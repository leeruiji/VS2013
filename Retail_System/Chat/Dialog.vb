Imports System.Text.RegularExpressions
Imports Retail_System.ChatClient
Imports PClass.PClass
Imports System.IO

Public Class Dialog


    ''是否在线
    Private _IsOnLine As Boolean = True
    Public HeadImage As Image
    Public GrapImage As Image
    Public Property IsOnline() As Boolean
        Get
            Return _IsOnLine
        End Get
        Set(ByVal value As Boolean)
            If value Then
                LabelReceiver.ForeColor = Color.FromArgb(255, 0, 255, 255)
                Me.Text = Receiver & ""
                PicHead.Image = HeadImage
                Me.Icon = SystemIcon.ImageToIcon(HeadImage)
            Else
                LabelReceiver.ForeColor = Color.FromArgb(255, 80, 80, 80)
                Me.Text = Receiver & " - 离线"
                PicHead.Image = GrapImage
                Me.Icon = SystemIcon.ImageToIcon(GrapImage)
            End If
            _IsOnLine = value
        End Set
    End Property


    Sub New()
        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。
        AddHandler Pic_Face.MouseDown, AddressOf CmdPic_MouseDown
        AddHandler Pic_Face.MouseEnter, AddressOf CmdPic_MouseEnter
        AddHandler Pic_Face.MouseLeave, AddressOf CmdPic_MouseLeave
        AddHandler Pic_Face.MouseUp, AddressOf CmdPic_MouseUp

        AddHandler Pic_Font.MouseDown, AddressOf CmdPic_MouseDown
        AddHandler Pic_Font.MouseEnter, AddressOf CmdPic_MouseEnter
        AddHandler Pic_Font.MouseLeave, AddressOf CmdPic_MouseLeave
        AddHandler Pic_Font.MouseUp, AddressOf CmdPic_MouseUp

        AddHandler Pic_Pic_Cut.MouseDown, AddressOf CmdPic_MouseDown
        AddHandler Pic_Pic_Cut.MouseEnter, AddressOf CmdPic_MouseEnter
        AddHandler Pic_Pic_Cut.MouseLeave, AddressOf CmdPic_MouseLeave
        AddHandler Pic_Pic_Cut.MouseUp, AddressOf CmdPic_MouseUp


        AddHandler Pic_SendPic.MouseDown, AddressOf CmdPic_MouseDown
        AddHandler Pic_SendPic.MouseEnter, AddressOf CmdPic_MouseEnter
        AddHandler Pic_SendPic.MouseLeave, AddressOf CmdPic_MouseLeave
        AddHandler Pic_SendPic.MouseUp, AddressOf CmdPic_MouseUp

        AddHandler Pic_Shake.MouseDown, AddressOf CmdPic_MouseDown
        AddHandler Pic_Shake.MouseEnter, AddressOf CmdPic_MouseEnter
        AddHandler Pic_Shake.MouseLeave, AddressOf CmdPic_MouseLeave
        AddHandler Pic_Shake.MouseUp, AddressOf CmdPic_MouseUp

        AddHandler Pic_Font.MouseDown, AddressOf CmdPic_MouseDown
        AddHandler Pic_Font.MouseEnter, AddressOf CmdPic_MouseEnter
        AddHandler Pic_Font.MouseLeave, AddressOf CmdPic_MouseLeave
        AddHandler Pic_Font.MouseUp, AddressOf CmdPic_MouseUp

        AddHandler Pic_Font_Color.MouseDown, AddressOf CmdPic_MouseDown
        AddHandler Pic_Font_Color.MouseEnter, AddressOf CmdPic_MouseEnter
        AddHandler Pic_Font_Color.MouseLeave, AddressOf CmdPic_MouseLeave
        AddHandler Pic_Font_Color.MouseUp, AddressOf CmdPic_MouseUp


        AddHandler Pic_FontLight.MouseDown, AddressOf CmdPic_MouseDown
        AddHandler Pic_FontLight.MouseEnter, AddressOf CmdPic_MouseEnter
        AddHandler Pic_FontLight.MouseLeave, AddressOf CmdPic_MouseLeave
        AddHandler Pic_FontLight.MouseUp, AddressOf CmdPic_MouseUp


        AddHandler Pic_SendFile.MouseDown, AddressOf CmdPic_MouseDown
        AddHandler Pic_SendFile.MouseEnter, AddressOf CmdPic_MouseEnter
        AddHandler Pic_SendFile.MouseLeave, AddressOf CmdPic_MouseLeave
        AddHandler Pic_SendFile.MouseUp, AddressOf CmdPic_MouseUp

        AddHandler Pic_Last_Msg.MouseDown, AddressOf CmdPic_MouseDown
        AddHandler Pic_Last_Msg.MouseEnter, AddressOf CmdPic_MouseEnter
        AddHandler Pic_Last_Msg.MouseUp, AddressOf CmdPic_MouseUp
    End Sub


    Private _Receiver As String = ""
    Public Property Receiver() As String
        Get
            Return _Receiver
        End Get
        Set(ByVal value As String)
            _Receiver = value
        End Set
    End Property

    Private TempCutImgList As New List(Of String)
    Public IsLoad As Boolean = False




