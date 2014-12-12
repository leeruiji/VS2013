Imports BaseClass

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F30105_PG_Msg
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F30105_PG_Msg))
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.TB_ClientID = New System.Windows.Forms.TextBox
        Me.Tool_Top = New System.Windows.Forms.ToolStrip
        Me.Cmd_Modify = New System.Windows.Forms.ToolStripButton
        Me.Cmd_Mod = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.Cmd_Preview = New System.Windows.Forms.ToolStripButton
        Me.Cmd_Print = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.Cmd_Exit = New System.Windows.Forms.ToolStripButton
        Me.Label15 = New System.Windows.Forms.Label
        Me.LB_State = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.LabelTitle = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.FLP_Title = New System.Windows.Forms.FlowLayoutPanel
        Me.Process1 = New System.Diagnostics.Process
        Me.GB_Header = New System.Windows.Forms.GroupBox
        Me.GB = New System.Windows.Forms.GroupBox
        Me.LB_OrderBill = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.TB_Contract = New System.Windows.Forms.TextBox
        Me.DP_Date_KaiDan = New System.Windows.Forms.DateTimePicker
        Me.Label13 = New System.Windows.Forms.Label
        Me.TB_BZC = New System.Windows.Forms.TextBox
        Me.TB_BZ = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.TB_ClientName = New System.Windows.Forms.TextBox
        Me.Label39 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.DP_JGSJ = New System.Windows.Forms.DateTimePicker
        Me.DP_CGSJ = New System.Windows.Forms.DateTimePicker
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.TB_RGBH = New System.Windows.Forms.TextBox
        Me.LB_No = New System.Windows.Forms.Label
        Me.TB_ID = New System.Windows.Forms.TextBox
        Me.Employee_List1 = New BaseClass.Employee_List
        Me.ToolStripSearch1 = New BaseClass.ToolStripSearch
        Me.Tool_Top.SuspendLayout()
        Me.FLP_Title.SuspendLayout()
        Me.GB_Header.SuspendLayout()
        Me.GB.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TB_ClientID
        '
        Me.TB_ClientID.Location = New System.Drawing.Point(571, 6)
        Me.TB_ClientID.Name = "TB_ClientID"
        Me.TB_ClientID.ReadOnly = True
        Me.TB_ClientID.Size = New System.Drawing.Size(125, 23)
        Me.TB_ClientID.TabIndex = 14
        Me.TB_ClientID.Visible = False
        '
        'Tool_Top
        '
        Me.Tool_Top.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.Tool_Top.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Cmd_Modify, Me.Cmd_Mod, Me.ToolStripSeparator5, Me.Cmd_Preview, Me.Cmd_Print, Me.ToolStripSeparator1, Me.ToolStripSeparator4, Me.Cmd_Exit})
        Me.Tool_Top.Location = New System.Drawing.Point(0, 0)
        Me.Tool_Top.MinimumSize = New System.Drawing.Size(0, 40)
        Me.Tool_Top.Name = "Tool_Top"
        Me.Tool_Top.Size = New System.Drawing.Size(720, 40)
        Me.Tool_Top.TabIndex = 45
        Me.Tool_Top.Text = "ToolStrip2"
        '
        'Cmd_Modify
        '
        Me.Cmd_Modify.AccessibleDescription = "修改按钮"
        Me.Cmd_Modify.AccessibleName = ""
        Me.Cmd_Modify.Image = Global.DN300_Produce.My.Resources.Resources.save
        Me.Cmd_Modify.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Modify.Name = "Cmd_Modify"
        Me.Cmd_Modify.Size = New System.Drawing.Size(57, 37)
        Me.Cmd_Modify.Text = "保存"
        '
        'Cmd_Mod
        '
        Me.Cmd_Mod.AccessibleDescription = "修改按钮"
        Me.Cmd_Mod.AccessibleName = ""
        Me.Cmd_Mod.Image = CType(resources.GetObject("Cmd_Mod.Image"), System.Drawing.Image)
        Me.Cmd_Mod.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Mod.Name = "Cmd_Mod"
        Me.Cmd_Mod.Size = New System.Drawing.Size(57, 37)
        Me.Cmd_Mod.Text = "修改"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 40)
        '
        'Cmd_Preview
        '
        Me.Cmd_Preview.Enabled = False
        Me.Cmd_Preview.Image = CType(resources.GetObject("Cmd_Preview.Image"), System.Drawing.Image)
        Me.Cmd_Preview.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Preview.Name = "Cmd_Preview"
        Me.Cmd_Preview.Size = New System.Drawing.Size(57, 37)
        Me.Cmd_Preview.Text = "预览"
        Me.Cmd_Preview.Visible = False
        '
        'Cmd_Print
        '
        Me.Cmd_Print.Enabled = False
        Me.Cmd_Print.Image = CType(resources.GetObject("Cmd_Print.Image"), System.Drawing.Image)
        Me.Cmd_Print.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Print.Name = "Cmd_Print"
        Me.Cmd_Print.Size = New System.Drawing.Size(57, 37)
        Me.Cmd_Print.Text = "打印"
        Me.Cmd_Print.Visible = False
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 40)
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 40)
        '
        'Cmd_Exit
        '
        Me.Cmd_Exit.Image = CType(resources.GetObject("Cmd_Exit.Image"), System.Drawing.Image)
        Me.Cmd_Exit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(57, 37)
        Me.Cmd_Exit.Text = "关闭"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("宋体", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label15.Location = New System.Drawing.Point(88, 17)
        Me.Label15.Margin = New System.Windows.Forms.Padding(3, 5, 3, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(67, 19)
        Me.Label15.TabIndex = 32
        Me.Label15.Text = "状 态:"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LB_State
        '
        Me.LB_State.AutoSize = True
        Me.LB_State.Font = New System.Drawing.Font("宋体", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LB_State.Location = New System.Drawing.Point(161, 15)
        Me.LB_State.Name = "LB_State"
        Me.LB_State.Size = New System.Drawing.Size(0, 21)
        Me.LB_State.TabIndex = 27
        '
        'Label25
        '
        Me.Label25.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label25.BackColor = System.Drawing.Color.Blue
        Me.Label25.Location = New System.Drawing.Point(-1, 82)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(719, 3)
        Me.Label25.TabIndex = 1
        '
        'LabelTitle
        '
        Me.LabelTitle.AutoSize = True
        Me.LabelTitle.Font = New System.Drawing.Font("黑体", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LabelTitle.ForeColor = System.Drawing.Color.Blue
        Me.LabelTitle.Location = New System.Drawing.Point(8, 16)
        Me.LabelTitle.Margin = New System.Windows.Forms.Padding(8, 5, 8, 0)
        Me.LabelTitle.Name = "LabelTitle"
        Me.LabelTitle.Size = New System.Drawing.Size(69, 20)
        Me.LabelTitle.TabIndex = 53
        Me.LabelTitle.Text = "排缸单"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(481, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 14)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "客户编号:"
        Me.Label1.Visible = False
        '
        'FLP_Title
        '
        Me.FLP_Title.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FLP_Title.Controls.Add(Me.LabelTitle)
        Me.FLP_Title.Controls.Add(Me.Label15)
        Me.FLP_Title.Controls.Add(Me.LB_State)
        Me.FLP_Title.FlowDirection = System.Windows.Forms.FlowDirection.BottomUp
        Me.FLP_Title.Location = New System.Drawing.Point(2, 43)
        Me.FLP_Title.Name = "FLP_Title"
        Me.FLP_Title.Size = New System.Drawing.Size(498, 36)
        Me.FLP_Title.TabIndex = 79
        '
        'Process1
        '
        Me.Process1.StartInfo.Domain = ""
        Me.Process1.StartInfo.LoadUserProfile = False
        Me.Process1.StartInfo.Password = Nothing
        Me.Process1.StartInfo.StandardErrorEncoding = Nothing
        Me.Process1.StartInfo.StandardOutputEncoding = Nothing
        Me.Process1.StartInfo.UserName = ""
        Me.Process1.SynchronizingObject = Me
        '
        'GB_Header
        '
        Me.GB_Header.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GB_Header.Controls.Add(Me.GB)
        Me.GB_Header.Controls.Add(Me.GroupBox3)
        Me.GB_Header.Controls.Add(Me.GroupBox2)
        Me.GB_Header.Location = New System.Drawing.Point(8, 86)
        Me.GB_Header.Name = "GB_Header"
        Me.GB_Header.Size = New System.Drawing.Size(697, 291)
        Me.GB_Header.TabIndex = 81
        Me.GB_Header.TabStop = False
        '
        'GB
        '
        Me.GB.Controls.Add(Me.LB_OrderBill)
        Me.GB.Controls.Add(Me.Label3)
        Me.GB.Controls.Add(Me.TB_Contract)
        Me.GB.Controls.Add(Me.DP_Date_KaiDan)
        Me.GB.Controls.Add(Me.Label13)
        Me.GB.Controls.Add(Me.TB_BZC)
        Me.GB.Controls.Add(Me.TB_BZ)
        Me.GB.Controls.Add(Me.Label2)
        Me.GB.Location = New System.Drawing.Point(333, 9)
        Me.GB.Name = "GB"
        Me.GB.Size = New System.Drawing.Size(355, 226)
        Me.GB.TabIndex = 64
        Me.GB.TabStop = False
        Me.GB.Text = "订单信息"
        '
        'LB_OrderBill
        '
        Me.LB_OrderBill.AutoSize = True
        Me.LB_OrderBill.Location = New System.Drawing.Point(34, 29)
        Me.LB_OrderBill.Name = "LB_OrderBill"
        Me.LB_OrderBill.Size = New System.Drawing.Size(56, 14)
        Me.LB_OrderBill.TabIndex = 51
        Me.LB_OrderBill.Text = "订单号:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(33, 153)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 14)
        Me.Label3.TabIndex = 63
        Me.Label3.Text = "颜  色:"
        '
        'TB_Contract
        '
        Me.TB_Contract.Location = New System.Drawing.Point(103, 26)
        Me.TB_Contract.Name = "TB_Contract"
        Me.TB_Contract.ReadOnly = True
        Me.TB_Contract.Size = New System.Drawing.Size(240, 23)
        Me.TB_Contract.TabIndex = 3
        '
        'DP_Date_KaiDan
        '
        Me.DP_Date_KaiDan.CustomFormat = "yyyy年MM月dd日"
        Me.DP_Date_KaiDan.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DP_Date_KaiDan.Location = New System.Drawing.Point(103, 64)
        Me.DP_Date_KaiDan.Name = "DP_Date_KaiDan"
        Me.DP_Date_KaiDan.Size = New System.Drawing.Size(197, 23)
        Me.DP_Date_KaiDan.TabIndex = 14
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(27, 68)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(70, 14)
        Me.Label13.TabIndex = 21
        Me.Label13.Text = "开单时间:"
        '
        'TB_BZC
        '
        Me.TB_BZC.Location = New System.Drawing.Point(103, 150)
        Me.TB_BZC.Name = "TB_BZC"
        Me.TB_BZC.ReadOnly = True
        Me.TB_BZC.Size = New System.Drawing.Size(240, 23)
        Me.TB_BZC.TabIndex = 62
        '
        'TB_BZ
        '
        Me.TB_BZ.Location = New System.Drawing.Point(103, 108)
        Me.TB_BZ.Name = "TB_BZ"
        Me.TB_BZ.ReadOnly = True
        Me.TB_BZ.Size = New System.Drawing.Size(240, 23)
        Me.TB_BZ.TabIndex = 60
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(33, 111)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 14)
        Me.Label2.TabIndex = 61
        Me.Label2.Text = "布  类:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.TB_ClientName)
        Me.GroupBox3.Controls.Add(Me.Label39)
        Me.GroupBox3.Location = New System.Drawing.Point(19, 6)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(293, 57)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "客户"
        '
        'TB_ClientName
        '
        Me.TB_ClientName.Font = New System.Drawing.Font("宋体", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TB_ClientName.Location = New System.Drawing.Point(92, 11)
        Me.TB_ClientName.Multiline = True
        Me.TB_ClientName.Name = "TB_ClientName"
        Me.TB_ClientName.ReadOnly = True
        Me.TB_ClientName.Size = New System.Drawing.Size(195, 44)
        Me.TB_ClientName.TabIndex = 17
        Me.TB_ClientName.TabStop = False
        Me.TB_ClientName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Location = New System.Drawing.Point(20, 19)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(63, 14)
        Me.Label39.TabIndex = 23
        Me.Label39.Text = "客   户:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.DP_JGSJ)
        Me.GroupBox2.Controls.Add(Me.DP_CGSJ)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.TB_RGBH)
        Me.GroupBox2.Location = New System.Drawing.Point(19, 67)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(293, 193)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "排缸信息"
        '
        'DP_JGSJ
        '
        Me.DP_JGSJ.Checked = False
        Me.DP_JGSJ.CustomFormat = "yyyy年MM月dd日HH:mm"
        Me.DP_JGSJ.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DP_JGSJ.Location = New System.Drawing.Point(83, 77)
        Me.DP_JGSJ.Name = "DP_JGSJ"
        Me.DP_JGSJ.ShowCheckBox = True
        Me.DP_JGSJ.Size = New System.Drawing.Size(204, 23)
        Me.DP_JGSJ.TabIndex = 56
        '
        'DP_CGSJ
        '
        Me.DP_CGSJ.Checked = False
        Me.DP_CGSJ.CustomFormat = "yyyy年MM月dd日HH:mm"
        Me.DP_CGSJ.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DP_CGSJ.Location = New System.Drawing.Point(83, 110)
        Me.DP_CGSJ.Name = "DP_CGSJ"
        Me.DP_CGSJ.ShowCheckBox = True
        Me.DP_CGSJ.Size = New System.Drawing.Size(204, 23)
        Me.DP_CGSJ.TabIndex = 57
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(11, 114)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(70, 14)
        Me.Label8.TabIndex = 54
        Me.Label8.Text = "出缸时间:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(11, 81)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(70, 14)
        Me.Label10.TabIndex = 55
        Me.Label10.Text = "入缸时间:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(11, 41)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(70, 14)
        Me.Label6.TabIndex = 53
        Me.Label6.Text = "染缸编号:"
        '
        'TB_RGBH
        '
        Me.TB_RGBH.Location = New System.Drawing.Point(83, 35)
        Me.TB_RGBH.Name = "TB_RGBH"
        Me.TB_RGBH.Size = New System.Drawing.Size(150, 23)
        Me.TB_RGBH.TabIndex = 52
        Me.TB_RGBH.TabStop = False
        '
        'LB_No
        '
        Me.LB_No.AutoSize = True
        Me.LB_No.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LB_No.ForeColor = System.Drawing.Color.Blue
        Me.LB_No.Location = New System.Drawing.Point(520, 61)
        Me.LB_No.Margin = New System.Windows.Forms.Padding(3, 8, 3, 0)
        Me.LB_No.Name = "LB_No"
        Me.LB_No.Size = New System.Drawing.Size(56, 16)
        Me.LB_No.TabIndex = 31
        Me.LB_No.Text = "缸 号:"
        '
        'TB_ID
        '
        Me.TB_ID.Location = New System.Drawing.Point(582, 56)
        Me.TB_ID.Name = "TB_ID"
        Me.TB_ID.ReadOnly = True
        Me.TB_ID.Size = New System.Drawing.Size(122, 23)
        Me.TB_ID.TabIndex = 1
        '
        'Employee_List1
        '
        Me.Employee_List1.BackColor = System.Drawing.Color.DodgerBlue
        Me.Employee_List1.IsShowAll = True
        Me.Employee_List1.IsTBLostFocusSelOne = True
        Me.Employee_List1.Location = New System.Drawing.Point(-454, -108)
        Me.Employee_List1.Name = "Employee_List1"
        Me.Employee_List1.SearchId = ""
        Me.Employee_List1.SearchType = BaseClass.Employee_List.ENum_SearchType.ALL
        Me.Employee_List1.Size = New System.Drawing.Size(157, 131)
        Me.Employee_List1.TabIndex = 51
        Me.Employee_List1.Visible = False
        '
        'ToolStripSearch1
        '
        Me.ToolStripSearch1.HideItemOnToolStrip = False
        Me.ToolStripSearch1.IsAddSearchBottom = True
        Me.ToolStripSearch1.IsNameChangeToData = False
        Me.ToolStripSearch1.ToolStrip = Nothing
        '
        'F30009_PG_Msg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.AutoSize = True
        Me.CanMaxSize = True
        Me.Controls.Add(Me.Employee_List1)
        Me.Controls.Add(Me.Tool_Top)
        Me.Controls.Add(Me.TB_ID)
        Me.Controls.Add(Me.LB_No)
        Me.Controls.Add(Me.GB_Header)
        Me.Controls.Add(Me.FLP_Title)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.TB_ClientID)
        Me.Controls.Add(Me.Label1)
        Me.Name = "F30009_PG_Msg"
        Me.Size = New System.Drawing.Size(720, 392)
        Me.Title = "排缸单"
        Me.Tool_Top.ResumeLayout(False)
        Me.Tool_Top.PerformLayout()
        Me.FLP_Title.ResumeLayout(False)
        Me.FLP_Title.PerformLayout()
        Me.GB_Header.ResumeLayout(False)
        Me.GB.ResumeLayout(False)
        Me.GB.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents TB_ClientID As System.Windows.Forms.TextBox
    Friend WithEvents Tool_Top As System.Windows.Forms.ToolStrip
    Friend WithEvents Cmd_Modify As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Cmd_Exit As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_Preview As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_Print As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Employee_List1 As BaseClass.Employee_List
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents LB_State As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents LabelTitle As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents FLP_Title As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Process1 As System.Diagnostics.Process
    Friend WithEvents ToolStripSearch1 As BaseClass.ToolStripSearch
    Friend WithEvents GB_Header As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents TB_ClientName As System.Windows.Forms.TextBox
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents LB_OrderBill As System.Windows.Forms.Label
    Friend WithEvents DP_Date_KaiDan As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TB_Contract As System.Windows.Forms.TextBox
    Friend WithEvents TB_RGBH As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents DP_JGSJ As System.Windows.Forms.DateTimePicker
    Friend WithEvents DP_CGSJ As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TB_BZC As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TB_BZ As System.Windows.Forms.TextBox
    Friend WithEvents GB As System.Windows.Forms.GroupBox
    Friend WithEvents Cmd_Mod As System.Windows.Forms.ToolStripButton
    Friend WithEvents TB_ID As System.Windows.Forms.TextBox
    Friend WithEvents LB_No As System.Windows.Forms.Label

End Class
