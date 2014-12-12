
Imports System.Data.SqlClient
Imports PClass.PClass
Imports System.Text

Module ModuleData
    Public Update_Cmd As New StringBuilder("")
    Public Update_Del As New StringBuilder("")



#Region "生成连接"
    Public DBMsg As String = ""
    ''' <summary>
    ''' 生成连接字符串
    ''' </summary>
    ''' <remarks>1111111</remarks>
    Public Sub CnnStrAdd(ByVal Csx As CSaveXml)
        Dim B As New SqlClient.SqlConnectionStringBuilder
        B.DataSource = Csx.MIP              'IP 或域名
        B.InitialCatalog = Csx.MDB           '数据库名
        B.UserID = Csx.MUserId                    '用户
        B.Password = DeDes(Csx.MPassword, AppDes)
        B.Pooling = True                '是否支持连接池
        If B.Password = "" Then
            B.Password = "vv"
        End If
        DBMsg = Csx.MIP & "[" & Csx.MDB & "]"
        B.ApplicationName = "V3_Retail"
        B.AsynchronousProcessing = False
        CnnStr = B.ConnectionString         '同步字符串
        B.AsynchronousProcessing = True
    End Sub

    ''' <summary>
    ''' 生成连接字符串
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub CnnChatStrAdd(ByVal Csx As CSaveXml)      '生成连接字符串
        Dim B As New SqlClient.SqlConnectionStringBuilder
        B.DataSource = IIf(Csx.MIP.Trim = "192.168.19.240", "192.168.16.10", Csx.MIP)              'IP 或域名

        B.InitialCatalog = Csx.MDB           '数据库名
        B.UserID = Csx.MUserId               '用户
        B.Password = DeDes(Csx.MPassword, AppDes)
        If B.Password = "" Then
            B.Password = "vv"
        End If
        B.Pooling = True                '是否支持连接池
        B.ConnectTimeout = 1
        B.ApplicationName = "V3_Retail"
        B.AsynchronousProcessing = False
        CnnChatStr = B.ConnectionString         '同步字符串
        B.AsynchronousProcessing = True
    End Sub
