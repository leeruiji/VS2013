<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F28000_Employees_JT
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F28000_Employees_JT))
        Me.Tool_Top = New System.Windows.Forms.ToolStrip()
        Me.Cmd_Modify = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.Cmd_Refresh = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.Cmd_Preview = New System.Windows.Forms.ToolStripSplitButton()
        Me.Cmd_PreView_All = New System.Windows.Forms.ToolStripMenuItem()
        Me.Cmd_Preview_Sel = New System.Windows.Forms.ToolStripMenuItem()
        Me.Cmd_Print = New System.Windows.Forms.ToolStripSplitButton()
        Me.Cmd_Print_All = New System.Windows.Forms.ToolStripMenuItem()
        Me.Cmd_Print_Sel = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.Cmd_Exit = New System.Windows.Forms.ToolStripButton()
        Me.Cmd_Save = New System.Windows.Forms.ToolStripButton()
        Me.CMS_FG1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.TSM_Add = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSM_Del = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSM_Save = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSM_CanSel = New System.Windows.Forms.ToolStripMenuItem()
        Me.PanelMain = New System.Windows.Forms.Panel()
        Me.CB_UserID = New BaseClass.ComBoList()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.Fg1 = New PClass.FG()
        Me.Fg_Spec = New PClass.FG()
        Me.LB_Hide = New System.Windows.Forms.Label()
        Me.Tool_Search = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel4 = New System.Windows.Forms.ToolStripLabel()
        Me.DP_Start = New PClass.ToolStripDateTimePicker()
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel()
        Me.Dp_End = New PClass.ToolStripDateTimePicker()
        Me.CB_State = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.TSC_Client = New BaseClass.ToolStripComboList()
        Me.LB_ID = New System.Windows.Forms.ToolStripLabel()
        Me.TB_ID = New System.Windows.Forms.ToolStripTextBox()
        Me.LB_GZ = New System.Windows.Forms.ToolStripLabel()
        Me.TB_GZ = New System.Windows.Forms.ToolStripTextBox()
        Me.Cmd_Search = New System.Windows.Forms.ToolStripButton()
        Me.TB_eDate = New PClass.ToolStripDateTimePicker()
        Me.Lb_eSdate = New System.Windows.Forms.ToolStripLabel()
        Me.Cb_Gx = New System.Windows.Forms.ToolStripComboBox()
        Me.lb_GX = New System.Windows.Forms.ToolStripLabel()
        Me.Tool_Top.SuspendLayout()
        Me.CMS_FG1.SuspendLayout()
        Me.PanelMain.SuspendLayout()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.Fg1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Fg_Spec, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tool_Search.SuspendLayout()
        Me.SuspendLayout()
        '
        'Tool_Top
        '
        Me.Tool_Top.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.Tool_Top.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Cmd_Modify, Me.ToolStripSeparator4, Me.Cmd_Refresh, Me.ToolStripSeparator3, Me.Cmd_Preview, Me.Cmd_Print, Me.ToolStripSeparator1, Me.Cmd_Exit, Me.Cmd_Save})
        Me.Tool_Top.Location = New System.Drawing.Point(2, 2)
        Me.Tool_Top.MinimumSize = New System.Drawing.Size(0, 40)
        Me.Tool_Top.Name = "Tool_Top"
        Me.Tool_Top.Size = New System.Drawing.Size(973, 40)
        Me.Tool_Top.TabIndex = 10
        Me.Tool_Top.Text = "ToolStrip2"
        '
        'Cmd_Modify
        '
        Me.Cmd_Modify.AccessibleDescription = "修改按钮"
        Me.Cmd_Modify.AccessibleName = ""
        Me.Cmd_Modify.Image = Global.DN280_Bonus.My.Resources.Resources.Modify
        Me.Cmd_Modify.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Modify.Name = "Cmd_Modify"
        Me.Cmd_Modify.Size = New System.Drawing.Size(60, 37)
        Me.Cmd_Modify.Text = "修改"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 40)
        '
        'Cmd_Refresh
        '
        Me.Cmd_Refresh.Image = Global.DN280_Bonus.My.Resources.Resources.ReFresh
        Me.Cmd_Refresh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Refresh.Name = "Cmd_Refresh"
        Me.Cmd_Refresh.Size = New System.Drawing.Size(60, 37)
        Me.Cmd_Refresh.Text = "刷新"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 40)
        '
        'Cmd_Preview
        '
        Me.Cmd_Preview.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Cmd_PreView_All, Me.Cmd_Preview_Sel})
        Me.Cmd_Preview.Image = Global.DN280_Bonus.My.Resources.Resources.Print_preview
        Me.Cmd_Preview.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Preview.Name = "Cmd_Preview"
        Me.Cmd_Preview.Size = New System.Drawing.Size(72, 37)
        Me.Cmd_Preview.Text = "预览"
        '
        'Cmd_PreView_All
        '
        Me.Cmd_PreView_All.Name = "Cmd_PreView_All"
        Me.Cmd_PreView_All.Size = New System.Drawing.Size(148, 22)
        Me.Cmd_PreView_All.Text = "预览当前页面"
        '
        'Cmd_Preview_Sel
        '
        Me.Cmd_Preview_Sel.Name = "Cmd_Preview_Sel"
        Me.Cmd_Preview_Sel.Size = New System.Drawing.Size(148, 22)
        Me.Cmd_Preview_Sel.Text = "预览选择项"
        '
        'Cmd_Print
        '
        Me.Cmd_Print.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Cmd_Print_All, Me.Cmd_Print_Sel})
        Me.Cmd_Print.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Print.Name = "Cmd_Print"
        Me.Cmd_Print.Size = New System.Drawing.Size(48, 37)
        Me.Cmd_Print.Text = "打印"
        '
        'Cmd_Print_All
        '
        Me.Cmd_Print_All.Name = "Cmd_Print_All"
        Me.Cmd_Print_All.Size = New System.Drawing.Size(148, 22)
        Me.Cmd_Print_All.Text = "打印当前页面"
        '
        'Cmd_Print_Sel
        '
        Me.Cmd_Print_Sel.Name = "Cmd_Print_Sel"
        Me.Cmd_Print_Sel.Size = New System.Drawing.Size(148, 22)
        Me.Cmd_Print_Sel.Text = "打印选择项"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 40)
        '
        'Cmd_Exit
        '
        Me.Cmd_Exit.Image = CType(resources.GetObject("Cmd_Exit.Image"), System.Drawing.Image)
        Me.Cmd_Exit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(60, 37)
        Me.Cmd_Exit.Text = "关闭"
        '
        'Cmd_Save
        '
        Me.Cmd_Save.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.Cmd_Save.Image = Global.DN280_Bonus.My.Resources.Resources.save
        Me.Cmd_Save.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Save.Name = "Cmd_Save"
        Me.Cmd_Save.Size = New System.Drawing.Size(60, 37)
        Me.Cmd_Save.Text = "保存"
        '
        'CMS_FG1
        '
        Me.CMS_FG1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSM_Add, Me.TSM_Del, Me.TSM_Save, Me.TSM_CanSel})
        Me.CMS_FG1.Name = "CMS_FG1"
        Me.CMS_FG1.Size = New System.Drawing.Size(149, 92)
        '
        'TSM_Add
        '
        Me.TSM_Add.Name = "TSM_Add"
        Me.TSM_Add.Size = New System.Drawing.Size(148, 22)
        Me.TSM_Add.Text = "增行"
        '
        'TSM_Del
        '
        Me.TSM_Del.Name = "TSM_Del"
        Me.TSM_Del.Size = New System.Drawing.Size(148, 22)
        Me.TSM_Del.Text = "减行"
        '
        'TSM_Save
        '
        Me.TSM_Save.Name = "TSM_Save"
        Me.TSM_Save.Size = New System.Drawing.Size(148, 22)
        Me.TSM_Save.Text = "保存"
        '
        'TSM_CanSel
        '
        Me.TSM_CanSel.Name = "TSM_CanSel"
        Me.TSM_CanSel.Size = New System.Drawing.Size(148, 22)
        Me.TSM_CanSel.Text = "取消完工状态"
        '
        'PanelMain
        '
        Me.PanelMain.Controls.Add(Me.CB_UserID)
        Me.PanelMain.Controls.Add(Me.SplitContainer2)
        Me.PanelMain.Controls.Add(Me.LB_Hide)
        Me.PanelMain.Controls.Add(Me.Tool_Search)
        Me.PanelMain.Controls.Add(Me.Tool_Top)
        Me.PanelMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelMain.Location = New System.Drawing.Point(0, 0)
        Me.PanelMain.Name = "PanelMain"
        Me.PanelMain.Padding = New System.Windows.Forms.Padding(2)
        Me.PanelMain.Size = New System.Drawing.Size(977, 700)
        Me.PanelMain.TabIndex = 12
        '
        'CB_UserID
        '
        Me.CB_UserID.Child = "ComboEmployee"
        Me.CB_UserID.FormattingEnabled = True
        Me.CB_UserID.IDAsInt = CType(0, Long)
        Me.CB_UserID.IDValue = ""
        Me.CB_UserID.IsKeyDownAutoSearch = True
        Me.CB_UserID.IsSelectName = False
        Me.CB_UserID.Location = New System.Drawing.Point(408, 6)
        Me.CB_UserID.Name = "CB_UserID"
        Me.CB_UserID.Size = New System.Drawing.Size(121, 22)
        Me.CB_UserID.TabIndex = 63
        Me.CB_UserID.Visible = False
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(2, 72)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.Fg1)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.Fg_Spec)
        Me.SplitContainer2.Size = New System.Drawing.Size(973, 626)
        Me.SplitContainer2.SplitterDistance = 609
        Me.SplitContainer2.TabIndex = 62
        '
        'Fg1
        '
        Me.Fg1.AddCopyMenu = False
        Me.Fg1.AutoAddIndex = True
        Me.Fg1.AutoGenerateColumns = False
        Me.Fg1.AutoResize = False
        Me.Fg1.BackColor = System.Drawing.Color.White
        Me.Fg1.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.XpThemes
        Me.Fg1.CanEditing = True
        Me.Fg1.CheckKeyPressEdit = True
        Me.Fg1.ColumnInfo = resources.GetString("Fg1.ColumnInfo")
        Me.Fg1.ContextMenuStrip = Me.CMS_FG1
        Me.Fg1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Fg1.EditFormat = True
        Me.Fg1.ExtendLastCol = True
        Me.Fg1.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Fg1.ForeColor = System.Drawing.Color.Black
        Me.Fg1.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.Fg1.IsAutoAddRow = False
        Me.Fg1.IsClickStartEdit = False
        Me.Fg1.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.Fg1.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.Fg1.Location = New System.Drawing.Point(0, 0)
        Me.Fg1.Name = "Fg1"
        Me.Fg1.NoShowMenu = False
        Me.Fg1.Rows.Count = 1
        Me.Fg1.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.Fg1.Size = New System.Drawing.Size(609, 626)
        Me.Fg1.StartCol = ""
        Me.Fg1.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("Fg1.Styles"))
        Me.Fg1.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.BelowData
        Me.Fg1.TabIndex = 14
        '
        'Fg_Spec
        '
        Me.Fg_Spec.AddCopyMenu = False
        Me.Fg_Spec.AutoAddIndex = True
        Me.Fg_Spec.AutoGenerateColumns = False
        Me.Fg_Spec.AutoResize = False
        Me.Fg_Spec.BackColor = System.Drawing.Color.White
        Me.Fg_Spec.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.XpThemes
        Me.Fg_Spec.CanEditing = True
        Me.Fg_Spec.CheckKeyPressEdit = True
        Me.Fg_Spec.ColumnInfo = resources.GetString("Fg_Spec.ColumnInfo")
        Me.Fg_Spec.ContextMenuStrip = Me.CMS_FG1
        Me.Fg_Spec.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Fg_Spec.EditFormat = True
        Me.Fg_Spec.ExtendLastCol = True
        Me.Fg_Spec.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Fg_Spec.ForeColor = System.Drawing.Color.Black
        Me.Fg_Spec.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.Fg_Spec.IsAutoAddRow = True
        Me.Fg_Spec.IsClickStartEdit = True
        Me.Fg_Spec.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.Fg_Spec.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.Fg_Spec.Location = New System.Drawing.Point(0, 0)
        Me.Fg_Spec.Name = "Fg_Spec"
        Me.Fg_Spec.NoShowMenu = False
        Me.Fg_Spec.Rows.Count = 1
        Me.Fg_Spec.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.Fg_Spec.Size = New System.Drawing.Size(360, 626)
        Me.Fg_Spec.StartCol = "User_ID"
        Me.Fg_Spec.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("Fg_Spec.Styles"))
        Me.Fg_Spec.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.BelowData
        Me.Fg_Spec.TabIndex = 32
        '
        'LB_Hide
        '
        Me.LB_Hide.AutoSize = True
        Me.LB_Hide.Location = New System.Drawing.Point(0, 0)
        Me.LB_Hide.Name = "LB_Hide"
        Me.LB_Hide.Size = New System.Drawing.Size(0, 14)
        Me.LB_Hide.TabIndex = 61
        '
        'Tool_Search
        '
        Me.Tool_Search.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel4, Me.DP_Start, Me.ToolStripLabel3, Me.Dp_End, Me.CB_State, Me.ToolStripLabel2, Me.TSC_Client, Me.LB_ID, Me.TB_ID, Me.LB_GZ, Me.TB_GZ, Me.Cmd_Search, Me.TB_eDate, Me.Lb_eSdate, Me.Cb_Gx, Me.lb_GX})
        Me.Tool_Search.Location = New System.Drawing.Point(2, 42)
        Me.Tool_Search.MinimumSize = New System.Drawing.Size(0, 30)
        Me.Tool_Search.Name = "Tool_Search"
        Me.Tool_Search.Size = New System.Drawing.Size(973, 30)
        Me.Tool_Search.TabIndex = 13
        Me.Tool_Search.Text = "ToolStrip1"
        '
        'ToolStripLabel4
        '
        Me.ToolStripLabel4.Margin = New System.Windows.Forms.Padding(0, 1, 2, 2)
        Me.ToolStripLabel4.Name = "ToolStripLabel4"
        Me.ToolStripLabel4.Size = New System.Drawing.Size(20, 27)
        Me.ToolStripLabel4.Text = "从"
        '
        'DP_Start
        '
        Me.DP_Start.Name = "DP_Start"
        Me.DP_Start.Size = New System.Drawing.Size(100, 27)
        Me.DP_Start.Text = "2012-03-02"
        Me.DP_Start.Value = New Date(2012, 3, 2, 0, 0, 0, 0)
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.Margin = New System.Windows.Forms.Padding(0, 1, 2, 2)
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(20, 27)
        Me.ToolStripLabel3.Text = "到"
        '
        'Dp_End
        '
        Me.Dp_End.Name = "Dp_End"
        Me.Dp_End.Size = New System.Drawing.Size(100, 27)
        Me.Dp_End.Text = "2012-03-02"
        Me.Dp_End.Value = New Date(2012, 3, 2, 0, 0, 0, 0)
        '
        'CB_State
        '
        Me.CB_State.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_State.Name = "CB_State"
        Me.CB_State.Size = New System.Drawing.Size(75, 30)
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(44, 27)
        Me.ToolStripLabel2.Text = "客户："
        '
        'TSC_Client
        '
        Me.TSC_Client.Child = "ComboClient"
        Me.TSC_Client.IDAsInt = 0
        Me.TSC_Client.IDValue = "0"
        Me.TSC_Client.IsKeyDownAutoSearch = True
        Me.TSC_Client.Name = "TSC_Client"
        Me.TSC_Client.Size = New System.Drawing.Size(100, 27)
        '
        'LB_ID
        '
        Me.LB_ID.Name = "LB_ID"
        Me.LB_ID.Size = New System.Drawing.Size(56, 27)
        Me.LB_ID.Text = "指令单："
        '
        'TB_ID
        '
        Me.TB_ID.Name = "TB_ID"
        Me.TB_ID.Size = New System.Drawing.Size(100, 30)
        '
        'LB_GZ
        '
        Me.LB_GZ.Name = "LB_GZ"
        Me.LB_GZ.Size = New System.Drawing.Size(35, 27)
        Me.LB_GZ.Text = "工价:"
        '
        'TB_GZ
        '
        Me.TB_GZ.Name = "TB_GZ"
        Me.TB_GZ.Size = New System.Drawing.Size(80, 30)
        '
        'Cmd_Search
        '
        Me.Cmd_Search.Image = CType(resources.GetObject("Cmd_Search.Image"), System.Drawing.Image)
        Me.Cmd_Search.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.Cmd_Search.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Search.Name = "Cmd_Search"
        Me.Cmd_Search.Size = New System.Drawing.Size(68, 27)
        Me.Cmd_Search.Text = "搜索"
        '
        'TB_eDate
        '
        Me.TB_eDate.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.TB_eDate.Name = "TB_eDate"
        Me.TB_eDate.Size = New System.Drawing.Size(100, 27)
        Me.TB_eDate.Text = "2013-11-23"
        Me.TB_eDate.Value = New Date(2013, 11, 23, 0, 0, 0, 0)
        '
        'Lb_eSdate
        '
        Me.Lb_eSdate.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.Lb_eSdate.Name = "Lb_eSdate"
        Me.Lb_eSdate.Size = New System.Drawing.Size(59, 17)
        Me.Lb_eSdate.Text = "录入日期:"
        '
        'Cb_Gx
        '
        Me.Cb_Gx.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.Cb_Gx.Name = "Cb_Gx"
        Me.Cb_Gx.Size = New System.Drawing.Size(80, 25)
        '
        'lb_GX
        '
        Me.lb_GX.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.lb_GX.Name = "lb_GX"
        Me.lb_GX.Size = New System.Drawing.Size(35, 17)
        Me.lb_GX.Text = "工序:"
        '
        'F28000_Employees_JT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.PanelMain)
        Me.Name = "F28000_Employees_JT"
        Me.Size = New System.Drawing.Size(977, 700)
        Me.Tool_Top.ResumeLayout(False)
        Me.Tool_Top.PerformLayout()
        Me.CMS_FG1.ResumeLayout(False)
        Me.PanelMain.ResumeLayout(False)
        Me.PanelMain.PerformLayout()
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.ResumeLayout(False)
        CType(Me.Fg1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Fg_Spec, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tool_Search.ResumeLayout(False)
        Me.Tool_Search.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Tool_Top As System.Windows.Forms.ToolStrip
    Friend WithEvents Cmd_Modify As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_Exit As System.Windows.Forms.ToolStripButton
    Friend WithEvents PanelMain As System.Windows.Forms.Panel
    Friend WithEvents Cmd_Refresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents Tool_Search As System.Windows.Forms.ToolStrip
    Friend WithEvents Cmd_Search As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CB_State As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents CMS_FG1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents LB_ID As System.Windows.Forms.ToolStripLabel
    Friend WithEvents LB_Hide As System.Windows.Forms.Label
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents TB_ID As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents Cmd_Preview As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents Cmd_PreView_All As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Cmd_Print As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents Cmd_Print_All As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Cmd_Preview_Sel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Cmd_Print_Sel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripLabel4 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents DP_Start As PClass.ToolStripDateTimePicker
    Friend WithEvents ToolStripLabel3 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Dp_End As PClass.ToolStripDateTimePicker
    Friend WithEvents TSC_Client As BaseClass.ToolStripComboList
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents Fg1 As PClass.FG
    Friend WithEvents Fg_Spec As PClass.FG
    Friend WithEvents TB_eDate As PClass.ToolStripDateTimePicker
    Friend WithEvents Lb_eSdate As System.Windows.Forms.ToolStripLabel
    Friend WithEvents lb_GX As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Cb_Gx As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents TSM_Add As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSM_Del As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSM_Save As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSM_CanSel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CB_UserID As BaseClass.ComBoList
    Friend WithEvents LB_GZ As System.Windows.Forms.ToolStripLabel
    Friend WithEvents TB_GZ As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents Cmd_Save As System.Windows.Forms.ToolStripButton

End Class
