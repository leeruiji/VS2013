<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F10301_DPGY_Msg
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
        Me.Tool_Top = New System.Windows.Forms.ToolStrip
        Me.Cmd_Modify = New System.Windows.Forms.ToolStripButton
        Me.Cmd_Del = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.Cmd_Exit = New System.Windows.Forms.ToolStripButton
        Me.PanelMain = New System.Windows.Forms.Panel
        Me.CB_BZ = New BaseClass.ComBoList
        Me.CB_Client = New BaseClass.ComBoList
        Me.TB_DPGY_SCW = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.TB_DPGY_XCW = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.CB_DPGY_YS = New System.Windows.Forms.ComboBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.TB_DPGY_WD = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.TB_DPGY_JS = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.CB_DPGY_Color = New System.Windows.Forms.ComboBox
        Me.TB_DPGY_FS = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.DP_Found_Date = New System.Windows.Forms.DateTimePicker
        Me.DP_UPD_DATE = New System.Windows.Forms.DateTimePicker
        Me.TB_Founder = New System.Windows.Forms.TextBox
        Me.TB_UPD_USER = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.TB_Remark = New System.Windows.Forms.TextBox
        Me.TB_ID = New System.Windows.Forms.TextBox
        Me.TB_Name = New System.Windows.Forms.TextBox
        Me.TB_SupplierName = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.LB_FullName = New System.Windows.Forms.Label
        Me.LB_Area = New System.Windows.Forms.Label
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.CB_DyingStep = New System.Windows.Forms.ComboBox
        Me.Tool_Top.SuspendLayout()
        Me.PanelMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'Tool_Top
        '
        Me.Tool_Top.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.Tool_Top.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Cmd_Modify, Me.Cmd_Del, Me.ToolStripSeparator1, Me.Cmd_Exit})
        Me.Tool_Top.Location = New System.Drawing.Point(0, 0)
        Me.Tool_Top.MinimumSize = New System.Drawing.Size(0, 40)
        Me.Tool_Top.Name = "Tool_Top"
        Me.Tool_Top.Size = New System.Drawing.Size(560, 40)
        Me.Tool_Top.TabIndex = 1
        Me.Tool_Top.Text = "ToolStrip2"
        '
        'Cmd_Modify
        '
        Me.Cmd_Modify.AccessibleDescription = "修改按钮"
        Me.Cmd_Modify.AccessibleName = ""
        Me.Cmd_Modify.Image = Global.DN100_BasicInfo.My.Resources.Resources.Modify
        Me.Cmd_Modify.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Modify.Name = "Cmd_Modify"
        Me.Cmd_Modify.Size = New System.Drawing.Size(57, 37)
        Me.Cmd_Modify.Text = "保存"
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
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 40)
        '
        'Cmd_Exit
        '
        Me.Cmd_Exit.Image = Global.DN100_BasicInfo.My.Resources.Resources.Close
        Me.Cmd_Exit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(57, 37)
        Me.Cmd_Exit.Text = "关闭"
        '
        'PanelMain
        '
        Me.PanelMain.Controls.Add(Me.CB_BZ)
        Me.PanelMain.Controls.Add(Me.CB_Client)
        Me.PanelMain.Controls.Add(Me.TB_DPGY_SCW)
        Me.PanelMain.Controls.Add(Me.Label7)
        Me.PanelMain.Controls.Add(Me.TB_DPGY_XCW)
        Me.PanelMain.Controls.Add(Me.Label11)
        Me.PanelMain.Controls.Add(Me.CB_DPGY_YS)
        Me.PanelMain.Controls.Add(Me.Label10)
        Me.PanelMain.Controls.Add(Me.Label8)
        Me.PanelMain.Controls.Add(Me.Label9)
        Me.PanelMain.Controls.Add(Me.TB_DPGY_WD)
        Me.PanelMain.Controls.Add(Me.Label4)
        Me.PanelMain.Controls.Add(Me.TB_DPGY_JS)
        Me.PanelMain.Controls.Add(Me.Label3)
        Me.PanelMain.Controls.Add(Me.CB_DPGY_Color)
        Me.PanelMain.Controls.Add(Me.TB_DPGY_FS)
        Me.PanelMain.Controls.Add(Me.Label1)
        Me.PanelMain.Controls.Add(Me.Label2)
        Me.PanelMain.Controls.Add(Me.DP_Found_Date)
        Me.PanelMain.Controls.Add(Me.DP_UPD_DATE)
        Me.PanelMain.Controls.Add(Me.TB_Founder)
        Me.PanelMain.Controls.Add(Me.TB_UPD_USER)
        Me.PanelMain.Controls.Add(Me.Label6)
        Me.PanelMain.Controls.Add(Me.Label23)
        Me.PanelMain.Controls.Add(Me.Label5)
        Me.PanelMain.Controls.Add(Me.Label22)
        Me.PanelMain.Controls.Add(Me.TB_Remark)
        Me.PanelMain.Controls.Add(Me.TB_ID)
        Me.PanelMain.Controls.Add(Me.TB_Name)
        Me.PanelMain.Controls.Add(Me.TB_SupplierName)
        Me.PanelMain.Controls.Add(Me.Label19)
        Me.PanelMain.Controls.Add(Me.LB_FullName)
        Me.PanelMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelMain.Location = New System.Drawing.Point(0, 40)
        Me.PanelMain.Name = "PanelMain"
        Me.PanelMain.Padding = New System.Windows.Forms.Padding(2)
        Me.PanelMain.Size = New System.Drawing.Size(560, 501)
        Me.PanelMain.TabIndex = 0
        '
        'CB_BZ
        '
        Me.CB_BZ.Child = "ComboBZ"
        Me.CB_BZ.FormattingEnabled = True
        Me.CB_BZ.IDValue = ""
        Me.CB_BZ.IsKeyDownAutoSearch = True
        Me.CB_BZ.IsTBLostFocusSelOne = True
        Me.CB_BZ.Location = New System.Drawing.Point(334, 117)
        Me.CB_BZ.Name = "CB_BZ"
        Me.CB_BZ.SearchType = BaseClass.cSearchType.ENum_SearchType.ALL
        Me.CB_BZ.Size = New System.Drawing.Size(161, 22)
        Me.CB_BZ.TabIndex = 3
        '
        'CB_Client
        '
        Me.CB_Client.Child = "ComboClient"
        Me.CB_Client.FormattingEnabled = True
        Me.CB_Client.IDValue = ""
        Me.CB_Client.IsKeyDownAutoSearch = True
        Me.CB_Client.IsTBLostFocusSelOne = True
        Me.CB_Client.Location = New System.Drawing.Point(120, 117)
        Me.CB_Client.Name = "CB_Client"
        Me.CB_Client.SearchType = BaseClass.cSearchType.ENum_SearchType.ALL
        Me.CB_Client.Size = New System.Drawing.Size(115, 22)
        Me.CB_Client.TabIndex = 2
        '
        'TB_DPGY_SCW
        '
        Me.TB_DPGY_SCW.Location = New System.Drawing.Point(120, 261)
        Me.TB_DPGY_SCW.Name = "TB_DPGY_SCW"
        Me.TB_DPGY_SCW.Size = New System.Drawing.Size(115, 23)
        Me.TB_DPGY_SCW.TabIndex = 8
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(57, 265)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(56, 14)
        Me.Label7.TabIndex = 79
        Me.Label7.Text = "上超位:"
        '
        'TB_DPGY_XCW
        '
        Me.TB_DPGY_XCW.Location = New System.Drawing.Point(334, 261)
        Me.TB_DPGY_XCW.Name = "TB_DPGY_XCW"
        Me.TB_DPGY_XCW.Size = New System.Drawing.Size(161, 23)
        Me.TB_DPGY_XCW.TabIndex = 9
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(268, 265)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(56, 14)
        Me.Label11.TabIndex = 77
        Me.Label11.Text = "下超位:"
        '
        'CB_DPGY_YS
        '
        Me.CB_DPGY_YS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_DPGY_YS.FormattingEnabled = True
        Me.CB_DPGY_YS.Items.AddRange(New Object() {"干压", "过热水"})
        Me.CB_DPGY_YS.Location = New System.Drawing.Point(120, 312)
        Me.CB_DPGY_YS.Name = "CB_DPGY_YS"
        Me.CB_DPGY_YS.Size = New System.Drawing.Size(115, 22)
        Me.CB_DPGY_YS.TabIndex = 10
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(69, 316)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(42, 14)
        Me.Label10.TabIndex = 73
        Me.Label10.Text = "压缩:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(282, 120)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(42, 14)
        Me.Label8.TabIndex = 69
        Me.Label8.Text = "布种:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(69, 120)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(42, 14)
        Me.Label9.TabIndex = 68
        Me.Label9.Text = "客户:"
        '
        'TB_DPGY_WD
        '
        Me.TB_DPGY_WD.Location = New System.Drawing.Point(334, 164)
        Me.TB_DPGY_WD.Name = "TB_DPGY_WD"
        Me.TB_DPGY_WD.Size = New System.Drawing.Size(161, 23)
        Me.TB_DPGY_WD.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(282, 168)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 14)
        Me.Label4.TabIndex = 63
        Me.Label4.Text = "温度:"
        '
        'TB_DPGY_JS
        '
        Me.TB_DPGY_JS.Location = New System.Drawing.Point(120, 212)
        Me.TB_DPGY_JS.Name = "TB_DPGY_JS"
        Me.TB_DPGY_JS.Size = New System.Drawing.Size(115, 23)
        Me.TB_DPGY_JS.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(69, 212)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 14)
        Me.Label3.TabIndex = 61
        Me.Label3.Text = "机速:"
        '
        'CB_DPGY_Color
        '
        Me.CB_DPGY_Color.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_DPGY_Color.FormattingEnabled = True
        Me.CB_DPGY_Color.Items.AddRange(New Object() {"白色", "杂色", "黑色"})
        Me.CB_DPGY_Color.Location = New System.Drawing.Point(120, 164)
        Me.CB_DPGY_Color.Name = "CB_DPGY_Color"
        Me.CB_DPGY_Color.Size = New System.Drawing.Size(115, 22)
        Me.CB_DPGY_Color.TabIndex = 4
        '
        'TB_DPGY_FS
        '
        Me.TB_DPGY_FS.Location = New System.Drawing.Point(334, 212)
        Me.TB_DPGY_FS.Name = "TB_DPGY_FS"
        Me.TB_DPGY_FS.Size = New System.Drawing.Size(161, 23)
        Me.TB_DPGY_FS.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(69, 168)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 14)
        Me.Label1.TabIndex = 58
        Me.Label1.Text = "颜色:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(282, 216)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 14)
        Me.Label2.TabIndex = 57
        Me.Label2.Text = "风速:"
        '
        'DP_Found_Date
        '
        Me.DP_Found_Date.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.DP_Found_Date.Enabled = False
        Me.DP_Found_Date.Location = New System.Drawing.Point(889, 476)
        Me.DP_Found_Date.Name = "DP_Found_Date"
        Me.DP_Found_Date.Size = New System.Drawing.Size(115, 23)
        Me.DP_Found_Date.TabIndex = 28
        Me.DP_Found_Date.Visible = False
        '
        'DP_UPD_DATE
        '
        Me.DP_UPD_DATE.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.DP_UPD_DATE.Enabled = False
        Me.DP_UPD_DATE.Location = New System.Drawing.Point(889, 440)
        Me.DP_UPD_DATE.Name = "DP_UPD_DATE"
        Me.DP_UPD_DATE.Size = New System.Drawing.Size(115, 23)
        Me.DP_UPD_DATE.TabIndex = 27
        Me.DP_UPD_DATE.Visible = False
        '
        'TB_Founder
        '
        Me.TB_Founder.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TB_Founder.Location = New System.Drawing.Point(667, 479)
        Me.TB_Founder.Name = "TB_Founder"
        Me.TB_Founder.ReadOnly = True
        Me.TB_Founder.Size = New System.Drawing.Size(115, 23)
        Me.TB_Founder.TabIndex = 25
        Me.TB_Founder.Visible = False
        '
        'TB_UPD_USER
        '
        Me.TB_UPD_USER.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TB_UPD_USER.Location = New System.Drawing.Point(667, 442)
        Me.TB_UPD_USER.Name = "TB_UPD_USER"
        Me.TB_UPD_USER.ReadOnly = True
        Me.TB_UPD_USER.Size = New System.Drawing.Size(115, 23)
        Me.TB_UPD_USER.TabIndex = 26
        Me.TB_UPD_USER.Visible = False
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(820, 482)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(70, 14)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "创建时间:"
        Me.Label6.Visible = False
        '
        'Label23
        '
        Me.Label23.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(792, 444)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(98, 14)
        Me.Label23.TabIndex = 18
        Me.Label23.Text = "最后修改时间:"
        Me.Label23.Visible = False
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(606, 482)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 14)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "创建人:"
        Me.Label5.Visible = False
        '
        'Label22
        '
        Me.Label22.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(578, 449)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(84, 14)
        Me.Label22.TabIndex = 16
        Me.Label22.Text = "最后修改人:"
        Me.Label22.Visible = False
        '
        'TB_Remark
        '
        Me.TB_Remark.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TB_Remark.Location = New System.Drawing.Point(120, 361)
        Me.TB_Remark.Multiline = True
        Me.TB_Remark.Name = "TB_Remark"
        Me.TB_Remark.Size = New System.Drawing.Size(406, 114)
        Me.TB_Remark.TabIndex = 11
        '
        'TB_ID
        '
        Me.TB_ID.Location = New System.Drawing.Point(120, 21)
        Me.TB_ID.Name = "TB_ID"
        Me.TB_ID.Size = New System.Drawing.Size(115, 23)
        Me.TB_ID.TabIndex = 0
        '
        'TB_Name
        '
        Me.TB_Name.Location = New System.Drawing.Point(120, 69)
        Me.TB_Name.Name = "TB_Name"
        Me.TB_Name.Size = New System.Drawing.Size(375, 23)
        Me.TB_Name.TabIndex = 1
        '
        'TB_SupplierName
        '
        Me.TB_SupplierName.AutoSize = True
        Me.TB_SupplierName.Location = New System.Drawing.Point(43, 24)
        Me.TB_SupplierName.Name = "TB_SupplierName"
        Me.TB_SupplierName.Size = New System.Drawing.Size(70, 14)
        Me.TB_SupplierName.TabIndex = 7
        Me.TB_SupplierName.Text = "工艺编号:"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(72, 364)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(42, 14)
        Me.Label19.TabIndex = 6
        Me.Label19.Text = "备注:"
        '
        'LB_FullName
        '
        Me.LB_FullName.AutoSize = True
        Me.LB_FullName.Location = New System.Drawing.Point(41, 72)
        Me.LB_FullName.Name = "LB_FullName"
        Me.LB_FullName.Size = New System.Drawing.Size(70, 14)
        Me.LB_FullName.TabIndex = 5
        Me.LB_FullName.Text = "工艺名称:"
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
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'CB_DyingStep
        '
        Me.CB_DyingStep.FormattingEnabled = True
        Me.CB_DyingStep.Location = New System.Drawing.Point(467, 12)
        Me.CB_DyingStep.Name = "CB_DyingStep"
        Me.CB_DyingStep.Size = New System.Drawing.Size(111, 22)
        Me.CB_DyingStep.TabIndex = 54
        Me.CB_DyingStep.Visible = False
        '
        'F10301_DPGY_Msg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CanMaxSize = True
        Me.Controls.Add(Me.CB_DyingStep)
        Me.Controls.Add(Me.PanelMain)
        Me.Controls.Add(Me.Tool_Top)
        Me.Controls.Add(Me.LB_Area)
        Me.Name = "F10301_DPGY_Msg"
        Me.Size = New System.Drawing.Size(560, 541)
        Me.Title = "工艺详细信息"
        Me.Tool_Top.ResumeLayout(False)
        Me.Tool_Top.PerformLayout()
        Me.PanelMain.ResumeLayout(False)
        Me.PanelMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Tool_Top As System.Windows.Forms.ToolStrip
    Friend WithEvents Cmd_Modify As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_Del As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_Exit As System.Windows.Forms.ToolStripButton
    Friend WithEvents PanelMain As System.Windows.Forms.Panel
    Friend WithEvents TB_Name As System.Windows.Forms.TextBox
    Friend WithEvents LB_FullName As System.Windows.Forms.Label
    Friend WithEvents TB_Remark As System.Windows.Forms.TextBox
    Friend WithEvents TB_ID As System.Windows.Forms.TextBox
    Friend WithEvents LB_Area As System.Windows.Forms.Label
    Friend WithEvents TB_SupplierName As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents DP_Found_Date As System.Windows.Forms.DateTimePicker
    Friend WithEvents DP_UPD_DATE As System.Windows.Forms.DateTimePicker
    Friend WithEvents TB_Founder As System.Windows.Forms.TextBox
    Friend WithEvents TB_UPD_USER As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CB_DyingStep As System.Windows.Forms.ComboBox
    Friend WithEvents TB_DPGY_FS As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CB_DPGY_Color As System.Windows.Forms.ComboBox
    Friend WithEvents TB_DPGY_WD As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TB_DPGY_JS As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents CB_DPGY_YS As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TB_DPGY_SCW As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TB_DPGY_XCW As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents CB_BZ As BaseClass.ComBoList
    Friend WithEvents CB_Client As BaseClass.ComBoList

End Class
