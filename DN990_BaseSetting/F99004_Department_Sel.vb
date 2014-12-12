Imports PClass.PClass
Imports System.Data
Imports BaseClass

Public Class F99004_Department_Sel
    Dim selectedDept As String = ""
    Dim DtDepts As New DataTable
    Dim DtEmployee As New DataTable
    Dim DtUser As New DataTable
    Dim DtDept As New DataTable
    Dim groupDt As New DataTable
    Dim selectNode As TreeNode

    ''' <summary>
    ''' 权限获取
    ''' </summary>
    ''' <remarks></remarks>
    Sub FormCheckRight()
        ID = 15000
        Control_CheckRight(ID, ClassMain.Add, Cmd_Add)
        TSMI_AddDept.Enabled = Cmd_Add.Enabled
        Control_CheckRight(ID, ClassMain.Modify, Cmd_Modify)
        Control_CheckRight(ID, ClassMain.Del, Cmd_Del)
        TSMI_Del.Enabled = Cmd_Del.Enabled
    End Sub

    Private Sub F99003_Department_Me_Load() Handles Me.Me_Load
        FormCheckRight()
        Dim msgDept As DtReturnMsg = Department_GetDeptAll()
        If msgDept.IsOk Then
            DtDepts = msgDept.Dt
            CreateTreeiew(DtDepts)
        End If
    End Sub
#Region "生成树形菜单"
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <remarks></remarks>
    Protected Sub CreateTreeiew(ByVal dt As DataTable)
        Dim root As New TreeNode
        root.Name = "D0"
        root.Text = "部门"
        root.ImageIndex = 0
        root.Tag = Enum_HR.Department
        root.Expand()
        For Each dr In dt.Select(" len (Dept_No)=4 ")
            Dim item As New TreeNode
            Dim nId As String = dr("Dept_No")
            Dim nName As String = dr("Dept_Name")
            item.Name = nId
            item.Text = nName
            item.Tag = Enum_HR.Department
            If nId = selectedDept Then
                selectNode = item
            End If


            root.Nodes.Add(item)
            For Each dr2 In dt.Select(" len (Dept_No)>=7 and substring (Dept_No,1,4)='" & nId & "'")
                CreateTreeItems(dr2("Dept_No"), dr2("Dept_Name"), item)
            Next
        Next

        TreeView_Dept.Nodes.Clear()

        TreeView_Dept.Nodes.Add(root)
        TreeView_Dept.SelectedNode = selectNode

    End Sub



    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="nodeName"></param>
    ''' <param name="nodeText"></param>
    ''' <param name="parentItem"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CreateTreeItems(ByVal nodeName As String, ByVal nodeText As String, ByVal parentItem As TreeNode) As TreeNode

        Dim MParentID As String = nodeName.Substring(0, nodeName.Length - 3)
        If MParentID.Length = parentItem.Name.Length Then
            If MParentID = parentItem.Name Then
                Dim item As TreeNode = New TreeNode
                item.Name = nodeName
                item.Text = nodeText
                item.Tag = Enum_HR.Department

                If nodeName = selectedDept Then
                    selectNode = item
                End If
                If nodeName = selectedDept Then
                    item.Checked = True
                    item.Expand()
                End If




                parentItem.Nodes.Add(item)
                Return item
            Else
                Return parentItem
            End If
        Else
            If MParentID.Length > parentItem.Name.Length Then
                Return parentItem
            Else
                Return CreateTreeItems(nodeName, nodeText, parentItem.Parent)
            End If
        End If
    End Function


#End Region

