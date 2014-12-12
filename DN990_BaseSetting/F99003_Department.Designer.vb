<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F99003_Department
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F99003_Department))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.GroupBox_Dept = New System.Windows.Forms.GroupBox
        Me.RB_Employee = New System.Windows.Forms.RadioButton
        Me.RB_User = New System.Windows.Forms.RadioButton
        Me.TreeView_Dept = New System.Windows.Forms.TreeView
        Me.Menu_TreeView = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.TSMI_AddDept = New System.Windows.Forms.ToolStripMenuItem
        Me.TSMI_AddEmployee = New System.Windows.Forms.ToolStripMenuItem
        Me.TSMI_AddUser = New System.Windows.Forms.ToolStripMenuItem
        Me.TSMI_Del = New System.Windows.Forms.ToolStripMenuItem
        Me.ImageList_Node = New System.Windows.Forms.ImageList(Me.components)
        Me.Tabs = New System.Windows.Forms.TabControl
        Me.Tab_Dept = New System.Windows.Forms.TabPage
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.CB_IsProductive = New System.Windows.Forms.CheckBox
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip
        Me.Cmd_AddDept = New System.Windows.Forms.ToolStripButton
        Me.Cmd_AddEmployee = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator
        Me.Cmd_SaveDept = New System.Windows.Forms.ToolStripButton
        Me.Cmd_DelDept = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.Cmd_Exit = New System.Windows.Forms.ToolStripButton
        Me.TextBox_DeptName = New System.Windows.Forms.TextBox
        Me.TextBox_DeptNo = New System.Windows.Forms.TextBox
        Me.TextBox_DeptSup = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.LB_ZaiZhi = New System.Windows.Forms.Label
        Me.LB_LiZhi = New System.Windows.Forms.Label
        Me.LB_LizhiCount = New System.Windows.Forms.Label
        Me.LB_ZaiZhiCount = New System.Windows.Forms.Label
        Me.Label_ECount = New System.Windows.Forms.Label
        Me.TabEmployeeAndUser = New System.Windows.Forms.TabControl
        Me.TabEmployee = New System.Windows.Forms.TabPage
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.DTP_FirstDateTo = New System.Windows.Forms.DateTimePicker
        Me.DTP_FirstDateFrom = New System.Windows.Forms.DateTimePicker
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.Cmd_Search = New System.Windows.Forms.ToolStripButton
        Me.Cmd_Print = New System.Windows.Forms.ToolStripButton
        Me.Cmd_Preview_Detail = New System.Windows.Forms.ToolStripButton
        Me.Cmd_Preview_Room = New System.Windows.Forms.ToolStripButton
        Me.CB_ConditionName = New System.Windows.Forms.ComboBox
        Me.CB_SearchByDept = New System.Windows.Forms.CheckBox
        Me.RB_All = New System.Windows.Forms.RadioButton
        Me.RB_LiZhi = New System.Windows.Forms.RadioButton
        Me.RB_ZaiZhi = New System.Windows.Forms.RadioButton
        Me.TB_EmployeeNo_Search = New System.Windows.Forms.TextBox
        Me.FG_Employee = New PClass.FG
        Me.Label43 = New System.Windows.Forms.Label
        Me.TB_AgeTo = New System.Windows.Forms.TextBox
        Me.Label41 = New System.Windows.Forms.Label
        Me.Label42 = New System.Windows.Forms.Label
        Me.Label39 = New System.Windows.Forms.Label
        Me.TB_AgeFrom = New System.Windows.Forms.TextBox
        Me.DP_FirstDateTo = New System.Windows.Forms.DateTimePicker
        Me.DP_FirstDateFrom = New System.Windows.Forms.DateTimePicker
        Me.TabUser = New System.Windows.Forms.TabPage
        Me.FG_User = New PClass.FG
        Me.Label_Mode = New System.Windows.Forms.Label
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.OFD_EmP = New System.Windows.Forms.OpenFileDialog
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GroupBox_Dept.SuspendLayout()
        Me.Menu_TreeView.SuspendLayout()
        Me.Tabs.SuspendLayout()
        Me.Tab_Dept.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        Me.TabEmployeeAndUser.SuspendLayout()
        Me.TabEmployee.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.FG_Employee, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabUser.SuspendLayout()
        CType(Me.FG_User, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox_Dept)
        Me.SplitContainer1.Panel1.Padding = New System.Windows.Forms.Padding(3)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.Tabs)
        Me.SplitContainer1.Panel2.Padding = New System.Windows.Forms.Padding(3)
        Me.SplitContainer1.Size = New System.Drawing.Size(1168, 739)
        Me.SplitContainer1.SplitterDistance = 223
        Me.SplitContainer1.TabIndex = 13
        '
        'GroupBox_Dept
        '
        Me.GroupBox_Dept.Controls.Add(Me.RB_Employee)
        Me.GroupBox_Dept.Controls.Add(Me.RB_User)
        Me.GroupBox_Dept.Controls.Add(Me.TreeView_Dept)
        Me.GroupBox_Dept.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox_Dept.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox_Dept.Name = "GroupBox_Dept"
        Me.GroupBox_Dept.Size = New System.Drawing.Size(217, 733)
        Me.GroupBox_Dept.TabIndex = 1
        Me.GroupBox_Dept.TabStop = False
        Me.GroupBox_Dept.Text = "部门列表"
        '
        'RB_Employee
        '
        Me.RB_Employee.AutoSize = True
        Me.RB_Employee.Checked = True
        Me.RB_Employee.Location = New System.Drawing.Point(71, 0)
        Me.RB_Employee.Name = "RB_Employee"
        Me.RB_Employee.Size = New System.Drawing.Size(81, 18)
        Me.RB_Employee.TabIndex = 1
        Me.RB_Employee.TabStop = True
        Me.RB_Employee.Text = "显示员工"
        Me.RB_Employee.UseVisualStyleBackColor = True
        '
        'RB_User
        '
        Me.RB_User.AutoSize = True
        Me.RB_User.Location = New System.Drawing.Point(158, 0)
        Me.RB_User.Name = "RB_User"
        Me.RB_User.Size = New System.Drawing.Size(81, 18)
        Me.RB_User.TabIndex = 2
        Me.RB_User.Text = "显示用户"
        Me.RB_User.UseVisualStyleBackColor = True
        '
        'TreeView_Dept
        '
        Me.TreeView_Dept.AllowDrop = True
        Me.TreeView_Dept.BackColor = System.Drawing.Color.White
        Me.TreeView_Dept.ContextMenuStrip = Me.Menu_TreeView
        Me.TreeView_Dept.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeView_Dept.HideSelection = False
        Me.TreeView_Dept.ImageIndex = 0
        Me.TreeView_Dept.ImageList = Me.ImageList_Node
        Me.TreeView_Dept.Location = New System.Drawing.Point(3, 19)
        Me.TreeView_Dept.Name = "TreeView_Dept"
        Me.TreeView_Dept.SelectedImageIndex = 1
        Me.TreeView_Dept.Size = New System.Drawing.Size(211, 711)
        Me.TreeView_Dept.TabIndex = 0
        '
        'Menu_TreeView
        '
        Me.Menu_TreeView.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSMI_AddDept, Me.TSMI_AddEmployee, Me.TSMI_AddUser, Me.TSMI_Del})
        Me.Menu_TreeView.Name = "Menu_TreeView"
        Me.Menu_TreeView.Size = New System.Drawing.Size(119, 92)
        '
        'TSMI_AddDept
        '
        Me.TSMI_AddDept.Name = "TSMI_AddDept"
        Me.TSMI_AddDept.Size = New System.Drawing.Size(118, 22)
        Me.TSMI_AddDept.Text = "添加部门"
        '
        'TSMI_AddEmployee
        '
        Me.TSMI_AddEmployee.Name = "TSMI_AddEmployee"
        Me.TSMI_AddEmployee.Size = New System.Drawing.Size(118, 22)
        Me.TSMI_AddEmployee.Text = "添加员工"
        '
        'TSMI_AddUser
        '
        Me.TSMI_AddUser.Name = "TSMI_AddUser"
        Me.TSMI_AddUser.Size = New System.Drawing.Size(118, 22)
        Me.TSMI_AddUser.Text = "添加用户"
        Me.TSMI_AddUser.Visible = False
        '
        'TSMI_Del
        '
        Me.TSMI_Del.Name = "TSMI_Del"
        Me.TSMI_Del.Size = New System.Drawing.Size(118, 22)
        Me.TSMI_Del.Text = "删除"
        '
        'ImageList_Node
        '
        Me.ImageList_Node.ImageStream = CType(resources.GetObject("ImageList_Node.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList_Node.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList_Node.Images.SetKeyName(0, "Node.png")
        Me.ImageList_Node.Images.SetKeyName(1, "NodeSelected.png")
        Me.ImageList_Node.Images.SetKeyName(2, "Employee.png")
        Me.ImageList_Node.Images.SetKeyName(3, "User.png")
        '
        'Tabs
        '
        Me.Tabs.Controls.Add(Me.Tab_Dept)
        Me.Tabs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Tabs.Location = New System.Drawing.Point(3, 3)
        Me.Tabs.Name = "Tabs"
        Me.Tabs.SelectedIndex = 0
        Me.Tabs.Size = New System.Drawing.Size(935, 733)
        Me.Tabs.TabIndex = 12
        '
        'Tab_Dept
        '
        Me.Tab_Dept.AutoScroll = True
        Me.Tab_Dept.BackColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Tab_Dept.Controls.Add(Me.Panel1)
        Me.Tab_Dept.Location = New System.Drawing.Point(4, 23)
        Me.Tab_Dept.Name = "Tab_Dept"
        Me.Tab_Dept.Padding = New System.Windows.Forms.Padding(3)
        Me.Tab_Dept.Size = New System.Drawing.Size(927, 706)
        Me.Tab_Dept.TabIndex = 1
        Me.Tab_Dept.Text = "部门信息"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.CB_IsProductive)
        Me.Panel1.Controls.Add(Me.ToolStrip2)
        Me.Panel1.Controls.Add(Me.TextBox_DeptName)
        Me.Panel1.Controls.Add(Me.TextBox_DeptNo)
        Me.Panel1.Controls.Add(Me.TextBox_DeptSup)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.LB_ZaiZhi)
        Me.Panel1.Controls.Add(Me.LB_LiZhi)
        Me.Panel1.Controls.Add(Me.LB_LizhiCount)
        Me.Panel1.Controls.Add(Me.LB_ZaiZhiCount)
        Me.Panel1.Controls.Add(Me.Label_ECount)
        Me.Panel1.Controls.Add(Me.TabEmployeeAndUser)
        Me.Panel1.Controls.Add(Me.Label_Mode)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(921, 700)
        Me.Panel1.TabIndex = 12
        '
        'CB_IsProductive
        '
        Me.CB_IsProductive.AutoSize = True
        Me.CB_IsProductive.Location = New System.Drawing.Point(587, 54)
        Me.CB_IsProductive.Name = "CB_IsProductive"
        Me.CB_IsProductive.Size = New System.Drawing.Size(110, 18)
        Me.CB_IsProductive.TabIndex = 38
        Me.CB_IsProductive.Text = "是否生成部门"
        Me.CB_IsProductive.UseVisualStyleBackColor = True
        '
        'ToolStrip2
        '
        Me.ToolStrip2.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Cmd_AddDept, Me.Cmd_AddEmployee, Me.ToolStripSeparator6, Me.Cmd_SaveDept, Me.Cmd_DelDept, Me.ToolStripSeparator5, Me.Cmd_Exit})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.MinimumSize = New System.Drawing.Size(0, 44)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(921, 44)
        Me.ToolStrip2.TabIndex = 32
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'Cmd_AddDept
        '
        Me.Cmd_AddDept.AccessibleDescription = "添加按钮"
        Me.Cmd_AddDept.AccessibleName = ""
        Me.Cmd_AddDept.Image = Global.DN990_BaseSetting.My.Resources.Resources.ADD
        Me.Cmd_AddDept.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_AddDept.Name = "Cmd_AddDept"
        Me.Cmd_AddDept.Size = New System.Drawing.Size(57, 41)
        Me.Cmd_AddDept.Text = "添加部门"
        Me.Cmd_AddDept.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'Cmd_AddEmployee
        '
        Me.Cmd_AddEmployee.Image = Global.DN990_BaseSetting.My.Resources.Resources.ADD
        Me.Cmd_AddEmployee.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_AddEmployee.Name = "Cmd_AddEmployee"
        Me.Cmd_AddEmployee.Size = New System.Drawing.Size(57, 41)
        Me.Cmd_AddEmployee.Text = "添加员工"
        Me.Cmd_AddEmployee.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 44)
        '
        'Cmd_SaveDept
        '
        Me.Cmd_SaveDept.AccessibleDescription = "修改按钮"
        Me.Cmd_SaveDept.AccessibleName = ""
        Me.Cmd_SaveDept.Image = Global.DN990_BaseSetting.My.Resources.Resources.Modify
        Me.Cmd_SaveDept.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_SaveDept.Name = "Cmd_SaveDept"
        Me.Cmd_SaveDept.Size = New System.Drawing.Size(81, 41)
        Me.Cmd_SaveDept.Text = "保存部门修改"
        Me.Cmd_SaveDept.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'Cmd_DelDept
        '
        Me.Cmd_DelDept.AccessibleDescription = "修改按钮"
        Me.Cmd_DelDept.AccessibleName = ""
        Me.Cmd_DelDept.Image = Global.DN990_BaseSetting.My.Resources.Resources.Delete
        Me.Cmd_DelDept.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_DelDept.Name = "Cmd_DelDept"
        Me.Cmd_DelDept.Size = New System.Drawing.Size(57, 41)
        Me.Cmd_DelDept.Text = "删除部门"
        Me.Cmd_DelDept.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 44)
        '
        'Cmd_Exit
        '
        Me.Cmd_Exit.Image = Global.DN990_BaseSetting.My.Resources.Resources.Close
        Me.Cmd_Exit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(33, 41)
        Me.Cmd_Exit.Text = "关闭"
        Me.Cmd_Exit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'TextBox_DeptName
        '
        Me.TextBox_DeptName.Location = New System.Drawing.Point(130, 95)
        Me.TextBox_DeptName.Name = "TextBox_DeptName"
        Me.TextBox_DeptName.Size = New System.Drawing.Size(151, 23)
        Me.TextBox_DeptName.TabIndex = 29
        '
        'TextBox_DeptNo
        '
        Me.TextBox_DeptNo.Location = New System.Drawing.Point(130, 52)
        Me.TextBox_DeptNo.Name = "TextBox_DeptNo"
        Me.TextBox_DeptNo.ReadOnly = True
        Me.TextBox_DeptNo.Size = New System.Drawing.Size(151, 23)
        Me.TextBox_DeptNo.TabIndex = 30
        '
        'TextBox_DeptSup
        '
        Me.TextBox_DeptSup.Location = New System.Drawing.Point(409, 52)
        Me.TextBox_DeptSup.Name = "TextBox_DeptSup"
        Me.TextBox_DeptSup.Size = New System.Drawing.Size(151, 23)
        Me.TextBox_DeptSup.TabIndex = 31
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(40, 55)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 14)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "部门编号:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(40, 98)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 14)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "部门名称:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(319, 55)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 14)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "部门负责人:"
        '
        'LB_ZaiZhi
        '
        Me.LB_ZaiZhi.AutoSize = True
        Me.LB_ZaiZhi.Location = New System.Drawing.Point(406, 98)
        Me.LB_ZaiZhi.Name = "LB_ZaiZhi"
        Me.LB_ZaiZhi.Size = New System.Drawing.Size(0, 14)
        Me.LB_ZaiZhi.TabIndex = 26
        '
        'LB_LiZhi
        '
        Me.LB_LiZhi.AutoSize = True
        Me.LB_LiZhi.Location = New System.Drawing.Point(566, 98)
        Me.LB_LiZhi.Name = "LB_LiZhi"
        Me.LB_LiZhi.Size = New System.Drawing.Size(0, 14)
        Me.LB_LiZhi.TabIndex = 26
        '
        'LB_LizhiCount
        '
        Me.LB_LizhiCount.AutoSize = True
        Me.LB_LizhiCount.Location = New System.Drawing.Point(490, 98)
        Me.LB_LizhiCount.Name = "LB_LizhiCount"
        Me.LB_LizhiCount.Size = New System.Drawing.Size(70, 14)
        Me.LB_LizhiCount.TabIndex = 26
        Me.LB_LizhiCount.Text = "离职人数:"
        '
        'LB_ZaiZhiCount
        '
        Me.LB_ZaiZhiCount.AutoSize = True
        Me.LB_ZaiZhiCount.Location = New System.Drawing.Point(333, 98)
        Me.LB_ZaiZhiCount.Name = "LB_ZaiZhiCount"
        Me.LB_ZaiZhiCount.Size = New System.Drawing.Size(70, 14)
        Me.LB_ZaiZhiCount.TabIndex = 27
        Me.LB_ZaiZhiCount.Text = "在职人数:"
        '
        'Label_ECount
        '
        Me.Label_ECount.AutoSize = True
        Me.Label_ECount.Location = New System.Drawing.Point(158, 91)
        Me.Label_ECount.Name = "Label_ECount"
        Me.Label_ECount.Size = New System.Drawing.Size(0, 14)
        Me.Label_ECount.TabIndex = 28
        Me.Label_ECount.Visible = False
        '
        'TabEmployeeAndUser
        '
        Me.TabEmployeeAndUser.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabEmployeeAndUser.Controls.Add(Me.TabEmployee)
        Me.TabEmployeeAndUser.Controls.Add(Me.TabUser)
        Me.TabEmployeeAndUser.Location = New System.Drawing.Point(3, 127)
        Me.TabEmployeeAndUser.Name = "TabEmployeeAndUser"
        Me.TabEmployeeAndUser.SelectedIndex = 0
        Me.TabEmployeeAndUser.Size = New System.Drawing.Size(915, 570)
        Me.TabEmployeeAndUser.TabIndex = 37
        '
        'TabEmployee
        '
        Me.TabEmployee.Controls.Add(Me.Label5)
        Me.TabEmployee.Controls.Add(Me.Label4)
        Me.TabEmployee.Controls.Add(Me.DTP_FirstDateTo)
        Me.TabEmployee.Controls.Add(Me.DTP_FirstDateFrom)
        Me.TabEmployee.Controls.Add(Me.ToolStrip1)
        Me.TabEmployee.Controls.Add(Me.CB_ConditionName)
        Me.TabEmployee.Controls.Add(Me.CB_SearchByDept)
        Me.TabEmployee.Controls.Add(Me.RB_All)
        Me.TabEmployee.Controls.Add(Me.RB_LiZhi)
        Me.TabEmployee.Controls.Add(Me.RB_ZaiZhi)
        Me.TabEmployee.Controls.Add(Me.TB_EmployeeNo_Search)
        Me.TabEmployee.Controls.Add(Me.FG_Employee)
        Me.TabEmployee.Controls.Add(Me.Label43)
        Me.TabEmployee.Controls.Add(Me.TB_AgeTo)
        Me.TabEmployee.Controls.Add(Me.Label41)
        Me.TabEmployee.Controls.Add(Me.Label42)
        Me.TabEmployee.Controls.Add(Me.Label39)
        Me.TabEmployee.Controls.Add(Me.TB_AgeFrom)
        Me.TabEmployee.Controls.Add(Me.DP_FirstDateTo)
        Me.TabEmployee.Controls.Add(Me.DP_FirstDateFrom)
        Me.TabEmployee.Location = New System.Drawing.Point(4, 23)
        Me.TabEmployee.Name = "TabEmployee"
        Me.TabEmployee.Padding = New System.Windows.Forms.Padding(3)
        Me.TabEmployee.Size = New System.Drawing.Size(907, 543)
        Me.TabEmployee.TabIndex = 0
        Me.TabEmployee.Text = "员工列表"
        Me.TabEmployee.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(10, 45)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 14)
        Me.Label5.TabIndex = 58
        Me.Label5.Text = "离职日期:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(206, 45)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(14, 14)
        Me.Label4.TabIndex = 57
        Me.Label4.Text = "-"
        '
        'DTP_FirstDateTo
        '
        Me.DTP_FirstDateTo.Checked = False
        Me.DTP_FirstDateTo.CustomFormat = "yyyy-MM-dd"
        Me.DTP_FirstDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTP_FirstDateTo.Location = New System.Drawing.Point(232, 41)
        Me.DTP_FirstDateTo.Name = "DTP_FirstDateTo"
        Me.DTP_FirstDateTo.ShowCheckBox = True
        Me.DTP_FirstDateTo.Size = New System.Drawing.Size(113, 23)
        Me.DTP_FirstDateTo.TabIndex = 56
        '
        'DTP_FirstDateFrom
        '
        Me.DTP_FirstDateFrom.Checked = False
        Me.DTP_FirstDateFrom.CustomFormat = "yyyy-MM-dd"
        Me.DTP_FirstDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTP_FirstDateFrom.Location = New System.Drawing.Point(86, 41)
        Me.DTP_FirstDateFrom.Name = "DTP_FirstDateFrom"
        Me.DTP_FirstDateFrom.ShowCheckBox = True
        Me.DTP_FirstDateFrom.Size = New System.Drawing.Size(110, 23)
        Me.DTP_FirstDateFrom.TabIndex = 55
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Cmd_Search, Me.Cmd_Print, Me.Cmd_Preview_Detail, Me.Cmd_Preview_Room})
        Me.ToolStrip1.Location = New System.Drawing.Point(685, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(216, 35)
        Me.ToolStrip1.TabIndex = 54
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'Cmd_Search
        '
        Me.Cmd_Search.Image = Global.DN990_BaseSetting.My.Resources.Resources.Look_All
        Me.Cmd_Search.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Search.Name = "Cmd_Search"
        Me.Cmd_Search.Size = New System.Drawing.Size(33, 32)
        Me.Cmd_Search.Text = "搜索"
        Me.Cmd_Search.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'Cmd_Print
        '
        Me.Cmd_Print.Image = Global.DN990_BaseSetting.My.Resources.Resources.Print_preview
        Me.Cmd_Print.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Print.Name = "Cmd_Print"
        Me.Cmd_Print.Size = New System.Drawing.Size(57, 32)
        Me.Cmd_Print.Text = "员工列表"
        Me.Cmd_Print.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'Cmd_Preview_Detail
        '
        Me.Cmd_Preview_Detail.Image = Global.DN990_BaseSetting.My.Resources.Resources.Print_preview
        Me.Cmd_Preview_Detail.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Preview_Detail.Name = "Cmd_Preview_Detail"
        Me.Cmd_Preview_Detail.Size = New System.Drawing.Size(57, 32)
        Me.Cmd_Preview_Detail.Text = "详细人事"
        Me.Cmd_Preview_Detail.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'Cmd_Preview_Room
        '
        Me.Cmd_Preview_Room.Image = Global.DN990_BaseSetting.My.Resources.Resources.Print_preview
        Me.Cmd_Preview_Room.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Preview_Room.Name = "Cmd_Preview_Room"
        Me.Cmd_Preview_Room.Size = New System.Drawing.Size(57, 32)
        Me.Cmd_Preview_Room.Text = "宿舍编排"
        Me.Cmd_Preview_Room.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'CB_ConditionName
        '
        Me.CB_ConditionName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_ConditionName.FormattingEnabled = True
        Me.CB_ConditionName.Location = New System.Drawing.Point(484, 5)
        Me.CB_ConditionName.Name = "CB_ConditionName"
        Me.CB_ConditionName.Size = New System.Drawing.Size(92, 22)
        Me.CB_ConditionName.TabIndex = 53
        '
        'CB_SearchByDept
        '
        Me.CB_SearchByDept.AutoSize = True
        Me.CB_SearchByDept.Checked = True
        Me.CB_SearchByDept.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CB_SearchByDept.Location = New System.Drawing.Point(682, 43)
        Me.CB_SearchByDept.Name = "CB_SearchByDept"
        Me.CB_SearchByDept.Size = New System.Drawing.Size(152, 18)
        Me.CB_SearchByDept.TabIndex = 52
        Me.CB_SearchByDept.Text = "在选择的部门内搜索"
        Me.CB_SearchByDept.UseVisualStyleBackColor = True
        '
        'RB_All
        '
        Me.RB_All.AutoSize = True
        Me.RB_All.Location = New System.Drawing.Point(606, 43)
        Me.RB_All.Name = "RB_All"
        Me.RB_All.Size = New System.Drawing.Size(53, 18)
        Me.RB_All.TabIndex = 49
        Me.RB_All.TabStop = True
        Me.RB_All.Text = "所有"
        Me.RB_All.UseVisualStyleBackColor = True
        '
        'RB_LiZhi
        '
        Me.RB_LiZhi.AutoSize = True
        Me.RB_LiZhi.Location = New System.Drawing.Point(490, 43)
        Me.RB_LiZhi.Name = "RB_LiZhi"
        Me.RB_LiZhi.Size = New System.Drawing.Size(95, 18)
        Me.RB_LiZhi.TabIndex = 50
        Me.RB_LiZhi.TabStop = True
        Me.RB_LiZhi.Text = "只显示离职"
        Me.RB_LiZhi.UseVisualStyleBackColor = True
        '
        'RB_ZaiZhi
        '
        Me.RB_ZaiZhi.AutoSize = True
        Me.RB_ZaiZhi.Checked = True
        Me.RB_ZaiZhi.Location = New System.Drawing.Point(370, 43)
        Me.RB_ZaiZhi.Name = "RB_ZaiZhi"
        Me.RB_ZaiZhi.Size = New System.Drawing.Size(95, 18)
        Me.RB_ZaiZhi.TabIndex = 51
        Me.RB_ZaiZhi.TabStop = True
        Me.RB_ZaiZhi.Text = "只显示在职"
        Me.RB_ZaiZhi.UseVisualStyleBackColor = True
        '
        'TB_EmployeeNo_Search
        '
        Me.TB_EmployeeNo_Search.Location = New System.Drawing.Point(580, 5)
        Me.TB_EmployeeNo_Search.Name = "TB_EmployeeNo_Search"
        Me.TB_EmployeeNo_Search.Size = New System.Drawing.Size(101, 23)
        Me.TB_EmployeeNo_Search.TabIndex = 42
        '
        'FG_Employee
        '
        Me.FG_Employee.AddCopyMenu = False
        Me.FG_Employee.AllowEditing = False
        Me.FG_Employee.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FG_Employee.AutoAddIndex = True
        Me.FG_Employee.AutoGenerateColumns = False
        Me.FG_Employee.AutoResize = False
        Me.FG_Employee.BackColor = System.Drawing.Color.White
        Me.FG_Employee.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.FG_Employee.CanEditing = False
        Me.FG_Employee.CheckKeyPressEdit = True
        Me.FG_Employee.ColumnInfo = resources.GetString("FG_Employee.ColumnInfo")
        Me.FG_Employee.EditFormat = True
        Me.FG_Employee.ExtendLastCol = True
        Me.FG_Employee.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.FG_Employee.ForeColor = System.Drawing.Color.Black
        Me.FG_Employee.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.FG_Employee.IsAutoAddRow = True
        Me.FG_Employee.IsClickStartEdit = True
        Me.FG_Employee.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.FG_Employee.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.FG_Employee.Location = New System.Drawing.Point(6, 70)
        Me.FG_Employee.Name = "FG_Employee"
        Me.FG_Employee.NoShowMenu = False
        Me.FG_Employee.Rows.Count = 10
        Me.FG_Employee.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.FG_Employee.Size = New System.Drawing.Size(901, 473)
        Me.FG_Employee.StartCol = ""
        Me.FG_Employee.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("FG_Employee.Styles"))
        Me.FG_Employee.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.BelowData
        Me.FG_Employee.TabIndex = 37
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Location = New System.Drawing.Point(437, 9)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(14, 14)
        Me.Label43.TabIndex = 47
        Me.Label43.Text = "-"
        '
        'TB_AgeTo
        '
        Me.TB_AgeTo.Location = New System.Drawing.Point(451, 5)
        Me.TB_AgeTo.Name = "TB_AgeTo"
        Me.TB_AgeTo.Size = New System.Drawing.Size(32, 23)
        Me.TB_AgeTo.TabIndex = 40
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Location = New System.Drawing.Point(206, 9)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(14, 14)
        Me.Label41.TabIndex = 46
        Me.Label41.Text = "-"
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Location = New System.Drawing.Point(354, 9)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(42, 14)
        Me.Label42.TabIndex = 39
        Me.Label42.Text = "年龄:"
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Location = New System.Drawing.Point(10, 9)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(70, 14)
        Me.Label39.TabIndex = 45
        Me.Label39.Text = "入职日期:"
        '
        'TB_AgeFrom
        '
        Me.TB_AgeFrom.Location = New System.Drawing.Point(402, 5)
        Me.TB_AgeFrom.Name = "TB_AgeFrom"
        Me.TB_AgeFrom.Size = New System.Drawing.Size(32, 23)
        Me.TB_AgeFrom.TabIndex = 41
        '
        'DP_FirstDateTo
        '
        Me.DP_FirstDateTo.Checked = False
        Me.DP_FirstDateTo.CustomFormat = "yyyy-MM-dd"
        Me.DP_FirstDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DP_FirstDateTo.Location = New System.Drawing.Point(232, 5)
        Me.DP_FirstDateTo.Name = "DP_FirstDateTo"
        Me.DP_FirstDateTo.ShowCheckBox = True
        Me.DP_FirstDateTo.Size = New System.Drawing.Size(113, 23)
        Me.DP_FirstDateTo.TabIndex = 44
        '
        'DP_FirstDateFrom
        '
        Me.DP_FirstDateFrom.Checked = False
        Me.DP_FirstDateFrom.CustomFormat = "yyyy-MM-dd"
        Me.DP_FirstDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DP_FirstDateFrom.Location = New System.Drawing.Point(86, 5)
        Me.DP_FirstDateFrom.Name = "DP_FirstDateFrom"
        Me.DP_FirstDateFrom.ShowCheckBox = True
        Me.DP_FirstDateFrom.Size = New System.Drawing.Size(110, 23)
        Me.DP_FirstDateFrom.TabIndex = 43
        '
        'TabUser
        '
        Me.TabUser.Controls.Add(Me.FG_User)
        Me.TabUser.Location = New System.Drawing.Point(4, 23)
        Me.TabUser.Name = "TabUser"
        Me.TabUser.Padding = New System.Windows.Forms.Padding(3)
        Me.TabUser.Size = New System.Drawing.Size(907, 543)
        Me.TabUser.TabIndex = 1
        Me.TabUser.Text = "用户列表"
        Me.TabUser.UseVisualStyleBackColor = True
        '
        'FG_User
        '
        Me.FG_User.AddCopyMenu = False
        Me.FG_User.AllowEditing = False
        Me.FG_User.AutoAddIndex = True
        Me.FG_User.AutoGenerateColumns = False
        Me.FG_User.AutoResize = False
        Me.FG_User.BackColor = System.Drawing.Color.White
        Me.FG_User.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.FG_User.CanEditing = False
        Me.FG_User.CheckKeyPressEdit = True
        Me.FG_User.ColumnInfo = resources.GetString("FG_User.ColumnInfo")
        Me.FG_User.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FG_User.EditFormat = True
        Me.FG_User.ExtendLastCol = True
        Me.FG_User.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.FG_User.ForeColor = System.Drawing.Color.Black
        Me.FG_User.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.FG_User.IsAutoAddRow = True
        Me.FG_User.IsClickStartEdit = True
        Me.FG_User.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.FG_User.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.FG_User.Location = New System.Drawing.Point(3, 3)
        Me.FG_User.Name = "FG_User"
        Me.FG_User.NoShowMenu = False
        Me.FG_User.Rows.Count = 10
        Me.FG_User.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.FG_User.Size = New System.Drawing.Size(901, 537)
        Me.FG_User.StartCol = ""
        Me.FG_User.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("FG_User.Styles"))
        Me.FG_User.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.BelowData
        Me.FG_User.TabIndex = 13
        '
        'Label_Mode
        '
        Me.Label_Mode.AutoSize = True
        Me.Label_Mode.Location = New System.Drawing.Point(27, 277)
        Me.Label_Mode.Name = "Label_Mode"
        Me.Label_Mode.Size = New System.Drawing.Size(0, 14)
        Me.Label_Mode.TabIndex = 5
        Me.Label_Mode.Visible = False
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 40)
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 40)
        '
        'OFD_EmP
        '
        Me.OFD_EmP.FileName = "OpenFileDialog1"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.AccessibleDescription = "修改按钮"
        Me.ToolStripButton1.AccessibleName = ""
        Me.ToolStripButton1.Image = Global.DN990_BaseSetting.My.Resources.Resources.ADD
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(33, 37)
        Me.ToolStripButton1.Text = "新增"
        Me.ToolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.AccessibleDescription = "修改按钮"
        Me.ToolStripButton2.AccessibleName = ""
        Me.ToolStripButton2.Image = Global.DN990_BaseSetting.My.Resources.Resources.Modify
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(33, 37)
        Me.ToolStripButton2.Text = "保存"
        Me.ToolStripButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.AccessibleDescription = "修改按钮"
        Me.ToolStripButton3.AccessibleName = ""
        Me.ToolStripButton3.Image = Global.DN990_BaseSetting.My.Resources.Resources.Delete
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(33, 37)
        Me.ToolStripButton3.Text = "删除"
        Me.ToolStripButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.Image = Global.DN990_BaseSetting.My.Resources.Resources.Paste
        Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.Size = New System.Drawing.Size(57, 37)
        Me.ToolStripButton4.Text = "标记离职"
        Me.ToolStripButton4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'F99003_Department
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "F99003_Department"
        Me.Size = New System.Drawing.Size(1168, 739)
        Me.Title = "部门及员工"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.GroupBox_Dept.ResumeLayout(False)
        Me.GroupBox_Dept.PerformLayout()
        Me.Menu_TreeView.ResumeLayout(False)
        Me.Tabs.ResumeLayout(False)
        Me.Tab_Dept.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.TabEmployeeAndUser.ResumeLayout(False)
        Me.TabEmployee.ResumeLayout(False)
        Me.TabEmployee.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.FG_Employee, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabUser.ResumeLayout(False)
        CType(Me.FG_User, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents TreeView_Dept As System.Windows.Forms.TreeView
    Friend WithEvents GroupBox_Dept As System.Windows.Forms.GroupBox
    Friend WithEvents Menu_TreeView As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents TSMI_AddDept As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSMI_AddEmployee As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RB_User As System.Windows.Forms.RadioButton
    Friend WithEvents RB_Employee As System.Windows.Forms.RadioButton
    Friend WithEvents TSMI_AddUser As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TSMI_Del As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OFD_EmP As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ImageList_Node As System.Windows.Forms.ImageList
    Friend WithEvents Tabs As System.Windows.Forms.TabControl
    Friend WithEvents Tab_Dept As System.Windows.Forms.TabPage
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents Cmd_AddDept As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Cmd_SaveDept As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_DelDept As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Cmd_Exit As System.Windows.Forms.ToolStripButton
    Friend WithEvents TextBox_DeptName As System.Windows.Forms.TextBox
    Friend WithEvents TextBox_DeptNo As System.Windows.Forms.TextBox
    Friend WithEvents TextBox_DeptSup As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents LB_ZaiZhi As System.Windows.Forms.Label
    Friend WithEvents LB_LiZhi As System.Windows.Forms.Label
    Friend WithEvents LB_LizhiCount As System.Windows.Forms.Label
    Friend WithEvents LB_ZaiZhiCount As System.Windows.Forms.Label
    Friend WithEvents Label_ECount As System.Windows.Forms.Label
    Friend WithEvents FG_User As PClass.FG
    Friend WithEvents Label_Mode As System.Windows.Forms.Label
    Friend WithEvents Cmd_AddEmployee As System.Windows.Forms.ToolStripButton
    Friend WithEvents TabEmployeeAndUser As System.Windows.Forms.TabControl
    Friend WithEvents TabUser As System.Windows.Forms.TabPage
    Friend WithEvents CB_IsProductive As System.Windows.Forms.CheckBox
    Friend WithEvents TabEmployee As System.Windows.Forms.TabPage
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents DTP_FirstDateTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents DTP_FirstDateFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents Cmd_Search As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_Print As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_Preview_Detail As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_Preview_Room As System.Windows.Forms.ToolStripButton
    Friend WithEvents CB_ConditionName As System.Windows.Forms.ComboBox
    Friend WithEvents CB_SearchByDept As System.Windows.Forms.CheckBox
    Friend WithEvents RB_All As System.Windows.Forms.RadioButton
    Friend WithEvents RB_LiZhi As System.Windows.Forms.RadioButton
    Friend WithEvents RB_ZaiZhi As System.Windows.Forms.RadioButton
    Friend WithEvents TB_EmployeeNo_Search As System.Windows.Forms.TextBox
    Friend WithEvents FG_Employee As PClass.FG
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents TB_AgeTo As System.Windows.Forms.TextBox
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents TB_AgeFrom As System.Windows.Forms.TextBox
    Friend WithEvents DP_FirstDateTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents DP_FirstDateFrom As System.Windows.Forms.DateTimePicker

End Class
