<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F15505_AtMachine_Msg
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F15505_AtMachine_Msg))
        Me.Tool_Top = New System.Windows.Forms.ToolStrip
        Me.Cmd_Modify = New System.Windows.Forms.ToolStripButton
        Me.Cmd_Del = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.Cmd_DataIn = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.Cmd_GetCard = New System.Windows.Forms.ToolStripButton
        Me.Cmd_ClearCards = New System.Windows.Forms.ToolStripButton
        Me.Cmd_ClearLog = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.Cmd_GetTime = New System.Windows.Forms.ToolStripButton
        Me.Cmd_SetTime = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.Cmd_Exit = New System.Windows.Forms.ToolStripButton
        Me.PanelMain = New System.Windows.Forms.Panel
        Me.GB_List = New System.Windows.Forms.GroupBox
        Me.Fg1 = New PClass.FG
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.TB_Remark = New System.Windows.Forms.TextBox
        Me.TB_Port = New System.Windows.Forms.TextBox
        Me.TB_IP = New System.Windows.Forms.TextBox
        Me.TB_Name = New System.Windows.Forms.TextBox
        Me.TB_ID = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.DP_Found_Date = New System.Windows.Forms.DateTimePicker
        Me.DP_UPD_DATE = New System.Windows.Forms.DateTimePicker
        Me.TB_Founder = New System.Windows.Forms.TextBox
        Me.TB_UPD_USER = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.BW = New System.ComponentModel.BackgroundWorker
        Me.LabelMsg = New System.Windows.Forms.Label
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.Pic_From = New System.Windows.Forms.Panel
        Me.Cmd_ClearAdmin = New System.Windows.Forms.ToolStripButton
        Me.Tool_Top.SuspendLayout()
        Me.PanelMain.SuspendLayout()
        Me.GB_List.SuspendLayout()
        CType(Me.Fg1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pic_From.SuspendLayout()
        Me.SuspendLayout()
        '
        'Tool_Top
        '
        Me.Tool_Top.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.Tool_Top.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Cmd_Modify, Me.Cmd_Del, Me.ToolStripSeparator1, Me.Cmd_DataIn, Me.ToolStripSeparator3, Me.Cmd_GetCard, Me.Cmd_ClearAdmin, Me.Cmd_ClearCards, Me.Cmd_ClearLog, Me.ToolStripSeparator5, Me.Cmd_GetTime, Me.Cmd_SetTime, Me.ToolStripSeparator2, Me.Cmd_Exit})
        Me.Tool_Top.Location = New System.Drawing.Point(0, 0)
        Me.Tool_Top.MinimumSize = New System.Drawing.Size(0, 58)
        Me.Tool_Top.Name = "Tool_Top"
        Me.Tool_Top.Size = New System.Drawing.Size(582, 58)
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
        Me.Cmd_Modify.Size = New System.Drawing.Size(36, 55)
        Me.Cmd_Modify.Text = "保存"
        Me.Cmd_Modify.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'Cmd_Del
        '
        Me.Cmd_Del.AccessibleDescription = "修改按钮"
        Me.Cmd_Del.AccessibleName = ""
        Me.Cmd_Del.Image = Global.DN155_AtMachine.My.Resources.Resources.Delete
        Me.Cmd_Del.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Del.Name = "Cmd_Del"
        Me.Cmd_Del.Size = New System.Drawing.Size(36, 55)
        Me.Cmd_Del.Text = "删除"
        Me.Cmd_Del.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 58)
        '
        'Cmd_DataIn
        '
        Me.Cmd_DataIn.Image = CType(resources.GetObject("Cmd_DataIn.Image"), System.Drawing.Image)
        Me.Cmd_DataIn.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_DataIn.Name = "Cmd_DataIn"
        Me.Cmd_DataIn.Size = New System.Drawing.Size(60, 55)
        Me.Cmd_DataIn.Text = "数据采集"
        Me.Cmd_DataIn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 58)
        '
        'Cmd_GetCard
        '
        Me.Cmd_GetCard.Image = Global.DN155_AtMachine.My.Resources.Resources._10300
        Me.Cmd_GetCard.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_GetCard.Name = "Cmd_GetCard"
        Me.Cmd_GetCard.Size = New System.Drawing.Size(72, 55)
        Me.Cmd_GetCard.Text = "获取白名单"
        Me.Cmd_GetCard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'Cmd_ClearCards
        '
        Me.Cmd_ClearCards.Image = Global.DN155_AtMachine.My.Resources.Resources._10350
        Me.Cmd_ClearCards.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_ClearCards.Name = "Cmd_ClearCards"
        Me.Cmd_ClearCards.Size = New System.Drawing.Size(84, 55)
        Me.Cmd_ClearCards.Text = "删除所有名单"
        Me.Cmd_ClearCards.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'Cmd_ClearLog
        '
        Me.Cmd_ClearLog.Image = Global.DN155_AtMachine.My.Resources.Resources._83
        Me.Cmd_ClearLog.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_ClearLog.Name = "Cmd_ClearLog"
        Me.Cmd_ClearLog.Size = New System.Drawing.Size(84, 55)
        Me.Cmd_ClearLog.Text = "删除打卡记录"
        Me.Cmd_ClearLog.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 58)
        '
        'Cmd_GetTime
        '
        Me.Cmd_GetTime.Image = Global.DN155_AtMachine.My.Resources.Resources.Time
        Me.Cmd_GetTime.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_GetTime.Name = "Cmd_GetTime"
        Me.Cmd_GetTime.Size = New System.Drawing.Size(60, 55)
        Me.Cmd_GetTime.Text = "获取时间"
        Me.Cmd_GetTime.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'Cmd_SetTime
        '
        Me.Cmd_SetTime.Image = Global.DN155_AtMachine.My.Resources.Resources.Time2
        Me.Cmd_SetTime.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_SetTime.Name = "Cmd_SetTime"
        Me.Cmd_SetTime.Size = New System.Drawing.Size(60, 45)
        Me.Cmd_SetTime.Text = "设置时间"
        Me.Cmd_SetTime.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 58)
        '
        'Cmd_Exit
        '
        Me.Cmd_Exit.Image = Global.DN155_AtMachine.My.Resources.Resources.Close
        Me.Cmd_Exit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(36, 45)
        Me.Cmd_Exit.Text = "关闭"
        Me.Cmd_Exit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'PanelMain
        '
        Me.PanelMain.Controls.Add(Me.GB_List)
        Me.PanelMain.Controls.Add(Me.Label7)
        Me.PanelMain.Controls.Add(Me.Label9)
        Me.PanelMain.Controls.Add(Me.TB_Remark)
        Me.PanelMain.Controls.Add(Me.TB_Port)
        Me.PanelMain.Controls.Add(Me.TB_IP)
        Me.PanelMain.Controls.Add(Me.TB_Name)
        Me.PanelMain.Controls.Add(Me.TB_ID)
        Me.PanelMain.Controls.Add(Me.Label10)
        Me.PanelMain.Controls.Add(Me.Label11)
        Me.PanelMain.Controls.Add(Me.Label12)
        Me.PanelMain.Controls.Add(Me.Label13)
        Me.PanelMain.Controls.Add(Me.DP_Found_Date)
        Me.PanelMain.Controls.Add(Me.DP_UPD_DATE)
        Me.PanelMain.Controls.Add(Me.TB_Founder)
        Me.PanelMain.Controls.Add(Me.TB_UPD_USER)
        Me.PanelMain.Controls.Add(Me.Label6)
        Me.PanelMain.Controls.Add(Me.Label23)
        Me.PanelMain.Controls.Add(Me.Label5)
        Me.PanelMain.Controls.Add(Me.Label22)
        Me.PanelMain.Controls.Add(Me.Label3)
        Me.PanelMain.Controls.Add(Me.Label21)
        Me.PanelMain.Controls.Add(Me.Label2)
        Me.PanelMain.Controls.Add(Me.Label18)
        Me.PanelMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelMain.Location = New System.Drawing.Point(0, 58)
        Me.PanelMain.Name = "PanelMain"
        Me.PanelMain.Padding = New System.Windows.Forms.Padding(2)
        Me.PanelMain.Size = New System.Drawing.Size(582, 561)
        Me.PanelMain.TabIndex = 0
        '
        'GB_List
        '
        Me.GB_List.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GB_List.Controls.Add(Me.Fg1)
        Me.GB_List.Controls.Add(Me.Label1)
        Me.GB_List.Location = New System.Drawing.Point(5, 134)
        Me.GB_List.Name = "GB_List"
        Me.GB_List.Size = New System.Drawing.Size(572, 344)
        Me.GB_List.TabIndex = 29
        Me.GB_List.TabStop = False
        Me.GB_List.Text = "白名单"
        '
        'Fg1
        '
        Me.Fg1.AddCopyMenu = False
        Me.Fg1.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.Rows
        Me.Fg1.AllowEditing = False
        Me.Fg1.AutoAddIndex = True
        Me.Fg1.AutoGenerateColumns = False
        Me.Fg1.AutoResize = False
        Me.Fg1.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.Fg1.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.XpThemes
        Me.Fg1.CanEditing = False
        Me.Fg1.CheckKeyPressEdit = True
        Me.Fg1.ColumnInfo = resources.GetString("Fg1.ColumnInfo")
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
        Me.Fg1.Location = New System.Drawing.Point(3, 19)
        Me.Fg1.Name = "Fg1"
        Me.Fg1.NoShowMenu = False
        Me.Fg1.Rows.Count = 10
        Me.Fg1.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.RowRange
        Me.Fg1.Size = New System.Drawing.Size(566, 322)
        Me.Fg1.StartCol = ""
        Me.Fg1.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("Fg1.Styles"))
        Me.Fg1.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.BelowData
        Me.Fg1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(204, 247)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 14)
        Me.Label1.TabIndex = 9
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label7.Location = New System.Drawing.Point(236, 32)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(47, 12)
        Me.Label7.TabIndex = 28
        Me.Label7.Text = "(1-255)"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label9.Location = New System.Drawing.Point(76, 104)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(48, 16)
        Me.Label9.TabIndex = 27
        Me.Label9.Text = "备注:"
        '
        'TB_Remark
        '
        Me.TB_Remark.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TB_Remark.Location = New System.Drawing.Point(130, 101)
        Me.TB_Remark.Margin = New System.Windows.Forms.Padding(4)
        Me.TB_Remark.Name = "TB_Remark"
        Me.TB_Remark.Size = New System.Drawing.Size(405, 26)
        Me.TB_Remark.TabIndex = 26
        '
        'TB_Port
        '
        Me.TB_Port.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TB_Port.Location = New System.Drawing.Point(382, 63)
        Me.TB_Port.Margin = New System.Windows.Forms.Padding(4)
        Me.TB_Port.Name = "TB_Port"
        Me.TB_Port.Size = New System.Drawing.Size(153, 26)
        Me.TB_Port.TabIndex = 25
        '
        'TB_IP
        '
        Me.TB_IP.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TB_IP.Location = New System.Drawing.Point(130, 63)
        Me.TB_IP.Margin = New System.Windows.Forms.Padding(4)
        Me.TB_IP.Name = "TB_IP"
        Me.TB_IP.Size = New System.Drawing.Size(151, 26)
        Me.TB_IP.TabIndex = 24
        '
        'TB_Name
        '
        Me.TB_Name.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TB_Name.Location = New System.Drawing.Point(382, 25)
        Me.TB_Name.Margin = New System.Windows.Forms.Padding(4)
        Me.TB_Name.Name = "TB_Name"
        Me.TB_Name.Size = New System.Drawing.Size(153, 26)
        Me.TB_Name.TabIndex = 23
        '
        'TB_ID
        '
        Me.TB_ID.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TB_ID.Location = New System.Drawing.Point(130, 25)
        Me.TB_ID.Margin = New System.Windows.Forms.Padding(4)
        Me.TB_ID.Name = "TB_ID"
        Me.TB_ID.Size = New System.Drawing.Size(97, 26)
        Me.TB_ID.TabIndex = 22
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label10.Location = New System.Drawing.Point(294, 66)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(80, 16)
        Me.Label10.TabIndex = 21
        Me.Label10.Text = "通信端口:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label11.Location = New System.Drawing.Point(60, 66)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(64, 16)
        Me.Label11.TabIndex = 20
        Me.Label11.Text = "通信IP:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label12.Location = New System.Drawing.Point(294, 28)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(80, 16)
        Me.Label12.TabIndex = 19
        Me.Label12.Text = "考勤机名:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label13.Location = New System.Drawing.Point(44, 28)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(80, 16)
        Me.Label13.TabIndex = 18
        Me.Label13.Text = "考勤机号:"
        '
        'DP_Found_Date
        '
        Me.DP_Found_Date.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DP_Found_Date.Location = New System.Drawing.Point(386, 534)
        Me.DP_Found_Date.Name = "DP_Found_Date"
        Me.DP_Found_Date.Size = New System.Drawing.Size(151, 23)
        Me.DP_Found_Date.TabIndex = 17
        '
        'DP_UPD_DATE
        '
        Me.DP_UPD_DATE.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DP_UPD_DATE.Location = New System.Drawing.Point(386, 500)
        Me.DP_UPD_DATE.Name = "DP_UPD_DATE"
        Me.DP_UPD_DATE.Size = New System.Drawing.Size(151, 23)
        Me.DP_UPD_DATE.TabIndex = 16
        '
        'TB_Founder
        '
        Me.TB_Founder.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TB_Founder.Location = New System.Drawing.Point(132, 535)
        Me.TB_Founder.Name = "TB_Founder"
        Me.TB_Founder.ReadOnly = True
        Me.TB_Founder.Size = New System.Drawing.Size(151, 23)
        Me.TB_Founder.TabIndex = 15
        '
        'TB_UPD_USER
        '
        Me.TB_UPD_USER.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TB_UPD_USER.Location = New System.Drawing.Point(132, 500)
        Me.TB_UPD_USER.Name = "TB_UPD_USER"
        Me.TB_UPD_USER.ReadOnly = True
        Me.TB_UPD_USER.Size = New System.Drawing.Size(151, 23)
        Me.TB_UPD_USER.TabIndex = 14
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(310, 538)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(70, 14)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "创建时间:"
        '
        'Label23
        '
        Me.Label23.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(289, 502)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(98, 14)
        Me.Label23.TabIndex = 7
        Me.Label23.Text = "最后修改时间:"
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(70, 538)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 14)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "创建人:"
        '
        'Label22
        '
        Me.Label22.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(42, 503)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(84, 14)
        Me.Label22.TabIndex = 6
        Me.Label22.Text = "最后修改人:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(209, 382)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(0, 14)
        Me.Label3.TabIndex = 9
        '
        'Label21
        '
        Me.Label21.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(210, 543)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(0, 14)
        Me.Label21.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(210, 546)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(0, 14)
        Me.Label2.TabIndex = 9
        '
        'Label18
        '
        Me.Label18.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(210, 508)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(0, 14)
        Me.Label18.TabIndex = 9
        '
        'BW
        '
        Me.BW.WorkerReportsProgress = True
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
        Me.Pic_From.Size = New System.Drawing.Size(582, 619)
        Me.Pic_From.TabIndex = 11
        '
        'Cmd_ClearAdmin
        '
        Me.Cmd_ClearAdmin.Image = Global.DN155_AtMachine.My.Resources.Resources._10350
        Me.Cmd_ClearAdmin.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_ClearAdmin.Name = "Cmd_ClearAdmin"
        Me.Cmd_ClearAdmin.Size = New System.Drawing.Size(72, 55)
        Me.Cmd_ClearAdmin.Text = "清除管理员"
        Me.Cmd_ClearAdmin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'F15505_AtMachine_Msg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.PanelMain)
        Me.Controls.Add(Me.Tool_Top)
        Me.Controls.Add(Me.Pic_From)
        Me.Name = "F15505_AtMachine_Msg"
        Me.Size = New System.Drawing.Size(582, 619)
        Me.Title = "机具详细信息"
        Me.Tool_Top.ResumeLayout(False)
        Me.Tool_Top.PerformLayout()
        Me.PanelMain.ResumeLayout(False)
        Me.PanelMain.PerformLayout()
        Me.GB_List.ResumeLayout(False)
        Me.GB_List.PerformLayout()
        CType(Me.Fg1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pic_From.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Tool_Top As System.Windows.Forms.ToolStrip
    Friend WithEvents Cmd_Modify As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_Del As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Cmd_Exit As System.Windows.Forms.ToolStripButton
    Friend WithEvents PanelMain As System.Windows.Forms.Panel
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents TB_UPD_USER As System.Windows.Forms.TextBox
    Friend WithEvents TB_Founder As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DP_UPD_DATE As System.Windows.Forms.DateTimePicker
    Friend WithEvents DP_Found_Date As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TB_Remark As System.Windows.Forms.TextBox
    Friend WithEvents TB_Port As System.Windows.Forms.TextBox
    Friend WithEvents TB_IP As System.Windows.Forms.TextBox
    Friend WithEvents TB_Name As System.Windows.Forms.TextBox
    Friend WithEvents TB_ID As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Cmd_DataIn As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_GetTime As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_SetTime As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BW As System.ComponentModel.BackgroundWorker
    Friend WithEvents LabelMsg As System.Windows.Forms.Label
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents Pic_From As System.Windows.Forms.Panel
    Friend WithEvents GB_List As System.Windows.Forms.GroupBox
    Friend WithEvents Fg1 As PClass.FG
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Cmd_GetCard As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_ClearCards As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Cmd_ClearLog As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_ClearAdmin As System.Windows.Forms.ToolStripButton

End Class
