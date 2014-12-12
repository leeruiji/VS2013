Option Compare Text
Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports PClass
Imports BaseClass
Imports PClass.CReport

Public Class F20301_StoreOut_Msg
    Dim LId As String = ""
    Dim Bill_Id_Date As Date = #1/1/1999#
    Dim dtList As DataTable
    Dim dtTable As DataTable
    Dim DtChePai As DataTable
    Dim StoreDt As DataTable
    Dim State As Enum_StroeOutstate = Enum_StroeOutstate.AddNew
    Dim IsBidings As Boolean = False
    Dim StoreOutType As Enum_StoreOut_Type
    Dim isDelivery As Boolean = False

    Public Sub New()
        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        ' 在 InitializeComponent() 调用之后添加任何初始化。
    End Sub

    Public Sub New(ByVal initID As String)
        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        ' 在 InitializeComponent() 调用之后添加任何初始化。
        Bill_Id = initID
        Me.Mode = Mode
    End Sub

    Private Sub Me_AfterLoad() Handles Me.AfterLoad
        If Fg1.Rows.Count > 1 Then
            Fg1.RowSel = 1
            Fg1.Row = 1
            Fg1.Select(1, Fg1.Cols("WL_No").Index, 1, Fg1.Cols("WL_No").Index)
        End If
        CB_Reason.Focus()
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
        Control_CheckRight(ID, ClassMain.Confirm, Cmd_Confirm)
        Control_CheckRight(ID, ClassMain.UnConfirm, Cmd_UnConfirm)
        Control_CheckRight(ID, ClassMain.SetInValid, Cmd_SetInValid)
        Control_CheckRight(ID, ClassMain.SetValid, Cmd_SetValid)
        Control_CheckRight(ID, ClassMain.Audited, Cmd_Audit)
        Control_CheckRight(ID, ClassMain.UnAudit, Cmd_UnAudit)

        Dim isShowPrice As Boolean = PClass.PClass.CheckRight(ID, ClassMain.ShowPrice)
        Dim isModifyPrice As Boolean = PClass.PClass.CheckRight(ID, ClassMain.ModifyPrice)
        Fg1.Cols("Price").Visible = isShowPrice
        Fg1.Cols("Amount").Visible = isShowPrice
        Fg1.Cols("Price").AllowEditing = isModifyPrice
        Fg1.Cols("Amount").AllowEditing = isModifyPrice
        LB_SumAmount.Visible = isShowPrice
        TB_SumAmount.Visible = isShowPrice

    End Sub



    Private Sub Form_Me_Closing(ByVal sender As Object, ByRef e As System.ComponentModel.CancelEventArgs) Handles Me.Me_Closing
        ComFun.DelBillNewID(BillType.BeiStoreOut, Bill_ID)
    End Sub

    Private Sub Form_Load() Handles Me.Me_Load


        If Bill_ID = "" AndAlso P_F_RS_ID2 <> "" Then
            Bill_ID = P_F_RS_ID
        End If

        Dim remarkType As Enum_RemarkType
        StoreOutType = Enum_StoreOut_Type.Other
        remarkType = Enum_RemarkType.StoreOut_Reason

        'Select Case ID

        '    Case 20300

        '        StoreOutType = Enum_StoreOut_Type.Other
        '        remarkType = Enum_RemarkType.StoreOut_Reason
        '        LB_ClientOrder.Visible = False
        '        TB_ClientOrderID.Visible = False
        '        ID = 20300

        '    Case 20302

        '        StoreOutType = Enum_StoreOut_Type.Other
        '        remarkType = Enum_RemarkType.StoreOut_Reason
        '        LB_ClientOrder.Visible = False
        '        TB_ClientOrderID.Visible = False
        '        ID = 20302

        '    Case 20304

        '        StoreOutType = Enum_StoreOut_Type.Other
        '        remarkType = Enum_RemarkType.StoreOut_Reason
        '        LB_ClientOrder.Visible = True
        '        TB_ClientOrderID.Visible = True
        '        ID = 20304

        'End Select
        FormCheckRight()
        Ch_Name = GetBillTypeName(ID)
        Me.Title = Ch_Name

        ''出库原因
        Dim msgReason As DtReturnMsg = BaseClass.ComFun.StoreOut_GetReason(remarkType)
        If msgReason.IsOk Then
            CB_Reason.DataSource = msgReason.Dt
            CB_Reason.ValueMember = "Remark"
            CB_Reason.DisplayMember = "Remark"
        End If
        ''车间
      
        '业务员
        Employee_List1.Set_TextBox(TB_Operator, TB_Upd_User)
        TB_Operator.Tag = "0"

        Fg1.IniFormat()
        If Me.Mode = Mode_Enum.Modify AndAlso P_F_RS_ID <> "" Then
            Me.Bill_ID = P_F_RS_ID
        End If
        Me_Refresh()

        If Mode = Mode_Enum.Add AndAlso CB_Reason.Items.Count > 0 Then
            CB_Reason.SelectedIndex = -1
            CB_Reason.SelectedIndex = 0
        End If


    End Sub

    Protected Sub Me_Refresh()


        Dim msgTable As DtReturnMsg = Dao.StoreOut_GetById(Bill_ID)
        If msgTable.IsOk Then
            If IsBidings Then
                DvUpdateToDt(msgTable.Dt, dtTable, New List(Of String))
            Else
                dtTable = msgTable.Dt
            End If

            If Mode = Mode_Enum.Modify AndAlso msgTable.Dt.Rows.Count = 0 Then
                ShowErrMsg("没有找到" & Ch_Name & "[" & Bill_ID & "]", True)
                Exit Sub
            End If
            SetForm(dtTable)
        End If
        Select Case Mode
            Case Mode_Enum.Add
                If CheckRight(ID, ClassMain.Add) = False Then Me.ShowErrMsg("没有权限添加" & Ch_Name & "!", True) : Exit Sub
                Dim msg As DtReturnMsg = Dao.StoreOut_SelListById(0)
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
                    TB_ClientOrderID.Text = Me.F_RS_ID5
                    CB_Client_ID.IDAsInt = Val(Me.F_RS_ID3)
                    CB_Client_ID.Text = CB_Client_ID.GetByTextBoxTag(CB_Client_ID.IDAsInt)
                    Fg1.DtToSetFG(DirectCast(Me.F_RS_Obj, DataTable))
                End If

            Case Mode_Enum.Modify
                Dim msg As DtReturnMsg = Dao.StoreOut_SelListById(Bill_ID)
                Cmd_Preview.Enabled = True
                Cmd_Print.Enabled = True
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


