<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F40310_CPIni
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F40310_CPIni))
        Me.Tool_Top = New System.Windows.Forms.ToolStrip
        Me.Cmd_Add = New System.Windows.Forms.ToolStripButton
        Me.Cmd_Modify = New System.Windows.Forms.ToolStripButton
        Me.Cmd_Del = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.Btn_Preview = New System.Windows.Forms.ToolStripButton
        Me.Btn_Print = New System.Windows.Forms.ToolStripButton
        Me.Cmd_Audit = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.Btn_Refresh = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.CK_Zero = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.Cmd_Exit = New System.Windows.Forms.ToolStripButton
        Me.TB_GH = New System.Windows.Forms.ToolStripTextBox
        Me.Serch_GH = New System.Windows.Forms.ToolStripLabel
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator
        Me.LB_RemainZL = New System.Windows.Forms.ToolStripLabel
        Me.ToolStripLabel8 = New System.Windows.Forms.ToolStripLabel
        Me.LB_RemainCount = New System.Windows.Forms.ToolStripLabel
        Me.ToolStripLabel7 = New System.Windows.Forms.ToolStripLabel
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.LB_ZL = New System.Windows.Forms.ToolStripLabel
        Me.LaB_ZL = New System.Windows.Forms.ToolStripLabel
        Me.LB_Qty = New System.Windows.Forms.ToolStripLabel
        Me.ToolStripLabel6 = New System.Windows.Forms.ToolStripLabel
        Me.FG1 = New PClass.FG
        Me.PanelMain = New System.Windows.Forms.Panel
        Me.CB_SearchByDate = New System.Windows.Forms.CheckBox
        Me.Tool_Search = New System.Windows.Forms.ToolStrip
        Me.DP_Start = New PClass.ToolStripDateTimePicker
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel
        Me.DP_End = New PClass.ToolStripDateTimePicker
        Me.ToolStripLabel4 = New System.Windows.Forms.ToolStripLabel
        Me.TSC_Client = New BaseClass.ToolStripComboList
        Me.ToolStripLabel5 = New System.Windows.Forms.ToolStripLabel
        Me.TSC_BZ = New BaseClass.ToolStripComboList
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel
        Me.CB_ConditionName1 = New System.Windows.Forms.ToolStripComboBox
        Me.TB_ConditionValue1 = New System.Windows.Forms.ToolStripTextBox
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel
        Me.CB_ConditionName2 = New System.Windows.Forms.ToolStripComboBox
        Me.CB_ConditionValue2 = New System.Windows.Forms.ToolStripComboBox
        Me.Btn_Search = New System.Windows.Forms.ToolStripButton
        Me.Tool_Top.SuspendLayout()
        CType(Me.FG1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelMain.SuspendLayout()
        Me.Tool_Search.SuspendLayout()
        Me.SuspendLayout()
        '
        'Tool_Top
        '
        Me.Tool_Top.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.Tool_Top.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Cmd_Add, Me.Cmd_Modify, Me.Cmd_Del, Me.ToolStripSeparator2, Me.Btn_Preview, Me.Btn_Print, Me.Cmd_Audit, Me.ToolStripSeparator5, Me.Btn_Refresh, Me.ToolStripSeparator1, Me.CK_Zero, Me.ToolStripSeparator3, Me.Cmd_Exit, Me.TB_GH, Me.Serch_GH, Me.ToolStripSeparator6, Me.LB_RemainZL, Me.ToolStripLabel8, Me.LB_RemainCount, Me.ToolStripLabel7, Me.ToolStripSeparator4, Me.LB_ZL, Me.LaB_ZL, Me.LB_Qty, Me.ToolStripLabel6})
        Me.Tool_Top.Location = New System.Drawing.Point(2, 2)
        Me.Tool_Top.MinimumSize = New System.Drawing.Size(0, 40)
        Me.Tool_Top.Name = "Tool_Top"
        Me.Tool_Top.Size = New System.Drawing.Size(1065, 40)
        Me.Tool_Top.TabIndex = 10
        Me.Tool_Top.Text = "ToolStrip2"
        '
        'Cmd_Add
        '
        Me.Cmd_Add.AccessibleDescription = "新增"
        Me.Cmd_Add.AccessibleName = ""
        Me.Cmd_Add.Image = Global.DN400_Store.My.Resources.Resources.ADD
        Me.Cmd_Add.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Add.Name = "Cmd_Add"
        Me.Cmd_Add.Size = New System.Drawing.Size(57, 37)
        Me.Cmd_Add.Text = "新增"
        '
        'Cmd_Modify
        '
        Me.Cmd_Modify.AccessibleDescription = "修改按钮"
        Me.Cmd_Modify.AccessibleName = ""
        Me.Cmd_Modify.Image = Global.DN400_Store.My.Resources.Resources.Modify
        Me.Cmd_Modify.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Modify.Name = "Cmd_Modify"
        Me.Cmd_Modify.Size = New System.Drawing.Size(57, 37)
        Me.Cmd_Modify.Text = "修改"
        '
        'Cmd_Del
        '
        Me.Cmd_Del.AccessibleDescription = "修改按钮"
        Me.Cmd_Del.AccessibleName = ""
        Me.Cmd_Del.Image = Global.DN400_Store.My.Resources.Resources.Delete
        Me.Cmd_Del.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Del.Name = "Cmd_Del"
        Me.Cmd_Del.Size = New System.Drawing.Size(57, 37)
        Me.Cmd_Del.Text = "删除"
        Me.Cmd_Del.Visible = False
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 40)
        '
        'Btn_Preview
        '
        Me.Btn_Preview.Image = Global.DN400_Store.My.Resources.Resources.Print_preview
        Me.Btn_Preview.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Btn_Preview.Name = "Btn_Preview"
        Me.Btn_Preview.Size = New System.Drawing.Size(57, 37)
        Me.Btn_Preview.Text = "预览"
        Me.Btn_Preview.Visible = False
        '
        'Btn_Print
        '
        Me.Btn_Print.Image = Global.DN400_Store.My.Resources.Resources.print
        Me.Btn_Print.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Btn_Print.Name = "Btn_Print"
        Me.Btn_Print.Size = New System.Drawing.Size(57, 37)
        Me.Btn_Print.Text = "打印"
        Me.Btn_Print.Visible = False
        '
        'Cmd_Audit
        '
        Me.Cmd_Audit.Image = Global.DN400_Store.My.Resources.Resources.apply
        Me.Cmd_Audit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Audit.Name = "Cmd_Audit"
        Me.Cmd_Audit.Size = New System.Drawing.Size(57, 37)
        Me.Cmd_Audit.Text = "审核"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 40)
        '
        'Btn_Refresh
        '
        Me.Btn_Refresh.Image = CType(resources.GetObject("Btn_Refresh.Image"), System.Drawing.Image)
        Me.Btn_Refresh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Btn_Refresh.Name = "Btn_Refresh"
        Me.Btn_Refresh.Size = New System.Drawing.Size(57, 37)
        Me.Btn_Refresh.Text = "刷新"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 40)
        '
        'CK_Zero
        '
        Me.CK_Zero.Checked = True
        Me.CK_Zero.CheckOnClick = True
        Me.CK_Zero.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CK_Zero.Image = Global.DN400_Store.My.Resources.Resources.PeiBu
        Me.CK_Zero.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CK_Zero.Name = "CK_Zero"
        Me.CK_Zero.Size = New System.Drawing.Size(81, 37)
        Me.CK_Zero.Text = "余数非零"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 40)
        '
        'Cmd_Exit
        '
        Me.Cmd_Exit.Image = Global.DN400_Store.My.Resources.Resources.Close
        Me.Cmd_Exit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(57, 37)
        Me.Cmd_Exit.Text = "关闭"
        '
        'TB_GH
        '
        Me.TB_GH.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.TB_GH.Name = "TB_GH"
        Me.TB_GH.Size = New System.Drawing.Size(100, 40)
        '
        'Serch_GH
        '
        Me.Serch_GH.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.Serch_GH.Name = "Serch_GH"
        Me.Serch_GH.Size = New System.Drawing.Size(65, 37)
        Me.Serch_GH.Text = "缸号查找："
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 40)
        '
        'LB_RemainZL
        '
        Me.LB_RemainZL.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.LB_RemainZL.ForeColor = System.Drawing.Color.Blue
        Me.LB_RemainZL.Name = "LB_RemainZL"
        Me.LB_RemainZL.Size = New System.Drawing.Size(11, 37)
        Me.LB_RemainZL.Text = "0"
        '
        'ToolStripLabel8
        '
        Me.ToolStripLabel8.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel8.Name = "ToolStripLabel8"
        Me.ToolStripLabel8.Size = New System.Drawing.Size(53, 37)
        Me.ToolStripLabel8.Text = "余重量："
        '
        'LB_RemainCount
        '
        Me.LB_RemainCount.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.LB_RemainCount.ForeColor = System.Drawing.Color.Blue
        Me.LB_RemainCount.Name = "LB_RemainCount"
        Me.LB_RemainCount.Size = New System.Drawing.Size(11, 37)
        Me.LB_RemainCount.Text = "0"
        '
        'ToolStripLabel7
        '
        Me.ToolStripLabel7.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel7.Name = "ToolStripLabel7"
        Me.ToolStripLabel7.Size = New System.Drawing.Size(53, 37)
        Me.ToolStripLabel7.Text = "余条数："
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 40)
        '
        'LB_ZL
        '
        Me.LB_ZL.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.LB_ZL.ForeColor = System.Drawing.Color.Blue
        Me.LB_ZL.Name = "LB_ZL"
        Me.LB_ZL.Size = New System.Drawing.Size(11, 37)
        Me.LB_ZL.Text = "0"
        '
        'LaB_ZL
        '
        Me.LaB_ZL.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.LaB_ZL.Name = "LaB_ZL"
        Me.LaB_ZL.Size = New System.Drawing.Size(53, 37)
        Me.LaB_ZL.Text = "总重量："
        '
        'LB_Qty
        '
        Me.LB_Qty.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.LB_Qty.ForeColor = System.Drawing.Color.Blue
        Me.LB_Qty.Name = "LB_Qty"
        Me.LB_Qty.Size = New System.Drawing.Size(11, 37)
        Me.LB_Qty.Text = "0"
        '
        'ToolStripLabel6
        '
        Me.ToolStripLabel6.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel6.Name = "ToolStripLabel6"
        Me.ToolStripLabel6.Size = New System.Drawing.Size(53, 37)
        Me.ToolStripLabel6.Text = "总条数："
        '
        'FG1
        '
        Me.FG1.AllowEditing = False
        Me.FG1.AutoAddIndex = True
        Me.FG1.AutoGenerateColumns = False
        Me.FG1.AutoResize = False
        Me.FG1.BackColor = System.Drawing.Color.White
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
        Me.FG1.Location = New System.Drawing.Point(2, 72)
        Me.FG1.Name = "FG1"
        Me.FG1.Rows.Count = 1
        Me.FG1.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.FG1.Size = New System.Drawing.Size(1065, 626)
        Me.FG1.StartCol = ""
        Me.FG1.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("FG1.Styles"))
        Me.FG1.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.BelowData
        Me.FG1.TabIndex = 11
        '
        'PanelMain
        '
        Me.PanelMain.Controls.Add(Me.FG1)
        Me.PanelMain.Controls.Add(Me.CB_SearchByDate)
        Me.PanelMain.Controls.Add(Me.Tool_Search)
        Me.PanelMain.Controls.Add(Me.Tool_Top)
        Me.PanelMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelMain.Location = New System.Drawing.Point(0, 0)
        Me.PanelMain.Name = "PanelMain"
        Me.PanelMain.Padding = New System.Windows.Forms.Padding(2)
        Me.PanelMain.Size = New System.Drawing.Size(1069, 700)
        Me.PanelMain.TabIndex = 12
        '
        'CB_SearchByDate
        '
        Me.CB_SearchByDate.AutoSize = True
        Me.CB_SearchByDate.Checked = True
        Me.CB_SearchByDate.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CB_SearchByDate.Location = New System.Drawing.Point(9, 50)
        Me.CB_SearchByDate.Margin = New System.Windows.Forms.Padding(10, 3, 3, 3)
        Me.CB_SearchByDate.Name = "CB_SearchByDate"
        Me.CB_SearchByDate.Size = New System.Drawing.Size(15, 14)
        Me.CB_SearchByDate.TabIndex = 14
        Me.CB_SearchByDate.UseVisualStyleBackColor = True
        '
        'Tool_Search
        '
        Me.Tool_Search.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DP_Start, Me.ToolStripLabel3, Me.DP_End, Me.ToolStripLabel4, Me.TSC_Client, Me.ToolStripLabel5, Me.TSC_BZ, Me.ToolStripLabel1, Me.CB_ConditionName1, Me.TB_ConditionValue1, Me.ToolStripLabel2, Me.CB_ConditionName2, Me.CB_ConditionValue2, Me.Btn_Search})
        Me.Tool_Search.Location = New System.Drawing.Point(2, 42)
        Me.Tool_Search.MinimumSize = New System.Drawing.Size(0, 30)
        Me.Tool_Search.Name = "Tool_Search"
        Me.Tool_Search.Size = New System.Drawing.Size(1065, 30)
        Me.Tool_Search.TabIndex = 13
        Me.Tool_Search.Text = "ToolStrip1"
        '
        'DP_Start
        '
        Me.DP_Start.Margin = New System.Windows.Forms.Padding(15, 1, 0, 2)
        Me.DP_Start.Name = "DP_Start"
        Me.DP_Start.Size = New System.Drawing.Size(100, 27)
        Me.DP_Start.Text = "2012-03-02"
        Me.DP_Start.Value = New Date(2012, 3, 2, 0, 0, 0, 0)
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.Margin = New System.Windows.Forms.Padding(2, 1, 2, 2)
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(17, 27)
        Me.ToolStripLabel3.Text = "到"
        '
        'DP_End
        '
        Me.DP_End.Name = "DP_End"
        Me.DP_End.Size = New System.Drawing.Size(100, 27)
        Me.DP_End.Text = "2012-03-02"
        Me.DP_End.Value = New Date(2012, 3, 2, 0, 0, 0, 0)
        '
        'ToolStripLabel4
        '
        Me.ToolStripLabel4.Name = "ToolStripLabel4"
        Me.ToolStripLabel4.Size = New System.Drawing.Size(35, 27)
        Me.ToolStripLabel4.Text = "客户:"
        '
        'TSC_Client
        '
        Me.TSC_Client.Child = "ComboClient"
        Me.TSC_Client.IDAsInt = 0
        Me.TSC_Client.IDValue = "0"
        Me.TSC_Client.IsKeyDownAutoSearch = True
        Me.TSC_Client.Name = "TSC_Client"
        Me.TSC_Client.SearchType = BaseClass.cSearchType.ENum_SearchType.ALL
        Me.TSC_Client.Size = New System.Drawing.Size(100, 27)
        '
        'ToolStripLabel5
        '
        Me.ToolStripLabel5.Name = "ToolStripLabel5"
        Me.ToolStripLabel5.Size = New System.Drawing.Size(35, 27)
        Me.ToolStripLabel5.Text = "布种:"
        '
        'TSC_BZ
        '
        Me.TSC_BZ.Child = "ComboBZ"
        Me.TSC_BZ.IDAsInt = 0
        Me.TSC_BZ.IDValue = "0"
        Me.TSC_BZ.IsKeyDownAutoSearch = True
        Me.TSC_BZ.Name = "TSC_BZ"
        Me.TSC_BZ.SearchType = BaseClass.cSearchType.ENum_SearchType.ALL
        Me.TSC_BZ.Size = New System.Drawing.Size(140, 27)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(47, 27)
        Me.ToolStripLabel1.Text = "条件1："
        '
        'CB_ConditionName1
        '
        Me.CB_ConditionName1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CB_ConditionName1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_ConditionName1.Name = "CB_ConditionName1"
        Me.CB_ConditionName1.Size = New System.Drawing.Size(80, 30)
        '
        'TB_ConditionValue1
        '
        Me.TB_ConditionValue1.Name = "TB_ConditionValue1"
        Me.TB_ConditionValue1.Size = New System.Drawing.Size(100, 30)
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(47, 27)
        Me.ToolStripLabel2.Text = "条件2："
        '
        'CB_ConditionName2
        '
        Me.CB_ConditionName2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_ConditionName2.Name = "CB_ConditionName2"
        Me.CB_ConditionName2.Size = New System.Drawing.Size(80, 30)
        '
        'CB_ConditionValue2
        '
        Me.CB_ConditionValue2.Name = "CB_ConditionValue2"
        Me.CB_ConditionValue2.Size = New System.Drawing.Size(120, 30)
        '
        'Btn_Search
        '
        Me.Btn_Search.Image = Global.DN400_Store.My.Resources.Resources.Search
        Me.Btn_Search.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.Btn_Search.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Btn_Search.Name = "Btn_Search"
        Me.Btn_Search.Size = New System.Drawing.Size(65, 36)
        Me.Btn_Search.Text = "搜索"
        '
        'F40310_CPIni
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.PanelMain)
        Me.Name = "F40310_CPIni"
        Me.Size = New System.Drawing.Size(1069, 700)
        Me.Tool_Top.ResumeLayout(False)
        Me.Tool_Top.PerformLayout()
        CType(Me.FG1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelMain.ResumeLayout(False)
        Me.PanelMain.PerformLayout()
        Me.Tool_Search.ResumeLayout(False)
        Me.Tool_Search.PerformLayout()
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
    Friend WithEvents Btn_Refresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents Tool_Search As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents CB_ConditionName1 As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents CB_ConditionName2 As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents CB_ConditionValue2 As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents Btn_Search As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripLabel3 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents TB_ConditionValue1 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents Btn_Preview As System.Windows.Forms.ToolStripButton
    Friend WithEvents Btn_Print As System.Windows.Forms.ToolStripButton
    Friend WithEvents CB_SearchByDate As System.Windows.Forms.CheckBox
    Friend WithEvents Cmd_Audit As System.Windows.Forms.ToolStripButton
    Friend WithEvents DP_Start As PClass.ToolStripDateTimePicker
    Friend WithEvents DP_End As PClass.ToolStripDateTimePicker
    Friend WithEvents ToolStripLabel4 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents TSC_Client As BaseClass.ToolStripComboList
    Friend WithEvents ToolStripLabel5 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents TSC_BZ As BaseClass.ToolStripComboList
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents LB_RemainCount As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabel7 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents LB_ZL As System.Windows.Forms.ToolStripLabel
    Friend WithEvents LaB_ZL As System.Windows.Forms.ToolStripLabel
    Friend WithEvents LB_Qty As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabel6 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CK_Zero As System.Windows.Forms.ToolStripButton
    Friend WithEvents LB_RemainZL As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabel8 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Serch_GH As System.Windows.Forms.ToolStripLabel
    Friend WithEvents TB_GH As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator

End Class
