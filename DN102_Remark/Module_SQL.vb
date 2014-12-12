Module Module_SQL

#Region "备注"

    Public Const SQL_Remark_Get As String = "select * from T10200_Remark  "

    Public Const SQL_Remark_GetByID As String = "select * from T10200_Remark where Remark_ID=@Remark_ID"
   
    Public Const SQL_Remark_DelByid As String = "Delete from  T10200_Remark where Remark_ID=@Remark_ID "

    Public Const SQL_Remark_OrderBy As String = " order by  Remark_ID "

#End Region
End Module
