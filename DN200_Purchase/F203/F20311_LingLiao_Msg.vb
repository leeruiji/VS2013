Option Compare Text
Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports PClass
Imports BaseClass
Imports PClass.CReport

Public Class F20311_LingLiao_Msg
    Dim BType As BillType = BillType.LingLiao
    Dim LId As String = ""
    Dim Bill_Id_Date As Date = #1/1/1999#
    Dim dtList As DataTable
    Dim dtTable As DataTable
    Dim DtChePai As DataTable
    Dim StoreDt As DataTable
    Dim State As Enum_State = Enum_State.AddNew
    Dim IsBidings As Boolean = False
    Dim IsJiaLiao As Boolean = False
    Dim MainBill As String = ""
    Dim JL_Qty As Integer = 0
   
    Public Sub New()
        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        ' 在 InitializeComponent() 调用之后添加任何初始化。
    End Sub

    Public Sub New(ByVal initID As String, Optional ByVal _IsJiaLiao As Boolean = False)
        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        ' 在 InitializeComponent() 调用之后添加任何初始化。
        Bill_Id = initID
        Me.Mode = Mode
        IsJiaLiao = _IsJiaLiao

    End Sub

    Private Sub Me_AfterLoad() Handles Me.AfterLoad
        If FG1.Rows.Count > 1 Then
            FG1.RowSel = 1
            FG1.Row = 1
            FG1.Select(1, FG1.Cols("WL_No").Index, 1, FG1.Cols("WL_No").Index)
        End If
        If Mode = Mode_Enum.Add Then
            SetNewRowDefaulValue()
        End If
        TB_Produce_ID.Focus()
        FG1.IniColsSize()
    End Sub



    ''' <summary>
    ''' 权限获取
    ''' </summary>
    ''' <remarks></remarks>
    Sub FormCheckRight()
        ID = 20310
        Control_CheckRight(ID, ClassMain.Modify, Cmd_Modify)
        Control_CheckRight(ID, ClassMain.Del, Cmd_Del)
        Control_CheckRight(ID, ClassMain.Audited, Cmd_Audit)
        Control_CheckRight(ID, ClassMain.UnAudit, Cmd_UnAudit)
        Control_CheckRight(ID, ClassMain.SetInValid, Cmd_SetInValid)
        Control_CheckRight(ID, ClassMain.SetValid, Cmd_SetValid)

        Control_CheckRight(ID, ClassMain.JiaLiao, Cmd_JiaLiao)
        Control_CheckRight(ID, ClassMain.ShowJiaLiao, Cmd_ShowJiaLiao)
        Control_CheckRight(ID, ClassMain.Rebuild, Cmd_Rebuild)

        Dim isShowPrice As Boolean = PClass.PClass.CheckRight(ID, ClassMain.ShowPrice)
        Dim isModifyPrice As Boolean = PClass.PClass.CheckRight(ID, ClassMain.ModifyPrice)
        FG1.Cols("Price_LL").Visible = isShowPrice
        FG1.Cols("Amount").Visible = isShowPrice
        FG1.Cols("Price_LL").AllowEditing = isModifyPrice
        LB_SumAmount.Visible = isShowPrice
        TB_SumAmount.Visible = isShowPrice
    End Sub


    Dim IsClosing As Boolean = False
    Private Sub Form_Me_Closing(ByVal sender As Object, ByRef e As System.ComponentModel.CancelEventArgs) Handles Me.Me_Closing
        IsClosing = True
        ComFun.DelBillNewID(BillType.LingLiao, Bill_Id)
    End Sub

    Private Sub Form_Load() Handles Me.Me_Load
        FormCheckRight()
        Ch_Name = GetBillTypeName(ID)
        Dao.LingLiao_DB_NAME = Ch_Name
        Me.Title = Ch_Name

        CB_Ratio.SelectedIndex = 3
        CB_Ratio2.SelectedIndex = 3
        If Bill_Id = "" AndAlso P_F_RS_ID2 <> "" Then
            Bill_Id = P_F_RS_ID
        End If

        FG1.Cols("WL_Unit_LL").Editor = CB_Unit_LL
        FG1.Cols("WL_No").Editor = CB_WL_FG



        '染色步骤,初始话下拉框列表
        Dim msgStep As DtReturnMsg = BaseClass.ComFun.Remark_GetList(Enum_RemarkType.Dying_Step)
        If msgStep.IsOk Then
            CB_DyingStep.DataSource = msgStep.Dt
            CB_DyingStep.DisplayMember = "Remark"
            CB_DyingStep.ValueMember = "Remark"

        End If
        FG1.Cols("DyingStep").Editor = CB_DyingStep
        ''出库原因
        Dim msgReason As DtReturnMsg = BaseClass.ComFun.StoreOut_GetReason(Enum_RemarkType.LingLiao_Reason)
        If msgReason.IsOk Then
            CB_Reason.DataSource = msgReason.Dt
            CB_Reason.ValueMember = "Remark"
            CB_Reason.DisplayMember = "Remark"
        End If
        ''部门
        Dim msgWorkshop As DtReturnMsg = BaseClass.ComFun.Dept_Get()
        If msgWorkshop.IsOk Then
            CB_Dept_No.ValueMember = "Dept_No"
            CB_Dept_No.DisplayMember = "Dept_Name"
            CB_Dept_No.DataSource = msgWorkshop.Dt
        End If
        ''业务员
        'Employee_List1.Set_TextBox(TB_Operator, TB_Upd_User)
        'TB_Operator.Tag = "0"

        FG1.IniFormat()
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
        If Mode = Mode_Enum.Add AndAlso CB_Reason.Items.Count > 0 Then

            CB_Reason.SelectedIndex = -1
            CB_Reason.SelectedIndex = 0
        End If
        If Mode = Mode_Enum.Add AndAlso CB_Dept_No.Items.Count > 0 Then
            Dim msgDept As DtReturnMsg = ComFun.User_GetDept(PClass.PClass.User_ID)
            If msgDept.IsOk Then
                Dim i As Int16 = 0
                If msgDept.Dt.Rows.Count > 0 Then
                    For Each dr As DataRow In msgWorkshop.Dt.Rows
                        If IsNull(dr("Dept_No"), "") = IsNull(msgDept.Dt.Rows(0)("Employee_Dept"), "") Then
                            CB_Dept_No.SelectedIndex = i
                            Exit For
                        End If
                        i = i + 1
                    Next
                End If
            End If
            CanLingliao = True
        End If


        SetStep()

    End Sub

    Sub CopyMe(Optional ByVal _isJialiao As Boolean = False)
        Me.IsJiaLiao = _isJialiao
        CanLingliao = True
        Me.MainBill = TB_ID.Text
        LId = ""
        TB_ID.Text = ""

        Mode = Mode_Enum.Add
        If CheckRight(ID, ClassMain.Add) = False Then Me.ShowErrMsg("没有权限添加" & Ch_Name & "!", True) : Exit Sub
        TB_Upd_User.Text = User_Display
        Me.Ch_Name = Me.Ch_Name.Replace("领料", "加料")
        LabelTitle.Text = "新建" & Me.Ch_Name
        Cmd_Preview.Enabled = False
        Cmd_Print.Enabled = False
        Cmd_Print.Enabled = False
        Cmd_Preview2.Enabled = False
        Cmd_Print2.Enabled = False
        dtTable.Rows(0)("State") = Enum_State.AddNew
        dtTable.Rows(0)("PrintOne") = False
        dtTable.Rows(0)("PrintTwo") = False
        DTP_sDate.Value = GetDate()
        SetForm(dtTable)
        Bill_Id_Date = #1/1/1999#
        GetNewID()
        Cmd_Preview.Enabled = False
        TB_State_User.Text = ""

        TB_BZ_ZL.Focus()
        If _isJialiao Then
            Cmd_GetGY.Visible = True
            FG1.Rows.Count = 1
            CaculateSumAmount()
        End If
        If _isJialiao Then TB_Produce_ID.ReadOnly = True
    End Sub

    Protected Sub Me_Refresh()
        Dim msgTable As DtReturnMsg = Dao.LingLiao_GetById(Bill_ID)
        If msgTable.IsOk Then
            If IsBidings Then
                DvUpdateToDt(msgTable.Dt, dtTable, New List(Of String))
            Else
                dtTable = msgTable.Dt
            End If
            dtTable.AcceptChanges()
            If Mode = Mode_Enum.Modify AndAlso msgTable.Dt.Rows.Count = 0 Then
                ShowErrMsg("没有找到" & Ch_Name & "[" & Bill_ID & "]", True)
                Exit Sub
            End If
            SetForm(dtTable)
        End If

        Select Case Mode
            Case Mode_Enum.Add

                If CheckRight(ID, ClassMain.Add) = False Then Me.ShowErrMsg("没有权限添加" & Ch_Name & "!", True) : Exit Sub

                Dim msg As DtReturnMsg = Dao.LingLiao_SelListById(0)
                If msg.IsOk Then dtList = msg.Dt
                FG1.Rows.Count = 2
                FG1.ReAddIndex()
                DTP_sDate.Value = GetDate()
                TB_Upd_User.Text = User_Display
                LabelTitle.Text = "新建" & Me.Ch_Name
                Cmd_Preview.Enabled = False
                Cmd_Print.Enabled = False
                Cmd_Preview2.Visible = False
                Cmd_Print2.Visible = False

                GetNewID()
                MainBill = TB_ID.Text
            Case Mode_Enum.Modify

                Dim msg As DtReturnMsg = Dao.LingLiao_SelListById(Bill_ID)
                Cmd_Preview.Enabled = True
                Cmd_Print.Enabled = True
                Cmd_Preview.Enabled = True
                Cmd_Print.Enabled = True
                If msg.IsOk Then
                    dtList = msg.Dt
                    Try
                        LastLine = msg.Dt.Rows(0)("Line")
                    Catch ex As Exception
                        LastLine = 0
                    End Try
                    FG1.DtToSetFG(msg.Dt)
                    '重新计算比例 如果比例是Null

                    For i As Integer = 1 To FG1.Rows.Count - 1
                        If IsNumeric(FG1.Item(i, "sPercent")) = False Then
                            CacPercent(i)
                        End If
                    Next
                    If FG1.Rows.Count > 1 Then
                        If FG1.Item(FG1.Rows.Count - 1, "IsPageTwo") Then
                            Cmd_Preview2.Visible = True
                            Cmd_Print2.Visible = True
                        End If
                    End If

                Else
                    FG1.Rows.Count = 1

                End If
                LId = TB_ID.Text
                LabelTitle.Text = "修改" & Me.Ch_Name
                If IsJiaLiao = False Then
                    GetPage(dtTable.Rows(0)("Produce_ID"))
                End If
        End Select
        CacQty_ALL(True)
        CaculateSumAmount()

        dtList.AcceptChanges()
        ' Dim T As New Threading.Thread(AddressOf GetDtMsg)
        '   T.Start()
        If Me.Mode = Mode_Enum.Add Then
            '   TB_Produce_ID.Text = Me.F_RS_ID
            '   CB_Reason.Text = Me.P_F_RS_ID2
            If Not Me.ReturnObj Is Nothing Then
                SetGoodsFromProduce()
            End If
            If CB_Dept_No.Items.Count > 0 Then
                CB_Dept_No.SelectedIndex = 0
            End If
        ElseIf Me.Mode = Mode_Enum.Modify Then
        End If

        If IsJiaLiao = True Then
            FG1.Cols("IsPageTwo").Visible = False
      
        End If


    End Sub


#Region "根据生产单生成列表"
    Protected Sub SetGoodsFromProduce()
        If Not Me.ReturnObj Is Nothing AndAlso FG1.CanEditing AndAlso FG1.RowSel > 0 Then
            Dim dt As DataTable = ReturnObj

            FG1.Rows.Count = 1
            FG1.CanEditing = False
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
            FG1.DtToSetFG(dtList)
            CaculateSumAmount()
            FG1.CanEditing = True
        Else

        End If
        Me.ReturnObj = Nothing
    End Sub

#End Region

