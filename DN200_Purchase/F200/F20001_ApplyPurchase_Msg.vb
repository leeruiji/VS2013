﻿Option Compare Text
Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports PClass
Imports BaseClass
Imports PClass.CReport

Public Class F20001_ApplyPurchase_Msg
    Dim LId As String = ""
    'Dim Bill_Id As String = ""
    Dim Bill_Id_Date As Date = #1/1/1999#
    Dim dtList As DataTable
    Dim dtTable As DataTable
    Dim DtChePai As DataTable
    '   Dim StoreDt As DataTable
    Dim State As Enum_State_Upgrade = Enum_State_Upgrade.AddNew
    Dim IsBidings As Boolean = False
    Dim Payment As Boolean = False
    Dim CO_To_Purchase As DataTable
    '是否由客户订单生成
    Dim IsCO_To_P As Boolean = False
    '申购但送货时间
    Dim Max_eDate As DateTime

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
            Fg1.Select(1, Fg1.Cols("WL_No").Index, 1, Fg1.Cols("WL_No").Index)
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
        Control_CheckRight(ID, ClassMain.Confirm, cmd_Confirm)
        Control_CheckRight(ID, ClassMain.UnConfirm, cmd_UnConfirm)
        Control_CheckRight(ID, ClassMain.Audited, Cmd_Audit)
        Control_CheckRight(ID, ClassMain.UnAudit, Cmd_UnAudit)
        Control_CheckRight(ID, ClassMain.SetInValid, Cmd_SetInValid)
        Control_CheckRight(ID, ClassMain.SetValid, Cmd_SetValid)
    End Sub

    Private Sub Form_Me_Closing(ByVal sender As Object, ByRef e As System.ComponentModel.CancelEventArgs) Handles Me.Me_Closing
        ComFun.DelBillNewID(BillType.ApplyPurchase, Bill_ID)
    End Sub

    Private Sub Form_Load() Handles Me.Me_Load
        Fg1.Cols("Supplier_Name").Editor = CB_Supplier
        ID = 20000
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
        If Me.P_F_RS_ID4 = "[ToApplyPurchase]" Then
            Bill_ID = Me.P_F_RS_ID5
        End If
        Dim msgTable As DtReturnMsg = Dao.Purchase_GetById(Bill_ID)
        If msgTable.IsOk Then
            If IsBidings Then
                DvUpdateToDt(msgTable.Dt, dtTable, New List(Of String))
            Else
                dtTable = msgTable.Dt
            End If
            If Mode = Mode_Enum.Modify AndAlso msgTable.Dt.Rows.Count = 0 Then
                ShowErrMsg("没有找到" & Dao.Purchase_DB_NAME & "[" & Bill_ID & "]", True)
                Exit Sub
            End If
            SetForm(dtTable)
        End If
        Select Case Mode
            Case Mode_Enum.Add
                If CheckRight(ID, ClassMain.Add) = False Then Me.ShowErrMsg("没有权限添加" & Dao.Purchase_DB_NAME & "!", True) : Exit Sub
                Dim msg As DtReturnMsg = Dao.Purchase_SelListById(0)
                If msg.IsOk Then dtList = msg.Dt
                Fg1.Rows.Count = 2
                Fg1.ReAddIndex()
                TB_Upd_User.Text = User_Display
                LabelTitle.Text = "新建" & Me.Ch_Name
                Cmd_Preview.Enabled = False
                Cmd_Print.Enabled = False
                DTP_sDate.Value = GetDate()
                GetNewID()

                If Me.P_F_RS_ID4 = "[ClientOrder]" Then
                    TB_ClientBill.Text = Me.F_RS_ID5
                    CO_To_Purchase = Me.F_RS_Obj
                    Fg1.DtToSetFG(DirectCast(Me.F_RS_Obj, DataTable))
                End If

            Case Mode_Enum.Modify
                Cmd_Preview.Enabled = True
                Cmd_Print.Enabled = True
                Dim msg As DtReturnMsg = Dao.Purchase_SelListById(Bill_ID)
                If msg.IsOk Then
                    dtList = msg.Dt
                    LastLine = msg.Dt.Rows(0)("Line")
                    Fg1.DtToSetFG(msg.Dt)
                End If
                LId = TB_ID.Text
                LabelTitle.Text = "修改" & Me.Ch_Name
        End Select
        CaculateSumAmount()
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
        CaculateSumAmount()
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
        'dr("Supplier_ID") = CB_Supplier.IDValue
        dr("State") = State
        dr("Payed") = dr("SumAmount") - IsNull(dr("UnPayed"), 0)
        dt.AcceptChanges()
        dtList = dtList.Clone
        For i As Integer = 1 To Fg1.Rows.Count - 1
            dr = dtList.NewRow
            dr("ID") = ID
            'dr("Store_ID") = Fg1.Item(i, "Store_ID")
            dr("WL_ID") = Fg1.Item(i, "WL_ID")
            dr("Price") = Fg1.Item(i, "Price")
            dr("Supplier_ID") = IsNull(Fg1.Item(i, "Supplier_ID"), 0)
            dr("Supplier_Name") = IsNull(Fg1.Item(i, "Supplier_Name"), "")
            dr("Cost") = Fg1.Item(i, "Price")
            dr("Qty") = Fg1.Item(i, "Qty")
            dr("Amount") = Fg1.Item(i, "Amount")
            dr("LRemark") = Fg1.Item(i, "LRemark")
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
            Dr("ClientBill") = ""
            Dr("Remark") = ""
            Dr("ID") = ""
            Dr("sDate") = ServerTime.Date
            Dr("eDate") = ServerTime.Date
            Dr("SumAmount") = 0
            Dr("Payed") = Dr("SumAmount") - Dr("UnPayed")

            cmd_Confirm.Visible = cmd_Confirm.Tag
            cmd_Confirm.Enabled = True
            cmd_UnConfirm.Visible = False
            cmd_UnConfirm.Enabled = False

            Cmd_SetValid.Visible = False
            Cmd_SetValid.Enabled = False
            Cmd_SetInValid.Visible = Cmd_SetInValid.Tag
            Cmd_SetInValid.Enabled = False
            Cmd_Del.Enabled = False

            Cmd_Audit.Visible = Cmd_Audit.Tag
            Cmd_Audit.Enabled = False
            Cmd_UnAudit.Visible = False
            Cmd_UnAudit.Enabled = False
            Cmd_Payment.Visible = False
            Cmd_UnPayment.Visible = False

            LabelPayment.Visible = False
            Bt_ToClientOrder.Visible = False
            LabelState.Text = "新建"
            LabelState.ForeColor = Color.Black
            dt.Rows.Add(Dr)
            dt.AcceptChanges()
            LockForm(False)
        Else
            Dr = dt.Rows(0)
            State = Dr("State")
            Payment = IsNull(Dr("Payment"), False)
            LabelPayment.Visible = True
            If IsNull(Dr("ClientBill"), "") <> "" Then IsCO_To_P = True Else IsCO_To_P = False

            If Payment Then
                LabelPayment.Text = "已付款"
                Cmd_Payment.Enabled = False
                Cmd_UnPayment.Enabled = True
            Else
                LabelPayment.Text = "未付款"
                Cmd_Payment.Enabled = True
                Cmd_UnPayment.Enabled = False
            End If
            Cmd_Del.Visible = False
            Select Case State
                Case Enum_State_Upgrade.AddNew '新建
                    LabelState.Text = "新建"
                    LabelState.ForeColor = Color.Black
                    Cmd_Modify.Enabled = Cmd_Modify.Tag

                    cmd_Confirm.Visible = cmd_Confirm.Tag
                    cmd_Confirm.Enabled = True
                    cmd_UnConfirm.Visible = False
                    cmd_UnConfirm.Enabled = False
                    Cmd_AddRow.Enabled = True
                    Cmd_Del.Enabled = Cmd_Del.Tag
                    Cmd_RemoveRow.Enabled = True

                    Cmd_SetValid.Visible = False
                    Cmd_SetValid.Enabled = True
                    Cmd_SetInValid.Visible = Cmd_SetInValid.Tag
                    Cmd_SetInValid.Enabled = True
                    Cmd_Del.Enabled = True

                    Cmd_Audit.Visible = Cmd_Audit.Tag
                    Cmd_Audit.Enabled = False
                    Cmd_UnAudit.Visible = False
                    Cmd_UnAudit.Enabled = False
                    Bt_ToClientOrder.Visible = False
                    LockForm(False)

                Case Enum_State_Upgrade.Invoid '作废
                    LabelState.Text = "已作废"
                    LabelState.ForeColor = Color.Red
                    Cmd_Modify.Enabled = False

                    cmd_Confirm.Visible = cmd_Confirm.Tag
                    cmd_Confirm.Enabled = False
                    cmd_UnConfirm.Visible = False
                    cmd_UnConfirm.Enabled = False

                    Cmd_AddRow.Enabled = False

                    Cmd_Del.Enabled = True
                    Cmd_RemoveRow.Enabled = False

                    Cmd_SetValid.Visible = Cmd_SetValid.Tag
                    Cmd_SetValid.Enabled = True
                    Cmd_SetInValid.Visible = False
                    Cmd_SetInValid.Enabled = False

                    Cmd_Audit.Visible = Cmd_Audit.Tag
                    Cmd_Audit.Enabled = False
                    Cmd_UnAudit.Visible = False
                    Cmd_UnAudit.Enabled = False
                    Bt_ToClientOrder.Visible = False
                    LockForm(True)

                Case Enum_State_Upgrade.Comfirm '确认
                    TB_ID.ReadOnly = True
                    LabelState.Text = "已确认"
                    LabelState.ForeColor = Color.Blue
                    Cmd_Modify.Enabled = False

                    Cmd_RemoveRow.Enabled = False
                    Cmd_AddRow.Enabled = False
                    Cmd_Del.Enabled = False

                    cmd_Confirm.Visible = False
                    cmd_Confirm.Enabled = False
                    cmd_UnConfirm.Visible = cmd_UnConfirm.Tag
                    cmd_UnConfirm.Enabled = True

                    Cmd_SetValid.Visible = False
                    Cmd_SetValid.Enabled = False
                    Cmd_SetInValid.Visible = Cmd_SetInValid.Tag
                    Cmd_SetInValid.Enabled = False

                    Cmd_Audit.Visible = Cmd_Audit.Tag
                    Cmd_Audit.Enabled = True
                    Cmd_UnAudit.Visible = False
                    Cmd_UnAudit.Enabled = False
                    Bt_ToClientOrder.Visible = IsCO_To_P
                    LockForm(True)


                Case Enum_State_Upgrade.Audited '审核
                    LabelState.Text = "已审核"
                    LabelState.ForeColor = Color.Blue
                    Cmd_Modify.Enabled = False

                    Cmd_RemoveRow.Enabled = False
                    Cmd_AddRow.Enabled = False
                    Cmd_Del.Enabled = False

                    cmd_Confirm.Visible = False
                    cmd_Confirm.Enabled = False
                    cmd_UnConfirm.Visible = False
                    cmd_UnConfirm.Enabled = True

                    Cmd_SetValid.Visible = False
                    Cmd_SetValid.Enabled = False
                    Cmd_SetInValid.Visible = Cmd_SetInValid.Tag
                    Cmd_SetInValid.Enabled = False

                    Cmd_Audit.Visible = Cmd_Audit.Tag
                    Cmd_Audit.Enabled = False
                    Cmd_UnAudit.Visible = True
                    Cmd_UnAudit.Enabled = True
                    Bt_ToClientOrder.Visible = IsCO_To_P
                    DTP_eDate.Enabled = False
                    LockForm(True)
            End Select
        End If
        If IsBidings = False Then



            TB_ID.DataBindings.Add("Text", dtTable, TB_ID.Name.Substring(3), False, DataSourceUpdateMode.OnPropertyChanged)
            DTP_sDate.DataBindings.Add("Value", dtTable, DTP_sDate.Name.Substring(4), False, DataSourceUpdateMode.OnPropertyChanged, ServerTime.Date, "yyyy-MM-dd")
            DTP_eDate.DataBindings.Add("Value", dtTable, DTP_eDate.Name.Substring(4), False, DataSourceUpdateMode.OnPropertyChanged, ServerTime.Date, "yyyy-MM-dd")
            TB_ClientBill.DataBindings.Add("Text", dtTable, TB_ClientBill.Name.Substring(3), False, DataSourceUpdateMode.OnPropertyChanged, "")
            TB_Remark.DataBindings.Add("Text", dtTable, TB_Remark.Name.Substring(3), False, DataSourceUpdateMode.OnPropertyChanged, "")
            TB_Payed.DataBindings.Add("Text", dtTable, TB_Payed.Name.Substring(3), True, DataSourceUpdateMode.OnPropertyChanged, 0, FormatSharp("money"))

            TB_UnPayed.DataBindings.Add("Text", dtTable, TB_UnPayed.Name.Substring(3), True, DataSourceUpdateMode.OnPropertyChanged, 0, FormatSharp("money"))
            TB_SumQty.DataBindings.Add("Text", dtTable, TB_SumQty.Name.Substring(3), True, DataSourceUpdateMode.OnPropertyChanged, 0, FormatSharp("num"))
            TB_SumAmount.DataBindings.Add("Text", dtTable, TB_SumAmount.Name.Substring(3), True, DataSourceUpdateMode.OnPropertyChanged, 0, FormatSharp("money"))

            TB_State_User.DataBindings.Add("Text", dtTable, TB_State_User.Name.Substring(3), False, DataSourceUpdateMode.OnPropertyChanged, "")
            TB_Upd_User.DataBindings.Add("Text", dtTable, TB_Upd_User.Name.Substring(3), False, DataSourceUpdateMode.OnPropertyChanged, "")

            IsBidings = True
            Max_eDate = DTP_eDate.Value
        End If
        'CB_Supplier.IDValue = IsNull(dtTable.Rows(0)("Supplier_ID"), "0")
        'CB_Supplier.Text = CB_Supplier.GetByTextBoxTag
        'TB_Supplier_Name.Text = CB_Supplier.NameValue
    End Sub

    Sub LockForm(ByVal Lock As Boolean)
        TB_ID.ReadOnly = Lock
        DTP_sDate.Enabled = Not Lock
        Fg1.CanEditing = Not Lock
        Fg1.IsClickStartEdit = Not Lock
        CB_Supplier.Enabled = Not Lock
        TB_ClientBill.ReadOnly = Lock
        TB_Payed.ReadOnly = Lock
        TB_Remark.ReadOnly = Lock
        If Me.P_F_RS_ID4 = "[ClientOrder]" Then
            Cmd_AddRow.Enabled = Lock
            Cmd_RemoveRow.Enabled = Lock
        Else
            Cmd_AddRow.Enabled = Not Lock
            Cmd_RemoveRow.Enabled = Not Lock
        End If
    End Sub


    ''' <summary>
    ''' FG合计
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub CaculateSumAmount()
        If Fg1.Rows.Count <= 1 Then
            TB_SumQty.Text = 0
            TB_SumAmount.Text = 0
            TB_UnPayed.Text = 0
            Exit Sub
        End If
        Dim SumQty As Double = 0
        Dim SumAmount As Double = 0
        For R As Integer = 1 To Fg1.Rows.Count - 1
            Fg1.Item(R, "Amount") = Val(Fg1.Item(R, "Qty")) * Val(Fg1.Item(R, "Price"))
            SumAmount = SumAmount + Val(Fg1.Item(R, "Amount"))
            SumQty = SumQty + Val(Fg1.Item(R, "Qty"))
        Next
        TB_SumQty.Text = FormatNum(SumQty)
        TB_SumAmount.Text = FormatMoney(SumAmount)
        TB_UnPayed.Text = FormatZL(SumAmount - Val(TB_Payed.Text))
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
                ShowConfirm("是否保存新" & Ch_Name & "?", AddressOf SavePurchase)
            Else
                If CheckIsModify() Then
                    ShowConfirm(Ch_Name & "[" & TB_ID.Text & "] 已经被其他人修改过,是否覆盖别人的修改?", AddressOf SavePurchase)
                Else
                    ShowConfirm("是否保存" & Ch_Name & "[" & TB_ID.Text & "] 的修改?", AddressOf SavePurchase)
                End If
            End If
        End If
    End Sub

    ''' <summary>
    ''' 保存修改
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub SavePurchase(Optional ByVal IfConfirm As Boolean = False)
        Dim R As MsgReturn
        Dim Dt As DataTable = GetForm()
        If IfConfirm Then
            Dt.Rows(0).Item("State_User") = User_Display
        End If
        If Me.Mode = Mode_Enum.Add Then
            R = Dao.Purchase_Add(Dt, dtList)
        Else
            R = Dao.Purchase_Save(LId, Dt, dtList)
        End If
        If R.IsOk Then
            LId = TB_ID.Text
            LastForm.ReturnId = TB_ID.Text
            Mode = Mode_Enum.Modify
            If IfConfirm Then
                Dim msg As MsgReturn = Dao.Purchase_IfConfirm(TB_ID.Text, True)
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
        CaculateSumAmount()
        TB_ID.Text = TB_ID.Text.Trim
        TB_ID.Text = TB_ID.Text.Replace("'", "")
        If TB_ID.Text = "" Then
            ShowErrMsg(Ch_Name & "单号不能为空!", AddressOf TB_ID.Focus)
            Return False
        End If
        If (Mode = Mode_Enum.Add Or (Mode = Mode_Enum.Modify And LId <> TB_ID.Text)) AndAlso Dao.Purchase_CheckID(TB_ID.Text) Then
            ShowErrMsg(Ch_Name & "单号[" & TB_ID.Text & "]已经存在!", AddressOf TB_ID.Focus)
            Return False
        End If
        'If (CB_Supplier.IDValue) = 0 Then
        '    ShowErrMsg("客户商编号或名称不能为空!", AddressOf CB_Supplier.Focus)
        '    Return False
        'End If


        For i As Integer = Fg1.Rows.Count - 1 To 1 Step -1
            Try
                If IsNull(Fg1.Item(i, "WL_No"), "") = "" Then
                    Fg1.RemoveItem(i)
                End If
                If Val(Fg1.Item(i, "Qty")) < 0 Then
                    Fg1.Item(i, "Qty") = -Val(Fg1.Item(i, "Qty"))
                End If
                If Val(Fg1.Item(i, "Qty")) = 0 OrElse Val(Fg1.Item(i, "Amount")) = 0 Then
                    ShowErrMsg("请填写物料" & Fg1.Item(i, "WL_No") & "单价!")
                    Return False
                    'Fg1.RemoveItem(i)
                End If
                'If Me.P_F_RS_ID4 = "[ClientOrder]" Then
                '    Dim dr_Qty As DataRow() = CO_To_Purchase.Select("WL_ID=" & Fg1.Item(i, "WL_ID"))
                '    If Val(Fg1.Item(i, "Qty")) < dr_Qty(0)("Qty") Then
                '        ShowErrMsg("自动生成申购单时，物料采购数量不能少于应采购的数量!")
                '        Return False
                '    End If
                'End If
                If IsNull(Fg1.Item(i, "Supplier_Name"), "") = "" Then
                    ShowErrMsg("请填写物料" & Fg1.Item(i, "WL_No") & "供应商!")
                    Return False
                End If
            Catch ex As Exception
            End Try
        Next

        If Fg1.Rows.Count <= 1 Then
            Cmd_GoodsSel.Visible = False
            ShowErrMsg("列表不能为空!")
            Return False
        End If

        If Val(TB_UnPayed.Text) < 0 Then
            ShowErrMsg("付款不能多于单据金额!", AddressOf TB_UnPayed.Focus)
            Return False
        End If

        Me.Refresh()
        Return True
    End Function

    ''' <summary>
    ''' 验证申购物料的到货日期
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Function CheckDate() As Boolean
        For Each dr As DataRow In dtList.Rows
            Try
                If IsNull(dr("eDate").ToString, "") = "" Then
                    ShowErrMsg("物料" & dr("WL_No") & "没有确认采购到货日期，不能对该申购单进行审核操作!")
                    Return False
                Else
                    If dr("eDate") > Max_eDate Then
                        Max_eDate = dr("eDate")
                    End If
                End If
            Catch ex As Exception
            End Try
        Next
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
                Case "WL_No"
                    GetWLByNo(Fg1.Item(Fg1.RowSel, Fg1.Cols(e.Col).Index))
                Case "Price", "Qty"
                    If Me.P_F_RS_ID4 = "[ClientOrder]" Then
                        Dim dr_Qty As DataRow() = CO_To_Purchase.Select("WL_ID=" & Fg1.Item(e.Row, "WL_ID"))
                        If Val(Fg1.Item(e.Row, "Qty")) < Val(dr_Qty(0)("Qty")) Then
                            Fg1.Item(e.Row, "Qty") = Val(dr_Qty(0)("Qty"))
                            ShowErrMsg("自动生成申购单时，物料采购数量不能少于应采购的数量!")
                        Else
                            Fg1.Item(e.Row, e.Col) = Val(Fg1.Item(e.Row, e.Col))
                            CaculateSumAmount()
                            Fg1.GotoNextCell(e.Col)
                        End If
                    Else
                        If Mode = Mode_Enum.Modify AndAlso TB_ClientBill.Text <> "" Then
                            Dim dr_Qty As DataRow() = dtList.Select("WL_ID=" & Fg1.Item(e.Row, "WL_ID"))
                            If Val(Fg1.Item(e.Row, "Qty")) < Val(dr_Qty(0)("Qty")) Then
                                Fg1.Item(e.Row, "Qty") = Val(dr_Qty(0)("Qty"))
                                ShowErrMsg("该申购单由出货计划单" & TB_ClientBill.Text & "，自动生成，物料采购数量不能少于应采购的数量!")
                            Else
                                Fg1.Item(e.Row, e.Col) = Val(Fg1.Item(e.Row, e.Col))
                                CaculateSumAmount()
                                Fg1.GotoNextCell(e.Col)
                            End If
                        Else
                            Fg1.Item(e.Row, e.Col) = Val(Fg1.Item(e.Row, e.Col))
                            CaculateSumAmount()
                            Fg1.GotoNextCell(e.Col)
                        End If

                    End If
                Case Else
                    Fg1.GotoNextCell(e.Col)
            End Select
        Else
            If Fg1.Cols(e.Col).Name = "WL_No" Then
                If Fg1.LastText <> Fg1.Item(Fg1.RowSel, Fg1.Cols(e.Col).Index) Then
                    Fg1.Item(Fg1.RowSel, "WL_ID") = 0
                    Fg1.Item(Fg1.RowSel, "WL_Name") = ""
                    Fg1.Item(Fg1.RowSel, "WL_Unit") = ""
                    Fg1.Item(Fg1.RowSel, "WL_Spec") = ""
                End If
            End If
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
            Case "WL_No"
                e.ToCol = Fg1.Cols("Supplier_Name").Index
            Case "Supplier_Name"
                e.ToCol = Fg1.Cols("Price").Index
            Case "Price"
                e.ToCol = Fg1.Cols("Qty").Index
            Case "Qty", "LRemark"
                If Me.P_F_RS_ID4 = "[ClientOrder]" Then
                    If Fg1.RowSel = Fg1.Rows.Count - 1 Then
                        e.ToCol = Fg1.Cols("Qty").Index
                    Else
                        e.ToRow = e.Row + 1
                        e.ToCol = Fg1.Cols("WL_No").Index
                    End If
                Else
                    If e.Row + 2 > Fg1.Rows.Count Then
                        AddRow()
                    End If
                    e.ToRow = e.Row + 1
                    e.ToCol = Fg1.Cols("WL_No").Index
                End If

            Case Else
                e.ToCol = Fg1.Cols("Price").Index
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

    Private Sub Cmd_GoodsSel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_GoodsSel.Click
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
            '.P_F_RS_ID5 = TB_Supplier_Name.Text
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
            For i As Integer = 1 To Fg1.Rows.Count - 1
                If CStr(dr("ID")) = Fg1.Item(i, "WL_ID") And Fg1.RowSel <> i Then
                    ShowErrMsg("物料[" & IsNull(dr("WL_Name"), "") & "]已经存在!", AddressOf Fg1.Focus)
                    Exit Sub
                End If
            Next
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
            ComFun.DelBillNewID(BillType.ApplyPurchase, Bill_ID)
            Bill_Id_Date = #1/1/1999#
            GetNewID()
        End If
    End Sub

    Sub GetNewID()
        If TB_ID.ReadOnly = False Then
            If DTP_sDate.Value <> Bill_Id_Date Then
                Dim R As RetrunNewIdMsg = ComFun.GetBillNewID(BillType.ApplyPurchase, DTP_sDate.Value, Bill_ID)
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
        Dim R As New R20001_Purchase_List
        R.Start(TB_ID.Text, DoOperator)
    End Sub

