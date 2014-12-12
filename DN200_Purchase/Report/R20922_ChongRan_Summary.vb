Imports System.Data
Imports PClass
Imports BaseClass
Imports PClass.PClass
Imports System.Text

Public Class R20922_ChongRan_Summary

    Inherits CReport
    Dim comletedCount As Integer = 0
    Protected fileName As String = "R20922_ChongRan_Summary.grf"

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
        Dim msg As DtReturnMsg = Dao.ChongRanSummary_Get(FirstDate, LastDate)
        If msg.IsOk Then





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




    Public Shared Function ChongRanSummary_Get(ByVal startDate As Date, ByVal endDate As Date) As DtReturnMsg

        Dim para As New Dictionary(Of String, Object)
        para.Add("@StartDate", startDate)
        para.Add("@EndDate", endDate)
        Dim d As New Date(2000, 1, 1)


        Dim sqlBuider As New StringBuilder()
        sqlBuider.AppendLine("select T.*,BZ.BZ_No,BZ.BZ_Name from ( ")
        sqlBuider.AppendLine(" select G.GH,sum(SumAmount) sumAmount,(select sum(SumAmount )   ")
        sqlBuider.AppendLine(" from T30000_Produce_Gd G1, T20310_LingLiao_Table L1 where L1.Produce_ID =G1.GH and G1.GH like G.GH + '%' and len(G1.GH) >11) SumAmount_CG  ")
        sqlBuider.AppendLine(" ,(select count(G2.GH) from T30000_Produce_Gd G2 where G2.GH like G.GH + '%' and len(G2.GH) >11 ) CGCount ")
        sqlBuider.AppendLine("  ,(select Sum(CR_LuoSeBzCount) from T30000_Produce_Gd G2 where G2.GH like G.GH + '%') CR_LuoSeBzCount  ")
        sqlBuider.AppendLine(" ,G.BZ_ID, CPName,BZCMSg,Date_LuoSe ")
        sqlBuider.AppendLine(" from T30000_Produce_Gd G, T20310_LingLiao_Table L where  L.Produce_ID =G.GH and G.IsChongRan=1 ")

        If startDate > d Then
            sqlBuider.AppendLine(" and Date_LuoSe>=@StartDate ")

        End If
        If endDate > d Then
            sqlBuider.AppendLine(" and Date_LuoSe<=@EndDate ")

        End If
        sqlBuider.AppendLine("group by G.GH,G.BZ_ID,CPName,BZCMSg,CR_LuoSeBzCount,Date_LuoSe ")
        sqlBuider.AppendLine(") T left join T10002_BZ BZ on T.BZ_ID=BZ.ID order by  T.GH")

        Return PClass.PClass.SqlStrToDt(sqlBuider.ToString, para)

    End Function

End Class


#End Region

