<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F15611_Attendance_Msg
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
        Me.Tool_Top = New System.Windows.Forms.ToolStrip
        Me.Cmd_Modify = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.Cmd_Exit = New System.Windows.Forms.ToolStripButton
        Me.ToolStripLabel4 = New System.Windows.Forms.ToolStripLabel
        Me.TB_Depart = New System.Windows.Forms.ToolStripTextBox
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel
        Me.TB_Employee_No = New System.Windows.Forms.ToolStripTextBox
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel
        Me.TB_Employee_Name = New System.Windows.Forms.ToolStripTextBox
        Me.PanelMain = New System.Windows.Forms.Panel
        Me.Label1 = New System.Windows.Forms.Label
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel
        Me.PL_Sumday = New System.Windows.Forms.Panel
        Me.LB_Sumday = New System.Windows.Forms.Label
        Me.PL_Monday = New System.Windows.Forms.Panel
        Me.LB_Monday = New System.Windows.Forms.Label
        Me.PL_Tuesday = New System.Windows.Forms.Panel
        Me.LB_Tuesday = New System.Windows.Forms.Label
        Me.PL_Wednesday = New System.Windows.Forms.Panel
        Me.LB_Wednesday = New System.Windows.Forms.Label
        Me.PL_Thursday = New System.Windows.Forms.Panel
        Me.LB_Thursday = New System.Windows.Forms.Label
        Me.PL_Friday = New System.Windows.Forms.Panel
        Me.LB_Friday = New System.Windows.Forms.Label
        Me.PL_Saturday = New System.Windows.Forms.Panel
        Me.LB_Saturday = New System.Windows.Forms.Label
        Me.FP_Month = New System.Windows.Forms.FlowLayoutPanel
        Me.MonthPicker = New BaseClass.ToolStripMonthPicker(Me.components)
        Me.Tool_Top.SuspendLayout()
        Me.PanelMain.SuspendLayout()
        Me.FlowLayoutPanel2.SuspendLayout()
        Me.PL_Sumday.SuspendLayout()
        Me.PL_Monday.SuspendLayout()
        Me.PL_Tuesday.SuspendLayout()
        Me.PL_Wednesday.SuspendLayout()
        Me.PL_Thursday.SuspendLayout()
        Me.PL_Friday.SuspendLayout()
        Me.PL_Saturday.SuspendLayout()
        Me.SuspendLayout()
        '
        'Tool_Top
        '
        Me.Tool_Top.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.Tool_Top.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Cmd_Modify, Me.ToolStripSeparator2, Me.Cmd_Exit, Me.MonthPicker, Me.ToolStripLabel4, Me.TB_Depart, Me.ToolStripLabel1, Me.TB_Employee_No, Me.ToolStripLabel2, Me.TB_Employee_Name})
        Me.Tool_Top.Location = New System.Drawing.Point(0, 0)
        Me.Tool_Top.MinimumSize = New System.Drawing.Size(0, 40)
        Me.Tool_Top.Name = "Tool_Top"
        Me.Tool_Top.Size = New System.Drawing.Size(929, 40)
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
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 40)
        '
        'Cmd_Exit
        '
        Me.Cmd_Exit.Image = Global.DN155_AtMachine.My.Resources.Resources.Close
        Me.Cmd_Exit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(57, 37)
        Me.Cmd_Exit.Text = "关闭"
        '
        'ToolStripLabel4
        '
        Me.ToolStripLabel4.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ToolStripLabel4.Name = "ToolStripLabel4"
        Me.ToolStripLabel4.Size = New System.Drawing.Size(42, 37)
        Me.ToolStripLabel4.Text = "部门:"
        '
        'TB_Depart
        '
        Me.TB_Depart.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TB_Depart.Name = "TB_Depart"
        Me.TB_Depart.Size = New System.Drawing.Size(100, 40)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ToolStripLabel1.Margin = New System.Windows.Forms.Padding(2, 1, 0, 2)
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(42, 37)
        Me.ToolStripLabel1.Text = "编号:"
        '
        'TB_Employee_No
        '
        Me.TB_Employee_No.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TB_Employee_No.Name = "TB_Employee_No"
        Me.TB_Employee_No.Size = New System.Drawing.Size(100, 40)
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ToolStripLabel2.Margin = New System.Windows.Forms.Padding(10, 1, 0, 2)
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(42, 37)
        Me.ToolStripLabel2.Text = "姓名:"
        '
        'TB_Employee_Name
        '
        Me.TB_Employee_Name.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TB_Employee_Name.Name = "TB_Employee_Name"
        Me.TB_Employee_Name.Size = New System.Drawing.Size(100, 40)
        '
        'PanelMain
        '
        Me.PanelMain.Controls.Add(Me.Label1)
        Me.PanelMain.Controls.Add(Me.FlowLayoutPanel2)
        Me.PanelMain.Controls.Add(Me.FP_Month)
        Me.PanelMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelMain.Location = New System.Drawing.Point(0, 40)
        Me.PanelMain.Name = "PanelMain"
        Me.PanelMain.Padding = New System.Windows.Forms.Padding(2)
        Me.PanelMain.Size = New System.Drawing.Size(929, 674)
        Me.PanelMain.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(11, 619)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(532, 14)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "√正常出勤 ▲请假 ★带薪假期 ●迟到 ■早退 ×旷工 ○上班无打卡 □下班无打卡"
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.BackColor = System.Drawing.Color.Blue
        Me.FlowLayoutPanel2.Controls.Add(Me.PL_Sumday)
        Me.FlowLayoutPanel2.Controls.Add(Me.PL_Monday)
        Me.FlowLayoutPanel2.Controls.Add(Me.PL_Tuesday)
        Me.FlowLayoutPanel2.Controls.Add(Me.PL_Wednesday)
        Me.FlowLayoutPanel2.Controls.Add(Me.PL_Thursday)
        Me.FlowLayoutPanel2.Controls.Add(Me.PL_Friday)
        Me.FlowLayoutPanel2.Controls.Add(Me.PL_Saturday)
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(13, 4)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(898, 58)
        Me.FlowLayoutPanel2.TabIndex = 14
        '
        'PL_Sumday
        '
        Me.PL_Sumday.BackColor = System.Drawing.Color.Transparent
        Me.PL_Sumday.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PL_Sumday.Controls.Add(Me.LB_Sumday)
        Me.PL_Sumday.Location = New System.Drawing.Point(8, 3)
        Me.PL_Sumday.Name = "PL_Sumday"
        Me.PL_Sumday.Size = New System.Drawing.Size(120, 49)
        Me.PL_Sumday.TabIndex = 43
        '
        'LB_Sumday
        '
        Me.LB_Sumday.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LB_Sumday.Font = New System.Drawing.Font("宋体", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LB_Sumday.ForeColor = System.Drawing.Color.White
        Me.LB_Sumday.Location = New System.Drawing.Point(0, 0)
        Me.LB_Sumday.Name = "LB_Sumday"
        Me.LB_Sumday.Size = New System.Drawing.Size(118, 47)
        Me.LB_Sumday.TabIndex = 0
        Me.LB_Sumday.Text = "星期日"
        Me.LB_Sumday.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PL_Monday
        '
        Me.PL_Monday.BackColor = System.Drawing.Color.Transparent
        Me.PL_Monday.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PL_Monday.Controls.Add(Me.LB_Monday)
        Me.PL_Monday.Location = New System.Drawing.Point(134, 3)
        Me.PL_Monday.Name = "PL_Monday"
        Me.PL_Monday.Size = New System.Drawing.Size(120, 49)
        Me.PL_Monday.TabIndex = 44
        '
        'LB_Monday
        '
        Me.LB_Monday.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LB_Monday.Font = New System.Drawing.Font("宋体", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LB_Monday.ForeColor = System.Drawing.Color.White
        Me.LB_Monday.Location = New System.Drawing.Point(0, 0)
        Me.LB_Monday.Name = "LB_Monday"
        Me.LB_Monday.Size = New System.Drawing.Size(118, 47)
        Me.LB_Monday.TabIndex = 0
        Me.LB_Monday.Text = "星期一"
        Me.LB_Monday.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PL_Tuesday
        '
        Me.PL_Tuesday.BackColor = System.Drawing.Color.Transparent
        Me.PL_Tuesday.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PL_Tuesday.Controls.Add(Me.LB_Tuesday)
        Me.PL_Tuesday.Location = New System.Drawing.Point(260, 3)
        Me.PL_Tuesday.Name = "PL_Tuesday"
        Me.PL_Tuesday.Size = New System.Drawing.Size(120, 49)
        Me.PL_Tuesday.TabIndex = 45
        '
        'LB_Tuesday
        '
        Me.LB_Tuesday.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LB_Tuesday.Font = New System.Drawing.Font("宋体", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LB_Tuesday.ForeColor = System.Drawing.Color.White
        Me.LB_Tuesday.Location = New System.Drawing.Point(0, 0)
        Me.LB_Tuesday.Name = "LB_Tuesday"
        Me.LB_Tuesday.Size = New System.Drawing.Size(118, 47)
        Me.LB_Tuesday.TabIndex = 0
        Me.LB_Tuesday.Text = "星期二"
        Me.LB_Tuesday.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PL_Wednesday
        '
        Me.PL_Wednesday.BackColor = System.Drawing.Color.Transparent
        Me.PL_Wednesday.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PL_Wednesday.Controls.Add(Me.LB_Wednesday)
        Me.PL_Wednesday.Location = New System.Drawing.Point(386, 3)
        Me.PL_Wednesday.Name = "PL_Wednesday"
        Me.PL_Wednesday.Size = New System.Drawing.Size(120, 49)
        Me.PL_Wednesday.TabIndex = 46
        '
        'LB_Wednesday
        '
        Me.LB_Wednesday.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LB_Wednesday.Font = New System.Drawing.Font("宋体", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LB_Wednesday.ForeColor = System.Drawing.Color.White
        Me.LB_Wednesday.Location = New System.Drawing.Point(0, 0)
        Me.LB_Wednesday.Name = "LB_Wednesday"
        Me.LB_Wednesday.Size = New System.Drawing.Size(118, 47)
        Me.LB_Wednesday.TabIndex = 0
        Me.LB_Wednesday.Text = "星期三"
        Me.LB_Wednesday.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PL_Thursday
        '
        Me.PL_Thursday.BackColor = System.Drawing.Color.Transparent
        Me.PL_Thursday.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PL_Thursday.Controls.Add(Me.LB_Thursday)
        Me.PL_Thursday.Location = New System.Drawing.Point(512, 3)
        Me.PL_Thursday.Name = "PL_Thursday"
        Me.PL_Thursday.Size = New System.Drawing.Size(120, 49)
        Me.PL_Thursday.TabIndex = 47
        '
        'LB_Thursday
        '
        Me.LB_Thursday.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LB_Thursday.Font = New System.Drawing.Font("宋体", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LB_Thursday.ForeColor = System.Drawing.Color.White
        Me.LB_Thursday.Location = New System.Drawing.Point(0, 0)
        Me.LB_Thursday.Name = "LB_Thursday"
        Me.LB_Thursday.Size = New System.Drawing.Size(118, 47)
        Me.LB_Thursday.TabIndex = 0
        Me.LB_Thursday.Text = "星期四"
        Me.LB_Thursday.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PL_Friday
        '
        Me.PL_Friday.BackColor = System.Drawing.Color.Transparent
        Me.PL_Friday.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PL_Friday.Controls.Add(Me.LB_Friday)
        Me.PL_Friday.Location = New System.Drawing.Point(638, 3)
        Me.PL_Friday.Name = "PL_Friday"
        Me.PL_Friday.Size = New System.Drawing.Size(120, 49)
        Me.PL_Friday.TabIndex = 48
        '
        'LB_Friday
        '
        Me.LB_Friday.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LB_Friday.Font = New System.Drawing.Font("宋体", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LB_Friday.ForeColor = System.Drawing.Color.White
        Me.LB_Friday.Location = New System.Drawing.Point(0, 0)
        Me.LB_Friday.Name = "LB_Friday"
        Me.LB_Friday.Size = New System.Drawing.Size(118, 47)
        Me.LB_Friday.TabIndex = 0
        Me.LB_Friday.Text = "星期五"
        Me.LB_Friday.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PL_Saturday
        '
        Me.PL_Saturday.BackColor = System.Drawing.Color.Transparent
        Me.PL_Saturday.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PL_Saturday.Controls.Add(Me.LB_Saturday)
        Me.PL_Saturday.Location = New System.Drawing.Point(764, 3)
        Me.PL_Saturday.Name = "PL_Saturday"
        Me.PL_Saturday.Size = New System.Drawing.Size(120, 49)
        Me.PL_Saturday.TabIndex = 49
        '
        'LB_Saturday
        '
        Me.LB_Saturday.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LB_Saturday.Font = New System.Drawing.Font("宋体", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LB_Saturday.ForeColor = System.Drawing.Color.White
        Me.LB_Saturday.Location = New System.Drawing.Point(0, 0)
        Me.LB_Saturday.Name = "LB_Saturday"
        Me.LB_Saturday.Size = New System.Drawing.Size(118, 47)
        Me.LB_Saturday.TabIndex = 0
        Me.LB_Saturday.Text = "星期六"
        Me.LB_Saturday.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FP_Month
        '
        Me.FP_Month.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.FP_Month.Location = New System.Drawing.Point(13, 61)
        Me.FP_Month.Name = "FP_Month"
        Me.FP_Month.Padding = New System.Windows.Forms.Padding(5)
        Me.FP_Month.Size = New System.Drawing.Size(898, 551)
        Me.FP_Month.TabIndex = 15
        '
        'MonthPicker
        '
        Me.MonthPicker.AutoSize = False
        Me.MonthPicker.BackColor = System.Drawing.Color.Transparent
        Me.MonthPicker.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.MonthPicker.Format = "yyyy年MM月"
        Me.MonthPicker.IsReadOnly = "False"
        Me.MonthPicker.IsShowTitle = True
        Me.MonthPicker.Margin = New System.Windows.Forms.Padding(150, 1, 0, 2)
        Me.MonthPicker.Name = "MonthPicker"
        Me.MonthPicker.ShowDirection = BaseClass.MonthPicker.Enum_ShowDirection.Below
        Me.MonthPicker.ShowDistince = 1
        Me.MonthPicker.Size = New System.Drawing.Size(130, 22)
        Me.MonthPicker.Text = "XXXX年XX月"
        Me.MonthPicker.Title = "月份:"
        Me.MonthPicker.TopMost = False
        Me.MonthPicker.Value = New Date(2012, 7, 1, 0, 0, 0, 0)
        '
        'F15611_Attendance_Msg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.PanelMain)
        Me.Controls.Add(Me.Tool_Top)
        Me.Name = "F15611_Attendance_Msg"
        Me.Size = New System.Drawing.Size(929, 714)
        Me.Title = "签卡记录"
        Me.Tool_Top.ResumeLayout(False)
        Me.Tool_Top.PerformLayout()
        Me.PanelMain.ResumeLayout(False)
        Me.PanelMain.PerformLayout()
        Me.FlowLayoutPanel2.ResumeLayout(False)
        Me.PL_Sumday.ResumeLayout(False)
        Me.PL_Monday.ResumeLayout(False)
        Me.PL_Tuesday.ResumeLayout(False)
        Me.PL_Wednesday.ResumeLayout(False)
        Me.PL_Thursday.ResumeLayout(False)
        Me.PL_Friday.ResumeLayout(False)
        Me.PL_Saturday.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Tool_Top As System.Windows.Forms.ToolStrip
    Friend WithEvents Cmd_Modify As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Cmd_Exit As System.Windows.Forms.ToolStripButton
    Friend WithEvents PanelMain As System.Windows.Forms.Panel
    Friend WithEvents FP_Month As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents FlowLayoutPanel2 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents PL_Sumday As System.Windows.Forms.Panel
    Friend WithEvents LB_Sumday As System.Windows.Forms.Label
    Friend WithEvents PL_Monday As System.Windows.Forms.Panel
    Friend WithEvents LB_Monday As System.Windows.Forms.Label
    Friend WithEvents PL_Tuesday As System.Windows.Forms.Panel
    Friend WithEvents LB_Tuesday As System.Windows.Forms.Label
    Friend WithEvents PL_Wednesday As System.Windows.Forms.Panel
    Friend WithEvents LB_Wednesday As System.Windows.Forms.Label
    Friend WithEvents PL_Thursday As System.Windows.Forms.Panel
    Friend WithEvents LB_Thursday As System.Windows.Forms.Label
    Friend WithEvents PL_Friday As System.Windows.Forms.Panel
    Friend WithEvents LB_Friday As System.Windows.Forms.Label
    Friend WithEvents PL_Saturday As System.Windows.Forms.Panel
    Friend WithEvents LB_Saturday As System.Windows.Forms.Label
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents TB_Employee_No As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents TB_Employee_Name As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripLabel4 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents TB_Depart As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents MonthPicker As BaseClass.ToolStripMonthPicker

End Class