#Region "根据生产单生成列表"
    Protected Sub SetGoodsFromProduce()
        If Not Me.ReturnObj Is Nothing AndAlso Fg1.CanEditing AndAlso Fg1.RowSel > 0 Then
            Dim dt As DataTable = ReturnObj

            Fg1.Rows.Count = 1
            Fg1.CanEditing = False
            Dim i As Integer = 0
            Me.dtList.Clear()
            Dim newDr As DataRow

            For Each dr In dt.Rows
                newDr = dtList.NewRow

                newDr("WL_ID") = IsNull(dr("WL_ID"), "")
                newDr("WL_No") = IsNull(dr("WL_No"), "")
                newDr("WL_Name") = IsNull(dr("WL_Name"), "")
                newDr("WL_Unit") = IsNull(dr("WL_Unit"), "")
                newDr("WL_Spec") = IsNull(dr("WL_Spec"), "")
                newDr("Qty") = IsNull(dr("PlanQty"), "")


                newDr("Store_id") = IsNull(dr("WL_Store_ID"), 0)


                newDr("Price") = IsNull(dr("Cost"), 0)


                '    Fg1.GotoNextCell("WL_No")
                dtList.Rows.Add(newDr)
            Next
            Fg1.DtToSetFG(dtList)
            CaculateSumAmount()
            Fg1.CanEditing = True
        Else

        End If
        Me.ReturnObj = Nothing
    End Sub

#End Region

#Region "生产单选择"
    Private Sub Cmd_ProduceSel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ShowProduceSel()
    End Sub
    Protected Sub ShowProduceSel(Optional ByVal _no As String = "")
        Dim F As BaseForm = PClass.PClass.LoadFormIDToChild(30013, Me)
        If F Is Nothing Then Exit Sub
        With F
            .P_F_RS_ID = ""
            .P_F_RS_ID2 = _no
            .P_F_RS_ID3 = "WL"
            .IsSel = True
        End With
        ReturnId = ""
        Me.ReturnObj = Nothing
        Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F, Me)
        AddHandler VF.ClosedX, AddressOf SetProduce
        VF.Show()
    End Sub

    Protected Sub SetProduce()
        If ReturnId <> "" Then

            GetProduceByNo(ReturnId)

        End If
        Me.ReturnId = ""
    End Sub

    Protected Sub GetProduceByNo(ByVal _No As String)
        'Dim msg As DtReturnMsg = Dao.Produce_SelListById(TB_Produce_ID.Text)
        'Fg1.CanEditing = False
        ''  Fg1.Rows.Count = 1
        'dtList.Clear()
        'Dim newDr As DataRow
        'If msg.IsOk Then
        '    For i = 0 To msg.Dt.Rows.Count - 1
        '        newDr = dtList.NewRow
        '        newDr("WL_ID") = IsNull(msg.Dt.Rows(i)("WL_ID"), "")
        '        newDr("WL_No") = IsNull(msg.Dt.Rows(i)("WL_No"), "")
        '        newDr("WL_Name") = IsNull(msg.Dt.Rows(i)("WL_Name"), "")
        '        newDr("WL_Unit") = IsNull(msg.Dt.Rows(i)("WL_Unit"), "")
        '        newDr("WL_Spec") = IsNull(msg.Dt.Rows(i)("WL_Spec"), "")
        '        newDr("Store_ID") = IsNull(msg.Dt.Rows(i)("WL_Store_ID"), 0)
        '        newDr("Qty") = IsNull(msg.Dt.Rows(i)("PlanQty"), 0)
        '        newDr("Price") = IsNull(msg.Dt.Rows(i)("Cost"), 0)
        '        CB_Unit_LL.SelectedValue = IsNull(msg.Dt.Rows(i)("WL_Store_ID"), 0)
        '        newDr("Store_Name") = CB_Unit_LL.Text
        '        dtList.Rows.Add(newDr)
        '    Next
        '    dtList.AcceptChanges()
        '    Fg1.DtToSetFG(dtList)
        '    Fg1.ReAddIndex()
        ''    CaculateSumAmount()
        'Else
        'ShowProduceSel(_No)
        'End If
        'Fg1.CanEditing = True
    End Sub
#End Region

