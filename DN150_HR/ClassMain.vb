Imports PClass.PClass
Imports System.Drawing

Public Class ClassMain

#Region "权限常量"
    Public Const Add As String = "Add"
    Public Const Modify As String = "Modify"
    Public Const Del As String = "Del"
    Public Const Right_Modify As String = "Right_Modify"
    Public Const FileOut As String = "FileOut"
    'Public Const SetInValid As String = "SetInValid"
    'Public Const SetValid As String = "SetValid"
    'Public Const ComfirmStoreInOrOut As String = "ComfirmStoreInOrOut"
    'Public Const Audited As String = "Audited"
    'Public Const UnAudit As String = "UnAudit"
    'Public Const Print As String = "Print"
    'Public Const SetReport As String = "SetReport"
    'Public Const ShowProfit As String = "ShowProfit"
#End Region
    Public CMenuX As New List(Of MainMenuXTpye)
    Public CModule As New List(Of MainModuleTpye)
    Public CForm As New List(Of DLLTpye)
    Public AppName As String
    Public Sub New(ByVal AppDes As String) '类创建事件
        AppName = "JMJ"
        If DllCheck(AppDes) = "" Then
            Exit Sub
        End If
        Dim MenuX As MainMenuXTpye
        Dim ModuleX As MainModuleTpye
        Dim FormX As DLLTpye

        '---------主菜单------------
        MenuX = New MainMenuXTpye
        MenuX.ID = 15                   '===需修改=========== 菜单ID
        MenuX.Caption = "人力资源"      '===需修改=========== 菜单名
        CMenuX.Add(MenuX)

        ''---------主模块------------
        ModuleX = New MainModuleTpye
        ModuleX.ID = 150                    '===需修改=========== 模块ID
        ModuleX.Caption = "部门及员工管理"      '===需修改=========== 模块名
        CModule.Add(ModuleX)



  

 


    End Sub

    'dll验证
    Public Function DllCheck(ByVal AppDes As String) As String
        If DeDes(AppDes, "MSATN") = AppName Then
            DllCheck = AppName
        Else
            DllCheck = ""
        End If
    End Function


End Class