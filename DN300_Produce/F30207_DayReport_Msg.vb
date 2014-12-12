Option Compare Text
Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports PClass
Imports BaseClass
Imports PClass.CReport
Imports BaseClass.ComFun

Public Class F30207_DayReport_Msg
    Dim LId As String = ""
    Dim PID As String = ""
    Dim PID_Date As Date = #1/1/1999#
    Dim dtReList As DataTable
    Dim dtAlList As DataTable
    Dim dtDXlist As DataTable
    Dim dtTable As DataTable
    Dim ReportTepy As BillType
    Dim DayCrop As Decimal = 0
    Dim Reson As String = ""
    Dim SumReCrop As Decimal = 0          '累计回修产量
    Dim SumCrop As Decimal = 0            '累计产量
    Dim LJJCGs As Decimal = 0             '累计加色缸数
    Dim LJJCWeight As Decimal = 0         '累计加色公斤数
    Dim LJJZJGs As Decimal = 0            '累计加助剂缸数
    Dim LJJZJWeight As Decimal = 0        '累计加助剂公斤数
    Dim KdDate As Date
    Dim State As Enum_State = Enum_State.AddNew


    Public Sub New(ByVal kDDate As Date)
        ' 此调用是 Windows 窗体设计器所必需的。
        Me.KdDate = kDDate
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
        SumFG2.AddSum()
    End Sub

    'Private Sub Me_Form_KeyDown(ByVal sender As Object, ByRef e As System.Windows.Forms.KeyEventArgs) Handles Me.Form_KeyDown
    '    If e.KeyCode = Keys.Enter Then
    '        Try
    '            If SP.ActiveControl.Name <> Fg1.Name AndAlso SP.ActiveControl.Parent.Name <> Fg1.Name AndAlso SP.ActiveControl.Name <> Fg2.Name AndAlso SP.ActiveControl.Parent.Name <> Fg2.Name AndAlso SP.ActiveControl.Name <> Fg3.Name AndAlso SP.ActiveControl.Parent.Name <> Fg3.Name Then
    '                SendKeys.SendWait("{TAB}")
    '            End If
    '        Catch ex As Exception
    '        End Try
    '    End If
    'End Sub

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
        ComFun.DelBillNewID(ReportTepy, PID)
    End Sub

    Private Sub Form_Load() Handles Me.Me_Load
        If PID = "" AndAlso P_F_RS_ID <> "" Then
            PID = P_F_RS_ID
        End If
        FormCheckRight()
        Select Case P_ID
            Case 30206
                ReportTepy = BillType.RBReport
                Reson = "染部日报表"
                GroupBox1.Visible = True
                TC_List.Controls("Tab1").Text = "染部回修明细"
            Case 30208
                ReportTepy = BillType.DXReport
                Reson = "定型日报表"
                GroupBox1.Visible = False
                TC_List.Controls("Tab1").Text = "定型回修明细"
                TC_List.Controls.Remove(Tab3)
        End Select


        Dim dtProject As DtReturnMsg = Dao.Get_ReProjet
        If dtProject.IsOk Then
            CB_Project.DataSource = dtProject.Dt
        End If
        Fg2.Cols("ReProject").Editor = CB_Project
        Ch_Name = GetBillTypeName(P_ID)
        Me.Title = Ch_Name
        Fg1.IniFormat()
        Me_Refresh()
        For i As Integer = 1 To Fg1.Rows.Count - 1
            Fg1.AutoSizeRow(i)
        Next
        For i As Integer = 1 To Fg3.Rows.Count - 1
            Fg3.AutoSizeRow(i)
        Next
    End Sub

    Protected Sub Me_Refresh()
        Dim msgTable As DtReturnMsg = Dao.DayRePort_GetById(PID)
        If msgTable.IsOk Then
            dtTable = msgTable.Dt
            If Mode = Mode_Enum.Modify AndAlso msgTable.Dt.Rows.Count = 0 Then
                ShowErrMsg("没有找到" & Dao.DayRePort_DB_NAME & "[" & PID & "]", True)
                Exit Sub
            End If
            SetForm(dtTable)
        End If
        Select Case Mode
            Case Mode_Enum.Add
                If CheckRight(ID, ClassMain.Add) = False Then Me.ShowErrMsg("没有权限添加" & Dao.DayRePort_DB_NAME & "!", True) : Exit Sub
                Dim msg As DtListReturnMsg = Dao.DayRePort_SelListById(0)
                If msg.IsOk Then
                    dtReList = msg.DtList("Re")
                    dtAlList = msg.DtList("Al")
                    dtDXlist = msg.DtList("Dx")
                End If
                Fg1.Rows.Count = 2
                Fg1.ReAddIndex()
                Fg2.Rows.Count = 2
                Fg2.ReAddIndex()
                Fg3.Rows.Count = 2
                Fg3.ReAddIndex()   
                LabelTitle.Text = "新建" & Me.Ch_Name
                Cmd_Preview.Enabled = False
                Cmd_Print.Enabled = False
                DTP_sDate.Value = KdDate
                GetNewID()

            Case Mode_Enum.Modify
                Cmd_Preview.Enabled = True
                Cmd_Print.Enabled = True
                Dim msg As DtListReturnMsg = Dao.DayRePort_SelListById(PID)
                If msg.IsOk Then
                    dtReList = msg.DtList("Re")
                    dtAlList = msg.DtList("Al")
                    dtDXlist = msg.DtList("Dx")
                    Fg1.DtToFG(dtReList)
                    Fg2.DtToFG(dtAlList)
                    Fg3.DtToFG(dtDXlist)
                    'LastReLine = dtReList.Rows(0)("Line")
                End If
                LId = TB_ID.Text
                LabelTitle.Text = "修改" & Me.Ch_Name
        End Select
        dtTable.AcceptChanges()
        dtReList.AcceptChanges()
        Count()
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



    ''' <summary>
    ''' 动态计算回修率，动态产量修改
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DayCL(ByRef dt As DataTable, ByVal sDate As Date)
        If dt Is Nothing Then
            Exit Sub
        End If
        Dim StartDate As Date = New Date(sDate.Year, sDate.Month, 1)
        Dim SumCrop As Decimal = 0   '累计产量
        Dim SumReCrop As Decimal = 0  '累计回修道产量
    
        Dim Msg_Sum As DtReturnMsg = Dao.GetReportLG(StartDate, sDate.Date, Reson)
        If Msg_Sum.IsOk AndAlso Msg_Sum.Dt.Rows.Count > 0 Then
            SumCrop = IsNull(Msg_Sum.Dt.Rows(0)("SumCrop"), 0)
            SumReCrop = IsNull(Msg_Sum.Dt.Rows(0)("SumReCrop"), 0)
        End If
        Dim dr As DataRow
        If Mode = Mode_Enum.Add Then
            dr = dt.Rows(0)
            dr("SumCrop") = SumCrop
            dr("SumReCrop") = SumReCrop
        Else
            dr = dt.Rows(0)
            dr("SumCrop") = SumCrop
            dr("SumReCrop") = SumReCrop

        End If
        dt.AcceptChanges()

    End Sub

    ''' <summary>
    ''' 动态计算加色,加助剂,
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CountJS(ByRef dt As DataTable, ByVal sDate As Date)
        If dt Is Nothing Then
            Exit Sub
        End If
        Dim StartDate As Date = New Date(sDate.Year, sDate.Month, 1)
        Dim LJJCGs As Decimal = 0         '累计加色缸数
        Dim LJJCWeight As Decimal = 0     '累计加色公斤数
        Dim LJJZJGs As Decimal = 0        '累计加助剂缸数
        Dim LJJZJWeight As Decimal = 0    '累计加助剂公斤数

        Dim Msg_Sum As DtReturnMsg = Dao.GetReportGsLG(StartDate, sDate.Date, Reson)
        If Msg_Sum.IsOk AndAlso Msg_Sum.Dt.Rows.Count > 0 Then
            LJJCGs = IsNull(Msg_Sum.Dt.Rows(0)("LJJCGs"), 0)
            LJJCWeight = IsNull(Msg_Sum.Dt.Rows(0)("LJJCWeight"), 0)
            LJJZJGs = IsNull(Msg_Sum.Dt.Rows(0)("LJJZJGs"), 0)
            LJJZJWeight = IsNull(Msg_Sum.Dt.Rows(0)("LJJZJWeight"), 0)
        End If
        Dim dr As DataRow
        dr = dt.Rows(0)
        If Mode = Mode_Enum.Add Then
            dr("LJJCGs") = LJJCGs
            dr("LJJCWeight") = LJJCWeight
            dr("LJJZJGs") = LJJZJGs
            dr("LJJZJWeight") = LJJZJWeight
        Else
            dr("LJJCGs") = LJJCGs
            dr("LJJCWeight") = LJJCWeight
            dr("LJJZJGs") = LJJZJGs
            dr("LJJZJWeight") = LJJZJWeight
        End If
        dt.AcceptChanges()

    End Sub


