Imports System.Runtime.InteropServices
Imports System.Drawing.Imaging

Public Class SystemIcon
    <StructLayout(LayoutKind.Sequential)> _
Private Structure SHFILEINFO
        Public hIcon As IntPtr
        Public iIcon As Integer
        Public dwAttributes As Integer
        <MarshalAs(UnmanagedType.LPStr, sizeconst:=260)> _
        Public szDisplayName As String
        <MarshalAs(UnmanagedType.LPStr, sizeconst:=80)> _
        Public szTypeName As String
    End Structure

    <DllImport("shell32.dll ")> _
    Private Shared Function SHGetFileInfo(ByVal pszPath As String, ByVal dwFileAttributes As Integer, _
            ByRef psfi As SHFILEINFO, ByVal cbfileInfo As Integer, ByVal uFlags As SHGFI) As Integer
    End Function

    Private Enum SHGFI As Integer
        SmallIcon = &H1
        LargeIcon = &H0
        Icon = &H100
        DisplayName = &H200
        Typename = &H400
        SysIconIndex = &H4000
        UseFileAttributes = &H10
    End Enum

    Public Shared Function GetFileIcon(ByVal strFilename As String, ByVal bSmallIcon As Boolean) As Icon
        Dim info As SHFILEINFO = Nothing
        Dim flags As SHGFI
        If bSmallIcon Then
            flags = SHGFI.Icon Or SHGFI.SmallIcon Or SHGFI.UseFileAttributes
        Else
            flags = SHGFI.Icon Or SHGFI.LargeIcon Or SHGFI.UseFileAttributes 'Or SHGFI.SysIconIndex
        End If
        SHGetFileInfo(strFilename, 0, info, Marshal.SizeOf(info), flags)
        Return Icon.FromHandle(info.hIcon)   '此处返回图标从变量窗口可知iconDate=nothing 
    End Function

    Public Shared Function GetDirectoryIconIcon(ByVal strFilename As String, ByVal bSmallIcon As Boolean) As Icon
        Dim info As SHFILEINFO = Nothing
        Dim flags As SHGFI
        If bSmallIcon Then
            flags = SHGFI.Icon Or SHGFI.SmallIcon 'Or SHGFI.UseFileAttributes
        Else
            flags = SHGFI.Icon Or SHGFI.LargeIcon 'Or SHGFI.UseFileAttributes 'Or SHGFI.SysIconIndex
        End If
        SHGetFileInfo(strFilename, 0, info, Marshal.SizeOf(info), flags)
        Return Icon.FromHandle(info.hIcon)   '此处返回图标从变量窗口可知iconDate=nothing 
    End Function



