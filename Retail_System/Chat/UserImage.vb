Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary

Public Class UserImage
    Implements BaseClass.iTooltipChild

    Dim UserName As String = ""
    Public Sub GetImage(ByVal UserName As String)
        If UserName = Me.UserName Then
            SetImage()
        Else
            PictureBox1.Image = PClass.My.Resources.BMPLoading
            Dim T As New Threading.Thread(AddressOf TGetImage)
            T.Start(UserName)
        End If
    End Sub


    Public Img As Image
    Public HeadImg As Image
    Public Sub TGetImage(ByVal UserName As String)
        Dim R As PClass.PClass.DtReturnMsg = PClass.PClass.SqlStrToDt("select top 1 Employee_Picture from T15001_Employee where Employee_Name=@Employee_Name", "Employee_Name", UserName)
        If R.IsOk AndAlso R.Dt.Rows.Count > 0 Then

            Try
                Dim B() As Byte = R.Dt.Rows(0)("Employee_Picture")
                If B.Length > 0 Then
                    Dim MemoryStream = New MemoryStream(B)
                    'IO.File.WriteAllBytes(F, B)
                    Img = Image.FromStream(MemoryStream)
                    Me.UserName = UserName

                Else
                    Me.UserName = ""
                    Img = Nothing
                End If
            Catch
                Me.UserName = ""
                Img = Nothing
            End Try
        Else
            Me.UserName = ""
            Img = Nothing
        End If
        Threading.Thread.Sleep(1)
        Try
            Me.Invoke(New DSetImage(AddressOf SetImage))
        Catch ex As Exception
        End Try
    End Sub


    Public BigSize As Size = New Size(230, 300)
    Public SmallSize As Size = New Size(144, 144)
    Private Delegate Sub DSetImage()
    Public Sub SetImage()
        If Img Is Nothing Then
            Me.PictureBox1.Image = HeadImg
            If Me.Size <> SmallSize Then
                Me.Size = SmallSize
            End If
        Else
            Me.PictureBox1.Image = Img
            If Me.Size <> BigSize Then
                Me.Size = BigSize
            End If
        End If
    End Sub


#Region "Tooltip"
    Public Property Dock1() As System.Windows.Forms.DockStyle Implements BaseClass.iTooltipChild.Dock
        Get
            Return Dock
        End Get
        Set(ByVal value As System.Windows.Forms.DockStyle)
            Dock = value
        End Set
    End Property

    Public Property Size1() As System.Drawing.Size Implements BaseClass.iTooltipChild.Size
        Get
            Return Me.Size
        End Get
        Set(ByVal value As System.Drawing.Size)
            Me.Size = value
        End Set
    End Property
    Private _ToolTip As BaseClass.ToolTipCtrl
    Public Property ToolTip() As BaseClass.ToolTipCtrl Implements BaseClass.iTooltipChild.ToolTip
        Get
            Return _ToolTip
        End Get
        Set(ByVal value As BaseClass.ToolTipCtrl)
            _ToolTip = value
        End Set
    End Property
#End Region

End Class
