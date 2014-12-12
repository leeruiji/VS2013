<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F30101_Produce_Msg
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
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.Btn_Preview = New System.Windows.Forms.ToolStripButton
        Me.Btn_Print = New System.Windows.Forms.ToolStripButton
        Me.Cmd_PreViewTM = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.Cmd_Exit = New System.Windows.Forms.ToolStripButton
        Me.PanelMain1 = New System.Windows.Forms.Panel
        Me.Label8 = New System.Windows.Forms.Label
        Me.TB_PWeight = New System.Windows.Forms.TextBox
        Me.Label31 = New System.Windows.Forms.Label
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label_Supplier_ID = New System.Windows.Forms.Label
        Me.PanelDZ = New System.Windows.Forms.Panel
        Me.TB_RanseGH = New System.Windows.Forms.TextBox
        Me.LB_RanseGH = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.TB_Remark = New System.Windows.Forms.TextBox
        Me.LB_Msg = New System.Windows.Forms.Label
        Me.Label28 = New System.Windows.Forms.Label
        Me.LB_State = New System.Windows.Forms.Label
        Me.Label32 = New System.Windows.Forms.Label
        Me.Cmd_Preview = New System.Windows.Forms.Button
        Me.Cmd_CZ = New System.Windows.Forms.Button
        Me.Cmd_Return = New System.Windows.Forms.Button
        Me.TB_GH = New System.Windows.Forms.TextBox
        Me.Label_ID = New System.Windows.Forms.Label
        Me.Panel_Input = New System.Windows.Forms.Panel
        Me.LabelOK = New System.Windows.Forms.Label
        Me.LabelErr = New System.Windows.Forms.Label
        Me.TB_GH_Input = New System.Windows.Forms.TextBox
        Me.Cmd_Input_Exit = New System.Windows.Forms.Button
        Me.Cmd_Input_OK = New System.Windows.Forms.Button
        Me.Label29 = New System.Windows.Forms.Label
        Me.PanelMain = New System.Windows.Forms.Panel
        Me.Tool_Top.SuspendLayout()
        Me.PanelMain1.SuspendLayout()
        Me.PanelDZ.SuspendLayout()
        Me.Panel_Input.SuspendLayout()
        Me.PanelMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'Tool_Top
        '
        Me.Tool_Top.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.Tool_Top.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Cmd_Modify, Me.ToolStripSeparator2, Me.Btn_Preview, Me.Btn_Print, Me.Cmd_PreViewTM, Me.ToolStripSeparator3, Me.Cmd_Exit})
        Me.Tool_Top.Location = New System.Drawing.Point(0, 0)
        Me.Tool_Top.MinimumSize = New System.Drawing.Size(0, 40)
        Me.Tool_Top.Name = "Tool_Top"
        Me.Tool_Top.Size = New System.Drawing.Size(1024, 40)
        Me.Tool_Top.TabIndex = 10
        Me.Tool_Top.Text = "ToolStrip2"
        Me.Tool_Top.Visible = False
        '
        'Cmd_Modify
        '
        Me.Cmd_Modify.AccessibleDescription = "修改按钮"
        Me.Cmd_Modify.AccessibleName = ""
        Me.Cmd_Modify.Image = Global.DN300_Produce.My.Resources.Resources.Modify
        Me.Cmd_Modify.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Modify.Name = "Cmd_Modify"
        Me.Cmd_Modify.Size = New System.Drawing.Size(57, 37)
        Me.Cmd_Modify.Text = "保存"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 40)
        '
        'Btn_Preview
        '
        Me.Btn_Preview.Image = Global.DN300_Produce.My.Resources.Resources.Print_preview
        Me.Btn_Preview.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Btn_Preview.Name = "Btn_Preview"
        Me.Btn_Preview.Size = New System.Drawing.Size(57, 37)
        Me.Btn_Preview.Text = "预览"
        '
        'Btn_Print
        '
        Me.Btn_Print.Image = Global.DN300_Produce.My.Resources.Resources.print
        Me.Btn_Print.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Btn_Print.Name = "Btn_Print"
        Me.Btn_Print.Size = New System.Drawing.Size(57, 37)
        Me.Btn_Print.Text = "打印"
        '
        'Cmd_PreViewTM
        '
        Me.Cmd_PreViewTM.Image = Global.DN300_Produce.My.Resources.Resources.print_previewTm
        Me.Cmd_PreViewTM.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_PreViewTM.Name = "Cmd_PreViewTM"
        Me.Cmd_PreViewTM.Size = New System.Drawing.Size(81, 37)
        Me.Cmd_PreViewTM.Text = "条码预览"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 40)
        '
        'Cmd_Exit
        '
        Me.Cmd_Exit.Image = Global.DN300_Produce.My.Resources.Resources.Close
        Me.Cmd_Exit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(57, 37)
        Me.Cmd_Exit.Text = "关闭"
        '
        'PanelMain1
        '
        Me.PanelMain1.Controls.Add(Me.Label8)
        Me.PanelMain1.Controls.Add(Me.TB_PWeight)
        Me.PanelMain1.Controls.Add(Me.Label31)
        Me.PanelMain1.Controls.Add(Me.BZC_No)
        Me.PanelMain1.Controls.Add(Me.Label25)
        Me.PanelMain1.Controls.Add(Me.DTP_Date_JiaoHuo)
        Me.PanelMain1.Controls.Add(Me.Label24)
        Me.PanelMain1.Controls.Add(Me.DTP_Date_KaiDan)
        Me.PanelMain1.Controls.Add(Me.Label23)
        Me.PanelMain1.Controls.Add(Me.DTP_Date_LuoSe)
        Me.PanelMain1.Controls.Add(Me.Label22)
        Me.PanelMain1.Controls.Add(Me.TB_ProcessType)
        Me.PanelMain1.Controls.Add(Me.Label21)
        Me.PanelMain1.Controls.Add(Me.TB_Contract)
        Me.PanelMain1.Controls.Add(Me.Label20)
        Me.PanelMain1.Controls.Add(Me.TB_CR_LuoSeBzCount)
        Me.PanelMain1.Controls.Add(Me.Label19)
        Me.PanelMain1.Controls.Add(Me.TB_BZ_No)
        Me.PanelMain1.Controls.Add(Me.TB_Client_No)
        Me.PanelMain1.Controls.Add(Me.TB_TextileFatory)
        Me.PanelMain1.Controls.Add(Me.Label17)
        Me.PanelMain1.Controls.Add(Me.Label12)
        Me.PanelMain1.Controls.Add(Me.LabelTitle)
        Me.PanelMain1.Controls.Add(Me.BZC_Name)
        Me.PanelMain1.Controls.Add(Me.Label13)
        Me.PanelMain1.Controls.Add(Me.TB_BZ_Name)
        Me.PanelMain1.Controls.Add(Me.Label11)
        Me.PanelMain1.Controls.Add(Me.TB_Client_Name)
        Me.PanelMain1.Controls.Add(Me.Label4)
        Me.PanelMain1.Controls.Add(Me.DTP_Date)
        Me.PanelMain1.Controls.Add(Me.Label1)
        Me.PanelMain1.Controls.Add(Me.Label_Supplier_ID)
        Me.PanelMain1.Controls.Add(Me.PanelDZ)
        Me.PanelMain1.Controls.Add(Me.Panel_Input)
        Me.PanelMain1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelMain1.Location = New System.Drawing.Point(0, 0)
        Me.PanelMain1.Name = "PanelMain1"
        Me.PanelMain1.Padding = New System.Windows.Forms.Padding(2)
        Me.PanelMain1.Size = New System.Drawing.Size(1024, 603)
        Me.PanelMain1.TabIndex = 0
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.Blue
        Me.Label8.Location = New System.Drawing.Point(795, 14)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(70, 14)
        Me.Label8.TabIndex = 49
        Me.Label8.Text = "开单日期:"
        '
        'TB_PWeight
        '
        Me.TB_PWeight.Location = New System.Drawing.Point(690, 87)
        Me.TB_PWeight.Name = "TB_PWeight"
        Me.TB_PWeight.ReadOnly = True
        Me.TB_PWeight.Size = New System.Drawing.Size(121, 23)
        Me.TB_PWeight.TabIndex = 45
        Me.TB_PWeight.Text = "0"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(614, 89)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(70, 14)
        Me.Label31.TabIndex = 46
        Me.Label31.Text = "胚布重量:"
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
        Me.TB_ProcessType.Location = New System.Drawing.Point(505, 125)
        Me.TB_ProcessType.Name = "TB_ProcessType"
        Me.TB_ProcessType.ReadOnly = True
        Me.TB_ProcessType.Size = New System.Drawing.Size(306, 23)
        Me.TB_ProcessType.TabIndex = 33
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(429, 129)
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
        Me.TB_CR_LuoSeBzCount.Location = New System.Drawing.Point(690, 52)
        Me.TB_CR_LuoSeBzCount.Name = "TB_CR_LuoSeBzCount"
        Me.TB_CR_LuoSeBzCount.ReadOnly = True
        Me.TB_CR_LuoSeBzCount.Size = New System.Drawing.Size(121, 23)
        Me.TB_CR_LuoSeBzCount.TabIndex = 29
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(614, 57)
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
        Me.LabelTitle.Size = New System.Drawing.Size(76, 16)
        Me.LabelTitle.TabIndex = 22
        Me.LabelTitle.Text = "进度更新"
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
        Me.DTP_Date.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DTP_Date.CustomFormat = "yyyy年MM月dd日"
        Me.DTP_Date.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTP_Date.Location = New System.Drawing.Point(875, 11)
        Me.DTP_Date.Name = "DTP_Date"
        Me.DTP_Date.Size = New System.Drawing.Size(124, 23)
        Me.DTP_Date.TabIndex = 18
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
        'PanelDZ
        '
        Me.PanelDZ.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelDZ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelDZ.Controls.Add(Me.TB_RanseGH)
        Me.PanelDZ.Controls.Add(Me.LB_RanseGH)
        Me.PanelDZ.Controls.Add(Me.Label3)
        Me.PanelDZ.Controls.Add(Me.TB_Remark)
        Me.PanelDZ.Controls.Add(Me.LB_Msg)
        Me.PanelDZ.Controls.Add(Me.Label28)
        Me.PanelDZ.Controls.Add(Me.LB_State)
        Me.PanelDZ.Controls.Add(Me.Label32)
        Me.PanelDZ.Controls.Add(Me.Cmd_Preview)
        Me.PanelDZ.Controls.Add(Me.Cmd_CZ)
        Me.PanelDZ.Controls.Add(Me.Cmd_Return)
        Me.PanelDZ.Controls.Add(Me.TB_GH)
        Me.PanelDZ.Controls.Add(Me.Label_ID)
        Me.PanelDZ.Location = New System.Drawing.Point(2, 170)
        Me.PanelDZ.Name = "PanelDZ"
        Me.PanelDZ.Padding = New System.Windows.Forms.Padding(5)
        Me.PanelDZ.Size = New System.Drawing.Size(1020, 431)
        Me.PanelDZ.TabIndex = 0
        '
        'TB_RanseGH
        '
        Me.TB_RanseGH.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TB_RanseGH.Font = New System.Drawing.Font("宋体", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TB_RanseGH.ForeColor = System.Drawing.Color.Blue
        Me.TB_RanseGH.Location = New System.Drawing.Point(69, 325)
        Me.TB_RanseGH.Name = "TB_RanseGH"
        Me.TB_RanseGH.Size = New System.Drawing.Size(152, 31)
        Me.TB_RanseGH.TabIndex = 0
        '
        'LB_RanseGH
        '
        Me.LB_RanseGH.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LB_RanseGH.AutoSize = True
        Me.LB_RanseGH.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LB_RanseGH.ForeColor = System.Drawing.Color.Blue
        Me.LB_RanseGH.Location = New System.Drawing.Point(15, 332)
        Me.LB_RanseGH.Name = "LB_RanseGH"
        Me.LB_RanseGH.Size = New System.Drawing.Size(48, 16)
        Me.LB_RanseGH.TabIndex = 46
        Me.LB_RanseGH.Text = "染缸:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("宋体", 12.0!)
        Me.Label3.Location = New System.Drawing.Point(15, 131)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 16)
        Me.Label3.TabIndex = 44
        Me.Label3.Text = "备注:"
        '
        'TB_Remark
        '
        Me.TB_Remark.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TB_Remark.Location = New System.Drawing.Point(69, 131)
        Me.TB_Remark.Multiline = True
        Me.TB_Remark.Name = "TB_Remark"
        Me.TB_Remark.ReadOnly = True
        Me.TB_Remark.Size = New System.Drawing.Size(743, 177)
        Me.TB_Remark.TabIndex = 43
        '
        'LB_Msg
        '
        Me.LB_Msg.AutoSize = True
        Me.LB_Msg.Font = New System.Drawing.Font("宋体", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LB_Msg.ForeColor = System.Drawing.Color.Orange
        Me.LB_Msg.Location = New System.Drawing.Point(73, 75)
        Me.LB_Msg.Name = "LB_Msg"
        Me.LB_Msg.Size = New System.Drawing.Size(0, 33)
        Me.LB_Msg.TabIndex = 42
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(227, 35)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(70, 14)
        Me.Label28.TabIndex = 44
        Me.Label28.Text = "当前状态:"
        '
        'LB_State
        '
        Me.LB_State.AutoSize = True
        Me.LB_State.ForeColor = System.Drawing.Color.Blue
        Me.LB_State.Location = New System.Drawing.Point(303, 35)
        Me.LB_State.Name = "LB_State"
        Me.LB_State.Size = New System.Drawing.Size(0, 14)
        Me.LB_State.TabIndex = 43
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("宋体", 12.0!)
        Me.Label32.Location = New System.Drawing.Point(15, 80)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(48, 16)
        Me.Label32.TabIndex = 41
        Me.Label32.Text = "提示:"
        '
        'Cmd_Preview
        '
        Me.Cmd_Preview.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cmd_Preview.Font = New System.Drawing.Font("宋体", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Cmd_Preview.Location = New System.Drawing.Point(837, 138)
        Me.Cmd_Preview.Name = "Cmd_Preview"
        Me.Cmd_Preview.Size = New System.Drawing.Size(163, 80)
        Me.Cmd_Preview.TabIndex = 37
        Me.Cmd_Preview.Text = "预览(&/)"
        Me.Cmd_Preview.UseVisualStyleBackColor = True
        '
        'Cmd_CZ
        '
        Me.Cmd_CZ.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cmd_CZ.Enabled = False
        Me.Cmd_CZ.Font = New System.Drawing.Font("宋体", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Cmd_CZ.Location = New System.Drawing.Point(837, 34)
        Me.Cmd_CZ.Name = "Cmd_CZ"
        Me.Cmd_CZ.Size = New System.Drawing.Size(163, 80)
        Me.Cmd_CZ.TabIndex = 1
        Me.Cmd_CZ.Text = "预定(&+)"
        Me.Cmd_CZ.UseVisualStyleBackColor = True
        '
        'Cmd_Return
        '
        Me.Cmd_Return.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cmd_Return.Font = New System.Drawing.Font("宋体", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Cmd_Return.Location = New System.Drawing.Point(837, 248)
        Me.Cmd_Return.Name = "Cmd_Return"
        Me.Cmd_Return.Size = New System.Drawing.Size(163, 80)
        Me.Cmd_Return.TabIndex = 2
        Me.Cmd_Return.Text = "返回(&*)"
        Me.Cmd_Return.UseVisualStyleBackColor = True
        '
        'TB_GH
        '
        Me.TB_GH.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TB_GH.Font = New System.Drawing.Font("宋体", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TB_GH.ForeColor = System.Drawing.Color.Blue
        Me.TB_GH.Location = New System.Drawing.Point(69, 27)
        Me.TB_GH.Name = "TB_GH"
        Me.TB_GH.ReadOnly = True
        Me.TB_GH.Size = New System.Drawing.Size(152, 31)
        Me.TB_GH.TabIndex = 1
        '
        'Label_ID
        '
        Me.Label_ID.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label_ID.AutoSize = True
        Me.Label_ID.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label_ID.ForeColor = System.Drawing.Color.Blue
        Me.Label_ID.Location = New System.Drawing.Point(15, 34)
        Me.Label_ID.Name = "Label_ID"
        Me.Label_ID.Size = New System.Drawing.Size(48, 16)
        Me.Label_ID.TabIndex = 14
        Me.Label_ID.Text = "缸号:"
        '
        'Panel_Input
        '
        Me.Panel_Input.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel_Input.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel_Input.Controls.Add(Me.LabelOK)
        Me.Panel_Input.Controls.Add(Me.LabelErr)
        Me.Panel_Input.Controls.Add(Me.TB_GH_Input)
        Me.Panel_Input.Controls.Add(Me.Cmd_Input_Exit)
        Me.Panel_Input.Controls.Add(Me.Cmd_Input_OK)
        Me.Panel_Input.Controls.Add(Me.Label29)
        Me.Panel_Input.Location = New System.Drawing.Point(2, 170)
        Me.Panel_Input.Name = "Panel_Input"
        Me.Panel_Input.Padding = New System.Windows.Forms.Padding(5)
        Me.Panel_Input.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Panel_Input.Size = New System.Drawing.Size(1020, 431)
        Me.Panel_Input.TabIndex = 0
        '
        'LabelOK
        '
        Me.LabelOK.AutoSize = True
        Me.LabelOK.Font = New System.Drawing.Font("宋体", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LabelOK.ForeColor = System.Drawing.Color.Blue
        Me.LabelOK.Location = New System.Drawing.Point(330, 55)
        Me.LabelOK.Name = "LabelOK"
        Me.LabelOK.Size = New System.Drawing.Size(0, 21)
        Me.LabelOK.TabIndex = 6
        '
        'LabelErr
        '
        Me.LabelErr.AutoSize = True
        Me.LabelErr.Font = New System.Drawing.Font("宋体", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LabelErr.ForeColor = System.Drawing.Color.Red
        Me.LabelErr.Location = New System.Drawing.Point(330, 179)
        Me.LabelErr.Name = "LabelErr"
        Me.LabelErr.Size = New System.Drawing.Size(0, 21)
        Me.LabelErr.TabIndex = 5
        '
        'TB_GH_Input
        '
        Me.TB_GH_Input.Font = New System.Drawing.Font("宋体", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TB_GH_Input.ForeColor = System.Drawing.Color.Blue
        Me.TB_GH_Input.Location = New System.Drawing.Point(503, 104)
        Me.TB_GH_Input.Name = "TB_GH_Input"
        Me.TB_GH_Input.Size = New System.Drawing.Size(267, 44)
        Me.TB_GH_Input.TabIndex = 0
        '
        'Cmd_Input_Exit
        '
        Me.Cmd_Input_Exit.Font = New System.Drawing.Font("宋体", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Cmd_Input_Exit.Location = New System.Drawing.Point(618, 270)
        Me.Cmd_Input_Exit.Name = "Cmd_Input_Exit"
        Me.Cmd_Input_Exit.Size = New System.Drawing.Size(176, 80)
        Me.Cmd_Input_Exit.TabIndex = 3
        Me.Cmd_Input_Exit.Text = "退出(&*)"
        Me.Cmd_Input_Exit.UseVisualStyleBackColor = True
        '
        'Cmd_Input_OK
        '
        Me.Cmd_Input_OK.Font = New System.Drawing.Font("宋体", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Cmd_Input_OK.Location = New System.Drawing.Point(329, 270)
        Me.Cmd_Input_OK.Name = "Cmd_Input_OK"
        Me.Cmd_Input_OK.Size = New System.Drawing.Size(166, 80)
        Me.Cmd_Input_OK.TabIndex = 1
        Me.Cmd_Input_OK.Text = "确定(&+)"
        Me.Cmd_Input_OK.UseVisualStyleBackColor = True
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("宋体", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label29.Location = New System.Drawing.Point(370, 116)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(132, 21)
        Me.Label29.TabIndex = 0
        Me.Label29.Text = "请输入缸号:"
        '
        'PanelMain
        '
        Me.PanelMain.Controls.Add(Me.PanelMain1)
        Me.PanelMain.Controls.Add(Me.Tool_Top)
        Me.PanelMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelMain.Location = New System.Drawing.Point(0, 0)
        Me.PanelMain.Name = "PanelMain"
        Me.PanelMain.Size = New System.Drawing.Size(1024, 603)
        Me.PanelMain.TabIndex = 0
        '
        'F30101_Produce_Msg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CanMaxSize = True
        Me.Controls.Add(Me.PanelMain)
        Me.Name = "F30101_Produce_Msg"
        Me.Size = New System.Drawing.Size(1024, 603)
        Me.Title = "成品重量录入"
        Me.Tool_Top.ResumeLayout(False)
        Me.Tool_Top.PerformLayout()
        Me.PanelMain1.ResumeLayout(False)
        Me.PanelMain1.PerformLayout()
        Me.PanelDZ.ResumeLayout(False)
        Me.PanelDZ.PerformLayout()
        Me.Panel_Input.ResumeLayout(False)
        Me.Panel_Input.PerformLayout()
        Me.PanelMain.ResumeLayout(False)
        Me.PanelMain.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Tool_Top As System.Windows.Forms.ToolStrip
    Friend WithEvents Cmd_Modify As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Cmd_Exit As System.Windows.Forms.ToolStripButton
    Friend WithEvents PanelMain1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label_Supplier_ID As System.Windows.Forms.Label
    Friend WithEvents TB_GH As System.Windows.Forms.TextBox
    Friend WithEvents Label_ID As System.Windows.Forms.Label
    Friend WithEvents DTP_Date As System.Windows.Forms.DateTimePicker
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
    Friend WithEvents TB_BZ_No As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents TB_BZ_Name As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
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
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents LB_State As System.Windows.Forms.Label
    Friend WithEvents TB_PWeight As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents PanelMain As System.Windows.Forms.Panel
    Friend WithEvents Cmd_PreViewTM As System.Windows.Forms.ToolStripButton
    Friend WithEvents PanelDZ As System.Windows.Forms.Panel
    Friend WithEvents Cmd_Return As System.Windows.Forms.Button
    Friend WithEvents Cmd_Preview As System.Windows.Forms.Button
    Friend WithEvents Cmd_CZ As System.Windows.Forms.Button
    Friend WithEvents LB_Msg As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Panel_Input As System.Windows.Forms.Panel
    Friend WithEvents Cmd_Input_Exit As System.Windows.Forms.Button
    Friend WithEvents Cmd_Input_OK As System.Windows.Forms.Button
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents TB_GH_Input As System.Windows.Forms.TextBox
    Friend WithEvents LabelErr As System.Windows.Forms.Label
    Friend WithEvents LabelOK As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TB_Remark As System.Windows.Forms.TextBox
    Friend WithEvents TB_RanseGH As System.Windows.Forms.TextBox
    Friend WithEvents LB_RanseGH As System.Windows.Forms.Label

End Class
