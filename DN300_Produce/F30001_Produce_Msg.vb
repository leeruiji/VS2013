Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports BaseClass
Public Class F30001_Produce_Msg
    Dim LId As String = ""
    Dim PID As String = ""
    Dim PID_Date As Date = #1/1/1999#
    Dim Dt_Produce As New DataTable
    Dim Dt_BZ As New DataTable
    Dim ProduceId As String = ""
    Dim dt_PBZ As DataTable
    Dim dt_CBZ As DataTable
    Dim isLoaded As Boolean = False
    Public Const BZListLimit As Int16 = 65

    Public Sub New()

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。
        Tab_Dye.BackColor = Me.BackColor
        Tab_QC.BackColor = Me.BackColor
        Tab_QC2.BackColor = Me.BackColor
    End Sub

    Public Sub New(ByVal produceId As String)

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        Me.ProduceId = produceId
        TB_No.Text = produceId
        ' 在 InitializeComponent() 调用之后添加任何初始化。
        Tab_Dye.BackColor = Me.BackColor
        Tab_QC.BackColor = Me.BackColor
        Tab_QC2.BackColor = Me.BackColor
    End Sub

    Private Sub Form_Me_Closing(ByVal sender As Object, ByRef e As System.ComponentModel.CancelEventArgs) Handles Me.Me_Closing
        ComFun.DelBillNewID(BillType.Produce, PID, "GH")
    End Sub

    Private Sub F30000_Produce_Me_Load() Handles Me.Me_Load
        'Dt_Produce.Columns.Add("GangHao", GetType(String))
        'Dt_Produce.Rows.Add(Dt_Produce.NewRow())
        'Dt_Produce.Rows(0)("GangHao") = "Test DataBinding"
        ID = 30000
        BzC_List1.Set_TextBox(TB_BZCID, TB_BZCName, TB_Contract)
        Client_List1.Set_TextBox(TB_ClientID, TB_ClientName, TB_Address)
        Bz_List1.Set_TextBox(TB_BZID, TB_BZName, TB_ClientID)
        LoadForm()
        BindingForm()
        If Mode = Mode_Enum.Add Then
            Dim D As Date = PClass.PClass.GetDate

            If CheckRight(ID, ClassMain.Add) = False Then Me.ShowErrMsg("没有权限添加" & Ch_Name & "!", True) : Exit Sub
            GetNewID()

            DP_JiaoHuo.Value = D
            DP_KaiDan.Value = D
            DP_LuoSe.Value = D
            DP_ShouPei.Value = D
            DP_RQC_ChuDui.Value = D
            DP_RQC_DuiCheng.Value = D
            DP_RQC_ZJ.Value = D
            DP_RQC_ZJ2.Value = D
            DP_RQC_ZJQC.Value = D
        End If
        Fg1.ReAddIndex()
        Fg2.ReAddIndex()
        TB_No.Focus()
        isLoaded = True
    End Sub

    Private Sub F30000_Produce_Form_KeyDown(ByVal sender As Object, ByRef e As System.Windows.Forms.KeyEventArgs) Handles Me.Form_KeyDown
        If e.KeyCode = Keys.Enter AndAlso (ActiveControl.Name <> Fg1.Name OrElse ActiveControl.Name <> Fg2.Name) Then
            Try
                SendKeys.SendWait("{TAB}")
            Catch ex As Exception
            End Try
        Else
            e.Handled = True
        End If
    End Sub
    ''' <summary>
    ''' 刷新表单信息
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub LoadForm()
        If Mode = Mode_Enum.Add Then
            Dim msg As DtReturnMsg = Produce_GetEmptyRow()
            If msg.IsOk Then
                Me.Dt_Produce = msg.Dt
                Me.Dt_Produce.Rows.Add(Me.Dt_Produce.NewRow)
            End If
        Else
            Dim msg As DtReturnMsg = Produce_GetById(ProduceId)
            If msg.IsOk Then
                Me.Dt_Produce = msg.Dt
            ElseIf Not Mode = Mode_Enum.Add Then
                ShowErrMsg("没能找到运转单[" & Me.P_F_RS_ID & "]信息")
            End If

        End If
        SetBZList()
    End Sub

