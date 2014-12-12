<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DeptTree
    Inherits System.Windows.Forms.UserControl

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DeptTree))
        Me.GroupBox_Dept = New System.Windows.Forms.GroupBox
        Me.TreeView_Dept = New System.Windows.Forms.TreeView
        Me.ImageList_Node = New System.Windows.Forms.ImageList(Me.components)
        Me.GroupBox_Dept.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox_Dept
        '
        Me.GroupBox_Dept.Controls.Add(Me.TreeView_Dept)
        Me.GroupBox_Dept.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox_Dept.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox_Dept.Name = "GroupBox_Dept"
        Me.GroupBox_Dept.Size = New System.Drawing.Size(290, 597)
        Me.GroupBox_Dept.TabIndex = 2
        Me.GroupBox_Dept.TabStop = False
        Me.GroupBox_Dept.Text = "部门列表"
        '
        'TreeView_Dept
        '
        Me.TreeView_Dept.AllowDrop = True
        Me.TreeView_Dept.BackColor = System.Drawing.Color.White
        Me.TreeView_Dept.CheckBoxes = True
        Me.TreeView_Dept.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeView_Dept.HideSelection = False
        Me.TreeView_Dept.ImageIndex = 0
        Me.TreeView_Dept.ImageList = Me.ImageList_Node
        Me.TreeView_Dept.Location = New System.Drawing.Point(3, 17)
        Me.TreeView_Dept.Name = "TreeView_Dept"
        Me.TreeView_Dept.SelectedImageIndex = 1
        Me.TreeView_Dept.Size = New System.Drawing.Size(284, 577)
        Me.TreeView_Dept.TabIndex = 0
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
        'DeptTree
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GroupBox_Dept)
        Me.Name = "DeptTree"
        Me.Size = New System.Drawing.Size(290, 597)
        Me.GroupBox_Dept.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox_Dept As System.Windows.Forms.GroupBox
    Friend WithEvents TreeView_Dept As System.Windows.Forms.TreeView
    Friend WithEvents ImageList_Node As System.Windows.Forms.ImageList

End Class
