<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F40311_CPIni_Msg
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F40311_CPIni_Msg))
        Me.Tool_Top = New System.Windows.Forms.ToolStrip
        Me.Cmd_Modify = New System.Windows.Forms.ToolStripButton
        Me.Cmd_Del = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.Btn_AddRow = New System.Windows.Forms.ToolStripButton
        Me.Btn_RemoveRow = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.Btn_Print = New System.Windows.Forms.ToolStripButton
        Me.Btn_Preview = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.Cmd_SetInValid = New System.Windows.Forms.ToolStripButton
        Me.Cmd_SetValid = New System.Windows.Forms.ToolStripButton
        Me.Cmd_UnAudit = New System.Windows.Forms.ToolStripButton
        Me.Cmd_Audit = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.Cmd_Exit = New System.Windows.Forms.ToolStripButton
        Me.PanelMain = New System.Windows.Forms.Panel
        Me.DP_RKDate = New System.Windows.Forms.DateTimePicker
        Me.Label21 = New System.Windows.Forms.Label
        Me.TB_GH = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.CB_Client = New BaseClass.ComBoList
        Me.CB_BZC = New BaseClass.ComBoList
        Me.CB_BZ = New BaseClass.ComBoList
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.TB_BZcName = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.TB_BZName = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.TB_ClientName = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Panel_All = New System.Windows.Forms.Panel
        Me.LB_AllQty = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.ToolStrip_StoreNo_Old = New System.Windows.Forms.ToolStrip
        Me.Cmd_StoreNo = New System.Windows.Forms.ToolStripButton
        Me.TB_StoreNo = New System.Windows.Forms.ToolStripTextBox
        Me.CB_Color = New System.Windows.Forms.ComboBox
        Me.CB_StoreNo = New System.Windows.Forms.ComboBox
        Me.LabelState = New System.Windows.Forms.Label
        Me.LabelStateT = New System.Windows.Forms.Label
        Me.TB_Remark = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.LabelTitle = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.DP_Date = New System.Windows.Forms.DateTimePicker
        Me.Label16 = New System.Windows.Forms.Label
        Me.TB_ID = New System.Windows.Forms.TextBox
        Me.Label_ID = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.GB_Foot = New System.Windows.Forms.GroupBox
        Me.CB_driver = New System.Windows.Forms.ComboBox
        Me.CB_License = New System.Windows.Forms.ComboBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.TB_XiaoZhang = New System.Windows.Forms.TextBox
        Me.TB_State_User = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.TB_ZhiDan = New System.Windows.Forms.TextBox
        Me.GB_List = New System.Windows.Forms.GroupBox
        Me.Cmd_YTS = New System.Windows.Forms.Button
        Me.Fg1 = New PClass.FG
        Me.TB_RemainZl = New System.Windows.Forms.TextBox
        Me.TB_PWeight = New System.Windows.Forms.TextBox
        Me.TB_RemainQty = New System.Windows.Forms.TextBox
        Me.TB_SumQty = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Tool_Top.SuspendLayout()
        Me.PanelMain.SuspendLayout()
        Me.Panel_All.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.ToolStrip_StoreNo_Old.SuspendLayout()
        Me.GB_Foot.SuspendLayout()
        Me.GB_List.SuspendLayout()
        CType(Me.Fg1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Tool_Top
        '
        Me.Tool_Top.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.Tool_Top.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Cmd_Modify, Me.Cmd_Del, Me.ToolStripSeparator2, Me.Btn_AddRow, Me.Btn_RemoveRow, Me.ToolStripSeparator5, Me.Btn_Print, Me.Btn_Preview, Me.ToolStripSeparator1, Me.Cmd_SetInValid, Me.Cmd_SetValid, Me.Cmd_UnAudit, Me.Cmd_Audit, Me.ToolStripSeparator3, Me.Cmd_Exit})
        Me.Tool_Top.Location = New System.Drawing.Point(0, 0)
        Me.Tool_Top.MinimumSize = New System.Drawing.Size(0, 45)
        Me.Tool_Top.Name = "Tool_Top"
        Me.Tool_Top.Size = New System.Drawing.Size(1146, 45)
        Me.Tool_Top.TabIndex = 10
        Me.Tool_Top.Text = "ToolStrip2"
        '
        'Cmd_Modify
        '
        Me.Cmd_Modify.AccessibleDescription = "修改按钮"
        Me.Cmd_Modify.AccessibleName = ""
        Me.Cmd_Modify.Image = Global.DN400_Store.My.Resources.Resources.Modify
        Me.Cmd_Modify.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Modify.Name = "Cmd_Modify"
        Me.Cmd_Modify.Size = New System.Drawing.Size(57, 42)
        Me.Cmd_Modify.Text = "保存"
        '
        'Cmd_Del
        '
        Me.Cmd_Del.AccessibleDescription = "修改按钮"
        Me.Cmd_Del.AccessibleName = ""
        Me.Cmd_Del.Image = Global.DN400_Store.My.Resources.Resources.Delete
        Me.Cmd_Del.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Del.Name = "Cmd_Del"
        Me.Cmd_Del.Size = New System.Drawing.Size(57, 42)
        Me.Cmd_Del.Text = "删除"
        Me.Cmd_Del.Visible = False
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 45)
        '
        'Btn_AddRow
        '
        Me.Btn_AddRow.Image = CType(resources.GetObject("Btn_AddRow.Image"), System.Drawing.Image)
        Me.Btn_AddRow.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Btn_AddRow.Name = "Btn_AddRow"
        Me.Btn_AddRow.Size = New System.Drawing.Size(57, 42)
        Me.Btn_AddRow.Text = "增行"
        '
        'Btn_RemoveRow
        '
        Me.Btn_RemoveRow.Image = Global.DN400_Store.My.Resources.Resources.Btn_RemoveRow
        Me.Btn_RemoveRow.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Btn_RemoveRow.Name = "Btn_RemoveRow"
        Me.Btn_RemoveRow.Size = New System.Drawing.Size(57, 42)
        Me.Btn_RemoveRow.Text = "减行"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 45)
        Me.ToolStripSeparator5.Visible = False
        '
        'Btn_Print
        '
        Me.Btn_Print.Image = Global.DN400_Store.My.Resources.Resources.print
        Me.Btn_Print.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Btn_Print.Name = "Btn_Print"
        Me.Btn_Print.Size = New System.Drawing.Size(57, 42)
        Me.Btn_Print.Text = "打印"
        Me.Btn_Print.Visible = False
        '
        'Btn_Preview
        '
        Me.Btn_Preview.Image = Global.DN400_Store.My.Resources.Resources.Print_preview
        Me.Btn_Preview.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Btn_Preview.Name = "Btn_Preview"
        Me.Btn_Preview.Size = New System.Drawing.Size(57, 42)
        Me.Btn_Preview.Text = "预览"
        Me.Btn_Preview.Visible = False
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 45)
        '
        'Cmd_SetInValid
        '
        Me.Cmd_SetInValid.AccessibleDescription = "作废按钮"
        Me.Cmd_SetInValid.AccessibleName = ""
        Me.Cmd_SetInValid.Image = Global.DN400_Store.My.Resources.Resources.InValid
        Me.Cmd_SetInValid.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_SetInValid.Name = "Cmd_SetInValid"
        Me.Cmd_SetInValid.Size = New System.Drawing.Size(57, 42)
        Me.Cmd_SetInValid.Text = "作废"
        Me.Cmd_SetInValid.Visible = False
        '
        'Cmd_SetValid
        '
        Me.Cmd_SetValid.AccessibleDescription = "反作废按钮"
        Me.Cmd_SetValid.AccessibleName = ""
        Me.Cmd_SetValid.Image = Global.DN400_Store.My.Resources.Resources._34
        Me.Cmd_SetValid.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_SetValid.Name = "Cmd_SetValid"
        Me.Cmd_SetValid.Size = New System.Drawing.Size(69, 42)
        Me.Cmd_SetValid.Text = "反作废"
        Me.Cmd_SetValid.Visible = False
        '
        'Cmd_UnAudit
        '
        Me.Cmd_UnAudit.Image = Global.DN400_Store.My.Resources.Resources.cancel
        Me.Cmd_UnAudit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_UnAudit.Name = "Cmd_UnAudit"
        Me.Cmd_UnAudit.Size = New System.Drawing.Size(57, 42)
        Me.Cmd_UnAudit.Text = "反审"
        Me.Cmd_UnAudit.Visible = False
        '
        'Cmd_Audit
        '
        Me.Cmd_Audit.Image = Global.DN400_Store.My.Resources.Resources.apply
        Me.Cmd_Audit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Audit.Name = "Cmd_Audit"
        Me.Cmd_Audit.Size = New System.Drawing.Size(57, 42)
        Me.Cmd_Audit.Text = "审核"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 45)
        '
        'Cmd_Exit
        '
        Me.Cmd_Exit.Image = Global.DN400_Store.My.Resources.Resources.Close
        Me.Cmd_Exit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(57, 42)
        Me.Cmd_Exit.Text = "关闭"
        '
        'PanelMain
        '
        Me.PanelMain.Controls.Add(Me.DP_RKDate)
        Me.PanelMain.Controls.Add(Me.Label21)
        Me.PanelMain.Controls.Add(Me.TB_GH)
        Me.PanelMain.Controls.Add(Me.Label7)
        Me.PanelMain.Controls.Add(Me.CB_Client)
        Me.PanelMain.Controls.Add(Me.CB_BZC)
        Me.PanelMain.Controls.Add(Me.CB_BZ)
        Me.PanelMain.Controls.Add(Me.Label19)
        Me.PanelMain.Controls.Add(Me.Label17)
        Me.PanelMain.Controls.Add(Me.Label12)
        Me.PanelMain.Controls.Add(Me.TB_BZcName)
        Me.PanelMain.Controls.Add(Me.Label15)
        Me.PanelMain.Controls.Add(Me.TB_BZName)
        Me.PanelMain.Controls.Add(Me.Label11)
        Me.PanelMain.Controls.Add(Me.TB_ClientName)
        Me.PanelMain.Controls.Add(Me.Label4)
        Me.PanelMain.Controls.Add(Me.Panel_All)
        Me.PanelMain.Controls.Add(Me.Panel1)
        Me.PanelMain.Controls.Add(Me.CB_Color)
        Me.PanelMain.Controls.Add(Me.CB_StoreNo)
        Me.PanelMain.Controls.Add(Me.LabelState)
        Me.PanelMain.Controls.Add(Me.LabelStateT)
        Me.PanelMain.Controls.Add(Me.TB_Remark)
        Me.PanelMain.Controls.Add(Me.Label5)
        Me.PanelMain.Controls.Add(Me.LabelTitle)
        Me.PanelMain.Controls.Add(Me.Label13)
        Me.PanelMain.Controls.Add(Me.DP_Date)
        Me.PanelMain.Controls.Add(Me.Label16)
        Me.PanelMain.Controls.Add(Me.TB_ID)
        Me.PanelMain.Controls.Add(Me.Label_ID)
        Me.PanelMain.Controls.Add(Me.Label1)
        Me.PanelMain.Controls.Add(Me.GB_Foot)
        Me.PanelMain.Controls.Add(Me.GB_List)
        Me.PanelMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelMain.Location = New System.Drawing.Point(0, 45)
        Me.PanelMain.Name = "PanelMain"
        Me.PanelMain.Padding = New System.Windows.Forms.Padding(2)
        Me.PanelMain.Size = New System.Drawing.Size(1146, 654)
        Me.PanelMain.TabIndex = 0
        '
        'DP_RKDate
        '
        Me.DP_RKDate.Location = New System.Drawing.Point(709, 90)
        Me.DP_RKDate.Name = "DP_RKDate"
        Me.DP_RKDate.Size = New System.Drawing.Size(124, 23)
        Me.DP_RKDate.TabIndex = 61
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(633, 93)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(70, 14)
        Me.Label21.TabIndex = 60
        Me.Label21.Text = "入库日期:"
        '
        'TB_GH
        '
        Me.TB_GH.Location = New System.Drawing.Point(481, 88)
        Me.TB_GH.Name = "TB_GH"
        Me.TB_GH.Size = New System.Drawing.Size(132, 23)
        Me.TB_GH.TabIndex = 58
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.Blue
        Me.Label7.Location = New System.Drawing.Point(433, 93)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(42, 14)
        Me.Label7.TabIndex = 59
        Me.Label7.Text = "缸号:"
        '
        'CB_Client
        '
        Me.CB_Client.Child = "ComboClient"
        Me.CB_Client.FormattingEnabled = True
        Me.CB_Client.IDAsInt = 0
        Me.CB_Client.IDValue = ""
        Me.CB_Client.IsKeyDownAutoSearch = True
        Me.CB_Client.IsSelectName = False
        Me.CB_Client.Location = New System.Drawing.Point(87, 90)
        Me.CB_Client.Name = "CB_Client"
        Me.CB_Client.SearchType = BaseClass.cSearchType.ENum_SearchType.ALL
        Me.CB_Client.Size = New System.Drawing.Size(89, 22)
        Me.CB_Client.TabIndex = 50
        '
        'CB_BZC
        '
        Me.CB_BZC.Child = "ComboBZC"
        Me.CB_BZC.FormattingEnabled = True
        Me.CB_BZC.IDAsInt = 0
        Me.CB_BZC.IDValue = ""
        Me.CB_BZC.IsKeyDownAutoSearch = True
        Me.CB_BZC.IsSelectName = False
        Me.CB_BZC.Location = New System.Drawing.Point(88, 50)
        Me.CB_BZC.Name = "CB_BZC"
        Me.CB_BZC.SearchType = BaseClass.cSearchType.ENum_SearchType.ALL
        Me.CB_BZC.Size = New System.Drawing.Size(89, 22)
        Me.CB_BZC.TabIndex = 52
        '
        'CB_BZ
        '
        Me.CB_BZ.Child = "ComboBZ"
        Me.CB_BZ.FormattingEnabled = True
        Me.CB_BZ.IDAsInt = 0
        Me.CB_BZ.IDValue = ""
        Me.CB_BZ.IsKeyDownAutoSearch = True
        Me.CB_BZ.IsSelectName = False
        Me.CB_BZ.Location = New System.Drawing.Point(492, 50)
        Me.CB_BZ.Name = "CB_BZ"
        Me.CB_BZ.SearchType = BaseClass.cSearchType.ENum_SearchType.ALL
        Me.CB_BZ.Size = New System.Drawing.Size(89, 22)
        Me.CB_BZ.TabIndex = 52
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(14, 54)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(42, 14)
        Me.Label19.TabIndex = 57
        Me.Label19.Text = "色号:"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(418, 54)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(70, 14)
        Me.Label17.TabIndex = 57
        Me.Label17.Text = "布类编号:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(13, 94)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(70, 14)
        Me.Label12.TabIndex = 56
        Me.Label12.Text = "客户编号:"
        '
        'TB_BZcName
        '
        Me.TB_BZcName.Location = New System.Drawing.Point(231, 50)
        Me.TB_BZcName.Name = "TB_BZcName"
        Me.TB_BZcName.Size = New System.Drawing.Size(149, 23)
        Me.TB_BZcName.TabIndex = 53
        Me.TB_BZcName.TabStop = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(183, 54)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(42, 14)
        Me.Label15.TabIndex = 54
        Me.Label15.Text = "颜色:"
        '
        'TB_BZName
        '
        Me.TB_BZName.Location = New System.Drawing.Point(656, 50)
        Me.TB_BZName.Name = "TB_BZName"
        Me.TB_BZName.ReadOnly = True
        Me.TB_BZName.Size = New System.Drawing.Size(149, 23)
        Me.TB_BZName.TabIndex = 53
        Me.TB_BZName.TabStop = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(587, 54)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(70, 14)
        Me.Label11.TabIndex = 54
        Me.Label11.Text = "布类名称:"
        '
        'TB_ClientName
        '
        Me.TB_ClientName.Location = New System.Drawing.Point(251, 90)
        Me.TB_ClientName.Name = "TB_ClientName"
        Me.TB_ClientName.ReadOnly = True
        Me.TB_ClientName.Size = New System.Drawing.Size(149, 23)
        Me.TB_ClientName.TabIndex = 51
        Me.TB_ClientName.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(182, 93)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 14)
        Me.Label4.TabIndex = 55
        Me.Label4.Text = "客户名称:"
        '
        'Panel_All
        '
        Me.Panel_All.Controls.Add(Me.LB_AllQty)
        Me.Panel_All.Controls.Add(Me.Label20)
        Me.Panel_All.Location = New System.Drawing.Point(599, 9)
        Me.Panel_All.Name = "Panel_All"
        Me.Panel_All.Size = New System.Drawing.Size(150, 27)
        Me.Panel_All.TabIndex = 49
        '
        'LB_AllQty
        '
        Me.LB_AllQty.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LB_AllQty.AutoSize = True
        Me.LB_AllQty.ForeColor = System.Drawing.Color.Blue
        Me.LB_AllQty.Location = New System.Drawing.Point(94, 6)
        Me.LB_AllQty.Name = "LB_AllQty"
        Me.LB_AllQty.Size = New System.Drawing.Size(0, 14)
        Me.LB_AllQty.TabIndex = 48
        '
        'Label20
        '
        Me.Label20.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(10, 7)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(84, 14)
        Me.Label20.TabIndex = 47
        Me.Label20.Text = "合计总条数:"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ToolStrip_StoreNo_Old)
        Me.Panel1.Location = New System.Drawing.Point(70, 124)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(470, 28)
        Me.Panel1.TabIndex = 10
        '
        'ToolStrip_StoreNo_Old
        '
        Me.ToolStrip_StoreNo_Old.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStrip_StoreNo_Old.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ToolStrip_StoreNo_Old.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Cmd_StoreNo, Me.TB_StoreNo})
        Me.ToolStrip_StoreNo_Old.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip_StoreNo_Old.Name = "ToolStrip_StoreNo_Old"
        Me.ToolStrip_StoreNo_Old.Size = New System.Drawing.Size(470, 28)
        Me.ToolStrip_StoreNo_Old.TabIndex = 0
        Me.ToolStrip_StoreNo_Old.Tag = "0"
        Me.ToolStrip_StoreNo_Old.Text = "ToolStrip1"
        '
        'Cmd_StoreNo
        '
        Me.Cmd_StoreNo.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Cmd_StoreNo.Image = Global.DN400_Store.My.Resources.Resources.ADD
        Me.Cmd_StoreNo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_StoreNo.Name = "Cmd_StoreNo"
        Me.Cmd_StoreNo.Size = New System.Drawing.Size(83, 25)
        Me.Cmd_StoreNo.Text = "选择仓位"
        '
        'TB_StoreNo
        '
        Me.TB_StoreNo.Name = "TB_StoreNo"
        Me.TB_StoreNo.Size = New System.Drawing.Size(50, 28)
        '
        'CB_Color
        '
        Me.CB_Color.Items.AddRange(New Object() {"白色", "浅色", "深色", "黑色"})
        Me.CB_Color.Location = New System.Drawing.Point(5, 29)
        Me.CB_Color.Name = "CB_Color"
        Me.CB_Color.Size = New System.Drawing.Size(121, 22)
        Me.CB_Color.TabIndex = 42
        Me.CB_Color.Visible = False
        '
        'CB_StoreNo
        '
        Me.CB_StoreNo.Location = New System.Drawing.Point(132, 29)
        Me.CB_StoreNo.Name = "CB_StoreNo"
        Me.CB_StoreNo.Size = New System.Drawing.Size(121, 22)
        Me.CB_StoreNo.TabIndex = 36
        Me.CB_StoreNo.Visible = False
        '
        'LabelState
        '
        Me.LabelState.AutoSize = True
        Me.LabelState.BackColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LabelState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LabelState.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LabelState.ForeColor = System.Drawing.Color.Blue
        Me.LabelState.Location = New System.Drawing.Point(291, 20)
        Me.LabelState.Name = "LabelState"
        Me.LabelState.Size = New System.Drawing.Size(37, 16)
        Me.LabelState.TabIndex = 35
        Me.LabelState.Text = "新建"
        '
        'LabelStateT
        '
        Me.LabelStateT.AutoSize = True
        Me.LabelStateT.Location = New System.Drawing.Point(243, 20)
        Me.LabelStateT.Name = "LabelStateT"
        Me.LabelStateT.Size = New System.Drawing.Size(42, 14)
        Me.LabelStateT.TabIndex = 34
        Me.LabelStateT.Text = "状态:"
        '
        'TB_Remark
        '
        Me.TB_Remark.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TB_Remark.Location = New System.Drawing.Point(657, 134)
        Me.TB_Remark.Name = "TB_Remark"
        Me.TB_Remark.Size = New System.Drawing.Size(396, 23)
        Me.TB_Remark.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(609, 138)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(42, 14)
        Me.Label5.TabIndex = 27
        Me.Label5.Text = "备注:"
        '
        'LabelTitle
        '
        Me.LabelTitle.AutoSize = True
        Me.LabelTitle.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LabelTitle.ForeColor = System.Drawing.Color.Blue
        Me.LabelTitle.Location = New System.Drawing.Point(31, 14)
        Me.LabelTitle.Name = "LabelTitle"
        Me.LabelTitle.Size = New System.Drawing.Size(127, 16)
        Me.LabelTitle.TabIndex = 22
        Me.LabelTitle.Text = "成品期初库存单"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(22, 129)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(42, 14)
        Me.Label13.TabIndex = 13
        Me.Label13.Text = "仓位:"
        '
        'DP_Date
        '
        Me.DP_Date.Location = New System.Drawing.Point(793, 11)
        Me.DP_Date.Name = "DP_Date"
        Me.DP_Date.Size = New System.Drawing.Size(124, 23)
        Me.DP_Date.TabIndex = 18
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(745, 15)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(42, 14)
        Me.Label16.TabIndex = 14
        Me.Label16.Text = "日期:"
        '
        'TB_ID
        '
        Me.TB_ID.Location = New System.Drawing.Point(995, 10)
        Me.TB_ID.Name = "TB_ID"
        Me.TB_ID.Size = New System.Drawing.Size(132, 23)
        Me.TB_ID.TabIndex = 0
        '
        'Label_ID
        '
        Me.Label_ID.AutoSize = True
        Me.Label_ID.ForeColor = System.Drawing.Color.Blue
        Me.Label_ID.Location = New System.Drawing.Point(947, 15)
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
        Me.Label1.Location = New System.Drawing.Point(-4, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(1150, 3)
        Me.Label1.TabIndex = 11
        '
        'GB_Foot
        '
        Me.GB_Foot.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GB_Foot.Controls.Add(Me.CB_driver)
        Me.GB_Foot.Controls.Add(Me.CB_License)
        Me.GB_Foot.Controls.Add(Me.Label23)
        Me.GB_Foot.Controls.Add(Me.Label22)
        Me.GB_Foot.Controls.Add(Me.TB_XiaoZhang)
        Me.GB_Foot.Controls.Add(Me.TB_State_User)
        Me.GB_Foot.Controls.Add(Me.Label10)
        Me.GB_Foot.Controls.Add(Me.Label9)
        Me.GB_Foot.Controls.Add(Me.Label8)
        Me.GB_Foot.Controls.Add(Me.TB_ZhiDan)
        Me.GB_Foot.Location = New System.Drawing.Point(5, 605)
        Me.GB_Foot.Name = "GB_Foot"
        Me.GB_Foot.Size = New System.Drawing.Size(1135, 44)
        Me.GB_Foot.TabIndex = 10
        Me.GB_Foot.TabStop = False
        '
        'CB_driver
        '
        Me.CB_driver.DisplayMember = "Remark2"
        Me.CB_driver.FormattingEnabled = True
        Me.CB_driver.Location = New System.Drawing.Point(767, 15)
        Me.CB_driver.Name = "CB_driver"
        Me.CB_driver.Size = New System.Drawing.Size(129, 22)
        Me.CB_driver.TabIndex = 19
        Me.CB_driver.ValueMember = "Remark2"
        '
        'CB_License
        '
        Me.CB_License.DisplayMember = "Remark"
        Me.CB_License.FormattingEnabled = True
        Me.CB_License.Location = New System.Drawing.Point(578, 15)
        Me.CB_License.Name = "CB_License"
        Me.CB_License.Size = New System.Drawing.Size(129, 22)
        Me.CB_License.TabIndex = 18
        Me.CB_License.ValueMember = "Remark"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(722, 19)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(42, 14)
        Me.Label23.TabIndex = 17
        Me.Label23.Text = "司机:"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(530, 19)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(42, 14)
        Me.Label22.TabIndex = 15
        Me.Label22.Text = "车牌:"
        '
        'TB_XiaoZhang
        '
        Me.TB_XiaoZhang.Location = New System.Drawing.Point(403, 15)
        Me.TB_XiaoZhang.Name = "TB_XiaoZhang"
        Me.TB_XiaoZhang.ReadOnly = True
        Me.TB_XiaoZhang.Size = New System.Drawing.Size(111, 23)
        Me.TB_XiaoZhang.TabIndex = 2
        '
        'TB_State_User
        '
        Me.TB_State_User.Location = New System.Drawing.Point(226, 15)
        Me.TB_State_User.Name = "TB_State_User"
        Me.TB_State_User.ReadOnly = True
        Me.TB_State_User.Size = New System.Drawing.Size(111, 23)
        Me.TB_State_User.TabIndex = 1
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(353, 20)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(42, 14)
        Me.Label10.TabIndex = 13
        Me.Label10.Text = "销账:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(180, 20)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(42, 14)
        Me.Label9.TabIndex = 13
        Me.Label9.Text = "审核:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(13, 19)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(42, 14)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "制单:"
        '
        'TB_ZhiDan
        '
        Me.TB_ZhiDan.Location = New System.Drawing.Point(58, 15)
        Me.TB_ZhiDan.Name = "TB_ZhiDan"
        Me.TB_ZhiDan.ReadOnly = True
        Me.TB_ZhiDan.Size = New System.Drawing.Size(111, 23)
        Me.TB_ZhiDan.TabIndex = 0
        '
        'GB_List
        '
        Me.GB_List.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GB_List.Controls.Add(Me.Cmd_YTS)
        Me.GB_List.Controls.Add(Me.Fg1)
        Me.GB_List.Controls.Add(Me.TB_RemainZl)
        Me.GB_List.Controls.Add(Me.TB_PWeight)
        Me.GB_List.Controls.Add(Me.TB_RemainQty)
        Me.GB_List.Controls.Add(Me.TB_SumQty)
        Me.GB_List.Controls.Add(Me.Label18)
        Me.GB_List.Controls.Add(Me.Label3)
        Me.GB_List.Controls.Add(Me.Label14)
        Me.GB_List.Controls.Add(Me.Label6)
        Me.GB_List.Controls.Add(Me.Label2)
        Me.GB_List.Location = New System.Drawing.Point(5, 163)
        Me.GB_List.Name = "GB_List"
        Me.GB_List.Size = New System.Drawing.Size(1136, 436)
        Me.GB_List.TabIndex = 9
        Me.GB_List.TabStop = False
        '
        'Cmd_YTS
        '
        Me.Cmd_YTS.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Cmd_YTS.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Cmd_YTS.Location = New System.Drawing.Point(6, 401)
        Me.Cmd_YTS.Name = "Cmd_YTS"
        Me.Cmd_YTS.Size = New System.Drawing.Size(109, 29)
        Me.Cmd_YTS.TabIndex = 18
        Me.Cmd_YTS.Text = "重新计算余条数"
        Me.Cmd_YTS.UseVisualStyleBackColor = True
        Me.Cmd_YTS.Visible = False
        '
        'Fg1
        '
        Me.Fg1.AddCopyMenu = False
        Me.Fg1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Fg1.AutoAddIndex = True
        Me.Fg1.AutoGenerateColumns = False
        Me.Fg1.AutoResize = False
        Me.Fg1.BackColor = System.Drawing.Color.White
        Me.Fg1.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.XpThemes
        Me.Fg1.CanEditing = True
        Me.Fg1.CheckKeyPressEdit = True
        Me.Fg1.ColumnInfo = resources.GetString("Fg1.ColumnInfo")
        Me.Fg1.EditFormat = True
        Me.Fg1.ExtendLastCol = True
        Me.Fg1.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Fg1.ForeColor = System.Drawing.Color.Black
        Me.Fg1.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.Fg1.IsAutoAddRow = True
        Me.Fg1.IsClickStartEdit = False
        Me.Fg1.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.Fg1.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.Fg1.Location = New System.Drawing.Point(0, 0)
        Me.Fg1.Name = "Fg1"
        Me.Fg1.NoShowMenu = False
        Me.Fg1.Rows.Count = 1
        Me.Fg1.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.Fg1.Size = New System.Drawing.Size(1122, 386)
        Me.Fg1.StartCol = ""
        Me.Fg1.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("Fg1.Styles"))
        Me.Fg1.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.BelowData
        Me.Fg1.TabIndex = 0
        '
        'TB_RemainZl
        '
        Me.TB_RemainZl.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TB_RemainZl.Location = New System.Drawing.Point(816, 407)
        Me.TB_RemainZl.Name = "TB_RemainZl"
        Me.TB_RemainZl.ReadOnly = True
        Me.TB_RemainZl.Size = New System.Drawing.Size(110, 23)
        Me.TB_RemainZl.TabIndex = 12
        '
        'TB_PWeight
        '
        Me.TB_PWeight.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TB_PWeight.Location = New System.Drawing.Point(424, 407)
        Me.TB_PWeight.Name = "TB_PWeight"
        Me.TB_PWeight.ReadOnly = True
        Me.TB_PWeight.Size = New System.Drawing.Size(111, 23)
        Me.TB_PWeight.TabIndex = 13
        '
        'TB_RemainQty
        '
        Me.TB_RemainQty.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TB_RemainQty.Location = New System.Drawing.Point(603, 407)
        Me.TB_RemainQty.Name = "TB_RemainQty"
        Me.TB_RemainQty.ReadOnly = True
        Me.TB_RemainQty.Size = New System.Drawing.Size(111, 23)
        Me.TB_RemainQty.TabIndex = 10
        '
        'TB_SumQty
        '
        Me.TB_SumQty.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TB_SumQty.Location = New System.Drawing.Point(221, 407)
        Me.TB_SumQty.Name = "TB_SumQty"
        Me.TB_SumQty.ReadOnly = True
        Me.TB_SumQty.Size = New System.Drawing.Size(111, 23)
        Me.TB_SumQty.TabIndex = 11
        '
        'Label18
        '
        Me.Label18.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(541, 410)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(56, 14)
        Me.Label18.TabIndex = 16
        Me.Label18.Text = "余条数:"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(744, 410)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 14)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "余胚重:"
        '
        'Label14
        '
        Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(143, 410)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(70, 14)
        Me.Label14.TabIndex = 14
        Me.Label14.Text = "本单条数:"
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(362, 410)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 14)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "总胚重:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(210, 407)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(0, 14)
        Me.Label2.TabIndex = 9
        '
        'F40311_CPIni_Msg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CanMaxSize = True
        Me.Controls.Add(Me.PanelMain)
        Me.Controls.Add(Me.Tool_Top)
        Me.Name = "F40311_CPIni_Msg"
        Me.Size = New System.Drawing.Size(1146, 699)
        Me.Title = "胚布入库单"
        Me.Tool_Top.ResumeLayout(False)
        Me.Tool_Top.PerformLayout()
        Me.PanelMain.ResumeLayout(False)
        Me.PanelMain.PerformLayout()
        Me.Panel_All.ResumeLayout(False)
        Me.Panel_All.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ToolStrip_StoreNo_Old.ResumeLayout(False)
        Me.ToolStrip_StoreNo_Old.PerformLayout()
        Me.GB_Foot.ResumeLayout(False)
        Me.GB_Foot.PerformLayout()
        Me.GB_List.ResumeLayout(False)
        Me.GB_List.PerformLayout()
        CType(Me.Fg1, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GB_Foot As System.Windows.Forms.GroupBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TB_ID As System.Windows.Forms.TextBox
    Friend WithEvents Label_ID As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents DP_Date As System.Windows.Forms.DateTimePicker
    Friend WithEvents Btn_AddRow As System.Windows.Forms.ToolStripButton
    Friend WithEvents Btn_RemoveRow As System.Windows.Forms.ToolStripButton
    Friend WithEvents LabelTitle As System.Windows.Forms.Label
    Friend WithEvents Btn_Preview As System.Windows.Forms.ToolStripButton
    Friend WithEvents Btn_Print As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents GB_List As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TB_Remark As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TB_ZhiDan As System.Windows.Forms.TextBox
    Friend WithEvents TB_XiaoZhang As System.Windows.Forms.TextBox
    Friend WithEvents TB_State_User As System.Windows.Forms.TextBox
    Friend WithEvents Fg1 As PClass.FG
    Friend WithEvents Cmd_Audit As System.Windows.Forms.ToolStripButton
    Friend WithEvents LabelState As System.Windows.Forms.Label
    Friend WithEvents LabelStateT As System.Windows.Forms.Label
    Friend WithEvents Cmd_SetInValid As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_SetValid As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_UnAudit As System.Windows.Forms.ToolStripButton
    Friend WithEvents TB_RemainZl As System.Windows.Forms.TextBox
    Friend WithEvents TB_PWeight As System.Windows.Forms.TextBox
    Friend WithEvents TB_RemainQty As System.Windows.Forms.TextBox
    Friend WithEvents TB_SumQty As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents CB_StoreNo As System.Windows.Forms.ComboBox
    Friend WithEvents CB_Color As System.Windows.Forms.ComboBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ToolStrip_StoreNo_Old As System.Windows.Forms.ToolStrip
    Friend WithEvents Cmd_StoreNo As System.Windows.Forms.ToolStripButton
    Friend WithEvents TB_StoreNo As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Panel_All As System.Windows.Forms.Panel
    Friend WithEvents LB_AllQty As System.Windows.Forms.Label
    Friend WithEvents Cmd_YTS As System.Windows.Forms.Button
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents CB_driver As System.Windows.Forms.ComboBox
    Friend WithEvents CB_License As System.Windows.Forms.ComboBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents CB_Client As BaseClass.ComBoList
    Friend WithEvents CB_BZ As BaseClass.ComBoList
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TB_BZName As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TB_ClientName As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CB_BZC As BaseClass.ComBoList
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents TB_BZcName As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents TB_GH As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents DP_RKDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label21 As System.Windows.Forms.Label

End Class
