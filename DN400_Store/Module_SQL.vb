
Module Module_SQL
#Region "送货单信息"


    '===================送货单信息==============
    Public Const SQL_BZSH_GetBZSHWhithClientName As String = SQL_BZSH_Get_Sel & SQL_BZSH_Get_Body


    Public Const SQL_BZSH_Get_Sel As String = "select  P.*,S.Client_No,S.Client_Name "

    Public Const SQL_BZSH_Get_Body As String = " from T40000_BZSH_Table P left join T10110_Client S on  P.Client_ID=S.ID  "

    Public Const SQL_BZSH_Get_leftJoin_BZID As String = " left join (  select distinct BZSH_ID, Bz_Id from T40001_BZSH_List    ) List on List.BZSH_ID=p.BZSH_ID"

    Public Const SQL_BZSH_Get_leftJoin_GoodsName As String = "   left join (  select distinct BZSH_ID, G.Bz_No,G.Bz_Name from T40001_BZSH_List PL left join T10002_BZ G on PL.Bz_ID=G.ID ) List on List.BZSH_ID=p.BZSH_ID"

    Public Const SQL_BZSH_GetBZSHByid As String = "select top 1 * from T40000_BZSH_Table  where BZSH_ID=@BZSH_ID"

    Public Const SQL_BZSH_GetBZSHByidWhithClientName As String = SQL_BZSH_Get_Sel & SQL_BZSH_Get_Body & "  where BZSH_ID=@BZSH_ID"

    Public Const SQL_BZSH_GetBZSHListByid As String = "select P.* , Gd.Client_ID,isnull(BZ.CP_No,BZ.BZ_No)as BZ_No,isnull(BZ.CP_Name,BZ.BZ_Name)as BZ_Name,BZC.BZC_No,BZC.BZC_Name from T40001_BZSH_List  P left join T10002_BZ BZ on BZ.ID=P.BZ_ID  left join T10003_BZC BZC on BZC.ID=P.BZC_ID Left join  T30000_Produce_Gd Gd On Gd.GH= P.GH where BZSH_ID=@BZSH_ID order by BZSH_ID ,line"

    Public Const SQL_BZSH_GetBZSHListByid_ForReport As String = "select P.* ,isnull(BZ.CP_No,BZ.BZ_No)as BZ_No,isnull(BZ.CP_Name,BZ.BZ_Name)as BZ_Name,isNull((Select top 1 Client_BZC from V10003_Client_BZC C where P.BZC_ID=C.BZC_ID and C.BZ_ID=P.BZ_ID),'') as Client_Bzc,BZC.BZC_Name,P.BZC_ID,BZC.BZC_No  from T40001_BZSH_List  P left join T10002_BZ BZ on BZ.ID=P.BZ_ID  left join T10003_BZC BZC on BZC.ID=P.BZC_ID    where BZSH_ID=@BZSH_ID order by BZSH_ID,line"


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




    Public Const SQL_Produce_GetByID_WithName As String = "select P.*,C.Client_Name,isnull(BZ.CP_No,BZ.BZ_No)as BZ_No,isnull(BZ.CP_Name,BZ.BZ_Name)as BZ_Name,BZC_No,BZC_Name,BZ_Spec   from T30000_Produce_Gd P left join T10110_Client C on P.Client_ID=C.ID left join T10002_BZ BZ on P.BZ_ID=BZ.ID left join T10003_BZC BZC on P.BZC_ID=BZC.ID where GH=@GH "

#End Region




End Module
