Imports PClass.PClass
Imports System.Data
Imports System.Text
Public Class F15504_AtMachine
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
        Dim F As New F15505_AtMachine_Msg("")
        With F
            .Mode = Mode_Enum.Add
            .P_F_RS_ID = ""
            .P_F_RS_ID2 = ""
        End With
        F_RS_ID = ""
        Me.ReturnId = ""
        Me.ReturnObj = Nothing
        Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F, Me)
        AddHandler VF.ClosedX, AddressOf Me_Refresh
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
        Dim F As New F15505_AtMachine_Msg(FG1.SelectItem("At_ID"))
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
            Dim F As New F15505_AtMachine_Msg(FG1.SelectItem("At_ID"))
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

    Private Sub BW_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BW.DoWork
        Dim StartTime As Date = DateTime.Now   '获得开始时间 
        Try
            Dim s As String
            Select Case N
                Case 0
                    s = ZKS_LoadAtMachineCard(FG1.Item(FG1.RowSel, "AT_IP"), FG1.Item(FG1.RowSel, "AT_Port"), FG1.Item(FG1.RowSel, "AT_ID"), BW)
                Case 1
                    s = ZKS_SendAtMachineName(FG1.Item(FG1.RowSel, "AT_IP"), FG1.Item(FG1.RowSel, "AT_Port"), FG1.Item(FG1.RowSel, "AT_ID"), BW)
                Case 2
                    s = ZKS_SendAtMachineName_Part(FG1.Item(FG1.RowSel, "AT_IP"), FG1.Item(FG1.RowSel, "AT_Port"), FG1.Item(FG1.RowSel, "AT_ID"), BW, ReturnObj)
                Case 3
                    s = ZKS_DeleteAtMachineName_Part(FG1.Item(FG1.RowSel, "AT_IP"), FG1.Item(FG1.RowSel, "AT_Port"), FG1.Item(FG1.RowSel, "AT_ID"), BW, ReturnObj, False)
                Case 4
                    s = ZKS_ExportUserinfo(FG1.Item(FG1.RowSel, "AT_IP"), FG1.Item(FG1.RowSel, "AT_Port"), FG1.Item(FG1.RowSel, "AT_ID"), BW)
                Case 5
                    s = ZKS_ImportUserinfo(FG1.Item(FG1.RowSel, "AT_IP"), FG1.Item(FG1.RowSel, "AT_Port"), FG1.Item(FG1.RowSel, "AT_ID"), BW)
                Case 6
                    s = ZKS_SetAdmin(FG1.Item(FG1.RowSel, "AT_IP"), FG1.Item(FG1.RowSel, "AT_Port"), FG1.Item(FG1.RowSel, "AT_ID"), BW, ReturnObj)

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
        Panel2.Visible = False
        '  MsgBox(M.ToString)
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
                '  .parent_Form_ZKS = Me
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

#Region "导出导入"


    Private Sub Cmd_Export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Export.Click
        If FG1.RowSel > 0 Then
            ShowConfirm("是否导出数据？导出数据将覆盖数据库原有数据。", AddressOf ExportData)
        Else
            MsgBox("请选择一台机器!", MsgBoxStyle.Exclamation, Me.Text)
        End If
    End Sub

    Private Sub ExportData()
        CaptureFromImageToPicture(Me, Panel2)
        LabelMsg.BringToFront()
        ProgressBar1.BringToFront()
        Panel2.BringToFront()
        Panel2.Visible = True
        N = 4
        LabelMsg.Text = "开始获取数据"
        BW.RunWorkerAsync()
    End Sub

    Private Sub CMd_Import_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMd_Import.Click
        If FG1.RowSel > 0 Then
            ShowConfirm("是否导入数据？导入数据将覆盖机器原有数据。", AddressOf ImportData)
        Else
            MsgBox("请选择一台机器!", MsgBoxStyle.Exclamation, Me.Text)
        End If
    End Sub
    Private Sub ImportData()
        CaptureFromImageToPicture(Me, Panel2)
        LabelMsg.BringToFront()
        ProgressBar1.BringToFront()
        Panel2.BringToFront()
        Panel2.Visible = True
        N = 5
        LabelMsg.Text = "开始获取数据"
        BW.RunWorkerAsync()
    End Sub
#End Region
End Class
