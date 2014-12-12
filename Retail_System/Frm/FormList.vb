
Imports PClass.PClass
Public Class FormList

    Sub LoadForm()
        Dim i As Integer = 0
        Dim d As String = ""
        Dim C As List(Of cBillType) = GetBillTypeList(ComboBox1.SelectedIndex)
        Fg1.Rows.Count = 1
        Fg1.Rows.Count = C.Count + 1
        Fg1.ReAddIndex()

        For Each DllUpdate As cBillType In C
            i = i + 1
            Try
                Fg1.Item(i, "BillName") = IO.Path.GetFileName(DllUpdate.BillName)
                Fg1.Item(i, "BillType") = DllUpdate.BillType
                Fg1.Item(i, "FormType") = DllUpdate.FormType

                Fg1.Item(i, "FileName") = DllUpdate.Dll.FileName
                Fg1.Item(i, "FormName") = DllUpdate.Dll.FormName.Name
                If DllUpdate.Dll.ModifyForm IsNot Nothing Then
                    Fg1.Item(i, "ModifyForm") = DllUpdate.Dll.ModifyForm.Name
                Else
                    Fg1.Item(i, "ModifyForm") = ""
                End If


                Fg1.Item(i, "NVer") = DllUpdate.Dll.Ver

      
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Next
    End Sub

    Private Sub FormList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ComboBox1.SelectedIndex = 0
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        LoadForm()
    End Sub
End Class