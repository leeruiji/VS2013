Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports BaseClass
Imports PClass

Public Class F10053_WorkList_Msg
    Dim ImagArray As Byte()
    Dim WorkList_Id As Integer = 0
    Dim list_NO As String
    Dim dtTable As DataTable
    Dim dtList As DataTable
    Public Sub New()

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。

    End Sub

    Public Sub New(ByVal goodsID As Integer, ByVal list_No As String)

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        Me.list_NO = list_No
        Me.WorkList_Id = goodsID
        Me.Mode = Mode

    End Sub

    Private Sub F10001_BZ_Msg_Form_KeyDown(ByVal sender As Object, ByRef e As System.Windows.Forms.KeyEventArgs) Handles Me.Form_KeyDown
        If e.KeyCode = Keys.Enter Then
            Try

                If Me.ActiveControl.Name <> Fg1.Name AndAlso ActiveControl.Parent.Name <> Fg1.Name Then
                    SendKeys.SendWait("{TAB}")
                End If

            Catch ex As Exception
            End Try
        End If
    End Sub

    ''' <summary>
    ''' 权限获取
    ''' </summary>
    ''' <remarks></remarks>
    Sub FormCheckRight()

        Control_CheckRight(10030, ClassMain.Modify, Cmd_Modify)
        Control_CheckRight(10030, ClassMain.Del, Cmd_Del)
    End Sub

    Private Sub FormLoad() Handles Me.Me_Load


        Fg1.IniColsSize()



        FormCheckRight()
        '  GetSupplierList()
        Me_Refresh()
        Cmd_ShowList.Checked = My.Settings.show
        Cmd_ShowList_Click(Cmd_ShowList, New EventArgs)
        If Mode = Mode_Enum.Add Then
            Cmd_Del.Visible = False
            If CheckRight(10030, ClassMain.Add) = False Then Me.ShowErrMsg("没有权限添加!", True) : Exit Sub
            WorkList_Id = 0
            TB_ID.Text = Dao.WorkList_GetNewID()

        End If
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub Me_Refresh()
        Dim msg As DtReturnMsg = Dao.WorkList_GetById(WorkList_Id)
        If msg.IsOk Then
            dtTable = msg.Dt
            SetForm(msg.Dt)
        End If

        Dim msgList As DtReturnMsg = Dao.List_GetById(list_NO)
        If msgList.IsOk Then
            dtList = msgList.Dt
            Fg1.DtToSetFG(dtList)
        End If

        Dim msgWork_Get As DtReturnMsg = Dao.Work_Get()

        If msgWork_Get.IsOk Then
            Try
                ComFun.Dt_LeftJoin(msgWork_Get.Dt, BaseClass.ComFun.GH_GetStateTable(), "Process_Name", "StateName", "Process", "State", "State=%Process%")
                'Dim AddRow As New Dictionary(Of String, String)
                'Dim LinkRow As New Dictionary(Of String, String)
                'AddRow.Add("Process_Name", "StateName")
                'LinkRow.Add("Process", "State")
                'ComFun.Dt_LeftJoin(msg.Dt, BaseClass.ComFun.GH_GetStateTable(), AddRow, LinkRow)
                Fg_Sel.DtToFG(msgWork_Get.Dt)

            Catch ex As Exception
                DebugToLog(ex)
            End Try

        End If
       
     
    End Sub

    '#Region "Combobox"

    '    Protected Sub GetSupplierList()
    '        Dim msg As DtReturnMsg = Supplier_GetAll()
    '        If msg.IsOk Then
    '            CB_Supplier.DataSource = msg.Dt
    '        End If
    '    End Sub

    '#End Region

