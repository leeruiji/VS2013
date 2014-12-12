<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F40502_Store_Sel
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F40502_Store_Sel))
        Me.PanelMain = New System.Windows.Forms.Panel
        Me.Bz_List2 = New BaseClass.Bz_List
        Me.Client_List1 = New BaseClass.Client_List
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Cmd_Find = New System.Windows.Forms.Button
        Me.Cmd_Sel = New System.Windows.Forms.Button
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.TabControl2 = New System.Windows.Forms.TabControl
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.Fg_CheckedCell = New PClass.FG
        Me.CB_Floor = New System.Windows.Forms.ComboBox
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.LabelPassage = New System.Windows.Forms.Label
        Me.LabelDisable = New System.Windows.Forms.Label
        Me.LabelPost = New System.Windows.Forms.Label
        Me.LabelCellA = New System.Windows.Forms.Label
        Me.LabelCell = New System.Windows.Forms.Label
        Me.LabelSel = New System.Windows.Forms.Label
        Me.LabelNormal = New System.Windows.Forms.Label
        Me.LabelEmpty = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.LabelXY = New System.Windows.Forms.Label
        Me.TB_No = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.TB_Qty = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.TB_MaxQty = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.CB_State = New System.Windows.Forms.ComboBox
        Me.DG = New System.Windows.Forms.DataGridView
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.LabelShow_0 = New System.Windows.Forms.Label
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel
        Me.Fg1 = New PClass.FG
        Me.Cmd_FGSel = New System.Windows.Forms.Button
        Me.Cmd_FGSelAll = New System.Windows.Forms.Button
        Me.LabelShow2_0 = New System.Windows.Forms.Label
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel
        Me.Cmd_FGDel = New System.Windows.Forms.Button
        Me.Fg2 = New PClass.FG
        Me.Cmd_FGDelAll = New System.Windows.Forms.Button
        Me.TB_BZ_Name = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.TB_BZ_ID = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.TB_ClientName = New System.Windows.Forms.TextBox
        Me.TB_ClientID = New System.Windows.Forms.TextBox
        Me.Label_Supplier_Name = New System.Windows.Forms.Label
        Me.Label_Supplier_ID = New System.Windows.Forms.Label
        Me.LB_Area = New System.Windows.Forms.Label
        Me.TimerLeave = New System.Windows.Forms.Timer(Me.components)
        Me.TimerLeave2 = New System.Windows.Forms.Timer(Me.components)
        Me.PanelMain.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TabControl2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        CType(Me.Fg_CheckedCell, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.DG, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.Fg1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Fg2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelMain
        '
        Me.PanelMain.AutoScroll = True
        Me.PanelMain.Controls.Add(Me.Client_List1)
        Me.PanelMain.Controls.Add(Me.Bz_List2)
        Me.PanelMain.Controls.Add(Me.Panel2)
        Me.PanelMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelMain.Location = New System.Drawing.Point(0, 0)
        Me.PanelMain.Name = "PanelMain"
        Me.PanelMain.Padding = New System.Windows.Forms.Padding(2)
        Me.PanelMain.Size = New System.Drawing.Size(1154, 763)
        Me.PanelMain.TabIndex = 12
        '
        'Bz_List2
        '
        Me.Bz_List2.BackColor = System.Drawing.Color.DodgerBlue
        Me.Bz_List2.IsShowAll = True
        Me.Bz_List2.IsTBLostFocusSelOne = True
        Me.Bz_List2.Location = New System.Drawing.Point(-400, -400)
        Me.Bz_List2.Name = "Bz_List2"
        Me.Bz_List2.SearchType = BaseClass.Bz_List.ENum_SearchType.Client
        Me.Bz_List2.Size = New System.Drawing.Size(292, 210)
        Me.Bz_List2.TabIndex = 38
        Me.Bz_List2.Visible = False
        '
        'Client_List1
        '
        Me.Client_List1.BackColor = System.Drawing.Color.DodgerBlue
        Me.Client_List1.IsShowAll = True
        Me.Client_List1.IsTBLostFocusSelOne = True
        Me.Client_List1.Location = New System.Drawing.Point(-400, -400)
        Me.Client_List1.Name = "Client_List1"
        Me.Client_List1.Size = New System.Drawing.Size(296, 206)
        Me.Client_List1.TabIndex = 37
        Me.Client_List1.Visible = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Cmd_Find)
        Me.Panel2.Controls.Add(Me.Cmd_Sel)
        Me.Panel2.Controls.Add(Me.TabControl1)
        Me.Panel2.Controls.Add(Me.TB_BZ_Name)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.TB_BZ_ID)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.TB_ClientName)
        Me.Panel2.Controls.Add(Me.TB_ClientID)
        Me.Panel2.Controls.Add(Me.Label_Supplier_Name)
        Me.Panel2.Controls.Add(Me.Label_Supplier_ID)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(2, 2)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Panel2.Size = New System.Drawing.Size(1150, 759)
        Me.Panel2.TabIndex = 2
        '
        'Cmd_Find
        '
        Me.Cmd_Find.Location = New System.Drawing.Point(768, 10)
        Me.Cmd_Find.Name = "Cmd_Find"
        Me.Cmd_Find.Size = New System.Drawing.Size(80, 36)
        Me.Cmd_Find.TabIndex = 32
        Me.Cmd_Find.Text = "查询"
        Me.Cmd_Find.UseVisualStyleBackColor = True
        '
        'Cmd_Sel
        '
        Me.Cmd_Sel.Location = New System.Drawing.Point(888, 10)
        Me.Cmd_Sel.Name = "Cmd_Sel"
        Me.Cmd_Sel.Size = New System.Drawing.Size(74, 36)
        Me.Cmd_Sel.TabIndex = 34
        Me.Cmd_Sel.Text = "选择"
        Me.Cmd_Sel.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(0, 38)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1150, 721)
        Me.TabControl1.TabIndex = 33
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Panel1)
        Me.TabPage1.Controls.Add(Me.DG)
        Me.TabPage1.Location = New System.Drawing.Point(4, 23)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1142, 694)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "仓库平面图"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.TabControl2)
        Me.Panel1.Controls.Add(Me.CB_Floor)
        Me.Panel1.Controls.Add(Me.GroupBox6)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.GroupBox5)
        Me.Panel1.Location = New System.Drawing.Point(884, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Panel1.Size = New System.Drawing.Size(255, 682)
        Me.Panel1.TabIndex = 42
        '
        'TabControl2
        '
        Me.TabControl2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl2.Controls.Add(Me.TabPage3)
        Me.TabControl2.Location = New System.Drawing.Point(5, 57)
        Me.TabControl2.Name = "TabControl2"
        Me.TabControl2.SelectedIndex = 0
        Me.TabControl2.Size = New System.Drawing.Size(247, 335)
        Me.TabControl2.TabIndex = 42
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.Fg_CheckedCell)
        Me.TabPage3.Location = New System.Drawing.Point(4, 23)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(239, 308)
        Me.TabPage3.TabIndex = 0
        Me.TabPage3.Text = "仓位"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'Fg_CheckedCell
        '
        Me.Fg_CheckedCell.AutoAddIndex = True
        Me.Fg_CheckedCell.AutoGenerateColumns = False
        Me.Fg_CheckedCell.AutoResize = False
        Me.Fg_CheckedCell.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.Fg_CheckedCell.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.XpThemes
        Me.Fg_CheckedCell.CanEditing = False
        Me.Fg_CheckedCell.ColumnInfo = resources.GetString("Fg_CheckedCell.ColumnInfo")
        Me.Fg_CheckedCell.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Fg_CheckedCell.EditFormat = True
        Me.Fg_CheckedCell.ExtendLastCol = True
        Me.Fg_CheckedCell.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Fg_CheckedCell.ForeColor = System.Drawing.Color.Black
        Me.Fg_CheckedCell.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.Fg_CheckedCell.IsAutoAddRow = True
        Me.Fg_CheckedCell.IsClickStartEdit = False
        Me.Fg_CheckedCell.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.Fg_CheckedCell.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.Fg_CheckedCell.Location = New System.Drawing.Point(3, 3)
        Me.Fg_CheckedCell.Name = "Fg_CheckedCell"
        Me.Fg_CheckedCell.Rows.Count = 10
        Me.Fg_CheckedCell.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.Fg_CheckedCell.Size = New System.Drawing.Size(233, 302)
        Me.Fg_CheckedCell.StartCol = ""
        Me.Fg_CheckedCell.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("Fg_CheckedCell.Styles"))
        Me.Fg_CheckedCell.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.BelowData
        Me.Fg_CheckedCell.TabIndex = 41
        '
        'CB_Floor
        '
        Me.CB_Floor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_Floor.Font = New System.Drawing.Font("宋体", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.CB_Floor.FormattingEnabled = True
        Me.CB_Floor.Location = New System.Drawing.Point(67, 8)
        Me.CB_Floor.Name = "CB_Floor"
        Me.CB_Floor.Size = New System.Drawing.Size(95, 43)
        Me.CB_Floor.TabIndex = 40
        '
        'GroupBox6
        '
        Me.GroupBox6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox6.Controls.Add(Me.LabelPassage)
        Me.GroupBox6.Controls.Add(Me.LabelDisable)
        Me.GroupBox6.Controls.Add(Me.LabelPost)
        Me.GroupBox6.Controls.Add(Me.LabelCellA)
        Me.GroupBox6.Controls.Add(Me.LabelCell)
        Me.GroupBox6.Controls.Add(Me.LabelSel)
        Me.GroupBox6.Controls.Add(Me.LabelNormal)
        Me.GroupBox6.Controls.Add(Me.LabelEmpty)
        Me.GroupBox6.Location = New System.Drawing.Point(6, 517)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(244, 60)
        Me.GroupBox6.TabIndex = 38
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "调色板"
        '
        'LabelPassage
        '
        Me.LabelPassage.AutoSize = True
        Me.LabelPassage.BackColor = System.Drawing.Color.Transparent
        Me.LabelPassage.ForeColor = System.Drawing.Color.Red
        Me.LabelPassage.Location = New System.Drawing.Point(156, 17)
        Me.LabelPassage.Name = "LabelPassage"
        Me.LabelPassage.Size = New System.Drawing.Size(35, 14)
        Me.LabelPassage.TabIndex = 7
        Me.LabelPassage.Text = "通道"
        '
        'LabelDisable
        '
        Me.LabelDisable.AutoSize = True
        Me.LabelDisable.BackColor = System.Drawing.Color.Transparent
        Me.LabelDisable.ForeColor = System.Drawing.Color.Red
        Me.LabelDisable.Location = New System.Drawing.Point(129, 38)
        Me.LabelDisable.Name = "LabelDisable"
        Me.LabelDisable.Size = New System.Drawing.Size(35, 14)
        Me.LabelDisable.TabIndex = 6
        Me.LabelDisable.Text = "禁用"
        '
        'LabelPost
        '
        Me.LabelPost.AutoSize = True
        Me.LabelPost.BackColor = System.Drawing.Color.Transparent
        Me.LabelPost.ForeColor = System.Drawing.Color.Red
        Me.LabelPost.Location = New System.Drawing.Point(106, 38)
        Me.LabelPost.Name = "LabelPost"
        Me.LabelPost.Size = New System.Drawing.Size(21, 14)
        Me.LabelPost.TabIndex = 5
        Me.LabelPost.Text = "柱"
        '
        'LabelCellA
        '
        Me.LabelCellA.AutoSize = True
        Me.LabelCellA.BackColor = System.Drawing.Color.Transparent
        Me.LabelCellA.ForeColor = System.Drawing.Color.Blue
        Me.LabelCellA.Location = New System.Drawing.Point(58, 38)
        Me.LabelCellA.Name = "LabelCellA"
        Me.LabelCellA.Size = New System.Drawing.Size(49, 14)
        Me.LabelCellA.TabIndex = 4
        Me.LabelCellA.Text = "双数格"
        '
        'LabelCell
        '
        Me.LabelCell.AutoSize = True
        Me.LabelCell.BackColor = System.Drawing.Color.Transparent
        Me.LabelCell.ForeColor = System.Drawing.Color.White
        Me.LabelCell.Location = New System.Drawing.Point(10, 38)
        Me.LabelCell.Name = "LabelCell"
        Me.LabelCell.Size = New System.Drawing.Size(49, 14)
        Me.LabelCell.TabIndex = 3
        Me.LabelCell.Text = "单数格"
        '
        'LabelSel
        '
        Me.LabelSel.AutoSize = True
        Me.LabelSel.BackColor = System.Drawing.Color.Transparent
        Me.LabelSel.ForeColor = System.Drawing.Color.Red
        Me.LabelSel.Location = New System.Drawing.Point(107, 17)
        Me.LabelSel.Name = "LabelSel"
        Me.LabelSel.Size = New System.Drawing.Size(49, 14)
        Me.LabelSel.TabIndex = 2
        Me.LabelSel.Text = "被选择"
        '
        'LabelNormal
        '
        Me.LabelNormal.AutoSize = True
        Me.LabelNormal.BackColor = System.Drawing.Color.Transparent
        Me.LabelNormal.ForeColor = System.Drawing.Color.Blue
        Me.LabelNormal.Location = New System.Drawing.Point(58, 17)
        Me.LabelNormal.Name = "LabelNormal"
        Me.LabelNormal.Size = New System.Drawing.Size(49, 14)
        Me.LabelNormal.TabIndex = 1
        Me.LabelNormal.Text = "有库存"
        '
        'LabelEmpty
        '
        Me.LabelEmpty.AutoSize = True
        Me.LabelEmpty.BackColor = System.Drawing.Color.Transparent
        Me.LabelEmpty.ForeColor = System.Drawing.Color.White
        Me.LabelEmpty.Location = New System.Drawing.Point(12, 17)
        Me.LabelEmpty.Name = "LabelEmpty"
        Me.LabelEmpty.Size = New System.Drawing.Size(35, 14)
        Me.LabelEmpty.TabIndex = 0
        Me.LabelEmpty.Text = "空格"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 14)
        Me.Label3.TabIndex = 29
        Me.Label3.Text = "楼层:"
        '
        'GroupBox5
        '
        Me.GroupBox5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox5.Controls.Add(Me.LabelXY)
        Me.GroupBox5.Controls.Add(Me.TB_No)
        Me.GroupBox5.Controls.Add(Me.Label12)
        Me.GroupBox5.Controls.Add(Me.Label11)
        Me.GroupBox5.Controls.Add(Me.TB_Qty)
        Me.GroupBox5.Controls.Add(Me.Label15)
        Me.GroupBox5.Controls.Add(Me.TB_MaxQty)
        Me.GroupBox5.Controls.Add(Me.Label14)
        Me.GroupBox5.Controls.Add(Me.Label13)
        Me.GroupBox5.Controls.Add(Me.CB_State)
        Me.GroupBox5.Location = New System.Drawing.Point(6, 398)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.GroupBox5.Size = New System.Drawing.Size(244, 117)
        Me.GroupBox5.TabIndex = 37
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "单前格"
        '
        'LabelXY
        '
        Me.LabelXY.AutoSize = True
        Me.LabelXY.ForeColor = System.Drawing.Color.Blue
        Me.LabelXY.Location = New System.Drawing.Point(140, 23)
        Me.LabelXY.Name = "LabelXY"
        Me.LabelXY.Size = New System.Drawing.Size(35, 14)
        Me.LabelXY.TabIndex = 38
        Me.LabelXY.Text = "位置"
        '
        'TB_No
        '
        Me.TB_No.Location = New System.Drawing.Point(53, 20)
        Me.TB_No.Name = "TB_No"
        Me.TB_No.Size = New System.Drawing.Size(37, 23)
        Me.TB_No.TabIndex = 37
        Me.TB_No.Text = "20"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(6, 23)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(42, 14)
        Me.Label12.TabIndex = 36
        Me.Label12.Text = "编号:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(94, 23)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(42, 14)
        Me.Label11.TabIndex = 35
        Me.Label11.Text = "位置:"
        '
        'TB_Qty
        '
        Me.TB_Qty.Location = New System.Drawing.Point(140, 80)
        Me.TB_Qty.Name = "TB_Qty"
        Me.TB_Qty.Size = New System.Drawing.Size(37, 23)
        Me.TB_Qty.TabIndex = 34
        Me.TB_Qty.Text = "0"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(98, 85)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(42, 14)
        Me.Label15.TabIndex = 33
        Me.Label15.Text = "库存:"
        '
        'TB_MaxQty
        '
        Me.TB_MaxQty.Location = New System.Drawing.Point(55, 80)
        Me.TB_MaxQty.Name = "TB_MaxQty"
        Me.TB_MaxQty.Size = New System.Drawing.Size(37, 23)
        Me.TB_MaxQty.TabIndex = 32
        Me.TB_MaxQty.Text = "20"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(6, 85)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(42, 14)
        Me.Label14.TabIndex = 31
        Me.Label14.Text = "容量:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(6, 55)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(42, 14)
        Me.Label13.TabIndex = 30
        Me.Label13.Text = "状态:"
        '
        'CB_State
        '
        Me.CB_State.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_State.FormattingEnabled = True
        Me.CB_State.Items.AddRange(New Object() {"普通格", "柱", "禁用", "通道"})
        Me.CB_State.Location = New System.Drawing.Point(53, 49)
        Me.CB_State.Name = "CB_State"
        Me.CB_State.Size = New System.Drawing.Size(83, 22)
        Me.CB_State.TabIndex = 29
        '
        'DG
        '
        Me.DG.AllowUserToAddRows = False
        Me.DG.AllowUserToDeleteRows = False
        Me.DG.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DG.BackgroundColor = System.Drawing.Color.White
        Me.DG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DG.ColumnHeadersVisible = False
        Me.DG.Location = New System.Drawing.Point(0, 0)
        Me.DG.MultiSelect = False
        Me.DG.Name = "DG"
        Me.DG.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DG.RowHeadersVisible = False
        Me.DG.RowTemplate.Height = 23
        Me.DG.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.DG.Size = New System.Drawing.Size(883, 689)
        Me.DG.TabIndex = 1
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.SplitContainer1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 23)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1142, 694)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "查询结果：仓位"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.LabelShow_0)
        Me.SplitContainer1.Panel1.Controls.Add(Me.FlowLayoutPanel1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Fg1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Cmd_FGSel)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Cmd_FGSelAll)
        Me.SplitContainer1.Panel1MinSize = 560
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.LabelShow2_0)
        Me.SplitContainer1.Panel2.Controls.Add(Me.FlowLayoutPanel2)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Cmd_FGDel)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Fg2)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Cmd_FGDelAll)
        Me.SplitContainer1.Size = New System.Drawing.Size(1136, 688)
        Me.SplitContainer1.SplitterDistance = 577
        Me.SplitContainer1.TabIndex = 3
        '
        'LabelShow_0
        '
        Me.LabelShow_0.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LabelShow_0.BackColor = System.Drawing.Color.White
        Me.LabelShow_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LabelShow_0.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LabelShow_0.ForeColor = System.Drawing.Color.Blue
        Me.LabelShow_0.Location = New System.Drawing.Point(3, 638)
        Me.LabelShow_0.Name = "LabelShow_0"
        Me.LabelShow_0.Size = New System.Drawing.Size(75, 49)
        Me.LabelShow_0.TabIndex = 7
        Me.LabelShow_0.Text = "全部仓位"
        Me.LabelShow_0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlowLayoutPanel1.BackColor = System.Drawing.Color.White
        Me.FlowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(79, 638)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(275, 49)
        Me.FlowLayoutPanel1.TabIndex = 6
        '
        'Fg1
        '
        Me.Fg1.AllowEditing = False
        Me.Fg1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Fg1.AutoAddIndex = True
        Me.Fg1.AutoGenerateColumns = False
        Me.Fg1.AutoResize = False
        Me.Fg1.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.Fg1.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.XpThemes
        Me.Fg1.CanEditing = False
        Me.Fg1.ColumnInfo = resources.GetString("Fg1.ColumnInfo")
        Me.Fg1.EditFormat = True
        Me.Fg1.ExtendLastCol = True
        Me.Fg1.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Fg1.ForeColor = System.Drawing.Color.Black
        Me.Fg1.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.Fg1.IsAutoAddRow = True
        Me.Fg1.IsClickStartEdit = False
        Me.Fg1.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.Fg1.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.Fg1.Location = New System.Drawing.Point(0, 0)
        Me.Fg1.Name = "Fg1"
        Me.Fg1.Rows.Count = 1
        Me.Fg1.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.RowRange
        Me.Fg1.Size = New System.Drawing.Size(577, 634)
        Me.Fg1.StartCol = ""
        Me.Fg1.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("Fg1.Styles"))
        Me.Fg1.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.BelowData
        Me.Fg1.TabIndex = 2
        '
        'Cmd_FGSel
        '
        Me.Cmd_FGSel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cmd_FGSel.Location = New System.Drawing.Point(360, 645)
        Me.Cmd_FGSel.Name = "Cmd_FGSel"
        Me.Cmd_FGSel.Size = New System.Drawing.Size(102, 32)
        Me.Cmd_FGSel.TabIndex = 4
        Me.Cmd_FGSel.Text = "添加 ->"
        Me.Cmd_FGSel.UseVisualStyleBackColor = True
        '
        'Cmd_FGSelAll
        '
        Me.Cmd_FGSelAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cmd_FGSelAll.Location = New System.Drawing.Point(468, 645)
        Me.Cmd_FGSelAll.Name = "Cmd_FGSelAll"
        Me.Cmd_FGSelAll.Size = New System.Drawing.Size(102, 31)
        Me.Cmd_FGSelAll.TabIndex = 5
        Me.Cmd_FGSelAll.Text = "全部添加 >>"
        Me.Cmd_FGSelAll.UseVisualStyleBackColor = True
        '
        'LabelShow2_0
        '
        Me.LabelShow2_0.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelShow2_0.BackColor = System.Drawing.Color.White
        Me.LabelShow2_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LabelShow2_0.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LabelShow2_0.ForeColor = System.Drawing.Color.Blue
        Me.LabelShow2_0.Location = New System.Drawing.Point(477, 638)
        Me.LabelShow2_0.Name = "LabelShow2_0"
        Me.LabelShow2_0.Size = New System.Drawing.Size(75, 49)
        Me.LabelShow2_0.TabIndex = 9
        Me.LabelShow2_0.Text = "全部仓位"
        Me.LabelShow2_0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlowLayoutPanel2.BackColor = System.Drawing.Color.White
        Me.FlowLayoutPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(214, 638)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(262, 49)
        Me.FlowLayoutPanel2.TabIndex = 8
        '
        'Cmd_FGDel
        '
        Me.Cmd_FGDel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Cmd_FGDel.Location = New System.Drawing.Point(111, 645)
        Me.Cmd_FGDel.Name = "Cmd_FGDel"
        Me.Cmd_FGDel.Size = New System.Drawing.Size(102, 32)
        Me.Cmd_FGDel.TabIndex = 6
        Me.Cmd_FGDel.Text = "<- 删除"
        Me.Cmd_FGDel.UseVisualStyleBackColor = True
        '
        'Fg2
        '
        Me.Fg2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Fg2.AutoAddIndex = True
        Me.Fg2.AutoGenerateColumns = False
        Me.Fg2.AutoResize = False
        Me.Fg2.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.Fg2.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.XpThemes
        Me.Fg2.CanEditing = False
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
        Me.Fg2.Location = New System.Drawing.Point(0, 0)
        Me.Fg2.Name = "Fg2"
        Me.Fg2.Rows.Count = 1
        Me.Fg2.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.RowRange
        Me.Fg2.Size = New System.Drawing.Size(555, 634)
        Me.Fg2.StartCol = ""
        Me.Fg2.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("Fg2.Styles"))
        Me.Fg2.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.BelowData
        Me.Fg2.TabIndex = 3
        '
        'Cmd_FGDelAll
        '
        Me.Cmd_FGDelAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Cmd_FGDelAll.Location = New System.Drawing.Point(3, 646)
        Me.Cmd_FGDelAll.Name = "Cmd_FGDelAll"
        Me.Cmd_FGDelAll.Size = New System.Drawing.Size(102, 31)
        Me.Cmd_FGDelAll.TabIndex = 7
        Me.Cmd_FGDelAll.Text = "<< 全部删除"
        Me.Cmd_FGDelAll.UseVisualStyleBackColor = True
        '
        'TB_BZ_Name
        '
        Me.TB_BZ_Name.Location = New System.Drawing.Point(612, 11)
        Me.TB_BZ_Name.Name = "TB_BZ_Name"
        Me.TB_BZ_Name.ReadOnly = True
        Me.TB_BZ_Name.Size = New System.Drawing.Size(150, 23)
        Me.TB_BZ_Name.TabIndex = 30
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(536, 15)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 14)
        Me.Label5.TabIndex = 31
        Me.Label5.Text = "布种名称:"
        '
        'TB_BZ_ID
        '
        Me.TB_BZ_ID.Location = New System.Drawing.Point(448, 11)
        Me.TB_BZ_ID.Name = "TB_BZ_ID"
        Me.TB_BZ_ID.ReadOnly = True
        Me.TB_BZ_ID.Size = New System.Drawing.Size(84, 23)
        Me.TB_BZ_ID.TabIndex = 28
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(372, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 14)
        Me.Label4.TabIndex = 29
        Me.Label4.Text = "布种编号:"
        '
        'TB_ClientName
        '
        Me.TB_ClientName.Location = New System.Drawing.Point(247, 11)
        Me.TB_ClientName.Name = "TB_ClientName"
        Me.TB_ClientName.ReadOnly = True
        Me.TB_ClientName.Size = New System.Drawing.Size(111, 23)
        Me.TB_ClientName.TabIndex = 23
        '
        'TB_ClientID
        '
        Me.TB_ClientID.Location = New System.Drawing.Point(86, 11)
        Me.TB_ClientID.Name = "TB_ClientID"
        Me.TB_ClientID.Size = New System.Drawing.Size(79, 23)
        Me.TB_ClientID.TabIndex = 22
        '
        'Label_Supplier_Name
        '
        Me.Label_Supplier_Name.AutoSize = True
        Me.Label_Supplier_Name.Location = New System.Drawing.Point(171, 15)
        Me.Label_Supplier_Name.Name = "Label_Supplier_Name"
        Me.Label_Supplier_Name.Size = New System.Drawing.Size(70, 14)
        Me.Label_Supplier_Name.TabIndex = 25
        Me.Label_Supplier_Name.Text = "客户名称:"
        '
        'Label_Supplier_ID
        '
        Me.Label_Supplier_ID.AutoSize = True
        Me.Label_Supplier_ID.Location = New System.Drawing.Point(10, 15)
        Me.Label_Supplier_ID.Name = "Label_Supplier_ID"
        Me.Label_Supplier_ID.Size = New System.Drawing.Size(70, 14)
        Me.Label_Supplier_ID.TabIndex = 24
        Me.Label_Supplier_ID.Text = "客户编号:"
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
        'TimerLeave
        '
        Me.TimerLeave.Interval = 500
        '
        'TimerLeave2
        '
        Me.TimerLeave2.Interval = 500
        '
        'F40502_Store_Sel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.PanelMain)
        Me.Controls.Add(Me.LB_Area)
        Me.Name = "F40502_Store_Sel"
        Me.Size = New System.Drawing.Size(1154, 763)
        Me.PanelMain.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TabControl2.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        CType(Me.Fg_CheckedCell, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.DG, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.Fg1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Fg2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PanelMain As System.Windows.Forms.Panel
    Friend WithEvents LB_Area As System.Windows.Forms.Label
    Friend WithEvents DG As System.Windows.Forms.DataGridView
    Friend WithEvents TB_ClientName As System.Windows.Forms.TextBox
    Friend WithEvents TB_ClientID As System.Windows.Forms.TextBox
    Friend WithEvents Label_Supplier_Name As System.Windows.Forms.Label
    Friend WithEvents Label_Supplier_ID As System.Windows.Forms.Label
    Friend WithEvents TB_BZ_Name As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TB_BZ_ID As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Bz_List2 As BaseClass.Bz_List
    Friend WithEvents Client_List1 As BaseClass.Client_List
    Friend WithEvents Cmd_Find As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Fg1 As PClass.FG
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TabControl2 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents Fg_CheckedCell As PClass.FG
    Friend WithEvents CB_Floor As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents LabelPassage As System.Windows.Forms.Label
    Friend WithEvents LabelDisable As System.Windows.Forms.Label
    Friend WithEvents LabelPost As System.Windows.Forms.Label
    Friend WithEvents LabelCellA As System.Windows.Forms.Label
    Friend WithEvents LabelCell As System.Windows.Forms.Label
    Friend WithEvents LabelSel As System.Windows.Forms.Label
    Friend WithEvents LabelNormal As System.Windows.Forms.Label
    Friend WithEvents LabelEmpty As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents LabelXY As System.Windows.Forms.Label
    Friend WithEvents TB_No As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TB_Qty As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents TB_MaxQty As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents CB_State As System.Windows.Forms.ComboBox
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Fg2 As PClass.FG
    Friend WithEvents Cmd_Sel As System.Windows.Forms.Button
    Friend WithEvents Cmd_FGSel As System.Windows.Forms.Button
    Friend WithEvents Cmd_FGSelAll As System.Windows.Forms.Button
    Friend WithEvents Cmd_FGDel As System.Windows.Forms.Button
    Friend WithEvents Cmd_FGDelAll As System.Windows.Forms.Button
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents TimerLeave As System.Windows.Forms.Timer
    Friend WithEvents LabelShow_0 As System.Windows.Forms.Label
    Friend WithEvents LabelShow2_0 As System.Windows.Forms.Label
    Friend WithEvents FlowLayoutPanel2 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents TimerLeave2 As System.Windows.Forms.Timer

End Class
