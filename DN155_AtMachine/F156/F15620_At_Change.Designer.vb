<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F15620_At_Change
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F15620_At_Change))
        Me.PanelMain = New System.Windows.Forms.Panel
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.Cmd_SelDept = New System.Windows.Forms.Button
        Me.Fg1 = New PClass.FG
        Me.Cmd_Add = New System.Windows.Forms.Button
        Me.CheckBoxAll = New System.Windows.Forms.CheckBox
        Me.CB_Employee = New BaseClass.ComBoList
        Me.Label1 = New System.Windows.Forms.Label
        Me.Button_Start = New System.Windows.Forms.Button
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.LabelMsg = New System.Windows.Forms.Label
        Me.PB = New System.Windows.Forms.ProgressBar
        Me.Label3 = New System.Windows.Forms.Label
        Me.PBE = New System.Windows.Forms.ProgressBar
        Me.BW = New System.ComponentModel.BackgroundWorker
        Me.PanelMain.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.Fg1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelMain
        '
        Me.PanelMain.Controls.Add(Me.Panel1)
        Me.PanelMain.Controls.Add(Me.LabelMsg)
        Me.PanelMain.Controls.Add(Me.PB)
        Me.PanelMain.Controls.Add(Me.Label3)
        Me.PanelMain.Controls.Add(Me.PBE)
        Me.PanelMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelMain.Location = New System.Drawing.Point(0, 0)
        Me.PanelMain.Name = "PanelMain"
        Me.PanelMain.Padding = New System.Windows.Forms.Padding(2)
        Me.PanelMain.Size = New System.Drawing.Size(833, 445)
        Me.PanelMain.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.CheckBox1)
        Me.Panel1.Controls.Add(Me.Cmd_SelDept)
        Me.Panel1.Controls.Add(Me.Fg1)
        Me.Panel1.Controls.Add(Me.Cmd_Add)
        Me.Panel1.Controls.Add(Me.CheckBoxAll)
        Me.Panel1.Controls.Add(Me.CB_Employee)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Button_Start)
        Me.Panel1.Controls.Add(Me.DateTimePicker2)
        Me.Panel1.Controls.Add(Me.DateTimePicker1)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Location = New System.Drawing.Point(12, 8)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(796, 330)
        Me.Panel1.TabIndex = 41
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Location = New System.Drawing.Point(179, 246)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(82, 18)
        Me.CheckBox1.TabIndex = 41
        Me.CheckBox1.Text = "高速分析"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Cmd_SelDept
        '
        Me.Cmd_SelDept.Location = New System.Drawing.Point(38, 270)
        Me.Cmd_SelDept.Name = "Cmd_SelDept"
        Me.Cmd_SelDept.Size = New System.Drawing.Size(98, 37)
        Me.Cmd_SelDept.TabIndex = 40
        Me.Cmd_SelDept.Text = "按部门选择"
        Me.Cmd_SelDept.UseVisualStyleBackColor = True
        '
        'Fg1
        '
        Me.Fg1.AddCopyMenu = False
        Me.Fg1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Fg1.AutoAddIndex = True
        Me.Fg1.AutoGenerateColumns = False
        Me.Fg1.AutoResize = False
        Me.Fg1.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.Fg1.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.XpThemes
        Me.Fg1.CanEditing = False
        Me.Fg1.CheckKeyPressEdit = True
        Me.Fg1.ColumnInfo = resources.GetString("Fg1.ColumnInfo")
        Me.Fg1.EditFormat = True
        Me.Fg1.ExtendLastCol = True
        Me.Fg1.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Fg1.ForeColor = System.Drawing.Color.Black
        Me.Fg1.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.Fg1.IsAutoAddRow = True
        Me.Fg1.IsClickStartEdit = False
        Me.Fg1.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.Fg1.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.Fg1.Location = New System.Drawing.Point(321, 1)
        Me.Fg1.Name = "Fg1"
        Me.Fg1.NoShowMenu = False
        Me.Fg1.Rows.Count = 1
        Me.Fg1.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.Fg1.Size = New System.Drawing.Size(472, 326)
        Me.Fg1.StartCol = ""
        Me.Fg1.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("Fg1.Styles"))
        Me.Fg1.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.BelowData
        Me.Fg1.TabIndex = 37
        '
        'Cmd_Add
        '
        Me.Cmd_Add.Location = New System.Drawing.Point(220, 200)
        Me.Cmd_Add.Name = "Cmd_Add"
        Me.Cmd_Add.Size = New System.Drawing.Size(78, 37)
        Me.Cmd_Add.TabIndex = 39
        Me.Cmd_Add.Text = "添加"
        Me.Cmd_Add.UseVisualStyleBackColor = True
        '
        'CheckBoxAll
        '
        Me.CheckBoxAll.AutoSize = True
        Me.CheckBoxAll.Checked = True
        Me.CheckBoxAll.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxAll.Font = New System.Drawing.Font("宋体", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.CheckBoxAll.ForeColor = System.Drawing.Color.Blue
        Me.CheckBoxAll.Location = New System.Drawing.Point(82, 158)
        Me.CheckBoxAll.Name = "CheckBoxAll"
        Me.CheckBoxAll.Size = New System.Drawing.Size(148, 23)
        Me.CheckBoxAll.TabIndex = 38
        Me.CheckBoxAll.Text = "分析所有员工"
        Me.CheckBoxAll.UseVisualStyleBackColor = True
        '
        'CB_Employee
        '
        Me.CB_Employee.Child = "ComboEmployee"
        Me.CB_Employee.FormattingEnabled = True
        Me.CB_Employee.IDAsInt = 0
        Me.CB_Employee.IDValue = ""
        Me.CB_Employee.IsKeyDownAutoSearch = True
        Me.CB_Employee.Location = New System.Drawing.Point(89, 208)
        Me.CB_Employee.Name = "CB_Employee"
        Me.CB_Employee.SearchType = BaseClass.cSearchType.ENum_SearchType.ALL
        Me.CB_Employee.Size = New System.Drawing.Size(121, 22)
        Me.CB_Employee.TabIndex = 36
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(41, 212)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 14)
        Me.Label1.TabIndex = 35
        Me.Label1.Text = "人员:"
        '
        'Button_Start
        '
        Me.Button_Start.Location = New System.Drawing.Point(179, 270)
        Me.Button_Start.Name = "Button_Start"
        Me.Button_Start.Size = New System.Drawing.Size(95, 37)
        Me.Button_Start.TabIndex = 26
        Me.Button_Start.Text = "开始分析"
        Me.Button_Start.UseVisualStyleBackColor = True
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Font = New System.Drawing.Font("宋体", 10.0!)
        Me.DateTimePicker2.Location = New System.Drawing.Point(89, 112)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(125, 23)
        Me.DateTimePicker2.TabIndex = 25
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Font = New System.Drawing.Font("宋体", 10.0!)
        Me.DateTimePicker1.Location = New System.Drawing.Point(89, 54)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(125, 23)
        Me.DateTimePicker1.TabIndex = 24
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(24, 60)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 14)
        Me.Label5.TabIndex = 28
        Me.Label5.Text = "开始时间:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(24, 118)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 14)
        Me.Label4.TabIndex = 29
        Me.Label4.Text = "结束时间:"
        '
        'LabelMsg
        '
        Me.LabelMsg.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelMsg.Location = New System.Drawing.Point(21, 396)
        Me.LabelMsg.Name = "LabelMsg"
        Me.LabelMsg.Size = New System.Drawing.Size(787, 37)
        Me.LabelMsg.TabIndex = 31
        Me.LabelMsg.Text = "点开始分析"
        Me.LabelMsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PB
        '
        Me.PB.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PB.Location = New System.Drawing.Point(23, 366)
        Me.PB.Name = "PB"
        Me.PB.Size = New System.Drawing.Size(785, 19)
        Me.PB.TabIndex = 30
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(209, 382)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(0, 14)
        Me.Label3.TabIndex = 9
        '
        'PBE
        '
        Me.PBE.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PBE.Location = New System.Drawing.Point(23, 338)
        Me.PBE.Name = "PBE"
        Me.PBE.Size = New System.Drawing.Size(785, 19)
        Me.PBE.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.PBE.TabIndex = 33
        Me.PBE.Visible = False
        '
        'BW
        '
        Me.BW.WorkerReportsProgress = True
        '
        'F15620_At_Change
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.PanelMain)
        Me.Name = "F15620_At_Change"
        Me.Size = New System.Drawing.Size(833, 445)
        Me.Title = "机具详细信息"
        Me.PanelMain.ResumeLayout(False)
        Me.PanelMain.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.Fg1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelMain As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents BW As System.ComponentModel.BackgroundWorker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PBE As System.Windows.Forms.ProgressBar
    Friend WithEvents LabelMsg As System.Windows.Forms.Label
    Friend WithEvents PB As System.Windows.Forms.ProgressBar
    Friend WithEvents Button_Start As System.Windows.Forms.Button
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CB_Employee As BaseClass.ComBoList
    Friend WithEvents CheckBoxAll As System.Windows.Forms.CheckBox
    Friend WithEvents Fg1 As PClass.FG
    Friend WithEvents Cmd_Add As System.Windows.Forms.Button
    Friend WithEvents Cmd_SelDept As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox

End Class
