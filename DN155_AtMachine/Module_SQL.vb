Module Module_SQL

    '===================机具信息==============
    Public Const SQL_At_GetAllAt As String = "select * from T15500_AT_Machine order by At_ID"

    Public Const SQL_At_GetAtByid As String = "select top 1 S.*,U.User_Name,U1.User_Name as FounderName from T15500_AT_Machine S left join User_Info U on S.UPD_USER=U.User_ID  left join User_Info U1 on S.Founder=U.User_ID  where At_ID=@At_ID"

    Public Const SQL_At_SelAtByid As String = "select top 1 * from T15500_AT_Machine  where At_ID=@At_ID"


    Public Const SQL_At_DelAtByid As String = "Delete from  T15500_AT_Machine where At_ID=@At_ID "


 
End Module
