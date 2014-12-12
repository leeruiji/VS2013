Module Module_SQL

    '===================成品出库单信息==============
    Public Const SQL_StoreOut_Get_Sel As String = "select  P.* "

    Public Const SQL_StoreOut_Get_Body As String = " from T25100_StoreOut_table P   "

    Public Const SQL_StoreOut_Get_leftJoin_GoodsNo As String = " left join (  select distinct StoreOut_ID, Goods_No from T25101_StoreOut_List    ) List on List.StoreOut_ID=p.StoreOut_ID"

    Public Const SQL_StoreOut_Get_leftJoin_GoodsName As String = "   left join (  select distinct StoreOut_ID, G.Goods_No,G.Goods_Name from T25101_StoreOut_List PL left join T10001_Goods G on PL.Goods_No=G.Goods_No ) List on List.StoreOut_ID=p.StoreOut_ID"

    Public Const SQL_StoreOut_GetStoreOutByid As String = "select top 1 * from T25100_StoreOut_table  where StoreOut_ID=@StoreOut_ID"

    Public Const SQL_StoreOut_GetStoreOutListByid As String = "select P.* ,G.Goods_Name,G.Goods_Unit from T25101_StoreOut_List  P left join T10001_Goods G on G.Goods_No=P.Goods_No where StoreOut_ID=@StoreOut_ID"


    ''' <summary>
    ''' table
    ''' </summary>
    ''' <remarks></remarks>
    Public Const SQL_StoreOut_SelByid As String = "select top 1 * from T25100_StoreOut_table  where StoreOut_ID=@StoreOut_ID"
    ''' <summary>
    ''' list
    ''' </summary>
    ''' <remarks></remarks>
    Public Const SQL_StoreOut_SelListByid As String = "select  * from T25101_StoreOut_List  where StoreOut_ID=@StoreOut_ID"
    ''' <summary>
    ''' 删除
    ''' </summary>
    ''' <remarks></remarks>
    Public Const SQL_StoreOut_DelStoreOutByid As String = "Delete from  T25100_StoreOut_table where StoreOut_ID=@StoreOut_ID "
    Public Const SQL_StoreOut_OrderBy As String = " order by StoreOut_Date "







End Module