#Region "表单信息"
    ''' <summary>
    ''' 获取表单内容
    ''' </summary>
    ''' <remarks></remarks>
    Protected Function GetForm() As DataTable
        Dim dt As DataTable
        dt = dtTable.Clone
        If Not dt Is Nothing Then
            dt.Clear()
            Dim dr As DataRow = dt.NewRow
            dt.Rows.Add(dr)
            If Mode <> Mode_Enum.Add Then dr("ID") = WorkList_Id
            dt.Rows(0)("WorkList_No") = TB_ID.Text
            dt.Rows(0)("WorkList_Name") = TB_Name.Text
            dt.Rows(0)("WorkList_Remark") = TB_Remark.Text
            dt.Rows(0)("Founder") = TB_Founder.Tag
            dt.Rows(0)("Found_Date") = DP_Found_Date.Value
            dt.Rows(0)("UPD_USER") = PClass.PClass.User_ID
            dt.Rows(0)("UPD_DATE") = Today
        End If
        Return dt
    End Function

    ''' <summary>
    ''' 设置表单内容
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub SetForm(ByVal dt As DataTable)
        If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
            TB_ID.Text = IsNull(dt.Rows(0)("WorkList_No"), "")
            TB_Name.Text = IsNull(dt.Rows(0)("WorkList_Name"), "")
            TB_Remark.Text = IsNull(dt.Rows(0)("WorkList_Remark"), "")
            TB_UPD_USER.Text = ComFun.User_GetNameByID(IsNull(dt.Rows(0)("UPD_User"), ""))
            TB_UPD_USER.Tag = IsNull(dt.Rows(0)("UPD_User"), "")
            TB_Founder.Tag = IsNull(dt.Rows(0)("Founder"), "")
            TB_Founder.Text = ComFun.User_GetNameByID(IsNull(dt.Rows(0)("Founder"), ""))
            If Not dt.Rows(0)("Found_Date") Is DBNull.Value Then
                DP_Found_Date.Text = dt.Rows(0)("Found_Date")
            End If
            If Not dt.Rows(0)("UPD_DATE") Is DBNull.Value Then
                DP_UPD_DATE.Value = dt.Rows(0)("UPD_DATE")
            End If

        Else
            TB_ID.Text = Me.WorkList_Id
            TB_Name.Text = ""
            TB_UPD_USER.Text = ""
            TB_Founder.Tag = PClass.PClass.User_ID
            TB_Founder.Text = PClass.PClass.User_Name
        End If

    End Sub


    ''' <summary>
    ''' 获取表单内容
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub GetList()
        Dim dt As DataTable = dtList.Clone
        Dim dr As DataRow
        For i = 1 To Fg1.Rows.Count - 1
            dr = dt.NewRow
            dr("WorkList_Index") = i
            dr("Work_ID") = TB_ID.Text
            dr("Work_No") = Fg1.Item(i, "Work_No")
            dr("Process_Name") = Fg1.Item(i, "Process_Name")
            dt.Rows.Add(dr)
        Next
        dtList = dt
    End Sub
#End Region

