<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F10032_GY_Image
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
        Me.Btn_SelImage = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.Cmd_Modify = New System.Windows.Forms.ToolStripButton
        Me.Cmd_Del = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.Cmd_Exit = New System.Windows.Forms.ToolStripButton
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.PB_ImgBig = New System.Windows.Forms.PictureBox
        Me.Tool_Top.SuspendLayout()
        CType(Me.PB_ImgBig, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Tool_Top
        '
        Me.Tool_Top.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.Tool_Top.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Btn_SelImage, Me.ToolStripSeparator2, Me.Cmd_Modify, Me.Cmd_Del, Me.ToolStripSeparator5, Me.Cmd_Exit})
        Me.Tool_Top.Location = New System.Drawing.Point(0, 0)
        Me.Tool_Top.MinimumSize = New System.Drawing.Size(0, 40)
        Me.Tool_Top.Name = "Tool_Top"
        Me.Tool_Top.Size = New System.Drawing.Size(300, 40)
        Me.Tool_Top.TabIndex = 10
        Me.Tool_Top.Text = "ToolStrip2"
        '
        'Btn_SelImage
        '
        Me.Btn_SelImage.Image = Global.DN100_BasicInfo.My.Resources.Resources.Look_All
        Me.Btn_SelImage.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Btn_SelImage.Name = "Btn_SelImage"
        Me.Btn_SelImage.Size = New System.Drawing.Size(81, 37)
        Me.Btn_SelImage.Text = "选择图片"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 40)
        '
        'Cmd_Modify
        '
        Me.Cmd_Modify.AccessibleDescription = "修改按钮"
        Me.Cmd_Modify.AccessibleName = ""
        Me.Cmd_Modify.Image = Global.DN100_BasicInfo.My.Resources.Resources.Modify
        Me.Cmd_Modify.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Modify.Name = "Cmd_Modify"
        Me.Cmd_Modify.Size = New System.Drawing.Size(57, 37)
        Me.Cmd_Modify.Text = "保存"
        '
        'Cmd_Del
        '
        Me.Cmd_Del.AccessibleDescription = "修改按钮"
        Me.Cmd_Del.AccessibleName = ""
        Me.Cmd_Del.Image = Global.DN100_BasicInfo.My.Resources.Resources.Delete
        Me.Cmd_Del.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Del.Name = "Cmd_Del"
        Me.Cmd_Del.Size = New System.Drawing.Size(57, 37)
        Me.Cmd_Del.Text = "删除"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 40)
        '
        'Cmd_Exit
        '
        Me.Cmd_Exit.Image = Global.DN100_BasicInfo.My.Resources.Resources.Close
        Me.Cmd_Exit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(57, 37)
        Me.Cmd_Exit.Text = "关闭"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'PB_ImgBig
        '
        Me.PB_ImgBig.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PB_ImgBig.Location = New System.Drawing.Point(0, 40)
        Me.PB_ImgBig.Name = "PB_ImgBig"
        Me.PB_ImgBig.Size = New System.Drawing.Size(300, 260)
        Me.PB_ImgBig.TabIndex = 11
        Me.PB_ImgBig.TabStop = False
        '
        'F10032_GY_Image
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.CanMaxSize = True
        Me.Controls.Add(Me.PB_ImgBig)
        Me.Controls.Add(Me.Tool_Top)
        Me.Name = "F10032_GY_Image"
        Me.Size = New System.Drawing.Size(300, 300)
        Me.Title = "供应商详细信息"
        Me.Tool_Top.ResumeLayout(False)
        Me.Tool_Top.PerformLayout()
        CType(Me.PB_ImgBig, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Tool_Top As System.Windows.Forms.ToolStrip
    Friend WithEvents Cmd_Modify As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_Del As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Cmd_Exit As System.Windows.Forms.ToolStripButton
    Friend WithEvents Btn_SelImage As System.Windows.Forms.ToolStripButton
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents PB_ImgBig As System.Windows.Forms.PictureBox

End Class
