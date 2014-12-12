Imports PClass.PClass
Imports System.Drawing

Public Class ClassMain

#Region "权限常量"
    Public Const Add As String = "Add"
    Public Const Modify As String = "Modify"
    Public Const Del As String = "Del"
    'Public Const Right_Modify As String = "Right_Modify"
    ' Public Const FileOut As String = "FileOut"
    Public Const SetInValid As String = "SetInValid"
    Public Const SetValid As String = "SetValid"
    'Public Const ComfirmStoreInOrOut As String = "ComfirmStoreInOrOut"
    Public Const Audited As String = "Audited"
    Public Const UnAudit As String = "UnAudit"
    'Public Const Print As String = "Print"
    'Public Const SetReport As String = "SetReport"
    'Public Const ShowProfit As String = "ShowProfit"
#End Region
    Public CMenuX As New List(Of MainMenuXTpye)
    Public CModule As New List(Of MainModuleTpye)
    Public CForm As New List(Of DLLTpye)
    Public AppName As String
    Public Sub New(ByVal AppDes As String) '类创建事件
        AppName = "XHF"
        If DllCheck(AppDes) = "" Then
            Exit Sub
        End If
        Dim MenuX As MainMenuXTpye
        Dim ModuleX As MainModuleTpye
        Dim FormX As DLLTpye
        '---------主菜单------------
        MenuX = New MainMenuXTpye
        MenuX.ID = 25                 '===需修改=========== 菜单ID
        MenuX.Caption = "生产管理"      '===需修改=========== 菜单名
        CMenuX.Add(MenuX)


        ''---------主模块------------
        ModuleX = New MainModuleTpye
        ModuleX.ID = 250                    '===需修改=========== 模块ID
        ModuleX.Caption = "生产模块"      '===需修改=========== 模块名
        CModule.Add(ModuleX)



        '---------主窗口----------
        FormX = New DLLTpye
        FormX.Caption = "生产记录"         '===需修改=========== 窗口菜单名
        FormX.FormName = "F25000_Produce"    '===需修改=========== 窗口调用名
        FormX.Img = My.Resources.Produce    '===需修改=========== 菜单图标
        FormX.ID = CInt(FormX.FormName.Substring(1, 5))
        FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        FormX.DllAss_Index = 0
        FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "生产单添加"})
        FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "生产单修改"})
        FormX.Right.Add(New RightTpye With {.RightName = Del, .RightShow = "生产单删除"})
        'FormX.Right.Add(New RightTpye With {.RightName = SetInValid, .RightShow = "生产单作废"})
        'FormX.Right.Add(New RightTpye With {.RightName = SetValid, .RightShow = "生产单还原"})
        'FormX.Right.Add(New RightTpye With {.RightName = Audited, .RightShow = "生产单审核"})
        'FormX.Right.Add(New RightTpye With {.RightName = UnAudit, .RightShow = "生产单反审"})
        CForm.Add(FormX)


      

 


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