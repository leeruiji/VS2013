<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F10336_SGGY_Msg
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F10336_SGGY_Msg))
        Me.Tool_Top = New System.Windows.Forms.ToolStrip
        Me.Cmd_Modify = New System.Windows.Forms.ToolStripButton
        Me.Cmd_Del = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.Cmd_AddRow = New System.Windows.Forms.ToolStripButton
        Me.Cmd_RemoveRow = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.Cmd_Audit = New System.Windows.Forms.ToolStripButton
        Me.Cmd_UnAudit = New System.Windows.Forms.ToolStripButton
        Me.Cmd_Exit = New System.Windows.Forms.ToolStripButton
        Me.PanelMain = New System.Windows.Forms.Panel
        Me.TB_Client_Bzc = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.TB_BZ_Name = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.LabelState = New System.Windows.Forms.Label
        Me.LabelStateT = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.CB_GSD = New System.Windows.Forms.ComboBox
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.Fg1 = New PClass.FG
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.Fg2 = New PClass.FG
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.Fg4 = New PClass.FG
        Me.Label9 = New System.Windows.Forms.Label
        Me.TB_FS = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.TB_ZCYL = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.TB_WD = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.TB_JS = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TB_SGGY_Feel = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.DP_Found_Date = New System.Windows.Forms.DateTimePicker
        Me.DP_UPD_DATE = New System.Windows.Forms.DateTimePicker
        Me.TB_Founder = New System.Windows.Forms.TextBox
        Me.TB_UPD_USER = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.TB_Remark = New System.Windows.Forms.TextBox
        Me.TB_NO = New System.Windows.Forms.TextBox
        Me.TB_Name = New System.Windows.Forms.TextBox
        Me.TB_SupplierName = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.LB_FullName = New System.Windows.Forms.Label
        Me.LB_Area = New System.Windows.Forms.Label
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.CB_DyingStep = New System.Windows.Forms.ComboBox
        Me.Fg3 = New PClass.FG
        Me.CB_BZ = New BaseClass.ComBoList
        Me.CB_Client = New BaseClass.ComBoList
        Me.CB_WL_FG4 = New BaseClass.ComBoList
        Me.CB_WL_FG2 = New BaseClass.ComBoList
        Me.CB_WL_FG1 = New BaseClass.ComBoList
        Me.Tool_Top.SuspendLayout()
        Me.PanelMain.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.Fg1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.Fg2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        CType(Me.Fg4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Fg3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Tool_Top
        '
        Me.Tool_Top.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.Tool_Top.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Cmd_Modify, Me.Cmd_Del, Me.ToolStripSeparator2, Me.Cmd_AddRow, Me.Cmd_RemoveRow, Me.ToolStripSeparator1, Me.Cmd_Audit, Me.Cmd_UnAudit, Me.Cmd_Exit})
        Me.Tool_Top.Location = New System.Drawing.Point(0, 0)
        Me.Tool_Top.MinimumSize = New System.Drawing.Size(0, 40)
        Me.Tool_Top.Name = "Tool_Top"
        Me.Tool_Top.Size = New System.Drawing.Size(799, 40)
        Me.Tool_Top.TabIndex = 10
        Me.Tool_Top.Text = "ToolStrip2"
        '
        'Cmd_Modify
        '
        Me.Cmd_Modify.AccessibleDescription = "修改按钮"
        Me.Cmd_Modify.AccessibleName = ""
        Me.Cmd_Modify.Image = Global.DN100_BasicInfo.My.Resources.Resources.Modify
        Me.Cmd_Modify.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Modify.Name = "Cmd_Modify"
        Me.Cmd_Modify.Size = New System.Drawing.Size(60, 37)
        Me.Cmd_Modify.Text = "保存"
        '
        'Cmd_Del
        '
        Me.Cmd_Del.AccessibleDescription = "修改按钮"
        Me.Cmd_Del.AccessibleName = ""
        Me.Cmd_Del.Image = Global.DN100_BasicInfo.My.Resources.Resources.Delete
        Me.Cmd_Del.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Del.Name = "Cmd_Del"
        Me.Cmd_Del.Size = New System.Drawing.Size(60, 37)
        Me.Cmd_Del.Text = "删除"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 40)
        '
        'Cmd_AddRow
        '
        Me.Cmd_AddRow.Image = Global.DN100_BasicInfo.My.Resources.Resources.AddRow
        Me.Cmd_AddRow.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_AddRow.Name = "Cmd_AddRow"
        Me.Cmd_AddRow.Size = New System.Drawing.Size(60, 37)
        Me.Cmd_AddRow.Text = "增行"
        '
        'Cmd_RemoveRow
        '
        Me.Cmd_RemoveRow.Image = CType(resources.GetObject("Cmd_RemoveRow.Image"), System.Drawing.Image)
        Me.Cmd_RemoveRow.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_RemoveRow.Name = "Cmd_RemoveRow"
        Me.Cmd_RemoveRow.Size = New System.Drawing.Size(60, 37)
        Me.Cmd_RemoveRow.Text = "减行"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 40)
        '
        'Cmd_Audit
        '
        Me.Cmd_Audit.Image = Global.DN100_BasicInfo.My.Resources.Resources.apply
        Me.Cmd_Audit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Audit.Name = "Cmd_Audit"
        Me.Cmd_Audit.Size = New System.Drawing.Size(60, 37)
        Me.Cmd_Audit.Text = "审核"
        '
        'Cmd_UnAudit
        '
        Me.Cmd_UnAudit.Image = Global.DN100_BasicInfo.My.Resources.Resources.cancel
        Me.Cmd_UnAudit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_UnAudit.Name = "Cmd_UnAudit"
        Me.Cmd_UnAudit.Size = New System.Drawing.Size(60, 37)
        Me.Cmd_UnAudit.Text = "反审"
        Me.Cmd_UnAudit.Visible = False
        '
        'Cmd_Exit
        '
        Me.Cmd_Exit.Image = Global.DN100_BasicInfo.My.Resources.Resources.Close
        Me.Cmd_Exit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(60, 37)
        Me.Cmd_Exit.Text = "关闭"
        '
        'PanelMain
        '
        Me.PanelMain.Controls.Add(Me.CB_BZ)
        Me.PanelMain.Controls.Add(Me.TB_Client_Bzc)
        Me.PanelMain.Controls.Add(Me.Label10)
        Me.PanelMain.Controls.Add(Me.TB_BZ_Name)
        Me.PanelMain.Controls.Add(Me.Label11)
        Me.PanelMain.Controls.Add(Me.Label12)
        Me.PanelMain.Controls.Add(Me.LabelState)
        Me.PanelMain.Controls.Add(Me.LabelStateT)
        Me.PanelMain.Controls.Add(Me.Label1)
        Me.PanelMain.Controls.Add(Me.CB_GSD)
        Me.PanelMain.Controls.Add(Me.CB_Client)
        Me.PanelMain.Controls.Add(Me.CB_WL_FG4)
        Me.PanelMain.Controls.Add(Me.CB_WL_FG2)
        Me.PanelMain.Controls.Add(Me.TabControl1)
        Me.PanelMain.Controls.Add(Me.Label9)
        Me.PanelMain.Controls.Add(Me.CB_WL_FG1)
        Me.PanelMain.Controls.Add(Me.TB_FS)
        Me.PanelMain.Controls.Add(Me.Label8)
        Me.PanelMain.Controls.Add(Me.TB_ZCYL)
        Me.PanelMain.Controls.Add(Me.Label7)
        Me.PanelMain.Controls.Add(Me.TB_WD)
        Me.PanelMain.Controls.Add(Me.Label4)
        Me.PanelMain.Controls.Add(Me.TB_JS)
        Me.PanelMain.Controls.Add(Me.Label3)
        Me.PanelMain.Controls.Add(Me.TB_SGGY_Feel)
        Me.PanelMain.Controls.Add(Me.Label2)
        Me.PanelMain.Controls.Add(Me.DP_Found_Date)
        Me.PanelMain.Controls.Add(Me.DP_UPD_DATE)
        Me.PanelMain.Controls.Add(Me.TB_Founder)
        Me.PanelMain.Controls.Add(Me.TB_UPD_USER)
        Me.PanelMain.Controls.Add(Me.Label6)
        Me.PanelMain.Controls.Add(Me.Label23)
        Me.PanelMain.Controls.Add(Me.Label5)
        Me.PanelMain.Controls.Add(Me.Label22)
        Me.PanelMain.Controls.Add(Me.TB_Remark)
        Me.PanelMain.Controls.Add(Me.TB_NO)
        Me.PanelMain.Controls.Add(Me.TB_Name)
        Me.PanelMain.Controls.Add(Me.TB_SupplierName)
        Me.PanelMain.Controls.Add(Me.Label19)
        Me.PanelMain.Controls.Add(Me.LB_FullName)
        Me.PanelMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelMain.Location = New System.Drawing.Point(0, 40)
        Me.PanelMain.Name = "PanelMain"
        Me.PanelMain.Padding = New System.Windows.Forms.Padding(2)
        Me.PanelMain.Size = New System.Drawing.Size(799, 619)
        Me.PanelMain.TabIndex = 12
        '
        'TB_Client_Bzc
        '
        Me.TB_Client_Bzc.Location = New System.Drawing.Point(555, 163)
        Me.TB_Client_Bzc.Name = "TB_Client_Bzc"
        Me.TB_Client_Bzc.Size = New System.Drawing.Size(82, 23)
        Me.TB_Client_Bzc.TabIndex = 94
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(479, 166)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(70, 14)
        Me.Label10.TabIndex = 98
        Me.Label10.Text = "布行色号:"
        '
        'TB_BZ_Name
        '
        Me.TB_BZ_Name.Location = New System.Drawing.Point(357, 161)
        Me.TB_BZ_Name.Name = "TB_BZ_Name"
        Me.TB_BZ_Name.ReadOnly = True
        Me.TB_BZ_Name.Size = New System.Drawing.Size(115, 23)
        Me.TB_BZ_Name.TabIndex = 96
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(272, 165)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(70, 14)
        Me.Label11.TabIndex = 97
        Me.Label11.Text = "布种名称:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(43, 166)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(70, 14)
        Me.Label12.TabIndex = 95
        Me.Label12.Text = "布种编号:"
        '
        'LabelState
        '
        Me.LabelState.AutoSize = True
        Me.LabelState.BackColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LabelState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LabelState.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LabelState.ForeColor = System.Drawing.Color.Blue
        Me.LabelState.Location = New System.Drawing.Point(724, 29)
        Me.LabelState.Name = "LabelState"
        Me.LabelState.Size = New System.Drawing.Size(37, 16)
        Me.LabelState.TabIndex = 92
        Me.LabelState.Text = "新建"
        '
        'LabelStateT
        '
        Me.LabelStateT.AutoSize = True
        Me.LabelStateT.Location = New System.Drawing.Point(676, 29)
        Me.LabelStateT.Name = "LabelStateT"
        Me.LabelStateT.Size = New System.Drawing.Size(42, 14)
        Me.LabelStateT.TabIndex = 91
        Me.LabelStateT.Text = "状态:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(507, 120)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 14)
        Me.Label1.TabIndex = 90
        Me.Label1.Text = "水位:"
        '
        'CB_GSD
        '
        Me.CB_GSD.FormattingEnabled = True
        Me.CB_GSD.Items.AddRange(New Object() {"干定", "湿定"})
        Me.CB_GSD.Location = New System.Drawing.Point(555, 114)
        Me.CB_GSD.Name = "CB_GSD"
        Me.CB_GSD.Size = New System.Drawing.Size(115, 22)
        Me.CB_GSD.TabIndex = 89
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(17, 270)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(777, 313)
        Me.TabControl1.TabIndex = 85
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Fg1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 24)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(769, 285)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "白色"
        Me.TabPage1.UseVisualStyleBackColor = True
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
        Me.Fg1.CanEditing = True
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
        Me.Fg1.Location = New System.Drawing.Point(3, 3)
        Me.Fg1.Name = "Fg1"
        Me.Fg1.NoShowMenu = False
        Me.Fg1.Rows.Count = 10
        Me.Fg1.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.Fg1.Size = New System.Drawing.Size(763, 279)
        Me.Fg1.StartCol = "WL_No"
        Me.Fg1.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("Fg1.Styles"))
        Me.Fg1.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.BelowData
        Me.Fg1.TabIndex = 8
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Fg2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 24)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(769, 285)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "杂色"
        Me.TabPage2.UseVisualStyleBackColor = True
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
        Me.Fg2.CanEditing = True
        Me.Fg2.CheckKeyPressEdit = True
        Me.Fg2.ColumnInfo = resources.GetString("Fg2.ColumnInfo")
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
        Me.Fg2.Location = New System.Drawing.Point(3, 3)
        Me.Fg2.Name = "Fg2"
        Me.Fg2.NoShowMenu = False
        Me.Fg2.Rows.Count = 10
        Me.Fg2.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.Fg2.Size = New System.Drawing.Size(763, 281)
        Me.Fg2.StartCol = "WL_No"
        Me.Fg2.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("Fg2.Styles"))
        Me.Fg2.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.BelowData
        Me.Fg2.TabIndex = 9
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.Fg4)
        Me.TabPage3.Location = New System.Drawing.Point(4, 24)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(769, 285)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "黑色"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'Fg4
        '
        Me.Fg4.AddCopyMenu = False
        Me.Fg4.AllowEditing = False
        Me.Fg4.AutoAddIndex = True
        Me.Fg4.AutoGenerateColumns = False
        Me.Fg4.AutoResize = False
        Me.Fg4.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.Fg4.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.XpThemes
        Me.Fg4.CanEditing = True
        Me.Fg4.CheckKeyPressEdit = True
        Me.Fg4.ColumnInfo = resources.GetString("Fg4.ColumnInfo")
        Me.Fg4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Fg4.EditFormat = True
        Me.Fg4.ExtendLastCol = True
        Me.Fg4.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Fg4.ForeColor = System.Drawing.Color.Black
        Me.Fg4.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.Fg4.IsAutoAddRow = True
        Me.Fg4.IsClickStartEdit = True
        Me.Fg4.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.Fg4.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.Fg4.Location = New System.Drawing.Point(3, 3)
        Me.Fg4.Name = "Fg4"
        Me.Fg4.NoShowMenu = False
        Me.Fg4.Rows.Count = 10
        Me.Fg4.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.Fg4.Size = New System.Drawing.Size(763, 281)
        Me.Fg4.StartCol = "WL_No"
        Me.Fg4.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("Fg4.Styles"))
        Me.Fg4.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.BelowData
        Me.Fg4.TabIndex = 10
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(507, 24)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(42, 14)
        Me.Label9.TabIndex = 83
        Me.Label9.Text = "客户:"
        '
        'TB_FS
        '
        Me.TB_FS.Location = New System.Drawing.Point(555, 66)
        Me.TB_FS.Name = "TB_FS"
        Me.TB_FS.Size = New System.Drawing.Size(116, 23)
        Me.TB_FS.TabIndex = 4
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(507, 70)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(42, 14)
        Me.Label8.TabIndex = 67
        Me.Label8.Text = "风速:"
        '
        'TB_ZCYL
        '
        Me.TB_ZCYL.Location = New System.Drawing.Point(358, 66)
        Me.TB_ZCYL.Name = "TB_ZCYL"
        Me.TB_ZCYL.Size = New System.Drawing.Size(114, 23)
        Me.TB_ZCYL.TabIndex = 7
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(282, 70)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(70, 14)
        Me.Label7.TabIndex = 65
        Me.Label7.Text = "轧车压力:"
        '
        'TB_WD
        '
        Me.TB_WD.Location = New System.Drawing.Point(357, 114)
        Me.TB_WD.Name = "TB_WD"
        Me.TB_WD.Size = New System.Drawing.Size(115, 23)
        Me.TB_WD.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(300, 120)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 14)
        Me.Label4.TabIndex = 63
        Me.Label4.Text = "温度:"
        '
        'TB_JS
        '
        Me.TB_JS.Location = New System.Drawing.Point(120, 117)
        Me.TB_JS.Name = "TB_JS"
        Me.TB_JS.Size = New System.Drawing.Size(111, 23)
        Me.TB_JS.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(69, 121)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 14)
        Me.Label3.TabIndex = 61
        Me.Label3.Text = "机速:"
        '
        'TB_SGGY_Feel
        '
        Me.TB_SGGY_Feel.Location = New System.Drawing.Point(120, 67)
        Me.TB_SGGY_Feel.Name = "TB_SGGY_Feel"
        Me.TB_SGGY_Feel.Size = New System.Drawing.Size(111, 23)
        Me.TB_SGGY_Feel.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(41, 76)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 14)
        Me.Label2.TabIndex = 57
        Me.Label2.Text = "工艺手感:"
        '
        'DP_Found_Date
        '
        Me.DP_Found_Date.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.DP_Found_Date.Enabled = False
        Me.DP_Found_Date.Location = New System.Drawing.Point(889, 594)
        Me.DP_Found_Date.Name = "DP_Found_Date"
        Me.DP_Found_Date.Size = New System.Drawing.Size(115, 23)
        Me.DP_Found_Date.TabIndex = 28
        Me.DP_Found_Date.Visible = False
        '
        'DP_UPD_DATE
        '
        Me.DP_UPD_DATE.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.DP_UPD_DATE.Enabled = False
        Me.DP_UPD_DATE.Location = New System.Drawing.Point(889, 558)
        Me.DP_UPD_DATE.Name = "DP_UPD_DATE"
        Me.DP_UPD_DATE.Size = New System.Drawing.Size(115, 23)
        Me.DP_UPD_DATE.TabIndex = 27
        Me.DP_UPD_DATE.Visible = False
        '
        'TB_Founder
        '
        Me.TB_Founder.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TB_Founder.Location = New System.Drawing.Point(667, 597)
        Me.TB_Founder.Name = "TB_Founder"
        Me.TB_Founder.ReadOnly = True
        Me.TB_Founder.Size = New System.Drawing.Size(115, 23)
        Me.TB_Founder.TabIndex = 25
        Me.TB_Founder.Visible = False
        '
        'TB_UPD_USER
        '
        Me.TB_UPD_USER.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TB_UPD_USER.Location = New System.Drawing.Point(667, 560)
        Me.TB_UPD_USER.Name = "TB_UPD_USER"
        Me.TB_UPD_USER.ReadOnly = True
        Me.TB_UPD_USER.Size = New System.Drawing.Size(115, 23)
        Me.TB_UPD_USER.TabIndex = 26
        Me.TB_UPD_USER.Visible = False
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(820, 600)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(70, 14)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "创建时间:"
        Me.Label6.Visible = False
        '
        'Label23
        '
        Me.Label23.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(792, 562)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(98, 14)
        Me.Label23.TabIndex = 18
        Me.Label23.Text = "最后修改时间:"
        Me.Label23.Visible = False
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(606, 600)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 14)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "创建人:"
        Me.Label5.Visible = False
        '
        'Label22
        '
        Me.Label22.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(578, 567)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(84, 14)
        Me.Label22.TabIndex = 16
        Me.Label22.Text = "最后修改人:"
        Me.Label22.Visible = False
        '
        'TB_Remark
        '
        Me.TB_Remark.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TB_Remark.Location = New System.Drawing.Point(119, 191)
        Me.TB_Remark.Multiline = True
        Me.TB_Remark.Name = "TB_Remark"
        Me.TB_Remark.Size = New System.Drawing.Size(551, 64)
        Me.TB_Remark.TabIndex = 8
        '
        'TB_NO
        '
        Me.TB_NO.Location = New System.Drawing.Point(120, 21)
        Me.TB_NO.Name = "TB_NO"
        Me.TB_NO.Size = New System.Drawing.Size(111, 23)
        Me.TB_NO.TabIndex = 0
        '
        'TB_Name
        '
        Me.TB_Name.Location = New System.Drawing.Point(358, 21)
        Me.TB_Name.Name = "TB_Name"
        Me.TB_Name.Size = New System.Drawing.Size(114, 23)
        Me.TB_Name.TabIndex = 1
        '
        'TB_SupplierName
        '
        Me.TB_SupplierName.AutoSize = True
        Me.TB_SupplierName.Location = New System.Drawing.Point(43, 24)
        Me.TB_SupplierName.Name = "TB_SupplierName"
        Me.TB_SupplierName.Size = New System.Drawing.Size(70, 14)
        Me.TB_SupplierName.TabIndex = 7
        Me.TB_SupplierName.Text = "工艺编号:"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(71, 194)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(42, 14)
        Me.Label19.TabIndex = 6
        Me.Label19.Text = "备注:"
        '
        'LB_FullName
        '
        Me.LB_FullName.AutoSize = True
        Me.LB_FullName.Location = New System.Drawing.Point(282, 24)
        Me.LB_FullName.Name = "LB_FullName"
        Me.LB_FullName.Size = New System.Drawing.Size(70, 14)
        Me.LB_FullName.TabIndex = 5
        Me.LB_FullName.Text = "工艺名称:"
        '
        'LB_Area
        '
        Me.LB_Area.AutoSize = True
        Me.LB_Area.Location = New System.Drawing.Point(265, 34)
        Me.LB_Area.Name = "LB_Area"
        Me.LB_Area.Size = New System.Drawing.Size(70, 14)
        Me.LB_Area.TabIndex = 7
        Me.LB_Area.Text = "默认仓库:"
        Me.LB_Area.Visible = False
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'CB_DyingStep
        '
        Me.CB_DyingStep.FormattingEnabled = True
        Me.CB_DyingStep.Location = New System.Drawing.Point(467, 12)
        Me.CB_DyingStep.Name = "CB_DyingStep"
        Me.CB_DyingStep.Size = New System.Drawing.Size(111, 22)
        Me.CB_DyingStep.TabIndex = 54
        Me.CB_DyingStep.Visible = False
        '
        'Fg3
        '
        Me.Fg3.AddCopyMenu = False
        Me.Fg3.AllowEditing = False
        Me.Fg3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Fg3.AutoAddIndex = True
        Me.Fg3.AutoGenerateColumns = False
        Me.Fg3.AutoResize = False
        Me.Fg3.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.Fg3.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.XpThemes
        Me.Fg3.CanEditing = True
        Me.Fg3.CheckKeyPressEdit = True
        Me.Fg3.ColumnInfo = resources.GetString("Fg3.ColumnInfo")
        Me.Fg3.EditFormat = True
        Me.Fg3.ExtendLastCol = True
        Me.Fg3.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Fg3.ForeColor = System.Drawing.Color.Black
        Me.Fg3.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.Fg3.IsAutoAddRow = True
        Me.Fg3.IsClickStartEdit = True
        Me.Fg3.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.Fg3.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.Fg3.Location = New System.Drawing.Point(3, 3)
        Me.Fg3.Name = "Fg3"
        Me.Fg3.NoShowMenu = False
        Me.Fg3.Rows.Count = 10
        Me.Fg3.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.Fg3.Size = New System.Drawing.Size(794, 361)
        Me.Fg3.StartCol = "WL_No"
        Me.Fg3.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("Fg3.Styles"))
        Me.Fg3.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.BelowData
        Me.Fg3.TabIndex = 9
        '
        'CB_BZ
        '
        Me.CB_BZ.Child = "ComboBZ"
        Me.CB_BZ.FormattingEnabled = True
        Me.CB_BZ.IDAsInt = CType(0, Long)
        Me.CB_BZ.IDValue = ""
        Me.CB_BZ.IsKeyDownAutoSearch = True
        Me.CB_BZ.IsSelectName = False
        Me.CB_BZ.IsTBLostFocusSelOne = True
        Me.CB_BZ.Location = New System.Drawing.Point(119, 162)
        Me.CB_BZ.Name = "CB_BZ"
        Me.CB_BZ.SearchType = BaseClass.cSearchType.ENum_SearchType.ALL
        Me.CB_BZ.Size = New System.Drawing.Size(107, 22)
        Me.CB_BZ.TabIndex = 93
        '
        'CB_Client
        '
        Me.CB_Client.Child = "ComboClient"
        Me.CB_Client.FormattingEnabled = True
        Me.CB_Client.IDAsInt = CType(0, Long)
        Me.CB_Client.IDValue = ""
        Me.CB_Client.IsKeyDownAutoSearch = True
        Me.CB_Client.IsTBLostFocusSelOne = True
        Me.CB_Client.Location = New System.Drawing.Point(555, 21)
        Me.CB_Client.Name = "CB_Client"
        Me.CB_Client.SearchType = BaseClass.cSearchType.ENum_SearchType.ALL
        Me.CB_Client.Size = New System.Drawing.Size(115, 22)
        Me.CB_Client.TabIndex = 88
        '
        'CB_WL_FG4
        '
        Me.CB_WL_FG4.Child = "ComboWL"
        Me.CB_WL_FG4.FormattingEnabled = True
        Me.CB_WL_FG4.IDAsInt = CType(0, Long)
        Me.CB_WL_FG4.IDValue = ""
        Me.CB_WL_FG4.IsKeyDownAutoSearch = True
        Me.CB_WL_FG4.IsSelectName = False
        Me.CB_WL_FG4.Location = New System.Drawing.Point(581, -6)
        Me.CB_WL_FG4.Name = "CB_WL_FG4"
        Me.CB_WL_FG4.SearchID = "and IsSGL=1"
        Me.CB_WL_FG4.SearchType = BaseClass.cSearchType.ENum_SearchType.Add_SQL
        Me.CB_WL_FG4.Size = New System.Drawing.Size(105, 22)
        Me.CB_WL_FG4.TabIndex = 87
        Me.CB_WL_FG4.Visible = False
        '
        'CB_WL_FG2
        '
        Me.CB_WL_FG2.Child = "ComboWL"
        Me.CB_WL_FG2.FormattingEnabled = True
        Me.CB_WL_FG2.IDAsInt = CType(0, Long)
        Me.CB_WL_FG2.IDValue = ""
        Me.CB_WL_FG2.IsKeyDownAutoSearch = True
        Me.CB_WL_FG2.IsSelectName = False
        Me.CB_WL_FG2.Location = New System.Drawing.Point(444, -6)
        Me.CB_WL_FG2.Name = "CB_WL_FG2"
        Me.CB_WL_FG2.SearchID = "and IsSGL=1"
        Me.CB_WL_FG2.SearchType = BaseClass.cSearchType.ENum_SearchType.Add_SQL
        Me.CB_WL_FG2.Size = New System.Drawing.Size(105, 22)
        Me.CB_WL_FG2.TabIndex = 86
        Me.CB_WL_FG2.Visible = False
        '
        'CB_WL_FG1
        '
        Me.CB_WL_FG1.Child = "ComboWL"
        Me.CB_WL_FG1.FormattingEnabled = True
        Me.CB_WL_FG1.IDAsInt = CType(0, Long)
        Me.CB_WL_FG1.IDValue = ""
        Me.CB_WL_FG1.IsKeyDownAutoSearch = True
        Me.CB_WL_FG1.IsSelectName = False
        Me.CB_WL_FG1.Location = New System.Drawing.Point(303, -9)
        Me.CB_WL_FG1.Name = "CB_WL_FG1"
        Me.CB_WL_FG1.SearchID = "and IsSGL=1"
        Me.CB_WL_FG1.SearchType = BaseClass.cSearchType.ENum_SearchType.Add_SQL
        Me.CB_WL_FG1.Size = New System.Drawing.Size(105, 22)
        Me.CB_WL_FG1.TabIndex = 82
        Me.CB_WL_FG1.Visible = False
        '
        'F10336_SGGY_Msg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CanMaxSize = True
        Me.Controls.Add(Me.CB_DyingStep)
        Me.Controls.Add(Me.PanelMain)
        Me.Controls.Add(Me.Tool_Top)
        Me.Controls.Add(Me.LB_Area)
        Me.Name = "F10336_SGGY_Msg"
        Me.Size = New System.Drawing.Size(799, 659)
        Me.Title = "工艺详细信息"
        Me.Tool_Top.ResumeLayout(False)
        Me.Tool_Top.PerformLayout()
        Me.PanelMain.ResumeLayout(False)
        Me.PanelMain.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.Fg1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.Fg2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        CType(Me.Fg4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Fg3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Tool_Top As System.Windows.Forms.ToolStrip
    Friend WithEvents Cmd_Modify As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_Del As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Cmd_Exit As System.Windows.Forms.ToolStripButton
    Friend WithEvents PanelMain As System.Windows.Forms.Panel
    Friend WithEvents TB_Name As System.Windows.Forms.TextBox
    Friend WithEvents LB_FullName As System.Windows.Forms.Label
    Friend WithEvents TB_Remark As System.Windows.Forms.TextBox
    Friend WithEvents TB_NO As System.Windows.Forms.TextBox
    Friend WithEvents LB_Area As System.Windows.Forms.Label
    Friend WithEvents TB_SupplierName As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents DP_Found_Date As System.Windows.Forms.DateTimePicker
    Friend WithEvents DP_UPD_DATE As System.Windows.Forms.DateTimePicker
    Friend WithEvents TB_Founder As System.Windows.Forms.TextBox
    Friend WithEvents TB_UPD_USER As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Fg1 As PClass.FG
    Friend WithEvents Cmd_AddRow As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_RemoveRow As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CB_DyingStep As System.Windows.Forms.ComboBox
    Friend WithEvents TB_SGGY_Feel As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TB_ZCYL As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TB_WD As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TB_JS As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TB_FS As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents CB_WL_FG1 As BaseClass.ComBoList
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Fg2 As PClass.FG
    Friend WithEvents Fg3 As PClass.FG
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents Fg4 As PClass.FG
    Friend WithEvents CB_WL_FG4 As BaseClass.ComBoList
    Friend WithEvents CB_WL_FG2 As BaseClass.ComBoList
    Friend WithEvents CB_Client As BaseClass.ComBoList
    Friend WithEvents CB_GSD As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LabelState As System.Windows.Forms.Label
    Friend WithEvents LabelStateT As System.Windows.Forms.Label
    Friend WithEvents Cmd_Audit As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_UnAudit As System.Windows.Forms.ToolStripButton
    Friend WithEvents CB_BZ As BaseClass.ComBoList
    Friend WithEvents TB_Client_Bzc As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TB_BZ_Name As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label

End Class
