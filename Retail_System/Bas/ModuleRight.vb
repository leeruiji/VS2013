Imports PClass.PClass

Module ModuleRight
    Public Const MainFormID As Integer = 99999



    Sub AddMainRight()
        Dim P As New MainModuleTpye
        P.Caption = "主窗口模块"
        P.ID = 999
        HashModule.Add(999, P)

        Dim FormX As DLLTpye

        '---------主窗口----------
        FormX = New DLLTpye
        FormX.Caption = "主窗口"         '===需修改=========== 窗口菜单名
        FormX.FormName = GetType(MainWindow)    '===需修改=========== 窗口调用名
        FormX.ID = MainFormID
        FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        FormX.LoadMode = 1                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        FormX.DllAss_Index = 0
        FormX.Right.Add(New RightTpye With {.RightName = "DLL_List", .RightShow = "DLL列表"})
        FormX.Right.Add(New RightTpye With {.RightName = "DLL_Update", .RightShow = "上传更新"})
        '  FormX.Right.Add(New RightTpye With {.RightName = "Accounts_Manage", .RightShow = "帐套管理"})
        FormX.Right.Add(New RightTpye With {.RightName = "Change_DB", .RightShow = "更新数据库"})
        FormX.Right.Add(New RightTpye With {.RightName = "Change_Pwd", .RightShow = "修改密码"})
        FormX.Right.Add(New RightTpye With {.RightName = "Change_SysImg", .RightShow = "更换默认图片"})
        FormX.Right.Add(New RightTpye With {.RightName = "Change_MyImg", .RightShow = "更换个人图片"})
        FormX.Right.Add(New RightTpye With {.RightName = "CanExcelOutFromFG", .RightShow = "从列表导出Excel"})
        FormX.Right.Add(New RightTpye With {.RightName = "CanExcelOutFromReport", .RightShow = "从报表导出Excel"})
        HashDll.Add(FormX.ID, FormX)




    End Sub



End Module
