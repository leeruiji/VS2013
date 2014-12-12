<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F10053_WorkList_Msg
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F10053_WorkList_Msg))
        Me.Tool_Top = New System.Windows.Forms.ToolStrip
        Me.Cmd_Modify = New System.Windows.Forms.ToolStripButton
        Me.Cmd_Del = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.Cmd_AddWorkList = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.Cmd_AddRowBefore = New System.Windows.Forms.ToolStripButton
        Me.Cmd_AddRowAfter = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.Cmd_Exit = New System.Windows.Forms.ToolStripButton
        Me.LB_Area = New System.Windows.Forms.Label
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.LB_FullName = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.TB_Name = New System.Windows.Forms.TextBox
        Me.TB_Remark = New System.Windows.Forms.TextBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.TB_UPD_USER = New System.Windows.Forms.TextBox
        Me.TB_Founder = New System.Windows.Forms.TextBox
        Me.DP_UPD_DATE = New System.Windows.Forms.DateTimePicker
        Me.DP_Found_Date = New System.Windows.Forms.DateTimePicker
        Me.Fg1 = New PClass.FG
        Me.TB_SupplierName = New System.Windows.Forms.Label
        Me.TB_ID = New System.Windows.Forms.TextBox
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.Fg_Sel = New PClass.FG
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton5 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton6 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripButton7 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton8 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator
        Me.Cmd_ShowList = New System.Windows.Forms.ToolStripButton
        Me.PanelMain = New System.Windows.Forms.Panel
        Me.Tool_Top.SuspendLayout()
        CType(Me.Fg1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.Fg_Sel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.PanelMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'Tool_Top
        '
        Me.Tool_Top.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.Tool_Top.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Cmd_Modify, Me.Cmd_Del, Me.ToolStripSeparator2, Me.Cmd_AddWorkList, Me.ToolStripSeparator4, Me.Cmd_AddRowBefore, Me.Cmd_AddRowAfter, Me.ToolStripSeparator3, Me.ToolStripSeparator1, Me.Cmd_Exit})
        Me.Tool_Top.Location = New System.Drawing.Point(0, 0)
        Me.Tool_Top.MinimumSize = New System.Drawing.Size(0, 40)
        Me.Tool_Top.Name = "Tool_Top"
        Me.Tool_Top.Size = New System.Drawing.Size(980, 40)
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
        Me.Cmd_Modify.Size = New System.Drawing.Size(57, 37)
        Me.Cmd_Modify.Text = "保存"
        '
        'Cmd_Del
        '
        Me.Cmd_Del.AccessibleDescription = "修改按钮"
        Me.Cmd_Del.AccessibleName = ""
        Me.Cmd_Del.Image = Global.DN100_BasicInfo.My.Resources.Resources.Delete
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
        'Cmd_AddWorkList
        '
        Me.Cmd_AddWorkList.Image = Global.DN100_BasicInfo.My.Resources.Resources.GY
        Me.Cmd_AddWorkList.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_AddWorkList.Name = "Cmd_AddWorkList"
        Me.Cmd_AddWorkList.Size = New System.Drawing.Size(81, 37)
        Me.Cmd_AddWorkList.Text = "添加集合"
        Me.Cmd_AddWorkList.ToolTipText = "加工集合将会插入到最后"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 40)
        '
        'Cmd_AddRowBefore
        '
        Me.Cmd_AddRowBefore.Image = Global.DN100_BasicInfo.My.Resources.Resources.AddRow
        Me.Cmd_AddRowBefore.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_AddRowBefore.Name = "Cmd_AddRowBefore"
        Me.Cmd_AddRowBefore.Size = New System.Drawing.Size(57, 37)
        Me.Cmd_AddRowBefore.Text = "前加"
        Me.Cmd_AddRowBefore.ToolTipText = "添加的加工内容会插入到你所选的行的前面"
        '
        'Cmd_AddRowAfter
        '
        Me.Cmd_AddRowAfter.Image = Global.DN100_BasicInfo.My.Resources.Resources.AddRow
        Me.Cmd_AddRowAfter.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_AddRowAfter.Name = "Cmd_AddRowAfter"
        Me.Cmd_AddRowAfter.Size = New System.Drawing.Size(57, 37)
        Me.Cmd_AddRowAfter.Text = "后加"
        Me.Cmd_AddRowAfter.ToolTipText = "添加的加工内容会插入到你所选的行的后面"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 40)
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 40)
        '
        'Cmd_Exit
        '
        Me.Cmd_Exit.Image = Global.DN100_BasicInfo.My.Resources.Resources.Close
        Me.Cmd_Exit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(57, 37)
        Me.Cmd_Exit.Text = "关闭"
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
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'LB_FullName
        '
        Me.LB_FullName.AutoSize = True
        Me.LB_FullName.Location = New System.Drawing.Point(192, 21)
        Me.LB_FullName.Name = "LB_FullName"
        Me.LB_FullName.Size = New System.Drawing.Size(98, 14)
        Me.LB_FullName.TabIndex = 5
        Me.LB_FullName.Text = "加工集合名称:"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(31, 50)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(42, 14)
        Me.Label19.TabIndex = 6
        Me.Label19.Text = "备注:"
        '
        'TB_Name
        '
        Me.TB_Name.Location = New System.Drawing.Point(296, 18)
        Me.TB_Name.Name = "TB_Name"
        Me.TB_Name.Size = New System.Drawing.Size(317, 23)
        Me.TB_Name.TabIndex = 0
        '
        'TB_Remark
        '
        Me.TB_Remark.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TB_Remark.Location = New System.Drawing.Point(79, 47)
        Me.TB_Remark.Multiline = True
        Me.TB_Remark.Name = "TB_Remark"
        Me.TB_Remark.Size = New System.Drawing.Size(715, 59)
        Me.TB_Remark.TabIndex = 2
        '
        'Label22
        '
        Me.Label22.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(578, 567)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(84, 14)
        Me.Label22.TabIndex = 16
        Me.Label22.Text = "最后修改人:"
        Me.Label22.Visible = False
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(606, 600)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 14)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "创建人:"
        Me.Label5.Visible = False
        '
        'Label23
        '
        Me.Label23.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(792, 562)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(98, 14)
        Me.Label23.TabIndex = 18
        Me.Label23.Text = "最后修改时间:"
        Me.Label23.Visible = False
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(820, 600)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(70, 14)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "创建时间:"
        Me.Label6.Visible = False
        '
        'TB_UPD_USER
        '
        Me.TB_UPD_USER.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TB_UPD_USER.Location = New System.Drawing.Point(667, 560)
        Me.TB_UPD_USER.Name = "TB_UPD_USER"
        Me.TB_UPD_USER.ReadOnly = True
        Me.TB_UPD_USER.Size = New System.Drawing.Size(115, 23)
        Me.TB_UPD_USER.TabIndex = 26
        Me.TB_UPD_USER.Visible = False
        '
        'TB_Founder
        '
        Me.TB_Founder.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TB_Founder.Location = New System.Drawing.Point(667, 597)
        Me.TB_Founder.Name = "TB_Founder"
        Me.TB_Founder.ReadOnly = True
        Me.TB_Founder.Size = New System.Drawing.Size(115, 23)
        Me.TB_Founder.TabIndex = 25
        Me.TB_Founder.Visible = False
        '
        'DP_UPD_DATE
        '
        Me.DP_UPD_DATE.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.DP_UPD_DATE.Enabled = False
        Me.DP_UPD_DATE.Location = New System.Drawing.Point(889, 558)
        Me.DP_UPD_DATE.Name = "DP_UPD_DATE"
        Me.DP_UPD_DATE.Size = New System.Drawing.Size(115, 23)
        Me.DP_UPD_DATE.TabIndex = 27
        Me.DP_UPD_DATE.Visible = False
        '
        'DP_Found_Date
        '
        Me.DP_Found_Date.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.DP_Found_Date.Enabled = False
        Me.DP_Found_Date.Location = New System.Drawing.Point(889, 594)
        Me.DP_Found_Date.Name = "DP_Found_Date"
        Me.DP_Found_Date.Size = New System.Drawing.Size(115, 23)
        Me.DP_Found_Date.TabIndex = 28
        Me.DP_Found_Date.Visible = False
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
        Me.Fg1.IsClickStartEdit = True
        Me.Fg1.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.Fg1.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.Fg1.Location = New System.Drawing.Point(58, 0)
        Me.Fg1.Name = "Fg1"
        Me.Fg1.Rows.Count = 1
        Me.Fg1.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.Fg1.Size = New System.Drawing.Size(470, 502)
        Me.Fg1.StartCol = "WL_No"
        Me.Fg1.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("Fg1.Styles"))
        Me.Fg1.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.BelowData
        Me.Fg1.TabIndex = 31
        '
        'TB_SupplierName
        '
        Me.TB_SupplierName.AutoSize = True
        Me.TB_SupplierName.Location = New System.Drawing.Point(31, 21)
        Me.TB_SupplierName.Name = "TB_SupplierName"
        Me.TB_SupplierName.Size = New System.Drawing.Size(42, 14)
        Me.TB_SupplierName.TabIndex = 32
        Me.TB_SupplierName.Text = "编号:"
        '
        'TB_ID
        '
        Me.TB_ID.Enabled = False
        Me.TB_ID.Location = New System.Drawing.Point(79, 18)
        Me.TB_ID.Name = "TB_ID"
        Me.TB_ID.ReadOnly = True
        Me.TB_ID.Size = New System.Drawing.Size(107, 23)
        Me.TB_ID.TabIndex = 33
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.Location = New System.Drawing.Point(3, 112)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.Fg_Sel)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.Fg1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.ToolStrip1)
        Me.SplitContainer1.Size = New System.Drawing.Size(972, 502)
        Me.SplitContainer1.SplitterDistance = 440
        Me.SplitContainer1.TabIndex = 34
        '
        'Fg_Sel
        '
        Me.Fg_Sel.AllowEditing = False
        Me.Fg_Sel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Fg_Sel.AutoAddIndex = True
        Me.Fg_Sel.AutoGenerateColumns = False
        Me.Fg_Sel.AutoResize = False
        Me.Fg_Sel.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.Fg_Sel.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.XpThemes
        Me.Fg_Sel.CanEditing = False
        Me.Fg_Sel.ColumnInfo = resources.GetString("Fg_Sel.ColumnInfo")
        Me.Fg_Sel.EditFormat = True
        Me.Fg_Sel.ExtendLastCol = True
        Me.Fg_Sel.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Fg_Sel.ForeColor = System.Drawing.Color.Black
        Me.Fg_Sel.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.Fg_Sel.IsAutoAddRow = True
        Me.Fg_Sel.IsClickStartEdit = True
        Me.Fg_Sel.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.Fg_Sel.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.Fg_Sel.Location = New System.Drawing.Point(0, 0)
        Me.Fg_Sel.Name = "Fg_Sel"
        Me.Fg_Sel.Rows.Count = 1
        Me.Fg_Sel.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.Fg_Sel.Size = New System.Drawing.Size(440, 502)
        Me.Fg_Sel.StartCol = "WL_No"
        Me.Fg_Sel.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("Fg_Sel.Styles"))
        Me.Fg_Sel.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.BelowData
        Me.Fg_Sel.TabIndex = 32
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Left
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator5, Me.ToolStripButton3, Me.ToolStripSeparator6, Me.ToolStripButton4, Me.ToolStripButton5, Me.ToolStripButton6, Me.ToolStripSeparator7, Me.ToolStripButton7, Me.ToolStripButton8, Me.ToolStripSeparator8, Me.Cmd_ShowList})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.MinimumSize = New System.Drawing.Size(0, 40)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(58, 502)
        Me.ToolStrip1.TabIndex = 32
        Me.ToolStrip1.Text = "ToolStrip2"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(55, 6)
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.Image = Global.DN100_BasicInfo.My.Resources.Resources.GY
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Margin = New System.Windows.Forms.Padding(0, 10, 0, 2)
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(55, 40)
        Me.ToolStripButton3.Text = "添加集合"
        Me.ToolStripButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ToolStripButton3.ToolTipText = "加工集合将会插入到最后"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(55, 6)
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.Image = Global.DN100_BasicInfo.My.Resources.Resources.AddRow
        Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton4.Margin = New System.Windows.Forms.Padding(0, 10, 0, 2)
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.Size = New System.Drawing.Size(55, 40)
        Me.ToolStripButton4.Text = "前加->"
        Me.ToolStripButton4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ToolStripButton4.ToolTipText = "添加的加工内容会插入到你所选的行的前面"
        '
        'ToolStripButton5
        '
        Me.ToolStripButton5.Image = Global.DN100_BasicInfo.My.Resources.Resources.AddRow
        Me.ToolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton5.Margin = New System.Windows.Forms.Padding(0, 10, 0, 2)
        Me.ToolStripButton5.Name = "ToolStripButton5"
        Me.ToolStripButton5.Size = New System.Drawing.Size(55, 40)
        Me.ToolStripButton5.Text = "后加->"
        Me.ToolStripButton5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ToolStripButton5.ToolTipText = "添加的加工内容会插入到你所选的行的后面"
        '
        'ToolStripButton6
        '
        Me.ToolStripButton6.Image = Global.DN100_BasicInfo.My.Resources.Resources.RemoveRow
        Me.ToolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton6.Margin = New System.Windows.Forms.Padding(0, 10, 0, 2)
        Me.ToolStripButton6.Name = "ToolStripButton6"
        Me.ToolStripButton6.Size = New System.Drawing.Size(55, 40)
        Me.ToolStripButton6.Text = "<-减行"
        Me.ToolStripButton6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(55, 6)
        '
        'ToolStripButton7
        '
        Me.ToolStripButton7.Image = Global.DN100_BasicInfo.My.Resources.Resources.up
        Me.ToolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton7.Margin = New System.Windows.Forms.Padding(0, 10, 0, 2)
        Me.ToolStripButton7.Name = "ToolStripButton7"
        Me.ToolStripButton7.Size = New System.Drawing.Size(55, 40)
        Me.ToolStripButton7.Text = "上移"
        Me.ToolStripButton7.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripButton8
        '
        Me.ToolStripButton8.Image = Global.DN100_BasicInfo.My.Resources.Resources.down
        Me.ToolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton8.Margin = New System.Windows.Forms.Padding(0, 10, 0, 2)
        Me.ToolStripButton8.Name = "ToolStripButton8"
        Me.ToolStripButton8.Size = New System.Drawing.Size(55, 40)
        Me.ToolStripButton8.Text = "下移"
        Me.ToolStripButton8.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(55, 6)
        '
        'Cmd_ShowList
        '
        Me.Cmd_ShowList.CheckOnClick = True
        Me.Cmd_ShowList.Image = Global.DN100_BasicInfo.My.Resources.Resources.Word
        Me.Cmd_ShowList.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_ShowList.Name = "Cmd_ShowList"
        Me.Cmd_ShowList.Size = New System.Drawing.Size(55, 40)
        Me.Cmd_ShowList.Text = "全显"
        Me.Cmd_ShowList.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'PanelMain
        '
        Me.PanelMain.Controls.Add(Me.SplitContainer1)
        Me.PanelMain.Controls.Add(Me.TB_ID)
        Me.PanelMain.Controls.Add(Me.TB_SupplierName)
        Me.PanelMain.Controls.Add(Me.DP_Found_Date)
        Me.PanelMain.Controls.Add(Me.DP_UPD_DATE)
        Me.PanelMain.Controls.Add(Me.TB_Founder)
        Me.PanelMain.Controls.Add(Me.TB_UPD_USER)
        Me.PanelMain.Controls.Add(Me.Label6)
        Me.PanelMain.Controls.Add(Me.Label23)
        Me.PanelMain.Controls.Add(Me.Label5)
        Me.PanelMain.Controls.Add(Me.Label22)
        Me.PanelMain.Controls.Add(Me.TB_Remark)
        Me.PanelMain.Controls.Add(Me.TB_Name)
        Me.PanelMain.Controls.Add(Me.Label19)
        Me.PanelMain.Controls.Add(Me.LB_FullName)
        Me.PanelMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelMain.Location = New System.Drawing.Point(0, 40)
        Me.PanelMain.Name = "PanelMain"
        Me.PanelMain.Padding = New System.Windows.Forms.Padding(2)
        Me.PanelMain.Size = New System.Drawing.Size(980, 619)
        Me.PanelMain.TabIndex = 12
        '
        'F10053_WorkList_Msg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CanMaxSize = True
        Me.Controls.Add(Me.PanelMain)
        Me.Controls.Add(Me.Tool_Top)
        Me.Controls.Add(Me.LB_Area)
        Me.Name = "F10053_WorkList_Msg"
        Me.Size = New System.Drawing.Size(980, 659)
        Me.Title = "加工集合信息"
        Me.Tool_Top.ResumeLayout(False)
        Me.Tool_Top.PerformLayout()
        CType(Me.Fg1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.Fg_Sel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.PanelMain.ResumeLayout(False)
        Me.PanelMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Tool_Top As System.Windows.Forms.ToolStrip
    Friend WithEvents Cmd_Modify As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_Del As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Cmd_Exit As System.Windows.Forms.ToolStripButton
    Friend WithEvents LB_Area As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Cmd_AddRowBefore As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Cmd_AddRowAfter As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_AddWorkList As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents LB_FullName As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents TB_Name As System.Windows.Forms.TextBox
    Friend WithEvents TB_Remark As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TB_UPD_USER As System.Windows.Forms.TextBox
    Friend WithEvents TB_Founder As System.Windows.Forms.TextBox
    Friend WithEvents DP_UPD_DATE As System.Windows.Forms.DateTimePicker
    Friend WithEvents DP_Found_Date As System.Windows.Forms.DateTimePicker
    Friend WithEvents Fg1 As PClass.FG
    Friend WithEvents TB_SupplierName As System.Windows.Forms.Label
    Friend WithEvents TB_ID As System.Windows.Forms.TextBox
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Fg_Sel As PClass.FG
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton5 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton6 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton7 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton8 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PanelMain As System.Windows.Forms.Panel
    Friend WithEvents Cmd_ShowList As System.Windows.Forms.ToolStripButton

End Class
