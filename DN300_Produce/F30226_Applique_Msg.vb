Option Compare Text
Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports PClass
Imports BaseClass
Imports PClass.CReport

Public Class F30226_Applique_Msg
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

    Private Sub Me_AfterLoad() Handles Me.AfterLoad
        If Fg1.Rows.Count > 1 Then
            Fg1.RowSel = 1
            Fg1.Row = 1
            Fg1.Select(1, Fg1.Cols("GH").Index, 1, Fg1.Cols("GH").Index)
        End If
    End Sub

    Private Sub Me_Form_KeyDown(ByVal sender As Object, ByRef e As System.Windows.Forms.KeyEventArgs) Handles Me.Form_KeyDown
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
        Control_CheckRight(ID, ClassMain.Modify, Cmd_Modify)
        Control_CheckRight(ID, ClassMain.Del, Cmd_Del)
        Control_CheckRight(ID, ClassMain.Audited, Cmd_Audit)
        Control_CheckRight(ID, ClassMain.UnAudit, Cmd_UnAudit)
        Control_CheckRight(ID, ClassMain.SetInValid, Cmd_SetInValid)
        Control_CheckRight(ID, ClassMain.SetValid, Cmd_SetValid)
    End Sub

    Private Sub Form_Me_Closing(ByVal sender As Object, ByRef e As System.ComponentModel.CancelEventArgs) Handles Me.Me_Closing
        ComFun.DelBillNewID(BillType.Applique, Bill_ID)
    End Sub

    Private Sub Form_Load() Handles Me.Me_Load
        ID = 30228
        FormCheckRight()
        Ch_Name = GetBillTypeName(ID)
        'Dao.Balance_DB_NAME = Ch_Name
        Me.Title = Ch_Name

        If Bill_ID = "" AndAlso P_F_RS_ID <> "" Then
            Bill_ID = P_F_RS_ID
        End If

        Fg1.IniFormat()
        Me_Refresh()
        '    Dim T As New Threading.Thread(AddressOf GetDtMsg)
        '   T.Start()
    End Sub

    Protected Sub Me_Refresh()
        Dim msgTable As DtReturnMsg = Dao.Applique_GetById(Bill_ID)
        If msgTable.IsOk Then
            If IsBidings Then
                DvUpdateToDt(msgTable.Dt, dtTable, New List(Of String))
            Else
                dtTable = msgTable.Dt
            End If
            If Mode = Mode_Enum.Modify AndAlso msgTable.Dt.Rows.Count = 0 Then
                ShowErrMsg("没有找到" & Dao.Applique_DB_NAME & "[" & Bill_ID & "]", True)
                Exit Sub
            End If
            SetForm(dtTable)
        End If
        Select Case Mode
            Case Mode_Enum.Add
                If CheckRight(ID, ClassMain.Add) = False Then Me.ShowErrMsg("没有权限添加" & Dao.Applique_DB_NAME & "!", True) : Exit Sub
                Dim msg As DtReturnMsg = Dao.Applique_SelById(0)
                If msg.IsOk Then dtList = msg.Dt
                Fg1.Rows.Count = 2
                Fg1.ReAddIndex()
                TB_UPD_USER.Text = User_Display
                LabelTitle.Text = "新建" & Me.Ch_Name
                Cmd_Preview.Enabled = False
                Cmd_Print.Enabled = False
                DTP_sDate.Value = GetDate()
                GetNewID()
            Case Mode_Enum.Modify
                Cmd_Preview.Enabled = True
                Cmd_Print.Enabled = True
                Dim msg As DtReturnMsg = Dao.Applique_SelById(Bill_ID)
                If msg.IsOk Then
                    dtList = msg.Dt
                    'LastLine = msg.Dt.Rows(0)("Line")
                    Fg1.DtToSetFG(msg.Dt)
                End If
                LId = TB_ID.Text
                LabelTitle.Text = "修改" & Me.Ch_Name
        End Select
        CaculateSumZL()
        dtTable.AcceptChanges()
        dtList.AcceptChanges()



    End Sub

    'Sub GetDtMsg()
    '    StoreDt = ComFun.GetStoreDt()
    '    CB_Store.DataSource = StoreDt
    'End Sub

