Option Compare Text
Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports PClass
Imports BaseClass
Imports PClass.CReport
Imports BaseClass.ComFun

Public Class F30221_QualityDayReport_Msg
    Dim LId As String = ""
    Dim PID As String = ""
    Dim PID_Date As Date = #1/1/1999#
    Dim dtJyList As DataTable
    Dim dtQpList As DataTable
    Dim dtLJList As DataTable
    Dim dtTable As DataTable
    Dim kdDate As Date
    Dim SumBJCL As Decimal = 0
    Dim SumLYTB As Decimal = 0
    Dim State As Enum_State = Enum_State.AddNew



    Public Sub New(ByVal kdDate As Date)
        ' 此调用是 Windows 窗体设计器所必需的。
        Me.kdDate = kdDate
        InitializeComponent()
        ' 在 InitializeComponent() 调用之后添加任何初始化。
    End Sub



    Public Sub New()
        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        ' 在 InitializeComponent() 调用之后添加任何初始化。
    End Sub

    Public Sub New(ByVal initID As String)
        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        ' 在 InitializeComponent() 调用之后添加任何初始化。
        PID = initID
        Me.Mode = Mode
    End Sub

    Private Sub Me_AfterLoad() Handles Me.AfterLoad
        If Fg1.Rows.Count > 1 Then
            Fg1.RowSel = 1
            Fg1.Row = 1
        End If
        SumFG1.AddSum()

    End Sub

    Private Sub Me_Form_KeyDown(ByVal sender As Object, ByRef e As System.Windows.Forms.KeyEventArgs) Handles Me.Form_KeyDown
        If e.KeyCode = Keys.Enter Then
            Try
                If Me.ActiveControl.Name <> Fg1.Name AndAlso ActiveControl.Parent.Name <> Fg1.Name AndAlso Me.ActiveControl.Name <> Fg2.Name AndAlso ActiveControl.Parent.Name <> Fg2.Name AndAlso Me.ActiveControl.Name <> Fg3.Name AndAlso ActiveControl.Parent.Name <> Fg3.Name Then
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
        Control_CheckRight(ID, ClassMain.Modify, Cmd_Modify)
        Control_CheckRight(ID, ClassMain.Del, Cmd_Del)
        Control_CheckRight(ID, ClassMain.Audited, Cmd_Audit)
        Control_CheckRight(ID, ClassMain.UnAudit, Cmd_UnAudit)
        Control_CheckRight(ID, ClassMain.SetInValid, Cmd_SetInValid)
        Control_CheckRight(ID, ClassMain.SetValid, Cmd_SetValid)
        Control_CheckRight(ID, ClassMain.Print, Cmd_Print)
        Control_CheckRight(ID, ClassMain.Preview, Cmd_Preview)
    End Sub

    Private Sub Form_Me_Closing(ByVal sender As Object, ByRef e As System.ComponentModel.CancelEventArgs) Handles Me.Me_Closing
        ComFun.DelBillNewID(BillType.QLReport, PID)
    End Sub

    Private Sub Form_Load() Handles Me.Me_Load
        If PID = "" AndAlso P_F_RS_ID <> "" Then
            PID = P_F_RS_ID
        End If
        FormCheckRight()
        Ch_Name = GetBillTypeName(P_ID)
        Me.Title = Ch_Name
        Fg1.IniFormat()
        Dim dtProject As DtReturnMsg = Dao.GetLYProject
        If dtProject.IsOk Then
            CB_Project.DataSource = dtProject.Dt
        End If
        Fg2.Cols("LYCM").Editor = CB_Project
        Me_Refresh()
        Fg1.Styles.Normal.WordWrap = True
        For i As Integer = 1 To Fg1.Rows.Count - 1
            Fg1.AutoSizeRow(i)
        Next
        Count()
    End Sub

    Protected Sub Me_Refresh()
        Dim msgTable As DtReturnMsg = Dao.QualityDayReport_GetById(PID)
        If msgTable.IsOk Then
            dtTable = msgTable.Dt
            If Mode = Mode_Enum.Modify AndAlso msgTable.Dt.Rows.Count = 0 Then
                ShowErrMsg("没有找到" & Dao.QualityDayReport_DB_NAME & "[" & PID & "]", True)
                Exit Sub
            End If

            SetForm(dtTable)
        End If
        Select Case Mode
            Case Mode_Enum.Add
                If CheckRight(ID, ClassMain.Add) = False Then Me.ShowErrMsg("没有权限添加" & Dao.QualityDayReport_DB_NAME & "!", True) : Exit Sub
                Dim msg As DtListReturnMsg = Dao.QualityDayReport_SelListById(0)
                If msg.IsOk Then
                    AddCL_Name(msg.DtList("JYXm"), msg.DtList("JY"))
                    dtJyList = msg.DtList("JY")
                    dtQpList = msg.DtList("QP")
                    dtLJList = msg.DtList("LJ")
                End If
                Fg1.Rows.Count = 2
                Fg1.ReAddIndex()
                Fg2.Rows.Count = 2
                Fg2.ReAddIndex()
                Fg3.Rows.Count = 2
                Fg3.ReAddIndex()
                Fg3.DtToSetFG(dtJyList)
                LabelTitle.Text = "新建" & Me.Ch_Name
                Cmd_Preview.Enabled = False
                Cmd_Print.Enabled = False
                DTP_sDate.Value = kdDate
                GetNewID()
            Case Mode_Enum.Modify
                Cmd_Preview.Enabled = True
                Cmd_Print.Enabled = True
                Dim msg As DtListReturnMsg = Dao.QualityDayReport_SelListById(PID)
                If msg.IsOk Then
                    dtJyList = msg.DtList("JY")
                    dtQpList = msg.DtList("QP")
                    dtLJList = msg.DtList("LJ")
                    Fg3.DtToSetFG(dtJyList)
                    Fg2.DtToSetFG(dtQpList)
                    Fg1.DtToSetFG(dtLJList)
                    LastReLine = dtJyList.Rows(0)("Line")
                End If
                LId = TB_ID.Text
                LabelTitle.Text = "修改" & Me.Ch_Name
        End Select
        dtTable.AcceptChanges()
        dtJyList.AcceptChanges()
    End Sub

    ''' <summary>
    ''' 初始化检查表项目
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub AddCL_Name(ByVal dt As DataTable, ByRef dtJY As DataTable)
        If dt Is Nothing Then
            Exit Sub
        End If
        Dim R As DataRow
        For Each dr As DataRow In dt.Rows
            R = dtJY.NewRow
            R("CL_Name") = dr("CL_Name")
            dtJY.Rows.Add(R)
        Next
    End Sub


    ''' <summary>
    ''' 动态计算累计包装产量,累计漏验退布量
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DayCL(ByRef dt As DataTable, ByVal sDate As Date)
        If dt Is Nothing Then
            Exit Sub
        End If
        Dim StartDate As Date = New Date(sDate.Year, sDate.Month, 1)
        Dim SumBJCL As Decimal = 0   '累计包装产量
        Dim SumLYTB As Decimal = 0  '累计漏验退布量
        Dim Msg_Sum As DtReturnMsg = Dao.GetQualityDayReportLG(StartDate, sDate.Date)
        If Msg_Sum.IsOk AndAlso Msg_Sum.Dt.Rows.Count > 0 Then
            SumBJCL = IsNull(Msg_Sum.Dt.Rows(0)("SumBJCL"), 0)
            SumLYTB = IsNull(Msg_Sum.Dt.Rows(0)("SumLYTB"), 0)
        End If
        Dim dr As DataRow
        dr = dt.Rows(0)
        dr("SumBJCL") = SumBJCL
        dr("SumLYTB") = SumLYTB
        dt.AcceptChanges()
    End Sub


