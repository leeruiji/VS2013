<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F15541_AT_ReleasePass_Msg
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F15541_AT_ReleasePass_Msg))
        Me.Tool_Top = New System.Windows.Forms.ToolStrip
        Me.Cmd_Modify = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.Cmd_Del = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.Cmd_Employee = New System.Windows.Forms.ToolStripButton
        Me.Cmd_Dellist = New System.Windows.Forms.ToolStripButton
        Me.Cmd_Exit = New System.Windows.Forms.ToolStripButton
        Me.PanelMain = New System.Windows.Forms.Panel
        Me.DTP_ReleaseDay = New System.Windows.Forms.DateTimePicker
        Me.Label6 = New System.Windows.Forms.Label
        Me.TB_Remark = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.DP_Start = New System.Windows.Forms.DateTimePicker
        Me.DP_End = New System.Windows.Forms.DateTimePicker
        Me.Label12 = New System.Windows.Forms.Label
        Me.LabelTitle = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.DTP_sDate = New System.Windows.Forms.DateTimePicker
        Me.Label16 = New System.Windows.Forms.Label
        Me.TB_ID = New System.Windows.Forms.TextBox
        Me.Label_ID = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.GB_List = New System.Windows.Forms.GroupBox
        Me.PanelFG = New System.Windows.Forms.Panel
        Me.Fg1 = New PClass.FG
        Me.CMS_Delect = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.TSM_De = New System.Windows.Forms.ToolStripMenuItem
        Me.Label2 = New System.Windows.Forms.Label
        Me.Tool_Top.SuspendLayout()
        Me.PanelMain.SuspendLayout()
        Me.GB_List.SuspendLayout()
        Me.PanelFG.SuspendLayout()
        CType(Me.Fg1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CMS_Delect.SuspendLayout()
        Me.SuspendLayout()
        '
        'Tool_Top
        '
        Me.Tool_Top.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.Tool_Top.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Cmd_Modify, Me.ToolStripSeparator4, Me.Cmd_Del, Me.ToolStripSeparator3, Me.Cmd_Employee, Me.Cmd_Dellist, Me.Cmd_Exit})
        Me.Tool_Top.Location = New System.Drawing.Point(0, 0)
        Me.Tool_Top.MinimumSize = New System.Drawing.Size(0, 40)
        Me.Tool_Top.Name = "Tool_Top"
        Me.Tool_Top.Size = New System.Drawing.Size(900, 40)
        Me.Tool_Top.TabIndex = 10
        Me.Tool_Top.Text = "ToolStrip2"
        '
        'Cmd_Modify
        '
        Me.Cmd_Modify.AccessibleDescription = "修改按钮"
        Me.Cmd_Modify.AccessibleName = ""
        Me.Cmd_Modify.Image = Global.DN155_AtMachine.My.Resources.Resources.Modify
        Me.Cmd_Modify.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Modify.Name = "Cmd_Modify"
        Me.Cmd_Modify.Size = New System.Drawing.Size(57, 37)
        Me.Cmd_Modify.Text = "保存"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 40)
        '
        'Cmd_Del
        '
        Me.Cmd_Del.AccessibleDescription = "修改按钮"
        Me.Cmd_Del.AccessibleName = ""
        Me.Cmd_Del.Image = Global.DN155_AtMachine.My.Resources.Resources.Delete
        Me.Cmd_Del.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Del.Name = "Cmd_Del"
        Me.Cmd_Del.Size = New System.Drawing.Size(57, 37)
        Me.Cmd_Del.Text = "删除"
        Me.Cmd_Del.Visible = False
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 40)
        '
        'Cmd_Employee
        '
        Me.Cmd_Employee.Image = Global.DN155_AtMachine.My.Resources.Resources._10300
        Me.Cmd_Employee.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Employee.Name = "Cmd_Employee"
        Me.Cmd_Employee.Size = New System.Drawing.Size(81, 37)
        Me.Cmd_Employee.Text = "员工选择"
        '
        'Cmd_Dellist
        '
        Me.Cmd_Dellist.Image = Global.DN155_AtMachine.My.Resources.Resources._79
        Me.Cmd_Dellist.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Dellist.Name = "Cmd_Dellist"
        Me.Cmd_Dellist.Size = New System.Drawing.Size(81, 37)
        Me.Cmd_Dellist.Text = "删除列表"
        '
        'Cmd_Exit
        '
        Me.Cmd_Exit.Image = Global.DN155_AtMachine.My.Resources.Resources.Close
        Me.Cmd_Exit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(57, 37)
        Me.Cmd_Exit.Text = "关闭"
        '
        'PanelMain
        '
        Me.PanelMain.Controls.Add(Me.DTP_ReleaseDay)
        Me.PanelMain.Controls.Add(Me.Label6)
        Me.PanelMain.Controls.Add(Me.TB_Remark)
        Me.PanelMain.Controls.Add(Me.Label5)
        Me.PanelMain.Controls.Add(Me.Label3)
        Me.PanelMain.Controls.Add(Me.DP_Start)
        Me.PanelMain.Controls.Add(Me.DP_End)
        Me.PanelMain.Controls.Add(Me.Label12)
        Me.PanelMain.Controls.Add(Me.LabelTitle)
        Me.PanelMain.Controls.Add(Me.Label4)
        Me.PanelMain.Controls.Add(Me.DTP_sDate)
        Me.PanelMain.Controls.Add(Me.Label16)
        Me.PanelMain.Controls.Add(Me.TB_ID)
        Me.PanelMain.Controls.Add(Me.Label_ID)
        Me.PanelMain.Controls.Add(Me.Label1)
        Me.PanelMain.Controls.Add(Me.GB_List)
        Me.PanelMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelMain.Location = New System.Drawing.Point(0, 40)
        Me.PanelMain.Name = "PanelMain"
        Me.PanelMain.Padding = New System.Windows.Forms.Padding(2)
        Me.PanelMain.Size = New System.Drawing.Size(900, 582)
        Me.PanelMain.TabIndex = 0
        '
        'DTP_ReleaseDay
        '
        Me.DTP_ReleaseDay.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DTP_ReleaseDay.CustomFormat = "yyyy年MM月dd日"
        Me.DTP_ReleaseDay.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTP_ReleaseDay.Location = New System.Drawing.Point(85, 58)
        Me.DTP_ReleaseDay.Name = "DTP_ReleaseDay"
        Me.DTP_ReleaseDay.Size = New System.Drawing.Size(124, 23)
        Me.DTP_ReleaseDay.TabIndex = 40
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(13, 62)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(70, 14)
        Me.Label6.TabIndex = 39
        Me.Label6.Text = "放行日期:"
        '
        'TB_Remark
        '
        Me.TB_Remark.Location = New System.Drawing.Point(585, 59)
        Me.TB_Remark.Name = "TB_Remark"
        Me.TB_Remark.Size = New System.Drawing.Size(302, 23)
        Me.TB_Remark.TabIndex = 38
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(537, 64)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(42, 14)
        Me.Label5.TabIndex = 37
        Me.Label5.Text = "备注:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(353, 62)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(14, 14)
        Me.Label3.TabIndex = 36
        Me.Label3.Text = "-"
        '
        'DP_Start
        '
        Me.DP_Start.CustomFormat = "HH:mm"
        Me.DP_Start.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DP_Start.Location = New System.Drawing.Point(287, 57)
        Me.DP_Start.Name = "DP_Start"
        Me.DP_Start.ShowUpDown = True
        Me.DP_Start.Size = New System.Drawing.Size(61, 23)
        Me.DP_Start.TabIndex = 35
        '
        'DP_End
        '
        Me.DP_End.CustomFormat = "HH:mm"
        Me.DP_End.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DP_End.Location = New System.Drawing.Point(443, 58)
        Me.DP_End.Name = "DP_End"
        Me.DP_End.ShowUpDown = True
        Me.DP_End.Size = New System.Drawing.Size(59, 23)
        Me.DP_End.TabIndex = 34
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(213, 62)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(70, 14)
        Me.Label12.TabIndex = 21
        Me.Label12.Text = "起始时间:"
        '
        'LabelTitle
        '
        Me.LabelTitle.AutoSize = True
        Me.LabelTitle.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LabelTitle.ForeColor = System.Drawing.Color.Blue
        Me.LabelTitle.Location = New System.Drawing.Point(13, 14)
        Me.LabelTitle.Name = "LabelTitle"
        Me.LabelTitle.Size = New System.Drawing.Size(59, 16)
        Me.LabelTitle.TabIndex = 22
        Me.LabelTitle.Text = "放行条"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(370, 62)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 14)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "结束时间:"
        '
        'DTP_sDate
        '
        Me.DTP_sDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DTP_sDate.CustomFormat = "yyyy年MM月dd日"
        Me.DTP_sDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTP_sDate.Location = New System.Drawing.Point(585, 11)
        Me.DTP_sDate.Name = "DTP_sDate"
        Me.DTP_sDate.Size = New System.Drawing.Size(124, 23)
        Me.DTP_sDate.TabIndex = 7
        '
        'Label16
        '
        Me.Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(537, 16)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(42, 14)
        Me.Label16.TabIndex = 14
        Me.Label16.Text = "日期:"
        '
        'TB_ID
        '
        Me.TB_ID.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TB_ID.Location = New System.Drawing.Point(763, 11)
        Me.TB_ID.Name = "TB_ID"
        Me.TB_ID.Size = New System.Drawing.Size(121, 23)
        Me.TB_ID.TabIndex = 0
        Me.TB_ID.Text = "系统自动生成单号"
        '
        'Label_ID
        '
        Me.Label_ID.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label_ID.AutoSize = True
        Me.Label_ID.ForeColor = System.Drawing.Color.Blue
        Me.Label_ID.Location = New System.Drawing.Point(715, 16)
        Me.Label_ID.Name = "Label_ID"
        Me.Label_ID.Size = New System.Drawing.Size(42, 14)
        Me.Label_ID.TabIndex = 14
        Me.Label_ID.Text = "单号:"
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.BackColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(-4, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(902, 3)
        Me.Label1.TabIndex = 11
        '
        'GB_List
        '
        Me.GB_List.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GB_List.Controls.Add(Me.PanelFG)
        Me.GB_List.Controls.Add(Me.Label2)
        Me.GB_List.Location = New System.Drawing.Point(5, 88)
        Me.GB_List.Name = "GB_List"
        Me.GB_List.Size = New System.Drawing.Size(888, 481)
        Me.GB_List.TabIndex = 5
        Me.GB_List.TabStop = False
        '
        'PanelFG
        '
        Me.PanelFG.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelFG.Controls.Add(Me.Fg1)
        Me.PanelFG.Location = New System.Drawing.Point(6, 22)
        Me.PanelFG.Name = "PanelFG"
        Me.PanelFG.Padding = New System.Windows.Forms.Padding(1)
        Me.PanelFG.Size = New System.Drawing.Size(876, 446)
        Me.PanelFG.TabIndex = 15
        '
        'Fg1
        '
        Me.Fg1.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.Rows
        Me.Fg1.AllowEditing = False
        Me.Fg1.AutoAddIndex = True
        Me.Fg1.AutoGenerateColumns = False
        Me.Fg1.AutoResize = False
        Me.Fg1.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.Fg1.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.XpThemes
        Me.Fg1.CanEditing = True
        Me.Fg1.ColumnInfo = resources.GetString("Fg1.ColumnInfo")
        Me.Fg1.ContextMenuStrip = Me.CMS_Delect
        Me.Fg1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Fg1.DragMode = C1.Win.C1FlexGrid.DragModeEnum.Automatic
        Me.Fg1.EditFormat = True
        Me.Fg1.ExtendLastCol = True
        Me.Fg1.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Fg1.ForeColor = System.Drawing.Color.Black
        Me.Fg1.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.Fg1.IsAutoAddRow = True
        Me.Fg1.IsClickStartEdit = True
        Me.Fg1.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.Fg1.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.Fg1.Location = New System.Drawing.Point(1, 1)
        Me.Fg1.Name = "Fg1"
        Me.Fg1.Rows.Count = 10
        Me.Fg1.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.RowRange
        Me.Fg1.Size = New System.Drawing.Size(874, 444)
        Me.Fg1.StartCol = ""
        Me.Fg1.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("Fg1.Styles"))
        Me.Fg1.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.BelowData
        Me.Fg1.TabIndex = 0
        '
        'CMS_Delect
        '
        Me.CMS_Delect.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSM_De})
        Me.CMS_Delect.Name = "CMS_Delect"
        Me.CMS_Delect.Size = New System.Drawing.Size(131, 26)
        '
        'TSM_De
        '
        Me.TSM_De.Name = "TSM_De"
        Me.TSM_De.Size = New System.Drawing.Size(130, 22)
        Me.TSM_De.Text = "删除选中项"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(204, 247)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(0, 14)
        Me.Label2.TabIndex = 9
        '
        'F15541_AT_ReleasePass_Msg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CanMaxSize = True
        Me.Controls.Add(Me.PanelMain)
        Me.Controls.Add(Me.Tool_Top)
        Me.ForeColor = System.Drawing.Color.Black
        Me.Name = "F15541_AT_ReleasePass_Msg"
        Me.Size = New System.Drawing.Size(900, 622)
        Me.Title = "采购单"
        Me.Tool_Top.ResumeLayout(False)
        Me.Tool_Top.PerformLayout()
        Me.PanelMain.ResumeLayout(False)
        Me.PanelMain.PerformLayout()
        Me.GB_List.ResumeLayout(False)
        Me.GB_List.PerformLayout()
        Me.PanelFG.ResumeLayout(False)
        CType(Me.Fg1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CMS_Delect.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Tool_Top As System.Windows.Forms.ToolStrip
    Friend WithEvents Cmd_Modify As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_Del As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_Exit As System.Windows.Forms.ToolStripButton
    Friend WithEvents PanelMain As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TB_ID As System.Windows.Forms.TextBox
    Friend WithEvents Label_ID As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents DTP_sDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents LabelTitle As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents GB_List As System.Windows.Forms.GroupBox
    Friend WithEvents PanelFG As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Fg1 As PClass.FG
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DP_Start As System.Windows.Forms.DateTimePicker
    Friend WithEvents DP_End As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TB_Remark As System.Windows.Forms.TextBox
    Friend WithEvents Cmd_Employee As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_Dellist As System.Windows.Forms.ToolStripButton
    Friend WithEvents DTP_ReleaseDay As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents CMS_Delect As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents TSM_De As System.Windows.Forms.ToolStripMenuItem

End Class
