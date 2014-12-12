Imports PClass.PClass
Imports System.Data
Imports System.Text
Public Class F99006_Job_Msg
    Dim jobID As String = ""
    Dim dtJob As DataTable

    Public Sub New()

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。

    End Sub

    Public Sub New(ByVal jID As String)
        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        ' 在 InitializeComponent() 调用之后添加任何初始化。
        jobID = jID
        Me.Mode = Mode
    End Sub
    ''' <summary>
    ''' 权限获取
    ''' </summary>
    ''' <remarks></remarks>
    Sub FormCheckRight()
        ID = 15002
        Control_CheckRight(ID, ClassMain.Modify, Cmd_Modify)
        Control_CheckRight(ID, ClassMain.Del, Cmd_Del)
    End Sub
    Private Sub F99006_Job_Msg_Me_Load() Handles Me.Me_Load
        FormCheckRight()
        If Mode = Mode_Enum.Add Then
            If CheckRight(ID, ClassMain.Add) = False Then Me.ShowErrMsg("没有权限添加!", True) : Exit Sub
            TB_ID.Text = Job_GetNewID()
            jobID = 0
            Cmd_Del.Visible = False
            TB_Grade.Text = 6
        End If
        Me_Refresh()
    End Sub

    Protected Sub Me_Refresh()
        Dim msg As DtReturnMsg = Job_GetById(jobID)
        If msg.IsOk Then
            dtJob = msg.Dt
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
        dt = dtJob.Clone
        If Not dt Is Nothing Then
            dt.Clear()
            Dim dr As DataRow = dt.NewRow
            If Mode <> Mode_Enum.Add Then dr("ID") = jobID
            dr("Job_No") = TB_ID.Text
            dr("Job_Name") = TB_Name.Text
            dr("Job_Dept") = TB_Dept.Tag
            dr("Job_Grade") = Val(TB_Grade.Text)
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
            TB_ID.Text = IsNull(dt.Rows(0)("Job_No"), "")
            TB_Name.Text = IsNull(dt.Rows(0)("Job_Name"), "")
            TB_Dept.Tag = IsNull(dt.Rows(0)("Job_Dept"), "")
            TB_Grade.Text = IsNull(dt.Rows(0)("Job_Grade"), "")

            If TB_Dept.Tag.ToString.Length = 7 Then
                Dim deptID As String = ""
                deptID = TB_Dept.Tag.ToString.Substring(0, 4)
                Dim msg As DtReturnMsg = Department_GetDeptById(deptID)
                If msg.IsOk Then
                    TB_Dept.Text = msg.Dt.Rows(0)("Dept_Name") & "/" & IsNull(dt.Rows(0)("Dept_Name"), "")
                End If
            ElseIf TB_Dept.Tag.ToString.Length = 4 Then

                TB_Dept.Text = IsNull(dt.Rows(0)("Dept_Name"), "")
            End If

        End If

    End Sub

#End Region


#Region "工具栏按钮"
    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub

    Private Sub Cmd_Modify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Modify.Click

        If CheckForm() Then ShowConfirm("是否保存职位 [" & TB_Name.Text & "] 的修改?", AddressOf SaveJob)
    End Sub

    Protected Sub SaveJob()
        Dim R As MsgReturn
        If Me.Mode = Mode_Enum.Add Then
            R = Job_Add(GetForm())
        Else
            R = Job_Save(GetForm())
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
            ShowMsg("职位编号不能为空", "")
            Return False
        End If

        If TB_Name.Text = "" Then
            ShowMsg("职位名称不能为空", "")
            Return False
        End If
        'Try


        '    Integer.Parse(TB_Grade.Text)
        'Catch ex As Exception
        '    ShowMsg("等级必须为整数", Me.Title)
        '    Return False
        'End Try


        Return True
    End Function

    ''' <summary>
    ''' 选择部门
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Btn_ChoseDept_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_ChoseDept.Click

        Dim F As New F99004_Department_Sel
        With F
            .Mode = Mode_Enum.Look
            .P_F_RS_ID = ""
            .P_F_RS_ID2 = ""
        End With
        F_RS_ID = ""
        Me.ReturnId = ""
        Me.ReturnObj = Nothing
        Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F, Me)
        AddHandler VF.ClosedX, AddressOf SetDept
        VF.Show()
    End Sub

    Protected Sub SetDept()
        If Not ReturnId = "" OrElse Not ReturnObj Is Nothing Then
            Me.TB_Dept.Text = Me.ReturnObj
            Me.TB_Dept.Tag = Me.ReturnId
        End If
    End Sub

    Private Sub Cmd_Del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Del.Click
        ShowConfirm("是否删除职位 [" & TB_Name.Text & "]?", AddressOf DelJob)
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub DelJob()
        Dim msg As MsgReturn = Job_Del(jobID)
        If msg.IsOk Then
            LastForm.ReturnId = "0"
            Me.Close()
        Else
            ShowErrMsg(msg.Msg)
        End If
    End Sub
#End Region

#Region "双击获取新编号"
    Private Sub Label_ID_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label_ID.MouseDoubleClick
        If Mode = Mode_Enum.Add Then
            TB_ID.Text = Job_GetNewID()
            TB_Name.Focus()
        End If
    End Sub
#End Region

End Class
