<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GoodsTypeTree
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
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("商品分类")
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GoodsTypeTree))
        Me.TV_GoodsType = New System.Windows.Forms.TreeView
        Me.CMS_GoodsType = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.TSMI_ADD = New System.Windows.Forms.ToolStripMenuItem
        Me.TSMI_Save = New System.Windows.Forms.ToolStripMenuItem
        Me.TSMI_Del = New System.Windows.Forms.ToolStripMenuItem
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.CMS_GoodsType.SuspendLayout()
        Me.SuspendLayout()
        '
        'TV_GoodsType
        '
        Me.TV_GoodsType.ContextMenuStrip = Me.CMS_GoodsType
        Me.TV_GoodsType.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TV_GoodsType.ImageIndex = 0
        Me.TV_GoodsType.ImageList = Me.ImageList1
        Me.TV_GoodsType.Location = New System.Drawing.Point(0, 0)
        Me.TV_GoodsType.Name = "TV_GoodsType"
        TreeNode1.Name = "GT"
        TreeNode1.Text = "商品分类"
        Me.TV_GoodsType.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode1})
        Me.TV_GoodsType.SelectedImageIndex = 1
        Me.TV_GoodsType.Size = New System.Drawing.Size(322, 613)
        Me.TV_GoodsType.TabIndex = 0
        '
        'CMS_GoodsType
        '
        Me.CMS_GoodsType.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSMI_ADD, Me.TSMI_Save, Me.TSMI_Del})
        Me.CMS_GoodsType.Name = "CMS_GoodsType"
        Me.CMS_GoodsType.Size = New System.Drawing.Size(119, 70)
        Me.CMS_GoodsType.Text = "新增分类"
        '
        'TSMI_ADD
        '
        Me.TSMI_ADD.Name = "TSMI_ADD"
        Me.TSMI_ADD.Size = New System.Drawing.Size(118, 22)
        Me.TSMI_ADD.Text = "新增分类"
        '
        'TSMI_Save
        '
        Me.TSMI_Save.Name = "TSMI_Save"
        Me.TSMI_Save.Size = New System.Drawing.Size(118, 22)
        Me.TSMI_Save.Text = "修改分类"
        '
        'TSMI_Del
        '
        Me.TSMI_Del.Name = "TSMI_Del"
        Me.TSMI_Del.Size = New System.Drawing.Size(118, 22)
        Me.TSMI_Del.Text = "删除分类"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "Node.png")
        Me.ImageList1.Images.SetKeyName(1, "NodeSelected.png")
        '
        'GoodsTypeTree
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TV_GoodsType)
        Me.Name = "GoodsTypeTree"
        Me.Size = New System.Drawing.Size(322, 613)
        Me.CMS_GoodsType.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TV_GoodsType As System.Windows.Forms.TreeView
    Friend WithEvents CMS_GoodsType As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents TSMI_ADD As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSMI_Save As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSMI_Del As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList

End Class
