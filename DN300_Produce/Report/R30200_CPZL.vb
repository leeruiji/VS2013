Imports System.Data
Imports PClass
Imports BaseClass
Imports PClass.PClass
Imports System.Text

Public Class R30200_CPZL
    Inherits CReport
    Dim comletedCount As Integer = 0
    Protected Const fileName As String = "R30200_CPZL.grf"
    Protected Const fileName_More40 As String = "R30201_CPZL_More40.grf"
    Dim FirstDate As Date
    Dim LastDate As Date


    Sub New()
        ReportFile = fileName
        ReDim Dt_Header(1)

    End Sub


    Sub Start(ByVal ID As String, ByVal CP_GH As String, ByVal DoOperator As OperatorType)
        Dim R As DtReturnMsg = Dao.CPZL_GetListByGH(ID, CP_GH)
        If R.IsOk = False Then
            MsgBox(R.Msg)
            Exit Sub
        End If
        Dt_List = CPZLSetDt(Dt_List, R.Dt)

        Dim Rt As DtReturnMsg = Dao.CPZL_GetTable(ID)
        If Rt.IsOk = False Then
            MsgBox(R.Msg)
            Exit Sub
        End If
        Dim T As DataTable = Rt.Dt
        ' T.Columns.Add("SmallGH")
        T.Columns.Add("SumQty", GetType(Double))
        T.Columns.Add("SumPZ", GetType(Double))
        T.Columns.Add("SumZL", GetType(Double))
        T.Columns.Add("SH", GetType(Double))

        If T.Rows.Count > 0 Then
            Dim Dr As DataRow = T.Rows(0)
            If IsNull(T.Rows(0)("Contract"), "") <> "" Then
                Dr("Contract") = "订单号:" & Dr("Contract")
            End If
            If IsNull(T.Rows(0)("ClientBzc"), "") <> "" Then
                Dr("ClientBzc") = Dr("ClientBzc") & "#"
            End If
            If IsNull(Dr("BZ_No"), "").ToString.Contains("#") = False Then
                Dr("BZ_No") = ""
            End If
            If IsNull(Dr("CPName"), "") = "" Then
                Dr("CPName") = Dr("BZ_No") & Dr("BZ_Name")
            End If
            ' Dim p As New Dictionary(Of String, Object)
            ' p.Add("No_ID", Dr("GH"))
            ' p.Add("NO_Type", 30000)
            ' Dr("SmallGH") = BaseClass.ComFun.GetGHTm(SqlStrToOneStr("select top 1 No_TM from Bill_Barcode where No_ID=@No_ID and NO_Type=@NO_Type", p).Msg)
            If IsNull(Dr("IsFD"), False) = True AndAlso IsNull(Dr("BzcMsg"), "") = "" Then
                Dr("BzcMsg") = "返定"
            Else
                If IsNull(Dr("BzcMsg"), "") = "" Then
                    Dr("BzcMsg") = Dr("ClientBzc") & Dr("BZC_Name") & vbCrLf & "GY-" & Format(IsNull(Dr("BZc_No"), ""), "000000") & Dr("BZC_PF")
                End If
            End If
            Dr("SumPZ") = 0
            Dr("SumZL") = 0
            Dr("SumQty") = 0
            For Each Row As DataRow In R.Dt.Rows
                Dr("SumPZ") = Row("PB") + Dr("SumPZ")
                Dr("SumZL") = Row("CP") + Dr("SumZL")
                Dr("SumQty") = 1 + Dr("SumQty")
            Next
            Try
                Dr("SH") = (Dr("SumZL") - (Dr("ZhiTong") + Dr("JiaZhong")) * Dr("SumQty")) / Dr("SumPZ") - 1
            Catch ex As Exception
                Dr("SH") = 0
            End Try

        End If

        If R.Dt.Rows.Count > 40 Then
            ReportFile = fileName_More40
        Else
            ReportFile = fileName
        End If

        Dt_Header(1) = T
        Me.DoOperator = DoOperator
        Me.DoWork()
    End Sub

    Function CPZLSetDt(ByVal Dt_List As DataTable, ByVal Drl As DataTable) As DataTable



        Dt_List = New DataTable("T")
        Dt_List.Columns.Add("XM1")
        Dt_List.Columns.Add("PZ1")
        Dt_List.Columns.Add("ZL1")

        Dt_List.Columns.Add("XM2")
        Dt_List.Columns.Add("PZ2")
        Dt_List.Columns.Add("ZL2")

        Dt_List.Columns.Add("XM3")
        Dt_List.Columns.Add("PZ3")
        Dt_List.Columns.Add("ZL3")

        Dt_List.Columns.Add("XM4")
        Dt_List.Columns.Add("PZ4")
        Dt_List.Columns.Add("ZL4")
 
        Dim j As Integer = 0
        Dim a As Integer
        Dim b As Integer = 0
        a = Drl.Rows.Count
        While j < Drl.Rows.Count

            If j >= 60 Then
                b = b + 1
                a = Drl.Rows.Count - 60 * b
                j = 0

            End If
            For i As Integer = 1 To 10
                Dt_List.Rows.Add(Dt_List.NewRow)
            Next
            For i As Integer = 0 To 9
                If j < a Then
                    Dt_List.Rows(i + b * 10)("PZ1") = Drl.Rows(j + b * 60)("PB")
                    Dt_List.Rows(i + b * 10)("ZL1") = Drl.Rows(j + b * 60)("CP")
                    j = j + 1
                Else
                    Return Dt_List
                End If
            Next
            For i As Integer = 0 To 9
                If j < a Then
                    Dt_List.Rows(i + b * 10)("PZ2") = Drl.Rows(j + b * 60)("PB")
                    Dt_List.Rows(i + b * 10)("ZL2") = Drl.Rows(j + b * 60)("CP")
                    j = j + 1
                Else
                    Return Dt_List
                End If
            Next
            For i As Integer = 0 To 9
                If j < a Then
                    Dt_List.Rows(i + b * 10)("PZ3") = Drl.Rows(j + b * 60)("PB")
                    Dt_List.Rows(i + b * 10)("ZL3") = Drl.Rows(j + b * 60)("CP")
                    j = j + 1
                Else
                    Return Dt_List
                End If
            Next
            For i As Integer = 0 To 9
                If j < a Then
                    Dt_List.Rows(i + b * 10)("PZ4") = Drl.Rows(j + b * 60)("PB")
                    Dt_List.Rows(i + b * 10)("ZL4") = Drl.Rows(j + b * 60)("CP")
                    j = j + 1
                Else
                    Return Dt_List
                End If
            Next

            If a > 40 Then
                Dt_List.Columns.Add("PZ5")
                Dt_List.Columns.Add("ZL5")

                Dt_List.Columns.Add("PZ6")
                Dt_List.Columns.Add("ZL6")

                For i As Integer = 0 To 9
                    If j < a Then
                        Dt_List.Rows(i + b * 10)("PZ5") = Drl.Rows(j + b * 60)("PB")
                        Dt_List.Rows(i + b * 10)("ZL5") = Drl.Rows(j + b * 60)("CP")
                        j = j + 1
                    Else
                        Return Dt_List
                    End If
                Next
                For i As Integer = 0 To 9
                    If j < a Then
                        Dt_List.Rows(i + b * 10)("PZ6") = Drl.Rows(j + b * 60)("PB")
                        Dt_List.Rows(i + b * 10)("ZL6") = Drl.Rows(j + b * 60)("CP")
                        j = j + 1
                    Else
                        Return Dt_List
                    End If
                Next


            End If
        End While
        Return Dt_List
    End Function