#Region "生产单选择"

    ''Private Sub TB_Produce_ID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_Produce_ID.TextChanged
    ''    If TB_Produce_ID.Text <> "" Then
    ''        Cmd_AddRow.Enabled = False
    ''        Cmd_RemoveRow.Enabled = False
    ''    End If
    ''End Sub

    'Private Sub Cmd_ProduceSel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_ProduceSel.Click
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
    '        TB_Produce_ID.Text = ReturnId
    '        GetProduceByNo(ReturnId)

    '    End If
    '    Me.ReturnId = ""
    'End Sub

    'Protected Sub GetProduceByNo(ByVal _No As String)
    '    Dim msg As DtReturnMsg = Dao.Produce_SelListById(TB_Produce_ID.Text)
    '    FG1.CanEditing = False
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
    '        FG1.DtToSetFG(dtList)
    '        FG1.ReAddIndex()
    '        CaculateSumAmount()
    '    Else
    '        ShowProduceSel(_No)
    '    End If
    '    FG1.CanEditing = True
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
        ReSetPageTwo()

        Dim dt As DataTable
        Dim ID As String = IIf(Mode = Mode_Enum.Add, TB_ID.Text, LId)
        dt = dtTable
        Dim dr As DataRow = dt.Rows(0)
        '  dr("Operator") = Val(TB_Operator.Tag)
        dr("State") = State
        dr("IsJiaLiao") = IsJiaLiao
        dr("mainBill") = MainBill
        If CB_Dept_No.SelectedIndex >= 0 Then
            dr("Dept_No") = CB_Dept_No.SelectedValue
        Else
            dr("Dept_No") = 0
        End If
        '获取客户ID
        dr("Client_ID") = Val(TB_ClientName.Tag)
        '获取色号ID
        dr("BZC_ID") = CB_BZC.IDAsInt   'Val(TB_BZC_ID.Tag) 
        dr("BZ_ID") = CB_BZ.IDAsInt ' Val(TB_BZ_ID.Tag)
        dr("BZC_No") = CB_BZC.NoValue
        dr("Type") = BType
        dtTable.Rows(0)("GY_ID1") = LabelGY1.Tag
        dtTable.Rows(0)("GY_ID2") = 0
        dr("OldID") = Text_Old.Text
        ComFun.GetColValue(dr, Tb_WaterLevel, "0", "", False, FormatSharp("waterlevel"))
        dr(CB_Ratio.Name.Substring(3)) = Val(CB_Ratio.Text)
        '   dr("Payed") = dr("SumAmount") - IsNull(dr("UnPayed"), 0)
        dt.AcceptChanges()
        dtList = dtList.Clone
        For i As Integer = 1 To FG1.Rows.Count - 1
            dr = dtList.NewRow
            dr("ID") = ID
            '   dr("Store_ID") = Fg1.Item(i, "Store_ID")
            dr("DyingStep") = FG1.Item(i, "DyingStep")
            dr("WL_ID") = Val(FG1.Item(i, "WL_ID"))
            dr("Price") = Val(FG1.Item(i, "Price"))
            dr("Price_LL") = Val(FG1.Item(i, "Price_LL"))
            dr("Cost") = Val(FG1.Item(i, "Cost"))
            dr("Qty") = Val(FG1.Item(i, "Qty"))
            dr("WL_Unit_LL") = FG1.Item(i, "WL_Unit_LL")
            dr("WL_Unit_LL2") = FG1.Item(i, "WL_Unit_LL2")
            dr("ByPercent") = IIf(FG1.Item(i, "ByPercent") Is Nothing, False, FG1.Item(i, "ByPercent"))
            If FG1.Item(i, "sPercent") Is Nothing Then
                dr("sPercent") = 0
            Else
                dr("sPercent") = Val(FG1.Item(i, "sPercent"))
            End If

            dr("WLPercent") = Val(FG1.Item(i, "WLPercent"))
            dr("IsPageTwo") = FG1.Item(i, "IsPageTwo")
            dr("Step") = Val(FG1.Item(i, "Step"))
            dr("IsZJ") = IIf(FG1.Item(i, "IsZJ") Is Nothing, False, FG1.Item(i, "IsZJ"))
            '实际扣除的库存=显示数量*单位转换*百分比，如果没有百分比则以100%算
            Dim p As Double = Val(FG1.Item(i, "WlPercent"))
            If p = 0 Then
                p = 1
            End If
            dr("Qty_Store") = dr("Qty") * ComFun.Unit_Convert(FG1.Item(i, "WL_Unit_LL"), FG1.Item(i, "WL_Unit_LL2")) * p


            dr("Amount") = Val(FG1.Item(i, "Amount"))
            dr("LRemark") = FG1.Item(i, "LRemark")
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
        If Mode = Mode_Enum.Add Then
            Cmd_Modify.Visible = True
            Cmd_Modify.Enabled = True
        Else
            Cmd_Modify.Visible = Cmd_Modify.Tag
            Cmd_Modify.Enabled = Cmd_Modify.Tag
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
            Cmd_Rebuild.Visible = False
            Cmd_Rebuild.Enabled = False
            Cmd_SetValid.Visible = False
            Cmd_SetValid.Enabled = False
            Cmd_SetInValid.Visible = Cmd_SetInValid.Tag
            Cmd_SetInValid.Enabled = False
            Cmd_Del.Enabled = False

            LabelState.Text = "新建"
            LabelState.ForeColor = Color.Black
            dt.Rows.Add(Dr)
            dt.AcceptChanges()
            Cmd_JiaLiao.Visible = False
            Cmd_ShowJiaLiao.Visible = False

            LockForm(False)
        Else
            Dr = dt.Rows(0)
            State = Dr("State")
            Cmd_RefreshCost.Visible = True
            Select Case State
                Case Enum_State.AddNew '新建
                    LabelState.Text = "新建"
                    LabelState.ForeColor = Color.Black


                    Cmd_Audit.Visible = Cmd_Audit.Tag
                    Cmd_Audit.Enabled = True
                    Cmd_UnAudit.Visible = False
                    Cmd_UnAudit.Enabled = False
                    CB_Reason.Enabled = True
                    CB_Dept_No.Enabled = True
                    Cmd_AddRow.Enabled = True
                    Cmd_Del.Enabled = Cmd_Del.Tag
                    Cmd_RemoveRow.Enabled = True


                    Cmd_Rebuild.Visible = False
                    Cmd_Rebuild.Enabled = True
                    Cmd_SetValid.Visible = False
                    Cmd_SetValid.Enabled = True
                    Cmd_SetInValid.Visible = Cmd_SetInValid.Tag
                    Cmd_SetInValid.Enabled = True
                    Cmd_Del.Enabled = True

                    Cmd_JiaLiao.Visible = Cmd_JiaLiao.Tag AndAlso Not IsJiaLiao AndAlso Not IsNull(Dr("IsPageTwo"), False)
                    Cmd_ShowJiaLiao.Visible = Cmd_ShowJiaLiao.Tag AndAlso Not IsJiaLiao

                    LockForm(False)
                    If Mode = Mode_Enum.Modify Then
                        TB_Produce_ID.ReadOnly = True
                    End If

                Case Enum_State.Invoid '作废
                    Cmd_RefreshCost.Visible = False
                    LabelState.Text = "已作废"
                    LabelState.ForeColor = Color.Red
                    Cmd_Modify.Enabled = False

                    Cmd_Audit.Visible = Cmd_Audit.Tag
                    Cmd_Audit.Enabled = False
                    Cmd_UnAudit.Visible = False
                    Cmd_UnAudit.Enabled = False


                    Cmd_AddRow.Enabled = False

                    Cmd_Del.Enabled = False
                    Cmd_RemoveRow.Enabled = False

                    Cmd_Rebuild.Visible = Cmd_Rebuild.Tag
                    Cmd_Rebuild.Enabled = True
                    Cmd_SetValid.Visible = Cmd_SetValid.Tag
                    Cmd_SetValid.Enabled = True
                    Cmd_SetInValid.Visible = False
                    Cmd_SetInValid.Enabled = False


                    Cmd_JiaLiao.Visible = False
                    Cmd_ShowJiaLiao.Visible = False
                    If IsNull(Dr("IsPageTwo"), False) = True AndAlso Dao.LingLiao_Get_State(Dr("MainBill"), Enum_State.Invoid) = True Then
                        Cmd_Rebuild.Visible = Cmd_Rebuild.Tag
                        Cmd_Rebuild.Enabled = False
                        Cmd_SetValid.Visible = Cmd_SetValid.Tag
                        Cmd_SetValid.Enabled = False
                    End If
                    LockForm(True)
                Case Enum_State.Audited '审核
                    Cmd_RefreshCost.Visible = False
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

                    Cmd_Rebuild.Visible = False
                    Cmd_Rebuild.Enabled = False
                    Cmd_SetValid.Visible = False
                    Cmd_SetValid.Enabled = False
                    Cmd_SetInValid.Visible = Cmd_SetInValid.Tag
                    Cmd_SetInValid.Enabled = False


                    Cmd_JiaLiao.Visible = Cmd_JiaLiao.Tag AndAlso Not IsJiaLiao
                    Cmd_ShowJiaLiao.Visible = Cmd_ShowJiaLiao.Tag AndAlso Not IsJiaLiao
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
            TB_Produce_ID.DataBindings.Add("Text", dtTable, TB_Produce_ID.Name.Substring(3), False, DataSourceUpdateMode.OnPropertyChanged, "")

            ' TB_BZC_ID.DataBindings.Add("Text", dtTable, "BZC_No", False, DataSourceUpdateMode.OnPropertyChanged, "")
            TB_BZC_Name.DataBindings.Add("Text", dtTable, TB_BZC_Name.Name.Substring(3), False, DataSourceUpdateMode.OnPropertyChanged, "")

            TB_RanSeShenPi.DataBindings.Add("Text", dtTable, TB_RanSeShenPi.Name.Substring(3), False, DataSourceUpdateMode.OnPropertyChanged, "")
            TB_LiaoFangQueRen.DataBindings.Add("Text", dtTable, TB_LiaoFangQueRen.Name.Substring(3), False, DataSourceUpdateMode.OnPropertyChanged, "")

            TB_BZ_Qty.DataBindings.Add("Text", dtTable, TB_BZ_Qty.Name.Substring(3), False, DataSourceUpdateMode.OnPropertyChanged, 0)
            TB_BZ_ZL.DataBindings.Add("Text", dtTable, TB_BZ_ZL.Name.Substring(3), False, DataSourceUpdateMode.OnPropertyChanged, 0)

            IsBidings = True
        End If
        SetPrintMsg(Dr)
        LabelGY1.Tag = IsNull(dtTable.Rows(0)("GY_ID1"), 0)
        LabelGY1.Text = IsNull(dtTable.Rows(0)("GY_Name1"), "")
        LabelGY2.Tag = IsNull(dtTable.Rows(0)("GY_ID2"), 0)
        LabelGY2.Text = IsNull(dtTable.Rows(0)("GY_Name2"), "")
        ComFun.SetColValue(Dr, Tb_WaterLevel, "0", "", False, FormatSharp("waterlevel"))
        CB_Ratio.Text = IsNull(Dr(CB_Ratio.Name.Substring(3)), 8)

        TB_ClientName.Text = IsNull(dtTable.Rows(0)("Client_Name"), "")
        TB_ClientName.Tag = IsNull(dtTable.Rows(0)("Client_ID"), "0")
        '     Client_List1.GetByTextBoxTag(IsNull(dtTable.Rows(0)("Client_ID"), "0"))
        Employee_List1.GetByTextBoxTag(IsNull(dtTable.Rows(0)("Operator"), "0"))
        If Mode = Mode_Enum.Modify Then
            IsJiaLiao = IsNull(dtTable.Rows(0)("IsJiaLiao"), False)
        End If

        'Bz_List1.GetByTextBoxTag(IsNull(dtTable.Rows(0)("BZ_ID"), "0"))
        'If Val(IsNull(Dr("BZC_ID"), 0)) <> 0 Then
        '    TB_BZC_ID.Tag = Dr("BZC_ID")
        '    Bz_List1.SearchID = Dr("BZC_ID")
        '    Bz_List1.SearchType = Bz_List.ENum_SearchType.BZC
        '    TB_BZ_ID.ReadOnly = False
        'End If

        'CB_BZC.Enabled = True
        CB_BZC.IDValue = Val(IsNull(Dr("BZC_ID"), 0))
        CB_BZC.Text = CB_BZC.GetByTextBoxTag
        TB_BZC_Name.Text = IsNull(Dr("BZC_Name"), "")

        '  CB_BZ.Enabled = False
        CB_BZ.IDAsInt = IsNull(Dr("BZ_ID"), 0)
        CB_BZ.Text = CB_BZ.GetByTextBoxTag
        TB_BZ_Name.Text = CB_BZ.NameValue
        CB_BZ.SearchType = cSearchType.ENum_SearchType.BZC
        CB_BZ.SearchID = CB_BZC.IDValue

        If IsNull(dt.Rows(0)("OldID"), "") <> "" Then
            LB_Old.Visible = True
            Text_Old.Visible = True
            Text_Old.Text = IsNull(dt.Rows(0)("OldID"), "")

            FG1.Cols("IsPageTwo").AllowEditing = False
        Else
            LB_Old.Visible = False
            Text_Old.Visible = False
        End If


        If Mode = Mode_Enum.Add Then
            MainBill = Bill_ID

        Else
            MainBill = IsNull(dtTable.Rows(0)("MainBill"), "")
        End If

        If IsJiaLiao = False Then
            JL_Qty = Dao.LingLiao_CountJiaLiao(TB_Produce_ID.Text)
            LB_Note.Text = "加料单数量为：" & JL_Qty
        Else
            JL_Qty = 0
            Cmd_JiaLiao.Visible = False
            Cmd_ShowJiaLiao.Visible = False
            Ch_Name = Ch_Name.Replace("领料", "加料")
            LB_Note.Text = "领料单号：" & MainBill
            LB_Note.ForeColor = Color.Blue
            LB_Note.Tag = MainBill
            FG1.Cols("IsPageTwo").Visible = False
            LB_Page.Visible = False
        End If

        Dim Cmd_IsPageTwo As Boolean = IsNull(dtTable.Rows(0)("IsPageTwo"), False)
        Cmd_Print2.Visible = Cmd_IsPageTwo
        Cmd_Preview2.Visible = Cmd_IsPageTwo
        Cmd_Print.Visible = Not Cmd_IsPageTwo
        Cmd_Preview.Visible = Not Cmd_IsPageTwo

        Dao.DXLingLiao_DB_NAME = Ch_Name
        Me.Title = Ch_Name
    End Sub

    Sub SetPrintMsg(ByVal Dr As DataRow)
        If IsNull(Dr("PrintOne"), False) Then
            LB_Page1.Visible = True
        Else
            LB_Page1.Visible = False
        End If
        If IsNull(Dr("PrintTwo"), False) Then
            LB_Page2.Visible = True
        Else
            LB_Page2.Visible = False
        End If
    End Sub

    Sub LockForm(ByVal Lock As Boolean)
        ' TB_ID.ReadOnly = Lock
        TB_BZ_ZL.ReadOnly = Lock
        DTP_sDate.Enabled = Not Lock
        Cmd_AddRow.Enabled = Not Lock
        Cmd_RemoveRow.Enabled = Not Lock
        CB_Reason.Enabled = Not Lock
        CB_Dept_No.Enabled = Not Lock
        TB_BZ_Qty.ReadOnly = Lock
        DTP_sDate.Enabled = False
        FG1.CanEditing = Not Lock
        FG1.IsClickStartEdit = Not Lock
        '    TB_Operator.ReadOnly = Lock

        TB_RanSeShenPi.ReadOnly = Lock
        TB_LiaoFangQueRen.ReadOnly = Lock
        TB_Remark.ReadOnly = Lock
        ' Cmd_ProduceSel.Enabled = Not Lock
        TB_Produce_ID.ReadOnly = Lock
        '   CB_BZ.Enabled = Not Lock
        '  CB_BZC.Enabled = Not Lock

        Cmd_AddGy.Enabled = Not Lock
        Cmd_InsertGY.Enabled = Not Lock

        '  Cmd_ShowJiaLiao.Enabled = Not Lock
        ' Cmd_JiaLiao.Enabled = Not Lock
        'TB_BZC_Name.ReadOnly = Lock
        CB_Ratio2.Enabled = Not Lock
        CB_Ratio.Enabled = Not Lock
    End Sub


    ''' <summary>
    ''' FG合计
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub CaculateSumAmount()
        If FG1.Rows.Count <= 1 Then
            TB_SumQty.Text = 0
            TB_SumAmount.Text = 0

            Exit Sub
        End If
        Dim SumQty As Double = 0
        Dim SumAmount As Double = 0
        For R As Integer = 1 To FG1.Rows.Count - 1

            FG1.Item(R, "Amount") = Val(FG1.Item(R, "Qty")) * Val(FG1.Item(R, "Price_LL"))
            SumAmount = SumAmount + Val(FG1.Item(R, "Amount"))
            SumQty = SumQty + Val(FG1.Item(R, "Qty"))
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
        TB_BZ_ZL.Focus()
        Tool_Top.Focus()
        FG1.FinishEditing(False)

        If CheckForm() Then
            If Mode = Mode_Enum.Add Then
                ShowConfirm("是否保存新" & Ch_Name & "?", AddressOf SaveLingLiao)
            Else
                If CheckIsModify() Then
                    ShowConfirm(Ch_Name & "[" & TB_ID.Text & "] 已经被其他人修改过,是否覆盖别人的修改?", AddressOf SaveLingLiao)
                Else
                    ShowConfirm("是否保存" & Ch_Name & "[" & TB_ID.Text & "] 的修改?", AddressOf SaveLingLiao)
                End If
            End If
        End If

    End Sub

    ''' <summary>
    ''' 保存修改
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub SaveLingLiao(Optional ByVal Audit As Boolean = False)
        Dim R As MsgReturn
        Dim Returnolist As New List(Of String)
        Returnolist.Add(TB_ID.Text)
        Dim Dt As DataTable = GetForm()
        '     Dt.Rows(0).Item("LingLiaoType") = Me.LingLiaoType
        If Me.Mode = Mode_Enum.Add Then
            If FG1.Item(FG1.Rows.Count - 1, "IsPageTwo") AndAlso Text_Old.Text = "" Then
                Dt.Rows(0)("IsPageTwo") = False
                Dim li As List(Of Double) = Sum_Qty_Amount(False)
                Dt.Rows(0)("SumAmount") = li(0)
                Dt.Rows(0)("SumQty") = li(1)
                R = Dao.LingLiao_Add(Dt, getlist(dtList, "IsPageTwo"))
                ReGetNewID()
                dtchang(Dt)
                R = Dao.LingLiao_Add(Dt, getlist(dtList, "IsPageTwo", TB_ID.Text))

            Else

                R = Dao.LingLiao_Add(Dt, dtList)
            End If
        Else
            R = Dao.LingLiao_Save(LId, Dt, dtList)
        End If
        If R.IsOk Then
            LId = TB_ID.Text
            If Returnolist.Contains(TB_ID.Text) = False Then
                Returnolist.Add(TB_ID.Text)
            End If

            LastForm.ReturnObj = Returnolist
            Mode = Mode_Enum.Modify
            If Audit Then
                Dim msg As MsgReturn = Dao.LingLiao_Audited(TB_ID.Text, True)
                If msg.IsOk Then
                    Bill_ID = TB_ID.Text
                    Mode = Mode_Enum.Modify
                    Me_Refresh()
                    ShowOk(msg.Msg)
                Else
                    ShowErrMsg("保存成功,但" & msg.Msg)
                End If
                Exit Sub
            End If
            If TB_ID.Text = Bill_ID.Replace("-", "") Then Bill_ID = Bill_ID.Replace("-", "")
            ShowConfirm(R.Msg & "是否退出?", AddressOf Me.Close, AddressOf Me_Refresh)
        Else
        ShowErrMsg(R.Msg)
        End If
    End Sub

    ''' <summary>
    ''' 计算分页时数量，金额
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function Sum_Qty_Amount(ByVal IsPageTwo As Boolean) As List(Of Double)
        Dim li As New List(Of Double)
        Dim SumAmount As Double = 0
        Dim SumQty As Double = 0
        For i As Integer = 1 To FG1.Rows.Count - 1
            If FG1.Item(i, "IsPageTwo") = IsPageTwo Then
                FG1.Item(i, "Amount") = Val(FG1.Item(i, "Qty")) * Val(FG1.Item(i, "Price_LL"))
                SumAmount = SumAmount + Val(FG1.Item(i, "Amount"))
                SumQty = SumQty + Val(FG1.Item(i, "Qty"))
            End If
        Next
        li.Add(FormatNum(SumAmount))
        li.Add(FormatMoney(SumQty))
        Return li
    End Function


    Private Function getlist(ByVal dtlist As DataTable, ByVal Col As String, Optional ByVal id As String = "") As DataTable
        Dim list As DataTable = dtlist.Clone
        Dim dr() As DataRow
        If id = "" Then
            dr = dtlist.Select(Col & "= False")
            For Each drt As DataRow In dr
                list.ImportRow(drt)
            Next
            Return list
        Else
            dr = dtlist.Select(Col & "= true")
            For Each drt As DataRow In dr
                drt("ID") = id
                list.ImportRow(drt)
            Next

            Return list
        End If
    End Function

    Private Sub dtchang(ByRef dttable As DataTable)
        If dttable Is Nothing Then
            Exit Sub
        End If
        dttable.Rows(0)("Ratio") = CB_Ratio2.Text
        dttable.Rows(0)("GY_ID1") = 0
        dttable.Rows(0)("GY_ID2") = LabelGY2.Tag
        dttable.Rows(0)("IsPageTwo") = True
        Dim li As List(Of Double) = Sum_Qty_Amount(True)
        dttable.Rows(0)("SumAmount") = li(0)
        dttable.Rows(0)("SumQty") = li(1)
    
    End Sub




    ''' <summary>
    ''' 验证信息
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Function CheckForm() As Boolean


        CacQty_ALL(True)
        CaculateSumAmount()

        TB_Produce_ID.Text = ComFun.FixGH(TB_Produce_ID.Text)
        Dim CR As MsgReturn = ComFun.CheckGH(TB_Produce_ID.Text)
        If CR.IsOk = False Then
            ShowErrMsg(CR.Msg, AddressOf TB_Produce_ID.Focus)
            Return False
        End If

        If Mode = Mode_Enum.Add AndAlso OKGH <> TB_Produce_ID.Text Then
            ShowErrMsg("当前缸号[" & OKGH & "]已经被改变,请在缸号输入框按一次回车键!", AddressOf TB_Produce_ID.Focus)
            Return False
        End If

        TB_ID.Text = TB_ID.Text.Trim
        TB_ID.Text = TB_ID.Text.Replace("'", "")
        If TB_ID.Text = "" Then
            ShowErrMsg(Ch_Name & "单号不能为空!", AddressOf TB_ID.Focus)
            Return False
        End If
        If (Mode = Mode_Enum.Add OrElse (Mode = Mode_Enum.Modify AndAlso LId <> TB_ID.Text)) AndAlso Dao.LingLiao_CheckID(TB_ID.Text) Then
            ShowErrMsg(Ch_Name & "单号[" & TB_ID.Text & "]已经存在!", AddressOf TB_ID.Focus)
            Return False
        End If

        If CB_BZ.IDAsInt = 0 Then
            ShowErrMsg("布种编号不能为空!", AddressOf CB_BZ.Focus)
            Return False
        End If
        If CB_BZC.IDAsInt = 0 Then
            ShowErrMsg("色号不能为空!", AddressOf CB_BZC.Focus)
            Return False
        End If
        If Val(TB_BZ_ZL.Text) <= 0 Then
            ShowErrMsg("重量必须大于0!", AddressOf TB_BZ_ZL.Focus)
            Return False
        End If
        Dim E As Boolean = FG1.CanEditing
        FG1.CanEditing = False
        For i As Integer = FG1.Rows.Count - 1 To 1 Step -1
            Try
                If (FG1.Item(i, "DyingStep") = "" AndAlso (Val(FG1.Item(i, "Qty")) = 0 OrElse Val(FG1.Item(i, "WL_ID")) = 0)) Then
                    FG1.RemoveItem(i)
                End If
                If Val(FG1.Item(i, "Qty")) < 0 Then
                    FG1.Item(i, "Qty") = -Val(FG1.Item(i, "Qty"))
                End If
                'If Val(Fg1.Item(i, "Qty")) = 0 OrElse Val(Fg1.Item(i, "Amount")) = 0 OrElse Val(Fg1.Item(i, "WL_ID")) = 0 Then
                '    Fg1.RemoveItem(i)
                'End If
            Catch ex As Exception
            End Try
        Next
        FG1.CanEditing = E
        If FG1.Rows.Count <= 1 Then
            'Cmd_GoodsSel.Visible = False
            ShowErrMsg("列表不能为空!")
            Return False
        End If

        If CanLingliao = False AndAlso IsJiaLiao = False AndAlso Mode = Mode_Enum.Add Then
            ShowErrMsg("缸号[" & TB_Produce_ID.Text & "]未配布,不能开领料单!", AddressOf TB_Produce_ID.Focus)
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
    Sub ReSetPageTwo()
        Dim C As Boolean = FG1.CanEditing
        FG1.CanEditing = False
        Dim B As Boolean = False
        For i As Integer = 1 To FG1.Rows.Count - 1
            If B = False Then
                If FG1.Item(i, "IsPageTwo") Then
                    B = True
                Else
                    FG1.Item(i, "IsPageTwo") = False
                End If
            Else
                FG1.Item(i, "IsPageTwo") = True
            End If
        Next

        FG1.CanEditing = C
        Ratio2Show(FG1.Item(FG1.Rows.Count - 1, "IsPageTwo"))
    End Sub

    Private Sub Fg1_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles FG1.Click
        If FG1.CanEditing = True Then
            If FG1.MouseCol > 0 AndAlso FG1.MouseRow > 0 Then
                If FG1.Cols(FG1.MouseCol).Name = "IsPageTwo" Then
                    Dim C As Boolean = FG1.CanEditing
                    FG1.CanEditing = False
                    Dim B As Boolean = True

                    Dim i As Integer = FG1.MouseRow
                    Do While i < FG1.Rows.Count
                        FG1.Item(i, "IsPageTwo") = B
                        i = i + 1
                    Loop
                    i = FG1.MouseRow - 1
                    Do While i > 0
                        FG1.Item(i, "IsPageTwo") = Not B
                        i = i - 1
                    Loop

                    'If FG1.Item(FG1.RowSel, "IsPageTwo") Then
                    '    FG1.Item(FG1.RowSel, "IsPageTwo") = False

                    'Else
                    '    FG1.Item(FG1.RowSel, "IsPageTwo") = True
                    '    FG1.Item(FG1.RowSel, "IsPageTwo") = Not FG1.Item(FG1.RowSel, "IsPageTwo")
                    'End If

                    FG1.Item(FG1.RowSel, "IsPageTwo") = Not FG1.Item(FG1.RowSel, "IsPageTwo")
                    FG1.CanEditing = C
                End If
            End If
        End If
        Ratio2Show(FG1.Item(FG1.Rows.Count - 1, "IsPageTwo"))
    End Sub

    Private Sub CB_Unit_LL_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles CB_Unit_LL.SelectionChangeCommitted
        FG1.Item(FG1.RowSel, "WL_Unit_LL") = CB_Unit_LL.SelectedItem
        FG1.Item(FG1.RowSel, "Price") = Val(FG1.Item(FG1.RowSel, "Cost")) * ComFun.Unit_Convert(FG1.Item(FG1.RowSel, "WL_Unit_LL"), FG1.Item(FG1.RowSel, "WL_Unit_LL2"))
        Dim P As Double = Val(FG1.Item(FG1.RowSel, "WLPercent"))
        If P = 0 Then P = 1
        FG1.Item(FG1.RowSel, "Price_LL") = FG1.Item(FG1.RowSel, "Price") * P
    End Sub




    Private Sub Fg1_AfterScroll(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RangeEventArgs) Handles FG1.AfterScroll
        ShowGoodsSelCmd()
    End Sub

    Private Sub Fg1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FG1.Click
        'If FG1.CanEditing = False Then Exit Sub
        'If FG1.Editor Is Nothing Then
        '    If FG1.RowSel < 0 Then
        '        Exit Sub
        '    End If
        '    If FG1.Cols(FG1.ColSel).AllowEditing AndAlso FG1.CanEditing Then
        '        FG1.LastKey = 0
        '        FG1.StartEditing()
        '    End If
        'End If
    End Sub
    Private Sub Fg1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles FG1.DoubleClick
        If FG1.RowSel > 0 Then
            If FG1.Cols("WL_Name").Index = FG1.ColSel Then
                ShowGoodsSel(FG1.Item(FG1.RowSel, "WL_No"))
            End If
        End If
    End Sub

