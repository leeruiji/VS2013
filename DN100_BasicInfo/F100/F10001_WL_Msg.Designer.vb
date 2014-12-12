<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F10001_WL_Msg
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F10001_WL_Msg))
        Me.Tool_Top = New System.Windows.Forms.ToolStrip()
        Me.Cmd_Modify = New System.Windows.Forms.ToolStripButton()
        Me.Cmd_Enable = New System.Windows.Forms.ToolStripButton()
        Me.Cmd_Disable = New System.Windows.Forms.ToolStripButton()
        Me.Cmd_AddRow = New System.Windows.Forms.ToolStripButton()
        Me.Cmd_RemoveRow = New System.Windows.Forms.ToolStripButton()
        Me.Cmd_Del = New System.Windows.Forms.ToolStripButton()
        Me.Cmd_ReNew = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.Cmd_Exit = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.LabelChange = New System.Windows.Forms.ToolStripButton()
        Me.PanelMain = New System.Windows.Forms.Panel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TB_Inner = New System.Windows.Forms.TextBox()
        Me.LB_Inner = New System.Windows.Forms.Label()
        Me.LB_Coat = New System.Windows.Forms.Label()
        Me.TB_Product = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.GB_Material = New System.Windows.Forms.GroupBox()
        Me.Btn_CMaterial = New System.Windows.Forms.Button()
        Me.TB_RSpec = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TB_RID = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.GB_Assemble = New System.Windows.Forms.GroupBox()
        Me.Fg1 = New PClass.FG()
        Me.Cmd_GoodsSel = New System.Windows.Forms.Button()
        Me.CB_Store = New System.Windows.Forms.ComboBox()
        Me.TB_Center = New System.Windows.Forms.TextBox()
        Me.TB_side = New System.Windows.Forms.TextBox()
        Me.TB_material = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.CB_IsSGL = New System.Windows.Forms.CheckBox()
        Me.TB_DownQty = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.CB_IsEP = New System.Windows.Forms.CheckBox()
        Me.CB_IsZJ = New System.Windows.Forms.CheckBox()
        Me.Label_State = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CB_Unit_LL = New System.Windows.Forms.ComboBox()
        Me.CB_Unit = New System.Windows.Forms.ComboBox()
        Me.TB_Qty = New System.Windows.Forms.TextBox()
        Me.Btn_ChoseParent = New System.Windows.Forms.Button()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.TB_Remark = New System.Windows.Forms.TextBox()
        Me.TB_Spec = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TB_ID = New System.Windows.Forms.TextBox()
        Me.Label_ID = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.TB_GoodsType = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LB_FullName = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LB_Contact = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TB_Price = New System.Windows.Forms.TextBox()
        Me.TB_Cost = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LB_Area = New System.Windows.Forms.Label()
        Me.TB_Coat = New System.Windows.Forms.TextBox()
        Me.CB_Name = New BaseClass.ComBoList()
        Me.CB_Supplier = New BaseClass.ComBoList()
        Me.Tool_Top.SuspendLayout()
        Me.PanelMain.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GB_Material.SuspendLayout()
        Me.GB_Assemble.SuspendLayout()
        CType(Me.Fg1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Tool_Top
        '
        Me.Tool_Top.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.Tool_Top.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Cmd_Modify, Me.Cmd_Enable, Me.Cmd_Disable, Me.Cmd_AddRow, Me.Cmd_RemoveRow, Me.Cmd_Del, Me.Cmd_ReNew, Me.ToolStripSeparator5, Me.Cmd_Exit, Me.ToolStripSeparator1, Me.LabelChange})
        Me.Tool_Top.Location = New System.Drawing.Point(0, 0)
        Me.Tool_Top.MinimumSize = New System.Drawing.Size(0, 40)
        Me.Tool_Top.Name = "Tool_Top"
        Me.Tool_Top.Size = New System.Drawing.Size(751, 40)
        Me.Tool_Top.TabIndex = 10
        Me.Tool_Top.Text = "ToolStrip2"
        '
        'Cmd_Modify
        '
        Me.Cmd_Modify.AccessibleDescription = "修改按钮"
        Me.Cmd_Modify.AccessibleName = ""
        Me.Cmd_Modify.Image = Global.DN100_BasicInfo.My.Resources.Resources.Modify
        Me.Cmd_Modify.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Modify.Name = "Cmd_Modify"
        Me.Cmd_Modify.Size = New System.Drawing.Size(60, 37)
        Me.Cmd_Modify.Text = "保存"
        '
        'Cmd_Enable
        '
        Me.Cmd_Enable.Image = Global.DN100_BasicInfo.My.Resources.Resources.bt_play
        Me.Cmd_Enable.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Enable.Name = "Cmd_Enable"
        Me.Cmd_Enable.Size = New System.Drawing.Size(60, 37)
        Me.Cmd_Enable.Text = "启用"
        '
        'Cmd_Disable
        '
        Me.Cmd_Disable.Image = Global.DN100_BasicInfo.My.Resources.Resources.bt_stop
        Me.Cmd_Disable.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Disable.Name = "Cmd_Disable"
        Me.Cmd_Disable.Size = New System.Drawing.Size(60, 37)
        Me.Cmd_Disable.Text = "禁用"
        '
        'Cmd_AddRow
        '
        Me.Cmd_AddRow.Image = Global.DN100_BasicInfo.My.Resources.Resources.AddRow
        Me.Cmd_AddRow.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_AddRow.Name = "Cmd_AddRow"
        Me.Cmd_AddRow.Size = New System.Drawing.Size(60, 37)
        Me.Cmd_AddRow.Text = "增行"
        '
        'Cmd_RemoveRow
        '
        Me.Cmd_RemoveRow.Image = CType(resources.GetObject("Cmd_RemoveRow.Image"), System.Drawing.Image)
        Me.Cmd_RemoveRow.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_RemoveRow.Name = "Cmd_RemoveRow"
        Me.Cmd_RemoveRow.Size = New System.Drawing.Size(60, 37)
        Me.Cmd_RemoveRow.Text = "减行"
        '
        'Cmd_Del
        '
        Me.Cmd_Del.AccessibleDescription = "修改按钮"
        Me.Cmd_Del.AccessibleName = ""
        Me.Cmd_Del.Image = Global.DN100_BasicInfo.My.Resources.Resources.Delete
        Me.Cmd_Del.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Del.Name = "Cmd_Del"
        Me.Cmd_Del.Size = New System.Drawing.Size(60, 37)
        Me.Cmd_Del.Text = "删除"
        '
        'Cmd_ReNew
        '
        Me.Cmd_ReNew.Image = Global.DN100_BasicInfo.My.Resources.Resources.Export
        Me.Cmd_ReNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_ReNew.Name = "Cmd_ReNew"
        Me.Cmd_ReNew.Size = New System.Drawing.Size(60, 37)
        Me.Cmd_ReNew.Text = "更换"
        Me.Cmd_ReNew.Visible = False
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 40)
        '
        'Cmd_Exit
        '
        Me.Cmd_Exit.Image = Global.DN100_BasicInfo.My.Resources.Resources.Close
        Me.Cmd_Exit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(60, 37)
        Me.Cmd_Exit.Text = "关闭"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 40)
        '
        'LabelChange
        '
        Me.LabelChange.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.LabelChange.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.LabelChange.ForeColor = System.Drawing.Color.Red
        Me.LabelChange.Image = CType(resources.GetObject("LabelChange.Image"), System.Drawing.Image)
        Me.LabelChange.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.LabelChange.Name = "LabelChange"
        Me.LabelChange.Size = New System.Drawing.Size(23, 37)
        Me.LabelChange.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        '
        'PanelMain
        '
        Me.PanelMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelMain.Controls.Add(Me.SplitContainer1)
        Me.PanelMain.Location = New System.Drawing.Point(0, 40)
        Me.PanelMain.Name = "PanelMain"
        Me.PanelMain.Padding = New System.Windows.Forms.Padding(2)
        Me.PanelMain.Size = New System.Drawing.Size(751, 420)
        Me.PanelMain.TabIndex = 0
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainer1.Location = New System.Drawing.Point(2, 2)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox2)
        Me.SplitContainer1.Panel1.Padding = New System.Windows.Forms.Padding(5)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.GroupBox1)
        Me.SplitContainer1.Panel2.Padding = New System.Windows.Forms.Padding(5)
        Me.SplitContainer1.Panel2MinSize = 60
        Me.SplitContainer1.Size = New System.Drawing.Size(747, 413)
        Me.SplitContainer1.SplitterDistance = 339
        Me.SplitContainer1.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.TB_Coat)
        Me.GroupBox2.Controls.Add(Me.TB_Inner)
        Me.GroupBox2.Controls.Add(Me.LB_Inner)
        Me.GroupBox2.Controls.Add(Me.LB_Coat)
        Me.GroupBox2.Controls.Add(Me.TB_Product)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.GB_Material)
        Me.GroupBox2.Controls.Add(Me.GB_Assemble)
        Me.GroupBox2.Controls.Add(Me.CB_Name)
        Me.GroupBox2.Controls.Add(Me.CB_Store)
        Me.GroupBox2.Controls.Add(Me.TB_Center)
        Me.GroupBox2.Controls.Add(Me.TB_side)
        Me.GroupBox2.Controls.Add(Me.TB_material)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.CB_IsSGL)
        Me.GroupBox2.Controls.Add(Me.TB_DownQty)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.CB_IsEP)
        Me.GroupBox2.Controls.Add(Me.CB_Supplier)
        Me.GroupBox2.Controls.Add(Me.CB_IsZJ)
        Me.GroupBox2.Controls.Add(Me.Label_State)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.CB_Unit_LL)
        Me.GroupBox2.Controls.Add(Me.CB_Unit)
        Me.GroupBox2.Controls.Add(Me.TB_Qty)
        Me.GroupBox2.Controls.Add(Me.Btn_ChoseParent)
        Me.GroupBox2.Controls.Add(Me.Label24)
        Me.GroupBox2.Controls.Add(Me.TB_Remark)
        Me.GroupBox2.Controls.Add(Me.TB_Spec)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.TB_ID)
        Me.GroupBox2.Controls.Add(Me.Label_ID)
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Controls.Add(Me.TB_GoodsType)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.LB_FullName)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.LB_Contact)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Location = New System.Drawing.Point(5, 5)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(737, 326)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "物料基础信息"
        '
        'TB_Inner
        '
        Me.TB_Inner.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TB_Inner.Location = New System.Drawing.Point(87, 255)
        Me.TB_Inner.Name = "TB_Inner"
        Me.TB_Inner.Size = New System.Drawing.Size(151, 23)
        Me.TB_Inner.TabIndex = 12
        '
        'LB_Inner
        '
        Me.LB_Inner.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LB_Inner.AutoSize = True
        Me.LB_Inner.Location = New System.Drawing.Point(33, 258)
        Me.LB_Inner.Name = "LB_Inner"
        Me.LB_Inner.Size = New System.Drawing.Size(42, 14)
        Me.LB_Inner.TabIndex = 103
        Me.LB_Inner.Text = "内径:"
        '
        'LB_Coat
        '
        Me.LB_Coat.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LB_Coat.AutoSize = True
        Me.LB_Coat.Location = New System.Drawing.Point(269, 258)
        Me.LB_Coat.Name = "LB_Coat"
        Me.LB_Coat.Size = New System.Drawing.Size(42, 14)
        Me.LB_Coat.TabIndex = 101
        Me.LB_Coat.Text = "镀膜:"
        '
        'TB_Product
        '
        Me.TB_Product.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TB_Product.Location = New System.Drawing.Point(85, 149)
        Me.TB_Product.Name = "TB_Product"
        Me.TB_Product.Size = New System.Drawing.Size(151, 23)
        Me.TB_Product.TabIndex = 7
        '
        'Label17
        '
        Me.Label17.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(8, 152)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(70, 14)
        Me.Label17.TabIndex = 85
        Me.Label17.Text = "产品编码:"
        '
        'GB_Material
        '
        Me.GB_Material.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GB_Material.Controls.Add(Me.Btn_CMaterial)
        Me.GB_Material.Controls.Add(Me.TB_RSpec)
        Me.GB_Material.Controls.Add(Me.Label16)
        Me.GB_Material.Controls.Add(Me.TB_RID)
        Me.GB_Material.Controls.Add(Me.Label14)
        Me.GB_Material.Location = New System.Drawing.Point(458, 17)
        Me.GB_Material.Name = "GB_Material"
        Me.GB_Material.Size = New System.Drawing.Size(275, 296)
        Me.GB_Material.TabIndex = 83
        Me.GB_Material.TabStop = False
        Me.GB_Material.Text = "毛坯料信息"
        '
        'Btn_CMaterial
        '
        Me.Btn_CMaterial.Font = New System.Drawing.Font("微软雅黑", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Btn_CMaterial.Location = New System.Drawing.Point(192, 32)
        Me.Btn_CMaterial.Name = "Btn_CMaterial"
        Me.Btn_CMaterial.Size = New System.Drawing.Size(25, 24)
        Me.Btn_CMaterial.TabIndex = 19
        Me.Btn_CMaterial.Text = "..."
        Me.Btn_CMaterial.UseVisualStyleBackColor = True
        '
        'TB_RSpec
        '
        Me.TB_RSpec.Location = New System.Drawing.Point(90, 65)
        Me.TB_RSpec.Name = "TB_RSpec"
        Me.TB_RSpec.Size = New System.Drawing.Size(127, 23)
        Me.TB_RSpec.TabIndex = 15
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(24, 68)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(49, 14)
        Me.Label16.TabIndex = 11
        Me.Label16.Text = "规 格:"
        '
        'TB_RID
        '
        Me.TB_RID.Location = New System.Drawing.Point(90, 32)
        Me.TB_RID.Name = "TB_RID"
        Me.TB_RID.ReadOnly = True
        Me.TB_RID.Size = New System.Drawing.Size(107, 23)
        Me.TB_RID.TabIndex = 14
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.ForeColor = System.Drawing.Color.Blue
        Me.Label14.Location = New System.Drawing.Point(15, 35)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(70, 14)
        Me.Label14.TabIndex = 9
        Me.Label14.Text = "物料编号:"
        '
        'GB_Assemble
        '
        Me.GB_Assemble.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GB_Assemble.Controls.Add(Me.Fg1)
        Me.GB_Assemble.Controls.Add(Me.Cmd_GoodsSel)
        Me.GB_Assemble.Location = New System.Drawing.Point(458, 17)
        Me.GB_Assemble.Name = "GB_Assemble"
        Me.GB_Assemble.Size = New System.Drawing.Size(273, 295)
        Me.GB_Assemble.TabIndex = 82
        Me.GB_Assemble.TabStop = False
        Me.GB_Assemble.Text = "装配组件"
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
        Me.Fg1.CanEditing = True
        Me.Fg1.CheckKeyPressEdit = True
        Me.Fg1.ColumnInfo = resources.GetString("Fg1.ColumnInfo")
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
        Me.Fg1.Location = New System.Drawing.Point(3, 19)
        Me.Fg1.Name = "Fg1"
        Me.Fg1.NoShowMenu = False
        Me.Fg1.Rows.Count = 1
        Me.Fg1.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.Fg1.Size = New System.Drawing.Size(267, 273)
        Me.Fg1.StartCol = ""
        Me.Fg1.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("Fg1.Styles"))
        Me.Fg1.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.BelowData
        Me.Fg1.TabIndex = 17
        '
        'Cmd_GoodsSel
        '
        Me.Cmd_GoodsSel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_GoodsSel.Location = New System.Drawing.Point(117, 52)
        Me.Cmd_GoodsSel.Name = "Cmd_GoodsSel"
        Me.Cmd_GoodsSel.Size = New System.Drawing.Size(17, 20)
        Me.Cmd_GoodsSel.TabIndex = 16
        Me.Cmd_GoodsSel.Text = "…"
        Me.Cmd_GoodsSel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Cmd_GoodsSel.UseVisualStyleBackColor = True
        Me.Cmd_GoodsSel.Visible = False
        '
        'CB_Store
        '
        Me.CB_Store.FormattingEnabled = True
        Me.CB_Store.Location = New System.Drawing.Point(525, 17)
        Me.CB_Store.Name = "CB_Store"
        Me.CB_Store.Size = New System.Drawing.Size(104, 22)
        Me.CB_Store.TabIndex = 16
        Me.CB_Store.Visible = False
        '
        'TB_Center
        '
        Me.TB_Center.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TB_Center.Location = New System.Drawing.Point(87, 115)
        Me.TB_Center.Name = "TB_Center"
        Me.TB_Center.Size = New System.Drawing.Size(150, 23)
        Me.TB_Center.TabIndex = 5
        '
        'TB_side
        '
        Me.TB_side.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TB_side.Location = New System.Drawing.Point(321, 115)
        Me.TB_side.Name = "TB_side"
        Me.TB_side.Size = New System.Drawing.Size(129, 23)
        Me.TB_side.TabIndex = 6
        '
        'TB_material
        '
        Me.TB_material.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TB_material.Location = New System.Drawing.Point(323, 80)
        Me.TB_material.Name = "TB_material"
        Me.TB_material.Size = New System.Drawing.Size(127, 23)
        Me.TB_material.TabIndex = 4
        '
        'Label12
        '
        Me.Label12.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(269, 86)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(42, 14)
        Me.Label12.TabIndex = 77
        Me.Label12.Text = "材质:"
        '
        'Label11
        '
        Me.Label11.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(29, 118)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(49, 14)
        Me.Label11.TabIndex = 76
        Me.Label11.Text = "中 心:"
        '
        'Label10
        '
        Me.Label10.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(288, 118)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(28, 14)
        Me.Label10.TabIndex = 75
        Me.Label10.Text = "边:"
        '
        'CB_IsSGL
        '
        Me.CB_IsSGL.AutoSize = True
        Me.CB_IsSGL.Location = New System.Drawing.Point(550, 205)
        Me.CB_IsSGL.Name = "CB_IsSGL"
        Me.CB_IsSGL.Size = New System.Drawing.Size(68, 18)
        Me.CB_IsSGL.TabIndex = 74
        Me.CB_IsSGL.Text = "手感料"
        Me.CB_IsSGL.UseVisualStyleBackColor = True
        Me.CB_IsSGL.Visible = False
        '
        'TB_DownQty
        '
        Me.TB_DownQty.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TB_DownQty.Location = New System.Drawing.Point(321, 146)
        Me.TB_DownQty.Name = "TB_DownQty"
        Me.TB_DownQty.Size = New System.Drawing.Size(131, 23)
        Me.TB_DownQty.TabIndex = 8
        '
        'Label6
        '
        Me.Label6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(242, 152)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(70, 14)
        Me.Label6.TabIndex = 73
        Me.Label6.Text = "库存下限:"
        '
        'CB_IsEP
        '
        Me.CB_IsEP.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CB_IsEP.AutoSize = True
        Me.CB_IsEP.Location = New System.Drawing.Point(380, 186)
        Me.CB_IsEP.Name = "CB_IsEP"
        Me.CB_IsEP.Size = New System.Drawing.Size(68, 18)
        Me.CB_IsEP.TabIndex = 10
        Me.CB_IsEP.Text = "环保料"
        Me.CB_IsEP.UseVisualStyleBackColor = True
        '
        'CB_IsZJ
        '
        Me.CB_IsZJ.AutoSize = True
        Me.CB_IsZJ.Location = New System.Drawing.Point(552, 184)
        Me.CB_IsZJ.Name = "CB_IsZJ"
        Me.CB_IsZJ.Size = New System.Drawing.Size(68, 18)
        Me.CB_IsZJ.TabIndex = 70
        Me.CB_IsZJ.Text = "按浴比"
        Me.CB_IsZJ.UseVisualStyleBackColor = True
        Me.CB_IsZJ.Visible = False
        '
        'Label_State
        '
        Me.Label_State.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label_State.AutoSize = True
        Me.Label_State.ForeColor = System.Drawing.Color.Blue
        Me.Label_State.Location = New System.Drawing.Point(308, 188)
        Me.Label_State.Name = "Label_State"
        Me.Label_State.Size = New System.Drawing.Size(35, 14)
        Me.Label_State.TabIndex = 69
        Me.Label_State.Text = "启用"
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(260, 188)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 14)
        Me.Label2.TabIndex = 68
        Me.Label2.Text = "状态:"
        '
        'CB_Unit_LL
        '
        Me.CB_Unit_LL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_Unit_LL.FormattingEnabled = True
        Me.CB_Unit_LL.Items.AddRange(New Object() {"个", "kg"})
        Me.CB_Unit_LL.Location = New System.Drawing.Point(527, 243)
        Me.CB_Unit_LL.Name = "CB_Unit_LL"
        Me.CB_Unit_LL.Size = New System.Drawing.Size(102, 22)
        Me.CB_Unit_LL.TabIndex = 6
        Me.CB_Unit_LL.Visible = False
        '
        'CB_Unit
        '
        Me.CB_Unit.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CB_Unit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_Unit.FormattingEnabled = True
        Me.CB_Unit.Items.AddRange(New Object() {"个", "kg"})
        Me.CB_Unit.Location = New System.Drawing.Point(83, 185)
        Me.CB_Unit.Name = "CB_Unit"
        Me.CB_Unit.Size = New System.Drawing.Size(127, 22)
        Me.CB_Unit.TabIndex = 9
        '
        'TB_Qty
        '
        Me.TB_Qty.Location = New System.Drawing.Point(527, 118)
        Me.TB_Qty.Name = "TB_Qty"
        Me.TB_Qty.ReadOnly = True
        Me.TB_Qty.Size = New System.Drawing.Size(102, 23)
        Me.TB_Qty.TabIndex = 7
        Me.TB_Qty.Visible = False
        '
        'Btn_ChoseParent
        '
        Me.Btn_ChoseParent.Font = New System.Drawing.Font("微软雅黑", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Btn_ChoseParent.Location = New System.Drawing.Point(213, 16)
        Me.Btn_ChoseParent.Name = "Btn_ChoseParent"
        Me.Btn_ChoseParent.Size = New System.Drawing.Size(25, 24)
        Me.Btn_ChoseParent.TabIndex = 18
        Me.Btn_ChoseParent.Text = "..."
        Me.Btn_ChoseParent.UseVisualStyleBackColor = True
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(535, 92)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(70, 14)
        Me.Label24.TabIndex = 67
        Me.Label24.Text = "仓库结存:"
        Me.Label24.Visible = False
        '
        'TB_Remark
        '
        Me.TB_Remark.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TB_Remark.Location = New System.Drawing.Point(86, 218)
        Me.TB_Remark.Name = "TB_Remark"
        Me.TB_Remark.Size = New System.Drawing.Size(364, 23)
        Me.TB_Remark.TabIndex = 11
        '
        'TB_Spec
        '
        Me.TB_Spec.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TB_Spec.Location = New System.Drawing.Point(86, 83)
        Me.TB_Spec.Name = "TB_Spec"
        Me.TB_Spec.Size = New System.Drawing.Size(151, 23)
        Me.TB_Spec.TabIndex = 3
        '
        'Label8
        '
        Me.Label8.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(29, 86)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(49, 14)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "规 格:"
        '
        'TB_ID
        '
        Me.TB_ID.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TB_ID.Location = New System.Drawing.Point(323, 16)
        Me.TB_ID.Name = "TB_ID"
        Me.TB_ID.ReadOnly = True
        Me.TB_ID.Size = New System.Drawing.Size(127, 23)
        Me.TB_ID.TabIndex = 100
        '
        'Label_ID
        '
        Me.Label_ID.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label_ID.AutoSize = True
        Me.Label_ID.ForeColor = System.Drawing.Color.Blue
        Me.Label_ID.Location = New System.Drawing.Point(248, 19)
        Me.Label_ID.Name = "Label_ID"
        Me.Label_ID.Size = New System.Drawing.Size(70, 14)
        Me.Label_ID.TabIndex = 7
        Me.Label_ID.Text = "物料编号:"
        '
        'Label19
        '
        Me.Label19.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(38, 222)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(42, 14)
        Me.Label19.TabIndex = 6
        Me.Label19.Text = "备注:"
        '
        'TB_GoodsType
        '
        Me.TB_GoodsType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TB_GoodsType.Location = New System.Drawing.Point(87, 17)
        Me.TB_GoodsType.Name = "TB_GoodsType"
        Me.TB_GoodsType.ReadOnly = True
        Me.TB_GoodsType.Size = New System.Drawing.Size(138, 23)
        Me.TB_GoodsType.TabIndex = 99
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 14)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "物料分类:"
        '
        'LB_FullName
        '
        Me.LB_FullName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LB_FullName.AutoSize = True
        Me.LB_FullName.Location = New System.Drawing.Point(29, 57)
        Me.LB_FullName.Name = "LB_FullName"
        Me.LB_FullName.Size = New System.Drawing.Size(49, 14)
        Me.LB_FullName.TabIndex = 5
        Me.LB_FullName.Text = "品 名:"
        '
        'Label15
        '
        Me.Label15.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(168, 163)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(0, 14)
        Me.Label15.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(260, 53)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 14)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "供应商:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(549, 226)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 14)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "领料单位:"
        Me.Label3.Visible = False
        '
        'LB_Contact
        '
        Me.LB_Contact.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LB_Contact.AutoSize = True
        Me.LB_Contact.Location = New System.Drawing.Point(29, 188)
        Me.LB_Contact.Name = "LB_Contact"
        Me.LB_Contact.Size = New System.Drawing.Size(49, 14)
        Me.LB_Contact.TabIndex = 4
        Me.LB_Contact.Text = "单 位:"
        '
        'Label9
        '
        Me.Label9.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(168, 162)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(0, 14)
        Me.Label9.TabIndex = 9
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.TB_Price)
        Me.GroupBox1.Controls.Add(Me.TB_Cost)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(737, 54)
        Me.GroupBox1.TabIndex = 69
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "物料单价"
        Me.GroupBox1.Visible = False
        '
        'TB_Price
        '
        Me.TB_Price.Location = New System.Drawing.Point(365, 22)
        Me.TB_Price.Name = "TB_Price"
        Me.TB_Price.Size = New System.Drawing.Size(151, 23)
        Me.TB_Price.TabIndex = 102
        '
        'TB_Cost
        '
        Me.TB_Cost.Location = New System.Drawing.Point(107, 22)
        Me.TB_Cost.Name = "TB_Cost"
        Me.TB_Cost.ReadOnly = True
        Me.TB_Cost.Size = New System.Drawing.Size(152, 23)
        Me.TB_Cost.TabIndex = 101
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(35, 25)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(70, 14)
        Me.Label7.TabIndex = 68
        Me.Label7.Text = "平均成本:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(296, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 14)
        Me.Label4.TabIndex = 66
        Me.Label4.Text = "参考单价:"
        '
        'LB_Area
        '
        Me.LB_Area.AutoSize = True
        Me.LB_Area.Location = New System.Drawing.Point(265, 34)
        Me.LB_Area.Name = "LB_Area"
        Me.LB_Area.Size = New System.Drawing.Size(70, 14)
        Me.LB_Area.TabIndex = 7
        Me.LB_Area.Text = "默认仓库:"
        Me.LB_Area.Visible = False
        '
        'TB_Coat
        '
        Me.TB_Coat.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TB_Coat.Location = New System.Drawing.Point(323, 254)
        Me.TB_Coat.Name = "TB_Coat"
        Me.TB_Coat.Size = New System.Drawing.Size(129, 23)
        Me.TB_Coat.TabIndex = 13
        '
        'CB_Name
        '
        Me.CB_Name.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CB_Name.Child = "ComboWL_Name"
        Me.CB_Name.FormattingEnabled = True
        Me.CB_Name.IDAsInt = CType(0, Long)
        Me.CB_Name.IDValue = ""
        Me.CB_Name.IsKeyDownAutoSearch = True
        Me.CB_Name.Location = New System.Drawing.Point(86, 52)
        Me.CB_Name.Name = "CB_Name"
        Me.CB_Name.Size = New System.Drawing.Size(151, 22)
        Me.CB_Name.TabIndex = 1
        '
        'CB_Supplier
        '
        Me.CB_Supplier.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CB_Supplier.Child = "ComboSupplier"
        Me.CB_Supplier.FormattingEnabled = True
        Me.CB_Supplier.IDAsInt = CType(0, Long)
        Me.CB_Supplier.IDValue = ""
        Me.CB_Supplier.IsKeyDownAutoSearch = True
        Me.CB_Supplier.Location = New System.Drawing.Point(323, 49)
        Me.CB_Supplier.Name = "CB_Supplier"
        Me.CB_Supplier.Size = New System.Drawing.Size(127, 22)
        Me.CB_Supplier.TabIndex = 2
        '
        'F10001_WL_Msg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.PanelMain)
        Me.Controls.Add(Me.Tool_Top)
        Me.Controls.Add(Me.LB_Area)
        Me.Name = "F10001_WL_Msg"
        Me.Size = New System.Drawing.Size(751, 463)
        Me.Title = "物料详细信息"
        Me.Tool_Top.ResumeLayout(False)
        Me.Tool_Top.PerformLayout()
        Me.PanelMain.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GB_Material.ResumeLayout(False)
        Me.GB_Material.PerformLayout()
        Me.GB_Assemble.ResumeLayout(False)
        CType(Me.Fg1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Tool_Top As System.Windows.Forms.ToolStrip
    Friend WithEvents Cmd_Modify As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_Del As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Cmd_Exit As System.Windows.Forms.ToolStripButton
    Friend WithEvents PanelMain As System.Windows.Forms.Panel
    Friend WithEvents TB_GoodsType As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LB_FullName As System.Windows.Forms.Label
    Friend WithEvents LB_Contact As System.Windows.Forms.Label
    Friend WithEvents TB_Remark As System.Windows.Forms.TextBox
    Friend WithEvents TB_ID As System.Windows.Forms.TextBox
    Friend WithEvents LB_Area As System.Windows.Forms.Label
    Friend WithEvents Label_ID As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents CB_Store As System.Windows.Forms.ComboBox
    Friend WithEvents Btn_ChoseParent As System.Windows.Forms.Button
    Friend WithEvents CB_Unit As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TB_Price As System.Windows.Forms.TextBox
    Friend WithEvents TB_Qty As System.Windows.Forms.TextBox
    Friend WithEvents TB_Cost As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label_State As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Cmd_Disable As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_Enable As System.Windows.Forms.ToolStripButton
    Friend WithEvents CB_Unit_LL As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label

    Friend WithEvents CB_IsZJ As System.Windows.Forms.CheckBox
    Friend WithEvents Cmd_ReNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents LabelChange As System.Windows.Forms.ToolStripButton
    Friend WithEvents CB_Supplier As BaseClass.ComBoList
    Friend WithEvents CB_IsEP As System.Windows.Forms.CheckBox
    Friend WithEvents TB_DownQty As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GoodsTypeTree1 As DN100_BasicInfo.GoodsTypeTree
    Friend WithEvents CB_IsSGL As System.Windows.Forms.CheckBox
    Friend WithEvents TB_Center As System.Windows.Forms.TextBox
    Friend WithEvents TB_side As System.Windows.Forms.TextBox
    Friend WithEvents TB_material As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents CB_Name As BaseClass.ComBoList
    Friend WithEvents GB_Assemble As System.Windows.Forms.GroupBox
    Friend WithEvents Cmd_GoodsSel As System.Windows.Forms.Button
    Friend WithEvents Fg1 As PClass.FG
    Friend WithEvents GB_Material As System.Windows.Forms.GroupBox
    Friend WithEvents TB_RSpec As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents TB_RID As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Btn_CMaterial As System.Windows.Forms.Button
    Friend WithEvents Cmd_AddRow As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_RemoveRow As System.Windows.Forms.ToolStripButton
    Friend WithEvents TB_Product As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents TB_Spec As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents LB_Coat As System.Windows.Forms.Label
    Friend WithEvents TB_Inner As System.Windows.Forms.TextBox
    Friend WithEvents LB_Inner As System.Windows.Forms.Label
    Friend WithEvents TB_Coat As System.Windows.Forms.TextBox
End Class
