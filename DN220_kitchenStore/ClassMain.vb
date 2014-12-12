Imports PClass.PClass
Imports System.Drawing

Public Class ClassMain

#Region "权限常量"
    Public Const Add As String = "Add"
    Public Const Modify As String = "Modify"
    Public Const Del As String = "Del"
    Public Const ReNew As String = "ReNew"
    Public Const ShowPrice As String = "ShowPrice"
    Public Const ModifyPrice As String = "ModifyPrice"


    Public Const Right_Modify As String = "Right_Modify"
    Public Const FileOut As String = "FileOut"
    Public Const LuoDan As String = "LuoDan"
    Public Const SetInValid As String = "SetInValid"
    Public Const SetValid As String = "SetValid"
    'Public Const ComfirmStoreInOrOut As String = "ComfirmStoreInOrOut"
    Public Const Audited As String = "Audited"
    Public Const UnAudit As String = "UnAudit"
    Public Const Print As String = "Print"

    Public Const JiaLiao As String = "JiaLiao"
    Public Const ShowJiaLiao As String = "ShowJiaLiao"
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
        'MenuX.ID = 22                   '===需修改=========== 菜单ID
        'MenuX.Caption = "厨房仓"      '===需修改=========== 菜单名
        'CMenuX.Add(MenuX)

        ' ''---------主模块------------
        'ModuleX = New MainModuleTpye
        'ModuleX.ID = 220                   '===需修改=========== 模块ID
        'ModuleX.Caption = "仓存资料"      '===需修改=========== 模块名
        'CModule.Add(ModuleX)


        ' ''---------主模块------------
        'ModuleX = New MainModuleTpye
        'ModuleX.ID = 221                   '===需修改=========== 模块IDF221
        'ModuleX.Caption = "采购管理"      '===需修改=========== 模块名
        'CModule.Add(ModuleX)

        ' ''---------主模块------------
        'ModuleX = New MainModuleTpye
        'ModuleX.ID = 222                 '===需修改=========== 模块ID
        'ModuleX.Caption = "入库管理"      '===需修改=========== 模块名
        'CModule.Add(ModuleX)

        ' ''---------主模块------------
        'ModuleX = New MainModuleTpye
        'ModuleX.ID = 223                '===需修改=========== 模块ID
        'ModuleX.Caption = "出库管理"      '===需修改=========== 模块名
        'CModule.Add(ModuleX)
        ' ''---------主模块------------
        'ModuleX = New MainModuleTpye
        'ModuleX.ID = 224                 '===需修改=========== 模块ID
        'ModuleX.Caption = "库存调整"      '===需修改=========== 模块名
        'CModule.Add(ModuleX)
        ' ''---------主模块------------
        'ModuleX = New MainModuleTpye
        'ModuleX.ID = 229                '===需修改=========== 模块ID
        'ModuleX.Caption = "报表管理"      '===需修改=========== 模块名
        'CModule.Add(ModuleX)

        ''---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "厨房物料"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F22000_kitchen)     '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources.Store      '===需修改=========== 菜单图标
        'FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0

        'FormX.BillName = "厨房物料"     '单据名
        'FormX.FormType = BaseFormType.Basic '窗口类型
        'FormX.ModifyForm = GetType(F22001_kitchen_Msg)    '修改窗口

        'FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "添加"})
        'FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "修改"})
        'FormX.Right.Add(New RightTpye With {.RightName = Del, .RightShow = "删除"})
        'FormX.Right.Add(New RightTpye With {.RightName = ShowPrice, .RightShow = "显示价钱"})
        'FormX.Right.Add(New RightTpye With {.RightName = SetInValid, .RightShow = "禁用"})
        'FormX.Right.Add(New RightTpye With {.RightName = SetValid, .RightShow = "启用"})
        'FormX.Right.Add(New RightTpye With {.RightName = ReNew, .RightShow = "更换"})

        'CForm.Add(FormX)

        ''---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "成本价调整"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F22005_CostChange)     '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources._36     '===需修改=========== 菜单图标
        'FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0
        'FormX.BillName = "成本价调整"     '单据名
        'FormX.FormType = BaseFormType.Basic '窗口类型
        'FormX.ModifyForm = GetType(F22006_CostChange_Msg)    '修改窗口
        'FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "添加"})
        'CForm.Add(FormX)


        ''---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "厨房物料选择"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F22002_kitchen_Sel)    '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources.Store       '===需修改=========== 菜单图标
        'FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        'FormX.IsShow = False                 '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0

        'FormX.BillName = "厨房物料选择"     '单据名
        'FormX.FormType = BaseFormType.Sel '窗口类型
        '' FormX.ModifyForm = GetType(F22001_kitchen_Msg)    '修改窗口

        'CForm.Add(FormX)

        ''---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "厨房分类选择"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F22010_GoodsType_Sel)    '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources.Store      '===需修改=========== 菜单图标
        'FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        'FormX.IsShow = False                 '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0

        'FormX.BillName = "厨房分类选择"     '单据名
        'FormX.FormType = BaseFormType.Sel '窗口类型
        '' FormX.ModifyForm = GetType(F22001_kitchen_Msg)    '修改窗口

        'CForm.Add(FormX)
        ''---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "厨房供应商"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F22020_Supplier)   '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources._10300     '===需修改=========== 菜单图标
        'FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0

        'FormX.BillName = "厨房供应商"     '单据名
        'FormX.FormType = BaseFormType.Basic  '窗口类型
        'FormX.ModifyForm = GetType(F22022_Supplier_Msg)    '修改窗口

        'FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "供应商添加"})
        'FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "供应商修改"})
        'FormX.Right.Add(New RightTpye With {.RightName = Del, .RightShow = "供应商删除"})
        'CForm.Add(FormX)
        ''---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "厨房采购"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F22100_Purchase)     '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources._6     '===需修改=========== 菜单图标
        'FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0
        ''单据名称
        ''类型,单据,基础,设置,报表
        ''F20001_Purchase_Msg
        'FormX.BillName = "厨房采购"     '单据名
        'FormX.FormType = BaseFormType.Bill '窗口类型
        'FormX.ModifyForm = GetType(F22101_Purchase_Msg)    '修改窗口


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
        'FormX.Caption = "厨房采购单选择"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F22102_Purchase_Sel)    '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources._6     '===需修改=========== 菜单图标
        'FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        'FormX.IsShow = False                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0

        'FormX.BillName = "厨房采购单选择"     '单据名
        'FormX.FormType = BaseFormType.Sel '窗口类型
        'CForm.Add(FormX)


        'FormX = New DLLTpye
        'FormX.Caption = "厨房退货单"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F22110_PurchaseReturn)    '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources._34     '===需修改=========== 菜单图标
        'FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0

        'FormX.BillName = "采购退货单"     '单据名
        'FormX.FormType = BaseFormType.Bill '窗口类型
        'FormX.ModifyForm = GetType(F22111_PurchaseReturn_Msg)    '修改窗口

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
        'FormX.Caption = "厨房其他入库单"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F22200_StoreIn)    '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources.Store     '===需修改=========== 菜单图标
        'FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0

        'FormX.BillName = "厨房其他入库单"     '单据名
        'FormX.FormType = BaseFormType.Bill '窗口类型
        'FormX.ModifyForm = GetType(F22201_StoreIn_Msg)    '修改窗口

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



        ''---------主窗口----------
        ''FormX = New DLLTpye
        ''FormX.Caption = "厨房退料单"         '===需修改=========== 窗口菜单名
        ''FormX.FormName = GetType(F22200_StoreIn)    '===需修改=========== 窗口调用名
        ''FormX.Img = My.Resources._12     '===需修改=========== 菜单图标
        ''FormX.ID = 22220
        ''FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        ''FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        ''FormX.DllAss_Index = 0

        ''FormX.BillName = "厨房退料单"     '单据名
        ''FormX.FormType = BaseFormType.Bill '窗口类型
        ''FormX.ModifyForm = GetType(F22201_StoreIn_Msg)    '修改窗口


        ''FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "添加"})
        ''FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "修改"})
        ''FormX.Right.Add(New RightTpye With {.RightName = Del, .RightShow = "删除"})

        ''FormX.Right.Add(New RightTpye With {.RightName = SetInValid, .RightShow = "作废"})
        ''FormX.Right.Add(New RightTpye With {.RightName = SetValid, .RightShow = "还原"})
        ''FormX.Right.Add(New RightTpye With {.RightName = Audited, .RightShow = "审核"})
        ''FormX.Right.Add(New RightTpye With {.RightName = UnAudit, .RightShow = "反审"})

        ''FormX.Right.Add(New RightTpye With {.RightName = ShowPrice, .RightShow = "显示价钱"})
        ''FormX.Right.Add(New RightTpye With {.RightName = ModifyPrice, .RightShow = "修改价钱"})
        ''CForm.Add(FormX)



        ''---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "厨房其他出库单"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F22300_StoreOut)    '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources._22     '===需修改=========== 菜单图标
        'FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0

        'FormX.BillName = "厨房其他出库单"     '单据名
        'FormX.FormType = BaseFormType.Bill '窗口类型
        'FormX.ModifyForm = GetType(F22301_StoreOut_Msg)    '修改窗口

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



        ''---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "厨房领料"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F22300_StoreOut)    '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources._20     '===需修改=========== 菜单图标
        'FormX.ID = 22310
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0

        'FormX.BillName = "厨房领料单"     '单据名
        'FormX.FormType = BaseFormType.Bill '窗口类型
        'FormX.ModifyForm = GetType(F22301_StoreOut_Msg)    '修改窗口

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
        'CForm.Add(FormX)




        ''---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "库存调整单"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F22400_StockAdjust)    '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources._20      '===需修改=========== 菜单图标
        'FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0

        'FormX.BillName = "库存调整单"     '单据名
        'FormX.FormType = BaseFormType.Bill '窗口类型
        'FormX.ModifyForm = GetType(F22401_StockAdjust_Msg)    '修改窗口

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
        'FormX.Caption = "厨房仓库存汇总表"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F22900_Store_Summary)    '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources.large_icons      '===需修改=========== 菜单图标
        'FormX.ID = 22900
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0

        'FormX.BillName = "厨房仓库存汇总表"     '单据名
        'FormX.FormType = BaseFormType.Report '窗口类型
        '' FormX.ModifyForm = GetType(F20322_DXLingLiao_Msg)    '修改窗口

        'FormX.Right.Add(New RightTpye With {.RightName = Print, .RightShow = "打印"})


        'CForm.Add(FormX)

        ''---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "厨房进销存表"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F22910_JXC)   '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources.ChartChangeType      '===需修改=========== 菜单图标
        'FormX.ID = 22910
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0

        'FormX.BillName = "厨房进销存表"     '单据名
        'FormX.FormType = BaseFormType.Report '窗口类型
        '' FormX.ModifyForm = GetType(F20322_DXLingLiao_Msg)    '修改窗口

        'FormX.Right.Add(New RightTpye With {.RightName = Print, .RightShow = "打印"})


        'CForm.Add(FormX)

        ''---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "厨房领料汇总"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F22920_LingLiaoSummary)   '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources.ChartChangeType      '===需修改=========== 菜单图标
        'FormX.ID = 22920
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0

        'FormX.BillName = "厨房领料汇总"     '单据名
        'FormX.FormType = BaseFormType.Report '窗口类型
        '' FormX.ModifyForm = GetType(F20322_DXLingLiao_Msg)    '修改窗口

        'FormX.Right.Add(New RightTpye With {.RightName = Print, .RightShow = "打印"})


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