<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPwd
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormPwd))
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.TextBox_Pwd1 = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.TextBox_Pwd2 = New System.Windows.Forms.TextBox
        Me.CmdEnd = New System.Windows.Forms.Button
        Me.CmdSave = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(103, 37)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(166, 21)
        Me.TextBox1.TabIndex = 5
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(103, 71)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextBox2.Size = New System.Drawing.Size(166, 21)
        Me.TextBox2.TabIndex = 0
        '
        'TextBox_Pwd1
        '
        Me.TextBox_Pwd1.Location = New System.Drawing.Point(103, 123)
        Me.TextBox_Pwd1.Name = "TextBox_Pwd1"
        Me.TextBox_Pwd1.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextBox_Pwd1.Size = New System.Drawing.Size(166, 21)
        Me.TextBox_Pwd1.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(62, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 12)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "帐号:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(50, 71)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 12)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "原密码:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(50, 126)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 12)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "新密码:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(26, 162)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 12)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "确认新密码:"
        '
        'TextBox_Pwd2
        '
        Me.TextBox_Pwd2.Location = New System.Drawing.Point(103, 162)
        Me.TextBox_Pwd2.Name = "TextBox_Pwd2"
        Me.TextBox_Pwd2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextBox_Pwd2.Size = New System.Drawing.Size(166, 21)
        Me.TextBox_Pwd2.TabIndex = 2
        '
        'CmdEnd
        '
        Me.CmdEnd.Image = CType(resources.GetObject("CmdEnd.Image"), System.Drawing.Image)
        Me.CmdEnd.Location = New System.Drawing.Point(231, 211)
        Me.CmdEnd.Name = "CmdEnd"
        Me.CmdEnd.Size = New System.Drawing.Size(86, 33)
        Me.CmdEnd.TabIndex = 4
        Me.CmdEnd.Text = " 取消 "
        Me.CmdEnd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdEnd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdEnd.UseVisualStyleBackColor = True
        '
        'CmdSave
        '
        Me.CmdSave.Image = CType(resources.GetObject("CmdSave.Image"), System.Drawing.Image)
        Me.CmdSave.Location = New System.Drawing.Point(139, 211)
        Me.CmdSave.Name = "CmdSave"
        Me.CmdSave.Size = New System.Drawing.Size(86, 33)
        Me.CmdSave.TabIndex = 3
        Me.CmdSave.Text = " 保存"
        Me.CmdSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdSave.UseVisualStyleBackColor = True
        '
        'FormPwd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(329, 256)
        Me.Controls.Add(Me.CmdEnd)
        Me.Controls.Add(Me.CmdSave)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TextBox_Pwd2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBox_Pwd1)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Icon = Global.Retail_System.My.Resources.Resources.V3_Vis
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormPwd"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "修改密码"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox_Pwd1 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextBox_Pwd2 As System.Windows.Forms.TextBox
    Friend WithEvents CmdEnd As System.Windows.Forms.Button
    Friend WithEvents CmdSave As System.Windows.Forms.Button
End Class
