Public Class ComboEmployee
    Public Shadows Const ComboName As String = "员工"
    Public Sub New()
        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        If Me.DesignMode = False Then FG1.Rows.Count = 1
        ' 在 InitializeComponent() 调用之后添加任何初始化。
        Me.Col_Col_ID = "ID"
        Dim Employee_Name As String = "Employee_Name"
        Dim Employee_No As String = "Employee_No"
        Try
            FG1.Cols(Me.Col_Col_Name).Name = Employee_Name
            FG1.Cols(Me.Col_Col_No).Name = Employee_No
        Catch ex As Exception
            If PClass.PClass.Ide Then MsgBox(Me.Name & "FG列名初始化出错!")
        End Try

        Col_Col_Name = Employee_Name
        Col_Col_No = Employee_No
        FormID = 15000  '添加修改窗口的权限控制
        Me.SQL_Col_GetSearch = SQL_Employee_GetSearch
        Me.SQL_Col_GetSearch_GetByID = SQL_Employee_GetSearch_GetByID
        Me.SQL_Col_GetSearch_Order = SQL_Employee_GetSearch_Order
        Me.SQL_Col_GetSearch_Where = SQL_Employee_GetSearch_Where
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
                GS = SQL_Employee_GetSearch
                GSL = GS
                If NotTop Then
                    NotTop = False
                    GS = GS.Replace("top 10", "")
                Else
                    GS = GS.Replace("top 10", "top " & ShowRowCount)
                End If
                WhereStr = SQL_Employee_GetSearch_Where
            Case cSearchType.ENum_SearchType.Department
                GS = SQL_Employee_GetSearch_Client & SQL_Employee_GetSearch_Department_Where
                GSL = GS
                If NotTop Then
                    NotTop = False
                    GS = GS.Replace("top 10", "")
                Else
                    GS = GS.Replace("top 10", "top " & ShowRowCount)
                End If
                WhereStr = SQL_Employee_GetSearch_Department_Where1
                Parameters.Add("@Employee_Dept", SearchID)
            Case cSearchType.ENum_SearchType.FormatSet
                GS = SQL_Employee_GetSearch_Client & SQL_Employee_GetSearch_Department_Where
                GSL = GS
                If NotTop Then
                    NotTop = False
                    GS = GS.Replace("top 10", "")
                Else
                    GS = GS.Replace("top 10", "top " & ShowRowCount)
                End If
                WhereStr = SQL_Employee_GetSearch_Department_Where1
                Dim ss As String = PClass.PClass.FormatSharp(SearchID)
                If ss = "0.00" Then
                    ss = ""
                End If
                Parameters.Add("@Employee_Dept", ss)
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
            If GS.Contains(" where ") = False Then
                GS = GS & " where 1=1 "
            End If

        Else
            GS = GS & WhereStr
        End If

        SQLtoSearch(GS, Parameters, True)
    End Sub

End Class
