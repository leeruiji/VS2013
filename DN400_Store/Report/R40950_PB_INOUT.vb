Imports System.Data
Imports PClass
Imports BaseClass
Imports PClass.PClass
Imports System.Text

Public Class R40950_PB_INOUT
    Inherits CReport

    Protected fileName As String = "R40950_PB_INOUT.grf"
    Dim Client_ID As Integer
    Dim Client_Name As String = ""
    Dim OList As OptionList
    Dim FirstDate As Date
    Dim LastDate As Date

    Sub New()
        ReportFile = Me.fileName
        ReDim Dt_Header(1)

    End Sub

    Sub SetOption(ByVal startDate As Date, ByVal endDate As Date, ByVal Olist As OptionList)
        Me.FirstDate = startDate
        Me.LastDate = endDate
        Me.OList = Olist
        Dim dt As New DataTable
        Dim msg As DtReturnMsg = Dao.PB_Report_GetByOption(Olist, FirstDate, LastDate)
        If msg.IsOk Then
            Dt_List = msg.Dt
        End If
        dt.Columns.Add("sDate", GetType(Date))
        dt.Columns.Add("eDate", GetType(Date))
        Dim row As DataRow = dt.NewRow
        row("sDate") = startDate
        row("eDate") = endDate
        dt.Rows.Add(row)
        Dt_Header(1) = dt
    End Sub

    Sub Start(Optional ByVal Excelout As Boolean = False, Optional ByVal _operator As OperatorType = OperatorType.LoadFile)

        If Excelout Then
            Me.SetCanExcelOut()
        Else
            Me.SetCanNotExcelOut()
        End If
        Me.DoOperator = _operator

        If Me.DoOperator = OperatorType.LoadFile Then
            Me.LoadReport()
        Else
            Me.DoWork()
        End If
    End Sub

End Class
#Region "数据库交换"

