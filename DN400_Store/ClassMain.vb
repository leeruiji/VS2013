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
    Public Const CWAudited As String = "CWAudited"
    Public Const CWUnAudit As String = "CWUnAudit"
    Public Const Print As String = "Print"
    Public Const Comfirm As String = "Comfirm"
    Public Const UnComfirm As String = "UnComfirm"
    Public Const Price As String = "Price"
    Public Const Modify_Price As String = "Modify_Price"
    'Public Const SetReport As String = "SetReport"
    'Public Const ShowProfit As String = "ShowProfit"
    Public Const Lock As String = "Lock"
    Public Const UnLock As String = "UnLock"
    Public Const CancelPB As String = "CancelPB"
    Public Const ZJ As String = "ZJ"
    Public Const Miss As String = "Miss"
    Public Const CanUseWNGH As String = "CanUseWNGH"
    Public Const ModifyZL As String = "ModifyZL"
    Public Const SetReceipt As String = "SetReceipt"
    Public Const CanExcelOut As String = "CanExcelOut"
    Public Const RpCanExcelOut As String = "RPCanExcelOut"

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
        'MenuX.ID = 40                 '===需修改=========== 菜单ID
        'MenuX.Caption = "布仓管理"      '===需修改=========== 菜单名
        'CMenuX.Add(MenuX)


        ' ''---------主模块------------
        'ModuleX = New MainModuleTpye
        'ModuleX.ID = 400                    '===需修改=========== 模块ID
        'ModuleX.Caption = "送货单"      '===需修改=========== 模块名
        'CModule.Add(ModuleX)

        ' ''---------主模块------------
        'ModuleX = New MainModuleTpye
        'ModuleX.ID = 401                    '===需修改=========== 模块ID
        'ModuleX.Caption = "胚布仓"      '===需修改=========== 模块名
        'CModule.Add(ModuleX)

        ' ''---------主模块------------
        'ModuleX = New MainModuleTpye
        'ModuleX.ID = 402                    '===需修改=========== 模块ID
        'ModuleX.Caption = "配布"      '===需修改=========== 模块名
        'CModule.Add(ModuleX)



        ' ''---------主模块------------
        'ModuleX = New MainModuleTpye
        'ModuleX.ID = 403                   '===需修改=========== 模块ID
        'ModuleX.Caption = "成品仓"      '===需修改=========== 模块名
        'CModule.Add(ModuleX)



        ' ''---------主模块------------
        'ModuleX = New MainModuleTpye
        'ModuleX.ID = 404                    '===需修改=========== 模块ID
        'ModuleX.Caption = "半成品仓"      '===需修改=========== 模块名
        'CModule.Add(ModuleX)



        ' ''---------主模块------------
        'ModuleX = New MainModuleTpye
        'ModuleX.ID = 405                    '===需修改=========== 模块ID
        'ModuleX.Caption = "仓库"      '===需修改=========== 模块名
        'CModule.Add(ModuleX)



        ' ''---------主模块------------
        'ModuleX = New MainModuleTpye
        'ModuleX.ID = 409                   '===需修改=========== 模块ID
        'ModuleX.Caption = "报表"      '===需修改=========== 模块名
        'CModule.Add(ModuleX)




        ''   ---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "送货单"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F40000_BZSH)    '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources.Image_40000  '===需修改=========== 菜单图标
        'FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0

        'FormX.BillName = "送货单"     '单据名
        'FormX.FormType = BaseFormType.Bill '窗口类型
        'FormX.ModifyForm = GetType(F40001_BZSH_Msg)    '修改窗口

        'FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "送货单添加"})
        'FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "送货单修改"})
        'FormX.Right.Add(New RightTpye With {.RightName = Del, .RightShow = "送货单删除"})
        'FormX.Right.Add(New RightTpye With {.RightName = SetInValid, .RightShow = "送货单作废"})
        'FormX.Right.Add(New RightTpye With {.RightName = SetValid, .RightShow = "送货单还原"})
        'FormX.Right.Add(New RightTpye With {.RightName = Audited, .RightShow = "送货单审核"})
        'FormX.Right.Add(New RightTpye With {.RightName = UnAudit, .RightShow = "送货单反审"})
        'FormX.Right.Add(New RightTpye With {.RightName = Comfirm, .RightShow = "仓库确认"})
        'FormX.Right.Add(New RightTpye With {.RightName = UnComfirm, .RightShow = "取消确认"})
        'FormX.Right.Add(New RightTpye With {.RightName = Price, .RightShow = "查看单价"})
        'FormX.Right.Add(New RightTpye With {.RightName = Modify_Price, .RightShow = "修改单价"})

        'FormX.Right.Add(New RightTpye With {.RightName = SetReceipt, .RightShow = "已收回单"})

        'FormX.Right.Add(New RightTpye With {.RightName = CanExcelOut, .RightShow = "从列表导出Excel"})
        'FormX.Right.Add(New RightTpye With {.RightName = RpCanExcelOut, .RightShow = "从报表导出Excel"})
        'CForm.Add(FormX)



        ''   ---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "送货录入"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F40003_BZSH_ChangePrice)    '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources._31  '===需修改=========== 菜单图标
        'FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0

        'FormX.BillName = "送货录入"     '单据名
        'FormX.FormType = BaseFormType.Other '窗口类型
        ''FormX.ModifyForm = GetType(F40001_BZSH_Msg)    '修改窗口

        'FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "送货单修改"})
        'FormX.Right.Add(New RightTpye With {.RightName = Price, .RightShow = "查看单价"})
        'FormX.Right.Add(New RightTpye With {.RightName = Modify_Price, .RightShow = "修改单价"})
        'CForm.Add(FormX)



        ''   ---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "外发加工单"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F40010_OutWork)    '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources._36   '===需修改=========== 菜单图标
        'FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0

        'FormX.BillName = "外发加工单"     '单据名
        'FormX.FormType = BaseFormType.Bill '窗口类型
        'FormX.ModifyForm = GetType(F40011_OutWork_Msg)    '修改窗口

        'FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "添加"})
        'FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "修改"})
        'FormX.Right.Add(New RightTpye With {.RightName = Del, .RightShow = "删除"})
        'FormX.Right.Add(New RightTpye With {.RightName = SetInValid, .RightShow = "作废"})
        'FormX.Right.Add(New RightTpye With {.RightName = SetValid, .RightShow = "还原"})
        ''FormX.Right.Add(New RightTpye With {.RightName = Audited, .RightShow = "审核"})
        ''FormX.Right.Add(New RightTpye With {.RightName = UnAudit, .RightShow = "反审"})
        'FormX.Right.Add(New RightTpye With {.RightName = Comfirm, .RightShow = "仓库确认"})
        'FormX.Right.Add(New RightTpye With {.RightName = UnComfirm, .RightShow = "取消确认"})
        ''FormX.Right.Add(New RightTpye With {.RightName = Price, .RightShow = "查看单价"})
        ''FormX.Right.Add(New RightTpye With {.RightName = Modify_Price, .RightShow = "修改单价"})
        'FormX.Right.Add(New RightTpye With {.RightName = SetReceipt, .RightShow = "已收回单"})
        'CForm.Add(FormX)


        ' ''---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "胚布入库"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F40100_PBRK)    '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources.PBRK   '===需修改=========== 菜单图标
        'FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0

        'FormX.BillName = "胚布入库单"     '单据名
        'FormX.FormType = BaseFormType.Bill '窗口类型
        'FormX.ModifyForm = GetType(F40101_PBRK_Msg)    '修改窗口

        'FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "添加"})
        'FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "修改"})
        'FormX.Right.Add(New RightTpye With {.RightName = Del, .RightShow = "删除"})
        'FormX.Right.Add(New RightTpye With {.RightName = SetInValid, .RightShow = "作废"})
        'FormX.Right.Add(New RightTpye With {.RightName = SetValid, .RightShow = "还原"})
        'FormX.Right.Add(New RightTpye With {.RightName = Audited, .RightShow = "仓库审核"})
        'FormX.Right.Add(New RightTpye With {.RightName = UnAudit, .RightShow = "仓库反审"})
        'FormX.Right.Add(New RightTpye With {.RightName = CWAudited, .RightShow = "财务审核"})
        'FormX.Right.Add(New RightTpye With {.RightName = CWUnAudit, .RightShow = "财务反审"})
        'FormX.Right.Add(New RightTpye With {.RightName = ZJ, .RightShow = "追加"})
        'FormX.Right.Add(New RightTpye With {.RightName = ModifyZL, .RightShow = "改重量"})
        'FormX.Right.Add(New RightTpye With {.RightName = Miss, .RightShow = "忽略重量"})
        'FormX.Right.Add(New RightTpye With {.RightName = CanExcelOut, .RightShow = "从列表导出Excel"})
        'FormX.Right.Add(New RightTpye With {.RightName = RpCanExcelOut, .RightShow = "从报表导出Excel"})
        'CForm.Add(FormX)

        ' ''---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "仓位调整"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F40150_PBTC)    '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources._43   '===需修改=========== 菜单图标
        'FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0

        'FormX.BillName = "仓位调整单"     '单据名
        'FormX.FormType = BaseFormType.Bill '窗口类型
        'FormX.ModifyForm = GetType(F40151_PBTC_Msg)    '修改窗口

        'FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "添加"})
        'FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "修改"})
        'CForm.Add(FormX)

        ' ''---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "库存调整"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F40160_KCmodify_Msg)    '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources._43   '===需修改=========== 菜单图标
        'FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 1                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0

        'FormX.BillName = "库存调整"     '单据名
        'FormX.FormType = BaseFormType.Bill     '窗口类型
        ''FormX.ModifyForm = GetType(F40151_PBTC_Msg)    '修改窗口

        'FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "添加"})
        'FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "修改"})
        'CForm.Add(FormX)

        ' ''---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "配布销数"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F40205_KUCUN_Msg)    '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources._36   '===需修改=========== 菜单图标
        'FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 1                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0

        'FormX.BillName = "配布销数"     '单据名
        'FormX.FormType = BaseFormType.Bill     '窗口类型
        ''FormX.ModifyForm = GetType(F40151_PBTC_Msg)    '修改窗口

        'FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "添加"})
        'FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "修改"})
        'CForm.Add(FormX)

        ''---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "生产配布"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F40200_SCPB)    '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources._75   '===需修改=========== 菜单图标
        'FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0

        'FormX.BillName = "生产配布单"     '单据名
        'FormX.FormType = BaseFormType.Bill '窗口类型
        'FormX.ModifyForm = GetType(F40201_SCPB_Msg)    '修改窗口

        'FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "添加"})
        'FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "修改"})
        'FormX.Right.Add(New RightTpye With {.RightName = CancelPB, .RightShow = "取消配布"})
        'FormX.Right.Add(New RightTpye With {.RightName = CanUseWNGH, .RightShow = "使用万能缸号"})
        ''FormX.Right.Add(New RightTpye With {.RightName = SetValid, .RightShow = "送货单还原"})
        ''FormX.Right.Add(New RightTpye With {.RightName = Audited, .RightShow = "送货单审核"})
        ''FormX.Right.Add(New RightTpye With {.RightName = UnAudit, .RightShow = "送货单反审"})
        'CForm.Add(FormX)


        ''---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "成品入库"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F40300_CPRK)    '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources.PeiBu   '===需修改=========== 菜单图标
        'FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0

        'FormX.BillName = "成品入库单"     '单据名
        'FormX.FormType = BaseFormType.Bill '窗口类型
        'FormX.ModifyForm = GetType(F40301_CPRK_Msg)    '修改窗口

        'FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "添加"})
        'FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "修改"})
        'FormX.Right.Add(New RightTpye With {.RightName = CancelPB, .RightShow = "取消入库"})
        ''FormX.Right.Add(New RightTpye With {.RightName = SetValid, .RightShow = "送货单还原"})
        'FormX.Right.Add(New RightTpye With {.RightName = Comfirm, .RightShow = "确认"})
        'FormX.Right.Add(New RightTpye With {.RightName = UnComfirm, .RightShow = "取消确认"})
        'FormX.Right.Add(New RightTpye With {.RightName = Audited, .RightShow = "审核"})
        'FormX.Right.Add(New RightTpye With {.RightName = UnAudit, .RightShow = "反审"})
        'CForm.Add(FormX)
        ''---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "成品期初库存"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F40310_CPIni)    '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources._181   '===需修改=========== 菜单图标
        'FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0

        'FormX.BillName = "成品期初库存"     '单据名
        'FormX.FormType = BaseFormType.Bill '窗口类型
        'FormX.ModifyForm = GetType(F40311_CPIni_Msg)    '修改窗口

        'FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "添加"})
        'FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "修改"})

        'FormX.Right.Add(New RightTpye With {.RightName = Audited, .RightShow = "审核"})
        'FormX.Right.Add(New RightTpye With {.RightName = UnAudit, .RightShow = "反审"})
        'CForm.Add(FormX)



        ''---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "半成品入库"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F40400_BCPRK)    '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources._34   '===需修改=========== 菜单图标
        'FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0

        'FormX.BillName = "半成品入库单"     '单据名
        'FormX.FormType = BaseFormType.Bill '窗口类型
        'FormX.ModifyForm = GetType(F40401_BCPRK_Msg)    '修改窗口

        'FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "添加"})
        'FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "修改"})
        'FormX.Right.Add(New RightTpye With {.RightName = CancelPB, .RightShow = "取消入库"})
        ''FormX.Right.Add(New RightTpye With {.RightName = SetValid, .RightShow = "送货单还原"})
        ''FormX.Right.Add(New RightTpye With {.RightName = Audited, .RightShow = "送货单审核"})
        ''FormX.Right.Add(New RightTpye With {.RightName = UnAudit, .RightShow = "送货单反审"})
        'CForm.Add(FormX)


        ''---------主窗口----------
        ''FormX = New DLLTpye
        ''FormX.Caption = "待处理品入库"         '===需修改=========== 窗口菜单名
        ''FormX.FormName = GetType(F40410_DCRK)    '===需修改=========== 窗口调用名
        ''FormX.Img = My.Resources._43   '===需修改=========== 菜单图标
        ''FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        ''FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        ''FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        ''FormX.DllAss_Index = 0

        ''FormX.BillName = "待处理入库单"     '单据名
        ''FormX.FormType = BaseFormType.Bill '窗口类型
        ''FormX.ModifyForm = GetType(F40411_DCRK_Msg)    '修改窗口

        ''FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "添加"})
        ''FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "修改"})
        ''FormX.Right.Add(New RightTpye With {.RightName = CancelPB, .RightShow = "取消入库"})
        ' ''FormX.Right.Add(New RightTpye With {.RightName = SetValid, .RightShow = "送货单还原"})
        ' ''FormX.Right.Add(New RightTpye With {.RightName = Audited, .RightShow = "送货单审核"})
        ' ''FormX.Right.Add(New RightTpye With {.RightName = UnAudit, .RightShow = "送货单反审"})
        ''CForm.Add(FormX)



        ''---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "仓库楼层"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F40500_Store_Map)    '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources.PBRK  '===需修改=========== 菜单图标
        'FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0

        'FormX.BillName = "仓库楼层"     '单据名
        'FormX.FormType = BaseFormType.Sel '窗口类型
        '' FormX.ModifyForm = GetType(F40201_SCPB_Msg)    '修改窗口

        'FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "添加"})
        'FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "修改"})
        'FormX.Right.Add(New RightTpye With {.RightName = Del, .RightShow = "删除"})
        ''FormX.Right.Add(New RightTpye With {.RightName = SetInValid, .RightShow = "送货单作废"})
        ''FormX.Right.Add(New RightTpye With {.RightName = SetValid, .RightShow = "送货单还原"})
        ''FormX.Right.Add(New RightTpye With {.RightName = Audited, .RightShow = "送货单审核"})
        ''FormX.Right.Add(New RightTpye With {.RightName = UnAudit, .RightShow = "送货单反审"})
        'CForm.Add(FormX)


        ''---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "仓库设计"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F40501_Map_Msg)    '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources._31   '===需修改=========== 菜单图标
        'FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0

        'FormX.BillName = "仓库设计"     '单据名
        'FormX.FormType = BaseFormType.Setting '窗口类型
        '' FormX.ModifyForm = GetType(F40201_SCPB_Msg)    '修改窗口

        'FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "添加"})
        'FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "修改"})
        'FormX.Right.Add(New RightTpye With {.RightName = Del, .RightShow = "删除"})
        ''FormX.Right.Add(New RightTpye With {.RightName = SetInValid, .RightShow = "送货单作废"})
        ''FormX.Right.Add(New RightTpye With {.RightName = SetValid, .RightShow = "送货单还原"})
        ''FormX.Right.Add(New RightTpye With {.RightName = Audited, .RightShow = "送货单审核"})
        ''FormX.Right.Add(New RightTpye With {.RightName = UnAudit, .RightShow = "送货单反审"})
        'CForm.Add(FormX)


        ''---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "送货汇总"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F40900_BZSH_Summary)   '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources._75   '===需修改=========== 菜单图标
        'FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0

        'FormX.BillName = "送货汇总"     '单据名
        'FormX.FormType = BaseFormType.Report '窗口类型
        '' FormX.ModifyForm = GetType(F40201_SCPB_Msg)    '修改窗口

        'FormX.Right.Add(New RightTpye With {.RightName = Print, .RightShow = "打印"})
        'FormX.Right.Add(New RightTpye With {.RightName = RpCanExcelOut, .RightShow = "从报表导出Excel"})

        'CForm.Add(FormX)




        ''---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "送货明细"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F40910_BZSH_Mx)    '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources.Export   '===需修改=========== 菜单图标
        'FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0

        'FormX.BillName = "送货明细"     '单据名
        'FormX.FormType = BaseFormType.Report '窗口类型
        '' FormX.ModifyForm = GetType(F40201_SCPB_Msg)    '修改窗口

        'FormX.Right.Add(New RightTpye With {.RightName = Print, .RightShow = "打印"})
        'FormX.Right.Add(New RightTpye With {.RightName = RpCanExcelOut, .RightShow = "从报表导出Excel"})


        'CForm.Add(FormX)


        ''---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "配布明细"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F40920_PBDay)    '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources.file_temp   '===需修改=========== 菜单图标
        'FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0

        'FormX.BillName = "配布明细"     '单据名
        'FormX.FormType = BaseFormType.Report '窗口类型
        '' FormX.ModifyForm = GetType(F40201_SCPB_Msg)    '修改窗口

        'FormX.Right.Add(New RightTpye With {.RightName = Print, .RightShow = "打印"})
        'FormX.Right.Add(New RightTpye With {.RightName = RpCanExcelOut, .RightShow = "从报表导出Excel"})

        'CForm.Add(FormX)

        ''---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "入库明细"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F40930_CPDay)    '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources.file_temp   '===需修改=========== 菜单图标
        'FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0

        'FormX.BillName = "入库明细"     '单据名
        'FormX.FormType = BaseFormType.Report '窗口类型
        '' FormX.ModifyForm = GetType(F40201_SCPB_Msg)    '修改窗口

        'FormX.Right.Add(New RightTpye With {.RightName = Print, .RightShow = "打印"})
        'FormX.Right.Add(New RightTpye With {.RightName = RpCanExcelOut, .RightShow = "从报表导出Excel"})

        'CForm.Add(FormX)

        ''---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "汽车送货汇总"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F40940_QCSH_Summary)   '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources._75   '===需修改=========== 菜单图标
        'FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0

        'FormX.BillName = "汽车送货汇总"     '单据名
        'FormX.FormType = BaseFormType.Report '窗口类型
        '' FormX.ModifyForm = GetType(F40201_SCPB_Msg)    '修改窗口


        'FormX.Right.Add(New RightTpye With {.RightName = Print, .RightShow = "打印"})

        'FormX.Right.Add(New RightTpye With {.RightName = RpCanExcelOut, .RightShow = "从报表导出Excel"})
        'CForm.Add(FormX)




        ''---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "仓位对照"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F40203_PBStore)   '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources.Word   '===需修改=========== 菜单图标
        'FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0

        'FormX.BillName = "仓位对照"     '单据名
        'FormX.FormType = BaseFormType.Report '窗口类型
        '' FormX.ModifyForm = GetType(F40201_SCPB_Msg)    '修改窗口
        'FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "添加"})
        'FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "修改"})
        'FormX.Right.Add(New RightTpye With {.RightName = Print, .RightShow = "打印"})
        'FormX.Right.Add(New RightTpye With {.RightName = RpCanExcelOut, .RightShow = "从报表导出Excel"})
        'CForm.Add(FormX)











        ''---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "胚布进出"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F40950_PB_INOUT)    '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources.PBRK   '===需修改=========== 菜单图标
        'FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0

        'FormX.BillName = "胚布进出"     '单据名
        'FormX.FormType = BaseFormType.Report '窗口类型
        ''FormX.ModifyForm = GetType(F40951_PB_INOUT_Msg)    '修改窗口


        'FormX.Right.Add(New RightTpye With {.RightName = RpCanExcelOut, .RightShow = "从报表导出Excel"})
        'CForm.Add(FormX)


        'FormX = New DLLTpye
        'FormX.Caption = "胚布进出明细"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F40951_PB_INOUT_Msg)    '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources._181   '===需修改=========== 菜单图标
        'FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0

        'FormX.BillName = "胚布进出明细"     '单据名
        'FormX.FormType = BaseFormType.Report '窗口类型
        '' FormX.ModifyForm = GetType(F40201_SCPB_Msg)    '修改窗口


        'FormX.Right.Add(New RightTpye With {.RightName = RpCanExcelOut, .RightShow = "从报表导出Excel"})
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