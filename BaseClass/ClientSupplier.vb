Imports PClass.PClass
Public MustInherit Class ClientSupplier
    Public Const SQL_Supplier_New As String = "select top 1 * from T10100_Supplier"
    Private Const SQL_GetAllSupplier As String = "select Supplier_ID,Supplier_Name from T10100_Supplier order by Supplier_ID"
    Private Const SQL_GetSpplierNameById As String = "select top 1 Supplier_Name from T10100_Supplier where Supplier_ID=@Supplier_ID"
    Private Const SQL_GetTopNSupplier As String = "select top %topn% Supplier_Name from T10100_Supplier where Supplier_ID=@Supplier_ID"

    ''' <summary>
    ''' 生成新的供应商ID 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Supplier_GetNewID() As String
        Dim paraMap As New Dictionary(Of String, Object)
        paraMap.Add("@DB_Str", "T10100_Supplier")
        paraMap.Add("@Id_Str", "G")
        paraMap.Add("@Field", "Supplier_ID")
        paraMap.Add("@Zero", "3")
        Dim msgID As MsgReturn = SqlStrToOneStr("GetTableID_NoDate", paraMap, True)
        If msgID.IsOk Then
            Return msgID.Msg
        Else
            Return ""
        End If
    End Function

    Public Shared Function GetAllSupplier() As DataTable
        Dim R As DtReturnMsg = SqlStrToDt(SQL_GetAllSupplier)
        Return R.Dt
    End Function
    Public Shared Function GetTopNSupplier(ByVal TopN As Integer) As DataTable
        Dim R As DtReturnMsg = SqlStrToDt(SQL_GetTopNSupplier.Replace("%topn%", TopN))
        Return R.Dt
    End Function



    'Public Shared Function GetAllClient() As DataTable

    'End Function

    'Public Shared Function GetTopNClient(ByVal TopN As Integer) As DataTable

    'End Function



    Public Shared Function GetSpplierNameById(ByVal spplierID As String) As String

        Dim R As MsgReturn = SqlStrToOneStr(SQL_GetSpplierNameById, "Supplier_ID", spplierID)
        If R.IsOk Then
            Return R.Msg
        Else
            Return ""
        End If
    End Function

End Class