#Region "WL选择"

    Dim IsWLSelect As Boolean
    Private Sub CB_WL_FG_Col_Sel(ByVal Col_No As String, ByVal Col_Name As String, ByVal ID As String) Handles CB_WL_FG.Col_Sel
        IsWLSelect = True
        FG1.Item(FG1.RowSel, "WL_Name") = Col_Name
        FG1.Item(FG1.RowSel, "WL_ID") = ID
        FG1.GotoNextCell("WL_No")
    End Sub
    Private Sub CB_WL_FG_SetEmpty() Handles CB_WL_FG.SetEmpty
        FG1.Item(FG1.RowSel, "WL_ID") = 0
        FG1.Item(FG1.RowSel, "WL_No") = ""
        FG1.Item(FG1.RowSel, "WL_Name") = ""
        FG1.Item(FG1.RowSel, "WL_Unit_LL") = ""
        FG1.Item(FG1.RowSel, "WL_Unit_LL2") = ""
        FG1.Item(FG1.RowSel, "WLPercent") = 0
        FG1.Item(FG1.RowSel, "Qty") = 0
        FG1.Item(FG1.RowSel, "IsZJ") = 0
        FG1.Item(FG1.RowSel, "WL_Spec") = ""
        FG1.Item(FG1.RowSel, "sPercent") = 0
        FG1.Item(FG1.RowSel, "Cost") = 0
        FG1.Item(FG1.RowSel, "Price") = 0
        FG1.Item(FG1.RowSel, "Amount") = 0
        SetPrice_LL()
    End Sub
    Private Sub CB_WL_FG_Col_SelRow(ByVal Dr As System.Data.DataRow) Handles CB_WL_FG.Col_SelRow
        FG1.Item(FG1.RowSel, "WL_Spec") = Dr("WL_Spec")
        FG1.Item(FG1.RowSel, "WL_Unit_LL") = Dr("WL_Unit_LL")
        FG1.Item(FG1.RowSel, "WL_Unit_LL2") = Dr("WL_Unit")
        FG1.Item(FG1.RowSel, "WLPercent") = IsNull(Dr("WL_Percent"), 0)
        FG1.Item(FG1.RowSel, "IsZJ") = IsNull(Dr("IsZJ"), 0)
        FG1.Item(FG1.RowSel, "Cost") = IsNull(Dr("WL_Cost"), 0)
        FG1.Item(FG1.RowSel, "Price") = Val(FG1.Item(FG1.RowSel, "Cost")) * ComFun.Unit_Convert(FG1.Item(FG1.RowSel, "WL_Unit_LL"), FG1.Item(FG1.RowSel, "WL_Unit_LL2"))
        SetPrice_LL()
    End Sub
    Private Sub CB_WL_FG_GetSearchEvent(ByRef Col_No As String, ByRef ID As String, ByVal Cancel As Boolean) Handles CB_WL_FG.GetSearchEvent
        CB_WL_FG.IDValue = FG1.Item(FG1.RowSel, "WL_ID")
    End Sub

    Sub FG_WL_No()
        FG1.StartEditing(FG1.RowSel, FG1.Cols("WL_No").Index)
    End Sub
