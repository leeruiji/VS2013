<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F30205_TZPB_Msg
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F30205_TZPB_Msg))
        Me.Tool_Top = New System.Windows.Forms.ToolStrip
        Me.Cmd_Modify = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.Btn_RemoveRow = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.Cmd_Exit = New System.Windows.Forms.ToolStripButton
        Me.PanelMain1 = New System.Windows.Forms.Panel
        Me.TB_TZA = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.TB_PWeight_B = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.BZC_No_B = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.DTP_Date_KaiDan_B = New System.Windows.Forms.DateTimePicker
        Me.TB_CR_LuoSeBzCount_B = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.TB_ProcessType_B = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.BZC_Name_B = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.TB_GH_B = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.TB_Client_Name_B = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.TB_PWeight = New System.Windows.Forms.TextBox
        Me.Label31 = New System.Windows.Forms.Label
        Me.Label28 = New System.Windows.Forms.Label
        Me.BZC_No = New System.Windows.Forms.TextBox
        Me.LB_State = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.DTP_Date_KaiDan = New System.Windows.Forms.DateTimePicker
        Me.TB_CR_LuoSeBzCount = New System.Windows.Forms.TextBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.TB_ProcessType = New System.Windows.Forms.TextBox
        Me.TB_BZ_No = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.LabelTitle = New System.Windows.Forms.Label
        Me.BZC_Name = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.GB_List = New System.Windows.Forms.GroupBox
        Me.PanelFG = New System.Windows.Forms.Panel
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.Fg1 = New PClass.FG
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer
        Me.Fg2 = New PClass.FG
        Me.Fg3 = New PClass.FG
        Me.Label2 = New System.Windows.Forms.Label
        Me.TB_BZ_Name = New System.Windows.Forms.TextBox
        Me.TB_GH = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label_ID = New System.Windows.Forms.Label
        Me.TB_Client_Name = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.TB_TZB = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.PanelMain = New System.Windows.Forms.Panel
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Tool_Top.SuspendLayout()
        Me.PanelMain1.SuspendLayout()
        Me.GB_List.SuspendLayout()
        Me.PanelFG.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.Fg1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.Fg2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Fg3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'Tool_Top
        '
        Me.Tool_Top.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.Tool_Top.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Cmd_Modify, Me.ToolStripSeparator2, Me.Btn_RemoveRow, Me.ToolStripSeparator3, Me.Cmd_Exit})
        Me.Tool_Top.Location = New System.Drawing.Point(0, 0)
        Me.Tool_Top.MinimumSize = New System.Drawing.Size(0, 40)
        Me.Tool_Top.Name = "Tool_Top"
        Me.Tool_Top.Size = New System.Drawing.Size(1024, 40)
        Me.Tool_Top.TabIndex = 10
        Me.Tool_Top.Text = "ToolStrip2"
        '
        'Cmd_Modify
        '
        Me.Cmd_Modify.AccessibleDescription = "修改按钮"
        Me.Cmd_Modify.AccessibleName = ""
        Me.Cmd_Modify.Image = Global.DN300_Produce.My.Resources.Resources.Modify
        Me.Cmd_Modify.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Modify.Name = "Cmd_Modify"
        Me.Cmd_Modify.Size = New System.Drawing.Size(57, 37)
        Me.Cmd_Modify.Text = "保存"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 40)
        '
        'Btn_RemoveRow
        '
        Me.Btn_RemoveRow.Image = CType(resources.GetObject("Btn_RemoveRow.Image"), System.Drawing.Image)
        Me.Btn_RemoveRow.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Btn_RemoveRow.Name = "Btn_RemoveRow"
        Me.Btn_RemoveRow.Size = New System.Drawing.Size(57, 37)
        Me.Btn_RemoveRow.Text = "减行"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 40)
        '
        'Cmd_Exit
        '
        Me.Cmd_Exit.Image = Global.DN300_Produce.My.Resources.Resources.Close
        Me.Cmd_Exit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(57, 37)
        Me.Cmd_Exit.Text = "关闭"
        '
        'PanelMain1
        '
        Me.PanelMain1.Controls.Add(Me.TB_TZA)
        Me.PanelMain1.Controls.Add(Me.Label14)
        Me.PanelMain1.Controls.Add(Me.TB_PWeight_B)
        Me.PanelMain1.Controls.Add(Me.Label3)
        Me.PanelMain1.Controls.Add(Me.BZC_No_B)
        Me.PanelMain1.Controls.Add(Me.Label5)
        Me.PanelMain1.Controls.Add(Me.DTP_Date_KaiDan_B)
        Me.PanelMain1.Controls.Add(Me.TB_CR_LuoSeBzCount_B)
        Me.PanelMain1.Controls.Add(Me.Label6)
        Me.PanelMain1.Controls.Add(Me.Label7)
        Me.PanelMain1.Controls.Add(Me.TB_ProcessType_B)
        Me.PanelMain1.Controls.Add(Me.Label8)
        Me.PanelMain1.Controls.Add(Me.BZC_Name_B)
        Me.PanelMain1.Controls.Add(Me.Label9)
        Me.PanelMain1.Controls.Add(Me.TB_GH_B)
        Me.PanelMain1.Controls.Add(Me.Label10)
        Me.PanelMain1.Controls.Add(Me.TB_Client_Name_B)
        Me.PanelMain1.Controls.Add(Me.Label12)
        Me.PanelMain1.Controls.Add(Me.TB_PWeight)
        Me.PanelMain1.Controls.Add(Me.Label31)
        Me.PanelMain1.Controls.Add(Me.Label28)
        Me.PanelMain1.Controls.Add(Me.BZC_No)
        Me.PanelMain1.Controls.Add(Me.LB_State)
        Me.PanelMain1.Controls.Add(Me.Label25)
        Me.PanelMain1.Controls.Add(Me.DTP_Date_KaiDan)
        Me.PanelMain1.Controls.Add(Me.TB_CR_LuoSeBzCount)
        Me.PanelMain1.Controls.Add(Me.Label23)
        Me.PanelMain1.Controls.Add(Me.Label19)
        Me.PanelMain1.Controls.Add(Me.TB_ProcessType)
        Me.PanelMain1.Controls.Add(Me.TB_BZ_No)
        Me.PanelMain1.Controls.Add(Me.Label21)
        Me.PanelMain1.Controls.Add(Me.Label17)
        Me.PanelMain1.Controls.Add(Me.LabelTitle)
        Me.PanelMain1.Controls.Add(Me.BZC_Name)
        Me.PanelMain1.Controls.Add(Me.Label1)
        Me.PanelMain1.Controls.Add(Me.Label13)
        Me.PanelMain1.Controls.Add(Me.GB_List)
        Me.PanelMain1.Controls.Add(Me.TB_BZ_Name)
        Me.PanelMain1.Controls.Add(Me.TB_GH)
        Me.PanelMain1.Controls.Add(Me.Label11)
        Me.PanelMain1.Controls.Add(Me.Label_ID)
        Me.PanelMain1.Controls.Add(Me.TB_Client_Name)
        Me.PanelMain1.Controls.Add(Me.Label4)
        Me.PanelMain1.Controls.Add(Me.TB_TZB)
        Me.PanelMain1.Controls.Add(Me.Label15)
        Me.PanelMain1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelMain1.Location = New System.Drawing.Point(0, 40)
        Me.PanelMain1.Name = "PanelMain1"
        Me.PanelMain1.Padding = New System.Windows.Forms.Padding(2)
        Me.PanelMain1.Size = New System.Drawing.Size(1024, 678)
        Me.PanelMain1.TabIndex = 0
        '
        'TB_TZA
        '
        Me.TB_TZA.Location = New System.Drawing.Point(429, 173)
        Me.TB_TZA.Name = "TB_TZA"
        Me.TB_TZA.ReadOnly = True
        Me.TB_TZA.Size = New System.Drawing.Size(76, 23)
        Me.TB_TZA.TabIndex = 63
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(360, 176)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(63, 14)
        Me.Label14.TabIndex = 64
        Me.Label14.Text = "调整后A:"
        '
        'TB_PWeight_B
        '
        Me.TB_PWeight_B.Location = New System.Drawing.Point(761, 173)
        Me.TB_PWeight_B.Name = "TB_PWeight_B"
        Me.TB_PWeight_B.ReadOnly = True
        Me.TB_PWeight_B.Size = New System.Drawing.Size(80, 23)
        Me.TB_PWeight_B.TabIndex = 61
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(685, 176)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 14)
        Me.Label3.TabIndex = 62
        Me.Label3.Text = "胚布重量:"
        '
        'BZC_No_B
        '
        Me.BZC_No_B.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.BZC_No_B.ForeColor = System.Drawing.Color.Blue
        Me.BZC_No_B.Location = New System.Drawing.Point(653, 101)
        Me.BZC_No_B.Name = "BZC_No_B"
        Me.BZC_No_B.ReadOnly = True
        Me.BZC_No_B.Size = New System.Drawing.Size(111, 23)
        Me.BZC_No_B.TabIndex = 59
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(605, 105)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(42, 14)
        Me.Label5.TabIndex = 60
        Me.Label5.Text = "色号:"
        '
        'DTP_Date_KaiDan_B
        '
        Me.DTP_Date_KaiDan_B.CustomFormat = "yyyy-MM-dd"
        Me.DTP_Date_KaiDan_B.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTP_Date_KaiDan_B.Location = New System.Drawing.Point(653, 136)
        Me.DTP_Date_KaiDan_B.Name = "DTP_Date_KaiDan_B"
        Me.DTP_Date_KaiDan_B.Size = New System.Drawing.Size(111, 23)
        Me.DTP_Date_KaiDan_B.TabIndex = 58
        '
        'TB_CR_LuoSeBzCount_B
        '
        Me.TB_CR_LuoSeBzCount_B.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.TB_CR_LuoSeBzCount_B.ForeColor = System.Drawing.Color.Blue
        Me.TB_CR_LuoSeBzCount_B.Location = New System.Drawing.Point(938, 171)
        Me.TB_CR_LuoSeBzCount_B.Name = "TB_CR_LuoSeBzCount_B"
        Me.TB_CR_LuoSeBzCount_B.ReadOnly = True
        Me.TB_CR_LuoSeBzCount_B.Size = New System.Drawing.Size(76, 23)
        Me.TB_CR_LuoSeBzCount_B.TabIndex = 53
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(577, 140)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(70, 14)
        Me.Label6.TabIndex = 57
        Me.Label6.Text = "开单日期:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(862, 175)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(70, 14)
        Me.Label7.TabIndex = 54
        Me.Label7.Text = "落色条数:"
        '
        'TB_ProcessType_B
        '
        Me.TB_ProcessType_B.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.TB_ProcessType_B.ForeColor = System.Drawing.Color.Blue
        Me.TB_ProcessType_B.Location = New System.Drawing.Point(865, 137)
        Me.TB_ProcessType_B.Name = "TB_ProcessType_B"
        Me.TB_ProcessType_B.ReadOnly = True
        Me.TB_ProcessType_B.Size = New System.Drawing.Size(149, 23)
        Me.TB_ProcessType_B.TabIndex = 55
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(789, 141)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(70, 14)
        Me.Label8.TabIndex = 56
        Me.Label8.Text = "加工类别:"
        '
        'BZC_Name_B
        '
        Me.BZC_Name_B.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.BZC_Name_B.ForeColor = System.Drawing.Color.Blue
        Me.BZC_Name_B.Location = New System.Drawing.Point(865, 101)
        Me.BZC_Name_B.Name = "BZC_Name_B"
        Me.BZC_Name_B.ReadOnly = True
        Me.BZC_Name_B.Size = New System.Drawing.Size(148, 23)
        Me.BZC_Name_B.TabIndex = 49
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(817, 105)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(42, 14)
        Me.Label9.TabIndex = 51
        Me.Label9.Text = "颜色:"
        '
        'TB_GH_B
        '
        Me.TB_GH_B.Location = New System.Drawing.Point(653, 62)
        Me.TB_GH_B.Name = "TB_GH_B"
        Me.TB_GH_B.ReadOnly = True
        Me.TB_GH_B.Size = New System.Drawing.Size(111, 23)
        Me.TB_GH_B.TabIndex = 48
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.Blue
        Me.Label10.Location = New System.Drawing.Point(598, 66)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(49, 14)
        Me.Label10.TabIndex = 52
        Me.Label10.Text = "缸号B:"
        '
        'TB_Client_Name_B
        '
        Me.TB_Client_Name_B.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.TB_Client_Name_B.ForeColor = System.Drawing.Color.Blue
        Me.TB_Client_Name_B.Location = New System.Drawing.Point(865, 62)
        Me.TB_Client_Name_B.Name = "TB_Client_Name_B"
        Me.TB_Client_Name_B.ReadOnly = True
        Me.TB_Client_Name_B.Size = New System.Drawing.Size(148, 23)
        Me.TB_Client_Name_B.TabIndex = 47
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(789, 66)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(70, 14)
        Me.Label12.TabIndex = 50
        Me.Label12.Text = "客户名称:"
        '
        'TB_PWeight
        '
        Me.TB_PWeight.Location = New System.Drawing.Point(262, 172)
        Me.TB_PWeight.Name = "TB_PWeight"
        Me.TB_PWeight.ReadOnly = True
        Me.TB_PWeight.Size = New System.Drawing.Size(94, 23)
        Me.TB_PWeight.TabIndex = 45
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(186, 176)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(70, 14)
        Me.Label31.TabIndex = 46
        Me.Label31.Text = "胚布重量:"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(181, 18)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(49, 14)
        Me.Label28.TabIndex = 44
        Me.Label28.Text = "状 态:"
        '
        'BZC_No
        '
        Me.BZC_No.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.BZC_No.ForeColor = System.Drawing.Color.Blue
        Me.BZC_No.Location = New System.Drawing.Point(86, 101)
        Me.BZC_No.Name = "BZC_No"
        Me.BZC_No.ReadOnly = True
        Me.BZC_No.Size = New System.Drawing.Size(94, 23)
        Me.BZC_No.TabIndex = 41
        '
        'LB_State
        '
        Me.LB_State.AutoSize = True
        Me.LB_State.ForeColor = System.Drawing.Color.Blue
        Me.LB_State.Location = New System.Drawing.Point(236, 18)
        Me.LB_State.Name = "LB_State"
        Me.LB_State.Size = New System.Drawing.Size(0, 14)
        Me.LB_State.TabIndex = 43
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(38, 105)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(42, 14)
        Me.Label25.TabIndex = 42
        Me.Label25.Text = "色号:"
        '
        'DTP_Date_KaiDan
        '
        Me.DTP_Date_KaiDan.CustomFormat = "yyyy-MM-dd"
        Me.DTP_Date_KaiDan.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTP_Date_KaiDan.Location = New System.Drawing.Point(86, 136)
        Me.DTP_Date_KaiDan.Name = "DTP_Date_KaiDan"
        Me.DTP_Date_KaiDan.Size = New System.Drawing.Size(94, 23)
        Me.DTP_Date_KaiDan.TabIndex = 38
        '
        'TB_CR_LuoSeBzCount
        '
        Me.TB_CR_LuoSeBzCount.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.TB_CR_LuoSeBzCount.ForeColor = System.Drawing.Color.Blue
        Me.TB_CR_LuoSeBzCount.Location = New System.Drawing.Point(86, 171)
        Me.TB_CR_LuoSeBzCount.Name = "TB_CR_LuoSeBzCount"
        Me.TB_CR_LuoSeBzCount.ReadOnly = True
        Me.TB_CR_LuoSeBzCount.Size = New System.Drawing.Size(94, 23)
        Me.TB_CR_LuoSeBzCount.TabIndex = 29
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(8, 141)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(70, 14)
        Me.Label23.TabIndex = 37
        Me.Label23.Text = "开单日期:"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(12, 175)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(70, 14)
        Me.Label19.TabIndex = 30
        Me.Label19.Text = "落色条数:"
        '
        'TB_ProcessType
        '
        Me.TB_ProcessType.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.TB_ProcessType.ForeColor = System.Drawing.Color.Blue
        Me.TB_ProcessType.Location = New System.Drawing.Point(262, 136)
        Me.TB_ProcessType.Name = "TB_ProcessType"
        Me.TB_ProcessType.ReadOnly = True
        Me.TB_ProcessType.Size = New System.Drawing.Size(130, 23)
        Me.TB_ProcessType.TabIndex = 33
        '
        'TB_BZ_No
        '
        Me.TB_BZ_No.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.TB_BZ_No.ForeColor = System.Drawing.Color.Blue
        Me.TB_BZ_No.Location = New System.Drawing.Point(476, 62)
        Me.TB_BZ_No.Name = "TB_BZ_No"
        Me.TB_BZ_No.ReadOnly = True
        Me.TB_BZ_No.Size = New System.Drawing.Size(111, 23)
        Me.TB_BZ_No.TabIndex = 2
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(187, 140)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(70, 14)
        Me.Label21.TabIndex = 34
        Me.Label21.Text = "加工类别:"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(400, 66)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(70, 14)
        Me.Label17.TabIndex = 21
        Me.Label17.Text = "布类编号:"
        '
        'LabelTitle
        '
        Me.LabelTitle.AutoSize = True
        Me.LabelTitle.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LabelTitle.ForeColor = System.Drawing.Color.Blue
        Me.LabelTitle.Location = New System.Drawing.Point(26, 18)
        Me.LabelTitle.Name = "LabelTitle"
        Me.LabelTitle.Size = New System.Drawing.Size(110, 16)
        Me.LabelTitle.TabIndex = 22
        Me.LabelTitle.Text = "成品重量录入"
        '
        'BZC_Name
        '
        Me.BZC_Name.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.BZC_Name.ForeColor = System.Drawing.Color.Blue
        Me.BZC_Name.Location = New System.Drawing.Point(262, 101)
        Me.BZC_Name.Name = "BZC_Name"
        Me.BZC_Name.ReadOnly = True
        Me.BZC_Name.Size = New System.Drawing.Size(130, 23)
        Me.BZC_Name.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.BackColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(-4, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(1028, 3)
        Me.Label1.TabIndex = 11
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(216, 105)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(42, 14)
        Me.Label13.TabIndex = 13
        Me.Label13.Text = "颜色:"
        '
        'GB_List
        '
        Me.GB_List.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GB_List.Controls.Add(Me.PanelFG)
        Me.GB_List.Controls.Add(Me.Label2)
        Me.GB_List.Location = New System.Drawing.Point(5, 206)
        Me.GB_List.Name = "GB_List"
        Me.GB_List.Size = New System.Drawing.Size(1014, 467)
        Me.GB_List.TabIndex = 0
        Me.GB_List.TabStop = False
        Me.GB_List.Text = "成品重量录入"
        '
        'PanelFG
        '
        Me.PanelFG.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelFG.Controls.Add(Me.SplitContainer1)
        Me.PanelFG.Location = New System.Drawing.Point(6, 22)
        Me.PanelFG.Name = "PanelFG"
        Me.PanelFG.Padding = New System.Windows.Forms.Padding(1)
        Me.PanelFG.Size = New System.Drawing.Size(1002, 445)
        Me.PanelFG.TabIndex = 15
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(1, 1)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.Fg1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer1.Size = New System.Drawing.Size(1000, 443)
        Me.SplitContainer1.SplitterDistance = 261
        Me.SplitContainer1.TabIndex = 2
        '
        'Fg1
        '
        Me.Fg1.AutoAddIndex = True
        Me.Fg1.AutoGenerateColumns = False
        Me.Fg1.AutoResize = False
        Me.Fg1.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.Fg1.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.XpThemes
        Me.Fg1.CanEditing = False
        Me.Fg1.ColumnInfo = resources.GetString("Fg1.ColumnInfo")
        Me.Fg1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Fg1.EditFormat = True
        Me.Fg1.ExtendLastCol = True
        Me.Fg1.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Fg1.ForeColor = System.Drawing.Color.Black
        Me.Fg1.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.Fg1.IsAutoAddRow = True
        Me.Fg1.IsClickStartEdit = False
        Me.Fg1.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.Fg1.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.Fg1.Location = New System.Drawing.Point(0, 0)
        Me.Fg1.Name = "Fg1"
        Me.Fg1.Rows.Count = 10
        Me.Fg1.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.Fg1.Size = New System.Drawing.Size(261, 443)
        Me.Fg1.StartCol = ""
        Me.Fg1.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("Fg1.Styles"))
        Me.Fg1.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.BelowData
        Me.Fg1.TabIndex = 2
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.Fg2)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.Fg3)
        Me.SplitContainer2.Size = New System.Drawing.Size(735, 443)
        Me.SplitContainer2.SplitterDistance = 460
        Me.SplitContainer2.TabIndex = 2
        '
        'Fg2
        '
        Me.Fg2.AutoAddIndex = True
        Me.Fg2.AutoGenerateColumns = False
        Me.Fg2.AutoResize = False
        Me.Fg2.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.Fg2.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.XpThemes
        Me.Fg2.CanEditing = False
        Me.Fg2.ColumnInfo = resources.GetString("Fg2.ColumnInfo")
        Me.Fg2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Fg2.EditFormat = True
        Me.Fg2.ExtendLastCol = True
        Me.Fg2.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Fg2.ForeColor = System.Drawing.Color.Black
        Me.Fg2.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.Fg2.IsAutoAddRow = True
        Me.Fg2.IsClickStartEdit = False
        Me.Fg2.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.Fg2.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.Fg2.Location = New System.Drawing.Point(0, 0)
        Me.Fg2.Name = "Fg2"
        Me.Fg2.Rows.Count = 10
        Me.Fg2.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.Fg2.Size = New System.Drawing.Size(460, 443)
        Me.Fg2.StartCol = ""
        Me.Fg2.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("Fg2.Styles"))
        Me.Fg2.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.BelowData
        Me.Fg2.TabIndex = 1
        '
        'Fg3
        '
        Me.Fg3.AutoAddIndex = True
        Me.Fg3.AutoGenerateColumns = False
        Me.Fg3.AutoResize = False
        Me.Fg3.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.Fg3.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.XpThemes
        Me.Fg3.CanEditing = False
        Me.Fg3.ColumnInfo = resources.GetString("Fg3.ColumnInfo")
        Me.Fg3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Fg3.EditFormat = True
        Me.Fg3.ExtendLastCol = True
        Me.Fg3.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Fg3.ForeColor = System.Drawing.Color.Black
        Me.Fg3.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.Fg3.IsAutoAddRow = True
        Me.Fg3.IsClickStartEdit = False
        Me.Fg3.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.Fg3.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.Fg3.Location = New System.Drawing.Point(0, 0)
        Me.Fg3.Name = "Fg3"
        Me.Fg3.Rows.Count = 10
        Me.Fg3.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.Fg3.Size = New System.Drawing.Size(271, 443)
        Me.Fg3.StartCol = ""
        Me.Fg3.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("Fg3.Styles"))
        Me.Fg3.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.BelowData
        Me.Fg3.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(204, 247)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(0, 14)
        Me.Label2.TabIndex = 9
        '
        'TB_BZ_Name
        '
        Me.TB_BZ_Name.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.TB_BZ_Name.ForeColor = System.Drawing.Color.Blue
        Me.TB_BZ_Name.Location = New System.Drawing.Point(476, 101)
        Me.TB_BZ_Name.Name = "TB_BZ_Name"
        Me.TB_BZ_Name.ReadOnly = True
        Me.TB_BZ_Name.Size = New System.Drawing.Size(111, 23)
        Me.TB_BZ_Name.TabIndex = 1
        '
        'TB_GH
        '
        Me.TB_GH.Location = New System.Drawing.Point(86, 62)
        Me.TB_GH.Name = "TB_GH"
        Me.TB_GH.Size = New System.Drawing.Size(94, 23)
        Me.TB_GH.TabIndex = 1
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(400, 105)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(70, 14)
        Me.Label11.TabIndex = 13
        Me.Label11.Text = "布类名称:"
        '
        'Label_ID
        '
        Me.Label_ID.AutoSize = True
        Me.Label_ID.ForeColor = System.Drawing.Color.Blue
        Me.Label_ID.Location = New System.Drawing.Point(26, 66)
        Me.Label_ID.Name = "Label_ID"
        Me.Label_ID.Size = New System.Drawing.Size(49, 14)
        Me.Label_ID.TabIndex = 14
        Me.Label_ID.Text = "缸号A:"
        '
        'TB_Client_Name
        '
        Me.TB_Client_Name.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.TB_Client_Name.ForeColor = System.Drawing.Color.Blue
        Me.TB_Client_Name.Location = New System.Drawing.Point(262, 62)
        Me.TB_Client_Name.Name = "TB_Client_Name"
        Me.TB_Client_Name.ReadOnly = True
        Me.TB_Client_Name.Size = New System.Drawing.Size(130, 23)
        Me.TB_Client_Name.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(188, 66)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 14)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "客户名称:"
        '
        'TB_TZB
        '
        Me.TB_TZB.Location = New System.Drawing.Point(593, 172)
        Me.TB_TZB.Name = "TB_TZB"
        Me.TB_TZB.ReadOnly = True
        Me.TB_TZB.Size = New System.Drawing.Size(83, 23)
        Me.TB_TZB.TabIndex = 65
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(524, 176)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(63, 14)
        Me.Label15.TabIndex = 66
        Me.Label15.Text = "调整后B:"
        '
        'PanelMain
        '
        Me.PanelMain.Controls.Add(Me.PanelMain1)
        Me.PanelMain.Controls.Add(Me.Tool_Top)
        Me.PanelMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelMain.Location = New System.Drawing.Point(0, 0)
        Me.PanelMain.Name = "PanelMain"
        Me.PanelMain.Size = New System.Drawing.Size(1024, 718)
        Me.PanelMain.TabIndex = 3
        '
        'Timer1
        '
        Me.Timer1.Interval = 1
        '
        'F30202_TZPB_Msg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CanMaxSize = True
        Me.Controls.Add(Me.PanelMain)
        Me.Name = "F30202_TZPB_Msg"
        Me.Size = New System.Drawing.Size(1024, 718)
        Me.Title = "成品重量录入"
        Me.Tool_Top.ResumeLayout(False)
        Me.Tool_Top.PerformLayout()
        Me.PanelMain1.ResumeLayout(False)
        Me.PanelMain1.PerformLayout()
        Me.GB_List.ResumeLayout(False)
        Me.GB_List.PerformLayout()
        Me.PanelFG.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.Fg1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.ResumeLayout(False)
        CType(Me.Fg2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Fg3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelMain.ResumeLayout(False)
        Me.PanelMain.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Tool_Top As System.Windows.Forms.ToolStrip
    Friend WithEvents Cmd_Modify As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Cmd_Exit As System.Windows.Forms.ToolStripButton
    Friend WithEvents PanelMain1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TB_GH As System.Windows.Forms.TextBox
    Friend WithEvents Label_ID As System.Windows.Forms.Label
    Friend WithEvents LabelTitle As System.Windows.Forms.Label
    Friend WithEvents TB_Client_Name As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents BZC_Name As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents GB_List As System.Windows.Forms.GroupBox
    Friend WithEvents PanelFG As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TB_BZ_No As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents TB_BZ_Name As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Fg2 As PClass.FG
    Friend WithEvents TB_ProcessType As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents TB_CR_LuoSeBzCount As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents DTP_Date_KaiDan As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents BZC_No As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents LB_State As System.Windows.Forms.Label
    Friend WithEvents TB_PWeight As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Fg1 As PClass.FG
    Friend WithEvents PanelMain As System.Windows.Forms.Panel
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents TB_PWeight_B As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents BZC_No_B As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DTP_Date_KaiDan_B As System.Windows.Forms.DateTimePicker
    Friend WithEvents TB_CR_LuoSeBzCount_B As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TB_ProcessType_B As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents BZC_Name_B As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TB_GH_B As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TB_Client_Name_B As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Btn_RemoveRow As System.Windows.Forms.ToolStripButton
    Friend WithEvents Fg3 As PClass.FG
    Friend WithEvents TB_TZA As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TB_TZB As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label

End Class
