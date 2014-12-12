<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConfirmBox
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
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
        Me.ButtonOk = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.SP_OK = New System.Windows.Forms.Panel
        Me.SP_YesNo = New System.Windows.Forms.Panel
        Me.ButtonY = New System.Windows.Forms.Button
        Me.ButtonN = New System.Windows.Forms.Button
        Me.Sp_YesNoCancel = New System.Windows.Forms.Panel
        Me.ButtonC1 = New System.Windows.Forms.Button
        Me.ButtonY1 = New System.Windows.Forms.Button
        Me.ButtonN1 = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.SP_OK.SuspendLayout()
        Me.SP_YesNo.SuspendLayout()
        Me.Sp_YesNoCancel.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ButtonOk
        '
        Me.ButtonOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.ButtonOk.Location = New System.Drawing.Point(55, 7)
        Me.ButtonOk.Name = "ButtonOk"
        Me.ButtonOk.Size = New System.Drawing.Size(80, 25)
        Me.ButtonOk.TabIndex = 0
        Me.ButtonOk.Text = "确认"
        Me.ButtonOk.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(55, 9)
        Me.Label1.MaximumSize = New System.Drawing.Size(717, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(17, 12)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "20"
        '
        'SP_OK
        '
        Me.SP_OK.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SP_OK.Controls.Add(Me.ButtonOk)
        Me.SP_OK.Location = New System.Drawing.Point(2, 47)
        Me.SP_OK.Name = "SP_OK"
        Me.SP_OK.Size = New System.Drawing.Size(187, 40)
        Me.SP_OK.TabIndex = 2
        Me.SP_OK.Visible = False
        '
        'SP_YesNo
        '
        Me.SP_YesNo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SP_YesNo.Controls.Add(Me.ButtonY)
        Me.SP_YesNo.Controls.Add(Me.ButtonN)
        Me.SP_YesNo.Location = New System.Drawing.Point(2, 46)
        Me.SP_YesNo.Name = "SP_YesNo"
        Me.SP_YesNo.Size = New System.Drawing.Size(187, 41)
        Me.SP_YesNo.TabIndex = 3
        Me.SP_YesNo.Visible = False
        '
        'ButtonY
        '
        Me.ButtonY.Location = New System.Drawing.Point(8, 8)
        Me.ButtonY.Name = "ButtonY"
        Me.ButtonY.Size = New System.Drawing.Size(80, 25)
        Me.ButtonY.TabIndex = 0
        Me.ButtonY.Text = "是(&Y)"
        Me.ButtonY.UseVisualStyleBackColor = True
        '
        'ButtonN
        '
        Me.ButtonN.Location = New System.Drawing.Point(90, 8)
        Me.ButtonN.Name = "ButtonN"
        Me.ButtonN.Size = New System.Drawing.Size(80, 25)
        Me.ButtonN.TabIndex = 1
        Me.ButtonN.Text = "否(&N)"
        Me.ButtonN.UseVisualStyleBackColor = True
        '
        'Sp_YesNoCancel
        '
        Me.Sp_YesNoCancel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Sp_YesNoCancel.Controls.Add(Me.ButtonC1)
        Me.Sp_YesNoCancel.Controls.Add(Me.ButtonY1)
        Me.Sp_YesNoCancel.Controls.Add(Me.ButtonN1)
        Me.Sp_YesNoCancel.Location = New System.Drawing.Point(1, 46)
        Me.Sp_YesNoCancel.Name = "Sp_YesNoCancel"
        Me.Sp_YesNoCancel.Size = New System.Drawing.Size(187, 41)
        Me.Sp_YesNoCancel.TabIndex = 4
        Me.Sp_YesNoCancel.Visible = False
        '
        'ButtonC1
        '
        Me.ButtonC1.Location = New System.Drawing.Point(263, 8)
        Me.ButtonC1.Name = "ButtonC1"
        Me.ButtonC1.Size = New System.Drawing.Size(80, 25)
        Me.ButtonC1.TabIndex = 2
        Me.ButtonC1.Text = "取消(&C)"
        Me.ButtonC1.UseVisualStyleBackColor = True
        '
        'ButtonY1
        '
        Me.ButtonY1.Location = New System.Drawing.Point(43, 8)
        Me.ButtonY1.Name = "ButtonY1"
        Me.ButtonY1.Size = New System.Drawing.Size(80, 25)
        Me.ButtonY1.TabIndex = 0
        Me.ButtonY1.Text = "是(&Y)"
        Me.ButtonY1.UseVisualStyleBackColor = True
        '
        'ButtonN1
        '
        Me.ButtonN1.Location = New System.Drawing.Point(153, 8)
        Me.ButtonN1.Name = "ButtonN1"
        Me.ButtonN1.Size = New System.Drawing.Size(80, 25)
        Me.ButtonN1.TabIndex = 1
        Me.ButtonN1.Text = "否(&N)"
        Me.ButtonN1.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(16, 7)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox1.TabIndex = 5
        Me.PictureBox1.TabStop = False
        '
        'ConfirmBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(190, 87)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Sp_YesNoCancel)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.SP_OK)
        Me.Controls.Add(Me.SP_YesNo)
        Me.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(190, 32)
        Me.Name = "ConfirmBox"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "ConfirmBox"
        Me.SP_OK.ResumeLayout(False)
        Me.SP_YesNo.ResumeLayout(False)
        Me.Sp_YesNoCancel.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButtonOk As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SP_OK As System.Windows.Forms.Panel
    Friend WithEvents SP_YesNo As System.Windows.Forms.Panel
    Friend WithEvents ButtonN As System.Windows.Forms.Button
    Friend WithEvents ButtonY As System.Windows.Forms.Button
    Friend WithEvents Sp_YesNoCancel As System.Windows.Forms.Panel
    Friend WithEvents ButtonC1 As System.Windows.Forms.Button
    Friend WithEvents ButtonY1 As System.Windows.Forms.Button
    Friend WithEvents ButtonN1 As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
End Class