#End Region

#Region "确认状态"
    ''' <summary>
    ''' 财务确认申购单
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmd_Confirm_Click(sender As Object, e As EventArgs) Handles cmd_Confirm.Click
        Fg1.FinishEditing(False)
        If CheckForm() Then
            If Mode = Mode_Enum.Add Then
                ShowConfirm("是否保存并确认新" & Ch_Name & "?", AddressOf Confirm)
            Else
                If CheckIsModify() Then
                    ShowConfirm(Ch_Name & "[" & TB_ID.Text & "] 已经被其他人修改过,是否覆盖别人的修改并且确认?", AddressOf Confirm)
                Else
                    ShowConfirm("是否保存并确认" & Ch_Name & "[" & TB_ID.Text & "] ?", AddressOf Confirm)
                End If
            End If
        End If
    End Sub

    ''' <summary>
    ''' 财务反确认申购单
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmd_UnConfirm_Click(sender As Object, e As EventArgs) Handles cmd_UnConfirm.Click
        ShowConfirm("是否反确认" & Ch_Name & " [" & TB_ID.Text & "]?", AddressOf UnConfirm)
    End Sub

    Protected Sub Confirm()
        SavePurchase(True)
    End Sub

    Protected Sub UnConfirm()
        Dim msg As MsgReturn = Dao.Purchase_IfConfirm(TB_ID.Text, False)
        If msg.IsOk Then
            Me_Refresh()
            Me.LastForm.ReturnId = TB_ID.Text
            ShowOk(msg.Msg)
        Else
            ShowErrMsg(msg.Msg)
        End If
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
        If CheckDate() Then
            ShowConfirm("是否审核" & Ch_Name & "?", AddressOf Audit)
        End If
    End Sub
    Protected Sub Audit()
        'Dim msg As MsgReturn = Dao.PurchaseState(True, TB_ID.Text)
        'If msg.IsOk Then
        '    Bill_ID = TB_ID.Text
        '    Me_Refresh()
        '    ShowOk(msg.Msg)
        'Else
        '    ShowErrMsg("保存成功,但" & msg.Msg)
        'End If

        Dim Msg As MsgReturn = Dao.PurchaseState(Enum_State_Upgrade.Audited, TB_ID.Text)
        If Msg.IsOk Then
            Try
                Dim p As New Dictionary(Of String, Object)
                p.Add("eDate", Max_eDate)
                p.Add("ID", TB_ID.Text)
                '更新申购单到货日期
                Dim Up_Date As MsgReturn = PClass.PClass.RunSQL("Update T20000_Puchase_Table set eDate=@eDate where ID=@ID", p)
                If Up_Date.IsOk Then
                    Me_Refresh()
                    LastForm.ReturnId = TB_ID.Text
                    ShowOk("申购单审核成功")
                Else
                    ShowErrMsg("申购单审核成功，但到货日期更新失败！")
                End If
            Catch ex As Exception

            End Try
        Else
            ShowErrMsg("申购单审核失败")
        End If
    End Sub

    Private Sub Cmd_UnAudit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_UnAudit.Click
        ShowConfirm("是否反审" & Ch_Name & " [" & TB_ID.Text & "]?", AddressOf UnAudit)
    End Sub

    Protected Sub UnAudit()
        Dim Msg As MsgReturn = Dao.PurchaseState(Enum_State_Upgrade.Comfirm, TB_ID.Text)
        If Msg.IsOk Then
            Me_Refresh()
            LastForm.ReturnId = TB_ID.Text
            ShowOk("申购单反审核成功")
        Else
            ShowErrMsg("申购单反审核失败")
        End If
        'Dim msg As MsgReturn = Dao.PurchaseState(False, TB_ID.Text)
        'If msg.IsOk Then
        '    Me_Refresh()
        '    Me.LastForm.ReturnId = TB_ID.Text
        '    ShowOk(msg.Msg)
        'Else
        '    ShowErrMsg(msg.Msg)
        'End If
    End Sub

    ''' <summary>
    ''' 删除按钮
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_Del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Del.Click
        ShowConfirm("是否删除" & Ch_Name & " [" & TB_ID.Text & "]?", AddressOf DelPurchase)
    End Sub

    ''' <summary>
    ''' 删除申购单
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub DelPurchase()
        Dim msg As MsgReturn = Dao.Purchase_Del(TB_ID.Text)
        If msg.IsOk Then
            LastForm.ReturnId = TB_ID.Text
            Me.Close()
        Else
            ShowErrMsg(msg.Msg)
        End If
    End Sub


    Private Sub Cmd_SetInValid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_SetInValid.Click
        ShowConfirm("是否作废" & Ch_Name & " [" & TB_ID.Text & "]?", AddressOf PurchaseInValid)
    End Sub


    Sub PurchaseInValid()
        Dim msg As MsgReturn = Dao.Purchase_InValid(TB_ID.Text, True)
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
        ShowConfirm("是否反作废" & Ch_Name & " [" & TB_ID.Text & "]?", AddressOf PurchaseValid)
    End Sub

    ''' <summary>
    ''' 作废
    ''' </summary>
    ''' <remarks></remarks>
    Sub PurchaseValid()
        Dim msg As MsgReturn = Dao.Purchase_InValid(TB_ID.Text, False)
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
            Return Dao.Purchase_CheckIsModify(LId, LastLine)
        End If
    End Function

