Imports System.Data
Imports PClass
Imports BaseClass
Imports PClass.PClass
Imports System.Text

Public Class R30940_GS_Count

    Inherits CReport
    Dim comletedCount As Integer = 0
    Protected fileName As String = "R30940_GS_Count.grf"

    Dim FirstDate As Date
    Dim LastDate As Date
    Dim LF As Integer = 0
    Dim Ln As Integer = 0
    Dim OList As List(Of FindOption)
    Public dtGoods As DataTable
    Dim IsLoaded As Boolean = False


    Sub New()
        ReportFile = Me.fileName
        ReDim Dt_Header(0)


    End Sub

    Sub SetOption(ByVal startDate As Date)

    End Sub

    Sub Start(ByVal Excelout As Boolean, ByVal StartDate As Date, ByVal EndDate As Date, ByVal dtmsg As DataTable, Optional ByVal _operator As OperatorType = OperatorType.LoadFile)

        If Excelout Then
            Me.SetCanExcelOut()
        Else
            Me.SetCanNotExcelOut()
        End If


        Dim dt As New DataTable
        dt.Columns.Add("sDate", GetType(Date))
        dt.Columns.Add("eDate", GetType(Date))
        Dim dr As DataRow = dt.NewRow
        dr("sDate") = StartDate
        dr("eDate") = EndDate
        dt.Rows.Add(dr)
        Dt_Header(0) = dt

        Dt_List = dtmsg
        Me.DoOperator = _operator
        If _operator = OperatorType.LoadFile Then
            Me.LoadReport()
        Else
            Me.DoWork()
        End If
    End Sub

End Class
#Region "数据库交换"

Partial Friend Class Dao

    'Public Const SQL_GetPB As String = "SELECT L.GH, C.Client_Name, BZ.BZ_Name, BZC.BZC_Name,BZC.BZC_No, SUM(L.PB) AS PB, SUM(ISNULL(L.Old_PB, L.PB)) AS Old_PB ,Count(*) as Qty  FROM T40101_PBRK_List L LEFT OUTER JOIN  T40100_PBRK_Table T ON T.ID = L.ID LEFT OUTER JOIN  T30000_Produce_Gd GD ON L.GH = GD.GH LEFT OUTER JOIN T10110_Client C ON C.ID = GD.Client_ID LEFT OUTER JOIN T10002_BZ BZ ON T.BZ_ID = BZ.ID LEFT OUTER JOIN T10003_BZC BZC ON BZC.ID = GD.BZC_ID  WHERE (Old_PB > 0) AND sDate Between @sDate and @eDate  "

    'Public Shared Function PB_Get(ByVal StartDate As Date, ByVal EndDate As Date) As DtReturnMsg
    '    Dim r As New DtReturnMsg
    '    Dim para As New Dictionary(Of String, Object)
    '    para.Add("@sDate", StartDate)
    '    para.Add("@eDate", EndDate)

    '    Dim sqlBuider As New StringBuilder()
    '    sqlBuider.Append(SQL_GetPB)

    '    sqlBuider.Append(" Group  BY L.GH, C.Client_Name, BZ.BZ_Name, BZC.BZC_Name,BZC.BZC_No")
    '    Return PClass.PClass.SqlStrToDt(sqlBuider.ToString, para)

    'End Function

End Class


#End Region

