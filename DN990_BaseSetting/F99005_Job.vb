Imports PClass.PClass
Imports System.Data
Imports System.Text
Public Class F99005_Job

    ''' <summary>
    ''' 权限获取
    ''' </summary>
    ''' <remarks></remarks>
    Sub FormCheckRight()
        Control_CheckRight(ID, ClassMain.Add, Cmd_Add)
        Control_CheckRight(ID, ClassMain.Modify, Cmd_Modify)
        Control_CheckRight(ID, ClassMain.Del, Cmd_Del)
    End Sub
    Private Sub F99005_Job_Me_Load() Handles Me.Me_Load
        FormCheckRight()
        If Cb_Dept.IDValue <> "" Then
            Cb_Dept.Text = Cb_Dept.GetByTextBoxTag()
        End If
        Me_Refresh()
    End Sub
    Public Sub New()
        InitializeComponent()


    End Sub
    Public Sub New(ByVal deptNo As String)
        InitializeComponent()

        Cb_Dept.IDValue = deptNo
    End Sub

    Protected Sub Me_Refresh()
        Dim msg As DtReturnMsg = Job_GetByDept(Cb_Dept.IDValue)
        If msg.IsOk Then
            FG1.DtToFG(msg.Dt)
            FG1.SortByLastOrder()
            FG1.RowSetForce("Job_No", ReturnId)
        End If
    End Sub

    Private Sub Edit_Retrun()
        If ReturnId <> "" Then
            Me_Refresh()
        End If
    End Sub

#Region "数据库交互"

#End Region

#Region "控件事件"
    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub

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
        Dim F As New F99006_Job_Msg("")
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
        ModifyJob()
    End Sub

    Sub ModifyJob()
        If FG1.RowSel <= 0 Then
            ShowErrMsg("请选择一个要修改的职位")
            Exit Sub
        End If
        Dim F As New F99006_Job_Msg(FG1.SelectItem("ID"))
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


    ''' <summary>
    ''' 双击行.进入修改页面
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FG1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FG1.DoubleClick
        If Me.IsSel Then
            ReturnJob()
        Else
            ModifyJob()
        End If
    End Sub

    Protected Sub ReturnJob()
        If FG1.RowSel <= 0 Then
            Me.Close()
            Exit Sub
        End If
        Me.LastForm.ReturnId = FG1.SelectItem("ID")
        Me.LastForm.ReturnObj = FG1.SelectItem
        Me.Close()
    End Sub

    Private Sub Cmd_Del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Del.Click
        If FG1.RowSel <= 0 Then
            ShowErrMsg("请选择一个要修改的职位")
            Exit Sub
        End If
        ShowConfirm("是否删除职位 [" & FG1.SelectItem("Job_Name") & "]?", AddressOf DelJob)
    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub DelJob()
        Dim msg As MsgReturn = Job_Del(FG1.SelectItem("ID"))
        If msg.IsOk Then
            Me.Me_Refresh()
        Else
            ShowErrMsg(msg.Msg)
        End If

    End Sub
#End Region


    Private Sub Cb_Dept_Col_Sel(ByVal Col_No As String, ByVal Col_Name As String, ByVal ID As String) Handles Cb_Dept.Col_Sel
        Me_Refresh()
    End Sub

    Private Sub Cb_Dept_SetEmpty() Handles Cb_Dept.SetEmpty
        Cb_Dept.IDAsInt = 0
        Me_Refresh()
    End Sub
End Class
