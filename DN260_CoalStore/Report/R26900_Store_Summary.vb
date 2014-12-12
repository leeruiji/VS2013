Imports System.Data
Imports PClass
Imports BaseClass
Imports PClass.PClass
Imports System.Text

Public Class R26900_Store_Summary

    Inherits CReport
    Dim comletedCount As Integer = 0
    Protected fileName As String = "R20900_Store_Summary.grf"

    Dim FirstDate As Date
    Dim LastDate As Date
    Dim LF As Integer = 0
    Dim Ln As Integer = 0
    Dim OList As List(Of FindOption)
    Public dtGoods As DataTable
    Dim IsLoaded As Boolean = False


    Sub New()
        ReportFile = Me.fileName
        ReDim Dt_Header(1)
    End Sub

    Sub SetOption(ByVal startDate As Date, ByVal endDate As Date, ByVal Olist As List(Of FindOption))
        FirstDate = startDate
        LastDate = endDate
        Me.OList = Olist
        Ln = Ln + 1
    End Sub

    Sub Start(Optional ByVal _operator As OperatorType = OperatorType.LoadFile)
        If _operator = OperatorType.LoadFile OrElse LF <> Ln Then
            Dim msg As DtReturnMsg = Dao.StoreSummary_Get(FirstDate, LastDate, OList)
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


    Public Shared Function StoreSummary_Get(ByVal startDate As Date, ByVal endDate As Date, ByVal Olist As List(Of FindOption)) As DtReturnMsg
        Dim r As New DtReturnMsg
        r.IsOk = False
        Dim para As New Dictionary(Of String, Object)
        para.Add("@StartDate", startDate)
        para.Add("@EndDate", endDate)


        Dim sqlBuider As New StringBuilder()
        sqlBuider.Append("select W.WL_Type_ID, GoodsType_Name,W.WL_Name,WL_Spec,WL_Unit,W.WL_No ")
        sqlBuider.Append(" ,isnull(WL_Cost,0) Cost ") '--成本价 
        sqlBuider.Append(" ,Isnull(StartQty,0) as StartQty ") '--期初数 
        sqlBuider.Append(" ,Isnull(StartAmount,0) as StartAmount ") '--期初数
        sqlBuider.Append(" ,Isnull(InQty,0) as InQty ") '--入库数
        sqlBuider.Append(" ,Isnull(InAmount,0) as InAmount ") '--入库数
        sqlBuider.Append(" ,Isnull(OutQty,0) as OutQty ") '--出库数
        sqlBuider.Append(" ,Isnull(OutAmount,0) as OutAmount ")


        sqlBuider.Append(" ,Isnull(EndQty,0) as EndQty") '--期末库存 
        sqlBuider.Append(" ,Isnull(EndAmount,0) as EndAmount") '--期末库存 
        sqlBuider.Append(" ,Isnull(WL_Qty,0) as WL_Qty") '--当前库存 
        sqlBuider.Append(" from  T26001_WLCoal  W ")
        sqlBuider.Append(" left join ( ")
        sqlBuider.Append(" select WL_ID,sum(Qty*StoreINorOut) StartQty,sum(Qty*StoreINorOut*Cost) StartAmount from T26003_Store_Detail where sDate < @StartDate  ")
        sqlBuider.Append(" group by WL_ID)S on W.id=s.Wl_id ")
        sqlBuider.Append(" left join ( ")
        sqlBuider.Append(" select WL_ID,sum(Qty) InQty,sum(Qty*StoreINorOut*Cost) InAmount from T26003_Store_Detail where sDate between @StartDate and @EndDate ")
        sqlBuider.Append(" and StoreINorOut =1 ")
        sqlBuider.Append(" group by WL_ID)I on W.id=i.Wl_id ")

        sqlBuider.Append(" left join ( ")
        sqlBuider.Append(" select WL_ID,sum(Qty*StoreINorOut) OutQty,sum(Qty*StoreINorOut*Cost) OutAmount from T26003_Store_Detail where sDate between @StartDate and @EndDate ")

        sqlBuider.Append(" and StoreINorOut =-1 ")
        sqlBuider.Append(" group by WL_ID)O on W.id=o.Wl_id ")
        sqlBuider.Append(" left join ( ")
        sqlBuider.Append(" select WL_ID,sum(Qty*StoreINorOut) EndQty,sum(Qty*StoreINorOut*Cost) EndAmount from T26003_Store_Detail where sDate <= @EndDate   ")
        sqlBuider.Append(" group by WL_ID)E on W.id=e.Wl_id  ")
        sqlBuider.Append(" left join (select T.GoodsType_id,isnull(L.GoodsType_Name,T.GoodsType_Name)GoodsType_Name from T26000_GoodsType T  ")
        sqlBuider.Append(" left join   ")
        sqlBuider.Append("  (select  L.GoodsType_id, (A.GoodsType_Name+'.'+L.GoodsType_name)GoodsType_Name from  ")
        sqlBuider.Append(" T26000_GoodsType L,T26000_GoodsType A ")
        sqlBuider.Append(" where len(L.GoodsType_id)>5  ")
        sqlBuider.Append("  and A.GoodsType_id=left(L.GoodsType_id,len(L.GoodsType_id)-3) ")
        sqlBuider.Append(" )L on T.GoodsType_id=l.GoodsType_id) T on GoodsType_ID=WL_Type_ID  ")


        If Olist.Count > 0 Then
            '  BaseClass.OptionClass.OptionClass_BuidSqlConditon(Olist, para)
            sqlBuider.Append(" where 1=1 ")
            sqlBuider.Append(BaseClass.OptionClass.OptionClass_BuidSqlConditon(Olist, para))
        End If
        sqlBuider.Append(" order by w.WL_Type_ID,WL_NO  ")
        Return PClass.PClass.SqlStrToDt(sqlBuider.ToString, para)

    End Function

End Class


#End Region


