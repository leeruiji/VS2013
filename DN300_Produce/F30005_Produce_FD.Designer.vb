<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F30005_Produce_FD
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
        Me.Cmd_FD = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.Cmd_Exit = New System.Windows.Forms.ToolStripButton
        Me.PanelMain = New System.Windows.Forms.Panel
        Me.TB_Color = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Employee_List1 = New BaseClass.Employee_List
        Me.Label1 = New System.Windows.Forms.Label
        Me.CB_Client = New BaseClass.ComBoList
        Me.CB_BZ = New BaseClass.ComBoList
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.TB_BZName = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.TB_ClientName = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.LabelMsg = New System.Windows.Forms.Label
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.Pic_From = New System.Windows.Forms.Panel
        Me.Tool_Top.SuspendLayout()
        Me.PanelMain.SuspendLayout()
        Me.Pic_From.SuspendLayout()
        Me.SuspendLayout()
        '
        'Tool_Top
        '
        Me.Tool_Top.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.Tool_Top.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Cmd_FD, Me.ToolStripSeparator2, Me.Cmd_Exit})
        Me.Tool_Top.Location = New System.Drawing.Point(0, 0)
        Me.Tool_Top.MinimumSize = New System.Drawing.Size(0, 40)
        Me.Tool_Top.Name = "Tool_Top"
        Me.Tool_Top.Size = New System.Drawing.Size(506, 40)
        Me.Tool_Top.TabIndex = 10
        Me.Tool_Top.Text = "ToolStrip2"
        '
        'Cmd_FD
        '
        Me.Cmd_FD.AccessibleDescription = "修改按钮"
        Me.Cmd_FD.AccessibleName = ""
        Me.Cmd_FD.Image = Global.DN300_Produce.My.Resources.Resources.Modify
        Me.Cmd_FD.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_FD.Name = "Cmd_FD"
        Me.Cmd_FD.Size = New System.Drawing.Size(57, 37)
        Me.Cmd_FD.Text = "开单"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 40)
        '
        'Cmd_Exit
        '
        Me.Cmd_Exit.Image = Global.DN300_Produce.My.Resources.Resources.Close
        Me.Cmd_Exit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(57, 37)
        Me.Cmd_Exit.Text = "关闭"
        '
        'PanelMain
        '
        Me.PanelMain.Controls.Add(Me.Employee_List1)
        Me.PanelMain.Controls.Add(Me.TB_Color)
        Me.PanelMain.Controls.Add(Me.Label2)
        Me.PanelMain.Controls.Add(Me.Label1)
        Me.PanelMain.Controls.Add(Me.CB_Client)
        Me.PanelMain.Controls.Add(Me.CB_BZ)
        Me.PanelMain.Controls.Add(Me.Label17)
        Me.PanelMain.Controls.Add(Me.Label12)
        Me.PanelMain.Controls.Add(Me.TB_BZName)
        Me.PanelMain.Controls.Add(Me.Label11)
        Me.PanelMain.Controls.Add(Me.TB_ClientName)
        Me.PanelMain.Controls.Add(Me.Label4)
        Me.PanelMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelMain.Location = New System.Drawing.Point(0, 40)
        Me.PanelMain.Name = "PanelMain"
        Me.PanelMain.Padding = New System.Windows.Forms.Padding(2)
        Me.PanelMain.Size = New System.Drawing.Size(506, 195)
        Me.PanelMain.TabIndex = 0
        '
        'TB_Color
        '
        Me.TB_Color.Location = New System.Drawing.Point(105, 100)
        Me.TB_Color.Name = "TB_Color"
        Me.TB_Color.Size = New System.Drawing.Size(113, 23)
        Me.TB_Color.TabIndex = 78
        Me.TB_Color.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(57, 103)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 14)
        Me.Label2.TabIndex = 79
        Me.Label2.Text = "颜色:"
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("宋体", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(213, 132)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 31)
        Me.Label1.TabIndex = 77
        Me.Label1.Text = "返定"
        '
        'CB_Client
        '
        Me.CB_Client.Child = "ComboClient"
        Me.CB_Client.FormattingEnabled = True
        Me.CB_Client.IDAsInt = 0
        Me.CB_Client.IDValue = ""
        Me.CB_Client.IsKeyDownAutoSearch = True
        Me.CB_Client.IsSelectName = False
        Me.CB_Client.IsTBLostFocusSelOne = True
        Me.CB_Client.Location = New System.Drawing.Point(105, 23)
        Me.CB_Client.Name = "CB_Client"
        Me.CB_Client.SearchType = BaseClass.cSearchType.ENum_SearchType.ALL
        Me.CB_Client.Size = New System.Drawing.Size(113, 22)
        Me.CB_Client.TabIndex = 69
        '
        'CB_BZ
        '
        Me.CB_BZ.Child = "ComboBZ"
        Me.CB_BZ.Enabled = False
        Me.CB_BZ.FormattingEnabled = True
        Me.CB_BZ.IDAsInt = 0
        Me.CB_BZ.IDValue = ""
        Me.CB_BZ.IsKeyDownAutoSearch = True
        Me.CB_BZ.IsSelectName = False
        Me.CB_BZ.Location = New System.Drawing.Point(105, 61)
        Me.CB_BZ.Name = "CB_BZ"
        Me.CB_BZ.SearchType = BaseClass.cSearchType.ENum_SearchType.ALL
        Me.CB_BZ.Size = New System.Drawing.Size(113, 22)
        Me.CB_BZ.TabIndex = 71
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(31, 65)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(70, 14)
        Me.Label17.TabIndex = 76
        Me.Label17.Text = "布类编号:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(31, 27)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(70, 14)
        Me.Label12.TabIndex = 75
        Me.Label12.Text = "客户编号:"
        '
        'TB_BZName
        '
        Me.TB_BZName.Location = New System.Drawing.Point(316, 61)
        Me.TB_BZName.Name = "TB_BZName"
        Me.TB_BZName.ReadOnly = True
        Me.TB_BZName.Size = New System.Drawing.Size(149, 23)
        Me.TB_BZName.TabIndex = 72
        Me.TB_BZName.TabStop = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(247, 65)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(70, 14)
        Me.Label11.TabIndex = 73
        Me.Label11.Text = "布类名称:"
        '
        'TB_ClientName
        '
        Me.TB_ClientName.Location = New System.Drawing.Point(316, 23)
        Me.TB_ClientName.Name = "TB_ClientName"
        Me.TB_ClientName.ReadOnly = True
        Me.TB_ClientName.Size = New System.Drawing.Size(149, 23)
        Me.TB_ClientName.TabIndex = 70
        Me.TB_ClientName.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(247, 26)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 14)
        Me.Label4.TabIndex = 74
        Me.Label4.Text = "客户名称:"
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
        Me.Pic_From.Size = New System.Drawing.Size(506, 235)
        Me.Pic_From.TabIndex = 11
        '
        'F30005_Produce_FD
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.PanelMain)
        Me.Controls.Add(Me.Tool_Top)
        Me.Controls.Add(Me.Pic_From)
        Me.Name = "F30005_Produce_FD"
        Me.Size = New System.Drawing.Size(506, 235)
        Me.Title = "新加返定布"
        Me.Tool_Top.ResumeLayout(False)
        Me.Tool_Top.PerformLayout()
        Me.PanelMain.ResumeLayout(False)
        Me.PanelMain.PerformLayout()
        Me.Pic_From.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Tool_Top As System.Windows.Forms.ToolStrip
    Friend WithEvents Cmd_FD As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Cmd_Exit As System.Windows.Forms.ToolStripButton
    Friend WithEvents PanelMain As System.Windows.Forms.Panel
    Friend WithEvents LabelMsg As System.Windows.Forms.Label
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents Pic_From As System.Windows.Forms.Panel
    Friend WithEvents Employee_List1 As BaseClass.Employee_List
    Friend WithEvents CB_Client As BaseClass.ComBoList
    Friend WithEvents CB_BZ As BaseClass.ComBoList
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TB_BZName As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TB_ClientName As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TB_Color As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label

End Class
