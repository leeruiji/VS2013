<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F27100_Process
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F27100_Process))
        Me.Tool_Top = New System.Windows.Forms.ToolStrip()
        Me.Cmd_Add = New System.Windows.Forms.ToolStripButton()
        Me.Cmd_Modify = New System.Windows.Forms.ToolStripButton()
        Me.Cmd_Del = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.Cmd_Eidt = New System.Windows.Forms.ToolStripButton()
        Me.Cmd_CancelEdit = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.Cmd_Refresh = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.Cmd_Preview = New System.Windows.Forms.ToolStripDropDownButton()
        Me.Cmd_PreView_All = New System.Windows.Forms.ToolStripMenuItem()
        Me.Cmd_Preview_JiaJi = New System.Windows.Forms.ToolStripMenuItem()
        Me.Cmd_Preview_Sel = New System.Windows.Forms.ToolStripMenuItem()
        Me.Cmd_Print = New System.Windows.Forms.ToolStripDropDownButton()
        Me.Cmd_Print_All = New System.Windows.Forms.ToolStripMenuItem()
        Me.Cmd_Print_JiaJi = New System.Windows.Forms.ToolStripMenuItem()
        Me.Cmd_Print_Sel = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.Cmd_JiaJi = New System.Windows.Forms.ToolStripButton()
        Me.Cmd_UnJiaJi = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.Cmd_FormInorOut = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.Cmd_Exit = New System.Windows.Forms.ToolStripButton()
        Me.FG1 = New PClass.FG()
        Me.CMS_FG1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Cmd_ChooseAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.Cmd_UnChooseAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.Cmd_UnChoose = New System.Windows.Forms.ToolStripMenuItem()
        Me.PanelMain = New System.Windows.Forms.Panel()
        Me.LB_Hide = New System.Windows.Forms.Label()
        Me.Tool_Search = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel4 = New System.Windows.Forms.ToolStripLabel()
        Me.DP_Start = New PClass.ToolStripDateTimePicker()
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel()
        Me.Dp_End = New PClass.ToolStripDateTimePicker()
        Me.CB_State = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.TSC_Client = New BaseClass.ToolStripComboList()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.TSC_BZ = New BaseClass.ToolStripComboList()
        Me.ToolStripLabel5 = New System.Windows.Forms.ToolStripLabel()
        Me.TSC_BZC = New BaseClass.ToolStripComboList()
        Me.LB_GH = New System.Windows.Forms.ToolStripLabel()
        Me.CB_ConditionName1 = New System.Windows.Forms.ToolStripComboBox()
        Me.TB_ConditionValue1 = New System.Windows.Forms.ToolStripTextBox()
        Me.Cmd_Search = New System.Windows.Forms.ToolStripButton()
        Me.LB_LuoSe_ZL = New System.Windows.Forms.ToolStripLabel()
        Me.LB_LB_ZL = New System.Windows.Forms.ToolStripLabel()
        Me.LB_Luose_Qty = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel6 = New System.Windows.Forms.ToolStripLabel()
        Me.Tool_Top.SuspendLayout()
        CType(Me.FG1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CMS_FG1.SuspendLayout()
        Me.PanelMain.SuspendLayout()
        Me.Tool_Search.SuspendLayout()
        Me.SuspendLayout()
        '
        'Tool_Top
        '
        Me.Tool_Top.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.Tool_Top.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Cmd_Add, Me.Cmd_Modify, Me.Cmd_Del, Me.ToolStripSeparator2, Me.Cmd_Eidt, Me.Cmd_CancelEdit, Me.ToolStripSeparator4, Me.Cmd_Refresh, Me.ToolStripSeparator3, Me.Cmd_Preview, Me.Cmd_Print, Me.ToolStripSeparator1, Me.Cmd_JiaJi, Me.Cmd_UnJiaJi, Me.ToolStripSeparator5, Me.Cmd_FormInorOut, Me.ToolStripSeparator6, Me.Cmd_Exit})
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
        Me.Cmd_Add.Image = Global.DN270_Business.My.Resources.Resources.ADD
        Me.Cmd_Add.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Add.Name = "Cmd_Add"
        Me.Cmd_Add.Size = New System.Drawing.Size(60, 37)
        Me.Cmd_Add.Text = "新增"
        '
        'Cmd_Modify
        '
        Me.Cmd_Modify.AccessibleDescription = "修改按钮"
        Me.Cmd_Modify.AccessibleName = ""
        Me.Cmd_Modify.Image = CType(resources.GetObject("Cmd_Modify.Image"), System.Drawing.Image)
        Me.Cmd_Modify.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Modify.Name = "Cmd_Modify"
        Me.Cmd_Modify.Size = New System.Drawing.Size(60, 37)
        Me.Cmd_Modify.Text = "修改"
        '
        'Cmd_Del
        '
        Me.Cmd_Del.AccessibleDescription = "修改按钮"
        Me.Cmd_Del.AccessibleName = ""
        Me.Cmd_Del.Image = Global.DN270_Business.My.Resources.Resources.Delete
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
        'Cmd_Eidt
        '
        Me.Cmd_Eidt.Image = Global.DN270_Business.My.Resources.Resources.paste
        Me.Cmd_Eidt.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Eidt.Name = "Cmd_Eidt"
        Me.Cmd_Eidt.Size = New System.Drawing.Size(108, 37)
        Me.Cmd_Eidt.Text = "进入编辑状态"
        Me.Cmd_Eidt.Visible = False
        '
        'Cmd_CancelEdit
        '
        Me.Cmd_CancelEdit.Image = Global.DN270_Business.My.Resources.Resources.cancel
        Me.Cmd_CancelEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_CancelEdit.Name = "Cmd_CancelEdit"
        Me.Cmd_CancelEdit.Size = New System.Drawing.Size(108, 37)
        Me.Cmd_CancelEdit.Text = "取消编辑状态"
        Me.Cmd_CancelEdit.Visible = False
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 40)
        '
        'Cmd_Refresh
        '
        Me.Cmd_Refresh.Image = Global.DN270_Business.My.Resources.Resources.ReFresh
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
        Me.Cmd_Preview.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Cmd_PreView_All, Me.Cmd_Preview_JiaJi, Me.Cmd_Preview_Sel})
        Me.Cmd_Preview.Image = CType(resources.GetObject("Cmd_Preview.Image"), System.Drawing.Image)
        Me.Cmd_Preview.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Preview.Name = "Cmd_Preview"
        Me.Cmd_Preview.Size = New System.Drawing.Size(69, 37)
        Me.Cmd_Preview.Text = "预览"
        '
        'Cmd_PreView_All
        '
        Me.Cmd_PreView_All.Name = "Cmd_PreView_All"
        Me.Cmd_PreView_All.Size = New System.Drawing.Size(148, 22)
        Me.Cmd_PreView_All.Text = "预览当前页面"
        '
        'Cmd_Preview_JiaJi
        '
        Me.Cmd_Preview_JiaJi.Name = "Cmd_Preview_JiaJi"
        Me.Cmd_Preview_JiaJi.Size = New System.Drawing.Size(148, 22)
        Me.Cmd_Preview_JiaJi.Text = "预览加急"
        '
        'Cmd_Preview_Sel
        '
        Me.Cmd_Preview_Sel.Name = "Cmd_Preview_Sel"
        Me.Cmd_Preview_Sel.Size = New System.Drawing.Size(148, 22)
        Me.Cmd_Preview_Sel.Text = "预览选择项"
        '
        'Cmd_Print
        '
        Me.Cmd_Print.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Cmd_Print_All, Me.Cmd_Print_JiaJi, Me.Cmd_Print_Sel})
        Me.Cmd_Print.Image = CType(resources.GetObject("Cmd_Print.Image"), System.Drawing.Image)
        Me.Cmd_Print.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Print.Name = "Cmd_Print"
        Me.Cmd_Print.Size = New System.Drawing.Size(69, 37)
        Me.Cmd_Print.Text = "打印"
        '
        'Cmd_Print_All
        '
        Me.Cmd_Print_All.Name = "Cmd_Print_All"
        Me.Cmd_Print_All.Size = New System.Drawing.Size(148, 22)
        Me.Cmd_Print_All.Text = "打印当前页面"
        '
        'Cmd_Print_JiaJi
        '
        Me.Cmd_Print_JiaJi.Name = "Cmd_Print_JiaJi"
        Me.Cmd_Print_JiaJi.Size = New System.Drawing.Size(148, 22)
        Me.Cmd_Print_JiaJi.Text = "打印加急"
        '
        'Cmd_Print_Sel
        '
        Me.Cmd_Print_Sel.Name = "Cmd_Print_Sel"
        Me.Cmd_Print_Sel.Size = New System.Drawing.Size(148, 22)
        Me.Cmd_Print_Sel.Text = "打印选择项"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 40)
        '
        'Cmd_JiaJi
        '
        Me.Cmd_JiaJi.Image = Global.DN270_Business.My.Resources.Resources.apply
        Me.Cmd_JiaJi.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_JiaJi.Name = "Cmd_JiaJi"
        Me.Cmd_JiaJi.Size = New System.Drawing.Size(60, 37)
        Me.Cmd_JiaJi.Text = "加急"
        Me.Cmd_JiaJi.Visible = False
        '
        'Cmd_UnJiaJi
        '
        Me.Cmd_UnJiaJi.Image = Global.DN270_Business.My.Resources.Resources.redo
        Me.Cmd_UnJiaJi.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_UnJiaJi.Name = "Cmd_UnJiaJi"
        Me.Cmd_UnJiaJi.Size = New System.Drawing.Size(84, 37)
        Me.Cmd_UnJiaJi.Text = "取消加急"
        Me.Cmd_UnJiaJi.Visible = False
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 40)
        '
        'Cmd_FormInorOut
        '
        Me.Cmd_FormInorOut.Image = Global.DN270_Business.My.Resources.Resources.cascate
        Me.Cmd_FormInorOut.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_FormInorOut.Name = "Cmd_FormInorOut"
        Me.Cmd_FormInorOut.Size = New System.Drawing.Size(60, 37)
        Me.Cmd_FormInorOut.Text = "窗口"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 40)
        '
        'Cmd_Exit
        '
        Me.Cmd_Exit.Image = CType(resources.GetObject("Cmd_Exit.Image"), System.Drawing.Image)
        Me.Cmd_Exit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(60, 37)
        Me.Cmd_Exit.Text = "关闭"
        '
        'FG1
        '
        Me.FG1.AddCopyMenu = False
        Me.FG1.AutoAddIndex = True
        Me.FG1.AutoGenerateColumns = False
        Me.FG1.AutoResize = False
        Me.FG1.BackColor = System.Drawing.Color.White
        Me.FG1.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.XpThemes
        Me.FG1.CanEditing = True
        Me.FG1.CheckKeyPressEdit = True
        Me.FG1.ColumnInfo = resources.GetString("FG1.ColumnInfo")
        Me.FG1.ContextMenuStrip = Me.CMS_FG1
        Me.FG1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FG1.EditFormat = True
        Me.FG1.ExtendLastCol = True
        Me.FG1.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.FG1.ForeColor = System.Drawing.Color.Black
        Me.FG1.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.FG1.IsAutoAddRow = True
        Me.FG1.IsClickStartEdit = False
        Me.FG1.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.FG1.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.FG1.Location = New System.Drawing.Point(2, 72)
        Me.FG1.Name = "FG1"
        Me.FG1.NoShowMenu = False
        Me.FG1.Rows.Count = 1
        Me.FG1.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.FG1.Size = New System.Drawing.Size(973, 626)
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
        Me.PanelMain.Controls.Add(Me.FG1)
        Me.PanelMain.Controls.Add(Me.LB_Hide)
        Me.PanelMain.Controls.Add(Me.Tool_Search)
        Me.PanelMain.Controls.Add(Me.Tool_Top)
        Me.PanelMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelMain.Location = New System.Drawing.Point(0, 0)
        Me.PanelMain.Name = "PanelMain"
        Me.PanelMain.Padding = New System.Windows.Forms.Padding(2)
        Me.PanelMain.Size = New System.Drawing.Size(977, 700)
        Me.PanelMain.TabIndex = 12
        '
        'LB_Hide
        '
        Me.LB_Hide.AutoSize = True
        Me.LB_Hide.Location = New System.Drawing.Point(0, 0)
        Me.LB_Hide.Name = "LB_Hide"
        Me.LB_Hide.Size = New System.Drawing.Size(0, 14)
        Me.LB_Hide.TabIndex = 61
        '
        'Tool_Search
        '
        Me.Tool_Search.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel4, Me.DP_Start, Me.ToolStripLabel3, Me.Dp_End, Me.CB_State, Me.ToolStripLabel2, Me.TSC_Client, Me.ToolStripLabel1, Me.TSC_BZ, Me.ToolStripLabel5, Me.TSC_BZC, Me.LB_GH, Me.CB_ConditionName1, Me.TB_ConditionValue1, Me.Cmd_Search, Me.LB_LuoSe_ZL, Me.LB_LB_ZL, Me.LB_Luose_Qty, Me.ToolStripLabel6})
        Me.Tool_Search.Location = New System.Drawing.Point(2, 42)
        Me.Tool_Search.MinimumSize = New System.Drawing.Size(0, 30)
        Me.Tool_Search.Name = "Tool_Search"
        Me.Tool_Search.Size = New System.Drawing.Size(973, 30)
        Me.Tool_Search.TabIndex = 13
        Me.Tool_Search.Text = "ToolStrip1"
        '
        'ToolStripLabel4
        '
        Me.ToolStripLabel4.Margin = New System.Windows.Forms.Padding(0, 1, 2, 2)
        Me.ToolStripLabel4.Name = "ToolStripLabel4"
        Me.ToolStripLabel4.Size = New System.Drawing.Size(20, 27)
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
        Me.ToolStripLabel3.Size = New System.Drawing.Size(20, 27)
        Me.ToolStripLabel3.Text = "到"
        '
        'Dp_End
        '
        Me.Dp_End.Name = "Dp_End"
        Me.Dp_End.Size = New System.Drawing.Size(100, 27)
        Me.Dp_End.Text = "2012-03-02"
        Me.Dp_End.Value = New Date(2012, 3, 2, 0, 0, 0, 0)
        '
        'CB_State
        '
        Me.CB_State.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_State.Name = "CB_State"
        Me.CB_State.Size = New System.Drawing.Size(75, 30)
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(44, 27)
        Me.ToolStripLabel2.Text = "客户："
        '
        'TSC_Client
        '
        Me.TSC_Client.Child = "ComboClient"
        Me.TSC_Client.IDAsInt = 0
        Me.TSC_Client.IDValue = "0"
        Me.TSC_Client.IsKeyDownAutoSearch = True
        Me.TSC_Client.Name = "TSC_Client"
        Me.TSC_Client.Size = New System.Drawing.Size(100, 27)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(35, 27)
        Me.ToolStripLabel1.Text = "布名:"
        '
        'TSC_BZ
        '
        Me.TSC_BZ.Child = "ComboBZ"
        Me.TSC_BZ.IDAsInt = 0
        Me.TSC_BZ.IDValue = "0"
        Me.TSC_BZ.IsKeyDownAutoSearch = True
        Me.TSC_BZ.Name = "TSC_BZ"
        Me.TSC_BZ.Size = New System.Drawing.Size(100, 27)
        '
        'ToolStripLabel5
        '
        Me.ToolStripLabel5.Name = "ToolStripLabel5"
        Me.ToolStripLabel5.Size = New System.Drawing.Size(35, 27)
        Me.ToolStripLabel5.Text = "色号:"
        '
        'TSC_BZC
        '
        Me.TSC_BZC.Child = "ComboBZC"
        Me.TSC_BZC.IDAsInt = 0
        Me.TSC_BZC.IDValue = "0"
        Me.TSC_BZC.IsKeyDownAutoSearch = True
        Me.TSC_BZC.Name = "TSC_BZC"
        Me.TSC_BZC.Size = New System.Drawing.Size(100, 27)
        '
        'LB_GH
        '
        Me.LB_GH.Name = "LB_GH"
        Me.LB_GH.Size = New System.Drawing.Size(42, 27)
        Me.LB_GH.Text = "条件1:"
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
        Me.TB_ConditionValue1.Size = New System.Drawing.Size(100, 23)
        '
        'Cmd_Search
        '
        Me.Cmd_Search.Image = CType(resources.GetObject("Cmd_Search.Image"), System.Drawing.Image)
        Me.Cmd_Search.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.Cmd_Search.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Search.Name = "Cmd_Search"
        Me.Cmd_Search.Size = New System.Drawing.Size(68, 36)
        Me.Cmd_Search.Text = "搜索"
        '
        'LB_LuoSe_ZL
        '
        Me.LB_LuoSe_ZL.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.LB_LuoSe_ZL.ForeColor = System.Drawing.Color.Blue
        Me.LB_LuoSe_ZL.Name = "LB_LuoSe_ZL"
        Me.LB_LuoSe_ZL.Size = New System.Drawing.Size(15, 17)
        Me.LB_LuoSe_ZL.Text = "0"
        '
        'LB_LB_ZL
        '
        Me.LB_LB_ZL.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.LB_LB_ZL.Name = "LB_LB_ZL"
        Me.LB_LB_ZL.Size = New System.Drawing.Size(68, 17)
        Me.LB_LB_ZL.Text = "落色重量："
        '
        'LB_Luose_Qty
        '
        Me.LB_Luose_Qty.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.LB_Luose_Qty.ForeColor = System.Drawing.Color.Blue
        Me.LB_Luose_Qty.Name = "LB_Luose_Qty"
        Me.LB_Luose_Qty.Size = New System.Drawing.Size(15, 17)
        Me.LB_Luose_Qty.Text = "0"
        '
        'ToolStripLabel6
        '
        Me.ToolStripLabel6.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel6.Name = "ToolStripLabel6"
        Me.ToolStripLabel6.Size = New System.Drawing.Size(68, 17)
        Me.ToolStripLabel6.Text = "落色条数："
        '
        'F27100_Process
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.PanelMain)
        Me.Name = "F27100_Process"
        Me.Size = New System.Drawing.Size(977, 700)
        Me.Tool_Top.ResumeLayout(False)
        Me.Tool_Top.PerformLayout()
        CType(Me.FG1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CMS_FG1.ResumeLayout(False)
        Me.PanelMain.ResumeLayout(False)
        Me.PanelMain.PerformLayout()
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
    Friend WithEvents Cmd_Search As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_JiaJi As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CB_State As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents CMS_FG1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents Cmd_ChooseAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Cmd_UnChooseAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Cmd_UnChoose As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LB_GH As System.Windows.Forms.ToolStripLabel
    Friend WithEvents LB_Hide As System.Windows.Forms.Label
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Cmd_UnJiaJi As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_Eidt As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_CancelEdit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel6 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents LB_LB_ZL As System.Windows.Forms.ToolStripLabel
    Friend WithEvents LB_LuoSe_ZL As System.Windows.Forms.ToolStripLabel
    Friend WithEvents LB_Luose_Qty As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Cmd_FormInorOut As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel4 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents DP_Start As PClass.ToolStripDateTimePicker
    Friend WithEvents ToolStripLabel3 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Dp_End As PClass.ToolStripDateTimePicker
    Friend WithEvents TSC_Client As BaseClass.ToolStripComboList
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents TSC_BZ As BaseClass.ToolStripComboList
    Friend WithEvents Cmd_Preview As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents Cmd_PreView_All As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Cmd_Preview_JiaJi As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Cmd_Preview_Sel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Cmd_Print As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents Cmd_Print_All As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Cmd_Print_JiaJi As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Cmd_Print_Sel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripLabel5 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents TSC_BZC As BaseClass.ToolStripComboList
    Friend WithEvents CB_ConditionName1 As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents TB_ConditionValue1 As System.Windows.Forms.ToolStripTextBox

End Class
