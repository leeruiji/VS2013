Public Class WL_List
  


    Protected Overrides Sub Col_Ini()
        Me.Col_Col_ID = "WL_ID"
        Dim WL_Name As String = "WL_Name"
        Dim WL_No As String = "WL_No"

        Fg1.Cols(Me.Col_Col_Name).Name = WL_Name
        Fg1.Cols(Me.Col_Col_No).Name = WL_No

        Col_Col_Name = WL_Name
        Col_Col_No = WL_No
        Me.SQL_Col_GetSearch = SQL_WL_GetSearch
        Me.SQL_Col_GetSearch_GetByID = SQL_WL_GetSearch_GetByID
        Me.SQL_Col_GetSearch_Order = SQL_WL_GetSearch_Order
        Me.SQL_Col_GetSearch_Where = SQL_WL_GetSearch_Where
        Loaded = True
    End Sub



End Class
