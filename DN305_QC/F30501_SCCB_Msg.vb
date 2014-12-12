Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports PClass
Imports BaseClass
Imports PClass.CReport

Public Class F30501_SCCP_Msg
    Dim PBRKID As String = ""
    Dim dtList As DataTable
    Dim dtTable As DataTable
    Dim DtChePai As DataTable
    Dim State As Enum_PBRK = Enum_PBRK.New_PBRK


    Public Sub New()
        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        ' 在 InitializeComponent() 调用之后添加任何初始化。
    End Sub

    Public Sub New(ByVal initID As String)
        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        ' 在 InitializeComponent() 调用之后添加任何初始化。
        PBRKID = initID
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
        ID = 40200
        Control_CheckRight(ID, ClassMain.Modify, Cmd_Modify)

    End Sub

    Private Sub Form_Msg_Load() Handles Me.Me_Load
        Fg1.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never
        Fg1.Rows.Count = 1
        Fg2.Rows.Count = 1
        FormCheckRight()
        Ch_Name = "生产配布单"
        SelStyle()
        Fg1.IniFormat()
        TB_Client_No.Tag = "0"
        'CB_ChePai.DataSource = Emplyee.GetAllEmployee.Copy
        Select Case Mode
            Case Mode_Enum.Add
                If CheckRight(ID, ClassMain.Add) = False Then Me.ShowErrMsg("没有权限添加!", True) : Exit Sub
                TB_ZhiDan.Text = User_Display
                LabelTitle.Text = Me.Ch_Name
                Btn_Preview.Enabled = False
                Btn_Print.Enabled = False
                Fg2.Rows.Count = 1
                Fg1.Rows.Count = 1
                CaculateSumAmount()
            Case Mode_Enum.Modify
                Get_GH(PBRKID)
                LabelTitle.Text = Me.Ch_Name

        End Select
    End Sub







