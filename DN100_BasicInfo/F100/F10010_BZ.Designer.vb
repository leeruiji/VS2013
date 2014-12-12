<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F10010_BZ
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F10010_BZ))
        Me.Tool_Top = New System.Windows.Forms.ToolStrip
        Me.Cmd_Add = New System.Windows.Forms.ToolStripButton
        Me.Cmd_Modify = New System.Windows.Forms.ToolStripButton
        Me.Cmd_Del = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.Btn_Refresh = New System.Windows.Forms.ToolStripButton
        Me.Cmd_Preview = New System.Windows.Forms.ToolStripButton
        Me.Cmd_Exit = New System.Windows.Forms.ToolStripButton
        Me.FG1 = New PClass.FG
        Me.CMS_Goods = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.TSMI_Add = New System.Windows.Forms.ToolStripMenuItem
        Me.TSMI_Modify = New System.Windows.Forms.ToolStripMenuItem
        Me.TSMI_Del = New System.Windows.Forms.ToolStripMenuItem
        Me.PanelMain = New System.Windows.Forms.Panel
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.Tool_Search = New System.Windows.Forms.ToolStrip
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel
        Me.CB_ConditionName1 = New System.Windows.Forms.ToolStripComboBox
        Me.TB_ConditionValue1 = New System.Windows.Forms.ToolStripTextBox
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel
        Me.CB_ConditionName2 = New System.Windows.Forms.ToolStripComboBox
        Me.CB_ConditionValue2 = New System.Windows.Forms.ToolStripComboBox
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel
        Me.TM_State = New System.Windows.Forms.ToolStripDropDownButton
        Me.TSM_All = New System.Windows.Forms.ToolStripMenuItem
        Me.TSM_isUse = New System.Windows.Forms.ToolStripMenuItem
        Me.Tlm_Disble = New System.Windows.Forms.ToolStripMenuItem
        Me.Btn_Search = New System.Windows.Forms.ToolStripButton
        Me.ClinetBZTree1 = New DN100_BasicInfo.ClinetBZTree
        Me.Tool_Top.SuspendLayout()
        CType(Me.FG1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CMS_Goods.SuspendLayout()
        Me.PanelMain.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.Tool_Search.SuspendLayout()
        Me.SuspendLayout()
        '
        'Tool_Top
        '
        Me.Tool_Top.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.Tool_Top.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Cmd_Add, Me.Cmd_Modify, Me.Cmd_Del, Me.ToolStripSeparator2, Me.Btn_Refresh, Me.Cmd_Preview, Me.Cmd_Exit})
        Me.Tool_Top.Location = New System.Drawing.Point(0, 0)
        Me.Tool_Top.MinimumSize = New System.Drawing.Size(0, 40)
        Me.Tool_Top.Name = "Tool_Top"
        Me.Tool_Top.Size = New System.Drawing.Size(1005, 40)
        Me.Tool_Top.TabIndex = 10
        Me.Tool_Top.Text = "ToolStrip2"
        '
        'Cmd_Add
        '
        Me.Cmd_Add.AccessibleDescription = "新增"
        Me.Cmd_Add.AccessibleName = ""
        Me.Cmd_Add.Image = Global.DN100_BasicInfo.My.Resources.Resources.ADD
        Me.Cmd_Add.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Add.Name = "Cmd_Add"
        Me.Cmd_Add.Size = New System.Drawing.Size(57, 37)
        Me.Cmd_Add.Text = "新增"
        '
        'Cmd_Modify
        '
        Me.Cmd_Modify.AccessibleDescription = "修改按钮"
        Me.Cmd_Modify.AccessibleName = ""
        Me.Cmd_Modify.Image = Global.DN100_BasicInfo.My.Resources.Resources.Modify
        Me.Cmd_Modify.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Modify.Name = "Cmd_Modify"
        Me.Cmd_Modify.Size = New System.Drawing.Size(57, 37)
        Me.Cmd_Modify.Text = "修改"
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
        'Btn_Refresh
        '
        Me.Btn_Refresh.Image = Global.DN100_BasicInfo.My.Resources.Resources.ReFresh
        Me.Btn_Refresh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Btn_Refresh.Name = "Btn_Refresh"
        Me.Btn_Refresh.Size = New System.Drawing.Size(57, 37)
        Me.Btn_Refresh.Text = "刷新"
        '
        'Cmd_Preview
        '
        Me.Cmd_Preview.Image = Global.DN100_BasicInfo.My.Resources.Resources.Print_preview
        Me.Cmd_Preview.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Preview.Name = "Cmd_Preview"
        Me.Cmd_Preview.Size = New System.Drawing.Size(57, 37)
        Me.Cmd_Preview.Text = "预览"
        '
        'Cmd_Exit
        '
        Me.Cmd_Exit.Image = Global.DN100_BasicInfo.My.Resources.Resources.Close
        Me.Cmd_Exit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(57, 37)
        Me.Cmd_Exit.Text = "关闭"
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
        Me.FG1.ContextMenuStrip = Me.CMS_Goods
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
        Me.FG1.Location = New System.Drawing.Point(0, 30)
        Me.FG1.Name = "FG1"
        Me.FG1.NoShowMenu = False
        Me.FG1.Rows.Count = 10
        Me.FG1.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.FG1.Size = New System.Drawing.Size(757, 626)
        Me.FG1.StartCol = ""
        Me.FG1.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("FG1.Styles"))
        Me.FG1.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.BelowData
        Me.FG1.TabIndex = 11
        '
        'CMS_Goods
        '
        Me.CMS_Goods.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSMI_Add, Me.TSMI_Modify, Me.TSMI_Del})
        Me.CMS_Goods.Name = "CMS_Goods"
        Me.CMS_Goods.Size = New System.Drawing.Size(119, 70)
        '
        'TSMI_Add
        '
        Me.TSMI_Add.Name = "TSMI_Add"
        Me.TSMI_Add.Size = New System.Drawing.Size(118, 22)
        Me.TSMI_Add.Text = "新增布类"
        '
        'TSMI_Modify
        '
        Me.TSMI_Modify.Name = "TSMI_Modify"
        Me.TSMI_Modify.Size = New System.Drawing.Size(118, 22)
        Me.TSMI_Modify.Text = "修改布类"
        '
        'TSMI_Del
        '
        Me.TSMI_Del.Name = "TSMI_Del"
        Me.TSMI_Del.Size = New System.Drawing.Size(118, 22)
        Me.TSMI_Del.Text = "删除布类"
        '
        'PanelMain
        '
        Me.PanelMain.Controls.Add(Me.SplitContainer1)
        Me.PanelMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelMain.Location = New System.Drawing.Point(0, 40)
        Me.PanelMain.Name = "PanelMain"
        Me.PanelMain.Padding = New System.Windows.Forms.Padding(2)
        Me.PanelMain.Size = New System.Drawing.Size(1005, 660)
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.ClinetBZTree1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.FG1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Tool_Search)
        Me.SplitContainer1.Size = New System.Drawing.Size(1001, 656)
        Me.SplitContainer1.SplitterDistance = 240
        Me.SplitContainer1.TabIndex = 12
        '
        'Tool_Search
        '
        Me.Tool_Search.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.CB_ConditionName1, Me.TB_ConditionValue1, Me.ToolStripLabel2, Me.CB_ConditionName2, Me.CB_ConditionValue2, Me.ToolStripLabel3, Me.TM_State, Me.Btn_Search})
        Me.Tool_Search.Location = New System.Drawing.Point(0, 0)
        Me.Tool_Search.MinimumSize = New System.Drawing.Size(0, 30)
        Me.Tool_Search.Name = "Tool_Search"
        Me.Tool_Search.Size = New System.Drawing.Size(757, 30)
        Me.Tool_Search.TabIndex = 0
        Me.Tool_Search.Text = "ToolStrip1"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(47, 27)
        Me.ToolStripLabel1.Text = "条件1："
        '
        'CB_ConditionName1
        '
        Me.CB_ConditionName1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CB_ConditionName1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_ConditionName1.Name = "CB_ConditionName1"
        Me.CB_ConditionName1.Size = New System.Drawing.Size(121, 30)
        '
        'TB_ConditionValue1
        '
        Me.TB_ConditionValue1.Name = "TB_ConditionValue1"
        Me.TB_ConditionValue1.Size = New System.Drawing.Size(100, 30)
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(47, 27)
        Me.ToolStripLabel2.Text = "条件2："
        '
        'CB_ConditionName2
        '
        Me.CB_ConditionName2.Name = "CB_ConditionName2"
        Me.CB_ConditionName2.Size = New System.Drawing.Size(121, 30)
        '
        'CB_ConditionValue2
        '
        Me.CB_ConditionValue2.Name = "CB_ConditionValue2"
        Me.CB_ConditionValue2.Size = New System.Drawing.Size(121, 30)
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(35, 27)
        Me.ToolStripLabel3.Text = "状态:"
        '
        'TM_State
        '
        Me.TM_State.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.TM_State.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSM_All, Me.TSM_isUse, Me.Tlm_Disble})
        Me.TM_State.ForeColor = System.Drawing.SystemColors.Desktop
        Me.TM_State.Image = CType(resources.GetObject("TM_State.Image"), System.Drawing.Image)
        Me.TM_State.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TM_State.Name = "TM_State"
        Me.TM_State.Size = New System.Drawing.Size(42, 27)
        Me.TM_State.Tag = "0"
        Me.TM_State.Text = "在用"
        '
        'TSM_All
        '
        Me.TSM_All.Name = "TSM_All"
        Me.TSM_All.Size = New System.Drawing.Size(152, 22)
        Me.TSM_All.Text = "全部"
        '
        'TSM_isUse
        '
        Me.TSM_isUse.Name = "TSM_isUse"
        Me.TSM_isUse.Size = New System.Drawing.Size(152, 22)
        Me.TSM_isUse.Text = "在用"
        '
        'Tlm_Disble
        '
        Me.Tlm_Disble.Name = "Tlm_Disble"
        Me.Tlm_Disble.Size = New System.Drawing.Size(152, 22)
        Me.Tlm_Disble.Text = "禁用"
        '
        'Btn_Search
        '
        Me.Btn_Search.Image = Global.DN100_BasicInfo.My.Resources.Resources.Search
        Me.Btn_Search.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.Btn_Search.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Btn_Search.Name = "Btn_Search"
        Me.Btn_Search.Size = New System.Drawing.Size(65, 27)
        Me.Btn_Search.Text = "搜索"
        '
        'ClinetBZTree1
        '
        Me.ClinetBZTree1.BackgroundImage = Global.DN100_BasicInfo.My.Resources.Resources.Print_preview
        Me.ClinetBZTree1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ClinetBZTree1.Location = New System.Drawing.Point(0, 0)
        Me.ClinetBZTree1.Name = "ClinetBZTree1"
        Me.ClinetBZTree1.Size = New System.Drawing.Size(240, 656)
        Me.ClinetBZTree1.TabIndex = 0
        '
        'F10010_BZ
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.PanelMain)
        Me.Controls.Add(Me.Tool_Top)
        Me.Name = "F10010_BZ"
        Me.Size = New System.Drawing.Size(1005, 700)
        Me.Tool_Top.ResumeLayout(False)
        Me.Tool_Top.PerformLayout()
        CType(Me.FG1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CMS_Goods.ResumeLayout(False)
        Me.PanelMain.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        Me.SplitContainer1.ResumeLayout(False)
        Me.Tool_Search.ResumeLayout(False)
        Me.Tool_Search.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Tool_Top As System.Windows.Forms.ToolStrip
    Friend WithEvents Cmd_Add As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_Modify As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_Del As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Cmd_Exit As System.Windows.Forms.ToolStripButton
    Friend WithEvents FG1 As PClass.FG
    Friend WithEvents PanelMain As System.Windows.Forms.Panel
    Friend WithEvents Btn_Refresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents CMS_Goods As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents TSMI_Add As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSMI_Modify As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSMI_Del As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Tool_Search As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents CB_ConditionName1 As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents CB_ConditionName2 As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents CB_ConditionValue2 As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents Btn_Search As System.Windows.Forms.ToolStripButton
    Friend WithEvents TB_ConditionValue1 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ClinetBZTree1 As DN100_BasicInfo.ClinetBZTree
    Friend WithEvents Cmd_Preview As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripLabel3 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents TM_State As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents TSM_All As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSM_isUse As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Tlm_Disble As System.Windows.Forms.ToolStripMenuItem

End Class
