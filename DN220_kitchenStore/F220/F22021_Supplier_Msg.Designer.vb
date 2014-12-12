<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F22022_Supplier_Msg
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
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.Cmd_Exit = New System.Windows.Forms.ToolStripButton
        Me.PanelMain = New System.Windows.Forms.Panel
        Me.DP_Found_Date = New System.Windows.Forms.DateTimePicker
        Me.DP_UPD_DATE = New System.Windows.Forms.DateTimePicker
        Me.TB_Founder = New System.Windows.Forms.TextBox
        Me.TB_UPD_USER = New System.Windows.Forms.TextBox
        Me.TB_Remark = New System.Windows.Forms.TextBox
        Me.TB_WebSite = New System.Windows.Forms.TextBox
        Me.TB_Bank = New System.Windows.Forms.TextBox
        Me.TB_Fax = New System.Windows.Forms.TextBox
        Me.TB_Tel1 = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.TB_Email = New System.Windows.Forms.TextBox
        Me.TB_BankAccount = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.TB_Address = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.TB_Tel2 = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.TB_Contact = New System.Windows.Forms.TextBox
        Me.TB_Mobile = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.TB_Area = New System.Windows.Forms.TextBox
        Me.LB_Mobile = New System.Windows.Forms.Label
        Me.TB_Name = New System.Windows.Forms.TextBox
        Me.LB_Area = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.TB_FullName = New System.Windows.Forms.TextBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.TB_SupplierName = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.TB_ID = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label_ID = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.LB_FullName = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.LB_Contact = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label_ECount = New System.Windows.Forms.Label
        Me.Tool_Top.SuspendLayout()
        Me.PanelMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'Tool_Top
        '
        Me.Tool_Top.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.Tool_Top.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Cmd_Modify, Me.Cmd_Del, Me.ToolStripSeparator2, Me.ToolStripSeparator5, Me.Cmd_Exit})
        Me.Tool_Top.Location = New System.Drawing.Point(0, 0)
        Me.Tool_Top.MinimumSize = New System.Drawing.Size(0, 40)
        Me.Tool_Top.Name = "Tool_Top"
        Me.Tool_Top.Size = New System.Drawing.Size(600, 40)
        Me.Tool_Top.TabIndex = 10
        Me.Tool_Top.Text = "ToolStrip2"
        '
        'Cmd_Modify
        '
        Me.Cmd_Modify.AccessibleDescription = "修改按钮"
        Me.Cmd_Modify.AccessibleName = ""
        Me.Cmd_Modify.Image = Global.DN220_kitchenStore.My.Resources.Resources.Modify
        Me.Cmd_Modify.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Modify.Name = "Cmd_Modify"
        Me.Cmd_Modify.Size = New System.Drawing.Size(57, 37)
        Me.Cmd_Modify.Text = "保存"
        '
        'Cmd_Del
        '
        Me.Cmd_Del.AccessibleDescription = "修改按钮"
        Me.Cmd_Del.AccessibleName = ""
        Me.Cmd_Del.Image = Global.DN220_kitchenStore.My.Resources.Resources.Delete
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
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 40)
        '
        'Cmd_Exit
        '
        Me.Cmd_Exit.Image = Global.DN220_kitchenStore.My.Resources.Resources.Close
        Me.Cmd_Exit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(57, 37)
        Me.Cmd_Exit.Text = "关闭"
        '
        'PanelMain
        '
        Me.PanelMain.Controls.Add(Me.DP_Found_Date)
        Me.PanelMain.Controls.Add(Me.DP_UPD_DATE)
        Me.PanelMain.Controls.Add(Me.TB_Founder)
        Me.PanelMain.Controls.Add(Me.TB_UPD_USER)
        Me.PanelMain.Controls.Add(Me.TB_Remark)
        Me.PanelMain.Controls.Add(Me.TB_WebSite)
        Me.PanelMain.Controls.Add(Me.TB_Bank)
        Me.PanelMain.Controls.Add(Me.TB_Fax)
        Me.PanelMain.Controls.Add(Me.TB_Tel1)
        Me.PanelMain.Controls.Add(Me.Label6)
        Me.PanelMain.Controls.Add(Me.Label23)
        Me.PanelMain.Controls.Add(Me.TB_Email)
        Me.PanelMain.Controls.Add(Me.TB_BankAccount)
        Me.PanelMain.Controls.Add(Me.Label17)
        Me.PanelMain.Controls.Add(Me.TB_Address)
        Me.PanelMain.Controls.Add(Me.Label14)
        Me.PanelMain.Controls.Add(Me.TB_Tel2)
        Me.PanelMain.Controls.Add(Me.Label11)
        Me.PanelMain.Controls.Add(Me.TB_Contact)
        Me.PanelMain.Controls.Add(Me.TB_Mobile)
        Me.PanelMain.Controls.Add(Me.Label8)
        Me.PanelMain.Controls.Add(Me.TB_Area)
        Me.PanelMain.Controls.Add(Me.LB_Mobile)
        Me.PanelMain.Controls.Add(Me.TB_Name)
        Me.PanelMain.Controls.Add(Me.LB_Area)
        Me.PanelMain.Controls.Add(Me.Label5)
        Me.PanelMain.Controls.Add(Me.TB_FullName)
        Me.PanelMain.Controls.Add(Me.Label22)
        Me.PanelMain.Controls.Add(Me.TB_SupplierName)
        Me.PanelMain.Controls.Add(Me.Label19)
        Me.PanelMain.Controls.Add(Me.TB_ID)
        Me.PanelMain.Controls.Add(Me.Label16)
        Me.PanelMain.Controls.Add(Me.Label3)
        Me.PanelMain.Controls.Add(Me.Label_ID)
        Me.PanelMain.Controls.Add(Me.Label22)
        Me.PanelMain.Controls.Add(Me.Label2)
        Me.PanelMain.Controls.Add(Me.Label13)
        Me.PanelMain.Controls.Add(Me.Label18)
        Me.PanelMain.Controls.Add(Me.LB_FullName)
        Me.PanelMain.Controls.Add(Me.Label15)
        Me.PanelMain.Controls.Add(Me.Label10)
        Me.PanelMain.Controls.Add(Me.Label12)
        Me.PanelMain.Controls.Add(Me.LB_Contact)
        Me.PanelMain.Controls.Add(Me.Label9)
        Me.PanelMain.Controls.Add(Me.Label4)
        Me.PanelMain.Controls.Add(Me.Label_ECount)
        Me.PanelMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelMain.Location = New System.Drawing.Point(0, 40)
        Me.PanelMain.Name = "PanelMain"
        Me.PanelMain.Padding = New System.Windows.Forms.Padding(2)
        Me.PanelMain.Size = New System.Drawing.Size(600, 460)
        Me.PanelMain.TabIndex = 0
        '
        'DP_Found_Date
        '
        Me.DP_Found_Date.Location = New System.Drawing.Point(385, 336)
        Me.DP_Found_Date.Name = "DP_Found_Date"
        Me.DP_Found_Date.Size = New System.Drawing.Size(151, 23)
        Me.DP_Found_Date.TabIndex = 17
        '
        'DP_UPD_DATE
        '
        Me.DP_UPD_DATE.Location = New System.Drawing.Point(385, 301)
        Me.DP_UPD_DATE.Name = "DP_UPD_DATE"
        Me.DP_UPD_DATE.Size = New System.Drawing.Size(151, 23)
        Me.DP_UPD_DATE.TabIndex = 16
        '
        'TB_Founder
        '
        Me.TB_Founder.Location = New System.Drawing.Point(131, 336)
        Me.TB_Founder.Name = "TB_Founder"
        Me.TB_Founder.ReadOnly = True
        Me.TB_Founder.Size = New System.Drawing.Size(151, 23)
        Me.TB_Founder.TabIndex = 15
        '
        'TB_UPD_USER
        '
        Me.TB_UPD_USER.Location = New System.Drawing.Point(131, 301)
        Me.TB_UPD_USER.Name = "TB_UPD_USER"
        Me.TB_UPD_USER.ReadOnly = True
        Me.TB_UPD_USER.Size = New System.Drawing.Size(151, 23)
        Me.TB_UPD_USER.TabIndex = 14
        '
        'TB_Remark
        '
        Me.TB_Remark.Location = New System.Drawing.Point(131, 266)
        Me.TB_Remark.Name = "TB_Remark"
        Me.TB_Remark.Size = New System.Drawing.Size(405, 23)
        Me.TB_Remark.TabIndex = 13
        '
        'TB_WebSite
        '
        Me.TB_WebSite.Location = New System.Drawing.Point(131, 231)
        Me.TB_WebSite.Name = "TB_WebSite"
        Me.TB_WebSite.Size = New System.Drawing.Size(151, 23)
        Me.TB_WebSite.TabIndex = 11
        '
        'TB_Bank
        '
        Me.TB_Bank.Location = New System.Drawing.Point(131, 196)
        Me.TB_Bank.Name = "TB_Bank"
        Me.TB_Bank.Size = New System.Drawing.Size(151, 23)
        Me.TB_Bank.TabIndex = 9
        '
        'TB_Fax
        '
        Me.TB_Fax.Location = New System.Drawing.Point(131, 161)
        Me.TB_Fax.Name = "TB_Fax"
        Me.TB_Fax.Size = New System.Drawing.Size(151, 23)
        Me.TB_Fax.TabIndex = 7
        '
        'TB_Tel1
        '
        Me.TB_Tel1.Location = New System.Drawing.Point(131, 126)
        Me.TB_Tel1.Name = "TB_Tel1"
        Me.TB_Tel1.Size = New System.Drawing.Size(151, 23)
        Me.TB_Tel1.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(309, 340)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(70, 14)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "创建时间:"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(288, 305)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(98, 14)
        Me.Label23.TabIndex = 7
        Me.Label23.Text = "最后修改时间:"
        '
        'TB_Email
        '
        Me.TB_Email.Location = New System.Drawing.Point(385, 231)
        Me.TB_Email.Name = "TB_Email"
        Me.TB_Email.Size = New System.Drawing.Size(151, 23)
        Me.TB_Email.TabIndex = 12
        '
        'TB_BankAccount
        '
        Me.TB_BankAccount.Location = New System.Drawing.Point(385, 196)
        Me.TB_BankAccount.Name = "TB_BankAccount"
        Me.TB_BankAccount.Size = New System.Drawing.Size(151, 23)
        Me.TB_BankAccount.TabIndex = 10
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(337, 235)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(42, 14)
        Me.Label17.TabIndex = 7
        Me.Label17.Text = "邮箱:"
        '
        'TB_Address
        '
        Me.TB_Address.Location = New System.Drawing.Point(385, 161)
        Me.TB_Address.Name = "TB_Address"
        Me.TB_Address.Size = New System.Drawing.Size(151, 23)
        Me.TB_Address.TabIndex = 8
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(309, 200)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(70, 14)
        Me.Label14.TabIndex = 7
        Me.Label14.Text = "银行账号:"
        '
        'TB_Tel2
        '
        Me.TB_Tel2.Location = New System.Drawing.Point(385, 126)
        Me.TB_Tel2.Name = "TB_Tel2"
        Me.TB_Tel2.Size = New System.Drawing.Size(151, 23)
        Me.TB_Tel2.TabIndex = 6
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(337, 165)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(42, 14)
        Me.Label11.TabIndex = 7
        Me.Label11.Text = "地址:"
        '
        'TB_Contact
        '
        Me.TB_Contact.Location = New System.Drawing.Point(131, 91)
        Me.TB_Contact.Name = "TB_Contact"
        Me.TB_Contact.Size = New System.Drawing.Size(151, 23)
        Me.TB_Contact.TabIndex = 3
        '
        'TB_Mobile
        '
        Me.TB_Mobile.Location = New System.Drawing.Point(385, 91)
        Me.TB_Mobile.Name = "TB_Mobile"
        Me.TB_Mobile.Size = New System.Drawing.Size(151, 23)
        Me.TB_Mobile.TabIndex = 4
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(330, 130)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(49, 14)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "电话2:"
        '
        'TB_Area
        '
        Me.TB_Area.Location = New System.Drawing.Point(385, 56)
        Me.TB_Area.Name = "TB_Area"
        Me.TB_Area.Size = New System.Drawing.Size(151, 23)
        Me.TB_Area.TabIndex = 2
        '
        'LB_Mobile
        '
        Me.LB_Mobile.AutoSize = True
        Me.LB_Mobile.Location = New System.Drawing.Point(337, 95)
        Me.LB_Mobile.Name = "LB_Mobile"
        Me.LB_Mobile.Size = New System.Drawing.Size(42, 14)
        Me.LB_Mobile.TabIndex = 7
        Me.LB_Mobile.Text = "手机:"
        '
        'TB_Name
        '
        Me.TB_Name.Location = New System.Drawing.Point(385, 22)
        Me.TB_Name.Name = "TB_Name"
        Me.TB_Name.Size = New System.Drawing.Size(151, 23)
        Me.TB_Name.TabIndex = 0
        '
        'LB_Area
        '
        Me.LB_Area.AutoSize = True
        Me.LB_Area.Location = New System.Drawing.Point(309, 60)
        Me.LB_Area.Name = "LB_Area"
        Me.LB_Area.Size = New System.Drawing.Size(70, 14)
        Me.LB_Area.TabIndex = 7
        Me.LB_Area.Text = "所属地区:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(69, 340)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 14)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "创建人:"
        '
        'TB_FullName
        '
        Me.TB_FullName.Location = New System.Drawing.Point(131, 56)
        Me.TB_FullName.Name = "TB_FullName"
        Me.TB_FullName.Size = New System.Drawing.Size(151, 23)
        Me.TB_FullName.TabIndex = 1
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(41, 305)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(84, 14)
        Me.Label22.TabIndex = 6
        Me.Label22.Text = "最后修改人:"
        '
        'TB_SupplierName
        '
        Me.TB_SupplierName.AutoSize = True
        Me.TB_SupplierName.Location = New System.Drawing.Point(295, 25)
        Me.TB_SupplierName.Name = "TB_SupplierName"
        Me.TB_SupplierName.Size = New System.Drawing.Size(84, 14)
        Me.TB_SupplierName.TabIndex = 7
        Me.TB_SupplierName.Text = "供应商名称:"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(83, 270)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(42, 14)
        Me.Label19.TabIndex = 6
        Me.Label19.Text = "备注:"
        '
        'TB_ID
        '
        Me.TB_ID.Location = New System.Drawing.Point(131, 22)
        Me.TB_ID.Name = "TB_ID"
        Me.TB_ID.Size = New System.Drawing.Size(151, 23)
        Me.TB_ID.TabIndex = 13
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(55, 235)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(70, 14)
        Me.Label16.TabIndex = 6
        Me.Label16.Text = "公司网址:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(209, 382)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(0, 14)
        Me.Label3.TabIndex = 9
        '
        'Label_ID
        '
        Me.Label_ID.AutoSize = True
        Me.Label_ID.ForeColor = System.Drawing.Color.Blue
        Me.Label_ID.Location = New System.Drawing.Point(41, 25)
        Me.Label_ID.Name = "Label_ID"
        Me.Label_ID.Size = New System.Drawing.Size(84, 14)
        Me.Label_ID.TabIndex = 7
        Me.Label_ID.Text = "供应商编号:"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(209, 344)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(0, 14)
        Me.Label22.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(209, 347)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(0, 14)
        Me.Label2.TabIndex = 9
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(55, 200)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(70, 14)
        Me.Label13.TabIndex = 6
        Me.Label13.Text = "开户银行:"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(209, 309)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(0, 14)
        Me.Label18.TabIndex = 9
        '
        'LB_FullName
        '
        Me.LB_FullName.AutoSize = True
        Me.LB_FullName.Location = New System.Drawing.Point(41, 60)
        Me.LB_FullName.Name = "LB_FullName"
        Me.LB_FullName.Size = New System.Drawing.Size(84, 14)
        Me.LB_FullName.TabIndex = 5
        Me.LB_FullName.Text = "供应商全称:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(209, 271)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(0, 14)
        Me.Label15.TabIndex = 9
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(83, 165)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(42, 14)
        Me.Label10.TabIndex = 6
        Me.Label10.Text = "传真:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(209, 236)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(0, 14)
        Me.Label12.TabIndex = 9
        '
        'LB_Contact
        '
        Me.LB_Contact.AutoSize = True
        Me.LB_Contact.Location = New System.Drawing.Point(69, 95)
        Me.LB_Contact.Name = "LB_Contact"
        Me.LB_Contact.Size = New System.Drawing.Size(56, 14)
        Me.LB_Contact.TabIndex = 4
        Me.LB_Contact.Text = "联系人:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(209, 198)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(0, 14)
        Me.Label9.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(76, 130)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 14)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "电话1:"
        '
        'Label_ECount
        '
        Me.Label_ECount.AutoSize = True
        Me.Label_ECount.Location = New System.Drawing.Point(209, 163)
        Me.Label_ECount.Name = "Label_ECount"
        Me.Label_ECount.Size = New System.Drawing.Size(0, 14)
        Me.Label_ECount.TabIndex = 9
        '
        'F10101_Supplier_Msg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.PanelMain)
        Me.Controls.Add(Me.Tool_Top)
        Me.Name = "F10101_Supplier_Msg"
        Me.Size = New System.Drawing.Size(600, 500)
        Me.Title = "供应商详细信息"
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
    Friend WithEvents Cmd_Exit As System.Windows.Forms.ToolStripButton
    Friend WithEvents PanelMain As System.Windows.Forms.Panel
    Friend WithEvents TB_Tel1 As System.Windows.Forms.TextBox
    Friend WithEvents TB_FullName As System.Windows.Forms.TextBox
    Friend WithEvents TB_ID As System.Windows.Forms.TextBox
    Friend WithEvents Label_ID As System.Windows.Forms.Label
    Friend WithEvents LB_FullName As System.Windows.Forms.Label
    Friend WithEvents LB_Contact As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label_ECount As System.Windows.Forms.Label
    Friend WithEvents TB_Remark As System.Windows.Forms.TextBox
    Friend WithEvents TB_WebSite As System.Windows.Forms.TextBox
    Friend WithEvents TB_Bank As System.Windows.Forms.TextBox
    Friend WithEvents TB_Fax As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents TB_Email As System.Windows.Forms.TextBox
    Friend WithEvents TB_BankAccount As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents TB_Address As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TB_Tel2 As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TB_Mobile As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TB_Area As System.Windows.Forms.TextBox
    Friend WithEvents LB_Mobile As System.Windows.Forms.Label
    Friend WithEvents TB_Name As System.Windows.Forms.TextBox
    Friend WithEvents LB_Area As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents TB_SupplierName As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TB_UPD_USER As System.Windows.Forms.TextBox
    Friend WithEvents TB_Contact As System.Windows.Forms.TextBox
    Friend WithEvents TB_Founder As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DP_UPD_DATE As System.Windows.Forms.DateTimePicker
    Friend WithEvents DP_Found_Date As System.Windows.Forms.DateTimePicker

End Class