#Region "工具栏,按钮"


    Private Sub Cmd_Modify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Modify.Click
        If CheckForm() Then ShowConfirm("是否保存加工集合[" & TB_Name.Text & "] 的修改?", AddressOf Save)
    End Sub

    Protected Sub Save()
        Dim R As MsgReturn
        GetList()
        If Me.Mode = Mode_Enum.Add Then
            R = Dao.WorkList_Add(GetForm(), dtList)
        Else
            R = Dao.WorkList_Save(GetForm(), dtList)
        End If
        If R.IsOk Then
            LastForm.ReturnId = TB_ID.Text
            Me.Close()
        Else
            ShowErrMsg(R.Msg)
        End If
    End Sub
    Protected Function CheckForm() As Boolean
        Fg1.FinishEditing(False)
        If TB_ID.Text = "" Then
            ShowErrMsg("加工集合编号不能为空")
            TB_ID.Focus()
            Return False
        End If
        If TB_Name.Text = "" Then
            ShowErrMsg("加工集合名称不能为空")
            TB_Name.Focus()
            Return False
        End If
        Return True
    End Function




    Private Sub Cmd_Del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Del.Click
        ShowConfirm("是否删除加工集合[" & TB_ID.Text & "]?", AddressOf DelGoods)
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub DelGoods()
        Dim msg As MsgReturn = Dao.WorkList_Del(WorkList_Id)
        If msg.IsOk Then
            Me.Close()
        Else
            ShowErrMsg(msg.Msg)

        End If

    End Sub

    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click '关闭事件
        Me.Close()
    End Sub



    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click   '前加
        Beforechoose()
    End Sub

    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.Click   '后加
        Afterchoose()
    End Sub

  

    Private Sub ToolStripButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton6.Click '删除
       
        Remove()

    End Sub

   

 

    Private Sub Cmd_ShowList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_ShowList.Click   '显示反选   If Cmd_ShowList.Checked Then

        Dim index As Integer = 1
        If Cmd_ShowList.Checked Then
            For i As Integer = 1 To Fg1.Rows.Count - 1
                For s As Integer = 1 To Fg_Sel.Rows.Count - 1
                    If Fg_Sel.Item(s, "Work_No") = Fg1.Item(i, "Work_No") Then
                        Fg_Sel.Rows(s).Visible = False
                    End If
                Next
            Next
            For i As Integer = 1 To Fg_Sel.Rows.Count - 1
                If Fg_Sel.Rows(i).Visible = True Then
                    Fg_Sel.Item(i, "FG_Index") = index
                    index += 1
                End If
            Next
            Cmd_ShowList.Text = "反显"
        Else
            For i As Integer = 1 To Fg_Sel.Rows.Count - 1

                Fg_Sel.Rows(i).Visible = True
                Fg_Sel.ReAddIndex()
            Next
            Cmd_ShowList.Text = "全显"
        End If
        My.Settings.show = Cmd_ShowList.Checked
        My.Settings.Save()
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click '集体插入
        GetGoods()
    End Sub
    Private Sub Cmd_AddWorkList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_AddWorkList.Click  '集体插入
        GetGoods()
    End Sub

    Private Sub ToolStripButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton7.Click '上移
        Upmove()
    End Sub


    Private Sub ToolStripButton8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton8.Click '下移
        DownMove()
    End Sub


    Private Sub Remove()

        If Cmd_ShowList.Checked = False Then
            Fg1.RemoveRow()
            Exit Sub
        End If
        Try

            Dim index As Integer = 1
            For i As Integer = 1 To Fg_Sel.Rows.Count - 1
                If Fg_Sel.Item(i, "Work_No") = Fg1.Item(Fg1.RowSel, "Work_No") Then

                    Fg_Sel.Rows(i).Visible = True
                End If
            Next

            For i As Integer = 1 To Fg_Sel.Rows.Count - 1
                If Fg_Sel.Rows(i).Visible = True Then
                    Fg_Sel.Item(i, "FG_Index") = index
                    index += 1

                End If
            Next


            Fg1.RemoveRow()
        Catch ex As Exception

        End Try




    End Sub






    Private Sub GetGoods()
        Dim F As New F10052_WorkList
        If F Is Nothing Then Exit Sub
        With F
            .P_F_RS_ID = ""
            .P_F_RS_ID2 = ""
            .P_F_RS_ID4 = ""
            .IsSel = True
        End With
        ReturnId = ""
        Me.ReturnObj = Nothing
        Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F, Me)
        AddHandler VF.ClosedX, AddressOf GetGoodsAll
        VF.Show()
    End Sub
    Private Sub GetGoodsAll()
        Dim msgList As DtReturnMsg = Dao.List_GetById(ReturnId)
        If msgList.IsOk Then
            For i As Integer = 0 To msgList.Dt.Rows.Count - 1
                Fg1.AddRow()
                Fg1.Item(Fg1.Rows.Count - 1, "Work_No") = msgList.Dt.Rows(i)("Work_No")
                Fg1.Item(Fg1.Rows.Count - 1, "Work_Name") = msgList.Dt.Rows(i)("Work_Name")
                Fg1.Item(Fg1.Rows.Count - 1, "Dept_Name") = msgList.Dt.Rows(i)("Dept_Name")
                Fg1.Item(Fg1.Rows.Count - 1, "Process_Name") = msgList.Dt.Rows(i)("Process_Name")


            Next
        End If

    End Sub
    Private Sub Upmove()
        If Fg1.RowSel < 2 Then
            Exit Sub
        End If

        Dim dt As New DataTable
        Dim dr As DataRow
        Dim da As New DataColumn("Work_No", GetType(String))
        dt.Columns.Add(da)
        Dim db As New DataColumn("Work_Name", GetType(String))
        dt.Columns.Add(db)
        Dim dc As New DataColumn("Dept_Name", GetType(String))
        dt.Columns.Add(dc)
        Dim dd As New DataColumn("Process_Name", GetType(String))
        dt.Columns.Add(dd)
        dr = dt.NewRow

        Dim index As Integer = Fg1.RowSel - 1

        dr("Work_No") = Fg1.Item(Fg1.RowSel, "Work_No")
        dr("Work_Name") = Fg1.Item(Fg1.RowSel, "Work_Name")
        dr("Dept_Name") = Fg1.Item(Fg1.RowSel, "Dept_Name")
        dr("Process_Name") = Fg1.Item(Fg1.RowSel, "Process_Name")

        Dim Row As C1.Win.C1FlexGrid.Row
        Row = Fg1.Rows(Fg1.RowSel - 1)

        Fg1.Item(Fg1.RowSel, "Work_No") = Row("Work_No")
        Fg1.Item(Fg1.RowSel, "Work_Name") = Row("Work_Name")
        Fg1.Item(Fg1.RowSel, "Dept_Name") = Row("Dept_Name")
        Fg1.Item(Fg1.RowSel, "Process_Name") = Row("Process_Name")

        Fg1.Item(Fg1.RowSel - 1, "Work_No") = dr("Work_No")
        Fg1.Item(Fg1.RowSel - 1, "Work_Name") = dr("Work_Name")
        Fg1.Item(Fg1.RowSel - 1, "Dept_Name") = dr("Dept_Name")
        Fg1.Item(Fg1.RowSel - 1, "Process_Name") = dr("Process_Name")

        Fg1.ReAddIndex()
        Fg1.RowSel = index
        Fg1.Row = index
    End Sub
    Private Sub DownMove()
        If Fg1.RowSel < 1 Then
            Exit Sub
        End If

        Dim dt As New DataTable
        Dim dr As DataRow
        Dim da As New DataColumn("Work_No", GetType(String))
        dt.Columns.Add(da)
        Dim db As New DataColumn("Work_Name", GetType(String))
        dt.Columns.Add(db)
        Dim dc As New DataColumn("Dept_Name", GetType(String))
        dt.Columns.Add(dc)
        Dim dd As New DataColumn("Process_Name", GetType(String))
        dt.Columns.Add(dd)
        dr = dt.NewRow

        Dim index As Integer = Fg1.RowSel + 1

        dr("Work_No") = Fg1.Item(Fg1.RowSel, "Work_No")
        dr("Work_Name") = Fg1.Item(Fg1.RowSel, "Work_Name")
        dr("Dept_Name") = Fg1.Item(Fg1.RowSel, "Dept_Name")
        dr("Process_Name") = Fg1.Item(Fg1.RowSel, "Process_Name")
        Try
            Dim Row As C1.Win.C1FlexGrid.Row
            Row = Fg1.Rows(Fg1.RowSel + 1)

            Fg1.Item(Fg1.RowSel, "Work_No") = Row("Work_No")
            Fg1.Item(Fg1.RowSel, "Work_Name") = Row("Work_Name")
            Fg1.Item(Fg1.RowSel, "Dept_Name") = Row("Dept_Name")
            Fg1.Item(Fg1.RowSel, "Process_Name") = Row("Process_Name")

            Fg1.Item(Fg1.RowSel + 1, "Work_No") = dr("Work_No")
            Fg1.Item(Fg1.RowSel + 1, "Work_Name") = dr("Work_Name")
            Fg1.Item(Fg1.RowSel + 1, "Dept_Name") = dr("Dept_Name")
            Fg1.Item(Fg1.RowSel + 1, "Process_Name") = dr("Process_Name")

            Fg1.ReAddIndex()
            Fg1.RowSel = index
            Fg1.Row = index
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Beforechoose()
        Dim index As Integer = 1
        ReturnId = Fg_Sel.SelectItem("ID")
        ReturnObj = Fg_Sel.SelectItem
        If Fg_Sel.Rows(Fg_Sel.RowSel).Visible = True Then
            AddWorkBefore()
        End If
        If Cmd_ShowList.Checked Then
            Fg_Sel.Rows(Fg_Sel.RowSel).Visible = False
            For i As Integer = 1 To Fg_Sel.Rows.Count - 1
                If Fg_Sel.Rows(i).Visible = True Then

                    Fg_Sel.Item(i, "FG_Index") = index
                    index += 1

                End If
            Next
        End If
    End Sub
    Private Sub Afterchoose()
        Dim index As Integer = 1
        ReturnId = Fg_Sel.SelectItem("ID")
        ReturnObj = Fg_Sel.SelectItem
        If Fg_Sel.Rows(Fg_Sel.RowSel).Visible = True Then
            AddWorkAfter()
        End If
        If Cmd_ShowList.Checked Then
            Fg_Sel.Rows(Fg_Sel.RowSel).Visible = False
            For i As Integer = 1 To Fg_Sel.Rows.Count - 1
                If Fg_Sel.Rows(i).Visible = True Then

                    Fg_Sel.Item(i, "FG_Index") = index
                    index += 1

                End If
            Next
        End If
    End Sub

