Option Compare Text
Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports PClass
Imports BaseClass
Imports PClass.CReport

Public Class F27001_ClientOrder_Msg
    Dim LId As String = ""
    Dim Bill_Id_Date As Date = #1/1/1999#
    Dim dtList As DataTable
    Dim dtTable As DataTable
    Dim DtChePai As DataTable
    Dim StoreDt As DataTable
    Dim State As Enum_State = Enum_State_Upgrade.AddNew
    Dim IsBidings As Boolean = False
    Dim Purchase_State As Boolean = False
    Dim ConDDate As Boolean = False

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
        TB_ID.Focus()
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
        Control_CheckRight(ID, ClassMain.CreateDan, Cmd_CreateDan)
        Control_CheckRight(ID, ClassMain.ConfirmDeliveryDate, Cmd_ConDDate)
        Control_CheckRight(ID, ClassMain.UnConfirmDeliveryDate, Cmd_UConDDate)
    End Sub

    Private Sub Form_Me_Closing(ByVal sender As Object, ByRef e As System.ComponentModel.CancelEventArgs) Handles Me.Me_Closing
        ComFun.DelBillNewID(BillType.ClientOrder, Bill_ID)
    End Sub

    Private Sub Form_Load() Handles Me.Me_Load

        If Bill_ID = "" AndAlso P_F_RS_ID <> "" Then
            Bill_ID = P_F_RS_ID
        End If

        FormCheckRight()
        Ch_Name = GetBillTypeName(ID)
        Me.Title = Ch_Name & "列表"

        Fg1.IniFormat()
        If Me.Mode = Mode_Enum.Modify AndAlso P_F_RS_ID <> "" Then
            Me.Bill_ID = P_F_RS_ID

        End If
        Me_Refresh()

    End Sub

    Protected Sub Me_Refresh()
        If Me.P_F_RS_ID4 = "[ToClientOrder]" Then
            Bill_ID = Me.P_F_RS_ID5
        End If
        Dim msgTable As DtReturnMsg = Dao.ClientOrder_GetById(Bill_ID)
        If msgTable.IsOk Then
            If IsSel Then
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
                Dim msg As DtReturnMsg = Dao.ClientOrder_SelListById(0)
                If msg.IsOk Then dtList = msg.Dt
                Fg1.Rows.Count = 2
                Fg1.ReAddIndex()
                TB_Upd_User.Text = User_Display
                DTP_sDate.Value = GetDate()
                DTP_eDate.Value = GetDate()
                LabelTitle.Text = "新建" & Me.Ch_Name
                Cmd_Preview.Enabled = False
                Cmd_Print.Enabled = False
                GetNewID()

            Case Mode_Enum.Modify
                Dim msg As DtReturnMsg = Dao.ClientOrder_SelListById(Bill_ID)
                Cmd_Preview.Enabled = True
                Cmd_Print.Enabled = True
                Dim dtList2 As DataTable
                If msg.IsOk Then
                    dtList = msg.Dt
                    dtList2 = msg.Dt
                    LastLine = msg.Dt.Rows(0)("Line")
                    Fg1.Cols("isSel").Visible = True
                    dtList2 = msg.Dt.Clone
                    If dtList2.Columns.Contains("isSel") = False Then dtList2.Columns.Add("isSel", GetType(Boolean))
                    dtList2.Columns.Add("Assemble_No", GetType(String))
                    dtList2.Columns.Add("Assemble_ID", GetType(Integer))
                    Dim dr As DataRow
                    For Each dr_Assemble As DataRow In msg.Dt.Rows
                        Dim IsAssemble As Boolean = dr_Assemble("IsAssemble")
                        dr = dtList2.NewRow
                        dr("isSel") = False
                        dr("WL_ID") = dr_Assemble("WL_ID")
                        dr("WL_No") = dr_Assemble("WL_No")
                        dr("WL_Name") = IsNull(dr_Assemble("WL_Name"), "")
                        dr("WL_Spec") = IsNull(dr_Assemble("WL_Spec"), "")
                        dr("Qty") = Val(IsNull(dr_Assemble("Qty"), 0))
                        dr("WL_Qty") = Val(IsNull(dr_Assemble("WL_Qty"), 0))
                        dr("WL_ApproveQty") = Val(IsNull(dr_Assemble("WL_ApproveQty"), 0))
                        dr("WL_material") = IsNull(dr_Assemble("WL_material"), "")
                        dr("WL_Center") = IsNull(dr_Assemble("WL_Center"), "")
                        dr("WL_side") = IsNull(dr_Assemble("WL_side"), "")
                        dr("WL_Unit") = IsNull(dr_Assemble("WL_Unit"), "")
                        dr("Wl_Price") = IsNull(dr_Assemble("Wl_Price"), "")
                        dr("RWL_No") = IsNull(dr_Assemble("RWL_No"), "")
                        dr("RWL_Qty") = Val(IsNull(dr_Assemble("RWL_Qty"), 0))
                        dr("BeiQty") = IsNull(dr_Assemble("BeiQty"), 0)
                        dtList2.Rows.Add(dr)
                        If IsAssemble Then
                            Dim dt_Assemble As DtReturnMsg = Dao.Assemble_SelListById(dr_Assemble("WL_No"))
                            For Each dr_Assemble_list As DataRow In dt_Assemble.Dt.Rows
                                dr = dtList2.NewRow
                                dr("WL_ID") = dr_Assemble("WL_ID")
                                dr("Assemble_ID") = dr_Assemble_list("ID")
                                dr("Assemble_No") = dr_Assemble_list("Assemble_No")
                                dr("WL_Name") = IsNull(dr_Assemble_list("WL_Name"), "")
                                dr("WL_Spec") = IsNull(dr_Assemble_list("WL_Spec"), "")
                                dr("Qty") = Val(IsNull(dr_Assemble("Qty"), 0)) * Val(IsNull(dr_Assemble_list("Assemble_Amount"), 0))
                                dr("BeiQty") = Val(IsNull(dr_Assemble("BeiQty"), 0)) * Val(IsNull(dr_Assemble_list("Assemble_Amount"), 0))
                                dr("WL_Qty") = Val(IsNull(dr_Assemble_list("WL_Qty"), 0))
                                dr("WL_ApproveQty") = Val(IsNull(dr_Assemble_list("WL_ApproveQty"), 0))
                                dr("WL_material") = IsNull(dr_Assemble_list("WL_material"), "")
                                dr("WL_Center") = IsNull(dr_Assemble_list("WL_Center"), "")
                                dr("WL_side") = IsNull(dr_Assemble_list("WL_side"), "")
                                dr("WL_Unit") = IsNull(dr_Assemble_list("WL_Unit"), "")
                                dr("Wl_Price") = IsNull(dr_Assemble_list("Wl_Price"), "")
                                dr("RWL_No") = IsNull(dr_Assemble_list("RWL_No"), "")
                                dr("RWL_Qty") = Val(IsNull(dr_Assemble_list("RWL_Qty"), 0))
                                dr("IsAssemble") = True
                                dtList2.Rows.Add(dr)
                            Next
                        End If
                    Next
                    dtList2.AcceptChanges()
                    Fg1.DtToSetFG(dtList2)
                    '''根据采购单是否已确定采购日期
                    If Not Purchase_State Then
                        Dim PurchaseWL As DataTable = GetPurchaseWL()
                        If PurchaseWL.Rows.Count = 0 Then
                            LB_Purchase_State.Text = "无需进行申购"
                        End If
                    Else
                        LB_PMaxDate.Visible = True
                        Dim msg_MaxDate As DtReturnMsg = Dao.Get_MaxDate(Bill_ID)
                        If msg_MaxDate.IsOk AndAlso msg_MaxDate.Dt.Rows.Count > 1 Then
                            DTP_PDate.Visible = True
                            DTP_PDate.Value = msg_MaxDate.Dt.Rows(0)("Max_eDate")
                        Else
                            LB_PMaxDate.Text = msg_MaxDate.Msg
                        End If
                    End If
                End If
                LId = TB_ID.Text
                LabelTitle.Text = "修改" & Me.Ch_Name
        End Select
        'CaculateSumAmount()
        dtTable.AcceptChanges()
        dtList.AcceptChanges()
        'If Me.Mode = Mode_Enum.Add Then
        '    If Not Me.ReturnObj Is Nothing Then
        '        SetGoodsFromProduce()
        '    End If
        'End If
    End Sub

    'Sub GetDtMsg()
    '    StoreDt = ComFun.GetStoreDt()
    '    CB_Store.DataSource = StoreDt
    'End Sub
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
                'newDr("WL_Unit") = IsNull(dr("WL_Unit"), "")
                'newDr("WL_Spec") = IsNull(dr("WL_Spec"), "")
                'newDr("Qty") = IsNull(dr("PlanQty"), "")

                dtList.Rows.Add(newDr)
            Next
            Fg1.DtToSetFG(dtList)
            'CaculateSumAmount()
            Fg1.CanEditing = True
        Else

        End If
        Me.ReturnObj = Nothing
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
        dr("ID") = ID
        dr("State") = State
        dr("Client_ID") = IsNull(CB_Client_ID.IDAsInt, 0)

        dt.AcceptChanges()
        dtList = dtList.Clone
        For i As Integer = 1 To Fg1.Rows.Count - 1
            If Fg1.Item(i, "IsAssemble") = False Then
                dr = dtList.NewRow
                dr("ID") = ID
                dr("WL_ID") = Fg1.Item(i, "WL_ID")
                dr("WL_material") = Fg1.Item(i, "WL_material")
                dr("WL_Center") = Fg1.Item(i, "WL_Center")
                dr("Qty") = Val(Fg1.Item(i, "Qty"))
                dr("WL_side") = Fg1.Item(i, "WL_side")
                'dr("Qty_Store") = dr("Qty") * ComFun.Unit_Convert(Fg1.Item(i, "WL_Unit_LL"), Fg1.Item(i, "WL_Unit_LL2"))
                'dr("Amount") = Fg1.Item(i, "Amount")
                dr("LRemark") = Fg1.Item(i, "LRemark")
                dtList.Rows.Add(dr)
            End If
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

        Dim Dr As DataRow
        If dt.Rows.Count = 0 Then
            Dr = dt.NewRow
            Dr("State_User") = ""
            Dr("Remark") = ""
            Dr("ID") = ""
            Dr("sDate") = ServerTime.Date
            Dr("eDate") = ServerTime.Date
            Cmd_Audit.Visible = Cmd_Audit.Tag
            Cmd_Audit.Enabled = True
            Cmd_UnAudit.Visible = False
            Cmd_UnAudit.Enabled = False

            Cmd_SetValid.Visible = False
            Cmd_SetValid.Enabled = False
            Cmd_SetInValid.Visible = Cmd_SetInValid.Tag
            Cmd_SetInValid.Enabled = False
            Cmd_Del.Enabled = False
            Cmd_ConDDate.Visible = False
            Cmd_UConDDate.Visible = False
            LB_eDate_State.Visible = False
            LB_Purchase_State.Visible = False
            LabelState.Text = "新建"
            LabelState.ForeColor = Color.Black
            dt.Rows.Add(Dr)
            dt.AcceptChanges()
            LockForm(False)
        Else
            Dr = dt.Rows(0)
            State = Dr("State")
            Purchase_State = IsNull(Dr("Purchase_State"), False)
            ConDDate = IsNull(Dr("ConDDate"), False)
            Cmd_ConDDate.Visible = Not ConDDate
            Cmd_UConDDate.Visible = ConDDate
            Cmd_CreatePurchase.Enabled = Not Purchase_State
            Cmd_CreateProduce.Enabled = ConDDate
            Cmd_CreateAssemble.Enabled = ConDDate
            LB_Purchase_State.Visible = True
            If ConDDate Then
                LB_eDate_State.Text = "已确认送货日期"
            Else
                LB_eDate_State.Text = "未确认送货日期"
            End If
            If Purchase_State Then
                Fg1.Cols("Qty").AllowEditing = False
                LB_Purchase_State.Text = "已申购"
            Else
                LB_Purchase_State.Text = "未申购"
            End If
            Cmd_Del.Visible = False
            Select Case State
                Case Enum_State.AddNew '新建
                    LabelState.Text = "新建"
                    LabelState.ForeColor = Color.Black
                    Cmd_Modify.Enabled = Cmd_Modify.Tag
                    Cmd_Del.Enabled = True


                    Cmd_Audit.Visible = Cmd_Audit.Tag
                    Cmd_Audit.Enabled = True
                    Cmd_UnAudit.Visible = False
                    Cmd_UnAudit.Enabled = False
                    Cmd_ConDDate.Enabled = True
                    Cmd_UConDDate.Enabled = True
                    Cmd_SetValid.Visible = False
                    Cmd_SetValid.Enabled = False
                    Cmd_SetInValid.Visible = Cmd_SetInValid.Tag
                    Cmd_SetInValid.Enabled = True
                    Cmd_Del.Visible = Cmd_Del.Tag
                    LockForm(False)
                    DTP_eDate.Enabled = Not ConDDate
                Case Enum_State.Invoid '作废
                    LabelState.Text = "已作废"
                    LabelState.ForeColor = Color.Red
                    Cmd_Modify.Enabled = False
                    Cmd_Del.Enabled = False
                    Cmd_ConDDate.Enabled = False
                    Cmd_UConDDate.Enabled = False
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
                    Cmd_Del.Enabled = False
                    Cmd_ConDDate.Enabled = False
                    Cmd_UConDDate.Enabled = False
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
            'CB_Client_No.DataBindings.Add("Text", dtTable, CB_Client_No.Name.Substring(3), False, DataSourceUpdateMode.OnPropertyChanged)
            TB_Client_Name.DataBindings.Add("Text", dtTable, TB_Client_Name.Name.Substring(3), False, DataSourceUpdateMode.OnPropertyChanged)
            DTP_sDate.DataBindings.Add("Value", dtTable, DTP_sDate.Name.Substring(4), False, DataSourceUpdateMode.OnPropertyChanged, ServerTime.Date, "yyyy-MM-dd")
            DTP_eDate.DataBindings.Add("Value", dtTable, DTP_eDate.Name.Substring(4), False, DataSourceUpdateMode.OnPropertyChanged, ServerTime.Date, "yyyy-MM-dd")
            TB_Remark.DataBindings.Add("Text", dtTable, TB_Remark.Name.Substring(3), False, DataSourceUpdateMode.OnPropertyChanged, "")
            'TB_SumQty.DataBindings.Add("Text", dtTable, TB_SumQty.Name.Substring(3), True, DataSourceUpdateMode.OnPropertyChanged, 0, FormatSharp("num"))
            TB_State_User.DataBindings.Add("Text", dtTable, TB_State_User.Name.Substring(3), False, DataSourceUpdateMode.OnPropertyChanged, "")
            TB_Upd_User.DataBindings.Add("Text", dtTable, TB_Upd_User.Name.Substring(3), False, DataSourceUpdateMode.OnPropertyChanged, "")
            IsBidings = True
        End If

        CB_Client_ID.IDAsInt = IsNull(dtTable.Rows(0)("Client_ID"), 0)
        CB_Client_ID.Text = CB_Client_ID.GetByTextBoxTag(CB_Client_ID.IDAsInt)




    End Sub

    Sub LockForm(ByVal Lock As Boolean)
        TB_ID.ReadOnly = Lock
        'DTP_sDate.Enabled = Not Lock
        DTP_eDate.Enabled = Not Lock
        Cmd_AddRow.Enabled = Not Lock
        Cmd_RemoveRow.Enabled = Not Lock
        Fg1.CanEditing = Not Lock
        Fg1.IsClickStartEdit = Not Lock
        TB_Remark.ReadOnly = Lock
    End Sub


    ''' <summary>
    ''' FG合计
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub CaculateSumAmount()
        If Fg1.Rows.Count <= 1 Then
            TB_SumQty.Text = 0

            Exit Sub
        End If
        Dim SumQty As Double = 0
        Dim SumAmount As Double = 0
        For R As Integer = 1 To Fg1.Rows.Count - 1
            'Fg1.Item(R, "Amount") = Val(Fg1.Item(R, "Qty")) * Val(Fg1.Item(R, "Price"))
            'SumAmount = SumAmount + Val(Fg1.Item(R, "Amount"))
            SumQty = SumQty + Val(Fg1.Item(R, "Qty"))
        Next
        TB_SumQty.Text = FormatNum(SumQty)

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
                ShowConfirm("是否保存新" & Ch_Name & "?", AddressOf SaveClientOrder)
            Else
                If CheckIsModify() Then
                    ShowConfirm(Ch_Name & "[" & TB_ID.Text & "] 已经被其他人修改过,是否覆盖别人的修改?", AddressOf SaveClientOrder)
                Else
                    ShowConfirm("是否保存" & Ch_Name & "[" & TB_ID.Text & "] 的修改?", AddressOf SaveClientOrder)
                End If
            End If
        End If
    End Sub

    ''' <summary>
    ''' 保存修改
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub SaveClientOrder(Optional ByVal Audit As Boolean = False)
        Dim R As MsgReturn
        Dim Dt As DataTable = GetForm()
        If Audit Then
            Dt.Rows(0).Item("State_User") = User_Display
        End If
        If Me.Mode = Mode_Enum.Add Then
            R = Dao.ClientOrder_Add(Dt, dtList)
        Else
            R = Dao.ClientOrder_Save(LId, Dt, dtList)
        End If
        If R.IsOk Then
            LId = TB_ID.Text
            LastForm.ReturnId = TB_ID.Text
            Mode = Mode_Enum.Modify
            If Audit Then
                Dim msg As MsgReturn = Dao.ClientOrder_Audited(TB_ID.Text, True)
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
        'CaculateSumAmount()
        TB_ID.Text = TB_ID.Text.Trim
        TB_ID.Text = TB_ID.Text.Replace("'", "")
        If TB_ID.Text = "" Then
            ShowErrMsg(Ch_Name & "单号不能为空!", AddressOf TB_ID.Focus)
            Return False
        End If
        If (Mode = Mode_Enum.Add Or (Mode = Mode_Enum.Modify And LId <> TB_ID.Text)) AndAlso Dao.ClientOrder_CheckID(TB_ID.Text) Then
            ShowErrMsg(Ch_Name & "单号[" & TB_ID.Text & "]已经存在!", AddressOf TB_ID.Focus)
            Return False
        End If


        If CB_Client_ID.IDAsInt = 0 Then
            ShowErrMsg("请选择客户")
            Return False
        End If

        'If ConDDate = False AndAlso Mode = Mode_Enum.Modify Then
        '    ShowErrMsg("未确认送货日期")
        '    Return False
        'End If

        For i As Integer = Fg1.Rows.Count - 1 To 1 Step -1
            Try
                If Fg1.Item(i, "IsAssemble") = False AndAlso Val(Fg1.Item(i, "Qty")) = 0 OrElse Val(Fg1.Item(i, "WL_ID")) = 0 Then
                    Fg1.RemoveItem(i)
                End If
                If Val(Fg1.Item(i, "Qty")) < 0 Then
                    Fg1.Item(i, "Qty") = -Val(Fg1.Item(i, "Qty"))
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
    ''' 验证信息
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Function Audit_CheckForm() As Boolean
        'CaculateSumAmount()
        TB_ID.Text = TB_ID.Text.Trim
        TB_ID.Text = TB_ID.Text.Replace("'", "")
        If TB_ID.Text = "" Then
            ShowErrMsg(Ch_Name & "单号不能为空!", AddressOf TB_ID.Focus)
            Return False
        End If
        If (Mode = Mode_Enum.Add Or (Mode = Mode_Enum.Modify And LId <> TB_ID.Text)) AndAlso Dao.ClientOrder_CheckID(TB_ID.Text) Then
            ShowErrMsg(Ch_Name & "单号[" & TB_ID.Text & "]已经存在!", AddressOf TB_ID.Focus)
            Return False
        End If


        If CB_Client_ID.IDAsInt = 0 Then
            ShowErrMsg("请选择客户")
            Return False
        End If

        If ConDDate = False AndAlso Mode = Mode_Enum.Modify Then
            ShowErrMsg("未确认送货日期")
            Return False
        End If

        For i As Integer = Fg1.Rows.Count - 1 To 1 Step -1
            Try
                If Fg1.Item(i, "IsAssemble") = False AndAlso Val(Fg1.Item(i, "Qty")) = 0 OrElse Val(Fg1.Item(i, "WL_ID")) = 0 Then
                    Fg1.RemoveItem(i)
                End If
                If Val(Fg1.Item(i, "Qty")) < 0 Then
                    Fg1.Item(i, "Qty") = -Val(Fg1.Item(i, "Qty"))
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

    Private Sub Fg1_AfterScroll(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RangeEventArgs)
        ShowGoodsSelCmd()
    End Sub

    'Private Sub Fg1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Fg1.Click
    '    If Fg1.CanEditing = False Then Exit Sub
    '    If Fg1.Editor Is Nothing Then
    '        If Fg1.RowSel < 0 Then
    '            Exit Sub
    '        End If
    '        If Fg1.Cols(Fg1.ColSel).AllowEditing AndAlso Fg1.CanEditing Then
    '            Fg1.LastKey = 0
    '            Fg1.StartEditing()
    '        End If
    '    End If
    'End Sub
    Private Sub Fg1_AfterEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs)
        If e.Row <= 0 Then
            Exit Sub
        End If
        Try
            If Fg1.LastKey = Keys.Enter Then
                Fg1.LastKey = 0
                Dim Work_No As String = Fg1.Item(Fg1.RowSel, "WL_No")
                Select Case Fg1.Cols(e.Col).Name
                    Case "WL_No"
                        For i As Integer = 1 To Fg1.Rows.Count - 1
                            If i <> Fg1.RowSel AndAlso Work_No.ToUpper = Fg1.Item(i, "WL_No") Then
                                ShowErrMsg("重复选择物料" & Work_No.ToUpper & "!")
                                Exit Sub
                            End If
                        Next
                        GetWLByNo(Fg1.Item(Fg1.RowSel, Fg1.Cols(e.Col).Index))
                        'Fg1.GotoNextCell(e.Col)
                        'Case "Price"
                        '    '修改当前单价时，当修改后单价不等于成本价时，修改成本价
                        '    'Dim p As Double = Fg1.Item(Fg1.RowSel, "Price") / ComFun.Unit_Convert(Fg1.Item(Fg1.RowSel, "WL_Unit_LL"), Fg1.Item(Fg1.RowSel, "WL_Unit_LL2"))
                        '    'If p <> Val(Fg1.Item(Fg1.RowSel, "Cost")) Then
                        '    '    Fg1.Item(Fg1.RowSel, "Cost") = p
                        '    'End If
                        '    ' Fg1.Item(Fg1.RowSel, "Cost") = Fg1.Item(Fg1.RowSel, "Price") / ComFun.Unit_Convert(Fg1.Item(Fg1.RowSel, "WL_Unit_LL"), Fg1.Item(Fg1.RowSel, "WL_Unit_LL2"))
                        '    Fg1.Item(e.Row, e.Col) = Val(Fg1.Item(e.Row, e.Col))
                        '    CaculateSumAmount()
                        '    Fg1.GotoNextCell(e.Col)
                    Case "Qty"
                        Dim WL_ID As Integer = Fg1.Item(e.Row, "WL_ID")
                        Dim dt_IsAssemble As DtReturnMsg = Dao.WL_GetByID(WL_ID)
                        If dt_IsAssemble.IsOk AndAlso dt_IsAssemble.Dt.Rows(0)("IsAssemble") = True Then
                            Dim WL_No As String = dt_IsAssemble.Dt.Rows(0)("WL_No")
                            Dim dt_Assemble As DtReturnMsg = Dao.Assemble_SelListByNo(WL_No)
                            For Each dr As DataRow In dt_Assemble.Dt.Rows
                                Dim Assemble_No As String = dr("Assemble_No")
                                Dim Assemble_Amount As Double = dr("Assemble_Amount")
                                For i As Integer = 1 To Fg1.Rows.Count - 1
                                    If Fg1.Item(i, "Assemble_No") = Assemble_No AndAlso Fg1.Item(i, "WL_ID") = WL_ID Then
                                        Fg1.Item(i, "Qty") = Val(Fg1.Item(e.Row, e.Col)) * Assemble_Amount
                                    End If
                                Next
                            Next
                            Fg1.Item(e.Row, e.Col) = Val(Fg1.Item(e.Row, e.Col))
                            Fg1.GotoNextCell("Assemble_No")
                        Else
                            Fg1.Item(e.Row, e.Col) = Val(Fg1.Item(e.Row, e.Col))
                            Fg1.GotoNextCell(e.Col)
                        End If
                        'Fg1.Item(e.Row, e.Col) = Val(Fg1.Item(e.Row, e.Col))
                        'CaculateSumAmount()
                        'Fg1.GotoNextCell(e.Col)
                        'Case "WL_Unit_LL"
                        '    '转换单位是，也转换单价
                        '    Fg1.Item(Fg1.RowSel, "Price") = Val(Fg1.Item(Fg1.RowSel, "Cost")) * ComFun.Unit_Convert(Fg1.Item(Fg1.RowSel, "WL_Unit_LL"), Fg1.Item(Fg1.RowSel, "WL_Unit_LL2"))
                        '    Fg1.GotoNextCell(e.Col)
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
                    'Else
                    '    Select Case Fg1.Cols(e.Col).Name

                    '        Case "Price"
                    '            '修改当前单价时，当修改后单价不等于成本价时，修改成本价
                    '            Dim p As Double = Fg1.Item(Fg1.RowSel, "Price") / ComFun.Unit_Convert(Fg1.Item(Fg1.RowSel, "WL_Unit_LL"), Fg1.Item(Fg1.RowSel, "WL_Unit_LL2"))
                    '            If p <> Val(Fg1.Item(Fg1.RowSel, "Cost")) Then
                    '                Fg1.Item(Fg1.RowSel, "Cost") = p
                    '            End If

                    '            CaculateSumAmount()

                    '        Case "WL_Unit_LL"
                    '            '转换单位是，也转换单价
                    '            Fg1.Item(Fg1.RowSel, "Price") = Val(Fg1.Item(Fg1.RowSel, "Cost")) * ComFun.Unit_Convert(Fg1.Item(Fg1.RowSel, "WL_Unit_LL"), Fg1.Item(Fg1.RowSel, "WL_Unit_LL2"))

                    '    End Select
                End If
            End If

        Catch ex As Exception

        End Try
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
    Private Sub Fg1_NextCell(ByVal e As PClass.FG.NextCellEventArgs)
        Select Case e.Col
            Case "WL_No"
                e.ToCol = Fg1.Cols("Qty").Index
            Case "Qty", "LRemark"

                If e.Row + 2 > Fg1.Rows.Count Then
                    AddRow()
                End If
                e.ToRow = e.Row + 1
                e.ToCol = Fg1.Cols("WL_No").Index
            Case "Assemble_No"

            Case Else
                'If Fg1.Cols("Price").AllowEditing Then
                '    e.ToCol = Fg1.Cols("Price").Index
                'Else
                'e.ToCol = Fg1.Cols("Qty").Index
                'End If
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
        ShowGoodsSelCmd()
    End Sub

    Private Sub Fg1_EnterCell(ByVal sender As Object, ByVal e As System.EventArgs)
        If Fg1.RowSel < 0 Then
            Exit Sub
        End If
        'If Fg1.Cols(Fg1.ColSel).AllowEditing AndAlso Fg1.CanEditing Then
        '    Fg1.LastKey = 0
        '    Fg1.StartEditing()
        'End If
        ShowGoodsSelCmd()
    End Sub

    Private Sub Fg1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
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

    Private Sub Fg1_KeyDownEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.KeyEditEventArgs)
        If e.KeyCode = Keys.Add AndAlso Fg1.Cols("WL_No").Index = e.Col AndAlso Fg1.CanEditing Then
            ShowGoodsSel()
        End If
    End Sub

    Private Sub FG1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If Fg1.ColSel = Fg1.Cols("isSel").Index Then
            Fg1.Item(Fg1.RowSel, "isSel") = Not Fg1.Item(Fg1.RowSel, "isSel")
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
                    Case "WL_No"
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
            Dim IsAssemble As Boolean = dr("IsAssemble")
            Fg1.FinishEditing(True)
            Dim Work_No As String = dr("WL_No")
            For i As Integer = 1 To Fg1.Rows.Count - 1
                If i <> Fg1.RowSel AndAlso Work_No.ToUpper = Fg1.Item(i, "WL_No") Then
                    ShowErrMsg("重复选择物料" & Work_No.ToUpper & "!")
                    Exit Sub
                End If
            Next
            If IsAssemble Then
                Dim dt_Assemble As DtReturnMsg = Dao.Assemble_SelListById(IsNull(dr("WL_No"), ""))
                If dt_Assemble.IsOk AndAlso dt_Assemble.Dt.Rows.Count > 0 Then
                    Fg1.Item(Fg1.RowSel, "WL_ID") = IsNull(dr("ID"), "")
                    Fg1.Item(Fg1.RowSel, "WL_No") = IsNull(dr("WL_No"), "")
                    'Fg1.Item(Fg1.RowSel, "RWL_No") = IsNull(dr("RWL_No"), "")
                    Fg1.Item(Fg1.RowSel, "WL_Name") = IsNull(dr("WL_Name"), "")
                    Fg1.Item(Fg1.RowSel, "WL_Spec") = IsNull(dr("WL_Spec"), "")
                    Fg1.Item(Fg1.RowSel, "WL_Unit") = IsNull(dr("WL_Unit"), "")
                    Fg1.Item(Fg1.RowSel, "Wl_Price") = IsNull(dr("Wl_Price"), "")
                    Fg1.Item(Fg1.RowSel, "WL_Qty") = Val(IsNull(dr("WL_Qty"), 0))
                    Fg1.Item(Fg1.RowSel, "WL_ApproveQty") = Val(IsNull(dr("WL_ApproveQty"), 0))
                    'Fg1.Item(Fg1.RowSel, "RWL_Qty") = Val(IsNull(dr("RWL_Qty"), 0))
                    Fg1.GotoNextCell("Qty")
                    For Each dr_Assemble As DataRow In dt_Assemble.Dt.Rows
                        Fg1.Item(Fg1.RowSel, "WL_ID") = IsNull(dr("ID"), "")
                        Fg1.Item(Fg1.RowSel, "Assemble_ID") = IsNull(dr_Assemble("ID"), "")
                        Fg1.Item(Fg1.RowSel, "Assemble_No") = IsNull(dr_Assemble("Assemble_No"), "")
                        Fg1.Item(Fg1.RowSel, "WL_Name") = IsNull(dr_Assemble("WL_Name"), "")
                        Fg1.Item(Fg1.RowSel, "WL_Spec") = IsNull(dr_Assemble("WL_Spec"), "")
                        Fg1.Item(Fg1.RowSel, "WL_Qty") = Val(IsNull(dr_Assemble("WL_Qty"), 0))
                        Fg1.Item(Fg1.RowSel, "WL_ApproveQty") = Val(IsNull(dr_Assemble("WL_ApproveQty"), 0))
                        Fg1.Item(Fg1.RowSel, "WL_material") = IsNull(dr_Assemble("WL_material"), "")
                        Fg1.Item(Fg1.RowSel, "WL_Center") = IsNull(dr_Assemble("WL_Center"), "")
                        Fg1.Item(Fg1.RowSel, "WL_side") = IsNull(dr_Assemble("WL_side"), "")
                        Fg1.Item(Fg1.RowSel, "WL_Unit") = IsNull(dr_Assemble("WL_Unit"), "")
                        Fg1.Item(Fg1.RowSel, "Wl_Price") = IsNull(dr_Assemble("Wl_Price"), "")
                        Fg1.Item(Fg1.RowSel, "RWL_No") = IsNull(dr_Assemble("RWL_No"), "")
                        Fg1.Item(Fg1.RowSel, "RWL_Qty") = Val(IsNull(dr_Assemble("RWL_Qty"), 0))
                        Fg1.Item(Fg1.RowSel, "IsAssemble") = True
                        Fg1.GotoNextCell("Qty")
                    Next
                Else
                    Fg1.Item(Fg1.RowSel, "WL_ID") = IsNull(dr("ID"), "")
                    Fg1.Item(Fg1.RowSel, "WL_No") = IsNull(dr("WL_No"), "")
                    'Fg1.Item(Fg1.RowSel, "RWL_No") = IsNull(dr("RWL_No"), "")
                    Fg1.Item(Fg1.RowSel, "WL_Name") = IsNull(dr("WL_Name"), "")
                    Fg1.Item(Fg1.RowSel, "WL_Spec") = IsNull(dr("WL_Spec"), "")
                    Fg1.Item(Fg1.RowSel, "WL_Qty") = Val(IsNull(dr("WL_Qty"), 0))
                    Fg1.Item(Fg1.RowSel, "WL_ApproveQty") = Val(IsNull(dr("WL_ApproveQty"), 0))
                    Fg1.Item(Fg1.RowSel, "WL_Unit") = IsNull(dr("WL_Unit"), "")
                    Fg1.Item(Fg1.RowSel, "Wl_Price") = IsNull(dr("Wl_Price"), "")
                    Fg1.GotoNextCell("WL_No")
                End If
            Else
                Fg1.Item(Fg1.RowSel, "WL_ID") = IsNull(dr("ID"), "")
                Fg1.Item(Fg1.RowSel, "WL_No") = IsNull(dr("WL_No"), "")
                Fg1.Item(Fg1.RowSel, "RWL_No") = IsNull(dr("RWL_No"), "")
                Fg1.Item(Fg1.RowSel, "WL_Name") = IsNull(dr("WL_Name"), "")
                Fg1.Item(Fg1.RowSel, "WL_Spec") = IsNull(dr("WL_Spec"), "")
                'Fg1.Item(Fg1.RowSel, "WL_Unit_LL") = IsNull(dr("WL_Unit_LL"), "")
                Fg1.Item(Fg1.RowSel, "WL_material") = IsNull(dr("WL_material"), "")
                Fg1.Item(Fg1.RowSel, "WL_Center") = IsNull(dr("WL_Center"), "")
                Fg1.Item(Fg1.RowSel, "WL_side") = IsNull(dr("WL_side"), "")
                Fg1.Item(Fg1.RowSel, "WL_Unit") = IsNull(dr("WL_Unit"), "")
                Fg1.Item(Fg1.RowSel, "Wl_Price") = IsNull(dr("Wl_Price"), "")
                Fg1.Item(Fg1.RowSel, "WL_Qty") = Val(IsNull(dr("WL_Qty"), 0))
                Fg1.Item(Fg1.RowSel, "WL_ApproveQty") = Val(IsNull(dr("WL_ApproveQty"), 0))
                Fg1.Item(Fg1.RowSel, "RWL_Qty") = Val(IsNull(dr("RWL_Qty"), 0))
                'gType = IsNull(dr("WL_Type_ID"), "")
                Fg1.GotoNextCell("WL_No")
            End If
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
            ComFun.DelBillNewID(BillType.ClientOrder, Bill_ID)
            Bill_Id_Date = #1/1/1999#
            GetNewID()
        End If
    End Sub

    Sub GetNewID()
        Dao.ClientOrder_DB_NAME = Ch_Name
        If TB_ID.ReadOnly = False Then
            If DTP_sDate.Value <> Bill_Id_Date Then
                Dim R As RetrunNewIdMsg = ComFun.GetBillNewID(BillType.ClientOrder, DTP_sDate.Value, Bill_ID)
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
        Dim R As New R27000_ClientOrder
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
        If Audit_CheckForm() Then
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
        SaveClientOrder(True)
    End Sub

    Private Sub Cmd_UnAudit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_UnAudit.Click
        ShowConfirm("是否反审" & Ch_Name & " [" & TB_ID.Text & "]?", AddressOf UnAudit)
    End Sub

    Protected Sub UnAudit()
        Dao.ClientOrder_DB_NAME = Ch_Name
        Dim msg As MsgReturn = Dao.ClientOrder_Audited(TB_ID.Text, False)
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
        ShowConfirm("是否删除" & Ch_Name & " [" & TB_ID.Text & "]?", AddressOf DelClientOrder)
    End Sub

    ''' <summary>
    ''' 删除客户单
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub DelClientOrder()
        Dao.ClientOrder_DB_NAME = Ch_Name
        Dim msg As MsgReturn = Dao.ClientOrder_Del(TB_ID.Text)
        If msg.IsOk Then
            LastForm.ReturnId = TB_ID.Text
            Me.Close()
        Else
            ShowErrMsg(msg.Msg)
        End If
    End Sub


    Private Sub Cmd_SetInValid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_SetInValid.Click
        ShowConfirm("是否作废" & Ch_Name & " [" & TB_ID.Text & "]?", AddressOf ClientOrderInValid)
    End Sub


    Sub ClientOrderInValid()
        Dao.ClientOrder_DB_NAME = Ch_Name
        Dim msg As MsgReturn = Dao.ClientOrder_InValid(TB_ID.Text, True)
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
        ShowConfirm("是否反作废" & Ch_Name & " [" & TB_ID.Text & "]?", AddressOf ClientOrderValid)
    End Sub

    ''' <summary>
    ''' 作废
    ''' </summary>
    ''' <remarks></remarks>
    Sub ClientOrderValid()
        Dao.ClientOrder_DB_NAME = Ch_Name
        Dim msg As MsgReturn = Dao.ClientOrder_InValid(TB_ID.Text, False)
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
            Return Dao.StoreIn_CheckIsModify(LId, LastLine)
        End If
    End Function