#End Region


#Region "是否已付款"
    Private Sub CB_Supplier_Col_Sel(ByVal Col_No As String, ByVal Col_Name As String, ByVal ID As String) Handles CB_Supplier.Col_Sel
        Fg1.Item(Fg1.RowSel, "Supplier_ID") = ID
        Fg1.GotoNextCell("Supplier_Name")
        'TB_Supplier_Name.Text = Col_Name
    End Sub

    Private Sub Cmd_Payment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Payment.Click
        Fg1.FinishEditing(False)
        ShowConfirm(Ch_Name & " [" & TB_ID.Text & "]是否付款?", AddressOf SetPayment)
    End Sub

    Private Sub SetPayment()
        Dim msg As MsgReturn = Dao.Purchase_Payment(TB_ID.Text, True)
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
        Dim msg As MsgReturn = Dao.Purchase_Payment(TB_ID.Text, False)
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

    ''' <summary>
    ''' 跳转到上游客户单
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Bt_ToClientOrder_Click(sender As Object, e As EventArgs) Handles Bt_ToClientOrder.Click
        Dim F As PClass.BaseForm = PClass.PClass.LoadModifyFormByID(BillType.ClientOrder)
        With F
            .Mode = Mode_Enum.Modify
            .P_F_RS_ID = ""
            .P_F_RS_ID2 = ""
            .P_F_RS_ID4 = "[ToClientOrder]"
            .P_F_RS_ID5 = TB_ClientBill.Text
        End With
        F_RS_ID = ""
        Me.ReturnId = ""
        Me.ReturnObj = Nothing
        Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F, Me)
        AddHandler VF.ClosedX, AddressOf Me_Refresh
        VF.Show()
    End Sub