#End Region


#Region "FG事件"
    Private Sub Fg_Sel_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Fg_Sel.DoubleClick    '双击后移
        
        Afterchoose()

    End Sub

    Private Sub Fg1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Fg1.DoubleClick    '双击删除
        Remove()
    End Sub

    Private Sub Cmd_AddRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_AddRowBefore.Click
        Dim VF As ViewForm = SelectWork()
        If VF IsNot Nothing Then
            AddHandler VF.ClosedX, AddressOf AddWorkBefore
            VF.Show()
        End If
    End Sub

    Private Sub Cmd_AddRowAfter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_AddRowAfter.Click
        Dim VF As ViewForm = SelectWork()
        If VF IsNot Nothing Then
            AddHandler VF.ClosedX, AddressOf AddWorkAfter
            VF.Show()
        End If
    End Sub
    Private Function SelectWork() As ViewForm
        Dim f As New F10050_Work()
        If f Is Nothing Then Return Nothing
        With f
            .P_F_RS_ID = ""
            .P_F_RS_ID2 = ""
            .P_F_RS_ID4 = ""
            .IsSel = True
        End With
        ReturnId = ""
        Me.ReturnObj = Nothing
        Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(f, Me)
        Return VF
    End Function



    Protected Sub AddWorkBefore()
        InsertWork(True)
    End Sub
    Protected Sub AddWorkAfter()
        InsertWork(False)
    End Sub

    Sub InsertWork(ByVal BeforeOrAfter As Boolean)
        If ReturnObj Is Nothing Then
            Exit Sub
        End If

        Try

            Dim Dr As DataRow = TryCast(ReturnObj, DataRow)
            If Dr Is Nothing Then
                Exit Sub
            End If
            Dim index As Integer = 1
            Dim Row As C1.Win.C1FlexGrid.Row
            If BeforeOrAfter Then
                If Fg1.RowSel > 1 Then
                    index = Fg1.RowSel
                End If
                Row = Fg1.Rows.Insert(index)
            Else
                If Fg1.RowSel > 1 Then
                    If Fg1.RowSel = Fg1.Rows.Count - 1 Then
                        Row = Fg1.Rows.Add()
                    Else
                        index = Fg1.RowSel + 1
                        Row = Fg1.Rows.Insert(index)
                    End If
                Else
                    Row = Fg1.Rows.Add()
                End If
            End If
            Row("Work_No") = Dr("Work_No")
            Row("Work_Name") = Dr("Work_Name")
            Row("Dept_Name") = Dr("Dept_Name")
            Row("Process_Name") = Dr("Process_Name")
            Fg1.ReAddIndex()
            Fg1.RowSel = Row.Index
            Fg1.Row = Row.Index
        Catch ex As Exception
            If Ide Then MsgBox(ex.Message)
        End Try
    End Sub