#End Region

    Private Sub Fg1_AfterEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles FG1.AfterEdit
        If e.Row < 0 Then
            Exit Sub
        End If
        If FG1.LastKey = Keys.Enter Then
            FG1.LastKey = 0
            Select Case FG1.Cols(e.Col).Name
                Case "WL_No"
                    CB_WL_FG.Col_SelOne()
                    If FG1.Item(e.Row, "WL_Name") = "" Then
                        ShowErrMsg("请输入一个物料编号!", AddressOf FG_WL_No)
                    End If
                Case "Price_LL"
                    '修改当前单价时，当修改后单价不等于成本价时，修改成本价
                    Dim WP As Double = Val(FG1.Item(FG1.RowSel, "WLPercent"))
                    If WP = 0 Then WP = 1
                    Dim P2 As Double = FG1.Item(FG1.RowSel, "Price_LL") / WP
                    FG1.Item(FG1.RowSel, "Price") = P2
                    Dim p As Double = FG1.Item(FG1.RowSel, "Price") / ComFun.Unit_Convert(FG1.Item(FG1.RowSel, "WL_Unit_LL"), FG1.Item(FG1.RowSel, "WL_Unit_LL2"))
                    If p <> Val(FG1.Item(FG1.RowSel, "Cost")) Then
                        FG1.Item(FG1.RowSel, "Cost") = p
                    End If
                    ' Fg1.Item(Fg1.RowSel, "Cost") = Fg1.Item(Fg1.RowSel, "Price") / ComFun.Unit_Convert(Fg1.Item(Fg1.RowSel, "WL_Unit_LL"), Fg1.Item(Fg1.RowSel, "WL_Unit_LL2"))
                    FG1.Item(e.Row, e.Col) = Val(FG1.Item(e.Row, e.Col))
                    CaculateSumAmount()
                    FG1.GotoNextCell(e.Col)
                Case "Qty"
                    FG1.Item(e.Row, e.Col) = Val(FG1.Item(e.Row, e.Col))
                    If Not Val(FG1.Item(e.Row, e.Col)) = Val(FG1.LastText) Then
                        CacPercent(FG1.RowSel)

                        FG1.Item(e.Row, "ByPercent") = False
                    End If
                    CaculateSumAmount()
                    FG1.GotoNextCell(e.Col)
                Case "sPercent"
                    FG1.Item(e.Row, e.Col) = Val(FG1.Item(e.Row, e.Col))
                    If Not Val(FG1.Item(e.Row, e.Col)) = Val(FG1.LastText) Then
                        CacQty(FG1.RowSel)

                        FG1.Item(e.Row, "ByPercent") = True
                    End If
                    CaculateSumAmount()
                    FG1.GotoNextCell(e.Col)
                Case "WL_Unit_LL"
                    '转换单位是，也转换单价
                    FG1.Item(FG1.RowSel, "Price") = Val(FG1.Item(FG1.RowSel, "Cost")) * ComFun.Unit_Convert(FG1.Item(FG1.RowSel, "WL_Unit_LL"), FG1.Item(FG1.RowSel, "WL_Unit_LL2"))
                    SetPrice_LL()
                    FG1.GotoNextCell(e.Col)
                Case Else
                    FG1.GotoNextCell(e.Col)
            End Select
        Else
            If FG1.Cols(e.Col).Name = "WL_No" Then
                If FG1.LastText <> IsNull(FG1.Item(e.Row, "WL_No"), "") AndAlso IsWLSelect = False Then
                    FG1.Item(FG1.RowSel, "WL_ID") = 0
                    FG1.Item(FG1.RowSel, "WL_Name") = ""
                    FG1.Item(FG1.RowSel, "WL_Unit_LL") = ""
                    FG1.Item(FG1.RowSel, "WL_Spec") = ""
                End If
                IsWLSelect = False
            Else
                Select Case FG1.Cols(e.Col).Name

                    Case "Price"
                        '修改当前单价时，当修改后单价不等于成本价时，修改成本价
                        Dim p As Double = FG1.Item(FG1.RowSel, "Price") / ComFun.Unit_Convert(FG1.Item(FG1.RowSel, "WL_Unit_LL"), FG1.Item(FG1.RowSel, "WL_Unit_LL2"))
                        If p <> Val(FG1.Item(FG1.RowSel, "Cost")) Then
                            FG1.Item(FG1.RowSel, "Cost") = p
                        End If
                        SetPrice_LL()
                        CaculateSumAmount()

                    Case "WL_Unit_LL"
                        '转换单位是，也转换单价
                        FG1.Item(FG1.RowSel, "Price") = Val(FG1.Item(FG1.RowSel, "Cost")) * ComFun.Unit_Convert(FG1.Item(FG1.RowSel, "WL_Unit_LL"), FG1.Item(FG1.RowSel, "WL_Unit_LL2"))
                        SetPrice_LL()
                End Select

            End If
        End If
    End Sub

    Sub SetPrice_LL(Optional ByVal Row As Integer = -1)
        If Row = -1 Then Row = FG1.RowSel
        Dim WP As Double = Val(FG1.Item(Row, "WLPercent"))
        If WP = 0 Then WP = 1
        FG1.Item(Row, "Price_LL") = FG1.Item(Row, "Price") * WP
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
        FG1.AddRow()
        SetNewRowDefaulValue()
    End Sub

    Protected Sub SetNewRowDefaulValue()
        FG1.Item(FG1.Rows.Count - 1, "sPercent") = 0
        FG1.Item(FG1.Rows.Count - 1, "Step") = 0
        If IsJiaLiao Then
            FG1.Item(FG1.Rows.Count - 1, "ByPercent") = False
        Else
            FG1.Item(FG1.Rows.Count - 1, "ByPercent") = True
        End If
        SetStep()
    End Sub

    ''' <summary>
    ''' 减行
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_RemoveRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_RemoveRow.Click
        FG1.RemoveRow()
        SetStep()
    End Sub
    Private Sub Fg1_NextCell(ByVal e As PClass.FG.NextCellEventArgs) Handles FG1.NextCell

        Select Case e.Col
            Case "DyingStep"
                e.ToCol = FG1.Cols("WL_No").Index
            Case "WL_No"
                If IIf(FG1.Item(e.Row, "ByPercent") Is Nothing, False, FG1.Item(e.Row, "ByPercent")) Then
                    e.ToCol = FG1.Cols("sPercent").Index
                Else
                    e.ToCol = FG1.Cols("Qty").Index
                End If
            Case "sPercent", "LRemark", "Amount"
                If e.Row + 2 > FG1.Rows.Count Then
                    FG1.Cols("DyingStep").AllowEditing = False
                    AddRow()
                    FG1.Cols("DyingStep").AllowEditing = True
                End If
                e.ToRow = e.Row + 1
                e.ToCol = FG1.Cols("WL_No").Index
            Case "Qty", "WL_Unit_LL"
                If FG1.Cols("Price_LL").Visible = True Then
                    e.ToCol = FG1.Cols("Price_LL").Index
                Else
                    If e.Row + 2 > FG1.Rows.Count Then
                        FG1.Cols("DyingStep").AllowEditing = False
                        AddRow()
                        FG1.Cols("DyingStep").AllowEditing = True
                    End If
                    e.ToRow = e.Row + 1
                    e.ToCol = FG1.Cols("WL_No").Index
                End If
            Case Else
                '  If FG1.Cols("Price_LL").AllowEditing Then
                'e.ToCol = FG1.Cols("Price_LL").Index
                '   Else
                e.ToCol = e.ToCol + 1 ' FG1.Cols("sPercent").Index
                '  End If
        End Select
    End Sub



    'Private Sub Fg1_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles FG1.Enter
    '    'If Fg1.RowSel < 0 Then
    '    '    Exit Sub
    '    'End If
    '    'If Fg1.Cols(Fg1.ColSel).AllowEditing AndAlso Fg1.CanEditing Then
    '    '    Fg1.LastKey = 0
    '    '    Fg1.StartEditing()
    '    'End If
    '    ShowGoodsSelCmd()
    'End Sub

    'Private Sub Fg1_EnterCell(ByVal sender As Object, ByVal e As System.EventArgs) Handles FG1.EnterCell
    '    If FG1.RowSel < 0 Then
    '        Exit Sub
    '    End If
    '    'If FG1.Cols(FG1.ColSel).AllowEditing AndAlso FG1.CanEditing Then
    '    '    FG1.LastKey = 0
    '    '    FG1.StartEditing()
    '    'End If
    '    ShowGoodsSelCmd()
    'End Sub

    Private Sub Fg1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles FG1.KeyDown
        'If FG1.RowSel < 0 Then
        '    Exit Sub
        'End If
        'If FG1.Cols(FG1.ColSel).AllowEditing = False Then
        '    If e.KeyCode = Keys.Enter Then
        '        If FG1.ColSel < FG1.Cols("Qty").Index Then
        '            FG1.StartEditing(FG1.RowSel, FG1.Cols("Qty").Index)
        '        Else
        '            FG1.StartEditing(FG1.RowSel, FG1.Cols("Qty").Index)
        '        End If
        '    ElseIf e.KeyCode = Keys.Add AndAlso FG1.Cols(FG1.ColSel).Name = "WL_No" Then
        '        ShowGoodsSel()
        '    End If
        'End If
    End Sub

    Private Sub Fg1_KeyDownEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.KeyEditEventArgs) Handles FG1.KeyDownEdit
        If e.KeyCode = Keys.Add AndAlso FG1.Cols("WL_No").Index = e.Col AndAlso FG1.CanEditing Then
            ShowGoodsSel()
        End If
    End Sub

#End Region

