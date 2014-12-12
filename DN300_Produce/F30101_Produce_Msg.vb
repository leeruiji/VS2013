Option Compare Text
Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports PClass
Imports BaseClass
Imports PClass.CReport

Public Class F30101_Produce_Msg

    Dim dtList As DataTable
    Dim dtTable As DataTable
    Dim state As Enum_ProduceState
    Dim stateSave As Enum_ProduceState
    Dim cz As String = ""

#Region "窗口定义"
    Private Sub Label_ID_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label_ID.DoubleClick
        If TB_GH.Text = "" Then
            Exit Sub
        End If
        Dim F As New F30001_Produce_Gd_Msg(TB_GH.Text)
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

        Control_CheckRight(ID, ClassMain.Modify, Cmd_Modify)

    End Sub

    Private Sub F30201_CPZL_Msg_AfterLoad() Handles Me.AfterLoad
        TB_GH_Input.Focus()
    End Sub


    Private Sub PanelMain_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles PanelMain.GotFocus
        If PanelDZ.Visible Then
            PanelDZ.Focus()
        Else
            TB_GH_Input.Focus()
        End If
    End Sub




    Private Sub F30202_CPZL_Input_Me_Closed() Handles Me.Me_Closed
        If F_RS_ID5 = "AutoClose" Then
            MainForm.CloseWindows()
        End If
    End Sub

    Private Sub Form_Msg_Load() Handles Me.Me_Load
        FormCheckRight()
        ShowGHInput()
        Ch_Name = GetBillTypeName(ID)
        'Dao.Balance_DB_NAME = Ch_Name
        Me.Title = Ch_Name

        Select Case ID
            Case 30101
                stateSave = Enum_ProduceState.YuDing
                Cmd_CZ.Text = ComFun.GetProduceStateName(stateSave).Replace("已", "") & "(&+)"
                TB_RanseGH.ReadOnly = True
            Case 30102
                stateSave = Enum_ProduceState.ChuGang
                Cmd_CZ.Text = ComFun.GetProduceStateName(stateSave).Replace("已", "") & "(&+)"
                TB_RanseGH.ReadOnly = False
            Case 30103
                stateSave = Enum_ProduceState.DingXing
                Cmd_CZ.Text = ComFun.GetProduceStateName(stateSave).Replace("已", "") & "(&+)"
                TB_RanseGH.ReadOnly = True

        End Select


   

        TB_Client_No.Tag = "0"
        'CB_ChePai.DataSource = Emplyee.GetAllEmployee.Copy
        Select Case Mode
            Case Mode_Enum.Add
                If CheckRight(ID, ClassMain.Add) = False Then Me.ShowErrMsg("没有权限添加!", True) : Exit Sub
                ' TB_ZhiDan.Text = User_Display
                LabelTitle.Text = Me.Ch_Name
                Btn_Preview.Enabled = False
                Btn_Print.Enabled = False

                TB_GH_Input.Focus()
            Case Mode_Enum.Modify
                Get_GH(Bill_ID)
                LabelTitle.Text = Me.Ch_Name

        End Select
    End Sub

#End Region


#Region "表单信息"







    ''' <summary>
    ''' 设置表单内容
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub SetForm(ByVal dt As DataTable)
        If dt Is Nothing Then
            Exit Sub
        End If
        If dt.Rows.Count = 1 Then
            Dim Dr As DataRow = dt.Rows(0)

            TB_GH.Text = IsNull(Dr("PBRK_ID"), "")
            If Not Dr("PBRK_Date") Is DBNull.Value Then
                DTP_Date.Value = Dr("PBRK_Date")
            End If
            'Client_List1.GetByTextBoxTag(IsNull(Dr("Client_ID"), "0"))
            'Bz_List1.GetByTextBoxTag(IsNull(Dr("BZ_ID"), "0"))

            TB_PWeight.Text = FormatZL(IsNull(Dr("SumPWeight"), 0))

            BZC_Name.Text = IsNull(Dr("CangWei"), "")

            TB_TextileFatory.Text = IsNull(Dr("ZhiChang"), "")




            'TB_ZhiDan.Text = IsNull(Dr("ZhiDan"), "")
        Else

        End If
    End Sub





    Private JZ As Double = 0
