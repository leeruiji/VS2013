Option Compare Text
Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports PClass
Imports BaseClass
Imports PClass.CReport

Public Class F30202_CPZL_Input

    Dim dtList As DataTable
    Dim dtTable As DataTable
    Dim cp_Gh As String = ""

    Dim ComX As String = "com3"
    Dim BaudRate As Integer = 1200
    Dim VF As WinMaxForm


#Region "窗口定义"

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
        ID = 30202
        Control_CheckRight(ID, ClassMain.Modify, Cmd_Modify)

    End Sub

#Region ""
    Private WriteOnly Property SetTopMost() As Boolean
        Set(ByVal value As Boolean)
            If VF IsNot Nothing Then
                VF.TopMost = value
            End If
        End Set
    End Property
#End Region


    Private Sub F30201_CPZL_Msg_AfterLoad() Handles Me.AfterLoad
        If F_RS_ID5 = "AutoClose" Then
            VF = WinMaxForm.SetTabFormOut(Me.VForm)
            If VF IsNot Nothing Then VF.ToMaxAndToMost()

        End If
        ReSetCom()
        TimerCZ.Start()
        ComboBox_Sec.SelectedIndex = 2
        ShowGHInput()

    End Sub

    Private Enum KeyModeType
        GHInput
        GHSelect
        KGInput
        SaveCheck
    End Enum


    Private KeyMode As KeyModeType = KeyModeType.GHInput
    Private Sub F30202_CPZL_Input_Form_KeyDown(ByVal sender As Object, ByRef e As System.Windows.Forms.KeyEventArgs) Handles Me.Form_KeyDown
        Dim IsHander As Boolean = False
        Select Case KeyMode
            Case KeyModeType.GHInput
                Select Case e.KeyCode
                    Case Keys.Return '确认
                        Cmd_Input_OK_Click(sender, e)
                    Case Keys.Back '清除
                        TB_GH_Input.Text = ""
                    Case Keys.Delete '删除
                        Input_Back()
                    Case Keys.Escape '取消
                        Cmd_Input_Exit_Click(sender, e)
                    Case Keys.NumPad0 To Keys.NumPad9, Keys.D0 To Keys.D9
                        If TB_GH_Input.Text.Length > 6 AndAlso (Not IsNumeric(TB_GH_Input.Text.Substring(TB_GH_Input.TextLength - 1))) Then
                            If TB_GH_Input.Text.Substring(TB_GH_Input.TextLength - 1) = "R" Then
                                TB_GH_Input.Text = TB_GH_Input.Text.Substring(0, TB_GH_Input.TextLength - 1)
                                TB_GH_Input.AppendText("A")
                            Else
                                TB_GH_Input.Text = TB_GH_Input.Text.Substring(0, TB_GH_Input.TextLength - 1)
                                TB_GH_Input.AppendText("R")
                            End If
                        Else
                            Dim K As Keys = e.KeyCode
                            If K >= Keys.NumPad0 Then
                                K = K - 48
                            End If
                            TB_GH_Input.AppendText(Chr(K))
                        End If
                    Case Keys.Decimal
                        If TB_GH_Input.Text.Length > 6 Then
                            TB_GH_Input.AppendText("A")
                        End If
                    Case Keys.P
                        If TB_GH_Input.Text.Length > 6 Then
                            If IsNumeric(TB_GH_Input.Text.Substring(TB_GH_Input.TextLength - 1)) Then
                                TB_GH_Input.AppendText("A")
                            Else
                                Dim A As Integer = Asc(TB_GH_Input.Text.Substring(TB_GH_Input.TextLength - 1))
                                A = A + 1
                                TB_GH_Input.Text = TB_GH_Input.Text.Substring(0, TB_GH_Input.TextLength - 1)
                                TB_GH_Input.AppendText(Chr(A))
                            End If
                        End If
                    Case Else
                End Select
                IsHander = True
            Case KeyModeType.GHSelect
                Select Case e.KeyCode
                    Case Keys.Return
                        Cmd_Add_Click(Fg3, New System.EventArgs)
                        IsHander = True
                    Case Keys.Escape
                        Cmd_Close_Click(Fg3, New System.EventArgs)
                        IsHander = True
                    Case Keys.Decimal '.
                        Cmd_Edit_Click(Fg3, New System.EventArgs)
                        IsHander = True
                End Select

            Case KeyModeType.KGInput
                Select Case e.KeyCode
                    Case Keys.Return
                        If Cmd_OK.Visible = True Then
                            Cmd_OK_Click(sender, e)
                            IsHander = True
                        End If
                    Case Keys.P
                        Cmd_PrintTM_Click(sender, e)
                        IsHander = True
                    Case Keys.Delete
                        Cmd_Del_Click(sender, e)
                        IsHander = True
                    Case Keys.Escape
                        Cmd_Return_Click(sender, e)
                        IsHander = True
                    Case Keys.Decimal '.
                        Cmd_Reset_Click(sender, e)
                        IsHander = True
                End Select
            Case KeyModeType.SaveCheck
                Select Case e.KeyCode
                    Case Keys.Return
                        Cmd_Save_Click(sender, e)
                    Case Keys.Delete
                        Cmd_NoSave_Click(sender, e)
                    Case Keys.Escape
                        Cmd_Cancel_Click(sender, e)
                End Select
                IsHander = True
        End Select
        If IsHander Then
            e.Handled = True
            e.SuppressKeyPress = False
        End If
    End Sub

    Private Sub F30202_CPZL_Input_GotActive() Handles Me.GotActive
        If Panel_Input.Visible Then TB_GH_Input.Focus()
        If PanelDZ.Visible Then Cmd_Return.Focus()
        If PanelSave.Visible Then Cmd_Save.Focus()
    End Sub



    Private Sub F30202_CPZL_Input_Me_Closed() Handles Me.Me_Closed
        StartGetData = False
        If F_RS_ID5 = "AutoClose" Then
            If VF IsNot Nothing Then
                VF.WindowState = FormWindowState.Minimized
                VF.Visible = False
            End If
        End If
        If SP.IsOpen Then
            Try
                SP.Close()
            Catch ex As Exception
            End Try
        End If
        If F_RS_ID5 = "AutoClose" Then
            If VF IsNot Nothing Then
                VF.WindowState = FormWindowState.Minimized
            End If
            MainForm.CloseWindows()
        End If
    End Sub

    Private Sub Form_Msg_Load() Handles Me.Me_Load

        FormCheckRight()
        ComX = My.Settings.ComX
        BaudRate = My.Settings.BaudRate
        SetRate()

        ShowGHInput()
        Ch_Name = GetBillTypeName(ID)
        'Dao.Balance_DB_NAME = Ch_Name
        Me.Title = Ch_Name

        Fg1.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Always
        Fg1.Rows.Count = 1
        Fg2.Rows.Count = 1

        Fg1.IniFormat()
        Fg3.IniFormat()
        TB_Client_No.Tag = "0"
        'CB_ChePai.DataSource = Emplyee.GetAllEmployee.Copy
        Select Case Mode
            Case Mode_Enum.Add
                If CheckRight(ID, ClassMain.Add) = False Then Me.ShowErrMsg("没有权限添加!", True) : Exit Sub
                ' TB_ZhiDan.Text = User_Display
                LabelTitle.Text = Me.Ch_Name
                Btn_Preview.Enabled = False
                Btn_Print.Enabled = False
                Fg2.Rows.Count = 1
                Fg1.Rows.Count = 1
                CaculateSumAmount()
                TB_GH_Input.Focus()
            Case Mode_Enum.Modify
                Get_GH(Bill_ID)
                LabelTitle.Text = Me.Ch_Name

        End Select
    End Sub

