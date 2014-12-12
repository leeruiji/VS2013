Imports PClass.PClass
Imports System.Drawing

Public Class ClassMain

#Region "权限常量"
    Public Const Add As String = "Add"
    Public Const Modify As String = "Modify"
    Public Const Del As String = "Del"

    Public Const ShowPrice As String = "ShowPrice"
    Public Const ModifyPrice As String = "ModifyPrice"


    Public Const Right_Modify As String = "Right_Modify"
    Public Const FileOut As String = "FileOut"
    Public Const LuoDan As String = "LuoDan"
    Public Const SetInValid As String = "SetInValid"
    Public Const SetValid As String = "SetValid"
    Public Const Rebuild As String = "Rebuild"

    'Public Const ComfirmStoreInOrOut As String = "ComfirmStoreInOrOut"
    Public Const Audited As String = "Audited"
    Public Const UnAudit As String = "UnAudit"

    Public Const Confirm As String = "Confirm"
    Public Const UnConfirm As String = "UnConfirm"
    Public Const ConfirmDate As String = "ConfirmDate"


    Public Const Print As String = "Print"

    Public Const JiaLiao As String = "JiaLiao"
    Public Const ShowJiaLiao As String = "ShowJiaLiao"
    Public Const PrintMore As String = "PrintMore"
    'Public Const SetReport As String = "SetReport"
    'Public Const ShowProfit As String = "ShowProfit"
    Public Const ReportRemark As String = "ReportRemark"

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
        MenuX.ID = 20                   '===需修改=========== 菜单ID
        MenuX.Caption = "物料管理"      '===需修改=========== 菜单名
        CMenuX.Add(MenuX)

        ''---------主模块------------
        ModuleX = New MainModuleTpye
        ModuleX.ID = 200                   '===需修改=========== 模块ID
        ModuleX.Caption = "采购管理"      '===需修改=========== 模块名
        CModule.Add(ModuleX)


        ''---------主模块------------
        ModuleX = New MainModuleTpye
        ModuleX.ID = 202                   '===需修改=========== 模块ID
        ModuleX.Caption = "入库管理"      '===需修改=========== 模块名
        CModule.Add(ModuleX)

        ''---------主模块------------
        ModuleX = New MainModuleTpye
        ModuleX.ID = 203                 '===需修改=========== 模块ID
        ModuleX.Caption = "出库管理"      '===需修改=========== 模块名
        CModule.Add(ModuleX)


        ''---------主模块------------
        'ModuleX = New MainModuleTpye
        'ModuleX.ID = 204                 '===需修改=========== 模块ID
        'ModuleX.Caption = "库存调整"      '===需修改=========== 模块名
        'CModule.Add(ModuleX)




        ''---------主模块------------
        ModuleX = New MainModuleTpye
        ModuleX.ID = 209                '===需修改=========== 模块ID
        ModuleX.Caption = "报表管理"      '===需修改=========== 模块名
        CModule.Add(ModuleX)


        '---------主窗口----------
        FormX = New DLLTpye
        FormX.Caption = "申购单"         '===需修改=========== 窗口菜单名
        FormX.FormName = GetType(F20000_ApplyPurchase)     '===需修改=========== 窗口调用名
        FormX.Img = My.Resources._6     '===需修改=========== 菜单图标
        FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        FormX.DllAss_Index = 0
        '单据名称
        '类型,单据,基础,设置,报表
        'F20001_Purchase_Msg
        FormX.BillName = "申购单"     '单据名
        FormX.FormType = BaseFormType.Bill '窗口类型
        FormX.ModifyForm = GetType(F20001_ApplyPurchase_Msg)    '修改窗口


        FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "添加"})
        FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "修改"})
        FormX.Right.Add(New RightTpye With {.RightName = Del, .RightShow = "删除"})
        FormX.Right.Add(New RightTpye With {.RightName = SetInValid, .RightShow = "作废"})
        FormX.Right.Add(New RightTpye With {.RightName = SetValid, .RightShow = "还原"})
        FormX.Right.Add(New RightTpye With {.RightName = Confirm, .RightShow = "确认"})
        FormX.Right.Add(New RightTpye With {.RightName = UnConfirm, .RightShow = "反确认"})
        FormX.Right.Add(New RightTpye With {.RightName = Audited, .RightShow = "审核"})
        FormX.Right.Add(New RightTpye With {.RightName = UnAudit, .RightShow = "反审"})
        CForm.Add(FormX)


        ''---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "申购单"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F20020_ApplyPurchase)     '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources._6     '===需修改=========== 菜单图标
        'FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0
        ''单据名称
        ''类型,单据,基础,设置,报表
        ''F20001_Purchase_Msg
        'FormX.BillName = "申购单"     '单据名
        'FormX.FormType = BaseFormType.Bill '窗口类型
        'FormX.ModifyForm = GetType(F20021_ApplyPurchase_Msg)    '修改窗口


        'FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "添加"})
        'FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "修改"})
        'FormX.Right.Add(New RightTpye With {.RightName = Del, .RightShow = "删除"})
        'FormX.Right.Add(New RightTpye With {.RightName = SetInValid, .RightShow = "作废"})
        'FormX.Right.Add(New RightTpye With {.RightName = SetValid, .RightShow = "还原"})
        'FormX.Right.Add(New RightTpye With {.RightName = Audited, .RightShow = "审核"})
        'FormX.Right.Add(New RightTpye With {.RightName = UnAudit, .RightShow = "反审"})
        'CForm.Add(FormX)

        '---------主窗口----------
        FormX = New DLLTpye
        FormX.Caption = "申购物料列表"         '===需修改=========== 窗口菜单名
        FormX.FormName = GetType(F20002_Purchase_Sel)    '===需修改=========== 窗口调用名
        FormX.Img = My.Resources._6     '===需修改=========== 菜单图标
        FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        FormX.IsShow = False                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        FormX.DllAss_Index = 0

        FormX.BillName = "申购物料列表"     '单据名
        FormX.FormType = BaseFormType.Sel '窗口类型
        CForm.Add(FormX)


        FormX = New DLLTpye
        FormX.Caption = "采购单"         '===需修改=========== 窗口菜单名
        FormX.FormName = GetType(F20010_Purchase)    '===需修改=========== 窗口调用名
        FormX.Img = My.Resources._34     '===需修改=========== 菜单图标
        FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        FormX.DllAss_Index = 0

        FormX.BillName = "采购单"     '单据名
        FormX.FormType = BaseFormType.Bill '窗口类型
        FormX.ModifyForm = GetType(F20011_Purchase_Msg)    '修改窗口

        FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "添加"})
        FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "修改"})
        FormX.Right.Add(New RightTpye With {.RightName = Del, .RightShow = "删除"})

        FormX.Right.Add(New RightTpye With {.RightName = SetInValid, .RightShow = "作废"})
        FormX.Right.Add(New RightTpye With {.RightName = SetValid, .RightShow = "还原"})
        FormX.Right.Add(New RightTpye With {.RightName = Audited, .RightShow = "审核"})
        FormX.Right.Add(New RightTpye With {.RightName = UnAudit, .RightShow = "反审"})
        FormX.Right.Add(New RightTpye With {.RightName = ConfirmDate, .RightShow = "确认采购到货日期"})
        CForm.Add(FormX)



        '---------主窗口----------
        FormX = New DLLTpye
        FormX.Caption = "其他入库单"         '===需修改=========== 窗口菜单名
        FormX.FormName = GetType(F20200_StoreIn)    '===需修改=========== 窗口调用名
        FormX.Img = My.Resources.Store     '===需修改=========== 菜单图标
        FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        FormX.DllAss_Index = 0

        FormX.BillName = "其他入库单"     '单据名
        FormX.FormType = BaseFormType.Bill '窗口类型
        FormX.ModifyForm = GetType(F20201_StoreIn_Msg)    '修改窗口

        FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "添加"})
        FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "修改"})
        FormX.Right.Add(New RightTpye With {.RightName = Del, .RightShow = "删除"})

        FormX.Right.Add(New RightTpye With {.RightName = SetInValid, .RightShow = "作废"})
        FormX.Right.Add(New RightTpye With {.RightName = SetValid, .RightShow = "还原"})
        FormX.Right.Add(New RightTpye With {.RightName = Audited, .RightShow = "审核"})
        FormX.Right.Add(New RightTpye With {.RightName = UnAudit, .RightShow = "反审"})

        FormX.Right.Add(New RightTpye With {.RightName = ShowPrice, .RightShow = "显示价钱"})
        FormX.Right.Add(New RightTpye With {.RightName = ModifyPrice, .RightShow = "修改价钱"})
        CForm.Add(FormX)


        '---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "采购入库单"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F20200_StoreIn)    '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources.Resources._12      '===需修改=========== 菜单图标
        'FormX.ID = 20210
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0

        'FormX.BillName = "采购入库单"     '单据名
        'FormX.FormType = BaseFormType.Bill '窗口类型
        'FormX.ModifyForm = GetType(F20201_StoreIn_Msg)    '修改窗口

        'FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "添加"})
        'FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "修改"})
        'FormX.Right.Add(New RightTpye With {.RightName = Del, .RightShow = "删除"})

        'FormX.Right.Add(New RightTpye With {.RightName = SetInValid, .RightShow = "作废"})
        'FormX.Right.Add(New RightTpye With {.RightName = SetValid, .RightShow = "还原"})
        'FormX.Right.Add(New RightTpye With {.RightName = Audited, .RightShow = "审核"})
        'FormX.Right.Add(New RightTpye With {.RightName = UnAudit, .RightShow = "反审"})

        'FormX.Right.Add(New RightTpye With {.RightName = ShowPrice, .RightShow = "显示价钱"})
        'FormX.Right.Add(New RightTpye With {.RightName = ModifyPrice, .RightShow = "修改价钱"})
        'CForm.Add(FormX)



        '---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "退料单"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F20200_StoreIn)    '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources._12     '===需修改=========== 菜单图标
        'FormX.ID = 20210
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0

        'FormX.BillName = "退料单"     '单据名
        'FormX.FormType = BaseFormType.Bill '窗口类型
        'FormX.ModifyForm = GetType(F20201_StoreIn_Msg)    '修改窗口

        'FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "添加"})
        'FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "修改"})
        'FormX.Right.Add(New RightTpye With {.RightName = Del, .RightShow = "删除"})

        'FormX.Right.Add(New RightTpye With {.RightName = SetInValid, .RightShow = "作废"})
        'FormX.Right.Add(New RightTpye With {.RightName = SetValid, .RightShow = "还原"})
        'FormX.Right.Add(New RightTpye With {.RightName = Audited, .RightShow = "审核"})
        'FormX.Right.Add(New RightTpye With {.RightName = UnAudit, .RightShow = "反审"})

        'FormX.Right.Add(New RightTpye With {.RightName = ShowPrice, .RightShow = "显示价钱"})
        'FormX.Right.Add(New RightTpye With {.RightName = ModifyPrice, .RightShow = "修改价钱"})
        'CForm.Add(FormX)



        '---------主窗口----------
        FormX = New DLLTpye
        FormX.Caption = "其它出库单"         '===需修改=========== 窗口菜单名
        FormX.FormName = GetType(F20302_OtherOut)    '===需修改=========== 窗口调用名
        FormX.Img = My.Resources._21     '===需修改=========== 菜单图标
        FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        FormX.DllAss_Index = 0

        FormX.BillName = "其它出库单"     '单据名
        FormX.FormType = BaseFormType.Bill '窗口类型
        FormX.ModifyForm = GetType(F20303_OtherOut_Msg)    '修改窗口

        FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "添加"})
        FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "修改"})
        FormX.Right.Add(New RightTpye With {.RightName = Del, .RightShow = "删除"})

        FormX.Right.Add(New RightTpye With {.RightName = SetInValid, .RightShow = "作废"})
        FormX.Right.Add(New RightTpye With {.RightName = SetValid, .RightShow = "还原"})
        FormX.Right.Add(New RightTpye With {.RightName = Audited, .RightShow = "审核"})
        FormX.Right.Add(New RightTpye With {.RightName = UnAudit, .RightShow = "反审"})

        FormX.Right.Add(New RightTpye With {.RightName = ShowPrice, .RightShow = "显示价钱"})
        FormX.Right.Add(New RightTpye With {.RightName = ModifyPrice, .RightShow = "修改价钱"})
        CForm.Add(FormX)


        ''---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "领料单"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F20300_StoreOut)    '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources._20     '===需修改=========== 菜单图标
        'FormX.ID = 20302
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0

        'FormX.BillName = "领料单"     '单据名
        'FormX.FormType = BaseFormType.Bill '窗口类型
        'FormX.ModifyForm = GetType(F20301_StoreOut_Msg)    '修改窗口

        'FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "添加"})
        'FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "修改"})
        'FormX.Right.Add(New RightTpye With {.RightName = Del, .RightShow = "删除"})

        'FormX.Right.Add(New RightTpye With {.RightName = SetInValid, .RightShow = "作废"})
        'FormX.Right.Add(New RightTpye With {.RightName = SetValid, .RightShow = "还原"})
        'FormX.Right.Add(New RightTpye With {.RightName = Audited, .RightShow = "审核"})
        'FormX.Right.Add(New RightTpye With {.RightName = UnAudit, .RightShow = "反审"})

        'FormX.Right.Add(New RightTpye With {.RightName = ShowPrice, .RightShow = "显示价钱"})
        'FormX.Right.Add(New RightTpye With {.RightName = ModifyPrice, .RightShow = "修改价钱"})
        'CForm.Add(FormX)

        '---------主窗口----------
        FormX = New DLLTpye
        FormX.Caption = "备货出库单"         '===需修改=========== 窗口菜单名
        FormX.FormName = GetType(F20300_StoreOut)    '===需修改=========== 窗口调用名
        FormX.Img = My.Resources._20     '===需修改=========== 菜单图标
        FormX.ID = 20304
        FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        FormX.DllAss_Index = 0

        FormX.BillName = "备货出库单"     '单据名
        FormX.FormType = BaseFormType.Bill '窗口类型
        FormX.ModifyForm = GetType(F20301_StoreOut_Msg)    '修改窗口

        FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "添加"})
        FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "修改"})
        FormX.Right.Add(New RightTpye With {.RightName = Del, .RightShow = "删除"})

        FormX.Right.Add(New RightTpye With {.RightName = SetInValid, .RightShow = "作废"})
        FormX.Right.Add(New RightTpye With {.RightName = SetValid, .RightShow = "还原"})
        FormX.Right.Add(New RightTpye With {.RightName = Audited, .RightShow = "审核"})
        FormX.Right.Add(New RightTpye With {.RightName = UnAudit, .RightShow = "反审"})

        FormX.Right.Add(New RightTpye With {.RightName = Confirm, .RightShow = "确认"})
        FormX.Right.Add(New RightTpye With {.RightName = UnConfirm, .RightShow = "反确认"})

        FormX.Right.Add(New RightTpye With {.RightName = ShowPrice, .RightShow = "显示价钱"})
        FormX.Right.Add(New RightTpye With {.RightName = ModifyPrice, .RightShow = "修改价钱"})
        CForm.Add(FormX)


        '---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "领料单"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F20310_LingLiao)    '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources._20     '===需修改=========== 菜单图标
        'FormX.ID = 20310
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0

        'FormX.BillName = "领料单"     '单据名
        'FormX.FormType = BaseFormType.Bill '窗口类型
        'FormX.ModifyForm = GetType(F20311_LingLiao_Msg)    '修改窗口

        'FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "添加"})
        'FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "修改"})
        'FormX.Right.Add(New RightTpye With {.RightName = Del, .RightShow = "删除"})

        'FormX.Right.Add(New RightTpye With {.RightName = Rebuild, .RightShow = "重建"})
        'FormX.Right.Add(New RightTpye With {.RightName = SetInValid, .RightShow = "作废"})
        'FormX.Right.Add(New RightTpye With {.RightName = SetValid, .RightShow = "还原"})
        'FormX.Right.Add(New RightTpye With {.RightName = Audited, .RightShow = "审核"})
        'FormX.Right.Add(New RightTpye With {.RightName = UnAudit, .RightShow = "反审"})

        'FormX.Right.Add(New RightTpye With {.RightName = ShowPrice, .RightShow = "显示价钱"})
        'FormX.Right.Add(New RightTpye With {.RightName = ModifyPrice, .RightShow = "修改价钱"})

        'FormX.Right.Add(New RightTpye With {.RightName = JiaLiao, .RightShow = "新增加料单"})
        'FormX.Right.Add(New RightTpye With {.RightName = ShowJiaLiao, .RightShow = "查看加料单"})
        'FormX.Right.Add(New RightTpye With {.RightName = PrintMore, .RightShow = "重复打印"})


        'CForm.Add(FormX)




        ''---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "定型领料"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F20320_DXLingLiao)    '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources._20     '===需修改=========== 菜单图标
        'FormX.ID = 20320
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0

        'FormX.BillName = "定型领料单"     '单据名
        'FormX.FormType = BaseFormType.Bill '窗口类型
        'FormX.ModifyForm = GetType(F20321_DXLingLiao_Msg)    '修改窗口

        'FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "添加"})
        'FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "修改"})
        'FormX.Right.Add(New RightTpye With {.RightName = Del, .RightShow = "删除"})

        'FormX.Right.Add(New RightTpye With {.RightName = SetInValid, .RightShow = "作废"})
        'FormX.Right.Add(New RightTpye With {.RightName = SetValid, .RightShow = "还原"})
        'FormX.Right.Add(New RightTpye With {.RightName = Audited, .RightShow = "审核"})
        'FormX.Right.Add(New RightTpye With {.RightName = UnAudit, .RightShow = "反审"})

        'FormX.Right.Add(New RightTpye With {.RightName = ShowPrice, .RightShow = "显示价钱"})
        'FormX.Right.Add(New RightTpye With {.RightName = ModifyPrice, .RightShow = "修改价钱"})


        'FormX.Right.Add(New RightTpye With {.RightName = JiaLiao, .RightShow = "新增加料单"})
        'FormX.Right.Add(New RightTpye With {.RightName = ShowJiaLiao, .RightShow = "查看加料单"})
        'FormX.Right.Add(New RightTpye With {.RightName = PrintMore, .RightShow = "重复打印"})
        'CForm.Add(FormX)


        ''---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "手感领料"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F20330_SGLingLiao)    '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources._20     '===需修改=========== 菜单图标
        'FormX.ID = 20330
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0

        'FormX.BillName = "手感领料单"     '单据名
        'FormX.FormType = BaseFormType.Bill '窗口类型
        'FormX.ModifyForm = GetType(F20331_SGLingLiao_Msg)    '修改窗口

        'FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "添加"})
        'FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "修改"})
        'FormX.Right.Add(New RightTpye With {.RightName = Del, .RightShow = "删除"})

        'FormX.Right.Add(New RightTpye With {.RightName = Rebuild, .RightShow = "重建"})
        'FormX.Right.Add(New RightTpye With {.RightName = SetInValid, .RightShow = "作废"})
        'FormX.Right.Add(New RightTpye With {.RightName = SetValid, .RightShow = "还原"})
        'FormX.Right.Add(New RightTpye With {.RightName = Audited, .RightShow = "审核"})
        'FormX.Right.Add(New RightTpye With {.RightName = UnAudit, .RightShow = "反审"})

        'FormX.Right.Add(New RightTpye With {.RightName = ShowPrice, .RightShow = "显示价钱"})
        'FormX.Right.Add(New RightTpye With {.RightName = ModifyPrice, .RightShow = "修改价钱"})

        'FormX.Right.Add(New RightTpye With {.RightName = JiaLiao, .RightShow = "新增加料单"})
        'FormX.Right.Add(New RightTpye With {.RightName = ShowJiaLiao, .RightShow = "查看加料单"})
        'FormX.Right.Add(New RightTpye With {.RightName = PrintMore, .RightShow = "重复打印"})


        'CForm.Add(FormX)

        '---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "库存调整单"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F20400_StockAdjust)    '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources._21     '===需修改=========== 菜单图标
        'FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0

        'FormX.BillName = "库存调整单"     '单据名
        'FormX.FormType = BaseFormType.Bill '窗口类型
        'FormX.ModifyForm = GetType(F20401_StockAdjust_Msg)    '修改窗口

        'FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "添加"})
        'FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "修改"})
        'FormX.Right.Add(New RightTpye With {.RightName = Del, .RightShow = "删除"})

        'FormX.Right.Add(New RightTpye With {.RightName = SetInValid, .RightShow = "作废"})
        'FormX.Right.Add(New RightTpye With {.RightName = SetValid, .RightShow = "还原"})
        'FormX.Right.Add(New RightTpye With {.RightName = Audited, .RightShow = "审核"})
        'FormX.Right.Add(New RightTpye With {.RightName = UnAudit, .RightShow = "反审"})

        'CForm.Add(FormX)



        ''---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "超料汇总表"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F20920_Chaoliao_gather)    '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources.large_icons      '===需修改=========== 菜单图标
        'FormX.ID = 20920
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0

        'FormX.BillName = "超料汇总表"     '单据名
        'FormX.FormType = BaseFormType.Report '窗口类型
        '' FormX.ModifyForm = GetType(F20321_DXLingLiao_Msg)    '修改窗口

        'FormX.Right.Add(New RightTpye With {.RightName = Print, .RightShow = "打印"})
        'FormX.Right.Add(New RightTpye With {.RightName = ReportRemark, .RightShow = "超料备注"})

        'CForm.Add(FormX)


        ''---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "重染汇总表"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F20922_ChongRan_Summary)    '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources.BZC       '===需修改=========== 菜单图标
        'FormX.ID = 20922
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0

        'FormX.BillName = "超料汇总表"     '单据名
        'FormX.FormType = BaseFormType.Report '窗口类型
        '' FormX.ModifyForm = GetType(F20321_DXLingLiao_Msg)    '修改窗口

        'FormX.Right.Add(New RightTpye With {.RightName = Print, .RightShow = "打印"})


        'CForm.Add(FormX)



        ''---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "库存汇总表"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F20900_Store_Summary)    '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources.large_icons      '===需修改=========== 菜单图标
        'FormX.ID = 20900
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0

        'FormX.BillName = "库存汇总表"     '单据名
        'FormX.FormType = BaseFormType.Report '窗口类型
        '' FormX.ModifyForm = GetType(F20321_DXLingLiao_Msg)    '修改窗口

        'FormX.Right.Add(New RightTpye With {.RightName = Print, .RightShow = "打印"})


        'CForm.Add(FormX)

        ''---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "月汇总表"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F20905_Store_Day)    '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources.large_icons      '===需修改=========== 菜单图标
        'FormX.ID = 20905
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0

        'FormX.BillName = "月汇总表"     '单据名
        'FormX.FormType = BaseFormType.Report '窗口类型
        '' FormX.ModifyForm = GetType(F20321_DXLingLiao_Msg)    '修改窗口

        'FormX.Right.Add(New RightTpye With {.RightName = Print, .RightShow = "打印"})


        'CForm.Add(FormX)


        ''---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "库存汇总明细表"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F20930_Store_Detail)    '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources.large_icons      '===需修改=========== 菜单图标
        'FormX.ID = 20930
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0

        'FormX.BillName = "库存汇总明细表"     '单据名
        'FormX.FormType = BaseFormType.Report '窗口类型
        '' FormX.ModifyForm = GetType(F20321_DXLingLiao_Msg)    '修改窗口

        'FormX.Right.Add(New RightTpye With {.RightName = Print, .RightShow = "打印"})


        'CForm.Add(FormX)

        '---------主窗口----------
        FormX = New DLLTpye
        FormX.Caption = "进销存表"         '===需修改=========== 窗口菜单名
        FormX.FormName = GetType(F20910_JXC)   '===需修改=========== 窗口调用名
        FormX.Img = My.Resources.ChartChangeType      '===需修改=========== 菜单图标
        FormX.ID = 20910
        FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        FormX.DllAss_Index = 0

        FormX.BillName = "进销存表"     '单据名
        FormX.FormType = BaseFormType.Report '窗口类型
        ' FormX.ModifyForm = GetType(F20321_DXLingLiao_Msg)    '修改窗口

        FormX.Right.Add(New RightTpye With {.RightName = Print, .RightShow = "打印"})


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