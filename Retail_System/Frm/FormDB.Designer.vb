<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormDB
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormDB))
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.T_IP = New System.Windows.Forms.TextBox
        Me.T15002_User = New System.Windows.Forms.TextBox
        Me.T_Pwd = New System.Windows.Forms.TextBox
        Me.T_DB = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.CmdEnd = New System.Windows.Forms.Button
        Me.CmdSave = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(51, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "服务器IP:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(75, 111)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 12)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "帐号:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(75, 149)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 12)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "密码:"
        '
        'T_IP
        '
        Me.T_IP.Location = New System.Drawing.Point(126, 32)
        Me.T_IP.Name = "T_IP"
        Me.T_IP.Size = New System.Drawing.Size(115, 21)
        Me.T_IP.TabIndex = 0
        '
        'T15002_User
        '
        Me.T15002_User.Location = New System.Drawing.Point(126, 108)
        Me.T15002_User.Name = "T15002_User"
        Me.T15002_User.Size = New System.Drawing.Size(115, 21)
        Me.T15002_User.TabIndex = 2
        '
        'T_Pwd
        '
        Me.T_Pwd.Location = New System.Drawing.Point(126, 146)
        Me.T_Pwd.Name = "T_Pwd"
        Me.T_Pwd.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.T_Pwd.Size = New System.Drawing.Size(115, 21)
        Me.T_Pwd.TabIndex = 3
        '
        'T_DB
        '
        Me.T_DB.Location = New System.Drawing.Point(126, 70)
        Me.T_DB.Name = "T_DB"
        Me.T_DB.Size = New System.Drawing.Size(115, 21)
        Me.T_DB.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(51, 73)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 12)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "数据库名:"
        '
        'CmdEnd
        '
        Me.CmdEnd.Image = CType(resources.GetObject("CmdEnd.Image"), System.Drawing.Image)
        Me.CmdEnd.Location = New System.Drawing.Point(169, 202)
        Me.CmdEnd.Name = "CmdEnd"
        Me.CmdEnd.Size = New System.Drawing.Size(86, 33)
        Me.CmdEnd.TabIndex = 5
        Me.CmdEnd.Text = " 取消 "
        Me.CmdEnd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdEnd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdEnd.UseVisualStyleBackColor = True
        '
        'CmdSave
        '
        Me.CmdSave.Image = CType(resources.GetObject("CmdSave.Image"), System.Drawing.Image)
        Me.CmdSave.Location = New System.Drawing.Point(43, 202)
        Me.CmdSave.Name = "CmdSave"
        Me.CmdSave.Size = New System.Drawing.Size(86, 33)
        Me.CmdSave.TabIndex = 4
        Me.CmdSave.Text = " 保存"
        Me.CmdSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdSave.UseVisualStyleBackColor = True
        '
        'FormDB
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(302, 247)
        Me.Controls.Add(Me.CmdEnd)
        Me.Controls.Add(Me.CmdSave)
        Me.Controls.Add(Me.T_DB)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.T_Pwd)
        Me.Controls.Add(Me.T15002_User)
        Me.Controls.Add(Me.T_IP)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = Global.Retail_System.My.Resources.Resources.V3_Vis
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormDB"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "数据库配置"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents T_IP As System.Windows.Forms.TextBox
    Friend WithEvents T15002_User As System.Windows.Forms.TextBox
    Friend WithEvents T_Pwd As System.Windows.Forms.TextBox
    Friend WithEvents T_DB As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CmdEnd As System.Windows.Forms.Button
    Friend WithEvents CmdSave As System.Windows.Forms.Button
End Class
