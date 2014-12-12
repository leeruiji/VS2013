<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F10201_Remark_Msg
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
        Me.Tool_Top = New System.Windows.Forms.ToolStrip
        Me.Cmd_Modify = New System.Windows.Forms.ToolStripButton
        Me.Cmd_Del = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.Btn_Refresh = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.PanelMain = New System.Windows.Forms.Panel
        Me.TB_ID = New System.Windows.Forms.TextBox
        Me.TB_Remark2 = New System.Windows.Forms.TextBox
        Me.LB_Remark2 = New System.Windows.Forms.Label
        Me.TB_Remark = New System.Windows.Forms.TextBox
        Me.LB_Remark = New System.Windows.Forms.Label
        Me.TB_SupplierName = New System.Windows.Forms.Label
        Me.LB_Area = New System.Windows.Forms.Label
        Me.Cmd_Exit = New System.Windows.Forms.ToolStripButton
        Me.Tool_Top.SuspendLayout()
        Me.PanelMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'Tool_Top
        '
        Me.Tool_Top.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.Tool_Top.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Cmd_Modify, Me.Cmd_Del, Me.ToolStripSeparator2, Me.Btn_Refresh, Me.ToolStripSeparator5, Me.Cmd_Exit})
        Me.Tool_Top.Location = New System.Drawing.Point(0, 0)
        Me.Tool_Top.MinimumSize = New System.Drawing.Size(0, 40)
        Me.Tool_Top.Name = "Tool_Top"
        Me.Tool_Top.Size = New System.Drawing.Size(430, 40)
        Me.Tool_Top.TabIndex = 10
        Me.Tool_Top.Text = "ToolStrip2"
        '
        'Cmd_Modify
        '
        Me.Cmd_Modify.AccessibleDescription = "修改按钮"
        Me.Cmd_Modify.AccessibleName = ""
        Me.Cmd_Modify.Image = Global.DN102_Remark.My.Resources.Resources.Modify
        Me.Cmd_Modify.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Modify.Name = "Cmd_Modify"
        Me.Cmd_Modify.Size = New System.Drawing.Size(57, 37)
        Me.Cmd_Modify.Text = "保存"
        '
        'Cmd_Del
        '
        Me.Cmd_Del.AccessibleDescription = "修改按钮"
        Me.Cmd_Del.AccessibleName = ""
        Me.Cmd_Del.Image = Global.DN102_Remark.My.Resources.Resources.Delete
        Me.Cmd_Del.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Del.Name = "Cmd_Del"
        Me.Cmd_Del.Size = New System.Drawing.Size(57, 37)
        Me.Cmd_Del.Text = "删除"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 40)
        '
        'Btn_Refresh
        '
        Me.Btn_Refresh.Image = Global.DN102_Remark.My.Resources.Resources.ReFresh
        Me.Btn_Refresh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Btn_Refresh.Name = "Btn_Refresh"
        Me.Btn_Refresh.Size = New System.Drawing.Size(57, 37)
        Me.Btn_Refresh.Text = "刷新"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 40)
        '
        'PanelMain
        '
        Me.PanelMain.Controls.Add(Me.TB_ID)
        Me.PanelMain.Controls.Add(Me.TB_Remark2)
        Me.PanelMain.Controls.Add(Me.LB_Remark2)
        Me.PanelMain.Controls.Add(Me.TB_Remark)
        Me.PanelMain.Controls.Add(Me.LB_Remark)
        Me.PanelMain.Controls.Add(Me.TB_SupplierName)
        Me.PanelMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelMain.Location = New System.Drawing.Point(0, 40)
        Me.PanelMain.Name = "PanelMain"
        Me.PanelMain.Padding = New System.Windows.Forms.Padding(2)
        Me.PanelMain.Size = New System.Drawing.Size(430, 186)
        Me.PanelMain.TabIndex = 12
        '
        'TB_ID
        '
        Me.TB_ID.Location = New System.Drawing.Point(130, 5)
        Me.TB_ID.Name = "TB_ID"
        Me.TB_ID.ReadOnly = True
        Me.TB_ID.Size = New System.Drawing.Size(268, 23)
        Me.TB_ID.TabIndex = 3
        Me.TB_ID.Visible = False
        '
        'TB_Remark2
        '
        Me.TB_Remark2.Location = New System.Drawing.Point(130, 76)
        Me.TB_Remark2.Multiline = True
        Me.TB_Remark2.Name = "TB_Remark2"
        Me.TB_Remark2.Size = New System.Drawing.Size(268, 66)
        Me.TB_Remark2.TabIndex = 1
        '
        'LB_Remark2
        '
        Me.LB_Remark2.AutoSize = True
        Me.LB_Remark2.Location = New System.Drawing.Point(82, 76)
        Me.LB_Remark2.Name = "LB_Remark2"
        Me.LB_Remark2.Size = New System.Drawing.Size(42, 14)
        Me.LB_Remark2.TabIndex = 5
        Me.LB_Remark2.Text = "备注:"
        '
        'TB_Remark
        '
        Me.TB_Remark.Location = New System.Drawing.Point(130, 36)
        Me.TB_Remark.Name = "TB_Remark"
        Me.TB_Remark.Size = New System.Drawing.Size(268, 23)
        Me.TB_Remark.TabIndex = 0
        '
        'LB_Remark
        '
        Me.LB_Remark.AutoSize = True
        Me.LB_Remark.Location = New System.Drawing.Point(54, 36)
        Me.LB_Remark.Name = "LB_Remark"
        Me.LB_Remark.Size = New System.Drawing.Size(70, 14)
        Me.LB_Remark.TabIndex = 5
        Me.LB_Remark.Text = "质量要求:"
        '
        'TB_SupplierName
        '
        Me.TB_SupplierName.AutoSize = True
        Me.TB_SupplierName.Location = New System.Drawing.Point(82, 8)
        Me.TB_SupplierName.Name = "TB_SupplierName"
        Me.TB_SupplierName.Size = New System.Drawing.Size(42, 14)
        Me.TB_SupplierName.TabIndex = 7
        Me.TB_SupplierName.Text = "编号:"
        Me.TB_SupplierName.Visible = False
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
        'Cmd_Exit
        '
        Me.Cmd_Exit.Image = Global.DN102_Remark.My.Resources.Resources.Close
        Me.Cmd_Exit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(57, 37)
        Me.Cmd_Exit.Text = "关闭"
        '
        'F10201_Remark_Msg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.PanelMain)
        Me.Controls.Add(Me.Tool_Top)
        Me.Controls.Add(Me.LB_Area)
        Me.Name = "F10201_Remark_Msg"
        Me.Size = New System.Drawing.Size(430, 226)
        Me.Title = "备注详细信息"
        Me.Tool_Top.ResumeLayout(False)
        Me.Tool_Top.PerformLayout()
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
    Friend WithEvents PanelMain As System.Windows.Forms.Panel
    Friend WithEvents TB_ID As System.Windows.Forms.TextBox
    Friend WithEvents LB_Area As System.Windows.Forms.Label
    Friend WithEvents TB_SupplierName As System.Windows.Forms.Label
    Friend WithEvents TB_Remark As System.Windows.Forms.TextBox
    Friend WithEvents LB_Remark As System.Windows.Forms.Label
    Friend WithEvents Btn_Refresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents TB_Remark2 As System.Windows.Forms.TextBox
    Friend WithEvents LB_Remark2 As System.Windows.Forms.Label
    Friend WithEvents Cmd_Exit As System.Windows.Forms.ToolStripButton

End Class
