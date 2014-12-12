Option Compare Text
Imports System.Threading
Imports PClass.PClass
Imports System.Text.RegularExpressions
Imports System.Drawing.Imaging

Class ChatClient

#Region "聊天窗口"
    Public Shared ImgPath As String
    Public Shared TempImgPath As String
    Public Shared TempPath As String
    Public Shared SystemFacePath As String
    Public Shared GifLoadingPath As String
    Public Shared GifLoadingPathAbsoluteUri As String

    Public Const PublicNetFilePath As String = "C:\PublicNetFilePath\"
    Public Const PublicNetSystemFacePath As String = "C:\PublicNetSystemFacePath\"
    Public Const PublicLoadingGif As String = "BMPLoading.gif"
    Public Const PublicNetSystemLoading As String = "C:\PublicNetSystemFacePath\" & PublicLoadingGif
    Public Shared FaceSelectForm As FormFace

#End Region
    Public Const DB As String = "_GYFZ"

    Public Shared ChatDB As String = "Chat" & DB
    Public Shared ChatData As String = "ChatData" & DB
    Public Shared ChatAttachment As String = "ChatAttachment" & DB
    Public Shared ChatDataLinkAttachment As String = "ChatDataLinkAttachment" & DB
    Public Shared ChatUserSetting As String = "ChatUserSetting" & DB
    Public Shared ChatScreen As String = "ChatScreen" & DB

    Private Shared GetIdDone As New ManualResetEvent(False)
    Private Shared SendDone As New ManualResetEvent(False)
    Private Shared SendOkDone As New ManualResetEvent(False)
    Private Shared ReceiveDone As New ManualResetEvent(False)
    Private Shared ReadDone As New ManualResetEvent(False)


    Private Shared SendList As New Queue(Of cPackage) '待发送
    Private Shared SendOkList As New Queue(Of cPackage) '发送成功
    Private Shared SendErrorList As New Queue(Of cPackage) '发送错误
    Private Shared ReceiveList As New Queue(Of cPackage) '接收等待处理
    Private Shared ReadList As New Queue(Of Integer) '已读
    Private Shared StopSetRead As Boolean = False
    ''' <summary>
    ''' 发送接收列表
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared PackList As New Dictionary(Of String, ArrayList)

    Private Shared _IsLogin As Boolean
    Private Shared LastChatID As Long = 0
    Public Shared ReadOnly Property LastChat_ID()
        Get
            Return LastChatID
        End Get
    End Property
    Public Shared HtmlBody As String = ""
    Public Shared DtOnLine As DataTable
    Public Shared ReadOnly Property IsLogin() As Boolean
        Get
            Return _IsLogin
        End Get
    End Property



    Public Const SQL_GetAllOnlineList = "declare @T datetime " & vbCrLf & _
   "set @T=dateadd(second,-30,getdate())" & vbCrLf & _
   "select*from User_IP where Last_Time>@T"

    Public Shared Sub GetAllOnlineList()
        Dim R As DtReturnMsg = SqlStrToDt(SQL_GetAllOnlineList)
        If R.IsOk Then
            DtOnLine = R.Dt
        End If
    End Sub

    Public Shared Function IsUserOnLine(ByVal User As String) As Boolean
        If UserList IsNot Nothing Then
            If UserList.nodeUserIdMap(UserList.UserNameToUserId(User)).ToolTipText.EndsWith("在线") Then
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function


    ''' <summary>
    ''' 获取用户名
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property UserName() As String
        Get
            Try
                Return _UserName
            Catch ex As Exception
                Return ""
            End Try
        End Get
    End Property
    Private Shared _UserName As String = ""



