
Public Class FormFaceSelect
    Private _LastForm As Object
    Public Property LastForm() As Object
        Get
            Return _LastForm
        End Get
        Set(ByVal value As Object)
            _LastForm = value
        End Set
    End Property

    Public Sub New(ByVal LastImage As Image)

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent() ' 在 InitializeComponent() 调用之后添加任何初始化
        PicBig.Image = LastImage
        PicSmall.Image = LastImage


    End Sub


    Private Sub FormFaceSelect_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AddHandler PicPointBL.MouseUp, AddressOf PicPoint_MouseUp
        AddHandler PicPointBM.MouseUp, AddressOf PicPoint_MouseUp
        AddHandler PicPointBR.MouseUp, AddressOf PicPoint_MouseUp
        AddHandler PicPointML.MouseUp, AddressOf PicPoint_MouseUp
        AddHandler PicPointMR.MouseUp, AddressOf PicPoint_MouseUp
        AddHandler PicPointTL.MouseUp, AddressOf PicPoint_MouseUp
        AddHandler PicPointTM.MouseUp, AddressOf PicPoint_MouseUp
        AddHandler PicPointTR.MouseUp, AddressOf PicPoint_MouseUp



        AddHandler PicPointBL.MouseMove, AddressOf PicPoint_MouseMove
        AddHandler PicPointBM.MouseMove, AddressOf PicPoint_MouseMove
        AddHandler PicPointBR.MouseMove, AddressOf PicPoint_MouseMove
        AddHandler PicPointML.MouseMove, AddressOf PicPoint_MouseMove
        AddHandler PicPointMR.MouseMove, AddressOf PicPoint_MouseMove
        AddHandler PicPointTL.MouseMove, AddressOf PicPoint_MouseMove
        AddHandler PicPointTM.MouseMove, AddressOf PicPoint_MouseMove
        AddHandler PicPointTR.MouseMove, AddressOf PicPoint_MouseMove

        AddHandler RadioButton1.CheckedChanged, AddressOf RadioButton_CheckedChanged
        AddHandler RadioButton2.CheckedChanged, AddressOf RadioButton_CheckedChanged
        AddHandler RadioButton3.CheckedChanged, AddressOf RadioButton_CheckedChanged
        AddHandler RadioButton4.CheckedChanged, AddressOf RadioButton_CheckedChanged

        'ReFreshPic()


    End Sub

