﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F27111_ProduceOrder_Msg
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F27111_ProduceOrder_Msg))
        Me.Tool_Top = New System.Windows.Forms.ToolStrip()
        Me.Cmd_Confirm = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.Cmd_AddRow = New System.Windows.Forms.ToolStripButton()
        Me.Cmd_RemoveRow = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.Cmd_Del = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.Cmd_SetInValid = New System.Windows.Forms.ToolStripButton()
        Me.Cmd_SetValid = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.Cmd_Preview = New System.Windows.Forms.ToolStripButton()
        Me.Cmd_Print = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.Cmd_Audit = New System.Windows.Forms.ToolStripButton()
        Me.Cmd_UnAudit = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.Cmd_Exit = New System.Windows.Forms.ToolStripButton()
        Me.PanelMain = New System.Windows.Forms.Panel()
        Me.LB_ClientOrder = New System.Windows.Forms.Label()
        Me.TB_ClientOrderID = New System.Windows.Forms.TextBox()
        Me.CB_Client_ID = New BaseClass.ComBoList()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TB_Client_Name = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LabelState = New System.Windows.Forms.Label()
        Me.LabelStateT = New System.Windows.Forms.Label()
        Me.TB_Remark = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.LabelTitle = New System.Windows.Forms.Label()
        Me.DTP_sDate = New System.Windows.Forms.DateTimePicker()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TB_ID = New System.Windows.Forms.TextBox()
        Me.Label_ID = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GB_List = New System.Windows.Forms.GroupBox()
        Me.TB_State_User = New System.Windows.Forms.TextBox()
        Me.TB_Upd_User = New System.Windows.Forms.TextBox()
        Me.TB_SumQty = New System.Windows.Forms.TextBox()
        Me.PanelFG = New System.Windows.Forms.Panel()
        Me.Fg1 = New PClass.FG()
        Me.Cmd_GoodsSel = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Employee_List1 = New BaseClass.Employee_List()
        Me.Cmd_UnConfirm = New System.Windows.Forms.ToolStripButton()
        Me.Tool_Top.SuspendLayout()
        Me.PanelMain.SuspendLayout()
        Me.GB_List.SuspendLayout()
        Me.PanelFG.SuspendLayout()
        CType(Me.Fg1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Tool_Top
        '
        Me.Tool_Top.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.Tool_Top.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Cmd_Confirm, Me.ToolStripSeparator4, Me.Cmd_UnConfirm, Me.Cmd_AddRow, Me.Cmd_RemoveRow, Me.ToolStripSeparator2, Me.Cmd_Del, Me.ToolStripSeparator6, Me.Cmd_SetInValid, Me.Cmd_SetValid, Me.ToolStripSeparator1, Me.Cmd_Preview, Me.Cmd_Print, Me.ToolStripSeparator5, Me.Cmd_Audit, Me.Cmd_UnAudit, Me.ToolStripSeparator3, Me.Cmd_Exit})
        Me.Tool_Top.Location = New System.Drawing.Point(0, 0)
        Me.Tool_Top.MinimumSize = New System.Drawing.Size(0, 40)
        Me.Tool_Top.Name = "Tool_Top"
        Me.Tool_Top.Size = New System.Drawing.Size(895, 40)
        Me.Tool_Top.TabIndex = 10
        Me.Tool_Top.Text = "反确认"
        '
        'Cmd_Confirm
        '
        Me.Cmd_Confirm.AccessibleDescription = "修改按钮"
        Me.Cmd_Confirm.AccessibleName = ""
        Me.Cmd_Confirm.Image = Global.DN270_Business.My.Resources.Resources.Modify
        Me.Cmd_Confirm.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Confirm.Name = "Cmd_Confirm"
        Me.Cmd_Confirm.Size = New System.Drawing.Size(60, 37)
        Me.Cmd_Confirm.Text = "确认"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 40)
        '
        'Cmd_AddRow
        '
        Me.Cmd_AddRow.Image = Global.DN270_Business.My.Resources.Resources.AddRow
        Me.Cmd_AddRow.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_AddRow.Name = "Cmd_AddRow"
        Me.Cmd_AddRow.Size = New System.Drawing.Size(60, 37)
        Me.Cmd_AddRow.Text = "增行"
        '
        'Cmd_RemoveRow
        '
        Me.Cmd_RemoveRow.Image = Global.DN270_Business.My.Resources.Resources.RemoveRow
        Me.Cmd_RemoveRow.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_RemoveRow.Name = "Cmd_RemoveRow"
        Me.Cmd_RemoveRow.Size = New System.Drawing.Size(60, 37)
        Me.Cmd_RemoveRow.Text = "减行"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 40)
        '
        'Cmd_Del
        '
        Me.Cmd_Del.AccessibleDescription = "修改按钮"
        Me.Cmd_Del.AccessibleName = ""
        Me.Cmd_Del.Image = Global.DN270_Business.My.Resources.Resources.Delete
        Me.Cmd_Del.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Del.Name = "Cmd_Del"
        Me.Cmd_Del.Size = New System.Drawing.Size(60, 37)
        Me.Cmd_Del.Text = "删除"
        Me.Cmd_Del.Visible = False
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 40)
        '
        'Cmd_SetInValid
        '
        Me.Cmd_SetInValid.AccessibleDescription = "作废按钮"
        Me.Cmd_SetInValid.AccessibleName = ""
        Me.Cmd_SetInValid.Image = Global.DN270_Business.My.Resources.Resources.InValid
        Me.Cmd_SetInValid.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_SetInValid.Name = "Cmd_SetInValid"
        Me.Cmd_SetInValid.Size = New System.Drawing.Size(60, 37)
        Me.Cmd_SetInValid.Text = "作废"
        Me.Cmd_SetInValid.Visible = False
        '
        'Cmd_SetValid
        '
        Me.Cmd_SetValid.AccessibleDescription = "反作废按钮"
        Me.Cmd_SetValid.AccessibleName = ""
        Me.Cmd_SetValid.Image = Global.DN270_Business.My.Resources.Resources.SetValid
        Me.Cmd_SetValid.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_SetValid.Name = "Cmd_SetValid"
        Me.Cmd_SetValid.Size = New System.Drawing.Size(72, 37)
        Me.Cmd_SetValid.Text = "反作废"
        Me.Cmd_SetValid.Visible = False
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 40)
        '
        'Cmd_Preview
        '
        Me.Cmd_Preview.Image = Global.DN270_Business.My.Resources.Resources.Print_preview
        Me.Cmd_Preview.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Preview.Name = "Cmd_Preview"
        Me.Cmd_Preview.Size = New System.Drawing.Size(60, 37)
        Me.Cmd_Preview.Text = "预览"
        '
        'Cmd_Print
        '
        Me.Cmd_Print.Image = Global.DN270_Business.My.Resources.Resources.print
        Me.Cmd_Print.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Print.Name = "Cmd_Print"
        Me.Cmd_Print.Size = New System.Drawing.Size(60, 37)
        Me.Cmd_Print.Text = "打印"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 40)
        '
        'Cmd_Audit
        '
        Me.Cmd_Audit.Image = Global.DN270_Business.My.Resources.Resources.apply
        Me.Cmd_Audit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Audit.Name = "Cmd_Audit"
        Me.Cmd_Audit.Size = New System.Drawing.Size(60, 37)
        Me.Cmd_Audit.Text = "审核"
        Me.Cmd_Audit.Visible = False
        '
        'Cmd_UnAudit
        '
        Me.Cmd_UnAudit.Image = Global.DN270_Business.My.Resources.Resources.cancel
        Me.Cmd_UnAudit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_UnAudit.Name = "Cmd_UnAudit"
        Me.Cmd_UnAudit.Size = New System.Drawing.Size(60, 37)
        Me.Cmd_UnAudit.Text = "反审"
        Me.Cmd_UnAudit.Visible = False
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 40)
        '
        'Cmd_Exit
        '
        Me.Cmd_Exit.Image = Global.DN270_Business.My.Resources.Resources.Close
        Me.Cmd_Exit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(60, 37)
        Me.Cmd_Exit.Text = "关闭"
        '
        'PanelMain
        '
        Me.PanelMain.Controls.Add(Me.LB_ClientOrder)
        Me.PanelMain.Controls.Add(Me.TB_ClientOrderID)
        Me.PanelMain.Controls.Add(Me.CB_Client_ID)
        Me.PanelMain.Controls.Add(Me.Label12)
        Me.PanelMain.Controls.Add(Me.TB_Client_Name)
        Me.PanelMain.Controls.Add(Me.Label4)
        Me.PanelMain.Controls.Add(Me.LabelState)
        Me.PanelMain.Controls.Add(Me.LabelStateT)
        Me.PanelMain.Controls.Add(Me.TB_Remark)
        Me.PanelMain.Controls.Add(Me.Label5)
        Me.PanelMain.Controls.Add(Me.LabelTitle)
        Me.PanelMain.Controls.Add(Me.DTP_sDate)
        Me.PanelMain.Controls.Add(Me.Label16)
        Me.PanelMain.Controls.Add(Me.TB_ID)
        Me.PanelMain.Controls.Add(Me.Label_ID)
        Me.PanelMain.Controls.Add(Me.Label1)
        Me.PanelMain.Controls.Add(Me.GB_List)
        Me.PanelMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelMain.Location = New System.Drawing.Point(0, 40)
        Me.PanelMain.Name = "PanelMain"
        Me.PanelMain.Padding = New System.Windows.Forms.Padding(2)
        Me.PanelMain.Size = New System.Drawing.Size(895, 580)
        Me.PanelMain.TabIndex = 0
        '
        'LB_ClientOrder
        '
        Me.LB_ClientOrder.AutoSize = True
        Me.LB_ClientOrder.Location = New System.Drawing.Point(25, 59)
        Me.LB_ClientOrder.Name = "LB_ClientOrder"
        Me.LB_ClientOrder.Padding = New System.Windows.Forms.Padding(0, 8, 0, 0)
        Me.LB_ClientOrder.Size = New System.Drawing.Size(84, 22)
        Me.LB_ClientOrder.TabIndex = 80
        Me.LB_ClientOrder.Text = "客户订单号:"
        '
        'TB_ClientOrderID
        '
        Me.TB_ClientOrderID.Location = New System.Drawing.Point(113, 62)
        Me.TB_ClientOrderID.Name = "TB_ClientOrderID"
        Me.TB_ClientOrderID.ReadOnly = True
        Me.TB_ClientOrderID.Size = New System.Drawing.Size(134, 23)
        Me.TB_ClientOrderID.TabIndex = 81
        '
        'CB_Client_ID
        '
        Me.CB_Client_ID.Child = "ComboClient"
        Me.CB_Client_ID.FormattingEnabled = True
        Me.CB_Client_ID.IDAsInt = CType(0, Long)
        Me.CB_Client_ID.IDValue = ""
        Me.CB_Client_ID.IsKeyDownAutoSearch = True
        Me.CB_Client_ID.IsSelectName = False
        Me.CB_Client_ID.IsTBLostFocusSelOne = True
        Me.CB_Client_ID.Location = New System.Drawing.Point(334, 63)
        Me.CB_Client_ID.Name = "CB_Client_ID"
        Me.CB_Client_ID.Size = New System.Drawing.Size(100, 22)
        Me.CB_Client_ID.TabIndex = 76
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(258, 67)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(70, 14)
        Me.Label12.TabIndex = 79
        Me.Label12.Text = "客户编号:"
        '
        'TB_Client_Name
        '
        Me.TB_Client_Name.Location = New System.Drawing.Point(517, 62)
        Me.TB_Client_Name.Name = "TB_Client_Name"
        Me.TB_Client_Name.ReadOnly = True
        Me.TB_Client_Name.Size = New System.Drawing.Size(140, 23)
        Me.TB_Client_Name.TabIndex = 77
        Me.TB_Client_Name.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(443, 66)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 14)
        Me.Label4.TabIndex = 78
        Me.Label4.Text = "客户名称:"
        '
        'LabelState
        '
        Me.LabelState.AutoSize = True
        Me.LabelState.BackColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LabelState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LabelState.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LabelState.ForeColor = System.Drawing.Color.Blue
        Me.LabelState.Location = New System.Drawing.Point(231, 15)
        Me.LabelState.Name = "LabelState"
        Me.LabelState.Size = New System.Drawing.Size(37, 16)
        Me.LabelState.TabIndex = 33
        Me.LabelState.Text = "新建"
        '
        'LabelStateT
        '
        Me.LabelStateT.AutoSize = True
        Me.LabelStateT.Location = New System.Drawing.Point(185, 16)
        Me.LabelStateT.Name = "LabelStateT"
        Me.LabelStateT.Size = New System.Drawing.Size(42, 14)
        Me.LabelStateT.TabIndex = 32
        Me.LabelStateT.Text = "状态:"
        '
        'TB_Remark
        '
        Me.TB_Remark.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TB_Remark.Location = New System.Drawing.Point(61, 543)
        Me.TB_Remark.Name = "TB_Remark"
        Me.TB_Remark.Size = New System.Drawing.Size(823, 23)
        Me.TB_Remark.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(13, 546)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(42, 14)
        Me.Label5.TabIndex = 27
        Me.Label5.Text = "备注:"
        '
        'LabelTitle
        '
        Me.LabelTitle.AutoSize = True
        Me.LabelTitle.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LabelTitle.ForeColor = System.Drawing.Color.Blue
        Me.LabelTitle.Location = New System.Drawing.Point(19, 15)
        Me.LabelTitle.Name = "LabelTitle"
        Me.LabelTitle.Size = New System.Drawing.Size(59, 16)
        Me.LabelTitle.TabIndex = 22
        Me.LabelTitle.Text = "生产单"
        '
        'DTP_sDate
        '
        Me.DTP_sDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DTP_sDate.CustomFormat = "yyyy年MM月dd日"
        Me.DTP_sDate.Enabled = False
        Me.DTP_sDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTP_sDate.Location = New System.Drawing.Point(479, 11)
        Me.DTP_sDate.Name = "DTP_sDate"
        Me.DTP_sDate.Size = New System.Drawing.Size(150, 23)
        Me.DTP_sDate.TabIndex = 7
        '
        'Label16
        '
        Me.Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(403, 16)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(70, 14)
        Me.Label16.TabIndex = 14
        Me.Label16.Text = "下单日期:"
        '
        'TB_ID
        '
        Me.TB_ID.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TB_ID.Location = New System.Drawing.Point(741, 11)
        Me.TB_ID.Name = "TB_ID"
        Me.TB_ID.Size = New System.Drawing.Size(125, 23)
        Me.TB_ID.TabIndex = 0
        Me.TB_ID.Text = "系统自动生成单号"
        '
        'Label_ID
        '
        Me.Label_ID.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label_ID.AutoSize = True
        Me.Label_ID.ForeColor = System.Drawing.Color.Blue
        Me.Label_ID.Location = New System.Drawing.Point(665, 16)
        Me.Label_ID.Name = "Label_ID"
        Me.Label_ID.Size = New System.Drawing.Size(70, 14)
        Me.Label_ID.TabIndex = 14
        Me.Label_ID.Text = "生产单号:"
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.BackColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(-4, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(897, 3)
        Me.Label1.TabIndex = 11
        '
        'GB_List
        '
        Me.GB_List.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GB_List.Controls.Add(Me.TB_State_User)
        Me.GB_List.Controls.Add(Me.TB_Upd_User)
        Me.GB_List.Controls.Add(Me.TB_SumQty)
        Me.GB_List.Controls.Add(Me.PanelFG)
        Me.GB_List.Controls.Add(Me.Label9)
        Me.GB_List.Controls.Add(Me.Label8)
        Me.GB_List.Controls.Add(Me.Label14)
        Me.GB_List.Controls.Add(Me.Label2)
        Me.GB_List.Location = New System.Drawing.Point(12, 91)
        Me.GB_List.Name = "GB_List"
        Me.GB_List.Size = New System.Drawing.Size(883, 440)
        Me.GB_List.TabIndex = 6
        Me.GB_List.TabStop = False
        '
        'TB_State_User
        '
        Me.TB_State_User.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TB_State_User.Location = New System.Drawing.Point(754, 406)
        Me.TB_State_User.Name = "TB_State_User"
        Me.TB_State_User.ReadOnly = True
        Me.TB_State_User.Size = New System.Drawing.Size(111, 23)
        Me.TB_State_User.TabIndex = 1
        '
        'TB_Upd_User
        '
        Me.TB_Upd_User.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TB_Upd_User.Location = New System.Drawing.Point(567, 406)
        Me.TB_Upd_User.Name = "TB_Upd_User"
        Me.TB_Upd_User.ReadOnly = True
        Me.TB_Upd_User.Size = New System.Drawing.Size(111, 23)
        Me.TB_Upd_User.TabIndex = 0
        '
        'TB_SumQty
        '
        Me.TB_SumQty.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TB_SumQty.Location = New System.Drawing.Point(322, 406)
        Me.TB_SumQty.Name = "TB_SumQty"
        Me.TB_SumQty.ReadOnly = True
        Me.TB_SumQty.Size = New System.Drawing.Size(82, 23)
        Me.TB_SumQty.TabIndex = 0
        Me.TB_SumQty.Visible = False
        '
        'PanelFG
        '
        Me.PanelFG.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelFG.Controls.Add(Me.Fg1)
        Me.PanelFG.Controls.Add(Me.Cmd_GoodsSel)
        Me.PanelFG.Location = New System.Drawing.Point(6, 22)
        Me.PanelFG.Name = "PanelFG"
        Me.PanelFG.Padding = New System.Windows.Forms.Padding(1)
        Me.PanelFG.Size = New System.Drawing.Size(871, 374)
        Me.PanelFG.TabIndex = 15
        '
        'Fg1
        '
        Me.Fg1.AddCopyMenu = False
        Me.Fg1.AllowEditing = False
        Me.Fg1.AutoAddIndex = True
        Me.Fg1.AutoGenerateColumns = False
        Me.Fg1.AutoResize = False
        Me.Fg1.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.Fg1.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.XpThemes
        Me.Fg1.CanEditing = True
        Me.Fg1.CheckKeyPressEdit = True
        Me.Fg1.ColumnInfo = resources.GetString("Fg1.ColumnInfo")
        Me.Fg1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Fg1.EditFormat = True
        Me.Fg1.ExtendLastCol = True
        Me.Fg1.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Fg1.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.Fg1.IsAutoAddRow = True
        Me.Fg1.IsClickStartEdit = True
        Me.Fg1.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.Fg1.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.Fg1.Location = New System.Drawing.Point(1, 1)
        Me.Fg1.Name = "Fg1"
        Me.Fg1.NoShowMenu = False
        Me.Fg1.Rows.Count = 10
        Me.Fg1.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.Fg1.Size = New System.Drawing.Size(869, 372)
        Me.Fg1.StartCol = ""
        Me.Fg1.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("Fg1.Styles"))
        Me.Fg1.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.BelowData
        Me.Fg1.TabIndex = 0
        '
        'Cmd_GoodsSel
        '
        Me.Cmd_GoodsSel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_GoodsSel.Location = New System.Drawing.Point(381, 100)
        Me.Cmd_GoodsSel.Name = "Cmd_GoodsSel"
        Me.Cmd_GoodsSel.Size = New System.Drawing.Size(17, 20)
        Me.Cmd_GoodsSel.TabIndex = 15
        Me.Cmd_GoodsSel.Text = "…"
        Me.Cmd_GoodsSel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Cmd_GoodsSel.UseVisualStyleBackColor = True
        Me.Cmd_GoodsSel.Visible = False
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(688, 410)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(56, 14)
        Me.Label9.TabIndex = 13
        Me.Label9.Text = "审核人:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(515, 410)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(56, 14)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "制单人:"
        '
        'Label14
        '
        Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(260, 410)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(56, 14)
        Me.Label14.TabIndex = 9
        Me.Label14.Text = "总数量:"
        Me.Label14.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(204, 247)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(0, 14)
        Me.Label2.TabIndex = 9
        '
        'Employee_List1
        '
        Me.Employee_List1.BackColor = System.Drawing.Color.DodgerBlue
        Me.Employee_List1.IsShowAll = True
        Me.Employee_List1.IsTBLostFocusSelOne = True
        Me.Employee_List1.Location = New System.Drawing.Point(-1000, 3)
        Me.Employee_List1.Name = "Employee_List1"
        Me.Employee_List1.SearchId = ""
        Me.Employee_List1.SearchType = BaseClass.Employee_List.ENum_SearchType.ALL
        Me.Employee_List1.Size = New System.Drawing.Size(250, 209)
        Me.Employee_List1.TabIndex = 11
        Me.Employee_List1.Visible = False
        '
        'Cmd_UnConfirm
        '
        Me.Cmd_UnConfirm.Image = Global.DN270_Business.My.Resources.Resources._43
        Me.Cmd_UnConfirm.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_UnConfirm.Name = "Cmd_UnConfirm"
        Me.Cmd_UnConfirm.Size = New System.Drawing.Size(72, 37)
        Me.Cmd_UnConfirm.Text = "反确认"
        '
        'F27111_ProduceOrder_Msg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CanMaxSize = True
        Me.Controls.Add(Me.Employee_List1)
        Me.Controls.Add(Me.PanelMain)
        Me.Controls.Add(Me.Tool_Top)
        Me.ForeColor = System.Drawing.Color.Black
        Me.Name = "F27111_ProduceOrder_Msg"
        Me.Size = New System.Drawing.Size(895, 620)
        Me.Title = "入库单"
        Me.Tool_Top.ResumeLayout(False)
        Me.Tool_Top.PerformLayout()
        Me.PanelMain.ResumeLayout(False)
        Me.PanelMain.PerformLayout()
        Me.GB_List.ResumeLayout(False)
        Me.GB_List.PerformLayout()
        Me.PanelFG.ResumeLayout(False)
        CType(Me.Fg1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Tool_Top As System.Windows.Forms.ToolStrip
    Friend WithEvents Cmd_Confirm As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_Del As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Cmd_Exit As System.Windows.Forms.ToolStripButton
    Friend WithEvents PanelMain As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TB_ID As System.Windows.Forms.TextBox
    Friend WithEvents Label_ID As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents DTP_sDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Cmd_AddRow As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_RemoveRow As System.Windows.Forms.ToolStripButton
    Friend WithEvents LabelTitle As System.Windows.Forms.Label
    Friend WithEvents Cmd_Preview As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_Print As System.Windows.Forms.ToolStripButton
    Friend WithEvents GB_List As System.Windows.Forms.GroupBox
    Friend WithEvents PanelFG As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TB_Remark As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TB_Upd_User As System.Windows.Forms.TextBox
    Friend WithEvents TB_State_User As System.Windows.Forms.TextBox
    Friend WithEvents Fg1 As PClass.FG
    Friend WithEvents Cmd_Audit As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_GoodsSel As System.Windows.Forms.Button
    Friend WithEvents LabelStateT As System.Windows.Forms.Label
    Friend WithEvents LabelState As System.Windows.Forms.Label
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Cmd_SetInValid As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_SetValid As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Cmd_UnAudit As System.Windows.Forms.ToolStripButton
    Friend WithEvents Employee_List1 As BaseClass.Employee_List
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CB_Client_ID As BaseClass.ComBoList
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TB_Client_Name As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents LB_ClientOrder As System.Windows.Forms.Label
    Friend WithEvents TB_ClientOrderID As System.Windows.Forms.TextBox
    Friend WithEvents TB_SumQty As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Cmd_UnConfirm As System.Windows.Forms.ToolStripButton

End Class
