Imports System.Data
Imports PClass.PClass
Imports C1.Win.C1FlexGrid
Public Class F89000_FileList
    Dim dtRights As DataTable

    Private Sub F89000_FileList_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadBaseData()
        List_ReFresh()
    End Sub

    Sub LoadBaseData()
        If Department_GetDeptAll().IsOk = False Then
            ShowErrMsg("加载部门资料失败!")
            Exit Sub
        End If
        If User_GetAll().IsOk = False Then
            ShowErrMsg("加载用户资料失败!")
            Exit Sub
        End If
        CreateTreeiew(DtDept)

     
    End Sub

    Private Sub FG1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles FG1.DoubleClick
        File_Modify()
    End Sub



#Region "生成树形菜单"
    Dim selectedDept As String = ""
    Dim selectNode As C1.Win.C1FlexGrid.Node
    Dim DtUser As DataTable
    Dim DtDept As DataTable
    Dim nodeMap As New Dictionary(Of String, C1.Win.C1FlexGrid.Node)
    Private Const RootID As String = "D0"
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <remarks></remarks>
    Protected Sub CreateTreeiew(ByVal dt As DataTable)
        nodeMap.Clear()
        Fg2.Rows.Count = 1
        Fg2.SubtotalPosition = SubtotalPositionEnum.AboveData
        Fg2.Rows.Count = 1
        Fg2.Tree.Column = 1
        Fg2.Tree.LineStyle = Drawing2D.DashStyle.Solid
        Fg2.Tree.Style = TreeStyleFlags.SimpleLeaf
        Dim Root As C1.Win.C1FlexGrid.Node = Fg2.Rows.InsertNode(1, 1)
        Fg2.Item(Root.Row.Index, "ID") = RootID
        Fg2.Item(Root.Row.Index, "Depart") = "部门"
        For Each dr In dt.Select(" len (Dept_No)=4 ")
            Dim nId As String = dr("Dept_No")
            Dim nName As String = dr("Dept_Name")
            Dim item As C1.Win.C1FlexGrid.Node = Root.AddNode(NodeTypeEnum.LastChild, nName, nId, My.Resources.Folder)
            Fg2.Item(item.Row.Index, "ID") = nId
            CreateUserNode(nId, item)
            nodeMap.Add(item.Key, item)
            item.Expanded = True
            For Each dr2 In dt.Select(" len (Dept_No)>=7 and substring (Dept_No,1,4)='" & nId & "'")
                CreateTreeItems(dr2("Dept_No"), dr2("Dept_Name"), item)
            Next
        Next
    End Sub



    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="nId"></param>
    ''' <param name="nName"></param>
    ''' <param name="parentItem"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CreateTreeItems(ByVal nId As String, ByVal nName As String, ByVal parentItem As C1.Win.C1FlexGrid.Node) As C1.Win.C1FlexGrid.Node
        Dim MParentID As String = nId.Substring(0, nId.Length - 3)
        Dim p As C1.Win.C1FlexGrid.Node
        If nodeMap.ContainsKey(MParentID) Then
            p = nodeMap(MParentID)
        Else
            Return Nothing
        End If
        ' Dim p As C1.Win.C1FlexGrid.Node = nodeMap(MParentID)
        If Not p Is Nothing Then
            Dim item As C1.Win.C1FlexGrid.Node = p.AddNode(NodeTypeEnum.LastChild, nName, nId, My.Resources.Folder)
            Fg2.Item(item.Row.Index, "ID") = nId
            CreateUserNode(nId, item)
            nodeMap.Add(item.Key, item)
            Return item
        Else
            Return Nothing
        End If
    End Function


    Protected Sub CreateUserNode(ByVal DepartID As String, ByVal parentItem As C1.Win.C1FlexGrid.Node)
        Dim drsE As DataRow() = DtUser.Select("User_Dept='" & DepartID & "'")
        For Each dr In drsE
            Dim I As Integer = parentItem.AddNode(NodeTypeEnum.LastChild, dr("User_Display"), dr("User_ID"), My.Resources.user).Row.Index
            '    Fg2.SetCellImage(1, 3, My.Resources.save)
            Fg2.Item(I, "DepartID") = DepartID
            Fg2.Item(I, "ID") = dr("User_ID")
            SetCheck(I, "CanOpen")
            SetUnCheck(I, "CanDel")
            SetUnCheck(I, "CanModify")
            SetUnCheck(I, "CanSetRight")
        Next
    End Sub





#End Region

