Option Compare Text
Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports PClass
Imports BaseClass
Imports PClass.CReport

Public Class F30230_GSSQ_Msg
    Dim LId As String = ""
    'Dim Bill_Id As String = ""
    Dim PID As String = ""
    Dim Bill_Id_Date As Date = #1/1/1999#
    Dim dtList As DataTable
    Dim dtTable As DataTable
    Dim DtChePai As DataTable
    '   Dim StoreDt As DataTable
    Dim State As Enum_State = Enum_State.AddNew
    Dim IsBidings As Boolean = False
    Dim Payment As Boolean = False

    Public Sub New()
        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        ' 在 InitializeComponent() 调用之后添加任何初始化。
    End Sub

    Public Sub New(ByVal initID As String)
        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        ' 在 InitializeComponent() 调用之后添加任何初始化。
        Bill_ID = initID
        Me.Mode = Mode
    End Sub

    'Private Sub Me_AfterLoad() Handles Me.AfterLoad
    '    If Fg1.Rows.Count > 1 Then
    '        Fg1.RowSel = 1
    '        Fg1.Row = 1
    '        Fg1.Select(1, Fg1.Cols("GH").Index, 1, Fg1.Cols("GH").Index)
    '    End If
    'End Sub

    'Private Sub Me_Form_KeyDown(ByVal sender As Object, ByRef e As System.Windows.Forms.KeyEventArgs) Handles Me.Form_KeyDown
    '    If e.KeyCode = Keys.Enter Then
    '        Try
    '            If Me.ActiveControl.Name <> Fg1.Name AndAlso ActiveControl.Parent.Name <> Fg1.Name Then
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
    End Sub

    Private Sub GSSQ_Msg_Form_KeyDown(ByVal sender As Object, ByRef e As System.Windows.Forms.KeyEventArgs) Handles Me.Form_KeyDown
        If e.KeyCode = Keys.Enter Then
            Try
                SendKeys.SendWait("{TAB}")
            Catch ex As Exception
            End Try
        End If
    End Sub


    Private Sub Form_Me_Closing(ByVal sender As Object, ByRef e As System.ComponentModel.CancelEventArgs) Handles Me.Me_Closing
        ComFun.DelBillNewID(BillType.GSSQ, Bill_ID)
    End Sub

    Private Sub Form_Load() Handles Me.Me_Load
        ID = 30229
        FormCheckRight()
        Ch_Name = GetBillTypeName(ID)
        Me.Title = Ch_Name

        If Bill_ID = "" AndAlso P_F_RS_ID <> "" Then
            Bill_ID = P_F_RS_ID
        End If
        Me_Refresh()     
    End Sub

    Protected Sub Me_Refresh()
        Dim msgTable As DtReturnMsg = Dao.GSSQ_GetById(Bill_ID)
        If msgTable.IsOk Then
            If IsBidings Then
                DvUpdateToDt(msgTable.Dt, dtTable, New List(Of String))
            Else
                dtTable = msgTable.Dt
            End If
            If Mode = Mode_Enum.Modify AndAlso msgTable.Dt.Rows.Count = 0 Then
                ShowErrMsg("没有找到" & Dao.GSSQ_DB_NAME & "[" & Bill_ID & "]", True)
                Exit Sub
            End If
            SetForm(dtTable)
        End If
        Select Case Mode
            Case Mode_Enum.Add
                If CheckRight(ID, ClassMain.Add) = False Then Me.ShowErrMsg("没有权限添加" & Dao.GSSQ_DB_NAME & "!", True) : Exit Sub
                Dim msg As DtReturnMsg = Dao.GSSQ_SelById(0)
                If msg.IsOk Then dtList = msg.Dt
                TB_UPD_USER.Text = User_Display
                LabelTitle.Text = "新建" & Me.Ch_Name
                Cmd_Preview.Enabled = False
                Cmd_Print.Enabled = False
                DTP_sDate.Value = GetDate()
                GetNewID()
            Case Mode_Enum.Modify
                TB_Modifier.Text = User_Display
                GB_Return.Visible = False
                TB_GH.Enabled = False
                Cmd_Preview.Enabled = True
                Cmd_Print.Enabled = True
                Dim msg As DtReturnMsg = Dao.GSSQ_SelById(Bill_ID)
                If msg.IsOk Then
                    dtList = msg.Dt
                    Setlist(dtList)
                End If
                LId = TB_ID.Text
                LabelTitle.Text = "修改" & Me.Ch_Name
        End Select
        'CaculateSumZL()
        dtTable.AcceptChanges()
        dtList.AcceptChanges()



    End Sub

    'Sub GetDtMsg()
    '    StoreDt = ComFun.GetStoreDt()
    '    CB_Store.DataSource = StoreDt
    'End Sub

#Region "表单控件事件"
    'Private Sub TB_Payed_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
    '    TB_Payed.Text = Val(TB_Payed.Text)
    '    CaculateSumZL()
    'End Sub
#End Region

