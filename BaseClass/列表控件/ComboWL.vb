Public Class ComboWL
    Public Shadows Const ComboName As String = "物料"
    Public Sub New()
        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        If Me.DesignMode = False Then FG1.Rows.Count = 1
        ' 在 InitializeComponent() 调用之后添加任何初始化。
        Me.Col_Col_ID = "ID"
        Dim WL_Name As String = "WL_Name"
        Dim WL_No As String = "WL_No"

        Try
            FG1.Cols(Me.Col_Col_Name).Name = WL_Name
            FG1.Cols(Me.Col_Col_No).Name = WL_No
        Catch ex As Exception
            If PClass.PClass.Ide Then MsgBox(Me.Name & "FG列名初始化出错!")
        End Try
        Col_Col_Name = WL_Name
        Col_Col_No = WL_No
        FormID = 10000  '添加修改窗口的权限控制
        Me.SQL_Col_GetSearch = SQL_WL_GetSearch
        Me.SQL_Col_GetSearch_GetByID = SQL_WL_GetSearch_GetByID
        Me.SQL_Col_GetSearch_Order = SQL_WL_GetSearch_Order
        Me.SQL_Col_GetSearch_Where = SQL_WL_GetSearch_Where
    End Sub


    'Protected Overrides Sub On_Add_ButtonClick()
    'Protected Overrides Sub On_Modify_ButtonClick()
    'Protected Overrides Sub On_Del_ButtonClick()


    Overrides Sub GetSearch()
        Dim S As String = StrConv(Search, vbNarrow)
        Dim GS As String = SQL_Col_GetSearch
        Dim GSL As String = SQL_Col_GetSearch
        Dim Parameters As New Dictionary(Of String, Object)
        Dim OrderStr As String = ""
        Dim WhereStr As String = ""
        Select Case SearchType
            Case cSearchType.ENum_SearchType.ALL '全部模式
                GS = SQL_WL_GetSearch
                GSL = GS
                If NotTop Then
                    NotTop = False
                    GS = GS.Replace("top 10", "")
                Else
                    GS = GS.Replace("top 10", "top " & ShowRowCount)
                End If
                WhereStr = SQL_Col_GetSearch_Where

            Case cSearchType.ENum_SearchType.Add_SQL
                GS = SQL_WL_GetSearch & Me.SearchID & " "
                GSL = GS
                If NotTop Then
                    NotTop = False
                    GS = GS.Replace("top 10", "")
                Else
                    GS = GS.Replace("top 10", "top " & ShowRowCount)
                End If
                WhereStr = SQL_Col_GetSearch_Where
  
        End Select
        If Not GSL.Contains("top 10") AndAlso IsSelectAll Then
            Search = ""
        Else
            Search = S
        End If
        Parameters.Add("@No", "%" & Search & "%")
        Parameters.Add("@Name", "%" & Search & "%")
        Parameters.Add("@FindHelper", "%" & Search & "%")
        If Search = "" Then
            GS = GS
        Else
            GS = GS & WhereStr
        End If

        SQLtoSearch(GS, Parameters, True)
    End Sub
End Class
