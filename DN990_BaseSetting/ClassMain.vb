Imports PClass.PClass
Imports System.Drawing

Public Class ClassMain

#Region "权限常量"
    Public Const User As String = "User"
    Public Const Employee As String = "Employee"
    Public Const Add As String = "Add"
    Public Const Modify As String = "Modify"
    Public Const DeptOrder As String = "DeptOrder"
    Public Const Del As String = "Del"
    Public Const Quit As String = "Quit"


    Public Const Right_Modify As String = "Right_Modify"
    Public Const FileOut As String = "FileOut"
    'Public Const SetInValid As String = "SetInValid"
    'Public Const SetValid As String = "SetValid"
    'Public Const ComfirmStoreInOrOut As String = "ComfirmStoreInOrOut"
    'Public Const Audited As String = "Audited"
    'Public Const UnAudit As String = "UnAudit"
    Public Const Print As String = "Print"
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
        MenuX.ID = 99                   '===需修改=========== 菜单ID
        MenuX.Caption = "系统设置"      '===需修改=========== 菜单名
        CMenuX.Add(MenuX)

        ''---------主模块------------
        'ModuleX = New MainModuleTpye
        'ModuleX.ID = 150                    '===需修改=========== 模块ID
        'ModuleX.Caption = "部门及员工管理"      '===需修改=========== 模块名
        'CModule.Add(ModuleX)

        ''---------主模块------------
        ModuleX = New MainModuleTpye
        ModuleX.ID = 990                    '===需修改=========== 模块ID
        ModuleX.Caption = "基本设置模块"      '===需修改=========== 模块名
        CModule.Add(ModuleX)

        '  My.Resources.ResourceManager.BaseName.Replace("")

        '---------主窗口----------
        FormX = New DLLTpye
        FormX.Caption = "权限设置"         '===需修改=========== 窗口菜单名
        FormX.FormName = GetType(F99000_Rights)    '===需修改=========== 窗口调用名
        FormX.Img = My.Resources.Image_99000     '===需修改=========== 菜单图标
        FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        FormX.DllAss_Index = 0

        FormX.BillName = "权限"     '单据名
        FormX.FormType = BaseFormType.Setting '窗口类型
        FormX.ModifyForm = Nothing    '修改窗口

        FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "权限组添加"})
        FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "权限组修改"})
        FormX.Right.Add(New RightTpye With {.RightName = Del, .RightShow = "权限组删除"})
        FormX.Right.Add(New RightTpye With {.RightName = Right_Modify, .RightShow = "权限修改"})
        CForm.Add(FormX)

        '---------主窗口----------
        FormX = New DLLTpye
        FormX.Caption = "部门及员工"         '===需修改=========== 窗口菜单名
        FormX.FormName = GetType(F99003_Department)    '===需修改=========== 窗口调用名
        FormX.Img = My.Resources.Image_99003     '===需修改=========== 菜单图标
        FormX.ID = 15000
        FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        FormX.DllAss_Index = 0


        FormX.BillName = "员工"     '单据名
        FormX.FormType = BaseFormType.Basic '窗口类型
        FormX.ModifyForm = GetType(F990031_Employee_Msg)    '修改窗口

        FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "部门添加"})
        FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "部门修改"})
        FormX.Right.Add(New RightTpye With {.RightName = DeptOrder, .RightShow = "部门排序"})
        FormX.Right.Add(New RightTpye With {.RightName = Del, .RightShow = "部门删除"})

        '  FormX.Right.Add(New RightTpye With {.RightName = User & Add, .RightShow = "用户添加"})
        FormX.Right.Add(New RightTpye With {.RightName = User & Modify, .RightShow = "用户修改"})
        FormX.Right.Add(New RightTpye With {.RightName = User & Del, .RightShow = "用户删除"})

        FormX.Right.Add(New RightTpye With {.RightName = Employee & Add, .RightShow = "员工添加"})
        FormX.Right.Add(New RightTpye With {.RightName = Employee & Modify, .RightShow = "员工修改"})
        FormX.Right.Add(New RightTpye With {.RightName = Employee & Del, .RightShow = "员工删除"})
        FormX.Right.Add(New RightTpye With {.RightName = Employee & Quit, .RightShow = "员工离职"})
        FormX.Right.Add(New RightTpye With {.RightName = Employee & ClassMain.Print, .RightShow = "打印员工卡"})


        CForm.Add(FormX)


        '---------主窗口----------
        FormX = New DLLTpye
        FormX.Caption = "部门选择"         '===需修改=========== 窗口菜单名
        FormX.FormName = GetType(F99004_Department_Sel)    '===需修改=========== 窗口调用名
        ' FormX.Img = My.Resources.WL      '===需修改=========== 菜单图标
        FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        FormX.IsShow = False                 '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        FormX.DllAss_Index = 0


        FormX.BillName = "部门"     '单据名
        FormX.FormType = BaseFormType.Sel '窗口类型
        FormX.ModifyForm = Nothing     '修改窗口

        CForm.Add(FormX)


        '---------主窗口----------
        FormX = New DLLTpye
        FormX.Caption = "职位列表"         '===需修改=========== 窗口菜单名
        FormX.FormName = GetType(F99005_Job)    '===需修改=========== 窗口调用名
        FormX.Img = My.Resources.Image_99005     '===需修改=========== 菜单图标
        FormX.ID = 15002
        FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        FormX.DllAss_Index = 0

        FormX.BillName = "职位"     '单据名
        FormX.FormType = BaseFormType.Basic '窗口类型
        FormX.ModifyForm = GetType(F99006_Job_Msg)    '修改窗口

        FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "职位添加"})
        FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "职位修改"})
        FormX.Right.Add(New RightTpye With {.RightName = Del, .RightShow = "职位删除"})
        CForm.Add(FormX)

        '---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "宿舍列表"         '===需修改=========== 窗口菜单名
        'FormX.FormName = GetType(F99012_Room)    '===需修改=========== 窗口调用名
        'FormX.Img = My.Resources._91     '===需修改=========== 菜单图标
        'FormX.ID = 15004
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0

        'FormX.BillName = "宿舍"     '单据名
        'FormX.FormType = BaseFormType.Basic '窗口类型
        'FormX.ModifyForm = GetType(F99013_Room_Msg)    '修改窗口

        'FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "添加"})
        'FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "修改"})
        'FormX.Right.Add(New RightTpye With {.RightName = Del, .RightShow = "删除"})
        'CForm.Add(FormX)


        ''---------主窗口----------
        FormX = New DLLTpye
        FormX.Caption = "报表设置"         '===需修改=========== 窗口菜单名
        FormX.FormName = GetType(F99010_Report)    '===需修改=========== 窗口调用名
        FormX.Img = My.Resources.Image_99030    '===需修改=========== 菜单图标
        FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        FormX.DllAss_Index = 0

        FormX.BillName = "报表"     '单据名
        FormX.FormType = BaseFormType.Setting '窗口类型
        FormX.ModifyForm = Nothing     '修改窗口


        FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "报表添加"})
        FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "报表修改"})
        FormX.Right.Add(New RightTpye With {.RightName = Del, .RightShow = "报表删除"})
        FormX.Right.Add(New RightTpye With {.RightName = FileOut, .RightShow = "报表文件导出"})
        CForm.Add(FormX)


       


        ''---------主窗口----------
        'FormX = New DLLTpye
        'FormX.Caption = "系统更新"         '===需修改=========== 窗口菜单名
        'FormX.FormName = "F99020_Update"    '===需修改=========== 窗口调用名
        'FormX.Img = GetBitmapImage("Images/29.png")     '===需修改=========== 菜单图标
        'FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        'FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        'FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        'FormX.DllAss_Index = 0
        'FormX.Right.Add(New RightTpye With {.RightName = DLL_Add, .RightShow = "文件更新"})
        'FormX.Right.Add(New RightTpye With {.RightName = DLL_Del, .RightShow = "文件删除"})
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