#End Region


#Region "表单信息"




    ''' <summary>
    ''' 获取表单内容
    ''' </summary>
    ''' <remarks></remarks>
    Protected Function GetList() As DataTable
        Dim dt As New DataTable("T")
        dt.Columns.Add("CP", GetType(Double))
        dt.Columns.Add("CP_Line", GetType(Integer))
        dt.Columns.Add("Line", GetType(Integer))
        dt.Columns.Add("CP_GH", GetType(String))
        If Not dt Is Nothing AndAlso Not TB_GH.Text = "" Then
            dt.Clear()
            For i As Integer = 1 To Fg1.Rows.Count - 1
                Dim dr As DataRow = dt.NewRow
                dr("CP") = Fg1.Item(i, "CP")
                dr("CP_GH") = cp_Gh
                dr("CP_Line") = i
                dt.Rows.Add(dr)
            Next
            Dim RDt As DtReturnMsg = Dao.PBRK_GetListByGH(TB_GH.Tag)
            If RDt.IsOk Then
                dtList = RDt.Dt
            End If
            Dim DtPB As DataTable = dtList.Copy
            For i As Integer = DtPB.Rows.Count - 1 To 0 Step -1
                If IsNull(DtPB.Rows(i)("CP_GH"), "") <> "" AndAlso IsNull(DtPB.Rows(i)("CP_GH"), "") <> cp_Gh Then
                    DtPB.Rows(i).Delete()
                End If
            Next
            DtPB.AcceptChanges()
            DtPB.DefaultView.Sort = "PB"
            DtPB = DtPB.DefaultView.ToTable
            dt.DefaultView.Sort = "CP"
            dt = dt.DefaultView.ToTable
            For i As Integer = 0 To dt.Rows.Count - 1
                DtPB.Rows(i)("CP") = dt.Rows(i)("CP")
                DtPB.Rows(i)("CP_GH") = dt.Rows(i)("CP_GH")
                DtPB.Rows(i)("CP_Line") = dt.Rows(i)("CP_Line")
            Next
            DtPB.AcceptChanges()
            For i As Integer = DtPB.Rows.Count - 1 To 0 Step -1
                If IsNull(DtPB.Rows(i)("CP_GH"), "") <> cp_Gh Then
                    DtPB.Rows(i).Delete()
                End If
            Next
            DtPB.AcceptChanges()
            Return DtPB
        Else
            Return dtList
        End If

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

            TB_TextileFatory.Text = IsNull(Dr("ZhiChang"), "")




            TB_XiaoZhang.Text = IsNull(Dr("XiaoZhang"), "")
            'TB_ZhiDan.Text = IsNull(Dr("ZhiDan"), "")
        Else

        End If
    End Sub

    ''' <summary>
    ''' FG合计
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub CaculateSumAmount()
        Dim SumZl As Double = 0
        For i As Integer = 1 To Fg1.Rows.Count - 1
            SumZl = SumZl + Val(Fg1.Item(i, "CP"))
        Next
        Dim Q As Integer = 0
        Dim CP As Double = 0
        If SplitContainer1.Panel1Collapsed Then
            For i As Integer = 1 To Fg2.Rows.Count - 1
                If Fg2.Item(i, "CP_GH") <> "" Then
                    Q = Q + 1
                    CP = CP + Fg2.Item(i, "CP")
                End If
            Next
            TB_RemainQty.Text = Val(TB_CR_LuoSeBzCount.Text) - Q
        Else
            For i As Integer = 1 To Fg2.Rows.Count - 1
                If Fg2.Item(i, "CP_GH") <> cp_Gh AndAlso Fg2.Item(i, "CP_GH") <> "" Then
                    Q = Q + 1
                End If
            Next
            TB_RemainQty.Text = Val(TB_CR_LuoSeBzCount.Text) - (Fg1.Rows.Count - 1) - Q
        End If

        TB_SumQty.Text = Fg1.Rows.Count - 1 + Q
        TB_SumZL.Text = FormatZL(SumZl)

        If Val(TB_PWeight.Text) = 0 Then
            TB_SH.Text = "0"
        Else
            If SplitContainer1.Panel1Collapsed Then
                TB_SH.Text = Format(((CP - JZ * Val(TB_SumQty.Text)) / Val(TB_PWeight.Text) - 1), "0.00%")
            Else
                TB_SH.Text = Format(((SumZl - JZ * Val(TB_SumQty.Text)) / Val(TB_PWeight.Text) - 1), "0.00%")
            End If
        End If



        If Val(TB_RemainQty.Text) = 0 Then
            TB_Input.ReadOnly = True
        Else
            TB_Input.ReadOnly = False
        End If


    End Sub


    Private JZ As Double = 0
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
            CaculateSumAmount()
            isPrint = False
            Dim S As String = ""
            If Val(TB_CR_LuoSeBzCount.Text) = Fg1.Rows.Count - 1 Then
                S = "是否保存" & Ch_Name & "[" & TB_GH.Text & LB_CP_GH.Text & "] 的修改?"
            Else
                S = "成品条数小于落色条数,是否保存本" & Ch_Name & LB_CP_GH.Text & "?"
            End If
            ShowConfirmX(S, "保存", "保存并打印", "取消(&" & Chr(27) & ")", AddressOf SavePBRK, AddressOf SaveAndPrint, AddressOf DoNothing)
        End If
    End Sub

    Sub DoNothing()

    End Sub

    Dim isPrint As Boolean = False
    Sub SaveAndPrint()
        isPrint = True
        SavePBRK()
    End Sub

    ''' <summary>
    ''' 保存修改
    ''' </summary>
    ''' <remarks></remarks>
    Protected Function SavePBRK() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.Refresh()
        Dim R As MsgReturn
        Dim Dt As DataTable = GetList()
        R = Dao.CPZL_Save(TB_GH.Tag, cp_Gh, DTP_Date.Value, Dt, Val(TB_RemainQty.Text) <= 0)
        If R.IsOk Then
            LastForm.ReturnId = TB_GH.Text
            If isPrint Then
                Print(OperatorType.Preview)
                ShowGHInput()
                Me.Cursor = Cursors.Default
                Return True
            Else
                ' ShowOk(R.Msg, True)
                ShowGHInput()
                LabelOK.Text = "缸号[" & TB_GH.Text & "]" & R.Msg
                Me.Cursor = Cursors.Default
                Return True
            End If
        Else
            If R.Msg.StartsWith("2") Then
                Dim ID() As String = R.Msg.Split(";")(1).Split(",")
                Dim sErr As New StringBuilder("")
                sErr.AppendLine("保存成品重量录入失败,原因:重量为")
                For i As Integer = 0 To ID.Length - 1
                    If ID(i) <> "" Then
                        Dim Row() As DataRow = Dt.Select("Line=" & ID(i))
                        If Row.Length > 0 Then
                            sErr.Append(Row(0)("ZL"))
                            sErr.Append(",")
                            For j As Integer = 1 To Fg2.Rows.Count - 1
                                If Fg2.Item(j, "Line") = ID(i) Then
                                    Fg2.Rows.Remove(j)
                                    Exit For
                                End If
                            Next
                        End If
                    End If
                Next
                sErr.AppendLine("已经被配布,系统自动删除这几条布!")
                ShowErrMsgX(sErr.ToString)
                If TB_GH.Text <> "" Then Get_GH(TB_GH.Text)
            Else
                ShowErrMsgX(R.Msg.Substring(1))
            End If
        End If
        Me.Cursor = Cursors.Default
        Return False
    End Function


    ''' <summary>
    ''' 验证信息
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Function CheckForm() As Boolean

        CaculateSumAmount()
        If TB_GH.Tag = "" Then
            ShowErrMsgX(Ch_Name & "缸号不能为空!", AddressOf TB_GH.Focus)
            Return False
        End If
        If Fg1.Rows.Count <= 1 Then
            ShowErrMsgX("成品列表不能为空!")
            Return False
        End If

        If Fg1.Rows.Count - 1 > Val(TB_CR_LuoSeBzCount.Text) Then
            ShowErrMsgX("成品条数不能大于落色条数!")
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
        Dim i As Integer = Fg1.RowSel
        isChange = True
        If i > 0 AndAlso Fg1.Rows.Count > 1 Then
            Fg1.RemoveRow()
            CaculateSumAmount()

        End If

    End Sub
