Imports PClass.PClass
Public Class FormDBSelect
    Dim Loaded As Boolean = False
    Dim IsNew As Boolean = True
    Private Sub FormDBSelect_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FG_Refresh()
        Loaded = True
    End Sub


    Sub FG_Refresh()
        Fg1.SqlToFGByChat("select DB_Msg,DB_Name,DB_Active from " & DB_Select)
    End Sub




    Sub GetMsg()
        If Fg1.RowSel > 0 Then
            Dim R As DtReturnMsg = SqlChatToDt("select * from " & DB_Select & " where db_msg='" & Fg1.Item(Fg1.RowSel, 1) & "'")
            If R.IsOk = False Then
                MsgBox("加载错误!" & vbCrLf & R.Msg, MsgBoxStyle.Exclamation, Me.Text)
                Exit Sub
            End If
            If R.Dt.Rows.Count > 0 Then
                T_Msg.Text = R.Dt.Rows(0).Item("DB_Msg")
                T_DB.Text = R.Dt.Rows(0).Item("DB_Name")
                T_IP.Text = R.Dt.Rows(0).Item("DB_IP")
                T15002_User.Text = R.Dt.Rows(0).Item("DB_User")
                T_Pwd.Text = DeDes(R.Dt.Rows(0).Item("DB_Pwd"), AppDes)
                CheckBox_Active.Checked = R.Dt.Rows(0).Item("DB_Active")
                IsNew = False
            End If
            R.Dt.Dispose()
        End If

    End Sub

    Private Sub CmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSave.Click

        Dim Cnn As New SqlClient.SqlConnection
        Dim Da As New SqlClient.SqlDataAdapter
        'Try
        Dim R As DtReturnMsg = SqlChatToDt("select * from " & DB_Select & " where db_msg='" & T_Msg.Text & "'", Cnn, Da)
        If R.IsOk = False Then
            MsgBox("加载错误!" & vbCrLf & R.Msg, MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        End If
        Dim Dt As DataTable = R.Dt
        If Dt.Rows.Count > 0 Then
            Dt.Rows(0).Item("DB_Name") = T_DB.Text
            Dt.Rows(0).Item("DB_IP") = T_IP.Text
            Dt.Rows(0).Item("DB_User") = T15002_User.Text
            Dt.Rows(0).Item("DB_Pwd") = EnDes(T_Pwd.Text, AppDes)
            Dt.Rows(0).Item("DB_Active") = CheckBox_Active.Checked
        Else
            Dim MyRow As System.Data.DataRow = Dt.NewRow
            MyRow("DB_Msg") = T_Msg.Text
            MyRow("DB_Name") = T_DB.Text
            MyRow("DB_IP") = T_IP.Text
            MyRow("DB_User") = T15002_User.Text
            MyRow("DB_Pwd") = EnDes(T_Pwd.Text, AppDes)
            MyRow("DB_Active") = False
            Dt.Rows.Add(MyRow)
        End If
        If DtToUpDate(Dt, Cnn, Da) Then
            MsgBox("记录保存成功!", MsgBoxStyle.Information, "提示!")
            Dt.Dispose()
            Da.Dispose()
            Cnn.Dispose()
        Else
            MsgBox("记录保存失败!", MsgBoxStyle.Exclamation, "提示!")
            Dt.Dispose()
            Da.Dispose()
            Cnn.Dispose()
        End If
        If CheckBox_Active.Checked Then MainWindow.ReLoad = True
        FG_Refresh()

    End Sub


    Private Sub CmdEnd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdEnd.Click
        Close()
    End Sub


    Private Sub Cmd_Active_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Active.Click
        If T_Msg.Text = "" Or IsNew Then MsgBox("套帐还没保存不能激活!", MsgBoxStyle.Exclamation, "提示!") : Exit Sub
        If MsgBox("是否要激活[" & T_Msg.Text & "]套帐?激活之后所有用户访问都会使用该帐套!", MsgBoxStyle.Question + MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.Yes Then
            Try
                RunSQLChat("update " & DB_Select & " set DB_Active=0" & vbCrLf & "update " & DB_Select & "  set DB_Active=1 where db_msg='" & T_Msg.Text & "'", True)
            Catch ex As Exception
                MsgBox("激活套帐失败!" & vbCrLf & ex.Message, MsgBoxStyle.Exclamation, Me.Text)
                Exit Sub
            End Try
            MsgBox("激活套帐成功,关闭程序后即可使用!", MsgBoxStyle.Information, "提示!")
            MainWindow.ReLoad = True
        End If
        FG_Refresh()
        Fg1.RowSel = 1
        ' GetMsg()
    End Sub

    Private Sub T_IP_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_IP.TextChanged
        IsNew = True
    End Sub

    Private Sub T_Msg_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_Msg.TextChanged
        IsNew = True
    End Sub

    Private Sub T15002_User_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T15002_User.TextChanged
        IsNew = True
    End Sub

    Private Sub T_Pwd_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_Pwd.TextChanged
        IsNew = True
    End Sub

    Private Sub T_DB_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_DB.TextChanged
        IsNew = True
    End Sub





 

    Private Sub Fg1_SelChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fg1.SelChange
        If Loaded Then
            GetMsg()
        End If
    End Sub
End Class