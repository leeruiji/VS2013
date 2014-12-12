Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports BaseClass
Imports PClass.CReport
Imports BaseClass.FindOption
Imports BaseClass.OptionClass

Public Class F30001_Produce_Gd_Msg

    Dim LId As String = ""

    Dim Bill_ID_Date As Date = #1/1/1999#
    Dim Dt_Produce As New DataTable
    Dim Dt_WorkList As New DataTable
    Dim Dt_Charge As New DataTable
    Dim Dt_BZ As New DataTable
    Dim IsBinding As Boolean = False
    Dim isLoaded As Boolean = False
    '  Dim IsFD As Boolean = False
    Public GHType As Enum_GH_Type = Enum_GH_Type.Normal
    Dim ChangeColor As Boolean = False


    Public Sub New()
        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        Me.Ch_Name = "运转单"
        ' 在 InitializeComponent() 调用之后添加任何初始化。
        ID = 30000

    End Sub

    Public Sub New(ByVal produceId As String)

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        Me.Bill_ID = produceId
        TB_ID.Text = produceId
        ' 在 InitializeComponent() 调用之后添加任何初始化。
        Me.Ch_Name = "运转单"
        ID = 30000
    End Sub

    ''' <summary>
    ''' 权限获取
    ''' </summary>
    ''' <remarks></remarks>
    Sub FormCheckRight()

        Control_CheckRight(ID, ClassMain.Modify, Cmd_Modify)
        ' Control_CheckRight(ID, ClassMain.Del, Cmd_Del)

        Control_CheckRight(ID, ClassMain.Print, Cmd_Preview)
        Control_CheckRight(ID, ClassMain.Print, Cmd_Print)

        Control_CheckRight(ID, ClassMain.SetInValid, Cmd_Invalid)
        Control_CheckRight(ID, ClassMain.SetValid, Cmd_SetValid)


        Control_CheckRight(ID, ClassMain.ChangeColor, Cmd_ChangeColor)
        Dim canEdit = CheckRight(ID, "ChangeColor")
        '  Cb_BZC.Enabled = canEdit
        '   CB_BZC_PF.Enabled = canEdit

        CKB_IsChangeToBlack.Enabled = canEdit


        Control_CheckRight(ID, ClassMain.ChangePB, Cmd_ChangePB)
        If CheckRight(ID, ClassMain.NoComFirm) = False Then
            Cb_BZC.SearchType = cSearchType.ENum_SearchType.Add_SQL
            Cb_BZC.SearchID = " and exists(select 1 from T50001_Price_List where BZC_ID=T10003_BZC.id and IsComfirm=1) "
        End If
        Control_CheckRight(ID, ClassMain.CaiGang, Cmd_CG)
        Control_CheckRight(ID, ClassMain.CaiGang, Cmd_ChangePB)
        Control_CheckRight(ID, ClassMain.HeGang, Cmd_HG)
        'Control_CheckRight(ID, ClassMain.PeiBu, Cmd_PeiBu)
        'Control_CheckRight(ID, ClassMain.PeiBu_Comfirm, Cmd_PeiBu_Comform)
        'Control_CheckRight(ID, ClassMain.PeiBu_Cancel, Cmd_PeiBu_Cancel)
    End Sub

    Protected Overrides Function ProcessDialogKey(ByVal keyData As Keys) As Boolean
        If keyData = Keys.Enter Then
            If TB_Remark.Focused = False AndAlso Cb_BZC.Focused = False Then
                keyData = Keys.Tab
            End If
        End If
        Return MyBase.ProcessDialogKey(keyData)
    End Function

    Private Sub F30001_Produce_Gd_Msg_AfterLoad() Handles Me.AfterLoad
        If Mode = Mode_Enum.Add Then
            Cb_BZC.Focus()
        End If

    End Sub

    Private Sub Form_Me_Closing(ByVal sender As Object, ByRef e As System.ComponentModel.CancelEventArgs) Handles Me.Me_Closing
        ComFun.DelBillNewID(BillType.Produce, Bill_ID, "GH")

    End Sub

    Private NowDate As Date = Today
    Private Sub F30000_Produce_Me_Load() Handles Me.Me_Load
        FormCheckRight()
        Ch_Name = GetBillTypeName(ID)
        'Dao.Balance_DB_NAME = Ch_Name
        Me.Title = Ch_Name

        If Bill_ID = "" Then Bill_ID = F_RS_ID
        SplitContainer1.Panel1Collapsed = True
      
        Cmd_Show.Checked = False
        AddUnitTextBox()
        AddAutoGoNext()
        CB_State.DisplayMember = "Field"
        CB_State.ValueMember = "DB_Field"
        CB_State.DataSource = Dao.StateName_GetConditionNames

        CB_WorkList.DisplayMember = "WorkList_Name"
        CB_WorkList.ValueMember = "ID"
        Dim dtWorkList As DtReturnMsg = Dao.Get_AllWorkList
        If dtWorkList.IsOk Then
            CB_WorkList.DataSource = dtWorkList.Dt
        End If
        CB_WorkList.SelectedIndex = -1
        Employee_List1.Set_TextBox(TB_GenDan, TB_Auditor)
        Employee_List1.SearchType = Employee_List.ENum_SearchType.FormatSet
        Employee_List1.SearchId = "E_CK"
        NowDate = PClass.PClass.GetDate
        DP_Date_JiaoHuo.Value = NowDate
        DP_Date_KaiDan.Value = NowDate
        DP_Date_LuoSe.Value = NowDate
        DP_Date_ShouPei.Value = NowDate
        LoadForm()
        If Mode = Mode_Enum.Add Then
            LabelGH.Visible = False
            CB_GH.Visible = False
            Cmd_HG.Visible = False
            If CheckRight(ID, ClassMain.Add) = False Then Me.ShowErrMsg("没有权限添加" & Ch_Name & "!", True) : Exit Sub
            GetNewID()
            ' Cmd_Copy.Visible = False
            TB_KaiDan.Text = PClass.PClass.User_Display

        ElseIf Mode = Mode_Enum.Modify Then
            CB_BZ.Enabled = False
            '   Cmd_AddBZ.Enabled = True
            '   Cmd_BZName.Enabled = True
            '  Cmd_BZCName.Enabled = True
            '  Cmd_BZNo.Enabled = True
            CB_WorkList.Visible = False
            Label31.Visible = False
            CB_WorkList.Enabled = False
            Label31.Enabled = False
           

            ' Cmd_Copy.Visible = True
        End If
        TB_ID.Focus()
        isLoaded = True
    End Sub


    ''' <summary>
    ''' 刷新表单信息
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub LoadForm()
        Cmd_ChangePB.Visible = False
        If Mode = Mode_Enum.Add Then
            Dim msg As DtReturnMsg = Dao.ProduceGd_GetEmptyRow()
            If msg.IsOk Then
                Me.Dt_Produce = msg.Dt
                Me.Dt_Produce.Rows.Add(Me.Dt_Produce.NewRow)
                Dim Dr As DataRow = Me.Dt_Produce.Rows(0)
                Dr("State") = Enum_ProduceState.AddNew
                Dr("IsFG") = False


                '返定,退胚处理
                If F_RS_ID3 <> "" Then
                    Select Case GHType
                        Case Enum_GH_Type.FD
                            Me.Dt_Produce.Rows(0)("IsFD") = True
                            Dr("BZ_ID") = F_RS_ID2
                            Dr("Client_ID") = F_RS_ID3
                            Dr("Client_No") = F_RS_ID4
                            Dr("Client_Name") = F_RS_ID5
                            Dr("BzcMsg") = F_RS_Obj & vbCrLf
                            Dr("ProcessType") = "返定"
                        Case Enum_GH_Type.TP
                            Me.Dt_Produce.Rows(0)("IsTP") = True
                            Dr("BZ_ID") = F_RS_ID2
                            Dr("Client_ID") = F_RS_ID3
                            Dr("Client_No") = F_RS_ID4
                            Dr("Client_Name") = F_RS_ID5
                            Dr("BzcMsg") = F_RS_Obj & vbCrLf
                            Dr("ProcessType") = "退胚"
                    End Select


                End If

            End If
            Dim worklist As DtReturnMsg = Dao.Produce_Worklist(0)
            Dim dtChare_Msg As DtReturnMsg = Dao.Produce_GetCharge(0)
            If dtChare_Msg.IsOk Then
                Dt_Charge = dtChare_Msg.Dt
            End If
          
            If worklist.IsOk Then
                Dt_WorkList = worklist.Dt
                Fg1.DtToSetFG(Dt_WorkList)
            End If



        Else
            Dim msg As DtReturnMsg = Dao.ProduceGd_GetById(Bill_ID)
            Dim worklist As DtReturnMsg = Dao.Produce_Worklist(Bill_ID)
            Dim dtChare_Msg As DtReturnMsg = Dao.Produce_GetCharge(Bill_ID)
            If dtChare_Msg.IsOk Then
                Dt_Charge = dtChare_Msg.Dt
            End If
            If msg.IsOk AndAlso msg.Dt.Rows.Count > 0 Then
                Me.Dt_Produce = msg.Dt
                Me.Dt_WorkList = worklist.Dt
                If IsNull(Me.Dt_Produce.Rows(0)("State"), Enum_ProduceState.AddNew) <> Enum_ProduceState.AddNew Then
                    '  Me.Cmd_LuoDan.Enabled = False
                    '   Me.Cmd_Del.Enabled = False
                End If

                If worklist.IsOk Then
                    worklist.Dt.Columns.Add("StateName", GetType(String))
                    For Each dr As DataRow In worklist.Dt.Rows
                        dr("StateName") = ComFun.GetWorkStateName(IsNull(dr("State"), Enum_WorkState.None))
                    Next
                    Fg1.DtToSetFG(worklist.Dt)
                End If
            Else
                ShowErrMsg("没能找到" & Dao.Produce_Gd_Name & "[" & Me.P_F_RS_ID & "]信息")
                Exit Sub
            End If
            LoadGH()
        End If

        PeiBuList1.iniForm(Me.Dt_Produce, Me)
        '   SetTab()
        SetForm()
        '  BindingForm()
    End Sub
#Region "相关缸号"


    Sub LoadGH()
        LabelGH.Text = "加载相关单号中...."
        TB_SumAmount.Text = "计算中..."
        CB_GH.ForeColor = Color.Black
        Cmd_HG.Visible = False
        LabelGH.Visible = True
        Dim T As New Threading.Thread(AddressOf LoadGH_Asc)
        T.Start(Bill_ID)
    End Sub

    Sub LoadGH_Asc(ByVal GH As String)
        Dim SQL As New List(Of String)
        Dim P As New Dictionary(Of String, Object)
        SQL.Add("select GH from T30000_Produce_Gd where GH like left(@GH,11) + '%' and GH<>@GH and state >-1")
        SQL.Add("select Sum(SumAmount)SumAmount from T20310_LingLiao_Table where Produce_id =@GH and state >-1")
        P.Add("@GH", GH)
        Try
            Dim R As List(Of DataTable) = SqlStrToDtList(SQL, P)
            Me.Invoke(New DShowGH(AddressOf ShowGH), R)
        Catch ex As Exception
            Me.Invoke(New DShowGH(AddressOf ShowGH), Nothing)
        End Try
    End Sub

    Delegate Sub DShowGH(ByVal Dt As List(Of DataTable))

    Sub ShowGH(ByVal Dt As List(Of DataTable))
        If Dt IsNot Nothing Then
            If Dt(0).Rows.Count > 0 Then
                CB_GH.DataSource = Dt(0)
                CB_GH.DisplayMember = "GH"
                CB_GH.ValueMember = "GH"
                LabelGH.Text = "相关单号:"
                LabelGH.Visible = True
                CB_GH.Visible = True
                Cmd_ChangePB.Visible = Cmd_ChangePB.Tag
                LabelGH.ForeColor = Color.Blue
                Cmd_HG.Visible = True
            Else
                Cmd_HG.Visible = False
                LabelGH.Visible = False
                CB_GH.Visible = False
                Cmd_ChangePB.Visible = False
                LabelGH.ForeColor = Color.Black
            End If

            If Dt(1).Rows.Count > 0 Then

       


                TB_SumAmount.Text = FormatMoney(IsNull(Dt(1).Rows(0)(0), 0))
            Else

                Cb_BZC.Enabled = True
                CB_BZC_PF.Enabled = True
                TB_SumAmount.Text = 0
            End If
        End If

    End Sub

    Private Sub LabelGH_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles LabelGH.DoubleClick

        Try
            If CB_GH.Text = "" Then
                Exit Sub
            End If
            Dim F As New F30001_Produce_Gd_Msg(CB_GH.Text)
            With F
                .Mode = Mode_Enum.Modify
                .P_F_RS_ID = ""
                .P_F_RS_ID2 = ""
            End With
            F_RS_ID = ""
            Me.ReturnId = ""
            Me.ReturnObj = Nothing
            Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F, Me)
            AddHandler VF.ClosedX, AddressOf LoadGH
            VF.Show()
        Catch ex As Exception

        End Try

    End Sub
#End Region
#Region "自动跳格"

    Sub AddAutoGoNext()
        AddHandler TB_CR_BianDuiBian.KeyDown, AddressOf AutoGoNext_KeyDown
        AddHandler TB_CR_ChengYiXiShui.KeyDown, AddressOf AutoGoNext_KeyDown
        AddHandler TB_CR_HengSuo.KeyDown, AddressOf AutoGoNext_KeyDown
        AddHandler TB_CR_KeZhong.KeyDown, AddressOf AutoGoNext_KeyDown
        AddHandler TB_CR_LuoSeBzCount.KeyDown, AddressOf AutoGoNext_KeyDown

        AddHandler TB_CR_LuoSeBzCount.KeyDown, AddressOf AutoGoNext_KeyDown
        AddHandler TB_CR_LuoSeBzZL.KeyDown, AddressOf AutoGoNext_KeyDown
        AddHandler TB_CR_NiuDu.KeyDown, AddressOf AutoGoNext_KeyDown
        AddHandler TB_CR_ShiYong.KeyDown, AddressOf AutoGoNext_KeyDown
        AddHandler TB_CR_XiLao.KeyDown, AddressOf AutoGoNext_KeyDown

        AddHandler TB_CR_ZhiSuo.KeyDown, AddressOf AutoGoNext_KeyDown
        AddHandler TB_DuiSeGangHao.KeyDown, AddressOf AutoGoNext_KeyDown

        AddHandler TB_Contract.KeyDown, AddressOf AutoGoNext_KeyDown
        '    AddHandler DP_Date_LuoSe.KeyDown, AddressOf AutoGoNext_KeyDown
        AddHandler TB_TextileFatory.KeyDown, AddressOf AutoGoNext_KeyDown
        '    AddHandler DP_Date_KaiDan.KeyDown, AddressOf AutoGoNext_KeyDown

        AddHandler TB_ShaPi.KeyDown, AddressOf AutoGoNext_KeyDown
        AddHandler TB_ProcessType.KeyDown, AddressOf AutoGoNext_KeyDown

        AddHandler TB_Address.KeyDown, AddressOf AutoGoNext_KeyDown
        AddHandler TB_ZhiTong.KeyDown, AddressOf AutoGoNext_KeyDown
        AddHandler TB_JiaZhong.KeyDown, AddressOf AutoGoNext_KeyDown
        AddHandler TB_GangShu.KeyDown, AddressOf AutoGoNext_KeyDown
        AddHandler TB_HeRanGangHao.KeyDown, AddressOf AutoGoNext_KeyDown

    End Sub



    Private Sub AutoGoNext_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyData = Keys.Down OrElse e.KeyData = Keys.Enter Then
            e.SuppressKeyPress = False
            SendKeys.Send("{tab}")
        ElseIf e.KeyData = Keys.Up Then
            e.SuppressKeyPress = False
            SendKeys.Send("+{tab}")
        End If
    End Sub
#End Region