#End Region

#Region "工具栏按钮"



    Sub DoNothing()

    End Sub

    Dim isPrint As Boolean = False



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

#Region "报表事件"








#End Region

#Region "选缸号"


    Private Sub TB_GH_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TB_GH.KeyPress

    End Sub




    Sub Get_GH(ByVal id As String)
        LabelErr.Text = ""
        id = ComFun.FixGH(id)
        Dim Mr As MsgReturn = ComFun.GetGHForTM(id)
        If Mr.IsOk = False Then
            ShowErrMsg(Mr.Msg)
            Exit Sub
        End If
        id = Mr.Msg

        Dim R As DtReturnMsg = Dao.CPZL_GetGH_ByID(id)
        If R.IsOk = False Then
            LabelErr.Text = "查询缸号失败!"
            TB_GH_Input.Focus()
            TB_GH_Input.SelectAll()
            Exit Sub
        End If
        If R.Dt.Rows.Count = 0 Then
            LabelErr.Text = "缸号[" & id & "不存在]!"
            TB_GH_Input.Focus()
            TB_GH_Input.SelectAll()
            Exit Sub
        End If

        Dim Dr As DataRow = R.Dt.Rows(0)
        If IsNull(Dr("IsTP"), False) Then
            LabelErr.Text = "缸号[" & id & "]是退胚缸不能操作!"
            TB_GH_Input.Focus()
            TB_GH_Input.SelectAll()
            Exit Sub
        End If
        state = IsNull(Dr("State"), 0)
        'If IsNull(Dr("State"), 0) > Enum_ProduceState.RanSe AndAlso IsNull(Dr("State"), 0) < Enum_ProduceState.ChengJian Then
        '    If IsNull(Dr("CR_LuoSeBzCount"), 0) <> IsNull(Dr("PB_CountSum"), 0) Then
        '        LabelErr.Text = "缸号[" & id & "]胚布条数和落色条数不一致,不能录入成品重量!"
        '        TB_GH_Input.Focus()
        '        TB_GH_Input.SelectAll()
        '        Exit Sub
        '    Else
        '        SetReadOnly(True)
        '    End If
        '    Btn_Preview.Enabled = False
        '    Btn_Print.Enabled = False
        'Else
        '    LabelErr.Text = "缸号[" & id & "]状态是" & BaseClass.ComFun.GetProduceStateName(IsNull(Dr("State"), 0)) & ",不能录入成品重量!"
        '    TB_GH_Input.Focus()
        '    TB_GH_Input.SelectAll()
        '    Exit Sub
        '    'ShowErrMsg("缸号[" & ID & "]当前状态不能录入成品重量!", AddressOf TB_GH.Focus)
        '    Btn_Preview.Enabled = True
        '    Btn_Print.Enabled = True
        '    SetReadOnly(False)
        'End If
        If IsNull(Dr("Client_Name"), "") = "毅泰" Then
            Cmd_Preview.Enabled = True
        Else
            Cmd_Preview.Enabled = False
        End If



        '赋值
        TB_Client_No.Text = IsNull(Dr("Client_No"), "")
        TB_Client_No.Tag = IsNull(Dr("Client_Id"), 0)
        TB_Client_Name.Text = IsNull(Dr("Client_Name"), "")
        TB_Contract.Text = IsNull(Dr("Contract"), "")
        TB_CR_LuoSeBzCount.Text = IsNull(Dr("CR_LuoSeBzCount"), 0)
        TB_Remark.Text = IsNull(Dr("Remark"), 0)

        TB_GH.Text = IsNull(Dr("GH"), "")
        TB_RanseGH.Text = IsNull(Dr("RanSeGH"), "")
        'TB_ZhiDan.Text = IsNull(Dr("KaiDan"), "")

        TB_BZ_No.Text = IsNull(Dr("BZ_No"), "")
        TB_BZ_No.Tag = IsNull(Dr("BZ_Id"), 0)
        TB_BZ_Name.Text = IsNull(Dr("BZ_Name"), "")
        TB_TextileFatory.Text = IsNull(Dr("TextileFatory"), "")
        TB_ProcessType.Text = IsNull(Dr("ProcessType"), "")
        TB_PWeight.Text = IsNull(Dr("PB_ZLSum"), 0)

        BZC_No.Text = IsNull(Dr("BZC_No"), "")
        BZC_Name.Text = IsNull(Dr("BZC_Name"), "")

        DTP_Date_LuoSe.Value = IsNull(Dr("Date_LuoSe"), "1999-1-1")
        DTP_Date_KaiDan.Value = IsNull(Dr("Date_KaiDan"), "1999-1-1")
        DTP_Date_JiaoHuo.Value = IsNull(Dr("Date_JiaoHuo"), "1999-1-1")
        LB_State.Text = ComFun.GetProduceStateName(IsNull(Dr("State"), 0))
        JZ = IsNull(Dr("JiaZhong"), 0) + IsNull(Dr("ZhiTong"), 0)
        dtTable = R.Dt
        dtTable.Columns.Add("CP", GetType(Double))
        dtTable.Columns.Add("CP_Line", GetType(Integer))

        ShowDZ()
    End Sub
