<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F40930_CPDay
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F40930_CPDay))
        Me.PanelMain = New System.Windows.Forms.Panel
        Me.GR = New AxgrproLib.AxGRDisplayViewer
        Me.Tool_Search = New System.Windows.Forms.ToolStrip
        Me.ToolStripLabel4 = New System.Windows.Forms.ToolStripLabel
        Me.DP_Start = New PClass.ToolStripDateTimePicker
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel
        Me.DP_End = New PClass.ToolStripDateTimePicker
        Me.CK_CP = New System.Windows.Forms.ToolStripDropDownButton
        Me.MenuItem_CPJC = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuItem_CPCH = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuItem_WJC = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuItem_ALL = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel
        Me.TSC_Client = New BaseClass.ToolStripComboList
        Me.ToolStripLabel5 = New System.Windows.Forms.ToolStripLabel
        Me.TSC_BZ = New BaseClass.ToolStripComboList
        Me.Btn_Search = New System.Windows.Forms.ToolStripButton
        Me.Cmd_Preview = New System.Windows.Forms.ToolStripButton
        Me.Cmd_Exit = New System.Windows.Forms.ToolStripButton
        Me.Label_ZL = New System.Windows.Forms.ToolStripLabel
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel
        Me.Label_Num = New System.Windows.Forms.ToolStripLabel
        Me.ToolStripLabel8 = New System.Windows.Forms.ToolStripLabel
        Me.Label_XiaDan = New System.Windows.Forms.ToolStripLabel
        Me.ToolStripLabel6 = New System.Windows.Forms.ToolStripLabel
        Me.MenuItem_YW = New System.Windows.Forms.ToolStripMenuItem
        Me.PanelMain.SuspendLayout()
        CType(Me.GR, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tool_Search.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelMain
        '
        Me.PanelMain.Controls.Add(Me.GR)
        Me.PanelMain.Controls.Add(Me.Tool_Search)
        Me.PanelMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelMain.Location = New System.Drawing.Point(0, 0)
        Me.PanelMain.Name = "PanelMain"
        Me.PanelMain.Padding = New System.Windows.Forms.Padding(2)
        Me.PanelMain.Size = New System.Drawing.Size(1174, 618)
        Me.PanelMain.TabIndex = 0
        '
        'GR
        '
        Me.GR.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GR.Enabled = True
        Me.GR.Location = New System.Drawing.Point(2, 34)
        Me.GR.Name = "GR"
        Me.GR.OcxState = CType(resources.GetObject("GR.OcxState"), System.Windows.Forms.AxHost.State)
        Me.GR.Size = New System.Drawing.Size(1170, 582)
        Me.GR.TabIndex = 17
        '
        'Tool_Search
        '
        Me.Tool_Search.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.Tool_Search.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel4, Me.DP_Start, Me.ToolStripLabel3, Me.DP_End, Me.CK_CP, Me.ToolStripLabel1, Me.TSC_Client, Me.ToolStripLabel5, Me.TSC_BZ, Me.Btn_Search, Me.Cmd_Preview, Me.Cmd_Exit, Me.Label_ZL, Me.ToolStripLabel2, Me.Label_Num, Me.ToolStripLabel8, Me.Label_XiaDan, Me.ToolStripLabel6})
        Me.Tool_Search.Location = New System.Drawing.Point(2, 2)
        Me.Tool_Search.MinimumSize = New System.Drawing.Size(0, 32)
        Me.Tool_Search.Name = "Tool_Search"
        Me.Tool_Search.Size = New System.Drawing.Size(1170, 32)
        Me.Tool_Search.TabIndex = 14
        Me.Tool_Search.Text = "ToolStrip1"
        '
        'ToolStripLabel4
        '
        Me.ToolStripLabel4.Name = "ToolStripLabel4"
        Me.ToolStripLabel4.Size = New System.Drawing.Size(17, 29)
        Me.ToolStripLabel4.Text = "从"
        '
        'DP_Start
        '
        Me.DP_Start.Name = "DP_Start"
        Me.DP_Start.Size = New System.Drawing.Size(100, 29)
        Me.DP_Start.Text = "2012-03-02"
        Me.DP_Start.Value = New Date(2012, 3, 2, 0, 0, 0, 0)
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.Margin = New System.Windows.Forms.Padding(2, 1, 2, 2)
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(17, 29)
        Me.ToolStripLabel3.Text = "到"
        '
        'DP_End
        '
        Me.DP_End.Name = "DP_End"
        Me.DP_End.Size = New System.Drawing.Size(100, 29)
        Me.DP_End.Text = "2012-03-02"
        Me.DP_End.Value = New Date(2012, 3, 2, 0, 0, 0, 0)
        '
        'CK_CP
        '
        Me.CK_CP.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuItem_CPJC, Me.MenuItem_CPCH, Me.MenuItem_YW, Me.MenuItem_WJC, Me.MenuItem_ALL})
        Me.CK_CP.ForeColor = System.Drawing.Color.Blue
        Me.CK_CP.Image = Global.DN400_Store.My.Resources.Resources._75
        Me.CK_CP.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CK_CP.Name = "CK_CP"
        Me.CK_CP.Size = New System.Drawing.Size(90, 29)
        Me.CK_CP.Text = "成品进仓"
        '
        'MenuItem_CPJC
        '
        Me.MenuItem_CPJC.Name = "MenuItem_CPJC"
        Me.MenuItem_CPJC.Size = New System.Drawing.Size(152, 22)
        Me.MenuItem_CPJC.Text = "成品进仓"
        '
        'MenuItem_CPCH
        '
        Me.MenuItem_CPCH.Name = "MenuItem_CPCH"
        Me.MenuItem_CPCH.Size = New System.Drawing.Size(152, 22)
        Me.MenuItem_CPCH.Text = "成品出货"
        '
        'MenuItem_WJC
        '
        Me.MenuItem_WJC.Name = "MenuItem_WJC"
        Me.MenuItem_WJC.Size = New System.Drawing.Size(152, 22)
        Me.MenuItem_WJC.Text = "未进仓"
        '
        'MenuItem_ALL
        '
        Me.MenuItem_ALL.Name = "MenuItem_ALL"
        Me.MenuItem_ALL.Size = New System.Drawing.Size(152, 22)
        Me.MenuItem_ALL.Text = "全部"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(41, 29)
        Me.ToolStripLabel1.Text = "客户："
        '
        'TSC_Client
        '
        Me.TSC_Client.Child = "ComboClient"
        Me.TSC_Client.IDAsInt = 0
        Me.TSC_Client.IDValue = "0"
        Me.TSC_Client.IsKeyDownAutoSearch = True
        Me.TSC_Client.Name = "TSC_Client"
        Me.TSC_Client.SearchType = BaseClass.cSearchType.ENum_SearchType.ALL
        Me.TSC_Client.Size = New System.Drawing.Size(100, 29)
        '
        'ToolStripLabel5
        '
        Me.ToolStripLabel5.Name = "ToolStripLabel5"
        Me.ToolStripLabel5.Size = New System.Drawing.Size(41, 29)
        Me.ToolStripLabel5.Text = "布类："
        '
        'TSC_BZ
        '
        Me.TSC_BZ.Child = "ComboBZ"
        Me.TSC_BZ.IDAsInt = 0
        Me.TSC_BZ.IDValue = "0"
        Me.TSC_BZ.IsKeyDownAutoSearch = True
        Me.TSC_BZ.Name = "TSC_BZ"
        Me.TSC_BZ.SearchType = BaseClass.cSearchType.ENum_SearchType.ALL
        Me.TSC_BZ.Size = New System.Drawing.Size(140, 29)
        '
        'Btn_Search
        '
        Me.Btn_Search.Image = CType(resources.GetObject("Btn_Search.Image"), System.Drawing.Image)
        Me.Btn_Search.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.Btn_Search.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Btn_Search.Name = "Btn_Search"
        Me.Btn_Search.Size = New System.Drawing.Size(65, 29)
        Me.Btn_Search.Text = "搜索"
        '
        'Cmd_Preview
        '
        Me.Cmd_Preview.Enabled = False
        Me.Cmd_Preview.Image = Global.DN400_Store.My.Resources.Resources.Print_preview
        Me.Cmd_Preview.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Preview.Name = "Cmd_Preview"
        Me.Cmd_Preview.Size = New System.Drawing.Size(57, 29)
        Me.Cmd_Preview.Text = "预览"
        '
        'Cmd_Exit
        '
        Me.Cmd_Exit.Image = Global.DN400_Store.My.Resources.Resources.Close
        Me.Cmd_Exit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(57, 29)
        Me.Cmd_Exit.Text = "关闭"
        '
        'Label_ZL
        '
        Me.Label_ZL.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.Label_ZL.ForeColor = System.Drawing.Color.Blue
        Me.Label_ZL.Margin = New System.Windows.Forms.Padding(5, 1, 10, 2)
        Me.Label_ZL.Name = "Label_ZL"
        Me.Label_ZL.Size = New System.Drawing.Size(11, 29)
        Me.Label_ZL.Text = "0"
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(35, 29)
        Me.ToolStripLabel2.Text = "剩余:"
        '
        'Label_Num
        '
        Me.Label_Num.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.Label_Num.ForeColor = System.Drawing.Color.Blue
        Me.Label_Num.Margin = New System.Windows.Forms.Padding(5, 1, 10, 2)
        Me.Label_Num.Name = "Label_Num"
        Me.Label_Num.Size = New System.Drawing.Size(11, 29)
        Me.Label_Num.Text = "0"
        '
        'ToolStripLabel8
        '
        Me.ToolStripLabel8.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel8.Name = "ToolStripLabel8"
        Me.ToolStripLabel8.Size = New System.Drawing.Size(35, 29)
        Me.ToolStripLabel8.Text = "入库:"
        '
        'Label_XiaDan
        '
        Me.Label_XiaDan.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.Label_XiaDan.ForeColor = System.Drawing.Color.Blue
        Me.Label_XiaDan.Margin = New System.Windows.Forms.Padding(5, 1, 10, 2)
        Me.Label_XiaDan.Name = "Label_XiaDan"
        Me.Label_XiaDan.Size = New System.Drawing.Size(11, 29)
        Me.Label_XiaDan.Text = "0"
        '
        'ToolStripLabel6
        '
        Me.ToolStripLabel6.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel6.Name = "ToolStripLabel6"
        Me.ToolStripLabel6.Size = New System.Drawing.Size(35, 29)
        Me.ToolStripLabel6.Text = "下单:"
        '
        'MenuItem_YW
        '
        Me.MenuItem_YW.Name = "MenuItem_YW"
        Me.MenuItem_YW.Size = New System.Drawing.Size(152, 22)
        Me.MenuItem_YW.Text = "已入库未出库"
        '
        'F40930_CPDay
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CanMaxSize = True
        Me.Controls.Add(Me.PanelMain)
        Me.ForeColor = System.Drawing.Color.Black
        Me.Name = "F40930_CPDay"
        Me.Size = New System.Drawing.Size(1174, 618)
        Me.PanelMain.ResumeLayout(False)
        Me.PanelMain.PerformLayout()
        CType(Me.GR, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tool_Search.ResumeLayout(False)
        Me.Tool_Search.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelMain As System.Windows.Forms.Panel
    Friend WithEvents Tool_Search As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel4 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabel3 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Btn_Search As System.Windows.Forms.ToolStripButton
    Friend WithEvents GR As AxgrproLib.AxGRDisplayViewer
    Friend WithEvents Cmd_Preview As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_Exit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Label_ZL As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabel6 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Label_Num As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabel5 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents TSC_Client As BaseClass.ToolStripComboList
    Friend WithEvents TSC_BZ As BaseClass.ToolStripComboList
    Friend WithEvents DP_Start As PClass.ToolStripDateTimePicker
    Friend WithEvents DP_End As PClass.ToolStripDateTimePicker
    Friend WithEvents ToolStripLabel8 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Label_XiaDan As System.Windows.Forms.ToolStripLabel
    Friend WithEvents CK_CP As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents MenuItem_CPJC As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuItem_CPCH As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuItem_WJC As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuItem_ALL As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuItem_YW As System.Windows.Forms.ToolStripMenuItem

End Class
