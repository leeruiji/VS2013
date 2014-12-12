Option Compare Text
Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports PClass
Imports BaseClass
Imports PClass.CReport

Public Class F26301_StoreOut_Msg
    Dim LId As String = ""
    Dim Bill_Id_Date As Date = #1/1/1999#
    Dim dtList As DataTable
    Dim dtTable As DataTable
    Dim DtChePai As DataTable
    Dim StoreDt As DataTable
    Dim State As Enum_State = Enum_State.AddNew
    Dim IsBidings As Boolean = False
    Dim StoreOutType As Enum_StoreOut_Type

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
        Control_CheckRight(ID, ClassMain.Audited, Cmd_Audit)
        Control_CheckRight(ID, ClassMain.UnAudit, Cmd_UnAudit)
        Control_CheckRight(ID, ClassMain.SetInValid, Cmd_SetInValid)
        Control_CheckRight(ID, ClassMain.SetValid, Cmd_SetValid)
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
        ComFun.DelBillNewID(BillType.StoreOut_MT, Bill_ID)
    End Sub

    Private Sub Form_Load() Handles Me.Me_Load
        '    Fg1.Cols("Store_Name").Editor = CB_Store
        If Bill_Id = "" AndAlso P_F_RS_ID2 <> "" Then
            Bill_Id = P_F_RS_ID
        End If

        '    Fg1.Cols("WL_Unit_LL").Editor = CB_Unit_LL
        Dim remarkType As Enum_RemarkType
        Select Case ID
            Case 21300
                LB_Workshop.Visible = False
                CB_Dept_No.Visible = False
                StoreOutType = Enum_StoreOut_Type.Other
                remarkType = Enum_RemarkType.StoreOut_Reason
                ID = 21300
            Case 21310
                LB_Workshop.Visible = False
                CB_Dept_No.Visible = False
                StoreOutType = Enum_StoreOut_Type.LingLiao
                remarkType = Enum_RemarkType.LingLiao_Reason
                LB_Workshop.Visible = True
                CB_Dept_No.Visible = True
                ID = 21310
        End Select
        FormCheckRight()
        Ch_Name = GetBillTypeName(ID)
        Me.Title = Ch_Name

        ''出库原因

        ''车间
        Dim msgWorkshop As DtReturnMsg = BaseClass.ComFun.Dept_GetAll()
        If msgWorkshop.IsOk Then
            CB_Dept_No.ValueMember = "Dept_No"
            CB_Dept_No.DisplayMember = "DisplayName"
            CB_Dept_No.DataSource = msgWorkshop.Dt
        End If
        '业务员
        'Employee_List1.Set_TextBox(TB_Operator, TB_Upd_User)
        'TB_Operator.Tag = "0"

        Fg1.IniFormat()
        If Me.Mode = Mode_Enum.Modify AndAlso P_F_RS_ID <> "" Then
            Me.Bill_Id = P_F_RS_ID


        End If
        Me_Refresh()

        '设置默认值
        'If Me.Mode = Mode_Enum.Add Then
        '    CB_Reason.SelectedIndex = -1
        '    Dim i As Int16 = 0
        '    For Each dr As DataRow In msgReason.Dt.Rows
        '        If IsNull(dr("IsDefault"), False) = True Then
        '            CB_Reason.SelectedIndex = i
        '            Exit For
        '        End If
        '        i = i + 1
        '    Next
        'End If

    End Sub

    Protected Sub Me_Refresh()
        Dim msgTable As DtReturnMsg = Dao.StoreOut_GetById(Bill_Id)
        If msgTable.IsOk Then
            If IsBidings Then
                DvUpdateToDt(msgTable.Dt, dtTable, New List(Of String))
            Else
                dtTable = msgTable.Dt
            End If

            If Mode = Mode_Enum.Modify AndAlso msgTable.Dt.Rows.Count = 0 Then
                ShowErrMsg("没有找到" & Ch_Name & "[" & Bill_Id & "]", True)
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

                GetNewID()
            Case Mode_Enum.Modify
                Dim msg As DtReturnMsg = Dao.StoreOut_SelListById(Bill_Id)
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
        ' Dim T As New Threading.Thread(AddressOf GetDtMsg)
        '   T.Start()
        If Me.Mode = Mode_Enum.Add Then
            '  TB_Produce_ID.Text = Me.F_RS_ID
            CB_Reason.Text = Me.P_F_RS_ID2
            If Not Me.ReturnObj Is Nothing Then
                SetGoodsFromProduce()
            End If
            If CB_Dept_No.Items.Count > 0 Then
                CB_Dept_No.SelectedIndex = 0
            End If
        ElseIf Me.Mode = Mode_Enum.Modify Then

        End If
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
                newDr("WL_Unit") = IsNull(dr("WL_Unit"), "")
                newDr("WL_Spec") = IsNull(dr("WL_Spec"), "")
                newDr("Qty") = IsNull(dr("PlanQty"), "")


                newDr("Store_id") = IsNull(dr("WL_Store_ID"), 0)


                newDr("Price") = IsNull(dr("Cost"), 0)
                newDr("Store_Name") = CB_Unit_LL.Text

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

    'Private Sub TB_Produce_ID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_Produce_ID.TextChanged
    '    If TB_Produce_ID.Text <> "" Then
    '        Cmd_AddRow.Enabled = False
    '        Cmd_RemoveRow.Enabled = False
    '    End If
    'End Sub

    'Private Sub Cmd_ProduceSel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    ShowProduceSel()
    'End Sub
    'Protected Sub ShowProduceSel(Optional ByVal _no As String = "")
    '    Dim F As BaseForm = PClass.PClass.LoadFormIDToChild(30013, Me)
    '    If F Is Nothing Then Exit Sub
    '    With F
    '        .P_F_RS_ID = ""
    '        .P_F_RS_ID2 = _no
    '        .P_F_RS_ID3 = "WL"
    '        .IsSel = True
    '    End With
    '    ReturnId = ""
    '    Me.ReturnObj = Nothing
    '    Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F, Me)
    '    AddHandler VF.ClosedX, AddressOf SetProduce
    '    VF.Show()
    'End Sub

    'Protected Sub SetProduce()
    '    If ReturnId <> "" Then
    '        'TB_Produce_ID.Text = ReturnId
    '        GetProduceByNo(ReturnId)

    '    End If
    '    Me.ReturnId = ""
    'End Sub

    'Protected Sub GetProduceByNo(ByVal _No As String)
    '    ' Dim msg As DtReturnMsg = Dao.Produce_SelListById(TB_Produce_ID.Text)
    '    Fg1.CanEditing = False
    '    '  Fg1.Rows.Count = 1
    '    dtList.Clear()
    '    Dim newDr As DataRow
    '    If msg.IsOk Then
    '        For i = 0 To msg.Dt.Rows.Count - 1
    '            newDr = dtList.NewRow
    '            newDr("WL_ID") = IsNull(msg.Dt.Rows(i)("WL_ID"), "")
    '            newDr("WL_No") = IsNull(msg.Dt.Rows(i)("WL_No"), "")
    '            newDr("WL_Name") = IsNull(msg.Dt.Rows(i)("WL_Name"), "")
    '            newDr("WL_Unit") = IsNull(msg.Dt.Rows(i)("WL_Unit"), "")
    '            newDr("WL_Spec") = IsNull(msg.Dt.Rows(i)("WL_Spec"), "")
    '            newDr("Store_ID") = IsNull(msg.Dt.Rows(i)("WL_Store_ID"), 0)
    '            newDr("Qty") = IsNull(msg.Dt.Rows(i)("PlanQty"), 0)
    '            newDr("Price") = IsNull(msg.Dt.Rows(i)("Cost"), 0)
    '            CB_Unit_LL.SelectedValue = IsNull(msg.Dt.Rows(i)("WL_Store_ID"), 0)
    '            newDr("Store_Name") = CB_Unit_LL.Text
    '            dtList.Rows.Add(newDr)
    '        Next
    '        dtList.AcceptChanges()
    '        Fg1.DtToSetFG(dtList)
    '        Fg1.ReAddIndex()
    '        CaculateSumAmount()
    '    Else
    '        ShowProduceSel(_No)
    '    End If
    '    Fg1.CanEditing = True
    'End Sub
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
        dr("Operator") = TB_Operator.Text
        dr("State") = State
        If CB_Dept_No.SelectedIndex >= 0 Then
            dr("Dept_No") = CB_Dept_No.SelectedValue
        Else
            dr("Dept_No") = 0
        End If
        dr("StoreOutType") = StoreOutType
        '   dr("Payed") = dr("SumAmount") - IsNull(dr("UnPayed"), 0)
        dt.AcceptChanges()
        dtList = dtList.Clone
        For i As Integer = 1 To Fg1.Rows.Count - 1
            dr = dtList.NewRow
            dr("ID") = ID

            dr("WL_ID") = Fg1.Item(i, "WL_ID")
            dr("Price") = Fg1.Item(i, "Price")
            dr("Cost") = Fg1.Item(i, "Cost")
            dr("Qty") = Fg1.Item(i, "Qty")
            'dr("WL_Unit_LL") = Fg1.Item(i, "WL_Unit_LL")
            dr("Qty_Store") = dr("Qty") '* ComFun.Unit_Convert(Fg1.Item(i, "WL_Unit_LL"), Fg1.Item(i, "WL_Unit_LL2"))

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

        Dim Dr As DataRow
        If dt.Rows.Count = 0 Then
            Dr = dt.NewRow
            ' Dr("UnPayed") = 0
            Dr("State_User") = ""
            ' Dr("ClientBill") = ""
            Dr("Remark") = ""
            Dr("ID") = ""
            Dr("sDate") = ServerTime.Date
            Dr("SumAmount") = 0
            '   Dr("Payed") = Dr("SumAmount") - Dr("UnPayed")

            Cmd_Audit.Visible = Cmd_Audit.Tag
            Cmd_Audit.Enabled = True
            Cmd_UnAudit.Visible = False
            Cmd_UnAudit.Enabled = False

            Cmd_SetValid.Visible = False
            Cmd_SetValid.Enabled = False
            Cmd_SetInValid.Visible = Cmd_SetInValid.Tag
            Cmd_SetInValid.Enabled = False
            Cmd_Del.Enabled = False

            LabelState.Text = "新建"
            LabelState.ForeColor = Color.Black
            dt.Rows.Add(Dr)
            dt.AcceptChanges()
            LockForm(False)
        Else
            Dr = dt.Rows(0)
            State = Dr("State")

            Select Case State
                Case Enum_State.AddNew '新建
                    LabelState.Text = "新建"
                    LabelState.ForeColor = Color.Black
                    Cmd_Modify.Enabled = Cmd_Modify.Tag

                    Cmd_Audit.Visible = Cmd_Audit.Tag
                    Cmd_Audit.Enabled = True
                    Cmd_UnAudit.Visible = False
                    Cmd_UnAudit.Enabled = False
                    CB_Reason.Enabled = True
                    CB_Dept_No.Enabled = True
                    Cmd_AddRow.Enabled = True
                    Cmd_Del.Enabled = Cmd_Del.Tag
                    Cmd_RemoveRow.Enabled = True

                    Cmd_SetValid.Visible = False
                    Cmd_SetValid.Enabled = True
                    Cmd_SetInValid.Visible = Cmd_SetInValid.Tag
                    Cmd_SetInValid.Enabled = True
                    Cmd_Del.Enabled = True
                    LockForm(False)
                Case Enum_State.Invoid '作废
                    LabelState.Text = "已作废"
                    LabelState.ForeColor = Color.Red
                    Cmd_Modify.Enabled = False

                    Cmd_Audit.Visible = Cmd_Audit.Tag
                    Cmd_Audit.Enabled = False
                    Cmd_UnAudit.Visible = False
                    Cmd_UnAudit.Enabled = False


                    Cmd_AddRow.Enabled = False

                    Cmd_Del.Enabled = True
                    Cmd_RemoveRow.Enabled = False

                    Cmd_SetValid.Visible = Cmd_SetValid.Tag
                    Cmd_SetValid.Enabled = True
                    Cmd_SetInValid.Visible = False
                    Cmd_SetInValid.Enabled = False

                    LockForm(True)
                Case Enum_State.Audited '审核
                    TB_ID.ReadOnly = True
                    CB_Reason.Enabled = False
                    CB_Dept_No.Enabled = False
                    LabelState.Text = "已审核"
                    LabelState.ForeColor = Color.Blue
                    Cmd_Modify.Enabled = False

                    Cmd_RemoveRow.Enabled = False
                    Cmd_AddRow.Enabled = False
                    Cmd_Del.Enabled = False

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
            TB_Remark.DataBindings.Add("Text", dtTable, TB_Remark.Name.Substring(3), False, DataSourceUpdateMode.OnPropertyChanged, "")
            TB_SumQty.DataBindings.Add("Text", dtTable, TB_SumQty.Name.Substring(3), True, DataSourceUpdateMode.OnPropertyChanged, 0, FormatSharp("num"))
            TB_SumAmount.DataBindings.Add("Text", dtTable, TB_SumAmount.Name.Substring(3), True, DataSourceUpdateMode.OnPropertyChanged, 0, FormatSharp("money"))

            TB_State_User.DataBindings.Add("Text", dtTable, TB_State_User.Name.Substring(3), False, DataSourceUpdateMode.OnPropertyChanged, "")
            TB_Upd_User.DataBindings.Add("Text", dtTable, TB_Upd_User.Name.Substring(3), False, DataSourceUpdateMode.OnPropertyChanged, "")
            CB_Reason.DataBindings.Add("Text", dtTable, CB_Reason.Name.Substring(3), False, DataSourceUpdateMode.OnPropertyChanged, "")
            CB_Dept_No.DataBindings.Add("SelectedValue", dtTable, CB_Dept_No.Name.Substring(3), False, DataSourceUpdateMode.OnPropertyChanged, "")
            ' TB_Produce_ID.DataBindings.Add("Text", dtTable, TB_Produce_ID.Name.Substring(3), False, DataSourceUpdateMode.OnPropertyChanged, "")
            TB_Operator.DataBindings.Add("Text", dtTable, TB_Operator.Name.Substring(3), False, DataSourceUpdateMode.OnPropertyChanged, "")
            IsBidings = True
        End If
        '    Employee_List1.GetByTextBoxTag(IsNull(dtTable.Rows(0)("Operator"), "0"))
    End Sub

    Sub LockForm(ByVal Lock As Boolean)
        TB_ID.ReadOnly = Lock
        DTP_sDate.Enabled = Not Lock
        Cmd_AddRow.Enabled = Not Lock
        Cmd_RemoveRow.Enabled = Not Lock
        CB_Reason.Enabled = Not Lock
        CB_Dept_No.Enabled = Not Lock

        Fg1.CanEditing = Not Lock
        Fg1.IsClickStartEdit = Not Lock
        TB_Operator.ReadOnly = Lock
        TB_Remark.ReadOnly = Lock
        '   Cmd_ProduceSel.Enabled = Not Lock
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
    Protected Sub SaveStoreOut(Optional ByVal Audit As Boolean = False)
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
            If Audit Then
                Dim msg As MsgReturn = Dao.StoreOut_Audited(TB_ID.Text, True)
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

        If CB_Reason.Text = "" Then
            ShowErrMsg("出库原因不能为空!", AddressOf CB_Reason.Focus)
            Return False
        End If
        ''If Me.StoreOutType = Enum_StoreOut_Type.LingLiao AndAlso CB_Dept_No.SelectedIndex < 0 Then
        ''    ShowErrMsg("生产车间不能为空!", AddressOf CB_Dept_No.Focus)
        ''    Return False
        ''End If


        For i As Integer = Fg1.Rows.Count - 1 To 1 Step -1
            Try
                If Val(Fg1.Item(i, "Qty")) = 0 OrElse Val(Fg1.Item(i, "WL_ID")) = 0 Then
                    Fg1.RemoveItem(i)
                End If
                If Val(Fg1.Item(i, "Qty")) < 0 Then
                    Fg1.Item(i, "Qty") = -Val(Fg1.Item(i, "Qty"))
                End If
                'If Val(Fg1.Item(i, "Qty")) = 0 OrElse Val(Fg1.Item(i, "Amount")) = 0 OrElse Val(Fg1.Item(i, "WL_ID")) = 0 Then
                '    Fg1.RemoveItem(i)
                'End If
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

    Private Sub CB_Store_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles CB_Unit_LL.SelectionChangeCommitted
        Fg1.Item(Fg1.RowSel, "Store_ID") = CB_Unit_LL.SelectedValue
    End Sub




    Private Sub Fg1_AfterScroll(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RangeEventArgs) Handles Fg1.AfterScroll
        ShowGoodsSelCmd()
    End Sub

    Private Sub Fg1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Fg1.Click
        'If Fg1.CanEditing = False Then Exit Sub
        'If Fg1.Editor Is Nothing Then
        '    If Fg1.RowSel < 0 Then
        '        Exit Sub
        '    End If
        '    If Fg1.Cols(Fg1.ColSel).AllowEditing AndAlso Fg1.CanEditing Then
        '        Fg1.LastKey = 0
        '        Fg1.StartEditing()
        '    End If
        'End If
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
                    '修改当前单价时，当修改后单价不等于成本价时，修改成本价
                    'Dim p As Double = Fg1.Item(Fg1.RowSel, "Price") / ComFun.Unit_Convert(Fg1.Item(Fg1.RowSel, "WL_Unit_LL"), Fg1.Item(Fg1.RowSel, "WL_Unit_LL2"))
                    'If p <> Val(Fg1.Item(Fg1.RowSel, "Cost")) Then
                    '    Fg1.Item(Fg1.RowSel, "Cost") = p
                    'End If
                    ' Fg1.Item(Fg1.RowSel, "Cost") = Fg1.Item(Fg1.RowSel, "Price") / ComFun.Unit_Convert(Fg1.Item(Fg1.RowSel, "WL_Unit_LL"), Fg1.Item(Fg1.RowSel, "WL_Unit_LL2"))
                    Fg1.Item(e.Row, e.Col) = Val(Fg1.Item(e.Row, e.Col))
                    CaculateSumAmount()
                    Fg1.GotoNextCell(e.Col)
                Case "Qty"
                    Fg1.Item(e.Row, e.Col) = Val(Fg1.Item(e.Row, e.Col))
                    CaculateSumAmount()
                    Fg1.GotoNextCell(e.Col)
                    'Case "WL_Unit_LL"
                    '    '转换单位是，也转换单价
                    '    Fg1.Item(Fg1.RowSel, "Price") = Val(Fg1.Item(Fg1.RowSel, "Cost")) ' * ComFun.Unit_Convert(Fg1.Item(Fg1.RowSel, "WL_Unit_LL"), Fg1.Item(Fg1.RowSel, "WL_Unit_LL2"))
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
            Else
                Select Case Fg1.Cols(e.Col).Name

                    Case "Price"
                        '修改当前单价时，当修改后单价不等于成本价时，修改成本价
                        'Dim p As Double = Fg1.Item(Fg1.RowSel, "Price") / ComFun.Unit_Convert(Fg1.Item(Fg1.RowSel, "WL_Unit_LL"), Fg1.Item(Fg1.RowSel, "WL_Unit_LL2"))
                        'If p <> Val(Fg1.Item(Fg1.RowSel, "Cost")) Then
                        '    Fg1.Item(Fg1.RowSel, "Cost") = p
                        'End If

                        CaculateSumAmount()

                        'Case "WL_Unit_LL"
                        '    '转换单位是，也转换单价
                        '    Fg1.Item(Fg1.RowSel, "Price") = Val(Fg1.Item(Fg1.RowSel, "Cost")) * ComFun.Unit_Convert(Fg1.Item(Fg1.RowSel, "WL_Unit_LL"), Fg1.Item(Fg1.RowSel, "WL_Unit_LL2"))

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
        Dim F As BaseForm = LoadFormIDToChild(26002, Me)
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

            Fg1.Item(Fg1.RowSel, "WL_Spec") = IsNull(dr("WL_Spec"), "")

            Fg1.Item(Fg1.RowSel, "WL_Unit") = IsNull(dr("WL_Unit"), "")
            Fg1.Item(Fg1.RowSel, "Price") = IsNull(dr("WL_Cost"), 0) '* ComFun.Unit_Convert(IsNull(dr("WL_Unit_LL"), ""), IsNull(dr("WL_Unit_LL"), ""))
            Fg1.Item(Fg1.RowSel, "Cost") = IsNull(dr("WL_Cost"), 0)
            gType = IsNull(dr("WL_Type_ID"), "")
            Fg1.GotoNextCell("WL_No")
        Else
            Fg1.StartEditing(Fg1.RowSel, Fg1.Cols("WL_No").Index)
        End If
        Me.ReturnObj = Nothing
    End Sub

    Protected Sub GetWLByNo(ByVal _No As String)
        Dim msg As DtReturnMsg = Dao.WLCoal_GetByNo(_No)
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
            ComFun.DelBillNewID(BillType.PurchaseReturn, Bill_Id)
            Bill_Id_Date = #1/1/1999#
            GetNewID()
        End If
    End Sub

    Sub GetNewID()
        Dao.StoreOut_DB_NAME = Ch_Name
        If TB_ID.ReadOnly = False Then
            If DTP_sDate.Value <> Bill_Id_Date Then
                Dim R As RetrunNewIdMsg = ComFun.GetBillNewID(BillType.StoreOut_MT, DTP_sDate.Value, Bill_ID)
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

        Dim R As New R26300_StoreOut
        R.Start(TB_ID.Text, DoOperator, Me.StoreOutType)
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
        SaveStoreOut(True)
    End Sub

    Private Sub Cmd_UnAudit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_UnAudit.Click
        ShowConfirm("是否反审" & Ch_Name & " [" & TB_ID.Text & "]?", AddressOf UnAudit)
    End Sub

    Protected Sub UnAudit()
        Dao.StoreOut_DB_NAME = Ch_Name
        Dim msg As MsgReturn = Dao.StoreOut_Audited(TB_ID.Text, False)
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


