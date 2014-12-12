Imports PClass.PClass
Imports System.Data
Imports System.Text
Public Class F50021_ProcessSort_Msg
    Dim dtPs As DataTable
    Dim line As Integer

    Public Sub New()
        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        ' 在 InitializeComponent() 调用之后添加任何初始化。
    End Sub

    Public Sub New(ByVal jID As Integer)
        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        ' 在 InitializeComponent() 调用之后添加任何初始化。
        Me.line = jID
        Me.Mode = Mode
    End Sub
    ''' <summary>
    ''' 权限获取
    ''' </summary>
    ''' <remarks></remarks>
    Sub FormCheckRight()
        ID = 50020
        Control_CheckRight(ID, ClassMain.Modify, Cmd_Modify)
        Control_CheckRight(ID, ClassMain.Del, Cmd_Del)
    End Sub
    Private Sub Form_Me_Load() Handles Me.Me_Load
        If Mode <> Mode_Enum.Add AndAlso line = 0 Then
            line = Val(Me.F_RS_ID)
        End If
        FormCheckRight()
        Ch_Name = GetBillTypeName(ID)
        'Dao.Balance_DB_NAME = Ch_Name
        Me.Title = Ch_Name
        Me_Refresh()
        If Mode = Mode_Enum.Add Then
            Cmd_Del.Visible = False
            If CheckRight(ID, ClassMain.Add) = False Then Me.ShowErrMsg("没有权限添加!", True) : Exit Sub
            line = 0
        End If

    End Sub

    Protected Sub Me_Refresh()
        Dim msg As DtReturnMsg = Dao.ProcessSort_GetByProcessSort(line)
        If msg.IsOk Then
            dtPs = msg.Dt
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
        dt = dtPs.Clone
        If Not dt Is Nothing Then
            dt.Clear()
            Dim dr As DataRow = dt.NewRow
            dr("ProcessSort") = TB_ProcessSort.Text
            dr("Price") = TB_Price.Text
            dr("Remark") = TB_Remark.Text
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
            TB_ProcessSort.Text = IsNull(dt.Rows(0)("ProcessSort"), "")
            TB_Price.Text = IsNull(dt.Rows(0)("Price"), "")
            TB_Remark.Text = IsNull(dt.Rows(0)("Remark"), "")
        End If
    End Sub

#End Region


#Region "工具栏按钮"


    Private Sub Cmd_Modify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Modify.Click
        If CheckForm() Then ShowConfirm("是否保存加工类型[" & TB_ProcessSort.Text & "] 的修改?", AddressOf SaveProcessSort)
    End Sub

    Protected Sub SaveProcessSort()
        Dim R As MsgReturn
        Dim Dt As DataTable = GetForm()
        If Me.Mode = Mode_Enum.Add Then
            R = Dao.ProcessSort_Add(Dt)
        Else
            R = Dao.ProcessSort_Save(Dt, line)
        End If
        If R.IsOk Then
            LastForm.ReturnId = TB_ProcessSort.Text
            LastForm.ReturnObj = Dt
            ShowOk(R.Msg, True)
        Else
            ShowErrMsg(R.Msg)
        End If
    End Sub
    Protected Function CheckForm() As Boolean
        If TB_ProcessSort.Text = "" Then
            ShowErrMsg("加工类型编号不能为空")
            Return False
        End If

        If TB_Price.Text = "" Then
            ShowErrMsg("加工类型名称不能为空")
            Return False
        End If
        Return True
    End Function




    Private Sub Cmd_Del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Del.Click
        ShowConfirm("是否删除加工类型 [" & TB_ProcessSort.Text & "]?", AddressOf DelProcessSort)
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub DelProcessSort()
        Dim msg As MsgReturn = Dao.ProcessSort_Del(line)
        If msg.IsOk Then
            LastForm.ReturnId = "0"
            Me.Close()
        Else
            ShowErrMsg(msg.Msg)
        End If
    End Sub

    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub
#End Region

End Class