#End Region

    ''' <summary>
    ''' 客户编号
    ''' </summary>
    ''' <param name="Col_No"></param>
    ''' <param name="Col_Name"></param>
    ''' <param name="ID"></param>
    ''' <remarks></remarks>
    Private Sub CB_Client_No_Col_Sel(Col_No As String, Col_Name As String, ID As String) Handles CB_Client_ID.Col_Sel
        TB_Client_Name.Text = Col_Name
    End Sub


#Region "单据自动生成"


    ''' <summary>
    ''' 生成备货单
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_CreateStoreOut_Click(sender As Object, e As EventArgs) Handles Cmd_CreateStoreOut.Click
        If CheckCreate(State) Then
            Dim BH As String = Dao.CheckBHState(TB_ID.Text)
            If BH <> "" Then
                ShowErrMsg("备货单[" & BH & "]未确定不能生成新的备货单")
                Exit Sub
            End If
            Dim Dt As DataTable = GetSelWL()
            If Dt Is Nothing OrElse Dt.Rows.Count = 0 Then
                ShowErrMsg("没有需要备货成品不能生成备货单,请重新选择!")
            Else
                CreateTable(BillType.BeiStoreOut, Dt)
            End If
        End If
    End Sub


    ''' <summary>
    ''' 生成申购单
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_CreatePurchase_Click(sender As Object, e As EventArgs) Handles Cmd_CreatePurchase.Click
        Dim msg As DtReturnMsg = Dao.CheckCPurchase(State, TB_ID.Text)
        If msg.IsOk Then
            Dim PurchaseWL As DataTable = GetPurchaseWL()
            If PurchaseWL.Rows.Count > 0 Then
                CreateTable(BillType.ApplyPurchase, PurchaseWL)
            Else
                ShowErrMsg("已有足够毛坯料，可以进行生产，无需进行申购。如需申购，请另外新增申购单!")
            End If
        Else
            ShowErrMsg("该客户订单已生成申购单" & msg.Dt.Rows(0)("ID"))
        End If
    End Sub



    ''' <summary>
    ''' 判断是否可以开单据
    ''' </summary>
    ''' <remarks></remarks>
    Private Function CheckCreate(ByVal State As Enum_State) As Boolean
        Dim Re As Boolean = False
        If State = Enum_State.AddNew Then
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
            If BillType = BaseClass.BillType.AssembleOrder Then
                .P_F_RS_ID2 = DTP_eDate.Value.ToString
            Else
                .P_F_RS_ID2 = ""
            End If
            .P_F_RS_ID3 = CB_Client_ID.IDAsInt
            .P_F_RS_ID4 = "[ClientOrder]"
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
            SQty = Val(Fg1.Item(i, "Qty")) - Val(Fg1.Item(i, "BeiQty"))
            If IsNull(Fg1.Item(i, "IsAssemble"), False) = False AndAlso Fg1.Item(i, "isSel") = True AndAlso SQty > 0 AndAlso Val(Fg1.Item(i, "WL_ApproveQty")) > 0 Then
                DR = WLTable.NewRow
                DR("WL_ID") = Fg1.Item(i, "WL_ID")
                DR("WL_No") = Fg1.Item(i, "WL_No")
                DR("WL_Name") = Fg1.Item(i, "WL_Name")
                DR("WL_Spec") = Fg1.Item(i, "WL_Spec")
                DR("Price") = Fg1.Item(i, "Wl_Price")
                DR("Qty") = SrtoeOutQty(SQty, Val(Fg1.Item(i, "WL_ApproveQty")))
                DR("Amount") = DR("Qty") * DR("Price")
                WLTable.Rows.Add(DR)
            End If
        Next
        Return WLTable
    End Function

    ''' <summary>
    ''' 获取要申购的毛坯料
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetPurchaseWL() As DataTable
        Dim WLTable As New DataTable
        Dim WLTable2 As New DataTable
        WLTable.Columns.Add("WL_ID", GetType(Integer))
        WLTable.Columns.Add("WL_No", GetType(String))
        WLTable.Columns.Add("WL_Name", GetType(String))
        WLTable.Columns.Add("WL_Spec", GetType(String))
        WLTable.Columns.Add("WL_Unit", GetType(String))
        WLTable.Columns.Add("Qty", GetType(Decimal))
        WLTable.Columns.Add("WL_ApproveQty", GetType(Decimal))
        WLTable.Columns.Add("RWL_Qty", GetType(Decimal))
        WLTable.Columns.Add("Supplier_ID", GetType(Integer))
        WLTable.Columns.Add("Supplier_Name", GetType(String))
        Dim dr As DataRow = WLTable.NewRow
        For i As Integer = 1 To Fg1.Rows.Count - 1

            'If IsNull(Fg1.Item(i, "RWL_No"), "") <> "" AndAlso Fg1.Item(i, "isSel") = True  AndAlso Fg1.Item(i, "IsAssemble") = True Then
            If IsNull(Fg1.Item(i, "RWL_No"), "") <> "" Then
                Dim msg As DtReturnMsg = Dao.Raw_SelListByNo(Fg1.Item(i, "RWL_No"))
                If msg.IsOk AndAlso msg.Dt.Rows.Count > 0 Then
                    dr = WLTable.NewRow
                    dr("WL_ID") = msg.Dt.Rows(0)("ID")
                    dr("WL_No") = msg.Dt.Rows(0)("WL_No")
                    dr("WL_Name") = IsNull(msg.Dt.Rows(0)("WL_Name"), "")
                    dr("WL_Spec") = IsNull(msg.Dt.Rows(0)("WL_Spec"), "")
                    dr("WL_Unit") = IsNull(msg.Dt.Rows(0)("WL_Unit"), "")
                    dr("Qty") = Val(IsNull(Fg1.Item(i, "Qty"), 0)) - Val(IsNull(Fg1.Item(i, "BeiQty"), 0))
                    dr("WL_ApproveQty") = Val(IsNull(Fg1.Item(i, "WL_ApproveQty"), 0))
                    dr("RWL_Qty") = Val(IsNull(Fg1.Item(i, "RWL_Qty"), 0))
                    dr("Supplier_ID") = msg.Dt.Rows(0)("Supplier_ID")
                    dr("Supplier_Name") = msg.Dt.Rows(0)("Supplier_Name")
                    WLTable.Rows.Add(dr)
                End If
            End If

            '五金件
            If IsNull(Fg1.Item(i, "RWL_No"), "") = "" AndAlso Fg1.Item(i, "IsAssemble") = True Then
                Dim msg As DtReturnMsg = Dao.Hardware_SelListByNo(Fg1.Item(i, "Assemble_No"))
                If msg.IsOk AndAlso msg.Dt.Rows.Count > 0 Then
                    dr = WLTable.NewRow
                    dr("WL_ID") = msg.Dt.Rows(0)("ID")
                    dr("WL_No") = msg.Dt.Rows(0)("WL_No")
                    dr("WL_Name") = IsNull(msg.Dt.Rows(0)("WL_Name"), "")
                    dr("WL_Spec") = IsNull(msg.Dt.Rows(0)("WL_Spec"), "")
                    dr("WL_Unit") = IsNull(msg.Dt.Rows(0)("WL_Unit"), "")
                    dr("Qty") = Val(IsNull(Fg1.Item(i, "Qty"), 0)) - Val(IsNull(Fg1.Item(i, "BeiQty"), 0))
                    dr("WL_ApproveQty") = Val(IsNull(Fg1.Item(i, "WL_ApproveQty"), 0))
                    dr("RWL_Qty") = Val(IsNull(Fg1.Item(i, "RWL_Qty"), 0))
                    dr("Supplier_ID") = msg.Dt.Rows(0)("Supplier_ID")
                    dr("Supplier_Name") = msg.Dt.Rows(0)("Supplier_Name")
                    WLTable.Rows.Add(dr)
                End If
            End If
        Next
        '过滤重复数据
        If WLTable.Rows.Count > 0 Then
            Dim myDataView As New DataView(WLTable)
            'Dim strComuns As String() = {"WL_ID", "WL_No", "WL_Name", "WL_Spec", "WL_Unit", "WL_ApproveQty", "RWL_Qty"}
            Dim strComuns As String() = {"WL_ID", "WL_No", "WL_Name", "WL_Spec", "WL_Unit", "WL_ApproveQty", "RWL_Qty", "Supplier_ID", "Supplier_Name"}
            WLTable2 = myDataView.ToTable(True, strComuns)
            WLTable2.Columns.Add("Qty", GetType(Decimal))
            'WLTable2.Columns.Add("WL_ApproveQty", GetType(Decimal))
            For Each dr_Table As DataRow In WLTable2.Rows
                Dim dr_Qty As DataRow() = WLTable.Select("WL_ID=" & dr_Table("WL_ID"))
                If dr_Qty.Length > 0 Then
                    For j As Integer = 1 To dr_Qty.Length
                        dr_Table("Qty") = Val(IsNull(dr_Table("Qty"), 0)) + Val(dr_Qty(j - 1)("Qty"))
                        'dr_Table("WL_ApproveQty") = Val(IsNull(dr_Table("WL_ApproveQty"), 0)) + Val(dr_Qty(j - 1)("WL_ApproveQty"))
                    Next
                End If
                dr_Table("Qty") = Val(IsNull(dr_Table("Qty"), 0)) - Val(dr_Table("RWL_Qty")) - Val(dr_Table("WL_ApproveQty"))
                If Val(IsNull(dr_Table("Qty"), 0)) < 0 Then
                    dr_Table("Qty") = 0
                End If
            Next
            '删除需申购数量为0的行
            Dim dr_PurWL As DataRow
            Dim PurWL_Table As DataTable = WLTable2.Clone
            For Each dr_PurWL_list As DataRow In WLTable2.Rows
                If dr_PurWL_list("Qty") > 0 Then
                    dr_PurWL = PurWL_Table.NewRow
                    dr_PurWL("WL_ID") = dr_PurWL_list("WL_ID")
                    dr_PurWL("WL_No") = dr_PurWL_list("WL_No")
                    dr_PurWL("WL_Name") = IsNull(dr_PurWL_list("WL_Name"), "")
                    dr_PurWL("WL_Spec") = IsNull(dr_PurWL_list("WL_Spec"), "")
                    dr_PurWL("WL_Unit") = IsNull(dr_PurWL_list("WL_Unit"), "")
                    dr_PurWL("Supplier_ID") = IsNull(dr_PurWL_list("Supplier_ID"), 0)
                    dr_PurWL("Supplier_Name") = IsNull(dr_PurWL_list("Supplier_Name"), "")
                    dr_PurWL("Qty") = Val(dr_PurWL_list("Qty"))
                    dr_PurWL("WL_ApproveQty") = Val(dr_PurWL_list("WL_ApproveQty"))
                    dr_PurWL("RWL_Qty") = Val(dr_PurWL_list("RWL_Qty"))
                    PurWL_Table.Rows.Add(dr_PurWL)
                End If
            Next
            PurWL_Table.AcceptChanges()
            Return PurWL_Table
        Else
            Return WLTable
        End If
    End Function

    ''' <summary>
    ''' 获取要装配的物料
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetAssembleWL() As DataTable
        Dim WLTable As New DataTable
        WLTable.Columns.Add("WL_ID", GetType(Integer))
        WLTable.Columns.Add("WL_No", GetType(String))
        WLTable.Columns.Add("WL_Name", GetType(String))
        WLTable.Columns.Add("WL_Spec", GetType(String))
        WLTable.Columns.Add("WL_Unit", GetType(String))
        WLTable.Columns.Add("Qty", GetType(Decimal))
        Dim dr As DataRow = WLTable.NewRow
        For i As Integer = 1 To Fg1.Rows.Count - 1
            If Fg1.Item(i, "IsAssemble") = False Then
                Dim msg As DtReturnMsg = Dao.Assemble_SelByID(Fg1.Item(i, "WL_ID"))
                If msg.IsOk AndAlso msg.Dt.Rows.Count > 0 Then
                    dr = WLTable.NewRow
                    dr("WL_ID") = Fg1.Item(i, "WL_ID")
                    dr("WL_No") = Fg1.Item(i, "WL_No")
                    dr("WL_Name") = IsNull(Fg1.Item(i, "WL_Name"), "")
                    dr("WL_Spec") = IsNull(Fg1.Item(i, "WL_Spec"), "")
                    dr("WL_Unit") = IsNull(msg.Dt.Rows(0)("WL_Unit"), "")
                    dr("Qty") = Val(IsNull(Fg1.Item(i, "Qty"), 0)) - Val(IsNull(Fg1.Item(i, "BeiQty"), 0)) - Val(IsNull(Fg1.Item(i, "WL_ApproveQty"), 0))
                    If Val(dr("Qty")) > 0 Then
                        WLTable.Rows.Add(dr)
                    End If
                End If
            End If
        Next
        WLTable.AcceptChanges()
        Return WLTable
    End Function



    ''' <summary>
    ''' 生成生产单
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_CreateProduce_Click(sender As Object, e As EventArgs) Handles Cmd_CreateProduce.Click
        Dim CHPro As String = Dao.CheckPro(TB_ID.Text)
        If CHPro <> "" Then
            ShowErrMsg("已生成生产指令单[" & CHPro & "]")
            Exit Sub
        End If

        Dim Dt As DataTable = GetProduceMP()
        If Dt Is Nothing OrElse Dt.Rows.Count = 0 Then
            ShowErrMsg("没有需要生产的镜头不能生成生产单,请重新选择!")
        Else
            CreateTable(BillType.ProduceOrder, Dt)
        End If

    End Sub



    ''' <summary>
    ''' 生成生产单
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetProduceMP() As DataTable
        Dim ReDt As New DataTable
        Dim Msg As DtReturnMsg = Dao.GetJP(TB_ID.Text)
        If Msg.IsOk = True Then
            ReDt = Msg.Dt
        End If
        Return ReDt
    End Function


    ''' <summary>
    ''' 生成备货单量
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function SrtoeOutQty(ByVal OrderQty As Integer, ByVal KQty As Integer) As Integer
        Dim ReQty As Integer = 0
        If OrderQty <= KQty Then
            ReQty = OrderQty
        Else
            ReQty = KQty
        End If
        Return ReQty
    End Function

    ''' <summary>
    ''' 生成装配单
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_CreateAssemble_Click(sender As Object, e As EventArgs) Handles Cmd_CreateAssemble.Click
        Dim msg As DtReturnMsg = Dao.CheckAssemble(TB_ID.Text)
        If msg.IsOk Then
            Dim AssembleWL As DataTable = GetAssembleWL()
            If AssembleWL.Rows.Count > 0 Then
                CreateTable(BillType.AssembleOrder, AssembleWL)
            Else
                ShowErrMsg("已有足够库存或不存在需要装配的产品，无需进行装配!")
            End If
        Else
            ShowErrMsg("该客户订单已生成装配单" & msg.Dt.Rows(0)("ID"))
        End If
    End Sub

#End Region

#Region "确认送货日期"

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_ConDDate_Click(sender As Object, e As EventArgs) Handles Cmd_ConDDate.Click
        ShowConfirm("是否确认" & Ch_Name & "送货日期?", AddressOf ConfirmDDate)
    End Sub

    Protected Sub ConfirmDDate()
        Dim Msg As MsgReturn = Dao.ConfirmDDate(DTP_eDate.Value, True, TB_ID.Text)
        If Msg.IsOk Then
            Me_Refresh()
            LastForm.ReturnId = TB_ID.Text
            ShowOk("送货日期确认成功！")
        Else
            ShowErrMsg("送货日期确认失败！")
        End If
    End Sub

#End Region


#Region "反确认送货日期"
    Private Sub Cmd_UConDDate_Click(sender As Object, e As EventArgs) Handles Cmd_UConDDate.Click
        ShowConfirm("是否反确认" & Ch_Name & "送货日期?", AddressOf UConfirmDDate)
    End Sub

    Protected Sub UConfirmDDate()
        Dim Msg As MsgReturn = Dao.ConfirmDDate(DTP_eDate.Value, False, TB_ID.Text)
        If Msg.IsOk Then
            Me_Refresh()
            LastForm.ReturnId = TB_ID.Text
            ShowOk("送货日期反确认成功！")
        Else
            ShowErrMsg("送货日期反确认失败！")
        End If
    End Sub
#End Region
End Class

Partial Friend Class Dao
#Region "常量"
    Protected Friend Shared ClientOrder_DB_NAME As String = "客户订单"

    ''' <summary>
    ''' 删除单据
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_ClientOrder_DelByid As String = "Delete from T27000_ClientOrder_Table  where ID=@ID and State=0"
    ''' <summary>
    ''' 获取单头
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_ClientOrder_GetByid As String = "select top 1 * from T27000_ClientOrder_Table  where ID=@ID "
    ''' <summary>
    ''' 获取单头
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_ClientOrder_SelByid As String = "select top 1 S.*,E.Employee_Name as OperatorName ,W.Dept_Name as Dept_Name from T20200_StoreIn_Table S  left join T15001_Employee E on S.Operator=E.ID left join T15000_Department W on S.Dept_No=W.Dept_No where S.ID=@ID"


    ''' <summary>
    ''' 获取单头 用于作废和审核
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_ClientOrder_GetStateByid As String = "select top 1 ID,State,State_User from T27000_ClientOrder_Table  where ID=@ID"
    ''' <summary>
    ''' 获取单体
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_ClientOrder_GetListByid As String = "select * from T27001_ClientOrder_List  where ID=@ID "

    ''' <summary>
    ''' 获取单体,用于显示
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_ClientOrder_SelListByid As String = "select  L.*,WL.WL_No,WL.WL_Name,WL.WL_Unit,WL.Wl_Price,GT.IsAssemble ,WL.WL_Qty, ISNULL(WL.WL_Qty, 0) - ISNULL(WL.WL_BeiQty, 0) AS WL_ApproveQty,WL.WL_Spec,WL.RWL_No,W.WL_Qty as RWL_Qty  from T27001_ClientOrder_List L left join T10001_WL WL on WL.ID=L.WL_ID left join T10000_GoodsType GT on WL.WL_Type_ID =GT.GoodsType_ID left join T10001_WL W on WL.RWL_No =W.WL_No where L.ID=@ID"
    ''' <summary>
    ''' 检查ID的重复性
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_ClientOrder_CheckID As String = "select count(*) from T27000_ClientOrder_Table  where ID=@ID"

    ''' <summary>
    ''' 检查其他人有没有修改过
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_StoreIn_CheckIsModify As String = "select count(*) from T20201_StoreIn_list  where ID=@ID and Line=@Line"



    ''' <summary>
    ''' 获取加工单列表,用于显示
    ''' </summary>
    ''' <remarks></remarks>0

    Private Const SQL_Produce_SelListByid As String = "select L.*,WL.WL_No,WL.WL_Name,WL.WL_Spec,WL.WL_Unit,WL.WL_Store_ID from (select * from T30011_Produce_List  where ID=@ID)L left join T10001_WL WL on WL.id=l.WL_id  where isnull(WL_Ignore,0)=0 order by WL.WL_Type_ID,WL.WL_Name"

    ''' <summary>
    ''' 获取装配组件信息
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_Assemble_SelListByid As String = "  select WL.WL_No As AWL_No,WL.Assemble_No ,WL.Assemble_Amount , W.* ,ISNULL(W.WL_Qty, 0) - ISNULL(W.WL_BeiQty, 0) AS WL_ApproveQty, WR .WL_Qty as RWL_Qty from T10001_WL_Assemble WL left join T10001_WL W on WL.Assemble_No  =W.WL_No left join T10001_WL WR on W.RWL_No =WR.WL_No where WL.WL_No=@WL_No"

    ''' <summary>
    ''' 获取物料信息
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_WL_GetByID As String = "select Top 1 WL.*,GT.IsAssemble  from T10001_WL WL left join  T10000_GoodsType GT on WL.WL_Type_ID =GT.GoodsType_ID where ID=@WL_ID"

    ''' <summary>
    ''' 获取装配组件信息
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_Assemble_SelListByNo As String = "  select * from T10001_WL_Assemble where WL_No=@WL_No"

    ''' <summary>
    ''' 获取装配组件信息
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_Raw_SelListByNo As String = "  select top 1 WL.*,S.ID as Supplier_ID ,S.Supplier_Name from T10001_WL WL left join T10000_GoodsType GT on WL.WL_Type_ID=GT.GoodsType_ID  left join T10100_Supplier S on WL.WL_Supplier=S.ID where WL_No=@WL_No and GT.IsRaw =1 "

    ''' <summary>
    ''' 获取装配组件五金件信息
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_Hardware_SelListByNo As String = "  select top 1 WL.*,S.ID as Supplier_ID ,S.Supplier_Name from T10001_WL WL left join T10000_GoodsType GT on WL.WL_Type_ID=GT.GoodsType_ID  left join T10100_Supplier S on WL.WL_Supplier=S.ID where WL_No=@WL_No and GT.IsHardware =1 "

    ''' <summary>
    ''' 确认送货日期
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_ConfirmDDate As String = "Update T27000_ClientOrder_Table set eDate=@eDate , ConDDate=@ConDDate Where ID=@ID"

    ''' <summary>
    ''' 检查自动生成申购单的重复性
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_CheckPurchase As String = "select * from T20000_Puchase_Table  where ClientBill=@ClientBill"


    ''' <summary>
    ''' 检查自动生成装配单的重复性
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_CheckAssemble As String = "select * from T27130_AssembleOrder_Table  where ClientOrderID=@ClientBill"



    Private Const SQL_GetJP As String = " select id As WL_ID,SUM(Produce_Qty) As Produce_Qty into #PM " & _
                                      "  from (SELECT WR.ID,(ISNULL (L.Qty,0)-ISNULL (L.BeiQty ,0))*WA.Assemble_Amount aS Produce_Qty  " & _
                                    "   FROM T27001_ClientOrder_List L lEFT JOIN T10001_WL WL ON  L.WL_ID =WL.ID  " & _
                                   "   Left join T10000_GoodsType GT ON GT.GoodsType_ID =WL.WL_Type_ID Left join T10001_WL_Assemble WA ON WA.WL_No =WL.WL_No " & _
                                     "  LEFT JOIN T10001_WL WR ON WR.WL_No =WA.Assemble_No   Where L.ID=@ID AND IsAssemble =1 AND IsRaw =0 and IsHardware=0 " & _
                                      "  UNION ALL " & _
                                      "  SELECT L.WL_ID,ISNULL (L.Qty,0)-ISNULL (L.BeiQty ,0) aS Produce_Qty  " & _
                                    "   FROM T27001_ClientOrder_List L lEFT JOIN T10001_WL WL ON  L.WL_ID =WL.ID Left join T10000_GoodsType GT ON GT.GoodsType_ID =WL.WL_Type_ID  " & _
                                    "    Where L.ID=@ID AND IsAssemble =0 AND IsRaw =0 and IsHardware=0 )A     Group by id " & _
                                   "    Select P.WL_ID,WL.WL_No, WL.WL_Name,WL.WL_Center ,WL.RWL_No,WL.WL_material,WL.WL_Spec,WL.WL_side,(P.Produce_Qty-Isnull(WL.WL_Qty,0)+ IsNull(WL_BeiQty,0))As Produce_Qty from #PM P " & _
                                   "  left join T10001_WL WL ON P.WL_ID=WL.ID Left join T10000_GoodsType GT On WL.WL_Type_ID=GT.GoodsType_ID  " & _
                                  "  Where P.Produce_Qty-Isnull(WL.WL_Qty,0)+ IsNull(WL_BeiQty,0) >0 AND IsAssemble =0 AND IsRaw =0 and IsHardware=0    " & _
                                  "  DROP Table #PM  "


    Private Const SQL_CheckBhState As String = "SELECT  ID FROM T20300_StoreOut_Table Where ClientOrder_ID = @ClientOrder_ID AND State = 0"

    Private Const SQL_CheckPro As String = "select ID FROM T27110_ProduceOrder_Table Where ClientOrderID=@ClientOrderID AND State>-1 "

    ''' <summary>
    ''' 获取装配组件
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_Assemble_SelByid As String = "select * from T10001_WL WL left join T10000_GoodsType GT on WL.WL_Type_ID=GT.GoodsType_ID where WL.ID=@WL_ID and GT.IsAssemble=1"

    ''' <summary>
    ''' 获取申购物料到货时间
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_Get_MaxDate As String = " select count(*) as Num,MAX (PL.eDate) as Max_eDate from T27000_ClientOrder_Table CT left join T20000_Puchase_Table PT on CT.ID =PT.ClientBill left join T20001_Puchase_List PL on PT.ID =PL.ID  where CT.ID =@ID and PL.eDate is not NUll"

    ''' <summary>
    ''' 获取申购物料到货时间
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_Get_MaxDate1 As String = " select count(*) as Num,MAX (PL.eDate) as Max_eDate from T27000_ClientOrder_Table CT left join T20000_Puchase_Table PT on CT.ID =PT.ClientBill left join T20001_Puchase_List PL on PT.ID =PL.ID  where CT.ID =@ID "
#Region "生产加工单"

    ''' <summary>
    ''' 获取对生产加工列表信息
    ''' </summary>
    ''' <param name="sId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Produce_SelListById(ByVal sId As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_Produce_SelListByid, "@ID", sId)
    End Function
#End Region

    ''' <summary>
    ''' 获取装配组件信息
    ''' </summary>
    ''' <param name="WL_No"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Assemble_SelListById(ByVal WL_No As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_Assemble_SelListByid, "@WL_No", WL_No)
    End Function

    ''' <summary>
    ''' 获取镜片
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetJP(ByVal id As String) As DtReturnMsg
        Dim Msg As DtReturnMsg = PClass.PClass.SqlStrToDt(SQL_GetJP, "@ID", id)
        Return Msg
    End Function

    ''' <summary>
    ''' 检查未确认备货单
    ''' </summary>
    ''' <param name="id"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CheckBHState(ByVal id As String) As String
        Dim Re As String = ""
        Dim Msg As DtReturnMsg = PClass.PClass.SqlStrToDt(SQL_CheckBhState, "@ClientOrder_ID", id)
        If Msg.IsOk AndAlso Msg.Dt.Rows.Count > 0 Then
            Re = Msg.Dt.Rows(0)("ID")
        End If
        Return Re
    End Function

    ''' <summary>
    ''' 检查是否已生成生产单
    ''' </summary>
    ''' <param name="ID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CheckPro(ByVal ID As String) As String
        Dim Re As String = ""
        Dim Msg As DtReturnMsg = PClass.PClass.SqlStrToDt(SQL_CheckPro, "@ClientOrderID", ID)
        If Msg.IsOk AndAlso Msg.Dt.Rows.Count > 0 Then
            Re = Msg.Dt.Rows(0)("ID")
        End If
        Return Re

    End Function




#End Region


#Region "单一张单内容查询"
    ''' <summary>
    ''' 获取客户订单信息
    ''' </summary>
    ''' <param name="sId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ClientOrder_GetById(ByVal sId As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_ClientOrder_GetByid, "@ID", sId)
    End Function

    ''' <summary>
    ''' 获取客户订单列表信息
    ''' </summary>
    ''' <param name="sId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ClientOrder_SelListById(ByVal sId As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_ClientOrder_SelListByid, "@ID", sId)
    End Function

    ''' <summary>
    ''' 获取物料信息
    ''' </summary>
    ''' <param name="ID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function WL_GetByID(ByVal ID As Integer) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_WL_GetByID, "@WL_ID", ID)
    End Function

    ''' <summary>
    ''' 获取物料组件信息
    ''' </summary>
    ''' <param name="WL_No"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Assemble_SelListByNo(ByVal WL_No As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_Assemble_SelListByNo, "@WL_No", WL_No)
    End Function


    ''' <summary>
    ''' 获取物料毛坯信息
    ''' </summary>
    ''' <param name="WL_No"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Raw_SelListByNo(ByVal WL_No As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_Raw_SelListByNo, "@WL_No", WL_No)
    End Function

    ''' <summary>
    ''' 获取物料毛坯信息
    ''' </summary>
    ''' <param name="WL_ID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Assemble_SelByID(ByVal WL_ID As Integer) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_Assemble_SelByid, "@WL_ID", WL_ID)
    End Function


    ''' <summary>
    ''' 获取物料五金件信息
    ''' </summary>
    ''' <param name="WL_No"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Hardware_SelListByNo(ByVal WL_No As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_Hardware_SelListByNo, "@WL_No", WL_No)
    End Function
#End Region

    ''' <summary>
    ''' 确认反确认送货日期
    ''' </summary>
    ''' <param name="eDate"></param>
    ''' <param name="ID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ConfirmDDate(ByVal eDate As Date, ByVal confirm As Boolean, ByVal ID As String) As MsgReturn
        Dim p As New Dictionary(Of String, Object)
        p.Add("eDate", eDate)
        p.Add("ConDDate", confirm)
        p.Add("ID", ID)
        Dim Msg As MsgReturn = PClass.PClass.RunSQL(SQL_ConfirmDDate, p)
        Return Msg
    End Function

    ''' <summary>
    ''' 获取申购物料到货时间
    ''' </summary>
    ''' <param name="_ID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Get_MaxDate(ByVal _ID As String) As DtReturnMsg
        Dim msg As DtReturnMsg = SqlStrToDt(SQL_Get_MaxDate, "@ID", _ID)
        Dim msg1 As DtReturnMsg = SqlStrToDt(SQL_Get_MaxDate1, "@ID", _ID)
        If msg.IsOk AndAlso msg1.IsOk Then
            If msg.Dt.Rows(0)("Num") = msg1.Dt.Rows(0)("Num") Then
                msg.Msg = "采购到货日期:"
            Else
                Dim Num As String = (Int(msg1.Dt.Rows(0)("Num")) - Int(msg.Dt.Rows(0)("Num"))).ToString
                msg.Msg = "采购物料未确认到货日期"
            End If
        Else
            msg.Dt = New DataTable
        End If
        Return msg
    End Function

