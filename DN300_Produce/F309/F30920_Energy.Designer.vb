<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F30920_Energy
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F30920_Energy))
        Me.PanelMain = New System.Windows.Forms.Panel
        Me.GR = New AxgrproLib.AxGRDisplayViewer
        Me.Tool_Search = New System.Windows.Forms.ToolStrip
        Me.Cmd_Add = New System.Windows.Forms.ToolStripButton
        Me.Cmd_Modify = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.Label_C = New System.Windows.Forms.ToolStripLabel
        Me.DP_Start = New PClass.ToolStripDateTimePicker
        Me.Label_D = New System.Windows.Forms.ToolStripLabel
        Me.Dp_End = New PClass.ToolStripDateTimePicker
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.Btn_Search = New System.Windows.Forms.ToolStripButton
        Me.Cmd_Preview = New System.Windows.Forms.ToolStripButton
        Me.Cmd_Exit = New System.Windows.Forms.ToolStripButton
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Cmd_CL = New System.Windows.Forms.Button
        Me.TB_LuoSe = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Cmd_Cancel = New System.Windows.Forms.Button
        Me.Cmd_OK = New System.Windows.Forms.Button
        Me.DTP_sDate = New System.Windows.Forms.DateTimePicker
        Me.Label9 = New System.Windows.Forms.Label
        Me.TB_DX_Coal = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.TB_DX_Elec = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.TB_DX_CL = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.TB_RB_Gas = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.TB_RB_ZJ = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.TB_RB_RL = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TB_RB_Water = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TB_RB_CL = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GR2 = New AxgrproLib.AxGRDisplayViewer
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.Cmd_Modify2 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.Cmd_Audited = New System.Windows.Forms.ToolStripButton
        Me.Cmd_UnAudit = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.Btn_Search2 = New System.Windows.Forms.ToolStripButton
        Me.Cmd_Preview2 = New System.Windows.Forms.ToolStripButton
        Me.Cmd_Close2 = New System.Windows.Forms.ToolStripButton
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.PanelMain.SuspendLayout()
        CType(Me.GR, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tool_Search.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.GR2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelMain
        '
        Me.PanelMain.Controls.Add(Me.GR)
        Me.PanelMain.Controls.Add(Me.Tool_Search)
        Me.PanelMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelMain.Location = New System.Drawing.Point(0, 0)
        Me.PanelMain.Name = "PanelMain"
        Me.PanelMain.Padding = New System.Windows.Forms.Padding(2)
        Me.PanelMain.Size = New System.Drawing.Size(1000, 618)
        Me.PanelMain.TabIndex = 0
        '
        'GR
        '
        Me.GR.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GR.Enabled = True
        Me.GR.Location = New System.Drawing.Point(2, 34)
        Me.GR.Name = "GR"
        Me.GR.OcxState = CType(resources.GetObject("GR.OcxState"), System.Windows.Forms.AxHost.State)
        Me.GR.Size = New System.Drawing.Size(996, 582)
        Me.GR.TabIndex = 17
        '
        'Tool_Search
        '
        Me.Tool_Search.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.Tool_Search.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Cmd_Add, Me.Cmd_Modify, Me.ToolStripSeparator3, Me.Label_C, Me.DP_Start, Me.Label_D, Me.Dp_End, Me.ToolStripSeparator2, Me.Btn_Search, Me.Cmd_Preview, Me.Cmd_Exit})
        Me.Tool_Search.Location = New System.Drawing.Point(2, 2)
        Me.Tool_Search.MinimumSize = New System.Drawing.Size(0, 32)
        Me.Tool_Search.Name = "Tool_Search"
        Me.Tool_Search.Size = New System.Drawing.Size(996, 32)
        Me.Tool_Search.TabIndex = 14
        Me.Tool_Search.Text = "ToolStrip1"
        '
        'Cmd_Add
        '
        Me.Cmd_Add.AccessibleDescription = "新增"
        Me.Cmd_Add.AccessibleName = ""
        Me.Cmd_Add.Image = Global.DN300_Produce.My.Resources.Resources.ADD
        Me.Cmd_Add.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Add.Name = "Cmd_Add"
        Me.Cmd_Add.Size = New System.Drawing.Size(57, 29)
        Me.Cmd_Add.Text = "新增"
        '
        'Cmd_Modify
        '
        Me.Cmd_Modify.AccessibleDescription = "修改按钮"
        Me.Cmd_Modify.AccessibleName = ""
        Me.Cmd_Modify.Image = Global.DN300_Produce.My.Resources.Resources.Modify
        Me.Cmd_Modify.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Modify.Name = "Cmd_Modify"
        Me.Cmd_Modify.Size = New System.Drawing.Size(57, 29)
        Me.Cmd_Modify.Text = "查看"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 32)
        '
        'Label_C
        '
        Me.Label_C.Margin = New System.Windows.Forms.Padding(0, 1, 2, 2)
        Me.Label_C.Name = "Label_C"
        Me.Label_C.Size = New System.Drawing.Size(17, 29)
        Me.Label_C.Text = "从"
        '
        'DP_Start
        '
        Me.DP_Start.Name = "DP_Start"
        Me.DP_Start.Size = New System.Drawing.Size(100, 29)
        Me.DP_Start.Text = "2012-03-02"
        Me.DP_Start.Value = New Date(2012, 3, 2, 0, 0, 0, 0)
        '
        'Label_D
        '
        Me.Label_D.Margin = New System.Windows.Forms.Padding(0, 1, 2, 2)
        Me.Label_D.Name = "Label_D"
        Me.Label_D.Size = New System.Drawing.Size(17, 29)
        Me.Label_D.Text = "到"
        '
        'Dp_End
        '
        Me.Dp_End.Name = "Dp_End"
        Me.Dp_End.Size = New System.Drawing.Size(100, 29)
        Me.Dp_End.Text = "2012-03-02"
        Me.Dp_End.Value = New Date(2012, 3, 2, 0, 0, 0, 0)
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 32)
        '
        'Btn_Search
        '
        Me.Btn_Search.Image = CType(resources.GetObject("Btn_Search.Image"), System.Drawing.Image)
        Me.Btn_Search.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.Btn_Search.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Btn_Search.Margin = New System.Windows.Forms.Padding(2, 1, 0, 2)
        Me.Btn_Search.Name = "Btn_Search"
        Me.Btn_Search.Size = New System.Drawing.Size(65, 29)
        Me.Btn_Search.Text = "搜索"
        '
        'Cmd_Preview
        '
        Me.Cmd_Preview.Image = Global.DN300_Produce.My.Resources.Resources.Print_preview
        Me.Cmd_Preview.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Preview.Name = "Cmd_Preview"
        Me.Cmd_Preview.Size = New System.Drawing.Size(57, 29)
        Me.Cmd_Preview.Text = "预览"
        '
        'Cmd_Exit
        '
        Me.Cmd_Exit.Image = Global.DN300_Produce.My.Resources.Resources.Close
        Me.Cmd_Exit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(57, 29)
        Me.Cmd_Exit.Text = "关闭"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Cmd_CL)
        Me.GroupBox2.Controls.Add(Me.TB_LuoSe)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Cmd_Cancel)
        Me.GroupBox2.Controls.Add(Me.Cmd_OK)
        Me.GroupBox2.Controls.Add(Me.DTP_sDate)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.TB_DX_Coal)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.TB_DX_Elec)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.TB_DX_CL)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.TB_RB_Gas)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.TB_RB_ZJ)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.TB_RB_RL)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.TB_RB_Water)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.TB_RB_CL)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(502, 321)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "修改当日能耗"
        Me.GroupBox2.Visible = False
        '
        'Cmd_CL
        '
        Me.Cmd_CL.Location = New System.Drawing.Point(274, 34)
        Me.Cmd_CL.Name = "Cmd_CL"
        Me.Cmd_CL.Size = New System.Drawing.Size(110, 26)
        Me.Cmd_CL.TabIndex = 20
        Me.Cmd_CL.Text = "刷新领料数"
        Me.Cmd_CL.UseVisualStyleBackColor = True
        '
        'TB_LuoSe
        '
        Me.TB_LuoSe.Location = New System.Drawing.Point(357, 217)
        Me.TB_LuoSe.Name = "TB_LuoSe"
        Me.TB_LuoSe.ReadOnly = True
        Me.TB_LuoSe.Size = New System.Drawing.Size(100, 26)
        Me.TB_LuoSe.TabIndex = 9
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label10.Location = New System.Drawing.Point(271, 220)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(80, 16)
        Me.Label10.TabIndex = 19
        Me.Label10.Text = "落色条数:"
        '
        'Cmd_Cancel
        '
        Me.Cmd_Cancel.Location = New System.Drawing.Point(364, 265)
        Me.Cmd_Cancel.Name = "Cmd_Cancel"
        Me.Cmd_Cancel.Size = New System.Drawing.Size(93, 37)
        Me.Cmd_Cancel.TabIndex = 11
        Me.Cmd_Cancel.Text = "取消"
        Me.Cmd_Cancel.UseVisualStyleBackColor = True
        '
        'Cmd_OK
        '
        Me.Cmd_OK.Location = New System.Drawing.Point(246, 265)
        Me.Cmd_OK.Name = "Cmd_OK"
        Me.Cmd_OK.Size = New System.Drawing.Size(93, 37)
        Me.Cmd_OK.TabIndex = 10
        Me.Cmd_OK.Text = "保存"
        Me.Cmd_OK.UseVisualStyleBackColor = True
        '
        'DTP_sDate
        '
        Me.DTP_sDate.CustomFormat = "yyyy年MM月dd日"
        Me.DTP_sDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTP_sDate.Location = New System.Drawing.Point(126, 34)
        Me.DTP_sDate.Name = "DTP_sDate"
        Me.DTP_sDate.Size = New System.Drawing.Size(136, 26)
        Me.DTP_sDate.TabIndex = 0
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(72, 39)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(48, 16)
        Me.Label9.TabIndex = 15
        Me.Label9.Text = "日期:"
        '
        'TB_DX_Coal
        '
        Me.TB_DX_Coal.Location = New System.Drawing.Point(357, 172)
        Me.TB_DX_Coal.Name = "TB_DX_Coal"
        Me.TB_DX_Coal.Size = New System.Drawing.Size(100, 26)
        Me.TB_DX_Coal.TabIndex = 8
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label6.Location = New System.Drawing.Point(295, 175)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 16)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "煤(T):"
        '
        'TB_DX_Elec
        '
        Me.TB_DX_Elec.Location = New System.Drawing.Point(357, 127)
        Me.TB_DX_Elec.Name = "TB_DX_Elec"
        Me.TB_DX_Elec.Size = New System.Drawing.Size(100, 26)
        Me.TB_DX_Elec.TabIndex = 7
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label7.Location = New System.Drawing.Point(287, 130)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(64, 16)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "电(度):"
        '
        'TB_DX_CL
        '
        Me.TB_DX_CL.Location = New System.Drawing.Point(357, 82)
        Me.TB_DX_CL.Name = "TB_DX_CL"
        Me.TB_DX_CL.Size = New System.Drawing.Size(100, 26)
        Me.TB_DX_CL.TabIndex = 6
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(271, 85)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(80, 16)
        Me.Label8.TabIndex = 10
        Me.Label8.Text = "定型产量:"
        '
        'TB_RB_Gas
        '
        Me.TB_RB_Gas.Location = New System.Drawing.Point(126, 172)
        Me.TB_RB_Gas.Name = "TB_RB_Gas"
        Me.TB_RB_Gas.Size = New System.Drawing.Size(100, 26)
        Me.TB_RB_Gas.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label5.Location = New System.Drawing.Point(72, 175)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 16)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "汽m³:"
        '
        'TB_RB_ZJ
        '
        Me.TB_RB_ZJ.Location = New System.Drawing.Point(126, 262)
        Me.TB_RB_ZJ.Name = "TB_RB_ZJ"
        Me.TB_RB_ZJ.ReadOnly = True
        Me.TB_RB_ZJ.Size = New System.Drawing.Size(100, 26)
        Me.TB_RB_ZJ.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(48, 265)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 16)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "助剂/元:"
        '
        'TB_RB_RL
        '
        Me.TB_RB_RL.Location = New System.Drawing.Point(126, 217)
        Me.TB_RB_RL.Name = "TB_RB_RL"
        Me.TB_RB_RL.ReadOnly = True
        Me.TB_RB_RL.Size = New System.Drawing.Size(100, 26)
        Me.TB_RB_RL.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(48, 220)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "染料/元:"
        '
        'TB_RB_Water
        '
        Me.TB_RB_Water.Location = New System.Drawing.Point(126, 127)
        Me.TB_RB_Water.Name = "TB_RB_Water"
        Me.TB_RB_Water.Size = New System.Drawing.Size(100, 26)
        Me.TB_RB_Water.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label2.Location = New System.Drawing.Point(72, 130)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "水m³:"
        '
        'TB_RB_CL
        '
        Me.TB_RB_CL.Location = New System.Drawing.Point(126, 82)
        Me.TB_RB_CL.Name = "TB_RB_CL"
        Me.TB_RB_CL.Size = New System.Drawing.Size(100, 26)
        Me.TB_RB_CL.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(40, 85)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "染部产量:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GR2)
        Me.GroupBox1.Controls.Add(Me.ToolStrip1)
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(893, 548)
        Me.GroupBox1.TabIndex = 18
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "当然能耗"
        '
        'GR2
        '
        Me.GR2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GR2.Enabled = True
        Me.GR2.Location = New System.Drawing.Point(3, 51)
        Me.GR2.Name = "GR2"
        Me.GR2.OcxState = CType(resources.GetObject("GR2.OcxState"), System.Windows.Forms.AxHost.State)
        Me.GR2.Size = New System.Drawing.Size(887, 494)
        Me.GR2.TabIndex = 18
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Cmd_Modify2, Me.ToolStripSeparator1, Me.Cmd_Audited, Me.Cmd_UnAudit, Me.ToolStripSeparator4, Me.Btn_Search2, Me.Cmd_Preview2, Me.Cmd_Close2})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 19)
        Me.ToolStrip1.MinimumSize = New System.Drawing.Size(0, 32)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(887, 32)
        Me.ToolStrip1.TabIndex = 19
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'Cmd_Modify2
        '
        Me.Cmd_Modify2.AccessibleDescription = "修改按钮"
        Me.Cmd_Modify2.AccessibleName = ""
        Me.Cmd_Modify2.Image = Global.DN300_Produce.My.Resources.Resources.Modify
        Me.Cmd_Modify2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Modify2.Name = "Cmd_Modify2"
        Me.Cmd_Modify2.Size = New System.Drawing.Size(57, 29)
        Me.Cmd_Modify2.Text = "修改"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 32)
        '
        'Cmd_Audited
        '
        Me.Cmd_Audited.Image = Global.DN300_Produce.My.Resources.Resources.apply
        Me.Cmd_Audited.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Audited.Name = "Cmd_Audited"
        Me.Cmd_Audited.Size = New System.Drawing.Size(57, 29)
        Me.Cmd_Audited.Text = "审核"
        '
        'Cmd_UnAudit
        '
        Me.Cmd_UnAudit.Image = Global.DN300_Produce.My.Resources.Resources.cancel
        Me.Cmd_UnAudit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_UnAudit.Name = "Cmd_UnAudit"
        Me.Cmd_UnAudit.Size = New System.Drawing.Size(57, 29)
        Me.Cmd_UnAudit.Text = "反审"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 32)
        '
        'Btn_Search2
        '
        Me.Btn_Search2.Image = Global.DN300_Produce.My.Resources.Resources.ReFresh
        Me.Btn_Search2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.Btn_Search2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Btn_Search2.Margin = New System.Windows.Forms.Padding(2, 1, 0, 2)
        Me.Btn_Search2.Name = "Btn_Search2"
        Me.Btn_Search2.Size = New System.Drawing.Size(57, 29)
        Me.Btn_Search2.Text = "刷新"
        '
        'Cmd_Preview2
        '
        Me.Cmd_Preview2.Image = Global.DN300_Produce.My.Resources.Resources.Print_preview
        Me.Cmd_Preview2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Preview2.Name = "Cmd_Preview2"
        Me.Cmd_Preview2.Size = New System.Drawing.Size(57, 29)
        Me.Cmd_Preview2.Text = "预览"
        '
        'Cmd_Close2
        '
        Me.Cmd_Close2.Image = Global.DN300_Produce.My.Resources.Resources.Close
        Me.Cmd_Close2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Close2.Name = "Cmd_Close2"
        Me.Cmd_Close2.Size = New System.Drawing.Size(57, 29)
        Me.Cmd_Close2.Text = "关闭"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1000, 618)
        Me.Panel1.TabIndex = 0
        '
        'F30920_Energy
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CanMaxSize = True
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PanelMain)
        Me.ForeColor = System.Drawing.Color.Black
        Me.Name = "F30920_Energy"
        Me.Size = New System.Drawing.Size(1000, 618)
        Me.PanelMain.ResumeLayout(False)
        Me.PanelMain.PerformLayout()
        CType(Me.GR, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tool_Search.ResumeLayout(False)
        Me.Tool_Search.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.GR2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelMain As System.Windows.Forms.Panel
    Friend WithEvents Tool_Search As System.Windows.Forms.ToolStrip
    Friend WithEvents GR As AxgrproLib.AxGRDisplayViewer
    Friend WithEvents Cmd_Preview As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_Exit As System.Windows.Forms.ToolStripButton
    Friend WithEvents Btn_Search As System.Windows.Forms.ToolStripButton
    Friend WithEvents DP_Start As PClass.ToolStripDateTimePicker
    Friend WithEvents Dp_End As PClass.ToolStripDateTimePicker
    Friend WithEvents Label_C As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Label_D As System.Windows.Forms.ToolStripLabel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GR2 As AxgrproLib.AxGRDisplayViewer
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents Btn_Search2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_Preview2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_Close2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TB_RB_ZJ As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TB_RB_RL As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TB_RB_Water As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TB_RB_CL As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DTP_sDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TB_DX_Coal As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TB_DX_Elec As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TB_DX_CL As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TB_RB_Gas As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Cmd_Cancel As System.Windows.Forms.Button
    Friend WithEvents Cmd_OK As System.Windows.Forms.Button
    Friend WithEvents Cmd_Add As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_Modify As System.Windows.Forms.ToolStripButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Cmd_Modify2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TB_LuoSe As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Cmd_CL As System.Windows.Forms.Button
    Friend WithEvents Cmd_Audited As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_UnAudit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator

End Class
