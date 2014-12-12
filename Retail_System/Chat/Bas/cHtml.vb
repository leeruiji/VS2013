Imports System.Text.RegularExpressions

Public Class cHtml

#Region "常量"

    ''' <summary>
    ''' 网页的主体
    ''' </summary>
    ''' <remarks></remarks>
    Public Const HtmlBody = "<html>" & vbCrLf & _
                            vbTab & "<head>" & vbCrLf & _
                            vbTab & vbTab & "<meta http-equiv=""Content-Type"" content=""text/html;charset=gb2312"" />" & vbCrLf & _
                            vbTab & vbTab & "<style type=Text/Css>" & vbCrLf & _
                            vbTab & vbTab & vbTab & "    P{margin:1pt }   " & vbCrLf & _
                            vbTab & vbTab & vbTab & "   .SysInf{font-size:9pt;color:808080;font-family:宋体;}" & vbCrLf & _
                            vbTab & vbTab & vbTab & "   .MeSend{color:#42B475;font-size:9pt;font-family:宋体;}" & vbCrLf & _
                            vbTab & vbTab & vbTab & "   .MeReceive{color:blue;font-size:9pt;font-family:宋体;}" & vbCrLf & _
                            vbTab & vbTab & vbTab & "   .CDiv{text-align:left;margin:margin: 5px 1px 1px 1px;padding-left:1px;font-size:9pt;font-family:宋体;}" & vbCrLf & _
                            vbTab & vbTab & vbTab & "   .DateLine{font-weight:bold;color:#3568BB;font-size:9pt;font-family:宋体;}" & vbCrLf & _
                            vbTab & vbTab & vbTab & "   .CutLine{ WIDTH:100%;SIZE:1;hight:1;color:#8EC3EB;}" & vbCrLf & _
                            vbTab & vbTab & vbTab & "   .DTable{font-size:9pt;color:Black;font-family:宋体;}" & vbCrLf & _
                            vbTab & vbTab & "</style>" & vbCrLf & _
                            vbTab & "</head>" & vbCrLf & _
                            vbTab & "<body style=""word-break:break-all; word-wrap:break-all; background:white;font-size:11pt;font-family:宋体;"">" & vbCrLf & _
                            vbTab & "</body>" & vbCrLf & _
                            "</html>" & vbCrLf

    '''' <summary>
    '''' 发送网页的主体
    '''' </summary>
    '''' <remarks></remarks>
    'Public Const HtmlBody_Send = "<html><head><meta http-equiv=""Content-Type"" content=""text/html;charset=gb2312"" /></head>" & vbCrLf & _
    '                        "<script type=""text/javascript"">var srcOneeror=""@varsrcOneeror""</script></head>" & vbCrLf & _
    '                        "<style type=Text/Css > P{margin:0pt }</style>" & vbCrLf & _
    '                        "<body style=""word-break:break-all; word-wrap:break-all;"">" & vbCrLf & _
    '                        "</body>" & vbCrLf & _
    '                        "<html>"

    ''' <summary>
    ''' 设置背景色
    ''' </summary>
    ''' <remarks></remarks>
    Public Const BackColor = "BackColor"

    ''' <summary>
    ''' 加粗
    ''' </summary>
    ''' <remarks></remarks>
    Public Const Bold = "Bold"
    ''' <summary>
    ''' 复制
    ''' </summary>
    ''' <remarks></remarks>
    Public Const Copy = "Copy"

    ''' <summary>
    ''' 生成标签
    ''' </summary>
    ''' <remarks></remarks>
    Public Const CreateBookmark = "CreateBookmark"


    ''' <summary>
    ''' 剪切
    ''' </summary>
    ''' <remarks></remarks>
    Public Const Cut = "Cut"


    ''' <summary>
    ''' 删除
    ''' </summary>
    ''' <remarks></remarks>
    Public Const Delete = "Delete"


    ''' <summary>
    ''' 字体
    ''' </summary>
    ''' <remarks></remarks>
    Public Const FontName = "FontName"


    ''' <summary>
    ''' 字体大小
    ''' </summary>
    ''' <remarks></remarks>
    Public Const FontSize = "FontSize"


    ''' <summary>
    ''' 字体颜色
    ''' </summary>
    ''' <remarks></remarks>
    Public Const ForeColor = "ForeColor"

    ''' <summary>
    '''  编辑区域
    ''' </summary>
    ''' <remarks></remarks>
    Public Const InsertFieldset = "InsertFieldset"


    ''' <summary>
    ''' 斜体
    ''' </summary>
    ''' <remarks></remarks>
    Public Const Italic = "Italic"
    ''' <summary>
    ''' 缩进
    ''' </summary>
    ''' <remarks></remarks>
    Public Const Indent = "Indent"


    ''' <summary>
    ''' 插入图片
    ''' </summary>
    ''' <remarks></remarks>
    Public Const InsertImage = "InsertImage"


    ''' <summary>
    '''  居中
    ''' </summary>
    ''' <remarks></remarks>
    Public Const JustifyCenter = "JustifyCenter"

    ''' <summary>
    ''' 插入图片
    ''' </summary>
    ''' <remarks></remarks>
    Public Const JustifyLeft = "JustifyLeft"

    ''' <summary>
    ''' 插入图片
    ''' </summary>
    ''' <remarks></remarks>
    Public Const JustifyRight = "JustifyRight"


    ''' <summary>
    ''' 下划线
    ''' </summary>
    ''' <remarks></remarks>
    Public Const Underline = "Underline"


    ''' <summary>
    ''' 撤销
    ''' </summary>
    ''' <remarks></remarks>
    Public Const Undo = "Undo "

    ''' <summary>
    ''' 删除线
    ''' </summary>
    ''' <remarks></remarks>
    Public Const StrikeThrough = "StrikeThrough"
#End Region



    Public Shared Function GetColor(ByVal Str As String) As Color
        Dim L As Integer
        Dim R As Integer
        Dim G As Integer
        Dim B As Integer
        If Str.IndexOf("#") >= 0 Then
            Str = Str.Replace("#", "")

            R = "&H" & Str.Substring(0, 2)
            G = "&H" & Str.Substring(2, 2)
            B = "&H" & Str.Substring(4, 2)
            L = B + G * 256 + R * 65536
        Else
            L = Val(Str)
            Dim StrHex As String
            StrHex = Hex(L)
            Select Case StrHex.Length
                Case 2
                    R = "&H" & StrHex.Substring(0, 2)
                Case 4
                    G = "&H" & StrHex.Substring(0, 2)
                    R = "&H" & StrHex.Substring(2, 2)
                Case 5
                    B = "&H" & StrHex.Substring(0, 1)
                    G = "&H" & StrHex.Substring(1, 2)
                    R = "&H" & StrHex.Substring(3, 2)
                Case 6
                    B = "&H" & StrHex.Substring(0, 2)
                    G = "&H" & StrHex.Substring(2, 2)
                    R = "&H" & StrHex.Substring(4, 2)
            End Select
            L = B + G * 256 + R * 65536
        End If
        Return Color.FromArgb(L)
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="I"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Get_SchemeSplit(ByVal I As SchemeSplit) As String
        Return [Enum].GetName(I.GetType, I)
    End Function

    ''' <summary>
    ''' 自定义方案名
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum SchemeSplit
        FileOpen
        FileSave

    End Enum

End Class