#Region "FG权限处理事件"
    Private Const UnCheck As String = " "
    Private Const Check As String = "  "
    Private Const MUnCheck As String = "   "
    Private Const MCheck As String = "    "

    Private Sub FG1_SelectRowChange(ByVal Row As Integer) Handles FG1.SelectRowChange
        Right_ReFresh()
    End Sub


    Sub Right_ReFresh()
        If FG1.RowSel <= 0 Then Exit Sub
        Dim R As DtReturnMsg = GetFileRight(FG1.SelectItem("Name"))
        Dim Dr() As DataRow = R.Dt.Select("User_ID='" & User_Id & "'")
        If (Dr.Length = 0 OrElse IsNull(Dr(0)("CanSetRight"), False) = False) And User_Id <> "Admin" Then
            Fg2.Rows(1).Node.Expanded = False
            Fg2.Rows(1).Visible = False
            Cmd_RightSave.Enabled = False
        Else
            dtRights = R.Dt
            RightToFG(R.Dt)
            Fg2.Rows(1).Node.Expanded = True
            Fg2.Rows(1).Visible = True
            Cmd_RightSave.Enabled = True
        End If
    End Sub

    Sub RightToFG(ByVal Dt As DataTable)
        Dim CanOpenCol As Integer = Fg2.Cols.Item("CanOpen").Index
        Dim CanModifyCol As Integer = Fg2.Cols.Item("CanModify").Index
        Dim CanDelCol As Integer = Fg2.Cols.Item("CanDel").Index
        Dim CanSetRightCol As Integer = Fg2.Cols.Item("CanSetRight").Index

        For i As Integer = 1 To Fg2.Rows.Count - 1
            Dim R As Row = Fg2.Rows(i)
            Dim U As String = R("ID")
            If U.ToUpper.StartsWith("U") Then
                Dim Dr() As DataRow = Dt.Select("User_ID='" & U & "'")
                If Dr.Length = 0 Then
                    SetUnCheck(i, CanOpenCol, False)
                    SetUnCheck(i, CanModifyCol, False)
                    SetUnCheck(i, CanDelCol, False)
                    SetUnCheck(i, CanSetRightCol, False)
                Else
                    If IsNull(Dr(0)("CanOpen"), False) Then SetCheck(i, CanOpenCol, False) Else SetUnCheck(i, CanOpenCol, False)
                    If IsNull(Dr(0)("CanModify"), False) Then SetCheck(i, CanModifyCol, False) Else SetUnCheck(i, CanModifyCol, False)
                    If IsNull(Dr(0)("CanDel"), False) Then SetCheck(i, CanDelCol, False) Else SetUnCheck(i, CanDelCol, False)
                    If IsNull(Dr(0)("CanSetRight"), False) Then SetCheck(i, CanSetRightCol, False) Else SetUnCheck(i, CanSetRightCol, False)
                End If
                'Else
                '    SetUnCheck(i, CanOpenCol, False)
                '    SetUnCheck(i, CanModifyCol, False)
                '    SetUnCheck(i, CanDelCol, False)
                '    SetUnCheck(i, CanSetRightCol, False)
            End If
        Next
    End Sub


    Private Sub Fg2_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fg2.DoubleClick
        If Fg2.RowSel <= 0 Then Exit Sub
        If Fg2.ColSel <= 1 Then Exit Sub
        Dim ColItem As Column = Fg2.Cols(Fg2.ColSel)
        If ColItem.Name.StartsWith("Can") Then
            Select Case Fg2.Item(Fg2.RowSel, Fg2.ColSel)
                Case UnCheck '没有打钩
                    'SetCheck(Fg2.RowSel, ColItem.Name, True)
                Case Check '绿色的钩钩
                    'SetUnCheck(Fg2.RowSel, ColItem.Name, True)
                Case MUnCheck '红色的X
                    'SetCheck(Fg2.RowSel, ColItem.Name, True)
                Case MCheck '红色的钩钩
                    'SetUnCheck(Fg2.RowSel, ColItem.Name, True)
                Case Else
                    ShowConfirm("是否设置或取消该部门下所有的[" & Fg2.Item(0, ColItem.Name) & "]权限?", "设置权限", "取消权限", "什么都不做", AddressOf SetAll, AddressOf UnSetAll, AddressOf DoNothing)
            End Select
        End If
    End Sub

    Private Sub Fg2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Fg2.Click
        If Fg2.RowSel <= 0 Then Exit Sub
        If Fg2.ColSel <= 1 Then Exit Sub
        Dim ColItem As Column = Fg2.Cols(Fg2.ColSel)
        If ColItem.Name.StartsWith("Can") Then
            Select Case Fg2.Item(Fg2.RowSel, Fg2.ColSel)
                Case UnCheck '没有打钩
                    SetCheck(Fg2.RowSel, ColItem.Name, True)
                Case Check '绿色的钩钩
                    SetUnCheck(Fg2.RowSel, ColItem.Name, True)
                Case MUnCheck '红色的X
                    SetCheck(Fg2.RowSel, ColItem.Name, True)
                Case MCheck '红色的钩钩
                    SetUnCheck(Fg2.RowSel, ColItem.Name, True)
           End Select
        End If
    End Sub

    Sub SetAll()
        SelDeptUserFileRight(True)

    End Sub

    Sub UnSetAll()
        SelDeptUserFileRight()

    End Sub

    Sub SelDeptUserFileRight(Optional ByVal isHave As Boolean = False)
        If Fg2.RowSel = -1 Then
            ShowErrMsg("请选择一个部门")
            Exit Sub

        End If
        Dim pId As String = Fg2.Item(Fg2.RowSel, "ID")
        Dim ColItem As Column = Fg2.Cols(Fg2.ColSel)
        For i As Integer = Fg2.RowSel + 1 To Fg2.Rows.Count - 1
            Dim deptId As String = Fg2.Item(i, "DepartID")
            If Not deptId Is Nothing AndAlso deptId.StartsWith(pId) Then
                If isHave Then
                    SetCheck(i, ColItem.Name, True)
                Else
                    SetUnCheck(i, ColItem.Name, True)
                End If

            End If
        Next
    End Sub


    Private Sub SetUnCheck(ByVal Row As Integer, ByVal ColStr As String, Optional ByVal Modify As Boolean = False)
        Dim Col As Integer = Fg2.Cols.Item(ColStr).Index
        SetUnCheck(Row, Col, Modify)
    End Sub

    Private Sub SetUnCheck(ByVal Row As Integer, ByVal Col As Integer, Optional ByVal Modify As Boolean = False)
        If Modify Then
            Fg2.SetCellImage(Row, Col, My.Resources.MUnCheck)
            Fg2.Item(Row, Col) = MUnCheck
            Fg2.Item(Row, "IsModified") = True
        Else
            Fg2.SetCellImage(Row, Col, My.Resources.UnCheck)
            Fg2.Item(Row, Col) = UnCheck
            Fg2.Item(Row, "IsModified") = False
        End If
    End Sub

    Private Sub SetCheck(ByVal Row As Integer, ByVal ColStr As String, Optional ByVal Modify As Boolean = False)
        Dim Col As Integer = Fg2.Cols.Item(ColStr).Index
        SetCheck(Row, Col, Modify)
    End Sub

    Private Sub SetCheck(ByVal Row As Integer, ByVal Col As Integer, Optional ByVal Modify As Boolean = False)
        If Modify Then
            Fg2.SetCellImage(Row, Col, My.Resources.MCheck)
            Fg2.Item(Row, Col) = MCheck
            Fg2.Item(Row, "IsModified") = True
        Else
            Fg2.SetCellImage(Row, Col, My.Resources.Check)
            Fg2.Item(Row, Col) = Check
            Fg2.Item(Row, "IsModified") = False
        End If
    End Sub

    Private Sub Cmd_RightSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_RightSave.Click
        If FG1.RowSel <= 0 Then
            ShowErrMsg("请选择一个文件")
            Exit Sub
        End If
        ShowConfirm("是否保存文件 [" & FG1.SelectItem("Name") & "]?", AddressOf FileRight_Save)

    End Sub

    Protected Function RightToDt() As DataTable
        Dim fileName As String
        If FG1.RowSel <= 0 Then
            ShowErrMsg("请选择一个文件")
            Return New DataTable("T")
        End If
        fileName = FG1.SelectItem("Name")
        If Not dtRights Is Nothing Then
            dtRights.Clear()
            Dim dt As DataTable = dtRights.Clone
            Dim dr As DataRow
            For i As Integer = 1 To Fg2.Rows.Count - 1
                Dim s As String = Fg2.Item(i, "CanOpen")
                If Fg2.Item(i, "IsModified") = True Then
                    dr = dt.NewRow
                    dr("FileName") = fileName
                    dr("User_ID") = Fg2.Item(i, "ID")
                    dr("CanOpen") = (Fg2.Item(i, "CanOpen") = MCheck OrElse Fg2.Item(i, "CanOpen") = Check)
                    dr("CanModify") = (Fg2.Item(i, "CanModify") = MCheck OrElse Fg2.Item(i, "CanModify") = Check)
                    dr("CanDel") = (Fg2.Item(i, "CanDel") = MCheck OrElse Fg2.Item(i, "CanDel") = Check)
                    dr("CanSetRight") = (Fg2.Item(i, "CanSetRight") = MCheck OrElse Fg2.Item(i, "CanSetRight") = Check)
                    dt.Rows.Add(dr)
                Else

                End If
            Next
            Return dt
        End If
        Return New DataTable("T")
    End Function