#End Region




    Public Sub DownLoadComplete()
        Update_Cmd.Append("Shell")
        Update_Cmd.Append(">>")
        Update_Cmd.Append(IO.Path.GetFileName(Application.ExecutablePath).ToLower)
        Update_Cmd.Append(">>")
        If Command.ToLower.StartsWith("ip=") Then
            Try
                If IO.File.Exists(AppPath & "clnk.exeux") Then
                    My.Computer.FileSystem.RenameFile(AppPath & "clnk.exeux", "clnk.exe")
                End If
            Catch ex As Exception
            End Try
            Try
                Process.Start(AppPath & "clnk.exe", AppName & ";" & IO.Path.GetFileNameWithoutExtension(Application.ExecutablePath))
            Catch ex As Exception
            End Try
            Update_Cmd.AppendLine("")
        Else
            Update_Cmd.AppendLine(Command)
        End If

        Update_Cmd.Append("UpdateExit")
        Update_Cmd.Append(">>")
        Update_Cmd.Append("")
        Update_Cmd.Append(">>")
        Update_Cmd.AppendLine("")




        Try
            Dim s As String = "Run=" & Convert.ToBase64String(System.Text.Encoding.Default.GetBytes("MainExe>>" & IO.Path.GetFileName(Application.ExecutablePath).ToLower & vbCrLf & Update_Cmd.ToString))
            IO.File.WriteAllText(AppPath & "Update.Log", s)
            Try
                Process.Start(AppPath & "DLLUpdate.exe", s)
            Catch ex As Exception
                Try
                    Shell(AppPath & "DLLUpdate.exe", AppWinStyle.NormalFocus)
                Catch ex1 As Exception
                    MsgBox("更新失败!" & ex1.Message)
                End Try
            End Try
        Catch ex As Exception
            MsgBox("更新丢失!" & ex.Message)
        End Try
        Application.Exit()
        End
    End Sub

    Sub AddDown(ByVal DownFileName As String, ByVal Mark As String, ByVal Cmd As String)
        Update_Cmd.Append(Cmd)
        Update_Cmd.Append(">>")
        Update_Cmd.Append(DownFileName)
        Update_Cmd.Append(">>")
        Update_Cmd.AppendLine(Mark)
    End Sub
    Sub AddDel(ByVal DownFileName As String, ByVal Mark As String, ByVal Cmd As String)
        Update_Del.Append(Cmd)
        Update_Del.Append(">>")
        Update_Del.Append(DownFileName)
        Update_Del.Append(">>")
        Update_Del.AppendLine(Mark)
    End Sub

    Private Const MainExeUpdate As String = "MainExeUpdate"
    Private Const MainDllUpdate As String = "MainDllUpdate"
    Private Const DllDel As String = "DllDel"
    Private Const OcxUpdate As String = "OcxUpdate"
    Private Const OcxUpdateReg As String = "OcxUpdateReg"
    Private Const DllUpdate As String = "DllUpdate"


    '更新DLL
    Public Function UpdateDLL() As Boolean
        FormLogon.TopMost = False
        Dim i As Integer
        Dim j As Integer
        Dim V As Integer
        Dim R As New DtReturnMsg
        Try
            R = SqlStrToDt("GetNewDLL")
            If R.IsOk = False Then
                End
            Else
                If IsBarCode Then
                    For ii As Integer = R.Dt.Rows.Count - 1 To 0 Step -1
                        Dim Row As DataRow = R.Dt.Rows(ii)
                        If Row("DLL_Name").ToLower <> "DN300_Produce.dll".ToLower Then
                            Row.Delete()
                        End If
                    Next
                    R.Dt.AcceptChanges()
                End If
            End If
        Catch ex As Exception
            End
        End Try
        ShowLoadWaitMsg("检查DLL的更新..")
        Dim Dt As DataTable = R.Dt
        UpdateDLL = False
        Dim Dax(DllAss.Count - 1) As Boolean
        If Dt.Rows.Count > 0 Then
            For j = 0 To Dt.Rows.Count - 1
                V = CInt(Dt.Rows(j).Item("DLL_Ver") * 100)
                For i = 0 To DllAss.Count - 1
                    If Dt.Rows(j).Item("DLL_Name").ToString.ToLower = IO.Path.GetFileName(DllAss(i).CodeBase).ToString.ToLower Then
                        If V > CInt(GetAssVer(DllAss(i)) * 100) Then
                            ShowLoadWaitMsg("正在更新" & Dt.Rows(j).Item("DLL_Name").ToString & " " & FormatN(V / 100, 2) & "版....请稍候不要关闭电脑!")
                            If DLLToFile(AppPath & Dt.Rows(j).Item("DLL_Name").ToString, V, Dt.Rows(j).Item("dll_Compress")) Then
                                AddDown(Dt.Rows(j).Item("DLL_Name").ToString, "up", DllUpdate)
                            End If
                            UpdateDLL = True
                        Else
                            If V < CInt(GetAssVer(DllAss(i)) * 100) Then AddDel(IO.Path.GetFileName(DllAss(i).CodeBase).ToString.ToLower, "", DllDel)
                        End If
                        Dax(i) = True
                        Exit For
                    End If
                Next
                If i > DllAss.Count - 1 Then
                    ShowLoadWaitMsg("正在更新" & Dt.Rows(j).Item("DLL_Name").ToString & " " & FormatN(V / 100, 2) & "版....请稍候不要关闭电脑!")
                    If DLLToFile(AppPath & Dt.Rows(j).Item("DLL_Name").ToString, V, Dt.Rows(j).Item("dll_Compress")) Then
                        AddDown(Dt.Rows(j).Item("DLL_Name").ToString, "up", DllUpdate)
                    End If
                    UpdateDLL = True
                End If
            Next
        End If
        For i = 0 To Dax.Length - 1
            If Dax(i) = False Then
                AddDel(IO.Path.GetFileName(DllAss(i).CodeBase).ToString.ToLower, "", DllDel)
            End If
        Next
        Return (UpdateExe() Or UpdateDLL)
    End Function

    Public DelStr As String = ""
    Public UpdateALL As Boolean = False
    '更新DLL
    Public Function UpdateExe() As Boolean
        'FormLogon.TopMost = False
        Dim j As Integer
        Dim V As Integer
        Dim dt As New DataTable
        Dim R As New DtReturnMsg
        R = SqlStrToDt("GetNewExe")
        If R.IsOk = False Then
            End
        Else
            dt = R.Dt
        End If
        UpdateExe = False
        If dt.Rows.Count > 0 Then
            For j = 0 To dt.Rows.Count - 1
                If dt.Rows(j).Item("exe_Name").ToString.ToLower = IO.Path.GetFileName(Application.ExecutablePath).ToLower Then
                    V = CInt(dt.Rows(j).Item("exe_Ver") * 100)
                    If V > CInt(GetAppVer() * 100) Or UpdateALL Then
                        ShowLoadWaitMsg("正在更新" & dt.Rows(j).Item("exe_Name").ToString & " " & FormatN(V / 100, 2) & "版....请稍候不要关闭电脑!")
                        If ExeToFile(Application.ExecutablePath, V, dt.Rows(j).Item("exe_Compress")) Then
                            AddDown(dt.Rows(j).Item("exe_Name").ToString, "up", MainExeUpdate)
                        End If
                        UpdateExe = True
                    End If
                    Exit For
                End If
            Next
            For j = 0 To dt.Rows.Count - 1
                If dt.Rows(j).Item("exe_Name").ToString.ToLower = "pclass.dll".ToLower Then
                    V = CInt(dt.Rows(j).Item("exe_Ver") * 100)
                    If V > CInt(GetPClassVer() * 100) Or UpdateALL Then
                        ShowLoadWaitMsg("正在更新" & dt.Rows(j).Item("exe_Name").ToString & " " & FormatN(V / 100, 2) & "版....请稍候不要关闭电脑!")
                        If ExeToFile(AppPath & dt.Rows(j).Item("exe_Name").ToString, V, dt.Rows(j).Item("exe_Compress")) Then
                            AddDown(dt.Rows(j).Item("exe_Name").ToString, "up", MainDllUpdate)
                        End If
                        UpdateExe = True
                    End If
                    Exit For
                End If
            Next
            '===================BaseClass=====================
            For j = 0 To dt.Rows.Count - 1
                If dt.Rows(j).Item("exe_Name").ToString.ToLower = "baseclass.dll".ToLower Then
                    V = CInt(dt.Rows(j).Item("exe_Ver") * 100)
                    If V > CInt(GetBaseClassVer() * 100) Or UpdateALL Then
                        ShowLoadWaitMsg("正在更新" & dt.Rows(j).Item("exe_Name").ToString & " " & FormatN(V / 100, 2) & "版....请稍候不要关闭电脑!")
                        If ExeToFile(AppPath & dt.Rows(j).Item("exe_Name").ToString, V, dt.Rows(j).Item("exe_Compress")) Then
                            AddDown(dt.Rows(j).Item("exe_Name").ToString, "up", MainDllUpdate)
                        End If
                        UpdateExe = True
                    End If
                    Exit For
                End If
            Next
        End If
    End Function


    ''' <summary>
    ''' 下载DLL更新到数据库
    ''' </summary>
    ''' <param name="DllName">Dll文件</param>
    ''' <param name="NV">版本号</param>
    ''' <remarks></remarks>
    Public Function DLLToFile(ByVal DllName As String, ByVal NV As Integer, Optional ByVal Compress As Boolean = False) As Boolean
        Dim R As Boolean = False
        Dim NvStr As String = FormatN(NV / 100, 2)
        Try
            If Compress Then
                R = GetDbFileDeCompress("dll_File", "dll_file", " where DLL_Name='" & IO.Path.GetFileName(DllName) & "' and dll_Ver=" & NvStr & " ", DllName & "up")
            Else
                R = GetDbFile("dll_File", "dll_file", " where DLL_Name='" & IO.Path.GetFileName(DllName) & "' and dll_Ver=" & NvStr & " ", DllName & "up")
            End If
        Catch ex As Exception
            MsgBox("更新错误," & ex.ToString)
            Return False
        End Try
        Return IO.File.Exists(DllName & "up") AndAlso R
    End Function

    ''' <summary>
    ''' 下载DLL更新到数据库
    ''' </summary>
    ''' <param name="ExeName"></param>
    ''' <param name="NV"></param>
    ''' <param name="Compress"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ExeToFile(ByVal ExeName As String, ByVal NV As Double, Optional ByVal Compress As Boolean = False) As Boolean
        Dim R As Boolean = False
        Dim NvStr As String = FormatN(NV / 100, 2)
        Try
            If Compress Then
                R = GetDbFileDeCompress("Exe_file", "Exe_File", " where Exe_Name='" & IO.Path.GetFileName(ExeName) & "' and Exe_Ver=" & NvStr & " ", ExeName & "up")
            Else
                R = GetDbFile("Exe_file", "Exe_File", " where Exe_Name='" & IO.Path.GetFileName(ExeName) & "' and Exe_Ver=" & NvStr & " ", ExeName & "up")
            End If
        Catch ex As Exception
            'DebugToLog(ex, "SQL语句:select Exe_file from Exe_File where Exe_Name='" & IO.Path.GetFileName(ExeName) & "' and Exe_Ver=" & NV & " ")
            MsgBox("更新错误," & ex.ToString)
            Return False
        End Try
        Return IO.File.Exists(ExeName & "up") AndAlso R
    End Function