#Region "表单控件事件"
    Private Sub TB_Payed_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TB_Payed.Validating
        TB_Payed.Text = Val(TB_Payed.Text)
        CaculateSumZL()
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
        'dr("Supplier_ID") = CB_Prevent.IDValue
        dr("State") = State
        dr("Reason_Date") = DTP_Reason_Date.Value
        dr("YFCS_Date") = DTP_YFCS_Date.Value
        dr("CFCS_Date") = DTP_CFCS_Date.Value

        'dr("Payed") = dr("SumZL") - IsNull(dr("UnPayed"), 0)
        dt.AcceptChanges()
        dtList = dtList.Clone
        For i As Integer = 1 To Fg1.Rows.Count - 1
            dr = dtList.NewRow
            dr("ID") = ID
            dr("GH") = Fg1.Item(i, "GH")
            'dr("BZ_Name") = Fg1.Item(i, "BZ_Name")
            'dr("BZC_No") = Fg1.Item(i, "BZC_No")
            'dr("BZC_Name") = Fg1.Item(i, "BZC_Name")
            dr("Qty") = Fg1.Item(i, "Qty")
            dr("ZL") = Fg1.Item(i, "ZL")
            'dr("Client_Name") = Fg1.Item(i, "Client_Name")
            dtList.Rows.Add(dr)
        Next
        dtList.AcceptChanges()
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
        If IsBidings = False Then dt.Columns.Add("UnPayed", GetType(Double))
        Dim Dr As DataRow
        If dt.Rows.Count = 0 Then
            Dr = dt.NewRow
            Dr("UnPayed") = 0
            Dr("State_User") = ""
            'Dr("ZL") = ""
            'Dr("ClientBill") = ""
            Dr("Remark") = ""
            Dr("ID") = ""
            Dr("sDate") = ServerTime.Date
            Dr("SumZL") = 0
            'Dr("Payed") = Dr("SumZL") - Dr("UnPayed")

            Cmd_Audit.Visible = Cmd_Audit.Tag
            Cmd_Audit.Enabled = True
            Cmd_UnAudit.Visible = False
            Cmd_UnAudit.Enabled = False

            Cmd_SetValid.Visible = False
            Cmd_SetValid.Enabled = False
            Cmd_SetInValid.Visible = Cmd_SetInValid.Tag
            Cmd_SetInValid.Enabled = False
            Cmd_Del.Visible = False
            'Cmd_Payment.Visible = False
            Cmd_UnPayment.Visible = False

            'LabelPayment.Visible = False
            LabelState.Text = "新建"
            LabelState.ForeColor = Color.Black
            dt.Rows.Add(Dr)
            dt.AcceptChanges()
            LockForm(False)
        Else
            Dr = dt.Rows(0)
            State = Dr("State")
            'Payment = IsNull(Dr("Payment"), False)
            'LabelPayment.Visible = True
            'If Payment Then
            '    LabelPayment.Text = "已付款"
            '    'Cmd_Payment.Enabled = False
            '    Cmd_UnPayment.Enabled = True
            'Else
            '    LabelPayment.Text = "未付款"
            '    'Cmd_Payment.Enabled = True
            '    Cmd_UnPayment.Enabled = False
            'End If
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



                    Cmd_SetValid.Visible = False
                    Cmd_SetValid.Enabled = False
                    Cmd_SetInValid.Visible = Cmd_SetInValid.Tag
                    Cmd_SetInValid.Enabled = False
                    LockForm(True)
            End Select
        End If
        If IsBidings = False Then



            TB_ID.DataBindings.Add("Text", dtTable, TB_ID.Name.Substring(3), False, DataSourceUpdateMode.OnPropertyChanged)
            DTP_sDate.DataBindings.Add("Value", dtTable, DTP_sDate.Name.Substring(4), False, DataSourceUpdateMode.OnPropertyChanged, ServerTime.Date, "yyyy-MM-dd")
            'DTP_Reason_Date.DataBindings.Add("Value", dtTable, DTP_Reason_Date.Name.Substring(4), False, DataSourceUpdateMode.OnPropertyChanged, ServerTime.Date, "yyyy-MM-dd")
            'DTP_YFCS_Date.DataBindings.Add("Value", dtTable, DTP_YFCS_Date.Name.Substring(4), False, DataSourceUpdateMode.OnPropertyChanged, ServerTime.Date, "yyyy-MM-dd")
            'DTP_CFCS_Date.DataBindings.Add("Value", dtTable, DTP_CFCS_Date.Name.Substring(4), False, DataSourceUpdateMode.OnPropertyChanged, ServerTime.Date, "yyyy-MM-dd")

            'TB_ClientBill.DataBindings.Add("Text", dtTable, TB_ClientBill.Name.Substring(3), False, DataSourceUpdateMode.OnPropertyChanged, "")
            TB_CBPS.DataBindings.Add("Text", dtTable, TB_CBPS.Name.Substring(3), False, DataSourceUpdateMode.OnPropertyChanged, "")
            'TB_Payed.DataBindings.Add("Text", dtTable, TB_Payed.Name.Substring(3), False, DataSourceUpdateMode.OnPropertyChanged, "")
            TB_Reason.DataBindings.Add("Text", dtTable, TB_Reason.Name.Substring(3), False, DataSourceUpdateMode.OnPropertyChanged, "")
            TB_YFCS.DataBindings.Add("Text", dtTable, TB_YFCS.Name.Substring(3), False, DataSourceUpdateMode.OnPropertyChanged, "")
            TB_CFCS.DataBindings.Add("Text", dtTable, TB_CFCS.Name.Substring(3), False, DataSourceUpdateMode.OnPropertyChanged, "")
            TB_Reason_ZG.DataBindings.Add("Text", dtTable, TB_Reason_ZG.Name.Substring(3), False, DataSourceUpdateMode.OnPropertyChanged, "")
            TB_YFCS_ZG.DataBindings.Add("Text", dtTable, TB_YFCS_ZG.Name.Substring(3), False, DataSourceUpdateMode.OnPropertyChanged, "")
            TB_CFCS_ZG.DataBindings.Add("Text", dtTable, TB_CFCS_ZG.Name.Substring(3), False, DataSourceUpdateMode.OnPropertyChanged, "")


            'TB_UnPayed.DataBindings.Add("Text", dtTable, TB_UnPayed.Name.Substring(3), True, DataSourceUpdateMode.OnPropertyChanged, 0, FormatSharp("money"))
            TB_SumQty.DataBindings.Add("Text", dtTable, TB_SumQty.Name.Substring(3), True, DataSourceUpdateMode.OnPropertyChanged, 0, FormatSharp("num"))
            TB_SumZL.DataBindings.Add("Text", dtTable, TB_SumZL.Name.Substring(3), True, DataSourceUpdateMode.OnPropertyChanged, 0, FormatSharp("money"))

            'TB_State_User.DataBindings.Add("Text", dtTable, TB_State_User.Name.Substring(3), False, DataSourceUpdateMode.OnPropertyChanged, "")
            TB_UPD_USER.DataBindings.Add("Text", dtTable, TB_UPD_USER.Name.Substring(3), False, DataSourceUpdateMode.OnPropertyChanged, "")

            IsBidings = True
        End If
        'CB_Prevent.IDValue = IsNull(dtTable.Rows(0)("Supplier_ID"), "0")
        CB_Prevent.Text = CB_Prevent.GetByTextBoxTag
        TB_Supplier_Name.Text = CB_Prevent.NameValue
        DTP_Reason_Date.Value = IsNull(dt.Rows(0)("Reason_Date"), Today)
        DTP_YFCS_Date.Value = IsNull(dt.Rows(0)("YFCS_Date"), Today)
        DTP_CFCS_Date.Value = IsNull(dt.Rows(0)("CFCS_Date"), Today)
    End Sub

    Sub LockForm(ByVal Lock As Boolean)
        TB_ID.ReadOnly = Lock
        DTP_sDate.Enabled = Not Lock
        Fg1.CanEditing = Not Lock
        Fg1.IsClickStartEdit = Not Lock
        CB_Prevent.Enabled = Not Lock
        TB_CFCS.ReadOnly = Lock
        TB_Payed.ReadOnly = Lock
        TB_CBPS.ReadOnly = Lock
        TB_YFCS.ReadOnly = Lock
        TB_Reason.ReadOnly = Lock
        TB_Reason_ZG.ReadOnly = Lock
        TB_YFCS_ZG.ReadOnly = Lock
        TB_CFCS_ZG.ReadOnly = Lock
        DTP_Reason_Date.Enabled = Not Lock
        DTP_YFCS_Date.Enabled = Not Lock
        DTP_CFCS_Date.Enabled = Not Lock
        Cmd_AddRow.Enabled = Not Lock
        Cmd_RemoveRow.Enabled = Not Lock
    End Sub


    ''' <summary>
    ''' FG合计
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub CaculateSumZL()
        If Fg1.Rows.Count <= 1 Then
            TB_SumQty.Text = 0
            TB_SumZL.Text = 0
            'TB_UnPayed.Text = 0
            Exit Sub
        End If
        Dim SumQty As Double = 0
        Dim SumZL As Double = 0
        For R As Integer = 1 To Fg1.Rows.Count - 1
            'Fg1.Item(R, "Amount") = Val(Fg1.Item(R, "Qty")) * Val(Fg1.Item(R, "Price"))
            SumZL = SumZL + Val(Fg1.Item(R, "ZL"))
            SumQty = SumQty + Val(Fg1.Item(R, "Qty"))
        Next
        TB_SumQty.Text = FormatNum(SumQty)
        TB_SumZL.Text = FormatMoney(SumZL)
        'TB_UnPayed.Text = FormatZL(SumZL - Val(TB_Payed.Text))
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
                ShowConfirm("是否保存新" & Ch_Name & "?", AddressOf SaveApplique)
            Else
                If CheckIsModify() Then
                    ShowConfirm(Ch_Name & "[" & TB_ID.Text & "] 已经被其他人修改过,是否覆盖别人的修改?", AddressOf SaveApplique)
                Else
                    ShowConfirm("是否保存" & Ch_Name & "[" & TB_ID.Text & "] 的修改?", AddressOf SaveApplique)
                End If
            End If
        End If
    End Sub

    ''' <summary>
    ''' 保存修改
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub SaveApplique(Optional ByVal Audit As Boolean = False)
        Dim R As MsgReturn
        Dim Dt As DataTable = GetForm()
        If Audit Then
            Dt.Rows(0).Item("State_User") = User_Display
        End If
        If Me.Mode = Mode_Enum.Add Then
            R = Dao.Applique_Add(Dt, dtList)
        Else
            R = Dao.Applique_Save(LId, Dt, dtList)
        End If
        If R.IsOk Then
            LId = TB_ID.Text
            LastForm.ReturnId = TB_ID.Text
            Mode = Mode_Enum.Modify
            If Audit Then
                Dim msg As MsgReturn = Dao.Applique_Audited(TB_ID.Text, True)
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
    End Sub
    ''' <summary>
    ''' 验证信息
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Function CheckForm() As Boolean
        CaculateSumZL()
        TB_ID.Text = TB_ID.Text.Trim
        TB_ID.Text = TB_ID.Text.Replace("'", "")
        If TB_ID.Text = "" Then
            ShowErrMsg(Ch_Name & "单号不能为空!", AddressOf TB_ID.Focus)
            Return False
        End If
        If (Mode = Mode_Enum.Add Or (Mode = Mode_Enum.Modify And LId <> TB_ID.Text)) AndAlso Dao.Applique_CheckID(TB_ID.Text) Then
            ShowErrMsg(Ch_Name & "单号[" & TB_ID.Text & "]已经存在!", AddressOf TB_ID.Focus)
            Return False
        End If
        'If (CB_Prevent.IDValue) = 0 Then
        '    ShowErrMsg("客户商编号或名称不能为空!", AddressOf CB_Prevent.Focus)
        '    Return False
        'End If


        For i As Integer = Fg1.Rows.Count - 1 To 1 Step -1
            Try
                If Val(Fg1.Item(i, "Qty")) < 0 Then
                    Fg1.Item(i, "Qty") = -Val(Fg1.Item(i, "Qty"))
                End If
                If Val(Fg1.Item(i, "Qty")) = 0 OrElse Val(Fg1.Item(i, "Amount")) = 0 OrElse Val(Fg1.Item(i, "WL_ID")) = 0 Then
                    Fg1.RemoveItem(i)
                End If
            Catch ex As Exception
            End Try
        Next

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

    Private Sub CB_Store_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles CB_Store.SelectionChangeCommitted
        Fg1.Item(Fg1.RowSel, "Store_ID") = CB_Store.SelectedValue
    End Sub

    'Private Sub CB_WL_Spec_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles CB_WL_Spec.SelectionChangeCommitted
    '    Dim Dr As DataRow = CB_WL_Spec.SelectedItem.row
    '    Me.ReturnObj = Dr
    '    SetGoods
    'End Sub
    'Private Sub Fg1_SetupEditor(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles Fg1.SetupEditor
    '    If e.Col = Fg1.Cols("WL_Spec").Index Then
    '        Dim T As String = Fg1.Item(Fg1.RowSel, "WL_Name")
    '        If T <> "" Then
    '            CB_WL_Spec.DataSource = BaseClass.ComFun.WL_GetByName(T).Dt
    '            CB_WL_Spec.DisplayMember = "WL_Spec"
    '            CB_WL_Spec.ValueMember = "ID"
    '            If CB_WL_Spec.Items.Count > 0 Then CB_WL_Spec.SelectedValue = Fg1.Item(Fg1.RowSel, "WL_ID")
    '        Else
    '            CB_WL_Spec.DataSource = Nothing
    '        End If
    '    End If
    'End Sub

    Private Sub Fg1_AfterScroll(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RangeEventArgs) Handles Fg1.AfterScroll
        ShowGoodsSelCmd()
    End Sub

    Private Sub Fg1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Fg1.Click
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
    Private Sub Fg1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fg1.DoubleClick
        'If Fg1.RowSel > 0 Then
        '    If Fg1.Cols("WL_Name").Index = Fg1.ColSel Then
        '        ShowGoodsSel(Fg1.Item(Fg1.RowSel, "WL_No"))
        '    End If
        'End If
    End Sub
    Private Sub Fg1_AfterEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles Fg1.AfterEdit
        If Fg1.ColSel = Fg1.Cols("GH").Index AndAlso Fg1.LastKey = Keys.Enter Then
            Fg1.LastKey = 0
            Dim gh As String = Fg1.Item(Fg1.RowSel, "GH")
            Dim s As String = ""
            s = gh.Replace("GY", "")
            s = s.Replace("-", "")
            gh = "GY" & s
            For i As Integer = 1 To Fg1.Rows.Count - 1
                If i <> Fg1.RowSel AndAlso gh = Fg1.Item(i, "GH") Then
                    ShowErrMsg("缸号已存在!")
                    Exit Sub
                End If
            Next
            Fg1.Item(Fg1.RowSel, "GH") = gh
            Dim msg As DtReturnMsg = Dao.BBApplique_GetById(gh)
            If msg.IsOk AndAlso msg.Dt.Rows.Count > 0 Then
                SetProduce(msg.Dt.Rows(0))
                If Fg1.Rows.Count <= 1 Then
                    TB_SumQty.Text = 0
                    TB_SumZL.Text = 0
                    Exit Sub
                End If
                Dim SumQty As Double = 0
                Dim SumZL As Double = 0
                For R As Integer = 1 To Fg1.Rows.Count - 1
                    SumZL = SumZL + Val(Fg1.Item(R, "ZL"))
                    SumQty = SumQty + Val(Fg1.Item(R, "Qty"))
                Next
                TB_SumQty.Text = FormatNum(SumQty)
                TB_SumZL.Text = FormatMoney(SumZL)
            Else

                ShowErrMsg("没有找到对应的缸号[" & Fg1.Item(Fg1.RowSel, "GH") & "] 信息!", AddressOf FG_NoGH)

                'Fg1.Focus()
                'Fg1.StartEditing()
                'Fg1.StartEditing(e.Row, e.Col)
            End If
        End If

        'If e.Row < 0 Then
        '    Exit Sub
        'End If
        'If Fg1.LastKey = Keys.Enter Then
        '    Fg1.LastKey = 0
        '    Select Case Fg1.Cols(e.Col).Name
        '        Case "WL_No"
        '            GetWLByNo(Fg1.Item(Fg1.RowSel, Fg1.Cols(e.Col).Index))
        '        Case "Price", "Qty"
        '            Fg1.Item(e.Row, e.Col) = Val(Fg1.Item(e.Row, e.Col))
        '            CaculateSumZL()
        '            Fg1.GotoNextCell(e.Col)
        '        Case Else
        '            Fg1.GotoNextCell(e.Col)
        '    End Select
        'Else
        '    If Fg1.Cols(e.Col).Name = "WL_No" Then
        '        If Fg1.LastText <> Fg1.Item(Fg1.RowSel, Fg1.Cols(e.Col).Index) Then
        '            Fg1.Item(Fg1.RowSel, "WL_ID") = 0
        '            Fg1.Item(Fg1.RowSel, "WL_Name") = ""
        '            Fg1.Item(Fg1.RowSel, "WL_Unit") = ""
        '            Fg1.Item(Fg1.RowSel, "WL_Spec") = ""
        '        End If
        '    End If
        'End If
    End Sub
    Sub FG_NoGH()
        Fg1.Focus()
        Fg1.StartEditing()
        Fg1.StartEditing(Fg1.RowSel, Fg1.ColSel)
    End Sub
    Sub SetProduce(ByVal dr As DataRow)
        ' Dim dr As DataRow = Me.ReturnObj
        If Not dr Is Nothing AndAlso Fg1.RowSel > 0 Then


            Fg1.Item(Fg1.RowSel, "GH") = dr("GH")
            'Fg1.Item(Fg1.RowSel, "OrderBill") = dr("Contract")
            Fg1.Item(Fg1.RowSel, "GH") = dr("GH")
            'Fg1.Item(Fg1.RowSel, "LuoSeDate") = dr("Date_LuoSe")
            'Fg1.Item(Fg1.RowSel, "BZ_ID") = dr("BZ_ID")
            'Fg1.Item(Fg1.RowSel, "BZ_No") = dr("BZ_No")
            Fg1.Item(Fg1.RowSel, "BZ_Name") = dr("BZ_Name")
            Fg1.Item(Fg1.RowSel, "ZL") = dr("ZL")
            Fg1.Item(Fg1.RowSel, "Client_Name") = dr("Client_Name")
            'Fg1.Item(Fg1.RowSel, "CPName") = dr("CPName")
            'Fg1.Item(Fg1.RowSel, "BZC_ID") = dr("BZC_ID")
            Fg1.Item(Fg1.RowSel, "BZC_No") = dr("BZC_No")
            Fg1.Item(Fg1.RowSel, "BZC_Name") = dr("BZC_Name")
            Fg1.Item(Fg1.RowSel, "Qty") = dr("PB_CountSum")
            'Fg1.Item(Fg1.RowSel, "PWeight") = dr("PB_ZLSum")
            'Fg1.Item(Fg1.RowSel, "BZC_PF") = IsNull(dr("BZC_PF"), "")
            If IsNull(dr("BzcMsg"), "") = "" Then
                If IsNull(dr("IsFD"), False) Then
                    dr("BzcMsg") = "(返定)"
                    'ElseIf IsNull(dr("IsTPs"), False) Then
                    '    dr("BzcMsg") = "(退胚)"
                Else
                    'dr("BzcMsg") = IIf(IsNull(dr("ClientBzc"), "") <> "" AndAlso Not dr("ClientBzc").ToString.Contains("#"), dr("ClientBzc") & "#", IsNull(dr("ClientBzc"), "")) & _
                    '        dr("BZC_Name") & vbCrLf & "GY-" & Format(dr("BZC_No"), "000000") & dr("BZC_PF")
                End If
            Else
                'Fg1.Item(Fg1.RowSel, "BzcMsg") = dr("BzcMsg")
                If IsNull(dr("IsFD"), False) Then
                    Fg1.Item(Fg1.RowSel, "BZC_Name") = dr("BzcMsg").ToString.Split(vbCrLf)(0)

                End If
            End If
            If IsNull(dr("IsTP"), False) Then
                dr("BzcMsg") = "(退胚)"
                Fg1.Item(Fg1.RowSel, "BZC_Name") = dr("BzcMsg")
            End If

            If IsNull(dr("CP_ZLSum"), 0) = 0 Then
                'Fg1.Item(Fg1.RowSel, "CWeight") = dr("PB_ZLSum")
            Else
                'Fg1.Item(Fg1.RowSel, "CWeight") = dr("CP_ZLSum")
            End If



            'Fg1.Item(Fg1.RowSel, "JiaGongNeiRong") = dr("ProcessType")
            Dim jiaDai As Boolean = IsNull(dr("CR_ShuangJiaoDai"), False)
            If jiaDai Then
                Fg1.Item(Fg1.RowSel, "JiaoDai") = "双"
            Else
                'Fg1.Item(Fg1.RowSel, "JiaoDai") = "单"
            End If
            '   Fg1.Item(Fg1.RowSel, "JiaoDai") =IsNull(Fg1.Item(Fg1.RowSel, "CR_ShuangJiaoDai"), False):"单""双"
            'Fg1.Item(Fg1.RowSel, "CSpec") = IsNull(dr("CR_ShiYong"), "") & " " & IsNull(dr("CR_BianDuiBian"), "") & " " & IsNull(dr("CR_KeZhong"), "")
            'Fg1.Item(Fg1.RowSel, "ZhiTong") = dr("ZhiTong")
            'Fg1.Item(Fg1.RowSel, "AddWeight") = dr("JiaZhong")
            Fg1.GotoNextCell()

        End If
    End Sub


    ''' <summary>
    '''增行
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_AddRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_AddRow.Click
        AddRow()
    End Sub

    ''' <summary>
    ''' 增行
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub AddRow()
        Fg1.AddRow()
    End Sub

    ''' <summary>
    ''' 减行
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_RemoveRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_RemoveRow.Click
        Fg1.RemoveRow()
    End Sub
    Private Sub Fg1_NextCell(ByVal e As PClass.FG.NextCellEventArgs) Handles Fg1.NextCell
        Select Case e.Col
            Case "ZL"
                e.ToCol = Fg1.Cols("Qty").Index
            Case "Qty"

                If e.Row + 2 > Fg1.Rows.Count Then
                    AddRow()
                End If
                e.ToRow = e.Row + 1
                e.ToCol = Fg1.Cols("Client_Name").Index

            Case Else
                e.ToCol = Fg1.Cols("Qty").Index
        End Select
    End Sub

    Private Sub Fg1_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fg1.Enter
        'If Fg1.RowSel < 0 Then
        '    Exit Sub
        'End If
        'If Fg1.Cols(Fg1.ColSel).AllowEditing AndAlso Fg1.CanEditing Then
        '    Fg1.LastKey = 0
        '    Fg1.StartEditing()
        'End If
        ShowGoodsSelCmd()
    End Sub

    Private Sub Fg1_EnterCell(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fg1.EnterCell
        If Fg1.RowSel < 0 Then
            Exit Sub
        End If
        If Fg1.Cols(Fg1.ColSel).AllowEditing AndAlso Fg1.CanEditing Then
            Fg1.LastKey = 0
            Fg1.StartEditing()
        End If
        ShowGoodsSelCmd()
    End Sub

    Private Sub Fg1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Fg1.KeyDown
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

    Private Sub Fg1_KeyDownEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.KeyEditEventArgs) Handles Fg1.KeyDownEdit
        If e.KeyCode = Keys.Add AndAlso Fg1.Cols("WL_No").Index = e.Col AndAlso Fg1.CanEditing Then
            ShowGoodsSel(Fg1.Item(Fg1.RowSel, "WL_No"))
        End If
    End Sub

