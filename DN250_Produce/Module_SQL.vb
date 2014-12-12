Module Module_SQL

    '===================生产单信息==============
    Public Const SQL_Produce_Get_Sel As String = "select  P.* "

    Public Const SQL_Produce_Get_Body As String = " from T25000_Produce_table P   "

    Public Const SQL_Produce_Get_leftJoin_GoodsNo As String = " left join (  select distinct Produce_ID, Goods_No from T25001_Produce_List    ) List on List.Produce_ID=p.Produce_ID"

    Public Const SQL_Produce_Get_leftJoin_GoodsName As String = "   left join (  select distinct Produce_ID, G.Goods_No,G.Goods_Name from T25001_Produce_List PL left join T10001_Goods G on PL.Goods_No=G.Goods_No ) List on List.Produce_ID=p.Produce_ID"

    Public Const SQL_Produce_GetProduceByid As String = "select top 1 * from T25000_Produce_table  where Produce_ID=@Produce_ID"

    Public Const SQL_Produce_GetProduceListByid As String = "select P.* ,G.Goods_Name,G.Goods_Unit from T25001_Produce_List  P left join T10001_Goods G on G.Goods_No=P.Goods_No where Produce_ID=@Produce_ID"


    ''' <summary>
    ''' table
    ''' </summary>
    ''' <remarks></remarks>
    Public Const SQL_Produce_SelByid As String = "select top 1 * from T25000_Produce_table  where Produce_ID=@Produce_ID"
    ''' <summary>
    ''' list
    ''' </summary>
    ''' <remarks></remarks>
    Public Const SQL_Produce_SelListByid As String = "select  * from T25001_Produce_List  where Produce_ID=@Produce_ID"
    ''' <summary>
    ''' 删除
    ''' </summary>
    ''' <remarks></remarks>
    Public Const SQL_Produce_DelProduceByid As String = "Delete from  T25000_Produce_table where Produce_ID=@Produce_ID "
    Public Const SQL_Produce_OrderBy As String = " order by Produce_Date "







End Module
