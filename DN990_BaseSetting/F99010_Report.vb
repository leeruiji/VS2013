Imports PClass
Imports grproLib
Imports PClass.PClass
Imports System.Data
Public Class F99010_Report
    Public WithEvents Report As GridppReport

#Region "-----窗体事件-----"
    ''' <summary>
    ''' 权限获取
    ''' </summary>
    ''' <remarks></remarks>
    Sub FormCheckRight()
        Control_CheckRight(ID, ClassMain.Add, Cmd_Add)
        Control_CheckRight(ID, ClassMain.Modify, Cmd_Modify)
        Control_CheckRight(ID, ClassMain.Del, Cmd_Del)
        Control_CheckRight(ID, ClassMain.FileOut, Cmd_FileOut)
    End Sub
    Private Sub Form_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        FormCheckRight()
        Me_Refresh()
    End Sub
#End Region
#Region "-----程序处理事件-----"
    ''' <summary>
    ''' 刷新FG
    ''' </summary>
    ''' <remarks></remarks>
    Sub Me_Refresh()
        VForm.HideShadow()
        FG1.SqlToFG(SQL_99010_GetNewReport)
        FG1.SortByLastOrder()
        FG1.RowSetForce("Report_MD5", ReturnId)
    End Sub

    Private Sub Edit_Retrun()
        If ReturnId <> "" Then
            Me_Refresh()
        End If
    End Sub

#Region "其他"

    Private Sub FG1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles FG1.DoubleClick
        RePort_Modify()
    End Sub

#End Region


#End Region

#Region "-----导航栏事件-----"
    '添加
    Private Sub Cmd_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Add.Click
        Dim F As New F99011_Report_Msg
        With F
            .Mode = Mode_Enum.Add
            .P_F_RS_ID = ""
            .P_F_RS_ID2 = True
        End With
        ReturnId = ""
        Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F, Me)
        AddHandler VF.ClosedX, AddressOf Edit_Retrun
        VF.Show()
    End Sub
    '刷新
    Private Sub Cmd_ReFresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_ReFresh.Click
        Edit_Retrun()
    End Sub
    '修改
    Private Sub Cmd_Modify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Modify.Click
        RePort_Modify()
    End Sub

    Sub RePort_Modify()
        If FG1.RowSel <= 0 Then ShowErrMsg("请选择一个要修改的报表!") : Exit Sub
        Dim F As New F99011_Report_Msg
        With F
            .Mode = Mode_Enum.Modify
            .P_F_RS_ID = FG1.SelectItem.Item("Report_FileName")
            .P_F_RS_ID2 = True
        End With
        ReturnId = ""
        Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F, Me)
        AddHandler VF.ClosedX, AddressOf Edit_Retrun
        VF.Show()
    End Sub

    '删除
    Private Sub Cmd_Del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Del.Click
        If FG1.RowSel <= 0 Then ShowErrMsg("请选择一个要修改的报表!") : Exit Sub
        ShowConfirm("是否删除[" & FG1.SelectItem.Item("Report_FileName") & "]的最新版[" & PClass.PClass.FormatN(FG1.SelectItem.Item("Report_Ver")) & "]?", AddressOf Report_Del)
    End Sub

    Sub Report_Del()
        Try
            PClass.PClass.RunSQL("delete from Report_File where Report_FileName ='" & FG1.SelectItem.Item("Report_FileName") & "' and Report_Ver='" & FG1.SelectItem.Item("Report_Ver") & "'")
        Catch ex As Exception
            ShowErrMsg("删除失败!" & vbCrLf & ex.Message)
            Exit Sub
        End Try
        ShowOk("删除[" & FG1.SelectItem.Item("Report_FileName") & "]的最新版[" & PClass.PClass.FormatN(FG1.SelectItem.Item("Report_Ver")) & "]成功!")
        Me_Refresh()
    End Sub

    '预览
    Private Sub Cmd_PreView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_PreView.Click
        If FG1.RowSel <= 0 Then ShowErrMsg("请选择一个要修改的报表!") : Exit Sub
        Report = New GridppReport
        Dim F As String
        F = PClass.PClass.GetReportFile(FG1.SelectItem.Item("Report_FileName"))
        If F = "" Then
            MsgBox("加载报表失败!", MsgBoxStyle.Exclamation, Me.Text)
        Else
            Report.LoadFromFile(F)
        End If
        Report.PrintPreview(True)

    End Sub

    '导出
    Private Sub Cmd_FileOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_FileOut.Click
        If FG1.RowSel <= 0 Then ShowErrMsg("请选择一个要修改的报表!") : Exit Sub
        SaveFileDialog1.FileName = FG1.SelectItem.Item("Report_FileName")
        SaveFileDialog1.Filter = "报表文件*.grf|*.grf"
        If SaveFileDialog1.ShowDialog(PClass.PClass.MainForm.CommandBars) = DialogResult.OK Then
            If SaveFileDialog1.FileName <> "" Then
                Dim FilePath As String
                FilePath = PClass.PClass.GetReportFile(FG1.SelectItem.Item("Report_FileName"))
                FileCopy(FilePath, SaveFileDialog1.FileName)
            End If

        End If
       
    End Sub


    '退出
    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub



