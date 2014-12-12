Public Class ComboSupplier_Cocal
    Public Shadows Const ComboName As String = "供应商(杂料)"
    Public Sub New()
        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        If Me.DesignMode = False Then FG1.Rows.Count = 1
        ' 在 InitializeComponent() 调用之后添加任何初始化。
        Me.Col_Col_ID = "ID"
        Dim Supplier_Name As String = "Supplier_Name"
        Dim Supplier_No As String = "Supplier_No"

        Try
            FG1.Cols(Me.Col_Col_Name).Name = Supplier_Name
            FG1.Cols(Me.Col_Col_No).Name = Supplier_No
        Catch ex As Exception
            If PClass.PClass.Ide Then MsgBox(Me.Name & "FG列名初始化出错!")
        End Try
        Col_Col_Name = Supplier_Name
        Col_Col_No = Supplier_No
        FormID = 26020  '添加修改窗口的权限控制
        Me.SQL_Col_GetSearch = SQL_Supplier_GetSearch_Cocal
        Me.SQL_Col_GetSearch_GetByID = SQL_Supplier_GetSearch_GetByID_Cocal
        Me.SQL_Col_GetSearch_Order = SQL_Supplier_GetSearch_Order
        Me.SQL_Col_GetSearch_Where = SQL_Supplier_GetSearch_Where
    End Sub


    'Protected Overrides Sub On_Add_ButtonClick()
    'Protected Overrides Sub On_Modify_ButtonClick()
    'Protected Overrides Sub On_Del_ButtonClick()

End Class
