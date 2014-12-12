<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F30007_Produce_CG_BeforePB
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F30007_Produce_CG_BeforePB))
        Me.Tool_Top = New System.Windows.Forms.ToolStrip
        Me.Cmd_Modify = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.Cmd_Exit = New System.Windows.Forms.ToolStripButton
        Me.PanelMain = New System.Windows.Forms.Panel
        Me.Employee_List1 = New BaseClass.Employee_List
        Me.TB_GenDan = New System.Windows.Forms.TextBox
        Me.Label45 = New System.Windows.Forms.Label
        Me.TB_KaiDan = New System.Windows.Forms.TextBox
        Me.Label44 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.TB_Remark = New System.Windows.Forms.TextBox
        Me.TB_New_CR_LuoSeBzCount = New System.Windows.Forms.TextBox
        Me.TB_CR_LuoSeBzCount = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.TB_ClientName = New System.Windows.Forms.TextBox
        Me.Label39 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.TB_BZName = New System.Windows.Forms.TextBox
        Me.TB_BZID = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.TB_ClientBZC = New System.Windows.Forms.TextBox
        Me.Label_ID = New System.Windows.Forms.Label
        Me.TB_BZCName = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.TB_BZCID = New System.Windows.Forms.TextBox
        Me.TB_NewGH = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TB_GH = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.LabelMsg = New System.Windows.Forms.Label
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.Pic_From = New System.Windows.Forms.Panel
        Me.Label3 = New System.Windows.Forms.Label
        Me.TB_CGRemark = New System.Windows.Forms.TextBox
        Me.Tool_Top.SuspendLayout()
        Me.PanelMain.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Pic_From.SuspendLayout()
        Me.SuspendLayout()
        '
        'Tool_Top
        '
        Me.Tool_Top.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.Tool_Top.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Cmd_Modify, Me.ToolStripSeparator2, Me.Cmd_Exit})
        Me.Tool_Top.Location = New System.Drawing.Point(0, 0)
        Me.Tool_Top.MinimumSize = New System.Drawing.Size(0, 40)
        Me.Tool_Top.Name = "Tool_Top"
        Me.Tool_Top.Size = New System.Drawing.Size(823, 40)
        Me.Tool_Top.TabIndex = 10
        Me.Tool_Top.Text = "ToolStrip2"
        '
        'Cmd_Modify
        '
        Me.Cmd_Modify.AccessibleDescription = "修改按钮"
        Me.Cmd_Modify.AccessibleName = ""
        Me.Cmd_Modify.Image = CType(resources.GetObject("Cmd_Modify.Image"), System.Drawing.Image)
        Me.Cmd_Modify.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Modify.Name = "Cmd_Modify"
        Me.Cmd_Modify.Size = New System.Drawing.Size(57, 37)
        Me.Cmd_Modify.Text = "保存"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 40)
        '
        'Cmd_Exit
        '
        Me.Cmd_Exit.Image = CType(resources.GetObject("Cmd_Exit.Image"), System.Drawing.Image)
        Me.Cmd_Exit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(57, 37)
        Me.Cmd_Exit.Text = "关闭"
        '
        'PanelMain
        '
        Me.PanelMain.Controls.Add(Me.TB_CGRemark)
        Me.PanelMain.Controls.Add(Me.Label3)
        Me.PanelMain.Controls.Add(Me.Employee_List1)
        Me.PanelMain.Controls.Add(Me.TB_GenDan)
        Me.PanelMain.Controls.Add(Me.Label45)
        Me.PanelMain.Controls.Add(Me.TB_KaiDan)
        Me.PanelMain.Controls.Add(Me.Label44)
        Me.PanelMain.Controls.Add(Me.Label10)
        Me.PanelMain.Controls.Add(Me.TB_Remark)
        Me.PanelMain.Controls.Add(Me.TB_New_CR_LuoSeBzCount)
        Me.PanelMain.Controls.Add(Me.TB_CR_LuoSeBzCount)
        Me.PanelMain.Controls.Add(Me.Label8)
        Me.PanelMain.Controls.Add(Me.Label9)
        Me.PanelMain.Controls.Add(Me.GroupBox3)
        Me.PanelMain.Controls.Add(Me.GroupBox2)
        Me.PanelMain.Controls.Add(Me.GroupBox1)
        Me.PanelMain.Controls.Add(Me.TB_NewGH)
        Me.PanelMain.Controls.Add(Me.Label2)
        Me.PanelMain.Controls.Add(Me.TB_GH)
        Me.PanelMain.Controls.Add(Me.Label1)
        Me.PanelMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelMain.Location = New System.Drawing.Point(0, 40)
        Me.PanelMain.Name = "PanelMain"
        Me.PanelMain.Padding = New System.Windows.Forms.Padding(2)
        Me.PanelMain.Size = New System.Drawing.Size(823, 337)
        Me.PanelMain.TabIndex = 0
        '
        'Employee_List1
        '
        Me.Employee_List1.BackColor = System.Drawing.Color.DodgerBlue
        Me.Employee_List1.IsShowAll = True
        Me.Employee_List1.IsTBLostFocusSelOne = True
        Me.Employee_List1.Location = New System.Drawing.Point(-4000, -4000)
        Me.Employee_List1.Name = "Employee_List1"
        Me.Employee_List1.SearchId = ""
        Me.Employee_List1.SearchType = BaseClass.Employee_List.ENum_SearchType.ALL
        Me.Employee_List1.Size = New System.Drawing.Size(292, 244)
        Me.Employee_List1.TabIndex = 68
        Me.Employee_List1.Visible = False
        '
        'TB_GenDan
        '
        Me.TB_GenDan.Location = New System.Drawing.Point(708, 63)
        Me.TB_GenDan.Name = "TB_GenDan"
        Me.TB_GenDan.Size = New System.Drawing.Size(84, 23)
        Me.TB_GenDan.TabIndex = 3
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Location = New System.Drawing.Point(646, 67)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(56, 14)
        Me.Label45.TabIndex = 67
        Me.Label45.Text = "跟单员:"
        '
        'TB_KaiDan
        '
        Me.TB_KaiDan.Location = New System.Drawing.Point(708, 22)
        Me.TB_KaiDan.Name = "TB_KaiDan"
        Me.TB_KaiDan.ReadOnly = True
        Me.TB_KaiDan.Size = New System.Drawing.Size(84, 23)
        Me.TB_KaiDan.TabIndex = 64
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Location = New System.Drawing.Point(649, 26)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(56, 14)
        Me.Label44.TabIndex = 66
        Me.Label44.Text = "开单员:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(270, 177)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(56, 14)
        Me.Label10.TabIndex = 63
        Me.Label10.Text = "新备注:"
        '
        'TB_Remark
        '
        Me.TB_Remark.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TB_Remark.Location = New System.Drawing.Point(270, 198)
        Me.TB_Remark.Multiline = True
        Me.TB_Remark.Name = "TB_Remark"
        Me.TB_Remark.Size = New System.Drawing.Size(522, 126)
        Me.TB_Remark.TabIndex = 2
        '
        'TB_New_CR_LuoSeBzCount
        '
        Me.TB_New_CR_LuoSeBzCount.Location = New System.Drawing.Point(530, 63)
        Me.TB_New_CR_LuoSeBzCount.Name = "TB_New_CR_LuoSeBzCount"
        Me.TB_New_CR_LuoSeBzCount.Size = New System.Drawing.Size(91, 23)
        Me.TB_New_CR_LuoSeBzCount.TabIndex = 0
        '
        'TB_CR_LuoSeBzCount
        '
        Me.TB_CR_LuoSeBzCount.Location = New System.Drawing.Point(348, 63)
        Me.TB_CR_LuoSeBzCount.Name = "TB_CR_LuoSeBzCount"
        Me.TB_CR_LuoSeBzCount.ReadOnly = True
        Me.TB_CR_LuoSeBzCount.Size = New System.Drawing.Size(91, 23)
        Me.TB_CR_LuoSeBzCount.TabIndex = 60
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(454, 66)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(70, 14)
        Me.Label8.TabIndex = 59
        Me.Label8.Text = "拆开条数:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(286, 66)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(56, 14)
        Me.Label9.TabIndex = 58
        Me.Label9.Text = "原条数:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.TB_ClientName)
        Me.GroupBox3.Controls.Add(Me.Label39)
        Me.GroupBox3.Location = New System.Drawing.Point(5, 12)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(259, 65)
        Me.GroupBox3.TabIndex = 57
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "客户"
        '
        'TB_ClientName
        '
        Me.TB_ClientName.Font = New System.Drawing.Font("宋体", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TB_ClientName.Location = New System.Drawing.Point(92, 11)
        Me.TB_ClientName.Multiline = True
        Me.TB_ClientName.Name = "TB_ClientName"
        Me.TB_ClientName.ReadOnly = True
        Me.TB_ClientName.Size = New System.Drawing.Size(152, 49)
        Me.TB_ClientName.TabIndex = 17
        Me.TB_ClientName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Location = New System.Drawing.Point(20, 19)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(63, 14)
        Me.Label39.TabIndex = 23
        Me.Label39.Text = "客   户:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.TB_BZName)
        Me.GroupBox2.Controls.Add(Me.TB_BZID)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Location = New System.Drawing.Point(5, 83)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(259, 93)
        Me.GroupBox2.TabIndex = 56
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "布类"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(20, 55)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 14)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "名 称:"
        '
        'TB_BZName
        '
        Me.TB_BZName.Location = New System.Drawing.Point(92, 52)
        Me.TB_BZName.Name = "TB_BZName"
        Me.TB_BZName.ReadOnly = True
        Me.TB_BZName.Size = New System.Drawing.Size(152, 23)
        Me.TB_BZName.TabIndex = 16
        '
        'TB_BZID
        '
        Me.TB_BZID.Location = New System.Drawing.Point(92, 22)
        Me.TB_BZID.Name = "TB_BZID"
        Me.TB_BZID.ReadOnly = True
        Me.TB_BZID.Size = New System.Drawing.Size(152, 23)
        Me.TB_BZID.TabIndex = 13
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(20, 25)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 14)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "编 号:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.TB_ClientBZC)
        Me.GroupBox1.Controls.Add(Me.Label_ID)
        Me.GroupBox1.Controls.Add(Me.TB_BZCName)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.TB_BZCID)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 188)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(259, 136)
        Me.GroupBox1.TabIndex = 55
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "颜色/色号"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(6, 93)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(70, 14)
        Me.Label11.TabIndex = 31
        Me.Label11.Text = "客户色号:"
        '
        'TB_ClientBZC
        '
        Me.TB_ClientBZC.Location = New System.Drawing.Point(87, 90)
        Me.TB_ClientBZC.Name = "TB_ClientBZC"
        Me.TB_ClientBZC.ReadOnly = True
        Me.TB_ClientBZC.Size = New System.Drawing.Size(152, 23)
        Me.TB_ClientBZC.TabIndex = 30
        '
        'Label_ID
        '
        Me.Label_ID.AutoSize = True
        Me.Label_ID.ForeColor = System.Drawing.Color.Blue
        Me.Label_ID.Location = New System.Drawing.Point(84, 26)
        Me.Label_ID.Name = "Label_ID"
        Me.Label_ID.Size = New System.Drawing.Size(28, 14)
        Me.Label_ID.TabIndex = 28
        Me.Label_ID.Text = "GY-"
        '
        'TB_BZCName
        '
        Me.TB_BZCName.Location = New System.Drawing.Point(87, 55)
        Me.TB_BZCName.Name = "TB_BZCName"
        Me.TB_BZCName.ReadOnly = True
        Me.TB_BZCName.Size = New System.Drawing.Size(152, 23)
        Me.TB_BZCName.TabIndex = 14
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(20, 58)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(49, 14)
        Me.Label16.TabIndex = 20
        Me.Label16.Text = "颜 色:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(20, 25)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(49, 14)
        Me.Label7.TabIndex = 27
        Me.Label7.Text = "色 号:"
        '
        'TB_BZCID
        '
        Me.TB_BZCID.Location = New System.Drawing.Point(112, 22)
        Me.TB_BZCID.Name = "TB_BZCID"
        Me.TB_BZCID.ReadOnly = True
        Me.TB_BZCID.Size = New System.Drawing.Size(127, 23)
        Me.TB_BZCID.TabIndex = 0
        '
        'TB_NewGH
        '
        Me.TB_NewGH.Location = New System.Drawing.Point(530, 22)
        Me.TB_NewGH.Name = "TB_NewGH"
        Me.TB_NewGH.ReadOnly = True
        Me.TB_NewGH.Size = New System.Drawing.Size(91, 23)
        Me.TB_NewGH.TabIndex = 11
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(468, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 14)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "拆缸号:"
        '
        'TB_GH
        '
        Me.TB_GH.Location = New System.Drawing.Point(348, 23)
        Me.TB_GH.Name = "TB_GH"
        Me.TB_GH.ReadOnly = True
        Me.TB_GH.Size = New System.Drawing.Size(91, 23)
        Me.TB_GH.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(286, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 14)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "原缸号:"
        '
        'LabelMsg
        '
        Me.LabelMsg.ForeColor = System.Drawing.Color.Blue
        Me.LabelMsg.Location = New System.Drawing.Point(76, 156)
        Me.LabelMsg.Name = "LabelMsg"
        Me.LabelMsg.Size = New System.Drawing.Size(403, 16)
        Me.LabelMsg.TabIndex = 13
        Me.LabelMsg.Text = "正在加载..."
        Me.LabelMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(71, 123)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(408, 22)
        Me.ProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.ProgressBar1.TabIndex = 12
        '
        'Pic_From
        '
        Me.Pic_From.Controls.Add(Me.LabelMsg)
        Me.Pic_From.Controls.Add(Me.ProgressBar1)
        Me.Pic_From.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pic_From.Location = New System.Drawing.Point(0, 0)
        Me.Pic_From.Name = "Pic_From"
        Me.Pic_From.Size = New System.Drawing.Size(823, 377)
        Me.Pic_From.TabIndex = 11
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(270, 101)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 14)
        Me.Label3.TabIndex = 69
        Me.Label3.Text = "拆缸原因："
        '
        'TB_CGRemark
        '
        Me.TB_CGRemark.Location = New System.Drawing.Point(348, 101)
        Me.TB_CGRemark.Multiline = True
        Me.TB_CGRemark.Name = "TB_CGRemark"
        Me.TB_CGRemark.Size = New System.Drawing.Size(444, 75)
        Me.TB_CGRemark.TabIndex = 70
        '
        'F30007_Produce_CG_BeforePB
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.PanelMain)
        Me.Controls.Add(Me.Tool_Top)
        Me.Controls.Add(Me.Pic_From)
        Me.Name = "F30007_Produce_CG_BeforePB"
        Me.Size = New System.Drawing.Size(823, 377)
        Me.Title = "拆缸"
        Me.Tool_Top.ResumeLayout(False)
        Me.Tool_Top.PerformLayout()
        Me.PanelMain.ResumeLayout(False)
        Me.PanelMain.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Pic_From.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Tool_Top As System.Windows.Forms.ToolStrip
    Friend WithEvents Cmd_Modify As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Cmd_Exit As System.Windows.Forms.ToolStripButton
    Friend WithEvents PanelMain As System.Windows.Forms.Panel
    Friend WithEvents LabelMsg As System.Windows.Forms.Label
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents Pic_From As System.Windows.Forms.Panel
    Friend WithEvents TB_NewGH As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TB_GH As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents TB_ClientName As System.Windows.Forms.TextBox
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TB_BZName As System.Windows.Forms.TextBox
    Friend WithEvents TB_BZID As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label_ID As System.Windows.Forms.Label
    Friend WithEvents TB_BZCName As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TB_BZCID As System.Windows.Forms.TextBox
    Friend WithEvents TB_New_CR_LuoSeBzCount As System.Windows.Forms.TextBox
    Friend WithEvents TB_CR_LuoSeBzCount As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TB_Remark As System.Windows.Forms.TextBox
    Friend WithEvents TB_GenDan As System.Windows.Forms.TextBox
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents TB_KaiDan As System.Windows.Forms.TextBox
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents Employee_List1 As BaseClass.Employee_List
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TB_ClientBZC As System.Windows.Forms.TextBox
    Friend WithEvents TB_CGRemark As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label

End Class
