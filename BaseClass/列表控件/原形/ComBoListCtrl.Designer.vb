<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ComBoListCtrl
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ComBoListCtrl))
        Me.TimerEdit = New System.Windows.Forms.Timer(Me.components)
        Me.TimerVisable = New System.Windows.Forms.Timer(Me.components)
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel
        Me.Cmd_Add = New System.Windows.Forms.Button
        Me.Cmd_Modify = New System.Windows.Forms.Button
        Me.Cmd_Del = New System.Windows.Forms.Button
        Me.Cmd_ShowAll = New System.Windows.Forms.Button
        Me.Cmd_Close = New System.Windows.Forms.Button
        Me.FG1 = New PClass.FG
        Me.FlowLayoutPanel1.SuspendLayout()
        CType(Me.FG1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TimerEdit
        '
        Me.TimerEdit.Interval = 1
        '
        'TimerVisable
        '
        Me.TimerVisable.Interval = 50
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.Cmd_Add)
        Me.FlowLayoutPanel1.Controls.Add(Me.Cmd_Modify)
        Me.FlowLayoutPanel1.Controls.Add(Me.Cmd_Del)
        Me.FlowLayoutPanel1.Controls.Add(Me.Cmd_ShowAll)
        Me.FlowLayoutPanel1.Controls.Add(Me.Cmd_Close)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.FlowLayoutPanel1.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 316)
        Me.FlowLayoutPanel1.Margin = New System.Windows.Forms.Padding(2)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Padding = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(368, 37)
        Me.FlowLayoutPanel1.TabIndex = 2
        '
        'Cmd_Add
        '
        Me.Cmd_Add.BackColor = System.Drawing.Color.Transparent
        Me.Cmd_Add.Image = Global.BaseClass.My.Resources.Resources.ADD
        Me.Cmd_Add.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Add.Location = New System.Drawing.Point(2, 2)
        Me.Cmd_Add.Margin = New System.Windows.Forms.Padding(0, 2, 0, 2)
        Me.Cmd_Add.Name = "Cmd_Add"
        Me.Cmd_Add.Size = New System.Drawing.Size(64, 32)
        Me.Cmd_Add.TabIndex = 0
        Me.Cmd_Add.Text = "新增"
        Me.Cmd_Add.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Add.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Cmd_Add.UseVisualStyleBackColor = False
        '
        'Cmd_Modify
        '
        Me.Cmd_Modify.Image = Global.BaseClass.My.Resources.Resources.Modify
        Me.Cmd_Modify.Location = New System.Drawing.Point(66, 2)
        Me.Cmd_Modify.Margin = New System.Windows.Forms.Padding(0, 2, 0, 2)
        Me.Cmd_Modify.Name = "Cmd_Modify"
        Me.Cmd_Modify.Size = New System.Drawing.Size(64, 32)
        Me.Cmd_Modify.TabIndex = 1
        Me.Cmd_Modify.Text = "修改"
        Me.Cmd_Modify.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Modify.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Cmd_Modify.UseVisualStyleBackColor = True
        '
        'Cmd_Del
        '
        Me.Cmd_Del.Image = Global.BaseClass.My.Resources.Resources.trash
        Me.Cmd_Del.Location = New System.Drawing.Point(130, 2)
        Me.Cmd_Del.Margin = New System.Windows.Forms.Padding(0, 2, 0, 2)
        Me.Cmd_Del.Name = "Cmd_Del"
        Me.Cmd_Del.Size = New System.Drawing.Size(64, 32)
        Me.Cmd_Del.TabIndex = 2
        Me.Cmd_Del.Text = "置空"
        Me.Cmd_Del.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Del.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Cmd_Del.UseVisualStyleBackColor = True
        '
        'Cmd_ShowAll
        '
        Me.Cmd_ShowAll.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Cmd_ShowAll.Image = Global.BaseClass.My.Resources.Resources.ReFresh
        Me.Cmd_ShowAll.Location = New System.Drawing.Point(194, 2)
        Me.Cmd_ShowAll.Margin = New System.Windows.Forms.Padding(0, 2, 0, 2)
        Me.Cmd_ShowAll.Name = "Cmd_ShowAll"
        Me.Cmd_ShowAll.Size = New System.Drawing.Size(96, 32)
        Me.Cmd_ShowAll.TabIndex = 4
        Me.Cmd_ShowAll.Text = "全部显示"
        Me.Cmd_ShowAll.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_ShowAll.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Cmd_ShowAll.UseVisualStyleBackColor = True
        '
        'Cmd_Close
        '
        Me.Cmd_Close.Image = Global.BaseClass.My.Resources.Resources.Close
        Me.Cmd_Close.Location = New System.Drawing.Point(290, 2)
        Me.Cmd_Close.Margin = New System.Windows.Forms.Padding(0, 2, 0, 2)
        Me.Cmd_Close.Name = "Cmd_Close"
        Me.Cmd_Close.Size = New System.Drawing.Size(64, 32)
        Me.Cmd_Close.TabIndex = 3
        Me.Cmd_Close.Text = "关闭"
        Me.Cmd_Close.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Close.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Cmd_Close.UseVisualStyleBackColor = True
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
        Me.FG1.Location = New System.Drawing.Point(0, 0)
        Me.FG1.Name = "FG1"
        Me.FG1.NoShowMenu = True
        Me.FG1.Rows.Count = 10
        Me.FG1.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.FG1.Size = New System.Drawing.Size(368, 316)
        Me.FG1.StartCol = ""
        Me.FG1.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("FG1.Styles"))
        Me.FG1.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.BelowData
        Me.FG1.TabIndex = 12
        '
        'ComBoListCtrl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.FG1)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Name = "ComBoListCtrl"
        Me.Size = New System.Drawing.Size(368, 353)
        Me.FlowLayoutPanel1.ResumeLayout(False)
        CType(Me.FG1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents TimerEdit As System.Windows.Forms.Timer
    Friend WithEvents TimerVisable As System.Windows.Forms.Timer
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Cmd_Add As System.Windows.Forms.Button
    Friend WithEvents Cmd_Modify As System.Windows.Forms.Button
    Friend WithEvents Cmd_Del As System.Windows.Forms.Button
    Friend WithEvents Cmd_Close As System.Windows.Forms.Button
    Friend WithEvents Cmd_ShowAll As System.Windows.Forms.Button
    Protected Friend WithEvents FG1 As PClass.FG

End Class
