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
    Public Const SetInValid As String = "SetInValid"
    Public Const SetValid As String = "SetValid"
    Public Const ReNew As String = "ReNew"
    'Public Const ComfirmStoreInOrOut As String = "ComfirmStoreInOrOut"
    Public Const Audited As String = "Audited"
    Public Const UnAudit As String = "UnAudit"
    'Public Const Print As String = "Print"
    'Public Const SetReport As String = "SetReport"
    'Public Const ShowProfit As String = "ShowProfit"
    Public Const Combine As String = "Combine" '布种合并
    Public Const AddGroup As String = "AddGroup"
    Public Const DelGroup As String = "DelGroup"
    Public Const Invoid As String = "Invoid"
    Public Const UnInvoid As String = "UnInvoid"
    Public Const Lock As String = "Lock"
    Public Const Unlock As String = "Unlock"
    Public Const CkPrice As String = "CkPrice"
    Public Const WL_Qty As String = "WL_Qty"
    Public Const WL_DownQty As String = "WL_DownQty"

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

        ''---------主模块------------
        ModuleX = New MainModuleTpye
        ModuleX.ID = 100                    '===需修改=========== 模块ID
        ModuleX.Caption = "基本资料"      '===需修改=========== 模块名
        CModule.Add(ModuleX)

        ''---------主模块------------
        'ModuleX = New MainModuleTpye
        'ModuleX.ID = 103                    '===需修改=========== 模块ID
        'ModuleX.Caption = "定型工艺"      '===需修改=========== 模块名
        'CModule.Add(ModuleX)

        ''---------主模块------------
        'ModuleX = New MainModuleTpye
        'ModuleX.ID = 101                    '===需修改=========== 模块ID
        'ModuleX.Caption = "客商资料"      '===需修改=========== 模块名
        'CModule.Add(ModuleX)

        '  My.Resources.ResourceManager.BaseName.Replace("")

        '---------主窗口----------
        FormX = New DLLTpye
        FormX.Caption = "物料信息"         '===需修改=========== 窗口菜单名
        FormX.FormName = GetType(F10000_WL)     '===需修改=========== 窗口调用名
        FormX.Img = My.Resources.WL      '===需修改=========== 菜单图标
        FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        FormX.DllAss_Index = 0

        FormX.BillName = "物料信息"     '单据名
        FormX.FormType = BaseFormType.Basic '窗口类型
        FormX.ModifyForm = GetType(F10001_WL_Msg)    '修改窗口

        FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "添加"})
        FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "修改"})
        FormX.Right.Add(New RightTpye With {.RightName = Del, .RightShow = "删除"})
        FormX.Right.Add(New RightTpye With {.RightName = ShowPrice, .RightShow = "显示价钱"})
        FormX.Right.Add(New RightTpye With {.RightName = SetInValid, .RightShow = "禁用"})
        FormX.Right.Add(New RightTpye With {.RightName = SetValid, .RightShow = "启用"})
        FormX.Right.Add(New RightTpye With {.RightName = ReNew, .RightShow = "更换"})
        FormX.Right.Add(New RightTpye With {.RightName = CkPrice, .RightShow = "参考价"})
        FormX.Right.Add(New RightTpye With {.RightName = WL_Qty, .RightShow = "显示库存"})
        FormX.Right.Add(New RightTpye With {.RightName = WL_DownQty, .RightShow = "显示库存下限"})
        CForm.Add(FormX)


        '---------主窗口----------
        FormX = New DLLTpye
        FormX.Caption = "物料名称"         '===需修改=========== 窗口菜单名
        FormX.FormName = GetType(F10007_WL_Name)    '===需修改=========== 窗口调用名
        FormX.Img = My.Resources.BZC   '===需修改=========== 菜单图标
        FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        FormX.DllAss_Index = 0

        FormX.BillName = "物料名称"     '单据名
        FormX.FormType = BaseFormType.Basic '窗口类型
        FormX.ModifyForm = GetType(F10008_WL_Name_Msg)    '修改窗口

        FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "添加物料名称"})
        FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "修改物料名称"})
        FormX.Right.Add(New RightTpye With {.RightName = Del, .RightShow = "客删除物料名称"})
        CForm.Add(FormX)

        '---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "成本价调整"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F10005_CostChange)     '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources._36     '===需修改=========== 菜单图标
        'FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0

        'FormX.BillName = "成本价调整"     '单据名
        'FormX.FormType = BaseFormType.Basic '窗口类型
        'FormX.ModifyForm = GetType(F10006_CostChange_Msg)    '修改窗口

        'FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "添加"})

        'CForm.Add(FormX)

        ''---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "物料属性"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F10013_WL_Type_Attribute)    '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources._90    '===需修改=========== 菜单图标
        'FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0


        'FormX.BillName = "物料属性"     '单据名
        'FormX.FormType = BaseFormType.Basic '窗口类型
        'FormX.ModifyForm = GetType(F10014_WL_Type_Attribute_Msg)    '修改窗口

        'FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "物料属性添加"})
        'FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "物料属性修改"})
        'FormX.Right.Add(New RightTpye With {.RightName = Del, .RightShow = "物料属性删除"})
        'CForm.Add(FormX)


        '---------主窗口----------
        FormX = New DLLTpye
        FormX.Caption = "物料选择"         '===需修改=========== 窗口菜单名
        FormX.FormName = GetType(F10004_WL_Sel)    '===需修改=========== 窗口调用名
        FormX.Img = My.Resources.WL      '===需修改=========== 菜单图标
        FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        FormX.IsShow = False                 '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        FormX.DllAss_Index = 0

        FormX.BillName = "物料选择"     '单据名
        FormX.FormType = BaseFormType.Sel '窗口类型
        ' FormX.ModifyForm = GetType(F10001_WL_Msg)    '修改窗口

        CForm.Add(FormX)

        '---------主窗口----------
        FormX = New DLLTpye
        FormX.Caption = "分类选择"         '===需修改=========== 窗口菜单名
        FormX.FormName = GetType(F10003_GoodsType_Sel)    '===需修改=========== 窗口调用名
        FormX.Img = My.Resources.WL      '===需修改=========== 菜单图标
        FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        FormX.IsShow = False                 '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        FormX.DllAss_Index = 0

        FormX.BillName = "分类选择"     '单据名
        FormX.FormType = BaseFormType.Sel '窗口类型
        ' FormX.ModifyForm = GetType(F10001_WL_Msg)    '修改窗口

        CForm.Add(FormX)



        ''---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "布类资料"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F10010_BZ)    '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources.Image_Goods     '===需修改=========== 菜单图标
        'FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0

        'FormX.BillName = "布类"     '单据名
        'FormX.FormType = BaseFormType.Basic '窗口类型
        'FormX.ModifyForm = GetType(F10011_BZ_Msg)    '修改窗口

        'FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "布类添加"})
        'FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "布类修改"})
        'FormX.Right.Add(New RightTpye With {.RightName = Del, .RightShow = "布类删除"})

        'FormX.Right.Add(New RightTpye With {.RightName = AddGroup, .RightShow = "添加关联布种"})
        'FormX.Right.Add(New RightTpye With {.RightName = DelGroup, .RightShow = "取消关联布种"})

        'FormX.Right.Add(New RightTpye With {.RightName = Combine, .RightShow = "布种合并"})
        'CForm.Add(FormX)

        ''---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "客户选择"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F10012_ClientBZ_Sel)    '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources.Image_Goods     '===需修改=========== 菜单图标
        'FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        'FormX.IsShow = False                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0

        'FormX.BillName = "客户布类选择"     '单据名
        'FormX.FormType = BaseFormType.Sel '窗口类型
        '' FormX.ModifyForm = GetType(F10001_WL_Msg)    '修改窗口

        'CForm.Add(FormX)

        '---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "BOM表资料"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F10020_BZC)    '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources._36     '===需修改=========== 菜单图标
        'FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0

        'FormX.BillName = "BOM表"     '单据名
        'FormX.FormType = BaseFormType.Basic '窗口类型
        'FormX.ModifyForm = GetType(F10021_BZC_Msg)    '修改窗口

        'FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "色号添加"})
        'FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "色号修改"})
        'FormX.Right.Add(New RightTpye With {.RightName = Del, .RightShow = "色号删除"})
        'FormX.Right.Add(New RightTpye With {.RightName = Audited, .RightShow = "色板审核"})
        'FormX.Right.Add(New RightTpye With {.RightName = UnAudit, .RightShow = "色板反审核"})
        'CForm.Add(FormX)



        '---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "染色工艺"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F10030_GY)    '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources.GY    '===需修改=========== 菜单图标
        'FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0


        'FormX.BillName = "染色工艺"     '单据名
        'FormX.FormType = BaseFormType.Basic '窗口类型
        'FormX.ModifyForm = GetType(F10031_GY_Msg)    '修改窗口

        'FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "工艺添加"})
        'FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "工艺修改"})
        'FormX.Right.Add(New RightTpye With {.RightName = Del, .RightShow = "工艺删除"})
        'FormX.Right.Add(New RightTpye With {.RightName = Lock, .RightShow = "工艺锁定"})
        'FormX.Right.Add(New RightTpye With {.RightName = Unlock, .RightShow = "工艺解锁"})
        'FormX.Right.Add(New RightTpye With {.RightName = Invoid, .RightShow = "工艺作废"})
        'FormX.Right.Add(New RightTpye With {.RightName = UnInvoid, .RightShow = "工艺反作废"})

        'CForm.Add(FormX)



        ''---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "加工内容"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F10050_Work)    '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources._90    '===需修改=========== 菜单图标
        'FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0


        'FormX.BillName = "加工内容"     '单据名
        'FormX.FormType = BaseFormType.Basic '窗口类型
        'FormX.ModifyForm = GetType(F10051_Work_Msg)    '修改窗口

        'FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "加工内容添加"})
        'FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "加工内容修改"})
        'FormX.Right.Add(New RightTpye With {.RightName = Del, .RightShow = "加工内容删除"})
        'CForm.Add(FormX)





        ''---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "回修项目"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F10070_ReProject)    '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources._90    '===需修改=========== 菜单图标
        'FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0


        'FormX.BillName = "回修项目"     '单据名
        'FormX.FormType = BaseFormType.Basic '窗口类型
        'FormX.ModifyForm = GetType(F10071_ReProject_Msg)    '修改窗口

        'FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "项目内容添加"})
        'FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "项目内容修改"})
        'FormX.Right.Add(New RightTpye With {.RightName = Del, .RightShow = "项目内容删除"})
        'CForm.Add(FormX)


        ''---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "回修项目"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F10072_ReProject_Sel)    '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources._90    '===需修改=========== 菜单图标
        'FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        'FormX.IsShow = False                 '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0


        'FormX.BillName = "回修项目"     '单据名
        'FormX.FormType = BaseFormType.Basic '窗口类型
        'FormX.ModifyForm = GetType(F10071_ReProject_Msg)    '修改窗口

        'FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "项目内容添加"})
        'FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "项目内容修改"})
        'FormX.Right.Add(New RightTpye With {.RightName = Del, .RightShow = "项目内容删除"})
        'CForm.Add(FormX)

        ''---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "责任部门"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F10080_department_Sel)    '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources._90    '===需修改=========== 菜单图标
        'FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        'FormX.IsShow = False                 '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0


        'FormX.BillName = "责任部门"     '单据名
        'FormX.FormType = BaseFormType.Basic '窗口类型
        ''FormX.ModifyForm = GetType(F10071_ReProject_Msg)    '修改窗口

        ''FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "项目内容添加"})
        'FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "项目内容修改"})
        ''FormX.Right.Add(New RightTpye With {.RightName = Del, .RightShow = "项目内容删除"})
        'CForm.Add(FormX)


        ''---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "加工集合"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F10052_WorkList)    '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources._37    '===需修改=========== 菜单图标
        'FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0


        'FormX.BillName = "加工集合"     '单据名
        'FormX.FormType = BaseFormType.Basic '窗口类型
        'FormX.ModifyForm = GetType(F10053_WorkList_Msg)    '修改窗口

        'FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "加工集合添加"})
        'FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "加工集合修改"})
        'FormX.Right.Add(New RightTpye With {.RightName = Del, .RightShow = "加工集合删除"})
        'CForm.Add(FormX)


        ''---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "染部配方"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F10040_RBPF)    '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources._37    '===需修改=========== 菜单图标
        'FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0

        'FormX.BillName = "染部配方"     '单据名
        'FormX.FormType = BaseFormType.Basic '窗口类型
        'FormX.ModifyForm = GetType(F10041_RBPF_Msg)    '修改窗口

        '' FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "添加"})
        'FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "工修改"})
        '' FormX.Right.Add(New RightTpye With {.RightName = Del, .RightShow = "工艺删除"})
        'FormX.Right.Add(New RightTpye With {.RightName = Invoid, .RightShow = "作废"})
        'FormX.Right.Add(New RightTpye With {.RightName = UnInvoid, .RightShow = "反作废"})



        'CForm.Add(FormX)



        ''---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "定胚工艺"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F10300_DPGY)    '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources._27    '===需修改=========== 菜单图标
        'FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0

        'FormX.BillName = "定胚工艺"     '单据名
        'FormX.FormType = BaseFormType.Basic '窗口类型
        'FormX.ModifyForm = GetType(F10301_DPGY_Msg)    '修改窗口

        'FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "工艺添加"})
        'FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "工艺修改"})
        'FormX.Right.Add(New RightTpye With {.RightName = Del, .RightShow = "工艺删除"})
        'CForm.Add(FormX)


        ''---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "缩水工艺"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F10310_SSGY)    '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources._90   '===需修改=========== 菜单图标
        'FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0

        'FormX.BillName = "缩水工艺"     '单据名
        'FormX.FormType = BaseFormType.Basic '窗口类型
        'FormX.ModifyForm = GetType(F10311_SSGY_Msg)    '修改窗口

        'FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "工艺添加"})
        'FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "工艺修改"})
        'FormX.Right.Add(New RightTpye With {.RightName = Del, .RightShow = "工艺删除"})
        'CForm.Add(FormX)


        ''---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "手感工艺"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F10335_SGGY)    '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources.GY    '===需修改=========== 菜单图标
        'FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0

        'FormX.BillName = "手感工艺"     '单据名
        'FormX.FormType = BaseFormType.Basic '窗口类型
        'FormX.ModifyForm = GetType(F10336_SGGY_Msg)    '修改窗口

        'FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "工艺添加"})
        'FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "工艺修改"})
        'FormX.Right.Add(New RightTpye With {.RightName = Del, .RightShow = "工艺删除"})
        'CForm.Add(FormX)


        'FormX = New DLLTpye
        'FormX.Caption = "色号"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F10060_BZC)    '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources.BZC     '===需修改=========== 菜单图标
        'FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        'FormX.IsShow = False                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0

        'FormX.BillName = "色号"     '单据名
        'FormX.FormType = BaseFormType.Basic '窗口类型
        'FormX.ModifyForm = GetType(F10021_BZC_Msg)    '修改窗口

        'FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "色号添加"})
        'FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "色号修改"})
        'FormX.Right.Add(New RightTpye With {.RightName = Del, .RightShow = "色号删除"})
        'FormX.Right.Add(New RightTpye With {.RightName = Audited, .RightShow = "色板审核"})
        'FormX.Right.Add(New RightTpye With {.RightName = UnAudit, .RightShow = "色板反审核"})
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