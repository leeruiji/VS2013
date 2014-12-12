Imports PClass.PClass
Imports System.Data
Imports System.Text
Public Class F15505_AtMachine_Msg
    Dim dtAt As DataTable

    Public Sub New()

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。

    End Sub

    Public Sub New(ByVal jID As String)

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。
        Bill_ID = jID

        Me.Mode = Mode

    End Sub
    ''' <summary>
    ''' 权限获取
    ''' </summary>
    ''' <remarks></remarks>
    Sub FormCheckRight()
        ID = 15500
        Control_CheckRight(ID, ClassMain.Modify, Cmd_Modify)
        Control_CheckRight(ID, ClassMain.Del, Cmd_Del)
    End Sub
    Private Sub F15501_At_Msg_Load() Handles Me.Me_Load
        FormCheckRight()
        Ch_Name = GetBillTypeName(ID)
        'Dao.Balance_DB_NAME = Ch_Name
        Me.Title = Ch_Name
        Me_Refresh()
        If Mode = Mode_Enum.Add Then
            Bill_ID = ""
            TB_Founder.Text = PClass.PClass.User_Name
            TB_Founder.Tag = PClass.PClass.User_ID
        Else
            'Try
            '    GetAtMachineTime(TB_IP.Text, TB_Port.Text, TB_ID.Text)
            'Catch ex As Exception
            '    Return
            'End Try
        End If
        TB_ID.Text = Bill_ID
        Fg1.Rows.Count = 1

    End Sub

    Protected Sub Me_Refresh()
        Dim msg As DtReturnMsg = At_GetById(Bill_ID)
        If msg.IsOk Then
            dtAt = msg.Dt
            SetForm(msg.Dt)
        End If
    End Sub

#Region "表单信息"
    ''' <summary>
    ''' 获取表单内容
    ''' </summary>
    ''' <remarks></remarks>
    Protected Function GetForm() As DataTable
        Dim dt As DataTable
        dt = dtAt.Clone
        If Not dt Is Nothing Then
            dt.Clear()
            Dim dr As DataRow = dt.NewRow
            dr("At_ID") = TB_ID.Text
            dr("At_Name") = TB_Name.Text

            dr("AT_IP") = TB_IP.Text
            dr("AT_Port") = TB_Port.Text
            dr("AT_Remark") = TB_Remark.Text

            dr("At_FindHelper") = StrGetPinYin(TB_Name.Text)

            dr("Founder") = TB_Founder.Tag
            dr("Found_Date") = DP_Found_Date.Value

            dr("UPD_USER") = PClass.PClass.User_ID
            dr("UPD_DATE") = DP_UPD_DATE.Value

            dt.Rows.Add(dr)
        End If
        Return dt
    End Function

    ''' <summary>
    ''' 设置表单内容
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub SetForm(ByVal dt As DataTable)
        If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
            TB_ID.Text = IsNull(dt.Rows(0)("At_ID"), "")
            TB_Name.Text = IsNull(dt.Rows(0)("At_Name"), "")

            TB_IP.Text = IsNull(dt.Rows(0)("AT_IP"), "")
            TB_Port.Text = IsNull(dt.Rows(0)("AT_Port"), 0)
            TB_Remark.Text = IsNull(dt.Rows(0)("At_Remark"), "")


            TB_Founder.Tag = IsNull(dt.Rows(0)("Founder"), "")
            TB_Founder.Text = PClass.PClass.UserIDtoDisplayName(IsNull(dt.Rows(0)("Founder"), ""))
            If Not dt.Rows(0)("Found_Date") Is DBNull.Value Then
                DP_Found_Date.Text = dt.Rows(0)("Found_Date")
            End If
            DP_Found_Date.Text = IsNull(dt.Rows(0)("Found_Date"), "")

            TB_UPD_USER.Text = PClass.PClass.UserIDtoDisplayName(IsNull(dt.Rows(0)("UPD_User"), ""))
            TB_UPD_USER.Tag = IsNull(dt.Rows(0)("UPD_User"), "")
            If Not dt.Rows(0)("UPD_DATE") Is DBNull.Value Then
                DP_UPD_DATE.Text = dt.Rows(0)("UPD_DATE")
            End If




        End If

    End Sub

#End Region


#Region "工具栏按钮"


    Private Sub Cmd_Modify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Modify.Click

        If CheckForm() Then ShowConfirm("是否保存机具 [" & TB_Name.Text & "] 的修改?", AddressOf SaveAt)
    End Sub

    Protected Sub SaveAt()

        Dim R As MsgReturn

        If Me.Mode = Mode_Enum.Add Then
            R = At_Add(GetForm())
        Else
            R = At_Save(GetForm())
        End If
        If R.IsOk Then
            LastForm.ReturnId = TB_ID.Text
            Me.Close()
        Else
            ShowErrMsg(R.Msg)
        End If
    End Sub
    Protected Function CheckForm() As Boolean
        If TB_ID.Text = "" Then
            ShowErrMsg("机具编号不能为空")
            Return False
        End If

        If TB_Name.Text = "" Then
            ShowErrMsg("机具名称不能为空")
            Return False
        End If
        Return True
    End Function




    Private Sub Cmd_Del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Del.Click
        ShowConfirm("是否删除机具 [" & TB_Name.Text & "]?", AddressOf DelAt)
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub DelAt()
        Dim msg As MsgReturn = At_Del(TB_ID.Text)
        If msg.IsOk Then
            Me.Close()
        Else
            ShowErrMsg(msg.Msg)
        End If

    End Sub

    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub
