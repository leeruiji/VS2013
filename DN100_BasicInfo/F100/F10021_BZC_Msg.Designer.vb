<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F10021_BZC_Msg
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F10021_BZC_Msg))
        Me.Tool_Top = New System.Windows.Forms.ToolStrip()
        Me.Cmd_Modify = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.Btn_AddRow = New System.Windows.Forms.ToolStripButton()
        Me.Btn_RemoveRow = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton_CopyVi_RL = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.Cmd_Exit = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.PanelMain = New System.Windows.Forms.Panel()
        Me.CB_BZ_FG = New BaseClass.ComBoList()
        Me.CB_Client = New BaseClass.ComBoList()
        Me.CB_BZ = New BaseClass.ComBoList()
        Me.CB_RanSe = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Fg2 = New PClass.FG()
        Me.Fg3 = New PClass.FG()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.Cmd_PF_Add = New System.Windows.Forms.ToolStripButton()
        Me.Cmd_PF_Remove = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.Cmd_CopyPF = New System.Windows.Forms.ToolStripButton()
        Me.Cmd_ClientChoose = New System.Windows.Forms.ToolStripButton()
        Me.Label_Client_Name = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TB_Client_Bzc = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TB_BZ_Name = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.DP_Found_Date = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TB_Qian_ChuLi = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Fg1 = New PClass.FG()
        Me.TB_BZC_No = New System.Windows.Forms.TextBox()
        Me.Label_ID = New System.Windows.Forms.Label()
        Me.TB_Remark = New System.Windows.Forms.TextBox()
        Me.TB_Name = New System.Windows.Forms.TextBox()
        Me.TB_SupplierName = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.LB_FullName = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.DP_UPD_DATE = New System.Windows.Forms.DateTimePicker()
        Me.TB_UPD_USER = New System.Windows.Forms.TextBox()
        Me.Tool_Top.SuspendLayout()
        Me.PanelMain.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.Fg2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Fg3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.Fg1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Tool_Top
        '
        Me.Tool_Top.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.Tool_Top.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Cmd_Modify, Me.ToolStripSeparator2, Me.Btn_AddRow, Me.Btn_RemoveRow, Me.ToolStripSeparator1, Me.ToolStripButton_CopyVi_RL, Me.ToolStripSeparator7, Me.Cmd_Exit, Me.ToolStripLabel1, Me.ToolStripLabel2})
        Me.Tool_Top.Location = New System.Drawing.Point(0, 0)
        Me.Tool_Top.MinimumSize = New System.Drawing.Size(0, 35)
        Me.Tool_Top.Name = "Tool_Top"
        Me.Tool_Top.Size = New System.Drawing.Size(1100, 35)
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
        Me.Cmd_Modify.Size = New System.Drawing.Size(60, 32)
        Me.Cmd_Modify.Text = "保存"
        Me.Cmd_Modify.Visible = False
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 35)
        '
        'Btn_AddRow
        '
        Me.Btn_AddRow.Image = Global.DN100_BasicInfo.My.Resources.Resources.AddRow
        Me.Btn_AddRow.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Btn_AddRow.Name = "Btn_AddRow"
        Me.Btn_AddRow.Size = New System.Drawing.Size(84, 32)
        Me.Btn_AddRow.Text = "增加布种"
        Me.Btn_AddRow.Visible = False
        '
        'Btn_RemoveRow
        '
        Me.Btn_RemoveRow.Image = Global.DN100_BasicInfo.My.Resources.Resources.RemoveRow
        Me.Btn_RemoveRow.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Btn_RemoveRow.Name = "Btn_RemoveRow"
        Me.Btn_RemoveRow.Size = New System.Drawing.Size(84, 32)
        Me.Btn_RemoveRow.Text = "删除布种"
        Me.Btn_RemoveRow.Visible = False
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 35)
        '
        'ToolStripButton_CopyVi_RL
        '
        Me.ToolStripButton_CopyVi_RL.Image = Global.DN100_BasicInfo.My.Resources.Resources.Paste
        Me.ToolStripButton_CopyVi_RL.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_CopyVi_RL.Name = "ToolStripButton_CopyVi_RL"
        Me.ToolStripButton_CopyVi_RL.Size = New System.Drawing.Size(60, 32)
        Me.ToolStripButton_CopyVi_RL.Text = "复制"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 35)
        '
        'Cmd_Exit
        '
        Me.Cmd_Exit.Image = Global.DN100_BasicInfo.My.Resources.Resources.Close
        Me.Cmd_Exit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(60, 32)
        Me.Cmd_Exit.Text = "关闭"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel1.AutoSize = False
        Me.ToolStripLabel1.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(225, 37)
        Me.ToolStripLabel1.Text = "最后修改日期:"
        Me.ToolStripLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel2.AutoSize = False
        Me.ToolStripLabel2.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(200, 37)
        Me.ToolStripLabel2.Text = "最后修改人:"
        Me.ToolStripLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PanelMain
        '
        Me.PanelMain.Controls.Add(Me.CB_BZ_FG)
        Me.PanelMain.Controls.Add(Me.CB_Client)
        Me.PanelMain.Controls.Add(Me.CB_BZ)
        Me.PanelMain.Controls.Add(Me.CB_RanSe)
        Me.PanelMain.Controls.Add(Me.Label1)
        Me.PanelMain.Controls.Add(Me.GroupBox2)
        Me.PanelMain.Controls.Add(Me.Label_Client_Name)
        Me.PanelMain.Controls.Add(Me.Label8)
        Me.PanelMain.Controls.Add(Me.Label7)
        Me.PanelMain.Controls.Add(Me.TB_Client_Bzc)
        Me.PanelMain.Controls.Add(Me.Label6)
        Me.PanelMain.Controls.Add(Me.TB_BZ_Name)
        Me.PanelMain.Controls.Add(Me.Label5)
        Me.PanelMain.Controls.Add(Me.Label4)
        Me.PanelMain.Controls.Add(Me.DP_Found_Date)
        Me.PanelMain.Controls.Add(Me.Label3)
        Me.PanelMain.Controls.Add(Me.TB_Qian_ChuLi)
        Me.PanelMain.Controls.Add(Me.Label2)
        Me.PanelMain.Controls.Add(Me.GroupBox1)
        Me.PanelMain.Controls.Add(Me.TB_BZC_No)
        Me.PanelMain.Controls.Add(Me.Label_ID)
        Me.PanelMain.Controls.Add(Me.TB_Remark)
        Me.PanelMain.Controls.Add(Me.TB_Name)
        Me.PanelMain.Controls.Add(Me.TB_SupplierName)
        Me.PanelMain.Controls.Add(Me.Label19)
        Me.PanelMain.Controls.Add(Me.LB_FullName)
        Me.PanelMain.Controls.Add(Me.Label15)
        Me.PanelMain.Controls.Add(Me.Label9)
        Me.PanelMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelMain.Location = New System.Drawing.Point(0, 35)
        Me.PanelMain.Name = "PanelMain"
        Me.PanelMain.Padding = New System.Windows.Forms.Padding(2)
        Me.PanelMain.Size = New System.Drawing.Size(1100, 665)
        Me.PanelMain.TabIndex = 0
        '
        'CB_BZ_FG
        '
        Me.CB_BZ_FG.Child = "ComboBZ"
        Me.CB_BZ_FG.FormattingEnabled = True
        Me.CB_BZ_FG.IDAsInt = CType(0, Long)
        Me.CB_BZ_FG.IDValue = ""
        Me.CB_BZ_FG.IsKeyDownAutoSearch = True
        Me.CB_BZ_FG.IsSelectName = False
        Me.CB_BZ_FG.IsTBLostFocusSelOne = True
        Me.CB_BZ_FG.Location = New System.Drawing.Point(726, -7)
        Me.CB_BZ_FG.Name = "CB_BZ_FG"
        Me.CB_BZ_FG.Size = New System.Drawing.Size(107, 22)
        Me.CB_BZ_FG.TabIndex = 4
        Me.CB_BZ_FG.Visible = False
        '
        'CB_Client
        '
        Me.CB_Client.Child = "ComboClient"
        Me.CB_Client.FormattingEnabled = True
        Me.CB_Client.IDAsInt = CType(0, Long)
        Me.CB_Client.IDValue = ""
        Me.CB_Client.IsKeyDownAutoSearch = True
        Me.CB_Client.IsSelectName = False
        Me.CB_Client.IsTBLostFocusSelOne = True
        Me.CB_Client.Location = New System.Drawing.Point(129, 81)
        Me.CB_Client.Name = "CB_Client"
        Me.CB_Client.Size = New System.Drawing.Size(107, 22)
        Me.CB_Client.TabIndex = 2
        '
        'CB_BZ
        '
        Me.CB_BZ.Child = "ComboBZ"
        Me.CB_BZ.FormattingEnabled = True
        Me.CB_BZ.IDAsInt = CType(0, Long)
        Me.CB_BZ.IDValue = ""
        Me.CB_BZ.IsKeyDownAutoSearch = True
        Me.CB_BZ.IsSelectName = False
        Me.CB_BZ.IsTBLostFocusSelOne = True
        Me.CB_BZ.Location = New System.Drawing.Point(478, 21)
        Me.CB_BZ.Name = "CB_BZ"
        Me.CB_BZ.Size = New System.Drawing.Size(107, 22)
        Me.CB_BZ.TabIndex = 3
        '
        'CB_RanSe
        '
        Me.CB_RanSe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_RanSe.FormattingEnabled = True
        Me.CB_RanSe.Items.AddRange(New Object() {"单染", "套活性", "套非活", "C", "R", "T", "TC", "TR", "A", "N", "TA", "ART", "AR", "AN", "AW"})
        Me.CB_RanSe.Location = New System.Drawing.Point(129, 138)
        Me.CB_RanSe.Name = "CB_RanSe"
        Me.CB_RanSe.Size = New System.Drawing.Size(121, 22)
        Me.CB_RanSe.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(53, 141)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 14)
        Me.Label1.TabIndex = 36
        Me.Label1.Text = "染色方法:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.SplitContainer1)
        Me.GroupBox2.Controls.Add(Me.ToolStrip1)
        Me.GroupBox2.Location = New System.Drawing.Point(5, 212)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1090, 446)
        Me.GroupBox2.TabIndex = 9
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "配色方案"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(3, 54)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.Fg2)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.Fg3)
        Me.SplitContainer1.Size = New System.Drawing.Size(1084, 389)
        Me.SplitContainer1.SplitterDistance = 536
        Me.SplitContainer1.TabIndex = 12
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
        Me.Fg2.Location = New System.Drawing.Point(0, 0)
        Me.Fg2.Name = "Fg2"
        Me.Fg2.NoShowMenu = False
        Me.Fg2.Rows.Count = 10
        Me.Fg2.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.Fg2.Size = New System.Drawing.Size(536, 389)
        Me.Fg2.StartCol = ""
        Me.Fg2.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("Fg2.Styles"))
        Me.Fg2.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.BelowData
        Me.Fg2.TabIndex = 0
        '
        'Fg3
        '
        Me.Fg3.AddCopyMenu = False
        Me.Fg3.AutoAddIndex = True
        Me.Fg3.AutoGenerateColumns = False
        Me.Fg3.AutoResize = False
        Me.Fg3.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.Fg3.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.XpThemes
        Me.Fg3.CanEditing = False
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
        Me.Fg3.Location = New System.Drawing.Point(0, 0)
        Me.Fg3.Name = "Fg3"
        Me.Fg3.NoShowMenu = False
        Me.Fg3.Rows.Count = 10
        Me.Fg3.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.Fg3.Size = New System.Drawing.Size(544, 389)
        Me.Fg3.StartCol = ""
        Me.Fg3.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("Fg3.Styles"))
        Me.Fg3.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.BelowData
        Me.Fg3.TabIndex = 0
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator3, Me.Cmd_PF_Add, Me.Cmd_PF_Remove, Me.ToolStripSeparator5, Me.Cmd_CopyPF, Me.Cmd_ClientChoose})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 19)
        Me.ToolStrip1.MinimumSize = New System.Drawing.Size(0, 35)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1084, 35)
        Me.ToolStrip1.TabIndex = 11
        Me.ToolStrip1.Text = "ToolStrip2"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 35)
        '
        'Cmd_PF_Add
        '
        Me.Cmd_PF_Add.Image = Global.DN100_BasicInfo.My.Resources.Resources.AddRow
        Me.Cmd_PF_Add.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_PF_Add.Name = "Cmd_PF_Add"
        Me.Cmd_PF_Add.Size = New System.Drawing.Size(84, 32)
        Me.Cmd_PF_Add.Text = "增加色板"
        '
        'Cmd_PF_Remove
        '
        Me.Cmd_PF_Remove.Image = Global.DN100_BasicInfo.My.Resources.Resources.RemoveRow
        Me.Cmd_PF_Remove.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_PF_Remove.Name = "Cmd_PF_Remove"
        Me.Cmd_PF_Remove.Size = New System.Drawing.Size(84, 32)
        Me.Cmd_PF_Remove.Text = "删除色板"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 35)
        '
        'Cmd_CopyPF
        '
        Me.Cmd_CopyPF.Image = Global.DN100_BasicInfo.My.Resources.Resources.Paste
        Me.Cmd_CopyPF.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_CopyPF.Name = "Cmd_CopyPF"
        Me.Cmd_CopyPF.Size = New System.Drawing.Size(84, 32)
        Me.Cmd_CopyPF.Text = "复制色板"
        '
        'Cmd_ClientChoose
        '
        Me.Cmd_ClientChoose.Image = Global.DN100_BasicInfo.My.Resources.Resources.Client
        Me.Cmd_ClientChoose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_ClientChoose.Name = "Cmd_ClientChoose"
        Me.Cmd_ClientChoose.Size = New System.Drawing.Size(84, 32)
        Me.Cmd_ClientChoose.Text = "客户选择"
        '
        'Label_Client_Name
        '
        Me.Label_Client_Name.AutoSize = True
        Me.Label_Client_Name.Location = New System.Drawing.Point(241, 84)
        Me.Label_Client_Name.Name = "Label_Client_Name"
        Me.Label_Client_Name.Size = New System.Drawing.Size(70, 14)
        Me.Label_Client_Name.TabIndex = 35
        Me.Label_Client_Name.Text = "客户名称:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(53, 84)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(70, 14)
        Me.Label8.TabIndex = 34
        Me.Label8.Text = "客户编号:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.Blue
        Me.Label7.Location = New System.Drawing.Point(989, 24)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(14, 14)
        Me.Label7.TabIndex = 30
        Me.Label7.Text = "#"
        '
        'TB_Client_Bzc
        '
        Me.TB_Client_Bzc.Location = New System.Drawing.Point(901, 22)
        Me.TB_Client_Bzc.Name = "TB_Client_Bzc"
        Me.TB_Client_Bzc.Size = New System.Drawing.Size(82, 23)
        Me.TB_Client_Bzc.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(825, 25)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(70, 14)
        Me.Label6.TabIndex = 29
        Me.Label6.Text = "布行色号:"
        '
        'TB_BZ_Name
        '
        Me.TB_BZ_Name.Location = New System.Drawing.Point(667, 21)
        Me.TB_BZ_Name.Name = "TB_BZ_Name"
        Me.TB_BZ_Name.ReadOnly = True
        Me.TB_BZ_Name.Size = New System.Drawing.Size(150, 23)
        Me.TB_BZ_Name.TabIndex = 26
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(591, 25)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 14)
        Me.Label5.TabIndex = 27
        Me.Label5.Text = "布种名称:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(402, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 14)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "布种编号:"
        '
        'DP_Found_Date
        '
        Me.DP_Found_Date.CustomFormat = "yyyy-MM-dd"
        Me.DP_Found_Date.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DP_Found_Date.Location = New System.Drawing.Point(130, 110)
        Me.DP_Found_Date.Name = "DP_Found_Date"
        Me.DP_Found_Date.Size = New System.Drawing.Size(255, 23)
        Me.DP_Found_Date.TabIndex = 5
        Me.DP_Found_Date.Value = New Date(2011, 4, 2, 10, 51, 0, 0)
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(81, 114)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 14)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "日期:"
        '
        'TB_Qian_ChuLi
        '
        Me.TB_Qian_ChuLi.Location = New System.Drawing.Point(466, -8)
        Me.TB_Qian_ChuLi.Name = "TB_Qian_ChuLi"
        Me.TB_Qian_ChuLi.Size = New System.Drawing.Size(254, 23)
        Me.TB_Qian_ChuLi.TabIndex = 3
        Me.TB_Qian_ChuLi.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(404, -5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 14)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "前处理:"
        Me.Label2.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Fg1)
        Me.GroupBox1.Location = New System.Drawing.Point(405, 58)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(603, 149)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "可染布种"
        Me.GroupBox1.Visible = False
        '
        'Fg1
        '
        Me.Fg1.AddCopyMenu = False
        Me.Fg1.AllowEditing = False
        Me.Fg1.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
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
        Me.Fg1.Rows.Count = 10
        Me.Fg1.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.Fg1.Size = New System.Drawing.Size(597, 127)
        Me.Fg1.StartCol = ""
        Me.Fg1.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("Fg1.Styles"))
        Me.Fg1.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.BelowData
        Me.Fg1.TabIndex = 0
        '
        'TB_BZC_No
        '
        Me.TB_BZC_No.Location = New System.Drawing.Point(157, 21)
        Me.TB_BZC_No.Name = "TB_BZC_No"
        Me.TB_BZC_No.Size = New System.Drawing.Size(228, 23)
        Me.TB_BZC_No.TabIndex = 0
        '
        'Label_ID
        '
        Me.Label_ID.AutoSize = True
        Me.Label_ID.ForeColor = System.Drawing.Color.Blue
        Me.Label_ID.Location = New System.Drawing.Point(129, 25)
        Me.Label_ID.Name = "Label_ID"
        Me.Label_ID.Size = New System.Drawing.Size(28, 14)
        Me.Label_ID.TabIndex = 15
        Me.Label_ID.Text = "GY-"
        '
        'TB_Remark
        '
        Me.TB_Remark.Location = New System.Drawing.Point(129, 167)
        Me.TB_Remark.Multiline = True
        Me.TB_Remark.Name = "TB_Remark"
        Me.TB_Remark.Size = New System.Drawing.Size(255, 43)
        Me.TB_Remark.TabIndex = 7
        '
        'TB_Name
        '
        Me.TB_Name.Location = New System.Drawing.Point(129, 51)
        Me.TB_Name.Name = "TB_Name"
        Me.TB_Name.Size = New System.Drawing.Size(254, 23)
        Me.TB_Name.TabIndex = 1
        '
        'TB_SupplierName
        '
        Me.TB_SupplierName.AutoSize = True
        Me.TB_SupplierName.Location = New System.Drawing.Point(53, 25)
        Me.TB_SupplierName.Name = "TB_SupplierName"
        Me.TB_SupplierName.Size = New System.Drawing.Size(70, 14)
        Me.TB_SupplierName.TabIndex = 7
        Me.TB_SupplierName.Text = "色号编号:"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(81, 170)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(42, 14)
        Me.Label19.TabIndex = 6
        Me.Label19.Text = "备注:"
        '
        'LB_FullName
        '
        Me.LB_FullName.AutoSize = True
        Me.LB_FullName.Location = New System.Drawing.Point(53, 54)
        Me.LB_FullName.Name = "LB_FullName"
        Me.LB_FullName.Size = New System.Drawing.Size(70, 14)
        Me.LB_FullName.TabIndex = 5
        Me.LB_FullName.Text = "色号名称:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(212, 302)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(0, 14)
        Me.Label15.TabIndex = 9
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(212, 301)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(0, 14)
        Me.Label9.TabIndex = 9
        '
        'DP_UPD_DATE
        '
        Me.DP_UPD_DATE.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DP_UPD_DATE.CustomFormat = "yyyy年MM月dd日"
        Me.DP_UPD_DATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DP_UPD_DATE.Location = New System.Drawing.Point(969, 6)
        Me.DP_UPD_DATE.Name = "DP_UPD_DATE"
        Me.DP_UPD_DATE.Size = New System.Drawing.Size(126, 23)
        Me.DP_UPD_DATE.TabIndex = 6
        '
        'TB_UPD_USER
        '
        Me.TB_UPD_USER.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TB_UPD_USER.Location = New System.Drawing.Point(759, 6)
        Me.TB_UPD_USER.Name = "TB_UPD_USER"
        Me.TB_UPD_USER.ReadOnly = True
        Me.TB_UPD_USER.Size = New System.Drawing.Size(106, 23)
        Me.TB_UPD_USER.TabIndex = 11
        '
        'F10021_BZC_Msg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CanMaxSize = True
        Me.Controls.Add(Me.DP_UPD_DATE)
        Me.Controls.Add(Me.TB_UPD_USER)
        Me.Controls.Add(Me.PanelMain)
        Me.Controls.Add(Me.Tool_Top)
        Me.Name = "F10021_BZC_Msg"
        Me.Size = New System.Drawing.Size(1100, 700)
        Me.Title = "BOM表详细信息"
        Me.Tool_Top.ResumeLayout(False)
        Me.Tool_Top.PerformLayout()
        Me.PanelMain.ResumeLayout(False)
        Me.PanelMain.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.Fg2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Fg3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.Fg1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Tool_Top As System.Windows.Forms.ToolStrip
    Friend WithEvents Cmd_Modify As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Cmd_Exit As System.Windows.Forms.ToolStripButton
    Friend WithEvents PanelMain As System.Windows.Forms.Panel
    Friend WithEvents TB_Name As System.Windows.Forms.TextBox
    Friend WithEvents LB_FullName As System.Windows.Forms.Label
    Friend WithEvents TB_Remark As System.Windows.Forms.TextBox
    Friend WithEvents TB_BZC_No As System.Windows.Forms.TextBox
    Friend WithEvents TB_SupplierName As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TB_UPD_USER As System.Windows.Forms.TextBox
    Friend WithEvents DP_UPD_DATE As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label_ID As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Fg1 As PClass.FG
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Btn_AddRow As System.Windows.Forms.ToolStripButton
    Friend WithEvents Btn_RemoveRow As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TB_Qian_ChuLi As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DP_Found_Date As System.Windows.Forms.DateTimePicker
    Friend WithEvents TB_BZ_Name As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TB_Client_Bzc As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label_Client_Name As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Cmd_PF_Add As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_PF_Remove As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripButton_CopyVi_RL As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Fg2 As PClass.FG
    Friend WithEvents Fg3 As PClass.FG
    Friend WithEvents Cmd_CopyPF As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CB_RanSe As System.Windows.Forms.ComboBox
    Friend WithEvents CB_BZ As BaseClass.ComBoList
    Friend WithEvents CB_Client As BaseClass.ComBoList
    Friend WithEvents CB_BZ_FG As BaseClass.ComBoList
    Friend WithEvents Cmd_ClientChoose As System.Windows.Forms.ToolStripButton

End Class
