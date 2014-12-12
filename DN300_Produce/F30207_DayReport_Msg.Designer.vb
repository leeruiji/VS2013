<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F30207_DayReport_Msg
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F30207_DayReport_Msg))
        Me.Tool_Top = New System.Windows.Forms.ToolStrip
        Me.Cmd_Modify = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.Cmd_AddRow = New System.Windows.Forms.ToolStripButton
        Me.Cmd_RemoveRow = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.Cmd_Preview = New System.Windows.Forms.ToolStripButton
        Me.Cmd_Count = New System.Windows.Forms.ToolStripButton
        Me.Cmd_SetInValid = New System.Windows.Forms.ToolStripButton
        Me.Cmd_SetValid = New System.Windows.Forms.ToolStripButton
        Me.Cmd_Del = New System.Windows.Forms.ToolStripButton
        Me.Cmd_Audit = New System.Windows.Forms.ToolStripButton
        Me.Cmd_UnAudit = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.Cmd_Print = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.Cmd_Exit = New System.Windows.Forms.ToolStripButton
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel
        Me.LabelTitle = New System.Windows.Forms.Label
        Me.LabelStateT = New System.Windows.Forms.Label
        Me.LabelState = New System.Windows.Forms.Label
        Me.GB_List = New System.Windows.Forms.GroupBox
        Me.TC_List = New System.Windows.Forms.TabControl
        Me.Tab1 = New System.Windows.Forms.TabPage
        Me.Fg1 = New PClass.FG
        Me.SumFG1 = New BaseClass.SumFG
        Me.TB_ReRemarks = New BaseClass.TitleTextBox
        Me.Tab2 = New System.Windows.Forms.TabPage
        Me.Fg2 = New PClass.FG
        Me.Tab3 = New System.Windows.Forms.TabPage
        Me.Fg3 = New PClass.FG
        Me.SumFG2 = New BaseClass.SumFG
        Me.TB_DXRemarks = New BaseClass.TitleTextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label_ID = New System.Windows.Forms.Label
        Me.TB_ID = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.DTP_sDate = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.TB_DayReCrop = New System.Windows.Forms.TextBox
        Me.CB_Project = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.TB_Upd_Dept = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.TB_State_User = New System.Windows.Forms.TextBox
        Me.TB_SumRePercent = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.TB_Upd_User = New System.Windows.Forms.TextBox
        Me.SP = New System.Windows.Forms.SplitContainer
        Me.TB_DayCrop = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.TB_SumCrop = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.TB_SumReCrop = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.TB_DayRePercent = New System.Windows.Forms.TextBox
        Me.Label_ClientBill = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.TB_LJJCWeight = New System.Windows.Forms.TextBox
        Me.TB_LJJZJWeight = New System.Windows.Forms.TextBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.TB_RJZJWeight = New System.Windows.Forms.TextBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.TB_RJSWeight = New System.Windows.Forms.TextBox
        Me.TB_DXCPLJ = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.TB_DXCPRJ = New System.Windows.Forms.TextBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.TB_JZJForPercent = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.TB_JSFORPercent = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.TB_LJJZJGs = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.TB_LJJCGs = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.TB_RJZJPercent = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.TB_RJSPercent = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.TB_RJZJGs = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.TB_RJSGs = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.PanelMain = New System.Windows.Forms.Panel
        Me.TB_Remarks = New BaseClass.TitleTextBox
        Me.Tool_Top.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.GB_List.SuspendLayout()
        Me.TC_List.SuspendLayout()
        Me.Tab1.SuspendLayout()
        CType(Me.Fg1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tab2.SuspendLayout()
        CType(Me.Fg2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tab3.SuspendLayout()
        CType(Me.Fg3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SP.Panel1.SuspendLayout()
        Me.SP.Panel2.SuspendLayout()
        Me.SP.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.PanelMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'Tool_Top
        '
        Me.Tool_Top.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.Tool_Top.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Cmd_Modify, Me.ToolStripSeparator4, Me.Cmd_AddRow, Me.Cmd_RemoveRow, Me.ToolStripSeparator2, Me.ToolStripSeparator1, Me.Cmd_Preview, Me.Cmd_Count, Me.Cmd_SetInValid, Me.Cmd_SetValid, Me.Cmd_Del, Me.Cmd_Audit, Me.Cmd_UnAudit, Me.ToolStripSeparator5, Me.Cmd_Print, Me.ToolStripSeparator3, Me.Cmd_Exit})
        Me.Tool_Top.Location = New System.Drawing.Point(0, 0)
        Me.Tool_Top.MinimumSize = New System.Drawing.Size(0, 40)
        Me.Tool_Top.Name = "Tool_Top"
        Me.Tool_Top.Size = New System.Drawing.Size(900, 40)
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
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 40)
        '
        'Cmd_AddRow
        '
        Me.Cmd_AddRow.Image = Global.DN300_Produce.My.Resources.Resources.AddRow
        Me.Cmd_AddRow.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_AddRow.Name = "Cmd_AddRow"
        Me.Cmd_AddRow.Size = New System.Drawing.Size(57, 37)
        Me.Cmd_AddRow.Text = "增行"
        '
        'Cmd_RemoveRow
        '
        Me.Cmd_RemoveRow.Image = Global.DN300_Produce.My.Resources.Resources.RemoveRow
        Me.Cmd_RemoveRow.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_RemoveRow.Name = "Cmd_RemoveRow"
        Me.Cmd_RemoveRow.Size = New System.Drawing.Size(57, 37)
        Me.Cmd_RemoveRow.Text = "减行"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 40)
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 40)
        '
        'Cmd_Preview
        '
        Me.Cmd_Preview.Image = Global.DN300_Produce.My.Resources.Resources.Print_preview
        Me.Cmd_Preview.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Preview.Name = "Cmd_Preview"
        Me.Cmd_Preview.Size = New System.Drawing.Size(57, 37)
        Me.Cmd_Preview.Text = "预览"
        '
        'Cmd_Count
        '
        Me.Cmd_Count.Image = Global.DN300_Produce.My.Resources.Resources._8
        Me.Cmd_Count.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Count.Name = "Cmd_Count"
        Me.Cmd_Count.Size = New System.Drawing.Size(57, 37)
        Me.Cmd_Count.Text = "计算"
        '
        'Cmd_SetInValid
        '
        Me.Cmd_SetInValid.AccessibleDescription = "作废按钮"
        Me.Cmd_SetInValid.AccessibleName = ""
        Me.Cmd_SetInValid.Image = Global.DN300_Produce.My.Resources.Resources.InValid
        Me.Cmd_SetInValid.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_SetInValid.Name = "Cmd_SetInValid"
        Me.Cmd_SetInValid.Size = New System.Drawing.Size(57, 37)
        Me.Cmd_SetInValid.Text = "作废"
        Me.Cmd_SetInValid.Visible = False
        '
        'Cmd_SetValid
        '
        Me.Cmd_SetValid.AccessibleDescription = "反作废按钮"
        Me.Cmd_SetValid.AccessibleName = ""
        Me.Cmd_SetValid.Image = Global.DN300_Produce.My.Resources.Resources.SetValid
        Me.Cmd_SetValid.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_SetValid.Name = "Cmd_SetValid"
        Me.Cmd_SetValid.Size = New System.Drawing.Size(69, 37)
        Me.Cmd_SetValid.Text = "反作废"
        Me.Cmd_SetValid.Visible = False
        '
        'Cmd_Del
        '
        Me.Cmd_Del.AccessibleDescription = "修改按钮"
        Me.Cmd_Del.AccessibleName = ""
        Me.Cmd_Del.Image = Global.DN300_Produce.My.Resources.Resources.Delete
        Me.Cmd_Del.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Del.Name = "Cmd_Del"
        Me.Cmd_Del.Size = New System.Drawing.Size(57, 37)
        Me.Cmd_Del.Text = "删除"
        Me.Cmd_Del.Visible = False
        '
        'Cmd_Audit
        '
        Me.Cmd_Audit.Image = Global.DN300_Produce.My.Resources.Resources.apply
        Me.Cmd_Audit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Audit.Name = "Cmd_Audit"
        Me.Cmd_Audit.Size = New System.Drawing.Size(57, 37)
        Me.Cmd_Audit.Text = "审核"
        Me.Cmd_Audit.Visible = False
        '
        'Cmd_UnAudit
        '
        Me.Cmd_UnAudit.Image = Global.DN300_Produce.My.Resources.Resources.cancel
        Me.Cmd_UnAudit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_UnAudit.Name = "Cmd_UnAudit"
        Me.Cmd_UnAudit.Size = New System.Drawing.Size(57, 37)
        Me.Cmd_UnAudit.Text = "反审"
        Me.Cmd_UnAudit.Visible = False
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 40)
        '
        'Cmd_Print
        '
        Me.Cmd_Print.Image = Global.DN300_Produce.My.Resources.Resources.print
        Me.Cmd_Print.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Print.Name = "Cmd_Print"
        Me.Cmd_Print.Size = New System.Drawing.Size(57, 37)
        Me.Cmd_Print.Text = "打印"
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
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.LabelTitle)
        Me.FlowLayoutPanel1.Controls.Add(Me.LabelStateT)
        Me.FlowLayoutPanel1.Controls.Add(Me.LabelState)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(9, 13)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(377, 19)
        Me.FlowLayoutPanel1.TabIndex = 6
        '
        'LabelTitle
        '
        Me.LabelTitle.AutoSize = True
        Me.LabelTitle.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LabelTitle.ForeColor = System.Drawing.Color.Blue
        Me.LabelTitle.Location = New System.Drawing.Point(3, 0)
        Me.LabelTitle.Name = "LabelTitle"
        Me.LabelTitle.Size = New System.Drawing.Size(93, 16)
        Me.LabelTitle.TabIndex = 22
        Me.LabelTitle.Text = "染部日报表"
        '
        'LabelStateT
        '
        Me.LabelStateT.AutoSize = True
        Me.LabelStateT.Location = New System.Drawing.Point(102, 0)
        Me.LabelStateT.Name = "LabelStateT"
        Me.LabelStateT.Size = New System.Drawing.Size(42, 14)
        Me.LabelStateT.TabIndex = 32
        Me.LabelStateT.Text = "状态:"
        '
        'LabelState
        '
        Me.LabelState.AutoSize = True
        Me.LabelState.BackColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LabelState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LabelState.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LabelState.ForeColor = System.Drawing.Color.Blue
        Me.LabelState.Location = New System.Drawing.Point(150, 0)
        Me.LabelState.Name = "LabelState"
        Me.LabelState.Size = New System.Drawing.Size(37, 16)
        Me.LabelState.TabIndex = 33
        Me.LabelState.Text = "新建"
        '
        'GB_List
        '
        Me.GB_List.Controls.Add(Me.TC_List)
        Me.GB_List.Controls.Add(Me.Label2)
        Me.GB_List.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GB_List.Location = New System.Drawing.Point(0, 134)
        Me.GB_List.Name = "GB_List"
        Me.GB_List.Size = New System.Drawing.Size(890, 369)
        Me.GB_List.TabIndex = 5
        Me.GB_List.TabStop = False
        '
        'TC_List
        '
        Me.TC_List.Controls.Add(Me.Tab1)
        Me.TC_List.Controls.Add(Me.Tab2)
        Me.TC_List.Controls.Add(Me.Tab3)
        Me.TC_List.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TC_List.Location = New System.Drawing.Point(3, 19)
        Me.TC_List.Name = "TC_List"
        Me.TC_List.SelectedIndex = 0
        Me.TC_List.Size = New System.Drawing.Size(884, 347)
        Me.TC_List.TabIndex = 14
        '
        'Tab1
        '
        Me.Tab1.Controls.Add(Me.Fg1)
        Me.Tab1.Controls.Add(Me.SumFG1)
        Me.Tab1.Controls.Add(Me.TB_ReRemarks)
        Me.Tab1.Location = New System.Drawing.Point(4, 23)
        Me.Tab1.Name = "Tab1"
        Me.Tab1.Padding = New System.Windows.Forms.Padding(3)
        Me.Tab1.Size = New System.Drawing.Size(876, 320)
        Me.Tab1.TabIndex = 0
        Me.Tab1.Text = "染部回修明细"
        Me.Tab1.UseVisualStyleBackColor = True
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
        Me.Fg1.Cursor = System.Windows.Forms.Cursors.Default
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
        Me.Fg1.Size = New System.Drawing.Size(870, 268)
        Me.Fg1.StartCol = ""
        Me.Fg1.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("Fg1.Styles"))
        Me.Fg1.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.BelowData
        Me.Fg1.TabIndex = 1
        '
        'SumFG1
        '
        Me.SumFG1.BackColor = System.Drawing.Color.Cornsilk
        Me.SumFG1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SumFG1.ColForSum.Add("Num")
        Me.SumFG1.ColForSum.Add("Weight")
        Me.SumFG1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.SumFG1.FG = Me.Fg1
        Me.SumFG1.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.SumFG1.ForeColor = System.Drawing.Color.Blue
        Me.SumFG1.Location = New System.Drawing.Point(3, 271)
        Me.SumFG1.Name = "SumFG1"
        Me.SumFG1.Size = New System.Drawing.Size(870, 23)
        Me.SumFG1.TabIndex = 5
        '
        'TB_ReRemarks
        '
        Me.TB_ReRemarks.AutoFixSize = True
        Me.TB_ReRemarks.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TB_ReRemarks.Font_Text = New System.Drawing.Font("宋体", 10.5!)
        Me.TB_ReRemarks.ForeColor_Text = System.Drawing.SystemColors.WindowText
        Me.TB_ReRemarks.FormatStr = ""
        Me.TB_ReRemarks.IsShowTitle = True
        Me.TB_ReRemarks.Location = New System.Drawing.Point(3, 294)
        Me.TB_ReRemarks.Name = "TB_ReRemarks"
        Me.TB_ReRemarks.Readonly = False
        Me.TB_ReRemarks.Size = New System.Drawing.Size(870, 23)
        Me.TB_ReRemarks.TabIndex = 6
        Me.TB_ReRemarks.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.TB_ReRemarks.Title = "备注:"
        '
        'Tab2
        '
        Me.Tab2.Controls.Add(Me.Fg2)
        Me.Tab2.Location = New System.Drawing.Point(4, 23)
        Me.Tab2.Name = "Tab2"
        Me.Tab2.Padding = New System.Windows.Forms.Padding(3)
        Me.Tab2.Size = New System.Drawing.Size(876, 320)
        Me.Tab2.TabIndex = 1
        Me.Tab2.Text = "质量问题分析表"
        Me.Tab2.UseVisualStyleBackColor = True
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
        Me.Fg2.Cursor = System.Windows.Forms.Cursors.Default
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
        Me.Fg2.Size = New System.Drawing.Size(870, 314)
        Me.Fg2.StartCol = ""
        Me.Fg2.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("Fg2.Styles"))
        Me.Fg2.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.BelowData
        Me.Fg2.TabIndex = 2
        '
        'Tab3
        '
        Me.Tab3.Controls.Add(Me.Fg3)
        Me.Tab3.Controls.Add(Me.SumFG2)
        Me.Tab3.Controls.Add(Me.TB_DXRemarks)
        Me.Tab3.Location = New System.Drawing.Point(4, 23)
        Me.Tab3.Name = "Tab3"
        Me.Tab3.Padding = New System.Windows.Forms.Padding(3)
        Me.Tab3.Size = New System.Drawing.Size(876, 320)
        Me.Tab3.TabIndex = 2
        Me.Tab3.Text = "定型加色明细表"
        Me.Tab3.UseVisualStyleBackColor = True
        '
        'Fg3
        '
        Me.Fg3.AddCopyMenu = False
        Me.Fg3.AllowEditing = False
        Me.Fg3.AutoAddIndex = True
        Me.Fg3.AutoGenerateColumns = False
        Me.Fg3.AutoResize = False
        Me.Fg3.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.Fg3.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.XpThemes
        Me.Fg3.CanEditing = True
        Me.Fg3.CheckKeyPressEdit = True
        Me.Fg3.ColumnInfo = resources.GetString("Fg3.ColumnInfo")
        Me.Fg3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Fg3.Dock = System.Windows.Forms.DockStyle.Fill
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
        Me.Fg3.Size = New System.Drawing.Size(870, 268)
        Me.Fg3.StartCol = ""
        Me.Fg3.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("Fg3.Styles"))
        Me.Fg3.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.BelowData
        Me.Fg3.TabIndex = 2
        '
        'SumFG2
        '
        Me.SumFG2.BackColor = System.Drawing.Color.Cornsilk
        Me.SumFG2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SumFG2.ColForSum.Add("Qty")
        Me.SumFG2.ColForSum.Add("Weight")
        Me.SumFG2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.SumFG2.FG = Me.Fg3
        Me.SumFG2.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.SumFG2.ForeColor = System.Drawing.Color.Blue
        Me.SumFG2.Location = New System.Drawing.Point(3, 271)
        Me.SumFG2.Name = "SumFG2"
        Me.SumFG2.Size = New System.Drawing.Size(870, 23)
        Me.SumFG2.TabIndex = 3
        '
        'TB_DXRemarks
        '
        Me.TB_DXRemarks.AutoFixSize = True
        Me.TB_DXRemarks.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TB_DXRemarks.Font_Text = New System.Drawing.Font("宋体", 10.5!)
        Me.TB_DXRemarks.ForeColor_Text = System.Drawing.SystemColors.WindowText
        Me.TB_DXRemarks.FormatStr = ""
        Me.TB_DXRemarks.IsShowTitle = True
        Me.TB_DXRemarks.Location = New System.Drawing.Point(3, 294)
        Me.TB_DXRemarks.Name = "TB_DXRemarks"
        Me.TB_DXRemarks.Readonly = False
        Me.TB_DXRemarks.Size = New System.Drawing.Size(870, 23)
        Me.TB_DXRemarks.TabIndex = 4
        Me.TB_DXRemarks.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.TB_DXRemarks.Title = "备注:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(204, 247)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(0, 14)
        Me.Label2.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.BackColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(-4, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(902, 3)
        Me.Label1.TabIndex = 11
        '
        'Label_ID
        '
        Me.Label_ID.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label_ID.AutoSize = True
        Me.Label_ID.ForeColor = System.Drawing.Color.Blue
        Me.Label_ID.Location = New System.Drawing.Point(715, 16)
        Me.Label_ID.Name = "Label_ID"
        Me.Label_ID.Size = New System.Drawing.Size(42, 14)
        Me.Label_ID.TabIndex = 14
        Me.Label_ID.Text = "单号:"
        '
        'TB_ID
        '
        Me.TB_ID.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TB_ID.Location = New System.Drawing.Point(763, 11)
        Me.TB_ID.Name = "TB_ID"
        Me.TB_ID.Size = New System.Drawing.Size(121, 23)
        Me.TB_ID.TabIndex = 0
        Me.TB_ID.Text = "系统自动生成单号"
        '
        'Label16
        '
        Me.Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(537, 16)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(42, 14)
        Me.Label16.TabIndex = 14
        Me.Label16.Text = "日期:"
        '
        'DTP_sDate
        '
        Me.DTP_sDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DTP_sDate.CustomFormat = "yyyy年MM月dd日"
        Me.DTP_sDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTP_sDate.Location = New System.Drawing.Point(585, 11)
        Me.DTP_sDate.Name = "DTP_sDate"
        Me.DTP_sDate.Size = New System.Drawing.Size(124, 23)
        Me.DTP_sDate.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(284, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(112, 14)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "日回修产量(KG):"
        '
        'TB_DayReCrop
        '
        Me.TB_DayReCrop.Location = New System.Drawing.Point(402, 17)
        Me.TB_DayReCrop.Name = "TB_DayReCrop"
        Me.TB_DayReCrop.ReadOnly = True
        Me.TB_DayReCrop.Size = New System.Drawing.Size(146, 23)
        Me.TB_DayReCrop.TabIndex = 2
        '
        'CB_Project
        '
        Me.CB_Project.DisplayMember = "ReProject_Name"
        Me.CB_Project.FormattingEnabled = True
        Me.CB_Project.Location = New System.Drawing.Point(438, 10)
        Me.CB_Project.Name = "CB_Project"
        Me.CB_Project.Size = New System.Drawing.Size(89, 22)
        Me.CB_Project.TabIndex = 1
        Me.CB_Project.ValueMember = "ID"
        Me.CB_Project.Visible = False
        '
        'Label8
        '
        Me.Label8.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(16, 653)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(70, 14)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "制单部门:"
        '
        'TB_Upd_Dept
        '
        Me.TB_Upd_Dept.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TB_Upd_Dept.Location = New System.Drawing.Point(84, 649)
        Me.TB_Upd_Dept.Name = "TB_Upd_Dept"
        Me.TB_Upd_Dept.ReadOnly = True
        Me.TB_Upd_Dept.Size = New System.Drawing.Size(96, 23)
        Me.TB_Upd_Dept.TabIndex = 0
        '
        'Label9
        '
        Me.Label9.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(380, 653)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(56, 14)
        Me.Label9.TabIndex = 13
        Me.Label9.Text = "审核人:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TB_State_User
        '
        Me.TB_State_User.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TB_State_User.Location = New System.Drawing.Point(438, 649)
        Me.TB_State_User.Name = "TB_State_User"
        Me.TB_State_User.ReadOnly = True
        Me.TB_State_User.Size = New System.Drawing.Size(96, 23)
        Me.TB_State_User.TabIndex = 1
        '
        'TB_SumRePercent
        '
        Me.TB_SumRePercent.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TB_SumRePercent.Location = New System.Drawing.Point(684, 56)
        Me.TB_SumRePercent.Name = "TB_SumRePercent"
        Me.TB_SumRePercent.ReadOnly = True
        Me.TB_SumRePercent.Size = New System.Drawing.Size(195, 23)
        Me.TB_SumRePercent.TabIndex = 10
        '
        'Label6
        '
        Me.Label6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(199, 653)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 14)
        Me.Label6.TabIndex = 37
        Me.Label6.Text = "制单人:"
        '
        'TB_Upd_User
        '
        Me.TB_Upd_User.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TB_Upd_User.Location = New System.Drawing.Point(252, 649)
        Me.TB_Upd_User.Name = "TB_Upd_User"
        Me.TB_Upd_User.ReadOnly = True
        Me.TB_Upd_User.Size = New System.Drawing.Size(111, 23)
        Me.TB_Upd_User.TabIndex = 36
        '
        'SP
        '
        Me.SP.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SP.Location = New System.Drawing.Point(5, 49)
        Me.SP.Name = "SP"
        Me.SP.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SP.Panel1
        '
        Me.SP.Panel1.Controls.Add(Me.TB_DayCrop)
        Me.SP.Panel1.Controls.Add(Me.Label12)
        Me.SP.Panel1.Controls.Add(Me.TB_SumCrop)
        Me.SP.Panel1.Controls.Add(Me.TB_SumRePercent)
        Me.SP.Panel1.Controls.Add(Me.Label3)
        Me.SP.Panel1.Controls.Add(Me.TB_DayReCrop)
        Me.SP.Panel1.Controls.Add(Me.Label7)
        Me.SP.Panel1.Controls.Add(Me.Label4)
        Me.SP.Panel1.Controls.Add(Me.TB_SumReCrop)
        Me.SP.Panel1.Controls.Add(Me.Label5)
        Me.SP.Panel1.Controls.Add(Me.TB_DayRePercent)
        Me.SP.Panel1.Controls.Add(Me.Label_ClientBill)
        Me.SP.Panel1.Controls.Add(Me.GroupBox2)
        '
        'SP.Panel2
        '
        Me.SP.Panel2.Controls.Add(Me.GB_List)
        Me.SP.Panel2.Controls.Add(Me.GroupBox1)
        Me.SP.Size = New System.Drawing.Size(890, 594)
        Me.SP.SplitterDistance = 87
        Me.SP.TabIndex = 40
        Me.SP.TabStop = False
        '
        'TB_DayCrop
        '
        Me.TB_DayCrop.Location = New System.Drawing.Point(106, 17)
        Me.TB_DayCrop.Name = "TB_DayCrop"
        Me.TB_DayCrop.Size = New System.Drawing.Size(131, 23)
        Me.TB_DayCrop.TabIndex = 0
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(16, 20)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(84, 14)
        Me.Label12.TabIndex = 21
        Me.Label12.Text = "日产量(KG):"
        '
        'TB_SumCrop
        '
        Me.TB_SumCrop.Location = New System.Drawing.Point(106, 56)
        Me.TB_SumCrop.Name = "TB_SumCrop"
        Me.TB_SumCrop.ReadOnly = True
        Me.TB_SumCrop.Size = New System.Drawing.Size(131, 23)
        Me.TB_SumCrop.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(29, 59)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 14)
        Me.Label3.TabIndex = 31
        Me.Label3.Text = "累计产量:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(596, 60)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(91, 14)
        Me.Label7.TabIndex = 35
        Me.Label7.Text = "总回修率(%):"
        '
        'TB_SumReCrop
        '
        Me.TB_SumReCrop.Location = New System.Drawing.Point(402, 56)
        Me.TB_SumReCrop.Name = "TB_SumReCrop"
        Me.TB_SumReCrop.ReadOnly = True
        Me.TB_SumReCrop.Size = New System.Drawing.Size(145, 23)
        Me.TB_SumReCrop.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(270, 59)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(126, 14)
        Me.Label5.TabIndex = 27
        Me.Label5.Text = "累计回修产量(KG):"
        '
        'TB_DayRePercent
        '
        Me.TB_DayRePercent.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TB_DayRePercent.Location = New System.Drawing.Point(683, 17)
        Me.TB_DayRePercent.Name = "TB_DayRePercent"
        Me.TB_DayRePercent.ReadOnly = True
        Me.TB_DayRePercent.Size = New System.Drawing.Size(196, 23)
        Me.TB_DayRePercent.TabIndex = 4
        '
        'Label_ClientBill
        '
        Me.Label_ClientBill.AutoSize = True
        Me.Label_ClientBill.Location = New System.Drawing.Point(596, 21)
        Me.Label_ClientBill.Name = "Label_ClientBill"
        Me.Label_ClientBill.Size = New System.Drawing.Size(91, 14)
        Me.Label_ClientBill.TabIndex = 21
        Me.Label_ClientBill.Text = "日回修率(%):"
        '
        'GroupBox2
        '
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(890, 87)
        Me.GroupBox2.TabIndex = 40
        Me.GroupBox2.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label25)
        Me.GroupBox1.Controls.Add(Me.TB_LJJCWeight)
        Me.GroupBox1.Controls.Add(Me.TB_LJJZJWeight)
        Me.GroupBox1.Controls.Add(Me.Label24)
        Me.GroupBox1.Controls.Add(Me.TB_RJZJWeight)
        Me.GroupBox1.Controls.Add(Me.Label22)
        Me.GroupBox1.Controls.Add(Me.TB_RJSWeight)
        Me.GroupBox1.Controls.Add(Me.TB_DXCPLJ)
        Me.GroupBox1.Controls.Add(Me.Label21)
        Me.GroupBox1.Controls.Add(Me.TB_DXCPRJ)
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.TB_JZJForPercent)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.TB_JSFORPercent)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.TB_LJJZJGs)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.TB_LJJCGs)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.TB_RJZJPercent)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.TB_RJSPercent)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.TB_RJZJGs)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.TB_RJSGs)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label23)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(890, 134)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label25.Location = New System.Drawing.Point(180, 101)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(16, 16)
        Me.Label25.TabIndex = 65
        Me.Label25.Text = "/"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TB_LJJCWeight
        '
        Me.TB_LJJCWeight.Location = New System.Drawing.Point(197, 97)
        Me.TB_LJJCWeight.Name = "TB_LJJCWeight"
        Me.TB_LJJCWeight.ReadOnly = True
        Me.TB_LJJCWeight.Size = New System.Drawing.Size(86, 23)
        Me.TB_LJJCWeight.TabIndex = 64
        '
        'TB_LJJZJWeight
        '
        Me.TB_LJJZJWeight.Location = New System.Drawing.Point(463, 97)
        Me.TB_LJJZJWeight.Name = "TB_LJJZJWeight"
        Me.TB_LJJZJWeight.ReadOnly = True
        Me.TB_LJJZJWeight.Size = New System.Drawing.Size(77, 23)
        Me.TB_LJJZJWeight.TabIndex = 62
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label24.Location = New System.Drawing.Point(447, 104)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(16, 16)
        Me.Label24.TabIndex = 63
        Me.Label24.Text = "/"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TB_RJZJWeight
        '
        Me.TB_RJZJWeight.Location = New System.Drawing.Point(459, 56)
        Me.TB_RJZJWeight.Name = "TB_RJZJWeight"
        Me.TB_RJZJWeight.Size = New System.Drawing.Size(81, 23)
        Me.TB_RJZJWeight.TabIndex = 60
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label22.Location = New System.Drawing.Point(180, 59)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(16, 16)
        Me.Label22.TabIndex = 59
        Me.Label22.Text = "/"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TB_RJSWeight
        '
        Me.TB_RJSWeight.Location = New System.Drawing.Point(198, 56)
        Me.TB_RJSWeight.Name = "TB_RJSWeight"
        Me.TB_RJSWeight.ReadOnly = True
        Me.TB_RJSWeight.Size = New System.Drawing.Size(86, 23)
        Me.TB_RJSWeight.TabIndex = 58
        '
        'TB_DXCPLJ
        '
        Me.TB_DXCPLJ.Location = New System.Drawing.Point(553, 16)
        Me.TB_DXCPLJ.Name = "TB_DXCPLJ"
        Me.TB_DXCPLJ.Size = New System.Drawing.Size(206, 23)
        Me.TB_DXCPLJ.TabIndex = 19
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(399, 19)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(140, 14)
        Me.Label21.TabIndex = 57
        Me.Label21.Text = "定型成品累计(缸数):"
        '
        'TB_DXCPRJ
        '
        Me.TB_DXCPRJ.Location = New System.Drawing.Point(164, 16)
        Me.TB_DXCPRJ.Name = "TB_DXCPRJ"
        Me.TB_DXCPRJ.Size = New System.Drawing.Size(158, 23)
        Me.TB_DXCPRJ.TabIndex = 17
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(16, 19)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(140, 14)
        Me.Label20.TabIndex = 55
        Me.Label20.Text = "定型成品日总(缸数):"
        '
        'TB_JZJForPercent
        '
        Me.TB_JZJForPercent.Location = New System.Drawing.Point(805, 97)
        Me.TB_JZJForPercent.Name = "TB_JZJForPercent"
        Me.TB_JZJForPercent.Size = New System.Drawing.Size(80, 23)
        Me.TB_JZJForPercent.TabIndex = 15
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(695, 95)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(112, 28)
        Me.Label15.TabIndex = 53
        Me.Label15.Text = "加助剂" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "占累计产量率(%)"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TB_JSFORPercent
        '
        Me.TB_JSFORPercent.Location = New System.Drawing.Point(626, 97)
        Me.TB_JSFORPercent.Name = "TB_JSFORPercent"
        Me.TB_JSFORPercent.Size = New System.Drawing.Size(63, 23)
        Me.TB_JSFORPercent.TabIndex = 13
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(550, 95)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(77, 28)
        Me.Label17.TabIndex = 51
        Me.Label17.Text = "加色占累计" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "产量率(%)"
        '
        'TB_LJJZJGs
        '
        Me.TB_LJJZJGs.Location = New System.Drawing.Point(387, 97)
        Me.TB_LJJZJGs.Name = "TB_LJJZJGs"
        Me.TB_LJJZJGs.ReadOnly = True
        Me.TB_LJJZJGs.Size = New System.Drawing.Size(60, 23)
        Me.TB_LJJZJGs.TabIndex = 11
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(276, 95)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(112, 28)
        Me.Label18.TabIndex = 49
        Me.Label18.Text = "累计加助剂" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "（缸数/公斤数）"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TB_LJJCGs
        '
        Me.TB_LJJCGs.Location = New System.Drawing.Point(117, 97)
        Me.TB_LJJCGs.Name = "TB_LJJCGs"
        Me.TB_LJJCGs.ReadOnly = True
        Me.TB_LJJCGs.Size = New System.Drawing.Size(61, 23)
        Me.TB_LJJCGs.TabIndex = 9
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(6, 95)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(112, 28)
        Me.Label19.TabIndex = 47
        Me.Label19.Text = "累计加色" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "（缸数/公斤数）"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TB_RJZJPercent
        '
        Me.TB_RJZJPercent.Location = New System.Drawing.Point(805, 56)
        Me.TB_RJZJPercent.Name = "TB_RJZJPercent"
        Me.TB_RJZJPercent.Size = New System.Drawing.Size(79, 23)
        Me.TB_RJZJPercent.TabIndex = 7
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(723, 54)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(84, 28)
        Me.Label14.TabIndex = 45
        Me.Label14.Text = "日加助剂" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "占日产率(%)"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TB_RJSPercent
        '
        Me.TB_RJSPercent.Location = New System.Drawing.Point(650, 56)
        Me.TB_RJSPercent.Name = "TB_RJSPercent"
        Me.TB_RJSPercent.Size = New System.Drawing.Size(72, 23)
        Me.TB_RJSPercent.TabIndex = 5
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(567, 54)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(84, 28)
        Me.Label13.TabIndex = 43
        Me.Label13.Text = "日加色" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "占日产率(%)"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TB_RJZJGs
        '
        Me.TB_RJZJGs.Location = New System.Drawing.Point(387, 56)
        Me.TB_RJZJGs.Name = "TB_RJZJGs"
        Me.TB_RJZJGs.Size = New System.Drawing.Size(60, 23)
        Me.TB_RJZJGs.TabIndex = 3
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(284, 54)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(112, 28)
        Me.Label11.TabIndex = 41
        Me.Label11.Text = "日加助剂" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "（缸数/公斤数）"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TB_RJSGs
        '
        Me.TB_RJSGs.Location = New System.Drawing.Point(117, 56)
        Me.TB_RJSGs.Name = "TB_RJSGs"
        Me.TB_RJSGs.ReadOnly = True
        Me.TB_RJSGs.Size = New System.Drawing.Size(63, 23)
        Me.TB_RJSGs.TabIndex = 1
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(1, 54)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(112, 28)
        Me.Label10.TabIndex = 22
        Me.Label10.Text = "日加色" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "（缸数/公斤数）"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label23.Location = New System.Drawing.Point(445, 60)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(16, 16)
        Me.Label23.TabIndex = 61
        Me.Label23.Text = "/"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PanelMain
        '
        Me.PanelMain.Controls.Add(Me.TB_Remarks)
        Me.PanelMain.Controls.Add(Me.TB_Upd_User)
        Me.PanelMain.Controls.Add(Me.Label6)
        Me.PanelMain.Controls.Add(Me.TB_State_User)
        Me.PanelMain.Controls.Add(Me.Label9)
        Me.PanelMain.Controls.Add(Me.TB_Upd_Dept)
        Me.PanelMain.Controls.Add(Me.Label8)
        Me.PanelMain.Controls.Add(Me.CB_Project)
        Me.PanelMain.Controls.Add(Me.DTP_sDate)
        Me.PanelMain.Controls.Add(Me.Label16)
        Me.PanelMain.Controls.Add(Me.TB_ID)
        Me.PanelMain.Controls.Add(Me.Label_ID)
        Me.PanelMain.Controls.Add(Me.Label1)
        Me.PanelMain.Controls.Add(Me.FlowLayoutPanel1)
        Me.PanelMain.Controls.Add(Me.SP)
        Me.PanelMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelMain.Location = New System.Drawing.Point(0, 40)
        Me.PanelMain.Name = "PanelMain"
        Me.PanelMain.Padding = New System.Windows.Forms.Padding(2)
        Me.PanelMain.Size = New System.Drawing.Size(900, 679)
        Me.PanelMain.TabIndex = 0
        '
        'TB_Remarks
        '
        Me.TB_Remarks.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TB_Remarks.AutoFixSize = True
        Me.TB_Remarks.Font_Text = New System.Drawing.Font("宋体", 10.5!)
        Me.TB_Remarks.ForeColor_Text = System.Drawing.SystemColors.WindowText
        Me.TB_Remarks.FormatStr = ""
        Me.TB_Remarks.IsShowTitle = True
        Me.TB_Remarks.Location = New System.Drawing.Point(555, 650)
        Me.TB_Remarks.Name = "TB_Remarks"
        Me.TB_Remarks.Readonly = False
        Me.TB_Remarks.Size = New System.Drawing.Size(333, 23)
        Me.TB_Remarks.TabIndex = 41
        Me.TB_Remarks.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.TB_Remarks.Title = "备注:"
        '
        'F30207_DayReport_Msg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CanMaxSize = True
        Me.Controls.Add(Me.PanelMain)
        Me.Controls.Add(Me.Tool_Top)
        Me.ForeColor = System.Drawing.Color.Black
        Me.Name = "F30207_DayReport_Msg"
        Me.Size = New System.Drawing.Size(900, 719)
        Me.Title = "采购单"
        Me.Tool_Top.ResumeLayout(False)
        Me.Tool_Top.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.GB_List.ResumeLayout(False)
        Me.GB_List.PerformLayout()
        Me.TC_List.ResumeLayout(False)
        Me.Tab1.ResumeLayout(False)
        CType(Me.Fg1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tab2.ResumeLayout(False)
        CType(Me.Fg2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tab3.ResumeLayout(False)
        CType(Me.Fg3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SP.Panel1.ResumeLayout(False)
        Me.SP.Panel1.PerformLayout()
        Me.SP.Panel2.ResumeLayout(False)
        Me.SP.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.PanelMain.ResumeLayout(False)
        Me.PanelMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Tool_Top As System.Windows.Forms.ToolStrip
    Friend WithEvents Cmd_Modify As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_Del As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Cmd_Exit As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_AddRow As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_RemoveRow As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_Preview As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_Print As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Cmd_Audit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Cmd_SetInValid As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_SetValid As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Cmd_UnAudit As System.Windows.Forms.ToolStripButton
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents LabelTitle As System.Windows.Forms.Label
    Friend WithEvents LabelStateT As System.Windows.Forms.Label
    Friend WithEvents LabelState As System.Windows.Forms.Label
    Friend WithEvents GB_List As System.Windows.Forms.GroupBox
    Friend WithEvents TC_List As System.Windows.Forms.TabControl
    Friend WithEvents Tab1 As System.Windows.Forms.TabPage
    Friend WithEvents Fg1 As PClass.FG
    Friend WithEvents SumFG1 As BaseClass.SumFG
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label_ID As System.Windows.Forms.Label
    Friend WithEvents TB_ID As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents DTP_sDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TB_DayReCrop As System.Windows.Forms.TextBox
    Friend WithEvents CB_Project As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TB_Upd_Dept As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TB_State_User As System.Windows.Forms.TextBox
    Friend WithEvents TB_SumRePercent As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TB_Upd_User As System.Windows.Forms.TextBox
    Friend WithEvents SP As System.Windows.Forms.SplitContainer
    Friend WithEvents PanelMain As System.Windows.Forms.Panel
    Friend WithEvents TB_DayCrop As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TB_SumCrop As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TB_SumReCrop As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TB_DayRePercent As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label_ClientBill As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TB_RJZJGs As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TB_RJSGs As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TB_RJZJPercent As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TB_RJSPercent As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TB_JZJForPercent As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents TB_JSFORPercent As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents TB_LJJZJGs As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents TB_LJJCGs As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Tab2 As System.Windows.Forms.TabPage
    Friend WithEvents Fg2 As PClass.FG
    Friend WithEvents Tab3 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Fg3 As PClass.FG
    Friend WithEvents TB_Remarks As BaseClass.TitleTextBox
    Friend WithEvents TB_ReRemarks As BaseClass.TitleTextBox
    Friend WithEvents SumFG2 As BaseClass.SumFG
    Friend WithEvents TB_DXRemarks As BaseClass.TitleTextBox
    Friend WithEvents TB_RJSWeight As System.Windows.Forms.TextBox
    Friend WithEvents TB_DXCPLJ As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents TB_DXCPRJ As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents TB_RJZJWeight As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents TB_LJJZJWeight As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents TB_LJJCWeight As System.Windows.Forms.TextBox
    Friend WithEvents Cmd_Count As System.Windows.Forms.ToolStripButton

End Class