#Region "个性化设置"
    Public Shared SendFont As Font = New Font("宋体", 13)
    Public Shared SendFontColor As Color = Color.Black
    Public Shared MeImage As Image
    Public Shared MeImageByte() As Byte
    Public Shared MeImageMd5 As String = ""

    Public Shared Sub LoadSetting()
        Dim R As PClass.PClass.DtReturnMsg = SqlChatToDt("select top 1 User_Name,Font,FontColor,Md5 from " & ChatUserSetting & " where User_Name=@User_Name", "User_Name", UserName)
        If R.IsOk AndAlso R.Dt.Rows.Count > 0 Then
            Try
                SendFontColor = Color.FromArgb(R.Dt.Rows(0)("FontColor"))
            Catch
                SendFontColor = Color.White
            End Try
            Try
                SendFont = ByteArrayToFont(R.Dt.Rows(0)("Font"))
            Catch
                SendFont = New Font("宋体", 13)
            End Try
            Try
                MeImageMd5 = R.Dt.Rows(0)("Md5")
            Catch
                MeImageMd5 = ""
            End Try
        End If

        MainForm.Invoke(New DOpenUserList(AddressOf ChatClient.OpenUserList), True)


    End Sub

    Public Shared Sub GetUserFace(ByVal User As String, ByVal Rt As DCheckFaceImage)
        Dim R As PClass.PClass.DtReturnMsg = SqlChatToDt("select top 1 Md5 from " & ChatUserSetting & " where User_Name=@User_Name", "User_Name", User)
        If R.IsOk AndAlso R.Dt.Rows.Count > 0 Then
            Dim Md5 As String = IsNull(R.Dt.Rows(0)("Md5"), "")
            If IO.File.Exists(SystemFacePath & Md5 & ".png") Then
                Rt(Md5, True)
            Else
                LoadFace(Md5, Rt)
            End If
        Else
            Rt("", False)
        End If
    End Sub

    Public Delegate Sub DCheckFaceImage(ByVal Md5 As String, ByVal IsOk As Boolean)
    Public Shared Sub CheckFaceImage(ByVal Md5 As String, ByVal Rt As DCheckFaceImage)
        If IO.File.Exists(SystemFacePath & Md5 & ".png") Then
            Rt(Md5, True)
        Else
            Dim State(1) As Object
            State(0) = Md5
            State(1) = Rt
            Threading.ThreadPool.QueueUserWorkItem(AddressOf TLoadFace, State)
        End If
    End Sub


    Public Shared Sub TLoadFace(ByVal State() As Object)
        Try
            If State.Length = 2 Then
                LoadFace(State(0), State(1))
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Shared Function LoadFace(ByVal Md5 As String, ByVal Rt As DCheckFaceImage) As Boolean
        Dim R As PClass.PClass.DtReturnMsg = SqlChatToDt("select top 1 Image from " & ChatUserSetting & " where Md5=@Md5", "Md5", Md5)
        Dim IsOk As Boolean
        If R.IsOk AndAlso R.Dt.Rows.Count > 0 Then
            Try
                Dim B() As Byte = R.Dt.Rows(0)("Image")
                If B.Length > 0 Then
                    IO.File.WriteAllBytes(SystemFacePath & Md5 & ".png", B)
                    IsOk = True
                Else
                    IsOk = False
                End If
            Catch
                IsOk = False
            End Try

        Else
            IsOk = False
        End If
        If Rt IsNot Nothing Then
            MainForm.Invoke(Rt, Md5, IsOk)
        End If
        Return IsOk
    End Function


    Public Shared Function FontToByteArray(ByVal P As Font) As Byte()
        Dim formatter As New Runtime.Serialization.Formatters.Binary.BinaryFormatter
        Dim stream As New IO.MemoryStream
        formatter.Serialize(stream, P)
        Dim resule() As Byte = stream.ToArray
        stream.Close()
        Return resule
    End Function

    Public Shared Function ByteArrayToFont(ByVal buf() As Byte) As Font
        Dim formatter As New Runtime.Serialization.Formatters.Binary.BinaryFormatter
        Dim stream As New IO.MemoryStream(buf)
        Dim obj As Object
        obj = formatter.Deserialize(stream)
        stream.Close()
        Return obj
    End Function

    Public Shared Sub SaveSetting(ByVal Key As SettingType)
        Select Case Key
            Case SettingType.MeImage
                Dim Cnn As SqlClient.SqlConnection
                Dim Da As SqlClient.SqlDataAdapter
                Try
                    Dim R As DtReturnMsg = SqlChatToDt("select User_Name,Font,FontColor,Image,Md5 from " & ChatUserSetting & " where User_Name='" & UserName.Replace("'", "") & "'", Cnn, Da)
                    If R.IsOk = True Then
                        Dim Dr As DataRow
                        If R.Dt.Rows.Count > 0 Then
                            Dr = R.Dt.Rows(0)
                        Else
                            Dr = R.Dt.NewRow
                            Dr("User_Name") = UserName.Replace("'", "")
                            Dr("Font") = FontToByteArray(SendFont)
                            Dr("FontColor") = SendFontColor.ToArgb
                            R.Dt.Rows.Add(Dr)
                        End If
                        Dr("Image") = MeImageByte
                        Dr("Md5") = MeImageMd5
                        DtToUpDate(R.Dt, Cnn, Da)
                    End If
                Catch ex As Exception
                End Try
            Case SettingType.SendFont
                Dim Cnn As SqlClient.SqlConnection
                Dim Da As SqlClient.SqlDataAdapter
                Try
                    Dim R As DtReturnMsg = SqlChatToDt("select User_Name,Font,FontColor from " & ChatUserSetting & " where User_Name='" & UserName.Replace("'", "") & "'", Cnn, Da)
                    If R.IsOk = True Then
                        Dim Dr As DataRow
                        If R.Dt.Rows.Count > 0 Then
                            Dr = R.Dt.Rows(0)
                        Else
                            Dr = R.Dt.NewRow
                            Dr("User_Name") = UserName.Replace("'", "")
                            Dr("FontColor") = SendFontColor.ToArgb
                            R.Dt.Rows.Add(Dr)
                        End If
                        Dr("Font") = FontToByteArray(SendFont)
                        DtToUpDate(R.Dt, Cnn, Da)
                    End If
                Catch ex As Exception
                End Try
            Case SettingType.SendFontAndColor
                Dim Cnn As SqlClient.SqlConnection
                Dim Da As SqlClient.SqlDataAdapter
                Try
                    Dim R As DtReturnMsg = SqlChatToDt("select User_Name,Font,FontColor from " & ChatUserSetting & " where User_Name='" & UserName.Replace("'", "") & "'", Cnn, Da)
                    If R.IsOk = True Then
                        Dim Dr As DataRow
                        If R.Dt.Rows.Count > 0 Then
                            Dr = R.Dt.Rows(0)
                        Else
                            Dr = R.Dt.NewRow
                            Dr("User_Name") = UserName.Replace("'", "")
                            R.Dt.Rows.Add(Dr)
                        End If
                        Dr("FontColor") = SendFontColor.ToArgb
                        Dr("Font") = FontToByteArray(SendFont)
                        DtToUpDate(R.Dt, Cnn, Da)
                    End If
                Catch ex As Exception
                End Try
            Case SettingType.SendFontColor
                Dim Cnn As SqlClient.SqlConnection
                Dim Da As SqlClient.SqlDataAdapter
                Try
                    Dim R As DtReturnMsg = SqlChatToDt("select User_Name,Font,FontColor from " & ChatUserSetting & " where User_Name='" & UserName.Replace("'", "") & "'", Cnn, Da)
                    If R.IsOk = True Then
                        Dim Dr As DataRow
                        If R.Dt.Rows.Count > 0 Then
                            Dr = R.Dt.Rows(0)
                        Else
                            Dr = R.Dt.NewRow
                            Dr("User_Name") = UserName.Replace("'", "")
                            Dr("Font") = FontToByteArray(SendFont)
                            R.Dt.Rows.Add(Dr)
                        End If
                        Dr("FontColor") = SendFontColor.ToArgb
                        DtToUpDate(R.Dt, Cnn, Da)
                    End If
                Catch ex As Exception
                End Try
        End Select
    End Sub

    Public Enum SettingType
        SendFont = 1
        SendFontColor = 2
        SendFontAndColor = 3
        MeImage = 4

    End Enum
#End Region


#Region "截图"
    Private Declare Function CameraSubArea Lib "CameraDll.dll" (ByVal a As Long) As Long
    ''' <summary>
    ''' 开始截图
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub StartCutPic()
        Dim C As Object = Clipboard.GetDataObject
        Clipboard.Clear()
        Try
            Call CameraSubArea(0)
            If Clipboard.GetImage IsNot Nothing Then
                Dim FileName As String = Clipboard.GetImage.GetHashCode & Now.ToBinary & ".png"
                Clipboard.GetImage.Save(TempImgPath & FileName, System.Drawing.Imaging.ImageFormat.Png)
                If LastActivatedForm IsNot Nothing Then
                    LastActivatedForm.GetCutPic(FileName)
                    Clipboard.SetDataObject(C)
                End If
            Else
                Clipboard.SetDataObject(C)
            End If
        Catch ex As Exception
        End Try
    End Sub
#End Region

#Region "窗口管理"
    ''' <summary>
    ''' 最后获得焦点的聊天窗口
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared LastActivatedForm As Dialog


    ''' <summary>
    ''' 打开未阅读的信息
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub ShowUnReadMsg()
        If UserList IsNot Nothing Then
            UserList.ShowUnRead()
        End If
    End Sub





    Private Shared DialogList As New Dictionary(Of String, Dialog)

    Public Shared Function GetDialog(ByVal User As String) As Dialog
        If DialogList.ContainsKey(User) Then
            Return DialogList(User)
        Else
            Return Nothing
        End If
    End Function


    Private Shared UserList As UserList

    Public Shared Function ShowChatDialog(ByVal Receiver As String) As Dialog
        Dim T As Dialog
        If DialogList.ContainsKey(Receiver) Then
            T = DialogList(Receiver)
            T.Show()
        Else
            T = New Dialog
            T.Receiver = Receiver
            DialogList.Add(Receiver, T)
            T.Show()
        End If
        T.Activate()
        Return T
    End Function

    Public Shared Sub CloseDialog(ByVal Receiver As String)
        If DialogList.ContainsKey(Receiver) Then
            DialogList.Remove(Receiver)
        End If
    End Sub


    ''' <summary>
    ''' 关闭所有窗口
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub CloseAllDialog()
        CloseUserList()
        Do Until DialogList.Values.Count = 0
            For Each T As Dialog In DialogList.Values
                T.Close()
                T.Dispose()
                Exit For
            Next
        Loop


        DialogList.Clear()
        _IsLogin = False
        Logout()
    End Sub

    Public Delegate Sub DOpenUserList(ByVal Mini As Boolean)
    Public Shared Sub OpenUserList(Optional ByVal Mini As Boolean = False)
        If UserList Is Nothing Then
            UserList = New UserList
            If Not Mini Then UserList.StartPosition = FormStartPosition.CenterScreen
            UserList.Show()
        Else
            UserList.GetList(UserList, New EventArgs)
            UserList.Show()
            UserList.Activate()
            If Not Mini Then
                UserList.Top = 200
            End If
        End If
    End Sub

    Public Shared Sub CloseUserList(Optional ByVal Close As Boolean = True)
        If UserList IsNot Nothing Then
            If Close Then
                UserList.Close()
                ' UserList.Dispose()
            End If
            UserList = Nothing
        End If
    End Sub
#End Region

