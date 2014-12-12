<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MonthPicker
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
        Me.Label_Month = New System.Windows.Forms.Label
        Me.Label_Title = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Label_Month
        '
        Me.Label_Month.AutoSize = True
        Me.Label_Month.BackColor = System.Drawing.Color.Transparent
        Me.Label_Month.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label_Month.ForeColor = System.Drawing.Color.Blue
        Me.Label_Month.Location = New System.Drawing.Point(37, 4)
        Me.Label_Month.Margin = New System.Windows.Forms.Padding(1)
        Me.Label_Month.Name = "Label_Month"
        Me.Label_Month.Size = New System.Drawing.Size(65, 12)
        Me.Label_Month.TabIndex = 0
        Me.Label_Month.Text = "XXXX年XX月"
        Me.Label_Month.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label_Title
        '
        Me.Label_Title.AutoSize = True
        Me.Label_Title.BackColor = System.Drawing.Color.Transparent
        Me.Label_Title.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label_Title.ForeColor = System.Drawing.Color.Black
        Me.Label_Title.Location = New System.Drawing.Point(2, 4)
        Me.Label_Title.Margin = New System.Windows.Forms.Padding(0)
        Me.Label_Title.Name = "Label_Title"
        Me.Label_Title.Size = New System.Drawing.Size(35, 12)
        Me.Label_Title.TabIndex = 1
        Me.Label_Title.Text = "月份:"
        Me.Label_Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Label1.Font = New System.Drawing.Font("Webdings", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(98, 4)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(10, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "6"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'MonthPicker
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Transparent
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label_Month)
        Me.Controls.Add(Me.Label_Title)
        Me.Margin = New System.Windows.Forms.Padding(0)
        Me.Name = "MonthPicker"
        Me.Padding = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.Size = New System.Drawing.Size(110, 21)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label_Month As System.Windows.Forms.Label
    Friend WithEvents Label_Title As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