#Region "表单信息"
    ''' <summary>
    ''' 获取表单内容
    ''' </summary>
    ''' <remarks></remarks>
    Protected Function GetForm() As DataTable
        '获取表头内容
        Dim dt As DataTable
        Dim ID As String = IIf(Mode = Mode_Enum.Add, TB_ID.Text, LId)
        dt = dtTable
        Dim dr As DataRow = dt.Rows(0)
        dr("State") = State
        dr("sReason_Date") = DTP_sReason_Date.Value
        dr("YFCS_Date") = DTP_YFCS_Date.Value
        dr("CFCS_Date") = DTP_CFCS_Date.Value
        dr("GH_State") = TB_GH_State.Tag
        dr("Banci") = RB_morning.Checked
        dt.AcceptChanges()

        '获取表体内容
        dtList = dtList.Clone
        dr = dtList.NewRow
        dr("ID") = ID
        dr("GH") = TB_GH.Text
        dr("BZC_ID") = Val(TB_BZCID.Tag)
        dr("BZ_ID") = Val(TB_BZID.Tag)
        dr("Client_ID") = Val(TB_ClientID.Tag)
        dr("CPName") = TB_CPName.Text
        dr("ClientBZC") = TB_ClientBZC.Text
        dr("BZC_PF") = TB_BZC_PF.Text
        dr("BzcMsg") = TB_BzcMsg.Text
        dr("FK") = TB_FK.Text
        dr("KZ") = TB_KZ.Text

        dr("LBZC_ID") = Val(CB_NBZC.IDValue)
        dr("LBZ_ID") = Val(TB_NBZName.Tag)
        dr("LClient_ID") = Val(TB_NClient_Name.Tag)
        dr("LCPName") = TB_NCPName.Text
        dr("LClientBZC") = TB_NClientBZC.Text
        dr("LBZC_PF") = CB_NBZC_PF.Text
        dr("LBzcMsg") = TB_NBzcMsg.Text
        dr("LFK") = TB_NFK.Text
        dr("LKZ") = TB_NKZ.Text

        dr("NBZC_ID") = Val(CB_NBZC.IDValue)
        dr("NBZ_ID") = Val(TB_NBZName.Tag)
        dr("NClient_ID") = Val(TB_NClient_Name.Tag)
        dr("NCPName") = TB_NCPName.Text
        dr("NClientBZC") = TB_NClientBZC.Text
        dr("NBZC_PF") = CB_NBZC_PF.Text
        dr("NBzcMsg") = TB_NBzcMsg.Text
        dr("NFK") = TB_NFK.Text
        dr("NKZ") = TB_NKZ.Text

        dr("Qty") = Val(TB_SumQty.Text)
        dr("ZL") = Val(TB_SumZL.Text)



        dtList.Rows.Add(dr)
        dtList.AcceptChanges()
        Return dt
    End Function
    ''' <summary>
    ''' 设置原单/改单内容
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <remarks></remarks>
    Protected Sub Setlist(ByVal dt As DataTable)
        If dt Is Nothing Then
            Exit Sub
        End If
        Dim dr As DataRow
        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)
            TB_GH.Text = dr("GH")
            TB_LBZName.Text = IsNull(dr("BZ_Name"), "")
            TB_LClient_Name.Text = IsNull(dr("Client_Name"), "")
            TB_LBZC.Text = IsNull(dr("BZC_No"), "")
            TB_LBZCName.Text = IsNull(dr("BZC_Name"), "")
            TB_LCPName.Text = IsNull(dr("CPName"), "")
            TB_LClientBZC.Text = IsNull(dr("ClientBZC"), "")
            TB_LBZ_No.Text = IsNull(dr("BZ_No"), "")
            TB_LBZCName.Tag = IsNull(dr("BZC_ID"), "")
            TB_LBZName.Tag = IsNull(dr("BZ_ID"), "")
            TB_LClient_Name.Tag = IsNull(dr("Client_ID"), "")
            TB_LBZC_PF.Text = IsNull(dr("BZC_PF"), "")
            TB_LBzcMsg.Text = IsNull(dr("BzcMsg"), "")
            TB_LFK.Text = IsNull(dr("FK"), "")
            TB_LKZ.Text = IsNull(dr("KZ"), "")

            TB_BZCID.Tag = IsNull(dr("BZC_ID"), "")
            TB_BZID.Tag = IsNull(dr("BZ_ID"), "")
            TB_ClientID.Tag = IsNull(dr("Client_ID"), "")
            TB_BZC_PF.Text = IsNull(dr("BZC_PF"), "")
            TB_ClientBZC.Text = IsNull(dr("ClientBZC"), "")
            TB_CPName.Text = IsNull(dr("CPName"), "")
            TB_BzcMsg.Text = IsNull(dr("BzcMsg"), "")
            TB_FK.Text = IsNull(dr("FK"), "")
            TB_KZ.Text = IsNull(dr("KZ"), "")

            CB_NBZC.IDValue = IsNull(dr("NBZC_ID"), "")
            CB_NBZC.Text = IsNull(dr("NBZC_No"), "")
            TB_NBZName.Tag = IsNull(dr("NBZ_ID"), "")
            TB_NClient_Name.Tag = IsNull(dr("NClient_ID"), "")
            TB_NClient_Name.Text = IsNull(dr("NClient_Name"), "")
            TB_NCPName.Text = IsNull(dr("NCPName"), "")
            TB_NClientBZC.Text = IsNull(dr("NClientBZC"), "")
            TB_NBzcMsg.Text = IsNull(dr("NBzcMsg"), "")
            TB_NBZName.Text = IsNull(dr("NBZ_Name"), "")
            CB_NBZ_No.Text = IsNull(dr("NBZ_No"), "")
            TB_NBZCName.Text = IsNull(dr("NBZC_Name"), "")
            TB_NFK.Text = IsNull(dr("NFK"), "")
            TB_NKZ.Text = IsNull(dr("NKZ"), "")

            CB_NBZC.SearchType = cSearchType.ENum_SearchType.Client
            CB_NBZC.SearchID = IsNull(dr("NClient_ID"), "")
        Else
            Exit Sub
        End If
    End Sub

    ''' <summary>
    ''' 设置表头内容
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub SetForm(ByVal dt As DataTable)
        If dt Is Nothing Then
            Exit Sub
        End If
        If IsBidings = False Then dt.Columns.Add("UnPayed", GetType(Double))
        Dim Dr As DataRow
        If dt.Rows.Count = 0 Then
            Dr = dt.NewRow
            Dr("UnPayed") = 0
            Dr("State_User") = ""
            Dr("Remark") = ""
            Dr("ID") = ""
            Dr("sDate") = ServerTime.Date
            Dr("SumZL") = 0

            Cmd_Audit.Visible = Cmd_Audit.Tag
            Cmd_Audit.Enabled = True
            Cmd_UnAudit.Visible = False
            Cmd_UnAudit.Enabled = False

            Cmd_SetValid.Visible = False
            Cmd_SetValid.Enabled = False
            Cmd_SetInValid.Visible = Cmd_SetInValid.Tag
            Cmd_SetInValid.Enabled = False
            Cmd_Del.Visible = False
            LabelState.Text = "新建"
            LabelState.ForeColor = Color.Black
            dt.Rows.Add(Dr)
            dt.AcceptChanges()
            LockForm(False)
        Else
            Dr = dt.Rows(0)
            State = Dr("State")
            Cmd_Del.Visible = False
            Select Case State
                Case Enum_State.AddNew '新建
                    LabelState.Text = "新建"
                    LabelState.ForeColor = Color.Black
                    Cmd_Modify.Enabled = Cmd_Modify.Tag

                    Cmd_Audit.Visible = Cmd_Audit.Tag
                    Cmd_Audit.Enabled = True
                    Cmd_UnAudit.Visible = False
                    Cmd_UnAudit.Enabled = False

                    Cmd_SetValid.Visible = False
                    Cmd_SetValid.Enabled = False
                    Cmd_SetInValid.Visible = Cmd_SetInValid.Tag
                    Cmd_SetInValid.Enabled = True
                    Cmd_Del.Visible = Cmd_Del.Tag
                    LockForm(False)
                Case Enum_State.Invoid '作废
                    LabelState.Text = "已作废"
                    LabelState.ForeColor = Color.Red
                    Cmd_Modify.Enabled = False

                    Cmd_Audit.Visible = Cmd_Audit.Tag
                    Cmd_Audit.Enabled = False
                    Cmd_UnAudit.Visible = False
                    Cmd_UnAudit.Enabled = False



                    Cmd_SetValid.Visible = Cmd_SetValid.Tag
                    Cmd_SetValid.Enabled = True
                    Cmd_SetInValid.Visible = False
                    Cmd_SetInValid.Enabled = False
                    LockForm(True)
                Case Enum_State.Audited '审核

                    LabelState.Text = "已审核"
                    LabelState.ForeColor = Color.Blue
                    Cmd_Modify.Enabled = False

                    Cmd_Audit.Visible = False
                    Cmd_Audit.Enabled = False
                    Cmd_UnAudit.Visible = Cmd_UnAudit.Tag
                    Cmd_UnAudit.Enabled = True
                    CB_NBZC.Enabled = False


                    Cmd_SetValid.Visible = False
                    Cmd_SetValid.Enabled = False
                    Cmd_SetInValid.Visible = Cmd_SetInValid.Tag
                    Cmd_SetInValid.Enabled = False
                    LockForm(True)
            End Select
        End If
        If IsBidings = False Then
            'Dr = dt.Rows(0)
            'TB_ID.Text = Dr("ID")
            'DTP_sDate.Value = IsNull(Dr("sDate"), "")
            'TB_CBPS.Text = IsNull(Dr("CBPS"), "")
            'TB_sReason.Text = IsNull(Dr("sReason"), "")
            'TB_YFCS.Text = IsNull(Dr("YFCS"), "")
            'TB_CFCS.Text = IsNull(Dr("CFCS"), "")
            'TB_sReason_ZG.Text = IsNull(Dr("sReason_ZG"), "")
            'TB_YFCS_ZG.Text = IsNull(Dr("YFCS_ZG"), "")
            'TB_CFCS_ZG.Text = IsNull(Dr("CFCS_ZG"), "")
            'TB_SumQty.Text = IsNull(Dr("SumQty"), "")
            'TB_SumZL.Text = IsNull(Dr("SumZL"), "")
            'TB_UPD_USER.Text = IsNull(Dr("UPD_USER"), "")
            TB_ID.DataBindings.Add("Text", dtTable, TB_ID.Name.Substring(3), False, DataSourceUpdateMode.OnPropertyChanged)
            DTP_sDate.DataBindings.Add("Value", dtTable, DTP_sDate.Name.Substring(4), False, DataSourceUpdateMode.OnPropertyChanged, ServerTime.Date, "yyyy-MM-dd")
            'DTP_Reason_Date.DataBindings.Add("Value", dtTable, DTP_Reason_Date.Name.Substring(4), False, DataSourceUpdateMode.OnPropertyChanged, ServerTime.Date, "yyyy-MM-dd")
            'DTP_YFCS_Date.DataBindings.Add("Value", dtTable, DTP_YFCS_Date.Name.Substring(4), False, DataSourceUpdateMode.OnPropertyChanged, ServerTime.Date, "yyyy-MM-dd")
            'DTP_CFCS_Date.DataBindings.Add("Value", dtTable, DTP_CFCS_Date.Name.Substring(4), False, DataSourceUpdateMode.OnPropertyChanged, ServerTime.Date, "yyyy-MM-dd")

            'TB_ClientBill.DataBindings.Add("Text", dtTable, TB_ClientBill.Name.Substring(3), False, DataSourceUpdateMode.OnPropertyChanged, "")
            TB_CBPS.DataBindings.Add("Text", dtTable, TB_CBPS.Name.Substring(3), False, DataSourceUpdateMode.OnPropertyChanged, "")
            'TB_Payed.DataBindings.Add("Text", dtTable, TB_Payed.Name.Substring(3), False, DataSourceUpdateMode.OnPropertyChanged, "")
            TB_sReason.DataBindings.Add("Text", dtTable, TB_sReason.Name.Substring(3), False, DataSourceUpdateMode.OnPropertyChanged, "")
            TB_YFCS.DataBindings.Add("Text", dtTable, TB_YFCS.Name.Substring(3), False, DataSourceUpdateMode.OnPropertyChanged, "")
            TB_CFCS.DataBindings.Add("Text", dtTable, TB_CFCS.Name.Substring(3), False, DataSourceUpdateMode.OnPropertyChanged, "")
            TB_sReason_ZG.DataBindings.Add("Text", dtTable, TB_sReason_ZG.Name.Substring(3), False, DataSourceUpdateMode.OnPropertyChanged, "")
            TB_YFCS_ZG.DataBindings.Add("Text", dtTable, TB_YFCS_ZG.Name.Substring(3), False, DataSourceUpdateMode.OnPropertyChanged, "")
            TB_CFCS_ZG.DataBindings.Add("Text", dtTable, TB_CFCS_ZG.Name.Substring(3), False, DataSourceUpdateMode.OnPropertyChanged, "")

            TB_Return_ID.DataBindings.Add("Text", dtTable, TB_Return_ID.Name.Substring(3), False, DataSourceUpdateMode.OnPropertyChanged, "")
            'TB_UnPayed.DataBindings.Add("Text", dtTable, TB_UnPayed.Name.Substring(3), True, DataSourceUpdateMode.OnPropertyChanged, 0, FormatSharp("money"))
            TB_SumQty.DataBindings.Add("Text", dtTable, TB_SumQty.Name.Substring(3), True, DataSourceUpdateMode.OnPropertyChanged, 0, FormatSharp("num"))
            TB_SumZL.DataBindings.Add("Text", dtTable, TB_SumZL.Name.Substring(3), True, DataSourceUpdateMode.OnPropertyChanged, 0, FormatSharp("money"))
            'TB_KZ.DataBindings.Add("Text", dtTable, TB_KZ.Name.Substring(3), False, DataSourceUpdateMode.OnPropertyChanged, "")
            'TB_FK.DataBindings.Add("Text", dtTable, TB_FK.Name.Substring(3), False, DataSourceUpdateMode.OnPropertyChanged, "")
            TB_LL_Count.DataBindings.Add("Text", dtTable, TB_LL_Count.Name.Substring(3), False, DataSourceUpdateMode.OnPropertyChanged, "")
            TB_JL_Count.DataBindings.Add("Text", dtTable, TB_JL_Count.Name.Substring(3), False, DataSourceUpdateMode.OnPropertyChanged, "")
            TB_SumAmount.DataBindings.Add("Text", dtTable, TB_SumAmount.Name.Substring(3), True, DataSourceUpdateMode.OnPropertyChanged, 0, FormatSharp("money"))
            TB_GH_State.DataBindings.Add("Tag", dtTable, TB_GH_State.Name.Substring(3), False, DataSourceUpdateMode.OnPropertyChanged, "")
            'TB_State_User.DataBindings.Add("Text", dtTable, TB_State_User.Name.Substring(3), False, DataSourceUpdateMode.OnPropertyChanged, "")
            TB_UPD_USER.DataBindings.Add("Text", dtTable, TB_UPD_USER.Name.Substring(3), False, DataSourceUpdateMode.OnPropertyChanged, "")
            TB_SH.DataBindings.Add("Text", dtTable, TB_SH.Name.Substring(3), False, DataSourceUpdateMode.OnPropertyChanged, "")
            TB_Modifier.DataBindings.Add("Text", dtTable, TB_Modifier.Name.Substring(3), False, DataSourceUpdateMode.OnPropertyChanged, "")
            IsBidings = True
        End If
        'CB_Prevent.IDValue = IsNull(dtTable.Rows(0)("Supplier_ID"), "0")
        'CB_Prevent.Text = CB_Prevent.GetByTextBoxTag
        'TB_Supplier_Name.Text = CB_Prevent.NameValue
        If IsNull(dt.Rows(0)("Banci"), False) = True Then
            RB_morning.Checked = True
        Else
            RB_even.Checked = True
        End If
        TB_GH_State.Text = BaseClass.ComFun.GetProduceStateName(IsNull(TB_GH_State.Tag, 0))
        DTP_sReason_Date.Value = IsNull(dt.Rows(0)("sReason_Date"), Today)
        DTP_YFCS_Date.Value = IsNull(dt.Rows(0)("YFCS_Date"), Today)
        DTP_CFCS_Date.Value = IsNull(dt.Rows(0)("CFCS_Date"), Today)
    End Sub

    Sub LockForm(ByVal Lock As Boolean)
        TB_ID.ReadOnly = Lock
        DTP_sDate.Enabled = Not Lock
        'Fg1.CanEditing = Not Lock
        'Fg1.IsClickStartEdit = Not Lock
        'CB_Prevent.Enabled = Not Lock
        TB_CFCS.ReadOnly = Lock
        'TB_Payed.ReadOnly = Lock
        TB_CBPS.ReadOnly = Lock
        TB_YFCS.ReadOnly = Lock
        TB_sReason.ReadOnly = Lock
        TB_sReason_ZG.ReadOnly = Lock
        TB_YFCS_ZG.ReadOnly = Lock
        TB_CFCS_ZG.ReadOnly = Lock
        DTP_sReason_Date.Enabled = Not Lock
        DTP_YFCS_Date.Enabled = Not Lock
        DTP_CFCS_Date.Enabled = Not Lock
    End Sub


    ''' <summary>
    ''' FG合计
    ''' </summary>
    ''' <remarks></remarks>
    'Protected Sub CaculateSumZL()
    '    If Fg1.Rows.Count <= 1 Then
    '        TB_SumQty.Text = 0
    '        TB_SumZL.Text = 0
    '        'TB_UnPayed.Text = 0
    '        Exit Sub
    '    End If
    '    Dim SumQty As Double = 0
    '    Dim SumZL As Double = 0
    '    For R As Integer = 1 To Fg1.Rows.Count - 1
    '        'Fg1.Item(R, "Amount") = Val(Fg1.Item(R, "Qty")) * Val(Fg1.Item(R, "Price"))
    '        SumZL = SumZL + Val(Fg1.Item(R, "ZL"))
    '        SumQty = SumQty + Val(Fg1.Item(R, "Qty"))
    '    Next
    '    TB_SumQty.Text = FormatNum(SumQty)
    '    TB_SumZL.Text = FormatMoney(SumZL)
    '    'TB_UnPayed.Text = FormatZL(SumZL - Val(TB_Payed.Text))
    'End Sub


