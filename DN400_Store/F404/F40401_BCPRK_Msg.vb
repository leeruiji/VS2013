Option Compare Text
Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports PClass
Imports BaseClass
Imports PClass.CReport


Public Class F40401_BCPRK_Msg
    Dim dtList As DataTable
    Dim dtTable As DataTable
    Dim DtChePai As DataTable
    Dim State As Integer = 0
    Dim LastID As String = ""
    Dim FormState As Enum_BZSHState = Enum_BZSHState.AddNew


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

    'Private Sub F20001_PBRK_Msg_Form_KeyDown(ByVal sender As Object, ByRef e As System.Windows.Forms.KeyEventArgs) Handles Me.Form_KeyDown
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
        ID = 40400
        Control_CheckRight(ID, ClassMain.Modify, Cmd_Modify)

        Control_CheckRight(ID, ClassMain.CancelPB, Cmd_CancelPB)
        'Control_CheckRight(ID, ClassMain.Comfirm, Cmd_Comfirm)
        'Control_CheckRight(ID, ClassMain.UnComfirm, Cmd_UnComfirm)
        'Control_CheckRight(ID, ClassMain.Audited, Cmd_Audit)
        'Control_CheckRight(ID, ClassMain.UnAudit, Cmd_UnAudit)

    End Sub

    Private Sub F40401_BCPRK_Msg_AfterLoad() Handles Me.AfterLoad
        If Mode = Mode_Enum.Modify Then
            TB_CW.Focus()
        End If
    End Sub

    Private Sub Form_Msg_Load() Handles Me.Me_Load
        FormCheckRight()
        Ch_Name = GetBillTypeName(ID)
        'Dao.Balance_DB_NAME = Ch_Name
        Me.Title = Ch_Name

        DTR_Date_CPRK.Value = GetTime.AddHours(-8).Date
        TB_Client_No.Tag = "0"

        'CB_ChePai.DataSource = Emplyee.GetAllEmployee.Copy
        Select Case Mode
            Case Mode_Enum.Add
                If CheckRight(ID, ClassMain.Add) = False Then Me.ShowErrMsg("没有权限添加!", True) : Exit Sub
                TB_CPRK_User.Text = User_Display
                LabelTitle.Text = Me.Ch_Name
                Btn_Preview.Enabled = False
                Btn_Print.Enabled = False
                ListBox1.Items.Clear()
                CaculateSumAmount()
            Case Mode_Enum.Modify
                Get_GH(Bill_ID)
                LabelTitle.Text = Me.Ch_Name
                TB_CW.Focus()
        End Select
    End Sub


