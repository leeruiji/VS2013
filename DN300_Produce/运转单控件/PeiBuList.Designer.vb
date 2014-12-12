<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PeiBuList
    Inherits System.Windows.Forms.UserControl

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PeiBuList))
        Me.TB_PB_User = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.LabelTitle = New System.Windows.Forms.Label
        Me.TB_No = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.LB_State = New System.Windows.Forms.Label
        Me.LB_No = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label7 = New System.Windows.Forms.Label
        Me.TB_PB_Notice = New System.Windows.Forms.TextBox
        Me.Label30 = New System.Windows.Forms.Label
        Me.Label29 = New System.Windows.Forms.Label
        Me.TB_YPQty = New System.Windows.Forms.TextBox
        Me.TB_YPZL = New System.Windows.Forms.TextBox
        Me.GB_List = New System.Windows.Forms.GroupBox
        Me.Cmd_RemoveRow = New System.Windows.Forms.Button
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Fg1 = New PClass.FG
        Me.SumFG1 = New BaseClass.SumFG
        Me.Cmd_GoodsSel = New System.Windows.Forms.Button
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1.SuspendLayout()
        Me.GB_List.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.Fg1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TB_PB_User
        '
        Me.TB_PB_User.Location = New System.Drawing.Point(406, 17)
        Me.TB_PB_User.Name = "TB_PB_User"
        Me.TB_PB_User.Size = New System.Drawing.Size(111, 21)
        Me.TB_PB_User.TabIndex = 15
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(353, 21)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(47, 12)
        Me.Label9.TabIndex = 13
        Me.Label9.Text = "配布人:"
        '
        'LabelTitle
        '
        Me.LabelTitle.AutoSize = True
        Me.LabelTitle.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LabelTitle.ForeColor = System.Drawing.Color.Blue
        Me.LabelTitle.Location = New System.Drawing.Point(7, 12)
        Me.LabelTitle.Name = "LabelTitle"
        Me.LabelTitle.Size = New System.Drawing.Size(59, 16)
        Me.LabelTitle.TabIndex = 59
        Me.LabelTitle.Text = "运转单"
        '
        'TB_No
        '
        Me.TB_No.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TB_No.Location = New System.Drawing.Point(699, 7)
        Me.TB_No.Name = "TB_No"
        Me.TB_No.ReadOnly = True
        Me.TB_No.Size = New System.Drawing.Size(122, 21)
        Me.TB_No.TabIndex = 54
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label1.Location = New System.Drawing.Point(-491, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 16)
        Me.Label1.TabIndex = 57
        Me.Label1.Text = "状 态:"
        '
        'LB_State
        '
        Me.LB_State.AutoSize = True
        Me.LB_State.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LB_State.Location = New System.Drawing.Point(95, 12)
        Me.LB_State.Name = "LB_State"
        Me.LB_State.Size = New System.Drawing.Size(0, 16)
        Me.LB_State.TabIndex = 55
        '
        'LB_No
        '
        Me.LB_No.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LB_No.AutoSize = True
        Me.LB_No.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LB_No.ForeColor = System.Drawing.Color.Blue
        Me.LB_No.Location = New System.Drawing.Point(623, 10)
        Me.LB_No.Name = "LB_No"
        Me.LB_No.Size = New System.Drawing.Size(56, 16)
        Me.LB_No.TabIndex = 56
        Me.LB_No.Text = "缸 号:"
        '
        'Label25
        '
        Me.Label25.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label25.BackColor = System.Drawing.Color.Blue
        Me.Label25.Location = New System.Drawing.Point(-647, 37)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(1672, 3)
        Me.Label25.TabIndex = 58
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.LB_State)
        Me.Panel1.Controls.Add(Me.LabelTitle)
        Me.Panel1.Controls.Add(Me.LB_No)
        Me.Panel1.Controls.Add(Me.TB_No)
        Me.Panel1.Controls.Add(Me.Label25)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(3, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(841, 0)
        Me.Panel1.TabIndex = 60
        Me.Panel1.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(34, 63)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(35, 12)
        Me.Label7.TabIndex = 28
        Me.Label7.Text = "注意:"
        '
        'TB_PB_Notice
        '
        Me.TB_PB_Notice.BackColor = System.Drawing.Color.White
        Me.TB_PB_Notice.ForeColor = System.Drawing.Color.Blue
        Me.TB_PB_Notice.Location = New System.Drawing.Point(79, 59)
        Me.TB_PB_Notice.Name = "TB_PB_Notice"
        Me.TB_PB_Notice.Size = New System.Drawing.Size(636, 21)
        Me.TB_PB_Notice.TabIndex = 26
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(176, 23)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(59, 12)
        Me.Label30.TabIndex = 45
        Me.Label30.Text = "已配重量:"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(17, 24)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(59, 12)
        Me.Label29.TabIndex = 46
        Me.Label29.Text = "已配条数:"
        '
        'TB_YPQty
        '
        Me.TB_YPQty.Location = New System.Drawing.Point(79, 20)
        Me.TB_YPQty.Name = "TB_YPQty"
        Me.TB_YPQty.ReadOnly = True
        Me.TB_YPQty.Size = New System.Drawing.Size(80, 21)
        Me.TB_YPQty.TabIndex = 43
        '
        'TB_YPZL
        '
        Me.TB_YPZL.Location = New System.Drawing.Point(241, 19)
        Me.TB_YPZL.Name = "TB_YPZL"
        Me.TB_YPZL.ReadOnly = True
        Me.TB_YPZL.Size = New System.Drawing.Size(96, 21)
        Me.TB_YPZL.TabIndex = 44
        '
        'GB_List
        '
        Me.GB_List.Controls.Add(Me.Cmd_RemoveRow)
        Me.GB_List.Controls.Add(Me.Panel2)
        Me.GB_List.Controls.Add(Me.Cmd_GoodsSel)
        Me.GB_List.Controls.Add(Me.TB_YPZL)
        Me.GB_List.Controls.Add(Me.TB_PB_User)
        Me.GB_List.Controls.Add(Me.TB_YPQty)
        Me.GB_List.Controls.Add(Me.Label29)
        Me.GB_List.Controls.Add(Me.Label9)
        Me.GB_List.Controls.Add(Me.Label30)
        Me.GB_List.Controls.Add(Me.TB_PB_Notice)
        Me.GB_List.Controls.Add(Me.Label7)
        Me.GB_List.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GB_List.Location = New System.Drawing.Point(0, 0)
        Me.GB_List.Name = "GB_List"
        Me.GB_List.Size = New System.Drawing.Size(852, 508)
        Me.GB_List.TabIndex = 49
        Me.GB_List.TabStop = False
        Me.GB_List.Text = "配布录入"
        '
        'Cmd_RemoveRow
        '
        Me.Cmd_RemoveRow.Location = New System.Drawing.Point(721, 57)
        Me.Cmd_RemoveRow.Name = "Cmd_RemoveRow"
        Me.Cmd_RemoveRow.Size = New System.Drawing.Size(75, 23)
        Me.Cmd_RemoveRow.TabIndex = 49
        Me.Cmd_RemoveRow.Text = "减行"
        Me.Cmd_RemoveRow.UseVisualStyleBackColor = True
        Me.Cmd_RemoveRow.Visible = False
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.Fg1)
        Me.Panel2.Controls.Add(Me.SumFG1)
        Me.Panel2.Location = New System.Drawing.Point(3, 86)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(846, 418)
        Me.Panel2.TabIndex = 53
        '
        'Fg1
        '
        Me.Fg1.AutoAddIndex = True
        Me.Fg1.AutoGenerateColumns = False
        Me.Fg1.AutoResize = False
        Me.Fg1.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.Fg1.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.XpThemes
        Me.Fg1.CanEditing = False
        Me.Fg1.ColumnInfo = resources.GetString("Fg1.ColumnInfo")
        Me.Fg1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Fg1.EditFormat = True
        Me.Fg1.ExtendLastCol = True
        Me.Fg1.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Fg1.ForeColor = System.Drawing.Color.Black
        Me.Fg1.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.Fg1.IsAutoAddRow = False
        Me.Fg1.IsClickStartEdit = False
        Me.Fg1.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.Fg1.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.Fg1.Location = New System.Drawing.Point(0, 0)
        Me.Fg1.Name = "Fg1"
        Me.Fg1.Rows.Count = 1
        Me.Fg1.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.Fg1.Size = New System.Drawing.Size(846, 398)
        Me.Fg1.StartCol = ""
        Me.Fg1.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("Fg1.Styles"))
        Me.Fg1.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.BelowData
        Me.Fg1.TabIndex = 48
        '
        'SumFG1
        '
        Me.SumFG1.BackColor = System.Drawing.Color.Cornsilk
        Me.SumFG1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SumFG1.ColForSum.Add("ZL")
        Me.SumFG1.ColForSum.Add("PB")
        Me.SumFG1.ColForSum.Add("Old_PB")
        Me.SumFG1.ColForSum.Add("CP")
        Me.SumFG1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.SumFG1.FG = Me.Fg1
        Me.SumFG1.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.SumFG1.ForeColor = System.Drawing.Color.Blue
        Me.SumFG1.Location = New System.Drawing.Point(0, 398)
        Me.SumFG1.Name = "SumFG1"
        Me.SumFG1.Size = New System.Drawing.Size(846, 20)
        Me.SumFG1.TabIndex = 52
        '
        'Cmd_GoodsSel
        '
        Me.Cmd_GoodsSel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_GoodsSel.Location = New System.Drawing.Point(153, 20)
        Me.Cmd_GoodsSel.Name = "Cmd_GoodsSel"
        Me.Cmd_GoodsSel.Size = New System.Drawing.Size(17, 21)
        Me.Cmd_GoodsSel.TabIndex = 47
        Me.Cmd_GoodsSel.Text = "…"
        Me.Cmd_GoodsSel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Cmd_GoodsSel.UseVisualStyleBackColor = True
        Me.Cmd_GoodsSel.Visible = False
        '
        'Timer1
        '
        Me.Timer1.Interval = 1
        '
        'PeiBuList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GB_List)
        Me.Name = "PeiBuList"
        Me.Size = New System.Drawing.Size(852, 508)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GB_List.ResumeLayout(False)
        Me.GB_List.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.Fg1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TB_PB_User As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents LabelTitle As System.Windows.Forms.Label
    Friend WithEvents TB_No As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LB_State As System.Windows.Forms.Label
    Friend WithEvents LB_No As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TB_PB_Notice As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents TB_YPQty As System.Windows.Forms.TextBox
    Friend WithEvents TB_YPZL As System.Windows.Forms.TextBox
    Friend WithEvents GB_List As System.Windows.Forms.GroupBox
    Friend WithEvents Cmd_GoodsSel As System.Windows.Forms.Button
    Friend WithEvents Fg1 As PClass.FG
    Friend WithEvents Cmd_RemoveRow As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents SumFG1 As BaseClass.SumFG
    Friend WithEvents Timer1 As System.Windows.Forms.Timer

End Class