#End Region

#Region "工具栏按钮"

    ''' <summary>
    ''' 保存按钮
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_Modify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Modify.Click
        ' Fg1.FinishEditing(False)
        If CB_NBZC.IDValue <> "" Then
            If CheckForm() Then
                If Mode = Mode_Enum.Add Then
                    If TB_Return_ID.Text = "" Then
                        ShowErrMsg("未做回修申请单或回修申请单未被审核!", AddressOf TB_GH.Focus)

                    Else
                        ShowConfirm("是否保存新" & Ch_Name & "?", AddressOf SaveGSSQ)
                    End If
                Else
                    If CheckIsModify() Then
                        ShowConfirm(Ch_Name & "[" & TB_ID.Text & "] 已经被其他人修改过,是否覆盖别人的修改?", AddressOf SaveGSSQ)
                    Else
                        ShowConfirm("是否保存" & Ch_Name & "[" & TB_ID.Text & "] 的修改?", AddressOf SaveGSSQ)
                    End If
                End If
            End If
        Else
            ShowErrMsg(Ch_Name & "改单信息不能为空!", AddressOf CB_NBZC.Focus)
        End If
    End Sub

    ''' <summary>
    ''' 保存修改
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub SaveGSSQ(Optional ByVal Audit As Boolean = False)
        If TB_Return_ID.Text = "" Then
            ShowErrMsg("未做回修申请单或回修申请单未被审核!", AddressOf TB_GH.Focus)
        Else
            Dim R As MsgReturn
            Dim Dt As DataTable = GetForm()
            If Audit Then
                Dt.Rows(0).Item("State_User") = User_Display
            End If
            If Me.Mode = Mode_Enum.Add Then
                R = Dao.GSSQ_Add(Dt, dtList)
            Else
                R = Dao.GSSQ_Save(LId, Dt, dtList)
            End If
            If R.IsOk Then
                LId = TB_ID.Text
                LastForm.ReturnId = TB_ID.Text
                Mode = Mode_Enum.Modify
                If Audit Then
                    Dim msg As MsgReturn = Dao.GSSQ_Audited(TB_ID.Text, True)
                    If msg.IsOk Then
                        Bill_ID = TB_ID.Text
                        Me_Refresh()
                        ShowOk(msg.Msg)
                    Else
                        ShowErrMsg("保存成功,但" & msg.Msg)
                    End If
                    Exit Sub
                End If
                If TB_ID.Text = Bill_ID.Replace("-", "") Then Bill_ID = ""
                ShowOk(R.Msg, True)
            Else
                ShowErrMsg(R.Msg)
            End If
        End If
    End Sub
    ''' <summary>
    ''' 验证信息
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Function CheckForm() As Boolean
        'CaculateSumZL()
        TB_ID.Text = TB_ID.Text.Trim
        TB_ID.Text = TB_ID.Text.Replace("'", "")
        If TB_ID.Text = "" Then
            ShowErrMsg(Ch_Name & "单号不能为空!", AddressOf TB_ID.Focus)
            Return False
        End If
        If (Mode = Mode_Enum.Add Or (Mode = Mode_Enum.Modify And LId <> TB_ID.Text)) AndAlso Dao.GSSQ_CheckID(TB_ID.Text) Then
            ShowErrMsg(Ch_Name & "单号[" & TB_ID.Text & "]已经存在!", AddressOf TB_ID.Focus)
            Return False
        End If

        'If (CB_Prevent.IDValue) = 0 Then
        '    ShowErrMsg("客户商编号或名称不能为空!", AddressOf CB_Prevent.Focus)
        '    Return False
        'End If


        'For i As Integer = Fg1.Rows.Count - 1 To 1 Step -1
        '    Try
        '        If Val(Fg1.Item(i, "Qty")) < 0 Then
        '            Fg1.Item(i, "Qty") = -Val(Fg1.Item(i, "Qty"))
        '        End If
        '        If Val(Fg1.Item(i, "Qty")) = 0 OrElse Val(Fg1.Item(i, "Amount")) = 0 OrElse Val(Fg1.Item(i, "WL_ID")) = 0 Then
        '            Fg1.RemoveItem(i)
        '        End If
        '    Catch ex As Exception
        '    End Try
        'Next

        'If Fg1.Rows.Count <= 1 Then
        '    Cmd_GoodsSel.Visible = False
        '    ShowErrMsg("列表不能为空!")
        '    Return False
        'End If

        'If Val(TB_UnPayed.Text) < 0 Then
        '    ShowErrMsg("付款不能多于单据金额!", AddressOf TB_UnPayed.Focus)
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

    'Private Sub CB_Store_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles CB_Store.SelectionChangeCommitted
    '    Fg1.Item(Fg1.RowSel, "Store_ID") = CB_Store.SelectedValue
    'End Sub

    'Private Sub CB_WL_Spec_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles CB_WL_Spec.SelectionChangeCommitted
    '    Dim Dr As DataRow = CB_WL_Spec.SelectedItem.row
    '    Me.ReturnObj = Dr
    '    SetGoods
    'End Sub

    'Private Sub Fg1_AfterEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs)
    '    If Fg1.ColSel = Fg1.Cols("GH").Index AndAlso Fg1.LastKey = Keys.Enter Then
    '        Fg1.LastKey = 0
    '        Dim gh As String = Fg1.Item(Fg1.RowSel, "GH")
    '        Dim s As String = ""
    '        s = gh.Replace("GY", "")
    '        s = s.Replace("-", "")
    '        gh = "GY" & s
    '        For i As Integer = 1 To Fg1.Rows.Count - 1
    '            If i <> Fg1.RowSel AndAlso gh = Fg1.Item(i, "GH") Then
    '                ShowErrMsg("缸号已存在!")
    '                Exit Sub
    '            End If
    '        Next
    '        Fg1.Item(Fg1.RowSel, "GH") = gh
    '        Dim msg As DtReturnMsg = Dao.BBGSSQ_GetById(gh)
    '        If msg.IsOk AndAlso msg.Dt.Rows.Count > 0 Then
    '            SetProduce(msg.Dt.Rows(0))
    '            If Fg1.Rows.Count <= 1 Then
    '                TB_SumQty.Text = 0
    '                TB_SumZL.Text = 0
    '                Exit Sub
    '            End If
    '            Dim SumQty As Double = 0
    '            Dim SumZL As Double = 0
    '            For R As Integer = 1 To Fg1.Rows.Count - 1
    '                SumZL = SumZL + Val(Fg1.Item(R, "ZL"))
    '                SumQty = SumQty + Val(Fg1.Item(R, "Qty"))
    '            Next
    '            TB_SumQty.Text = FormatNum(SumQty)
    '            TB_SumZL.Text = FormatMoney(SumZL)
    '        Else

    '            ShowErrMsg("没有找到对应的缸号[" & Fg1.Item(Fg1.RowSel, "GH") & "] 信息!", AddressOf FG_NoGH)

    '            'Fg1.Focus()
    '            'Fg1.StartEditing()
    '            'Fg1.StartEditing(e.Row, e.Col)
    '        End If
    '    End If

    '    'If e.Row < 0 Then
    '    '    Exit Sub
    '    'End If
    '    'If Fg1.LastKey = Keys.Enter Then
    '    '    Fg1.LastKey = 0
    '    '    Select Case Fg1.Cols(e.Col).Name
    '    '        Case "WL_No"
    '    '            GetWLByNo(Fg1.Item(Fg1.RowSel, Fg1.Cols(e.Col).Index))
    '    '        Case "Price", "Qty"
    '    '            Fg1.Item(e.Row, e.Col) = Val(Fg1.Item(e.Row, e.Col))
    '    '            CaculateSumZL()
    '    '            Fg1.GotoNextCell(e.Col)
    '    '        Case Else
    '    '            Fg1.GotoNextCell(e.Col)
    '    '    End Select
    '    'Else
    '    '    If Fg1.Cols(e.Col).Name = "WL_No" Then
    '    '        If Fg1.LastText <> Fg1.Item(Fg1.RowSel, Fg1.Cols(e.Col).Index) Then
    '    '            Fg1.Item(Fg1.RowSel, "WL_ID") = 0
    '    '            Fg1.Item(Fg1.RowSel, "WL_Name") = ""
    '    '            Fg1.Item(Fg1.RowSel, "WL_Unit") = ""
    '    '            Fg1.Item(Fg1.RowSel, "WL_Spec") = ""
    '    '        End If
    '    '    End If
    '    'End If
    'End Sub
    'Sub FG_NoGH()
    '    Fg1.Focus()
    '    Fg1.StartEditing()
    '    Fg1.StartEditing(Fg1.RowSel, Fg1.ColSel)
    'End Sub
    Sub SetProduce(ByVal dr As DataRow)
        If Not dr Is Nothing Then
            TB_Return_ID.Text = IsNull(dr("ID"), "")
            TB_LBZCName.Text = IsNull(dr("BZC_Name"), "")
            TB_LBZName.Text = IsNull(dr("BZ_Name"), "")
            TB_LBZC.Text = IsNull(dr("BZC_No"), "")
            TB_LBZ_No.Text = IsNull(dr("BZ_No"), "")
            TB_LCPName.Text = IsNull(dr("CPName"), "")
            TB_LClientBZC.Text = IsNull(dr("ClientBZC"), "")
            TB_LClient_Name.Text = IsNull(dr("Client_Name"), "")
            TB_LBZCName.Tag = IsNull(dr("BZC_ID"), "")
            TB_LBZName.Tag = IsNull(dr("BZ_ID"), "")
            TB_LClient_Name.Tag = IsNull(dr("Client_ID"), "")
            TB_LBZC_PF.Text = IsNull(dr("BZC_PF"), "")
            TB_LBzcMsg.Text = IsNull(dr("BzcMsg"), "")
            TB_LFK.Text = IsNull(dr("CR_BianDuiBian"), "")
            TB_LKZ.Text = IsNull(dr("CR_KeZhong"), "")

            TB_NCPName.Text = IsNull(dr("CPName"), "")
            TB_NClientBZC.Text = IsNull(dr("ClientBZC"), "")
            TB_NFK.Text = IsNull(dr("CR_BianDuiBian"), "")
            TB_NKZ.Text = IsNull(dr("CR_KeZhong"), "")
            TB_NClient_Name.Text = IsNull(dr("Client_Name"), "")

            TB_BZCID.Tag = IsNull(dr("BZC_ID"), "")
            TB_ClientID.Tag = IsNull(dr("Client_ID"), "")
            TB_BZID.Tag = IsNull(dr("BZ_ID"), "")
            TB_CPName.Text = IsNull(dr("CPName"), "")
            TB_ClientBZC.Text = IsNull(dr("ClientBZC"), "")
            TB_BZC_PF.Text = IsNull(dr("BZC_PF"), "")
            TB_BzcMsg.Text = IsNull(dr("BzcMsg"), "")
            TB_FK.Text = IsNull(dr("CR_BianDuiBian"), "")
            TB_KZ.Text = IsNull(dr("CR_KeZhong"), "")
        End If
    End Sub


    '''' <summary>
    ''''增行
    '''' </summary>
    '''' <param name="sender"></param>
    '''' <param name="e"></param>
    '''' <remarks></remarks>
    'Private Sub Cmd_AddRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    AddRow()
    'End Sub

    '''' <summary>
    '''' 增行
    '''' </summary>
    '''' <remarks></remarks>
    'Protected Sub AddRow()
    '    Fg1.AddRow()
    'End Sub

    '''' <summary>
    '''' 减行
    '''' </summary>
    '''' <param name="sender"></param>
    '''' <param name="e"></param>
    '''' <remarks></remarks>
    'Private Sub Cmd_RemoveRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Fg1.RemoveRow()
    'End Sub
    'Private Sub Fg1_NextCell(ByVal e As PClass.FG.NextCellEventArgs)
    '    Select Case e.Col
    '        Case "ZL"
    '            e.ToCol = Fg1.Cols("Qty").Index
    '        Case "Qty"

    '            If e.Row + 2 > Fg1.Rows.Count Then
    '                AddRow()
    '            End If
    '            e.ToRow = e.Row + 1
    '            e.ToCol = Fg1.Cols("Client_Name").Index

    '        Case Else
    '            e.ToCol = Fg1.Cols("Qty").Index
    '    End Select
    'End Sub

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
            ComFun.DelBillNewID(BillType.GSSQ, Bill_ID)
            Bill_Id_Date = #1/1/1999#
            GetNewID()
        End If
    End Sub

    Sub GetNewID()
        If TB_ID.ReadOnly = False Then
            If DTP_sDate.Value <> Bill_Id_Date Then
                Dim R As RetrunNewIdMsg = ComFun.GetBillNewID(BillType.GSSQ, DTP_sDate.Value, Bill_ID)
                If R.IsOk Then
                    Bill_Id_Date = R.NewIdDate
                    DTP_sDate.MinDate = R.MaxDate.AddDays(1)
                    DTP_sDate.Value = R.NewIdDate
                    Bill_ID = R.NewID
                    TB_ID.Text = Bill_ID.Replace("-", "")
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
        Dim R As New R30229_GSSQ_List
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
        'Fg1.FinishEditing(False)
        If CheckForm() Then
            TB_SH.Text = User_Display
            If Mode = Mode_Enum.Add Then
                ShowConfirm("是否保存并审核新" & Ch_Name & "?", AddressOf Shenhe)
            Else
                If CheckIsModify() Then
                    ShowConfirm(Ch_Name & "[" & TB_ID.Text & "] 已经被其他人修改过,是否覆盖别人的修改并且审核?", AddressOf Shenhe)
                Else
                    ShowConfirm("是否保存并审核" & Ch_Name & "[" & TB_ID.Text & "] ?", AddressOf Shenhe)
                End If
            End If
        End If
    End Sub
    Protected Sub Shenhe()
        SaveGSSQ(True)
    End Sub

    Private Sub Cmd_UnAudit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_UnAudit.Click
        ShowConfirm("是否反审" & Ch_Name & " [" & TB_ID.Text & "]?", AddressOf UnAudit)
    End Sub

    Protected Sub UnAudit()
        Dim msg As MsgReturn = Dao.GSSQ_Audited(TB_ID.Text, False)
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
        ShowConfirm("是否删除" & Ch_Name & " [" & TB_ID.Text & "]?", AddressOf DelGSSQ)
    End Sub

    ''' <summary>
    ''' 删除日报表
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub DelGSSQ()
        Dim msg As MsgReturn = Dao.GSSQ_Del(TB_ID.Text)
        If msg.IsOk Then
            LastForm.ReturnId = TB_ID.Text
            Me.Close()
        Else
            ShowErrMsg(msg.Msg)
        End If
    End Sub


    Private Sub Cmd_SetInValid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_SetInValid.Click
        ShowConfirm("是否作废" & Ch_Name & " [" & TB_ID.Text & "]?", AddressOf GSSQInValid)
    End Sub


    Sub GSSQInValid()
        Dim msg As MsgReturn = Dao.GSSQ_InValid(TB_ID.Text, True)
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
        ShowConfirm("是否反作废" & Ch_Name & " [" & TB_ID.Text & "]?", AddressOf GSSQValid)
    End Sub

    ''' <summary>
    ''' 作废
    ''' </summary>
    ''' <remarks></remarks>
    Sub GSSQValid()
        Dim msg As MsgReturn = Dao.GSSQ_InValid(TB_ID.Text, False)
        If msg.IsOk Then
            Me_Refresh()
            LastForm.ReturnId = TB_ID.Text
        Else
            ShowErrMsg(msg.Msg)
        End If
    End Sub


