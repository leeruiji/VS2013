Module Module_SQL

#Region "商品分类"



    '===================商品分类==============
    Public Const SQL_GoodsType_GetAll As String = "select * from T10000_GoodsType order by GoodsType_ID"

    'Public Const SQL_GoodsType_GetChildrenBYParentID As String = "select * from T10000_GoodsType order by GoodsType_ID"
    Public Const SQL_UPDATE_PF_ALL As String = "UPDATE T10010_BZC_PF SET IsOK = 0 WHERE BZC_ID=@BZC_ID"
    Public Const SQL_UPDATE_PF As String = "UPDATE T10010_BZC_PF SET IsOK = @IsOK WHERE BZC_ID=@BZC_ID AND ID=@ID"

    Public Const SQL_GoodsType_GetByID As String = "select * from T10000_GoodsType where GoodsType_ID=@GoodsType_ID"

    Public Const SQL_GoodsType_Del As String = "Delete from T10000_GoodsType where GoodsType_ID=@GoodsType_ID"


    Public Const SQL_GoodsType_CheckDel = "SELECT(SELECT Count(*)" & vbCrLf & _
                                    "FROM T10000_GoodsType" & vbCrLf & _
                                    "WHERE (GoodsType_ID LIKE @GoodsType_ID + '%' and GoodsType_ID<>@GoodsType_ID))" & vbCrLf & _
                                    "+(select Count(*) from T10001_WL where WL_Type_ID=@GoodsType_ID)"
#End Region


#Region " 布类信息"


    Public Const SQL_BZ_NameCheckDuplicate = "select count(*) from T10002_BZ where BZ_No=@BZ_No and BZ_Name=@BZ_Name and Client_ID=@Client_ID and id<>@id"

    Public Const SQL_BZ_Get As String = "select B.ID,BZ_No,BZ_Name,BZ_FindHelper,Client_ID,Client_No,Client_Name,CP_No,CP_Name , CASE BZ_State WHEN - 1 THEN 1 ELSE 0 END AS Disable  from T10002_BZ  B left join T10110_Client C on B.Client_ID=C.ID"

    Public Const SQL_BZ_GetByID As String = "select * from T10002_BZ where ID=@ID"
    Public Const SQL_BZ_GetByNo As String = "select top 0 * from T10002_BZ "

    Public Const SQL_BZ_SelByID As String = "select G.*,T.Client_Name from T10002_BZ G left join T10110_Client T on G.Client_ID=T.ID where G.ID=@ID"
    Public Const SQL_BZ_OrderBy As String = " order by  BZ_No "

    Public Const SQL_BZ_DelByid As String = " Delete from  T10002_BZ where ID=@ID "
#End Region

#Region "布种色号"
    Public Const SQL_Get_BZC As String = "select 'GY-' + right('00000' + cast(BZC_No as varchar(20)),6) as BZC_NoShow,Id,BZC_NO,BZC_Name,Found_Date,RB_PF_Count,Client_Bzc,ID,(select top 1 Client_Name from T10110_Client C where Client_id=c.id) as Client_Name,(select top 1 Bz_Name from T10002_BZ C where BZ_ID=c.id) as Bz_Name,(Select max(Price_Time)as Price_Time from T50001_Price_List where BZC_ID=C.ID)as Price_Time from T10003_BZC C "
    Public Const SQL_BZC_Get As String = "select 'GY-' + right('00000' + cast(BZC_No as varchar(20)),6) as BZC_NoShow,Id,RanSe,BZC_NO,BZC_Name,Found_Date,RB_PF_Count,Client_Bzc,ID,(select top 1 Client_Name from T10110_Client C where Client_id=c.id) as Client_Name,(select top 1 Bz_Name from T10002_BZ C where BZ_ID=c.id) as Bz_Name from T10003_BZC C "

    Public Const SQL_BZC As String = "select top 0 'GY-' + right('00000' + cast(BZC_No as varchar(20)),6) as BZC_NoShow,Id,BZC_NO,BZC_Name,Found_Date,RB_PF_Count,Client_Bzc,ID,(select top 1 Client_Name from T10110_Client C where Client_id=c.id) as Client_Name,(select top 1 Bz_Name from T10002_BZ C where BZ_ID=c.id) as Bz_Name,(Select max(Price_Time)as Price_Time from T50001_Price_List where BZC_ID=C.ID)as Price_Time from T10003_BZC C "

    Public Const SQL_BZC_GetAutoID As String = "declare @i int" & vbCrLf & _
                                                "select @i=count(*) from T10003_BZC where BZC_No=@BZC_No" & vbCrLf & _
                                                "if @i>0" & vbCrLf & _
                                                "set @i=0" & vbCrLf & _
                                                "else" & vbCrLf & _
                                                "begin" & vbCrLf & _
                                                "insert into T10003_BZC (BZC_No,BZC_Name)Values(@BZC_No,@BZC_Name)" & vbCrLf & _
                                                "set @i=@@identity " & vbCrLf & _
                                                "end" & vbCrLf & _
                                                "select @i"

    Public Const SQL_BZC_NameCheckDuplicate = "select count(*) from T10003_BZC where BZC_No=@BZC_No and id<>@id"

    Public Const SQL_BZC_SetByID As String = "select C.*,B.BZ_No,B.Client_Bzc,B.BZ_Name,N.Client_Name,N.Client_No from (select * from T10003_BZC where ID=@BZC_ID)C left join T10002_BZ B on B.ID=C.BZ_ID left join T10110_Client n on n.ID=C.Client_ID"
    Public Const SQL_BZC_GetBZByID As String = "select C.*,BZ_No,BZ_Name from T10003_BZC C Left join T10002_BZ B On C.BZ_ID=B.ID  where C.ID=@BZC_ID"
    Public Const SQL_BZC_GetByNo As String = "select * from T10003_BZC C where BZC_No=@BZC_No"
    Public Const SQL_BZC_GetByID As String = "select * from T10003_BZC C where ID=@BZC_ID"

    Public Const SQL_BZC_Link_Bz_GetByID_Save As String = "select * from T10009_BzcLinkBz where BZC_ID=@BZC_ID"
    Public Const SQL_BZC_Link_Bz_GetByID As String = "select C.*,b.Bz_No,b.Bz_Name from T10009_BzcLinkBz C left join T10002_BZ B on b.ID=c.BZ_ID where BZC_ID=@BZC_ID  "

    Public Const SQL_BZC_PF_GetByID As String = "select C.*,isnull(b.WL_Name,'')WL_Name,isnull(b.WL_No,'')WL_No from (select *,(case when WL_ID='[Employee]' or WL_ID='[date]' then 0 else WL_ID end) as WL_IDS from T10010_BZC_PF where BZC_ID=@BZC_ID ) C left join T10001_WL B on   b.ID=c.WL_IDS   "
    Public Const SQL_BZC_PF_GetByID_Save As String = "select * from T10010_BZC_PF  where BZC_ID=@BZC_ID "


    Public Const SQL_BZC_CheckGH As String = "select Count(*) from T30000_Produce_Gd where BZC_ID=@BZC_ID"
    Public Const SQL_BZC_DelByid As String = "Delete from  T10003_BZC where ID=@BZC_ID and PF_Count=0"
    Public Const SQL_BZC_OrderBy As String = " order by  BZC_No "
