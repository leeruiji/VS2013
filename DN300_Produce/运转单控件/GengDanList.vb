Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports BaseClass
Imports PClass.CReport
Imports PClass.BaseForm

Public Class GengDanList
    Dim ID As Integer
    Dim Ch_Name As String = ""
    Dim Dt_Produce As New DataTable
    Dim Dt_BZ As New DataTable
    Dim ProduceId As String = ""
    Dim mode As PClass.BaseForm.Mode_Enum
    Dim LastForm As PClass .BaseForm 
   Dim returnID As String =""
    Dim ReturnObj As Object = Nothing
   Dim returnMsg As String =""
Dim P_F_RS_ID As String =""

    Dim isLoaded As Boolean = False


    Public Sub New()

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。

    End Sub

    Public Sub New(ByVal produceId As String)

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        Me.ProduceId = produceId
        TB_No.Text = produceId
        ' 在 InitializeComponent() 调用之后添加任何初始化。
        Me.Ch_Name = "生产单跟单"
        ID = 30000
    End Sub

    ''' <summary>
    ''' 权限获取
    ''' </summary>
    ''' <remarks></remarks>
    Sub FormCheckRight()
        ID = 30000
        Control_CheckRight(ID, ClassMain.Modify, Cmd_Modify)
        Control_CheckRight(ID, ClassMain.Del, Cmd_Del)
        Control_CheckRight(ID, ClassMain.LuoDan, Cmd_LuoDan)
        Control_CheckRight(ID, ClassMain.Print, Cmd_Preview)
        Control_CheckRight(ID, ClassMain.Print, Cmd_Print)
    End Sub
    Private Sub Me_Load(ByVal Sender As Object, ByVal e As EventArgs) Handles Me.Load

    End Sub

    Private Sub ME_LoadForm()
        FormCheckRight()
        'Dt_Produce.Columns.Add("GangHao", GetType(String))
        'Dt_Produce.Rows.Add(Dt_Produce.NewRow())
        'Dt_Produce.Rows(0)("GangHao") = "Test DataBinding"
        Employee_List1.Set_TextBox(TB_GenDan, TB_Auditor)
        Bzc_List1.Set_TextBox(TB_BZCID, TB_BZCName, TB_Contract)
        ' Client_List1.Set_TextBox(TB_ClientID, TB_ClientName, TB_Address)
        Bz_List1.Set_TextBox(TB_BZID, TB_BZName, TB_ClientID)

        LoadForm()
        SetForm()
        BindingForm()
        If mode = PClass.BaseForm.Mode_Enum.Add Then
            TB_KaiDan.Text = PClass.PClass.User_Display
            DP_KaiDan.Value = PClass.PClass.GetDate
            DP_JiaoHuo.Value = PClass.PClass.GetDate
            DP_LuoSe.Value = PClass.PClass.GetDate
            DP_ShouPei.Value = PClass.PClass.GetDate
            Dim msg As RetrunNewIdMsg = Dao.ProduceGd_GetNewID(DP_KaiDan.Value.Date)
            If msg.IsOk Then
                TB_No.Text = msg.NewID
            End If

        End If

        TB_No.Focus()
        isLoaded = True
    End Sub

    Private Sub F30000_Produce_Form_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        If e.KeyCode = Keys.Enter Then
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
        If mode = Mode_Enum.Add Then

            Dim msg As DtReturnMsg = Dao.ProduceGd_GetEmptyRow()
            If msg.IsOk Then
                Me.Dt_Produce = msg.Dt
                Me.Dt_Produce.Rows.Add(Me.Dt_Produce.NewRow)

                Me.Dt_Produce.Rows(0)("State") = Enum_ProduceState.AddNew
            End If
        Else
            Dim msg As DtReturnMsg = Dao.ProduceGd_GetById(ProduceId)
            If msg.IsOk Then
                Me.Dt_Produce = msg.Dt
                If IsNull(Me.Dt_Produce.Rows(0)("State"), Enum_ProduceState.AddNew) <> Enum_ProduceState.AddNew Then
                    Me.Cmd_LuoDan.Enabled = False
                    Me.Cmd_Del.Enabled = False
                End If

            Else
                MsgBox("没能找到" & Dao.Produce_Gd_Name & "[" & Me.P_F_RS_ID & "]信息")
            End If

        End If
        Me.LB_State.Text = BaseClass.ComFun.GetProduceStateName(IsNull(Me.Dt_Produce.Rows(0)("State"), Enum_ProduceState.AddNew))
    End Sub