End Class

Partial Friend Class Dao
#Region "常量"
    Protected Friend Const Purchase_DB_NAME As String = "申购单"
    ''' <summary>
    ''' 删除单据
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_Purchase_DelByid As String = "Delete from T20000_Puchase_Table  where ID=@ID and State=0"
    ''' <summary>
    ''' 获取单头
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_Purchase_GetByid As String = "select top 1 * from T20000_Puchase_Table  where ID=@ID"
    ''' <summary>
    ''' 获取单头
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_Purchase_SelByid As String = "select T.*,C.Supplier_Name From (Select top 1 * from T20000_Puchase_Table where ID=@ID)  T left join T10100_Supplier C on C.ID=T.Supplier_ID"


    ''' <summary>
    ''' 获取单头 用于作废和审核
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_Purchase_GetStateByid As String = "select top 1 ID,State,State_User from T20000_Puchase_Table  where ID=@ID"
    ''' <summary>
    ''' 获取单体
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_Purchase_GetListByid As String = "select * from T20001_Puchase_List  where ID=@ID "
    ''' <summary>
    ''' 获取单体,用于显示
    ''' </summary>
    ''' <remarks></remarks>0
    Private Const SQL_Purchase_SelListByid As String = "select L.*,WL.WL_No,WL.WL_Name,WL.WL_Spec,WL.WL_Unit,s.Supplier_Name  from (select * from T20001_Puchase_List  where ID=@ID)L left join T10001_WL WL on WL.id=l.WL_ID left join T10100_Supplier s on L.Supplier_ID=s.ID  "
    ''' <summary>
    ''' 检查ID的重复性
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_Purchase_CheckID As String = "select count(*) from T20000_Puchase_Table  where ID=@ID"
    ''' <summary>
    ''' 检查ID的重复性
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_Purchase_CheckIsModify As String = "select count(*) from T20001_Puchase_List  where @ID=ID and Line=@Line"
    ''' <summary>
    ''' 审核或反审核
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_Purchase_IfAudit As String = " Update T20000_Puchase_Table set State=@State , State_User=@State_User,Audited_Date=@Audited_Date Where ID=@ID "
#End Region