#Region "表单控件事件"

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
        dr("Operator") = Val(TB_Operator.Tag)
        dr("State") = State
        dr("ClientOrder_ID") = TB_ClientOrderID.Text
        dr("Client_ID") = CB_Client_ID.IDAsInt
        dt.AcceptChanges()
        dtList = dtList.Clone
        For i As Integer = 1 To Fg1.Rows.Count - 1
            dr = dtList.NewRow
            dr("ID") = ID
            dr("WL_ID") = Fg1.Item(i, "WL_ID")
            dr("Price") = Fg1.Item(i, "Price")
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
        Dim CreatDelivery As Boolean = False

        If dt Is Nothing Then
            Exit Sub
        End If

        Dim Dr As DataRow
        If dt.Rows.Count = 0 Then
            Dr = dt.NewRow
            Dr("State_User") = ""
            Dr("Remark") = ""
            Dr("ID") = ""
            Dr("sDate") = ServerTime.Date
            Dr("SumAmount") = 0
            Dr("isDelivery") = False
            Cmd_Confirm.Visible = Cmd_Confirm.Tag
            Cmd_Confirm.Enabled = True
            Cmd_UnConfirm.Visible = False
            Cmd_UnConfirm.Enabled = False

            Cmd_SetValid.Visible = False
            Cmd_SetValid.Enabled = False
            Cmd_SetInValid.Visible = Cmd_SetInValid.Tag
            Cmd_SetInValid.Enabled = False
            Cmd_Del.Enabled = False

            Cmd_Audit.Visible = Cmd_Audit.Tag
            Cmd_Audit.Enabled = False
            Cmd_UnAudit.Visible = False
            Cmd_UnAudit.Enabled = False

            CreatDelivery = False

            LabelState.Text = "新建"
            LabelState.ForeColor = Color.Black
            dt.Rows.Add(Dr)
            dt.AcceptChanges()
            LockForm(False)
        Else
            Dr = dt.Rows(0)
            State = Dr("State")

            Select Case State
                Case Enum_StroeOutstate.AddNew '新建
                    LabelState.Text = "新建"
                    LabelState.ForeColor = Color.Black
                    Cmd_Modify.Enabled = Cmd_Modify.Tag

                    Cmd_Confirm.Visible = Cmd_Confirm.Tag
                    Cmd_Confirm.Enabled = True
                    Cmd_UnConfirm.Visible = False
                    Cmd_UnConfirm.Enabled = False
                    CB_Reason.Enabled = True

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

                    CreatDelivery = False

                    LockForm(False)

                Case Enum_StroeOutstate.Invoid '作废
                    LabelState.Text = "已作废"
                    LabelState.ForeColor = Color.Red
                    Cmd_Modify.Enabled = False

                    Cmd_Confirm.Visible = Cmd_Confirm.Tag
                    Cmd_Confirm.Enabled = False
                    Cmd_UnConfirm.Visible = False
                    Cmd_UnConfirm.Enabled = False

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

                   CreatDelivery = False


                    LockForm(True)

                Case Enum_StroeOutstate.Comfirm '确认
                    TB_ID.ReadOnly = True
                    CB_Reason.Enabled = False

                    LabelState.Text = "已确认"
                    LabelState.ForeColor = Color.Blue
                    Cmd_Modify.Enabled = False

                    Cmd_RemoveRow.Enabled = False
                    Cmd_AddRow.Enabled = False
                    Cmd_Del.Enabled = False

                    Cmd_Confirm.Visible = False
                    Cmd_Confirm.Enabled = False
                    Cmd_UnConfirm.Visible = Cmd_UnConfirm.Tag
                    Cmd_UnConfirm.Enabled = True

                    Cmd_SetValid.Visible = False
                    Cmd_SetValid.Enabled = False
                    Cmd_SetInValid.Visible = Cmd_SetInValid.Tag
                    Cmd_SetInValid.Enabled = False

                    Cmd_Audit.Visible = Cmd_Audit.Tag
                    Cmd_Audit.Enabled = True
                    Cmd_UnAudit.Visible = False
                    Cmd_UnAudit.Enabled = False

                     CreatDelivery = False


                    LockForm(True)


                Case Enum_StroeOutstate.Audited '审核
                    TB_ID.ReadOnly = True
                    CB_Reason.Enabled = False

                    LabelState.Text = "已审核"
                    LabelState.ForeColor = Color.Blue
                    Cmd_Modify.Enabled = False

                    Cmd_RemoveRow.Enabled = False
                    Cmd_AddRow.Enabled = False
                    Cmd_Del.Enabled = False

                    Cmd_Confirm.Visible = False
                    Cmd_Confirm.Enabled = False
                    Cmd_UnConfirm.Visible = Cmd_UnConfirm.Tag
                    Cmd_UnConfirm.Enabled = False

                    Cmd_SetValid.Visible = False
                    Cmd_SetValid.Enabled = False
                    Cmd_SetInValid.Visible = Cmd_SetInValid.Tag
                    Cmd_SetInValid.Enabled = False

                    Cmd_Audit.Visible = Cmd_Audit.Tag
                    Cmd_Audit.Enabled = False
                    Cmd_UnAudit.Visible = True
                    Cmd_UnAudit.Enabled = True

                    CreatDelivery = True

                    LockForm(True)
            End Select
        End If
        If IsBidings = False Then
            TB_ID.DataBindings.Add("Text", dtTable, TB_ID.Name.Substring(3), False, DataSourceUpdateMode.OnPropertyChanged)
            DTP_sDate.DataBindings.Add("Value", dtTable, DTP_sDate.Name.Substring(4), False, DataSourceUpdateMode.OnPropertyChanged, ServerTime.Date, "yyyy-MM-dd")
            TB_Remark.DataBindings.Add("Text", dtTable, TB_Remark.Name.Substring(3), False, DataSourceUpdateMode.OnPropertyChanged, "")
            TB_SumQty.DataBindings.Add("Text", dtTable, TB_SumQty.Name.Substring(3), True, DataSourceUpdateMode.OnPropertyChanged, 0, FormatSharp("num"))
            TB_SumAmount.DataBindings.Add("Text", dtTable, TB_SumAmount.Name.Substring(3), True, DataSourceUpdateMode.OnPropertyChanged, 0, FormatSharp("money"))
            TB_State_User.DataBindings.Add("Text", dtTable, TB_State_User.Name.Substring(3), False, DataSourceUpdateMode.OnPropertyChanged, "")
            TB_Upd_User.DataBindings.Add("Text", dtTable, TB_Upd_User.Name.Substring(3), False, DataSourceUpdateMode.OnPropertyChanged, "")
            CB_Reason.DataBindings.Add("Text", dtTable, CB_Reason.Name.Substring(3), False, DataSourceUpdateMode.OnPropertyChanged, "")

            IsBidings = True
        End If
        Employee_List1.GetByTextBoxTag(IsNull(dtTable.Rows(0)("Operator"), "0"))
        TB_ClientOrderID.Text = IsNull(dtTable.Rows(0)("ClientOrder_ID"), "")
        CB_Client_ID.IDAsInt = IsNull(dtTable.Rows(0)("Client_ID"), 0)
        CB_Client_ID.Text = CB_Client_ID.GetByTextBoxTag(CB_Client_ID.IDAsInt)


        isDelivery = IsNull(dtTable.Rows(0)("isDelivery"), False)
        Dim CheckQty As DtReturnMsg = Dao.GetDeliveryQty(TB_ID.Text)
        If CheckQty.IsOk AndAlso CheckQty.Dt.Rows.Count > 0 Then
            cmd_CreateD.Visible = CreatDelivery And False
            cmd_CreateD.Enabled = CreatDelivery And False
            LB_Delivery.Visible = True
            LB_DeliveryID.Visible = True
            LB_DeliveryID.Text = CheckQty.Dt.Rows(0)("ID")
        Else
            cmd_CreateD.Visible = CreatDelivery And True
            cmd_CreateD.Enabled = CreatDelivery And True
            LB_Delivery.Visible = False
            LB_DeliveryID.Visible = False
        End If

    End Sub

    Sub LockForm(ByVal Lock As Boolean)
        TB_ID.ReadOnly = Lock
        DTP_sDate.Enabled = Not Lock
        Cmd_AddRow.Enabled = Not Lock
        Cmd_RemoveRow.Enabled = Not Lock
        CB_Reason.Enabled = Not Lock
        Fg1.CanEditing = Not Lock
        Fg1.IsClickStartEdit = Not Lock
        TB_Operator.ReadOnly = Lock
        TB_Remark.ReadOnly = Lock

    End Sub


    ''' <summary>
    ''' FG合计
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub CaculateSumAmount()
        If Fg1.Rows.Count <= 1 Then
            TB_SumQty.Text = 0
            TB_SumAmount.Text = 0

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
                ShowConfirm("是否保存新" & Ch_Name & "?", AddressOf SaveStoreOut)
            Else
                If CheckIsModify() Then
                    ShowConfirm(Ch_Name & "[" & TB_ID.Text & "] 已经被其他人修改过,是否覆盖别人的修改?", AddressOf SaveStoreOut)
                Else
                    ShowConfirm("是否保存" & Ch_Name & "[" & TB_ID.Text & "] 的修改?", AddressOf SaveStoreOut)
                End If
            End If
        End If
    End Sub

    ''' <summary>
    ''' 保存修改
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub SaveStoreOut(Optional ByVal Confirm As Boolean = False)
        Dim R As MsgReturn
        Dim Dt As DataTable = GetForm()
        Dt.Rows(0).Item("StoreOutType") = Me.StoreOutType
        If Me.Mode = Mode_Enum.Add Then
            R = Dao.StoreOut_Add(Dt, dtList)
        Else
            R = Dao.StoreOut_Save(LId, Dt, dtList)
        End If
        If R.IsOk Then
            LId = TB_ID.Text
            LastForm.ReturnId = TB_ID.Text
            Mode = Mode_Enum.Modify
            If Confirm Then
                Dim msg As MsgReturn = Dao.StoreOut_Confirmed(TB_ID.Text, True)
                If msg.IsOk Then
                    Bill_Id = TB_ID.Text
                    Me_Refresh()
                    ShowOk(msg.Msg)
                Else
                    ShowErrMsg("保存成功,但" & msg.Msg)
                End If
                Exit Sub
            End If
            If TB_ID.Text = Bill_Id.Replace("-", "") Then Bill_Id = ""
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
        If (Mode = Mode_Enum.Add Or (Mode = Mode_Enum.Modify And LId <> TB_ID.Text)) AndAlso Dao.StoreOut_CheckID(TB_ID.Text) Then
            ShowErrMsg(Ch_Name & "单号[" & TB_ID.Text & "]已经存在!", AddressOf TB_ID.Focus)
            Return False
        End If

        'If CB_Reason.Text = "" Then
        '    ShowErrMsg("出库原因不能为空!", AddressOf CB_Reason.Focus)
        '    Return False
        'End If

      
        Dim CheckQrQty As Boolean = False
        For i As Integer = 1 To Fg1.Rows.Count - 1
            Dim QrQty As Decimal = Dao.GetquantityQty(TB_ClientOrderID.Text, Fg1.Item(i, "WL_ID"))
            If Fg1.Item(i, "Qty") > QrQty Then
                Fg1.Item(i, "OldQty") = Fg1.Item(i, "Qty")
                Fg1.Item(i, "Qty") = QrQty
                CheckQrQty = True
            End If
        Next


        If CheckQrQty = True Then
            Fg1.Cols("OldQty").StyleNew.ForeColor = Color.Blue
            Fg1.Cols("OldQty").Visible = True
            ShowErrMsg("备货数不能大于订单剩余数!")
            Return False
        End If


        Dim CheckQty As Boolean = False
        For i As Integer = 1 To Fg1.Rows.Count - 1
            Dim CKQty As Decimal = ComFun.GetWLQty(Fg1.Item(i, "WL_ID"))
            If Fg1.Item(i, "Qty") > CKQty Then
                Fg1.Item(i, "OldQty") = Fg1.Item(i, "Qty")
                Fg1.Item(i, "Qty") = CKQty
                CheckQty = True
            End If
        Next

        If CheckQty = True Then
            Fg1.Cols("OldQty").StyleNew.ForeColor = Color.Blue
            Fg1.Cols("OldQty").Visible = True
            ShowErrMsg("备货数不能大于库存数!")
            Return False
        End If


        For i As Integer = Fg1.Rows.Count - 1 To 1 Step -1
            Try
                If Val(Fg1.Item(i, "Qty")) = 0 OrElse Val(Fg1.Item(i, "WL_ID")) = 0 Then
                    Fg1.RemoveItem(i)
                End If
                If Val(Fg1.Item(i, "Qty")) < 0 Then
                    ShowErrMsg("物料[" & Fg1.Item(i, "WL_Name") & "]备货数量不能为负数")
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

    Private Sub CB_Store_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Fg1_AfterScroll(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RangeEventArgs) Handles Fg1.AfterScroll
        ShowGoodsSelCmd()
    End Sub

    Private Sub Fg1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Fg1.Click

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
                Case "Price"

                    Fg1.Item(e.Row, e.Col) = Val(Fg1.Item(e.Row, e.Col))
                    CaculateSumAmount()
                    Fg1.GotoNextCell(e.Col)
                Case "Qty"
                    Fg1.Item(e.Row, e.Col) = Val(Fg1.Item(e.Row, e.Col))
                    CaculateSumAmount()
                    Fg1.GotoNextCell(e.Col)

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
            Else
                Select Case Fg1.Cols(e.Col).Name

                    Case "Price"

                        CaculateSumAmount()

                End Select
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
            Case "Price"
                e.ToCol = Fg1.Cols("Qty").Index
            Case "Qty", "LRemark"

                If e.Row + 2 > Fg1.Rows.Count Then
                    AddRow()
                End If
                e.ToRow = e.Row + 1
                e.ToCol = Fg1.Cols("WL_No").Index
            Case Else
                If Fg1.Cols("Price").AllowEditing Then
                    e.ToCol = Fg1.Cols("Price").Index
                Else
                    e.ToCol = Fg1.Cols("Qty").Index
                End If
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
        'If Fg1.Cols(Fg1.ColSel).AllowEditing AndAlso Fg1.CanEditing Then
        '    Fg1.LastKey = 0
        '    Fg1.StartEditing()
        'End If
        ShowGoodsSelCmd()
    End Sub

    Private Sub Fg1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Fg1.KeyDown
        If Fg1.RowSel < 0 Then
            Exit Sub
        End If
        If Fg1.Cols(Fg1.ColSel).AllowEditing = False Then
            If e.KeyCode = Keys.Enter Then
                If Fg1.ColSel < Fg1.Cols("Qty").Index Then
                    Fg1.StartEditing(Fg1.RowSel, Fg1.Cols("Qty").Index)
                Else
                    Fg1.StartEditing(Fg1.RowSel, Fg1.Cols("Remark").Index)
                End If
            ElseIf e.KeyCode = Keys.Add AndAlso Fg1.Cols(Fg1.ColSel).Name = "WL_No" Then
                ShowGoodsSel()
            End If
        End If
    End Sub

    Private Sub Fg1_KeyDownEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.KeyEditEventArgs) Handles Fg1.KeyDownEdit
        If e.KeyCode = Keys.Add AndAlso Fg1.Cols("WL_No").Index = e.Col AndAlso Fg1.CanEditing Then
            ShowGoodsSel()
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
        ShowGoodsSel()
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
            Fg1.FinishEditing(True)
            Fg1.Item(Fg1.RowSel, "WL_ID") = IsNull(dr("ID"), "")
            Fg1.Item(Fg1.RowSel, "WL_No") = IsNull(dr("WL_No"), "")
            Fg1.Item(Fg1.RowSel, "WL_Name") = IsNull(dr("WL_Name"), "")
            '   Fg1.Item(Fg1.RowSel, "WL_Spec") = IsNull(dr("WL_Spec"), "")
            '   Fg1.Item(Fg1.RowSel, "Price") = IsNull(dr("WL_Price"), "")
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
            ComFun.DelBillNewID(BillType.BeiStoreOut, Bill_ID)
            Bill_Id_Date = #1/1/1999#
            GetNewID()
        End If
    End Sub

    Sub GetNewID()
        Dao.StoreOut_DB_NAME = Ch_Name
        If TB_ID.ReadOnly = False Then
            If DTP_sDate.Value <> Bill_Id_Date Then
                Dim R As RetrunNewIdMsg = ComFun.GetBillNewID(BillType.BeiStoreOut, DTP_sDate.Value, Bill_ID)
                If R.IsOk Then
                    Bill_Id_Date = R.NewIdDate
                    DTP_sDate.MinDate = R.MaxDate.AddDays(1)
                    DTP_sDate.Value = R.NewIdDate
                    Bill_Id = R.NewID
                    TB_ID.Text = Bill_Id.Replace("-", "")
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

        Dim R As New R20300_StoreOut
        R.Start(TB_ID.Text, DoOperator, Me.StoreOutType)
    End Sub

