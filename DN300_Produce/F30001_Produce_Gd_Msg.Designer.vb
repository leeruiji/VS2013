Imports BaseClass

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F30001_Produce_Gd_Msg
    Inherits Global.PClass.BaseForm

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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F30001_Produce_Gd_Msg))
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.CKB_SG = New System.Windows.Forms.GroupBox
        Me.TB_SGName = New System.Windows.Forms.TextBox
        Me.Label33 = New System.Windows.Forms.Label
        Me.CB_Color = New System.Windows.Forms.ComboBox
        Me.CB_SG = New BaseClass.ComBoList
        Me.Label29 = New System.Windows.Forms.Label
        Me.LB_CGRemark = New System.Windows.Forms.Label
        Me.TB_CGRemark = New System.Windows.Forms.TextBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.TB_ClientName = New System.Windows.Forms.TextBox
        Me.Label39 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.CB_CPName = New System.Windows.Forms.CheckBox
        Me.TB_CPName = New System.Windows.Forms.TextBox
        Me.CB_BZ = New BaseClass.ComBoList
        Me.Cmd_BZNo = New System.Windows.Forms.Button
        Me.Cmd_BZName = New System.Windows.Forms.Button
        Me.Cmd_AddBZ = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.TB_BZName = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.CB_State = New System.Windows.Forms.ComboBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.CKB_IsChangeToBlack = New System.Windows.Forms.CheckBox
        Me.Cb_BZC = New BaseClass.ComBoList
        Me.Cmd_BZCName = New System.Windows.Forms.Button
        Me.CB_BZC_PF = New System.Windows.Forms.ComboBox
        Me.Label27 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label_ID = New System.Windows.Forms.Label
        Me.TB_BZCName = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.TB_ClientBZC = New System.Windows.Forms.TextBox
        Me.LB_OrderBill = New System.Windows.Forms.Label
        Me.Cmd_ChooseRemark = New System.Windows.Forms.Button
        Me.DP_Date_JiaoHuo = New System.Windows.Forms.DateTimePicker
        Me.DP_Date_LuoSe = New System.Windows.Forms.DateTimePicker
        Me.DP_Date_ShouPei = New System.Windows.Forms.DateTimePicker
        Me.DP_Date_KaiDan = New System.Windows.Forms.DateTimePicker
        Me.TB_ShaPi = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.TB_Remark = New System.Windows.Forms.TextBox
        Me.LB_Remark = New System.Windows.Forms.Label
        Me.TB_Address = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.TB_ProcessType = New System.Windows.Forms.TextBox
        Me.LB_ProcessType = New System.Windows.Forms.Label
        Me.TB_JiaZhong = New System.Windows.Forms.TextBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.TB_ZhiTong = New System.Windows.Forms.TextBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.TB_GangShu = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.TB_TextileFatory = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.TB_Contract = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Radio_ZL = New System.Windows.Forms.RadioButton
        Me.Radio_Num = New System.Windows.Forms.RadioButton
        Me.TB_CR_LuoSeBzZL = New System.Windows.Forms.TextBox
        Me.Label26 = New System.Windows.Forms.Label
        Me.TB_PB_CountSum = New System.Windows.Forms.TextBox
        Me.Label84 = New System.Windows.Forms.Label
        Me.Label85 = New System.Windows.Forms.Label
        Me.TB_PB_ZLSum = New System.Windows.Forms.TextBox
        Me.TB_CR_LuoSeBzCount = New System.Windows.Forms.TextBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.TB_ClientID = New System.Windows.Forms.TextBox
        Me.TB_GangCi = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.GB_ClientRequest = New System.Windows.Forms.GroupBox
        Me.TB_ClothStore = New System.Windows.Forms.TextBox
        Me.Label28 = New System.Windows.Forms.Label
        Me.CB_CR_SuoShuiJi = New System.Windows.Forms.CheckBox
        Me.CB_CR_PaoGan = New System.Windows.Forms.CheckBox
        Me.CB_CR_ShuangJiaoDai = New System.Windows.Forms.CheckBox
        Me.CB_CR_ShiCa = New System.Windows.Forms.CheckBox
        Me.CB_CR_DanXi = New System.Windows.Forms.CheckBox
        Me.CB_CR_DanMo = New System.Windows.Forms.CheckBox
        Me.CB_CR_KaiDing = New System.Windows.Forms.CheckBox
        Me.CB_CR_ShiMao = New System.Windows.Forms.CheckBox
        Me.CB_CR_KaiZhua = New System.Windows.Forms.CheckBox
        Me.CB_CR_QieBian = New System.Windows.Forms.CheckBox
        Me.CB_CR_GanCa = New System.Windows.Forms.CheckBox
        Me.CB_CR_JiangBian = New System.Windows.Forms.CheckBox
        Me.CB_CR_RiShai = New System.Windows.Forms.CheckBox
        Me.CB_CR_YinHuaYong = New System.Windows.Forms.CheckBox
        Me.CB_CR_ZhuangBaiSe = New System.Windows.Forms.CheckBox
        Me.TB_CR_KeZhong = New System.Windows.Forms.TextBox
        Me.Label36 = New System.Windows.Forms.Label
        Me.TB_HeRanGangHao = New System.Windows.Forms.TextBox
        Me.Label37 = New System.Windows.Forms.Label
        Me.TB_DuiSeGangHao = New System.Windows.Forms.TextBox
        Me.Label53 = New System.Windows.Forms.Label
        Me.TB_CR_NiuDu = New System.Windows.Forms.TextBox
        Me.TB_CR_BianDuiBian = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.TB_CR_ShiYong = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.TB_CR_ChengYiXiShui = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.TB_CR_ZhiSuo = New System.Windows.Forms.TextBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.TB_CR_HengSuo = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.TB_CR_XiLao = New System.Windows.Forms.TextBox
        Me.Label46 = New System.Windows.Forms.Label
        Me.Label51 = New System.Windows.Forms.Label
        Me.Tool_Top = New System.Windows.Forms.ToolStrip
        Me.Cmd_Modify = New System.Windows.Forms.ToolStripButton
        Me.Cmd_Copy = New System.Windows.Forms.ToolStripButton
        Me.Cmd_CG = New System.Windows.Forms.ToolStripButton
        Me.Cmd_ChangeColor = New System.Windows.Forms.ToolStripButton
        Me.Cmd_ChangePB = New System.Windows.Forms.ToolStripButton
        Me.Cmd_HG = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.Cmd_Del = New System.Windows.Forms.ToolStripButton
        Me.Cmd_Invalid = New System.Windows.Forms.ToolStripButton
        Me.Cmd_SetValid = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.Cmd_FG = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.Cmd_Preview = New System.Windows.Forms.ToolStripButton
        Me.Cmd_Print = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.Cmd_ShowList = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.Cmd_Exit = New System.Windows.Forms.ToolStripButton
        Me.GB_Foot = New System.Windows.Forms.GroupBox
        Me.TB_UPD_USER = New BaseClass.GH_BillLog
        Me.TB_Auditor = New System.Windows.Forms.TextBox
        Me.Label47 = New System.Windows.Forms.Label
        Me.TB_GenDan = New System.Windows.Forms.TextBox
        Me.Label45 = New System.Windows.Forms.Label
        Me.TB_KaiDan = New System.Windows.Forms.TextBox
        Me.Label44 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.TB_ID = New System.Windows.Forms.TextBox
        Me.LB_No = New System.Windows.Forms.Label
        Me.LB_State = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.LabelTitle = New System.Windows.Forms.Label
        Me.Tabs = New System.Windows.Forms.TabControl
        Me.Tab_Gd = New System.Windows.Forms.TabPage
        Me.Tab_RB = New System.Windows.Forms.TabPage
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.Cmd_WorkList = New System.Windows.Forms.ToolStripButton
        Me.Cmd_AddRowBefore = New System.Windows.Forms.ToolStripButton
        Me.Cmd_AddRowAfter = New System.Windows.Forms.ToolStripButton
        Me.Cmd_RemoveRow = New System.Windows.Forms.ToolStripButton
        Me.Cmd_ClearAll = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator
        Me.Cmd_UP = New System.Windows.Forms.ToolStripButton
        Me.Cmd_Down = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator
        Me.Cmd_Show = New System.Windows.Forms.ToolStripButton
        Me.Cmd_WorkList_Save = New System.Windows.Forms.ToolStripButton
        Me.Cmd_Edit = New System.Windows.Forms.ToolStripButton
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.Fg_Sel = New PClass.FG
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer
        Me.Fg1 = New PClass.FG
        Me.Fg2 = New PClass.FG
        Me.CMS_FG2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SMI_AddEmployee = New System.Windows.Forms.ToolStripMenuItem
        Me.SMI_DelEmployee = New System.Windows.Forms.ToolStripMenuItem
        Me.Tab_PB = New System.Windows.Forms.TabPage
        Me.PeiBuList1 = New DN300_Produce.PeiBuList
        Me.Tp_DX = New System.Windows.Forms.TabPage
        Me.Label1 = New System.Windows.Forms.Label
        Me.LabelGH = New System.Windows.Forms.Label
        Me.CB_GH = New System.Windows.Forms.ComboBox
        Me.Label30 = New System.Windows.Forms.Label
        Me.TB_SumAmount = New System.Windows.Forms.TextBox
        Me.LabelFDFG = New System.Windows.Forms.Label
        Me.FLP_Title = New System.Windows.Forms.FlowLayoutPanel
        Me.Process1 = New System.Diagnostics.Process
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel
        Me.CB_WorkList = New System.Windows.Forms.ComboBox
        Me.Label31 = New System.Windows.Forms.Label
        Me.Employee_List1 = New BaseClass.Employee_List
        Me.ToolStripSearch1 = New BaseClass.ToolStripSearch
        Me.CKB_SG.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GB_ClientRequest.SuspendLayout()
        Me.Tool_Top.SuspendLayout()
        Me.GB_Foot.SuspendLayout()
        Me.Tabs.SuspendLayout()
        Me.Tab_Gd.SuspendLayout()
        Me.Tab_RB.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.Fg_Sel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.Fg1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Fg2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CMS_FG2.SuspendLayout()
        Me.Tab_PB.SuspendLayout()
        Me.FLP_Title.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CKB_SG
        '
        Me.CKB_SG.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CKB_SG.Controls.Add(Me.TB_SGName)
        Me.CKB_SG.Controls.Add(Me.Label33)
        Me.CKB_SG.Controls.Add(Me.CB_Color)
        Me.CKB_SG.Controls.Add(Me.CB_SG)
        Me.CKB_SG.Controls.Add(Me.Label29)
        Me.CKB_SG.Controls.Add(Me.LB_CGRemark)
        Me.CKB_SG.Controls.Add(Me.TB_CGRemark)
        Me.CKB_SG.Controls.Add(Me.GroupBox3)
        Me.CKB_SG.Controls.Add(Me.GroupBox2)
        Me.CKB_SG.Controls.Add(Me.CB_State)
        Me.CKB_SG.Controls.Add(Me.GroupBox1)
        Me.CKB_SG.Controls.Add(Me.LB_OrderBill)
        Me.CKB_SG.Controls.Add(Me.Cmd_ChooseRemark)
        Me.CKB_SG.Controls.Add(Me.DP_Date_JiaoHuo)
        Me.CKB_SG.Controls.Add(Me.DP_Date_LuoSe)
        Me.CKB_SG.Controls.Add(Me.DP_Date_ShouPei)
        Me.CKB_SG.Controls.Add(Me.DP_Date_KaiDan)
        Me.CKB_SG.Controls.Add(Me.TB_ShaPi)
        Me.CKB_SG.Controls.Add(Me.Label8)
        Me.CKB_SG.Controls.Add(Me.TB_Remark)
        Me.CKB_SG.Controls.Add(Me.LB_Remark)
        Me.CKB_SG.Controls.Add(Me.TB_Address)
        Me.CKB_SG.Controls.Add(Me.Label10)
        Me.CKB_SG.Controls.Add(Me.TB_ProcessType)
        Me.CKB_SG.Controls.Add(Me.LB_ProcessType)
        Me.CKB_SG.Controls.Add(Me.TB_JiaZhong)
        Me.CKB_SG.Controls.Add(Me.Label24)
        Me.CKB_SG.Controls.Add(Me.TB_ZhiTong)
        Me.CKB_SG.Controls.Add(Me.Label20)
        Me.CKB_SG.Controls.Add(Me.TB_GangShu)
        Me.CKB_SG.Controls.Add(Me.Label7)
        Me.CKB_SG.Controls.Add(Me.TB_TextileFatory)
        Me.CKB_SG.Controls.Add(Me.Label13)
        Me.CKB_SG.Controls.Add(Me.Label14)
        Me.CKB_SG.Controls.Add(Me.Label6)
        Me.CKB_SG.Controls.Add(Me.Label12)
        Me.CKB_SG.Controls.Add(Me.TB_Contract)
        Me.CKB_SG.Controls.Add(Me.Label11)
        Me.CKB_SG.Location = New System.Drawing.Point(0, 0)
        Me.CKB_SG.Name = "CKB_SG"
        Me.CKB_SG.Size = New System.Drawing.Size(1005, 305)
        Me.CKB_SG.TabIndex = 0
        Me.CKB_SG.TabStop = False
        '
        'TB_SGName
        '
        Me.TB_SGName.Location = New System.Drawing.Point(371, 209)
        Me.TB_SGName.Name = "TB_SGName"
        Me.TB_SGName.ReadOnly = True
        Me.TB_SGName.Size = New System.Drawing.Size(136, 23)
        Me.TB_SGName.TabIndex = 91
        Me.TB_SGName.TabStop = False
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(303, 214)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(70, 14)
        Me.Label33.TabIndex = 92
        Me.Label33.Text = "工艺名称:"
        '
        'CB_Color
        '
        Me.CB_Color.FormattingEnabled = True
        Me.CB_Color.Items.AddRange(New Object() {"黑色", "白色", "杂色"})
        Me.CB_Color.Location = New System.Drawing.Point(462, 176)
        Me.CB_Color.Name = "CB_Color"
        Me.CB_Color.Size = New System.Drawing.Size(54, 22)
        Me.CB_Color.TabIndex = 90
        '
        'CB_SG
        '
        Me.CB_SG.Child = "ComboSG"
        Me.CB_SG.FormattingEnabled = True
        Me.CB_SG.IDAsInt = CType(0, Long)
        Me.CB_SG.IDValue = ""
        Me.CB_SG.IsKeyDownAutoSearch = True
        Me.CB_SG.IsSelectName = False
        Me.CB_SG.IsTBLostFocusSelOne = True
        Me.CB_SG.Location = New System.Drawing.Point(371, 176)
        Me.CB_SG.Name = "CB_SG"
        Me.CB_SG.SearchID = "1"
        Me.CB_SG.SearchType = BaseClass.cSearchType.ENum_SearchType.Add_SQL
        Me.CB_SG.Size = New System.Drawing.Size(88, 22)
        Me.CB_SG.TabIndex = 55
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(310, 182)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(49, 14)
        Me.Label29.TabIndex = 54
        Me.Label29.Text = "手 感:"
        '
        'LB_CGRemark
        '
        Me.LB_CGRemark.AutoSize = True
        Me.LB_CGRemark.ForeColor = System.Drawing.Color.Blue
        Me.LB_CGRemark.Location = New System.Drawing.Point(303, 252)
        Me.LB_CGRemark.Name = "LB_CGRemark"
        Me.LB_CGRemark.Size = New System.Drawing.Size(70, 14)
        Me.LB_CGRemark.TabIndex = 53
        Me.LB_CGRemark.Text = "拆缸原因:"
        '
        'TB_CGRemark
        '
        Me.TB_CGRemark.Location = New System.Drawing.Point(372, 244)
        Me.TB_CGRemark.Multiline = True
        Me.TB_CGRemark.Name = "TB_CGRemark"
        Me.TB_CGRemark.Size = New System.Drawing.Size(535, 55)
        Me.TB_CGRemark.TabIndex = 52
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.TB_ClientName)
        Me.GroupBox3.Controls.Add(Me.Label39)
        Me.GroupBox3.Location = New System.Drawing.Point(19, 6)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(259, 57)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "客户"
        '
        'TB_ClientName
        '
        Me.TB_ClientName.Font = New System.Drawing.Font("宋体", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TB_ClientName.Location = New System.Drawing.Point(92, 11)
        Me.TB_ClientName.Multiline = True
        Me.TB_ClientName.Name = "TB_ClientName"
        Me.TB_ClientName.ReadOnly = True
        Me.TB_ClientName.Size = New System.Drawing.Size(152, 44)
        Me.TB_ClientName.TabIndex = 17
        Me.TB_ClientName.TabStop = False
        Me.TB_ClientName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.ForeColor = System.Drawing.Color.Crimson
        Me.Label39.Location = New System.Drawing.Point(20, 19)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(63, 14)
        Me.Label39.TabIndex = 23
        Me.Label39.Text = "客   户:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.CB_CPName)
        Me.GroupBox2.Controls.Add(Me.TB_CPName)
        Me.GroupBox2.Controls.Add(Me.CB_BZ)
        Me.GroupBox2.Controls.Add(Me.Cmd_BZNo)
        Me.GroupBox2.Controls.Add(Me.Cmd_BZName)
        Me.GroupBox2.Controls.Add(Me.Cmd_AddBZ)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.TB_BZName)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Location = New System.Drawing.Point(19, 68)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(259, 108)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "布类"
        '
        'CB_CPName
        '
        Me.CB_CPName.AutoSize = True
        Me.CB_CPName.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CB_CPName.Location = New System.Drawing.Point(10, 79)
        Me.CB_CPName.Name = "CB_CPName"
        Me.CB_CPName.Size = New System.Drawing.Size(68, 18)
        Me.CB_CPName.TabIndex = 50
        Me.CB_CPName.Text = "成品名"
        Me.CB_CPName.UseVisualStyleBackColor = True
        '
        'TB_CPName
        '
        Me.TB_CPName.Location = New System.Drawing.Point(83, 77)
        Me.TB_CPName.Name = "TB_CPName"
        Me.TB_CPName.ReadOnly = True
        Me.TB_CPName.Size = New System.Drawing.Size(139, 23)
        Me.TB_CPName.TabIndex = 49
        Me.TB_CPName.TabStop = False
        '
        'CB_BZ
        '
        Me.CB_BZ.Child = "ComboBZ"
        Me.CB_BZ.Enabled = False
        Me.CB_BZ.FormattingEnabled = True
        Me.CB_BZ.IDAsInt = CType(0, Long)
        Me.CB_BZ.IDValue = ""
        Me.CB_BZ.IsKeyDownAutoSearch = True
        Me.CB_BZ.IsSelectName = False
        Me.CB_BZ.IsTBLostFocusSelOne = True
        Me.CB_BZ.Location = New System.Drawing.Point(84, 17)
        Me.CB_BZ.Name = "CB_BZ"
        Me.CB_BZ.SearchType = BaseClass.cSearchType.ENum_SearchType.BZC
        Me.CB_BZ.Size = New System.Drawing.Size(105, 22)
        Me.CB_BZ.TabIndex = 0
        Me.CB_BZ.TabStop = False
        '
        'Cmd_BZNo
        '
        Me.Cmd_BZNo.Enabled = False
        Me.Cmd_BZNo.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Cmd_BZNo.Location = New System.Drawing.Point(192, 18)
        Me.Cmd_BZNo.Name = "Cmd_BZNo"
        Me.Cmd_BZNo.Size = New System.Drawing.Size(29, 23)
        Me.Cmd_BZNo.TabIndex = 48
        Me.Cmd_BZNo.TabStop = False
        Me.Cmd_BZNo.Text = "改"
        Me.Cmd_BZNo.UseVisualStyleBackColor = True
        Me.Cmd_BZNo.Visible = False
        '
        'Cmd_BZName
        '
        Me.Cmd_BZName.Enabled = False
        Me.Cmd_BZName.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Cmd_BZName.Location = New System.Drawing.Point(220, 48)
        Me.Cmd_BZName.Name = "Cmd_BZName"
        Me.Cmd_BZName.Size = New System.Drawing.Size(29, 23)
        Me.Cmd_BZName.TabIndex = 47
        Me.Cmd_BZName.TabStop = False
        Me.Cmd_BZName.Text = "改"
        Me.Cmd_BZName.UseVisualStyleBackColor = True
        Me.Cmd_BZName.Visible = False
        '
        'Cmd_AddBZ
        '
        Me.Cmd_AddBZ.Enabled = False
        Me.Cmd_AddBZ.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Cmd_AddBZ.Location = New System.Drawing.Point(220, 18)
        Me.Cmd_AddBZ.Name = "Cmd_AddBZ"
        Me.Cmd_AddBZ.Size = New System.Drawing.Size(29, 23)
        Me.Cmd_AddBZ.TabIndex = 46
        Me.Cmd_AddBZ.TabStop = False
        Me.Cmd_AddBZ.Text = "+"
        Me.Cmd_AddBZ.UseVisualStyleBackColor = True
        Me.Cmd_AddBZ.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(20, 51)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 14)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "名 称:"
        '
        'TB_BZName
        '
        Me.TB_BZName.Location = New System.Drawing.Point(84, 48)
        Me.TB_BZName.Name = "TB_BZName"
        Me.TB_BZName.ReadOnly = True
        Me.TB_BZName.Size = New System.Drawing.Size(139, 23)
        Me.TB_BZName.TabIndex = 16
        Me.TB_BZName.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(20, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 14)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "编 号:"
        '
        'CB_State
        '
        Me.CB_State.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_State.FormattingEnabled = True
        Me.CB_State.Location = New System.Drawing.Point(454, 225)
        Me.CB_State.Name = "CB_State"
        Me.CB_State.Size = New System.Drawing.Size(121, 22)
        Me.CB_State.TabIndex = 33
        Me.CB_State.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CKB_IsChangeToBlack)
        Me.GroupBox1.Controls.Add(Me.Cb_BZC)
        Me.GroupBox1.Controls.Add(Me.Cmd_BZCName)
        Me.GroupBox1.Controls.Add(Me.CB_BZC_PF)
        Me.GroupBox1.Controls.Add(Me.Label27)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label_ID)
        Me.GroupBox1.Controls.Add(Me.TB_BZCName)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.TB_ClientBZC)
        Me.GroupBox1.Location = New System.Drawing.Point(19, 175)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(259, 125)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "颜色/色号"
        '
        'CKB_IsChangeToBlack
        '
        Me.CKB_IsChangeToBlack.AutoSize = True
        Me.CKB_IsChangeToBlack.Location = New System.Drawing.Point(179, 99)
        Me.CKB_IsChangeToBlack.Name = "CKB_IsChangeToBlack"
        Me.CKB_IsChangeToBlack.Size = New System.Drawing.Size(68, 18)
        Me.CKB_IsChangeToBlack.TabIndex = 49
        Me.CKB_IsChangeToBlack.Text = "改黑色"
        Me.CKB_IsChangeToBlack.UseVisualStyleBackColor = True
        '
        'Cb_BZC
        '
        Me.Cb_BZC.Child = "ComboBZC"
        Me.Cb_BZC.FormattingEnabled = True
        Me.Cb_BZC.IDAsInt = CType(0, Long)
        Me.Cb_BZC.IDValue = ""
        Me.Cb_BZC.IsKeyDownAutoSearch = True
        Me.Cb_BZC.IsSelectName = False
        Me.Cb_BZC.IsTBLostFocusSelOne = True
        Me.Cb_BZC.Location = New System.Drawing.Point(85, 31)
        Me.Cb_BZC.Name = "Cb_BZC"
        Me.Cb_BZC.SearchID = "1"
        Me.Cb_BZC.SearchType = BaseClass.cSearchType.ENum_SearchType.Add_SQL
        Me.Cb_BZC.Size = New System.Drawing.Size(88, 22)
        Me.Cb_BZC.TabIndex = 0
        '
        'Cmd_BZCName
        '
        Me.Cmd_BZCName.Enabled = False
        Me.Cmd_BZCName.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Cmd_BZCName.Location = New System.Drawing.Point(220, 63)
        Me.Cmd_BZCName.Name = "Cmd_BZCName"
        Me.Cmd_BZCName.Size = New System.Drawing.Size(29, 23)
        Me.Cmd_BZCName.TabIndex = 48
        Me.Cmd_BZCName.TabStop = False
        Me.Cmd_BZCName.Text = "改"
        Me.Cmd_BZCName.UseVisualStyleBackColor = True
        Me.Cmd_BZCName.Visible = False
        '
        'CB_BZC_PF
        '
        Me.CB_BZC_PF.Enabled = False
        Me.CB_BZC_PF.FormattingEnabled = True
        Me.CB_BZC_PF.Location = New System.Drawing.Point(179, 31)
        Me.CB_BZC_PF.Name = "CB_BZC_PF"
        Me.CB_BZC_PF.Size = New System.Drawing.Size(44, 22)
        Me.CB_BZC_PF.TabIndex = 1
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(224, 34)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(21, 14)
        Me.Label27.TabIndex = 31
        Me.Label27.Text = "办"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 99)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 14)
        Me.Label4.TabIndex = 29
        Me.Label4.Text = "客户色号:"
        '
        'Label_ID
        '
        Me.Label_ID.AutoSize = True
        Me.Label_ID.ForeColor = System.Drawing.Color.Blue
        Me.Label_ID.Location = New System.Drawing.Point(60, 35)
        Me.Label_ID.Name = "Label_ID"
        Me.Label_ID.Size = New System.Drawing.Size(28, 14)
        Me.Label_ID.TabIndex = 28
        Me.Label_ID.Text = "GY-"
        '
        'TB_BZCName
        '
        Me.TB_BZCName.Location = New System.Drawing.Point(85, 64)
        Me.TB_BZCName.Name = "TB_BZCName"
        Me.TB_BZCName.ReadOnly = True
        Me.TB_BZCName.Size = New System.Drawing.Size(136, 23)
        Me.TB_BZCName.TabIndex = 14
        Me.TB_BZCName.TabStop = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(6, 67)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(49, 14)
        Me.Label16.TabIndex = 20
        Me.Label16.Text = "颜 色:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 34)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 14)
        Me.Label5.TabIndex = 27
        Me.Label5.Text = "色 号:"
        '
        'TB_ClientBZC
        '
        Me.TB_ClientBZC.Location = New System.Drawing.Point(85, 96)
        Me.TB_ClientBZC.Name = "TB_ClientBZC"
        Me.TB_ClientBZC.Size = New System.Drawing.Size(86, 23)
        Me.TB_ClientBZC.TabIndex = 15
        Me.TB_ClientBZC.TabStop = False
        '
        'LB_OrderBill
        '
        Me.LB_OrderBill.AutoSize = True
        Me.LB_OrderBill.Location = New System.Drawing.Point(303, 18)
        Me.LB_OrderBill.Name = "LB_OrderBill"
        Me.LB_OrderBill.Size = New System.Drawing.Size(56, 14)
        Me.LB_OrderBill.TabIndex = 51
        Me.LB_OrderBill.Text = "订单号:"
        '
        'Cmd_ChooseRemark
        '
        Me.Cmd_ChooseRemark.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Cmd_ChooseRemark.Location = New System.Drawing.Point(532, 202)
        Me.Cmd_ChooseRemark.Name = "Cmd_ChooseRemark"
        Me.Cmd_ChooseRemark.Size = New System.Drawing.Size(29, 23)
        Me.Cmd_ChooseRemark.TabIndex = 45
        Me.Cmd_ChooseRemark.TabStop = False
        Me.Cmd_ChooseRemark.Text = "+"
        Me.Cmd_ChooseRemark.UseVisualStyleBackColor = True
        '
        'DP_Date_JiaoHuo
        '
        Me.DP_Date_JiaoHuo.Checked = False
        Me.DP_Date_JiaoHuo.CustomFormat = "yyyy年MM月d日"
        Me.DP_Date_JiaoHuo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DP_Date_JiaoHuo.Location = New System.Drawing.Point(710, 81)
        Me.DP_Date_JiaoHuo.Name = "DP_Date_JiaoHuo"
        Me.DP_Date_JiaoHuo.ShowCheckBox = True
        Me.DP_Date_JiaoHuo.Size = New System.Drawing.Size(197, 23)
        Me.DP_Date_JiaoHuo.TabIndex = 15
        '
        'DP_Date_LuoSe
        '
        Me.DP_Date_LuoSe.CustomFormat = "yyyy年MM月d日"
        Me.DP_Date_LuoSe.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DP_Date_LuoSe.Location = New System.Drawing.Point(710, 15)
        Me.DP_Date_LuoSe.Name = "DP_Date_LuoSe"
        Me.DP_Date_LuoSe.Size = New System.Drawing.Size(197, 23)
        Me.DP_Date_LuoSe.TabIndex = 13
        '
        'DP_Date_ShouPei
        '
        Me.DP_Date_ShouPei.Checked = False
        Me.DP_Date_ShouPei.CustomFormat = "yyyy年MM月d日"
        Me.DP_Date_ShouPei.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DP_Date_ShouPei.Location = New System.Drawing.Point(371, 112)
        Me.DP_Date_ShouPei.Name = "DP_Date_ShouPei"
        Me.DP_Date_ShouPei.ShowCheckBox = True
        Me.DP_Date_ShouPei.Size = New System.Drawing.Size(241, 23)
        Me.DP_Date_ShouPei.TabIndex = 16
        '
        'DP_Date_KaiDan
        '
        Me.DP_Date_KaiDan.CustomFormat = "yyyy年MM月d日"
        Me.DP_Date_KaiDan.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DP_Date_KaiDan.Location = New System.Drawing.Point(710, 48)
        Me.DP_Date_KaiDan.Name = "DP_Date_KaiDan"
        Me.DP_Date_KaiDan.Size = New System.Drawing.Size(197, 23)
        Me.DP_Date_KaiDan.TabIndex = 14
        '
        'TB_ShaPi
        '
        Me.TB_ShaPi.Location = New System.Drawing.Point(372, 80)
        Me.TB_ShaPi.Name = "TB_ShaPi"
        Me.TB_ShaPi.Size = New System.Drawing.Size(241, 23)
        Me.TB_ShaPi.TabIndex = 5
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(316, 85)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(49, 14)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "纱 批:"
        '
        'TB_Remark
        '
        Me.TB_Remark.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TB_Remark.Location = New System.Drawing.Point(570, 182)
        Me.TB_Remark.Multiline = True
        Me.TB_Remark.Name = "TB_Remark"
        Me.TB_Remark.Size = New System.Drawing.Size(337, 84)
        Me.TB_Remark.TabIndex = 12
        '
        'LB_Remark
        '
        Me.LB_Remark.AutoSize = True
        Me.LB_Remark.ForeColor = System.Drawing.Color.Blue
        Me.LB_Remark.Location = New System.Drawing.Point(516, 182)
        Me.LB_Remark.Name = "LB_Remark"
        Me.LB_Remark.Size = New System.Drawing.Size(49, 14)
        Me.LB_Remark.TabIndex = 22
        Me.LB_Remark.Text = "备 注:"
        '
        'TB_Address
        '
        Me.TB_Address.Location = New System.Drawing.Point(372, 147)
        Me.TB_Address.Name = "TB_Address"
        Me.TB_Address.Size = New System.Drawing.Size(242, 23)
        Me.TB_Address.TabIndex = 7
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(294, 151)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(70, 14)
        Me.Label10.TabIndex = 20
        Me.Label10.Text = "送货地址:"
        '
        'TB_ProcessType
        '
        Me.TB_ProcessType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TB_ProcessType.Location = New System.Drawing.Point(710, 114)
        Me.TB_ProcessType.Name = "TB_ProcessType"
        Me.TB_ProcessType.Size = New System.Drawing.Size(197, 23)
        Me.TB_ProcessType.TabIndex = 6
        '
        'LB_ProcessType
        '
        Me.LB_ProcessType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LB_ProcessType.AutoSize = True
        Me.LB_ProcessType.ForeColor = System.Drawing.Color.Blue
        Me.LB_ProcessType.Location = New System.Drawing.Point(634, 118)
        Me.LB_ProcessType.Name = "LB_ProcessType"
        Me.LB_ProcessType.Size = New System.Drawing.Size(70, 14)
        Me.LB_ProcessType.TabIndex = 19
        Me.LB_ProcessType.Text = "加工类别:"
        '
        'TB_JiaZhong
        '
        Me.TB_JiaZhong.Location = New System.Drawing.Point(760, 147)
        Me.TB_JiaZhong.Name = "TB_JiaZhong"
        Me.TB_JiaZhong.Size = New System.Drawing.Size(52, 23)
        Me.TB_JiaZhong.TabIndex = 10
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(717, 151)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(42, 14)
        Me.Label24.TabIndex = 17
        Me.Label24.Text = "加重:"
        '
        'TB_ZhiTong
        '
        Me.TB_ZhiTong.Location = New System.Drawing.Point(665, 147)
        Me.TB_ZhiTong.Name = "TB_ZhiTong"
        Me.TB_ZhiTong.Size = New System.Drawing.Size(46, 23)
        Me.TB_ZhiTong.TabIndex = 9
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(623, 151)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(42, 14)
        Me.Label20.TabIndex = 8
        Me.Label20.Text = "纸筒:"
        '
        'TB_GangShu
        '
        Me.TB_GangShu.Location = New System.Drawing.Point(868, 147)
        Me.TB_GangShu.Name = "TB_GangShu"
        Me.TB_GangShu.Size = New System.Drawing.Size(39, 23)
        Me.TB_GangShu.TabIndex = 11
        Me.TB_GangShu.Text = "1"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(816, 151)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(56, 14)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "总缸数:"
        '
        'TB_TextileFatory
        '
        Me.TB_TextileFatory.Location = New System.Drawing.Point(372, 48)
        Me.TB_TextileFatory.Name = "TB_TextileFatory"
        Me.TB_TextileFatory.Size = New System.Drawing.Size(240, 23)
        Me.TB_TextileFatory.TabIndex = 4
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(634, 52)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(70, 14)
        Me.Label13.TabIndex = 21
        Me.Label13.Text = "开单日期:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(634, 85)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(70, 14)
        Me.Label14.TabIndex = 16
        Me.Label14.Text = "交货日期:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(316, 52)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 14)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "织 厂:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(295, 118)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(70, 14)
        Me.Label12.TabIndex = 25
        Me.Label12.Text = "收胚日期:"
        '
        'TB_Contract
        '
        Me.TB_Contract.Location = New System.Drawing.Point(372, 15)
        Me.TB_Contract.Name = "TB_Contract"
        Me.TB_Contract.Size = New System.Drawing.Size(240, 23)
        Me.TB_Contract.TabIndex = 3
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(634, 19)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(70, 14)
        Me.Label11.TabIndex = 26
        Me.Label11.Text = "落色日期:"
        '
        'Radio_ZL
        '
        Me.Radio_ZL.AutoSize = True
        Me.Radio_ZL.Location = New System.Drawing.Point(103, 143)
        Me.Radio_ZL.Name = "Radio_ZL"
        Me.Radio_ZL.Size = New System.Drawing.Size(95, 18)
        Me.Radio_ZL.TabIndex = 49
        Me.Radio_ZL.Text = "按重量落色"
        Me.Radio_ZL.UseVisualStyleBackColor = True
        '
        'Radio_Num
        '
        Me.Radio_Num.AutoSize = True
        Me.Radio_Num.Checked = True
        Me.Radio_Num.Location = New System.Drawing.Point(7, 143)
        Me.Radio_Num.Name = "Radio_Num"
        Me.Radio_Num.Size = New System.Drawing.Size(95, 18)
        Me.Radio_Num.TabIndex = 48
        Me.Radio_Num.TabStop = True
        Me.Radio_Num.Text = "按条数落色"
        Me.Radio_Num.UseVisualStyleBackColor = True
        '
        'TB_CR_LuoSeBzZL
        '
        Me.TB_CR_LuoSeBzZL.Location = New System.Drawing.Point(436, 141)
        Me.TB_CR_LuoSeBzZL.Name = "TB_CR_LuoSeBzZL"
        Me.TB_CR_LuoSeBzZL.Size = New System.Drawing.Size(70, 23)
        Me.TB_CR_LuoSeBzZL.TabIndex = 26
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(360, 145)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(70, 14)
        Me.Label26.TabIndex = 47
        Me.Label26.Text = "落色重量:"
        '
        'TB_PB_CountSum
        '
        Me.TB_PB_CountSum.Location = New System.Drawing.Point(617, 141)
        Me.TB_PB_CountSum.Name = "TB_PB_CountSum"
        Me.TB_PB_CountSum.ReadOnly = True
        Me.TB_PB_CountSum.Size = New System.Drawing.Size(71, 23)
        Me.TB_PB_CountSum.TabIndex = 42
        '
        'Label84
        '
        Me.Label84.AutoSize = True
        Me.Label84.Location = New System.Drawing.Point(540, 145)
        Me.Label84.Name = "Label84"
        Me.Label84.Size = New System.Drawing.Size(70, 14)
        Me.Label84.TabIndex = 37
        Me.Label84.Text = "已配条数:"
        '
        'Label85
        '
        Me.Label85.AutoSize = True
        Me.Label85.Location = New System.Drawing.Point(705, 145)
        Me.Label85.Name = "Label85"
        Me.Label85.Size = New System.Drawing.Size(70, 14)
        Me.Label85.TabIndex = 34
        Me.Label85.Text = "已配重量:"
        '
        'TB_PB_ZLSum
        '
        Me.TB_PB_ZLSum.Location = New System.Drawing.Point(778, 141)
        Me.TB_PB_ZLSum.Name = "TB_PB_ZLSum"
        Me.TB_PB_ZLSum.ReadOnly = True
        Me.TB_PB_ZLSum.Size = New System.Drawing.Size(70, 23)
        Me.TB_PB_ZLSum.TabIndex = 40
        '
        'TB_CR_LuoSeBzCount
        '
        Me.TB_CR_LuoSeBzCount.Location = New System.Drawing.Point(274, 141)
        Me.TB_CR_LuoSeBzCount.Name = "TB_CR_LuoSeBzCount"
        Me.TB_CR_LuoSeBzCount.Size = New System.Drawing.Size(71, 23)
        Me.TB_CR_LuoSeBzCount.TabIndex = 25
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(198, 145)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(70, 14)
        Me.Label23.TabIndex = 38
        Me.Label23.Text = "落色条数:"
        '
        'TB_ClientID
        '
        Me.TB_ClientID.Location = New System.Drawing.Point(612, 6)
        Me.TB_ClientID.Name = "TB_ClientID"
        Me.TB_ClientID.ReadOnly = True
        Me.TB_ClientID.Size = New System.Drawing.Size(125, 23)
        Me.TB_ClientID.TabIndex = 14
        Me.TB_ClientID.Visible = False
        '
        'TB_GangCi
        '
        Me.TB_GangCi.Location = New System.Drawing.Point(857, 3)
        Me.TB_GangCi.Name = "TB_GangCi"
        Me.TB_GangCi.Size = New System.Drawing.Size(39, 23)
        Me.TB_GangCi.TabIndex = 6
        Me.TB_GangCi.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(813, 6)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(42, 14)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "缸次:"
        Me.Label9.Visible = False
        '
        'GB_ClientRequest
        '
        Me.GB_ClientRequest.Controls.Add(Me.TB_ClothStore)
        Me.GB_ClientRequest.Controls.Add(Me.Label28)
        Me.GB_ClientRequest.Controls.Add(Me.Label23)
        Me.GB_ClientRequest.Controls.Add(Me.CB_CR_SuoShuiJi)
        Me.GB_ClientRequest.Controls.Add(Me.CB_CR_PaoGan)
        Me.GB_ClientRequest.Controls.Add(Me.CB_CR_ShuangJiaoDai)
        Me.GB_ClientRequest.Controls.Add(Me.Radio_ZL)
        Me.GB_ClientRequest.Controls.Add(Me.CB_CR_ShiCa)
        Me.GB_ClientRequest.Controls.Add(Me.Radio_Num)
        Me.GB_ClientRequest.Controls.Add(Me.CB_CR_DanXi)
        Me.GB_ClientRequest.Controls.Add(Me.TB_CR_LuoSeBzZL)
        Me.GB_ClientRequest.Controls.Add(Me.Label26)
        Me.GB_ClientRequest.Controls.Add(Me.CB_CR_DanMo)
        Me.GB_ClientRequest.Controls.Add(Me.CB_CR_KaiDing)
        Me.GB_ClientRequest.Controls.Add(Me.CB_CR_ShiMao)
        Me.GB_ClientRequest.Controls.Add(Me.CB_CR_KaiZhua)
        Me.GB_ClientRequest.Controls.Add(Me.CB_CR_QieBian)
        Me.GB_ClientRequest.Controls.Add(Me.CB_CR_GanCa)
        Me.GB_ClientRequest.Controls.Add(Me.CB_CR_JiangBian)
        Me.GB_ClientRequest.Controls.Add(Me.CB_CR_RiShai)
        Me.GB_ClientRequest.Controls.Add(Me.TB_PB_CountSum)
        Me.GB_ClientRequest.Controls.Add(Me.CB_CR_YinHuaYong)
        Me.GB_ClientRequest.Controls.Add(Me.Label84)
        Me.GB_ClientRequest.Controls.Add(Me.CB_CR_ZhuangBaiSe)
        Me.GB_ClientRequest.Controls.Add(Me.Label85)
        Me.GB_ClientRequest.Controls.Add(Me.TB_CR_KeZhong)
        Me.GB_ClientRequest.Controls.Add(Me.Label36)
        Me.GB_ClientRequest.Controls.Add(Me.TB_PB_ZLSum)
        Me.GB_ClientRequest.Controls.Add(Me.TB_HeRanGangHao)
        Me.GB_ClientRequest.Controls.Add(Me.Label37)
        Me.GB_ClientRequest.Controls.Add(Me.TB_DuiSeGangHao)
        Me.GB_ClientRequest.Controls.Add(Me.Label53)
        Me.GB_ClientRequest.Controls.Add(Me.TB_CR_NiuDu)
        Me.GB_ClientRequest.Controls.Add(Me.TB_CR_BianDuiBian)
        Me.GB_ClientRequest.Controls.Add(Me.Label19)
        Me.GB_ClientRequest.Controls.Add(Me.TB_CR_ShiYong)
        Me.GB_ClientRequest.Controls.Add(Me.Label18)
        Me.GB_ClientRequest.Controls.Add(Me.TB_CR_ChengYiXiShui)
        Me.GB_ClientRequest.Controls.Add(Me.Label17)
        Me.GB_ClientRequest.Controls.Add(Me.TB_CR_ZhiSuo)
        Me.GB_ClientRequest.Controls.Add(Me.Label22)
        Me.GB_ClientRequest.Controls.Add(Me.TB_CR_HengSuo)
        Me.GB_ClientRequest.Controls.Add(Me.Label21)
        Me.GB_ClientRequest.Controls.Add(Me.TB_CR_XiLao)
        Me.GB_ClientRequest.Controls.Add(Me.Label46)
        Me.GB_ClientRequest.Controls.Add(Me.Label51)
        Me.GB_ClientRequest.Controls.Add(Me.TB_CR_LuoSeBzCount)
        Me.GB_ClientRequest.Location = New System.Drawing.Point(0, 309)
        Me.GB_ClientRequest.Name = "GB_ClientRequest"
        Me.GB_ClientRequest.Size = New System.Drawing.Size(1009, 175)
        Me.GB_ClientRequest.TabIndex = 1
        Me.GB_ClientRequest.TabStop = False
        Me.GB_ClientRequest.Text = "客户要求"
        '
        'TB_ClothStore
        '
        Me.TB_ClothStore.Location = New System.Drawing.Point(225, 48)
        Me.TB_ClothStore.Name = "TB_ClothStore"
        Me.TB_ClothStore.Size = New System.Drawing.Size(623, 23)
        Me.TB_ClothStore.TabIndex = 50
        Me.TB_ClothStore.Visible = False
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(177, 52)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(42, 14)
        Me.Label28.TabIndex = 51
        Me.Label28.Text = "布仓:"
        Me.Label28.Visible = False
        '
        'CB_CR_SuoShuiJi
        '
        Me.CB_CR_SuoShuiJi.AutoSize = True
        Me.CB_CR_SuoShuiJi.Location = New System.Drawing.Point(73, 48)
        Me.CB_CR_SuoShuiJi.Name = "CB_CR_SuoShuiJi"
        Me.CB_CR_SuoShuiJi.Size = New System.Drawing.Size(68, 18)
        Me.CB_CR_SuoShuiJi.TabIndex = 14
        Me.CB_CR_SuoShuiJi.Text = "缩水机"
        Me.CB_CR_SuoShuiJi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CB_CR_SuoShuiJi.UseVisualStyleBackColor = True
        '
        'CB_CR_PaoGan
        '
        Me.CB_CR_PaoGan.AutoSize = True
        Me.CB_CR_PaoGan.Location = New System.Drawing.Point(6, 48)
        Me.CB_CR_PaoGan.Name = "CB_CR_PaoGan"
        Me.CB_CR_PaoGan.Size = New System.Drawing.Size(61, 18)
        Me.CB_CR_PaoGan.TabIndex = 13
        Me.CB_CR_PaoGan.Text = "抛 干"
        Me.CB_CR_PaoGan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CB_CR_PaoGan.UseVisualStyleBackColor = True
        '
        'CB_CR_ShuangJiaoDai
        '
        Me.CB_CR_ShuangJiaoDai.AutoSize = True
        Me.CB_CR_ShuangJiaoDai.Location = New System.Drawing.Point(900, 22)
        Me.CB_CR_ShuangJiaoDai.Name = "CB_CR_ShuangJiaoDai"
        Me.CB_CR_ShuangJiaoDai.Size = New System.Drawing.Size(68, 18)
        Me.CB_CR_ShuangJiaoDai.TabIndex = 12
        Me.CB_CR_ShuangJiaoDai.Text = "双胶袋"
        Me.CB_CR_ShuangJiaoDai.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CB_CR_ShuangJiaoDai.UseVisualStyleBackColor = True
        '
        'CB_CR_ShiCa
        '
        Me.CB_CR_ShiCa.AutoSize = True
        Me.CB_CR_ShiCa.Location = New System.Drawing.Point(281, 22)
        Me.CB_CR_ShiCa.Name = "CB_CR_ShiCa"
        Me.CB_CR_ShiCa.Size = New System.Drawing.Size(61, 18)
        Me.CB_CR_ShiCa.TabIndex = 4
        Me.CB_CR_ShiCa.Text = "湿 擦"
        Me.CB_CR_ShiCa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CB_CR_ShiCa.UseVisualStyleBackColor = True
        '
        'CB_CR_DanXi
        '
        Me.CB_CR_DanXi.AutoSize = True
        Me.CB_CR_DanXi.Location = New System.Drawing.Point(819, 22)
        Me.CB_CR_DanXi.Name = "CB_CR_DanXi"
        Me.CB_CR_DanXi.Size = New System.Drawing.Size(82, 18)
        Me.CB_CR_DanXi.TabIndex = 11
        Me.CB_CR_DanXi.Text = "单面吸毛"
        Me.CB_CR_DanXi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CB_CR_DanXi.UseVisualStyleBackColor = True
        '
        'CB_CR_DanMo
        '
        Me.CB_CR_DanMo.AutoSize = True
        Me.CB_CR_DanMo.Location = New System.Drawing.Point(734, 22)
        Me.CB_CR_DanMo.Name = "CB_CR_DanMo"
        Me.CB_CR_DanMo.Size = New System.Drawing.Size(82, 18)
        Me.CB_CR_DanMo.TabIndex = 10
        Me.CB_CR_DanMo.Text = "单面磨毛"
        Me.CB_CR_DanMo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CB_CR_DanMo.UseVisualStyleBackColor = True
        '
        'CB_CR_KaiDing
        '
        Me.CB_CR_KaiDing.AutoSize = True
        Me.CB_CR_KaiDing.Location = New System.Drawing.Point(422, 22)
        Me.CB_CR_KaiDing.Name = "CB_CR_KaiDing"
        Me.CB_CR_KaiDing.Size = New System.Drawing.Size(82, 18)
        Me.CB_CR_KaiDing.TabIndex = 6
        Me.CB_CR_KaiDing.Text = "开边定型"
        Me.CB_CR_KaiDing.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CB_CR_KaiDing.UseVisualStyleBackColor = True
        '
        'CB_CR_ShiMao
        '
        Me.CB_CR_ShiMao.AutoSize = True
        Me.CB_CR_ShiMao.Location = New System.Drawing.Point(355, 22)
        Me.CB_CR_ShiMao.Name = "CB_CR_ShiMao"
        Me.CB_CR_ShiMao.Size = New System.Drawing.Size(61, 18)
        Me.CB_CR_ShiMao.TabIndex = 5
        Me.CB_CR_ShiMao.Text = "食 毛"
        Me.CB_CR_ShiMao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CB_CR_ShiMao.UseVisualStyleBackColor = True
        '
        'CB_CR_KaiZhua
        '
        Me.CB_CR_KaiZhua.AutoSize = True
        Me.CB_CR_KaiZhua.Location = New System.Drawing.Point(648, 22)
        Me.CB_CR_KaiZhua.Name = "CB_CR_KaiZhua"
        Me.CB_CR_KaiZhua.Size = New System.Drawing.Size(82, 18)
        Me.CB_CR_KaiZhua.TabIndex = 9
        Me.CB_CR_KaiZhua.Text = "开边抓毛"
        Me.CB_CR_KaiZhua.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CB_CR_KaiZhua.UseVisualStyleBackColor = True
        '
        'CB_CR_QieBian
        '
        Me.CB_CR_QieBian.AutoSize = True
        Me.CB_CR_QieBian.Location = New System.Drawing.Point(581, 22)
        Me.CB_CR_QieBian.Name = "CB_CR_QieBian"
        Me.CB_CR_QieBian.Size = New System.Drawing.Size(61, 18)
        Me.CB_CR_QieBian.TabIndex = 8
        Me.CB_CR_QieBian.Text = "切 边"
        Me.CB_CR_QieBian.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CB_CR_QieBian.UseVisualStyleBackColor = True
        '
        'CB_CR_GanCa
        '
        Me.CB_CR_GanCa.AutoSize = True
        Me.CB_CR_GanCa.Location = New System.Drawing.Point(214, 22)
        Me.CB_CR_GanCa.Name = "CB_CR_GanCa"
        Me.CB_CR_GanCa.Size = New System.Drawing.Size(61, 18)
        Me.CB_CR_GanCa.TabIndex = 3
        Me.CB_CR_GanCa.Text = "干 擦"
        Me.CB_CR_GanCa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CB_CR_GanCa.UseVisualStyleBackColor = True
        '
        'CB_CR_JiangBian
        '
        Me.CB_CR_JiangBian.AutoSize = True
        Me.CB_CR_JiangBian.Location = New System.Drawing.Point(514, 22)
        Me.CB_CR_JiangBian.Name = "CB_CR_JiangBian"
        Me.CB_CR_JiangBian.Size = New System.Drawing.Size(61, 18)
        Me.CB_CR_JiangBian.TabIndex = 7
        Me.CB_CR_JiangBian.Text = "浆 边"
        Me.CB_CR_JiangBian.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CB_CR_JiangBian.UseVisualStyleBackColor = True
        '
        'CB_CR_RiShai
        '
        Me.CB_CR_RiShai.AutoSize = True
        Me.CB_CR_RiShai.Location = New System.Drawing.Point(147, 22)
        Me.CB_CR_RiShai.Name = "CB_CR_RiShai"
        Me.CB_CR_RiShai.Size = New System.Drawing.Size(61, 18)
        Me.CB_CR_RiShai.TabIndex = 2
        Me.CB_CR_RiShai.Text = "日 晒"
        Me.CB_CR_RiShai.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CB_CR_RiShai.UseVisualStyleBackColor = True
        '
        'CB_CR_YinHuaYong
        '
        Me.CB_CR_YinHuaYong.AutoSize = True
        Me.CB_CR_YinHuaYong.Location = New System.Drawing.Point(73, 22)
        Me.CB_CR_YinHuaYong.Name = "CB_CR_YinHuaYong"
        Me.CB_CR_YinHuaYong.Size = New System.Drawing.Size(68, 18)
        Me.CB_CR_YinHuaYong.TabIndex = 1
        Me.CB_CR_YinHuaYong.Text = "印花用"
        Me.CB_CR_YinHuaYong.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CB_CR_YinHuaYong.UseVisualStyleBackColor = True
        '
        'CB_CR_ZhuangBaiSe
        '
        Me.CB_CR_ZhuangBaiSe.AutoSize = True
        Me.CB_CR_ZhuangBaiSe.Location = New System.Drawing.Point(6, 22)
        Me.CB_CR_ZhuangBaiSe.Name = "CB_CR_ZhuangBaiSe"
        Me.CB_CR_ZhuangBaiSe.Size = New System.Drawing.Size(68, 18)
        Me.CB_CR_ZhuangBaiSe.TabIndex = 0
        Me.CB_CR_ZhuangBaiSe.Text = "撞白色"
        Me.CB_CR_ZhuangBaiSe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CB_CR_ZhuangBaiSe.UseVisualStyleBackColor = True
        '
        'TB_CR_KeZhong
        '
        Me.TB_CR_KeZhong.Location = New System.Drawing.Point(386, 74)
        Me.TB_CR_KeZhong.Name = "TB_CR_KeZhong"
        Me.TB_CR_KeZhong.Size = New System.Drawing.Size(99, 23)
        Me.TB_CR_KeZhong.TabIndex = 17
        Me.TB_CR_KeZhong.Tag = ""
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(331, 78)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(49, 14)
        Me.Label36.TabIndex = 34
        Me.Label36.Text = "克 重:"
        '
        'TB_HeRanGangHao
        '
        Me.TB_HeRanGangHao.Location = New System.Drawing.Point(749, 103)
        Me.TB_HeRanGangHao.Name = "TB_HeRanGangHao"
        Me.TB_HeRanGangHao.Size = New System.Drawing.Size(99, 23)
        Me.TB_HeRanGangHao.TabIndex = 24
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(669, 107)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(70, 14)
        Me.Label37.TabIndex = 36
        Me.Label37.Text = "合染缸号:"
        '
        'TB_DuiSeGangHao
        '
        Me.TB_DuiSeGangHao.Location = New System.Drawing.Point(567, 103)
        Me.TB_DuiSeGangHao.Name = "TB_DuiSeGangHao"
        Me.TB_DuiSeGangHao.Size = New System.Drawing.Size(99, 23)
        Me.TB_DuiSeGangHao.TabIndex = 23
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.Location = New System.Drawing.Point(491, 106)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(70, 14)
        Me.Label53.TabIndex = 35
        Me.Label53.Text = "对色缸号:"
        '
        'TB_CR_NiuDu
        '
        Me.TB_CR_NiuDu.Location = New System.Drawing.Point(386, 103)
        Me.TB_CR_NiuDu.Name = "TB_CR_NiuDu"
        Me.TB_CR_NiuDu.Size = New System.Drawing.Size(99, 23)
        Me.TB_CR_NiuDu.TabIndex = 22
        Me.TB_CR_NiuDu.Tag = "%以内"
        '
        'TB_CR_BianDuiBian
        '
        Me.TB_CR_BianDuiBian.Location = New System.Drawing.Point(226, 74)
        Me.TB_CR_BianDuiBian.Name = "TB_CR_BianDuiBian"
        Me.TB_CR_BianDuiBian.Size = New System.Drawing.Size(99, 23)
        Me.TB_CR_BianDuiBian.TabIndex = 16
        Me.TB_CR_BianDuiBian.Tag = ""
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(164, 78)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(56, 14)
        Me.Label19.TabIndex = 38
        Me.Label19.Text = "边对边:"
        '
        'TB_CR_ShiYong
        '
        Me.TB_CR_ShiYong.Location = New System.Drawing.Point(59, 74)
        Me.TB_CR_ShiYong.Name = "TB_CR_ShiYong"
        Me.TB_CR_ShiYong.Size = New System.Drawing.Size(99, 23)
        Me.TB_CR_ShiYong.TabIndex = 15
        Me.TB_CR_ShiYong.Tag = ""
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(11, 78)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(42, 14)
        Me.Label18.TabIndex = 38
        Me.Label18.Text = "实用:"
        '
        'TB_CR_ChengYiXiShui
        '
        Me.TB_CR_ChengYiXiShui.Location = New System.Drawing.Point(748, 74)
        Me.TB_CR_ChengYiXiShui.Name = "TB_CR_ChengYiXiShui"
        Me.TB_CR_ChengYiXiShui.Size = New System.Drawing.Size(99, 23)
        Me.TB_CR_ChengYiXiShui.TabIndex = 19
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(672, 78)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(70, 14)
        Me.Label17.TabIndex = 38
        Me.Label17.Text = "成衣洗水:"
        '
        'TB_CR_ZhiSuo
        '
        Me.TB_CR_ZhiSuo.Location = New System.Drawing.Point(226, 103)
        Me.TB_CR_ZhiSuo.Name = "TB_CR_ZhiSuo"
        Me.TB_CR_ZhiSuo.Size = New System.Drawing.Size(99, 23)
        Me.TB_CR_ZhiSuo.TabIndex = 21
        Me.TB_CR_ZhiSuo.Tag = "%以内"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(178, 107)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(42, 14)
        Me.Label22.TabIndex = 38
        Me.Label22.Text = "直缩:"
        '
        'TB_CR_HengSuo
        '
        Me.TB_CR_HengSuo.Location = New System.Drawing.Point(59, 103)
        Me.TB_CR_HengSuo.Name = "TB_CR_HengSuo"
        Me.TB_CR_HengSuo.Size = New System.Drawing.Size(99, 23)
        Me.TB_CR_HengSuo.TabIndex = 20
        Me.TB_CR_HengSuo.Tag = "%以内"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(11, 107)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(42, 14)
        Me.Label21.TabIndex = 38
        Me.Label21.Text = "横缩:"
        '
        'TB_CR_XiLao
        '
        Me.TB_CR_XiLao.Location = New System.Drawing.Point(567, 74)
        Me.TB_CR_XiLao.Name = "TB_CR_XiLao"
        Me.TB_CR_XiLao.Size = New System.Drawing.Size(99, 23)
        Me.TB_CR_XiLao.TabIndex = 18
        Me.TB_CR_XiLao.Tag = "级以上"
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.Location = New System.Drawing.Point(491, 78)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(70, 14)
        Me.Label46.TabIndex = 38
        Me.Label46.Text = "洗水牢度:"
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.Location = New System.Drawing.Point(330, 107)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(49, 14)
        Me.Label51.TabIndex = 37
        Me.Label51.Text = "扭 度:"
        '
        'Tool_Top
        '
        Me.Tool_Top.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.Tool_Top.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Cmd_Modify, Me.Cmd_Copy, Me.Cmd_CG, Me.Cmd_ChangeColor, Me.Cmd_ChangePB, Me.Cmd_HG, Me.ToolStripSeparator5, Me.Cmd_Del, Me.Cmd_Invalid, Me.Cmd_SetValid, Me.ToolStripSeparator2, Me.Cmd_FG, Me.ToolStripSeparator3, Me.Cmd_Preview, Me.Cmd_Print, Me.ToolStripSeparator1, Me.Cmd_ShowList, Me.ToolStripSeparator4, Me.Cmd_Exit})
        Me.Tool_Top.Location = New System.Drawing.Point(0, 0)
        Me.Tool_Top.MinimumSize = New System.Drawing.Size(0, 40)
        Me.Tool_Top.Name = "Tool_Top"
        Me.Tool_Top.Size = New System.Drawing.Size(1024, 40)
        Me.Tool_Top.TabIndex = 45
        Me.Tool_Top.Text = "ToolStrip2"
        '
        'Cmd_Modify
        '
        Me.Cmd_Modify.AccessibleDescription = "修改按钮"
        Me.Cmd_Modify.AccessibleName = ""
        Me.Cmd_Modify.Image = CType(resources.GetObject("Cmd_Modify.Image"), System.Drawing.Image)
        Me.Cmd_Modify.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Modify.Name = "Cmd_Modify"
        Me.Cmd_Modify.Size = New System.Drawing.Size(60, 37)
        Me.Cmd_Modify.Text = "保存"
        '
        'Cmd_Copy
        '
        Me.Cmd_Copy.Image = Global.DN300_Produce.My.Resources.Resources.Export
        Me.Cmd_Copy.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Copy.Name = "Cmd_Copy"
        Me.Cmd_Copy.Size = New System.Drawing.Size(60, 37)
        Me.Cmd_Copy.Text = "复制"
        '
        'Cmd_CG
        '
        Me.Cmd_CG.Image = Global.DN300_Produce.My.Resources.Resources.cascate
        Me.Cmd_CG.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_CG.Name = "Cmd_CG"
        Me.Cmd_CG.Size = New System.Drawing.Size(60, 37)
        Me.Cmd_CG.Text = "拆缸"
        '
        'Cmd_ChangeColor
        '
        Me.Cmd_ChangeColor.AccessibleDescription = "修改按钮"
        Me.Cmd_ChangeColor.AccessibleName = ""
        Me.Cmd_ChangeColor.Image = Global.DN300_Produce.My.Resources.Resources._87
        Me.Cmd_ChangeColor.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_ChangeColor.Name = "Cmd_ChangeColor"
        Me.Cmd_ChangeColor.Size = New System.Drawing.Size(60, 37)
        Me.Cmd_ChangeColor.Text = "改色"
        '
        'Cmd_ChangePB
        '
        Me.Cmd_ChangePB.AccessibleDescription = "修改按钮"
        Me.Cmd_ChangePB.AccessibleName = ""
        Me.Cmd_ChangePB.Image = Global.DN300_Produce.My.Resources.Resources.Export
        Me.Cmd_ChangePB.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_ChangePB.Name = "Cmd_ChangePB"
        Me.Cmd_ChangePB.Size = New System.Drawing.Size(60, 37)
        Me.Cmd_ChangePB.Text = "转移"
        Me.Cmd_ChangePB.Visible = False
        '
        'Cmd_HG
        '
        Me.Cmd_HG.Image = Global.DN300_Produce.My.Resources.Resources._14
        Me.Cmd_HG.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_HG.Name = "Cmd_HG"
        Me.Cmd_HG.Size = New System.Drawing.Size(60, 37)
        Me.Cmd_HG.Text = "合缸"
        Me.Cmd_HG.Visible = False
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 40)
        '
        'Cmd_Del
        '
        Me.Cmd_Del.AccessibleDescription = "修改按钮"
        Me.Cmd_Del.AccessibleName = ""
        Me.Cmd_Del.Image = CType(resources.GetObject("Cmd_Del.Image"), System.Drawing.Image)
        Me.Cmd_Del.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Del.Name = "Cmd_Del"
        Me.Cmd_Del.Size = New System.Drawing.Size(60, 37)
        Me.Cmd_Del.Text = "删除"
        Me.Cmd_Del.Visible = False
        '
        'Cmd_Invalid
        '
        Me.Cmd_Invalid.Image = Global.DN300_Produce.My.Resources.Resources.InValid
        Me.Cmd_Invalid.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Invalid.Name = "Cmd_Invalid"
        Me.Cmd_Invalid.Size = New System.Drawing.Size(60, 37)
        Me.Cmd_Invalid.Text = "作废"
        '
        'Cmd_SetValid
        '
        Me.Cmd_SetValid.Image = Global.DN300_Produce.My.Resources.Resources.SetValid
        Me.Cmd_SetValid.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_SetValid.Name = "Cmd_SetValid"
        Me.Cmd_SetValid.Size = New System.Drawing.Size(60, 37)
        Me.Cmd_SetValid.Text = "还原"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 40)
        '
        'Cmd_FG
        '
        Me.Cmd_FG.Image = Global.DN300_Produce.My.Resources.Resources._43
        Me.Cmd_FG.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_FG.Name = "Cmd_FG"
        Me.Cmd_FG.Size = New System.Drawing.Size(60, 37)
        Me.Cmd_FG.Text = "反工"
        Me.Cmd_FG.Visible = False
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 40)
        '
        'Cmd_Preview
        '
        Me.Cmd_Preview.Image = CType(resources.GetObject("Cmd_Preview.Image"), System.Drawing.Image)
        Me.Cmd_Preview.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Preview.Name = "Cmd_Preview"
        Me.Cmd_Preview.Size = New System.Drawing.Size(60, 37)
        Me.Cmd_Preview.Text = "预览"
        '
        'Cmd_Print
        '
        Me.Cmd_Print.Image = CType(resources.GetObject("Cmd_Print.Image"), System.Drawing.Image)
        Me.Cmd_Print.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Print.Name = "Cmd_Print"
        Me.Cmd_Print.Size = New System.Drawing.Size(60, 37)
        Me.Cmd_Print.Text = "打印"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 40)
        '
        'Cmd_ShowList
        '
        Me.Cmd_ShowList.CheckOnClick = True
        Me.Cmd_ShowList.Image = Global.DN300_Produce.My.Resources.Resources.Word
        Me.Cmd_ShowList.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_ShowList.Name = "Cmd_ShowList"
        Me.Cmd_ShowList.Size = New System.Drawing.Size(84, 37)
        Me.Cmd_ShowList.Text = "领料明细"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 40)
        '
        'Cmd_Exit
        '
        Me.Cmd_Exit.Image = CType(resources.GetObject("Cmd_Exit.Image"), System.Drawing.Image)
        Me.Cmd_Exit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(60, 37)
        Me.Cmd_Exit.Text = "关闭"
        '
        'GB_Foot
        '
        Me.GB_Foot.Controls.Add(Me.TB_UPD_USER)
        Me.GB_Foot.Controls.Add(Me.TB_Auditor)
        Me.GB_Foot.Controls.Add(Me.Label47)
        Me.GB_Foot.Controls.Add(Me.TB_GenDan)
        Me.GB_Foot.Controls.Add(Me.Label45)
        Me.GB_Foot.Controls.Add(Me.TB_KaiDan)
        Me.GB_Foot.Controls.Add(Me.Label44)
        Me.GB_Foot.Location = New System.Drawing.Point(0, 482)
        Me.GB_Foot.Name = "GB_Foot"
        Me.GB_Foot.Size = New System.Drawing.Size(1009, 47)
        Me.GB_Foot.TabIndex = 2
        Me.GB_Foot.TabStop = False
        '
        'TB_UPD_USER
        '
        Me.TB_UPD_USER.AutoFixSize = True
        Me.TB_UPD_USER.BillID = ""
        Me.TB_UPD_USER.BillType = BaseClass.BillType.Purchase
        Me.TB_UPD_USER.Font_Text = New System.Drawing.Font("宋体", 10.5!)
        Me.TB_UPD_USER.ForeColor_Text = System.Drawing.SystemColors.WindowText
        Me.TB_UPD_USER.IsShowTitle = True
        Me.TB_UPD_USER.Location = New System.Drawing.Point(570, 17)
        Me.TB_UPD_USER.Name = "TB_UPD_USER"
        Me.TB_UPD_USER.Readonly = True
        Me.TB_UPD_USER.ShowDirection = BaseClass.GH_BillLog.Enum_ShowDirection.Below
        Me.TB_UPD_USER.ShowDistince = 1
        Me.TB_UPD_USER.Size = New System.Drawing.Size(257, 23)
        Me.TB_UPD_USER.TabIndex = 41
        Me.TB_UPD_USER.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.TB_UPD_USER.Title = "最后修改人:"
        '
        'TB_Auditor
        '
        Me.TB_Auditor.Location = New System.Drawing.Point(445, 17)
        Me.TB_Auditor.Name = "TB_Auditor"
        Me.TB_Auditor.ReadOnly = True
        Me.TB_Auditor.Size = New System.Drawing.Size(84, 23)
        Me.TB_Auditor.TabIndex = 2
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.Location = New System.Drawing.Point(383, 21)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(56, 14)
        Me.Label47.TabIndex = 40
        Me.Label47.Text = "审核人:"
        '
        'TB_GenDan
        '
        Me.TB_GenDan.Location = New System.Drawing.Point(264, 17)
        Me.TB_GenDan.Name = "TB_GenDan"
        Me.TB_GenDan.Size = New System.Drawing.Size(84, 23)
        Me.TB_GenDan.TabIndex = 0
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Location = New System.Drawing.Point(202, 21)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(56, 14)
        Me.Label45.TabIndex = 40
        Me.Label45.Text = "跟单员:"
        '
        'TB_KaiDan
        '
        Me.TB_KaiDan.Location = New System.Drawing.Point(65, 17)
        Me.TB_KaiDan.Name = "TB_KaiDan"
        Me.TB_KaiDan.ReadOnly = True
        Me.TB_KaiDan.Size = New System.Drawing.Size(84, 23)
        Me.TB_KaiDan.TabIndex = 0
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Location = New System.Drawing.Point(6, 21)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(56, 14)
        Me.Label44.TabIndex = 40
        Me.Label44.Text = "开单员:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("宋体", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label15.Location = New System.Drawing.Point(88, 17)
        Me.Label15.Margin = New System.Windows.Forms.Padding(3, 5, 3, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(67, 19)
        Me.Label15.TabIndex = 32
        Me.Label15.Text = "状 态:"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TB_ID
        '
        Me.TB_ID.Location = New System.Drawing.Point(647, 3)
        Me.TB_ID.Name = "TB_ID"
        Me.TB_ID.ReadOnly = True
        Me.TB_ID.Size = New System.Drawing.Size(122, 23)
        Me.TB_ID.TabIndex = 1
        '
        'LB_No
        '
        Me.LB_No.AutoSize = True
        Me.LB_No.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LB_No.ForeColor = System.Drawing.Color.Blue
        Me.LB_No.Location = New System.Drawing.Point(585, 8)
        Me.LB_No.Margin = New System.Windows.Forms.Padding(3, 8, 3, 0)
        Me.LB_No.Name = "LB_No"
        Me.LB_No.Size = New System.Drawing.Size(56, 16)
        Me.LB_No.TabIndex = 31
        Me.LB_No.Text = "缸 号:"
        '
        'LB_State
        '
        Me.LB_State.AutoSize = True
        Me.LB_State.Font = New System.Drawing.Font("宋体", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LB_State.Location = New System.Drawing.Point(161, 15)
        Me.LB_State.Name = "LB_State"
        Me.LB_State.Size = New System.Drawing.Size(0, 21)
        Me.LB_State.TabIndex = 27
        '
        'Label25
        '
        Me.Label25.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label25.BackColor = System.Drawing.Color.Blue
        Me.Label25.Location = New System.Drawing.Point(-1, 82)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(1023, 3)
        Me.Label25.TabIndex = 1
        '
        'LabelTitle
        '
        Me.LabelTitle.AutoSize = True
        Me.LabelTitle.Font = New System.Drawing.Font("黑体", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LabelTitle.ForeColor = System.Drawing.Color.Blue
        Me.LabelTitle.Location = New System.Drawing.Point(8, 16)
        Me.LabelTitle.Margin = New System.Windows.Forms.Padding(8, 5, 8, 0)
        Me.LabelTitle.Name = "LabelTitle"
        Me.LabelTitle.Size = New System.Drawing.Size(69, 20)
        Me.LabelTitle.TabIndex = 53
        Me.LabelTitle.Text = "运转单"
        '
        'Tabs
        '
        Me.Tabs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Tabs.Controls.Add(Me.Tab_Gd)
        Me.Tabs.Controls.Add(Me.Tab_RB)
        Me.Tabs.Controls.Add(Me.Tab_PB)
        Me.Tabs.Controls.Add(Me.Tp_DX)
        Me.Tabs.Location = New System.Drawing.Point(3, 88)
        Me.Tabs.Name = "Tabs"
        Me.Tabs.SelectedIndex = 0
        Me.Tabs.Size = New System.Drawing.Size(1019, 612)
        Me.Tabs.TabIndex = 0
        '
        'Tab_Gd
        '
        Me.Tab_Gd.Controls.Add(Me.GB_Foot)
        Me.Tab_Gd.Controls.Add(Me.CKB_SG)
        Me.Tab_Gd.Controls.Add(Me.GB_ClientRequest)
        Me.Tab_Gd.Location = New System.Drawing.Point(4, 24)
        Me.Tab_Gd.Name = "Tab_Gd"
        Me.Tab_Gd.Padding = New System.Windows.Forms.Padding(3)
        Me.Tab_Gd.Size = New System.Drawing.Size(1011, 584)
        Me.Tab_Gd.TabIndex = 0
        Me.Tab_Gd.Text = "跟单部"
        Me.Tab_Gd.UseVisualStyleBackColor = True
        '
        'Tab_RB
        '
        Me.Tab_RB.Controls.Add(Me.ToolStrip1)
        Me.Tab_RB.Controls.Add(Me.SplitContainer1)
        Me.Tab_RB.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.Tab_RB.Location = New System.Drawing.Point(4, 24)
        Me.Tab_RB.Name = "Tab_RB"
        Me.Tab_RB.Padding = New System.Windows.Forms.Padding(3)
        Me.Tab_RB.Size = New System.Drawing.Size(1011, 584)
        Me.Tab_RB.TabIndex = 2
        Me.Tab_RB.Text = "工序"
        Me.Tab_RB.UseVisualStyleBackColor = True
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Cmd_WorkList, Me.Cmd_AddRowBefore, Me.Cmd_AddRowAfter, Me.Cmd_RemoveRow, Me.Cmd_ClearAll, Me.ToolStripSeparator8, Me.Cmd_UP, Me.Cmd_Down, Me.ToolStripSeparator9, Me.Cmd_Show, Me.Cmd_WorkList_Save, Me.Cmd_Edit})
        Me.ToolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 3)
        Me.ToolStrip1.MinimumSize = New System.Drawing.Size(0, 30)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1005, 30)
        Me.ToolStrip1.TabIndex = 33
        Me.ToolStrip1.Text = "ToolStrip2"
        '
        'Cmd_WorkList
        '
        Me.Cmd_WorkList.Image = Global.DN300_Produce.My.Resources.Resources._52
        Me.Cmd_WorkList.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_WorkList.Name = "Cmd_WorkList"
        Me.Cmd_WorkList.Size = New System.Drawing.Size(84, 27)
        Me.Cmd_WorkList.Text = "添加集合"
        Me.Cmd_WorkList.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
        Me.Cmd_WorkList.ToolTipText = "加工集合将会插入到最后"
        '
        'Cmd_AddRowBefore
        '
        Me.Cmd_AddRowBefore.Image = Global.DN300_Produce.My.Resources.Resources.AddRow
        Me.Cmd_AddRowBefore.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_AddRowBefore.Name = "Cmd_AddRowBefore"
        Me.Cmd_AddRowBefore.Size = New System.Drawing.Size(74, 27)
        Me.Cmd_AddRowBefore.Text = "前加->"
        Me.Cmd_AddRowBefore.ToolTipText = "添加的加工内容会插入到你所选的行的前面"
        Me.Cmd_AddRowBefore.Visible = False
        '
        'Cmd_AddRowAfter
        '
        Me.Cmd_AddRowAfter.Image = Global.DN300_Produce.My.Resources.Resources.AddRow
        Me.Cmd_AddRowAfter.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_AddRowAfter.Name = "Cmd_AddRowAfter"
        Me.Cmd_AddRowAfter.Size = New System.Drawing.Size(74, 27)
        Me.Cmd_AddRowAfter.Text = "后加->"
        Me.Cmd_AddRowAfter.ToolTipText = "添加的加工内容会插入到你所选的行的后面"
        Me.Cmd_AddRowAfter.Visible = False
        '
        'Cmd_RemoveRow
        '
        Me.Cmd_RemoveRow.Image = Global.DN300_Produce.My.Resources.Resources.RemoveRow1
        Me.Cmd_RemoveRow.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_RemoveRow.Name = "Cmd_RemoveRow"
        Me.Cmd_RemoveRow.Size = New System.Drawing.Size(74, 27)
        Me.Cmd_RemoveRow.Text = "<-减行"
        '
        'Cmd_ClearAll
        '
        Me.Cmd_ClearAll.Image = Global.DN300_Produce.My.Resources.Resources.cancel
        Me.Cmd_ClearAll.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_ClearAll.Name = "Cmd_ClearAll"
        Me.Cmd_ClearAll.Size = New System.Drawing.Size(84, 27)
        Me.Cmd_ClearAll.Text = "清空工序"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 30)
        '
        'Cmd_UP
        '
        Me.Cmd_UP.Image = Global.DN300_Produce.My.Resources.Resources.up
        Me.Cmd_UP.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_UP.Name = "Cmd_UP"
        Me.Cmd_UP.Size = New System.Drawing.Size(60, 27)
        Me.Cmd_UP.Text = "上移"
        '
        'Cmd_Down
        '
        Me.Cmd_Down.Image = Global.DN300_Produce.My.Resources.Resources.down
        Me.Cmd_Down.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Down.Name = "Cmd_Down"
        Me.Cmd_Down.Size = New System.Drawing.Size(60, 27)
        Me.Cmd_Down.Text = "下移"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(6, 30)
        '
        'Cmd_Show
        '
        Me.Cmd_Show.Image = Global.DN300_Produce.My.Resources.Resources.ReFresh
        Me.Cmd_Show.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Show.Name = "Cmd_Show"
        Me.Cmd_Show.Size = New System.Drawing.Size(84, 27)
        Me.Cmd_Show.Text = "加工内容"
        '
        'Cmd_WorkList_Save
        '
        Me.Cmd_WorkList_Save.Image = Global.DN300_Produce.My.Resources.Resources._74
        Me.Cmd_WorkList_Save.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_WorkList_Save.Name = "Cmd_WorkList_Save"
        Me.Cmd_WorkList_Save.Size = New System.Drawing.Size(60, 27)
        Me.Cmd_WorkList_Save.Text = "保存"
        '
        'Cmd_Edit
        '
        Me.Cmd_Edit.Image = Global.DN300_Produce.My.Resources.Resources.paste
        Me.Cmd_Edit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Edit.Name = "Cmd_Edit"
        Me.Cmd_Edit.Size = New System.Drawing.Size(84, 27)
        Me.Cmd_Edit.Text = "编辑状态"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.Cursor = System.Windows.Forms.Cursors.Default
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 36)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox4)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.GroupBox5)
        Me.SplitContainer1.Size = New System.Drawing.Size(1013, 546)
        Me.SplitContainer1.SplitterDistance = 486
        Me.SplitContainer1.TabIndex = 34
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Fg_Sel)
        Me.GroupBox4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox4.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(486, 546)
        Me.GroupBox4.TabIndex = 34
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "加工内容"
        '
        'Fg_Sel
        '
        Me.Fg_Sel.AddCopyMenu = False
        Me.Fg_Sel.AllowEditing = False
        Me.Fg_Sel.AutoAddIndex = True
        Me.Fg_Sel.AutoGenerateColumns = False
        Me.Fg_Sel.AutoResize = False
        Me.Fg_Sel.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.Fg_Sel.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.XpThemes
        Me.Fg_Sel.CanEditing = False
        Me.Fg_Sel.CheckKeyPressEdit = True
        Me.Fg_Sel.ColumnInfo = resources.GetString("Fg_Sel.ColumnInfo")
        Me.Fg_Sel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Fg_Sel.EditFormat = True
        Me.Fg_Sel.ExtendLastCol = True
        Me.Fg_Sel.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Fg_Sel.ForeColor = System.Drawing.Color.Black
        Me.Fg_Sel.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.Fg_Sel.IsAutoAddRow = True
        Me.Fg_Sel.IsClickStartEdit = True
        Me.Fg_Sel.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.Fg_Sel.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.Fg_Sel.Location = New System.Drawing.Point(3, 19)
        Me.Fg_Sel.Name = "Fg_Sel"
        Me.Fg_Sel.NoShowMenu = False
        Me.Fg_Sel.Rows.Count = 1
        Me.Fg_Sel.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.Fg_Sel.Size = New System.Drawing.Size(480, 524)
        Me.Fg_Sel.StartCol = "WL_No"
        Me.Fg_Sel.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("Fg_Sel.Styles"))
        Me.Fg_Sel.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.BelowData
        Me.Fg_Sel.TabIndex = 33
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.SplitContainer2)
        Me.GroupBox5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox5.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(523, 546)
        Me.GroupBox5.TabIndex = 33
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "工序"
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(3, 19)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.Fg1)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.Fg2)
        Me.SplitContainer2.Size = New System.Drawing.Size(517, 524)
        Me.SplitContainer2.SplitterDistance = 390
        Me.SplitContainer2.TabIndex = 33
        '
        'Fg1
        '
        Me.Fg1.AddCopyMenu = False
        Me.Fg1.AllowEditing = False
        Me.Fg1.AutoAddIndex = True
        Me.Fg1.AutoGenerateColumns = False
        Me.Fg1.AutoResize = False
        Me.Fg1.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.Fg1.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.XpThemes
        Me.Fg1.CanEditing = False
        Me.Fg1.CheckKeyPressEdit = True
        Me.Fg1.ColumnInfo = resources.GetString("Fg1.ColumnInfo")
        Me.Fg1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Fg1.EditFormat = True
        Me.Fg1.ExtendLastCol = True
        Me.Fg1.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Fg1.ForeColor = System.Drawing.Color.Black
        Me.Fg1.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.Fg1.IsAutoAddRow = True
        Me.Fg1.IsClickStartEdit = True
        Me.Fg1.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.Fg1.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.Fg1.Location = New System.Drawing.Point(0, 0)
        Me.Fg1.Name = "Fg1"
        Me.Fg1.NoShowMenu = False
        Me.Fg1.Rows.Count = 1
        Me.Fg1.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.Fg1.Size = New System.Drawing.Size(390, 524)
        Me.Fg1.StartCol = "WL_No"
        Me.Fg1.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("Fg1.Styles"))
        Me.Fg1.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.BelowData
        Me.Fg1.TabIndex = 32
        '
        'Fg2
        '
        Me.Fg2.AddCopyMenu = False
        Me.Fg2.AllowEditing = False
        Me.Fg2.AutoAddIndex = True
        Me.Fg2.AutoGenerateColumns = False
        Me.Fg2.AutoResize = False
        Me.Fg2.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.Fg2.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.XpThemes
        Me.Fg2.CanEditing = False
        Me.Fg2.CheckKeyPressEdit = True
        Me.Fg2.ColumnInfo = resources.GetString("Fg2.ColumnInfo")
        Me.Fg2.ContextMenuStrip = Me.CMS_FG2
        Me.Fg2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Fg2.EditFormat = True
        Me.Fg2.ExtendLastCol = True
        Me.Fg2.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Fg2.ForeColor = System.Drawing.Color.Black
        Me.Fg2.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.Fg2.IsAutoAddRow = True
        Me.Fg2.IsClickStartEdit = True
        Me.Fg2.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.Fg2.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.Fg2.Location = New System.Drawing.Point(0, 0)
        Me.Fg2.Name = "Fg2"
        Me.Fg2.NoShowMenu = False
        Me.Fg2.Rows.Count = 1
        Me.Fg2.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.Fg2.Size = New System.Drawing.Size(123, 524)
        Me.Fg2.StartCol = "WL_No"
        Me.Fg2.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("Fg2.Styles"))
        Me.Fg2.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.BelowData
        Me.Fg2.TabIndex = 33
        '
        'CMS_FG2
        '
        Me.CMS_FG2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SMI_AddEmployee, Me.SMI_DelEmployee})
        Me.CMS_FG2.Name = "CMS_FG2"
        Me.CMS_FG2.Size = New System.Drawing.Size(125, 48)
        '
        'SMI_AddEmployee
        '
        Me.SMI_AddEmployee.Name = "SMI_AddEmployee"
        Me.SMI_AddEmployee.Size = New System.Drawing.Size(124, 22)
        Me.SMI_AddEmployee.Text = "添加员工"
        '
        'SMI_DelEmployee
        '
        Me.SMI_DelEmployee.Name = "SMI_DelEmployee"
        Me.SMI_DelEmployee.Size = New System.Drawing.Size(124, 22)
        Me.SMI_DelEmployee.Text = "删除员工"
        '
        'Tab_PB
        '
        Me.Tab_PB.Controls.Add(Me.PeiBuList1)
        Me.Tab_PB.Location = New System.Drawing.Point(4, 24)
        Me.Tab_PB.Name = "Tab_PB"
        Me.Tab_PB.Padding = New System.Windows.Forms.Padding(3)
        Me.Tab_PB.Size = New System.Drawing.Size(1011, 584)
        Me.Tab_PB.TabIndex = 1
        Me.Tab_PB.Text = "配布"
        Me.Tab_PB.UseVisualStyleBackColor = True
        '
        'PeiBuList1
        '
        Me.PeiBuList1.BackColor = System.Drawing.Color.Transparent
        Me.PeiBuList1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PeiBuList1.Location = New System.Drawing.Point(3, 3)
        Me.PeiBuList1.Name = "PeiBuList1"
        Me.PeiBuList1.Size = New System.Drawing.Size(1005, 578)
        Me.PeiBuList1.TabIndex = 0
        '
        'Tp_DX
        '
        Me.Tp_DX.Location = New System.Drawing.Point(4, 24)
        Me.Tp_DX.Name = "Tp_DX"
        Me.Tp_DX.Padding = New System.Windows.Forms.Padding(3)
        Me.Tp_DX.Size = New System.Drawing.Size(1011, 584)
        Me.Tp_DX.TabIndex = 3
        Me.Tp_DX.Text = "定型部"
        Me.Tp_DX.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(609, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 14)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "客户编号:"
        Me.Label1.Visible = False
        '
        'LabelGH
        '
        Me.LabelGH.AutoSize = True
        Me.LabelGH.Location = New System.Drawing.Point(207, 8)
        Me.LabelGH.Margin = New System.Windows.Forms.Padding(3, 8, 3, 0)
        Me.LabelGH.Name = "LabelGH"
        Me.LabelGH.Size = New System.Drawing.Size(70, 14)
        Me.LabelGH.TabIndex = 54
        Me.LabelGH.Text = "相关单号:"
        '
        'CB_GH
        '
        Me.CB_GH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_GH.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.CB_GH.FormattingEnabled = True
        Me.CB_GH.Location = New System.Drawing.Point(283, 3)
        Me.CB_GH.Name = "CB_GH"
        Me.CB_GH.Size = New System.Drawing.Size(122, 24)
        Me.CB_GH.TabIndex = 55
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(411, 8)
        Me.Label30.Margin = New System.Windows.Forms.Padding(3, 8, 3, 0)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(70, 14)
        Me.Label30.TabIndex = 56
        Me.Label30.Text = "领料合计:"
        '
        'TB_SumAmount
        '
        Me.TB_SumAmount.Location = New System.Drawing.Point(487, 3)
        Me.TB_SumAmount.Name = "TB_SumAmount"
        Me.TB_SumAmount.ReadOnly = True
        Me.TB_SumAmount.Size = New System.Drawing.Size(92, 23)
        Me.TB_SumAmount.TabIndex = 57
        Me.TB_SumAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LabelFDFG
        '
        Me.LabelFDFG.AutoSize = True
        Me.LabelFDFG.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LabelFDFG.Font = New System.Drawing.Font("宋体", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LabelFDFG.ForeColor = System.Drawing.Color.Red
        Me.LabelFDFG.Location = New System.Drawing.Point(167, 5)
        Me.LabelFDFG.Name = "LabelFDFG"
        Me.LabelFDFG.Size = New System.Drawing.Size(75, 31)
        Me.LabelFDFG.TabIndex = 78
        Me.LabelFDFG.Text = "返定"
        '
        'FLP_Title
        '
        Me.FLP_Title.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FLP_Title.Controls.Add(Me.LabelTitle)
        Me.FLP_Title.Controls.Add(Me.Label15)
        Me.FLP_Title.Controls.Add(Me.LB_State)
        Me.FLP_Title.Controls.Add(Me.LabelFDFG)
        Me.FLP_Title.FlowDirection = System.Windows.Forms.FlowDirection.BottomUp
        Me.FLP_Title.Location = New System.Drawing.Point(2, 43)
        Me.FLP_Title.Name = "FLP_Title"
        Me.FLP_Title.Size = New System.Drawing.Size(445, 36)
        Me.FLP_Title.TabIndex = 79
        '
        'Process1
        '
        Me.Process1.StartInfo.Domain = ""
        Me.Process1.StartInfo.LoadUserProfile = False
        Me.Process1.StartInfo.Password = Nothing
        Me.Process1.StartInfo.StandardErrorEncoding = Nothing
        Me.Process1.StartInfo.StandardOutputEncoding = Nothing
        Me.Process1.StartInfo.UserName = ""
        Me.Process1.SynchronizingObject = Me
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlowLayoutPanel1.Controls.Add(Me.TB_ID)
        Me.FlowLayoutPanel1.Controls.Add(Me.LB_No)
        Me.FlowLayoutPanel1.Controls.Add(Me.TB_SumAmount)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label30)
        Me.FlowLayoutPanel1.Controls.Add(Me.CB_GH)
        Me.FlowLayoutPanel1.Controls.Add(Me.LabelGH)
        Me.FlowLayoutPanel1.Controls.Add(Me.CB_WorkList)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label31)
        Me.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(246, 43)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(772, 36)
        Me.FlowLayoutPanel1.TabIndex = 80
        '
        'CB_WorkList
        '
        Me.CB_WorkList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_WorkList.FormattingEnabled = True
        Me.CB_WorkList.Location = New System.Drawing.Point(103, 3)
        Me.CB_WorkList.Name = "CB_WorkList"
        Me.CB_WorkList.Size = New System.Drawing.Size(98, 22)
        Me.CB_WorkList.TabIndex = 58
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(27, 8)
        Me.Label31.Margin = New System.Windows.Forms.Padding(3, 8, 3, 0)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(70, 14)
        Me.Label31.TabIndex = 59
        Me.Label31.Text = "加工合集:"
        '
        'Employee_List1
        '
        Me.Employee_List1.BackColor = System.Drawing.Color.DodgerBlue
        Me.Employee_List1.IsShowAll = True
        Me.Employee_List1.IsTBLostFocusSelOne = True
        Me.Employee_List1.Location = New System.Drawing.Point(-721, -171)
        Me.Employee_List1.Name = "Employee_List1"
        Me.Employee_List1.SearchId = ""
        Me.Employee_List1.SearchType = BaseClass.Employee_List.ENum_SearchType.ALL
        Me.Employee_List1.Size = New System.Drawing.Size(250, 209)
        Me.Employee_List1.TabIndex = 51
        Me.Employee_List1.Visible = False
        '
        'ToolStripSearch1
        '
        Me.ToolStripSearch1.HideItemOnToolStrip = False
        Me.ToolStripSearch1.IsAddSearchBottom = True
        Me.ToolStripSearch1.IsNameChangeToData = False
        Me.ToolStripSearch1.ToolStrip = Nothing
        '
        'F30001_Produce_Gd_Msg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.AutoSize = True
        Me.CanMaxSize = True
        Me.Controls.Add(Me.Employee_List1)
        Me.Controls.Add(Me.FLP_Title)
        Me.Controls.Add(Me.Tool_Top)
        Me.Controls.Add(Me.Tabs)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.TB_GangCi)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.TB_ClientID)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Name = "F30001_Produce_Gd_Msg"
        Me.Size = New System.Drawing.Size(1024, 700)
        Me.Title = "运转单"
        Me.CKB_SG.ResumeLayout(False)
        Me.CKB_SG.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GB_ClientRequest.ResumeLayout(False)
        Me.GB_ClientRequest.PerformLayout()
        Me.Tool_Top.ResumeLayout(False)
        Me.Tool_Top.PerformLayout()
        Me.GB_Foot.ResumeLayout(False)
        Me.GB_Foot.PerformLayout()
        Me.Tabs.ResumeLayout(False)
        Me.Tab_Gd.ResumeLayout(False)
        Me.Tab_RB.ResumeLayout(False)
        Me.Tab_RB.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.Fg_Sel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.ResumeLayout(False)
        CType(Me.Fg1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Fg2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CMS_FG2.ResumeLayout(False)
        Me.Tab_PB.ResumeLayout(False)
        Me.FLP_Title.ResumeLayout(False)
        Me.FLP_Title.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents CKB_SG As System.Windows.Forms.GroupBox
    Friend WithEvents DP_Date_KaiDan As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TB_ShaPi As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TB_Remark As System.Windows.Forms.TextBox
    Friend WithEvents LB_Remark As System.Windows.Forms.Label
    Friend WithEvents TB_Address As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TB_ProcessType As System.Windows.Forms.TextBox
    Friend WithEvents LB_ProcessType As System.Windows.Forms.Label
    Friend WithEvents TB_GangCi As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TB_GangShu As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TB_TextileFatory As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TB_Contract As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TB_ClientID As System.Windows.Forms.TextBox
    Friend WithEvents CB_CR_SuoShuiJi As System.Windows.Forms.CheckBox
    Friend WithEvents CB_CR_PaoGan As System.Windows.Forms.CheckBox
    Friend WithEvents CB_CR_ShuangJiaoDai As System.Windows.Forms.CheckBox
    Friend WithEvents CB_CR_ShiCa As System.Windows.Forms.CheckBox
    Friend WithEvents CB_CR_DanXi As System.Windows.Forms.CheckBox
    Friend WithEvents CB_CR_DanMo As System.Windows.Forms.CheckBox
    Friend WithEvents CB_CR_KaiDing As System.Windows.Forms.CheckBox
    Friend WithEvents CB_CR_ShiMao As System.Windows.Forms.CheckBox
    Friend WithEvents CB_CR_KaiZhua As System.Windows.Forms.CheckBox
    Friend WithEvents CB_CR_QieBian As System.Windows.Forms.CheckBox
    Friend WithEvents CB_CR_GanCa As System.Windows.Forms.CheckBox
    Friend WithEvents CB_CR_JiangBian As System.Windows.Forms.CheckBox
    Friend WithEvents CB_CR_RiShai As System.Windows.Forms.CheckBox
    Friend WithEvents CB_CR_YinHuaYong As System.Windows.Forms.CheckBox
    Friend WithEvents CB_CR_ZhuangBaiSe As System.Windows.Forms.CheckBox
    Friend WithEvents TB_CR_KeZhong As System.Windows.Forms.TextBox
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents TB_HeRanGangHao As System.Windows.Forms.TextBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents TB_DuiSeGangHao As System.Windows.Forms.TextBox
    Friend WithEvents Label53 As System.Windows.Forms.Label
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents TB_BZName As System.Windows.Forms.TextBox
    Friend WithEvents TB_ClientName As System.Windows.Forms.TextBox
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents GB_ClientRequest As System.Windows.Forms.GroupBox
    Friend WithEvents TB_CR_NiuDu As System.Windows.Forms.TextBox
    Friend WithEvents TB_CR_XiLao As System.Windows.Forms.TextBox
    Friend WithEvents Tool_Top As System.Windows.Forms.ToolStrip
    Friend WithEvents Cmd_Modify As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_Del As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Cmd_Exit As System.Windows.Forms.ToolStripButton
    Friend WithEvents GB_Foot As System.Windows.Forms.GroupBox
    Friend WithEvents TB_ID As System.Windows.Forms.TextBox
    Friend WithEvents LB_No As System.Windows.Forms.Label
    Friend WithEvents TB_Auditor As System.Windows.Forms.TextBox
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents TB_GenDan As System.Windows.Forms.TextBox
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents TB_KaiDan As System.Windows.Forms.TextBox
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents Label84 As System.Windows.Forms.Label
    Friend WithEvents TB_PB_CountSum As System.Windows.Forms.TextBox
    Friend WithEvents Label85 As System.Windows.Forms.Label
    Friend WithEvents TB_PB_ZLSum As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents TB_BZCName As System.Windows.Forms.TextBox
    Friend WithEvents Cmd_ChooseRemark As System.Windows.Forms.Button
    Friend WithEvents TB_CR_BianDuiBian As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents TB_CR_ShiYong As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents TB_CR_ChengYiXiShui As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents TB_CR_ZhiSuo As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents TB_CR_HengSuo As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Cmd_Preview As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_Print As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Employee_List1 As BaseClass.Employee_List
    Friend WithEvents TB_CR_LuoSeBzCount As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents LB_State As System.Windows.Forms.Label
    Friend WithEvents TB_JiaZhong As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents TB_ZhiTong As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents DP_Date_JiaoHuo As System.Windows.Forms.DateTimePicker
    Friend WithEvents DP_Date_LuoSe As System.Windows.Forms.DateTimePicker
    Friend WithEvents DP_Date_ShouPei As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents LabelTitle As System.Windows.Forms.Label
    Friend WithEvents Radio_ZL As System.Windows.Forms.RadioButton
    Friend WithEvents Radio_Num As System.Windows.Forms.RadioButton
    Friend WithEvents TB_CR_LuoSeBzZL As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Tabs As System.Windows.Forms.TabControl
    Friend WithEvents Tab_Gd As System.Windows.Forms.TabPage
    Friend WithEvents Tab_PB As System.Windows.Forms.TabPage
    Friend WithEvents Tab_RB As System.Windows.Forms.TabPage
    Friend WithEvents Tp_DX As System.Windows.Forms.TabPage
    Friend WithEvents PeiBuList1 As PeiBuList
    Friend WithEvents Cmd_Invalid As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_SetValid As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents LB_OrderBill As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TB_ClientBZC As System.Windows.Forms.TextBox
    Friend WithEvents Label_ID As System.Windows.Forms.Label
    Friend WithEvents Cmd_CG As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents CB_BZC_PF As System.Windows.Forms.ComboBox
    Friend WithEvents Cmd_AddBZ As System.Windows.Forms.Button
    Friend WithEvents Cmd_Copy As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_BZName As System.Windows.Forms.Button
    Friend WithEvents Cmd_BZCName As System.Windows.Forms.Button
    Friend WithEvents TB_ClothStore As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Cmd_BZNo As System.Windows.Forms.Button
    Friend WithEvents LabelGH As System.Windows.Forms.Label
    Friend WithEvents CB_GH As System.Windows.Forms.ComboBox
    Friend WithEvents Cb_BZC As BaseClass.ComBoList
    Friend WithEvents CB_BZ As BaseClass.ComBoList
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents TB_SumAmount As System.Windows.Forms.TextBox
    Friend WithEvents Cmd_ShowList As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Cmd_FG As System.Windows.Forms.ToolStripButton
    Friend WithEvents LabelFDFG As System.Windows.Forms.Label
    Friend WithEvents FLP_Title As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Cmd_ChangePB As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_ChangeColor As System.Windows.Forms.ToolStripButton
    Friend WithEvents Fg1 As PClass.FG
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents Cmd_WorkList As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_AddRowBefore As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_AddRowAfter As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_RemoveRow As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Cmd_UP As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_Down As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Fg_Sel As PClass.FG
    Friend WithEvents Cmd_Show As System.Windows.Forms.ToolStripButton
    Friend WithEvents Process1 As System.Diagnostics.Process
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents Fg2 As PClass.FG
    Friend WithEvents Cmd_Edit As System.Windows.Forms.ToolStripButton
    Friend WithEvents CMS_FG2 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents SMI_AddEmployee As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SMI_DelEmployee As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CB_State As System.Windows.Forms.ComboBox
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents CB_WorkList As System.Windows.Forms.ComboBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Cmd_WorkList_Save As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_ClearAll As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_HG As System.Windows.Forms.ToolStripButton
    Friend WithEvents CKB_IsChangeToBlack As System.Windows.Forms.CheckBox
    Friend WithEvents CB_CPName As System.Windows.Forms.CheckBox
    Friend WithEvents TB_CPName As System.Windows.Forms.TextBox
    Friend WithEvents LB_CGRemark As System.Windows.Forms.Label
    Friend WithEvents TB_CGRemark As System.Windows.Forms.TextBox
    Friend WithEvents TB_UPD_USER As BaseClass.GH_BillLog
    Friend WithEvents ToolStripSearch1 As BaseClass.ToolStripSearch
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents CB_SG As BaseClass.ComBoList
    Friend WithEvents CB_Color As System.Windows.Forms.ComboBox
    Friend WithEvents TB_SGName As System.Windows.Forms.TextBox
    Friend WithEvents Label33 As System.Windows.Forms.Label

End Class
