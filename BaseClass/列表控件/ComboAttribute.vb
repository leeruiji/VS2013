Public Class ComboAttribute
    Public Shadows Const ComboName As String = "物料属性"
    Public Sub New()
        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        If Me.DesignMode = False Then FG1.Rows.Count = 1
        ' 在 InitializeComponent() 调用之后添加任何初始化。
        Me.Col_Col_ID = "ID"
        Dim Attribute_Name As String = "Attribute_Name"
        Dim Attribute_No As String = "ID"

        Try
            FG1.Cols(Me.Col_Col_Name).Name = Attribute_Name
            FG1.Cols(Me.Col_Col_No).Name = Attribute_No
        Catch ex As Exception
            If PClass.PClass.Ide Then MsgBox(Me.Name & "FG列名初始化出错!")
        End Try
        Col_Col_Name = Attribute_Name
        Col_Col_No = Attribute_No
        FormID = 10013  '添加修改窗口的权限控制
        Me.SQL_Col_GetSearch = SQL_Attribute_GetSearch
        Me.SQL_Col_GetSearch_GetByID = SQL_Attribute_GetSearch_GetByID
    End Sub


End Class
