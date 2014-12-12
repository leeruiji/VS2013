<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F15501_AtMachine_Msg
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F15501_AtMachine_Msg))
        Me.Tool_Top = New System.Windows.Forms.ToolStrip
        Me.Cmd_Modify = New System.Windows.Forms.ToolStripButton
        Me.Cmd_Del = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.Cmd_DataIn = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.Cmd_GetTime = New System.Windows.Forms.ToolStripButton
        Me.Cmd_SetTime = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.Cmd_Exit = New System.Windows.Forms.ToolStripButton
        Me.PanelMain = New System.Windows.Forms.Panel
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.TabpageSet = New PClass.CustomTabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.Cmd_SetModeDefault = New System.Windows.Forms.Button
        Me.Cmd_ReadMode = New System.Windows.Forms.Button
        Me.Cmd_SetMode = New System.Windows.Forms.Button
        Me.GB_Mode = New System.Windows.Forms.GroupBox
        Me.PL_RepeatClockerTime = New System.Windows.Forms.Panel
        Me.Cmd_SetRepeatClockerTime = New System.Windows.Forms.Button
        Me.ND_RepeatClockerTime = New System.Windows.Forms.NumericUpDown
        Me.Label20 = New System.Windows.Forms.Label
        Me.CB_Mode_7 = New System.Windows.Forms.CheckBox
        Me.CB_Mode_6 = New System.Windows.Forms.CheckBox
        Me.CB_Mode_54 = New System.Windows.Forms.ComboBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.CB_Mode_3 = New System.Windows.Forms.CheckBox
        Me.CB_Mode_210 = New System.Windows.Forms.ComboBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.TabPage4 = New System.Windows.Forms.TabPage
        Me.Cmd_SetExtraModeDefault = New System.Windows.Forms.Button
        Me.Cmd_ReadExtraMode = New System.Windows.Forms.Button
        Me.Cmd_SetExtraMode = New System.Windows.Forms.Button
        Me.GB_ExtraMode = New System.Windows.Forms.GroupBox
        Me.CB_ExtraMode_2 = New System.Windows.Forms.CheckBox
        Me.CB_ExtraMode_765 = New System.Windows.Forms.ComboBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.CB_ExtraMode_4 = New System.Windows.Forms.CheckBox
        Me.CB_ExtraMode_3 = New System.Windows.Forms.CheckBox
        Me.CB_ExtraMode_1 = New System.Windows.Forms.CheckBox
        Me.CB_ExtraMode_0 = New System.Windows.Forms.CheckBox
        Me.TabPage5 = New System.Windows.Forms.TabPage
        Me.Cmd_SetSystemModeDefault = New System.Windows.Forms.Button
        Me.Cmd_ReadSystemMode = New System.Windows.Forms.Button
        Me.Cmd_SetSystemMode = New System.Windows.Forms.Button
        Me.GB_SystemMode = New System.Windows.Forms.GroupBox
        Me.CB_SystemMode_7 = New System.Windows.Forms.CheckBox
        Me.CB_SystemMode_6 = New System.Windows.Forms.CheckBox
        Me.CB_SystemMode_5 = New System.Windows.Forms.CheckBox
        Me.CB_SystemMode_4 = New System.Windows.Forms.CheckBox
        Me.CB_SystemMode_3 = New System.Windows.Forms.CheckBox
        Me.CB_SystemMode_2 = New System.Windows.Forms.CheckBox
        Me.CB_SystemMode_1 = New System.Windows.Forms.CheckBox
        Me.CB_SystemMode_0 = New System.Windows.Forms.CheckBox
        Me.TabPage6 = New System.Windows.Forms.TabPage
        Me.Cmd_SetRingModeDefault = New System.Windows.Forms.Button
        Me.Cmd_ReadRingMode = New System.Windows.Forms.Button
        Me.Cmd_SetRingMode = New System.Windows.Forms.Button
        Me.GB_RingMode = New System.Windows.Forms.GroupBox
        Me.CB_RingMode_5 = New System.Windows.Forms.CheckBox
        Me.CB_RingMode_3 = New System.Windows.Forms.CheckBox
        Me.CB_RingMode_4 = New System.Windows.Forms.CheckBox
        Me.CB_RingMode_1 = New System.Windows.Forms.CheckBox
        Me.CB_RingMode_2 = New System.Windows.Forms.CheckBox
        Me.CB_RingMode_0 = New System.Windows.Forms.CheckBox
        Me.CB_RingMode_76 = New System.Windows.Forms.ComboBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.Cmd_SetFirstWindowDispString = New System.Windows.Forms.Button
        Me.Label8 = New System.Windows.Forms.Label
        Me.TB_SetFirstWindowDispString = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.Cmd_SetClockNormalMessage = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.TB_SetClockNormalMessage = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.Label25 = New System.Windows.Forms.Label
        Me.Cmd_SetManagerCard = New System.Windows.Forms.Button
        Me.TB_ManagerCard = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.TB_Remark = New System.Windows.Forms.TextBox
        Me.TB_Port = New System.Windows.Forms.TextBox
        Me.TB_IP = New System.Windows.Forms.TextBox
        Me.TB_Name = New System.Windows.Forms.TextBox
        Me.TB_ID = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.DP_Found_Date = New System.Windows.Forms.DateTimePicker
        Me.DP_UPD_DATE = New System.Windows.Forms.DateTimePicker
        Me.TB_Founder = New System.Windows.Forms.TextBox
        Me.TB_UPD_USER = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.BW = New System.ComponentModel.BackgroundWorker
        Me.LabelMsg = New System.Windows.Forms.Label
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.Pic_From = New System.Windows.Forms.Panel
        Me.Tool_Top.SuspendLayout()
        Me.PanelMain.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabpageSet.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GB_Mode.SuspendLayout()
        Me.PL_RepeatClockerTime.SuspendLayout()
        CType(Me.ND_RepeatClockerTime, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage4.SuspendLayout()
        Me.GB_ExtraMode.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        Me.GB_SystemMode.SuspendLayout()
        Me.TabPage6.SuspendLayout()
        Me.GB_RingMode.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.Pic_From.SuspendLayout()
        Me.SuspendLayout()
        '
        'Tool_Top
        '
        Me.Tool_Top.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.Tool_Top.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Cmd_Modify, Me.Cmd_Del, Me.ToolStripSeparator1, Me.Cmd_DataIn, Me.ToolStripSeparator3, Me.Cmd_GetTime, Me.Cmd_SetTime, Me.ToolStripSeparator5, Me.Cmd_Exit})
        Me.Tool_Top.Location = New System.Drawing.Point(0, 0)
        Me.Tool_Top.MinimumSize = New System.Drawing.Size(0, 58)
        Me.Tool_Top.Name = "Tool_Top"
        Me.Tool_Top.Size = New System.Drawing.Size(646, 58)
        Me.Tool_Top.TabIndex = 10
        Me.Tool_Top.Text = "ToolStrip2"
        '
        'Cmd_Modify
        '
        Me.Cmd_Modify.AccessibleDescription = "修改按钮"
        Me.Cmd_Modify.AccessibleName = ""
        Me.Cmd_Modify.Image = Global.DN155_AtMachine.My.Resources.Resources.Modify
        Me.Cmd_Modify.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Modify.Name = "Cmd_Modify"
        Me.Cmd_Modify.Size = New System.Drawing.Size(33, 55)
        Me.Cmd_Modify.Text = "保存"
        Me.Cmd_Modify.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'Cmd_Del
        '
        Me.Cmd_Del.AccessibleDescription = "修改按钮"
        Me.Cmd_Del.AccessibleName = ""
        Me.Cmd_Del.Image = Global.DN155_AtMachine.My.Resources.Resources.Delete
        Me.Cmd_Del.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Del.Name = "Cmd_Del"
        Me.Cmd_Del.Size = New System.Drawing.Size(33, 55)
        Me.Cmd_Del.Text = "删除"
        Me.Cmd_Del.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 58)
        '
        'Cmd_DataIn
        '
        Me.Cmd_DataIn.Image = CType(resources.GetObject("Cmd_DataIn.Image"), System.Drawing.Image)
        Me.Cmd_DataIn.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_DataIn.Name = "Cmd_DataIn"
        Me.Cmd_DataIn.Size = New System.Drawing.Size(57, 55)
        Me.Cmd_DataIn.Text = "数据采集"
        Me.Cmd_DataIn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 58)
        '
        'Cmd_GetTime
        '
        Me.Cmd_GetTime.Image = Global.DN155_AtMachine.My.Resources.Resources.Time
        Me.Cmd_GetTime.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_GetTime.Name = "Cmd_GetTime"
        Me.Cmd_GetTime.Size = New System.Drawing.Size(57, 55)
        Me.Cmd_GetTime.Text = "获取时间"
        Me.Cmd_GetTime.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'Cmd_SetTime
        '
        Me.Cmd_SetTime.Image = Global.DN155_AtMachine.My.Resources.Resources.Time2
        Me.Cmd_SetTime.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_SetTime.Name = "Cmd_SetTime"
        Me.Cmd_SetTime.Size = New System.Drawing.Size(57, 55)
        Me.Cmd_SetTime.Text = "设置时间"
        Me.Cmd_SetTime.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 58)
        '
        'Cmd_Exit
        '
        Me.Cmd_Exit.Image = Global.DN155_AtMachine.My.Resources.Resources.Close
        Me.Cmd_Exit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(33, 55)
        Me.Cmd_Exit.Text = "关闭"
        Me.Cmd_Exit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'PanelMain
        '
        Me.PanelMain.Controls.Add(Me.GroupBox1)
        Me.PanelMain.Controls.Add(Me.Label7)
        Me.PanelMain.Controls.Add(Me.Label9)
        Me.PanelMain.Controls.Add(Me.TB_Remark)
        Me.PanelMain.Controls.Add(Me.TB_Port)
        Me.PanelMain.Controls.Add(Me.TB_IP)
        Me.PanelMain.Controls.Add(Me.TB_Name)
        Me.PanelMain.Controls.Add(Me.TB_ID)
        Me.PanelMain.Controls.Add(Me.Label10)
        Me.PanelMain.Controls.Add(Me.Label11)
        Me.PanelMain.Controls.Add(Me.Label12)
        Me.PanelMain.Controls.Add(Me.Label13)
        Me.PanelMain.Controls.Add(Me.DP_Found_Date)
        Me.PanelMain.Controls.Add(Me.DP_UPD_DATE)
        Me.PanelMain.Controls.Add(Me.TB_Founder)
        Me.PanelMain.Controls.Add(Me.TB_UPD_USER)
        Me.PanelMain.Controls.Add(Me.Label6)
        Me.PanelMain.Controls.Add(Me.Label23)
        Me.PanelMain.Controls.Add(Me.Label5)
        Me.PanelMain.Controls.Add(Me.Label22)
        Me.PanelMain.Controls.Add(Me.Label3)
        Me.PanelMain.Controls.Add(Me.Label21)
        Me.PanelMain.Controls.Add(Me.Label2)
        Me.PanelMain.Controls.Add(Me.Label18)
        Me.PanelMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelMain.Location = New System.Drawing.Point(0, 58)
        Me.PanelMain.Name = "PanelMain"
        Me.PanelMain.Padding = New System.Windows.Forms.Padding(2)
        Me.PanelMain.Size = New System.Drawing.Size(646, 485)
        Me.PanelMain.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TabpageSet)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 134)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(610, 244)
        Me.GroupBox1.TabIndex = 30
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "具体参数设置"
        '
        'TabpageSet
        '
        Me.TabpageSet.BackColor_MouseOnSelect = System.Drawing.Color.Orange
        Me.TabpageSet.BackColor_NotSelect = System.Drawing.Color.Cyan
        Me.TabpageSet.Controls.Add(Me.TabPage1)
        Me.TabpageSet.Controls.Add(Me.TabPage4)
        Me.TabpageSet.Controls.Add(Me.TabPage5)
        Me.TabpageSet.Controls.Add(Me.TabPage6)
        Me.TabpageSet.Controls.Add(Me.TabPage2)
        Me.TabpageSet.Controls.Add(Me.TabPage3)
        Me.TabpageSet.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TabpageSet.ItemSize = New System.Drawing.Size(0, 18)
        Me.TabpageSet.Location = New System.Drawing.Point(6, 22)
        Me.TabpageSet.Name = "TabpageSet"
        Me.TabpageSet.Padding = New System.Drawing.Point(10, 0)
        Me.TabpageSet.SelectedIndex = 0
        Me.TabpageSet.Size = New System.Drawing.Size(593, 216)
        Me.TabpageSet.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Cmd_SetModeDefault)
        Me.TabPage1.Controls.Add(Me.Cmd_ReadMode)
        Me.TabPage1.Controls.Add(Me.Cmd_SetMode)
        Me.TabPage1.Controls.Add(Me.GB_Mode)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(585, 190)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "工作模式"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Cmd_SetModeDefault
        '
        Me.Cmd_SetModeDefault.Enabled = False
        Me.Cmd_SetModeDefault.Location = New System.Drawing.Point(495, 104)
        Me.Cmd_SetModeDefault.Name = "Cmd_SetModeDefault"
        Me.Cmd_SetModeDefault.Size = New System.Drawing.Size(84, 29)
        Me.Cmd_SetModeDefault.TabIndex = 29
        Me.Cmd_SetModeDefault.Text = "推荐设置"
        Me.Cmd_SetModeDefault.UseVisualStyleBackColor = True
        '
        'Cmd_ReadMode
        '
        Me.Cmd_ReadMode.Location = New System.Drawing.Point(495, 14)
        Me.Cmd_ReadMode.Name = "Cmd_ReadMode"
        Me.Cmd_ReadMode.Size = New System.Drawing.Size(84, 29)
        Me.Cmd_ReadMode.TabIndex = 28
        Me.Cmd_ReadMode.Text = "获取"
        Me.Cmd_ReadMode.UseVisualStyleBackColor = True
        '
        'Cmd_SetMode
        '
        Me.Cmd_SetMode.Enabled = False
        Me.Cmd_SetMode.Location = New System.Drawing.Point(495, 59)
        Me.Cmd_SetMode.Name = "Cmd_SetMode"
        Me.Cmd_SetMode.Size = New System.Drawing.Size(84, 29)
        Me.Cmd_SetMode.TabIndex = 27
        Me.Cmd_SetMode.Text = "设置"
        Me.Cmd_SetMode.UseVisualStyleBackColor = True
        '
        'GB_Mode
        '
        Me.GB_Mode.Controls.Add(Me.PL_RepeatClockerTime)
        Me.GB_Mode.Controls.Add(Me.CB_Mode_7)
        Me.GB_Mode.Controls.Add(Me.CB_Mode_6)
        Me.GB_Mode.Controls.Add(Me.CB_Mode_54)
        Me.GB_Mode.Controls.Add(Me.Label17)
        Me.GB_Mode.Controls.Add(Me.CB_Mode_3)
        Me.GB_Mode.Controls.Add(Me.CB_Mode_210)
        Me.GB_Mode.Controls.Add(Me.Label15)
        Me.GB_Mode.Dock = System.Windows.Forms.DockStyle.Left
        Me.GB_Mode.Enabled = False
        Me.GB_Mode.Location = New System.Drawing.Point(3, 3)
        Me.GB_Mode.Name = "GB_Mode"
        Me.GB_Mode.Size = New System.Drawing.Size(486, 184)
        Me.GB_Mode.TabIndex = 1
        Me.GB_Mode.TabStop = False
        '
        'PL_RepeatClockerTime
        '
        Me.PL_RepeatClockerTime.Controls.Add(Me.Cmd_SetRepeatClockerTime)
        Me.PL_RepeatClockerTime.Controls.Add(Me.ND_RepeatClockerTime)
        Me.PL_RepeatClockerTime.Controls.Add(Me.Label20)
        Me.PL_RepeatClockerTime.Enabled = False
        Me.PL_RepeatClockerTime.Location = New System.Drawing.Point(138, 19)
        Me.PL_RepeatClockerTime.Name = "PL_RepeatClockerTime"
        Me.PL_RepeatClockerTime.Size = New System.Drawing.Size(290, 30)
        Me.PL_RepeatClockerTime.TabIndex = 12
        '
        'Cmd_SetRepeatClockerTime
        '
        Me.Cmd_SetRepeatClockerTime.Location = New System.Drawing.Point(172, 2)
        Me.Cmd_SetRepeatClockerTime.Name = "Cmd_SetRepeatClockerTime"
        Me.Cmd_SetRepeatClockerTime.Size = New System.Drawing.Size(107, 23)
        Me.Cmd_SetRepeatClockerTime.TabIndex = 11
        Me.Cmd_SetRepeatClockerTime.Text = "设置打卡间隔"
        Me.Cmd_SetRepeatClockerTime.UseVisualStyleBackColor = True
        '
        'ND_RepeatClockerTime
        '
        Me.ND_RepeatClockerTime.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.ND_RepeatClockerTime.Location = New System.Drawing.Point(115, 2)
        Me.ND_RepeatClockerTime.Maximum = New Decimal(New Integer() {999, 0, 0, 0})
        Me.ND_RepeatClockerTime.Name = "ND_RepeatClockerTime"
        Me.ND_RepeatClockerTime.Size = New System.Drawing.Size(51, 23)
        Me.ND_RepeatClockerTime.TabIndex = 10
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(11, 4)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(98, 14)
        Me.Label20.TabIndex = 9
        Me.Label20.Text = "重复刷卡间隔:"
        '
        'CB_Mode_7
        '
        Me.CB_Mode_7.AutoSize = True
        Me.CB_Mode_7.Location = New System.Drawing.Point(6, 88)
        Me.CB_Mode_7.Name = "CB_Mode_7"
        Me.CB_Mode_7.Size = New System.Drawing.Size(306, 18)
        Me.CB_Mode_7.TabIndex = 7
        Me.CB_Mode_7.Text = "记录存贮满后循环存贮，新记录覆盖最旧记录"
        Me.CB_Mode_7.UseVisualStyleBackColor = True
        '
        'CB_Mode_6
        '
        Me.CB_Mode_6.AutoSize = True
        Me.CB_Mode_6.Location = New System.Drawing.Point(6, 22)
        Me.CB_Mode_6.Name = "CB_Mode_6"
        Me.CB_Mode_6.Size = New System.Drawing.Size(110, 18)
        Me.CB_Mode_6.TabIndex = 6
        Me.CB_Mode_6.Text = "禁止重复刷卡"
        Me.CB_Mode_6.UseVisualStyleBackColor = True
        '
        'CB_Mode_54
        '
        Me.CB_Mode_54.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_Mode_54.FormattingEnabled = True
        Me.CB_Mode_54.Location = New System.Drawing.Point(80, 118)
        Me.CB_Mode_54.Name = "CB_Mode_54"
        Me.CB_Mode_54.Size = New System.Drawing.Size(232, 22)
        Me.CB_Mode_54.TabIndex = 5
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(6, 121)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(70, 14)
        Me.Label17.TabIndex = 4
        Me.Label17.Text = "铃声模式:"
        '
        'CB_Mode_3
        '
        Me.CB_Mode_3.AutoSize = True
        Me.CB_Mode_3.Location = New System.Drawing.Point(6, 55)
        Me.CB_Mode_3.Name = "CB_Mode_3"
        Me.CB_Mode_3.Size = New System.Drawing.Size(208, 18)
        Me.CB_Mode_3.TabIndex = 3
        Me.CB_Mode_3.Text = "非允许时段刷卡记录存贮记录"
        Me.CB_Mode_3.UseVisualStyleBackColor = True
        '
        'CB_Mode_210
        '
        Me.CB_Mode_210.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_Mode_210.FormattingEnabled = True
        Me.CB_Mode_210.Location = New System.Drawing.Point(80, 146)
        Me.CB_Mode_210.Name = "CB_Mode_210"
        Me.CB_Mode_210.Size = New System.Drawing.Size(232, 22)
        Me.CB_Mode_210.TabIndex = 1
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(4, 150)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(70, 14)
        Me.Label15.TabIndex = 0
        Me.Label15.Text = "机器作用:"
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.Cmd_SetExtraModeDefault)
        Me.TabPage4.Controls.Add(Me.Cmd_ReadExtraMode)
        Me.TabPage4.Controls.Add(Me.Cmd_SetExtraMode)
        Me.TabPage4.Controls.Add(Me.GB_ExtraMode)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(585, 190)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "扩展模式"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'Cmd_SetExtraModeDefault
        '
        Me.Cmd_SetExtraModeDefault.Enabled = False
        Me.Cmd_SetExtraModeDefault.Location = New System.Drawing.Point(495, 104)
        Me.Cmd_SetExtraModeDefault.Name = "Cmd_SetExtraModeDefault"
        Me.Cmd_SetExtraModeDefault.Size = New System.Drawing.Size(84, 29)
        Me.Cmd_SetExtraModeDefault.TabIndex = 32
        Me.Cmd_SetExtraModeDefault.Text = "推荐设置"
        Me.Cmd_SetExtraModeDefault.UseVisualStyleBackColor = True
        '
        'Cmd_ReadExtraMode
        '
        Me.Cmd_ReadExtraMode.Location = New System.Drawing.Point(495, 14)
        Me.Cmd_ReadExtraMode.Name = "Cmd_ReadExtraMode"
        Me.Cmd_ReadExtraMode.Size = New System.Drawing.Size(84, 29)
        Me.Cmd_ReadExtraMode.TabIndex = 31
        Me.Cmd_ReadExtraMode.Text = "获取"
        Me.Cmd_ReadExtraMode.UseVisualStyleBackColor = True
        '
        'Cmd_SetExtraMode
        '
        Me.Cmd_SetExtraMode.Enabled = False
        Me.Cmd_SetExtraMode.Location = New System.Drawing.Point(495, 59)
        Me.Cmd_SetExtraMode.Name = "Cmd_SetExtraMode"
        Me.Cmd_SetExtraMode.Size = New System.Drawing.Size(84, 29)
        Me.Cmd_SetExtraMode.TabIndex = 30
        Me.Cmd_SetExtraMode.Text = "设置"
        Me.Cmd_SetExtraMode.UseVisualStyleBackColor = True
        '
        'GB_ExtraMode
        '
        Me.GB_ExtraMode.Controls.Add(Me.CB_ExtraMode_2)
        Me.GB_ExtraMode.Controls.Add(Me.CB_ExtraMode_765)
        Me.GB_ExtraMode.Controls.Add(Me.Label19)
        Me.GB_ExtraMode.Controls.Add(Me.CB_ExtraMode_4)
        Me.GB_ExtraMode.Controls.Add(Me.CB_ExtraMode_3)
        Me.GB_ExtraMode.Controls.Add(Me.CB_ExtraMode_1)
        Me.GB_ExtraMode.Controls.Add(Me.CB_ExtraMode_0)
        Me.GB_ExtraMode.Dock = System.Windows.Forms.DockStyle.Left
        Me.GB_ExtraMode.Enabled = False
        Me.GB_ExtraMode.Location = New System.Drawing.Point(3, 3)
        Me.GB_ExtraMode.Name = "GB_ExtraMode"
        Me.GB_ExtraMode.Size = New System.Drawing.Size(486, 184)
        Me.GB_ExtraMode.TabIndex = 0
        Me.GB_ExtraMode.TabStop = False
        '
        'CB_ExtraMode_2
        '
        Me.CB_ExtraMode_2.AutoSize = True
        Me.CB_ExtraMode_2.Location = New System.Drawing.Point(6, 74)
        Me.CB_ExtraMode_2.Name = "CB_ExtraMode_2"
        Me.CB_ExtraMode_2.Size = New System.Drawing.Size(376, 18)
        Me.CB_ExtraMode_2.TabIndex = 12
        Me.CB_ExtraMode_2.Text = "门禁通行判断时，检查刷卡卡号是否为黑名单，是则报警"
        Me.CB_ExtraMode_2.UseVisualStyleBackColor = True
        '
        'CB_ExtraMode_765
        '
        Me.CB_ExtraMode_765.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_ExtraMode_765.FormattingEnabled = True
        Me.CB_ExtraMode_765.Location = New System.Drawing.Point(83, 155)
        Me.CB_ExtraMode_765.Name = "CB_ExtraMode_765"
        Me.CB_ExtraMode_765.Size = New System.Drawing.Size(355, 22)
        Me.CB_ExtraMode_765.TabIndex = 11
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(7, 158)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(70, 14)
        Me.Label19.TabIndex = 10
        Me.Label19.Text = "机器作用:"
        '
        'CB_ExtraMode_4
        '
        Me.CB_ExtraMode_4.AutoSize = True
        Me.CB_ExtraMode_4.Location = New System.Drawing.Point(6, 126)
        Me.CB_ExtraMode_4.Name = "CB_ExtraMode_4"
        Me.CB_ExtraMode_4.Size = New System.Drawing.Size(432, 18)
        Me.CB_ExtraMode_4.TabIndex = 9
        Me.CB_ExtraMode_4.Text = "门禁通行时需要检查刷卡卡号是否在门禁通行名单中，不是则报警"
        Me.CB_ExtraMode_4.UseVisualStyleBackColor = True
        '
        'CB_ExtraMode_3
        '
        Me.CB_ExtraMode_3.AutoSize = True
        Me.CB_ExtraMode_3.Location = New System.Drawing.Point(6, 100)
        Me.CB_ExtraMode_3.Name = "CB_ExtraMode_3"
        Me.CB_ExtraMode_3.Size = New System.Drawing.Size(460, 18)
        Me.CB_ExtraMode_3.TabIndex = 8
        Me.CB_ExtraMode_3.Text = "IC卡刷卡时检查卡片上的组别信息是否与机具组别匹配，不匹配则报警"
        Me.CB_ExtraMode_3.UseVisualStyleBackColor = True
        '
        'CB_ExtraMode_1
        '
        Me.CB_ExtraMode_1.AutoSize = True
        Me.CB_ExtraMode_1.Location = New System.Drawing.Point(6, 48)
        Me.CB_ExtraMode_1.Name = "CB_ExtraMode_1"
        Me.CB_ExtraMode_1.Size = New System.Drawing.Size(348, 18)
        Me.CB_ExtraMode_1.TabIndex = 7
        Me.CB_ExtraMode_1.Text = "考勤时检查刷卡卡号是否在考勤黑名单中，是则报警"
        Me.CB_ExtraMode_1.UseVisualStyleBackColor = True
        '
        'CB_ExtraMode_0
        '
        Me.CB_ExtraMode_0.AutoSize = True
        Me.CB_ExtraMode_0.Location = New System.Drawing.Point(6, 22)
        Me.CB_ExtraMode_0.Name = "CB_ExtraMode_0"
        Me.CB_ExtraMode_0.Size = New System.Drawing.Size(320, 18)
        Me.CB_ExtraMode_0.TabIndex = 6
        Me.CB_ExtraMode_0.Text = "检查刷卡卡号是否在考勤白名单中，不是则报警"
        Me.CB_ExtraMode_0.UseVisualStyleBackColor = True
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.Cmd_SetSystemModeDefault)
        Me.TabPage5.Controls.Add(Me.Cmd_ReadSystemMode)
        Me.TabPage5.Controls.Add(Me.Cmd_SetSystemMode)
        Me.TabPage5.Controls.Add(Me.GB_SystemMode)
        Me.TabPage5.Location = New System.Drawing.Point(4, 22)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage5.Size = New System.Drawing.Size(585, 190)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "系统模式"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'Cmd_SetSystemModeDefault
        '
        Me.Cmd_SetSystemModeDefault.Enabled = False
        Me.Cmd_SetSystemModeDefault.Location = New System.Drawing.Point(496, 104)
        Me.Cmd_SetSystemModeDefault.Name = "Cmd_SetSystemModeDefault"
        Me.Cmd_SetSystemModeDefault.Size = New System.Drawing.Size(84, 29)
        Me.Cmd_SetSystemModeDefault.TabIndex = 36
        Me.Cmd_SetSystemModeDefault.Text = "推荐设置"
        Me.Cmd_SetSystemModeDefault.UseVisualStyleBackColor = True
        '
        'Cmd_ReadSystemMode
        '
        Me.Cmd_ReadSystemMode.Location = New System.Drawing.Point(496, 14)
        Me.Cmd_ReadSystemMode.Name = "Cmd_ReadSystemMode"
        Me.Cmd_ReadSystemMode.Size = New System.Drawing.Size(84, 29)
        Me.Cmd_ReadSystemMode.TabIndex = 35
        Me.Cmd_ReadSystemMode.Text = "获取"
        Me.Cmd_ReadSystemMode.UseVisualStyleBackColor = True
        '
        'Cmd_SetSystemMode
        '
        Me.Cmd_SetSystemMode.Enabled = False
        Me.Cmd_SetSystemMode.Location = New System.Drawing.Point(496, 59)
        Me.Cmd_SetSystemMode.Name = "Cmd_SetSystemMode"
        Me.Cmd_SetSystemMode.Size = New System.Drawing.Size(84, 29)
        Me.Cmd_SetSystemMode.TabIndex = 34
        Me.Cmd_SetSystemMode.Text = "设置"
        Me.Cmd_SetSystemMode.UseVisualStyleBackColor = True
        '
        'GB_SystemMode
        '
        Me.GB_SystemMode.Controls.Add(Me.CB_SystemMode_7)
        Me.GB_SystemMode.Controls.Add(Me.CB_SystemMode_6)
        Me.GB_SystemMode.Controls.Add(Me.CB_SystemMode_5)
        Me.GB_SystemMode.Controls.Add(Me.CB_SystemMode_4)
        Me.GB_SystemMode.Controls.Add(Me.CB_SystemMode_3)
        Me.GB_SystemMode.Controls.Add(Me.CB_SystemMode_2)
        Me.GB_SystemMode.Controls.Add(Me.CB_SystemMode_1)
        Me.GB_SystemMode.Controls.Add(Me.CB_SystemMode_0)
        Me.GB_SystemMode.Dock = System.Windows.Forms.DockStyle.Left
        Me.GB_SystemMode.Enabled = False
        Me.GB_SystemMode.Location = New System.Drawing.Point(3, 3)
        Me.GB_SystemMode.Name = "GB_SystemMode"
        Me.GB_SystemMode.Size = New System.Drawing.Size(486, 184)
        Me.GB_SystemMode.TabIndex = 33
        Me.GB_SystemMode.TabStop = False
        '
        'CB_SystemMode_7
        '
        Me.CB_SystemMode_7.AutoSize = True
        Me.CB_SystemMode_7.Location = New System.Drawing.Point(6, 161)
        Me.CB_SystemMode_7.Name = "CB_SystemMode_7"
        Me.CB_SystemMode_7.Size = New System.Drawing.Size(278, 18)
        Me.CB_SystemMode_7.TabIndex = 13
        Me.CB_SystemMode_7.Text = "考勤时分时段刷卡，非允许时段刷卡报警"
        Me.CB_SystemMode_7.UseVisualStyleBackColor = True
        '
        'CB_SystemMode_6
        '
        Me.CB_SystemMode_6.AutoSize = True
        Me.CB_SystemMode_6.Location = New System.Drawing.Point(6, 132)
        Me.CB_SystemMode_6.Name = "CB_SystemMode_6"
        Me.CB_SystemMode_6.Size = New System.Drawing.Size(292, 18)
        Me.CB_SystemMode_6.TabIndex = 12
        Me.CB_SystemMode_6.Text = "门禁通行后存贮该卡的通行记录，以备查验"
        Me.CB_SystemMode_6.UseVisualStyleBackColor = True
        '
        'CB_SystemMode_5
        '
        Me.CB_SystemMode_5.AutoSize = True
        Me.CB_SystemMode_5.Location = New System.Drawing.Point(6, 103)
        Me.CB_SystemMode_5.Name = "CB_SystemMode_5"
        Me.CB_SystemMode_5.Size = New System.Drawing.Size(362, 18)
        Me.CB_SystemMode_5.TabIndex = 11
        Me.CB_SystemMode_5.Text = "门禁刷卡后检测到该卡无法通行时存贮记录，以备查验"
        Me.CB_SystemMode_5.UseVisualStyleBackColor = True
        '
        'CB_SystemMode_4
        '
        Me.CB_SystemMode_4.AutoSize = True
        Me.CB_SystemMode_4.Location = New System.Drawing.Point(174, 45)
        Me.CB_SystemMode_4.Name = "CB_SystemMode_4"
        Me.CB_SystemMode_4.Size = New System.Drawing.Size(306, 18)
        Me.CB_SystemMode_4.TabIndex = 10
        Me.CB_SystemMode_4.Text = "门禁开门时，检查门打开是否超时，是则报警"
        Me.CB_SystemMode_4.UseVisualStyleBackColor = True
        '
        'CB_SystemMode_3
        '
        Me.CB_SystemMode_3.AutoSize = True
        Me.CB_SystemMode_3.Location = New System.Drawing.Point(6, 74)
        Me.CB_SystemMode_3.Name = "CB_SystemMode_3"
        Me.CB_SystemMode_3.Size = New System.Drawing.Size(411, 18)
        Me.CB_SystemMode_3.TabIndex = 9
        Me.CB_SystemMode_3.Text = "通讯时使用机具产品序列号的最后2位数字作为设备号用于联机"
        Me.CB_SystemMode_3.UseVisualStyleBackColor = True
        '
        'CB_SystemMode_2
        '
        Me.CB_SystemMode_2.AutoSize = True
        Me.CB_SystemMode_2.Location = New System.Drawing.Point(6, 45)
        Me.CB_SystemMode_2.Name = "CB_SystemMode_2"
        Me.CB_SystemMode_2.Size = New System.Drawing.Size(152, 18)
        Me.CB_SystemMode_2.TabIndex = 8
        Me.CB_SystemMode_2.Text = "非法卡刷卡存贮记录"
        Me.CB_SystemMode_2.UseVisualStyleBackColor = True
        '
        'CB_SystemMode_1
        '
        Me.CB_SystemMode_1.AutoSize = True
        Me.CB_SystemMode_1.Location = New System.Drawing.Point(174, 16)
        Me.CB_SystemMode_1.Name = "CB_SystemMode_1"
        Me.CB_SystemMode_1.Size = New System.Drawing.Size(166, 18)
        Me.CB_SystemMode_1.TabIndex = 7
        Me.CB_SystemMode_1.Text = "黑名单刷卡时存贮记录"
        Me.CB_SystemMode_1.UseVisualStyleBackColor = True
        '
        'CB_SystemMode_0
        '
        Me.CB_SystemMode_0.AutoSize = True
        Me.CB_SystemMode_0.Location = New System.Drawing.Point(6, 16)
        Me.CB_SystemMode_0.Name = "CB_SystemMode_0"
        Me.CB_SystemMode_0.Size = New System.Drawing.Size(166, 18)
        Me.CB_SystemMode_0.TabIndex = 6
        Me.CB_SystemMode_0.Text = "存贮员工正常考勤记录"
        Me.CB_SystemMode_0.UseVisualStyleBackColor = True
        '
        'TabPage6
        '
        Me.TabPage6.Controls.Add(Me.Cmd_SetRingModeDefault)
        Me.TabPage6.Controls.Add(Me.Cmd_ReadRingMode)
        Me.TabPage6.Controls.Add(Me.Cmd_SetRingMode)
        Me.TabPage6.Controls.Add(Me.GB_RingMode)
        Me.TabPage6.Location = New System.Drawing.Point(4, 22)
        Me.TabPage6.Name = "TabPage6"
        Me.TabPage6.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage6.Size = New System.Drawing.Size(585, 190)
        Me.TabPage6.TabIndex = 5
        Me.TabPage6.Text = "响铃模式"
        Me.TabPage6.UseVisualStyleBackColor = True
        '
        'Cmd_SetRingModeDefault
        '
        Me.Cmd_SetRingModeDefault.Enabled = False
        Me.Cmd_SetRingModeDefault.Location = New System.Drawing.Point(496, 104)
        Me.Cmd_SetRingModeDefault.Name = "Cmd_SetRingModeDefault"
        Me.Cmd_SetRingModeDefault.Size = New System.Drawing.Size(84, 29)
        Me.Cmd_SetRingModeDefault.TabIndex = 36
        Me.Cmd_SetRingModeDefault.Text = "推荐设置"
        Me.Cmd_SetRingModeDefault.UseVisualStyleBackColor = True
        '
        'Cmd_ReadRingMode
        '
        Me.Cmd_ReadRingMode.Location = New System.Drawing.Point(496, 14)
        Me.Cmd_ReadRingMode.Name = "Cmd_ReadRingMode"
        Me.Cmd_ReadRingMode.Size = New System.Drawing.Size(84, 29)
        Me.Cmd_ReadRingMode.TabIndex = 35
        Me.Cmd_ReadRingMode.Text = "获取"
        Me.Cmd_ReadRingMode.UseVisualStyleBackColor = True
        '
        'Cmd_SetRingMode
        '
        Me.Cmd_SetRingMode.Enabled = False
        Me.Cmd_SetRingMode.Location = New System.Drawing.Point(496, 59)
        Me.Cmd_SetRingMode.Name = "Cmd_SetRingMode"
        Me.Cmd_SetRingMode.Size = New System.Drawing.Size(84, 29)
        Me.Cmd_SetRingMode.TabIndex = 34
        Me.Cmd_SetRingMode.Text = "设置"
        Me.Cmd_SetRingMode.UseVisualStyleBackColor = True
        '
        'GB_RingMode
        '
        Me.GB_RingMode.Controls.Add(Me.CB_RingMode_5)
        Me.GB_RingMode.Controls.Add(Me.CB_RingMode_3)
        Me.GB_RingMode.Controls.Add(Me.CB_RingMode_4)
        Me.GB_RingMode.Controls.Add(Me.CB_RingMode_1)
        Me.GB_RingMode.Controls.Add(Me.CB_RingMode_2)
        Me.GB_RingMode.Controls.Add(Me.CB_RingMode_0)
        Me.GB_RingMode.Controls.Add(Me.CB_RingMode_76)
        Me.GB_RingMode.Controls.Add(Me.Label24)
        Me.GB_RingMode.Dock = System.Windows.Forms.DockStyle.Left
        Me.GB_RingMode.Enabled = False
        Me.GB_RingMode.Location = New System.Drawing.Point(3, 3)
        Me.GB_RingMode.Name = "GB_RingMode"
        Me.GB_RingMode.Size = New System.Drawing.Size(486, 184)
        Me.GB_RingMode.TabIndex = 33
        Me.GB_RingMode.TabStop = False
        '
        'CB_RingMode_5
        '
        Me.CB_RingMode_5.AutoSize = True
        Me.CB_RingMode_5.Location = New System.Drawing.Point(6, 128)
        Me.CB_RingMode_5.Name = "CB_RingMode_5"
        Me.CB_RingMode_5.Size = New System.Drawing.Size(404, 18)
        Me.CB_RingMode_5.TabIndex = 20
        Me.CB_RingMode_5.Text = "外部输入联动警报为火灾消防警报，生效时应能自动开门逃生"
        Me.CB_RingMode_5.UseVisualStyleBackColor = True
        '
        'CB_RingMode_3
        '
        Me.CB_RingMode_3.AutoSize = True
        Me.CB_RingMode_3.Location = New System.Drawing.Point(6, 59)
        Me.CB_RingMode_3.Name = "CB_RingMode_3"
        Me.CB_RingMode_3.Size = New System.Drawing.Size(292, 18)
        Me.CB_RingMode_3.TabIndex = 18
        Me.CB_RingMode_3.Text = "刷卡无法通行时响铃，发出无法通行提示音"
        Me.CB_RingMode_3.UseVisualStyleBackColor = True
        '
        'CB_RingMode_4
        '
        Me.CB_RingMode_4.AutoSize = True
        Me.CB_RingMode_4.Location = New System.Drawing.Point(6, 105)
        Me.CB_RingMode_4.Name = "CB_RingMode_4"
        Me.CB_RingMode_4.Size = New System.Drawing.Size(320, 18)
        Me.CB_RingMode_4.TabIndex = 17
        Me.CB_RingMode_4.Text = "使用常开门磁，门关闭时，门磁闭合，开关短路"
        Me.CB_RingMode_4.UseVisualStyleBackColor = True
        '
        'CB_RingMode_1
        '
        Me.CB_RingMode_1.AutoSize = True
        Me.CB_RingMode_1.Location = New System.Drawing.Point(6, 36)
        Me.CB_RingMode_1.Name = "CB_RingMode_1"
        Me.CB_RingMode_1.Size = New System.Drawing.Size(334, 18)
        Me.CB_RingMode_1.TabIndex = 16
        Me.CB_RingMode_1.Text = "黑名单卡、非法卡刷卡时响铃发出刷卡错误提示音"
        Me.CB_RingMode_1.UseVisualStyleBackColor = True
        '
        'CB_RingMode_2
        '
        Me.CB_RingMode_2.AutoSize = True
        Me.CB_RingMode_2.Location = New System.Drawing.Point(6, 82)
        Me.CB_RingMode_2.Name = "CB_RingMode_2"
        Me.CB_RingMode_2.Size = New System.Drawing.Size(306, 18)
        Me.CB_RingMode_2.TabIndex = 15
        Me.CB_RingMode_2.Text = "非允许刷卡时段刷卡响铃发出相对应的提示音"
        Me.CB_RingMode_2.UseVisualStyleBackColor = True
        '
        'CB_RingMode_0
        '
        Me.CB_RingMode_0.AutoSize = True
        Me.CB_RingMode_0.Location = New System.Drawing.Point(6, 13)
        Me.CB_RingMode_0.Name = "CB_RingMode_0"
        Me.CB_RingMode_0.Size = New System.Drawing.Size(250, 18)
        Me.CB_RingMode_0.TabIndex = 14
        Me.CB_RingMode_0.Text = "正常刷卡时响铃发出正常刷卡提示音"
        Me.CB_RingMode_0.UseVisualStyleBackColor = True
        '
        'CB_RingMode_76
        '
        Me.CB_RingMode_76.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_RingMode_76.FormattingEnabled = True
        Me.CB_RingMode_76.Location = New System.Drawing.Point(84, 151)
        Me.CB_RingMode_76.Name = "CB_RingMode_76"
        Me.CB_RingMode_76.Size = New System.Drawing.Size(355, 22)
        Me.CB_RingMode_76.TabIndex = 11
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(8, 151)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(70, 14)
        Me.Label24.TabIndex = 10
        Me.Label24.Text = "机器作用:"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Cmd_SetFirstWindowDispString)
        Me.TabPage2.Controls.Add(Me.Label8)
        Me.TabPage2.Controls.Add(Me.TB_SetFirstWindowDispString)
        Me.TabPage2.Controls.Add(Me.Label14)
        Me.TabPage2.Controls.Add(Me.Cmd_SetClockNormalMessage)
        Me.TabPage2.Controls.Add(Me.Label4)
        Me.TabPage2.Controls.Add(Me.TB_SetClockNormalMessage)
        Me.TabPage2.Controls.Add(Me.Label1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(585, 190)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "界面设置"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Cmd_SetFirstWindowDispString
        '
        Me.Cmd_SetFirstWindowDispString.Location = New System.Drawing.Point(482, 87)
        Me.Cmd_SetFirstWindowDispString.Name = "Cmd_SetFirstWindowDispString"
        Me.Cmd_SetFirstWindowDispString.Size = New System.Drawing.Size(68, 29)
        Me.Cmd_SetFirstWindowDispString.TabIndex = 30
        Me.Cmd_SetFirstWindowDispString.Text = "设置"
        Me.Cmd_SetFirstWindowDispString.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label8.Location = New System.Drawing.Point(321, 92)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(136, 16)
        Me.Label8.TabIndex = 29
        Me.Label8.Text = "(8中文,16个英文)"
        '
        'TB_SetFirstWindowDispString
        '
        Me.TB_SetFirstWindowDispString.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TB_SetFirstWindowDispString.Location = New System.Drawing.Point(127, 89)
        Me.TB_SetFirstWindowDispString.Margin = New System.Windows.Forms.Padding(4)
        Me.TB_SetFirstWindowDispString.Name = "TB_SetFirstWindowDispString"
        Me.TB_SetFirstWindowDispString.Size = New System.Drawing.Size(186, 26)
        Me.TB_SetFirstWindowDispString.TabIndex = 28
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label14.Location = New System.Drawing.Point(7, 92)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(112, 16)
        Me.Label14.TabIndex = 27
        Me.Label14.Text = "开机显示内容:"
        '
        'Cmd_SetClockNormalMessage
        '
        Me.Cmd_SetClockNormalMessage.Location = New System.Drawing.Point(482, 26)
        Me.Cmd_SetClockNormalMessage.Name = "Cmd_SetClockNormalMessage"
        Me.Cmd_SetClockNormalMessage.Size = New System.Drawing.Size(68, 29)
        Me.Cmd_SetClockNormalMessage.TabIndex = 26
        Me.Cmd_SetClockNormalMessage.Text = "设置"
        Me.Cmd_SetClockNormalMessage.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label4.Location = New System.Drawing.Point(321, 31)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(136, 16)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "(8中文,16个英文)"
        '
        'TB_SetClockNormalMessage
        '
        Me.TB_SetClockNormalMessage.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TB_SetClockNormalMessage.Location = New System.Drawing.Point(127, 28)
        Me.TB_SetClockNormalMessage.Margin = New System.Windows.Forms.Padding(4)
        Me.TB_SetClockNormalMessage.Name = "TB_SetClockNormalMessage"
        Me.TB_SetClockNormalMessage.Size = New System.Drawing.Size(186, 26)
        Me.TB_SetClockNormalMessage.TabIndex = 24
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label1.Location = New System.Drawing.Point(7, 31)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 16)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "常态显示内容:"
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.Label25)
        Me.TabPage3.Controls.Add(Me.Cmd_SetManagerCard)
        Me.TabPage3.Controls.Add(Me.TB_ManagerCard)
        Me.TabPage3.Controls.Add(Me.Label16)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(585, 190)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "管理卡"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.ForeColor = System.Drawing.Color.Red
        Me.Label25.Location = New System.Drawing.Point(128, 76)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(189, 14)
        Me.Label25.TabIndex = 32
        Me.Label25.Text = "(管理卡不能作为考勤卡使用)"
        '
        'Cmd_SetManagerCard
        '
        Me.Cmd_SetManagerCard.Location = New System.Drawing.Point(366, 27)
        Me.Cmd_SetManagerCard.Name = "Cmd_SetManagerCard"
        Me.Cmd_SetManagerCard.Size = New System.Drawing.Size(68, 29)
        Me.Cmd_SetManagerCard.TabIndex = 31
        Me.Cmd_SetManagerCard.Text = "设置"
        Me.Cmd_SetManagerCard.UseVisualStyleBackColor = True
        '
        'TB_ManagerCard
        '
        Me.TB_ManagerCard.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TB_ManagerCard.Location = New System.Drawing.Point(144, 30)
        Me.TB_ManagerCard.Margin = New System.Windows.Forms.Padding(4)
        Me.TB_ManagerCard.Name = "TB_ManagerCard"
        Me.TB_ManagerCard.Size = New System.Drawing.Size(186, 26)
        Me.TB_ManagerCard.TabIndex = 28
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label16.Location = New System.Drawing.Point(40, 33)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(96, 16)
        Me.Label16.TabIndex = 27
        Me.Label16.Text = "管理卡号码:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label7.Location = New System.Drawing.Point(236, 32)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(47, 12)
        Me.Label7.TabIndex = 28
        Me.Label7.Text = "(1-255)"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label9.Location = New System.Drawing.Point(76, 104)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(48, 16)
        Me.Label9.TabIndex = 27
        Me.Label9.Text = "备注:"
        '
        'TB_Remark
        '
        Me.TB_Remark.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TB_Remark.Location = New System.Drawing.Point(130, 101)
        Me.TB_Remark.Margin = New System.Windows.Forms.Padding(4)
        Me.TB_Remark.Name = "TB_Remark"
        Me.TB_Remark.Size = New System.Drawing.Size(405, 26)
        Me.TB_Remark.TabIndex = 26
        '
        'TB_Port
        '
        Me.TB_Port.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TB_Port.Location = New System.Drawing.Point(382, 63)
        Me.TB_Port.Margin = New System.Windows.Forms.Padding(4)
        Me.TB_Port.Name = "TB_Port"
        Me.TB_Port.Size = New System.Drawing.Size(153, 26)
        Me.TB_Port.TabIndex = 25
        '
        'TB_IP
        '
        Me.TB_IP.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TB_IP.Location = New System.Drawing.Point(130, 63)
        Me.TB_IP.Margin = New System.Windows.Forms.Padding(4)
        Me.TB_IP.Name = "TB_IP"
        Me.TB_IP.Size = New System.Drawing.Size(151, 26)
        Me.TB_IP.TabIndex = 24
        '
        'TB_Name
        '
        Me.TB_Name.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TB_Name.Location = New System.Drawing.Point(382, 25)
        Me.TB_Name.Margin = New System.Windows.Forms.Padding(4)
        Me.TB_Name.Name = "TB_Name"
        Me.TB_Name.Size = New System.Drawing.Size(153, 26)
        Me.TB_Name.TabIndex = 23
        '
        'TB_ID
        '
        Me.TB_ID.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TB_ID.Location = New System.Drawing.Point(130, 25)
        Me.TB_ID.Margin = New System.Windows.Forms.Padding(4)
        Me.TB_ID.Name = "TB_ID"
        Me.TB_ID.Size = New System.Drawing.Size(97, 26)
        Me.TB_ID.TabIndex = 22
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label10.Location = New System.Drawing.Point(294, 66)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(80, 16)
        Me.Label10.TabIndex = 21
        Me.Label10.Text = "通信端口:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label11.Location = New System.Drawing.Point(60, 66)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(64, 16)
        Me.Label11.TabIndex = 20
        Me.Label11.Text = "通信IP:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label12.Location = New System.Drawing.Point(294, 28)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(80, 16)
        Me.Label12.TabIndex = 19
        Me.Label12.Text = "考勤机名:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label13.Location = New System.Drawing.Point(44, 28)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(80, 16)
        Me.Label13.TabIndex = 18
        Me.Label13.Text = "考勤机号:"
        '
        'DP_Found_Date
        '
        Me.DP_Found_Date.Location = New System.Drawing.Point(384, 422)
        Me.DP_Found_Date.Name = "DP_Found_Date"
        Me.DP_Found_Date.Size = New System.Drawing.Size(151, 23)
        Me.DP_Found_Date.TabIndex = 17
        '
        'DP_UPD_DATE
        '
        Me.DP_UPD_DATE.Location = New System.Drawing.Point(384, 388)
        Me.DP_UPD_DATE.Name = "DP_UPD_DATE"
        Me.DP_UPD_DATE.Size = New System.Drawing.Size(151, 23)
        Me.DP_UPD_DATE.TabIndex = 16
        '
        'TB_Founder
        '
        Me.TB_Founder.Location = New System.Drawing.Point(130, 423)
        Me.TB_Founder.Name = "TB_Founder"
        Me.TB_Founder.ReadOnly = True
        Me.TB_Founder.Size = New System.Drawing.Size(151, 23)
        Me.TB_Founder.TabIndex = 15
        '
        'TB_UPD_USER
        '
        Me.TB_UPD_USER.Location = New System.Drawing.Point(130, 388)
        Me.TB_UPD_USER.Name = "TB_UPD_USER"
        Me.TB_UPD_USER.ReadOnly = True
        Me.TB_UPD_USER.Size = New System.Drawing.Size(151, 23)
        Me.TB_UPD_USER.TabIndex = 14
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(308, 426)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(70, 14)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "创建时间:"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(287, 390)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(98, 14)
        Me.Label23.TabIndex = 7
        Me.Label23.Text = "最后修改时间:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(68, 426)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 14)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "创建人:"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(40, 391)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(84, 14)
        Me.Label22.TabIndex = 6
        Me.Label22.Text = "最后修改人:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(209, 423)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(0, 14)
        Me.Label3.TabIndex = 9
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(208, 431)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(0, 14)
        Me.Label21.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(208, 434)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(0, 14)
        Me.Label2.TabIndex = 9
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(208, 396)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(0, 14)
        Me.Label18.TabIndex = 9
        '
        'BW
        '
        Me.BW.WorkerReportsProgress = True
        '
        'LabelMsg
        '
        Me.LabelMsg.ForeColor = System.Drawing.Color.Blue
        Me.LabelMsg.Location = New System.Drawing.Point(76, 156)
        Me.LabelMsg.Name = "LabelMsg"
        Me.LabelMsg.Size = New System.Drawing.Size(403, 16)
        Me.LabelMsg.TabIndex = 13
        Me.LabelMsg.Text = "正在加载..."
        Me.LabelMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(71, 123)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(408, 22)
        Me.ProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.ProgressBar1.TabIndex = 12
        '
        'Pic_From
        '
        Me.Pic_From.Controls.Add(Me.LabelMsg)
        Me.Pic_From.Controls.Add(Me.ProgressBar1)
        Me.Pic_From.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pic_From.Location = New System.Drawing.Point(0, 0)
        Me.Pic_From.Name = "Pic_From"
        Me.Pic_From.Size = New System.Drawing.Size(646, 543)
        Me.Pic_From.TabIndex = 11
        '
        'F15501_AtMachine_Msg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.PanelMain)
        Me.Controls.Add(Me.Tool_Top)
        Me.Controls.Add(Me.Pic_From)
        Me.Name = "F15501_AtMachine_Msg"
        Me.Size = New System.Drawing.Size(646, 543)
        Me.Title = "机具详细信息"
        Me.Tool_Top.ResumeLayout(False)
        Me.Tool_Top.PerformLayout()
        Me.PanelMain.ResumeLayout(False)
        Me.PanelMain.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.TabpageSet.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.GB_Mode.ResumeLayout(False)
        Me.GB_Mode.PerformLayout()
        Me.PL_RepeatClockerTime.ResumeLayout(False)
        Me.PL_RepeatClockerTime.PerformLayout()
        CType(Me.ND_RepeatClockerTime, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage4.ResumeLayout(False)
        Me.GB_ExtraMode.ResumeLayout(False)
        Me.GB_ExtraMode.PerformLayout()
        Me.TabPage5.ResumeLayout(False)
        Me.GB_SystemMode.ResumeLayout(False)
        Me.GB_SystemMode.PerformLayout()
        Me.TabPage6.ResumeLayout(False)
        Me.GB_RingMode.ResumeLayout(False)
        Me.GB_RingMode.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.Pic_From.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Tool_Top As System.Windows.Forms.ToolStrip
    Friend WithEvents Cmd_Modify As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_Del As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Cmd_Exit As System.Windows.Forms.ToolStripButton
    Friend WithEvents PanelMain As System.Windows.Forms.Panel
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents TB_UPD_USER As System.Windows.Forms.TextBox
    Friend WithEvents TB_Founder As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DP_UPD_DATE As System.Windows.Forms.DateTimePicker
    Friend WithEvents DP_Found_Date As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TB_Remark As System.Windows.Forms.TextBox
    Friend WithEvents TB_Port As System.Windows.Forms.TextBox
    Friend WithEvents TB_IP As System.Windows.Forms.TextBox
    Friend WithEvents TB_Name As System.Windows.Forms.TextBox
    Friend WithEvents TB_ID As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Cmd_DataIn As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_GetTime As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_SetTime As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BW As System.ComponentModel.BackgroundWorker
    Friend WithEvents LabelMsg As System.Windows.Forms.Label
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents Pic_From As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TabpageSet As PClass.CustomTabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents Cmd_SetModeDefault As System.Windows.Forms.Button
    Friend WithEvents Cmd_ReadMode As System.Windows.Forms.Button
    Friend WithEvents Cmd_SetMode As System.Windows.Forms.Button
    Friend WithEvents GB_Mode As System.Windows.Forms.GroupBox
    Friend WithEvents PL_RepeatClockerTime As System.Windows.Forms.Panel
    Friend WithEvents Cmd_SetRepeatClockerTime As System.Windows.Forms.Button
    Friend WithEvents ND_RepeatClockerTime As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents CB_Mode_7 As System.Windows.Forms.CheckBox
    Friend WithEvents CB_Mode_6 As System.Windows.Forms.CheckBox
    Friend WithEvents CB_Mode_54 As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents CB_Mode_3 As System.Windows.Forms.CheckBox
    Friend WithEvents CB_Mode_210 As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents Cmd_SetExtraModeDefault As System.Windows.Forms.Button
    Friend WithEvents Cmd_ReadExtraMode As System.Windows.Forms.Button
    Friend WithEvents Cmd_SetExtraMode As System.Windows.Forms.Button
    Friend WithEvents GB_ExtraMode As System.Windows.Forms.GroupBox
    Friend WithEvents CB_ExtraMode_2 As System.Windows.Forms.CheckBox
    Friend WithEvents CB_ExtraMode_765 As System.Windows.Forms.ComboBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents CB_ExtraMode_4 As System.Windows.Forms.CheckBox
    Friend WithEvents CB_ExtraMode_3 As System.Windows.Forms.CheckBox
    Friend WithEvents CB_ExtraMode_1 As System.Windows.Forms.CheckBox
    Friend WithEvents CB_ExtraMode_0 As System.Windows.Forms.CheckBox
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents Cmd_SetSystemModeDefault As System.Windows.Forms.Button
    Friend WithEvents Cmd_ReadSystemMode As System.Windows.Forms.Button
    Friend WithEvents Cmd_SetSystemMode As System.Windows.Forms.Button
    Friend WithEvents GB_SystemMode As System.Windows.Forms.GroupBox
    Friend WithEvents CB_SystemMode_7 As System.Windows.Forms.CheckBox
    Friend WithEvents CB_SystemMode_6 As System.Windows.Forms.CheckBox
    Friend WithEvents CB_SystemMode_5 As System.Windows.Forms.CheckBox
    Friend WithEvents CB_SystemMode_4 As System.Windows.Forms.CheckBox
    Friend WithEvents CB_SystemMode_3 As System.Windows.Forms.CheckBox
    Friend WithEvents CB_SystemMode_2 As System.Windows.Forms.CheckBox
    Friend WithEvents CB_SystemMode_1 As System.Windows.Forms.CheckBox
    Friend WithEvents CB_SystemMode_0 As System.Windows.Forms.CheckBox
    Friend WithEvents TabPage6 As System.Windows.Forms.TabPage
    Friend WithEvents Cmd_SetRingModeDefault As System.Windows.Forms.Button
    Friend WithEvents Cmd_ReadRingMode As System.Windows.Forms.Button
    Friend WithEvents Cmd_SetRingMode As System.Windows.Forms.Button
    Friend WithEvents GB_RingMode As System.Windows.Forms.GroupBox
    Friend WithEvents CB_RingMode_5 As System.Windows.Forms.CheckBox
    Friend WithEvents CB_RingMode_3 As System.Windows.Forms.CheckBox
    Friend WithEvents CB_RingMode_4 As System.Windows.Forms.CheckBox
    Friend WithEvents CB_RingMode_1 As System.Windows.Forms.CheckBox
    Friend WithEvents CB_RingMode_2 As System.Windows.Forms.CheckBox
    Friend WithEvents CB_RingMode_0 As System.Windows.Forms.CheckBox
    Friend WithEvents CB_RingMode_76 As System.Windows.Forms.ComboBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Cmd_SetFirstWindowDispString As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TB_SetFirstWindowDispString As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Cmd_SetClockNormalMessage As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TB_SetClockNormalMessage As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Cmd_SetManagerCard As System.Windows.Forms.Button
    Friend WithEvents TB_ManagerCard As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label

End Class
