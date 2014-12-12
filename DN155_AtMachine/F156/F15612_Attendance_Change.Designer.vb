<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F15612_Attendance_Change
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
        Me.PanelMain = New System.Windows.Forms.Panel
        Me.LabelBC = New System.Windows.Forms.Label
        Me.LabelState = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.LB_Remark4 = New System.Windows.Forms.Label
        Me.LB_Remark5 = New System.Windows.Forms.Label
        Me.LB_Remark7 = New System.Windows.Forms.Label
        Me.LB_Remark2 = New System.Windows.Forms.Label
        Me.LB_Remark3 = New System.Windows.Forms.Label
        Me.LB_Remark6 = New System.Windows.Forms.Label
        Me.LB_Remark1 = New System.Windows.Forms.Label
        Me.LB_Remark8 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.LB_MX = New System.Windows.Forms.ListBox
        Me.Cmd_Auto = New System.Windows.Forms.Button
        Me.CB_Is_Auto = New System.Windows.Forms.CheckBox
        Me.ComboBox_Data = New System.Windows.Forms.ComboBox
        Me.CB_XX = New System.Windows.Forms.CheckBox
        Me.CB_QQ = New System.Windows.Forms.CheckBox
        Me.TB_CD = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.TB_ZT = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.CB_CQ = New System.Windows.Forms.CheckBox
        Me.TB_Up_Time = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.TB_Down_Time = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.TB_Remark_Mx = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.TB_Remark = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TB_User_Date = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.TB_Employee_No = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.TB_Employee_Name = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TB_Depart = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Cmd_Cancel = New System.Windows.Forms.Button
        Me.Cmd_Ok = New System.Windows.Forms.Button
        Me.LabelMsg = New System.Windows.Forms.Label
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.Pic_From = New System.Windows.Forms.Panel
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem_Up = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem_Down = New System.Windows.Forms.ToolStripMenuItem
        Me.PanelMain.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Pic_From.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelMain
        '
        Me.PanelMain.Controls.Add(Me.LabelBC)
        Me.PanelMain.Controls.Add(Me.LabelState)
        Me.PanelMain.Controls.Add(Me.GroupBox2)
        Me.PanelMain.Controls.Add(Me.GroupBox1)
        Me.PanelMain.Controls.Add(Me.Cmd_Auto)
        Me.PanelMain.Controls.Add(Me.CB_Is_Auto)
        Me.PanelMain.Controls.Add(Me.ComboBox_Data)
        Me.PanelMain.Controls.Add(Me.CB_XX)
        Me.PanelMain.Controls.Add(Me.CB_QQ)
        Me.PanelMain.Controls.Add(Me.TB_CD)
        Me.PanelMain.Controls.Add(Me.Label10)
        Me.PanelMain.Controls.Add(Me.TB_ZT)
        Me.PanelMain.Controls.Add(Me.Label11)
        Me.PanelMain.Controls.Add(Me.CB_CQ)
        Me.PanelMain.Controls.Add(Me.TB_Up_Time)
        Me.PanelMain.Controls.Add(Me.Label8)
        Me.PanelMain.Controls.Add(Me.TB_Down_Time)
        Me.PanelMain.Controls.Add(Me.Label9)
        Me.PanelMain.Controls.Add(Me.Label7)
        Me.PanelMain.Controls.Add(Me.TB_Remark_Mx)
        Me.PanelMain.Controls.Add(Me.Label6)
        Me.PanelMain.Controls.Add(Me.TB_Remark)
        Me.PanelMain.Controls.Add(Me.Label2)
        Me.PanelMain.Controls.Add(Me.TB_User_Date)
        Me.PanelMain.Controls.Add(Me.Label5)
        Me.PanelMain.Controls.Add(Me.TB_Employee_No)
        Me.PanelMain.Controls.Add(Me.Label4)
        Me.PanelMain.Controls.Add(Me.TB_Employee_Name)
        Me.PanelMain.Controls.Add(Me.Label3)
        Me.PanelMain.Controls.Add(Me.TB_Depart)
        Me.PanelMain.Controls.Add(Me.Label1)
        Me.PanelMain.Controls.Add(Me.Cmd_Cancel)
        Me.PanelMain.Controls.Add(Me.Cmd_Ok)
        Me.PanelMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelMain.Location = New System.Drawing.Point(0, 0)
        Me.PanelMain.Name = "PanelMain"
        Me.PanelMain.Padding = New System.Windows.Forms.Padding(2)
        Me.PanelMain.Size = New System.Drawing.Size(706, 424)
        Me.PanelMain.TabIndex = 0
        '
        'LabelBC
        '
        Me.LabelBC.AutoSize = True
        Me.LabelBC.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LabelBC.Location = New System.Drawing.Point(426, 27)
        Me.LabelBC.Name = "LabelBC"
        Me.LabelBC.Size = New System.Drawing.Size(34, 16)
        Me.LabelBC.TabIndex = 82
        Me.LabelBC.Text = "1号"
        Me.LabelBC.Visible = False
        '
        'LabelState
        '
        Me.LabelState.AutoSize = True
        Me.LabelState.ForeColor = System.Drawing.Color.Blue
        Me.LabelState.Location = New System.Drawing.Point(402, 250)
        Me.LabelState.Name = "LabelState"
        Me.LabelState.Size = New System.Drawing.Size(105, 14)
        Me.LabelState.TabIndex = 81
        Me.LabelState.Text = "当前是自动分析"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.LB_Remark4)
        Me.GroupBox2.Controls.Add(Me.LB_Remark5)
        Me.GroupBox2.Controls.Add(Me.LB_Remark7)
        Me.GroupBox2.Controls.Add(Me.LB_Remark2)
        Me.GroupBox2.Controls.Add(Me.LB_Remark3)
        Me.GroupBox2.Controls.Add(Me.LB_Remark6)
        Me.GroupBox2.Controls.Add(Me.LB_Remark1)
        Me.GroupBox2.Controls.Add(Me.LB_Remark8)
        Me.GroupBox2.Location = New System.Drawing.Point(13, 204)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(370, 68)
        Me.GroupBox2.TabIndex = 80
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "图例"
        '
        'LB_Remark4
        '
        Me.LB_Remark4.AutoSize = True
        Me.LB_Remark4.ForeColor = System.Drawing.Color.Blue
        Me.LB_Remark4.Location = New System.Drawing.Point(259, 23)
        Me.LB_Remark4.Name = "LB_Remark4"
        Me.LB_Remark4.Size = New System.Drawing.Size(91, 14)
        Me.LB_Remark4.TabIndex = 79
        Me.LB_Remark4.Text = "○上班无打卡"
        '
        'LB_Remark5
        '
        Me.LB_Remark5.AutoSize = True
        Me.LB_Remark5.ForeColor = System.Drawing.Color.Blue
        Me.LB_Remark5.Location = New System.Drawing.Point(12, 46)
        Me.LB_Remark5.Name = "LB_Remark5"
        Me.LB_Remark5.Size = New System.Drawing.Size(49, 14)
        Me.LB_Remark5.TabIndex = 78
        Me.LB_Remark5.Text = "×旷工"
        '
        'LB_Remark7
        '
        Me.LB_Remark7.AutoSize = True
        Me.LB_Remark7.ForeColor = System.Drawing.Color.Blue
        Me.LB_Remark7.Location = New System.Drawing.Point(189, 46)
        Me.LB_Remark7.Name = "LB_Remark7"
        Me.LB_Remark7.Size = New System.Drawing.Size(49, 14)
        Me.LB_Remark7.TabIndex = 77
        Me.LB_Remark7.Text = "■早退"
        '
        'LB_Remark2
        '
        Me.LB_Remark2.AutoSize = True
        Me.LB_Remark2.ForeColor = System.Drawing.Color.Blue
        Me.LB_Remark2.Location = New System.Drawing.Point(106, 23)
        Me.LB_Remark2.Name = "LB_Remark2"
        Me.LB_Remark2.Size = New System.Drawing.Size(77, 14)
        Me.LB_Remark2.TabIndex = 76
        Me.LB_Remark2.Text = "★带薪假期"
        '
        'LB_Remark3
        '
        Me.LB_Remark3.AutoSize = True
        Me.LB_Remark3.ForeColor = System.Drawing.Color.Blue
        Me.LB_Remark3.Location = New System.Drawing.Point(189, 23)
        Me.LB_Remark3.Name = "LB_Remark3"
        Me.LB_Remark3.Size = New System.Drawing.Size(49, 14)
        Me.LB_Remark3.TabIndex = 75
        Me.LB_Remark3.Text = "●迟到"
        '
        'LB_Remark6
        '
        Me.LB_Remark6.AutoSize = True
        Me.LB_Remark6.ForeColor = System.Drawing.Color.Blue
        Me.LB_Remark6.Location = New System.Drawing.Point(106, 46)
        Me.LB_Remark6.Name = "LB_Remark6"
        Me.LB_Remark6.Size = New System.Drawing.Size(49, 14)
        Me.LB_Remark6.TabIndex = 74
        Me.LB_Remark6.Text = "▲请假"
        '
        'LB_Remark1
        '
        Me.LB_Remark1.AutoSize = True
        Me.LB_Remark1.ForeColor = System.Drawing.Color.Blue
        Me.LB_Remark1.Location = New System.Drawing.Point(12, 23)
        Me.LB_Remark1.Name = "LB_Remark1"
        Me.LB_Remark1.Size = New System.Drawing.Size(77, 14)
        Me.LB_Remark1.TabIndex = 73
        Me.LB_Remark1.Text = "√正常出勤"
        '
        'LB_Remark8
        '
        Me.LB_Remark8.AutoSize = True
        Me.LB_Remark8.ForeColor = System.Drawing.Color.Blue
        Me.LB_Remark8.Location = New System.Drawing.Point(259, 46)
        Me.LB_Remark8.Name = "LB_Remark8"
        Me.LB_Remark8.Size = New System.Drawing.Size(91, 14)
        Me.LB_Remark8.TabIndex = 72
        Me.LB_Remark8.Text = "□下班无打卡"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.LB_MX)
        Me.GroupBox1.Location = New System.Drawing.Point(525, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(176, 414)
        Me.GroupBox1.TabIndex = 71
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "打卡明细"
        '
        'LB_MX
        '
        Me.LB_MX.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LB_MX.FormattingEnabled = True
        Me.LB_MX.ItemHeight = 14
        Me.LB_MX.Location = New System.Drawing.Point(3, 19)
        Me.LB_MX.Name = "LB_MX"
        Me.LB_MX.Size = New System.Drawing.Size(170, 382)
        Me.LB_MX.TabIndex = 0
        '
        'Cmd_Auto
        '
        Me.Cmd_Auto.Location = New System.Drawing.Point(49, 357)
        Me.Cmd_Auto.Name = "Cmd_Auto"
        Me.Cmd_Auto.Size = New System.Drawing.Size(123, 46)
        Me.Cmd_Auto.TabIndex = 70
        Me.Cmd_Auto.Text = "自动分析"
        Me.Cmd_Auto.UseVisualStyleBackColor = True
        '
        'CB_Is_Auto
        '
        Me.CB_Is_Auto.AutoSize = True
        Me.CB_Is_Auto.Enabled = False
        Me.CB_Is_Auto.Location = New System.Drawing.Point(276, 321)
        Me.CB_Is_Auto.Name = "CB_Is_Auto"
        Me.CB_Is_Auto.Size = New System.Drawing.Size(166, 18)
        Me.CB_Is_Auto.TabIndex = 69
        Me.CB_Is_Auto.Text = "根据打卡时间自动分析"
        Me.CB_Is_Auto.UseVisualStyleBackColor = True
        '
        'ComboBox_Data
        '
        Me.ComboBox_Data.BackColor = System.Drawing.Color.White
        Me.ComboBox_Data.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_Data.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ComboBox_Data.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ComboBox_Data.FormattingEnabled = True
        Me.ComboBox_Data.Location = New System.Drawing.Point(64, 110)
        Me.ComboBox_Data.Name = "ComboBox_Data"
        Me.ComboBox_Data.Size = New System.Drawing.Size(108, 24)
        Me.ComboBox_Data.TabIndex = 68
        '
        'CB_XX
        '
        Me.CB_XX.AutoSize = True
        Me.CB_XX.Location = New System.Drawing.Point(205, 321)
        Me.CB_XX.Name = "CB_XX"
        Me.CB_XX.Size = New System.Drawing.Size(54, 18)
        Me.CB_XX.TabIndex = 67
        Me.CB_XX.Text = "休息"
        Me.CB_XX.UseVisualStyleBackColor = True
        '
        'CB_QQ
        '
        Me.CB_QQ.AutoSize = True
        Me.CB_QQ.ForeColor = System.Drawing.Color.Red
        Me.CB_QQ.Location = New System.Drawing.Point(145, 321)
        Me.CB_QQ.Name = "CB_QQ"
        Me.CB_QQ.Size = New System.Drawing.Size(54, 18)
        Me.CB_QQ.TabIndex = 66
        Me.CB_QQ.Text = "缺勤"
        Me.CB_QQ.UseVisualStyleBackColor = True
        '
        'TB_CD
        '
        Me.TB_CD.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TB_CD.Location = New System.Drawing.Point(464, 111)
        Me.TB_CD.Name = "TB_CD"
        Me.TB_CD.Size = New System.Drawing.Size(55, 23)
        Me.TB_CD.TabIndex = 65
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(390, 114)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(63, 14)
        Me.Label10.TabIndex = 64
        Me.Label10.Text = "迟到分钟"
        '
        'TB_ZT
        '
        Me.TB_ZT.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TB_ZT.Location = New System.Drawing.Point(464, 156)
        Me.TB_ZT.Name = "TB_ZT"
        Me.TB_ZT.Size = New System.Drawing.Size(55, 23)
        Me.TB_ZT.TabIndex = 63
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(390, 159)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(70, 14)
        Me.Label11.TabIndex = 62
        Me.Label11.Text = "早退分钟:"
        '
        'CB_CQ
        '
        Me.CB_CQ.AutoSize = True
        Me.CB_CQ.ForeColor = System.Drawing.Color.Blue
        Me.CB_CQ.Location = New System.Drawing.Point(74, 321)
        Me.CB_CQ.Name = "CB_CQ"
        Me.CB_CQ.Size = New System.Drawing.Size(54, 18)
        Me.CB_CQ.TabIndex = 61
        Me.CB_CQ.Text = "出勤"
        Me.CB_CQ.UseVisualStyleBackColor = True
        '
        'TB_Up_Time
        '
        Me.TB_Up_Time.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TB_Up_Time.Location = New System.Drawing.Point(274, 111)
        Me.TB_Up_Time.Name = "TB_Up_Time"
        Me.TB_Up_Time.Size = New System.Drawing.Size(110, 23)
        Me.TB_Up_Time.TabIndex = 60
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(200, 114)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(70, 14)
        Me.Label8.TabIndex = 59
        Me.Label8.Text = "上班时间:"
        '
        'TB_Down_Time
        '
        Me.TB_Down_Time.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TB_Down_Time.Location = New System.Drawing.Point(274, 156)
        Me.TB_Down_Time.Name = "TB_Down_Time"
        Me.TB_Down_Time.Size = New System.Drawing.Size(110, 23)
        Me.TB_Down_Time.TabIndex = 58
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(200, 159)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(70, 14)
        Me.Label9.TabIndex = 57
        Me.Label9.Text = "下班时间:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(18, 286)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(42, 14)
        Me.Label7.TabIndex = 56
        Me.Label7.Text = "提示:"
        '
        'TB_Remark_Mx
        '
        Me.TB_Remark_Mx.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TB_Remark_Mx.Location = New System.Drawing.Point(64, 283)
        Me.TB_Remark_Mx.Name = "TB_Remark_Mx"
        Me.TB_Remark_Mx.Size = New System.Drawing.Size(457, 23)
        Me.TB_Remark_Mx.TabIndex = 54
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(16, 114)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(42, 14)
        Me.Label6.TabIndex = 53
        Me.Label6.Text = "班次:"
        '
        'TB_Remark
        '
        Me.TB_Remark.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TB_Remark.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TB_Remark.Location = New System.Drawing.Point(62, 156)
        Me.TB_Remark.Name = "TB_Remark"
        Me.TB_Remark.Size = New System.Drawing.Size(110, 23)
        Me.TB_Remark.TabIndex = 52
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 159)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 14)
        Me.Label2.TabIndex = 51
        Me.Label2.Text = "标记:"
        '
        'TB_User_Date
        '
        Me.TB_User_Date.Location = New System.Drawing.Point(274, 20)
        Me.TB_User_Date.Name = "TB_User_Date"
        Me.TB_User_Date.ReadOnly = True
        Me.TB_User_Date.Size = New System.Drawing.Size(110, 23)
        Me.TB_User_Date.TabIndex = 50
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(228, 23)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(42, 14)
        Me.Label5.TabIndex = 49
        Me.Label5.Text = "日期:"
        '
        'TB_Employee_No
        '
        Me.TB_Employee_No.Location = New System.Drawing.Point(62, 65)
        Me.TB_Employee_No.Name = "TB_Employee_No"
        Me.TB_Employee_No.ReadOnly = True
        Me.TB_Employee_No.Size = New System.Drawing.Size(110, 23)
        Me.TB_Employee_No.TabIndex = 48
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 68)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 14)
        Me.Label4.TabIndex = 47
        Me.Label4.Text = "编号:"
        '
        'TB_Employee_Name
        '
        Me.TB_Employee_Name.Location = New System.Drawing.Point(274, 65)
        Me.TB_Employee_Name.Name = "TB_Employee_Name"
        Me.TB_Employee_Name.ReadOnly = True
        Me.TB_Employee_Name.Size = New System.Drawing.Size(110, 23)
        Me.TB_Employee_Name.TabIndex = 46
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(228, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 14)
        Me.Label3.TabIndex = 45
        Me.Label3.Text = "姓名:"
        '
        'TB_Depart
        '
        Me.TB_Depart.Location = New System.Drawing.Point(62, 20)
        Me.TB_Depart.Name = "TB_Depart"
        Me.TB_Depart.ReadOnly = True
        Me.TB_Depart.Size = New System.Drawing.Size(110, 23)
        Me.TB_Depart.TabIndex = 44
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 14)
        Me.Label1.TabIndex = 42
        Me.Label1.Text = "部门:"
        '
        'Cmd_Cancel
        '
        Me.Cmd_Cancel.Location = New System.Drawing.Point(393, 357)
        Me.Cmd_Cancel.Name = "Cmd_Cancel"
        Me.Cmd_Cancel.Size = New System.Drawing.Size(123, 46)
        Me.Cmd_Cancel.TabIndex = 41
        Me.Cmd_Cancel.Text = "取消"
        Me.Cmd_Cancel.UseVisualStyleBackColor = True
        '
        'Cmd_Ok
        '
        Me.Cmd_Ok.Location = New System.Drawing.Point(220, 357)
        Me.Cmd_Ok.Name = "Cmd_Ok"
        Me.Cmd_Ok.Size = New System.Drawing.Size(123, 46)
        Me.Cmd_Ok.TabIndex = 40
        Me.Cmd_Ok.Text = "确认"
        Me.Cmd_Ok.UseVisualStyleBackColor = True
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
        Me.Pic_From.Size = New System.Drawing.Size(706, 424)
        Me.Pic_From.TabIndex = 11
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem_Up, Me.ToolStripMenuItem_Down})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(155, 48)
        '
        'ToolStripMenuItem_Up
        '
        Me.ToolStripMenuItem_Up.Name = "ToolStripMenuItem_Up"
        Me.ToolStripMenuItem_Up.Size = New System.Drawing.Size(154, 22)
        Me.ToolStripMenuItem_Up.Text = "复制到上班时间"
        '
        'ToolStripMenuItem_Down
        '
        Me.ToolStripMenuItem_Down.Name = "ToolStripMenuItem_Down"
        Me.ToolStripMenuItem_Down.Size = New System.Drawing.Size(154, 22)
        Me.ToolStripMenuItem_Down.Text = "复制到下班时间"
        '
        'F15612_Attendance_Change
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.PanelMain)
        Me.Controls.Add(Me.Pic_From)
        Me.Name = "F15612_Attendance_Change"
        Me.Size = New System.Drawing.Size(706, 424)
        Me.Title = "考勤记录"
        Me.PanelMain.ResumeLayout(False)
        Me.PanelMain.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.Pic_From.ResumeLayout(False)
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelMain As System.Windows.Forms.Panel
    Friend WithEvents LabelMsg As System.Windows.Forms.Label
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents Pic_From As System.Windows.Forms.Panel
    Friend WithEvents Cmd_Cancel As System.Windows.Forms.Button
    Friend WithEvents Cmd_Ok As System.Windows.Forms.Button
    Friend WithEvents TB_Remark_Mx As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TB_Remark As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TB_User_Date As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TB_Employee_No As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TB_Employee_Name As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TB_Depart As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CB_XX As System.Windows.Forms.CheckBox
    Friend WithEvents CB_QQ As System.Windows.Forms.CheckBox
    Friend WithEvents TB_CD As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TB_ZT As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents CB_CQ As System.Windows.Forms.CheckBox
    Friend WithEvents TB_Up_Time As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TB_Down_Time As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Cmd_Auto As System.Windows.Forms.Button
    Friend WithEvents CB_Is_Auto As System.Windows.Forms.CheckBox
    Public WithEvents ComboBox_Data As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents LB_MX As System.Windows.Forms.ListBox
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItem_Up As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem_Down As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LB_Remark4 As System.Windows.Forms.Label
    Friend WithEvents LB_Remark5 As System.Windows.Forms.Label
    Friend WithEvents LB_Remark7 As System.Windows.Forms.Label
    Friend WithEvents LB_Remark2 As System.Windows.Forms.Label
    Friend WithEvents LB_Remark3 As System.Windows.Forms.Label
    Friend WithEvents LB_Remark6 As System.Windows.Forms.Label
    Friend WithEvents LB_Remark1 As System.Windows.Forms.Label
    Friend WithEvents LB_Remark8 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents LabelState As System.Windows.Forms.Label
    Public WithEvents LabelBC As System.Windows.Forms.Label

End Class