#Region "表单信息"
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub GetForm()
        If Me.Dt_Produce IsNot Nothing Then
            Dt_Produce.Rows(0)("BZC_ID") = Val(TB_BZCID.Tag)
            Dt_Produce.Rows(0)("BZC_No") = TB_BZCID.Text
            Dt_Produce.Rows(0)("BZC_Name") = TB_BZCName.Text

            Dt_Produce.Rows(0)("Client_ID") = Val(TB_ClientID.Tag)
            Dt_Produce.Rows(0)("Client_No") = TB_ClientID.Text
            Dt_Produce.Rows(0)("Client_Name") = TB_ClientName.Text

            Dt_Produce.Rows(0)("BZ_ID") = Val(TB_BZID.Tag)
            Dt_Produce.Rows(0)("BZ_No") = TB_BZID.Text
            Dt_Produce.Rows(0)("BZ_Name") = TB_BZName.Text
        End If


    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub SetForm()
        If Me.Dt_Produce IsNot Nothing Then
            TB_BZCID.Tag = IsNull(Dt_Produce.Rows(0)("BZC_ID"), 0)
            TB_BZCID.Text = IsNull(Dt_Produce.Rows(0)("BZC_No"), "")
            TB_BZCName.Text = IsNull(Dt_Produce.Rows(0)("BZC_Name"), "")

            TB_BZID.Tag = IsNull(Dt_Produce.Rows(0)("BZ_ID"), 0)
            TB_BZID.Text = IsNull(Dt_Produce.Rows(0)("BZ_No"), "")
            TB_BZName.Text = IsNull(Dt_Produce.Rows(0)("BZ_Name"), "")

            TB_ClientID.Tag = IsNull(Dt_Produce.Rows(0)("Client_ID"), 0)
            TB_ClientID.Text = IsNull(Dt_Produce.Rows(0)("Client_No"), "")
            TB_ClientName.Text = IsNull(Dt_Produce.Rows(0)("Client_Name"), "")



        End If


    End Sub

    ''' <summary>
    ''' 绑定表单信息
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub BindingForm()
        ''表头
        TB_No.DataBindings.Add("Text", Dt_Produce, "GH", True, DataSourceUpdateMode.OnPropertyChanged)
        '    TB_GangHao.DataBindings.Add("Text", Dt_Produce, "GangHao", True, DataSourceUpdateMode.OnPropertyChanged)
        'TB_BZCID.DataBindings.Add("Text", Dt_Produce, "BZC_No", True, DataSourceUpdateMode.OnPropertyChanged)
        'TB_BZCID.DataBindings.Add("Tag", Dt_Produce, "BZC_ID", True, DataSourceUpdateMode.OnPropertyChanged, 0)
        'TB_BZCName.DataBindings.Add("Text", Dt_Produce, "BZC_Name", True, DataSourceUpdateMode.OnPropertyChanged)

        'TB_ClientID.DataBindings.Add("Tag", Dt_Produce, "Client_ID", True, DataSourceUpdateMode.OnPropertyChanged, 0)
        'TB_ClientID.DataBindings.Add("Text", Dt_Produce, "Client_No", True, DataSourceUpdateMode.OnPropertyChanged)
        'TB_ClientName.DataBindings.Add("Text", Dt_Produce, "Client_Name", True, DataSourceUpdateMode.OnPropertyChanged)

        TB_BZCClient.DataBindings.Add("Text", Dt_Produce, "ClientBZC", True, DataSourceUpdateMode.OnPropertyChanged)

        'TB_BZID.DataBindings.Add("Tag", Dt_Produce, "BZ_ID", True, DataSourceUpdateMode.OnPropertyChanged, 0)
        'TB_BZID.DataBindings.Add("Text", Dt_Produce, "BZ_No", True, DataSourceUpdateMode.OnPropertyChanged)
        'TB_BZName.DataBindings.Add("Text", Dt_Produce, "BZ_Name", True, DataSourceUpdateMode.OnPropertyChanged)

        TB_Contract.DataBindings.Add("Text", Dt_Produce, "Contract", True, DataSourceUpdateMode.OnPropertyChanged)
        TB_TextileFatory.DataBindings.Add("Text", Dt_Produce, "TextileFatory", True, DataSourceUpdateMode.OnPropertyChanged)
        TB_GangShu.DataBindings.Add("Text", Dt_Produce, "GangShu", True, DataSourceUpdateMode.OnPropertyChanged)
        TB_GangCi.DataBindings.Add("Text", Dt_Produce, "GangCi", True, DataSourceUpdateMode.OnPropertyChanged)
        TB_ShaPi.DataBindings.Add("Text", Dt_Produce, "ShaPi", True, DataSourceUpdateMode.OnPropertyChanged)
        TB_ProcessType.DataBindings.Add("Text", Dt_Produce, "ProcessType", True, DataSourceUpdateMode.OnPropertyChanged)
        TB_Address.DataBindings.Add("Text", Dt_Produce, "Address", True, DataSourceUpdateMode.OnPropertyChanged)
        TB_Remark.DataBindings.Add("Text", Dt_Produce, "Remark", True, DataSourceUpdateMode.OnPropertyChanged)
        DP_JiaoHuo.DataBindings.Add("Value", Dt_Produce, "Date_JiaoHuo", True, DataSourceUpdateMode.OnPropertyChanged, "")
        DP_KaiDan.DataBindings.Add("Value", Dt_Produce, "Date_KaiDan", True, DataSourceUpdateMode.OnPropertyChanged, "")
        DP_LuoSe.DataBindings.Add("Value", Dt_Produce, "Date_LuoSe", True, DataSourceUpdateMode.OnPropertyChanged, "")
        DP_ShouPei.DataBindings.Add("Value", Dt_Produce, "Date_ShouPei", True, DataSourceUpdateMode.OnPropertyChanged, "")

        'If Dt_Produce.Rows(0)("Date_JiaoHuo") Is DBNull.Value Then
        '    DP_JiaoHuo.Text = ""
        'Else
        '    DP_JiaoHuo.Value = Dt_Produce.Rows(0)("Date_JiaoHuo")
        'End If

        'If Dt_Produce.Rows(0)("Date_KaiDan") Is DBNull.Value Then
        '    DP_KaiDan.Text = ""
        'Else
        '    DP_KaiDan.Value = Dt_Produce.Rows(0)("Date_KaiDan")
        'End If

        'If Dt_Produce.Rows(0)("Date_LuoSe") Is DBNull.Value Then
        '    DP_LuoSe.Text = ""
        'Else
        '    DP_LuoSe.Value = Dt_Produce.Rows(0)("Date_LuoSe")
        'End If

        'If Dt_Produce.Rows(0)("Date_ShouPei") Is DBNull.Value Then
        '    DP_ShouPei.Text = ""
        'Else
        '    DP_ShouPei.Value = Dt_Produce.Rows(0)("Date_ShouPei")
        'End If

        TB_ZhiTong.DataBindings.Add("Text", Dt_Produce, "ZhiTong", True, DataSourceUpdateMode.OnPropertyChanged, 0, PClass.PClass.FormatSharp("num"))
        TB_JiaZhong.DataBindings.Add("Text", Dt_Produce, "JiaZhong", True, DataSourceUpdateMode.OnPropertyChanged, 0, PClass.PClass.FormatSharp("num"))

        ''客户要求
        CB_ZhuangBaiSe.DataBindings.Add("Checked", Dt_Produce, "CR_ZhuangBaiSe", True, DataSourceUpdateMode.OnPropertyChanged)
        CB_QieBian.DataBindings.Add("Checked", Dt_Produce, "CR_QieBian", True, DataSourceUpdateMode.OnPropertyChanged)
        CB_YinHuaYong.DataBindings.Add("Checked", Dt_Produce, "CR_YinHuaYong", True, DataSourceUpdateMode.OnPropertyChanged)
        CB_RiShai.DataBindings.Add("Checked", Dt_Produce, "CR_RiShai", True, DataSourceUpdateMode.OnPropertyChanged)
        CB_GanCa.DataBindings.Add("Checked", Dt_Produce, "CR_GanCa", True, DataSourceUpdateMode.OnPropertyChanged)
        CB_ShiCa.DataBindings.Add("Checked", Dt_Produce, "CR_ShiCa", True, DataSourceUpdateMode.OnPropertyChanged)
        CB_ShiMao.DataBindings.Add("Checked", Dt_Produce, "CR_ShiMao", True, DataSourceUpdateMode.OnPropertyChanged)
        CB_KaiDing.DataBindings.Add("Checked", Dt_Produce, "CR_KaiDing", True, DataSourceUpdateMode.OnPropertyChanged)
        CB_KaiZhua.DataBindings.Add("Checked", Dt_Produce, "CR_KaiZhua", True, DataSourceUpdateMode.OnPropertyChanged)
        CB_DanMo.DataBindings.Add("Checked", Dt_Produce, "CR_DanMo", True, DataSourceUpdateMode.OnPropertyChanged)
        CB_DanXi.DataBindings.Add("Checked", Dt_Produce, "CR_DanXi", True, DataSourceUpdateMode.OnPropertyChanged)
        CB_ShuangJiaoDai.DataBindings.Add("Checked", Dt_Produce, "CR_ShuangJiaoDai", True, DataSourceUpdateMode.OnPropertyChanged)
        CB_PaoGan.DataBindings.Add("Checked", Dt_Produce, "CR_PaoGan", True, DataSourceUpdateMode.OnPropertyChanged)
        CB_SuoShuiJi.DataBindings.Add("Checked", Dt_Produce, "CR_SuoShuiJi", True, DataSourceUpdateMode.OnPropertyChanged)
        '  CB_RuShuangDai.DataBindings.Add("Checked", Dt_Produce, "CR_RuShuangDai", True, DataSourceUpdateMode.OnPropertyChanged)
        CB_JiangBian.DataBindings.Add("Checked", Dt_Produce, "CR_JiangBian", True, DataSourceUpdateMode.OnPropertyChanged)

        TB_DuiGang.DataBindings.Add("Text", Dt_Produce, "DuiSeGangHao", True, DataSourceUpdateMode.OnPropertyChanged)
        TB_HeGang.DataBindings.Add("Text", Dt_Produce, "HeRanGangHao", True, DataSourceUpdateMode.OnPropertyChanged)
        TB_XiLao.DataBindings.Add("Text", Dt_Produce, "CR_XiLao", True, DataSourceUpdateMode.OnPropertyChanged)
        TB_ChengXi.DataBindings.Add("Text", Dt_Produce, "CR_ChengYiXiShui", True, DataSourceUpdateMode.OnPropertyChanged)
        TB_ShiYong.DataBindings.Add("Text", Dt_Produce, "CR_ShiYong", True, DataSourceUpdateMode.OnPropertyChanged)
        TB_BianDuiBian.DataBindings.Add("Text", Dt_Produce, "CR_BianDuiBian", True, DataSourceUpdateMode.OnPropertyChanged)
        TB_KeZhong.DataBindings.Add("Text", Dt_Produce, "CR_KeZhong", True, DataSourceUpdateMode.OnPropertyChanged)

        TB_HengSuo.DataBindings.Add("Text", Dt_Produce, "CR_HengSuo", True, DataSourceUpdateMode.OnPropertyChanged)
        TB_ZhiSuo.DataBindings.Add("Text", Dt_Produce, "CR_ZhiSuo", True, DataSourceUpdateMode.OnPropertyChanged)
        TB_NiuDu.DataBindings.Add("Text", Dt_Produce, "CR_NiuDu", True, DataSourceUpdateMode.OnPropertyChanged)
        TB_LuoSeBzCount.DataBindings.Add("Text", Dt_Produce, "CR_LuoSeBzCount", False, DataSourceUpdateMode.OnPropertyChanged)
        TB_LuoSeBzZL.DataBindings.Add("Text", Dt_Produce, "CR_LuoSeBzZL", False, DataSourceUpdateMode.OnPropertyChanged)
        Radio_ZL.DataBindings.Add("Checked", Dt_Produce, "CR_LuoSeType", True, DataSourceUpdateMode.OnPropertyChanged, False)


        '其他
        TB_KaiDan.DataBindings.Add("Text", Dt_Produce, "KaiDan", True, DataSourceUpdateMode.OnPropertyChanged)
        '   TB_KaiDan.DataBindings.Add("Tag", Dt_Produce, "KaiDan", True, DataSourceUpdateMode.OnPropertyChanged)
        TB_Auditor.DataBindings.Add("Text", Dt_Produce, "Auditor", True, DataSourceUpdateMode.OnPropertyChanged)
        TB_GenDan.DataBindings.Add("Tag", Dt_Produce, "GengDan", True, DataSourceUpdateMode.OnPropertyChanged, "0")
        TB_GenDan.DataBindings.Add("Text", Dt_Produce, "GengDanName", True, DataSourceUpdateMode.OnPropertyChanged, "")
        TB_UPD_User.DataBindings.Add("Text", Dt_Produce, "UPD_User", True, DataSourceUpdateMode.OnPropertyChanged)

        'LB_PBZCount.DataBindings.Add("Text", Dt_Produce, "PBZ_Weight", True, DataSourceUpdateMode.OnPropertyChanged)
        'LB_PBZCount.DataBindings.Add("Tag", Dt_Produce, "PBZ_Count", True, DataSourceUpdateMode.OnPropertyChanged)
        'LB_CBZCount.DataBindings.Add("Text", Dt_Produce, "CBZ_Weight", True, DataSourceUpdateMode.OnPropertyChanged)
        'LB_CBZCount.DataBindings.Add("Tag", Dt_Produce, "CBZ_Count", True, DataSourceUpdateMode.OnPropertyChanged)
        ''配布信息
        TB_PB_CountSum.Text = IsNull(Dt_Produce.Rows(0)("PB_CountSum"), 0)
        TB_PB_ZLSum.Text = IsNull(Dt_Produce.Rows(0)("PB_ZLSum"), 0)






    End Sub


