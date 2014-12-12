<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F40011_OutWork_Msg
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F40011_OutWork_Msg))
        Me.Tool_Top = New System.Windows.Forms.ToolStrip
        Me.Cmd_Modify = New System.Windows.Forms.ToolStripButton
        Me.Cmd_Del = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.Btn_AddRow = New System.Windows.Forms.ToolStripButton
        Me.Btn_RemoveRow = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.Btn_Preview = New System.Windows.Forms.ToolStripButton
        Me.Btn_Print = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.Cmd_UnComfirm = New System.Windows.Forms.ToolStripButton
        Me.Cmd_Store_Comfirm = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.Cmd_SetInvalid = New System.Windows.Forms.ToolStripButton
        Me.Cmd_SetValid = New System.Windows.Forms.ToolStripButton
        Me.Cmd_Exit = New System.Windows.Forms.ToolStripButton
        Me.PanelMain = New System.Windows.Forms.Panel
        Me.CKB_SetReceipt = New System.Windows.Forms.CheckBox
        Me.LabelState = New System.Windows.Forms.Label
        Me.LabelStateT = New System.Windows.Forms.Label
        Me.CB_BZC_FG = New BaseClass.ComBoList
        Me.CB_BZ_FG = New BaseClass.ComBoList
        Me.CB_JGDW = New BaseClass.ComBoList
        Me.TB_JGDWName = New System.Windows.Forms.TextBox
        Me.TB_PWeight = New System.Windows.Forms.TextBox
        Me.TB_SumQty = New System.Windows.Forms.TextBox
        Me.LabelTitle = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label_Supplier_Name = New System.Windows.Forms.Label
        Me.DP_Date = New System.Windows.Forms.DateTimePicker
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.TB_ID = New System.Windows.Forms.TextBox
        Me.Label_ID = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label_Supplier_ID = New System.Windows.Forms.Label
        Me.GB_List = New System.Windows.Forms.GroupBox
        Me.PanelFG = New System.Windows.Forms.Panel
        Me.Fg1 = New PClass.FG
        Me.Label2 = New System.Windows.Forms.Label
        Me.GB_Foot = New System.Windows.Forms.GroupBox
        Me.CB_SiJi = New System.Windows.Forms.ComboBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.TB_Remark = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.TB_Address = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.CB_ChePai = New System.Windows.Forms.ComboBox
        Me.CB_FaHuo = New System.Windows.Forms.ComboBox
        Me.CB_ZhiDan = New System.Windows.Forms.ComboBox
        Me.Tool_Top.SuspendLayout()
        Me.PanelMain.SuspendLayout()
        Me.GB_List.SuspendLayout()
        Me.PanelFG.SuspendLayout()
        CType(Me.Fg1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GB_Foot.SuspendLayout()
        Me.SuspendLayout()
        '
        'Tool_Top
        '
        Me.Tool_Top.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.Tool_Top.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Cmd_Modify, Me.Cmd_Del, Me.ToolStripSeparator2, Me.Btn_AddRow, Me.Btn_RemoveRow, Me.ToolStripSeparator5, Me.Btn_Preview, Me.Btn_Print, Me.ToolStripSeparator1, Me.Cmd_UnComfirm, Me.Cmd_Store_Comfirm, Me.ToolStripSeparator4, Me.Cmd_SetInvalid, Me.Cmd_SetValid, Me.Cmd_Exit})
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
        Me.Cmd_Modify.Image = Global.DN400_Store.My.Resources.Resources.Modify
        Me.Cmd_Modify.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Modify.Name = "Cmd_Modify"
        Me.Cmd_Modify.Size = New System.Drawing.Size(57, 37)
        Me.Cmd_Modify.Text = "保存"
        '
        'Cmd_Del
        '
        Me.Cmd_Del.AccessibleDescription = "修改按钮"
        Me.Cmd_Del.AccessibleName = ""
        Me.Cmd_Del.Image = Global.DN400_Store.My.Resources.Resources.Delete
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
        'Btn_AddRow
        '
        Me.Btn_AddRow.Image = CType(resources.GetObject("Btn_AddRow.Image"), System.Drawing.Image)
        Me.Btn_AddRow.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Btn_AddRow.Name = "Btn_AddRow"
        Me.Btn_AddRow.Size = New System.Drawing.Size(57, 37)
        Me.Btn_AddRow.Text = "增行"
        '
        'Btn_RemoveRow
        '
        Me.Btn_RemoveRow.Image = Global.DN400_Store.My.Resources.Resources.Btn_RemoveRow
        Me.Btn_RemoveRow.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Btn_RemoveRow.Name = "Btn_RemoveRow"
        Me.Btn_RemoveRow.Size = New System.Drawing.Size(57, 37)
        Me.Btn_RemoveRow.Text = "减行"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 40)
        '
        'Btn_Preview
        '
        Me.Btn_Preview.Image = Global.DN400_Store.My.Resources.Resources.Print_preview
        Me.Btn_Preview.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Btn_Preview.Name = "Btn_Preview"
        Me.Btn_Preview.Size = New System.Drawing.Size(57, 37)
        Me.Btn_Preview.Text = "预览"
        '
        'Btn_Print
        '
        Me.Btn_Print.Image = Global.DN400_Store.My.Resources.Resources.print
        Me.Btn_Print.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Btn_Print.Name = "Btn_Print"
        Me.Btn_Print.Size = New System.Drawing.Size(57, 37)
        Me.Btn_Print.Text = "打印"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 40)
        '
        'Cmd_UnComfirm
        '
        Me.Cmd_UnComfirm.Image = Global.DN400_Store.My.Resources.Resources.PBRK
        Me.Cmd_UnComfirm.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_UnComfirm.Name = "Cmd_UnComfirm"
        Me.Cmd_UnComfirm.Size = New System.Drawing.Size(81, 37)
        Me.Cmd_UnComfirm.Text = "取消确认"
        '
        'Cmd_Store_Comfirm
        '
        Me.Cmd_Store_Comfirm.Image = Global.DN400_Store.My.Resources.Resources.PeiBu
        Me.Cmd_Store_Comfirm.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Store_Comfirm.Name = "Cmd_Store_Comfirm"
        Me.Cmd_Store_Comfirm.Size = New System.Drawing.Size(57, 37)
        Me.Cmd_Store_Comfirm.Text = "确认"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 40)
        '
        'Cmd_SetInvalid
        '
        Me.Cmd_SetInvalid.Image = Global.DN400_Store.My.Resources.Resources.InValid
        Me.Cmd_SetInvalid.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_SetInvalid.Name = "Cmd_SetInvalid"
        Me.Cmd_SetInvalid.Size = New System.Drawing.Size(57, 37)
        Me.Cmd_SetInvalid.Text = "作废"
        '
        'Cmd_SetValid
        '
        Me.Cmd_SetValid.Image = Global.DN400_Store.My.Resources.Resources.PBRK
        Me.Cmd_SetValid.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_SetValid.Name = "Cmd_SetValid"
        Me.Cmd_SetValid.Size = New System.Drawing.Size(69, 37)
        Me.Cmd_SetValid.Text = "反作废"
        '
        'Cmd_Exit
        '
        Me.Cmd_Exit.Image = Global.DN400_Store.My.Resources.Resources.Close
        Me.Cmd_Exit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(57, 37)
        Me.Cmd_Exit.Text = "关闭"
        '
        'PanelMain
        '
        Me.PanelMain.Controls.Add(Me.CKB_SetReceipt)
        Me.PanelMain.Controls.Add(Me.LabelState)
        Me.PanelMain.Controls.Add(Me.LabelStateT)
        Me.PanelMain.Controls.Add(Me.CB_BZC_FG)
        Me.PanelMain.Controls.Add(Me.CB_BZ_FG)
        Me.PanelMain.Controls.Add(Me.CB_JGDW)
        Me.PanelMain.Controls.Add(Me.TB_JGDWName)
        Me.PanelMain.Controls.Add(Me.TB_PWeight)
        Me.PanelMain.Controls.Add(Me.TB_SumQty)
        Me.PanelMain.Controls.Add(Me.LabelTitle)
        Me.PanelMain.Controls.Add(Me.Label14)
        Me.PanelMain.Controls.Add(Me.Label_Supplier_Name)
        Me.PanelMain.Controls.Add(Me.DP_Date)
        Me.PanelMain.Controls.Add(Me.Label6)
        Me.PanelMain.Controls.Add(Me.Label16)
        Me.PanelMain.Controls.Add(Me.TB_ID)
        Me.PanelMain.Controls.Add(Me.Label_ID)
        Me.PanelMain.Controls.Add(Me.Label1)
        Me.PanelMain.Controls.Add(Me.Label_Supplier_ID)
        Me.PanelMain.Controls.Add(Me.GB_List)
        Me.PanelMain.Controls.Add(Me.GB_Foot)
        Me.PanelMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelMain.Location = New System.Drawing.Point(0, 40)
        Me.PanelMain.Name = "PanelMain"
        Me.PanelMain.Padding = New System.Windows.Forms.Padding(2)
        Me.PanelMain.Size = New System.Drawing.Size(1024, 610)
        Me.PanelMain.TabIndex = 12
        '
        'CKB_SetReceipt
        '
        Me.CKB_SetReceipt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CKB_SetReceipt.AutoSize = True
        Me.CKB_SetReceipt.Enabled = False
        Me.CKB_SetReceipt.Location = New System.Drawing.Point(551, 13)
        Me.CKB_SetReceipt.Name = "CKB_SetReceipt"
        Me.CKB_SetReceipt.Size = New System.Drawing.Size(82, 18)
        Me.CKB_SetReceipt.TabIndex = 44
        Me.CKB_SetReceipt.Text = "已收回单"
        Me.CKB_SetReceipt.UseVisualStyleBackColor = True
        '
        'LabelState
        '
        Me.LabelState.AutoSize = True
        Me.LabelState.BackColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LabelState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LabelState.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LabelState.ForeColor = System.Drawing.Color.Blue
        Me.LabelState.Location = New System.Drawing.Point(225, 16)
        Me.LabelState.Name = "LabelState"
        Me.LabelState.Size = New System.Drawing.Size(37, 16)
        Me.LabelState.TabIndex = 43
        Me.LabelState.Text = "新建"
        '
        'LabelStateT
        '
        Me.LabelStateT.AutoSize = True
        Me.LabelStateT.Location = New System.Drawing.Point(177, 16)
        Me.LabelStateT.Name = "LabelStateT"
        Me.LabelStateT.Size = New System.Drawing.Size(42, 14)
        Me.LabelStateT.TabIndex = 42
        Me.LabelStateT.Text = "状态:"
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
        Me.CB_BZC_FG.Location = New System.Drawing.Point(405, 7)
        Me.CB_BZC_FG.Name = "CB_BZC_FG"
        Me.CB_BZC_FG.SearchType = BaseClass.cSearchType.ENum_SearchType.ALL
        Me.CB_BZC_FG.Size = New System.Drawing.Size(119, 22)
        Me.CB_BZC_FG.TabIndex = 41
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
        Me.CB_BZ_FG.Location = New System.Drawing.Point(280, 8)
        Me.CB_BZ_FG.Name = "CB_BZ_FG"
        Me.CB_BZ_FG.SearchType = BaseClass.cSearchType.ENum_SearchType.ALL
        Me.CB_BZ_FG.Size = New System.Drawing.Size(119, 22)
        Me.CB_BZ_FG.TabIndex = 40
        Me.CB_BZ_FG.Visible = False
        '
        'CB_JGDW
        '
        Me.CB_JGDW.Child = "ComboJGDW"
        Me.CB_JGDW.FormattingEnabled = True
        Me.CB_JGDW.IDAsInt = 0
        Me.CB_JGDW.IDValue = ""
        Me.CB_JGDW.IsKeyDownAutoSearch = True
        Me.CB_JGDW.IsSelectName = False
        Me.CB_JGDW.IsShowAdd = True
        Me.CB_JGDW.IsShowModify = True
        Me.CB_JGDW.IsTBLostFocusSelOne = True
        Me.CB_JGDW.Location = New System.Drawing.Point(110, 57)
        Me.CB_JGDW.Name = "CB_JGDW"
        Me.CB_JGDW.SearchType = BaseClass.cSearchType.ENum_SearchType.ALL
        Me.CB_JGDW.Size = New System.Drawing.Size(109, 22)
        Me.CB_JGDW.TabIndex = 0
        '
        'TB_JGDWName
        '
        Me.TB_JGDWName.Location = New System.Drawing.Point(325, 57)
        Me.TB_JGDWName.Name = "TB_JGDWName"
        Me.TB_JGDWName.ReadOnly = True
        Me.TB_JGDWName.Size = New System.Drawing.Size(111, 23)
        Me.TB_JGDWName.TabIndex = 1
        '
        'TB_PWeight
        '
        Me.TB_PWeight.Location = New System.Drawing.Point(680, 57)
        Me.TB_PWeight.Name = "TB_PWeight"
        Me.TB_PWeight.Size = New System.Drawing.Size(111, 23)
        Me.TB_PWeight.TabIndex = 3
        '
        'TB_SumQty
        '
        Me.TB_SumQty.Location = New System.Drawing.Point(494, 58)
        Me.TB_SumQty.Name = "TB_SumQty"
        Me.TB_SumQty.ReadOnly = True
        Me.TB_SumQty.Size = New System.Drawing.Size(111, 23)
        Me.TB_SumQty.TabIndex = 2
        '
        'LabelTitle
        '
        Me.LabelTitle.AutoSize = True
        Me.LabelTitle.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LabelTitle.ForeColor = System.Drawing.Color.Blue
        Me.LabelTitle.Location = New System.Drawing.Point(31, 14)
        Me.LabelTitle.Name = "LabelTitle"
        Me.LabelTitle.Size = New System.Drawing.Size(93, 16)
        Me.LabelTitle.TabIndex = 22
        Me.LabelTitle.Text = "外发加工单"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(439, 61)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(56, 14)
        Me.Label14.TabIndex = 9
        Me.Label14.Text = "总条数:"
        '
        'Label_Supplier_Name
        '
        Me.Label_Supplier_Name.AutoSize = True
        Me.Label_Supplier_Name.Location = New System.Drawing.Point(225, 61)
        Me.Label_Supplier_Name.Name = "Label_Supplier_Name"
        Me.Label_Supplier_Name.Size = New System.Drawing.Size(98, 14)
        Me.Label_Supplier_Name.TabIndex = 21
        Me.Label_Supplier_Name.Text = "加工单位名称:"
        '
        'DP_Date
        '
        Me.DP_Date.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DP_Date.Location = New System.Drawing.Point(687, 12)
        Me.DP_Date.Name = "DP_Date"
        Me.DP_Date.Size = New System.Drawing.Size(124, 23)
        Me.DP_Date.TabIndex = 18
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(618, 61)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(42, 14)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "总重:"
        '
        'Label16
        '
        Me.Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(639, 16)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(42, 14)
        Me.Label16.TabIndex = 14
        Me.Label16.Text = "日期:"
        '
        'TB_ID
        '
        Me.TB_ID.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TB_ID.Location = New System.Drawing.Point(889, 11)
        Me.TB_ID.Name = "TB_ID"
        Me.TB_ID.Size = New System.Drawing.Size(132, 23)
        Me.TB_ID.TabIndex = 0
        '
        'Label_ID
        '
        Me.Label_ID.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label_ID.AutoSize = True
        Me.Label_ID.ForeColor = System.Drawing.Color.Blue
        Me.Label_ID.Location = New System.Drawing.Point(841, 16)
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
        Me.Label1.Size = New System.Drawing.Size(1028, 3)
        Me.Label1.TabIndex = 11
        '
        'Label_Supplier_ID
        '
        Me.Label_Supplier_ID.AutoSize = True
        Me.Label_Supplier_ID.Location = New System.Drawing.Point(6, 61)
        Me.Label_Supplier_ID.Name = "Label_Supplier_ID"
        Me.Label_Supplier_ID.Size = New System.Drawing.Size(98, 14)
        Me.Label_Supplier_ID.TabIndex = 13
        Me.Label_Supplier_ID.Text = "加工单位编号:"
        '
        'GB_List
        '
        Me.GB_List.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GB_List.Controls.Add(Me.PanelFG)
        Me.GB_List.Controls.Add(Me.Label2)
        Me.GB_List.Location = New System.Drawing.Point(5, 84)
        Me.GB_List.Name = "GB_List"
        Me.GB_List.Size = New System.Drawing.Size(1019, 415)
        Me.GB_List.TabIndex = 4
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
        Me.PanelFG.Size = New System.Drawing.Size(1007, 387)
        Me.PanelFG.TabIndex = 0
        '
        'Fg1
        '
        Me.Fg1.AddCopyMenu = False
        Me.Fg1.AllowEditing = False
        Me.Fg1.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.Fg1.AutoAddIndex = True
        Me.Fg1.AutoGenerateColumns = False
        Me.Fg1.AutoResize = False
        Me.Fg1.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.Fg1.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.XpThemes
        Me.Fg1.CanEditing = True
        Me.Fg1.CheckKeyPressEdit = True
        Me.Fg1.ColumnInfo = resources.GetString("Fg1.ColumnInfo")
        Me.Fg1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Fg1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Fg1.EditFormat = True
        Me.Fg1.ExtendLastCol = True
        Me.Fg1.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Fg1.ForeColor = System.Drawing.Color.Black
        Me.Fg1.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.Fg1.IsAutoAddRow = True
        Me.Fg1.IsClickStartEdit = True
        Me.Fg1.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.Fg1.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.Fg1.Location = New System.Drawing.Point(1, 1)
        Me.Fg1.Name = "Fg1"
        Me.Fg1.NoShowMenu = False
        Me.Fg1.Rows.Count = 10
        Me.Fg1.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.Fg1.Size = New System.Drawing.Size(1005, 385)
        Me.Fg1.StartCol = ""
        Me.Fg1.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("Fg1.Styles"))
        Me.Fg1.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.BelowData
        Me.Fg1.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(204, 247)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(0, 14)
        Me.Label2.TabIndex = 9
        '
        'GB_Foot
        '
        Me.GB_Foot.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GB_Foot.Controls.Add(Me.CB_SiJi)
        Me.GB_Foot.Controls.Add(Me.Label11)
        Me.GB_Foot.Controls.Add(Me.Label10)
        Me.GB_Foot.Controls.Add(Me.TB_Remark)
        Me.GB_Foot.Controls.Add(Me.Label9)
        Me.GB_Foot.Controls.Add(Me.TB_Address)
        Me.GB_Foot.Controls.Add(Me.Label4)
        Me.GB_Foot.Controls.Add(Me.Label8)
        Me.GB_Foot.Controls.Add(Me.Label5)
        Me.GB_Foot.Controls.Add(Me.CB_ChePai)
        Me.GB_Foot.Controls.Add(Me.CB_FaHuo)
        Me.GB_Foot.Controls.Add(Me.CB_ZhiDan)
        Me.GB_Foot.Location = New System.Drawing.Point(5, 505)
        Me.GB_Foot.Name = "GB_Foot"
        Me.GB_Foot.Size = New System.Drawing.Size(1006, 100)
        Me.GB_Foot.TabIndex = 3
        Me.GB_Foot.TabStop = False
        '
        'CB_SiJi
        '
        Me.CB_SiJi.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CB_SiJi.DisplayMember = "Remark"
        Me.CB_SiJi.FormattingEnabled = True
        Me.CB_SiJi.Location = New System.Drawing.Point(679, 15)
        Me.CB_SiJi.Name = "CB_SiJi"
        Me.CB_SiJi.Size = New System.Drawing.Size(111, 22)
        Me.CB_SiJi.TabIndex = 14
        Me.CB_SiJi.ValueMember = "Remark"
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(444, 20)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(42, 14)
        Me.Label11.TabIndex = 13
        Me.Label11.Text = "车牌:"
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(631, 20)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(42, 14)
        Me.Label10.TabIndex = 13
        Me.Label10.Text = "司机:"
        '
        'TB_Remark
        '
        Me.TB_Remark.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TB_Remark.Location = New System.Drawing.Point(82, 58)
        Me.TB_Remark.Name = "TB_Remark"
        Me.TB_Remark.Size = New System.Drawing.Size(312, 23)
        Me.TB_Remark.TabIndex = 4
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(221, 19)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(56, 14)
        Me.Label9.TabIndex = 13
        Me.Label9.Text = "发货人:"
        '
        'TB_Address
        '
        Me.TB_Address.Location = New System.Drawing.Point(483, 58)
        Me.TB_Address.Name = "TB_Address"
        Me.TB_Address.Size = New System.Drawing.Size(307, 23)
        Me.TB_Address.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(407, 62)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 14)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "送货地址:"
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(34, 19)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(42, 14)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "制单:"
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(34, 61)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(42, 14)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "备注:"
        '
        'CB_ChePai
        '
        Me.CB_ChePai.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CB_ChePai.DisplayMember = "Remark"
        Me.CB_ChePai.FormattingEnabled = True
        Me.CB_ChePai.Location = New System.Drawing.Point(492, 16)
        Me.CB_ChePai.Name = "CB_ChePai"
        Me.CB_ChePai.Size = New System.Drawing.Size(111, 22)
        Me.CB_ChePai.TabIndex = 3
        Me.CB_ChePai.ValueMember = "Remark"
        '
        'CB_FaHuo
        '
        Me.CB_FaHuo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CB_FaHuo.DisplayMember = "Employee_Name"
        Me.CB_FaHuo.FormattingEnabled = True
        Me.CB_FaHuo.Location = New System.Drawing.Point(283, 15)
        Me.CB_FaHuo.Name = "CB_FaHuo"
        Me.CB_FaHuo.Size = New System.Drawing.Size(111, 22)
        Me.CB_FaHuo.TabIndex = 1
        Me.CB_FaHuo.ValueMember = "Employee_No"
        '
        'CB_ZhiDan
        '
        Me.CB_ZhiDan.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CB_ZhiDan.DisplayMember = "Employee_Name"
        Me.CB_ZhiDan.FormattingEnabled = True
        Me.CB_ZhiDan.Location = New System.Drawing.Point(82, 15)
        Me.CB_ZhiDan.Name = "CB_ZhiDan"
        Me.CB_ZhiDan.Size = New System.Drawing.Size(111, 22)
        Me.CB_ZhiDan.TabIndex = 0
        Me.CB_ZhiDan.ValueMember = "Employee_No"
        '
        'F40011_OutWork_Msg
        '
        Me.AutoMax = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CanMaxSize = True
        Me.Controls.Add(Me.PanelMain)
        Me.Controls.Add(Me.Tool_Top)
        Me.Name = "F40011_OutWork_Msg"
        Me.Size = New System.Drawing.Size(1024, 650)
        Me.Title = "外发加工单"
        Me.Tool_Top.ResumeLayout(False)
        Me.Tool_Top.PerformLayout()
        Me.PanelMain.ResumeLayout(False)
        Me.PanelMain.PerformLayout()
        Me.GB_List.ResumeLayout(False)
        Me.GB_List.PerformLayout()
        Me.PanelFG.ResumeLayout(False)
        CType(Me.Fg1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GB_Foot.ResumeLayout(False)
        Me.GB_Foot.PerformLayout()
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
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label_Supplier_ID As System.Windows.Forms.Label
    Friend WithEvents GB_List As System.Windows.Forms.GroupBox
    Friend WithEvents Fg1 As PClass.FG
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TB_Remark As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TB_PWeight As System.Windows.Forms.TextBox
    Friend WithEvents GB_Foot As System.Windows.Forms.GroupBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents CB_FaHuo As System.Windows.Forms.ComboBox
    Friend WithEvents CB_ZhiDan As System.Windows.Forms.ComboBox
    Friend WithEvents TB_SumQty As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TB_ID As System.Windows.Forms.TextBox
    Friend WithEvents Label_ID As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents DP_Date As System.Windows.Forms.DateTimePicker
    Friend WithEvents Btn_AddRow As System.Windows.Forms.ToolStripButton
    Friend WithEvents Btn_RemoveRow As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label_Supplier_Name As System.Windows.Forms.Label
    Friend WithEvents LabelTitle As System.Windows.Forms.Label
    Friend WithEvents PanelFG As System.Windows.Forms.Panel
    Friend WithEvents TB_Address As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TB_JGDWName As System.Windows.Forms.TextBox
    Friend WithEvents Btn_Preview As System.Windows.Forms.ToolStripButton
    Friend WithEvents Btn_Print As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CB_ChePai As System.Windows.Forms.ComboBox
    Friend WithEvents CB_SiJi As System.Windows.Forms.ComboBox
    Friend WithEvents CB_JGDW As BaseClass.ComBoList
    Friend WithEvents CB_BZC_FG As BaseClass.ComBoList
    Friend WithEvents CB_BZ_FG As BaseClass.ComBoList
    Friend WithEvents Cmd_SetInvalid As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_SetValid As System.Windows.Forms.ToolStripButton
    Friend WithEvents LabelState As System.Windows.Forms.Label
    Friend WithEvents LabelStateT As System.Windows.Forms.Label
    Friend WithEvents CKB_SetReceipt As System.Windows.Forms.CheckBox
    Friend WithEvents Cmd_UnComfirm As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_Store_Comfirm As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator

End Class
