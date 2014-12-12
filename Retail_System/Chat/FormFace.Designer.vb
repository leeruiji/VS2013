Imports Retail_System.My.Resources.ChatRes
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormFace
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.PanelFace = New System.Windows.Forms.FlowLayoutPanel
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.PicFaceShow1 = New System.Windows.Forms.PictureBox
        Me.DG = New System.Windows.Forms.DataGridView
        Me.Column1 = New System.Windows.Forms.DataGridViewImageColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewImageColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewImageColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewImageColumn
        Me.Column5 = New System.Windows.Forms.DataGridViewImageColumn
        Me.Column6 = New System.Windows.Forms.DataGridViewImageColumn
        Me.Column7 = New System.Windows.Forms.DataGridViewImageColumn
        Me.Column8 = New System.Windows.Forms.DataGridViewImageColumn
        Me.Column9 = New System.Windows.Forms.DataGridViewImageColumn
        Me.Column10 = New System.Windows.Forms.DataGridViewImageColumn
        Me.Column11 = New System.Windows.Forms.DataGridViewImageColumn
        Me.Column12 = New System.Windows.Forms.DataGridViewImageColumn
        Me.Column13 = New System.Windows.Forms.DataGridViewImageColumn
        Me.Column14 = New System.Windows.Forms.DataGridViewImageColumn
        Me.Column15 = New System.Windows.Forms.DataGridViewImageColumn
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.TimerShow = New System.Windows.Forms.Timer(Me.components)
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.PicFaceShow1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DG, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelFace
        '
        Me.PanelFace.BackColor = System.Drawing.Color.White
        Me.PanelFace.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelFace.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelFace.Location = New System.Drawing.Point(3, 3)
        Me.PanelFace.Name = "PanelFace"
        Me.PanelFace.Size = New System.Drawing.Size(453, 270)
        Me.PanelFace.TabIndex = 1
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(467, 301)
        Me.TabControl1.TabIndex = 5
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.PicFaceShow1)
        Me.TabPage1.Controls.Add(Me.DG)
        Me.TabPage1.Location = New System.Drawing.Point(4, 21)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(459, 276)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "静态显示"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'PicFaceShow1
        '
        Me.PicFaceShow1.BackColor = System.Drawing.Color.White
        Me.PicFaceShow1.Location = New System.Drawing.Point(370, 3)
        Me.PicFaceShow1.Name = "PicFaceShow1"
        Me.PicFaceShow1.Size = New System.Drawing.Size(85, 85)
        Me.PicFaceShow1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PicFaceShow1.TabIndex = 6
        Me.PicFaceShow1.TabStop = False
        Me.PicFaceShow1.Visible = False
        '
        'DG
        '
        Me.DG.AllowUserToDeleteRows = False
        Me.DG.AllowUserToOrderColumns = True
        Me.DG.AllowUserToResizeColumns = False
        Me.DG.AllowUserToResizeRows = False
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        Me.DG.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.DG.BackgroundColor = System.Drawing.Color.White
        Me.DG.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DG.ColumnHeadersVisible = False
        Me.DG.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Column7, Me.Column8, Me.Column9, Me.Column10, Me.Column11, Me.Column12, Me.Column13, Me.Column14, Me.Column15})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DG.DefaultCellStyle = DataGridViewCellStyle4
        Me.DG.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DG.GridColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.DG.Location = New System.Drawing.Point(3, 3)
        Me.DG.MultiSelect = False
        Me.DG.Name = "DG"
        Me.DG.ReadOnly = True
        Me.DG.RowHeadersVisible = False
        Me.DG.RowTemplate.Height = 23
        Me.DG.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.DG.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.DG.Size = New System.Drawing.Size(453, 270)
        Me.DG.TabIndex = 5
        '
        'Column1
        '
        Me.Column1.HeaderText = "Column1"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 30
        '
        'Column2
        '
        Me.Column2.HeaderText = "Column2"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 30
        '
        'Column3
        '
        Me.Column3.HeaderText = "Column3"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 30
        '
        'Column4
        '
        Me.Column4.HeaderText = "Column4"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 30
        '
        'Column5
        '
        Me.Column5.HeaderText = "Column5"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 30
        '
        'Column6
        '
        Me.Column6.HeaderText = "Column6"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Width = 30
        '
        'Column7
        '
        Me.Column7.HeaderText = "Column7"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        Me.Column7.Width = 30
        '
        'Column8
        '
        Me.Column8.HeaderText = "Column8"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        Me.Column8.Width = 30
        '
        'Column9
        '
        Me.Column9.HeaderText = "Column9"
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        Me.Column9.Width = 30
        '
        'Column10
        '
        Me.Column10.HeaderText = "Column10"
        Me.Column10.Name = "Column10"
        Me.Column10.ReadOnly = True
        Me.Column10.Width = 30
        '
        'Column11
        '
        Me.Column11.HeaderText = "Column11"
        Me.Column11.Name = "Column11"
        Me.Column11.ReadOnly = True
        Me.Column11.Width = 30
        '
        'Column12
        '
        Me.Column12.HeaderText = "Column12"
        Me.Column12.Name = "Column12"
        Me.Column12.ReadOnly = True
        Me.Column12.Width = 30
        '
        'Column13
        '
        Me.Column13.HeaderText = "Column13"
        Me.Column13.Name = "Column13"
        Me.Column13.ReadOnly = True
        Me.Column13.Width = 30
        '
        'Column14
        '
        Me.Column14.HeaderText = "Column14"
        Me.Column14.Name = "Column14"
        Me.Column14.ReadOnly = True
        Me.Column14.Width = 30
        '
        'Column15
        '
        Me.Column15.HeaderText = "Column15"
        Me.Column15.Name = "Column15"
        Me.Column15.ReadOnly = True
        Me.Column15.Width = 30
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.PanelFace)
        Me.TabPage2.Location = New System.Drawing.Point(4, 21)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(459, 276)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "动态显示"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TimerShow
        '
        Me.TimerShow.Interval = 1
        '
        'FormFace
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(467, 301)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FormFace"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "FormFace"
        Me.TopMost = True
        Me.TransparencyKey = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.PicFaceShow1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DG, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelFace As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents PicFaceShow1 As System.Windows.Forms.PictureBox
    Friend WithEvents DG As System.Windows.Forms.DataGridView
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents Column9 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents Column10 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents Column11 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents Column12 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents Column13 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents Column14 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents Column15 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TimerShow As System.Windows.Forms.Timer
End Class