#End Region

#Region "确认状态"
    ''' <summary>
    ''' 确认状态
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_Confirm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Confirm.Click
        Fg1.FinishEditing(False)
        If CheckForm() Then
            If Mode = Mode_Enum.Add Then
                ShowConfirm("是否保存并确认新" & Ch_Name & "?", AddressOf Shenhe)
            Else
                If CheckIsModify() Then
                    ShowConfirm(Ch_Name & "[" & TB_ID.Text & "] 已经被其他人修改过,是否覆盖别人的修改并且确认?", AddressOf Shenhe)
                Else
                    ShowConfirm("是否保存并确认" & Ch_Name & "[" & TB_ID.Text & "] ?", AddressOf Shenhe)
                End If
            End If
        End If
    End Sub
    Protected Sub Shenhe()
        SaveStoreOut(True)
    End Sub

    Private Sub Cmd_UnConfirm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_UnConfirm.Click
        ShowConfirm("是否反审" & Ch_Name & " [" & TB_ID.Text & "]?", AddressOf UnConfirm)
    End Sub

    Protected Sub UnConfirm()
        Dao.StoreOut_DB_NAME = Ch_Name
        Dim msg As MsgReturn = Dao.StoreOut_Confirmed(TB_ID.Text, False)
        If msg.IsOk Then
            ShowOk(msg.Msg)
            Me_Refresh()
            Me.LastForm.ReturnId = TB_ID.Text
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
        ShowConfirm("是否删除" & Ch_Name & " [" & TB_ID.Text & "]?", AddressOf DelStoreOut)
    End Sub

    ''' <summary>
    ''' 删除出库单
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub DelStoreOut()
        Dao.StoreOut_DB_NAME = Ch_Name
        Dim msg As MsgReturn = Dao.StoreOut_Del(TB_ID.Text)
        If msg.IsOk Then
            LastForm.ReturnId = TB_ID.Text
            Me.Close()
        Else
            ShowErrMsg(msg.Msg)
        End If
    End Sub


    Private Sub Cmd_SetInValid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_SetInValid.Click
        ShowConfirm("是否作废" & Ch_Name & " [" & TB_ID.Text & "]?", AddressOf StoreOutInValid)
    End Sub


    Sub StoreOutInValid()
        Dao.StoreOut_DB_NAME = Ch_Name
        Dim msg As MsgReturn = Dao.StoreOut_InValid(TB_ID.Text, True)
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
        ShowConfirm("是否反作废" & Ch_Name & " [" & TB_ID.Text & "]?", AddressOf StoreOutValid)
    End Sub

    ''' <summary>
    ''' 作废
    ''' </summary>
    ''' <remarks></remarks>
    Sub StoreOutValid()
        Dao.StoreOut_DB_NAME = Ch_Name
        Dim msg As MsgReturn = Dao.StoreOut_InValid(TB_ID.Text, False)
        If msg.IsOk Then
            Me_Refresh()
            LastForm.ReturnId = TB_ID.Text
        Else
            ShowErrMsg(msg.Msg)
        End If
    End Sub



    Private Sub Cmd_Aduit_Click(sender As Object, e As EventArgs) Handles Cmd_Audit.Click
        ShowConfirm("是否审核" & Ch_Name & "?", AddressOf Audit)
    End Sub

    ''' <summary>
    ''' 审核
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Audit()
        Dim Msg As MsgReturn = Dao.StoreOut_Audit(TB_ID.Text, True)
        If Msg.IsOk Then
            Me_Refresh()
            LastForm.ReturnId = TB_ID.Text
            ShowOk("备货单审核成功")
        Else
            ShowErrMsg("备货单审核失败")
        End If
    End Sub


    Private Sub Cmd_UnAduit_Click(sender As Object, e As EventArgs) Handles Cmd_UnAudit.Click
        ShowConfirm("是否反审核" & Ch_Name & "?", AddressOf UnAudit)
    End Sub


    ''' <summary>
    ''' 反审核
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub UnAudit()
        Dim Msg As MsgReturn = Dao.StoreOut_Audit(TB_ID.Text, False)
        If Msg.IsOk Then
            Me_Refresh()
            LastForm.ReturnId = TB_ID.Text
            ShowOk("备货反审核成功")
        Else
            ShowErrMsg("备货单反审核失败")
        End If
    End Sub