#End Region


#Region "检查其他人有没有修改过"
    Private LastLine As Integer = 0
    Private Function CheckIsModify() As Boolean
        If Mode <> Mode_Enum.Add Then
            Return Dao.GSSQ_CheckIsModify(LId, LastLine)
        End If
    End Function

#End Region


#Region "是否已付款"
    Private Sub CB_Supplier_Col_Sel(ByVal Col_No As String, ByVal Col_Name As String, ByVal ID As String)
        'TB_Supplier_Name.Text = Col_Name
    End Sub

    Private Sub Cmd_Payment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ' Fg1.FinishEditing(False)
        ShowConfirm(Ch_Name & " [" & TB_ID.Text & "]是否付款?", AddressOf SetPayment)
    End Sub

    Private Sub SetPayment()
        Dim msg As MsgReturn = Dao.GSSQ_Payment(TB_ID.Text, True)
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

    Private Sub UnPayment()
        Dim msg As MsgReturn = Dao.GSSQ_Payment(TB_ID.Text, False)
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


    Private Sub Cmd_UnPayment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ShowConfirm("是否取消" & Ch_Name & " [" & TB_ID.Text & "]的付款?", AddressOf UnPayment)
    End Sub

#End Region



    Private Sub TB_GH_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TB_GH.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim gh As String = TB_GH.Text
            Dim s As String = ""
            s = gh.Replace("GY", "")
            s = s.Replace("-", "")
            gh = "GY" & s
            Dim msg As DtReturnMsg = Dao.BBGSSQ_GetById(gh)
            If msg.IsOk AndAlso msg.Dt.Rows.Count > 0 Then
                SetProduce(msg.Dt.Rows(0))
                'If Fg1.Rows.Count <= 1 Then
                TB_SumQty.Text = 0
                TB_SumZL.Text = 0
                'Exit Sub
                'End If
                Dim SumQty As Double = 0
                Dim SumZL As Double = 0
                Dim SumAmount As Double = 0
                For R As Integer = 0 To msg.Dt.Rows.Count - 1
                    If IsNull(msg.Dt.Rows(R)("IsJiaLiao"), False) Then
                        TB_JL_Count.Text = IsNull(msg.Dt.Rows(R)("LL_Count"), 0)
                    Else
                        TB_LL_Count.Text = IsNull(msg.Dt.Rows(R)("LL_Count"), 0)
                    End If
                    SumAmount = SumAmount + IsNull(msg.Dt.Rows(R)("SumAmount"), 0)
                Next
                SumZL = IsNull(msg.Dt.Rows(0)("PB_ZLSum"), "")
                SumQty = IsNull(msg.Dt.Rows(0)("PB_CountSum"), "")
                TB_SumQty.Text = FormatNum(SumQty)
                TB_SumZL.Text = FormatMoney(SumZL)
                SetState(IsNull(msg.Dt.Rows(0)("State"), 0))
                TB_SumAmount.Text = FormatMoney(SumAmount)
                CB_NBZC.SearchType = cSearchType.ENum_SearchType.Client
                CB_NBZC.SearchID = IsNull(msg.Dt.Rows(0)("Client_ID"), "")
            Else
                ShowErrMsg("没有找到对应的缸号[" & TB_GH.Text & "] 信息!")
            End If
        End If
    End Sub

    Sub SetState(ByVal state As Enum_ProduceState)
        Me.TB_GH_State.Text = BaseClass.ComFun.GetProduceStateName(state)
        Me.TB_GH_State.Tag = state
    End Sub

    Private Sub CB_NBZC_Col_Sel(ByVal Col_No As String, ByVal Col_Name As String, ByVal ID As String) Handles CB_NBZC.Col_Sel
        TB_NBZCName.Text = Col_Name
        If ID IsNot Nothing AndAlso TB_GH.Text = "" Then
            Exit Sub
        End If
        CB_NBZ_No.SearchID = ID
        CB_NBZ_No.Enabled = True
        TB_NKZ.Enabled = True
        TB_NFK.Enabled = True
        Dim msgBz As DtReturnMsg = Dao.ProduceGd_GetBZListByBzcID(Val(ID))
        If msgBz.IsOk And msgBz.Dt.Rows.Count > 0 Then
            Dim msg As DtReturnMsg = Dao.ProduceGd_GetClientBZC(Val(ID), 0)
            If msg.IsOk And msg.Dt.Rows.Count > 0 Then
                If (TB_LBZCName.Tag).ToString <> ID Then
                    TB_BZCID.Tag = Val(TB_LBZCName.Tag)
                    TB_ClientID.Tag = Val(TB_LClient_Name.Tag)
                    TB_BZID.Tag = Val(TB_LBZName.Tag)
                    TB_CPName.Text = TB_LCPName.Text
                    TB_ClientBZC.Text = TB_LClientBZC.Text
                    TB_BZC_PF.Text = TB_LBZC_PF.Text
                    TB_BzcMsg.Text = TB_LBzcMsg.Text
                End If
                Dim Row As DataRow = msgBz.Dt.Select("Client_Bzc='" & IsNull(msg.Dt.Rows(0)("Client_Bzc"), "") & "'")(0)
                CB_NBZ_No.IDAsInt = IsNull(Row("BZ_ID"), 0)
                CB_NBZ_No.Text = CB_NBZ_No.GetByTextBoxTag()
                TB_NBZName.Tag = IsNull(Row("BZ_ID"), 0)
                CB_NBZC.IDValue = ID
                CB_NBZC.Text = Col_No
                TB_NBZName.Text = CB_NBZ_No.NameValue
            End If
        End If
        Dim msgClient As DtReturnMsg = Dao.ProduceGd_GetClientByBzcID(Val(ID))
        If msgClient.IsOk And msgClient.Dt.Rows.Count > 0 Then
            TB_NClient_Name.Text = IsNull(msgClient.Dt.Rows(0)("Client_Name"), "")
            TB_NClient_Name.Tag = IsNull(msgClient.Dt.Rows(0)("Client_ID"), "")
        End If
        LoadPF(ID)
        CB_NBZC_PF.Enabled = True
        CB_NBZC_PF.Focus()
        TB_NBzcMsg.Text = IIf(IsNull(TB_NClientBZC.Text, "") <> "" AndAlso Not (TB_NClientBZC.Text).ToString.Contains("#"), (TB_NClientBZC.Text) & "#", IsNull(TB_NClientBZC.Text, "")) & _
        (TB_NBZCName.Text) & vbCrLf & "GY-" & Format(Val(CB_NBZC.Text), "000000") & (CB_NBZC_PF.Text)
    End Sub

    Private Sub CB_NBZ_No_Col_Sel(ByVal Col_No As String, ByVal Col_Name As String, ByVal ID As String) Handles CB_NBZ_No.Col_Sel
        TB_NBZName.Text = Col_Name
        Dim msg As DtReturnMsg = Dao.ProduceGd_GetClientBZC(CB_NBZC.IDValue, ID)
        If msg.IsOk And msg.Dt.Rows.Count > 0 Then
            TB_NClientBZC.Text = IsNull(msg.Dt.Rows(0)("Client_Bzc"), "")
        Else
            TB_NClientBZC.Text = ""
        End If
    End Sub

    Private Sub LoadPF(ByVal BZC_ID As Integer)
        Dim R As DtReturnMsg = Dao.Produce_GetBZCPF(BZC_ID)
        Dim T As String = CB_NBZC_PF.Text
        If R.IsOk Then

            CB_NBZC_PF.DisplayMember = "PF_Name"
            CB_NBZC_PF.ValueMember = "PF_Name"
            Dim newDr As DataRow = R.Dt.NewRow
            newDr("PF_Name") = ""
            R.Dt.Rows.InsertAt(newDr, 0)
            CB_NBZC_PF.DataSource = R.Dt
        Else
            CB_NBZC_PF.DataSource = Nothing
        End If


        CB_NBZC_PF.Text = T
    End Sub