#Region "布种列表,加载"
    Protected Sub SetBZList()
        Dim msg As DtReturnMsg = Produce_GetBZList(TB_No.Text)
        If msg.IsOk Then
            dt_PBZ = BaseClass.ComFun.GetNewDataTable(msg.Dt, " isNull(IsChengPIn,0)=0", "")
            dt_CBZ = BaseClass.ComFun.GetNewDataTable(msg.Dt, " isNull(IsChengPIn,0)=1", "")
            Fg1.DtToFG(dt_PBZ)
            Fg2.DtToFG(dt_CBZ)
            If dt_PBZ.Rows.Count = 0 Then
                FG1AddRow()
            End If
            If dt_CBZ.Rows.Count = 0 Then
                Fg2AddRow()
            End If
            CaculatePBZ()
            CaculateCBZ()
        End If
    End Sub

    Protected Function GetBZList() As DataTable
        Dim dt As New DataTable
        If dt_PBZ Is Nothing OrElse dt_CBZ Is Nothing Then
            ShowErrMsg("布种列表没有初始化!")
            Return Nothing
        Else
            For Each dr In dt_PBZ.Rows
                dr("GH") = TB_No.Text
                dr("IsChengPIn") = False
            Next
            For Each dr In dt_CBZ.Rows
                dr("GH") = TB_No.Text
                dr("IsChengPIn") = True
            Next
            dt = dt_PBZ.Copy
            dt.Merge(dt_CBZ)
            Return dt
        End If

    End Function
