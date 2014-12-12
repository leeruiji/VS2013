Imports System.Data
Imports PClass
Imports BaseClass
Imports PClass.PClass
Imports System.Text

Public Class R99003_Card
    Inherits CReport

    Dim comletedCount As Integer = 0

    Protected Const RP_FILE_Manager As String = "R99003_Card_Manager.grf"

    Protected Const RP_FILE_NorMal As String = "R99003_Card_Normal.grf"

    Protected Const RP_FILE_Security As String = "R99003_Card_Security.grf"
    Dim FirstDate As Date
    Dim LastDate As Date


    Sub New()
        ReDim Dt_Header(0)

    End Sub


   


#Region "数据库交换"

    Sub Start(ByVal Employee_No As String, ByVal DoOperator As OperatorType, ByVal style As Enum_PrintStyle)
        Select Case style
            Case Enum_PrintStyle.Manager
                ReportFile = RP_FILE_Manager
            Case Enum_PrintStyle.Normal
                ReportFile = RP_FILE_NorMal
            Case Enum_PrintStyle.Security
                ReportFile = RP_FILE_Security
        End Select


        Dim msg As DtReturnMsg = SqlStrToDt(SQL_Employee_GetByID, "Employee_No", Employee_No)
        If msg.IsOk = False OrElse msg.Dt.Rows.Count = 0 Then
            MsgBox("加载报表信息错误")
            Exit Sub
        End If
        Dim deptID As String = msg.Dt.Rows(0)("Employee_Dept")
        If IsNull(deptID, "").ToString.Length > 4 Then
            deptID = deptID.Substring(0, 4)
        End If
        Dim Dept As DtReturnMsg = SqlStrToDt("Select top 1 Dept_Name from T15000_Department where Dept_No=@Dept_No", "Dept_No", deptID)
        If msg.IsOk Then
            Me.Dt_List = msg.Dt
            Me.Dt_Header(0) = Dept.Dt
            Me.DoOperator = DoOperator
            Me.DoWork()
        Else
            MsgBox("加载报表信息错误")
        End If
    End Sub

    Dim arr As Byte()
#End Region

    Public Enum Enum_PrintStyle
        Manager
        Normal
        Security

    End Enum






End Class
