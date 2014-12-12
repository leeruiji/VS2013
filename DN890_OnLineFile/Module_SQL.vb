Module Module_SQL
    Public Const SQL_89000_Department_GetDeptAll As String = "select * from T15000_Department order by Dept_No"
    Public Const SQL_89000_User_GetAll As String = "select * from User_Info where isnull(Invalid,0)=0 order by User_ID"
    Public Const SQL_89000_Del_File As String = "select Top 1 Name,Ver from T890_OnlineFile where ID=@ID"
    Public Const SQL_89000_DelAll_File As String = "select Name,Ver from T890_OnlineFile where Name=@Name"
    Public Const SQL_89000_GetFileRight As String = "select * from T891_FileRight where FileName=@ID order by FileName,User_ID"

    Public Const SQL_89001_FormLoad As String = "select top 1 * from  T891_FileRight where FileName=@FileName and User_ID=@User_ID"

    Public Const SQL_89001_SaveFile As String = "select isnull((select top 1 ver from T890_OnlineFile where Name=@Name order by ver desc),0.99)+0.01"
    Public Const SQL_89001_CheckFile As String = "select COunt(Name) from T890_OnlineFile where ID =@ID"



End Module