#Region "表单信息"




    ''' <summary>
    ''' 获取表单内容
    ''' </summary>
    ''' <remarks></remarks>
    Protected Function GetList() As DataTable
        Dim dt As New DataTable("T")
        dt.Columns.Add("PBRK_ID")
        dt.Columns.Add("PBRK_Line", GetType(Integer))
        dt.Columns.Add("PB", GetType(Double))
        dt.Columns.Add("ZL", GetType(Double))
        dt.Columns.Add("GH")

        If Not dt Is Nothing AndAlso Not TB_GH.Text = "" Then
            dt.Clear()
            For i As Integer = 1 To Fg2.Rows.Count - 1
                Dim dr As DataRow = dt.NewRow
                dr("PBRK_ID") = Fg2.Item(i, "PBRK_ID")
                dr("PBRK_Line") = Fg2.Item(i, "PBRK_Line")
                dr("ZL") = Fg2.Item(i, "ZL")
                dr("PB") = Fg2.Item(i, "PB")
                dr("GH") = TB_GH.Text
                dt.Rows.Add(dr)
            Next
        End If
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
        If dt.Rows.Count = 1 Then
            Dim Dr As DataRow = dt.Rows(0)

            TB_GH.Text = IsNull(Dr("PBRK_ID"), "")
            If Not Dr("PBRK_Date") Is DBNull.Value Then
                DTP_Date.Value = Dr("PBRK_Date")
            End If
            'Client_List1.GetByTextBoxTag(IsNull(Dr("Client_ID"), "0"))
            'Bz_List1.GetByTextBoxTag(IsNull(Dr("BZ_ID"), "0"))



            TB_SumQty.Text = FormatNum(IsNull(Dr("SumQty"), 0))
            TB_PWeight.Text = FormatZL(IsNull(Dr("SumPWeight"), 0))

            BZC_Name.Text = IsNull(Dr("CangWei"), "")
            TB_ShaPi.Text = IsNull(Dr("ShaPi"), "")
            TB_PBRK_ID.Text = IsNull(Dr("ClientBill"), "")
            TB_TextileFatory.Text = IsNull(Dr("ZhiChang"), "")

            TB_Notice.Text = IsNull(Dr("Notice"), "")
            TB_Remark.Text = IsNull(Dr("Remark"), "")

            TB_PB_User.Text = IsNull(Dr("ShenHe"), "")
            TB_XiaoZhang.Text = IsNull(Dr("XiaoZhang"), "")
            TB_ZhiDan.Text = IsNull(Dr("ZhiDan"), "")
            State = IsNull(Dr("State"), Enum_PBRK.New_PBRK)
        Else

        End If
    End Sub

    ''' <summary>
    ''' FG合计
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub CaculateSumAmount()
        If Fg1.Rows.Count <= 1 Then
            TB_SumQty.Text = 0
            TB_PWeight.Text = 0
            TB_RemainQty.Text = 0
            TB_RemainZl.Text = 0

        End If
        Dim SumQty As Double = 0
        Dim SumPWeight As Double = 0
        Dim ReMainQty As Double = 0
        Dim ReMainZl As Double = 0

        For R As Integer = 1 To Fg1.Rows.Count - 1
            If Fg1.Item(R, "GH") = "" Then
                If Val(Fg1.Item(R, "ZL")) > 0 Then
                    ReMainQty = ReMainQty + 1
                    ReMainZl = ReMainZl + Val(Fg1.Item(R, "ZL"))
                End If
            End If
            If Val(Fg1.Item(R, "ZL")) > 0 Then
                SumQty = SumQty + 1
                SumPWeight = SumPWeight + Val(Fg1.Item(R, "ZL"))
            End If
        Next
        TB_SumQty.Text = FormatNum(SumQty)
        TB_PWeight.Text = FormatZL(SumPWeight)
        TB_RemainQty.Text = FormatNum(ReMainQty)
        TB_RemainZl.Text = FormatZL(ReMainZl)

        SumQty = 0
        SumPWeight = 0
        ReMainZl = 0
        For R As Integer = 1 To Fg2.Rows.Count - 1
            If Val(Fg2.Item(R, "PB")) > 0 Then
                SumQty = SumQty + 1
                SumPWeight = SumPWeight + Val(Fg2.Item(R, "PB"))
            End If
        Next
        TB_YPQty.Text = FormatNum(SumQty)
        TB_YPZL.Text = FormatZL(SumPWeight)
        TB_XPQty.Text = FormatNum(Val(TB_CR_LuoSeBzCount.Text) - SumQty)
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

            If TB_CR_LuoSeBzZL.Visible = True Then
                If Math.Abs(Val(TB_YPZL.Text) - Val(TB_CR_LuoSeBzZL.Text)) > 10 Then
                    ShowConfirm("配布重量小于落色重量,是否保存本" & Ch_Name & "?", AddressOf SavePBRK)
                Else
                    ShowConfirm("是否保存" & Ch_Name & "[" & TB_GH.Text & "] 的修改?", AddressOf SavePBRK)
                End If
            Else
                If Val(TB_CR_LuoSeBzCount.Text) = Fg2.Rows.Count - 1 Then
                    ShowConfirm("是否保存" & Ch_Name & "[" & TB_GH.Text & "] 的修改?", AddressOf SavePBRK)
                Else
                    ShowConfirm("配布条数小于落色条数,是否保存本" & Ch_Name & "?", AddressOf SavePBRK)
                End If
            End If
        End If
    End Sub

    ''' <summary>
    ''' 保存修改
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub SavePBRK()
        Dim R As MsgReturn
        Dim Dt As DataTable = GetList()
        R = SCPB_Save(TB_GH.Tag, DTP_Date.Value, Dt, TB_CR_LuoSeBzZL.Visible = False)

        If R.IsOk Then
            LastForm.ReturnId = TB_GH.Text
            ShowOk(R.Msg, True)
        Else
            If R.Msg.StartsWith("2") Then

                Dim ID() As String = R.Msg.Split(";")(1).Split(",")
                Dim sErr As New StringBuilder("")
                sErr.AppendLine("保存配布单失败,原因:重量为")
                For i As Integer = 0 To ID.Length - 1
                    If ID(i) <> "" Then
                        Dim Row() As DataRow = Dt.Select("PBRK_Line=" & ID(i))
                        If Row.Length > 0 Then
                            sErr.Append(Row(0)("ZL"))
                            sErr.Append(",")
                            For j As Integer = 1 To Fg2.Rows.Count - 1
                                If Fg2.Item(j, "PBRK_Line") = ID(i) Then
                                    Fg2.Rows.Remove(j)
                                    Exit For
                                End If
                            Next
                        End If
                    End If
                Next
                sErr.AppendLine("已经被配布,系统自动删除这几条布!")
                ShowErrMsg(sErr.ToString)
                If TB_GH.Text <> "" Then Get_GH(TB_GH.Text)
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
        If Fg2.Rows.Count <= 1 Then
            ShowErrMsg("配布列表不能为空!")
            Return False
        End If
        If TB_CR_LuoSeBzZL.Visible = True Then
            If (Val(TB_YPZL.Text) - 10) > Val(TB_CR_LuoSeBzZL.Text) Then
                ShowErrMsg("配布重量不能大于落色重量!")
                Return False
            End If
        Else
            If Fg2.Rows.Count - 1 > Val(TB_CR_LuoSeBzCount.Text) Then
                ShowErrMsg("配布条数不能大于落色条数!")
                Return False
            End If
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
        Dim i As Integer = Fg2.RowSel
        If i > 0 AndAlso Fg2.Rows.Count > 1 Then
            Try
                For j As Integer = 1 To Fg1.Rows.Count - 1
                    If Fg1.Item(j, "PBRK_Line") = Fg2.Item(i, "PBRK_Line") Then
                        Fg1.Item(j, "GH") = ""
                        Fg1.Item(j, "State_Name") = "新建"
                        Fg1.Item(j, "Date_PeiBu") = ""
                        FG_SetForeColorNormal(j)
                        Exit For
                    End If
                Next
                Fg2.Rows.Remove(i)
            Catch ex As Exception
            End Try
            CaculateSumAmount()


            If TB_CR_LuoSeBzZL.Visible = True Then
                If Math.Abs(Val(TB_YPZL.Text) - Val(TB_CR_LuoSeBzZL.Text)) < 10 OrElse (Val(TB_YPZL.Text) + 10) > Val(TB_CR_LuoSeBzZL.Text) Then
                    TB_PBRK_ID.ReadOnly = True
                    TB_Input.ReadOnly = True
                    TB_PBRK_ID.Focus()
                Else
                    If Val(TB_CR_LuoSeBzZL.Text) > 0 Then
                        TB_PBRK_ID.ReadOnly = False
                        TB_Input.ReadOnly = False
                    End If
                End If
            Else
                If Fg2.Rows.Count - 1 >= Val(TB_CR_LuoSeBzCount.Text) Then
                    TB_Input.ReadOnly = True
                    TB_PBRK_ID.ReadOnly = True
                Else
                    If Val(TB_CR_LuoSeBzCount.Text) > 0 Then
                        TB_PBRK_ID.ReadOnly = False
                        TB_Input.ReadOnly = False
                    End If
                End If
            End If



            If Fg2.Rows.Count < 2 Then
            Else
                Fg2.ReAddIndex()
            End If
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


