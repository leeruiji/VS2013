Imports PClass.PClass
Public Class FormPwd

    Private Sub CmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSave.Click
        Dim Cnn As New System.Data.SqlClient.SqlConnection
        Dim Da As New System.Data.SqlClient.SqlDataAdapter
        Dim Dt As New System.Data.DataTable

        If Trim(TextBox_Pwd1.Text) = "" Or Trim(TextBox_Pwd2.Text) = "" Then
            MsgBox("请输入密码!", MsgBoxStyle.Exclamation, "提示!")
            TextBox_Pwd1.Focus()
            Exit Sub
        End If
        If Trim(TextBox_Pwd1.Text) <> Trim(TextBox_Pwd2.Text) Then
            MsgBox("您两次输入的密码不一致!", MsgBoxStyle.Exclamation, "提示!")
            TextBox_Pwd2.Focus()
            Exit Sub
        End If
        Dim R As DtReturnMsg = SqlStrToDt("select top 1 User_ID,User_Name,User_Password from User_Info where User_Id='" & Trim(User_Id) & "'", Cnn, Da)
        If R.IsOk = True AndAlso R.Dt.Rows.Count > 0 Then
            Dt = R.Dt
            '核对密码
            If Dt.Rows(0).Item("User_Password") <> EnDes(TextBox2.Text, StrToMD5(User_Name.ToUpper.Trim)) Then
                MsgBox("原密码输入不正确!", MsgBoxStyle.Exclamation, "提示!")
                TextBox2.Focus()
                Dt.Dispose()
                Da.Dispose()
                Cnn.Dispose()
                Exit Sub
            End If
        Else
            MsgBox("你的账号已被删除!程序自动退出!", MsgBoxStyle.Exclamation, "提示!")
            Dt.Dispose()
            Da.Dispose()
            Cnn.Dispose()
            End
        End If
        Dt.Rows(0).Item("User_Password") = EnDes(TextBox_Pwd1.Text, StrToMD5(User_Name.ToUpper.Trim))
        If DtToUpDate(Dt, Cnn, Da) Then
            Dt.Dispose()
            Da.Dispose()
            Cnn.Dispose()
            MsgBox("修改密码成功!", MsgBoxStyle.Information, "提示!")
            Dispose()
        Else
            MsgBox("修改密码失败!", MsgBoxStyle.Exclamation, "提示!")
            Dt.Dispose()
            Da.Dispose()
            Cnn.Dispose()
        End If
    End Sub

    Private Sub FormPwd_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        TextBox1.Text = User_Name

    End Sub

    Private Sub CmdEnd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdEnd.Click
        Dispose()
    End Sub
End Class