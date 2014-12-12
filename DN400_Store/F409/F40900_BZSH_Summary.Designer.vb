<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F40900_BZSH_Summary
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F40900_BZSH_Summary))
        Me.PanelMain = New System.Windows.Forms.Panel
        Me.GR = New AxgrproLib.AxGRDisplayViewer
        Me.Tool_Search = New System.Windows.Forms.ToolStrip
        Me.ToolStripLabel4 = New System.Windows.Forms.ToolStripLabel
        Me.DP_Start = New PClass.ToolStripDateTimePicker
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel
        Me.DP_End = New PClass.ToolStripDateTimePicker
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel
        Me.TSC_Client = New BaseClass.ToolStripComboList
        Me.Btn_Search = New System.Windows.Forms.ToolStripButton
        Me.Cmd_Preview = New System.Windows.Forms.ToolStripButton
        Me.Cmd_Excel = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.Cmd_ShowColor = New System.Windows.Forms.ToolStripDropDownButton
        Me.Cmd_TP = New System.Windows.Forms.ToolStripMenuItem
        Me.Cmd_FG = New System.Windows.Forms.ToolStripMenuItem
        Me.Cmd_FK = New System.Windows.Forms.ToolStripMenuItem
        Me.Cmd_QT = New System.Windows.Forms.ToolStripMenuItem
        Me.Cmd_ShowHead = New System.Windows.Forms.ToolStripButton
        Me.Cmd_ShowFooter = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.Cmd_Exit = New System.Windows.Forms.ToolStripButton
        Me.Label_ZL = New System.Windows.Forms.ToolStripLabel
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel
        Me.Label_Num = New System.Windows.Forms.ToolStripLabel
        Me.ToolStripLabel6 = New System.Windows.Forms.ToolStripLabel
        Me.GroupBox_Color = New System.Windows.Forms.GroupBox
        Me.CB_Type = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Cme_Cancel = New System.Windows.Forms.Button
        Me.Cmd_Save = New System.Windows.Forms.Button
        Me.TB_Sift = New System.Windows.Forms.TextBox
        Me.Cmd_Color = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.TB_Name = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel_Color = New System.Windows.Forms.Panel
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog
        Me.CB_State = New System.Windows.Forms.ToolStripComboBox
        Me.ToolStripLabel5 = New System.Windows.Forms.ToolStripLabel
        Me.PanelMain.SuspendLayout()
        CType(Me.GR, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tool_Search.SuspendLayout()
        Me.GroupBox_Color.SuspendLayout()
        Me.Panel_Color.SuspendLayout()
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
        Me.Tool_Search.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel4, Me.DP_Start, Me.ToolStripLabel3, Me.DP_End, Me.ToolStripLabel1, Me.TSC_Client, Me.ToolStripLabel5, Me.CB_State, Me.Btn_Search, Me.Cmd_Preview, Me.Cmd_Excel, Me.ToolStripSeparator1, Me.Cmd_ShowColor, Me.Cmd_ShowHead, Me.Cmd_ShowFooter, Me.ToolStripSeparator2, Me.Cmd_Exit, Me.Label_ZL, Me.ToolStripLabel2, Me.Label_Num, Me.ToolStripLabel6})
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
        'DP_Start
        '
        Me.DP_Start.Name = "DP_Start"
        Me.DP_Start.Size = New System.Drawing.Size(100, 29)
        Me.DP_Start.Text = "2012-03-02"
        Me.DP_Start.Value = New Date(2012, 3, 2, 0, 0, 0, 0)
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.Margin = New System.Windows.Forms.Padding(2, 1, 2, 2)
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(17, 29)
        Me.ToolStripLabel3.Text = "到"
        '
        'DP_End
        '
        Me.DP_End.Name = "DP_End"
        Me.DP_End.Size = New System.Drawing.Size(100, 29)
        Me.DP_End.Text = "2012-03-02"
        Me.DP_End.Value = New Date(2012, 3, 2, 0, 0, 0, 0)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(41, 29)
        Me.ToolStripLabel1.Text = "客户："
        '
        'TSC_Client
        '
        Me.TSC_Client.Child = "ComboClient"
        Me.TSC_Client.IDAsInt = 0
        Me.TSC_Client.IsKeyDownAutoSearch = True
        Me.TSC_Client.Name = "TSC_Client"
        Me.TSC_Client.SearchType = BaseClass.cSearchType.ENum_SearchType.ALL
        Me.TSC_Client.Size = New System.Drawing.Size(120, 29)
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
        Me.Cmd_Preview.Enabled = False
        Me.Cmd_Preview.Image = Global.DN400_Store.My.Resources.Resources.Print_preview
        Me.Cmd_Preview.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Preview.Name = "Cmd_Preview"
        Me.Cmd_Preview.Size = New System.Drawing.Size(57, 29)
        Me.Cmd_Preview.Text = "预览"
        '
        'Cmd_Excel
        '
        Me.Cmd_Excel.Enabled = False
        Me.Cmd_Excel.Image = Global.DN400_Store.My.Resources.Resources.FileOut
        Me.Cmd_Excel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Excel.Name = "Cmd_Excel"
        Me.Cmd_Excel.Size = New System.Drawing.Size(57, 29)
        Me.Cmd_Excel.Text = "导出"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 32)
        '
        'Cmd_ShowColor
        '
        Me.Cmd_ShowColor.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Cmd_TP, Me.Cmd_FG, Me.Cmd_FK, Me.Cmd_QT})
        Me.Cmd_ShowColor.Image = Global.DN400_Store.My.Resources.Resources.A
        Me.Cmd_ShowColor.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_ShowColor.Name = "Cmd_ShowColor"
        Me.Cmd_ShowColor.Size = New System.Drawing.Size(90, 29)
        Me.Cmd_ShowColor.Text = "颜色设置"
        '
        'Cmd_TP
        '
        Me.Cmd_TP.AccessibleName = "0"
        Me.Cmd_TP.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Cmd_TP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Cmd_TP.Image = Global.DN400_Store.My.Resources.Resources.A
        Me.Cmd_TP.ImageTransparentColor = System.Drawing.Color.Fuchsia
        Me.Cmd_TP.Name = "Cmd_TP"
        Me.Cmd_TP.Size = New System.Drawing.Size(138, 30)
        Me.Cmd_TP.Text = "退胚颜色"
        Me.Cmd_TP.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay
        '
        'Cmd_FG
        '
        Me.Cmd_FG.AccessibleName = "1"
        Me.Cmd_FG.Image = Global.DN400_Store.My.Resources.Resources.A
        Me.Cmd_FG.Name = "Cmd_FG"
        Me.Cmd_FG.Size = New System.Drawing.Size(138, 30)
        Me.Cmd_FG.Text = "返工不收费"
        '
        'Cmd_FK
        '
        Me.Cmd_FK.AccessibleName = "2"
        Me.Cmd_FK.Image = Global.DN400_Store.My.Resources.Resources.A
        Me.Cmd_FK.Name = "Cmd_FK"
        Me.Cmd_FK.Size = New System.Drawing.Size(138, 30)
        Me.Cmd_FK.Text = "复刻收费"
        '
        'Cmd_QT
        '
        Me.Cmd_QT.AccessibleName = "3"
        Me.Cmd_QT.Image = Global.DN400_Store.My.Resources.Resources.A
        Me.Cmd_QT.Name = "Cmd_QT"
        Me.Cmd_QT.Size = New System.Drawing.Size(138, 30)
        Me.Cmd_QT.Text = "返定收费"
        '
        'Cmd_ShowHead
        '
        Me.Cmd_ShowHead.CheckOnClick = True
        Me.Cmd_ShowHead.Image = Global.DN400_Store.My.Resources.Resources.Modify
        Me.Cmd_ShowHead.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_ShowHead.Name = "Cmd_ShowHead"
        Me.Cmd_ShowHead.Size = New System.Drawing.Size(81, 29)
        Me.Cmd_ShowHead.Text = "显示表头"
        '
        'Cmd_ShowFooter
        '
        Me.Cmd_ShowFooter.CheckOnClick = True
        Me.Cmd_ShowFooter.Image = Global.DN400_Store.My.Resources.Resources._43
        Me.Cmd_ShowFooter.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_ShowFooter.Name = "Cmd_ShowFooter"
        Me.Cmd_ShowFooter.Size = New System.Drawing.Size(81, 29)
        Me.Cmd_ShowFooter.Text = "显示表尾"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 32)
        '
        'Cmd_Exit
        '
        Me.Cmd_Exit.Image = Global.DN400_Store.My.Resources.Resources.Close
        Me.Cmd_Exit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(57, 28)
        Me.Cmd_Exit.Text = "关闭"
        '
        'Label_ZL
        '
        Me.Label_ZL.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.Label_ZL.ForeColor = System.Drawing.Color.Blue
        Me.Label_ZL.Margin = New System.Windows.Forms.Padding(5, 1, 10, 2)
        Me.Label_ZL.Name = "Label_ZL"
        Me.Label_ZL.Size = New System.Drawing.Size(11, 12)
        Me.Label_ZL.Text = "0"
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(59, 12)
        Me.ToolStripLabel2.Text = "胚重合计:"
        '
        'Label_Num
        '
        Me.Label_Num.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.Label_Num.ForeColor = System.Drawing.Color.Blue
        Me.Label_Num.Margin = New System.Windows.Forms.Padding(5, 1, 10, 2)
        Me.Label_Num.Name = "Label_Num"
        Me.Label_Num.Size = New System.Drawing.Size(11, 12)
        Me.Label_Num.Text = "0"
        '
        'ToolStripLabel6
        '
        Me.ToolStripLabel6.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel6.Name = "ToolStripLabel6"
        Me.ToolStripLabel6.Size = New System.Drawing.Size(59, 12)
        Me.ToolStripLabel6.Text = "条数合计:"
        '
        'GroupBox_Color
        '
        Me.GroupBox_Color.Controls.Add(Me.CB_Type)
        Me.GroupBox_Color.Controls.Add(Me.Label3)
        Me.GroupBox_Color.Controls.Add(Me.Cme_Cancel)
        Me.GroupBox_Color.Controls.Add(Me.Cmd_Save)
        Me.GroupBox_Color.Controls.Add(Me.TB_Sift)
        Me.GroupBox_Color.Controls.Add(Me.Cmd_Color)
        Me.GroupBox_Color.Controls.Add(Me.Label2)
        Me.GroupBox_Color.Controls.Add(Me.TB_Name)
        Me.GroupBox_Color.Controls.Add(Me.Label1)
        Me.GroupBox_Color.Location = New System.Drawing.Point(137, 165)
        Me.GroupBox_Color.Name = "GroupBox_Color"
        Me.GroupBox_Color.Size = New System.Drawing.Size(388, 236)
        Me.GroupBox_Color.TabIndex = 19
        Me.GroupBox_Color.TabStop = False
        Me.GroupBox_Color.Text = "筛选设置"
        '
        'CB_Type
        '
        Me.CB_Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_Type.FormattingEnabled = True
        Me.CB_Type.Items.AddRange(New Object() {"正常", "退胚", "返工"})
        Me.CB_Type.Location = New System.Drawing.Point(121, 119)
        Me.CB_Type.Name = "CB_Type"
        Me.CB_Type.Size = New System.Drawing.Size(171, 22)
        Me.CB_Type.TabIndex = 9
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(66, 122)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 14)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "属于:"
        '
        'Cme_Cancel
        '
        Me.Cme_Cancel.Location = New System.Drawing.Point(247, 168)
        Me.Cme_Cancel.Name = "Cme_Cancel"
        Me.Cme_Cancel.Size = New System.Drawing.Size(93, 33)
        Me.Cme_Cancel.TabIndex = 7
        Me.Cme_Cancel.Text = "取消"
        Me.Cme_Cancel.UseVisualStyleBackColor = True
        '
        'Cmd_Save
        '
        Me.Cmd_Save.Location = New System.Drawing.Point(137, 168)
        Me.Cmd_Save.Name = "Cmd_Save"
        Me.Cmd_Save.Size = New System.Drawing.Size(93, 33)
        Me.Cmd_Save.TabIndex = 6
        Me.Cmd_Save.Text = "保存"
        Me.Cmd_Save.UseVisualStyleBackColor = True
        '
        'TB_Sift
        '
        Me.TB_Sift.Location = New System.Drawing.Point(121, 77)
        Me.TB_Sift.Name = "TB_Sift"
        Me.TB_Sift.Size = New System.Drawing.Size(171, 23)
        Me.TB_Sift.TabIndex = 5
        '
        'Cmd_Color
        '
        Me.Cmd_Color.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Cmd_Color.Location = New System.Drawing.Point(28, 168)
        Me.Cmd_Color.Name = "Cmd_Color"
        Me.Cmd_Color.Size = New System.Drawing.Size(93, 33)
        Me.Cmd_Color.TabIndex = 3
        Me.Cmd_Color.Text = "颜色"
        Me.Cmd_Color.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(66, 80)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 14)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "筛选:"
        '
        'TB_Name
        '
        Me.TB_Name.Location = New System.Drawing.Point(121, 34)
        Me.TB_Name.Name = "TB_Name"
        Me.TB_Name.Size = New System.Drawing.Size(171, 23)
        Me.TB_Name.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(66, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 14)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "名称:"
        '
        'Panel_Color
        '
        Me.Panel_Color.Controls.Add(Me.GroupBox_Color)
        Me.Panel_Color.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel_Color.Location = New System.Drawing.Point(0, 0)
        Me.Panel_Color.Name = "Panel_Color"
        Me.Panel_Color.Size = New System.Drawing.Size(1000, 618)
        Me.Panel_Color.TabIndex = 20
        Me.Panel_Color.Visible = False
        '
        'ColorDialog1
        '
        Me.ColorDialog1.FullOpen = True
        '
        'CB_State
        '
        Me.CB_State.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.CB_State.Name = "CB_State"
        Me.CB_State.Size = New System.Drawing.Size(80, 32)
        '
        'ToolStripLabel5
        '
        Me.ToolStripLabel5.Name = "ToolStripLabel5"
        Me.ToolStripLabel5.Size = New System.Drawing.Size(41, 29)
        Me.ToolStripLabel5.Text = "类型："
        '
        'F40900_BZSH_Summary
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CanMaxSize = True
        Me.Controls.Add(Me.PanelMain)
        Me.Controls.Add(Me.Panel_Color)
        Me.ForeColor = System.Drawing.Color.Black
        Me.Name = "F40900_BZSH_Summary"
        Me.Size = New System.Drawing.Size(1000, 618)
        Me.PanelMain.ResumeLayout(False)
        Me.PanelMain.PerformLayout()
        CType(Me.GR, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tool_Search.ResumeLayout(False)
        Me.Tool_Search.PerformLayout()
        Me.GroupBox_Color.ResumeLayout(False)
        Me.GroupBox_Color.PerformLayout()
        Me.Panel_Color.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelMain As System.Windows.Forms.Panel
    Friend WithEvents Tool_Search As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel4 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabel3 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Btn_Search As System.Windows.Forms.ToolStripButton
    Friend WithEvents GR As AxgrproLib.AxGRDisplayViewer
    Friend WithEvents Cmd_Preview As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Label_ZL As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabel6 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Label_Num As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Cmd_Exit As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBox_Color As System.Windows.Forms.GroupBox
    Friend WithEvents TB_Sift As System.Windows.Forms.TextBox
    Friend WithEvents Cmd_Color As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TB_Name As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CB_Type As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Cme_Cancel As System.Windows.Forms.Button
    Friend WithEvents Cmd_Save As System.Windows.Forms.Button
    Friend WithEvents Panel_Color As System.Windows.Forms.Panel
    Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
    Friend WithEvents Cmd_Excel As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_ShowColor As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents Cmd_TP As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Cmd_FG As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Cmd_FK As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Cmd_QT As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Cmd_ShowHead As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_ShowFooter As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TSC_Client As BaseClass.ToolStripComboList
    Friend WithEvents DP_Start As PClass.ToolStripDateTimePicker
    Friend WithEvents DP_End As PClass.ToolStripDateTimePicker
    Friend WithEvents ToolStripLabel5 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents CB_State As System.Windows.Forms.ToolStripComboBox

End Class