#Region "检查版本"
#Region "baseclass"
    Function GetBaseClassVer() As Double
        Dim Ass As Reflection.Assembly = Reflection.Assembly.GetAssembly(GetType(BaseClass.ComFun))
        GetBaseClassVer = GetAssVer(Ass)
        Ass = Nothing
    End Function
#End Region

    Function GetPClassVer() As Double
        Dim Ass As Reflection.Assembly = Reflection.Assembly.GetAssembly(GetType(PClass.PClass))
        GetPClassVer = GetAssVer(Ass)
        Ass = Nothing
    End Function

    Function GetExeVer(ByVal Exe As String) As Double
        Dim Ass As Reflection.Assembly = Reflection.Assembly.LoadFrom(Exe)
        GetExeVer = GetAssVer(Ass)
        Ass = Nothing
    End Function
    Public Function GetAppVer() As Double
        Dim asm As Reflection.Assembly = Reflection.Assembly.GetExecutingAssembly()
        Return GetAssVer(asm)
    End Function


#End Region

#Region "检查控件文件"
    Public Sub CheckFile()
        Dim R As New DtReturnMsg
        Try
            R = SqlStrToDt("select DOcx_Name,DOcx_MD5,DOcx_Reg,isnull(DOcx_Compress,0)as DOcx_Compress from DOcx_File")
            If R.IsOk = False Then
                End
            End If
        Catch ex As Exception
            End
        End Try
        Dim F As String = ""
        Dim Md5 As String = ""
        For j As Integer = 0 To R.Dt.Rows.Count - 1
            F = R.Dt.Rows(j).Item("DOcx_Name")
            Md5 = FileToMD5(AppPath & F)
            If Md5 = "" Or Md5.ToUpper <> R.Dt.Rows(j).Item("DOcx_MD5").ToString.ToUpper Then
                If DocxToFile(AppPath & F, R.Dt.Rows(j).Item("DOcx_Reg"), R.Dt.Rows(j).Item("DOcx_Compress")) Then
                    If R.Dt.Rows(j).Item("DOcx_Reg") Then
                        AddDown(F, "uc", OcxUpdate)
                    Else
                        AddDown(F, "ux", OcxUpdateReg)
                    End If
                End If
            End If
        Next
    End Sub

    ''' <summary>
    ''' 下载Docx文件
    ''' </summary>
    ''' <param name="Docx"></param>
    ''' <param name="Reg"></param>
    ''' <param name="Compress"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function DocxToFile(ByVal Docx As String, Optional ByVal Reg As Boolean = False, Optional ByVal Compress As Boolean = False) As Boolean
        Try
            If IO.Path.GetFileName(Docx).ToUpper = "DLLUpdate.exe".ToUpper Then
                If My.Computer.FileSystem.FileExists(DllPath & IO.Path.GetFileName(Docx)) Then
                    Kill(DllPath & IO.Path.GetFileName(Docx))
                End If
                'GetDbFile("select DOcx_File from DOcx_File where DOcx_Name='" & IO.Path.GetFileName(Docx) & "'", Docx)
                If Compress Then
                    GetDbFileDeCompress("DOcx_File", "DOcx_File", " where DOcx_Name='" & IO.Path.GetFileName(Docx) & "'", Docx)
                Else
                    GetDbFile("DOcx_File", "DOcx_File", " where DOcx_Name='" & IO.Path.GetFileName(Docx) & "'", Docx)
                End If
                Return IO.File.Exists(Docx)
            Else
                'GetDbFile("select DOcx_File from DOcx_File where DOcx_Name='" & IO.Path.GetFileName(Docx) & "'", Docx & IIf(Reg, ".uc", ".ux"))
                If Compress Then
                    GetDbFileDeCompress("DOcx_File", "DOcx_File", " where DOcx_Name='" & IO.Path.GetFileName(Docx) & "'", Docx & IIf(Reg, "uc", "ux"))
                Else
                    GetDbFile("DOcx_File", "DOcx_File", " where DOcx_Name='" & IO.Path.GetFileName(Docx) & "'", Docx & IIf(Reg, "uc", "ux"))
                End If
                Return IO.File.Exists(Docx & IIf(Reg, "uc", "ux"))
            End If

            Exit Function
        Catch ex As Exception
            MsgBox("更新错误," & ex.ToString)
            Return False
        End Try

    End Function
#End Region
End Module