#End Region
#Region "表单信息"
    ''' <summary>
    ''' 绑定表单信息
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub BindingForm()
        ''表头
        TB_No.DataBindings.Add("Text", Dt_Produce, "GH", True, DataSourceUpdateMode.OnPropertyChanged)
        '    TB_GangHao.DataBindings.Add("Text", Dt_Produce, "GangHao", True, DataSourceUpdateMode.OnPropertyChanged)
        TB_BZCID.DataBindings.Add("Text", Dt_Produce, "BZC_No", True, DataSourceUpdateMode.OnPropertyChanged)
        TB_BZCName.DataBindings.Add("Text", Dt_Produce, "BZC_Name", True, DataSourceUpdateMode.OnPropertyChanged)
        TB_ClientID.DataBindings.Add("Text", Dt_Produce, "Client_No", True, DataSourceUpdateMode.OnPropertyChanged)
        TB_ClientName.DataBindings.Add("Text", Dt_Produce, "Client_Name", True, DataSourceUpdateMode.OnPropertyChanged)
        TB_BZCClient.DataBindings.Add("Text", Dt_Produce, "ClientBZC", True, DataSourceUpdateMode.OnPropertyChanged)
        TB_BZID.DataBindings.Add("Text", Dt_Produce, "BZ_No", True, DataSourceUpdateMode.OnPropertyChanged)
        TB_BZName.DataBindings.Add("Text", Dt_Produce, "BZ_Name", True, DataSourceUpdateMode.OnPropertyChanged)
        TB_Contract.DataBindings.Add("Text", Dt_Produce, "Contract", True, DataSourceUpdateMode.OnPropertyChanged)
        TB_TextileFatory.DataBindings.Add("Text", Dt_Produce, "TextileFatory", True, DataSourceUpdateMode.OnPropertyChanged)
        TB_GangShu.DataBindings.Add("Text", Dt_Produce, "GangShu", True, DataSourceUpdateMode.OnPropertyChanged)
        TB_GangCi.DataBindings.Add("Text", Dt_Produce, "GangCi", True, DataSourceUpdateMode.OnPropertyChanged)
        TB_ShaPi.DataBindings.Add("Text", Dt_Produce, "ShaPi", True, DataSourceUpdateMode.OnPropertyChanged)
        TB_ProcessType.DataBindings.Add("Text", Dt_Produce, "ProcessType", True, DataSourceUpdateMode.OnPropertyChanged)
        TB_Address.DataBindings.Add("Text", Dt_Produce, "Address", True, DataSourceUpdateMode.OnPropertyChanged)
        TB_Remark.DataBindings.Add("Text", Dt_Produce, "Remark", True, DataSourceUpdateMode.OnPropertyChanged)
        DP_JiaoHuo.DataBindings.Add("Value", Dt_Produce, "Date_JiaoHuo", True, DataSourceUpdateMode.OnPropertyChanged)
        DP_KaiDan.DataBindings.Add("Value", Dt_Produce, "Date_KaiDan", True, DataSourceUpdateMode.OnPropertyChanged)
        DP_LuoSe.DataBindings.Add("Value", Dt_Produce, "Date_LuoSe", True, DataSourceUpdateMode.OnPropertyChanged)
        DP_ShouPei.DataBindings.Add("Value", Dt_Produce, "Date_ShouPei", True, DataSourceUpdateMode.OnPropertyChanged)

        TB_ZhiTong.DataBindings.Add("Text", Dt_Produce, "ZhiTong", True, DataSourceUpdateMode.OnPropertyChanged, 0, PClass.PClass.FormatSharp("num"))
        TB_JiaZhong.DataBindings.Add("Text", Dt_Produce, "JiaZhong", True, DataSourceUpdateMode.OnPropertyChanged, 0, PClass.PClass.FormatSharp("num"))

        ''客户要求
        CB_ZhuangBaiSe.DataBindings.Add("Checked", Dt_Produce, "CR_ZhuangBaiSe", True, DataSourceUpdateMode.OnPropertyChanged)
        CB_QieBian.DataBindings.Add("Checked", Dt_Produce, "CR_QieBian", True, DataSourceUpdateMode.OnPropertyChanged)
        CB_YinHuaYong.DataBindings.Add("Checked", Dt_Produce, "CR_YinHuaYong", True, DataSourceUpdateMode.OnPropertyChanged)
        CB_RiShai.DataBindings.Add("Checked", Dt_Produce, "CR_RiShai", True, DataSourceUpdateMode.OnPropertyChanged)
        CB_GanCa.DataBindings.Add("Checked", Dt_Produce, "CR_GanCa", True, DataSourceUpdateMode.OnPropertyChanged)
        CB_ShiCa.DataBindings.Add("Checked", Dt_Produce, "CR_ShiCa", True, DataSourceUpdateMode.OnPropertyChanged)
        TB_XiLao.DataBindings.Add("Text", Dt_Produce, "CR_XiLao", True, DataSourceUpdateMode.OnPropertyChanged)
        CB_ChengXi.DataBindings.Add("Checked", Dt_Produce, "CR_ChengYiXiShui", True, DataSourceUpdateMode.OnPropertyChanged)
        CB_ShiMao.DataBindings.Add("Checked", Dt_Produce, "CR_ShiMao", True, DataSourceUpdateMode.OnPropertyChanged)
        CB_KaiDing.DataBindings.Add("Checked", Dt_Produce, "CR_KaiDing", True, DataSourceUpdateMode.OnPropertyChanged)
        CB_ShiYong.DataBindings.Add("Checked", Dt_Produce, "CR_ShiYong", True, DataSourceUpdateMode.OnPropertyChanged)
        CB_BianDuiBian.DataBindings.Add("Checked", Dt_Produce, "CR_BianDuiBian", True, DataSourceUpdateMode.OnPropertyChanged)
        TB_KeZhong.DataBindings.Add("Text", Dt_Produce, "CR_KeZhong", True, DataSourceUpdateMode.OnPropertyChanged)
        CB_JiangBian.DataBindings.Add("Checked", Dt_Produce, "CR_JiangBian", True, DataSourceUpdateMode.OnPropertyChanged)
        CB_HengSuo.DataBindings.Add("Checked", Dt_Produce, "CR_HengSuo", True, DataSourceUpdateMode.OnPropertyChanged)
        CB_ZhiSuo.DataBindings.Add("Checked", Dt_Produce, "CR_ZhiSuo", True, DataSourceUpdateMode.OnPropertyChanged)
        TB_NiuDu.DataBindings.Add("Text", Dt_Produce, "CR_NiuDu", True, DataSourceUpdateMode.OnPropertyChanged)
        CB_KaiZhua.DataBindings.Add("Checked", Dt_Produce, "CR_KaiZhua", True, DataSourceUpdateMode.OnPropertyChanged)
        CB_DanMo.DataBindings.Add("Checked", Dt_Produce, "CR_DanMo", True, DataSourceUpdateMode.OnPropertyChanged)
        CB_DanXi.DataBindings.Add("Checked", Dt_Produce, "CR_DanXi", True, DataSourceUpdateMode.OnPropertyChanged)
        CB_ShuangJiaoDai.DataBindings.Add("Checked", Dt_Produce, "CR_ShuangJiaoDai", True, DataSourceUpdateMode.OnPropertyChanged)
        CB_PaoGan.DataBindings.Add("Checked", Dt_Produce, "CR_PaoGan", True, DataSourceUpdateMode.OnPropertyChanged)
        CB_SuoShuiJi.DataBindings.Add("Checked", Dt_Produce, "CR_SuoShuiJi", True, DataSourceUpdateMode.OnPropertyChanged)
        CB_RuShuangDai.DataBindings.Add("Checked", Dt_Produce, "CR_RuShuangDai", True, DataSourceUpdateMode.OnPropertyChanged)
        TB_DuiGang.DataBindings.Add("Text", Dt_Produce, "DuiSeGangHao", True, DataSourceUpdateMode.OnPropertyChanged)
        TB_HeGang.DataBindings.Add("Text", Dt_Produce, "HeRanGangHao", True, DataSourceUpdateMode.OnPropertyChanged)
        ''染色事项

        TB_DyeingNote.DataBindings.Add("Text", Dt_Produce, "Dyeing_Note", True, DataSourceUpdateMode.OnPropertyChanged)
        TB_DyeingWay.DataBindings.Add("Text", Dt_Produce, "Dyeing_Way", True, DataSourceUpdateMode.OnPropertyChanged)
        TB_Dyeing_AfterProcess.DataBindings.Add("Text", Dt_Produce, "Dyeing_AtfterProcess", True, DataSourceUpdateMode.OnPropertyChanged)
        '染色QC
        TB_RQC_ChuDui.DataBindings.Add("Text", Dt_Produce, "RQC_ChuDui", True, DataSourceUpdateMode.OnPropertyChanged)
        TB_RQC_ChuDuiSign.DataBindings.Add("Text", Dt_Produce, "RQC_ChuDui_Sign", True, DataSourceUpdateMode.OnPropertyChanged)
        DP_RQC_ChuDui.DataBindings.Add("Value", Dt_Produce, "RQC_ChuDui_Date", True, DataSourceUpdateMode.OnPropertyChanged)

        TB_RQC_ZhongDui.DataBindings.Add("Text", Dt_Produce, "RQC_ZJ1", True, DataSourceUpdateMode.OnPropertyChanged)
        TB_RQC_ZJSign.DataBindings.Add("Text", Dt_Produce, "RQC_ZJ1_Sign", True, DataSourceUpdateMode.OnPropertyChanged)
        DP_RQC_ZJ.DataBindings.Add("Value", Dt_Produce, "RQC_ZJ1_Date", True, DataSourceUpdateMode.OnPropertyChanged)

        TB_RQC_ZJQC.DataBindings.Add("Text", Dt_Produce, "RQC_QC", True, DataSourceUpdateMode.OnPropertyChanged)
        TB_RQC_ZJQCSign.DataBindings.Add("Text", Dt_Produce, "RQC_QC_Sign", True, DataSourceUpdateMode.OnPropertyChanged)
        DP_RQC_ZJQC.DataBindings.Add("Value", Dt_Produce, "RQC_QC_Date", True, DataSourceUpdateMode.OnPropertyChanged)

        TB_RQC_ZJ2.DataBindings.Add("Text", Dt_Produce, "RQC_ZJ2", True, DataSourceUpdateMode.OnPropertyChanged)
        TB_RQC_ZJ2Sign.DataBindings.Add("Text", Dt_Produce, "RQC_ZJ2_Sign", True, DataSourceUpdateMode.OnPropertyChanged)
        DP_RQC_ZJ2.DataBindings.Add("Value", Dt_Produce, "RQC_ZJ2_Date", True, DataSourceUpdateMode.OnPropertyChanged)

        TB_RQC_DuiCheng.DataBindings.Add("Text", Dt_Produce, "RQC_DuiCheng", True, DataSourceUpdateMode.OnPropertyChanged)
        TB_RQC_DuiChengSign.DataBindings.Add("Text", Dt_Produce, "RQC_DuiCheng_Sign", True, DataSourceUpdateMode.OnPropertyChanged)
        DP_RQC_DuiCheng.DataBindings.Add("Value", Dt_Produce, "RQC_DuiCheng_Date", True, DataSourceUpdateMode.OnPropertyChanged)

        '定型QC
        DQC_DQ1_CunShu.DataBindings.Add("Text", Dt_Produce, "DQC_DQ1_CunShu", True, DataSourceUpdateMode.OnPropertyChanged)
        DQC_DQ1_ZhongLiang.DataBindings.Add("Text", Dt_Produce, "DQC_DQ1_ZhongLiang", True, DataSourceUpdateMode.OnPropertyChanged)
        DQC_DQ1_MeiMa.DataBindings.Add("Text", Dt_Produce, "DQC_DQ1_MeiMa", True, DataSourceUpdateMode.OnPropertyChanged)
        DQC_DQ1_WenDu.DataBindings.Add("Text", Dt_Produce, "DQC_DQ1_WenDu", True, DataSourceUpdateMode.OnPropertyChanged)
        DQC_DQ1_JiSu.DataBindings.Add("Text", Dt_Produce, "DQC_DQ1_JiSu", True, DataSourceUpdateMode.OnPropertyChanged)
        DQC_DQ1_JiaKai.DataBindings.Add("Text", Dt_Produce, "DQC_DQ1_JiaKai", True, DataSourceUpdateMode.OnPropertyChanged)
        DQC_DQ1_Up.DataBindings.Add("Text", Dt_Produce, "DQC_DQ1_Up", True, DataSourceUpdateMode.OnPropertyChanged)
        DQC_DQ1_Down.DataBindings.Add("Text", Dt_Produce, "DQC_DQ1_Down", True, DataSourceUpdateMode.OnPropertyChanged)
        DQC_DQ2_CunShu.DataBindings.Add("Text", Dt_Produce, "DQC_DQ2_CunShu", True, DataSourceUpdateMode.OnPropertyChanged)
        DQC_DQ2_ZhongLiang.DataBindings.Add("Text", Dt_Produce, "DQC_DQ2_ZhongLiang", True, DataSourceUpdateMode.OnPropertyChanged)
        DQC_DQ2_MeiMa.DataBindings.Add("Text", Dt_Produce, "DQC_DQ2_MeiMa", True, DataSourceUpdateMode.OnPropertyChanged)
        DQC_DQ2_PeiFang.DataBindings.Add("Text", Dt_Produce, "DQC_DQ2_PeiFang", True, DataSourceUpdateMode.OnPropertyChanged)
        DQC_DQ3_CunShu.DataBindings.Add("Text", Dt_Produce, "DQC_DQ3_CunShu", True, DataSourceUpdateMode.OnPropertyChanged)
        DQC_DQ3_ZhongLiang.DataBindings.Add("Text", Dt_Produce, "DQC_DQ3_ZhongLiang", True, DataSourceUpdateMode.OnPropertyChanged)
        DQC_DQ3_MeiMa.DataBindings.Add("Text", Dt_Produce, "DQC_DQ3_MeiMa", True, DataSourceUpdateMode.OnPropertyChanged)
        DQC_DQ3_WenDu.DataBindings.Add("Text", Dt_Produce, "DQC_DQ3_WenDu", True, DataSourceUpdateMode.OnPropertyChanged)
        DQC_DQ3_JiSu.DataBindings.Add("Text", Dt_Produce, "DQC_DQ3_JiSu", True, DataSourceUpdateMode.OnPropertyChanged)
        DQC_DQ3_JiaKai.DataBindings.Add("Text", Dt_Produce, "DQC_DQ3_JiaKai", True, DataSourceUpdateMode.OnPropertyChanged)
        DQC_DQ3_Up.DataBindings.Add("Text", Dt_Produce, "DQC_DQ3_Up", True, DataSourceUpdateMode.OnPropertyChanged)
        DQC_DQ3_Down.DataBindings.Add("Text", Dt_Produce, "DQC_DQ3_Down", True, DataSourceUpdateMode.OnPropertyChanged)
        DQC_DH_CunShu.DataBindings.Add("Text", Dt_Produce, "DQC_DH_CunShu", True, DataSourceUpdateMode.OnPropertyChanged)
        DQC_DH_ZhongLiang.DataBindings.Add("Text", Dt_Produce, "DQC_DH_ZhongLiang", True, DataSourceUpdateMode.OnPropertyChanged)
        DQC_DH_MeiMa.DataBindings.Add("Text", Dt_Produce, "DQC_DH_MeiMa", True, DataSourceUpdateMode.OnPropertyChanged)
        DQC_DH_PeiFang.DataBindings.Add("Text", Dt_Produce, "DQC_DH_PeiFang", True, DataSourceUpdateMode.OnPropertyChanged)
        DQC_JQ_HengSuo.DataBindings.Add("Text", Dt_Produce, "DQC_JQ_HengSuo", True, DataSourceUpdateMode.OnPropertyChanged)
        DQC_JQ_ZhiSuo.DataBindings.Add("Text", Dt_Produce, "DQC_JQ_ZhiSuo", True, DataSourceUpdateMode.OnPropertyChanged)
        DQC_JQ_NiuDu.DataBindings.Add("Text", Dt_Produce, "DQC_JQ_NiuDu", True, DataSourceUpdateMode.OnPropertyChanged)
        DQC_JQ_XihouZhong.DataBindings.Add("Text", Dt_Produce, "DQC_JQ_XihouZhong", True, DataSourceUpdateMode.OnPropertyChanged)
        DQC_JQ_KeZhong.DataBindings.Add("Text", Dt_Produce, "DQC_JQ_KeZhong", True, DataSourceUpdateMode.OnPropertyChanged)
        DQC_JQ_XieWen.DataBindings.Add("Text", Dt_Produce, "DQC_JQ_XieWen", True, DataSourceUpdateMode.OnPropertyChanged)


        '其他
        TB_KaiDan.DataBindings.Add("Text", Dt_Produce, "KaiDan", True, DataSourceUpdateMode.OnPropertyChanged)
        TB_Auditor.DataBindings.Add("Text", Dt_Produce, "Auditor", True, DataSourceUpdateMode.OnPropertyChanged)
        TB_GenDan.DataBindings.Add("Text", Dt_Produce, "GengDan", True, DataSourceUpdateMode.OnPropertyChanged)
        TB_UPD_User.DataBindings.Add("Text", Dt_Produce, "UPD_User", True, DataSourceUpdateMode.OnPropertyChanged)

        'LB_PBZCount.DataBindings.Add("Text", Dt_Produce, "PBZ_Weight", True, DataSourceUpdateMode.OnPropertyChanged)
        'LB_PBZCount.DataBindings.Add("Tag", Dt_Produce, "PBZ_Count", True, DataSourceUpdateMode.OnPropertyChanged)
        'LB_CBZCount.DataBindings.Add("Text", Dt_Produce, "CBZ_Weight", True, DataSourceUpdateMode.OnPropertyChanged)
        'LB_CBZCount.DataBindings.Add("Tag", Dt_Produce, "CBZ_Count", True, DataSourceUpdateMode.OnPropertyChanged)

    End Sub


