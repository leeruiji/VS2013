<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F40003_BZSH_ChangePrice
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F40003_BZSH_ChangePrice))
        Me.Tool_Top = New System.Windows.Forms.ToolStrip
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.Cmd_CanSort = New System.Windows.Forms.ToolStripButton
        Me.Btn_Auto_BZ = New System.Windows.Forms.ToolStripButton
        Me.Btn_Auto_JiaGongNeiRong = New System.Windows.Forms.ToolStripButton
        Me.Btn_Auto_BZC = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.Cmd_SetZhiTong = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.Cmd_ShowALL = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.Cmd_Bookmark = New System.Windows.Forms.ToolStripButton
        Me.Cmd_Exit = New System.Windows.Forms.ToolStripButton
        Me.LB_LuoSe_ZL = New System.Windows.Forms.ToolStripLabel
        Me.LB_LB_ZL = New System.Windows.Forms.ToolStripLabel
        Me.LB_Luose_Qty = New System.Windows.Forms.ToolStripLabel
        Me.ToolStripLabel6 = New System.Windows.Forms.ToolStripLabel
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Fg2 = New PClass.FG
        Me.Tool_Search = New System.Windows.Forms.ToolStrip
        Me.ToolStripLabel4 = New System.Windows.Forms.ToolStripLabel
        Me.DP_Start = New PClass.ToolStripDateTimePicker
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel
        Me.Dp_End = New PClass.ToolStripDateTimePicker
        Me.CB_Condition3 = New System.Windows.Forms.ToolStripComboBox
        Me.ToolStripLabel5 = New System.Windows.Forms.ToolStripLabel
        Me.TSC_Client = New BaseClass.ToolStripComboList
        Me.ToolStripLabel7 = New System.Windows.Forms.ToolStripLabel
        Me.TSC_BZ = New BaseClass.ToolStripComboList
        Me.ToolStripLabel9 = New System.Windows.Forms.ToolStripLabel
        Me.Tb_GH = New System.Windows.Forms.ToolStripTextBox
        Me.CKB_ZeroOnly = New System.Windows.Forms.ToolStripButton
        Me.Btn_Search = New System.Windows.Forms.ToolStripButton
        Me.SumFG1 = New BaseClass.SumFG
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripLabel8 = New System.Windows.Forms.ToolStripLabel
        Me.Label_Name = New System.Windows.Forms.ToolStripLabel
        Me.ToolStripLabel10 = New System.Windows.Forms.ToolStripLabel
        Me.Label_BZC_No = New System.Windows.Forms.ToolStripLabel
        Me.ToolStripLabel12 = New System.Windows.Forms.ToolStripLabel
        Me.Label_LastPrice = New System.Windows.Forms.ToolStripLabel
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel
        Me.Label_LastId = New System.Windows.Forms.ToolStripLabel
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel
        Me.Last_ComfirmPrice = New System.Windows.Forms.ToolStripLabel
        Me.GroupBox_ZhiTong = New System.Windows.Forms.GroupBox
        Me.Fg1 = New PClass.FG
        Me.RadioButton2 = New System.Windows.Forms.RadioButton
        Me.RadioButton1 = New System.Windows.Forms.RadioButton
        Me.Cmd_Cancel = New System.Windows.Forms.Button
        Me.Cmd_Ok = New System.Windows.Forms.Button
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.PanelMain = New System.Windows.Forms.Panel
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.GroupBox_P = New System.Windows.Forms.GroupBox
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.Tool_Top.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.Fg2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tool_Search.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox_ZhiTong.SuspendLayout()
        CType(Me.Fg1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelMain.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GroupBox_P.SuspendLayout()
        Me.SuspendLayout()
        '
        'Tool_Top
        '
        Me.Tool_Top.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.Tool_Top.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.Cmd_CanSort, Me.Btn_Auto_BZ, Me.Btn_Auto_JiaGongNeiRong, Me.Btn_Auto_BZC, Me.ToolStripSeparator1, Me.Cmd_SetZhiTong, Me.ToolStripSeparator3, Me.Cmd_ShowALL, Me.ToolStripSeparator4, Me.Cmd_Bookmark, Me.Cmd_Exit, Me.LB_LuoSe_ZL, Me.LB_LB_ZL, Me.LB_Luose_Qty, Me.ToolStripLabel6})
        Me.Tool_Top.Location = New System.Drawing.Point(2, 2)
        Me.Tool_Top.MinimumSize = New System.Drawing.Size(0, 40)
        Me.Tool_Top.Name = "Tool_Top"
        Me.Tool_Top.Size = New System.Drawing.Size(907, 40)
        Me.Tool_Top.TabIndex = 10
        Me.Tool_Top.Text = "ToolStrip2"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 40)
        '
        'Cmd_CanSort
        '
        Me.Cmd_CanSort.CheckOnClick = True
        Me.Cmd_CanSort.ForeColor = System.Drawing.Color.Blue
        Me.Cmd_CanSort.Image = Global.DN400_Store.My.Resources.Resources.file_temp
        Me.Cmd_CanSort.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_CanSort.Name = "Cmd_CanSort"
        Me.Cmd_CanSort.Size = New System.Drawing.Size(81, 37)
        Me.Cmd_CanSort.Text = "允许排序"
        '
        'Btn_Auto_BZ
        '
        Me.Btn_Auto_BZ.Checked = True
        Me.Btn_Auto_BZ.CheckOnClick = True
        Me.Btn_Auto_BZ.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Btn_Auto_BZ.ForeColor = System.Drawing.Color.Blue
        Me.Btn_Auto_BZ.Image = Global.DN400_Store.My.Resources.Resources._31
        Me.Btn_Auto_BZ.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Btn_Auto_BZ.Name = "Btn_Auto_BZ"
        Me.Btn_Auto_BZ.Size = New System.Drawing.Size(141, 37)
        Me.Btn_Auto_BZ.Text = "同色号自动设置单价"
        '
        'Btn_Auto_JiaGongNeiRong
        '
        Me.Btn_Auto_JiaGongNeiRong.Checked = True
        Me.Btn_Auto_JiaGongNeiRong.CheckOnClick = True
        Me.Btn_Auto_JiaGongNeiRong.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Btn_Auto_JiaGongNeiRong.ForeColor = System.Drawing.Color.Blue
        Me.Btn_Auto_JiaGongNeiRong.Image = Global.DN400_Store.My.Resources.Resources._75
        Me.Btn_Auto_JiaGongNeiRong.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Btn_Auto_JiaGongNeiRong.Name = "Btn_Auto_JiaGongNeiRong"
        Me.Btn_Auto_JiaGongNeiRong.Size = New System.Drawing.Size(165, 37)
        Me.Btn_Auto_JiaGongNeiRong.Text = "同加工内存自动设置单价"
        '
        'Btn_Auto_BZC
        '
        Me.Btn_Auto_BZC.Checked = True
        Me.Btn_Auto_BZC.CheckOnClick = True
        Me.Btn_Auto_BZC.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Btn_Auto_BZC.ForeColor = System.Drawing.Color.Blue
        Me.Btn_Auto_BZC.Image = Global.DN400_Store.My.Resources.Resources.Export
        Me.Btn_Auto_BZC.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Btn_Auto_BZC.Name = "Btn_Auto_BZC"
        Me.Btn_Auto_BZC.Size = New System.Drawing.Size(141, 37)
        Me.Btn_Auto_BZC.Text = "同布种自动设置单价"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 40)
        '
        'Cmd_SetZhiTong
        '
        Me.Cmd_SetZhiTong.Image = Global.DN400_Store.My.Resources.Resources.Modify
        Me.Cmd_SetZhiTong.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_SetZhiTong.Name = "Cmd_SetZhiTong"
        Me.Cmd_SetZhiTong.Size = New System.Drawing.Size(105, 37)
        Me.Cmd_SetZhiTong.Text = "设置纸筒单价"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 40)
        '
        'Cmd_ShowALL
        '
        Me.Cmd_ShowALL.Checked = True
        Me.Cmd_ShowALL.CheckOnClick = True
        Me.Cmd_ShowALL.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Cmd_ShowALL.Image = Global.DN400_Store.My.Resources.Resources.Word
        Me.Cmd_ShowALL.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_ShowALL.Name = "Cmd_ShowALL"
        Me.Cmd_ShowALL.Size = New System.Drawing.Size(81, 37)
        Me.Cmd_ShowALL.Text = "显示全部"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 40)
        '
        'Cmd_Bookmark
        '
        Me.Cmd_Bookmark.CheckOnClick = True
        Me.Cmd_Bookmark.Image = Global.DN400_Store.My.Resources.Resources.file_temp
        Me.Cmd_Bookmark.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Bookmark.Name = "Cmd_Bookmark"
        Me.Cmd_Bookmark.Size = New System.Drawing.Size(57, 37)
        Me.Cmd_Bookmark.Text = "书签"
        '
        'Cmd_Exit
        '
        Me.Cmd_Exit.Image = Global.DN400_Store.My.Resources.Resources.Close
        Me.Cmd_Exit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(57, 37)
        Me.Cmd_Exit.Text = "关闭"
        '
        'LB_LuoSe_ZL
        '
        Me.LB_LuoSe_ZL.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.LB_LuoSe_ZL.ForeColor = System.Drawing.Color.Blue
        Me.LB_LuoSe_ZL.Name = "LB_LuoSe_ZL"
        Me.LB_LuoSe_ZL.Size = New System.Drawing.Size(11, 37)
        Me.LB_LuoSe_ZL.Text = "0"
        '
        'LB_LB_ZL
        '
        Me.LB_LB_ZL.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.LB_LB_ZL.Name = "LB_LB_ZL"
        Me.LB_LB_ZL.Size = New System.Drawing.Size(65, 12)
        Me.LB_LB_ZL.Text = "成品重量："
        '
        'LB_Luose_Qty
        '
        Me.LB_Luose_Qty.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.LB_Luose_Qty.ForeColor = System.Drawing.Color.Blue
        Me.LB_Luose_Qty.Name = "LB_Luose_Qty"
        Me.LB_Luose_Qty.Size = New System.Drawing.Size(11, 12)
        Me.LB_Luose_Qty.Text = "0"
        '
        'ToolStripLabel6
        '
        Me.ToolStripLabel6.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel6.Name = "ToolStripLabel6"
        Me.ToolStripLabel6.Size = New System.Drawing.Size(41, 12)
        Me.ToolStripLabel6.Text = "条数："
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Fg2)
        Me.Panel1.Controls.Add(Me.Tool_Search)
        Me.Panel1.Controls.Add(Me.Tool_Top)
        Me.Panel1.Controls.Add(Me.SumFG1)
        Me.Panel1.Controls.Add(Me.ToolStrip1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(2)
        Me.Panel1.Size = New System.Drawing.Size(911, 700)
        Me.Panel1.TabIndex = 12
        '
        'Fg2
        '
        Me.Fg2.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.Fg2.AutoAddIndex = True
        Me.Fg2.AutoGenerateColumns = False
        Me.Fg2.AutoResize = False
        Me.Fg2.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.Fg2.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.XpThemes
        Me.Fg2.CanEditing = True
        Me.Fg2.ColumnInfo = resources.GetString("Fg2.ColumnInfo")
        Me.Fg2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Fg2.EditFormat = False
        Me.Fg2.ExtendLastCol = True
        Me.Fg2.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Fg2.ForeColor = System.Drawing.Color.Black
        Me.Fg2.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.Fg2.IsAutoAddRow = False
        Me.Fg2.IsClickStartEdit = True
        Me.Fg2.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.Fg2.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.Fg2.Location = New System.Drawing.Point(2, 72)
        Me.Fg2.Name = "Fg2"
        Me.Fg2.Rows.Count = 1
        Me.Fg2.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.Fg2.Size = New System.Drawing.Size(907, 573)
        Me.Fg2.StartCol = ""
        Me.Fg2.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("Fg2.Styles"))
        Me.Fg2.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.BelowData
        Me.Fg2.TabIndex = 1
        '
        'Tool_Search
        '
        Me.Tool_Search.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel4, Me.DP_Start, Me.ToolStripLabel3, Me.Dp_End, Me.CB_Condition3, Me.ToolStripLabel5, Me.TSC_Client, Me.ToolStripLabel7, Me.TSC_BZ, Me.ToolStripLabel9, Me.Tb_GH, Me.CKB_ZeroOnly, Me.Btn_Search})
        Me.Tool_Search.Location = New System.Drawing.Point(2, 42)
        Me.Tool_Search.MinimumSize = New System.Drawing.Size(0, 30)
        Me.Tool_Search.Name = "Tool_Search"
        Me.Tool_Search.Size = New System.Drawing.Size(907, 30)
        Me.Tool_Search.TabIndex = 13
        Me.Tool_Search.Text = "ToolStrip1"
        '
        'ToolStripLabel4
        '
        Me.ToolStripLabel4.Margin = New System.Windows.Forms.Padding(0, 1, 2, 2)
        Me.ToolStripLabel4.Name = "ToolStripLabel4"
        Me.ToolStripLabel4.Size = New System.Drawing.Size(17, 27)
        Me.ToolStripLabel4.Text = "从"
        '
        'DP_Start
        '
        Me.DP_Start.Name = "DP_Start"
        Me.DP_Start.Size = New System.Drawing.Size(100, 27)
        Me.DP_Start.Text = "2012-03-02"
        Me.DP_Start.Value = New Date(2012, 3, 2, 0, 0, 0, 0)
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.Margin = New System.Windows.Forms.Padding(0, 1, 2, 2)
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(17, 27)
        Me.ToolStripLabel3.Text = "到"
        '
        'Dp_End
        '
        Me.Dp_End.Name = "Dp_End"
        Me.Dp_End.Size = New System.Drawing.Size(100, 27)
        Me.Dp_End.Text = "2012-03-02"
        Me.Dp_End.Value = New Date(2012, 3, 2, 0, 0, 0, 0)
        '
        'CB_Condition3
        '
        Me.CB_Condition3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_Condition3.Name = "CB_Condition3"
        Me.CB_Condition3.Size = New System.Drawing.Size(75, 30)
        Me.CB_Condition3.Visible = False
        '
        'ToolStripLabel5
        '
        Me.ToolStripLabel5.Name = "ToolStripLabel5"
        Me.ToolStripLabel5.Size = New System.Drawing.Size(65, 27)
        Me.ToolStripLabel5.Text = "选择客户："
        '
        'TSC_Client
        '
        Me.TSC_Client.Child = "ComboClient"
        Me.TSC_Client.IDAsInt = 0
        Me.TSC_Client.IDValue = "0"
        Me.TSC_Client.IsKeyDownAutoSearch = True
        Me.TSC_Client.Name = "TSC_Client"
        Me.TSC_Client.SearchType = BaseClass.cSearchType.ENum_SearchType.ALL
        Me.TSC_Client.Size = New System.Drawing.Size(100, 27)
        '
        'ToolStripLabel7
        '
        Me.ToolStripLabel7.Name = "ToolStripLabel7"
        Me.ToolStripLabel7.Size = New System.Drawing.Size(41, 27)
        Me.ToolStripLabel7.Text = "布类："
        '
        'TSC_BZ
        '
        Me.TSC_BZ.Child = "ComboBZ"
        Me.TSC_BZ.IDAsInt = 0
        Me.TSC_BZ.IDValue = "0"
        Me.TSC_BZ.IsKeyDownAutoSearch = True
        Me.TSC_BZ.Name = "TSC_BZ"
        Me.TSC_BZ.SearchType = BaseClass.cSearchType.ENum_SearchType.ALL
        Me.TSC_BZ.Size = New System.Drawing.Size(160, 27)
        '
        'ToolStripLabel9
        '
        Me.ToolStripLabel9.Name = "ToolStripLabel9"
        Me.ToolStripLabel9.Size = New System.Drawing.Size(41, 27)
        Me.ToolStripLabel9.Text = "缸号："
        '
        'Tb_GH
        '
        Me.Tb_GH.Name = "Tb_GH"
        Me.Tb_GH.Size = New System.Drawing.Size(100, 30)
        '
        'CKB_ZeroOnly
        '
        Me.CKB_ZeroOnly.CheckOnClick = True
        Me.CKB_ZeroOnly.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.CKB_ZeroOnly.Image = CType(resources.GetObject("CKB_ZeroOnly.Image"), System.Drawing.Image)
        Me.CKB_ZeroOnly.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CKB_ZeroOnly.Name = "CKB_ZeroOnly"
        Me.CKB_ZeroOnly.Size = New System.Drawing.Size(99, 27)
        Me.CKB_ZeroOnly.Text = "只显示价格为0的"
        '
        'Btn_Search
        '
        Me.Btn_Search.Image = Global.DN400_Store.My.Resources.Resources.Search
        Me.Btn_Search.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.Btn_Search.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Btn_Search.Name = "Btn_Search"
        Me.Btn_Search.Size = New System.Drawing.Size(65, 36)
        Me.Btn_Search.Text = "搜索"
        '
        'SumFG1
        '
        Me.SumFG1.BackColor = System.Drawing.Color.Cornsilk
        Me.SumFG1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SumFG1.ColForSum.Add("Qty")
        Me.SumFG1.ColForSum.Add("PWeight")
        Me.SumFG1.ColForSum.Add("CWeight")
        Me.SumFG1.ColForSum.Add("Amount")
        Me.SumFG1.ColForSum.Add("Amount_JiaoDai")
        Me.SumFG1.ColForSum.Add("Amount_GH")
        Me.SumFG1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.SumFG1.FG = Me.Fg2
        Me.SumFG1.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.SumFG1.ForeColor = System.Drawing.Color.Blue
        Me.SumFG1.Location = New System.Drawing.Point(2, 645)
        Me.SumFG1.Name = "SumFG1"
        Me.SumFG1.Size = New System.Drawing.Size(907, 23)
        Me.SumFG1.TabIndex = 64
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel8, Me.Label_Name, Me.ToolStripLabel10, Me.Label_BZC_No, Me.ToolStripLabel12, Me.Label_LastPrice, Me.ToolStripLabel1, Me.Label_LastId, Me.ToolStripLabel2, Me.Last_ComfirmPrice})
        Me.ToolStrip1.Location = New System.Drawing.Point(2, 668)
        Me.ToolStrip1.MinimumSize = New System.Drawing.Size(0, 30)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(907, 30)
        Me.ToolStrip1.TabIndex = 63
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripLabel8
        '
        Me.ToolStripLabel8.Name = "ToolStripLabel8"
        Me.ToolStripLabel8.Size = New System.Drawing.Size(83, 27)
        Me.ToolStripLabel8.Text = "当前布种名称:"
        '
        'Label_Name
        '
        Me.Label_Name.ForeColor = System.Drawing.Color.Blue
        Me.Label_Name.Name = "Label_Name"
        Me.Label_Name.Size = New System.Drawing.Size(0, 27)
        '
        'ToolStripLabel10
        '
        Me.ToolStripLabel10.Margin = New System.Windows.Forms.Padding(30, 1, 0, 2)
        Me.ToolStripLabel10.Name = "ToolStripLabel10"
        Me.ToolStripLabel10.Size = New System.Drawing.Size(59, 27)
        Me.ToolStripLabel10.Text = "当前色号:"
        '
        'Label_BZC_No
        '
        Me.Label_BZC_No.ForeColor = System.Drawing.Color.Blue
        Me.Label_BZC_No.Name = "Label_BZC_No"
        Me.Label_BZC_No.Size = New System.Drawing.Size(0, 27)
        '
        'ToolStripLabel12
        '
        Me.ToolStripLabel12.Margin = New System.Windows.Forms.Padding(30, 1, 0, 2)
        Me.ToolStripLabel12.Name = "ToolStripLabel12"
        Me.ToolStripLabel12.Size = New System.Drawing.Size(83, 27)
        Me.ToolStripLabel12.Text = "上次加工单价:"
        '
        'Label_LastPrice
        '
        Me.Label_LastPrice.ForeColor = System.Drawing.Color.Blue
        Me.Label_LastPrice.Name = "Label_LastPrice"
        Me.Label_LastPrice.Size = New System.Drawing.Size(11, 27)
        Me.Label_LastPrice.Text = "0"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Margin = New System.Windows.Forms.Padding(30, 1, 0, 2)
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(89, 27)
        Me.ToolStripLabel1.Text = "上次确定单号："
        '
        'Label_LastId
        '
        Me.Label_LastId.DoubleClickEnabled = True
        Me.Label_LastId.ForeColor = System.Drawing.Color.Blue
        Me.Label_LastId.Name = "Label_LastId"
        Me.Label_LastId.Size = New System.Drawing.Size(0, 27)
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Margin = New System.Windows.Forms.Padding(30, 1, 0, 2)
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(83, 27)
        Me.ToolStripLabel2.Text = "上次确认单价:"
        '
        'Last_ComfirmPrice
        '
        Me.Last_ComfirmPrice.ForeColor = System.Drawing.Color.Blue
        Me.Last_ComfirmPrice.Name = "Last_ComfirmPrice"
        Me.Last_ComfirmPrice.Size = New System.Drawing.Size(11, 27)
        Me.Last_ComfirmPrice.Text = "0"
        '
        'GroupBox_ZhiTong
        '
        Me.GroupBox_ZhiTong.Controls.Add(Me.Fg1)
        Me.GroupBox_ZhiTong.Controls.Add(Me.RadioButton2)
        Me.GroupBox_ZhiTong.Controls.Add(Me.RadioButton1)
        Me.GroupBox_ZhiTong.Controls.Add(Me.Cmd_Cancel)
        Me.GroupBox_ZhiTong.Controls.Add(Me.Cmd_Ok)
        Me.GroupBox_ZhiTong.Location = New System.Drawing.Point(28, 30)
        Me.GroupBox_ZhiTong.Name = "GroupBox_ZhiTong"
        Me.GroupBox_ZhiTong.Size = New System.Drawing.Size(440, 352)
        Me.GroupBox_ZhiTong.TabIndex = 65
        Me.GroupBox_ZhiTong.TabStop = False
        Me.GroupBox_ZhiTong.Text = "纸筒单价批量设置"
        Me.GroupBox_ZhiTong.Visible = False
        '
        'Fg1
        '
        Me.Fg1.AutoAddIndex = True
        Me.Fg1.AutoGenerateColumns = False
        Me.Fg1.AutoResize = False
        Me.Fg1.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.Fg1.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.XpThemes
        Me.Fg1.CanEditing = True
        Me.Fg1.ColumnInfo = resources.GetString("Fg1.ColumnInfo")
        Me.Fg1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Fg1.EditFormat = True
        Me.Fg1.ExtendLastCol = True
        Me.Fg1.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Fg1.ForeColor = System.Drawing.Color.Black
        Me.Fg1.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.Fg1.IsAutoAddRow = True
        Me.Fg1.IsClickStartEdit = False
        Me.Fg1.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.Fg1.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveDown
        Me.Fg1.Location = New System.Drawing.Point(3, 19)
        Me.Fg1.Name = "Fg1"
        Me.Fg1.Rows.Count = 10
        Me.Fg1.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.Fg1.Size = New System.Drawing.Size(434, 249)
        Me.Fg1.StartCol = ""
        Me.Fg1.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("Fg1.Styles"))
        Me.Fg1.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.BelowData
        Me.Fg1.TabIndex = 64
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Checked = True
        Me.RadioButton2.Location = New System.Drawing.Point(21, 313)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(130, 18)
        Me.RadioButton2.TabIndex = 68
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "只设置单价为0的"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(21, 283)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(123, 18)
        Me.RadioButton1.TabIndex = 67
        Me.RadioButton1.Text = "全部应该该设置"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'Cmd_Cancel
        '
        Me.Cmd_Cancel.Location = New System.Drawing.Point(311, 289)
        Me.Cmd_Cancel.Name = "Cmd_Cancel"
        Me.Cmd_Cancel.Size = New System.Drawing.Size(103, 42)
        Me.Cmd_Cancel.TabIndex = 66
        Me.Cmd_Cancel.Text = "取消"
        Me.Cmd_Cancel.UseVisualStyleBackColor = True
        '
        'Cmd_Ok
        '
        Me.Cmd_Ok.Location = New System.Drawing.Point(185, 289)
        Me.Cmd_Ok.Name = "Cmd_Ok"
        Me.Cmd_Ok.Size = New System.Drawing.Size(103, 42)
        Me.Cmd_Ok.TabIndex = 65
        Me.Cmd_Ok.Text = "应用"
        Me.Cmd_Ok.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        Me.Timer1.Interval = 1
        '
        'PanelMain
        '
        Me.PanelMain.Controls.Add(Me.Panel1)
        Me.PanelMain.Controls.Add(Me.Panel2)
        Me.PanelMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelMain.Location = New System.Drawing.Point(0, 0)
        Me.PanelMain.Name = "PanelMain"
        Me.PanelMain.Size = New System.Drawing.Size(911, 700)
        Me.PanelMain.TabIndex = 66
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.GroupBox_P)
        Me.Panel2.Controls.Add(Me.GroupBox_ZhiTong)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(911, 700)
        Me.Panel2.TabIndex = 64
        Me.Panel2.Visible = False
        '
        'GroupBox_P
        '
        Me.GroupBox_P.Controls.Add(Me.ProgressBar1)
        Me.GroupBox_P.Location = New System.Drawing.Point(248, 530)
        Me.GroupBox_P.Name = "GroupBox_P"
        Me.GroupBox_P.Size = New System.Drawing.Size(372, 81)
        Me.GroupBox_P.TabIndex = 67
        Me.GroupBox_P.TabStop = False
        Me.GroupBox_P.Text = "更新中"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(35, 33)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(299, 30)
        Me.ProgressBar1.TabIndex = 66
        '
        'F40003_BZSH_ChangePrice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.CanMaxSize = True
        Me.Controls.Add(Me.PanelMain)
        Me.Name = "F40003_BZSH_ChangePrice"
        Me.Size = New System.Drawing.Size(911, 700)
        Me.Tool_Top.ResumeLayout(False)
        Me.Tool_Top.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.Fg2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tool_Search.ResumeLayout(False)
        Me.Tool_Search.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox_ZhiTong.ResumeLayout(False)
        Me.GroupBox_ZhiTong.PerformLayout()
        CType(Me.Fg1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelMain.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.GroupBox_P.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Tool_Top As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Cmd_Exit As System.Windows.Forms.ToolStripButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Btn_Auto_BZ As System.Windows.Forms.ToolStripButton
    Friend WithEvents Tool_Search As System.Windows.Forms.ToolStrip
    Friend WithEvents Btn_Search As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripLabel3 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabel4 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabel5 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabel6 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents LB_Luose_Qty As System.Windows.Forms.ToolStripLabel
    Friend WithEvents LB_LB_ZL As System.Windows.Forms.ToolStripLabel
    Friend WithEvents LB_LuoSe_ZL As System.Windows.Forms.ToolStripLabel
    Friend WithEvents CB_Condition3 As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents Fg2 As PClass.FG
    Friend WithEvents ToolStripLabel7 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Btn_Auto_BZC As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel8 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Label_Name As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabel10 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Label_BZC_No As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabel12 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Label_LastPrice As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents CKB_ZeroOnly As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBox_ZhiTong As System.Windows.Forms.GroupBox
    Friend WithEvents Fg1 As PClass.FG
    Friend WithEvents Cmd_Cancel As System.Windows.Forms.Button
    Friend WithEvents Cmd_Ok As System.Windows.Forms.Button
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Cmd_SetZhiTong As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PanelMain As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox_P As System.Windows.Forms.GroupBox
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents TSC_Client As BaseClass.ToolStripComboList
    Friend WithEvents TSC_BZ As BaseClass.ToolStripComboList
    Friend WithEvents DP_Start As PClass.ToolStripDateTimePicker
    Friend WithEvents Dp_End As PClass.ToolStripDateTimePicker
    Friend WithEvents Cmd_CanSort As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Label_LastId As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Last_ComfirmPrice As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Cmd_ShowALL As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Cmd_Bookmark As System.Windows.Forms.ToolStripButton

    Friend WithEvents SumFG1 As BaseClass.SumFG

    Friend WithEvents ToolStripLabel9 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Tb_GH As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents Btn_Auto_JiaGongNeiRong As System.Windows.Forms.ToolStripButton


End Class