#End Region

#Region "报表事件"

    Private Sub Cmd_Preview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Fg3.RowSel > 0 Then
            Print_CP_GH = Fg3.Item(Fg3.RowSel, "CP_GH")
        Else
            Exit Sub
        End If
        Print(OperatorType.Preview)
    End Sub

    Private Sub Cmd_Print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Fg3.RowSel > 0 Then
            Print_CP_GH = Fg3.Item(Fg3.RowSel, "CP_GH")
        Else
            Exit Sub
        End If
        Print(OperatorType.Print)
    End Sub



    Private Sub Btn_Preview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Preview.Click

        If cp_Gh = "" Then
            Print_CP_GH = Fg2.Item(Fg2.RowSel, "CP_GH")
        Else
            Print_CP_GH = cp_Gh
        End If
        Print(OperatorType.Preview)
    End Sub

    Private Sub Btn_Print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Print.Click
        If cp_Gh = "" Then
            Print_CP_GH = Fg2.Item(Fg2.RowSel, "CP_GH")
        Else
            Print_CP_GH = cp_Gh
        End If
        Print(OperatorType.Print)
    End Sub

    Dim Print_CP_GH As String = ""
    Protected Sub Print(ByVal DoOperator As OperatorType)
        If Me.Mode = Mode_Enum.Add Then
            Exit Sub
        End If
        If TB_GH.Tag = "" Then
            Exit Sub
        End If
        Dim R As New R30200_CPZL
        R.Start(TB_GH.Tag, Print_CP_GH, DoOperator)
    End Sub
    Private Sub Cmd_PreViewTM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_PreViewTM.Click
        If cp_Gh = "" Then
            Print_CP_GH = Fg2.Item(Fg2.RowSel, "CP_GH")
        Else
            Print_CP_GH = cp_Gh
        End If
        PrintTM(OperatorType.Preview)
    End Sub
    Protected Sub PrintTM(ByVal DoOperator As OperatorType)
        If Me.Mode = Mode_Enum.Add Then
            Exit Sub
        End If
        If TB_GH.Tag = "" Then
            Exit Sub
        End If
        Dim R As New R10010_GoodsBarcode
        R.Start(TB_GH.Tag, Print_CP_GH, DoOperator)
    End Sub
#End Region