#End Region
#Region "工具栏事件"




    ''' <summary>
    ''' 保存按钮
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_Modify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Modify.Click
        Fg1.FinishEditing(True)
        If CheckForm() Then
            TB_UPD_User.Text = PClass.PClass.User_Name
            If Mode = Mode_Enum.Add Then
                ShowConfirm("是否保存新" & Ch_Name & "?", AddressOf SaveProduce)
            Else
                ShowConfirm("是否保存" & Ch_Name & "[" & TB_No.Text & "] 的修改?", AddressOf SaveProduce)
            End If
        End If
    End Sub

    ''' <summary>
    ''' 保存修改
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub SaveProduce()
        Dim R As MsgReturn
        If Me.Mode = Mode_Enum.Add Then
            R = Produce_Add(Dt_Produce, GetBZList)
        Else
            R = Produce_Save(Dt_Produce, GetBZList)
        End If
        If R.IsOk Then
            LastForm.ReturnId = TB_No.Text
            ShowOk(R.Msg, True)
        Else
            ShowErrMsg(R.Msg)
        End If
    End Sub



    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub

    Private Sub Cmd_Del_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmd_Del.Click
        If Mode = Mode_Enum.Modify Then
            ShowMsg("确定删除运转单[" & TB_No.Text & "]?", AddressOf DelProduce)
        End If
    End Sub

    Protected Sub DelProduce()
        Dim msg As MsgReturn = Produce_Del(TB_No.Text)
        If msg.IsOk = False Then
            ShowErrMsg(msg.Msg)
        Else
            Me.Close()
        End If
    End Sub



    Private Sub Cmd_DelPBZ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_DelPBZ.Click
        If Fg1.RowSel > 0 Then
            FG1RemoveRow()
        End If
    End Sub

    Private Sub Cmd_DelCBZ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_DelCBZ.Click
        If Fg2.RowSel > 0 Then
            FG2RemoveRow()
        End If
    End Sub

    Private Sub Cmd_AddPBZ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_AddPBZ.Click
        FG1AddRow()
    End Sub

    Private Sub Cmd_AddCBZ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_AddCBZ.Click
        Fg2AddRow()
    End Sub