#Region "选入库单"
    Private Sub TB_PBRK_ID_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TB_PBRK_ID.KeyPress
        If e.KeyChar = vbCr Then
            FG_Get_PBRK(TB_PBRK_ID.Text)
        End If
    End Sub


    Sub FG_Get_PBRK(ByVal ID As String)
        Dim R As DtReturnMsg = SCPB_GetPBRK_Table_ByID(ID)
        If R.IsOk = False Then
            ShowErrMsg("查询入库单失败!", AddressOf TB_PBRK_ID.Focus)
            Exit Sub
        End If
        If R.Dt.Rows.Count = 0 Then
            ShowErrMsg("入库单[" & ID & "不存在]!", AddressOf TB_PBRK_ID.Focus)
            Exit Sub
        End If
        Dim Dr As DataRow = R.Dt.Rows(0)
        Select Case IsNull(Dr("State"), 0)
            Case Enum_PBRK.New_PBRK
                ShowErrMsg("入库单[" & ID & "没有审核不能配布]!", AddressOf TB_PBRK_ID.Focus)
                Exit Sub
            Case Enum_PBRK.XiaoZhang
                ShowErrMsg("入库单[" & ID & "已经销账不能配布]!", AddressOf TB_PBRK_ID.Focus)
                Exit Sub
            Case Enum_PBRK.ShenHe

            Case Else
                ShowErrMsg("入库单[" & ID & "状态错误不能配布]!", AddressOf TB_PBRK_ID.Focus)
                Exit Sub
        End Select
        If IsNull(Dr("Client_ID"), "") <> TB_Client_No.Tag Then
            ShowErrMsg("入库单[" & ID & "]不属于客户[" & TB_Client_Name.Text & "]的布,不能配布!", AddressOf TB_PBRK_ID.Focus)
            Exit Sub
        End If

        If IsNull(Dr("BZ_ID"), "") <> TB_BZ_No.Tag Then
            ShowErrMsg("入库单[" & ID & "]不是布类[" & TB_BZ_Name.Text & "],不能配布!", AddressOf TB_PBRK_ID.Focus)
            Exit Sub
        End If


        '赋值
        TB_ShaPi.Text = IsNull(Dr("ShaPi"), "")
        TB_Remark.Text = IsNull(Dr("Remark"), "")
        TB_Notice.Text = IsNull(Dr("Notice"), "")
        DTR_PBRK_Date.Value = IsNull(Dr("PBRK_Date"), "1999-1-1")

        TB_Input.Tag = Dr("PBRK_ID")
        Dim RL As DtReturnMsg = PBRK_SetListById(Dr("PBRK_ID"))

        If RL.IsOk = False Then
            ShowErrMsg("查询入库单失败!", AddressOf TB_PBRK_ID.Focus)
            Exit Sub
        End If

        Fg1.DtToSetFG(RL.Dt)
        For i As Integer = 1 To Fg1.Rows.Count - 1
            If Fg1.Item(i, "GH") <> "" Then
                If Fg1.Item(i, "GH") = TB_GH.Tag Then
                    Fg1.Item(i, "Date_PeiBu") = DTP_Date.Value
                    Fg1.Item(i, "State_Name") = "正在配布"
                    FG_SetForeColorBlue(i)
                Else
                    FG_SetForeColorRed(i)
                End If
            Else
                For j As Integer = 1 To Fg2.Rows.Count - 1
                    Dim line As Integer = Fg1.Item(i, "PBRK_Line")
                    If Fg2.Item(j, "PBRK_Line") = line Then
                        Fg1.Item(i, "GH") = TB_GH.Tag
                        Fg1.Item(i, "State_Name") = "正在配布"
                        Fg1.Item(i, "Date_PeiBu") = DTP_Date.Value
                        FG_SetForeColorBlue(i)
                        j = Fg2.Rows.Count
                    End If
                Next
            End If
        Next

        CaculateSumAmount()
        If TB_CR_LuoSeBzZL.Visible = True Then
            If Math.Abs(Val(TB_YPZL.Text) - Val(TB_CR_LuoSeBzZL.Text)) < 10 OrElse (Val(TB_YPZL.Text) + 10) > Val(TB_CR_LuoSeBzZL.Text) Then
                TB_Input.ReadOnly = True
            Else
                TB_Input.ReadOnly = False
            End If
        Else
            If Fg2.Rows.Count - 1 >= Val(TB_CR_LuoSeBzCount.Text) Then
                TB_Input.ReadOnly = True
            Else
                TB_Input.ReadOnly = False
            End If
        End If


        TB_Input.Focus()
    End Sub
