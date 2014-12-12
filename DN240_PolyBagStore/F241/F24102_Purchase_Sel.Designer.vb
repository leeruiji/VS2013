<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F24102_Purchase_Sel
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F24102_Purchase_Sel))
        Me.Tool_Top = New System.Windows.Forms.ToolStrip
        Me.Cmd_Sel = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.Cmd_Refresh = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.Cmd_Exit = New System.Windows.Forms.ToolStripButton
        Me.FG1 = New PClass.FG
        Me.CMS_FG1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Cmd_ChooseAll = New System.Windows.Forms.ToolStripMenuItem
        Me.Cmd_UnChooseAll = New System.Windows.Forms.ToolStripMenuItem
        Me.Cmd_UnChoose = New System.Windows.Forms.ToolStripMenuItem
        Me.PanelMain = New System.Windows.Forms.Panel
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.SumFG1 = New BaseClass.SumFG
        Me.SumFG2 = New BaseClass.SumFG
        Me.Fg2 = New PClass.FG
        Me.DP_End = New System.Windows.Forms.DateTimePicker
        Me.DP_Start = New System.Windows.Forms.DateTimePicker
        Me.Tool_Search = New System.Windows.Forms.ToolStrip
        Me.ToolStripLabel4 = New System.Windows.Forms.ToolStripLabel
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel
        Me.Btn_Search = New System.Windows.Forms.ToolStripButton
        Me.Tool_Top.SuspendLayout()
        CType(Me.FG1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CMS_FG1.SuspendLayout()
        Me.PanelMain.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.Fg2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tool_Search.SuspendLayout()
        Me.SuspendLayout()
        '
        'Tool_Top
        '
        Me.Tool_Top.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.Tool_Top.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Cmd_Sel, Me.ToolStripSeparator2, Me.Cmd_Refresh, Me.ToolStripSeparator3, Me.Cmd_Exit})
        Me.Tool_Top.Location = New System.Drawing.Point(2, 2)
        Me.Tool_Top.MinimumSize = New System.Drawing.Size(0, 42)
        Me.Tool_Top.Name = "Tool_Top"
        Me.Tool_Top.Size = New System.Drawing.Size(973, 42)
        Me.Tool_Top.TabIndex = 10
        Me.Tool_Top.Text = "ToolStrip2"
        '
        'Cmd_Sel
        '
        Me.Cmd_Sel.AccessibleDescription = "新增"
        Me.Cmd_Sel.AccessibleName = ""
        Me.Cmd_Sel.Image = Global.DN240_PolyBagStore.My.Resources.Resources.file_apply
        Me.Cmd_Sel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Sel.Name = "Cmd_Sel"
        Me.Cmd_Sel.Size = New System.Drawing.Size(57, 39)
        Me.Cmd_Sel.Text = "选择"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 42)
        '
        'Cmd_Refresh
        '
        Me.Cmd_Refresh.Image = Global.DN240_PolyBagStore.My.Resources.Resources.ReFresh
        Me.Cmd_Refresh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Refresh.Name = "Cmd_Refresh"
        Me.Cmd_Refresh.Size = New System.Drawing.Size(57, 39)
        Me.Cmd_Refresh.Text = "刷新"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 42)
        '
        'Cmd_Exit
        '
        Me.Cmd_Exit.Image = CType(resources.GetObject("Cmd_Exit.Image"), System.Drawing.Image)
        Me.Cmd_Exit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(57, 39)
        Me.Cmd_Exit.Text = "关闭"
        '
        'FG1
        '
        Me.FG1.AllowEditing = False
        Me.FG1.AutoAddIndex = True
        Me.FG1.AutoGenerateColumns = False
        Me.FG1.AutoResize = False
        Me.FG1.BackColor = System.Drawing.Color.White
        Me.FG1.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.XpThemes
        Me.FG1.CanEditing = False
        Me.FG1.ColumnInfo = resources.GetString("FG1.ColumnInfo")
        Me.FG1.ContextMenuStrip = Me.CMS_FG1
        Me.FG1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FG1.EditFormat = True
        Me.FG1.ExtendLastCol = True
        Me.FG1.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.FG1.ForeColor = System.Drawing.Color.Black
        Me.FG1.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.FG1.IsAutoAddRow = True
        Me.FG1.IsClickStartEdit = False
        Me.FG1.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.FG1.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.FG1.Location = New System.Drawing.Point(0, 0)
        Me.FG1.Name = "FG1"
        Me.FG1.Rows.Count = 1
        Me.FG1.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.FG1.Size = New System.Drawing.Size(973, 236)
        Me.FG1.StartCol = ""
        Me.FG1.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("FG1.Styles"))
        Me.FG1.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.BelowData
        Me.FG1.TabIndex = 11
        '
        'CMS_FG1
        '
        Me.CMS_FG1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Cmd_ChooseAll, Me.Cmd_UnChooseAll, Me.Cmd_UnChoose})
        Me.CMS_FG1.Name = "CMS_FG1"
        Me.CMS_FG1.Size = New System.Drawing.Size(107, 70)
        '
        'Cmd_ChooseAll
        '
        Me.Cmd_ChooseAll.Name = "Cmd_ChooseAll"
        Me.Cmd_ChooseAll.Size = New System.Drawing.Size(106, 22)
        Me.Cmd_ChooseAll.Text = "全选"
        '
        'Cmd_UnChooseAll
        '
        Me.Cmd_UnChooseAll.Name = "Cmd_UnChooseAll"
        Me.Cmd_UnChooseAll.Size = New System.Drawing.Size(106, 22)
        Me.Cmd_UnChooseAll.Text = "全不选"
        '
        'Cmd_UnChoose
        '
        Me.Cmd_UnChoose.Name = "Cmd_UnChoose"
        Me.Cmd_UnChoose.Size = New System.Drawing.Size(106, 22)
        Me.Cmd_UnChoose.Text = "反选"
        '
        'PanelMain
        '
        Me.PanelMain.Controls.Add(Me.SplitContainer1)
        Me.PanelMain.Controls.Add(Me.DP_End)
        Me.PanelMain.Controls.Add(Me.DP_Start)
        Me.PanelMain.Controls.Add(Me.Tool_Search)
        Me.PanelMain.Controls.Add(Me.Tool_Top)
        Me.PanelMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelMain.Location = New System.Drawing.Point(0, 0)
        Me.PanelMain.Name = "PanelMain"
        Me.PanelMain.Padding = New System.Windows.Forms.Padding(2)
        Me.PanelMain.Size = New System.Drawing.Size(977, 700)
        Me.PanelMain.TabIndex = 12
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(2, 74)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.FG1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.SumFG1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.Fg2)
        Me.SplitContainer1.Panel2.Controls.Add(Me.SumFG2)
        Me.SplitContainer1.Size = New System.Drawing.Size(973, 624)
        Me.SplitContainer1.SplitterDistance = 259
        Me.SplitContainer1.TabIndex = 14
        '
        'SumFG1
        '
        Me.SumFG1.BackColor = System.Drawing.Color.Cornsilk
        Me.SumFG1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SumFG1.ColForSum.Add("SumQty")
        Me.SumFG1.ColForSum.Add("SumAmount")
        Me.SumFG1.ColForSum.Add("Payed")
        Me.SumFG1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.SumFG1.FG = Me.FG1
        Me.SumFG1.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.SumFG1.ForeColor = System.Drawing.Color.Blue
        Me.SumFG1.Location = New System.Drawing.Point(0, 236)
        Me.SumFG1.Name = "SumFG1"
        Me.SumFG1.Size = New System.Drawing.Size(973, 23)
        Me.SumFG1.TabIndex = 12
        '
        'SumFG2
        '
        Me.SumFG2.BackColor = System.Drawing.Color.Cornsilk
        Me.SumFG2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SumFG2.ColForSum.Add("Qty")
        Me.SumFG2.ColForSum.Add("CanReturn")
        Me.SumFG2.ColForSum.Add("Amount")
        Me.SumFG2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.SumFG2.FG = Me.Fg2
        Me.SumFG2.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.SumFG2.ForeColor = System.Drawing.Color.Blue
        Me.SumFG2.Location = New System.Drawing.Point(0, 338)
        Me.SumFG2.Name = "SumFG2"
        Me.SumFG2.Size = New System.Drawing.Size(973, 23)
        Me.SumFG2.TabIndex = 2
        '
        'Fg2
        '
        Me.Fg2.AllowEditing = False
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
        Me.Fg2.IsClickStartEdit = True
        Me.Fg2.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.Fg2.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.Fg2.Location = New System.Drawing.Point(0, 0)
        Me.Fg2.Name = "Fg2"
        Me.Fg2.Rows.Count = 1
        Me.Fg2.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.Fg2.Size = New System.Drawing.Size(973, 338)
        Me.Fg2.StartCol = ""
        Me.Fg2.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("Fg2.Styles"))
        Me.Fg2.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.BelowData
        Me.Fg2.TabIndex = 1
        '
        'DP_End
        '
        Me.DP_End.CustomFormat = "yyyy-MM-dd"
        Me.DP_End.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DP_End.Location = New System.Drawing.Point(140, 47)
        Me.DP_End.Name = "DP_End"
        Me.DP_End.Size = New System.Drawing.Size(94, 23)
        Me.DP_End.TabIndex = 12
        '
        'DP_Start
        '
        Me.DP_Start.CustomFormat = "yyyy-MM-dd"
        Me.DP_Start.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DP_Start.Location = New System.Drawing.Point(28, 47)
        Me.DP_Start.Name = "DP_Start"
        Me.DP_Start.Size = New System.Drawing.Size(94, 23)
        Me.DP_Start.TabIndex = 12
        '
        'Tool_Search
        '
        Me.Tool_Search.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel4, Me.ToolStripLabel3, Me.Btn_Search})
        Me.Tool_Search.Location = New System.Drawing.Point(2, 44)
        Me.Tool_Search.MinimumSize = New System.Drawing.Size(0, 30)
        Me.Tool_Search.Name = "Tool_Search"
        Me.Tool_Search.Size = New System.Drawing.Size(973, 30)
        Me.Tool_Search.TabIndex = 13
        Me.Tool_Search.Text = "ToolStrip1"
        '
        'ToolStripLabel4
        '
        Me.ToolStripLabel4.Name = "ToolStripLabel4"
        Me.ToolStripLabel4.Size = New System.Drawing.Size(17, 27)
        Me.ToolStripLabel4.Text = "从"
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.Margin = New System.Windows.Forms.Padding(95, 1, 95, 2)
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(17, 27)
        Me.ToolStripLabel3.Text = "到"
        '
        'Btn_Search
        '
        Me.Btn_Search.Image = CType(resources.GetObject("Btn_Search.Image"), System.Drawing.Image)
        Me.Btn_Search.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.Btn_Search.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Btn_Search.Name = "Btn_Search"
        Me.Btn_Search.Size = New System.Drawing.Size(65, 27)
        Me.Btn_Search.Text = "搜索"
        '
        'F24102_Purchase_Sel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.PanelMain)
        Me.Name = "F24102_Purchase_Sel"
        Me.Size = New System.Drawing.Size(977, 700)
        Me.Title = "采购单选择"
        Me.Tool_Top.ResumeLayout(False)
        Me.Tool_Top.PerformLayout()
        CType(Me.FG1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CMS_FG1.ResumeLayout(False)
        Me.PanelMain.ResumeLayout(False)
        Me.PanelMain.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.Fg2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tool_Search.ResumeLayout(False)
        Me.Tool_Search.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Tool_Top As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Cmd_Exit As System.Windows.Forms.ToolStripButton
    Friend WithEvents FG1 As PClass.FG
    Friend WithEvents PanelMain As System.Windows.Forms.Panel
    Friend WithEvents Cmd_Refresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents Tool_Search As System.Windows.Forms.ToolStrip
    Friend WithEvents Btn_Search As System.Windows.Forms.ToolStripButton
    Friend WithEvents DP_Start As System.Windows.Forms.DateTimePicker
    Friend WithEvents DP_End As System.Windows.Forms.DateTimePicker
    Friend WithEvents ToolStripLabel3 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel4 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Fg2 As PClass.FG
    Friend WithEvents CMS_FG1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents Cmd_ChooseAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Cmd_UnChooseAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Cmd_UnChoose As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Cmd_Sel As System.Windows.Forms.ToolStripButton
    Friend WithEvents SumFG1 As BaseClass.SumFG
    Friend WithEvents SumFG2 As BaseClass.SumFG

End Class
