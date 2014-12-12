<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F40500_Store_Map
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F40500_Store_Map))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.PanelMain = New System.Windows.Forms.Panel
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Cmd_Refresh = New System.Windows.Forms.Button
        Me.Cmd_Choose = New System.Windows.Forms.Button
        Me.TabControl2 = New System.Windows.Forms.TabControl
        Me.TabPage4 = New System.Windows.Forms.TabPage
        Me.Fg2 = New PClass.FG
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
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.CK_showKC = New System.Windows.Forms.CheckBox
        Me.CB_Sel = New System.Windows.Forms.ComboBox
        Me.TB_GHSearch = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Cmd_Report = New System.Windows.Forms.Button
        Me.CB_BZ = New BaseClass.ComBoList
        Me.CB_Client = New BaseClass.ComBoList
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.DG = New System.Windows.Forms.DataGridView
        Me.Label_Supplier_Name = New System.Windows.Forms.Label
        Me.TB_ClientName = New System.Windows.Forms.TextBox
        Me.TB_BZ_Name = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.Fg1 = New PClass.FG
        Me.TabPage5 = New System.Windows.Forms.TabPage
        Me.CmdPreview = New System.Windows.Forms.Button
        Me.CmdClear = New System.Windows.Forms.Button
        Me.CmdAdd = New System.Windows.Forms.Button
        Me.Label8 = New System.Windows.Forms.Label
        Me.ListBox1 = New System.Windows.Forms.ListBox
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.CheckedListBox1 = New System.Windows.Forms.CheckedListBox
        Me.RadioButton4 = New System.Windows.Forms.RadioButton
        Me.RadioButton3 = New System.Windows.Forms.RadioButton
        Me.RadioButton2 = New System.Windows.Forms.RadioButton
        Me.RadioButton1 = New System.Windows.Forms.RadioButton
        Me.CmdPrint = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Cmd_Find = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label_Supplier_ID = New System.Windows.Forms.Label
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.PanelMain.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TabControl2.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        CType(Me.Fg2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        CType(Me.Fg_CheckedCell, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.DG, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.Fg1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage5.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelMain
        '
        Me.PanelMain.AutoScroll = True
        Me.PanelMain.Controls.Add(Me.SplitContainer1)
        Me.PanelMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelMain.Location = New System.Drawing.Point(0, 0)
        Me.PanelMain.Name = "PanelMain"
        Me.PanelMain.Padding = New System.Windows.Forms.Padding(2)
        Me.PanelMain.Size = New System.Drawing.Size(1154, 763)
        Me.PanelMain.TabIndex = 12
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(2, 2)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel1)
        Me.SplitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.SplitContainer1.Panel1MinSize = 228
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel2)
        Me.SplitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.SplitContainer1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.SplitContainer1.Size = New System.Drawing.Size(1150, 759)
        Me.SplitContainer1.SplitterDistance = 255
        Me.SplitContainer1.TabIndex = 42
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Cmd_Refresh)
        Me.Panel1.Controls.Add(Me.Cmd_Choose)
        Me.Panel1.Controls.Add(Me.TabControl2)
        Me.Panel1.Controls.Add(Me.CB_Floor)
        Me.Panel1.Controls.Add(Me.GroupBox6)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.GroupBox5)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Panel1.Size = New System.Drawing.Size(255, 759)
        Me.Panel1.TabIndex = 42
        '
        'Cmd_Refresh
        '
        Me.Cmd_Refresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Cmd_Refresh.Location = New System.Drawing.Point(16, 670)
        Me.Cmd_Refresh.Name = "Cmd_Refresh"
        Me.Cmd_Refresh.Size = New System.Drawing.Size(80, 34)
        Me.Cmd_Refresh.TabIndex = 44
        Me.Cmd_Refresh.Text = "刷新"
        Me.Cmd_Refresh.UseVisualStyleBackColor = True
        '
        'Cmd_Choose
        '
        Me.Cmd_Choose.Location = New System.Drawing.Point(165, 3)
        Me.Cmd_Choose.Name = "Cmd_Choose"
        Me.Cmd_Choose.Size = New System.Drawing.Size(80, 45)
        Me.Cmd_Choose.TabIndex = 43
        Me.Cmd_Choose.Text = "选择"
        Me.Cmd_Choose.UseVisualStyleBackColor = True
        '
        'TabControl2
        '
        Me.TabControl2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl2.Controls.Add(Me.TabPage4)
        Me.TabControl2.Controls.Add(Me.TabPage3)
        Me.TabControl2.Location = New System.Drawing.Point(5, 54)
        Me.TabControl2.Name = "TabControl2"
        Me.TabControl2.SelectedIndex = 0
        Me.TabControl2.Size = New System.Drawing.Size(247, 412)
        Me.TabControl2.TabIndex = 42
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.Fg2)
        Me.TabPage4.Location = New System.Drawing.Point(4, 23)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(239, 385)
        Me.TabPage4.TabIndex = 1
        Me.TabPage4.Text = "仓位明细"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'Fg2
        '
        Me.Fg2.AddCopyMenu = False
        Me.Fg2.AutoAddIndex = True
        Me.Fg2.AutoGenerateColumns = False
        Me.Fg2.AutoResize = False
        Me.Fg2.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.Fg2.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.XpThemes
        Me.Fg2.CanEditing = False
        Me.Fg2.CheckKeyPressEdit = True
        Me.Fg2.ColumnInfo = resources.GetString("Fg2.ColumnInfo")
        Me.Fg2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Fg2.EditFormat = True
        Me.Fg2.ExtendLastCol = True
        Me.Fg2.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Fg2.ForeColor = System.Drawing.Color.Black
        Me.Fg2.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.Fg2.IsAutoAddRow = True
        Me.Fg2.IsClickStartEdit = False
        Me.Fg2.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.Fg2.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.Fg2.Location = New System.Drawing.Point(3, 3)
        Me.Fg2.Name = "Fg2"
        Me.Fg2.NoShowMenu = False
        Me.Fg2.Rows.Count = 1
        Me.Fg2.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.Fg2.Size = New System.Drawing.Size(233, 379)
        Me.Fg2.StartCol = ""
        Me.Fg2.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("Fg2.Styles"))
        Me.Fg2.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.BelowData
        Me.Fg2.TabIndex = 0
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.Fg_CheckedCell)
        Me.TabPage3.Location = New System.Drawing.Point(4, 23)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(239, 385)
        Me.TabPage3.TabIndex = 0
        Me.TabPage3.Text = "仓位"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'Fg_CheckedCell
        '
        Me.Fg_CheckedCell.AddCopyMenu = False
        Me.Fg_CheckedCell.AutoAddIndex = True
        Me.Fg_CheckedCell.AutoGenerateColumns = False
        Me.Fg_CheckedCell.AutoResize = False
        Me.Fg_CheckedCell.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.Fg_CheckedCell.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.XpThemes
        Me.Fg_CheckedCell.CanEditing = False
        Me.Fg_CheckedCell.CheckKeyPressEdit = True
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
        Me.Fg_CheckedCell.NoShowMenu = False
        Me.Fg_CheckedCell.Rows.Count = 1
        Me.Fg_CheckedCell.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.Fg_CheckedCell.Size = New System.Drawing.Size(233, 379)
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
        Me.CB_Floor.Location = New System.Drawing.Point(67, 5)
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
        Me.GroupBox6.Location = New System.Drawing.Point(6, 591)
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
        Me.Label3.Font = New System.Drawing.Font("宋体", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label3.Location = New System.Drawing.Point(8, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 19)
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
        Me.GroupBox5.Location = New System.Drawing.Point(6, 472)
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
        Me.CB_State.Items.AddRange(New Object() {"普通格", "柱", "禁用", "通道", "楼梯"})
        Me.CB_State.Location = New System.Drawing.Point(53, 49)
        Me.CB_State.Name = "CB_State"
        Me.CB_State.Size = New System.Drawing.Size(83, 22)
        Me.CB_State.TabIndex = 29
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.CK_showKC)
        Me.Panel2.Controls.Add(Me.CB_Sel)
        Me.Panel2.Controls.Add(Me.TB_GHSearch)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.Cmd_Report)
        Me.Panel2.Controls.Add(Me.CB_BZ)
        Me.Panel2.Controls.Add(Me.CB_Client)
        Me.Panel2.Controls.Add(Me.TabControl1)
        Me.Panel2.Controls.Add(Me.Cmd_Find)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label_Supplier_ID)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Panel2.Size = New System.Drawing.Size(891, 759)
        Me.Panel2.TabIndex = 2
        '
        'CK_showKC
        '
        Me.CK_showKC.AutoSize = True
        Me.CK_showKC.Location = New System.Drawing.Point(747, 38)
        Me.CK_showKC.Name = "CK_showKC"
        Me.CK_showKC.Size = New System.Drawing.Size(96, 18)
        Me.CK_showKC.TabIndex = 32
        Me.CK_showKC.Text = "不显示空仓"
        Me.CK_showKC.UseVisualStyleBackColor = True
        '
        'CB_Sel
        '
        Me.CB_Sel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_Sel.FormattingEnabled = True
        Me.CB_Sel.Items.AddRange(New Object() {"所有仓位", "已用仓位"})
        Me.CB_Sel.Location = New System.Drawing.Point(615, 10)
        Me.CB_Sel.Name = "CB_Sel"
        Me.CB_Sel.Size = New System.Drawing.Size(111, 22)
        Me.CB_Sel.TabIndex = 39
        '
        'TB_GHSearch
        '
        Me.TB_GHSearch.Location = New System.Drawing.Point(471, 9)
        Me.TB_GHSearch.Name = "TB_GHSearch"
        Me.TB_GHSearch.Size = New System.Drawing.Size(138, 23)
        Me.TB_GHSearch.TabIndex = 32
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(395, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 14)
        Me.Label1.TabIndex = 38
        Me.Label1.Text = "缸号查找:"
        '
        'Cmd_Report
        '
        Me.Cmd_Report.Location = New System.Drawing.Point(811, 9)
        Me.Cmd_Report.Name = "Cmd_Report"
        Me.Cmd_Report.Size = New System.Drawing.Size(73, 24)
        Me.Cmd_Report.TabIndex = 37
        Me.Cmd_Report.Text = "报表"
        Me.Cmd_Report.UseVisualStyleBackColor = True
        '
        'CB_BZ
        '
        Me.CB_BZ.Child = "ComboBZ"
        Me.CB_BZ.FormattingEnabled = True
        Me.CB_BZ.IDAsInt = 0
        Me.CB_BZ.IDValue = ""
        Me.CB_BZ.IsKeyDownAutoSearch = True
        Me.CB_BZ.IsSelectName = False
        Me.CB_BZ.Location = New System.Drawing.Point(274, 10)
        Me.CB_BZ.Name = "CB_BZ"
        Me.CB_BZ.SearchType = BaseClass.cSearchType.ENum_SearchType.ALL
        Me.CB_BZ.Size = New System.Drawing.Size(114, 22)
        Me.CB_BZ.TabIndex = 35
        '
        'CB_Client
        '
        Me.CB_Client.Child = "ComboClient"
        Me.CB_Client.FormattingEnabled = True
        Me.CB_Client.IDAsInt = 0
        Me.CB_Client.IDValue = ""
        Me.CB_Client.IsKeyDownAutoSearch = True
        Me.CB_Client.IsSelectName = False
        Me.CB_Client.Location = New System.Drawing.Point(75, 11)
        Me.CB_Client.Name = "CB_Client"
        Me.CB_Client.SearchType = BaseClass.cSearchType.ENum_SearchType.ALL
        Me.CB_Client.Size = New System.Drawing.Size(118, 22)
        Me.CB_Client.TabIndex = 34
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage5)
        Me.TabControl1.Location = New System.Drawing.Point(3, 54)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(888, 707)
        Me.TabControl1.TabIndex = 33
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.DG)
        Me.TabPage1.Controls.Add(Me.Label_Supplier_Name)
        Me.TabPage1.Controls.Add(Me.TB_ClientName)
        Me.TabPage1.Controls.Add(Me.TB_BZ_Name)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Location = New System.Drawing.Point(4, 23)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(880, 680)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "仓库平面图"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'DG
        '
        Me.DG.AllowUserToAddRows = False
        Me.DG.AllowUserToDeleteRows = False
        Me.DG.BackgroundColor = System.Drawing.Color.White
        Me.DG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DG.ColumnHeadersVisible = False
        Me.DG.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DG.Location = New System.Drawing.Point(3, 3)
        Me.DG.MultiSelect = False
        Me.DG.Name = "DG"
        Me.DG.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DG.RowHeadersVisible = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        Me.DG.RowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DG.RowTemplate.Height = 23
        Me.DG.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.DG.Size = New System.Drawing.Size(874, 674)
        Me.DG.TabIndex = 1
        '
        'Label_Supplier_Name
        '
        Me.Label_Supplier_Name.AutoSize = True
        Me.Label_Supplier_Name.Location = New System.Drawing.Point(168, 169)
        Me.Label_Supplier_Name.Name = "Label_Supplier_Name"
        Me.Label_Supplier_Name.Size = New System.Drawing.Size(42, 14)
        Me.Label_Supplier_Name.TabIndex = 25
        Me.Label_Supplier_Name.Text = "名称:"
        Me.Label_Supplier_Name.Visible = False
        '
        'TB_ClientName
        '
        Me.TB_ClientName.Location = New System.Drawing.Point(215, 131)
        Me.TB_ClientName.Name = "TB_ClientName"
        Me.TB_ClientName.ReadOnly = True
        Me.TB_ClientName.Size = New System.Drawing.Size(111, 23)
        Me.TB_ClientName.TabIndex = 23
        Me.TB_ClientName.Visible = False
        '
        'TB_BZ_Name
        '
        Me.TB_BZ_Name.Location = New System.Drawing.Point(506, 149)
        Me.TB_BZ_Name.Name = "TB_BZ_Name"
        Me.TB_BZ_Name.ReadOnly = True
        Me.TB_BZ_Name.Size = New System.Drawing.Size(150, 23)
        Me.TB_BZ_Name.TabIndex = 30
        Me.TB_BZ_Name.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(458, 106)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(42, 14)
        Me.Label5.TabIndex = 31
        Me.Label5.Text = "布名:"
        Me.Label5.Visible = False
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Fg1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 23)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(880, 680)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "查询结果：仓位"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Fg1
        '
        Me.Fg1.AddCopyMenu = False
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
        Me.Fg1.Location = New System.Drawing.Point(3, 3)
        Me.Fg1.Name = "Fg1"
        Me.Fg1.NoShowMenu = False
        Me.Fg1.Rows.Count = 1
        Me.Fg1.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.Fg1.Size = New System.Drawing.Size(874, 674)
        Me.Fg1.StartCol = ""
        Me.Fg1.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("Fg1.Styles"))
        Me.Fg1.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.BelowData
        Me.Fg1.TabIndex = 1
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.CmdPreview)
        Me.TabPage5.Controls.Add(Me.CmdClear)
        Me.TabPage5.Controls.Add(Me.CmdAdd)
        Me.TabPage5.Controls.Add(Me.Label8)
        Me.TabPage5.Controls.Add(Me.ListBox1)
        Me.TabPage5.Controls.Add(Me.TextBox2)
        Me.TabPage5.Controls.Add(Me.Label7)
        Me.TabPage5.Controls.Add(Me.TextBox1)
        Me.TabPage5.Controls.Add(Me.Label6)
        Me.TabPage5.Controls.Add(Me.CheckedListBox1)
        Me.TabPage5.Controls.Add(Me.RadioButton4)
        Me.TabPage5.Controls.Add(Me.RadioButton3)
        Me.TabPage5.Controls.Add(Me.RadioButton2)
        Me.TabPage5.Controls.Add(Me.RadioButton1)
        Me.TabPage5.Controls.Add(Me.CmdPrint)
        Me.TabPage5.Controls.Add(Me.Label2)
        Me.TabPage5.Location = New System.Drawing.Point(4, 23)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage5.Size = New System.Drawing.Size(880, 680)
        Me.TabPage5.TabIndex = 2
        Me.TabPage5.Text = "标签打印"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'CmdPreview
        '
        Me.CmdPreview.Location = New System.Drawing.Point(241, 429)
        Me.CmdPreview.Name = "CmdPreview"
        Me.CmdPreview.Size = New System.Drawing.Size(137, 63)
        Me.CmdPreview.TabIndex = 19
        Me.CmdPreview.Text = "预览"
        Me.CmdPreview.UseVisualStyleBackColor = True
        '
        'CmdClear
        '
        Me.CmdClear.Location = New System.Drawing.Point(241, 268)
        Me.CmdClear.Name = "CmdClear"
        Me.CmdClear.Size = New System.Drawing.Size(137, 64)
        Me.CmdClear.TabIndex = 18
        Me.CmdClear.Text = "清除"
        Me.CmdClear.UseVisualStyleBackColor = True
        '
        'CmdAdd
        '
        Me.CmdAdd.Location = New System.Drawing.Point(241, 186)
        Me.CmdAdd.Name = "CmdAdd"
        Me.CmdAdd.Size = New System.Drawing.Size(137, 64)
        Me.CmdAdd.TabIndex = 17
        Me.CmdAdd.Text = "添加"
        Me.CmdAdd.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(408, 22)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(35, 14)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "预览"
        '
        'ListBox1
        '
        Me.ListBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 14
        Me.ListBox1.Location = New System.Drawing.Point(411, 39)
        Me.ListBox1.MultiColumn = True
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(463, 648)
        Me.ListBox1.TabIndex = 15
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(165, 485)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(70, 23)
        Me.TextBox2.TabIndex = 14
        Me.TextBox2.Text = "90"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(138, 489)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(21, 14)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "到"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(62, 485)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(70, 23)
        Me.TextBox1.TabIndex = 12
        Me.TextBox1.Text = "1"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(7, 489)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 14)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "数字从"
        '
        'CheckedListBox1
        '
        Me.CheckedListBox1.FormattingEnabled = True
        Me.CheckedListBox1.Location = New System.Drawing.Point(10, 39)
        Me.CheckedListBox1.Name = "CheckedListBox1"
        Me.CheckedListBox1.Size = New System.Drawing.Size(225, 436)
        Me.CheckedListBox1.TabIndex = 10
        '
        'RadioButton4
        '
        Me.RadioButton4.AutoSize = True
        Me.RadioButton4.Location = New System.Drawing.Point(241, 162)
        Me.RadioButton4.Name = "RadioButton4"
        Me.RadioButton4.Size = New System.Drawing.Size(144, 18)
        Me.RadioButton4.TabIndex = 9
        Me.RadioButton4.Text = "单号向右,双号向左"
        Me.RadioButton4.UseVisualStyleBackColor = True
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.CheckAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.RadioButton3.Checked = True
        Me.RadioButton3.Location = New System.Drawing.Point(241, 121)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(144, 18)
        Me.RadioButton3.TabIndex = 8
        Me.RadioButton3.TabStop = True
        Me.RadioButton3.Text = "单号向左,双号向右"
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(241, 80)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(81, 18)
        Me.RadioButton2.TabIndex = 7
        Me.RadioButton2.Text = "统一向右"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(241, 39)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(81, 18)
        Me.RadioButton1.TabIndex = 6
        Me.RadioButton1.Text = "统一向左"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'CmdPrint
        '
        Me.CmdPrint.Location = New System.Drawing.Point(241, 351)
        Me.CmdPrint.Name = "CmdPrint"
        Me.CmdPrint.Size = New System.Drawing.Size(137, 63)
        Me.CmdPrint.TabIndex = 4
        Me.CmdPrint.Text = "打印"
        Me.CmdPrint.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 14)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "通道"
        '
        'Cmd_Find
        '
        Me.Cmd_Find.Location = New System.Drawing.Point(747, 8)
        Me.Cmd_Find.Name = "Cmd_Find"
        Me.Cmd_Find.Size = New System.Drawing.Size(58, 24)
        Me.Cmd_Find.TabIndex = 32
        Me.Cmd_Find.Text = "查询"
        Me.Cmd_Find.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(198, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 14)
        Me.Label4.TabIndex = 29
        Me.Label4.Text = "布种编号:"
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
        'Timer1
        '
        Me.Timer1.Interval = 5000
        '
        'F40500_Store_Map
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.PanelMain)
        Me.DoubleBuffered = True
        Me.Name = "F40500_Store_Map"
        Me.Size = New System.Drawing.Size(1154, 763)
        Me.PanelMain.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TabControl2.ResumeLayout(False)
        Me.TabPage4.ResumeLayout(False)
        CType(Me.Fg2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        CType(Me.Fg_CheckedCell, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.DG, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.Fg1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage5.ResumeLayout(False)
        Me.TabPage5.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelMain As System.Windows.Forms.Panel
    Friend WithEvents DG As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents LabelPassage As System.Windows.Forms.Label
    Friend WithEvents LabelDisable As System.Windows.Forms.Label
    Friend WithEvents LabelPost As System.Windows.Forms.Label
    Friend WithEvents LabelCellA As System.Windows.Forms.Label
    Friend WithEvents LabelCell As System.Windows.Forms.Label
    Friend WithEvents LabelSel As System.Windows.Forms.Label
    Friend WithEvents LabelNormal As System.Windows.Forms.Label
    Friend WithEvents LabelEmpty As System.Windows.Forms.Label
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
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CB_Floor As System.Windows.Forms.ComboBox
    Friend WithEvents Fg_CheckedCell As PClass.FG
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents TB_ClientName As System.Windows.Forms.TextBox
    Friend WithEvents Label_Supplier_Name As System.Windows.Forms.Label
    Friend WithEvents Label_Supplier_ID As System.Windows.Forms.Label
    Friend WithEvents TB_BZ_Name As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Cmd_Find As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabControl2 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents Fg2 As PClass.FG
    Friend WithEvents Cmd_Choose As System.Windows.Forms.Button
    Friend WithEvents Cmd_Refresh As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Fg1 As PClass.FG
    Friend WithEvents CB_BZ As BaseClass.ComBoList
    Friend WithEvents CB_Client As BaseClass.ComBoList
    Friend WithEvents Cmd_Report As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TB_GHSearch As System.Windows.Forms.TextBox
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents CmdPrint As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents CheckedListBox1 As System.Windows.Forms.CheckedListBox
    Friend WithEvents RadioButton4 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents CmdAdd As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents CmdClear As System.Windows.Forms.Button
    Friend WithEvents CmdPreview As System.Windows.Forms.Button
    Friend WithEvents CB_Sel As System.Windows.Forms.ComboBox
    Friend WithEvents CK_showKC As System.Windows.Forms.CheckBox

End Class