#End Region









  
  
End Class


Partial Class Dao
    Public Const WorkList_Bill_NAME As String = "加工集合"

#Region "加工集合"
    Public Const SQL_WorkList_NameCheckDuplicate = "select count(*) from T10023_WorkTable where WorkList_No=@WorkList_No and id<>@id"


    Public Const SQL_WorkList_Get As String = "select ID, WorkList_No,WorkList_Name,WorkList_Remark,Founder,Found_Date,Upd_User,Upd_Date from T10023_WorkTable "

    Public Const SQL_WorkList_GetByID As String = "select top 1 * from T10023_WorkTable where ID=@ID"
    Public Const SQL_WorkList_GetListByID As String = "select WL.*,W.Dept_Name,W.Work_Name from T10024_WorkList WL left join T10022_Work W ON WL.Work_No=W.Work_No where Work_ID=@Work_ID order by WorkList_Index"
    Public Const SQL_WorkList_GetList As String = "select * from T10024_WorkList where Work_ID=@Work_ID"
    Public Const SQL_WorkList_GetByNo As String = "select * from T10023_WorkTable where WorkList_No=@WorkList_No"

    Public Const SQL_WorkList_GetByID_ExceptImage As String = "select ID,WorkList_No,WorkList_Name,WorkList_Remark,Founder,Found_Date,Upd_User,Upd_Date from T10023_WorkTable where ID=@ID"

    Public Const SQL_WorkList_DelByid As String = "Delete from  T10023_WorkTable where ID=@ID "

    Public Const SQL_WorkList_OrderBy As String = " order by  WorkList_No "

    '  Public Const SQL_WorkList_GeList_ByIDWithName = "select P.*,WL_Name,WL_No,WL_Spec from T10005_WorkListList  P left join T10001_WL W on P.WL_ID=W.ID where  P.ID=@ID "


    Public Const SQL_WorkList_InsertNewID = "if exists (select * from T10023_WorkTable where WorkList_No= @WorkList_No)" & vbCrLf & _
                                            "select -1" & vbCrLf & _
                                            "else" & vbCrLf & _
                                            "begin" & vbCrLf & _
                                            "insert into T10023_WorkTable(WorkList_No)Values(@WorkList_No)" & vbCrLf & _
                                            "select @@IDENTITY" & vbCrLf & _
                                            "end"
