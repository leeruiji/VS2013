Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports PClass
Imports BaseClass
Imports PClass.CReport

Public Class F30201_CPZL_Msg

    Dim dtList As DataTable
    Dim cp_Gh As String = ""

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
        ID = 30200
        Control_CheckRight(ID, ClassMain.Modify, Cmd_Modify)

    End Sub

    Private Sub F30201_CPZL_Msg_AfterLoad() Handles Me.AfterLoad

    End Sub

    Private Sub Form_Msg_Load() Handles Me.Me_Load
        FormCheckRight()
        Ch_Name = GetBillTypeName(ID)
        'Dao.Balance_DB_NAME = Ch_Name
        Me.Title = Ch_Name

        Fg1.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never
        Fg1.Rows.Count = 1
        Fg2.Rows.Count = 1

        Fg1.IniFormat()
        Fg3.IniFormat()
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
            TB_ZhiDan.Text = IsNull(Dr("ZhiDan"), "")
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


        If Val(TB_PWeight.Text) = 0 Then
            TB_SH.Text = "0"
        Else
            If SplitContainer1.Panel1Collapsed Then
                TB_SH.Text = Format(1 - (CP - (JZ * Val(TB_SumQty.Text))) / Val(TB_PWeight.Text), "0.00%")
                TB_SumZL.Text = FormatZL(CP)
            Else
                TB_SH.Text = Format(1 - (SumZl - (JZ * Val(TB_SumQty.Text))) / Val(TB_PWeight.Text), "0.00%")
                TB_SumZL.Text = FormatZL(SumZl)
            End If
        End If



        If Val(TB_RemainQty.Text) = 0 Then
            TB_Input.ReadOnly = True
        Else
            TB_Input.ReadOnly = Not Cmd_Modify.Visible
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
            ShowConfirm(S, "保存并打印", "保存不打印", "取消", AddressOf SaveAndPrint, AddressOf SavePBRK, AddressOf DoNothing)
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
    Protected Sub SavePBRK()
        Dim R As MsgReturn
        Dim Dt As DataTable = GetList()
        R = Dao.CPZL_Save(TB_GH.Tag, cp_Gh, DTP_Date.Value, Dt, Val(TB_RemainQty.Text) <= 0)
        If R.IsOk Then
            IsChange = False
            LastForm.ReturnId = TB_GH.Text
            If isPrint Then
                Print(OperatorType.Preview)
            Else
                ShowOk(R.Msg, True)
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
                sErr.AppendLine("已经被成检,系统自动删除这几条布!")
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
        If Fg1.Rows.Count <= 1 Then
            ShowErrMsg("成品列表不能为空!")
            Return False
        End If

        If Fg1.Rows.Count - 1 > Val(TB_CR_LuoSeBzCount.Text) Then
            ShowErrMsg("成品条数不能大于落色条数!")
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
        If i > 0 AndAlso Fg1.Rows.Count > 1 Then
            Fg1.RemoveRow()
            CaculateSumAmount()

        End If

    End Sub
#End Region

#Region "报表事件"

    Private Sub Cmd_Preview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Preview.Click
        If Fg3.RowSel > 0 Then
            Print_CP_GH = Fg3.Item(Fg3.RowSel, "CP_GH")
        Else
            Exit Sub
        End If
        Print(OperatorType.Preview)
    End Sub

    Private Sub Cmd_Print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Print.Click
        If Fg3.RowSel > 0 Then
            Print_CP_GH = Fg3.Item(Fg3.RowSel, "CP_GH")
        Else
            Exit Sub
        End If
        Print(OperatorType.Print)
    End Sub



    Private Sub Btn_Preview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Preview.Click
        If Fg2.RowSel <= 0 Then
            Exit Sub
        End If
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

    Private Sub Cmd_DsPreViewTM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_DsPreViewTM.Click
        If cp_Gh = "" Then
            Print_CP_GH = Fg2.Item(Fg2.RowSel, "CP_GH")
        Else
            Print_CP_GH = cp_Gh
        End If
        PrintTM(OperatorType.Preview, True)
    End Sub
    Dim R As New R10010_GoodsBarcode
    Protected Sub PrintTM(ByVal DoOperator As OperatorType, Optional ByVal isDx As Boolean = False)
        If Me.Mode = Mode_Enum.Add Then
            Exit Sub
        End If
        If TB_GH.Tag = "" Then
            Exit Sub
        End If

        R.Start(TB_GH.Tag, Print_CP_GH, DoOperator)
    End Sub



