Module Module_SQL
#Region "布种"
    Public Const SQL_BZ_GetSearch As String = "select top 10 BZ_No,ID,BZ_Name,BZ_FindHelper,BZ_Spec,BZ_Type_ID from T10002_BZ  "
    Public Const SQL_BZ_GetSearch_Where As String = " where (BZ_No like @No or BZ_Name like @Name or BZ_FindHelper like @FindHelper)and BZ_State=0 "
    Public Const SQL_BZ_GetSearch_Order As String = " order by BZ_No"
    Public Const SQL_BZ_GetSearch_GetByID As String = "select top 1 * from T10002_BZ where ID=@ID"

    Public Const SQL_BZ_GetSearch_Client As String = "select BZ_No,ID,BZ_Name,BZ_FindHelper,BZ_Spec from T10002_BZ    "
    Public Const SQL_BZ_GetSearch_Client_Where As String = " where Client_ID=@Client_ID "
    Public Const SQL_BZ_GetSearch_Client_Where1 As String = " and (BZ_No like @No or BZ_Name like @Name or BZ_FindHelper like @FindHelper) "
    Public Const SQL_BZ_GetSearch_Client_Order As String = " order by BZ_No"


    Public Const SQL_BZ_GetSearch_BZC As String = "select distinct BZ_ID as ID,BZ_No,BZ_Name,BZ_FindHelper,BZ_Spec,BZ_Type_ID from ( select BZ_ID from T10003_BZC where ID=@BZC_ID union all select BZ_ID from T10009_BzcLinkBz where BZC_ID=@BZC_ID) T left join T10002_BZ BZ on BZ.ID=T.BZ_ID"
    Public Const SQL_BZ_GetSearch_BZC_Where As String = " where (BZ_No like @No or BZ_Name like @Name or BZ_FindHelper like @FindHelper) "
    Public Const SQL_BZ_GetSearch_BZC_Order As String = " order by BZ_No"


    Public Const SQL_BZC_GetSearch_Client As String = "select BZC_No,ID,BZC_Name,BZC_FindHelper from T10003_BZC    "
    Public Const SQL_BZC_GetSearch_Client_Where As String = " where Client_ID=@Client_ID "
    Public Const SQL_BZC_GetSearch_Client_Where1 As String = " and( BZC_No like @No or BZC_Name like @Name or BZC_FindHelper like @FindHelper) "
    Public Const SQL_BZC_GetSearch_Client_Order As String = " order by BZC_No"
#End Region

#Region "色号"
    Public Const SQL_BZC_GetSearch As String = "select top 10 BZC_No,ID,BZC_Name,BZC_FindHelper,Client_Bzc,Client_id from T10003_BZC  "
    Public Const SQL_BZC_GetSearch_Where As String = " where (BZC_No like @No or BZC_Name like @Name or BZC_FindHelper like @FindHelper) "
    Public Const SQL_BZC_GetSearch_Order As String = " order by BZC_No"
    Public Const SQL_BZC_GetSearch_GetByID As String = "select top 1 * from T10003_BZC where ID=@ID"
#End Region

#Region "客户"
    Public Const SQL_Client_GetSearch As String = "select  Client_No,ID,Client_Name,Client_FindHelper,Client_Mobile from T10110_Client  "
    Public Const SQL_Client_GetSearch_Where As String = " where  (Client_No like @No or Client_Name like @Name or Client_FindHelper like @FindHelper) "
    Public Const SQL_Client_GetSearch_Order As String = " order by Client_No"
    Public Const SQL_Client_GetSearch_GetByID As String = "select top 1 * from T10110_Client where ID=@ID"
#End Region

#Region "加工单位"

    Public Const SQL_JGDW_GetSearch As String = "select  JGDW_No,ID,JGDW_Name,JGDW_FindHelper,JGDW_Mobile from T10130_JGDW  "
    Public Const SQL_JGDW_GetSearch_Where As String = " where (JGDW_No like @No or JGDW_Name like @Name or JGDW_FindHelper like @FindHelper) "
    Public Const SQL_JGDW_GetSearch_Order As String = " order by JGDW_No"
    Public Const SQL_JGDW_GetSearch_GetByID As String = "select top 1 * from T10130_JGDW where ID=@ID"
#End Region

#Region "员工"
    Public Const SQL_Employee_GetSearch As String = "select top 10 Employee_No,ID,Employee_Name,Employee_FindHelper,Employee_Dept from T15001_Employee  "
    Public Const SQL_Employee_GetSearch_Where As String = " where (Employee_No like @No or Employee_Name like @Name or Employee_FindHelper like @FindHelper) "
    Public Const SQL_Employee_GetSearch_Order As String = "and (Employee_FileType <> '离职' or (Employee_FileType = '离职' and isnull(Employee_QuitDate,'2099-1-1')>=Getdate())) order by Employee_No"
    Public Const SQL_Employee_GetSearch_GetByID As String = "select top 1 * from T15001_Employee where ID=@ID"




    Public Const SQL_Employee_GetSearch_Client As String = "select Employee_No,ID,Employee_Name,Employee_FindHelper,Employee_Dept from T15001_Employee    "
    Public Const SQL_Employee_GetSearch_Department_Where As String = " where Employee_Dept=@Employee_Dept "
    Public Const SQL_Employee_GetSearch_Department_Where1 As String = " and (Employee_No like @No or Employee_Name like @Name or Employee_FindHelper like @FindHelper) "
    Public Const SQL_Employee_GetSearch_Department_Order As String = "and (Employee_FileType <> '离职' or (Employee_FileType = '离职' and isnull(Employee_QuitDate,'2099-1-1')>=Getdate())) order by Employee_No"

    Public Const SQL_User_GetDept = "select  Employee_Dept,Dept_Name from T15001_Employee E left join T15000_Department D On E.Employee_Dept=D.Dept_No  where Employee_No=(select Employee_No from User_Info where User_ID=@User_ID) "
  
