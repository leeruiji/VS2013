<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F10031_GY_Msg
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F10031_GY_Msg))
        Me.Tool_Top = New System.Windows.Forms.ToolStrip
        Me.Cmd_Modify = New System.Windows.Forms.ToolStripButton
        Me.Cmd_Del = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.Cmd_AddRow = New System.Windows.Forms.ToolStripButton
        Me.Cmd_RemoveRow = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.Cmd_Lock = New System.Windows.Forms.ToolStripButton
        Me.Cmd_UnLock = New System.Windows.Forms.ToolStripButton
        Me.Cmd_Invoid = New System.Windows.Forms.ToolStripButton
        Me.Cmd_UnInvoid = New System.Windows.Forms.ToolStripButton
        Me.Cmd_Exit = New System.Windows.Forms.ToolStripButton
        Me.PanelMain = New System.Windows.Forms.Panel
        Me.LB_State = New System.Windows.Forms.Label
        Me.CB_WL_FG = New BaseClass.ComBoList
        Me.Cmd_Clear = New System.Windows.Forms.Button
        Me.Fg1 = New PClass.FG
        Me.Btn_ChooseImage = New System.Windows.Forms.Button
        Me.PB_Image = New System.Windows.Forms.PictureBox
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
        CType(Me.Fg1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PB_Image, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Tool_Top
        '
        Me.Tool_Top.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.Tool_Top.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Cmd_Modify, Me.Cmd_Del, Me.ToolStripSeparator2, Me.Cmd_AddRow, Me.Cmd_RemoveRow, Me.ToolStripSeparator1, Me.Cmd_Lock, Me.Cmd_UnLock, Me.Cmd_Invoid, Me.Cmd_UnInvoid, Me.Cmd_Exit})
        Me.Tool_Top.Location = New System.Drawing.Point(0, 0)
        Me.Tool_Top.MinimumSize = New System.Drawing.Size(0, 40)
        Me.Tool_Top.Name = "Tool_Top"
        Me.Tool_Top.Size = New System.Drawing.Size(799, 40)
        Me.Tool_Top.TabIndex = 10
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
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 40)
        '
        'Cmd_AddRow
        '
        Me.Cmd_AddRow.Image = Global.DN100_BasicInfo.My.Resources.Resources.AddRow
        Me.Cmd_AddRow.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_AddRow.Name = "Cmd_AddRow"
        Me.Cmd_AddRow.Size = New System.Drawing.Size(57, 37)
        Me.Cmd_AddRow.Text = "增行"
        '
        'Cmd_RemoveRow
        '
        Me.Cmd_RemoveRow.Image = CType(resources.GetObject("Cmd_RemoveRow.Image"), System.Drawing.Image)
        Me.Cmd_RemoveRow.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_RemoveRow.Name = "Cmd_RemoveRow"
        Me.Cmd_RemoveRow.Size = New System.Drawing.Size(57, 37)
        Me.Cmd_RemoveRow.Text = "减行"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 40)
        '
        'Cmd_Lock
        '
        Me.Cmd_Lock.Image = Global.DN100_BasicInfo.My.Resources.Resources.GX
        Me.Cmd_Lock.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Lock.Name = "Cmd_Lock"
        Me.Cmd_Lock.Size = New System.Drawing.Size(57, 37)
        Me.Cmd_Lock.Text = "锁定"
        '
        'Cmd_UnLock
        '
        Me.Cmd_UnLock.Image = Global.DN100_BasicInfo.My.Resources.Resources.GY
        Me.Cmd_UnLock.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_UnLock.Name = "Cmd_UnLock"
        Me.Cmd_UnLock.Size = New System.Drawing.Size(57, 37)
        Me.Cmd_UnLock.Text = "解锁"
        '
        'Cmd_Invoid
        '
        Me.Cmd_Invoid.Image = Global.DN100_BasicInfo.My.Resources.Resources.cancel
        Me.Cmd_Invoid.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Invoid.Name = "Cmd_Invoid"
        Me.Cmd_Invoid.Size = New System.Drawing.Size(57, 37)
        Me.Cmd_Invoid.Text = "作废"
        '
        'Cmd_UnInvoid
        '
        Me.Cmd_UnInvoid.Image = Global.DN100_BasicInfo.My.Resources.Resources.ReFresh
        Me.Cmd_UnInvoid.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_UnInvoid.Name = "Cmd_UnInvoid"
        Me.Cmd_UnInvoid.Size = New System.Drawing.Size(69, 37)
        Me.Cmd_UnInvoid.Text = "反作废"
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
        Me.PanelMain.Controls.Add(Me.LB_State)
        Me.PanelMain.Controls.Add(Me.CB_WL_FG)
        Me.PanelMain.Controls.Add(Me.Cmd_Clear)
        Me.PanelMain.Controls.Add(Me.Fg1)
        Me.PanelMain.Controls.Add(Me.Btn_ChooseImage)
        Me.PanelMain.Controls.Add(Me.PB_Image)
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
        Me.PanelMain.Size = New System.Drawing.Size(799, 619)
        Me.PanelMain.TabIndex = 12
        '
        'LB_State
        '
        Me.LB_State.AutoSize = True
        Me.LB_State.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LB_State.Font = New System.Drawing.Font("宋体", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LB_State.ForeColor = System.Drawing.Color.Red
        Me.LB_State.Location = New System.Drawing.Point(42, 8)
        Me.LB_State.Name = "LB_State"
        Me.LB_State.Size = New System.Drawing.Size(2, 21)
        Me.LB_State.TabIndex = 83
        '
        'CB_WL_FG
        '
        Me.CB_WL_FG.Child = "ComboWL"
        Me.CB_WL_FG.FormattingEnabled = True
        Me.CB_WL_FG.IDAsInt = 0
        Me.CB_WL_FG.IDValue = ""
        Me.CB_WL_FG.IsKeyDownAutoSearch = True
        Me.CB_WL_FG.IsSelectName = False
        Me.CB_WL_FG.Location = New System.Drawing.Point(230, -9)
        Me.CB_WL_FG.Name = "CB_WL_FG"
        Me.CB_WL_FG.SearchType = BaseClass.cSearchType.ENum_SearchType.ALL
        Me.CB_WL_FG.Size = New System.Drawing.Size(105, 22)
        Me.CB_WL_FG.TabIndex = 82
        Me.CB_WL_FG.Visible = False
        '
        'Cmd_Clear
        '
        Me.Cmd_Clear.Location = New System.Drawing.Point(39, 134)
        Me.Cmd_Clear.Name = "Cmd_Clear"
        Me.Cmd_Clear.Size = New System.Drawing.Size(72, 37)
        Me.Cmd_Clear.TabIndex = 56
        Me.Cmd_Clear.Text = "清空图片"
        Me.Cmd_Clear.UseVisualStyleBackColor = True
        '
        'Fg1
        '
        Me.Fg1.AddCopyMenu = False
        Me.Fg1.AllowEditing = False
        Me.Fg1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Fg1.AutoAddIndex = True
        Me.Fg1.AutoGenerateColumns = False
        Me.Fg1.AutoResize = False
        Me.Fg1.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.Fg1.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.XpThemes
        Me.Fg1.CanEditing = True
        Me.Fg1.CheckKeyPressEdit = True
        Me.Fg1.ColumnInfo = resources.GetString("Fg1.ColumnInfo")
        Me.Fg1.EditFormat = True
        Me.Fg1.ExtendLastCol = True
        Me.Fg1.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Fg1.ForeColor = System.Drawing.Color.Black
        Me.Fg1.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.Fg1.IsAutoAddRow = True
        Me.Fg1.IsClickStartEdit = True
        Me.Fg1.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.Fg1.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.Fg1.Location = New System.Drawing.Point(7, 379)
        Me.Fg1.Name = "Fg1"
        Me.Fg1.NoShowMenu = False
        Me.Fg1.Rows.Count = 10
        Me.Fg1.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.Fg1.Size = New System.Drawing.Size(782, 235)
        Me.Fg1.StartCol = "WL_No"
        Me.Fg1.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("Fg1.Styles"))
        Me.Fg1.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.BelowData
        Me.Fg1.TabIndex = 31
        '
        'Btn_ChooseImage
        '
        Me.Btn_ChooseImage.Location = New System.Drawing.Point(39, 91)
        Me.Btn_ChooseImage.Name = "Btn_ChooseImage"
        Me.Btn_ChooseImage.Size = New System.Drawing.Size(72, 37)
        Me.Btn_ChooseImage.TabIndex = 30
        Me.Btn_ChooseImage.Text = "图片选择"
        Me.Btn_ChooseImage.UseVisualStyleBackColor = True
        '
        'PB_Image
        '
        Me.PB_Image.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PB_Image.BackColor = System.Drawing.Color.White
        Me.PB_Image.Location = New System.Drawing.Point(120, 91)
        Me.PB_Image.Name = "PB_Image"
        Me.PB_Image.Size = New System.Drawing.Size(545, 282)
        Me.PB_Image.TabIndex = 29
        Me.PB_Image.TabStop = False
        '
        'DP_Found_Date
        '
        Me.DP_Found_Date.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.DP_Found_Date.Enabled = False
        Me.DP_Found_Date.Location = New System.Drawing.Point(889, 594)
        Me.DP_Found_Date.Name = "DP_Found_Date"
        Me.DP_Found_Date.Size = New System.Drawing.Size(115, 23)
        Me.DP_Found_Date.TabIndex = 28
        Me.DP_Found_Date.Visible = False
        '
        'DP_UPD_DATE
        '
        Me.DP_UPD_DATE.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.DP_UPD_DATE.Enabled = False
        Me.DP_UPD_DATE.Location = New System.Drawing.Point(889, 558)
        Me.DP_UPD_DATE.Name = "DP_UPD_DATE"
        Me.DP_UPD_DATE.Size = New System.Drawing.Size(115, 23)
        Me.DP_UPD_DATE.TabIndex = 27
        Me.DP_UPD_DATE.Visible = False
        '
        'TB_Founder
        '
        Me.TB_Founder.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TB_Founder.Location = New System.Drawing.Point(667, 597)
        Me.TB_Founder.Name = "TB_Founder"
        Me.TB_Founder.ReadOnly = True
        Me.TB_Founder.Size = New System.Drawing.Size(115, 23)
        Me.TB_Founder.TabIndex = 25
        Me.TB_Founder.Visible = False
        '
        'TB_UPD_USER
        '
        Me.TB_UPD_USER.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TB_UPD_USER.Location = New System.Drawing.Point(667, 560)
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
        Me.Label6.Location = New System.Drawing.Point(820, 600)
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
        Me.Label23.Location = New System.Drawing.Point(792, 562)
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
        Me.Label5.Location = New System.Drawing.Point(606, 600)
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
        Me.Label22.Location = New System.Drawing.Point(578, 567)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(84, 14)
        Me.Label22.TabIndex = 16
        Me.Label22.Text = "最后修改人:"
        Me.Label22.Visible = False
        '
        'TB_Remark
        '
        Me.TB_Remark.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TB_Remark.Location = New System.Drawing.Point(363, 21)
        Me.TB_Remark.Multiline = True
        Me.TB_Remark.Name = "TB_Remark"
        Me.TB_Remark.Size = New System.Drawing.Size(425, 64)
        Me.TB_Remark.TabIndex = 2
        '
        'TB_ID
        '
        Me.TB_ID.Location = New System.Drawing.Point(120, 30)
        Me.TB_ID.Name = "TB_ID"
        Me.TB_ID.Size = New System.Drawing.Size(111, 23)
        Me.TB_ID.TabIndex = 10
        '
        'TB_Name
        '
        Me.TB_Name.Location = New System.Drawing.Point(120, 62)
        Me.TB_Name.Name = "TB_Name"
        Me.TB_Name.Size = New System.Drawing.Size(237, 23)
        Me.TB_Name.TabIndex = 0
        '
        'TB_SupplierName
        '
        Me.TB_SupplierName.AutoSize = True
        Me.TB_SupplierName.Location = New System.Drawing.Point(43, 34)
        Me.TB_SupplierName.Name = "TB_SupplierName"
        Me.TB_SupplierName.Size = New System.Drawing.Size(70, 14)
        Me.TB_SupplierName.TabIndex = 7
        Me.TB_SupplierName.Text = "工艺编号:"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(315, 24)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(42, 14)
        Me.Label19.TabIndex = 6
        Me.Label19.Text = "备注:"
        '
        'LB_FullName
        '
        Me.LB_FullName.AutoSize = True
        Me.LB_FullName.Location = New System.Drawing.Point(41, 65)
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
        Me.CB_DyingStep.Location = New System.Drawing.Point(581, 3)
        Me.CB_DyingStep.Name = "CB_DyingStep"
        Me.CB_DyingStep.Size = New System.Drawing.Size(111, 22)
        Me.CB_DyingStep.TabIndex = 54
        Me.CB_DyingStep.Visible = False
        '
        'F10031_GY_Msg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CanMaxSize = True
        Me.Controls.Add(Me.CB_DyingStep)
        Me.Controls.Add(Me.PanelMain)
        Me.Controls.Add(Me.Tool_Top)
        Me.Controls.Add(Me.LB_Area)
        Me.Name = "F10031_GY_Msg"
        Me.Size = New System.Drawing.Size(799, 659)
        Me.Title = "工艺详细信息"
        Me.Tool_Top.ResumeLayout(False)
        Me.Tool_Top.PerformLayout()
        Me.PanelMain.ResumeLayout(False)
        Me.PanelMain.PerformLayout()
        CType(Me.Fg1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PB_Image, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Tool_Top As System.Windows.Forms.ToolStrip
    Friend WithEvents Cmd_Modify As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_Del As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
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
    Friend WithEvents PB_Image As System.Windows.Forms.PictureBox
    Friend WithEvents Btn_ChooseImage As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Fg1 As PClass.FG
    Friend WithEvents Cmd_AddRow As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_RemoveRow As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CB_DyingStep As System.Windows.Forms.ComboBox
    Friend WithEvents Cmd_Clear As System.Windows.Forms.Button
    Friend WithEvents CB_WL_FG As BaseClass.ComBoList
    Friend WithEvents Cmd_Lock As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_UnLock As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_Invoid As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_UnInvoid As System.Windows.Forms.ToolStripButton
    Friend WithEvents LB_State As System.Windows.Forms.Label

End Class
