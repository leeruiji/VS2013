<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F40501_Map_Msg
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
        Me.components = New System.ComponentModel.Container
        Me.PanelMain = New System.Windows.Forms.Panel
        Me.Cmd_AddRow = New System.Windows.Forms.Button
        Me.CB_Floor = New System.Windows.Forms.ComboBox
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.LabelPassage = New System.Windows.Forms.Label
        Me.LabelDisable = New System.Windows.Forms.Label
        Me.LabelPost = New System.Windows.Forms.Label
        Me.LabelCellA = New System.Windows.Forms.Label
        Me.LabelCell = New System.Windows.Forms.Label
        Me.LabelSel = New System.Windows.Forms.Label
        Me.LabelNormal = New System.Windows.Forms.Label
        Me.LabelEmpty = New System.Windows.Forms.Label
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.Cmd_Save = New System.Windows.Forms.Button
        Me.LabelXY = New System.Windows.Forms.Label
        Me.TB_No = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.TB_Qty = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.TB_MaxQty = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.CB_State = New System.Windows.Forms.ComboBox
        Me.Cmd_Edit = New System.Windows.Forms.Button
        Me.TB_sMaxQty = New System.Windows.Forms.TextBox
        Me.Cmd_Quick = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.TB_NoStart = New System.Windows.Forms.TextBox
        Me.Cmd_AutoAddNo = New System.Windows.Forms.Button
        Me.Label9 = New System.Windows.Forms.Label
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.TB_JStart = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.TB_JStep = New System.Windows.Forms.TextBox
        Me.Add_PJCol = New System.Windows.Forms.Button
        Me.Add_PCol = New System.Windows.Forms.Button
        Me.Cmd_AddPJRow = New System.Windows.Forms.Button
        Me.Cmd_AddPRow = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.TB_Passage_Height = New System.Windows.Forms.TextBox
        Me.TB_Passage_Width = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TB_Row = New System.Windows.Forms.TextBox
        Me.Tb_Col = New System.Windows.Forms.TextBox
        Me.TB_ColWidth = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TB_RowHeight = New System.Windows.Forms.TextBox
        Me.Cmd_Set = New System.Windows.Forms.Button
        Me.DG = New System.Windows.Forms.DataGridView
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.LB_Area = New System.Windows.Forms.Label
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.PanelMain.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DG, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelMain
        '
        Me.PanelMain.AutoScroll = True
        Me.PanelMain.Controls.Add(Me.Cmd_AddRow)
        Me.PanelMain.Controls.Add(Me.CB_Floor)
        Me.PanelMain.Controls.Add(Me.GroupBox6)
        Me.PanelMain.Controls.Add(Me.GroupBox5)
        Me.PanelMain.Controls.Add(Me.TB_sMaxQty)
        Me.PanelMain.Controls.Add(Me.Cmd_Quick)
        Me.PanelMain.Controls.Add(Me.GroupBox3)
        Me.PanelMain.Controls.Add(Me.GroupBox4)
        Me.PanelMain.Controls.Add(Me.GroupBox2)
        Me.PanelMain.Controls.Add(Me.GroupBox1)
        Me.PanelMain.Controls.Add(Me.Cmd_Set)
        Me.PanelMain.Controls.Add(Me.DG)
        Me.PanelMain.Controls.Add(Me.Label10)
        Me.PanelMain.Controls.Add(Me.Label3)
        Me.PanelMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelMain.Location = New System.Drawing.Point(0, 0)
        Me.PanelMain.Name = "PanelMain"
        Me.PanelMain.Padding = New System.Windows.Forms.Padding(2)
        Me.PanelMain.Size = New System.Drawing.Size(1099, 763)
        Me.PanelMain.TabIndex = 12
        '
        'Cmd_AddRow
        '
        Me.Cmd_AddRow.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cmd_AddRow.Location = New System.Drawing.Point(1002, 659)
        Me.Cmd_AddRow.Name = "Cmd_AddRow"
        Me.Cmd_AddRow.Size = New System.Drawing.Size(74, 32)
        Me.Cmd_AddRow.TabIndex = 41
        Me.Cmd_AddRow.Text = "加行"
        Me.Cmd_AddRow.UseVisualStyleBackColor = True
        '
        'CB_Floor
        '
        Me.CB_Floor.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CB_Floor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_Floor.FormattingEnabled = True
        Me.CB_Floor.Location = New System.Drawing.Point(912, 42)
        Me.CB_Floor.Name = "CB_Floor"
        Me.CB_Floor.Size = New System.Drawing.Size(65, 22)
        Me.CB_Floor.TabIndex = 40
        '
        'GroupBox6
        '
        Me.GroupBox6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox6.Controls.Add(Me.LabelPassage)
        Me.GroupBox6.Controls.Add(Me.LabelDisable)
        Me.GroupBox6.Controls.Add(Me.LabelPost)
        Me.GroupBox6.Controls.Add(Me.LabelCellA)
        Me.GroupBox6.Controls.Add(Me.LabelCell)
        Me.GroupBox6.Controls.Add(Me.LabelSel)
        Me.GroupBox6.Controls.Add(Me.LabelNormal)
        Me.GroupBox6.Controls.Add(Me.LabelEmpty)
        Me.GroupBox6.Location = New System.Drawing.Point(875, 581)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(205, 60)
        Me.GroupBox6.TabIndex = 38
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "调色板"
        '
        'LabelPassage
        '
        Me.LabelPassage.AutoSize = True
        Me.LabelPassage.BackColor = System.Drawing.Color.Transparent
        Me.LabelPassage.ForeColor = System.Drawing.Color.Red
        Me.LabelPassage.Location = New System.Drawing.Point(160, 17)
        Me.LabelPassage.Name = "LabelPassage"
        Me.LabelPassage.Size = New System.Drawing.Size(35, 14)
        Me.LabelPassage.TabIndex = 7
        Me.LabelPassage.Text = "通道"
        '
        'LabelDisable
        '
        Me.LabelDisable.AutoSize = True
        Me.LabelDisable.BackColor = System.Drawing.Color.Transparent
        Me.LabelDisable.ForeColor = System.Drawing.Color.Red
        Me.LabelDisable.Location = New System.Drawing.Point(129, 38)
        Me.LabelDisable.Name = "LabelDisable"
        Me.LabelDisable.Size = New System.Drawing.Size(35, 14)
        Me.LabelDisable.TabIndex = 6
        Me.LabelDisable.Text = "禁用"
        '
        'LabelPost
        '
        Me.LabelPost.AutoSize = True
        Me.LabelPost.BackColor = System.Drawing.Color.Transparent
        Me.LabelPost.ForeColor = System.Drawing.Color.Red
        Me.LabelPost.Location = New System.Drawing.Point(106, 38)
        Me.LabelPost.Name = "LabelPost"
        Me.LabelPost.Size = New System.Drawing.Size(21, 14)
        Me.LabelPost.TabIndex = 5
        Me.LabelPost.Text = "柱"
        '
        'LabelCellA
        '
        Me.LabelCellA.AutoSize = True
        Me.LabelCellA.BackColor = System.Drawing.Color.Transparent
        Me.LabelCellA.ForeColor = System.Drawing.Color.Blue
        Me.LabelCellA.Location = New System.Drawing.Point(58, 38)
        Me.LabelCellA.Name = "LabelCellA"
        Me.LabelCellA.Size = New System.Drawing.Size(49, 14)
        Me.LabelCellA.TabIndex = 4
        Me.LabelCellA.Text = "双数格"
        '
        'LabelCell
        '
        Me.LabelCell.AutoSize = True
        Me.LabelCell.BackColor = System.Drawing.Color.Transparent
        Me.LabelCell.ForeColor = System.Drawing.Color.White
        Me.LabelCell.Location = New System.Drawing.Point(10, 38)
        Me.LabelCell.Name = "LabelCell"
        Me.LabelCell.Size = New System.Drawing.Size(49, 14)
        Me.LabelCell.TabIndex = 3
        Me.LabelCell.Text = "单数格"
        '
        'LabelSel
        '
        Me.LabelSel.AutoSize = True
        Me.LabelSel.BackColor = System.Drawing.Color.Transparent
        Me.LabelSel.ForeColor = System.Drawing.Color.Red
        Me.LabelSel.Location = New System.Drawing.Point(107, 17)
        Me.LabelSel.Name = "LabelSel"
        Me.LabelSel.Size = New System.Drawing.Size(49, 14)
        Me.LabelSel.TabIndex = 2
        Me.LabelSel.Text = "被选择"
        '
        'LabelNormal
        '
        Me.LabelNormal.AutoSize = True
        Me.LabelNormal.BackColor = System.Drawing.Color.Transparent
        Me.LabelNormal.ForeColor = System.Drawing.Color.Blue
        Me.LabelNormal.Location = New System.Drawing.Point(58, 17)
        Me.LabelNormal.Name = "LabelNormal"
        Me.LabelNormal.Size = New System.Drawing.Size(49, 14)
        Me.LabelNormal.TabIndex = 1
        Me.LabelNormal.Text = "有库存"
        '
        'LabelEmpty
        '
        Me.LabelEmpty.AutoSize = True
        Me.LabelEmpty.BackColor = System.Drawing.Color.Transparent
        Me.LabelEmpty.ForeColor = System.Drawing.Color.White
        Me.LabelEmpty.Location = New System.Drawing.Point(12, 17)
        Me.LabelEmpty.Name = "LabelEmpty"
        Me.LabelEmpty.Size = New System.Drawing.Size(35, 14)
        Me.LabelEmpty.TabIndex = 0
        Me.LabelEmpty.Text = "空格"
        '
        'GroupBox5
        '
        Me.GroupBox5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox5.Controls.Add(Me.Cmd_Save)
        Me.GroupBox5.Controls.Add(Me.LabelXY)
        Me.GroupBox5.Controls.Add(Me.TB_No)
        Me.GroupBox5.Controls.Add(Me.Label12)
        Me.GroupBox5.Controls.Add(Me.Label11)
        Me.GroupBox5.Controls.Add(Me.TB_Qty)
        Me.GroupBox5.Controls.Add(Me.Label15)
        Me.GroupBox5.Controls.Add(Me.TB_MaxQty)
        Me.GroupBox5.Controls.Add(Me.Label14)
        Me.GroupBox5.Controls.Add(Me.Label13)
        Me.GroupBox5.Controls.Add(Me.CB_State)
        Me.GroupBox5.Controls.Add(Me.Cmd_Edit)
        Me.GroupBox5.Location = New System.Drawing.Point(875, 421)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(205, 154)
        Me.GroupBox5.TabIndex = 37
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "单前格"
        '
        'Cmd_Save
        '
        Me.Cmd_Save.Location = New System.Drawing.Point(106, 109)
        Me.Cmd_Save.Name = "Cmd_Save"
        Me.Cmd_Save.Size = New System.Drawing.Size(93, 33)
        Me.Cmd_Save.TabIndex = 10
        Me.Cmd_Save.Text = "保存"
        Me.Cmd_Save.UseVisualStyleBackColor = True
        '
        'LabelXY
        '
        Me.LabelXY.AutoSize = True
        Me.LabelXY.ForeColor = System.Drawing.Color.Blue
        Me.LabelXY.Location = New System.Drawing.Point(140, 23)
        Me.LabelXY.Name = "LabelXY"
        Me.LabelXY.Size = New System.Drawing.Size(35, 14)
        Me.LabelXY.TabIndex = 38
        Me.LabelXY.Text = "位置"
        '
        'TB_No
        '
        Me.TB_No.Location = New System.Drawing.Point(53, 20)
        Me.TB_No.Name = "TB_No"
        Me.TB_No.Size = New System.Drawing.Size(37, 23)
        Me.TB_No.TabIndex = 37
        Me.TB_No.Text = "20"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(6, 23)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(42, 14)
        Me.Label12.TabIndex = 36
        Me.Label12.Text = "编号:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(94, 23)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(42, 14)
        Me.Label11.TabIndex = 35
        Me.Label11.Text = "位置:"
        '
        'TB_Qty
        '
        Me.TB_Qty.Location = New System.Drawing.Point(140, 80)
        Me.TB_Qty.Name = "TB_Qty"
        Me.TB_Qty.Size = New System.Drawing.Size(37, 23)
        Me.TB_Qty.TabIndex = 34
        Me.TB_Qty.Text = "0"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(98, 85)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(42, 14)
        Me.Label15.TabIndex = 33
        Me.Label15.Text = "库存:"
        '
        'TB_MaxQty
        '
        Me.TB_MaxQty.Location = New System.Drawing.Point(55, 80)
        Me.TB_MaxQty.Name = "TB_MaxQty"
        Me.TB_MaxQty.Size = New System.Drawing.Size(37, 23)
        Me.TB_MaxQty.TabIndex = 32
        Me.TB_MaxQty.Text = "20"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(6, 85)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(42, 14)
        Me.Label14.TabIndex = 31
        Me.Label14.Text = "容量:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(6, 55)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(42, 14)
        Me.Label13.TabIndex = 30
        Me.Label13.Text = "状态:"
        '
        'CB_State
        '
        Me.CB_State.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_State.FormattingEnabled = True
        Me.CB_State.Items.AddRange(New Object() {"普通格", "柱", "禁用", "通道", "楼梯"})
        Me.CB_State.Location = New System.Drawing.Point(53, 49)
        Me.CB_State.Name = "CB_State"
        Me.CB_State.Size = New System.Drawing.Size(83, 22)
        Me.CB_State.TabIndex = 29
        '
        'Cmd_Edit
        '
        Me.Cmd_Edit.Location = New System.Drawing.Point(12, 109)
        Me.Cmd_Edit.Name = "Cmd_Edit"
        Me.Cmd_Edit.Size = New System.Drawing.Size(88, 33)
        Me.Cmd_Edit.TabIndex = 19
        Me.Cmd_Edit.Text = "修改"
        Me.Cmd_Edit.UseVisualStyleBackColor = True
        '
        'TB_sMaxQty
        '
        Me.TB_sMaxQty.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TB_sMaxQty.Location = New System.Drawing.Point(1024, 42)
        Me.TB_sMaxQty.Name = "TB_sMaxQty"
        Me.TB_sMaxQty.Size = New System.Drawing.Size(52, 23)
        Me.TB_sMaxQty.TabIndex = 35
        Me.TB_sMaxQty.Text = "20"
        '
        'Cmd_Quick
        '
        Me.Cmd_Quick.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cmd_Quick.Location = New System.Drawing.Point(963, 5)
        Me.Cmd_Quick.Name = "Cmd_Quick"
        Me.Cmd_Quick.Size = New System.Drawing.Size(107, 31)
        Me.Cmd_Quick.TabIndex = 34
        Me.Cmd_Quick.Text = "快速设置设置"
        Me.Cmd_Quick.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.TB_NoStart)
        Me.GroupBox3.Controls.Add(Me.Cmd_AutoAddNo)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Location = New System.Drawing.Point(875, 355)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(205, 60)
        Me.GroupBox3.TabIndex = 33
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "分配序号"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(148, 32)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(35, 14)
        Me.Label8.TabIndex = 24
        Me.Label8.Text = "开始"
        '
        'TB_NoStart
        '
        Me.TB_NoStart.Location = New System.Drawing.Point(115, 27)
        Me.TB_NoStart.Name = "TB_NoStart"
        Me.TB_NoStart.Size = New System.Drawing.Size(31, 23)
        Me.TB_NoStart.TabIndex = 22
        Me.TB_NoStart.Text = "1"
        '
        'Cmd_AutoAddNo
        '
        Me.Cmd_AutoAddNo.Location = New System.Drawing.Point(6, 21)
        Me.Cmd_AutoAddNo.Name = "Cmd_AutoAddNo"
        Me.Cmd_AutoAddNo.Size = New System.Drawing.Size(88, 33)
        Me.Cmd_AutoAddNo.TabIndex = 19
        Me.Cmd_AutoAddNo.Text = "分配编号"
        Me.Cmd_AutoAddNo.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(94, 32)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(21, 14)
        Me.Label9.TabIndex = 23
        Me.Label9.Text = "从"
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.TB_JStart)
        Me.GroupBox4.Controls.Add(Me.Label7)
        Me.GroupBox4.Controls.Add(Me.Label4)
        Me.GroupBox4.Controls.Add(Me.TB_JStep)
        Me.GroupBox4.Controls.Add(Me.Add_PJCol)
        Me.GroupBox4.Controls.Add(Me.Add_PCol)
        Me.GroupBox4.Controls.Add(Me.Cmd_AddPJRow)
        Me.GroupBox4.Controls.Add(Me.Cmd_AddPRow)
        Me.GroupBox4.Location = New System.Drawing.Point(874, 211)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(206, 138)
        Me.GroupBox4.TabIndex = 32
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "通道设置"
        '
        'TB_JStart
        '
        Me.TB_JStart.Location = New System.Drawing.Point(41, 111)
        Me.TB_JStart.Name = "TB_JStart"
        Me.TB_JStart.Size = New System.Drawing.Size(52, 23)
        Me.TB_JStart.TabIndex = 17
        Me.TB_JStart.Text = "1"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(108, 114)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(21, 14)
        Me.Label7.TabIndex = 20
        Me.Label7.Text = "每"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 114)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 14)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "开始:"
        '
        'TB_JStep
        '
        Me.TB_JStep.Location = New System.Drawing.Point(131, 111)
        Me.TB_JStep.Name = "TB_JStep"
        Me.TB_JStep.Size = New System.Drawing.Size(52, 23)
        Me.TB_JStep.TabIndex = 19
        Me.TB_JStep.Text = "3"
        '
        'Add_PJCol
        '
        Me.Add_PJCol.Location = New System.Drawing.Point(8, 59)
        Me.Add_PJCol.Name = "Add_PJCol"
        Me.Add_PJCol.Size = New System.Drawing.Size(88, 33)
        Me.Add_PJCol.TabIndex = 16
        Me.Add_PJCol.Text = "间行竖通道"
        Me.Add_PJCol.UseVisualStyleBackColor = True
        '
        'Add_PCol
        '
        Me.Add_PCol.Location = New System.Drawing.Point(8, 20)
        Me.Add_PCol.Name = "Add_PCol"
        Me.Add_PCol.Size = New System.Drawing.Size(88, 33)
        Me.Add_PCol.TabIndex = 15
        Me.Add_PCol.Text = "设置竖通道"
        Me.Add_PCol.UseVisualStyleBackColor = True
        '
        'Cmd_AddPJRow
        '
        Me.Cmd_AddPJRow.Location = New System.Drawing.Point(99, 59)
        Me.Cmd_AddPJRow.Name = "Cmd_AddPJRow"
        Me.Cmd_AddPJRow.Size = New System.Drawing.Size(88, 33)
        Me.Cmd_AddPJRow.TabIndex = 16
        Me.Cmd_AddPJRow.Text = "间行横通道"
        Me.Cmd_AddPJRow.UseVisualStyleBackColor = True
        '
        'Cmd_AddPRow
        '
        Me.Cmd_AddPRow.Location = New System.Drawing.Point(99, 20)
        Me.Cmd_AddPRow.Name = "Cmd_AddPRow"
        Me.Cmd_AddPRow.Size = New System.Drawing.Size(88, 33)
        Me.Cmd_AddPRow.TabIndex = 14
        Me.Cmd_AddPRow.Text = "设置横通道"
        Me.Cmd_AddPRow.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.TB_Passage_Height)
        Me.GroupBox2.Controls.Add(Me.TB_Passage_Width)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Location = New System.Drawing.Point(872, 150)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(208, 55)
        Me.GroupBox2.TabIndex = 31
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "通道"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(28, 14)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "高:"
        '
        'TB_Passage_Height
        '
        Me.TB_Passage_Height.Location = New System.Drawing.Point(135, 21)
        Me.TB_Passage_Height.Name = "TB_Passage_Height"
        Me.TB_Passage_Height.Size = New System.Drawing.Size(52, 23)
        Me.TB_Passage_Height.TabIndex = 2
        Me.TB_Passage_Height.Text = "6"
        '
        'TB_Passage_Width
        '
        Me.TB_Passage_Width.Location = New System.Drawing.Point(43, 21)
        Me.TB_Passage_Width.Name = "TB_Passage_Width"
        Me.TB_Passage_Width.Size = New System.Drawing.Size(52, 23)
        Me.TB_Passage_Width.TabIndex = 3
        Me.TB_Passage_Width.Text = "2"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(104, 24)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(28, 14)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "宽:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.TB_Row)
        Me.GroupBox1.Controls.Add(Me.Tb_Col)
        Me.GroupBox1.Controls.Add(Me.TB_ColWidth)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.TB_RowHeight)
        Me.GroupBox1.Location = New System.Drawing.Point(872, 70)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(208, 75)
        Me.GroupBox1.TabIndex = 30
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "单元格"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 14)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "行:"
        '
        'TB_Row
        '
        Me.TB_Row.Location = New System.Drawing.Point(48, 17)
        Me.TB_Row.Name = "TB_Row"
        Me.TB_Row.Size = New System.Drawing.Size(52, 23)
        Me.TB_Row.TabIndex = 2
        Me.TB_Row.Text = "78"
        '
        'Tb_Col
        '
        Me.Tb_Col.Location = New System.Drawing.Point(48, 44)
        Me.Tb_Col.Name = "Tb_Col"
        Me.Tb_Col.Size = New System.Drawing.Size(52, 23)
        Me.Tb_Col.TabIndex = 3
        Me.Tb_Col.Text = "45"
        '
        'TB_ColWidth
        '
        Me.TB_ColWidth.Location = New System.Drawing.Point(106, 44)
        Me.TB_ColWidth.Name = "TB_ColWidth"
        Me.TB_ColWidth.Size = New System.Drawing.Size(52, 23)
        Me.TB_ColWidth.TabIndex = 9
        Me.TB_ColWidth.Text = "36"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(28, 14)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "列:"
        '
        'TB_RowHeight
        '
        Me.TB_RowHeight.Location = New System.Drawing.Point(106, 17)
        Me.TB_RowHeight.Name = "TB_RowHeight"
        Me.TB_RowHeight.Size = New System.Drawing.Size(52, 23)
        Me.TB_RowHeight.TabIndex = 8
        Me.TB_RowHeight.Text = "20"
        '
        'Cmd_Set
        '
        Me.Cmd_Set.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cmd_Set.Location = New System.Drawing.Point(874, 5)
        Me.Cmd_Set.Name = "Cmd_Set"
        Me.Cmd_Set.Size = New System.Drawing.Size(88, 31)
        Me.Cmd_Set.TabIndex = 27
        Me.Cmd_Set.Text = "设置"
        Me.Cmd_Set.UseVisualStyleBackColor = True
        '
        'DG
        '
        Me.DG.AllowUserToAddRows = False
        Me.DG.AllowUserToDeleteRows = False
        Me.DG.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DG.BackgroundColor = System.Drawing.Color.White
        Me.DG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DG.ColumnHeadersVisible = False
        Me.DG.Location = New System.Drawing.Point(5, 5)
        Me.DG.MultiSelect = False
        Me.DG.Name = "DG"
        Me.DG.RowHeadersVisible = False
        Me.DG.RowTemplate.Height = 23
        Me.DG.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.DG.Size = New System.Drawing.Size(861, 749)
        Me.DG.TabIndex = 1
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(983, 45)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(42, 14)
        Me.Label10.TabIndex = 36
        Me.Label10.Text = "容量:"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(872, 45)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 14)
        Me.Label3.TabIndex = 29
        Me.Label3.Text = "楼层:"
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
        'Timer1
        '
        '
        'F40501_Map_Msg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.PanelMain)
        Me.Controls.Add(Me.LB_Area)
        Me.Name = "F40501_Map_Msg"
        Me.Size = New System.Drawing.Size(1099, 763)
        Me.PanelMain.ResumeLayout(False)
        Me.PanelMain.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DG, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PanelMain As System.Windows.Forms.Panel
    Friend WithEvents LB_Area As System.Windows.Forms.Label
    Friend WithEvents DG As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents LabelPassage As System.Windows.Forms.Label
    Friend WithEvents LabelDisable As System.Windows.Forms.Label
    Friend WithEvents LabelPost As System.Windows.Forms.Label
    Friend WithEvents LabelCellA As System.Windows.Forms.Label
    Friend WithEvents LabelCell As System.Windows.Forms.Label
    Friend WithEvents LabelSel As System.Windows.Forms.Label
    Friend WithEvents LabelNormal As System.Windows.Forms.Label
    Friend WithEvents LabelEmpty As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents LabelXY As System.Windows.Forms.Label
    Friend WithEvents TB_No As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TB_Qty As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents TB_MaxQty As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents CB_State As System.Windows.Forms.ComboBox
    Friend WithEvents Cmd_Edit As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TB_sMaxQty As System.Windows.Forms.TextBox
    Friend WithEvents Cmd_Quick As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TB_NoStart As System.Windows.Forms.TextBox
    Friend WithEvents Cmd_AutoAddNo As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TB_JStart As System.Windows.Forms.TextBox
    Friend WithEvents TB_JStep As System.Windows.Forms.TextBox
    Friend WithEvents Add_PJCol As System.Windows.Forms.Button
    Friend WithEvents Add_PCol As System.Windows.Forms.Button
    Friend WithEvents Cmd_AddPJRow As System.Windows.Forms.Button
    Friend WithEvents Cmd_AddPRow As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TB_Passage_Height As System.Windows.Forms.TextBox
    Friend WithEvents TB_Passage_Width As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TB_Row As System.Windows.Forms.TextBox
    Friend WithEvents Tb_Col As System.Windows.Forms.TextBox
    Friend WithEvents TB_ColWidth As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TB_RowHeight As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Cmd_Set As System.Windows.Forms.Button
    Friend WithEvents CB_Floor As System.Windows.Forms.ComboBox
    Friend WithEvents Cmd_Save As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Cmd_AddRow As System.Windows.Forms.Button

End Class