#Region "表单控件事件"
    Private Sub TB_Payed_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        TB_SumBJCL.Text = Val(TB_SumBJCL.Text)

    End Sub

    Private Sub TB_DayLYTB_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TB_SumLYTBL.Validating, TB_SumLYTB.Validating, TB_SumBJCL.Validating, TB_DayLYTBL.Validating, TB_DayLYTB.Validating, TB_DayBJCL.Validating
        sender.text = Val(sender.text)
    End Sub


#End Region

#Region "表单信息"
    ''' <summary>
    ''' 获取表单内容
    ''' </summary>
    ''' <remarks></remarks>
    Protected Function GetForm() As DataTable
        Dim dt As DataTable
        Dim ID As String = IIf(Mode = Mode_Enum.Add, TB_ID.Text, LId)
        dt = dtTable
        Dim dr As DataRow = dt.Rows(0)
        Dim IsLock As Boolean = False
        GetColValue(dr, TB_DayBJCL, "", "", IsLock, "0.##")
        GetColValue(dr, TB_DayLYTB, "", "", IsLock, "0.##")
        GetColValue(dr, TB_DayLYTBL, "", "", IsLock, "0.##")
        GetColValue(dr, TB_SumBJCL, "", "", IsLock, "0.##")
        GetColValue(dr, TB_SumLYTB, "", "", IsLock, "0.##")
        GetColValue(dr, TB_SumLYTBL, "", "", IsLock, "0.##")
        GetColValue(dr, TB_Upd_Dept, "", "", IsLock)
        GetColValue(dr, TB_Upd_User, "", "", IsLock)
        GetColValue(dr, TB_State_User, "", "", IsLock)
        dr("JYRemarks") = IsNull(TB_JYRemarks.Text, "")
        dr("LJRemarks") = IsNull(TB_LJRmearks.Text, "")
        GetColValue(dr, DTP_sDate, ServerTime.Date, "", IsLock)
        dr("Remarks") = TB_Remarks.Text
        dr("State") = State
        dr("ID") = IIf(Mode = Mode_Enum.Add, TB_ID.Text, LId)
        dt.AcceptChanges()
        dtJyList = dtJyList.Clone
        dtQpList = dtQpList.Clone
        dtLJList = dtLJList.Clone
        For i As Integer = 1 To Fg3.Rows.Count - 1
            dr = dtJyList.NewRow
            dr("ID") = ID
            dr("CL_Name") = Fg3.Item(i, "CL_Name")
            dr("ZJJ") = Val(Fg3.Item(i, "ZJJ"))
            dr("ZJY") = Val(Fg3.Item(i, "ZJY"))
            dr("PSJ") = Val(Fg3.Item(i, "PSJ"))
            dr("PSY") = Val(Fg3.Item(i, "PSY"))
            dr("JCPRC") = Val(Fg3.Item(i, "JCPRC"))
            dr("YCPRC") = Val(Fg3.Item(i, "YCPRC"))
            dr("ZGFX") = Val(Fg3.Item(i, "ZGFX"))
            dtJyList.Rows.Add(dr)
        Next

        For i As Integer = 1 To Fg2.Rows.Count - 1
            dr = dtQpList.NewRow
            dr("ID") = ID
            dr("LYCM") = Fg2.Item(i, "LYCM")
            dr("LYSL") = Val(Fg2.Item(i, "LYSL"))
            dr("DayLYL") = Val(Fg2.Item(i, "DayLYL"))
            dr("LRemarks") = Fg2.Item(i, "LRemarks")
            dtQpList.Rows.Add(dr)
        Next

        For i As Integer = 1 To Fg1.Rows.Count - 1

            dr = dtLJList.NewRow
            dr("ID") = ID
            dr("GH") = Fg1.Item(i, "GH")
            dr("BZC_ID") = Val(Fg1.Item(i, "BZC_ID"))
            dr("BZ_ID") = Val(Fg1.Item(i, "BZ_ID"))
            dr("Client_ID") = Val(Fg1.Item(i, "Client_ID"))
            dr("Qty") = Val(Fg1.Item(i, "Qty"))
            dr("Weight") = Val(Fg1.Item(i, "Weight"))
            dr("LRemarks") = Fg1.Item(i, "LRemarks")
            dtLJList.Rows.Add(dr)
        Next

        dtQpList.AcceptChanges()
        dtJyList.AcceptChanges()
        dtLJList.AcceptChanges()
        Return dt
    End Function

    ''' <summary>
    ''' 设置表单内容
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub SetForm(ByVal dt As DataTable)
        If dt Is Nothing Then
            Exit Sub
        End If
        Dim Dr As DataRow
        Dim IsLock As Boolean = False
        Dim IdLock As Boolean = True
        If dt.Rows.Count = 0 Then
            IdLock = False
            LabelState.Text = "新建"
            LabelState.ForeColor = Color.Black
            SetCmd_State(Cmd_Audit, Cmd_UnAudit, Enum_CmdState.AllDisable) '审核和反审按钮
            SetCmd_State(Cmd_SetInValid, Cmd_SetValid, Enum_CmdState.AllDisable) '作废和反作废按钮
            SetCmd_State(Cmd_Del, Nothing, Enum_CmdState.AllDisable) '删除按钮

            If Mode = Mode_Enum.Add Then
                Cmd_Modify.Visible = True
                Cmd_Modify.Enabled = True
            Else
                Cmd_Modify.Visible = Cmd_Modify.Tag
                Cmd_Modify.Enabled = Cmd_Modify.Tag
            End If
            Dr = dt.NewRow
            Dr("sDate") = DTP_sDate.Value.Date
            Dr("Upd_User") = User_Name
            Dr("Upd_Dept") = GetDeptName(User_ID)
            dt.Rows.Add(Dr)
            dt.AcceptChanges()
            IsLock = False
        Else
            'state取值以及设置
            Dr = dt.Rows(0)
            State = Dr("State")
            Cmd_Del.Visible = False
            Select Case State
                Case Enum_State.AddNew '新建
                    LabelState.Text = "新建"
                    LabelState.ForeColor = Color.Black
                    SetCmd_State(Cmd_Audit, Cmd_UnAudit, Enum_CmdState.Enable1Disable2) '审核和反审按钮
                    SetCmd_State(Cmd_SetInValid, Cmd_SetValid, Enum_CmdState.Enable1Disable2) '作废和反作废按钮
                    SetCmd_State(Cmd_Del, Nothing, Enum_CmdState.AllEnable) '删除按钮
                    SetCmd_State(Cmd_Modify, Nothing, Enum_CmdState.AllEnable) '保存按钮
                    IsLock = False

                Case Enum_State.Invoid '作废
                    LabelState.Text = "已作废"
                    LabelState.ForeColor = Color.Red
                    SetCmd_State(Cmd_Audit, Cmd_UnAudit, Enum_CmdState.AllDisable) '审核和反审按钮
                    SetCmd_State(Cmd_SetInValid, Cmd_SetValid, Enum_CmdState.Enable2Disable1) '作废和反作废按钮
                    SetCmd_State(Cmd_Del, Nothing, Enum_CmdState.AllDisable) '删除按钮
                    SetCmd_State(Cmd_Modify, Nothing, Enum_CmdState.AllDisable) '保存按钮
                    IsLock = True


                Case Enum_State.Audited '审核
                    LabelState.Text = "已审核"
                    SetCmd_State(Cmd_Audit, Cmd_UnAudit, Enum_CmdState.Enable2Disable1) '审核和反审按钮
                    SetCmd_State(Cmd_SetInValid, Cmd_SetValid, Enum_CmdState.AllDisable) '作废和反作废按钮
                    SetCmd_State(Cmd_Del, Nothing, Enum_CmdState.AllDisable) '删除按钮
                    SetCmd_State(Cmd_Modify, Nothing, Enum_CmdState.Enable2Disable1) '保存按钮
                    IsLock = True
            End Select
        End If

        Dim kDate As Date = Dr("sDate")
        Dim StartDate As Date = New Date(kDate.Year, kDate.Month, 1)
        kDate = kDate.AddDays(-1)
        DayCL(dt, kDate)

        LockForm(IsLock)

        SetColValue(Dr, TB_ID, "", "", IdLock)
        SetColValue(Dr, DTP_sDate, ServerTime.Date, "", IsLock)
        SetColValue(Dr, TB_DayBJCL, "", "", IsLock, "0.##")
        SetColValue(Dr, TB_DayLYTB, "", "", True, "0.##")
        SetColValue(Dr, TB_DayLYTBL, "", "", True, "0.##")
        SetColValue(Dr, TB_SumBJCL, "", "", True, "0.##")
        SetColValue(Dr, TB_SumLYTB, "", "", True, "0.##")
        SetColValue(Dr, TB_SumLYTBL, "", "", True, "0.##")
        SetColValue(Dr, TB_Upd_Dept, "", "", True)
        SetColValue(Dr, TB_Upd_User, "", "", True)
        SetColValue(Dr, TB_State_User, "", "", True)
        TB_JYRemarks.Text = IsNull(Dr("JYRemarks"), "")
        TB_LJRmearks.Text = IsNull(Dr("LJRemarks"), "")
        TB_Remarks.Text = IsNull(Dr("Remarks"), "")
        SumBJCL = IsNull(Dr("SumBJCL"), 0)
        SumLYTB = IsNull(Dr("SumLYTB"), 0)
    End Sub

    Sub LockForm(ByVal Lock As Boolean)
        TB_ID.ReadOnly = Lock
        DTP_sDate.Enabled = Not Lock
        Fg1.CanEditing = Not Lock
        Fg1.IsClickStartEdit = Not Lock
        TB_DayLYTBL.ReadOnly = Lock
        TB_SumBJCL.ReadOnly = Lock
        TB_SumLYTB.ReadOnly = Lock
        Cmd_AddRow.Enabled = Not Lock
        Cmd_RemoveRow.Enabled = Not Lock
    End Sub


    ''' <summary>
    ''' 获取部门名称
    ''' </summary>
    ''' <remarks></remarks>
    Private Function GetDeptName(ByVal User_ID As String) As String
        Dim Dept As DtReturnMsg = User_GetDept(User_ID)
        If Dept.IsOk AndAlso Dept.Dt.Rows.Count > 0 Then
            Return Dept.Dt.Rows(0)("Dept_Name")
        Else
            Return ""
        End If
    End Function