#End Region

#Region "选缸号"


    Private Sub TB_GH_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TB_GH.KeyPress
        If e.KeyChar = vbCr Then
            Get_GH(TB_GH.Text)
        End If
    End Sub

    Sub Get_GH(ByVal ID As String)
        If ID.StartsWith("GY", StringComparison.CurrentCultureIgnoreCase) = False Then
            ID = "GY" & ID
        End If
        Dim R As DtReturnMsg = SCPB_GetGH_ByID(ID)
        If R.IsOk = False Then
            ShowErrMsg("查询缸号失败!", AddressOf TB_GH.Focus)
            Exit Sub
        End If
        If R.Dt.Rows.Count = 0 Then
            ShowErrMsg("缸号[" & ID & "不存在]!", AddressOf TB_GH.Focus)
            Exit Sub
        End If
        Dim Dr As DataRow = R.Dt.Rows(0)
        Select Case IsNull(Dr("State"), 0)
            Case Enum_ProduceState.XiaDan
                Cmd_Modify.Visible = Cmd_Modify.Tag
                TB_PBRK_ID.ReadOnly = False
                TB_Input.ReadOnly = False
                Btn_RemoveRow.Enabled = True
            Case Enum_ProduceState.AddNew
                ShowErrMsg("缸号[" & ID & "]没有审核不能配布!", AddressOf TB_PBRK_ID.Focus)

                Exit Sub
            Case Else
                ShowErrMsg("缸号[" & ID & "]不是待配布状态不能配布!", AddressOf TB_PBRK_ID.Focus)
                Cmd_Modify.Visible = False
                TB_Input.ReadOnly = True
                TB_PBRK_ID.ReadOnly = True
                Btn_RemoveRow.Enabled = False
        End Select


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


        TB_GH.Text = IsNull(Dr("Produce_ID"), "")
        TB_ZhiDan.Text = IsNull(Dr("KaiDan"), "")
        TB_PB_User.Text = IsNull(Dr("PB_User"), "")
        TB_BZ_No.Text = IsNull(Dr("BZ_No"), "")
        TB_BZ_No.Tag = IsNull(Dr("BZ_Id"), 0)
        TB_BZ_Name.Text = IsNull(Dr("BZ_Name"), "")
        TB_TextileFatory.Text = IsNull(Dr("TextileFatory"), "")
        TB_ProcessType.Text = IsNull(Dr("ProcessType"), "")

        BZC_No.Text = IsNull(Dr("BZC_No"), "")
        BZC_Name.Text = IsNull(Dr("BZC_Name"), "")

        DTP_Date_LuoSe.Value = IsNull(Dr("Date_LuoSe"), "1999-1-1")
        DTP_Date_KaiDan.Value = IsNull(Dr("Date_KaiDan"), "1999-1-1")
        DTP_Date_JiaoHuo.Value = IsNull(Dr("Date_JiaoHuo"), "1999-1-1")
        LB_State.Text = ComFun.GetProduceStateName(IsNull(Dr("State"), 0))

        Dim RDt As DtReturnMsg = PBRK_GetListByGH(TB_GH.Text)

        If RDt.IsOk Then
            Fg2.DtToSetFG(RDt.Dt)
        End If

        CaculateSumAmount()
        If TB_CR_LuoSeBzZL.Visible = True Then
            If Math.Abs(Val(TB_YPZL.Text) - Val(TB_CR_LuoSeBzZL.Text)) < 10 OrElse (Val(TB_YPZL.Text) + 10) > Val(TB_CR_LuoSeBzZL.Text) Then
                TB_Input.ReadOnly = True
            Else
                TB_Input.ReadOnly = False
            End If
        Else
            If Fg2.Rows.Count - 1 >= Val(TB_CR_LuoSeBzCount.Text) Then
                TB_Input.ReadOnly = True
            Else
                TB_Input.ReadOnly = False
            End If
        End If

        TB_PBRK_ID.Focus()
        TB_GH.Tag = TB_GH.Text
    End Sub
