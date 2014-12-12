Module Module_SQL
#Region "送货单信息"


    '===================送货单信息==============
    Public Const SQL_BZSH_Get_Sel As String = "select  P.*,S.Client_No,S.Client_Name "

    Public Const SQL_BZSH_Get_Body As String = " from T40000_BZSH_Table P left join T10110_Client S on  P.Client_ID=S.ID  "

    Public Const SQL_BZSH_Get_leftJoin_GoodsNo As String = " left join (  select distinct BZSH_ID, Bz_No from T40001_BZSH_List    ) List on List.BZSH_ID=p.BZSH_ID"

    Public Const SQL_BZSH_Get_leftJoin_GoodsName As String = "   left join (  select distinct BZSH_ID, G.Bz_No,G.Bz_Name from T40001_BZSH_List PL left join T10002_BZ G on PL.Bz_ID=G.ID ) List on List.BZSH_ID=p.BZSH_ID"

    Public Const SQL_BZSH_GetBZSHByid As String = "select top 1 * from T40000_BZSH_Table  where BZSH_ID=@BZSH_ID"

    Public Const SQL_BZSH_GetBZSHByidWhithClientName As String = SQL_BZSH_Get_Sel & SQL_BZSH_Get_Body & "  where BZSH_ID=@BZSH_ID"

    Public Const SQL_BZSH_GetBZSHListByid As String = "select P.* ,BZ.BZ_Name,BZC.BZC_Name from T40001_BZSH_List  P left join T10002_BZ BZ on BZ.BZ_ID=P.BZ_ID  left join T10003_BZC BZC on BZC.BZC_ID=P.BZC_ID  where BZSH_ID=@BZSH_ID"

    Public Const SQL_BZSH_GetBZSHListByid_ForReport As String = "select P.* ,P.BZ_ID + '#' +BZ.BZ_Name as BZ_Name ,isNull( Client_Bzc,'') +'#'+BZC.BZC_Name+' GY-' + right('00000' + P.BZC_ID,6) as BZC_Name  from T40001_BZSH_List  P left join T10002_BZ BZ on BZ.BZ_ID=P.BZ_ID  left join T10003_BZC BZC on BZC.BZC_ID=P.BZC_ID  where BZSH_ID=@BZSH_ID order by BZSH_ID"


    ''' <summary>
    ''' table
    ''' </summary>
    ''' <remarks></remarks>
    Public Const SQL_BZSH_SelByid As String = "select top 1 * from T40000_BZSH_Table  where BZSH_ID=@BZSH_ID"
    ''' <summary>
    ''' list
    ''' </summary>
    ''' <remarks></remarks>
    Public Const SQL_BZSH_SelListByid As String = "select  * from T40001_BZSH_List  where BZSH_ID=@BZSH_ID"
    ''' <summary>
    ''' 删除
    ''' </summary>
    ''' <remarks></remarks>
    Public Const SQL_BZSH_DelBZSHByid As String = "Delete from  T40000_BZSH_Table where BZSH_ID=@BZSH_ID "
    Public Const SQL_BZSH_OrderBy As String = " order by BZSH_Date "



    Public Const SQL_Produce_GetByID_WithName As String = "select P.*,C.Client_Name,BZ_Name,BZC_Name,BZ_Spec   from T30000_Produce P left join T10110_Client C on P.Client_ID=C.Client_ID left join T10002_BZ BZ on P.BZ_ID=BZ.BZ_ID left join T10003_BZC BZC on P.BZC_ID=BZC.BZC_ID where Produce_ID=@Produce_ID "

#End Region