#Region "物料选择"
    Dim gType As String = ""
    Protected Sub ShowGoodsSelCmd()
        'If FG1.ColSel > 0 AndAlso FG1.RowSel > 0 Then
        '    If FG1.CanEditing Then
        '        Dim C As C1.Win.C1FlexGrid.Column = FG1.Cols(FG1.ColSel)
        '        Dim R As C1.Win.C1FlexGrid.Row = FG1.Rows(FG1.RowSel)
        '        Select Case FG1.Cols(FG1.ColSel).Name
        '            Case "WL_No", "WL_Name"
        '                Cmd_GoodsSel.Left = FG1.Left + C.Left + C.WidthDisplay - Cmd_GoodsSel.Width + FG1.ScrollPosition.X + 1
        '                Cmd_GoodsSel.Top = FG1.Top + R.Top + FG1.ScrollPosition.Y + 1
        '                Cmd_GoodsSel.Height = R.HeightDisplay
        '                Cmd_GoodsSel.Visible = True
        '            Case Else
        '                Cmd_GoodsSel.Visible = False
        '        End Select
        '    Else
        '        Cmd_GoodsSel.Visible = False
        '    End If
        'Else
        '    Cmd_GoodsSel.Visible = False
        'End If
    End Sub

    Private Sub Cmd_GoodsSel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ShowGoodsSel()
    End Sub
    Protected Sub ShowGoodsSel(Optional ByVal _no As String = "")
        If _no Is Nothing Then _no = ""
        If _no = "" Then _no = FG1.Item(FG1.RowSel, "WL_No")
        Dim F As BaseForm = LoadFormIDToChild(10004, Me)
        If F Is Nothing Then Exit Sub
        FG1.RowSel = FG1.RowSel
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
        If Not Me.ReturnObj Is Nothing AndAlso FG1.CanEditing AndAlso FG1.RowSel > 0 Then
            Dim dr As DataRow = ReturnObj
            FG1.FinishEditing(True)
            DrToFGRow(dr, FG1.RowSel)
            If FG1.RowSel > 1 Then
                FG1.Item(FG1.RowSel, "Step") = FG1.Item(FG1.RowSel - 1, "Step")
            End If

            gType = IsNull(dr("WL_Type_ID"), "")
            FG1.GotoNextCell("WL_No")
        Else
            FG1.StartEditing(FG1.RowSel, FG1.Cols("WL_No").Index)
        End If
        Me.ReturnObj = Nothing
    End Sub

    Protected Sub SetGoods_FromGY(ByVal dt As DataTable, ByVal startRow As Integer)
        FG1.FinishEditing(True)
        FG1.Select(FG1.RowSel, FG1.Cols("WL_Name").Index, True)
        Dim C As Boolean = FG1.CanEditing
        FG1.CanEditing = False
        FG1.Redraw = False

        Try
            For Each dr As DataRow In dt.Rows
                FG1.Rows.Insert(startRow)
                DrToFGRow_GY(dr, startRow)
                startRow += 1
            Next
        Catch ex As Exception
        End Try
        CaculateSumAmount()
        CacQty_ALL(True)
        FG1.ReAddIndex()
        ReSetPageTwo()
        SetStep()


        FG1.Redraw = True
        FG1.CanEditing = C

    End Sub

    Private Sub DrToFGRow(ByVal dr As DataRow, ByVal i As Integer)
        FG1.Item(i, "WL_ID") = IsNull(dr("ID"), "")
        FG1.Item(i, "WL_No") = IsNull(dr("WL_No"), "")
        FG1.Item(i, "WL_Name") = IsNull(dr("WL_Name"), "")
        FG1.Item(i, "WL_Unit_LL") = IsNull(dr("WL_Unit_LL"), "")
        FG1.Item(i, "WL_Unit_LL2") = IsNull(dr("WL_Unit"), "")
        FG1.Item(i, "WL_Spec") = IsNull(dr("WL_Spec"), "")
        FG1.Item(i, "sPercent") = 1
        FG1.Item(i, "ByPercent") = True
        FG1.Item(i, "WlPercent") = IsNull(dr("WL_Percent"), 0)
        FG1.Item(i, "IsZJ") = IsNull(dr("IsZJ"), False)
        '当前单价按单位转换率算
        FG1.Item(i, "Cost") = IsNull(dr("WL_Cost"), 0)
        FG1.Item(i, "Price") = IsNull(dr("WL_Cost"), 0) * ComFun.Unit_Convert(IsNull(dr("WL_Unit_LL"), ""), IsNull(dr("WL_Unit"), ""))
        SetPrice_LL(i)

    End Sub

    Private Sub DrToFGRow_GY(ByVal dr As DataRow, ByVal i As Integer)
        FG1.Item(i, "DyingStep") = IsNull(dr("DyingStep"), "")
        FG1.Item(i, "WL_ID") = IsNull(dr("WL_ID"), "")
        FG1.Item(i, "WL_No") = IsNull(dr("WL_No"), "")
        FG1.Item(i, "WL_Name") = IsNull(dr("WL_Name"), "")
        FG1.Item(i, "WL_Unit_LL") = IsNull(dr("WL_Unit_LL"), "")
        FG1.Item(i, "WL_Unit_LL2") = IsNull(dr("WL_Unit"), "")
        FG1.Item(i, "WL_Spec") = IsNull(dr("WL_Spec"), "")
        FG1.Item(i, "WlPercent") = IsNull(dr("WL_Percent"), 0)
        FG1.Item(i, "sPercent") = IsNull(dr("Qty"), 0)
        FG1.Item(i, "ByPercent") = True
        FG1.Item(i, "Step") = 9999
        FG1.Item(i, "IsZJ") = IsNull(dr("IsZJ"), False)
        '当前单价按单位转换率算
        FG1.Item(i, "Cost") = IsNull(dr("WL_Cost"), 0)
        FG1.Item(i, "Price") = IsNull(dr("WL_Cost"), 0) * ComFun.Unit_Convert(IsNull(dr("WL_Unit_LL"), ""), IsNull(dr("WL_Unit"), ""))
        SetPrice_LL(i)
        CB_Unit_LL.SelectedValue = IsNull(dr("WL_Store_ID"), 0)
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
        If Mode <> Mode_Enum.Add Then
            ShowErrMsg("非新增状态不能修改单号!")
        Else
            ShowConfirm("是否获取新单号?", AddressOf ReGetNewID)
        End If
    End Sub

    Sub ReGetNewID()
        If TB_ID.Text <> LId OrElse LId = "" Then
            ComFun.DelBillNewID(BillType.PurchaseReturn, Bill_ID)
            Bill_Id_Date = #1/1/1999#
            GetNewID()
        End If
    End Sub

    Sub GetNewID()
        Dao.LingLiao_DB_NAME = Ch_Name
        If Mode = Mode_Enum.Add Then
            If DTP_sDate.Value <> Bill_Id_Date Then
                Dim R As RetrunNewIdMsg = ComFun.GetBillNewID(BillType.LingLiao, DTP_sDate.Value, Bill_ID)
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


    Private Sub Cmd_Preview2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Preview2.Click
        Print(OperatorType.Preview, False)
    End Sub

    Private Sub Cmd_Print2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Print2.Click
        Print(OperatorType.Print, False)
    End Sub

    Protected Sub Print(ByVal DoOperator As OperatorType, Optional ByVal isFirst As Boolean = True)
        If Me.Mode = Mode_Enum.Add Then
            Exit Sub
        End If
        If CheckRight(ID, ClassMain.PrintMore) Then
            Dim R As New R20310_LingLiao
            AddHandler R.PrintEnd, AddressOf Report_PrintEnd
            R.Start(TB_ID.Text, DoOperator, isFirst)
        Else
            Dim dtPrint As DtReturnMsg = Dao.GetPrintState(TB_ID.Text)
            If dtPrint.IsOk AndAlso dtPrint.Dt.Rows.Count > 0 AndAlso IsNull(dtPrint.Dt.Rows(0)(IIf(isFirst, "PrintOne", "PrintTwo")), False) = True Then
                ShowErrMsg("单号［" & TB_ID.Text & "］已打印")
                Exit Sub
            Else
                Dim R As New R20310_LingLiao
                AddHandler R.PrintEnd, AddressOf Report_PrintEnd
                R.Start(TB_ID.Text, DoOperator, isFirst)
            End If
        End If
    End Sub
    Private Sub Report_PrintEnd()
        Dim dtPrint As DtReturnMsg = Dao.GetPrintState(TB_ID.Text)
        If dtPrint.IsOk AndAlso dtPrint.Dt.Rows.Count > 0 Then
            SetPrintMsg(dtPrint.Dt.Rows(0))
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
        FG1.FinishEditing(False)
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
        SaveLingLiao(True)
    End Sub

    Private Sub Cmd_UnAudit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_UnAudit.Click
        ShowConfirm("是否反审" & Ch_Name & " [" & TB_ID.Text & "]?", AddressOf UnAudit)
    End Sub

    Protected Sub UnAudit()
        Dao.LingLiao_DB_NAME = Ch_Name
        Dim msg As MsgReturn = Dao.LingLiao_Audited(TB_ID.Text, False)
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
        If JL_Qty > 0 Then
            ShowErrMsg("本单有加料单不能删除")
            Exit Sub
        End If

        Dim Show As String = ""
        If LB_Page.Text = "显示第二页" Then
            If Dao.LingLiao_Get_State(LB_Page.Tag, Enum_State.Audited) = True Then
                ShowErrMsg("本缸号第二页单已审核不能删除!")
                Exit Sub
            End If
            Show = "(注：删除第一页时同时会删除第二页)"
        End If
        ShowConfirm("是否删除" & Ch_Name & " [" & TB_ID.Text & "]?" & vbCrLf & Show, AddressOf DelLingLiao)
    End Sub

    ''' <summary>
    ''' 删除出库单
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub DelLingLiao()

        Dao.LingLiao_DB_NAME = Ch_Name
        Dim msg As MsgReturn = Dao.LingLiao_Del(TB_ID.Text)
        If LB_Page.Text = "显示第二页" AndAlso LB_Page.Tag IsNot Nothing Then
            msg = Dao.LingLiao_Del(LB_Page.Tag)
            If msg.IsOk Then
                Dim li As New List(Of String)
                li.Add(TB_ID.Text)
                li.Add(LB_Page.Tag)
                LastForm.ReturnObj = li
            End If
        End If
        If msg.IsOk Then
            LastForm.ReturnId = TB_ID.Text
            Me.Close()
        Else
            ShowErrMsg(msg.Msg)
        End If
    End Sub


    Private Sub Cmd_SetInValid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_SetInValid.Click
        If JL_Qty > 0 Then
            ShowErrMsg("本单有加料单不能作废!")
            Exit Sub
        End If
        Dim Show As String = ""
        If LB_Page.Text = "显示第二页" Then
            If Dao.LingLiao_Get_State(LB_Page.Tag, Enum_State.Audited) = True Then
                ShowErrMsg("本缸号第二页单已审核不能作废!")
                Exit Sub
            End If
            Show = "(注：作废第一页时同时会作废第二页)"
        End If
        ShowConfirm("是否作废" & Ch_Name & " [" & TB_ID.Text & "]? " & vbCrLf & Show, AddressOf LingLiaoInValid)
    End Sub


    Sub LingLiaoInValid()
        Dao.LingLiao_DB_NAME = Ch_Name
        Dim msg As MsgReturn = Dao.LingLiao_InValid(TB_ID.Text, True)
        If LB_Page.Text = "显示第二页" AndAlso LB_Page.Tag IsNot Nothing Then
            msg = Dao.LingLiao_InValid(LB_Page.Tag, True)
            If msg.IsOk Then
                Dim li As New List(Of String)
                li.Add(TB_ID.Text)
                li.Add(LB_Page.Tag)
                LastForm.ReturnObj = li
            End If
        End If
        If msg.IsOk Then

            Me_Refresh()
            LastForm.ReturnId = TB_ID.Text
        Else
            ShowErrMsg(msg.Msg)
        End If
        Me.Close()
    End Sub

    ''' <summary>
    ''' 反作废
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_SetValid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_SetValid.Click

        Dim R As DtReturnMsg = Dao.LingLiao_OldID_Count(TB_ID.Text)

        If R.IsOk AndAlso R.Dt.Rows.Count > 0 Then
            ShowErrMsg("单号[" & TB_ID.Text & "]有重建单[" & R.Dt.Rows(0)("ID") & "]不能反作废")
            Exit Sub
        End If

        ShowConfirm("是否反作废" & Ch_Name & " [" & TB_ID.Text & "]?", AddressOf LingLiaoValid)
    End Sub

    ''' <summary>
    ''' 作废
    ''' </summary>
    ''' <remarks></remarks>
    Sub LingLiaoValid()
        Dao.LingLiao_DB_NAME = Ch_Name
        Dim msg As MsgReturn = Dao.LingLiao_InValid(TB_ID.Text, False)
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
            Return Dao.LingLiao_CheckIsModify(LId, LastLine)
        End If
    End Function

#End Region

#Region "比例计算"
    Private Sub TB_BZ_ZL_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TB_BZ_ZL.KeyPress

        If e.KeyChar = vbCr Then
            TB_BZ_Qty.Focus()
        End If
    End Sub
    Private Sub TB_BZ_ZL_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TB_BZ_ZL.LostFocus
        CacQty_ALL()
        CaculateSumAmount()
    End Sub
    Private Sub CB_Ratio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CB_Ratio.SelectedIndexChanged
        CacWaterLevel()
    End Sub

    Private Sub CacQty_ALL(Optional ByVal MustQty As Boolean = False)
        If MustQty OrElse TB_BZ_ZL.Tag Is Nothing OrElse Val(TB_BZ_ZL.Tag) <> Val(TB_BZ_ZL.Text) Then
            Dim byPercent As Boolean = False
            For i As Integer = 1 To FG1.Rows.Count - 1
                byPercent = IIf(FG1.Item(i, "ByPercent") Is Nothing, False, FG1.Item(i, "ByPercent"))
                If byPercent Then
                    CacQty(i)
                Else
                    CacPercent(i)
                End If

            Next
            TB_BZ_ZL.Tag = TB_BZ_ZL.Text
            CacWaterLevel()
        End If
    End Sub

    Private Sub CacWaterLevel()
        Tb_WaterLevel.Text = Format(Val(TB_BZ_ZL.Text) * Val(CB_Ratio.Text), FormatSharp("waterlevel"))
    End Sub


    Private Sub CacQty(ByVal rowIndex As Integer)
        Dim I_isKg As Integer = 1
        If FG1.Item(rowIndex, "WL_Unit_LL") = "g" Then
            '   FG1.Item(rowIndex, "Qty") = Val(TB_BZ_ZL.Text) * 10 * Val(FG1.Item(rowIndex, "sPercent"))
        ElseIf FG1.Item(rowIndex, "WL_Unit_LL") = "Kg" Then
            I_isKg = 1000
            '    FG1.Item(rowIndex, "Qty") = Val(TB_BZ_ZL.Text) * 10 * Val(FG1.Item(rowIndex, "sPercent")) / 1000
        End If
        Dim p As Double
        If Val(FG1.Item(rowIndex, "WlPercent")) = 1 OrElse Val(FG1.Item(rowIndex, "WlPercent")) = 0 Then
            '助剂数量=配布重*比例*10
            p = 1
        Else
            '助剂数量=配布重*比例*浴比
            p = Val(FG1.Item(rowIndex, "WlPercent"))
        End If

        If FG1.Item(rowIndex, "ISZJ") = False Then
            '助剂数量=配布重*比例*10
            FG1.Item(rowIndex, "Qty") = Val(TB_BZ_ZL.Text) * 10 * Val(FG1.Item(rowIndex, "sPercent")) / I_isKg
        Else
            '助剂数量=配布重*比例*浴比
            FG1.Item(rowIndex, "Qty") = Val(TB_BZ_ZL.Text) * Val(FG1.Item(rowIndex, "sPercent")) * Val(CB_Ratio.Text) / I_isKg
        End If



    End Sub


    Private Sub CacPercent(ByVal rowIndex As Integer)
        If Val(TB_BZ_ZL.Text) > 0 Then


            If FG1.Item(rowIndex, "WL_Unit_LL") = "g" Then
                ' FG1.Item(FG1.RowSel, "Qty") = Val(TB_BZ_ZL.Text) * 10 * Val(FG1.Item(FG1.RowSel, "sPercent"))
                FG1.Item(rowIndex, "sPercent") = Format(Val(FG1.Item(rowIndex, "Qty")) / (Val(TB_BZ_ZL.Text) * 10), FG1.Cols("sPercent").Format)
            ElseIf FG1.Item(rowIndex, "WL_Unit_LL") = "Kg" Then
                'FG1.Item(FG1.RowSel, "Qty") = Val(TB_BZ_ZL.Text) * 10 * Val(FG1.Item(FG1.RowSel, "sPercent")) / 1000

                FG1.Item(rowIndex, "sPercent") = Format((Val(FG1.Item(rowIndex, "Qty")) / (Val(TB_BZ_ZL.Text) * 10)) * 1000, FG1.Cols("sPercent").Format)
            End If
        End If
    End Sub


#End Region


    Private Sub Cmd_Copy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CopyMe()
    End Sub
#Region "选择色号,布种"
    Private Sub CB_BZC_Col_Sel(ByVal Col_No As String, ByVal Col_Name As String, ByVal ID As String) Handles CB_BZC.Col_Sel
        TB_BZC_Name.Text = Col_Name
        Dim msg As DtReturnMsg = ComFun.Clinet_GetBy_BZCID(ID)
        If msg.IsOk Then
            TB_ClientName.Tag = msg.Dt.Rows(0)("ID")
            '   TB_ClientID.Text = msg.Dt.Rows(0)("Client_No")
            TB_ClientName.Text = msg.Dt.Rows(0)("Client_Name")
        End If
        If ID <> Val(CB_BZ.SearchID) Then
            CB_BZ.IDAsInt = 0
            CB_BZ.Text = ""
            TB_BZ_Name.Text = ""
            CB_BZ.SearchID = ID
            CB_BZ.SearchType = cSearchType.ENum_SearchType.BZC
            CB_BZ.Enabled = True
            GetRBPF()
        End If
    End Sub

    Private Sub CB_BZ_Col_Sel(ByVal Col_No As String, ByVal Col_Name As String, ByVal ID As String) Handles CB_BZ.Col_Sel
        TB_BZ_Name.Text = Col_Name
        GetRBPF()
    End Sub

#End Region


