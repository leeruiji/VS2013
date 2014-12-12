Imports System.Data
Imports PClass
Imports BaseClass
Imports PClass.PClass
Imports System.Text

Public Class R10061_PF

    Inherits CReport
    Dim comletedCount As Integer = 0
    Protected fileName As String = "R10020_BZC_Ranse.grf"

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

    Sub Start(Optional ByVal _operator As OperatorType = OperatorType.LoadFile)
        Dim msg As DtReturnMsg = Dao.StoreSummary_Get(FirstDate, LastDate)
        If msg.IsOk Then
            Dt_List = msg.Dt
        End If


        Dim dt As New DataTable
        dt.Columns.Add("startDate", GetType(DateTime))
        dt.Columns.Add("endDate", GetType(DateTime))
        Dim dr As DataRow = dt.NewRow
        dr("startDate") = FirstDate
        dr("endDate") = LastDate
        dt.Rows.Add(dr)

        Dt_Header(1) = dt

        If _operator = OperatorType.LoadFile Then
            Me.LoadReport()
        Else
            Me.DoOperator = _operator
            Me.DoWork()
        End If

    End Sub

End Class
#Region "数据库交换"

Partial Friend Class Dao
    Public Const SQLStr = "select " & vbCrLf & _
      "'打板员'as GroupName," & vbCrLf & _
      "F.FounderName as name," & vbCrLf & _
      "sum( case when ranse='单染' then 1 else 0 end) as DAnyan" & vbCrLf & _
      ",sum( case when ranse='套非活' then 1 else 0 end) as TFH" & vbCrLf & _
      ",sum( case when ranse='套活性' then 1 else 0 end) as THS" & vbCrLf & _
      "from T10010_BZC_PF F,T10003_BZC C" & vbCrLf & _
      "where F.BZC_ID=C.id and FoundDate between @StartDate and @EndDate" & vbCrLf & _
      "group by F.FounderName" & vbCrLf & _
      "union all" & vbCrLf & _
      "select " & vbCrLf & _
      "'出板员'as GroupName," & vbCrLf & _
      "F.AdjusterName as name," & vbCrLf & _
      "sum( case when ranse='单染' then 1 else 0 end) as DAnyan" & vbCrLf & _
      ",sum( case when ranse='套非活' then 1 else 0 end) as TFH" & vbCrLf & _
      ",sum( case when ranse='套活性' then 1 else 0 end) as THS" & vbCrLf & _
      "from T10010_BZC_PF F,T10003_BZC C" & vbCrLf & _
      "where F.BZC_ID=C.id and FoundDate between @StartDate and @EndDate" & vbCrLf & _
      "group by F.AdjusterName"


    Public Shared Function StoreSummary_Get(ByVal startDate As Date, ByVal endDate As Date) As DtReturnMsg

        Dim para As New Dictionary(Of String, Object)
        para.Add("@StartDate", startDate)
        para.Add("@EndDate", endDate)


        Return PClass.PClass.SqlStrToDt(SQLStr.ToString, para)

    End Function

End Class


#End Region


