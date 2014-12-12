<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F15605_PBB_Mx
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F15605_PBB_Mx))
        Me.PanelMain = New System.Windows.Forms.Panel
        Me.GR = New AxgrproLib.AxGRDisplayViewer
        Me.Tool_Search = New System.Windows.Forms.ToolStrip
        Me.MonthPicker1 = New BaseClass.ToolStripMonthPicker(Me.components)
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator
        Me.Cmd_ChooseDept = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel
        Me.DropDown_Leven = New System.Windows.Forms.ToolStripDropDownButton
        Me.Cmd_LevenAll = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.Cmd_Leven1 = New System.Windows.Forms.ToolStripMenuItem
        Me.Cmd_Leven2 = New System.Windows.Forms.ToolStripMenuItem
        Me.Cmd_Leven3 = New System.Windows.Forms.ToolStripMenuItem
        Me.Cmd_Leven1to3 = New System.Windows.Forms.ToolStripMenuItem
        Me.Cmd_Leven4to6 = New System.Windows.Forms.ToolStripMenuItem
        Me.Cmd_Leven4 = New System.Windows.Forms.ToolStripMenuItem
        Me.Cmd_Leven5 = New System.Windows.Forms.ToolStripMenuItem
        Me.Cmd_Leven6 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel
        Me.CB_Employee = New BaseClass.ToolStripComboList
        Me.Btn_Search = New System.Windows.Forms.ToolStripButton
        Me.Cmd_Preview = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.Cmd_Exit = New System.Windows.Forms.ToolStripButton
        Me.PanelMain.SuspendLayout()
        CType(Me.GR, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tool_Search.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelMain
        '
        Me.PanelMain.Controls.Add(Me.GR)
        Me.PanelMain.Controls.Add(Me.Tool_Search)
        Me.PanelMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelMain.Location = New System.Drawing.Point(0, 0)
        Me.PanelMain.Name = "PanelMain"
        Me.PanelMain.Padding = New System.Windows.Forms.Padding(2)
        Me.PanelMain.Size = New System.Drawing.Size(1000, 618)
        Me.PanelMain.TabIndex = 0
        '
        'GR
        '
        Me.GR.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GR.Enabled = True
        Me.GR.Location = New System.Drawing.Point(2, 34)
        Me.GR.Name = "GR"
        Me.GR.OcxState = CType(resources.GetObject("GR.OcxState"), System.Windows.Forms.AxHost.State)
        Me.GR.Size = New System.Drawing.Size(996, 582)
        Me.GR.TabIndex = 17
        '
        'Tool_Search
        '
        Me.Tool_Search.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.Tool_Search.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MonthPicker1, Me.ToolStripSeparator6, Me.Cmd_ChooseDept, Me.ToolStripSeparator1, Me.ToolStripLabel2, Me.DropDown_Leven, Me.ToolStripSeparator5, Me.ToolStripLabel1, Me.CB_Employee, Me.Btn_Search, Me.Cmd_Preview, Me.ToolStripSeparator3, Me.Cmd_Exit})
        Me.Tool_Search.Location = New System.Drawing.Point(2, 2)
        Me.Tool_Search.MinimumSize = New System.Drawing.Size(0, 32)
        Me.Tool_Search.Name = "Tool_Search"
        Me.Tool_Search.Size = New System.Drawing.Size(996, 32)
        Me.Tool_Search.TabIndex = 14
        Me.Tool_Search.Text = "ToolStrip1"
        '
        'MonthPicker1
        '
        Me.MonthPicker1.AutoSize = False
        Me.MonthPicker1.BackColor = System.Drawing.Color.Transparent
        Me.MonthPicker1.Format = "yyyy年MM月"
        Me.MonthPicker1.IsReadOnly = "False"
        Me.MonthPicker1.IsShowTitle = True
        Me.MonthPicker1.Name = "MonthPicker1"
        Me.MonthPicker1.ShowDirection = BaseClass.MonthPicker.Enum_ShowDirection.Below
        Me.MonthPicker1.ShowDistince = 1
        Me.MonthPicker1.Size = New System.Drawing.Size(110, 22)
        Me.MonthPicker1.Text = "2012年07月"
        Me.MonthPicker1.Title = "月份:"
        Me.MonthPicker1.TopMost = False
        Me.MonthPicker1.Value = New Date(2012, 7, 1, 0, 0, 0, 0)
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 32)
        '
        'Cmd_ChooseDept
        '
        Me.Cmd_ChooseDept.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.Cmd_ChooseDept.Image = CType(resources.GetObject("Cmd_ChooseDept.Image"), System.Drawing.Image)
        Me.Cmd_ChooseDept.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_ChooseDept.Margin = New System.Windows.Forms.Padding(0, 1, 5, 2)
        Me.Cmd_ChooseDept.Name = "Cmd_ChooseDept"
        Me.Cmd_ChooseDept.Size = New System.Drawing.Size(57, 29)
        Me.Cmd_ChooseDept.Text = "选择部门"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 32)
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(59, 29)
        Me.ToolStripLabel2.Text = "职位等级:"
        '
        'DropDown_Leven
        '
        Me.DropDown_Leven.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Cmd_LevenAll, Me.ToolStripSeparator4, Me.Cmd_Leven1, Me.Cmd_Leven2, Me.Cmd_Leven3, Me.Cmd_Leven1to3, Me.Cmd_Leven4to6, Me.Cmd_Leven4, Me.Cmd_Leven5, Me.Cmd_Leven6})
        Me.DropDown_Leven.ForeColor = System.Drawing.Color.Blue
        Me.DropDown_Leven.Name = "DropDown_Leven"
        Me.DropDown_Leven.Size = New System.Drawing.Size(66, 29)
        Me.DropDown_Leven.Text = "全部等级"
        '
        'Cmd_LevenAll
        '
        Me.Cmd_LevenAll.Name = "Cmd_LevenAll"
        Me.Cmd_LevenAll.Size = New System.Drawing.Size(166, 22)
        Me.Cmd_LevenAll.Text = "全部等级"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(163, 6)
        '
        'Cmd_Leven1
        '
        Me.Cmd_Leven1.Name = "Cmd_Leven1"
        Me.Cmd_Leven1.Size = New System.Drawing.Size(166, 22)
        Me.Cmd_Leven1.Tag = "=1 "
        Me.Cmd_Leven1.Text = "1级"
        '
        'Cmd_Leven2
        '
        Me.Cmd_Leven2.Name = "Cmd_Leven2"
        Me.Cmd_Leven2.Size = New System.Drawing.Size(166, 22)
        Me.Cmd_Leven2.Tag = "=2"
        Me.Cmd_Leven2.Text = "2级"
        '
        'Cmd_Leven3
        '
        Me.Cmd_Leven3.Name = "Cmd_Leven3"
        Me.Cmd_Leven3.Size = New System.Drawing.Size(166, 22)
        Me.Cmd_Leven3.Tag = "=3"
        Me.Cmd_Leven3.Text = "3级"
        '
        'Cmd_Leven1to3
        '
        Me.Cmd_Leven1to3.Name = "Cmd_Leven1to3"
        Me.Cmd_Leven1to3.Size = New System.Drawing.Size(166, 22)
        Me.Cmd_Leven1to3.Tag = "<=3"
        Me.Cmd_Leven1to3.Text = "3级以下(包括3级)"
        '
        'Cmd_Leven4to6
        '
        Me.Cmd_Leven4to6.Name = "Cmd_Leven4to6"
        Me.Cmd_Leven4to6.Size = New System.Drawing.Size(166, 22)
        Me.Cmd_Leven4to6.Tag = ">3"
        Me.Cmd_Leven4to6.Text = "3级以上"
        '
        'Cmd_Leven4
        '
        Me.Cmd_Leven4.Name = "Cmd_Leven4"
        Me.Cmd_Leven4.Size = New System.Drawing.Size(166, 22)
        Me.Cmd_Leven4.Tag = "=4"
        Me.Cmd_Leven4.Text = "4级"
        '
        'Cmd_Leven5
        '
        Me.Cmd_Leven5.Name = "Cmd_Leven5"
        Me.Cmd_Leven5.Size = New System.Drawing.Size(166, 22)
        Me.Cmd_Leven5.Tag = "=5"
        Me.Cmd_Leven5.Text = "5级"
        '
        'Cmd_Leven6
        '
        Me.Cmd_Leven6.Name = "Cmd_Leven6"
        Me.Cmd_Leven6.Size = New System.Drawing.Size(166, 22)
        Me.Cmd_Leven6.Tag = "=6"
        Me.Cmd_Leven6.Text = "6级"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 32)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(35, 29)
        Me.ToolStripLabel1.Text = "姓名:"
        '
        'CB_Employee
        '
        Me.CB_Employee.Child = "ComboEmployee"
        Me.CB_Employee.IDAsInt = 0
        Me.CB_Employee.IDValue = "0"
        Me.CB_Employee.IsKeyDownAutoSearch = True
        Me.CB_Employee.Name = "CB_Employee"
        Me.CB_Employee.SearchType = BaseClass.cSearchType.ENum_SearchType.ALL
        Me.CB_Employee.Size = New System.Drawing.Size(100, 29)
        '
        'Btn_Search
        '
        Me.Btn_Search.Image = CType(resources.GetObject("Btn_Search.Image"), System.Drawing.Image)
        Me.Btn_Search.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.Btn_Search.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Btn_Search.Name = "Btn_Search"
        Me.Btn_Search.Size = New System.Drawing.Size(65, 29)
        Me.Btn_Search.Text = "搜索"
        '
        'Cmd_Preview
        '
        Me.Cmd_Preview.Image = Global.DN155_AtMachine.My.Resources.Resources.Print_preview
        Me.Cmd_Preview.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Preview.Name = "Cmd_Preview"
        Me.Cmd_Preview.Size = New System.Drawing.Size(57, 29)
        Me.Cmd_Preview.Text = "预览"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 32)
        '
        'Cmd_Exit
        '
        Me.Cmd_Exit.Image = Global.DN155_AtMachine.My.Resources.Resources.Close
        Me.Cmd_Exit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(57, 29)
        Me.Cmd_Exit.Text = "关闭"
        '
        'F15605_PBB_Mx
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CanMaxSize = True
        Me.Controls.Add(Me.PanelMain)
        Me.ForeColor = System.Drawing.Color.Black
        Me.Name = "F15605_PBB_Mx"
        Me.Size = New System.Drawing.Size(1000, 618)
        Me.PanelMain.ResumeLayout(False)
        Me.PanelMain.PerformLayout()
        CType(Me.GR, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tool_Search.ResumeLayout(False)
        Me.Tool_Search.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelMain As System.Windows.Forms.Panel
    Friend WithEvents Tool_Search As System.Windows.Forms.ToolStrip
    Friend WithEvents Btn_Search As System.Windows.Forms.ToolStripButton
    Friend WithEvents GR As AxgrproLib.AxGRDisplayViewer
    Friend WithEvents Cmd_ChooseDept As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_Preview As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_Exit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents DropDown_Leven As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents Cmd_LevenAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Cmd_Leven1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Cmd_Leven2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Cmd_Leven3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Cmd_Leven1to3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Cmd_Leven4to6 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Cmd_Leven4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Cmd_Leven5 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Cmd_Leven6 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MonthPicker1 As BaseClass.ToolStripMonthPicker
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CB_Employee As BaseClass.ToolStripComboList

End Class