#End Region

    ''' <summary>
    ''' 获取所有加工集合信息
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function WorkList_GetAll() As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_WorkList_Get)
    End Function
    ''' <summary>
    ''' 获取所有加工集合信息
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Work_Get() As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_Work_Get)
    End Function



    ''' <summary>
    ''' 获取查询条件集合
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function WorkList_GetConditionNames() As List(Of FindOption)
        Dim foList As New List(Of FindOption)
        Dim fo As New FindOption
        fo.Field = "请选择"
        fo.DB_Field = ""
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "加工集合编号"
        fo.DB_Field = "WorkList_No"
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "加工集合名称"
        fo.DB_Field = "WorkList_Name"
        foList.Add(fo)
        Return foList
    End Function

    ''' <summary>
    ''' 按条件获取加工集合信息
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function WorkList_GetByOption(ByVal oList As OptionList) As DtReturnMsg
        Dim paraMap As New Dictionary(Of String, Object)
        Dim sqlBuider As New StringBuilder
        sqlBuider.Append(SQL_WorkList_Get)
        sqlBuider.Append("  WHERE 1=1  ")
        sqlBuider.Append(OptionClass.OptionClass_BuidSqlConditon(oList.FoList, paraMap))
        sqlBuider.Append(SQL_WorkList_OrderBy)
        Return PClass.PClass.SqlStrToDt(sqlBuider.ToString, paraMap)
    End Function

    ''' <summary>
    ''' 获取加工集合信息
    ''' </summary>
    ''' <param name="sId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function WorkList_GetById(ByVal sId As Integer) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_WorkList_GetByID, "@Id", sId)
    End Function
    Public Shared Function List_GetById(ByVal sId As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_WorkList_GetListByID, "@Work_ID", sId)
    End Function

    ''' <summary>
    ''' 增加一个加工集合
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function WorkList_Add(ByVal dtTable As DataTable, ByVal DtList As DataTable) As MsgReturn
        Dim msg As New DtListReturnMsg
        Dim R As New MsgReturn
        Dim sqlMap As New Dictionary(Of String, String)
        Dim paraMap As New Dictionary(Of String, Object)
        Dim _No As String = dtTable.Rows(0)("WorkList_No")
        Dim Work_ID As String = _No
        Dim IsInsert As Boolean = False
        Dim ID As Integer = 0
        Try
            Dim newIdMsg As MsgReturn = SqlStrToOneStr(SQL_WorkList_InsertNewID, "@WorkList_No", _No)
            If newIdMsg.IsOk Then
                If Val(newIdMsg.Msg) = -1 Then
                    R.IsOk = False
                    R.Msg = WorkList_Bill_NAME & "编号[" & dtTable.Rows(0)("WorkList_No") & "]已经存在!"
                    Return R
                Else
                    ID = Val(newIdMsg.Msg)
                    dtTable.Rows(0)("ID") = ID
                    For Each dr As DataRow In DtList.Rows
                        dr("ID") = ID
                    Next
                End If
            End If
            paraMap.Add("ID", ID)
            paraMap.Add("Work_ID", Work_ID)
            sqlMap.Add("Table", SQL_WorkList_GetByID)
            sqlMap.Add("List", SQL_WorkList_GetList)

            msg = SqlStrToDt(sqlMap, paraMap)
            If msg.DtList("Table").Rows.Count = 1 Then
                DvToDt(DtList, msg.DtList("List"), New List(Of String))
                DvUpdateToDt(dtTable, msg.DtList("Table"), New List(Of String))
                '  Dim TmSQL As String = "insert into Bill_Barcode (No_ID,NO_Type)values('" & PuchaseId & "'," & BillType.Purchase & ")"
                DtToUpDate(msg)
                R.Msg = "" & WorkList_Bill_NAME & "[" & dtTable.Rows(0)("WorkList_Name") & "]添加成功!"
                R.IsOk = True
            Else
                R.IsOk = False
                R.Msg = "" & WorkList_Bill_NAME & "[" & dtTable.Rows(0)("WorkList_Name") & "]已经存在!"
            End If
            Return R
        Catch ex As Exception
            R.IsOk = False
            R.Msg = "" & WorkList_Bill_NAME & "[" & dtTable.Rows(0)("WorkList_Name") & "]添加错误!"
            DebugToLog(ex)
            Return R
        Finally
        End Try
    End Function



    ''' <summary>
    '''修改一个加工集合
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function WorkList_Save(ByVal dtTable As DataTable, ByVal dtList As DataTable) As MsgReturn
        Dim msg As New DtListReturnMsg
        Dim R As New MsgReturn
        Dim sqlMap As New Dictionary(Of String, String)
        Dim paraMap As New Dictionary(Of String, Object)
        Dim ID As Integer = dtTable.Rows(0)("ID")
        Dim Work_ID As String = dtTable.Rows(0)("WorkList_No")
        Dim IsInsert As Boolean = False
        paraMap.Add("ID", ID)
        paraMap.Add("Work_ID", Work_ID)

        Try
            sqlMap.Add("Table", SQL_WorkList_GetByID)
            sqlMap.Add("List", SQL_WorkList_GetList)

            msg = SqlStrToDt(sqlMap, paraMap)
            If msg.DtList("Table").Rows.Count = 1 Then
                DvToDt(dtList, msg.DtList("List"), New List(Of String))
                DvUpdateToDt(dtTable, msg.DtList("Table"), New List(Of String))

                '  Dim TmSQL As String = "insert into Bill_Barcode (No_ID,NO_Type)values('" & PuchaseId & "'," & BillType.Purchase & ")"
                DtToUpDate(msg)
                R.Msg = "" & WorkList_Bill_NAME & "[" & dtTable.Rows(0)("WorkList_Name") & "]修改成功!"
                R.IsOk = True
            Else
                R.IsOk = False
                R.Msg = "" & WorkList_Bill_NAME & "[" & dtTable.Rows(0)("WorkList_Name") & "]不存在!"
            End If
            Return R
        Catch ex As Exception
            R.IsOk = False
            R.Msg = "" & WorkList_Bill_NAME & "[" & dtTable.Rows(0)("WorkList_Name") & "]修改错误!"
            DebugToLog(ex)
            Return R
        Finally
        End Try
    End Function


    ''' <summary>
    ''' 检查布类编号的是否重复
    ''' </summary>
    ''' <param name="WorkList_No"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function WorkList_NameCheckDuplicate(ByVal WorkList_No As String, ByVal ID As Integer) As Boolean
        Dim P As New Dictionary(Of String, Object)
        P.Add("WorkList_No", WorkList_No)
        P.Add("ID", ID)
        Dim r As MsgReturn = SqlStrToOneStr(SQL_WorkList_NameCheckDuplicate, P)
        If r.IsOk Then
            If Val(r.Msg) > 0 Then
                Return True
            Else
                Return False
            End If
        Else
            Return True
        End If
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="BZId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function WorkList_Del(ByVal BZId As String)
        Return RunSQL(SQL_WorkList_DelByid, "@ID", BZId)
    End Function

    ''' <summary>
    ''' 生成新的分类ID 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function WorkList_GetNewID() As String
        Dim paraMap As New Dictionary(Of String, Object)
        paraMap.Add("@DB_Str", "T10023_WorkTable")
        paraMap.Add("@Id_Str", "")
        paraMap.Add("@Field", "WorkList_No")
        paraMap.Add("@Zero", "3")
        Dim msgID As MsgReturn = SqlStrToOneStr("GetTableID_NoDate", paraMap, True)
        If msgID.IsOk Then
            Return Format(Val(msgID.Msg), "000")
        Else
            Return ""
        End If
    End Function



    'Public Shared Function WorkList_GetList_ByID(ByVal _ID As Integer) As DtReturnMsg
    '    Dim R As New DtReturnMsg
    '    Dim sql As String = SQL_WorkList_GeList_ByIDWithName
    '    Dim para As New Dictionary(Of String, Object)
    '    para.Add("@ID", _ID)
    '    R = PClass.PClass.SqlStrToDt(sql, para)
    '    Return R
    'End Function






End Class