#End Region
#Region "工具栏事件"




    ''' <summary>
    ''' 保存按钮
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_Modify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_LuoDan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    ''' <summary>
    ''' 保存修改
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub SaveProduce()
        Dim R As MsgReturn
        GetForm()
        If Me.mode = Mode_Enum.Add Then
            R = Dao.ProduceGd_Add(Dt_Produce)
        Else
            R = Dao.ProduceGd_Save(Dt_Produce)
        End If

        If R.IsOk Then
            LastForm.ReturnId = TB_No.Text
            LastForm.ShowOk(R.Msg, True)
        Else
            LastForm.ShowErrMsg(R.Msg)
        End If
    End Sub

    Protected Sub SetLuoDan()
        Me.Dt_Produce.Rows(0)("State") = BaseClass.Enum_ProduceState.XiaDan
        SaveProduce()
    End Sub


    Protected Sub DoNothing()

    End Sub

    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Cmd_Del_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If mode = Mode_Enum.Modify Then
            LastForm.ShowMsg("确定删除" & Dao.Produce_Gd_Name & "[" & TB_No.Text & "]?", AddressOf DelProduce)
        End If
    End Sub

    Protected Sub DelProduce()
        Dim msg As MsgReturn = Dao.ProduceGd_Del(TB_No.Text)
        If msg.IsOk = False Then
            LastForm.ShowErrMsg(msg.Msg)
        Else

        End If
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
            LastForm.ShowErrMsg("表单单内容有误,无法保存!")
            Exit Function
        End If
        DP_JiaoHuo.Value = DP_JiaoHuo.Value.Date
        DP_KaiDan.Value = DP_KaiDan.Value.Date
        DP_LuoSe.Value = DP_LuoSe.Value.Date
        DP_ShouPei.Value = DP_ShouPei.Value.Date
        Dt_Produce.Rows(0)("BZC_ID") = Val(TB_BZCID.Tag)
        Dt_Produce.Rows(0)("BZ_ID") = Val(TB_BZID.Tag)
        Dt_Produce.Rows(0)("Client_ID") = Val(TB_ClientID.Tag)
        Dt_Produce.Rows(0)("GengDan") = Val(TB_GenDan.Tag)
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

        If Val(TB_BZCID.Tag) = 0 Then
            LastForm.ShowErrMsg("色号不能为空!", AddressOf TB_BZCID.Focus)
            Return False
        End If

        If Val(TB_BZID.Tag) = 0 Then
            LastForm.ShowErrMsg("布种不能为空!", AddressOf TB_BZID.Focus)
            Return False
        End If

        If Val(TB_ClientID.Tag) = 0 Then
            LastForm.ShowErrMsg("客户不能为空!", AddressOf TB_ClientID.Focus)
            Return False
        End If

        If Radio_Num.Checked Then
            If Val(TB_LuoSeBzCount.Text) <= 0 Then
                LastForm.ShowErrMsg("落色条数必须是正整数", AddressOf TB_LuoSeBzCount.Focus)
                Return False
            End If
        Else
            If Val(TB_LuoSeBzZL.Text) <= 0 Then
                LastForm.ShowErrMsg("落色重量必须是正整数", AddressOf TB_LuoSeBzZL.Focus)
                Return False
            End If
        End If

        Return True
    End Function
