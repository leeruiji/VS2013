<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F20930_Store_Detail
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F20930_Store_Detail))
        Me.PanelMain = New System.Windows.Forms.Panel
        Me.GR = New AxgrproLib.AxGRDisplayViewer
        Me.DP_End = New System.Windows.Forms.DateTimePicker
        Me.DP_Start = New System.Windows.Forms.DateTimePicker
        Me.Tool_Search = New System.Windows.Forms.ToolStrip
        Me.ToolStripLabel4 = New System.Windows.Forms.ToolStripLabel
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel
        Me.Cmd_ChooseType = New System.Windows.Forms.ToolStripButton
        Me.Cmd_ChooseWL = New System.Windows.Forms.ToolStripButton
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel
        Me.CB_ConditionName1 = New System.Windows.Forms.ToolStripComboBox
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel
        Me.CB_ConditionName2 = New System.Windows.Forms.ToolStripComboBox
        Me.Cb_ConditionValue2 = New System.Windows.Forms.ToolStripComboBox
        Me.TMI_aEnable = New System.Windows.Forms.ToolStripDropDownButton
        Me.TMI_All = New System.Windows.Forms.ToolStripMenuItem
        Me.TMI_Enable = New System.Windows.Forms.ToolStripMenuItem
        Me.TMI_Disble = New System.Windows.Forms.ToolStripMenuItem
        Me.Btn_Search = New System.Windows.Forms.ToolStripButton
        Me.Cmd_Preview = New System.Windows.Forms.ToolStripButton
        Me.Cmd_Exit = New System.Windows.Forms.ToolStripButton
        Me.PanelMain.SuspendLayout()
        CType(Me.GR, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tool_Search.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelMain
        '
        Me.PanelMain.Controls.Add(Me.GR)
        Me.PanelMain.Controls.Add(Me.DP_End)
        Me.PanelMain.Controls.Add(Me.DP_Start)
        Me.PanelMain.Controls.Add(Me.Tool_Search)
        Me.PanelMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelMain.Location = New System.Drawing.Point(0, 0)
        Me.PanelMain.Name = "PanelMain"
        Me.PanelMain.Padding = New System.Windows.Forms.Padding(2)
        Me.PanelMain.Size = New System.Drawing.Size(1000, 618)
        Me.PanelMain.TabIndex = 0
        '
        'GR
        '
        Me.GR.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GR.Enabled = True
        Me.GR.Location = New System.Drawing.Point(2, 34)
        Me.GR.Name = "GR"
        Me.GR.OcxState = CType(resources.GetObject("GR.OcxState"), System.Windows.Forms.AxHost.State)
        Me.GR.Size = New System.Drawing.Size(996, 582)
        Me.GR.TabIndex = 17
        '
        'DP_End
        '
        Me.DP_End.CustomFormat = "yyyy-MM-dd"
        Me.DP_End.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DP_End.Location = New System.Drawing.Point(137, 5)
        Me.DP_End.Name = "DP_End"
        Me.DP_End.Size = New System.Drawing.Size(94, 23)
        Me.DP_End.TabIndex = 16
        '
        'DP_Start
        '
        Me.DP_Start.CustomFormat = "yyyy-MM-dd"
        Me.DP_Start.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DP_Start.Location = New System.Drawing.Point(27, 5)
        Me.DP_Start.Name = "DP_Start"
        Me.DP_Start.Size = New System.Drawing.Size(94, 23)
        Me.DP_Start.TabIndex = 15
        '
        'Tool_Search
        '
        Me.Tool_Search.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.Tool_Search.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel4, Me.ToolStripLabel3, Me.Cmd_ChooseType, Me.Cmd_ChooseWL, Me.ToolStripLabel2, Me.CB_ConditionName1, Me.ToolStripLabel1, Me.CB_ConditionName2, Me.Cb_ConditionValue2, Me.TMI_aEnable, Me.Btn_Search, Me.Cmd_Preview, Me.Cmd_Exit})
        Me.Tool_Search.Location = New System.Drawing.Point(2, 2)
        Me.Tool_Search.MinimumSize = New System.Drawing.Size(0, 32)
        Me.Tool_Search.Name = "Tool_Search"
        Me.Tool_Search.Size = New System.Drawing.Size(996, 32)
        Me.Tool_Search.TabIndex = 14
        Me.Tool_Search.Text = "ToolStrip1"
        '
        'ToolStripLabel4
        '
        Me.ToolStripLabel4.Name = "ToolStripLabel4"
        Me.ToolStripLabel4.Size = New System.Drawing.Size(17, 29)
        Me.ToolStripLabel4.Text = "从"
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.Margin = New System.Windows.Forms.Padding(95, 1, 95, 2)
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(17, 29)
        Me.ToolStripLabel3.Text = "到"
        '
        'Cmd_ChooseType
        '
        Me.Cmd_ChooseType.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.Cmd_ChooseType.ForeColor = System.Drawing.Color.Blue
        Me.Cmd_ChooseType.Image = CType(resources.GetObject("Cmd_ChooseType.Image"), System.Drawing.Image)
        Me.Cmd_ChooseType.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_ChooseType.Margin = New System.Windows.Forms.Padding(0, 1, 5, 2)
        Me.Cmd_ChooseType.Name = "Cmd_ChooseType"
        Me.Cmd_ChooseType.Size = New System.Drawing.Size(57, 29)
        Me.Cmd_ChooseType.Text = "选择分类"
        Me.Cmd_ChooseType.ToolTipText = "左键选择分类,右键删除分类"
        '
        'Cmd_ChooseWL
        '
        Me.Cmd_ChooseWL.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.Cmd_ChooseWL.ForeColor = System.Drawing.Color.Blue
        Me.Cmd_ChooseWL.Image = CType(resources.GetObject("Cmd_ChooseWL.Image"), System.Drawing.Image)
        Me.Cmd_ChooseWL.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_ChooseWL.Margin = New System.Windows.Forms.Padding(0, 1, 5, 2)
        Me.Cmd_ChooseWL.Name = "Cmd_ChooseWL"
        Me.Cmd_ChooseWL.Size = New System.Drawing.Size(57, 29)
        Me.Cmd_ChooseWL.Text = "选择商品"
        Me.Cmd_ChooseWL.ToolTipText = "左键选择商品,右键取消商品"
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(47, 29)
        Me.ToolStripLabel2.Text = "条件1："
        Me.ToolStripLabel2.Visible = False
        '
        'CB_ConditionName1
        '
        Me.CB_ConditionName1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CB_ConditionName1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_ConditionName1.Name = "CB_ConditionName1"
        Me.CB_ConditionName1.Size = New System.Drawing.Size(100, 32)
        Me.CB_ConditionName1.Visible = False
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(47, 29)
        Me.ToolStripLabel1.Text = "条件2："
        Me.ToolStripLabel1.Visible = False
        '
        'CB_ConditionName2
        '
        Me.CB_ConditionName2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CB_ConditionName2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_ConditionName2.Name = "CB_ConditionName2"
        Me.CB_ConditionName2.Size = New System.Drawing.Size(85, 32)
        '
        'Cb_ConditionValue2
        '
        Me.Cb_ConditionValue2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Cb_ConditionValue2.Name = "Cb_ConditionValue2"
        Me.Cb_ConditionValue2.Size = New System.Drawing.Size(100, 32)
        '
        'TMI_aEnable
        '
        Me.TMI_aEnable.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.TMI_aEnable.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TMI_All, Me.TMI_Enable, Me.TMI_Disble})
        Me.TMI_aEnable.ForeColor = System.Drawing.Color.Blue
        Me.TMI_aEnable.Image = CType(resources.GetObject("TMI_aEnable.Image"), System.Drawing.Image)
        Me.TMI_aEnable.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TMI_aEnable.Name = "TMI_aEnable"
        Me.TMI_aEnable.Size = New System.Drawing.Size(78, 29)
        Me.TMI_aEnable.Tag = "0"
        Me.TMI_aEnable.Text = "不显示禁用"
        '
        'TMI_All
        '
        Me.TMI_All.Name = "TMI_All"
        Me.TMI_All.Size = New System.Drawing.Size(130, 22)
        Me.TMI_All.Tag = "2"
        Me.TMI_All.Text = "全部"
        '
        'TMI_Enable
        '
        Me.TMI_Enable.Name = "TMI_Enable"
        Me.TMI_Enable.Size = New System.Drawing.Size(130, 22)
        Me.TMI_Enable.Tag = "0"
        Me.TMI_Enable.Text = "不显示禁用"
        '
        'TMI_Disble
        '
        Me.TMI_Disble.Name = "TMI_Disble"
        Me.TMI_Disble.Size = New System.Drawing.Size(130, 22)
        Me.TMI_Disble.Tag = "1"
        Me.TMI_Disble.Text = "只显示禁用"
        '
        'Btn_Search
        '
        Me.Btn_Search.Image = CType(resources.GetObject("Btn_Search.Image"), System.Drawing.Image)
        Me.Btn_Search.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.Btn_Search.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Btn_Search.Name = "Btn_Search"
        Me.Btn_Search.Size = New System.Drawing.Size(65, 29)
        Me.Btn_Search.Text = "搜索"
        '
        'Cmd_Preview
        '
        Me.Cmd_Preview.Image = Global.DN200_Purchase.My.Resources.Resources.Print_preview
        Me.Cmd_Preview.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Preview.Name = "Cmd_Preview"
        Me.Cmd_Preview.Size = New System.Drawing.Size(57, 29)
        Me.Cmd_Preview.Text = "预览"
        '
        'Cmd_Exit
        '
        Me.Cmd_Exit.Image = Global.DN200_Purchase.My.Resources.Resources.Close
        Me.Cmd_Exit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(57, 29)
        Me.Cmd_Exit.Text = "关闭"
        '
        'F20930_Store_Detail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CanMaxSize = True
        Me.Controls.Add(Me.PanelMain)
        Me.ForeColor = System.Drawing.Color.Black
        Me.Name = "F20930_Store_Detail"
        Me.Size = New System.Drawing.Size(1000, 618)
        Me.PanelMain.ResumeLayout(False)
        Me.PanelMain.PerformLayout()
        CType(Me.GR, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tool_Search.ResumeLayout(False)
        Me.Tool_Search.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelMain As System.Windows.Forms.Panel
    Friend WithEvents Tool_Search As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel4 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabel3 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents CB_ConditionName1 As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents Btn_Search As System.Windows.Forms.ToolStripButton
    Friend WithEvents DP_Start As System.Windows.Forms.DateTimePicker
    Friend WithEvents DP_End As System.Windows.Forms.DateTimePicker
    Friend WithEvents GR As AxgrproLib.AxGRDisplayViewer
    Friend WithEvents Cmd_ChooseType As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_Preview As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_Exit As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_ChooseWL As System.Windows.Forms.ToolStripButton
    Friend WithEvents CB_ConditionName2 As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents Cb_ConditionValue2 As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents TMI_aEnable As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents TMI_All As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TMI_Enable As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TMI_Disble As System.Windows.Forms.ToolStripMenuItem

End Class
