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
        MenuX.ID = 10                  '===需修改=========== 菜单ID
        MenuX.Caption = "基本资料"      '===需修改=========== 菜单名
        CMenuX.Add(MenuX)


        '---------主模块------------
        ModuleX = New MainModuleTpye
        ModuleX.ID = 101                    '===需修改=========== 模块ID
        ModuleX.Caption = "客商资料"      '===需修改=========== 模块名
        CModule.Add(ModuleX)



        '---------主窗口----------
        FormX = New DLLTpye
        FormX.Caption = "供应商设置"         '===需修改=========== 窗口菜单名
        FormX.FormName = GetType(F10100_Supplier)   '===需修改=========== 窗口调用名
        FormX.Img = My.Resources._10300     '===需修改=========== 菜单图标
        FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        FormX.DllAss_Index = 0

        FormX.BillName = "供应商"     '单据名
        FormX.FormType = BaseFormType.Basic '窗口类型
        FormX.ModifyForm = GetType(F10101_Supplier_Msg)    '修改窗口

        FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "供应商添加"})
        FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "供应商修改"})
        FormX.Right.Add(New RightTpye With {.RightName = Del, .RightShow = "供应商删除"})
        CForm.Add(FormX)


        '---------主窗口----------
        FormX = New DLLTpye
        FormX.Caption = "客户设置"         '===需修改=========== 窗口菜单名
        FormX.FormName = GetType(F10110_Client)    '===需修改=========== 窗口调用名
        FormX.Img = My.Resources._10350     '===需修改=========== 菜单图标
        FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        FormX.DllAss_Index = 0

        FormX.BillName = "客户"     '单据名
        FormX.FormType = BaseFormType.Basic '窗口类型
        FormX.ModifyForm = GetType(F10111_Client_Msg)    '修改窗口

        FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "客户添加"})
        FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "客户修改"})
        FormX.Right.Add(New RightTpye With {.RightName = Del, .RightShow = "客户删除"})
        CForm.Add(FormX)



        ''---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "织厂设置"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F10120_ZhiChang)    '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources._10300     '===需修改=========== 菜单图标
        'FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0

        'FormX.BillName = "织厂"     '单据名
        'FormX.FormType = BaseFormType.Basic '窗口类型
        'FormX.ModifyForm = GetType(F10121_ZhiChang_Msg)    '修改窗口

        'FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "织厂添加"})
        'FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "织厂修改"})
        'FormX.Right.Add(New RightTpye With {.RightName = Del, .RightShow = "织厂删除"})
        'CForm.Add(FormX)

        ''---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "加工单位设置"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F10130_JGDW)    '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources._10350     '===需修改=========== 菜单图标
        'FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0

        'FormX.BillName = "加工单位"     '单据名
        'FormX.FormType = BaseFormType.Basic '窗口类型
        'FormX.ModifyForm = GetType(F10131_JGDW_Msg)    '修改窗口


        'FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "加工单位添加"})
        'FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "加工单位修改"})
        'FormX.Right.Add(New RightTpye With {.RightName = Del, .RightShow = "加工单位删除"})
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