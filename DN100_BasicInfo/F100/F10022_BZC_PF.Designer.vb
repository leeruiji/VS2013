<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F10022_BZC_PF
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F10022_BZC_PF))
        Me.Tool_Top = New System.Windows.Forms.ToolStrip
        Me.Cmd_Modify = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.Cmd_AddRow = New System.Windows.Forms.ToolStripButton
        Me.Cmd_RemoveRow = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.Cmd_Audit = New System.Windows.Forms.ToolStripButton
        Me.Cmd_UnAudit = New System.Windows.Forms.ToolStripButton
        Me.Btn_Preview = New System.Windows.Forms.ToolStripButton
        Me.Btn_Print = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.Cmd_Exit = New System.Windows.Forms.ToolStripButton
        Me.PanelMain = New System.Windows.Forms.Panel
        Me.CB_AdjusterName = New BaseClass.ComBoList
        Me.CB_FounderName = New BaseClass.ComBoList
        Me.TB_Bzc_No = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.CKB_IsCheck = New System.Windows.Forms.CheckBox
        Me.Fg1 = New PClass.FG
        Me.CKB_IsOK = New System.Windows.Forms.CheckBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.LB_State = New System.Windows.Forms.Label
        Me.DP_FoundDate = New System.Windows.Forms.DateTimePicker
        Me.Label22 = New System.Windows.Forms.Label
        Me.LB_Adjust = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.TB_UpdName = New System.Windows.Forms.TextBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.TB_PF_Name = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.CB_DyingStep = New System.Windows.Forms.ComboBox
        Me.CB_WL_FG = New BaseClass.ComBoList
        Me.Tool_Top.SuspendLayout()
        Me.PanelMain.SuspendLayout()
        CType(Me.Fg1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Tool_Top
        '
        Me.Tool_Top.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.Tool_Top.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Cmd_Modify, Me.ToolStripSeparator2, Me.Cmd_AddRow, Me.Cmd_RemoveRow, Me.ToolStripSeparator5, Me.Cmd_Audit, Me.Cmd_UnAudit, Me.Btn_Preview, Me.Btn_Print, Me.ToolStripSeparator3, Me.Cmd_Exit})
        Me.Tool_Top.Location = New System.Drawing.Point(0, 0)
        Me.Tool_Top.MinimumSize = New System.Drawing.Size(0, 35)
        Me.Tool_Top.Name = "Tool_Top"
        Me.Tool_Top.Size = New System.Drawing.Size(751, 35)
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
        Me.Cmd_Modify.Size = New System.Drawing.Size(57, 32)
        Me.Cmd_Modify.Text = "保存"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 35)
        '
        'Cmd_AddRow
        '
        Me.Cmd_AddRow.Image = Global.DN100_BasicInfo.My.Resources.Resources.AddRow
        Me.Cmd_AddRow.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_AddRow.Name = "Cmd_AddRow"
        Me.Cmd_AddRow.Size = New System.Drawing.Size(57, 32)
        Me.Cmd_AddRow.Text = "增行"
        '
        'Cmd_RemoveRow
        '
        Me.Cmd_RemoveRow.Image = CType(resources.GetObject("Cmd_RemoveRow.Image"), System.Drawing.Image)
        Me.Cmd_RemoveRow.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_RemoveRow.Name = "Cmd_RemoveRow"
        Me.Cmd_RemoveRow.Size = New System.Drawing.Size(57, 32)
        Me.Cmd_RemoveRow.Text = "减行"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 35)
        '
        'Cmd_Audit
        '
        Me.Cmd_Audit.Image = Global.DN100_BasicInfo.My.Resources.Resources.apply
        Me.Cmd_Audit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Audit.Name = "Cmd_Audit"
        Me.Cmd_Audit.Size = New System.Drawing.Size(57, 32)
        Me.Cmd_Audit.Text = "审核"
        '
        'Cmd_UnAudit
        '
        Me.Cmd_UnAudit.Image = Global.DN100_BasicInfo.My.Resources.Resources.cancel
        Me.Cmd_UnAudit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_UnAudit.Name = "Cmd_UnAudit"
        Me.Cmd_UnAudit.Size = New System.Drawing.Size(57, 32)
        Me.Cmd_UnAudit.Text = "反审"
        Me.Cmd_UnAudit.Visible = False
        '
        'Btn_Preview
        '
        Me.Btn_Preview.Image = Global.DN100_BasicInfo.My.Resources.Resources.Print_preview
        Me.Btn_Preview.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Btn_Preview.Name = "Btn_Preview"
        Me.Btn_Preview.Size = New System.Drawing.Size(57, 32)
        Me.Btn_Preview.Text = "预览"
        Me.Btn_Preview.Visible = False
        '
        'Btn_Print
        '
        Me.Btn_Print.Image = Global.DN100_BasicInfo.My.Resources.Resources.print
        Me.Btn_Print.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Btn_Print.Name = "Btn_Print"
        Me.Btn_Print.Size = New System.Drawing.Size(57, 32)
        Me.Btn_Print.Text = "打印"
        Me.Btn_Print.Visible = False
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 35)
        '
        'Cmd_Exit
        '
        Me.Cmd_Exit.Image = Global.DN100_BasicInfo.My.Resources.Resources.Close
        Me.Cmd_Exit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(57, 32)
        Me.Cmd_Exit.Text = "关闭"
        '
        'PanelMain
        '
        Me.PanelMain.Controls.Add(Me.CB_AdjusterName)
        Me.PanelMain.Controls.Add(Me.CB_FounderName)
        Me.PanelMain.Controls.Add(Me.TB_Bzc_No)
        Me.PanelMain.Controls.Add(Me.Label1)
        Me.PanelMain.Controls.Add(Me.CKB_IsCheck)
        Me.PanelMain.Controls.Add(Me.Fg1)
        Me.PanelMain.Controls.Add(Me.CKB_IsOK)
        Me.PanelMain.Controls.Add(Me.Label2)
        Me.PanelMain.Controls.Add(Me.LB_State)
        Me.PanelMain.Controls.Add(Me.DP_FoundDate)
        Me.PanelMain.Controls.Add(Me.Label22)
        Me.PanelMain.Controls.Add(Me.LB_Adjust)
        Me.PanelMain.Controls.Add(Me.Label21)
        Me.PanelMain.Controls.Add(Me.TB_UpdName)
        Me.PanelMain.Controls.Add(Me.Label20)
        Me.PanelMain.Controls.Add(Me.TB_PF_Name)
        Me.PanelMain.Controls.Add(Me.Label12)
        Me.PanelMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelMain.Location = New System.Drawing.Point(0, 35)
        Me.PanelMain.Name = "PanelMain"
        Me.PanelMain.Padding = New System.Windows.Forms.Padding(2)
        Me.PanelMain.Size = New System.Drawing.Size(751, 543)
        Me.PanelMain.TabIndex = 0
        '
        'CB_AdjusterName
        '
        Me.CB_AdjusterName.Child = "ComboEmployee"
        Me.CB_AdjusterName.FormattingEnabled = True
        Me.CB_AdjusterName.IDAsInt = 0
        Me.CB_AdjusterName.IDValue = ""
        Me.CB_AdjusterName.IsKeyDownAutoSearch = True
        Me.CB_AdjusterName.Location = New System.Drawing.Point(310, 55)
        Me.CB_AdjusterName.Name = "CB_AdjusterName"
        Me.CB_AdjusterName.SearchID = "E_lab"
        Me.CB_AdjusterName.SearchType = BaseClass.cSearchType.ENum_SearchType.FormatSet
        Me.CB_AdjusterName.Size = New System.Drawing.Size(137, 22)
        Me.CB_AdjusterName.TabIndex = 2
        '
        'CB_FounderName
        '
        Me.CB_FounderName.Child = "ComboEmployee"
        Me.CB_FounderName.FormattingEnabled = True
        Me.CB_FounderName.IDAsInt = 0
        Me.CB_FounderName.IDValue = ""
        Me.CB_FounderName.IsKeyDownAutoSearch = True
        Me.CB_FounderName.Location = New System.Drawing.Point(80, 54)
        Me.CB_FounderName.Name = "CB_FounderName"
        Me.CB_FounderName.SearchID = "E_lab"
        Me.CB_FounderName.SearchType = BaseClass.cSearchType.ENum_SearchType.FormatSet
        Me.CB_FounderName.Size = New System.Drawing.Size(134, 22)
        Me.CB_FounderName.TabIndex = 1
        '
        'TB_Bzc_No
        '
        Me.TB_Bzc_No.ForeColor = System.Drawing.Color.Blue
        Me.TB_Bzc_No.Location = New System.Drawing.Point(310, 17)
        Me.TB_Bzc_No.Name = "TB_Bzc_No"
        Me.TB_Bzc_No.ReadOnly = True
        Me.TB_Bzc_No.Size = New System.Drawing.Size(137, 23)
        Me.TB_Bzc_No.TabIndex = 53
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(262, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 14)
        Me.Label1.TabIndex = 54
        Me.Label1.Text = "色号:"
        '
        'CKB_IsCheck
        '
        Me.CKB_IsCheck.AutoSize = True
        Me.CKB_IsCheck.Enabled = False
        Me.CKB_IsCheck.Location = New System.Drawing.Point(660, 57)
        Me.CKB_IsCheck.Name = "CKB_IsCheck"
        Me.CKB_IsCheck.Size = New System.Drawing.Size(54, 18)
        Me.CKB_IsCheck.TabIndex = 52
        Me.CKB_IsCheck.Text = "审核"
        Me.CKB_IsCheck.UseVisualStyleBackColor = True
        '
        'Fg1
        '
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
        Me.Fg1.Location = New System.Drawing.Point(5, 97)
        Me.Fg1.Name = "Fg1"
        Me.Fg1.Rows.Count = 10
        Me.Fg1.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.Fg1.Size = New System.Drawing.Size(741, 441)
        Me.Fg1.StartCol = "WL_No"
        Me.Fg1.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("Fg1.Styles"))
        Me.Fg1.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.BelowData
        Me.Fg1.TabIndex = 5
        '
        'CKB_IsOK
        '
        Me.CKB_IsOK.AutoSize = True
        Me.CKB_IsOK.Enabled = False
        Me.CKB_IsOK.Location = New System.Drawing.Point(660, 22)
        Me.CKB_IsOK.Name = "CKB_IsOK"
        Me.CKB_IsOK.Size = New System.Drawing.Size(82, 18)
        Me.CKB_IsOK.TabIndex = 50
        Me.CKB_IsOK.Text = "客户选择"
        Me.CKB_IsOK.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(503, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(0, 14)
        Me.Label2.TabIndex = 43
        '
        'LB_State
        '
        Me.LB_State.AutoSize = True
        Me.LB_State.ForeColor = System.Drawing.Color.Blue
        Me.LB_State.Location = New System.Drawing.Point(506, 21)
        Me.LB_State.Name = "LB_State"
        Me.LB_State.Size = New System.Drawing.Size(0, 14)
        Me.LB_State.TabIndex = 43
        '
        'DP_FoundDate
        '
        Me.DP_FoundDate.CustomFormat = "yyyy-MM-dd"
        Me.DP_FoundDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DP_FoundDate.Location = New System.Drawing.Point(550, 17)
        Me.DP_FoundDate.Name = "DP_FoundDate"
        Me.DP_FoundDate.Size = New System.Drawing.Size(104, 23)
        Me.DP_FoundDate.TabIndex = 4
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(474, 21)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(70, 14)
        Me.Label22.TabIndex = 35
        Me.Label22.Text = "送板日期:"
        '
        'LB_Adjust
        '
        Me.LB_Adjust.AutoSize = True
        Me.LB_Adjust.Location = New System.Drawing.Point(248, 58)
        Me.LB_Adjust.Name = "LB_Adjust"
        Me.LB_Adjust.Size = New System.Drawing.Size(56, 14)
        Me.LB_Adjust.TabIndex = 34
        Me.LB_Adjust.Text = "调方人:"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(18, 58)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(63, 14)
        Me.Label21.TabIndex = 34
        Me.Label21.Text = "打板员："
        '
        'TB_UpdName
        '
        Me.TB_UpdName.ForeColor = System.Drawing.Color.Blue
        Me.TB_UpdName.Location = New System.Drawing.Point(550, 54)
        Me.TB_UpdName.Name = "TB_UpdName"
        Me.TB_UpdName.ReadOnly = True
        Me.TB_UpdName.Size = New System.Drawing.Size(104, 23)
        Me.TB_UpdName.TabIndex = 3
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(488, 58)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(56, 14)
        Me.Label20.TabIndex = 32
        Me.Label20.Text = "修改人:"
        '
        'TB_PF_Name
        '
        Me.TB_PF_Name.ForeColor = System.Drawing.Color.Blue
        Me.TB_PF_Name.Location = New System.Drawing.Point(80, 17)
        Me.TB_PF_Name.Name = "TB_PF_Name"
        Me.TB_PF_Name.Size = New System.Drawing.Size(134, 23)
        Me.TB_PF_Name.TabIndex = 0
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(18, 21)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(56, 14)
        Me.Label12.TabIndex = 21
        Me.Label12.Text = "色板号:"
        '
        'CB_DyingStep
        '
        Me.CB_DyingStep.FormattingEnabled = True
        Me.CB_DyingStep.Location = New System.Drawing.Point(563, 7)
        Me.CB_DyingStep.Name = "CB_DyingStep"
        Me.CB_DyingStep.Size = New System.Drawing.Size(111, 22)
        Me.CB_DyingStep.TabIndex = 53
        Me.CB_DyingStep.Visible = False
        '
        'CB_WL_FG
        '
        Me.CB_WL_FG.Child = "ComboWL"
        Me.CB_WL_FG.FormattingEnabled = True
        Me.CB_WL_FG.IDAsInt = 0
        Me.CB_WL_FG.IDValue = ""
        Me.CB_WL_FG.IsKeyDownAutoSearch = True
        Me.CB_WL_FG.IsSelectName = False
        Me.CB_WL_FG.Location = New System.Drawing.Point(398, 24)
        Me.CB_WL_FG.Name = "CB_WL_FG"
        Me.CB_WL_FG.SearchType = BaseClass.cSearchType.ENum_SearchType.ALL
        Me.CB_WL_FG.Size = New System.Drawing.Size(105, 22)
        Me.CB_WL_FG.TabIndex = 80
        Me.CB_WL_FG.Visible = False
        '
        'F10022_BZC_PF
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CanMaxSize = True
        Me.Controls.Add(Me.CB_WL_FG)
        Me.Controls.Add(Me.CB_DyingStep)
        Me.Controls.Add(Me.PanelMain)
        Me.Controls.Add(Me.Tool_Top)
        Me.Name = "F10022_BZC_PF"
        Me.Size = New System.Drawing.Size(751, 578)
        Me.Title = "色板明细"
        Me.Tool_Top.ResumeLayout(False)
        Me.Tool_Top.PerformLayout()
        Me.PanelMain.ResumeLayout(False)
        Me.PanelMain.PerformLayout()
        CType(Me.Fg1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Tool_Top As System.Windows.Forms.ToolStrip
    Friend WithEvents Cmd_Modify As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Cmd_Exit As System.Windows.Forms.ToolStripButton
    Friend WithEvents PanelMain As System.Windows.Forms.Panel
    Friend WithEvents Cmd_RemoveRow As System.Windows.Forms.ToolStripButton
    Friend WithEvents Btn_Preview As System.Windows.Forms.ToolStripButton
    Friend WithEvents Btn_Print As System.Windows.Forms.ToolStripButton
    Friend WithEvents TB_PF_Name As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents TB_UpdName As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents LB_State As System.Windows.Forms.Label
    Friend WithEvents DP_FoundDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents CKB_IsOK As System.Windows.Forms.CheckBox
    Friend WithEvents Fg1 As PClass.FG
    Friend WithEvents Cmd_AddRow As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CB_DyingStep As System.Windows.Forms.ComboBox
    Friend WithEvents LB_Adjust As System.Windows.Forms.Label
    Friend WithEvents Cmd_Audit As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_UnAudit As System.Windows.Forms.ToolStripButton
    Friend WithEvents CKB_IsCheck As System.Windows.Forms.CheckBox
    Friend WithEvents TB_Bzc_No As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CB_WL_FG As BaseClass.ComBoList
    Friend WithEvents CB_FounderName As BaseClass.ComBoList
    Friend WithEvents CB_AdjusterName As BaseClass.ComBoList

End Class
