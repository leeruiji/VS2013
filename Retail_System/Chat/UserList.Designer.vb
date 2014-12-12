<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserList
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UserList))
        Me.TreeView_Dept = New System.Windows.Forms.TreeView
        Me.ImageList_Node = New System.Windows.Forms.ImageList(Me.components)
        Me.TimerFlash = New System.Windows.Forms.Timer(Me.components)
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.PicHead = New System.Windows.Forms.PictureBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.LabelUserName = New System.Windows.Forms.Label
        Me.PanelHead = New System.Windows.Forms.Panel
        Me.TimerShow = New System.Windows.Forms.Timer(Me.components)
        Me.TimerHide = New System.Windows.Forms.Timer(Me.components)
        Me.TimerActivate = New System.Windows.Forms.Timer(Me.components)
        CType(Me.PicHead, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelHead.SuspendLayout()
        Me.SuspendLayout()
        '
        'TreeView_Dept
        '
        Me.TreeView_Dept.BackColor = System.Drawing.Color.White
        Me.TreeView_Dept.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeView_Dept.Font = New System.Drawing.Font("宋体", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TreeView_Dept.ImageKey = "Node"
        Me.TreeView_Dept.ImageList = Me.ImageList_Node
        Me.TreeView_Dept.Indent = 29
        Me.TreeView_Dept.ItemHeight = 26
        Me.TreeView_Dept.Location = New System.Drawing.Point(0, 69)
        Me.TreeView_Dept.Name = "TreeView_Dept"
        Me.TreeView_Dept.SelectedImageKey = "NodeSelected"
        Me.TreeView_Dept.Size = New System.Drawing.Size(270, 554)
        Me.TreeView_Dept.TabIndex = 1
        '
        'ImageList_Node
        '
        Me.ImageList_Node.ImageStream = CType(resources.GetObject("ImageList_Node.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList_Node.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList_Node.Images.SetKeyName(0, "Node")
        Me.ImageList_Node.Images.SetKeyName(1, "NodeSelected")
        Me.ImageList_Node.Images.SetKeyName(2, "Transparent")
        Me.ImageList_Node.Images.SetKeyName(3, "User")
        '
        'TimerFlash
        '
        Me.TimerFlash.Enabled = True
        Me.TimerFlash.Interval = 240
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.Text = "NotifyIcon1"
        Me.NotifyIcon1.Visible = True
        '
        'PicHead
        '
        Me.PicHead.BackColor = System.Drawing.Color.Transparent
        Me.PicHead.Image = Global.Retail_System.My.Resources.Resources.PicHead
        Me.PicHead.Location = New System.Drawing.Point(11, 11)
        Me.PicHead.Name = "PicHead"
        Me.PicHead.Size = New System.Drawing.Size(48, 48)
        Me.PicHead.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PicHead.TabIndex = 2
        Me.PicHead.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(69, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 12)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "姓名:"
        '
        'LabelUserName
        '
        Me.LabelUserName.AutoSize = True
        Me.LabelUserName.ForeColor = System.Drawing.Color.Blue
        Me.LabelUserName.Location = New System.Drawing.Point(110, 12)
        Me.LabelUserName.Name = "LabelUserName"
        Me.LabelUserName.Size = New System.Drawing.Size(35, 12)
        Me.LabelUserName.TabIndex = 6
        Me.LabelUserName.Text = "姓名:"
        '
        'PanelHead
        '
        Me.PanelHead.BackColor = System.Drawing.Color.Transparent
        Me.PanelHead.BackgroundImage = CType(resources.GetObject("PanelHead.BackgroundImage"), System.Drawing.Image)
        Me.PanelHead.Controls.Add(Me.LabelUserName)
        Me.PanelHead.Controls.Add(Me.Label2)
        Me.PanelHead.Controls.Add(Me.PicHead)
        Me.PanelHead.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelHead.Location = New System.Drawing.Point(0, 0)
        Me.PanelHead.Name = "PanelHead"
        Me.PanelHead.Size = New System.Drawing.Size(270, 69)
        Me.PanelHead.TabIndex = 7
        '
        'TimerShow
        '
        '
        'TimerHide
        '
        Me.TimerHide.Interval = 1000
        '
        'TimerActivate
        '
        Me.TimerActivate.Interval = 500
        '
        'UserList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(178, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(270, 623)
        Me.Controls.Add(Me.TreeView_Dept)
        Me.Controls.Add(Me.PanelHead)
        Me.DoubleBuffered = True
        Me.Location = New System.Drawing.Point(100, -652)
        Me.MaximizeBox = False
        Me.Name = "UserList"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "员工账号列表"
        Me.TopMost = True
        CType(Me.PicHead, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelHead.ResumeLayout(False)
        Me.PanelHead.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TreeView_Dept As System.Windows.Forms.TreeView
    Friend WithEvents ImageList_Node As System.Windows.Forms.ImageList
    Friend WithEvents TimerFlash As System.Windows.Forms.Timer
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents PicHead As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LabelUserName As System.Windows.Forms.Label
    Friend WithEvents PanelHead As System.Windows.Forms.Panel
    Friend WithEvents TimerShow As System.Windows.Forms.Timer
    Friend WithEvents TimerHide As System.Windows.Forms.Timer
    Friend WithEvents TimerActivate As System.Windows.Forms.Timer
End Class
