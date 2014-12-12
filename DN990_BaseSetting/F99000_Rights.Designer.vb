<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F99000_Rights
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F99000_Rights))
        Me.Tool_Top = New System.Windows.Forms.ToolStrip
        Me.Cmd_Modify = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.Cmd_Add = New System.Windows.Forms.ToolStripButton
        Me.Cmd_Del = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.Cmd_ShowAll = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripButton_SelALL = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton_SelNone = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton_NSel = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripButton_CopyVi_RL = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton_PasteVi_RL = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.Cmd_Exit = New System.Windows.Forms.ToolStripButton
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.FG_Control = New PClass.FG
        Me.Splitter4 = New System.Windows.Forms.Splitter
        Me.FG_Form = New PClass.FG
        Me.Splitter3 = New System.Windows.Forms.Splitter
        Me.FG_Model = New PClass.FG
        Me.Splitter2 = New System.Windows.Forms.Splitter
        Me.FG_Menu = New PClass.FG
        Me.Splitter1 = New System.Windows.Forms.Splitter
        Me.FG_Group = New PClass.FG
        Me.Panel_UserGroup = New System.Windows.Forms.Panel
        Me.GroupBox_UserGroup = New System.Windows.Forms.GroupBox
        Me.Button_Group_Exit = New System.Windows.Forms.Button
        Me.Button_Group_Save = New System.Windows.Forms.Button
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Tool_Top.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.FG_Control, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FG_Form, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FG_Model, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FG_Menu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FG_Group, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel_UserGroup.SuspendLayout()
        Me.GroupBox_UserGroup.SuspendLayout()
        Me.SuspendLayout()
        '
        'Tool_Top
        '
        Me.Tool_Top.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.Tool_Top.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Cmd_Modify, Me.ToolStripSeparator1, Me.Cmd_Add, Me.Cmd_Del, Me.ToolStripSeparator2, Me.Cmd_ShowAll, Me.ToolStripSeparator3, Me.ToolStripButton_SelALL, Me.ToolStripButton_SelNone, Me.ToolStripButton_NSel, Me.ToolStripSeparator4, Me.ToolStripButton_CopyVi_RL, Me.ToolStripButton_PasteVi_RL, Me.ToolStripSeparator5, Me.Cmd_Exit})
        Me.Tool_Top.Location = New System.Drawing.Point(0, 0)
        Me.Tool_Top.MinimumSize = New System.Drawing.Size(0, 50)
        Me.Tool_Top.Name = "Tool_Top"
        Me.Tool_Top.Size = New System.Drawing.Size(1167, 50)
        Me.Tool_Top.TabIndex = 9
        Me.Tool_Top.Text = "ToolStrip2"
        '
        'Cmd_Modify
        '
        Me.Cmd_Modify.AccessibleDescription = "修改按钮"
        Me.Cmd_Modify.AccessibleName = ""
        Me.Cmd_Modify.Image = Global.DN990_BaseSetting.My.Resources.Resources.Modify
        Me.Cmd_Modify.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Modify.Name = "Cmd_Modify"
        Me.Cmd_Modify.Size = New System.Drawing.Size(57, 47)
        Me.Cmd_Modify.Text = "修改权限"
        Me.Cmd_Modify.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 50)
        '
        'Cmd_Add
        '
        Me.Cmd_Add.AccessibleDescription = ""
        Me.Cmd_Add.AccessibleName = ""
        Me.Cmd_Add.Image = Global.DN990_BaseSetting.My.Resources.Resources.ADD
        Me.Cmd_Add.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Add.Name = "Cmd_Add"
        Me.Cmd_Add.Size = New System.Drawing.Size(45, 47)
        Me.Cmd_Add.Text = "添加组"
        Me.Cmd_Add.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'Cmd_Del
        '
        Me.Cmd_Del.AccessibleDescription = ""
        Me.Cmd_Del.AccessibleName = ""
        Me.Cmd_Del.Image = Global.DN990_BaseSetting.My.Resources.Resources.Delete
        Me.Cmd_Del.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Del.Name = "Cmd_Del"
        Me.Cmd_Del.Size = New System.Drawing.Size(45, 47)
        Me.Cmd_Del.Text = "删除组"
        Me.Cmd_Del.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 50)
        '
        'Cmd_ShowAll
        '
        Me.Cmd_ShowAll.CheckOnClick = True
        Me.Cmd_ShowAll.Image = Global.DN990_BaseSetting.My.Resources.Resources.Look_All
        Me.Cmd_ShowAll.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_ShowAll.Name = "Cmd_ShowAll"
        Me.Cmd_ShowAll.Size = New System.Drawing.Size(57, 47)
        Me.Cmd_ShowAll.Text = "全部查看"
        Me.Cmd_ShowAll.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 50)
        '
        'ToolStripButton_SelALL
        '
        Me.ToolStripButton_SelALL.Image = Global.DN990_BaseSetting.My.Resources.Resources.Cell_Click
        Me.ToolStripButton_SelALL.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_SelALL.Name = "ToolStripButton_SelALL"
        Me.ToolStripButton_SelALL.Size = New System.Drawing.Size(33, 47)
        Me.ToolStripButton_SelALL.Text = "全选"
        Me.ToolStripButton_SelALL.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripButton_SelNone
        '
        Me.ToolStripButton_SelNone.Image = Global.DN990_BaseSetting.My.Resources.Resources.Cell_NoClick
        Me.ToolStripButton_SelNone.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_SelNone.Name = "ToolStripButton_SelNone"
        Me.ToolStripButton_SelNone.Size = New System.Drawing.Size(45, 47)
        Me.ToolStripButton_SelNone.Text = "全不选"
        Me.ToolStripButton_SelNone.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripButton_NSel
        '
        Me.ToolStripButton_NSel.Image = Global.DN990_BaseSetting.My.Resources.Resources.Cell_UnClick
        Me.ToolStripButton_NSel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_NSel.Name = "ToolStripButton_NSel"
        Me.ToolStripButton_NSel.Size = New System.Drawing.Size(33, 47)
        Me.ToolStripButton_NSel.Text = "反选"
        Me.ToolStripButton_NSel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 50)
        '
        'ToolStripButton_CopyVi_RL
        '
        Me.ToolStripButton_CopyVi_RL.Image = Global.DN990_BaseSetting.My.Resources.Resources.Paste
        Me.ToolStripButton_CopyVi_RL.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_CopyVi_RL.Name = "ToolStripButton_CopyVi_RL"
        Me.ToolStripButton_CopyVi_RL.Size = New System.Drawing.Size(33, 47)
        Me.ToolStripButton_CopyVi_RL.Text = "复制"
        Me.ToolStripButton_CopyVi_RL.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripButton_PasteVi_RL
        '
        Me.ToolStripButton_PasteVi_RL.Enabled = False
        Me.ToolStripButton_PasteVi_RL.Image = CType(resources.GetObject("ToolStripButton_PasteVi_RL.Image"), System.Drawing.Image)
        Me.ToolStripButton_PasteVi_RL.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_PasteVi_RL.Name = "ToolStripButton_PasteVi_RL"
        Me.ToolStripButton_PasteVi_RL.Size = New System.Drawing.Size(33, 47)
        Me.ToolStripButton_PasteVi_RL.Text = "粘贴"
        Me.ToolStripButton_PasteVi_RL.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 50)
        '
        'Cmd_Exit
        '
        Me.Cmd_Exit.Image = Global.DN990_BaseSetting.My.Resources.Resources.Close
        Me.Cmd_Exit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(33, 47)
        Me.Cmd_Exit.Text = "关闭"
        Me.Cmd_Exit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.Tool_Top)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1167, 598)
        Me.Panel1.TabIndex = 11
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.FG_Control)
        Me.Panel2.Controls.Add(Me.Splitter4)
        Me.Panel2.Controls.Add(Me.FG_Form)
        Me.Panel2.Controls.Add(Me.Splitter3)
        Me.Panel2.Controls.Add(Me.FG_Model)
        Me.Panel2.Controls.Add(Me.Splitter2)
        Me.Panel2.Controls.Add(Me.FG_Menu)
        Me.Panel2.Controls.Add(Me.Splitter1)
        Me.Panel2.Controls.Add(Me.FG_Group)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 50)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Padding = New System.Windows.Forms.Padding(2)
        Me.Panel2.Size = New System.Drawing.Size(1167, 548)
        Me.Panel2.TabIndex = 12
        '
        'FG_Control
        '
        Me.FG_Control.AutoAddIndex = False
        Me.FG_Control.AutoGenerateColumns = False
        Me.FG_Control.AutoResize = False
        Me.FG_Control.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.FG_Control.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.XpThemes
        Me.FG_Control.CanEditing = True
        Me.FG_Control.ColumnInfo = resources.GetString("FG_Control.ColumnInfo")
        Me.FG_Control.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FG_Control.EditFormat = True
        Me.FG_Control.ExtendLastCol = True
        Me.FG_Control.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.FG_Control.ForeColor = System.Drawing.Color.Black
        Me.FG_Control.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.FG_Control.IsAutoAddRow = True
        Me.FG_Control.IsClickStartEdit = False
        Me.FG_Control.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.FG_Control.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.FG_Control.Location = New System.Drawing.Point(854, 2)
        Me.FG_Control.Name = "FG_Control"
        Me.FG_Control.Rows.Count = 10
        Me.FG_Control.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox
        Me.FG_Control.Size = New System.Drawing.Size(311, 544)
        Me.FG_Control.StartCol = ""
        Me.FG_Control.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("FG_Control.Styles"))
        Me.FG_Control.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.BelowData
        Me.FG_Control.TabIndex = 18
        '
        'Splitter4
        '
        Me.Splitter4.Location = New System.Drawing.Point(851, 2)
        Me.Splitter4.Name = "Splitter4"
        Me.Splitter4.Size = New System.Drawing.Size(3, 544)
        Me.Splitter4.TabIndex = 17
        Me.Splitter4.TabStop = False
        '
        'FG_Form
        '
        Me.FG_Form.AutoAddIndex = False
        Me.FG_Form.AutoGenerateColumns = False
        Me.FG_Form.AutoResize = False
        Me.FG_Form.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.FG_Form.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.XpThemes
        Me.FG_Form.CanEditing = True
        Me.FG_Form.ColumnInfo = resources.GetString("FG_Form.ColumnInfo")
        Me.FG_Form.Dock = System.Windows.Forms.DockStyle.Left
        Me.FG_Form.EditFormat = True
        Me.FG_Form.ExtendLastCol = True
        Me.FG_Form.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.FG_Form.ForeColor = System.Drawing.Color.Black
        Me.FG_Form.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.FG_Form.IsAutoAddRow = True
        Me.FG_Form.IsClickStartEdit = False
        Me.FG_Form.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.FG_Form.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.FG_Form.Location = New System.Drawing.Point(641, 2)
        Me.FG_Form.Name = "FG_Form"
        Me.FG_Form.Rows.Count = 10
        Me.FG_Form.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox
        Me.FG_Form.Size = New System.Drawing.Size(210, 544)
        Me.FG_Form.StartCol = ""
        Me.FG_Form.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("FG_Form.Styles"))
        Me.FG_Form.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.BelowData
        Me.FG_Form.TabIndex = 16
        '
        'Splitter3
        '
        Me.Splitter3.Location = New System.Drawing.Point(638, 2)
        Me.Splitter3.Name = "Splitter3"
        Me.Splitter3.Size = New System.Drawing.Size(3, 544)
        Me.Splitter3.TabIndex = 15
        Me.Splitter3.TabStop = False
        '
        'FG_Model
        '
        Me.FG_Model.AutoAddIndex = False
        Me.FG_Model.AutoGenerateColumns = False
        Me.FG_Model.AutoResize = False
        Me.FG_Model.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.FG_Model.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.XpThemes
        Me.FG_Model.CanEditing = True
        Me.FG_Model.ColumnInfo = resources.GetString("FG_Model.ColumnInfo")
        Me.FG_Model.Dock = System.Windows.Forms.DockStyle.Left
        Me.FG_Model.EditFormat = True
        Me.FG_Model.ExtendLastCol = True
        Me.FG_Model.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.FG_Model.ForeColor = System.Drawing.Color.Black
        Me.FG_Model.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.FG_Model.IsAutoAddRow = True
        Me.FG_Model.IsClickStartEdit = False
        Me.FG_Model.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.FG_Model.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.FG_Model.Location = New System.Drawing.Point(428, 2)
        Me.FG_Model.Name = "FG_Model"
        Me.FG_Model.Rows.Count = 10
        Me.FG_Model.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox
        Me.FG_Model.Size = New System.Drawing.Size(210, 544)
        Me.FG_Model.StartCol = ""
        Me.FG_Model.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("FG_Model.Styles"))
        Me.FG_Model.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.BelowData
        Me.FG_Model.TabIndex = 14
        '
        'Splitter2
        '
        Me.Splitter2.Location = New System.Drawing.Point(425, 2)
        Me.Splitter2.Name = "Splitter2"
        Me.Splitter2.Size = New System.Drawing.Size(3, 544)
        Me.Splitter2.TabIndex = 13
        Me.Splitter2.TabStop = False
        '
        'FG_Menu
        '
        Me.FG_Menu.AutoAddIndex = False
        Me.FG_Menu.AutoGenerateColumns = False
        Me.FG_Menu.AutoResize = False
        Me.FG_Menu.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.FG_Menu.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.XpThemes
        Me.FG_Menu.CanEditing = True
        Me.FG_Menu.ColumnInfo = resources.GetString("FG_Menu.ColumnInfo")
        Me.FG_Menu.Dock = System.Windows.Forms.DockStyle.Left
        Me.FG_Menu.EditFormat = True
        Me.FG_Menu.ExtendLastCol = True
        Me.FG_Menu.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.FG_Menu.ForeColor = System.Drawing.Color.Black
        Me.FG_Menu.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.FG_Menu.IsAutoAddRow = True
        Me.FG_Menu.IsClickStartEdit = False
        Me.FG_Menu.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.FG_Menu.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.FG_Menu.Location = New System.Drawing.Point(215, 2)
        Me.FG_Menu.Name = "FG_Menu"
        Me.FG_Menu.Rows.Count = 10
        Me.FG_Menu.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox
        Me.FG_Menu.Size = New System.Drawing.Size(210, 544)
        Me.FG_Menu.StartCol = ""
        Me.FG_Menu.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("FG_Menu.Styles"))
        Me.FG_Menu.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.BelowData
        Me.FG_Menu.TabIndex = 12
        '
        'Splitter1
        '
        Me.Splitter1.Location = New System.Drawing.Point(212, 2)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(3, 544)
        Me.Splitter1.TabIndex = 0
        Me.Splitter1.TabStop = False
        '
        'FG_Group
        '
        Me.FG_Group.AutoAddIndex = False
        Me.FG_Group.AutoGenerateColumns = False
        Me.FG_Group.AutoResize = False
        Me.FG_Group.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.FG_Group.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.XpThemes
        Me.FG_Group.CanEditing = False
        Me.FG_Group.ColumnInfo = resources.GetString("FG_Group.ColumnInfo")
        Me.FG_Group.Dock = System.Windows.Forms.DockStyle.Left
        Me.FG_Group.EditFormat = True
        Me.FG_Group.ExtendLastCol = True
        Me.FG_Group.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.FG_Group.ForeColor = System.Drawing.Color.Black
        Me.FG_Group.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.FG_Group.IsAutoAddRow = True
        Me.FG_Group.IsClickStartEdit = False
        Me.FG_Group.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.FG_Group.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.FG_Group.Location = New System.Drawing.Point(2, 2)
        Me.FG_Group.Name = "FG_Group"
        Me.FG_Group.Rows.Count = 10
        Me.FG_Group.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.FG_Group.Size = New System.Drawing.Size(210, 544)
        Me.FG_Group.StartCol = ""
        Me.FG_Group.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("FG_Group.Styles"))
        Me.FG_Group.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.BelowData
        Me.FG_Group.TabIndex = 11
        '
        'Panel_UserGroup
        '
        Me.Panel_UserGroup.Controls.Add(Me.GroupBox_UserGroup)
        Me.Panel_UserGroup.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel_UserGroup.Location = New System.Drawing.Point(0, 0)
        Me.Panel_UserGroup.Name = "Panel_UserGroup"
        Me.Panel_UserGroup.Size = New System.Drawing.Size(1167, 598)
        Me.Panel_UserGroup.TabIndex = 19
        Me.Panel_UserGroup.Visible = False
        '
        'GroupBox_UserGroup
        '
        Me.GroupBox_UserGroup.BackColor = System.Drawing.Color.White
        Me.GroupBox_UserGroup.Controls.Add(Me.Button_Group_Exit)
        Me.GroupBox_UserGroup.Controls.Add(Me.Button_Group_Save)
        Me.GroupBox_UserGroup.Controls.Add(Me.CheckBox1)
        Me.GroupBox_UserGroup.Controls.Add(Me.Label1)
        Me.GroupBox_UserGroup.Controls.Add(Me.TextBox1)
        Me.GroupBox_UserGroup.Location = New System.Drawing.Point(377, 168)
        Me.GroupBox_UserGroup.Name = "GroupBox_UserGroup"
        Me.GroupBox_UserGroup.Size = New System.Drawing.Size(344, 210)
        Me.GroupBox_UserGroup.TabIndex = 0
        Me.GroupBox_UserGroup.TabStop = False
        Me.GroupBox_UserGroup.Text = "用户组别"
        '
        'Button_Group_Exit
        '
        Me.Button_Group_Exit.ForeColor = System.Drawing.Color.Red
        Me.Button_Group_Exit.Location = New System.Drawing.Point(211, 140)
        Me.Button_Group_Exit.Name = "Button_Group_Exit"
        Me.Button_Group_Exit.Size = New System.Drawing.Size(104, 37)
        Me.Button_Group_Exit.TabIndex = 4
        Me.Button_Group_Exit.Text = "取消(&C)"
        Me.Button_Group_Exit.UseVisualStyleBackColor = True
        '
        'Button_Group_Save
        '
        Me.Button_Group_Save.ForeColor = System.Drawing.Color.Blue
        Me.Button_Group_Save.Location = New System.Drawing.Point(57, 140)
        Me.Button_Group_Save.Name = "Button_Group_Save"
        Me.Button_Group_Save.Size = New System.Drawing.Size(104, 37)
        Me.Button_Group_Save.TabIndex = 3
        Me.Button_Group_Save.Text = "保存(&S)"
        Me.Button_Group_Save.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(94, 82)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(82, 18)
        Me.CheckBox1.TabIndex = 2
        Me.CheckBox1.Text = "是否启用"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 14)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "组别名称:"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(94, 42)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(231, 23)
        Me.TextBox1.TabIndex = 0
        '
        'F99000_Rights
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel_UserGroup)
        Me.Name = "F99000_Rights"
        Me.Size = New System.Drawing.Size(1167, 598)
        Me.Title = "权限设置"
        Me.Tool_Top.ResumeLayout(False)
        Me.Tool_Top.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.FG_Control, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FG_Form, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FG_Model, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FG_Menu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FG_Group, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel_UserGroup.ResumeLayout(False)
        Me.GroupBox_UserGroup.ResumeLayout(False)
        Me.GroupBox_UserGroup.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Tool_Top As System.Windows.Forms.ToolStrip
    Friend WithEvents Cmd_Del As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Cmd_ShowAll As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton_SelALL As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton_SelNone As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton_NSel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton_CopyVi_RL As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton_PasteVi_RL As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Cmd_Exit As System.Windows.Forms.ToolStripButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents FG_Group As PClass.FG
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents FG_Menu As PClass.FG
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents FG_Form As PClass.FG
    Friend WithEvents Splitter3 As System.Windows.Forms.Splitter
    Friend WithEvents FG_Model As PClass.FG
    Friend WithEvents Splitter2 As System.Windows.Forms.Splitter
    Friend WithEvents FG_Control As PClass.FG
    Friend WithEvents Splitter4 As System.Windows.Forms.Splitter
    Friend WithEvents Cmd_Add As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_Modify As System.Windows.Forms.ToolStripButton
    Friend WithEvents Panel_UserGroup As System.Windows.Forms.Panel
    Friend WithEvents GroupBox_UserGroup As System.Windows.Forms.GroupBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button_Group_Exit As System.Windows.Forms.Button
    Friend WithEvents Button_Group_Save As System.Windows.Forms.Button
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator

End Class