#End Region

#Region "选缸号"


    Private Sub TB_GH_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TB_GH.KeyPress
        If e.KeyChar = vbCr Then
            Get_GH(TB_GH.Text)
        End If
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

        cp_Gh = ""
        id = ComFun.FixGH(id)
        Dim Mr As MsgReturn = ComFun.GetGHForTM(id)
        If Mr.IsOk = False Then
            ShowErrMsg(Mr.Msg)
            Exit Sub
        End If
        id = Mr.Msg
        Fg1.Rows.Count = 1
        Dim R As DtReturnMsg = Dao.CPZL_GetGH_ByID(id)
        If R.IsOk = False Then
            ShowErrMsg("查询缸号失败!", AddressOf TB_GH.Focus)
            Exit Sub
        End If
        If R.Dt.Rows.Count = 0 Then
            ShowErrMsg("缸号[" & id & "不存在]!", AddressOf TB_GH.Focus)
            Exit Sub
        End If
        Dim Dr As DataRow = R.Dt.Rows(0)
        Cmd_PreViewTM.Visible = False
        Cmd_DsPreViewTM.Visible = False
        If IsNull(Dr("IsTP"), False) Then
            ShowErrMsg("缸号[" & id & "]是退胚缸不能成检!", AddressOf TB_GH.Focus)
            Exit Sub
        End If


        If IsNull(Dr("State"), 0) > Enum_ProduceState.RanSe AndAlso IsNull(Dr("State"), 0) < Enum_ProduceState.ChengJian Then
            If IsNull(Dr("CR_LuoSeBzCount"), 0) <> IsNull(Dr("PB_CountSum"), 0) Then
                ShowErrMsg("缸号[" & id & "]胚布条数和落色条数不一致,不能录入成品重量!", AddressOf TB_GH.Focus)
                SetReadOnly(False)
            Else
                SetReadOnly(True)
                TB_Input.Focus()
            End If
            Btn_Preview.Enabled = False
            Btn_Print.Enabled = False
        Else
            'ShowErrMsg("缸号[" & ID & "]当前状态不能录入成品重量!", AddressOf TB_GH.Focus)
            Btn_Preview.Enabled = True
            Btn_Print.Enabled = True
            SetReadOnly(False)
            If IsNull(Dr("Client_Name"), "") = "毅泰" Then
                Cmd_PreViewTM.Visible = True
                Cmd_DsPreViewTM.Visible = False
            ElseIf IsNull(Dr("Client_Name"), "") = "大新" Then
                Cmd_PreViewTM.Visible = False
                Cmd_DsPreViewTM.Visible = True
            End If
        End If
        If IsNull(Dr("State"), 0) = Enum_ProduceState.ChengJian Then
            Cmd_CancelCJ.Visible = True
        Else
            Cmd_CancelCJ.Visible = False
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
        If IsNull(Dr("CR_LuoSeType"), 0) = 0 Then
            TB_CR_LuoSeBzZL.Visible = False
            Label_CR_LuoSeBzZL.Visible = False
        Else
            TB_CR_LuoSeBzZL.Visible = True
            Label_CR_LuoSeBzZL.Visible = True
        End If


        TB_GH.Text = IsNull(Dr("GH"), "")
        TB_ZhiDan.Text = IsNull(Dr("KaiDan"), "")

        TB_BZ_No.Text = IsNull(Dr("BZ_No"), "")
        TB_BZ_No.Tag = IsNull(Dr("BZ_Id"), 0)
        TB_BZ_Name.Text = IsNull(Dr("BZ_Name"), "")
        TB_CPName.Text = IsNull(Dr("CPName"), "")
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
        Dim RDt As DtReturnMsg = Dao.PBRK_GetListByGH(TB_GH.Text)

        If RDt.IsOk Then
            dtList = RDt.Dt
            If dtList.Select("old_PB>0").Length > 0 Then
                Fg2.Cols("Old_PB").Visible = True
            Else
                Fg2.Cols("Old_PB").Visible = False
            End If
            For Each oDR As DataRow In dtList.Rows
                If IsNull(oDR("old_PB"), 0) = 0 Then
                    oDR("old_PB") = oDR("PB")
                End If


            Next
            Fg2.DtToSetFG(dtList)
          
            Fg2.IniColsSize()
            Fg2.FG_ColResize()
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
            IsChange = False
            CaculateSumAmount()
            LB_CP_GH.Text = ""
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
            End If
        End If
    End Sub

    Sub ShowCPGH()
        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Timer1.Stop()
        CaptureFromImageToPicture(Me, Panel_CP)
        Panel_CP.BringToFront()
        Group_CP.Left = Panel_CP.Width / 2 - Group_CP.Width / 2
        Group_CP.Top = Panel_CP.Height / 2 - Group_CP.Height / 2
        Group_CP.Visible = True
        Group_CP.BringToFront()
        Panel_CP.Visible = True
        PanelMain.Enabled = False
    End Sub
    Sub HideCPGH()
        Panel_CP.Visible = False
        Panel_CP.SendToBack()
        PanelMain.Enabled = True
        CaculateSumAmount()
        TB_Input.Focus()
    End Sub



    Private Sub Cmd_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Add.Click
        Dim S As String = Fg3.Item(Fg3.Rows.Count - 1, "CP_GH")
        S = "#" & Val(S.Replace("#", "")) + 1
        cp_Gh = S
        LB_CP_GH.Text = cp_Gh
        LoadCPFormFG()
        HideCPGH()
    End Sub

    Private Sub Cmd_Edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Edit.Click
        If Fg3.RowSel > 0 Then
            Dim S As String = Fg3.Item(Fg3.RowSel, "CP_GH")
            cp_Gh = S
            LB_CP_GH.Text = cp_Gh
            LoadCPFormFG()
            HideCPGH()
        Else
            ShowErrMsg("请选择一行")
        End If
    End Sub


    Sub LoadCPFormFG()
        IsChange = False
        Fg1.Rows.Count = 1
        Dim Dt As DataTable = DtRunSQLtoDt(dtList, "CP_GH='" & cp_Gh & "'", "CP_GH,CP_Line")
        Fg1.DtToSetFG(Dt)
        If Dt.Select("old_PB>0").Length > 0 Then
            Fg2.Cols("Old_PB").Visible = True
        Else
            Fg2.Cols("Old_PB").Visible = False
        End If
        Fg2.IniColsSize()
        Fg2.FG_ColResize()
    End Sub
    Private Sub Fg3_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fg3.DoubleClick
        If Fg3.RowSel > 0 Then
            Cmd_Edit_Click(Fg3, New System.EventArgs)
        End If
    End Sub

    Private Sub Cmd_Close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Close.Click
        Me.Close()
    End Sub

    Private Sub Btn_Refresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Refresh.Click
        GetCPGH()
    End Sub
