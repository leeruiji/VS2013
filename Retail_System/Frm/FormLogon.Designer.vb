<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormLogon
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormLogon))
        Me.ApplicationTitle = New System.Windows.Forms.Label
        Me.Txt_Pwd = New System.Windows.Forms.TextBox
        Me.LabelMsg = New System.Windows.Forms.Label
        Me.PanelLogin = New System.Windows.Forms.Panel
        Me.CMd_Close = New System.Windows.Forms.Panel
        Me.Combox_User = New System.Windows.Forms.ComboBox
        Me.LabelCheck = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.PanelCLose = New System.Windows.Forms.Panel
        Me.LabelVer = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'ApplicationTitle
        '
        Me.ApplicationTitle.AutoSize = True
        Me.ApplicationTitle.BackColor = System.Drawing.Color.Transparent
        Me.ApplicationTitle.Font = New System.Drawing.Font("隶书", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ApplicationTitle.ForeColor = System.Drawing.Color.White
        Me.ApplicationTitle.Location = New System.Drawing.Point(36, 18)
        Me.ApplicationTitle.Name = "ApplicationTitle"
        Me.ApplicationTitle.Size = New System.Drawing.Size(423, 35)
        Me.ApplicationTitle.TabIndex = 2
        Me.ApplicationTitle.Text = "应用程序标题(自动加载)"
        '
        'Txt_Pwd
        '
        Me.Txt_Pwd.Enabled = False
        Me.Txt_Pwd.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Txt_Pwd.Location = New System.Drawing.Point(645, 361)
        Me.Txt_Pwd.Name = "Txt_Pwd"
        Me.Txt_Pwd.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.Txt_Pwd.Size = New System.Drawing.Size(126, 26)
        Me.Txt_Pwd.TabIndex = 1
        '
        'LabelMsg
        '
        Me.LabelMsg.AutoSize = True
        Me.LabelMsg.BackColor = System.Drawing.Color.Transparent
        Me.LabelMsg.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LabelMsg.ForeColor = System.Drawing.Color.Blue
        Me.LabelMsg.Location = New System.Drawing.Point(12, 592)
        Me.LabelMsg.Name = "LabelMsg"
        Me.LabelMsg.Size = New System.Drawing.Size(84, 14)
        Me.LabelMsg.TabIndex = 4
        Me.LabelMsg.Text = "加载中...."
        Me.LabelMsg.Visible = False
        '
        'PanelLogin
        '
        Me.PanelLogin.BackColor = System.Drawing.Color.Transparent
        Me.PanelLogin.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PanelLogin.Location = New System.Drawing.Point(791, 328)
        Me.PanelLogin.Name = "PanelLogin"
        Me.PanelLogin.Size = New System.Drawing.Size(72, 59)
        Me.PanelLogin.TabIndex = 2
        '
        'CMd_Close
        '
        Me.CMd_Close.BackColor = System.Drawing.Color.Transparent
        Me.CMd_Close.BackgroundImage = CType(resources.GetObject("CMd_Close.BackgroundImage"), System.Drawing.Image)
        Me.CMd_Close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.CMd_Close.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMd_Close.Location = New System.Drawing.Point(991, 46)
        Me.CMd_Close.Name = "CMd_Close"
        Me.CMd_Close.Size = New System.Drawing.Size(21, 21)
        Me.CMd_Close.TabIndex = 14
        Me.CMd_Close.Visible = False
        '
        'Combox_User
        '
        Me.Combox_User.DisplayMember = "User_Name"
        Me.Combox_User.Enabled = False
        Me.Combox_User.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Combox_User.FormattingEnabled = True
        Me.Combox_User.Location = New System.Drawing.Point(645, 328)
        Me.Combox_User.Name = "Combox_User"
        Me.Combox_User.Size = New System.Drawing.Size(126, 24)
        Me.Combox_User.TabIndex = 0
        '
        'LabelCheck
        '
        Me.LabelCheck.BackColor = System.Drawing.Color.Transparent
        Me.LabelCheck.Location = New System.Drawing.Point(499, 481)
        Me.LabelCheck.Name = "LabelCheck"
        Me.LabelCheck.Size = New System.Drawing.Size(60, 39)
        Me.LabelCheck.TabIndex = 16
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.Location = New System.Drawing.Point(506, 242)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(53, 55)
        Me.Panel2.TabIndex = 17
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("宋体", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(567, 249)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(193, 29)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "应用程序标题"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label2.Location = New System.Drawing.Point(569, 331)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 16)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "帐  号:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label3.Location = New System.Drawing.Point(569, 364)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 16)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "密  码:"
        '
        'PanelCLose
        '
        Me.PanelCLose.BackColor = System.Drawing.Color.Transparent
        Me.PanelCLose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PanelCLose.Location = New System.Drawing.Point(917, 33)
        Me.PanelCLose.Name = "PanelCLose"
        Me.PanelCLose.Size = New System.Drawing.Size(71, 25)
        Me.PanelCLose.TabIndex = 3
        '
        'LabelVer
        '
        Me.LabelVer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelVer.AutoSize = True
        Me.LabelVer.BackColor = System.Drawing.Color.Transparent
        Me.LabelVer.Location = New System.Drawing.Point(789, 450)
        Me.LabelVer.Name = "LabelVer"
        Me.LabelVer.Size = New System.Drawing.Size(77, 12)
        Me.LabelVer.TabIndex = 21
        Me.LabelVer.Text = "当前版本1.00"
        '
        'FormLogon
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(1024, 645)
        Me.Controls.Add(Me.LabelVer)
        Me.Controls.Add(Me.PanelCLose)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.LabelCheck)
        Me.Controls.Add(Me.Combox_User)
        Me.Controls.Add(Me.CMd_Close)
        Me.Controls.Add(Me.PanelLogin)
        Me.Controls.Add(Me.LabelMsg)
        Me.Controls.Add(Me.ApplicationTitle)
        Me.Controls.Add(Me.Txt_Pwd)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = Global.Retail_System.My.Resources.Resources.V3_Vis
        Me.Name = "FormLogon"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "用户登录"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ApplicationTitle As System.Windows.Forms.Label
    Friend WithEvents Txt_Pwd As System.Windows.Forms.TextBox
    Friend WithEvents LabelMsg As System.Windows.Forms.Label
    Friend WithEvents PanelLogin As System.Windows.Forms.Panel
    Friend WithEvents CMd_Close As System.Windows.Forms.Panel
    Friend WithEvents Combox_User As System.Windows.Forms.ComboBox
    Friend WithEvents LabelCheck As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PanelCLose As System.Windows.Forms.Panel
    Friend WithEvents LabelVer As System.Windows.Forms.Label
End Class