#Region "表单信息"
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub GetForm()
        If Me.Dt_Produce IsNot Nothing Then
            Dim Lock As Boolean
            Dim Dr As DataRow = Dt_Produce.Rows(0)
            Dr("CPRK_IsPrinted") = 0 '初始化成品入库未打印
            Select Case GHType
                Case Enum_GH_Type.FD
                    Dr("BZC_ID") = 0
                    Dr("BZC_No") = 0
                    Dr("BZC_Name") = ""
                    Dr("BZC_PF") = ""
                    Dr("ClientBZC") = ""
                    Cmd_Copy.Visible = False
                    Cmd_Copy.Enabled = False
                    Cmd_Copy.Tag = False
                    If TB_BZCName.Text <> "" Then
                        Dr("BzcMsg") = TB_BZCName.Text & vbCrLf & "(返定)"
                    End If
                Case Enum_GH_Type.TP
                    Dr("BZC_ID") = 0
                    Dr("BZC_No") = 0
                    Dr("BZC_Name") = ""
                    Dr("BZC_PF") = ""
                    Dr("ClientBZC") = ""
                    Cmd_Copy.Visible = False
                    Cmd_Copy.Enabled = False
                    Cmd_Copy.Tag = False
                    Dr("BzcMsg") = "(退胚)"
                Case Else
                    Dr("BZC_ID") = Cb_BZC.IDValue
                    Dr("BZC_No") = Cb_BZC.NoValue
                    Dr("BZC_Name") = TB_BZCName.Text
                    Dr("BZC_PF") = CB_BZC_PF.Text
                    Dr("ClientBZC") = TB_ClientBZC.Text


                    Dr("BzcMsg") = IIf(IsNull(Dr("ClientBzc"), "") <> "" AndAlso Not Dr("ClientBzc").ToString.Contains("#"), Dr("ClientBzc") & "#", IsNull(Dr("ClientBzc"), "")) & _
                    Dr("BZC_Name") & vbCrLf & "GY-" & Format(Dr("BZC_No"), "000000") & Dr("BZC_PF")



            End Select

            'If IsFD Then
            '    Dr("BZC_ID") = 0
            '    Dr("BZC_No") = 0
            '    Dr("BZC_Name") = ""
            '    Dr("BZC_PF") = ""
            '    Dr("ClientBZC") = ""
            '    Cmd_Copy.Visible = False
            '    Cmd_Copy.Enabled = False
            '    Cmd_Copy.Tag = False
            '    If TB_BZCName.Text <> "" Then
            '        Dr("BzcMsg") = TB_BZCName.Text & vbCrLf & "(返定)"
            '    End If
            'Else
            '    Dr("BZC_ID") = Cb_BZC.IDValue
            '    Dr("BZC_No") = Cb_BZC.NoValue
            '    Dr("BZC_Name") = TB_BZCName.Text
            '    Dr("BZC_PF") = CB_BZC_PF.Text
            '    Dr("ClientBZC") = TB_ClientBZC.Text


            '    Dr("BzcMsg") = IIf(IsNull(Dr("ClientBzc"), "") <> "" AndAlso Not Dr("ClientBzc").ToString.Contains("#"), Dr("ClientBzc") & "#", IsNull(Dr("ClientBzc"), "")) & _
            '            Dr("BZC_Name") & vbCrLf & "GY-" & Format(Dr("BZC_No"), "000000") & Dr("BZC_PF")


            'End If
            Dr("GHType") = GHType
            Dr("IsFD") = IIf(GHType = Enum_GH_Type.FD, True, False)
            Dr("IsTP") = IIf(GHType = Enum_GH_Type.TP, True, False)


            Dr("Client_ID") = Val(TB_ClientID.Tag)
            Dr("Client_No") = TB_ClientID.Text
            Dr("Client_Name") = TB_ClientName.Text

            Dr("BZ_ID") = CB_BZ.IDAsInt
            Dr("SG_ID") = CB_SG.IDAsInt
            Dr("SG_Color") = CB_Color.Text
            Dr("BZ_No") = CB_BZ.NoValue
            Dr("BZ_Name") = CB_BZ.NameValue

            Dr("UPD_User") = PClass.PClass.User_Name
            ComFun.GetColValue(Dr, CKB_IsChangeToBlack, False)

            ComFun.GetColValue(Dr, TB_ID, TB_ID.Text, "GH", Lock)
            ComFun.GetColValue(Dr, TB_Contract, "", "", Lock)
            ComFun.GetColValue(Dr, TB_TextileFatory, "", "", Lock)
            ComFun.GetColValue(Dr, TB_GangShu, "", "", Lock, "0")
            ComFun.GetColValue(Dr, TB_GangCi, "", "", Lock, "0")

            ComFun.GetColValue(Dr, TB_ShaPi, "", "", Lock)
            ComFun.GetColValue(Dr, TB_Address, "", "", Lock)
            ComFun.GetColValue(Dr, TB_ProcessType, "", "", Lock)
            ComFun.GetColValue(Dr, TB_Remark, "", "", Lock)


            ComFun.GetColValue(Dr, DP_Date_JiaoHuo, NowDate, "", Lock)
            ComFun.GetColValue(Dr, DP_Date_ShouPei, NowDate, "", Lock)
            ComFun.GetColValue(Dr, DP_Date_KaiDan, NowDate, "", Lock)
            ComFun.GetColValue(Dr, DP_Date_LuoSe, NowDate, "", Lock)


            ComFun.GetColValue(Dr, TB_ZhiTong, 0, "", Lock, FormatSharp("zhitong"))
            ComFun.GetColValue(Dr, TB_JiaZhong, 0, "", Lock, FormatSharp("jiazhong"))


            ''客户要求
            ComFun.GetColValue(Dr, CB_CR_ZhuangBaiSe, False, "", Lock, True)
            ComFun.GetColValue(Dr, CB_CR_QieBian, False, "", Lock, True)
            ComFun.GetColValue(Dr, CB_CR_YinHuaYong, False, "", Lock, True)
            ComFun.GetColValue(Dr, CB_CR_RiShai, False, "", Lock, True)

            ComFun.GetColValue(Dr, CB_CR_GanCa, False, "", Lock, True)
            ComFun.GetColValue(Dr, CB_CR_ShiCa, False, "", Lock, True)
            ComFun.GetColValue(Dr, CB_CR_ShiMao, False, "", Lock, True)
            ComFun.GetColValue(Dr, CB_CR_KaiDing, False, "", Lock, True)

            ComFun.GetColValue(Dr, CB_CR_KaiZhua, False, "", Lock, True)
            ComFun.GetColValue(Dr, CB_CR_DanMo, False, "", Lock, True)
            ComFun.GetColValue(Dr, CB_CR_DanXi, False, "", Lock, True)
            ComFun.GetColValue(Dr, CB_CR_ShuangJiaoDai, False, "", Lock, True)

            ComFun.GetColValue(Dr, CB_CR_PaoGan, False, "", Lock, True)
            ComFun.GetColValue(Dr, CB_CR_SuoShuiJi, False, "", Lock, True)
            ComFun.GetColValue(Dr, CB_CR_JiangBian, False, "", Lock, True)
            ComFun.GetColValue(Dr, CB_CR_ShuangJiaoDai, False, "", Lock, True)

            ComFun.GetColValue(Dr, TB_CR_XiLao, "", "", Lock)
            ComFun.GetColValue(Dr, TB_CR_ChengYiXiShui, "", "", Lock)
            ComFun.GetColValue(Dr, TB_CR_ShiYong, "", "", Lock)
            ComFun.GetColValue(Dr, TB_CR_BianDuiBian, "", "", Lock)
            ComFun.GetColValue(Dr, TB_CR_KeZhong, "", "", Lock)

            ComFun.GetColValue(Dr, TB_CR_HengSuo, "", "", Lock)
            ComFun.GetColValue(Dr, TB_CR_ZhiSuo, "", "", Lock)
            ComFun.GetColValue(Dr, TB_CR_NiuDu, "", "", Lock)

            ComFun.GetColValue(Dr, TB_CR_LuoSeBzCount, "", "", Lock)
            ComFun.GetColValue(Dr, TB_CR_LuoSeBzZL, "", "", Lock)



            ComFun.GetColValue(Dr, TB_DuiSeGangHao, "", "", Lock)
            ComFun.GetColValue(Dr, TB_HeRanGangHao, "", "", Lock)
            ComFun.GetColValue(Dr, TB_KaiDan, "", "", Lock)


            ComFun.GetColValue(Dr, TB_Auditor, "", "", Lock)
            ComFun.GetColValue(Dr, TB_GenDan, "", "GengDanName", Lock)
            'ComFun.GetColValue(Dr, TB_UPD_User, "", "", Lock)

            ComFun.GetColValue(Dr, TB_PB_CountSum, 0, "", Lock, FormatSharp("num"))
            ComFun.GetColValue(Dr, TB_PB_ZLSum, 0, "", Lock, FormatSharp("zl"))
            ComFun.GetColValue(Dr, TB_ClothStore, "", "", Lock)
            Dr("CR_LuoSeType") = Radio_ZL.Checked
            ' Dr("CKE_SG") = CheckBox_SG.Checked

            If CB_CPName.Checked Then
                Dr("CPName") = TB_CPName.Text
            Else

                Dr("CPName") = DBNull.Value
            End If


            If Radio_ZL.Checked = False Then
                Dr("PB_ZLSum") = DBNull.Value
            End If
        End If
        GetWork_List()
    End Sub

    Private Sub GetWork_List()
        Dt_WorkList = Dt_WorkList.Clone
        For i As Integer = 1 To Fg1.Rows.Count - 1
            Dim dw As DataRow = Dt_WorkList.NewRow
            dw("GH") = TB_ID.Text
            dw("Work_Name") = Fg1.Item(i, "Work_Name")
            dw("Work_No") = Fg1.Item(i, "Work_No")
            dw("Process_Name") = Fg1.Item(i, "Process_Name")
            dw("WorkList_Index") = i
            If Fg1.Item(i, "StartTime") Is Nothing OrElse Fg1.Item(i, "StartTime").ToString = "" Then
                dw("StartTime") = DBNull.Value
            Else
                dw("StartTime") = Fg1.Item(i, "StartTime")
            End If

            If Fg1.Item(i, "FinishTime") Is Nothing OrElse Fg1.Item(i, "FinishTime").ToString = "" Then
                dw("FinishTime") = DBNull.Value
            Else
                dw("FinishTime") = Fg1.Item(i, "FinishTime")
            End If
            If Fg1.Item(i, "State") Is Nothing OrElse Fg1.Item(i, "State").ToString = "" Then
                dw("State") = Enum_WorkState.None
            Else
                dw("State") = Fg1.Item(i, "State")
            End If

            dw("Work_ID") = Fg1.Item(i, "Work_ID")
            Dt_WorkList.Rows.Add(dw)
        Next
        Dt_WorkList.AcceptChanges()

    End Sub




    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub SetForm()
        If Me.Dt_Produce IsNot Nothing Then
            Dim Lock As Boolean
            Dim Dr As DataRow = Dt_Produce.Rows(0)
            'IsFD = IsNull(Dr("IsFD"), False)
            GHType = IsNull(Dr("GHType"), Enum_GH_Type.Normal)
            If IsNull(Dr("IsFD"), False) Then
                GHType = Enum_GH_Type.FD
            ElseIf IsNull(Dr("IsTP"), False) Then
                GHType = Enum_GH_Type.TP
            Else
                GHType = Enum_GH_Type.Normal
            End If
            Select Case GHType
                Case Enum_GH_Type.FD '返定
                    Cb_BZC.Enabled = False
                    Cb_BZC.SetSearchEmpty()
                    TB_BZCName.Text = IsNull(Dr("BzcMsg"), "").ToString.Split(vbCrLf)(0)
                    CB_BZ.Enabled = False
                    CB_BZ.IDAsInt = IsNull(Dr("BZ_ID"), 0)
                    CB_BZ.GetByTextBoxTag()
                    CB_BZ.Text = CB_BZ.NoValue
                    TB_BZName.Text = CB_BZ.NameValue
                    CB_BZ.SearchType = cSearchType.ENum_SearchType.ALL
                    TB_ClientBZC.Text = ""
                    CB_BZC_PF.Enabled = False
                    CB_BZC_PF.Text = ""
                    LabelFDFG.Text = "返定"
                    LabelFDFG.Visible = True
                Case Enum_GH_Type.TP '退胚
                    Cb_BZC.Enabled = False
                    Cb_BZC.SetSearchEmpty()
                    TB_BZCName.Text = IsNull(Dr("BzcMsg"), "").ToString.Split(vbCrLf)(0)
                    CB_BZ.Enabled = False
                    CB_BZ.IDAsInt = IsNull(Dr("BZ_ID"), 0)
                    CB_BZ.GetByTextBoxTag()
                    CB_BZ.Text = CB_BZ.NoValue
                    TB_BZName.Text = CB_BZ.NameValue
                    CB_BZ.SearchType = cSearchType.ENum_SearchType.ALL
                    TB_ClientBZC.Text = ""
                    CB_BZC_PF.Enabled = False
                    CB_BZC_PF.Text = ""
                    LabelFDFG.Text = "退胚"
                    LabelFDFG.Visible = True
                Case Else
                    Cb_BZC.Enabled = True
                    Cb_BZC.IDValue = Val(IsNull(Dr("BZC_ID"), 0))
                    Cb_BZC.GetByTextBoxTag()
                    Cb_BZC.Text = Cb_BZC.NoValue
                    TB_BZCName.Text = Cb_BZC.NameValue


                    CB_SG.Enabled = True
                    CB_SG.IDValue = IsNull(Dr("SG_ID"), 0)
                    CB_SG.GetByTextBoxTag()
                    CB_SG.Text = IsNull(Dr("SGGY_No"), "")
                    TB_SGName.Text = IsNull(Dr("SGGY_Name"), "")

                    CB_BZ.Enabled = False
                    CB_BZ.IDAsInt = IsNull(Dr("BZ_ID"), 0)
                    CB_BZ.GetByTextBoxTag()
                    CB_BZ.Text = IsNull(Dr("BZ_No"), "")
                    TB_BZName.Text = IsNull(Dr("BZ_Name"), "")
                    CB_BZ.SearchType = cSearchType.ENum_SearchType.BZC
                    CB_BZ.SearchID = Cb_BZC.IDValue
                    TB_ClientBZC.Text = IsNull(Dr("ClientBZC"), "")
                    CB_BZC_PF.Text = IsNull(Dr("BZC_PF"), "")
                    LoadPF(IsNull(Dr("BZC_ID"), 0))
                    If IsNull(Dr("IsFG"), False) Then
                        LabelFDFG.Text = "返工"
                        LabelFDFG.Visible = True
                    Else
                        LabelFDFG.Text = ""
                        LabelFDFG.Visible = False
                    End If
            End Select
            'If IsFD Then '返定
            '    Cb_BZC.Enabled = False
            '    Cb_BZC.SetSearchEmpty()
            '    TB_BZCName.Text = IsNull(Dr("BzcMsg"), "").ToString.Split(vbCrLf)(0)

            '    CB_BZ.Enabled = False
            '    CB_BZ.IDAsInt = IsNull(Dr("BZ_ID"), 0)
            '    CB_BZ.GetByTextBoxTag()
            '    CB_BZ.Text = CB_BZ.NoValue
            '    TB_BZName.Text = CB_BZ.NameValue
            '    CB_BZ.SearchType = cSearchType.ENum_SearchType.ALL
            '    TB_ClientBZC.Text = ""
            '    CB_BZC_PF.Enabled = False
            '    CB_BZC_PF.Text = ""

            '    LabelFDFG.Text = "返定"
            '    LabelFDFG.Visible = True

            'Else
            '    Cb_BZC.Enabled = True
            '    Cb_BZC.IDValue = Val(IsNull(Dr("BZC_ID"), 0))
            '    Cb_BZC.GetByTextBoxTag()
            '    Cb_BZC.Text = IsNull(Dr("BZC_No"), "")
            '    TB_BZCName.Text = IsNull(Dr("BZC_Name"), "")

            '    CB_BZ.Enabled = False
            '    CB_BZ.IDAsInt = IsNull(Dr("BZ_ID"), 0)
            '    CB_BZ.GetByTextBoxTag()
            '    CB_BZ.Text = IsNull(Dr("BZ_No"), "")
            '    TB_BZName.Text = IsNull(Dr("BZ_Name"), "")
            '    CB_BZ.SearchType = cSearchType.ENum_SearchType.BZC
            '    CB_BZ.SearchID = Cb_BZC.IDValue
            '    TB_ClientBZC.Text = IsNull(Dr("ClientBZC"), "")
            '    CB_BZC_PF.Text = IsNull(Dr("BZC_PF"), "")
            '    LoadPF(IsNull(Dr("BZC_ID"), 0))

            '    If IsNull(Dr("IsFG"), False) Then
            '        LabelFDFG.Text = "返工"
            '        LabelFDFG.Visible = True
            '    Else
            '        LabelFDFG.Text = ""
            '        LabelFDFG.Visible = False
            '    End If

            'End If


            ComFun.SetColValue(Dr, CKB_IsChangeToBlack, False)
            TB_ClientID.Tag = IsNull(Dr("Client_ID"), 0)
            TB_ClientID.Text = IsNull(Dr("Client_No"), "")
            TB_ClientName.Text = IsNull(Dr("Client_Name"), "")
            CB_Color.Text = IsNull(Dr("SG_Color"), "")


            'TB_UPD_User.Text = IsNull(Dr("UPD_User"), "")
            'TB_UPD_Date.Text = IsNull(Dr("UPD_Date"), "")

            ComFun.SetColValue(Dr, TB_ID, TB_ID.Text, "GH", Lock)
            ComFun.SetColValue(Dr, TB_Contract, "", "", Lock)
            ComFun.SetColValue(Dr, TB_TextileFatory, "", "", Lock)


            ComFun.SetColValue(Dr, TB_GangShu, "1", "", Lock, "0")
            ComFun.SetColValue(Dr, TB_GangCi, "", "", Lock, "0")

            ComFun.SetColValue(Dr, TB_ShaPi, "", "", Lock)
            ComFun.SetColValue(Dr, TB_Address, "", "", Lock)
            ComFun.SetColValue(Dr, TB_ProcessType, "", "", Lock)
            ComFun.SetColValue(Dr, TB_Remark, "", "", Lock)
            ComFun.SetColValue(Dr, TB_CGRemark, "", "", Lock)


            ComFun.SetColValue(Dr, DP_Date_JiaoHuo, NowDate, "", Lock)
            ComFun.SetColValue(Dr, DP_Date_ShouPei, NowDate, "", Lock)
            ComFun.SetColValue(Dr, DP_Date_KaiDan, NowDate, "", Lock)
            ComFun.SetColValue(Dr, DP_Date_LuoSe, NowDate, "", Lock)


            ComFun.SetColValue(Dr, TB_ZhiTong, 0, "", Lock, FormatSharp("zhitong"))
            ComFun.SetColValue(Dr, TB_JiaZhong, 0, "", Lock, FormatSharp("jiazhong"))


            ''客户要求
            ComFun.SetColValue(Dr, CB_CR_ZhuangBaiSe, False, "", Lock, True)
            ComFun.SetColValue(Dr, CB_CR_QieBian, False, "", Lock, True)
            ComFun.SetColValue(Dr, CB_CR_YinHuaYong, False, "", Lock, True)
            ComFun.SetColValue(Dr, CB_CR_RiShai, False, "", Lock, True)

            ComFun.SetColValue(Dr, CB_CR_GanCa, False, "", Lock, True)
            ComFun.SetColValue(Dr, CB_CR_ShiCa, False, "", Lock, True)
            ComFun.SetColValue(Dr, CB_CR_ShiMao, False, "", Lock, True)
            ComFun.SetColValue(Dr, CB_CR_KaiDing, False, "", Lock, True)

            ComFun.SetColValue(Dr, CB_CR_KaiZhua, False, "", Lock, True)
            ComFun.SetColValue(Dr, CB_CR_DanMo, False, "", Lock, True)
            ComFun.SetColValue(Dr, CB_CR_DanXi, False, "", Lock, True)
            ComFun.SetColValue(Dr, CB_CR_ShuangJiaoDai, False, "", Lock, True)

            ComFun.SetColValue(Dr, CB_CR_PaoGan, False, "", Lock, True)
            ComFun.SetColValue(Dr, CB_CR_SuoShuiJi, False, "", Lock, True)
            ComFun.SetColValue(Dr, CB_CR_JiangBian, False, "", Lock, True)

            ComFun.SetColValue(Dr, CB_CR_ShuangJiaoDai, False, "", Lock, True)

            ComFun.SetColValue(Dr, TB_CR_XiLao, "", "", Lock)
            ComFun.SetColValue(Dr, TB_CR_ChengYiXiShui, "", "", Lock)
            ComFun.SetColValue(Dr, TB_CR_ShiYong, "", "", Lock)
            ComFun.SetColValue(Dr, TB_CR_BianDuiBian, "", "", Lock)
            ComFun.SetColValue(Dr, TB_CR_KeZhong, "", "", Lock)

            ComFun.SetColValue(Dr, TB_CR_HengSuo, "", "", Lock)
            ComFun.SetColValue(Dr, TB_CR_ZhiSuo, "", "", Lock)
            ComFun.SetColValue(Dr, TB_CR_NiuDu, "", "", Lock)
            ComFun.SetColValue(Dr, TB_CR_LuoSeBzCount, "", "", Lock)
            ComFun.SetColValue(Dr, TB_CR_LuoSeBzZL, "", "", Lock)



            ComFun.SetColValue(Dr, TB_DuiSeGangHao, "", "", Lock)
            ComFun.SetColValue(Dr, TB_HeRanGangHao, "", "", Lock)
            ComFun.SetColValue(Dr, TB_KaiDan, "", "", Lock)


            ComFun.SetColValue(Dr, TB_Auditor, "", "", Lock)
            ComFun.SetColValue(Dr, TB_GenDan, "", "GengDanName", Lock)
            'ComFun.SetColValue(Dr, TB_UPD_User, "", "", Lock)

            ComFun.SetColValue(Dr, TB_PB_CountSum, 0, "", Lock, FormatSharp("num"))
            ComFun.SetColValue(Dr, TB_PB_ZLSum, 0, "", Lock, FormatSharp("zl"))
            ComFun.SetColValue(Dr, TB_ClothStore, "", "", Lock)

            '其他

            TB_UPD_USER.BillID = TB_ID.Text
            TB_UPD_USER.Text = IsNull(Dr("UPD_User"), "")
            TB_UPD_USER.Tag = IsNull(Dr("UPD_User"), "")






            If TB_CGRemark.Text = "" Then
                TB_CGRemark.Visible = False
                LB_CGRemark.Visible = False
                TB_Remark.Height = 117
            Else
                TB_CGRemark.Visible = True
                LB_CGRemark.Visible = True
                TB_Remark.Height = 117 / 2
            End If

            If IsNull(Dr("CPName"), "") = "" Then
                TB_CPName.Text = ""
                CB_CPName.Checked = False
            Else
                TB_CPName.Text = Dr("CPName")
                CB_CPName.Checked = True
            End If


            TB_GenDan.Tag = IsNull(Dr("GengDan"), 0)
            If IsNull(Dr("CR_LuoSeType"), False) Then
                Radio_ZL.Checked = True
                Radio_Num.Checked = False
            Else
                Radio_ZL.Checked = False
                Radio_Num.Checked = True
            End If
            SetState(IsNull(Dr("State"), 0))
        End If

       

    End Sub

    Sub SetState(ByVal state As Enum_ProduceState)

        If Mode = Mode_Enum.Add Then
            Cmd_Copy.Visible = False
            Cmd_CG.Visible = False
            CB_WorkList.Visible = True
            CB_WorkList.Enabled = True
            Cmd_SetValid.Enabled = False
            Cmd_Invalid.Enabled = False
            Cmd_Preview.Enabled = False
            Cmd_Print.Enabled = False
        Else
            Cmd_Copy.Visible = True
            CB_WorkList.Visible = False
            CB_WorkList.Enabled = False
            Cmd_CG.Visible = True
            Cmd_Preview.Enabled = True
            Cmd_Print.Enabled = True
        End If

        Cmd_FG.Visible = False
        Select Case state
            Case Enum_ProduceState.AddNew
                Cmd_Modify.Enabled = Cmd_Modify.Tag
                Cmd_WorkList_Save.Enabled = Not Cmd_Modify.Enabled
                Cmd_ChangeColor.Visible = False
                Cmd_Invalid.Visible = Cmd_Invalid.Tag
                Cmd_SetValid.Visible = False
                LockQty(False)
            Case Enum_ProduceState.Invalid
                Cmd_CG.Visible = False
                Cmd_Modify.Enabled = False
                Cmd_WorkList_Save.Enabled = Not Cmd_Modify.Enabled
                Cmd_ChangeColor.Visible = False
                Cmd_Invalid.Visible = False
                Cmd_SetValid.Visible = Cmd_SetValid.Tag
                CB_BZ.Enabled = False
                Cb_BZC.Enabled = False
                CB_BZC_PF.Enabled = False
                LockQty(True)
            Case Enum_ProduceState.XiaDan
                Cmd_Modify.Enabled = Cmd_Modify.Tag
                Cmd_WorkList_Save.Enabled = Not Cmd_Modify.Enabled
                Cmd_ChangeColor.Visible = True
                Cmd_Invalid.Visible = Cmd_Invalid.Tag
                Cmd_SetValid.Visible = False
                If Cmd_ChangeColor.Tag = False Then
                    CB_BZ.Enabled = False
                    Cb_BZC.Enabled = False
                    CB_BZC_PF.Enabled = False
                Else
                    CB_BZ.Enabled = True
                    Cb_BZC.Enabled = True
                    CB_BZC_PF.Enabled = True
                End If
                LockQty(False)
            Case Is < Enum_ProduceState.ChengJianZhong
                Cmd_Modify.Enabled = False
                Cmd_WorkList_Save.Enabled = Not Cmd_Modify.Enabled
                Cmd_ChangeColor.Visible = True
                Cmd_Invalid.Visible = Cmd_Invalid.Tag
                Cmd_SetValid.Visible = False
                Cmd_FG.Visible = False
                If Cmd_ChangeColor.Tag = False Then
                    CB_BZ.Enabled = False
                    Cb_BZC.Enabled = False
                    CB_BZC_PF.Enabled = False
                Else
                    CB_BZ.Enabled = True
                    Cb_BZC.Enabled = True
                    CB_BZC_PF.Enabled = True
                End If
                LockQty(True)
            Case Is >= Enum_ProduceState.ChengJianZhong
                If state = Enum_ProduceState.SongHuo Then
                    Cmd_CG.Enabled = False
                    Cmd_CG.Visible = False
                    Cmd_Modify.Enabled = False
                    Cmd_WorkList_Save.Enabled = Not Cmd_Modify.Enabled
                    Cmd_ChangeColor.Visible = True
                    Cmd_Invalid.Visible = False
                    Cmd_SetValid.Visible = False
                    CB_BZ.Enabled = False
                    Cb_BZC.Enabled = False
                    CB_BZC_PF.Enabled = False
                    Cmd_FG.Visible = True
                    If Cmd_ChangeColor.Tag = False Then
                        CB_BZ.Enabled = False
                        Cb_BZC.Enabled = False
                        CB_BZC_PF.Enabled = False
                    Else
                        CB_BZ.Enabled = True
                        Cb_BZC.Enabled = True
                        CB_BZC_PF.Enabled = True
                    End If
                Else
                    Cmd_Modify.Enabled = False
                    Cmd_WorkList_Save.Enabled = Not Cmd_Modify.Enabled
                    Cmd_ChangeColor.Visible = True
                    Cmd_Invalid.Visible = False
                    Cmd_SetValid.Visible = False
                    CB_BZ.Enabled = False
                    Cb_BZC.Enabled = False
                    CB_BZC_PF.Enabled = False
                    Cmd_FG.Visible = True
                    If Cmd_ChangeColor.Tag = False Then
                        CB_BZ.Enabled = False
                        Cb_BZC.Enabled = False
                        CB_BZC_PF.Enabled = False
                    Else
                        CB_BZ.Enabled = True
                        Cb_BZC.Enabled = True
                        CB_BZC_PF.Enabled = True
                    End If
                End If
                LockQty(True)
            Case Else
                Cmd_Modify.Enabled = Cmd_Modify.Tag
                Cmd_WorkList_Save.Enabled = Not Cmd_Modify.Enabled
                Cmd_ChangeColor.Visible = True
                Cmd_Invalid.Visible = False
                Cmd_SetValid.Visible = False
                If Cmd_ChangeColor.Tag = False Then
                    CB_BZ.Enabled = False
                    Cb_BZC.Enabled = False
                    CB_BZC_PF.Enabled = False
                Else
                    CB_BZ.Enabled = True
                    Cb_BZC.Enabled = True
                    CB_BZC_PF.Enabled = True
                End If
                LockQty(False)
        End Select





        Me.LB_State.Text = BaseClass.ComFun.GetProduceStateName(state)
        Me.LB_State.Tag = state
    End Sub

    Sub LockQty(ByVal Lock As Boolean)
        Radio_Num.Enabled = Not Lock
        Radio_ZL.Enabled = Not Lock
        TB_CR_LuoSeBzCount.ReadOnly = Lock
        TB_CR_LuoSeBzZL.ReadOnly = Lock
        Radio_Num_CheckedChanged(Nothing, Nothing)
    End Sub


    ''' <summary>
    ''' 绑定表单信息
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub BindingForm()
        If IsBinding = False Then
            ' ''表头
            '' TB_ID.DataBindings.Add("Text", Dt_Produce, "GH", True, DataSourceUpdateMode.OnPropertyChanged)
            'Dim Dr As DataRow = Dt_Produce.Rows(0)
            'TB_ID.Text = IsNull(Dr("GH"), "")

            'Comfun.setColValue(Dr, TB_ID, "", "GH", Lock)

            'Comfun.setColValue(Dr, TB_Contract, "", "", Lock)
            'Comfun.setColValue(Dr, TB_TextileFatory, "", "", Lock)
            'Comfun.setColValue(Dr, TB_GangShu, "", "", Lock)
            'Comfun.setColValue(Dr, TB_GangCi, "", "", Lock)

            'Comfun.setColValue(Dr, TB_ShaPi, "", "", Lock)
            'Comfun.setColValue(Dr, TB_Address, "", "", Lock)
            'Comfun.setColValue(Dr, TB_ProcessType, "", "", Lock)
            'Comfun.setColValue(Dr, TB_Remark, "", "", Lock)

            'If IsDBNull(Dr("DP_Date_JiaoHuo")) Then
            '    DP_Date_JiaoHuo.Checked = False
            'Else
            '    Comfun.setColValue(Dr, DP_Date_JiaoHuo, "", "", Lock)
            'End If

            'Comfun.setColValue(Dr, DP_Date_KaiDan, "", "", Lock)
            'Comfun.setColValue(Dr, DP_Date_LuoSe, "", "", Lock)
            'Comfun.setColValue(Dr, DP_Date_ShouPei, "", "", Lock)

            'Comfun.setColValue(Dr, TB_ZhiTong, 0, "", Lock)
            'Comfun.setColValue(Dr, TB_JiaZhong, 0, "", Lock)


            ''TB_Contract.DataBindings.Add("Text", Dt_Produce, "Contract", True, DataSourceUpdateMode.OnPropertyChanged)
            ''TB_TextileFatory.DataBindings.Add("Text", Dt_Produce, "TextileFatory", True, DataSourceUpdateMode.OnPropertyChanged)
            ''TB_GangShu.DataBindings.Add("Text", Dt_Produce, "GangShu", True, DataSourceUpdateMode.OnPropertyChanged)
            ''TB_GangCi.DataBindings.Add("Text", Dt_Produce, "GangCi", True, DataSourceUpdateMode.OnPropertyChanged)

            ''TB_ShaPi.DataBindings.Add("Text", Dt_Produce, "ShaPi", True, DataSourceUpdateMode.OnPropertyChanged)
            ''TB_ProcessType.DataBindings.Add("Text", Dt_Produce, "ProcessType", True, DataSourceUpdateMode.OnPropertyChanged)
            ''TB_Address.DataBindings.Add("Text", Dt_Produce, "Address", True, DataSourceUpdateMode.OnPropertyChanged)
            ''TB_Remark.DataBindings.Add("Text", Dt_Produce, "Remark", True, DataSourceUpdateMode.OnPropertyChanged)

            ''DP_JiaoHuo.DataBindings.Add("Value", Dt_Produce, "Date_JiaoHuo", True, DataSourceUpdateMode.OnPropertyChanged, "")
            ''DP_KaiDan.DataBindings.Add("Value", Dt_Produce, "Date_KaiDan", True, DataSourceUpdateMode.OnPropertyChanged, "")
            ''DP_LuoSe.DataBindings.Add("Value", Dt_Produce, "Date_LuoSe", True, DataSourceUpdateMode.OnPropertyChanged, "")
            ''DP_ShouPei.DataBindings.Add("Value", Dt_Produce, "Date_ShouPei", True, DataSourceUpdateMode.OnPropertyChanged, "")

            ''TB_ZhiTong.DataBindings.Add("Text", Dt_Produce, "ZhiTong", True, DataSourceUpdateMode.OnPropertyChanged, 0, PClass.PClass.FormatSharp("num"))
            ''TB_JiaZhong.DataBindings.Add("Text", Dt_Produce, "JiaZhong", True, DataSourceUpdateMode.OnPropertyChanged, 0, PClass.PClass.FormatSharp("num"))

            ' ''客户要求
            'Comfun.setColValue(Dr, CB_CR_ZhuangBaiSe, False, "", Lock)
            'Comfun.setColValue(Dr, CB_CR_QieBian, False, "", Lock)
            'Comfun.setColValue(Dr, CB_CR_YinHuaYong, False, "", Lock)
            'Comfun.setColValue(Dr, CB_CR_RiShai, False, "", Lock)

            'Comfun.setColValue(Dr, CB_CR_GanCa, False, "", Lock)
            'Comfun.setColValue(Dr, CB_CR_ShiCa, False, "", Lock)
            'Comfun.setColValue(Dr, CB_CR_ShiMao, False, "", Lock)
            'Comfun.setColValue(Dr, CB_CR_KaiDing, False, "", Lock)

            'Comfun.setColValue(Dr, CB_CR_KaiZhua, False, "", Lock)
            'Comfun.setColValue(Dr, CB_CR_DanMo, False, "", Lock)
            'Comfun.setColValue(Dr, CB_CR_DanXi, False, "", Lock)
            'Comfun.setColValue(Dr, CB_CR_ShuangJiaoDai, False, "", Lock)

            'Comfun.setColValue(Dr, CB_CR_PaoGan, False, "", Lock)
            'Comfun.setColValue(Dr, CB_CR_SuoShuiJi, False, "", Lock)
            'Comfun.setColValue(Dr, CB_CR_JiangBian, False, "", Lock)

            'Comfun.setColValue(Dr, TB_CR_XiLao, "", "", Lock)
            'Comfun.setColValue(Dr, TB_CR_ChengXi, "", "", Lock)
            'Comfun.setColValue(Dr, TB_CR_ShiYong, "", "", Lock)
            'Comfun.setColValue(Dr, TB_CR_BianDuiBian, "", "", Lock)
            'Comfun.setColValue(Dr, TB_CR_KeZhong, "", "", Lock)

            'Comfun.setColValue(Dr, TB_CR_HengSuo, "", "", Lock)
            'Comfun.setColValue(Dr, TB_CR_ZhiSuo, "", "", Lock)
            'Comfun.setColValue(Dr, TB_CR_NiuDu, "", "", Lock)
            'Comfun.setColValue(Dr, TB_CR_LuoSeBzCount, "", "", Lock)
            'Comfun.setColValue(Dr, TB_CR_LuoSeBzZL, "", "", Lock)


            ''CB_CR_ZhuangBaiSe.DataBindings.Add("Checked", Dt_Produce, "CR_ZhuangBaiSe", True, DataSourceUpdateMode.OnPropertyChanged)
            ''CB_CR_QieBian.DataBindings.Add("Checked", Dt_Produce, "CR_QieBian", True, DataSourceUpdateMode.OnPropertyChanged)
            ''CB_CR_YinHuaYong.DataBindings.Add("Checked", Dt_Produce, "CR_YinHuaYong", True, DataSourceUpdateMode.OnPropertyChanged)
            ''CB_CR_RiShai.DataBindings.Add("Checked", Dt_Produce, "CR_RiShai", True, DataSourceUpdateMode.OnPropertyChanged)

            ''CB_CR_GanCa.DataBindings.Add("Checked", Dt_Produce, "CR_GanCa", True, DataSourceUpdateMode.OnPropertyChanged)
            ''CB_CR_ShiCa.DataBindings.Add("Checked", Dt_Produce, "CR_ShiCa", True, DataSourceUpdateMode.OnPropertyChanged)
            ''CB_CR_ShiMao.DataBindings.Add("Checked", Dt_Produce, "CR_ShiMao", True, DataSourceUpdateMode.OnPropertyChanged)
            ''CB_CR_KaiDing.DataBindings.Add("Checked", Dt_Produce, "CR_KaiDing", True, DataSourceUpdateMode.OnPropertyChanged)

            ''CB_CR_KaiZhua.DataBindings.Add("Checked", Dt_Produce, "CR_KaiZhua", True, DataSourceUpdateMode.OnPropertyChanged)
            ''CB_CR_DanMo.DataBindings.Add("Checked", Dt_Produce, "CR_DanMo", True, DataSourceUpdateMode.OnPropertyChanged)
            ''CB_CR_DanXi.DataBindings.Add("Checked", Dt_Produce, "CR_DanXi", True, DataSourceUpdateMode.OnPropertyChanged)
            ''CB_CR_ShuangJiaoDai.DataBindings.Add("Checked", Dt_Produce, "CR_ShuangJiaoDai", True, DataSourceUpdateMode.OnPropertyChanged)

            ''CB_CR_PaoGan.DataBindings.Add("Checked", Dt_Produce, "CR_PaoGan", True, DataSourceUpdateMode.OnPropertyChanged)
            ''CB_CR_SuoShuiJi.DataBindings.Add("Checked", Dt_Produce, "CR_SuoShuiJi", True, DataSourceUpdateMode.OnPropertyChanged)
            ''CB_CR_JiangBian.DataBindings.Add("Checked", Dt_Produce, "CR_JiangBian", True, DataSourceUpdateMode.OnPropertyChanged)

            ''TB_CR_XiLao.DataBindings.Add("Text", Dt_Produce, "CR_XiLao", True, DataSourceUpdateMode.OnPropertyChanged)
            ''TB_CR_ChengXi.DataBindings.Add("Text", Dt_Produce, "CR_ChengYiXiShui", True, DataSourceUpdateMode.OnPropertyChanged)
            ''TB_CR_ShiYong.DataBindings.Add("Text", Dt_Produce, "CR_ShiYong", True, DataSourceUpdateMode.OnPropertyChanged)
            ''TB_CR_BianDuiBian.DataBindings.Add("Text", Dt_Produce, "CR_BianDuiBian", True, DataSourceUpdateMode.OnPropertyChanged)
            ''TB_CR_KeZhong.DataBindings.Add("Text", Dt_Produce, "CR_KeZhong", True, DataSourceUpdateMode.OnPropertyChanged)

            ''TB_CR_HengSuo.DataBindings.Add("Text", Dt_Produce, "CR_HengSuo", True, DataSourceUpdateMode.OnPropertyChanged)
            ''TB_CR_ZhiSuo.DataBindings.Add("Text", Dt_Produce, "CR_ZhiSuo", True, DataSourceUpdateMode.OnPropertyChanged)
            ''TB_CR_NiuDu.DataBindings.Add("Text", Dt_Produce, "CR_NiuDu", True, DataSourceUpdateMode.OnPropertyChanged)
            ''TB_CR_LuoSeBzCount.DataBindings.Add("Text", Dt_Produce, "CR_LuoSeBzCount", False, DataSourceUpdateMode.OnPropertyChanged)
            ''TB_CR_LuoSeBzZL.DataBindings.Add("Text", Dt_Produce, "CR_LuoSeBzZL", False, DataSourceUpdateMode.OnPropertyChanged)

            ''Radio_ZL.DataBindings.Add("Checked", Dt_Produce, "CR_LuoSeType", True, DataSourceUpdateMode.OnPropertyChanged, False)


            'Comfun.setColValue(Dr, TB_DuiSeGangHao, "", "", Lock)
            'Comfun.setColValue(Dr, TB_HeRanGangHao, "", "", Lock)
            'Comfun.setColValue(Dr, TB_KaiDan, "", "", Lock)


            'Comfun.setColValue(Dr, TB_Auditor, "", "", Lock)
            'Comfun.setColValue(Dr, TB_GenDan, "", "GengDanName", Lock)
            'Comfun.setColValue(Dr, TB_CR_NiuDu, "", "", Lock)
            'Comfun.setColValue(Dr, TB_UPD_User, "", "", Lock)

            'Comfun.setColValue(Dr, TB_PB_CountSum, 0, "", Lock)
            'Comfun.setColValue(Dr, TB_PB_ZLSum, 0, "", Lock)


            ''其他
            ''TB_DuiSeGangHao.DataBindings.Add("Text", Dt_Produce, "DuiSeGangHao", True, DataSourceUpdateMode.OnPropertyChanged)
            ''TB_HeRanGangHao.DataBindings.Add("Text", Dt_Produce, "HeRanGangHao", True, DataSourceUpdateMode.OnPropertyChanged)
            ''TB_KaiDan.DataBindings.Add("Text", Dt_Produce, "KaiDan", True, DataSourceUpdateMode.OnPropertyChanged)

            ''TB_Auditor.DataBindings.Add("Text", Dt_Produce, "Auditor", True, DataSourceUpdateMode.OnPropertyChanged)
            ''TB_GenDan.DataBindings.Add("Tag", Dt_Produce, "GengDan", True, DataSourceUpdateMode.OnPropertyChanged, "0")
            ''TB_GenDan.DataBindings.Add("Text", Dt_Produce, "GengDanName", True, DataSourceUpdateMode.OnPropertyChanged, "")
            ''TB_UPD_User.DataBindings.Add("Text", Dt_Produce, "UPD_User", True, DataSourceUpdateMode.OnPropertyChanged)
            'IsBinding = True

            'TB_GenDan.Tag = IsNull(Dr("GengDan"), 0)
            'If IsNull(Dr("CR_LuoSeType"), False) Then
            '    Radio_ZL.Checked = True
            '    Radio_Num.Checked = False
            'Else
            '    Radio_ZL.Checked = False
            '    Radio_Num.Checked = True
            'End If
        End If

        'LB_PBZCount.DataBindings.Add("Text", Dt_Produce, "PBZ_Weight", True, DataSourceUpdateMode.OnPropertyChanged)
        'LB_PBZCount.DataBindings.Add("Tag", Dt_Produce, "PBZ_Count", True, DataSourceUpdateMode.OnPropertyChanged)
        'LB_CBZCount.DataBindings.Add("Text", Dt_Produce, "CBZ_Weight", True, DataSourceUpdateMode.OnPropertyChanged)
        'LB_CBZCount.DataBindings.Add("Tag", Dt_Produce, "CBZ_Count", True, DataSourceUpdateMode.OnPropertyChanged)
        ''配布信息


    End Sub