#Region "选缸号"


    Private Sub TB_GH_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TB_GH.KeyPress

    End Sub

    Sub SetReadOnly(ByVal T As Boolean)
        If T = False Then
            Cmd_Modify.Visible = False
        Else
            Cmd_Modify.Visible = Cmd_Modify.Tag
        End If
        TB_Input.ReadOnly = Not T
        Btn_RemoveRow.Enabled = T
        SplitContainer1.Panel1Collapsed = Not T
        Fg2.Cols("ZL").Visible = Not T
    End Sub


    Sub Get_GH(ByVal id As String)
        LabelErr.Text = ""
        cp_Gh = ""
        id = ComFun.FixGH(id)
        Dim Mr As MsgReturn = ComFun.GetGHForTM(id)
        If Mr.IsOk = False Then
            LabelErr.Text = Mr.Msg
            TB_GH_Input.Focus()
            TB_GH_Input.SelectAll()
            Exit Sub
        End If
        id = Mr.Msg
        Fg1.Rows.Count = 1
        Dim R As DtReturnMsg = Dao.CPZL_GetGH_ByID(id)
        If R.IsOk = False Then
            LabelErr.Text = "查询缸号失败!"
            TB_GH_Input.Focus()
            TB_GH_Input.SelectAll()
            Exit Sub
        End If
        If R.Dt.Rows.Count = 0 Then
            LabelErr.Text = "缸号[" & id & "]不存在!"
            TB_GH_Input.Focus()
            TB_GH_Input.SelectAll()
            Exit Sub
        End If
        Dim Dr As DataRow = R.Dt.Rows(0)
        Cmd_PreViewTM.Visible = False
        If IsNull(Dr("IsTP"), False) Then
            LabelErr.Text = "缸号[" & id & "]是退胚缸不能成检!"
            TB_GH_Input.Focus()
            TB_GH_Input.SelectAll()
            Exit Sub
        End If

        If IsNull(Dr("State"), 0) > Enum_ProduceState.RanSe AndAlso IsNull(Dr("State"), 0) < Enum_ProduceState.ChengJian Then
            If IsNull(Dr("CR_LuoSeBzCount"), 0) <> IsNull(Dr("PB_CountSum"), 0) Then
                LabelErr.Text = "缸号[" & id & "]胚布条数和落色条数不一致,不能录入成品重量!"
                TB_GH_Input.Focus()
                TB_GH_Input.SelectAll()
                Exit Sub
            Else
                SetReadOnly(True)
            End If
            Btn_Preview.Enabled = False
            Btn_Print.Enabled = False
        Else
            LabelErr.Text = "缸号[" & id & "]状态是" & BaseClass.ComFun.GetProduceStateName(IsNull(Dr("State"), 0)) & ",不能录入成品重量!"
            TB_GH_Input.Focus()
            TB_GH_Input.SelectAll()
            Exit Sub
            Btn_Preview.Enabled = True
            Btn_Print.Enabled = True
            SetReadOnly(False)

        End If
        If IsNull(Dr("Client_Name"), "") = "毅泰" Then
            Cmd_PrintTM.Enabled = True
            Cmd_PrintTM.Tag = 2
        ElseIf IsNull(Dr("Client_Name"), "") = "大新" Then
            Cmd_PrintTM.Enabled = True
            Cmd_PrintTM.Tag = 1
        Else
            Cmd_PrintTM.Enabled = False
        End If
        Fg2.IniColsSize()
        Fg2.FG_ColResize()


        '赋值
        TB_Client_No.Text = IsNull(Dr("Client_No"), "")
        TB_Client_No.Tag = IsNull(Dr("Client_Id"), 0)
        TB_Client_Name.Text = IsNull(Dr("Client_Name"), "")
        TB_Contract.Text = IsNull(Dr("Contract"), "")
        TB_CR_LuoSeBzCount.Text = IsNull(Dr("CR_LuoSeBzCount"), 0)
        TB_CR_LuoSeBzZL.Text = IsNull(Dr("CR_LuoSeBzZL"), 0)
        TB_JiaZhong.Text = IsNull(Dr("JiaZhong"), 0)
        If IsNull(Dr("CR_LuoSeType"), 0) = 0 Then
            TB_CR_LuoSeBzZL.Visible = False
            Label_CR_LuoSeBzZL.Visible = False
        Else
            TB_CR_LuoSeBzZL.Visible = True
            Label_CR_LuoSeBzZL.Visible = True
        End If


        TB_GH.Text = IsNull(Dr("GH"), "")
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
        Dim RDt As DtReturnMsg = Dao.PBRK_GetListByGH(TB_GH.Text)

        If RDt.IsOk Then
            dtList = RDt.Dt
            Fg2.DtToSetFG(RDt.Dt)
        End If

        If Fg1.Rows.Count - 1 >= Val(TB_CR_LuoSeBzCount.Text) OrElse TB_Input.ReadOnly = True Then
            TB_Input.ReadOnly = True
        Else
            TB_Input.ReadOnly = False
        End If

        'TB_PBRK_ID.Focus()
        TB_GH.Tag = TB_GH.Text
        If SplitContainer1.Panel1Collapsed = False Then
            GetCPGH()
        Else
            CaculateSumAmount()
            LB_CP_GH.Text = ""
            StartGetData = True
        End If
    End Sub
#End Region

#Region "获取成品单号"

    Sub GetCPGH()
        Dim Dtr As DtReturnMsg = Dao.CPZL_GetCPZL_Table_ByID(TB_GH.Tag)
        If Dtr.IsOk Then
            If Dtr.Dt.Rows.Count > 0 Then
                Fg3.DtToSetFG(Dtr.Dt)
                Dim q As Integer = 0
                For i As Integer = 1 To Fg3.Rows.Count - 1
                    q = Fg3.Item(i, "SumQty") + q
                Next
                LB_Qty.Text = q
                ShowCPGH()
            Else
                cp_Gh = "#1"
                LB_CP_GH.Text = cp_Gh
                ShowDZ()
            End If
        End If
    End Sub

    Sub ShowCPGH()
        TimerCP.Start()
    End Sub

    Private Sub TimerCP_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerCP.Tick
        TimerCP.Stop()
        CaptureFromImageToPicture(Me, Panel_CP)
        Panel_CP.BringToFront()
        Panel_Input.Visible = False
        Group_CP.Left = Panel_CP.Width / 2 - Group_CP.Width / 2
        Group_CP.Top = Panel_CP.Height / 2 - Group_CP.Height / 2
        Group_CP.Visible = True
        Group_CP.BringToFront()
        Panel_CP.Visible = True
        PanelMain.Enabled = False
        Fg3.Focus()
    End Sub
    Sub HideCPGH()
        LabelOK.Text = ""
        Panel_CP.Visible = False
        Panel_CP.SendToBack()
        PanelMain.Enabled = True
        CaculateSumAmount()
        Panel_Input.Visible = True
    End Sub



    Private Sub Cmd_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Add.Click
        Dim S As String = Fg3.Item(Fg3.Rows.Count - 1, "CP_GH")
        S = "#" & Val(S.Replace("#", "")) + 1
        cp_Gh = S
        LB_CP_GH.Text = cp_Gh
        LoadCPFormFG()
        HideCPGH()
        ShowDZ()
    End Sub

    Private Sub Cmd_Edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Edit.Click
        If Fg3.RowSel > 0 Then
            Dim S As String = Fg3.Item(Fg3.RowSel, "CP_GH")
            cp_Gh = S
            LB_CP_GH.Text = cp_Gh
            LoadCPFormFG()
            HideCPGH()
            ShowDZ()
        Else
            ShowErrMsgX("请选择一行")
        End If
    End Sub


    Sub LoadCPFormFG()
        Fg1.Rows.Count = 1
        Fg1.DtToSetFG(DtRunSQLtoDt(dtList, "CP_GH='" & cp_Gh & "'", "CP_GH,CP_Line"))
    End Sub
    Private Sub Fg3_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fg3.DoubleClick
        If Fg3.RowSel > 0 Then
            Cmd_Edit_Click(Fg3, New System.EventArgs)
        End If
    End Sub

    Private Sub Cmd_Close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Close.Click
        HideCPGH()
        TB_GH_Input.Focus()
    End Sub

    Private Sub Btn_Refresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Refresh.Click
        GetCPGH()
    End Sub

 