#Region "树形菜单事件"

    Private Sub TreeView_Dept_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles TreeView_Dept.DragDrop

    End Sub
    Private Sub TreeView_Dept_NodeMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles TreeView_Dept.NodeMouseClick
        If e.Node Is Nothing Then
            Exit Sub
        End If
        Dim nodeName As String = e.Node.Name

        If Not DtDepts Is Nothing Then
            Try
                If e.Node.Name = "D0" Then

                    TextBox_DeptNo.Text = "D0"
                    TextBox_DeptName.Text = "所有部门"
                    TextBox_DeptSup.Text = ""
                    TextBox_ENumPrefix.Text = ""
                    CB_IsProductive.Visible = False
                Else
                    Dim dr As DataRow = DtDepts.Select("Dept_No='" & nodeName & "'")(0)
                    TextBox_DeptNo.Text = IsNull(dr("Dept_No"), "")
                    TextBox_DeptName.Text = IsNull(dr("Dept_Name"), "")
                    TextBox_DeptSup.Text = IsNull(dr("Dept_SupperVisor"), "")
                    TextBox_ENumPrefix.Text = IsNull(dr("Dept_ENumPrefix"), "")
                    CB_IsProductive.Checked = IsNull(dr("IsProductive"), False)
                    If TextBox_DeptNo.Text.Length = 4 Then
                        CB_IsProductive.Visible = True
                    Else
                        CB_IsProductive.Visible = False
                    End If
                End If

            Catch ex As Exception
                TextBox_DeptNo.Text = "D0"
                TextBox_DeptName.Text = "所有部门"
                TextBox_DeptSup.Text = ""
                TextBox_ENumPrefix.Text = ""
            End Try
        End If
    End Sub

    Private Sub TreeView_Dept_NodeMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles TreeView_Dept.NodeMouseDoubleClick
        If e.Node Is Nothing Then
            Exit Sub
        End If
        Dim pf As PClass.BaseForm = TryCast(Me.LastForm, PClass.BaseForm)
        If Not pf Is Nothing Then
            If e.Node.Name.Length = 7 Then
                pf.ReturnObj = e.Node.Parent.Text & "/" & e.Node.Text
            ElseIf e.Node.Name.Length = 4 Then
                pf.ReturnObj = e.Node.Text
            End If
            pf.ReturnId = e.Node.Name

            Me.Close()
        End If
    End Sub

#End Region

#Region "工具栏事件"
    ''''==========================部门===========================

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Btn_SaveDept_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Modify.Click
        If CheckForm() Then ShowConfirm("是否保存部门[" & TextBox_DeptNo.Text & "]?", AddressOf SaveDept)
    End Sub

    Protected Sub SaveDept()
        If Label_Mode.Tag = "Add" Then
            Department_AddSave()
        Else
            Department_ModifySave()
            selectedDept = TextBox_DeptNo.Text
        End If
        F99003_Department_Me_Load()
        Label_Mode.Tag = ""
    End Sub

    Private Sub Btn_DelDept_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Del.Click
        ShowConfirm("是否删除部门[" & TextBox_DeptName.Text & "]?", AddressOf DelDept)
    End Sub

    Protected Sub DelDept()
        Dim msg As MsgReturn = Dept_Delete(TextBox_DeptNo.Text)
        If msg.IsOk = False Then
            ShowErrMsg(msg.Msg)
        Else
            selectedDept = "D0"
        End If
        F99003_Department_Me_Load()
    End Sub

    Protected Function CheckForm() As Boolean
        If TextBox_DeptNo.Text = "" Then
            ShowErrMsg("部门编号不能为空")
            TextBox_DeptNo.Focus()
            Return False
        End If
        If TextBox_DeptName.Text = "" Then
            ShowErrMsg("部门名称不能为空")
            TextBox_DeptName.Focus()
            Return False
        End If
        Return True
    End Function
    ''' <summary>
    ''' 刷新页面
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_Reflesh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Reflesh.Click
        F99003_Department_Me_Load()
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub

    Private Sub Cmd_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Add.Click
        TSMI_AddDept_Click(TSMI_AddDept, e)
    End Sub
#End Region

#Region "右键菜单"

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TSMI_AddDept_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMI_AddDept.Click
        If Me.TreeView_Dept.SelectedNode Is Nothing OrElse Not Me.TreeView_Dept.SelectedNode.Tag = Enum_HR.Department Then
            ShowErrMsg("请选择一个部门")
        Else
            Me.selectedDept = Me.TreeView_Dept.SelectedNode.Name

            Label_Mode.Tag = "Add"

            TextBox_DeptNo.Text = Department_GetNewDeptID(TreeView_Dept.SelectedNode.Name)
            TextBox_DeptName.Text = ""
            TextBox_DeptSup.Text = ""
            TextBox_ENumPrefix.Text = ""
            If TextBox_DeptNo.Text.Length = 4 Then
                CB_IsProductive.Visible = True
            Else
                CB_IsProductive.Visible = False
            End If
        End If
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TSMI_Del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMI_Del.Click
        If Me.TreeView_Dept.SelectedNode Is Nothing Then
            Exit Sub
        Else

            ShowConfirm("是否删除部门[" & TextBox_DeptName.Text & "]?", AddressOf DelDept)

        End If
    End Sub

#End Region

#Region "数据库交互"
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <param name="condition"></param>
    ''' <param name="sortstr"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetNewDataTable(ByVal dt As DataTable, ByVal condition As String, ByVal sortstr As String) As DataTable
        Dim newdt As New DataTable()
        newdt = dt.Clone()
        Dim dr As DataRow() = dt.Select(condition, sortstr)
        For i As Integer = 0 To dr.Length - 1
            newdt.ImportRow(DirectCast(dr(i), DataRow))
        Next
        Return newdt
        '返回的查询结果
    End Function


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Protected Function Department_GetDeptAll() As DtReturnMsg
        Dim sql As String = "select * from T15000_Department order by Dept_No"
        Return PClass.PClass.SqlStrToDt(sql)

    End Function

    Protected Function Department_GetDeptById(ByVal id As String) As DtReturnMsg
        Dim sql As String = "select * from T15000_Department where Dept_No='" & id & "' order by Dept_No"
        Return PClass.PClass.SqlStrToDt(sql)
    End Function
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Department_GetNewDeptID(ByVal parentId As String) As String
        Try
            Dim sql As String
            Dim msg As New MsgReturn
            If parentId.Length >= 4 Then
                sql = "select top 1 Dept_No  from T15000_Department where Dept_No like '" & parentId & "%' order by Dept_No desc"
            Else
                parentId = "D"
                sql = "select top 1 Dept_No  from T15000_Department where len( Dept_No)=4  order by Dept_No desc"
            End If

            msg = SqlStrToOneStr(sql)

            If msg.IsOk Then
                Dim s As String = ""
                Dim i As Integer
                If msg.Msg.Length = parentId.Length Then
                    i = 1
                Else
                    i = Integer.Parse(msg.Msg.Substring(msg.Msg.Length - 3, 3))
                End If





                i = i + 1
                If i < 10 Then
                    s = "00" & i
                ElseIf i > 10 AndAlso i < 100 Then
                    s = "0" & i
                End If
                Return parentId & s

            Else
                Return ""

            End If
        Catch ex As Exception
            DebugToLog(ex)
            Return ""
        End Try
    End Function



