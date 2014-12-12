Option Compare Text
Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports PClass
Imports BaseClass
Imports PClass.CReport

Public Delegate Sub gg(ByVal tt As String)
Public Class F40201_SCPB_Msg
    Dim dtList As DataTable
    Dim dtTable As DataTable
    Dim DtChePai As DataTable
    Dim State As Integer = 0
    Dim InserSQL As StringBuilder
    Dim dtStore As DataTable
    Dim T As New DataTable
    Dim StoreNoList As New List(Of String)

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
        ID = 40200
        Control_CheckRight(ID, ClassMain.Modify, Cmd_Modify)
        Control_CheckRight(ID, ClassMain.CancelPB, Cmd_CancelPB)
    End Sub

    Private Sub Me_AfterLoad() Handles Me.AfterLoad

        SumFg3.AddSum()
    End Sub


    Dim RDT As DataTable
    Dim RN As String
    Private Sub Form_Msg_Load() Handles Me.Me_Load
        FormCheckRight()
        Ch_Name = GetBillTypeName(ID)
        'Dao.Balance_DB_NAME = Ch_Name
        Me.Title = Ch_Name

        Fg1.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Always
        Fg1.Rows.Count = 1
        Fg2.Rows.Count = 1
        SelStyle()
        Fg1.IniFormat()
        DTP_Date.Value = GetTime.AddHours(-8).Date
        TB_Client_No.Tag = "0"
        Dim msStore As DtReturnMsg = Dao.SCPB_GetStoreNo_ByID(0)
        If msStore.IsOk Then
            dtStore = msStore.Dt
            T = dtStore.Clone
            Fg3.DtToFG(dtStore)
        End If
        RN = P_F_RS_ID
        If RN = "" Then
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
        Else
            Bill_ID = P_F_RS_ID2
            RDT = P_F_RS_Obj
            CancelPB(RN)
        End If

        'CB_ChePai.DataSource = Emplyee.GetAllEmployee.Copy

    End Sub



