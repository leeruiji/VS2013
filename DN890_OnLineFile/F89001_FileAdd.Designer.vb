<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F89001_FileAdd
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F89001_FileAdd))
        Me.Tool_Top = New System.Windows.Forms.ToolStrip
        Me.Cmd_Add = New System.Windows.Forms.ToolStripButton
        Me.Cmd_Modify = New System.Windows.Forms.ToolStripButton
        Me.Cmd_Del = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.Cmd_Print = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.Cmd_Exit = New System.Windows.Forms.ToolStripButton
        Me.Labeld_Founder = New System.Windows.Forms.ToolStripLabel
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel
        Me.PanelMain = New System.Windows.Forms.Panel
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.OFX = New AxEDOfficeLib.AxEDOffice
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.TollStripLabel1 = New System.Windows.Forms.ToolStripLabel
        Me.TextBox_FileName = New System.Windows.Forms.ToolStripTextBox
        Me.Lable_UPD_USER = New System.Windows.Forms.ToolStripLabel
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel
        Me.TextBox_Remark = New System.Windows.Forms.ToolStripTextBox
        Me.Panel_New = New System.Windows.Forms.Panel
        Me.GroupBox_New = New System.Windows.Forms.GroupBox
        Me.Cmd_Open = New System.Windows.Forms.Button
        Me.Cmd_NewExit = New System.Windows.Forms.Button
        Me.Cmd_NewWord = New System.Windows.Forms.Button
        Me.Cmd_NewExcel = New System.Windows.Forms.Button
        Me.TimerStart = New System.Windows.Forms.Timer(Me.components)
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.Tool_Top.SuspendLayout()
        Me.PanelMain.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.OFX, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.Panel_New.SuspendLayout()
        Me.GroupBox_New.SuspendLayout()
        Me.SuspendLayout()
        '
        'Tool_Top
        '
        Me.Tool_Top.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.Tool_Top.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Cmd_Add, Me.Cmd_Modify, Me.Cmd_Del, Me.ToolStripSeparator1, Me.Cmd_Print, Me.ToolStripSeparator2, Me.Cmd_Exit, Me.Labeld_Founder, Me.ToolStripLabel2})
        Me.Tool_Top.Location = New System.Drawing.Point(2, 2)
        Me.Tool_Top.MinimumSize = New System.Drawing.Size(0, 30)
        Me.Tool_Top.Name = "Tool_Top"
        Me.Tool_Top.Size = New System.Drawing.Size(923, 30)
        Me.Tool_Top.TabIndex = 10
        Me.Tool_Top.Text = "ToolStrip2"
        '
        'Cmd_Add
        '
        Me.Cmd_Add.AccessibleDescription = ""
        Me.Cmd_Add.AccessibleName = ""
        Me.Cmd_Add.Image = Global.DN890_OnLineFile.My.Resources.Resources.ADD
        Me.Cmd_Add.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Add.Name = "Cmd_Add"
        Me.Cmd_Add.Size = New System.Drawing.Size(105, 27)
        Me.Cmd_Add.Text = "新增到服务器"
        '
        'Cmd_Modify
        '
        Me.Cmd_Modify.AccessibleDescription = "修改按钮"
        Me.Cmd_Modify.AccessibleName = ""
        Me.Cmd_Modify.Image = Global.DN890_OnLineFile.My.Resources.Resources.save
        Me.Cmd_Modify.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Modify.Name = "Cmd_Modify"
        Me.Cmd_Modify.Size = New System.Drawing.Size(81, 27)
        Me.Cmd_Modify.Text = "保存修改"
        '
        'Cmd_Del
        '
        Me.Cmd_Del.AccessibleDescription = ""
        Me.Cmd_Del.AccessibleName = ""
        Me.Cmd_Del.Image = Global.DN890_OnLineFile.My.Resources.Resources.Delete
        Me.Cmd_Del.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Del.Name = "Cmd_Del"
        Me.Cmd_Del.Size = New System.Drawing.Size(81, 27)
        Me.Cmd_Del.Text = "删除文档"
        Me.Cmd_Del.Visible = False
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 30)
        '
        'Cmd_Print
        '
        Me.Cmd_Print.AccessibleDescription = ""
        Me.Cmd_Print.AccessibleName = ""
        Me.Cmd_Print.Image = Global.DN890_OnLineFile.My.Resources.Resources.Print_preview
        Me.Cmd_Print.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Print.Name = "Cmd_Print"
        Me.Cmd_Print.Size = New System.Drawing.Size(81, 27)
        Me.Cmd_Print.Text = "文档打印"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 30)
        '
        'Cmd_Exit
        '
        Me.Cmd_Exit.Image = Global.DN890_OnLineFile.My.Resources.Resources.Close
        Me.Cmd_Exit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(57, 27)
        Me.Cmd_Exit.Text = "关闭"
        '
        'Labeld_Founder
        '
        Me.Labeld_Founder.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.Labeld_Founder.ForeColor = System.Drawing.Color.Blue
        Me.Labeld_Founder.Margin = New System.Windows.Forms.Padding(0, 0, 0, 10)
        Me.Labeld_Founder.Name = "Labeld_Founder"
        Me.Labeld_Founder.Size = New System.Drawing.Size(11, 20)
        Me.Labeld_Founder.Text = " "
        Me.Labeld_Founder.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel2.Margin = New System.Windows.Forms.Padding(0, 0, 0, 10)
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(47, 20)
        Me.ToolStripLabel2.Text = "创建人:"
        Me.ToolStripLabel2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'PanelMain
        '
        Me.PanelMain.Controls.Add(Me.Panel1)
        Me.PanelMain.Controls.Add(Me.ToolStrip1)
        Me.PanelMain.Controls.Add(Me.Tool_Top)
        Me.PanelMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelMain.Location = New System.Drawing.Point(0, 0)
        Me.PanelMain.Name = "PanelMain"
        Me.PanelMain.Padding = New System.Windows.Forms.Padding(2)
        Me.PanelMain.Size = New System.Drawing.Size(927, 700)
        Me.PanelMain.TabIndex = 12
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.OFX)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(2, 57)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(3)
        Me.Panel1.Size = New System.Drawing.Size(923, 641)
        Me.Panel1.TabIndex = 11
        '
        'OFX
        '
        Me.OFX.Dock = System.Windows.Forms.DockStyle.Fill
        Me.OFX.Enabled = True
        Me.OFX.Location = New System.Drawing.Point(3, 3)
        Me.OFX.Name = "OFX"
        Me.OFX.OcxState = CType(resources.GetObject("OFX.OcxState"), System.Windows.Forms.AxHost.State)
        Me.OFX.Size = New System.Drawing.Size(917, 635)
        Me.OFX.TabIndex = 0
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TollStripLabel1, Me.TextBox_FileName, Me.Lable_UPD_USER, Me.ToolStripLabel1, Me.ToolStripLabel3, Me.TextBox_Remark})
        Me.ToolStrip1.Location = New System.Drawing.Point(2, 32)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(923, 25)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'TollStripLabel1
        '
        Me.TollStripLabel1.Name = "TollStripLabel1"
        Me.TollStripLabel1.Size = New System.Drawing.Size(59, 22)
        Me.TollStripLabel1.Text = "文件标题:"
        '
        'TextBox_FileName
        '
        Me.TextBox_FileName.Name = "TextBox_FileName"
        Me.TextBox_FileName.Size = New System.Drawing.Size(300, 25)
        '
        'Lable_UPD_USER
        '
        Me.Lable_UPD_USER.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.Lable_UPD_USER.ForeColor = System.Drawing.Color.Blue
        Me.Lable_UPD_USER.Name = "Lable_UPD_USER"
        Me.Lable_UPD_USER.Size = New System.Drawing.Size(0, 22)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(71, 22)
        Me.ToolStripLabel1.Text = "最后修改人:"
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(35, 22)
        Me.ToolStripLabel3.Text = "备注:"
        '
        'TextBox_Remark
        '
        Me.TextBox_Remark.Name = "TextBox_Remark"
        Me.TextBox_Remark.Size = New System.Drawing.Size(300, 25)
        '
        'Panel_New
        '
        Me.Panel_New.Controls.Add(Me.GroupBox_New)
        Me.Panel_New.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel_New.Location = New System.Drawing.Point(0, 0)
        Me.Panel_New.Name = "Panel_New"
        Me.Panel_New.Size = New System.Drawing.Size(927, 700)
        Me.Panel_New.TabIndex = 2
        Me.Panel_New.Visible = False
        '
        'GroupBox_New
        '
        Me.GroupBox_New.Controls.Add(Me.Cmd_Open)
        Me.GroupBox_New.Controls.Add(Me.Cmd_NewExit)
        Me.GroupBox_New.Controls.Add(Me.Cmd_NewWord)
        Me.GroupBox_New.Controls.Add(Me.Cmd_NewExcel)
        Me.GroupBox_New.Location = New System.Drawing.Point(192, 214)
        Me.GroupBox_New.Name = "GroupBox_New"
        Me.GroupBox_New.Size = New System.Drawing.Size(506, 189)
        Me.GroupBox_New.TabIndex = 0
        Me.GroupBox_New.TabStop = False
        Me.GroupBox_New.Text = "创建文档类型"
        '
        'Cmd_Open
        '
        Me.Cmd_Open.Image = Global.DN890_OnLineFile.My.Resources.Resources.Export
        Me.Cmd_Open.Location = New System.Drawing.Point(6, 68)
        Me.Cmd_Open.Name = "Cmd_Open"
        Me.Cmd_Open.Size = New System.Drawing.Size(107, 79)
        Me.Cmd_Open.TabIndex = 3
        Me.Cmd_Open.Text = "导入新文档"
        Me.Cmd_Open.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Cmd_Open.UseVisualStyleBackColor = True
        '
        'Cmd_NewExit
        '
        Me.Cmd_NewExit.Image = Global.DN890_OnLineFile.My.Resources.Resources.Close
        Me.Cmd_NewExit.Location = New System.Drawing.Point(380, 68)
        Me.Cmd_NewExit.Name = "Cmd_NewExit"
        Me.Cmd_NewExit.Size = New System.Drawing.Size(107, 79)
        Me.Cmd_NewExit.TabIndex = 2
        Me.Cmd_NewExit.Text = "退出"
        Me.Cmd_NewExit.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Cmd_NewExit.UseVisualStyleBackColor = True
        '
        'Cmd_NewWord
        '
        Me.Cmd_NewWord.Image = Global.DN890_OnLineFile.My.Resources.Resources.Word
        Me.Cmd_NewWord.Location = New System.Drawing.Point(131, 68)
        Me.Cmd_NewWord.Name = "Cmd_NewWord"
        Me.Cmd_NewWord.Size = New System.Drawing.Size(107, 79)
        Me.Cmd_NewWord.TabIndex = 1
        Me.Cmd_NewWord.Text = "创建Word文档"
        Me.Cmd_NewWord.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Cmd_NewWord.UseVisualStyleBackColor = True
        '
        'Cmd_NewExcel
        '
        Me.Cmd_NewExcel.Image = Global.DN890_OnLineFile.My.Resources.Resources.Excel
        Me.Cmd_NewExcel.Location = New System.Drawing.Point(256, 68)
        Me.Cmd_NewExcel.Name = "Cmd_NewExcel"
        Me.Cmd_NewExcel.Size = New System.Drawing.Size(107, 79)
        Me.Cmd_NewExcel.TabIndex = 0
        Me.Cmd_NewExcel.Text = "创建Excel文档"
        Me.Cmd_NewExcel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Cmd_NewExcel.UseVisualStyleBackColor = True
        '
        'TimerStart
        '
        Me.TimerStart.Interval = 1
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'F89001_FileAdd
        '
        Me.AutoMax = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CanMaxSize = True
        Me.Controls.Add(Me.PanelMain)
        Me.Controls.Add(Me.Panel_New)
        Me.Name = "F89001_FileAdd"
        Me.Title = "在线文档"
        Me.Tool_Top.ResumeLayout(False)
        Me.Tool_Top.PerformLayout()
        Me.PanelMain.ResumeLayout(False)
        Me.PanelMain.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.OFX, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Panel_New.ResumeLayout(False)
        Me.GroupBox_New.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Tool_Top As System.Windows.Forms.ToolStrip
    Friend WithEvents Cmd_Add As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_Modify As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_Del As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Cmd_Exit As System.Windows.Forms.ToolStripButton
    Friend WithEvents PanelMain As System.Windows.Forms.Panel
    Friend WithEvents OFX As AxEDOfficeLib.AxEDOffice
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents TollStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents TextBox_FileName As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents Lable_UPD_USER As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Labeld_Founder As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Panel_New As System.Windows.Forms.Panel
    Friend WithEvents GroupBox_New As System.Windows.Forms.GroupBox
    Friend WithEvents Cmd_NewExit As System.Windows.Forms.Button
    Friend WithEvents Cmd_NewWord As System.Windows.Forms.Button
    Friend WithEvents Cmd_NewExcel As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TimerStart As System.Windows.Forms.Timer
    Friend WithEvents ToolStripLabel3 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents TextBox_Remark As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Cmd_Print As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_Open As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog

End Class