#Region "添加修改删除"

    ''' <summary>
    ''' 检查其他人有没有修改过
    ''' </summary>
    ''' <param name="ID"></param>
    ''' <param name="Line"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function StoreIn_CheckIsModify(ByVal ID As String, ByVal Line As Integer) As Boolean
        Dim P As New Dictionary(Of String, Object)
        P.Add("ID", ID)
        P.Add("Line", Line)
        Dim R As MsgReturn = SqlStrToOneStr(SQL_StoreIn_CheckIsModify, P)
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
    Public Shared Function ClientOrder_CheckID(ByVal ID As String) As Boolean
        Dim R As MsgReturn = SqlStrToOneStr(SQL_ClientOrder_CheckID, "@ID", ID)
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
    ''' 判断是否可以开申购单据
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Function CheckCPurchase(ByVal State As Enum_State, ByVal Clien_Bill As String) As DtReturnMsg
        Dim paraMap As New Dictionary(Of String, Object)
        paraMap.Add("ClientBill", Clien_Bill)
        Dim R As DtReturnMsg = SqlStrToDt(SQL_CheckPurchase, "@ClientBill", Clien_Bill)
        If State = Enum_State.AddNew AndAlso R.IsOk Then
            If R.Dt.Rows.Count > 0 Then
                R.IsOk = False
            Else
                R.IsOk = True
            End If
        End If
        Return R
    End Function

    ''' <summary>
    ''' 判断是否可以开装配单据
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Function CheckAssemble(ByVal Clien_Bill As String) As DtReturnMsg
        Dim paraMap As New Dictionary(Of String, Object)
        paraMap.Add("ClientBill", Clien_Bill)
        Dim R As DtReturnMsg = SqlStrToDt(SQL_CheckAssemble, "@ClientBill", Clien_Bill)
        If R.IsOk Then
            If R.Dt.Rows.Count > 0 Then
                R.IsOk = False
            Else
                R.IsOk = True
            End If
        End If
        Return R
    End Function


    ''' <summary>
    ''' 添加客户订单
    ''' </summary>
    ''' <param name="dtTable"></param>
    ''' <param name="dtList"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ClientOrder_Add(ByVal dtTable As DataTable, ByVal dtList As DataTable) As MsgReturn
        Dim msg As New DtListReturnMsg
        Dim R As New MsgReturn
        Dim sqlMap As New Dictionary(Of String, String)
        Dim paraMap As New Dictionary(Of String, Object)
        Dim ClientOrderId As String = dtTable.Rows(0)("ID")
        Dim IsInsert As Boolean = False
        paraMap.Add("ID", ClientOrderId)
        Try
            sqlMap.Add("Table", SQL_ClientOrder_GetByid)
            sqlMap.Add("List", SQL_ClientOrder_GetListByid)
            msg = SqlStrToDt(sqlMap, paraMap)
            If msg.DtList("Table").Rows.Count = 0 Then
                DvToDt(dtTable, msg.DtList("Table"), New List(Of String), True)
                DvToDt(dtList, msg.DtList("List"), New List(Of String), True)
                Dim TmSQL As String = "insert into Bill_Barcode (No_ID,NO_Type)values('" & ClientOrderId & "'," & BillType.ClientOrder & ")"
                DtToUpDate(msg, TmSQL)
                R.Msg = "" & ClientOrder_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]添加成功!"
                R.IsOk = True
            Else
                R.IsOk = False
                R.Msg = "" & ClientOrder_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]已经存在!请双击编号文本框,获取新编号!"
            End If
            Return R
        Catch ex As Exception
            R.IsOk = False
            R.Msg = "" & ClientOrder_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]添加错误!"
            DebugToLog(ex)
            Return R
        Finally
        End Try
    End Function

    ''' <summary>
    ''' 修改客户订单单
    ''' </summary>
    ''' <param name="dtTable"></param>
    ''' <param name="dtList"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ClientOrder_Save(ByVal LID As String, ByVal dtTable As DataTable, ByVal dtList As DataTable) As MsgReturn
        Dim msg As New DtListReturnMsg
        Dim R As New MsgReturn
        Dim sqlMap As New Dictionary(Of String, String)
        Dim paraMap As New Dictionary(Of String, Object)
        Dim ClientOrderId As String = dtTable.Rows(0)("ID")
        If LID <> ClientOrderId AndAlso ClientOrder_CheckID(ClientOrderId) Then
            R.IsOk = False
            R.Msg = "" & ClientOrder_DB_NAME & "[" & ClientOrderId & "]已经存在!请双击编号文本框,获取新编号!"
            Return R
        End If
        dtTable.Rows(0)("ID") = LID
        paraMap.Add("ID", LID)

        Try
            sqlMap.Add("Table", SQL_ClientOrder_GetByid)
            sqlMap.Add("List", SQL_ClientOrder_GetListByid)
            msg = SqlStrToDt(sqlMap, paraMap)
            If msg.DtList("Table").Rows.Count = 1 Then
                If msg.DtList("Table").Rows(0)("State") = Enum_State.Audited Then
                    msg.DaList("Table").Dispose()
                    msg.DaList("List").Dispose()
                    msg.Cnn.Dispose()
                    R.IsOk = False
                    R.Msg = "" & ClientOrder_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]已经被审核不能再修改!"
                    Return R
                End If
                If msg.DtList("Table").Rows(0)("State") = Enum_State.Invoid Then
                    msg.DaList("Table").Dispose()
                    msg.DaList("List").Dispose()
                    msg.Cnn.Dispose()
                    R.IsOk = False
                    R.Msg = "" & ClientOrder_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]已经被作废不能再修改!"
                    Return R
                End If
                DvToDt(dtList, msg.DtList("List"), New List(Of String))
                DvUpdateToDt(dtTable, msg.DtList("Table"), New List(Of String))
                Dim TmSQL As String = "Update Bill_Barcode set No_ID='" & ClientOrderId & "' where No_ID='" & LID & "' and NO_Type=" & BillType.StoreIn
                If LID <> ClientOrderId Then
                    DtToUpDate(msg, "Update T27000_ClientOrder_Table set id='" & ClientOrderId & "' where id='" & LID & "'" & vbCrLf & TmSQL)
                    dtTable.Rows(0)("ID") = ClientOrderId
                    R.Msg = "" & ClientOrder_DB_NAME & "[" & LID & "]已经修改为[" & ClientOrderId & "]!"
                Else
                    DtToUpDate(msg)
                    R.Msg = "" & ClientOrder_DB_NAME & "[" & LID & "]修改成功!"
                End If
                R.IsOk = True
            Else
                R.IsOk = False
                R.Msg = "" & ClientOrder_DB_NAME & "[" & LID & "]不存在"
            End If
            Return R
        Catch ex As Exception
            R.IsOk = False
            R.Msg = "" & ClientOrder_DB_NAME & "[" & LID & "]修改错误"
            DebugToLog(ex)
            Return R
        Finally
        End Try
    End Function

    ''' <summary>
    ''' 删除客户订单
    ''' </summary>
    ''' <param name="ClientOrderId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ClientOrder_Del(ByVal ClientOrderId As String)
        Return RunSQL(SQL_ClientOrder_DelByid, "@ID", ClientOrderId)
    End Function


    ''' <summary>
    ''' 作废客户订单
    ''' </summary>
    ''' <param name="_ID"></param>
    ''' <param name="IsFei">作废还是反作废</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ClientOrder_InValid(ByVal _ID As String, ByVal IsFei As Boolean) As MsgReturn
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
            sqlMap.Add("Table", SQL_ClientOrder_GetStateByid)
            msg = SqlStrToDt(sqlMap, paraMap)
            If msg.DtList("Table").Rows.Count = 1 Then
                If msg.DtList("Table").Rows(0)("State") <> Enum_State.Audited Then
                    '检查加工单状态
                    If msg.DtList("Table").Rows(0)("State") <> State Then
                        msg.DtList("Table").Rows(0)("State") = State
                        msg.DtList("Table").Rows(0)("State_User") = User_Display
                        DtToUpDate(msg)
                        R.IsOk = True
                        R.Msg = "" & ClientOrder_DB_NAME & "[" & _ID & "]" & OStr & "成功!"
                    Else
                        R.IsOk = False
                        R.Msg = "" & ClientOrder_DB_NAME & "[" & _ID & "]已经被" & OStr & "!不能再" & OStr & "!"
                    End If
                Else
                    R.IsOk = False
                    R.Msg = "" & ClientOrder_DB_NAME & "[" & _ID & "]已经被审核,不能" & OStr & "!"
                End If
            Else
                R.IsOk = False
                R.Msg = "" & ClientOrder_DB_NAME & "[" & _ID & "]不存在,不能" & OStr & "!"
            End If
            Return R
        Catch ex As Exception
            R.IsOk = False
            R.Msg = "" & ClientOrder_DB_NAME & "[" & _ID & "]" & OStr & "错误!"
            DebugToLog(ex)
            Return R
        Finally
        End Try
    End Function




    ''' <summary>
    ''' 审核客户订单
    ''' </summary>
    ''' <param name="_ID"></param>
    ''' <param name="IsAudited">审核还是反审核</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ClientOrder_Audited(ByVal _ID As String, ByVal IsAudited As Boolean) As MsgReturn
        Dim paraMap As New Dictionary(Of String, Object)
        paraMap.Add("ID", _ID)
        paraMap.Add("IsAudited", IsAudited)
        paraMap.Add("State_User", User_Display)
        Dim R As MsgReturn = SqlStrToOneStr("P27000_ClientOrder_Audited", paraMap, True)
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