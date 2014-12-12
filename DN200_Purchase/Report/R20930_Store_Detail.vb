Imports System.Data
Imports PClass
Imports BaseClass
Imports PClass.PClass
Imports System.Text

Public Class R20930_Store_Detail

    Inherits CReport
    Dim comletedCount As Integer = 0
    Protected fileName As String = "R20930_Store_Detail.grf"



    Dim FirstDate As Date
    Dim LastDate As Date
    Dim Disable As ENum_Disable
    Dim LF As Integer = 0
    Dim Ln As Integer = 0
    Dim OList As List(Of FindOption)
    Public dtGoods As DataTable
    Dim IsLoaded As Boolean = False


    Sub New()
        ReportFile = Me.fileName
        ReDim Dt_Header(1)
    End Sub

    Sub SetOption(ByVal startDate As Date, ByVal endDate As Date, ByVal iDisable As ENum_Disable, ByVal Olist As List(Of FindOption))
        FirstDate = startDate
        LastDate = endDate
        Disable = iDisable
        Me.OList = Olist
        Ln = Ln + 1
    End Sub

    Sub Start(Optional ByVal _operator As OperatorType = OperatorType.LoadFile)
        If _operator = OperatorType.LoadFile OrElse LF <> Ln Then
            Dim msg As DtReturnMsg = Dao.StoreDetail_Get(FirstDate, LastDate, Disable, OList)
            If msg.IsOk Then
                If IsLoaded = False Then
                    dtGoods = msg.Dt
                    IsLoaded = True
                Else
                    If dtGoods.Rows.Count < msg.Dt.Rows.Count Then
                        dtGoods = msg.Dt
                    End If
                End If
                Dt_List = msg.Dt
                LF = Ln
                Dt_Header(1) = New DataTable("T")
                Me.DoOperator = _operator
                If _operator = OperatorType.LoadFile Then
                    Me.LoadReport()
                Else
                    Me.DoWork()
                End If
            Else
                MsgBox(msg.Msg)
            End If
        Else
            Me.DoOperator = _operator
            Me.DoWork()
        End If
    End Sub

End Class
#Region "数据库交换"