#End Region


#Region "Form 事件"
#Region "获取新单号"
    Private Sub Label_No_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LB_No.Click
        If mode = Mode_Enum.Add Then
            LastForm.ShowConfirm("是否获取新单号?", AddressOf GetNewID)
        Else
            LastForm.ShowErrMsg("非新增状态不能修改单号!")
        End If
    End Sub

    Sub GetNewID()
        If mode = Mode_Enum.Add Then
            Dim msg As RetrunNewIdMsg = Dao.Produce_GetNewID(DP_KaiDan.Value)
            If msg.IsOk Then
                DP_KaiDan.MinDate = msg.MaxDate.AddDays(1)
                DP_KaiDan.Value = msg.NewIdDate

                TB_No.Text = msg.NewID
                If msg.IsTheDate = False Then
                    LastForm.ShowErrMsg(msg.RetrunMsg)
                End If
            Else
                LastForm.ShowErrMsg(msg.RetrunMsg)
            End If
        End If
    End Sub
    Private Sub DP_Date_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DP_ShouPei.ValueChanged, DP_LuoSe.ValueChanged, DP_KaiDan.ValueChanged, DP_JiaoHuo.ValueChanged
        GetNewID()
    End Sub
#End Region
#Region "双击获取新编号"


    Private Sub TB_No_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TB_No.MouseDoubleClick
        If mode = Mode_Enum.Add Then
            GetNewID()
        End If

    End Sub
