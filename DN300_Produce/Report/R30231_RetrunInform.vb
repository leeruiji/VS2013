Imports System.Data
Imports PClass
Imports BaseClass
Imports PClass.PClass
Imports System.Text

Public Class R30231_RetrunInform
    Inherits CReport
    Dim comletedCount As Integer = 0
    Protected Const fileName As String = "R30231_RetrunInform.grf"
    Dim FirstDate As Date
    Dim LastDate As Date


    Sub New()
        ReDim Dt_Header(1)
        ReportFile = fileName
    End Sub


    Sub Start(ByVal ID As String, ByVal DoOperator As OperatorType)


        Dt_Header(1) = New DataTable


        Dim R As DtReturnMsg = Dao.InForm_GetById(ID)

        If R.IsOk = False Then
            MsgBox(R.Msg)
            Exit Sub
        End If
        Dt_List = R.Dt
        Me.DoOperator = DoOperator
        Me.DoWork()
    End Sub







End Class
#Region "数据库交换"

Partial Friend Class Dao
 

End Class


#End Region
