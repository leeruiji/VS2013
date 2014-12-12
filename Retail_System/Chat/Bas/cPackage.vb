Imports System.Runtime.Serialization.Formatters.Binary
Imports System.IO

Public Class cPackage
#Region "初始化"
    Sub New(ByVal Buff() As Byte, ByVal PackageType As Enum_PackageType)
        Me._BaseMsg = New cBaseMsg(Buff)
        Me._PackageType = PackageType
    End Sub

    Sub New(ByVal Sender As String, ByVal PackageType As Enum_PackageType)
        Me._BaseMsg = New cBaseMsg(Sender)
        Me._PackageType = PackageType
    End Sub
#End Region


#Region "定义"
    Public Enum Enum_State
        Add = 0
        Sending = 1
        Sended = 2
        Save = 3
    End Enum
#End Region

#Region "   属性    "
    Public ID As Integer = 0
    Public Data_Id As Integer = 0
    Protected _BaseMsg As cBaseMsg
    ''' <summary>
    ''' 基础信息包
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property BaseMsg() As cBaseMsg
        Get
            Return _BaseMsg
        End Get
        Set(ByVal value As cBaseMsg)
            _BaseMsg = value
        End Set
    End Property

    Public Enum Enum_PackageType
        System = 0
        Msg = 1
        Shake = 2
        ImgMsg = 3
        File = 4
        ScreenCut = 5
        SystemVer = 98
        ScreenImg = 99
    End Enum
    ''' <summary>
    ''' 包的类型
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property PackageType() As Enum_PackageType
        Get
            Return _PackageType
        End Get
    End Property
    Protected _PackageType As Enum_PackageType

    Public CurrentGetTime As Date
    Public AttachmentFiles As New Dictionary(Of String, Byte())
    ''' <summary>
    ''' 读取时间
    ''' </summary>
    ''' <remarks></remarks>
    Public ReadTime As DateTime
#End Region

#Region "   常量   "
    Public Const NEW_Date As Date = #1/1/1999#
    Public Const ERROR_Date As Date = #1/1/1990#
#End Region

#Region "   方法    "
    ''' <summary>
    ''' 增加附件
    ''' </summary>
    ''' <param name="Title"></param>
    ''' <param name="Md5"></param>
    ''' <param name="Buff"></param>
    ''' <remarks></remarks>
    Public Sub Add_Attachment(ByVal Title As String, ByVal Md5 As String, ByVal Buff() As Byte)
        If Attachments.ContainsKey(Title) = False Then
            Attachments.Add(Title, Md5)
        End If
        If AttachmentFiles.ContainsKey(Md5) = False Then
            AttachmentFiles.Add(Md5, Buff)
        End If
    End Sub

    ''' <summary>
    ''' 增加表情附件
    ''' </summary>
    ''' <param name="Title"></param>
    ''' <remarks></remarks>
    Public Sub Add_Attachment(ByVal Title As String)
        If Attachments.ContainsKey(Title) = False Then
            Attachments.Add(Title, "")
        End If
    End Sub

    Public Attachments As New Dictionary(Of String, String)

    Public Sub AttachmentsToBase()
        ReDim _BaseMsg.Title(Attachments.Count - 1)
        ReDim _BaseMsg.Md5(Attachments.Count - 1)
        Dim i As Integer = 0
        For Each KV As KeyValuePair(Of String, String) In Attachments
            _BaseMsg.Title(i) = KV.Key
            _BaseMsg.Md5(i) = KV.Value
            i = i + 1
        Next
    End Sub
    Public Sub BaseToAttachments()
        Attachments = New Dictionary(Of String, String)
        For i As Integer = 0 To _BaseMsg.Title.Length - 1
            Attachments.Add(_BaseMsg.Title(i), _BaseMsg.Md5(i))
        Next
    End Sub
#End Region


End Class 'cPackage

''' <summary>
''' 基础信息包
''' </summary>
''' <remarks></remarks>
<System.Serializable()> Public Class cBaseMsg
#Region "   初始化   "
    Sub New(ByVal Sender As String)
        Me._Sender = Sender
    End Sub
    Sub New(ByVal P As cBaseMsg)
        Me._Header = P._Header
        Me._Receiver = P._Receiver
        Me._Sender = P._Sender
        Me._SendTime = P.SendTime
        Me._State = cPackage.Enum_State.Sending
        Me._Content = P._Content
        Me.Title = P.Title
        Me.Md5 = P.Md5
    End Sub
    Sub New(ByVal buf() As Byte)
        Me.New(Deserialze(buf))
    End Sub
#End Region





#Region "   标题和内容   "
    ''' <summary>
    ''' 标题
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Header() As String
        Get
            Return _Header
        End Get
        Set(ByVal value As String)
            _Header = value
        End Set
    End Property
    Protected _Header As String

    ''' <summary>
    ''' 内容
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Content() As String
        Get
            Return _Content
        End Get
        Set(ByVal value As String)
            _Content = value
        End Set
    End Property
    Protected _Content As String
