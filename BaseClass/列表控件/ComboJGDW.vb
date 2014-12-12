Public Class ComboJGDW
    Public Shadows Const ComboName As String = "加工单位"
    Public Sub New()
        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        If Me.DesignMode = False Then FG1.Rows.Count = 1
        ' 在 InitializeComponent() 调用之后添加任何初始化。
        Me.Col_Col_ID = "ID"
        Dim JGDW_Name As String = "JGDW_Name"
        Dim JGDW_No As String = "JGDW_No"
        Try
            FG1.Cols(Me.Col_Col_Name).Name = JGDW_Name
            FG1.Cols(Me.Col_Col_No).Name = JGDW_No
        Catch ex As Exception
            If PClass.PClass.Ide Then MsgBox(Me.Name & "FG列名初始化出错!")
        End Try

        Col_Col_Name = JGDW_Name
        Col_Col_No = JGDW_No
        FormID = 10130  '添加修改窗口的权限控制
        Me.SQL_Col_GetSearch = SQL_JGDW_GetSearch
        Me.SQL_Col_GetSearch_GetByID = SQL_JGDW_GetSearch_GetByID
        Me.SQL_Col_GetSearch_Order = SQL_JGDW_GetSearch_Order
        Me.SQL_Col_GetSearch_Where = SQL_JGDW_GetSearch_Where
    End Sub

    'Protected Overrides Sub On_Add_ButtonClick()
    'Protected Overrides Sub On_Modify_ButtonClick()
    'Protected Overrides Sub On_Del_ButtonClick()
End Class