#Region "成品名"
    Private Sub CB_CPName_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CB_CPName.CheckedChanged
        If CB_CPName.Checked Then

            TB_NCPName.ReadOnly = False
        Else
            TB_NCPName.ReadOnly = True
        End If
    End Sub
#End Region

#Region "客户色号"
    Private Sub CB_ClientBZC_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CB_ClientBZC.CheckedChanged
        If CB_ClientBZC.Checked Then

            TB_NClientBZC.ReadOnly = False
        Else
            TB_NClientBZC.ReadOnly = True
        End If
    End Sub
#End Region


    Private Sub Cmd_ChooseReason_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmd_ChooseReason.Click
        ShowReasonList()
    End Sub

    Protected Sub ShowReasonList()
        Dim f As PClass.BaseForm = LoadFormIDToChild(10221, Me)
        If f Is Nothing Then Exit Sub
        f.P_F_RS_ID = TB_sReason.Text
        f.P_F_RS_ID2 = "/"

        Me.ReturnId = ""
        Me.ReturnObj = Nothing
        Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(f, Me)
        '  VF.Width = 800
        '  VF.Height = 400
        AddHandler VF.ClosedX, AddressOf setReason
        VF.Show()
    End Sub

    Sub setReason()
        If Me.ReturnMsg = "" Then
            Exit Sub
        End If

        Me.TB_sReason.Text = Me.ReturnMsg

        Me.ReturnMsg = ""
    End Sub

    Private Sub CB_NBZC_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CB_NBZC.SelectedIndexChanged

    End Sub