#End Region
#Region "form 验证"
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Function CheckForm() As Boolean
        DP_JiaoHuo.Value = DP_JiaoHuo.Value.Date
        DP_KaiDan.Value = DP_KaiDan.Value.Date
        DP_LuoSe.Value = DP_LuoSe.Value.Date
        DP_RQC_ChuDui.Value = DP_RQC_ChuDui.Value.Date
        DP_RQC_DuiCheng.Value = DP_RQC_DuiCheng.Value.Date
        DP_RQC_ZJ.Value = DP_RQC_ZJ.Value.Date
        DP_RQC_ZJ2.Value = DP_RQC_ZJ2.Value.Date
        DP_RQC_ZJQC.Value = DP_RQC_ZJQC.Value.Date
        DP_ShouPei.Value = DP_ShouPei.Value.Date
        If Not dt_PBZ Is Nothing Then
            dt_PBZ.AcceptChanges()
            For i = dt_PBZ.Rows.Count - 1 To 0 Step -1
                If IsNull(dt_PBZ.Rows(i)("BZ_Num"), 0) = 0 AndAlso IsNull(dt_PBZ.Rows(i)("BZ_Weight"), 0) = 0 Then
                    dt_PBZ.Rows(i).Delete()
                End If
            Next
            dt_PBZ.AcceptChanges()
        End If
        If Not dt_CBZ Is Nothing Then
            dt_CBZ.AcceptChanges()
            For i = dt_CBZ.Rows.Count - 1 To 0 Step -1
                If IsNull(dt_CBZ.Rows(i)("BZ_Num"), 0) = 0 AndAlso IsNull(dt_CBZ.Rows(i)("BZ_Weight"), 0) = 0 Then
                    dt_CBZ.Rows(i).Delete()
                End If
            Next
            dt_CBZ.AcceptChanges()
        End If
        CaculatePBZ()
        CaculateCBZ()


        Return True
    End Function