#Region "表单信息"
    ''' <summary>
    ''' FG合计
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub CaculateSumAmount()
        If LDT Is Nothing Then Exit Sub

        Dim Q As Integer = IsNull(LDT.Compute("Sum(Qty)", ""), 0)
        TB_RemainQty.Text = Val(TB_CR_LuoSeBzCount2.Text) - Q
        TB_CPRK_Qty.Text = Q


        'If Fg1.Rows.Count <= 1 Then
        '    TB_SumQty.Text = 0
        '    TB_PWeight.Text = 0
        '    TB_RemainQty.Text = 0
        '    TB_Qty.Text = 0

        'End If
        'Dim SumQty As Double = 0
        'Dim SumPWeight As Double = 0
        'Dim ReMainQty As Double = 0
        'Dim ReMainZl As Double = 0

        ''For R As Integer = 1 To Fg1.Rows.Count - 1
        ''    If Fg1.Item(R, "GH") = "" Then
        ''        If Val(Fg1.Item(R, "ZL")) > 0 Then
        ''            ReMainQty = ReMainQty + 1
        ''            ReMainZl = ReMainZl + Val(Fg1.Item(R, "ZL"))
        ''        End If
        ''    End If
        ''    If Val(Fg1.Item(R, "ZL")) > 0 Then
        ''        SumQty = SumQty + 1
        ''        SumPWeight = SumPWeight + Val(Fg1.Item(R, "ZL"))
        ''    End If
        ''Next
        'TB_SumQty.Text = FormatNum(SumQty)
        'TB_PWeight.Text = FormatZL(SumPWeight)
        'TB_RemainQty.Text = FormatNum(ReMainQty)
        'TB_Qty.Text = FormatZL(ReMainZl)

        'SumQty = 0
        'SumPWeight = 0
        'ReMainZl = 0
        'For R As Integer = 1 To Fg1.Rows.Count - 1
        '    If Val(Fg1.Item(R, "PB")) > 0 Then
        '        SumQty = SumQty + 1
        '        SumPWeight = SumPWeight + Val(Fg1.Item(R, "PB"))
        '    End If
        'Next
        'TB_Qty.Text = FormatNum(SumQty)
        '' TB_YPZL.Text = FormatZL(SumPWeight)
        'TB_XPQty.Text = FormatNum(Val(TB_CR_LuoSeBzCount.Text) - SumQty)
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
        If CheckForm() Then
            Dim D As Date = GetTime.AddHours(-8).Date
            If DTR_Date_CPRK.Value.Date <> D Then
                ShowConfirm("你选择的入库日期是[" & DTR_Date_CPRK.Value.Date.ToString("yyyy-MM-dd") & "]和单前日期[" & D.Date.ToString("yyyy-MM-dd") & "]不相同,是否继续保存" & Ch_Name & "?", "继续保存", "改为当天", "取消", AddressOf SaveConfirm, AddressOf SaveConfirmAsDate, AddressOf Me.NoSave)
            Else
                SaveConfirm()
            End If
        End If
    End Sub

    Sub NoSave()

    End Sub

    Sub SaveConfirmAsDate()
        DTR_Date_CPRK.Value = GetTime.AddHours(-8).Date
        SaveConfirm()
    End Sub

    Sub showSave()
        ShowConfirm("是否保存" & Ch_Name & "[" & TB_GH.Text & "] 的修改?", AddressOf SaveBCPRK)
    End Sub
    Sub showSaveConfirm()
        ShowConfirm("是否保存并仓库确认" & Ch_Name & "[" & TB_GH.Text & "] 的修改?", AddressOf SaveAndConfirm)
    End Sub
    Sub SaveConfirm()
        ShowConfirm("是否保存" & Ch_Name & "[" & TB_GH.Text & "] 的修改?", AddressOf SavePBRK)

    End Sub


    ''' <summary>
    ''' 保存修改
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub SavePBRK()
        Dim R As MsgReturn

        R = Dao.BCPRK_Save(TB_GH.Tag, DTR_Date_CPRK.Value, LDT, Val(TB_CPRK_Qty.Text), Val(TB_RemainQty.Text) = 0)

        If R.IsOk Then
            LastForm.ReturnId = TB_GH.Text
            ShowOk(R.Msg, True)
        Else
            If R.Msg.StartsWith("9") Then
                ShowErrMsg(R.Msg.Substring(1), True)
            Else
                ShowErrMsg(R.Msg.Substring(1))
            End If
        End If
    End Sub


    ''' <summary>
    ''' 验证信息
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Function CheckForm() As Boolean

        CaculateSumAmount()
        If TB_GH.Tag = "" Then
            ShowErrMsg(Ch_Name & "缸号不能为空!", AddressOf TB_GH.Focus)
            Return False
        End If
        If TB_RemainQty.Text <> "0" Then
            ShowErrMsg(Ch_Name & "余条数不能为0", AddressOf TB_CW.Focus)
            Return False
        End If
        'If TB_CW.Tag = "" Then
        '    ShowErrMsg(Ch_Name & "仓位不能为空！", AddressOf TB_CW.Focus)
        '    Return False
        'End If
        'If TB_Input.Tag = "" Then
        '    ShowErrMsg(Ch_Name & "数量不能为空！", AddressOf TB_Input.Focus)
        '    Return False
        'End If
        'If Fg1.Rows.Count <= 1 Then
        '    ShowErrMsg("入库列表不能为空!")
        '    Return False
        'End If
        'If TB_CR_LuoSeBzZL.Visible = True Then
        '    If (Val(TB_YPZL.Text) - 10) > Val(TB_CR_LuoSeBzZL.Text) Then
        '        ShowErrMsg("入库重量不能大于落色重量!")
        '        Return False
        '    End If
        'Else
        '    If Fg1.Rows.Count - 1 > Val(TB_CR_LuoSeBzCount.Text) Then
        '        ShowErrMsg("入库条数不能大于落色条数!")
        '        Return False
        '    End If
        'End If

        If Val(TB_RemainQty.Text) > 0 Then
            ShowErrMsg(Ch_Name & "还有" & Val(TB_RemainQty.Text) & "条布未入库!", AddressOf TB_GH.Focus)
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





    ''' <summary>
    ''' 减行
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Btn_RemoveRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_RemoveRow.Click
        RemoveRow()
    End Sub

    Sub RemoveRow()
        If ListBox1.SelectedIndex < 0 Then
            Exit Sub
        Else
            If LDT Is Nothing Then Exit Sub
            LDT.Rows(ListBox1.SelectedIndex).Delete()
            LDT.AcceptChanges()
            CaculateSumAmount()
            LockInput()
        End If
    End Sub

