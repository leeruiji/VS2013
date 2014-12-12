Imports System.Data
Imports PClass
Imports BaseClass
Imports PClass.PClass
Imports System.Text
Imports grproLib

Public Class R30207_DayReport_Msg
    Inherits CReport
    Dim comletedCount As Integer = 0
    Protected Const FileNameRd As String = "R30207_DayReport.grf"
    Protected Const FileNameDx As String = "R30208_DayReport.grf"
    Dim FirstDate As Date
    Dim LastDate As Date
    Dim Pid As Integer


    Sub New(ByVal PID As Integer)
        Me.Pid = PID
        Select Case PID
            Case 30206
                ReportFile = FileNameRd
            Case 30208
                ReportFile = FileNameDx
            Case Else
                ReportFile = ""
        End Select

        ReDim Dt_Header(1)
    End Sub

    Dim Rs As New SubReport
    Dim Ra As New SubReport
    Sub Start(ByVal sID As String, ByVal DoOperator As OperatorType)
        Dim dtmsg As DtReturnMsg = Dao.DayRePort_GetById(sID)
        If dtmsg.IsOk AndAlso dtmsg.Dt.Rows.Count > 0 Then
            Dim eDate As Date = dtmsg.Dt.Rows(0)("sDate")
            Dim sDate As Date = New Date(eDate.Year, eDate.Month, 1)
            Dim dtSum As DtReturnMsg = Dao.SumReport(sDate, eDate, dtmsg.Dt.Rows(0)("Reson"))
            If dtSum.IsOk AndAlso dtSum.Dt.Rows.Count > 0 Then
                dtmsg.Dt.Rows(0)("SumCrop") = IsNull(dtSum.Dt.Rows(0)("SumCrop"), 0)
                dtmsg.Dt.Rows(0)("SumReCrop") = IsNull(dtSum.Dt.Rows(0)("SumReCrop"), 0)
                dtmsg.Dt.Rows(0)("LJJCGs") = IsNull(dtSum.Dt.Rows(0)("LJJCGs"), 0)
                dtmsg.Dt.Rows(0)("LJJCWeight") = IsNull(dtSum.Dt.Rows(0)("LJJCWeight"), 0)
                dtmsg.Dt.Rows(0)("LJJZJGs") = IsNull(dtSum.Dt.Rows(0)("LJJZJGs"), 0)
                dtmsg.Dt.Rows(0)("LJJZJWeight") = IsNull(dtSum.Dt.Rows(0)("LJJZJWeight"), 0)
                If IsNull(dtmsg.Dt.Rows(0)("DayCrop"), 0) <> 0 Then
                    dtmsg.Dt.Rows(0)("DayRePercent") = IsNull(dtmsg.Dt.Rows(0)("DayReCrop"), 0) / IsNull(dtmsg.Dt.Rows(0)("DayCrop"), 0) * 100
                End If
                If dtmsg.Dt.Rows(0)("SumCrop") <> 0 Then
                    dtmsg.Dt.Rows(0)("SumRePercent") = IsNull(dtmsg.Dt.Rows(0)("SumReCrop"), 0) / IsNull(dtmsg.Dt.Rows(0)("SumCrop"), 0) * 100
                End If
            End If
            Dt_Header(1) = dtmsg.Dt
            Ra.Dt_Header(1) = dtmsg.Dt
            Rs.Dt_Header(1) = dtmsg.Dt
        End If
        Dim msg As DtListReturnMsg = Dao.DayRePort_SelListById(sID)
        If msg.IsOk Then
            If CheckDC(msg.DtList("Al").Rows.Count) Then
                msg.DtList("Al").Rows.Add()
            End If
            Ra.Dt_List = msg.DtList("Al")
            Select Case Pid
                Case 30206
                    Dt_List = msg.DtList("Dx")
                    Rs.Dt_List = msg.DtList("Re")
                Case 30208
                    Dt_List = msg.DtList("Re")
            End Select
        End If

        Me.DoOperator = DoOperator
        Me.DoWork()
    End Sub

    Private Sub R30207_DayReport_Msg_AfterLoadReport() Handles Me.AfterLoadReport
         Select Pid
            Case 30206
                Rs.Report = Me.Report.ControlByName("SubReport2").AsSubReport.Report
                Ra.Report = Me.Report.ControlByName("SubReport1").AsSubReport.Report
            Case 30208
                Ra.Report = Me.Report.ControlByName("SubReport1").AsSubReport.Report
        End Select
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

Public Class SubReport
    Inherits CReport
    Sub New()
        ReDim Dt_Header(1)
    End Sub
End Class


#Region "数据库交换"

Partial Friend Class Dao
    ''' <summary>
    ''' 计算累加值
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_DayRePort_Sum As String = "Select Sum(DayCrop)As SumCrop ,Sum(DayReCrop)As SumReCrop, Sum(RJSGS) AS LJJCGs, Sum(RJSWeight)As LJJCWeight,Sum(RJZJGS)As LJJZJGs ,Sum(RJZJWeight)as LJJZJWeight from T30207_DayReport_Table  Where sDate between @sDate1 and @sDate2 And Reson=@Reson    "

    ''' <summary>
    '''计算累加项
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Function SumReport(ByVal sDate As Date, ByVal eDate As Date, ByVal Reson As String) As DtReturnMsg
        Dim p As New Dictionary(Of String, Object)
        p.Add("sDate1", sDate)
        p.Add("sDate2", eDate)
        p.Add("Reson", Reson)
        Return PClass.PClass.SqlStrToDt(SQL_DayRePort_Sum, p)
    End Function

End Class


#End Region
