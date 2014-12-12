Imports PClass
Imports System.Data

Public Class R40501_StoreNo_Left
    Inherits CReport



    Protected Const fileName As String = "R40501_StoreNo_Left.grf"


    Sub New()
        ReDim Dt_Header(0)
        ReportFile = fileName
    End Sub

    Sub Start(ByVal Dt As datatable, ByVal DoOperator As OperatorType)
        Me.Dt_List = Dt
        Me.DoOperator = DoOperator
        Me.DoWork()
    End Sub

End Class
