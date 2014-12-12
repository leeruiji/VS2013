Imports System.Data
Imports PClass
Imports BaseClass
Imports PClass.PClass
Imports System.Text

Public Class R10010_GoodsBarcode
    Inherits CReport
    Dim comletedCount As Integer = 0
    Protected Const fileName As String = "R10010_GoodsBarcode.grf"
    Protected Const DsfileName As String = "R10011_GoodsBarcode.grf"
    Dim FirstDate As Date
    Dim LastDate As Date
    Public PrintTime As Integer = 1

    Sub New()
        ReDim Dt_Header(0)
    End Sub


    Sub Start(ByVal ID As String, ByVal CP_GH As String, ByVal DoOperator As OperatorType)

    

        Dim R As DtReturnMsg = Dao.CPZL_GetListByGH(ID, CP_GH)
        If R.IsOk = False Then
            MsgBox(R.Msg)
            Exit Sub
        End If
        Dim Rt As DtReturnMsg = Dao.CPZL_GetTable(ID)
        If Rt.IsOk = False Then
            MsgBox(R.Msg)
            Exit Sub
        End If
        If Rt.Dt.Rows.Count = 0 Then
            Exit Sub
        End If
        GetReportFile(Rt.Dt.Rows(0))

         Dim T As DataTable = GetDatatable()
        For Each Row As DataRow In R.Dt.Rows
            Dim Dr As DataRow = T.NewRow
            T.Rows.Add(Dr)
            GetDR(Dr, Rt.Dt.Rows(0), Row)
        Next
        Dt_List = T
        Me.DoOperator = DoOperator
        Me.DoWork()
    End Sub



    Sub Start(ByVal DoOperator As OperatorType, ByVal Row As DataRow, Optional ByVal ISdx As Boolean = False)
        GetReportFile(Row)
        Dim T As DataTable = GetDatatable()
        For i As Integer = 1 To PrintTime
            Dim Dr As DataRow = T.NewRow
            T.Rows.Add(Dr)
            GetDR(Dr, Row, Row)
        Next
        Dt_List = T
        Me.DoOperator = DoOperator
        If DoOperator = OperatorType.Print Then
            Me.Print(False)
        Else
            Me.DoWork()
        End If
    End Sub


    Sub GetReportFile(ByVal Row As DataRow)
        Select Case Row("Client_Name")
            Case "大新"
                ReportFile = DsfileName
            Case Else
                ReportFile = fileName
        End Select
    End Sub

    Function GetDatatable() As DataTable
        Dim T As New DataTable("T")
        T.Columns.Add("RC_BzNo")
        T.Columns.Add("BZ_Name")
        T.Columns.Add("RC_BzColor")
        T.Columns.Add("RC_BzcName")
        T.Columns.Add("RC_ZL")
        T.Columns.Add("RC_VatNo")
        T.Columns.Add("RC_DZL")
        T.Columns.Add("RC_BarCode")
        T.Columns.Add("RC_CP_Line")
        T.Columns.Add("RC_Contract")
        T.Columns.Add("CR_ShiYong")
        T.Columns.Add("CR_KeZhong")
        T.Columns.Add("CR_BianDuiBian")
        Return T
    End Function

    Sub GetDR(ByVal Dr As DataRow, ByVal Row1 As DataRow, ByVal row2 As DataRow)
        Dim Spec As String = ""
        If IsNull(Row1("CR_ShiYong"), "") = "" Then
            If IsNull(Row1("CR_BianDuiBian"), "") = "" Then
                Spec = IsNull(Row1("CR_KeZhong"), "")
            Else
                Spec = Row1("CR_BianDuiBian") & "*" & IsNull(Row1("CR_KeZhong"), "")
            End If
        Else
            Spec = Row1("CR_ShiYong") & "*" & IsNull(Row1("CR_KeZhong"), "")
        End If


        Select Case Row1("Client_Name")
            Case "大新"
                If Row1("Bz_No").ToString.Length > 5 Then
                    Dr("RC_BzNo") = Row1("Bz_No").ToString.Substring(2, 4) & "#"
                Else
                    Dr("RC_BzNo") = Row1("Bz_No")
                End If
                Dr("BZ_Name") = Row1("BZ_Name")
                Dr("CR_ShiYong") = Row1("CR_ShiYong")
                Dr("CR_KeZhong") = Row1("CR_KeZhong")
                Dr("CR_BianDuiBian") = Row1("CR_BianDuiBian")
                Dr("RC_BzColor") = Row1("ClientBzc").ToString.Replace("#", "")
                Dr("RC_BzcName") = Row1("BZC_Name")
                Dr("RC_ZL") = Spec '规格
                Dr("RC_VatNo") = Row1("GH")
                Dr("RC_DZL") = row2("CP")
                Dr("RC_CP_Line") = row2("CP_Line") & "#"
                Dr("RC_Contract") = Row1("Contract")
                Dr("RC_BarCode") = CreateTM_DX(Dr("RC_BzNo"), Dr("RC_BzColor"), Dr("RC_Contract"), Dr("RC_DZL"))
            Case Else
                Dr("RC_BzNo") = Row1("Bz_No").ToString.Replace("#", "")
                Dr("BZ_Name") = Row1("BZ_Name")
                Dr("CR_ShiYong") = Row1("CR_ShiYong")
                Dr("CR_KeZhong") = Row1("CR_KeZhong")
                Dr("CR_BianDuiBian") = Row1("CR_BianDuiBian")
                Dr("BZ_Name") = Row1("BZ_Name")
                Dr("RC_BzColor") = Row1("ClientBzc").ToString.Replace("#", "")
                Dr("RC_BzcName") = Row1("BZC_Name")
                Dr("RC_ZL") = Spec '规格
                Dr("RC_VatNo") = Row1("GH").ToString.Replace("GY", "") & "-" & row2("CP_Line")
                Dr("RC_DZL") = row2("CP")
                Dr("RC_BarCode") = CreateTM(Dr("RC_BzNo"), Dr("RC_BzColor"), Row1("GH").ToString.Replace("GY", ""), Dr("RC_DZL"))
        End Select
    End Sub


    Public Shared Function CreateTM_DX(ByVal BzNo As String, ByVal Bzc As String, ByVal Contract As String, ByVal ZL As Double) As String
        Dim s As String
        Dim C As String
        Dim G As String
        Dim B As String
        If Contract Is Nothing Then Contract = "0"

        B = "0000" & BzNo.ToUpper.Replace("#", "")
        B = B.Substring(B.Length - 4)

        C = "000" & Bzc.ToUpper
        C = C.Substring(C.Length - 3)

        s = Format(ZL, "00.0").Replace(".", "")
        s = s.Substring(s.Length - 3, 3)
        If Contract.Length > 5 Then
            G = CLng(Val(Contract.Substring(Contract.Length - 5))).ToString
        Else
            G = CLng(Val(Contract.Substring(Contract))).ToString
        End If

        If G.Length > 6 Then G = G.Substring(0, 6)
        G = "000000" & G
        G = G.Substring(G.Length - 6)

        Return B & C & G & s
    End Function


    Public Shared Function CreateTM(ByVal BzNo As String, ByVal Bzc As String, ByVal Gh As String, ByVal ZL As Double) As String
        Dim s As String
        Dim C As String
        Dim G As String
        Dim B As String
        If Gh Is Nothing Then Gh = "0"

        B = "00000" & BzNo.ToUpper
        B = B.Substring(B.Length - 5)

        C = "000" & Bzc.ToUpper
        C = C.Substring(C.Length - 3)

        s = Format(ZL, "00.0").Replace(".", "")
        s = s.Substring(s.Length - 3, 3)

        G = "00000" & Gh.ToUpper
        For i As Integer = G.Length - 1 To 5 Step -1
            If IsNumeric(G.Substring(i, 1)) = False Then
                G = G.Replace(G.Substring(i, 1), "")
            End If
        Next
        G = G.Substring(G.Length - 5)
        Return B & C & G & s
    End Function

End Class

