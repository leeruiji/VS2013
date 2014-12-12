<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GH_BillLogItem
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GH_BillLogItem))
        Me.FG1 = New PClass.FG
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.CB_Show = New System.Windows.Forms.CheckBox
        CType(Me.FG1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
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
        Me.FG1.EditFormat = True
        Me.FG1.ExtendLastCol = True
        Me.FG1.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.FG1.ForeColor = System.Drawing.Color.Black
        Me.FG1.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.FG1.IsAutoAddRow = True
        Me.FG1.IsClickStartEdit = False
        Me.FG1.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.FG1.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.FG1.Location = New System.Drawing.Point(0, 2)
        Me.FG1.Name = "FG1"
        Me.FG1.NoShowMenu = False
        Me.FG1.Rows.Count = 10
        Me.FG1.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.FG1.Size = New System.Drawing.Size(510, 249)
        Me.FG1.StartCol = ""
        Me.FG1.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("FG1.Styles"))
        Me.FG1.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.BelowData
        Me.FG1.TabIndex = 13
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.CB_Show)
        Me.Panel1.Controls.Add(Me.FG1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(510, 280)
        Me.Panel1.TabIndex = 14
        '
        'CB_Show
        '
        Me.CB_Show.AutoSize = True
        Me.CB_Show.Location = New System.Drawing.Point(3, 257)
        Me.CB_Show.Name = "CB_Show"
        Me.CB_Show.Size = New System.Drawing.Size(72, 16)
        Me.CB_Show.TabIndex = 14
        Me.CB_Show.Text = "显示全部"
        Me.CB_Show.UseVisualStyleBackColor = True
        '
        'GH_BillLogItem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Panel1)
        Me.Name = "GH_BillLogItem"
        Me.Size = New System.Drawing.Size(510, 280)
        CType(Me.FG1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Protected Friend WithEvents FG1 As PClass.FG
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents CB_Show As System.Windows.Forms.CheckBox

End Class
