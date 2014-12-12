Public Class ComboSG
    Public Shadows Const ComboName As String = "手感"
    Public Sub New()
        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        If Me.DesignMode = False Then FG1.Rows.Count = 1
        ' 在 InitializeComponent() 调用之后添加任何初始化。
        Me.Col_Col_ID = "ID"
        Dim SGGY_Name As String = "SGGY_Name"
        Dim SGGY_No As String = "SGGY_No"

        Try
            FG1.Cols(Me.Col_Col_Name).Name = SGGY_Name
            FG1.Cols(Me.Col_Col_No).Name = SGGY_No
        Catch ex As Exception
            If PClass.PClass.Ide Then MsgBox(Me.Name & "FG列名初始化出错!")
        End Try
        Col_Col_Name = SGGY_Name
        Col_Col_No = SGGY_No
        FormID = 10100  '添加修改窗口的权限控制
        Me.SQL_Col_GetSearch = SQL_SG_GetSearch
        Me.SQL_Col_GetSearch_GetByID = SQL_SG_GetSearch_GetByID
        Me.SQL_Col_GetSearch_Order = SQL_SG_GetSearch_Order
        Me.SQL_Col_GetSearch_Where = SQL_SG_GetSearch_Where
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
                GS = SQL_SG_GetSearch
                GSL = GS
                If NotTop Then
                    NotTop = False
                    GS = GS.Replace("top 10", "")
                Else
                    GS = GS.Replace("top 10", "top " & ShowRowCount)
                End If
                WhereStr = SQL_SG_GetSearch_Where
            Case cSearchType.ENum_SearchType.Add_SQL
                GS = SQL_SG_GetSearch
                GSL = GS
                If NotTop Then
                    NotTop = False
                    GS = GS.Replace("top 10", "")
                Else
                    GS = GS.Replace("top 10", "top " & ShowRowCount)
                End If
                Select Case Me.SearchID
                    Case "1"
                        WhereStr = SQL_SG_GetSearch_Where & "  and (select top 1  Iscomfirm  from T50001_Price_List where  BZC_ID=T10003_BZC.ID  order by Price_Time desc)=1"
                    Case Else
                        WhereStr = SQL_SG_GetSearch_Where & " " & Me.SearchID

                End Select

            Case cSearchType.ENum_SearchType.Client
                GS = SQL_SG_GetSearch_Client & SQL_SG_GetSearch_Client_Where
                GSL = GS
                If NotTop Then
                    NotTop = False
                    GS = GS.Replace("top 10", "")
                Else
                    GS = GS.Replace("top 10", "top " & ShowRowCount)
                End If
                WhereStr = SQL_SG_GetSearch_Client_Where1
                Parameters.Add("@Client_ID", SearchID)


            Case cSearchType.ENum_SearchType.ClientBZ
                GS = SQL_SG_GetSearch_Client & SQL_SG_GetSearch_Client_Where2
                GSL = GS
                If NotTop Then
                    NotTop = False
                    GS = GS.Replace("top 10", "")
                Else
                    GS = GS.Replace("top 10", "top " & ShowRowCount)
                End If
                WhereStr = SQL_SG_GetSearch_Client_Where1
                Parameters.Add("@Client_ID", SearchID)
                Parameters.Add("@BZ_ID", SearchBZID)

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