End Class
#Region "数据库交换"
Partial Friend Class Dao
    Public Const SQL_CPZL_GetListByGH = "select PB,CP,CP_Line from T40101_PBRK_List where GH=@GH and isnull(CP_GH,'')<>'' order by CP_GH,CP_Line"
    Public Const SQL_CPZL_GetListByCPGH = "select PB,CP,CP_Line from T40101_PBRK_List where GH=@GH and  CP_GH=@CP_GH order by CP_GH,CP_Line"
    Public Const SQL_CPZL_GetTable = "Select top 1 P.GH,p.Contract,ZhiTong,JiaZhong,CR_ShiYong,CR_BianDuiBian,CR_KeZhong,IsFD,BzcMsg,BZC_PF,C.Client_Name,isnull(CP_No,BZ_No) BZ_No,isnull(CP_Name,BZ_Name)BZ_Name ,BZC_No,BZC_Name,BZ_Spec,ClientBzc,CPName from T30000_Produce_Gd P left join T10110_Client C on P.Client_ID=C.ID left join T10002_BZ BZ on P.BZ_ID=BZ.ID left join T10003_BZC BZC on P.BZC_ID=BZC.ID  where GH=@GH "

    Public Shared Function CPZL_GetListByGH(ByVal GH As String, ByVal CP_GH As String) As DtReturnMsg
        If CP_GH = "" Then
            Return SqlStrToDt(SQL_CPZL_GetListByGH, "GH", GH)
        Else
            Dim P As New Dictionary(Of String, Object)
            P.Add("GH", GH)
            P.Add("CP_GH", CP_GH)
            Return SqlStrToDt(SQL_CPZL_GetListByCPGH, P)
        End If
    End Function

    Public Shared Function CPZL_GetTable(ByVal GH As String) As DtReturnMsg
        Return SqlStrToDt(SQL_CPZL_GetTable, "GH", GH)
    End Function

End Class


#End Region