#End Region

#Region "-----导航栏事件-----"
    Private Sub Cmd_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Add.Click
        ' If FG1.RowSel <= 0 Then ShowErrMsg("请选择一个文件?") : Exit Sub
        Dim F As New F89001_FileAdd
        With F
            .Mode = Mode_Enum.Add
            .P_F_RS_ID = ""
            .P_F_RS_ID2 = ""
        End With
        ReturnId = ""
        Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F, Me)
        AddHandler VF.ClosedX, AddressOf List_ReFresh
        VF.Show()
    End Sub

    Private Sub Cmd_Modify_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmd_Modify.Click
        File_Modify()
    End Sub
    Sub File_Modify()
        If FG1.RowSel <= 0 Then ShowErrMsg("请选择一个文件?") : Exit Sub
        Dim F As New F89001_FileAdd
        With F
            .Mode = Mode_Enum.Modify
            .P_F_RS_ID = FG1.SelectItem("Name")
            .P_F_RS_ID2 = FG1.SelectItem("Ver")
        End With
        ReturnId = ""
        Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F, Me)
        AddHandler VF.ClosedX, AddressOf List_ReFresh
        VF.Show()
    End Sub


    Private Sub Cmd_ReFresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_ReFresh.Click
        List_ReFresh()
    End Sub



    Private Sub Cmd_Del_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmd_Del.Click
        If FG1.RowSel <= 0 Then ShowErrMsg("请选择一个文件?") : Exit Sub
        '权限分析
        Dim Parameters As New Dictionary(Of String, Object)
        Parameters.Add("User_ID", User_Id)
        Parameters.Add("FileName", FG1.SelectItem("Name"))
        Dim R As DtReturnMsg = SqlStrToDt(SQL_89001_FormLoad, Parameters)
        If R.IsOk = False Then
            Exit Sub
        Else
            LastForm.ReturnId = F_RS_ID
            If User_Id <> "Admin" AndAlso (R.Dt.Rows.Count = 0 OrElse IsNull(R.Dt.Rows(0)("CanDel"), False) = False) Then
                ShowErrMsg("你没有权限删除该文档!", False)
                Exit Sub
            End If
        End If



        ShowConfirm("删除文件[" & FG1.SelectItem("Name") & "]的" & FormatNumber(FG1.SelectItem("Ver"), 2) & "版本,或者删除全部版本?", "当前版本", "全部版本", "取消", AddressOf Del_File, AddressOf DelAll_File, AddressOf DoNothing)
    End Sub
    Private Sub Del_File()
        ReturnId = FG1.SelectItem("Id")
        ShowRetrunMsg(Del_File(FG1.SelectItem("Id").ToString))
        List_ReFresh()
    End Sub

    Private Sub DelAll_File()
        ShowRetrunMsg(DelAll_File(FG1.SelectItem("Name").ToString))
        List_ReFresh()
    End Sub

    Private Sub DoNothing()

    End Sub

    ''' <summary>
    ''' 刷新权限列表
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_RightReFresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_RightReFresh.Click
        Right_ReFresh()
    End Sub

    ''' <summary>
    ''' 关闭页面
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub
#End Region

