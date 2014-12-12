Module Module_SQL
    Public Const SQL_99000_UserGroupList_Load As String = "select * from User_Group order by Group_Name"
    Public Const SQL_99000_UserGroup_Add As String = "select top 0 * from  User_Group "
    Public Const SQL_99000_UserGroup_SaveAndDel As String = "select top 1 * from  User_Group where Group_ID=@Group_ID"


    Public Const SQL_99000_Right_Save As String = "select top 1 * from User_Group where @Group_ID=Group_ID"
    Public Const SQL_99000_Right_Save_Table_Name As String = "Group_Right"
    Public Const SQL_99000_Right_GetByID As String = "select  * from Group_Right where Group_ID=@Group_ID order by Group_ID"

    Public Const SQL_99010_GetNewReport As String = "[GetNewReport]"
    '===================职位信息==============
#Region "职位"
    Public Const SQL_Job_NameCheckDuplicate = "select count(*) from T15003_Job where Job_No=@Job_No and id<>@id"

    Public Const SQL_Job_GetAllJob As String = "select J.*,(case when len(Job_Dept)=7 then  (select top 1 Dept_Name from T15000_Department  where left(Job_Dept,4)=Dept_No)  else Dept_Name end) as Dept_Name,  (case when len(Job_Dept)=7 then  Dept_Name else '' end )GroupName  from T15003_Job J left join T15000_Department D on D.Dept_No=J.Job_dept "

    Public SQl_Job_Get = "select J.*,V.Dept_Name,V.DisplayName  from T15003_Job J left join  V15000_Dept V on J.Job_dept=V.Dept_No "
    Public Const SQL_Job_GetByid As String = "select top 1 * from T15003_Job where ID=@ID"
    Public Const SQL_Job_GetByNo As String = "select top 1 * from T15003_Job where Job_No=@Job_No"

    Public Const SQL_Job_DelByid As String = "Delete from  T15003_Job where ID=@ID "
#End Region

#Region "员工"
    Public Const SQL_Employee_GetByID As String = "select TE.*,(case when len(Employee_Dept)=7 then  (select top 1 Dept_Name from T15000_Department D where left(TE.Employee_Dept,4)=D.Dept_No)  else TD.Dept_Name end) as Dept_Name,  (case when len(Employee_Dept)=7 then  TD.Dept_Name else '' end )GroupName   ,Job.Job_Name ,U.User_ID,U.User_ID,U.User_Name ,U.User_Display from (select * from T15001_Employee where Employee_No=@Employee_No ) TE left join T15000_Department TD on TE.Employee_Dept=TD.Dept_No  left join T15003_Job Job on Job.ID=Employee_Job left join User_Info U on TE.Employee_No=U.Employee_No order by TE.Employee_No"
#End Region

#Region "员工卡记录"
    Public Const SQL_Card_GetHistoryByCard = "select H.*,E.Employee_Name,E.Employee_No from T15004_CardHistory H left join T15001_Employee E on  H.ID=E.ID where Card=@Card "

    Public Const SQL_Card_GetHistoryByEID = "select H.*,E.Employee_Name,E.Employee_No from T15004_CardHistory H left join T15001_Employee E on  H.ID=E.ID where H.ID=@ID "
#End Region
End Module
