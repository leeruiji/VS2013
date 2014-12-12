<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F20920_Chaoliao_gather
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F20920_Chaoliao_gather))
        Me.PanelMain = New System.Windows.Forms.Panel
        Me.GR = New AxgrproLib.AxGRDisplayViewer
        Me.Tool_Search = New System.Windows.Forms.ToolStrip
        Me.CK_Date = New System.Windows.Forms.ToolStripButton
        Me.Label_C = New System.Windows.Forms.ToolStripLabel
        Me.DP_Start = New PClass.ToolStripDateTimePicker
        Me.Label_D = New System.Windows.Forms.ToolStripLabel
        Me.DP_End = New PClass.ToolStripDateTimePicker
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel
        Me.CB_Times = New System.Windows.Forms.ToolStripComboBox
        Me.CK_HaveRL = New System.Windows.Forms.ToolStripButton
        Me.CK_Check30 = New System.Windows.Forms.ToolStripButton
        Me.LReaSon = New System.Windows.Forms.ToolStripLabel
        Me.CB_Reason = New System.Windows.Forms.ToolStripComboBox
        Me.Cmd_Preview = New System.Windows.Forms.ToolStripButton
        Me.Btn_Search = New System.Windows.Forms.ToolStripButton
        Me.Cmd_Remark = New System.Windows.Forms.ToolStripButton
        Me.Cmd_Exit = New System.Windows.Forms.ToolStripButton
        Me.PanelMain.SuspendLayout()
        CType(Me.GR, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tool_Search.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelMain
        '
        Me.PanelMain.Controls.Add(Me.GR)
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
        'Tool_Search
        '
        Me.Tool_Search.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.Tool_Search.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CK_Date, Me.Label_C, Me.DP_Start, Me.Label_D, Me.DP_End, Me.ToolStripLabel1, Me.CB_Times, Me.CK_HaveRL, Me.CK_Check30, Me.LReaSon, Me.CB_Reason, Me.Cmd_Preview, Me.Btn_Search, Me.Cmd_Remark, Me.Cmd_Exit})
        Me.Tool_Search.Location = New System.Drawing.Point(2, 2)
        Me.Tool_Search.MinimumSize = New System.Drawing.Size(0, 32)
        Me.Tool_Search.Name = "Tool_Search"
        Me.Tool_Search.Size = New System.Drawing.Size(996, 32)
        Me.Tool_Search.TabIndex = 14
        Me.Tool_Search.Text = "ToolStrip1"
        '
        'CK_Date
        '
        Me.CK_Date.Checked = True
        Me.CK_Date.CheckOnClick = True
        Me.CK_Date.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CK_Date.Image = Global.DN200_Purchase.My.Resources.Resources._181
        Me.CK_Date.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CK_Date.Name = "CK_Date"
        Me.CK_Date.Size = New System.Drawing.Size(81, 29)
        Me.CK_Date.Text = "按日查询"
        '
        'Label_C
        '
        Me.Label_C.Name = "Label_C"
        Me.Label_C.Size = New System.Drawing.Size(17, 29)
        Me.Label_C.Text = "从"
        '
        'DP_Start
        '
        Me.DP_Start.Name = "DP_Start"
        Me.DP_Start.Size = New System.Drawing.Size(100, 29)
        Me.DP_Start.Text = "2012-07-05"
        Me.DP_Start.Value = New Date(2012, 7, 5, 0, 0, 0, 0)
        '
        'Label_D
        '
        Me.Label_D.Name = "Label_D"
        Me.Label_D.Size = New System.Drawing.Size(17, 29)
        Me.Label_D.Text = "到"
        '
        'DP_End
        '
        Me.DP_End.Name = "DP_End"
        Me.DP_End.Size = New System.Drawing.Size(100, 29)
        Me.DP_End.Text = "2012-07-05"
        Me.DP_End.Value = New Date(2012, 7, 5, 0, 0, 0, 0)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(59, 29)
        Me.ToolStripLabel1.Text = "加料超过:"
        '
        'CB_Times
        '
        Me.CB_Times.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9"})
        Me.CB_Times.Name = "CB_Times"
        Me.CB_Times.Size = New System.Drawing.Size(75, 32)
        Me.CB_Times.Text = "3"
        '
        'CK_HaveRL
        '
        Me.CK_HaveRL.CheckOnClick = True
        Me.CK_HaveRL.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.CK_HaveRL.Image = CType(resources.GetObject("CK_HaveRL.Image"), System.Drawing.Image)
        Me.CK_HaveRL.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CK_HaveRL.Name = "CK_HaveRL"
        Me.CK_HaveRL.Size = New System.Drawing.Size(57, 29)
        Me.CK_HaveRL.Text = "包含染料"
        Me.CK_HaveRL.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay
        '
        'CK_Check30
        '
        Me.CK_Check30.Checked = True
        Me.CK_Check30.CheckOnClick = True
        Me.CK_Check30.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CK_Check30.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.CK_Check30.Image = CType(resources.GetObject("CK_Check30.Image"), System.Drawing.Image)
        Me.CK_Check30.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CK_Check30.Name = "CK_Check30"
        Me.CK_Check30.Size = New System.Drawing.Size(75, 29)
        Me.CK_Check30.Text = "或者超料30%"
        Me.CK_Check30.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay
        '
        'LReaSon
        '
        Me.LReaSon.Name = "LReaSon"
        Me.LReaSon.Size = New System.Drawing.Size(65, 29)
        Me.LReaSon.Text = "领料类型："
        '
        'CB_Reason
        '
        Me.CB_Reason.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_Reason.Items.AddRange(New Object() {"全部", "定型领料", "染部领料"})
        Me.CB_Reason.Name = "CB_Reason"
        Me.CB_Reason.Size = New System.Drawing.Size(80, 32)
        '
        'Cmd_Preview
        '
        Me.Cmd_Preview.Image = Global.DN200_Purchase.My.Resources.Resources.Print_preview
        Me.Cmd_Preview.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Preview.Name = "Cmd_Preview"
        Me.Cmd_Preview.Size = New System.Drawing.Size(57, 29)
        Me.Cmd_Preview.Text = "预览"
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
        'Cmd_Remark
        '
        Me.Cmd_Remark.Image = Global.DN200_Purchase.My.Resources.Resources.file_apply
        Me.Cmd_Remark.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Remark.Name = "Cmd_Remark"
        Me.Cmd_Remark.Size = New System.Drawing.Size(81, 29)
        Me.Cmd_Remark.Text = "修改备注"
        '
        'Cmd_Exit
        '
        Me.Cmd_Exit.Image = Global.DN200_Purchase.My.Resources.Resources.Close
        Me.Cmd_Exit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(57, 28)
        Me.Cmd_Exit.Text = "关闭"
        '
        'F20920_Chaoliao_gather
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CanMaxSize = True
        Me.Controls.Add(Me.PanelMain)
        Me.ForeColor = System.Drawing.Color.Black
        Me.Name = "F20920_Chaoliao_gather"
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
    Friend WithEvents Label_C As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Label_D As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Btn_Search As System.Windows.Forms.ToolStripButton
    Friend WithEvents GR As AxgrproLib.AxGRDisplayViewer
    Friend WithEvents Cmd_Exit As System.Windows.Forms.ToolStripButton
    Friend WithEvents CK_Date As System.Windows.Forms.ToolStripButton
    Friend WithEvents DP_Start As PClass.ToolStripDateTimePicker
    Friend WithEvents DP_End As PClass.ToolStripDateTimePicker
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents CB_Times As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents CK_Check30 As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_Preview As System.Windows.Forms.ToolStripButton
    Friend WithEvents CK_HaveRL As System.Windows.Forms.ToolStripButton
    Friend WithEvents LReaSon As System.Windows.Forms.ToolStripLabel
    Friend WithEvents CB_Reason As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents Cmd_Remark As System.Windows.Forms.ToolStripButton

End Class
