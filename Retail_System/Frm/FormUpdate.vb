
Imports PClass.PClass
Imports System.Reflection

Public Class FormUpdate

    Private Sub FormUpdate_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub

    Private Sub FormUpdate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Cmd_PClass_Update.Enabled = User_Update
        Cmd_Exe_Update.Enabled = User_Update
        Cmd_CE_Update.Enabled = User_Update
        Cmd_DLL_Update.Enabled = User_Update
        Cmd_BaseClass_Update.Enabled = User_Update
        Cmd_Msg.Enabled = User_Update
        CmdADDFJ.Enabled = User_Update
        Cmd_Bill.Visible = User_Update
        If User_Update = False Then Me.Text = "已加载的DLL列表和附件列表"

        'FG_INI(FG)
        'FG_INI(FG2)

        GetDLLMsg() '获取最新的DLL
        GetExeMsg()
    End Sub

    Sub GetExeMsg()
        Dim j As Integer = 0
        Dim d As String = ""
        Label_NowVer.Text = GetAppVer().ToString
        Label_PClassNowVer.Text = FormatN(GetPClassVer(), 2)
        Label_BaseClassNowVer.Text = FormatN(GetBaseClassVer(), 2)
        FindExeVer()
    End Sub


    Sub FindExeVer()
        Dim i As Integer
        Dim EFlie As String = IO.Path.GetFileName(Application.ExecutablePath)
        Dim DFile As String = "pclass.dll"
        Dim BFile As String = "baseclass.dll"
        Dim Dt As New DataTable
        Dim R As DtReturnMsg = SqlStrToDt("[GetNewExe]")
        If R.IsOk = False Then Exit Sub
        Dt = R.Dt
        Label_DBVer.Text = "0"
        Label_DBDate.Text = ""
        Label_PCLassVer.Text = "0"
        Label_PCLassDate.Text = ""
        Label_BaseCLassVer.Text = "0"
        Label_BaseCLassDate.Text = ""
        For i = 0 To Dt.Rows.Count - 1
            If IsNull(Dt.Rows(i).Item("exe_name"), "").ToString.ToUpper = EFlie.ToUpper Then
                Label_DBVer.Text = FormatN(IsNull(Dt.Rows(i).Item("exe_ver"), 0), 2)
                Label_DBDate.Text = IsNull(Dt.Rows(i).Item("Exe_Date"), 0)
            End If
            If IsNull(Dt.Rows(i).Item("exe_name"), "").ToString.ToUpper = DFile.ToUpper Then
                Label_PCLassVer.Text = FormatN(IsNull(Dt.Rows(i).Item("exe_ver"), 0), 2)
                Label_PCLassDate.Text = IsNull(Dt.Rows(i).Item("Exe_Date"), 0)
            End If
            If IsNull(Dt.Rows(i).Item("exe_name"), "").ToString.ToUpper = BFile.ToUpper Then
                Label_BaseCLassVer.Text = FormatN(IsNull(Dt.Rows(i).Item("exe_ver"), 0), 2)
                Label_BaseCLassDate.Text = IsNull(Dt.Rows(i).Item("Exe_Date"), 0)
            End If
        Next
    End Sub



    Sub GetDLLMsg()
        Dim i As Integer = 0
        Dim d As String = ""
        Fg1.Rows.Count = 1
        Fg1.Rows.Count = DllUpdateList.Count + 1
        Fg1.ReAddIndex()
        For Each DllUpdate As DllUpdateListType In DllUpdateList
            i = i + 1
            Try
                Fg1.Item(i, "DLL_Name") = IO.Path.GetFileName(DllUpdate.FileName)
                Fg1.Item(i, "File_Path") = DllUpdate.FileName
                Fg1.Item(i, "NVer") = DllUpdate.Ver
                Fg1.Item(i, "MenuName") = DllUpdate.MenuName
                Fg1.Item(i, "ModuleName") = DllUpdate.ModuleName
                Fg1.Item(i, "IsUpdate") = False

                Fg1.Item(i, "Size") = FileLens(DllUpdate.FileName)
                Fg1.Item(i, "SizeShow") = FileLenStr(Fg1.Item(i, "Size"))
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Next
        FindVer()

    End Sub

    ''' <summary>
    ''' 获取文件的大小 ,自动划分G M K
    ''' </summary>
    ''' <param name="L"></param>
    ''' <returns></returns>
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

    Function FileLens(ByVal File As String) As Long
        Try
            Return FileLen(File)
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Sub FindVer()
        On Error GoTo ToExit '打开错误陷阱
        '------------------------------------------------
        Dim i As Integer
        Dim j As Integer
        Dim R As DtReturnMsg = SqlStrToDt("[GetNewDLL]")
        If R.IsOk = False Then Exit Sub
        Dim Dt As DataTable = R.Dt
        If Dt.Rows.Count > 0 Then
            For i = 1 To Fg1.Rows.Count - 1
                For j = 0 To Dt.Rows.Count - 1
                    If Dt.Rows(j).Item("DLL_Name") = Fg1.Item(i, "DLL_Name") Then
                        Fg1.Item(i, "DLL_Ver") = Dt.Rows(j).Item("DLL_Ver")
                        Fg1.Item(i, "DLL_Date") = Dt.Rows(j).Item("DLL_Date")
                        Exit For
                    End If
                Next j
            Next i
        End If
        Dim K As Long = 0
        Dim K2 As Long = 0
        For i = 1 To Fg1.Rows.Count - 1
            If Val(Fg1.Item(i, "DLL_Ver")) = 0 Then
                Fg1.Item(i, "IsUpdate") = True
                K = K + Fg1.Item(i, "Size")
            Else
                If Val(Fg1.Item(i, "DLL_Ver")) <> Val(Fg1.Item(i, "NVer")) Then
                    Fg1.Item(i, "IsUpdate") = True
                    K = K + Fg1.Item(i, "Size")
                End If
            End If
            K2 = K2 + Fg1.Item(i, "Size")
        Next
        Label2.Text = "更新:" & FileLenStr(K)
        Label4.Text = "总共:" & FileLenStr(K2)
        '------------------------------------------------
        Exit Sub
        '----------------
ToExit:

    End Sub

    Sub TotalDLL()
        Dim K As Long = 0
        Dim K2 As Long = 0
        For i = 1 To Fg1.Rows.Count - 1

            If Fg1.Item(i, "IsUpdate") = True Then
                K = K + Fg1.Item(i, "Size")
            End If
            K2 = K2 + Fg1.Item(i, "Size")

        Next
        Label2.Text = "更新:" & FileLenStr(K)
        Label4.Text = "总共:" & FileLenStr(K2)
    End Sub
    Private Sub Fg1_BeforeEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles Fg1.BeforeEdit
        If e.Row = 0 Or e.Col <> 7 Then
            e.Cancel = True
        Else
            TotalDLL()
        End If
    End Sub

    Private Sub Cmd_DLL_Update_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_DLL_Update.Click
        LabelMsg.Visible = True
        Dim i As Integer
        Dim S As String
        Dim N As Integer
        Dim NI As Integer
        For i = 1 To Fg1.Rows.Count - 1
            If Fg1.Item(i, "IsUpdate") Then
                Dim R As MsgReturn = SqlStrToOneStr("select count(DLL_Name) from dll_File where DLL_Name='" & Fg1.Item(i, "DLL_Name") & "' and dll_Ver='" & Fg1.Item(i, "NVer") & "' ")
                If R.IsOk = False Then Exit Sub
                S = R.Msg
                If S <> "0" Then
                    If MsgBox("[" & Fg1.Item(i, "DLL_Name") & "]的[" & FormatN(Fg1.Item(i, "NVer"), 2) & "]版已存在,是否重新写入数据库?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        '写入数据库
                        If UpdateDLLToFile(Fg1.Item(i, "File_Path"), Val(Fg1.Item(i, "NVer"))) Then
                            NI = NI + 1
                        End If
                    End If
                Else
                    If InsertDLLToFile(Fg1.Item(i, "File_Path"), Val(Fg1.Item(i, "NVer"))) Then N = N + 1
                End If
            End If
            LabelMsg.Text = "系统更新模块 - " & N & "个DLL被写入," & NI & "个DLL被更新!"
            LabelMsg.Refresh()
        Next i
        GetDLLMsg()
        LabelMsg.Visible = False
        MsgBox("更新完毕!" & N & "个DLL被写入," & NI & "个DLL被更新!", MsgBoxStyle.Information, Me.Text)
    End Sub


    Private Sub Cmd_Exe_Update_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exe_Update.Click
        Dim S As String
        If Val(Label_NowVer.Text) < Val(Label_DBVer.Text) Then
            If Not MsgBox("系统版本比当前版本还要高是否继续更新?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Exit Sub
            End If
        End If
        Dim R As MsgReturn = SqlStrToOneStr("select count(exe_name) from Exe_File where exe_name='" & IO.Path.GetFileName(Application.ExecutablePath).ToUpper & "' and Exe_Ver='" & Val(Label_NowVer.Text) & "' ")
        If R.IsOk = False Then Exit Sub
        S = R.Msg
        If S <> "0" Then
            If MsgBox("主程序的[" & Label_NowVer.Text & "]版已存在,是否重新写入数据库?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                '写入数据库
                LabelMsg.Text = "正在重新写入主程序"
                LabelMsg.Show()
                If UpdateExeoFileUnCompress(Application.ExecutablePath, Val(Label_NowVer.Text)) Then
                    MsgBox("更新主程序成功!", MsgBoxStyle.Information, Me.Text)
                End If
                LabelMsg.Hide()
            End If
        Else
            LabelMsg.Text = "正在重新写入主程序"
            LabelMsg.Show()
            If InsertExeToFileUnCompress(Application.ExecutablePath, Val(Label_NowVer.Text)) Then
                MsgBox("更新主程序成功!", MsgBoxStyle.Information, Me.Text)
            End If
            LabelMsg.Hide()
        End If
        GetExeMsg()
    End Sub


    Private Sub Cmd_PClass_Update_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_PClass_Update.Click
        Dim S As String
        If Val(Label_PClassNowVer.Text) < Val(Label_PCLassVer.Text) Then
            If Not MsgBox("系统版本比当前版本还要高是否继续更新?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Exit Sub
            End If
        End If
        Dim R As MsgReturn = SqlStrToOneStr("select count(exe_name) from Exe_File where exe_name='" & "pclass.dll".ToUpper & "' and Exe_Ver='" & Val(Label_PClassNowVer.Text) & "' ")
        If R.IsOk = False Then Exit Sub
        S = R.Msg
        If S <> "0" Then
            If MsgBox("PClass的[" & Label_PClassNowVer.Text & "]版已存在,是否重新写入数据库?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                LabelMsg.Text = "正在重新写入PCLass"
                LabelMsg.Show()
                '写入数据库
                If UpdateExeoFileUnCompress(DllPath & "pclass.dll", Val(Label_PClassNowVer.Text)) Then
                    MsgBox("更新PClass成功!", MsgBoxStyle.Information, Me.Text)
                End If
                LabelMsg.Hide()
            End If
        Else
            LabelMsg.Text = "正在更新PCLass"
            If InsertExeToFileUnCompress(DllPath & "pclass.dll", Val(Label_PClassNowVer.Text)) Then
                MsgBox("更新PClass成功!", MsgBoxStyle.Information, Me.Text)
            End If
            LabelMsg.Hide()
        End If
        GetExeMsg()
    End Sub



    Function FindExeVer(ByVal EFlie As String) As Double
        Dim i As Integer
        Dim R As DtReturnMsg = SqlStrToDt("[GetNewExe]")
        If R.IsOk = False Then Return 0
        Dim Dt As DataTable = R.Dt
        For i = 0 To Dt.Rows.Count - 1
            If IsNull(Dt.Rows(i).Item("exe_name"), "").ToString.ToUpper = EFlie.ToUpper Then
                Return IsNull(Dt.Rows(i).Item("exe_ver"), 0)

            End If
        Next
    End Function

    Private Sub Cmd_CE_Update_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_CE_Update.Click
        Dim OpenFile As System.Windows.Forms.OpenFileDialog = New System.Windows.Forms.OpenFileDialog
        With OpenFile
            .Filter = "CE系统文件|*.exe"
            .FilterIndex = 1
            .InitialDirectory = "D:\"
            .Title = "打开文件"
            .Multiselect = False
            .ReadOnlyChecked = True
        End With
        Dim s As String
        Dim V As Double = 1.1
        If OpenFile.ShowDialog(MainWindow.CommandBars) = Windows.Forms.DialogResult.OK Then
            Try
                If OpenFile.FileName <> "" Then
                    V = GetExeVer(OpenFile.FileName)
                    If FindExeVer(OpenFile.FileName) > V Then
                        If Not MsgBox("系统版本比当前版本还要高是否继续更新?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                            Exit Sub
                        End If
                    End If
                    Dim R As MsgReturn = SqlStrToOneStr("select count(exe_name) from Exe_File where exe_name='" & IO.Path.GetFileName(OpenFile.FileName).ToUpper & "' and Exe_Ver='" & Val(V) & "' ")
                    If R.IsOk = False Then Exit Sub
                    s = R.Msg
                    If s <> "0" Then
                        If MsgBox("主程序的[" & IO.Path.GetFileName(OpenFile.FileName) & "]版已存在,是否重新写入数据库?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                            '写入数据库
                            LabelMsg.Text = "正在重新CE程序"
                            LabelMsg.Show()
                            If UpdateExeoFileUnCompress(OpenFile.FileName, Val(V)) Then
                                MsgBox("更新CE程序成功,更新后的" & IO.Path.GetFileName(OpenFile.FileName) & "的版本为:" & V, MsgBoxStyle.Information, Me.Text)
                            End If
                            LabelMsg.Hide()
                        End If
                    Else
                        LabelMsg.Text = "更新CE程序"
                        LabelMsg.Show()
                        If InsertExeToFileUnCompress(OpenFile.FileName, Val(V)) Then
                            MsgBox("更新CE程序成功,更新后的" & IO.Path.GetFileName(OpenFile.FileName) & "的版本为:" & V, MsgBoxStyle.Information, Me.Text)
                        End If
                        LabelMsg.Hide()
                    End If
                Else
                End If
            Catch ex As Exception
                MsgBox(ex.ToString, MsgBoxStyle.Exclamation, Me.Text)
            End Try
        End If
        OpenFile.Dispose()
    End Sub

    Sub GetDocxMsg()
        Fg2.SqlToFG("select DOcx_Name,DOcx_MD5,DOcx_Date,DOcx_Reg,'删除' as [Del] from DOcx_File order by DOcx_Name")
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Button1.Text = "附件列表" Then
            Fg1.Visible = False
            FG2.Visible = True
            CmdADDFJ.Visible = True
            Cmd_DLL_Update.Visible = False
            Button1.Text = "返回"
            GetDocxMsg()
        Else
            Fg1.Visible = True
            FG2.Visible = False
            Cmd_DLL_Update.Visible = True
            CmdADDFJ.Visible = False
            Button1.Text = "附件列表"
            GetDLLMsg()
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdADDFJ.Click
        If User_Update = False Then
            MsgBox("您没有权限添加附件!", MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        End If
        Dim OpenFile As System.Windows.Forms.OpenFileDialog = New System.Windows.Forms.OpenFileDialog
        With OpenFile
            .Filter = "任何文件|*.*"
            .FilterIndex = 1
            '.InitialDirectory = "C:\"
            .Title = "打开文件"
            .Multiselect = False
            .ReadOnlyChecked = True
        End With
        Dim s As String
        If OpenFile.ShowDialog(MainWindow.CommandBars) = Windows.Forms.DialogResult.OK Then
            Try
                If OpenFile.FileName <> "" Then
                    Dim R As MsgReturn = SqlStrToOneStr("select DOcx_MD5 from DOcx_File where DOcx_Name='" & IO.Path.GetFileName(OpenFile.FileName).ToUpper & "'  ")
                    If R.IsOk = False Then Exit Sub
                    s = R.Msg
                    Dim M As String = FileToMD5(OpenFile.FileName)
                    If s <> "" Then
                        If s = M Then
                            MsgBox("[" & IO.Path.GetFileName(OpenFile.FileName) & "]已存在数据库,而且文件内容一样,无需再添加", MsgBoxStyle.Information, Me.Text)
                            Exit Sub
                        End If
                        If MsgBox("文件[" & IO.Path.GetFileName(OpenFile.FileName) & "]已存在,但内容不一样,是否重新写入数据库?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                            '写入数据库
                            If UpdateDocxFile(OpenFile.FileName, M) Then
                                MsgBox("更新附件" & IO.Path.GetFileName(OpenFile.FileName) & "成功,MD5为:" & M, MsgBoxStyle.Information, Me.Text)
                                GetDocxMsg()
                            End If
                        End If
                    Else
                        If InsertDocxToFile(OpenFile.FileName, M) Then
                            MsgBox("更新附件" & IO.Path.GetFileName(OpenFile.FileName) & "成功,MD5为:" & M, MsgBoxStyle.Information, Me.Text)
                            GetDocxMsg()
                        End If
                    End If
                Else
                End If
            Catch ex As Exception
                MsgBox(ex.ToString, MsgBoxStyle.Exclamation, Me.Text)
            End Try
        End If
    End Sub

 



    Private Sub FG2_ClickEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fg2.Click
        If User_Update = False Then
            MsgBox("您没有权限删除附件!", MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        End If
        If Fg2.RowSel > 0 And Fg2.ColSel = Fg2.Cols("Del").Index Then
            If MsgBox("是否删除[" & Fg2.SelectItem("DOcx_Name") & "]这个附件?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                RunSQL("delete from DOcx_File where DOcx_Name='" & Fg2.SelectItem("DOcx_Name") & "'", False, False)
                GetDocxMsg()
            End If
        End If
        If Fg2.RowSel > 0 And Fg2.ColSel = Fg2.Cols("DOcx_Reg").Index Then
            If Fg2.SelectItem("DOcx_Reg") = False Then
                If MsgBox("是否设置[" & Fg2.SelectItem("DOcx_Name") & "]这个附件为非注册附件?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    RunSQL("update  DOcx_File set Docx_Reg=0 where DOcx_Name='" & Fg2.SelectItem("DOcx_Name") & "'", False, False)
                    GetDocxMsg()
                End If
            Else
                If MsgBox("是否设置[" & Fg2.SelectItem("DOcx_Name") & "]这个附件为注册附件?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    RunSQL("update  DOcx_File set Docx_Reg=1 where DOcx_Name='" & Fg2.SelectItem("DOcx_Name") & "'", False, False)
                    GetDocxMsg()
                End If
            End If
        End If
    End Sub

    Private Sub FG_DblClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fg1.DoubleClick
        If User_Update = False Then
            MsgBox("您没有权限删除附件!", MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        End If
        If Fg1.RowSel > 0 Then
            If Fg1.ColSel = Fg1.Cols("DLL_Date").Index Then
                Dim r As DtReturnMsg = SqlStrToDt("select DLL_Date,DLL_Ver from DLL_File where DLL_Name=@DLL_Name order by DLL_Date desc", "DLL_Name", Fg1.SelectItemX("DLL_Name"))
                Dim S As New System.Text.StringBuilder("")
                For Each row As DataRow In r.Dt.Rows
                    S.Append(Format(row("DLL_Ver"), "0.00"))
                    S.Append(" ")
                    S.AppendLine(row("DLL_Date"))
                Next
                MsgBox(S.ToString, MsgBoxStyle.OkOnly, "更新日志")
                Exit Sub
            End If
            If MsgBox("是否删除DLL[" & Fg1.SelectItemX("DLL_Name") & "]?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.Yes Then
                Try
                    Dim Parameters As New Dictionary(Of String, Object)
                    Parameters.Add("@DLL_Name", Fg1.SelectItemX("DLL_Name"))
                    Parameters.Add("@DLL_Ver", Fg1.SelectItemX("@DLL_Ver"))
                    If Val(RunSQL("delete from DLL_File where DLL_Name=@DLL_Name and DLL_Ver=@DLL_Ver", Parameters).Msg) > 0 Then
                        MsgBox("删除成功!")
                    Else
                        MsgBox("删除失败!")
                    End If
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try

            End If

            GetDLLMsg()
        End If
    End Sub




    Private Sub Cmd_BaseClass_Update_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_BaseClass_Update.Click
        Dim S As String
        If Val(Label_BaseClassNowVer.Text) < Val(Label_BaseCLassVer.Text) Then
            If Not MsgBox("系统版本比当前版本还要高是否继续更新?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Exit Sub
            End If
        End If
        Dim R As MsgReturn = SqlStrToOneStr("select count(exe_name) from Exe_File where exe_name='" & "BaseClass.dll".ToUpper & "' and Exe_Ver='" & Val(Label_BaseClassNowVer.Text) & "' ")
        If R.IsOk = False Then Exit Sub
        S = R.Msg
        If S <> "0" Then
            If MsgBox("BaseClass的[" & Label_BaseClassNowVer.Text & "]版已存在,是否重新写入数据库?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                LabelMsg.Text = "正在重新写入BaseClass"
                LabelMsg.Show()
                '写入数据库
                If UpdateExeoFileUnCompress(DllPath & "BaseClass.dll", Val(Label_BaseClassNowVer.Text)) Then
                    MsgBox("更新BaseClass成功!", MsgBoxStyle.Information, Me.Text)
                End If
                LabelMsg.Hide()
            End If
        Else
            LabelMsg.Text = "正在更新BaseClass"
            If InsertExeToFileUnCompress(AppPath & "BaseClass.dll", Val(Label_BaseClassNowVer.Text)) Then
                MsgBox("更新BaseClass成功!", MsgBoxStyle.Information, Me.Text)
            End If
            LabelMsg.Hide()
        End If
        GetExeMsg()
    End Sub

#Region "写入数据库操作"
    '写入文件
    Public Function InsertDLLToFile(ByVal d As String, ByVal Nv As Double) As Boolean
        Try
            RunSQL("delete from dll_File where DLL_Ver=0" & vbCrLf & "Insert into dll_File (DLL_Name,DLL_Ver,DLL_Date,DLL_Compress)values('" & IO.Path.GetFileName(d) & "'," & 0 & ",getdate(),1)")
            Return InputFileToDbCompress(DllPath & IO.Path.GetFileName(d), "dll_File", "DLL_File", ",dll_date=getdate(),DLL_Compress=1,DLL_Ver =" & Nv & " where DLL_Name ='" & IO.Path.GetFileName(d) & "' and DLL_Ver =0")
            Return True
        Catch ex As Exception
            Return False
            ' IO.Path.
        End Try
    End Function
    '写入文件
    Public Function UpdateDLLToFile(ByVal d As String, ByVal Nv As Double) As Boolean
        Try
            UpdateDLLToFile = InputFileToDbCompress(DllPath & IO.Path.GetFileName(d), "dll_File", "DLL_File", ",dll_date=getdate(),DLL_Compress=1 where DLL_Name ='" & IO.Path.GetFileName(d) & "' and DLL_Ver =" & Nv)
        Catch ex As Exception
            Return False
        End Try
    End Function

    '写入exe文件(不压缩,手持终端和PDA有些不支持压缩的)
    Public Function InsertExeToFileUnCompress(ByVal d As String, ByVal Nv As Double) As Boolean
        Try
            RunSQL("delete from Exe_File where Exe_Ver=0" & vbCrLf & "Insert into Exe_File (Exe_Name,Exe_Ver,exe_Date)values('" & IO.Path.GetFileName(d) & "',0,getdate())")
            Return InputFileToDb(d, "Exe_File", "Exe_File", ",EXE_Date=getdate(),exe_Compress=0,Exe_Ver =" & Nv & " where Exe_Name ='" & IO.Path.GetFileName(d) & "' and Exe_Ver=0")
        Catch ex As Exception
            Return False
            ' IO.Path.
        End Try
    End Function

    '写入exe文件
    Public Function InsertExeToFile(ByVal d As String, ByVal Nv As Double) As Boolean
        Try
            RunSQL("delete from Exe_File where Exe_Ver=0" & vbCrLf & "Insert into Exe_File (Exe_Name,Exe_Ver,exe_Date)values('" & IO.Path.GetFileName(d) & "',0,getdate())")
            Return InputFileToDbCompress(d, "Exe_File", "Exe_File", ",EXE_Date=getdate(),exe_Compress=1,Exe_Ver =" & Nv & " where Exe_Name ='" & IO.Path.GetFileName(d) & "' and Exe_Ver =0")
        Catch ex As Exception
            Return False
            ' IO.Path.
        End Try
    End Function
    '写入exe文件
    Public Function UpdateExeoFile(ByVal d As String, ByVal Nv As Double) As Boolean
        Try
            Return InputFileToDbCompress(d, "Exe_File", "Exe_File", ",EXE_Date=getdate(),exe_Compress=1 where Exe_Name ='" & IO.Path.GetFileName(d) & "' and Exe_Ver =" & Nv)
        Catch ex As Exception
            Return False
        End Try
    End Function

    '写入exe文件(不压缩,手持终端和PDA有些不支持压缩的)
    Public Function UpdateExeoFileUnCompress(ByVal d As String, ByVal Nv As Double) As Boolean
        Try
            Return InputFileToDb(d, "Exe_File", "Exe_File", ",EXE_Date=getdate(),exe_Compress=0 where Exe_Name ='" & IO.Path.GetFileName(d) & "' and Exe_Ver =" & Nv)
        Catch ex As Exception
            Return False
        End Try
    End Function

    '更新Docx文件
    Public Function UpdateDocxFile(ByVal d As String, ByVal Md5 As String) As Boolean
        Try
            UpdateDocxFile = InputFileToDbCompress(d, "DOcx_File", "DOcx_File", ",DOcx_Date=getdate(),DOcx_md5 ='" & Md5 & "',DOcx_Compress=1 where DOcx_Name ='" & IO.Path.GetFileName(d) & "' ")
        Catch ex As Exception
            Return False
        End Try
    End Function
    '写入Docx文件
    Public Function InsertDocxToFile(ByVal d As String, ByVal Md5 As String) As Boolean
        Try
            SqlStrToOneStr("Insert into DOcx_File (DOcx_Name,DOcx_md5,DOcx_Date)values('" & IO.Path.GetFileName(d) & "','" & Md5 & "',getdate())")
            InsertDocxToFile = UpdateDocxFile(d, Md5)
        Catch ex As Exception
            Return False
            ' IO.Path.
        End Try
    End Function
#End Region

  
    

   
    Private Sub Cmd_Msg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Msg.Click
        Dim L As New Dictionary(Of String, String)
        L.Add("A", "Select top 1 * from FormatSet where ID='LastUpdateID'")
        Using G As New PClass.PClass.DtHelper(L, Nothing)
            If G.IsOk Then
                If G.DtList("A").Rows.Count = 0 Then
                    G.DtList("A").Rows.Add(G.DtList("A").NewRow)
                    G.DtList("A").Rows(0)("Id") = "LastUpdateID"
                    G.DtList("A").Rows(0)("Format") = 1
                End If
                G.DtList("A").Rows(0)("Format") = G.DtList("A").Rows(0)("Format") + 1
                If G.UpdateAll(True).IsOk = True Then
                    MsgBox("通知成功!", MsgBoxStyle.Information, AppName)
                Else
                    MsgBox("通知失败," & G.Msg, MsgBoxStyle.Exclamation, AppName)

                End If

            Else
                MsgBox("通知失败!", MsgBoxStyle.Exclamation, AppName)
            End If
        End Using
    End Sub

    Private Sub Cmd_Bill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Bill.Click
        Using F As New FormList
            F.ShowDialog()
        End Using
    End Sub
End Class