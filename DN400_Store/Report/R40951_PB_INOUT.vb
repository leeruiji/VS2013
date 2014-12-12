Imports System.Data
Imports PClass
Imports BaseClass
Imports PClass.PClass
Imports System.Text

Public Class R40951_PB_INOUT
    Inherits CReport

    Protected fileName As String = "R40951_PB_INOUT.grf"
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
        Dim msg As DtReturnMsg = Dao.PB2_Report_GetByOption(Olist, FirstDate, LastDate)
        If msg.IsOk Then
            For Each dr As DataRow In msg.Dt.Rows
                If IsNull(dr("BZ_No"), "").ToString.Contains("#") = False Then
                    dr("BZ_No") = ""
                End If
            Next
            Dt_List = msg.Dt
        End If
        Dt_Header(1) = New DataTable("T")
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

    ' Public Const SQL_Report_Get_PB_InOut2 As String = "declare @DateNow Varchar(20)" & vbCrLf & _
    '"select A.Client_ID,Sum(InQty)InQty,Sum(InZL)InZL,sum(PBQyt)PBQyt,Sum(PBQyt)PBQyt,sum(PBZL)PBZL,Sum(SHQty)SHQty,sum(ShZL)ShZL,Sum(NowQty)NowQty,sum(NowZL)NowZL" & vbCrLf & _
    '",C.Client_Name,BZ_Name,BZ_No" & vbCrLf & _
    '"from(" & vbCrLf & _
    '"select Client_ID,BZ_ID,Sum(SumQty)InQty,sum(SumPWeight)InZL,0 as PBQyt,0 as PBZL,0 as SHQty,0 as ShZL,0 as NowQty,0 as NowZL" & vbCrLf & _
    '"from T40100_PBRK_Table " & vbCrLf & _
    '"where sDate between @Date1 and @Date2" & vbCrLf & _
    '"group by Client_ID,BZ_ID" & vbCrLf & _
    '"union all" & vbCrLf & _
    '"select Client_ID,BZ_ID,0,0,Sum(PB_CountSum)PB_CountSum,Sum(PB_ZLSum)PB_ZLSum ,0,0,0,0" & vbCrLf & _
    '"from T30000_Produce_Gd " & vbCrLf & _
    '"where Date_PeiBu between @Date1 and @Date2" & vbCrLf & _
    '"group by Client_ID,BZ_ID" & vbCrLf & _
    '"union all" & vbCrLf & _
    '"select Client_ID,BZ_ID,0,0,0,0,sum(SumQty)SumQty,sum(SumPWeight)SumPWeight,0,0" & vbCrLf & _
    '"from T40000_BZSH_Table t,T40001_BZSH_List l" & vbCrLf & _
    '"where BZSH_Date between @Date1 and @Date2 and t.BZSH_ID=l.BZSH_ID" & vbCrLf & _
    '"group by Client_ID,BZ_ID" & vbCrLf & _
    '"union all" & vbCrLf & _
    '"select Client_ID,BZ_ID,0,0,0,0,0,0,Sum(RemainCount)NowQty,sum(RemainWeight)NowZL" & vbCrLf & _
    '"from T40100_PBRK_Table " & vbCrLf & _
    '"group by Client_ID,BZ_ID" & vbCrLf & _
    '"union all" & vbCrLf & _
    '"select Client_ID,BZ_ID,0,0,0,0,0,0,-Sum(SumQty)InQty,-sum(SumPWeight)InZL" & vbCrLf & _
    '"from T40100_PBRK_Table " & vbCrLf & _
    '"where sDate > @Date2 " & vbCrLf & _
    '"group by Client_ID,BZ_ID" & vbCrLf & _
    '"union all" & vbCrLf & _
    '"select Client_ID,BZ_ID,0,0,0,0,0,0,Sum(PB_CountSum)PB_CountSum,Sum(PB_ZLSum)PB_ZLSum" & vbCrLf & _
    '"from T30000_Produce_Gd " & vbCrLf & _
    '"where Date_PeiBu  > @Date2 " & vbCrLf & _
    '"group by Client_ID,BZ_ID" & vbCrLf & _
    '")A" & vbCrLf & _
    '"left join T10110_Client C on C.id=A.Client_ID" & vbCrLf & _
    '"left join T10002_BZ B on B.id=A.BZ_ID"
    ''' <summary>
    ''' 按条件获取胚布入库单列表
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function PB2_Report_GetByOption(ByVal oList As OptionList, ByVal FirstDate As DateTime, ByVal LastDate As DateTime) As DtReturnMsg
        Dim paraMap As New Dictionary(Of String, Object)
        paraMap.Add("Date1", FirstDate)
        paraMap.Add("Date2", LastDate)

        Dim sqlBuider As New StringBuilder

        sqlBuider.AppendLine("select B.ID as BZ_ID,B.Client_ID,")
        sqlBuider.AppendLine("Sum(InQty)InQty,Sum(InZL)InZL,")
        sqlBuider.AppendLine("sum(PBQty)PBQty,Sum(PBZL)PBZL,")
        sqlBuider.AppendLine("sum(PBZL)PBZL,Sum(SHQty)SHQty,")
        sqlBuider.AppendLine("sum(ShZL)ShZL,")
        sqlBuider.AppendLine("Sum(CPRKQty)CPRKQty,Sum(CPPBQty)CPPBQty,sum(CPQty)CPQty,")
        sqlBuider.AppendLine("Sum(NowPBQty)NowPBQty,sum(NowPBZL)NowPBZL,")
        sqlBuider.AppendLine("Sum(CPQty+NowPBQty)NowQty,")
        sqlBuider.AppendLine("C.Client_Name,BZ_Name,BZ_No")
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
        sqlBuider.AppendLine("select Client_ID,BZ_ID,0,0,0,0,sum(qty)SumQty,sum(CWeight)SumPWeight,0,0,0,0,0")
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
      
        sqlBuider.Append(" group by B.Client_ID,Client_Name,BZ_Name,BZ_No,B.ID")
        sqlBuider.Append(" order by B.Client_ID,Client_Name,BZ_No")
        Return PClass.PClass.SqlStrToDt(sqlBuider.ToString, paraMap)
    End Function



End Class


#End Region



