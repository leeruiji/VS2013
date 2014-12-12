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
    'Public Const ComfirmAccountsOrOut As String = "ComfirmAccountsOrOut"
    Public Const Audited As String = "Audited"
    Public Const UnAudit As String = "UnAudit"
    Public Const Lock As String = "Lock"
    Public Const UnLock As String = "UnLock"
    Public Const Print As String = "Print"
    Public Const ShowKuaiJi As String = "ShowKuaiJi" '查看会计账目
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
        'MenuX.ID = 50                 '===需修改=========== 菜单ID
        'MenuX.Caption = "财务管理"      '===需修改=========== 菜单名
        'CMenuX.Add(MenuX)


        ' ''---------主模块------------
        'ModuleX = New MainModuleTpye
        'ModuleX.ID = 500                    '===需修改=========== 模块ID
        'ModuleX.Caption = "财务报价"      '===需修改=========== 模块名
        'CModule.Add(ModuleX)


        ' ''---------主模块------------
        'ModuleX = New MainModuleTpye
        'ModuleX.ID = 501                    '===需修改=========== 模块ID
        'ModuleX.Caption = "对账单"      '===需修改=========== 模块名
        'CModule.Add(ModuleX)


        ' ''---------主模块------------
        'ModuleX = New MainModuleTpye
        'ModuleX.ID = 502                    '===需修改=========== 模块ID
        'ModuleX.Caption = "手感报价"      '===需修改=========== 模块名
        'CModule.Add(ModuleX)


        '' ---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "内部报价单"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F50030_InnerPrice)    '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources.money      '===需修改=========== 菜单图标
        'FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0

        'FormX.BillName = "内部报价单"     '单据名
        'FormX.FormType = BaseFormType.Bill '窗口类型
        'FormX.ModifyForm = GetType(F50031_InnerPrice_Msg)    '修改窗口

        'FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "添加"})
        'FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "修改"})
        'FormX.Right.Add(New RightTpye With {.RightName = Del, .RightShow = "删除"})
        'FormX.Right.Add(New RightTpye With {.RightName = SetInValid, .RightShow = "作废"})
        'FormX.Right.Add(New RightTpye With {.RightName = SetValid, .RightShow = "还原"})
        'FormX.Right.Add(New RightTpye With {.RightName = Audited, .RightShow = "审核"})
        'FormX.Right.Add(New RightTpye With {.RightName = UnAudit, .RightShow = "反审"})
        'CForm.Add(FormX)


        '' ---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "加工内容报价单"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F50010_ProcessPrice)    '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources._64      '===需修改=========== 菜单图标
        'FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0

        'FormX.BillName = "加工内容报价单"     '单据名
        'FormX.FormType = BaseFormType.Bill '窗口类型
        'FormX.ModifyForm = GetType(F50011_ProcessPrice_Msg)    '修改窗口

        'FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "添加"})
        'FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "修改"})
        'FormX.Right.Add(New RightTpye With {.RightName = Del, .RightShow = "删除"})
        'FormX.Right.Add(New RightTpye With {.RightName = SetInValid, .RightShow = "作废"})
        'FormX.Right.Add(New RightTpye With {.RightName = SetValid, .RightShow = "还原"})
        'FormX.Right.Add(New RightTpye With {.RightName = Audited, .RightShow = "审核"})
        'FormX.Right.Add(New RightTpye With {.RightName = UnAudit, .RightShow = "反审"})
        'CForm.Add(FormX)

        '' ---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "加工类型"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F50020_ProcessSort)    '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources._42      '===需修改=========== 菜单图标
        'FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0

        'FormX.BillName = "加工类型"     '单据名
        'FormX.FormType = BaseFormType.Bill '窗口类型
        'FormX.ModifyForm = GetType(F50021_ProcessSort_Msg)    '修改窗口

        'FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "添加"})
        'FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "修改"})
        'FormX.Right.Add(New RightTpye With {.RightName = Del, .RightShow = "删除"})

        'CForm.Add(FormX)

        '' ---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "发货结算对账单"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F50100_BZSH_Balance)    '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources.Word    '===需修改=========== 菜单图标
        'FormX.ID = 50100
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0

        'FormX.BillName = "发货结算对账单"     '单据名
        'FormX.FormType = BaseFormType.Bill '窗口类型
        'FormX.ModifyForm = GetType(F50101_BZSH_Balance_Msg)    '修改窗口

        'FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "添加"})
        'FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "修改"})
        'FormX.Right.Add(New RightTpye With {.RightName = Del, .RightShow = "删除"})
        'FormX.Right.Add(New RightTpye With {.RightName = SetInValid, .RightShow = "作废"})
        'FormX.Right.Add(New RightTpye With {.RightName = SetValid, .RightShow = "还原"})
        'FormX.Right.Add(New RightTpye With {.RightName = Audited, .RightShow = "审核"})
        'FormX.Right.Add(New RightTpye With {.RightName = UnAudit, .RightShow = "反审"})
        'FormX.Right.Add(New RightTpye With {.RightName = Lock, .RightShow = "锁定"})
        'FormX.Right.Add(New RightTpye With {.RightName = UnLock, .RightShow = "解锁"})
        'CForm.Add(FormX)

        '' ---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "报价单"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F50000_Price)    '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources.money      '===需修改=========== 菜单图标
        'FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0

        'FormX.BillName = "报价单"     '单据名
        'FormX.FormType = BaseFormType.Bill '窗口类型
        'FormX.ModifyForm = GetType(F50001_Price_Msg)    '修改窗口

        'FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "添加"})
        'FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "修改"})
        'FormX.Right.Add(New RightTpye With {.RightName = Del, .RightShow = "删除"})
        'FormX.Right.Add(New RightTpye With {.RightName = SetInValid, .RightShow = "作废"})
        'FormX.Right.Add(New RightTpye With {.RightName = SetValid, .RightShow = "还原"})
        'FormX.Right.Add(New RightTpye With {.RightName = Audited, .RightShow = "审核"})
        'FormX.Right.Add(New RightTpye With {.RightName = UnAudit, .RightShow = "反审"})
        'CForm.Add(FormX)


        '' ---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "手感内部报价单"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F50012_IniTouch)    '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources._20       '===需修改=========== 菜单图标
        'FormX.ID = 50200
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0

        'FormX.BillName = "手感内部报价单"     '单据名
        'FormX.FormType = BaseFormType.Bill '窗口类型
        'FormX.ModifyForm = GetType(F50013_IniTouch_Msg)    '修改窗口

        'FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "添加"})
        'FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "修改"})
        'FormX.Right.Add(New RightTpye With {.RightName = Del, .RightShow = "删除"})
        'FormX.Right.Add(New RightTpye With {.RightName = SetInValid, .RightShow = "作废"})
        'FormX.Right.Add(New RightTpye With {.RightName = SetValid, .RightShow = "还原"})
        'FormX.Right.Add(New RightTpye With {.RightName = Audited, .RightShow = "审核"})
        'FormX.Right.Add(New RightTpye With {.RightName = UnAudit, .RightShow = "反审"})
        'CForm.Add(FormX)


        '' ---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "手感报价单"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F50032_PriceiTouch)    '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources._21       '===需修改=========== 菜单图标
        'FormX.ID = 50201
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0

        'FormX.BillName = "手感报价单"     '单据名
        'FormX.FormType = BaseFormType.Bill '窗口类型
        'FormX.ModifyForm = GetType(F50033_PriceiTouch_Msg)    '修改窗口

        'FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "添加"})
        'FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "修改"})
        'FormX.Right.Add(New RightTpye With {.RightName = Del, .RightShow = "删除"})
        'FormX.Right.Add(New RightTpye With {.RightName = SetInValid, .RightShow = "作废"})
        'FormX.Right.Add(New RightTpye With {.RightName = SetValid, .RightShow = "还原"})
        'FormX.Right.Add(New RightTpye With {.RightName = Audited, .RightShow = "审核"})
        'FormX.Right.Add(New RightTpye With {.RightName = UnAudit, .RightShow = "反审"})
        'CForm.Add(FormX)

        '' ---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "报价汇总表"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F50040_PrinceSummary)    '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources._64      '===需修改=========== 菜单图标
        'FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0

        'FormX.BillName = "报价汇总表"     '单据名
        'FormX.FormType = BaseFormType.Bill '窗口类型
        ''FormX.ModifyForm = GetType(F50013_ProcessiTouch_Msg)    '修改窗口

        ''FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "添加"})
        ''FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "修改"})
        ''FormX.Right.Add(New RightTpye With {.RightName = Del, .RightShow = "删除"})
        ''FormX.Right.Add(New RightTpye With {.RightName = SetInValid, .RightShow = "作废"})
        ''FormX.Right.Add(New RightTpye With {.RightName = SetValid, .RightShow = "还原"})
        ''FormX.Right.Add(New RightTpye With {.RightName = Audited, .RightShow = "审核"})
        ''FormX.Right.Add(New RightTpye With {.RightName = UnAudit, .RightShow = "反审"})
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