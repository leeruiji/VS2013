<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F30501_SCCP_Msg
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F30501_SCCP_Msg))
        Me.Tool_Top = New System.Windows.Forms.ToolStrip
        Me.Cmd_Modify = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.Btn_RemoveRow = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.Btn_Preview = New System.Windows.Forms.ToolStripButton
        Me.Btn_Print = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.Cmd_Exit = New System.Windows.Forms.ToolStripButton
        Me.PanelMain = New System.Windows.Forms.Panel
        Me.TB_CR_LuoSeBzZL = New System.Windows.Forms.TextBox
        Me.Label_CR_LuoSeBzZL = New System.Windows.Forms.Label
        Me.TB_XPQty = New System.Windows.Forms.TextBox
        Me.Label31 = New System.Windows.Forms.Label
        Me.Label28 = New System.Windows.Forms.Label
        Me.LB_State = New System.Windows.Forms.Label
        Me.BZC_No = New System.Windows.Forms.TextBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.DTP_Date_JiaoHuo = New System.Windows.Forms.DateTimePicker
        Me.Label24 = New System.Windows.Forms.Label
        Me.DTP_Date_KaiDan = New System.Windows.Forms.DateTimePicker
        Me.Label23 = New System.Windows.Forms.Label
        Me.DTP_Date_LuoSe = New System.Windows.Forms.DateTimePicker
        Me.Label22 = New System.Windows.Forms.Label
        Me.TB_ProcessType = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.TB_Contract = New System.Windows.Forms.TextBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.TB_CR_LuoSeBzCount = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.TB_BZ_No = New System.Windows.Forms.TextBox
        Me.TB_Client_No = New System.Windows.Forms.TextBox
        Me.TB_TextileFatory = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.LabelTitle = New System.Windows.Forms.Label
        Me.BZC_Name = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.TB_BZ_Name = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.TB_Client_Name = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.DTP_Date = New System.Windows.Forms.DateTimePicker
        Me.Label16 = New System.Windows.Forms.Label
        Me.TB_GH = New System.Windows.Forms.TextBox
        Me.Label_ID = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label_Supplier_ID = New System.Windows.Forms.Label
        Me.GB_List = New System.Windows.Forms.GroupBox
        Me.TB_YPZL = New System.Windows.Forms.TextBox
        Me.TB_YPQty = New System.Windows.Forms.TextBox
        Me.Label29 = New System.Windows.Forms.Label
        Me.Label30 = New System.Windows.Forms.Label
        Me.TB_Input = New System.Windows.Forms.TextBox
        Me.Label26 = New System.Windows.Forms.Label
        Me.PanelFG = New System.Windows.Forms.Panel
        Me.Fg2 = New PClass.FG
        Me.TB_RemainZl = New System.Windows.Forms.TextBox
        Me.TB_PWeight = New System.Windows.Forms.TextBox
        Me.TB_RemainQty = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.TB_SumQty = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.GB_Foot = New System.Windows.Forms.GroupBox
        Me.TB_XiaoZhang = New System.Windows.Forms.TextBox
        Me.TB_PB_User = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.TB_ZhiDan = New System.Windows.Forms.TextBox
        Me.Tool_Top.SuspendLayout()
        Me.PanelMain.SuspendLayout()
        Me.GB_List.SuspendLayout()
        Me.PanelFG.SuspendLayout()
        CType(Me.Fg2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GB_Foot.SuspendLayout()
        Me.SuspendLayout()
        '
        'Tool_Top
        '
        Me.Tool_Top.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.Tool_Top.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Cmd_Modify, Me.ToolStripSeparator2, Me.Btn_RemoveRow, Me.ToolStripSeparator5, Me.Btn_Preview, Me.Btn_Print, Me.ToolStripSeparator3, Me.Cmd_Exit})
        Me.Tool_Top.Location = New System.Drawing.Point(0, 0)
        Me.Tool_Top.MinimumSize = New System.Drawing.Size(0, 58)
        Me.Tool_Top.Name = "Tool_Top"
        Me.Tool_Top.Size = New System.Drawing.Size(1024, 58)
        Me.Tool_Top.TabIndex = 10
        Me.Tool_Top.Text = "ToolStrip2"
        '
        'Cmd_Modify
        '
        Me.Cmd_Modify.AccessibleDescription = "修改按钮"
        Me.Cmd_Modify.AccessibleName = ""
        Me.Cmd_Modify.Image = Global.DN305_QC.My.Resources.Resources.Modify
        Me.Cmd_Modify.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Modify.Name = "Cmd_Modify"
        Me.Cmd_Modify.Size = New System.Drawing.Size(33, 55)
        Me.Cmd_Modify.Text = "保存"
        Me.Cmd_Modify.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 58)
        '
        'Btn_RemoveRow
        '
        Me.Btn_RemoveRow.Image = CType(resources.GetObject("Btn_RemoveRow.Image"), System.Drawing.Image)
        Me.Btn_RemoveRow.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Btn_RemoveRow.Name = "Btn_RemoveRow"
        Me.Btn_RemoveRow.Size = New System.Drawing.Size(33, 55)
        Me.Btn_RemoveRow.Text = "减行"
        Me.Btn_RemoveRow.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 58)
        '
        'Btn_Preview
        '
        Me.Btn_Preview.Image = Global.DN305_QC.My.Resources.Resources.Print_preview
        Me.Btn_Preview.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Btn_Preview.Name = "Btn_Preview"
        Me.Btn_Preview.Size = New System.Drawing.Size(33, 55)
        Me.Btn_Preview.Text = "预览"
        Me.Btn_Preview.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'Btn_Print
        '
        Me.Btn_Print.Image = Global.DN305_QC.My.Resources.Resources.print
        Me.Btn_Print.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Btn_Print.Name = "Btn_Print"
        Me.Btn_Print.Size = New System.Drawing.Size(33, 55)
        Me.Btn_Print.Text = "打印"
        Me.Btn_Print.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 58)
        '
        'Cmd_Exit
        '
        Me.Cmd_Exit.Image = Global.DN305_QC.My.Resources.Resources.Close
        Me.Cmd_Exit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(33, 55)
        Me.Cmd_Exit.Text = "关闭"
        Me.Cmd_Exit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'PanelMain
        '
        Me.PanelMain.Controls.Add(Me.TB_CR_LuoSeBzZL)
        Me.PanelMain.Controls.Add(Me.Label_CR_LuoSeBzZL)
        Me.PanelMain.Controls.Add(Me.TB_XPQty)
        Me.PanelMain.Controls.Add(Me.Label31)
        Me.PanelMain.Controls.Add(Me.Label28)
        Me.PanelMain.Controls.Add(Me.LB_State)
        Me.PanelMain.Controls.Add(Me.BZC_No)
        Me.PanelMain.Controls.Add(Me.Label25)
        Me.PanelMain.Controls.Add(Me.DTP_Date_JiaoHuo)
        Me.PanelMain.Controls.Add(Me.Label24)
        Me.PanelMain.Controls.Add(Me.DTP_Date_KaiDan)
        Me.PanelMain.Controls.Add(Me.Label23)
        Me.PanelMain.Controls.Add(Me.DTP_Date_LuoSe)
        Me.PanelMain.Controls.Add(Me.Label22)
        Me.PanelMain.Controls.Add(Me.TB_ProcessType)
        Me.PanelMain.Controls.Add(Me.Label21)
        Me.PanelMain.Controls.Add(Me.TB_Contract)
        Me.PanelMain.Controls.Add(Me.Label20)
        Me.PanelMain.Controls.Add(Me.TB_CR_LuoSeBzCount)
        Me.PanelMain.Controls.Add(Me.Label19)
        Me.PanelMain.Controls.Add(Me.TB_BZ_No)
        Me.PanelMain.Controls.Add(Me.TB_Client_No)
        Me.PanelMain.Controls.Add(Me.TB_TextileFatory)
        Me.PanelMain.Controls.Add(Me.Label17)
        Me.PanelMain.Controls.Add(Me.Label12)
        Me.PanelMain.Controls.Add(Me.LabelTitle)
        Me.PanelMain.Controls.Add(Me.BZC_Name)
        Me.PanelMain.Controls.Add(Me.Label13)
        Me.PanelMain.Controls.Add(Me.TB_BZ_Name)
        Me.PanelMain.Controls.Add(Me.Label11)
        Me.PanelMain.Controls.Add(Me.TB_Client_Name)
        Me.PanelMain.Controls.Add(Me.Label4)
        Me.PanelMain.Controls.Add(Me.DTP_Date)
        Me.PanelMain.Controls.Add(Me.Label16)
        Me.PanelMain.Controls.Add(Me.TB_GH)
        Me.PanelMain.Controls.Add(Me.Label_ID)
        Me.PanelMain.Controls.Add(Me.Label1)
        Me.PanelMain.Controls.Add(Me.Label_Supplier_ID)
        Me.PanelMain.Controls.Add(Me.GB_List)
        Me.PanelMain.Controls.Add(Me.GB_Foot)
        Me.PanelMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelMain.Location = New System.Drawing.Point(0, 58)
        Me.PanelMain.Name = "PanelMain"
        Me.PanelMain.Padding = New System.Windows.Forms.Padding(2)
        Me.PanelMain.Size = New System.Drawing.Size(1024, 660)
        Me.PanelMain.TabIndex = 0
        '
        'TB_CR_LuoSeBzZL
        '
        Me.TB_CR_LuoSeBzZL.Location = New System.Drawing.Point(505, 125)
        Me.TB_CR_LuoSeBzZL.Name = "TB_CR_LuoSeBzZL"
        Me.TB_CR_LuoSeBzZL.ReadOnly = True
        Me.TB_CR_LuoSeBzZL.Size = New System.Drawing.Size(104, 23)
        Me.TB_CR_LuoSeBzZL.TabIndex = 47
        Me.TB_CR_LuoSeBzZL.Visible = False
        '
        'Label_CR_LuoSeBzZL
        '
        Me.Label_CR_LuoSeBzZL.AutoSize = True
        Me.Label_CR_LuoSeBzZL.Location = New System.Drawing.Point(429, 127)
        Me.Label_CR_LuoSeBzZL.Name = "Label_CR_LuoSeBzZL"
        Me.Label_CR_LuoSeBzZL.Size = New System.Drawing.Size(70, 14)
        Me.Label_CR_LuoSeBzZL.TabIndex = 48
        Me.Label_CR_LuoSeBzZL.Text = "落色重量:"
        Me.Label_CR_LuoSeBzZL.Visible = False
        '
        'TB_XPQty
        '
        Me.TB_XPQty.Location = New System.Drawing.Point(690, 125)
        Me.TB_XPQty.Name = "TB_XPQty"
        Me.TB_XPQty.ReadOnly = True
        Me.TB_XPQty.Size = New System.Drawing.Size(104, 23)
        Me.TB_XPQty.TabIndex = 45
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(614, 127)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(70, 14)
        Me.Label31.TabIndex = 46
        Me.Label31.Text = "须配条数:"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(181, 18)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(49, 14)
        Me.Label28.TabIndex = 44
        Me.Label28.Text = "状 态:"
        '
        'LB_State
        '
        Me.LB_State.AutoSize = True
        Me.LB_State.ForeColor = System.Drawing.Color.Blue
        Me.LB_State.Location = New System.Drawing.Point(236, 18)
        Me.LB_State.Name = "LB_State"
        Me.LB_State.Size = New System.Drawing.Size(0, 14)
        Me.LB_State.TabIndex = 43
        '
        'BZC_No
        '
        Me.BZC_No.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.BZC_No.ForeColor = System.Drawing.Color.Blue
        Me.BZC_No.Location = New System.Drawing.Point(100, 124)
        Me.BZC_No.Name = "BZC_No"
        Me.BZC_No.ReadOnly = True
        Me.BZC_No.Size = New System.Drawing.Size(111, 23)
        Me.BZC_No.TabIndex = 41
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(52, 128)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(42, 14)
        Me.Label25.TabIndex = 42
        Me.Label25.Text = "色号:"
        '
        'DTP_Date_JiaoHuo
        '
        Me.DTP_Date_JiaoHuo.CustomFormat = "yyyy-MM-dd"
        Me.DTP_Date_JiaoHuo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTP_Date_JiaoHuo.Location = New System.Drawing.Point(898, 124)
        Me.DTP_Date_JiaoHuo.Name = "DTP_Date_JiaoHuo"
        Me.DTP_Date_JiaoHuo.Size = New System.Drawing.Size(101, 23)
        Me.DTP_Date_JiaoHuo.TabIndex = 40
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(817, 128)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(70, 14)
        Me.Label24.TabIndex = 39
        Me.Label24.Text = "交货日期:"
        '
        'DTP_Date_KaiDan
        '
        Me.DTP_Date_KaiDan.CustomFormat = "yyyy-MM-dd"
        Me.DTP_Date_KaiDan.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTP_Date_KaiDan.Location = New System.Drawing.Point(898, 89)
        Me.DTP_Date_KaiDan.Name = "DTP_Date_KaiDan"
        Me.DTP_Date_KaiDan.Size = New System.Drawing.Size(101, 23)
        Me.DTP_Date_KaiDan.TabIndex = 38
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(817, 93)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(70, 14)
        Me.Label23.TabIndex = 37
        Me.Label23.Text = "开单日期:"
        '
        'DTP_Date_LuoSe
        '
        Me.DTP_Date_LuoSe.CustomFormat = "yyyy-MM-dd"
        Me.DTP_Date_LuoSe.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTP_Date_LuoSe.Location = New System.Drawing.Point(898, 54)
        Me.DTP_Date_LuoSe.Name = "DTP_Date_LuoSe"
        Me.DTP_Date_LuoSe.Size = New System.Drawing.Size(101, 23)
        Me.DTP_Date_LuoSe.TabIndex = 36
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(817, 58)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(70, 14)
        Me.Label22.TabIndex = 35
        Me.Label22.Text = "落色日期:"
        '
        'TB_ProcessType
        '
        Me.TB_ProcessType.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.TB_ProcessType.ForeColor = System.Drawing.Color.Blue
        Me.TB_ProcessType.Location = New System.Drawing.Point(690, 56)
        Me.TB_ProcessType.Name = "TB_ProcessType"
        Me.TB_ProcessType.ReadOnly = True
        Me.TB_ProcessType.Size = New System.Drawing.Size(104, 23)
        Me.TB_ProcessType.TabIndex = 33
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(614, 60)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(70, 14)
        Me.Label21.TabIndex = 34
        Me.Label21.Text = "加工类别:"
        '
        'TB_Contract
        '
        Me.TB_Contract.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.TB_Contract.ForeColor = System.Drawing.Color.Blue
        Me.TB_Contract.Location = New System.Drawing.Point(504, 54)
        Me.TB_Contract.Name = "TB_Contract"
        Me.TB_Contract.ReadOnly = True
        Me.TB_Contract.Size = New System.Drawing.Size(104, 23)
        Me.TB_Contract.TabIndex = 31
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(456, 59)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(42, 14)
        Me.Label20.TabIndex = 32
        Me.Label20.Text = "合同:"
        '
        'TB_CR_LuoSeBzCount
        '
        Me.TB_CR_LuoSeBzCount.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.TB_CR_LuoSeBzCount.ForeColor = System.Drawing.Color.Blue
        Me.TB_CR_LuoSeBzCount.Location = New System.Drawing.Point(690, 90)
        Me.TB_CR_LuoSeBzCount.Name = "TB_CR_LuoSeBzCount"
        Me.TB_CR_LuoSeBzCount.ReadOnly = True
        Me.TB_CR_LuoSeBzCount.Size = New System.Drawing.Size(104, 23)
        Me.TB_CR_LuoSeBzCount.TabIndex = 29
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(614, 95)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(70, 14)
        Me.Label19.TabIndex = 30
        Me.Label19.Text = "落色条数:"
        '
        'TB_BZ_No
        '
        Me.TB_BZ_No.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.TB_BZ_No.ForeColor = System.Drawing.Color.Blue
        Me.TB_BZ_No.Location = New System.Drawing.Point(100, 89)
        Me.TB_BZ_No.Name = "TB_BZ_No"
        Me.TB_BZ_No.ReadOnly = True
        Me.TB_BZ_No.Size = New System.Drawing.Size(111, 23)
        Me.TB_BZ_No.TabIndex = 2
        '
        'TB_Client_No
        '
        Me.TB_Client_No.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.TB_Client_No.ForeColor = System.Drawing.Color.Blue
        Me.TB_Client_No.Location = New System.Drawing.Point(100, 54)
        Me.TB_Client_No.Name = "TB_Client_No"
        Me.TB_Client_No.ReadOnly = True
        Me.TB_Client_No.Size = New System.Drawing.Size(111, 23)
        Me.TB_Client_No.TabIndex = 1
        '
        'TB_TextileFatory
        '
        Me.TB_TextileFatory.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.TB_TextileFatory.ForeColor = System.Drawing.Color.Blue
        Me.TB_TextileFatory.Location = New System.Drawing.Point(505, 89)
        Me.TB_TextileFatory.Name = "TB_TextileFatory"
        Me.TB_TextileFatory.ReadOnly = True
        Me.TB_TextileFatory.Size = New System.Drawing.Size(104, 23)
        Me.TB_TextileFatory.TabIndex = 4
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(24, 93)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(70, 14)
        Me.Label17.TabIndex = 21
        Me.Label17.Text = "布类编号:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(24, 58)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(70, 14)
        Me.Label12.TabIndex = 21
        Me.Label12.Text = "客户编号:"
        '
        'LabelTitle
        '
        Me.LabelTitle.AutoSize = True
        Me.LabelTitle.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LabelTitle.ForeColor = System.Drawing.Color.Blue
        Me.LabelTitle.Location = New System.Drawing.Point(26, 18)
        Me.LabelTitle.Name = "LabelTitle"
        Me.LabelTitle.Size = New System.Drawing.Size(93, 16)
        Me.LabelTitle.TabIndex = 22
        Me.LabelTitle.Text = "生产出布单"
        '
        'BZC_Name
        '
        Me.BZC_Name.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.BZC_Name.ForeColor = System.Drawing.Color.Blue
        Me.BZC_Name.Location = New System.Drawing.Point(290, 124)
        Me.BZC_Name.Name = "BZC_Name"
        Me.BZC_Name.ReadOnly = True
        Me.BZC_Name.Size = New System.Drawing.Size(129, 23)
        Me.BZC_Name.TabIndex = 6
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(242, 128)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(42, 14)
        Me.Label13.TabIndex = 13
        Me.Label13.Text = "颜色:"
        '
        'TB_BZ_Name
        '
        Me.TB_BZ_Name.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.TB_BZ_Name.ForeColor = System.Drawing.Color.Blue
        Me.TB_BZ_Name.Location = New System.Drawing.Point(290, 89)
        Me.TB_BZ_Name.Name = "TB_BZ_Name"
        Me.TB_BZ_Name.ReadOnly = True
        Me.TB_BZ_Name.Size = New System.Drawing.Size(128, 23)
        Me.TB_BZ_Name.TabIndex = 1
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(214, 93)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(70, 14)
        Me.Label11.TabIndex = 13
        Me.Label11.Text = "布类名称:"
        '
        'TB_Client_Name
        '
        Me.TB_Client_Name.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.TB_Client_Name.ForeColor = System.Drawing.Color.Blue
        Me.TB_Client_Name.Location = New System.Drawing.Point(290, 54)
        Me.TB_Client_Name.Name = "TB_Client_Name"
        Me.TB_Client_Name.ReadOnly = True
        Me.TB_Client_Name.Size = New System.Drawing.Size(128, 23)
        Me.TB_Client_Name.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(214, 58)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 14)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "客户名称:"
        '
        'DTP_Date
        '
        Me.DTP_Date.Location = New System.Drawing.Point(653, 15)
        Me.DTP_Date.Name = "DTP_Date"
        Me.DTP_Date.Size = New System.Drawing.Size(124, 23)
        Me.DTP_Date.TabIndex = 18
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(577, 19)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(70, 14)
        Me.Label16.TabIndex = 14
        Me.Label16.Text = "配布日期:"
        '
        'TB_GH
        '
        Me.TB_GH.Location = New System.Drawing.Point(872, 15)
        Me.TB_GH.Name = "TB_GH"
        Me.TB_GH.Size = New System.Drawing.Size(132, 23)
        Me.TB_GH.TabIndex = 0
        '
        'Label_ID
        '
        Me.Label_ID.AutoSize = True
        Me.Label_ID.ForeColor = System.Drawing.Color.Blue
        Me.Label_ID.Location = New System.Drawing.Point(824, 19)
        Me.Label_ID.Name = "Label_ID"
        Me.Label_ID.Size = New System.Drawing.Size(42, 14)
        Me.Label_ID.TabIndex = 14
        Me.Label_ID.Text = "缸号:"
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.BackColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(-4, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(1028, 3)
        Me.Label1.TabIndex = 11
        '
        'Label_Supplier_ID
        '
        Me.Label_Supplier_ID.AutoSize = True
        Me.Label_Supplier_ID.Location = New System.Drawing.Point(456, 93)
        Me.Label_Supplier_ID.Name = "Label_Supplier_ID"
        Me.Label_Supplier_ID.Size = New System.Drawing.Size(42, 14)
        Me.Label_Supplier_ID.TabIndex = 13
        Me.Label_Supplier_ID.Text = "织厂:"
        '
        'GB_List
        '
        Me.GB_List.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GB_List.Controls.Add(Me.TB_YPZL)
        Me.GB_List.Controls.Add(Me.TB_YPQty)
        Me.GB_List.Controls.Add(Me.Label29)
        Me.GB_List.Controls.Add(Me.Label30)
        Me.GB_List.Controls.Add(Me.TB_Input)
        Me.GB_List.Controls.Add(Me.Label26)
        Me.GB_List.Controls.Add(Me.PanelFG)
        Me.GB_List.Controls.Add(Me.TB_RemainZl)
        Me.GB_List.Controls.Add(Me.TB_PWeight)
        Me.GB_List.Controls.Add(Me.TB_RemainQty)
        Me.GB_List.Controls.Add(Me.Label18)
        Me.GB_List.Controls.Add(Me.TB_SumQty)
        Me.GB_List.Controls.Add(Me.Label3)
        Me.GB_List.Controls.Add(Me.Label14)
        Me.GB_List.Controls.Add(Me.Label6)
        Me.GB_List.Controls.Add(Me.Label2)
        Me.GB_List.Location = New System.Drawing.Point(5, 153)
        Me.GB_List.Name = "GB_List"
        Me.GB_List.Size = New System.Drawing.Size(1014, 430)
        Me.GB_List.TabIndex = 4
        Me.GB_List.TabStop = False
        Me.GB_List.Text = "成品录入"
        '
        'TB_YPZL
        '
        Me.TB_YPZL.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TB_YPZL.Location = New System.Drawing.Point(910, 396)
        Me.TB_YPZL.Name = "TB_YPZL"
        Me.TB_YPZL.ReadOnly = True
        Me.TB_YPZL.Size = New System.Drawing.Size(96, 23)
        Me.TB_YPZL.TabIndex = 44
        '
        'TB_YPQty
        '
        Me.TB_YPQty.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TB_YPQty.Location = New System.Drawing.Point(756, 396)
        Me.TB_YPQty.Name = "TB_YPQty"
        Me.TB_YPQty.ReadOnly = True
        Me.TB_YPQty.Size = New System.Drawing.Size(80, 23)
        Me.TB_YPQty.TabIndex = 43
        '
        'Label29
        '
        Me.Label29.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(688, 400)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(70, 14)
        Me.Label29.TabIndex = 46
        Me.Label29.Text = "已配条数:"
        '
        'Label30
        '
        Me.Label30.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(843, 400)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(70, 14)
        Me.Label30.TabIndex = 45
        Me.Label30.Text = "已配重量:"
        '
        'TB_Input
        '
        Me.TB_Input.Location = New System.Drawing.Point(95, 22)
        Me.TB_Input.Name = "TB_Input"
        Me.TB_Input.ReadOnly = True
        Me.TB_Input.Size = New System.Drawing.Size(111, 23)
        Me.TB_Input.TabIndex = 29
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(19, 26)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(70, 14)
        Me.Label26.TabIndex = 30
        Me.Label26.Text = "重量录入:"
        '
        'PanelFG
        '
        Me.PanelFG.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelFG.Controls.Add(Me.Fg2)
        Me.PanelFG.Location = New System.Drawing.Point(6, 51)
        Me.PanelFG.Name = "PanelFG"
        Me.PanelFG.Padding = New System.Windows.Forms.Padding(1)
        Me.PanelFG.Size = New System.Drawing.Size(1002, 335)
        Me.PanelFG.TabIndex = 15
        '
        'Fg2
        '
        Me.Fg2.AutoAddIndex = True
        Me.Fg2.AutoGenerateColumns = False
        Me.Fg2.AutoResize = False
        Me.Fg2.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.Fg2.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.XpThemes
        Me.Fg2.CanEditing = False
        Me.Fg2.ColumnInfo = resources.GetString("Fg2.ColumnInfo")
        Me.Fg2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Fg2.ExtendLastCol = True
        Me.Fg2.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Fg2.ForeColor = System.Drawing.Color.Black
        Me.Fg2.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.Fg2.IsClickStartEdit = False
        Me.Fg2.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.Fg2.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.Fg2.Location = New System.Drawing.Point(1, 1)
        Me.Fg2.Name = "Fg2"
        Me.Fg2.Rows.Count = 10
        Me.Fg2.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.Fg2.Size = New System.Drawing.Size(1000, 333)
        Me.Fg2.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("Fg2.Styles"))
        Me.Fg2.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.BelowData
        Me.Fg2.TabIndex = 1
        '
        'TB_RemainZl
        '
        Me.TB_RemainZl.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TB_RemainZl.Location = New System.Drawing.Point(550, 396)
        Me.TB_RemainZl.Name = "TB_RemainZl"
        Me.TB_RemainZl.ReadOnly = True
        Me.TB_RemainZl.Size = New System.Drawing.Size(111, 23)
        Me.TB_RemainZl.TabIndex = 2
        '
        'TB_PWeight
        '
        Me.TB_PWeight.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TB_PWeight.Location = New System.Drawing.Point(207, 396)
        Me.TB_PWeight.Name = "TB_PWeight"
        Me.TB_PWeight.ReadOnly = True
        Me.TB_PWeight.Size = New System.Drawing.Size(96, 23)
        Me.TB_PWeight.TabIndex = 2
        '
        'TB_RemainQty
        '
        Me.TB_RemainQty.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TB_RemainQty.Location = New System.Drawing.Point(371, 396)
        Me.TB_RemainQty.Name = "TB_RemainQty"
        Me.TB_RemainQty.ReadOnly = True
        Me.TB_RemainQty.Size = New System.Drawing.Size(111, 23)
        Me.TB_RemainQty.TabIndex = 1
        '
        'Label18
        '
        Me.Label18.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(309, 400)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(56, 14)
        Me.Label18.TabIndex = 9
        Me.Label18.Text = "余条数:"
        '
        'TB_SumQty
        '
        Me.TB_SumQty.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TB_SumQty.Location = New System.Drawing.Point(63, 396)
        Me.TB_SumQty.Name = "TB_SumQty"
        Me.TB_SumQty.ReadOnly = True
        Me.TB_SumQty.Size = New System.Drawing.Size(80, 23)
        Me.TB_SumQty.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(488, 400)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 14)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "余胚重:"
        '
        'Label14
        '
        Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(1, 400)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(56, 14)
        Me.Label14.TabIndex = 9
        Me.Label14.Text = "总条数:"
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(150, 400)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 14)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "总胚重:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(204, 247)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(0, 14)
        Me.Label2.TabIndex = 9
        '
        'GB_Foot
        '
        Me.GB_Foot.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GB_Foot.Controls.Add(Me.TB_XiaoZhang)
        Me.GB_Foot.Controls.Add(Me.TB_PB_User)
        Me.GB_Foot.Controls.Add(Me.Label10)
        Me.GB_Foot.Controls.Add(Me.Label9)
        Me.GB_Foot.Controls.Add(Me.Label8)
        Me.GB_Foot.Controls.Add(Me.TB_ZhiDan)
        Me.GB_Foot.Location = New System.Drawing.Point(5, 589)
        Me.GB_Foot.Name = "GB_Foot"
        Me.GB_Foot.Size = New System.Drawing.Size(1013, 44)
        Me.GB_Foot.TabIndex = 3
        Me.GB_Foot.TabStop = False
        '
        'TB_XiaoZhang
        '
        Me.TB_XiaoZhang.Location = New System.Drawing.Point(468, 15)
        Me.TB_XiaoZhang.Name = "TB_XiaoZhang"
        Me.TB_XiaoZhang.ReadOnly = True
        Me.TB_XiaoZhang.Size = New System.Drawing.Size(111, 23)
        Me.TB_XiaoZhang.TabIndex = 16
        Me.TB_XiaoZhang.Visible = False
        '
        'TB_PB_User
        '
        Me.TB_PB_User.Location = New System.Drawing.Point(267, 15)
        Me.TB_PB_User.Name = "TB_PB_User"
        Me.TB_PB_User.ReadOnly = True
        Me.TB_PB_User.Size = New System.Drawing.Size(111, 23)
        Me.TB_PB_User.TabIndex = 15
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(420, 20)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(42, 14)
        Me.Label10.TabIndex = 13
        Me.Label10.Text = "销账:"
        Me.Label10.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(209, 20)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(56, 14)
        Me.Label9.TabIndex = 13
        Me.Label9.Text = "配布人:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(25, 20)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(42, 14)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "制单:"
        '
        'TB_ZhiDan
        '
        Me.TB_ZhiDan.Location = New System.Drawing.Point(82, 16)
        Me.TB_ZhiDan.Name = "TB_ZhiDan"
        Me.TB_ZhiDan.ReadOnly = True
        Me.TB_ZhiDan.Size = New System.Drawing.Size(111, 23)
        Me.TB_ZhiDan.TabIndex = 14
        '
        'F30501_SCCP_Msg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CanMaxSize = True
        Me.Controls.Add(Me.PanelMain)
        Me.Controls.Add(Me.Tool_Top)
        Me.Name = "F30501_SCCP_Msg"
        Me.Size = New System.Drawing.Size(1024, 718)
        Me.Tool_Top.ResumeLayout(False)
        Me.Tool_Top.PerformLayout()
        Me.PanelMain.ResumeLayout(False)
        Me.PanelMain.PerformLayout()
        Me.GB_List.ResumeLayout(False)
        Me.GB_List.PerformLayout()
        Me.PanelFG.ResumeLayout(False)
        CType(Me.Fg2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GB_Foot.ResumeLayout(False)
        Me.GB_Foot.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Tool_Top As System.Windows.Forms.ToolStrip
    Friend WithEvents Cmd_Modify As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Cmd_Exit As System.Windows.Forms.ToolStripButton
    Friend WithEvents PanelMain As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label_Supplier_ID As System.Windows.Forms.Label
    Friend WithEvents GB_Foot As System.Windows.Forms.GroupBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TB_GH As System.Windows.Forms.TextBox
    Friend WithEvents Label_ID As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents DTP_Date As System.Windows.Forms.DateTimePicker
    Friend WithEvents Btn_RemoveRow As System.Windows.Forms.ToolStripButton
    Friend WithEvents LabelTitle As System.Windows.Forms.Label
    Friend WithEvents TB_Client_Name As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TB_TextileFatory As System.Windows.Forms.TextBox
    Friend WithEvents Btn_Preview As System.Windows.Forms.ToolStripButton
    Friend WithEvents Btn_Print As System.Windows.Forms.ToolStripButton
    Friend WithEvents TB_Client_No As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents BZC_Name As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents GB_List As System.Windows.Forms.GroupBox
    Friend WithEvents PanelFG As System.Windows.Forms.Panel
    Friend WithEvents TB_PWeight As System.Windows.Forms.TextBox
    Friend WithEvents TB_SumQty As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TB_BZ_No As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents TB_BZ_Name As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TB_RemainZl As System.Windows.Forms.TextBox
    Friend WithEvents TB_RemainQty As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TB_ZhiDan As System.Windows.Forms.TextBox
    Friend WithEvents TB_XiaoZhang As System.Windows.Forms.TextBox
    Friend WithEvents TB_PB_User As System.Windows.Forms.TextBox
    Friend WithEvents Fg2 As PClass.FG
    Friend WithEvents DTP_Date_LuoSe As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents TB_ProcessType As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents TB_Contract As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents TB_CR_LuoSeBzCount As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents DTP_Date_KaiDan As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents DTP_Date_JiaoHuo As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents BZC_No As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents TB_Input As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents LB_State As System.Windows.Forms.Label
    Friend WithEvents TB_XPQty As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents TB_YPZL As System.Windows.Forms.TextBox
    Friend WithEvents TB_YPQty As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents TB_CR_LuoSeBzZL As System.Windows.Forms.TextBox
    Friend WithEvents Label_CR_LuoSeBzZL As System.Windows.Forms.Label

End Class
