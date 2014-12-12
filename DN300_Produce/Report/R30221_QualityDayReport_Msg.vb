Imports System.Data
Imports PClass
Imports BaseClass
Imports PClass.PClass
Imports System.Text

Public Class R30221_QualityDayReport_Msg
    Inherits CReport
    Dim comletedCount As Integer = 0
    Protected Const fileName As String = "R30221_QualityDayReort_Msg.grf"
    Dim FirstDate As Date
    Dim LastDate As Date


    Sub New()
        ReportFile = fileName
        ReDim Dt_Header(1)

    End Sub

    Dim Rs As New SuReport
    Dim Ra As New SuReport

    Sub Start(ByVal sID As String, ByVal DoOperator As OperatorType)
        Dim dtmsg As DtReturnMsg = Dao.QualityDayReport_GetById(sID)
        If dtmsg.IsOk AndAlso dtmsg.Dt.Rows.Count > 0 Then
            Dim eDate As Date = dtmsg.Dt.Rows(0)("sDate")
            Dim sDate As Date = New Date(eDate.Year, eDate.Month, 1)
            Dim dtSum As DtReturnMsg = Dao.SumReportforQuality(sDate, eDate)
            If dtSum.IsOk AndAlso dtSum.Dt.Rows.Count > 0 Then
                dtmsg.Dt.Rows(0)("SumBJCL") = IsNull(dtSum.Dt.Rows(0)("SumBJCL"), 0)
                dtmsg.Dt.Rows(0)("SumLYTB") = IsNull(dtSum.Dt.Rows(0)("SumLYTB"), 0)

                If IsNull(dtmsg.Dt.Rows(0)("DayBJCL"), 0) <> 0 Then
                    dtmsg.Dt.Rows(0)("DayLYTBL") = IsNull(dtmsg.Dt.Rows(0)("DayLYTB"), 0) / IsNull(dtmsg.Dt.Rows(0)("DayBJCL"), 0) * 100
                End If
                If dtmsg.Dt.Rows(0)("SumBJCL") <> 0 Then
                    dtmsg.Dt.Rows(0)("SumLYTBL") = IsNull(dtmsg.Dt.Rows(0)("SumLYTB"), 0) / IsNull(dtmsg.Dt.Rows(0)("SumBJCL"), 0) * 100
                End If

            End If
            Dt_Header(1) = dtmsg.Dt
            Ra.Dt_Header(1) = dtmsg.Dt
            Rs.Dt_Header(1) = dtmsg.Dt
        End If
        Dim msg As DtListReturnMsg = Dao.QualityDayReport_SelListById(sID)
        If msg.IsOk Then
            Dt_List = msg.DtList("JY")
            If CheckDC(msg.DtList("QP").Rows.Count) Then
                msg.DtList("QP").Rows.Add()
            End If
            Ra.Dt_List = msg.DtList("QP")
            Rs.Dt_List = msg.DtList("LJ")
        End If
        Me.DoOperator = DoOperator
        Me.DoWork()

    End Sub

    Private Sub R30221_QualityDayReport_Msg_AfterLoadReport() Handles Me.AfterLoadReport
        Ra.Report = Me.Report.ControlByName("SubReport1").AsSubReport.Report
        Rs.Report = Me.Report.ControlByName("SubReport2").AsSubReport.Report
    End Sub


    ''' <summary>
    '''检查单双
    ''' </summary>
    ''' <remarks></remarks>
    Private Function CheckDC(ByVal Count As Integer) As Boolean
        Select Case Count Mod 2
            Case 1
                Return True '奇数
            Case 0
                Return False '偶数
            Case Else
                Return True   '奇数
        End Select
    End Function
End Class

#Region "数据库交换"

Partial Friend Class Dao
    ''' <summary>
    ''' 计算累加值
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_QualityDayReport_Sum As String = "Select Sum(DayBJCL)As SumBJCL ,Sum(DayLYTB)As SumLYTB from T30220_QualityDayReport_Table  Where sDate between @sDate1 and @sDate2  "

    ''' <summary>
    '''计算累加项
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Function SumReportforQuality(ByVal sDate As Date, ByVal eDate As Date) As DtReturnMsg
        Dim p As New Dictionary(Of String, Object)
        p.Add("sDate1", sDate)
        p.Add("sDate2", eDate)
        Return PClass.PClass.SqlStrToDt(SQL_QualityDayReport_Sum, p)
    End Function


End Class

Public Class SuReport
    Inherits CReport
    Sub New()
        ReDim Dt_Header(1)
    End Sub
End Class

#End Region
