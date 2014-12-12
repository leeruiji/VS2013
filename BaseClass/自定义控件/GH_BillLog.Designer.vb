<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GH_BillLog
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
        Me.TB_Value = New System.Windows.Forms.TextBox
        Me.Label_Title = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'TB_Value
        '
        Me.TB_Value.BackColor = System.Drawing.SystemColors.Control
        Me.TB_Value.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TB_Value.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TB_Value.Location = New System.Drawing.Point(71, 0)
        Me.TB_Value.Name = "TB_Value"
        Me.TB_Value.ReadOnly = True
        Me.TB_Value.Size = New System.Drawing.Size(99, 21)
        Me.TB_Value.TabIndex = 7
        '
        'Label_Title
        '
        Me.Label_Title.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label_Title.Location = New System.Drawing.Point(0, 0)
        Me.Label_Title.Name = "Label_Title"
        Me.Label_Title.Size = New System.Drawing.Size(148, 25)
        Me.Label_Title.TabIndex = 6
        Me.Label_Title.Text = "最后修改人:"
        Me.Label_Title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label2.ForeColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 12)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "最后修改人:"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Label1.Font = New System.Drawing.Font("Webdings", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(170, 0)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(10, 25)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "6"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GH_BillLog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TB_Value)
        Me.Controls.Add(Me.Label_Title)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "GH_BillLog"
        Me.Size = New System.Drawing.Size(180, 25)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents TB_Value As System.Windows.Forms.TextBox
    Friend WithEvents Label_Title As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
