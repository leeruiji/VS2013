<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F15517_Real_Shift
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F15517_Real_Shift))
        Me.Tool_Top = New System.Windows.Forms.ToolStrip
        Me.Cmd_Add = New System.Windows.Forms.ToolStripButton
        Me.Cmd_Modify = New System.Windows.Forms.ToolStripButton
        Me.Cmd_Del = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.Btn_Refresh = New System.Windows.Forms.ToolStripButton
        Me.Cmd_Exit = New System.Windows.Forms.ToolStripButton
        Me.FG1 = New PClass.FG
        Me.PanelMain = New System.Windows.Forms.Panel
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.Fg2 = New PClass.FG
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.Cmd_AddMonth = New System.Windows.Forms.ToolStripButton
        Me.Cmd_ModifyMonth = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.MP_Start = New BaseClass.ToolStripMonthPicker(Me.components)
        Me.MP_End = New BaseClass.ToolStripMonthPicker(Me.components)
        Me.Btn_Search = New System.Windows.Forms.ToolStripButton
        Me.PanelAdd = New System.Windows.Forms.Panel
        Me.GroupAdd = New System.Windows.Forms.GroupBox
        Me.Cmd_Cancel = New System.Windows.Forms.Button
        Me.Cmd_OK = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.TB_Remark = New System.Windows.Forms.TextBox
        Me.CB_Shift_Moudel = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.TB_Moduel_Name = New System.Windows.Forms.TextBox
        Me.BW = New System.ComponentModel.BackgroundWorker
        Me.Tool_Top.SuspendLayout()
        CType(Me.FG1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelMain.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.Fg2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.PanelAdd.SuspendLayout()
        Me.GroupAdd.SuspendLayout()
        Me.SuspendLayout()
        '
        'Tool_Top
        '
        Me.Tool_Top.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.Tool_Top.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Cmd_Add, Me.Cmd_Modify, Me.Cmd_Del, Me.ToolStripSeparator2, Me.Btn_Refresh, Me.Cmd_Exit})
        Me.Tool_Top.Location = New System.Drawing.Point(2, 2)
        Me.Tool_Top.MinimumSize = New System.Drawing.Size(0, 43)
        Me.Tool_Top.Name = "Tool_Top"
        Me.Tool_Top.Size = New System.Drawing.Size(923, 43)
        Me.Tool_Top.TabIndex = 10
        Me.Tool_Top.Text = "ToolStrip2"
        '
        'Cmd_Add
        '
        Me.Cmd_Add.AccessibleDescription = "新增"
        Me.Cmd_Add.AccessibleName = ""
        Me.Cmd_Add.Image = Global.DN155_AtMachine.My.Resources.Resources.ADD
        Me.Cmd_Add.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Add.Name = "Cmd_Add"
        Me.Cmd_Add.Size = New System.Drawing.Size(57, 40)
        Me.Cmd_Add.Text = "新增"
        '
        'Cmd_Modify
        '
        Me.Cmd_Modify.AccessibleDescription = "修改按钮"
        Me.Cmd_Modify.AccessibleName = ""
        Me.Cmd_Modify.Image = Global.DN155_AtMachine.My.Resources.Resources.Modify
        Me.Cmd_Modify.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Modify.Name = "Cmd_Modify"
        Me.Cmd_Modify.Size = New System.Drawing.Size(57, 40)
        Me.Cmd_Modify.Text = "修改"
        '
        'Cmd_Del
        '
        Me.Cmd_Del.AccessibleDescription = "修改按钮"
        Me.Cmd_Del.AccessibleName = ""
        Me.Cmd_Del.Image = Global.DN155_AtMachine.My.Resources.Resources.Delete
        Me.Cmd_Del.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Del.Name = "Cmd_Del"
        Me.Cmd_Del.Size = New System.Drawing.Size(57, 40)
        Me.Cmd_Del.Text = "删除"
        Me.Cmd_Del.Visible = False
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 43)
        '
        'Btn_Refresh
        '
        Me.Btn_Refresh.Image = CType(resources.GetObject("Btn_Refresh.Image"), System.Drawing.Image)
        Me.Btn_Refresh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Btn_Refresh.Name = "Btn_Refresh"
        Me.Btn_Refresh.Size = New System.Drawing.Size(57, 40)
        Me.Btn_Refresh.Text = "刷新"
        '
        'Cmd_Exit
        '
        Me.Cmd_Exit.Image = Global.DN155_AtMachine.My.Resources.Resources.Close
        Me.Cmd_Exit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(57, 40)
        Me.Cmd_Exit.Text = "关闭"
        '
        'FG1
        '
        Me.FG1.AutoAddIndex = True
        Me.FG1.AutoGenerateColumns = False
        Me.FG1.AutoResize = False
        Me.FG1.BackColor = System.Drawing.Color.White
        Me.FG1.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.XpThemes
        Me.FG1.CanEditing = True
        Me.FG1.ColumnInfo = resources.GetString("FG1.ColumnInfo")
        Me.FG1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FG1.EditFormat = True
        Me.FG1.ExtendLastCol = True
        Me.FG1.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.FG1.ForeColor = System.Drawing.Color.Black
        Me.FG1.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.FG1.IsAutoAddRow = True
        Me.FG1.IsClickStartEdit = False
        Me.FG1.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.FG1.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.FG1.Location = New System.Drawing.Point(0, 0)
        Me.FG1.Name = "FG1"
        Me.FG1.Rows.Count = 10
        Me.FG1.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.FG1.Size = New System.Drawing.Size(497, 653)
        Me.FG1.StartCol = ""
        Me.FG1.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("FG1.Styles"))
        Me.FG1.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.BelowData
        Me.FG1.TabIndex = 11
        '
        'PanelMain
        '
        Me.PanelMain.Controls.Add(Me.SplitContainer1)
        Me.PanelMain.Controls.Add(Me.Tool_Top)
        Me.PanelMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelMain.Location = New System.Drawing.Point(0, 0)
        Me.PanelMain.Name = "PanelMain"
        Me.PanelMain.Padding = New System.Windows.Forms.Padding(2)
        Me.PanelMain.Size = New System.Drawing.Size(927, 700)
        Me.PanelMain.TabIndex = 12
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(2, 45)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.FG1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.Fg2)
        Me.SplitContainer1.Panel2.Controls.Add(Me.ToolStrip1)
        Me.SplitContainer1.Size = New System.Drawing.Size(923, 653)
        Me.SplitContainer1.SplitterDistance = 497
        Me.SplitContainer1.TabIndex = 12
        '
        'Fg2
        '
        Me.Fg2.AutoAddIndex = True
        Me.Fg2.AutoGenerateColumns = False
        Me.Fg2.AutoResize = False
        Me.Fg2.BackColor = System.Drawing.Color.White
        Me.Fg2.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.XpThemes
        Me.Fg2.CanEditing = False
        Me.Fg2.ColumnInfo = resources.GetString("Fg2.ColumnInfo")
        Me.Fg2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Fg2.EditFormat = True
        Me.Fg2.ExtendLastCol = True
        Me.Fg2.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Fg2.ForeColor = System.Drawing.Color.Black
        Me.Fg2.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.Fg2.IsAutoAddRow = True
        Me.Fg2.IsClickStartEdit = False
        Me.Fg2.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.Fg2.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.Fg2.Location = New System.Drawing.Point(0, 30)
        Me.Fg2.Name = "Fg2"
        Me.Fg2.Rows.Count = 10
        Me.Fg2.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.Fg2.Size = New System.Drawing.Size(422, 623)
        Me.Fg2.StartCol = ""
        Me.Fg2.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("Fg2.Styles"))
        Me.Fg2.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.BelowData
        Me.Fg2.TabIndex = 12
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator4, Me.Cmd_AddMonth, Me.Cmd_ModifyMonth, Me.ToolStripSeparator1, Me.MP_Start, Me.MP_End, Me.Btn_Search})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.MinimumSize = New System.Drawing.Size(0, 30)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(422, 30)
        Me.ToolStrip1.TabIndex = 13
        Me.ToolStrip1.Text = "ToolStrip2"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 30)
        '
        'Cmd_AddMonth
        '
        Me.Cmd_AddMonth.AccessibleDescription = "排班"
        Me.Cmd_AddMonth.AccessibleName = ""
        Me.Cmd_AddMonth.Image = Global.DN155_AtMachine.My.Resources.Resources.ADD
        Me.Cmd_AddMonth.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_AddMonth.Name = "Cmd_AddMonth"
        Me.Cmd_AddMonth.Size = New System.Drawing.Size(57, 27)
        Me.Cmd_AddMonth.Text = "排班"
        '
        'Cmd_ModifyMonth
        '
        Me.Cmd_ModifyMonth.AccessibleDescription = "修改按钮"
        Me.Cmd_ModifyMonth.AccessibleName = ""
        Me.Cmd_ModifyMonth.Image = Global.DN155_AtMachine.My.Resources.Resources.Modify
        Me.Cmd_ModifyMonth.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_ModifyMonth.Name = "Cmd_ModifyMonth"
        Me.Cmd_ModifyMonth.Size = New System.Drawing.Size(57, 27)
        Me.Cmd_ModifyMonth.Text = "修改"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 30)
        '
        'MP_Start
        '
        Me.MP_Start.AutoSize = False
        Me.MP_Start.BackColor = System.Drawing.Color.Transparent
        Me.MP_Start.Format = "yyyy年MM月"
        Me.MP_Start.IsReadOnly = "False"
        Me.MP_Start.IsShowTitle = True
        Me.MP_Start.Name = "MP_Start"
        Me.MP_Start.ShowDirection = BaseClass.MonthPicker.Enum_ShowDirection.Below
        Me.MP_Start.ShowDistince = 1
        Me.MP_Start.Size = New System.Drawing.Size(92, 20)
        Me.MP_Start.Text = "2012年07月"
        Me.MP_Start.Title = "从"
        Me.MP_Start.TopMost = False
        Me.MP_Start.Value = New Date(2012, 7, 1, 0, 0, 0, 0)
        '
        'MP_End
        '
        Me.MP_End.AutoSize = False
        Me.MP_End.BackColor = System.Drawing.Color.Transparent
        Me.MP_End.Format = "yyyy年MM月"
        Me.MP_End.IsReadOnly = "False"
        Me.MP_End.IsShowTitle = True
        Me.MP_End.Name = "MP_End"
        Me.MP_End.ShowDirection = BaseClass.MonthPicker.Enum_ShowDirection.Below
        Me.MP_End.ShowDistince = 1
        Me.MP_End.Size = New System.Drawing.Size(92, 20)
        Me.MP_End.Text = "2012年07月"
        Me.MP_End.Title = "到"
        Me.MP_End.TopMost = False
        Me.MP_End.Value = New Date(2012, 7, 1, 0, 0, 0, 0)
        '
        'Btn_Search
        '
        Me.Btn_Search.Image = Global.DN155_AtMachine.My.Resources.Resources.Search
        Me.Btn_Search.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.Btn_Search.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Btn_Search.Name = "Btn_Search"
        Me.Btn_Search.Size = New System.Drawing.Size(65, 27)
        Me.Btn_Search.Text = "搜索"
        '
        'PanelAdd
        '
        Me.PanelAdd.Controls.Add(Me.GroupAdd)
        Me.PanelAdd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelAdd.Location = New System.Drawing.Point(0, 0)
        Me.PanelAdd.Name = "PanelAdd"
        Me.PanelAdd.Size = New System.Drawing.Size(927, 700)
        Me.PanelAdd.TabIndex = 0
        Me.PanelAdd.Visible = False
        '
        'GroupAdd
        '
        Me.GroupAdd.Controls.Add(Me.Cmd_Cancel)
        Me.GroupAdd.Controls.Add(Me.Cmd_OK)
        Me.GroupAdd.Controls.Add(Me.Label3)
        Me.GroupAdd.Controls.Add(Me.TB_Remark)
        Me.GroupAdd.Controls.Add(Me.CB_Shift_Moudel)
        Me.GroupAdd.Controls.Add(Me.Label2)
        Me.GroupAdd.Controls.Add(Me.Label1)
        Me.GroupAdd.Controls.Add(Me.TB_Moduel_Name)
        Me.GroupAdd.Location = New System.Drawing.Point(237, 196)
        Me.GroupAdd.Name = "GroupAdd"
        Me.GroupAdd.Size = New System.Drawing.Size(342, 239)
        Me.GroupAdd.TabIndex = 0
        Me.GroupAdd.TabStop = False
        Me.GroupAdd.Text = "添加实际班次"
        '
        'Cmd_Cancel
        '
        Me.Cmd_Cancel.Location = New System.Drawing.Point(228, 188)
        Me.Cmd_Cancel.Name = "Cmd_Cancel"
        Me.Cmd_Cancel.Size = New System.Drawing.Size(79, 32)
        Me.Cmd_Cancel.TabIndex = 4
        Me.Cmd_Cancel.Text = "取消"
        Me.Cmd_Cancel.UseVisualStyleBackColor = True
        '
        'Cmd_OK
        '
        Me.Cmd_OK.Location = New System.Drawing.Point(134, 188)
        Me.Cmd_OK.Name = "Cmd_OK"
        Me.Cmd_OK.Size = New System.Drawing.Size(79, 32)
        Me.Cmd_OK.TabIndex = 3
        Me.Cmd_OK.Text = "保存"
        Me.Cmd_OK.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(88, 136)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 14)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "备注:"
        '
        'TB_Remark
        '
        Me.TB_Remark.Location = New System.Drawing.Point(143, 133)
        Me.TB_Remark.Name = "TB_Remark"
        Me.TB_Remark.Size = New System.Drawing.Size(146, 23)
        Me.TB_Remark.TabIndex = 2
        '
        'CB_Shift_Moudel
        '
        Me.CB_Shift_Moudel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_Shift_Moudel.FormattingEnabled = True
        Me.CB_Shift_Moudel.Location = New System.Drawing.Point(143, 92)
        Me.CB_Shift_Moudel.Name = "CB_Shift_Moudel"
        Me.CB_Shift_Moudel.Size = New System.Drawing.Size(146, 22)
        Me.CB_Shift_Moudel.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(39, 95)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 14)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "继承班次模板"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(39, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(98, 14)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "实际班次名称:"
        '
        'TB_Moduel_Name
        '
        Me.TB_Moduel_Name.Location = New System.Drawing.Point(143, 49)
        Me.TB_Moduel_Name.Name = "TB_Moduel_Name"
        Me.TB_Moduel_Name.Size = New System.Drawing.Size(146, 23)
        Me.TB_Moduel_Name.TabIndex = 0
        '
        'BW
        '
        Me.BW.WorkerReportsProgress = True
        '
        'F15517_Real_Shift
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.PanelMain)
        Me.Controls.Add(Me.PanelAdd)
        Me.Name = "F15517_Real_Shift"
        Me.Tool_Top.ResumeLayout(False)
        Me.Tool_Top.PerformLayout()
        CType(Me.FG1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelMain.ResumeLayout(False)
        Me.PanelMain.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.Fg2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.PanelAdd.ResumeLayout(False)
        Me.GroupAdd.ResumeLayout(False)
        Me.GroupAdd.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Tool_Top As System.Windows.Forms.ToolStrip
    Friend WithEvents Cmd_Add As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_Modify As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_Del As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Cmd_Exit As System.Windows.Forms.ToolStripButton
    Friend WithEvents FG1 As PClass.FG
    Friend WithEvents PanelMain As System.Windows.Forms.Panel
    Friend WithEvents Btn_Refresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents PanelAdd As System.Windows.Forms.Panel
    Friend WithEvents BW As System.ComponentModel.BackgroundWorker
    Friend WithEvents GroupAdd As System.Windows.Forms.GroupBox
    Friend WithEvents CB_Shift_Moudel As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TB_Moduel_Name As System.Windows.Forms.TextBox
    Friend WithEvents Cmd_Cancel As System.Windows.Forms.Button
    Friend WithEvents Cmd_OK As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TB_Remark As System.Windows.Forms.TextBox
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Fg2 As PClass.FG
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MP_Start As BaseClass.ToolStripMonthPicker
    Friend WithEvents MP_End As BaseClass.ToolStripMonthPicker
    Friend WithEvents Btn_Search As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_AddMonth As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_ModifyMonth As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator

End Class
