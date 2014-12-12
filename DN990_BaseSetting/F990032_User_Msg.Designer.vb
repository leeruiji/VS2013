<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F990032_User_Msg
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
        Me.PanelMain = New System.Windows.Forms.Panel
        Me.CB_Invalid = New System.Windows.Forms.CheckBox
        Me.Btn_ChoseDeptForUser = New System.Windows.Forms.Button
        Me.TextBox_ComfirmPsw = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.TextBox_Remark = New System.Windows.Forms.TextBox
        Me.Label_ComfirmPsw = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.ComboBox_UserGroup = New System.Windows.Forms.ComboBox
        Me.Tb_EmployeeID_ForUser = New System.Windows.Forms.TextBox
        Me.TB_Display = New System.Windows.Forms.TextBox
        Me.TextBox_UserName = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.TextBox_Psw = New System.Windows.Forms.TextBox
        Me.Label34 = New System.Windows.Forms.Label
        Me.TextBox_UserID = New System.Windows.Forms.TextBox
        Me.Label33 = New System.Windows.Forms.Label
        Me.Label_UserMode = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.TB_UserDept = New System.Windows.Forms.TextBox
        Me.Label_UserID = New System.Windows.Forms.Label
        Me.Cmd_Exit2 = New System.Windows.Forms.ToolStrip
        Me.Cmd_LookEmployee = New System.Windows.Forms.ToolStripButton
        Me.Cmd_SaveUser = New System.Windows.Forms.ToolStripButton
        Me.Cmd_DelUser = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator
        Me.Cmd_Exit = New System.Windows.Forms.ToolStripButton
        Me.Label3 = New System.Windows.Forms.Label
        Me.PanelMain.SuspendLayout()
        Me.Cmd_Exit2.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelMain
        '
        Me.PanelMain.Controls.Add(Me.CB_Invalid)
        Me.PanelMain.Controls.Add(Me.Btn_ChoseDeptForUser)
        Me.PanelMain.Controls.Add(Me.TextBox_ComfirmPsw)
        Me.PanelMain.Controls.Add(Me.Label6)
        Me.PanelMain.Controls.Add(Me.Label9)
        Me.PanelMain.Controls.Add(Me.TextBox_Remark)
        Me.PanelMain.Controls.Add(Me.Label_ComfirmPsw)
        Me.PanelMain.Controls.Add(Me.Label8)
        Me.PanelMain.Controls.Add(Me.ComboBox_UserGroup)
        Me.PanelMain.Controls.Add(Me.Tb_EmployeeID_ForUser)
        Me.PanelMain.Controls.Add(Me.TB_Display)
        Me.PanelMain.Controls.Add(Me.TextBox_UserName)
        Me.PanelMain.Controls.Add(Me.Label10)
        Me.PanelMain.Controls.Add(Me.TextBox_Psw)
        Me.PanelMain.Controls.Add(Me.Label34)
        Me.PanelMain.Controls.Add(Me.TextBox_UserID)
        Me.PanelMain.Controls.Add(Me.Label33)
        Me.PanelMain.Controls.Add(Me.Label_UserMode)
        Me.PanelMain.Controls.Add(Me.Label7)
        Me.PanelMain.Controls.Add(Me.TB_UserDept)
        Me.PanelMain.Controls.Add(Me.Label_UserID)
        Me.PanelMain.Controls.Add(Me.Cmd_Exit2)
        Me.PanelMain.Controls.Add(Me.Label3)
        Me.PanelMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelMain.Location = New System.Drawing.Point(0, 0)
        Me.PanelMain.Name = "PanelMain"
        Me.PanelMain.Padding = New System.Windows.Forms.Padding(2)
        Me.PanelMain.Size = New System.Drawing.Size(522, 307)
        Me.PanelMain.TabIndex = 12
        '
        'CB_Invalid
        '
        Me.CB_Invalid.AutoSize = True
        Me.CB_Invalid.Location = New System.Drawing.Point(305, 238)
        Me.CB_Invalid.Name = "CB_Invalid"
        Me.CB_Invalid.Size = New System.Drawing.Size(54, 18)
        Me.CB_Invalid.TabIndex = 35
        Me.CB_Invalid.Text = "禁用"
        Me.CB_Invalid.UseVisualStyleBackColor = True
        '
        'Btn_ChoseDeptForUser
        '
        Me.Btn_ChoseDeptForUser.Font = New System.Drawing.Font("微软雅黑", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Btn_ChoseDeptForUser.Location = New System.Drawing.Point(229, 158)
        Me.Btn_ChoseDeptForUser.Name = "Btn_ChoseDeptForUser"
        Me.Btn_ChoseDeptForUser.Size = New System.Drawing.Size(25, 23)
        Me.Btn_ChoseDeptForUser.TabIndex = 34
        Me.Btn_ChoseDeptForUser.Text = "..."
        Me.Btn_ChoseDeptForUser.UseVisualStyleBackColor = True
        '
        'TextBox_ComfirmPsw
        '
        Me.TextBox_ComfirmPsw.Location = New System.Drawing.Point(365, 198)
        Me.TextBox_ComfirmPsw.Name = "TextBox_ComfirmPsw"
        Me.TextBox_ComfirmPsw.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextBox_ComfirmPsw.Size = New System.Drawing.Size(116, 23)
        Me.TextBox_ComfirmPsw.TabIndex = 27
        Me.TextBox_ComfirmPsw.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(56, 198)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 14)
        Me.Label6.TabIndex = 23
        Me.Label6.Text = "权限组:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(70, 238)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(42, 14)
        Me.Label9.TabIndex = 22
        Me.Label9.Text = "备注:"
        '
        'TextBox_Remark
        '
        Me.TextBox_Remark.Location = New System.Drawing.Point(118, 235)
        Me.TextBox_Remark.Name = "TextBox_Remark"
        Me.TextBox_Remark.Size = New System.Drawing.Size(121, 23)
        Me.TextBox_Remark.TabIndex = 26
        '
        'Label_ComfirmPsw
        '
        Me.Label_ComfirmPsw.AutoSize = True
        Me.Label_ComfirmPsw.Location = New System.Drawing.Point(278, 201)
        Me.Label_ComfirmPsw.Name = "Label_ComfirmPsw"
        Me.Label_ComfirmPsw.Size = New System.Drawing.Size(70, 14)
        Me.Label_ComfirmPsw.TabIndex = 16
        Me.Label_ComfirmPsw.Text = "确认密码:"
        Me.Label_ComfirmPsw.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(15, 161)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(98, 14)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "用户所属部门:"
        '
        'ComboBox_UserGroup
        '
        Me.ComboBox_UserGroup.DisplayMember = "Group_Name"
        Me.ComboBox_UserGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_UserGroup.FormattingEnabled = True
        Me.ComboBox_UserGroup.Location = New System.Drawing.Point(118, 195)
        Me.ComboBox_UserGroup.Name = "ComboBox_UserGroup"
        Me.ComboBox_UserGroup.Size = New System.Drawing.Size(121, 22)
        Me.ComboBox_UserGroup.TabIndex = 31
        Me.ComboBox_UserGroup.ValueMember = "Group_ID"
        '
        'Tb_EmployeeID_ForUser
        '
        Me.Tb_EmployeeID_ForUser.Location = New System.Drawing.Point(365, 65)
        Me.Tb_EmployeeID_ForUser.Name = "Tb_EmployeeID_ForUser"
        Me.Tb_EmployeeID_ForUser.Size = New System.Drawing.Size(116, 23)
        Me.Tb_EmployeeID_ForUser.TabIndex = 28
        '
        'TB_Display
        '
        Me.TB_Display.Location = New System.Drawing.Point(365, 109)
        Me.TB_Display.Name = "TB_Display"
        Me.TB_Display.Size = New System.Drawing.Size(116, 23)
        Me.TB_Display.TabIndex = 30
        '
        'TextBox_UserName
        '
        Me.TextBox_UserName.Location = New System.Drawing.Point(118, 109)
        Me.TextBox_UserName.Name = "TextBox_UserName"
        Me.TextBox_UserName.Size = New System.Drawing.Size(121, 23)
        Me.TextBox_UserName.TabIndex = 29
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(317, 161)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(42, 14)
        Me.Label10.TabIndex = 17
        Me.Label10.Text = "密码:"
        '
        'TextBox_Psw
        '
        Me.TextBox_Psw.Location = New System.Drawing.Point(365, 158)
        Me.TextBox_Psw.Name = "TextBox_Psw"
        Me.TextBox_Psw.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextBox_Psw.Size = New System.Drawing.Size(116, 23)
        Me.TextBox_Psw.TabIndex = 25
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(303, 68)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(56, 14)
        Me.Label34.TabIndex = 18
        Me.Label34.Text = "员工ID:"
        '
        'TextBox_UserID
        '
        Me.TextBox_UserID.Location = New System.Drawing.Point(118, 65)
        Me.TextBox_UserID.Name = "TextBox_UserID"
        Me.TextBox_UserID.ReadOnly = True
        Me.TextBox_UserID.Size = New System.Drawing.Size(121, 23)
        Me.TextBox_UserID.TabIndex = 24
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(303, 112)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(56, 14)
        Me.Label33.TabIndex = 19
        Me.Label33.Text = "显示名:"
        '
        'Label_UserMode
        '
        Me.Label_UserMode.AutoSize = True
        Me.Label_UserMode.Location = New System.Drawing.Point(28, 261)
        Me.Label_UserMode.Name = "Label_UserMode"
        Me.Label_UserMode.Size = New System.Drawing.Size(0, 14)
        Me.Label_UserMode.TabIndex = 32
        Me.Label_UserMode.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(56, 112)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(56, 14)
        Me.Label7.TabIndex = 21
        Me.Label7.Text = "用户名:"
        '
        'TB_UserDept
        '
        Me.TB_UserDept.Location = New System.Drawing.Point(118, 158)
        Me.TB_UserDept.Name = "TB_UserDept"
        Me.TB_UserDept.ReadOnly = True
        Me.TB_UserDept.Size = New System.Drawing.Size(114, 23)
        Me.TB_UserDept.TabIndex = 33
        '
        'Label_UserID
        '
        Me.Label_UserID.AutoSize = True
        Me.Label_UserID.Location = New System.Drawing.Point(43, 68)
        Me.Label_UserID.Name = "Label_UserID"
        Me.Label_UserID.Size = New System.Drawing.Size(70, 14)
        Me.Label_UserID.TabIndex = 20
        Me.Label_UserID.Text = "用户编号:"
        '
        'Cmd_Exit2
        '
        Me.Cmd_Exit2.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.Cmd_Exit2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Cmd_LookEmployee, Me.Cmd_SaveUser, Me.Cmd_DelUser, Me.ToolStripSeparator7, Me.Cmd_Exit})
        Me.Cmd_Exit2.Location = New System.Drawing.Point(2, 2)
        Me.Cmd_Exit2.MinimumSize = New System.Drawing.Size(0, 44)
        Me.Cmd_Exit2.Name = "Cmd_Exit2"
        Me.Cmd_Exit2.Size = New System.Drawing.Size(518, 44)
        Me.Cmd_Exit2.TabIndex = 13
        Me.Cmd_Exit2.Text = "ToolStrip2"
        '
        'Cmd_LookEmployee
        '
        Me.Cmd_LookEmployee.Image = Global.DN990_BaseSetting.My.Resources.Resources.Look_All
        Me.Cmd_LookEmployee.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_LookEmployee.Name = "Cmd_LookEmployee"
        Me.Cmd_LookEmployee.Size = New System.Drawing.Size(105, 41)
        Me.Cmd_LookEmployee.Text = "查看员工信息"
        '
        'Cmd_SaveUser
        '
        Me.Cmd_SaveUser.AccessibleDescription = "修改按钮"
        Me.Cmd_SaveUser.AccessibleName = ""
        Me.Cmd_SaveUser.Image = Global.DN990_BaseSetting.My.Resources.Resources.Modify
        Me.Cmd_SaveUser.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_SaveUser.Name = "Cmd_SaveUser"
        Me.Cmd_SaveUser.Size = New System.Drawing.Size(57, 41)
        Me.Cmd_SaveUser.Text = "保存"
        '
        'Cmd_DelUser
        '
        Me.Cmd_DelUser.AccessibleDescription = "修改按钮"
        Me.Cmd_DelUser.AccessibleName = ""
        Me.Cmd_DelUser.Image = Global.DN990_BaseSetting.My.Resources.Resources.Delete
        Me.Cmd_DelUser.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_DelUser.Name = "Cmd_DelUser"
        Me.Cmd_DelUser.Size = New System.Drawing.Size(57, 41)
        Me.Cmd_DelUser.Text = "删除"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 44)
        '
        'Cmd_Exit
        '
        Me.Cmd_Exit.Image = Global.DN990_BaseSetting.My.Resources.Resources.Close
        Me.Cmd_Exit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(57, 41)
        Me.Cmd_Exit.Text = "关闭"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(209, 382)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(0, 14)
        Me.Label3.TabIndex = 9
        '
        'F990032_User_Msg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.PanelMain)
        Me.Name = "F990032_User_Msg"
        Me.Size = New System.Drawing.Size(522, 307)
        Me.Title = "用户信息"
        Me.PanelMain.ResumeLayout(False)
        Me.PanelMain.PerformLayout()
        Me.Cmd_Exit2.ResumeLayout(False)
        Me.Cmd_Exit2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelMain As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Cmd_Exit2 As System.Windows.Forms.ToolStrip
    Friend WithEvents Cmd_SaveUser As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_DelUser As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Cmd_Exit As System.Windows.Forms.ToolStripButton
    Friend WithEvents Btn_ChoseDeptForUser As System.Windows.Forms.Button
    Friend WithEvents TextBox_ComfirmPsw As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TextBox_Remark As System.Windows.Forms.TextBox
    Friend WithEvents Label_ComfirmPsw As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ComboBox_UserGroup As System.Windows.Forms.ComboBox
    Friend WithEvents Tb_EmployeeID_ForUser As System.Windows.Forms.TextBox
    Friend WithEvents TB_Display As System.Windows.Forms.TextBox
    Friend WithEvents TextBox_UserName As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TextBox_Psw As System.Windows.Forms.TextBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents TextBox_UserID As System.Windows.Forms.TextBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label_UserMode As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TB_UserDept As System.Windows.Forms.TextBox
    Friend WithEvents Label_UserID As System.Windows.Forms.Label
    Friend WithEvents Cmd_LookEmployee As System.Windows.Forms.ToolStripButton
    Friend WithEvents CB_Invalid As System.Windows.Forms.CheckBox

End Class