#End Region

#Region "自动匹配重量"


    Private Sub TB_Input_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TB_Input.KeyPress
        If Val(TB_Input.Text) > MaxZL Then
            ShowErrMsg("成品重量不能大于" & MaxZL, AddressOf TB_Input.Focus)
        ElseIf e.KeyChar = vbCr AndAlso TB_Input.ReadOnly = False Then
            FG_Sel_Zl(Val(TB_Input.Text))
        End If
    End Sub
    Dim IsChange As Boolean = False
    Sub FG_Sel_Zl(ByVal ZL As Double)
        IsChange = True
        If ZL <= 0 Then
            ShowErrMsg("请选择一个正确的重量", AddressOf TB_Input.Focus)
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

    End Sub
#End Region













    Private Sub Fg1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fg1.DoubleClick
        Btn_RemoveRow_Click(sender, e)
    End Sub

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









    Private Sub Cmd_CancelCJ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_CancelCJ.Click
        ShowConfirm("是否取消成检?", AddressOf CancelPB)
    End Sub
    Sub CancelPB()
        Dim R As MsgReturn = Dao.CPZL_Cancel(Bill_ID)
        If R.IsOk Then
            ShowOk(R.Msg)
        Else
            ShowErrMsg(R.Msg)
        End If
        TB_GH.Text = Bill_ID
        Get_GH(Bill_ID)
    End Sub

    Private Sub Fg2_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fg2.DoubleClick
        If Fg2.RowSel <= 0 Then Exit Sub
        If IsChange Then
            ShowErrMsg("修改重量之前,请先保存当前的修改!")
            Exit Sub
        End If
        If Fg2.Item(Fg2.RowSel, "Old_PB") = 0 Then
            ShowInput("是否把原配布重量[" & Fg2.Item(Fg2.RowSel, "PB") & "]改为:", AddressOf ChangeCP, Fg2.Item(Fg2.RowSel, "PB").ToString)
        Else
            ShowInput("是否把原配布重量[" & Fg2.Item(Fg2.RowSel, "Old_PB") & "]改为:", AddressOf ChangeCP, Fg2.Item(Fg2.RowSel, "PB").ToString)
        End If
    End Sub


    Private MinZL As Double = Val(FormatSharp("MinZL"))
    Private MaxZL As Double = Val(FormatSharp("MaxZL"))

    Sub ChangeCP(ByVal S As String)
        Dim D As Double = Val(S)
        If D <> 0 Then
            If D > MaxZL Then
                ShowErrMsg("配布重量不能大于" & MaxZL & "!  ")
                Exit Sub
            End If
            If D < MinZL Then
                ShowErrMsg("配布重量不能小于" & MinZL & "!  ")
                Exit Sub
            End If
        End If
        Dim P As New Dictionary(Of String, Object)
        P.Add("@GH", TB_GH.Tag)
        P.Add("@Line", Fg2.Item(Fg2.RowSel, "Line"))
        P.Add("@NewPB", D)
        Dim R As MsgReturn = RunSQL("P30200_Change_PB", P, True)
        Get_GH(TB_GH.Tag)
    End Sub

   