#End Region

#Region "物料选择"
    Dim gType As String = ""
    Protected Sub ShowGoodsSelCmd()
        If Fg1.ColSel > 0 AndAlso Fg1.RowSel > 0 Then
            If Fg1.CanEditing Then
                Dim C As C1.Win.C1FlexGrid.Column = Fg1.Cols(Fg1.ColSel)
                Dim R As C1.Win.C1FlexGrid.Row = Fg1.Rows(Fg1.RowSel)
                Select Case Fg1.Cols(Fg1.ColSel).Name
                    Case "WL_No", "WL_Name"
                        Cmd_GoodsSel.Left = Fg1.Left + C.Left + C.WidthDisplay - Cmd_GoodsSel.Width + Fg1.ScrollPosition.X + 1
                        Cmd_GoodsSel.Top = Fg1.Top + R.Top + Fg1.ScrollPosition.Y + 1
                        Cmd_GoodsSel.Height = R.HeightDisplay
                        Cmd_GoodsSel.Visible = True
                    Case Else
                        Cmd_GoodsSel.Visible = False
                End Select
            Else
                Cmd_GoodsSel.Visible = False
            End If
        Else
            Cmd_GoodsSel.Visible = False
        End If
    End Sub

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
            .P_F_RS_ID5 = TB_Supplier_Name.Text
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
            CB_Store.SelectedValue = IsNull(dr("WL_Store_ID"), 0)
            Fg1.Item(Fg1.RowSel, "Store_Name") = CB_Store.Text
            gType = IsNull(dr("WL_Type_ID"), "")
            Fg1.GotoNextCell("WL_No")
        Else
            Fg1.StartEditing(Fg1.RowSel, Fg1.Cols("WL_No").Index)
        End If
        Me.ReturnObj = Nothing
    End Sub

    Protected Sub GetWLByNo(ByVal _No As String)
        Dim msg As DtReturnMsg = ComFun.WL_GetByNo(_No)
        If msg.IsOk AndAlso msg.Dt.Rows.Count = 1 Then
            Me.ReturnObj = msg.Dt.Rows(0)
            SetGoods()
        Else
            ShowGoodsSel(_No)
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
            ComFun.DelBillNewID(BillType.Applique, Bill_ID)
            Bill_Id_Date = #1/1/1999#
            GetNewID()
        End If
    End Sub

    Sub GetNewID()
        If TB_ID.ReadOnly = False Then
            If DTP_sDate.Value <> Bill_Id_Date Then
                Dim R As RetrunNewIdMsg = ComFun.GetBillNewID(BillType.Applique, DTP_sDate.Value, Bill_ID)
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
        Dim R As New R30225_Applique_List
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
        If CheckForm() Then
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
        SaveApplique(True)
    End Sub

    Private Sub Cmd_UnAudit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_UnAudit.Click
        ShowConfirm("是否反审" & Ch_Name & " [" & TB_ID.Text & "]?", AddressOf UnAudit)
    End Sub

    Protected Sub UnAudit()
        Dim msg As MsgReturn = Dao.Applique_Audited(TB_ID.Text, False)
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
        ShowConfirm("是否删除" & Ch_Name & " [" & TB_ID.Text & "]?", AddressOf DelApplique)
    End Sub

    ''' <summary>
    ''' 删除日报表
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub DelApplique()
        Dim msg As MsgReturn = Dao.Applique_Del(TB_ID.Text)
        If msg.IsOk Then
            LastForm.ReturnId = TB_ID.Text
            Me.Close()
        Else
            ShowErrMsg(msg.Msg)
        End If
    End Sub


    Private Sub Cmd_SetInValid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_SetInValid.Click
        ShowConfirm("是否作废" & Ch_Name & " [" & TB_ID.Text & "]?", AddressOf AppliqueInValid)
    End Sub


    Sub AppliqueInValid()
        Dim msg As MsgReturn = Dao.Applique_InValid(TB_ID.Text, True)
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
        ShowConfirm("是否反作废" & Ch_Name & " [" & TB_ID.Text & "]?", AddressOf AppliqueValid)
    End Sub

    ''' <summary>
    ''' 作废
    ''' </summary>
    ''' <remarks></remarks>
    Sub AppliqueValid()
        Dim msg As MsgReturn = Dao.Applique_InValid(TB_ID.Text, False)
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
            Return Dao.Applique_CheckIsModify(LId, LastLine)
        End If
    End Function