#Region "图片转换"
    Public Shared Function ImageToIcon(ByVal Img As Image) As Icon
        Dim mStream As System.IO.MemoryStream = New System.IO.MemoryStream()
        Img.Save(mStream, System.Drawing.Imaging.ImageFormat.Tiff)
        ImageToIcon = Icon.FromHandle(New Bitmap(mStream).GetHicon())
        mStream.Close()
    End Function



    Public Shared Sub MakeSmallImg(ByVal myImage As System.Drawing.Image, ByVal fileSaveUrl As String, ByVal templateWidth As System.Double, ByVal templateHeight As System.Double)
        Using BitMap As Image = MakeSmallImg(myImage, templateHeight, templateWidth)
            '保存缩略图  
            If IO.File.Exists(fileSaveUrl) Then
                IO.File.SetAttributes(fileSaveUrl, IO.FileAttributes.Normal)
                IO.File.Delete(fileSaveUrl)
            End If
            BitMap.Save(fileSaveUrl, System.Drawing.Imaging.ImageFormat.Png)
        End Using
    End Sub


    Public Shared Function MakeSmallImg(ByVal myImage As System.Drawing.Image, ByVal templateWidth As System.Double, ByVal templateHeight As System.Double) As Image
        '缩略图宽、高  
        Dim newWidth As System.Double = myImage.Width
        Dim newHeight As System.Double = myImage.Height
        '宽大于模版的横图  
        If myImage.Width > myImage.Height OrElse myImage.Width = myImage.Height Then
            If myImage.Width > templateWidth Then
                '宽按模版，高按比例缩放  
                newWidth = templateWidth
                newHeight = myImage.Height * (newWidth / myImage.Width)
            End If
        Else
            '高大于模版的竖图  
            If myImage.Height > templateHeight Then
                '高按模版，宽按比例缩放  
                newHeight = templateHeight
                newWidth = myImage.Width * (newHeight / myImage.Height)
            End If
        End If

        '取得图片大小  
        Dim mySize As System.Drawing.Size = New Size(CInt(Math.Truncate(newWidth)), CInt(Math.Truncate(newHeight)))
        '新建一个bmp图片  
        Dim bitmap As System.Drawing.Image = New System.Drawing.Bitmap(mySize.Width, mySize.Height)
        '新建一个画板  
        Using g__1 As System.Drawing.Graphics = System.Drawing.Graphics.FromImage(bitmap)
            '设置高质量插值法  
            g__1.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High
            '设置高质量,低速度呈现平滑程度  
            g__1.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality
            '清空一下画布  
            g__1.Clear(Color.White)
            '在指定位置画图  
            g__1.DrawImage(myImage, New System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height), New System.Drawing.Rectangle(0, 0, myImage.Width, myImage.Height), System.Drawing.GraphicsUnit.Pixel)
            g__1.Dispose()
        End Using
        Return bitmap
    End Function

    Public Shared Function ImageToGray(ByVal bmp As Image) As Image
        Dim bitmap As System.Drawing.Image = New System.Drawing.Bitmap(bmp.Width, bmp.Height)
        Dim ia As New Drawing.Imaging.ImageAttributes
        Dim cm As New Drawing.Imaging.ColorMatrix(New Single()() _
                        {New Single() {0.299, 0.299, 0.299, 0, 0}, _
                         New Single() {0.587, 0.587, 0.587, 0, 0}, _
                         New Single() {0.114, 0.114, 0.114, 0, 0}, _
                         New Single() {0, 0, 0, 1, 0}, _
                         New Single() {0, 0, 0, 0, 1}})

        ia.SetColorMatrix(cm, Imaging.ColorMatrixFlag.Default, Imaging.ColorAdjustType.Bitmap)
        Dim g As Graphics = Drawing.Graphics.FromImage(bitmap)
        g.DrawImage(bmp, New Rectangle(0, 0, bmp.Width, bmp.Height), 0, 0, bmp.Width, bmp.Height, GraphicsUnit.Pixel, ia)
        Return bitmap
    End Function
#End Region


#Region "截取图象"

    Private Declare Function BitBlt Lib "GDI32" (ByVal hdcDest As IntPtr, ByVal nXDest As Integer, ByVal nYDest As Integer, ByVal nWidth As Integer, ByVal nHeight As Integer, ByVal hdcSrc As IntPtr, ByVal nXSrc As Integer, ByVal nYSrc As Integer, ByVal dwRop As Integer) As Boolean
    Public Shared Function CopyFromImage(ByVal F As PictureBox) As Image
        If F.Width < 2 Then
            F.Width = 2
        End If
        If F.Height < 2 Then
            F.Height = 2
        End If
        Dim g1 As Graphics = Graphics.FromHwnd(F.Handle)
        Dim ScreenImage As Bitmap = New Bitmap(F.Width - 1, F.Height - 1, g1)
        Dim g2 As Graphics = Graphics.FromImage(ScreenImage)
        Dim dc3 As IntPtr = g1.GetHdc
        Dim dc2 As IntPtr = g2.GetHdc
        BitBlt(dc2, 0, 0, ScreenImage.Width - 1, ScreenImage.Height - 1, dc3, 0, 0, 13369376)
        g1.ReleaseHdc(dc3)
        g2.ReleaseHdc(dc2)
        'Dim mBrush As New SolidBrush(System.Drawing.Color.FromArgb(128, 128, 128, 128))
        'g2.FillRectangle(mBrush, 0, 0, ScreenImage.Width, ScreenImage.Height)
        Return ScreenImage
    End Function
    Public Shared Function CaptureFromImage(ByVal F As Panel) As Image
        Dim g1 As Graphics = Graphics.FromHwnd(F.Handle)
        Dim ScreenImage As Bitmap = New Bitmap(F.Width, F.Height, g1)
        Dim g2 As Graphics = Graphics.FromImage(ScreenImage)
        Dim dc3 As IntPtr = g1.GetHdc
        Dim dc2 As IntPtr = g2.GetHdc
        BitBlt(dc2, 0, 0, ScreenImage.Width, ScreenImage.Height, dc3, 0, 0, 13369376)
        g1.ReleaseHdc(dc3)
        g2.ReleaseHdc(dc2)
        Dim mBrush As New SolidBrush(System.Drawing.Color.FromArgb(128, 128, 128, 128))
        g2.FillRectangle(mBrush, 0, 0, ScreenImage.Width, ScreenImage.Height)
        Return ScreenImage
    End Function




