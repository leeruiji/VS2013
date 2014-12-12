Imports System.Data
Imports PClass
Imports BaseClass
Imports PClass.PClass
Imports System.Text

Public Class R20900_Store_Summary

    Inherits CReport
    Dim comletedCount As Integer = 0
    Protected fileName As String = "R20900_Store_Summary.grf"



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
            Dim msg As DtReturnMsg = Dao.StoreSummary_Get(FirstDate, LastDate, Disable, OList)
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
Public Enum ENum_Disable
    Disable = 0
    Enable = 1
    All = 2
End Enum
Partial Friend Class Dao


    ''' <summary>
    ''' 获取查询条件集合
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function StoreSummary_GetConditionNames() As List(Of FindOption)
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


    Public Shared Function StoreSummary_Get(ByVal startDate As Date, ByVal endDate As Date, ByVal isDisable As ENum_Disable, ByVal Olist As List(Of FindOption)) As DtReturnMsg
        Dim r As New DtReturnMsg
        r.IsOk = False
        Dim para As New Dictionary(Of String, Object)
        para.Add("@StartDate", startDate)
        para.Add("@EndDate", endDate)

        'Dim sqlBuider As New StringBuilder()
        'sqlBuider.AppendLine("select W.WL_Type_ID, GoodsType_Name,W.WL_Name,WL_Spec,WL_Unit,W.WL_No  ,")
        'sqlBuider.AppendLine("Isnull(WL_Qty,0)-Isnull(EndQty,0)-Isnull(InQty,0)-Isnull(OutQty,0) as StartQty  ,")
        'sqlBuider.AppendLine("(Isnull(WL_Qty,0)-Isnull(EndQty,0)-Isnull(InQty,0)-Isnull(OutQty,0))*isnull(WL_Cost,0) as StartAmount  ,")
        'sqlBuider.AppendLine("Isnull(InQty,0) as InQty  ,")
        'sqlBuider.AppendLine("Isnull(InAmount,0) as InAmount  ,")
        'sqlBuider.AppendLine("Isnull(OutQty,0) as OutQty  ,")
        'sqlBuider.AppendLine("Isnull(OutAmount,0) as OutAmount  ,")
        'sqlBuider.AppendLine("Isnull(WL_Qty,0)-Isnull(EndQty,0) as EndQty ,")
        'sqlBuider.AppendLine("(Isnull(WL_Qty,0)-Isnull(EndQty,0))*isnull(WL_Cost,0) as EndAmount ,")
        'sqlBuider.AppendLine("isnull(WL_Cost,0) Cost  ,")
        'sqlBuider.AppendLine("Isnull(WL_Qty,0) as WL_Qty from  T10001_WL  W ")
        'sqlBuider.AppendLine("left join (  select WL_ID,sum(Qty) InQty,sum(Qty*StoreINorOut*Cost) InAmount from T10050_Store_Detail (INDEX=IX_T10050_Store_Detail_1) ")
        'sqlBuider.AppendLine("where sDate between @StartDate and @EndDate  and StoreINorOut =1 and BillType>10013 group by WL_ID)I on W.id=i.Wl_id  ")
        'sqlBuider.AppendLine("left join (  select WL_ID,sum(Qty*StoreINorOut) OutQty,sum(Qty*StoreINorOut*Cost) OutAmount from T10050_Store_Detail (INDEX=IX_T10050_Store_Detail_1) ")
        'sqlBuider.AppendLine("where sDate between @StartDate and @EndDate  and StoreINorOut =-1 and BillType>10013 group by WL_ID)O on W.id=o.Wl_id ")
        'sqlBuider.AppendLine("left join (  select WL_ID,sum(Qty*StoreINorOut) EndQty from T10050_Store_Detail (INDEX=IX_T10050_Store_Detail_1) ")
        'sqlBuider.AppendLine("where sDate > @EndDate  and BillType>10013  group by WL_ID)E on W.id=e.Wl_id   ")
        'sqlBuider.AppendLine("left join (select T.GoodsType_id,isnull(L.GoodsType_Name,T.GoodsType_Name)GoodsType_Name from T10000_GoodsType T   ")
        'sqlBuider.AppendLine("left join     (select  L.GoodsType_id, (A.GoodsType_Name+'.'+L.GoodsType_name)GoodsType_Name from   T10000_GoodsType L,T10000_GoodsType A ")
        'sqlBuider.AppendLine(" where len(L.GoodsType_id)>5    and A.GoodsType_id=left(L.GoodsType_id,len(L.GoodsType_id)-3)  )L on T.GoodsType_id=l.GoodsType_id) T on GoodsType_ID=WL_Type_ID  ")


        Dim sqlBuider As New StringBuilder()
        sqlBuider.AppendLine("select wl_id, ")
        sqlBuider.AppendLine("SUM(Convert(decimal(18,2),(CASE WHEN StoreINorOut = 1 THEN Qty ELSE 0.0 END)))  as InQty,")
        sqlBuider.AppendLine("SUM(Convert(decimal(18,2),(CASE WHEN StoreINorOut = 1 THEN Qty * Cost ELSE 0.0 END))) as InAmount,")
        sqlBuider.AppendLine("SUM(Convert(decimal(18,2),(CASE WHEN StoreINorOut = - 1 THEN -Qty ELSE 0.0 END))) AS OutQty, ")
        sqlBuider.AppendLine("SUM(Convert(decimal(18,2),(CASE WHEN StoreINorOut = - 1 THEN - Qty * Cost ELSE 0.0 END))) AS OutAmount")
        sqlBuider.AppendLine("INTO #oi FROM dbo.T10050_Store_Detail(NOLOCK) WHERE (BillType > 10013)")
        sqlBuider.AppendLine("and sDate between @StartDate and @EndDate group by wl_id")

        sqlBuider.AppendLine("select wl_id,SUM(Qty*StoreINorOut) AS EndQty   INTO #E  from dbo.T10050_Store_Detail(NOLOCK) ")
        sqlBuider.AppendLine("    where (BillType > 10013) and  sDate > @EndDate   group by wl_id")

        sqlBuider.AppendLine("select W.WL_Type_ID, GoodsType_Name,W.WL_Name,WL_Spec,WL_Unit,W.WL_No  ,")
        sqlBuider.AppendLine("Isnull(WL_Qty,0)-Isnull(EndQty,0)-Isnull(InQty,0)-Isnull(OutQty,0) as StartQty  ,")
        sqlBuider.AppendLine("(Isnull(WL_Qty,0)-Isnull(EndQty,0)-Isnull(InQty,0)-Isnull(OutQty,0))*isnull(WL_Cost,0) as StartAmount  ,")
        sqlBuider.AppendLine("Isnull(InQty,0) as InQty  ,")
        sqlBuider.AppendLine("Isnull(InAmount,0) as InAmount  ,")
        sqlBuider.AppendLine("Isnull(OutQty,0) as OutQty  ,")
        sqlBuider.AppendLine("Isnull(OutAmount,0) as OutAmount  ,")
        sqlBuider.AppendLine("Isnull(WL_Qty,0)-Isnull(EndQty,0) as EndQty ,")
        sqlBuider.AppendLine("(Isnull(WL_Qty,0)-Isnull(EndQty,0))*isnull(WL_Cost,0) as EndAmount ,")
        sqlBuider.AppendLine("isnull(WL_Cost,0) Cost  ,")
        '  sqlBuider.AppendLine("isnull(SumLoss,0) SumLoss  ,")
        sqlBuider.AppendLine("Isnull(WL_Qty,0) as WL_Qty from  T10001_WL   W (NOLOCK) ")

        sqlBuider.AppendLine(" left join #oi  oi On Oi.wl_id=w.id")
        sqlBuider.AppendLine(" left join #E E On E.wl_id=w.id")
        sqlBuider.AppendLine("left join V10000_GoodsType T (NOLOCK) on GoodsType_ID=WL_Type_ID ")


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


