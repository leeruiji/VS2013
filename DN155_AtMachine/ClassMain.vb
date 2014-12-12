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
    Public Const Audited As String = "Audited"
    Public Const UnAudit As String = "UnAudit"
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
        'MenuX.ID = 15                   '===需修改=========== 菜单ID
        'MenuX.Caption = "人力资源"      '===需修改=========== 菜单名
        'CMenuX.Add(MenuX)

        ' ''---------主模块------------
        ''ModuleX = New MainModuleTpye
        ''ModuleX.ID = 155                    '===需修改=========== 模块ID
        ''ModuleX.Caption = "机具资料"      '===需修改=========== 模块名
        ''CModule.Add(ModuleX)

        '' ''---------主模块------------
        ''ModuleX = New MainModuleTpye
        ''ModuleX.ID = 156                    '===需修改=========== 模块ID
        ''ModuleX.Caption = "考勤资料"      '===需修改=========== 模块名
        ''CModule.Add(ModuleX)

        '' ---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "机具设置"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F15500_AtMachine)   '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources._29    '===需修改=========== 菜单图标
        'FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0

        'FormX.BillName = "机具"     '单据名
        'FormX.FormType = BaseFormType.Basic '窗口类型
        'FormX.ModifyForm = GetType(F15501_AtMachine_Msg)    '修改窗口


        'FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "机具添加"})
        'FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "机具修改"})
        'FormX.Right.Add(New RightTpye With {.RightName = Del, .RightShow = "机具删除"})

        'CForm.Add(FormX)


        ''---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "机具设置（人面）"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F15504_AtMachine)   '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources._29    '===需修改=========== 菜单图标
        'FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0

        'FormX.BillName = "机具"     '单据名
        'FormX.FormType = BaseFormType.Basic '窗口类型
        'FormX.ModifyForm = GetType(F15505_AtMachine_Msg)    '修改窗口


        'FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "机具添加"})
        'FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "机具修改"})
        'FormX.Right.Add(New RightTpye With {.RightName = Del, .RightShow = "机具删除"})

        'CForm.Add(FormX)

        ''---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "班次信息"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F15510_AT_Shifts)    '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources._14     '===需修改=========== 菜单图标
        'FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0

        'FormX.BillName = "班次"     '单据名
        'FormX.FormType = BaseFormType.Basic '窗口类型
        'FormX.ModifyForm = GetType(F15511_AT_Shifts_Msg)    '修改窗口

        'FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "班次添加"})
        'FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "班次修改"})
        'FormX.Right.Add(New RightTpye With {.RightName = Del, .RightShow = "班次删除"})
        'CForm.Add(FormX)


        ''---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "班次模板"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F15515_Shift_Moduel)    '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources._22     '===需修改=========== 菜单图标
        'FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0

        'FormX.BillName = "班次模板"     '单据名
        'FormX.FormType = BaseFormType.Basic '窗口类型
        'FormX.ModifyForm = GetType(F15516_Shift_Moduel_Msg)    '修改窗口

        'FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "模板添加"})
        'FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "模板修改"})
        'FormX.Right.Add(New RightTpye With {.RightName = Del, .RightShow = "模板删除"})
        'CForm.Add(FormX)


        ''---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "实际班次"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F15517_Real_Shift)    '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources._72     '===需修改=========== 菜单图标
        'FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0

        'FormX.BillName = "实际班次"     '单据名
        'FormX.FormType = BaseFormType.Basic '窗口类型
        'FormX.ModifyForm = GetType(F15518_Real_Shift_Msg)    '修改窗口

        'FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "模板添加"})
        'FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "模板修改"})
        'FormX.Right.Add(New RightTpye With {.RightName = Del, .RightShow = "模板删除"})
        'CForm.Add(FormX)


        ''---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "签卡记录"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F15520_AT_SignCard)    '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources.edit     '===需修改=========== 菜单图标
        'FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0

        'FormX.BillName = "签卡记录"     '单据名
        'FormX.FormType = BaseFormType.Other '窗口类型
        'FormX.ModifyForm = GetType(F15521_AT_SignCard_Msg)    '修改窗口

        'FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "添加"})
        'FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "修改"})
        'FormX.Right.Add(New RightTpye With {.RightName = Del, .RightShow = "删除"})
        'CForm.Add(FormX)

        ''---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "请假记录"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F15530_AT_Leave)    '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources._38   '===需修改=========== 菜单图标
        'FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0

        'FormX.BillName = "请假记录"     '单据名
        'FormX.FormType = BaseFormType.Other '窗口类型
        'FormX.ModifyForm = GetType(F15531_AT_Leave_Msg)    '修改窗口

        'FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "添加"})
        'FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "修改"})
        'FormX.Right.Add(New RightTpye With {.RightName = Del, .RightShow = "删除"})
        'CForm.Add(FormX)






        ''---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "打卡明细"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F15600_At_Data_Mx)    '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources._79   '===需修改=========== 菜单图标
        'FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0

        'FormX.BillName = "打卡明细"     '单据名
        'FormX.FormType = BaseFormType.Report '窗口类型
        ''FormX.ModifyForm = GetType(F15531_AT_Leave_Msg)    '修改窗口

        'CForm.Add(FormX)


        ''---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "排班表"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F15605_PBB_Mx)    '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources._83   '===需修改=========== 菜单图标
        'FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0

        'FormX.BillName = "排班表明细"     '单据名
        'FormX.FormType = BaseFormType.Report '窗口类型
        ''FormX.ModifyForm = GetType(F15531_AT_Leave_Msg)    '修改窗口

        'CForm.Add(FormX)


        ''---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "考勤表"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F15610_Attendance_Data)    '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources._18   '===需修改=========== 菜单图标
        'FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0

        'FormX.BillName = "考勤表"     '单据名
        'FormX.FormType = BaseFormType.Report '窗口类型
        ''FormX.ModifyForm = GetType(F15531_AT_Leave_Msg)    '修改窗口

        'CForm.Add(FormX)
        'FormX.Right.Add(New RightTpye With {.RightName = Audited, .RightShow = "审核"})
        'FormX.Right.Add(New RightTpye With {.RightName = UnAudit, .RightShow = "反审"})


        ''---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "放行条"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F15540_AT_ReleasePass)    '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources._18   '===需修改=========== 菜单图标
        'FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0

        'FormX.BillName = "放行条"     '单据名
        'FormX.FormType = BaseFormType.Basic '窗口类型
        'FormX.ModifyForm = GetType(F15541_AT_ReleasePass_Msg)    '修改窗口

        'CForm.Add(FormX)
        'FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "添加"})
        'FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "修改"})
        'FormX.Right.Add(New RightTpye With {.RightName = Del, .RightShow = "删除"})












        ''---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "考勤分析"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F15620_At_Change)    '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources._18   '===需修改=========== 菜单图标
        'FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 1                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0

        'FormX.BillName = "考勤分析"     '单据名
        'FormX.FormType = BaseFormType.Other '窗口类型
        ''FormX.ModifyForm = GetType(F15531_AT_Leave_Msg)    '修改窗口

        'CForm.Add(FormX)


        ''---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "考勤明细表"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F15630_Attendance_Detailed)    '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources._22   '===需修改=========== 菜单图标
        'FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0

        'FormX.BillName = "考勤明细表"     '单据名
        'FormX.FormType = BaseFormType.Report '窗口类型
        ''FormX.ModifyForm = GetType(F15531_AT_Leave_Msg)    '修改窗口

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