#End Region

#Region "全屏截图"
    Public Shared Function GetScreenImage() As Image
        Dim myImage As Image = New Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height)
        Using G = Graphics.FromImage(myImage)
            G.CopyFromScreen(New Point(0, 0), New Point(0, 0), New Size(myImage.Width, myImage.Height))
            Dim C As Cursor = Cursors.Arrow
            Dim R As New Rectangle(Cursor.Position, Cursor.Current.Size)
            R.Offset(-Cursor.Current.Size.Width / 4, -Cursor.Current.Size.Height / 4)
            C.Draw(G, R)

            G.Dispose()
        End Using
        Return myImage
    End Function

    Public Shared Function GetScreenImage2() As Image
        Dim G1 As Graphics = Graphics.FromHwnd(0)
        Dim ScreenImage As Bitmap = New Bitmap(G1.VisibleClipBounds.Width, G1.VisibleClipBounds.Height, G1)
        Dim G2 As Graphics = Graphics.FromImage(ScreenImage)
        Dim dc3 As IntPtr = G1.GetHdc
        Dim dc2 As IntPtr = G2.GetHdc
        BitBlt(dc2, 0, 0, ScreenImage.Width - 1, ScreenImage.Height - 1, dc3, 0, 0, 13369376)
        Dim C As Cursor = Cursors.Arrow
        Dim R As New Rectangle(Cursor.Position, Cursor.Current.Size)
        R.Offset(-Cursor.Current.Size.Width / 4, -Cursor.Current.Size.Height / 4)
        C.Draw(G2, R)
        G1.ReleaseHdc(dc3)
        G2.ReleaseHdc(dc2)
        Return ScreenImage
    End Function

    ''' <summary>
    ''' 压缩图片
    ''' </summary>
    ''' <param name="Img"></param>
    ''' <param name="Quality"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ImageCompress(ByVal Img As Image, Optional ByVal Quality As Byte = 25) As IO.MemoryStream
        Dim myBitmap As Bitmap
        Dim myImageCodecInfo As ImageCodecInfo
        Dim myEncoder As Encoder
        Dim myEncoderParameter As EncoderParameter
        Dim myEncoderParameters As EncoderParameters
        myBitmap = Img
        myImageCodecInfo = GetEncoderInfo(ImageFormat.Jpeg)
        myEncoder = Encoder.Quality
        myEncoderParameters = New EncoderParameters(1)
        myEncoderParameter = New EncoderParameter(myEncoder, CType(Quality, Int32))
        myEncoderParameters.Param(0) = myEncoderParameter
        Dim I As IO.MemoryStream = New IO.MemoryStream
        Img.Save(I, myImageCodecInfo, myEncoderParameters)
        Return I
    End Function


    Private Shared Function GetEncoderInfo(ByVal format As Imaging.ImageFormat) As Imaging.ImageCodecInfo
        Dim j As Integer
        Dim encoders() As Imaging.ImageCodecInfo
        encoders = Imaging.ImageCodecInfo.GetImageEncoders()
        j = 0
        While j < encoders.Length
            If encoders(j).FormatID = format.Guid Then
                Return encoders(j)
            End If
            j += 1
        End While
        Return Nothing

    End Function
#End Region
End Class