#End Region
    Private Sub LB_Remark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LB_Remark.Click
        ShowRemarkList()
    End Sub
    Protected Sub ShowRemarkList()
        Dim f As PClass.BaseForm = LoadFormIDToChild(10202, Me.LastForm)
        If f Is Nothing Then Exit Sub
        f.P_F_RS_ID = TB_Remark.Text
        f.P_F_RS_ID2 = ";"

        Me.ReturnId = ""
        Me.ReturnObj = Nothing
        Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(f, Me.LastForm)
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
        Dim f As PClass.BaseForm = LoadFormIDToChild(10204, Me.LastForm)
        If f Is Nothing Then Exit Sub
        f.P_F_RS_ID = TB_ProcessType.Text
        f.P_F_RS_ID2 = "/"

        Me.ReturnId = ""
        Me.ReturnObj = Nothing
        Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(f, Me.LastForm)
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
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="Bzc_No"></param>
    ''' <param name="Bzc_Name"></param>
    ''' <param name="ID"></param>
    ''' <remarks></remarks>
    Private Sub BzC_List1_Bzc_Sel(ByVal Bzc_No As String, ByVal Bzc_Name As String, ByVal ID As String) Handles Bzc_List1.Col_Sel

        If ID Is Nothing Then
            Exit Sub
        End If
        Bz_List1.SearchID = ID
        TB_BZCID.Tag = ID


        Dim msgBz As DtReturnMsg = Dao.ProduceGd_GetBZListByBzcID(Val(ID))
        If msgBz.IsOk And msgBz.Dt.Rows.Count > 0 Then
            Dim msg As DtReturnMsg = Dao.ProduceGd_GetClientBZC(Val(ID), 0)
            If msg.IsOk And msg.Dt.Rows.Count > 0 Then
                Dim Rs() As DataRow = msgBz.Dt.Select("BZ_ID='" & Val(TB_BZID.Tag) & "'") '先搜索原来已经选择的布种编号
                If Rs.Length > 0 Then
                    TB_BZID.Tag = IsNull(Rs(0)("BZ_ID"), "")
                    TB_BZID.Text = IsNull(Rs(0)("BZ_No"), "")
                    TB_BZName.Text = IsNull(Rs(0)("BZ_Name"), "")
                    TB_BZCClient.Text = IsNull(Rs(0)("Client_Bzc"), "")
                Else '如果没有搜索到 就用默认的布种编号
                    Dim Row As DataRow = msgBz.Dt.Select("Client_Bzc='" & IsNull(msg.Dt.Rows(0)("Client_Bzc"), "") & "'")(0)
                    TB_BZID.Tag = IsNull(Row("BZ_ID"), "")
                    TB_BZID.Text = IsNull(Row("BZ_No"), "")
                    TB_BZName.Text = IsNull(Row("BZ_Name"), "")
                    TB_BZCClient.Text = IsNull(Row("Client_Bzc"), "")
                End If
            Else
                TB_BZCClient.Text = ""
            End If
        Else
            TB_BZID.Text = ""
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
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="BZ_No"></param>
    ''' <param name="Bz_Name"></param>
    ''' <param name="ID"></param>
    ''' <remarks></remarks>
    Private Sub Bz_List1_Bz_Sel(ByVal BZ_No As String, ByVal Bz_Name As String, ByVal ID As String) Handles Bz_List1.Col_Sel
        Dim msg As DtReturnMsg = Dao.ProduceGd_GetClientBZC(TB_BZCID.Tag, ID)
        If msg.IsOk And msg.Dt.Rows.Count > 0 Then
            TB_BZCClient.Text = msg.Dt.Rows(0)("Client_Bzc")
        Else
            TB_BZCClient.Text = ""
        End If
    End Sub



#End Region


#Region "报表事件"

    Private Sub Btn_Preview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Print(OperatorType.Preview)
    End Sub

    Private Sub Btn_Print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Print(OperatorType.Print)
    End Sub

    Protected Sub Print(ByVal DoOperator As OperatorType)
        If Me.mode = Mode_Enum.Add Then
            Exit Sub
        End If
        Dim R As New R30000_ProduceGd
        R.Start(Dt_Produce, DoOperator)
    End Sub

#End Region


    Private Sub Radio_Num_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Radio_ZL.CheckedChanged, Radio_Num.CheckedChanged
        If Radio_Num.Checked Then
            TB_LuoSeBzZL.ReadOnly = True
            If Dt_Produce.Rows.Count > 0 Then Dt_Produce.Rows(0)("CR_LuoSeBzZL") = DBNull.Value
        Else
            TB_LuoSeBzZL.ReadOnly = False
        End If

    End Sub


    Private Sub Cmd_SelectBZ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class
