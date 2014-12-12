<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F15510_AT_Shifts
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F15510_AT_Shifts))
        Me.Tool_Top = New System.Windows.Forms.ToolStrip
        Me.Cmd_Add = New System.Windows.Forms.ToolStripButton
        Me.Cmd_Modify = New System.Windows.Forms.ToolStripButton
        Me.Cmd_Del = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.Btn_Refresh = New System.Windows.Forms.ToolStripButton
        Me.Cmd_Exit = New System.Windows.Forms.ToolStripButton
        Me.FG1 = New PClass.FG
        Me.PanelMain = New System.Windows.Forms.Panel
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.LabelMsg = New System.Windows.Forms.Label
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.Tool_Top.SuspendLayout()
        CType(Me.FG1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelMain.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Tool_Top
        '
        Me.Tool_Top.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.Tool_Top.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Cmd_Add, Me.Cmd_Modify, Me.Cmd_Del, Me.ToolStripSeparator2, Me.ToolStripSeparator1, Me.Btn_Refresh, Me.Cmd_Exit})
        Me.Tool_Top.Location = New System.Drawing.Point(0, 0)
        Me.Tool_Top.MinimumSize = New System.Drawing.Size(0, 43)
        Me.Tool_Top.Name = "Tool_Top"
        Me.Tool_Top.Size = New System.Drawing.Size(927, 43)
        Me.Tool_Top.TabIndex = 10
        Me.Tool_Top.Text = "ToolStrip2"
        '
        'Cmd_Add
        '
        Me.Cmd_Add.AccessibleDescription = "新增"
        Me.Cmd_Add.AccessibleName = ""
        Me.Cmd_Add.Image = Global.DN155_AtMachine.My.Resources.Resources.ADD
        Me.Cmd_Add.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Add.Name = "Cmd_Add"
        Me.Cmd_Add.Size = New System.Drawing.Size(57, 40)
        Me.Cmd_Add.Text = "新增"
        '
        'Cmd_Modify
        '
        Me.Cmd_Modify.AccessibleDescription = "修改按钮"
        Me.Cmd_Modify.AccessibleName = ""
        Me.Cmd_Modify.Image = Global.DN155_AtMachine.My.Resources.Resources.Modify
        Me.Cmd_Modify.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Modify.Name = "Cmd_Modify"
        Me.Cmd_Modify.Size = New System.Drawing.Size(57, 40)
        Me.Cmd_Modify.Text = "修改"
        '
        'Cmd_Del
        '
        Me.Cmd_Del.AccessibleDescription = "修改按钮"
        Me.Cmd_Del.AccessibleName = ""
        Me.Cmd_Del.Image = Global.DN155_AtMachine.My.Resources.Resources.Delete
        Me.Cmd_Del.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Del.Name = "Cmd_Del"
        Me.Cmd_Del.Size = New System.Drawing.Size(57, 40)
        Me.Cmd_Del.Text = "删除"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 43)
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 43)
        '
        'Btn_Refresh
        '
        Me.Btn_Refresh.Image = CType(resources.GetObject("Btn_Refresh.Image"), System.Drawing.Image)
        Me.Btn_Refresh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Btn_Refresh.Name = "Btn_Refresh"
        Me.Btn_Refresh.Size = New System.Drawing.Size(57, 40)
        Me.Btn_Refresh.Text = "刷新"
        '
        'Cmd_Exit
        '
        Me.Cmd_Exit.Image = Global.DN155_AtMachine.My.Resources.Resources.Close
        Me.Cmd_Exit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(57, 40)
        Me.Cmd_Exit.Text = "关闭"
        '
        'FG1
        '
        Me.FG1.AutoAddIndex = True
        Me.FG1.AutoGenerateColumns = False
        Me.FG1.AutoResize = False
        Me.FG1.BackColor = System.Drawing.Color.White
        Me.FG1.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.XpThemes
        Me.FG1.CanEditing = True
        Me.FG1.ColumnInfo = resources.GetString("FG1.ColumnInfo")
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
        Me.FG1.Location = New System.Drawing.Point(2, 2)
        Me.FG1.Name = "FG1"
        Me.FG1.Rows.Count = 10
        Me.FG1.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.FG1.Size = New System.Drawing.Size(923, 653)
        Me.FG1.StartCol = ""
        Me.FG1.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("FG1.Styles"))
        Me.FG1.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.BelowData
        Me.FG1.TabIndex = 11
        '
        'PanelMain
        '
        Me.PanelMain.Controls.Add(Me.FG1)
        Me.PanelMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelMain.Location = New System.Drawing.Point(0, 43)
        Me.PanelMain.Name = "PanelMain"
        Me.PanelMain.Padding = New System.Windows.Forms.Padding(2)
        Me.PanelMain.Size = New System.Drawing.Size(927, 657)
        Me.PanelMain.TabIndex = 12
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.LabelMsg)
        Me.Panel2.Controls.Add(Me.ProgressBar1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 43)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(927, 657)
        Me.Panel2.TabIndex = 14
        Me.Panel2.Visible = False
        '
        'LabelMsg
        '
        Me.LabelMsg.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelMsg.ForeColor = System.Drawing.Color.Blue
        Me.LabelMsg.Location = New System.Drawing.Point(304, 198)
        Me.LabelMsg.Name = "LabelMsg"
        Me.LabelMsg.Size = New System.Drawing.Size(397, 16)
        Me.LabelMsg.TabIndex = 13
        Me.LabelMsg.Text = "正在加载..."
        Me.LabelMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ProgressBar1.Location = New System.Drawing.Point(299, 155)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(402, 22)
        Me.ProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.ProgressBar1.TabIndex = 12
        '
        'F15510_AT_Shifts
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.PanelMain)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Tool_Top)
        Me.Name = "F15510_AT_Shifts"
        Me.Tool_Top.ResumeLayout(False)
        Me.Tool_Top.PerformLayout()
        CType(Me.FG1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelMain.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Tool_Top As System.Windows.Forms.ToolStrip
    Friend WithEvents Cmd_Add As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_Modify As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_Del As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Cmd_Exit As System.Windows.Forms.ToolStripButton
    Friend WithEvents FG1 As PClass.FG
    Friend WithEvents PanelMain As System.Windows.Forms.Panel
    Friend WithEvents Btn_Refresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents LabelMsg As System.Windows.Forms.Label
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar

End Class
