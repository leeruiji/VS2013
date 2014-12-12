Imports PClass.PClass
Imports System.Drawing

Public Class ClassMain

#Region "权限常量"
    Public Const Add As String = "Add"
    Public Const Modify As String = "Modify"
    Public Const Del As String = "Del"
    Public Const Right_Modify As String = "Right_Modify"
    Public Const FileOut As String = "FileOut"
    Public Const ShowPrice As String = "ShowPrice"
    Public Const PeiBu As String = "PeiBu"

    Public Const SetInValid As String = "SetInValid"
    Public Const SetValid As String = "SetValid"
    'Public Const ComfirmStoreInOrOut As String = "ComfirmStoreInOrOut"
    Public Const Audited As String = "Audited"
    Public Const UnAudit As String = "UnAudit"
    Public Const Print As String = "Print"
    Public Const Preview As String = "Preview"
    'Public Const SetReport As String = "SetReport"
    'Public Const ShowProfit As String = "ShowProfit"
    '运转单权限
    Public Const LuoDan As String = "LuoDan"
    Public Const LuoDan_Cancel As String = "LuoDan_Cancel"
    Public Const CanEdit As String = "CanEdit"
    Public Const JiaJi As String = "JiaJi"
    Public Const UnJiaJi As String = "UnJiaJi"
    Public Const TZPB As String = "TZPB"
    Public Const NoComFirm As String = "NoComFirmPrice"

    Public Const ChangePB As String = "ChangePB"
    Public Const ChangeColor As String = "ChangeColor"  '改色
    Public Const CaiGang As String = "CaiGang"
    Public Const HeGang As String = "HeGang"
    Public Const CanExcelOut As String = "CanExcelOut"
    Public Const RpCanExcelOut As String = "RPCanExcelOut"
    ''' <summary>
    ''' 确认配布
    ''' </summary>
    ''' <remarks></remarks>
    Public Const PeiBu_Comfirm As String = "PeiBu_Comfirm"
    ''' <summary>
    ''' 取消配布
    ''' </summary>
    ''' <remarks></remarks>
    Public Const PeiBu_Cancel As String = "PeiBu_Cancel"
    ''' <summary>
    ''' 返定
    ''' </summary>
    ''' <remarks></remarks>
    Public Const FD As String = "FD"
    ''' <summary>
    ''' 退胚
    ''' </summary>
    ''' <remarks></remarks>
    Public Const TP As String = "TP"
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
        'MenuX.ID = 30                   '===需修改=========== 菜单ID
        'MenuX.Caption = "生产资料"      '===需修改=========== 菜单名
        'CMenuX.Add(MenuX)

        ' ''---------主模块------------
        'ModuleX = New MainModuleTpye
        'ModuleX.ID = 300                   '===需修改=========== 模块ID
        'ModuleX.Caption = "运转单"      '===需修改=========== 模块名
        'CModule.Add(ModuleX)

        ' ''---------主模块------------
        'ModuleX = New MainModuleTpye
        'ModuleX.ID = 301                   '===需修改=========== 模块ID
        'ModuleX.Caption = "进度表"      '===需修改=========== 模块名
        'CModule.Add(ModuleX)

        ' ''---------主模块------------
        'ModuleX = New MainModuleTpye
        'ModuleX.ID = 302                   '===需修改=========== 模块ID
        'ModuleX.Caption = "质检部"      '===需修改=========== 模块名
        'CModule.Add(ModuleX)

        ' ''---------主模块------------
        'ModuleX = New MainModuleTpye
        'ModuleX.ID = 309                  '===需修改=========== 模块ID
        'ModuleX.Caption = "报表"      '===需修改=========== 模块名
        'CModule.Add(ModuleX)

        ''---------主窗口----------
        ''FormX = New DLLTpye
        ''FormX.Caption = "运转单"         '===需修改=========== 窗口菜单名
        ''FormX.FormName = "F30000_Produce"    '===需修改=========== 窗口调用名
        ''FormX.Img = My.Resources.Produce       '===需修改=========== 菜单图标
        ''FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        ''FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        ''FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        ''FormX.DllAss_Index = 0
        ''FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "添加"})
        ''FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "修改"})
        ''FormX.Right.Add(New RightTpye With {.RightName = Del, .RightShow = "删除"})
        ''CForm.Add(FormX)


        ''---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = Dao.Produce_Gd_Name       '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F30000_Produce_Gd)    '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources.Produce       '===需修改=========== 菜单图标
        'FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0

        'FormX.BillName = "运转单"     '单据名
        'FormX.FormType = BaseFormType.Bill '窗口类型
        'FormX.ModifyForm = GetType(F30001_Produce_Gd_Msg)    '修改窗口

        'FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "添加"})
        'FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "修改"})
        'FormX.Right.Add(New RightTpye With {.RightName = Del, .RightShow = "删除"})

        'FormX.Right.Add(New RightTpye With {.RightName = Print, .RightShow = "打印"})
        'FormX.Right.Add(New RightTpye With {.RightName = SetInValid, .RightShow = "作废"})
        'FormX.Right.Add(New RightTpye With {.RightName = SetValid, .RightShow = "还原"})
        'FormX.Right.Add(New RightTpye With {.RightName = ShowPrice, .RightShow = "显示金额"})


        'FormX.Right.Add(New RightTpye With {.RightName = ChangePB, .RightShow = "转移"})
        'FormX.Right.Add(New RightTpye With {.RightName = ChangeColor, .RightShow = "改色"})

        'FormX.Right.Add(New RightTpye With {.RightName = FD, .RightShow = "返定"})
        'FormX.Right.Add(New RightTpye With {.RightName = TP, .RightShow = "退胚"})
        'FormX.Right.Add(New RightTpye With {.RightName = NoComFirm, .RightShow = "没确认单价色号"})
        'FormX.Right.Add(New RightTpye With {.RightName = CaiGang, .RightShow = "拆缸"})
        'FormX.Right.Add(New RightTpye With {.RightName = HeGang, .RightShow = "合缸"})
        'FormX.Right.Add(New RightTpye With {.RightName = CanExcelOut, .RightShow = "从列表导出Excel"})
        'FormX.Right.Add(New RightTpye With {.RightName = RpCanExcelOut, .RightShow = "从报表导出Excel"})

        ''FormX.Right.Add(New RightTpye With {.RightName = PeiBu_Cancel, .RightShow = "取消配布"})

        'CForm.Add(FormX)

        ''---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = Dao.PG_Gd_Name        '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F30104_PG)    '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources.Produce       '===需修改=========== 菜单图标
        'FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0

        'FormX.BillName = "排缸单"     '单据名
        'FormX.FormType = BaseFormType.Bill '窗口类型
        'FormX.ModifyForm = GetType(F30105_PG_Msg)    '修改窗口
        'FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "修改"})
        'FormX.Right.Add(New RightTpye With {.RightName = Print, .RightShow = "打印"})


        'CForm.Add(FormX)

        ''---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = Dao.Process_DB_NAME        '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F30100_Process)    '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources.paste        '===需修改=========== 菜单图标
        'FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0

        'FormX.BillName = Dao.Process_DB_NAME     '单据名
        'FormX.FormType = BaseFormType.Other '窗口类型
        '' FormX.ModifyForm = GetType(F30001_Produce_Gd_Msg)    '修改窗口

        'FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "添加"})
        'FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "修改"})
        'FormX.Right.Add(New RightTpye With {.RightName = Del, .RightShow = "删除"})

        'FormX.Right.Add(New RightTpye With {.RightName = Print, .RightShow = "打印"})
        'FormX.Right.Add(New RightTpye With {.RightName = JiaJi, .RightShow = "加急"})
        'FormX.Right.Add(New RightTpye With {.RightName = UnJiaJi, .RightShow = "取消加急"})
        'FormX.Right.Add(New RightTpye With {.RightName = CanEdit, .RightShow = "编辑状态"})
        'FormX.Right.Add(New RightTpye With {.RightName = CanExcelOut, .RightShow = "从列表导出Excel"})
        'FormX.Right.Add(New RightTpye With {.RightName = RpCanExcelOut, .RightShow = "从报表导出Excel"})


        ''FormX.Right.Add(New RightTpye With {.RightName = PeiBu, .RightShow = "配布确定"})
        'CForm.Add(FormX)



        ''---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "预定确定"        '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F30101_Produce_Msg)    '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources._38        '===需修改=========== 菜单图标
        'FormX.ID = 30101
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0
        'FormX.BillName = "预定确定"     '单据名
        'FormX.FormType = BaseFormType.Other '窗口类型
        'FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "预定确定"})
        'CForm.Add(FormX)



        ''---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "染色确定"       '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F30101_Produce_Msg)    '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources._87        '===需修改=========== 菜单图标
        'FormX.ID = 30102
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0
        'FormX.BillName = "染色确定"     '单据名
        'FormX.FormType = BaseFormType.Other '窗口类型
        'FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "染色确定"})
        'CForm.Add(FormX)



        ''---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "定型确定"        '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F30101_Produce_Msg)    '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources._52        '===需修改=========== 菜单图标
        'FormX.ID = 30103
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0
        'FormX.BillName = "定型确定"     '单据名
        'FormX.FormType = BaseFormType.Other '窗口类型
        'FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "定型确定"})
        'CForm.Add(FormX)

        ''---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "定型工艺"        '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F30110_DProcess)    '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources._52        '===需修改=========== 菜单图标
        'FormX.ID = 30110
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0
        'FormX.BillName = "定型工艺"     '单据名
        'FormX.FormType = BaseFormType.Other '窗口类型
        'FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "添加"})
        'FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "修改"})
        'FormX.Right.Add(New RightTpye With {.RightName = Del, .RightShow = "删除"})
        'FormX.Right.Add(New RightTpye With {.RightName = CanExcelOut, .RightShow = "从列表导出Excel"})
        'FormX.Right.Add(New RightTpye With {.RightName = RpCanExcelOut, .RightShow = "从报表导出Excel"})

        'CForm.Add(FormX)

        ''---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = Dao.KF_DB_NAME        '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F30112_KF)    '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources._52        '===需修改=========== 菜单图标
        'FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0
        'FormX.BillName = "开幅工艺"     '单据名
        'FormX.FormType = BaseFormType.Other '窗口类型
        'FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "添加"})
        'FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "修改"})
        'FormX.Right.Add(New RightTpye With {.RightName = Del, .RightShow = "删除"})
        'FormX.Right.Add(New RightTpye With {.RightName = CanExcelOut, .RightShow = "从列表导出Excel"})
        'FormX.Right.Add(New RightTpye With {.RightName = RpCanExcelOut, .RightShow = "从报表导出Excel"})

        'CForm.Add(FormX)


        ''---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "色布重量"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F30200_CPZL)   '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources._74   '===需修改=========== 菜单图标
        'FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0

        'FormX.BillName = "色布重量录入单"     '单据名
        'FormX.FormType = BaseFormType.Bill '窗口类型
        'FormX.ModifyForm = GetType(F30201_CPZL_Msg)    '修改窗口

        'FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "添加"})
        'FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "修改"})
        'FormX.Right.Add(New RightTpye With {.RightName = TZPB, .RightShow = "改重"})
        ''FormX.Right.Add(New RightTpye With {.RightName = SetValid, .RightShow = "送货单还原"})
        ''FormX.Right.Add(New RightTpye With {.RightName = Audited, .RightShow = "送货单审核"})
        ''FormX.Right.Add(New RightTpye With {.RightName = UnAudit, .RightShow = "送货单反审"})
        'CForm.Add(FormX)


        ''---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "电子称录入"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F30202_CPZL_Input)   '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources._83  '===需修改=========== 菜单图标
        'FormX.ID = 30202
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0

        'FormX.BillName = "电子称录入"     '单据名
        'FormX.FormType = BaseFormType.Other '窗口类型
        'FormX.ModifyForm = GetType(F30202_CPZL_Input)    '修改窗口
        'CForm.Add(FormX)



        ''---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "染部日报表"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F30206_DayReport)   '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources.contact_list    '===需修改=========== 菜单图标
        'FormX.ID = 30206
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0

        'FormX.BillName = "染部日报表"     '单据名
        'FormX.FormType = BaseFormType.Other '窗口类型
        'FormX.ModifyForm = GetType(F30207_DayReport_Msg)    '修改窗口


        'FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "添加"})
        'FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "修改"})
        'FormX.Right.Add(New RightTpye With {.RightName = Del, .RightShow = "删除"})
        'FormX.Right.Add(New RightTpye With {.RightName = Audited, .RightShow = "审核"})
        'FormX.Right.Add(New RightTpye With {.RightName = UnAudit, .RightShow = "反审"})
        'FormX.Right.Add(New RightTpye With {.RightName = SetInValid, .RightShow = "作废"})
        'FormX.Right.Add(New RightTpye With {.RightName = SetValid, .RightShow = "还原"})
        'FormX.Right.Add(New RightTpye With {.RightName = Print, .RightShow = "打印"})
        'FormX.Right.Add(New RightTpye With {.RightName = Preview, .RightShow = "预览"})
        'CForm.Add(FormX)


        ''---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "定型部日报表"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F30206_DayReport)   '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources.credit_card    '===需修改=========== 菜单图标
        'FormX.ID = 30208
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0

        'FormX.BillName = "定型部日报表"     '单据名
        'FormX.FormType = BaseFormType.Other '窗口类型
        'FormX.ModifyForm = GetType(F30207_DayReport_Msg)    '修改窗口

        'FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "添加"})
        'FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "修改"})
        'FormX.Right.Add(New RightTpye With {.RightName = Del, .RightShow = "删除"})
        'FormX.Right.Add(New RightTpye With {.RightName = Audited, .RightShow = "审核"})
        'FormX.Right.Add(New RightTpye With {.RightName = UnAudit, .RightShow = "反审"})
        'FormX.Right.Add(New RightTpye With {.RightName = SetInValid, .RightShow = "作废"})
        'FormX.Right.Add(New RightTpye With {.RightName = SetValid, .RightShow = "还原"})
        'FormX.Right.Add(New RightTpye With {.RightName = Print, .RightShow = "打印"})
        'FormX.Right.Add(New RightTpye With {.RightName = Preview, .RightShow = "预览"})
        'CForm.Add(FormX)

        ''---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "质量日报表"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F30220_QualityDayReport)   '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources._18   '===需修改=========== 菜单图标
        'FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0
        'FormX.BillName = "质量日报表"     '单据名
        'FormX.FormType = BaseFormType.Other '窗口类型
        'FormX.ModifyForm = GetType(F30221_QualityDayReport_Msg)    '修改窗口

        'FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "添加"})
        'FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "修改"})
        'FormX.Right.Add(New RightTpye With {.RightName = Del, .RightShow = "删除"})
        'FormX.Right.Add(New RightTpye With {.RightName = Audited, .RightShow = "审核"})
        'FormX.Right.Add(New RightTpye With {.RightName = UnAudit, .RightShow = "反审"})
        'FormX.Right.Add(New RightTpye With {.RightName = SetInValid, .RightShow = "作废"})
        'FormX.Right.Add(New RightTpye With {.RightName = SetValid, .RightShow = "还原"})
        'FormX.Right.Add(New RightTpye With {.RightName = Print, .RightShow = "打印"})
        'FormX.Right.Add(New RightTpye With {.RightName = Preview, .RightShow = "预览"})

        'CForm.Add(FormX)


        ''---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "补布申请单"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F30225_Applique)     '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources._25     '===需修改=========== 菜单图标
        'FormX.ID = 30228
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0
        ''单据名称
        ''类型,单据,基础,设置,报表
        ''F30225_Applique_Msg
        'FormX.BillName = "补布申请单"     '单据名
        'FormX.FormType = BaseFormType.Bill '窗口类型
        'FormX.ModifyForm = GetType(F30226_Applique_Msg)    '修改窗口
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
        'FormX.Caption = "改黑申请单"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F30227_GHSQ)     '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources._22      '===需修改=========== 菜单图标
        'FormX.ID = 30230
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0
        ''单据名称
        ''类型,单据,基础,设置,报表
        ''F30225_Applique_Msg
        'FormX.BillName = "改黑申请单"     '单据名
        'FormX.FormType = BaseFormType.Bill '窗口类型
        'FormX.ModifyForm = GetType(F30228_GHSQ_Msg)    '修改窗口
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
        'FormX.Caption = "改色申请单"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F30229_GSSQ)     '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources._22      '===需修改=========== 菜单图标
        'FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0
        'FormX.BillName = "改色申请单"     '单据名
        'FormX.FormType = BaseFormType.Bill '窗口类型
        'FormX.ModifyForm = GetType(F30230_GSSQ_Msg)    '修改窗口
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
        'FormX.Caption = "回修通知单"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F30231_RetrunInform)     '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources._18     '===需修改=========== 菜单图标
        'FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0
        'FormX.BillName = "回修通知单"     '单据名
        'FormX.FormType = BaseFormType.Bill '窗口类型
        'FormX.ModifyForm = GetType(F30232_RetrunInform_Msg)    '修改窗口
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
        'FormX.Caption = "落色汇总"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F30900_LuoSe_DaySummary)    '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources._8        '===需修改=========== 菜单图标
        'FormX.ID = 30900
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0

        'FormX.BillName = "落色汇总"     '单据名
        'FormX.FormType = BaseFormType.Report '窗口类型
        ''FormX.ModifyForm = GetType(F30001_Produce_Gd_Msg)    '修改窗口

        'FormX.Right.Add(New RightTpye With {.RightName = Print, .RightShow = "打印"})

        'FormX.Right.Add(New RightTpye With {.RightName = RpCanExcelOut, .RightShow = "从报表导出Excel"})


        'CForm.Add(FormX)

        ''---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "能耗表"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F30920_Energy)    '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources.file_chart        '===需修改=========== 菜单图标
        'FormX.ID = 30920
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0

        'FormX.BillName = "能耗表"     '单据名
        'FormX.FormType = BaseFormType.Report '窗口类型
        ''FormX.ModifyForm = GetType(F30001_Produce_Gd_Msg)    '修改窗口

        'FormX.Right.Add(New RightTpye With {.RightName = Print, .RightShow = "打印"})
        'FormX.Right.Add(New RightTpye With {.RightName = Audited, .RightShow = "审核"})
        'FormX.Right.Add(New RightTpye With {.RightName = UnAudit, .RightShow = "反审"})

        'FormX.Right.Add(New RightTpye With {.RightName = RpCanExcelOut, .RightShow = "从报表导出Excel"})


        'CForm.Add(FormX)


        ''---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "胚布修改统计表"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F30930_PB_Match)    '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources.credit_card         '===需修改=========== 菜单图标
        'FormX.ID = 30930
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0

        'FormX.BillName = "胚布修改统计表"     '单据名
        'FormX.FormType = BaseFormType.Report '窗口类型
        ''FormX.ModifyForm = GetType(F30001_Produce_Gd_Msg)    '修改窗口

        'FormX.Right.Add(New RightTpye With {.RightName = Print, .RightShow = "打印"})

        'FormX.Right.Add(New RightTpye With {.RightName = RpCanExcelOut, .RightShow = "从报表导出Excel"})

        'CForm.Add(FormX)

        ''---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "改色统计表"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F30940_GS_Count)    '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources.credit_card         '===需修改=========== 菜单图标
        'FormX.ID = 30940
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0

        'FormX.BillName = "改色统计表"     '单据名
        'FormX.FormType = BaseFormType.Report '窗口类型
        ''FormX.ModifyForm = GetType(F30001_Produce_Gd_Msg)    '修改窗口

        'FormX.Right.Add(New RightTpye With {.RightName = Print, .RightShow = "打印"})

        'FormX.Right.Add(New RightTpye With {.RightName = RpCanExcelOut, .RightShow = "从报表导出Excel"})

        'CForm.Add(FormX)

        ''---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "损耗表"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F30950_LossEnergy)    '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources.credit_card         '===需修改=========== 菜单图标
        'FormX.ID = 30950
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0

        'FormX.BillName = "损耗表"     '单据名
        'FormX.FormType = BaseFormType.Report '窗口类型
        ''FormX.ModifyForm = GetType(F30001_Produce_Gd_Msg)    '修改窗口

        'FormX.Right.Add(New RightTpye With {.RightName = Print, .RightShow = "打印"})

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