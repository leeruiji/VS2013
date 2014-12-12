<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class YearMonth
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
        Me.Label_TheMonth = New System.Windows.Forms.Label
        Me.Cmd_Exit = New System.Windows.Forms.Button
        Me.Cmd_OK = New System.Windows.Forms.Button
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel
        Me.Month1 = New System.Windows.Forms.Label
        Me.Month2 = New System.Windows.Forms.Label
        Me.Month3 = New System.Windows.Forms.Label
        Me.Month4 = New System.Windows.Forms.Label
        Me.Month5 = New System.Windows.Forms.Label
        Me.Month6 = New System.Windows.Forms.Label
        Me.Month7 = New System.Windows.Forms.Label
        Me.Month8 = New System.Windows.Forms.Label
        Me.Month9 = New System.Windows.Forms.Label
        Me.Month10 = New System.Windows.Forms.Label
        Me.Month11 = New System.Windows.Forms.Label
        Me.Month12 = New System.Windows.Forms.Label
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel
        Me.Next_Last = New System.Windows.Forms.Button
        Me.LabelYear_3 = New System.Windows.Forms.Label
        Me.LabelYear_2 = New System.Windows.Forms.Label
        Me.LabelYear_1 = New System.Windows.Forms.Label
        Me.LabelYear_This = New System.Windows.Forms.Label
        Me.LabelYear1 = New System.Windows.Forms.Label
        Me.LabelYear2 = New System.Windows.Forms.Label
        Me.LabelYear3 = New System.Windows.Forms.Label
        Me.Cmd_Next = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.FlowLayoutPanel2.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label_TheMonth
        '
        Me.Label_TheMonth.AutoSize = True
        Me.Label_TheMonth.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label_TheMonth.ForeColor = System.Drawing.Color.Red
        Me.Label_TheMonth.Location = New System.Drawing.Point(7, 142)
        Me.Label_TheMonth.Name = "Label_TheMonth"
        Me.Label_TheMonth.Size = New System.Drawing.Size(130, 16)
        Me.Label_TheMonth.TabIndex = 13
        Me.Label_TheMonth.Text = "本月:2012年7月"
        '
        'Cmd_Exit
        '
        Me.Cmd_Exit.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Cmd_Exit.Location = New System.Drawing.Point(410, 133)
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(82, 34)
        Me.Cmd_Exit.TabIndex = 12
        Me.Cmd_Exit.Text = "取消"
        Me.Cmd_Exit.UseVisualStyleBackColor = True
        '
        'Cmd_OK
        '
        Me.Cmd_OK.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Cmd_OK.Location = New System.Drawing.Point(318, 133)
        Me.Cmd_OK.Name = "Cmd_OK"
        Me.Cmd_OK.Size = New System.Drawing.Size(82, 34)
        Me.Cmd_OK.TabIndex = 11
        Me.Cmd_OK.Text = "确认"
        Me.Cmd_OK.UseVisualStyleBackColor = True
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.Controls.Add(Me.Month1)
        Me.FlowLayoutPanel2.Controls.Add(Me.Month2)
        Me.FlowLayoutPanel2.Controls.Add(Me.Month3)
        Me.FlowLayoutPanel2.Controls.Add(Me.Month4)
        Me.FlowLayoutPanel2.Controls.Add(Me.Month5)
        Me.FlowLayoutPanel2.Controls.Add(Me.Month6)
        Me.FlowLayoutPanel2.Controls.Add(Me.Month7)
        Me.FlowLayoutPanel2.Controls.Add(Me.Month8)
        Me.FlowLayoutPanel2.Controls.Add(Me.Month9)
        Me.FlowLayoutPanel2.Controls.Add(Me.Month10)
        Me.FlowLayoutPanel2.Controls.Add(Me.Month11)
        Me.FlowLayoutPanel2.Controls.Add(Me.Month12)
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(5, 16)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(478, 34)
        Me.FlowLayoutPanel2.TabIndex = 10
        '
        'Month1
        '
        Me.Month1.AutoSize = True
        Me.Month1.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Month1.Location = New System.Drawing.Point(3, 8)
        Me.Month1.Margin = New System.Windows.Forms.Padding(3, 8, 3, 0)
        Me.Month1.Name = "Month1"
        Me.Month1.Padding = New System.Windows.Forms.Padding(0, 2, 0, 2)
        Me.Month1.Size = New System.Drawing.Size(30, 18)
        Me.Month1.TabIndex = 15
        Me.Month1.Tag = "1"
        Me.Month1.Text = "1月"
        '
        'Month2
        '
        Me.Month2.AutoSize = True
        Me.Month2.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Month2.Location = New System.Drawing.Point(39, 8)
        Me.Month2.Margin = New System.Windows.Forms.Padding(3, 8, 3, 0)
        Me.Month2.Name = "Month2"
        Me.Month2.Padding = New System.Windows.Forms.Padding(0, 2, 0, 2)
        Me.Month2.Size = New System.Drawing.Size(30, 18)
        Me.Month2.TabIndex = 16
        Me.Month2.Tag = "2"
        Me.Month2.Text = "2月"
        '
        'Month3
        '
        Me.Month3.AutoSize = True
        Me.Month3.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Month3.Location = New System.Drawing.Point(75, 8)
        Me.Month3.Margin = New System.Windows.Forms.Padding(3, 8, 3, 0)
        Me.Month3.Name = "Month3"
        Me.Month3.Padding = New System.Windows.Forms.Padding(0, 2, 0, 2)
        Me.Month3.Size = New System.Drawing.Size(30, 18)
        Me.Month3.TabIndex = 17
        Me.Month3.Tag = "3"
        Me.Month3.Text = "3月"
        '
        'Month4
        '
        Me.Month4.AutoSize = True
        Me.Month4.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Month4.Location = New System.Drawing.Point(111, 8)
        Me.Month4.Margin = New System.Windows.Forms.Padding(3, 8, 3, 0)
        Me.Month4.Name = "Month4"
        Me.Month4.Padding = New System.Windows.Forms.Padding(0, 2, 0, 2)
        Me.Month4.Size = New System.Drawing.Size(30, 18)
        Me.Month4.TabIndex = 18
        Me.Month4.Tag = "4"
        Me.Month4.Text = "4月"
        '
        'Month5
        '
        Me.Month5.AutoSize = True
        Me.Month5.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Month5.Location = New System.Drawing.Point(147, 8)
        Me.Month5.Margin = New System.Windows.Forms.Padding(3, 8, 3, 0)
        Me.Month5.Name = "Month5"
        Me.Month5.Padding = New System.Windows.Forms.Padding(0, 2, 0, 2)
        Me.Month5.Size = New System.Drawing.Size(30, 18)
        Me.Month5.TabIndex = 19
        Me.Month5.Tag = "5"
        Me.Month5.Text = "5月"
        '
        'Month6
        '
        Me.Month6.AutoSize = True
        Me.Month6.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Month6.Location = New System.Drawing.Point(183, 8)
        Me.Month6.Margin = New System.Windows.Forms.Padding(3, 8, 3, 0)
        Me.Month6.Name = "Month6"
        Me.Month6.Padding = New System.Windows.Forms.Padding(0, 2, 0, 2)
        Me.Month6.Size = New System.Drawing.Size(30, 18)
        Me.Month6.TabIndex = 20
        Me.Month6.Tag = "6"
        Me.Month6.Text = "6月"
        '
        'Month7
        '
        Me.Month7.AutoSize = True
        Me.Month7.BackColor = System.Drawing.Color.Blue
        Me.Month7.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Month7.ForeColor = System.Drawing.Color.Red
        Me.Month7.Location = New System.Drawing.Point(219, 8)
        Me.Month7.Margin = New System.Windows.Forms.Padding(3, 8, 3, 0)
        Me.Month7.Name = "Month7"
        Me.Month7.Padding = New System.Windows.Forms.Padding(0, 2, 0, 2)
        Me.Month7.Size = New System.Drawing.Size(30, 18)
        Me.Month7.TabIndex = 21
        Me.Month7.Tag = "7"
        Me.Month7.Text = "7月"
        '
        'Month8
        '
        Me.Month8.AutoSize = True
        Me.Month8.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Month8.Location = New System.Drawing.Point(255, 8)
        Me.Month8.Margin = New System.Windows.Forms.Padding(3, 8, 3, 0)
        Me.Month8.Name = "Month8"
        Me.Month8.Padding = New System.Windows.Forms.Padding(0, 2, 0, 2)
        Me.Month8.Size = New System.Drawing.Size(30, 18)
        Me.Month8.TabIndex = 22
        Me.Month8.Tag = "8"
        Me.Month8.Text = "8月"
        '
        'Month9
        '
        Me.Month9.AutoSize = True
        Me.Month9.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Month9.Location = New System.Drawing.Point(291, 8)
        Me.Month9.Margin = New System.Windows.Forms.Padding(3, 8, 3, 0)
        Me.Month9.Name = "Month9"
        Me.Month9.Padding = New System.Windows.Forms.Padding(0, 2, 0, 2)
        Me.Month9.Size = New System.Drawing.Size(30, 18)
        Me.Month9.TabIndex = 23
        Me.Month9.Tag = "9"
        Me.Month9.Text = "9月"
        '
        'Month10
        '
        Me.Month10.AutoSize = True
        Me.Month10.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Month10.Location = New System.Drawing.Point(327, 8)
        Me.Month10.Margin = New System.Windows.Forms.Padding(3, 8, 3, 0)
        Me.Month10.Name = "Month10"
        Me.Month10.Padding = New System.Windows.Forms.Padding(0, 2, 0, 2)
        Me.Month10.Size = New System.Drawing.Size(38, 18)
        Me.Month10.TabIndex = 24
        Me.Month10.Tag = "10"
        Me.Month10.Text = "10月"
        '
        'Month11
        '
        Me.Month11.AutoSize = True
        Me.Month11.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Month11.Location = New System.Drawing.Point(371, 8)
        Me.Month11.Margin = New System.Windows.Forms.Padding(3, 8, 3, 0)
        Me.Month11.Name = "Month11"
        Me.Month11.Padding = New System.Windows.Forms.Padding(0, 2, 0, 2)
        Me.Month11.Size = New System.Drawing.Size(38, 18)
        Me.Month11.TabIndex = 25
        Me.Month11.Tag = "11"
        Me.Month11.Text = "11月"
        '
        'Month12
        '
        Me.Month12.AutoSize = True
        Me.Month12.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Month12.Location = New System.Drawing.Point(415, 8)
        Me.Month12.Margin = New System.Windows.Forms.Padding(3, 8, 3, 0)
        Me.Month12.Name = "Month12"
        Me.Month12.Padding = New System.Windows.Forms.Padding(0, 2, 0, 2)
        Me.Month12.Size = New System.Drawing.Size(38, 18)
        Me.Month12.TabIndex = 26
        Me.Month12.Tag = "12"
        Me.Month12.Text = "12月"
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.Next_Last)
        Me.FlowLayoutPanel1.Controls.Add(Me.LabelYear_3)
        Me.FlowLayoutPanel1.Controls.Add(Me.LabelYear_2)
        Me.FlowLayoutPanel1.Controls.Add(Me.LabelYear_1)
        Me.FlowLayoutPanel1.Controls.Add(Me.LabelYear_This)
        Me.FlowLayoutPanel1.Controls.Add(Me.LabelYear1)
        Me.FlowLayoutPanel1.Controls.Add(Me.LabelYear2)
        Me.FlowLayoutPanel1.Controls.Add(Me.LabelYear3)
        Me.FlowLayoutPanel1.Controls.Add(Me.Cmd_Next)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(7, 15)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(476, 38)
        Me.FlowLayoutPanel1.TabIndex = 9
        '
        'Next_Last
        '
        Me.Next_Last.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Next_Last.Location = New System.Drawing.Point(3, 3)
        Me.Next_Last.Name = "Next_Last"
        Me.Next_Last.Size = New System.Drawing.Size(46, 27)
        Me.Next_Last.TabIndex = 9
        Me.Next_Last.Text = "<<"
        Me.Next_Last.UseVisualStyleBackColor = True
        '
        'LabelYear_3
        '
        Me.LabelYear_3.AutoSize = True
        Me.LabelYear_3.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LabelYear_3.Location = New System.Drawing.Point(55, 8)
        Me.LabelYear_3.Margin = New System.Windows.Forms.Padding(3, 8, 3, 0)
        Me.LabelYear_3.Name = "LabelYear_3"
        Me.LabelYear_3.Size = New System.Drawing.Size(44, 16)
        Me.LabelYear_3.TabIndex = 2
        Me.LabelYear_3.Tag = "-3"
        Me.LabelYear_3.Text = "2010"
        '
        'LabelYear_2
        '
        Me.LabelYear_2.AutoSize = True
        Me.LabelYear_2.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LabelYear_2.Location = New System.Drawing.Point(105, 8)
        Me.LabelYear_2.Margin = New System.Windows.Forms.Padding(3, 8, 3, 0)
        Me.LabelYear_2.Name = "LabelYear_2"
        Me.LabelYear_2.Size = New System.Drawing.Size(44, 16)
        Me.LabelYear_2.TabIndex = 1
        Me.LabelYear_2.Tag = "-2"
        Me.LabelYear_2.Text = "2011"
        '
        'LabelYear_1
        '
        Me.LabelYear_1.AutoSize = True
        Me.LabelYear_1.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LabelYear_1.ForeColor = System.Drawing.Color.Red
        Me.LabelYear_1.Location = New System.Drawing.Point(155, 8)
        Me.LabelYear_1.Margin = New System.Windows.Forms.Padding(3, 8, 3, 0)
        Me.LabelYear_1.Name = "LabelYear_1"
        Me.LabelYear_1.Size = New System.Drawing.Size(44, 16)
        Me.LabelYear_1.TabIndex = 3
        Me.LabelYear_1.Tag = "-1"
        Me.LabelYear_1.Text = "2012"
        '
        'LabelYear_This
        '
        Me.LabelYear_This.AutoSize = True
        Me.LabelYear_This.BackColor = System.Drawing.Color.Blue
        Me.LabelYear_This.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LabelYear_This.ForeColor = System.Drawing.Color.White
        Me.LabelYear_This.Location = New System.Drawing.Point(205, 8)
        Me.LabelYear_This.Margin = New System.Windows.Forms.Padding(3, 8, 3, 0)
        Me.LabelYear_This.Name = "LabelYear_This"
        Me.LabelYear_This.Size = New System.Drawing.Size(44, 16)
        Me.LabelYear_This.TabIndex = 4
        Me.LabelYear_This.Tag = "0"
        Me.LabelYear_This.Text = "2013"
        '
        'LabelYear1
        '
        Me.LabelYear1.AutoSize = True
        Me.LabelYear1.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LabelYear1.Location = New System.Drawing.Point(255, 8)
        Me.LabelYear1.Margin = New System.Windows.Forms.Padding(3, 8, 3, 0)
        Me.LabelYear1.Name = "LabelYear1"
        Me.LabelYear1.Size = New System.Drawing.Size(44, 16)
        Me.LabelYear1.TabIndex = 5
        Me.LabelYear1.Tag = "1"
        Me.LabelYear1.Text = "2014"
        '
        'LabelYear2
        '
        Me.LabelYear2.AutoSize = True
        Me.LabelYear2.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LabelYear2.Location = New System.Drawing.Point(305, 8)
        Me.LabelYear2.Margin = New System.Windows.Forms.Padding(3, 8, 3, 0)
        Me.LabelYear2.Name = "LabelYear2"
        Me.LabelYear2.Size = New System.Drawing.Size(44, 16)
        Me.LabelYear2.TabIndex = 6
        Me.LabelYear2.Tag = "2"
        Me.LabelYear2.Text = "2015"
        '
        'LabelYear3
        '
        Me.LabelYear3.AutoSize = True
        Me.LabelYear3.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LabelYear3.Location = New System.Drawing.Point(355, 8)
        Me.LabelYear3.Margin = New System.Windows.Forms.Padding(3, 8, 3, 0)
        Me.LabelYear3.Name = "LabelYear3"
        Me.LabelYear3.Size = New System.Drawing.Size(44, 16)
        Me.LabelYear3.TabIndex = 11
        Me.LabelYear3.Tag = "3"
        Me.LabelYear3.Text = "2016"
        '
        'Cmd_Next
        '
        Me.Cmd_Next.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Cmd_Next.Location = New System.Drawing.Point(405, 3)
        Me.Cmd_Next.Name = "Cmd_Next"
        Me.Cmd_Next.Size = New System.Drawing.Size(46, 27)
        Me.Cmd_Next.TabIndex = 10
        Me.Cmd_Next.Text = ">>"
        Me.Cmd_Next.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.FlowLayoutPanel2)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 62)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(489, 60)
        Me.GroupBox1.TabIndex = 14
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "月份"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.FlowLayoutPanel1)
        Me.GroupBox2.Location = New System.Drawing.Point(3, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(489, 60)
        Me.GroupBox2.TabIndex = 15
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "年份"
        '
        'YearMonth
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label_TheMonth)
        Me.Controls.Add(Me.Cmd_Exit)
        Me.Controls.Add(Me.Cmd_OK)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "YearMonth"
        Me.Size = New System.Drawing.Size(495, 178)
        Me.FlowLayoutPanel2.ResumeLayout(False)
        Me.FlowLayoutPanel2.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label_TheMonth As System.Windows.Forms.Label
    Friend WithEvents Cmd_Exit As System.Windows.Forms.Button
    Friend WithEvents Cmd_OK As System.Windows.Forms.Button
    Friend WithEvents FlowLayoutPanel2 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Month1 As System.Windows.Forms.Label
    Friend WithEvents Month2 As System.Windows.Forms.Label
    Friend WithEvents Month3 As System.Windows.Forms.Label
    Friend WithEvents Month4 As System.Windows.Forms.Label
    Friend WithEvents Month5 As System.Windows.Forms.Label
    Friend WithEvents Month6 As System.Windows.Forms.Label
    Friend WithEvents Month7 As System.Windows.Forms.Label
    Friend WithEvents Month8 As System.Windows.Forms.Label
    Friend WithEvents Month9 As System.Windows.Forms.Label
    Friend WithEvents Month10 As System.Windows.Forms.Label
    Friend WithEvents Month11 As System.Windows.Forms.Label
    Friend WithEvents Month12 As System.Windows.Forms.Label
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Next_Last As System.Windows.Forms.Button
    Friend WithEvents LabelYear_3 As System.Windows.Forms.Label
    Friend WithEvents LabelYear_2 As System.Windows.Forms.Label
    Friend WithEvents LabelYear_1 As System.Windows.Forms.Label
    Friend WithEvents LabelYear_This As System.Windows.Forms.Label
    Friend WithEvents LabelYear1 As System.Windows.Forms.Label
    Friend WithEvents LabelYear2 As System.Windows.Forms.Label
    Friend WithEvents LabelYear3 As System.Windows.Forms.Label
    Friend WithEvents Cmd_Next As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox

End Class