#End Region

#Region "物料"
    Public Const SQL_WL_GetSearch As String = "select top 10 WL_No,ID,WL_Name,WL_FindHelper,WL_Spec,WL_Type_ID,WL_Unit_LL,WL_Unit,WL_Cost,WL_Percent,IsZJ from T10001_WL where WL_Disable=0 "
    Public Const SQL_WL_GetSearch_Where As String = " and (WL_No like @No or WL_Name like @Name or WL_FindHelper like @FindHelper )"
    Public Const SQL_WL_GetSearch_Order As String = " order by WL_No"
    Public Const SQL_WL_GetSearch_GetByID As String = "select top 1 * from T10001_WL where ID=@ID"
#End Region
#Region "物料名称"
    Public Const SQL_WL_Name_GetSearch As String = "select top 10 * from T10007_WL_Name "
    Public Const SQL_WL_Name_GetSearch_Where As String = " and (WL_Name_No like @No or WL_Name like @Name or WL_FindHelper like @FindHelper )"
    Public Const SQL_WL_Name_GetSearch_Order As String = " order by WL_Name_No"
    Public Const SQL_WL_Name_GetSearch_GetByID As String = "select top 1 * from T10007_WL_Name where ID=@ID"
#End Region
#Region "手感"
    Public Const SQL_SG_GetSearch As String = "select  SGGY_No,ID,SGGY_Name from T10035_SGGY  "
    Public Const SQL_SG_GetSearch_Where As String = " where (SGGY_No like @No or SGGY_Name like @Name ) "
    Public Const SQL_SG_GetSearch_Order As String = " order by SGGY_No"
    Public Const SQL_SG_GetSearch_GetByID As String = "select top 1 * from T10035_SGGY where ID=@ID"

    Public Const SQL_SG_GetSearch_Client As String = "select SGGY_No,ID,SGGY_Name from T10035_SGGY    "
    Public Const SQL_SG_GetSearch_Client_Where As String = " where Client_ID=@Client_ID "
    Public Const SQL_SG_GetSearch_Client_Where2 As String = " where Client_ID=@Client_ID and BZ_ID=@BZ_ID "
    Public Const SQL_SG_GetSearch_Client_Where1 As String = " and( SGGY_No like @No or SGGY_Name like @Name ) "
    Public Const SQL_SG_GetSearch_Client_Order As String = " order by SGGY_No"

#End Region

#Region "供应商"
    Public Const SQL_Supplier_GetSearch As String = "select  Supplier_No,ID,Supplier_Name,Supplier_FindHelper,Supplier_Mobile from T10100_Supplier  "
    Public Const SQL_Supplier_GetSearch_Where As String = " where (Supplier_No like @No or Supplier_Name like @Name or Supplier_FindHelper like @FindHelper) "
    Public Const SQL_Supplier_GetSearch_Order As String = " order by Supplier_No"
    Public Const SQL_Supplier_GetSearch_GetByID As String = "select top 1 * from T10100_Supplier where ID=@ID"
    Public Const SQL_Supplier_GetSearch_Metal As String = "select  Supplier_No,ID,Supplier_Name,Supplier_FindHelper,Supplier_Mobile from T21004_Supplier  "
    Public Const SQL_Supplier_GetSearch_PolyBag As String = "select  Supplier_No,ID,Supplier_Name,Supplier_FindHelper,Supplier_Mobile from T24004_Supplier  "

    Public Const SQL_Supplier_GetSearch_Kitchen As String = "select  Supplier_No,ID,Supplier_Name,Supplier_FindHelper,Supplier_Mobile from T22004_Supplier  "
    Public Const SQL_Supplier_GetSearch_Cocal As String = "select  Supplier_No,ID,Supplier_Name,Supplier_FindHelper,Supplier_Mobile from T26004_Supplier  "

    Public Const SQL_Supplier_GetSearch_GetByID_Metal As String = "select top 1 * from T21004_Supplier where ID=@ID"
    Public Const SQL_Supplier_GetSearch_GetByID_Kitchen As String = "select top 1 * from T22004_Supplier where ID=@ID"
    Public Const SQL_Supplier_GetSearch_GetByID_PolyBag As String = "select top 1 * from T24004_Supplier where ID=@ID"
    Public Const SQL_Supplier_GetSearch_GetByID_Cocal As String = "select top 1 * from T26004_Supplier where ID=@ID"
#End Region

#Region "织厂"
    Public Const SQL_ZhiChang_GetSearch As String = "select  ZhiChang_No,ID,ZhiChang_Name,ZhiChang_FindHelper,ZhiChang_Mobile from T10120_ZhiChang  "
    Public Const SQL_ZhiChang_GetSearch_Where As String = " where (ZhiChang_No like @No or ZhiChang_Name like @Name or ZhiChang_FindHelper like @FindHelper) "
    Public Const SQL_ZhiChang_GetSearch_Order As String = " order by ZhiChang_No"
    Public Const SQL_ZhiChang_GetSearch_GetByID As String = "select top 1 * from T10120_ZhiChang where ID=@ID"
#End Region


#Region "物料属性"
    Public Const SQL_Attribute_GetSearch As String = "select  * from T10013_WL_Type_Attribute  order by ID"
    Public Const SQL_Attribute_GetSearch_GetByID As String = "select top 1 * from T10013_WL_Type_Attribute where ID=@ID"
#End Region
End Module
