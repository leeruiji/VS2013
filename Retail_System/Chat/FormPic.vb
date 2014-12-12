Imports PClass.PClass
Imports Retail_System.ChatClient
Public Class FormPic
    Private TH As Threading.Thread
    Private _Receiver As String
    Property Receiver() As String
        Get
            Return _Receiver
        End Get
        Set(ByVal value As String)
            Label1.Text = value
            _Receiver = value
        End Set
    End Property


    Dim LastID As Integer
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Button1.Text = "开始截图" Then
            sCount = -1
            Button1.Text = "停止截图"
            LastID = LastChat_ID
            GetImage()
        Else

            Button1.Text = "开始截图"
        End If


    End Sub



    Sub SumTX()
        Dim D As Integer = Decimal.ToInt32(NumericUpDownDelay.Value)
        Dim T As Integer = Decimal.ToInt32(NumericUpDownTime.Value)

        LabelTime.Text = D * T / 1000 & "秒"
        LabelKB.Text = Format(1000 * 600 / D, "#,###,##0.00Kb/s")


    End Sub
    '开始获取图像
    Sub GetImage()
        Stoped = False
        Timer1.Interval = Decimal.ToInt32(NumericUpDownDelay.Value) / 2
        Timer1.Start()
        DelayTime = Decimal.ToInt32(NumericUpDownDelay.Value)
        Dim Width As Long
        Dim Height As Long
        Dim Quality As Byte = Val(CB_Quality.Text)
        If RadioButton1.Checked Then
            Width = PictureBox1.Width
            Height = PictureBox1.Height
            Quality = Quality * 2
        End If
        ChatClient.SendCutScreen(Receiver, Decimal.ToInt32(NumericUpDownTime.Value), DelayTime, Val(CB_Quality.Text), Width, Height)
        If TH IsNot Nothing AndAlso TH.IsAlive Then
            Exit Sub
        End If
        TH = New Threading.Thread(AddressOf ReceiverSrceen)
        TH.Start()
    End Sub


    Dim Stoped As Boolean = True
    Dim Img As Image
    Dim sCount As Integer
    Dim SendTime As Date
    Dim Msg As String
    Dim T As Date
    Dim LastTime As Date
    Dim DelayTime As Integer
    Dim KB As Integer
    Dim KBS As String = ""

    Sub ReceiverSrceen()
        LastTime = Now
        Do While Stoped = False
            Try

                Dim D As Date = Now
                Dim s As Integer = DelayTime - (D - LastTime).TotalMilliseconds
                LastTime = D
                If s > 0 Then
                    Threading.Thread.Sleep(s)
                End If
                Dim Cnn As New SqlClient.SqlConnection
                Dim Da As New SqlClient.SqlDataAdapter
                Dim R As DtReturnMsg = SqlChatToDt("Select top 1 * from " & ChatScreen & " where Sender='" & Receiver & "' and Receiver='" & UserName & "' and SenderId>" & LastID & " ", Cnn, Da)
                If R.IsOk AndAlso R.Dt.Rows.Count > 0 Then
                    Dim I As New IO.MemoryStream(TryCast(R.Dt.Rows(0).Item("data"), Byte()))
                    KB = I.Length
                    KBS = KB / DelayTime
                    Dim Img As Image = Image.FromStream(I)
                    sCount = R.Dt.Rows(0).Item("sCount")
                    Me.Img = Img
                    SendTime = R.Dt.Rows(0).Item("SendTime")
                    Msg = IsNull(R.Dt.Rows(0).Item("Msg"), "")
                    'Dim s As String = ImgPath & "Screen" & R.Dt.Rows(0).Item("Id") & ".png"
                    'IO.File.WriteAllBytes(s, R.Dt.Rows(0).Item("data"))
                    'Img = s
                    'T = R.Dt.Rows(0).Item("SendTime")
                    R.Dt.Rows(0).Delete()
                    DtToUpDate(R.Dt, Cnn, Da)
                End If
                Da.Dispose()
                Cnn.Dispose()
            Catch ex As Exception
            End Try
        Loop
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If Img IsNot Nothing Then
            Try
                PictureBox1.Image = Img
                Label_sCount.Text = sCount
                LabelSendTime.Text = SendTime.ToString("yyyy-MM-dd") & vbCrLf & SendTime.ToString("HH:mm:ss")
                LabelMsg.Text = Msg
                LabelKBS.Text = KBS & "KB/s"
                If sCount = 0 Then
                    If Button1.Text = "停止截图" Then
                        sCount = -1
                        GetImage()
                    Else
                        Stoped = True
                        KBS = ""
                        LabelKBS.Text = ""
                        Timer1.Stop()
                    End If
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub FormPic_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Stoped = True
        Threading.Thread.Sleep(50)
    End Sub

    Private Sub FormPic_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DP_Start.Value = Today
        DP_End.Value = Today
        SumTX()

    End Sub

    Private Sub NumericUpDownTime_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericUpDownTime.ValueChanged
        SumTX()
    End Sub

    Private Sub NumericUpDownDelay_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericUpDownDelay.ValueChanged
        SumTX()
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked Then
            PictureBox1.Dock = DockStyle.None
            PictureBox1.SizeMode = PictureBoxSizeMode.AutoSize

        Else
            PictureBox1.Dock = DockStyle.Fill
            PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If MsgBox("是否重启[" & Receiver & "]的客户端?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            ChatClient.SendSytemMsg(Receiver, "自动重启", 10)
        End If

    End Sub

    Private Sub Btn_Search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Search.Click
        Dim P As New Dictionary(Of String, Object)
        P.Add("Date1", DP_Start.Value)
        P.Add("Date2", DP_End.Value)
        P.Add("user_id", _Receiver)
        Dim DtR As DtReturnMsg = SqlStrToDt("select * from Sys_Log where sDate between @Date1 and @Date2 and user_id=@user_id order by sTime", P)

        If DtR.IsOk Then
            FG1.DtToSetFG(DtR.Dt)
        Else
            FG1.Rows.Count = 1
        End If
    End Sub
End Class