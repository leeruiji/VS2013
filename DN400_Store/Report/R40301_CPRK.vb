Imports System.Data
Imports PClass
Imports BaseClass
Imports PClass.PClass
Imports System.Text

Public Class R40301_CPRK

    Inherits CReport

    Dim comletedCount As Integer = 0

    Protected Const fileName As String = "R40300_CPRK.grf"
    Dim FirstDate As Date
    Dim LastDate As Date


    Sub New()
        ' Me.IsSavePrinterSetting = False
        ReDim Dt_Header(1)
        ReportFile = fileName
    End Sub

    Sub Start(ByVal _GH As String, ByVal _operator As OperatorType)
        GH = _GH
        Dim msg As DtReturnMsg = SqlStrToDt(Dao.SQL_CPRK_GetDT_ByID, "GH", GH)
        If msg.IsOk = False OrElse msg.Dt.Rows.Count = 0 Then
            MsgBox("加载报表信息错误")
            Exit Sub
        End If
        Dt_Header(1) = msg.Dt
        Dim MsgList As DtReturnMsg = SqlStrToDt(Dao.SQL_CPRK_GetDL_ByID, "GH", GH)

        Dt_List = MsgList.Dt

        Me.DoOperator = _operator
        Me.DoWork()

    End Sub
    Dim GH As String
    Private Sub R40301_CPRK_PrintCompleted() Handles Me.PrintCompleted
        Dim P As New Dictionary(Of String, Object)
        P.Add("@GH", GH)

        Dim sql As New StringBuilder()
        'sql.AppendLine("insert into T10080_BillStateLog (BillType,ID,State,StateName,ChangeTime,ChagneUser)values(@BillType,@BZSH_ID,@State,@StateName,Getdate(),@ChagneUser)")
        sql.AppendLine("Update T30000_Produce_Gd set CPRK_IsPrinted=1 where GH=@GH")
        RunSQL(sql.ToString, P)
    End Sub
End Class