#End Region
#Region "FG1事件"

    Private Sub Fg1_AfterEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles Fg1.AfterEdit
        If Fg1.LastKey = Keys.Enter Then
            Fg1.GotoNextCell()

        End If
        CaculatePBZ()

    End Sub


    Private Sub Fg1_NextCell(ByVal e As PClass.FG.NextCellEventArgs) Handles Fg1.NextCell
        Select Case e.Col
            Case "BZ_Weight"
                If Fg1.Cols(e.Col).Index = Fg1.Cols.Count - 1 Then
                    If e.Row = Fg1.Rows.Count - 1 AndAlso Fg1.Rows.Count < BZListLimit Then
                        FG1AddRow()

                    End If
                    e.ToRow = e.Row + 1
                    e.ToCol = Fg1.Cols("BZ_Num").Index
                End If

            Case Else
                e.ToCol = Fg1.Cols(e.Col).Index + 1
        End Select
    End Sub


    ''' <summary>
    ''' 增行
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub FG1AddRow()
        If Fg1.Rows.Count < BZListLimit Then


            dt_PBZ.Rows.Add(dt_PBZ.NewRow)
            Fg1.ReAddIndex()
        End If
    End Sub

    ''' <summary>
    ''' 减行
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub FG1RemoveRow()
        Fg1.Select(Fg1.RowSel, 0)
        Dim i As Integer = Fg1.RowSel

        If i > 0 AndAlso Fg1.Rows.Count > 1 Then
            Try
                Fg1.Rows.Remove(i)
            Catch ex As Exception
            End Try
            If Fg1.Rows.Count < 2 Then
            Else
                Fg1.ReAddIndex()
            End If
        End If
    End Sub

    Dim lastKey As Keys



