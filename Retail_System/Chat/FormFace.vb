Public Class FormFace
 
    Public Delegate Sub DFaceSelect(ByVal FaceStr As String)

    Public FaceSelect As DFaceSelect


    Private Sub FormFace_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Deactivate
        Me.Visible = False
    End Sub
    Private Sub FormFace_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ShowSystemFace()
    End Sub


    Public Sub ShowSystemFace()
        If TabControl1.SelectedIndex = 0 Then
            DG_ShowSystemFace()
        Else
            Panel_ShowSystemFace()
        End If
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        ShowSystemFace()
    End Sub


    Public Sub ShowFace(ByVal Left As Integer, ByVal Top As Integer, ByVal FRetrun As DFaceSelect)
        TimerShow.Start()
        Me.Visible = True
        Dim T As Integer = MousePosition.Y - Me.Height - Top
        Dim L As Integer = MousePosition.X - Me.Width / 2 - Left

        If T < 0 Then
            T = 0
        ElseIf T + Me.Height > Screen.PrimaryScreen.Bounds.Height Then
            T = Screen.PrimaryScreen.Bounds.Height - Me.Height
        End If
        If L < 0 Then
            L = 0
        ElseIf L + Me.Width > Screen.PrimaryScreen.Bounds.Width Then
            L = Screen.PrimaryScreen.Bounds.Width - Me.Width
        End If

        Me.Left = L
        Me.Top = T
        Me.ShowSystemFace()
        Me.FaceSelect = FRetrun

    End Sub

    Private Sub TimerShow_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerShow.Tick
        TimerShow.Stop()
        Me.Visible = True
    End Sub



    Private Sub _FaceSelect(ByVal FaceStr As String)
        If FaceSelect IsNot Nothing Then
            If FaceStr.StartsWith("gif") Then
                FaceSelect(ChatClient.GetSystemFaceByString(FaceStr))
            End If
        End If
    End Sub

#Region "静态"



    Private Sub DG_ShowSystemFace()
        Static IsShow As Boolean
        If IsShow = False Then
            DG.AllowUserToAddRows = False
            Dim C As Integer = 14
            For i As Integer = 1 To 105
                Dim R As Integer
                C = C + 1
                If C > 14 Then
                    R = DG.Rows.Add()
                    DG.Rows(R).Height = 30
                    C = 0
                End If
                DG.Item(C, R).Value = My.resources.ChatRes.ResourceManager.GetObject("gif" & i)
                DG.Item(C, R).Tag = "gif" & i
            Next
            IsShow = True
        End If
    End Sub

    Private Sub DG_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG.CellClick
        _FaceSelect(DG.Item(e.ColumnIndex, e.RowIndex).Tag)
        Me.Visible = False
    End Sub



    Private Sub DG_CellMouseEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG.CellMouseEnter
        ' sender.Selected = True
        ' DG.SelectedCells(0).Selected = False
        DG.Item(e.ColumnIndex, e.RowIndex).Selected = True
        'DG.Item(e.ColumnIndex, e.RowIndex).

        If e.ColumnIndex < 5 AndAlso PicFaceShow1.Left < DG.Width / 2 Then
            PicFaceShow1.Left = DG.Left + DG.Width + 1 - PicFaceShow1.Width
        ElseIf e.ColumnIndex > 10 AndAlso PicFaceShow1.Left > DG.Width / 2 Then
            PicFaceShow1.Left = DG.Left + 1
        End If


        PicFaceShow1.Visible = True
        PicFaceShow1.Image = DG.Item(e.ColumnIndex, e.RowIndex).Value
        Try
            If PicFaceShow1.Image.Width > 85 Or PicFaceShow1.Image.Width > 85 Then
                PicFaceShow1.SizeMode = PictureBoxSizeMode.Zoom
            Else
                PicFaceShow1.SizeMode = PictureBoxSizeMode.CenterImage
            End If
        Catch ex As Exception
            PicFaceShow1.SizeMode = PictureBoxSizeMode.CenterImage
        End Try
    End Sub

    Private Sub DG_CellMouseLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG.CellMouseLeave
        PicFaceShow1.Visible = False
        DG.CurrentCell.Selected = False
    End Sub



    Private Sub DG_RowPrePaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles DG.RowPrePaint
        e.PaintParts = e.PaintParts And Not DataGridViewPaintParts.Focus
    End Sub



    Private Sub PicFaceShow_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PicFaceShow1.Paint
        Dim P As PictureBox = TryCast(sender, PictureBox)
        Dim m_BorderColor As Color = Color.DodgerBlue
        Dim m_BorderWidth As Integer = 1
        Dim Pen1 As Pen = New Pen(m_BorderColor)
        Pen1.Width = m_BorderWidth
        e.Graphics.DrawRectangle(Pen1, CInt(m_BorderWidth / 2), CInt(m_BorderWidth / 2) _
        , P.Width - m_BorderWidth * 2 _
        , P.Height - m_BorderWidth * 2)
    End Sub
#End Region


#Region "动态"
    Private Sub Panel_ShowSystemFace()
        Static IsShow As Boolean
        If IsShow = False Then
            For i As Integer = 1 To 105
                Dim P As New PictureBox
                P.Name = "PicFace" & i
                P.SizeMode = PictureBoxSizeMode.CenterImage
                P.Width = 30
                P.Height = 30
                P.Margin = New Padding(0)
                P.Padding = New Padding(5)
                PanelFace.Controls.Add(P)
                P.Image = My.resources.ChatRes.ResourceManager.GetObject("gif" & i)
                P.Visible = True
                P.Left = 0
                P.Top = 0
                P.Tag = "gif" & i
                AddHandler P.Paint, AddressOf PicFace_Paint
                AddHandler P.MouseEnter, AddressOf PicFace_MouseEnter
                AddHandler P.MouseLeave, AddressOf PicFace_MouseLeave
                AddHandler P.MouseClick, AddressOf PicFace_MouseClick
            Next
            IsShow = True
        End If
    End Sub



    Private Sub PicFace_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs)
        Dim P As PictureBox = TryCast(sender, PictureBox)
        Dim m_BorderColor As Color = Color.FromArgb(255, 223, 230, 246)
        Dim m_BorderWidth As Integer = 1
        Dim Pen1 As Pen = New Pen(m_BorderColor)
        Pen1.Width = m_BorderWidth
        Dim I As Integer = 0
        e.Graphics.DrawRectangle(Pen1, I, I _
        , P.Width - 1 _
        , P.Height - 1)
    End Sub

    Private Sub PicFace_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim P As PictureBox = TryCast(sender, PictureBox)
        P.BackColor = Color.FromArgb(180, 223, 254, 255)
    End Sub

    Private Sub PicFace_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim P As PictureBox = TryCast(sender, PictureBox)
        P.BackColor = Color.White

    End Sub
    Private Sub PicFace_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Dim P As PictureBox = TryCast(sender, PictureBox)
        _FaceSelect(P.Tag)
        Me.Visible = False
    End Sub
#End Region



 


End Class