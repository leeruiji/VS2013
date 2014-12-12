Imports System.Data
Imports PClass
Imports BaseClass
Imports PClass.PClass
Imports System.Text

Public Class R40001_BZSH

    Inherits CReport

    Dim comletedCount As Integer = 0

    Protected Const fileName As String = "R40001_BZSH.grf"
    Dim FirstDate As Date
    Dim LastDate As Date


    Sub New()
        ReDim Dt_Header(1)
        ReportFile = fileName
    End Sub





#Region "数据库交换"

    Sub Start(ByVal BZSH_ID As String, ByVal DoOperator As OperatorType)

        Dim msg As DtReturnMsg = SqlStrToDt(SQL_BZSH_GetBZSHByidWhithClientName, "BZSH_ID", BZSH_ID)
        If msg.IsOk = False OrElse msg.Dt.Rows.Count = 0 Then
            MsgBox("加载报表信息错误")
            Exit Sub
        End If
        Dim MsgList As DtReturnMsg = SqlStrToDt(SQL_BZSH_GetBZSHListByid_ForReport, "BZSH_ID", BZSH_ID)




        If msg.IsOk AndAlso MsgList.IsOk Then
            Me.Dt_List = msg.Dt
            Me.Dt_Header(0) = msg.Dt
            Me.Dt_List = MsgList.Dt
            Me.DoOperator = DoOperator
            Me.DoWork()
        Else
            MsgBox("加载报表信息错误")
        End If
    End Sub

    Dim arr As Byte()
#End Region








End Class