End Class

Partial Class Dao

    ''' <summary>
    ''' 取消成检
    ''' </summary>
    ''' <param name="GH"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CPZL_Cancel(ByVal GH As String) As MsgReturn
        Dim R As New MsgReturn
        Dim S As New Dictionary(Of String, String)
        Dim P As New Dictionary(Of String, Object)
        S.Add("G", "Select top 1 GH,State,UPD_User,UPD_Date from T30000_Produce_Gd where GH=@GH")
        P.Add("GH", GH)
        Using H As New DtHelper(S, P)
            If H.IsOk = True Then
                If H.DtList("G").Rows.Count > 0 Then
                    If H.DtList("G").Rows(0)("State") = Enum_ProduceState.ChengJian Then
                        H.DtList("G").Rows(0)("State") = Enum_ProduceState.ChengJianZhong
                        H.DtList("G").Rows(0)("UPD_User") = User_Name
                        H.DtList("G").Rows(0)("UPD_Date") = GetTime()
                        If H.UpdateAll(True).IsOk Then
                            R.IsOk = True
                            R.Msg = "取消成检成功!"
                        Else
                            R.IsOk = False
                            R.Msg = "取消成检失败," & H.Msg
                        End If
                    Else
                        R.IsOk = False
                        R.Msg = "取消成检失败,缸号[" & GH & "]当前状态是[" & ComFun.GetProduceStateName(H.DtList("G").Rows(0)("State")) & "],不能取消成检!"
                    End If
                Else
                    R.IsOk = False
                    R.Msg = "取消成检失败,缸号[" & GH & "]不存在!"
                End If
            Else
                R.IsOk = False
                R.Msg = "取消成检失败," & R.Msg
            End If
        End Using
        Return R
    End Function
End Class