Partial Friend Class Dao


    ''' <summary>
    ''' 获取查询条件集合
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function StoreDetail_GetConditionNames() As List(Of FindOption)
        Dim foList As New List(Of FindOption)
        Dim fo As New FindOption
        fo.Field = "请选择"
        fo.DB_Field = ""
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "商品编号"
        fo.DB_Field = "WL_NO"
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "商品名称"
        fo.DB_Field = "WL_Name"
        foList.Add(fo)



        Return foList
    End Function


    Public Shared Function StoreDetail_Get(ByVal startDate As Date, ByVal endDate As Date, ByVal isDisable As ENum_Disable, ByVal Olist As List(Of FindOption)) As DtReturnMsg
        Dim r As New DtReturnMsg
        r.IsOk = False
        Dim para As New Dictionary(Of String, Object)
        para.Add("@StartDate", startDate)
        para.Add("@EndDate", endDate)


        Dim sqlBuider As New StringBuilder()
        'sqlBuider.AppendLine("select  W.WL_Type_ID, GoodsType_Name,W.WL_Name,WL_Spec,WL_Unit,W.WL_No  ,")
        'sqlBuider.AppendLine("Isnull(WL_Qty,0)-Isnull(EndQty,0)-Isnull(InQty,0)-Isnull(OutQty,0) as StartQty  ,")
        ''   sqlBuider.AppendLine("(Isnull(WL_Qty,0)-Isnull(EndQty,0)-Isnull(InQty,0)-Isnull(OutQty,0)+isnull(SumLoss,0))*isnull(WL_Cost,0) as StartAmount  ,")
        ''  sqlBuider.AppendLine("Isnull(InQty,0) as InQty  ,")
        ''   sqlBuider.AppendLine("Isnull(InAmount,0) as InAmount  ,")
        ''   sqlBuider.AppendLine("Isnull(OutQty,0) as OutQty  ,")
        ''   sqlBuider.AppendLine("Isnull(OutAmount,0) as OutAmount  ,")
        'sqlBuider.AppendLine("Isnull(WL_Qty,0)-Isnull(EndQty,0) as EndQty ,")
        ''  sqlBuider.AppendLine("(Isnull(WL_Qty,0)-Isnull(EndQty,0)+isnull(SumLoss,0))*isnull(WL_Cost,0) as EndAmount ,")
        'sqlBuider.AppendLine("isnull(PurQty,0) PurQty  ,")
        'sqlBuider.AppendLine("isnull(OtherQty,0) OtherQty  ,")
        'sqlBuider.AppendLine("isnull(LingLiaoQty,0) LingLiaoQty  ,")
        'sqlBuider.AppendLine("isnull(LossQty,0) LossQty  ,")
        'sqlBuider.AppendLine("isnull(WL_Cost,0) Cost  ,")
        ''  sqlBuider.AppendLine("-1*isnull(SumLoss,0) SumLoss  ,")
        'sqlBuider.AppendLine("Isnull(WL_Qty,0) as WL_Qty from  T10001_WL  W ")

        ''采购
        'sqlBuider.AppendLine(" left join (select wl_id, sum(StoreInOrOut*Qty) as PurQty,sum(StoreInOrOut*Qty*Cost) as PurAmount from T10050_Store_Detail where BillType>=20000 and BillType<20100 ")
        'sqlBuider.AppendLine("    and  sDate between @StartDate and @EndDate group by wl_id)  Pur On Pur.wl_id=w.id")
        ''其他
        'sqlBuider.AppendLine(" left join (select wl_id, sum(StoreInOrOut*Qty) as OtherQty,sum(StoreInOrOut*Qty*Cost) as OtherAmount from T10050_Store_Detail where BillType>=20200 and BillType<=20300  ")
        'sqlBuider.AppendLine("    and  sDate between @StartDate and @EndDate group by wl_id)  Other On Other.wl_id=w.id")
        ''领料
        'sqlBuider.AppendLine(" left join (select wl_id, sum(StoreInOrOut*Qty) as LingLiaoQty,sum(StoreInOrOut*Qty*Cost) as LingLiaoAmount from T10050_Store_Detail where BillType>=20310 and BillType<20330  ")
        'sqlBuider.AppendLine("    and  sDate between @StartDate and @EndDate group by wl_id)  LL On LL.wl_id=w.id")

        ''损耗
        'sqlBuider.AppendLine(" left join (select wl_id, sum(StoreInOrOut*Qty) as LossQty,sum(StoreInOrOut*Qty*Cost) as LossAmount from T10050_Store_Detail where BillType=20400  ")
        'sqlBuider.AppendLine("    and  sDate between @StartDate and @EndDate group by wl_id)  Loss On Loss.wl_id=w.id")
        ''查询时间内出入库数
        'sqlBuider.AppendLine(" left join (select wl_id,sum(InQty)InQty,sum(InAmount)InAmount,sum(OutQty)OutQty,sum(OutAmount)OutAmount from V10050_Store_Day ")
        'sqlBuider.AppendLine("    where  sDate between @StartDate and @EndDate group by wl_id)  oi On Oi.wl_id=w.id")
        ''查询时间外出入库数
        'sqlBuider.AppendLine(" left join (select wl_id,sum(InQty+OutQty)EndQty from V10050_Store_Day ")
        'sqlBuider.AppendLine("    where  sDate > @EndDate   group by wl_id) E On E.wl_id=w.id")
        ' ''计算损耗
        ''sqlBuider.AppendLine(" left join (select WL_ID, sum(L.Loss) SumLoss from T20400_StockAdjust_Table T, T20401_StockAdjust_List L ")
        ''sqlBuider.AppendLine("    where T.ID=L.ID  and T.State=1 and  sDate between @StartDate and @EndDate group by WL_ID  ) P On P.wl_id=w.id")

        'sqlBuider.AppendLine("left join V10000_GoodsType T on GoodsType_ID=WL_Type_ID ")

        sqlBuider.AppendLine("select wl_id, sum(StoreInOrOut*Qty) as PurQty,sum(StoreInOrOut*Qty*Cost) as PurAmount Into #Pur from T10050_Store_Detail where BillType>=20000 and BillType<20100 ")
        sqlBuider.AppendLine("and  sDate between @StartDate and @EndDate group by wl_id")

        sqlBuider.AppendLine("select wl_id, sum(StoreInOrOut*Qty) as OtherQty,sum(StoreInOrOut*Qty*Cost) as OtherAmount Into #Other from T10050_Store_Detail where BillType>=20200 and BillType<20200 ")
        sqlBuider.AppendLine("and  sDate between @StartDate and @EndDate group by wl_id")

        sqlBuider.AppendLine("select wl_id, sum(StoreInOrOut*Qty) as LingLiaoQty,sum(StoreInOrOut*Qty*Cost) as LingLiaoAmount Into #LL from T10050_Store_Detail where BillType>=20310 and BillType<20330 ")
        sqlBuider.AppendLine("and  sDate between @StartDate and @EndDate group by wl_id")

        sqlBuider.AppendLine("select wl_id, sum(StoreInOrOut*Qty) as LossQty,sum(StoreInOrOut*Qty*Cost) as LossAmount Into #Loss from T10050_Store_Detail where BillType=20400 ")
        sqlBuider.AppendLine("and  sDate between @StartDate and @EndDate group by wl_id")

        sqlBuider.AppendLine("select wl_id, ")
        sqlBuider.AppendLine("SUM(Convert(decimal(18,2),(CASE WHEN StoreINorOut = 1 THEN Qty ELSE 0.0 END)))  as InQty,")
        sqlBuider.AppendLine("SUM(Convert(decimal(18,2),(CASE WHEN StoreINorOut = 1 THEN Qty * Cost ELSE 0.0 END))) as InAmount,")
        sqlBuider.AppendLine("SUM(Convert(decimal(18,2),(CASE WHEN StoreINorOut = - 1 THEN -Qty ELSE 0.0 END))) AS OutQty, ")
        sqlBuider.AppendLine("SUM(Convert(decimal(18,2),(CASE WHEN StoreINorOut = - 1 THEN - Qty * Cost ELSE 0.0 END))) AS OutAmount")
        sqlBuider.AppendLine("INTO #oi FROM dbo.T10050_Store_Detail(NOLOCK) WHERE (BillType > 10013)")
        sqlBuider.AppendLine("and sDate between @StartDate and @EndDate group by wl_id")


        sqlBuider.AppendLine("select wl_id,SUM(Qty*StoreINorOut) AS EndQty   INTO #E  from dbo.T10050_Store_Detail(NOLOCK) ")
        sqlBuider.AppendLine("    where (BillType > 10013) and  sDate > @EndDate   group by wl_id")


        sqlBuider.AppendLine("select  W.WL_Type_ID, GoodsType_Name,W.WL_Name,WL_Spec,WL_Unit,W.WL_No  ,")
        sqlBuider.AppendLine("Isnull(WL_Qty,0)-Isnull(EndQty,0)-Isnull(InQty,0)-Isnull(OutQty,0) as StartQty  ,")
        sqlBuider.AppendLine("Isnull(WL_Qty,0)-Isnull(EndQty,0) as EndQty ,")
        sqlBuider.AppendLine("isnull(PurQty,0) PurQty  ,")
        sqlBuider.AppendLine("isnull(OtherQty,0) OtherQty  ,")
        sqlBuider.AppendLine("isnull(LingLiaoQty,0) LingLiaoQty  ,")
        sqlBuider.AppendLine("isnull(LossQty,0) LossQty  ,")
        sqlBuider.AppendLine("isnull(WL_Cost,0) Cost  ,")
        sqlBuider.AppendLine("Isnull(WL_Qty,0) as WL_Qty from  T10001_WL  W ")

        '采购
        sqlBuider.AppendLine(" left join #Pur Pur On Pur.wl_id=w.id")
        '其他
        sqlBuider.AppendLine(" left join #Other Other On Other.wl_id=w.id")
        '领料
        sqlBuider.AppendLine(" left join #LL  LL On LL.wl_id=w.id")

        '损耗
        sqlBuider.AppendLine(" left join #Loss Loss On Loss.wl_id=w.id")
        '查询时间内出入库数
        sqlBuider.AppendLine(" left join #oi  oi On Oi.wl_id=w.id")
        '查询时间外出入库数
        sqlBuider.AppendLine(" left join #E E On E.wl_id=w.id")


        sqlBuider.AppendLine("left join V10000_GoodsType T on GoodsType_ID=WL_Type_ID ")



        'If Olist.Count > 0 Then
        '  BaseClass.OptionClass.OptionClass_BuidSqlConditon(Olist, para)
        sqlBuider.Append(" where 1=1 ")
        sqlBuider.Append(BaseClass.OptionClass.OptionClass_BuidSqlConditon(Olist, para))
        Select Case isDisable
            Case ENum_Disable.Disable
                sqlBuider.Append(" and WL_Disable=0 ")
            Case ENum_Disable.Enable
                sqlBuider.Append(" and WL_Disable=1 ")
        End Select

        sqlBuider.Append(" order by w.WL_Type_ID,WL_NO  ")
        Return PClass.PClass.SqlStrToDt(sqlBuider.ToString, para)
        'Else
        '    para.Add("@Disable", isDisable)
        '    Return PClass.PClass.SqlStrToDt("F20900_Store_Summary", para, True)
        'End If
    End Function

End Class


#End Region


