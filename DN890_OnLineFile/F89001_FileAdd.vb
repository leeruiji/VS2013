Imports PClass.PClass
Public Class F89001_FileAdd
    Public Temp As String = AppPath & "Temp\"
    Public FileName As String = ""
    Public Type As String = ""
    Public TempName As String = Now.ToString("yyyy-MM-dd_HH.mm.ss")
    Dim F_ID As Integer = 0
    Dim Ver As Double = 0
    Dim LVer As Double = 0
    Dim Founder As String = ""

    Private Sub F89001_FileAdd_ClosedX() Handles Me.ClosedX

    End Sub


    Private Sub Form_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MDDir(Temp)
        Randomize()
        TempName = TempName & "-" & CLng(Rnd() * 10000000 + 1)
        If (Mode = Mode_Enum.Add Or F_RS_ID = "") Then
            If CheckRight(89000, ClassMain.Add) = False Then Me.ShowErrMsg("没有权限添加!", True) : Exit Sub
            Mode = Mode_Enum.Add
            Founder = User_Id
            Cmd_Modify.Visible = False
            TimerStart.Start()
        ElseIf Mode = Mode_Enum.Modify Then
            '权限分析
            Dim Parameters As New Dictionary(Of String, Object)
            Parameters.Add("User_ID", User_Id)
            Parameters.Add("FileName", F_RS_ID)
            Dim R As DtReturnMsg = SqlStrToDt(SQL_89001_FormLoad, Parameters)
            If R.IsOk = False Then
                Exit Sub
            Else
                LastForm.ReturnId = F_RS_ID
                If R.Dt.Rows.Count = 0 And User_Id <> "Admin" Then
                    ShowErrMsg("你没有权限打开该文档!", True)
                    Exit Sub
                Else
                    If User_Id <> "Admin" AndAlso IsNull(R.Dt.Rows(0)("CanOpen"), False) = False Then
                        ShowErrMsg("你没有权限打开该文档!", True)
                        Exit Sub
                    End If
                    If User_Id <> "Admin" AndAlso IsNull(R.Dt.Rows(0)("CanModify"), False) = False Then
                        Cmd_Modify.Enabled = False
                        Cmd_Modify.Tag = False
                    End If
                    If User_Id <> "Admin" AndAlso IsNull(R.Dt.Rows(0)("CanDel"), False) = False Then
                        Cmd_Del.Enabled = False
                        Cmd_Del.Tag = False
                    End If
                End If
            End If
            Cmd_Add.Visible = False
            TempName = GetFile(F_RS_ID, 0)
            If TempName <> "" Then
                Select Case Type.ToLower
                    Case "word"
                        OFX.OpenWord(TempName)
                    Case "excel"
                        OFX.OpenExcel(TempName)
                    Case "powerpoint"
                        OFX.OpenPowerPoint(TempName, 0, 0, 0)
                End Select
                OFX.Open(TempName)
                FileName = F_RS_ID
                OFX.Toolbars = False
                OFX.Toolbars = True
            Else
                ShowErrMsg("加载文件错误或文件[" & F_RS_ID & "]已经被删除!", True)
            End If
        Else
            Cmd_Modify.Visible = False
        End If
    End Sub

#Region "-----导航栏事件-----"
    '新增
    Private Sub Cmd_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Add.Click
        FileName = TextBox_FileName.Text
        FileName = FileName.Replace("'", "")
        If FileName = "" Then
            ShowErrMsg("文件名不能为空！")
            TextBox_FileName.Focus()
            Exit Sub
        End If
        'If CheckFile(FileName) = True Then
        '    ShowErrMsg("保存失败!已存在文件名为[" & FileName & "]的文件,不能添加!")
        '    Exit Sub
        'End If


        Dim Ver As Double = GetFielVer(FileName)
        If Ver > 1 Then
            ShowMsg("文件[" & FileName & "]已存在！", Me.Title)
            Exit Sub
        Else
            Dim R As MsgReturn = SaveFile(FileName, Ver, Type, TextBox_Remark.Text)
            If R.IsOk Then
                ShowOk(R.Msg, True)
            Else
                ShowErrMsg(R.Msg)
                LastForm.ReturnId = FileName
            End If
        End If
    End Sub

    Protected Sub InsertFileRight()

    End Sub

    '修改
    Private Sub Cmd_Modify_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmd_Modify.Click
        FileName = TextBox_FileName.Text
        FileName = FileName.Replace("'", "")
        If FileName = "" Then
            ShowErrMsg("文件名不能为空！")
            TextBox_FileName.Focus()
            Exit Sub
        End If
        If CheckFile(F_ID) = False Then
            ShowErrMsg("保存失败!文件名为[" & FileName & "]已经被删除!")
            Exit Sub
        End If
        Dim Ver As Double = GetFielVer(FileName)
        Me.Ver = Ver
        If CInt((Ver - Me.LVer) * 100) > 1 Then
            ShowConfirm("原文件[" & FileName & "]已经被其他人修改过,是否覆盖其他的修改?", AddressOf ModifyFile)
            Exit Sub
        Else
            ModifyFile()
        End If
    End Sub


    Sub ModifyFile()
        Dim R As MsgReturn = SaveFile(FileName, Ver, Type, TextBox_Remark.Text)
        If R.IsOk = False Then
            ShowErrMsg(R.Msg)
        Else
            ShowOk(R.Msg, True)
            LastForm.ReturnId = FileName
        End If
    End Sub


    Private Sub Tool_Top_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Tool_Top.MouseEnter
        Tool_Top.Focus()
    End Sub

    '打印
    Private Sub Cmd_Print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Print.Click
        OFX.PrintPreview()
    End Sub

    ''' <summary>
    ''' 关闭页面
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub
#End Region