#End Region

#Region "工具栏事件"

#Region "配布之后保存"


    ''' <summary>
    ''' 因为配布之后就不能更改,所以增加个改色 让他可以颜色和其他内容,但是不能改条数
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_ChangeColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_ChangeColor.Click
        IsPrint = False
        If CheckForm() Then
            ShowConfirm("修改[" & Ch_Name & "]单?                              ", "修改" & Ch_Name, "修改并打印", "取消", AddressOf SaveTabs, AddressOf SaveTabsAndPrint, AddressOf DoNothing)
        End If
    End Sub


#End Region

    Dim IsPrint As Boolean = False
    ''' <summary>
    ''' 保存按钮
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_Modify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Modify.Click
        IsPrint = False

        If TB_CR_LuoSeBzCount.Enabled = True Then
            CheckKC()
        End If
        If CheckForm() Then
            'TB_UPD_User.Text = PClass.PClass.User_Name
            If Mode = Mode_Enum.Add Then
                ShowConfirm("新增[" & Ch_Name & "]单?                              ", "新增并打印", "新增不打印", "取消", AddressOf SetLuoDan, AddressOf SaveProduce, AddressOf DoNothing)
            Else
                ShowConfirm("修改[" & Ch_Name & "]单?                              ", "修改" & Ch_Name, "修改并打印", "取消", AddressOf SaveTabs, AddressOf SaveTabsAndPrint, AddressOf DoNothing)
            End If
        End If

    End Sub



    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SaveTabs()
        '   If PeiBuList1.IsEdited Then
        'If Not PeiBuList1.SavePB() Then
        '    ShowErrMsg("保存配布信息失败！")
        '    Exit Sub
        'End If
        '   End If
        SaveProduce()
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SaveTabsAndPrint()
        IsPrint = True
        '   If PeiBuList1.IsEdited Then
        'If Not PeiBuList1.SavePB() Then
        '    ShowErrMsg("保存配布信息失败！")
        '    Exit Sub
        'End If
        '   End If
        SaveProduce()
    End Sub


    ''' <summary>
    ''' 保存修改
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub SaveProduce()
        Dim R As MsgReturn
        GetForm()
        If Me.Mode = Mode_Enum.Add Then
            R = Dao.ProduceGd_Add(Dt_Produce, Dt_WorkList, Dt_Charge)
        Else
            R = Dao.ProduceGd_Save(Dt_Produce, Dt_WorkList, Dt_Charge)
        End If

        If Cmd_Copy.Visible = False Then
            Dim X As MsgReturn
            X = Dao.ProduceGd_Copy(TB_ID.Text, "", "")
        End If

        If R.IsOk Then
            LastForm.ReturnId = TB_ID.Text

            Mode = Mode_Enum.Modify
            Me.Bill_ID = TB_ID.Text
            LoadForm()

            If IsPrint Then
                Print()
            End If
            'Me.Refresh()
        Else
            ShowErrMsg(R.Msg)
        End If
    End Sub

    Protected Sub SetLuoDan()
        IsPrint = True

        SaveProduce()

    End Sub
    ''' <summary>
    ''' 取消下单
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_XiaDan_Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Me.Dt_Produce.Rows(0)("State") = BaseClass.Enum_ProduceState.AddNew
        SaveProduce()
    End Sub

    Protected Sub DoNothing()

    End Sub


