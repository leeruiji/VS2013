﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F20320_DXLingLiao
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F20320_DXLingLiao))
        Me.Tool_Top = New System.Windows.Forms.ToolStrip()
        Me.Cmd_Add = New System.Windows.Forms.ToolStripButton()
        Me.Cmd_Modify = New System.Windows.Forms.ToolStripButton()
        Me.Cmd_Del = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.Cmd_ShowList = New System.Windows.Forms.ToolStripButton()
        Me.Cmd_Refresh = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.Cmd_Preview = New System.Windows.Forms.ToolStripButton()
        Me.Cmd_Preview2 = New System.Windows.Forms.ToolStripButton()
        Me.Cmd_Print = New System.Windows.Forms.ToolStripButton()
        Me.Cmd_Print2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.Cmd_Audit = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel5 = New System.Windows.Forms.ToolStripLabel()
        Me.TSP_Autited = New PClass.ToolStripDateTimePicker()
        Me.Cmd_Exit = New System.Windows.Forms.ToolStripButton()
        Me.LB_ZL = New System.Windows.Forms.ToolStripLabel()
        Me.LaB_ZL = New System.Windows.Forms.ToolStripLabel()
        Me.LB_Qty = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel6 = New System.Windows.Forms.ToolStripLabel()
        Me.LB_Amount = New System.Windows.Forms.ToolStripLabel()
        Me.LabelZJE = New System.Windows.Forms.ToolStripLabel()
        Me.FG1 = New PClass.FG()
        Me.CMS_FG1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Cmd_ChooseAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.Cmd_UnChooseAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.Cmd_UnChoose = New System.Windows.Forms.ToolStripMenuItem()
        Me.PanelMain = New System.Windows.Forms.Panel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.SumFG1 = New BaseClass.SumFG()
        Me.Fg2 = New PClass.FG()
        Me.SumFG2 = New BaseClass.SumFG()
        Me.Tool_Search = New System.Windows.Forms.ToolStrip()
        Me.TSD_Date = New System.Windows.Forms.ToolStripDropDownButton()
        Me.TSM_sDate = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSM_Audited_Date = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripLabel4 = New System.Windows.Forms.ToolStripLabel()
        Me.DP_Start = New PClass.ToolStripDateTimePicker()
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel()
        Me.DP_End = New PClass.ToolStripDateTimePicker()
        Me.CB_Condition3 = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.CB_ConditionName1 = New System.Windows.Forms.ToolStripComboBox()
        Me.TB_ConditionValue1 = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.CB_ConditionName2 = New System.Windows.Forms.ToolStripComboBox()
        Me.CB_ConditionValue2 = New System.Windows.Forms.ToolStripComboBox()
        Me.Btn_Search = New System.Windows.Forms.ToolStripButton()
        Me.Tool_Top.SuspendLayout()
        CType(Me.FG1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CMS_FG1.SuspendLayout()
        Me.PanelMain.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.Fg2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tool_Search.SuspendLayout()
        Me.SuspendLayout()
        '
        'Tool_Top
        '
        Me.Tool_Top.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.Tool_Top.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Cmd_Add, Me.Cmd_Modify, Me.Cmd_Del, Me.ToolStripSeparator2, Me.Cmd_ShowList, Me.Cmd_Refresh, Me.ToolStripSeparator3, Me.Cmd_Preview, Me.Cmd_Preview2, Me.Cmd_Print, Me.Cmd_Print2, Me.ToolStripSeparator1, Me.Cmd_Audit, Me.ToolStripSeparator5, Me.ToolStripLabel5, Me.TSP_Autited, Me.Cmd_Exit, Me.LB_ZL, Me.LaB_ZL, Me.LB_Qty, Me.ToolStripLabel6, Me.LB_Amount, Me.LabelZJE})
        Me.Tool_Top.Location = New System.Drawing.Point(2, 2)
        Me.Tool_Top.MinimumSize = New System.Drawing.Size(0, 40)
        Me.Tool_Top.Name = "Tool_Top"
        Me.Tool_Top.Size = New System.Drawing.Size(973, 40)
        Me.Tool_Top.TabIndex = 10
        Me.Tool_Top.Text = "ToolStrip2"
        '
        'Cmd_Add
        '
        Me.Cmd_Add.AccessibleDescription = "新增"
        Me.Cmd_Add.AccessibleName = ""
        Me.Cmd_Add.Image = Global.DN200_Purchase.My.Resources.Resources.ADD
        Me.Cmd_Add.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Add.Name = "Cmd_Add"
        Me.Cmd_Add.Size = New System.Drawing.Size(60, 37)
        Me.Cmd_Add.Text = "新增"
        '
        'Cmd_Modify
        '
        Me.Cmd_Modify.AccessibleDescription = "修改按钮"
        Me.Cmd_Modify.AccessibleName = ""
        Me.Cmd_Modify.Image = Global.DN200_Purchase.My.Resources.Resources.Modify
        Me.Cmd_Modify.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Modify.Name = "Cmd_Modify"
        Me.Cmd_Modify.Size = New System.Drawing.Size(60, 37)
        Me.Cmd_Modify.Text = "修改"
        '
        'Cmd_Del
        '
        Me.Cmd_Del.AccessibleDescription = "修改按钮"
        Me.Cmd_Del.AccessibleName = ""
        Me.Cmd_Del.Image = Global.DN200_Purchase.My.Resources.Resources.Delete
        Me.Cmd_Del.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Del.Name = "Cmd_Del"
        Me.Cmd_Del.Size = New System.Drawing.Size(60, 37)
        Me.Cmd_Del.Text = "删除"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 40)
        '
        'Cmd_ShowList
        '
        Me.Cmd_ShowList.CheckOnClick = True
        Me.Cmd_ShowList.Image = Global.DN200_Purchase.My.Resources.Resources.Word
        Me.Cmd_ShowList.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_ShowList.Name = "Cmd_ShowList"
        Me.Cmd_ShowList.Size = New System.Drawing.Size(84, 37)
        Me.Cmd_ShowList.Text = "显示明细"
        '
        'Cmd_Refresh
        '
        Me.Cmd_Refresh.Image = Global.DN200_Purchase.My.Resources.Resources.ReFresh
        Me.Cmd_Refresh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Refresh.Name = "Cmd_Refresh"
        Me.Cmd_Refresh.Size = New System.Drawing.Size(60, 37)
        Me.Cmd_Refresh.Text = "刷新"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 40)
        '
        'Cmd_Preview
        '
        Me.Cmd_Preview.Image = Global.DN200_Purchase.My.Resources.Resources.Print_preview
        Me.Cmd_Preview.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Preview.Name = "Cmd_Preview"
        Me.Cmd_Preview.Size = New System.Drawing.Size(60, 37)
        Me.Cmd_Preview.Text = "预览"
        '
        'Cmd_Preview2
        '
        Me.Cmd_Preview2.Image = Global.DN200_Purchase.My.Resources.Resources.Print_preview
        Me.Cmd_Preview2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Preview2.Name = "Cmd_Preview2"
        Me.Cmd_Preview2.Size = New System.Drawing.Size(67, 37)
        Me.Cmd_Preview2.Text = "预览2"
        Me.Cmd_Preview2.Visible = False
        '
        'Cmd_Print
        '
        Me.Cmd_Print.Image = Global.DN200_Purchase.My.Resources.Resources.print
        Me.Cmd_Print.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Print.Name = "Cmd_Print"
        Me.Cmd_Print.Size = New System.Drawing.Size(60, 37)
        Me.Cmd_Print.Text = "打印"
        '
        'Cmd_Print2
        '
        Me.Cmd_Print2.Image = Global.DN200_Purchase.My.Resources.Resources.print
        Me.Cmd_Print2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Print2.Name = "Cmd_Print2"
        Me.Cmd_Print2.Size = New System.Drawing.Size(67, 37)
        Me.Cmd_Print2.Text = "打印2"
        Me.Cmd_Print2.Visible = False
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 40)
        '
        'Cmd_Audit
        '
        Me.Cmd_Audit.Image = Global.DN200_Purchase.My.Resources.Resources.apply
        Me.Cmd_Audit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Audit.Name = "Cmd_Audit"
        Me.Cmd_Audit.Size = New System.Drawing.Size(60, 37)
        Me.Cmd_Audit.Text = "审核"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 40)
        '
        'ToolStripLabel5
        '
        Me.ToolStripLabel5.Name = "ToolStripLabel5"
        Me.ToolStripLabel5.Size = New System.Drawing.Size(68, 37)
        Me.ToolStripLabel5.Text = "审核时间："
        '
        'TSP_Autited
        '
        Me.TSP_Autited.Name = "TSP_Autited"
        Me.TSP_Autited.Size = New System.Drawing.Size(100, 37)
        Me.TSP_Autited.Text = "2012-08-02"
        Me.TSP_Autited.Value = New Date(2012, 8, 2, 0, 0, 0, 0)
        '
        'Cmd_Exit
        '
        Me.Cmd_Exit.Image = CType(resources.GetObject("Cmd_Exit.Image"), System.Drawing.Image)
        Me.Cmd_Exit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(60, 37)
        Me.Cmd_Exit.Text = "关闭"
        '
        'LB_ZL
        '
        Me.LB_ZL.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.LB_ZL.ForeColor = System.Drawing.Color.Blue
        Me.LB_ZL.Name = "LB_ZL"
        Me.LB_ZL.Size = New System.Drawing.Size(15, 37)
        Me.LB_ZL.Text = "0"
        '
        'LaB_ZL
        '
        Me.LaB_ZL.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.LaB_ZL.Name = "LaB_ZL"
        Me.LaB_ZL.Size = New System.Drawing.Size(56, 37)
        Me.LaB_ZL.Text = "总胚重："
        '
        'LB_Qty
        '
        Me.LB_Qty.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.LB_Qty.ForeColor = System.Drawing.Color.Blue
        Me.LB_Qty.Name = "LB_Qty"
        Me.LB_Qty.Size = New System.Drawing.Size(15, 37)
        Me.LB_Qty.Text = "0"
        '
        'ToolStripLabel6
        '
        Me.ToolStripLabel6.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel6.Name = "ToolStripLabel6"
        Me.ToolStripLabel6.Size = New System.Drawing.Size(56, 37)
        Me.ToolStripLabel6.Text = "总条数："
        '
        'LB_Amount
        '
        Me.LB_Amount.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.LB_Amount.ForeColor = System.Drawing.Color.Blue
        Me.LB_Amount.Name = "LB_Amount"
        Me.LB_Amount.Size = New System.Drawing.Size(15, 37)
        Me.LB_Amount.Text = "0"
        '
        'LabelZJE
        '
        Me.LabelZJE.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.LabelZJE.Name = "LabelZJE"
        Me.LabelZJE.Size = New System.Drawing.Size(56, 17)
        Me.LabelZJE.Text = "总金额："
        '
        'FG1
        '
        Me.FG1.AddCopyMenu = False
        Me.FG1.AllowEditing = False
        Me.FG1.AutoAddIndex = True
        Me.FG1.AutoGenerateColumns = False
        Me.FG1.AutoResize = False
        Me.FG1.BackColor = System.Drawing.Color.White
        Me.FG1.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.XpThemes
        Me.FG1.CanEditing = False
        Me.FG1.CheckKeyPressEdit = True
        Me.FG1.ColumnInfo = resources.GetString("FG1.ColumnInfo")
        Me.FG1.ContextMenuStrip = Me.CMS_FG1
        Me.FG1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FG1.EditFormat = True
        Me.FG1.ExtendLastCol = True
        Me.FG1.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.FG1.ForeColor = System.Drawing.Color.Black
        Me.FG1.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.FG1.IsAutoAddRow = True
        Me.FG1.IsClickStartEdit = False
        Me.FG1.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.FG1.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.FG1.Location = New System.Drawing.Point(0, 0)
        Me.FG1.Name = "FG1"
        Me.FG1.NoShowMenu = False
        Me.FG1.Rows.Count = 1
        Me.FG1.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.FG1.Size = New System.Drawing.Size(973, 290)
        Me.FG1.StartCol = ""
        Me.FG1.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("FG1.Styles"))
        Me.FG1.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.BelowData
        Me.FG1.TabIndex = 11
        '
        'CMS_FG1
        '
        Me.CMS_FG1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Cmd_ChooseAll, Me.Cmd_UnChooseAll, Me.Cmd_UnChoose})
        Me.CMS_FG1.Name = "CMS_FG1"
        Me.CMS_FG1.Size = New System.Drawing.Size(113, 70)
        '
        'Cmd_ChooseAll
        '
        Me.Cmd_ChooseAll.Name = "Cmd_ChooseAll"
        Me.Cmd_ChooseAll.Size = New System.Drawing.Size(112, 22)
        Me.Cmd_ChooseAll.Text = "全选"
        '
        'Cmd_UnChooseAll
        '
        Me.Cmd_UnChooseAll.Name = "Cmd_UnChooseAll"
        Me.Cmd_UnChooseAll.Size = New System.Drawing.Size(112, 22)
        Me.Cmd_UnChooseAll.Text = "全不选"
        '
        'Cmd_UnChoose
        '
        Me.Cmd_UnChoose.Name = "Cmd_UnChoose"
        Me.Cmd_UnChoose.Size = New System.Drawing.Size(112, 22)
        Me.Cmd_UnChoose.Text = "反选"
        '
        'PanelMain
        '
        Me.PanelMain.Controls.Add(Me.SplitContainer1)
        Me.PanelMain.Controls.Add(Me.Tool_Search)
        Me.PanelMain.Controls.Add(Me.Tool_Top)
        Me.PanelMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelMain.Location = New System.Drawing.Point(0, 0)
        Me.PanelMain.Name = "PanelMain"
        Me.PanelMain.Padding = New System.Windows.Forms.Padding(2)
        Me.PanelMain.Size = New System.Drawing.Size(977, 700)
        Me.PanelMain.TabIndex = 12
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(2, 72)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.FG1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.SumFG1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.Fg2)
        Me.SplitContainer1.Panel2.Controls.Add(Me.SumFG2)
        Me.SplitContainer1.Size = New System.Drawing.Size(973, 626)
        Me.SplitContainer1.SplitterDistance = 313
        Me.SplitContainer1.TabIndex = 14
        '
        'SumFG1
        '
        Me.SumFG1.BackColor = System.Drawing.Color.Cornsilk
        Me.SumFG1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SumFG1.ColForSum.Add("BZ_Qty")
        Me.SumFG1.ColForSum.Add("BZ_ZL")
        Me.SumFG1.ColForSum.Add("SumAmount")
        Me.SumFG1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.SumFG1.FG = Me.FG1
        Me.SumFG1.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.SumFG1.ForeColor = System.Drawing.Color.Blue
        Me.SumFG1.Location = New System.Drawing.Point(0, 290)
        Me.SumFG1.Name = "SumFG1"
        Me.SumFG1.Size = New System.Drawing.Size(973, 23)
        Me.SumFG1.TabIndex = 12
        '
        'Fg2
        '
        Me.Fg2.AddCopyMenu = False
        Me.Fg2.AllowEditing = False
        Me.Fg2.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
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
        Me.Fg2.IsClickStartEdit = True
        Me.Fg2.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.Fg2.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.Fg2.Location = New System.Drawing.Point(0, 0)
        Me.Fg2.Name = "Fg2"
        Me.Fg2.NoShowMenu = False
        Me.Fg2.Rows.Count = 10
        Me.Fg2.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.Fg2.ShowButtons = C1.Win.C1FlexGrid.ShowButtonsEnum.Always
        Me.Fg2.Size = New System.Drawing.Size(973, 286)
        Me.Fg2.StartCol = ""
        Me.Fg2.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("Fg2.Styles"))
        Me.Fg2.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.BelowData
        Me.Fg2.TabIndex = 1
        '
        'SumFG2
        '
        Me.SumFG2.BackColor = System.Drawing.Color.Cornsilk
        Me.SumFG2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SumFG2.ColForSum.Add("Qty")
        Me.SumFG2.ColForSum.Add("Amount")
        Me.SumFG2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.SumFG2.FG = Me.Fg2
        Me.SumFG2.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.SumFG2.ForeColor = System.Drawing.Color.Blue
        Me.SumFG2.Location = New System.Drawing.Point(0, 286)
        Me.SumFG2.Name = "SumFG2"
        Me.SumFG2.Size = New System.Drawing.Size(973, 23)
        Me.SumFG2.TabIndex = 2
        '
        'Tool_Search
        '
        Me.Tool_Search.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSD_Date, Me.ToolStripLabel4, Me.DP_Start, Me.ToolStripLabel3, Me.DP_End, Me.CB_Condition3, Me.ToolStripLabel1, Me.CB_ConditionName1, Me.TB_ConditionValue1, Me.ToolStripLabel2, Me.CB_ConditionName2, Me.CB_ConditionValue2, Me.Btn_Search})
        Me.Tool_Search.Location = New System.Drawing.Point(2, 42)
        Me.Tool_Search.MinimumSize = New System.Drawing.Size(0, 30)
        Me.Tool_Search.Name = "Tool_Search"
        Me.Tool_Search.Size = New System.Drawing.Size(973, 30)
        Me.Tool_Search.TabIndex = 13
        Me.Tool_Search.Text = "ToolStrip1"
        '
        'TSD_Date
        '
        Me.TSD_Date.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.TSD_Date.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSM_sDate, Me.TSM_Audited_Date})
        Me.TSD_Date.ForeColor = System.Drawing.Color.Blue
        Me.TSD_Date.Image = CType(resources.GetObject("TSD_Date.Image"), System.Drawing.Image)
        Me.TSD_Date.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSD_Date.Name = "TSD_Date"
        Me.TSD_Date.Size = New System.Drawing.Size(69, 27)
        Me.TSD_Date.Tag = "sDate"
        Me.TSD_Date.Text = "开单日期"
        '
        'TSM_sDate
        '
        Me.TSM_sDate.Name = "TSM_sDate"
        Me.TSM_sDate.Size = New System.Drawing.Size(124, 22)
        Me.TSM_sDate.Text = "开单日期"
        '
        'TSM_Audited_Date
        '
        Me.TSM_Audited_Date.Name = "TSM_Audited_Date"
        Me.TSM_Audited_Date.Size = New System.Drawing.Size(124, 22)
        Me.TSM_Audited_Date.Text = "审核日期"
        '
        'ToolStripLabel4
        '
        Me.ToolStripLabel4.Name = "ToolStripLabel4"
        Me.ToolStripLabel4.Size = New System.Drawing.Size(20, 27)
        Me.ToolStripLabel4.Text = "从"
        '
        'DP_Start
        '
        Me.DP_Start.Name = "DP_Start"
        Me.DP_Start.Size = New System.Drawing.Size(100, 27)
        Me.DP_Start.Text = "2012-08-16"
        Me.DP_Start.Value = New Date(2012, 8, 16, 0, 0, 0, 0)
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.Margin = New System.Windows.Forms.Padding(1)
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(20, 28)
        Me.ToolStripLabel3.Text = "到"
        '
        'DP_End
        '
        Me.DP_End.Name = "DP_End"
        Me.DP_End.Size = New System.Drawing.Size(100, 27)
        Me.DP_End.Text = "2012-08-16"
        Me.DP_End.Value = New Date(2012, 8, 16, 0, 0, 0, 0)
        '
        'CB_Condition3
        '
        Me.CB_Condition3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_Condition3.Name = "CB_Condition3"
        Me.CB_Condition3.Size = New System.Drawing.Size(75, 30)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(51, 27)
        Me.ToolStripLabel1.Text = "条件1："
        '
        'CB_ConditionName1
        '
        Me.CB_ConditionName1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CB_ConditionName1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_ConditionName1.Name = "CB_ConditionName1"
        Me.CB_ConditionName1.Size = New System.Drawing.Size(85, 30)
        '
        'TB_ConditionValue1
        '
        Me.TB_ConditionValue1.Name = "TB_ConditionValue1"
        Me.TB_ConditionValue1.Size = New System.Drawing.Size(100, 30)
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(51, 27)
        Me.ToolStripLabel2.Text = "条件2："
        '
        'CB_ConditionName2
        '
        Me.CB_ConditionName2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_ConditionName2.Name = "CB_ConditionName2"
        Me.CB_ConditionName2.Size = New System.Drawing.Size(85, 30)
        '
        'CB_ConditionValue2
        '
        Me.CB_ConditionValue2.Name = "CB_ConditionValue2"
        Me.CB_ConditionValue2.Size = New System.Drawing.Size(120, 30)
        '
        'Btn_Search
        '
        Me.Btn_Search.Image = CType(resources.GetObject("Btn_Search.Image"), System.Drawing.Image)
        Me.Btn_Search.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.Btn_Search.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Btn_Search.Name = "Btn_Search"
        Me.Btn_Search.Size = New System.Drawing.Size(68, 27)
        Me.Btn_Search.Text = "搜索"
        '
        'F20320_DXLingLiao
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.PanelMain)
        Me.Name = "F20320_DXLingLiao"
        Me.Size = New System.Drawing.Size(977, 700)
        Me.Tool_Top.ResumeLayout(False)
        Me.Tool_Top.PerformLayout()
        CType(Me.FG1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CMS_FG1.ResumeLayout(False)
        Me.PanelMain.ResumeLayout(False)
        Me.PanelMain.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.Fg2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tool_Search.ResumeLayout(False)
        Me.Tool_Search.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Tool_Top As System.Windows.Forms.ToolStrip
    Friend WithEvents Cmd_Add As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_Modify As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_Del As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Cmd_Exit As System.Windows.Forms.ToolStripButton
    Friend WithEvents FG1 As PClass.FG
    Friend WithEvents PanelMain As System.Windows.Forms.Panel
    Friend WithEvents Cmd_Refresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents Tool_Search As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents CB_ConditionName1 As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents CB_ConditionName2 As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents CB_ConditionValue2 As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents Btn_Search As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripLabel3 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents TB_ConditionValue1 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents Cmd_Audit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel4 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Cmd_ShowList As System.Windows.Forms.ToolStripButton
    Friend WithEvents CB_Condition3 As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents CMS_FG1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents Cmd_ChooseAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Cmd_UnChooseAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Cmd_UnChoose As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Cmd_Preview2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_Preview As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_Print As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_Print2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents Fg2 As PClass.FG
    Friend WithEvents LB_ZL As System.Windows.Forms.ToolStripLabel
    Friend WithEvents LaB_ZL As System.Windows.Forms.ToolStripLabel
    Friend WithEvents LB_Qty As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabel6 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents LB_Amount As System.Windows.Forms.ToolStripLabel
    Friend WithEvents LabelZJE As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabel5 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents TSP_Autited As PClass.ToolStripDateTimePicker
    Friend WithEvents TSD_Date As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents DP_Start As PClass.ToolStripDateTimePicker
    Friend WithEvents DP_End As PClass.ToolStripDateTimePicker
    Friend WithEvents TSM_sDate As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSM_Audited_Date As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SumFG1 As BaseClass.SumFG
    Friend WithEvents SumFG2 As BaseClass.SumFG

End Class