#Region "控件事件"
    Sub Col_SetValue(ByVal Row As Data.DataRow)
        TextBox_FileName.Text = Row("Name")
        TextBox_Remark.Text = Row("Remark")
        Type = Row("Type")
        FileName = Row("Name")
    End Sub




    Private Sub OFX_BeforeDocumentOpened(ByVal sender As Object, ByVal e As System.EventArgs) Handles OFX.BeforeDocumentOpened
        OFX.DisableFileCommand(EDOfficeLib.WdUIType.wdUIDisalbeSave, True)
        OFX.DisableFileCommand(EDOfficeLib.WdUIType.wdUIDisalbeSaveAs, True)
        OFX.DisableFileCommand(EDOfficeLib.WdUIType.wdUIDisalbeSaveAsMenu, True)
        OFX.DisableFileCommand(EDOfficeLib.WdUIType.wdUIDisalbePrint, True)
        OFX.DisableFileCommand(EDOfficeLib.WdUIType.wdUIDisalbePrintQuick, True)
        OFX.DisableFileCommand(EDOfficeLib.WdUIType.wdUIDisalbePublishMenu, True)
    End Sub
#End Region


#Region "-----新建窗口处理-----"
    Private Sub Cmd_Open_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Open.Click
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.Filter = "所支持的文档|*.Doc;*.xls|Word文档|*.doc|Excel文档|*.xls"
        OpenFileDialog1.Multiselect = False
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            Select Case OpenFileDialog1.FileName.Substring(OpenFileDialog1.FileName.Length - 3).ToLower
                Case "xls"
                    Type = "Excel"
                    Try
                        FileCopy(OpenFileDialog1.FileName, Temp & TempName)
                        If OFX.OpenExcel(Temp & TempName) = False Then
                            Kill(Temp & TempName)
                            Exit Sub
                        End If
                    Catch ex As Exception
                    End Try
                Case "doc"
                    Type = "Word"
                    Try
                        FileCopy(OpenFileDialog1.FileName, Temp & TempName)
                        If OFX.OpenWord(Temp & TempName) = False Then
                            Kill(Temp & TempName)
                            Exit Sub
                        End If
                    Catch ex As Exception
                    End Try
                Case Else
                    Exit Sub
            End Select
            TempName = Temp & TempName
            OFX.Toolbars = False
            OFX.Toolbars = True
            Panel_New.Visible = False
            PanelMain.Enabled = True
        End If

    End Sub


    '创建Word
    Private Sub Cmd_NewWord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_NewWord.Click
        Type = "Word"
        TempName = Temp & TempName & ".doc"
        OFX.NewWord()
        OFX.Toolbars = False
        OFX.Toolbars = True
        Panel_New.Visible = False
        PanelMain.Enabled = True
    End Sub
    '创建Excel
    Private Sub Cmd_NewExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_NewExcel.Click
        Type = "Excel"
        TempName = Temp & TempName & ".xls"
        OFX.NewExcel()
        OFX.Toolbars = False
        OFX.Toolbars = True
        Panel_New.Visible = False
        PanelMain.Enabled = True
    End Sub
    '打开New界面
    Private Sub TimerStart_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerStart.Tick
        ShowNew()
    End Sub
    '显示New界面
    Sub ShowNew()
        TimerStart.Stop()
        CaptureFromImageToPicture(Me, Panel_New)
        Panel_New.BringToFront()
        PanelMain.Enabled = False
        GroupBox_New.Left = Panel_New.Width / 2 - GroupBox_New.Width / 2
        GroupBox_New.Top = Panel_New.Height / 2 - GroupBox_New.Height / 2
        GroupBox_New.Visible = True
        GroupBox_New.BringToFront()
        Panel_New.Visible = True
    End Sub
    '退出
    Private Sub Cmd_NewExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_NewExit.Click
        Me.Close(True)
    End Sub
#End Region