#End Region

#Region "工具栏按钮"

    ''' <summary>
    ''' 保存按钮
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_Modify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Modify.Click
        Fg1.FinishEditing(False)
        If CheckForm() Then
            If Mode = Mode_Enum.Add Then
                ShowConfirm("是否保存新" & Ch_Name & "?", AddressOf SaveQualityDayReport)
            Else
                If CheckIsModify() Then
                    ShowConfirm(Ch_Name & "[" & TB_ID.Text & "] 已经被其他人修改过,是否覆盖别人的修改?", AddressOf SaveQualityDayReport)
                Else
                    ShowConfirm("是否保存" & Ch_Name & "[" & TB_ID.Text & "] 的修改?", AddressOf SaveQualityDayReport)
                End If
            End If
        End If
    End Sub

    ''' <summary>
    ''' 保存修改
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub SaveQualityDayReport(Optional ByVal CallBack As DSub_None = Nothing)
        Dim R As MsgReturn
        Dim Dt As DataTable = GetForm()

        If Me.Mode = Mode_Enum.Add Then
            R = Dao.QualityDayReport_Add(Dt, dtJyList, dtQpList, dtLJList)
        Else
            R = Dao.QualityDayReport_Save(Dt, dtJyList, dtQpList, dtLJList)
        End If
        If R.IsOk Then
            LId = TB_ID.Text
            LastForm.ReturnId = TB_ID.Text
            Mode = Mode_Enum.Modify
            If CallBack IsNot Nothing Then '保存成功后要完成的事
                CallBack()
            Else
                ShowOk(R.Msg, True)
            End If
            If TB_ID.Text = PID.Replace("-", "") Then PID = ""
        Else
            ShowErrMsg(R.Msg)
        End If
    End Sub

    ''' <summary>
    ''' 验证信息
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Function CheckForm() As Boolean
        TB_ID.Text = TB_ID.Text.Trim
        TB_ID.Text = TB_ID.Text.Replace("'", "")
        If TB_ID.Text = "" Then
            ShowErrMsg(Ch_Name & "单号不能为空!", AddressOf TB_ID.Focus)
            Return False
        End If
        If (Mode = Mode_Enum.Add Or (Mode = Mode_Enum.Modify And LId <> TB_ID.Text)) AndAlso Dao.QualityDayReport_CheckID(TB_ID.Text) Then
            ShowErrMsg(Ch_Name & "单号[" & TB_ID.Text & "]已经存在!", AddressOf TB_ID.Focus)
            Return False
        End If

        For i As Integer = Fg1.Rows.Count - 1 To 1 Step -1
            Try
                If Fg1.Item(i, "GH") = "" Then
                    Fg1.RemoveItem(i)
                End If

                If Val(Fg1.Item(i, "Client_ID")) = 0 Then
                    Fg1.RemoveItem(i)
                End If

            Catch ex As Exception
            End Try
        Next


        For i As Integer = Fg2.Rows.Count - 1 To 1 Step -1
            Try
                If Fg2.Item(i, "LYCM") = "" Then
                    Fg2.RemoveItem(i)
                End If
            Catch ex As Exception
            End Try
        Next



        For i As Integer = Fg3.Rows.Count - 1 To 1 Step -1
            Try
                If Fg3.Item(i, "CL_Name") = "" Then
                    Fg3.RemoveItem(i)
                End If
            Catch ex As Exception
            End Try
        Next



        'If Fg1.Rows.Count <= 1 Then

        '    ShowErrMsg("回收明细不能为空!")
        '    Return False
        'End If

        'If Fg2.Rows.Count <= 1 Then
        '    ShowErrMsg("质量问题分析表不能为空!")
        '    Return False
        'End If


        Me.Refresh()
        Return True
    End Function

    ''' <summary>
    ''' 退出
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub


#End Region

#Region "FG 事件"

    Private Sub Fg1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Fg1.CanEditing = False Then Exit Sub
        If Fg1.Editor Is Nothing Then
            If Fg1.RowSel < 0 Then
                Exit Sub
            End If
            If Fg1.Cols(Fg1.ColSel).AllowEditing AndAlso Fg1.CanEditing Then
                Fg1.LastKey = 0
                Fg1.StartEditing()
            End If
        End If
    End Sub
    Private Sub Fg1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
        If Fg1.RowSel > 0 Then
            
        End If
    End Sub

    Private Sub Fg1_AfterEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles Fg1.AfterEdit
        If e.Row < 0 Then
            Exit Sub
        End If
        If Fg1.LastKey = Keys.Enter Then
            Fg1.LastKey = 0
            Select Case Fg1.Cols(e.Col).Name
                Case "GH"
                    Fg1.Item(e.Row, "GH") = Fg1.Item(e.Row, "GH").ToString.ToUpper
                    GetByGH(Fg1.Item(e.Row, e.Col), Fg1)
                    Fg1.GotoNextCell(e.Col)
                Case "Qty"
                    Fg1.Item(e.Row, e.Col) = Val(Fg1.Item(e.Row, e.Col))
                    SumFG1.AddSum()
                    Fg1.GotoNextCell(e.Col)
                Case "Weight"
                    Fg1.Item(e.Row, e.Col) = Val(Fg1.Item(e.Row, e.Col))
                    SumFG1.AddSum()

                    Fg1.GotoNextCell(e.Col)
                Case "LRemarks"
                    Fg1.AutoSizeRow(e.Row)
                    Fg1.GotoNextCell(e.Col)
                Case Else
                    Fg1.GotoNextCell(e.Col)
            End Select
        Else
            Fg1.LastKey = 0

        End If

    End Sub

    Private Sub flex_ChangeEdit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fg1.ChangeEdit
        Dim f As FG = TryCast(sender, FG)
        Dim g As Graphics = f.CreateGraphics()
        Try
        Finally
            'measure text height
            Dim sf As StringFormat = New StringFormat()
            Dim wid As Integer = f.Cols(Fg1.Col).WidthDisplay - 2
            Dim text As String = f.Editor.Text
            Dim sz As SizeF = g.MeasureString(text, f.Font, wid, sf)

            'adjust row height if necessary
            Dim row As C1.Win.C1FlexGrid.Row = f.Rows(f.Row)
            If sz.Height + 4 > row.HeightDisplay Then
                row.HeightDisplay = CType(sz.Height, Integer) + 4
            End If
        End Try
    End Sub




    ''' <summary>
    '''增行
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' 
    Private Sub Cmd_AddRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_AddRow.Click
      
        If Tc_List.SelectedTab.Name = "TabPage2" Then
            AddRow(Fg2)
        ElseIf Tc_List.SelectedTab.Name = "TabPage3" Then
            AddRow(Fg1)
        End If
    End Sub

    ''' <summary>
    ''' 增行
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub AddRow(ByVal FG As FG)
        FG.AddRow()
    End Sub

    ''' <summary>
    ''' 减行
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub RemoveRow(ByVal FG As FG)
        FG.RemoveRow()
    End Sub





    ''' <summary>
    ''' 减行
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_RemoveRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_RemoveRow.Click
        If Tc_List.SelectedTab.Name = "TabPage1" Then
            RemoveRow(Fg3)
        ElseIf Tc_List.SelectedTab.Name = "TabPage2" Then
            RemoveRow(Fg2)
        ElseIf Tc_List.SelectedTab.Name = "TabPage3" Then
            RemoveRow(Fg1)
        End If
    End Sub

    Private Sub Fg1_NextCell(ByVal e As PClass.FG.NextCellEventArgs) Handles Fg1.NextCell
        Select Case e.Col
            Case "GH"
                e.ToCol = Fg1.Cols("Qty").Index

            Case "Qty"
                e.ToCol = Fg1.Cols("Weight").Index

            Case "Weight"
                e.ToCol = Fg1.Cols("LRemarks").Index

            Case "LRemarks"

                If e.Row + 2 > Fg1.Rows.Count Then
                    Fg1.AddRow()
                End If
                e.ToRow = e.Row + 1
                e.ToCol = Fg1.Cols("GH").Index

            Case Else
                e.ToCol = Fg1.Cols("Qty").Index
        End Select
    End Sub

    Private Sub Fg1_Enter(ByVal sender As Object, ByVal e As System.EventArgs)
        'If Fg1.RowSel < 0 Then
        '    Exit Sub
        'End If
        'If Fg1.Cols(Fg1.ColSel).AllowEditing AndAlso Fg1.CanEditing Then
        '    Fg1.LastKey = 0
        '    Fg1.StartEditing()
        'End If

    End Sub

    Private Sub Fg1_EnterCell(ByVal sender As Object, ByVal e As System.EventArgs)
        If Fg1.RowSel < 0 Then
            Exit Sub
        End If
        If Fg1.Cols(Fg1.ColSel).AllowEditing AndAlso Fg1.CanEditing Then
            Fg1.LastKey = 0
            Fg1.StartEditing()
        End If

    End Sub

    Private Sub Fg1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If Fg1.RowSel < 0 Then
            Exit Sub
        End If
        If Fg1.CanEditing = True Then
            If e.KeyCode = Keys.Enter Then
                If Fg1.ColSel < Fg1.Cols("Qty").Index Then
                    Fg1.StartEditing(Fg1.RowSel, Fg1.Cols("Qty").Index)
                Else
                    Fg1.StartEditing(Fg1.RowSel, Fg1.Cols("LRemark").Index)
                End If
            ElseIf e.KeyCode = Keys.Add AndAlso Fg1.Cols(Fg1.ColSel).Name = "WL_No" Then

            End If
        End If
    End Sub

    Private Sub Fg1_KeyDownEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.KeyEditEventArgs)
      
    End Sub


    Private Sub Fg2_NextCell(ByVal e As PClass.FG.NextCellEventArgs) Handles Fg2.NextCell
        Select Case e.Col
            Case "LYCM"
                e.ToCol = Fg2.Cols("LYSL").Index

            Case "LYSL"
                e.ToCol = Fg2.Cols("DayLYL").Index

            Case "DayLYL"
                e.ToCol = Fg2.Cols("LRemarks").Index

            Case "LRemarks"

                If e.Row + 2 > Fg2.Rows.Count Then
                    Fg2.AddRow()
                End If
                e.ToRow = e.Row + 1
                e.ToCol = Fg2.Cols("LYCM").Index

            Case Else
                e.ToCol = Fg2.Cols("LYCM").Index
        End Select
    End Sub


    Private Sub Fg2_AfterEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles Fg2.AfterEdit
        If e.Row < 0 Then
            Exit Sub
        End If
        If Fg2.LastKey = Keys.Enter Then
            Fg2.LastKey = 0
            Select Case Fg2.Cols(e.Col).Name
                Case "LYCM"
                    Fg2.GotoNextCell(e.Col)
                Case "LYSL"
                    Fg2.Item(e.Row, e.Col) = Val(Fg2.Item(e.Row, e.Col))
                    Fg2.GotoNextCell(e.Col)
                Case "DayLYL"
                    Fg2.Item(e.Row, e.Col) = Val(Fg2.Item(e.Row, e.Col))
                    Fg2.GotoNextCell(e.Col)
                Case "LRemarks"
                    Fg2.GotoNextCell(e.Col)
                Case Else
                    Fg2.GotoNextCell(e.Col)
            End Select
        Else
            Fg2.LastKey = 0

        End If

    End Sub

    Private Sub Fg3_NextCell(ByVal e As PClass.FG.NextCellEventArgs) Handles Fg3.NextCell
        Select Case e.Col
            Case "CL_Name"
                e.ToCol = Fg3.Cols("ZJJ").Index

            Case "ZJJ"
                e.ToCol = Fg3.Cols("ZJY").Index

            Case "ZJY"
                e.ToCol = Fg3.Cols("PSJ").Index

            Case "PSJ"
                e.ToCol = Fg3.Cols("PSY").Index

            Case "PSY"
                e.ToCol = Fg3.Cols("JCPRC").Index

            Case "JCPRC"
                e.ToCol = Fg3.Cols("YCPRC").Index

            Case "YCPRC"
                e.ToCol = Fg3.Cols("ZGFX").Index

            Case "ZGFX"

                If e.Row + 1 < Fg3.Rows.Count Then
                    e.ToRow = e.Row + 1
                    e.ToCol = Fg3.Cols("ZJJ").Index
                Else
                    e.ToRow = 1
                    e.ToCol = Fg3.Cols("ZJJ").Index
                End If


            Case Else
                e.ToCol = Fg3.Cols("ZJJ").Index
        End Select
    End Sub


    Private Sub Fg3_AfterEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles Fg3.AfterEdit
        If e.Row < 0 Then
            Exit Sub
        End If
        If Fg3.LastKey = Keys.Enter Then
            Fg3.LastKey = 0
            Select Case Fg3.Cols(e.Col).Name
                Case "CL_Name"
                    Fg3.GotoNextCell(e.Col)

                Case "ZJJ"
                    Fg3.Item(e.Row, e.Col) = Val(Fg3.Item(e.Row, e.Col))
                    Fg3.GotoNextCell(e.Col)

                Case "ZJY"
                    Fg3.Item(e.Row, e.Col) = Val(Fg3.Item(e.Row, e.Col))
                    Fg3.GotoNextCell(e.Col)

                Case "PSJ"
                    Fg3.Item(e.Row, e.Col) = Val(Fg3.Item(e.Row, e.Col))
                    Fg3.GotoNextCell(e.Col)

                Case "PSY"
                    Fg3.Item(e.Row, e.Col) = Val(Fg3.Item(e.Row, e.Col))
                    Fg3.GotoNextCell(e.Col)

                Case "JCPRC"
                    Fg3.Item(e.Row, e.Col) = Val(Fg3.Item(e.Row, e.Col))
                    Fg3.GotoNextCell(e.Col)

                Case "YCPRC"
                    Fg3.Item(e.Row, e.Col) = Val(Fg3.Item(e.Row, e.Col))
                    Fg3.GotoNextCell(e.Col)

                Case "ZGFX"
                    Fg3.GotoNextCell(e.Col)

                Case Else
                    Fg3.GotoNextCell(e.Col)
            End Select
        Else
            Fg3.LastKey = 0

        End If

    End Sub




