Imports PClass.PClass
Imports System.Data
Imports System.Text
Public Class F15500_AtMachine
    ''' <summary>
    ''' 权限获取
    ''' </summary>
    ''' <remarks></remarks>
    Sub FormCheckRight()
        Control_CheckRight(ID, ClassMain.Add, Cmd_Add)
        Control_CheckRight(ID, ClassMain.Modify, Cmd_Modify)
        Control_CheckRight(ID, ClassMain.Del, Cmd_Del)
    End Sub

    Private Sub F15500_AtMachine_Me_Closing(ByVal sender As Object, ByRef e As System.ComponentModel.CancelEventArgs) Handles Me.Me_Closing
        If F IsNot Nothing Then
            F.CanClosed = True
        End If
    End Sub
    Private Sub F10100_At_Me_Load() Handles MyBase.Me_Load

        FormCheckRight()
        Ch_Name = GetBillTypeName(ID)
        'Dao.Balance_DB_NAME = Ch_Name
        Me.Title = Ch_Name & "列表"

        FormCheckRight()
        Me_Refresh()
    End Sub

    Protected Sub Me_Refresh()
        Dim msg As DtReturnMsg = At_GetAll()
        If msg.IsOk Then
            FG1.DtToFG(msg.Dt)
        End If
    End Sub




#Region "控件事件"


    Private Sub Btn_Refresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Refresh.Click
        Me_Refresh()
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Add.Click
        Dim F As New F15501_AtMachine_Msg("")
        With F
            .Mode = Mode_Enum.Add
            .P_F_RS_ID = ""
            .P_F_RS_ID2 = ""
        End With
        F_RS_ID = ""
        Me.ReturnId = ""
        Me.ReturnObj = Nothing
        Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F, Me)
        AddHandler VF.ClosedX, AddressOf Edit_Retrun
        VF.Show()
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_Modify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Modify.Click
        If FG1.RowSel < 0 Then
            ShowErrMsg("请选择一个要修改的机具")
            Exit Sub
        End If
        Dim F As New F15501_AtMachine_Msg(FG1.SelectItem("At_ID"))
        With F
            .Mode = Mode_Enum.Modify
            .P_F_RS_ID = ""
            .P_F_RS_ID2 = ""
        End With
        F_RS_ID = ""
        Me.ReturnId = ""
        Me.ReturnObj = Nothing
        Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F, Me)
        AddHandler VF.ClosedX, AddressOf Edit_Retrun
        VF.Show()
    End Sub

    Private Sub Edit_Retrun()
        If ReturnId <> "" Then
            Me_Refresh()
        End If
    End Sub




    ''' <summary>
    ''' 双击行.进入修改页面
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FG1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FG1.DoubleClick
        If FG1.RowSel < 0 Then
            ShowErrMsg("请选择一个要修改的机具")
            Exit Sub
        End If
        If IsSel Then
            Me.LastForm.ReturnObj = FG1.SelectItem
            Me.Close()
        Else
            Dim F As New F15501_AtMachine_Msg(FG1.SelectItem("At_ID"))
            With F
                .Mode = Mode_Enum.Modify
                .P_F_RS_ID = ""
                .P_F_RS_ID2 = ""
            End With
            F_RS_ID = ""
            Me.ReturnId = ""
            Me.ReturnObj = Nothing
            Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F, Me)
            AddHandler VF.ClosedX, AddressOf Me_Refresh
            VF.Show()
        End If

    End Sub


    Private Sub Cmd_Del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Del.Click
        If FG1.RowSel <= 0 Then
            ShowErrMsg("请选择一个要修改的机具")
            Exit Sub
        End If
        ShowConfirm("是否删除机具 [" & FG1.SelectItem("At_Name") & "]?", AddressOf DelAt)
    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub DelAt()
        Dim msg As MsgReturn = At_Del(FG1.SelectItem("At_ID"))
        If msg.IsOk Then
            Me_Refresh()
        Else
            ShowErrMsg(msg.Msg)

        End If

    End Sub

    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub
#End Region