#End Region




#Region "导入导出"



   
    Private Sub Cmd_ExportXml_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_ExportXml.Click
        Dim T As New Threading.Thread(AddressOf SaveXml)
        Using D As New SaveFileDialog
            D.FileName = "Report_Data.xml"
            D.Filter = "xml文件|*.xml"
            If D.ShowDialog() <> DialogResult.OK Then
                Exit Sub
            Else
                F = D.FileName
            End If
        End Using
        ShowGroup()
        LabelMsg.Visible = True
        Me.Refresh()
        Dim Dt As Data.DataTable = FG1.DataSource
        T.Start(Dt)
    End Sub

    Dim F As String
    Sub SaveXml(ByVal Dt As DataTable)
        Dt = Dt.Copy
        Dt.Columns.Add("Report_File")
        Dim I As Integer = 0
        For Each Row As DataRow In Dt.Rows
            Me.Invoke(New DShowPross(AddressOf ShowPross), "正在加载:" & I & "/" & Dt.Rows.Count)
            Dim P As New Dictionary(Of String, Object)
            P.Add("Report_FileName", Row("Report_FileName"))
            P.Add("Report_Ver", Row("Report_Ver"))
            Dim R As DtReturnMsg = SqlStrToDt("select Report_File,Report_Compress from Report_File where Report_FileName=@Report_FileName and Report_Ver=@Report_Ver", P)
            If R.IsOk AndAlso R.Dt.Rows.Count > 0 Then
                If IsNull(Row("Report_Compress"), False) Then
                    Row("Report_File") = System.Convert.ToBase64String(Decompress(R.Dt.Rows(0)("Report_File")))
                Else
                    Row("Report_File") = System.Convert.ToBase64String(R.Dt.Rows(0)("Report_File"))
                End If
            End If
            I = I + 1
        Next
        Me.Invoke(New DShowPross(AddressOf ShowPross), "加载完成!")
        Dt.AcceptChanges()
        Using Sm As New IO.FileStream(F, IO.FileMode.OpenOrCreate)
            Dt.WriteXml(Sm)
        End Using
        Me.Invoke(New BaseClass.ComFun.DSub_None(AddressOf ShowSaveOk))
    End Sub

    Sub ShowSaveXmlOk()

        HideGroup()
        ShowOk("生成xml成功")
    End Sub

    Delegate Sub DShowPross(ByVal s As String)
    Sub ShowPross(ByVal S As String)
        LabelMsg.Text = S
        LabelMsg.Refresh()
    End Sub



    Private Sub Cmd_InputXml_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_InputXml.Click
        Dim Dt As Data.DataTable = FG1.DataSource
        Dim F As String
        Using D As New OpenFileDialog
            D.FileName = "Report_Data.xml"
            D.Filter = "xml文件|*.xml"
            If D.ShowDialog() <> DialogResult.OK Then
                Exit Sub
            Else
                F = D.FileName
            End If
        End Using

        Dim DtL As DataTable = Dt.Clone
        DtL.Columns.Add("Report_File")
        Using Sm As New IO.FileStream(F, IO.FileMode.Open)
            DtL.ReadXml(Sm)
        End Using

        Dim DtR As DataTable = Dt.Clone
        DtR.Columns.Add("NewDate", GetType(Date))
        DtR.Columns.Add("IsUpdate", GetType(Boolean))
        DtR.Columns.Add("Opt", GetType(String))
        DtR.Columns.Add("Report_File", GetType(Byte()))
        Dim Rows() As DataRow
        For Each Row As DataRow In DtL.Rows
            Rows = Dt.Select("Report_FileName='" & Row("Report_FileName") & "'")
            If Rows.Length > 0 Then
                If Row("Report_MD5") <> Rows(0)("Report_MD5") Then
                    Dim NR As DataRow = DtR.NewRow
                    For Each C As DataColumn In DtL.Columns
                        If C.ColumnName <> "Report_File" Then
                            NR(C.ColumnName) = Row(C.ColumnName)
                        Else
                            NR(C.ColumnName) = System.Convert.FromBase64String(Row(C.ColumnName))
                        End If
                    Next
                    NR("NewDate") = Row("Report_Date")
                    NR("Report_Date") = Rows(0)("Report_Date")
                    NR("IsUpdate") = True
                    NR("Opt") = "更新"
                    DtR.Rows.Add(NR)
                End If
            Else
                Dim NR As DataRow = DtR.NewRow
                For Each C As DataColumn In DtL.Columns
                    If C.ColumnName <> "Report_File" Then
                        NR(C.ColumnName) = Row(C.ColumnName)
                    Else
                        NR(C.ColumnName) = System.Convert.FromBase64String(Row(C.ColumnName))
                    End If
                Next
                NR("NewDate") = Row("Report_Date")
                NR("Report_Date") = DBNull.Value
                NR("IsUpdate") = True
                NR("Opt") = "新增"
                DtR.Rows.Add(NR)
            End If
        Next


        For Each Row As DataRow In Dt.Rows
            Rows = DtL.Select("Report_FileName='" & Row("Report_FileName") & "'")
            If Rows.Length = 0 Then
                Dim NR As DataRow = DtR.NewRow
                For Each C As DataColumn In DtL.Columns
                    If C.ColumnName <> "Report_File" Then
                        NR(C.ColumnName) = Row(C.ColumnName)
                    Else
                        ' NR(C.ColumnName) = System.Convert.FromBase64String(Row(C.ColumnName))
                    End If
                Next
                NR("NewDate") = DBNull.Value
                NR("IsUpdate") = False
                NR("Opt") = "缺少"
                DtR.Rows.Add(NR)
            End If
        Next
        DtL.AcceptChanges()
        Fg2.DtToFG(DtR)
        Me.Refresh()
        ShowGroup()
        GroupBox_Xml.Visible = True
    End Sub


    Sub ShowGroup()
        CaptureFromImageToPicture(Me, Panel_Xml)
        Panel_Xml.BringToFront()
        ' GroupBox_Xml.Height = 268
        GroupBox_Xml.Left = Panel_Xml.Width / 2 - GroupBox_Xml.Width / 2
        GroupBox_Xml.Top = Panel_Xml.Height / 2 - GroupBox_Xml.Height / 2

        Panel_Xml.BringToFront()
        Panel_Xml.Visible = True
    End Sub

    Sub HideGroup()
        LabelMsg.Visible = False
        Panel_Xml.Visible = False
        Panel_Xml.SendToBack()
        GroupBox_Xml.Visible = False
    End Sub


    Private Sub Cmd_Change_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Change.Click

        GroupBox_Xml.Visible = False
        LabelMsg.Visible = False
        Me.Refresh()
        Dim T As New Threading.Thread(AddressOf Save)
        Dim Dt As Data.DataTable = Fg2.DataSource
        T.Start(Dt)
    End Sub


    Sub Save(ByVal Dt As DataTable)

        Dim I As Integer = 0
        Dim J As Integer = 0
        For Each Row As DataRow In Dt.Rows
            If Row("IsUpdate") = False Then
                I = I + 1
                Continue For
            End If
            Me.Invoke(New DShowPross(AddressOf ShowPross), "保存进度:" & I & "/" & Dt.Rows.Count)
            Dim R As MsgReturn = SqlStrToOneStr("select isnull(Max(Report_Ver),0.99)+0.01 from  Report_File where Report_FileName=@Report_FileName", "Report_FileName", Row("Report_FileName"))
            Dim V As Double = 1
            If R.IsOk Then
                V = Val(R.Msg)
            End If
            Dim md5 As String = Row("Report_MD5")
            If md5 = "" Then
                MsgBox("保存失败!")
                Me.Invoke(New BaseClass.ComFun.DSub_None(AddressOf ShowSaveOk))
                Exit Sub
            End If
            Try
                RunSQL("insert into Report_File (Report_FileName,Report_Name,Report_Ver,Report_Date,Report_MD5)values('" & Row("Report_FileName") & "','" & Row("Report_Name") & "'," & Format(V, "0.00") & ",getdate(),'" & md5 & "')")
            Catch ex As Exception
                MsgBox("保存失败!" & vbCrLf & ex.Message)
                Me.Invoke(New BaseClass.ComFun.DSub_None(AddressOf ShowSaveOk))
                Exit Sub
            End Try
            Dim ReportFile As String = IO.Path.GetTempPath & IO.Path.GetRandomFileName
            IO.File.WriteAllBytes(ReportFile, Row("Report_File"))
            InputFileToDbCompress(ReportFile, "Report_File", "Report_File", ",Report_Compress=1 where Report_FileName='" & Row("Report_FileName") & "' and Report_Ver=" & Format(V, "0.00") & "  ")
            Kill(ReportFile)
            I = I + 1
            J = J + 1
        Next
        Me.Invoke(New DShowPross(AddressOf ShowPross), "保存完成!")
        Me.Invoke(New BaseClass.ComFun.DSub_None(AddressOf ShowSaveOk))
    End Sub
    Sub ShowSaveOk()
        Me_Refresh()
        Me.ShowOk("保存成功!")
        HideGroup()
    End Sub


    Private Sub Cmd_Hide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Hide.Click
        HideGroup()
    End Sub

    Private Sub Fg2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Fg2.Click
        If Fg2.ColSel = Fg2.Cols("IsUpdate").Index Then
            If Fg2.RowSel > 0 Then
                Fg2.Item(Fg2.RowSel, "IsUpdate") = Not Fg2.Item(Fg2.RowSel, "IsUpdate")
            End If
        End If
    End Sub

#End Region
End Class
