<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F89000_FileList
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F89000_FileList))
        Me.Tool_Top = New System.Windows.Forms.ToolStrip
        Me.Cmd_Add = New System.Windows.Forms.ToolStripButton
        Me.Cmd_Modify = New System.Windows.Forms.ToolStripButton
        Me.Cmd_Del = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.Cmd_ReFresh = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.Cmd_Exit = New System.Windows.Forms.ToolStripButton
        Me.FG1 = New PClass.FG
        Me.PanelMain = New System.Windows.Forms.Panel
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.GroupBox_File = New System.Windows.Forms.GroupBox
        Me.GroupBox_Right = New System.Windows.Forms.GroupBox
        Me.Fg2 = New PClass.FG
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.Cmd_RightSave = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.Cmd_RightReFresh = New System.Windows.Forms.ToolStripButton
        Me.Tool_Top.SuspendLayout()
        CType(Me.FG1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelMain.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GroupBox_File.SuspendLayout()
        Me.GroupBox_Right.SuspendLayout()
        CType(Me.Fg2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Tool_Top
        '
        Me.Tool_Top.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.Tool_Top.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Cmd_Add, Me.Cmd_Modify, Me.Cmd_Del, Me.ToolStripSeparator2, Me.Cmd_ReFresh, Me.ToolStripSeparator5, Me.Cmd_Exit})
        Me.Tool_Top.Location = New System.Drawing.Point(0, 0)
        Me.Tool_Top.MinimumSize = New System.Drawing.Size(0, 50)
        Me.Tool_Top.Name = "Tool_Top"
        Me.Tool_Top.Size = New System.Drawing.Size(927, 50)
        Me.Tool_Top.TabIndex = 10
        Me.Tool_Top.Text = "ToolStrip2"
        '
        'Cmd_Add
        '
        Me.Cmd_Add.AccessibleDescription = ""
        Me.Cmd_Add.AccessibleName = ""
        Me.Cmd_Add.Image = Global.DN890_OnLineFile.My.Resources.Resources.ADD
        Me.Cmd_Add.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Add.Name = "Cmd_Add"
        Me.Cmd_Add.Size = New System.Drawing.Size(33, 47)
        Me.Cmd_Add.Text = "添加"
        Me.Cmd_Add.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'Cmd_Modify
        '
        Me.Cmd_Modify.AccessibleDescription = ""
        Me.Cmd_Modify.AccessibleName = ""
        Me.Cmd_Modify.Image = Global.DN890_OnLineFile.My.Resources.Resources.Modify
        Me.Cmd_Modify.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Modify.Name = "Cmd_Modify"
        Me.Cmd_Modify.Size = New System.Drawing.Size(33, 47)
        Me.Cmd_Modify.Text = "修改"
        Me.Cmd_Modify.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'Cmd_Del
        '
        Me.Cmd_Del.AccessibleDescription = ""
        Me.Cmd_Del.AccessibleName = ""
        Me.Cmd_Del.Image = Global.DN890_OnLineFile.My.Resources.Resources.Delete
        Me.Cmd_Del.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Del.Name = "Cmd_Del"
        Me.Cmd_Del.Size = New System.Drawing.Size(33, 47)
        Me.Cmd_Del.Text = "删除"
        Me.Cmd_Del.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 50)
        '
        'Cmd_ReFresh
        '
        Me.Cmd_ReFresh.AccessibleDescription = ""
        Me.Cmd_ReFresh.AccessibleName = ""
        Me.Cmd_ReFresh.Image = Global.DN890_OnLineFile.My.Resources.Resources.ReFresh
        Me.Cmd_ReFresh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_ReFresh.Name = "Cmd_ReFresh"
        Me.Cmd_ReFresh.Size = New System.Drawing.Size(33, 47)
        Me.Cmd_ReFresh.Text = "刷新"
        Me.Cmd_ReFresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 50)
        '
        'Cmd_Exit
        '
        Me.Cmd_Exit.Image = Global.DN890_OnLineFile.My.Resources.Resources.Close
        Me.Cmd_Exit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(33, 47)
        Me.Cmd_Exit.Text = "关闭"
        Me.Cmd_Exit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'FG1
        '
        Me.FG1.AllowEditing = False
        Me.FG1.AutoAddIndex = True
        Me.FG1.AutoGenerateColumns = False
        Me.FG1.AutoResize = False
        Me.FG1.BackColor = System.Drawing.Color.White
        Me.FG1.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.XpThemes
        Me.FG1.ColumnInfo = resources.GetString("FG1.ColumnInfo")
        Me.FG1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FG1.ExtendLastCol = True
        Me.FG1.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.FG1.ForeColor = System.Drawing.Color.Black
        Me.FG1.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.FG1.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.FG1.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.FG1.Location = New System.Drawing.Point(3, 19)
        Me.FG1.Name = "FG1"
        Me.FG1.Rows.Count = 10
        Me.FG1.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.FG1.Size = New System.Drawing.Size(561, 624)
        Me.FG1.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("FG1.Styles"))
        Me.FG1.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.BelowData
        Me.FG1.TabIndex = 11
        '
        'PanelMain
        '
        Me.PanelMain.Controls.Add(Me.SplitContainer1)
        Me.PanelMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelMain.Location = New System.Drawing.Point(0, 50)
        Me.PanelMain.Name = "PanelMain"
        Me.PanelMain.Padding = New System.Windows.Forms.Padding(2)
        Me.PanelMain.Size = New System.Drawing.Size(927, 650)
        Me.PanelMain.TabIndex = 12
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(2, 2)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox_File)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.GroupBox_Right)
        Me.SplitContainer1.Size = New System.Drawing.Size(923, 646)
        Me.SplitContainer1.SplitterDistance = 567
        Me.SplitContainer1.TabIndex = 12
        '
        'GroupBox_File
        '
        Me.GroupBox_File.Controls.Add(Me.FG1)
        Me.GroupBox_File.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox_File.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox_File.Name = "GroupBox_File"
        Me.GroupBox_File.Size = New System.Drawing.Size(567, 646)
        Me.GroupBox_File.TabIndex = 12
        Me.GroupBox_File.TabStop = False
        Me.GroupBox_File.Text = "在线文档"
        '
        'GroupBox_Right
        '
        Me.GroupBox_Right.Controls.Add(Me.Fg2)
        Me.GroupBox_Right.Controls.Add(Me.ToolStrip1)
        Me.GroupBox_Right.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox_Right.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox_Right.Name = "GroupBox_Right"
        Me.GroupBox_Right.Size = New System.Drawing.Size(352, 646)
        Me.GroupBox_Right.TabIndex = 1
        Me.GroupBox_Right.TabStop = False
        Me.GroupBox_Right.Text = "权限设置"
        '
        'Fg2
        '
        Me.Fg2.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.Fg2.AllowEditing = False
        Me.Fg2.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.Fg2.AutoAddIndex = False
        Me.Fg2.AutoGenerateColumns = False
        Me.Fg2.AutoResize = False
        Me.Fg2.BackColor = System.Drawing.Color.White
        Me.Fg2.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.XpThemes
        Me.Fg2.ColumnInfo = resources.GetString("Fg2.ColumnInfo")
        Me.Fg2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Fg2.ExtendLastCol = True
        Me.Fg2.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Fg2.ForeColor = System.Drawing.Color.Black
        Me.Fg2.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.Fg2.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.Fg2.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.Fg2.Location = New System.Drawing.Point(3, 50)
        Me.Fg2.Name = "Fg2"
        Me.Fg2.Rows.Count = 10
        Me.Fg2.Rows.MinSize = 22
        Me.Fg2.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.Fg2.Size = New System.Drawing.Size(346, 593)
        Me.Fg2.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("Fg2.Styles"))
        Me.Fg2.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.BelowData
        Me.Fg2.TabIndex = 0
        Me.Fg2.Tree.Column = 1
        Me.Fg2.Tree.Indent = 20
        Me.Fg2.Tree.LineColor = System.Drawing.Color.Blue
        Me.Fg2.Tree.LineStyle = System.Drawing.Drawing2D.DashStyle.Solid
        Me.Fg2.Tree.Style = CType(((C1.Win.C1FlexGrid.TreeStyleFlags.Lines Or C1.Win.C1FlexGrid.TreeStyleFlags.Symbols) _
                    Or C1.Win.C1FlexGrid.TreeStyleFlags.Leaf), C1.Win.C1FlexGrid.TreeStyleFlags)
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Cmd_RightSave, Me.ToolStripSeparator1, Me.Cmd_RightReFresh})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 19)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(346, 31)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        Me.ToolStrip1.TextDirection = System.Windows.Forms.ToolStripTextDirection.Vertical90
        '
        'Cmd_RightSave
        '
        Me.Cmd_RightSave.Image = Global.DN890_OnLineFile.My.Resources.Resources.save
        Me.Cmd_RightSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.Cmd_RightSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_RightSave.Name = "Cmd_RightSave"
        Me.Cmd_RightSave.Size = New System.Drawing.Size(81, 28)
        Me.Cmd_RightSave.Text = "保存权限"
        Me.Cmd_RightSave.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 31)
        Me.ToolStripSeparator1.TextDirection = System.Windows.Forms.ToolStripTextDirection.Vertical90
        '
        'Cmd_RightReFresh
        '
        Me.Cmd_RightReFresh.Image = Global.DN890_OnLineFile.My.Resources.Resources.ReFresh
        Me.Cmd_RightReFresh.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.Cmd_RightReFresh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_RightReFresh.Name = "Cmd_RightReFresh"
        Me.Cmd_RightReFresh.Size = New System.Drawing.Size(57, 28)
        Me.Cmd_RightReFresh.Text = "刷新"
        Me.Cmd_RightReFresh.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
        '
        'F89000_FileList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.PanelMain)
        Me.Controls.Add(Me.Tool_Top)
        Me.Name = "F89000_FileList"
        Me.Tool_Top.ResumeLayout(False)
        Me.Tool_Top.PerformLayout()
        CType(Me.FG1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelMain.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.GroupBox_File.ResumeLayout(False)
        Me.GroupBox_Right.ResumeLayout(False)
        Me.GroupBox_Right.PerformLayout()
        CType(Me.Fg2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Tool_Top As System.Windows.Forms.ToolStrip
    Friend WithEvents Cmd_Add As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_Modify As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_Del As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Cmd_Exit As System.Windows.Forms.ToolStripButton
    Friend WithEvents FG1 As PClass.FG
    Friend WithEvents PanelMain As System.Windows.Forms.Panel
    Friend WithEvents Cmd_ReFresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents GroupBox_Right As System.Windows.Forms.GroupBox
    Friend WithEvents Fg2 As PClass.FG
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents GroupBox_File As System.Windows.Forms.GroupBox
    Friend WithEvents Cmd_RightSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Cmd_RightReFresh As System.Windows.Forms.ToolStripButton

End Class