#Region "表单信息"

    ''' <summary>
    ''' 获取表单内容
    ''' </summary>
    ''' <remarks></remarks>
    Protected Function GetList() As DataTable
        Dim dt As New DataTable("T")
        dt.Columns.Add("ID")
        dt.Columns.Add("Line", GetType(Integer))
        dt.Columns.Add("PB", GetType(Double))
        dt.Columns.Add("ZL", GetType(Double))
        dt.Columns.Add("GH")

        If Not dt Is Nothing AndAlso Not TB_GH.Text = "" Then
            dt.Clear()
            For i As Integer = 1 To Fg2.Rows.Count - 1
                Dim dr As DataRow = dt.NewRow
                dr("ID") = Fg2.Item(i, "ID")
                dr("Line") = Fg2.Item(i, "Line")
                dr("ZL") = Fg2.Item(i, "ZL")
                dr("PB") = Fg2.Item(i, "PB")
                dr("GH") = TB_GH.Text
                dt.Rows.Add(dr)
            Next
        End If

        InserSQL = New StringBuilder
        InserSQL.AppendLine(" delete from T40521_PB_Detail where BillType=40200 and GH='" & TB_GH.Text & "' ")
        For I As Integer = 0 To dtStore.Rows.Count - 1
            If Val(dtStore.Rows(I)("OQty")) <> 0 Then
                InserSQL.AppendLine(" INSERT INTO T40521_PB_Detail(BillType,ID,StoreNo,GH,BillName,InQty,sDate)VALUES (40200, '" & dtStore.Rows(I)("ID") & "' , '" & dtStore.Rows(I)("StoreNo") & "' , '" & TB_GH.Text & "' , '生产配布单' ," & -dtStore.Rows(I)("OQty") & ", '" & GetTime() & "' )")
            End If
        Next


        Return dt
    End Function

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
        Dim RKZL As Double = 0
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
                RKZL = RKZL + Val(Fg2.Item(R, "ZL"))
            End If
        Next
        TB_YPQty.Text = FormatNum(SumQty)
        TB_YPZL.Text = FormatZL(SumPWeight)
        TB_XPQty.Text = FormatNum(Val(TB_CR_LuoSeBzCount.Text) - SumQty)
        TB_RKZL.Text = FormatZL(RKZL)
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
        TB_GH.Focus()
        If CheckForm() Then
            Dim D As Date = GetTime.AddHours(-8).Date
            If DTP_Date.Value.Date <> D Then
                ShowConfirm("你选择的配布日期是[" & DTP_Date.Value.Date.ToString("yyyy-MM-dd") & "]和当前日期[" & D.Date.ToString("yyyy-MM-dd") & "]不相同,是否继续保存" & Ch_Name & "?", "继续保存", "改为当天", "取消", AddressOf SaveConfirm, AddressOf SaveConfirmAsDate, AddressOf Me.NoSave)
            Else
                SaveConfirm()
            End If
        End If
    End Sub

    Sub NoSave()

    End Sub

    Sub SaveConfirmAsDate()
        DTP_Date.Value = GetTime.AddHours(-8).Date
        SaveConfirm()
    End Sub

    Sub SaveConfirm()
        If TB_CR_LuoSeBzZL.Visible = True Then
            If Math.Abs(Val(TB_YPZL.Text) - Val(TB_CR_LuoSeBzZL.Text)) > 20 Then
                ShowConfirm("配布重量小于落色重量,是否保存本" & Ch_Name & "?", AddressOf SaveSCPB)
            Else
                ShowConfirm("是否保存" & Ch_Name & "[" & TB_GH.Text & "] 的修改?", AddressOf SaveSCPB)
            End If
        Else
            If Val(TB_CR_LuoSeBzCount.Text) = Fg2.Rows.Count - 1 Then
                ShowConfirm("是否保存" & Ch_Name & "[" & TB_GH.Text & "] 的修改?", AddressOf SaveSCPB)
            Else
                ShowConfirm("配布条数小于落色条数,是否保存本" & Ch_Name & "?", AddressOf SaveSCPB)
            End If
        End If
    End Sub

    ''' <summary>
    ''' 保存修改
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub SaveSCPB()
        Dim R As MsgReturn
        Dim Dt As DataTable = GetList()
        R = Dao.SCPB_Save(TB_GH.Tag, DTP_Date.Value, Dt, InserSQL.ToString, TB_CR_LuoSeBzZL.Visible = False Or (Math.Abs(Val(TB_YPZL.Text) - Val(TB_CR_LuoSeBzZL.Text)) <= 20))

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
                ShowErrMsg(sErr.ToString)
                If TB_GH.Text <> "" Then Get_GH(TB_GH.Text)
            Else
                'ShowErrMsg(R.Msg.Substring(1))
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


        For i As Integer = 1 To Fg3.Rows.Count - 1
            If IsNull(Fg3.Item(i, "StoreNo"), "") = "" Then
                Fg3.RemoveItem(i)
            End If
        Next
        If Fg3.Rows.Count <= 1 Then
            ShowErrMsg("仓位信息为空时不能配布。")
            Return False
        End If

        Dim PBCHeck As String = GetPBQty()
        If PBCHeck <> "" Then
            ShowErrMsg(PBCHeck)
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

        For m As Integer = Fg2.Selection.BottomRow To Fg2.Selection.TopRow Step -1
            'Dim i As Integer = Fg2.RowSel
            Dim i As Integer = m
            If i > 0 AndAlso Fg2.Rows.Count > 1 Then
                Try
                    For j As Integer = 1 To Fg1.Rows.Count - 1
                        Dim k As Integer = Fg2.Rows.Count
                        If Fg1.Item(j, "Line") = Fg2.Item(i, "Line") Then
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
        Next
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
            GetPBRK(sender, e)
        End If

    End Sub

    Private Sub GetPBRK(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        
        Dim f As Boolean = FG_Get_PBRK(sender.Text)

        If ToolStrip_StoreNo_Old.Items.ContainsKey(sender.TEXT) = False AndAlso f = True Then
            Dim msg As DtReturnMsg = Dao.SCPB_GetStoreNo_ByID(sender.TEXT)
            If msg.IsOk Then
                dtStore.Merge(msg.Dt)
                Fg3.ReAddIndex()
            End If
            Dim Button As New ToolStripButton
            Button.Name = sender.text
            Button.Text = sender.text
            Button.ForeColor = Color.Blue
            Button.CheckOnClick = True
            AddHandler Button.Click, AddressOf SelStore_ByStroeNo
            AddHandler Button.MouseUp, AddressOf DeleteBill
            ToolStrip_StoreNo_Old.Items.Add(Button)

        End If

        SelStore_ByStroeNo(sender, e)
        SumFg3.ReSum()
    End Sub


    Private Sub SelStore_ByStroeNo(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'UpDateTable(T, dtStore)
        TB_GH.Focus()

        For Each B As ToolStripButton In ToolStrip_StoreNo_Old.Items
            If B.Name <> sender.text Then
                B.Checked = False
            Else
                B.Checked = True
            End If
        Next
        Dim dr() As DataRow = dtStore.Select("ID='" & sender.text & "'")
        T.Clear()
        For Each drs As DataRow In dr
            T.ImportRow(drs)
        Next
        Fg3.DtToFG(T)
        Fg3.ReAddIndex()
        SumFg3.ReSum()
        If sender.name = TB_PBRK_ID.Name Then
        Else

            FG_Get_PBRK(sender.Text)
        End If

    End Sub


    Dim B As ToolStripButton
    Private Sub DeleteBill(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)

        If e.Button = Windows.Forms.MouseButtons.Right Then
            B = DirectCast(sender, ToolStripButton)
            ShowConfirm("是否删除入库单［" & sender.text & "］", AddressOf Delete)
        End If

    End Sub

    Private Sub Delete()
        Dim R() As DataRow = dtStore.Select("ID='" & B.Name & "'")
        For Each DR As DataRow In R
            dtStore.Rows.Remove(DR)
        Next
        Fg3.DtToFG(dtStore)
        Cmd_ShowAll.Checked = True
        ToolStrip_StoreNo_Old.Items.Remove(B)
        Fg3.ReAddIndex()
        SumFg3.ReSum()

        For i As Integer = Fg1.Rows.Count - 1 To 1 Step -1
            Fg1.Rows.Remove(i)
        Next


        For i As Integer = Fg2.Rows.Count - 1 To 1 Step -1
            If Fg2.Item(i, "ID") = B.Name Then
                Fg2.Rows.Remove(i)
            End If
        Next

        Fg2.ReAddIndex()
        CaculateSumAmount()

        If Val(Fg2.Rows.Count - 1) < Val(TB_CR_LuoSeBzCount.Text) Then
            TB_PBRK_ID.ReadOnly = False
        End If



    End Sub



    Public IsWNGH As Boolean = False
    Function FG_Get_PBRK(ByVal ID As String) As Boolean
        Dim R As DtReturnMsg = Dao.SCPB_GetPBRK_Table_ByID(ID)
        If R.IsOk = False Then
            ShowErrMsg("查询入库单失败!", AddressOf TB_PBRK_ID.Focus)
            Return False
        End If
        If R.Dt.Rows.Count = 0 Then
            ShowErrMsg("入库单[" & ID & "不存在]!", AddressOf TB_PBRK_ID.Focus)
            Return False
        End If
        Dim Dr As DataRow = R.Dt.Rows(0)
        Select Case IsNull(Dr("State"), 0)
            Case Enum_BZSHState.AddNew
                ShowErrMsg("入库单[" & ID & "没有审核不能配布]!", AddressOf TB_PBRK_ID.Focus)
                Return False
                'Case Enum_PBRK.XiaoZhang
                '    ShowErrMsg("入库单[" & ID & "已经销账不能配布]!", AddressOf TB_PBRK_ID.Focus)
                '    Return False
            Case Enum_BZSHState.Store_Comfirm

            Case Enum_BZSHState.Audited

            Case Else
                ShowErrMsg("入库单[" & ID & "状态错误不能配布]!", AddressOf TB_PBRK_ID.Focus)
                Return False
        End Select
        If IsNull(Dr("Client_ID"), "") <> TB_Client_No.Tag AndAlso IsWNGH = False Then
            ShowErrMsg("入库单[" & ID & "]不属于客户[" & TB_Client_Name.Text & "]的布,不能配布!", AddressOf TB_PBRK_ID.Focus)
            Return False
        End If




        '赋值
        TB_ShaPi.Text = IsNull(Dr("ShaPi"), "")
        TB_Remark.Text = IsNull(Dr("Remark"), "")
        TB_RK_BZ_No.Text = IsNull(Dr("BZ_No"), "")
        TB_RK_BZ_Name.Text = IsNull(Dr("BZ_Name"), "")
        TB_Remark.Text = IsNull(Dr("Remark"), "")
        TB_Notice.Text = IsNull(Dr("Notice"), "")
        DTR_PBRK_Date.Value = IsNull(Dr("sDate"), "1999-1-1")

        TB_Input.Tag = Dr("ID")
        Dim RL As DtReturnMsg = Dao.PBRK_SetListById(Dr("ID"))

        If RL.IsOk = False Then
            ShowErrMsg("查询入库单失败!", AddressOf TB_PBRK_ID.Focus)
            Return False
        End If

        Fg1.DtToSetFG(RL.Dt)
        dtList = RL.Dt
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
                    Dim line As Integer = Fg1.Item(i, "Line")
                    If Fg2.Item(j, "Line") = line Then
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
        If IsNull(Dr("BZ_No"), "") <> TB_BZ_No.Text AndAlso IsWNGH = False Then
            ShowMsg("入库单[" & ID & "]布类编号[" & IsNull(Dr("BZ_No"), "") & "]" & vbCrLf & "本缸号的布类编号[" & TB_BZ_No.Text & "]不一致,请细心核对!", Me.Title, AddressOf TB_Input.Focus, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Fg1.IniColsSize()


        Return True

    End Function
#End Region

#Region "选缸号"


    Private Sub TB_GH_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TB_GH.KeyPress
        If e.KeyChar = vbCr Then
            Get_GH(TB_GH.Text)
        End If
    End Sub

    Dim IsShowErr As Boolean = False
    Sub Get_GH(ByVal ID As String)
        Dim lOCK As Boolean = False
        ID = ComFun.FixGH(ID)
        Dim Mr As MsgReturn = ComFun.GetGHForTM(ID)
        If Mr.IsOk = False Then
            ShowErrMsg(Mr.Msg)
            Exit Sub
        End If
        ID = Mr.Msg
        Dim R As DtReturnMsg = Dao.SCPB_GetGH_ByID(ID)
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
        If R.Dt.Rows(0)("GH") = Dao.WNGH Then
            If CheckRight(Me.ID, ClassMain.CanUseWNGH) = False Then
                ShowErrMsg("你没有权限使用万能缸号!", AddressOf TB_GH.Focus)
                Exit Sub
            End If
            IsWNGH = True
            Cmd_Modify.Visible = Cmd_Modify.Tag
            TB_PBRK_ID.ReadOnly = False
            TB_Input.ReadOnly = False
            Btn_RemoveRow.Enabled = True
            Cmd_AddAll.Enabled = True
            Cmd_ClearPB.Enabled = True
        Else
            IsWNGH = False
            Select Case IsNull(Dr("State"), 0)
                Case Enum_ProduceState.XiaDan
                    Cmd_Modify.Visible = Cmd_Modify.Tag
                    TB_PBRK_ID.ReadOnly = False
                    TB_Input.ReadOnly = False
                    Cmd_AddAll.Enabled = False
                    Btn_RemoveRow.Enabled = True
                    Cmd_ClearPB.Enabled = True
                    Fg3.CanEditing = True
                    Fg3.IsClickStartEdit = True
                    lOCK = False
                Case Enum_ProduceState.PeiBu

                    Cmd_CancelPB.Visible = True
                    Cmd_Modify.Visible = False
                    TB_Input.ReadOnly = True
                    Cmd_AddAll.Enabled = False
                    TB_PBRK_ID.ReadOnly = True
                    Btn_RemoveRow.Enabled = False
                    Cmd_AddAll.Enabled = False
                    Cmd_ClearPB.Enabled = False
                    Fg3.CanEditing = False
                    Fg3.IsClickStartEdit = False
                    lOCK = True


                Case Enum_ProduceState.AddNew
                    Btn_RemoveRow.Enabled = False
                    Cmd_AddAll.Enabled = False
                    Cmd_ClearPB.Enabled = False
                    lOCK = False
                    ShowErrMsg("缸号[" & ID & "]没有下单不能配布!", AddressOf TB_PBRK_ID.Focus)
                    Exit Sub
                Case Else

                    If IsShowErr = False Then
                        ShowErrMsg("缸号[" & ID & "]不是待配布状态不能配布!", AddressOf TB_PBRK_ID.Focus)
                    End If
                    Cmd_ClearPB.Enabled = False
                    Cmd_Modify.Visible = False
                    TB_Input.ReadOnly = True
                    TB_PBRK_ID.ReadOnly = True
                    Btn_RemoveRow.Enabled = False
                    Cmd_AddAll.Enabled = False
                    lOCK = True
            End Select
        End If
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
        If Mode <> Mode_Enum.Add AndAlso IsDBNull(Dr("Date_PeiBu")) = False Then
            DTP_Date.Value = Dr("Date_PeiBu")
        End If

        LB_State.Text = ComFun.GetProduceStateName(IsNull(Dr("State"), 0))

        If IsNull(Dr("IsFD"), False) Then '返定
            LabelFDFG.Text = "返定"
            LabelFDFG.Visible = True
        Else
            If IsNull(Dr("IsFG"), False) Then
                LabelFDFG.Text = "返工"
                LabelFDFG.Visible = True
            Else
                If IsNull(Dr("IsTP"), False) Then
                    LabelFDFG.Text = "退胚"
                    LabelFDFG.Visible = True
                Else
                    LabelFDFG.Text = ""
                    LabelFDFG.Visible = False
                End If
            End If

        End If

        If IsWNGH Then
            Fg2.Rows.Count = 1
        Else
            Dim RDt As DtReturnMsg = Dao.PBRK_GetListByGH(TB_GH.Text)
            If RDt.IsOk Then
                Fg2.DtToSetFG(RDt.Dt)
            End If
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

        If TB_Input.Tag IsNot Nothing Then
            TB_PBRK_ID.Text = TB_Input.Tag
            FG_Get_PBRK(TB_Input.Tag)
        End If

        If IsWNGH Then
            ShowConfirm("本缸号为万能缸号,用过度回收旧布,是否只插入布种不修改之前布?(建议选择是)", AddressOf WHGH_Insert, AddressOf WHGH_Edit)
        Else
            Dao.IsInsert = False
        End If
        GetPBStore(TB_GH.Text, lOCK)
    End Sub

    Private Sub GetPBStore(ByVal GH As String, ByVal LOCK As Boolean)
        Dim L As New List(Of String)
        If LOCK = False Then
            L.Add("InQty")
            L.Add("OQty")
            L.Add("Qty")

        Else
            L.Add("OQty")
            Dim dtPB As DtReturnMsg = Dao.SCPB_GetStore_ByGH(TB_GH.Text)
            If dtPB.IsOk AndAlso dtPB.Dt.Rows.Count > 0 Then
                dtStore = dtPB.Dt
                Fg3.DtToFG(dtStore)
            End If
        End If
        Fg3.Cols("InQty").Visible = Not LOCK
        Fg3.Cols("Qty").Visible = Not LOCK
        Fg3.Cols("ID").Visible = LOCK
        SumFg3.ColForSum = L
        SumFg3.AddSum()
    End Sub

    Sub WHGH_Insert()
        If IsWNGH Then Dao.IsInsert = True
    End Sub

    Sub WHGH_Edit()
        If IsWNGH Then
            Dao.IsInsert = False
            Dim RDt As DtReturnMsg = Dao.PBRK_GetListByGH(TB_GH.Text)
            If RDt.IsOk Then
                Fg2.DtToSetFG(RDt.Dt)
            End If
        End If
    End Sub

#End Region
#Region "自动匹配重量"


    Private Sub TB_Input_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TB_Input.KeyPress
        If e.KeyChar = vbCr AndAlso TB_Input.ReadOnly = False Then
            FG_Sel_Zl(Val(TB_Input.Text))
        End If
    End Sub

    Sub FG_Sel_Zl(ByVal PB As Double)


        Dim Min As Double = Double.MaxValue
        Dim MinRow As Integer = 0
        Dim H As Boolean = False
        For i As Integer = 1 To Fg1.Rows.Count - 1
            If Fg1.Item(i, "GH") = "" Then
                Dim CZ As Double = Math.Abs(Val(Fg1.Item(i, "ZL")) - PB)
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
                ShowErrMsg("没有找到重量和[" & PB & "]相近的胚布!", AddressOf TB_Input.Focus)
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
            Fg2.Item(i, "ID") = TB_Input.Tag
            Fg2.Item(i, "PB") = TB_Input.Text
            Fg2.Item(i, "ZL") = Fg1.Item(MinRow, "ZL")
            Fg2.Item(i, "Line") = Fg1.Item(MinRow, "Line")
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

    Private Sub Fg2_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fg2.DoubleClick
        If Btn_RemoveRow.Visible = True AndAlso Btn_RemoveRow.Enabled = True Then
            Btn_RemoveRow_Click(Btn_RemoveRow, New System.EventArgs)
        End If
    End Sub

    Sub AddAll()
        For i As Integer = 1 To Fg1.Rows.Count - 1
            If Fg1.Item(i, "GH") = "" Then
                TB_Input.Text = Fg1.Item(i, "ZL")
                FG_Sel_Zl(Val(TB_Input.Text))
            End If
            If TB_Input.ReadOnly Then
                Exit For
            End If
        Next
    End Sub


#Region "Fg3事件"

    Private Sub Fg3_NextCell(ByVal e As PClass.FG.NextCellEventArgs) Handles Fg3.NextCell

        Select Case e.Col
            Case "StoreNo"
                e.ToCol = Fg3.Cols("InQty").Index

            Case "OQty"
                If e.Row + 2 > Fg3.Rows.Count Then
                    e.ToRow = e.Row
                    e.ToCol = 4
                Else
                    e.ToRow = e.Row + 1
                    e.ToCol = 4
                End If
        End Select
    End Sub

    Private Sub Fg3_AfterEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles Fg3.AfterEdit
        If e.Row < 0 Then
            Exit Sub
        End If
        If Fg3.LastKey = Keys.Enter Then
            Fg3.LastKey = 0
            Select Case Fg3.Cols(e.Col).Name
                Case "StoreNo"

                Case "OQty"
                    If Val(Fg3.Item(e.Row, "InQty")) < Val(Fg3.Item(e.Row, "OQty")) Then
                        Fg3.Item(e.Row, "OQty") = 0
                        ShowErrMsg("配布数量不能大于仓存数量")
                    End If
                    Fg3.Item(e.Row, "Qty") = Val(Fg3.Item(e.Row, "InQty")) - Val(Fg3.Item(e.Row, "OQty"))
                    SetDtStore(dtStore, e.Row)
                    SumFg3.ReSum()
                    Fg3.GotoNextCell(e.Col)
                Case Else
                    Fg3.GotoNextCell(e.Col)
            End Select
        End If

        Select Case Fg3.Cols(e.Col).Name

            Case "StoreNo"

            Case "OQty"
                If Val(Fg3.Item(e.Row, "InQty")) < Val(Fg3.Item(e.Row, "OQty")) Then
                    Fg3.Item(e.Row, "OQty") = 0
                    MsgBox("配布数量不能大于仓存数量", MsgBoxStyle.DefaultButton1, "错误提示")
                End If
                Fg3.Item(e.Row, "Qty") = Val(Fg3.Item(e.Row, "InQty")) - Val(Fg3.Item(e.Row, "OQty"))
                SetDtStore(dtStore, e.Row)
                SumFg3.ReSum()

        End Select



    End Sub

    Private Sub SetDtStore(ByVal dt As DataTable, ByVal Row As Integer)
        Dim dr() As DataRow = dt.Select("ID='" & Fg3.Item(Row, "ID") & "' And StoreNo='" & Fg3.Item(Row, "StoreNo") & "'")
        If dr.Length = 1 Then
            dr(0)("OQty") = Val(Fg3.Item(Row, "OQty"))
            dr(0)("Qty") = Val(Fg3.Item(Row, "InQty")) - Val(Fg3.Item(Row, "OQty"))
        End If
    End Sub




    Private Sub Fg3AddRow()
        Fg3.AddRow()
    End Sub


    Private Function SetStoreCheck(ByVal StorNo As String) As Boolean
        Dim T As Integer = 0
        For i As Integer = 1 To Fg3.Rows.Count - 1
            If StorNo = Fg3.Item(i, "StoreNo") Then
                T += 1
            End If
        Next
        If T > 1 Then
            T = 0
            ShowErrMsg("仓位［" & StorNo & "］已被选择")
            Return False
        End If

        If CheckStoreNo(StorNo) = False Then
            ShowErrMsg("找不到仓位［" & StorNo & "］")
            Return False
        End If
        Return True
    End Function

    Protected Function CheckStoreNo(ByVal _storeNO) As Boolean
        Dim msg As DtReturnMsg = ComFun.StoreMap_CheckStoreNo(_storeNO)
        If msg.IsOk AndAlso msg.Dt.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

#End Region

    Private Sub RemoveALL(ByVal FG As FG)
        For I As Integer = FG.Rows.Count - 1 To 1 Step -1
            FG.RemoveRow()
        Next
    End Sub



#Region "取消配布"

    Private Sub Cmd_CancelPB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_CancelPB.Click
        ' ShowInput("请填写取消原因", AddressOf CancelPB)
        '    ShowConfirm("是否取消配布?", AddressOf CancelPB)
        Dim F As New F40205_KUCUN_Msg("")
        With F
            .Mode = Mode_Enum.Add
            .P_F_RS_ID = Bill_ID
            .P_F_RS_ID2 = Val(TB_CR_LuoSeBzCount.Text)
            .ID = Me.ID
        End With
        F_RS_ID = ""
        Me.ReturnId = ""
        Me.ReturnObj = Nothing
        Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F, Me)
        AddHandler VF.ClosedX, AddressOf Edit_Retrun
        VF.Show()
        Me.Close()
    End Sub
    Private Sub Edit_Retrun()
        If ReturnId <> "" Then
            ' Me_Refresh()
        End If
    End Sub

    Sub CancelPB(ByVal reason As String)
        Dim bztext As New StringBuilder
        bztext.Append("|")
        For i As Integer = 1 To Fg2.Rows.Count - 1
            bztext.Append(Fg2.Item(i, "ID"))
            bztext.Append(";")

            bztext.Append(";")
            bztext.Append(Fg2.Item(i, "ZL"))
            bztext.Append(";")
            bztext.Append(Fg2.Item(i, "PB"))
            bztext.Append(";")
            bztext.Append("|")
        Next
        Dim R As MsgReturn = Dao.SCPB_Cancel(Bill_ID, reason, bztext.ToString, RDT)
        ' Dim L As MsgReturn = Dao.KU_Save(RDT)
        If R.IsOk Then
            ShowOk("取消配布成功!")
        Else
            IsShowErr = True
            ShowErrMsg("取消配布失败!")
        End If
        TB_GH.Text = Bill_ID
        Get_GH(Bill_ID)
        IsShowErr = False
    End Sub

#End Region

#Region "清除配布"


    Private Sub Cmd_ClearPB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_ClearPB.Click
        ShowConfirm("是否清除本单的所有配布?", AddressOf ClearPB)
    End Sub

    Sub ClearPB()
        Dim R As MsgReturn = Dao.SCPB_Clear(Bill_ID)
        If R.IsOk Then
            dtStore.Clear()
            ShowOk(R.Msg)
        Else
            IsShowErr = True
            ShowErrMsg(R.Msg)
        End If
        TB_GH.Text = Bill_ID
        Get_GH(Bill_ID)
        IsShowErr = False
    End Sub

#End Region

    Private Sub Cmd_AddAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_AddAll.Click
        AddAll()
    End Sub

    Private Sub TB_YPZL_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_YPZL.TextChanged

    End Sub

    Private Sub Label30_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label30.Click

    End Sub

    Private Sub Cmd_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Add.Click
        For i As Integer = Fg1.Selection.TopRow To Fg1.Selection.BottomRow
            If Fg1.RowSel > 0 AndAlso Fg1.Item(Fg1.RowSel, "GH") = "" AndAlso TB_Input.ReadOnly = False Then
                TB_Input.Text = Fg1.Item(i, "ZL")
                FG_Sel_Zl(Val(TB_Input.Text))
            End If
        Next
    End Sub

    Private Sub Cmd_ShowAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_ShowAll.Click
        'For j As Integer = 1 To ToolStrip_StoreNo_Old.Tag
        '    CType(ToolStrip_StoreNo_Old.Items("StoreNo" & j), ToolStripButton).Checked = False
        'Next
        'If Cmd_ShowAll.Text <> sender.text Then Cmd_ShowAll.Checked = False
        'sender.Checked = True
        ''OldStore = sender.text
        'FG_ChangeStore(Fg1, dtList, "StoreNo", sender.text, True)

        'UpDateTable(T, dtStore)
        TB_GH.Focus()
        For Each B As ToolStripButton In ToolStrip_StoreNo_Old.Items
            If B.Name <> sender.text Then
                B.Checked = False
            End If
        Next
        Cmd_ShowAll.Checked = True
        Fg3.DtToFG(dtStore)
        Fg3.ReAddIndex()
        SumFg3.ReSum()
    End Sub


    Sub FG_ChangeStore(ByVal FG As FG, ByVal Dt As DataTable, ByVal Field As String, ByVal Store As String, Optional ByVal IsSearchNo As Boolean = False)
        If Dt IsNot Nothing Then
            FG.Redraw = False
            'Dim SearchNo As String = ""
            'If TB_SearchNo.Text <> "" AndAlso IsSearchNo Then
            '    SearchNo = " and sID like '%" & TB_SearchNo.Text & "%'"
            'End If
            If Store = "全部仓位" Then
                'FG.DtToSetFG(DtRunSQLtoDt(Dt, " IsSel=0" & SearchNo))
                FG.DtToSetFG(Dt)
            Else
                FG.DtToSetFG(DtRunSQLtoDt(Dt, Field & "='" & Store & "'"))
            End If
            FG.Redraw = True
        Else
            FG.Rows.Count = 1
        End If
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
                    Dim line As Integer = Fg1.Item(i, "Line")
                    If Fg2.Item(j, "Line") = line Then
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
    End Sub

    Private Sub Cmd_Del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Del.Click
        Btn_RemoveRow_Click(sender, e)
    End Sub

#Region "查看取消记录"
    Private Sub Cmd_ShowLog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_ShowLog.Click
        Dim F As New F40202_CancelPB_Log(TB_GH.Text)
        With F
            .Mode = Mode_Enum.Modify
            .P_F_RS_ID = ""
            .P_F_RS_ID2 = ""
        End With
        F_RS_ID = ""
        Me.ReturnId = ""
        Me.ReturnObj = Nothing
        Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F, Me)

        VF.Show()
    End Sub
#End Region



    ''' <summary>
    ''' 获取仓位库存
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Get_StoreNo_Qty(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Del.Click
        Btn_RemoveRow_Click(sender, e)
    End Sub

    ''' <summary>
    ''' 获取仓位配布数
    ''' </summary>
    ''' <remarks></remarks>
    Private Function GetPBQty() As String
        Dim V As New StringBuilder
        Dim dt As DataTable = dtStore.DefaultView.ToTable(True, "ID")
        Dim S As Object
        Dim L As Integer = 0
        For Each Dr As DataRow In dt.Rows
            S = dtStore.Compute("Sum(OQty)", "ID='" & Dr("ID") & "'")
            L = GetPBQty(Fg2, Dr("ID"))
            If S <> L Then
                V.AppendLine("入库单［" & Dr("ID") & "］仓位配布［" & S & "］与条数配布［" & L & "］不一致")
            End If
        Next
        Return V.ToString.Trim

    End Function






    Private Function GetPBQty(ByVal f As FG, ByVal ID As String) As Integer
        Dim t As Integer = 0
        For i As Integer = 1 To f.Rows.Count - 1
            If f.Item(i, "ID") = ID Then
                t += 1
            End If
        Next

        Return t
    End Function

End Class