#End Region

#Region "form 验证"
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Function CheckForm() As Boolean
        If Dt_Produce Is Nothing OrElse Dt_Produce.Rows.Count < 1 Then
            ShowErrMsg("表单单内容有误,无法保存!")
            Exit Function
        End If

        'If Not DP_JiaoHuo.Text = "" Then
        '    Dt_Produce.Rows(0)("Date_JiaoHuo") = DP_JiaoHuo.Value.Date
        'End If

        'If Not DP_KaiDan.Text = "" Then
        '    Dt_Produce.Rows(0)("Date_KaiDan") = DP_KaiDan.Value.Date
        'End If
        'If Not DP_LuoSe.Text = "" Then
        '    Dt_Produce.Rows(0)("Date_LuoSe") = DP_LuoSe.Value.Date
        'End If
        'If Not DP_ShouPei.Text = "" Then
        '    Dt_Produce.Rows(0)("Date_ShouPei") = DP_ShouPei.Value.Date
        'End If

        If Cb_BZC.IDAsInt = 0 AndAlso GHType = Enum_GH_Type.Normal Then
            ShowErrMsg("色号不能为空!", AddressOf Cb_BZC.Focus)
            Return False
        End If

        If CB_BZ.IDAsInt = 0 Then
            ShowErrMsg("布种不能为空!", AddressOf CB_BZ.Focus)
            Return False
        End If

        If Val(TB_ClientID.Tag) = 0 Then
            ShowErrMsg("客户不能为空!", AddressOf TB_ClientID.Focus)
            Return False
        End If

        If Radio_Num.Checked Then
            If Val(TB_CR_LuoSeBzCount.Text) <= 0 Then
                ShowErrMsg("落色条数必须是正整数", AddressOf TB_CR_LuoSeBzCount.Focus)
                Return False
            End If
        Else
            If Val(TB_CR_LuoSeBzZL.Text) <= 0 Then
                ShowErrMsg("落色重量必须是正整数", AddressOf TB_CR_LuoSeBzZL.Focus)
                Return False
            End If
        End If


        DP_Date_JiaoHuo.Value = DP_Date_JiaoHuo.Value.Date
        DP_Date_KaiDan.Value = DP_Date_KaiDan.Value.Date
        DP_Date_LuoSe.Value = DP_Date_LuoSe.Value.Date
        DP_Date_ShouPei.Value = DP_Date_ShouPei.Value.Date
        Dt_Produce.Rows(0)("BZC_ID") = Val(Cb_BZC.IDValue)
        Dt_Produce.Rows(0)("BZ_ID") = CB_BZ.IDAsInt
        Dt_Produce.Rows(0)("SG_ID") = CB_SG.IDAsInt
        Dt_Produce.Rows(0)("Client_ID") = Val(TB_ClientID.Tag)
        Dt_Produce.Rows(0)("GengDan") = Val(TB_GenDan.Tag)
        TB_GangCi.Text = Val(TB_GangCi.Text)
        TB_GangShu.Text = Val(TB_GangShu.Text)
        TB_CR_LuoSeBzZL.Text = Val(TB_CR_LuoSeBzZL.Text)
        TB_CR_LuoSeBzCount.Text = Val(TB_CR_LuoSeBzCount.Text)

        Return True
    End Function
#End Region

#Region "Form 事件"
#Region "获取新单号"
    Private Sub Label_No_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LB_No.Click
        If Mode = Mode_Enum.Add Then
            ShowConfirm("是否获取新单号?", AddressOf GetNewID)
        Else
            ShowErrMsg("非新增状态不能修改单号!")
        End If
    End Sub

    Sub GetNewID()
        If Mode = Mode_Enum.Add Then
            If DP_Date_KaiDan.Value <> Bill_ID_Date Then
                Dim R As RetrunNewIdMsg = ComFun.GetBillNewID(BillType.Produce, DP_Date_KaiDan.Value, Bill_ID)
                If R.IsOk Then
                    Bill_ID_Date = R.NewIdDate
                    DP_Date_KaiDan.MinDate = R.MaxDate.AddDays(1)
                    DP_Date_KaiDan.Value = R.NewIdDate
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

    Private Sub DP_KaiDan_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles DP_Date_KaiDan.Validated
        GetNewID()
    End Sub

#End Region
#Region "双击获取新编号"


    Private Sub TB_No_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TB_ID.MouseDoubleClick
        If Mode = Mode_Enum.Add Then
            GetNewID()
        End If

    End Sub
#End Region
    Private Sub LB_Remark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LB_Remark.Click
        ShowRemarkList()
    End Sub
    Protected Sub ShowRemarkList()
        Dim f As PClass.BaseForm = LoadFormIDToChild(10202, Me)
        If f Is Nothing Then Exit Sub
        f.P_F_RS_ID = TB_Remark.Text
        f.P_F_RS_ID2 = "/"

        Me.ReturnId = ""
        Me.ReturnObj = Nothing
        Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(f, Me)
        '  VF.Width = 800
        '  VF.Height = 400
        AddHandler VF.ClosedX, AddressOf setRemark
        VF.Show()
    End Sub

    Sub setRemark()
        If Me.ReturnMsg = "" Then
            Exit Sub
        End If

        Me.TB_Remark.Text = Me.ReturnMsg

        Me.ReturnMsg = ""
    End Sub

    ''' <summary>
    ''' 获取备注信息
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_ChooseRemark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_ChooseRemark.Click
        ShowRemarkList()
    End Sub

    ''' <summary>
    ''' 获取加工类型
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub LB_ProcessType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LB_ProcessType.Click
        Dim f As PClass.BaseForm = LoadFormIDToChild(10204, Me)
        If f Is Nothing Then Exit Sub
        f.P_F_RS_ID = TB_ProcessType.Text
        f.P_F_RS_ID2 = "/"

        Me.ReturnId = ""
        Me.ReturnObj = Nothing
        Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(f, Me)
        '  VF.Width = 800
        '  VF.Height = 400
        AddHandler VF.ClosedX, AddressOf SetProcessType
        VF.Show()
    End Sub

    Protected Sub SetProcessType()
        TB_ProcessType.Text = Me.ReturnMsg
        Me.ReturnMsg = ""
    End Sub
#End Region

#Region "搜索色号"


    Private Sub Cb_BZC_Col_Sel(ByVal Col_No As String, ByVal Col_Name As String, ByVal ID As String) Handles Cb_BZC.Col_Sel
        TB_BZCName.Text = Col_Name
        If ID Is Nothing Then
            Exit Sub
        End If
        CB_BZ.SearchID = ID

        '  TB_BZCID.Text = Bzc_Name & vbCrLf & Bzc_No
        CB_BZ.Enabled = True
        Dim msgBz As DtReturnMsg = Dao.ProduceGd_GetBZListByBzcID(Val(ID))
        If msgBz.IsOk And msgBz.Dt.Rows.Count > 0 Then
            Dim msg As DtReturnMsg = Dao.ProduceGd_GetClientBZC(Val(ID), 0)
            If msg.IsOk And msg.Dt.Rows.Count > 0 Then
                Dim Rs() As DataRow = msgBz.Dt.Select("BZ_ID='" & CB_BZ.IDAsInt & "'") '先搜索原来已经选择的布种编号
                If Rs.Length > 0 Then
                    CB_BZ.IDAsInt = IsNull(Rs(0)("BZ_ID"), 0)
                    CB_BZ.Text = CB_BZ.GetByTextBoxTag()
                    TB_BZName.Text = CB_BZ.NameValue
                    TB_ClientBZC.Text = IsNull(Rs(0)("Client_Bzc"), "")
                    Cmd_BZCName.Enabled = True

                Else '如果没有搜索到 就用默认的布种编号
                    Dim Row As DataRow = msgBz.Dt.Select("Client_Bzc='" & IsNull(msg.Dt.Rows(0)("Client_Bzc"), "") & "'")(0)
                    CB_BZ.IDAsInt = IsNull(Row("BZ_ID"), 0)
                    CB_BZ.Text = CB_BZ.GetByTextBoxTag()
                    TB_BZName.Text = CB_BZ.NameValue
                    TB_ClientBZC.Text = IsNull(Row("Client_Bzc"), "")
                    Cmd_BZCName.Enabled = True
                End If
            Else
                TB_ClientBZC.Text = ""
            End If
        Else
            CB_BZ.Text = ""
            CB_BZ.IDAsInt = 0
            TB_BZName.Text = ""
        End If



        Dim msgClient As DtReturnMsg = Dao.ProduceGd_GetClientByBzcID(Val(ID))
        If msgClient.IsOk And msgClient.Dt.Rows.Count > 0 Then
            TB_ClientID.Tag = IsNull(msgClient.Dt.Rows(0)("Client_ID"), "")
            TB_ClientID.Text = IsNull(msgClient.Dt.Rows(0)("Client_No"), "")
            TB_ClientName.Text = IsNull(msgClient.Dt.Rows(0)("Client_Name"), "")
        Else
            'TB_ClientID.Text = ""
            'TB_ClientName.Text = ""
        End If

        '加载色板集合
        LoadPF(ID)

        CB_BZ.LastTextIndex = 0
        CB_BZ.LastTextLen = CB_BZ.Text.Length
        CB_BZ.SelectionStart = 0
        CB_BZ.SelectionLength = CB_BZ.Text.Length
        CB_BZC_PF.Enabled = True
        Cmd_AddBZ.Enabled = True
        CB_BZC_PF.Focus()
    End Sub




    Private Sub LoadPF(ByVal BZC_ID As Integer)
        Dim R As DtReturnMsg = Dao.Produce_GetBZCPF(BZC_ID)
        Dim T As String = CB_BZC_PF.Text
        If R.IsOk Then

            CB_BZC_PF.DisplayMember = "PF_Name"
            CB_BZC_PF.ValueMember = "PF_Name"
            Dim newDr As DataRow = R.Dt.NewRow
            newDr("PF_Name") = ""
            R.Dt.Rows.InsertAt(newDr, 0)
            CB_BZC_PF.DataSource = R.Dt
        Else
            CB_BZC_PF.DataSource = Nothing
        End If


        CB_BZC_PF.Text = T
    End Sub




#End Region

#Region "获取色板"


#End Region

#Region "报表事件"

    Private Sub Report_PrintCompleted() Handles Report.PrintCompleted
        Dim R As DtReturnMsg = Dao.Produce_GetState(TB_ID.Text)
        If R.IsOk AndAlso R.Dt.Rows.Count > 0 Then
            SetState(R.Dt.Rows(0)(0))
            Me.Dt_Produce.Rows(0)("State") = R.Dt.Rows(0)(0)
            SetTab()
        End If
    End Sub
    Private Sub Btn_Preview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Preview.Click
        Print(OperatorType.Preview)
    End Sub

    Private Sub Btn_Print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Print.Click
        Print(OperatorType.Print)
    End Sub

    Dim WithEvents Report As R30000_ProduceGd

    Protected Sub Print(ByVal DoOperator As OperatorType)
        If Me.Mode = Mode_Enum.Add Then
            Exit Sub
        End If
        Report = New R30000_ProduceGd(CheckRight(ID, ClassMain.CanExcelOut))
        Report.Start(Dt_Produce, DoOperator)
    End Sub
    Protected Sub Print()
        Print(OperatorType.Print)
    End Sub

#End Region

#Region "作废，还原"

    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click

        Me.Close()
    End Sub
    ''' <summary>
    ''' 删除
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_Del_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmd_Del.Click
        If Mode = Mode_Enum.Modify Then
            ShowConfirm("确定删除" & Dao.Produce_Gd_Name & "[" & TB_ID.Text & "]?", AddressOf DelProduce)
        End If
    End Sub


    Protected Sub DelProduce()
        Dim msg As MsgReturn = Dao.ProduceGd_Del(TB_ID.Text)
        If msg.IsOk = False Then
            LastForm.ReturnId = TB_ID.Text
            ShowErrMsg(msg.Msg)
        Else
            Me.Close()
        End If
    End Sub

    ''' <summary>
    ''' 作废
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_Invalid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Invalid.Click
        If Mode = Mode_Enum.Modify Then
            ShowConfirm("确定作废" & Dao.Produce_Gd_Name & "[" & TB_ID.Text & "]?", AddressOf InvalidProduce)
        End If
    End Sub


    Protected Sub InvalidProduce()

        Dim msg As MsgReturn = Dao.Produce_Invalid(TB_ID.Text)
        If msg.IsOk Then
            ShowOk("缸号" & TB_ID.Text & "已作废!")
            Me.LoadForm()
        Else
            ShowErrMsg(msg.Msg)
        End If
    End Sub




    ''' <summary>
    ''' 还原运转单状态到新建
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_SetValid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_SetValid.Click
        Dim R As DtReturnMsg = Dao.ProduceGd_GetById(TB_ID.Text)
        If R.IsOk AndAlso R.Dt.Rows(0)("State") < Enum_ProduceState.RanSe Then
            Dim msg As MsgReturn = Dao.ProduceGd_UpdateState(TB_ID.Text, Enum_ProduceState.AddNew)
            If msg.IsOk = False Then
                ShowErrMsg(msg.Msg)
            Else
                '  Me.Close()
                Me.LoadForm()
            End If
        Else
            Dim stateName As String = BaseClass.ComFun.GetProduceStateName(IsNull(R.Dt.Rows(0)("State"), Enum_ProduceState.AddNew))
            ShowErrMsg("运转单[" & TB_ID.Text & "]状态为：" & stateName & "，不能还原到新建状态！")
        End If
    End Sub


#End Region

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Radio_Num_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Radio_Num.CheckedChanged, Radio_ZL.CheckedChanged
        If Radio_Num.Checked Then
            TB_CR_LuoSeBzZL.ReadOnly = True
            If Dt_Produce.Rows.Count > 0 Then Dt_Produce.Rows(0)("CR_LuoSeBzZL") = DBNull.Value
        Else
            TB_CR_LuoSeBzZL.ReadOnly = False
        End If

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_SelectBZ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim F As PClass.BaseForm = PClass.PClass.LoadFormIDToChild(40500, Me)
        With F
            .Mode = Mode_Enum.Add
            .P_F_RS_ID = ""
            .P_F_RS_ID2 = ""
        End With
        F_RS_ID = ""
        Me.ReturnId = ""
        Me.ReturnObj = Nothing
        Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F, Me)
        VF.MaximizeBox = True

        '   AddHandler VF.ClosedX, AddressOf GetStoreNo

        VF.Show()
    End Sub

