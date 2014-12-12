<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F30002_Produce_CG
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F30002_Produce_CG))
        Me.Tool_Top = New System.Windows.Forms.ToolStrip
        Me.Cmd_Modify = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.Cmd_Exit = New System.Windows.Forms.ToolStripButton
        Me.PanelMain1 = New System.Windows.Forms.Panel
        Me.Employee_List1 = New BaseClass.Employee_List
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.Fg1 = New PClass.FG
        Me.Fg2 = New PClass.FG
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Cmd_FGDel = New System.Windows.Forms.Button
        Me.Cmd_FGAdd = New System.Windows.Forms.Button
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.Fg3 = New PClass.FG
        Me.TB_CGRemark = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Cmd_QtyChange = New System.Windows.Forms.Button
        Me.TB_GenDan = New System.Windows.Forms.TextBox
        Me.Label45 = New System.Windows.Forms.Label
        Me.TB_KaiDan = New System.Windows.Forms.TextBox
        Me.Label44 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.TB_Remark = New System.Windows.Forms.TextBox
        Me.TB_New_PB_CountSum = New System.Windows.Forms.TextBox
        Me.TB_PB_CountSum = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.TB_ClientName = New System.Windows.Forms.TextBox
        Me.Label39 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.TB_BZName = New System.Windows.Forms.TextBox
        Me.TB_BZID = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.TB_ClientBZC = New System.Windows.Forms.TextBox
        Me.Label_ID = New System.Windows.Forms.Label
        Me.TB_BZCName = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.TB_BZCID = New System.Windows.Forms.TextBox
        Me.TB_New_PB_ZLSum = New System.Windows.Forms.TextBox
        Me.TB_PB_ZLSum = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.TB_NewGH = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TB_GH = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Pic_From = New System.Windows.Forms.Panel
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.Cmd_Cancel = New System.Windows.Forms.Button
        Me.Cmd_Ok = New System.Windows.Forms.Button
        Me.CB_OldGH = New System.Windows.Forms.ComboBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.PanelMain = New System.Windows.Forms.Panel
        Me.Btn_RemoveRow = New System.Windows.Forms.ToolStripButton
        Me.Tool_Top.SuspendLayout()
        Me.PanelMain1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.Fg1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Fg2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.Fg3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Pic_From.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.PanelMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'Tool_Top
        '
        Me.Tool_Top.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.Tool_Top.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Btn_RemoveRow, Me.Cmd_Modify, Me.ToolStripSeparator1, Me.Cmd_Exit})
        Me.Tool_Top.Location = New System.Drawing.Point(0, 0)
        Me.Tool_Top.MinimumSize = New System.Drawing.Size(0, 40)
        Me.Tool_Top.Name = "Tool_Top"
        Me.Tool_Top.Size = New System.Drawing.Size(823, 40)
        Me.Tool_Top.TabIndex = 10
        Me.Tool_Top.Text = "ToolStrip2"
        '
        'Cmd_Modify
        '
        Me.Cmd_Modify.AccessibleDescription = "修改按钮"
        Me.Cmd_Modify.AccessibleName = ""
        Me.Cmd_Modify.Image = Global.DN300_Produce.My.Resources.Resources.Modify
        Me.Cmd_Modify.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Modify.Name = "Cmd_Modify"
        Me.Cmd_Modify.Size = New System.Drawing.Size(57, 37)
        Me.Cmd_Modify.Text = "保存"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 40)
        '
        'Cmd_Exit
        '
        Me.Cmd_Exit.Image = Global.DN300_Produce.My.Resources.Resources.Close
        Me.Cmd_Exit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(57, 37)
        Me.Cmd_Exit.Text = "关闭"
        '
        'PanelMain1
        '
        Me.PanelMain1.Controls.Add(Me.Employee_List1)
        Me.PanelMain1.Controls.Add(Me.TabControl1)
        Me.PanelMain1.Controls.Add(Me.TB_CGRemark)
        Me.PanelMain1.Controls.Add(Me.Label13)
        Me.PanelMain1.Controls.Add(Me.Cmd_QtyChange)
        Me.PanelMain1.Controls.Add(Me.TB_GenDan)
        Me.PanelMain1.Controls.Add(Me.Label45)
        Me.PanelMain1.Controls.Add(Me.TB_KaiDan)
        Me.PanelMain1.Controls.Add(Me.Label44)
        Me.PanelMain1.Controls.Add(Me.Label10)
        Me.PanelMain1.Controls.Add(Me.TB_Remark)
        Me.PanelMain1.Controls.Add(Me.TB_New_PB_CountSum)
        Me.PanelMain1.Controls.Add(Me.TB_PB_CountSum)
        Me.PanelMain1.Controls.Add(Me.Label8)
        Me.PanelMain1.Controls.Add(Me.Label9)
        Me.PanelMain1.Controls.Add(Me.GroupBox3)
        Me.PanelMain1.Controls.Add(Me.GroupBox2)
        Me.PanelMain1.Controls.Add(Me.GroupBox1)
        Me.PanelMain1.Controls.Add(Me.TB_New_PB_ZLSum)
        Me.PanelMain1.Controls.Add(Me.TB_PB_ZLSum)
        Me.PanelMain1.Controls.Add(Me.Label4)
        Me.PanelMain1.Controls.Add(Me.Label3)
        Me.PanelMain1.Controls.Add(Me.TB_NewGH)
        Me.PanelMain1.Controls.Add(Me.Label2)
        Me.PanelMain1.Controls.Add(Me.TB_GH)
        Me.PanelMain1.Controls.Add(Me.Label1)
        Me.PanelMain1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelMain1.Location = New System.Drawing.Point(0, 40)
        Me.PanelMain1.Name = "PanelMain1"
        Me.PanelMain1.Padding = New System.Windows.Forms.Padding(2)
        Me.PanelMain1.Size = New System.Drawing.Size(823, 677)
        Me.PanelMain1.TabIndex = 0
        '
        'Employee_List1
        '
        Me.Employee_List1.BackColor = System.Drawing.Color.DodgerBlue
        Me.Employee_List1.IsShowAll = True
        Me.Employee_List1.IsTBLostFocusSelOne = True
        Me.Employee_List1.Location = New System.Drawing.Point(-4000, -4000)
        Me.Employee_List1.Name = "Employee_List1"
        Me.Employee_List1.SearchId = ""
        Me.Employee_List1.SearchType = BaseClass.Employee_List.ENum_SearchType.ALL
        Me.Employee_List1.Size = New System.Drawing.Size(292, 244)
        Me.Employee_List1.TabIndex = 68
        Me.Employee_List1.Visible = False
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(3, 320)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(795, 352)
        Me.TabControl1.TabIndex = 74
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.SplitContainer1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 23)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(787, 325)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "细码信息"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.Fg1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.Fg2)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel1)
        Me.SplitContainer1.Size = New System.Drawing.Size(781, 319)
        Me.SplitContainer1.SplitterDistance = 353
        Me.SplitContainer1.TabIndex = 70
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
        Me.Fg1.Location = New System.Drawing.Point(0, 0)
        Me.Fg1.Name = "Fg1"
        Me.Fg1.NoShowMenu = False
        Me.Fg1.Rows.Count = 1
        Me.Fg1.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.Fg1.Size = New System.Drawing.Size(353, 319)
        Me.Fg1.StartCol = ""
        Me.Fg1.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("Fg1.Styles"))
        Me.Fg1.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.BelowData
        Me.Fg1.TabIndex = 70
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
        Me.Fg2.Location = New System.Drawing.Point(102, 0)
        Me.Fg2.Name = "Fg2"
        Me.Fg2.NoShowMenu = False
        Me.Fg2.Rows.Count = 1
        Me.Fg2.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.Fg2.Size = New System.Drawing.Size(322, 319)
        Me.Fg2.StartCol = ""
        Me.Fg2.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("Fg2.Styles"))
        Me.Fg2.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.BelowData
        Me.Fg2.TabIndex = 69
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Cmd_FGDel)
        Me.Panel1.Controls.Add(Me.Cmd_FGAdd)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(102, 319)
        Me.Panel1.TabIndex = 70
        '
        'Cmd_FGDel
        '
        Me.Cmd_FGDel.Location = New System.Drawing.Point(11, 228)
        Me.Cmd_FGDel.Name = "Cmd_FGDel"
        Me.Cmd_FGDel.Size = New System.Drawing.Size(78, 34)
        Me.Cmd_FGDel.TabIndex = 1
        Me.Cmd_FGDel.Text = "<-"
        Me.Cmd_FGDel.UseVisualStyleBackColor = True
        '
        'Cmd_FGAdd
        '
        Me.Cmd_FGAdd.Location = New System.Drawing.Point(11, 66)
        Me.Cmd_FGAdd.Name = "Cmd_FGAdd"
        Me.Cmd_FGAdd.Size = New System.Drawing.Size(78, 34)
        Me.Cmd_FGAdd.TabIndex = 0
        Me.Cmd_FGAdd.Text = "->"
        Me.Cmd_FGAdd.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Fg3)
        Me.TabPage2.Location = New System.Drawing.Point(4, 23)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(787, 325)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "成品库存信息"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Fg3
        '
        Me.Fg3.AddCopyMenu = False
        Me.Fg3.AutoAddIndex = True
        Me.Fg3.AutoGenerateColumns = False
        Me.Fg3.AutoResize = False
        Me.Fg3.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.Fg3.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.XpThemes
        Me.Fg3.CanEditing = True
        Me.Fg3.CheckKeyPressEdit = True
        Me.Fg3.ColumnInfo = resources.GetString("Fg3.ColumnInfo")
        Me.Fg3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Fg3.EditFormat = True
        Me.Fg3.ExtendLastCol = True
        Me.Fg3.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Fg3.ForeColor = System.Drawing.Color.Black
        Me.Fg3.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.Fg3.IsAutoAddRow = True
        Me.Fg3.IsClickStartEdit = False
        Me.Fg3.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.Fg3.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.Fg3.Location = New System.Drawing.Point(3, 3)
        Me.Fg3.Name = "Fg3"
        Me.Fg3.NoShowMenu = False
        Me.Fg3.Rows.Count = 1
        Me.Fg3.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.Fg3.Size = New System.Drawing.Size(781, 319)
        Me.Fg3.StartCol = ""
        Me.Fg3.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("Fg3.Styles"))
        Me.Fg3.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.BelowData
        Me.Fg3.TabIndex = 71
        '
        'TB_CGRemark
        '
        Me.TB_CGRemark.Location = New System.Drawing.Point(348, 120)
        Me.TB_CGRemark.Multiline = True
        Me.TB_CGRemark.Name = "TB_CGRemark"
        Me.TB_CGRemark.Size = New System.Drawing.Size(457, 77)
        Me.TB_CGRemark.TabIndex = 73
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(272, 120)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(77, 14)
        Me.Label13.TabIndex = 72
        Me.Label13.Text = "拆缸原因："
        '
        'Cmd_QtyChange
        '
        Me.Cmd_QtyChange.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_QtyChange.Location = New System.Drawing.Point(604, 55)
        Me.Cmd_QtyChange.Name = "Cmd_QtyChange"
        Me.Cmd_QtyChange.Size = New System.Drawing.Size(17, 23)
        Me.Cmd_QtyChange.TabIndex = 71
        Me.Cmd_QtyChange.Text = "…"
        Me.Cmd_QtyChange.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Cmd_QtyChange.UseVisualStyleBackColor = True
        '
        'TB_GenDan
        '
        Me.TB_GenDan.Location = New System.Drawing.Point(708, 55)
        Me.TB_GenDan.Name = "TB_GenDan"
        Me.TB_GenDan.Size = New System.Drawing.Size(84, 23)
        Me.TB_GenDan.TabIndex = 3
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Location = New System.Drawing.Point(646, 59)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(56, 14)
        Me.Label45.TabIndex = 67
        Me.Label45.Text = "跟单员:"
        '
        'TB_KaiDan
        '
        Me.TB_KaiDan.Location = New System.Drawing.Point(708, 22)
        Me.TB_KaiDan.Name = "TB_KaiDan"
        Me.TB_KaiDan.ReadOnly = True
        Me.TB_KaiDan.Size = New System.Drawing.Size(84, 23)
        Me.TB_KaiDan.TabIndex = 64
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Location = New System.Drawing.Point(649, 26)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(56, 14)
        Me.Label44.TabIndex = 66
        Me.Label44.Text = "开单员:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(270, 203)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(56, 14)
        Me.Label10.TabIndex = 63
        Me.Label10.Text = "新备注:"
        '
        'TB_Remark
        '
        Me.TB_Remark.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TB_Remark.Location = New System.Drawing.Point(270, 223)
        Me.TB_Remark.Multiline = True
        Me.TB_Remark.Name = "TB_Remark"
        Me.TB_Remark.Size = New System.Drawing.Size(535, 93)
        Me.TB_Remark.TabIndex = 2
        '
        'TB_New_PB_CountSum
        '
        Me.TB_New_PB_CountSum.Location = New System.Drawing.Point(530, 55)
        Me.TB_New_PB_CountSum.Name = "TB_New_PB_CountSum"
        Me.TB_New_PB_CountSum.ReadOnly = True
        Me.TB_New_PB_CountSum.Size = New System.Drawing.Size(78, 23)
        Me.TB_New_PB_CountSum.TabIndex = 0
        '
        'TB_PB_CountSum
        '
        Me.TB_PB_CountSum.Location = New System.Drawing.Point(348, 55)
        Me.TB_PB_CountSum.Name = "TB_PB_CountSum"
        Me.TB_PB_CountSum.ReadOnly = True
        Me.TB_PB_CountSum.Size = New System.Drawing.Size(91, 23)
        Me.TB_PB_CountSum.TabIndex = 60
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(454, 58)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(70, 14)
        Me.Label8.TabIndex = 59
        Me.Label8.Text = "拆开条数:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(286, 58)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(56, 14)
        Me.Label9.TabIndex = 58
        Me.Label9.Text = "原条数:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.TB_ClientName)
        Me.GroupBox3.Controls.Add(Me.Label39)
        Me.GroupBox3.Location = New System.Drawing.Point(5, 12)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(259, 65)
        Me.GroupBox3.TabIndex = 57
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "客户"
        '
        'TB_ClientName
        '
        Me.TB_ClientName.Font = New System.Drawing.Font("宋体", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TB_ClientName.Location = New System.Drawing.Point(92, 11)
        Me.TB_ClientName.Multiline = True
        Me.TB_ClientName.Name = "TB_ClientName"
        Me.TB_ClientName.ReadOnly = True
        Me.TB_ClientName.Size = New System.Drawing.Size(152, 49)
        Me.TB_ClientName.TabIndex = 17
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
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.TB_BZName)
        Me.GroupBox2.Controls.Add(Me.TB_BZID)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Location = New System.Drawing.Point(5, 83)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(259, 93)
        Me.GroupBox2.TabIndex = 56
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "布类"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(20, 55)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 14)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "名 称:"
        '
        'TB_BZName
        '
        Me.TB_BZName.Location = New System.Drawing.Point(92, 52)
        Me.TB_BZName.Name = "TB_BZName"
        Me.TB_BZName.ReadOnly = True
        Me.TB_BZName.Size = New System.Drawing.Size(152, 23)
        Me.TB_BZName.TabIndex = 16
        '
        'TB_BZID
        '
        Me.TB_BZID.Location = New System.Drawing.Point(92, 22)
        Me.TB_BZID.Name = "TB_BZID"
        Me.TB_BZID.ReadOnly = True
        Me.TB_BZID.Size = New System.Drawing.Size(152, 23)
        Me.TB_BZID.TabIndex = 13
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(20, 25)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 14)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "编 号:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.TB_ClientBZC)
        Me.GroupBox1.Controls.Add(Me.Label_ID)
        Me.GroupBox1.Controls.Add(Me.TB_BZCName)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.TB_BZCID)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 188)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(259, 128)
        Me.GroupBox1.TabIndex = 55
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "颜色/色号"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(6, 93)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(70, 14)
        Me.Label11.TabIndex = 31
        Me.Label11.Text = "客户色号:"
        '
        'TB_ClientBZC
        '
        Me.TB_ClientBZC.Location = New System.Drawing.Point(87, 90)
        Me.TB_ClientBZC.Name = "TB_ClientBZC"
        Me.TB_ClientBZC.ReadOnly = True
        Me.TB_ClientBZC.Size = New System.Drawing.Size(152, 23)
        Me.TB_ClientBZC.TabIndex = 30
        '
        'Label_ID
        '
        Me.Label_ID.AutoSize = True
        Me.Label_ID.ForeColor = System.Drawing.Color.Blue
        Me.Label_ID.Location = New System.Drawing.Point(84, 26)
        Me.Label_ID.Name = "Label_ID"
        Me.Label_ID.Size = New System.Drawing.Size(28, 14)
        Me.Label_ID.TabIndex = 28
        Me.Label_ID.Text = "GY-"
        '
        'TB_BZCName
        '
        Me.TB_BZCName.Location = New System.Drawing.Point(87, 55)
        Me.TB_BZCName.Name = "TB_BZCName"
        Me.TB_BZCName.ReadOnly = True
        Me.TB_BZCName.Size = New System.Drawing.Size(152, 23)
        Me.TB_BZCName.TabIndex = 14
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(20, 58)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(49, 14)
        Me.Label16.TabIndex = 20
        Me.Label16.Text = "颜 色:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(20, 25)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(49, 14)
        Me.Label7.TabIndex = 27
        Me.Label7.Text = "色 号:"
        '
        'TB_BZCID
        '
        Me.TB_BZCID.Location = New System.Drawing.Point(112, 22)
        Me.TB_BZCID.Name = "TB_BZCID"
        Me.TB_BZCID.ReadOnly = True
        Me.TB_BZCID.Size = New System.Drawing.Size(127, 23)
        Me.TB_BZCID.TabIndex = 0
        '
        'TB_New_PB_ZLSum
        '
        Me.TB_New_PB_ZLSum.Location = New System.Drawing.Point(530, 87)
        Me.TB_New_PB_ZLSum.Name = "TB_New_PB_ZLSum"
        Me.TB_New_PB_ZLSum.ReadOnly = True
        Me.TB_New_PB_ZLSum.Size = New System.Drawing.Size(91, 23)
        Me.TB_New_PB_ZLSum.TabIndex = 1
        '
        'TB_PB_ZLSum
        '
        Me.TB_PB_ZLSum.Location = New System.Drawing.Point(348, 87)
        Me.TB_PB_ZLSum.Name = "TB_PB_ZLSum"
        Me.TB_PB_ZLSum.ReadOnly = True
        Me.TB_PB_ZLSum.Size = New System.Drawing.Size(91, 23)
        Me.TB_PB_ZLSum.TabIndex = 14
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(454, 90)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 14)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "拆开重量:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(286, 90)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 14)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "原重量:"
        '
        'TB_NewGH
        '
        Me.TB_NewGH.Location = New System.Drawing.Point(530, 22)
        Me.TB_NewGH.Name = "TB_NewGH"
        Me.TB_NewGH.ReadOnly = True
        Me.TB_NewGH.Size = New System.Drawing.Size(91, 23)
        Me.TB_NewGH.TabIndex = 11
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(468, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 14)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "拆缸号:"
        '
        'TB_GH
        '
        Me.TB_GH.Location = New System.Drawing.Point(348, 23)
        Me.TB_GH.Name = "TB_GH"
        Me.TB_GH.ReadOnly = True
        Me.TB_GH.Size = New System.Drawing.Size(91, 23)
        Me.TB_GH.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(286, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 14)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "原缸号:"
        '
        'Pic_From
        '
        Me.Pic_From.Controls.Add(Me.GroupBox4)
        Me.Pic_From.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pic_From.Location = New System.Drawing.Point(0, 0)
        Me.Pic_From.Name = "Pic_From"
        Me.Pic_From.Size = New System.Drawing.Size(823, 717)
        Me.Pic_From.TabIndex = 11
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Cmd_Cancel)
        Me.GroupBox4.Controls.Add(Me.Cmd_Ok)
        Me.GroupBox4.Controls.Add(Me.CB_OldGH)
        Me.GroupBox4.Controls.Add(Me.Label12)
        Me.GroupBox4.Location = New System.Drawing.Point(251, 194)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(328, 190)
        Me.GroupBox4.TabIndex = 0
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "转移到"
        '
        'Cmd_Cancel
        '
        Me.Cmd_Cancel.Location = New System.Drawing.Point(198, 105)
        Me.Cmd_Cancel.Name = "Cmd_Cancel"
        Me.Cmd_Cancel.Size = New System.Drawing.Size(88, 47)
        Me.Cmd_Cancel.TabIndex = 3
        Me.Cmd_Cancel.Text = "取消"
        Me.Cmd_Cancel.UseVisualStyleBackColor = True
        '
        'Cmd_Ok
        '
        Me.Cmd_Ok.Location = New System.Drawing.Point(61, 106)
        Me.Cmd_Ok.Name = "Cmd_Ok"
        Me.Cmd_Ok.Size = New System.Drawing.Size(88, 47)
        Me.Cmd_Ok.TabIndex = 2
        Me.Cmd_Ok.Text = "确认"
        Me.Cmd_Ok.UseVisualStyleBackColor = True
        '
        'CB_OldGH
        '
        Me.CB_OldGH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_OldGH.FormattingEnabled = True
        Me.CB_OldGH.Location = New System.Drawing.Point(120, 41)
        Me.CB_OldGH.Name = "CB_OldGH"
        Me.CB_OldGH.Size = New System.Drawing.Size(166, 22)
        Me.CB_OldGH.TabIndex = 1
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(39, 46)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(70, 14)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "原有缸号:"
        '
        'PanelMain
        '
        Me.PanelMain.Controls.Add(Me.PanelMain1)
        Me.PanelMain.Controls.Add(Me.Tool_Top)
        Me.PanelMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelMain.Location = New System.Drawing.Point(0, 0)
        Me.PanelMain.Name = "PanelMain"
        Me.PanelMain.Size = New System.Drawing.Size(823, 717)
        Me.PanelMain.TabIndex = 1
        '
        'Btn_RemoveRow
        '
        Me.Btn_RemoveRow.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Btn_RemoveRow.Name = "Btn_RemoveRow"
        Me.Btn_RemoveRow.Size = New System.Drawing.Size(33, 37)
        Me.Btn_RemoveRow.Text = "减行"
        '
        'F30002_Produce_CG
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.PanelMain)
        Me.Controls.Add(Me.Pic_From)
        Me.Name = "F30002_Produce_CG"
        Me.Size = New System.Drawing.Size(823, 717)
        Me.Title = "拆缸"
        Me.Tool_Top.ResumeLayout(False)
        Me.Tool_Top.PerformLayout()
        Me.PanelMain1.ResumeLayout(False)
        Me.PanelMain1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.Fg1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Fg2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        CType(Me.Fg3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Pic_From.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.PanelMain.ResumeLayout(False)
        Me.PanelMain.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Tool_Top As System.Windows.Forms.ToolStrip
    Friend WithEvents Cmd_Modify As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_Exit As System.Windows.Forms.ToolStripButton
    Friend WithEvents PanelMain1 As System.Windows.Forms.Panel
    Friend WithEvents Pic_From As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TB_NewGH As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TB_GH As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TB_New_PB_ZLSum As System.Windows.Forms.TextBox
    Friend WithEvents TB_PB_ZLSum As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents TB_ClientName As System.Windows.Forms.TextBox
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TB_BZName As System.Windows.Forms.TextBox
    Friend WithEvents TB_BZID As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label_ID As System.Windows.Forms.Label
    Friend WithEvents TB_BZCName As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TB_BZCID As System.Windows.Forms.TextBox
    Friend WithEvents TB_New_PB_CountSum As System.Windows.Forms.TextBox
    Friend WithEvents TB_PB_CountSum As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TB_Remark As System.Windows.Forms.TextBox
    Friend WithEvents TB_GenDan As System.Windows.Forms.TextBox
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents TB_KaiDan As System.Windows.Forms.TextBox
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents Employee_List1 As BaseClass.Employee_List
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TB_ClientBZC As System.Windows.Forms.TextBox
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Fg1 As PClass.FG
    Friend WithEvents Fg2 As PClass.FG
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Cmd_FGDel As System.Windows.Forms.Button
    Friend WithEvents Cmd_FGAdd As System.Windows.Forms.Button
    Friend WithEvents Cmd_QtyChange As System.Windows.Forms.Button
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Cmd_Cancel As System.Windows.Forms.Button
    Friend WithEvents Cmd_Ok As System.Windows.Forms.Button
    Friend WithEvents CB_OldGH As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents PanelMain As System.Windows.Forms.Panel
    Friend WithEvents TB_CGRemark As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Fg3 As PClass.FG
    Friend WithEvents Btn_RemoveRow As System.Windows.Forms.ToolStripButton

End Class
