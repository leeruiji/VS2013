<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F21001_Metal_Msg
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F21001_Metal_Msg))
        Me.Tool_Top = New System.Windows.Forms.ToolStrip
        Me.Cmd_Modify = New System.Windows.Forms.ToolStripButton
        Me.Cmd_Enable = New System.Windows.Forms.ToolStripButton
        Me.Cmd_Disable = New System.Windows.Forms.ToolStripButton
        Me.Cmd_Del = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.Cmd_Exit = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.LabelChange = New System.Windows.Forms.ToolStripButton
        Me.PanelMain = New System.Windows.Forms.Panel
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label_State = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.CB_Unit = New System.Windows.Forms.ComboBox
        Me.TB_Qty = New System.Windows.Forms.TextBox
        Me.Btn_ChoseParent = New System.Windows.Forms.Button
        Me.Label24 = New System.Windows.Forms.Label
        Me.TB_Remark = New System.Windows.Forms.TextBox
        Me.TB_Spec = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.TB_ID = New System.Windows.Forms.TextBox
        Me.TB_Name = New System.Windows.Forms.TextBox
        Me.Label_ID = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.TB_GoodsType = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.LB_FullName = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.LB_Contact = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.TB_Price = New System.Windows.Forms.TextBox
        Me.TB_Cost = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.CB_Store = New System.Windows.Forms.ComboBox
        Me.LB_Area = New System.Windows.Forms.Label
        Me.Tool_Top.SuspendLayout()
        Me.PanelMain.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Tool_Top
        '
        Me.Tool_Top.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.Tool_Top.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Cmd_Modify, Me.Cmd_Enable, Me.Cmd_Disable, Me.Cmd_Del, Me.ToolStripSeparator5, Me.Cmd_Exit, Me.ToolStripSeparator1, Me.LabelChange})
        Me.Tool_Top.Location = New System.Drawing.Point(0, 0)
        Me.Tool_Top.MinimumSize = New System.Drawing.Size(0, 40)
        Me.Tool_Top.Name = "Tool_Top"
        Me.Tool_Top.Size = New System.Drawing.Size(658, 40)
        Me.Tool_Top.TabIndex = 10
        Me.Tool_Top.Text = "ToolStrip2"
        '
        'Cmd_Modify
        '
        Me.Cmd_Modify.AccessibleDescription = "修改按钮"
        Me.Cmd_Modify.AccessibleName = ""
        Me.Cmd_Modify.Image = Global.DN210_MetalStore.My.Resources.Resources.Modify
        Me.Cmd_Modify.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Modify.Name = "Cmd_Modify"
        Me.Cmd_Modify.Size = New System.Drawing.Size(57, 37)
        Me.Cmd_Modify.Text = "保存"
        '
        'Cmd_Enable
        '
        Me.Cmd_Enable.Image = Global.DN210_MetalStore.My.Resources.Resources.bt_play
        Me.Cmd_Enable.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Enable.Name = "Cmd_Enable"
        Me.Cmd_Enable.Size = New System.Drawing.Size(57, 37)
        Me.Cmd_Enable.Text = "启用"
        '
        'Cmd_Disable
        '
        Me.Cmd_Disable.Image = Global.DN210_MetalStore.My.Resources.Resources.bt_stop
        Me.Cmd_Disable.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Disable.Name = "Cmd_Disable"
        Me.Cmd_Disable.Size = New System.Drawing.Size(57, 37)
        Me.Cmd_Disable.Text = "禁用"
        '
        'Cmd_Del
        '
        Me.Cmd_Del.AccessibleDescription = "修改按钮"
        Me.Cmd_Del.AccessibleName = ""
        Me.Cmd_Del.Image = Global.DN210_MetalStore.My.Resources.Resources.Delete
        Me.Cmd_Del.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Del.Name = "Cmd_Del"
        Me.Cmd_Del.Size = New System.Drawing.Size(57, 37)
        Me.Cmd_Del.Text = "删除"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 40)
        '
        'Cmd_Exit
        '
        Me.Cmd_Exit.Image = Global.DN210_MetalStore.My.Resources.Resources.Close
        Me.Cmd_Exit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(57, 37)
        Me.Cmd_Exit.Text = "关闭"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 40)
        '
        'LabelChange
        '
        Me.LabelChange.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.LabelChange.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.LabelChange.ForeColor = System.Drawing.Color.Red
        Me.LabelChange.Image = CType(resources.GetObject("LabelChange.Image"), System.Drawing.Image)
        Me.LabelChange.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.LabelChange.Name = "LabelChange"
        Me.LabelChange.Size = New System.Drawing.Size(23, 37)
        Me.LabelChange.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        '
        'PanelMain
        '
        Me.PanelMain.Controls.Add(Me.SplitContainer1)
        Me.PanelMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelMain.Location = New System.Drawing.Point(0, 40)
        Me.PanelMain.Name = "PanelMain"
        Me.PanelMain.Padding = New System.Windows.Forms.Padding(2)
        Me.PanelMain.Size = New System.Drawing.Size(658, 415)
        Me.PanelMain.TabIndex = 0
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainer1.Location = New System.Drawing.Point(2, 2)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox2)
        Me.SplitContainer1.Panel1.Padding = New System.Windows.Forms.Padding(5)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.GroupBox1)
        Me.SplitContainer1.Panel2.Padding = New System.Windows.Forms.Padding(5)
        Me.SplitContainer1.Panel2MinSize = 60
        Me.SplitContainer1.Size = New System.Drawing.Size(654, 411)
        Me.SplitContainer1.SplitterDistance = 340
        Me.SplitContainer1.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label_State)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.CB_Unit)
        Me.GroupBox2.Controls.Add(Me.TB_Qty)
        Me.GroupBox2.Controls.Add(Me.Btn_ChoseParent)
        Me.GroupBox2.Controls.Add(Me.Label24)
        Me.GroupBox2.Controls.Add(Me.TB_Remark)
        Me.GroupBox2.Controls.Add(Me.TB_Spec)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.TB_ID)
        Me.GroupBox2.Controls.Add(Me.TB_Name)
        Me.GroupBox2.Controls.Add(Me.Label_ID)
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Controls.Add(Me.TB_GoodsType)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.LB_FullName)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.LB_Contact)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Location = New System.Drawing.Point(5, 5)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(644, 330)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "物料基础信息"
        '
        'Label_State
        '
        Me.Label_State.AutoSize = True
        Me.Label_State.ForeColor = System.Drawing.Color.Blue
        Me.Label_State.Location = New System.Drawing.Point(114, 123)
        Me.Label_State.Name = "Label_State"
        Me.Label_State.Size = New System.Drawing.Size(35, 14)
        Me.Label_State.TabIndex = 69
        Me.Label_State.Text = "启用"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(52, 123)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 14)
        Me.Label2.TabIndex = 68
        Me.Label2.Text = "状态:"
        '
        'CB_Unit
        '
        Me.CB_Unit.FormattingEnabled = True
        Me.CB_Unit.Items.AddRange(New Object() {"个", "米", "支", "台", "把", "块", "张", "本", "kg", "g"})
        Me.CB_Unit.Location = New System.Drawing.Point(361, 51)
        Me.CB_Unit.Name = "CB_Unit"
        Me.CB_Unit.Size = New System.Drawing.Size(151, 22)
        Me.CB_Unit.TabIndex = 4
        '
        'TB_Qty
        '
        Me.TB_Qty.Location = New System.Drawing.Point(361, 119)
        Me.TB_Qty.Name = "TB_Qty"
        Me.TB_Qty.ReadOnly = True
        Me.TB_Qty.Size = New System.Drawing.Size(152, 23)
        Me.TB_Qty.TabIndex = 7
        '
        'Btn_ChoseParent
        '
        Me.Btn_ChoseParent.Font = New System.Drawing.Font("微软雅黑", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Btn_ChoseParent.Location = New System.Drawing.Point(233, 16)
        Me.Btn_ChoseParent.Name = "Btn_ChoseParent"
        Me.Btn_ChoseParent.Size = New System.Drawing.Size(25, 24)
        Me.Btn_ChoseParent.TabIndex = 18
        Me.Btn_ChoseParent.Text = "..."
        Me.Btn_ChoseParent.UseVisualStyleBackColor = True
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(290, 123)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(70, 14)
        Me.Label24.TabIndex = 67
        Me.Label24.Text = "仓库结存:"
        '
        'TB_Remark
        '
        Me.TB_Remark.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TB_Remark.Location = New System.Drawing.Point(107, 159)
        Me.TB_Remark.Multiline = True
        Me.TB_Remark.Name = "TB_Remark"
        Me.TB_Remark.Size = New System.Drawing.Size(409, 105)
        Me.TB_Remark.TabIndex = 8
        '
        'TB_Spec
        '
        Me.TB_Spec.Location = New System.Drawing.Point(107, 84)
        Me.TB_Spec.Name = "TB_Spec"
        Me.TB_Spec.Size = New System.Drawing.Size(151, 23)
        Me.TB_Spec.TabIndex = 5
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(52, 87)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(49, 14)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "规 格:"
        '
        'TB_ID
        '
        Me.TB_ID.Location = New System.Drawing.Point(361, 16)
        Me.TB_ID.Name = "TB_ID"
        Me.TB_ID.Size = New System.Drawing.Size(151, 23)
        Me.TB_ID.TabIndex = 0
        '
        'TB_Name
        '
        Me.TB_Name.Location = New System.Drawing.Point(107, 50)
        Me.TB_Name.Name = "TB_Name"
        Me.TB_Name.Size = New System.Drawing.Size(151, 23)
        Me.TB_Name.TabIndex = 1
        '
        'Label_ID
        '
        Me.Label_ID.AutoSize = True
        Me.Label_ID.ForeColor = System.Drawing.Color.Blue
        Me.Label_ID.Location = New System.Drawing.Point(285, 19)
        Me.Label_ID.Name = "Label_ID"
        Me.Label_ID.Size = New System.Drawing.Size(70, 14)
        Me.Label_ID.TabIndex = 7
        Me.Label_ID.Text = "物料编号:"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(59, 162)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(42, 14)
        Me.Label19.TabIndex = 6
        Me.Label19.Text = "备注:"
        '
        'TB_GoodsType
        '
        Me.TB_GoodsType.Location = New System.Drawing.Point(107, 17)
        Me.TB_GoodsType.Name = "TB_GoodsType"
        Me.TB_GoodsType.ReadOnly = True
        Me.TB_GoodsType.Size = New System.Drawing.Size(138, 23)
        Me.TB_GoodsType.TabIndex = 13
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(30, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 14)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "物料分类:"
        '
        'LB_FullName
        '
        Me.LB_FullName.AutoSize = True
        Me.LB_FullName.Location = New System.Drawing.Point(30, 52)
        Me.LB_FullName.Name = "LB_FullName"
        Me.LB_FullName.Size = New System.Drawing.Size(70, 14)
        Me.LB_FullName.TabIndex = 5
        Me.LB_FullName.Text = "物料名称:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(188, 132)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(0, 14)
        Me.Label15.TabIndex = 9
        '
        'LB_Contact
        '
        Me.LB_Contact.AutoSize = True
        Me.LB_Contact.Location = New System.Drawing.Point(306, 54)
        Me.LB_Contact.Name = "LB_Contact"
        Me.LB_Contact.Size = New System.Drawing.Size(49, 14)
        Me.LB_Contact.TabIndex = 4
        Me.LB_Contact.Text = "单 位:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(188, 131)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(0, 14)
        Me.Label9.TabIndex = 9
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TB_Price)
        Me.GroupBox1.Controls.Add(Me.TB_Cost)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(5, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(644, 57)
        Me.GroupBox1.TabIndex = 69
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "物料单价"
        '
        'TB_Price
        '
        Me.TB_Price.Location = New System.Drawing.Point(365, 22)
        Me.TB_Price.Name = "TB_Price"
        Me.TB_Price.Size = New System.Drawing.Size(151, 23)
        Me.TB_Price.TabIndex = 0
        '
        'TB_Cost
        '
        Me.TB_Cost.Location = New System.Drawing.Point(107, 22)
        Me.TB_Cost.Name = "TB_Cost"
        Me.TB_Cost.ReadOnly = True
        Me.TB_Cost.Size = New System.Drawing.Size(152, 23)
        Me.TB_Cost.TabIndex = 64
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(35, 25)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(70, 14)
        Me.Label7.TabIndex = 68
        Me.Label7.Text = "平均成本:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(296, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 14)
        Me.Label4.TabIndex = 66
        Me.Label4.Text = "参考单价:"
        '
        'CB_Store
        '
        Me.CB_Store.FormattingEnabled = True
        Me.CB_Store.Location = New System.Drawing.Point(341, 30)
        Me.CB_Store.Name = "CB_Store"
        Me.CB_Store.Size = New System.Drawing.Size(150, 22)
        Me.CB_Store.TabIndex = 16
        Me.CB_Store.Visible = False
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
        'F21001_Metal_Msg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.PanelMain)
        Me.Controls.Add(Me.CB_Store)
        Me.Controls.Add(Me.Tool_Top)
        Me.Controls.Add(Me.LB_Area)
        Me.Name = "F21001_Metal_Msg"
        Me.Size = New System.Drawing.Size(658, 455)
        Me.Title = "五金物料详细信息"
        Me.Tool_Top.ResumeLayout(False)
        Me.Tool_Top.PerformLayout()
        Me.PanelMain.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Tool_Top As System.Windows.Forms.ToolStrip
    Friend WithEvents Cmd_Modify As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_Del As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Cmd_Exit As System.Windows.Forms.ToolStripButton
    Friend WithEvents PanelMain As System.Windows.Forms.Panel
    Friend WithEvents LB_Area As System.Windows.Forms.Label
    Friend WithEvents CB_Store As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TB_Price As System.Windows.Forms.TextBox
    Friend WithEvents TB_Cost As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Cmd_Disable As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_Enable As System.Windows.Forms.ToolStripButton

    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents LabelChange As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label_State As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CB_Unit As System.Windows.Forms.ComboBox
    Friend WithEvents TB_Qty As System.Windows.Forms.TextBox
    Friend WithEvents Btn_ChoseParent As System.Windows.Forms.Button
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents TB_Remark As System.Windows.Forms.TextBox
    Friend WithEvents TB_Spec As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TB_ID As System.Windows.Forms.TextBox
    Friend WithEvents TB_Name As System.Windows.Forms.TextBox
    Friend WithEvents Label_ID As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents TB_GoodsType As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LB_FullName As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents LB_Contact As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label

End Class