#End Region


#Region "   收发人   "

    ''' <summary>
    ''' 收件人列表
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Receiver() As List(Of String)
        Get
            Return _Receiver
        End Get
    End Property
    Protected _Receiver As New List(Of String)
    ''' <summary>
    ''' 添加收件人
    ''' </summary>
    ''' <param name="R"></param>
    ''' <remarks></remarks>
    Public Sub AddReceiver(ByVal R As String)
        _Receiver.Add(R)
    End Sub


    ''' <summary>
    ''' 发件人
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Sender() As String
        Get
            Return _Sender
        End Get
    End Property
    Protected _Sender As String


    ''' <summary>
    ''' 发送时间
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SendTime() As Date
        Get
            Return _SendTime
        End Get
        Set(ByVal value As Date)
            _SendTime = value
        End Set
    End Property
    Protected _SendTime As Date


    Public Sub SetReceive(ByVal R As String, ByVal T As Date)
        If State = cPackage.Enum_State.Sending Then
            If _Receiver.Contains(R) Then
                _Receiver(R) = T
                Dim OK As Boolean = True
                For Each D As Date In _Receiver
                    If D <= cPackage.NEW_Date Then
                        OK = False
                        Exit For
                    End If
                Next
                If OK Then
                    State = cPackage.Enum_State.Sended
                End If
            End If
        End If
    End Sub
#End Region


#Region "   状态    "

    ''' <summary>
    ''' 状态
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property State() As cPackage.Enum_State
        Get
            Return _State
        End Get
        Set(ByVal value As cPackage.Enum_State)
            If value > _State Then
                _State = value
            End If
        End Set
    End Property
    Protected _State As Byte
#End Region


#Region "   序列化  "
    Public Overridable Function ToByte() As Byte()
        Return Serialize(Me)
    End Function

    Public Function Serialize(ByVal P As cBaseMsg) As Byte()
        Dim formatter As New BinaryFormatter
        Dim stream As New MemoryStream
        formatter.Serialize(stream, P)
        Dim resule() As Byte = stream.ToArray
        stream.Close()
        Return resule
    End Function

    Public Shared Function Deserialze(ByVal buf() As Byte) As cBaseMsg
        Dim formatter As New BinaryFormatter
        Dim stream As New MemoryStream(buf)
        Dim obj As Object
        obj = formatter.Deserialize(stream)
        stream.Close()
        Return obj
    End Function
#End Region

#Region "   附件   "
    Public Title() As String
    Public Md5() As String
#End Region


End Class 'cBaseMsg



'<System.Serializable()> Public Class cFilePackage
'    Inherits cPackage
'    Sub New(ByVal Sender As String, ByVal PackageType As Enum_PackageType)
'        MyBase.New(Sender, PackageType)
'    End Sub
'    Sub New(ByVal P As cFilePackage)
'        MyBase.New(P)
'        Me._Attachments = P._Attachments
'    End Sub


'    Protected _Attachments As New List(Of cAttachment)
'    ''' <summary>
'    ''' 附件列表
'    ''' </summary>
'    ''' <value></value>
'    ''' <returns></returns>
'    ''' <remarks></remarks>
'    Public Property Attachments() As List(Of cAttachment)
'        Get
'            Return _Attachments
'        End Get
'        Set(ByVal value As List(Of cAttachment))
'            _Attachments = value
'        End Set
'    End Property

'#Region "   序列化  "
'    Public Overrides Function ToByte() As Byte()
'        Return Serialize(Me)
'    End Function

'    Public Overloads Function Serialize(ByVal P As cFilePackage) As Byte()
'        Dim formatter As New BinaryFormatter
'        Dim stream As New MemoryStream
'        formatter.Serialize(stream, P)
'        Dim resule() As Byte = stream.ToArray
'        stream.Close()
'        Return resule
'    End Function

'    Public Overloads Shared Function Deserialze(ByVal buf() As Byte) As cFilePackage
'        Dim formatter As New BinaryFormatter
'        Dim stream As New MemoryStream(buf)
'        Dim obj As Object
'        obj = formatter.Deserialize(stream)
'        stream.Close()
'        Return obj
'    End Function
'#End Region
'End Class

'''' <summary>
'''' 附件
'''' </summary>
'''' <remarks></remarks>
'Public Class cAttachmentList
'    Protected _Attachments As New Dictionary(Of String, Byte())
'    ''' <summary>
'    ''' 附件列表
'    ''' </summary>
'    ''' <value></value>
'    ''' <returns></returns>
'    ''' <remarks></remarks>
'    Public Property Attachments() As Dictionary(Of String, Byte())
'        Get
'            Return _Attachments
'        End Get
'        Set(ByVal value As Dictionary(Of String, Byte()))
'            _Attachments = value
'        End Set
'    End Property
'End Class
