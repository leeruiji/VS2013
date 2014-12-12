Public Interface ICol_Parent

#Region "属性"
    Property IsShowAdd() As Boolean
    Property IsShowModify() As Boolean
    Property IsTBLostFocusSelOne() As Boolean
    Property IsShowAll() As Boolean
    Property SearchID() As String
    Property SearchBZID() As String
    Property SearchType() As cSearchType.ENum_SearchType
    Property IsSelectName() As Boolean
    ReadOnly Property IsDropDown() As Boolean
    ReadOnly Property ShowValue() As String
    ReadOnly Property ShowID() As String
#End Region
#Region "函数"
    Sub Close()
    Sub Col_SelOne()
    Sub StartSearch()
    Sub ShowDropDown()
    Sub SetSearchEmpty()
    Function GetByTextBoxTag(Optional ByVal ID As String = "") As String
    Function GetIDToDataRow(Optional ByVal ID As String = "") As DataRow

    Sub RE_Col_Sel(ByVal Col_No As String, ByVal Col_Name As String, ByVal ID As String)
    Sub RE_GetSearchEvent(ByRef Col_No As String, ByRef ID As String, ByVal Cancel As Boolean)
    Sub RE_Col_SelRow(ByVal Row As DataRow)

#End Region
#Region "事件"
    Event Col_Sel(ByVal Col_No As String, ByVal Col_Name As String, ByVal ID As String)
    Event Col_SelRow(ByVal Dr As DataRow)
    Event GetSearchEvent(ByRef Col_No As String, ByRef ID As String, ByVal Cancel As Boolean)
#End Region
End Interface
