Imports System.Data
Imports PClass
Imports BaseClass
Imports PClass.PClass
Imports System.Text

Public Class R40100_PBRK

    Inherits CReport

    Dim comletedCount As Integer = 0

    Protected Const fileName As String = "R40100_PBRK.grf"
    Dim FirstDate As Date
    Dim LastDate As Date


    Sub New(ByVal Excelout As Boolean)
        ' Me.IsSavePrinterSetting = False
        ReDim Dt_Header(1)
        ReportFile = fileName

        If Excelout Then
            Me.SetCanExcelOut()
        Else
            Me.SetCanNotExcelOut()
        End If


    End Sub

    Sub Start(ByVal _operator As OperatorType, ByVal dtlist As DataTable)
        Dt_Header(1) = New DataTable("T")
        Dt_List = dtlist

        Me.DoOperator = _operator
        Me.DoWork()

    End Sub
End Class