End Class

Partial Friend Class Dao
#Region "常量"
    Protected Friend Const GSSQ_DB_NAME As String = "改色申请单"
    ''' <summary>
    ''' 删除单据
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_GSSQ_DelByid As String = "Delete from T30229_GSSQ_Table  where ID=@ID and State=0"
    ''' <summary>
    ''' 获取单头
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_GSSQ_GetByid As String = "select top 1 * from T30229_GSSQ_Table  where ID=@ID"
    'Private Const SQL_GSSQ_GetByid As String = "select BL.*,BT.*,T.CR_BianDuiBian,T.CR_KeZhong,T.Client_Name,T.BZ_Name,T.BZC_Name,T.BZC_No ,Client_ID,BZ_ID,BZC_ID from T30230_GSSQ_List BL left join T30229_GSSQ_Table BT ON BL.ID=BT.ID left join (select P.CR_BianDuiBian,P.CR_KeZhong,P.GH,P.Client_ID,P.BZ_ID,P.BZC_ID,BZ_Name,BZC_Name,BZC_No,Client_Name from  T30000_Produce_Gd P  left join T10110_Client C on P.Client_ID=C.ID left join T10002_BZ BZ on P.BZ_ID=BZ.ID left join T10003_BZC BZC on P.BZC_ID=BZC.ID ) T on T.GH=BL.GH  where BL.ID=@ID"

    'Private Const SQL_GSSQ_SelByid As String = "select BL.*,T.CR_BianDuiBian,T.CR_KeZhong,T.Client_Name,T.BZ_Name,T.BZC_Name,T.BZC_No,BT.sReason,BT.YFCS,BT.YFCS_ZG,BT.YFCS_Date,BT.CFCS,BT.CFCS_ZG,BT.CFCS_Date,BT.CBPS,BT.sReason_ZG,BT.sReason_Date from T30230_GSSQ_List BL left join T30229_GSSQ_Table BT ON BL.ID=BT.ID left join (select P.CR_BianDuiBian,P.CR_KeZhong,P.GH,P.Client_ID,P.BZ_ID,P.BZC_ID,BZ_Name,BZC_Name,BZC_No,Client_Name from  T30000_Produce_Gd P  left join T10110_Client C on P.Client_ID=C.ID left join T10002_BZ BZ on P.BZ_ID=BZ.ID left join T10003_BZC BZC on P.BZC_ID=BZC.ID ) T on T.GH=BL.GH  where BL.ID=@ID"
    'Private Const SQL_GSSQ_SelByid As String = "select BL.*,BT.* ,P.CPName,P.BzcMsg,P.ClientBZC,Client_Name,BZ_Name,BZC_Name,BZC_No,BZ_No from T30230_GSSQ_List BL left join T30000_Produce_Gd P on P.GH=BL.GH left join T30229_GSSQ_Table BT ON BL.ID=BT.ID left join T10110_Client C on BL.LClient_ID=C.ID left join T10002_BZ BZ on BL.LBZ_ID=BZ.ID left join T10003_BZC BZC on BL.LBZC_ID=BZC.ID where BL.ID=@ID"
    Private Const SQL_GSSQ_SelByid As String = "select BL.*,BT.* ,BZ.BZ_Name  as BZ_Name,NBZ .BZ_Name as NBZ_Name,C.Client_Name as Client_Name,NC.Client_Name as NClient_Name,BZC.BZC_Name as BZC_Name,NBZC.BZC_Name  as NBZC_Name,BZC .BZC_No  AS BZC_No ,NBZC .BZC_No  AS NBZC_No ,BZ.BZ_No as BZ_No,NBZ.BZ_No  as NBZ_No,LClientBZC ,NClientBZC  from T30230_GSSQ_List BL left join T30229_GSSQ_Table BT ON BL.ID=BT.ID left join T10110_Client C on BL.Client_ID=C.ID left join T10110_Client NC on BL.LClient_ID=NC.ID left join T10002_BZ BZ on BL.BZ_ID=BZ.ID left join T10002_BZ NBZ on BL.LBZ_ID=NBZ.ID left join T10003_BZC BZC on BL.BZC_ID=BZC.ID left join T10003_BZC NBZC on BL.LBZC_ID=NBZC.ID where BL.ID=@ID"
    ''' <summary>
    ''' 获取单头 用于作废和审核
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_GSSQ_GetStateByid As String = "select top 1 ID,State,State_User from T30229_GSSQ_Table  where ID=@ID"
    ''' <summary>
    ''' 获取单体
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_GSSQ_GetListByid As String = "select * from T30230_GSSQ_List  where ID=@ID "
    ''' <summary>
    ''' 获取单体,用于显示
    ''' </summary>
    ''' <remarks></remarks>0
    Private Const SQL_GSSQ_SelListByid As String = "select BL.*,T.CR_BianDuiBian,T.CR_KeZhong,T.Client_Name,T.BZ_Name,T.BZC_Name,T.BZC_No from T30230_GSSQ_List BL left join (select P.CR_BianDuiBian,P.CR_KeZhong,P.GH,P.Client_ID,P.BZ_ID,P.BZC_ID,BZ_Name,BZC_Name,BZC_No,Client_Name from  T30000_Produce_Gd P  left join T10110_Client C on P.Client_ID=C.ID left join T10002_BZ BZ on P.BZ_ID=BZ.ID left join T10003_BZC BZC on P.BZC_ID=BZC.ID ) T on T.GH=BL.GH where BL.ID=@ID"

    'Private Const SQL_GSSQ_SelListByid As String = " select * from T30226_GSSQ_List BL  left join T10002_BZ BZ on BL.BZ_ID=BZ.ID where ID=@ID "
    ''' 检查ID的重复性
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_GSSQ_CheckID As String = "select * from T30229_GSSQ_Table  where ID=@ID"
    ''' <summary>
    ''' 检查ID的重复性
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_GSSQ_CheckIsModify As String = "select count(*) from T30230_GSSQ_List  where @ID=ID and Line=@Line"
    ''' <summary>
    ''' 获取改色申请单信息
    ''' </summary>
    ''' <remarks></remarks>
    Public Const SQL_BBGSSQ_GetByID_WithName As String = "select P.*,R.ID,C.Client_Name,BZ.BZ_Name,BZC.BZC_Name,BZC.BZC_No,L.*,BZ.BZ_No from T30000_Produce_Gd P  left join ( select top(1) ID,GH  from T30231_RetrunInform where id=(select max(id) from T30231_RetrunInform where State=1 and GH=@GH and State=1)) R on p.GH =R.GH left join T10110_Client C on P.Client_ID=C.ID left join T10002_BZ BZ on P.BZ_ID=BZ.ID left join T10003_BZC BZC on P.BZC_ID=BZC.ID left join (SELECT  COUNT (Produce_ID) as LL_Count,sum (SumAmount) as SumAmount,Produce_ID, IsJiaLiao FROM T20310_LingLiao_Table where Produce_ID =@GH group by Produce_ID, IsJiaLiao) L on p.GH=L.Produce_ID   where P.GH=@GH  "


#End Region


#Region "单一张单内容查询"
    ''' <summary>
    ''' 获取对日报表信息
    ''' </summary>
    ''' <param name="sId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GSSQ_GetById(ByVal sId As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_GSSQ_GetByid, "@ID", sId)
    End Function

    ''' <summary>
    ''' 获取对日报表列表信息
    ''' </summary>
    ''' <param name="sId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GSSQ_SelListById(ByVal sId As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_GSSQ_SelListByid, "@ID", sId)
    End Function
#End Region



#Region "添加修改删除"

    ''' <summary>
    ''' 检查其他人有没有修改过
    ''' </summary>
    ''' <param name="ID"></param>
    ''' <param name="Line"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GSSQ_CheckIsModify(ByVal ID As String, ByVal Line As Integer) As Boolean
        Dim P As New Dictionary(Of String, Object)
        P.Add("ID", ID)
        P.Add("Line", Line)
        Dim R As MsgReturn = SqlStrToOneStr(SQL_GSSQ_CheckIsModify, P)
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
    Public Shared Function GSSQ_CheckID(ByVal ID As String) As Boolean
        Dim R As MsgReturn = SqlStrToOneStr(SQL_GSSQ_CheckID, "@ID", ID)
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
    ''' <param name="dtList"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GSSQ_Add(ByVal dtTable As DataTable, ByVal dtList As DataTable) As MsgReturn
        Dim msg As New DtListReturnMsg
        Dim R As New MsgReturn
        Dim sqlMap As New Dictionary(Of String, String)
        Dim paraMap As New Dictionary(Of String, Object)
        Dim GSSQId As String = dtTable.Rows(0)("ID")
        Dim IsInsert As Boolean = False
        paraMap.Add("ID", GSSQId)
        Try
            sqlMap.Add("Table", SQL_GSSQ_GetByid)
            sqlMap.Add("List", SQL_GSSQ_GetListByid)
            'Dim il As New List(Of String)
            'il.Add("BZ_ID")
            'il.Add("BZC_ID")
            'il.Add("Client_ID")
            msg = SqlStrToDt(sqlMap, paraMap)
            If msg.DtList("Table").Rows.Count = 0 Then
                DvToDt(dtTable, msg.DtList("Table"), New List(Of String), True)
                DvToDt(dtList, msg.DtList("List"), New List(Of String), True)
                Dim TmSQL As String = "insert into Bill_Barcode (No_ID,NO_Type)values('" & GSSQId & "'," & BillType.GSSQ & ")"
                DtToUpDate(msg, TmSQL)
                R.Msg = "" & GSSQ_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]添加成功!"
                R.IsOk = True
            Else
                R.IsOk = False
                R.Msg = "" & GSSQ_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]已经存在!请双击编号文本框,获取新编号!"
            End If
            Return R
        Catch ex As Exception
            R.IsOk = False
            R.Msg = "" & GSSQ_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]添加错误!"
            DebugToLog(ex)
            Return R
        Finally
        End Try
    End Function

    ''' <summary>
    ''' 修改改色申请表
    ''' </summary>
    ''' <param name="dtTable"></param>
    ''' <param name="dtList"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GSSQ_Save(ByVal LID As String, ByVal dtTable As DataTable, ByVal dtList As DataTable) As MsgReturn
        Dim msg As New DtListReturnMsg
        Dim R As New MsgReturn
        Dim sqlMap As New Dictionary(Of String, String)
        Dim paraMap As New Dictionary(Of String, Object)
        Dim GSSQId As String = dtTable.Rows(0)("ID")
        If LID <> GSSQId AndAlso GSSQ_CheckID(GSSQId) Then
            R.IsOk = False
            R.Msg = "" & GSSQ_DB_NAME & "[" & GSSQId & "]已经存在!请双击编号文本框,获取新编号!"
            Return R
        End If
        dtTable.Rows(0)("ID") = LID
        paraMap.Add("ID", LID)
        Try
            sqlMap.Add("Table", SQL_GSSQ_GetByid)
            sqlMap.Add("List", SQL_GSSQ_GetListByid)
            msg = SqlStrToDt(sqlMap, paraMap)
            If msg.DtList("Table").Rows.Count = 1 Then
                If msg.DtList("Table").Rows(0)("State") = Enum_State.Audited Then
                    msg.DaList("Table").Dispose()
                    msg.DaList("List").Dispose()
                    msg.Cnn.Dispose()
                    R.IsOk = False
                    R.Msg = "" & GSSQ_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]已经被审核不能再修改!"
                    Return R
                End If
                If msg.DtList("Table").Rows(0)("State") = Enum_State.Invoid Then
                    msg.DaList("Table").Dispose()
                    msg.DaList("List").Dispose()
                    msg.Cnn.Dispose()
                    R.IsOk = False
                    R.Msg = "" & GSSQ_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]已经被作废不能再修改!"
                    Return R
                End If
                DvToDt(dtList, msg.DtList("List"), New List(Of String))
                DvUpdateToDt(dtTable, msg.DtList("Table"), New List(Of String))
                Dim TmSQL As String = "Update Bill_Barcode set No_ID='" & GSSQId & "' where No_ID='" & LID & "' and NO_Type=" & BillType.GSSQ
                If LID <> GSSQId Then
                    DtToUpDate(msg, "Update T30229_GSSQ_Table set id='" & GSSQId & "' where id='" & LID & "'" & vbCrLf & TmSQL)
                    dtTable.Rows(0)("ID") = GSSQId
                    R.Msg = "" & GSSQ_DB_NAME & "[" & LID & "]已经修改为[" & GSSQId & "]!"
                Else
                    DtToUpDate(msg)
                    R.Msg = "" & GSSQ_DB_NAME & "[" & LID & "]修改成功!"
                End If
                R.IsOk = True
            Else
                R.IsOk = False
                R.Msg = "" & GSSQ_DB_NAME & "[" & LID & "]不存在"
            End If
            Return R
        Catch ex As Exception
            R.IsOk = False
            R.Msg = "" & GSSQ_DB_NAME & "[" & LID & "]修改错误"
            DebugToLog(ex)
            Return R
        Finally
        End Try
    End Function

    ''' <summary>
    ''' 删除日报表
    ''' </summary>
    ''' <param name="GSSQId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GSSQ_Del(ByVal GSSQId As String)
        Return RunSQL(SQL_GSSQ_DelByid, "@ID", GSSQId)
    End Function

    ''' <summary>
    ''' 作废日报表
    ''' </summary>
    ''' <param name="_ID"></param>
    ''' <param name="IsFei">作废还是反作废</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GSSQ_InValid(ByVal _ID As String, ByVal IsFei As Boolean) As MsgReturn
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
            sqlMap.Add("Table", SQL_GSSQ_GetStateByid)
            msg = SqlStrToDt(sqlMap, paraMap)
            If msg.DtList("Table").Rows.Count = 1 Then
                If msg.DtList("Table").Rows(0)("State") <> Enum_State.Audited Then
                    If msg.DtList("Table").Rows(0)("State") <> State Then
                        msg.DtList("Table").Rows(0)("State") = State
                        msg.DtList("Table").Rows(0)("State_User") = User_Display
                        DtToUpDate(msg)
                        R.IsOk = True
                        R.Msg = "" & GSSQ_DB_NAME & "[" & _ID & "]" & OStr & "成功!"
                    Else
                        R.IsOk = False
                        R.Msg = "" & GSSQ_DB_NAME & "[" & _ID & "]已经被" & OStr & "!不能再" & OStr & "!"
                    End If
                Else
                    R.IsOk = False
                    R.Msg = "" & GSSQ_DB_NAME & "[" & _ID & "]已经被审核,不能" & OStr & "!"
                End If
            Else
                R.IsOk = False
                R.Msg = "" & GSSQ_DB_NAME & "[" & _ID & "]不存在,不能" & OStr & "!"
            End If
            Return R
        Catch ex As Exception
            R.IsOk = False
            R.Msg = "" & GSSQ_DB_NAME & "[" & _ID & "]" & OStr & "错误!"
            DebugToLog(ex)
            Return R
        Finally
        End Try
    End Function
    ''' <summary>
    ''' 审核改色申请单
    ''' </summary>
    ''' <param name="_ID"></param>
    ''' <param name="IsAudited">审核还是反审核</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GSSQ_Audited(ByVal _ID As String, ByVal IsAudited As Boolean) As MsgReturn
        Dim R As MsgReturn
        Dim s As String = IIf(IsAudited, "审核", "反审核")
        Dim state As Integer = IIf(IsAudited, 1, 0)

        Dim paraMap As New Dictionary(Of String, Object)
        paraMap.Add("ID", _ID)
        paraMap.Add("IsAudited", IsAudited)
        paraMap.Add("State_User", User_Display)

        Dim msg As DtReturnMsg = SqlStrToDt("select state from  T30229_GSSQ_Table where ID=@ID  ", "ID", _ID)
        If msg.IsOk AndAlso msg.Dt.Rows.Count > 0 AndAlso IsNull(msg.Dt.Rows(0)("State"), False) = state Then
            R = New MsgReturn
            R.Msg = GSSQ_DB_NAME & s & "失败！[" & _ID & "]已被" & s
            Return R
        End If

        Dim msgsql As DtReturnMsg = SqlStrToDt("select * from T30230_GSSQ_List where ID=@ID", "ID", _ID)
        If msgsql.IsOk AndAlso msgsql.Dt.Rows.Count > 0 AndAlso IsAudited Then
            R = New MsgReturn
            Dim p As New Dictionary(Of String, Object)
            p.Add("GH", msgsql.Dt.Rows(0)("GH"))
            p.Add("BZ_ID", msgsql.Dt.Rows(0)("LBZ_ID"))
            p.Add("BZC_ID", msgsql.Dt.Rows(0)("LBZC_ID"))
            p.Add("Client_ID", msgsql.Dt.Rows(0)("LClient_ID"))
            p.Add("BZC_PF", msgsql.Dt.Rows(0)("LBZC_PF"))
            p.Add("ClientBZC", msgsql.Dt.Rows(0)("LClientBZC"))
            p.Add("BzcMsg", msgsql.Dt.Rows(0)("LBzcMsg"))
            p.Add("CPName", msgsql.Dt.Rows(0)("LCPName"))
            p.Add("CR_BianDuiBian", msgsql.Dt.Rows(0)("LFK"))
            p.Add("CR_KeZhong", msgsql.Dt.Rows(0)("LKZ"))
            R = SqlStrToOneStr("Update T30000_Produce_Gd set BZ_ID=@BZ_ID,BZC_ID=@BZC_ID,Client_ID=@Client_ID,BZC_PF=@BZC_PF,ClientBZC=@ClientBZC,BzcMsg=@BzcMsg,CPName=@CPName ,CR_BianDuiBian=@CR_BianDuiBian ,CR_KeZhong=@CR_KeZhong where GH=@GH", p)
        Else
            R = New MsgReturn
            Dim p As New Dictionary(Of String, Object)
            p.Add("GH", msgsql.Dt.Rows(0)("GH"))
            p.Add("BZ_ID", msgsql.Dt.Rows(0)("BZ_ID"))
            p.Add("BZC_ID", msgsql.Dt.Rows(0)("BZC_ID"))
            p.Add("Client_ID", msgsql.Dt.Rows(0)("Client_ID"))
            p.Add("BZC_PF", msgsql.Dt.Rows(0)("BZC_PF"))
            p.Add("ClientBZC", msgsql.Dt.Rows(0)("ClientBZC"))
            p.Add("BzcMsg", msgsql.Dt.Rows(0)("BzcMsg"))
            p.Add("CPName", msgsql.Dt.Rows(0)("CPName"))
            p.Add("CR_BianDuiBian", msgsql.Dt.Rows(0)("FK"))
            p.Add("CR_KeZhong", msgsql.Dt.Rows(0)("KZ"))
            R = SqlStrToOneStr("Update T30000_Produce_Gd set BZ_ID=@BZ_ID,BZC_ID=@BZC_ID,Client_ID=@Client_ID,BZC_PF=@BZC_PF,ClientBZC=@ClientBZC,BzcMsg=@BzcMsg,CPName=@CPName ,CR_BianDuiBian=@CR_BianDuiBian,CR_KeZhong=@CR_KeZhong where GH=@GH", p)
        End If
        R = SqlStrToOneStr("Update T30229_GSSQ_Table set State=@IsAudited,State_User=@State_User where ID=@ID  ", paraMap)

        If R.IsOk Then
            R.Msg = GSSQ_DB_NAME & s & "成功！"
        Else
            R.Msg = GSSQ_DB_NAME & s & "失败！" & R.Msg

        End If

        Return R
    End Function


    '''' <summary>
    '''' 审核日报表
    '''' </summary>
    '''' <param name="_ID"></param>
    '''' <param name="IsAudited">审核还是反审核</param>
    '''' <returns></returns>
    '''' <remarks></remarks>
    'Public Shared Function GSSQ_Audited(ByVal _ID As String, ByVal IsAudited As Boolean) As MsgReturn
    '    Dim paraMap As New Dictionary(Of String, Object)
    '    paraMap.Add("ID", _ID)
    '    paraMap.Add("IsAudited", IsAudited)
    '    paraMap.Add("State_User", User_Display)
    '    Dim R As MsgReturn = SqlStrToOneStr("", paraMap, True)
    '    If R.IsOk Then
    '        If R.Msg.StartsWith("1") Then
    '            R.IsOk = True
    '        Else
    '            R.IsOk = False
    '        End If
    '        R.Msg = R.Msg.Substring(1)
    '    End If
    '    Return R
    'End Function



    ''' <summary>
    ''' 付款
    ''' </summary>
    ''' <param name="_ID"></param>
    ''' <param name="IsPayment">付款还是未付款</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GSSQ_Payment(ByVal _ID As String, ByVal IsPayment As Boolean) As MsgReturn
        Dim paraMap As New Dictionary(Of String, Object)
        paraMap.Add("ID", _ID)
        paraMap.Add("IsPayment", IsPayment)
        Dim R As MsgReturn = SqlStrToOneStr("Update T20000_Puchase_Table set Payment=@IsPayment where ID=@ID  ", paraMap)
        Dim s As String = IIf(IsPayment, "付款", "未付款")
        If R.IsOk Then
            R.Msg = GSSQ_DB_NAME & s & "成功！"
        Else
            R.Msg = GSSQ_DB_NAME & s & "失败！" & R.Msg

        End If

        Return R
    End Function

    ''' <summary>
    ''' 获取运转单信息
    ''' </summary>
    ''' <param name="sId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function BBGSSQ_GetById(ByVal sId As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_BBGSSQ_GetByID_WithName, "@GH", sId)
    End Function













#End Region
End Class