#End Region





#Region "报表事件"

    Private Sub Btn_Preview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Preview.Click
        Print(OperatorType.Preview)
    End Sub

    Private Sub Btn_Print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Print.Click
        Print(OperatorType.Print)
    End Sub

    Protected Sub Print(ByVal DoOperator As OperatorType)
        'If Me.Mode = Mode_Enum.Add Then
        '    Exit Sub
        'End If
        'Dim R As New R40001_PBRK
        'R.Start(TB_ID.Text, DoOperator)
    End Sub

#End Region




#Region "选缸号"


    Private Sub TB_GH_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TB_GH.KeyPress
        If e.KeyChar = vbCr Then
            Get_GH(TB_GH.Text)
        End If
    End Sub

    Dim IsShowErr As Boolean = False
    Sub Get_GH(ByVal ID As String)
        ID = ComFun.FixGH(ID)
        Dim Mr As MsgReturn = ComFun.GetGHForTM(ID)
        If Mr.IsOk = False Then
            ShowErrMsg(Mr.Msg)
            Exit Sub
        End If
        ID = Mr.Msg
        Dim R As DtReturnMsg = Dao.BCPRK_GetGH_ByID(ID)
        If R.IsOk = False Then
            ShowErrMsg("查询缸号失败!", AddressOf TB_GH.Focus)
            Exit Sub
        End If
        If R.Dt.Rows.Count = 0 Then
            ShowErrMsg("缸号[" & ID & "不存在]!", AddressOf TB_GH.Focus)
            Exit Sub
        End If
        Dim Dr As DataRow = R.Dt.Rows(0)
        Cmd_CancelPB.Visible = False


        'Select Case IsNull(Dr("State"), 0)
        '    Case Enum_ProduceState.ChengJian
        '        Cmd_Modify.Visible = Cmd_Modify.Tag

        '        GB_List.Enabled = True
        '        Btn_RemoveRow.Enabled = True
        '        TB_CW.Focus()
        If IsNull(Dr("isBCPRK"), False) = True Then
            Cmd_Modify.Visible = False
            GB_List.Enabled = False
            'Cmd_CancelPB.Visible = True
            Btn_RemoveRow.Visible = False
        End If

        If IsNull(Dr("State"), 0) < Enum_ProduceState.ChuGang Or IsNull(Dr("State"), 0) >= Enum_ProduceState.ChengJian Then
            ShowErrMsg("缸号[" & ID & "]未出缸或者已成检,不能再入库!", AddressOf TB_GH.Focus)
            Cmd_Modify.Visible = False
            GB_List.Enabled = False
            Btn_RemoveRow.Visible = False
        End If

        '    Case Else

        '        If IsShowErr = False Then
        '            ShowErrMsg("缸号[" & ID & "]不是已成检状态不能入库!", AddressOf TB_GH.Focus)
        '        End If
        '        Cmd_Modify.Visible = False
        '        GB_List.Enabled = False
        '        Btn_RemoveRow.Visible = False
        'End Select

        Bill_ID = ID
        '赋值
        TB_Client_No.Text = IsNull(Dr("Client_No"), "")
        TB_Client_No.Tag = IsNull(Dr("Client_Id"), 0)
        TB_Client_Name.Text = IsNull(Dr("Client_Name"), "")
        TB_Contract.Text = IsNull(Dr("Contract"), "")
        TB_CR_LuoSeBzCount.Text = IsNull(Dr("CR_LuoSeBzCount"), 0)
        TB_CR_LuoSeBzZL.Text = IsNull(Dr("CR_LuoSeBzZL"), 0)
        If IsNull(Dr("CR_LuoSeType"), 0) = 0 Then
            TB_CR_LuoSeBzZL.Visible = False
            Label_CR_LuoSeBzZL.Visible = False
        Else
            TB_CR_LuoSeBzZL.Visible = True
            Label_CR_LuoSeBzZL.Visible = True
        End If


        TB_GH.Text = IsNull(Dr("GH"), "")
        TB_CPRK_User.Text = IsNull(Dr("BCPRK_User"), "")
        TB_BZ_No.Text = IsNull(Dr("BZ_No"), "")
        TB_BZ_No.Tag = IsNull(Dr("BZ_Id"), 0)
        TB_BZ_Name.Text = IsNull(Dr("BZ_Name"), "")
        TB_TextileFatory.Text = IsNull(Dr("TextileFatory"), "")
        TB_ProcessType.Text = IsNull(Dr("ProcessType"), "")

        TB_CR_LuoSeBzCount2.Text = IsNull(Dr("CR_LuoSeBzCount"), 0)
        TB_CP_ZLSumm.Text = IsNull(Dr("CP_ZLSum"), 0)





        BZC_No.Text = IsNull(Dr("BZC_No"), "")
        BZC_Name.Text = IsNull(Dr("BZC_Name"), "")

        DTP_Date_LuoSe.Value = IsNull(Dr("Date_LuoSe"), "1999-1-1")
        DTP_Date_KaiDan.Value = IsNull(Dr("Date_BCPRK"), "1999-1-1")
        DTP_Date_JiaoHuo.Value = IsNull(Dr("Date_JiaoHuo"), "1999-1-1")
        LB_State.Text = ComFun.GetProduceStateName(IsNull(Dr("State"), 0))

        If IsNull(Dr("IsFD"), False) Then '返定
            LabelFDFG.Text = "返定"
            LabelFDFG.Visible = True
        Else
            If IsNull(Dr("IsFG"), False) Then
                LabelFDFG.Text = "返工"
                LabelFDFG.Visible = True
            Else
                LabelFDFG.Text = ""
                LabelFDFG.Visible = False
            End If
        End If


        Dim RDt As DtReturnMsg = Dao.BCPRK_GetListByGH(TB_GH.Text)
        If RDt.IsOk Then
            SetListBox(RDt.Dt)
        End If
        CaculateSumAmount()
        TB_GH.Tag = TB_GH.Text
        SetForm(R.Dt)

    End Sub

    Dim LDT As DataTable
    Sub SetListBox(ByVal Dt As DataTable)
        If Dt.Columns.Contains("msg") = False Then
            Dt.Columns.Add("Msg")
            For Each Row As DataRow In Dt.Rows
                Row("Msg") = Row("StoreNo") & ":" & Row("Qty") & "条"
            Next
        End If
        Dt.AcceptChanges()
        LDT = Dt
        ListBox1.DisplayMember = "Msg"
        ListBox1.ValueMember = "StoreNo"
        ListBox1.DataSource = Dt
    End Sub

