﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserDay
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
        Me.LabelState = New System.Windows.Forms.Label
        Me.LabelDay = New System.Windows.Forms.Label
        Me.ComboBox_Data = New System.Windows.Forms.ComboBox
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.LabelBC = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'LabelState
        '
        Me.LabelState.AutoSize = True
        Me.LabelState.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LabelState.ForeColor = System.Drawing.Color.Blue
        Me.LabelState.Location = New System.Drawing.Point(58, 20)
        Me.LabelState.Name = "LabelState"
        Me.LabelState.Size = New System.Drawing.Size(0, 14)
        Me.LabelState.TabIndex = 12
        '
        'LabelDay
        '
        Me.LabelDay.AutoSize = True
        Me.LabelDay.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LabelDay.Location = New System.Drawing.Point(14, 16)
        Me.LabelDay.Name = "LabelDay"
        Me.LabelDay.Size = New System.Drawing.Size(34, 16)
        Me.LabelDay.TabIndex = 10
        Me.LabelDay.Text = "1号"
        '
        'ComboBox_Data
        '
        Me.ComboBox_Data.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_Data.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ComboBox_Data.FormattingEnabled = True
        Me.ComboBox_Data.Location = New System.Drawing.Point(17, 49)
        Me.ComboBox_Data.Name = "ComboBox_Data"
        Me.ComboBox_Data.Size = New System.Drawing.Size(82, 24)
        Me.ComboBox_Data.TabIndex = 11
        '
        'LabelBC
        '
        Me.LabelBC.AutoSize = True
        Me.LabelBC.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LabelBC.Location = New System.Drawing.Point(14, 52)
        Me.LabelBC.Name = "LabelBC"
        Me.LabelBC.Size = New System.Drawing.Size(34, 16)
        Me.LabelBC.TabIndex = 13
        Me.LabelBC.Text = "1号"
        Me.LabelBC.Visible = False
        '
        'UserDay
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.LabelBC)
        Me.Controls.Add(Me.LabelState)
        Me.Controls.Add(Me.LabelDay)
        Me.Controls.Add(Me.ComboBox_Data)
        Me.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Name = "UserDay"
        Me.Size = New System.Drawing.Size(120, 84)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents LabelState As System.Windows.Forms.Label
    Public WithEvents LabelDay As System.Windows.Forms.Label
    Public WithEvents ComboBox_Data As System.Windows.Forms.ComboBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Public WithEvents LabelBC As System.Windows.Forms.Label

End Class