#End Region


#Region "是否已付款"
    Private Sub CB_Supplier_Col_Sel(ByVal Col_No As String, ByVal Col_Name As String, ByVal ID As String) Handles CB_Prevent.Col_Sel
        TB_Supplier_Name.Text = Col_Name
    End Sub

    Private Sub Cmd_Payment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Fg1.FinishEditing(False)
        ShowConfirm(Ch_Name & " [" & TB_ID.Text & "]是否付款?", AddressOf SetPayment)
    End Sub

    Private Sub SetPayment()
        Dim msg As MsgReturn = Dao.Applique_Payment(TB_ID.Text, True)
        If msg.IsOk Then
            LastForm.ReturnId = Me.TB_ID.Text
            Bill_Id = TB_ID.Text
            Mode = Mode_Enum.Modify
            Me_Refresh()
            ShowOk(msg.Msg)
        Else
            ShowErrMsg(msg.Msg)
        End If
    End Sub

    Private Sub UnPayment()
        Dim msg As MsgReturn = Dao.Applique_Payment(TB_ID.Text, False)
        If msg.IsOk Then
            LastForm.ReturnId = Me.TB_ID.Text
            Bill_Id = TB_ID.Text
            Mode = Mode_Enum.Modify
            Me_Refresh()
            ShowOk(msg.Msg)
        Else
            ShowErrMsg(msg.Msg)
        End If
    End Sub


    Private Sub Cmd_UnPayment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_UnPayment.Click
        ShowConfirm("是否取消" & Ch_Name & " [" & TB_ID.Text & "]的付款?", AddressOf UnPayment)
    End Sub

