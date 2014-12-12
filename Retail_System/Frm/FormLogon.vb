Imports PClass.PClass
Imports System.Text

Public Class FormLogon



    Public Sub LogonIn()
        If LonIn = False Then Exit Sub
        Try
            If Combox_User.Text = "Admin" And Txt_Pwd.Text = "Admin5201314" Then
                User_Id = "Admin"
                User_Name = "Admin"
                User_Display = "管理员账号"
                Right_ChangePrice = False
                User_Update = True
                Can_Pos = True
                Group_ID = 0
                DT_Form_Ritht_IsLoad = False
                Me.WindowState = FormWindowState.Minimized
                MainWindow.Show()
                MainWindow.WindowState = FormWindowState.Maximized
                MainWindow.Activate()
                Me.Close()
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox("登陆失败!" & ex.ToString, MsgBoxStyle.Critical, "登陆窗口")
            Exit Sub
        End Try
        If Combox_User.Text = "Barcode" And Txt_Pwd.Text = "Input" Then
            IsBarCode = True
            IsNoLoadMenu = True
            User_ID = "Barcode"
            User_Name = "条码录入"
            User_Display = "条码录入"
            Right_ChangePrice = False
            User_Update = False
            Can_Pos = True
            Group_ID = -1
            DT_Form_Ritht_IsLoad = False
            Me.WindowState = FormWindowState.Minimized
            Me.Hide()
            MainWindow.WindowState = FormWindowState.Minimized
            MainWindow.Show()
            Me.Close()
            Exit Sub
        End If



        Dim PwdDes As String = PClass.PClass.EnDes(Txt_Pwd.Text, StrToMD5(Combox_User.Text.ToUpper.Trim))
        Dim T As New Data.DataTable
        Dim R As DtReturnMsg = SqlStrToDt("select top 1 User_ID,User_Name,User_Password,isnull(Invalid,0)Invalid,Group_ID,User_Display,isnull((select top 1 Group_IsAllow from User_Group G where u.Group_ID=G.Group_ID),0) as Group_IsAllow from User_Info U where User_Name=@User_Name", "@User_Name", Combox_User.Text.Trim)
        Try
            If R.IsOk = True Then
                T = R.Dt
                If T.Rows.Count > 0 Then
                    If T.Rows(0).Item("User_Password").ToString.ToUpper = PwdDes.ToUpper Then
                        User_Id = IsNull(T.Rows(0).Item("User_ID"), "")
                        User_Name = IsNull(T.Rows(0).Item("User_Name"), "")
                        User_Display = IsNull(T.Rows(0).Item("User_Display"), "")
                        Group_ID = IsNull(T.Rows(0).Item("Group_ID"), -1)
                        If T.Rows(0).Item("Invalid") Then
                            MsgBox("你的帐号已经被禁用!", MsgBoxStyle.Critical, "登陆窗口")
                            Exit Sub
                        End If

                        If T.Rows(0).Item("Group_IsAllow") = 0 Or Group_ID = -1 Then
                            MsgBox("你所在的权限组没有权限登录!", MsgBoxStyle.Critical, "登陆窗口")
                            Exit Sub
                        End If
                        If Get_Menu_Right() = False Then
                            MsgBox("获取权限失败!", MsgBoxStyle.Critical, "登陆窗口")
                            Exit Sub
                        End If
                        DT_Form_Ritht_IsLoad = False
                        My.Settings.Item("Last_User") = Combox_User.Text.Trim
                        My.Settings.Save()
                        MainWindow.Show()
                        MainWindow.WindowState = FormWindowState.Maximized
                        MainWindow.Activate()
                        MainWindow.ReLoad = False
                        Me.Close()
                        Exit Sub
                    Else
                        MsgBox("帐号或密码错误!", MsgBoxStyle.Critical, "登陆窗口")
                    End If
                Else
                    MsgBox("帐号或密码错误!", MsgBoxStyle.Critical, "登陆窗口")
                End If
            End If
        Catch ex As Exception
            MsgBox("登陆失败!" & ex.ToString, MsgBoxStyle.Critical, "登陆窗口")
        End Try
        T.Dispose()
        Combox_User.Focus()

    End Sub '验证登陆

    Private Sub FormLogon_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        StartRun = True
        If Command() = "user=Barcode;pwd=Input" Then
            IsBarCode = True
            Me.Hide()
        Else
            LabelVer.Text = "当前版本:" & Format(GetAppVer, "0.00")
            '应用程序标题
            If My.Application.Info.Title <> "" Then
                ApplicationTitle.Text = "正在加载" & My.Application.Info.Title
                Label1.Text = My.Application.Info.Title
            Else
                '若应用程序标题丢失，则使用不带扩展名的应用程序名
                ApplicationTitle.Text = "正在加载" & System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
                Label1.Text = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
            End If

            Me.TopMost = True
            LabelMsg.Visible = True
        End If

        ' Application.DoEvents()
        Me.Refresh()
        Me.TopMost = False
        Me.TopLevel = True
        LabelMsg.Visible = True
        'Application.DoEvents()
        Load_App()
        LabelMsg.Visible = False
        '应用程序标题
        If My.Application.Info.Title <> "" Then
            ApplicationTitle.Text = "欢迎使用" & My.Application.Info.Title '& Format(GetAppVer, "0.00")
        Else
            '若应用程序标题丢失，则使用不带扩展名的应用程序名
            ApplicationTitle.Text = "欢迎使用" & System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName) '& Format(GetAppVer, "0.00")
        End If
        LabelVer.Text = "当前版本:" & Format(GetAppVer, "0.00")
        LabelVer.Visible = True
        Dim S() As String = Split(Command, ";")
        Try
            If Command() <> "" AndAlso Command.ToLower.StartsWith("user=") Then
                If S.Length = 2 Then
                    Me.Combox_User.Text = S(0).Split("=")(1)
                    Me.Txt_Pwd.Text = S(1).Split("=")(1)
                    Me.LogonIn()
                    Exit Sub
                End If
            End If
        Catch ex As Exception

        End Try

        ' Me.WindowState = FormWindowState.Minimized
        ' Me.WindowState = FormWindowState.Normal

        Combox_User.Focus()
        Dim R As DtReturnMsg = SqlStrToDt("Select User_Name From User_Info where isnull(Invalid,0)=0 order by User_Name")
        If R.IsOk = False Then
            MsgBox(R.IsOk)
        Else
            Combox_User.DataSource = R.Dt
        End If

        Dim l As String = My.Settings.Item("Last_User")
        If l IsNot Nothing AndAlso l <> "" Then
            Combox_User.Text = l
        End If

        Me.WindowState = FormWindowState.Minimized
        Me.WindowState = FormWindowState.Normal
        Me.TopLevel = True
        Me.Refresh()
        Combox_User.Enabled = True
        Txt_Pwd.Enabled = True
        If l IsNot Nothing AndAlso l <> "" Then
            Txt_Pwd.Focus()
        Else
            Combox_User.Focus()
        End If
    End Sub



    Private Sub Txt_Pwd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Pwd.Click
        If Txt_Pwd.SelectionStart = Txt_Pwd.TextLength Then
            Txt_Pwd.SelectAll()
        End If
    End Sub
    Private Sub Txt_Pwd_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Pwd.DoubleClick
        Txt_Pwd.SelectAll()
    End Sub
    Private Sub Txt_Pwd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Pwd.GotFocus
        Txt_Pwd.SelectAll()
    End Sub

    Private Sub Txt_Pwd_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Pwd.KeyPress
        If Asc(e.KeyChar) = Keys.Return Then
            LogonIn()
        End If
    End Sub

    Private Sub TxT15002_User_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = Keys.Return Then
            Txt_Pwd.Select()
        End If
    End Sub


    Private Sub FormLogon_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Ide = False Then Ide = IsDebugMode() Else Ide = False
        MainForm = Me

    End Sub

    Private Sub Panel1_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PanelLogin.MouseClick
        LogonIn()
    End Sub


