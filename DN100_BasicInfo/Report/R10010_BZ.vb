Imports System.Data
Imports PClass
Imports BaseClass
Imports PClass.PClass
Imports System.Text

Public Class R10010_BZ

    Inherits CReport
    Dim comletedCount As Integer = 0
    Protected fileName As String = "R10010_BZ.grf"

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

    Sub Start(ByVal dtlist As DataTable, Optional ByVal _operator As OperatorType = OperatorType.LoadFile)

        Dt_List = dtlist
        Dt_Header(1) = New DataTable("T")
        Me.DoOperator = _operator
        Me.DoWork()
    End Sub

End Class
#Region "数据库交换"


#End Region