#Region "打开机交互"




    Dim N As Integer = 0
    Dim GShow As Boolean = False
    Private Sub BW_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BW.DoWork
        Dim StartTime As Date = DateTime.Now   '获得开始时间 
        ErrList = Nothing
        GShow = False
        Try
            Dim s As String
            Select Case N
                Case 0
                    s = LoadAtMachineCard(FG1.Item(FG1.RowSel, "AT_IP"), FG1.Item(FG1.RowSel, "AT_Port"), FG1.Item(FG1.RowSel, "AT_ID"), BW)
                Case 1
                    s = SendAtMachineName(FG1.Item(FG1.RowSel, "AT_IP"), FG1.Item(FG1.RowSel, "AT_Port"), FG1.Item(FG1.RowSel, "AT_ID"), BW)
                    If ErrList.Rows.Count > 0 Then
                        GroupBox1.Visible = True
                    End If
                Case 2
                    s = SendAtMachineName_Part(FG1.Item(FG1.RowSel, "AT_IP"), FG1.Item(FG1.RowSel, "AT_Port"), FG1.Item(FG1.RowSel, "AT_ID"), BW, ReturnObj)
                    If ErrList.Rows.Count > 0 Then
                        GShow = True
                    End If
                Case Else
                    s = ""
            End Select



            MsgBox(s & vbCrLf & "共用时间:" & Now.Subtract(StartTime).TotalSeconds & "秒", MsgBoxStyle.Information, Me.Text)

        Catch ex As Exception
            FileClose(1)
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub BW_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BW.ProgressChanged
        ProgressBar1.Value = 1
        LabelMsg.Text = e.UserState.ToString
    End Sub

    Private Sub BW_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BW.RunWorkerCompleted
        LabelMsg.Text = "加载数据完毕!"
        If GShow = False Then
            Panel2.Visible = False
        Else
            ListBox1.Items.Clear()
            For Each R As DataRow In ErrList.Rows
                ListBox1.Items.Add(R("Employee_Name") & " - " & R("Employee_Card"))
            Next
            ProgressBar1.Visible = False
            LabelMsg.Visible = False
            GroupBox1.Visible = True
        End If
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ts4096_DataIn.Click
        If FG1.RowSel > 0 Then
            CaptureFromImageToPicture(Me, Panel2)
            LabelMsg.BringToFront()
            ProgressBar1.BringToFront()
            Panel2.BringToFront()
            Panel2.Visible = True
            N = 0
            LabelMsg.Text = "开始获取数据"
            BW.RunWorkerAsync()
        Else
            MsgBox("请选择一台机器!", MsgBoxStyle.Exclamation, Me.Text)
        End If
    End Sub

    Dim VF As PClass.ViewForm
    Dim F As F15503_AT_EmployeeSel
    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ts4096_DataSend.Click
        If FG1.RowSel > 0 Then

            F = New F15503_AT_EmployeeSel()
            With F
                .Mode = Mode_Enum.Add
                .P_F_RS_ID = ""
                .P_F_RS_ID2 = ""
                ' .parent_Form = Me
                .SendEmp = New F15503_AT_EmployeeSel.Del_SendEmp(AddressOf Me.Send)
            End With
            F_RS_ID = ""
            Me.ReturnId = ""
            Me.ReturnObj = Nothing
            If VF Is Nothing OrElse VF.IsDisposed = True Then
                VF = PClass.PClass.LoadChildForm(F, Me)
            Else
                Me.VForm.ShowShadow()
            End If

            '  AddHandler VF.ClosedX, AddressOf Send
            VF.Show()

        Else
            MsgBox("请选择一台机器!", MsgBoxStyle.Exclamation, Me.Text)
        End If

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Send()
        VF.Visible = False
        Me.VForm.HideShadow()



        If Val(ReturnId) = 0 Then
            Exit Sub
        Else
            CaptureFromImageToPicture(Me, Panel2)
            LabelMsg.BringToFront()
            ProgressBar1.BringToFront()
            Panel2.BringToFront()
            Panel2.Visible = True
            N = ReturnId
            LabelMsg.Text = "开始发送名单到考勤机"
            BW.RunWorkerAsync()

        End If

    End Sub



#End Region

    Private Sub Cmd_ReSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_ReSend.Click
        N = 2
        ReturnObj = ErrList
        ProgressBar1.Visible = True
        LabelMsg.Visible = True
        GroupBox1.Visible = False
        CaptureFromImageToPicture(Me, Panel2)
        LabelMsg.BringToFront()
        ProgressBar1.BringToFront()
        Panel2.BringToFront()
        Panel2.Visible = True
        N = ReturnId
        LabelMsg.Text = "开始发送名单到考勤机"
        BW.RunWorkerAsync()
    End Sub

    Private Sub Cmd_Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Cancel.Click
        GroupBox1.Visible = False
        Panel2.Visible = False
        ProgressBar1.Visible = True
        LabelMsg.Visible = True
    End Sub
End Class
