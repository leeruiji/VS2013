Imports System.Data
Imports PClass
Imports BaseClass
Imports PClass.PClass
Imports System.Text

Public Class R30111_DProcess_Msg
    Inherits CReport
    Dim comletedCount As Integer = 0
    Protected Const fileName As String = "R30111_DProcess_Msg.grf"
    Dim FirstDate As Date
    Dim LastDate As Date


    Sub New()
        ReportFile = fileName
        ReDim Dt_Header(1)

    End Sub


    Sub Start(ByVal dt As DataTable, ByVal dList As DataTable, ByVal DoOperator As OperatorType)
        'Dim R As DtReturnMsg = Dao.Get_Dprocess_Getlist
        'If R.IsOk = False Then
        '    MsgBox(R.Msg)
        '    Exit Sub
        'End If
        Dt_List = dList
        Dt_Header(0) = dt

        ReportFile = fileName


        Dt_Header(1) = Nothing
        Me.DoOperator = DoOperator
        Me.DoWork()
    End Sub





End Class