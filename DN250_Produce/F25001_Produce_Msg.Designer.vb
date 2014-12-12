<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F25001_Produce_Msg
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F25001_Produce_Msg))
        Me.Tool_Top = New System.Windows.Forms.ToolStrip
        Me.Cmd_Modify = New System.Windows.Forms.ToolStripButton
        Me.Cmd_Del = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.Btn_AddRow = New System.Windows.Forms.ToolStripButton
        Me.Btn_RemoveRow = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.Cmd_Exit = New System.Windows.Forms.ToolStripButton
        Me.PanelMain = New System.Windows.Forms.Panel
        Me.TB_SumQTY = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TB_Project = New System.Windows.Forms.TextBox
        Me.TB_SumProductQty = New System.Windows.Forms.TextBox
        Me.Fg2 = New PClass.FG
        Me.Label17 = New System.Windows.Forms.Label
        Me.ListBox_Show = New System.Windows.Forms.ListBox
        Me.LabelTitle = New System.Windows.Forms.Label
        Me.DP_Date = New System.Windows.Forms.DateTimePicker
        Me.Label16 = New System.Windows.Forms.Label
        Me.TB_ID = New System.Windows.Forms.TextBox
        Me.Label_ID = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label_Produce = New System.Windows.Forms.Label
        Me.GB_List = New System.Windows.Forms.GroupBox
        Me.PanelFG = New System.Windows.Forms.Panel
        Me.Btn_GoodsSel = New System.Windows.Forms.Button
        Me.Fg1 = New PClass.FG
        Me.Label2 = New System.Windows.Forms.Label
        Me.GB_Foot = New System.Windows.Forms.GroupBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.TB_Remark = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.CB_Operator = New System.Windows.Forms.ComboBox
        Me.CB_YanShou = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.CB_KuaiJi = New System.Windows.Forms.ComboBox
        Me.CB_ChuNa = New System.Windows.Forms.ComboBox
        Me.CB_FuHe = New System.Windows.Forms.ComboBox
        Me.CB_JiZhang = New System.Windows.Forms.ComboBox
        Me.TimerCombox = New System.Windows.Forms.Timer(Me.components)
        Me.TimerFGLostFocus = New System.Windows.Forms.Timer(Me.components)
        Me.TimerGoods = New System.Windows.Forms.Timer(Me.components)
        Me.Tool_Top.SuspendLayout()
        Me.PanelMain.SuspendLayout()
        CType(Me.Fg2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GB_List.SuspendLayout()
        Me.PanelFG.SuspendLayout()
        CType(Me.Fg1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GB_Foot.SuspendLayout()
        Me.SuspendLayout()
        '
        'Tool_Top
        '
        Me.Tool_Top.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.Tool_Top.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Cmd_Modify, Me.Cmd_Del, Me.ToolStripSeparator2, Me.Btn_AddRow, Me.Btn_RemoveRow, Me.ToolStripSeparator5, Me.Cmd_Exit})
        Me.Tool_Top.Location = New System.Drawing.Point(0, 0)
        Me.Tool_Top.MinimumSize = New System.Drawing.Size(0, 58)
        Me.Tool_Top.Name = "Tool_Top"
        Me.Tool_Top.Size = New System.Drawing.Size(1024, 58)
        Me.Tool_Top.TabIndex = 10
        Me.Tool_Top.Text = "ToolStrip2"
        '
        'Cmd_Modify
        '
        Me.Cmd_Modify.AccessibleDescription = "修改按钮"
        Me.Cmd_Modify.AccessibleName = ""
        Me.Cmd_Modify.Image = Global.DN250_Produce.My.Resources.Resources.Modify
        Me.Cmd_Modify.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Modify.Name = "Cmd_Modify"
        Me.Cmd_Modify.Size = New System.Drawing.Size(33, 55)
        Me.Cmd_Modify.Text = "保存"
        Me.Cmd_Modify.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'Cmd_Del
        '
        Me.Cmd_Del.AccessibleDescription = "修改按钮"
        Me.Cmd_Del.AccessibleName = ""
        Me.Cmd_Del.Image = Global.DN250_Produce.My.Resources.Resources.Delete
        Me.Cmd_Del.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Del.Name = "Cmd_Del"
        Me.Cmd_Del.Size = New System.Drawing.Size(33, 55)
        Me.Cmd_Del.Text = "删除"
        Me.Cmd_Del.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 58)
        '
        'Btn_AddRow
        '
        Me.Btn_AddRow.Image = CType(resources.GetObject("Btn_AddRow.Image"), System.Drawing.Image)
        Me.Btn_AddRow.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Btn_AddRow.Name = "Btn_AddRow"
        Me.Btn_AddRow.Size = New System.Drawing.Size(33, 55)
        Me.Btn_AddRow.Text = "增行"
        Me.Btn_AddRow.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'Btn_RemoveRow
        '
        Me.Btn_RemoveRow.Image = CType(resources.GetObject("Btn_RemoveRow.Image"), System.Drawing.Image)
        Me.Btn_RemoveRow.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Btn_RemoveRow.Name = "Btn_RemoveRow"
        Me.Btn_RemoveRow.Size = New System.Drawing.Size(33, 55)
        Me.Btn_RemoveRow.Text = "减行"
        Me.Btn_RemoveRow.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 58)
        '
        'Cmd_Exit
        '
        Me.Cmd_Exit.Image = Global.DN250_Produce.My.Resources.Resources.Close
        Me.Cmd_Exit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(33, 55)
        Me.Cmd_Exit.Text = "关闭"
        Me.Cmd_Exit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'PanelMain
        '
        Me.PanelMain.Controls.Add(Me.TB_SumQTY)
        Me.PanelMain.Controls.Add(Me.Label3)
        Me.PanelMain.Controls.Add(Me.TB_Project)
        Me.PanelMain.Controls.Add(Me.TB_SumProductQty)
        Me.PanelMain.Controls.Add(Me.Fg2)
        Me.PanelMain.Controls.Add(Me.Label17)
        Me.PanelMain.Controls.Add(Me.ListBox_Show)
        Me.PanelMain.Controls.Add(Me.LabelTitle)
        Me.PanelMain.Controls.Add(Me.DP_Date)
        Me.PanelMain.Controls.Add(Me.Label16)
        Me.PanelMain.Controls.Add(Me.TB_ID)
        Me.PanelMain.Controls.Add(Me.Label_ID)
        Me.PanelMain.Controls.Add(Me.Label1)
        Me.PanelMain.Controls.Add(Me.Label_Produce)
        Me.PanelMain.Controls.Add(Me.GB_List)
        Me.PanelMain.Controls.Add(Me.GB_Foot)
        Me.PanelMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelMain.Location = New System.Drawing.Point(0, 58)
        Me.PanelMain.Name = "PanelMain"
        Me.PanelMain.Padding = New System.Windows.Forms.Padding(2)
        Me.PanelMain.Size = New System.Drawing.Size(1024, 592)
        Me.PanelMain.TabIndex = 12
        '
        'TB_SumQTY
        '
        Me.TB_SumQTY.Location = New System.Drawing.Point(506, 57)
        Me.TB_SumQTY.Name = "TB_SumQTY"
        Me.TB_SumQTY.ReadOnly = True
        Me.TB_SumQTY.Size = New System.Drawing.Size(111, 23)
        Me.TB_SumQTY.TabIndex = 24
        Me.TB_SumQTY.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(430, 60)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 14)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "切片平方:"
        Me.Label3.Visible = False
        '
        'TB_Project
        '
        Me.TB_Project.Location = New System.Drawing.Point(82, 56)
        Me.TB_Project.Name = "TB_Project"
        Me.TB_Project.Size = New System.Drawing.Size(227, 23)
        Me.TB_Project.TabIndex = 23
        '
        'TB_SumProductQty
        '
        Me.TB_SumProductQty.Location = New System.Drawing.Point(722, 57)
        Me.TB_SumProductQty.Name = "TB_SumProductQty"
        Me.TB_SumProductQty.ReadOnly = True
        Me.TB_SumProductQty.Size = New System.Drawing.Size(111, 23)
        Me.TB_SumProductQty.TabIndex = 5
        Me.TB_SumProductQty.Visible = False
        '
        'Fg2
        '
        Me.Fg2.AutoAddIndex = False
        Me.Fg2.AutoGenerateColumns = False
        Me.Fg2.AutoResize = False
        Me.Fg2.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.Fg2.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.None
        Me.Fg2.CanEditing = False
        Me.Fg2.ColumnInfo = resources.GetString("Fg2.ColumnInfo")
        Me.Fg2.ExtendLastCol = True
        Me.Fg2.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Fg2.ForeColor = System.Drawing.Color.Black
        Me.Fg2.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.Fg2.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.Fg2.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.Fg2.Location = New System.Drawing.Point(43, 146)
        Me.Fg2.Name = "Fg2"
        Me.Fg2.Rows.Count = 10
        Me.Fg2.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.Fg2.Size = New System.Drawing.Size(266, 241)
        Me.Fg2.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("Fg2.Styles"))
        Me.Fg2.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.BelowData
        Me.Fg2.TabIndex = 14
        Me.Fg2.Visible = False
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(646, 60)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(70, 14)
        Me.Label17.TabIndex = 9
        Me.Label17.Text = "合计平方:"
        Me.Label17.Visible = False
        '
        'ListBox_Show
        '
        Me.ListBox_Show.DisplayMember = "col"
        Me.ListBox_Show.FormattingEnabled = True
        Me.ListBox_Show.ItemHeight = 14
        Me.ListBox_Show.Location = New System.Drawing.Point(362, 182)
        Me.ListBox_Show.Name = "ListBox_Show"
        Me.ListBox_Show.Size = New System.Drawing.Size(97, 144)
        Me.ListBox_Show.TabIndex = 14
        Me.ListBox_Show.ValueMember = "col"
        Me.ListBox_Show.Visible = False
        '
        'LabelTitle
        '
        Me.LabelTitle.AutoSize = True
        Me.LabelTitle.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LabelTitle.ForeColor = System.Drawing.Color.Blue
        Me.LabelTitle.Location = New System.Drawing.Point(31, 14)
        Me.LabelTitle.Name = "LabelTitle"
        Me.LabelTitle.Size = New System.Drawing.Size(59, 16)
        Me.LabelTitle.TabIndex = 22
        Me.LabelTitle.Text = "生产单"
        '
        'DP_Date
        '
        Me.DP_Date.Location = New System.Drawing.Point(687, 12)
        Me.DP_Date.Name = "DP_Date"
        Me.DP_Date.Size = New System.Drawing.Size(124, 23)
        Me.DP_Date.TabIndex = 18
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
        Me.TB_ID.TabIndex = 15
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
        Me.Label1.Location = New System.Drawing.Point(-4, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(1028, 3)
        Me.Label1.TabIndex = 11
        '
        'Label_Produce
        '
        Me.Label_Produce.AutoSize = True
        Me.Label_Produce.Location = New System.Drawing.Point(6, 60)
        Me.Label_Produce.Name = "Label_Produce"
        Me.Label_Produce.Size = New System.Drawing.Size(70, 14)
        Me.Label_Produce.TabIndex = 13
        Me.Label_Produce.Text = "项目名称:"
        '
        'GB_List
        '
        Me.GB_List.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GB_List.Controls.Add(Me.PanelFG)
        Me.GB_List.Controls.Add(Me.Label2)
        Me.GB_List.Location = New System.Drawing.Point(5, 84)
        Me.GB_List.Name = "GB_List"
        Me.GB_List.Size = New System.Drawing.Size(1019, 358)
        Me.GB_List.TabIndex = 4
        Me.GB_List.TabStop = False
        '
        'PanelFG
        '
        Me.PanelFG.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelFG.Controls.Add(Me.Btn_GoodsSel)
        Me.PanelFG.Controls.Add(Me.Fg1)
        Me.PanelFG.Location = New System.Drawing.Point(6, 22)
        Me.PanelFG.Name = "PanelFG"
        Me.PanelFG.Padding = New System.Windows.Forms.Padding(1)
        Me.PanelFG.Size = New System.Drawing.Size(1007, 330)
        Me.PanelFG.TabIndex = 15
        '
        'Btn_GoodsSel
        '
        Me.Btn_GoodsSel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_GoodsSel.Location = New System.Drawing.Point(188, 87)
        Me.Btn_GoodsSel.Name = "Btn_GoodsSel"
        Me.Btn_GoodsSel.Size = New System.Drawing.Size(17, 20)
        Me.Btn_GoodsSel.TabIndex = 13
        Me.Btn_GoodsSel.Text = "…"
        Me.Btn_GoodsSel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Btn_GoodsSel.UseVisualStyleBackColor = True
        Me.Btn_GoodsSel.Visible = False
        '
        'Fg1
        '
        Me.Fg1.AllowEditing = False
        Me.Fg1.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.Fg1.AutoAddIndex = True
        Me.Fg1.AutoGenerateColumns = False
        Me.Fg1.AutoResize = False
        Me.Fg1.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.Fg1.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.XpThemes
        Me.Fg1.CanEditing = True
        Me.Fg1.ColumnInfo = resources.GetString("Fg1.ColumnInfo")
        Me.Fg1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Fg1.ExtendLastCol = True
        Me.Fg1.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Fg1.ForeColor = System.Drawing.Color.Black
        Me.Fg1.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.Fg1.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.Fg1.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.Fg1.Location = New System.Drawing.Point(1, 1)
        Me.Fg1.Name = "Fg1"
        Me.Fg1.Rows.Count = 10
        Me.Fg1.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.Fg1.Size = New System.Drawing.Size(1005, 328)
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
        Me.GB_Foot.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GB_Foot.Controls.Add(Me.Label13)
        Me.GB_Foot.Controls.Add(Me.Label12)
        Me.GB_Foot.Controls.Add(Me.Label11)
        Me.GB_Foot.Controls.Add(Me.Label10)
        Me.GB_Foot.Controls.Add(Me.TB_Remark)
        Me.GB_Foot.Controls.Add(Me.Label9)
        Me.GB_Foot.Controls.Add(Me.Label8)
        Me.GB_Foot.Controls.Add(Me.CB_Operator)
        Me.GB_Foot.Controls.Add(Me.CB_YanShou)
        Me.GB_Foot.Controls.Add(Me.Label5)
        Me.GB_Foot.Controls.Add(Me.CB_KuaiJi)
        Me.GB_Foot.Controls.Add(Me.CB_ChuNa)
        Me.GB_Foot.Controls.Add(Me.CB_FuHe)
        Me.GB_Foot.Controls.Add(Me.CB_JiZhang)
        Me.GB_Foot.Location = New System.Drawing.Point(0, 449)
        Me.GB_Foot.Name = "GB_Foot"
        Me.GB_Foot.Size = New System.Drawing.Size(1024, 100)
        Me.GB_Foot.TabIndex = 3
        Me.GB_Foot.TabStop = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(232, 58)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(42, 14)
        Me.Label13.TabIndex = 13
        Me.Label13.Text = "制单:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(34, 58)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(42, 14)
        Me.Label12.TabIndex = 13
        Me.Label12.Text = "验收:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(631, 19)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(42, 14)
        Me.Label11.TabIndex = 13
        Me.Label11.Text = "会计:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(415, 19)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(42, 14)
        Me.Label10.TabIndex = 13
        Me.Label10.Text = "出纳:"
        '
        'TB_Remark
        '
        Me.TB_Remark.Location = New System.Drawing.Point(483, 55)
        Me.TB_Remark.Name = "TB_Remark"
        Me.TB_Remark.Size = New System.Drawing.Size(307, 23)
        Me.TB_Remark.TabIndex = 6
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(235, 19)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(42, 14)
        Me.Label9.TabIndex = 13
        Me.Label9.Text = "复核:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(34, 19)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(42, 14)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "记账:"
        '
        'CB_Operator
        '
        Me.CB_Operator.DisplayMember = "Employee_Name"
        Me.CB_Operator.Enabled = False
        Me.CB_Operator.FormattingEnabled = True
        Me.CB_Operator.Location = New System.Drawing.Point(280, 55)
        Me.CB_Operator.Name = "CB_Operator"
        Me.CB_Operator.Size = New System.Drawing.Size(111, 22)
        Me.CB_Operator.TabIndex = 5
        Me.CB_Operator.ValueMember = "Employee_ID"
        '
        'CB_YanShou
        '
        Me.CB_YanShou.DisplayMember = "Employee_Name"
        Me.CB_YanShou.FormattingEnabled = True
        Me.CB_YanShou.Location = New System.Drawing.Point(82, 55)
        Me.CB_YanShou.Name = "CB_YanShou"
        Me.CB_YanShou.Size = New System.Drawing.Size(111, 22)
        Me.CB_YanShou.TabIndex = 4
        Me.CB_YanShou.ValueMember = "Employee_ID"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(415, 58)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(42, 14)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "备注:"
        '
        'CB_KuaiJi
        '
        Me.CB_KuaiJi.DisplayMember = "Employee_Name"
        Me.CB_KuaiJi.FormattingEnabled = True
        Me.CB_KuaiJi.Location = New System.Drawing.Point(679, 16)
        Me.CB_KuaiJi.Name = "CB_KuaiJi"
        Me.CB_KuaiJi.Size = New System.Drawing.Size(111, 22)
        Me.CB_KuaiJi.TabIndex = 3
        Me.CB_KuaiJi.ValueMember = "Employee_ID"
        '
        'CB_ChuNa
        '
        Me.CB_ChuNa.DisplayMember = "Employee_Name"
        Me.CB_ChuNa.FormattingEnabled = True
        Me.CB_ChuNa.Location = New System.Drawing.Point(483, 16)
        Me.CB_ChuNa.Name = "CB_ChuNa"
        Me.CB_ChuNa.Size = New System.Drawing.Size(111, 22)
        Me.CB_ChuNa.TabIndex = 2
        Me.CB_ChuNa.ValueMember = "Employee_ID"
        '
        'CB_FuHe
        '
        Me.CB_FuHe.DisplayMember = "Employee_Name"
        Me.CB_FuHe.FormattingEnabled = True
        Me.CB_FuHe.Location = New System.Drawing.Point(283, 16)
        Me.CB_FuHe.Name = "CB_FuHe"
        Me.CB_FuHe.Size = New System.Drawing.Size(111, 22)
        Me.CB_FuHe.TabIndex = 1
        Me.CB_FuHe.ValueMember = "Employee_ID"
        '
        'CB_JiZhang
        '
        Me.CB_JiZhang.DisplayMember = "Employee_Name"
        Me.CB_JiZhang.FormattingEnabled = True
        Me.CB_JiZhang.Location = New System.Drawing.Point(82, 16)
        Me.CB_JiZhang.Name = "CB_JiZhang"
        Me.CB_JiZhang.Size = New System.Drawing.Size(111, 22)
        Me.CB_JiZhang.TabIndex = 0
        Me.CB_JiZhang.ValueMember = "Employee_ID"
        '
        'TimerCombox
        '
        Me.TimerCombox.Interval = 1
        '
        'TimerFGLostFocus
        '
        Me.TimerFGLostFocus.Interval = 50
        '
        'TimerGoods
        '
        Me.TimerGoods.Interval = 1
        '
        'F25001_Produce_Msg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.PanelMain)
        Me.Controls.Add(Me.Tool_Top)
        Me.Name = "F25001_Produce_Msg"
        Me.Size = New System.Drawing.Size(1024, 650)
        Me.Title = "生产单详细信息"
        Me.Tool_Top.ResumeLayout(False)
        Me.Tool_Top.PerformLayout()
        Me.PanelMain.ResumeLayout(False)
        Me.PanelMain.PerformLayout()
        CType(Me.Fg2, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents Label_Produce As System.Windows.Forms.Label
    Friend WithEvents GB_List As System.Windows.Forms.GroupBox
    Friend WithEvents Fg1 As PClass.FG
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TB_Remark As System.Windows.Forms.TextBox
    Friend WithEvents GB_Foot As System.Windows.Forms.GroupBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents CB_Operator As System.Windows.Forms.ComboBox
    Friend WithEvents CB_YanShou As System.Windows.Forms.ComboBox
    Friend WithEvents CB_KuaiJi As System.Windows.Forms.ComboBox
    Friend WithEvents CB_ChuNa As System.Windows.Forms.ComboBox
    Friend WithEvents CB_FuHe As System.Windows.Forms.ComboBox
    Friend WithEvents CB_JiZhang As System.Windows.Forms.ComboBox
    Friend WithEvents TB_ID As System.Windows.Forms.TextBox
    Friend WithEvents Label_ID As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents DP_Date As System.Windows.Forms.DateTimePicker
    Friend WithEvents Btn_GoodsSel As System.Windows.Forms.Button
    Friend WithEvents Btn_AddRow As System.Windows.Forms.ToolStripButton
    Friend WithEvents Btn_RemoveRow As System.Windows.Forms.ToolStripButton
    Friend WithEvents TB_SumProductQty As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents LabelTitle As System.Windows.Forms.Label
    Friend WithEvents ListBox_Show As System.Windows.Forms.ListBox
    Friend WithEvents TimerCombox As System.Windows.Forms.Timer
    Friend WithEvents TimerFGLostFocus As System.Windows.Forms.Timer
    Friend WithEvents PanelFG As System.Windows.Forms.Panel
    Friend WithEvents Fg2 As PClass.FG
    Friend WithEvents TimerGoods As System.Windows.Forms.Timer
    Friend WithEvents TB_Project As System.Windows.Forms.TextBox
    Friend WithEvents TB_SumQTY As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label

End Class
