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
        'AppName = "GYFZ"
        'If DllCheck(AppDes) = "" Then
        '    Exit Sub
        'End If
        'Dim MenuX As MainMenuXTpye
        'Dim ModuleX As MainModuleTpye
        'Dim FormX As DLLTpye

        ''---------主菜单------------
        'MenuX = New MainMenuXTpye
        'MenuX.ID = 89                   '===需修改=========== 菜单ID
        'MenuX.Caption = "在线办公"      '===需修改=========== 菜单名
        'CMenuX.Add(MenuX)

        ' ''---------主模块------------
        'ModuleX = New MainModuleTpye
        'ModuleX.ID = 890                    '===需修改=========== 模块ID
        'ModuleX.Caption = "在线办公"      '===需修改=========== 模块名
        'CModule.Add(ModuleX)



        ''---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "文件列表"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F89000_FileList)   '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources.Image_89000     '===需修改=========== 菜单图标
        'FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0
        'FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "文件添加"})

        'FormX.BillName = "在线文档"     '单据名
        'FormX.FormType = BaseFormType.Basic '窗口类型
        'FormX.ModifyForm = GetType(F89001_FileAdd)    '修改窗口

        'CForm.Add(FormX)

        ''---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "新建文档"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F89001_FileAdd)    '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources.Word      '===需修改=========== 菜单图标
        'FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0
        'FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "文件添加"})

        'FormX.BillName = "在线文档"     '单据名
        'FormX.FormType = BaseFormType.Other '窗口类型
        'FormX.ModifyForm = GetType(F89001_FileAdd)    '修改窗口

        'CForm.Add(FormX)


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