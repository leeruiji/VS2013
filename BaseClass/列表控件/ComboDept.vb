Public Class ComboDept
    Public Shadows Const ComboName As String = "部门"
    Public Sub New()
        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        If Me.DesignMode = False Then FG1.Rows.Count = 1
        ' 在 InitializeComponent() 调用之后添加任何初始化。
        Me.Col_Col_ID = "Dept_No"
        Dim Dept_Name As String = "DisplayName"
        Dim Dept_No As String = "Dept_No"
        Try
            FG1.Cols(Me.Col_Col_Name).Name = Dept_Name
            FG1.Cols(Me.Col_Col_No).Name = Dept_No
        Catch ex As Exception
            If PClass.PClass.Ide Then MsgBox(Me.Name & "FG列名初始化出错!")
        End Try

        Col_Col_Name = Dept_Name
        Col_Col_No = Dept_No
        FormID = 99003  '添加修改窗口的权限控制
        Me.SQL_Col_GetSearch = Dao.SQL_Dept_GetSearch
        Me.SQL_Col_GetSearch_GetByID = Dao.SQL_Dept_GetSearch_GetByID
        Me.SQL_Col_GetSearch_Order = Dao.SQL_Dept_GetSearch_Order
        Me.SQL_Col_GetSearch_Where = Dao.SQL_Dept_GetSearch_Where
    End Sub


End Class

Partial Class Dao

#Region "部门"
    Public Const SQL_Dept_GetSearch As String = "select *  from V15000_Dept "
    Public Const SQL_Dept_GetSearch_Where As String = " where (Dept_No like @No or Dept_Name like @Name  ) "
    Public Const SQL_Dept_GetSearch_Order As String = " order by Dept_No"
    Public Const SQL_Dept_GetSearch_GetByID As String = "select top 1 * from V15000_Dept where Dept_No=@ID"
#End Region
End Class