#End Region
#Region "自动匹配重量"


    Private Sub TB_Input_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TB_Input.KeyPress
        If e.KeyChar = vbCr Then
            FG_Sel_Zl(Val(TB_Input.Text))
        End If
    End Sub

    Sub FG_Sel_Zl(ByVal ZL As Double)


        Dim Min As Double = Double.MaxValue
        Dim MinRow As Integer = 0
        Dim H As Boolean = False
        For i As Integer = 1 To Fg1.Rows.Count - 1
            If Fg1.Item(i, "GH") = "" Then
                Dim CZ As Double = Math.Abs(Val(Fg1.Item(i, "ZL")) - ZL)
                If CZ = 0 Then
                    Min = 0
                    MinRow = i
                    Exit For
                Else
                    If CZ <= 0.5 Then
                        If CZ < Min Then
                            Min = CZ
                            MinRow = i
                        End If
                    Else
                        H = True
                    End If
                End If
            End If
        Next
        If MinRow = 0 Then
            If H Then
                TB_Input.Focus()
                TB_Input.SelectAll()
                ShowErrMsg("没有找到重量和[" & ZL & "]相近的胚布!", AddressOf TB_Input.Focus)
            Else
                TB_PBRK_ID.Focus()
                TB_PBRK_ID.SelectAll()
                ShowErrMsg("没有可选的行!", AddressOf TB_PBRK_ID.Focus)
            End If
            Exit Sub
        Else
            If TB_GH.ReadOnly = False Then
                TB_GH.ReadOnly = False
                TB_GH.Text = TB_GH.Tag
            End If


            Fg2.AddRow()
            Dim i As Integer = Fg2.Rows.Count - 1
            Fg2.RowSel = i
            Fg2.Row = i
            Fg2.Item(i, "PBRK_ID") = TB_Input.Tag
            Fg2.Item(i, "PB") = TB_Input.Text
            Fg2.Item(i, "ZL") = Fg1.Item(MinRow, "ZL")
            Fg2.Item(i, "PBRK_Line") = Fg1.Item(MinRow, "PBRK_Line")
            Fg1.Item(MinRow, "GH") = TB_GH.Text
            Fg1.Item(MinRow, "State_Name") = "正在配布"
            Fg1.Item(MinRow, "Date_PeiBu") = DTP_Date.Value

            FG_SetForeColorBlue(MinRow)
            CaculateSumAmount()
            TB_Input.Text = ""

            If TB_CR_LuoSeBzZL.Visible = True Then
                If Math.Abs(Val(TB_YPZL.Text) - Val(TB_CR_LuoSeBzZL.Text)) < 10 OrElse (Val(TB_YPZL.Text) + 10) > Val(TB_CR_LuoSeBzZL.Text) Then
                    TB_PBRK_ID.ReadOnly = True
                    TB_Input.ReadOnly = True
                    TB_PBRK_ID.Focus()
                Else
                    TB_Input.Focus()
                End If
            Else
                If Fg2.Rows.Count - 1 >= Val(TB_CR_LuoSeBzCount.Text) Then
                    TB_PBRK_ID.ReadOnly = True
                    TB_Input.ReadOnly = True
                    TB_PBRK_ID.Focus()
                Else
                    TB_Input.Focus()
                End If
            End If


        End If
    End Sub