#End Region

#Region "获取成品单号"
    Sub ShowDZ()
        Panel_Input.Visible = False
        PanelDZ.RightToLeft = Windows.Forms.RightToLeft.No
        PanelDZ.Visible = True
        PanelDZ.BringToFront()
        If state < Enum_ProduceState.PeiBu Then
            Cmd_CZ.Enabled = False
            LB_Msg.Text = "缸号未配布不能" & ComFun.GetProduceStateName(stateSave).Replace("已", "")
            LB_Msg.ForeColor = Color.Red
            Cmd_Return.Focus()
        ElseIf state >= stateSave Then
            Cmd_CZ.Enabled = False
            LB_Msg.Text = "缸号已经在[" & ComFun.GetProduceStateName(state) & "]不能再" & ComFun.GetProduceStateName(stateSave).Replace("已", "")
            LB_Msg.ForeColor = Color.Red
            Cmd_Return.Focus()
        Else
            Cmd_CZ.Enabled = True
            LB_Msg.Text = "缸号可以" & ComFun.GetProduceStateName(stateSave).Replace("已", "")
            LB_Msg.ForeColor = Color.Blue

            If stateSave = Enum_ProduceState.RanSe Then
                TB_RanseGH.Focus()
            Else
                Cmd_CZ.Focus()
            End If
        End If


    End Sub





#End Region



#Region "Input"
    Sub ShowGHInput()
        LabelOK.Text = ""
        PanelDZ.Visible = False
        Panel_Input.Visible = True
        Panel_Input.BringToFront()
        TB_GH_Input.Focus()
        TB_GH_Input.SelectAll()
    End Sub



    Private Sub TB_GH_Input_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TB_GH_Input.KeyPress
        If e.KeyChar = vbCr Then
            e.KeyChar = ""
            Get_GH(TB_GH_Input.Text)
        ElseIf e.KeyChar = "+" Then
            e.KeyChar = ""
            Get_GH(TB_GH_Input.Text)
        ElseIf e.KeyChar = "-" Then
            e.KeyChar = Chr(Keys.Back)
        ElseIf e.KeyChar = "*" Then
            e.KeyChar = ""
            Me.Close()
        End If
    End Sub

    Private Sub Cmd_Input_OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Input_OK.Click
        Get_GH(TB_GH_Input.Text)
    End Sub

    Private Sub Cmd_Input_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Input_Exit.Click
        Me.Close()
    End Sub
