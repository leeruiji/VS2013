<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F30300_AT_EmployessSel
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F30300_AT_EmployessSel))
        Me.Tool_Top = New System.Windows.Forms.ToolStrip
        Me.Cmd_SendAll = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.Cmd_Modify = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel
        Me.CB_shift = New System.Windows.Forms.ToolStripComboBox
        Me.Cmd_Exit = New System.Windows.Forms.ToolStripButton
        Me.TV_Left = New System.Windows.Forms.TreeView
        Me.Menu_TreeView = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.TSMI_AddDept = New System.Windows.Forms.ToolStripMenuItem
        Me.TSMI_Del = New System.Windows.Forms.ToolStripMenuItem
        Me.ImageList_Node = New System.Windows.Forms.ImageList(Me.components)
        Me.TV_Right = New System.Windows.Forms.TreeView
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.Tool_Top.SuspendLayout()
        Me.Menu_TreeView.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Tool_Top
        '
        Me.Tool_Top.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.Tool_Top.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Cmd_SendAll, Me.ToolStripSeparator3, Me.Cmd_Modify, Me.ToolStripSeparator2, Me.ToolStripLabel1, Me.CB_shift, Me.Cmd_Exit})
        Me.Tool_Top.Location = New System.Drawing.Point(0, 0)
        Me.Tool_Top.MinimumSize = New System.Drawing.Size(0, 35)
        Me.Tool_Top.Name = "Tool_Top"
        Me.Tool_Top.Size = New System.Drawing.Size(703, 35)
        Me.Tool_Top.TabIndex = 10
        Me.Tool_Top.Text = "ToolStrip2"
        '
        'Cmd_SendAll
        '
        Me.Cmd_SendAll.AccessibleDescription = "发送全部"
        Me.Cmd_SendAll.AccessibleName = ""
        Me.Cmd_SendAll.Image = Global.DN300_Produce.My.Resources.Resources.ADD
        Me.Cmd_SendAll.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_SendAll.Name = "Cmd_SendAll"
        Me.Cmd_SendAll.Size = New System.Drawing.Size(81, 32)
        Me.Cmd_SendAll.Text = "发送全部"
        Me.Cmd_SendAll.Visible = False
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 35)
        '
        'Cmd_Modify
        '
        Me.Cmd_Modify.AccessibleDescription = "修改按钮"
        Me.Cmd_Modify.AccessibleName = ""
        Me.Cmd_Modify.Image = Global.DN300_Produce.My.Resources.Resources.Modify
        Me.Cmd_Modify.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Modify.Name = "Cmd_Modify"
        Me.Cmd_Modify.Size = New System.Drawing.Size(57, 32)
        Me.Cmd_Modify.Text = "选择"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 35)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(41, 32)
        Me.ToolStripLabel1.Text = "班次："
        '
        'CB_shift
        '
        Me.CB_shift.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_shift.Name = "CB_shift"
        Me.CB_shift.Size = New System.Drawing.Size(121, 35)
        '
        'Cmd_Exit
        '
        Me.Cmd_Exit.Image = Global.DN300_Produce.My.Resources.Resources.Close
        Me.Cmd_Exit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(57, 32)
        Me.Cmd_Exit.Text = "关闭"
        '
        'TV_Left
        '
        Me.TV_Left.AllowDrop = True
        Me.TV_Left.ContextMenuStrip = Me.Menu_TreeView
        Me.TV_Left.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TV_Left.HideSelection = False
        Me.TV_Left.ImageIndex = 0
        Me.TV_Left.ImageList = Me.ImageList_Node
        Me.TV_Left.Location = New System.Drawing.Point(0, 0)
        Me.TV_Left.Name = "TV_Left"
        Me.TV_Left.SelectedImageIndex = 1
        Me.TV_Left.Size = New System.Drawing.Size(345, 659)
        Me.TV_Left.TabIndex = 0
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
        'TV_Right
        '
        Me.TV_Right.AllowDrop = True
        Me.TV_Right.ContextMenuStrip = Me.Menu_TreeView
        Me.TV_Right.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TV_Right.HideSelection = False
        Me.TV_Right.ImageIndex = 0
        Me.TV_Right.ImageList = Me.ImageList_Node
        Me.TV_Right.Location = New System.Drawing.Point(0, 0)
        Me.TV_Right.Name = "TV_Right"
        Me.TV_Right.SelectedImageIndex = 1
        Me.TV_Right.Size = New System.Drawing.Size(354, 659)
        Me.TV_Right.TabIndex = 11
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 35)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.TV_Left)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.TV_Right)
        Me.SplitContainer1.Size = New System.Drawing.Size(703, 659)
        Me.SplitContainer1.SplitterDistance = 345
        Me.SplitContainer1.TabIndex = 12
        '
        'F30300_AT_EmployessSel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.Tool_Top)
        Me.Name = "F30300_AT_EmployessSel"
        Me.Size = New System.Drawing.Size(703, 694)
        Me.Title = "部门选择"
        Me.Tool_Top.ResumeLayout(False)
        Me.Tool_Top.PerformLayout()
        Me.Menu_TreeView.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Tool_Top As System.Windows.Forms.ToolStrip
    Friend WithEvents TV_Left As System.Windows.Forms.TreeView
    Friend WithEvents Menu_TreeView As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents TSMI_AddDept As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Cmd_Exit As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSMI_Del As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Cmd_Modify As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Cmd_SendAll As System.Windows.Forms.ToolStripButton
    Friend WithEvents ImageList_Node As System.Windows.Forms.ImageList
    Friend WithEvents TV_Right As System.Windows.Forms.TreeView
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents CB_shift As System.Windows.Forms.ToolStripComboBox

End Class
