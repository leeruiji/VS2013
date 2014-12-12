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

    Public Const Audited As String = "Audited"
    Public Const UnAudit As String = "UnAudit"
    Public Const Print As String = "Print"

    Public Const Confirm_Qty As String = "Confirm_Qty"

    Public Const JiaLiao As String = "JiaLiao"
    Public Const ShowJiaLiao As String = "ShowJiaLiao"
    Public Const PrintMore As String = "PrintMore"
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
        MenuX.ID = 28                   '===需修改=========== 菜单ID
        MenuX.Caption = "工资计提"      '===需修改=========== 菜单名
        CMenuX.Add(MenuX)

        ''---------主模块------------
        ModuleX = New MainModuleTpye
        ModuleX.ID = 280                   '===需修改=========== 模块ID
        ModuleX.Caption = "计提录入"      '===需修改=========== 模块名
        CModule.Add(ModuleX)

       


        '---------主窗口----------
        FormX = New DLLTpye
        FormX.Caption = "计件录入"         '===需修改=========== 窗口菜单名
        FormX.FormName = GetType(F28000_Employees_JT)    '===需修改=========== 窗口调用名
        FormX.Img = My.Resources._73     '===需修改=========== 菜单图标
        FormX.ID = CInt(FormX.FormName.Name.Substring(1, 5))
        FormX.IsShow = True                '===需修改=========== 显示在菜单上直接调用,false 可以间接调用
        FormX.LoadMode = 0                 '加载模式 0为MDI窗口 1为固定窗口例如修改密码窗口之类,运行时锁死其他窗口
        FormX.DllAss_Index = 0

        FormX.BillName = "计件录入"     '单据名
        FormX.FormType = BaseFormType.Bill '窗口类型
        FormX.ModifyForm = GetType(F28000_Employees_JT)    '修改窗口

        FormX.Right.Add(New RightTpye With {.RightName = Add, .RightShow = "添加"})
        FormX.Right.Add(New RightTpye With {.RightName = Modify, .RightShow = "修改"})
        FormX.Right.Add(New RightTpye With {.RightName = Del, .RightShow = "删除"})

        FormX.Right.Add(New RightTpye With {.RightName = SetInValid, .RightShow = "作废"})
        FormX.Right.Add(New RightTpye With {.RightName = SetValid, .RightShow = "还原"})
        FormX.Right.Add(New RightTpye With {.RightName = Audited, .RightShow = "审核"})
        FormX.Right.Add(New RightTpye With {.RightName = UnAudit, .RightShow = "反审"})
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