#End Region

    Private Sub PanelMain_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PanelMain.Paint

    End Sub
End Class

Partial Friend Class Dao
#Region "常量"
    Protected Friend Const Applique_DB_NAME As String = "补布申请单"
    ''' <summary>
    ''' 删除单据
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_Applique_DelByid As String = "Delete from T30225_BBSQ_Table  where ID=@ID and State=0"
    ''' <summary>
    ''' 获取单头
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_Applique_GetByid As String = "select top 1 * from T30225_BBSQ_Table  where ID=@ID"
    ''' <summary>
    ''' 获取单头
    ''' </summary>
    ''' <remarks></remarks>
    'Private Const SQL_Applique_SelByid As String = "select  * from T30225_BBSQ_Table  where ID=@ID"

    Private Const SQL_Applique_SelByid As String = "select BL.*,T.Client_Name,T.BZ_Name,T.BZC_Name,T.BZC_No,BT.Reason,BT.YFCS,BT.YFCS_ZG,BT.YFCS_Date,BT.CFCS,BT.CFCS_ZG,BT.CFCS_Date,BT.CBPS,BT.Reason_ZG,BT.Reason_Date from T30226_BBSQ_List BL left join T30225_BBSQ_Table BT ON BL.ID=BT.ID left join (select P.GH,P.Client_ID,P.BZ_ID,P.BZC_ID,BZ_Name,BZC_Name,BZC_No,Client_Name from  T30000_Produce_Gd P  left join T10110_Client C on P.Client_ID=C.ID left join T10002_BZ BZ on P.BZ_ID=BZ.ID left join T10003_BZC BZC on P.BZC_ID=BZC.ID ) T on T.GH=BL.GH where BL.ID=@ID"

    ''' <summary>
    ''' 获取单头 用于作废和审核
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_Applique_GetStateByid As String = "select top 1 ID,State,State_User from T30225_BBSQ_Table  where ID=@ID"
    ''' <summary>
    ''' 获取单体
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_Applique_GetListByid As String = "select * from T30226_BBSQ_List  where ID=@ID "
    ''' <summary>
    ''' 获取单体,用于显示
    ''' </summary>
    ''' <remarks></remarks>0
    Private Const SQL_Applique_SelListByid As String = "select BL.*,T.Client_Name,T.BZ_Name,T.BZC_Name,T.BZC_No from T30226_BBSQ_List BL left join (select P.GH,P.Client_ID,P.BZ_ID,P.BZC_ID,BZ_Name,BZC_Name,BZC_No,Client_Name from  T30000_Produce_Gd P  left join T10110_Client C on P.Client_ID=C.ID left join T10002_BZ BZ on P.BZ_ID=BZ.ID left join T10003_BZC BZC on P.BZC_ID=BZC.ID ) T on T.GH=BL.GH where BL.ID=@ID"

    'Private Const SQL_Applique_SelListByid As String = " select * from T30226_BBSQ_List BL  left join T10002_BZ BZ on BL.BZ_ID=BZ.ID where ID=@ID "
    ''' 检查ID的重复性
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_Applique_CheckID As String = "select * from T30225_BBSQ_Table  where ID=@ID"
    ''' <summary>
    ''' 检查ID的重复性
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_Applique_CheckIsModify As String = "select count(*) from T30226_BBSQ_List  where @ID=ID and Line=@Line"
    ''' <summary>
    ''' 获取补布申请单信息
    ''' </summary>
    ''' <remarks></remarks>
    Public Const SQL_BBApplique_GetByID_WithName As String = "select P.*,C.Client_Name,BZ.BZ_Name,BZC.BZC_Name,BZC.BZC_No,l.ZL from T30000_Produce_Gd P  left join T10110_Client C on P.Client_ID=C.ID left join T10002_BZ BZ on P.BZ_ID=BZ.ID left join T10003_BZC BZC on P.BZC_ID=BZC.ID left join T40101_PBRK_List L on p.GH=L.GH   where P.GH=@GH  "


#End Region


#Region "单一张单内容查询"
    ''' <summary>
    ''' 获取对日报表信息
    ''' </summary>
    ''' <param name="sId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Applique_GetById(ByVal sId As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_Applique_GetByid, "@ID", sId)
    End Function

    ''' <summary>
    ''' 获取对日报表列表信息
    ''' </summary>
    ''' <param name="sId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Applique_SelListById(ByVal sId As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_Applique_SelListByid, "@ID", sId)
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
    Public Shared Function Applique_CheckIsModify(ByVal ID As String, ByVal Line As Integer) As Boolean
        Dim P As New Dictionary(Of String, Object)
        P.Add("ID", ID)
        P.Add("Line", Line)
        Dim R As MsgReturn = SqlStrToOneStr(SQL_Applique_CheckIsModify, P)
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
    Public Shared Function Applique_CheckID(ByVal ID As String) As Boolean
        Dim R As MsgReturn = SqlStrToOneStr(SQL_Applique_CheckID, "@ID", ID)
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
    Public Shared Function Applique_Add(ByVal dtTable As DataTable, ByVal dtList As DataTable) As MsgReturn
        Dim msg As New DtListReturnMsg
        Dim R As New MsgReturn
        Dim sqlMap As New Dictionary(Of String, String)
        Dim paraMap As New Dictionary(Of String, Object)
        Dim AppliqueId As String = dtTable.Rows(0)("ID")
        Dim IsInsert As Boolean = False
        paraMap.Add("ID", AppliqueId)
        Try
            sqlMap.Add("Table", SQL_Applique_GetByid)
            sqlMap.Add("List", SQL_Applique_GetListByid)

            msg = SqlStrToDt(sqlMap, paraMap)
            If msg.DtList("Table").Rows.Count = 0 Then
                DvToDt(dtTable, msg.DtList("Table"), New List(Of String), True)
                DvToDt(dtList, msg.DtList("List"), New List(Of String), True)
                Dim TmSQL As String = "insert into Bill_Barcode (No_ID,NO_Type)values('" & AppliqueId & "'," & BillType.Applique & ")"
                DtToUpDate(msg, TmSQL)
                R.Msg = "" & Applique_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]添加成功!"
                R.IsOk = True
            Else
                R.IsOk = False
                R.Msg = "" & Applique_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]已经存在!请双击编号文本框,获取新编号!"
            End If
            Return R
        Catch ex As Exception
            R.IsOk = False
            R.Msg = "" & Applique_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]添加错误!"
            DebugToLog(ex)
            Return R
        Finally
        End Try
    End Function

    ''' <summary>
    ''' 修改日报表
    ''' </summary>
    ''' <param name="dtTable"></param>
    ''' <param name="dtList"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Applique_Save(ByVal LID As String, ByVal dtTable As DataTable, ByVal dtList As DataTable) As MsgReturn
        Dim msg As New DtListReturnMsg
        Dim R As New MsgReturn
        Dim sqlMap As New Dictionary(Of String, String)
        Dim paraMap As New Dictionary(Of String, Object)
        Dim AppliqueId As String = dtTable.Rows(0)("ID")
        If LID <> AppliqueId AndAlso Applique_CheckID(AppliqueId) Then
            R.IsOk = False
            R.Msg = "" & Applique_DB_NAME & "[" & AppliqueId & "]已经存在!请双击编号文本框,获取新编号!"
            Return R
        End If
        dtTable.Rows(0)("ID") = LID
        paraMap.Add("ID", LID)
        Try
            sqlMap.Add("Table", SQL_Applique_GetByid)
            sqlMap.Add("List", SQL_Applique_GetListByid)
            msg = SqlStrToDt(sqlMap, paraMap)
            If msg.DtList("Table").Rows.Count = 1 Then
                If msg.DtList("Table").Rows(0)("State") = Enum_State.Audited Then
                    msg.DaList("Table").Dispose()
                    msg.DaList("List").Dispose()
                    msg.Cnn.Dispose()
                    R.IsOk = False
                    R.Msg = "" & Applique_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]已经被审核不能再修改!"
                    Return R
                End If
                If msg.DtList("Table").Rows(0)("State") = Enum_State.Invoid Then
                    msg.DaList("Table").Dispose()
                    msg.DaList("List").Dispose()
                    msg.Cnn.Dispose()
                    R.IsOk = False
                    R.Msg = "" & Applique_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]已经被作废不能再修改!"
                    Return R
                End If
                DvToDt(dtList, msg.DtList("List"), New List(Of String))
                DvUpdateToDt(dtTable, msg.DtList("Table"), New List(Of String))
                Dim TmSQL As String = "Update Bill_Barcode set No_ID='" & AppliqueId & "' where No_ID='" & LID & "' and NO_Type=" & BillType.Applique
                If LID <> AppliqueId Then
                    DtToUpDate(msg, "Update T30225_BBSQ_Table set id='" & AppliqueId & "' where id='" & LID & "'" & vbCrLf & TmSQL)
                    dtTable.Rows(0)("ID") = AppliqueId
                    R.Msg = "" & Applique_DB_NAME & "[" & LID & "]已经修改为[" & AppliqueId & "]!"
                Else
                    DtToUpDate(msg)
                    R.Msg = "" & Applique_DB_NAME & "[" & LID & "]修改成功!"
                End If
                R.IsOk = True
            Else
                R.IsOk = False
                R.Msg = "" & Applique_DB_NAME & "[" & LID & "]不存在"
            End If
            Return R
        Catch ex As Exception
            R.IsOk = False
            R.Msg = "" & Applique_DB_NAME & "[" & LID & "]修改错误"
            DebugToLog(ex)
            Return R
        Finally
        End Try
    End Function

    ''' <summary>
    ''' 删除日报表
    ''' </summary>
    ''' <param name="AppliqueId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Applique_Del(ByVal AppliqueId As String)
        Return RunSQL(SQL_Applique_DelByid, "@ID", AppliqueId)
    End Function

    ''' <summary>
    ''' 作废日报表
    ''' </summary>
    ''' <param name="_ID"></param>
    ''' <param name="IsFei">作废还是反作废</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Applique_InValid(ByVal _ID As String, ByVal IsFei As Boolean) As MsgReturn
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
            sqlMap.Add("Table", SQL_Applique_GetStateByid)
            msg = SqlStrToDt(sqlMap, paraMap)
            If msg.DtList("Table").Rows.Count = 1 Then
                If msg.DtList("Table").Rows(0)("State") <> Enum_State.Audited Then
                    If msg.DtList("Table").Rows(0)("State") <> State Then
                        msg.DtList("Table").Rows(0)("State") = State
                        msg.DtList("Table").Rows(0)("State_User") = User_Display
                        DtToUpDate(msg)
                        R.IsOk = True
                        R.Msg = "" & Applique_DB_NAME & "[" & _ID & "]" & OStr & "成功!"
                    Else
                        R.IsOk = False
                        R.Msg = "" & Applique_DB_NAME & "[" & _ID & "]已经被" & OStr & "!不能再" & OStr & "!"
                    End If
                Else
                    R.IsOk = False
                    R.Msg = "" & Applique_DB_NAME & "[" & _ID & "]已经被审核,不能" & OStr & "!"
                End If
            Else
                R.IsOk = False
                R.Msg = "" & Applique_DB_NAME & "[" & _ID & "]不存在,不能" & OStr & "!"
            End If
            Return R
        Catch ex As Exception
            R.IsOk = False
            R.Msg = "" & Applique_DB_NAME & "[" & _ID & "]" & OStr & "错误!"
            DebugToLog(ex)
            Return R
        Finally
        End Try
    End Function
    ''' <summary>
    ''' 审核补布申请单
    ''' </summary>
    ''' <param name="_ID"></param>
    ''' <param name="IsAudited">审核还是反审核</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Applique_Audited(ByVal _ID As String, ByVal IsAudited As Boolean) As MsgReturn
        Dim R As MsgReturn
        Dim s As String = IIf(IsAudited, "审核", "反审核")
        Dim state As Integer = IIf(IsAudited, 1, 0)
        Dim paraMap As New Dictionary(Of String, Object)
        paraMap.Add("ID", _ID)
        paraMap.Add("IsAudited", IsAudited)
        paraMap.Add("State_User", User_Display)

        '判断状态
        Dim msg As DtReturnMsg = SqlStrToDt("select state from  T30225_BBSQ_Table where ID=@ID  ", "ID", _ID)
        If msg.IsOk AndAlso msg.Dt.Rows.Count > 0 AndAlso IsNull(msg.Dt.Rows(0)("State"), False) = state Then
            R = New MsgReturn
            R.Msg = Applique_DB_NAME & s & "失败！[" & _ID & "]已被" & s
            Return R

        End If

        R = SqlStrToOneStr("Update T30225_BBSQ_Table set State=@IsAudited,State_User=@State_User where ID=@ID  ", paraMap)
        If R.IsOk Then
            R.Msg = Applique_DB_NAME & s & "成功！"
        Else
            R.Msg = Applique_DB_NAME & s & "失败！" & R.Msg

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
    'Public Shared Function Applique_Audited(ByVal _ID As String, ByVal IsAudited As Boolean) As MsgReturn
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
    Public Shared Function Applique_Payment(ByVal _ID As String, ByVal IsPayment As Boolean) As MsgReturn
        Dim paraMap As New Dictionary(Of String, Object)
        paraMap.Add("ID", _ID)
        paraMap.Add("IsPayment", IsPayment)
        Dim R As MsgReturn = SqlStrToOneStr("Update T20000_Puchase_Table set Payment=@IsPayment where ID=@ID  ", paraMap)
        Dim s As String = IIf(IsPayment, "付款", "未付款")
        If R.IsOk Then
            R.Msg = Applique_DB_NAME & s & "成功！"
        Else
            R.Msg = Applique_DB_NAME & s & "失败！" & R.Msg

        End If

        Return R
    End Function

    ''' <summary>
    ''' 获取运转单信息
    ''' </summary>
    ''' <param name="sId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function BBApplique_GetById(ByVal sId As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_BBApplique_GetByID_WithName, "@GH", sId)
    End Function













#End Region
End Class