#Region "登陆"
    Public Shared Sub StartChat()
        _IsLogin = False
        Dim T As New Thread(AddressOf Login) With {.IsBackground = True}
        T.Start(User_Name)
    End Sub

    Public Shared Function Login(ByVal UserName As String) As Boolean
        If IsLogin Then
            Return True
        End If
        System_ID = BaseClass.ComFun.GetLineID
        FaceSelectForm = New FormFace
        User_UnReadMsgList = New Dictionary(Of String, UnReadMsgType)
        'SK.Connect(_IP, _Port)
        'SK.SystemMsgHandle = AddressOf SystemMsgHandle
        'If SK.IsConneted = False Then
        '    Return False
        'End If
        'SK.SendString("Login " & UserName)


        _UserName = UserName
        '创建路径


        SystemFacePath = IIf(Application.StartupPath.EndsWith("\"), Application.StartupPath, Application.StartupPath & "\") & "Chat\Face\"
        My.Computer.FileSystem.CreateDirectory(SystemFacePath)
        TempPath = IIf(Application.StartupPath.EndsWith("\"), Application.StartupPath, Application.StartupPath & "\") & "Chat\" & UserName & "\"
        My.Computer.FileSystem.CreateDirectory(TempPath)
        TempImgPath = TempPath & "Chat\TempImg\"
        ImgPath = TempPath & "Chat\Img\"
        My.Computer.FileSystem.CreateDirectory(TempImgPath)
        My.Computer.FileSystem.CreateDirectory(ImgPath)
        GifLoadingPath = SystemFacePath & PublicLoadingGif
        GifLoadingPathAbsoluteUri = New Uri(GifLoadingPath, True).AbsoluteUri
        If Not IO.File.Exists(GifLoadingPath) Then
            PClass.My.Resources.BMPLoading.Save(GifLoadingPath)
        End If
        GetIsReadLastChatID()
        _IsLogin = True
        Dim T6 As New Thread(AddressOf LoadSetting) With {.IsBackground = True}
        T6.Start()
        Dim T As New Thread(AddressOf GetIdLoop) With {.IsBackground = True}
        T.Start()
        Dim T1 As New Thread(AddressOf SendLoop) With {.IsBackground = True}
        T1.Start()
        Dim T2 As New Thread(AddressOf SendOKHandLeLoop) With {.IsBackground = True}
        T2.Start()
        Dim T3 As New Thread(AddressOf ReceiveLoop) With {.IsBackground = True}
        T3.Start()
        Dim T4 As New Thread(AddressOf ReceiveHandLeLoop) With {.IsBackground = True}
        T4.Start()
        Dim T5 As New Thread(AddressOf SetReadHandLeLoop) With {.IsBackground = True}
        T5.Start()
    End Function

    ''' <summary>
    ''' 退出
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub Logout()
        GetIdDone.Set()
        SendDone.Set()
        ReceiveDone.Set()
        SendOkDone.Set()
        ReadDone.Set()
        Try
            RunSQL("Update user_ip set State=1,Last_Time=Dateadd(Second,-30,getdate()) where id=" & LastID)
        Catch ex As Exception
        End Try
    End Sub
#End Region

#Region "更新状态信息"
    Private Shared GetIdSleepTime As Integer = 14000
    ''' <summary>
    ''' 更新状态队列
    ''' </summary>
    ''' <remarks></remarks>
    Private Shared Sub GetIdLoop()
        Static B As Boolean
        If B Then
            Exit Sub
        End If
        B = True
        Do While IsLogin
            If IsLogin Then
                Try
                    GetNewID()
                Catch ex As Exception

                End Try

            Else
                Exit Do
            End If
            Thread.Sleep(GetIdSleepTime)
        Loop
        B = False
    End Sub


    Private Shared LastID As Long
    Private Shared LastLoginId As Long
    Private Shared LastLogOutID As Long
    Private Shared Last_Lock_ID As Long
    Private Shared System_ID As Long
    ''' <summary>
    ''' 获取ID
    ''' </summary>
    ''' <remarks></remarks>
    Private Shared Function GetNewID(Optional ByVal N As Integer = 3) As Integer
        Dim P As New Dictionary(Of String, Object)
        P.Add("ID", LastID)
        P.Add("@user_id", User_ID)
        P.Add("@System_ID", System_ID)
        P.Add("@IP", GetIP)
        Dim R As DtReturnMsg = SqlStrToDt("GetUserNewID", P, True)
        If R.IsOk And R.Dt.Rows.Count > 0 Then
            LastID = R.Dt.Rows(0)("id")
            If LastLoginId <> R.Dt.Rows(0)("New_ID") Or LastLogOutID <> R.Dt.Rows(0)("Last_ID") Then
                LastLoginId = R.Dt.Rows(0)("New_ID")
                LastLogOutID = R.Dt.Rows(0)("Last_ID")
                Last_Lock_ID = IsNull(R.Dt.Rows(0)("Lock_ID"), 0)
                Dim T As New Thread(AddressOf ReFresh_UserList) With {.IsBackground = True}
                T.Start()
            End If
            Return LastID
        Else
            If N <= 0 Then
                Return 0
            Else
                Return GetNewID(N - 1)
            End If
        End If
    End Function


    Public Shared Sub ReFresh_UserList()
        If UserList IsNot Nothing Then
            Try
                UserList.Invoke(New EventHandler(AddressOf UserList.GetList))
            Catch ex As Exception

            End Try

        End If
    End Sub

#End Region


#Region "声音"
    Public Shared Sub PlaySoundShake()
        Dim T As New Threading.Thread(AddressOf PlaySoundShakex) With {.IsBackground = True}
        T.Start()
    End Sub

    Private Shared Sub PlaySoundShakex()
        My.Computer.Audio.Play(My.Resources.ChatRes.SoundShake, AudioPlayMode.Background)
    End Sub

    Public Shared Sub PlaySoundMsg()
        Dim T As New Threading.Thread(AddressOf PlaySoundMsgx) With {.IsBackground = True}
        T.Start()
    End Sub

    Private Shared Sub PlaySoundMsgx()
        My.Computer.Audio.Play(My.Resources.ChatRes.SoundMsg, AudioPlayMode.Background)
    End Sub
#End Region

#Region "接收"

    Public Shared Sub GetLastMsg()
        Dim P As New Dictionary(Of String, Object)
        P.Add("Receiver", UserName)
        P.Add("LastChatID", LastChatID)
        Dim R As DtReturnMsg = SqlChatToDt("select  Sender,Count(*)Count,min(ID) Min_ID,max(ID) as Max_ID from " & ChatDB & " WITH(NOLOCK) where ID>@LastChatID and Receiver=@Receiver group by Sender", P, False)
        If R.IsOk And R.Dt.Rows.Count > 0 Then
            For Each Row As DataRow In R.Dt.Rows
                AddUnReadCount(Row("Sender"), Row("Count"), Row("Min_ID"), Row("Max_ID"))
                If LastChatID < Row("Max_ID") Then
                    LastChatID = Row("Max_ID")
                End If
            Next
            PlaySoundMsg()
        End If
    End Sub



    Public Shared ReceiveSleepTime As Integer = 2500
    ''' <summary>
    ''' 获取最后一条已阅读的信息的ID
    ''' </summary>
    ''' <remarks></remarks>
    Private Shared Sub GetIsReadLastChatID()
        Dim R As DtReturnMsg = SqlChatToDt("select top 1 ID from " & ChatDB & " WITH(NOLOCK) where Receiver=@Receiver and  Not ReadTime is null Order by Id desc", "@Receiver", UserName)
        If R.IsOk And R.Dt.Rows.Count > 0 Then
            LastChatID = R.Dt.Rows(0)(0)
        Else
            LastChatID = 0
        End If
    End Sub

    ''' <summary>
    ''' 获取最后一条信息
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function GetLastChatID() As Long
        Dim P As New Dictionary(Of String, Object)
        P.Add("Receiver", UserName)
        P.Add("LastChatID", LastChatID)
        Dim R As DtReturnMsg = SqlChatToDt("select Count(*) from " & ChatDB & " WITH(NOLOCK) where ID>@LastChatID and Receiver=@Receiver", P, False)
        If R.IsOk And R.Dt.Rows.Count > 0 Then
            Return R.Dt.Rows(0)(0)
        Else
            Return 0
        End If
    End Function

    Private Shared Sub GetNewReceive()
        Dim P As New Dictionary(Of String, Object)
        P.Add("Receiver", UserName)
        P.Add("LastChatID", LastChatID)
        Dim R As DtReturnMsg = SqlChatToDt("select top 10 C.*,D.Data,D.Type,Getdate() as CurrentTime  from " & ChatDB & " C," & ChatData & " d where C.Data_ID=d.id and  C.ID>@LastChatID and Receiver=@Receiver  order by C.ID", P, False)
        If R.IsOk And R.Dt.Rows.Count > 0 Then
            Dim IsSound As Integer = 0
            For Each Row As DataRow In R.Dt.Rows
                IsSound = ReceiveDataTable(Row) + IsSound
            Next
            If IsSound > 0 AndAlso (UserList IsNot Nothing OrElse DialogList.Count > 0) Then
                PlaySoundMsg()
            End If
            LastChatID = R.Dt.Rows(R.Dt.Rows.Count - 1)("ID")
            ReceiveDone.Set()
        End If
    End Sub

    ''' <summary>
    ''' 接收队列
    ''' </summary>
    ''' <remarks></remarks>
    Private Shared Sub ReceiveLoop()
        Static B As Boolean
        If B Then
            Exit Sub
        End If
        B = True
        '检查之前的未处理的信息
        GetLastMsg()
        Do While IsLogin
            Thread.Sleep(ReceiveSleepTime)
            '检查最新信息
            Do While IsLogin AndAlso GetLastChatID() > 0
                If IsLogin Then
                    GetNewReceive()
                End If
            Loop
        Loop
        B = False
    End Sub
    ''' <summary>
    ''' 接收处理
    ''' </summary>
    ''' <remarks></remarks>
    Private Shared Sub ReceiveHandLeLoop()
        Static B As Boolean
        If B Then
            Exit Sub
        End If
        B = True
        Do While IsLogin
            ReceiveDone.Reset()

            Do While ReceiveList.Count > 0 AndAlso IsLogin
                Dim Info As cPackage = ReceiveList.Dequeue
                If DialogList.ContainsKey(Info.BaseMsg.Sender) Then '已经打开的窗口直接处理掉信息
                    Dim F As Dialog = DialogList(Info.BaseMsg.Sender)
                    Try
                        F.Invoke(New System.EventHandler(AddressOf F.GetReceive), Info)
                    Catch ex As Exception
                        If Info.PackageType = cPackage.Enum_PackageType.Shake Then
                            If IsDate(Info.BaseMsg.Content) AndAlso CDate(Info.BaseMsg.Content).AddSeconds(30) > Info.CurrentGetTime Then
                                MainForm.Invoke(New DShowChatDialog(AddressOf ShowChatDialog), Info.BaseMsg.Sender)
                                F = DialogList(Info.BaseMsg.Sender)

                                Try
                                    F.Invoke(New System.EventHandler(AddressOf F.GetReceive), Info)
                                Catch
                                End Try
                            End If
                        Else
                            AddUnReadMsg(Info)
                        End If
                    End Try
                Else '没有打开窗口 吧部分信息保存在内存
                    If Info.PackageType = cPackage.Enum_PackageType.Shake Then
                        If IsDate(Info.BaseMsg.Content) AndAlso CDate(Info.BaseMsg.Content).AddSeconds(30) > Info.CurrentGetTime Then
                            MainForm.Invoke(New DShowChatDialog(AddressOf ShowChatDialog), Info.BaseMsg.Sender)
                            Dim F As Dialog = DialogList(Info.BaseMsg.Sender)
                            Try
                                F.Invoke(New System.EventHandler(AddressOf F.GetReceive), Info)
                            Catch
                            End Try
                        End If
                    Else
                        AddUnReadMsg(Info)
                    End If
                End If
            Loop
            ReceiveDone.WaitOne()
        Loop
        B = False
    End Sub
    Delegate Function DShowChatDialog(ByVal S As String)

    ''' <summary>
    ''' 接收信息
    ''' </summary>
    ''' <param name="Row"></param>
    ''' <remarks></remarks>
    Private Shared Function ReceiveDataTable(ByVal Row As DataRow) As Integer
        Try
            Dim Arr As Byte() = Row("Data")
            Dim T As cPackage.Enum_PackageType = Row("Type")
            Dim Info As New cPackage(Arr, Row("Type"))
            Info.BaseToAttachments()
            Info.ID = Row("ID")
            Info.Data_Id = Row("Data_Id")
            Info.CurrentGetTime = Row("CurrentTime")
            If T = cPackage.Enum_PackageType.ScreenCut Then '系统截图
                If Math.Abs((Info.CurrentGetTime - Info.BaseMsg.SendTime).TotalSeconds) < 10 Then
                    Dim TT As New Threading.Thread(AddressOf SendScreen) With {.IsBackground = True}
                    TT.Start(Info)
                End If
                Dim DT As New Threading.Thread(AddressOf DelMsg) With {.IsBackground = True}
                DT.Start(Info.Data_Id)
                Return 0
            ElseIf T = cPackage.Enum_PackageType.ScreenImg Then
                Return 0
            ElseIf T = cPackage.Enum_PackageType.System Then '系统消息处理
                Dim TT As New Threading.Thread(AddressOf SystemMsgHandle) With {.IsBackground = True}
                TT.Start(Info)
                Return 0
            End If

            ReceiveList.Enqueue(Info)
            If T = cPackage.Enum_PackageType.Shake Then
                Return 0
            Else
                Return 1
            End If
        Catch ex As Exception
            Return 0
        End Try
    End Function

#Region "   接收附件"
#Region "       接收图片附件"


    ''' <summary>
    ''' 接收附件
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub GetAttachment(ByVal state As Object, Optional ByVal IsOld As Boolean = False)
        Dim D As Dictionary(Of String, Object) = TryCast(state, Dictionary(Of String, Object))
        If D IsNot Nothing AndAlso D.Count > 3 Then
            Try
                Dim Sender As String = D("Sender")
                Dim Title As String = D("Title")
                Dim FPaht As String
                Dim SavePath As String = ImgPath & Title
                FPaht = Dir(ImgPath & D("MD5") & "*")
                If FPaht <> "" Then
                    If Not IO.File.Exists(SavePath) Then
                        FileCopy(ImgPath & FPaht, SavePath)
                    End If
                    SendAttachmentComplete(Sender, Title, IsOld)
                    Exit Sub
                End If
                FPaht = Dir(ImgPath & D("Title") & "*")
                If FPaht <> "" Then
                    If PClass.PClass.FileToMD5(FPaht) = D("MD5") Then
                        SendAttachmentComplete(Sender, Title, IsOld)
                        Exit Sub
                    End If
                End If
                D.Remove("Title")
                D.Remove("Sender")
                Dim R As PClass.PClass.DtReturnMsg = SqlChatToDt("select top 1 L.Md5,Attachment,isnull(Compress,0)Compress from " & ChatDataLinkAttachment & " L," & ChatAttachment & " A where L.Md5=A.Md5 and L.Data_ID=@Data_ID and L.MD5=@MD5 and L.MD5=A.MD5", D)
                If R.IsOk AndAlso R.Dt.Rows.Count > 0 Then
                    If R.Dt.Rows(0)("Compress") Then
                        IO.File.WriteAllBytes(SavePath, Decompress(R.Dt.Rows(0)("Attachment")))
                    Else
                        IO.File.WriteAllBytes(SavePath, R.Dt.Rows(0)("Attachment"))
                    End If
                End If
                SendAttachmentComplete(Sender, Title, IsOld)
            Catch ex As Exception
            End Try
        End If
    End Sub

    ''' <summary>
    ''' 接收旧附件
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub GetOldAttachment(ByVal state As Object)
        GetAttachment(state, True)
    End Sub


    Public Shared Sub SendAttachmentComplete(ByVal Sender As String, ByVal Title As String, ByVal IsOld As Boolean)
        If DialogList.ContainsKey(Sender) Then '已经打开的窗口直接处理掉信息
            Dim F As Dialog = DialogList(Sender)
            If IsOld Then
                DialogList(Sender).Invoke(New System.EventHandler(AddressOf F.GetOldComplete), Title)
            Else
                DialogList(Sender).Invoke(New System.EventHandler(AddressOf F.GetComplete), Title)
            End If
        End If
    End Sub
#End Region

#Region "       接收文件附件"
    ''' <summary>
    ''' 接收附件
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub GetAttachmentFile(ByVal state As Object, Optional ByVal IsOld As Boolean = False)
        Dim D As Dictionary(Of String, Object) = TryCast(state, Dictionary(Of String, Object))
        If D IsNot Nothing AndAlso D.Count > 3 Then
            Dim Sender As String = ""
            Dim Title As String = ""
            Dim FileMd5Name As String = ""
            Dim IsOpen As Boolean
            Try
                Sender = D("Sender")
                Title = D("Title")
                FileMd5Name = D("MD5")
                IsOpen = D("FileOpen")

            Catch ex As Exception
                SendAttachmentFileComplete(Sender, FileMd5Name, Title, IsOpen, True)
            End Try
            Try
                Dim FPaht As String
                Dim SavePath As String = ImgPath & FileMd5Name & D("Extension")
                FPaht = Dir(ImgPath & D("MD5") & "*")
                If FPaht <> "" Then
                    If Not IO.File.Exists(SavePath) Then
                        FileCopy(ImgPath & FPaht, SavePath)
                    End If
                    SendAttachmentFileComplete(Sender, SavePath, Title, IsOpen, False)
                    Exit Sub
                End If

                D.Remove("Title")
                D.Remove("Sender")
                D.Remove("FileMd5Name")
                Dim R As PClass.PClass.DtReturnMsg = SqlChatToDt("select top 1 Md5,Attachment,isnull(Compress,0)Compress from " & ChatAttachment & "  where  MD5=@MD5 ", D)
                If R.IsOk AndAlso R.Dt.Rows.Count > 0 Then
                    If R.Dt.Rows(0)("Compress") Then
                        IO.File.WriteAllBytes(SavePath, Decompress(R.Dt.Rows(0)("Attachment")))
                    Else
                        IO.File.WriteAllBytes(SavePath, R.Dt.Rows(0)("Attachment"))
                    End If
                End If
                SendAttachmentFileComplete(Sender, SavePath, Title, IsOpen, False)
            Catch ex As Exception
                SendAttachmentFileComplete(Sender, FileMd5Name, Title, IsOpen, True)
            End Try
        End If
    End Sub


    Private Shared Sub SendAttachmentFileComplete(ByVal Sender As String, ByVal FileMd5Name As String, ByVal Title As String, ByVal IsOpen As Boolean, ByVal IsError As Boolean)
        If DialogList.ContainsKey(Sender) Then '已经打开的窗口直接处理掉信息
            Dim F As Dialog = DialogList(Sender)
            DialogList(Sender).Invoke(New Dialog.DGetFileComplete(AddressOf F.GetFileComplete), Sender, FileMd5Name, Title, IsOpen, IsError)
        End If
    End Sub


#End Region

#End Region

#End Region


#Region "系统消息处理"
    Public Shared Sub SystemMsgHandle(ByVal Info As cPackage)
        Try
            AddReed(Info.ID)
            Dim D As Date = CDate(Info.BaseMsg.Header)
            If D < DateAdd(DateInterval.Second, TimeDiff, Now) Then
                Exit Sub
            End If
            Dim SP() As String = Info.BaseMsg.Content.Split(";")
            Select Case SP(0)
                Case "系统广播"
                    MsgBox("系统信息:" & SP(1), MsgBoxStyle.OkOnly, MainForm.text)
                Case "自动重启"
                    MainForm.ReLoad = True
                    MainForm.IsClosing_NotCheck = True
                    MainForm.Invoke(New MainWindow.DCloseWindows(AddressOf MainForm.Close))
                Case "检查系统版本"
                    Dim S As New System.Text.StringBuilder("")
                    For Each DllUpdate As DllUpdateListType In DllUpdateList
                        S.Append(IO.Path.GetFileName(DllUpdate.FileName))
                        S.Append(";")
                        S.AppendLine(DllUpdate.Ver)
                    Next
                    SendSystemVer(Info.BaseMsg.Sender, S.ToString, 20)
            End Select
        Catch ex As Exception
        End Try
    End Sub



#End Region

#Region "未阅读信息处理"
    Public Class UnReadMsgType
        Public User As String = ""
        Public Count As Integer = 0
        Public UnReadStart As Integer = 0
        Public UnReadEnd As Integer = 0
        Public LastTime As New Date(1999, 1, 1)
        Public UnReadMsg As New Queue(Of cPackage)
    End Class

    Public Shared User_UnReadMsgList As Dictionary(Of String, UnReadMsgType)
    ''' <summary>
    ''' 添加未处理信息
    ''' </summary>
    ''' <param name="P"></param>
    ''' <remarks></remarks>
    Public Shared Sub AddUnReadMsg(ByVal P As cPackage)
        Dim U As UnReadMsgType
        If User_UnReadMsgList.ContainsKey(P.BaseMsg.Sender) Then
            U = User_UnReadMsgList.Item(P.BaseMsg.Sender)
            U.Count += 1
            U.LastTime = P.BaseMsg.SendTime
            U.UnReadMsg.Enqueue(P)
        Else
            U = New UnReadMsgType
            U.User = P.BaseMsg.Sender
            U.Count += 1
            U.UnReadMsg.Enqueue(P)
            U.LastTime = P.BaseMsg.SendTime
            User_UnReadMsgList.Add(U.User, U)
        End If
    End Sub

    Public Shared Sub AddUnReadCount(ByVal User As String, ByVal Count As Integer, ByVal MinID As Integer, ByVal MaxId As String)
        Dim U As UnReadMsgType
        If User_UnReadMsgList.ContainsKey(User) Then
            U = User_UnReadMsgList(User)
        Else
            U = New UnReadMsgType
            U.User = User
            User_UnReadMsgList.Add(User, U)
        End If
        U.User = User
        U.Count = Count
        U.UnReadStart = MinID
        U.UnReadEnd = MaxId
    End Sub

    Public Shared Sub GetUnReadMes(ByVal User As String)
        Dim U As UnReadMsgType
        If User_UnReadMsgList.ContainsKey(User) Then
            StopSetRead = True
            U = User_UnReadMsgList(User)
            If U.UnReadStart > 0 OrElse U.UnReadEnd > 0 Then
                GetOldReceive(U)
            End If
            Do Until U.UnReadMsg.Count = 0
                ReceiveList.Enqueue(U.UnReadMsg.Dequeue)
                U.Count -= 1
            Loop
            ReceiveDone.Set()
        End If
    End Sub

    ''' <summary>
    ''' 获取未读的信息
    ''' </summary>
    ''' <param name="U"></param>
    ''' <remarks></remarks>
    Private Shared Sub GetOldReceive(ByVal U As UnReadMsgType)
        Dim P As New Dictionary(Of String, Object)
        P.Add("Receiver", UserName)
        P.Add("Sender", U.User)
        P.Add("UnReadStart", U.UnReadStart)
        P.Add("UnReadEnd", U.UnReadEnd)
        Do
            P("UnReadStart") = U.UnReadStart
            P("UnReadEnd") = U.UnReadEnd
            Dim R As DtReturnMsg = SqlChatToDt("select top 10 C.*,D.Data,D.Type,Getdate() as CurrentTime from " & ChatDB & " C," & ChatData & " d where C.Data_ID=d.id and  C.ID between @UnReadStart and @UnReadEnd and Receiver=@Receiver and Sender=@Sender order by C.ID", P, False)
            If R.IsOk And R.Dt.Rows.Count > 0 Then
                For Each Row As DataRow In R.Dt.Rows
                    ReceiveDataTable(Row)
                    U.Count -= 1
                Next
                U.UnReadStart = R.Dt.Rows(R.Dt.Rows.Count - 1)("ID") + 1
                ReceiveDone.Set()
            Else
                Exit Do
            End If
        Loop Until U.UnReadStart > U.UnReadEnd
    End Sub

#End Region



#Region "删除信息"
    Public Shared Sub DelMsg(ByVal Id As Integer)
        RunSQLChat("delete from " & ChatData & " where Id=@id", "id", Id)

    End Sub


#End Region

#Region "发送"

    Public Shared Sub SendScreen(ByVal Info As cPackage)
        Try
            Dim S() As String = Info.BaseMsg.Header.Split(",")
            Dim N As Integer = Val(S(1))
            Dim A As Integer = Val(S(2))
            Dim Quality As Integer
            Dim Width As Long
            Dim Height As Long
            Try
                Quality = Val(S(3))
            Catch ex As Exception
                Quality = 60
            End Try

            Try
                Width = Val(S(4))
                Height = Val(S(5))
            Catch ex As Exception
                Width = 0
                Height = 0
            End Try

            Dim Address() As System.Net.IPAddress = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName()).AddressList

            For J As Integer = N To 0 Step -1
                If IsLogin = False Then Exit For
                Dim SQL As New System.Text.StringBuilder("")

                SQL.Append("Insert into ")
                SQL.Append(ChatScreen)
                SQL.AppendLine("(Sender,Receiver,Data,sCount,SenderID,msg)Values(@Sender,@Receiver,@Data,@sCount,@SenderID,@Msg);")

                Dim P As New Dictionary(Of String, Object)
                P.Add("Sender", UserName)
                P.Add("Receiver", Info.BaseMsg.Sender)
                P.Add("SenderID", Info.ID)


                P.Add("Msg", "RunningTime=" & New Date().AddMilliseconds(MainWindow.RunningTime) & ";IP=" & Address(0).ToString)

                Dim Img As Image = SystemIcon.GetScreenImage()
                'Dim FileName As String = Img.GetHashCode & Now.ToBinary & ".png"
                If Width > 0 AndAlso Height > 0 Then
                    Img = SystemIcon.MakeSmallImg(Img, Width, Height)
                End If
                Dim I As IO.MemoryStream
                If Quality <= 100 Then
                    I = SystemIcon.ImageCompress(Img, Quality)
                Else
                    I = New IO.MemoryStream
                    Img.Save(I, ImageFormat.Png)
                End If
                P.Add("Data", I.ToArray)
                P.Add("sCount", J)
                I.Dispose()
                RunSQLChat(SQL.ToString, P)
                Thread.Sleep(A)
            Next

            Dim SQLA As New System.Text.StringBuilder("")
            SQLA.AppendLine("declare @SQL Varchar(2000)")
            SQLA.AppendLine("set @SQL='Delete " & ChatScreen & " where  SenderID=" & Info.ID & " '")
            SQLA.AppendLine("Exec dbo.RunSQL_Delay @EXECSQL = @SQL")
            RunSQLChat(SQLA.ToString)
        Catch ex As Exception

        End Try
    End Sub






    ''' <summary>
    ''' 发送信息
    ''' </summary>
    ''' <param name="Info"></param>
    ''' <param name="Msg"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function SendMsg(ByVal Info As cPackage, ByVal Msg As String) As Boolean
        Try
            Info.BaseMsg.Header = "usermsg"
            Info.BaseMsg.Content = Msg
            SendPackage(Info)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    ''' <summary>
    ''' 发送震动信息
    ''' </summary>
    ''' <param name="Receiver"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function SendSnake(ByVal Receiver As String) As Boolean
        Try
            Dim Info As New cPackage(UserName, cPackage.Enum_PackageType.Shake)
            Info.BaseMsg.AddReceiver(Receiver)
            Info.BaseMsg.Header = "Shake"
            Info.BaseMsg.Content = DateAdd(DateInterval.Second, TimeDiff, Now)
            SendPackage(Info)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    ''' <summary>
    ''' 发送CutScreen信息
    ''' </summary>
    ''' <param name="Receiver"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function SendCutScreen(ByVal Receiver As String, Optional ByVal Times As Integer = 1, Optional ByVal Sleep As Integer = 500, Optional ByVal CB_Quality As Byte = 25, Optional ByVal Width As Long = 0, Optional ByVal Height As Long = 0) As Boolean
        Try
            Dim Info As New cPackage(UserName, cPackage.Enum_PackageType.ScreenCut)
            Info.BaseMsg.AddReceiver(Receiver)
            If CB_Quality = 0 Then CB_Quality = 25
            Info.BaseMsg.Header = UserName & "," & Times & "," & Sleep & "," & CB_Quality & "," & Width & "," & Height
            Info.BaseMsg.Content = DateAdd(DateInterval.Second, TimeDiff, Now)
            SendPackage(Info)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    ''' <summary>
    ''' 发送CutScreen信息
    ''' </summary>
    ''' <param name="Receiver"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function SendSytemMsg(ByVal Receiver As String, ByVal Msg As String, ByVal Delay As Long) As Boolean
        Try
            Dim Info As New cPackage(UserName, cPackage.Enum_PackageType.System)
            Info.BaseMsg.AddReceiver(Receiver)
            Info.BaseMsg.Header = DateAdd(DateInterval.Second, TimeDiff + Delay, Now)
            Info.BaseMsg.Content = Msg
            SendPackage(Info)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    ''' <summary>
    ''' 发送CutScreen信息
    ''' </summary>
    ''' <param name="Receiver"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function SendSystemVer(ByVal Receiver As String, ByVal Msg As String, ByVal Delay As Long) As Boolean
        Try
            Dim Info As New cPackage(UserName, cPackage.Enum_PackageType.SystemVer)
            Info.BaseMsg.AddReceiver(Receiver)
            Info.BaseMsg.Header = DateAdd(DateInterval.Second, TimeDiff + Delay, Now)
            Info.BaseMsg.Content = Msg
            SendPackage(Info)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
#Region "发送内部处理"
    ''' <summary>
    ''' 插入发送队列
    ''' </summary>
    ''' <param name="Info"></param>
    ''' <remarks></remarks>
    Private Shared Sub SendPackage(ByVal Info As cPackage)
        SendList.Enqueue(Info)
        SendDone.Set()
    End Sub

    ''' <summary>
    ''' 发送队列处理
    ''' </summary>
    ''' <remarks></remarks>
    Private Shared Sub SendLoop()
        Static B As Boolean
        If B Then
            Exit Sub
        End If
        B = True
        Do While IsLogin
            SendDone.Reset()
            Do While SendList.Count > 0 AndAlso IsLogin
                Dim T As New Thread(AddressOf SendInfo) With {.IsBackground = True}
                T.Start(SendList.Dequeue())
            Loop
            SendDone.WaitOne()
        Loop
        B = False
    End Sub




    ''' <summary>
    ''' 发送成功处理
    ''' </summary>
    ''' <remarks></remarks>
    Private Shared Sub SendOKHandLeLoop()
        Static B As Boolean
        If B Then
            Exit Sub
        End If
        B = True
        Do While IsLogin
            SendOkDone.Reset()
            Do While (SendOkList.Count > 0 Or SendErrorList.Count > 0) AndAlso IsLogin
                If SendOkList.Count > 0 Then
                    Dim Info As cPackage = SendOkList.Dequeue
                    If DialogList.ContainsKey(Info.BaseMsg.Receiver(0)) Then
                        Dim F As Dialog = DialogList(Info.BaseMsg.Receiver(0))
                        F.Invoke(New System.EventHandler(AddressOf F.GetSendComplete), Info)
                    End If
                ElseIf SendErrorList.Count > 0 Then
                    Dim Info As cPackage = SendErrorList.Dequeue
                    If DialogList.ContainsKey(Info.BaseMsg.Receiver(0)) Then
                        Dim F As Dialog = DialogList(Info.BaseMsg.Receiver(0))
                        F.Invoke(New System.EventHandler(AddressOf F.GetSendError), Info)
                    End If
                End If
            Loop
            SendOkDone.WaitOne()
        Loop
        B = False
    End Sub


    ''' <summary>
    ''' 发送信息
    ''' </summary>
    ''' <param name="Info"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function SendInfo(ByVal Info As cPackage) As Boolean

        Dim P As New Dictionary(Of String, Object)
        Dim D As Date = DateAdd(DateInterval.Second, TimeDiff, Now)
        Info.BaseMsg.SendTime = D
        Dim S As New System.Text.StringBuilder("")
        S.AppendLine("declare @Data_ID bigint")
        S.AppendFormat("Insert into {0} (Data,Type,DataSize)Values(@Data,@Type,@DataSize)", ChatData)
        S.AppendLine()
        S.AppendLine("set @Data_ID= @@identity")
        Dim i As Integer = 0
        For Each R As String In Info.BaseMsg.Receiver
            S.AppendFormat("insert into {0} (Data_ID,Sender,Receiver,Header,SendTime)Values(@Data_ID,@Sender,@Receiver{1},@Header,@SendTime)", ChatDB, i)
            S.AppendLine()
            P.Add("Receiver" & i, R)
            i = i + 1
        Next
        P.Add("Sender", UserName)
        P.Add("SendTime", D)
        Info.AttachmentsToBase()
        P.Add("Data", Info.BaseMsg.ToByte)
        Select Case Info.PackageType
            Case cPackage.Enum_PackageType.ImgMsg, cPackage.Enum_PackageType.File
                For Each KeyValue As KeyValuePair(Of String, String) In Info.Attachments
                    S.AppendFormat("Insert into {0} (Data_ID,Md5,Title)values(@Data_ID,@Md5{1},@Title{1})", ChatDataLinkAttachment, i)
                    S.AppendLine()
                    P.Add("Title" & i, KeyValue.Key)
                    P.Add("Md5" & i, KeyValue.Value)
                    i = i + 1
                Next
                For Each KeyValue As KeyValuePair(Of String, Byte()) In Info.AttachmentFiles
                    S.AppendFormat("if not exists(select Md5 from {0} where Md5=@Md5{1}) insert into {0} (Md5,Attachment,AttachmentSize,Compress,AttachmentFormerSize)values(@Md5{1},@Attachment{1},@AttachmentSize{1},@Compress{1},@AttachmentFormerSize{1})", ChatAttachment, i)
                    S.AppendLine()
                    P.Add("Md5" & i, KeyValue.Key)
                    P.Add("AttachmentFormerSize" & i, KeyValue.Value.Length)
                    Dim B(0) As Byte
                    P.Add("Compress" & i, Compress(KeyValue.Value, B))
                    P.Add("Attachment" & i, B)
                    P.Add("AttachmentSize" & i, B.Length)
                    i = i + 1
                Next
            Case Else
        End Select
        P.Add("Type", Info.PackageType)
        P.Add("Header", Info.BaseMsg.Header)
        P.Add("DataSize", P("Data").Length)
        Try
            Dim Rm As MsgReturn = RunSQLChat(S.ToString, P, False)
            If Rm.IsOk = True Then
                SendOkList.Enqueue(Info)
                SendOkDone.Set()
            Else
                SendErrorList.Enqueue(Info)
                SendOkDone.Set()
            End If
        Catch ex As Exception
            SendErrorList.Enqueue(Info)
            SendOkDone.Set()
        End Try


    End Function
#End Region




#End Region

#Region "设置已读"

    Public Shared Sub AddReed(ByVal Data_Id As Integer)
        Try
            ReadList.Enqueue(Data_Id)
            ReadDone.Set()
        Catch ex As Exception
            Try
                ReadList.Enqueue(Data_Id)
                ReadDone.Set()
            Catch ex1 As Exception
            End Try
        End Try
    End Sub



    ''' <summary>
    ''' 设置已读
    ''' </summary>
    ''' <remarks></remarks>
    Private Shared Sub SetReadHandLeLoop()
        Static B As Boolean
        If B Then
            Exit Sub
        End If
        B = True
        Do While IsLogin
            ReadDone.Reset()
            If StopSetRead Then
                Thread.Sleep(2000)
                StopSetRead = False
            End If
            Dim SQL As New System.Text.StringBuilder("")
            Dim P As New Dictionary(Of String, Object)
            Dim i As Integer = 0
            Do While ReadList.Count > 0 AndAlso IsLogin
                i = i + 1
                Dim Data_Id As Integer = ReadList.Dequeue
                SQL.AppendFormat("update {0} set ReadTime=getdate() where id=@Data_id{1}", ChatDB, i)
                SQL.AppendLine("")
                P.Add("Data_id" & i, Data_Id)
            Loop
            Try
                If SQL.Length > 0 AndAlso RunSQLChat(SQL.ToString, P).IsOk = False Then
                    RunSQLChat(SQL.ToString, P)
                End If
            Catch ex As Exception
            End Try

            ReadDone.WaitOne()
        Loop
        B = False
    End Sub


#End Region

    'Shared Function SystemMsgHandle(ByVal Rs As cSocket, ByVal LastState As cSocket.SetBufferRetrun) As Boolean
    '    Select Case LastState
    '        Case cSocket.SetBufferRetrun.NotCompleted '未完成

    '        Case cSocket.SetBufferRetrun.AllCompleted '全部接收完毕
    '            Dim s As String = Encoding.ASCII.GetString(Rs.ReceiveBag, 0, Rs.ReceiveBagSize)
    '        Case cSocket.SetBufferRetrun.OneCompleted '一个接收完毕
    '            '解包,
    '            Dim s As String = Encoding.ASCII.GetString(Rs.ReceiveBag, 0, Rs.ReceiveBagSize)

    '            If s.StartsWith("Text", StringComparison.CurrentCultureIgnoreCase) Then '增加连接
    '                Me.Invoke(New DAddText(AddressOf AddText), s.Substring(5))
    '            End If

    '        Case cSocket.SetBufferRetrun.ReceiveRetrun '接收返回
    '    End Select
    '    Return True
    'End Function


#Region "获取系统图片"
    Public Shared Function GetSystemFace(ByVal F As Enum_FaceName) As String
        Return GetSystemFaceByString(FaceName_GetNames(F))
    End Function

    Public Shared Function GetSystemFaceByString(ByVal Str As String) As String
        Dim FaceName As String = Str
        Dim FacePath As String = SystemFacePath & FaceName & "." & FaceName.Substring(0, 3)
        If My.Computer.FileSystem.FileExists(FacePath) = False Then
            Try
                Dim B As Bitmap = My.Resources.ChatRes.ResourceManager.GetObject(FaceName)
                B.Save(FacePath)
            Catch ex As Exception
            End Try
        End If
        Return FacePath
    End Function

    Private Shared Function FaceName_GetNames(ByVal I As Enum_FaceName) As String
        Return [Enum].GetName(I.GetType, I)
    End Function

    Public Enum Enum_FaceName
        gifSmallFace
        gifSystemInfo
        gifSystemOk
    End Enum



#End Region

#Region "其他公共函数"
    ''' <summary>
    ''' win32 颜色转换成Html颜色
    ''' </summary>
    ''' <param name="C"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ColorToHtmlColor(ByVal C As Color) As String
        Return "#" & C.R.ToString("X2") + C.G.ToString("X2") + C.B.ToString("X2")
    End Function

    ''' <summary>
    ''' 清除SCRIPT
    ''' </summary>
    ''' <param name="Str"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function StrReplaceSCRIPT(ByVal Str As String) As String
        Return Regex.Replace(Str, "<SCRIPT[^<]*</SCRIPT>", "", RegexOptions.IgnoreCase)
    End Function


    ''' <summary>
    ''' 把图片文件路径转换
    ''' </summary>
    ''' <param name="Document"></param>
    ''' <param name="Info"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function DocumentReplaceFilePath(ByVal Document As HtmlDocument, ByRef Info As cPackage) As Boolean
        DocumentReplaceFilePath = False
        Dim FB() As Byte
        Dim FielList As New Dictionary(Of String, String)
        For Each d As System.Windows.Forms.HtmlElement In Document.GetElementsByTagName("img")
            Dim FullName As String = d.DomElement.src.ToString
            Dim FileName As String = d.DomElement.nameProp.ToString
            If CheckSystemFacePath(FullName) Then '系统表情
                d.DomElement.src = PublicNetSystemFacePath & FileName
                FullName = FileName.Substring(0, FileName.Length - 4)
                Info.Add_Attachment(FullName)
                DocumentReplaceFilePath = True
            Else
                Try
                    Using wc As New Net.WebClient
                        If FullName <> New Uri(ChatClient.ImgPath & FileName, True).AbsoluteUri Then
                            wc.DownloadFile(FullName, ChatClient.ImgPath & FileName)
                        End If
                    End Using
                    FB = IO.File.ReadAllBytes(ImgPath & FileName) '读取到Byte
                    Dim Md5 As String
                    Using hashmd5 As New Security.Cryptography.MD5CryptoServiceProvider
                        Md5 = BitConverter.ToString(hashmd5.ComputeHash(FB)).Replace("-", "").ToUpper '转换MD5
                    End Using
                    Dim New_FileName As String = Md5 & IO.Path.GetExtension(ImgPath & FileName)
                    d.DomElement.src = PublicNetSystemLoading
                    d.DomElement.title = PublicNetFilePath & New_FileName
                    Info.Add_Attachment(New_FileName, Md5, FB)
                    DocumentReplaceFilePath = True
                    Rename(ChatClient.ImgPath & FileName, ImgPath & New_FileName)
                Catch
                End Try
            End If
        Next
    End Function


    ''' <summary>
    ''' 把图片文件路径转换
    ''' </summary>
    ''' <param name="Document"></param>
    ''' <param name="Tilte"></param>
    ''' <remarks></remarks>
    Public Shared Sub DocumentFileDownComplete(ByVal Document As HtmlDocument, ByVal Tilte As String)
        Dim FB() As Byte
        Dim FielList As New Dictionary(Of String, String)
        For Each d As System.Windows.Forms.HtmlElement In Document.GetElementsByTagName("img")
            Try
                If d.DomElement.Title IsNot Nothing AndAlso d.DomElement.title = PublicNetFilePath & Tilte AndAlso d.DomElement.src.ToString.EndsWith(PublicLoadingGif) Then
                    d.DomElement.src = ImgPath & Tilte
                    d.DomElement.title = "双击打开图片" & Tilte
                    d.AttachEventHandler("ondblclick", New EventHandler(Function() ImgOpen(ImgPath, Tilte)))
                End If
            Catch
            End Try
        Next
    End Sub

    Private Shared Function ImgOpen(ByVal FilePath As String, ByVal FileName As String) As Boolean
        Try
            Dim d As String = System.IO.Path.GetTempPath & System.IO.Path.GetRandomFileName & "\"
            MDDir(d)
            Dim f As String = d & FileName
            FileCopy(ImgPath & FileName, f)
            Process.Start(f)
        Catch ex As Exception
        End Try
    End Function


    Public Shared Function StringReplcaseFilePath(ByVal str As String) As String
        Return str.Replace(PublicNetFilePath, New Uri(ImgPath, True).AbsoluteUri)
    End Function

    Public Shared Function StringSystemFacePath(ByVal str As String, ByVal Face As String) As String
        Return str.Replace(PublicNetSystemFacePath & Face, New Uri(SystemFacePath, True).AbsoluteUri & Face)
    End Function

    Public Shared Function CheckSystemFacePath(ByVal FilePath As String) As Boolean
        If FilePath.StartsWith(New Uri(SystemFacePath, True).AbsoluteUri, StringComparison.CurrentCultureIgnoreCase) Then
            Return True
        Else
            Return False
        End If
    End Function


    Public Shared Sub DelTempFileList(ByRef FileList As List(Of String))
        For Each F As String In FileList
            Try
                Kill(F)
            Catch ex As Exception
            End Try
        Next
        FileList.Clear()
    End Sub

#End Region


#Region "获取旧有记录"
    Public Shared Sub AddSendReceiveInfo(ByVal Receive As String, ByVal Info As cPackage)
        If PackList.ContainsKey(Receive) = False Then
            PackList.Add(Receive, New ArrayList)
        End If
        Dim A As ArrayList = PackList(Receive)
        A.Add(Info)
    End Sub




    Public Shared Function GetOldReceive(ByVal Receiver As String, ByVal StartDate As Date, ByVal EndDate As String) As DataTable
        Dim P As New Dictionary(Of String, Object)
        P.Add("Receiver", Receiver)
        P.Add("Sender", UserName)
        P.Add("StartDate", StartDate)
        P.Add("EndDate", EndDate)

        Dim R As DtReturnMsg = SqlChatToDt("select C.*,D.Data,D.Type  from " & ChatDB & " C, " & ChatData & " d where C.Data_ID=d.id and sendtime between @StartDate and @EndDate  and ((Receiver=@Receiver and Sender=@Sender)or (Receiver=@Sender and Sender=@Receiver ))order by C.ID", P, False)
        If R.IsOk And R.Dt.Rows.Count > 0 Then
            For Each Row As DataRow In R.Dt.Rows
                ReceiveDataTable(Row)
            Next
            P("LastChatID") = R.Dt.Rows(R.Dt.Rows.Count - 1)("ID")
            ReceiveDone.Set()
            Return R.Dt
        Else
            Return Nothing
        End If
    End Function


#End Region

End Class
