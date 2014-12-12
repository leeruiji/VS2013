<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormFaceSelect
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
        Me.PicSmall = New System.Windows.Forms.PictureBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.PicCutHead = New System.Windows.Forms.PictureBox
        Me.PicPointBR = New System.Windows.Forms.PictureBox
        Me.PicPointBM = New System.Windows.Forms.PictureBox
        Me.PicPointMR = New System.Windows.Forms.PictureBox
        Me.PicPointBL = New System.Windows.Forms.PictureBox
        Me.PicPointML = New System.Windows.Forms.PictureBox
        Me.PicPointTR = New System.Windows.Forms.PictureBox
        Me.PicPointTM = New System.Windows.Forms.PictureBox
        Me.PicPointTL = New System.Windows.Forms.PictureBox
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Cmd_Load = New System.Windows.Forms.Button
        Me.PicBig = New System.Windows.Forms.PictureBox
        Me.RadioButton1 = New System.Windows.Forms.RadioButton
        Me.RadioButton2 = New System.Windows.Forms.RadioButton
        Me.RadioButton3 = New System.Windows.Forms.RadioButton
        Me.RadioButton4 = New System.Windows.Forms.RadioButton
        Me.Cmd_Small = New System.Windows.Forms.Button
        Me.Cmd_GetBack = New System.Windows.Forms.Button
        Me.Cmd_ImageCut = New System.Windows.Forms.Button
        Me.TimerCutPic = New System.Windows.Forms.Timer(Me.components)
        Me.Cmd_Save = New System.Windows.Forms.Button
        CType(Me.PicSmall, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.PicCutHead, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicPointBR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicPointBM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicPointMR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicPointBL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicPointML, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicPointTR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicPointTM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicPointTL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicBig, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PicSmall
        '
        Me.PicSmall.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.PicSmall.Location = New System.Drawing.Point(536, 12)
        Me.PicSmall.Name = "PicSmall"
        Me.PicSmall.Size = New System.Drawing.Size(20, 20)
        Me.PicSmall.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PicSmall.TabIndex = 1
        Me.PicSmall.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Panel1.Controls.Add(Me.PicCutHead)
        Me.Panel1.Controls.Add(Me.PicPointBR)
        Me.Panel1.Controls.Add(Me.PicPointBM)
        Me.Panel1.Controls.Add(Me.PicPointMR)
        Me.Panel1.Controls.Add(Me.PicPointBL)
        Me.Panel1.Controls.Add(Me.PicPointML)
        Me.Panel1.Controls.Add(Me.PicPointTR)
        Me.Panel1.Controls.Add(Me.PicPointTM)
        Me.Panel1.Controls.Add(Me.PicPointTL)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Location = New System.Drawing.Point(12, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(500, 500)
        Me.Panel1.TabIndex = 2
        '
        'PicCutHead
        '
        Me.PicCutHead.BackColor = System.Drawing.Color.Transparent
        Me.PicCutHead.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PicCutHead.Cursor = System.Windows.Forms.Cursors.SizeAll
        Me.PicCutHead.Location = New System.Drawing.Point(220, 200)
        Me.PicCutHead.Name = "PicCutHead"
        Me.PicCutHead.Size = New System.Drawing.Size(64, 64)
        Me.PicCutHead.TabIndex = 1
        Me.PicCutHead.TabStop = False
        Me.PicCutHead.Visible = False
        '
        'PicPointBR
        '
        Me.PicPointBR.BackColor = System.Drawing.Color.White
        Me.PicPointBR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PicPointBR.Cursor = System.Windows.Forms.Cursors.SizeNWSE
        Me.PicPointBR.Location = New System.Drawing.Point(262, 167)
        Me.PicPointBR.Name = "PicPointBR"
        Me.PicPointBR.Size = New System.Drawing.Size(6, 6)
        Me.PicPointBR.TabIndex = 8
        Me.PicPointBR.TabStop = False
        Me.PicPointBR.Visible = False
        '
        'PicPointBM
        '
        Me.PicPointBM.BackColor = System.Drawing.Color.White
        Me.PicPointBM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PicPointBM.Cursor = System.Windows.Forms.Cursors.SizeNS
        Me.PicPointBM.Location = New System.Drawing.Point(195, 167)
        Me.PicPointBM.Name = "PicPointBM"
        Me.PicPointBM.Size = New System.Drawing.Size(6, 6)
        Me.PicPointBM.TabIndex = 9
        Me.PicPointBM.TabStop = False
        Me.PicPointBM.Visible = False
        '
        'PicPointMR
        '
        Me.PicPointMR.BackColor = System.Drawing.Color.White
        Me.PicPointMR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PicPointMR.Cursor = System.Windows.Forms.Cursors.SizeWE
        Me.PicPointMR.Location = New System.Drawing.Point(262, 99)
        Me.PicPointMR.Name = "PicPointMR"
        Me.PicPointMR.Size = New System.Drawing.Size(6, 6)
        Me.PicPointMR.TabIndex = 7
        Me.PicPointMR.TabStop = False
        Me.PicPointMR.Visible = False
        '
        'PicPointBL
        '
        Me.PicPointBL.BackColor = System.Drawing.Color.White
        Me.PicPointBL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PicPointBL.Cursor = System.Windows.Forms.Cursors.SizeNESW
        Me.PicPointBL.Location = New System.Drawing.Point(113, 167)
        Me.PicPointBL.Name = "PicPointBL"
        Me.PicPointBL.Size = New System.Drawing.Size(6, 6)
        Me.PicPointBL.TabIndex = 6
        Me.PicPointBL.TabStop = False
        Me.PicPointBL.Visible = False
        '
        'PicPointML
        '
        Me.PicPointML.BackColor = System.Drawing.Color.White
        Me.PicPointML.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PicPointML.Cursor = System.Windows.Forms.Cursors.SizeWE
        Me.PicPointML.Location = New System.Drawing.Point(113, 99)
        Me.PicPointML.Name = "PicPointML"
        Me.PicPointML.Size = New System.Drawing.Size(6, 6)
        Me.PicPointML.TabIndex = 5
        Me.PicPointML.TabStop = False
        Me.PicPointML.Visible = False
        '
        'PicPointTR
        '
        Me.PicPointTR.BackColor = System.Drawing.Color.White
        Me.PicPointTR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PicPointTR.Cursor = System.Windows.Forms.Cursors.SizeNESW
        Me.PicPointTR.Location = New System.Drawing.Point(262, 44)
        Me.PicPointTR.Name = "PicPointTR"
        Me.PicPointTR.Size = New System.Drawing.Size(6, 6)
        Me.PicPointTR.TabIndex = 4
        Me.PicPointTR.TabStop = False
        Me.PicPointTR.Visible = False
        '
        'PicPointTM
        '
        Me.PicPointTM.BackColor = System.Drawing.Color.White
        Me.PicPointTM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PicPointTM.Cursor = System.Windows.Forms.Cursors.SizeNS
        Me.PicPointTM.Location = New System.Drawing.Point(204, 44)
        Me.PicPointTM.Name = "PicPointTM"
        Me.PicPointTM.Size = New System.Drawing.Size(6, 6)
        Me.PicPointTM.TabIndex = 3
        Me.PicPointTM.TabStop = False
        Me.PicPointTM.Visible = False
        '
        'PicPointTL
        '
        Me.PicPointTL.BackColor = System.Drawing.Color.White
        Me.PicPointTL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PicPointTL.Cursor = System.Windows.Forms.Cursors.SizeNWSE
        Me.PicPointTL.Location = New System.Drawing.Point(113, 44)
        Me.PicPointTL.Name = "PicPointTL"
        Me.PicPointTL.Size = New System.Drawing.Size(6, 6)
        Me.PicPointTL.TabIndex = 2
        Me.PicPointTL.TabStop = False
        Me.PicPointTL.Visible = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(500, 500)
        Me.Panel2.TabIndex = 10
        Me.Panel2.Visible = False
        '
        'Cmd_Load
        '
        Me.Cmd_Load.Location = New System.Drawing.Point(518, 359)
        Me.Cmd_Load.Name = "Cmd_Load"
        Me.Cmd_Load.Size = New System.Drawing.Size(73, 40)
        Me.Cmd_Load.TabIndex = 3
        Me.Cmd_Load.Text = "加载图片"
        Me.Cmd_Load.UseVisualStyleBackColor = True
        '
        'PicBig
        '
        Me.PicBig.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.PicBig.Location = New System.Drawing.Point(536, 56)
        Me.PicBig.Name = "PicBig"
        Me.PicBig.Size = New System.Drawing.Size(40, 40)
        Me.PicBig.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PicBig.TabIndex = 4
        Me.PicBig.TabStop = False
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(532, 470)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(47, 16)
        Me.RadioButton1.TabIndex = 5
        Me.RadioButton1.Text = "平铺"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Checked = True
        Me.RadioButton2.Location = New System.Drawing.Point(532, 492)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(47, 16)
        Me.RadioButton2.TabIndex = 6
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "缩放"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.Location = New System.Drawing.Point(585, 470)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(47, 16)
        Me.RadioButton3.TabIndex = 7
        Me.RadioButton3.Text = "拉伸"
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'RadioButton4
        '
        Me.RadioButton4.AutoSize = True
        Me.RadioButton4.Location = New System.Drawing.Point(585, 492)
        Me.RadioButton4.Name = "RadioButton4"
        Me.RadioButton4.Size = New System.Drawing.Size(47, 16)
        Me.RadioButton4.TabIndex = 8
        Me.RadioButton4.Text = "居中"
        Me.RadioButton4.UseVisualStyleBackColor = True
        '
        'Cmd_Small
        '
        Me.Cmd_Small.Location = New System.Drawing.Point(607, 359)
        Me.Cmd_Small.Name = "Cmd_Small"
        Me.Cmd_Small.Size = New System.Drawing.Size(73, 40)
        Me.Cmd_Small.TabIndex = 9
        Me.Cmd_Small.Text = "小图再编辑"
        Me.Cmd_Small.UseVisualStyleBackColor = True
        '
        'Cmd_GetBack
        '
        Me.Cmd_GetBack.Enabled = False
        Me.Cmd_GetBack.Location = New System.Drawing.Point(518, 405)
        Me.Cmd_GetBack.Name = "Cmd_GetBack"
        Me.Cmd_GetBack.Size = New System.Drawing.Size(73, 40)
        Me.Cmd_GetBack.TabIndex = 10
        Me.Cmd_GetBack.Text = "重新加载"
        Me.Cmd_GetBack.UseVisualStyleBackColor = True
        '
        'Cmd_ImageCut
        '
        Me.Cmd_ImageCut.Location = New System.Drawing.Point(607, 405)
        Me.Cmd_ImageCut.Name = "Cmd_ImageCut"
        Me.Cmd_ImageCut.Size = New System.Drawing.Size(73, 40)
        Me.Cmd_ImageCut.TabIndex = 11
        Me.Cmd_ImageCut.Text = "屏幕截图"
        Me.Cmd_ImageCut.UseVisualStyleBackColor = True
        '
        'TimerCutPic
        '
        Me.TimerCutPic.Interval = 1
        '
        'Cmd_Save
        '
        Me.Cmd_Save.Enabled = False
        Me.Cmd_Save.Location = New System.Drawing.Point(607, 313)
        Me.Cmd_Save.Name = "Cmd_Save"
        Me.Cmd_Save.Size = New System.Drawing.Size(73, 40)
        Me.Cmd_Save.TabIndex = 12
        Me.Cmd_Save.Text = "保存设置"
        Me.Cmd_Save.UseVisualStyleBackColor = True
        '
        'FormFaceSelect
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(692, 520)
        Me.Controls.Add(Me.Cmd_Save)
        Me.Controls.Add(Me.Cmd_ImageCut)
        Me.Controls.Add(Me.Cmd_GetBack)
        Me.Controls.Add(Me.Cmd_Small)
        Me.Controls.Add(Me.RadioButton4)
        Me.Controls.Add(Me.RadioButton3)
        Me.Controls.Add(Me.RadioButton2)
        Me.Controls.Add(Me.RadioButton1)
        Me.Controls.Add(Me.PicBig)
        Me.Controls.Add(Me.Cmd_Load)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PicSmall)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormFaceSelect"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "头像选择"
        CType(Me.PicSmall, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.PicCutHead, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicPointBR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicPointBM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicPointMR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicPointBL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicPointML, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicPointTR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicPointTM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicPointTL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicBig, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PicSmall As System.Windows.Forms.PictureBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PicPointBR As System.Windows.Forms.PictureBox
    Friend WithEvents PicPointMR As System.Windows.Forms.PictureBox
    Friend WithEvents PicPointBL As System.Windows.Forms.PictureBox
    Friend WithEvents PicPointML As System.Windows.Forms.PictureBox
    Friend WithEvents PicPointTR As System.Windows.Forms.PictureBox
    Friend WithEvents PicPointTM As System.Windows.Forms.PictureBox
    Friend WithEvents PicCutHead As System.Windows.Forms.PictureBox
    Friend WithEvents PicPointTL As System.Windows.Forms.PictureBox
    Friend WithEvents PicPointBM As System.Windows.Forms.PictureBox
    Friend WithEvents Cmd_Load As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents PicBig As System.Windows.Forms.PictureBox
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton4 As System.Windows.Forms.RadioButton
    Friend WithEvents Cmd_Small As System.Windows.Forms.Button
    Friend WithEvents Cmd_GetBack As System.Windows.Forms.Button
    Friend WithEvents Cmd_ImageCut As System.Windows.Forms.Button
    Friend WithEvents TimerCutPic As System.Windows.Forms.Timer
    Friend WithEvents Cmd_Save As System.Windows.Forms.Button
End Class
