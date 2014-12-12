Imports System.Data
Imports PClass
Imports BaseClass
Imports PClass.PClass
Imports System.Text
Public Class R40940_QCSH_Summary
    Inherits CReport
    Dim comletedCount As Integer = 0
    Protected fileName As String = "R40940_QCSH_Summary.grf"

    Dim FirstDate As Date
    Dim LastDate As Date



    Sub New()
        ReportFile = Me.fileName
        ReDim Dt_Header(1)

    End Sub

    Sub SetOption(ByVal startDate As Date, ByVal endDate As Date)
        FirstDate = startDate
        LastDate = endDate

    End Sub

    Sub Start(Optional ByVal Excelout As Boolean = False, Optional ByVal _operator As OperatorType = OperatorType.LoadFile)
        If Excelout Then
            Me.SetCanExcelOut()
        Else
            Me.SetCanNotExcelOut()
        End If
        Dim msg As DtReturnMsg = Dao.QCSH_Get(FirstDate, LastDate)
        If msg.IsOk Then
            Dt_List = msg.Dt
        End If

        Dt_Header(1) = New DataTable("T")
        Dt_List = msg.Dt

        If _operator = OperatorType.LoadFile Then
            Me.LoadReport()
        Else
            Me.DoWork()
        End If

    End Sub

End Class
#Region "数据库交换"

Partial Friend Class Dao




    Public Shared Function QCSH_Get(ByVal startDate As Date, ByVal endDate As Date) As DtReturnMsg

        Dim para As New Dictionary(Of String, Object)
        para.Add("@StartDate", startDate)
        para.Add("@EndDate", endDate)


        Dim sqlBuider As New StringBuilder()
        sqlBuider.AppendLine("SELECT License, SUM(SumQty) AS SumQty, SUM(SumPWeight) AS SumPWeight ")
        sqlBuider.AppendLine(" FROM T40100_PBRK_Table ")
        sqlBuider.AppendLine("WHERE (sDate BETWEEN @StartDate AND @EndDate) and not License is null  ")
        sqlBuider.AppendLine("GROUP BY License  ")

        Return PClass.PClass.SqlStrToDt(sqlBuider.ToString, para)

    End Function

End Class


#End Region
