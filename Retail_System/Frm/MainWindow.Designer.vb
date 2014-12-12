<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainWindow
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainWindow))
        Me.Pic_Refresh = New System.Windows.Forms.PictureBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.CommandBars = New AxXtremeCommandBars.AxCommandBars()
        Me.PopupControl = New AxXtremeSuiteControls.AxPopupControl()
        CType(Me.Pic_Refresh, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CommandBars, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PopupControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Pic_Refresh
        '
        Me.Pic_Refresh.Image = Global.Retail_System.My.Resources.Resources.uk
        Me.Pic_Refresh.Location = New System.Drawing.Point(328, 171)
        Me.Pic_Refresh.Name = "Pic_Refresh"
        Me.Pic_Refresh.Size = New System.Drawing.Size(32, 32)
        Me.Pic_Refresh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.Pic_Refresh.TabIndex = 9
        Me.Pic_Refresh.TabStop = False
        Me.Pic_Refresh.Visible = False
        '
        'Timer1
        '
        Me.Timer1.Interval = 500
        '
        'CommandBars
        '
        Me.CommandBars.Enabled = True
        Me.CommandBars.Location = New System.Drawing.Point(251, 155)
        Me.CommandBars.Name = "CommandBars"
        Me.CommandBars.OcxState = CType(resources.GetObject("CommandBars.OcxState"), System.Windows.Forms.AxHost.State)
        Me.CommandBars.Size = New System.Drawing.Size(24, 24)
        Me.CommandBars.TabIndex = 5
        '
        'PopupControl
        '
        Me.PopupControl.Enabled = True
        Me.PopupControl.Location = New System.Drawing.Point(221, 155)
        Me.PopupControl.Name = "PopupControl"
        Me.PopupControl.OcxState = CType(resources.GetObject("PopupControl.OcxState"), System.Windows.Forms.AxHost.State)
        Me.PopupControl.Size = New System.Drawing.Size(24, 24)
        Me.PopupControl.TabIndex = 11
        '
        'MainWindow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(868, 652)
        Me.Controls.Add(Me.CommandBars)
        Me.Controls.Add(Me.PopupControl)
        Me.Controls.Add(Me.Pic_Refresh)
        Me.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.IsMdiContainer = True
        Me.Name = "MainWindow"
        Me.Text = "V3进销存"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.Pic_Refresh, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CommandBars, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PopupControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Pic_Refresh As System.Windows.Forms.PictureBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Public WithEvents CommandBars As AxXtremeCommandBars.AxCommandBars
    Public WithEvents PopupControl As AxXtremeSuiteControls.AxPopupControl

End Class
