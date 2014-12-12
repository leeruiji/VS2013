<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F50001_Price_Msg
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F50001_Price_Msg))
        Me.Tool_Top = New System.Windows.Forms.ToolStrip
        Me.Cmd_Modify = New System.Windows.Forms.ToolStripButton
        Me.Cmd_Price = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator
        Me.Cmd_Copy = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.Cmd_AddRow = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.Cmd_RemoveRow = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.Cmd_SetInValid = New System.Windows.Forms.ToolStripButton
        Me.Cmd_SetValid = New System.Windows.Forms.ToolStripButton
        Me.Cmd_Del = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.Cmd_Audit = New System.Windows.Forms.ToolStripButton
        Me.Cmd_UnAudit = New System.Windows.Forms.ToolStripButton
        Me.Cmd_paste = New System.Windows.Forms.ToolStripButton
        Me.TS_Preview = New System.Windows.Forms.ToolStripDropDownButton
        Me.Cmd_Preview = New System.Windows.Forms.ToolStripMenuItem
        Me.Cmd_Preview_Un = New System.Windows.Forms.ToolStripMenuItem
        Me.Cmd_Preview_CK = New System.Windows.Forms.ToolStripMenuItem
        Me.Cmd_Preview_Un_Ck = New System.Windows.Forms.ToolStripMenuItem
        Me.TS_Print = New System.Windows.Forms.ToolStripDropDownButton
        Me.Cmd_Print = New System.Windows.Forms.ToolStripMenuItem
        Me.Cmd_Print_Un = New System.Windows.Forms.ToolStripMenuItem
        Me.Cmd_Print_CK = New System.Windows.Forms.ToolStripMenuItem
        Me.Cmd_Print_Un_CK = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.Cmd_Exit = New System.Windows.Forms.ToolStripButton
        Me.PanelMain = New System.Windows.Forms.Panel
        Me.CB_BZC_FG = New BaseClass.ComBoList
        Me.CB_BZ_FG = New BaseClass.ComBoList
        Me.CB_Client = New BaseClass.ComBoList
        Me.TB_Qty_UnComfirm = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.TB_Qty_Comfirm = New System.Windows.Forms.TextBox
        Me.CB_ShowComfirm = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TB_State_User = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.TB_Upd_User = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TB_Client_Name = New System.Windows.Forms.TextBox
        Me.Label39 = New System.Windows.Forms.Label
        Me.LabelState = New System.Windows.Forms.Label
        Me.LabelStateT = New System.Windows.Forms.Label
        Me.TB_Remark = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.LabelTitle = New System.Windows.Forms.Label
        Me.DTP_sDate = New System.Windows.Forms.DateTimePicker
        Me.Label16 = New System.Windows.Forms.Label
        Me.TB_ID = New System.Windows.Forms.TextBox
        Me.Label_ID = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.GB_List = New System.Windows.Forms.GroupBox
        Me.FG1 = New PClass.FG
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Employee_List1 = New BaseClass.Employee_List
        Me.Tool_Top.SuspendLayout()
        Me.PanelMain.SuspendLayout()
        Me.GB_List.SuspendLayout()
        CType(Me.FG1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Tool_Top
        '
        Me.Tool_Top.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.Tool_Top.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Cmd_Modify, Me.Cmd_Price, Me.ToolStripSeparator6, Me.Cmd_Copy, Me.ToolStripSeparator4, Me.Cmd_AddRow, Me.ToolStripSeparator5, Me.Cmd_RemoveRow, Me.ToolStripSeparator2, Me.Cmd_SetInValid, Me.Cmd_SetValid, Me.Cmd_Del, Me.ToolStripSeparator1, Me.Cmd_Audit, Me.Cmd_UnAudit, Me.Cmd_paste, Me.TS_Preview, Me.TS_Print, Me.ToolStripSeparator3, Me.Cmd_Exit})
        Me.Tool_Top.Location = New System.Drawing.Point(0, 0)
        Me.Tool_Top.MinimumSize = New System.Drawing.Size(0, 40)
        Me.Tool_Top.Name = "Tool_Top"
        Me.Tool_Top.Size = New System.Drawing.Size(1024, 40)
        Me.Tool_Top.TabIndex = 10
        Me.Tool_Top.Text = "ToolStrip2"
        '
        'Cmd_Modify
        '
        Me.Cmd_Modify.AccessibleDescription = "修改按钮"
        Me.Cmd_Modify.AccessibleName = ""
        Me.Cmd_Modify.Image = Global.DN500_Finance.My.Resources.Resources.Modify
        Me.Cmd_Modify.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Modify.Name = "Cmd_Modify"
        Me.Cmd_Modify.Size = New System.Drawing.Size(57, 37)
        Me.Cmd_Modify.Text = "保存"
        '
        'Cmd_Price
        '
        Me.Cmd_Price.Image = Global.DN500_Finance.My.Resources.Resources._30
        Me.Cmd_Price.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Price.Name = "Cmd_Price"
        Me.Cmd_Price.Size = New System.Drawing.Size(57, 37)
        Me.Cmd_Price.Text = "报价"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 40)
        '
        'Cmd_Copy
        '
        Me.Cmd_Copy.AccessibleDescription = "修改按钮"
        Me.Cmd_Copy.AccessibleName = ""
        Me.Cmd_Copy.Image = Global.DN500_Finance.My.Resources.Resources.copy
        Me.Cmd_Copy.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Copy.Name = "Cmd_Copy"
        Me.Cmd_Copy.Size = New System.Drawing.Size(57, 37)
        Me.Cmd_Copy.Text = "复制"
        Me.Cmd_Copy.Visible = False
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 40)
        '
        'Cmd_AddRow
        '
        Me.Cmd_AddRow.Image = Global.DN500_Finance.My.Resources.Resources.AddRow
        Me.Cmd_AddRow.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_AddRow.Name = "Cmd_AddRow"
        Me.Cmd_AddRow.Size = New System.Drawing.Size(57, 37)
        Me.Cmd_AddRow.Text = "增行"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 40)
        '
        'Cmd_RemoveRow
        '
        Me.Cmd_RemoveRow.Image = Global.DN500_Finance.My.Resources.Resources.RemoveRow
        Me.Cmd_RemoveRow.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_RemoveRow.Name = "Cmd_RemoveRow"
        Me.Cmd_RemoveRow.Size = New System.Drawing.Size(57, 37)
        Me.Cmd_RemoveRow.Text = "减行"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 40)
        '
        'Cmd_SetInValid
        '
        Me.Cmd_SetInValid.AccessibleDescription = "作废按钮"
        Me.Cmd_SetInValid.AccessibleName = ""
        Me.Cmd_SetInValid.Image = Global.DN500_Finance.My.Resources.Resources.InValid
        Me.Cmd_SetInValid.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_SetInValid.Name = "Cmd_SetInValid"
        Me.Cmd_SetInValid.Size = New System.Drawing.Size(57, 37)
        Me.Cmd_SetInValid.Text = "作废"
        Me.Cmd_SetInValid.Visible = False
        '
        'Cmd_SetValid
        '
        Me.Cmd_SetValid.AccessibleDescription = "反作废按钮"
        Me.Cmd_SetValid.AccessibleName = ""
        Me.Cmd_SetValid.Image = Global.DN500_Finance.My.Resources.Resources.SetValid
        Me.Cmd_SetValid.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_SetValid.Name = "Cmd_SetValid"
        Me.Cmd_SetValid.Size = New System.Drawing.Size(69, 37)
        Me.Cmd_SetValid.Text = "反作废"
        Me.Cmd_SetValid.Visible = False
        '
        'Cmd_Del
        '
        Me.Cmd_Del.AccessibleDescription = "修改按钮"
        Me.Cmd_Del.AccessibleName = ""
        Me.Cmd_Del.Image = Global.DN500_Finance.My.Resources.Resources.Delete
        Me.Cmd_Del.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Del.Name = "Cmd_Del"
        Me.Cmd_Del.Size = New System.Drawing.Size(57, 37)
        Me.Cmd_Del.Text = "删除"
        Me.Cmd_Del.Visible = False
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 40)
        '
        'Cmd_Audit
        '
        Me.Cmd_Audit.Image = Global.DN500_Finance.My.Resources.Resources.apply
        Me.Cmd_Audit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Audit.Name = "Cmd_Audit"
        Me.Cmd_Audit.Size = New System.Drawing.Size(57, 37)
        Me.Cmd_Audit.Text = "审核"
        Me.Cmd_Audit.Visible = False
        '
        'Cmd_UnAudit
        '
        Me.Cmd_UnAudit.Image = Global.DN500_Finance.My.Resources.Resources.cancel
        Me.Cmd_UnAudit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_UnAudit.Name = "Cmd_UnAudit"
        Me.Cmd_UnAudit.Size = New System.Drawing.Size(57, 37)
        Me.Cmd_UnAudit.Text = "反审"
        Me.Cmd_UnAudit.Visible = False
        '
        'Cmd_paste
        '
        Me.Cmd_paste.Image = Global.DN500_Finance.My.Resources.Resources.exce
        Me.Cmd_paste.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_paste.Name = "Cmd_paste"
        Me.Cmd_paste.Size = New System.Drawing.Size(87, 37)
        Me.Cmd_paste.Text = "Excel导入"
        '
        'TS_Preview
        '
        Me.TS_Preview.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Cmd_Preview, Me.Cmd_Preview_Un, Me.Cmd_Preview_CK, Me.Cmd_Preview_Un_Ck})
        Me.TS_Preview.Image = Global.DN500_Finance.My.Resources.Resources.Print_preview
        Me.TS_Preview.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TS_Preview.Name = "TS_Preview"
        Me.TS_Preview.Size = New System.Drawing.Size(66, 37)
        Me.TS_Preview.Text = "预览"
        '
        'Cmd_Preview
        '
        Me.Cmd_Preview.Name = "Cmd_Preview"
        Me.Cmd_Preview.Size = New System.Drawing.Size(190, 22)
        Me.Cmd_Preview.Text = "预览"
        '
        'Cmd_Preview_Un
        '
        Me.Cmd_Preview_Un.Name = "Cmd_Preview_Un"
        Me.Cmd_Preview_Un.Size = New System.Drawing.Size(190, 22)
        Me.Cmd_Preview_Un.Text = "预览未确定"
        '
        'Cmd_Preview_CK
        '
        Me.Cmd_Preview_CK.Name = "Cmd_Preview_CK"
        Me.Cmd_Preview_CK.Size = New System.Drawing.Size(190, 22)
        Me.Cmd_Preview_CK.Text = "预览(带参考价)"
        '
        'Cmd_Preview_Un_Ck
        '
        Me.Cmd_Preview_Un_Ck.Name = "Cmd_Preview_Un_Ck"
        Me.Cmd_Preview_Un_Ck.Size = New System.Drawing.Size(190, 22)
        Me.Cmd_Preview_Un_Ck.Text = "预览未确定(带参考价)"
        '
        'TS_Print
        '
        Me.TS_Print.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Cmd_Print, Me.Cmd_Print_Un, Me.Cmd_Print_CK, Me.Cmd_Print_Un_CK})
        Me.TS_Print.Image = Global.DN500_Finance.My.Resources.Resources.print
        Me.TS_Print.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TS_Print.Name = "TS_Print"
        Me.TS_Print.Size = New System.Drawing.Size(66, 37)
        Me.TS_Print.Text = "打印"
        '
        'Cmd_Print
        '
        Me.Cmd_Print.Name = "Cmd_Print"
        Me.Cmd_Print.Size = New System.Drawing.Size(190, 22)
        Me.Cmd_Print.Text = "打印"
        '
        'Cmd_Print_Un
        '
        Me.Cmd_Print_Un.Name = "Cmd_Print_Un"
        Me.Cmd_Print_Un.Size = New System.Drawing.Size(190, 22)
        Me.Cmd_Print_Un.Text = "打印未确定"
        '
        'Cmd_Print_CK
        '
        Me.Cmd_Print_CK.Name = "Cmd_Print_CK"
        Me.Cmd_Print_CK.Size = New System.Drawing.Size(190, 22)
        Me.Cmd_Print_CK.Text = "打印(带参考价)"
        '
        'Cmd_Print_Un_CK
        '
        Me.Cmd_Print_Un_CK.Name = "Cmd_Print_Un_CK"
        Me.Cmd_Print_Un_CK.Size = New System.Drawing.Size(190, 22)
        Me.Cmd_Print_Un_CK.Text = "打印未确定(带参考价)"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 40)
        '
        'Cmd_Exit
        '
        Me.Cmd_Exit.Image = Global.DN500_Finance.My.Resources.Resources.Close
        Me.Cmd_Exit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(57, 37)
        Me.Cmd_Exit.Text = "关闭"
        '
        'PanelMain
        '
        Me.PanelMain.Controls.Add(Me.CB_BZC_FG)
        Me.PanelMain.Controls.Add(Me.CB_BZ_FG)
        Me.PanelMain.Controls.Add(Me.CB_Client)
        Me.PanelMain.Controls.Add(Me.TB_Qty_UnComfirm)
        Me.PanelMain.Controls.Add(Me.Label4)
        Me.PanelMain.Controls.Add(Me.Label6)
        Me.PanelMain.Controls.Add(Me.TB_Qty_Comfirm)
        Me.PanelMain.Controls.Add(Me.CB_ShowComfirm)
        Me.PanelMain.Controls.Add(Me.Label2)
        Me.PanelMain.Controls.Add(Me.TB_State_User)
        Me.PanelMain.Controls.Add(Me.Label9)
        Me.PanelMain.Controls.Add(Me.Label8)
        Me.PanelMain.Controls.Add(Me.TB_Upd_User)
        Me.PanelMain.Controls.Add(Me.Label3)
        Me.PanelMain.Controls.Add(Me.TB_Client_Name)
        Me.PanelMain.Controls.Add(Me.Label39)
        Me.PanelMain.Controls.Add(Me.LabelState)
        Me.PanelMain.Controls.Add(Me.LabelStateT)
        Me.PanelMain.Controls.Add(Me.TB_Remark)
        Me.PanelMain.Controls.Add(Me.Label5)
        Me.PanelMain.Controls.Add(Me.LabelTitle)
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
        Me.PanelMain.Size = New System.Drawing.Size(1024, 668)
        Me.PanelMain.TabIndex = 0
        '
        'CB_BZC_FG
        '
        Me.CB_BZC_FG.Child = "ComboBZC"
        Me.CB_BZC_FG.FormattingEnabled = True
        Me.CB_BZC_FG.IDAsInt = 0
        Me.CB_BZC_FG.IDValue = ""
        Me.CB_BZC_FG.IsKeyDownAutoSearch = True
        Me.CB_BZC_FG.IsSelectName = False
        Me.CB_BZC_FG.IsTBLostFocusSelOne = True
        Me.CB_BZC_FG.Location = New System.Drawing.Point(392, 14)
        Me.CB_BZC_FG.Name = "CB_BZC_FG"
        Me.CB_BZC_FG.SearchType = BaseClass.cSearchType.ENum_SearchType.ALL
        Me.CB_BZC_FG.Size = New System.Drawing.Size(119, 22)
        Me.CB_BZC_FG.TabIndex = 78
        Me.CB_BZC_FG.Visible = False
        '
        'CB_BZ_FG
        '
        Me.CB_BZ_FG.Child = "ComboBZ"
        Me.CB_BZ_FG.FormattingEnabled = True
        Me.CB_BZ_FG.IDAsInt = 0
        Me.CB_BZ_FG.IDValue = ""
        Me.CB_BZ_FG.IsKeyDownAutoSearch = True
        Me.CB_BZ_FG.IsSelectName = False
        Me.CB_BZ_FG.IsTBLostFocusSelOne = True
        Me.CB_BZ_FG.Location = New System.Drawing.Point(267, 15)
        Me.CB_BZ_FG.Name = "CB_BZ_FG"
        Me.CB_BZ_FG.SearchType = BaseClass.cSearchType.ENum_SearchType.ALL
        Me.CB_BZ_FG.Size = New System.Drawing.Size(119, 22)
        Me.CB_BZ_FG.TabIndex = 77
        Me.CB_BZ_FG.Visible = False
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
        Me.CB_Client.Location = New System.Drawing.Point(90, 58)
        Me.CB_Client.Name = "CB_Client"
        Me.CB_Client.SearchType = BaseClass.cSearchType.ENum_SearchType.ALL
        Me.CB_Client.Size = New System.Drawing.Size(102, 22)
        Me.CB_Client.TabIndex = 0
        '
        'TB_Qty_UnComfirm
        '
        Me.TB_Qty_UnComfirm.Location = New System.Drawing.Point(277, 103)
        Me.TB_Qty_UnComfirm.Name = "TB_Qty_UnComfirm"
        Me.TB_Qty_UnComfirm.ReadOnly = True
        Me.TB_Qty_UnComfirm.Size = New System.Drawing.Size(111, 23)
        Me.TB_Qty_UnComfirm.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(215, 107)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 14)
        Me.Label4.TabIndex = 75
        Me.Label4.Text = "未确认:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(14, 106)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(70, 14)
        Me.Label6.TabIndex = 76
        Me.Label6.Text = "客户确认:"
        '
        'TB_Qty_Comfirm
        '
        Me.TB_Qty_Comfirm.Location = New System.Drawing.Point(89, 103)
        Me.TB_Qty_Comfirm.Name = "TB_Qty_Comfirm"
        Me.TB_Qty_Comfirm.ReadOnly = True
        Me.TB_Qty_Comfirm.Size = New System.Drawing.Size(103, 23)
        Me.TB_Qty_Comfirm.TabIndex = 4
        '
        'CB_ShowComfirm
        '
        Me.CB_ShowComfirm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_ShowComfirm.FormattingEnabled = True
        Me.CB_ShowComfirm.Items.AddRange(New Object() {"只显示未确认", "只显示已确认", "显示所有"})
        Me.CB_ShowComfirm.Location = New System.Drawing.Point(472, 103)
        Me.CB_ShowComfirm.Name = "CB_ShowComfirm"
        Me.CB_ShowComfirm.Size = New System.Drawing.Size(121, 22)
        Me.CB_ShowComfirm.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(400, 107)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 14)
        Me.Label2.TabIndex = 71
        Me.Label2.Text = "显示内容:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TB_State_User
        '
        Me.TB_State_User.Location = New System.Drawing.Point(651, 58)
        Me.TB_State_User.Name = "TB_State_User"
        Me.TB_State_User.ReadOnly = True
        Me.TB_State_User.Size = New System.Drawing.Size(100, 23)
        Me.TB_State_User.TabIndex = 3
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(585, 62)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(56, 14)
        Me.Label9.TabIndex = 69
        Me.Label9.Text = "审核人:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(420, 62)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(42, 14)
        Me.Label8.TabIndex = 70
        Me.Label8.Text = "制单:"
        '
        'TB_Upd_User
        '
        Me.TB_Upd_User.Location = New System.Drawing.Point(472, 58)
        Me.TB_Upd_User.Name = "TB_Upd_User"
        Me.TB_Upd_User.ReadOnly = True
        Me.TB_Upd_User.Size = New System.Drawing.Size(103, 23)
        Me.TB_Upd_User.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 62)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 14)
        Me.Label3.TabIndex = 66
        Me.Label3.Text = "客户编号:"
        '
        'TB_Client_Name
        '
        Me.TB_Client_Name.Location = New System.Drawing.Point(277, 58)
        Me.TB_Client_Name.Name = "TB_Client_Name"
        Me.TB_Client_Name.ReadOnly = True
        Me.TB_Client_Name.Size = New System.Drawing.Size(111, 23)
        Me.TB_Client_Name.TabIndex = 1
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Location = New System.Drawing.Point(201, 62)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(70, 14)
        Me.Label39.TabIndex = 58
        Me.Label39.Text = "客户名称:"
        '
        'LabelState
        '
        Me.LabelState.AutoSize = True
        Me.LabelState.BackColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LabelState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LabelState.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LabelState.ForeColor = System.Drawing.Color.Blue
        Me.LabelState.Location = New System.Drawing.Point(184, 14)
        Me.LabelState.Name = "LabelState"
        Me.LabelState.Size = New System.Drawing.Size(37, 16)
        Me.LabelState.TabIndex = 33
        Me.LabelState.Text = "新建"
        '
        'LabelStateT
        '
        Me.LabelStateT.AutoSize = True
        Me.LabelStateT.Location = New System.Drawing.Point(136, 14)
        Me.LabelStateT.Name = "LabelStateT"
        Me.LabelStateT.Size = New System.Drawing.Size(42, 14)
        Me.LabelStateT.TabIndex = 32
        Me.LabelStateT.Text = "状态:"
        '
        'TB_Remark
        '
        Me.TB_Remark.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TB_Remark.Location = New System.Drawing.Point(89, 529)
        Me.TB_Remark.Multiline = True
        Me.TB_Remark.Name = "TB_Remark"
        Me.TB_Remark.Size = New System.Drawing.Size(930, 125)
        Me.TB_Remark.TabIndex = 11
        Me.TB_Remark.Text = resources.GetString("TB_Remark.Text")
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(42, 532)
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
        Me.LabelTitle.Location = New System.Drawing.Point(13, 14)
        Me.LabelTitle.Name = "LabelTitle"
        Me.LabelTitle.Size = New System.Drawing.Size(59, 16)
        Me.LabelTitle.TabIndex = 22
        Me.LabelTitle.Text = "报价单"
        '
        'DTP_sDate
        '
        Me.DTP_sDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DTP_sDate.CustomFormat = "yyyy年MM月dd日"
        Me.DTP_sDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTP_sDate.Location = New System.Drawing.Point(709, 11)
        Me.DTP_sDate.Name = "DTP_sDate"
        Me.DTP_sDate.Size = New System.Drawing.Size(124, 23)
        Me.DTP_sDate.TabIndex = 7
        '
        'Label16
        '
        Me.Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(661, 16)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(42, 14)
        Me.Label16.TabIndex = 14
        Me.Label16.Text = "日期:"
        '
        'TB_ID
        '
        Me.TB_ID.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TB_ID.Location = New System.Drawing.Point(887, 11)
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
        Me.Label_ID.Location = New System.Drawing.Point(839, 16)
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
        Me.Label1.Size = New System.Drawing.Size(1026, 3)
        Me.Label1.TabIndex = 11
        '
        'GB_List
        '
        Me.GB_List.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GB_List.Controls.Add(Me.FG1)
        Me.GB_List.Location = New System.Drawing.Point(10, 137)
        Me.GB_List.Name = "GB_List"
        Me.GB_List.Size = New System.Drawing.Size(1012, 386)
        Me.GB_List.TabIndex = 0
        Me.GB_List.TabStop = False
        '
        'FG1
        '
        Me.FG1.AddCopyMenu = False
        Me.FG1.AllowEditing = False
        Me.FG1.AutoAddIndex = True
        Me.FG1.AutoGenerateColumns = False
        Me.FG1.AutoResize = False
        Me.FG1.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.FG1.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.XpThemes
        Me.FG1.CanEditing = True
        Me.FG1.CheckKeyPressEdit = True
        Me.FG1.ColumnInfo = resources.GetString("FG1.ColumnInfo")
        Me.FG1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FG1.EditFormat = True
        Me.FG1.ExtendLastCol = True
        Me.FG1.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.FG1.ForeColor = System.Drawing.Color.Black
        Me.FG1.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.FG1.IsAutoAddRow = True
        Me.FG1.IsClickStartEdit = True
        Me.FG1.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.FG1.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.FG1.Location = New System.Drawing.Point(3, 19)
        Me.FG1.Name = "FG1"
        Me.FG1.NoShowMenu = False
        Me.FG1.Rows.Count = 10
        Me.FG1.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.FG1.Size = New System.Drawing.Size(1006, 364)
        Me.FG1.StartCol = ""
        Me.FG1.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("FG1.Styles"))
        Me.FG1.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.BelowData
        Me.FG1.TabIndex = 0
        '
        'Timer1
        '
        '
        'Employee_List1
        '
        Me.Employee_List1.BackColor = System.Drawing.Color.DodgerBlue
        Me.Employee_List1.IsShowAll = True
        Me.Employee_List1.IsTBLostFocusSelOne = True
        Me.Employee_List1.Location = New System.Drawing.Point(-1000, 4)
        Me.Employee_List1.Name = "Employee_List1"
        Me.Employee_List1.SearchId = ""
        Me.Employee_List1.SearchType = BaseClass.Employee_List.ENum_SearchType.ALL
        Me.Employee_List1.Size = New System.Drawing.Size(250, 209)
        Me.Employee_List1.TabIndex = 11
        Me.Employee_List1.Visible = False
        '
        'F50001_Price_Msg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CanMaxSize = True
        Me.Controls.Add(Me.Employee_List1)
        Me.Controls.Add(Me.PanelMain)
        Me.Controls.Add(Me.Tool_Top)
        Me.ForeColor = System.Drawing.Color.Black
        Me.Name = "F50001_Price_Msg"
        Me.Size = New System.Drawing.Size(1024, 708)
        Me.Title = "报价单"
        Me.Tool_Top.ResumeLayout(False)
        Me.Tool_Top.PerformLayout()
        Me.PanelMain.ResumeLayout(False)
        Me.PanelMain.PerformLayout()
        Me.GB_List.ResumeLayout(False)
        CType(Me.FG1, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents TB_ID As System.Windows.Forms.TextBox
    Friend WithEvents Label_ID As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents DTP_sDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Cmd_AddRow As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_RemoveRow As System.Windows.Forms.ToolStripButton
    Friend WithEvents LabelTitle As System.Windows.Forms.Label
    Friend WithEvents GB_List As System.Windows.Forms.GroupBox
    Friend WithEvents TB_Remark As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents FG1 As PClass.FG
    Friend WithEvents Cmd_Audit As System.Windows.Forms.ToolStripButton
    Friend WithEvents LabelStateT As System.Windows.Forms.Label
    Friend WithEvents LabelState As System.Windows.Forms.Label
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Cmd_SetInValid As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_SetValid As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Cmd_UnAudit As System.Windows.Forms.ToolStripButton
    Friend WithEvents Employee_List1 As BaseClass.Employee_List
    Friend WithEvents TB_Client_Name As System.Windows.Forms.TextBox
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents Cmd_Copy As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TB_State_User As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TB_Upd_User As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CB_ShowComfirm As System.Windows.Forms.ComboBox
    Friend WithEvents Cmd_Price As System.Windows.Forms.ToolStripButton
    Friend WithEvents TB_Qty_UnComfirm As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TB_Qty_Comfirm As System.Windows.Forms.TextBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents CB_Client As BaseClass.ComBoList
    Friend WithEvents CB_BZC_FG As BaseClass.ComBoList
    Friend WithEvents CB_BZ_FG As BaseClass.ComBoList
    Friend WithEvents Cmd_paste As System.Windows.Forms.ToolStripButton
    Friend WithEvents TS_Preview As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents Cmd_Preview As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Cmd_Preview_Un As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Cmd_Preview_CK As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Cmd_Preview_Un_Ck As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TS_Print As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents Cmd_Print As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Cmd_Print_Un As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Cmd_Print_CK As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Cmd_Print_Un_CK As System.Windows.Forms.ToolStripMenuItem

End Class