#End Region


    Private Sub Label_ID_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label_ID.DoubleClick
        If TB_GH.Text = "" Then
            Exit Sub
        End If
        Dim F As BaseForm = LoadModifyFormByID(30000)
        With F
            .Mode = Mode_Enum.Modify
            .P_F_RS_ID = TB_GH.Text
            .P_F_RS_ID2 = ""
        End With
        F_RS_ID = ""
        Me.ReturnId = ""
        Me.ReturnObj = Nothing
        Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F, Me)
        VF.Show()
    End Sub









#Region "取消入库"

    Private Sub Cmd_CancelPB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_CancelPB.Click
        ShowConfirm("是否取消入库?", AddressOf CancelPB)
    End Sub

    Sub CancelPB()
        Dim R As MsgReturn = Dao.BCPRK_Cancel(Bill_ID)
        If R.IsOk Then
            ShowOk(R.Msg)
        Else
            IsShowErr = True
            ShowErrMsg(R.Msg)
        End If
        TB_GH.Text = Bill_ID
        LastForm.ReturnId = TB_GH.Text
        Get_GH(Bill_ID)
        IsShowErr = False
    End Sub

#End Region



    Private Sub Cmd_AddAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub



    Protected Function CheckStoreNo(ByVal _storeNO) As Boolean
        Dim msg As DtReturnMsg = ComFun.StoreMap_CheckStoreNo(_storeNO)
        If msg.IsOk AndAlso msg.Dt.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub TB_CW_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TB_CW.KeyPress
        If e.KeyChar = vbCr Then

            If TB_CW.Tag IsNot Nothing AndAlso TB_CW.Tag = TB_CW.Text Then

            Else
                If CheckStoreNo(TB_CW.Text) = False Then

                    ShowErrMsg("仓位;[" & TB_CW.Text & "]不存在!", AddressOf TB_CW.Focus)
                    Exit Sub
                Else
                    TB_CW.Tag = TB_CW.Text
                End If
            End If
            TB_Input.Focus()
            TB_Input.SelectAll()
        End If

    End Sub

    Private Sub TB_Input_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TB_Input.KeyPress
        If e.KeyChar = vbCr Then
            If TB_CW.Tag IsNot Nothing AndAlso TB_CW.Tag = TB_CW.Text Then
            Else
                If CheckStoreNo(TB_CW.Text) = False Then
                    ShowErrMsg("仓位;[" & TB_CW.Text & "]不存在!", AddressOf TB_CW.Focus)
                    Exit Sub
                Else
                    TB_CW.Tag = TB_CW.Text
                End If
            End If
            Dim n As Integer = CInt(Val(TB_Input.Text))
            If n = 0 Then
                ShowErrMsg("请输入正确的条数!", AddressOf TB_Input.Focus)
                TB_Input.Focus()
                Exit Sub
            End If
            n = Math.Abs(n)
            If Val(TB_RemainQty.Text) < n Then
                n = Val(TB_RemainQty.Text)
                If n = 0 Then
                    ShowErrMsg("请输入正确的条数!", AddressOf TB_Input.Focus)
                    Exit Sub
                End If
            End If
            TB_Input.Text = n
            Dim dr As DataRow

            Dim Rows() As DataRow = LDT.Select("StoreNo='" & TB_CW.Text & "'")
            If Rows.Length > 0 Then
                dr = Rows(0)
                dr("Qty") = dr("Qty") + n
                dr("Msg") = dr("StoreNo") & ":" & dr("Qty") & "条"
            Else
                dr = LDT.NewRow
                dr("GH") = TB_GH.Tag
                dr("StoreNo") = TB_CW.Text
                dr("Qty") = n
                dr("Msg") = dr("StoreNo") & ":" & dr("Qty") & "条"
                LDT.Rows.Add(dr)
            End If
            LDT.AcceptChanges()
            CaculateSumAmount()
            TB_CW.SelectAll()
            LockInput()
            TB_CW.Focus()
        End If
    End Sub


    Sub LockInput()
        Dim F As Boolean
        If Val(TB_RemainQty.Text) = 0 Then
            F = True
        Else
            F = False
        End If
        TB_Input.ReadOnly = F
        TB_CW.ReadOnly = F
    End Sub

    Private Sub ListBox1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox1.DoubleClick
        RemoveRow()
    End Sub