#End Region
#Region "FG2事件"

    Private Sub Fg2_AfterEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles Fg2.AfterEdit
        If Fg2.LastKey = Keys.Enter Then
            Fg2.GotoNextCell()


        End If
        CaculateCBZ()
    End Sub


    Private Sub Fg2_NextCell(ByVal e As PClass.FG.NextCellEventArgs) Handles Fg2.NextCell
        Select Case e.Col
            Case "BZ_Weight"
                If Fg2.Cols(e.Col).Index = Fg2.Cols.Count - 1 Then
                    If e.Row = Fg2.Rows.Count - 1 AndAlso Fg2.Rows.Count < BZListLimit Then
                        Fg2AddRow()

                    End If
                    e.ToRow = e.Row + 1
                    e.ToCol = Fg2.Cols("BZ_Num").Index
                End If

            Case Else
                e.ToCol = Fg2.Cols(e.Col).Index + 1
        End Select
    End Sub


    ''' <summary>
    ''' 增行
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub Fg2AddRow()
        If Fg2.Rows.Count < BZListLimit Then


            dt_CBZ.Rows.Add(dt_CBZ.NewRow)
            '  End If
            '   Fg2.Rows.Add()
            Fg2.ReAddIndex()
        End If
    End Sub

    ''' <summary>
    ''' 减行
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub FG2RemoveRow()
        Fg2.Select(Fg2.RowSel, 0)
        Dim i As Integer = Fg2.RowSel

        If i > 0 AndAlso Fg2.Rows.Count > 1 Then
            Try
                Fg2.Rows.Remove(i)
            Catch ex As Exception
            End Try
            If Fg2.Rows.Count < 2 Then
            Else
                Fg2.ReAddIndex()
            End If

        End If
    End Sub





#End Region
#Region "统计行"
    Protected Sub CaculatePBZ()
        dt_PBZ.AcceptChanges()
        If Not dt_PBZ Is Nothing AndAlso dt_PBZ.Rows.Count > 0 Then
            Dim sumBZNum As Double = 0
            Dim sumBZWeight As Double = 0
            Dim count As Double = 0
            For Each dr In dt_PBZ.Rows
                count = count + 1
                sumBZNum = sumBZNum + IsNull(dr("BZ_Num"), 0)
                sumBZWeight = sumBZWeight + IsNull(dr("BZ_Weight"), 0)
            Next
            LB_PBZ.Text = sumBZNum
            LB_PBZCount.Text = sumBZWeight
            LB_PBZCount.Tag = count
            If Not Dt_Produce Is Nothing AndAlso Dt_Produce.Rows.Count = 1 Then
                Dt_Produce.Rows(0)("PBZ_Count") = count
                Dt_Produce.Rows(0)("PBZ_Weight") = sumBZWeight

            End If
        End If
    End Sub

    Protected Sub CaculateCBZ()
        dt_CBZ.AcceptChanges()
        If Not dt_CBZ Is Nothing AndAlso dt_CBZ.Rows.Count > 0 Then
            Dim sumBZNum As Double = 0
            Dim sumBZWeight As Double = 0
            Dim count As Double = 0
            For Each dr In dt_CBZ.Rows
                sumBZNum = sumBZNum + IsNull(dr("BZ_Num"), 0)
                sumBZWeight = sumBZWeight + IsNull(dr("BZ_Weight"), 0)
                count = count + 1
            Next
            LB_CBZ.Text = sumBZNum
            LB_CBZCount.Text = sumBZWeight
            LB_CBZCount.Tag = count
            If Not Dt_Produce Is Nothing AndAlso Dt_Produce.Rows.Count = 1 Then
                Dt_Produce.Rows(0)("CBZ_Count") = count
                Dt_Produce.Rows(0)("CBZ_Weight") = sumBZWeight

            End If
        End If
    End Sub
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
        If TB_No.ReadOnly = False Then
            If DP_KaiDan.Value <> PID_Date Then
                Dim R As RetrunNewIdMsg = ComFun.GetBillNewID(BillType.Produce, DP_KaiDan.Value, PID)
                If R.IsOk Then
                    PID_Date = R.NewIdDate
                    DP_KaiDan.MinDate = R.MaxDate.AddDays(1)
                    DP_KaiDan.Value = R.NewIdDate
                    PID = R.NewID
                    TB_No.Text = PID.Replace("-", "")
                    If R.IsTheDate = False Then
                        ShowErrMsg(R.RetrunMsg)
                    End If
                Else
                    ShowErrMsg(R.RetrunMsg)
                End If
            End If
        End If
    End Sub
    Private Sub DP_Date_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DP_KaiDan.ValueChanged
        GetNewID()
    End Sub