#Region "窗口"
    Private Sub Dialog_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        ChatClient.LastActivatedForm = Me
        WB_Send.Select()
    End Sub

    Private Sub Dialog_DragOver(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Me.DragOver, PanelHead.DragOver, PanelDetail.DragOver
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            Try
                Dim s As String = e.Data.GetData(DataFormats.FileDrop, True)(0)
                If IO.File.Exists(s) Then
                    CheckUpFile(s)
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub Dialog_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        CloseDialog(Receiver)
    End Sub

    Public E_ID As Integer = 0
    Private Sub Dialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LabelReceiver.Text = Receiver
        DTP_Start.Value = Today.AddDays(-3)
        DTP_End.Value = Today
        If Receiver = "Admin" Then
            LB_Dept.Text = "软件公司"
            LabelJob.Text = "管理员"
            E_ID = -1
        Else
            If Receiver <> "" Then
                Dim msg As DtReturnMsg = BaseClass.ComFun.Dept_GetByEmpName(Receiver)
                If msg.IsOk AndAlso msg.Dt.Rows.Count > 0 Then
                    E_ID = msg.Dt.Rows(0)("ID")
                    LB_Dept.Text = IsNull(msg.Dt.Rows(0)("Dept_Name"), "")
                    LabelJob.Text = IsNull(msg.Dt.Rows(0)("Job_Name"), "")
                End If

            End If
        End If
        ToolTipCtrl1.SetCol(PicHead)


        FontFont = ChatClient.SendFont
        FontColor = ChatClient.SendFontColor


        WB_Send.DocumentText = ""
        WB_Send.Document.Write(cHtml.HtmlBody)
        WB_Receive.DocumentText = ""
        WB_Receive.Document.Write(cHtml.HtmlBody)
        WB_Old.DocumentText = ""
        WB_Old.Document.Write(cHtml.HtmlBody)
        WB_Send.Document.DomDocument.designMode = "on"
        Application.DoEvents()
        SetFont(GetFont, FontFont)
        WB_Send.Document.ExecCommand(cHtml.ForeColor, False, ColorToHtmlColor(FontColor))
        TimerStart.Start()
        Me.Text = Receiver
        GetUserFace(Receiver, New DCheckFaceImage(AddressOf MyFaceImageLoad))
        If UserName = "Admin" Then
            Pic_GetImage.Visible = True
        End If
    End Sub
    Sub MyFaceImageLoad(ByVal Md5 As String, ByVal IsOk As Boolean)
        If IsOk Then
            Try
                HeadImage = Image.FromFile(SystemFacePath & Md5 & ".png")
                GrapImage = SystemIcon.ImageToGray(HeadImage)
                If IsOnline Then
                    PicHead.Image = HeadImage
                Else
                    PicHead.Image = GrapImage
                End If
            Catch ex As Exception
                PicHead.Image = My.Resources.PicHead
            End Try
        Else
            PicHead.Image = My.Resources.PicHead
            HeadImage = My.Resources.PicHead
            GrapImage = SystemIcon.ImageToGray(My.Resources.PicHead)
        End If
    End Sub

    Private Sub TimerStart_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerStart.Tick
        TimerStart.Enabled = False
        IsLoad = True
        Dim T As New Threading.Thread(AddressOf ChatClient.GetUnReadMes)
        T.Start(Receiver)
    End Sub

    Private Sub Cmd_Close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Close.Click
        Me.Close()
    End Sub

#Region "Tooltip"
    Private Sub ToolTipCtrl1_BeforeShow(ByRef Child As BaseClass.iTooltipChild, ByRef ShowSize As System.Drawing.Size, ByRef isCancel As Boolean) Handles ToolTipCtrl1.BeforeShow
        If Child Is Nothing Then
            Child = New UserImage
        End If
        If UserName = "Admin" Then
            Dim U As UserImage = TryCast(Child, UserImage)
            U.HeadImg = PicHead.Image
            U.GetImage(Receiver)
        Else
            Dim U As UserImage = TryCast(Child, UserImage)
            U.HeadImg = PicHead.Image
            U.SetImage()
        End If


    End Sub
#End Region

#End Region

#Region "界面按钮显示"
    Private Const Pic_Move_Distance = 2





#Region "图片按钮事件"
    Dim IsDown As Boolean = False
    Private Sub CmdPic_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) 'Handles Pic_Pic_Cut.MouseDown
        TryCast(sender, PictureBox).Padding = New Padding(4, 4, 0, 0)
        IsDown = True
    End Sub

    Private Sub CmdPic_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) 'Handles Pic_Pic_Cut.MouseEnter
        Dim P As PictureBox = TryCast(sender, PictureBox)
        If P.Width > 24 Then
            P.BackgroundImage = My.Resources.ChatRes.FaceBackLight_Long
        Else
            P.BackgroundImage = My.Resources.ChatRes.FaceBackLight
        End If
        P.Padding = New Padding(0, 0, 0, 0)
    End Sub

    Private Sub CmdPic_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) 'Handles Pic_Pic_Cut.MouseLeave
        Dim P As PictureBox = TryCast(sender, PictureBox)
        P.BackgroundImage = Nothing
        P.Padding = New Padding(0, 0, 0, 0)
        IsDown = False
    End Sub

    Private Sub CmdPic_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) 'Handles Pic_Pic_Cut.MouseUp
        TryCast(sender, PictureBox).Padding = New Padding(0, 0, 0, 0)
        IsDown = False
    End Sub






#Region "信息记录"


    Private Sub Pic_Last_Msg_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Pic_Last_Msg.Click
        If SplitContainer1.Panel2Collapsed Then '打开
            If Me.WindowState = FormWindowState.Normal Then
                Me.Width = Me.Width + 300
            End If
            SplitContainer1.Panel2MinSize = 400
            SplitContainer1.Panel2Collapsed = False


            GetNowOldReceiveMsg()
        Else
            SplitContainer1.Panel2MinSize = 70
            If Me.WindowState = FormWindowState.Normal And Me.Width > 700 Then
                Me.Width = Me.Width - 300
            End If
            SplitContainer1.Panel2Collapsed = True
        End If
    End Sub


    Private Sub Pic_Last_Msg_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Pic_Last_Msg.MouseLeave
        Dim P As PictureBox = TryCast(sender, PictureBox)
        If SplitContainer1.Panel2Collapsed Then
            P.BackgroundImage = Nothing
            P.Padding = New Padding(0, 0, 0, 0)
        End If
        IsDown = False
    End Sub


#End Region







#End Region


#End Region

#Region "震动"
    Private Sub Pic_Shake_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Pic_Shake.Click
        If _IsOnLine = False Then
            Dim Html As New System.Text.StringBuilder()
            Html.AppendLine("<Div class='SysInf'><img alt='' src='" & ChatClient.GetSystemFace(Enum_FaceName.gifSystemInfo) & "' /> " & DateAdd(DateInterval.Second, TimeDiff, Now) & "</FONT><Div style=""text-align:left;margin:1px;padding-left:9px"">")
            Html.AppendLine("用户" & Me.Receiver & "不在线不能窗口抖动。")
            Html.AppendLine("</Div></Div>")
            WB_Receive.Document.Body.Document.Write(Html.ToString)
            StartReceiveScroll()
            Exit Sub
        Else
            If ShakeTime.AddSeconds(5) < Now Then
                ChatClient.SendSnake(Receiver)
            Else
                ShowErrorMsg(My.Resources.ChatRes.gifSystemInfo, (ShakeTime.AddSeconds(5) - Now).TotalSeconds, "您发送的抖动过于频繁，请稍后再发。")
            End If
        End If
    End Sub

    Sub ShowErrorMsg(ByVal Img As Image, ByVal DelayTime As Integer, ByVal Msg As String)
        PB_SysInf.Image = Img 'My.resources.ChatRes.SystemInfo
        Panle_SysInf.Visible = True
        TimerMsg.Interval = 1000
        MsgShowTime = Now.AddSeconds(DelayTime)
        TimerMsg.Enabled = True
        LabelMsg.Text = Msg
    End Sub



    Private Sub TimerMsg_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TimerMsg.Tick
        If MsgShowTime <= Now Then
            Panle_SysInf.Visible = False
            TimerMsg.Stop()
        End If
    End Sub
    Private Sub TimerShake_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerShake.Tick
        TimerShake.Stop()
        PlaySoundShake()
        Shake()
        TimerShake.Stop()
    End Sub
    Dim IsActivate As Boolean
    Dim MsgShowTime As Date
    Dim ShakeTime As Date = Now.AddSeconds(-8)
    Sub Shake()
        If IsActivate Then
            If Me.WindowState = FormWindowState.Minimized Then
                Me.WindowState = FormWindowState.Normal
            End If
            Me.Activate()
            Me.Focus()
            Me.Refresh()
            IsActivate = False
        End If

        ShakeTime = Now
        Dim rx As Integer = Me.Left
        Dim ry As Integer = Me.Top
        Dim L As Integer = 5
        Dim T As Integer = 60
        For i As Integer = 0 To 3
            Try
                Me.Top -= L
                If i > 0 Then Me.Left -= L
                Threading.Thread.Sleep(T)
                Me.Top += L
                Me.Left -= L
                Threading.Thread.Sleep(T)
                Me.Top += L
                Me.Left += L
                Threading.Thread.Sleep(T)
                Me.Top -= L
                Me.Left += L
                T += 5
                If i > 2 Then L -= 1

                Me.Refresh()
            Catch ex As Exception

            End Try

        Next
        Me.Left = rx
        Me.Top = ry
    End Sub
