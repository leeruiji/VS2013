<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F15531_AT_Leave_Msg
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F15531_AT_Leave_Msg))
        Me.Tool_Top = New System.Windows.Forms.ToolStrip
        Me.Cmd_Save = New System.Windows.Forms.ToolStripButton
        Me.Cmd_Del = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.Btn_Inser = New System.Windows.Forms.ToolStripButton
        Me.Btn_Modify = New System.Windows.Forms.ToolStripButton
        Me.Cmd_Exit = New System.Windows.Forms.ToolStripButton
        Me.PanelMain = New System.Windows.Forms.Panel
        Me.Employee_List1 = New BaseClass.Employee_List
        Me.Tool_Search = New System.Windows.Forms.ToolStrip
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel
        Me.DP_Start = New PClass.ToolStripDateTimePicker
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel
        Me.DP_End = New PClass.ToolStripDateTimePicker
        Me.Cmd_ChooseDept = New System.Windows.Forms.ToolStripButton
        Me.ToolStripLabel4 = New System.Windows.Forms.ToolStripLabel
        Me.CB_Employee = New BaseClass.ToolStripComboList
        Me.Btn_Search = New System.Windows.Forms.ToolStripButton
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.PL_day = New System.Windows.Forms.Panel
        Me.DTP_Start = New System.Windows.Forms.DateTimePicker
        Me.DTP_End = New System.Windows.Forms.DateTimePicker
        Me.PL_time = New System.Windows.Forms.Panel
        Me.DTP_Day = New System.Windows.Forms.DateTimePicker
        Me.Label6 = New System.Windows.Forms.Label
        Me.DTP_Start_time = New System.Windows.Forms.DateTimePicker
        Me.DTP_End_Time = New System.Windows.Forms.DateTimePicker
        Me.CB_QC = New System.Windows.Forms.CheckBox
        Me.TB_Le_Cause = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.TB_Le_User = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.TB_Employee_Name = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TB_Employee_No = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.RB_Time = New System.Windows.Forms.RadioButton
        Me.RB_Day = New System.Windows.Forms.RadioButton
        Me.Fg1 = New PClass.FG
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.LabelMsg = New System.Windows.Forms.Label
        Me.Pic_From = New System.Windows.Forms.Panel
        Me.Tool_Top.SuspendLayout()
        Me.PanelMain.SuspendLayout()
        Me.Tool_Search.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.PL_day.SuspendLayout()
        Me.PL_time.SuspendLayout()
        CType(Me.Fg1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pic_From.SuspendLayout()
        Me.SuspendLayout()
        '
        'Tool_Top
        '
        Me.Tool_Top.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.Tool_Top.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Cmd_Save, Me.Cmd_Del, Me.ToolStripSeparator2, Me.Btn_Inser, Me.Btn_Modify, Me.Cmd_Exit})
        Me.Tool_Top.Location = New System.Drawing.Point(0, 0)
        Me.Tool_Top.MinimumSize = New System.Drawing.Size(0, 40)
        Me.Tool_Top.Name = "Tool_Top"
        Me.Tool_Top.Size = New System.Drawing.Size(780, 40)
        Me.Tool_Top.TabIndex = 10
        Me.Tool_Top.Text = "ToolStrip2"
        '
        'Cmd_Save
        '
        Me.Cmd_Save.AccessibleDescription = "修改按钮"
        Me.Cmd_Save.AccessibleName = ""
        Me.Cmd_Save.Image = Global.DN155_AtMachine.My.Resources.Resources.Modify
        Me.Cmd_Save.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Save.Name = "Cmd_Save"
        Me.Cmd_Save.Size = New System.Drawing.Size(57, 37)
        Me.Cmd_Save.Text = "保存"
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
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 40)
        '
        'Btn_Inser
        '
        Me.Btn_Inser.Image = Global.DN155_AtMachine.My.Resources.Resources.edit
        Me.Btn_Inser.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Btn_Inser.Name = "Btn_Inser"
        Me.Btn_Inser.Size = New System.Drawing.Size(81, 37)
        Me.Btn_Inser.Text = "插入记录"
        '
        'Btn_Modify
        '
        Me.Btn_Modify.Image = Global.DN155_AtMachine.My.Resources.Resources.Modify
        Me.Btn_Modify.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Btn_Modify.Name = "Btn_Modify"
        Me.Btn_Modify.Size = New System.Drawing.Size(81, 37)
        Me.Btn_Modify.Text = "更改记录"
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
        Me.PanelMain.Controls.Add(Me.Employee_List1)
        Me.PanelMain.Controls.Add(Me.Tool_Search)
        Me.PanelMain.Controls.Add(Me.GroupBox1)
        Me.PanelMain.Controls.Add(Me.Fg1)
        Me.PanelMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelMain.Location = New System.Drawing.Point(0, 40)
        Me.PanelMain.Name = "PanelMain"
        Me.PanelMain.Padding = New System.Windows.Forms.Padding(2)
        Me.PanelMain.Size = New System.Drawing.Size(780, 696)
        Me.PanelMain.TabIndex = 0
        '
        'Employee_List1
        '
        Me.Employee_List1.BackColor = System.Drawing.Color.DodgerBlue
        Me.Employee_List1.IsShowAll = True
        Me.Employee_List1.IsTBLostFocusSelOne = True
        Me.Employee_List1.Location = New System.Drawing.Point(-1320, 60)
        Me.Employee_List1.Name = "Employee_List1"
        Me.Employee_List1.SearchId = ""
        Me.Employee_List1.SearchType = BaseClass.Employee_List.ENum_SearchType.ALL
        Me.Employee_List1.Size = New System.Drawing.Size(250, 210)
        Me.Employee_List1.TabIndex = 7
        Me.Employee_List1.Visible = False
        '
        'Tool_Search
        '
        Me.Tool_Search.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.DP_Start, Me.ToolStripLabel2, Me.DP_End, Me.Cmd_ChooseDept, Me.ToolStripLabel4, Me.CB_Employee, Me.Btn_Search})
        Me.Tool_Search.Location = New System.Drawing.Point(2, 2)
        Me.Tool_Search.MinimumSize = New System.Drawing.Size(0, 30)
        Me.Tool_Search.Name = "Tool_Search"
        Me.Tool_Search.Size = New System.Drawing.Size(776, 30)
        Me.Tool_Search.TabIndex = 42
        Me.Tool_Search.Text = "ToolStrip1"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(17, 27)
        Me.ToolStripLabel1.Text = "从"
        '
        'DP_Start
        '
        Me.DP_Start.Name = "DP_Start"
        Me.DP_Start.Size = New System.Drawing.Size(100, 27)
        Me.DP_Start.Text = "2012-07-16"
        Me.DP_Start.Value = New Date(2012, 7, 16, 0, 0, 0, 0)
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(17, 27)
        Me.ToolStripLabel2.Text = "到"
        '
        'DP_End
        '
        Me.DP_End.Name = "DP_End"
        Me.DP_End.Size = New System.Drawing.Size(100, 27)
        Me.DP_End.Text = "2012-07-16"
        Me.DP_End.Value = New Date(2012, 7, 16, 0, 0, 0, 0)
        '
        'Cmd_ChooseDept
        '
        Me.Cmd_ChooseDept.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.Cmd_ChooseDept.ForeColor = System.Drawing.Color.Blue
        Me.Cmd_ChooseDept.Image = CType(resources.GetObject("Cmd_ChooseDept.Image"), System.Drawing.Image)
        Me.Cmd_ChooseDept.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_ChooseDept.Name = "Cmd_ChooseDept"
        Me.Cmd_ChooseDept.Size = New System.Drawing.Size(57, 27)
        Me.Cmd_ChooseDept.Text = "选择部门"
        '
        'ToolStripLabel4
        '
        Me.ToolStripLabel4.Name = "ToolStripLabel4"
        Me.ToolStripLabel4.Size = New System.Drawing.Size(65, 27)
        Me.ToolStripLabel4.Text = "员工姓名："
        '
        'CB_Employee
        '
        Me.CB_Employee.Child = "ComboEmployee"
        Me.CB_Employee.IDAsInt = 0
        Me.CB_Employee.IDValue = "0"
        Me.CB_Employee.IsKeyDownAutoSearch = True
        Me.CB_Employee.Name = "CB_Employee"
        Me.CB_Employee.SearchType = BaseClass.cSearchType.ENum_SearchType.ALL
        Me.CB_Employee.Size = New System.Drawing.Size(100, 27)
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
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.PL_day)
        Me.GroupBox1.Controls.Add(Me.PL_time)
        Me.GroupBox1.Controls.Add(Me.CB_QC)
        Me.GroupBox1.Controls.Add(Me.TB_Le_Cause)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.TB_Le_User)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.TB_Employee_Name)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.TB_Employee_No)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.RB_Time)
        Me.GroupBox1.Controls.Add(Me.RB_Day)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 40)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(770, 149)
        Me.GroupBox1.TabIndex = 41
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "请假录入"
        '
        'PL_day
        '
        Me.PL_day.Controls.Add(Me.DTP_Start)
        Me.PL_day.Controls.Add(Me.DTP_End)
        Me.PL_day.Location = New System.Drawing.Point(110, 19)
        Me.PL_day.Name = "PL_day"
        Me.PL_day.Size = New System.Drawing.Size(238, 39)
        Me.PL_day.TabIndex = 20
        '
        'DTP_Start
        '
        Me.DTP_Start.CustomFormat = "yyyy-MM-dd"
        Me.DTP_Start.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTP_Start.Location = New System.Drawing.Point(3, 4)
        Me.DTP_Start.Name = "DTP_Start"
        Me.DTP_Start.Size = New System.Drawing.Size(100, 23)
        Me.DTP_Start.TabIndex = 4
        '
        'DTP_End
        '
        Me.DTP_End.CustomFormat = "yyyy-MM-dd"
        Me.DTP_End.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTP_End.Location = New System.Drawing.Point(129, 4)
        Me.DTP_End.Name = "DTP_End"
        Me.DTP_End.Size = New System.Drawing.Size(100, 23)
        Me.DTP_End.TabIndex = 5
        '
        'PL_time
        '
        Me.PL_time.Controls.Add(Me.DTP_Day)
        Me.PL_time.Controls.Add(Me.Label6)
        Me.PL_time.Controls.Add(Me.DTP_Start_time)
        Me.PL_time.Controls.Add(Me.DTP_End_Time)
        Me.PL_time.Location = New System.Drawing.Point(104, 60)
        Me.PL_time.Name = "PL_time"
        Me.PL_time.Size = New System.Drawing.Size(307, 27)
        Me.PL_time.TabIndex = 19
        '
        'DTP_Day
        '
        Me.DTP_Day.CustomFormat = "yyyy-MM-dd"
        Me.DTP_Day.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTP_Day.Location = New System.Drawing.Point(9, 2)
        Me.DTP_Day.Name = "DTP_Day"
        Me.DTP_Day.Size = New System.Drawing.Size(100, 23)
        Me.DTP_Day.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(209, 5)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(14, 14)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "-"
        '
        'DTP_Start_time
        '
        Me.DTP_Start_time.CustomFormat = "HH:mm"
        Me.DTP_Start_time.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTP_Start_time.Location = New System.Drawing.Point(129, 2)
        Me.DTP_Start_time.Name = "DTP_Start_time"
        Me.DTP_Start_time.ShowUpDown = True
        Me.DTP_Start_time.Size = New System.Drawing.Size(74, 23)
        Me.DTP_Start_time.TabIndex = 0
        Me.DTP_Start_time.Value = New Date(2012, 7, 16, 18, 12, 0, 0)
        '
        'DTP_End_Time
        '
        Me.DTP_End_Time.CustomFormat = "HH:mm"
        Me.DTP_End_Time.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTP_End_Time.Location = New System.Drawing.Point(229, 2)
        Me.DTP_End_Time.Name = "DTP_End_Time"
        Me.DTP_End_Time.ShowUpDown = True
        Me.DTP_End_Time.Size = New System.Drawing.Size(72, 23)
        Me.DTP_End_Time.TabIndex = 3
        '
        'CB_QC
        '
        Me.CB_QC.AutoSize = True
        Me.CB_QC.Location = New System.Drawing.Point(354, 23)
        Me.CB_QC.Name = "CB_QC"
        Me.CB_QC.Size = New System.Drawing.Size(54, 18)
        Me.CB_QC.TabIndex = 17
        Me.CB_QC.Text = "出勤"
        Me.CB_QC.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CB_QC.UseVisualStyleBackColor = True
        '
        'TB_Le_Cause
        '
        Me.TB_Le_Cause.Location = New System.Drawing.Point(524, 20)
        Me.TB_Le_Cause.Multiline = True
        Me.TB_Le_Cause.Name = "TB_Le_Cause"
        Me.TB_Le_Cause.Size = New System.Drawing.Size(219, 62)
        Me.TB_Le_Cause.TabIndex = 16
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(444, 27)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(77, 14)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "请假原因："
        '
        'TB_Le_User
        '
        Me.TB_Le_User.Location = New System.Drawing.Point(609, 99)
        Me.TB_Le_User.Name = "TB_Le_User"
        Me.TB_Le_User.ReadOnly = True
        Me.TB_Le_User.Size = New System.Drawing.Size(134, 23)
        Me.TB_Le_User.TabIndex = 14
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(533, 102)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 14)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = " 录入人："
        '
        'TB_Employee_Name
        '
        Me.TB_Employee_Name.Location = New System.Drawing.Point(354, 99)
        Me.TB_Employee_Name.Name = "TB_Employee_Name"
        Me.TB_Employee_Name.ReadOnly = True
        Me.TB_Employee_Name.Size = New System.Drawing.Size(132, 23)
        Me.TB_Employee_Name.TabIndex = 12
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(271, 102)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 14)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "员工姓名："
        '
        'TB_Employee_No
        '
        Me.TB_Employee_No.Location = New System.Drawing.Point(119, 99)
        Me.TB_Employee_No.Name = "TB_Employee_No"
        Me.TB_Employee_No.ReadOnly = True
        Me.TB_Employee_No.Size = New System.Drawing.Size(100, 23)
        Me.TB_Employee_No.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(42, 102)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 14)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "员工编号："
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(23, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 14)
        Me.Label1.TabIndex = 8
        '
        'RB_Time
        '
        Me.RB_Time.AutoSize = True
        Me.RB_Time.Location = New System.Drawing.Point(26, 64)
        Me.RB_Time.Name = "RB_Time"
        Me.RB_Time.Size = New System.Drawing.Size(95, 18)
        Me.RB_Time.TabIndex = 6
        Me.RB_Time.TabStop = True
        Me.RB_Time.Text = "按时请假："
        Me.RB_Time.UseVisualStyleBackColor = True
        '
        'RB_Day
        '
        Me.RB_Day.AutoSize = True
        Me.RB_Day.Location = New System.Drawing.Point(26, 25)
        Me.RB_Day.Name = "RB_Day"
        Me.RB_Day.Size = New System.Drawing.Size(95, 18)
        Me.RB_Day.TabIndex = 2
        Me.RB_Day.TabStop = True
        Me.RB_Day.Text = "按日请假："
        Me.RB_Day.UseVisualStyleBackColor = True
        '
        'Fg1
        '
        Me.Fg1.AutoAddIndex = True
        Me.Fg1.AutoGenerateColumns = False
        Me.Fg1.AutoResize = False
        Me.Fg1.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.Fg1.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.XpThemes
        Me.Fg1.CanEditing = False
        Me.Fg1.ColumnInfo = resources.GetString("Fg1.ColumnInfo")
        Me.Fg1.EditFormat = True
        Me.Fg1.ExtendLastCol = True
        Me.Fg1.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Fg1.ForeColor = System.Drawing.Color.Black
        Me.Fg1.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.Fg1.IsAutoAddRow = False
        Me.Fg1.IsClickStartEdit = False
        Me.Fg1.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.Fg1.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.Fg1.Location = New System.Drawing.Point(3, 203)
        Me.Fg1.Name = "Fg1"
        Me.Fg1.Rows.Count = 10
        Me.Fg1.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.Fg1.Size = New System.Drawing.Size(770, 457)
        Me.Fg1.StartCol = ""
        Me.Fg1.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("Fg1.Styles"))
        Me.Fg1.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.BelowData
        Me.Fg1.TabIndex = 40
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(71, 123)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(408, 22)
        Me.ProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.ProgressBar1.TabIndex = 12
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
        'Pic_From
        '
        Me.Pic_From.Controls.Add(Me.LabelMsg)
        Me.Pic_From.Controls.Add(Me.ProgressBar1)
        Me.Pic_From.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pic_From.Location = New System.Drawing.Point(0, 0)
        Me.Pic_From.Name = "Pic_From"
        Me.Pic_From.Size = New System.Drawing.Size(780, 736)
        Me.Pic_From.TabIndex = 11
        '
        'F15531_AT_Leave_Msg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.PanelMain)
        Me.Controls.Add(Me.Tool_Top)
        Me.Controls.Add(Me.Pic_From)
        Me.Name = "F15531_AT_Leave_Msg"
        Me.Size = New System.Drawing.Size(780, 736)
        Me.Title = "请假记录"
        Me.Tool_Top.ResumeLayout(False)
        Me.Tool_Top.PerformLayout()
        Me.PanelMain.ResumeLayout(False)
        Me.PanelMain.PerformLayout()
        Me.Tool_Search.ResumeLayout(False)
        Me.Tool_Search.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.PL_day.ResumeLayout(False)
        Me.PL_time.ResumeLayout(False)
        Me.PL_time.PerformLayout()
        CType(Me.Fg1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pic_From.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Tool_Top As System.Windows.Forms.ToolStrip
    Friend WithEvents Cmd_Save As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_Del As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Cmd_Exit As System.Windows.Forms.ToolStripButton
    Friend WithEvents PanelMain As System.Windows.Forms.Panel
    Friend WithEvents Employee_List1 As BaseClass.Employee_List
    Friend WithEvents Fg1 As PClass.FG
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents DTP_Day As System.Windows.Forms.DateTimePicker
    Friend WithEvents DTP_Start_time As System.Windows.Forms.DateTimePicker
    Friend WithEvents RB_Time As System.Windows.Forms.RadioButton
    Friend WithEvents DTP_End As System.Windows.Forms.DateTimePicker
    Friend WithEvents DTP_Start As System.Windows.Forms.DateTimePicker
    Friend WithEvents DTP_End_Time As System.Windows.Forms.DateTimePicker
    Friend WithEvents RB_Day As System.Windows.Forms.RadioButton
    Friend WithEvents Tool_Search As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents DP_Start As PClass.ToolStripDateTimePicker
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents DP_End As PClass.ToolStripDateTimePicker
    Friend WithEvents Btn_Search As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TB_Le_User As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TB_Employee_Name As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TB_Employee_No As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TB_Le_Cause As System.Windows.Forms.TextBox
    Friend WithEvents CB_QC As System.Windows.Forms.CheckBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Btn_Inser As System.Windows.Forms.ToolStripButton
    Friend WithEvents CB_Employee As BaseClass.ToolStripComboList
    Friend WithEvents Cmd_ChooseDept As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripLabel4 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents PL_time As System.Windows.Forms.Panel
    Friend WithEvents PL_day As System.Windows.Forms.Panel
    Friend WithEvents Btn_Modify As System.Windows.Forms.ToolStripButton
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents LabelMsg As System.Windows.Forms.Label
    Friend WithEvents Pic_From As System.Windows.Forms.Panel

End Class
