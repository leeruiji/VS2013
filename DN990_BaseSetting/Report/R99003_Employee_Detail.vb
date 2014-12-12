Imports System.Data
Imports PClass
Imports BaseClass
Imports PClass.PClass
Imports System.Text

Public Class R99003_Employee_Detail
    Inherits CReport

    Dim comletedCount As Integer = 0

    Protected Const Report_File As String = "R99003_Employee_Detail.grf"

    Dim FirstDate As Date
    Dim LastDate As Date


    Sub New()
        ReDim Dt_Header(0)

    End Sub





#Region "数据库交换"

    Sub Start(ByVal dt As DataTable, ByVal DoOperator As OperatorType)



        Me.ReportFile = Report_File

        Me.Dt_List = dt
        Me.Dt_Header(0) = New DataTable
        Me.DoOperator = DoOperator
        Me.DoWork()

        '   MsgBox("加载报表信息错误")

    End Sub

    Dim arr As Byte()
#End Region

    Public Enum Enum_PrintStyle
        Manager
        Normal
        Security

    End Enum






End Class
