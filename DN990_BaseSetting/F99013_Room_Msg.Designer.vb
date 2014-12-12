<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F99013_Room_Msg
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
        Me.Cmd_Exit = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.PanelMain = New System.Windows.Forms.Panel
        Me.Cb_Room_Floor = New System.Windows.Forms.ComboBox
        Me.CB_Room_Buiding = New System.Windows.Forms.ComboBox
        Me.TB_Room_Note = New System.Windows.Forms.TextBox
        Me.TB_Name = New System.Windows.Forms.TextBox
        Me.TB_ID = New System.Windows.Forms.TextBox
        Me.Label_ID = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Tool_Top.SuspendLayout()
        Me.PanelMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'Tool_Top
        '
        Me.Tool_Top.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.Tool_Top.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Cmd_Modify, Me.Cmd_Del, Me.ToolStripSeparator2, Me.Cmd_Exit, Me.ToolStripSeparator5})
        Me.Tool_Top.Location = New System.Drawing.Point(0, 0)
        Me.Tool_Top.MinimumSize = New System.Drawing.Size(0, 50)
        Me.Tool_Top.Name = "Tool_Top"
        Me.Tool_Top.Size = New System.Drawing.Size(384, 50)
        Me.Tool_Top.TabIndex = 10
        Me.Tool_Top.Text = "ToolStrip2"
        '
        'Cmd_Modify
        '
        Me.Cmd_Modify.AccessibleDescription = "修改按钮"
        Me.Cmd_Modify.AccessibleName = ""
        Me.Cmd_Modify.Image = Global.DN990_BaseSetting.My.Resources.Resources.Modify
        Me.Cmd_Modify.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Modify.Name = "Cmd_Modify"
        Me.Cmd_Modify.Size = New System.Drawing.Size(33, 47)
        Me.Cmd_Modify.Text = "保存"
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
        'Cmd_Exit
        '
        Me.Cmd_Exit.Image = Global.DN990_BaseSetting.My.Resources.Resources.Close
        Me.Cmd_Exit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(33, 47)
        Me.Cmd_Exit.Text = "关闭"
        Me.Cmd_Exit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 50)
        '
        'PanelMain
        '
        Me.PanelMain.Controls.Add(Me.Cb_Room_Floor)
        Me.PanelMain.Controls.Add(Me.CB_Room_Buiding)
        Me.PanelMain.Controls.Add(Me.TB_Room_Note)
        Me.PanelMain.Controls.Add(Me.TB_Name)
        Me.PanelMain.Controls.Add(Me.TB_ID)
        Me.PanelMain.Controls.Add(Me.Label_ID)
        Me.PanelMain.Controls.Add(Me.Label2)
        Me.PanelMain.Controls.Add(Me.Label5)
        Me.PanelMain.Controls.Add(Me.Label1)
        Me.PanelMain.Controls.Add(Me.Label3)
        Me.PanelMain.Controls.Add(Me.Label4)
        Me.PanelMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelMain.Location = New System.Drawing.Point(0, 50)
        Me.PanelMain.Name = "PanelMain"
        Me.PanelMain.Padding = New System.Windows.Forms.Padding(2)
        Me.PanelMain.Size = New System.Drawing.Size(384, 255)
        Me.PanelMain.TabIndex = 12
        '
        'Cb_Room_Floor
        '
        Me.Cb_Room_Floor.FormattingEnabled = True
        Me.Cb_Room_Floor.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7"})
        Me.Cb_Room_Floor.Location = New System.Drawing.Point(236, 92)
        Me.Cb_Room_Floor.Name = "Cb_Room_Floor"
        Me.Cb_Room_Floor.Size = New System.Drawing.Size(78, 22)
        Me.Cb_Room_Floor.TabIndex = 14
        '
        'CB_Room_Buiding
        '
        Me.CB_Room_Buiding.FormattingEnabled = True
        Me.CB_Room_Buiding.Items.AddRange(New Object() {"1#"})
        Me.CB_Room_Buiding.Location = New System.Drawing.Point(131, 92)
        Me.CB_Room_Buiding.Name = "CB_Room_Buiding"
        Me.CB_Room_Buiding.Size = New System.Drawing.Size(78, 22)
        Me.CB_Room_Buiding.TabIndex = 14
        '
        'TB_Room_Note
        '
        Me.TB_Room_Note.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TB_Room_Note.Location = New System.Drawing.Point(131, 128)
        Me.TB_Room_Note.Multiline = True
        Me.TB_Room_Note.Name = "TB_Room_Note"
        Me.TB_Room_Note.Size = New System.Drawing.Size(210, 93)
        Me.TB_Room_Note.TabIndex = 11
        '
        'TB_Name
        '
        Me.TB_Name.Location = New System.Drawing.Point(131, 55)
        Me.TB_Name.Name = "TB_Name"
        Me.TB_Name.Size = New System.Drawing.Size(210, 23)
        Me.TB_Name.TabIndex = 10
        '
        'TB_ID
        '
        Me.TB_ID.Location = New System.Drawing.Point(131, 21)
        Me.TB_ID.Name = "TB_ID"
        Me.TB_ID.Size = New System.Drawing.Size(210, 23)
        Me.TB_ID.TabIndex = 13
        '
        'Label_ID
        '
        Me.Label_ID.AutoSize = True
        Me.Label_ID.Location = New System.Drawing.Point(41, 24)
        Me.Label_ID.Name = "Label_ID"
        Me.Label_ID.Size = New System.Drawing.Size(70, 14)
        Me.Label_ID.TabIndex = 7
        Me.Label_ID.Text = "宿舍编号:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(41, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 14)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "宿舍名称:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(320, 95)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(21, 14)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "层"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(209, 95)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(21, 14)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "楼"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(41, 95)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 14)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "所属楼层:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(41, 131)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 14)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "宿舍类型:"
        '
        'F99013_Room_Msg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.PanelMain)
        Me.Controls.Add(Me.Tool_Top)
        Me.Name = "F99013_Room_Msg"
        Me.Size = New System.Drawing.Size(384, 305)
        Me.Title = "职位详细信息"
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
    Friend WithEvents TB_Room_Note As System.Windows.Forms.TextBox
    Friend WithEvents TB_Name As System.Windows.Forms.TextBox
    Friend WithEvents TB_ID As System.Windows.Forms.TextBox
    Friend WithEvents Label_ID As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CB_Room_Buiding As System.Windows.Forms.ComboBox
    Friend WithEvents Cb_Room_Floor As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
