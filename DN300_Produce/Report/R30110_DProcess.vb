Imports System.Data
Imports PClass
Imports BaseClass
Imports PClass.PClass
Imports System.Text

Public Class R30110_DProcess
    Inherits CReport
    Dim comletedCount As Integer = 0
    Protected Const fileName As String = "R30110_DProcess.grf"
    Dim FirstDate As Date
    Dim LastDate As Date


    Sub New()
        ReportFile = fileName
        ReDim Dt_Header(1)

    End Sub


    Sub Start(ByVal dt As DataTable, ByVal DoOperator As OperatorType)
        'Dim R As DtReturnMsg = Dao.Get_Dprocess_Getlist
        'If R.IsOk = False Then
        '    MsgBox(R.Msg)
        '    Exit Sub
        'End If
        Dt_List = dt


        ReportFile = fileName


        Dt_Header(1) = Nothing
        Me.DoOperator = DoOperator
        Me.DoWork()
    End Sub

   



End Class
#Region "数据库交换"

Partial Friend Class Dao
    'Public Const SQL_Dprocess_Getlist = " select D.*,W.Work_Name from T30110_DProcess D left join T10022_Work W ON D.Remark=W.Work_No "

    'Public Shared Function Get_Dprocess_Getlist() As DtReturnMsg

    '    Return SqlStrToDt(SQL_Dprocess_Getlist)
    'End Function

End Class


#End Region