#Region "tab 事件"
    Private Sub SetTab()
        Tabs.Visible = False
        Tabs.TabPages.Clear()
        If Me.Mode = Mode_Enum.Add Then


            Tabs.TabPages.Add(Tab_Gd)
        Else
            Select Case IsNull(Me.Dt_Produce.Rows(0)("State"), Enum_ProduceState.AddNew)
                Case Enum_ProduceState.AddNew, Enum_ProduceState.Invalid
                    Tabs.TabPages.Add(Tab_Gd)
                Case Enum_ProduceState.XiaDan
                    Tabs.TabPages.Add(Tab_Gd)
                    Tabs.TabPages.Add(Tab_PB)
                Case Enum_ProduceState.PeiBu
                    Tabs.TabPages.Add(Tab_Gd)
                    Tabs.TabPages.Add(Tab_PB)
                Case Enum_ProduceState.PeiBu
                    Tabs.TabPages.Add(Tab_Gd)
                    Tabs.TabPages.Add(Tab_PB)
                Case Else
                    Tabs.TabPages.Add(Tab_Gd)
            End Select
        End If
        Tabs.Visible = True
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TabControl1_TabIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Tabs.SelectedIndexChanged
        'If Tabs.SelectedIndex <> 0 AndAlso IsNull(Dt_Produce.Rows(0)("State"), 0) < Enum_ProduceState.XiaDan Then
        '    ShowErrMsg("没有确认下单不能编辑其他项！")
        '    '   Tabs.SelectTab(0)
        '    Exit Sub
        'End If
        Select Case Tabs.SelectedIndex
            Case 0
            Case 2
                If Me.PeiBuList1.IsLoaded = False Then
                    If Me.Dt_Produce IsNot Nothing Then
                        Try
                            Me.PeiBuList1.LoadData(IsNull(Dt_Produce.Rows(0)("PB_ZLSum"), 0), IsNull(Dt_Produce.Rows(0)("PB_CountSum"), 0))
                        Catch ex As Exception

                        End Try

                    End If


                End If
        End Select
    End Sub
#End Region


#Region "拆缸"
    Private Sub Cmd_CG_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_CG.Click
        If Mode = Mode_Enum.Add Then
            Exit Sub
        End If
        Dim F As PClass.BaseForm
        If LB_State.Tag IsNot Nothing AndAlso LB_State.Tag < Enum_ProduceState.PeiBu Then
            F = New F30007_Produce_CG_BeforePB(Me)
        Else
            F = New F30002_Produce_CG(Me)
        End If
        'F = New F30002_Produce_CG(Me)
        With F
            .Mode = Mode_Enum.Add
            .P_F_RS_ID = ""
            .P_F_RS_ID2 = ""
        End With
        F_RS_ID = ""
        Me.ReturnId = ""
        Me.ReturnObj = Nothing
        Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F, Me)
        AddHandler VF.ClosedX, AddressOf CG_Retrun
        VF.Show()
    End Sub

    Sub CG_Retrun()
        Dim Dt_WorkListCache As DataTable = Dt_WorkList.Copy
        If ReturnId <> "" Then
            LastForm.ReturnId = ReturnId
            Mode = Mode_Enum.Modify
            Me.Bill_ID = ReturnId
            LoadForm()
            Me.Refresh()
            Dt_WorkList = Dt_WorkListCache.Copy
            For i As Integer = Fg2.Rows.Count - 1 To 1 Step -1
                Fg2.Rows.Remove(i)
            Next
            Fg1.DtToSetFG(Dt_WorkList)
            If Me.Dt_Produce.Rows(0)("State") = BaseClass.Enum_ProduceState.XiaDan Then
                ShowConfirm("是否打印?", AddressOf Print)
            End If

        End If
    End Sub

    ''' <summary>
    ''' 转移
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_Change_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_ChangePB.Click
        If Mode = Mode_Enum.Add Then
            Exit Sub
        End If
        Dim F As PClass.BaseForm
        If LB_State.Tag IsNot Nothing AndAlso LB_State.Tag < Enum_ProduceState.PeiBu Then
            F = New F30007_Produce_CG_BeforePB(Me, False, CB_GH.Text)
        Else
            F = New F30002_Produce_CG(Me, False, CB_GH.Text)
        End If
        'F = New F30002_Produce_CG(Me)
        With F
            .Mode = Mode_Enum.Add
            .P_F_RS_ID = ""
            .P_F_RS_ID2 = ""
        End With
        F_RS_ID = ""
        Me.ReturnId = ""
        Me.ReturnObj = Nothing
        Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F, Me)
        AddHandler VF.ClosedX, AddressOf CG_Retrun
        VF.Show()
    End Sub
#End Region

#Region "自动添加单位"
    Sub AddUnitTextBox()
        AddHandler TB_CR_ZhiSuo.LostFocus, AddressOf AddUnit
        AddHandler TB_CR_HengSuo.LostFocus, AddressOf AddUnit
        AddHandler TB_CR_NiuDu.LostFocus, AddressOf AddUnit
        AddHandler TB_CR_BianDuiBian.LostFocus, AddressOf AddUnit
        AddHandler TB_CR_KeZhong.LostFocus, AddressOf AddUnit
        AddHandler TB_CR_ShiYong.LostFocus, AddressOf AddUnit
        AddHandler TB_CR_XiLao.LostFocus, AddressOf AddUnit
    End Sub


    Private Sub AddUnit(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim TB As TextBox = TryCast(sender, TextBox)
        If Val(TB.Text) <> 0 AndAlso Not TB.Text.Contains(TB.Tag) Then
            TB.Text = TB.Text & TB.Tag
        End If
    End Sub
#End Region

#Region "增加布种"
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_AddBZ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_AddBZ.Click
        If Val(Cb_BZC.IDValue) <> 0 Then
            Dim F As PClass.BaseForm = New F30003_AddBZ(Val(Cb_BZC.IDValue))
            With F
                .Mode = Mode_Enum.Modify
                .P_F_RS_ID = ""
                .P_F_RS_ID2 = ""
            End With
            F_RS_ID = ""
            Me.ReturnId = ""
            Me.ReturnObj = Nothing
            Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F, Me)
            AddHandler VF.ClosedX, AddressOf AddBZ_Retrun
            VF.Show()
        End If

    End Sub

    Sub AddBZ_Retrun()
        If ReturnId <> "" Then
            'TB_BZID.Focus()
            If CB_BZ.Enabled Then
                CB_BZ.IDAsInt = ReturnId
                CB_BZ.Text = CB_BZ.GetByTextBoxTag
                TB_BZName.Text = CB_BZ.NameValue
            End If
        End If
    End Sub

#End Region


#Region "布种修改名字"
    Private Sub Cmd_BZName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_BZName.Click
        ShowInput("修改布种[" & CB_BZ.Text & "]的名称:", AddressOf ChangeBZ_Name, TB_BZName.Text)
    End Sub

    Sub ChangeBZ_Name(ByVal s As String)
        If s <> "" Then
            Dim R As MsgReturn = Dao.Bz_Rename(CB_BZ.IDAsInt, s)
            If R.IsOk Then
                CB_BZ.Text = CB_BZ.GetByTextBoxTag()
                TB_BZName.Text = CB_BZ.NameValue
            Else
                ShowErrMsg("修改失败!")
            End If
        End If
    End Sub
    '
    Private Sub Cmd_Cmd_BZNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_BZNo.Click
        ShowInput("修改布种[" & Cmd_BZNo.Text & "]的名称:", AddressOf ChangeBZNo, CB_BZ.Text)
    End Sub

    Sub ChangeBZNo(ByVal s As String)
        If s <> "" Then
            Dim R As MsgReturn = Dao.Bz_No_Rename(CB_BZ.IDAsInt, s)
            If R.IsOk Then
                CB_BZ.Text = CB_BZ.GetByTextBoxTag()
                TB_BZName.Text = CB_BZ.NameValue
            Else
                ShowErrMsg("修改失败!")
            End If
        End If
    End Sub

    Private Sub Cmd_BZCName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_BZCName.Click
        ShowInput("修改色号[" & Cb_BZC.Text & "]的颜色名称:", AddressOf ChangeBZCName, TB_BZCName.Text)
    End Sub

    Sub ChangeBZCName(ByVal s As String)
        If s <> "" Then
            Dim R As MsgReturn = Dao.Bzc_Rename(Cb_BZC.IDAsInt, s)
            If R.IsOk Then
                Cb_BZC.Text = Cb_BZC.GetByTextBoxTag()
                TB_BZCName.Text = Cb_BZC.NameValue
            Else
                ShowErrMsg("修改失败!")
            End If
        End If
    End Sub

    Private Sub CB_BZ_Col_Sel(ByVal Col_No As String, ByVal Col_Name As String, ByVal ID As String) Handles CB_BZ.Col_Sel
        TB_BZName.Text = Col_Name

        Dim msg As DtReturnMsg = Dao.ProduceGd_GetClientBZC(Cb_BZC.IDValue, ID)
        If msg.IsOk And msg.Dt.Rows.Count > 0 Then
            TB_ClientBZC.Text = IsNull(msg.Dt.Rows(0)("Client_Bzc"), "")
        Else
            TB_ClientBZC.Text = ""
        End If
        'Cmd_BZName.Enabled = True
        ' Cmd_BZNo.Enabled = True
        ''获取客户最近的备注
        If Mode = Mode_Enum.Add AndAlso TB_ClientID.Tag IsNot Nothing Then
            Dim R As DtReturnMsg = Dao.Produce_GetClientRemark(TB_ClientID.Tag, ID)
            If R.IsOk AndAlso R.Dt.Rows.Count > 0 Then
                Dim Dr As DataRow = R.Dt.Rows(0)
                Dim Lock As Boolean = False
                ComFun.SetColValue(Dr, TB_Address, "", "", Lock)
                ComFun.SetColValue(Dr, TB_ProcessType, "", "", Lock)
                ComFun.SetColValue(Dr, TB_Remark, "", "", Lock)

                ComFun.SetColValue(Dr, TB_ZhiTong, 0, "", Lock, FormatSharp("zhitong"))
                ComFun.SetColValue(Dr, TB_JiaZhong, 0, "", Lock, FormatSharp("jiazhong"))


                ''客户要求
                ComFun.SetColValue(Dr, TB_CR_XiLao, "", "", Lock)
                ComFun.SetColValue(Dr, TB_CR_ChengYiXiShui, "", "", Lock)
                ComFun.SetColValue(Dr, TB_CR_ShiYong, "", "", Lock)
                ComFun.SetColValue(Dr, TB_CR_BianDuiBian, "", "", Lock)
                ComFun.SetColValue(Dr, TB_CR_KeZhong, "", "", Lock)

                ComFun.SetColValue(Dr, TB_CR_HengSuo, "", "", Lock)
                ComFun.SetColValue(Dr, TB_CR_ZhiSuo, "", "", Lock)
                ComFun.SetColValue(Dr, TB_CR_NiuDu, "", "", Lock)
            End If
        End If
    End Sub
#End Region

#Region "复制"

    Private Sub Cmd_Copy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Copy.Click

        If Not GHType = Enum_GH_Type.Normal OrElse IsNull(Dt_Produce.Rows(0)("IsFG"), False) = True Then
            ShowErrMsg("返定布和返工布以及退胚不能复制!")
            Exit Sub
        End If

        Mode = Mode_Enum.Add
        TB_CR_LuoSeBzCount.ReadOnly = False
        Bill_ID_Date = #1/1/1999#

        LB_State.Text = "复制缸号" & TB_ID.Text & "的内容"
        GetNewID()
        Cmd_Modify.Visible = Cmd_Modify.Tag
        Cmd_Modify.Enabled = True
        Cmd_Copy.Visible = False

        Cmd_Invalid.Visible = False
        Cmd_SetValid.Visible = False
        Cmd_Del.Visible = False
        Cmd_CG.Visible = False
        Cmd_Preview.Enabled = False
        Cmd_Print.Enabled = False
        TB_PB_CountSum.Text = 0
        TB_PB_ZLSum.Text = 0
        CB_GH.Visible = False
        LabelGH.Visible = False

        Cb_BZC.Enabled = True
        CB_BZ.Enabled = True
        CB_BZC_PF.Enabled = True
        Cmd_FG.Visible = False
        Cmd_ShowList.Visible = False
        TB_KaiDan.Text = User_Display
        ClearWork_list()
    End Sub

    ''' <summary>
    '''  复制时清空工序状态
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ClearWork_list()

        For i As Integer = Fg1.Rows.Count - 1 To 1 Step -1
            Fg1.Item(i, "StartTime") = ""
            Fg1.Item(i, "FinishTime") = ""
            Fg1.Item(i, "StateName") = ""
            Fg1.Item(i, "State") = ""
        Next
        Dt_Charge.Clear()
        Dim dt As DataTable
        DP_Date_JiaoHuo.Checked = False
        DP_Date_ShouPei.Checked = False
        TB_UPD_USER.Text = ""
        PeiBuList1.iniForm(dt, Me)
        TB_SumAmount.Text = ""
        DP_Date_KaiDan.Text = Today
        DP_Date_LuoSe.Text = Today

        For i As Integer = Fg2.Rows.Count - 1 To 1 Step -1
            Fg2.Rows.Remove(i)
        Next

    End Sub

    Private Sub Cmd_FG_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_FG.Click

        Mode = Mode_Enum.Add

        LB_State.Text = "返工缸号" & TB_ID.Text
        TB_ID.Text = TB_ID.Text & "R"

        Dt_Produce.Rows(0)("IsFG") = True
        Cmd_Modify.Visible = Cmd_Modify.Tag
        Cmd_Modify.Enabled = True
        Cmd_Copy.Visible = False
        TB_CR_LuoSeBzCount.ReadOnly = False
        Cmd_Invalid.Visible = False
        Cmd_SetValid.Visible = False
        Cmd_Del.Visible = False
        Cmd_CG.Visible = False
        Cmd_Preview.Enabled = False
        Cmd_Print.Enabled = False
        TB_PB_CountSum.Text = 0
        TB_PB_ZLSum.Text = 0
        LabelGH.Visible = False
        CB_GH.Visible = False
        Cb_BZC.Enabled = True
        CB_BZ.Enabled = True
        CB_BZC_PF.Enabled = True
        Cmd_FG.Visible = False
        Cmd_ShowList.Visible = False



        LabelFDFG.Text = "返工"
        LabelFDFG.Visible = True

    End Sub

#End Region
    Private Sub Cmd_ShowList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_ShowList.Click
        Dim F As New F30004_Produce_Amount()
        With F
            .Mode = Mode_Enum.Add
            .P_F_RS_ID = TB_ID.Text
            .P_F_RS_ID2 = ""
        End With
        F_RS_ID = ""
        Me.ReturnId = ""
        Me.ReturnObj = Nothing
        Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F, Me)
        VF.Show()
    End Sub

#Region "工序"

#Region "工具栏事件"

#Region "清空工序栏列表"
    ''' <summary>
    ''' 清空工序栏列表
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Cmd_ClearAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_ClearAll.Click

        ShowConfirm("是否清空工序列表", AddressOf ClareWorkList)

    End Sub
    Private Sub ClareWorkList()
        For i As Integer = Fg1.Rows.Count - 1 To 1 Step -1
            Fg1.Rows.Remove(i)
        Next
    End Sub
#End Region



    ''' <summary>
    ''' 保存按钮
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Cmd_WorkList_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_WorkList_Save.Click
        Dim R As MsgReturn
        GetWork_List()
        R = Dao.WorkList_Save(Dt_WorkList, Dt_Charge)
        If R.IsOk Then
            ShowOk(R.Msg, False)
        Else
            ShowErrMsg(R.Msg)
        End If

    End Sub

    ''' <summary>
    ''' 是否可编辑
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Cmd_Edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Edit.Click
        Cmd_Edit.Checked = Not Cmd_Edit.Checked

        If Cmd_Edit.Checked = True Then
            Fg1.CanEditing = True
            Fg1.Cols("StateName").Editor = CB_State
        Else
            Fg1.FinishEditing()
            Fg1.CanEditing = False
            Fg1.Cols("StateName").Editor = Nothing
        End If
    End Sub

    ''' <summary>
    ''' 获取集俣
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Cmd_WorkList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_WorkList.Click
        GetGoods()
    End Sub

    ''' <summary>
    ''' 前加
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Cmd_AddRowBefore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_AddRowBefore.Click
        Beforechoose(False)
    End Sub

    ''' <summary>
    ''' 后加
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Cmd_AddRowAfter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_AddRowAfter.Click
        Afterchoose(False)
    End Sub

    ''' <summary>
    ''' 删行
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Cmd_RemoveRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_RemoveRow.Click
        Remove(Cmd_Show.Checked)
    End Sub

    ''' <summary>
    ''' 上移
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Cmd_UP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_UP.Click
        Upmove()
    End Sub

    ''' <summary>
    ''' 下移
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Cmd_Down_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Down.Click
        DownMove()
    End Sub

    ''' <summary>
    ''' 显示加工内容
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Show.Click
        SplitContainer1.Panel1Collapsed = Not SplitContainer1.Panel1Collapsed

        Cmd_Show.Checked = Not Cmd_Show.Checked
        SplitContainer2.Panel2Collapsed = Cmd_Show.Checked
        Cmd_AddShow(Cmd_Show.Checked)
        Dim msgWork_Get As DtReturnMsg = Dao.Work_Get()
        If msgWork_Get.IsOk Then
            Try
                ComFun.Dt_LeftJoin(msgWork_Get.Dt, BaseClass.ComFun.GH_GetStateTable(), "Process_Name", "StateName", "Process", "State", "State=%Process%")
                Fg_Sel.DtToFG(msgWork_Get.Dt)
            Catch ex As Exception
                DebugToLog(ex)
            End Try

        End If

    End Sub

#End Region

#Region "FG事件"
    ''' <summary>
    ''' 添加加工内容事件
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Fg_Sel_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Fg_Sel.DoubleClick
        Afterchoose(True)
    End Sub

    ''' <summary>
    ''' 删除加工内容事件
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Fg1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Fg1.DoubleClick
        If SplitContainer1.Panel1Collapsed = False Then
            Remove(True)
        End If
    End Sub

    ''' <summary>
    ''' 添加当前时间
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Fg1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Fg1.Click
        'SplitContainer2.Panel2Collapsed = False
        If Fg1.RowSel < 1 Then
            Exit Sub
        End If
        Fg2.DtToFG(ShowCharge(Fg1.Item(Fg1.RowSel, "Work_ID")))
        If Fg1.Cols("StartTime").Index = Fg1.ColSel AndAlso Cmd_Edit.Checked Then
            If Fg1.Item(Fg1.RowSel, "StartTime") Is Nothing OrElse Fg1.Item(Fg1.RowSel, "StartTime").ToString = "" Then
                Fg1.Item(Fg1.RowSel, "StartTime") = GetTime()
            Else
                Fg1.Item(Fg1.RowSel, "StartTime") = ""
            End If
        End If
        If Fg1.Cols("FinishTime").Index = Fg1.ColSel AndAlso Cmd_Edit.Checked Then
            If Fg1.Item(Fg1.RowSel, "FinishTime") Is Nothing OrElse Fg1.Item(Fg1.RowSel, "FinishTime").ToString = "" Then
                Fg1.Item(Fg1.RowSel, "FinishTime") = GetTime()
            Else
                Fg1.Item(Fg1.RowSel, "FinishTime") = ""
            End If
        End If
    End Sub

    ''' <summary>
    ''' 修改状态
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CB_State_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CB_State.SelectedIndexChanged
        If Fg1.RowSel < 1 Then
            Exit Sub
        End If
        Fg1.Item(Fg1.RowSel, "State") = CB_State.SelectedValue

        If Fg1.Cols("StateName").Index = Fg1.ColSel AndAlso Cmd_Edit.Checked = True Then
            For i As Integer = 1 To Fg1.Rows.Count - 1
                If i < Fg1.RowSel Then
                    Fg1.Item(i, "StateName") = ComFun.GetWorkStateName(Enum_WorkState.Finish)
                    Fg1.Item(i, "State") = Enum_WorkState.Finish
                ElseIf i > Fg1.RowSel Then
                    Fg1.Item(i, "StateName") = ComFun.GetWorkStateName(Enum_WorkState.None)
                    Fg1.Item(i, "State") = Enum_WorkState.None
                End If
            Next
        End If
        CB_State.Visible = False
    End Sub
