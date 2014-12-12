Imports System.Data
Imports PClass
Imports BaseClass
Imports PClass.PClass
Imports System.Text

Public Class R20920_Chaoliao_gather

    Inherits CReport
    Dim comletedCount As Integer = 0
    Protected fileName As String = "R20920_Chaoliao_gather.grf"

    Dim FirstDate As Date
    Dim LastDate As Date
    Dim Times As Integer = 0
    Dim IsCheck30 As Boolean = True
    Dim haveRL As Boolean = False
    Dim Reason As String

    Sub New()
        ReportFile = Me.fileName
        ReDim Dt_Header(1)
    End Sub

    Sub SetOption(ByVal startDate As Date, ByVal endDate As Date, ByVal havRanliao As Boolean, ByVal Reason As String, Optional ByVal Times As Integer = 0, Optional ByVal IsCheck30 As Boolean = True)
        Me.FirstDate = startDate
        Me.LastDate = endDate
        Me.Reason = Reason
        Me.Times = Times
        Me.IsCheck30 = IsCheck30
        Me.haveRL = havRanliao
    End Sub

    Sub Start(Optional ByVal _operator As OperatorType = OperatorType.LoadFile)
        If _operator = OperatorType.LoadFile Then


            Dim msg As DtReturnMsg = Dao.ChaoLiao_Get(FirstDate, LastDate, Reason, Times, IsCheck30, haveRL)
            If msg.IsOk Then
                msg.Dt.Columns.Add("Cereason", GetType(String))
                For i As Integer = 0 To msg.Dt.Rows.Count - 1

                    If msg.Dt.Rows(i)("Count_JiaLiso") > 2 AndAlso msg.Dt.Rows(i)("Amount_JiaLiao") > msg.Dt.Rows(i)("sumAmount") * 0.3 Then
                        msg.Dt.Rows(i)("Cereason") = "加料单数与总价超额"
                    ElseIf msg.Dt.Rows(i)("Count_JiaLiso") > 2 Then
                        msg.Dt.Rows(i)("Cereason") = "加料单数超过2张"
                    ElseIf msg.Dt.Rows(i)("Amount_JiaLiao") > msg.Dt.Rows(i)("sumAmount") * 0.3 Then
                        msg.Dt.Rows(i)("Cereason") = "加料总价超30%"
                    Else
                        msg.Dt.Rows(i)("Cereason") = ""
                    End If

                Next



            End If

            Dt_Header(1) = New DataTable("T")
            Dt_List = msg.Dt

            If _operator = OperatorType.LoadFile Then
                Me.LoadReport()
            Else
                Me.DoWork()
            End If
        Else
            Me.DoOperator = _operator
            Me.DoWork()
        End If
    End Sub

End Class
#Region "数据库交换"

Partial Friend Class Dao




    Public Shared Function ChaoLiao_Get(ByVal startDate As Date, ByVal endDate As Date, ByVal Reason As String, Optional ByVal Times As Integer = 0, Optional ByVal IsCheck30 As Boolean = True, Optional ByVal haveRL As Boolean = False) As DtReturnMsg

        Dim para As New Dictionary(Of String, Object)
        para.Add("@StartDate", startDate)
        para.Add("@EndDate", endDate.AddDays(1).AddSeconds(-1))
        para.Add("@Reason", Reason)
        para.Add("@Times", Times)

        Dim sqlBuider As New StringBuilder()
        'sqlBuider.AppendLine("select T.*,J.Count_JiaLiso,Amount_JiaLiao,BZ.BZ_No,BZ.BZ_Name ")
        'sqlBuider.AppendLine(" from T20310_LingLiao_Table T left join T10002_BZ BZ on BZ.ID=T.BZ_ID  ")
        'sqlBuider.AppendLine(" left join (  ")
        'sqlBuider.AppendLine(" select Produce_ID,Type,Count(*) Count_JiaLiso,Isnull(Sum(SumAmount),0) Amount_JiaLiao from T20310_LingLiao_Table  ")
        'sqlBuider.AppendLine(" where State=1 and IsJiaLiao=1 group by Produce_ID,Type)J on  J.Produce_ID=T.Produce_ID  and j.Type=T.Type")
        'sqlBuider.AppendLine(" Where Audited_Date BETWEEN @StartDate and @EndDate and ")
        'sqlBuider.AppendLine(" State>-1 and   IsJiaLiao = 0 And (Count_JiaLiso > @Times ")
        'If IsCheck30 Then
        '    sqlBuider.AppendLine("  Or Amount_JiaLiao > sumAmount * 0.3 ")
        'End If
        'sqlBuider.AppendLine(" ) And IsPageTwo=0 order by T.id  ")


        sqlBuider.AppendLine("SELECT   MainBill,Type,count(*) as T_Count,sum(SumAmount) as T_Sum into #T")
        sqlBuider.AppendLine("FROM T20310_LingLiao_Table ")
        sqlBuider.AppendLine(" T  ")
        sqlBuider.AppendLine("where Audited_Date between @StartDate and @EndDate and State=1 and IsJiaLiao=1")
        If haveRL Then
            sqlBuider.AppendLine(" and  exists( select * from T20311_LingLiao_List L ,T10001_WL W where  L.ID=T.ID and L.Wl_ID=W.ID and  WL_Type_ID like 'GT003002%' )")
        End If

        sqlBuider.AppendLine("group by MainBill,Type")
        sqlBuider.AppendLine("select T.MainBill,T.Type,max(Audited_Date) LastDate,count(*) as Count_JiaLiso,sum(SumAmount) as Amount_JiaLiao into #A ")
        sqlBuider.AppendLine("from  #T,T20310_LingLiao_Table T ")
        sqlBuider.AppendLine("where T.MainBill=#T.MainBill and T.Type=#T.Type and State=1 and IsJiaLiao=1 and isnull(IsPageTwo,0)=0")
        sqlBuider.AppendLine("group by T.MainBill,T.Type")
        sqlBuider.AppendLine("select T.MainBill,Audited_Date,SumQty,SumAmount,Reason,BZ_Qty,BZ_ZL,LastDate,BZC_No,BZC_Name,Produce_ID,T.ReportRemark,")
        sqlBuider.AppendLine("T_Count,T_Sum,")
        sqlBuider.AppendLine("Count_JiaLiso,Amount_JiaLiao,BZ.BZ_No,BZ.BZ_Name from  #T ")
        sqlBuider.AppendLine("left join T20310_LingLiao_Table T on T.id=#T.MainBill and T.Type=#T.Type")
        sqlBuider.AppendLine("left join T10002_BZ BZ on BZ.ID=T.BZ_ID ")
        sqlBuider.AppendLine("left join #A A on A.MainBill=#T.MainBill and  A.Type=#T.Type ")
        sqlBuider.AppendLine("where isnull(IsPageTwo,0)=0 and  (Count_JiaLiso > @Times")
        If IsCheck30 Then
            sqlBuider.AppendLine("  Or Amount_JiaLiao > sumAmount * 0.3 ")
        End If
        If Reason <> "全部" Then
            sqlBuider.AppendLine(" ) and (Reason =@Reason ")
        End If

        sqlBuider.AppendLine(") order by T.id  ")
        Return PClass.PClass.SqlStrToDt(sqlBuider.ToString, para)

    End Function

End Class


#End Region