#Region "根据色号，布种获取染部配方"
    Private Sub GetRBPF()
        If CB_BZC.IDAsInt <> 0 AndAlso CB_BZ.IDAsInt <> 0 Then
            Dim msg As DtReturnMsg = Dao.LingLiao_GetList_ByBZC(CB_BZC.IDAsInt, CB_BZ.IDAsInt)
            If msg.IsOk Then
                SetGoodsFromRBPF(msg.Dt)
                If msg.Dt.Rows.Count = 0 Then
                    If IsClosing = False Then ShowErrMsg("没有找到与【" & TB_BZC_Name.Text & "】【" & TB_BZ_Name.Text & "】相符的染部配方！")
                Else
                    Dim R As DtReturnMsg = Dao.LingLiao_GetGYID_ByBZC(CB_BZC.IDAsInt, msg.Dt.Rows(0)("ID"))
                    If R.IsOk AndAlso R.Dt.Rows.Count > 0 Then
                        LabelGY1.Tag = IsNull(R.Dt.Rows(0)("GY_ID1"), 0)
                        LabelGY1.Text = IsNull(R.Dt.Rows(0)("GY_Name1"), "")
                        LabelGY2.Tag = IsNull(R.Dt.Rows(0)("GY_ID2"), 0)
                        LabelGY2.Text = IsNull(R.Dt.Rows(0)("GY_Name2"), "")
                    End If
                End If
            Else
                ShowErrMsg(msg.Msg)
            End If

        End If
    End Sub


    Protected Sub SetGoodsFromRBPF(ByVal dt As DataTable)
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            FG1.FinishEditing(True)
            FG1.Redraw = False
            Dim E As Boolean = FG1.CanEditing
            FG1.CanEditing = False
            FG1.Rows.Count = 1
            Dim i As Integer = 1
            TB_BZ_ZL.Tag = 0
            Try
                For Each dr As DataRow In dt.Rows
                    FG1.AddRow() '
                    FG1.Item(i, "DyingStep") = IsNull(dr("DyingStep"), "")
                    FG1.Item(i, "WL_ID") = IsNull(dr("WL_ID"), 0)
                    FG1.Item(i, "WL_No") = IsNull(dr("WL_No"), "")
                    FG1.Item(i, "WL_Name") = IsNull(dr("WL_Name"), "")
                    FG1.Item(i, "WL_Unit_LL") = IsNull(dr("WL_Unit_LL"), "")
                    FG1.Item(i, "WL_Unit_LL2") = IsNull(dr("WL_Unit"), "")
                    FG1.Item(i, "WL_Spec") = IsNull(dr("WL_Spec"), "")
                    FG1.Item(i, "sPercent") = IsNull(dr("sPercent"), 0)
                    FG1.Item(i, "ByPercent") = True
                    FG1.Item(i, "WLPercent") = IsNull(dr("WL_Percent"), 0)
                    FG1.Item(i, "IsPageTwo") = IsNull(dr("IsPageTwo"), 0)
                    FG1.Item(i, "Step") = IsNull(dr("Step"), 0)
                    FG1.Item(i, "IsZJ") = IsNull(dr("IsZJ"), False)
                    '当前单价按单位转换率算
                    FG1.Item(i, "Cost") = IsNull(dr("Cost"), 0)
                    FG1.Item(i, "Price") = IsNull(dr("Cost"), 0) * ComFun.Unit_Convert(IsNull(dr("WL_Unit_LL"), ""), IsNull(dr("WL_Unit"), ""))
                    SetPrice_LL(i)
                    i = i + 1
                Next
            Catch ex As Exception

            End Try

            CaculateSumAmount()
            CacQty_ALL(True)
            FG1.ReAddIndex()
            ReSetPageTwo()
            SetStep()
            FG1.Redraw = True
            FG1.CanEditing = E
        End If

    End Sub
#End Region


#Region "获取缸号资料"


    Dim Old_ID As String = ""
    Sub GoLingLiao(Optional ByVal JiaLiao As Boolean = False)
        If Old_ID <> "" Then
            If Mode = Mode_Enum.Add Then ComFun.DelBillNewID(BillType.LingLiao, Bill_ID)
            Mode = Mode_Enum.Modify
            Bill_ID = Old_ID
            If JiaLiao = False Then LabelTitle.Text = LabelTitle.Text.Replace("新建", "修改")
            Me_Refresh()
            If JiaLiao Then
                CopyMe(JiaLiao)
                LoadFromGH(TB_Produce_ID.Text)
            End If
        End If
    End Sub
    Sub GoJiaLiao()
        GoLingLiao(True)
    End Sub
    Sub DoNothing()

    End Sub
    Dim OKGH As String = ""
    Dim CanLingliao As Boolean = False
    Private Sub TB_Produce_ID_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TB_Produce_ID.KeyPress
        If TB_Produce_ID.ReadOnly = False AndAlso e.KeyChar = vbCr Then
            Dim s As String = TB_Produce_ID.Text
            s = s.Replace("-", "")
            Dim Mr As MsgReturn = ComFun.GetGHForTM(s)
            If Mr.IsOk = False Then
                ShowErrMsg(Mr.Msg)
                Exit Sub
            End If
            s = Mr.Msg


            Dim Rt As MsgReturn = Dao.LingLiao_Count(s)
            If Rt.IsOk AndAlso Rt.Msg <> Bill_ID Then
                Old_ID = Rt.Msg
                If CheckRight(ID, ClassMain.JiaLiao) Then
                    ShowConfirm("缸号[" & s & "]已经开了领料单,不能再开领料单,只能开加料单。" & vbCrLf & "现在是否开加料单,还是转到领料单[" & Rt.Msg & "]?", "转到领料单", "开加料单", "取消", AddressOf GoLingLiao, AddressOf GoJiaLiao, AddressOf DoNothing)
                Else
                    ShowConfirm("缸号[" & s & "]已经开了领料单,不能再开领料单,只能开加料单。" & vbCrLf & "现在是否开加料单,还是退出?", "转到领料单", "退出", "取消", AddressOf GoLingLiao, AddressOf Me.Close, AddressOf DoNothing)
                End If
                Exit Sub
            End If
            LoadFromGH(s)

       
        End If



    End Sub

    Sub LoadFromGH(ByVal s As String)
        Dim R As DtReturnMsg = Dao.LingLiao_GetGH(s)
        If R.IsOk AndAlso R.Dt.Rows.Count > 0 Then
            If IsNull(R.Dt.Rows(0)("IsFD"), False) = True Then
                ShowErrMsg("缸号[" & s & "]是返定布不需要领料!")
                TB_Produce_ID.Text = ""
            Else
                Try
                    CB_BZC.IDAsInt = R.Dt.Rows(0)("BZC_ID")
                    CB_BZC.Text = CB_BZC.GetByTextBoxTag()
                    TB_BZC_Name.Text = CB_BZC.NameValue

                    TB_Produce_ID.Text = R.Dt.Rows(0)("GH")

                    TB_ClientName.Tag = R.Dt.Rows(0)("Client_ID")
                    TB_ClientName.Text = R.Dt.Rows(0)("Client_Name")



                    CB_BZ.IDAsInt = R.Dt.Rows(0)("BZ_ID")
                    CB_BZ.Text = CB_BZ.GetByTextBoxTag()
                    TB_BZ_Name.Text = CB_BZ.NameValue

                    CB_BZ.SearchID = R.Dt.Rows(0)("BZC_ID")
                    CB_BZ.SearchType = cSearchType.ENum_SearchType.BZC
                    '  CB_BZ.Enabled = True

                    TB_BZ_ZL.Text = IsNull(R.Dt.Rows(0)("PB_ZLSum"), 0)
                    TB_BZ_Qty.Text = IsNull(R.Dt.Rows(0)("PB_CountSum"), 0)
                    If IsJiaLiao = False Then
                        GetRBPF()
                    End If
                    CaculateSumAmount()
                    If R.Dt.Rows(0)("State") >= Enum_ProduceState.PeiBu Then
                        TB_BZ_ZL.Focus()
                        CanLingliao = True
                    Else
                        ShowErrMsg("缸号[" & s & "]未配布,不能开领料单!", AddressOf TB_Produce_ID.Focus)
                        CanLingliao = False
                    End If
                    OKGH = TB_Produce_ID.Text
                Catch ex As Exception
                    ShowErrMsg(ex.ToString)
                End Try
            End If


        End If
    End Sub

    ''' <summary>
    ''' 浴比显示方式
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Ratio2Show(ByVal show As Boolean)
        If show Then
            CB_Ratio.Width = 62
        Else
            CB_Ratio.Width = 185
        End If
        CB_Ratio2.Visible = show
        Label21.Visible = show
    End Sub

#Region "根据缸号查询染料单页数"

    Private Sub GetPage(ByVal GH As String)
        Dim R As DtReturnMsg = Dao.LingLiao_Page_Count(GH)
        If R.IsOk Then
            LB_Page.Visible = False
            If R.Dt.Rows.Count = 1 Then
                LB_Page.Text = ""
          
            ElseIf R.Dt.Rows.Count = 2 Then
                For Each dr As DataRow In R.Dt.Rows
                    If dr("id") = LId AndAlso IsNull(dr("IsPageTwo"), False) = False Then
                        LB_Page.Text = "显示第二页"
                        LB_Page.Tag = R.Dt.Rows(1)("ID")
                        LB_Page.Visible = True

                    ElseIf dr("id") = LId AndAlso IsNull(dr("IsPageTwo"), False) = True Then
                        LB_Page.Text = "显示第一页"
                        LB_Page.Tag = R.Dt.Rows(0)("ID")
                        LB_Page.Visible = True
                   
                    End If
                Next
            End If

        End If
    End Sub

    Protected Sub ShowModify()
        If LB_Page.Tag = "" Then

            Exit Sub
        End If
        Dim F As New F20311_LingLiao_Msg(LB_Page.Tag)
        With F
            .Mode = Mode_Enum.Modify
            .P_F_RS_ID = ""
            .P_F_RS_ID2 = ""
            .ID = Me.ID
        End With
        F_RS_ID = ""
        Me.ReturnId = ""
        Me.ReturnObj = Nothing
        Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F, Me)
        VF.Show()
    End Sub


#End Region

#End Region

#Region "添加工艺"
    Private Sub Cmd_AddGy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_AddGy.Click
        Dim VF As ViewForm = SelectGY()
        If VF IsNot Nothing Then
            AddHandler VF.ClosedX, AddressOf AddGy
            VF.Show()
        End If
    End Sub


    Private Sub Cmd_InsertGY_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_InsertGY.Click
        Dim VF As ViewForm = SelectGY()
        If VF IsNot Nothing Then
            AddHandler VF.ClosedX, AddressOf SetGy
            VF.Show()
        End If
    End Sub
    Private Function SelectGY() As ViewForm
        Dim F As BaseForm = LoadFormIDToChild(10030, Me)
        If F Is Nothing Then Return Nothing
        With F
            .P_F_RS_ID = ""
            .P_F_RS_ID2 = ""
            .P_F_RS_ID4 = ""
            .IsSel = True
        End With
        ReturnId = ""
        Me.ReturnObj = Nothing
        Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F, Me)
        Return VF
    End Function

    ''' <summary>
    ''' 添加到当前节点
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub AddGy()
        SetFGGY(FG1.Rows.Count)
    End Sub

    ''' <summary>
    ''' 添加到当前节点
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub SetGy()
        SetFGGY(GetInsertRowIndex)
    End Sub

    Protected Sub SetFGGY(ByVal StartRow As Integer)
        Try
            If ReturnObj Is Nothing Then
                Exit Sub
            End If
            Dim dr As DataRow = ReturnObj

            Dim msg As DtReturnMsg = ComFun.GY_GetList_ByID(IsNull(dr("ID"), 0))
            If msg.Dt.Rows.Count = 0 Then
                ShowErrMsg("你所选的工艺[" & dr("Gy_Name") & "]没有对应的配方不能选择?")
                Exit Sub
            End If


            SetGoods_FromGY(msg.Dt, StartRow)

            CaculateSumAmount()
            Me.ReturnObj = Nothing
        Catch ex As Exception

        End Try
    End Sub


    ''' <summary>
    ''' 计算要插入的位置
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetInsertRowIndex() As Int16
        Dim startRow As Integer = 1
        If FG1.RowSel > 1 Then
            Dim tmp As Integer = 1
            If FG1.Item(FG1.RowSel, "Step") Is Nothing OrElse FG1.Item(FG1.RowSel, "Step").ToString.Length = 0 Then
                Return FG1.RowSel
            End If
            tmp = Val(FG1.Item(FG1.RowSel, "Step"))

            For i As Integer = FG1.RowSel To 1 Step -1
                If tmp <> Val(FG1.Item(i, "Step")) Then
                    startRow = i + 1
                    Exit For
                End If
            Next

        End If
        Return startRow
    End Function


#End Region

#Region "计算Step"

    Private Sub SetStep()
        Dim st As Integer = 1
        Dim st_Last As Integer = 1
        Dim tmp As Integer = 1
        For i As Integer = 1 To FG1.Rows.Count - 1
            tmp = Val(FG1.Item(i, "Step"))
            If i = 1 Then
                FG1.Item(i, "Step") = 1
            ElseIf st_Last = tmp Then
                FG1.Item(i, "Step") = st
            Else
                st = st + 1
                FG1.Item(i, "Step") = st
            End If
            st_Last = tmp
        Next
    End Sub

#End Region

#Region "加料"
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_JiaLiao_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_JiaLiao.Click

        If Mode = Mode_Enum.Add Then
            ShowErrMsg("新增状态不能加料.")
            Cmd_JiaLiao.Visible = False
            Exit Sub
        End If
        CopyMe(True)
        LoadFromGH(TB_Produce_ID.Text)
        'Dim F As New F20311_LingLiao_Msg(Bill_Id, True)
        'With F
        '    .Mode = Mode_Enum.Add
        '    .P_F_RS_ID = ""
        '    .P_F_RS_ID2 = ""
        '    .ID = Me.ID
        'End With
        'F_RS_ID = ""
        'Me.ReturnId = ""
        'Me.ReturnObj = Nothing
        'Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F, Me)
        'AddHandler VF.ClosedX, AddressOf Me_Refresh
        'VF.Show()
    End Sub

    Private Sub Cmd_ShowJiaLiao_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_ShowJiaLiao.Click
        If Mode = Mode_Enum.Add Then
            ShowErrMsg("新增状态不能加料.")
            Cmd_ShowJiaLiao.Visible = False
            Exit Sub
        End If
        Dim F As New F20312_JiaLiao_Sel(TB_Produce_ID.Text)
        With F
            .Mode = Mode_Enum.Add
            .P_F_RS_ID = ""
            .P_F_RS_ID2 = ""
            .ID = Me.ID
        End With
        F_RS_ID = ""
        Me.ReturnId = ""
        Me.ReturnObj = Nothing
        Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F, Me)
        '    AddHandler VF.ClosedX, AddressOf Me_Refresh
        VF.Show()
    End Sub
#End Region


    Private Sub LabelGY1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LabelGY1.DoubleClick
        ShowConfirm("是否删除第一个工艺图?", AddressOf DelGY1)
    End Sub

    Private Sub LabelGY2_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LabelGY2.DoubleClick
        ShowConfirm("是否删除第二个工艺图?", AddressOf DelGY2)
    End Sub



    Sub DelGY1()
        If LabelGY1.Tag IsNot Nothing AndAlso LabelGY1.Tag <> 0 Then
            LabelGY1.Tag = LabelGY2.Tag
            LabelGY1.Text = LabelGY2.Text
        Else
            LabelGY1.Tag = 0
            LabelGY1.Text = ""
        End If
        LabelGY2.Tag = 0
        LabelGY2.Text = ""
    End Sub
    Sub DelGY2()
        LabelGY2.Tag = 0
        LabelGY2.Text = ""
    End Sub


    Private Sub TB_RanSeShenPi_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TB_RanSeShenPi.KeyPress
        If e.KeyChar = vbCr Then
            TB_LiaoFangQueRen.Focus()
        End If
    End Sub

    Private Sub TB_LiaoFangQueRen_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TB_LiaoFangQueRen.KeyPress
        If e.KeyChar = vbCr Then
            TB_Remark.Focus()
        End If
    End Sub
