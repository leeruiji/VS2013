Imports System.Data
Imports PClass
Imports BaseClass
Imports PClass.PClass
Imports System.Text

Public Class R40002_BZSH2

    Inherits CReport

    Dim comletedCount As Integer = 0

    Protected Const fileName As String = "R40002_BZSH2.grf"
    Dim FirstDate As Date
    Dim LastDate As Date


    Sub New()
        ' Me.IsSavePrinterSetting = False
        ReDim Dt_Header(1)
        ReportFile = fileName
    End Sub





#Region "数据库交换"
    Dim BZSHId As String
    Sub Start(ByVal BZSH_ID As String, ByVal DoOperator As OperatorType)
        Me.BZSHId = BZSH_ID
        Dim msg As DtReturnMsg = SqlStrToDt(SQL_BZSH_GetBZSHByidWhithClientName, "BZSH_ID", BZSH_ID)
        If msg.IsOk = False OrElse msg.Dt.Rows.Count = 0 Then
            MsgBox("加载报表信息错误")
            Exit Sub
        End If
        Dim MsgList As DtReturnMsg = SqlStrToDt(SQL_BZSH_GetBZSHListByid_ForReport, "BZSH_ID", BZSH_ID)

        Dim sqlBuider As New StringBuilder()
        sqlBuider.AppendLine("select distinct B.GH,P.ID  from T40001_BZSH_List B,T40101_PBRK_List P where ")
        sqlBuider.AppendLine("B.GH =p.GH and")
        sqlBuider.AppendLine("BZSH_ID =@BZSH_ID")
        sqlBuider.AppendLine("order by B.GH,P.ID")

        Dim R As DtReturnMsg = SqlStrToDt(sqlBuider.ToString, "BZSH_ID", BZSH_ID)
        MsgList.Dt.Columns.Add("PBRK_ID")

        For Each Dr As DataRow In MsgList.Dt.Rows
            Dim Rows() As DataRow = R.Dt.Select("GH='" & Dr("GH") & "'")
            Dr("PBRK_ID") = ComFun.DtToString(DtRunSQLtoDt(R.Dt, "GH='" & Dr("GH") & "'"), "ID", ",")



            If IsNull(Dr("Client_Bzc"), "") <> "" Then
                Dr("Client_Bzc") = Dr("Client_Bzc") & "#"
            End If
            If IsNull(Dr("BZ_No"), "").ToString.Contains("#") = False Then
                Dr("BZ_No") = ""
            End If
            If IsNull(Dr("CPName"), "") = "" Then
                Dr("CPName") = Dr("BZ_No") & Dr("BZ_Name")
            End If

            If IsNull(Dr("BzcMsg"), "") = "" Then
                Dr("BzcMsg") = Dr("Client_Bzc") & Dr("BZC_Name") & vbCrLf & "GY-" & Format(IsNull(Dr("BZc_No"), ""), "000000") & Dr("BZC_PF")
            End If


        Next

        If msg.IsOk AndAlso MsgList.IsOk Then
            Me.Dt_List = msg.Dt
            Me.Dt_Header(0) = msg.Dt
            Me.Dt_List = MsgList.Dt
            Me.DoOperator = DoOperator
            Me.DoWork()
        Else
            MsgBox("加载报表信息错误")
        End If
    End Sub

    Dim arr As Byte()
#End Region

    Private Sub R40001_BZSH_PrintCompleted() Handles Me.PrintCompleted
        Dim P As New Dictionary(Of String, Object)
        P.Add("@BZSH_ID", BZSHId)
        P.Add("BillType", BillType.BZSH)
        P.Add("State", -1)
        P.Add("StateName", "打印")
        P.Add("ChagneUser", User_Display)
        Dim sql As New StringBuilder()
        sql.AppendLine("insert into T10080_BillStateLog (BillType,ID,State,StateName,ChangeTime,ChagneUser)values(@BillType,@BZSH_ID,@State,@StateName,Getdate(),@ChagneUser)")
        sql.AppendLine("Update T40000_BZSH_Table set Printed=1 where BZSH_ID=@BZSH_ID")
        RunSQL(sql.ToString, P)
    End Sub








    Private Sub R40001_BZSH_PrintEnd() Handles Me.PrintEnd

    End Sub

    'Private Sub Report_ShowPreviewWnd(ByVal pPrintViewer As grproLib.GRPrintViewer) Handles Report.ShowPreviewWnd
    '    If CheckRight(40000, ClassMain.Print) = False Then
    '        pPrintViewer.RemoveToolbarControl(grproLib.GRToolControlType.grtctExport)
    '        pPrintViewer.RemoveToolbarControl(grproLib.GRToolControlType.grtctMail)
    '        pPrintViewer.RemoveToolbarControl(grproLib.GRToolControlType.grtctPrint)
    '        pPrintViewer.RemoveToolbarControl(grproLib.GRToolControlType.grtctExportXLSBtn)
    '        pPrintViewer.RemoveToolbarControl(grproLib.GRToolControlType.grtctExportPDFBtn)
    '        pPrintViewer.RemoveToolbarControl(grproLib.GRToolControlType.grtctExportCSV)
    '        pPrintViewer.RemoveToolbarControl(grproLib.GRToolControlType.grtctExportHTM)
    '        pPrintViewer.RemoveToolbarControl(grproLib.GRToolControlType.grtctExportIMG)
    '        pPrintViewer.RemoveToolbarControl(grproLib.GRToolControlType.grtctExportPDF)
    '        pPrintViewer.RemoveToolbarControl(grproLib.GRToolControlType.grtctExportRTF)
    '        pPrintViewer.RemoveToolbarControl(grproLib.GRToolControlType.grtctExportTXT)
    '        pPrintViewer.RemoveToolbarControl(grproLib.GRToolControlType.grtctExportXLS)
    '        pPrintViewer.RemoveToolbarControl(grproLib.GRToolControlType.grtctExportXLSBtn)
    '    End If
    'End Sub
    'Private Sub Peport_PrintBegin() Handles Report.PrintBegin
    '    If CheckRight(40000, ClassMain.Print) = False Then
    '        Report.AbortPrint()
    '    End If
    'End Sub
End Class