#Region "-----数据库交换-----"
    Private Function GetFileRight(ByVal FileName) As DtReturnMsg
        Dim R As DtReturnMsg = SqlStrToDt(SQL_89000_GetFileRight, "@ID", FileName)
        Return R
    End Function


    Private Function Del_File(ByVal F_ID As String) As MsgReturn
        Dim R As New MsgReturn
        Dim Cnn As New SqlClient.SqlConnection
        Dim Da As New SqlClient.SqlDataAdapter
        Dim DtR As DtReturnMsg = SqlStrToDt(SQL_89000_Del_File, Cnn, Da, "@ID", F_ID)
        If DtR.IsOk Then
            If DtR.Dt.Rows.Count > 0 Then
                '   DtR.Dt.Rows.Clear()
                DtR.Dt.Rows(0).Delete()
                Try
                    DtToUpDate(DtR.Dt, Cnn, Da)
                    R.IsOk = True
                    R.Msg = "删除成功!"
                Catch ex As Exception
                    R.Msg = "删除失败!" & ex.Message
                End Try
            Else
                R.Msg = "删除失败!文件当前版本已经被删除!"
            End If
        Else
            R.Msg = "删除失败!" & DtR.Msg
        End If
        If Not Da Is Nothing Then Da.Dispose()
        If Not Cnn Is Nothing Then Cnn.Dispose()
        Return R
    End Function
    Private Function DelAll_File(ByVal F_Name As String) As MsgReturn
        Dim R As New MsgReturn
        Dim Cnn As New SqlClient.SqlConnection
        Dim Da As New SqlClient.SqlDataAdapter
        Dim DtR As DtReturnMsg = SqlStrToDt(SQL_89000_DelAll_File, Cnn, Da, "@Name", F_Name)
        If DtR.IsOk Then
            If DtR.Dt.Rows.Count > 0 Then
                Dim i As Integer
                For i = DtR.Dt.Rows.Count - 1 To 0 Step -1
                    DtR.Dt.Rows(i).Delete()
                Next
                Try
                    DtToUpDate(DtR.Dt, Cnn, Da, "Delete from T891_FileRight where FileName=@FileName", "FileName", F_Name)
                    R.IsOk = True
                    R.Msg = "删除成功!"
                Catch ex As Exception
                    R.Msg = "删除失败!" & ex.Message
                End Try
            Else
                R.Msg = "删除失败!文件当前版本已经被删除!"
            End If
        Else
            R.Msg = "删除失败!" & DtR.Msg
        End If
        If Not Da Is Nothing Then Da.Dispose()
        If Not Cnn Is Nothing Then Cnn.Dispose()
        Return R
    End Function


    Sub List_ReFresh()
        FG1.SqlToFG("select * from V89000_NewFile")
        Dim Col As Integer = FG1.Cols("ico").Index
        For i As Integer = 1 To FG1.Rows.Count - 1
            Select Case FG1.Item(i, "type")
                Case "Word"
                    FG1.SetCellImage(i, Col, My.Resources.Word)
                Case "Excel"
                    FG1.SetCellImage(i, Col, My.Resources.Excel)
            End Select
        Next


        FG1.RowSetForce("Name", ReturnId)
    End Sub

    Private Function User_GetAll() As DtReturnMsg
        Dim msgUser As DtReturnMsg = PClass.PClass.SqlStrToDt(SQL_89000_User_GetAll)
        If msgUser.IsOk Then
            DtUser = msgUser.Dt
        End If
        Return msgUser
    End Function


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Private Function Department_GetDeptAll() As DtReturnMsg
        Dim msgDept As DtReturnMsg = PClass.PClass.SqlStrToDt(SQL_89000_Department_GetDeptAll)
        If msgDept.IsOk Then
            DtDept = msgDept.Dt
        End If
        Return msgDept
    End Function


    Protected Function FileRight_Save()
        Dim Cnn As New SqlClient.SqlConnection
        Dim Da As New SqlClient.SqlDataAdapter
        Dim dt As DataTable
        Dim sql As String
        Dim deptId As String = FG1.SelectItem("Name")
        Dim dtSource As DataTable = RightToDt()
        Try

            sql = "select  * from T891_FileRight where FileName=@FileName "
            dt = SqlStrToDt(sql, Cnn, Da, "@FileName", deptId).Dt
            For Each dr In dtSource.Rows
                Dim rows() As DataRow = dt.Select("User_ID='" & dr("User_ID") & "'")
                If rows.Length > 0 Then
                 
                    rows(0)("CanOpen") = dr("CanOpen")
                    rows(0)("CanModify") = dr("CanModify") '= (Fg2.Item(i, "CanDel") = MCheck OrElse Fg2.Item(i, "CanDel") = Check)
                    rows(0)("CanSetRight") = dr("CanSetRight") '= (Fg2.Item(i, "CanSetRight") = MCheck OrElse Fg2.Item(i, "CanSetRight") = Check)
                    rows(0)("CanDel") = dr("CanDel")
                Else
                    dt.ImportRow(dr)
                End If
            Next
            DtToUpDate(dt, Cnn, Da)
            Right_ReFresh()
            Return True
        Catch ex As Exception

            DebugToLog(ex)
            Return False
        End Try
    End Function
#End Region









   


 

End Class