#End Region

    Sub FG_SetForeColorNormal(ByVal Row As Integer)
        If Row <= 0 OrElse Row > Fg1.Rows.Count - 1 Then Exit Sub
        If Row Mod 2 = 1 Then
            Fg1.Rows(Row).Style = Fg1.Styles(C1.Win.C1FlexGrid.CellStyleEnum.Alternate)
        Else
            Fg1.Rows(Row).Style = Fg1.Styles(C1.Win.C1FlexGrid.CellStyleEnum.Normal)
        End If
    End Sub


    Sub FG_SetForeColorRed(ByVal Row As Integer)
        If Row <= 0 OrElse Row > Fg1.Rows.Count - 1 Then Exit Sub
        If Row Mod 2 = 1 Then
            Fg1.Rows(Row).Style = Fg1.Styles("HasGHA")
        Else
            Fg1.Rows(Row).Style = Fg1.Styles("HasGH")
        End If
    End Sub

    Sub FG_SetForeColorBlue(ByVal Row As Integer)
        If Row <= 0 OrElse Row > Fg1.Rows.Count - 1 Then Exit Sub
        If Row Mod 2 = 1 Then
            Fg1.Rows(Row).Style = Fg1.Styles("HasGHA_Blue")
        Else
            Fg1.Rows(Row).Style = Fg1.Styles("HasGH_Blue")
        End If
    End Sub

    Sub SelStyle()
        Fg1.Styles.Add("HasGH", Fg1.Styles(C1.Win.C1FlexGrid.CellStyleEnum.Normal))
        Fg1.Styles("HasGH").ForeColor = Color.Red

        Fg1.Styles.Add("HasGHA", Fg1.Styles(C1.Win.C1FlexGrid.CellStyleEnum.Alternate))
        Fg1.Styles("HasGHA").ForeColor = Color.Red



        Fg1.Styles.Add("HasGH_Blue", Fg1.Styles(C1.Win.C1FlexGrid.CellStyleEnum.Normal))
        Fg1.Styles("HasGH_Blue").ForeColor = Color.Blue

        Fg1.Styles.Add("HasGHA_Blue", Fg1.Styles(C1.Win.C1FlexGrid.CellStyleEnum.Alternate))
        Fg1.Styles("HasGHA_Blue").ForeColor = Color.Blue
    End Sub




    Private Sub Fg1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fg1.DoubleClick
        If Fg1.RowSel > 0 AndAlso Fg1.Item(Fg1.RowSel, "GH") = "" AndAlso TB_Input.ReadOnly = False Then
            TB_Input.Text = Fg1.Item(Fg1.RowSel, "ZL")
            FG_Sel_Zl(Val(TB_Input.Text))
        End If
    End Sub



End Class
