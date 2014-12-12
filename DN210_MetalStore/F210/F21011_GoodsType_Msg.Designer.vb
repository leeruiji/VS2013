<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F21011_GoodsType_Msg
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
        Me.Btn_ChoseParent = New System.Windows.Forms.Button
        Me.DP_UPD_User = New System.Windows.Forms.DateTimePicker
        Me.TB_UPD_User = New System.Windows.Forms.TextBox
        Me.TB_Remark = New System.Windows.Forms.TextBox
        Me.TB_StartNum = New System.Windows.Forms.TextBox
        Me.TB_Name = New System.Windows.Forms.TextBox
        Me.TB_ID = New System.Windows.Forms.TextBox
        Me.TB_Parent = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.LB_FullName = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.LB_Contact = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
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
        Me.Tool_Top.Size = New System.Drawing.Size(522, 40)
        Me.Tool_Top.TabIndex = 10
        Me.Tool_Top.Text = "ToolStrip2"
        '
        'Cmd_Modify
        '
        Me.Cmd_Modify.AccessibleDescription = "修改按钮"
        Me.Cmd_Modify.AccessibleName = ""
        Me.Cmd_Modify.Image = Global.DN210_MetalStore.My.Resources.Resources.Modify
        Me.Cmd_Modify.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Modify.Name = "Cmd_Modify"
        Me.Cmd_Modify.Size = New System.Drawing.Size(57, 37)
        Me.Cmd_Modify.Text = "保存"
        '
        'Cmd_Del
        '
        Me.Cmd_Del.AccessibleDescription = "修改按钮"
        Me.Cmd_Del.AccessibleName = ""
        Me.Cmd_Del.Image = Global.DN210_MetalStore.My.Resources.Resources.Delete
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
        Me.Cmd_Exit.Image = Global.DN210_MetalStore.My.Resources.Resources.Close
        Me.Cmd_Exit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(57, 37)
        Me.Cmd_Exit.Text = "关闭"
        '
        'PanelMain
        '
        Me.PanelMain.Controls.Add(Me.Btn_ChoseParent)
        Me.PanelMain.Controls.Add(Me.DP_UPD_User)
        Me.PanelMain.Controls.Add(Me.TB_UPD_User)
        Me.PanelMain.Controls.Add(Me.TB_Remark)
        Me.PanelMain.Controls.Add(Me.TB_StartNum)
        Me.PanelMain.Controls.Add(Me.TB_Name)
        Me.PanelMain.Controls.Add(Me.TB_ID)
        Me.PanelMain.Controls.Add(Me.TB_Parent)
        Me.PanelMain.Controls.Add(Me.Label16)
        Me.PanelMain.Controls.Add(Me.Label1)
        Me.PanelMain.Controls.Add(Me.Label13)
        Me.PanelMain.Controls.Add(Me.LB_FullName)
        Me.PanelMain.Controls.Add(Me.Label10)
        Me.PanelMain.Controls.Add(Me.Label12)
        Me.PanelMain.Controls.Add(Me.LB_Contact)
        Me.PanelMain.Controls.Add(Me.Label4)
        Me.PanelMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelMain.Location = New System.Drawing.Point(0, 40)
        Me.PanelMain.Name = "PanelMain"
        Me.PanelMain.Padding = New System.Windows.Forms.Padding(2)
        Me.PanelMain.Size = New System.Drawing.Size(522, 212)
        Me.PanelMain.TabIndex = 12
        '
        'Btn_ChoseParent
        '
        Me.Btn_ChoseParent.Font = New System.Drawing.Font("微软雅黑", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Btn_ChoseParent.Location = New System.Drawing.Point(231, 20)
        Me.Btn_ChoseParent.Name = "Btn_ChoseParent"
        Me.Btn_ChoseParent.Size = New System.Drawing.Size(25, 23)
        Me.Btn_ChoseParent.TabIndex = 15
        Me.Btn_ChoseParent.Text = "..."
        Me.Btn_ChoseParent.UseVisualStyleBackColor = True
        '
        'DP_UPD_User
        '
        Me.DP_UPD_User.Enabled = False
        Me.DP_UPD_User.Location = New System.Drawing.Point(338, 140)
        Me.DP_UPD_User.Name = "DP_UPD_User"
        Me.DP_UPD_User.Size = New System.Drawing.Size(125, 23)
        Me.DP_UPD_User.TabIndex = 14
        '
        'TB_UPD_User
        '
        Me.TB_UPD_User.Location = New System.Drawing.Point(131, 138)
        Me.TB_UPD_User.Name = "TB_UPD_User"
        Me.TB_UPD_User.Size = New System.Drawing.Size(105, 23)
        Me.TB_UPD_User.TabIndex = 11
        '
        'TB_Remark
        '
        Me.TB_Remark.Location = New System.Drawing.Point(131, 99)
        Me.TB_Remark.Name = "TB_Remark"
        Me.TB_Remark.Size = New System.Drawing.Size(332, 23)
        Me.TB_Remark.TabIndex = 11
        '
        'TB_StartNum
        '
        Me.TB_StartNum.Location = New System.Drawing.Point(357, 59)
        Me.TB_StartNum.Name = "TB_StartNum"
        Me.TB_StartNum.Size = New System.Drawing.Size(106, 23)
        Me.TB_StartNum.TabIndex = 11
        '
        'TB_Name
        '
        Me.TB_Name.Location = New System.Drawing.Point(131, 60)
        Me.TB_Name.Name = "TB_Name"
        Me.TB_Name.Size = New System.Drawing.Size(105, 23)
        Me.TB_Name.TabIndex = 10
        '
        'TB_ID
        '
        Me.TB_ID.Location = New System.Drawing.Point(357, 21)
        Me.TB_ID.Name = "TB_ID"
        Me.TB_ID.ReadOnly = True
        Me.TB_ID.Size = New System.Drawing.Size(105, 23)
        Me.TB_ID.TabIndex = 10
        '
        'TB_Parent
        '
        Me.TB_Parent.Location = New System.Drawing.Point(131, 21)
        Me.TB_Parent.Name = "TB_Parent"
        Me.TB_Parent.ReadOnly = True
        Me.TB_Parent.Size = New System.Drawing.Size(105, 23)
        Me.TB_Parent.TabIndex = 13
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(242, 144)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(98, 14)
        Me.Label16.TabIndex = 6
        Me.Label16.Text = "最后修改时间:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(41, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 14)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "上一层分类:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(41, 147)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(84, 14)
        Me.Label13.TabIndex = 6
        Me.Label13.Text = "最后修改人:"
        '
        'LB_FullName
        '
        Me.LB_FullName.AutoSize = True
        Me.LB_FullName.Location = New System.Drawing.Point(281, 24)
        Me.LB_FullName.Name = "LB_FullName"
        Me.LB_FullName.Size = New System.Drawing.Size(70, 14)
        Me.LB_FullName.TabIndex = 5
        Me.LB_FullName.Text = "分类编号:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(83, 108)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(42, 14)
        Me.Label10.TabIndex = 6
        Me.Label10.Text = "备注:"
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
        Me.LB_Contact.Location = New System.Drawing.Point(55, 65)
        Me.LB_Contact.Name = "LB_Contact"
        Me.LB_Contact.Size = New System.Drawing.Size(70, 14)
        Me.LB_Contact.TabIndex = 4
        Me.LB_Contact.Text = "分类名称:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(281, 63)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 14)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "分类前缀:"
        '
        'F21011_GoodsType_Msg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.PanelMain)
        Me.Controls.Add(Me.Tool_Top)
        Me.Name = "F21011_GoodsType_Msg"
        Me.Size = New System.Drawing.Size(522, 252)
        Me.Title = "分类详细信息"
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
    Friend WithEvents TB_StartNum As System.Windows.Forms.TextBox
    Friend WithEvents TB_ID As System.Windows.Forms.TextBox
    Friend WithEvents TB_Parent As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LB_FullName As System.Windows.Forms.Label
    Friend WithEvents LB_Contact As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TB_UPD_User As System.Windows.Forms.TextBox
    Friend WithEvents TB_Remark As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TB_Name As System.Windows.Forms.TextBox
    Friend WithEvents DP_UPD_User As System.Windows.Forms.DateTimePicker
    Friend WithEvents Btn_ChoseParent As System.Windows.Forms.Button

End Class
