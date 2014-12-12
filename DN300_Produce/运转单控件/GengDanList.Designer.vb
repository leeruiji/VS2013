<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GengDanList
    Inherits System.Windows.Forms.UserControl

    'UserControl 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GengDanList))
        Me.GB_Header = New System.Windows.Forms.GroupBox
        Me.Radio_ZL = New System.Windows.Forms.RadioButton
        Me.Radio_Num = New System.Windows.Forms.RadioButton
        Me.TB_LuoSeBzZL = New System.Windows.Forms.TextBox
        Me.Label26 = New System.Windows.Forms.Label
        Me.Cmd_ChooseRemark = New System.Windows.Forms.Button
        Me.DP_JiaoHuo = New System.Windows.Forms.DateTimePicker
        Me.DP_LuoSe = New System.Windows.Forms.DateTimePicker
        Me.DP_ShouPei = New System.Windows.Forms.DateTimePicker
        Me.DP_KaiDan = New System.Windows.Forms.DateTimePicker
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.TB_BZCName = New System.Windows.Forms.TextBox
        Me.TB_PB_CountSum = New System.Windows.Forms.TextBox
        Me.Label84 = New System.Windows.Forms.Label
        Me.TB_BZCID = New System.Windows.Forms.TextBox
        Me.Label85 = New System.Windows.Forms.Label
        Me.TB_BZCClient = New System.Windows.Forms.TextBox
        Me.TB_PB_ZLSum = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TB_BZName = New System.Windows.Forms.TextBox
        Me.Label38 = New System.Windows.Forms.Label
        Me.TB_BZID = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TB_ShaPi = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.TB_Remark = New System.Windows.Forms.TextBox
        Me.LB_Remark = New System.Windows.Forms.Label
        Me.TB_Address = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.TB_ProcessType = New System.Windows.Forms.TextBox
        Me.LB_ProcessType = New System.Windows.Forms.Label
        Me.TB_JiaZhong = New System.Windows.Forms.TextBox
        Me.TB_GangCi = New System.Windows.Forms.TextBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.TB_ZhiTong = New System.Windows.Forms.TextBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.TB_GangShu = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.TB_TextileFatory = New System.Windows.Forms.TextBox
        Me.TB_LuoSeBzCount = New System.Windows.Forms.TextBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.TB_Contract = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.TB_ClientName = New System.Windows.Forms.TextBox
        Me.Label39 = New System.Windows.Forms.Label
        Me.TB_ClientID = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GB_ClientRequest = New System.Windows.Forms.GroupBox
        Me.Client_List1 = New BaseClass.Client_List
        Me.CB_SuoShuiJi = New System.Windows.Forms.CheckBox
        Me.CB_PaoGan = New System.Windows.Forms.CheckBox
        Me.CB_ShuangJiaoDai = New System.Windows.Forms.CheckBox
        Me.CB_ShiCa = New System.Windows.Forms.CheckBox
        Me.CB_DanXi = New System.Windows.Forms.CheckBox
        Me.CB_DanMo = New System.Windows.Forms.CheckBox
        Me.CB_KaiDing = New System.Windows.Forms.CheckBox
        Me.CB_ShiMao = New System.Windows.Forms.CheckBox
        Me.CB_KaiZhua = New System.Windows.Forms.CheckBox
        Me.CB_QieBian = New System.Windows.Forms.CheckBox
        Me.CB_GanCa = New System.Windows.Forms.CheckBox
        Me.CB_JiangBian = New System.Windows.Forms.CheckBox
        Me.CB_RiShai = New System.Windows.Forms.CheckBox
        Me.CB_YinHuaYong = New System.Windows.Forms.CheckBox
        Me.CB_ZhuangBaiSe = New System.Windows.Forms.CheckBox
        Me.TB_KeZhong = New System.Windows.Forms.TextBox
        Me.Label36 = New System.Windows.Forms.Label
        Me.TB_HeGang = New System.Windows.Forms.TextBox
        Me.Label37 = New System.Windows.Forms.Label
        Me.TB_DuiGang = New System.Windows.Forms.TextBox
        Me.Label53 = New System.Windows.Forms.Label
        Me.TB_NiuDu = New System.Windows.Forms.TextBox
        Me.TB_BianDuiBian = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.TB_ShiYong = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.TB_ChengXi = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.TB_ZhiSuo = New System.Windows.Forms.TextBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.TB_HengSuo = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.TB_XiLao = New System.Windows.Forms.TextBox
        Me.Label46 = New System.Windows.Forms.Label
        Me.Label51 = New System.Windows.Forms.Label
        Me.GB_Foot = New System.Windows.Forms.GroupBox
        Me.TB_UPD_User = New System.Windows.Forms.TextBox
        Me.Label76 = New System.Windows.Forms.Label
        Me.TB_Auditor = New System.Windows.Forms.TextBox
        Me.Label47 = New System.Windows.Forms.Label
        Me.TB_GenDan = New System.Windows.Forms.TextBox
        Me.Label45 = New System.Windows.Forms.Label
        Me.TB_KaiDan = New System.Windows.Forms.TextBox
        Me.Label44 = New System.Windows.Forms.Label
        Me.LabelTitle = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.LB_State = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.Tool_Top = New System.Windows.Forms.ToolStrip
        Me.Cmd_Modify = New System.Windows.Forms.ToolStripButton
        Me.Cmd_LuoDan = New System.Windows.Forms.ToolStripButton
        Me.Cmd_SelectBZ = New System.Windows.Forms.ToolStripButton
        Me.Cmd_Del = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.Cmd_Preview = New System.Windows.Forms.ToolStripButton
        Me.Cmd_Print = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.Cmd_Exit = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.TB_No = New System.Windows.Forms.TextBox
        Me.LB_No = New System.Windows.Forms.Label
        Me.Employee_List1 = New BaseClass.Employee_List
        Me.Bzc_List1 = New BaseClass.Bzc_List
        Me.Bz_List1 = New BaseClass.Bz_List
        Me.GB_Header.SuspendLayout()
        Me.GB_ClientRequest.SuspendLayout()
        Me.GB_Foot.SuspendLayout()
        Me.Tool_Top.SuspendLayout()
        Me.SuspendLayout()
        '
        'GB_Header
        '
        Me.GB_Header.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GB_Header.Controls.Add(Me.Radio_ZL)
        Me.GB_Header.Controls.Add(Me.Radio_Num)
        Me.GB_Header.Controls.Add(Me.TB_LuoSeBzZL)
        Me.GB_Header.Controls.Add(Me.Label26)
        Me.GB_Header.Controls.Add(Me.Cmd_ChooseRemark)
        Me.GB_Header.Controls.Add(Me.DP_JiaoHuo)
        Me.GB_Header.Controls.Add(Me.DP_LuoSe)
        Me.GB_Header.Controls.Add(Me.DP_ShouPei)
        Me.GB_Header.Controls.Add(Me.DP_KaiDan)
        Me.GB_Header.Controls.Add(Me.Label16)
        Me.GB_Header.Controls.Add(Me.Label4)
        Me.GB_Header.Controls.Add(Me.TB_BZCName)
        Me.GB_Header.Controls.Add(Me.TB_PB_CountSum)
        Me.GB_Header.Controls.Add(Me.Label84)
        Me.GB_Header.Controls.Add(Me.TB_BZCID)
        Me.GB_Header.Controls.Add(Me.Label85)
        Me.GB_Header.Controls.Add(Me.TB_BZCClient)
        Me.GB_Header.Controls.Add(Me.TB_PB_ZLSum)
        Me.GB_Header.Controls.Add(Me.Label3)
        Me.GB_Header.Controls.Add(Me.TB_BZName)
        Me.GB_Header.Controls.Add(Me.Label38)
        Me.GB_Header.Controls.Add(Me.TB_BZID)
        Me.GB_Header.Controls.Add(Me.Label2)
        Me.GB_Header.Controls.Add(Me.TB_ShaPi)
        Me.GB_Header.Controls.Add(Me.Label8)
        Me.GB_Header.Controls.Add(Me.TB_Remark)
        Me.GB_Header.Controls.Add(Me.LB_Remark)
        Me.GB_Header.Controls.Add(Me.TB_Address)
        Me.GB_Header.Controls.Add(Me.Label10)
        Me.GB_Header.Controls.Add(Me.TB_ProcessType)
        Me.GB_Header.Controls.Add(Me.LB_ProcessType)
        Me.GB_Header.Controls.Add(Me.TB_JiaZhong)
        Me.GB_Header.Controls.Add(Me.TB_GangCi)
        Me.GB_Header.Controls.Add(Me.Label24)
        Me.GB_Header.Controls.Add(Me.Label9)
        Me.GB_Header.Controls.Add(Me.TB_ZhiTong)
        Me.GB_Header.Controls.Add(Me.Label20)
        Me.GB_Header.Controls.Add(Me.TB_GangShu)
        Me.GB_Header.Controls.Add(Me.Label7)
        Me.GB_Header.Controls.Add(Me.TB_TextileFatory)
        Me.GB_Header.Controls.Add(Me.TB_LuoSeBzCount)
        Me.GB_Header.Controls.Add(Me.Label23)
        Me.GB_Header.Controls.Add(Me.Label13)
        Me.GB_Header.Controls.Add(Me.Label14)
        Me.GB_Header.Controls.Add(Me.Label6)
        Me.GB_Header.Controls.Add(Me.Label12)
        Me.GB_Header.Controls.Add(Me.TB_Contract)
        Me.GB_Header.Controls.Add(Me.Label11)
        Me.GB_Header.Controls.Add(Me.Label5)
        Me.GB_Header.Controls.Add(Me.TB_ClientName)
        Me.GB_Header.Controls.Add(Me.Label39)
        Me.GB_Header.Controls.Add(Me.TB_ClientID)
        Me.GB_Header.Controls.Add(Me.Label1)
        Me.GB_Header.Location = New System.Drawing.Point(3, 77)
        Me.GB_Header.Name = "GB_Header"
        Me.GB_Header.Size = New System.Drawing.Size(994, 262)
        Me.GB_Header.TabIndex = 2
        Me.GB_Header.TabStop = False
        '
        'Radio_ZL
        '
        Me.Radio_ZL.AutoSize = True
        Me.Radio_ZL.Location = New System.Drawing.Point(180, 200)
        Me.Radio_ZL.Name = "Radio_ZL"
        Me.Radio_ZL.Size = New System.Drawing.Size(83, 16)
        Me.Radio_ZL.TabIndex = 49
        Me.Radio_ZL.Text = "按重量落色"
        Me.Radio_ZL.UseVisualStyleBackColor = True
        '
        'Radio_Num
        '
        Me.Radio_Num.AutoSize = True
        Me.Radio_Num.Checked = True
        Me.Radio_Num.Location = New System.Drawing.Point(179, 168)
        Me.Radio_Num.Name = "Radio_Num"
        Me.Radio_Num.Size = New System.Drawing.Size(83, 16)
        Me.Radio_Num.TabIndex = 48
        Me.Radio_Num.TabStop = True
        Me.Radio_Num.Text = "按条数落色"
        Me.Radio_Num.UseVisualStyleBackColor = True
        '
        'TB_LuoSeBzZL
        '
        Me.TB_LuoSeBzZL.Location = New System.Drawing.Point(88, 198)
        Me.TB_LuoSeBzZL.Name = "TB_LuoSeBzZL"
        Me.TB_LuoSeBzZL.Size = New System.Drawing.Size(82, 21)
        Me.TB_LuoSeBzZL.TabIndex = 46
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(12, 202)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(59, 12)
        Me.Label26.TabIndex = 47
        Me.Label26.Text = "落色重量:"
        '
        'Cmd_ChooseRemark
        '
        Me.Cmd_ChooseRemark.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Cmd_ChooseRemark.Location = New System.Drawing.Point(419, 132)
        Me.Cmd_ChooseRemark.Name = "Cmd_ChooseRemark"
        Me.Cmd_ChooseRemark.Size = New System.Drawing.Size(29, 23)
        Me.Cmd_ChooseRemark.TabIndex = 45
        Me.Cmd_ChooseRemark.Text = "+"
        Me.Cmd_ChooseRemark.UseVisualStyleBackColor = True
        '
        'DP_JiaoHuo
        '
        Me.DP_JiaoHuo.Location = New System.Drawing.Point(875, 76)
        Me.DP_JiaoHuo.Name = "DP_JiaoHuo"
        Me.DP_JiaoHuo.Size = New System.Drawing.Size(122, 21)
        Me.DP_JiaoHuo.TabIndex = 10
        '
        'DP_LuoSe
        '
        Me.DP_LuoSe.Location = New System.Drawing.Point(875, 15)
        Me.DP_LuoSe.Name = "DP_LuoSe"
        Me.DP_LuoSe.Size = New System.Drawing.Size(122, 21)
        Me.DP_LuoSe.TabIndex = 10
        '
        'DP_ShouPei
        '
        Me.DP_ShouPei.Location = New System.Drawing.Point(662, 47)
        Me.DP_ShouPei.Name = "DP_ShouPei"
        Me.DP_ShouPei.Size = New System.Drawing.Size(122, 21)
        Me.DP_ShouPei.TabIndex = 10
        '
        'DP_KaiDan
        '
        Me.DP_KaiDan.Location = New System.Drawing.Point(875, 46)
        Me.DP_KaiDan.Name = "DP_KaiDan"
        Me.DP_KaiDan.Size = New System.Drawing.Size(122, 21)
        Me.DP_KaiDan.TabIndex = 10
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(33, 50)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(41, 12)
        Me.Label16.TabIndex = 20
        Me.Label16.Text = "颜 色:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(33, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 12)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "色 号:"
        '
        'TB_BZCName
        '
        Me.TB_BZCName.Location = New System.Drawing.Point(88, 47)
        Me.TB_BZCName.Name = "TB_BZCName"
        Me.TB_BZCName.ReadOnly = True
        Me.TB_BZCName.Size = New System.Drawing.Size(82, 21)
        Me.TB_BZCName.TabIndex = 14
        '
        'TB_PB_CountSum
        '
        Me.TB_PB_CountSum.Location = New System.Drawing.Point(351, 166)
        Me.TB_PB_CountSum.Name = "TB_PB_CountSum"
        Me.TB_PB_CountSum.ReadOnly = True
        Me.TB_PB_CountSum.Size = New System.Drawing.Size(96, 21)
        Me.TB_PB_CountSum.TabIndex = 42
        '
        'Label84
        '
        Me.Label84.AutoSize = True
        Me.Label84.Location = New System.Drawing.Point(275, 170)
        Me.Label84.Name = "Label84"
        Me.Label84.Size = New System.Drawing.Size(59, 12)
        Me.Label84.TabIndex = 37
        Me.Label84.Text = "已配条数:"
        '
        'TB_BZCID
        '
        Me.TB_BZCID.Location = New System.Drawing.Point(88, 16)
        Me.TB_BZCID.Name = "TB_BZCID"
        Me.TB_BZCID.Size = New System.Drawing.Size(82, 21)
        Me.TB_BZCID.TabIndex = 0
        '
        'Label85
        '
        Me.Label85.AutoSize = True
        Me.Label85.Location = New System.Drawing.Point(275, 202)
        Me.Label85.Name = "Label85"
        Me.Label85.Size = New System.Drawing.Size(59, 12)
        Me.Label85.TabIndex = 34
        Me.Label85.Text = "已配重量:"
        '
        'TB_BZCClient
        '
        Me.TB_BZCClient.Location = New System.Drawing.Point(245, 46)
        Me.TB_BZCClient.Name = "TB_BZCClient"
        Me.TB_BZCClient.ReadOnly = True
        Me.TB_BZCClient.Size = New System.Drawing.Size(126, 21)
        Me.TB_BZCClient.TabIndex = 15
        '
        'TB_PB_ZLSum
        '
        Me.TB_PB_ZLSum.Location = New System.Drawing.Point(352, 198)
        Me.TB_PB_ZLSum.Name = "TB_PB_ZLSum"
        Me.TB_PB_ZLSum.ReadOnly = True
        Me.TB_PB_ZLSum.Size = New System.Drawing.Size(95, 21)
        Me.TB_PB_ZLSum.TabIndex = 40
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(176, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 12)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "客户色号:"
        '
        'TB_BZName
        '
        Me.TB_BZName.Location = New System.Drawing.Point(245, 76)
        Me.TB_BZName.Name = "TB_BZName"
        Me.TB_BZName.ReadOnly = True
        Me.TB_BZName.Size = New System.Drawing.Size(125, 21)
        Me.TB_BZName.TabIndex = 16
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Location = New System.Drawing.Point(176, 80)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(59, 12)
        Me.Label38.TabIndex = 12
        Me.Label38.Text = "布种名称:"
        '
        'TB_BZID
        '
        Me.TB_BZID.Location = New System.Drawing.Point(88, 76)
        Me.TB_BZID.Name = "TB_BZID"
        Me.TB_BZID.Size = New System.Drawing.Size(82, 21)
        Me.TB_BZID.TabIndex = 13
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 78)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 12)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "布种编号:"
        '
        'TB_ShaPi
        '
        Me.TB_ShaPi.Location = New System.Drawing.Point(662, 16)
        Me.TB_ShaPi.Name = "TB_ShaPi"
        Me.TB_ShaPi.Size = New System.Drawing.Size(122, 21)
        Me.TB_ShaPi.TabIndex = 3
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(607, 20)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(41, 12)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "纱 批:"
        '
        'TB_Remark
        '
        Me.TB_Remark.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TB_Remark.Location = New System.Drawing.Point(454, 107)
        Me.TB_Remark.Multiline = True
        Me.TB_Remark.Name = "TB_Remark"
        Me.TB_Remark.Size = New System.Drawing.Size(528, 147)
        Me.TB_Remark.TabIndex = 8
        '
        'LB_Remark
        '
        Me.LB_Remark.AutoSize = True
        Me.LB_Remark.ForeColor = System.Drawing.Color.Blue
        Me.LB_Remark.Location = New System.Drawing.Point(398, 115)
        Me.LB_Remark.Name = "LB_Remark"
        Me.LB_Remark.Size = New System.Drawing.Size(41, 12)
        Me.LB_Remark.TabIndex = 22
        Me.LB_Remark.Text = "备 注:"
        '
        'TB_Address
        '
        Me.TB_Address.Location = New System.Drawing.Point(88, 136)
        Me.TB_Address.Name = "TB_Address"
        Me.TB_Address.Size = New System.Drawing.Size(282, 21)
        Me.TB_Address.TabIndex = 7
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(12, 136)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(59, 12)
        Me.Label10.TabIndex = 20
        Me.Label10.Text = "送货地址:"
        '
        'TB_ProcessType
        '
        Me.TB_ProcessType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TB_ProcessType.Location = New System.Drawing.Point(88, 230)
        Me.TB_ProcessType.Name = "TB_ProcessType"
        Me.TB_ProcessType.Size = New System.Drawing.Size(359, 21)
        Me.TB_ProcessType.TabIndex = 5
        '
        'LB_ProcessType
        '
        Me.LB_ProcessType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LB_ProcessType.AutoSize = True
        Me.LB_ProcessType.ForeColor = System.Drawing.Color.Blue
        Me.LB_ProcessType.Location = New System.Drawing.Point(10, 233)
        Me.LB_ProcessType.Name = "LB_ProcessType"
        Me.LB_ProcessType.Size = New System.Drawing.Size(59, 12)
        Me.LB_ProcessType.TabIndex = 19
        Me.LB_ProcessType.Text = "加工类别:"
        '
        'TB_JiaZhong
        '
        Me.TB_JiaZhong.Location = New System.Drawing.Point(543, 77)
        Me.TB_JiaZhong.Name = "TB_JiaZhong"
        Me.TB_JiaZhong.Size = New System.Drawing.Size(39, 21)
        Me.TB_JiaZhong.TabIndex = 6
        '
        'TB_GangCi
        '
        Me.TB_GangCi.Location = New System.Drawing.Point(543, 47)
        Me.TB_GangCi.Name = "TB_GangCi"
        Me.TB_GangCi.Size = New System.Drawing.Size(39, 21)
        Me.TB_GangCi.TabIndex = 6
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(499, 80)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(35, 12)
        Me.Label24.TabIndex = 17
        Me.Label24.Text = "加重:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(499, 50)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(35, 12)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "缸次:"
        '
        'TB_ZhiTong
        '
        Me.TB_ZhiTong.Location = New System.Drawing.Point(454, 76)
        Me.TB_ZhiTong.Name = "TB_ZhiTong"
        Me.TB_ZhiTong.Size = New System.Drawing.Size(39, 21)
        Me.TB_ZhiTong.TabIndex = 4
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(405, 80)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(35, 12)
        Me.Label20.TabIndex = 18
        Me.Label20.Text = "纸筒:"
        '
        'TB_GangShu
        '
        Me.TB_GangShu.Location = New System.Drawing.Point(454, 46)
        Me.TB_GangShu.Name = "TB_GangShu"
        Me.TB_GangShu.Size = New System.Drawing.Size(39, 21)
        Me.TB_GangShu.TabIndex = 4
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(391, 50)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(47, 12)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "总缸数:"
        '
        'TB_TextileFatory
        '
        Me.TB_TextileFatory.Location = New System.Drawing.Point(454, 16)
        Me.TB_TextileFatory.Name = "TB_TextileFatory"
        Me.TB_TextileFatory.Size = New System.Drawing.Size(128, 21)
        Me.TB_TextileFatory.TabIndex = 2
        '
        'TB_LuoSeBzCount
        '
        Me.TB_LuoSeBzCount.Location = New System.Drawing.Point(88, 166)
        Me.TB_LuoSeBzCount.Name = "TB_LuoSeBzCount"
        Me.TB_LuoSeBzCount.Size = New System.Drawing.Size(82, 21)
        Me.TB_LuoSeBzCount.TabIndex = 2
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(12, 170)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(59, 12)
        Me.Label23.TabIndex = 38
        Me.Label23.Text = "落色条数:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(799, 50)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(59, 12)
        Me.Label13.TabIndex = 21
        Me.Label13.Text = "开单日期:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(799, 83)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(59, 12)
        Me.Label14.TabIndex = 16
        Me.Label14.Text = "交货日期:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(399, 20)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(41, 12)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "织 厂:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(586, 52)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(59, 12)
        Me.Label12.TabIndex = 25
        Me.Label12.Text = "收胚日期:"
        '
        'TB_Contract
        '
        Me.TB_Contract.Location = New System.Drawing.Point(245, 16)
        Me.TB_Contract.Name = "TB_Contract"
        Me.TB_Contract.Size = New System.Drawing.Size(126, 21)
        Me.TB_Contract.TabIndex = 1
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(799, 19)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(59, 12)
        Me.Label11.TabIndex = 26
        Me.Label11.Text = "落色日期:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(197, 20)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 12)
        Me.Label5.TabIndex = 22
        Me.Label5.Text = "合 同:"
        '
        'TB_ClientName
        '
        Me.TB_ClientName.Location = New System.Drawing.Point(245, 106)
        Me.TB_ClientName.Name = "TB_ClientName"
        Me.TB_ClientName.ReadOnly = True
        Me.TB_ClientName.Size = New System.Drawing.Size(125, 21)
        Me.TB_ClientName.TabIndex = 17
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Location = New System.Drawing.Point(176, 109)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(59, 12)
        Me.Label39.TabIndex = 23
        Me.Label39.Text = "客户名称:"
        '
        'TB_ClientID
        '
        Me.TB_ClientID.Location = New System.Drawing.Point(88, 106)
        Me.TB_ClientID.Name = "TB_ClientID"
        Me.TB_ClientID.ReadOnly = True
        Me.TB_ClientID.Size = New System.Drawing.Size(82, 21)
        Me.TB_ClientID.TabIndex = 14
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 107)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 12)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "客户编号:"
        '
        'GB_ClientRequest
        '
        Me.GB_ClientRequest.Controls.Add(Me.Client_List1)
        Me.GB_ClientRequest.Controls.Add(Me.CB_SuoShuiJi)
        Me.GB_ClientRequest.Controls.Add(Me.CB_PaoGan)
        Me.GB_ClientRequest.Controls.Add(Me.CB_ShuangJiaoDai)
        Me.GB_ClientRequest.Controls.Add(Me.CB_ShiCa)
        Me.GB_ClientRequest.Controls.Add(Me.CB_DanXi)
        Me.GB_ClientRequest.Controls.Add(Me.CB_DanMo)
        Me.GB_ClientRequest.Controls.Add(Me.CB_KaiDing)
        Me.GB_ClientRequest.Controls.Add(Me.CB_ShiMao)
        Me.GB_ClientRequest.Controls.Add(Me.CB_KaiZhua)
        Me.GB_ClientRequest.Controls.Add(Me.CB_QieBian)
        Me.GB_ClientRequest.Controls.Add(Me.CB_GanCa)
        Me.GB_ClientRequest.Controls.Add(Me.CB_JiangBian)
        Me.GB_ClientRequest.Controls.Add(Me.CB_RiShai)
        Me.GB_ClientRequest.Controls.Add(Me.CB_YinHuaYong)
        Me.GB_ClientRequest.Controls.Add(Me.CB_ZhuangBaiSe)
        Me.GB_ClientRequest.Controls.Add(Me.TB_KeZhong)
        Me.GB_ClientRequest.Controls.Add(Me.Label36)
        Me.GB_ClientRequest.Controls.Add(Me.TB_HeGang)
        Me.GB_ClientRequest.Controls.Add(Me.Label37)
        Me.GB_ClientRequest.Controls.Add(Me.TB_DuiGang)
        Me.GB_ClientRequest.Controls.Add(Me.Label53)
        Me.GB_ClientRequest.Controls.Add(Me.TB_NiuDu)
        Me.GB_ClientRequest.Controls.Add(Me.TB_BianDuiBian)
        Me.GB_ClientRequest.Controls.Add(Me.Label19)
        Me.GB_ClientRequest.Controls.Add(Me.TB_ShiYong)
        Me.GB_ClientRequest.Controls.Add(Me.Label18)
        Me.GB_ClientRequest.Controls.Add(Me.TB_ChengXi)
        Me.GB_ClientRequest.Controls.Add(Me.Label17)
        Me.GB_ClientRequest.Controls.Add(Me.TB_ZhiSuo)
        Me.GB_ClientRequest.Controls.Add(Me.Label22)
        Me.GB_ClientRequest.Controls.Add(Me.TB_HengSuo)
        Me.GB_ClientRequest.Controls.Add(Me.Label21)
        Me.GB_ClientRequest.Controls.Add(Me.TB_XiLao)
        Me.GB_ClientRequest.Controls.Add(Me.Label46)
        Me.GB_ClientRequest.Controls.Add(Me.Label51)
        Me.GB_ClientRequest.Location = New System.Drawing.Point(3, 345)
        Me.GB_ClientRequest.Name = "GB_ClientRequest"
        Me.GB_ClientRequest.Size = New System.Drawing.Size(1009, 122)
        Me.GB_ClientRequest.TabIndex = 4
        Me.GB_ClientRequest.TabStop = False
        Me.GB_ClientRequest.Text = "客户要求"
        '
        'Client_List1
        '
        Me.Client_List1.BackColor = System.Drawing.Color.DodgerBlue
        Me.Client_List1.IsTBLostFocusSelOne = True
        Me.Client_List1.Location = New System.Drawing.Point(-1120, 10)
        Me.Client_List1.Name = "Client_List1"
        Me.Client_List1.Size = New System.Drawing.Size(250, 210)
        Me.Client_List1.TabIndex = 67
        '
        'CB_SuoShuiJi
        '
        Me.CB_SuoShuiJi.AutoSize = True
        Me.CB_SuoShuiJi.Location = New System.Drawing.Point(73, 46)
        Me.CB_SuoShuiJi.Name = "CB_SuoShuiJi"
        Me.CB_SuoShuiJi.Size = New System.Drawing.Size(60, 16)
        Me.CB_SuoShuiJi.TabIndex = 58
        Me.CB_SuoShuiJi.Text = "缩水机"
        Me.CB_SuoShuiJi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CB_SuoShuiJi.UseVisualStyleBackColor = True
        '
        'CB_PaoGan
        '
        Me.CB_PaoGan.AutoSize = True
        Me.CB_PaoGan.Location = New System.Drawing.Point(6, 46)
        Me.CB_PaoGan.Name = "CB_PaoGan"
        Me.CB_PaoGan.Size = New System.Drawing.Size(54, 16)
        Me.CB_PaoGan.TabIndex = 52
        Me.CB_PaoGan.Text = "抛 干"
        Me.CB_PaoGan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CB_PaoGan.UseVisualStyleBackColor = True
        '
        'CB_ShuangJiaoDai
        '
        Me.CB_ShuangJiaoDai.AutoSize = True
        Me.CB_ShuangJiaoDai.Location = New System.Drawing.Point(900, 22)
        Me.CB_ShuangJiaoDai.Name = "CB_ShuangJiaoDai"
        Me.CB_ShuangJiaoDai.Size = New System.Drawing.Size(60, 16)
        Me.CB_ShuangJiaoDai.TabIndex = 54
        Me.CB_ShuangJiaoDai.Text = "双胶袋"
        Me.CB_ShuangJiaoDai.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CB_ShuangJiaoDai.UseVisualStyleBackColor = True
        '
        'CB_ShiCa
        '
        Me.CB_ShiCa.AutoSize = True
        Me.CB_ShiCa.Location = New System.Drawing.Point(281, 22)
        Me.CB_ShiCa.Name = "CB_ShiCa"
        Me.CB_ShiCa.Size = New System.Drawing.Size(54, 16)
        Me.CB_ShiCa.TabIndex = 53
        Me.CB_ShiCa.Text = "湿 擦"
        Me.CB_ShiCa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CB_ShiCa.UseVisualStyleBackColor = True
        '
        'CB_DanXi
        '
        Me.CB_DanXi.AutoSize = True
        Me.CB_DanXi.Location = New System.Drawing.Point(819, 22)
        Me.CB_DanXi.Name = "CB_DanXi"
        Me.CB_DanXi.Size = New System.Drawing.Size(72, 16)
        Me.CB_DanXi.TabIndex = 64
        Me.CB_DanXi.Text = "单面吸毛"
        Me.CB_DanXi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CB_DanXi.UseVisualStyleBackColor = True
        '
        'CB_DanMo
        '
        Me.CB_DanMo.AutoSize = True
        Me.CB_DanMo.Location = New System.Drawing.Point(734, 22)
        Me.CB_DanMo.Name = "CB_DanMo"
        Me.CB_DanMo.Size = New System.Drawing.Size(72, 16)
        Me.CB_DanMo.TabIndex = 63
        Me.CB_DanMo.Text = "单面磨毛"
        Me.CB_DanMo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CB_DanMo.UseVisualStyleBackColor = True
        '
        'CB_KaiDing
        '
        Me.CB_KaiDing.AutoSize = True
        Me.CB_KaiDing.Location = New System.Drawing.Point(422, 22)
        Me.CB_KaiDing.Name = "CB_KaiDing"
        Me.CB_KaiDing.Size = New System.Drawing.Size(72, 16)
        Me.CB_KaiDing.TabIndex = 66
        Me.CB_KaiDing.Text = "开边定型"
        Me.CB_KaiDing.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CB_KaiDing.UseVisualStyleBackColor = True
        '
        'CB_ShiMao
        '
        Me.CB_ShiMao.AutoSize = True
        Me.CB_ShiMao.Location = New System.Drawing.Point(355, 22)
        Me.CB_ShiMao.Name = "CB_ShiMao"
        Me.CB_ShiMao.Size = New System.Drawing.Size(54, 16)
        Me.CB_ShiMao.TabIndex = 65
        Me.CB_ShiMao.Text = "食 毛"
        Me.CB_ShiMao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CB_ShiMao.UseVisualStyleBackColor = True
        '
        'CB_KaiZhua
        '
        Me.CB_KaiZhua.AutoSize = True
        Me.CB_KaiZhua.Location = New System.Drawing.Point(648, 22)
        Me.CB_KaiZhua.Name = "CB_KaiZhua"
        Me.CB_KaiZhua.Size = New System.Drawing.Size(72, 16)
        Me.CB_KaiZhua.TabIndex = 59
        Me.CB_KaiZhua.Text = "开边抓毛"
        Me.CB_KaiZhua.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CB_KaiZhua.UseVisualStyleBackColor = True
        '
        'CB_QieBian
        '
        Me.CB_QieBian.AutoSize = True
        Me.CB_QieBian.Location = New System.Drawing.Point(581, 22)
        Me.CB_QieBian.Name = "CB_QieBian"
        Me.CB_QieBian.Size = New System.Drawing.Size(54, 16)
        Me.CB_QieBian.TabIndex = 61
        Me.CB_QieBian.Text = "切 边"
        Me.CB_QieBian.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CB_QieBian.UseVisualStyleBackColor = True
        '
        'CB_GanCa
        '
        Me.CB_GanCa.AutoSize = True
        Me.CB_GanCa.Location = New System.Drawing.Point(214, 22)
        Me.CB_GanCa.Name = "CB_GanCa"
        Me.CB_GanCa.Size = New System.Drawing.Size(54, 16)
        Me.CB_GanCa.TabIndex = 46
        Me.CB_GanCa.Text = "干 擦"
        Me.CB_GanCa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CB_GanCa.UseVisualStyleBackColor = True
        '
        'CB_JiangBian
        '
        Me.CB_JiangBian.AutoSize = True
        Me.CB_JiangBian.Location = New System.Drawing.Point(514, 22)
        Me.CB_JiangBian.Name = "CB_JiangBian"
        Me.CB_JiangBian.Size = New System.Drawing.Size(54, 16)
        Me.CB_JiangBian.TabIndex = 45
        Me.CB_JiangBian.Text = "浆 边"
        Me.CB_JiangBian.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CB_JiangBian.UseVisualStyleBackColor = True
        '
        'CB_RiShai
        '
        Me.CB_RiShai.AutoSize = True
        Me.CB_RiShai.Location = New System.Drawing.Point(147, 22)
        Me.CB_RiShai.Name = "CB_RiShai"
        Me.CB_RiShai.Size = New System.Drawing.Size(54, 16)
        Me.CB_RiShai.TabIndex = 44
        Me.CB_RiShai.Text = "日 晒"
        Me.CB_RiShai.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CB_RiShai.UseVisualStyleBackColor = True
        '
        'CB_YinHuaYong
        '
        Me.CB_YinHuaYong.AutoSize = True
        Me.CB_YinHuaYong.Location = New System.Drawing.Point(73, 22)
        Me.CB_YinHuaYong.Name = "CB_YinHuaYong"
        Me.CB_YinHuaYong.Size = New System.Drawing.Size(60, 16)
        Me.CB_YinHuaYong.TabIndex = 50
        Me.CB_YinHuaYong.Text = "印花用"
        Me.CB_YinHuaYong.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CB_YinHuaYong.UseVisualStyleBackColor = True
        '
        'CB_ZhuangBaiSe
        '
        Me.CB_ZhuangBaiSe.AutoSize = True
        Me.CB_ZhuangBaiSe.Location = New System.Drawing.Point(6, 22)
        Me.CB_ZhuangBaiSe.Name = "CB_ZhuangBaiSe"
        Me.CB_ZhuangBaiSe.Size = New System.Drawing.Size(60, 16)
        Me.CB_ZhuangBaiSe.TabIndex = 49
        Me.CB_ZhuangBaiSe.Text = "撞白色"
        Me.CB_ZhuangBaiSe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CB_ZhuangBaiSe.UseVisualStyleBackColor = True
        '
        'TB_KeZhong
        '
        Me.TB_KeZhong.Location = New System.Drawing.Point(743, 46)
        Me.TB_KeZhong.Name = "TB_KeZhong"
        Me.TB_KeZhong.Size = New System.Drawing.Size(70, 21)
        Me.TB_KeZhong.TabIndex = 1
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(688, 53)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(41, 12)
        Me.Label36.TabIndex = 34
        Me.Label36.Text = "克 重:"
        '
        'TB_HeGang
        '
        Me.TB_HeGang.Location = New System.Drawing.Point(895, 78)
        Me.TB_HeGang.Name = "TB_HeGang"
        Me.TB_HeGang.Size = New System.Drawing.Size(70, 21)
        Me.TB_HeGang.TabIndex = 4
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(819, 87)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(59, 12)
        Me.Label37.TabIndex = 36
        Me.Label37.Text = "合染缸号:"
        '
        'TB_DuiGang
        '
        Me.TB_DuiGang.Location = New System.Drawing.Point(743, 78)
        Me.TB_DuiGang.Name = "TB_DuiGang"
        Me.TB_DuiGang.Size = New System.Drawing.Size(70, 21)
        Me.TB_DuiGang.TabIndex = 3
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.Location = New System.Drawing.Point(667, 81)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(59, 12)
        Me.Label53.TabIndex = 35
        Me.Label53.Text = "对色缸号:"
        '
        'TB_NiuDu
        '
        Me.TB_NiuDu.Location = New System.Drawing.Point(583, 44)
        Me.TB_NiuDu.Name = "TB_NiuDu"
        Me.TB_NiuDu.Size = New System.Drawing.Size(70, 21)
        Me.TB_NiuDu.TabIndex = 0
        '
        'TB_BianDuiBian
        '
        Me.TB_BianDuiBian.Location = New System.Drawing.Point(895, 43)
        Me.TB_BianDuiBian.Name = "TB_BianDuiBian"
        Me.TB_BianDuiBian.Size = New System.Drawing.Size(70, 21)
        Me.TB_BianDuiBian.TabIndex = 2
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(833, 46)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(47, 12)
        Me.Label19.TabIndex = 38
        Me.Label19.Text = "边对边:"
        '
        'TB_ShiYong
        '
        Me.TB_ShiYong.Location = New System.Drawing.Point(583, 78)
        Me.TB_ShiYong.Name = "TB_ShiYong"
        Me.TB_ShiYong.Size = New System.Drawing.Size(70, 21)
        Me.TB_ShiYong.TabIndex = 2
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(533, 81)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(35, 12)
        Me.Label18.TabIndex = 38
        Me.Label18.Text = "实用:"
        '
        'TB_ChengXi
        '
        Me.TB_ChengXi.Location = New System.Drawing.Point(437, 78)
        Me.TB_ChengXi.Name = "TB_ChengXi"
        Me.TB_ChengXi.Size = New System.Drawing.Size(70, 21)
        Me.TB_ChengXi.TabIndex = 2
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(361, 81)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(59, 12)
        Me.Label17.TabIndex = 38
        Me.Label17.Text = "成衣洗水:"
        '
        'TB_ZhiSuo
        '
        Me.TB_ZhiSuo.Location = New System.Drawing.Point(437, 46)
        Me.TB_ZhiSuo.Name = "TB_ZhiSuo"
        Me.TB_ZhiSuo.Size = New System.Drawing.Size(70, 21)
        Me.TB_ZhiSuo.TabIndex = 2
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(389, 49)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(35, 12)
        Me.Label22.TabIndex = 38
        Me.Label22.Text = "直缩:"
        '
        'TB_HengSuo
        '
        Me.TB_HengSuo.Location = New System.Drawing.Point(275, 46)
        Me.TB_HengSuo.Name = "TB_HengSuo"
        Me.TB_HengSuo.Size = New System.Drawing.Size(70, 21)
        Me.TB_HengSuo.TabIndex = 2
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(227, 47)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(35, 12)
        Me.Label21.TabIndex = 38
        Me.Label21.Text = "横缩:"
        '
        'TB_XiLao
        '
        Me.TB_XiLao.Location = New System.Drawing.Point(275, 78)
        Me.TB_XiLao.Name = "TB_XiLao"
        Me.TB_XiLao.Size = New System.Drawing.Size(70, 21)
        Me.TB_XiLao.TabIndex = 2
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.Location = New System.Drawing.Point(199, 81)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(59, 12)
        Me.Label46.TabIndex = 38
        Me.Label46.Text = "洗水牢度:"
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.Location = New System.Drawing.Point(528, 46)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(41, 12)
        Me.Label51.TabIndex = 37
        Me.Label51.Text = "扭 度:"
        '
        'GB_Foot
        '
        Me.GB_Foot.Controls.Add(Me.TB_UPD_User)
        Me.GB_Foot.Controls.Add(Me.Label76)
        Me.GB_Foot.Controls.Add(Me.TB_Auditor)
        Me.GB_Foot.Controls.Add(Me.Label47)
        Me.GB_Foot.Controls.Add(Me.TB_GenDan)
        Me.GB_Foot.Controls.Add(Me.Label45)
        Me.GB_Foot.Controls.Add(Me.TB_KaiDan)
        Me.GB_Foot.Controls.Add(Me.Label44)
        Me.GB_Foot.Location = New System.Drawing.Point(3, 473)
        Me.GB_Foot.Name = "GB_Foot"
        Me.GB_Foot.Size = New System.Drawing.Size(1009, 47)
        Me.GB_Foot.TabIndex = 47
        Me.GB_Foot.TabStop = False
        '
        'TB_UPD_User
        '
        Me.TB_UPD_User.Location = New System.Drawing.Point(806, 17)
        Me.TB_UPD_User.Name = "TB_UPD_User"
        Me.TB_UPD_User.ReadOnly = True
        Me.TB_UPD_User.Size = New System.Drawing.Size(84, 21)
        Me.TB_UPD_User.TabIndex = 41
        '
        'Label76
        '
        Me.Label76.AutoSize = True
        Me.Label76.Location = New System.Drawing.Point(744, 21)
        Me.Label76.Name = "Label76"
        Me.Label76.Size = New System.Drawing.Size(47, 12)
        Me.Label76.TabIndex = 40
        Me.Label76.Text = "更新人:"
        '
        'TB_Auditor
        '
        Me.TB_Auditor.Location = New System.Drawing.Point(641, 17)
        Me.TB_Auditor.Name = "TB_Auditor"
        Me.TB_Auditor.ReadOnly = True
        Me.TB_Auditor.Size = New System.Drawing.Size(84, 21)
        Me.TB_Auditor.TabIndex = 2
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.Location = New System.Drawing.Point(579, 21)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(47, 12)
        Me.Label47.TabIndex = 40
        Me.Label47.Text = "审核人:"
        '
        'TB_GenDan
        '
        Me.TB_GenDan.Location = New System.Drawing.Point(460, 17)
        Me.TB_GenDan.Name = "TB_GenDan"
        Me.TB_GenDan.Size = New System.Drawing.Size(84, 21)
        Me.TB_GenDan.TabIndex = 1
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Location = New System.Drawing.Point(398, 21)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(47, 12)
        Me.Label45.TabIndex = 40
        Me.Label45.Text = "跟单员:"
        '
        'TB_KaiDan
        '
        Me.TB_KaiDan.Location = New System.Drawing.Point(261, 17)
        Me.TB_KaiDan.Name = "TB_KaiDan"
        Me.TB_KaiDan.ReadOnly = True
        Me.TB_KaiDan.Size = New System.Drawing.Size(84, 21)
        Me.TB_KaiDan.TabIndex = 0
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Location = New System.Drawing.Point(202, 21)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(47, 12)
        Me.Label44.TabIndex = 40
        Me.Label44.Text = "开单员:"
        '
        'LabelTitle
        '
        Me.LabelTitle.AutoSize = True
        Me.LabelTitle.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LabelTitle.ForeColor = System.Drawing.Color.Blue
        Me.LabelTitle.Location = New System.Drawing.Point(28, 45)
        Me.LabelTitle.Name = "LabelTitle"
        Me.LabelTitle.Size = New System.Drawing.Size(59, 16)
        Me.LabelTitle.TabIndex = 63
        Me.LabelTitle.Text = "运转单"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label15.Location = New System.Drawing.Point(162, 45)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(56, 16)
        Me.Label15.TabIndex = 61
        Me.Label15.Text = "状 态:"
        '
        'LB_State
        '
        Me.LB_State.AutoSize = True
        Me.LB_State.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LB_State.Location = New System.Drawing.Point(236, 45)
        Me.LB_State.Name = "LB_State"
        Me.LB_State.Size = New System.Drawing.Size(0, 16)
        Me.LB_State.TabIndex = 60
        '
        'Label25
        '
        Me.Label25.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label25.BackColor = System.Drawing.Color.Blue
        Me.Label25.Location = New System.Drawing.Point(6, 74)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(1031, 3)
        Me.Label25.TabIndex = 62
        '
        'Tool_Top
        '
        Me.Tool_Top.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.Tool_Top.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Cmd_Modify, Me.Cmd_LuoDan, Me.Cmd_SelectBZ, Me.Cmd_Del, Me.ToolStripSeparator5, Me.Cmd_Preview, Me.Cmd_Print, Me.ToolStripSeparator1, Me.Cmd_Exit, Me.ToolStripSeparator2})
        Me.Tool_Top.Location = New System.Drawing.Point(0, 0)
        Me.Tool_Top.MinimumSize = New System.Drawing.Size(0, 40)
        Me.Tool_Top.Name = "Tool_Top"
        Me.Tool_Top.Size = New System.Drawing.Size(1020, 40)
        Me.Tool_Top.TabIndex = 64
        Me.Tool_Top.Text = "ToolStrip2"
        '
        'Cmd_Modify
        '
        Me.Cmd_Modify.AccessibleDescription = "修改按钮"
        Me.Cmd_Modify.AccessibleName = ""
        Me.Cmd_Modify.Image = CType(resources.GetObject("Cmd_Modify.Image"), System.Drawing.Image)
        Me.Cmd_Modify.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Modify.Name = "Cmd_Modify"
        Me.Cmd_Modify.Size = New System.Drawing.Size(57, 37)
        Me.Cmd_Modify.Text = "保存"
        '
        'Cmd_LuoDan
        '
        Me.Cmd_LuoDan.Image = Global.DN300_Produce.My.Resources.Resources.Produce
        Me.Cmd_LuoDan.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_LuoDan.Name = "Cmd_LuoDan"
        Me.Cmd_LuoDan.Size = New System.Drawing.Size(81, 37)
        Me.Cmd_LuoDan.Text = "确认下单"
        '
        'Cmd_SelectBZ
        '
        Me.Cmd_SelectBZ.Image = Global.DN300_Produce.My.Resources.Resources.Image_89000
        Me.Cmd_SelectBZ.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_SelectBZ.Name = "Cmd_SelectBZ"
        Me.Cmd_SelectBZ.Size = New System.Drawing.Size(57, 37)
        Me.Cmd_SelectBZ.Text = "配布"
        '
        'Cmd_Del
        '
        Me.Cmd_Del.AccessibleDescription = "修改按钮"
        Me.Cmd_Del.AccessibleName = ""
        Me.Cmd_Del.Image = CType(resources.GetObject("Cmd_Del.Image"), System.Drawing.Image)
        Me.Cmd_Del.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Del.Name = "Cmd_Del"
        Me.Cmd_Del.Size = New System.Drawing.Size(57, 37)
        Me.Cmd_Del.Text = "删除"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 40)
        '
        'Cmd_Preview
        '
        Me.Cmd_Preview.Image = CType(resources.GetObject("Cmd_Preview.Image"), System.Drawing.Image)
        Me.Cmd_Preview.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Preview.Name = "Cmd_Preview"
        Me.Cmd_Preview.Size = New System.Drawing.Size(57, 37)
        Me.Cmd_Preview.Text = "预览"
        '
        'Cmd_Print
        '
        Me.Cmd_Print.Image = CType(resources.GetObject("Cmd_Print.Image"), System.Drawing.Image)
        Me.Cmd_Print.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Print.Name = "Cmd_Print"
        Me.Cmd_Print.Size = New System.Drawing.Size(57, 37)
        Me.Cmd_Print.Text = "打印"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 40)
        '
        'Cmd_Exit
        '
        Me.Cmd_Exit.Image = CType(resources.GetObject("Cmd_Exit.Image"), System.Drawing.Image)
        Me.Cmd_Exit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(57, 37)
        Me.Cmd_Exit.Text = "关闭"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 40)
        '
        'TB_No
        '
        Me.TB_No.Location = New System.Drawing.Point(878, 46)
        Me.TB_No.Name = "TB_No"
        Me.TB_No.ReadOnly = True
        Me.TB_No.Size = New System.Drawing.Size(122, 21)
        Me.TB_No.TabIndex = 65
        '
        'LB_No
        '
        Me.LB_No.AutoSize = True
        Me.LB_No.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LB_No.ForeColor = System.Drawing.Color.Blue
        Me.LB_No.Location = New System.Drawing.Point(802, 49)
        Me.LB_No.Name = "LB_No"
        Me.LB_No.Size = New System.Drawing.Size(56, 16)
        Me.LB_No.TabIndex = 66
        Me.LB_No.Text = "缸 号:"
        '
        'Employee_List1
        '
        Me.Employee_List1.BackColor = System.Drawing.Color.DodgerBlue
        Me.Employee_List1.IsTBLostFocusSelOne = True
        Me.Employee_List1.Location = New System.Drawing.Point(-1000, 0)
        Me.Employee_List1.Name = "Employee_List1"
        Me.Employee_List1.SearchId = ""
        Me.Employee_List1.SearchType = BaseClass.Employee_List.ENum_SearchType.ALL
        Me.Employee_List1.Size = New System.Drawing.Size(250, 210)
        Me.Employee_List1.TabIndex = 50
        '
        'Bzc_List1
        '
        Me.Bzc_List1.BackColor = System.Drawing.Color.DodgerBlue
        Me.Bzc_List1.IsTBLostFocusSelOne = True
        Me.Bzc_List1.Location = New System.Drawing.Point(-1000, 0)
        Me.Bzc_List1.Name = "Bzc_List1"
        Me.Bzc_List1.Size = New System.Drawing.Size(250, 210)
        Me.Bzc_List1.TabIndex = 51
        '
        'Bz_List1
        '
        Me.Bz_List1.BackColor = System.Drawing.Color.DodgerBlue
        Me.Bz_List1.IsTBLostFocusSelOne = True
        Me.Bz_List1.Location = New System.Drawing.Point(-1000, 0)
        Me.Bz_List1.Name = "Bz_List1"
        Me.Bz_List1.SearchType = BaseClass.Bz_List.ENum_SearchType.ALL
        Me.Bz_List1.Size = New System.Drawing.Size(250, 210)
        Me.Bz_List1.TabIndex = 52
        '
        'GengDanList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Bz_List1)
        Me.Controls.Add(Me.Bzc_List1)
        Me.Controls.Add(Me.Employee_List1)
        Me.Controls.Add(Me.TB_No)
        Me.Controls.Add(Me.LB_No)
        Me.Controls.Add(Me.Tool_Top)
        Me.Controls.Add(Me.LabelTitle)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.LB_State)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.GB_Foot)
        Me.Controls.Add(Me.GB_ClientRequest)
        Me.Controls.Add(Me.GB_Header)
        Me.Name = "GengDanList"
        Me.Size = New System.Drawing.Size(1020, 577)
        Me.GB_Header.ResumeLayout(False)
        Me.GB_Header.PerformLayout()
        Me.GB_ClientRequest.ResumeLayout(False)
        Me.GB_ClientRequest.PerformLayout()
        Me.GB_Foot.ResumeLayout(False)
        Me.GB_Foot.PerformLayout()
        Me.Tool_Top.ResumeLayout(False)
        Me.Tool_Top.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GB_Header As System.Windows.Forms.GroupBox
    Friend WithEvents Radio_ZL As System.Windows.Forms.RadioButton
    Friend WithEvents Radio_Num As System.Windows.Forms.RadioButton
    Friend WithEvents TB_LuoSeBzZL As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Cmd_ChooseRemark As System.Windows.Forms.Button
    Friend WithEvents DP_JiaoHuo As System.Windows.Forms.DateTimePicker
    Friend WithEvents DP_LuoSe As System.Windows.Forms.DateTimePicker
    Friend WithEvents DP_ShouPei As System.Windows.Forms.DateTimePicker
    Friend WithEvents DP_KaiDan As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TB_BZCName As System.Windows.Forms.TextBox
    Friend WithEvents TB_PB_CountSum As System.Windows.Forms.TextBox
    Friend WithEvents Label84 As System.Windows.Forms.Label
    Friend WithEvents TB_BZCID As System.Windows.Forms.TextBox
    Friend WithEvents Label85 As System.Windows.Forms.Label
    Friend WithEvents TB_BZCClient As System.Windows.Forms.TextBox
    Friend WithEvents TB_PB_ZLSum As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TB_BZName As System.Windows.Forms.TextBox
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents TB_BZID As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TB_ShaPi As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TB_Remark As System.Windows.Forms.TextBox
    Friend WithEvents LB_Remark As System.Windows.Forms.Label
    Friend WithEvents TB_Address As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TB_ProcessType As System.Windows.Forms.TextBox
    Friend WithEvents LB_ProcessType As System.Windows.Forms.Label
    Friend WithEvents TB_JiaZhong As System.Windows.Forms.TextBox
    Friend WithEvents TB_GangCi As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TB_ZhiTong As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents TB_GangShu As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TB_TextileFatory As System.Windows.Forms.TextBox
    Friend WithEvents TB_LuoSeBzCount As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TB_Contract As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TB_ClientName As System.Windows.Forms.TextBox
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents TB_ClientID As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GB_ClientRequest As System.Windows.Forms.GroupBox
    Friend WithEvents CB_SuoShuiJi As System.Windows.Forms.CheckBox
    Friend WithEvents CB_PaoGan As System.Windows.Forms.CheckBox
    Friend WithEvents CB_ShuangJiaoDai As System.Windows.Forms.CheckBox
    Friend WithEvents CB_ShiCa As System.Windows.Forms.CheckBox
    Friend WithEvents CB_DanXi As System.Windows.Forms.CheckBox
    Friend WithEvents CB_DanMo As System.Windows.Forms.CheckBox
    Friend WithEvents CB_KaiDing As System.Windows.Forms.CheckBox
    Friend WithEvents CB_ShiMao As System.Windows.Forms.CheckBox
    Friend WithEvents CB_KaiZhua As System.Windows.Forms.CheckBox
    Friend WithEvents CB_QieBian As System.Windows.Forms.CheckBox
    Friend WithEvents CB_GanCa As System.Windows.Forms.CheckBox
    Friend WithEvents CB_JiangBian As System.Windows.Forms.CheckBox
    Friend WithEvents CB_RiShai As System.Windows.Forms.CheckBox
    Friend WithEvents CB_YinHuaYong As System.Windows.Forms.CheckBox
    Friend WithEvents CB_ZhuangBaiSe As System.Windows.Forms.CheckBox
    Friend WithEvents TB_KeZhong As System.Windows.Forms.TextBox
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents TB_HeGang As System.Windows.Forms.TextBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents TB_DuiGang As System.Windows.Forms.TextBox
    Friend WithEvents Label53 As System.Windows.Forms.Label
    Friend WithEvents TB_NiuDu As System.Windows.Forms.TextBox
    Friend WithEvents TB_BianDuiBian As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents TB_ShiYong As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents TB_ChengXi As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents TB_ZhiSuo As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents TB_HengSuo As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents TB_XiLao As System.Windows.Forms.TextBox
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents GB_Foot As System.Windows.Forms.GroupBox
    Friend WithEvents TB_UPD_User As System.Windows.Forms.TextBox
    Friend WithEvents Label76 As System.Windows.Forms.Label
    Friend WithEvents TB_Auditor As System.Windows.Forms.TextBox
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents TB_GenDan As System.Windows.Forms.TextBox
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents TB_KaiDan As System.Windows.Forms.TextBox
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents LabelTitle As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents LB_State As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Tool_Top As System.Windows.Forms.ToolStrip
    Friend WithEvents Cmd_Modify As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_LuoDan As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_SelectBZ As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_Del As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Cmd_Preview As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_Print As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Cmd_Exit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TB_No As System.Windows.Forms.TextBox
    Friend WithEvents LB_No As System.Windows.Forms.Label
    Friend WithEvents Employee_List1 As BaseClass.Employee_List
    Friend WithEvents Client_List1 As BaseClass.Client_List
    Friend WithEvents Bzc_List1 As BaseClass.Bzc_List
    Friend WithEvents Bz_List1 As BaseClass.Bz_List

End Class
