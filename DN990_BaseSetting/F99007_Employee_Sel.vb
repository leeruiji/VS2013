Imports PClass.PClass
Imports System.Data
Imports System.Text
Public Class F99007_Employee_Sel
    Dim GoodsTypeID As String = ""
    Dim dtGoodsType As DataTable

    Public Sub New()

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。

    End Sub


    ''' <summary>
    ''' 权限获取
    ''' </summary>
    ''' <remarks></remarks>
    Sub FormCheckRight()
        'Control_CheckRight(ID, ClassMain.Add, Cmd_Add)
        'Control_CheckRight(ID, ClassMain.Modify, Cmd_Modify)
        'Control_CheckRight(ID, ClassMain.Del, Cmd_Del)
    End Sub
    Private Sub F10003_GoodsType_Sel_Load() Handles Me.Me_Load

        FormCheckRight()
      
        Me.DeptTree1.LoadData()

    End Sub

  


#Region "事件"
    
#End Region

#Region "工具栏按钮"




#End Region


#Region "树形菜单事件"
    ''' <summary>
    ''' 获取选择的员工
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetCheckedEmployee() As DataTable
        Return Me.DeptTree1.GetCheckedEmployee
    End Function
#End Region


End Class