#End Region




#Region "保存Panel"

    Private Sub Cmd_CZ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_CZ.Click
        If Cmd_CZ.Enabled = False Then Exit Sub
        Select Case stateSave
            Case Enum_ProduceState.YuDing
                If UpdateState(stateSave) Then
                    LabelErr.Text = "缸号[" & TB_GH.Text & "]已设置状态为[" & ComFun.GetProduceStateName(stateSave) & "]"
                    LabelErr.ForeColor = Color.Blue
                    ShowGHInput()
                End If
            Case Enum_ProduceState.RanSe
                If UpdateState_RanSe(TB_RanseGH.Text, Enum_ProduceState.RanSe, True) Then
                    ShowGHInput()
                    LabelErr.Text = "缸号[" & TB_GH.Text & "]已设置状态为[" & ComFun.GetProduceStateName(stateSave) & "]"
                    LabelErr.ForeColor = Color.Blue
                End If
            Case Enum_ProduceState.DingXing
                If UpdateState(stateSave) Then
                    ShowGHInput()
                    LabelErr.Text = "缸号[" & TB_GH.Text & "]已设置状态为[" & ComFun.GetProduceStateName(stateSave) & "]"
                    LabelErr.ForeColor = Color.Blue
                End If
            Case Enum_ProduceState.ChuGang
                If UpdateState_RanSe(TB_RanseGH.Text, Enum_ProduceState.ChuGang, True) Then
                    ShowGHInput()
                    LabelErr.Text = "缸号[" & TB_GH.Text & "]已设置状态为[" & ComFun.GetProduceStateName(stateSave) & "]"
                    LabelErr.ForeColor = Color.Blue
                End If
        End Select

    End Sub



    Private Sub Cmd_Return_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Return.Click
        ShowGHInput()
    End Sub


#End Region



#Region "新增,修改"
    Private Function UpdateState_RanSe(ByVal _RanSeGh As String, ByVal state As Enum_ProduceState, ByVal UpdateState As Boolean) As Boolean
        Dim Msg As MsgReturn = Dao.Produce_UpdateState_RanSeGH(TB_GH.Text, _RanSeGh, state, UpdateState)
        If Msg.IsOk = False Then
            ShowErrMsg(Msg.Msg)
        Else

        End If
        Return Msg.IsOk
    End Function

    Private Function UpdateState(ByVal _State As Enum_ProduceState) As Boolean
        Dim Msg As MsgReturn = Dao.Produce_UpdateState(TB_GH.Text, _State)
        If Msg.IsOk = False Then
            ShowErrMsg(Msg.Msg)
        Else

        End If
        Return Msg.IsOk
    End Function

    ''' <summary>
    ''' 更新备注
    ''' </summary>
    ''' <param name="Remark"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function UpdateRemark(ByVal Remark As String) As Boolean
        Dim Msg As MsgReturn = Dao.Produce_UpdateRemark(TB_GH.Text, Remark)
        If Msg.IsOk = False Then
            ShowErrMsg(Msg.Msg)
        Else

        End If
        Return Msg.IsOk
    End Function


    Private Sub TB_RanseGH_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TB_RanseGH.KeyPress
        If (e.KeyChar = "+" OrElse e.KeyChar = vbCr) AndAlso Cmd_CZ.Enabled Then
            Cmd_CZ_Click(sender, New EventArgs)
        End If
    End Sub


#End Region




#Region "报表事件"

    Private Sub Btn_Preview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Preview.Click
        Print(OperatorType.Preview)
    End Sub

    Private Sub Btn_Print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Preview.Click
        Print(OperatorType.Print)
    End Sub

    Protected Sub Print(ByVal DoOperator As OperatorType)

        Dim R As New R30000_ProduceGd(CheckRight(ID, ClassMain.CanExcelOut))
        R.Start(TB_GH.Text, DoOperator)
        '  R.Start(Dt_Produce, DoOperator)
    End Sub

#End Region

 
End Class