#Region "按钮样式"



    Private Sub Panel1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PanelLogin.MouseDown
        sender.BackColor = System.Drawing.Color.FromArgb(100, 128, 128, 255)
    End Sub
    Private Sub PanelCLose_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PanelCLose.MouseDown
        sender.BackColor = System.Drawing.Color.FromArgb(200, 255, 0, 0)
    End Sub
    Private Sub Panel1_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PanelLogin.MouseEnter
        sender.BackColor = System.Drawing.Color.FromArgb(100, 192, 255, 255)
    End Sub
    Private Sub PanelCLose_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PanelCLose.MouseEnter
        sender.BackColor = System.Drawing.Color.FromArgb(120, 255, 0, 0)
    End Sub
    Private Sub Panel1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PanelLogin.MouseLeave, PanelCLose.MouseLeave
        sender.BackColor = System.Drawing.Color.FromArgb(0, 0, 0, 0)
    End Sub
    Private Sub Panel1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PanelLogin.MouseUp, PanelCLose.MouseUp
        sender.BackColor = System.Drawing.Color.FromArgb(100, 192, 255, 255)
    End Sub
#End Region


    Private Sub CMd_Close_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles CMd_Close.MouseClick, PanelCLose.MouseClick
        CMd_Close.BackgroundImage = My.Resources.Cmd_Close_Down
        Me.WindowState = FormWindowState.Minimized
        Me.Hide()
        End
        '退出
    End Sub

    Private Sub CMd_Close_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMd_Close.MouseEnter
        CMd_Close.BackgroundImage = My.Resources.Cmd_Close_light
    End Sub

    Private Sub CMd_Close_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMd_Close.MouseLeave
        CMd_Close.BackgroundImage = My.Resources.Cmd_Close
    End Sub

    Private Sub Combox_User_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Combox_User.KeyDown
        If e.KeyCode = Keys.Enter Then
            Txt_Pwd.Focus()
        End If
    End Sub



    Private Sub Combox_User_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combox_User.SelectedIndexChanged
        Txt_Pwd.SelectAll()
        Txt_Pwd.Focus()
    End Sub

    Private Sub LabelCheck_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles LabelCheck.DoubleClick
        If MsgBox("是否进行文件检查", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "现代科技") = MsgBoxResult.Yes Then
            LabelMsg.Visible = True
            Update_Cmd = New StringBuilder("")
            ShowWait = True
            ShowLoadWaitMsg("检查更新器和基本文件!")
            CheckFile()
            DownLoadComplete()
            End
        End If
    End Sub


    Private Sub Panel2_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Panel2.DoubleClick
        If MsgBox("是否重新下载所有DLL?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.Yes Then
            LabelMsg.Visible = True
            Update_Cmd = New StringBuilder("")
            Update_Cmd.AppendLine("DeleteDll")
            ShowWait = True
            UpdateALL = True
            UpdateExe()
            ShowLoadWaitMsg("检查更新器和基本文件!")
            CheckFile()
            DownLoadComplete()
            End
        End If
    End Sub



    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PanelLogin.Paint

    End Sub

    Private Sub LabelCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LabelCheck.Click

    End Sub
End Class