#End Region
#Region "双击获取新编号"


    Private Sub TB_No_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TB_No.MouseDoubleClick
        If Mode = Mode_Enum.Add Then
            GetNewID()
        End If

    End Sub
#End Region
    Private Sub LB_Remark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LB_Remark.Click
        Dim f As PClass.BaseForm = LoadFormIDToChild(10200, Me)
        f.IsSel = True
        F_RS_ID = ""
        Me.ReturnId = ""
        Me.ReturnObj = Nothing
        Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(f, Me)
        VF.Width = 400
        VF.Height = 400
        AddHandler VF.ClosedX, AddressOf setRemark
        VF.Show()
    End Sub
    Sub setRemark()
        If Me.ReturnObj Is Nothing OrElse Me.ReturnObj = "" Then
            Exit Sub
        End If
        If Me.TB_Remark.Text.Trim = "" Then
            Me.TB_Remark.Text = Me.ReturnObj
        Else
            Me.TB_Remark.Text = Me.TB_Remark.Text & "; " & Me.ReturnObj
        End If

        Me.ReturnObj = ""
    End Sub

    Private Sub Cmd_ChooseRemark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_ChooseRemark.Click
        Dim f As PClass.BaseForm = LoadFormIDToChild(10200, Me)
        f.IsSel = True
        F_RS_ID = ""
        Me.ReturnId = ""
        Me.ReturnObj = Nothing
        Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(f, Me)
        VF.Width = 400
        VF.Height = 400
        AddHandler VF.ClosedX, AddressOf setRemark
        VF.Show()
    End Sub
#End Region

#Region "搜索色号"
    Private Sub TB_BZCID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TB_BZCID.TextChanged
        If isLoaded = False Then
            Exit Sub
        End If
        Dim msg As DtReturnMsg = Produce_GetClientBZC(TB_BZCID.Text, TB_BZID.Text)
        If msg.IsOk And msg.Dt.Rows.Count > 0 Then
            TB_BZCClient.Text = IsNull(msg.Dt.Rows(0)("Client_Bzc"), "")
        Else
            TB_BZCClient.Text = ""
        End If
        Dim msgBz As DtReturnMsg = Produce_GetBZListByBzcID(TB_BZCID.Text)
        If msgBz.IsOk And msgBz.Dt.Rows.Count > 0 Then
            TB_BZID.Text = IsNull(msgBz.Dt.Rows(0)("BZ_No"), "")
            TB_BZName.Text = IsNull(msgBz.Dt.Rows(0)("BZ_Name"), "")
        Else
            TB_BZID.Text = ""
            TB_BZName.Text = ""
        End If

        Dim msgClient As DtReturnMsg = Produce_GetClientByBzcID(TB_BZCID.Text)
        If msgClient.IsOk And msg.Dt.Rows.Count > 0 Then
            TB_ClientID.Text = IsNull(msgClient.Dt.Rows(0)("Client_No"), "")
            TB_ClientName.Text = IsNull(msgClient.Dt.Rows(0)("Client_Name"), "")
        Else
            TB_ClientID.Text = ""
            TB_ClientName.Text = ""
        End If
    End Sub

    Private Sub TB_BZID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TB_BZID.TextChanged
        Dim msg As DtReturnMsg = Produce_GetClientBZC(TB_BZCID.Text, TB_BZID.Text)
        If msg.IsOk And msg.Dt.Rows.Count > 0 Then
            TB_BZCClient.Text = msg.Dt.Rows(0)("Client_Bzc")
        Else
            TB_BZCClient.Text = ""
        End If
    End Sub

#End Region




End Class
