<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormDBSelect
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormDBSelect))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Cmd_Active = New System.Windows.Forms.Button
        Me.T_Msg = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.CheckBox_Active = New System.Windows.Forms.CheckBox
        Me.CmdEnd = New System.Windows.Forms.Button
        Me.CmdSave = New System.Windows.Forms.Button
        Me.T_DB = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.T_Pwd = New System.Windows.Forms.TextBox
        Me.T15002_User = New System.Windows.Forms.TextBox
        Me.T_IP = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Fg1 = New PClass.FG
        Me.GroupBox1.SuspendLayout()
        CType(Me.Fg1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Cmd_Active)
        Me.GroupBox1.Controls.Add(Me.T_Msg)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.CheckBox_Active)
        Me.GroupBox1.Controls.Add(Me.CmdEnd)
        Me.GroupBox1.Controls.Add(Me.CmdSave)
        Me.GroupBox1.Controls.Add(Me.T_DB)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.T_Pwd)
        Me.GroupBox1.Controls.Add(Me.T15002_User)
        Me.GroupBox1.Controls.Add(Me.T_IP)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 295)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(484, 189)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "数据库设置"
        '
        'Cmd_Active
        '
        Me.Cmd_Active.Image = CType(resources.GetObject("Cmd_Active.Image"), System.Drawing.Image)
        Me.Cmd_Active.Location = New System.Drawing.Point(392, 150)
        Me.Cmd_Active.Name = "Cmd_Active"
        Me.Cmd_Active.Size = New System.Drawing.Size(86, 33)
        Me.Cmd_Active.TabIndex = 20
        Me.Cmd_Active.Text = " 激活"
        Me.Cmd_Active.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Active.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Cmd_Active.UseVisualStyleBackColor = True
        '
        'T_Msg
        '
        Me.T_Msg.Location = New System.Drawing.Point(97, 18)
        Me.T_Msg.Name = "T_Msg"
        Me.T_Msg.Size = New System.Drawing.Size(291, 21)
        Me.T_Msg.TabIndex = 19
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(46, 21)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 12)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "名称:"
        '
        'CheckBox_Active
        '
        Me.CheckBox_Active.AutoCheck = False
        Me.CheckBox_Active.AutoSize = True
        Me.CheckBox_Active.Location = New System.Drawing.Point(394, 20)
        Me.CheckBox_Active.Name = "CheckBox_Active"
        Me.CheckBox_Active.Size = New System.Drawing.Size(84, 16)
        Me.CheckBox_Active.TabIndex = 17
        Me.CheckBox_Active.Text = "是否被激活"
        Me.CheckBox_Active.UseVisualStyleBackColor = True
        '
        'CmdEnd
        '
        Me.CmdEnd.Image = CType(resources.GetObject("CmdEnd.Image"), System.Drawing.Image)
        Me.CmdEnd.Location = New System.Drawing.Point(300, 150)
        Me.CmdEnd.Name = "CmdEnd"
        Me.CmdEnd.Size = New System.Drawing.Size(86, 33)
        Me.CmdEnd.TabIndex = 15
        Me.CmdEnd.Text = " 取消 "
        Me.CmdEnd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdEnd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdEnd.UseVisualStyleBackColor = True
        '
        'CmdSave
        '
        Me.CmdSave.Image = CType(resources.GetObject("CmdSave.Image"), System.Drawing.Image)
        Me.CmdSave.Location = New System.Drawing.Point(208, 150)
        Me.CmdSave.Name = "CmdSave"
        Me.CmdSave.Size = New System.Drawing.Size(86, 33)
        Me.CmdSave.TabIndex = 14
        Me.CmdSave.Text = " 保存"
        Me.CmdSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdSave.UseVisualStyleBackColor = True
        '
        'T_DB
        '
        Me.T_DB.Location = New System.Drawing.Point(97, 94)
        Me.T_DB.Name = "T_DB"
        Me.T_DB.Size = New System.Drawing.Size(115, 21)
        Me.T_DB.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(22, 97)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 12)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "数据库名:"
        '
        'T_Pwd
        '
        Me.T_Pwd.Location = New System.Drawing.Point(273, 94)
        Me.T_Pwd.Name = "T_Pwd"
        Me.T_Pwd.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.T_Pwd.Size = New System.Drawing.Size(115, 21)
        Me.T_Pwd.TabIndex = 13
        '
        'T15002_User
        '
        Me.T15002_User.Location = New System.Drawing.Point(273, 56)
        Me.T15002_User.Name = "T15002_User"
        Me.T15002_User.Size = New System.Drawing.Size(115, 21)
        Me.T15002_User.TabIndex = 11
        '
        'T_IP
        '
        Me.T_IP.Location = New System.Drawing.Point(97, 56)
        Me.T_IP.Name = "T_IP"
        Me.T_IP.Size = New System.Drawing.Size(115, 21)
        Me.T_IP.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(222, 97)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 12)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "密码:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(222, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 12)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "帐号:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 59)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 12)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "服务器IP:"
        '
        'Fg1
        '
        Me.Fg1.AutoAddIndex = True
        Me.Fg1.AutoGenerateColumns = False
        Me.Fg1.AutoResize = False
        Me.Fg1.BackColor = System.Drawing.Color.White
        Me.Fg1.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.XpThemes
        Me.Fg1.ColumnInfo = resources.GetString("Fg1.ColumnInfo")
        Me.Fg1.ExtendLastCol = True
        Me.Fg1.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Fg1.ForeColor = System.Drawing.Color.Black
        Me.Fg1.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.Fg1.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.Fg1.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.Fg1.Location = New System.Drawing.Point(12, 12)
        Me.Fg1.Name = "Fg1"
        Me.Fg1.Rows.Count = 10
        Me.Fg1.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.Fg1.Size = New System.Drawing.Size(484, 277)
        Me.Fg1.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("Fg1.Styles"))
        Me.Fg1.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.BelowData
        Me.Fg1.TabIndex = 21
        '
        'FormDBSelect
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(508, 496)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Fg1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormDBSelect"
        Me.Icon = Global.Retail_System.My.Resources.Resources.V3_Vis
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "帐套设置"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.Fg1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CmdEnd As System.Windows.Forms.Button
    Friend WithEvents CmdSave As System.Windows.Forms.Button
    Friend WithEvents T_DB As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents T_Pwd As System.Windows.Forms.TextBox
    Friend WithEvents T15002_User As System.Windows.Forms.TextBox
    Friend WithEvents T_IP As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CheckBox_Active As System.Windows.Forms.CheckBox
    Friend WithEvents T_Msg As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Cmd_Active As System.Windows.Forms.Button
    Friend WithEvents Fg1 As PClass.FG
End Class