#End Region



#Region "信息提示"
    Private Sub ShowMsgReturn(ByVal Result As MsgBoxResult)

    End Sub

    Private Sub ShowMsgReturnClose(ByVal Result As MsgBoxResult)
        Me.Close(True)
    End Sub

    Public Sub ShowErrMsgX(ByVal Msg As String, ByVal ResultReturn As ConfirmBox.DeReturn)
        If Not VForm Is Nothing Then VForm.ShowShadow()
        Shadow_Form = New ConfirmBox(Msg, Title, ResultReturn, AddressOf HideShadow, MessageBoxButtons.OK, MessageBoxIcon.Error) With {.TopMost = True}
        Shadow_Form.Active()
    End Sub

    Public Sub ShowErrMsgX(ByVal Msg As String, Optional ByVal Close As Boolean = False)
        If Close Then
            If Not VForm Is Nothing Then VForm.ShowShadow()
            Shadow_Form = New ConfirmBox(Msg, Title, AddressOf ShowMsgReturnClose, AddressOf HideShadow, MessageBoxButtons.OK, MessageBoxIcon.Error) With {.TopMost = True}
        Else
            If Not VForm Is Nothing Then VForm.ShowShadow()
            Shadow_Form = New ConfirmBox(Msg, Title, AddressOf ShowMsgReturn, AddressOf HideShadow, MessageBoxButtons.OK, MessageBoxIcon.Error) With {.TopMost = True}
        End If
        Shadow_Form.Active()
    End Sub


    ''' <summary>
    ''' 自定义按钮文件的确认窗口
    ''' </summary>
    ''' <param name="Msg"></param>
    ''' <param name="Button1">按钮1</param>
    ''' <param name="Button2">按钮2</param>
    ''' <param name="Button3">按钮3</param>
    ''' <param name="Button1Return"></param>
    ''' <param name="Button2Return"></param>
    ''' <param name="Button3Return"></param>
    ''' <remarks></remarks>
    Public Overloads Sub ShowConfirmX(ByVal Msg As String, ByVal Button1 As String, ByVal Button2 As String, ByVal Button3 As String, ByVal Button1Return As ConfirmBox.DeNoReturn, ByVal Button2Return As ConfirmBox.DeNoReturn, ByVal Button3Return As ConfirmBox.DeNoReturn)
        If Not VForm Is Nothing Then VForm.ShowShadow()
        Shadow_Form = New ConfirmBox(Msg, Me.Title, Button1, Button2, Button3, Button1Return, Button2Return, Button3Return, AddressOf HideShadow) With {.TopMost = True}
        Shadow_Form.Active()
    End Sub

#Region "ShowInput"
    Sub NoReturn()
        Me.Focus()
    End Sub
    Public Overloads Sub ShowInput(ByVal Msg As String, ByVal YesReturn As InputBoxs.DYesReturn, Optional ByVal DefaultString As String = "", Optional ByVal Title As String = "")

        If Not VForm Is Nothing Then VForm.ShowShadow()
        If Title = "" Then Title = Me.Title
        Shadow_Form = New InputBoxs(Msg, Title, DefaultString, YesReturn, AddressOf NoReturn, AddressOf HideShadow) With {.TopMost = True}
        Shadow_Form.Active()
    End Sub

    Public Overloads Sub ShowInput(ByVal Msg As String, ByVal YesReturn As InputBoxs.DYesReturn, ByVal NoReturn As InputBoxs.DeNoReturn, Optional ByVal DefaultString As String = "", Optional ByVal Title As String = "")
        If Not VForm Is Nothing Then VForm.ShowShadow()
        If Title = "" Then Title = Me.Title
        Shadow_Form = New InputBoxs(Msg, Title, DefaultString, YesReturn, NoReturn, AddressOf HideShadow) With {.TopMost = True}
        Shadow_Form.Active()
    End Sub
#End Region

#End Region

#Region "自动匹配重量"




    Private Sub TB_Input_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TB_Input.KeyPress
        If e.KeyChar = vbCr AndAlso TB_Input.ReadOnly = False Then
            e.Handled = True
            e.KeyChar = ""
            FG_Sel_Zl(Val(TB_Input.Text))
        End If
    End Sub

    Sub FG_Sel_Zl(ByVal ZL As Double)
        Try
            isChange = True
            If ZL <= 0 Then
                ShowErrMsgX("请选择一个正确的重量", AddressOf TB_Input.Focus)
                TB_Input.Text = ""
                Exit Sub
            End If

            If TB_GH.ReadOnly = False Then
                TB_GH.ReadOnly = False
                TB_GH.Text = TB_GH.Tag
            End If

            Fg1.AddRow()
            Dim i As Integer = Fg1.Rows.Count - 1
            Fg1.RowSel = i
            Fg1.Row = i
            Fg1.Item(i, "CP") = ZL
            CaculateSumAmount()
            TB_Input.Text = ""


            If Fg1.Rows.Count - 1 >= Val(TB_CR_LuoSeBzCount.Text) Then
                TB_Input.ReadOnly = True
            Else
                TB_Input.Focus()
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
#End Region




#Region "电子称"
    Private _startGetData As Boolean = False
    Private Property StartGetData() As Boolean
        Get
            Return _startGetData
        End Get
        Set(ByVal value As Boolean)
            _startGetData = value
            Cmd_Reset.Visible = value
        End Set
    End Property

    Private Sub ReSetCom()
        Dim T As New Threading.Thread(AddressOf TResetCod)
        T.Start()
    End Sub
    Sub TResetCod()
        Try
            If SP.IsOpen Then
                Try
                    SP.Close()
                Catch ex As Exception
                End Try
            End If
            StartCom()
        Catch ex As Exception
        End Try
    End Sub



    Private isChange As Boolean = False
    Sub ShowDZ()
        isChange = False
        StartGetData = True
        Txt_Bz_ZL.Text = 0
        LB_ZL.Text = ""
        LB_Time.Text = "请放布"
        LB_ZL.Tag = Nothing
        LB_Index.Text = Fg1.Rows.Count
        If Fg1.Rows.Count > 1 Then
            Fg1.Row = Fg1.Rows.Count - 1
            Fg1.RowSel = Fg1.Rows.Count - 1
        End If
        Panel_Input.Visible = False
        PanelSave.Visible = False
        PanelDZ.Visible = True
        PanelDZ.BringToFront()
        Cmd_Return.Focus()
    End Sub

    Private Sub Cmd_Reset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Reset.Click
        ReSetCom()
    End Sub

    Dim isWD As Boolean = False
    Private Sub TimerCZ_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerCZ.Tick
        'If isWD Then
        '    TimerCZ.Interval = 800
        'Else
        '    TimerCZ.Interval = 333
        'End If
        Static CheckInt As Integer = 0

        TimerCZ.Interval = 500
        Try
            If SP.IsOpen = True Then
                'SerialPort1.Write(Chr(&H1B) + "p")
                If Txt_Bz_ZL.ReadOnly = False Then Txt_Bz_ZL.ReadOnly = True
                LabelKG.Text = LastZL
            Else
                LabelKG.Text = ""
                If Txt_Bz_ZL.ReadOnly = True Then Txt_Bz_ZL.ReadOnly = False
            End If
            If LastZL = "" Then
                CheckInt = CheckInt + 1
                If CheckInt > 5 Then
                    CheckInt = -10
                    ReSetCom()
                End If
            Else
                If CheckInt > 5 Then
                    LastZL = ""
                    CheckInt = -10
                End If
            End If
        Catch ex As Exception
        End Try

    End Sub
    Sub StartCom()
        If SP.IsOpen Then
            Try
                SP.Close()
            Catch ex As Exception
            End Try
        Else
            Try
                If CB_AutoGetZL.Checked Then
                    SP.BaudRate = BaudRate
                    SP.PortName = ComX
                    SP.Open()
                    TimerCZ.Start()
                Else
                    SP.Close()
                    Txt_Bz_ZL.ReadOnly = False
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

    Delegate Sub DGetWeight(ByVal Ws As String)
    Dim Lt As Double = 0
    Sub GetWeight(ByVal Ws As String, Optional ByVal HD As Boolean = False)
        Static StartTime As Date
        Static IsPrint As Boolean

        If StartGetData Then
            If Ws.EndsWith("kg") Then '稳定
                CB_WD.Checked = True
                If CB_AutoDZ.Checked OrElse HD Then
                    Dim k As Double = Val(Ws.Replace("kg", ""))
                    If k < 3 Then '重量小于3
                        Lt = 0
                        StartTime = Now
                        isWD = False
                        IsPrint = False
                        LB_Time.Text = "请放布"
                        LB_Time.ForeColor = Color.Red
                    Else '重量大于3
                        If (Lt = k AndAlso IsPrint = False) OrElse HD Then '稳定并且连续两次称得同样重量
                            Txt_Bz_ZL.Text = FormatN(k + Val(TB_JiaZhong.Text), 1)
                            IsPrint = True
                            LB_Time.Text = "已OK,请放下一条"
                            LB_Time.ForeColor = Color.Blue
                            LB_ZL.Text = Txt_Bz_ZL.Text
                            LB_ZL.Tag = LB_Index.Text
                            PlayPP()
                            isWD = True
                            PrintOneTM(OperatorType.Print)
                            FG_ADD()
                            LB_Index.Text = Fg1.Rows.Count
                        Else
                            If IsPrint = False Then
                                Lt = k
                                LB_Time.Text = "等待稳定"
                                LB_Time.ForeColor = Color.YellowGreen
                            End If
                        End If
                    End If
                Else

                End If
            Else
                CB_WD.Checked = False
                If CB_AutoDZ.Checked AndAlso IsPrint = False Then
                    If Val(Ws) < 3 Then '重量小于3
                        IsPrint = False
                        LB_Time.Text = "请放布"
                        LB_Time.ForeColor = Color.Red
                    Else
                        LB_Time.Text = "等待稳定"
                        LB_Time.ForeColor = Color.YellowGreen
                    End If
                End If
            End If
            Txt_Bz_ZL.Text = FormatN(Val(Ws.Replace("kg", "")) + Val(TB_JiaZhong.Text), 1)
        Else
            CB_WD.Checked = Ws.EndsWith("kg")
            Lt = 0
            IsPrint = False
            StartTime = Now
        End If


    End Sub


    Sub FG_ADD()
        FG_Sel_Zl(Val(Txt_Bz_ZL.Text))
        If TB_Input.ReadOnly Then
            TimerStrop.Start()
            Cmd_OK.Visible = True
        End If
    End Sub
    Dim Report As New R10010_GoodsBarcode
    Sub PrintOneTM(ByVal DoOperator As OperatorType)
        If TB_GH.Tag = "" OrElse Cmd_PrintTM.Enabled = False Then
            Exit Sub
        End If
        If Not LB_ZL.Tag = Nothing Then
            Dim Row As DataRow = dtTable.Rows(0)
            Row("CP") = LB_ZL.Text
            Row("CP_Line") = LB_ZL.Tag
            Report.PrintTime = IsNothing(Cmd_PrintTM.Tag, 1)
            Report.Start(DoOperator, Row)
        End If
    End Sub

    Private Sub SerialPort1_DataReceived(ByVal sender As System.Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles SP.DataReceived
        Static s As String = ""
        Dim ss As String = ""
        'SyncLock s
        's = s & SerialPort1.ReadExisting
        '    If s.Contains(vbCrLf) Then
        '        Dim i As Integer = s.LastIndexOf(vbCrLf)
        '        ss = s.Substring(0, i)
        '        s = s.Substring(i + 1)
        '        Me.Invoke(New DGetWeight(AddressOf GetWeight), New Object() {ss})
        '    Else
        '        Exit Sub
        '    End If
        'End SyncLock
        SyncLock s
            Try
                s = SP.ReadExisting
                If s.Length = 8 Then
                    If s.IndexOf("=") = 0 Then
                        ss = StrReverse(s)
                        ss = Val(ss.Replace("=", "").Trim)
                        Dim T As New Threading.Thread(AddressOf SendWeight)
                        T.Start(ss)
                    Else
                        Dim i As Integer
                        i = s.IndexOf("=")
                        If i > -1 Then
                            SP.ReceivedBytesThreshold = 8 + i
                        End If
                    End If
                Else
                    SP.ReceivedBytesThreshold = 8
                End If
            Catch ex As Exception
                s = ""
            End Try
        End SyncLock
    End Sub
    Dim LastKG As String = ""
    Dim LastZL As String = ""
    Dim LastT As Integer = 0

    Sub SendWeight(ByVal SS As String)
        If LastKG = SS Then
            LastT = LastT + 1
        Else
            LastKG = SS
            LastT = 0
        End If
        LastZL = IIf(LastT > 5, SS & "kg", SS)
        If StartGetData = False Then Exit Sub
        If StartGetData Then
            Me.Invoke(New DGetWeight(AddressOf GetWeight), LastZL)
        End If
    End Sub

    Private Sub Cmd_Del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Del.Click
        ' Fg1.Select(Fg1.Rows.Count - 1, 0, Fg1.Rows.Count - 1, Fg1.Cols.Count - 1, True)

        Fg1.RowSel = Fg1.Rows.Count - 1
        Fg1.Row = Fg1.Rows.Count - 1
        Btn_RemoveRow_Click(Fg1, New EventArgs)
        LB_Index.Text = Fg1.Rows.Count
        LB_ZL.Tag = Nothing
        LB_ZL.Text = ""
        LB_Time.Text = "请放布"
        If Cmd_OK.Visible = True Then
            Cmd_OK.Visible = False
            StartGetData = True
        End If
    End Sub

    Private Sub Cmd_PrintTM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_PrintTM.Click
        PrintOneTM(OperatorType.Print)
    End Sub

    Private Sub SetComplete()
        StartGetData = False
        Cmd_OK.Visible = True
        LB_Index.Text = "完成"
        LB_Time.Text = "共录入" & Fg1.Rows.Count - 1 & "条"

    End Sub

    Private Sub CB_AutoDZ_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CB_AutoDZ.CheckedChanged
        Cmd_DZ.Enabled = Not CB_AutoDZ.Checked
        If Cmd_DZ.Enabled = True Then
            Cmd_DZ.Focus()
        End If
    End Sub

    Private Sub Cmd_OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_OK.Click
        If SavePBRK() Then
            Cmd_OK.Visible = False
        End If
    End Sub

    Private Sub Cmd_Return_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Return.Click
        If isChange Then
            ShowSave()
        Else
            ShowGHInput()
        End If
    End Sub
    Private Sub Cmd_DZ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_DZ.Click
        If TB_Input.ReadOnly = False Then
            LB_Time.Text = "OK"
            LB_Time.ForeColor = Color.Blue
            LB_ZL.Text = Txt_Bz_ZL.Text
            LB_ZL.Tag = LB_Index.Text
            PrintOneTM(OperatorType.Print)
            FG_ADD()
            LB_Index.Text = Fg1.Rows.Count
        End If
    End Sub
#End Region

#Region "测试部分"

    'Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
    '    Static i As Integer
    '    Static j As Integer
    '    Static k As Integer
    '    Static l As Integer
    '    Static ZL As Double
    '    Static ZLM As Double
    '    If i = 0 OrElse i > k + l Then
    '        Randomize()
    '        j = CInt(Rnd() * 200)
    '        k = CInt(Rnd() * 200) + j
    '        l = CInt(Rnd() * 100) + 80
    '        Randomize()
    '        ZL = Math.Round((Rnd() * 40), 1) + 15
    '        ZLM = 0
    '        i = 0
    '        Me.Invoke(New DGetWeight(AddressOf GetWeight), New Object() {CStr(0)})
    '    ElseIf i < j Then
    '        Me.Invoke(New DGetWeight(AddressOf GetWeight), New Object() {CStr(0)})
    '    ElseIf i > k And i < k + l Then
    '        Randomize()
    '        Me.Invoke(New DGetWeight(AddressOf GetWeight), New Object() {CStr(ZL)})
    '    Else
    '        Randomize()
    '        ZLM = Rnd() * (ZL - ZLM) + ZLM

    '        Me.Invoke(New DGetWeight(AddressOf GetWeight), New Object() {CStr(Math.Round(ZLM))})
    '        If Math.Round(ZLM, 1) - ZL < 1 Then
    '            ZLM = ZLM - Rnd() * ZL
    '        End If
    '    End If
    '    i = i + 1
    'End Sub


    'Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    '    If Button1.Text = "开始测试" Then
    '        Button1.Text = "停止测试"
    '        Timer2.Start()
    '    Else
    '        Button1.Text = "开始测试"
    '        Timer2.Stop()
    '    End If
    'End Sub

#End Region

#Region "输入缸号"
    Dim WithEvents T As New Timer With {.Interval = 3000}
    Private Sub T_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles T.Tick
        If TB_GH_Input.Focused = False AndAlso IsShowShadow = False AndAlso PanelMain.Enabled = True Then
            TB_GH_Input.Focus()
        End If
    End Sub

    Private Sub Panel_Input_VisibleChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel_Input.VisibleChanged
        T.Enabled = Panel_Input.Visible
        If Panel_Input.Visible Then KeyMode = KeyModeType.GHInput
    End Sub

    Sub ShowGHInput()
        Cmd_OK.Visible = False
        LabelOK.Text = ""
        StartGetData = False
        PanelSave.Visible = False
        PanelDZ.Visible = False
        Panel_Input.Visible = True
        Panel_Input.BringToFront()
        TB_GH_Input.Focus()
        TB_GH_Input.SelectAll()
    End Sub



    Private Sub TB_GH_Input_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TB_GH_Input.KeyPress
        If e.KeyChar = vbCr Then
            e.KeyChar = ""
            e.Handled = True
            Get_GH(TB_GH_Input.Text)
        ElseIf e.KeyChar = "+" Then
            e.KeyChar = ""
            e.Handled = True
            Get_GH(TB_GH_Input.Text)
        ElseIf e.KeyChar = "-" Then
            e.Handled = True
            e.KeyChar = Chr(Keys.Back)
        ElseIf e.KeyChar = "*" Then
            e.Handled = True
            e.KeyChar = ""
            Cmd_Input_Exit_Click(sender, e)
        End If
    End Sub

    Private Sub Cmd_Input_OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Input_OK.Click
        Get_GH(TB_GH_Input.Text)
    End Sub


    Private Sub Cmd_Num_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click, Button9.Click, Button8.Click, Button7.Click, Button6.Click, Button5.Click, Button4.Click, Button3.Click, Button2.Click, Button11.Click, Button10.Click
        Select Case sender.text
            Case Button11.Text
                Input_Back()
            Case 0 To 9
                TB_GH_Input.AppendText(sender.text)
        End Select
        TB_GH_Input.Focus()
    End Sub

    Sub Input_Back()
        If TB_GH_Input.TextLength > 0 Then
            TB_GH_Input.Text = TB_GH_Input.Text.Substring(0, TB_GH_Input.TextLength - 1)
        End If
    End Sub


    Private Sub Cmd_Input_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Input_Exit.Click
        If F_RS_ID5 = "AutoClose" Then
            If Control.ModifierKeys = Keys.Control Then
                ShowConfirmX("是否关闭系统?                      ", "关闭(确认)", "重启(清除)", "取消", AddressOf Me.Close, AddressOf ReBoot, AddressOf DoNothing)
            Else
                ShowConfirmX("是否重启?                          ", "关机(确认)", "重启(清除)", "取消", AddressOf ShutDown, AddressOf ReBoot, AddressOf DoNothing)
            End If
        Else
            Me.Close()
        End If
    End Sub

    Sub ShutDown()
        Process.Start("shutdown", "-s -t 00")
        Me.Close()
    End Sub

    Sub ReBoot()
        Process.Start("shutdown", "-r -t 00")
        Me.Close()
    End Sub
#End Region




#Region "保存Panel"
    Sub ShowSave()
        StartGetData = False
        PanelDZ.Visible = False
        Panel_Input.Visible = False
        PanelSave.Visible = True
        PanelSave.BringToFront()
        Cmd_Save.Focus()
    End Sub

    Private Sub Cmd_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Save.Click
        SavePBRK()
    End Sub
    Private Sub Cmd_NoSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_NoSave.Click
        ShowGHInput()
    End Sub

    Private Sub Cmd_Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Cancel.Click
        ShowDZ()
        isChange = True
    End Sub
#End Region




#Region "Com口设置"

    Private Sub LabelCom_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LabelCom.DoubleClick
        Me.ShowInput("请输入com口:", AddressOf WComYes, ComX, "调整Com设置")
    End Sub

    Sub WComYes(ByVal s As String)
        If s.Contains("com") Then
            s = s.Replace("com", "")
        End If
        If Val(s) > 0 Then
            ComX = "com" & s
            My.Settings.ComX = ComX
            My.Settings.Save()
            SetRate()
            Me.ShowInput("请输入com口的频率:", AddressOf WBaudRateYes, BaudRate, "调整Com设置")
        Else
            ShowErrMsgX("请输入的com口不正确")
        End If
    End Sub

    Sub WBaudRateYes(ByVal s As String)
        If Val(s) > 0 Then
            BaudRate = Val(s)
            My.Settings.BaudRate = BaudRate
            My.Settings.Save()
            SetRate()
        Else
            ShowErrMsg("请输入com口的频率不正确")
        End If
    End Sub

    Sub SetRate()
        LabelCom.Text = ComX & ":" & BaudRate
    End Sub
#End Region

#Region "声音"
    Public S_Code As String
    Public SoundCode As New System.Threading.Thread(AddressOf PlayStr)
    Public Sub PlayStr()

        On Error Resume Next
        Dim i As Short
        Dim S() As String
        Dim T() As String
        S = Split(S_Code, vbCrLf)
        For i = 0 To UBound(S)
            T = Split(S(i), ",")
            If CInt(T(0)) <= 37 Then
                Threading.Thread.Sleep(CInt(T(1)))
            Else
                System.Console.Beep(CInt(T(0)), CInt(T(1)))
            End If
        Next
    End Sub

    Public Sub PlayP()
        SoundCode.Abort()
        S_Code = "2965,200" & vbCrLf & "1100,100"
        SoundCode = New System.Threading.Thread(AddressOf PlayStr)
        SoundCode.Start()
    End Sub
    Public Sub PlayPP()
        SoundCode.Abort()
        S_Code = "4000,200" & vbCrLf & "1100,50" & vbCrLf & "4000,200"

        SoundCode = New System.Threading.Thread(AddressOf PlayStr)
        SoundCode.Start()
    End Sub

#End Region


    Private Sub Txt_Bz_ZL_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Bz_ZL.KeyPress
        If e.KeyChar = vbCr AndAlso Txt_Bz_ZL.ReadOnly = False Then
            GetWeight(Txt_Bz_ZL.Text & "kg", True)
        End If
    End Sub

    Private Sub TimerStrop_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerStrop.Tick
        TimerStrop.Stop()
        StartGetData = False
    End Sub


    Private Sub PanelDZ_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles PanelDZ.VisibleChanged
        If PanelDZ.Visible Then KeyMode = KeyModeType.KGInput
    End Sub
 
    Private Sub PanelSave_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles PanelSave.VisibleChanged
        If PanelSave.Visible Then KeyMode = KeyModeType.SaveCheck
    End Sub

    Private Sub Panel_CP_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Panel_CP.VisibleChanged
        If Panel_CP.Visible Then KeyMode = KeyModeType.GHSelect
    End Sub


End Class
