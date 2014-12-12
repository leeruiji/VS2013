<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F99010_Report
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F99010_Report))
        Me.Tool_Top = New System.Windows.Forms.ToolStrip
        Me.Cmd_Add = New System.Windows.Forms.ToolStripButton
        Me.Cmd_Modify = New System.Windows.Forms.ToolStripButton
        Me.Cmd_Del = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.Cmd_ReFresh = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.Cmd_PreView = New System.Windows.Forms.ToolStripButton
        Me.Cmd_FileOut = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.Cmd_ExportXml = New System.Windows.Forms.ToolStripButton
        Me.Cmd_InputXml = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.Cmd_Exit = New System.Windows.Forms.ToolStripButton
        Me.FG1 = New PClass.FG
        Me.PanelMain = New System.Windows.Forms.Panel
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.GroupBox_Xml = New System.Windows.Forms.GroupBox
        Me.Fg2 = New PClass.FG
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.Cmd_Change = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.Cmd_Hide = New System.Windows.Forms.ToolStripButton
        Me.Panel_Xml = New System.Windows.Forms.Panel
        Me.LabelMsg = New System.Windows.Forms.Label
        Me.Tool_Top.SuspendLayout()
        CType(Me.FG1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelMain.SuspendLayout()
        Me.GroupBox_Xml.SuspendLayout()
        CType(Me.Fg2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.Panel_Xml.SuspendLayout()
        Me.SuspendLayout()
        '
        'Tool_Top
        '
        Me.Tool_Top.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.Tool_Top.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Cmd_Add, Me.Cmd_Modify, Me.Cmd_Del, Me.ToolStripSeparator2, Me.Cmd_ReFresh, Me.ToolStripSeparator5, Me.Cmd_PreView, Me.Cmd_FileOut, Me.ToolStripSeparator3, Me.Cmd_ExportXml, Me.Cmd_InputXml, Me.ToolStripSeparator1, Me.Cmd_Exit})
        Me.Tool_Top.Location = New System.Drawing.Point(2, 2)
        Me.Tool_Top.MinimumSize = New System.Drawing.Size(0, 40)
        Me.Tool_Top.Name = "Tool_Top"
        Me.Tool_Top.Size = New System.Drawing.Size(1018, 40)
        Me.Tool_Top.TabIndex = 10
        Me.Tool_Top.Text = "ToolStrip2"
        '
        'Cmd_Add
        '
        Me.Cmd_Add.AccessibleDescription = ""
        Me.Cmd_Add.AccessibleName = ""
        Me.Cmd_Add.Image = Global.DN990_BaseSetting.My.Resources.Resources.ADD
        Me.Cmd_Add.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Add.Name = "Cmd_Add"
        Me.Cmd_Add.Size = New System.Drawing.Size(57, 37)
        Me.Cmd_Add.Text = "添加"
        '
        'Cmd_Modify
        '
        Me.Cmd_Modify.AccessibleDescription = ""
        Me.Cmd_Modify.AccessibleName = ""
        Me.Cmd_Modify.Image = Global.DN990_BaseSetting.My.Resources.Resources.Modify
        Me.Cmd_Modify.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Modify.Name = "Cmd_Modify"
        Me.Cmd_Modify.Size = New System.Drawing.Size(57, 37)
        Me.Cmd_Modify.Text = "修改"
        '
        'Cmd_Del
        '
        Me.Cmd_Del.AccessibleDescription = ""
        Me.Cmd_Del.AccessibleName = ""
        Me.Cmd_Del.Image = Global.DN990_BaseSetting.My.Resources.Resources.Delete
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
        'Cmd_ReFresh
        '
        Me.Cmd_ReFresh.AccessibleDescription = ""
        Me.Cmd_ReFresh.AccessibleName = ""
        Me.Cmd_ReFresh.Image = Global.DN990_BaseSetting.My.Resources.Resources.ReFresh
        Me.Cmd_ReFresh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_ReFresh.Name = "Cmd_ReFresh"
        Me.Cmd_ReFresh.Size = New System.Drawing.Size(57, 37)
        Me.Cmd_ReFresh.Text = "刷新"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 40)
        '
        'Cmd_PreView
        '
        Me.Cmd_PreView.AccessibleDescription = ""
        Me.Cmd_PreView.AccessibleName = ""
        Me.Cmd_PreView.Image = Global.DN990_BaseSetting.My.Resources.Resources.Print_preview
        Me.Cmd_PreView.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_PreView.Name = "Cmd_PreView"
        Me.Cmd_PreView.Size = New System.Drawing.Size(57, 37)
        Me.Cmd_PreView.Text = "预览"
        '
        'Cmd_FileOut
        '
        Me.Cmd_FileOut.AccessibleDescription = ""
        Me.Cmd_FileOut.AccessibleName = ""
        Me.Cmd_FileOut.Image = Global.DN990_BaseSetting.My.Resources.Resources.FileOut
        Me.Cmd_FileOut.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_FileOut.Name = "Cmd_FileOut"
        Me.Cmd_FileOut.Size = New System.Drawing.Size(57, 37)
        Me.Cmd_FileOut.Text = "导出"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 40)
        '
        'Cmd_ExportXml
        '
        Me.Cmd_ExportXml.AccessibleDescription = ""
        Me.Cmd_ExportXml.AccessibleName = ""
        Me.Cmd_ExportXml.Image = Global.DN990_BaseSetting.My.Resources.Resources.Image_99010
        Me.Cmd_ExportXml.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_ExportXml.Name = "Cmd_ExportXml"
        Me.Cmd_ExportXml.Size = New System.Drawing.Size(75, 37)
        Me.Cmd_ExportXml.Text = "导出xml"
        '
        'Cmd_InputXml
        '
        Me.Cmd_InputXml.AccessibleDescription = ""
        Me.Cmd_InputXml.AccessibleName = ""
        Me.Cmd_InputXml.Image = Global.DN990_BaseSetting.My.Resources.Resources.Export
        Me.Cmd_InputXml.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_InputXml.Name = "Cmd_InputXml"
        Me.Cmd_InputXml.Size = New System.Drawing.Size(75, 37)
        Me.Cmd_InputXml.Text = "对较xml"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 40)
        '
        'Cmd_Exit
        '
        Me.Cmd_Exit.Image = Global.DN990_BaseSetting.My.Resources.Resources.Close
        Me.Cmd_Exit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(57, 37)
        Me.Cmd_Exit.Text = "关闭"
        '
        'FG1
        '
        Me.FG1.AllowEditing = False
        Me.FG1.AutoAddIndex = True
        Me.FG1.AutoGenerateColumns = False
        Me.FG1.AutoResize = False
        Me.FG1.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.FG1.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.XpThemes
        Me.FG1.CanEditing = False
        Me.FG1.ColumnInfo = resources.GetString("FG1.ColumnInfo")
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
        Me.FG1.Location = New System.Drawing.Point(2, 42)
        Me.FG1.Name = "FG1"
        Me.FG1.Rows.Count = 10
        Me.FG1.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.FG1.Size = New System.Drawing.Size(1018, 623)
        Me.FG1.StartCol = ""
        Me.FG1.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("FG1.Styles"))
        Me.FG1.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.BelowData
        Me.FG1.TabIndex = 11
        '
        'PanelMain
        '
        Me.PanelMain.Controls.Add(Me.FG1)
        Me.PanelMain.Controls.Add(Me.Tool_Top)
        Me.PanelMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelMain.Location = New System.Drawing.Point(0, 0)
        Me.PanelMain.Name = "PanelMain"
        Me.PanelMain.Padding = New System.Windows.Forms.Padding(2)
        Me.PanelMain.Size = New System.Drawing.Size(1022, 667)
        Me.PanelMain.TabIndex = 12
        '
        'GroupBox_Xml
        '
        Me.GroupBox_Xml.Controls.Add(Me.Fg2)
        Me.GroupBox_Xml.Controls.Add(Me.ToolStrip1)
        Me.GroupBox_Xml.Location = New System.Drawing.Point(49, 319)
        Me.GroupBox_Xml.Name = "GroupBox_Xml"
        Me.GroupBox_Xml.Size = New System.Drawing.Size(921, 575)
        Me.GroupBox_Xml.TabIndex = 12
        Me.GroupBox_Xml.TabStop = False
        Me.GroupBox_Xml.Text = "报表差异"
        Me.GroupBox_Xml.Visible = False
        '
        'Fg2
        '
        Me.Fg2.AllowEditing = False
        Me.Fg2.AutoAddIndex = True
        Me.Fg2.AutoGenerateColumns = False
        Me.Fg2.AutoResize = False
        Me.Fg2.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.Fg2.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.XpThemes
        Me.Fg2.CanEditing = False
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
        Me.Fg2.Location = New System.Drawing.Point(3, 59)
        Me.Fg2.Name = "Fg2"
        Me.Fg2.Rows.Count = 10
        Me.Fg2.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.Fg2.Size = New System.Drawing.Size(915, 513)
        Me.Fg2.StartCol = ""
        Me.Fg2.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("Fg2.Styles"))
        Me.Fg2.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.BelowData
        Me.Fg2.TabIndex = 12
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Cmd_Change, Me.ToolStripSeparator4, Me.Cmd_Hide})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 19)
        Me.ToolStrip1.MinimumSize = New System.Drawing.Size(0, 40)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(915, 40)
        Me.ToolStrip1.TabIndex = 13
        Me.ToolStrip1.Text = "ToolStrip2"
        '
        'Cmd_Change
        '
        Me.Cmd_Change.AccessibleDescription = ""
        Me.Cmd_Change.AccessibleName = ""
        Me.Cmd_Change.Image = Global.DN990_BaseSetting.My.Resources.Resources.Export
        Me.Cmd_Change.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Change.Name = "Cmd_Change"
        Me.Cmd_Change.Size = New System.Drawing.Size(57, 37)
        Me.Cmd_Change.Text = "更新"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 40)
        '
        'Cmd_Hide
        '
        Me.Cmd_Hide.Image = Global.DN990_BaseSetting.My.Resources.Resources.Close
        Me.Cmd_Hide.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Hide.Name = "Cmd_Hide"
        Me.Cmd_Hide.Size = New System.Drawing.Size(57, 37)
        Me.Cmd_Hide.Text = "关闭"
        '
        'Panel_Xml
        '
        Me.Panel_Xml.Controls.Add(Me.GroupBox_Xml)
        Me.Panel_Xml.Controls.Add(Me.LabelMsg)
        Me.Panel_Xml.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel_Xml.Location = New System.Drawing.Point(0, 0)
        Me.Panel_Xml.Name = "Panel_Xml"
        Me.Panel_Xml.Size = New System.Drawing.Size(1022, 667)
        Me.Panel_Xml.TabIndex = 12
        Me.Panel_Xml.Visible = False
        '
        'LabelMsg
        '
        Me.LabelMsg.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelMsg.BackColor = System.Drawing.Color.Transparent
        Me.LabelMsg.Font = New System.Drawing.Font("宋体", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LabelMsg.ForeColor = System.Drawing.Color.Blue
        Me.LabelMsg.Location = New System.Drawing.Point(221, 224)
        Me.LabelMsg.Name = "LabelMsg"
        Me.LabelMsg.Size = New System.Drawing.Size(610, 59)
        Me.LabelMsg.TabIndex = 13
        Me.LabelMsg.Text = "加载中...."
        Me.LabelMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.LabelMsg.Visible = False
        '
        'F99010_Report
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Panel_Xml)
        Me.Controls.Add(Me.PanelMain)
        Me.Name = "F99010_Report"
        Me.Size = New System.Drawing.Size(1022, 667)
        Me.Title = "报表设置"
        Me.Tool_Top.ResumeLayout(False)
        Me.Tool_Top.PerformLayout()
        CType(Me.FG1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelMain.ResumeLayout(False)
        Me.PanelMain.PerformLayout()
        Me.GroupBox_Xml.ResumeLayout(False)
        Me.GroupBox_Xml.PerformLayout()
        CType(Me.Fg2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Panel_Xml.ResumeLayout(False)
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
    Friend WithEvents Cmd_ReFresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_PreView As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_FileOut As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents Cmd_ExportXml As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Cmd_InputXml As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBox_Xml As System.Windows.Forms.GroupBox
    Friend WithEvents Fg2 As PClass.FG
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents Cmd_Change As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Cmd_Hide As System.Windows.Forms.ToolStripButton
    Friend WithEvents Panel_Xml As System.Windows.Forms.Panel
    Friend WithEvents LabelMsg As System.Windows.Forms.Label

End Class