#End Region

#Region "检查其他人有没有修改过"
    Private LastLine As Integer = 0
    Private Function CheckIsModify() As Boolean
        If Mode <> Mode_Enum.Add Then
            Return Dao.StoreOut_CheckIsModify(LId, LastLine)
        End If
    End Function

#End Region

    ''' <summary>
    ''' 生成送货单
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_CreateD_Click(sender As Object, e As EventArgs) Handles cmd_CreateD.Click


        If CheckCreate(State) Then
            Dim Dt As DataTable = GetSelWL()
            If Dt Is Nothing OrElse Dt.Rows.Count = 0 Then
                ShowErrMsg("没有要备的货物不能生成送货单,请重新选择!")
            Else
                CreateTable(BillType.Delivery, Dt)
            End If
        End If

    End Sub


    ''' <summary>
    ''' 判断是否可以开单据
    ''' </summary>
    ''' <remarks></remarks>
    Private Function CheckCreate(ByVal State As Enum_StroeOutstate) As Boolean
        Dim Re As Boolean = False
        If State >= Enum_StroeOutstate.Comfirm Then
            Re = True
        End If
        Return Re
    End Function



 


    ''' <summary>
    '''自动生动指定单据
    ''' </summary>
    ''' <param name="BillType"></param>
    ''' <remarks></remarks>
    Private Sub CreateTable(ByVal BillType As BillType, ByVal ReDt As DataTable)

        Dim F As PClass.BaseForm = PClass.PClass.LoadModifyFormByID(BillType)
        If F Is Nothing Then Exit Sub
        With F
            .Mode = Mode_Enum.Add
            .P_F_RS_ID = ""
            .P_F_RS_ID2 = ""
            .P_F_RS_ID4 = "[StoreOut]"
            .P_F_RS_ID5 = TB_ID.Text
            .P_F_RS_Obj = ReDt
        End With
        F_RS_ID = ""
        Me.ReturnId = ""
        Me.ReturnObj = Nothing
        Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F, Me)
        AddHandler VF.ClosedX, AddressOf Me_Refresh
        VF.Show()
    End Sub





    ''' <summary>
    ''' 获取选择物料
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetSelWL() As DataTable
        Dim WLTable As New DataTable
        Dim SQty As Integer = 0
        WLTable.Columns.Add("WL_ID", GetType(Integer))
        WLTable.Columns.Add("WL_No", GetType(String))
        WLTable.Columns.Add("WL_Name", GetType(String))
        WLTable.Columns.Add("WL_Spec", GetType(String))
        WLTable.Columns.Add("Qty", GetType(Decimal))
        WLTable.Columns.Add("Price", GetType(Decimal))
        WLTable.Columns.Add("Amount", GetType(Decimal))
        Dim DR As DataRow = WLTable.NewRow
        For i As Integer = 1 To Fg1.Rows.Count - 1
            DR = WLTable.NewRow
            DR("WL_ID") = Fg1.Item(i, "WL_ID")
            DR("WL_No") = Fg1.Item(i, "WL_No")
            DR("WL_Name") = Fg1.Item(i, "WL_Name")
            DR("WL_Spec") = Fg1.Item(i, "WL_Spec")
            DR("Price") = Fg1.Item(i, "Price")
            DR("Qty") = Fg1.Item(i, "Qty")
            DR("Amount") = Fg1.Item(i, "Amount")
            WLTable.Rows.Add(DR)
        Next
        Return WLTable
    End Function

End Class





Partial Friend Class Dao

#Region "常量"
    Protected Friend Shared StoreOut_DB_NAME As String = "出库单"
    ''' <summary>
    ''' 删除单据
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_StoreOut_DelByid As String = "Delete from T20300_StoreOut_Table  where ID=@ID and State=0"
    ''' <summary>
    ''' 获取单头
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_StoreOut_GetByid As String = "select top 1 * from T20300_StoreOut_Table  where ID=@ID "
    ''' <summary>
    ''' 获取单头
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_StoreOut_SelByid As String = "select top 1 S.*,E.Employee_Name as OperatorName ,W.Dept_Name as Dept_Name from T20300_StoreOut_Table S  left join T15001_Employee E on S.Operator=E.ID left join T15000_Department W on S.Dept_No=W.Dept_No where S.ID=@ID"


    ''' <summary>
    ''' 获取单头 用于作废和确认
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_StoreOut_GetStateByid As String = "select top 1 ID,State,State_User from T20300_StoreOut_Table  where ID=@ID"
    ''' <summary>
    ''' 获取单体
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_StoreOut_GetListByid As String = "select * from T20301_StoreOut_List  where ID=@ID "
    ''' <summary>
    ''' 获取单体,用于显示
    ''' </summary>
    ''' <remarks></remarks>0
    Private Const SQL_StoreOut_SelListByid As String = "select L.*,L.WL_Unit_LL as WL_Unit_LL2,WL.WL_No,WL.WL_Name,WL.WL_Spec from (select * from T20301_StoreOut_List  where ID=@ID)L left join T10001_WL WL on WL.id=l.WL_ID  "
    ''' <summary>
    ''' 检查ID的重复性
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_StoreOut_CheckID As String = "select count(*) from T20300_StoreOut_Table  where ID=@ID"

    ''' <summary>
    ''' 获取加工单列表,用于显示
    ''' </summary>
    ''' <remarks></remarks>0

    Private Const SQL_Produce_SelListByid As String = "select L.*,WL.WL_No,WL.WL_Name,WL.WL_Spec,WL.WL_Unit,WL.WL_Store_ID from (select * from T30011_Produce_List  where ID=@ID)L left join T10001_WL WL on WL.id=l.WL_id  where isnull(WL_Ignore,0)=0 order by WL.WL_Type_ID,WL.WL_Name"

    ''' <summary>
    ''' 检查ID的重复性
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_StoreOut_CheckIsModify As String = "select count(*) from T20301_StoreOut_List  where ID=@ID and Line=@Line"

    ''' <summary>
    ''' 检查订单剩余量
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_GetqyQty As String = "Select  Isnull(Qty,0)-Isnull(BeiQty,0) As Qty  from  T27001_ClientOrder_List Where ID=@ID AND WL_ID=@WL_ID    "



    ''' <summary>
    ''' 检查备货单有多少单送货单
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQLStroreOutGetDeliverQty As String = "select ID from T27200_Delivery_Table Where BeiHuo_ID=@ID and state>-1    "


#End Region

#Region "单一张单内容查询"
    ''' <summary>
    ''' 获取对出库单信息
    ''' </summary>
    ''' <param name="sId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function StoreOut_GetById(ByVal sId As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_StoreOut_GetByid, "@ID", sId)
    End Function

    ''' <summary>
    ''' 获取对出库单列表信息
    ''' </summary>
    ''' <param name="sId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function StoreOut_SelListById(ByVal sId As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_StoreOut_SelListByid, "@ID", sId)
    End Function



    ''' <summary>
    ''' 查查当前有多少张出货单
    ''' </summary>
    ''' <param name="id"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetDeliveryQty(ByVal id As String) As DtReturnMsg
        Dim s As DtReturnMsg = PClass.PClass.SqlStrToDt(SQLStroreOutGetDeliverQty, "@ID", id)
        Return s
    End Function



    ''' <summary>
    ''' 获取指定订单指定物料的剩余数量
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetquantityQty(ByVal orderID As String, ByVal WL_id As Integer) As Decimal
        Dim ReQty As Decimal = 0
        Dim p As New Dictionary(Of String, Object)
        p.Add("ID", orderID)
        p.Add("WL_ID", WL_id)
        Dim DtMsg As DtReturnMsg = PClass.PClass.SqlStrToDt(SQL_GetqyQty, p)
        If DtMsg.IsOk AndAlso DtMsg.Dt.Rows.Count = 1 Then
            ReQty = DtMsg.Dt.Rows(0)("Qty")
        End If
        Return ReQty
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
    Public Shared Function StoreOut_CheckIsModify(ByVal ID As String, ByVal Line As Integer) As Boolean
        Dim P As New Dictionary(Of String, Object)
        P.Add("ID", ID)
        P.Add("Line", Line)
        Dim R As MsgReturn = SqlStrToOneStr(SQL_StoreOut_CheckIsModify, P)
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
    Public Shared Function StoreOut_CheckID(ByVal ID As String) As Boolean
        Dim R As MsgReturn = SqlStrToOneStr(SQL_StoreOut_CheckID, "@ID", ID)
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
    ''' 添加出库单
    ''' </summary>
    ''' <param name="dtTable"></param>
    ''' <param name="dtList"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function StoreOut_Add(ByVal dtTable As DataTable, ByVal dtList As DataTable) As MsgReturn
        Dim msg As New DtListReturnMsg
        Dim R As New MsgReturn
        Dim sqlMap As New Dictionary(Of String, String)
        Dim paraMap As New Dictionary(Of String, Object)
        Dim StoreOutId As String = dtTable.Rows(0)("ID")
        Dim IsInsert As Boolean = False
        paraMap.Add("ID", StoreOutId)
        Try

            If IsNull(dtTable.Rows(0)("Produce_ID"), "") <> "" Then
                Dim Rx As MsgReturn = CallByID(30010, "Produce_CheckCanRef", dtTable.Rows(0)("Produce_ID"))
                If Rx.IsOk = False Then
                    R.IsOk = False
                    R.Msg = StoreOut_DB_NAME & "[" & StoreOutId & "]添加失败!" & vbCrLf & Rx.Msg
                    Return R
                End If
            End If

            sqlMap.Add("Table", SQL_StoreOut_GetByid)
            sqlMap.Add("List", SQL_StoreOut_GetListByid)
            msg = SqlStrToDt(sqlMap, paraMap)
            If msg.DtList("Table").Rows.Count = 0 Then
                DvToDt(dtTable, msg.DtList("Table"), New List(Of String), True)
                DvToDt(dtList, msg.DtList("List"), New List(Of String), True)
                Dim TmSQL As String = "insert into Bill_Barcode (No_ID,NO_Type)values('" & StoreOutId & "'," & BillType.BeiStoreOut & ")"
                DtToUpDate(msg, TmSQL)
                R.Msg = "" & StoreOut_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]添加成功!"
                R.IsOk = True
            Else
                R.IsOk = False
                R.Msg = "" & StoreOut_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]已经存在!请双击编号文本框,获取新编号!"
            End If
            Return R
        Catch ex As Exception
            R.IsOk = False
            R.Msg = "" & StoreOut_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]添加错误!"
            DebugToLog(ex)
            Return R
        Finally
        End Try
    End Function

    ''' <summary>
    ''' 修改出库单
    ''' </summary>
    ''' <param name="dtTable"></param>
    ''' <param name="dtList"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function StoreOut_Save(ByVal LID As String, ByVal dtTable As DataTable, ByVal dtList As DataTable) As MsgReturn
        Dim msg As New DtListReturnMsg
        Dim R As New MsgReturn
        Dim sqlMap As New Dictionary(Of String, String)
        Dim paraMap As New Dictionary(Of String, Object)
        Dim StoreOutId As String = dtTable.Rows(0)("ID")
        If LID <> StoreOutId AndAlso StoreOut_CheckID(StoreOutId) Then
            R.IsOk = False
            R.Msg = "" & StoreOut_DB_NAME & "[" & StoreOutId & "]已经存在!请双击编号文本框,获取新编号!"
            Return R
        End If
        dtTable.Rows(0)("ID") = LID
        paraMap.Add("ID", LID)

        If IsNull(dtTable.Rows(0)("Produce_ID"), "") <> "" Then
            Dim Rx As MsgReturn = CallByID(30010, "Produce_CheckCanRef", dtTable.Rows(0)("Produce_ID"))
            If Rx.IsOk = False Then
                R.IsOk = False
                R.Msg = StoreOut_DB_NAME & "[" & StoreOutId & "]添加失败!" & vbCrLf & Rx.Msg
                Return R
            End If
        End If

        Try
            sqlMap.Add("Table", SQL_StoreOut_GetByid)
            sqlMap.Add("List", SQL_StoreOut_GetListByid)
            msg = SqlStrToDt(sqlMap, paraMap)
            If msg.DtList("Table").Rows.Count = 1 Then


                If msg.DtList("Table").Rows(0)("State") = Enum_StroeOutstate.Comfirm Then
                    msg.DaList("Table").Dispose()
                    msg.DaList("List").Dispose()
                    msg.Cnn.Dispose()
                    R.IsOk = False
                    R.Msg = "" & StoreOut_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]已经被确认不能再修改!"
                    Return R
                End If
                If msg.DtList("Table").Rows(0)("State") = Enum_StroeOutstate.Invoid Then
                    msg.DaList("Table").Dispose()
                    msg.DaList("List").Dispose()
                    msg.Cnn.Dispose()
                    R.IsOk = False
                    R.Msg = "" & StoreOut_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]已经被作废不能再修改!"
                    Return R
                End If
                DvToDt(dtList, msg.DtList("List"), New List(Of String))
                DvUpdateToDt(dtTable, msg.DtList("Table"), New List(Of String))
                Dim TmSQL As String = "Update Bill_Barcode set No_ID='" & StoreOutId & "' where No_ID='" & LID & "' and NO_Type=" & BillType.BeiStoreOut
                If LID <> StoreOutId Then
                    DtToUpDate(msg, "Update T20300_StoreOut_Table set id='" & StoreOutId & "' where id='" & LID & "'" & vbCrLf & TmSQL)
                    dtTable.Rows(0)("ID") = StoreOutId
                    R.Msg = "" & StoreOut_DB_NAME & "[" & LID & "]已经修改为[" & StoreOutId & "]!"
                Else
                    DtToUpDate(msg)
                    R.Msg = "" & StoreOut_DB_NAME & "[" & LID & "]修改成功!"
                End If
                R.IsOk = True
            Else
                R.IsOk = False
                R.Msg = "" & StoreOut_DB_NAME & "[" & LID & "]不存在"
            End If
            Return R
        Catch ex As Exception
            R.IsOk = False
            R.Msg = "" & StoreOut_DB_NAME & "[" & LID & "]修改错误"
            DebugToLog(ex)
            Return R
        Finally
        End Try
    End Function

    ''' <summary>
    ''' 删除出库单
    ''' </summary>
    ''' <param name="StoreOutId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function StoreOut_Del(ByVal StoreOutId As String)
        Return RunSQL(SQL_StoreOut_DelByid, "@ID", StoreOutId)
    End Function

    ''' <summary>
    ''' 作废出库单
    ''' </summary>
    ''' <param name="_ID"></param>
    ''' <param name="IsFei">作废还是反作废</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function StoreOut_InValid(ByVal _ID As String, ByVal IsFei As Boolean) As MsgReturn
        Dim msg As New DtListReturnMsg
        Dim R As New MsgReturn
        Dim sqlMap As New Dictionary(Of String, String)
        Dim paraMap As New Dictionary(Of String, Object)
        Dim IsInsert As Boolean = False
        Dim OStr As String
        Dim State As Enum_StroeOutstate = Enum_StroeOutstate.AddNew
        If IsFei Then
            OStr = "作废"
            State = Enum_StroeOutstate.Invoid
        Else
            OStr = "反作废"
        End If
        paraMap.Add("ID", _ID)
        Try
            sqlMap.Add("Table", SQL_StoreOut_GetStateByid)
            msg = SqlStrToDt(sqlMap, paraMap)
            If msg.DtList("Table").Rows.Count = 1 Then
                If msg.DtList("Table").Rows(0)("State") <> Enum_StroeOutstate.Comfirm OrElse msg.DtList("Table").Rows(0)("State") <> Enum_StroeOutstate.Audited Then
                    If msg.DtList("Table").Rows(0)("State") <> State Then
                        msg.DtList("Table").Rows(0)("State") = State
                        msg.DtList("Table").Rows(0)("State_User") = User_Display
                        DtToUpDate(msg)
                        R.IsOk = True
                        R.Msg = "" & StoreOut_DB_NAME & "[" & _ID & "]" & OStr & "成功!"
                    Else
                        R.IsOk = False
                        R.Msg = "" & StoreOut_DB_NAME & "[" & _ID & "]已经被" & OStr & "!不能再" & OStr & "!"
                    End If
                Else
                    R.IsOk = False
                    R.Msg = "" & StoreOut_DB_NAME & "[" & _ID & "]已经被确认,不能" & OStr & "!"
                End If
            Else
                R.IsOk = False
                R.Msg = "" & StoreOut_DB_NAME & "[" & _ID & "]不存在,不能" & OStr & "!"
            End If
            Return R
        Catch ex As Exception
            R.IsOk = False
            R.Msg = "" & StoreOut_DB_NAME & "[" & _ID & "]" & OStr & "错误!"
            DebugToLog(ex)
            Return R
        Finally
        End Try
    End Function

    ''' <summary>
    ''' 确认出库单
    ''' </summary>
    ''' <param name="_ID"></param>
    ''' <param name="IsConfirmed">确认还是反确认</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function StoreOut_Confirmed(ByVal _ID As String, ByVal IsConfirmed As Boolean) As MsgReturn
        Dim paraMap As New Dictionary(Of String, Object)
        paraMap.Add("ID", _ID)
        paraMap.Add("IsConfirmed", IsConfirmed)
        paraMap.Add("State_User", User_Display)

        Dim R As MsgReturn = SqlStrToOneStr("P20300_StoreOut_Confirmed", paraMap, True)
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

#End Region










End Class