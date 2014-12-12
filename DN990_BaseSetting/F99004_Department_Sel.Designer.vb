<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F99004_Department_Sel
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F99004_Department_Sel))
        Me.Tool_Top = New System.Windows.Forms.ToolStrip
        Me.Cmd_Add = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.Cmd_Modify = New System.Windows.Forms.ToolStripButton
        Me.Cmd_Del = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.Cmd_Reflesh = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.Cmd_Exit = New System.Windows.Forms.ToolStripButton
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.GroupBox_Dept = New System.Windows.Forms.GroupBox
        Me.TreeView_Dept = New System.Windows.Forms.TreeView
        Me.Menu_TreeView = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.TSMI_AddDept = New System.Windows.Forms.ToolStripMenuItem
        Me.TSMI_Del = New System.Windows.Forms.ToolStripMenuItem
        Me.ImageList_Node = New System.Windows.Forms.ImageList(Me.components)
        Me.Label_Mode = New System.Windows.Forms.Label
        Me.TextBox_ENumPrefix = New System.Windows.Forms.TextBox
        Me.TextBox_DeptName = New System.Windows.Forms.TextBox
        Me.TextBox_DeptNo = New System.Windows.Forms.TextBox
        Me.TextBox_DeptSup = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.CB_IsProductive = New System.Windows.Forms.CheckBox
        Me.Tool_Top.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GroupBox_Dept.SuspendLayout()
        Me.Menu_TreeView.SuspendLayout()
        Me.SuspendLayout()
        '
        'Tool_Top
        '
        Me.Tool_Top.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.Tool_Top.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Cmd_Add, Me.ToolStripSeparator3, Me.Cmd_Modify, Me.Cmd_Del, Me.ToolStripSeparator2, Me.Cmd_Reflesh, Me.ToolStripSeparator1, Me.Cmd_Exit})
        Me.Tool_Top.Location = New System.Drawing.Point(0, 0)
        Me.Tool_Top.MinimumSize = New System.Drawing.Size(0, 50)
        Me.Tool_Top.Name = "Tool_Top"
        Me.Tool_Top.Size = New System.Drawing.Size(600, 50)
        Me.Tool_Top.TabIndex = 10
        Me.Tool_Top.Text = "ToolStrip2"
        '
        'Cmd_Add
        '
        Me.Cmd_Add.AccessibleDescription = "添加按钮"
        Me.Cmd_Add.AccessibleName = ""
        Me.Cmd_Add.Image = Global.DN990_BaseSetting.My.Resources.Resources.ADD
        Me.Cmd_Add.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Add.Name = "Cmd_Add"
        Me.Cmd_Add.Size = New System.Drawing.Size(33, 47)
        Me.Cmd_Add.Text = "添加"
        Me.Cmd_Add.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 50)
        '
        'Cmd_Modify
        '
        Me.Cmd_Modify.AccessibleDescription = "修改按钮"
        Me.Cmd_Modify.AccessibleName = ""
        Me.Cmd_Modify.Image = Global.DN990_BaseSetting.My.Resources.Resources.Modify
        Me.Cmd_Modify.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Modify.Name = "Cmd_Modify"
        Me.Cmd_Modify.Size = New System.Drawing.Size(33, 47)
        Me.Cmd_Modify.Text = "修改"
        Me.Cmd_Modify.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'Cmd_Del
        '
        Me.Cmd_Del.AccessibleDescription = "修改按钮"
        Me.Cmd_Del.AccessibleName = ""
        Me.Cmd_Del.Image = Global.DN990_BaseSetting.My.Resources.Resources.Delete
        Me.Cmd_Del.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Del.Name = "Cmd_Del"
        Me.Cmd_Del.Size = New System.Drawing.Size(33, 47)
        Me.Cmd_Del.Text = "删除"
        Me.Cmd_Del.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 50)
        '
        'Cmd_Reflesh
        '
        Me.Cmd_Reflesh.Image = Global.DN990_BaseSetting.My.Resources.Resources.ReFresh
        Me.Cmd_Reflesh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Reflesh.Name = "Cmd_Reflesh"
        Me.Cmd_Reflesh.Size = New System.Drawing.Size(33, 47)
        Me.Cmd_Reflesh.Text = "刷新"
        Me.Cmd_Reflesh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 50)
        '
        'Cmd_Exit
        '
        Me.Cmd_Exit.Image = Global.DN990_BaseSetting.My.Resources.Resources.Close
        Me.Cmd_Exit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(33, 47)
        Me.Cmd_Exit.Text = "关闭"
        Me.Cmd_Exit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 50)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox_Dept)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.CB_IsProductive)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label_Mode)
        Me.SplitContainer1.Panel2.Controls.Add(Me.TextBox_ENumPrefix)
        Me.SplitContainer1.Panel2.Controls.Add(Me.TextBox_DeptName)
        Me.SplitContainer1.Panel2.Controls.Add(Me.TextBox_DeptNo)
        Me.SplitContainer1.Panel2.Controls.Add(Me.TextBox_DeptSup)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label3)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label4)
        Me.SplitContainer1.Size = New System.Drawing.Size(600, 450)
        Me.SplitContainer1.SplitterDistance = 251
        Me.SplitContainer1.TabIndex = 13
        '
        'GroupBox_Dept
        '
        Me.GroupBox_Dept.Controls.Add(Me.TreeView_Dept)
        Me.GroupBox_Dept.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox_Dept.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox_Dept.Name = "GroupBox_Dept"
        Me.GroupBox_Dept.Size = New System.Drawing.Size(251, 450)
        Me.GroupBox_Dept.TabIndex = 1
        Me.GroupBox_Dept.TabStop = False
        Me.GroupBox_Dept.Text = "部门列表"
        '
        'TreeView_Dept
        '
        Me.TreeView_Dept.AllowDrop = True
        Me.TreeView_Dept.ContextMenuStrip = Me.Menu_TreeView
        Me.TreeView_Dept.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeView_Dept.HideSelection = False
        Me.TreeView_Dept.ImageIndex = 0
        Me.TreeView_Dept.ImageList = Me.ImageList_Node
        Me.TreeView_Dept.Location = New System.Drawing.Point(3, 19)
        Me.TreeView_Dept.Name = "TreeView_Dept"
        Me.TreeView_Dept.SelectedImageIndex = 1
        Me.TreeView_Dept.Size = New System.Drawing.Size(245, 428)
        Me.TreeView_Dept.TabIndex = 0
        '
        'Menu_TreeView
        '
        Me.Menu_TreeView.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSMI_AddDept, Me.TSMI_Del})
        Me.Menu_TreeView.Name = "Menu_TreeView"
        Me.Menu_TreeView.Size = New System.Drawing.Size(119, 48)
        '
        'TSMI_AddDept
        '
        Me.TSMI_AddDept.Name = "TSMI_AddDept"
        Me.TSMI_AddDept.Size = New System.Drawing.Size(118, 22)
        Me.TSMI_AddDept.Text = "添加部门"
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
        'Label_Mode
        '
        Me.Label_Mode.AutoSize = True
        Me.Label_Mode.Location = New System.Drawing.Point(58, 257)
        Me.Label_Mode.Name = "Label_Mode"
        Me.Label_Mode.Size = New System.Drawing.Size(0, 14)
        Me.Label_Mode.TabIndex = 16
        Me.Label_Mode.Visible = False
        '
        'TextBox_ENumPrefix
        '
        Me.TextBox_ENumPrefix.Location = New System.Drawing.Point(167, 150)
        Me.TextBox_ENumPrefix.Name = "TextBox_ENumPrefix"
        Me.TextBox_ENumPrefix.Size = New System.Drawing.Size(151, 23)
        Me.TextBox_ENumPrefix.TabIndex = 12
        '
        'TextBox_DeptName
        '
        Me.TextBox_DeptName.Location = New System.Drawing.Point(167, 80)
        Me.TextBox_DeptName.Name = "TextBox_DeptName"
        Me.TextBox_DeptName.Size = New System.Drawing.Size(151, 23)
        Me.TextBox_DeptName.TabIndex = 13
        '
        'TextBox_DeptNo
        '
        Me.TextBox_DeptNo.Location = New System.Drawing.Point(167, 46)
        Me.TextBox_DeptNo.Name = "TextBox_DeptNo"
        Me.TextBox_DeptNo.ReadOnly = True
        Me.TextBox_DeptNo.Size = New System.Drawing.Size(151, 23)
        Me.TextBox_DeptNo.TabIndex = 14
        '
        'TextBox_DeptSup
        '
        Me.TextBox_DeptSup.Location = New System.Drawing.Point(167, 117)
        Me.TextBox_DeptSup.Name = "TextBox_DeptSup"
        Me.TextBox_DeptSup.Size = New System.Drawing.Size(151, 23)
        Me.TextBox_DeptSup.TabIndex = 11
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(77, 54)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 14)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "部门编号:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(77, 89)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 14)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "部门名称:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(77, 126)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 14)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "部门负责人:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(77, 159)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 14)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "工号前缀:"
        '
        'CB_IsProductive
        '
        Me.CB_IsProductive.AutoSize = True
        Me.CB_IsProductive.Location = New System.Drawing.Point(80, 193)
        Me.CB_IsProductive.Name = "CB_IsProductive"
        Me.CB_IsProductive.Size = New System.Drawing.Size(110, 18)
        Me.CB_IsProductive.TabIndex = 17
        Me.CB_IsProductive.Text = "是否生成部门"
        Me.CB_IsProductive.UseVisualStyleBackColor = True
        '
        'F99004_Department_Sel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.Tool_Top)
        Me.Name = "F99004_Department_Sel"
        Me.Size = New System.Drawing.Size(600, 500)
        Me.Title = "部门选择"
        Me.Tool_Top.ResumeLayout(False)
        Me.Tool_Top.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        Me.SplitContainer1.ResumeLayout(False)
        Me.GroupBox_Dept.ResumeLayout(False)
        Me.Menu_TreeView.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Tool_Top As System.Windows.Forms.ToolStrip
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents TreeView_Dept As System.Windows.Forms.TreeView
    Friend WithEvents GroupBox_Dept As System.Windows.Forms.GroupBox
    Friend WithEvents Cmd_Reflesh As System.Windows.Forms.ToolStripButton
    Friend WithEvents Menu_TreeView As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents TSMI_AddDept As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label_Mode As System.Windows.Forms.Label
    Friend WithEvents TextBox_ENumPrefix As System.Windows.Forms.TextBox
    Friend WithEvents TextBox_DeptName As System.Windows.Forms.TextBox
    Friend WithEvents TextBox_DeptNo As System.Windows.Forms.TextBox
    Friend WithEvents TextBox_DeptSup As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Cmd_Exit As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSMI_Del As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Cmd_Modify As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Cmd_Del As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Cmd_Add As System.Windows.Forms.ToolStripButton
    Friend WithEvents ImageList_Node As System.Windows.Forms.ImageList
    Friend WithEvents CB_IsProductive As System.Windows.Forms.CheckBox

End Class