#Region "确认状态"
    ''' <summary>
    ''' 仓库确认
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_Comfirm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Comfirm.Click
        ' Fg1.FinishEditing()
        If CheckForm() Then
            Dim D As Date = GetTime.AddHours(-8).Date
            If DTR_Date_CPRK.Value.Date <> D Then
                ShowConfirm("你选择的入库日期是[" & DTR_Date_CPRK.Value.Date.ToString("yyyy-MM-dd") & "]和单前日期[" & D.Date.ToString("yyyy-MM-dd") & "]不相同,是否继续保存" & Ch_Name & "?", "继续保存", "改为当天", "取消", AddressOf showSaveConfirm, AddressOf SaveConfirmAsDate, AddressOf Me.NoSave)
            Else
                showSaveConfirm()
            End If
        End If
    End Sub
    Sub ShenheAsDate()
        DTR_Date_CPRK.Value = GetTime.AddHours(-8).Date
        ShenheConfirm()
    End Sub

    Sub ShenheConfirm()
        ShowConfirm("是否保存并确认新" & Ch_Name & "?", AddressOf QueRen)
    End Sub


    Protected Sub QueRen()
        SaveBCPRK()
    End Sub
#End Region



    ''' <summary>
    ''' 保存和确认
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub SaveAndConfirm(Optional ByVal Audit As Boolean = False)
        Dim R As MsgReturn

        R = Dao.BCPRK_Save(TB_GH.Tag, DTR_Date_CPRK.Value, LDT, Val(TB_CPRK_Qty.Text), Val(TB_RemainQty.Text) = 0)

        If R.IsOk Then
            LastForm.ReturnId = TB_GH.Text
            If Dao.BCPRK_UpdateFormState(Enum_BZSHState.Store_Comfirm, TB_GH.Text) Then
                ShowOk("确认成功", False)
                Get_GH(Bill_ID)
            Else
                ShowErrMsg("确认失败")
            End If

        Else
            If R.Msg.StartsWith("9") Then
                ShowErrMsg(R.Msg.Substring(1), True)
            Else
                ShowErrMsg(R.Msg.Substring(1))
            End If
        End If
        'If R.IsOk Then
        '    LastForm.ReturnId = TB_GH.Text
        '    If Audit Then
        '        Dim msg As MsgReturn = Dao.PBRK_Audit(TB_GH.Text, True)
        '        If msg.IsOk Then
        '            Bill_ID = TB_GH.Text
        '            Me.Mode = Mode_Enum.Modify
        '            Me.Refresh()
        '            ShowOk(msg.Msg)
        '        Else
        '            ShowErrMsg(msg.Msg)
        '        End If
        '        Exit Sub
        '    End If
        '    ShowOk(R.Msg, True)
        'Else
        '    ShowErrMsg(R.Msg)
        'End If
    End Sub


    ''' <summary>
    ''' 保存修改
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub SaveBCPRK(Optional ByVal Audit As Boolean = False)
        Dim R As MsgReturn

        R = Dao.BCPRK_Save(TB_GH.Tag, DTR_Date_CPRK.Value, LDT, Val(TB_CPRK_Qty.Text), Val(TB_RemainQty.Text) = 0)

        If R.IsOk Then
            LastForm.ReturnId = TB_GH.Text
            ShowOk(R.Msg, True)
        Else
            If R.Msg.StartsWith("9") Then
                ShowErrMsg(R.Msg.Substring(1), True)
            Else
                ShowErrMsg(R.Msg.Substring(1))
            End If
        End If
        If R.IsOk Then
            LastForm.ReturnId = TB_GH.Text
            If Audit Then
                Dim msg As MsgReturn = Dao.PBRK_Audit(TB_GH.Text, True)
                If msg.IsOk Then
                    Bill_ID = TB_GH.Text
                    Me.Mode = Mode_Enum.Modify
                    Me_Refresh()
                    ShowOk(msg.Msg)
                Else
                    ShowErrMsg(msg.Msg)
                End If
                Exit Sub
            End If
            ShowOk(R.Msg, True)
        Else
            ShowErrMsg(R.Msg)
        End If
    End Sub


    Sub LockForm(ByVal Lock As Boolean)

        DTR_Date_CPRK.Enabled = Not Lock
        Btn_RemoveRow.Enabled = Not Lock

    End Sub

    Sub SetAddState()
        LabelState.Text = "新建"
        LabelState.ForeColor = Color.Black
        Cmd_Modify.Enabled = Cmd_Modify.Tag

        Cmd_UnAudit.Visible = False
        Cmd_UnAudit.Enabled = False
        Cmd_Audit.Visible = False
        Cmd_Audit.Enabled = False
        Cmd_Comfirm.Visible = True
        Cmd_Comfirm.Enabled = True
        Cmd_UnComfirm.Visible = False
        Cmd_UnComfirm.Enabled = False
        LockForm(False)
    End Sub



    ''' <summary>
    ''' 设置表单内容
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub SetForm(ByVal dt As DataTable)
        If dt Is Nothing Then
            Exit Sub
        Else
            State = Enum_BZSHState.AddNew

        End If

        If dt.Rows.Count <= 0 Then
            State = Enum_BZSHState.AddNew
            FormState = Enum_BZSHState.AddNew
        Else

            'State = dt.Rows(0)("State")
            FormState = IsNull(dt.Rows(0)("BCPRK_State"), Enum_BZSHState.AddNew)
        End If

        Select Case FormState
            Case Enum_BZSHState.AddNew '新建
                SetAddState()

            Case Enum_BZSHState.Invoid '作废
                LabelState.Text = "已反审"
                LabelState.ForeColor = Color.Blue
                Cmd_Modify.Enabled = False
                Cmd_Comfirm.Visible = False
                Cmd_Comfirm.Enabled = False
                Cmd_UnComfirm.Visible = True
                Cmd_UnComfirm.Enabled = True
                Cmd_Audit.Visible = True
                Cmd_Audit.Enabled = True
                Cmd_UnAudit.Visible = False
                Cmd_UnAudit.Enabled = False
                LockForm(True)

            Case Enum_BZSHState.Store_Comfirm  '确

                If LB_State.Text = "已送货" Then
                    LabelState.Text = "已确认"
                    LabelState.ForeColor = Color.Blue
                    Cmd_Modify.Enabled = False
                    Cmd_UnAudit.Visible = False
                    Cmd_UnAudit.Enabled = False
                    Cmd_Audit.Visible = True
                    Cmd_Audit.Enabled = True
                    Cmd_Comfirm.Visible = False
                    Cmd_Comfirm.Enabled = False
                    Cmd_UnComfirm.Visible = False
                    Cmd_UnComfirm.Enabled = False
                    Cmd_CancelPB.Visible = False
                    Cmd_CancelPB.Enabled = False
                    TB_CW.Enabled = False
                    TB_Input.Enabled = False
                    ListBox1.Enabled = False
                Else
                    LabelState.Text = "已确认"
                    LabelState.ForeColor = Color.Blue
                    Cmd_Modify.Enabled = False
                    Cmd_UnAudit.Visible = False
                    Cmd_UnAudit.Enabled = False
                    Cmd_CancelPB.Visible = False
                    Cmd_CancelPB.Enabled = False
                    Cmd_Audit.Visible = True
                    Cmd_Audit.Enabled = True
                    Cmd_Comfirm.Visible = False
                    Cmd_Comfirm.Enabled = False
                    Cmd_UnComfirm.Visible = True
                    Cmd_UnComfirm.Enabled = True
                    TB_CW.Enabled = False
                    TB_Input.Enabled = False
                    ListBox1.Enabled = False
                End If
                LockForm(True)
                'Case Enum_ProduceState.SongHuo   '已送货
                '    LB_State.Text = "已送货"
                '    LabelState.ForeColor = Color.Blue
                '    Cmd_Modify.Enabled = False
                '    Cmd_UnAudit.Visible = False
                '    Cmd_UnAudit.Enabled = False
                '    Cmd_Audit.Visible = Cmd_Audit.Tag
                '    Cmd_Audit.Enabled = True
                '    Cmd_Comfirm.Visible = False
                '    Cmd_Comfirm.Enabled = False
                '    Cmd_UnComfirm.Visible = False
                '    Cmd_UnComfirm.Enabled = False
                '    TB_CW.Enabled = False
                '    TB_Input.Enabled = False
                '    LockForm(True)


            Case Enum_BZSHState.Audited '审核
                LabelState.Text = "已审核"
                LabelState.ForeColor = Color.Blue
                Cmd_Modify.Enabled = False
                Cmd_UnAudit.Visible = True
                Cmd_UnAudit.Enabled = True
                Cmd_CancelPB.Visible = False
                Cmd_CancelPB.Enabled = False
                Cmd_Audit.Visible = False
                Cmd_Audit.Enabled = False
                Cmd_Comfirm.Visible = False
                Cmd_Comfirm.Enabled = False
                Cmd_UnComfirm.Visible = False
                Cmd_UnComfirm.Enabled = False
                TB_CW.Enabled = False
                TB_Input.Enabled = False
                ListBox1.Enabled = False
                LockForm(True)
        End Select




        If dt.Rows.Count = 1 Then
            Dim Dr As DataRow = dt.Rows(0)

            TB_GH.Text = IsNull(Dr("GH"), "")
            TB_CPRK_User.Text = IsNull(Dr("BCPRK_User"), "")
            TB_BZ_No.Text = IsNull(Dr("BZ_No"), "")
            TB_BZ_No.Tag = IsNull(Dr("BZ_Id"), 0)
            TB_BZ_Name.Text = IsNull(Dr("BZ_Name"), "")
            TB_TextileFatory.Text = IsNull(Dr("TextileFatory"), "")
            TB_ProcessType.Text = IsNull(Dr("ProcessType"), "")

            TB_CR_LuoSeBzCount2.Text = IsNull(Dr("CR_LuoSeBzCount"), 0)
            TB_CP_ZLSumm.Text = IsNull(Dr("CP_ZLSum"), 0)
        End If
    End Sub
    Protected Sub Me_Refresh()
        Dim msgTable As DtReturnMsg = Dao.CPRK_GetGH_ByID(Bill_ID)
        If msgTable.IsOk Then
            dtTable = msgTable.Dt
            'If msgTable.Dt.Rows.Count = 0 OrElse IsNull(msgTable.Dt.Rows(0)("CPRK_State"), Enum_CPRK.New_CPRK) >= Enum_CPRK.ShenHe Then
            '    Cmd_Audit.Enabled = False
            'End If
            SetForm(msgTable.Dt)
        End If
        'If Mode = Mode_Enum.Add Then
        '    'Cmd_ZJ.Enabled = False
        '    Dim msg As DtReturnMsg = Dao.CPRK_GetGH_ByID(0)
        '    If msg.IsOk Then
        '        dtList = msg.Dt
        '    End If
        '    '  Fg1.Rows.Count = 1

        '    Dim StoreMsg As DtReturnMsg = Dao.PBRK_GetStoreNoById_AddNew(0)
        '    If StoreMsg.IsOk Then
        '        '  dtStore = StoreMsg.Dt
        '    End If

        'Else
        '    TB_GH.ReadOnly = True
        '    'Cmd_ZJ.Enabled = True
        '    If FormState = Enum_CPRK.New_CPRK Then
        '        ' Cmd_YTS.Visible = False
        '        Cmd_Audit.Visible = False

        '        Dim msg As DtReturnMsg = Dao.CPRK_GetListByGH(Bill_ID)
        '        If msg.IsOk Then
        '            dtList = msg.Dt
        '            'DtListToFg(msg.Dt)
        '        End If
        '    Else
        '        'Cmd_YTS.Visible = True


        '        Dim msg As DtReturnMsg = Dao.CPRK_GetGH_ByID(Bill_ID)
        '        If msg.IsOk Then
        '            msg.Dt.Columns.Add("State_Name")
        '            For Each Row As DataRow In msg.Dt.Rows
        '                If IsNull(Row("GHState"), -1) > 0 Then
        '                    Row("State_Name") = BaseClass.ComFun.GetProduceStateName(IsNull(Row("GHState"), Enum_ProduceState.AddNew))
        '                Else
        '                    Row("State_Name") = "未配布"
        '                End If
        '            Next
        '            dtList = msg.Dt
        '        End If
        '    End If
        '    Dim Storemsg As DtReturnMsg = Dao.CPRK_GetGH_ByID(Bill_ID)
        '    If Storemsg.IsOk Then
        '        ' dtStore = Storemsg.Dt
        '        ' Fg2.DtToFG(dtStore)
        '    End If

        '    ' Fg1.DtToSetFG(dtList)
        'End If
        CaculateSumAmount()
    End Sub
    ''' <summary>
    ''' 取消确认
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_UnComfirm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_UnComfirm.Click
        ShowConfirm("是否取消确认" & Ch_Name & " [" & TB_GH.Text & "]?", AddressOf UnComfirm)
    End Sub
    Protected Sub UnComfirm()
        If FormState = Enum_BZSHState.Store_Comfirm Then
            If Dao.BCPRK_UpdateFormState(Enum_BZSHState.AddNew, TB_GH.Text) Then
                Dao.BCPRK_CleanStore(TB_GH.Text, "")
                ShowOk("取消确认成功！")
            Else
                ShowErrMsg("取消确认失败！")
            End If
        End If
        Me_Refresh()
        LastForm.ReturnId = TB_GH.Text

    End Sub
    ''' <summary>
    ''' 财务审核
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_Audit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Audit.Click
        If FormState = Enum_BZSHState.Store_Comfirm Then

            If Dao.BCPRK_UpdateFormState(Enum_BZSHState.Audited, TB_GH.Text) Then
                ShowOk("财务审核成功!")
                Get_GH(Bill_ID)
            Else
                ShowErrMsg("财务审核失败!")
            End If

            LastForm.ReturnId = TB_GH.Text
        Else
            ShowErrMsg("请先进行仓库确认！")
        End If
    End Sub
    ''' <summary>
    ''' 反审
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_UnAudit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_UnAudit.Click
        'ShowConfirm("是否要反审?", AddressOf TB_ID.Focus)
        If FormState = Enum_BZSHState.Audited Then
            If Dao.BCPRK_UpdateFormState(Enum_BZSHState.Store_Comfirm, TB_GH.Text) Then
                ShowOk("反审成功！")
                Get_GH(Bill_ID)
            Else
                ShowErrMsg("反审失败！")
            End If
        End If

        LastForm.ReturnId = TB_GH.Text
    End Sub
End Class



