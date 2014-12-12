Imports PClass.PClass
Imports System.Drawing

Public Class ClassMain

#Region "权限常量"
    Public Const Add As String = "Add"
    Public Const Modify As String = "Modify"
    Public Const Del As String = "Del"

    Public Const ShowPrice As String = "ShowPrice"
    Public Const ModifyPrice As String = "ModifyPrice"
    Public Const Price As String = "Price"
    Public Const CreateDan As String = "CreateDan"
    Public Const ConfirmDeliveryDate As String = "ConfirmDeliveryDate"
    Public Const UnConfirmDeliveryDate As String = "UnConfirmDeliveryDate"


    Public Const Right_Modify As String = "Right_Modify"
    Public Const FileOut As String = "FileOut"
    Public Const LuoDan As String = "LuoDan"
    Public Const SetInValid As String = "SetInValid"
    Public Const SetValid As String = "SetValid"
    Public Const Rebuild As String = "Rebuild"
    Public Const Confirm As String = "Confirm"
    Public Const UnConfirm As String = "UnConfirm"
    'Public Const ComfirmStoreInOrOut As String = "ComfirmStoreInOrOut"
    Public Const Audited As String = "Audited"
    Public Const UnAudit As String = "UnAudit"
    Public Const Print As String = "Print"

    Public Const Confirm_Qty As String = "Confirm_Qty"

    Public Const JiaLiao As String = "JiaLiao"
    Public Const ShowJiaLiao As String = "ShowJiaLiao"
    Public Const PrintMore As String = "PrintMore"
    'Public Const SetReport As String = "SetReport"
    'Public Const ShowProfit As String = "ShowProfit"
    Public Const ReportRemark As String = "ReportRemark"
    '进度表权限
    Public Const CanEdit As String = "CanEdit"
    Public Const CanExcelOut As String = "CanExcelOut"
    Public Const RpCanExcelOut As String = "RPCanExcelOut"

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
        MenuX.ID = 27                   '===需修改=========== 菜单ID
        MenuX.Caption = "业务管理"      '===需修改=========== 菜单名
        CMenuX.Add(MenuX)

        ''---------主模块------------
        ModuleX = New MainModuleTpye
        ModuleX.ID = 270                   '===需修改=========== 模块ID
        ModuleX.Caption = "订单管理"      '===需修改=========== 模块名
        CModule.Add(ModuleX)

        ''---------主模块------------
        ModuleX = New MainModuleTpye
        ModuleX.ID = 271                   '===需修改=========== 模块ID
        ModuleX.Caption = "生产管理"      '===需修改=========== 模块名
        CModule.Add(ModuleX)

        ''---------主模块------------
        ModuleX = New MainModuleTpye
        ModuleX.ID = 272                   '===需修改=========== 模块ID
        ModuleX.Caption = "送货管理"      '===需修改=========== 模块名
        CModule.Add(ModuleX)


        ''---------主模块------------
        ModuleX = New MainModuleTpye
        ModuleX.ID = 273                  '===需修改=========== 模块ID
        ModuleX.Caption = "报表"      '===需修改=========== 模块名
        CModule.Add(ModuleX)



        '---------主窗口----------
        FormX = New DLLTpye
        FormX.Caption = "客户订单"         '===需修改=========== 窗口菜单名
        FormX.FormName = GetType(F27000_ClientOrder)    '===需修改=========== 窗口调用名
        FormX.Img = My.Resources._43     '===需修改=========== 菜单图标
        FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        FormX.DllAss_Index = 0

        FormX.BillName = "客户订单"     '单据名
        FormX.FormType = BaseFormType.Bill '窗口类型
        FormX.ModifyForm = GetType(F27001_ClientOrder_Msg)    '修改窗口

        FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "添加"})
        FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "修改"})
        FormX.Right.Add(New RightTpye With {.RightName = Del, .RightShow = "删除"})

        FormX.Right.Add(New RightTpye With {.RightName = SetInValid, .RightShow = "作废"})
        FormX.Right.Add(New RightTpye With {.RightName = SetValid, .RightShow = "还原"})
        FormX.Right.Add(New RightTpye With {.RightName = Audited, .RightShow = "审核"})
        FormX.Right.Add(New RightTpye With {.RightName = UnAudit, .RightShow = "反审"})
        FormX.Right.Add(New RightTpye With {.RightName = CreateDan, .RightShow = "生成单据"})
        FormX.Right.Add(New RightTpye With {.RightName = ConfirmDeliveryDate, .RightShow = "确认送货日期"})
        FormX.Right.Add(New RightTpye With {.RightName = UnConfirmDeliveryDate, .RightShow = "反确认送货日期"})
        'FormX.Right.Add(New RightTpye With {.RightName = ShowPrice, .RightShow = "显示价钱"})
        'FormX.Right.Add(New RightTpye With {.RightName = ModifyPrice, .RightShow = "修改价钱"})
        CForm.Add(FormX)

        ''---------主窗口----------
        FormX = New DLLTpye
        FormX.Caption = "生产进度表"       '===需修改=========== 窗口菜单名
        FormX.FormName = GetType(F27100_Process)    '===需修改=========== 窗口调用名
        FormX.Img = My.Resources.paste        '===需修改=========== 菜单图标
        FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        FormX.DllAss_Index = 0

        FormX.BillName = "生产进度表"      '单据名
        FormX.FormType = BaseFormType.Other '窗口类型
        ' FormX.ModifyForm = GetType(F30001_Produce_Gd_Msg)    '修改窗口

        FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "添加"})
        FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "修改"})
        FormX.Right.Add(New RightTpye With {.RightName = Del, .RightShow = "删除"})

        FormX.Right.Add(New RightTpye With {.RightName = Print, .RightShow = "打印"})
        FormX.Right.Add(New RightTpye With {.RightName = CanEdit, .RightShow = "编辑状态"})
        FormX.Right.Add(New RightTpye With {.RightName = CanExcelOut, .RightShow = "从列表导出Excel"})
        FormX.Right.Add(New RightTpye With {.RightName = RpCanExcelOut, .RightShow = "从报表导出Excel"})
        CForm.Add(FormX)

        FormX = New DLLTpye
        FormX.Caption = "生产指令单"         '===需修改=========== 窗口菜单名
        FormX.FormName = GetType(F27110_ProduceOrder)    '===需修改=========== 窗口调用名
        FormX.Img = My.Resources._43     '===需修改=========== 菜单图标
        FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        FormX.DllAss_Index = 0

        FormX.BillName = "生产指令单"     '单据名
        FormX.FormType = BaseFormType.Bill '窗口类型
        FormX.ModifyForm = GetType(F27111_ProduceOrder_Msg)    '修改窗口

        FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "添加"})
        FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "修改"})
        FormX.Right.Add(New RightTpye With {.RightName = Del, .RightShow = "删除"})

        FormX.Right.Add(New RightTpye With {.RightName = SetInValid, .RightShow = "作废"})
        FormX.Right.Add(New RightTpye With {.RightName = SetValid, .RightShow = "还原"})
        FormX.Right.Add(New RightTpye With {.RightName = Audited, .RightShow = "审核"})
        FormX.Right.Add(New RightTpye With {.RightName = UnAudit, .RightShow = "反审"})

        FormX.Right.Add(New RightTpye With {.RightName = UnAudit, .RightShow = "确定"})
        FormX.Right.Add(New RightTpye With {.RightName = UnAudit, .RightShow = "不确定"})

        'FormX.Right.Add(New RightTpye With {.RightName = ShowPrice, .RightShow = "显示价钱"})
        'FormX.Right.Add(New RightTpye With {.RightName = ModifyPrice, .RightShow = "修改价钱"})
        CForm.Add(FormX)


        FormX = New DLLTpye
        FormX.Caption = "生产排期单"         '===需修改=========== 窗口菜单名
        FormX.FormName = GetType(F27120_Schedule)    '===需修改=========== 窗口调用名
        FormX.Img = My.Resources._43     '===需修改=========== 菜单图标
        FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        FormX.DllAss_Index = 0

        FormX.BillName = "生产排期单"     '单据名
        FormX.FormType = BaseFormType.Bill '窗口类型
        FormX.ModifyForm = GetType(F27121_Schedule_Msg)    '修改窗口

        FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "添加"})
        FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "修改"})
        FormX.Right.Add(New RightTpye With {.RightName = Del, .RightShow = "删除"})

        FormX.Right.Add(New RightTpye With {.RightName = SetInValid, .RightShow = "作废"})
        FormX.Right.Add(New RightTpye With {.RightName = SetValid, .RightShow = "还原"})
        FormX.Right.Add(New RightTpye With {.RightName = Audited, .RightShow = "审核"})
        FormX.Right.Add(New RightTpye With {.RightName = UnAudit, .RightShow = "反审"})

        CForm.Add(FormX)

        ''    ---------主窗口----------
        FormX = New DLLTpye
        FormX.Caption = "装配指令单"         '===需修改=========== 窗口菜单名
        FormX.FormName = GetType(F27130_AssembleOrder)    '===需修改=========== 窗口调用名
        FormX.Img = My.Resources._43     '===需修改=========== 菜单图标
        FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        FormX.DllAss_Index = 0

        FormX.BillName = "装配指令单"     '单据名
        FormX.FormType = BaseFormType.Bill '窗口类型
        FormX.ModifyForm = GetType(F27131_AssembleOrder_Msg)    '修改窗口

        FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "添加"})
        FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "修改"})
        FormX.Right.Add(New RightTpye With {.RightName = Del, .RightShow = "删除"})

        FormX.Right.Add(New RightTpye With {.RightName = SetInValid, .RightShow = "作废"})
        FormX.Right.Add(New RightTpye With {.RightName = SetValid, .RightShow = "还原"})
        FormX.Right.Add(New RightTpye With {.RightName = Audited, .RightShow = "审核"})
        FormX.Right.Add(New RightTpye With {.RightName = UnAudit, .RightShow = "反审"})
        CForm.Add(FormX)




        ''    ---------主窗口----------
        FormX = New DLLTpye
        FormX.Caption = "送货单"         '===需修改=========== 窗口菜单名
        FormX.FormName = GetType(F27200_Delivery)    '===需修改=========== 窗口调用名
        FormX.Img = My.Resources._12  '===需修改=========== 菜单图标
        FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        FormX.IsShow = True                 '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        FormX.DllAss_Index = 0

        FormX.BillName = "送货单"     '单据名
        FormX.FormType = BaseFormType.Bill '窗口类型
        FormX.ModifyForm = GetType(F27201_Delivery_Msg)    '修改窗口

        FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "添加"})
        FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "修改"})
        FormX.Right.Add(New RightTpye With {.RightName = Del, .RightShow = "删除"})
        FormX.Right.Add(New RightTpye With {.RightName = SetInValid, .RightShow = "作废"})
        FormX.Right.Add(New RightTpye With {.RightName = SetValid, .RightShow = "还原"})
        FormX.Right.Add(New RightTpye With {.RightName = Audited, .RightShow = "审核"})
        FormX.Right.Add(New RightTpye With {.RightName = UnAudit, .RightShow = "反审"})
        FormX.Right.Add(New RightTpye With {.RightName = Confirm, .RightShow = "确定"})
        FormX.Right.Add(New RightTpye With {.RightName = UnConfirm, .RightShow = "反确定"})

        CForm.Add(FormX)


        ''    ---------主窗口----------
        FormX = New DLLTpye
        FormX.Caption = "退货单"         '===需修改=========== 窗口菜单名
        FormX.FormName = GetType(F27210_ReturnGoods)    '===需修改=========== 窗口调用名
        FormX.Img = My.Resources._12  '===需修改=========== 菜单图标
        FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        FormX.IsShow = True                 '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        FormX.DllAss_Index = 0

        FormX.BillName = "退货单"     '单据名
        FormX.FormType = BaseFormType.Bill '窗口类型
        FormX.ModifyForm = GetType(F27211_ReturnGoods_Msg)    '修改窗口

        FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "添加"})
        FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "修改"})
        FormX.Right.Add(New RightTpye With {.RightName = Del, .RightShow = "删除"})
        FormX.Right.Add(New RightTpye With {.RightName = SetInValid, .RightShow = "作废"})
        FormX.Right.Add(New RightTpye With {.RightName = SetValid, .RightShow = "还原"})
        FormX.Right.Add(New RightTpye With {.RightName = Audited, .RightShow = "审核"})
        FormX.Right.Add(New RightTpye With {.RightName = UnAudit, .RightShow = "反审"})
        FormX.Right.Add(New RightTpye With {.RightName = Confirm, .RightShow = "确定"})
        FormX.Right.Add(New RightTpye With {.RightName = UnConfirm, .RightShow = "反确定"})
        CForm.Add(FormX)


        ''    ---------主窗口----------
        FormX = New DLLTpye
        FormX.Caption = "生产领料单"         '===需修改=========== 窗口菜单名
        FormX.FormName = GetType(F27140_ProLiLiao)    '===需修改=========== 窗口调用名
        FormX.Img = My.Resources._43     '===需修改=========== 菜单图标
        FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        FormX.DllAss_Index = 0

        FormX.BillName = "生产领料单"     '单据名
        FormX.FormType = BaseFormType.Bill '窗口类型
        FormX.ModifyForm = GetType(F27141_ProLiLiao_Msg)    '修改窗口

        FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "添加"})
        FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "修改"})
        FormX.Right.Add(New RightTpye With {.RightName = Del, .RightShow = "删除"})

        FormX.Right.Add(New RightTpye With {.RightName = Confirm_Qty, .RightShow = "发货数量"})
       
        FormX.Right.Add(New RightTpye With {.RightName = SetInValid, .RightShow = "作废"})
        FormX.Right.Add(New RightTpye With {.RightName = SetValid, .RightShow = "还原"})
        FormX.Right.Add(New RightTpye With {.RightName = Audited, .RightShow = "审核"})
        FormX.Right.Add(New RightTpye With {.RightName = UnAudit, .RightShow = "反审"})
        CForm.Add(FormX)



        '---------主窗口----------
        FormX = New DLLTpye
        FormX.Caption = "备货明细表"         '===需修改=========== 窗口菜单名
        FormX.FormName = GetType(F27300_BH_List)    '===需修改=========== 窗口调用名
        FormX.Img = My.Resources.BZC       '===需修改=========== 菜单图标
        FormX.ID = 27300
        FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        FormX.DllAss_Index = 0

        FormX.BillName = "备货明细表"     '单据名
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