#Region "胚布入库单信息"


    '===================胚布入库单信息==============
    Public Const SQL_PBRK_Get_WithName = "select  P.*,Client_No,S.Client_Name,BZ_No,BZ_Name from T40100_PBRK_Table P left join T10110_Client S on  P.Client_ID=S.ID left join T10002_BZ BZ on BZ.ID =P.BZ_ID "
    Public Const SQL_PBRK_Get_Sel As String = "select  P.*,S.Client_Name "

    Public Const SQL_PBRK_Get_Body As String = " from T40100_PBRK_Table P left join T10110_Client S on  P.Client_ID=S.ID  "

    Public Const SQL_PBRK_Get_leftJoin_GoodsNo As String = " left join (  select distinct PBRK_ID, Bz_ID from T40101_PBRK_List    ) List on List.PBRK_ID=p.PBRK_ID"
    Public Const SQL_PBRK_Get_leftJoin_GoodsName As String = "   left join (  select distinct PBRK_ID, G.Bz_No,G.Bz_Name from T40101_PBRK_List PL left join T10002_BZ G on PL.BZ_ID=G.id ) List on List.PBRK_ID=p.PBRK_ID"

    Public Const SQL_PBRK_GetPBRKByid As String = "select top 1 * from T40100_PBRK_Table  where PBRK_ID=@PBRK_ID"

    Public Const SQL_PBRK_GetPBRKByidWhithClientName As String = SQL_PBRK_Get_WithName & "  where PBRK_ID=@PBRK_ID"

    Public Const SQL_PBRK_GetPBRKListByid As String = "select * from T40101_PBRK_List  where PBRK_ID=@PBRK_ID"

    Public Const SQL_PBRK_GetPBRKListByid_ForReport As String = "select P.* ,P.BZ_ID + '#' +BZ.BZ_Name as BZ_Name ,isNull( Client_Bzc,'') +'#'+BZC.BZC_Name+' GY-' + right('00000' + P.BZC_ID,6) as BZC_Name  from T40101_PBRK_List  P left join T10002_BZ BZ on BZ.BZ_ID=P.BZ_ID  left join T10003_BZC BZC on BZC.BZC_ID=P.BZC_ID  where PBRK_ID=@PBRK_ID order by PBRK_ID"

    Public Const SQL_PBRK_CheckID As String = "select count(*) from T40100_PBRK_Table  where PBRK_ID=@PBRK_ID"


    ''' <summary>
    ''' table
    ''' </summary>
    ''' <remarks></remarks>
    Public Const SQL_PBRK_SelByid As String = "select top 1 * from T40100_PBRK_Table  where PBRK_ID=@PBRK_ID"
    ''' <summary>
    ''' list
    ''' </summary>
    ''' <remarks></remarks>
    Public Const SQL_PBRK_SelListByid As String = "select  * from T40101_PBRK_List  where PBRK_ID=@PBRK_ID"
    ''' <summary>
    ''' 删除
    ''' </summary>
    ''' <remarks></remarks>
    Public Const SQL_PBRK_DelPBRKByid As String = "Delete from  T40100_PBRK_Table where PBRK_ID=@PBRK_ID "
    Public Const SQL_PBRK_OrderBy As String = " order by PBRK_Date "

    Public Const SQL_PBRK_SetListById As String = "select p.*,G.Date_PeiBu,G.State as GH_State from (select ZL,GH,CK_Date,State,PBRK_Line from T40101_PBRK_List where PBRK_ID=@PBRK_ID) P left join T30010_Produce_Gd G on Produce_ID=GH"
#End Region



#Region "生产配布"
    Public Const SQL_ProduceGd_Get_WithName As String = "select P.*,Client_No, C.Client_Name,BZ_No,BZ_Name ,BZC_No,BZC_Name,BZ_Spec,E.Employee_name as GenDanName from T30010_Produce_Gd P left join T10110_Client C on P.Client_ID=C.ID left join T10002_BZ BZ on P.BZ_ID=BZ.ID left join T10003_BZC BZC on P.BZC_ID=BZC.ID left join T15001_Employee E on  P.GengDan=E.ID"

    Public Const SQL_SCPB_Get_WithName = "select distinct( L.GH), P.*,Client_No,S.Client_Name,BZ_No,BZ_Name from T40100_PBRK_Table P left join T10110_Client S on  P.Client_ID=S.ID left join T10002_BZ BZ on BZ.ID =P.BZ_ID left Join T40101_PBRK_List L on P.PBRK_ID=L.PBRK_ID"
    Public Const SQL_SCPB_GetPBRK_Table_ByID = "select top 1 PBRK_ID,PBRK_Date,Client_ID,BZ_ID,Notice,Remark,ShaPi,State from T40100_PBRK_Table where PBRK_ID=@PBRK_ID"
    Public Const SQL_SCPB_GetPBRK_List_ByID = "select * from T40101_PBRK_List where PBRK_ID=@PBRK_ID"
    Public Const SQL_SCPB_GetGH_ByID = "select G.*,C.Client_No,C.Client_Name,BZ.Bz_No,Bz.Bz_Name,BZC.BZC_No,BZC.BZC_Name from(select top 1 * from T30010_Produce_Gd where Produce_ID=@GH)G left join T10110_Client C On C.id=G.Client_id  left join T10002_BZ BZ On BZ.id=G.BZ_id   left join T10003_BZC BZC On BZC.id=G.BZC_id "
    Public Const SQL_PBRK_GetListByGH = "select PBRK_ID,PBRK_Line,ZL,PB from T40101_PBRK_List where GH=@GH"
#End Region
End Module