#End Region

#Region "方法"
    ''' <summary>
    ''' 获取加工集合
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub GetGoods()
        Dim f As PClass.BaseForm = LoadFormIDToChild(10052, Me)
        If f Is Nothing Then Exit Sub
        With f
            .P_F_RS_ID = ""
            .P_F_RS_ID2 = ""
            .P_F_RS_ID4 = ""
            .IsSel = True
        End With
        ReturnId = ""
        Me.ReturnObj = Nothing
        Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(f, Me)
        AddHandler VF.ClosedX, AddressOf GetGoodsAll
        VF.Show()
    End Sub

    ''' <summary>
    ''' 获取加工集合合刷新工序列表
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub GetGoodsAll()
        If ReturnId <> "" Then
            GetWorkList(CLng(ReturnId))
        End If

    End Sub

    Private Sub GetWorkList(ByVal id As Long)
        Dim msgList As DtReturnMsg = Dao.List_GetById(id)
        If msgList.IsOk Then
            For i As Integer = 0 To msgList.Dt.Rows.Count - 1
                Fg1.AddRow()
                Fg1.Item(Fg1.Rows.Count - 1, "Work_No") = msgList.Dt.Rows(i)("Work_No")
                Fg1.Item(Fg1.Rows.Count - 1, "Work_Name") = msgList.Dt.Rows(i)("Work_Name")
                Fg1.Item(Fg1.Rows.Count - 1, "Dept_Name") = msgList.Dt.Rows(i)("Dept_Name")
                Fg1.Item(Fg1.Rows.Count - 1, "Process_Name") = msgList.Dt.Rows(i)("Process_Name")
                Fg1.Item(Fg1.Rows.Count - 1, "Work_ID") = ComFun.GetLineID
            Next
        End If

    End Sub



    ''' <summary>
    ''' 前加
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Beforechoose(ByVal show As Boolean)
        Dim index As Integer = 1
        ReturnId = Fg_Sel.SelectItem("ID")
        ReturnObj = Fg_Sel.SelectItem
        If Fg_Sel.Rows(Fg_Sel.RowSel).Visible = True Then
            AddWorkBefore()
        End If
        If show = True Then
            Fg_Sel.Rows(Fg_Sel.RowSel).Visible = False
            For i As Integer = 1 To Fg_Sel.Rows.Count - 1
                If Fg_Sel.Rows(i).Visible = True Then

                    Fg_Sel.Item(i, "FG_Index") = index
                    index += 1

                End If
            Next
        End If
    End Sub

    ''' <summary>
    '''向前插入工序
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub AddWorkBefore()
        InsertWork(True)
    End Sub

    ''' <summary>
    ''' 插入工序
    ''' </summary>
    ''' <remarks></remarks>
    Sub InsertWork(ByVal BeforeOrAfter As Boolean)
        If ReturnObj Is Nothing Then
            Exit Sub
        End If

        If Fg1.RowSel > 0 Then
            If BeforeOrAfter = True AndAlso Fg1.Item(Fg1.RowSel, "State") = Enum_WorkState.Finish Then
                ShowErrMsg("工序[" & Fg1.Item(Fg1.RowSel, "Work_Name") & "]已完成不能向前插入工序")
                Exit Sub
            End If




            If BeforeOrAfter = False AndAlso Fg1.RowSel <> Fg1.Rows.Count - 1 AndAlso Fg1.Item(Fg1.RowSel + 1, "State") = Enum_WorkState.Finish Then
                ShowErrMsg("工序[" & Fg1.Item(Fg1.RowSel, "Work_Name") & "]已完成不能向后插入工序")
                Exit Sub
            End If

        End If
        Try

            Dim Dr As DataRow = TryCast(ReturnObj, DataRow)
            If Dr Is Nothing Then
                Exit Sub
            End If
            Dim index As Integer = 1
            Dim Row As C1.Win.C1FlexGrid.Row
            If BeforeOrAfter Then
                If Fg1.RowSel > 1 Then
                    index = Fg1.RowSel
                End If
                Row = Fg1.Rows.Insert(index)
            Else
                If Fg1.RowSel > 1 Then
                    If Fg1.RowSel = Fg1.Rows.Count - 1 Then
                        Row = Fg1.Rows.Add()
                    Else
                        index = Fg1.RowSel + 1
                        Row = Fg1.Rows.Insert(index)
                    End If
                Else
                    Row = Fg1.Rows.Add()
                End If
            End If
            Row("Work_No") = Dr("Work_No")
            Row("Work_Name") = Dr("Work_Name")
            Row("Dept_Name") = Dr("Dept_Name")
            Row("Process_Name") = Dr("Process_Name")
            Row("Work_ID") = ComFun.GetLineID
            Fg1.ReAddIndex()
            Fg1.RowSel = Row.Index
            Fg1.Row = Row.Index
        Catch ex As Exception
            If Ide Then MsgBox(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' 加载加工内容窗口
    ''' </summary>
    ''' <remarks></remarks>
    Private Function SelectWork() As PClass.ViewForm

        Dim f As PClass.BaseForm = LoadFormIDToChild(10050, Me)
        If f Is Nothing Then Return Nothing
        With f
            .P_F_RS_ID = ""
            .P_F_RS_ID2 = ""
            .P_F_RS_ID4 = ""
            .IsSel = True
        End With
        ReturnId = ""
        Me.ReturnObj = Nothing
        Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(f, Me)
        Return VF
    End Function

    ''' <summary>
    ''' 后加
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub AddWorkAfter()
        InsertWork(False)
    End Sub

    ''' <summary>
    '''上移
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Upmove()
        If Fg1.RowSel < 0 Then
            Exit Sub
        End If

        If Fg1.Item(Fg1.RowSel - 1, "State") = Enum_WorkState.Finish Then
            ShowErrMsg("[" & Fg1.Item(Fg1.RowSel - 1, "Work_Name") & "]已完成不能移动")
            Exit Sub
        End If

        Dim dt As New DataTable
        Dim dr As DataRow
        Dim da As New DataColumn("Work_No", GetType(String))
        dt.Columns.Add(da)
        Dim db As New DataColumn("Work_Name", GetType(String))
        dt.Columns.Add(db)
        Dim dc As New DataColumn("Dept_Name", GetType(String))
        dt.Columns.Add(dc)
        Dim dd As New DataColumn("Process_Name", GetType(String))
        dt.Columns.Add(dd)
        dr = dt.NewRow

        Dim index As Integer = Fg1.RowSel - 1

        dr("Work_No") = Fg1.Item(Fg1.RowSel, "Work_No")
        dr("Work_Name") = Fg1.Item(Fg1.RowSel, "Work_Name")
        dr("Dept_Name") = Fg1.Item(Fg1.RowSel, "Dept_Name")
        dr("Process_Name") = Fg1.Item(Fg1.RowSel, "Process_Name")

        Dim Row As C1.Win.C1FlexGrid.Row
        Row = Fg1.Rows(Fg1.RowSel - 1)

        Fg1.Item(Fg1.RowSel, "Work_No") = Row("Work_No")
        Fg1.Item(Fg1.RowSel, "Work_Name") = Row("Work_Name")
        Fg1.Item(Fg1.RowSel, "Dept_Name") = Row("Dept_Name")
        Fg1.Item(Fg1.RowSel, "Process_Name") = Row("Process_Name")

        Fg1.Item(Fg1.RowSel - 1, "Work_No") = dr("Work_No")
        Fg1.Item(Fg1.RowSel - 1, "Work_Name") = dr("Work_Name")
        Fg1.Item(Fg1.RowSel - 1, "Dept_Name") = dr("Dept_Name")
        Fg1.Item(Fg1.RowSel - 1, "Process_Name") = dr("Process_Name")

        Fg1.ReAddIndex()
        Fg1.RowSel = index
        Fg1.Row = index
    End Sub

    ''' <summary>
    ''' 下移
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DownMove()
        If Fg1.RowSel < 1 Then
            Exit Sub
        End If

        If Fg1.Item(Fg1.RowSel, "State") = Enum_WorkState.Finish Then
            ShowErrMsg("[" & Fg1.Item(Fg1.RowSel, "Work_Name") & "]已完成不能移动")
            Exit Sub
        End If

        Dim dt As New DataTable
        Dim dr As DataRow
        Dim da As New DataColumn("Work_No", GetType(String))
        dt.Columns.Add(da)
        Dim db As New DataColumn("Work_Name", GetType(String))
        dt.Columns.Add(db)
        Dim dc As New DataColumn("Dept_Name", GetType(String))
        dt.Columns.Add(dc)
        Dim dd As New DataColumn("Process_Name", GetType(String))
        dt.Columns.Add(dd)
        dr = dt.NewRow

        Dim index As Integer = Fg1.RowSel + 1

        dr("Work_No") = Fg1.Item(Fg1.RowSel, "Work_No")
        dr("Work_Name") = Fg1.Item(Fg1.RowSel, "Work_Name")
        dr("Dept_Name") = Fg1.Item(Fg1.RowSel, "Dept_Name")
        dr("Process_Name") = Fg1.Item(Fg1.RowSel, "Process_Name")
        Try
            Dim Row As C1.Win.C1FlexGrid.Row
            Row = Fg1.Rows(Fg1.RowSel + 1)
            Fg1.Item(Fg1.RowSel, "Work_No") = Row("Work_No")
            Fg1.Item(Fg1.RowSel, "Work_Name") = Row("Work_Name")
            Fg1.Item(Fg1.RowSel, "Dept_Name") = Row("Dept_Name")
            Fg1.Item(Fg1.RowSel, "Process_Name") = Row("Process_Name")
            Fg1.Item(Fg1.RowSel + 1, "Work_No") = dr("Work_No")
            Fg1.Item(Fg1.RowSel + 1, "Work_Name") = dr("Work_Name")
            Fg1.Item(Fg1.RowSel + 1, "Dept_Name") = dr("Dept_Name")
            Fg1.Item(Fg1.RowSel + 1, "Process_Name") = dr("Process_Name")
            Fg1.ReAddIndex()
            Fg1.RowSel = index
            Fg1.Row = index
        Catch ex As Exception

        End Try
    End Sub

    ''' <summary>
    '''前加后加按钮可见性
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Cmd_AddShow(ByVal show As Boolean)
        Cmd_AddRowAfter.Visible = show
        Cmd_AddRowBefore.Visible = show
        If Cmd_Edit.Checked = True Then
            Cmd_Edit.Checked = False

        End If
        Cmd_Edit.Visible = Not show

    End Sub

    ''' <summary>
    ''' 后加
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Afterchoose(ByVal Show As Boolean)

        Dim index As Integer = 1
        ReturnId = Fg_Sel.SelectItem("ID")
        ReturnObj = Fg_Sel.SelectItem
        If Fg_Sel.Rows(Fg_Sel.RowSel).Visible = True Then
            AddWorkAfter()
        End If
        If Show Then
            Fg_Sel.Rows(Fg_Sel.RowSel).Visible = False
            For i As Integer = 1 To Fg_Sel.Rows.Count - 1
                If Fg_Sel.Rows(i).Visible = True Then
                    Fg_Sel.Item(i, "FG_Index") = index
                    index += 1
                Else
                    Fg_Sel.Item(i, "FG_Index") = 0
                End If
            Next
            Fg_Sel.RowSetForce("FG_Index", 1)
        End If
    End Sub

    ''' <summary>
    ''' 删除选中行
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Remove(ByVal show As Boolean)
        If Fg1.RowSel < 1 Then
            Exit Sub
        End If

        If Fg1.Item(Fg1.RowSel, "State") = Enum_WorkState.Finish Then
            ShowErrMsg("工序[" & Fg1.Item(Fg1.RowSel, "Work_Name") & "]已完工不能删除")
            Exit Sub
        End If

        If show = False Then
            Fg1.RemoveRow()
            Exit Sub
        End If
        Try
            Dim index As Integer = 1
            For i As Integer = 1 To Fg_Sel.Rows.Count - 1
                If Fg_Sel.Item(i, "Work_No") = Fg1.Item(Fg1.RowSel, "Work_No") Then
                    Fg_Sel.Rows(i).Visible = True
                End If
            Next
            For i As Integer = 1 To Fg_Sel.Rows.Count - 1
                If Fg_Sel.Rows(i).Visible = True Then
                    Fg_Sel.Item(i, "FG_Index") = index
                    index += 1
                End If
            Next
            Fg_Sel.RowSetForce("Work_No", Fg1.Item(Fg1.RowSel, "Work_No"))
            Fg1.RemoveRow()
        Catch ex As Exception
        End Try
    End Sub

    Private Function ShowCharge(ByVal Word_id As Long) As DataTable
        Dim dt As DataTable = Dt_Charge.Clone
        Dim dr() As DataRow = Dt_Charge.Select("Work_id=" & Word_id)
        For Each ds As DataRow In dr
            dt.ImportRow(ds)
        Next
        Return dt
    End Function

    ''' <summary>
    ''' 获取员工
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub getlist()
        If ReturnObj Is Nothing OrElse Fg1.RowSel < 1 Then
            Exit Sub
        End If
        Dim dtEmployee As DataTable = TryCast(ReturnObj, DataTable)
        For Each dr As DataRow In dtEmployee.Rows
            Dim dc() As DataRow = Dt_Charge.Select("Employee_ID=" & dr("ID") & " and Work_id=" & Fg1.Item(Fg1.RowSel, "Work_id"))
            If dc.Length = 0 Then
                Dt_Charge.Rows.Add()
                Dt_Charge.Rows(Dt_Charge.Rows.Count - 1)("Employee_ID") = dr("ID")
                Dt_Charge.Rows(Dt_Charge.Rows.Count - 1)("Employee_Name") = dr("Employee_Name")
                Dt_Charge.Rows(Dt_Charge.Rows.Count - 1)("GH") = TB_ID.Text
                Dt_Charge.Rows(Dt_Charge.Rows.Count - 1)("Work_id") = Fg1.Item(Fg1.RowSel, "Work_id")
            End If
        Next
        Fg2.DtToFG(ShowCharge(Fg1.Item(Fg1.RowSel, "Work_id")))
    End Sub

    ''' <summary>
    ''' 删除员工
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DelEmployee(ByRef dt As DataTable, ByVal GH As String, ByVal Work_ID As Long, ByVal Employee_ID As Integer)
        Dim dr() As DataRow = dt.Select("GH='" & GH & "' And Work_ID=" & Work_ID & " And Employee_ID=" & Employee_ID)
        dt.Rows.Remove(dr(0))
        Fg2.DtToFG(ShowCharge(Work_ID))
    End Sub

#End Region

#Region "其它控件事件"

    ''' <summary>
    ''' Combobox获取一个集合
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CB_WorkList_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CB_WorkList.SelectedValueChanged
        If isLoaded = False Then
            Exit Sub
        End If
        If Fg1.Rows.Count > 1 AndAlso Mode = Mode_Enum.Add Then
            For i As Integer = Fg1.Rows.Count - 1 To 1 Step -1
                Fg1.Rows.Remove(i)
            Next
        End If
        GetWorkList(CB_WorkList.SelectedValue)

    End Sub


    ''' <summary>
    ''' 删除员工
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SMI_DelEmployee_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SMI_DelEmployee.Click
        If Fg2.RowSel < 1 Then
            Exit Sub
        End If

        DelEmployee(Dt_Charge, TB_ID.Text, Fg2.Item(Fg2.RowSel, "Work_ID"), Fg2.Item(Fg2.RowSel, "Employee_ID"))
    End Sub

    ''' <summary>
    ''' 添加员工
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SMI_AddEmployee_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SMI_AddEmployee.Click
        Dim F = New F30300_AT_EmployessSel
        With F
            .Mode = Mode_Enum.Add
            .P_F_RS_ID = ""
            .P_F_RS_ID2 = ""
            .parent_Form = Me
        End With
        F_RS_ID = ""
        Me.ReturnId = ""
        Me.ReturnObj = Nothing
        If VF Is Nothing OrElse VF.IsDisposed = True Then
            VF = PClass.PClass.LoadChildForm(F, Me)
        Else
            Me.VForm.ShowShadow()
        End If

        AddHandler VF.ClosedX, AddressOf getlist
        VF.Show()
    End Sub


#End Region

#End Region

    Dim VF As PClass.ViewForm
    Dim F As F30300_AT_EmployessSel


#Region "合缸"
    Private Sub Cmd_HG_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_HG.Click
        If CB_GH.Text = "" Then
            ShowErrMsg("请选择一个要合缸的缸号?")
            Exit Sub
        Else
            Dim GH1 As String
            Dim GH2 As String
            If CB_GH.Text.EndsWith("R", StringComparison.CurrentCultureIgnoreCase) OrElse IsNumeric(CB_GH.Text.Substring(CB_GH.Text.Length - 1)) Then
                GH1 = CB_GH.Text
                GH2 = TB_ID.Text
            Else
                GH2 = CB_GH.Text
                GH1 = TB_ID.Text
            End If
            ShowConfirm("是否要缸号[" & GH2 & "] 合并到缸号[" & GH1 & "]中?", AddressOf HG)
        End If
    End Sub

    Sub HG()
        Dim R As MsgReturn
        If CB_GH.Text.EndsWith("R", StringComparison.CurrentCultureIgnoreCase) OrElse IsNumeric(CB_GH.Text.Substring(CB_GH.Text.Length - 1)) Then
            R = Dao.Produce_HG(CB_GH.Text, TB_ID.Text)
        Else
            R = Dao.Produce_HG(TB_ID.Text, CB_GH.Text)
        End If
        If R.IsOk Then
            ShowOk("合缸成功!")
            ReturnId = R.Msg
            CG_Retrun()
        Else
            ShowErrMsg(R.Msg)
        End If
    End Sub
#End Region

#Region "成品名"
    Private Sub CB_CPName_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CB_CPName.CheckedChanged
        If CB_CPName.Checked Then

            TB_CPName.ReadOnly = False
        Else
            TB_CPName.ReadOnly = True
        End If
    End Sub
#End Region



    Private Sub CheckKC()
        Dim Msg As MsgReturn = Dao.GET_BZID_Qty(CB_BZ.IDAsInt)
        If Msg.IsOk Then
            If Val(Msg.Msg) < Val(TB_CR_LuoSeBzCount.Text) Then
                ShowErrMsg(TB_BZName.Text & "库存［" & Val(Msg.Msg) & "］比落色条数［" & Val(TB_CR_LuoSeBzCount.Text) & "］少")
            End If
        End If
    End Sub



    Private Sub FLP_Title_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles FLP_Title.Paint

    End Sub
    Private Sub Label39_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label39.DoubleClick
        Dim Msg As DtReturnMsg = Dao.GET_ID_ExClient(Val(TB_ClientID.Tag))
        If Msg.IsOk AndAlso Msg.Dt.Rows.Count > 0 Then
            TB_ClientName.Text = Msg.Dt.Rows(0)("Client_Name")
            TB_ClientID.Tag = Msg.Dt.Rows(0)("ID")
            'If Msg.Dt.Rows(0)("Client_Name") = TB_ClientName.Text Then
            '    TB_ClientName.Text = Msg.Dt.Rows(0)("ExClient")
            'Else
            '    TB_ClientName.Text = Msg.Dt.Rows(0)("Client_Name")
            'End If
        End If
    End Sub

    Private Sub CB_SG_Col_Sel(ByVal Col_No As System.String, ByVal Col_Name As System.String, ByVal ID As System.String) Handles CB_SG.Col_Sel
        TB_SGName.Text = Col_Name
        If ID Is Nothing Then
            Exit Sub
        End If
        CB_SG.SearchID = ID

        CB_SG.Enabled = True

        Dim msgSG As DtReturnMsg = Dao.ProduceGd_GetSGListByBzcID(ID)
        If msgSG.IsOk And msgSG.Dt.Rows.Count > 0 Then
            Dim Rs() As DataRow = msgSG.Dt.Select("SG_ID='" & CB_SG.IDAsInt & "'") '先搜索原来已经选择的布种编号
            If Rs.Length > 0 Then
                CB_SG.IDAsInt = IsNull(Rs(0)("SG_ID"), 0)
                CB_SG.Text = CB_SG.GetByTextBoxTag()
                TB_SGName.Text = CB_SG.NameValue
            End If
        End If

    End Sub

    Private Sub CB_SG_GetSearchEvent(ByRef Col_No As System.String, ByRef ID As System.String, ByVal Cancel As System.Boolean) Handles CB_SG.GetSearchEvent
        If TB_ClientID.Tag <> 0 Then
            CB_SG.SearchType = cSearchType.ENum_SearchType.ClientBZ
            CB_SG.SearchID = TB_ClientID.Tag
            CB_SG.SearchBZID = CB_BZ.IDValue
        Else
            CB_SG.SearchType = cSearchType.ENum_SearchType.ALL
            CB_SG.SearchID = TB_ClientID.Tag
        End If
    End Sub

    Private Sub CB_SG_SetEmpty() Handles CB_SG.SetEmpty
        TB_SGName.Text = ""
    End Sub
End Class

Partial Class Dao
#Region "合缸"
    Public Shared Function Produce_HG(ByVal GH1 As String, ByVal GH2 As String) As MsgReturn
        Dim R As New MsgReturn
        Dim P As New Dictionary(Of String, Object)
        P.Add("GH1", GH1)
        P.Add("GH2", GH2)
        P.Add("UPD_User", User_Name)
        Dim M As DtReturnMsg = SqlStrToDt("select (select top 1 State from T30000_Produce_Gd where GH=@GH1) as State1,(select top 1 State from T30000_Produce_Gd where GH=@GH2) as State2", P)
        If M.IsOk Then
            If IsNull(M.Dt.Rows(0)("State1"), 0) = IsNull(M.Dt.Rows(0)("State2"), 0) Then
                Dim sqlBuider As New StringBuilder()
                sqlBuider.AppendLine("declare @PB_CountSum bigint")
                sqlBuider.AppendLine("declare @CR_LuoSeBzCount bigint")
                sqlBuider.AppendLine("declare @PB_ZLSum as decimal(18,2)")
                '  sqlBuider.AppendLine("ALTER  TABLE  T40101_PBRK_List  DISABLE  TRIGGER  T40101_PBRK_List_Update")
                sqlBuider.AppendLine("select top 1 @PB_CountSum=PB_CountSum,@CR_LuoSeBzCount=CR_LuoSeBzCount,@PB_ZLSum=PB_ZLSum from T30000_Produce_Gd where GH=@GH2")
                sqlBuider.AppendLine("update T30000_Produce_Gd")
                sqlBuider.AppendLine("set PB_CountSum=@PB_CountSum+PB_CountSum")
                sqlBuider.AppendLine(",CR_LuoSeBzCount=@CR_LuoSeBzCount+CR_LuoSeBzCount")
                sqlBuider.AppendLine(",PB_ZLSum=@PB_ZLSum+PB_ZLSum,UPD_User=@UPD_User,UPD_Date=GetDate()")
                sqlBuider.AppendLine("where GH=@GH1")
                sqlBuider.AppendLine("Update T40101_PBRK_List set GH=@GH1 where GH=@GH2")
                '
                sqlBuider.AppendLine("select T.ID ,StoreNo,Qty  into #T  from(select @GH1 AS ID ,StoreNo,SUM(Qty) AS Qty FROM T40520_PB_StoreNo WHERE ID=@GH1 OR ID=@GH2 GROUP BY StoreNo) T ")
                sqlBuider.AppendLine("delete T40520_PB_StoreNo  where ID=@GH1")
                sqlBuider.AppendLine("delete T40520_PB_StoreNo  where ID=@GH2")
                sqlBuider.AppendLine("insert into T40520_PB_StoreNo  (StoreNo,ID,Qty,BZType) select StoreNo,ID,Qty,1 from #T  where ID=@GH1 ")
                sqlBuider.AppendLine("insert into T40521_PB_Detail  (StoreNo,ID,GH,InQty,BillType,BillName) select StoreNo,GH,GH,Qty * -1,3000,'合缸' from T30002_CPRK  where GH=@GH2 ")
                sqlBuider.AppendLine("delete T30002_CPRK  where GH=@GH2")
                sqlBuider.AppendLine("delete T30002_CPRK  where GH=@GH1")
                sqlBuider.AppendLine("insert into T30002_CPRK  (StoreNo,GH,Qty) select StoreNo,ID,Qty from T40520_PB_StoreNo  where ID=@GH1 ")


                '
                sqlBuider.AppendLine("Update T30000_Produce_Gd set State=-1 , UPD_User=@UPD_User,UPD_Date=GetDate()  where GH=@GH2")
                '   sqlBuider.AppendLine("ALTER  TABLE  T40101_PBRK_List  ENABLE  TRIGGER  T40101_PBRK_List_Update")
                sqlBuider.AppendLine("Drop table #T")
                R = RunSQL(sqlBuider.ToString, P)
                If R.IsOk Then
                    R.Msg = GH1
                End If
            Else
                R.Msg = "合缸失败,两个单号的状态不一致" & vbCrLf & GH1 & "状态是[" & ComFun.GetProduceStateName(IsNull(M.Dt.Rows(0)("State1"), Enum_WorkState.None)) & "]" & _
                 vbCrLf & GH2 & "状态是[" & ComFun.GetProduceStateName(IsNull(M.Dt.Rows(0)("State2"), Enum_WorkState.None)) & "]"
            End If
        Else
            R.Msg = "合缸失败,查询失败"
        End If
        Return R
    End Function

#End Region


#Region "生产运转单"
    Public Const SQL_Produce_Get_WithName As String = "select P.*,C.Client_Name,BZ_Name ,BZC_Name,BZ_Spec from T30000_Produce_Gd P left join T10110_Client C on P.Client_No=C.Client_No left join T10002_BZ BZ on P.BZ_No=BZ.BZ_No  left join T10003_BZC BZC on P.BZC_No=BZC.BZC_No"

    Public Const SQL_Produce_GetByID As String = "select * from T30000_Produce_Gd where GH=@GH"

    Public Const SQL_Produce_GetByID_WithName As String = "select P.*,C.Client_Name,BZ_Name,BZC_Name,BZ_Spec  from T30000_Produce_Gd P left join T10110_Client C on P.Client_No=C.Client_No left join T10002_BZ BZ on P.BZ_No=BZ.BZ_No left join T10003_BZC BZC on P.BZC_No=BZC.BZC_No where GH=@GH "

    Public Const SQL_Produce_GetEmptyRow As String = "select top 0  P.*,C.Client_Name,BZ_Name,BZC_Name  from T30000_Produce_Gd P left join T10110_Client C on P.Client_No=C.Client_No left join T10002_BZ BZ on P.BZ_No=BZ.BZ_No left join T10003_BZC BZC on P.BZC_No=BZC.BZC_No  "

    Public Const SQL_Bz_Link_GetByID_Save As String = "select * from T10009_ProduceLinkBz where GH=@GH"

    Public Const SQL_Produce_DelByid As String = "Delete from  T30000_Produce_Gd where GH=@GH "
    Public Const SQL_Produce_OrderBy As String = " order by  GH "



    Public Const SQL_Produce_GetBZByBZCID As String = "select distinct( BZ.BZ_No),BZ_Name,BZ_FindHelper  from  (select BZ_No from T10009_BzcLinkBz where BZC_No=@BZC_No union all select BZ_No from T10003_BZC where BZC_No=@BZC_No) BL left join T10002_BZ  BZ on BZ.BZ_No=BL.BZ_No "
    Public Const SQL_Produce_GetClientByBZCID As String = "select B.Client_No, Client_Name from T10003_BZC B left join T10110_Client C on  B.Client_No=C.Client_No where BZC_No=@BZC_No "

#End Region

#Region "运转单跟单"
    Public Const Produce_Gd_Name As String = "运转单"
    Public Const SQL_ProduceGd_Get_WithName As String = "select P.*,Client_No, C.Client_Name,BZ_No,BZ_Name ,BZC_No,BZC_Name,BZ_Spec,E.Employee_name as GenDanName,(select Sum(SumAmount)SumAmount from T20310_LingLiao_Table where Produce_id = GH and state >-1 )SumAmount from T30000_Produce_Gd P left join T10110_Client C on P.Client_ID=C.ID left join T10002_BZ BZ on P.BZ_ID=BZ.ID left join T10003_BZC BZC on P.BZC_ID=BZC.ID left join T15001_Employee E on  P.GengDan=E.ID"

    Public Const SQL_ProduceGd_GetByID As String = "select Top 1 * from T30000_Produce_Gd where GH=@GH"
    Public Const SQL_ProduceGd_GetCGByID As String = "select Top 1 * from T30000_Produce_Gd where GH=@CG"

    Public Const SQL_ProduceGd_GetByID_WithName As String = "Select top 1 P.* ,SG.SGGY_Name,SG.SGGY_No,BZC.RanSe,Client_No, C.Client_Name,BZ_No,BZ_Name ,BZC_No,BZC_Name,BZ_Spec,E.Employee_Name as GengDanName  from T30000_Produce_Gd P left join T10110_Client C on P.Client_ID=C.ID left join T10002_BZ BZ on P.BZ_ID=BZ.ID left join T10003_BZC BZC on P.BZC_ID=BZC.ID left join T15001_Employee E on  P.GengDan =E.ID LEFT JOIN T10035_SGGY SG ON SG.ID=P.SG_ID  where GH=@GH "

    Public Const SQL_ProduceGd_GetEmptyRow As String = "Select top 0 P.*,SG.SGGY_Name,SG.SGGY_No,Client_No, C.Client_Name,BZ_No,BZ_Name ,BZC_No,BZC_Name,BZ_Spec,E.Employee_Name as GengDanName  from T30000_Produce_Gd P left join T10110_Client C on P.Client_ID=C.ID left join T10002_BZ BZ on P.BZ_ID=BZ.ID left join T10003_BZC BZC on P.BZC_ID=BZC.ID left join T15001_Employee E on  P.GengDan =E.ID LEFT JOIN T10035_SGGY SG ON SG.ID=P.SG_ID "


    Public Const SQL_ProduceGd_DelByid As String = "Delete from  T30000_Produce_Gd where GH=@GH "

    Public Const SQL_ProduceGd_UpdateState As String = "update  T30000_Produce_Gd set UPD_User=@UPD_User,UPD_Date=GetDate(),State=@State where GH=@GH "

    Public Const SQL_ProduceGd_Copy As String = "update  T30000_Produce_Gd set Date_PeiBu=@Date_PeiBu,Date_CPLR=@Date_CPLR where GH=@GH "

    Public Const SQL_ProduceGd_OrderBy As String = " order by  GH "


    Public Const SQL_ProduceGd_GetBZByBZCID As String = "select  distinct( BZ_ID),Client_Bzc  from  (select BZ_ID,Client_Bzc from T10009_BzcLinkBz where BZC_ID=@BZC_ID union all select BZ_ID,Client_Bzc from T10003_BZC where ID=@BZC_ID) BL  "
    Public Const SQL_ProduceGd_GetSGByBZCID As String = "select  ID AS SG_ID ,SGGY_Name,SGGY_No from  T10035_SGGY WHERE ID=@ID "

    Public Const SQL_ProduceGd_GetClientByBZCID As String = "select B.Client_ID,Client_No, Client_Name from T10003_BZC B left join T10110_Client C on  B.Client_ID=C.ID where B.ID=@BZC_ID "



#End Region

#Region "常量"
    Private Const Produce_PBComplete As String = "  update T30000_Produce_Gd set state =@State, UPD_User=@UPD_User,UPD_Date=GetDate() where GH= @GH"
    Private Const Produce_UpdRemark As String = "  update T30000_Produce_Gd set LRemark =@LRemark , UPD_User=@UPD_User,UPD_Date=GetDate() where GH= @GH"
    Public Const SQL_WorkList_GetListByID As String = "select WL.*,W.Dept_Name,W.Work_Name from T10024_WorkList WL left join T10022_Work W ON WL.Work_No=W.Work_No where Work_ID=@Work_ID order by WorkList_Index"
    Public Const SQL_Work_GetALL As String = "select * from T10022_Work "
    Public Const SQL_WorkListGetByGH As String = "Select * from T30003_Produce_Worklist where GH=@GH"
    Public Const SQL_WorkListByGH As String = "select WL.*,W.Dept_Name,W.Work_Name from T30003_Produce_Worklist WL left join T10022_Work W ON WL.Work_No=W.Work_No where GH=@GH order by WorkList_Index"
    Public Const SQL_WorkListGetCharge As String = "Select * from T30004_Produce_Charge where GH=@GH"
    Public Const SQL_WorkList_GetAll As String = "Select WorkList_No, ID,WorkList_Name from T10023_WorkTable "
    Public Const SQL_GetBZ_ID_Store As String = "SELECT sum(P.Qty) FROM T40520_PB_StoreNo p left join  T40100_PBRK_Table l on  P.ID=L.ID  WHERE L.BZ_ID = @BZ_ID  "
    Public Const SQL_GetID_ExClient As String = "select top 1 ExClient,Client_Name,ID from T10110_Client  Where ExClient =@ID "

    'Private Const GetClientRemark As String = "select top 1 Remark from T30000_Produce_Gd where  Client_ID=@Client_ID order by GH Desc"

    'Private Const GetClientRemark_BZ As String = "select top 1 Remark from T30000_Produce_Gd where  Client_ID=@Client_ID and BZ_ID=@BZ_ID order by GH Desc"
#End Region

#Region "获取状态"
    ''' <summary>
    ''' 获取状态
    ''' </summary>
    ''' <param name="GH"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Produce_GetState(ByVal GH As String) As DtReturnMsg
        Dim sql As String = "select Top 1  State from T30000_Produce_Gd where GH=@GH"
        Return SqlStrToDt(sql, "GH", GH)
    End Function
#End Region

#Region "更新状态"

    ''' <summary>
    ''' 作废
    ''' </summary>
    ''' <param name="GH"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Produce_Invalid(ByVal GH As String) As MsgReturn
        Dim R As New MsgReturn
        Dim S As New Dictionary(Of String, String)
        Dim P As New Dictionary(Of String, Object)
        S.Add("G", "Select top 1 GH,State,UPD_User,UPD_Date,PB_ZLSum,PB_CountSum,Date_PeiBu,PB_User from T30000_Produce_Gd where GH=@GH")
        P.Add("GH", GH)
        Using H As New DtHelper(S, P)
            If H.IsOk = True Then
                If H.DtList("G").Rows.Count > 0 Then
                    If H.DtList("G").Rows(0)("State") < Enum_ProduceState.PeiBu Then
                        H.DtList("G").Rows(0)("State") = Enum_ProduceState.Invalid
                        H.DtList("G").Rows(0)("PB_ZLSum") = 0
                        H.DtList("G").Rows(0)("PB_CountSum") = 0
                        H.DtList("G").Rows(0)("Date_PeiBu") = DBNull.Value
                        H.DtList("G").Rows(0)("PB_User") = ""
                        H.DtList("G").Rows(0)("UPD_User") = User_Name
                        H.DtList("G").Rows(0)("UPD_Date") = GetTime()
                        Dim AfterSql As String = "update T40101_PBRK_List set GH='',PB=0,cp=0 where GH=@GH" & vbCrLf & _
                        "Exec('P40100_PBRK_ReSum '''+@GH+''' ')"
                        If H.UpdateAll(True, AfterSql, "GH", GH).IsOk Then
                            R.IsOk = True
                            R.Msg = "作废成功!"
                        Else
                            R.IsOk = False
                            R.Msg = "作废失败," & H.Msg
                        End If
                    Else
                        R.IsOk = False
                        R.Msg = "作废失败,缸号[" & GH & "]当前状态是[" & ComFun.GetProduceStateName(H.DtList("G").Rows(0)("State")) & "],不能作废!请先清除配布。"
                    End If
                Else
                    R.IsOk = False
                    R.Msg = "作废失败,缸号[" & GH & "]不存在!"
                End If
            Else
                R.IsOk = False
                R.Msg = "作废失败," & R.Msg
            End If
        End Using
        Return R
    End Function



    Public Shared Function Produce_UpdateRemark(ByVal _GH As String, ByVal Remark As String)
        Dim p As New Dictionary(Of String, Object)
        p.Add("LRemark", Remark)
        p.Add("GH", _GH)
        p.Add("UPD_User", PClass.PClass.User_Name)
        Return RunSQL(Produce_UpdRemark, p)
    End Function
    Public Shared Function Produce_UpdateState(ByVal _GH As String, ByVal _State As Enum_ProduceState)
        Dim p As New Dictionary(Of String, Object)
        p.Add("State", _State)
        p.Add("GH", _GH)
        p.Add("UPD_User", PClass.PClass.User_Name)
        Return RunSQL(Produce_PBComplete, p)
    End Function

    Public Shared Function Produce_UpdateState_RanSeGH(ByVal _GH As String, ByVal RanseGH As String, ByVal State As Enum_ProduceState, Optional ByVal UpdateState As Boolean = False)
        Dim p As New Dictionary(Of String, Object)
        p.Add("RanseGH", RanseGH)
        p.Add("GH", _GH)
        p.Add("UPD_User", PClass.PClass.User_Name)
        Dim sql As New StringBuilder
        sql.Append(" update  T30000_Produce_Gd set UPD_User=@UPD_User,UPD_Date=GetDate() ")
        If UpdateState Then
            sql.Append(",State=" & State & "")
        End If
        sql.Append(" ,RanseGH=@RanseGH where GH=@GH ")
        Return RunSQL(sql.ToString, p)
    End Function

    Public Shared Function Produce_UpdateState_ChuHuo(ByVal _GH As String, ByVal Date_ChuHuo As Date, ByVal State As Enum_ProduceState)
        Dim p As New Dictionary(Of String, Object)
        p.Add("Date_JiaoHuo", Date_ChuHuo)
        p.Add("GH", _GH)
        p.Add("UPD_User", PClass.PClass.User_Name)
        Return RunSQL("update  T30000_Produce_Gd set UPD_User=@UPD_User,UPD_Date=GetDate(), State=" & State & ",Date_JiaoHuo=@Date_JiaoHuo where GH=@GH", p)
    End Function

#End Region

#Region "运转单跟单"
    ''' <summary>
    ''' 获取查询条件集合
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Produce_GetConditionNames() As List(Of FindOption)
        Dim foList As New List(Of FindOption)
        Dim fo As New FindOption
        fo.Field = "请选择"
        fo.DB_Field = ""
        foList.Add(fo)



        fo = New FindOption
        fo.Field = "缸号"
        fo.DB_Field = "GH"
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "客户编号"
        fo.DB_Field = "P.Client_No"
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "客户名称"
        fo.DB_Field = "Client_Name"
        foList.Add(fo)
        Return foList
    End Function


    ''' <summary>
    ''' 状态列表
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function StateName_GetConditionNames() As List(Of FindOption)
        Dim foList As New List(Of FindOption)
        Dim fo As New FindOption
        fo.Field = ComFun.GetWorkStateName(Enum_WorkState.None)
        fo.DB_Field = Enum_WorkState.None
        foList.Add(fo)



        fo = New FindOption
        fo.Field = ComFun.GetWorkStateName(Enum_WorkState.Start)
        fo.DB_Field = Enum_WorkState.Start
        foList.Add(fo)

        fo = New FindOption
        fo.Field = ComFun.GetWorkStateName(Enum_WorkState.Finish)
        fo.DB_Field = Enum_WorkState.Finish
        foList.Add(fo)
      
        Return foList
    End Function


    ''' <summary>
    ''' 获取所有运转单
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ProduceGd_GetAll() As DtReturnMsg

        Return PClass.PClass.SqlStrToDt(SQL_ProduceGd_Get_WithName)
    End Function

    ''' <summary>
    ''' 获取查询条件集合
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ProduceGd_GetConditionNames() As List(Of FindOption)
        Dim foList As New List(Of FindOption)
        Dim fo As New FindOption
        fo.Field = "请选择"
        fo.DB_Field = ""
        foList.Add(fo)



        fo = New FindOption
        fo.Field = "缸号"
        fo.DB_Field = "GH"
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "客户编号"
        fo.DB_Field = "P.Client_No"
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "客户名称"
        fo.DB_Field = "Client_Name"
        foList.Add(fo)
        Return foList
    End Function



    ''' <summary>
    ''' 按条件获取运转单
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ProduceGd_GetByOptionString(ByVal s As String) As DtReturnMsg
        Dim paraMap As New Dictionary(Of String, Object)
        Dim sqlBuider As New StringBuilder
        sqlBuider.Append(SQL_ProduceGd_Get_WithName)
        sqlBuider.Append("  WHERE 1=1  ")
        sqlBuider.Append(s)
        sqlBuider.Append(SQL_ProduceGd_OrderBy)
        Return PClass.PClass.SqlStrToDt(sqlBuider.ToString, paraMap)
    End Function

    ''' <summary>
    ''' 获取运转单信息
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ProduceGd_GetEmptyRow() As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_ProduceGd_GetEmptyRow)
    End Function


    ''' <summary>
    ''' 获取运转单信息
    ''' </summary>
    ''' <param name="sId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ProduceGd_GetById(ByVal sId As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_ProduceGd_GetByID_WithName, "@GH", sId)
    End Function


    ''' <summary>
    ''' 增加一个运转单
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ProduceGd_Add(ByVal Dt_Produce As DataTable, ByVal DT_WorkList As DataTable, ByVal Dt_Charge As DataTable) As MsgReturn
        Dim msg As New DtListReturnMsg
        Dim returnMsg As New MsgReturn
        Dim sqlMap As New Dictionary(Of String, String)
        Dim paraMap As New Dictionary(Of String, Object)
        If Dt_Produce.Rows.Count <> 1 Then '检查参数
            returnMsg.IsOk = False
            returnMsg.Msg = "添加" & Produce_Gd_Name & "失败!"
            Return returnMsg
        End If
        paraMap.Add("@GH", Dt_Produce.Rows(0)("GH"))
        sqlMap.Add("Produce", SQL_ProduceGd_GetByID)
        sqlMap.Add("WorkList", SQL_WorkListGetByGH)
        sqlMap.Add("Charge", SQL_WorkListGetCharge)
        Dt_Produce.Rows(0)("State") = Enum_ProduceState.AddNew
        msg = SqlStrToDt(sqlMap, paraMap)
        Try
            If msg.IsOk AndAlso msg.DtList("Produce").Rows.Count = 0 Then
                Dim P As New List(Of String)
                P.Add("JiaJi")
                P.Add("JiaJi_Date")
                P.Add("PB_CountSum")
                P.Add("PB_ZLSum")
                DvToDt(Dt_Produce, msg.DtList("Produce"), P, False)
                DvToDt(DT_WorkList, msg.DtList("WorkList"), P, True)
                DvToDt(Dt_Charge, msg.DtList("Charge"), P, True)
                Dim TmSQL As String = "insert into Bill_Barcode (No_ID,NO_Type)values('" & Dt_Produce.Rows(0)("GH") & "'," & BillType.Produce & ")"
                DtToUpDate(msg, TmSQL)
                returnMsg.IsOk = True
                returnMsg.Msg = "运转单[" & Dt_Produce.Rows(0)("GH") & "添加成功!"
            ElseIf msg.DtList("Produce").Rows.Count = 1 Then
                returnMsg.IsOk = False
                returnMsg.Msg = "运转单[" & Dt_Produce.Rows(0)("GH") & "]已经存在!,请双击[缸号],获取新编号!"
            End If
        Catch ex As Exception
            DebugToLog(ex)
            returnMsg.IsOk = False
            returnMsg.Msg = "添加" & Produce_Gd_Name & "失败!"
        End Try
        Return returnMsg
    End Function








    ''' <summary>
    '''修改一个运转单
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ProduceGd_Save(ByVal Dt_Produce As DataTable, ByVal Dt_Worklist As DataTable, ByVal Dt_Charge As DataTable) As MsgReturn
        Dim msg As New DtListReturnMsg
        Dim returnMsg As New MsgReturn
        Dim sqlMap As New Dictionary(Of String, String)
        Dim paraMap As New Dictionary(Of String, Object)
        If Dt_Produce.Rows.Count <> 1 Then '检查参数
            returnMsg.IsOk = False
            returnMsg.Msg = "修改运转单失败!"
            Return returnMsg
        End If
        paraMap.Add("@GH", Dt_Produce.Rows(0)("GH"))
        sqlMap.Add("Produce", SQL_ProduceGd_GetByID)
        sqlMap.Add("WorkList", SQL_WorkListGetByGH)
        sqlMap.Add("Charge", SQL_WorkListGetCharge)
        msg = SqlStrToDt(sqlMap, paraMap)
        Try
            If msg.IsOk AndAlso msg.DtList("Produce").Rows.Count > 0 Then
                Dim il As New List(Of String)
                il.Add("PB_ZLSum")
                il.Add("PB_CountSum")
                il.Add("JiaJi")
                il.Add("JiaJi_Date")
                il.Add("GH")
                If msg.DtList("Produce").Rows(0)("State") >= Enum_ProduceState.PeiBu Then
                    il.Add("CR_LuoSeBzCount")
                    il.Add("State")
                End If
                DvUpdateToDt(Dt_Produce, msg.DtList("Produce"), il)
                DvToDt(Dt_Worklist, msg.DtList("WorkList"), New List(Of String), False)
                DvToDt(Dt_Charge, msg.DtList("Charge"), New List(Of String), False)

                DtToUpDate(msg)
                returnMsg.IsOk = True
                returnMsg.Msg = Produce_Gd_Name & Dt_Produce.Rows(0)("GH") & "修改成功!"
            Else
                returnMsg.IsOk = False
                returnMsg.Msg = Produce_Gd_Name & Dt_Produce.Rows(0)("GH") & "不存在!"
            End If
        Catch ex As Exception
            DebugToLog(ex)
            returnMsg.IsOk = False
            returnMsg.Msg = "修改" & Produce_Gd_Name & "失败!"
        End Try
        Return returnMsg
    End Function

    ''' <summary>
    '''修改工序
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function WorkList_Save(ByVal Dt_Worklist As DataTable, ByVal Dt_Charge As DataTable) As MsgReturn
        Dim msg As New DtListReturnMsg
        Dim returnMsg As New MsgReturn
        Dim sqlMap As New Dictionary(Of String, String)
        Dim paraMap As New Dictionary(Of String, Object)
        paraMap.Add("@GH", Dt_Worklist.Rows(0)("GH"))


        sqlMap.Add("WorkList", SQL_WorkListGetByGH)
        sqlMap.Add("Charge", SQL_WorkListGetCharge)
        msg = SqlStrToDt(sqlMap, paraMap)
        Try
            If msg.IsOk Then
                DvToDt(Dt_Worklist, msg.DtList("WorkList"), New List(Of String), False)
                DvToDt(Dt_Charge, msg.DtList("Charge"), New List(Of String), False)

                DtToUpDate(msg)
                returnMsg.IsOk = True
                returnMsg.Msg = "工序修改成功!"
            Else
                returnMsg.IsOk = False
                returnMsg.Msg = "工序修改失败!"
            End If
        Catch ex As Exception
            DebugToLog(ex)
            returnMsg.IsOk = False
            returnMsg.Msg = "修改失败!"
        End Try
        Return returnMsg
    End Function


    ''' <summary>
    ''' 删除
    ''' </summary>
    ''' <param name="_GH"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ProduceGd_Del(ByVal _GH As String)
        Return RunSQL(SQL_ProduceGd_DelByid, "@GH", _GH)
    End Function

    ''' <summary>
    ''' 作废,更新状态
    ''' </summary>
    ''' <param name="_Gh"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ProduceGd_UpdateState(ByVal _Gh As String, ByVal state As Enum_ProduceState)
        Dim para As New Dictionary(Of String, Object)
        para.Add("State", state)
        para.Add("@GH", _Gh)
        para.Add("UPD_User", PClass.PClass.User_Name)
        Return RunSQL(SQL_ProduceGd_UpdateState, para)
    End Function

    ''' <summary>
    ''' 复制,更新状态
    ''' </summary>
    ''' <param name="_Gh"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ProduceGd_Copy(ByVal _Gh As String, ByVal _Date_PeiBu As String, ByVal _Date_CPLR As String)
        Dim para As New Dictionary(Of String, Object)
        para.Add("@GH", _Gh)
        para.Add("@Date_PeiBu", _Date_PeiBu)
        para.Add("@Date_CPLR", _Date_CPLR)
        Return RunSQL(SQL_ProduceGd_Copy, para)
    End Function


    ''' <summary>
    ''' 获取一个新ID
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ProduceGd_GetNewID(ByVal D As Date) As RetrunNewIdMsg
        Dim R As New RetrunNewIdMsg
        R.MaxDate = Maxdate.AddDays(1)
        Try
            If D.Date <= Maxdate Then
                R.NewIdDate = Maxdate.AddDays(1)
                R.IsTheDate = False
                R.RetrunMsg = "你选择的日期小于或等于日结日期!"
            Else
                R.NewIdDate = D
                R.IsTheDate = True
                R.RetrunMsg = "获取" & Produce_Gd_Name & "号成功!"
            End If
            Dim paraMap As New Dictionary(Of String, Object)
            paraMap.Add("@DB_Str", "T30000_Produce_Gd")
            paraMap.Add("@Id_Str", "GY")
            paraMap.Add("@Field", "GH")
            paraMap.Add("@Zero", "3")
            paraMap.Add("@Date", D.ToString("yyyy-MM-dd"))
            Dim MR As MsgReturn = SqlStrToOneStr("GetTableID_NoSave_Date", paraMap, True)
            If MR.IsOk Then
                R.NewID = MR.Msg
                R.IsOk = True
            Else
                R.RetrunMsg = "获取" & Produce_Gd_Name & "号失败!"
                R.IsOk = False
            End If
            Return R
        Catch ex As Exception
            DebugToLog(ex)
            R.IsOk = False
            R.RetrunMsg = "获取" & Produce_Gd_Name & "号失败!" & ex.Message
            Return R
        End Try
    End Function


    ''' <summary>
    ''' 获取客户色号
    ''' </summary>
    ''' <param name="BZC_ID"></param>
    ''' <param name="BZ_ID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ProduceGd_GetClientBZC(ByVal BZC_ID As String, ByVal BZ_ID As String) As DtReturnMsg
        Dim sqlBuider As New StringBuilder
        Dim P As New Dictionary(Of String, Object)
        P.Add("BZC_ID", BZC_ID)
        If Not BZ_ID = 0 Then
            P.Add("BZ_ID", BZ_ID)
            sqlBuider.Append("select Client_BZC from T10003_BZC where ID=@BZC_ID and BZ_ID=@BZ_ID union all select Client_BZC from T10009_BzcLinkBz where BZC_ID=@BZC_ID  and BZ_ID=@BZ_ID")
            Return PClass.PClass.SqlStrToDt(sqlBuider.ToString, P)
        Else
            sqlBuider.Append("select Client_BZC from T10003_BZC where ID=@BZC_ID  union all select Client_BZC from T10009_BzcLinkBz where BZC_ID=@BZC_ID ")
            Return PClass.PClass.SqlStrToDt(sqlBuider.ToString, P)
        End If
    End Function

    ''' <summary>
    ''' 按手感获取名字列表
    ''' </summary>
    ''' <param name="_ID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ProduceGd_GetSGListByBzcID(ByVal _ID As String) As DtReturnMsg

        Return PClass.PClass.SqlStrToDt(SQL_ProduceGd_GetSGByBZCID, "@ID", _ID)
    End Function
    ''' <summary>
    ''' 按色号获取布种列表
    ''' </summary>
    ''' <param name="bzcID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ProduceGd_GetBZListByBzcID(ByVal bzcID As String) As DtReturnMsg

        Return PClass.PClass.SqlStrToDt(SQL_ProduceGd_GetBZByBZCID, "@BZC_ID", bzcID)
    End Function


    ''' <summary>
    ''' 按色号获取客户
    ''' </summary>
    ''' <param name="bzcID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ProduceGd_GetClientByBzcID(ByVal bzcID As Integer) As DtReturnMsg

        Return PClass.PClass.SqlStrToDt(SQL_ProduceGd_GetClientByBZCID, "@BZC_ID", bzcID)
    End Function
#End Region

#Region "获取色办集合"
    ''' <summary>
    ''' 获取色办集合
    ''' </summary>
    ''' <param name="BZc_ID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Produce_GetBZCPF(ByVal BZc_ID As Integer) As DtReturnMsg

        Dim sql As String = "select BZC_ID,ID,PF_Name,IsOk,IsCheck from T10010_BZC_PF where BZC_ID=@BZC_ID order by ID"
        Return SqlStrToDt(sql, "BZC_ID", BZc_ID)
    End Function

#End Region

#Region "获取客户备注"
    ''' <summary>
    ''' 获取客户备注
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Produce_GetClientRemark(ByVal Client_ID As Integer, ByVal BZ_ID As Integer) As DtReturnMsg
        Dim p As New Dictionary(Of String, Object)
        p.Add("Client_ID", Client_ID)
        p.Add("BZ_ID", BZ_ID)
        Return SqlStrToDt("P30010_Produce_GetClientRemark", p, True)

    End Function
#End Region

#Region "修改布种名称"
    ''' <summary>
    ''' 修改布种名称"
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Bz_Rename(ByVal BZ_ID As Integer, ByVal BZ_Name As String) As MsgReturn
        Dim p As New Dictionary(Of String, Object)
        p.Add("BZ_ID", BZ_ID)
        p.Add("BZ_Name", BZ_Name)
        Return RunSQL("Update T10002_BZ set BZ_Name=@BZ_Name where ID=@BZ_ID", p)
    End Function
    ''' <summary>
    ''' 修改布种名称"
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Bz_No_Rename(ByVal BZ_ID As Integer, ByVal BZ_No As String) As MsgReturn
        Dim p As New Dictionary(Of String, Object)
        p.Add("BZ_ID", BZ_ID)
        p.Add("BZ_No", BZ_No)
        Return RunSQL("Update T10002_BZ set BZ_No=@BZ_No where ID=@BZ_ID", p)
    End Function
    ''' <summary>
    ''' 修改颜色名称
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Bzc_Rename(ByVal BZC_ID As Integer, ByVal BZC_Name As String) As MsgReturn
        Dim p As New Dictionary(Of String, Object)
        p.Add("BZC_ID", BZC_ID)
        p.Add("BZC_Name", BZC_Name)
        Return RunSQL("Update T10003_BZC set BZC_Name=@BZC_Name where ID=@BZC_ID", p)
    End Function

#End Region

#Region "获取加工列表"

    Public Shared Function Get_AllWorkList() As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_WorkList_GetAll)
    End Function




    Public Shared Function List_GetById(ByVal sId As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_WorkList_GetListByID, "@Work_ID", sId)
    End Function

    ''' <summary>
    ''' 获取所有加工信息
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Work_Get() As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_Work_GetALL)
    End Function

    ''' <summary>
    ''' 获取运转单工序
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Produce_Worklist(ByVal GH As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_WorkListByGH, "@GH", GH)
    End Function

    ''' <summary>
    ''' 获取工序责任人
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Produce_GetCharge(ByVal GH As String) As DtReturnMsg
        Dim P As New Dictionary(Of String, Object)
        P.Add("@GH", GH)
        Return PClass.PClass.SqlStrToDt(SQL_WorkListGetCharge, P)
    End Function

#End Region

#Region "获取指定布种库存"

    ''' <summary>
    ''' 获取指定布种库存
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GET_BZID_Qty(ByVal BZ_ID As Integer) As MsgReturn
        Return PClass.PClass.SqlStrToOneStr(SQL_GetBZ_ID_Store, "BZ_ID", BZ_ID)
    End Function


#End Region


#Region "获取关联客户"

    ''' <summary>
    ''' 获取关联客户
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GET_ID_ExClient(ByVal ID As Integer) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_GetID_ExClient, "ID", ID)
    End Function


#End Region


End Class
Public Enum Enum_GH_Type
    ''' <summary>
    ''' 正常缸
    ''' </summary>
    ''' <remarks></remarks>
    Normal
    ''' <summary>
    ''' 反定
    ''' </summary>
    ''' <remarks></remarks>
    FD
    ''' <summary>
    ''' 退胚
    ''' </summary>
    ''' <remarks></remarks>
    TP


End Enum