#Region "增删改"
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Department_AddSave() As Boolean
        Dim Cnn As New SqlClient.SqlConnection
        Dim Da As New SqlClient.SqlDataAdapter
        Dim dt As DataTable
        Dim sql As String
        Dim deptId As String = ""
        Try

            sql = "select top 1 * from T15000_Department where Dept_No=@Dept_No order by Dept_No"
            dt = SqlStrToDt(sql, Cnn, Da, "Dept_No", deptId).Dt
            If dt.Rows.Count = 0 Then
                dt.Rows.Add(dt.NewRow)
                dt.Rows(0)("Dept_No") = TextBox_DeptNo.Text
                dt.Rows(0)("Dept_Name") = TextBox_DeptName.Text
                dt.Rows(0)("Dept_SupperVisor") = TextBox_DeptSup.Text
                dt.Rows(0)("Dept_ENumPrefix") = TextBox_ENumPrefix.Text
                dt.Rows(0)("IsProductive") = CB_IsProductive.Checked
                DtToUpDate(dt, Cnn, Da)
            Else
                ShowErrMsg("部门:[" & TextBox_DeptNo.Text & "] 已经存在")
            End If
            Da.Dispose()
            Cnn.Dispose()
            Return True
        Catch ex As Exception
            ShowErrMsg("部门:[" & TextBox_DeptNo.Text & "] 修改错误")
            DebugToLog(ex)
            Return False
        End Try
    End Function
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Department_ModifySave() As Boolean
        Dim Cnn As New SqlClient.SqlConnection
        Dim Da As New SqlClient.SqlDataAdapter
        Dim dt As DataTable
        Dim sql As String
        Dim deptId As String = TextBox_DeptNo.Text
        Try

            sql = "select top 1 * from T15000_Department where Dept_No=@Dept_No order by Dept_No"
            dt = SqlStrToDt(sql, Cnn, Da, "Dept_No", deptId).Dt
            If dt.Rows.Count = 1 Then

                dt.Rows(0)("Dept_No") = TextBox_DeptNo.Text
                dt.Rows(0)("Dept_Name") = TextBox_DeptName.Text
                dt.Rows(0)("Dept_SupperVisor") = TextBox_DeptSup.Text
                dt.Rows(0)("Dept_ENumPrefix") = TextBox_ENumPrefix.Text
                dt.Rows(0)("IsProductive") = CB_IsProductive.Checked
                DtToUpDate(dt, Cnn, Da)
            Else
                ShowErrMsg("部门:[" & TextBox_DeptNo.Text & "]不存在")
            End If
            Da.Dispose()
            Cnn.Dispose()
            Return True
        Catch ex As Exception
            ShowErrMsg("部门:[" & TextBox_DeptNo.Text & "] 修改错误")
            DebugToLog(ex)
            Return False
        End Try
    End Function
    Protected Function Dept_Delete(ByVal id As String) As MsgReturn
        Dim sql As String = "Delete  from T15000_Department where Dept_No='" & id & "' "
        Return PClass.PClass.RunSQL(sql)
    End Function
#End Region


#End Region









End Class

