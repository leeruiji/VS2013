Public Class cSearchType
    Public Enum ENum_SearchType
        ''' <summary>
        ''' 自定义搜索语句
        ''' </summary>
        ''' <remarks></remarks>
        Add_SQL = -1


        ''' <summary>
        ''' 所有
        ''' </summary>
        ''' <remarks></remarks>
        ALL = 0
        ''' <summary>
        ''' 按客户
        ''' </summary>
        ''' <remarks></remarks>
        Client = 1
        ''' <summary>
        ''' 按供应商
        ''' </summary>
        ''' <remarks></remarks>
        Supplier = 2
        ''' <summary>
        ''' 按照FormatSet中对应的部门
        ''' </summary>
        ''' <remarks></remarks>
        FormatSet = 3
        ''' <summary>
        ''' 按照指定的部门
        ''' </summary>
        ''' <remarks></remarks>
        Department = 4
        ''' <summary>
        ''' 按布种
        ''' </summary>
        ''' <remarks></remarks>
        Bz = 5
        ''' <summary>
        ''' 按色号
        ''' </summary>
        ''' <remarks></remarks>
        BZC = 6

        ''' <summary>
        ''' 按布种和客户
        ''' </summary>
        ''' <remarks></remarks>
        ClientBZ = 7



















    End Enum
End Class
