Imports System.Data
Imports PClass
Imports BaseClass
Imports PClass.PClass
Imports System.Text

Public Class R50040_PrinceSummary

    Inherits CReport
    Dim comletedCount As Integer = 0
    Protected fileName As String = "R50040_PrinceSummary.grf"

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

    Sub SetOption(ByVal startDate As Date)

    End Sub

    Sub Start(ByVal Excelout As Boolean, ByVal StartDate As Date, ByVal EndDate As Date, ByVal Client_id As Integer, ByVal BZC_ID As Integer, ByVal Times As String, ByVal iscomfirm As String, Optional ByVal _operator As OperatorType = OperatorType.LoadFile)


        If Excelout Then
            Me.SetCanExcelOut()
        Else
            Me.SetCanNotExcelOut()
        End If

        If _operator = OperatorType.LoadFile OrElse LF <> Ln Then
            Dim msg As DtReturnMsg = Dao.LuoSe_DaySummary_Get(StartDate, EndDate, Client_id, BZC_ID, Times, iscomfirm)
            If msg.IsOk Then
                If IsLoaded = False Then
                    dtGoods = msg.Dt
                    IsLoaded = True
                Else
                    If dtGoods.Rows.Count < msg.Dt.Rows.Count Then
                        dtGoods = msg.Dt
                    End If
                End If
                msg.Dt.Columns.Add("spec")
                'For Each R As DataRow In msg.Dt.Rows
                '    If IsNull(R("BZ_No"), "").ToString.Contains("#") Then
                '        R("BZ") = R("BZ_No") & R("BZ")
                '    End If
                '    If IsNull(R("ClientBZC"), "") <> "" Then
                '        R("BZC") = R("ClientBZC") & "#" & IsNull(R("BZC") & Format(IsNull(R("BZC_No"), 0), "GY000000") & IsNull(R("BZC_PF"), ""), "")
                '    Else
                '        R("BZC") = IsNull(R("BZC") & Format(IsNull(R("BZC_No"), 0), "GY000000") & IsNull(R("BZC_PF"), ""), "")
                '    End If

                '    Dim spec As String = ""
                '    If IsNull(R("CR_ShiYong"), "") <> "" Then
                '        spec = spec & "*" & R("CR_ShiYong")
                '    End If
                '    If IsNull(R("CR_BianDuiBian"), "") <> "" Then
                '        spec = spec & "*" & R("CR_BianDuiBian")
                '    End If
                '    If IsNull(R("CR_KeZhong"), "") <> "" Then
                '        spec = spec & "*" & R("CR_KeZhong")
                '    End If
                '    If spec.StartsWith("*") Then
                '        spec = spec.Substring(1)
                '    End If
                '    R("spec") = spec
                'Next

                Dt_List = msg.Dt
                LF = Ln
                Dim T As New DataTable("T")
                T.Columns.Add("price_time")
                T.Rows.Add()
                If StartDate = EndDate Then
                    T.Rows(0)("price_time") = StartDate
                Else
                    T.Rows(0)("price_time") = StartDate.ToString("yyyy-MM-dd") & "到" & EndDate.ToString("yyyy-MM-dd")
                End If

                Dt_Header(1) = T
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
    Public Shared Function LuoSe_DaySummary_GetConditionNames() As List(Of FindOption)
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


    Public Shared Function LuoSe_DaySummary_Get(ByVal StartDate As Date, ByVal EndDate As Date, ByVal Client_ID As Integer, ByVal BZC_ID As Integer, ByVal Times As String, ByVal iscomfirm As String) As DtReturnMsg
        Dim r As New DtReturnMsg
        r.IsOk = False
        Dim para As New Dictionary(Of String, Object)

        para.Add("@StartDate", StartDate)
        para.Add("@EndDate", EndDate)
        para.Add("@Client_ID", Client_ID)
        para.Add("@BZC_ID", BZC_ID)
        para.Add("@iscomfirm", iscomfirm)
        para.Add("Times", Times)
        Dim sqlBuider As New StringBuilder()
        'sqlBuider.Append(" select B.BZ_Name, price,iscomfirm,price_time,Client_Name,Bzc_No,BZC_Name,B.Client_id,P.BZC_ID from T50001_Price_List P")
        'sqlBuider.Append(" LEFT JOIN T10003_BZC B on B.ID =P.BZC_ID ")
        'sqlBuider.Append(" LEFT JOIN T10110_Client C on C.ID =B.Client_id ")

        '  sqlBuider.Append("select  Count (P.ID) as Times, price,MinPrice,MaxPrice,iscomfirm,price_time,Client_Name,Bzc_No,BZC_Name,Z.BZ_Name ,B.Client_id,P.BZC_ID ,T.cost,(select COUNT(GH ) from T30000_Produce_Gd where BZC_ID= p.BZC_ID and BZ_ID=p.BZ_ID ) as GHCount from T50001_Price_List P ")
        '  sqlBuider.Append(" left join  (select BZC_ID,BZ_ID, min(price) as MinPrice,max(price) as MaxPrice from T50001_Price_List group by   BZC_ID,BZ_ID ) p1 on p.BZC_ID=p1.BZC_ID and P.BZ_ID = P1.BZ_ID")

        '   sqlBuider.Append("select Count (P.ID) as Times, price,iscomfirm,price_time,Client_Name,Bzc_No,BZC_Name,Z.BZ_Name ,B.Client_id,P.BZC_ID ,T.cost,(select COUNT(GH ) from T30000_Produce_Gd where BZC_ID= p.BZC_ID and BZ_ID=p.BZ_ID ) as GHCount from T50001_Price_List P ")
        sqlBuider.AppendLine(" select Client_Name,Bzc_No,BZC_Name,Z.BZ_Name ,B.Client_id,P.BZC_ID ,T.cost,Times,MinPrice,MaxPrice")
        sqlBuider.AppendLine("  ,(select top 1 price from T50001_Price_List where BZC_ID= p.BZC_ID and BZ_ID=p.BZ_ID and IsLastPrice  =1  ) as LastPrice ")
        sqlBuider.AppendLine("   ,(select top 1 price from T50001_Price_List where BZC_ID= p.BZC_ID and BZ_ID=p.BZ_ID and IsComfirm =1 ) as ComfirmPrice")
        sqlBuider.AppendLine(" ,(select COUNT(GH ) from T30000_Produce_Gd where BZC_ID= p.BZC_ID and BZ_ID=p.BZ_ID ) as GHCount ")
        sqlBuider.AppendLine("  from (")
        sqlBuider.AppendLine(" select p.BZC_ID,p.BZ_ID ,min(price) as MInPrice,max(price) as MaxPrice,count(P.ID ) as Times")
        sqlBuider.AppendLine("  from T50001_Price_List P ,T50000_Price_Table T ")


        sqlBuider.Append(" where p.ID=T.ID and State>0 and price_time between @StartDate and @EndDate ")
        If Client_ID > 0 Then
            sqlBuider.Append("  And T.Client_id=@Client_ID ")
        End If
        If BZC_ID > 0 Then
            sqlBuider.Append("  And P.BZC_ID=@BZC_ID ")
        End If
        If iscomfirm <> "" Then
            sqlBuider.Append("  And iscomfirm=@iscomfirm ")
        End If

        sqlBuider.AppendLine("    group by p.BZC_ID,p.BZ_ID  ")
        If Times = "下单数大于0" Then
            sqlBuider.AppendLine("    having count(P.ID )>0 ")
        ElseIf Times = "报价次数大于0" Then
            sqlBuider.AppendLine(" having (select COUNT(GH ) from T30000_Produce_Gd where BZC_ID= p.BZC_ID and BZ_ID=p.BZ_ID )>0")
        End If
        sqlBuider.AppendLine("    ) P ")

        sqlBuider.Append(" LEFT JOIN T10003_BZC B on B.ID =P.BZC_ID")
        sqlBuider.Append(" LEFT JOIN T10002_BZ Z on B.BZ_ID  =Z.ID")
        sqlBuider.Append(" LEFT JOIN T10110_Client C on C.ID =B.Client_id ")
        sqlBuider.Append(" left join  ( select P.BZC_ID, sum(Wl_Price*1000*0.01*Pl.Qty)  as cost ")
        sqlBuider.Append(" from  (SELECT BZC_ID ,ID from T10010_BZC_PF WHERE IsOK=1) P ")
        sqlBuider.Append(" left join(SELECT WL_ID, BZC_ID,Qty,ID,Line FROM T10011_BZC_PFList where WL_ID>0) Pl  ")
        sqlBuider.Append(" on P.BZC_ID=Pl.BZC_ID and P.ID=Pl.ID ")
        sqlBuider.Append(" left join T10001_WL W on Pl.WL_ID=W.ID group by P.BZC_ID) T on T .BZC_ID=P.BZC_ID")
        sqlBuider.Append(" order by B.Client_id,Bzc_No")





        'sqlBuider.Append("select G.Client_ID,G.ProcessType,G.BZ_ID,BZC_ID,Client_Name,ClientBZC,BZC_PF")
        'sqlBuider.Append(" ,BZ_No,BZ_Name as BZ")
        'sqlBuider.Append(",BZC_No,BZC_Name as BZC")
        'sqlBuider.Append(",CR_ShiYong,CR_BianDuiBian,CR_KeZhong")
        'sqlBuider.Append(",GH,Contract,CR_LuoSeBzCount,Remark,CR_BianDuiBian,CR_ShiYong,CR_BianDuiBian from T30000_Produce_Gd G")
        'sqlBuider.Append(" left join T10002_BZ BZ on G.BZ_ID=BZ.ID ")
        'sqlBuider.Append("left join T10003_BZC BZC on G.BZC_ID=BZC.ID ")
        'sqlBuider.Append(" left join T10110_Client C on G.Client_ID=C.ID  ")
        'sqlBuider.Append("  where State>0 and  Date_LuoSe between @StartDate and @EndDate ")






        '   sqlBuider.Append("group by P .Price ,MinPrice,MaxPrice,P.IsComfirm ,P.Price_Time ,C.Client_Name ,B.BZC_No ,B.BZC_Name ,Z.BZ_Name ,B.Client_id ,P.BZC_ID ,T.cost  order by Client_Name,Bzc_No,iscomfirm desc")
        Return PClass.PClass.SqlStrToDt(sqlBuider.ToString, para)

    End Function

End Class


#End Region


