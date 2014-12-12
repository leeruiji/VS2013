<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Dialog
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Dialog))
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Menu_Pic_Cut = New System.Windows.Forms.ToolStripMenuItem
        Me.Menu_Sleep_Pic_Cut = New System.Windows.Forms.ToolStripMenuItem
        Me.Menu_Hide_Me = New System.Windows.Forms.ToolStripMenuItem
        Me.FontDialog1 = New System.Windows.Forms.FontDialog
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog
        Me.TimerCutPic = New System.Windows.Forms.Timer(Me.components)
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer
        Me.WB_Receive = New System.Windows.Forms.WebBrowser
        Me.Panle_SysInf = New System.Windows.Forms.Panel
        Me.LabelMsg = New System.Windows.Forms.Label
        Me.PB_SysInf = New System.Windows.Forms.PictureBox
        Me.WB_Send = New System.Windows.Forms.WebBrowser
        Me.PanelDetail = New System.Windows.Forms.Panel
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.Cmd_Send = New System.Windows.Forms.Button
        Me.Cmd_Close = New System.Windows.Forms.Button
        Me.PanelFaceBack = New System.Windows.Forms.Panel
        Me.Pic_GetImage = New System.Windows.Forms.PictureBox
        Me.Pic_SendFile = New System.Windows.Forms.PictureBox
        Me.Pic_FontLight = New System.Windows.Forms.PictureBox
        Me.Pic_Last_Msg = New System.Windows.Forms.PictureBox
        Me.Pic_Shake = New System.Windows.Forms.PictureBox
        Me.Pic_Pic_Cut = New System.Windows.Forms.PictureBox
        Me.Pic_SendPic = New System.Windows.Forms.PictureBox
        Me.Pic_Face = New System.Windows.Forms.PictureBox
        Me.Pic_Font = New System.Windows.Forms.PictureBox
        Me.Pic_Font_Color = New System.Windows.Forms.PictureBox
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.WB_Old = New System.Windows.Forms.WebBrowser
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Cmd_Find = New System.Windows.Forms.Button
        Me.DTP_Start = New System.Windows.Forms.DateTimePicker
        Me.DTP_End = New System.Windows.Forms.DateTimePicker
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.TimerShake = New System.Windows.Forms.Timer(Me.components)
        Me.TimerSendFocus = New System.Windows.Forms.Timer(Me.components)
        Me.TimerStart = New System.Windows.Forms.Timer(Me.components)
        Me.PanelHead = New System.Windows.Forms.Panel
        Me.LabelJob = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.LabelReceiver = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.LB_Dept = New System.Windows.Forms.Label
        Me.PicHead = New System.Windows.Forms.PictureBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TimerMsg = New System.Windows.Forms.Timer(Me.components)
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.TimerReceive = New System.Windows.Forms.Timer(Me.components)
        Me.Timerold = New System.Windows.Forms.Timer(Me.components)
        Me.PanelMain = New System.Windows.Forms.Panel
        Me.PanelShadow = New System.Windows.Forms.Panel
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.Label2 = New System.Windows.Forms.Label
        Me.TimerFlash = New System.Windows.Forms.Timer(Me.components)
        Me.ToolTipCtrl1 = New BaseClass.ToolTipCtrl(Me.components)
        Me.Label6 = New System.Windows.Forms.Label
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.Panle_SysInf.SuspendLayout()
        CType(Me.PB_SysInf, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelDetail.SuspendLayout()
        Me.PanelFaceBack.SuspendLayout()
        CType(Me.Pic_GetImage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Pic_SendFile, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Pic_FontLight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Pic_Last_Msg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Pic_Shake, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Pic_Pic_Cut, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Pic_SendPic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Pic_Face, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Pic_Font, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Pic_Font_Color, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.PanelHead.SuspendLayout()
        CType(Me.PicHead, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelMain.SuspendLayout()
        Me.PanelShadow.SuspendLayout()
        Me.SuspendLayout()
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Menu_Pic_Cut, Me.Menu_Sleep_Pic_Cut, Me.Menu_Hide_Me})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(179, 70)
        '
        'Menu_Pic_Cut
        '
        Me.Menu_Pic_Cut.Name = "Menu_Pic_Cut"
        Me.Menu_Pic_Cut.Size = New System.Drawing.Size(178, 22)
        Me.Menu_Pic_Cut.Text = "立刻截图"
        '
        'Menu_Sleep_Pic_Cut
        '
        Me.Menu_Sleep_Pic_Cut.Name = "Menu_Sleep_Pic_Cut"
        Me.Menu_Sleep_Pic_Cut.Size = New System.Drawing.Size(178, 22)
        Me.Menu_Sleep_Pic_Cut.Text = "5秒后开始截图"
        '
        'Menu_Hide_Me
        '
        Me.Menu_Hide_Me.CheckOnClick = True
        Me.Menu_Hide_Me.Name = "Menu_Hide_Me"
        Me.Menu_Hide_Me.Size = New System.Drawing.Size(178, 22)
        Me.Menu_Hide_Me.Text = "截图时隐藏当前窗口"
        '
        'TimerCutPic
        '
        Me.TimerCutPic.Interval = 1
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.WB_Receive)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Panle_SysInf)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.WB_Send)
        Me.SplitContainer2.Panel2.Controls.Add(Me.PanelDetail)
        Me.SplitContainer2.Panel2.Controls.Add(Me.PanelFaceBack)
        Me.SplitContainer2.Size = New System.Drawing.Size(512, 521)
        Me.SplitContainer2.SplitterDistance = 302
        Me.SplitContainer2.SplitterWidth = 1
        Me.SplitContainer2.TabIndex = 1
        '
        'WB_Receive
        '
        Me.WB_Receive.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WB_Receive.IsWebBrowserContextMenuEnabled = False
        Me.WB_Receive.Location = New System.Drawing.Point(0, 15)
        Me.WB_Receive.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WB_Receive.Name = "WB_Receive"
        Me.WB_Receive.Size = New System.Drawing.Size(512, 287)
        Me.WB_Receive.TabIndex = 0
        '
        'Panle_SysInf
        '
        Me.Panle_SysInf.BackColor = System.Drawing.Color.White
        Me.Panle_SysInf.Controls.Add(Me.LabelMsg)
        Me.Panle_SysInf.Controls.Add(Me.PB_SysInf)
        Me.Panle_SysInf.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panle_SysInf.Location = New System.Drawing.Point(0, 0)
        Me.Panle_SysInf.Name = "Panle_SysInf"
        Me.Panle_SysInf.Size = New System.Drawing.Size(512, 15)
        Me.Panle_SysInf.TabIndex = 2
        Me.Panle_SysInf.Visible = False
        '
        'LabelMsg
        '
        Me.LabelMsg.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelMsg.BackColor = System.Drawing.Color.White
        Me.LabelMsg.Location = New System.Drawing.Point(31, 1)
        Me.LabelMsg.Name = "LabelMsg"
        Me.LabelMsg.Size = New System.Drawing.Size(446, 12)
        Me.LabelMsg.TabIndex = 1
        Me.LabelMsg.Text = "您发送的抖动过于频繁，请稍候再发。"
        '
        'PB_SysInf
        '
        Me.PB_SysInf.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PB_SysInf.ErrorImage = Nothing
        Me.PB_SysInf.Image = CType(resources.GetObject("PB_SysInf.Image"), System.Drawing.Image)
        Me.PB_SysInf.Location = New System.Drawing.Point(15, -2)
        Me.PB_SysInf.Name = "PB_SysInf"
        Me.PB_SysInf.Size = New System.Drawing.Size(98, 14)
        Me.PB_SysInf.TabIndex = 2
        Me.PB_SysInf.TabStop = False
        '
        'WB_Send
        '
        Me.WB_Send.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WB_Send.IsWebBrowserContextMenuEnabled = False
        Me.WB_Send.Location = New System.Drawing.Point(0, 32)
        Me.WB_Send.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WB_Send.Name = "WB_Send"
        Me.WB_Send.Size = New System.Drawing.Size(512, 154)
        Me.WB_Send.TabIndex = 1
        '
        'PanelDetail
        '
        Me.PanelDetail.AllowDrop = True
        Me.PanelDetail.BackColor = System.Drawing.Color.Transparent
        Me.PanelDetail.BackgroundImage = CType(resources.GetObject("PanelDetail.BackgroundImage"), System.Drawing.Image)
        Me.PanelDetail.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PanelDetail.Controls.Add(Me.CheckBox1)
        Me.PanelDetail.Controls.Add(Me.Cmd_Send)
        Me.PanelDetail.Controls.Add(Me.Cmd_Close)
        Me.PanelDetail.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelDetail.Location = New System.Drawing.Point(0, 186)
        Me.PanelDetail.Name = "PanelDetail"
        Me.PanelDetail.Size = New System.Drawing.Size(512, 32)
        Me.PanelDetail.TabIndex = 2
        '
        'CheckBox1
        '
        Me.CheckBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.BackColor = System.Drawing.Color.Transparent
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Location = New System.Drawing.Point(210, 10)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(102, 16)
        Me.CheckBox1.TabIndex = 2
        Me.CheckBox1.Text = "Ctrl+回车发送"
        Me.CheckBox1.UseVisualStyleBackColor = False
        '
        'Cmd_Send
        '
        Me.Cmd_Send.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cmd_Send.Location = New System.Drawing.Point(415, 2)
        Me.Cmd_Send.Name = "Cmd_Send"
        Me.Cmd_Send.Size = New System.Drawing.Size(88, 28)
        Me.Cmd_Send.TabIndex = 1
        Me.Cmd_Send.Text = "发送"
        Me.Cmd_Send.UseVisualStyleBackColor = True
        '
        'Cmd_Close
        '
        Me.Cmd_Close.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cmd_Close.Location = New System.Drawing.Point(318, 2)
        Me.Cmd_Close.Name = "Cmd_Close"
        Me.Cmd_Close.Size = New System.Drawing.Size(88, 28)
        Me.Cmd_Close.TabIndex = 0
        Me.Cmd_Close.Text = "关闭"
        Me.Cmd_Close.UseVisualStyleBackColor = True
        '
        'PanelFaceBack
        '
        Me.PanelFaceBack.BackColor = System.Drawing.Color.Transparent
        Me.PanelFaceBack.BackgroundImage = CType(resources.GetObject("PanelFaceBack.BackgroundImage"), System.Drawing.Image)
        Me.PanelFaceBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PanelFaceBack.Controls.Add(Me.Label6)
        Me.PanelFaceBack.Controls.Add(Me.Pic_GetImage)
        Me.PanelFaceBack.Controls.Add(Me.Pic_SendFile)
        Me.PanelFaceBack.Controls.Add(Me.Pic_FontLight)
        Me.PanelFaceBack.Controls.Add(Me.Pic_Last_Msg)
        Me.PanelFaceBack.Controls.Add(Me.Pic_Shake)
        Me.PanelFaceBack.Controls.Add(Me.Pic_Pic_Cut)
        Me.PanelFaceBack.Controls.Add(Me.Pic_SendPic)
        Me.PanelFaceBack.Controls.Add(Me.Pic_Face)
        Me.PanelFaceBack.Controls.Add(Me.Pic_Font)
        Me.PanelFaceBack.Controls.Add(Me.Pic_Font_Color)
        Me.PanelFaceBack.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelFaceBack.Location = New System.Drawing.Point(0, 0)
        Me.PanelFaceBack.Name = "PanelFaceBack"
        Me.PanelFaceBack.Size = New System.Drawing.Size(512, 32)
        Me.PanelFaceBack.TabIndex = 0
        '
        'Pic_GetImage
        '
        Me.Pic_GetImage.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Pic_GetImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Pic_GetImage.Image = Global.Retail_System.My.Resources.Resources.pictures
        Me.Pic_GetImage.Location = New System.Drawing.Point(478, 6)
        Me.Pic_GetImage.Name = "Pic_GetImage"
        Me.Pic_GetImage.Size = New System.Drawing.Size(24, 20)
        Me.Pic_GetImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.Pic_GetImage.TabIndex = 12
        Me.Pic_GetImage.TabStop = False
        Me.Pic_GetImage.Visible = False
        '
        'Pic_SendFile
        '
        Me.Pic_SendFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Pic_SendFile.Image = Global.Retail_System.My.Resources.ChatRes.PngSendFile
        Me.Pic_SendFile.Location = New System.Drawing.Point(222, 5)
        Me.Pic_SendFile.Name = "Pic_SendFile"
        Me.Pic_SendFile.Size = New System.Drawing.Size(24, 20)
        Me.Pic_SendFile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.Pic_SendFile.TabIndex = 11
        Me.Pic_SendFile.TabStop = False
        '
        'Pic_FontLight
        '
        Me.Pic_FontLight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Pic_FontLight.Image = Global.Retail_System.My.Resources.ChatRes.PngFontLightColor
        Me.Pic_FontLight.Location = New System.Drawing.Point(72, 5)
        Me.Pic_FontLight.Name = "Pic_FontLight"
        Me.Pic_FontLight.Size = New System.Drawing.Size(24, 20)
        Me.Pic_FontLight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.Pic_FontLight.TabIndex = 10
        Me.Pic_FontLight.TabStop = False
        '
        'Pic_Last_Msg
        '
        Me.Pic_Last_Msg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Pic_Last_Msg.Image = Global.Retail_System.My.Resources.ChatRes.PngLastMsg
        Me.Pic_Last_Msg.Location = New System.Drawing.Point(252, 5)
        Me.Pic_Last_Msg.Name = "Pic_Last_Msg"
        Me.Pic_Last_Msg.Size = New System.Drawing.Size(85, 20)
        Me.Pic_Last_Msg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.Pic_Last_Msg.TabIndex = 6
        Me.Pic_Last_Msg.TabStop = False
        '
        'Pic_Shake
        '
        Me.Pic_Shake.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Pic_Shake.Image = Global.Retail_System.My.Resources.ChatRes.PngShake
        Me.Pic_Shake.Location = New System.Drawing.Point(162, 5)
        Me.Pic_Shake.Name = "Pic_Shake"
        Me.Pic_Shake.Size = New System.Drawing.Size(24, 20)
        Me.Pic_Shake.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.Pic_Shake.TabIndex = 5
        Me.Pic_Shake.TabStop = False
        '
        'Pic_Pic_Cut
        '
        Me.Pic_Pic_Cut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Pic_Pic_Cut.ContextMenuStrip = Me.ContextMenuStrip1
        Me.Pic_Pic_Cut.Image = Global.Retail_System.My.Resources.ChatRes.PngCutPic
        Me.Pic_Pic_Cut.Location = New System.Drawing.Point(192, 5)
        Me.Pic_Pic_Cut.Name = "Pic_Pic_Cut"
        Me.Pic_Pic_Cut.Size = New System.Drawing.Size(24, 20)
        Me.Pic_Pic_Cut.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.Pic_Pic_Cut.TabIndex = 4
        Me.Pic_Pic_Cut.TabStop = False
        '
        'Pic_SendPic
        '
        Me.Pic_SendPic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Pic_SendPic.Image = Global.Retail_System.My.Resources.ChatRes.PngSendPic
        Me.Pic_SendPic.Location = New System.Drawing.Point(132, 5)
        Me.Pic_SendPic.Name = "Pic_SendPic"
        Me.Pic_SendPic.Size = New System.Drawing.Size(24, 20)
        Me.Pic_SendPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.Pic_SendPic.TabIndex = 3
        Me.Pic_SendPic.TabStop = False
        '
        'Pic_Face
        '
        Me.Pic_Face.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Pic_Face.Image = Global.Retail_System.My.Resources.ChatRes.PngFace
        Me.Pic_Face.Location = New System.Drawing.Point(102, 5)
        Me.Pic_Face.Name = "Pic_Face"
        Me.Pic_Face.Size = New System.Drawing.Size(24, 20)
        Me.Pic_Face.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.Pic_Face.TabIndex = 2
        Me.Pic_Face.TabStop = False
        '
        'Pic_Font
        '
        Me.Pic_Font.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Pic_Font.Image = Global.Retail_System.My.Resources.ChatRes.PngFont
        Me.Pic_Font.Location = New System.Drawing.Point(12, 5)
        Me.Pic_Font.Name = "Pic_Font"
        Me.Pic_Font.Size = New System.Drawing.Size(24, 20)
        Me.Pic_Font.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.Pic_Font.TabIndex = 1
        Me.Pic_Font.TabStop = False
        '
        'Pic_Font_Color
        '
        Me.Pic_Font_Color.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Pic_Font_Color.Image = Global.Retail_System.My.Resources.ChatRes.PngFontColor
        Me.Pic_Font_Color.Location = New System.Drawing.Point(42, 5)
        Me.Pic_Font_Color.Name = "Pic_Font_Color"
        Me.Pic_Font_Color.Size = New System.Drawing.Size(24, 20)
        Me.Pic_Font_Color.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.Pic_Font_Color.TabIndex = 8
        Me.Pic_Font_Color.TabStop = False
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BackColor = System.Drawing.Color.Transparent
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 69)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer1.Panel1MinSize = 435
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.WB_Old)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel1)
        Me.SplitContainer1.Panel2Collapsed = True
        Me.SplitContainer1.Panel2MinSize = 70
        Me.SplitContainer1.Size = New System.Drawing.Size(512, 521)
        Me.SplitContainer1.SplitterDistance = 435
        Me.SplitContainer1.TabIndex = 1
        '
        'WB_Old
        '
        Me.WB_Old.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WB_Old.IsWebBrowserContextMenuEnabled = False
        Me.WB_Old.Location = New System.Drawing.Point(0, 0)
        Me.WB_Old.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WB_Old.Name = "WB_Old"
        Me.WB_Old.Size = New System.Drawing.Size(25, 68)
        Me.WB_Old.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BackgroundImage = CType(resources.GetObject("Panel1.BackgroundImage"), System.Drawing.Image)
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.Cmd_Find)
        Me.Panel1.Controls.Add(Me.DTP_Start)
        Me.Panel1.Controls.Add(Me.DTP_End)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 68)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(25, 32)
        Me.Panel1.TabIndex = 2
        '
        'Cmd_Find
        '
        Me.Cmd_Find.Location = New System.Drawing.Point(227, 4)
        Me.Cmd_Find.Name = "Cmd_Find"
        Me.Cmd_Find.Size = New System.Drawing.Size(45, 28)
        Me.Cmd_Find.TabIndex = 6
        Me.Cmd_Find.Text = "查询"
        Me.Cmd_Find.UseVisualStyleBackColor = True
        '
        'DTP_Start
        '
        Me.DTP_Start.CustomFormat = "yyyy-MM-dd"
        Me.DTP_Start.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTP_Start.Location = New System.Drawing.Point(25, 6)
        Me.DTP_Start.Name = "DTP_Start"
        Me.DTP_Start.Size = New System.Drawing.Size(85, 21)
        Me.DTP_Start.TabIndex = 0
        '
        'DTP_End
        '
        Me.DTP_End.CustomFormat = "yyyy-MM-dd"
        Me.DTP_End.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTP_End.Location = New System.Drawing.Point(135, 7)
        Me.DTP_End.Name = "DTP_End"
        Me.DTP_End.Size = New System.Drawing.Size(86, 21)
        Me.DTP_End.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(114, 11)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(17, 12)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "到"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 10)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(17, 12)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "从"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TimerShake
        '
        Me.TimerShake.Interval = 1
        '
        'TimerSendFocus
        '
        Me.TimerSendFocus.Interval = 1
        '
        'TimerStart
        '
        Me.TimerStart.Interval = 1
        '
        'PanelHead
        '
        Me.PanelHead.AllowDrop = True
        Me.PanelHead.BackColor = System.Drawing.Color.Transparent
        Me.PanelHead.BackgroundImage = CType(resources.GetObject("PanelHead.BackgroundImage"), System.Drawing.Image)
        Me.PanelHead.Controls.Add(Me.LabelJob)
        Me.PanelHead.Controls.Add(Me.Label7)
        Me.PanelHead.Controls.Add(Me.LabelReceiver)
        Me.PanelHead.Controls.Add(Me.Label3)
        Me.PanelHead.Controls.Add(Me.LB_Dept)
        Me.PanelHead.Controls.Add(Me.PicHead)
        Me.PanelHead.Controls.Add(Me.Label1)
        Me.PanelHead.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelHead.Location = New System.Drawing.Point(0, 0)
        Me.PanelHead.Name = "PanelHead"
        Me.PanelHead.Size = New System.Drawing.Size(512, 69)
        Me.PanelHead.TabIndex = 1
        '
        'LabelJob
        '
        Me.LabelJob.AutoSize = True
        Me.LabelJob.BackColor = System.Drawing.Color.Transparent
        Me.LabelJob.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.LabelJob.Location = New System.Drawing.Point(250, 12)
        Me.LabelJob.Name = "LabelJob"
        Me.LabelJob.Size = New System.Drawing.Size(17, 12)
        Me.LabelJob.TabIndex = 6
        Me.LabelJob.Text = "无"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(209, 12)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(35, 12)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "职位:"
        '
        'LabelReceiver
        '
        Me.LabelReceiver.AutoSize = True
        Me.LabelReceiver.BackColor = System.Drawing.Color.Transparent
        Me.LabelReceiver.ForeColor = System.Drawing.Color.Cyan
        Me.LabelReceiver.Location = New System.Drawing.Point(111, 33)
        Me.LabelReceiver.Name = "LabelReceiver"
        Me.LabelReceiver.Size = New System.Drawing.Size(29, 12)
        Me.LabelReceiver.TabIndex = 4
        Me.LabelReceiver.Text = "帐号"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(70, 33)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 12)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "帐号:"
        '
        'LB_Dept
        '
        Me.LB_Dept.AutoSize = True
        Me.LB_Dept.BackColor = System.Drawing.Color.Transparent
        Me.LB_Dept.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.LB_Dept.Location = New System.Drawing.Point(111, 12)
        Me.LB_Dept.Name = "LB_Dept"
        Me.LB_Dept.Size = New System.Drawing.Size(35, 12)
        Me.LB_Dept.TabIndex = 2
        Me.LB_Dept.Text = "部门:"
        '
        'PicHead
        '
        Me.PicHead.BackColor = System.Drawing.Color.Transparent
        Me.PicHead.Location = New System.Drawing.Point(12, 10)
        Me.PicHead.Name = "PicHead"
        Me.PicHead.Size = New System.Drawing.Size(48, 48)
        Me.PicHead.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PicHead.TabIndex = 1
        Me.PicHead.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(70, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "部门:"
        '
        'TimerMsg
        '
        '
        'TimerReceive
        '
        '
        'Timerold
        '
        Me.Timerold.Interval = 300
        '
        'PanelMain
        '
        Me.PanelMain.Controls.Add(Me.SplitContainer1)
        Me.PanelMain.Controls.Add(Me.PanelHead)
        Me.PanelMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelMain.Location = New System.Drawing.Point(0, 0)
        Me.PanelMain.Name = "PanelMain"
        Me.PanelMain.Size = New System.Drawing.Size(512, 590)
        Me.PanelMain.TabIndex = 3
        '
        'PanelShadow
        '
        Me.PanelShadow.BackColor = System.Drawing.Color.Transparent
        Me.PanelShadow.Controls.Add(Me.ProgressBar1)
        Me.PanelShadow.Controls.Add(Me.Label2)
        Me.PanelShadow.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelShadow.Location = New System.Drawing.Point(0, 0)
        Me.PanelShadow.Name = "PanelShadow"
        Me.PanelShadow.Size = New System.Drawing.Size(512, 590)
        Me.PanelShadow.TabIndex = 3
        Me.PanelShadow.Visible = False
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(162, 241)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(183, 22)
        Me.ProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.ProgressBar1.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(190, 216)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(125, 12)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "下载文件中,请稍后..."
        '
        'TimerFlash
        '
        Me.TimerFlash.Interval = 500
        '
        'ToolTipCtrl1
        '
        Me.ToolTipCtrl1.AllowReSize = True
        Me.ToolTipCtrl1.AutoSize = True
        Me.ToolTipCtrl1.Child = Nothing
        Me.ToolTipCtrl1.Delay = 5000
        Me.ToolTipCtrl1.HidDelay = 500
        Me.ToolTipCtrl1.ShowDelay = 500
        Me.ToolTipCtrl1.ShowDirection = BaseClass.ToolTipCtrl.Enum_ShowDirection.Below
        Me.ToolTipCtrl1.ShowDistince = 1
        Me.ToolTipCtrl1.Size = New System.Drawing.Size(0, 0)
        Me.ToolTipCtrl1.TopMost = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Magenta
        Me.Label6.Location = New System.Drawing.Point(350, 10)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(119, 12)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "Ctrl+Q 是截图快捷键"
        '
        'Dialog
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(178, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(512, 590)
        Me.Controls.Add(Me.PanelMain)
        Me.Controls.Add(Me.PanelShadow)
        Me.Name = "Dialog"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Dialog"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.ResumeLayout(False)
        Me.Panle_SysInf.ResumeLayout(False)
        CType(Me.PB_SysInf, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelDetail.ResumeLayout(False)
        Me.PanelDetail.PerformLayout()
        Me.PanelFaceBack.ResumeLayout(False)
        Me.PanelFaceBack.PerformLayout()
        CType(Me.Pic_GetImage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Pic_SendFile, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Pic_FontLight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Pic_Last_Msg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Pic_Shake, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Pic_Pic_Cut, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Pic_SendPic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Pic_Face, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Pic_Font, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Pic_Font_Color, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.PanelHead.ResumeLayout(False)
        Me.PanelHead.PerformLayout()
        CType(Me.PicHead, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelMain.ResumeLayout(False)
        Me.PanelShadow.ResumeLayout(False)
        Me.PanelShadow.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents FontDialog1 As System.Windows.Forms.FontDialog
    Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents Menu_Pic_Cut As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Menu_Sleep_Pic_Cut As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Menu_Hide_Me As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TimerCutPic As System.Windows.Forms.Timer
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents Pic_Last_Msg As System.Windows.Forms.PictureBox
    Friend WithEvents Pic_Shake As System.Windows.Forms.PictureBox
    Friend WithEvents Pic_Pic_Cut As System.Windows.Forms.PictureBox
    Friend WithEvents Pic_SendPic As System.Windows.Forms.PictureBox
    Friend WithEvents Pic_Font As System.Windows.Forms.PictureBox
    Friend WithEvents PanelFaceBack As System.Windows.Forms.Panel
    Friend WithEvents WB_Receive As System.Windows.Forms.WebBrowser
    Friend WithEvents WB_Send As System.Windows.Forms.WebBrowser
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Pic_Font_Color As System.Windows.Forms.PictureBox
    Friend WithEvents Pic_FontLight As System.Windows.Forms.PictureBox
    Friend WithEvents PanelHead As System.Windows.Forms.Panel
    Friend WithEvents PicHead As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LabelReceiver As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents LB_Dept As System.Windows.Forms.Label
    Friend WithEvents PanelDetail As System.Windows.Forms.Panel
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents Cmd_Send As System.Windows.Forms.Button
    Friend WithEvents Cmd_Close As System.Windows.Forms.Button
    Friend WithEvents Pic_Face As System.Windows.Forms.PictureBox
    Friend WithEvents TimerShake As System.Windows.Forms.Timer
    Friend WithEvents TimerSendFocus As System.Windows.Forms.Timer
    Friend WithEvents WB_Old As System.Windows.Forms.WebBrowser
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DTP_End As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents DTP_Start As System.Windows.Forms.DateTimePicker
    Friend WithEvents Cmd_Find As System.Windows.Forms.Button
    Friend WithEvents TimerStart As System.Windows.Forms.Timer
    Friend WithEvents LabelMsg As System.Windows.Forms.Label
    Friend WithEvents TimerMsg As System.Windows.Forms.Timer
    Friend WithEvents Panle_SysInf As System.Windows.Forms.Panel
    Friend WithEvents PB_SysInf As System.Windows.Forms.PictureBox
    Friend WithEvents Pic_SendFile As System.Windows.Forms.PictureBox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents TimerReceive As System.Windows.Forms.Timer
    Friend WithEvents Timerold As System.Windows.Forms.Timer
    Friend WithEvents PanelMain As System.Windows.Forms.Panel
    Friend WithEvents PanelShadow As System.Windows.Forms.Panel
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Pic_GetImage As System.Windows.Forms.PictureBox
    Friend WithEvents TimerFlash As System.Windows.Forms.Timer
    Friend WithEvents LabelJob As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ToolTipCtrl1 As BaseClass.ToolTipCtrl
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