#Region "单一张单内容查询"
    ''' <summary>
    ''' 获取对日报表信息
    ''' </summary>
    ''' <param name="sId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Purchase_GetById(ByVal sId As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_Purchase_GetByid, "@ID", sId)
    End Function

    ''' <summary>
    ''' 获取对日报表列表信息
    ''' </summary>
    ''' <param name="sId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Purchase_SelListById(ByVal sId As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_Purchase_SelListByid, "@ID", sId)
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
    Public Shared Function Purchase_CheckIsModify(ByVal ID As String, ByVal Line As Integer) As Boolean
        Dim P As New Dictionary(Of String, Object)
        P.Add("ID", ID)
        P.Add("Line", Line)
        Dim R As MsgReturn = SqlStrToOneStr(SQL_Purchase_CheckIsModify, P)
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
    Public Shared Function Purchase_CheckID(ByVal ID As String) As Boolean
        Dim R As MsgReturn = SqlStrToOneStr(SQL_Purchase_CheckID, "@ID", ID)
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
    Public Shared Function Purchase_Add(ByVal dtTable As DataTable, ByVal dtList As DataTable) As MsgReturn
        Dim msg As New DtListReturnMsg
        Dim R As New MsgReturn
        Dim sqlMap As New Dictionary(Of String, String)
        Dim paraMap As New Dictionary(Of String, Object)
        Dim PurchaseId As String = dtTable.Rows(0)("ID")
        Dim IsInsert As Boolean = False
        paraMap.Add("ID", PurchaseId)
        Try
            sqlMap.Add("Table", SQL_Purchase_GetByid)
            sqlMap.Add("List", SQL_Purchase_GetListByid)

            msg = SqlStrToDt(sqlMap, paraMap)
            If msg.DtList("Table").Rows.Count = 0 Then
                DvToDt(dtTable, msg.DtList("Table"), New List(Of String), True)
                DvToDt(dtList, msg.DtList("List"), New List(Of String), True)
                Dim TmSQL As String = "insert into Bill_Barcode (No_ID,NO_Type)values('" & PurchaseId & "'," & BillType.Purchase & ")"
                DtToUpDate(msg, TmSQL)
                R.Msg = "" & Purchase_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]添加成功!"
                R.IsOk = True
            Else
                R.IsOk = False
                R.Msg = "" & Purchase_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]已经存在!请双击编号文本框,获取新编号!"
            End If
            Return R
        Catch ex As Exception
            R.IsOk = False
            R.Msg = "" & Purchase_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]添加错误!"
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
    Public Shared Function Purchase_Save(ByVal LID As String, ByVal dtTable As DataTable, ByVal dtList As DataTable) As MsgReturn
        Dim msg As New DtListReturnMsg
        Dim R As New MsgReturn
        Dim sqlMap As New Dictionary(Of String, String)
        Dim paraMap As New Dictionary(Of String, Object)
        Dim PurchaseId As String = dtTable.Rows(0)("ID")
        If LID <> PurchaseId AndAlso Purchase_CheckID(PurchaseId) Then
            R.IsOk = False
            R.Msg = "" & Purchase_DB_NAME & "[" & PurchaseId & "]已经存在!请双击编号文本框,获取新编号!"
            Return R
        End If
        dtTable.Rows(0)("ID") = LID
        paraMap.Add("ID", LID)
        Try
            sqlMap.Add("Table", SQL_Purchase_GetByid)
            sqlMap.Add("List", SQL_Purchase_GetListByid)
            msg = SqlStrToDt(sqlMap, paraMap)
            If msg.DtList("Table").Rows.Count = 1 Then
                If msg.DtList("Table").Rows(0)("State") = Enum_State_Upgrade.Audited Then
                    msg.DaList("Table").Dispose()
                    msg.DaList("List").Dispose()
                    msg.Cnn.Dispose()
                    R.IsOk = False
                    R.Msg = "" & Purchase_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]已经被审核不能再修改!"
                    Return R
                End If
                If msg.DtList("Table").Rows(0)("State") = Enum_State_Upgrade.Invoid Then
                    msg.DaList("Table").Dispose()
                    msg.DaList("List").Dispose()
                    msg.Cnn.Dispose()
                    R.IsOk = False
                    R.Msg = "" & Purchase_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]已经被作废不能再修改!"
                    Return R
                End If
                DvToDt(dtList, msg.DtList("List"), New List(Of String))
                DvUpdateToDt(dtTable, msg.DtList("Table"), New List(Of String))
                Dim TmSQL As String = "Update Bill_Barcode set No_ID='" & PurchaseId & "' where No_ID='" & LID & "' and NO_Type=" & BillType.Purchase
                If LID <> PurchaseId Then
                    DtToUpDate(msg, "Update T20000_Puchase_Table set id='" & PurchaseId & "' where id='" & LID & "'" & vbCrLf & TmSQL)
                    dtTable.Rows(0)("ID") = PurchaseId
                    R.Msg = "" & Purchase_DB_NAME & "[" & LID & "]已经修改为[" & PurchaseId & "]!"
                Else
                    DtToUpDate(msg)
                    R.Msg = "" & Purchase_DB_NAME & "[" & LID & "]修改成功!"
                End If
                R.IsOk = True
            Else
                R.IsOk = False
                R.Msg = "" & Purchase_DB_NAME & "[" & LID & "]不存在"
            End If
            Return R
        Catch ex As Exception
            R.IsOk = False
            R.Msg = "" & Purchase_DB_NAME & "[" & LID & "]修改错误"
            DebugToLog(ex)
            Return R
        Finally
        End Try
    End Function

    ''' <summary>
    ''' 删除申购单
    ''' </summary>
    ''' <param name="PurchaseId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Purchase_Del(ByVal PurchaseId As String)
        Return RunSQL(SQL_Purchase_DelByid, "@ID", PurchaseId)
    End Function

    ''' <summary>
    ''' 作废申购单
    ''' </summary>
    ''' <param name="_ID"></param>
    ''' <param name="IsFei">作废还是反作废</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Purchase_InValid(ByVal _ID As String, ByVal IsFei As Boolean) As MsgReturn
        Dim msg As New DtListReturnMsg
        Dim R As New MsgReturn
        Dim sqlMap As New Dictionary(Of String, String)
        Dim paraMap As New Dictionary(Of String, Object)
        Dim IsInsert As Boolean = False
        Dim OStr As String
        Dim State As Enum_State_Upgrade = Enum_State_Upgrade.AddNew
        If IsFei Then
            OStr = "作废"
            State = Enum_State_Upgrade.Invoid
        Else
            OStr = "反作废"
        End If
        paraMap.Add("ID", _ID)
        Try
            sqlMap.Add("Table", SQL_Purchase_GetStateByid)
            msg = SqlStrToDt(sqlMap, paraMap)
            If msg.DtList("Table").Rows.Count = 1 Then
                If msg.DtList("Table").Rows(0)("State") <> Enum_State_Upgrade.Audited Then
                    If msg.DtList("Table").Rows(0)("State") <> State Then
                        msg.DtList("Table").Rows(0)("State") = State
                        msg.DtList("Table").Rows(0)("State_User") = User_Display
                        DtToUpDate(msg)
                        R.IsOk = True
                        R.Msg = "" & Purchase_DB_NAME & "[" & _ID & "]" & OStr & "成功!"
                    Else
                        R.IsOk = False
                        R.Msg = "" & Purchase_DB_NAME & "[" & _ID & "]已经被" & OStr & "!不能再" & OStr & "!"
                    End If
                Else
                    R.IsOk = False
                    R.Msg = "" & Purchase_DB_NAME & "[" & _ID & "]已经被审核,不能" & OStr & "!"
                End If
            Else
                R.IsOk = False
                R.Msg = "" & Purchase_DB_NAME & "[" & _ID & "]不存在,不能" & OStr & "!"
            End If
            Return R
        Catch ex As Exception
            R.IsOk = False
            R.Msg = "" & Purchase_DB_NAME & "[" & _ID & "]" & OStr & "错误!"
            DebugToLog(ex)
            Return R
        Finally
        End Try
    End Function

    ''' <summary>
    ''' 确认或反确认申购单
    ''' </summary>
    ''' <param name="_ID"></param>
    ''' <param name="IfConfirm">确认还是反确认</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Purchase_IfConfirm(ByVal _ID As String, ByVal IfConfirm As Boolean) As MsgReturn
        Dim paraMap As New Dictionary(Of String, Object)
        paraMap.Add("ID", _ID)
        paraMap.Add("IfConfirm", IfConfirm)
        paraMap.Add("State_User", User_Display)
        Dim R As MsgReturn = SqlStrToOneStr("P20000_Puchase_IfConfirm", paraMap, True)
        If R.IsOk Then
            If R.Msg.StartsWith("1") Then
                R.IsOk = True
            Else
                R.IsOk = False
            End If
            R.Msg = R.Msg.Substring(1)
        End If
        Return R
    End Function

    ''' <summary>
    ''' 审核或反审核
    ''' </summary>
    ''' <param name="state"></param>
    ''' <param name="_ID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function PurchaseState(ByVal state As Int32, ByVal _ID As String) As MsgReturn
        'Dim paraMap As New Dictionary(Of String, Object)
        'paraMap.Add("ID", _ID)
        'paraMap.Add("IsAudited", IsAudited)
        'paraMap.Add("State_User", User_Display)
        'Dim R As MsgReturn = SqlStrToOneStr("P20000_Puchase_Audited", paraMap, True)
        'If R.IsOk Then
        '    If R.Msg.StartsWith("1") Then
        '        R.IsOk = True
        '    Else
        '        R.IsOk = False
        '    End If
        '    R.Msg = R.Msg.Substring(1)
        'End If
        'Return R

        Dim p As New Dictionary(Of String, Object)
        p.Add("State", state)
        p.Add("State_User", User_Name)
        p.Add("Audited_Date", GetTime)
        p.Add("ID", _ID)
        Dim Msg As MsgReturn = PClass.PClass.RunSQL(SQL_Purchase_IfAudit, p)
        Return Msg
    End Function

    ''' <summary>
    ''' 付款
    ''' </summary>
    ''' <param name="_ID"></param>
    ''' <param name="IsPayment">付款还是未付款</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Purchase_Payment(ByVal _ID As String, ByVal IsPayment As Boolean) As MsgReturn
        Dim paraMap As New Dictionary(Of String, Object)
        paraMap.Add("ID", _ID)
        paraMap.Add("IsPayment", IsPayment)
        Dim R As MsgReturn = SqlStrToOneStr("Update T20000_Puchase_Table set Payment=@IsPayment where ID=@ID  ", paraMap)
        Dim s As String = IIf(IsPayment, "付款", "未付款")
        If R.IsOk Then
            R.Msg = Purchase_DB_NAME & s & "成功！"
        Else
            R.Msg = Purchase_DB_NAME & s & "失败！" & R.Msg

        End If

        Return R
    End Function














#End Region
End Class