#End Region

#Region "检查其他人有没有修改过"
    Private LastLine As Integer = 0
    Private Function CheckIsModify() As Boolean
        If Mode <> Mode_Enum.Add Then
            Return Dao.StoreOut_CheckIsModify(LId, LastLine)
        End If
    End Function

#End Region

End Class





Partial Friend Class Dao
#Region "常量"
    Protected Friend Shared StoreOut_DB_NAME As String = "出库单"
    ''' <summary>
    ''' 删除单据
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_StoreOut_DelByid As String = "Delete from T26300_StoreOut_Table  where ID=@ID and State=0"
    ''' <summary>
    ''' 获取单头
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_StoreOut_GetByid As String = "select top 1 * from T26300_StoreOut_Table  where ID=@ID "
    ''' <summary>
    ''' 获取单头
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_StoreOut_SelByid As String = "select top 1 S.*,E.Employee_Name as OperatorName ,W.Dept_Name as Dept_Name from T26300_StoreOut_Table S  left join T15001_Employee E on S.Operator=E.ID left join T15000_Department W on S.Dept_No=W.Dept_No where S.ID=@ID"


    ''' <summary>
    ''' 获取单头 用于作废和审核
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_StoreOut_GetStateByid As String = "select top 1 ID,State,State_User,Produce_ID from T26300_StoreOut_Table  where ID=@ID"
    ''' <summary>
    ''' 获取单体
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_StoreOut_GetListByid As String = "select * from T21301_StoreOut_List  where ID=@ID "
    ''' <summary>
    ''' 获取单体,用于显示
    ''' </summary>
    ''' <remarks></remarks>0
    Private Const SQL_StoreOut_SelListByid As String = "select L.*,L.WL_Unit_LL as WL_Unit_LL2,WL.WL_No,WL.WL_Name,WL.WL_Spec from (select * from T21301_StoreOut_List  where ID=@ID)L left join T26001_WLCoal WL on WL.id=l.WL_ID  "
    ''' <summary>
    ''' 检查ID的重复性
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_StoreOut_CheckID As String = "select count(*) from T26300_StoreOut_Table  where ID=@ID"

    ''' <summary>
    ''' 获取加工单列表,用于显示
    ''' </summary>
    ''' <remarks></remarks>0

    Private Const SQL_Produce_SelListByid As String = "select L.*,WL.WL_No,WL.WL_Name,WL.WL_Spec,WL.WL_Unit,WL.WL_Store_ID from (select * from T30011_Produce_List  where ID=@ID)L left join T26001_WLCoal WL on WL.id=l.WL_id  where isnull(WL_Ignore,0)=0 order by WL.WL_Type_ID,WL.WL_Name"

    ''' <summary>
    ''' 检查ID的重复性
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_StoreOut_CheckIsModify As String = "select count(*) from T26301_StoreOut_List  where ID=@ID and Line=@Line"
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
                Dim TmSQL As String = "insert into Bill_Barcode (No_ID,NO_Type)values('" & StoreOutId & "'," & BillType.StoreOut & ")"
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


                If msg.DtList("Table").Rows(0)("State") = Enum_State.Audited Then
                    msg.DaList("Table").Dispose()
                    msg.DaList("List").Dispose()
                    msg.Cnn.Dispose()
                    R.IsOk = False
                    R.Msg = "" & StoreOut_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]已经被审核不能再修改!"
                    Return R
                End If
                If msg.DtList("Table").Rows(0)("State") = Enum_State.Invoid Then
                    msg.DaList("Table").Dispose()
                    msg.DaList("List").Dispose()
                    msg.Cnn.Dispose()
                    R.IsOk = False
                    R.Msg = "" & StoreOut_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]已经被作废不能再修改!"
                    Return R
                End If
                DvToDt(dtList, msg.DtList("List"), New List(Of String))
                DvUpdateToDt(dtTable, msg.DtList("Table"), New List(Of String))
                Dim TmSQL As String = "Update Bill_Barcode set No_ID='" & StoreOutId & "' where No_ID='" & LID & "' and NO_Type=" & BillType.StoreOut
                If LID <> StoreOutId Then
                    DtToUpDate(msg, "Update T26300_StoreOut_Table set id='" & StoreOutId & "' where id='" & LID & "'" & vbCrLf & TmSQL)
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
        Dim State As Enum_State = Enum_State.AddNew
        If IsFei Then
            OStr = "作废"
            State = Enum_State.Invoid
        Else
            OStr = "反作废"
        End If
        paraMap.Add("ID", _ID)
        Try
            sqlMap.Add("Table", SQL_StoreOut_GetStateByid)
            msg = SqlStrToDt(sqlMap, paraMap)
            If msg.DtList("Table").Rows.Count = 1 Then
                If msg.DtList("Table").Rows(0)("State") <> Enum_State.Audited Then
                    '检查加工单状态
                    If IsFei = False AndAlso IsNull(msg.DtList("Table").Rows(0)("Produce_ID"), "") <> "" Then
                        Dim Rx As MsgReturn = CallByID(30010, "Produce_CheckCanRef", msg.DtList("Table").Rows(0)("Produce_ID"))
                        If Rx.IsOk = False Then
                            R.IsOk = False
                            R.Msg = StoreOut_DB_NAME & "[" & _ID & "]" & OStr & "失败!" & vbCrLf & Rx.Msg.Replace("不能被引用", "")
                            Return R
                        End If
                    End If
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
                    R.Msg = "" & StoreOut_DB_NAME & "[" & _ID & "]已经被审核,不能" & OStr & "!"
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
    ''' 审核出库单
    ''' </summary>
    ''' <param name="_ID"></param>
    ''' <param name="IsAudited">审核还是反审核</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function StoreOut_Audited(ByVal _ID As String, ByVal IsAudited As Boolean) As MsgReturn
        Dim paraMap As New Dictionary(Of String, Object)
        paraMap.Add("ID", _ID)
        paraMap.Add("IsAudited", IsAudited)
        paraMap.Add("State_User", User_Display)

        Dim R As MsgReturn = SqlStrToOneStr("P26300_StoreOut_Audited", paraMap, True)
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

    '#Region "生产加工单"

    '    ''' <summary>
    '    ''' 获取对生产加工列表信息
    '    ''' </summary>
    '    ''' <param name="sId"></param>
    '    ''' <returns></returns>
    '    ''' <remarks></remarks>
    '    Public Shared Function Produce_SelListById(ByVal sId As String) As DtReturnMsg
    '        Return PClass.PClass.SqlStrToDt(SQL_Produce_SelListByid, "@ID", sId)
    '    End Function
    '#End Region
End Class