#Region "双击单号"
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub LB_Note_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If IsJiaLiao Then
            Dim F As New F20311_LingLiao_Msg(MainBill)
            With F
                .Mode = Mode_Enum.Modify
                .P_F_RS_ID = ""
                .P_F_RS_ID2 = ""
                .ID = Me.ID
            End With
            F_RS_ID = ""
            Me.ReturnId = ""
            Me.ReturnObj = Nothing
            Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F, Me)

            VF.Show()
        End If
    End Sub
#End Region

    Private Sub Cmd_RefreshCost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_RefreshCost.Click
        For i As Integer = 1 To FG1.Rows.Count - 1
            If Val(FG1.Item(i, "WL_ID")) > 0 Then
                Try
                    Dim Dr As DataRow = BaseClass.ComFun.Get_WL_Cost(FG1.Item(i, "WL_ID"))
                    If Dr IsNot Nothing Then
                        FG1.Item(i, "Cost") = IsNull(Dr("WL_Cost"), 0)
                        FG1.Item(i, "WLPercent") = IsNull(Dr("WL_Percent"), 1)
                        FG1.Item(i, "Price") = Val(FG1.Item(i, "Cost")) * ComFun.Unit_Convert(FG1.Item(i, "WL_Unit_LL"), FG1.Item(i, "WL_Unit_LL2"))
                    End If
                    SetPrice_LL(i)
                Catch ex As Exception
                End Try
            End If
        Next
        CaculateSumAmount()
    End Sub

    Private Sub LB_Page_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LB_Page.DoubleClick
        'ShowModify()
        If LB_Page.Tag = "" Then
            Exit Sub
        End If
        Me.Mode = Mode_Enum.Modify
        Bill_ID = LB_Page.Tag
        Me_Refresh()

    End Sub

    Private Sub Cmd_Rebuild_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Rebuild.Click
        If Mode = Mode_Enum.Modify Then
            ShowConfirm("是否重建申购单[" & TB_ID.Text & "]?", AddressOf Rebuild)
        End If
    End Sub

    Dim newID As String = ""
    Private Sub Rebuild()
        newID = Flow_IsBillRenewed(TB_ID.Text)
        If newID <> "" Then
            ShowConfirm(Dao.LingLiao_DB_NAME & "[" & TB_ID.Text & "]" & "已重建为[" & newID & "],是否打开[" & newID & "]", AddressOf ShowNewBill)
            Exit Sub
        End If
        Mode = Mode_Enum.Add
        Me.dtTable.Rows(0)("State") = 0
        Me.dtTable.Rows(0)("OldID") = Me.TB_ID.Text
        SetForm(dtTable)
        GetNewID()
        Cmd_Rebuild_State()
        MainBill = dtTable.Rows(0)("MainBill")
    End Sub

    Private Sub Cmd_Rebuild_State()

        Cmd_Audit.Visible = Cmd_Audit.Tag
        Cmd_Audit.Enabled = True
        Cmd_UnAudit.Visible = False
        Cmd_UnAudit.Enabled = False
        Cmd_Rebuild.Visible = False
        Cmd_Rebuild.Enabled = False
        Cmd_SetValid.Visible = False
        Cmd_SetValid.Enabled = False
        Cmd_SetInValid.Visible = Cmd_SetInValid.Tag
        Cmd_SetInValid.Enabled = False
        Cmd_Del.Enabled = False
        Cmd_JiaLiao.Visible = False
        Cmd_ShowJiaLiao.Visible = False
        Cmd_RefreshCost.Visible = False
        Cmd_Preview.Enabled = False
        Cmd_Preview2.Visible = False
        Cmd_Print.Enabled = False
        Cmd_Print2.Visible = False
        LockForm(False)
        TB_Produce_ID.Enabled = False
        'CB_BZC.Enabled = False
        'CB_BZ.Enabled = False
        LabelTitle.Text = "新建" & Me.Ch_Name
        LabelState.Text = "新建"
        LabelState.ForeColor = Color.Black

    End Sub


    ''' <summary>
    ''' 查找原始单据ID，没有则返回""
    ''' </summary>
    ''' <param name="billID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Flow_IsBillRenewed(ByVal billID As String) As String
        Dim sql As String = "select top 1 ID from T20310_LingLiao_Table where OldID=@OldID"
        Dim msg As MsgReturn = SqlStrToOneStr(sql, "OldID", billID)
        If msg.IsOk Then

            Return msg.Msg
        Else
            Return ""
        End If
    End Function



    Private Sub ShowBill(ByVal _ID As String)
        Dim F As New F20311_LingLiao_Msg(_ID)
        With F
            .Mode = Mode_Enum.Modify
            .P_F_RS_ID = ""
            .P_F_RS_ID2 = ""
        End With
        F_RS_ID = ""
        Me.ReturnId = ""
        Me.ReturnObj = Nothing
        Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F, Me)
        '   AddHandler VF.ClosedX, AddressOf Edit_Retrun
        VF.Show()
    End Sub

    Private Sub ShowNewBill()
        ShowBill(newID)
    End Sub

    Private Sub Text_Old_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Text_Old.DoubleClick
        ShowBill(Text_Old.Text)
    End Sub

 
    Private Sub LB_Note_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LB_Note.DoubleClick
        If LB_Note.Tag IsNot Nothing Then
            ShowBill(LB_Note.Tag)
        End If
    End Sub

    Private Sub Cmd_GetGY_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_GetGY.Click
        GetRBPF()
    End Sub

    Private Sub TB_Produce_ID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_Produce_ID.TextChanged

    End Sub
End Class

Partial Friend Class Dao
#Region "常量"


    Protected Friend Shared LingLiao_DB_NAME As String = "出库单"
    ''' <summary>
    ''' 删除单据
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_LingLiao_DelByid As String = "Delete from T20310_LingLiao_Table  where ID=@ID and State=0 "
    ''' <summary>
    ''' 获取单头
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_LingLiao_GetByid As String = "select top 1 * from T20310_LingLiao_Table  where ID=@ID "

    ''' <summary>
    ''' 获取单头
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_LingLiao_GetByid_WithName As String = "select top 1 T. * ,C.Client_Name,(Select top 1 GY_No + '.' + GY_Name from  T10004_GY where T10004_GY.ID=T.GY_ID1) as GY_Name1,(Select top 1 GY_No + '.' + GY_Name from  T10004_GY where T10004_GY.ID=T.GY_ID2) as GY_Name2 from T20310_LingLiao_Table T Left join T10110_Client C on T.Client_ID=C.ID  where T.ID=@ID "
    ''' <summary>
    ''' 获取单头
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_LingLiao_SelByid As String = " select top 1 S.*,E.Employee_Name as OperatorName ,W.Dept_Name as Dept_Name,BZ.BZ_Name ,C.Client_Name ,C.Client_No" & _
                                                   " from T20310_LingLiao_Table S " & _
                                                    " left join T15001_Employee E on S.Operator=E.ID " & _
                                                    "left join T15000_Department W on S.Dept_No=W.Dept_No " & _
                                                    "left join T10110_Client C on S.Client_ID=C.ID " & _
                                                    "left join T10002_BZ BZ on BZ.id=S.BZ_ID " & _
                                                     "where S.ID=@ID "
    'select top 1 S.*,E.Employee_Name as OperatorName ,W.Dept_Name as Dept_Name from T20310_LingLiao_Table S  left join T15001_Employee E on S.Operator=E.ID left join T15000_Department W on S.Dept_No=W.Dept_No where S.ID=@ID"


    ''' <summary>
    ''' 获取单头 用于作废和审核
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_LingLiao_GetStateByid As String = "select top 1 ID,State,State_User,Produce_ID from T20310_LingLiao_Table  where ID=@ID"
    ''' <summary>
    ''' 获取单体
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_LingLiao_GetListByid As String = "select * from T20311_LingLiao_List  where ID=@ID "
    ''' <summary>
    ''' 获取单体,用于显示
    ''' </summary>
    ''' <remarks></remarks>0
    Private Const SQL_LingLiao_SelListByid As String = "select L.*, WL.WL_No,WL.WL_Name,WL.WL_Spec,WL.WL_Cost from (select * from T20311_LingLiao_List  where ID =@ID)L left join T10001_WL WL on WL.id=l.WL_ID order by L.ID ,L.Line "
    'Private Const SQL_LingLiao_SelListid As String = "select L.*, WL.WL_No,WL.WL_Name,WL.WL_Spec,WL.WL_Cost from (select * from T20311_LingLiao_List  where ID IN (@ID))L left join T10001_WL WL on WL.id=l.WL_ID order by L.ID ,L.Line "
    ''' <summary>
    ''' 检查ID的重复性
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_LingLiao_CheckID As String = "select count(*) from T20310_LingLiao_Table  where ID=@ID"

    '''' <summary>
    '''' 获取加工单列表,用于显示
    '''' </summary>
    '''' <remarks></remarks>0

    '  Private Const SQL_Produce_SelListByid As String = "select L.*,WL.WL_No,WL.WL_Name,WL.WL_Spec,WL.WL_Unit,WL.WL_Store_ID from (select * from T30011_Produce_List  where ID=@ID)L left join T10001_WL WL on WL.id=l.WL_id  where isnull(WL_Ignore,0)=0 order by WL.WL_Type_ID,WL.WL_Name"

    ''' <summary>
    ''' 检查ID的重复性
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_LingLiao_CheckIsModify As String = "select count(*) from T20311_LingLiao_List  where ID=@ID and Line=@Line"

    ''' <summary>
    ''' 根据色号获取染部配方
    ''' </summary>
    ''' <remarks></remarks>
    Public Const SQL_RBPF_PF_GeList_WithName = "select  P.ID,p.DyingStep,P.WL_ID,P.Qty as sPercent,W.WL_No,W.WL_Name,W.WL_Unit,W.WL_Unit_LL,W.WL_Spec,W.WL_Cost as Cost,W.WL_Cost as Price,W.IsZJ,IsPageTwo,GYSetID  as Step,W.WL_Percent   from T10013_RB_PFList P " & _
             "left join T10001_WL W on P.WL_ID=W.ID where IsGY=0 and  BZC_ID=@BZC_ID and P.ID =(select top 1 PF_ID from ( " & _
             " select PF_ID from T10003_BZC where  ID=@BZC_ID and BZ_ID=@BZ_ID and not  PF_ID is null " & _
             " union all " & _
             "select PF_ID from T10009_BzcLinkBz where BZC_ID=@BZC_ID and BZ_ID=@BZ_ID)T ) order by Line "
    ''' <summary>
    ''' 根据ID获取工艺图
    ''' </summary>
    ''' <remarks></remarks>
    Public Const SQL_GetGYID_ByBZC = "select top 1 GY_ID1,GY_ID2,(Select top 1 GY_No + '.' + GY_Name from  T10004_GY where T10004_GY.ID=T.GY_ID1) as GY_Name1,(Select top 1 GY_No + '.' + GY_Name from  T10004_GY where T10004_GY.ID=T.GY_ID2) as GY_Name2 from T10012_RB_PF T where T.BZC_ID=@BZC_ID and T.ID=@ID"

    ''' <summary>
    ''' 判断作废单是否有重建单
    ''' </summary>
    ''' <remarks></remarks>
    Public Const SQL_GetOldID_Count = " SELECT top 1 * FROM T20310_LingLiao_Table where oldid=@oldid"


    ''' <summary>
    ''' 判断第一页状态
    ''' </summary>
    ''' <remarks></remarks>
    Public Const SQL_Get_first_State = " SELECT top 1 State FROM T20310_LingLiao_Table where ID=@ID"

    ''' <summary>
    ''' 查找同一缸号的单据
    ''' </summary>
    ''' <remarks></remarks>
    Public Const SQL_Get_ID = " SELECT * FROM T20310_LingLiao_Table where Produce_ID=@Produce_ID and State=0"

    ''' <summary>
    ''' 查找单号是否已打印
    ''' </summary>
    ''' <remarks></remarks>
    Public Const SQL_GetPrint = " SELECT PrintOne,PrintTwo FROM T20310_LingLiao_Table where ID=@ID"


#End Region

