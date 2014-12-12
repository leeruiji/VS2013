<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F99007_Employee_Sel
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F99007_Employee_Sel))
        Me.FG_Employee = New PClass.FG
        Me.DeptTree1 = New DN990_BaseSetting.DeptTree
        CType(Me.FG_Employee, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'FG_Employee
        '
        Me.FG_Employee.AllowEditing = False
        Me.FG_Employee.AutoAddIndex = True
        Me.FG_Employee.AutoGenerateColumns = False
        Me.FG_Employee.AutoResize = False
        Me.FG_Employee.BackColor = System.Drawing.Color.White
        Me.FG_Employee.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.XpThemes
        Me.FG_Employee.CanEditing = False
        Me.FG_Employee.ColumnInfo = resources.GetString("FG_Employee.ColumnInfo")
        Me.FG_Employee.ExtendLastCol = True
        Me.FG_Employee.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.FG_Employee.ForeColor = System.Drawing.Color.Black
        Me.FG_Employee.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.FG_Employee.IsClickStartEdit = True
        Me.FG_Employee.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.FG_Employee.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.FG_Employee.Location = New System.Drawing.Point(295, 19)
        Me.FG_Employee.Name = "FG_Employee"
        Me.FG_Employee.Rows.Count = 10
        Me.FG_Employee.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.FG_Employee.Size = New System.Drawing.Size(373, 383)
        Me.FG_Employee.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("FG_Employee.Styles"))
        Me.FG_Employee.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.BelowData
        Me.FG_Employee.TabIndex = 13
        '
        'DeptTree1
        '
        Me.DeptTree1.Location = New System.Drawing.Point(0, 0)
        Me.DeptTree1.Name = "DeptTree1"
        Me.DeptTree1.Size = New System.Drawing.Size(300, 603)
        Me.DeptTree1.TabIndex = 0
        '
        'F99007_Employee_Sel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.Controls.Add(Me.FG_Employee)
        Me.Controls.Add(Me.DeptTree1)
        Me.Name = "F99007_Employee_Sel"
        Me.Size = New System.Drawing.Size(639, 700)
        CType(Me.FG_Employee, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Tool_Top As System.Windows.Forms.ToolStrip
    Friend WithEvents Cmd_Del As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Cmd_Exit As System.Windows.Forms.ToolStripButton
    Friend WithEvents PanelMain As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label

    Friend WithEvents Cmd_Modify As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_Add As System.Windows.Forms.ToolStripButton
    Friend WithEvents Btn_Choose As System.Windows.Forms.ToolStripButton
    Friend WithEvents DeptTree1 As DN990_BaseSetting.DeptTree
    Friend WithEvents FG_Employee As PClass.FG

End Class