Partial Friend Class Dao




    ''' <summary>
    ''' 按条件获取胚布入库单列表
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function PB_Report_GetByOption(ByVal oList As OptionList, ByVal FirstDate As DateTime, ByVal LastDate As DateTime) As DtReturnMsg
        Dim paraMap As New Dictionary(Of String, Object)
        Dim sqlBuider As New StringBuilder

        'sqlBuider.AppendLine("select Client_ID,")
        'sqlBuider.AppendLine("Sum(InQty)InQty,Sum(InZL)InZL,")
        'sqlBuider.AppendLine("sum(PBQty)PBQty,Sum(PBZL)PBZL,")
        'sqlBuider.AppendLine("sum(PBZL)PBZL,Sum(SHQty)SHQty,")
        'sqlBuider.AppendLine("sum(ShZL)ShZL,")
        'sqlBuider.AppendLine("Sum(CPRKQty)CPRKQty,Sum(CPPBQty)CPPBQty,sum(CPQty)CPQty,")
        'sqlBuider.AppendLine("Sum(NowPBQty)NowPBQty,sum(NowPBZL)NowPBZL,")
        'sqlBuider.AppendLine("Sum(CPQty+NowPBQty)NowQty,")
        'sqlBuider.AppendLine("C.Client_Name")
        'sqlBuider.AppendLine("from(")
        'sqlBuider.AppendLine("select Client_ID,Sum(SumQty)InQty,sum(SumPWeight)InZL,")
        'sqlBuider.AppendLine("0 as PBQty,0 as PBZL,")
        'sqlBuider.AppendLine("0 as SHQty,0 as ShZL,")
        'sqlBuider.AppendLine("0 as CPRKQty, 0 as CPPBQty, 0 as CPQty,")
        'sqlBuider.AppendLine("0 as NowPBQty,0 as NowPBZL")
        'sqlBuider.AppendLine("from T40100_PBRK_Table --入库数")
        'sqlBuider.AppendLine("where sDate between @Date1 and @Date2")
        'sqlBuider.AppendLine("group by Client_ID")
        'sqlBuider.AppendLine("union all--配布数")
        'sqlBuider.AppendLine("select Client_ID,0,0,Sum(PB_CountSum)PB_CountSum,Sum(PB_ZLSum)PB_ZLSum ,0,0,0,0,0,0,0")
        'sqlBuider.AppendLine("from T30000_Produce_Gd ")
        'sqlBuider.AppendLine("where Date_PeiBu between @Date1 and @Date2")
        'sqlBuider.AppendLine("group by Client_ID")
        'sqlBuider.AppendLine("union all--送货数")
        'sqlBuider.AppendLine("select Client_ID,0,0,0,0,sum(SumQty)SumQty,sum(SumPWeight)SumPWeight,0,0,0,0,0")
        'sqlBuider.AppendLine("from T40000_BZSH_Table")
        'sqlBuider.AppendLine("where State>=0 and  BZSH_Date between @Date1 and @Date2")
        'sqlBuider.AppendLine("group by Client_ID")
        'sqlBuider.AppendLine("union all--成品入库条数")
        'sqlBuider.AppendLine("select Client_ID,0,0,0,0,0,0,Sum(Isnull(CPRK_Qty,0))CPRK_Qty,Sum(PB_CountSum)PB_CountSum,0,0,0")
        'sqlBuider.AppendLine("from T30000_Produce_Gd ")
        'sqlBuider.AppendLine("where Date_CPRK between @Date1 and @Date2")
        'sqlBuider.AppendLine("group by Client_ID")
        'sqlBuider.AppendLine("union all--成品余条数")
        'sqlBuider.AppendLine("select Client_ID,0,0,0,0,0,0,0,0,Sum(Isnull(CPRK_Qty,0))CPRK_Qty ,0,0")
        'sqlBuider.AppendLine("from T30000_Produce_Gd ")
        'sqlBuider.AppendLine("where Date_CPRK <= @Date2 and State<90")
        'sqlBuider.AppendLine("group by Client_ID")
        'sqlBuider.AppendLine("union all--胚布余数")
        'sqlBuider.AppendLine("select Client_ID,0,0,0,0,0,0,0,0,0,Sum(RemainCount)NowQty,sum(RemainWeight)NowZL")
        'sqlBuider.AppendLine("from T40100_PBRK_Table ")
        'sqlBuider.AppendLine("group by Client_ID")
        'sqlBuider.AppendLine("union all--期末到现在的入库数")
        'sqlBuider.AppendLine("select Client_ID,0,0,0,0,0,0,0,0,0,-Sum(SumQty)InQty,-sum(SumPWeight)InZL")
        'sqlBuider.AppendLine("from T40100_PBRK_Table ")
        'sqlBuider.AppendLine("where sDate   > @Date2 ")
        'sqlBuider.AppendLine("group by Client_ID")
        'sqlBuider.AppendLine("union all--期末到现在的配布数")
        'sqlBuider.AppendLine("select Client_ID,0,0,0,0,0,0,0,0,0,Sum(PB_CountSum)PB_CountSum,Sum(PB_ZLSum)PB_ZLSum")
        'sqlBuider.AppendLine("from T30000_Produce_Gd ")
        'sqlBuider.AppendLine("where Date_PeiBu  > @Date2 ")
        'sqlBuider.AppendLine("group by Client_ID")
        'sqlBuider.AppendLine(")A")
        'sqlBuider.AppendLine("left join T10110_Client C on C.id=A.Client_ID  ")

        'sqlBuider.Append("  WHERE 1=1  ")
        'sqlBuider.Append(BaseClass.OptionClass.OptionClass_BuidSqlConditon(oList.FoList, paraMap))
        'paraMap.Add("Date1", FirstDate)
        'paraMap.Add("Date2", LastDate)
        'sqlBuider.Append(" group by Client_ID,Client_Name")
        'sqlBuider.Append(" order by Client_ID,Client_Name")
        sqlBuider.AppendLine("select B.Client_ID,")
        sqlBuider.AppendLine("Sum(InQty)InQty,Sum(InZL)InZL,")
        sqlBuider.AppendLine("sum(PBQty)PBQty,Sum(PBZL)PBZL,")
        sqlBuider.AppendLine("sum(PBZL)PBZL,Sum(SHQty)SHQty,")
        sqlBuider.AppendLine("sum(ShZL)ShZL,")
        sqlBuider.AppendLine("Sum(CPRKQty)CPRKQty,Sum(CPPBQty)CPPBQty,sum(CPQty)CPQty,")
        sqlBuider.AppendLine("Sum(NowPBQty)NowPBQty,sum(NowPBZL)NowPBZL,")
        sqlBuider.AppendLine("Sum(CPQty+NowPBQty)NowQty,")
        sqlBuider.AppendLine("C.Client_Name ")
        sqlBuider.AppendLine("from  T10002_BZ B left join   ")
        sqlBuider.AppendLine("(")
        sqlBuider.AppendLine("select Client_ID,BZ_ID,Sum(SumQty)InQty,sum(SumPWeight)InZL,")
        sqlBuider.AppendLine("0 as PBQty,0 as PBZL,")
        sqlBuider.AppendLine("0 as SHQty,0 as ShZL,")
        sqlBuider.AppendLine("0 as CPRKQty,0 as CPPBQty,0 as CPQty,")
        sqlBuider.AppendLine("0 as NowPBQty,0 as NowPBZL")
        sqlBuider.AppendLine("from T40100_PBRK_Table --入库数")
        sqlBuider.AppendLine("where sDate between @Date1 and @Date2")
        sqlBuider.AppendLine("group by Client_ID,BZ_ID")
        sqlBuider.AppendLine("union all--配布数")
        sqlBuider.AppendLine("select Client_ID,BZ_ID,0,0,Sum(PB_CountSum)PB_CountSum,Sum(PB_ZLSum)PB_ZLSum ,0,0,0,0,0,0,0")
        sqlBuider.AppendLine("from T30000_Produce_Gd ")
        sqlBuider.AppendLine("where Date_PeiBu between @Date1 and @Date2")
        sqlBuider.AppendLine("group by Client_ID,BZ_ID")
        sqlBuider.AppendLine("union all--送货数")
        sqlBuider.AppendLine("select Client_ID,BZ_ID,0,0,0,0,sum(SumQty)SumQty,sum(SumPWeight)SumPWeight,0,0,0,0,0")
        sqlBuider.AppendLine("from T40000_BZSH_Table t,T40001_BZSH_List l")
        sqlBuider.AppendLine("where State>=0 and  BZSH_Date between @Date1 and @Date2 and t.BZSH_ID=l.BZSH_ID")
        sqlBuider.AppendLine("group by Client_ID,BZ_ID")
        sqlBuider.AppendLine("union all--成品入库条数")
        sqlBuider.AppendLine("select Client_ID,BZ_ID,0,0,0,0,0,0,Sum(Isnull(CPRK_Qty,0))CPRK_Qty,Sum(PB_CountSum)PB_CountSum,0,0,0")
        sqlBuider.AppendLine("from T30000_Produce_Gd ")
        sqlBuider.AppendLine("where Date_CPRK between @Date1 and @Date2")
        sqlBuider.AppendLine("group by Client_ID,BZ_ID")
        sqlBuider.AppendLine("union all--成品余条数")
        sqlBuider.AppendLine("select Client_ID,BZ_ID,0,0,0,0,0,0,0,0,Sum(Isnull(CPRK_Qty,0))CPRK_Qty ,0,0")
        sqlBuider.AppendLine("from T30000_Produce_Gd ")
        sqlBuider.AppendLine("where Date_CPRK <= @Date2 and State<90")
        sqlBuider.AppendLine("group by Client_ID,BZ_ID")
        sqlBuider.AppendLine("union all--胚布余数")
        sqlBuider.AppendLine("select Client_ID,BZ_ID,0,0,0,0,0,0,0,0,0,Sum(RemainCount)NowQty,sum(RemainWeight)NowZL")
        sqlBuider.AppendLine("from T40100_PBRK_Table ")
        sqlBuider.AppendLine("group by Client_ID,BZ_ID")
        sqlBuider.AppendLine("union all--期末到现在的入库数")
        sqlBuider.AppendLine("select Client_ID,BZ_ID,0,0,0,0,0,0,0,0,0,-Sum(SumQty)InQty,-sum(SumPWeight)InZL")
        sqlBuider.AppendLine("from T40100_PBRK_Table ")
        sqlBuider.AppendLine("where sDate   > @Date2 ")
        sqlBuider.AppendLine("group by Client_ID,BZ_ID")
        sqlBuider.AppendLine("union all--期末到现在的配布数")
        sqlBuider.AppendLine("select Client_ID,BZ_ID,0,0,0,0,0,0,0,0,0,Sum(PB_CountSum)PB_CountSum,Sum(PB_ZLSum)PB_ZLSum")
        sqlBuider.AppendLine("from T30000_Produce_Gd ")
        sqlBuider.AppendLine("where Date_PeiBu  > @Date2 ")
        sqlBuider.AppendLine("group by Client_ID,BZ_ID")
        sqlBuider.AppendLine(")A on B.id=A.BZ_ID ")
        sqlBuider.AppendLine("left join T10110_Client C on C.id=B.Client_ID  ")
        '  sqlBuider.AppendLine("left join T10002_BZ B on B.id=A.BZ_ID  ")

        sqlBuider.Append("  WHERE not A.Client_ID is null  ")
        sqlBuider.Append(BaseClass.OptionClass.OptionClass_BuidSqlConditon(oList.FoList, paraMap))
        paraMap.Add("Date1", FirstDate)
        paraMap.Add("Date2", LastDate)
        sqlBuider.Append(" group by B.Client_ID,Client_Name")
        sqlBuider.Append(" order by B.Client_ID,Client_Name")
        Return PClass.PClass.SqlStrToDt(sqlBuider.ToString, paraMap)
    End Function



End Class


#End Region


