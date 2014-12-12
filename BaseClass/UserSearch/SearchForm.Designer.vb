<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SearchForm
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SearchForm))
        Me.FG1 = New PClass.FG
        Me.Tool_Top = New System.Windows.Forms.ToolStrip
        Me.Cmd_Save = New System.Windows.Forms.ToolStripButton
        Me.Cmd_IgnoreTime = New System.Windows.Forms.ToolStripButton
        Me.Menu_Search = New System.Windows.Forms.ToolStripDropDownButton
        Me.Cmd_Clear = New System.Windows.Forms.ToolStripButton
        Me.Cmd_Reset = New System.Windows.Forms.ToolStripButton
        Me.Cmd_Cancel = New System.Windows.Forms.ToolStripButton
        Me.CB_Operator = New System.Windows.Forms.ComboBox
        Me.CB_ConditionName = New System.Windows.Forms.ComboBox
        Me.CK_SaveValue = New System.Windows.Forms.CheckBox
        Me.CK_PreView = New System.Windows.Forms.CheckBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.SC_Condition = New System.Windows.Forms.SplitContainer
        Me.SC_Between = New System.Windows.Forms.SplitContainer
        Me.TB_Value1 = New System.Windows.Forms.TextBox
        Me.TB_Value2 = New System.Windows.Forms.TextBox
        Me.CB_ConditionValue = New System.Windows.Forms.ComboBox
        Me.TB_Value = New System.Windows.Forms.TextBox
        Me.Cmd_Add = New System.Windows.Forms.Button
        Me.RadioAnd = New System.Windows.Forms.RadioButton
        Me.RadioOr = New System.Windows.Forms.RadioButton
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.CKB_AddLast = New System.Windows.Forms.CheckBox
        Me.Cmd_Del = New System.Windows.Forms.Button
        Me.Cmd_Modify = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.PanelMain = New System.Windows.Forms.Panel
        CType(Me.FG1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tool_Top.SuspendLayout()
        Me.SC_Condition.Panel1.SuspendLayout()
        Me.SC_Condition.Panel2.SuspendLayout()
        Me.SC_Condition.SuspendLayout()
        Me.SC_Between.Panel1.SuspendLayout()
        Me.SC_Between.Panel2.SuspendLayout()
        Me.SC_Between.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.PanelMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'FG1
        '
        Me.FG1.AddCopyMenu = False
        Me.FG1.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.FG1.AllowEditing = False
        Me.FG1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FG1.AutoAddIndex = True
        Me.FG1.AutoGenerateColumns = False
        Me.FG1.AutoResize = False
        Me.FG1.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.FG1.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.XpThemes
        Me.FG1.CanEditing = False
        Me.FG1.CheckKeyPressEdit = True
        Me.FG1.ColumnInfo = resources.GetString("FG1.ColumnInfo")
        Me.FG1.EditFormat = True
        Me.FG1.ExtendLastCol = True
        Me.FG1.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.FG1.ForeColor = System.Drawing.Color.Black
        Me.FG1.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.FG1.IsAutoAddRow = True
        Me.FG1.IsClickStartEdit = True
        Me.FG1.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.FG1.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.FG1.Location = New System.Drawing.Point(0, 136)
        Me.FG1.Margin = New System.Windows.Forms.Padding(6)
        Me.FG1.Name = "FG1"
        Me.FG1.NoShowMenu = True
        Me.FG1.Rows.Count = 20
        Me.FG1.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.FG1.Size = New System.Drawing.Size(786, 292)
        Me.FG1.StartCol = ""
        Me.FG1.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("FG1.Styles"))
        Me.FG1.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.BelowData
        Me.FG1.TabIndex = 1
        '
        'Tool_Top
        '
        Me.Tool_Top.ImageScalingSize = New System.Drawing.Size(18, 18)
        Me.Tool_Top.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Cmd_Save, Me.Cmd_IgnoreTime, Me.Menu_Search, Me.Cmd_Clear, Me.Cmd_Reset, Me.Cmd_Cancel})
        Me.Tool_Top.Location = New System.Drawing.Point(0, 0)
        Me.Tool_Top.MinimumSize = New System.Drawing.Size(0, 33)
        Me.Tool_Top.Name = "Tool_Top"
        Me.Tool_Top.Size = New System.Drawing.Size(786, 33)
        Me.Tool_Top.TabIndex = 11
        Me.Tool_Top.Text = "ToolStrip2"
        '
        'Cmd_Save
        '
        Me.Cmd_Save.Image = Global.BaseClass.My.Resources.Resources.save
        Me.Cmd_Save.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Save.Name = "Cmd_Save"
        Me.Cmd_Save.Size = New System.Drawing.Size(51, 30)
        Me.Cmd_Save.Text = "确定"
        '
        'Cmd_IgnoreTime
        '
        Me.Cmd_IgnoreTime.CheckOnClick = True
        Me.Cmd_IgnoreTime.Image = Global.BaseClass.My.Resources.Resources._19
        Me.Cmd_IgnoreTime.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_IgnoreTime.Name = "Cmd_IgnoreTime"
        Me.Cmd_IgnoreTime.Size = New System.Drawing.Size(99, 30)
        Me.Cmd_IgnoreTime.Text = "忽略时间条件"
        '
        'Menu_Search
        '
        Me.Menu_Search.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.Menu_Search.Image = Global.BaseClass.My.Resources.Resources.favorits
        Me.Menu_Search.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Menu_Search.Name = "Menu_Search"
        Me.Menu_Search.Size = New System.Drawing.Size(84, 30)
        Me.Menu_Search.Text = "搜索方案"
        '
        'Cmd_Clear
        '
        Me.Cmd_Clear.Image = Global.BaseClass.My.Resources.Resources.trash
        Me.Cmd_Clear.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Clear.Name = "Cmd_Clear"
        Me.Cmd_Clear.Size = New System.Drawing.Size(99, 30)
        Me.Cmd_Clear.Text = "清除所有条件"
        '
        'Cmd_Reset
        '
        Me.Cmd_Reset.Image = Global.BaseClass.My.Resources.Resources.ReFresh
        Me.Cmd_Reset.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Reset.Name = "Cmd_Reset"
        Me.Cmd_Reset.Size = New System.Drawing.Size(99, 30)
        Me.Cmd_Reset.Text = "重置编辑内容"
        '
        'Cmd_Cancel
        '
        Me.Cmd_Cancel.Image = Global.BaseClass.My.Resources.Resources.Close
        Me.Cmd_Cancel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Cancel.Name = "Cmd_Cancel"
        Me.Cmd_Cancel.Size = New System.Drawing.Size(51, 30)
        Me.Cmd_Cancel.Text = "取消"
        '
        'CB_Operator
        '
        Me.CB_Operator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_Operator.FormattingEnabled = True
        Me.CB_Operator.Location = New System.Drawing.Point(654, 40)
        Me.CB_Operator.Name = "CB_Operator"
        Me.CB_Operator.Size = New System.Drawing.Size(115, 22)
        Me.CB_Operator.TabIndex = 13
        '
        'CB_ConditionName
        '
        Me.CB_ConditionName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CB_ConditionName.DropDownHeight = 145
        Me.CB_ConditionName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_ConditionName.FormattingEnabled = True
        Me.CB_ConditionName.IntegralHeight = False
        Me.CB_ConditionName.Location = New System.Drawing.Point(0, 0)
        Me.CB_ConditionName.Name = "CB_ConditionName"
        Me.CB_ConditionName.Size = New System.Drawing.Size(155, 22)
        Me.CB_ConditionName.TabIndex = 12
        '
        'CK_SaveValue
        '
        Me.CK_SaveValue.AutoSize = True
        Me.CK_SaveValue.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CK_SaveValue.Location = New System.Drawing.Point(294, 22)
        Me.CK_SaveValue.Name = "CK_SaveValue"
        Me.CK_SaveValue.Size = New System.Drawing.Size(96, 18)
        Me.CK_SaveValue.TabIndex = 23
        Me.CK_SaveValue.Text = "保存条件值"
        Me.CK_SaveValue.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CK_SaveValue.UseVisualStyleBackColor = True
        '
        'CK_PreView
        '
        Me.CK_PreView.AutoSize = True
        Me.CK_PreView.Location = New System.Drawing.Point(179, 21)
        Me.CK_PreView.Name = "CK_PreView"
        Me.CK_PreView.Size = New System.Drawing.Size(96, 18)
        Me.CK_PreView.TabIndex = 20
        Me.CK_PreView.Text = "列出可选值"
        Me.CK_PreView.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(593, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 14)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "操作符:"
        '
        'SC_Condition
        '
        Me.SC_Condition.Location = New System.Drawing.Point(105, 39)
        Me.SC_Condition.Name = "SC_Condition"
        '
        'SC_Condition.Panel1
        '
        Me.SC_Condition.Panel1.Controls.Add(Me.CB_ConditionName)
        '
        'SC_Condition.Panel2
        '
        Me.SC_Condition.Panel2.Controls.Add(Me.SC_Between)
        Me.SC_Condition.Panel2.Controls.Add(Me.CB_ConditionValue)
        Me.SC_Condition.Panel2.Controls.Add(Me.TB_Value)
        Me.SC_Condition.Size = New System.Drawing.Size(475, 31)
        Me.SC_Condition.SplitterDistance = 155
        Me.SC_Condition.SplitterWidth = 6
        Me.SC_Condition.TabIndex = 14
        '
        'SC_Between
        '
        Me.SC_Between.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SC_Between.Location = New System.Drawing.Point(0, 0)
        Me.SC_Between.Name = "SC_Between"
        '
        'SC_Between.Panel1
        '
        Me.SC_Between.Panel1.Controls.Add(Me.TB_Value1)
        '
        'SC_Between.Panel2
        '
        Me.SC_Between.Panel2.Controls.Add(Me.TB_Value2)
        Me.SC_Between.Size = New System.Drawing.Size(314, 31)
        Me.SC_Between.SplitterDistance = 149
        Me.SC_Between.SplitterWidth = 5
        Me.SC_Between.TabIndex = 2
        Me.SC_Between.Visible = False
        '
        'TB_Value1
        '
        Me.TB_Value1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TB_Value1.Location = New System.Drawing.Point(0, 0)
        Me.TB_Value1.Name = "TB_Value1"
        Me.TB_Value1.Size = New System.Drawing.Size(149, 23)
        Me.TB_Value1.TabIndex = 0
        '
        'TB_Value2
        '
        Me.TB_Value2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TB_Value2.Location = New System.Drawing.Point(0, 0)
        Me.TB_Value2.Name = "TB_Value2"
        Me.TB_Value2.Size = New System.Drawing.Size(160, 23)
        Me.TB_Value2.TabIndex = 1
        '
        'CB_ConditionValue
        '
        Me.CB_ConditionValue.DisplayMember = "ConditionValue"
        Me.CB_ConditionValue.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CB_ConditionValue.DropDownHeight = 145
        Me.CB_ConditionValue.FormattingEnabled = True
        Me.CB_ConditionValue.IntegralHeight = False
        Me.CB_ConditionValue.Location = New System.Drawing.Point(0, 0)
        Me.CB_ConditionValue.Name = "CB_ConditionValue"
        Me.CB_ConditionValue.Size = New System.Drawing.Size(314, 22)
        Me.CB_ConditionValue.TabIndex = 0
        Me.CB_ConditionValue.ValueMember = "ConditionValue"
        Me.CB_ConditionValue.Visible = False
        '
        'TB_Value
        '
        Me.TB_Value.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TB_Value.Location = New System.Drawing.Point(0, 0)
        Me.TB_Value.Name = "TB_Value"
        Me.TB_Value.Size = New System.Drawing.Size(314, 23)
        Me.TB_Value.TabIndex = 1
        '
        'Cmd_Add
        '
        Me.Cmd_Add.Location = New System.Drawing.Point(608, 81)
        Me.Cmd_Add.Name = "Cmd_Add"
        Me.Cmd_Add.Size = New System.Drawing.Size(50, 38)
        Me.Cmd_Add.TabIndex = 24
        Me.Cmd_Add.Text = "添加"
        Me.Cmd_Add.UseVisualStyleBackColor = True
        '
        'RadioAnd
        '
        Me.RadioAnd.AutoSize = True
        Me.RadioAnd.Checked = True
        Me.RadioAnd.Location = New System.Drawing.Point(7, 21)
        Me.RadioAnd.Name = "RadioAnd"
        Me.RadioAnd.Size = New System.Drawing.Size(74, 18)
        Me.RadioAnd.TabIndex = 2
        Me.RadioAnd.TabStop = True
        Me.RadioAnd.Text = "并且(&A)"
        Me.RadioAnd.UseVisualStyleBackColor = True
        '
        'RadioOr
        '
        Me.RadioOr.AutoSize = True
        Me.RadioOr.Location = New System.Drawing.Point(79, 21)
        Me.RadioOr.Name = "RadioOr"
        Me.RadioOr.Size = New System.Drawing.Size(74, 18)
        Me.RadioOr.TabIndex = 3
        Me.RadioOr.Text = "或者(&O)"
        Me.RadioOr.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CKB_AddLast)
        Me.GroupBox1.Controls.Add(Me.RadioOr)
        Me.GroupBox1.Controls.Add(Me.CK_SaveValue)
        Me.GroupBox1.Controls.Add(Me.RadioAnd)
        Me.GroupBox1.Controls.Add(Me.CK_PreView)
        Me.GroupBox1.Location = New System.Drawing.Point(11, 71)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(569, 56)
        Me.GroupBox1.TabIndex = 21
        Me.GroupBox1.TabStop = False
        '
        'CKB_AddLast
        '
        Me.CKB_AddLast.AutoSize = True
        Me.CKB_AddLast.Checked = True
        Me.CKB_AddLast.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CKB_AddLast.Location = New System.Drawing.Point(444, 22)
        Me.CKB_AddLast.Name = "CKB_AddLast"
        Me.CKB_AddLast.Size = New System.Drawing.Size(96, 18)
        Me.CKB_AddLast.TabIndex = 27
        Me.CKB_AddLast.Text = "添加到最末"
        Me.CKB_AddLast.UseVisualStyleBackColor = True
        '
        'Cmd_Del
        '
        Me.Cmd_Del.Location = New System.Drawing.Point(719, 81)
        Me.Cmd_Del.Name = "Cmd_Del"
        Me.Cmd_Del.Size = New System.Drawing.Size(50, 38)
        Me.Cmd_Del.TabIndex = 25
        Me.Cmd_Del.Text = "删除"
        Me.Cmd_Del.UseVisualStyleBackColor = True
        '
        'Cmd_Modify
        '
        Me.Cmd_Modify.Location = New System.Drawing.Point(664, 81)
        Me.Cmd_Modify.Name = "Cmd_Modify"
        Me.Cmd_Modify.Size = New System.Drawing.Size(50, 38)
        Me.Cmd_Modify.TabIndex = 26
        Me.Cmd_Modify.Text = "修改"
        Me.Cmd_Modify.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(36, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 14)
        Me.Label2.TabIndex = 27
        Me.Label2.Text = "条件:"
        '
        'PanelMain
        '
        Me.PanelMain.Controls.Add(Me.Tool_Top)
        Me.PanelMain.Controls.Add(Me.FG1)
        Me.PanelMain.Controls.Add(Me.Label2)
        Me.PanelMain.Controls.Add(Me.Cmd_Del)
        Me.PanelMain.Controls.Add(Me.Cmd_Modify)
        Me.PanelMain.Controls.Add(Me.CB_Operator)
        Me.PanelMain.Controls.Add(Me.Cmd_Add)
        Me.PanelMain.Controls.Add(Me.Label1)
        Me.PanelMain.Controls.Add(Me.GroupBox1)
        Me.PanelMain.Controls.Add(Me.SC_Condition)
        Me.PanelMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelMain.Location = New System.Drawing.Point(0, 0)
        Me.PanelMain.Name = "PanelMain"
        Me.PanelMain.Size = New System.Drawing.Size(786, 428)
        Me.PanelMain.TabIndex = 0
        '
        'SearchForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(786, 428)
        Me.Controls.Add(Me.PanelMain)
        Me.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(221, 32)
        Me.Name = "SearchForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "高级搜索"
        CType(Me.FG1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tool_Top.ResumeLayout(False)
        Me.Tool_Top.PerformLayout()
        Me.SC_Condition.Panel1.ResumeLayout(False)
        Me.SC_Condition.Panel2.ResumeLayout(False)
        Me.SC_Condition.Panel2.PerformLayout()
        Me.SC_Condition.ResumeLayout(False)
        Me.SC_Between.Panel1.ResumeLayout(False)
        Me.SC_Between.Panel1.PerformLayout()
        Me.SC_Between.Panel2.ResumeLayout(False)
        Me.SC_Between.Panel2.PerformLayout()
        Me.SC_Between.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.PanelMain.ResumeLayout(False)
        Me.PanelMain.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents FG1 As PClass.FG
    Friend WithEvents Tool_Top As System.Windows.Forms.ToolStrip
    Friend WithEvents CB_Operator As System.Windows.Forms.ComboBox
    Friend WithEvents CB_ConditionName As System.Windows.Forms.ComboBox
    Friend WithEvents Cmd_Save As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_Cancel As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_IgnoreTime As System.Windows.Forms.ToolStripButton
    Friend WithEvents CK_SaveValue As System.Windows.Forms.CheckBox
    Friend WithEvents CK_PreView As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SC_Condition As System.Windows.Forms.SplitContainer
    Friend WithEvents SC_Between As System.Windows.Forms.SplitContainer
    Friend WithEvents TB_Value1 As System.Windows.Forms.TextBox
    Friend WithEvents TB_Value2 As System.Windows.Forms.TextBox
    Friend WithEvents CB_ConditionValue As System.Windows.Forms.ComboBox
    Friend WithEvents TB_Value As System.Windows.Forms.TextBox
    Friend WithEvents Cmd_Add As System.Windows.Forms.Button
    Friend WithEvents RadioAnd As System.Windows.Forms.RadioButton
    Friend WithEvents RadioOr As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Cmd_Del As System.Windows.Forms.Button
    Friend WithEvents Cmd_Modify As System.Windows.Forms.Button
    Friend WithEvents Menu_Search As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents CKB_AddLast As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Cmd_Clear As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_Reset As System.Windows.Forms.ToolStripButton
    Friend WithEvents PanelMain As System.Windows.Forms.Panel


End Class
