<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SearchCol
    Inherits System.Windows.Forms.UserControl

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
        Me.SC_Condition = New System.Windows.Forms.SplitContainer
        Me.CB_ConditionName = New System.Windows.Forms.ComboBox
        Me.SC_Between = New System.Windows.Forms.SplitContainer
        Me.TB_Value1 = New System.Windows.Forms.TextBox
        Me.TB_Value2 = New System.Windows.Forms.TextBox
        Me.CB_ConditionValue = New System.Windows.Forms.ComboBox
        Me.TB_Value = New System.Windows.Forms.TextBox
        Me.RadioAnd = New System.Windows.Forms.RadioButton
        Me.RadioOr = New System.Windows.Forms.RadioButton
        Me.CB_Operator = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Cmd_OK = New System.Windows.Forms.Button
        Me.Cmd_Cancel = New System.Windows.Forms.Button
        Me.Cmd_Del = New System.Windows.Forms.Button
        Me.CK_PreView = New System.Windows.Forms.CheckBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.CK_IgnoreTime = New System.Windows.Forms.CheckBox
        Me.CK_SaveValue = New System.Windows.Forms.CheckBox
        Me.Cmd_Add = New System.Windows.Forms.Button
        Me.SC_Condition.Panel1.SuspendLayout()
        Me.SC_Condition.Panel2.SuspendLayout()
        Me.SC_Condition.SuspendLayout()
        Me.SC_Between.Panel1.SuspendLayout()
        Me.SC_Between.Panel2.SuspendLayout()
        Me.SC_Between.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SC_Condition
        '
        Me.SC_Condition.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SC_Condition.Location = New System.Drawing.Point(4, 14)
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
        Me.SC_Condition.Size = New System.Drawing.Size(407, 27)
        Me.SC_Condition.SplitterDistance = 133
        Me.SC_Condition.SplitterWidth = 5
        Me.SC_Condition.TabIndex = 1
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
        Me.CB_ConditionName.Size = New System.Drawing.Size(133, 22)
        Me.CB_ConditionName.TabIndex = 0
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
        Me.SC_Between.Size = New System.Drawing.Size(269, 27)
        Me.SC_Between.SplitterDistance = 128
        Me.SC_Between.TabIndex = 2
        Me.SC_Between.Visible = False
        '
        'TB_Value1
        '
        Me.TB_Value1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TB_Value1.Location = New System.Drawing.Point(0, 0)
        Me.TB_Value1.Name = "TB_Value1"
        Me.TB_Value1.Size = New System.Drawing.Size(128, 23)
        Me.TB_Value1.TabIndex = 0
        '
        'TB_Value2
        '
        Me.TB_Value2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TB_Value2.Location = New System.Drawing.Point(0, 0)
        Me.TB_Value2.Name = "TB_Value2"
        Me.TB_Value2.Size = New System.Drawing.Size(137, 23)
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
        Me.CB_ConditionValue.Size = New System.Drawing.Size(269, 22)
        Me.CB_ConditionValue.TabIndex = 0
        Me.CB_ConditionValue.ValueMember = "ConditionValue"
        Me.CB_ConditionValue.Visible = False
        '
        'TB_Value
        '
        Me.TB_Value.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TB_Value.Location = New System.Drawing.Point(0, 0)
        Me.TB_Value.Name = "TB_Value"
        Me.TB_Value.Size = New System.Drawing.Size(269, 23)
        Me.TB_Value.TabIndex = 1
        '
        'RadioAnd
        '
        Me.RadioAnd.AutoSize = True
        Me.RadioAnd.Checked = True
        Me.RadioAnd.Location = New System.Drawing.Point(6, 22)
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
        Me.RadioOr.Location = New System.Drawing.Point(6, 46)
        Me.RadioOr.Name = "RadioOr"
        Me.RadioOr.Size = New System.Drawing.Size(74, 18)
        Me.RadioOr.TabIndex = 3
        Me.RadioOr.Text = "或者(&O)"
        Me.RadioOr.UseVisualStyleBackColor = True
        '
        'CB_Operator
        '
        Me.CB_Operator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_Operator.FormattingEnabled = True
        Me.CB_Operator.Location = New System.Drawing.Point(274, 50)
        Me.CB_Operator.Name = "CB_Operator"
        Me.CB_Operator.Size = New System.Drawing.Size(137, 22)
        Me.CB_Operator.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(214, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 14)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "操作符:"
        '
        'Cmd_OK
        '
        Me.Cmd_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cmd_OK.Location = New System.Drawing.Point(254, 143)
        Me.Cmd_OK.Name = "Cmd_OK"
        Me.Cmd_OK.Size = New System.Drawing.Size(76, 37)
        Me.Cmd_OK.TabIndex = 6
        Me.Cmd_OK.Text = "确认"
        Me.Cmd_OK.UseVisualStyleBackColor = True
        '
        'Cmd_Cancel
        '
        Me.Cmd_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cmd_Cancel.Location = New System.Drawing.Point(336, 143)
        Me.Cmd_Cancel.Name = "Cmd_Cancel"
        Me.Cmd_Cancel.Size = New System.Drawing.Size(75, 37)
        Me.Cmd_Cancel.TabIndex = 7
        Me.Cmd_Cancel.Text = "取消"
        Me.Cmd_Cancel.UseVisualStyleBackColor = True
        '
        'Cmd_Del
        '
        Me.Cmd_Del.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cmd_Del.Location = New System.Drawing.Point(77, 143)
        Me.Cmd_Del.Name = "Cmd_Del"
        Me.Cmd_Del.Size = New System.Drawing.Size(76, 37)
        Me.Cmd_Del.TabIndex = 8
        Me.Cmd_Del.Text = "删除"
        Me.Cmd_Del.UseVisualStyleBackColor = True
        '
        'CK_PreView
        '
        Me.CK_PreView.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CK_PreView.AutoSize = True
        Me.CK_PreView.Location = New System.Drawing.Point(274, 78)
        Me.CK_PreView.Name = "CK_PreView"
        Me.CK_PreView.Size = New System.Drawing.Size(96, 18)
        Me.CK_PreView.TabIndex = 9
        Me.CK_PreView.Text = "列出可选值"
        Me.CK_PreView.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RadioOr)
        Me.GroupBox1.Controls.Add(Me.RadioAnd)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 50)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(133, 65)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "和其他条件的关系"
        '
        'CK_IgnoreTime
        '
        Me.CK_IgnoreTime.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CK_IgnoreTime.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CK_IgnoreTime.Location = New System.Drawing.Point(274, 104)
        Me.CK_IgnoreTime.Name = "CK_IgnoreTime"
        Me.CK_IgnoreTime.Size = New System.Drawing.Size(124, 33)
        Me.CK_IgnoreTime.TabIndex = 11
        Me.CK_IgnoreTime.Text = "当本条件生效时忽略时间搜索"
        Me.CK_IgnoreTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CK_IgnoreTime.UseVisualStyleBackColor = True
        '
        'CK_SaveValue
        '
        Me.CK_SaveValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CK_SaveValue.AutoSize = True
        Me.CK_SaveValue.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CK_SaveValue.Location = New System.Drawing.Point(4, 120)
        Me.CK_SaveValue.Name = "CK_SaveValue"
        Me.CK_SaveValue.Size = New System.Drawing.Size(110, 18)
        Me.CK_SaveValue.TabIndex = 13
        Me.CK_SaveValue.Text = "保存搜索内容"
        Me.CK_SaveValue.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CK_SaveValue.UseVisualStyleBackColor = True
        '
        'Cmd_Add
        '
        Me.Cmd_Add.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cmd_Add.Location = New System.Drawing.Point(159, 143)
        Me.Cmd_Add.Name = "Cmd_Add"
        Me.Cmd_Add.Size = New System.Drawing.Size(89, 37)
        Me.Cmd_Add.TabIndex = 8
        Me.Cmd_Add.Text = "确定并新增"
        Me.Cmd_Add.UseVisualStyleBackColor = True
        '
        'SearchCol
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.CK_SaveValue)
        Me.Controls.Add(Me.CK_IgnoreTime)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Cmd_Add)
        Me.Controls.Add(Me.Cmd_Del)
        Me.Controls.Add(Me.CK_PreView)
        Me.Controls.Add(Me.Cmd_Cancel)
        Me.Controls.Add(Me.Cmd_OK)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CB_Operator)
        Me.Controls.Add(Me.SC_Condition)
        Me.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.Margin = New System.Windows.Forms.Padding(4, 10, 4, 10)
        Me.MinimumSize = New System.Drawing.Size(347, 70)
        Me.Name = "SearchCol"
        Me.Size = New System.Drawing.Size(416, 186)
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
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SC_Condition As System.Windows.Forms.SplitContainer
    Friend WithEvents CB_ConditionName As System.Windows.Forms.ComboBox
    Friend WithEvents CB_ConditionValue As System.Windows.Forms.ComboBox
    Friend WithEvents RadioAnd As System.Windows.Forms.RadioButton
    Friend WithEvents RadioOr As System.Windows.Forms.RadioButton
    Friend WithEvents CB_Operator As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Cmd_OK As System.Windows.Forms.Button
    Friend WithEvents Cmd_Cancel As System.Windows.Forms.Button
    Friend WithEvents Cmd_Del As System.Windows.Forms.Button
    Friend WithEvents CK_PreView As System.Windows.Forms.CheckBox
    Friend WithEvents TB_Value As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents SC_Between As System.Windows.Forms.SplitContainer
    Friend WithEvents TB_Value1 As System.Windows.Forms.TextBox
    Friend WithEvents TB_Value2 As System.Windows.Forms.TextBox
    Friend WithEvents CK_IgnoreTime As System.Windows.Forms.CheckBox
    Friend WithEvents CK_SaveValue As System.Windows.Forms.CheckBox
    Friend WithEvents Cmd_Add As System.Windows.Forms.Button

End Class