#End Region

#Region "物料"
    Public Const SQL_WL_GetGoodsType = "select top 1 WL_Type_ID from T10001_WL where WL_No=@WL_No"

    Public Const SQL_WL_CheckDel As String = " select id, WL_No,WL_Name,WL_Spec from T10001_WL where  ID=@ID   and   (   exists (select top 1 * from T10050_Store_Detail where WL_ID=@ID )  or   exists(select  top 1 * from T10011_BZC_PFList where WL_ID=@ID)  )"


    Public Const SQL_WL_NameCheckDuplicate = "select count(*) from T10001_WL where WL_No=@WL_No and id<>@id"

    Public Const SQL_WL_Get As String = "select G.*,ISNULL(G.WL_DownQty, 0) - ISNULL(G.WL_Qty, 0) AS WL_ShortQty, ISNULL(G.WL_Qty, 0) - ISNULL(G.WL_BeiQty, 0) AS WL_ApproveQty , T.GoodsType_Name,T.IsAssemble,S.Supplier_No,S.Supplier_Name,W.WL_Qty as RWL_Qty from T10001_WL G left join T10000_GoodsType T on G.WL_Type_ID=T.GoodsType_ID  left join T10100_Supplier S On G.WL_Supplier=S.ID left join T10001_WL W on G.RWL_No =W.WL_No "

    Public Const SQL_WL_GetByID As String = "select * from T10001_WL where ID=@ID"
    Public Const SQL_WL_GetByNo As String = "select * from T10001_WL where WL_No=@WL_No"

    Public Const SQL_WL_SelByID As String = "select top 1 G.*,T.GoodsType_Name,T.IsAssemble,T.IsRaw,S.Supplier_No,S.Supplier_Name from T10001_WL G left join T10000_GoodsType T on G.WL_Type_ID=T.GoodsType_ID left join T10100_Supplier S on G.WL_Supplier=S.ID  where G.ID=@ID"
    Public Const SQL_WL_OrderBy As String = " order by G.WL_Type_ID, G.WL_No "

    Public Const SQL_WL_DelByid As String = "Delete from  T10001_WL where ID=@ID "
    Public Const SQL_WL_Enable As String = "update T10001_WL set WL_Disable=0 where ID=@ID "

    '获取装配物料基本信息
    Public Const SQL_WL_AssembleSelByWL_No As String = "select * from T10001_WL_Assemble where WL_No=@WL_No"

    Public Const SQL_WL_RawGetByNo As String = "select top 1 GT.IsRaw from T10001_WL WL left join T10000_GoodsType GT on WL.WL_Type_ID=GT.GoodsType_ID where WL_No=@WL_No"

    Public Const SQL_WL_AssembleByNo As String = "select top 1 GT.IsRaw,GT.IsAssemble,GT.IsHardware from T10001_WL WL left join T10000_GoodsType GT on WL.WL_Type_ID=GT.GoodsType_ID where WL_No=@WL_No"
#End Region



End Module
