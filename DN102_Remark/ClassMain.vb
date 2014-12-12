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
        'MenuX.ID = 10                  '===需修改=========== 菜单ID
        'MenuX.Caption = "基本资料"      '===需修改=========== 菜单名
        'CMenuX.Add(MenuX)


        ' ''---------主模块------------
        'ModuleX = New MainModuleTpye
        'ModuleX.ID = 102                    '===需修改=========== 模块ID
        'ModuleX.Caption = "备注资料"      '===需修改=========== 模块名
        'CModule.Add(ModuleX)


        ' ''---------主模块------------
        'ModuleX = New MainModuleTpye
        'ModuleX.ID = 100                    '===需修改=========== 模块ID
        'ModuleX.Caption = "基本资料"      '===需修改=========== 模块名
        'CModule.Add(ModuleX)


        ''---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "染色步骤"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F10200_Remark)    '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources.Export     '===需修改=========== 菜单图标
        'FormX.ID = 10023
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0

        'FormX.BillName = "染色步骤"     '单据名
        'FormX.FormType = BaseFormType.Setting '窗口类型
        'FormX.ModifyForm = GetType(F10201_Remark_Msg)    '修改窗口

        'FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "添加"})
        'FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "修改"})
        'FormX.Right.Add(New RightTpye With {.RightName = Del, .RightShow = "删除"})
        'CForm.Add(FormX)

        ''---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "质量要求"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F10200_Remark)    '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources.Remark     '===需修改=========== 菜单图标
        'FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0

        'FormX.BillName = "质量要求"     '单据名
        'FormX.FormType = BaseFormType.Setting '窗口类型
        'FormX.ModifyForm = GetType(F10201_Remark_Msg)    '修改窗口

        'FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "添加"})
        'FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "修改"})
        'FormX.Right.Add(New RightTpye With {.RightName = Del, .RightShow = "删除"})
        'CForm.Add(FormX)

        ''---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "质量要求选择"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F10202_Remark_Sel)    '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources.Remark     '===需修改=========== 菜单图标
        'FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        'FormX.IsShow = False                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0

        'FormX.BillName = "质量要求选择"     '单据名
        'FormX.FormType = BaseFormType.Sel '窗口类型
        ''FormX.ModifyForm = GetType(F10201_Remark_Msg)    '修改窗口

        'FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "添加"})
        'FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "修改"})
        'FormX.Right.Add(New RightTpye With {.RightName = Del, .RightShow = "删除"})
        'CForm.Add(FormX)

        ''---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "车牌"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F10200_Remark)    '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources.Delivery     '===需修改=========== 菜单图标
        'FormX.ID = 10201
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0

        'FormX.BillName = "车牌"     '单据名
        'FormX.FormType = BaseFormType.Setting '窗口类型
        'FormX.ModifyForm = GetType(F10201_Remark_Msg)    '修改窗口

        'FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "添加"})
        'FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "修改"})
        'FormX.Right.Add(New RightTpye With {.RightName = Del, .RightShow = "删除"})
        'CForm.Add(FormX)

        ''---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "加工类别"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F10200_Remark)    '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources.ProcessType      '===需修改=========== 菜单图标
        'FormX.ID = 10203
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0

        'FormX.BillName = "加工类别"     '单据名
        'FormX.FormType = BaseFormType.Setting '窗口类型
        'FormX.ModifyForm = GetType(F10201_Remark_Msg)    '修改窗口

        'FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "添加"})
        'FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "修改"})
        'FormX.Right.Add(New RightTpye With {.RightName = Del, .RightShow = "删除"})
        'CForm.Add(FormX)

        ''---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "入库原因"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F10200_Remark)    '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources._86       '===需修改=========== 菜单图标
        'FormX.ID = 10205
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0

        'FormX.BillName = "入库原因"     '单据名
        'FormX.FormType = BaseFormType.Setting '窗口类型
        'FormX.ModifyForm = GetType(F10201_Remark_Msg)    '修改窗口

        'FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "添加"})
        'FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "修改"})
        'FormX.Right.Add(New RightTpye With {.RightName = Del, .RightShow = "删除"})
        'CForm.Add(FormX)

        ''---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "退料原因"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F10200_Remark)    '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources._74       '===需修改=========== 菜单图标
        'FormX.ID = 10206
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0

        'FormX.BillName = "退料原因"     '单据名
        'FormX.FormType = BaseFormType.Setting '窗口类型
        'FormX.ModifyForm = GetType(F10201_Remark_Msg)    '修改窗口

        'FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "添加"})
        'FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "修改"})
        'FormX.Right.Add(New RightTpye With {.RightName = Del, .RightShow = "删除"})
        'CForm.Add(FormX)

        ''---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "出库原因"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F10200_Remark)    '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources._73       '===需修改=========== 菜单图标
        'FormX.ID = 10207
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0

        'FormX.BillName = "出库原因"     '单据名
        'FormX.FormType = BaseFormType.Setting '窗口类型
        'FormX.ModifyForm = GetType(F10201_Remark_Msg)    '修改窗口

        'FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "添加"})
        'FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "修改"})
        'FormX.Right.Add(New RightTpye With {.RightName = Del, .RightShow = "删除"})
        'CForm.Add(FormX)


        ''---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "领料原因"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F10200_Remark)    '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources._65       '===需修改=========== 菜单图标
        'FormX.ID = 10208
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0

        'FormX.BillName = "领料原因"     '单据名
        'FormX.FormType = BaseFormType.Setting '窗口类型
        'FormX.ModifyForm = GetType(F10201_Remark_Msg)    '修改窗口

        'FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "添加"})
        'FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "修改"})
        'FormX.Right.Add(New RightTpye With {.RightName = Del, .RightShow = "删除"})
        'CForm.Add(FormX)


        ' ''---------主窗口----------
        ''FormX = New DLLTpye
        ''FormX.Caption = "回修项目"         '===需修改=========== 窗口菜单名
        ''FormX.FormName = GetType(F10200_Remark)    '===需修改=========== 窗口调用名
        ''FormX.Img = My.Resources._65       '===需修改=========== 菜单图标
        ''FormX.ID = 10209
        ''FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        ''FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        ''FormX.DllAss_Index = 0

        ''FormX.BillName = "回修项目"     '单据名
        ''FormX.FormType = BaseFormType.Setting '窗口类型
        ''FormX.ModifyForm = GetType(F10201_Remark_Msg)    '修改窗口

        ''FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "添加"})
        ''FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "修改"})
        ''FormX.Right.Add(New RightTpye With {.RightName = Del, .RightShow = "删除"})
        ''CForm.Add(FormX)

        ' ''---------主窗口----------
        ''FormX = New DLLTpye
        ''FormX.Caption = "回修项目选择"         '===需修改=========== 窗口菜单名
        ''FormX.FormName = GetType(F10202_Remark_Sel)    '===需修改=========== 窗口调用名
        ''FormX.Img = My.Resources._65       '===需修改=========== 菜单图标
        ''FormX.ID = 10220
        ''FormX.IsShow = False                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        ''FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        ''FormX.DllAss_Index = 0

        ''FormX.BillName = "回修项目"     '单据名
        ''FormX.FormType = BaseFormType.Setting '窗口类型
        ''FormX.ModifyForm = GetType(F10201_Remark_Msg)    '修改窗口

        ''FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "添加"})
        ''FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "修改"})
        ''FormX.Right.Add(New RightTpye With {.RightName = Del, .RightShow = "删除"})
        ''CForm.Add(FormX)


        ''---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "改色原因"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F10202_Remark_Sel)    '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources._65       '===需修改=========== 菜单图标
        'FormX.ID = 10221
        'FormX.IsShow = False                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0

        'FormX.BillName = "改色原因"     '单据名
        'FormX.FormType = BaseFormType.Setting '窗口类型
        'FormX.ModifyForm = GetType(F10201_Remark_Msg)    '修改窗口

        'FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "添加"})
        'FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "修改"})
        'FormX.Right.Add(New RightTpye With {.RightName = Del, .RightShow = "删除"})
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