#Region "-----数据库交换-----"


    Function CheckFile(ByVal FID As Integer) As Boolean
        If Val(SqlStrToOneStr("select COunt(Name) from T890_OnlineFile where ID =@ID", "@ID", FID).Msg) = 0 Then
            Return False
        Else
            Return True
        End If
    End Function


    Private Sub F89001_FileAdd_Me_Closed() Handles Me.Me_Closed
        Try
            My.Computer.FileSystem.DeleteFile(TempName)
        Catch ex As Exception
        End Try
        Try
            OFX.DisableFileCommand(EDOfficeLib.WdUIType.wdUIDisalbeSave, False)
            OFX.DisableFileCommand(EDOfficeLib.WdUIType.wdUIDisalbeSaveAs, False)
            OFX.DisableFileCommand(EDOfficeLib.WdUIType.wdUIDisalbeSaveAsMenu, False)
            OFX.DisableFileCommand(EDOfficeLib.WdUIType.wdUIDisalbePrint, False)
            OFX.DisableFileCommand(EDOfficeLib.WdUIType.wdUIDisalbePrintQuick, False)
            OFX.DisableFileCommand(EDOfficeLib.WdUIType.wdUIDisalbePublishMenu, False)
        Catch ex As Exception

        End Try
    End Sub

    Function GetFielVer(ByVal FileName As String) As Double
        Dim Vr As MsgReturn = SqlStrToOneStr(SQL_89001_SaveFile, "@Name", FileName)
        If Vr.IsOk = False Then Return 0 Else Return Val(Vr.Msg)
    End Function


    ''' <summary>
    ''' 加载文件
    ''' </summary>
    ''' <param name="FileName"></param>
    ''' <param name="Ver">-1为最新</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetFile(ByVal FileName As String, Optional ByVal Ver As Double = 0) As String
        Dim Rt As New DtReturnMsg
        Rt = SqlStrToDt("select top 1 * from V89000_NewFile where Name='" & FileName & "'")
        If Rt.IsOk = False Then Return ""
        If Rt.Dt.Rows.Count > 0 Then
            '不是最新下载
            Try
                F_ID = Rt.Dt.Rows(0)("ID")
                Me.LVer = Rt.Dt.Rows(0)("Ver")
                Founder = Rt.Dt.Rows(0)("Founder")
                Labeld_Founder.Text = Rt.Dt.Rows(0)("FounderName")
                Lable_UPD_USER.Text = Rt.Dt.Rows(0)("UPD_Name")
                If Rt.Dt.Rows(0).Item("Compress") Then
                    If GetDbFileDeCompress("T890_OnlineFile", "data", " where Name='" & FileName & "' and Ver=" & Rt.Dt.Rows(0).Item("Ver"), Temp & TempName) Then
                        Col_SetValue(Rt.Dt.Rows(0))
                        Return Temp & TempName
                    Else
                        Return ""
                    End If
                Else
                    If GetDbFile("T890_OnlineFile", "data", " where Name='" & FileName & "' and Ver=" & Rt.Dt.Rows(0).Item("Ver"), Temp & TempName) Then
                        Col_SetValue(Rt.Dt.Rows(0))
                        Return Temp & TempName
                    Else
                        Return ""
                    End If
                End If
            Catch ex As Exception
                Return ""
            End Try
        Else
            Return ""
        End If
    End Function


    ''' <summary>
    ''' 保存文件
    ''' </summary>
    ''' <param name="FileName"></param>
    ''' <param name="Ver"></param>
    ''' <param name="Type"></param>
    ''' <param name="Remark"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function SaveFile(ByVal FileName As String, ByVal Ver As Double, ByVal Type As String, ByVal Remark As String) As MsgReturn
        Dim SaveReturn As New MsgReturn
        Try
            OFX.SaveAs(TempName)
            OFX.CloseDoc()
        Catch ex As Exception
            SaveReturn.Msg = "保存失败" & ex.Message
            Return SaveReturn
        End Try
        Dim sqlbuider As New System.Text.StringBuilder
        Dim R As MsgReturn

        sqlbuider.AppendLine("insert into T890_OnlineFile (Name,Ver,Type,Remark,Founder,UPD_USER,UPD_DATE)values('" & FileName & "'," & Ver & ",'" & Type & "','" & Remark & "','" & Founder & "','" & User_Id & "',getdate())")
        If Me.Mode = Mode_Enum.Add Then
            sqlbuider.AppendLine("insert into T891_FileRight (FileName,User_ID,CanOpen,CanModify,CanDel,CanSetRight)values('" & FileName & "','" & PClass.PClass.User_Id & "'," & 1 & "," & 1 & "," & 1 & "," & 1 & ")")
        Else
            sqlbuider.AppendLine("delete from  T890_OnlineFile where Name ='" & Name & "' and Ver<'" & Ver - 0.05 & "'")
        End If
        R = RunSQL(sqlbuider.ToString)
        If R.IsOk = False Then Return R
        If InputFileToDbCompress(TempName, "T890_OnlineFile", "Data", ",Compress=1 where Name='" & FileName & "' and Ver=" & Ver & " ") Then

            SaveReturn.Msg = "保存成功"
            SaveReturn.IsOk = True
        Else
            SaveReturn.Msg = "保存失败"
        End If
        Return SaveReturn
    End Function

#End Region











  

End Class