#Region "单一张单内容查询"

    ''' <summary>
    ''' 获取对出库单信息
    ''' </summary>
    ''' <param name="sId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function LingLiao_GetById(ByVal sId As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_LingLiao_GetByid_WithName, "@ID", sId)
    End Function

    ''' <summary>
    ''' 获取对出库单列表信息
    ''' </summary>
    ''' <param name="sId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function LingLiao_SelListById(ByVal sId As String) As DtReturnMsg
        Dim P As New Dictionary(Of String, Object)
        P.Add("ID", sId)
        Return PClass.PClass.SqlStrToDt(SQL_LingLiao_SelListByid, "@ID", sId)
    End Function

    ''' <summary>
    ''' 获取单号打印状态
    ''' </summary>
    ''' <param name="sId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetPrintState(ByVal sId As String) As DtReturnMsg
        Dim P As New Dictionary(Of String, Object)
        P.Add("ID", sId)
        Return PClass.PClass.SqlStrToDt(SQL_GetPrint, "@ID", sId)
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
    Public Shared Function LingLiao_CheckIsModify(ByVal ID As String, ByVal Line As Integer) As Boolean
        Dim P As New Dictionary(Of String, Object)
        P.Add("ID", ID)
        P.Add("Line", Line)
        Dim R As MsgReturn = SqlStrToOneStr(SQL_LingLiao_CheckIsModify, P)
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
    Public Shared Function LingLiao_CheckID(ByVal ID As String) As Boolean
        Dim P As New Dictionary(Of String, Object)
        P.Add("ID", ID)
        Dim R As MsgReturn = SqlStrToOneStr(SQL_LingLiao_CheckID, P)
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
    ''' 添加领料单
    ''' </summary>
    ''' <param name="dtTable"></param>
    ''' <param name="dtList"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function LingLiao_Add(ByVal dtTable As DataTable, ByVal dtList As DataTable) As MsgReturn
        Dim R As New MsgReturn
        Dim sqlMap As New Dictionary(Of String, String)
        Dim paraMap As New Dictionary(Of String, Object)
        Dim LingLiaoId As String = dtTable.Rows(0)("ID")
        Dim Type As Integer = dtTable.Rows(0)("Type")

        sqlMap.Add("Table", SQL_LingLiao_GetByid)
        sqlMap.Add("List", SQL_LingLiao_GetListByid)
        paraMap.Add("ID", LingLiaoId)
        paraMap.Add("Type", Type)
        paraMap.Add("GH", dtTable.Rows(0)("Produce_ID"))
        Using H As New DtHelper(sqlMap, paraMap)
            If H.IsOk Then
                If H.DtList("Table").Rows.Count = 0 Then
                    DvToDt(dtTable, H.DtList("Table"), New List(Of String), True)
                    H.Update("Table", False)
                    ''当前单据为领料单是判断是否重复开单
                    If IsNull(dtTable.Rows(0)("IsJiaLiao"), False) = False AndAlso Val(H.SelectOneValue("select Count(*) from T20310_LingLiao_Table where Produce_ID=@GH and type=@type and IsJiaLiao=0 and IsPageTwo=0 and state>-1", paraMap).Msg) > 1 Then
                        R.Msg = "本缸号已存在领料单只能开加料单!"
                        R.IsOk = False
                        Return R
                    End If
                    DvToDt(dtList, H.DtList("List"), New List(Of String), True)
                    Dim TmSQL As String = "insert into Bill_Barcode (No_ID,NO_Type)values('" & LingLiaoId & "'," & BillType.LingLiao & ")"
                    H.UpdateAll(True, TmSQL)
                    R.Msg = "" & LingLiao_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]添加成功!"
                    R.IsOk = True
                Else
                    R.IsOk = False
                    R.Msg = "" & LingLiao_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]已经存在!请双击编号文本框,获取新编号!"
                End If
                Return R
            Else
                R.IsOk = False
                R.Msg = "" & LingLiao_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]添加错误!"
                DebugToLog(New Exception(H.Msg))
                Return R
            End If
        End Using
    End Function

    ''' <summary>
    ''' 修改出库单
    ''' </summary>
    ''' <param name="dtTable"></param>
    ''' <param name="dtList"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function LingLiao_Save(ByVal LID As String, ByVal dtTable As DataTable, ByVal dtList As DataTable) As MsgReturn
        Dim msg As New DtListReturnMsg
        Dim R As New MsgReturn
        Dim sqlMap As New Dictionary(Of String, String)
        Dim paraMap As New Dictionary(Of String, Object)
        Dim LingLiaoId As String = dtTable.Rows(0)("ID")

        If LID <> LingLiaoId AndAlso LingLiao_CheckID(LingLiaoId) Then
            R.IsOk = False
            R.Msg = "" & LingLiao_DB_NAME & "[" & LingLiaoId & "]已经存在!请双击编号文本框,获取新编号!"
            Return R
        End If
        dtTable.Rows(0)("ID") = LID
        paraMap.Add("ID", LID)

        'If IsNull(dtTable.Rows(0)("Produce_ID"), "") <> "" Then
        '    Dim Rx As MsgReturn = CallByID(30010, "Produce_CheckCanRef", dtTable.Rows(0)("Produce_ID"))
        '    If Rx.IsOk = False Then
        '        R.IsOk = False
        '        R.Msg = LingLiao_DB_NAME & "[" & LingLiaoId & "]添加失败!" & vbCrLf & Rx.Msg
        '        Return R
        '    End If
        'End If

        Try
            sqlMap.Add("Table", SQL_LingLiao_GetByid)
            sqlMap.Add("List", SQL_LingLiao_GetListByid)
            msg = SqlStrToDt(sqlMap, paraMap)
            If msg.DtList("Table").Rows.Count = 1 Then


                If msg.DtList("Table").Rows(0)("State") = Enum_State.Audited Then
                    msg.DaList("Table").Dispose()
                    msg.DaList("List").Dispose()
                    msg.Cnn.Dispose()
                    R.IsOk = False
                    R.Msg = "" & LingLiao_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]已经被审核不能再修改!"
                    Return R
                End If
                If msg.DtList("Table").Rows(0)("State") = Enum_State.Invoid Then
                    msg.DaList("Table").Dispose()
                    msg.DaList("List").Dispose()
                    msg.Cnn.Dispose()
                    R.IsOk = False
                    R.Msg = "" & LingLiao_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]已经被作废不能再修改!"
                    Return R
                End If
                DvToDt(dtList, msg.DtList("List"), New List(Of String))
                DvUpdateToDt(dtTable, msg.DtList("Table"), New List(Of String))
                Dim TmSQL As String = "Update Bill_Barcode set No_ID='" & LingLiaoId & "' where No_ID='" & LID & "' and NO_Type=" & BillType.LingLiao
                If LID <> LingLiaoId Then
                    DtToUpDate(msg, "Update T20310_LingLiao_Table set id='" & LingLiaoId & "' where id='" & LID & "'" & vbCrLf & TmSQL)
                    dtTable.Rows(0)("ID") = LingLiaoId
                    R.Msg = "" & LingLiao_DB_NAME & "[" & LID & "]已经修改为[" & LingLiaoId & "]!"
                Else
                    DtToUpDate(msg)
                    R.Msg = "" & LingLiao_DB_NAME & "[" & LID & "]修改成功!"
                End If
                R.IsOk = True
            Else
                R.IsOk = False
                R.Msg = "" & LingLiao_DB_NAME & "[" & LID & "]不存在"
            End If
            Return R
        Catch ex As Exception
            R.IsOk = False
            R.Msg = "" & LingLiao_DB_NAME & "[" & LID & "]修改错误"
            DebugToLog(ex)
            Return R
        Finally
        End Try
    End Function

    ''' <summary>
    ''' 删除出库单
    ''' </summary>
    ''' <param name="LingLiaoId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function LingLiao_Del(ByVal LingLiaoId As String)
        Dim P As New Dictionary(Of String, Object)
        P.Add("@ID", LingLiaoId)
        Return RunSQL(SQL_LingLiao_DelByid, P)
    End Function

    ''' <summary>
    ''' 作废出库单
    ''' </summary>
    ''' <param name="_ID"></param>
    ''' <param name="IsFei">作废还是反作废</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function LingLiao_InValid(ByVal _ID As String, ByVal IsFei As Boolean) As MsgReturn
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
            sqlMap.Add("Table", SQL_LingLiao_GetStateByid)
            msg = SqlStrToDt(sqlMap, paraMap)
            If msg.DtList("Table").Rows.Count = 1 Then
                If msg.DtList("Table").Rows(0)("State") <> Enum_State.Audited Then
                    '检查加工单状态
                    'If IsFei = False AndAlso IsNull(msg.DtList("Table").Rows(0)("Produce_ID"), "") <> "" Then
                    '    Dim Rx As MsgReturn = CallByID(30010, "Produce_CheckCanRef", msg.DtList("Table").Rows(0)("Produce_ID"))
                    '    If Rx.IsOk = False Then
                    '        R.IsOk = False
                    '        R.Msg = LingLiao_DB_NAME & "[" & _ID & "]" & OStr & "失败!" & vbCrLf & Rx.Msg.Replace("不能被引用", "")
                    '        Return R
                    '    End If
                    'End If
                    If msg.DtList("Table").Rows(0)("State") <> State Then
                        msg.DtList("Table").Rows(0)("State") = State
                        msg.DtList("Table").Rows(0)("State_User") = User_Display
                        DtToUpDate(msg)
                        R.IsOk = True
                        R.Msg = "" & LingLiao_DB_NAME & "[" & _ID & "]" & OStr & "成功!"
                    Else
                        R.IsOk = False
                        R.Msg = "" & LingLiao_DB_NAME & "[" & _ID & "]已经被" & OStr & "!不能再" & OStr & "!"
                    End If
                Else
                    R.IsOk = False
                    R.Msg = "" & LingLiao_DB_NAME & "[" & _ID & "]已经被审核,不能" & OStr & "!"
                End If
            Else
                R.IsOk = False
                R.Msg = "" & LingLiao_DB_NAME & "[" & _ID & "]不存在,不能" & OStr & "!"
            End If
            Return R
        Catch ex As Exception
            R.IsOk = False
            R.Msg = "" & LingLiao_DB_NAME & "[" & _ID & "]" & OStr & "错误!"
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
    Public Shared Function LingLiao_Audited(ByVal _ID As String, ByVal IsAudited As Boolean) As MsgReturn


        Dim paraMap As New Dictionary(Of String, Object)
        paraMap.Add("ID", _ID)
        paraMap.Add("IsAudited", IsAudited)
        paraMap.Add("State_User", User_Display)
        If IsAudited Then
            paraMap.Add("sDate", BaseClass.ComFun.Autitedtime.Date)
        Else
            paraMap.Add("sDate", DBNull.Value)
        End If

        Dim R As MsgReturn = SqlStrToOneStr("P20310_LingLiao_Audited", paraMap, True)
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

#Region "根据色号获取染部配方"
    ''' <summary>
    ''' 根据色号获取染部配方
    ''' </summary>
    ''' <param name="BZC_ID"></param>
    ''' <param name="BZ_ID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function LingLiao_GetList_ByBZC(ByVal BZC_ID As Integer, ByVal BZ_ID As Integer) As DtReturnMsg
        Dim P As New Dictionary(Of String, Object)
        P.Add("BZC_ID", BZC_ID)
        P.Add("BZ_ID", BZ_ID)
        Return SqlStrToDt(SQL_RBPF_PF_GeList_WithName, P)
    End Function


    ''' <summary>
    ''' 根据色号获取染部配方
    ''' </summary>
    ''' <param name="BZC_ID"></param>
    ''' <param name="ID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function LingLiao_GetGYID_ByBZC(ByVal BZC_ID As Integer, ByVal ID As Integer) As DtReturnMsg
        Dim P As New Dictionary(Of String, Object)
        P.Add("BZC_ID", BZC_ID)
        P.Add("ID", ID)
        Return SqlStrToDt(SQL_GetGYID_ByBZC, P)
    End Function
#End Region

#Region "获取缸号资料"

    ''' <summary>
    ''' 获取缸号资料
    ''' </summary>
    ''' <param name="Produce_ID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function LingLiao_GetGH(ByVal Produce_ID As String) As DtReturnMsg
        Dim P As New Dictionary(Of String, Object)
        P.Add("GH", Produce_ID)
        Return SqlStrToDt("select top 1 GH,State,BZC_ID,BZ_ID,Client_ID,PB_ZLSum,PB_CountSum,IsFD,(Select top 1 Client_Name from T10110_Client where ID=Client_ID) as Client_Name from T30000_Produce_Gd where GH=@GH", P)
    End Function
#End Region

    ''' <summary>
    ''' 查询加料单的张数
    ''' </summary>
    ''' <param name="_ID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function LingLiaoDX_CountJiaLiao(ByVal _ID As String) As Integer
        Dim R As MsgReturn = SqlStrToOneStr("select Count(*) from T20310_LingLiao_Table where Produce_ID=@ID and type=20320 and IsJiaLiao=1 and state>-1", "ID", _ID)
        Return Val(R.Msg)
    End Function



    ''' <summary>
    ''' 查询加料单的张数
    ''' </summary>
    ''' <param name="_ID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function LingLiao_CountJiaLiao(ByVal _ID As String) As Integer
        Dim R As MsgReturn = SqlStrToOneStr("select Count(*) from T20310_LingLiao_Table where Produce_ID=@ID and type=20310 and IsJiaLiao=1 and state>-1", "ID", _ID)
        Return Val(R.Msg)
    End Function

    ''' <summary>
    ''' 查询加料单的张数
    ''' </summary>
    ''' <param name="_ID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function LingLiao_Page_Count(ByVal _ID As String) As DtReturnMsg
        Dim R As DtReturnMsg = SqlStrToDt("select * from T20310_LingLiao_Table where Produce_ID=@ID and type=20310 and IsJiaLiao=0 and state>-1 and  not IsPageTwo is null order by IsPageTwo", "ID", _ID)
        Return R
    End Function


    ''' <summary>
    ''' 查询缸号是否已经开了定型领料单
    ''' </summary>
    ''' <param name="GH"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function LingLiaoDX_Count(ByVal GH As String) As MsgReturn
        Dim R As DtReturnMsg = SqlStrToDt("select top 1 ID from T20310_LingLiao_Table where Produce_ID=@ID and type=20320  and IsJiaLiao=0 and state>-1", "ID", GH)
        Dim Rt As New MsgReturn
        If R.IsOk AndAlso R.Dt.Rows.Count > 0 Then
            Rt.Msg = R.Dt.Rows(0)(0)
            Rt.IsOk = True
        Else
            Rt.IsOk = False
            Rt.Msg = R.Msg
        End If
        Return Rt
    End Function


    ''' <summary>
    ''' 查询缸号是否已经开领料单
    ''' </summary>
    ''' <param name="GH"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function LingLiao_Count(ByVal GH As String) As MsgReturn
        Dim R As DtReturnMsg = SqlStrToDt("select top 1 ID from T20310_LingLiao_Table where Produce_ID=@ID and type=20310  and IsJiaLiao=0 and state>-1", "ID", GH)
        Dim Rt As New MsgReturn
        If R.IsOk AndAlso R.Dt.Rows.Count > 0 Then
            Rt.Msg = R.Dt.Rows(0)(0)
            Rt.IsOk = True
        Else
            Rt.IsOk = False
            Rt.Msg = R.Msg
        End If
        Return Rt
    End Function


    ''' <summary>
    ''' 检查是否有重建单
    ''' </summary>
    ''' <param name="_ID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function LingLiao_OldID_Count(ByVal _ID As String) As DtReturnMsg
        Dim R As DtReturnMsg = SqlStrToDt(SQL_GetOldID_Count, "@oldid", _ID)
        Return R
    End Function



    ''' <summary>
    '''判断单据状态
    ''' </summary>
    ''' <param name="_ID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function LingLiao_Get_State(ByVal _ID As String, ByVal State As Enum_State) As Boolean
        Dim R As DtReturnMsg = SqlStrToDt(SQL_Get_first_State, "@ID", _ID)
        If R.IsOk AndAlso R.Dt.Rows.Count = 1 Then
            If R.Dt.Rows(0)("State") = State Then
                Return True
            Else
                Return False
            End If
        End If
    End Function

    ''' <summary>
    ''' 获取同一缸号单据
    ''' </summary>
    ''' <param name="_ID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function LingLiao_Get_ID(ByVal _ID As String) As DtReturnMsg
        Dim R As DtReturnMsg = SqlStrToDt(SQL_Get_ID, "@oldid", _ID)
        Return R
    End Function



End Class