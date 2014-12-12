Public Class ComboZhiChang
    Public Shadows Const ComboName As String = "织厂"
    Public Sub New()
        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        If Me.DesignMode = False Then FG1.Rows.Count = 1
        ' 在 InitializeComponent() 调用之后添加任何初始化。
        Me.Col_Col_ID = "ID"
        Dim ZhiChang_Name As String = "ZhiChang_Name"
        Dim ZhiChang_No As String = "ZhiChang_No"
        Try
            FG1.Cols(Me.Col_Col_Name).Name = ZhiChang_Name
            FG1.Cols(Me.Col_Col_No).Name = ZhiChang_No
        Catch ex As Exception
            If PClass.PClass.Ide Then MsgBox(Me.Name & "FG列名初始化出错!")
        End Try

        Col_Col_Name = ZhiChang_Name
        Col_Col_No = ZhiChang_No
        FormID = 10120  '添加修改窗口的权限控制
        Me.SQL_Col_GetSearch = SQL_ZhiChang_GetSearch
        Me.SQL_Col_GetSearch_GetByID = SQL_ZhiChang_GetSearch_GetByID
        Me.SQL_Col_GetSearch_Order = SQL_ZhiChang_GetSearch_Order
        Me.SQL_Col_GetSearch_Where = SQL_ZhiChang_GetSearch_Where
    End Sub

    'Protected Overrides Sub On_Add_ButtonClick()
    'Protected Overrides Sub On_Modify_ButtonClick()
    'Protected Overrides Sub On_Del_ButtonClick()
End Class