#End Region

#Region "截图"

    Private Sub Pic_Pic_Cut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Pic_Pic_Cut.Click
        TimerCutPic.Interval = 1
        TimerCutPic.Start()
    End Sub

    Private Sub Menu_Sleep_Pic_Cut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu_Sleep_Pic_Cut.Click
        TimerCutPic.Interval = 5000
        TimerCutPic.Start()
    End Sub

    Private Sub Menu_Pic_Cut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu_Pic_Cut.Click
        TimerCutPic.Interval = 1
        TimerCutPic.Start()
    End Sub


    Private Sub TimerCutPic_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerCutPic.Tick
        TimerCutPic.Stop()
        StartCutPic()
    End Sub


    ''' <summary>
    ''' 开始截图
    ''' </summary>
    ''' <remarks></remarks>
    Sub StartCutPic()
        If Menu_Hide_Me.Checked = True Then
            Me.Hide()
        End If
        ChatClient.StartCutPic()
        If Menu_Hide_Me.Checked = True Then
            Me.Show()
        End If
    End Sub

    ''' <summary>
    ''' 获取图片
    ''' </summary>
    ''' <param name="FileName"></param>
    ''' <remarks></remarks>
    Sub GetCutPic(ByVal FileName As String)
        WB_Send.Document.ExecCommand(cHtml.InsertImage, False, TempImgPath & FileName)
        TempCutImgList.Add(TempImgPath & FileName)
        TimerSendFocus.Start()
    End Sub

#End Region

#Region "发图片"
    Private Sub Pic_SendPic_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Pic_SendPic.Click
        OpenFileDialog1.Filter = "图片文件(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|Gif文件|*.Gif|JPG文件|*.JPG|PNG文件|*.PNG|BMP文件|*.BMP"
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim f As FileInfo = New FileInfo(OpenFileDialog1.FileName)
            Dim I As Image
            Dim FileName As String
            If f.Extension.ToUpper = ".BMP" Then
                I = Image.FromFile(f.FullName)
                FileName = I.GetHashCode & Now.ToBinary & ".png"
                I.Save(TempImgPath & FileName, System.Drawing.Imaging.ImageFormat.Png)
            Else
                If f.Length > MAX_ImgFILE_SIZE Then
                    MsgBox("图片文件的大小不能大于" & FileLenStr(MAX_ImgFILE_SIZE))
                    Exit Sub
                Else
                    I = Image.FromFile(f.FullName)
                    FileName = I.GetHashCode & Now.ToBinary & f.Extension
                    I.Save(TempImgPath & FileName)
                End If
            End If
            WB_Send.Document.ExecCommand(cHtml.InsertImage, False, TempImgPath & FileName)
            TempCutImgList.Add(TempImgPath & FileName)
            TimerSendFocus.Start()
        End If
    End Sub
#End Region

#Region "上传文件"
    Public Const MAX_FILE_SIZE As Integer = 5242880
    Public Const MAX_ImgFILE_SIZE As Integer = 2097152

    Public Sub UpdaloadFile(ByVal F As FileInfo)
        Dim FB() As Byte = IO.File.ReadAllBytes(F.FullName) '读取到Byte
        Dim Md5 As String
        Using hashmd5 As New Security.Cryptography.MD5CryptoServiceProvider
            Md5 = BitConverter.ToString(hashmd5.ComputeHash(FB)).Replace("-", "").ToUpper '转换MD5
        End Using
        Dim Info As New cPackage(UserName, cPackage.Enum_PackageType.File)
        Info.Add_Attachment(F.Name, Md5, FB)
        Info.BaseMsg.AddReceiver(Receiver)
        Dim S As New System.Text.StringBuilder
        S.Append(F.Name)
        S.Append("|")
        S.Append(F.Length)
        If F.Extension.ToLower = ".exe" Then
            Dim IconPath As String = SystemFacePath & "Extension-" & F.Name & ".Png"
            SystemIcon.GetFileIcon(F.FullName, False).ToBitmap.Save(IconPath, System.Drawing.Imaging.ImageFormat.Png)
            S.Append("|")
            S.Append(ByteArrayToHString(File.ReadAllBytes(IconPath)))
        End If
        If ChatClient.SendMsg(Info, S.ToString) Then
        Else
            ShowErrorMsg(My.Resources.ChatRes.GifSmallError, 3, "发送文件失败!")
            Exit Sub
        End If
    End Sub

    Private Sub PB_File_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Pic_SendFile.Click
        OpenFileDialog1.Filter = "所有文件|*.*"
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            CheckUpFile(OpenFileDialog1.FileName)
        End If
    End Sub
    Sub CheckUpFile(ByVal FileName As String)
        Dim f As FileInfo = New FileInfo(FileName)
        If f.Exists Then
            Try
                If f.Length > MAX_FILE_SIZE Then
                    MsgBox("上传文件的大小不能大于" & FileLenStr(MAX_FILE_SIZE))
                    Exit Sub
                Else
                    If MsgBox("是否发送文件[" & f.Name & "]" & "大小为:" & FileLenStr(f.Length), MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        UpdaloadFile(f)
                    End If
                End If
            Catch ex As Exception
                ShowErrorMsg(My.Resources.ChatRes.GifSmallError, 3, "发送文件失败!")
            End Try
        End If
    End Sub

    ''' <summary>
    ''' 文件发送成功
    ''' </summary>
    ''' <param name="Info"></param>
    ''' <param name="_fileName"></param>
    ''' <param name="_fileSize"></param>
    ''' <remarks></remarks>
    Private Sub UploadFileCompleted(ByVal Info As cPackage, ByVal _fileName As String, ByVal _fileSize As Integer)
        Dim sSize As String = FileLenStr(_fileSize)
        WB_Receive.Document.Write("<Div class='SysInf'>" & Info.BaseMsg.SendTime & "<Div style=""text-align:left;margin:1px;padding-left:9px"">")
        WB_Receive.Document.Write("成功发送文件" & _fileName & "(" & sSize & "_fileSize")

        WB_Receive.Document.Write("</Div></Div>")
    End Sub


    ''' <summary>
    ''' 获取文件的大小 ,自动划分G M K
    ''' </summary>
    ''' <returns>0为不存在</returns>
    ''' <remarks></remarks>
    Function FileLenStr(ByVal L As Long) As String
        Try
            Select Case L
                Case Is >= 1073741824
                    Return FormatN(L / 1073741824, 2, True) & "GB"
                Case Is >= 1048576
                    Return FormatN(L / 1048576, 2, True) & "MB"
                Case Is >= 1024
                    Return FormatN(L / 1024, 2, True) & "KB"
                Case Else
                    Return FormatNum(L) & "B"
            End Select
        Catch ex As Exception
            Return 0
        End Try
    End Function
#End Region


#Region "字体"
    Public FontFont As Font = Me.Font
    Private Sub Pic_Font_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Pic_Font.Click
        'MsgBox(WB_Send.Document.DomDocument.queryCommandState("Bold"))
        Dim OldFont As Font = GetFont()
        FontDialog1.Font = FontFont
        If FontDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            FontFont = OldFont
            SetFont(OldFont, FontDialog1.Font)
            FontFont = FontDialog1.Font
        End If
    End Sub

    Function GetFont() As Font
        Dim FN As String
        Try
            FN = WB_Send.Document.DomDocument.queryCommandValue(cHtml.FontName)
        Catch ex As Exception
            FN = FontFont.Name
        End Try
        If FN Is Nothing Then
            FN = FontFont.Name
        End If
        Dim F As New FontFamily(FN)
        Dim Size As Integer = WB_Send.Document.DomDocument.queryCommandState(cHtml.FontSize)
        Dim s As FontStyle
        If WB_Send.Document.DomDocument.queryCommandState(cHtml.Bold) Then
            s = FontStyle.Bold
        End If
        If WB_Send.Document.DomDocument.queryCommandState(cHtml.Italic) Then
            s = s + FontStyle.Italic
        End If
        If WB_Send.Document.DomDocument.queryCommandState(cHtml.StrikeThrough) Then
            s = s + FontStyle.Strikeout
        End If
        If WB_Send.Document.DomDocument.queryCommandState(cHtml.Underline) Then
            s = s + FontStyle.Underline
        End If
        '获得当前字体
        Return New Font(F, PttoFontSize(FontFont.Size), s)
    End Function


    Sub SetFont(ByVal OldFont As Font, ByVal NewFont As Font)
        ' WB_Send .Document.ActiveElement  

        If OldFont.Bold <> NewFont.Bold Then
            WB_Send.Document.ExecCommand(cHtml.Bold, False, Nothing)
        End If
        If OldFont.Italic <> NewFont.Italic Then
            WB_Send.Document.ExecCommand(cHtml.Italic, False, Nothing)
        End If
        If OldFont.Underline <> NewFont.Underline Then
            WB_Send.Document.ExecCommand(cHtml.StrikeThrough, False, Nothing)
        End If

        If OldFont.FontFamily.Name <> NewFont.FontFamily.Name Then
            WB_Send.Document.ExecCommand(cHtml.FontName, False, NewFont.FontFamily.Name)
        End If
        'If OldFont.Size <> NewFont.Size Then
        WB_Send.Document.ExecCommand(cHtml.FontSize, True, FontSizeToPt(NewFont.Size))
        'End If
    End Sub


    Function FontSizeToPt(ByVal px As Integer) As Integer
        Select Case px
            Case Is <= 8
                Return 1
            Case Is <= 11
                Return 2
            Case Is <= 13
                Return 3
            Case Is <= 16
                Return 4
            Case Is <= 21
                Return 5
            Case Is <= 30
                Return 6
            Case Else
                Return 7
        End Select
    End Function


    Function PttoFontSize(ByVal FontSize As Integer) As Integer
        Select Case FontSize
            Case 1
                Return 7.5
            Case 2
                Return 9.5
            Case 3
                Return 12
            Case 4
                Return 14.5
            Case 5
                Return 18
            Case 6
                Return 24
            Case 7
                Return 36
            Case Else
                Return 12
        End Select

    End Function
#End Region


#Region "字体颜色"
    Public FontColor As Color = Color.Black

    Private Sub Pic_Font_Color_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Pic_Font_Color.Click
        ColorDialog1.Color = FontColor 'Color.FromArgb(WB_Send.Document.DomDocument.queryCommandValue(cHtml.ForeColor).ToString.Replace("#", ""))
        If ColorDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            FontColor = ColorDialog1.Color
            Pic_Font_Color.Invalidate()
            WB_Send.Document.ExecCommand(cHtml.ForeColor, False, ColorToHtmlColor(FontColor))
            Pic_Font_Color.Invalidate()
        End If
    End Sub
    Private Sub Pic_Font_Color_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Pic_Font_Color.Paint
        Dim P As PictureBox = TryCast(sender, PictureBox)
        Dim m_BorderWidth As Integer = 4
        Dim Pen1 As Pen = New Pen(FontColor)
        Pen1.Width = m_BorderWidth
        If IsDown Then
            e.Graphics.DrawLine(Pen1, 7, 19, 22, 19)
        Else
            e.Graphics.DrawLine(Pen1, 5, 17, 20, 17)
        End If
    End Sub
#End Region



#Region "字体背景颜色"
    Public FontLightColor As Color = Color.White
    Private Sub Pic_FontLight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Pic_FontLight.Click
        ColorDialog1.Color = cHtml.GetColor(WB_Send.Document.DomDocument.queryCommandValue(cHtml.BackColor))
        If ColorDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            FontLightColor = ColorDialog1.Color
            WB_Send.Document.ExecCommand(cHtml.BackColor, False, ColorToHtmlColor(FontLightColor))
            ' Pic_FontLight.Invalidate()
        End If

        ' CmdPic_MouseLeave(sender, New System.EventArgs)
    End Sub


    Private Sub Pic_FontLight_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Pic_FontLight.Paint
        Dim P As PictureBox = TryCast(sender, PictureBox)
        Dim m_BorderWidth As Integer = 4
        Dim Pen1 As Pen = New Pen(FontLightColor)
        Pen1.Width = m_BorderWidth
        If IsDown Then
            e.Graphics.DrawLine(Pen1, 7, 19, 22, 19)
        Else
            e.Graphics.DrawLine(Pen1, 5, 17, 20, 17)
        End If
    End Sub
#End Region

#Region "表情选择"
    Private Sub Pic_Face_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Pic_Face.MouseClick
        FaceSelectForm.ShowFace(e.X, e.Y, AddressOf FaceSelect)
    End Sub

    Sub FaceSelect(ByVal FaceStr As String)
        WB_Send.Document.ExecCommand(cHtml.InsertImage, False, FaceStr)
        TimerSendFocus.Start()
    End Sub
    Dim IsSetFont As Boolean = False
    Private Sub TimerSendFocus_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerSendFocus.Tick
        TimerSendFocus.Stop()
        If IsSetFont Then
            SetFont(GetFont, FontFont)
            WB_Send.Document.ExecCommand(cHtml.ForeColor, False, ColorToHtmlColor(FontColor))
            IsSetFont = False
            Application.DoEvents()
            WB_Send.Focus()
            SendKeys.Send("{RIGHT}")
            WB_Send.Document.Body.Focus()
        End If
        WB_SendRight()
    End Sub
    ''' <summary>
    ''' 离开图片编辑状态
    ''' </summary>
    ''' <remarks></remarks>
    Sub WB_SendRight()
        WB_Send.Focus()
        SendKeys.Send("{RIGHT}")
        WB_Send.Document.Body.Focus()
    End Sub

#End Region


    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------


#Region "发送"
    Private Sub Cmd_Send_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Send.Click
        If WB_Send.Document.Body.InnerHtml Is Nothing Then
            ShowErrorMsg(My.Resources.ChatRes.GifSmallError, 3, "发送内容不能为空，请重新输入。")
            Exit Sub
        End If
        Dim LastDocument As String = WB_Send.Document.Body.Document.Body.InnerHtml
        Dim Info As New cPackage(UserName, cPackage.Enum_PackageType.ImgMsg)
        Dim IsFJ As Boolean = DocumentReplaceFilePath(WB_Send.Document.Body.Document, Info)

        Dim s As String = WB_Send.Document.Body.Document.Body.InnerHtml
        WB_Send.Document.Body.InnerHtml = ""
        WB_Send.Document.ExecCommand(cHtml.ForeColor, False, ColorToHtmlColor(FontColor))
        If IsFJ = False Then
            Info = New cPackage(UserName, cPackage.Enum_PackageType.Msg)
            Info.BaseMsg.AddReceiver(Receiver)
            If ChatClient.SendMsg(Info, s) Then
            Else
                ShowErrorMsg(My.Resources.ChatRes.GifSmallError, 3, "发送失败!")
                WB_Send.Document.Write(LastDocument)
                Exit Sub
            End If
        Else
            Info.BaseMsg.AddReceiver(Receiver)
            If ChatClient.SendMsg(Info, s) Then
                DelTempFileList(TempCutImgList)
            Else
                ShowErrorMsg(My.Resources.ChatRes.GifSmallError, 3, "发送失败!")
                WB_Send.Document.Write(LastDocument)
                Exit Sub
            End If
        End If

        If SendFont.Name <> FontFont.Name OrElse SendFont.Bold <> FontFont.Bold OrElse SendFont.Italic <> FontFont.Italic OrElse SendFont.Size <> FontFont.Size OrElse SendFont.Underline <> FontFont.Underline Then
            If (SendFontColor <> FontColor) Then
                SendFontColor = FontColor
                Dim T As New Threading.Thread(AddressOf SaveSetting)
                T.Start(SettingType.SendFontAndColor)
            Else
                SendFont = FontFont
                Dim T As New Threading.Thread(AddressOf SaveSetting)
                T.Start(SettingType.SendFont)
            End If
        Else
            If (SendFontColor <> FontColor) Then
                SendFontColor = FontColor
                Dim T As New Threading.Thread(AddressOf SaveSetting)
                T.Start(SettingType.SendFontColor)
            End If
        End If

        IsSetFont = True
        TimerSendFocus.Start()
    End Sub
#End Region


#Region "接收"

    Public Sub GetSendComplete(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim Source As cPackage = TryCast(sender, cPackage)
        Dim WList As New List(Of Dictionary(Of String, Object))
        If Source IsNot Nothing Then
            Dim Str As String = cPackageToHtml(Source, True, True, WList)
            If Str <> "" Then
                WB_Receive.Document.Body.Document.Write(Str)
                StartReceiveScroll()
                For Each D As Dictionary(Of String, Object) In WList
                    Threading.ThreadPool.UnsafeQueueUserWorkItem(New Threading.WaitCallback(AddressOf ChatClient.GetAttachment), D)
                Next
            End If
        End If
        WList.Clear()
    End Sub

    Public Sub GetSendError(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim Source As cPackage = TryCast(sender, cPackage)
        'Dim WList As New List(Of Dictionary(Of String, Object))
        'If Source IsNot Nothing Then AddReceive(Source, True, True, WList)
        'For Each D As Dictionary(Of String, Object) In WList
        '    Threading.ThreadPool.UnsafeQueueUserWorkItem(New Threading.WaitCallback(AddressOf ChatClient.GetAttachment), D)
        'Next
        'WList.Clear()
    End Sub

    Private Declare Function GetActiveWindow Lib "user32" () As IntPtr

    Public Sub GetReceive(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim Source As cPackage = TryCast(sender, cPackage)
        Dim WList As New List(Of Dictionary(Of String, Object))
        If Source IsNot Nothing Then
            If GetActiveWindow <> Me.Handle Then
                TimerFlash.Start()
            End If



            Dim Str As String = cPackageToHtml(Source, False, True, WList)
            If Str <> "" Then
                WB_Receive.Document.Body.Document.Write(Str)
                StartReceiveScroll()
                For Each D As Dictionary(Of String, Object) In WList
                    Threading.ThreadPool.UnsafeQueueUserWorkItem(New Threading.WaitCallback(AddressOf ChatClient.GetAttachment), D)
                Next
            End If
        End If
        WList.Clear()
    End Sub

    Public Sub GetComplete(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim Title As String = TryCast(sender, String)
        If Title IsNot Nothing Then
            DocumentFileDownComplete(WB_Receive.Document.Body.Document, Title)
            StartReceiveScroll(350)
        End If
    End Sub

    Public Sub GetOldComplete(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim Title As String = TryCast(sender, String)
        If Title IsNot Nothing Then
            DocumentFileDownComplete(WB_Old.Document.Body.Document, Title)
            StartoldScroll(350)
        End If
    End Sub


    ''' <summary>
    ''' cPackage生成Html代码
    ''' </summary>
    ''' <param name="Info"></param>
    ''' <param name="IsSendComplete"></param>
    ''' <param name="IsNew"></param>
    ''' <param name="WList"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function cPackageToHtml(ByVal Info As cPackage, ByVal IsSendComplete As Boolean, ByVal IsNew As Boolean, ByVal WList As List(Of Dictionary(Of String, Object))) As String
        Dim Html As New System.Text.StringBuilder
        Dim ColorStyle As String
        If IsSendComplete Then
            ColorStyle = "MeSend"
        Else
            ColorStyle = "MeReceive"
        End If
        If IsSendComplete = False Then AddReed(Info.ID)
        If IsNew Then AddSendReceiveInfo(Receiver, Info)
        Select Case Info.PackageType
            Case cPackage.Enum_PackageType.Msg
                If IsSendComplete = False AndAlso IsNew Then
                    PlaySoundMsg()
                End If
                Html.AppendLine("<Div>")
                Html.Append(vbTab & "<span class='")
                Html.Append(ColorStyle)
                Html.Append("'>")
                Html.Append(Info.BaseMsg.Sender)
                Html.Append(" " & Info.BaseMsg.SendTime & "</span>")

                If Info.ReadTime <> New Date Then
                    Html.Append(vbTab & "<img src='")
                    Html.Append(ChatClient.GetSystemFace(Enum_FaceName.gifSystemOk))
                    Html.Append("' alt='")
                    Html.Append("已查看,查看时间是:")
                    Html.Append(Info.ReadTime)
                    Html.AppendLine("' /> ")
                End If

                Html.AppendLine(vbTab & "<Div class='CDiv'>")
                Html.AppendLine(Info.BaseMsg.Content) '内容
                Html.AppendLine(vbTab & "</Div>")
                Html.AppendLine("</Div>")
            Case cPackage.Enum_PackageType.ImgMsg
                Dim Str As String = Info.BaseMsg.Content
                Str = Str.Replace(PublicNetSystemLoading, GifLoadingPathAbsoluteUri)
                For Each Kv As KeyValuePair(Of String, String) In Info.Attachments
                    Try
                        If Kv.Value = "" Then
                            GetSystemFaceByString(Kv.Key)
                            Str = StringSystemFacePath(Str, Kv.Key)
                        Else
                            Dim D As New Dictionary(Of String, Object)
                            D.Add("Data_ID", Info.Data_Id)
                            D.Add("MD5", Kv.Value)
                            D.Add("Title", Kv.Key)

                            If Info.BaseMsg.Sender = UserName Then
                                D.Add("Sender", Receiver)
                            Else
                                D.Add("Sender", Info.BaseMsg.Sender)
                            End If
                            WList.Add(D)
                        End If
                    Catch ex As Exception
                    End Try
                Next
                If IsSendComplete = False AndAlso IsNew Then
                    PlaySoundMsg()
                End If
                Html.AppendLine("<Div>")
                Html.Append(vbTab & "<span class='")
                Html.Append(ColorStyle)
                Html.Append("'>")
                Html.Append(Info.BaseMsg.Sender)
                Html.AppendLine(" " & Info.BaseMsg.SendTime & "</span>")


                If Info.ReadTime <> New Date Then
                    Html.Append(vbTab & "<img src='")
                    Html.Append(ChatClient.GetSystemFace(Enum_FaceName.gifSystemOk))
                    Html.Append("' alt='")
                    Html.Append("已查看,查看时间是:")
                    Html.Append(Info.ReadTime)
                    Html.AppendLine("' /> ")
                End If

                Html.AppendLine(vbTab & "<Div class='CDiv'>")
                Html.AppendLine(Str) '内容
                Html.AppendLine(vbTab & "</Div>")
                Html.AppendLine("</Div>")

            Case cPackage.Enum_PackageType.Shake
                If Not IsDate(Info.BaseMsg.Content) Then
                    Return ""
                End If
                ''发送抖动消息提示
                Html.AppendLine("<Div class='SysInf'>")
                Html.Append(vbTab & "<img src='")
                Html.Append(ChatClient.GetSystemFace(Enum_FaceName.gifSystemOk))
                Html.AppendLine("' /> ")
                Html.Append(vbTab & Info.BaseMsg.SendTime)
                Html.Append("<Div class='CDiv'>")
                If IsSendComplete Then
                    Html.AppendLine("您给" & Me.Receiver & "发送了一个窗口抖动。")
                Else
                    Html.AppendLine(Info.BaseMsg.Sender & "给您发送了一个窗口抖动。")
                End If
                Html.AppendLine(vbTab & "</Div>")
                Html.AppendLine("</Div>")
                If IsNew Then
                    If CDate(Info.BaseMsg.Content).AddSeconds(30) > Info.CurrentGetTime Then
                        IsActivate = True
                        Me.IsOnline = True
                        TimerShake.Start()
                    End If
                End If
            Case cPackage.Enum_PackageType.File

                Try
                    Dim S() As String = Info.BaseMsg.Content.Split("|")
                    Dim SP() As String = S(0).Split(".")
                    Dim IconStr As String
                    If Not Info.Attachments.ContainsKey(S(0)) Then
                        Return ""
                    End If
                    Dim Md5 As String = Info.Attachments(S(0))


                    If SP.Length > 1 Then
                        IconStr = SP(SP.Length - 1)
                    Else
                        IconStr = ""
                    End If
                    Dim IconPath As String
                    If IconStr.ToLower = "exe" Then
                        IconPath = SystemFacePath & "Extension-" & S(0) & ".Png"
                        Dim len As Integer
                        len = S(2).Length / 2 - 1
                        Dim inputByteArray(len) As Byte
                        Dim x, i As Integer
                        For x = 0 To len
                            i = Convert.ToInt32(S(2).Substring(x * 2, 2), 16)
                            inputByteArray(x) = CType(i, Byte)
                        Next
                        File.WriteAllBytes(IconPath, inputByteArray)
                    Else
                        IconPath = SystemFacePath & "Extension-" & IconStr.ToUpper & ".Png"
                        SystemIcon.GetFileIcon("." & IconStr, False).ToBitmap.Save(IconPath, System.Drawing.Imaging.ImageFormat.Png)
                    End If

                    Html.AppendLine("<Div class='SysInf'>")
                    Html.Append(vbTab & "<img src='")
                    Html.Append(ChatClient.GetSystemFace(Enum_FaceName.gifSystemOk))
                    Html.AppendLine("' /> ")
                    Html.Append(vbTab & Info.BaseMsg.SendTime)
                    Html.Append("<Div class='CDiv'>")
                    If IsSendComplete Then
                        Html.AppendLine("您给[" & Me.Receiver & "]发送了文件:")
                    Else
                        Html.AppendLine("[" & Me.Receiver & "]给您发送了文件:")
                    End If
                    Html.AppendLine("</Div>")

                    Html.AppendLine("<table class='DTable'><tr><td>")
                    Html.Append("<a style=""text-decoration:none;"" href=""")
                    Html.Append(cHtml.Get_SchemeSplit(cHtml.SchemeSplit.FileOpen))
                    Html.Append(":")
                    Html.Append(S(0))
                    Html.Append("*")
                    Html.Append(Md5)
                    Html.AppendLine(""">")
                    Html.AppendLine(vbTab & "<img alt='" & S(0) & "' border=""0"" src='" & IconPath & "' />")
                    Html.AppendLine("</a> </td>")
                    Html.AppendLine(" <td> <table class='DTable'><tr><td>")
                    Html.AppendLine(S(0))
                    Html.AppendLine("</td></tr><tr><td>")
                    Html.AppendLine(FileLenStr(S(1)))
                    Html.AppendLine("</td></tr></table></td></tr></table>")
                    Html.AppendLine("</Div>")

                    Html.AppendLine("<div class=""CDiv"">")
                    Html.Append("<a  style=""margin: 1px 15px 0px 5px"" href=""")
                    Html.Append(cHtml.Get_SchemeSplit(cHtml.SchemeSplit.FileOpen))
                    Html.Append(":")
                    Html.Append(S(0))
                    Html.Append("*")
                    Html.Append(Md5)
                    Html.Append(""">打开文件</a> ")

                    Html.AppendLine("<a href=""")
                    Html.Append(cHtml.Get_SchemeSplit(cHtml.SchemeSplit.FileSave))
                    Html.Append(":")
                    Html.Append(S(0))
                    Html.Append("*")
                    Html.Append(Md5)
                    Html.Append(""">另外为</a>")
                    Html.AppendLine("</Div>")

                    If IsSendComplete = False AndAlso IsNew Then
                        PlaySoundMsg()
                    End If
                Catch ex As Exception
                    Return ""
                End Try
        End Select
        Return Html.ToString
    End Function


#End Region



#Region "获取旧信息"




    Private Sub WB_Send_PreviewKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles WB_Send.PreviewKeyDown
        If e.Control = True AndAlso e.KeyCode = Keys.Enter Then
            Cmd_Send_Click(Cmd_Send, New EventArgs)
            WB_Send.Document.DomDocument.designMode = "off"
            Application.DoEvents()
            WB_Send.Document.DomDocument.designMode = "on"
        End If
    End Sub

    Private Sub GetNowOldReceiveMsg()
        If ChatClient.PackList.ContainsKey(Receiver) Then
            Dim D As Date
            Dim isFirst As Boolean = True
            Dim WList As New List(Of Dictionary(Of String, Object))
            Dim Str As New System.Text.StringBuilder("")
            WB_Old.Document.Body.InnerHtml = ""
            For Each Info As cPackage In ChatClient.PackList(Receiver).Clone
                If D <> Info.BaseMsg.SendTime.Date Then
                    D = Info.BaseMsg.SendTime.Date
                    If isFirst = False Then
                        Str.AppendLine("<Br/>")
                    End If
                    isFirst = False
                    Str.AppendLine("<span class='DateLine'>  日期:" & D.ToString("yyyy年MM月dd日") & "</span><HR class='CutLine'>")
                End If
                Str.AppendLine(cPackageToHtml(Info, Info.BaseMsg.Sender <> Receiver, False, WList))
            Next
            WB_Old.Document.Body.Document.Write(Str.ToString)
            StartoldScroll()
            For Each W As Dictionary(Of String, Object) In WList
                Threading.ThreadPool.UnsafeQueueUserWorkItem(New Threading.WaitCallback(AddressOf ChatClient.GetOldAttachment), W)
            Next
        End If
    End Sub



    Private Sub Cmd_Find_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Find.Click
        Dim Dt As DataTable = ChatClient.GetOldReceive(Receiver, DTP_Start.Value.Date, DTP_End.Value.Date.ToString("yyyy-MM-dd 23:59:59.999"))
        WB_Old.Document.Body.InnerHtml = ""
        If Dt IsNot Nothing Then
            Dim D As Date
            Dim isFirst As Boolean = True
            Dim WList As New List(Of Dictionary(Of String, Object))
            Dim Str As New System.Text.StringBuilder("")
            For Each Row As DataRow In Dt.Rows
                Dim Arr As Byte() = Row("Data")
                Dim T As cPackage.Enum_PackageType = Row("Type")
                Dim Info As New cPackage(Arr, Row("Type"))
                Info.BaseToAttachments()
                Info.ID = Row("ID")
                Info.Data_Id = Row("Data_Id")
                Info.ReadTime = IsNull(Row("ReadTime"), New Date)
                'Info.CurrentGetTime = Row("CurrentTime")
                If ChatClient.PackList.ContainsKey(Receiver) Then
                    For Each II As cPackage In ChatClient.PackList(Receiver)
                        If II.ID = Info.ID Then
                            II.ReadTime = Info.ReadTime
                        End If
                    Next
                End If



                If D <> Info.BaseMsg.SendTime.Date Then
                    D = Info.BaseMsg.SendTime.Date
                    If isFirst = False Then
                        Str.AppendLine("<Br/>")
                    End If
                    isFirst = False
                    Str.AppendLine("<span class='DateLine'>  日期:" & D.ToString("yyyy年MM月dd日") & "</span>")
                    Str.AppendLine("<HR class='CutLine'>")
                End If
                Str.AppendLine(cPackageToHtml(Info, Info.BaseMsg.Sender <> Receiver, False, WList))
            Next
            WB_Old.Document.Body.Document.Write(Str.ToString)
            StartoldScroll()
            For Each W As Dictionary(Of String, Object) In WList
                Threading.ThreadPool.UnsafeQueueUserWorkItem(New Threading.WaitCallback(AddressOf ChatClient.GetOldAttachment), W)
            Next
        End If

    End Sub





#End Region

#Region "滚动"


    Sub StartReceiveScroll(Optional ByVal Interval As Integer = 10)
        If TimerReceive.Enabled Then
            TimerReceive.Stop()
        End If
        TimerReceive.Interval = Interval
        TimerReceive.Start()
    End Sub
    Sub StartoldScroll(Optional ByVal Interval As Integer = 10)
        If Timerold.Enabled Then
            Timerold.Stop()
        End If
        Timerold.Interval = Interval
        Timerold.Start()
    End Sub

    Private Sub Timerold_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timerold.Tick
        Timerold.Stop()
        'WB_Old.Document.Body.Document.Write("<SCRIPT>JAVASCRIPT:this.window.scrollTo(0,document.body.scrollHeight);</SCRIPT>")
        WB_Old.Document.Window.ScrollTo(0, WB_Old.Document.Body.ScrollRectangle.Height)
    End Sub
    Private Sub TimerReceive_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerReceive.Tick
        TimerReceive.Stop()
        'WB_Receive.Document.Body.Document.Write("<SCRIPT>JAVASCRIPT:this.window.scrollTo(0,document.body.scrollHeight);</SCRIPT>")
        WB_Receive.Document.Window.ScrollTo(0, WB_Receive.Document.Body.ScrollRectangle.Height)
    End Sub
#End Region

#Region "文件打开和保存"

    Public Delegate Sub DGetFileComplete(ByVal Sender As String, ByVal FileMd5Name As String, ByVal Title As String, ByVal IsOpen As Boolean, ByVal IsError As Boolean)
    Public Sub GetFileComplete(ByVal Sender As String, ByVal FileMd5Name As String, ByVal Title As String, ByVal IsOpen As Boolean, ByVal IsError As Boolean)
        If IsError Then
            ShowErrorMsg(My.Resources.ChatRes.GifSmallError, 4, "下载文件失败!")
        Else
            If IsOpen Then
                FileOpen(FileMd5Name, Title)
            Else
                FileSave(FileMd5Name, Title)
            End If

        End If
        PanelShadow.Visible = False
    End Sub


    Sub FileOpen(ByVal OldFile As String, ByVal NewFile As String)
        Try
            Dim d As String = System.IO.Path.GetTempPath & System.IO.Path.GetRandomFileName & "\"
            MDDir(d)
            Dim f As String = d & NewFile
            FileCopy(OldFile, f)
            Process.Start(f)
            'My.Computer.FileSystem.DeleteDirectory(d, FileIO.DeleteDirectoryOption.DeleteAllContents, FileIO.RecycleOption.DeletePermanently)
        Catch ex As Exception
        End Try
    End Sub


    Sub FileSave(ByVal OldFile As String, ByVal NewFile As String)
        Try
            Using D As New SaveFileDialog
                D.FileName = NewFile
                D.Filter = "所有类型|*.*"
                If D.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                    FileCopy(OldFile, D.FileName)
                    If MsgBox("保存文件成功,是否打开文件", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        Process.Start(D.FileName)
                    End If
                End If
            End Using
        Catch ex As Exception
        End Try
    End Sub
#End Region

    Private Sub Pic_Head_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PicHead.MouseClick
        Dim Control As Short = System.Windows.Forms.Control.ModifierKeys \ Keys.Control
        If Control = 1 AndAlso e.Button = Windows.Forms.MouseButtons.Right Then
            Clipboard.SetText(WB_Receive.DocumentText)
        End If
    End Sub

#Region "跳转"


    Private Sub WB_Receive_Navigating(ByVal sender As Object, ByVal e As System.Windows.Forms.WebBrowserNavigatingEventArgs) Handles WB_Receive.Navigating, WB_Old.Navigating
        If e.Url.AbsolutePath <> "blank" Then
            e.Cancel = True
            Select Case e.Url.Scheme.ToLower
                Case "file", "ftp", "gopher", "http", "https", "ldap", "mailto", "net.pipe", "net.tcp", "news", "nntp", "telnet", "uuid"
                    Exit Sub

                Case cHtml.Get_SchemeSplit(cHtml.SchemeSplit.FileOpen).ToLower, cHtml.Get_SchemeSplit(cHtml.SchemeSplit.FileSave).ToLower
                    Dim s() As String = e.Url.LocalPath.Split("*")
                    Dim F() As String = s(0).Split(".")
                    If s.Length = 2 Then
                        Dim P As String = Dir(ImgPath & s(1) & "*")
                        If P <> "" Then
                            If FileToMD5(ImgPath & P) = s(1) Then
                                If e.Url.Scheme.ToLower = cHtml.Get_SchemeSplit(cHtml.SchemeSplit.FileOpen).ToLower Then
                                    FileOpen(ImgPath & P, s(0))
                                Else
                                    FileSave(ImgPath & P, s(0))
                                End If
                                Exit Sub
                            End If
                        End If
                        PanelShadow.BackgroundImage = PClass.PClass.CaptureFromImage(Me)
                        PanelShadow.BringToFront()
                        PanelShadow.Visible = True
                        Dim w As New Dictionary(Of String, Object)
                        w.Add("MD5", s(1))
                        w.Add("Title", s(0))
                        If F.Length = 1 Then
                            w.Add("Extension", ".")
                        Else
                            w.Add("Extension", "." & F(F.Length - 1))
                        End If
                        w.Add("Sender", Receiver)
                        If e.Url.Scheme.ToLower = cHtml.Get_SchemeSplit(cHtml.SchemeSplit.FileOpen).ToLower Then
                            w.Add("FileOpen", True)
                        Else
                            w.Add("FileOpen", False)
                        End If


                        Threading.ThreadPool.UnsafeQueueUserWorkItem(New Threading.WaitCallback(AddressOf ChatClient.GetAttachmentFile), w)
                    End If
                Case cHtml.Get_SchemeSplit(cHtml.SchemeSplit.FileSave).ToLower
            End Select
        End If
    End Sub

    Private Sub WB_Receive_NewWindow(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles WB_Receive.NewWindow
        e.Cancel = True
    End Sub

    Private Sub WB_Old_NewWindow(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles WB_Old.NewWindow
        e.Cancel = True
    End Sub
    Private Sub WB_Send_NewWindow(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles WB_Send.NewWindow
        e.Cancel = True
    End Sub
#End Region


#Region "闪烁"
    Public Declare Function FlashWindow Lib "user32" (ByVal hwnd As IntPtr, ByVal bInvert As Boolean) As Long
    Public FlashTime As Integer = 0
    Private Sub TimerFlash_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerFlash.Tick
        If FlashTime = 0 Then
            FlashTime = 5
        End If
        FlashWindow(Me.Handle, True)
        FlashTime = FlashTime - 1
        If FlashTime = 0 Then
            TimerFlash.Stop()
        End If
    End Sub
#End Region



    Private Sub Pic_GetImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Pic_GetImage.Click
        Dim T As FormPic = New FormPic
        T.Receiver = Receiver
        T.Show()
    End Sub



 
End Class


