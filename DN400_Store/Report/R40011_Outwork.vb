Imports System.Data
Imports PClass
Imports BaseClass
Imports PClass.PClass
Imports System.Text

Public Class R40011_Outwork

    Inherits CReport

    Dim comletedCount As Integer = 0

    Protected Const fileName As String = "R40011_Outwork.grf"
    Dim FirstDate As Date
    Dim LastDate As Date


    Sub New()
        ' Me.IsSavePrinterSetting = False
        ReDim Dt_Header(1)
        ReportFile = fileName
    End Sub





#Region "数据库交换"
    Dim _Id As String
    Sub Start(ByVal _ID As String, ByVal DoOperator As OperatorType)
        Me._Id = _ID
        Dim msg As DtReturnMsg = SqlStrToDt(Dao.SQL_OutWork_GetByOption & "Where T.ID=@ID", "ID", _ID)
        If msg.IsOk = False OrElse msg.Dt.Rows.Count = 0 Then
            MsgBox("加载报表信息错误")
            Exit Sub
        End If
        Dim MsgList As DtReturnMsg = SqlStrToDt(Dao.SQL_OutWork_GetOutWorkListByid_ForReport, "ID", _ID)

        For Each Dr As DataRow In MsgList.Dt.Rows



            'If IsNull(Dr("Client_Bzc"), "") <> "" Then
            '    Dr("Client_Bzc") = Dr("Client_Bzc") & "#"
            'End If
            'If IsNull(Dr("BZ_No"), "").ToString.Contains("#") = False Then
            '    Dr("BZ_No") = ""
            'End If


            'If IsNull(Dr("BzcMsg"), "") = "" Then
            '    Dr("BzcMsg") = Dr("Client_Bzc") & Dr("BZC_Name") & vbCrLf & "GY-" & Format(IsNull(Dr("BZc_No"), ""), "000000") & Dr("BZC_PF")
            'End If


        Next

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

    Private Sub R40001_BZSH_PrintCompleted() Handles Me.PrintCompleted
        Dim P As New Dictionary(Of String, Object)
        P.Add("@BZSH_ID", _Id)
        P.Add("BillType", BillType.BZSH)
        P.Add("State", -1)
        P.Add("StateName", "打印")
        P.Add("ChagneUser", User_Display)
        RunSQL("insert into T10080_BillStateLog (BillType,ID,State,StateName,ChangeTime,ChagneUser)values(@BillType,@BZSH_ID,@State,@StateName,Getdate(),@ChagneUser) ", P)
    End Sub








    Private Sub R40001_BZSH_PrintEnd() Handles Me.PrintEnd

    End Sub
End Class
