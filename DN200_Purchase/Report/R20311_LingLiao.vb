Imports System.Data
Imports PClass
Imports BaseClass
Imports PClass.PClass
Imports System.Text
Public Class R20311_LingLiao
    Inherits CReport
    Dim comletedCount As Integer = 0

    Protected fileName As String = "R20311_StoreOut_LingLiao.grf"
    Dim FirstDate As Date
    Dim LastDate As Date
    Dim BType As BillType = BillType.LingLiao

    Sub New()
        ReDim Dt_Header(1)

    End Sub


    Sub Start(ByVal dt As DataTable, ByVal ID As String, ByVal DoOperator As OperatorType, Optional ByVal isFirst As Boolean = True)
        Me.ReportFile = fileName
        Dim R As DtReturnMsg
        Dim dlist As New DataTable
        Dim sid() As String = dt.Rows(0)("ID").ToString.Split(",")
        For Each did In sid
            R = Dao.LingLiao_SelListById(did)
            If R.IsOk = False Then
                MsgBox(R.Msg)
                Exit Sub
            End If

            Dt_List = DtRunSQLtoDt(R.Dt, "Isnull(IsPageTwo,1)=" & IIf(isFirst, 0, 1))
            Dt_List.Columns.Add("StepStr")
            Dt_List.Columns.Add("ISBz", GetType(Boolean))
            Dt_List.Columns.Add("StepTime", GetType(String))
            Dim S As Integer = 1
            Dim K As Integer = 0

            For i As Integer = 0 To Dt_List.Rows.Count - 1
                Dim Row As DataRow = Dt_List.Rows(i)
                If IsNull(Row("DyingStep"), "") <> "" Then
                    For J As Integer = K To i
                        Dt_List.Rows(J).Item("StepStr") = S
                        Dt_List.Rows(J).Item("StepTime") = Dt_List.Rows(i).Item("DyingStep")
                    Next
                    S = S + 1
                    K = i + 1
                End If
                Dt_List.Rows(i).Item("ISBz") = False

            Next
            dlist.Merge(Dt_List)

        Next
        Dt_List = dlist




        Dim list As DataTable = Dt_List.Clone
        Dim qty As Double = 0
        Dim dv As DataRow
        Dim y As Integer = 0
        For n As Integer = 0 To Dt_List.Rows.Count - 1

            For Each ds In Dt_List.Rows
                If IsNull(ds("WL_Name"), "") = IsNull(Dt_List.Rows(n)("WL_Name"), "") AndAlso Val(ds("sPercent")) = Val(Dt_List.Rows(n)("sPercent")) AndAlso IsNull(ds("StepStr"), "") = IsNull(Dt_List.Rows(n)("StepStr"), "") AndAlso ds("ISBz") = False Then
                    qty = qty + ds("Qty")
                    ds("Qty") = qty
                    dv = ds
                    Dt_List.Rows(y)("ISBz") = True
                End If
                y += 1
            Next
            qty = 0
            y = 0
            list.ImportRow(dv)
            dv = Nothing

            'strr = "WL_Name='" & Dt_List.Rows(n)("WL_Name") & "' and sPercent=" & Dt_List.Rows(n)("sPercent")& 
            'Dim dr() As DataRow = Dt_List.Select(strr)
            'For Each ds As DataRow In dr
            '    qty = qty + ds("Qty")
            '    ds("Qty") = qty
            '    dv = ds
            '    Dt_List.Rows.Remove(ds)
            '    Dt_List.AcceptChanges()
            'Next
            'list.ImportRow(dv)
        Next

        Dt_List = list




        R = Dao.LingLiao_SelById(ID)
        If R.IsOk = False Then
            MsgBox(R.Msg)
            Exit Sub
        End If

        R.Dt.Rows(0)("ID") = dt.Rows(0)("ID")
        R.Dt.Rows(0)("Produce_ID") = dt.Rows(0)("Produce_ID")
        R.Dt.Rows(0)("BZ_Qty") = dt.Rows(0)("BZ_Qty")
        R.Dt.Rows(0)("BZ_ZL") = dt.Rows(0)("BZ_ZL")



        R.Dt.Columns.Add("GY_Image", GetType(Byte()))

        R.Dt.Columns.Add("Title")





        If R.Dt.Rows.Count > 0 Then
            If IsNull(R.Dt.Rows(0)("IsJiaLiao"), False) = False Then
                R.Dt.Rows(0)("Title") = "领料单"
            Else
                R.Dt.Rows(0)("Title") = "加料单"
            End If


            If isFirst Then
                If IsNull(R.Dt.Rows(0).Item("GY_ID1"), 0) <> 0 Then
                    Dim Ri As DtReturnMsg = Dao.GY_GetById(IsNull(R.Dt.Rows(0).Item("GY_ID1"), 0))
                    If Ri.IsOk AndAlso Ri.Dt.Rows.Count > 0 Then
                        R.Dt.Rows(0)("GY_Image") = Ri.Dt.Rows(0).Item("GY_Image")
                    End If
                End If
            Else
                If IsNull(R.Dt.Rows(0).Item("GY_ID2"), 0) <> 0 Then
                    Dim Ri As DtReturnMsg = Dao.GY_GetById(IsNull(R.Dt.Rows(0).Item("GY_ID2"), 0))
                    If Ri.IsOk AndAlso Ri.Dt.Rows.Count > 0 Then
                        R.Dt.Rows(0)("GY_Image") = Ri.Dt.Rows(0).Item("GY_Image")
                    End If
                End If
            End If
        End If



        Dt_Header(1) = R.Dt

        Me.DoOperator = DoOperator
        Me.DoWork()
    End Sub







End Class