#End Region

#Region "物料选择"
  
    ''' <summary>
    '''按缸号选中客户、布种、色号
    ''' </summary>
    ''' <remarks></remarks>
    ''' 
    Protected Sub GetByGH(ByVal GH As String, ByVal FG As FG)
        Dim msg As DtReturnMsg = Dao.QualityDayReport_Get_byGH(GH)
        If msg.IsOk AndAlso msg.Dt.Rows.Count = 1 Then
            FG.Item(FG.RowSel, "Client_Name") = msg.Dt.Rows(0)("Client_Name")
            FG.Item(FG.RowSel, "Client_ID") = msg.Dt.Rows(0)("Client_ID")
            FG.Item(FG.RowSel, "BZ_Name") = msg.Dt.Rows(0)("BZ_Name")
            FG.Item(FG.RowSel, "BZ_ID") = msg.Dt.Rows(0)("BZ_ID")
            FG.Item(FG.RowSel, "BZC_Name") = msg.Dt.Rows(0)("BZC_Name")
            FG.Item(FG.RowSel, "BZC_ID") = msg.Dt.Rows(0)("BZC_ID")
        End If
    End Sub

#End Region

#Region "获取新单号"
    Private Sub Label_ID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label_ID.Click
        If TB_ID.ReadOnly OrElse TB_ID.Enabled = False Then
            ShowErrMsg("非新增状态不能修改单号!")
        Else
            ShowConfirm("是否获取新单号?", AddressOf ReGetNewID)
        End If
    End Sub

    Sub ReGetNewID()
        If TB_ID.Text <> LId OrElse LId = "" Then
            ComFun.DelBillNewID(BillType.QLReport, PID)
            PID_Date = #1/1/1999#
            GetNewID()
        End If
    End Sub

    Sub GetNewID()
        If TB_ID.ReadOnly = False Then
            If DTP_sDate.Value <> PID_Date Then
                Dim R As RetrunNewIdMsg = ComFun.GetBillNewID(BillType.QLReport, DTP_sDate.Value, PID)
                If R.IsOk Then
                    PID_Date = R.NewIdDate
                    DTP_sDate.MinDate = R.MaxDate.AddDays(1)
                    DTP_sDate.Value = R.NewIdDate
                    PID = R.NewID
                    TB_ID.Text = PID.Replace("-", "")
                    If R.IsTheDate = False Then
                        ShowErrMsg(R.RetrunMsg)
                    End If
                Else
                    ShowErrMsg(R.RetrunMsg)
                End If
            End If
        End If
    End Sub

    Private Sub DTP_sDate_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles DTP_sDate.Validated
        GetNewID()
    End Sub

#End Region

#Region "报表事件"

    Private Sub Cmd_Preview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Preview.Click
        Print(OperatorType.Preview)
    End Sub

    Private Sub Cmd_Print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Print.Click
        Print(OperatorType.Print)
    End Sub

    Protected Sub Print(ByVal DoOperator As OperatorType)
        If Me.Mode = Mode_Enum.Add Then
            Exit Sub
        End If
        Dim R As New R30221_QualityDayReport_Msg
        R.Start(TB_ID.Text, DoOperator)
    End Sub

#End Region

#Region "审核状态"
    ''' <summary>
    ''' 审核状态
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_Audit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Audit.Click
        Fg1.FinishEditing(False)

        Dim msg As MsgReturn = Dao.QualityDayReport_Audited(TB_ID.Text, True)
        If msg.IsOk Then
            LastForm.ReturnId = Me.TB_ID.Text
            Bill_ID = TB_ID.Text
            Mode = Mode_Enum.Modify
            Me_Refresh()
            ShowOk(msg.Msg)
        Else
            ShowErrMsg(msg.Msg)
        End If
    End Sub
    Protected Sub Shenhe()
        SaveQualityDayReport()
    End Sub

    Private Sub Cmd_UnAudit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_UnAudit.Click
        ShowConfirm("是否反审" & Ch_Name & " [" & TB_ID.Text & "]?", AddressOf UnAudit)
    End Sub

    Protected Sub UnAudit()
        Dim msg As MsgReturn = Dao.QualityDayReport_Audited(TB_ID.Text, False)
        If msg.IsOk Then
            Me_Refresh()
            Me.LastForm.ReturnId = TB_ID.Text
            ShowOk(msg.Msg)
        Else
            ShowErrMsg(msg.Msg)
        End If
    End Sub

    ''' <summary>
    ''' 删除按钮
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_Del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Del.Click
        ShowConfirm("是否删除" & Ch_Name & " [" & TB_ID.Text & "]?", AddressOf DelQualityDayReport)
    End Sub

    ''' <summary>
    ''' 删除日报表
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub DelQualityDayReport()
        Dim msg As MsgReturn = Dao.QualityDayReport_Del(TB_ID.Text)
        If msg.IsOk Then
            LastForm.ReturnId = TB_ID.Text
            Me.Close()
        Else
            ShowErrMsg(msg.Msg)
        End If
    End Sub


    Private Sub Cmd_SetInValid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_SetInValid.Click
        ShowConfirm("是否作废" & Ch_Name & " [" & TB_ID.Text & "]?", AddressOf QualityDayReportInValid)
    End Sub


    Sub QualityDayReportInValid()
        Dim msg As MsgReturn = Dao.QualityDayReport_InValid(TB_ID.Text, True)
        If msg.IsOk Then
            Me_Refresh()
            LastForm.ReturnId = TB_ID.Text
        Else
            ShowErrMsg(msg.Msg)
        End If
    End Sub

    ''' <summary>
    ''' 反作废
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_SetValid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_SetValid.Click
        ShowConfirm("是否反作废" & Ch_Name & " [" & TB_ID.Text & "]?", AddressOf QualityDayReportValid)
    End Sub

    ''' <summary>
    ''' 作废
    ''' </summary>
    ''' <remarks></remarks>
    Sub QualityDayReportValid()
        Dim msg As MsgReturn = Dao.QualityDayReport_InValid(TB_ID.Text, False)
        If msg.IsOk Then
            Me_Refresh()
            LastForm.ReturnId = TB_ID.Text
        Else
            ShowErrMsg(msg.Msg)
        End If
    End Sub


#End Region


#Region "检查其他人有没有修改过"
    Private LastReLine As Integer = 0
    Private LastAlLine As Integer = 0
    Private Function CheckIsModify() As Boolean
        If Mode <> Mode_Enum.Add Then
            Return Dao.QualityDayReport_CheckIsModify(LId, LastReLine)
        End If
    End Function

#End Region


    Private Sub Cmd_Count_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Count.Click
        Count()
    End Sub



    ''' <summary>
    ''' 计算质量日报表数据
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Count()
        For i As Integer = Fg1.Rows.Count - 1 To 1 Step -1
            Try
                If IsNull(Fg1.Item(i, "GH"), "") = "" OrElse IsNull(Val(Fg1.Item(i, "Client_ID")), 0) = 0 Then
                    Fg1.FinishEditing()
                    Fg1.RemoveItem(i)
                End If
            Catch ex As Exception
            End Try
        Next

        Dim DayLYTB As Decimal = 0

        For i As Integer = 1 To Fg1.Rows.Count - 1
            DayLYTB += Val(Fg1.Item(i, "Weight"))
        Next

        TB_DayLYTB.Text = DayLYTB

        TB_SumBJCL.Text = SumBJCL + Val(TB_DayBJCL.Text)
        TB_SumLYTB.Text = SumLYTB + Val(TB_DayLYTB.Text)

        If Val(TB_DayBJCL.Text) <> 0 Then
            TB_DayLYTBL.Text = Format(Val(TB_DayLYTB.Text) / Val(TB_DayBJCL.Text) * 100, "#,##0.##")
        End If

        If Val(TB_SumBJCL.Text) <> 0 Then
            TB_SumLYTBL.Text = Format(Val(TB_SumLYTB.Text) / Val(TB_SumBJCL.Text) * 100, "#,##0.##")
        End If

    End Sub


End Class

Partial Friend Class Dao
#Region "常量"
    Protected Friend Const QualityDayReport_DB_NAME As String = "质量日报表"
    ''' <summary>
    ''' 删除单据
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_QualityDayReport_DelByid As String = "Delete from T30220_QualityDayReport_Table  where ID=@ID and State=0"
    ''' <summary>
    ''' 获取单头
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_QualityDayReport_GetByid As String = "select top 1 * from T30220_QualityDayReport_Table where ID=@ID"


    ''' <summary>
    ''' 按缸号获取资料
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_QualityDayReport_GetByGH As String = "SELECT TOP 1 C.Client_Name, B.BZ_Name, ZC.BZC_Name,G.BZ_ID,G.BZC_ID,G.Client_ID FROM T30000_Produce_Gd G LEFT JOIN   T10110_Client C ON G.Client_ID = C.ID LEFT JOIN   T10002_BZ B ON G.BZ_ID = B.ID LEFT JOIN T10003_BZC ZC ON G.BZC_ID = ZC.ID  where GH=@GH"

    ''' <summary>
    ''' 获取单头 用于作废和审核
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_QualityDayReport_GetStateByid As String = "select top 1 ID,State,State_User from T30220_QualityDayReport_Table  where ID=@ID"

    ''' <summary>
    ''' 获取检验表,用于显示
    ''' </summary>
    ''' <remarks></remarks>0
    Private Const SQL_QualityDayReport_SelJYListByid As String = "select * from T30221_QualityDayReport_JYList where ID=@ID   "


    ''' <summary>
    ''' 获取检验表,用于初始显示
    ''' </summary>
    ''' <remarks></remarks>0
    Private Const SQL_QualityDayReport_SelJYList As String = "select * from T30224_QualityDayReport_JYList Order by line   "

    ''' <summary>
    ''' 获取漏验项目
    ''' </summary>
    ''' <remarks></remarks>0
    Private Const SQL_GetLYProject As String = "select ReProject_Name from T10025_ReProjet Where ReProject_Type='漏验项目'"



    ''' <summary>
    ''' 获取质量问题分析表,用于显示
    ''' </summary>
    ''' <remarks></remarks>0
    Private Const SQL_QualityDayReport_SelQPListByid As String = "select * from T30222_QualityDayReport_QPList where ID=@ID"



    ''' <summary>
    ''' 获取质量问题漏验明细,用于显示
    ''' </summary>
    ''' <remarks></remarks>0
    Private Const SQL_QualityDayReport_SelLJMSListByid As String = "select LJ.*,C.Client_Name,BZ.BZ_Name,BZC.BZC_Name,BZC.BZC_No from T30223_QualityDayReport_LJMSList LJ left join T10110_Client C on  LJ.Client_ID=C.ID Left join T10002_BZ BZ ON BZ.ID= LJ.BZ_ID left join T10003_BZC BZC On BZC.ID= LJ.BZC_ID  where  LJ.ID=@ID   "

    ''' <summary>
    ''' 获取质量问题漏验明细,用于保存
    ''' </summary>
    ''' <remarks></remarks>0
    Private Const SQL_QualityDayReport_SelLJListByid As String = "select * from T30223_QualityDayReport_LJMSList where  ID=@ID   "


    ''' <summary>
    ''' 检查ID的重复性
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_QualityDayReport_CheckID As String = "select count(*) from T30220_QualityDayReport_Table  where ID=@ID"

    ''' <summary>
    ''' 检查ID的重复性
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_QualityDayReport_CheckIsModify As String = "select count(*) from T30221_QualityDayReport_JYList  where @ID=ID and Line=@Line"


    ''' <summary>
    ''' 计算累计包装产量,累计漏验退布量
    ''' </summary>
    ''' <remarks></remarks>0
    Private Const SQL_GetLG As String = "select Sum(DayBJCL)As SumBJCL  ,Sum(DayLYTB) as SumLYTB  from T30220_QualityDayReport_Table Where sDate between @sDate1 and @sDate2   "



#End Region


#Region "单一张单内容查询"
    ''' <summary>
    ''' 获取对日报表信息
    ''' </summary>
    ''' <param name="sId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function QualityDayReport_GetById(ByVal sId As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_QualityDayReport_GetByid, "@ID", sId)
    End Function

    ''' <summary>
    ''' 获取漏验项目
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetLYProject() As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_GetLYProject)
    End Function


    ''' <summary>
    ''' 获取累计包装产量,累计漏验退布量
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetQualityDayReportLG(ByVal sDate As Date, ByVal eDate As Date) As DtReturnMsg
        Dim p As New Dictionary(Of String, Object)
        p.Add("sDate1", sDate)
        p.Add("sDate2", eDate)
        Return PClass.PClass.SqlStrToDt(SQL_GetLG, p)
    End Function


    ''' <summary>
    ''' 获取对日报表列表信息
    ''' </summary>
    ''' <param name="sId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function QualityDayReport_SelListById(ByVal sId As String) As DtListReturnMsg
        Dim ListMsg As New DtListReturnMsg
        Dim Sqlmap As New Dictionary(Of String, String)
        Dim paraMap As New Dictionary(Of String, Object)
        Sqlmap.Add("JYXm", SQL_QualityDayReport_SelJYList)
        Sqlmap.Add("JY", SQL_QualityDayReport_SelJYListByid)
        Sqlmap.Add("QP", SQL_QualityDayReport_SelQPListByid)
        Sqlmap.Add("LJ", SQL_QualityDayReport_SelLJMSListByid)
        paraMap.Add("ID", sId)
        Return PClass.PClass.SqlStrToDt(Sqlmap, paraMap)
    End Function
#End Region



    ''' <summary> 
    ''' 按缸号获取信息
    ''' </summary>
    ''' <param name="GH"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function QualityDayReport_Get_byGH(ByVal GH As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_QualityDayReport_GetByGH, "GH", GH)
    End Function


    ''' <summary>
    '''获取中检明细
    ''' </summary>
    ''' <param name="sID "></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function QualityDayReport_GetRe_byid(ByVal sID As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_QualityDayReport_SelLJMSListByid, "ID", sID)
    End Function


#Region "添加修改删除"

    ''' <summary>
    ''' 检查其他人有没有修改过
    ''' </summary>
    ''' <param name="ID"></param>
    ''' <param name="Line"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function QualityDayReport_CheckIsModify(ByVal ID As String, ByVal Line As Integer) As Boolean
        Dim P As New Dictionary(Of String, Object)
        P.Add("ID", ID)
        P.Add("Line", Line)
        Dim R As MsgReturn = SqlStrToOneStr(SQL_QualityDayReport_CheckIsModify, P)
        If R.IsOk Then
            If Val(R.Msg) = 0 Then
                Return True
            Else
                Return False
            End If
        Else
            Return True
        End If
    End Function
    ''' <summary>
    ''' 检查ID的重复性
    ''' </summary>
    ''' <param name="ID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function QualityDayReport_CheckID(ByVal ID As String) As Boolean
        Dim R As MsgReturn = SqlStrToOneStr(SQL_QualityDayReport_CheckID, "@ID", ID)
        If R.IsOk Then
            If Val(R.Msg) = 0 Then
                Return False
            Else
                Return True
            End If
        Else
            Return False
        End If
    End Function

    ''' <summary>
    ''' 添加日报表
    ''' </summary>
    ''' <param name="dtTable"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function QualityDayReport_Add(ByVal dtTable As DataTable, ByVal dtJyList As DataTable, ByVal dtQpList As DataTable, ByVal dtLJList As DataTable) As MsgReturn

        Dim R As New MsgReturn
        Dim sqlMap As New Dictionary(Of String, String)
        Dim paraMap As New Dictionary(Of String, Object)
        Dim QualityDayReportId As String = dtTable.Rows(0)("ID")
        Dim BillTypeName As String = QualityDayReport_DB_NAME
        sqlMap.Add("Table", SQL_QualityDayReport_GetByid)
        sqlMap.Add("JYList", SQL_QualityDayReport_SelJYListByid)
        sqlMap.Add("PQList", SQL_QualityDayReport_SelQPListByid)
        sqlMap.Add("LJList", SQL_QualityDayReport_SelLJListByid)

        paraMap.Add("ID", QualityDayReportId)

        Using H As New DtHelper(sqlMap, paraMap)
            If H.IsOk Then
                If H.DtList("Table").Rows.Count = 0 Then
                    DvToDt(dtTable, H.DtList("Table"), New List(Of String), True)
                    DvToDt(dtJyList, H.DtList("JYList"), New List(Of String), True)
                    DvToDt(dtQpList, H.DtList("PQList"), New List(Of String), True)
                    DvToDt(dtLJList, H.DtList("LJList"), New List(Of String), True)
                    If H.UpdateAll(True).IsOk Then '更新多个Dt中的内容到数据库 同时运行Sql语句,使用事务处理
                        R.Msg = "" & QualityDayReport_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]添加成功!"
                        R.IsOk = True
                    Else
                        R.Msg = "" & QualityDayReport_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]添加失败!" & H.Msg
                        R.IsOk = False
                    End If
                Else
                    R.IsOk = False
                    R.Msg = "" & BillTypeName & "[" & dtTable.Rows(0)("ID") & "]已经存在!请双击编号文本框,获取新编号!"
                End If
                Return R
            Else
                R.IsOk = False
                R.Msg = "" & BillTypeName & "[" & dtTable.Rows(0)("ID") & "]添加错误!"
                DebugToLog(New Exception(R.Msg))
                Return R
            End If
        End Using

    End Function

    ''' <summary>
    ''' 修改日报表
    ''' </summary>
    ''' <param name="dtTable"></param>
    ''' <param name="dtJyList"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function QualityDayReport_Save(ByVal dtTable As DataTable, ByVal dtJyList As DataTable, ByVal dtQpList As DataTable, ByVal dtLJList As DataTable) As MsgReturn
        Dim R As New MsgReturn
        Dim sqlMap As New Dictionary(Of String, String)
        Dim paraMap As New Dictionary(Of String, Object)
        Dim QualityDayReportId As String = dtTable.Rows(0)("ID")
        Dim BillTypeName As String = QualityDayReport_DB_NAME
        sqlMap.Add("Table", SQL_QualityDayReport_GetByid)
        sqlMap.Add("JYList", SQL_QualityDayReport_SelJYListByid)
        sqlMap.Add("PQList", SQL_QualityDayReport_SelQPListByid)
        sqlMap.Add("LJList", SQL_QualityDayReport_SelLJListByid)

        paraMap.Add("ID", QualityDayReportId)
        Using H As New DtHelper(sqlMap, paraMap)
            If H.IsOk Then
                If H.DtList("Table").Rows.Count = 1 Then
                    DvUpdateToDt(dtTable, H.DtList("Table"), New List(Of String))
                    DvToDt(dtJyList, H.DtList("JYList"), New List(Of String))
                    DvToDt(dtQpList, H.DtList("PQList"), New List(Of String))
                    DvToDt(dtLJList, H.DtList("LJList"), New List(Of String))
                    If H.UpdateAll(True).IsOk Then '更新多个Dt中的内容到数据库 同时运行Sql语句,使用事务处理
                        R.Msg = "" & QualityDayReport_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]修改成功!"
                        R.IsOk = True
                    Else
                        R.Msg = "" & QualityDayReport_DB_NAME & "[" & dtTable.Rows(0)("ID") & "修改失败!" & H.Msg
                        R.IsOk = False
                    End If
                Else
                    R.IsOk = False
                    R.Msg = "" & BillTypeName & "[" & dtTable.Rows(0)("ID") & "]已经存在!请双击编号文本框,获取新编号!"
                End If
                Return R
            Else
                R.IsOk = False
                R.Msg = "" & BillTypeName & "[" & dtTable.Rows(0)("ID") & "]修改错误!"
                DebugToLog(New Exception(R.Msg))
                Return R
            End If
        End Using

    End Function

    ''' <summary>
    ''' 删除日报表
    ''' </summary>
    ''' <param name="QualityDayReportId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function QualityDayReport_Del(ByVal QualityDayReportId As String)
        Return RunSQL(SQL_QualityDayReport_DelByid, "@ID", QualityDayReportId)
    End Function

    ''' <summary>
    ''' 作废日报表
    ''' </summary>
    ''' <param name="_ID"></param>
    ''' <param name="IsFei">作废还是反作废</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function QualityDayReport_InValid(ByVal _ID As String, ByVal IsFei As Boolean) As MsgReturn
        Dim msg As New DtListReturnMsg
        Dim R As New MsgReturn
        Dim sqlMap As New Dictionary(Of String, String)
        Dim paraMap As New Dictionary(Of String, Object)
        Dim IsInsert As Boolean = False
        Dim OStr As String
        Dim State As Enum_State = Enum_State.AddNew
        If IsFei Then
            OStr = "作废"
            State = Enum_State.Invoid
        Else
            OStr = "反作废"
        End If
        paraMap.Add("ID", _ID)
        Try
            sqlMap.Add("Table", SQL_QualityDayReport_GetStateByid)
            msg = SqlStrToDt(sqlMap, paraMap)
            If msg.DtList("Table").Rows.Count = 1 Then
                If msg.DtList("Table").Rows(0)("State") <> Enum_State.Audited Then
                    If msg.DtList("Table").Rows(0)("State") <> State Then
                        msg.DtList("Table").Rows(0)("State") = State
                        msg.DtList("Table").Rows(0)("State_User") = User_Display
                        DtToUpDate(msg)
                        R.IsOk = True
                        R.Msg = "" & QualityDayReport_DB_NAME & "[" & _ID & "]" & OStr & "成功!"
                    Else
                        R.IsOk = False
                        R.Msg = "" & QualityDayReport_DB_NAME & "[" & _ID & "]已经被" & OStr & "!不能再" & OStr & "!"
                    End If
                Else
                    R.IsOk = False
                    R.Msg = "" & QualityDayReport_DB_NAME & "[" & _ID & "]已经被审核,不能" & OStr & "!"
                End If
            Else
                R.IsOk = False
                R.Msg = "" & QualityDayReport_DB_NAME & "[" & _ID & "]不存在,不能" & OStr & "!"
            End If
            Return R
        Catch ex As Exception
            R.IsOk = False
            R.Msg = "" & QualityDayReport_DB_NAME & "[" & _ID & "]" & OStr & "错误!"
            DebugToLog(ex)
            Return R
        Finally
        End Try
    End Function


    ''' <summary>
    ''' 审核日报表
    ''' </summary>
    ''' <param name="_ID"></param>
    ''' <param name="IsAudited">审核还是反审核</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function QualityDayReport_Audited(ByVal _ID As String, ByVal IsAudited As Boolean) As MsgReturn
        Dim R As MsgReturn
        Dim s As String = IIf(IsAudited, "审核", "反审核")
        Dim state As Integer = IIf(IsAudited, 1, 0)


        Dim paraMap As New Dictionary(Of String, Object)
        paraMap.Add("ID", _ID)
        paraMap.Add("IsAudited", IsAudited)
        paraMap.Add("State_User", IIf(IsAudited, User_Display, ""))

        '判断状态
        Dim msg As DtReturnMsg = SqlStrToDt("select state from  T30220_QualityDayReport_Table where ID=@ID  ", "ID", _ID)
        If msg.IsOk AndAlso msg.Dt.Rows.Count > 0 AndAlso IsNull(msg.Dt.Rows(0)("State"), False) = state Then
            R = New MsgReturn
            R.Msg = QualityDayReport_DB_NAME & s & "失败！[" & _ID & "]已被" & s
            Return R
        End If

        R = SqlStrToOneStr("Update T30220_QualityDayReport_Table set State=@IsAudited,State_User=@State_User where ID=@ID  ", paraMap)

        If R.IsOk Then
            R.Msg = QualityDayReport_DB_NAME & s & "成功！"
        Else
            R.Msg = QualityDayReport_DB_NAME & s & "失败！" & R.Msg
        End If
        Return R
    End Function


#End Region
End Class