#Region "PicPoint"
    Private PointLock As Boolean
    Private Sub PicPoint_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Dim F As New System.Windows.Forms.MouseEventArgs(e.Button, e.Clicks, e.X + sender.left, e.Y + sender.top, e.Delta)
        If F.Button = Windows.Forms.MouseButtons.Left Then
            If sender IsNot Nothing Then
                PointLock = True
                Select Case sender.Name
                    Case PicPointTL.Name
                        Dim W As Integer = PicCutHead.Width + PicCutHead.Left
                        Dim H As Integer = PicCutHead.Height
                        PicCutHead.Left = F.X
                        PicCutHead.Width = W - F.X
                        PicCutHead.Height = PicCutHead.Width
                        PicCutHead.Top = PicCutHead.Top - (PicCutHead.Height - H)
                    Case PicPointTM.Name
                        Dim W As Integer = PicCutHead.Width
                        Dim H As Integer = PicCutHead.Height + PicCutHead.Top
                        PicCutHead.Top = F.Y
                        PicCutHead.Height = H - F.Y
                        PicCutHead.Width = PicCutHead.Height
                        PicCutHead.Left = PicCutHead.Left - (PicCutHead.Width - W) / 2
                    Case PicPointTR.Name
                        Dim W As Integer = (F.X - PicCutHead.Left)
                        Dim H As Integer = PicCutHead.Height + PicCutHead.Top
                        PicCutHead.Top = F.Y
                        PicCutHead.Width = W
                        PicCutHead.Height = H - F.Y


                    Case PicPointML.Name
                        Dim W As Integer = PicCutHead.Width + PicCutHead.Left
                        Dim H As Integer = PicCutHead.Height
                        PicCutHead.Left = F.X
                        PicCutHead.Width = W - F.X
                        PicCutHead.Height = PicCutHead.Width
                        PicCutHead.Top = PicCutHead.Top - (PicCutHead.Height - H) / 2
                    Case PicPointMR.Name
                        Dim W As Integer = (F.X - PicCutHead.Left)
                        Dim H As Integer = PicCutHead.Height
                        PicCutHead.Width = W
                        PicCutHead.Height = W
                        PicCutHead.Top = PicCutHead.Top - (PicCutHead.Height - H) / 2
                    Case PicPointBL.Name
                        Dim W As Integer = PicCutHead.Width + PicCutHead.Left
                        PicCutHead.Left = F.X
                        PicCutHead.Width = W - F.X
                        PicCutHead.Height = PicCutHead.Width
                    Case PicPointBM.Name
                        Dim H As Integer = F.Y - PicCutHead.Top
                        Dim W As Integer = PicCutHead.Width
                        PicCutHead.Width = H
                        PicCutHead.Height = H
                        PicCutHead.Left = PicCutHead.Left - (PicCutHead.Width - W) / 2
                    Case PicPointBR.Name
                        Dim W As Integer = (F.X - PicCutHead.Left)
                        PicCutHead.Width = W
                        PicCutHead.Height = W
                End Select

                PicPoint_ReDraw(True)
                PointLock = False
                Me.Refresh()
            End If
        End If
    End Sub

    Private Sub PicPoint_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Left Then
            PointHide()
            PicCutHead_Point = New Point(e.X, e.Y)
            Panel1.Refresh()
            Panel2.Refresh()
            PicPoint_ReDraw()
            PointShow()
        End If
    End Sub

    Private Const PLR As Integer = 2
    ''' <summary>
    ''' 重新定位point控件
    ''' </summary>
    ''' <param name="NoLoack"></param>
    ''' <remarks></remarks>
    Sub PicPoint_ReDraw(Optional ByVal NoLoack As Boolean = False)
        If NoLoack OrElse PointLock = False Then

            PicPointTL.Top = PicCutHead.Top - PicPointTL.Height + PLR
            PicPointTL.Left = PicCutHead.Left - PicPointBL.Width + PLR


            PicPointTM.Top = PicPointTL.Top
            PicPointTM.Left = PicCutHead.Left + PicCutHead.Width / 2 - PicPointTL.Width / 2

            PicPointTR.Top = PicPointTL.Top
            PicPointTR.Left = PicCutHead.Left + PicCutHead.Width - PLR


            PicPointML.Top = PicCutHead.Top + PicCutHead.Height / 2 - PicPointBL.Height / 2
            PicPointML.Left = PicPointTL.Left


            PicPointMR.Top = PicPointML.Top
            PicPointMR.Left = PicPointTR.Left


            PicPointBL.Top = PicCutHead.Top + PicCutHead.Height - PLR
            PicPointBL.Left = PicPointTL.Left


            PicPointBM.Top = PicPointBL.Top
            PicPointBM.Left = PicPointTM.Left

            PicPointBR.Top = PicPointBL.Top
            PicPointBR.Left = PicPointTR.Left
            PicCutHead.Refresh()
            If PicCutHead.Width > 1 OrElse PicCutHead.Height > 1 Then
                PicBig.Image = SystemIcon.CopyFromImage(PicCutHead)
                PicSmall.Image = PicBig.Image
            End If

        End If
    End Sub

    Sub PointHide()
        PicPointBL.Visible = False
        PicPointBM.Visible = False
        PicPointBR.Visible = False
        PicPointML.Visible = False
        PicPointMR.Visible = False
        PicPointTL.Visible = False
        PicPointTM.Visible = False
        PicPointTR.Visible = False
    End Sub
    Sub PointShow()
        PicPointBL.Visible = True
        PicPointBM.Visible = True
        PicPointBR.Visible = True
        PicPointML.Visible = True
        PicPointMR.Visible = True
        PicPointTL.Visible = True
        PicPointTM.Visible = True
        PicPointTR.Visible = True
    End Sub

#End Region


#Region "PicCutHead"
    Dim PicCutHead_Point As Point

    Private Sub PicCutHead_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PicCutHead.MouseDoubleClick
        Cmd_Save_Click(sender, New EventArgs)
    End Sub


    Private Sub PicCutHead_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PicCutHead.MouseMove
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Dim X As Integer = e.X + PicCutHead.Left - PicCutHead_Point.X
            Dim Y As Integer = e.Y + PicCutHead.Top - PicCutHead_Point.Y
            If X < 0 Then X = 0
            If Y < 0 Then Y = 0
            If X > Panel1.Width - PicCutHead.Width Then X = Panel1.Width - PicCutHead.Width
            If Y > Panel1.Height - PicCutHead.Height Then Y = Panel1.Height - PicCutHead.Height

            PicCutHead.Top = Y
            PicCutHead.Left = X
        End If
    End Sub
    Private Sub PicCutHead_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PicCutHead.MouseDown
        PicCutHead_Point = New Point(e.X, e.Y)
        PointHide()
    End Sub
    Private Sub PicCutHead_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PicCutHead.MouseUp
        PicPoint_ReDraw()
        PointShow()
    End Sub
    Private Sub PicCutHead_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles PicCutHead.Resize
        PicPoint_ReDraw()
    End Sub
#End Region



#Region "图片加载"
    Dim LastImage As Image
    Private Sub Cmd_Load_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Load.Click
        Using D As New OpenFileDialog
            D.FileName = ""
            D.Filter = "图片文件(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|Gif文件|*.Gif|JPG文件|*.JPG|PNG文件|*.PNG|BMP文件|*.BMP"
            If D.ShowDialog = Windows.Forms.DialogResult.OK Then
                Cmd_GetBack.Enabled = True
                Cmd_Save.Enabled = True
                LastImage = Image.FromFile(D.FileName)
                Panel1.BackgroundImage = LastImage
                ReFreshPic()
            Else
                Exit Sub
            End If
        End Using
    End Sub

    Sub ReFreshPic()
        PicCutHead.Visible = False
        PointHide()
        Panel2.Visible = False
        Me.Refresh()
        Panel2.BackgroundImage = SystemIcon.CaptureFromImage(Panel1)
        Panel2.BackgroundImageLayout = ImageLayout.Zoom
        Panel2.Visible = True
        PointShow()
        PicPoint_ReDraw()
        PicCutHead.Visible = True

    End Sub

    Private Sub RadioButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Object.ReferenceEquals(RadioButton1, sender) Then
            Panel1.BackgroundImageLayout = ImageLayout.None
        ElseIf Object.ReferenceEquals(RadioButton2, sender) Then
            Panel1.BackgroundImageLayout = ImageLayout.Zoom
        ElseIf Object.ReferenceEquals(RadioButton3, sender) Then
            Panel1.BackgroundImageLayout = ImageLayout.Stretch
        ElseIf Object.ReferenceEquals(RadioButton4, sender) Then
            Panel1.BackgroundImageLayout = ImageLayout.Center
        End If
        Panel2.BackgroundImageLayout = Panel1.BackgroundImageLayout
        ReFreshPic()
    End Sub

    Private Sub Cmd_Small_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Small.Click
        Panel1.BackgroundImage = PicBig.Image
        ReFreshPic()
    End Sub

    Private Sub Cmd_GetBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_GetBack.Click
        Panel1.BackgroundImage = LastImage
        ReFreshPic()
    End Sub
#End Region



#Region "截图"
    Private Declare Function CameraSubArea Lib "CameraDll.dll" (ByVal a As Long) As Long

    Private Sub Cmd_ImageCut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_ImageCut.Click
        TimerCutPic.Interval = 1
        TimerCutPic.Start()
    End Sub



    Private Sub TimerCutPic_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerCutPic.Tick
        TimerCutPic.Stop()
        Dim C As Object = Clipboard.GetDataObject
        Clipboard.Clear()
        Try
            Call CameraSubArea(0)
            If Clipboard.GetImage IsNot Nothing Then
                Cmd_GetBack.Enabled = True
                Cmd_Save.Enabled = True
                Panel1.BackgroundImage = Clipboard.GetImage
                LastImage = Panel1.BackgroundImage
                ReFreshPic()
            Else
                Clipboard.SetDataObject(C)
            End If

        Catch ex As Exception
            Panel1.BackgroundImage = LastImage
        End Try
    End Sub
#End Region








    Private Sub Cmd_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Save.Click
        If MsgBox("是否保存当前头像?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "头像选择") = MsgBoxResult.Yes Then
            LastForm.RetrunObj = PicSmall.Image
            Me.Close()
        End If
    End Sub

End Class