#End Region



    Private Sub Cmd_GetTime_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_GetTime.Click
        Try
            ShowOk(ZKS_GetAtMachineTime(TB_IP.Text, TB_Port.Text, TB_ID.Text))
        Catch ex As Exception
            ShowErrMsg(ex.ToString)
        End Try
    End Sub

    Private Sub Cmd_SetTime_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_SetTime.Click
        Try
            ShowOk(ZKS_SetAtMachineTime(TB_IP.Text, TB_Port.Text, TB_ID.Text))
        Catch ex As Exception
            ShowErrMsg(ex.ToString)
        End Try
    End Sub

    Private Sub Cmd_DataIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_DataIn.Click
        PClass.PClass.CaptureFromImageToPicture(Me, Pic_From)
        LabelMsg.BringToFront()
        ProgressBar1.BringToFront()
        Pic_From.BringToFront()
        Pic_From.Visible = True
        Tool_Top.Visible = False
        Me.Refresh()
        LabelMsg.Text = "开始获取数据"
        N = 0
        BW.RunWorkerAsync()
    End Sub


    Private Sub Cmd_DataSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CaptureFromImageToPicture(Me, Pic_From)
        LabelMsg.BringToFront()
        ProgressBar1.BringToFront()
        Pic_From.BringToFront()
        Pic_From.Visible = True
        Tool_Top.Visible = False
        LabelMsg.Text = "开始发送名单"
        N = 1
        BW.RunWorkerAsync()
    End Sub

#Region "BW"
    Dim N As Integer = 0
    Private Sub BW_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BW.DoWork
        Dim StartTime As Date = DateTime.Now   '获得开始时间 
        Try
            Dim s As String = ""
            Select Case N
                Case 0
                    s = ZKS_LoadAtMachineCard(TB_IP.Text, TB_Port.Text, TB_ID.Text, BW)
                Case 1
                    s = ZKS_SendAtMachineName(TB_IP.Text, TB_Port.Text, TB_ID.Text, BW)
                Case 2
                    s = ZKS_DeleteAtLog(TB_IP.Text, TB_Port.Text, BW)
                Case 3
                    s = DeleteAtMachineName(TB_IP.Text, TB_Port.Text, BW)

            End Select

            MsgBox(s & vbCrLf & "共用时间:" & Now.Subtract(StartTime).TotalSeconds & "秒", MsgBoxStyle.Information, Me.Text)
        Catch ex As Exception
            FileClose(1)
            MsgBox(ex.ToString)
            Pic_From.Visible = False
            Tool_Top.Visible = True
        End Try
    End Sub

    Private Sub BW_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BW.ProgressChanged
        ProgressBar1.Value = 1
        LabelMsg.Text = e.UserState.ToString
    End Sub

    Private Sub BW_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BW.RunWorkerCompleted
        LabelMsg.Text = "加载数据完毕!"
        Pic_From.Visible = False
        Tool_Top.Visible = True
    End Sub
#End Region

#Region "获取白名单"
    Private Sub Cmd_GetCard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_GetCard.Click
        Dim ld As List(Of Card) = ZKS_GetATCards(TB_IP.Text, TB_Port.Text)
        Fg1.Rows.Count = 1
        Dim i As Integer = 1
        For Each c As Card In ld
            Fg1.AddRow()
            Fg1.ReAddIndex()
            Fg1.Item(i, "Employee_Name") = c.UserName
            Fg1.Item(i, "Card") = c.UserID
            i = i + 1
        Next
    End Sub
    Private Sub Cmd_ClearCards_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_ClearCards.Click
        CaptureFromImageToPicture(Me, Pic_From)
        LabelMsg.BringToFront()
        ProgressBar1.BringToFront()
        Pic_From.BringToFront()
        Pic_From.Visible = True
        N = 3
        LabelMsg.Text = "开始获取数据"
        BW.RunWorkerAsync()
        'Dim R As MsgReturn = ClearATCards(TB_IP.Text, TB_Port.Text)
        'If R.IsOk Then
        '    Fg1.Rows.Count = 1
        '    ShowOk("删除成功")
        'Else
        '    ShowErrMsg(R.Msg)
        'End If
    End Sub
#End Region



    Private Sub Cmd_ClearLog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_ClearLog.Click
        CaptureFromImageToPicture(Me, Pic_From)
        LabelMsg.BringToFront()
        ProgressBar1.BringToFront()
        Pic_From.BringToFront()
        Pic_From.Visible = True
        N = 2
        LabelMsg.Text = "开始获取数据"
        BW.RunWorkerAsync()
        'Dim R As MsgReturn = ClearATLog(TB_IP.Text, TB_Port.Text)
        'If R.IsOk Then
        '    Fg1.Rows.Count = 1
        '    ShowOk("删除成功")
        'Else
        '    ShowErrMsg(R.Msg)
        'End If
    End Sub

    Private Sub Cmd_ClearAdmin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_ClearAdmin.Click
        ShowConfirm("是否确定清除改机器的管理员设置？", AddressOf ClearAdmin)
    End Sub
    Public Sub ClearAdmin()
        ZKS_ClearAdmin(TB_IP.Text, Val(TB_Port.Text), Val(TB_ID.Text))
    End Sub
End Class
