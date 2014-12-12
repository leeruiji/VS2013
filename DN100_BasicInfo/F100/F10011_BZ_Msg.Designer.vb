<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F10011_BZ_Msg
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F10011_BZ_Msg))
        Me.Tool_Top = New System.Windows.Forms.ToolStrip
        Me.Cmd_Modify = New System.Windows.Forms.ToolStripButton
        Me.Cmd_Del = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.Cmd_UnDisable = New System.Windows.Forms.ToolStripButton
        Me.Cmd_Disable = New System.Windows.Forms.ToolStripButton
        Me.Cmd_Exit = New System.Windows.Forms.ToolStripButton
        Me.PanelMain = New System.Windows.Forms.Panel
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.FG1 = New PClass.FG
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.CB_BZ_FG = New BaseClass.ToolStripComboList
        Me.Cmd_Combine = New System.Windows.Forms.ToolStripButton
        Me.Cmd_Add = New System.Windows.Forms.ToolStripButton
        Me.Cmd_Remove = New System.Windows.Forms.ToolStripButton
        Me.Btn_Refresh = New System.Windows.Forms.ToolStripButton
        Me.Label7 = New System.Windows.Forms.Label
        Me.TB_CP_Name = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.TB_CP_No = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Btn_ChoseParent = New System.Windows.Forms.Button
        Me.DP_Found_Date = New System.Windows.Forms.DateTimePicker
        Me.DP_UPD_DATE = New System.Windows.Forms.DateTimePicker
        Me.TB_Founder = New System.Windows.Forms.TextBox
        Me.TB_UPD_USER = New System.Windows.Forms.TextBox
        Me.TB_Remark = New System.Windows.Forms.TextBox
        Me.TB_Spec = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.TB_ID = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.TB_Name = New System.Windows.Forms.TextBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label_ID = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.TB_GoodsType = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.LB_FullName = New System.Windows.Forms.Label
        Me.LB_State = New System.Windows.Forms.ToolStripLabel
        Me.Lb1 = New System.Windows.Forms.ToolStripLabel
        Me.Tool_Top.SuspendLayout()
        Me.PanelMain.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.FG1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Tool_Top
        '
        Me.Tool_Top.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.Tool_Top.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Cmd_Modify, Me.Cmd_Del, Me.ToolStripSeparator5, Me.Cmd_UnDisable, Me.Cmd_Disable, Me.Cmd_Exit, Me.LB_State, Me.Lb1})
        Me.Tool_Top.Location = New System.Drawing.Point(0, 0)
        Me.Tool_Top.MinimumSize = New System.Drawing.Size(0, 40)
        Me.Tool_Top.Name = "Tool_Top"
        Me.Tool_Top.Size = New System.Drawing.Size(962, 40)
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
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 40)
        '
        'Cmd_UnDisable
        '
        Me.Cmd_UnDisable.Image = Global.DN100_BasicInfo.My.Resources.Resources.bt_play
        Me.Cmd_UnDisable.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_UnDisable.Name = "Cmd_UnDisable"
        Me.Cmd_UnDisable.Size = New System.Drawing.Size(57, 37)
        Me.Cmd_UnDisable.Text = "启用"
        '
        'Cmd_Disable
        '
        Me.Cmd_Disable.Image = Global.DN100_BasicInfo.My.Resources.Resources.bt_stop
        Me.Cmd_Disable.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Disable.Name = "Cmd_Disable"
        Me.Cmd_Disable.Size = New System.Drawing.Size(57, 37)
        Me.Cmd_Disable.Text = "禁用"
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
        Me.PanelMain.Controls.Add(Me.GroupBox1)
        Me.PanelMain.Controls.Add(Me.Label7)
        Me.PanelMain.Controls.Add(Me.TB_CP_Name)
        Me.PanelMain.Controls.Add(Me.Label4)
        Me.PanelMain.Controls.Add(Me.TB_CP_No)
        Me.PanelMain.Controls.Add(Me.Label3)
        Me.PanelMain.Controls.Add(Me.Label2)
        Me.PanelMain.Controls.Add(Me.Btn_ChoseParent)
        Me.PanelMain.Controls.Add(Me.DP_Found_Date)
        Me.PanelMain.Controls.Add(Me.DP_UPD_DATE)
        Me.PanelMain.Controls.Add(Me.TB_Founder)
        Me.PanelMain.Controls.Add(Me.TB_UPD_USER)
        Me.PanelMain.Controls.Add(Me.TB_Remark)
        Me.PanelMain.Controls.Add(Me.TB_Spec)
        Me.PanelMain.Controls.Add(Me.Label6)
        Me.PanelMain.Controls.Add(Me.Label23)
        Me.PanelMain.Controls.Add(Me.Label8)
        Me.PanelMain.Controls.Add(Me.TB_ID)
        Me.PanelMain.Controls.Add(Me.Label5)
        Me.PanelMain.Controls.Add(Me.TB_Name)
        Me.PanelMain.Controls.Add(Me.Label22)
        Me.PanelMain.Controls.Add(Me.Label_ID)
        Me.PanelMain.Controls.Add(Me.Label19)
        Me.PanelMain.Controls.Add(Me.TB_GoodsType)
        Me.PanelMain.Controls.Add(Me.Label1)
        Me.PanelMain.Controls.Add(Me.LB_FullName)
        Me.PanelMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelMain.Location = New System.Drawing.Point(0, 40)
        Me.PanelMain.Name = "PanelMain"
        Me.PanelMain.Padding = New System.Windows.Forms.Padding(2)
        Me.PanelMain.Size = New System.Drawing.Size(962, 397)
        Me.PanelMain.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.FG1)
        Me.GroupBox1.Controls.Add(Me.ToolStrip1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.GroupBox1.Location = New System.Drawing.Point(545, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(415, 393)
        Me.GroupBox1.TabIndex = 25
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "相关的布种"
        '
        'FG1
        '
        Me.FG1.AddCopyMenu = False
        Me.FG1.AllowEditing = False
        Me.FG1.AutoAddIndex = True
        Me.FG1.AutoGenerateColumns = False
        Me.FG1.AutoResize = False
        Me.FG1.BackColor = System.Drawing.Color.White
        Me.FG1.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.XpThemes
        Me.FG1.CanEditing = False
        Me.FG1.CheckKeyPressEdit = True
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
        Me.FG1.Location = New System.Drawing.Point(3, 44)
        Me.FG1.Name = "FG1"
        Me.FG1.NoShowMenu = False
        Me.FG1.Rows.Count = 10
        Me.FG1.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.FG1.Size = New System.Drawing.Size(409, 346)
        Me.FG1.StartCol = ""
        Me.FG1.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("FG1.Styles"))
        Me.FG1.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.BelowData
        Me.FG1.TabIndex = 24
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CB_BZ_FG, Me.Cmd_Combine, Me.Cmd_Add, Me.Cmd_Remove, Me.Btn_Refresh})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 19)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(409, 25)
        Me.ToolStrip1.TabIndex = 25
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'CB_BZ_FG
        '
        Me.CB_BZ_FG.Child = "ComboBZ"
        Me.CB_BZ_FG.IDAsInt = 0
        Me.CB_BZ_FG.IDValue = "0"
        Me.CB_BZ_FG.IsKeyDownAutoSearch = True
        Me.CB_BZ_FG.Name = "CB_BZ_FG"
        Me.CB_BZ_FG.SearchType = BaseClass.cSearchType.ENum_SearchType.ALL
        Me.CB_BZ_FG.Size = New System.Drawing.Size(140, 22)
        '
        'Cmd_Combine
        '
        Me.Cmd_Combine.AccessibleDescription = "合并"
        Me.Cmd_Combine.AccessibleName = ""
        Me.Cmd_Combine.Image = Global.DN100_BasicInfo.My.Resources.Resources.ADD
        Me.Cmd_Combine.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Combine.Name = "Cmd_Combine"
        Me.Cmd_Combine.Size = New System.Drawing.Size(49, 22)
        Me.Cmd_Combine.Text = "合并"
        '
        'Cmd_Add
        '
        Me.Cmd_Add.AccessibleDescription = "新增"
        Me.Cmd_Add.AccessibleName = ""
        Me.Cmd_Add.Image = Global.DN100_BasicInfo.My.Resources.Resources.ADD
        Me.Cmd_Add.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Add.Name = "Cmd_Add"
        Me.Cmd_Add.Size = New System.Drawing.Size(73, 22)
        Me.Cmd_Add.Text = "新增关联"
        '
        'Cmd_Remove
        '
        Me.Cmd_Remove.AccessibleDescription = "修改按钮"
        Me.Cmd_Remove.AccessibleName = ""
        Me.Cmd_Remove.Image = Global.DN100_BasicInfo.My.Resources.Resources.Delete
        Me.Cmd_Remove.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Remove.Name = "Cmd_Remove"
        Me.Cmd_Remove.Size = New System.Drawing.Size(73, 22)
        Me.Cmd_Remove.Text = "取消关联"
        '
        'Btn_Refresh
        '
        Me.Btn_Refresh.Image = Global.DN100_BasicInfo.My.Resources.Resources.ReFresh
        Me.Btn_Refresh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Btn_Refresh.Name = "Btn_Refresh"
        Me.Btn_Refresh.Size = New System.Drawing.Size(49, 22)
        Me.Btn_Refresh.Text = "刷新"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.Red
        Me.Label7.Location = New System.Drawing.Point(82, 347)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(392, 14)
        Me.Label7.TabIndex = 23
        Me.Label7.Text = "如果成品编号和成品名称为空的时候,即跟布类编号和名称相同"
        '
        'TB_CP_Name
        '
        Me.TB_CP_Name.Location = New System.Drawing.Point(384, 111)
        Me.TB_CP_Name.Name = "TB_CP_Name"
        Me.TB_CP_Name.Size = New System.Drawing.Size(151, 23)
        Me.TB_CP_Name.TabIndex = 21
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(308, 115)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 14)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "成品名称:"
        '
        'TB_CP_No
        '
        Me.TB_CP_No.Location = New System.Drawing.Point(384, 66)
        Me.TB_CP_No.Name = "TB_CP_No"
        Me.TB_CP_No.Size = New System.Drawing.Size(151, 23)
        Me.TB_CP_No.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(308, 70)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 14)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "成品编号:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(43, 307)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(448, 14)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "提示:胚布编号:如有#号,会在运转单上显示布种编号,如果没有就不显示"
        '
        'Btn_ChoseParent
        '
        Me.Btn_ChoseParent.Font = New System.Drawing.Font("微软雅黑", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Btn_ChoseParent.Location = New System.Drawing.Point(257, 20)
        Me.Btn_ChoseParent.Name = "Btn_ChoseParent"
        Me.Btn_ChoseParent.Size = New System.Drawing.Size(25, 23)
        Me.Btn_ChoseParent.TabIndex = 18
        Me.Btn_ChoseParent.Text = "..."
        Me.Btn_ChoseParent.UseVisualStyleBackColor = True
        '
        'DP_Found_Date
        '
        Me.DP_Found_Date.Location = New System.Drawing.Point(388, 249)
        Me.DP_Found_Date.Name = "DP_Found_Date"
        Me.DP_Found_Date.Size = New System.Drawing.Size(151, 23)
        Me.DP_Found_Date.TabIndex = 15
        '
        'DP_UPD_DATE
        '
        Me.DP_UPD_DATE.Location = New System.Drawing.Point(388, 212)
        Me.DP_UPD_DATE.Name = "DP_UPD_DATE"
        Me.DP_UPD_DATE.Size = New System.Drawing.Size(151, 23)
        Me.DP_UPD_DATE.TabIndex = 14
        '
        'TB_Founder
        '
        Me.TB_Founder.Location = New System.Drawing.Point(131, 249)
        Me.TB_Founder.Name = "TB_Founder"
        Me.TB_Founder.ReadOnly = True
        Me.TB_Founder.Size = New System.Drawing.Size(151, 23)
        Me.TB_Founder.TabIndex = 11
        '
        'TB_UPD_USER
        '
        Me.TB_UPD_USER.Location = New System.Drawing.Point(131, 212)
        Me.TB_UPD_USER.Name = "TB_UPD_USER"
        Me.TB_UPD_USER.ReadOnly = True
        Me.TB_UPD_USER.Size = New System.Drawing.Size(151, 23)
        Me.TB_UPD_USER.TabIndex = 11
        '
        'TB_Remark
        '
        Me.TB_Remark.Location = New System.Drawing.Point(130, 153)
        Me.TB_Remark.Multiline = True
        Me.TB_Remark.Name = "TB_Remark"
        Me.TB_Remark.Size = New System.Drawing.Size(405, 45)
        Me.TB_Remark.TabIndex = 4
        '
        'TB_Spec
        '
        Me.TB_Spec.Location = New System.Drawing.Point(384, 21)
        Me.TB_Spec.Name = "TB_Spec"
        Me.TB_Spec.Size = New System.Drawing.Size(151, 23)
        Me.TB_Spec.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(309, 253)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(70, 14)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "创建时间:"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(281, 216)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(98, 14)
        Me.Label23.TabIndex = 7
        Me.Label23.Text = "最后修改时间:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(336, 25)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(42, 14)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "规格:"
        '
        'TB_ID
        '
        Me.TB_ID.Location = New System.Drawing.Point(130, 65)
        Me.TB_ID.Name = "TB_ID"
        Me.TB_ID.Size = New System.Drawing.Size(151, 23)
        Me.TB_ID.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(72, 253)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 14)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "创建人:"
        '
        'TB_Name
        '
        Me.TB_Name.Location = New System.Drawing.Point(131, 111)
        Me.TB_Name.Name = "TB_Name"
        Me.TB_Name.Size = New System.Drawing.Size(151, 23)
        Me.TB_Name.TabIndex = 2
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(43, 216)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(84, 14)
        Me.Label22.TabIndex = 6
        Me.Label22.Text = "最后修改人:"
        '
        'Label_ID
        '
        Me.Label_ID.AutoSize = True
        Me.Label_ID.ForeColor = System.Drawing.Color.Blue
        Me.Label_ID.Location = New System.Drawing.Point(54, 69)
        Me.Label_ID.Name = "Label_ID"
        Me.Label_ID.Size = New System.Drawing.Size(70, 14)
        Me.Label_ID.TabIndex = 7
        Me.Label_ID.Text = "布类编号:"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(82, 169)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(42, 14)
        Me.Label19.TabIndex = 6
        Me.Label19.Text = "备注:"
        '
        'TB_GoodsType
        '
        Me.TB_GoodsType.Location = New System.Drawing.Point(131, 20)
        Me.TB_GoodsType.Name = "TB_GoodsType"
        Me.TB_GoodsType.ReadOnly = True
        Me.TB_GoodsType.Size = New System.Drawing.Size(135, 23)
        Me.TB_GoodsType.TabIndex = 13
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(54, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 14)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "客户名称:"
        '
        'LB_FullName
        '
        Me.LB_FullName.AutoSize = True
        Me.LB_FullName.Location = New System.Drawing.Point(54, 115)
        Me.LB_FullName.Name = "LB_FullName"
        Me.LB_FullName.Size = New System.Drawing.Size(70, 14)
        Me.LB_FullName.TabIndex = 5
        Me.LB_FullName.Text = "布类名称:"
        '
        'LB_State
        '
        Me.LB_State.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.LB_State.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LB_State.ForeColor = System.Drawing.Color.Red
        Me.LB_State.Name = "LB_State"
        Me.LB_State.Size = New System.Drawing.Size(103, 37)
        Me.LB_State.Text = "asdfasdfasfd"
        '
        'Lb1
        '
        Me.Lb1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.Lb1.Name = "Lb1"
        Me.Lb1.Size = New System.Drawing.Size(35, 37)
        Me.Lb1.Text = "状态:"
        '
        'F10011_BZ_Msg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.PanelMain)
        Me.Controls.Add(Me.Tool_Top)
        Me.Name = "F10011_BZ_Msg"
        Me.Size = New System.Drawing.Size(962, 437)
        Me.Title = "布类详细信息"
        Me.Tool_Top.ResumeLayout(False)
        Me.Tool_Top.PerformLayout()
        Me.PanelMain.ResumeLayout(False)
        Me.PanelMain.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.FG1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Tool_Top As System.Windows.Forms.ToolStrip
    Friend WithEvents Cmd_Modify As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_Del As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Cmd_Exit As System.Windows.Forms.ToolStripButton
    Friend WithEvents PanelMain As System.Windows.Forms.Panel
    Friend WithEvents TB_Spec As System.Windows.Forms.TextBox
    Friend WithEvents TB_Name As System.Windows.Forms.TextBox
    Friend WithEvents LB_FullName As System.Windows.Forms.Label
    Friend WithEvents TB_Remark As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents TB_UPD_USER As System.Windows.Forms.TextBox
    Friend WithEvents TB_Founder As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DP_UPD_DATE As System.Windows.Forms.DateTimePicker
    Friend WithEvents DP_Found_Date As System.Windows.Forms.DateTimePicker
    Friend WithEvents Btn_ChoseParent As System.Windows.Forms.Button
    Friend WithEvents TB_ID As System.Windows.Forms.TextBox
    Friend WithEvents Label_ID As System.Windows.Forms.Label
    Friend WithEvents TB_GoodsType As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TB_CP_No As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TB_CP_Name As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents FG1 As PClass.FG
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents Cmd_Add As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_Remove As System.Windows.Forms.ToolStripButton
    Friend WithEvents CB_BZ_FG As BaseClass.ToolStripComboList
    Friend WithEvents Btn_Refresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_Combine As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_UnDisable As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_Disable As System.Windows.Forms.ToolStripButton
    Friend WithEvents LB_State As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Lb1 As System.Windows.Forms.ToolStripLabel

End Class