#Region "表单控件事件"
    Private Sub TB_Payed_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        TB_SumCrop.Text = Val(TB_SumCrop.Text)

    End Sub


    Private Sub CB_Supplier_Col_Sel(ByVal Col_No As String, ByVal Col_Name As String, ByVal ID As String)
        TB_DayReCrop.Text = Col_Name
    End Sub

    Private Sub TB_DayRePercent_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TB_SumRePercent.Validating, TB_SumReCrop.Validating, TB_SumCrop.Validating, TB_DayRePercent.Validating, TB_DayReCrop.Validating, TB_DayCrop.Validating
        sender.text = Val(sender.text)
    End Sub
    Private Sub TB_RJSPercent_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TB_RJZJPercent.Validating, TB_RJSPercent.Validating, TB_JZJForPercent.Validating, TB_JSFORPercent.Validating, TB_DXCPRJ.Validating, TB_DXCPLJ.Validating
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
        GetColValue(dr, TB_DayCrop, "", "", IsLock, "0.##")
        GetColValue(dr, TB_DayReCrop, "", "", IsLock, "0.##")
        GetColValue(dr, TB_DayRePercent, "", "", IsLock, "0.##")
        GetColValue(dr, TB_SumCrop, "", "", IsLock, "0.##")
        GetColValue(dr, TB_SumReCrop, "", "", IsLock, "0.##")
        GetColValue(dr, TB_SumRePercent, "", "", IsLock, "0.##")
        GetColValue(dr, TB_Upd_Dept, "", "", IsLock)
        GetColValue(dr, TB_Upd_User, "", "", IsLock)
        GetColValue(dr, TB_State_User, "", "", IsLock)
        GetColValue(dr, TB_RJSGs, "", "", IsLock, "0.##")
        GetColValue(dr, TB_RJSWeight, "", "", IsLock, "0.##")
        GetColValue(dr, TB_RJZJGs, "", "", IsLock, "0.##")
        GetColValue(dr, TB_RJZJWeight, "", "", IsLock, "0.##")
        GetColValue(dr, TB_RJSPercent, "", "", IsLock)
        GetColValue(dr, TB_RJZJPercent, "", "", IsLock)
        GetColValue(dr, TB_LJJCGs, "", "", IsLock, "0.##")
        GetColValue(dr, TB_LJJCWeight, "", "", IsLock, "0.##")
        GetColValue(dr, TB_LJJZJGs, "", "", IsLock, "0.##")
        GetColValue(dr, TB_LJJZJWeight, "", "", IsLock, "0.##")
        GetColValue(dr, TB_JSFORPercent, "", "", IsLock)
        GetColValue(dr, TB_JZJForPercent, "", "", IsLock)
        GetColValue(dr, TB_DXCPRJ, "", "", IsLock)
        GetColValue(dr, TB_DXCPLJ, "", "", IsLock)
        GetColValue(dr, DTP_sDate, ServerTime.Date, "", IsLock)
        dr("ReRemarks") = TB_ReRemarks.Text
        dr("DxRemarks") = TB_DXRemarks.Text
        dr("Remarks") = TB_Remarks.Text
        dr("State") = State
        dr("ID") = IIf(Mode = Mode_Enum.Add, TB_ID.Text, LId)
        dr("Reson") = Reson
        dt.AcceptChanges()
        dtReList = dtReList.Clone
        dtAlList = dtAlList.Clone
        dtDXlist = dtDXlist.Clone
        For i As Integer = 1 To Fg1.Rows.Count - 1
            dr = dtReList.NewRow
            dr("ID") = ID
            dr("BZ_ID") = Val(Fg1.Item(i, "BZ_ID"))
            dr("BZC_ID") = Val(Fg1.Item(i, "BZC_ID"))
            dr("Client_ID") = Val(Fg1.Item(i, "Client_ID"))
            dr("GH") = Fg1.Item(i, "GH")
            dr("Num") = Val(Fg1.Item(i, "Num"))
            dr("Weight") = Val(Fg1.Item(i, "Weight"))
            dr("ReListRemarks") = Fg1.Item(i, "ReListRemarks")
            dtReList.Rows.Add(dr)
        Next

        For i As Integer = 1 To Fg2.Rows.Count - 1
            dr = dtAlList.NewRow
            dr("ID") = ID
            dr("ReProject") = Fg2.Item(i, "ReProject")
            dr("ReSum") = Val(Fg2.Item(i, "ReSum"))
            dr("RePrcent") = Val(Fg2.Item(i, "RePrcent"))
            dr("AnalyRemarks") = Fg2.Item(i, "AnalyRemarks")
            dtAlList.Rows.Add(dr)
        Next

        For i As Integer = 1 To Fg3.Rows.Count - 1
            dr = dtDXlist.NewRow
            dr("ID") = ID
            dr("BZ_ID") = Val(Fg3.Item(i, "BZ_ID"))
            dr("BZC_ID") = Val(Fg3.Item(i, "BZC_ID"))
            dr("Client_ID") = Val(Fg3.Item(i, "Client_ID"))
            dr("GH") = Fg3.Item(i, "GH")
            dr("Qty") = Val(Fg3.Item(i, "Qty"))
            dr("Weight") = Val(Fg3.Item(i, "Weight"))
            dr("JYL") = IsNull(Fg3.Item(i, "JYL"), "")
            dr("JZJ") = IsNull(Fg3.Item(i, "JZJ"), "")
            dtDXlist.Rows.Add(dr)
        Next

        dtAlList.AcceptChanges()
        dtReList.AcceptChanges()
        dtDXlist.AcceptChanges()
        Return dt
    End Function

    ''' <summary>
    ''' 设置表单内容
    ''' </summary>
    ''' <remarks></remarks>
    ''' 
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
            'Dim dCL As DataTable = DayCL(dt, DTP_sDate.Value.Date)
            Dr = dt.NewRow
            Dr("sDate") = KdDate
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
        If Reson = "染部日报表" Then
            CountJS(dt, kDate)
        End If
        LockForm(IsLock)
        SetColValue(Dr, TB_ID, "", "", IdLock)
        SetColValue(Dr, DTP_sDate, ServerTime.Date, "", IsLock)
        SetColValue(Dr, TB_DayCrop, "", "", IsLock, "0.##")
        SetColValue(Dr, TB_DayReCrop, "", "", IsLock, "0.##")
        SetColValue(Dr, TB_DayRePercent, "", "", True, "0.##")
        SetColValue(Dr, TB_DayCrop, "", "", IsLock, "0.##")
        SetColValue(Dr, TB_SumCrop, "", "", True, "0.##")
        SetColValue(Dr, TB_SumReCrop, "", "", True, "0.##")
        SetColValue(Dr, TB_SumRePercent, "", "", IsLock, "0.##")
        SetColValue(Dr, TB_RJSGs, "", "", IsLock)
        SetColValue(Dr, TB_RJZJGs, "", "", IsLock)
        SetColValue(Dr, TB_RJZJWeight, "", "", IsLock)
        SetColValue(Dr, TB_RJSPercent, "", "", IsLock, "0.##")
        SetColValue(Dr, TB_RJZJPercent, "", "", IsLock, "0.##")
        SetColValue(Dr, TB_LJJCGs, "", "", IsLock)
        SetColValue(Dr, TB_LJJZJGs, "", "", IsLock)
        SetColValue(Dr, TB_JSFORPercent, "", "", IsLock, "0.##")
        SetColValue(Dr, TB_JZJForPercent, "", "", IsLock, "0.##")
        SetColValue(Dr, TB_DXCPRJ, "", "", IsLock, "0.##")
        SetColValue(Dr, TB_DXCPLJ, "", "", IsLock, "0.##")
        SetColValue(Dr, TB_Upd_Dept, "", "", True)
        SetColValue(Dr, TB_Upd_User, "", "", True)
        SetColValue(Dr, TB_State_User, "", "", True)
        TB_Remarks.Text = IsNull(Dr("Remarks"), "")
        TB_ReRemarks.Text = IsNull(Dr("ReRemarks"), "")
        TB_DXRemarks.Text = IsNull(Dr("DxRemarks"), "")
        SumReCrop = Val(Dr("SumReCrop"))
        SumCrop = Val(Dr("SumCrop"))
        LJJCGs = Val(Dr("LJJCGs"))                        '累计加色缸数
        LJJCWeight = Val(Dr("LJJCWeight"))                  '累计加色公斤数
        LJJZJGs = Val(Dr("LJJZJGs"))                      '累计加助剂缸数
        LJJZJWeight = Val(Dr("LJJZJWeight"))                  '累计加助剂公斤数
    End Sub

    Sub LockForm(ByVal Lock As Boolean)
        TB_ID.ReadOnly = Lock
        DTP_sDate.Enabled = Not Lock
        Fg1.CanEditing = Not Lock
        Fg1.IsClickStartEdit = Not Lock
        TB_DayRePercent.ReadOnly = Lock
        TB_SumCrop.ReadOnly = Lock
        TB_SumReCrop.ReadOnly = Lock
        Cmd_AddRow.Enabled = Not Lock
        Cmd_RemoveRow.Enabled = Not Lock
    End Sub

  
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
                ShowConfirm("是否保存新" & Ch_Name & "?", AddressOf SaveDayRePort)
            Else
                If CheckIsModify() Then
                    ShowConfirm(Ch_Name & "[" & TB_ID.Text & "] 已经被其他人修改过,是否覆盖别人的修改?", AddressOf SaveDayRePort)
                Else
                    ShowConfirm("是否保存" & Ch_Name & "[" & TB_ID.Text & "] 的修改?", AddressOf SaveDayRePort)
                End If
            End If
        End If
    End Sub

    ''' <summary>
    ''' 保存修改
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub SaveDayRePort(Optional ByVal CallBack As DSub_None = Nothing)
        Dim R As MsgReturn
        Dim Dt As DataTable = GetForm()

        If Me.Mode = Mode_Enum.Add Then
            R = Dao.DayRePort_Add(Dt, dtReList, dtAlList, dtDXlist)
        Else
            R = Dao.DayRePort_Save(Dt, dtReList, dtAlList, dtDXlist)
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
        Count()
        TB_ID.Text = TB_ID.Text.Trim
        TB_ID.Text = TB_ID.Text.Replace("'", "")
        If TB_ID.Text = "" Then
            ShowErrMsg(Ch_Name & "单号不能为空!", AddressOf TB_ID.Focus)
            Return False
        End If
        If (Mode = Mode_Enum.Add Or (Mode = Mode_Enum.Modify And LId <> TB_ID.Text)) AndAlso Dao.DayRePort_CheckID(TB_ID.Text) Then
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
                If Fg2.Item(i, "ReProject") = "" Then
                    Fg2.RemoveItem(i)
                End If
            Catch ex As Exception
            End Try
        Next

        For i As Integer = Fg3.Rows.Count - 1 To 1 Step -1
            Try
                If IsNull(Fg3.Item(i, "GH"), "") = "" Then
                    Fg3.RemoveItem(i)
                End If

                If Val(Fg3.Item(i, "Client_ID")) = 0 Then
                    Fg3.RemoveItem(i)
                End If

            Catch ex As Exception
            End Try
        Next

        'If Fg1.Rows.Count <= 1 Then

        '    ShowErrMsg("回收明细不能为空!")
        '    Return False
        'End If

        ''If Fg2.Rows.Count <= 1 Then
        ''    ShowErrMsg("质量问题分析表不能为空!")
        ''    Return False
        ''End If

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

    'Private Sub CB_Store_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles CB_Project.SelectionChangeCommitted
    '    Fg1.Item(Fg1.RowSel, "ReProject") = CB_Project.Text
    'End Sub



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
            If Fg1.Cols("WL_Name").Index = Fg1.ColSel Then
                ShowGoodsSel(Fg1.Item(Fg1.RowSel, "WL_No"))
            End If
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
                Case "Num"
                    SumFG1.AddSum()
                    Fg1.GotoNextCell(e.Col)
                Case "Weight"
                    SumFG1.AddSum()
                    Fg1.GotoNextCell(e.Col)
                Case "ReListRemarks"
                    Fg1.AutoSizeRow(e.Row)
                    Fg1.GotoNextCell(e.Col)
                Case Else
                    Fg1.GotoNextCell(e.Col)
            End Select
        Else
            Fg1.LastKey = 0
        End If

    End Sub

    Private Sub flex_ChangeEdit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fg1.ChangeEdit, Fg3.ChangeEdit
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
            If sz.Height + 2 > row.HeightDisplay Then
                row.HeightDisplay = CType(sz.Height, Integer) + 2
            End If
        End Try
    End Sub



    ''' <summary>
    '''增行
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_AddRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_AddRow.Click
        If TC_List.SelectedTab.Name = "Tab1" Then
            AddRow(Fg1)
        ElseIf TC_List.SelectedTab.Name = "Tab2" Then
            AddRow(Fg2)
        ElseIf TC_List.SelectedTab.Name = "Tab3" Then
            AddRow(Fg3)
        End If

    End Sub


    ''' <summary>
    ''' 增行
    ''' </summary>
    ''' <remarks></remarks>
    ''' 
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
        If TC_List.SelectedTab.Name = "Tab1" Then
            RemoveRow(Fg1)
        ElseIf TC_List.SelectedTab.Name = "Tab2" Then
            RemoveRow(Fg2)
        ElseIf TC_List.SelectedTab.Name = "Tab3" Then
            RemoveRow(Fg3)
        End If
    End Sub

    Private Sub Fg1_NextCell(ByVal e As PClass.FG.NextCellEventArgs) Handles Fg1.NextCell
        Select Case e.Col
            Case "GH"
                e.ToCol = Fg1.Cols("Num").Index

            Case "Num"
                e.ToCol = Fg1.Cols("Weight").Index

            Case "Weight"
                e.ToCol = Fg1.Cols("ReListRemarks").Index

            Case "ReListRemarks"
                If e.Row + 2 > Fg1.Rows.Count Then
                    Fg1.AddRow()
                End If
                e.ToRow = e.Row + 1
                e.ToCol = Fg1.Cols("GH").Index
            Case Else
                e.ToCol = Fg1.Cols("Num").Index
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
                ShowGoodsSel(Fg1.Item(Fg1.RowSel, "WL_No"))
            End If
        End If
    End Sub

    Private Sub Fg1_KeyDownEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.KeyEditEventArgs)
        If e.KeyCode = Keys.Add AndAlso Fg1.Cols("WL_No").Index = e.Col AndAlso Fg1.CanEditing Then
            ShowGoodsSel(Fg1.Item(Fg1.RowSel, "WL_No"))
        End If
    End Sub


    Private Sub Fg2_NextCell(ByVal e As PClass.FG.NextCellEventArgs) Handles Fg2.NextCell

        Select Case e.Col
            Case "ReProject"
                e.ToCol = Fg2.Cols("ReSum").Index

            Case "ReSum"
                e.ToCol = Fg2.Cols("Reprcent").Index

            Case "Reprcent"
                e.ToCol = Fg2.Cols("AnalyRemarks").Index

            Case "AnalyRemarks"

                If e.Row + 2 > Fg2.Rows.Count Then
                    Fg2.AddRow()
                End If
                e.ToRow = e.Row + 1
                e.ToCol = Fg2.Cols("ReProject").Index

            Case Else
                e.ToCol = Fg2.Cols("ReSum").Index
        End Select
    End Sub


    Private Sub Fg2_AfterEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles Fg2.AfterEdit
        If e.Row < 0 Then
            Exit Sub
        End If
        If Fg2.LastKey = Keys.Enter Then
            Fg2.LastKey = 0
            Select Case Fg2.Cols(e.Col).Name
                Case "ReProject"
                    Fg2.GotoNextCell(e.Col)
                Case "ReSum"
                    Fg2.Item(e.Row, e.Col) = Val(Fg2.Item(e.Row, e.Col))
                    Fg2.GotoNextCell(e.Col)
                Case "RePrcent"
                    Fg2.Item(e.Row, e.Col) = Val(Fg2.Item(e.Row, e.Col))
                    Fg2.GotoNextCell(e.Col)
                Case "AnalyRemarks"
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
            Case "GH"
                e.ToCol = Fg3.Cols("Qty").Index

            Case "Qty"
                e.ToCol = Fg3.Cols("Weight").Index

            Case "Weight"
                e.ToCol = Fg3.Cols("JYL").Index

            Case "JYL"
                e.ToCol = Fg3.Cols("JZJ").Index

            Case "JZJ"

                If e.Row + 2 > Fg3.Rows.Count Then
                    Fg3.AddRow()
                End If
                e.ToRow = e.Row + 1
                e.ToCol = Fg3.Cols("GH").Index

            Case Else
                e.ToCol = Fg3.Cols("Qty").Index
        End Select
    End Sub


    Private Sub Fg3_AfterEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles Fg3.AfterEdit
        If e.Row < 0 Then
            Exit Sub
        End If
        If Fg3.LastKey = Keys.Enter Then
            Fg3.LastKey = 0
            Select Case Fg3.Cols(e.Col).Name
                Case "GH"
                    Fg3.Item(e.Row, "GH") = Fg3.Item(e.Row, "GH").ToString.ToUpper
                    GetByGH(Fg3.Item(e.Row, e.Col), Fg3)
                    Fg3.GotoNextCell(e.Col)

                Case "Qty"
                    Fg3.Item(e.Row, e.Col) = Val(Fg3.Item(e.Row, e.Col))
                    SumFG2.AddSum()
                    Fg3.GotoNextCell(e.Col)

                Case "Weight"
                    Fg3.Item(e.Row, e.Col) = Val(Fg3.Item(e.Row, e.Col))
                    SumFG2.AddSum()
                    Fg3.GotoNextCell(e.Col)

                Case "JYL"
                    Fg3.AutoSizeRow(e.Row)
                    Fg3.GotoNextCell(e.Col)

                Case "JZJ"
                    Fg3.AutoSizeRow(e.Row)
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
    Dim gType As String = ""

    Private Sub Cmd_GoodsSel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ShowGoodsSel(Fg1.Item(Fg1.RowSel, "WL_No"))
    End Sub
    Protected Sub ShowGoodsSel(Optional ByVal _no As String = "")
        If _no Is Nothing Then _no = ""
        If _no = "" Then _no = Fg1.Item(Fg1.RowSel, "WL_No")
        Dim F As BaseForm = LoadFormIDToChild(10004, Me)
        If F Is Nothing Then Exit Sub
        Fg1.RowSel = Fg1.RowSel
        With F
            .P_F_RS_ID = ""
            .P_F_RS_ID2 = _no
            .P_F_RS_ID4 = gType
            .P_F_RS_ID5 = TB_DayReCrop.Text
            .IsSel = True
        End With
        ReturnId = ""
        Me.ReturnObj = Nothing
        Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F, Me)
        AddHandler VF.ClosedX, AddressOf SetGoods
        VF.Show()
    End Sub

    Protected Sub SetGoods()
        If Not Me.ReturnObj Is Nothing AndAlso Fg1.CanEditing AndAlso Fg1.RowSel > 0 Then
            Dim dr As DataRow = ReturnObj
            'For i As Integer = 1 To Fg1.Rows.Count - 1
            '    If CStr(IsNull(dr("ID"), "")) = Fg1.Item(i, "WL_ID") And Fg1.RowSel <> i Then
            '        ShowErrMsg("商品[" & IsNull(dr("WL_Name")) & "]已经存在!", AddressOf Fg1.Focus)
            '        Exit Sub
            '    End If
            'Next
            Fg1.FinishEditing(True)
            Fg1.Item(Fg1.RowSel, "WL_ID") = IsNull(dr("ID"), "")
            Fg1.Item(Fg1.RowSel, "WL_No") = IsNull(dr("WL_No"), "")
            Fg1.Item(Fg1.RowSel, "WL_Name") = IsNull(dr("WL_Name"), "")
            Fg1.Item(Fg1.RowSel, "WL_Unit") = IsNull(dr("WL_Unit"), "")
            Fg1.Item(Fg1.RowSel, "WL_Spec") = IsNull(dr("WL_Spec"), "")
            Fg1.Item(Fg1.RowSel, "Store_ID") = IsNull(dr("WL_Store_ID"), 0)
            If IsNull(dr("WL_Cost"), 0) = 0 Then
                Fg1.Item(Fg1.RowSel, "Price") = Format(IsNull(dr("Wl_Price"), 0), "0.###")
            Else
                Fg1.Item(Fg1.RowSel, "Price") = Format(IsNull(dr("WL_Cost"), 0), "0.###")
            End If
            CB_Project.SelectedValue = IsNull(dr("WL_Store_ID"), 0)
            Fg1.Item(Fg1.RowSel, "Store_Name") = CB_Project.Text
            gType = IsNull(dr("WL_Type_ID"), "")
            Fg1.GotoNextCell("WL_No")
        Else
            Fg1.StartEditing(Fg1.RowSel, Fg1.Cols("WL_No").Index)
        End If
        Me.ReturnObj = Nothing
    End Sub




    ''' <summary>
    '''按缸号选中客户、布种、色号
    ''' </summary>
    ''' <remarks></remarks>
    ''' 
    Protected Sub GetByGH(ByVal GH As String, ByVal FG As FG)
        Dim msg As DtReturnMsg = Dao.DayRePort_Get_byGH(GH)
        If msg.IsOk AndAlso msg.Dt.Rows.Count = 1 Then
            FG.Item(FG.RowSel, "Client_Name") = msg.Dt.Rows(0)("Client_Name")
            FG.Item(FG.RowSel, "Client_ID") = msg.Dt.Rows(0)("Client_ID")
            FG.Item(FG.RowSel, "BZ_Name") = msg.Dt.Rows(0)("BZ_Name")
            FG.Item(FG.RowSel, "BZ_ID") = msg.Dt.Rows(0)("BZ_ID")
            FG.Item(FG.RowSel, "BZC_Name") = msg.Dt.Rows(0)("BZC_Name")
            FG.Item(FG.RowSel, "BZC_No") = msg.Dt.Rows(0)("BZC_No")
            FG.Item(FG.RowSel, "BZC_ID") = msg.Dt.Rows(0)("ID")
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
            ComFun.DelBillNewID(ReportTepy, PID)
            PID_Date = #1/1/1999#
            GetNewID()
        End If
    End Sub

    Sub GetNewID()
        If TB_ID.ReadOnly = False Then
            If DTP_sDate.Value <> PID_Date Then
                Dim R As RetrunNewIdMsg = ComFun.GetBillNewID(ReportTepy, DTP_sDate.Value, PID)
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
        Dim R As New R30207_DayReport_Msg(ReportTepy)
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
       
        Dim msg As MsgReturn = Dao.DayRePort_Audited(TB_ID.Text, True)
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
        SaveDayRePort()
    End Sub

    Private Sub Cmd_UnAudit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_UnAudit.Click
        ShowConfirm("是否反审" & Ch_Name & " [" & TB_ID.Text & "]?", AddressOf UnAudit)
    End Sub

    Protected Sub UnAudit()
        Dim msg As MsgReturn = Dao.DayRePort_Audited(TB_ID.Text, False)
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
        ShowConfirm("是否删除" & Ch_Name & " [" & TB_ID.Text & "]?", AddressOf DelDayRePort)
    End Sub

    ''' <summary>
    ''' 删除日报表
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub DelDayRePort()
        Dim msg As MsgReturn = Dao.DayRePort_Del(TB_ID.Text)
        If msg.IsOk Then
            LastForm.ReturnId = TB_ID.Text
            Me.Close()
        Else
            ShowErrMsg(msg.Msg)
        End If
    End Sub


    Private Sub Cmd_SetInValid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_SetInValid.Click
        ShowConfirm("是否作废" & Ch_Name & " [" & TB_ID.Text & "]?", AddressOf DayRePortInValid)
    End Sub


    Sub DayRePortInValid()
        Dim msg As MsgReturn = Dao.DayRePort_InValid(TB_ID.Text, True)
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
        ShowConfirm("是否反作废" & Ch_Name & " [" & TB_ID.Text & "]?", AddressOf DayRePortValid)
    End Sub

    ''' <summary>
    ''' 作废
    ''' </summary>
    ''' <remarks></remarks>
    Sub DayRePortValid()
        Dim msg As MsgReturn = Dao.DayRePort_InValid(TB_ID.Text, False)
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
            Return Dao.DayRePort_CheckIsModify(LId, LastReLine)
        End If
    End Function

#End Region


    Private Sub Cmd_Count_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Count.Click
        Count()
    End Sub


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

        For i As Integer = Fg2.Rows.Count - 1 To 1 Step -1
            Try
                If Fg2.Item(i, "ReProject") = "" Then
                    Fg2.RemoveItem(i)
                End If
            Catch ex As Exception
            End Try
        Next

        For i As Integer = Fg3.Rows.Count - 1 To 1 Step -1
            Try
                If IsNull(Fg3.Item(i, "GH"), "") = "" OrElse IsNull(Val(Fg3.Item(i, "Client_ID")), 0) = 0 Then
                    Fg1.FinishEditing()
                    Fg3.RemoveItem(i)
                End If

            Catch ex As Exception
            End Try
        Next

        If Fg1.Rows.Count <= 1 Then
            TB_DayReCrop.Text = 0
        End If
        Dim SumWeight As Double = 0
        For R As Integer = 1 To Fg1.Rows.Count - 1
            SumWeight = SumWeight + Val(Fg1.Item(R, "Weight"))
        Next
        TB_SumCrop.Text = SumCrop + Val(TB_DayCrop.Text)
        TB_DayReCrop.Text = FormatNum(SumWeight)
        TB_SumReCrop.Text = SumReCrop + SumWeight
        If Val(TB_DayCrop.Text) <> 0 Then
            TB_DayRePercent.Text = Format((Val(TB_DayReCrop.Text) / Val(TB_DayCrop.Text) * 100), "#,##0.##")
        End If
        If Val(TB_SumCrop.Text) <> 0 Then
            TB_SumRePercent.Text = Format((Val(TB_SumReCrop.Text) / Val(TB_SumCrop.Text) * 100), "#,##0.##")
        End If
        SumWeight = 0
        For R As Integer = 1 To Fg3.Rows.Count - 1
            SumWeight = SumWeight + Val(Fg3.Item(R, "Weight"))
        Next
        TB_RJSGs.Text = Fg3.Rows.Count - 1
        TB_RJSWeight.Text = SumWeight
        TB_LJJCGs.Text = LJJCGs + Val(TB_RJZJGs.Text)
        TB_LJJCWeight.Text = LJJCWeight + Val(TB_RJSWeight.Text)
        TB_LJJZJGs.Text = LJJZJGs + Val(TB_RJZJGs.Text)
        TB_LJJZJWeight.Text = LJJZJWeight + Val(TB_RJZJWeight.Text)
    End Sub

    Private Sub TB_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TB_RJZJWeight.KeyUp, TB_RJZJPercent.KeyUp, TB_RJZJGs.KeyUp, TB_RJSPercent.KeyUp, TB_JZJForPercent.KeyUp, TB_JSFORPercent.KeyUp, TB_DXCPRJ.KeyUp, TB_DXCPLJ.KeyUp, TB_DayCrop.KeyUp
        If e.KeyCode = Keys.Enter Then
            Select Case DirectCast(sender, TextBox).Name
                Case "TB_DayCrop"
                    TB_DXCPRJ.Focus()
                Case "TB_DXCPRJ"
                    TB_DXCPLJ.Focus()
                Case "TB_DXCPLJ"
                    TB_RJZJGs.Focus()
                Case "TB_RJZJGs"
                    TB_RJZJWeight.Focus()
                Case "TB_RJZJWeight"
                    TB_RJSPercent.Focus()
                Case "TB_RJSPercent"
                    TB_RJZJPercent.Focus()
                Case "TB_RJZJPercent"
                    TB_JSFORPercent.Focus()
                Case "TB_JSFORPercent"
                    TB_JZJForPercent.Focus()
                Case "TB_JSFORPercent"
                    TB_JZJForPercent.Focus()
            End Select
        End If
    End Sub
End Class

Partial Friend Class Dao
#Region "常量"
    Protected Friend Const DayRePort_DB_NAME As String = "染部日报表"
    ''' <summary>
    ''' 删除单据
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_DayRePort_DelByid As String = "Delete from T30207_DayRePort_Table  where ID=@ID and State=0"
    ''' <summary>
    ''' 获取单头
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_DayRePort_GetByid As String = "select top 1 * from T30207_DayRePort_Table where ID=@ID"
    ''' <summary>
    ''' 获取单头
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_DayRePort_SelByid As String = "select T.*,C.Supplier_Name From (Select top 1 * from T30207_DayRePort_Table where ID=@ID)  T left join T10100_Supplier C on C.ID=T.Supplier_ID"

    ''' <summary>
    ''' 按缸号获取资料
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_DayRePort_GetByGH As String = "SELECT TOP 1 C.Client_Name, B.BZ_Name, ZC.BZC_Name,ZC.BZC_No,ZC.ID,G.BZ_ID,G.BZC_ID,G.Client_ID FROM T30000_Produce_Gd G LEFT JOIN   T10110_Client C ON G.Client_ID = C.ID LEFT JOIN   T10002_BZ B ON G.BZ_ID = B.ID LEFT JOIN T10003_BZC ZC ON G.BZC_ID = ZC.ID  where GH=@GH"

    ''' <summary>
    ''' 获取单头 用于作废和审核
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_DayRePort_GetStateByid As String = "select top 1 ID,State,State_User from T30207_DayRePort_Table  where ID=@ID"
    ''' <summary>
    ''' 获取单体
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_DayRePort_GetListByid As String = "select * from T20001_DayRePort_List  where ID=@ID "
    ''' <summary>
    ''' 获取回修明细单体详细,用于显示
    ''' </summary>
    ''' <remarks></remarks>0
    Private Const SQL_DayRePort_SelReListByid As String = "select Re.*,C.Client_Name,BZ.BZ_Name,BZC.BZC_Name ,BZC.BZC_No from T30208_DayReport_ReList Re left join T10110_Client C on RE.Client_ID=C.ID Left join T10002_BZ BZ ON BZ.ID=Re.BZ_ID left join T10003_BZC BZC On BZC.ID=Re.BZC_ID  where Re.ID=@ID   "

    ''' <summary>
    ''' 获取定型加色明细表,用于显示
    ''' </summary>
    ''' <remarks></remarks>0
    Private Const SQL_DayRePort_SelDXListByid As String = "select Dx.*,BZ.BZ_Name,BZC.BZC_Name ,BZC.BZC_No,C.Client_Name from T30210_DayReport_DXLC Dx left join  T10002_BZ BZ ON BZ.ID=Dx.BZ_ID left join T10003_BZC BZC On BZC.ID=Dx.BZC_ID Left join T10110_Client C on Dx.Client_ID=C.ID where Dx.ID=@ID   "





    ''' <summary>
    ''' 获取回修明细单体,
    ''' </summary>
    ''' <remarks></remarks>0
    Private Const SQL_DayRePort_ReListByid As String = "select * from T30208_DayReport_ReList where ID=@ID   "


    ''' <summary>
    ''' 获取定型加色单体,
    ''' </summary>
    ''' <remarks></remarks>0
    Private Const SQL_DayRePort_DxListByid As String = "select * from T30210_DayReport_DXLC where ID=@ID   "


    ''' <summary>
    ''' 获取问题分析表,用于显示
    ''' </summary>
    ''' <remarks></remarks>0
    Private Const SQL_DayRePort_SelAlListByid As String = "select * from T30209_DayReport_AnalysisList where ID=@ID"

    ''' <summary>
    ''' 按能耗表计算月产量
    ''' </summary>
    ''' <remarks></remarks>0
    Private Const SQL_GetSumCL As String = " SELECT Sum(DayCrop) AS SumCrop, Sum(DayReCrop) AS SumReCrop, Sum(DayRePercent)AS SumRePercent FROM T30207_DayReport_Table WHERE sDate Between @sDate1 AND @sDate2 and Reson=@Reson "

    ''' <summary>
    ''' 按能耗表获取当日产量
    ''' </summary>
    ''' <remarks></remarks>0
    Private Const SQL_GetCLbydAY As String = " SELECT RB_CL ,DX_CL  FROM T30920_Energy WHERE sDate=@sDate "

    ''' <summary>
    ''' 检查ID的重复性
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_DayRePort_CheckID As String = "select count(*) from T30207_DayRePort_Table  where ID=@ID"
    ''' <summary>
    ''' 检查ID的重复性
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_DayRePort_CheckIsModify As String = "select count(*) from T30208_DayReport_ReList  where @ID=ID and Line=@Line"


    ''' <summary>
    ''' 获取回修项目
    ''' </summary>
    ''' <remarks></remarks>0
    Private Const SQL_GetProjectName As String = " SELECT ReProject_Name FROM T10025_ReProjet Where ReProject_Type='回修项目'"

    ''' <summary>
    ''' 获取加色,加助剂累计
    ''' </summary>
    ''' <remarks></remarks>0
    Private Const SQL_GetSh As String = " SELECT Sum(RJSGS)as LJJCGs,Sum(RJSWeight)as LJJCWeight ,Sum(RJZJGS) as LJJZJGs ,Sum(RJZJWeight) as LJJZJWeight from T30207_DayReport_Table Where sDate between @sDate1 and @sDate2 And Reson=@Reson "




#End Region


#Region "单一张单内容查询"
    ''' <summary>
    ''' 获取对日报表信息
    ''' </summary>
    ''' <param name="sId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function DayRePort_GetById(ByVal sId As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_DayRePort_GetByid, "@ID", sId)
    End Function


    ''' <summary>
    '''获取回修项目
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Get_ReProjet() As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_GetProjectName)
    End Function


    ''' <summary>
    ''' 获取对日报表列表信息
    ''' </summary>
    ''' <param name="sId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function DayRePort_SelListById(ByVal sId As String) As DtListReturnMsg
        Dim ListMsg As New DtListReturnMsg
        Dim Sqlmap As New Dictionary(Of String, String)
        Dim paraMap As New Dictionary(Of String, Object)
        Sqlmap.Add("Re", SQL_DayRePort_SelReListByid)
        Sqlmap.Add("Al", SQL_DayRePort_SelAlListByid)
        Sqlmap.Add("Dx", SQL_DayRePort_SelDXListByid)
        paraMap.Add("ID", sId)
        Return PClass.PClass.SqlStrToDt(Sqlmap, paraMap)
    End Function
#End Region

    ''' <summary>
    '''获取报表当月累计
    ''' </summary>
    ''' <param name="sDate"></param>
    ''' <param name="eDate"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetReportLG(ByVal sDate As Date, ByVal eDate As Date, ByVal Reson As String) As DtReturnMsg
        Dim P As New Dictionary(Of String, Object)
        P.Add("sDate1", sDate)
        P.Add("sDate2", eDate)
        P.Add("Reson", Reson)
        Return PClass.PClass.SqlStrToDt(SQL_GetSumCL, P)
    End Function


    ''' <summary>
    '''获取报表当月加色助剂累计
    ''' </summary>
    ''' <param name="sDate"></param>
    ''' <param name="eDate"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetReportGsLG(ByVal sDate As Date, ByVal eDate As Date, ByVal Reson As String) As DtReturnMsg
        Dim P As New Dictionary(Of String, Object)
        P.Add("sDate1", sDate)
        P.Add("sDate2", eDate)
        P.Add("Reson", Reson)
        Return PClass.PClass.SqlStrToDt(SQL_GetSh, P)
    End Function



    ''' <summary>
    '''按能耗表获取当日产量
    ''' </summary>
    ''' <param name="sDate"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CL_ByDay(ByVal sDate As Date) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_GetCLbydAY, "@sDate", sDate)
    End Function



    ''' <summary>
    ''' 按缸号获取信息
    ''' </summary>
    ''' <param name="GH"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function DayRePort_Get_byGH(ByVal GH As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_DayRePort_GetByGH, "GH", GH)
    End Function


    ''' <summary>
    '''获取回收明细
    ''' </summary>
    ''' <param name="sID "></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function DayRePort_GetRe_byid(ByVal sID As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_DayRePort_SelReListByid, "ID", sID)
    End Function


#Region "添加修改删除"

    ''' <summary>
    ''' 检查其他人有没有修改过
    ''' </summary>
    ''' <param name="ID"></param>
    ''' <param name="Line"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function DayRePort_CheckIsModify(ByVal ID As String, ByVal Line As Integer) As Boolean
        Dim P As New Dictionary(Of String, Object)
        P.Add("ID", ID)
        P.Add("Line", Line)
        Dim R As MsgReturn = SqlStrToOneStr(SQL_DayRePort_CheckIsModify, P)
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
    Public Shared Function DayRePort_CheckID(ByVal ID As String) As Boolean
        Dim R As MsgReturn = SqlStrToOneStr(SQL_DayRePort_CheckID, "@ID", ID)
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
    Public Shared Function DayRePort_Add(ByVal dtTable As DataTable, ByVal dtReList As DataTable, ByVal dtAllist As DataTable, ByVal dtDxlist As DataTable) As MsgReturn

        Dim R As New MsgReturn
        Dim sqlMap As New Dictionary(Of String, String)
        Dim paraMap As New Dictionary(Of String, Object)
        Dim DayReportId As String = dtTable.Rows(0)("ID")
        Dim BillTypeName As String = DayRePort_DB_NAME
        sqlMap.Add("Table", SQL_DayRePort_GetByid)
        sqlMap.Add("ReList", SQL_DayRePort_ReListByid)
        sqlMap.Add("AlList", SQL_DayRePort_SelAlListByid)
        sqlMap.Add("DxList", SQL_DayRePort_DxListByid)

        paraMap.Add("ID", DayReportId)

        Using H As New DtHelper(sqlMap, paraMap)
            If H.IsOk Then
                If H.DtList("Table").Rows.Count = 0 Then
                    DvToDt(dtTable, H.DtList("Table"), New List(Of String), True)
                    DvToDt(dtReList, H.DtList("ReList"), New List(Of String), True)
                    DvToDt(dtAllist, H.DtList("AlList"), New List(Of String), True)
                    DvToDt(dtDxlist, H.DtList("DxList"), New List(Of String), True)
                    If H.UpdateAll(True).IsOk Then '更新多个Dt中的内容到数据库 同时运行Sql语句,使用事务处理
                        R.Msg = "" & DayRePort_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]添加成功!"
                        R.IsOk = True
                    Else
                        R.Msg = "" & DayRePort_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]添加失败!" & H.Msg
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
    ''' <param name="dtRelist"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function DayRePort_Save(ByVal dtTable As DataTable, ByVal dtRelist As DataTable, ByVal dtAlList As DataTable, ByVal dtDxList As DataTable) As MsgReturn
        Dim R As New MsgReturn
        Dim sqlMap As New Dictionary(Of String, String)
        Dim paraMap As New Dictionary(Of String, Object)
        Dim DayReportId As String = dtTable.Rows(0)("ID")
        Dim BillTypeName As String = DayRePort_DB_NAME
        sqlMap.Add("Table", SQL_DayRePort_GetByid)
        sqlMap.Add("ReList", SQL_DayRePort_ReListByid)
        sqlMap.Add("AlList", SQL_DayRePort_SelAlListByid)
        sqlMap.Add("DxList", SQL_DayRePort_DxListByid)

        paraMap.Add("ID", DayReportId)
        Using H As New DtHelper(sqlMap, paraMap)
            If H.IsOk Then
                If H.DtList("Table").Rows.Count = 1 Then
                    DvUpdateToDt(dtTable, H.DtList("Table"), New List(Of String))
                    DvToDt(dtRelist, H.DtList("ReList"), New List(Of String))
                    DvToDt(dtAlList, H.DtList("AlList"), New List(Of String))
                    DvToDt(dtDxList, H.DtList("DxList"), New List(Of String))
                    If H.UpdateAll(True).IsOk Then '更新多个Dt中的内容到数据库 同时运行Sql语句,使用事务处理
                        R.Msg = "" & DayRePort_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]修改成功!"
                        R.IsOk = True
                    Else
                        R.Msg = "" & DayRePort_DB_NAME & "[" & dtTable.Rows(0)("ID") & "修改失败!" & H.Msg
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
    ''' <param name="DayRePortId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function DayRePort_Del(ByVal DayRePortId As String)
        Return RunSQL(SQL_DayRePort_DelByid, "@ID", DayRePortId)
    End Function

    ''' <summary>
    ''' 作废日报表
    ''' </summary>
    ''' <param name="_ID"></param>
    ''' <param name="IsFei">作废还是反作废</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function DayRePort_InValid(ByVal _ID As String, ByVal IsFei As Boolean) As MsgReturn
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
            sqlMap.Add("Table", SQL_DayRePort_GetStateByid)
            msg = SqlStrToDt(sqlMap, paraMap)
            If msg.DtList("Table").Rows.Count = 1 Then
                If msg.DtList("Table").Rows(0)("State") <> Enum_State.Audited Then
                    If msg.DtList("Table").Rows(0)("State") <> State Then
                        msg.DtList("Table").Rows(0)("State") = State
                        msg.DtList("Table").Rows(0)("State_User") = User_Display
                        DtToUpDate(msg)
                        R.IsOk = True
                        R.Msg = "" & DayRePort_DB_NAME & "[" & _ID & "]" & OStr & "成功!"
                    Else
                        R.IsOk = False
                        R.Msg = "" & DayRePort_DB_NAME & "[" & _ID & "]已经被" & OStr & "!不能再" & OStr & "!"
                    End If
                Else
                    R.IsOk = False
                    R.Msg = "" & DayRePort_DB_NAME & "[" & _ID & "]已经被审核,不能" & OStr & "!"
                End If
            Else
                R.IsOk = False
                R.Msg = "" & DayRePort_DB_NAME & "[" & _ID & "]不存在,不能" & OStr & "!"
            End If
            Return R
        Catch ex As Exception
            R.IsOk = False
            R.Msg = "" & DayRePort_DB_NAME & "[" & _ID & "]" & OStr & "错误!"
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
    Public Shared Function DayRePort_Audited(ByVal _ID As String, ByVal IsAudited As Boolean) As MsgReturn   
        Dim R As MsgReturn
        Dim s As String = IIf(IsAudited, "审核", "反审核")
        Dim state As Integer = IIf(IsAudited, 1, 0)
        Dim paraMap As New Dictionary(Of String, Object)
        paraMap.Add("ID", _ID)
        paraMap.Add("IsAudited", IsAudited)
        paraMap.Add("State_User", IIf(IsAudited, User_Display, ""))
        '判断状态
        Dim msg As DtReturnMsg = SqlStrToDt("select state from  T30207_DayReport_Table where ID=@ID  ", "ID", _ID)
        If msg.IsOk AndAlso msg.Dt.Rows.Count > 0 AndAlso IsNull(msg.Dt.Rows(0)("State"), False) = state Then
            R = New MsgReturn
            R.Msg = DayRePort_DB_NAME & s & "失败！[" & _ID & "]已被" & s
            Return R
        End If
        R = SqlStrToOneStr("Update T30207_DayReport_Table set State=@IsAudited,State_User=@State_User where ID=@ID  ", paraMap)

        If R.IsOk Then
            R.Msg = DayRePort_DB_NAME & s & "成功！"
        Else
            R.Msg = DayRePort_DB_NAME & s & "失败！" & R.Msg
        End If
        Return R
    End Function


#End Region
End Class