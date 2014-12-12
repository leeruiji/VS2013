<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F40151_PBTC_Msg
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F40151_PBTC_Msg))
        Me.Tool_Top = New System.Windows.Forms.ToolStrip()
        Me.Cmd_Modify = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.Cmd_Exit = New System.Windows.Forms.ToolStripButton()
        Me.PanelMain = New System.Windows.Forms.Panel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.GB_List = New System.Windows.Forms.GroupBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Fg1 = New PClass.FG()
        Me.ToolStrip_SearchNo = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.TB_SearchNo = New System.Windows.Forms.ToolStripTextBox()
        Me.Cmd_Clear = New System.Windows.Forms.ToolStripButton()
        Me.Cmd_SearchNo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStrip_StoreNo_Old = New System.Windows.Forms.ToolStrip()
        Me.Cmd_OldStoreNo = New System.Windows.Forms.ToolStripButton()
        Me.TB_StoreNo_Old = New System.Windows.Forms.ToolStripTextBox()
        Me.OldStoreNo_All = New System.Windows.Forms.ToolStripButton()
        Me.Cmd_RowAdd = New System.Windows.Forms.Button()
        Me.TB_Old_Qty = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Fg2 = New PClass.FG()
        Me.TB_Now_Qty = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Cmd_RowDel = New System.Windows.Forms.Button()
        Me.Fg3 = New PClass.FG()
        Me.TB_New_Qty = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.ToolStrip_StoreNo_New = New System.Windows.Forms.ToolStrip()
        Me.Cmd_NewStoreNo = New System.Windows.Forms.ToolStripButton()
        Me.TB_StoreNo_New = New System.Windows.Forms.ToolStripTextBox()
        Me.NewStoreNo_All = New System.Windows.Forms.ToolStripButton()
        Me.LabelState = New System.Windows.Forms.Label()
        Me.LabelStateT = New System.Windows.Forms.Label()
        Me.LabelTitle = New System.Windows.Forms.Label()
        Me.DTP_sDate = New System.Windows.Forms.DateTimePicker()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TB_ID = New System.Windows.Forms.TextBox()
        Me.Label_ID = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GB_Foot = New System.Windows.Forms.GroupBox()
        Me.TB_Remark = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TB_ZhiDan = New System.Windows.Forms.TextBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Fg4 = New PClass.FG()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TB_CangWei = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TB_Old_CangWei = New System.Windows.Forms.TextBox()
        Me.Tool_Top.SuspendLayout()
        Me.PanelMain.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GB_List.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.Fg1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip_SearchNo.SuspendLayout()
        Me.ToolStrip_StoreNo_Old.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.Fg2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.Fg3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip_StoreNo_New.SuspendLayout()
        Me.GB_Foot.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.Fg4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Tool_Top
        '
        Me.Tool_Top.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.Tool_Top.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Cmd_Modify, Me.ToolStripSeparator3, Me.Cmd_Exit})
        Me.Tool_Top.Location = New System.Drawing.Point(0, 0)
        Me.Tool_Top.MinimumSize = New System.Drawing.Size(0, 45)
        Me.Tool_Top.Name = "Tool_Top"
        Me.Tool_Top.Size = New System.Drawing.Size(1024, 45)
        Me.Tool_Top.TabIndex = 10
        Me.Tool_Top.Text = "ToolStrip2"
        '
        'Cmd_Modify
        '
        Me.Cmd_Modify.AccessibleDescription = "修改按钮"
        Me.Cmd_Modify.AccessibleName = ""
        Me.Cmd_Modify.Image = CType(resources.GetObject("Cmd_Modify.Image"), System.Drawing.Image)
        Me.Cmd_Modify.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Modify.Name = "Cmd_Modify"
        Me.Cmd_Modify.Size = New System.Drawing.Size(60, 42)
        Me.Cmd_Modify.Text = "保存"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 45)
        '
        'Cmd_Exit
        '
        Me.Cmd_Exit.Image = CType(resources.GetObject("Cmd_Exit.Image"), System.Drawing.Image)
        Me.Cmd_Exit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(60, 42)
        Me.Cmd_Exit.Text = "关闭"
        '
        'PanelMain
        '
        Me.PanelMain.Controls.Add(Me.SplitContainer1)
        Me.PanelMain.Controls.Add(Me.LabelState)
        Me.PanelMain.Controls.Add(Me.LabelStateT)
        Me.PanelMain.Controls.Add(Me.LabelTitle)
        Me.PanelMain.Controls.Add(Me.DTP_sDate)
        Me.PanelMain.Controls.Add(Me.Label16)
        Me.PanelMain.Controls.Add(Me.TB_ID)
        Me.PanelMain.Controls.Add(Me.Label_ID)
        Me.PanelMain.Controls.Add(Me.Label1)
        Me.PanelMain.Controls.Add(Me.GB_Foot)
        Me.PanelMain.Controls.Add(Me.GroupBox4)
        Me.PanelMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelMain.Location = New System.Drawing.Point(0, 45)
        Me.PanelMain.Name = "PanelMain"
        Me.PanelMain.Padding = New System.Windows.Forms.Padding(2)
        Me.PanelMain.Size = New System.Drawing.Size(1024, 680)
        Me.PanelMain.TabIndex = 0
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.Location = New System.Drawing.Point(3, 50)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.GB_List)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.GroupBox3)
        Me.SplitContainer1.Size = New System.Drawing.Size(1016, 569)
        Me.SplitContainer1.SplitterDistance = 536
        Me.SplitContainer1.TabIndex = 43
        '
        'GB_List
        '
        Me.GB_List.Controls.Add(Me.Panel1)
        Me.GB_List.Controls.Add(Me.Cmd_RowAdd)
        Me.GB_List.Controls.Add(Me.TB_Old_Qty)
        Me.GB_List.Controls.Add(Me.Label14)
        Me.GB_List.Controls.Add(Me.Label2)
        Me.GB_List.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GB_List.Location = New System.Drawing.Point(0, 0)
        Me.GB_List.Name = "GB_List"
        Me.GB_List.Size = New System.Drawing.Size(536, 569)
        Me.GB_List.TabIndex = 9
        Me.GB_List.TabStop = False
        Me.GB_List.Text = "调出仓位"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.Fg1)
        Me.Panel1.Controls.Add(Me.ToolStrip_SearchNo)
        Me.Panel1.Controls.Add(Me.ToolStrip_StoreNo_Old)
        Me.Panel1.Location = New System.Drawing.Point(8, 19)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(522, 511)
        Me.Panel1.TabIndex = 45
        '
        'Fg1
        '
        Me.Fg1.AddCopyMenu = False
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
        Me.Fg1.EditFormat = True
        Me.Fg1.ExtendLastCol = True
        Me.Fg1.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Fg1.ForeColor = System.Drawing.Color.Black
        Me.Fg1.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.Fg1.IsAutoAddRow = True
        Me.Fg1.IsClickStartEdit = False
        Me.Fg1.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.Fg1.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.Fg1.Location = New System.Drawing.Point(0, 50)
        Me.Fg1.Name = "Fg1"
        Me.Fg1.NoShowMenu = False
        Me.Fg1.Rows.Count = 1
        Me.Fg1.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.RowRange
        Me.Fg1.Size = New System.Drawing.Size(522, 461)
        Me.Fg1.StartCol = ""
        Me.Fg1.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("Fg1.Styles"))
        Me.Fg1.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.BelowData
        Me.Fg1.TabIndex = 42
        '
        'ToolStrip_SearchNo
        '
        Me.ToolStrip_SearchNo.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ToolStrip_SearchNo.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton2, Me.TB_SearchNo, Me.Cmd_Clear, Me.Cmd_SearchNo, Me.ToolStripSeparator1})
        Me.ToolStrip_SearchNo.Location = New System.Drawing.Point(0, 25)
        Me.ToolStrip_SearchNo.Name = "ToolStrip_SearchNo"
        Me.ToolStrip_SearchNo.Size = New System.Drawing.Size(522, 25)
        Me.ToolStrip_SearchNo.TabIndex = 44
        Me.ToolStrip_SearchNo.Tag = "0"
        Me.ToolStrip_SearchNo.Text = "ToolStrip1"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton2.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ToolStripButton2.ForeColor = System.Drawing.Color.Black
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(46, 22)
        Me.ToolStripButton2.Text = "单号:"
        Me.ToolStripButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay
        '
        'TB_SearchNo
        '
        Me.TB_SearchNo.Name = "TB_SearchNo"
        Me.TB_SearchNo.Size = New System.Drawing.Size(100, 25)
        '
        'Cmd_Clear
        '
        Me.Cmd_Clear.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Cmd_Clear.Image = Global.DN400_Store.My.Resources.Resources.InValid
        Me.Cmd_Clear.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Clear.Name = "Cmd_Clear"
        Me.Cmd_Clear.Size = New System.Drawing.Size(55, 22)
        Me.Cmd_Clear.Text = "清空"
        '
        'Cmd_SearchNo
        '
        Me.Cmd_SearchNo.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Cmd_SearchNo.Image = Global.DN400_Store.My.Resources.Resources.ReFresh
        Me.Cmd_SearchNo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_SearchNo.Name = "Cmd_SearchNo"
        Me.Cmd_SearchNo.Size = New System.Drawing.Size(55, 22)
        Me.Cmd_SearchNo.Text = "搜索"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStrip_StoreNo_Old
        '
        Me.ToolStrip_StoreNo_Old.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ToolStrip_StoreNo_Old.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Cmd_OldStoreNo, Me.TB_StoreNo_Old, Me.OldStoreNo_All})
        Me.ToolStrip_StoreNo_Old.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip_StoreNo_Old.Name = "ToolStrip_StoreNo_Old"
        Me.ToolStrip_StoreNo_Old.Size = New System.Drawing.Size(522, 25)
        Me.ToolStrip_StoreNo_Old.TabIndex = 0
        Me.ToolStrip_StoreNo_Old.Tag = "0"
        Me.ToolStrip_StoreNo_Old.Text = "ToolStrip1"
        '
        'Cmd_OldStoreNo
        '
        Me.Cmd_OldStoreNo.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Cmd_OldStoreNo.Image = Global.DN400_Store.My.Resources.Resources.ADD
        Me.Cmd_OldStoreNo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_OldStoreNo.Name = "Cmd_OldStoreNo"
        Me.Cmd_OldStoreNo.Size = New System.Drawing.Size(111, 22)
        Me.Cmd_OldStoreNo.Text = "选择调出仓位"
        '
        'TB_StoreNo_Old
        '
        Me.TB_StoreNo_Old.Name = "TB_StoreNo_Old"
        Me.TB_StoreNo_Old.Size = New System.Drawing.Size(50, 25)
        '
        'OldStoreNo_All
        '
        Me.OldStoreNo_All.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.OldStoreNo_All.ForeColor = System.Drawing.Color.Blue
        Me.OldStoreNo_All.Image = CType(resources.GetObject("OldStoreNo_All.Image"), System.Drawing.Image)
        Me.OldStoreNo_All.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.OldStoreNo_All.Name = "OldStoreNo_All"
        Me.OldStoreNo_All.Size = New System.Drawing.Size(41, 22)
        Me.OldStoreNo_All.Text = "全部"
        Me.OldStoreNo_All.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay
        '
        'Cmd_RowAdd
        '
        Me.Cmd_RowAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cmd_RowAdd.Location = New System.Drawing.Point(450, 538)
        Me.Cmd_RowAdd.Name = "Cmd_RowAdd"
        Me.Cmd_RowAdd.Size = New System.Drawing.Size(80, 24)
        Me.Cmd_RowAdd.TabIndex = 43
        Me.Cmd_RowAdd.Text = "添加->"
        Me.Cmd_RowAdd.UseVisualStyleBackColor = True
        '
        'TB_Old_Qty
        '
        Me.TB_Old_Qty.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TB_Old_Qty.Location = New System.Drawing.Point(75, 542)
        Me.TB_Old_Qty.Name = "TB_Old_Qty"
        Me.TB_Old_Qty.ReadOnly = True
        Me.TB_Old_Qty.Size = New System.Drawing.Size(111, 23)
        Me.TB_Old_Qty.TabIndex = 11
        '
        'Label14
        '
        Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(13, 545)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(56, 14)
        Me.Label14.TabIndex = 14
        Me.Label14.Text = "总条数:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(210, 407)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(0, 14)
        Me.Label2.TabIndex = 9
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.SplitContainer2)
        Me.GroupBox3.Controls.Add(Me.ToolStrip_StoreNo_New)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox3.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(476, 569)
        Me.GroupBox3.TabIndex = 46
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "调入仓位"
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(3, 44)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.GroupBox1)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.GroupBox2)
        Me.SplitContainer2.Size = New System.Drawing.Size(470, 522)
        Me.SplitContainer2.SplitterDistance = 226
        Me.SplitContainer2.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Fg2)
        Me.GroupBox1.Controls.Add(Me.TB_Now_Qty)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(470, 226)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "当前仓位的胚布"
        '
        'Fg2
        '
        Me.Fg2.AddCopyMenu = False
        Me.Fg2.AllowEditing = False
        Me.Fg2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Fg2.AutoAddIndex = True
        Me.Fg2.AutoGenerateColumns = False
        Me.Fg2.AutoResize = False
        Me.Fg2.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.Fg2.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.XpThemes
        Me.Fg2.CanEditing = False
        Me.Fg2.CheckKeyPressEdit = True
        Me.Fg2.ColumnInfo = resources.GetString("Fg2.ColumnInfo")
        Me.Fg2.EditFormat = True
        Me.Fg2.ExtendLastCol = True
        Me.Fg2.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Fg2.ForeColor = System.Drawing.Color.Black
        Me.Fg2.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.Fg2.IsAutoAddRow = True
        Me.Fg2.IsClickStartEdit = False
        Me.Fg2.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.Fg2.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.Fg2.Location = New System.Drawing.Point(7, 18)
        Me.Fg2.Name = "Fg2"
        Me.Fg2.NoShowMenu = False
        Me.Fg2.Rows.Count = 1
        Me.Fg2.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.Fg2.Size = New System.Drawing.Size(451, 173)
        Me.Fg2.StartCol = ""
        Me.Fg2.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("Fg2.Styles"))
        Me.Fg2.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.BelowData
        Me.Fg2.TabIndex = 43
        '
        'TB_Now_Qty
        '
        Me.TB_Now_Qty.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TB_Now_Qty.Location = New System.Drawing.Point(144, 197)
        Me.TB_Now_Qty.Name = "TB_Now_Qty"
        Me.TB_Now_Qty.ReadOnly = True
        Me.TB_Now_Qty.Size = New System.Drawing.Size(111, 23)
        Me.TB_Now_Qty.TabIndex = 11
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(66, 200)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 14)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "总条数:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(210, 407)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(0, 14)
        Me.Label11.TabIndex = 9
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Cmd_RowDel)
        Me.GroupBox2.Controls.Add(Me.Fg3)
        Me.GroupBox2.Controls.Add(Me.TB_New_Qty)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(470, 292)
        Me.GroupBox2.TabIndex = 10
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "新加的胚布"
        '
        'Cmd_RowDel
        '
        Me.Cmd_RowDel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Cmd_RowDel.Location = New System.Drawing.Point(6, 264)
        Me.Cmd_RowDel.Name = "Cmd_RowDel"
        Me.Cmd_RowDel.Size = New System.Drawing.Size(80, 24)
        Me.Cmd_RowDel.TabIndex = 45
        Me.Cmd_RowDel.Text = "<-删除"
        Me.Cmd_RowDel.UseVisualStyleBackColor = True
        '
        'Fg3
        '
        Me.Fg3.AddCopyMenu = False
        Me.Fg3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Fg3.AutoAddIndex = True
        Me.Fg3.AutoGenerateColumns = False
        Me.Fg3.AutoResize = False
        Me.Fg3.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.Fg3.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.XpThemes
        Me.Fg3.CanEditing = False
        Me.Fg3.CheckKeyPressEdit = True
        Me.Fg3.ColumnInfo = resources.GetString("Fg3.ColumnInfo")
        Me.Fg3.EditFormat = True
        Me.Fg3.ExtendLastCol = True
        Me.Fg3.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Fg3.ForeColor = System.Drawing.Color.Black
        Me.Fg3.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.Fg3.IsAutoAddRow = True
        Me.Fg3.IsClickStartEdit = False
        Me.Fg3.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.Fg3.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.Fg3.Location = New System.Drawing.Point(7, 12)
        Me.Fg3.Name = "Fg3"
        Me.Fg3.NoShowMenu = False
        Me.Fg3.Rows.Count = 1
        Me.Fg3.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.RowRange
        Me.Fg3.Size = New System.Drawing.Size(451, 244)
        Me.Fg3.StartCol = ""
        Me.Fg3.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("Fg3.Styles"))
        Me.Fg3.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.BelowData
        Me.Fg3.TabIndex = 44
        '
        'TB_New_Qty
        '
        Me.TB_New_Qty.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TB_New_Qty.Location = New System.Drawing.Point(154, 262)
        Me.TB_New_Qty.Name = "TB_New_Qty"
        Me.TB_New_Qty.ReadOnly = True
        Me.TB_New_Qty.Size = New System.Drawing.Size(111, 23)
        Me.TB_New_Qty.TabIndex = 11
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(93, 268)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(56, 14)
        Me.Label12.TabIndex = 14
        Me.Label12.Text = "总条数:"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(210, 407)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(0, 14)
        Me.Label17.TabIndex = 9
        '
        'ToolStrip_StoreNo_New
        '
        Me.ToolStrip_StoreNo_New.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ToolStrip_StoreNo_New.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Cmd_NewStoreNo, Me.TB_StoreNo_New, Me.NewStoreNo_All})
        Me.ToolStrip_StoreNo_New.Location = New System.Drawing.Point(3, 19)
        Me.ToolStrip_StoreNo_New.Name = "ToolStrip_StoreNo_New"
        Me.ToolStrip_StoreNo_New.Size = New System.Drawing.Size(470, 25)
        Me.ToolStrip_StoreNo_New.TabIndex = 1
        Me.ToolStrip_StoreNo_New.Tag = "0"
        Me.ToolStrip_StoreNo_New.Text = "ToolStrip1"
        '
        'Cmd_NewStoreNo
        '
        Me.Cmd_NewStoreNo.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Cmd_NewStoreNo.Image = Global.DN400_Store.My.Resources.Resources.ADD
        Me.Cmd_NewStoreNo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_NewStoreNo.Name = "Cmd_NewStoreNo"
        Me.Cmd_NewStoreNo.Size = New System.Drawing.Size(111, 22)
        Me.Cmd_NewStoreNo.Text = "选择调入仓位"
        '
        'TB_StoreNo_New
        '
        Me.TB_StoreNo_New.Name = "TB_StoreNo_New"
        Me.TB_StoreNo_New.Size = New System.Drawing.Size(50, 25)
        '
        'NewStoreNo_All
        '
        Me.NewStoreNo_All.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.NewStoreNo_All.ForeColor = System.Drawing.Color.Blue
        Me.NewStoreNo_All.Image = CType(resources.GetObject("NewStoreNo_All.Image"), System.Drawing.Image)
        Me.NewStoreNo_All.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.NewStoreNo_All.Name = "NewStoreNo_All"
        Me.NewStoreNo_All.Size = New System.Drawing.Size(41, 22)
        Me.NewStoreNo_All.Text = "全部"
        Me.NewStoreNo_All.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay
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
        'LabelTitle
        '
        Me.LabelTitle.AutoSize = True
        Me.LabelTitle.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LabelTitle.ForeColor = System.Drawing.Color.Blue
        Me.LabelTitle.Location = New System.Drawing.Point(31, 14)
        Me.LabelTitle.Name = "LabelTitle"
        Me.LabelTitle.Size = New System.Drawing.Size(93, 16)
        Me.LabelTitle.TabIndex = 22
        Me.LabelTitle.Text = "仓位调整单"
        '
        'DTP_sDate
        '
        Me.DTP_sDate.Location = New System.Drawing.Point(687, 12)
        Me.DTP_sDate.Name = "DTP_sDate"
        Me.DTP_sDate.Size = New System.Drawing.Size(124, 23)
        Me.DTP_sDate.TabIndex = 18
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(639, 16)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(42, 14)
        Me.Label16.TabIndex = 14
        Me.Label16.Text = "日期:"
        '
        'TB_ID
        '
        Me.TB_ID.Location = New System.Drawing.Point(889, 11)
        Me.TB_ID.Name = "TB_ID"
        Me.TB_ID.Size = New System.Drawing.Size(132, 23)
        Me.TB_ID.TabIndex = 0
        '
        'Label_ID
        '
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
        Me.Label1.Location = New System.Drawing.Point(-4, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(1028, 3)
        Me.Label1.TabIndex = 11
        '
        'GB_Foot
        '
        Me.GB_Foot.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GB_Foot.Controls.Add(Me.TB_Remark)
        Me.GB_Foot.Controls.Add(Me.Label5)
        Me.GB_Foot.Controls.Add(Me.Label8)
        Me.GB_Foot.Controls.Add(Me.TB_ZhiDan)
        Me.GB_Foot.Location = New System.Drawing.Point(8, 621)
        Me.GB_Foot.Name = "GB_Foot"
        Me.GB_Foot.Size = New System.Drawing.Size(1013, 46)
        Me.GB_Foot.TabIndex = 10
        Me.GB_Foot.TabStop = False
        '
        'TB_Remark
        '
        Me.TB_Remark.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TB_Remark.Location = New System.Drawing.Point(238, 16)
        Me.TB_Remark.Name = "TB_Remark"
        Me.TB_Remark.Size = New System.Drawing.Size(770, 23)
        Me.TB_Remark.TabIndex = 28
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(194, 19)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(42, 14)
        Me.Label5.TabIndex = 29
        Me.Label5.Text = "备注:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(29, 19)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(42, 14)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "制单:"
        '
        'TB_ZhiDan
        '
        Me.TB_ZhiDan.Location = New System.Drawing.Point(77, 16)
        Me.TB_ZhiDan.Name = "TB_ZhiDan"
        Me.TB_ZhiDan.ReadOnly = True
        Me.TB_ZhiDan.Size = New System.Drawing.Size(111, 23)
        Me.TB_ZhiDan.TabIndex = 0
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.Fg4)
        Me.GroupBox4.Controls.Add(Me.Label9)
        Me.GroupBox4.Controls.Add(Me.TB_CangWei)
        Me.GroupBox4.Controls.Add(Me.Label7)
        Me.GroupBox4.Controls.Add(Me.TB_Old_CangWei)
        Me.GroupBox4.Location = New System.Drawing.Point(5, 50)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(1014, 569)
        Me.GroupBox4.TabIndex = 44
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "调整明细"
        '
        'Fg4
        '
        Me.Fg4.AddCopyMenu = False
        Me.Fg4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Fg4.AutoAddIndex = True
        Me.Fg4.AutoGenerateColumns = False
        Me.Fg4.AutoResize = False
        Me.Fg4.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.Fg4.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.XpThemes
        Me.Fg4.CanEditing = False
        Me.Fg4.CheckKeyPressEdit = True
        Me.Fg4.ColumnInfo = resources.GetString("Fg4.ColumnInfo")
        Me.Fg4.EditFormat = True
        Me.Fg4.ExtendLastCol = True
        Me.Fg4.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Fg4.ForeColor = System.Drawing.Color.Black
        Me.Fg4.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.Fg4.IsAutoAddRow = True
        Me.Fg4.IsClickStartEdit = False
        Me.Fg4.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.Fg4.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.Fg4.Location = New System.Drawing.Point(3, 51)
        Me.Fg4.Name = "Fg4"
        Me.Fg4.NoShowMenu = False
        Me.Fg4.Rows.Count = 1
        Me.Fg4.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.RowRange
        Me.Fg4.Size = New System.Drawing.Size(1008, 514)
        Me.Fg4.StartCol = ""
        Me.Fg4.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("Fg4.Styles"))
        Me.Fg4.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.BelowData
        Me.Fg4.TabIndex = 45
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(486, 23)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(70, 14)
        Me.Label9.TabIndex = 49
        Me.Label9.Text = "调入仓位:"
        '
        'TB_CangWei
        '
        Me.TB_CangWei.Location = New System.Drawing.Point(562, 19)
        Me.TB_CangWei.Name = "TB_CangWei"
        Me.TB_CangWei.ReadOnly = True
        Me.TB_CangWei.Size = New System.Drawing.Size(248, 23)
        Me.TB_CangWei.TabIndex = 48
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(15, 23)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(70, 14)
        Me.Label7.TabIndex = 47
        Me.Label7.Text = "调出仓位:"
        '
        'TB_Old_CangWei
        '
        Me.TB_Old_CangWei.Location = New System.Drawing.Point(91, 21)
        Me.TB_Old_CangWei.Name = "TB_Old_CangWei"
        Me.TB_Old_CangWei.ReadOnly = True
        Me.TB_Old_CangWei.Size = New System.Drawing.Size(389, 23)
        Me.TB_Old_CangWei.TabIndex = 46
        '
        'F40151_PBTC_Msg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CanMaxSize = True
        Me.Controls.Add(Me.PanelMain)
        Me.Controls.Add(Me.Tool_Top)
        Me.Name = "F40151_PBTC_Msg"
        Me.Size = New System.Drawing.Size(1024, 725)
        Me.Title = "胚布入库单"
        Me.Tool_Top.ResumeLayout(False)
        Me.Tool_Top.PerformLayout()
        Me.PanelMain.ResumeLayout(False)
        Me.PanelMain.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.GB_List.ResumeLayout(False)
        Me.GB_List.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.Fg1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip_SearchNo.ResumeLayout(False)
        Me.ToolStrip_SearchNo.PerformLayout()
        Me.ToolStrip_StoreNo_Old.ResumeLayout(False)
        Me.ToolStrip_StoreNo_Old.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.Fg2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.Fg3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip_StoreNo_New.ResumeLayout(False)
        Me.ToolStrip_StoreNo_New.PerformLayout()
        Me.GB_Foot.ResumeLayout(False)
        Me.GB_Foot.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.Fg4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Tool_Top As System.Windows.Forms.ToolStrip
    Friend WithEvents Cmd_Modify As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_Exit As System.Windows.Forms.ToolStripButton
    Friend WithEvents PanelMain As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GB_Foot As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TB_ID As System.Windows.Forms.TextBox
    Friend WithEvents Label_ID As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents DTP_sDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents LabelTitle As System.Windows.Forms.Label
    Friend WithEvents GB_List As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TB_ZhiDan As System.Windows.Forms.TextBox
    Friend WithEvents LabelState As System.Windows.Forms.Label
    Friend WithEvents LabelStateT As System.Windows.Forms.Label
    Friend WithEvents TB_Old_Qty As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TB_Now_Qty As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TB_New_Qty As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Fg1 As PClass.FG
    Friend WithEvents TB_Remark As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ToolStrip_StoreNo_Old As System.Windows.Forms.ToolStrip
    Friend WithEvents Cmd_OldStoreNo As System.Windows.Forms.ToolStripButton
    Friend WithEvents TB_StoreNo_Old As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents Fg2 As PClass.FG
    Friend WithEvents Fg3 As PClass.FG
    Friend WithEvents Cmd_RowAdd As System.Windows.Forms.Button
    Friend WithEvents Cmd_RowDel As System.Windows.Forms.Button
    Friend WithEvents OldStoreNo_All As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents ToolStrip_StoreNo_New As System.Windows.Forms.ToolStrip
    Friend WithEvents Cmd_NewStoreNo As System.Windows.Forms.ToolStripButton
    Friend WithEvents TB_StoreNo_New As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents NewStoreNo_All As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Fg4 As PClass.FG
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TB_CangWei As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TB_Old_CangWei As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ToolStrip_SearchNo As System.Windows.Forms.ToolStrip
    Friend WithEvents Cmd_SearchNo As System.Windows.Forms.ToolStripButton
    Friend WithEvents TB_SearchNo As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_Clear As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator

End Class
