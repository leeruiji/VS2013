Imports PClass.PClass
Imports System.Data
Imports System.Text
Public Class F10008_WL_Name_Msg
    Dim Dt_WL_Name As DataTable


    Protected Overrides Function ProcessDialogKey(ByVal keyData As Keys) As Boolean
        If keyData = Keys.Enter Then
            keyData = Keys.Tab
        End If
        Return MyBase.ProcessDialogKey(keyData)
    End Function






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
        ID = 10007
        Control_CheckRight(ID, ClassMain.Modify, Cmd_Modify)
        Control_CheckRight(ID, ClassMain.Del, Cmd_Del)
    End Sub
    Private Sub Form_Me_Load() Handles Me.Me_Load
        If Mode <> Mode_Enum.Add AndAlso Val(Bill_ID) = 0 Then
            Bill_ID = Val(Me.F_RS_ID)
        End If
        FormCheckRight()
        Ch_Name = GetBillTypeName(ID)
        'Dao.Balance_DB_NAME = Ch_Name
        Me.Title = Ch_Name
        Me_Refresh()
        If Mode = Mode_Enum.Add Then
            Cmd_Del.Visible = False
            If CheckRight(ID, ClassMain.Add) = False Then Me.ShowErrMsg("没有权限添加!", True) : Exit Sub
            TB_ID.Text = Dao.WL_Name_GetNewID()
            Bill_ID = 0
        End If

    End Sub

    Protected Sub Me_Refresh()
        Dim msg As DtReturnMsg = Dao.WL_Name_GetById(IsNothing(Bill_ID, 0))
        If msg.IsOk Then
            Dt_WL_Name = msg.Dt
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
        dt = Dt_WL_Name.Clone
        If Not dt Is Nothing Then
            dt.Clear()
            Dim dr As DataRow = dt.NewRow
            If Mode <> Mode_Enum.Add Then dr("ID") = Bill_ID
            dr("WL_Name_No") = TB_ID.Text
            dr("WL_Name") = TB_Name.Text
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
            TB_ID.Text = IsNull(dt.Rows(0)("WL_Name_No"), "")
            TB_Name.Text = IsNull(dt.Rows(0)("WL_Name"), "")
            TB_Remark.Text = IsNull(dt.Rows(0)("Remark"), "")
        End If
    End Sub

#End Region


#Region "工具栏按钮"


    Private Sub Cmd_Modify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Modify.Click
        If CheckForm() Then ShowConfirm("是否保存物料名称 [" & TB_Name.Text & "] 的修改?", AddressOf SaveWL_Name)
    End Sub

    Protected Sub SaveWL_Name()
        Dim R As MsgReturn
        Dim Dt As DataTable = GetForm()
        If Me.Mode = Mode_Enum.Add Then
            R = Dao.WL_Name_Add(Dt)
        Else
            R = Dao.WL_Name_Save(Dt)
        End If
        If R.IsOk Then
            LastForm.ReturnId = TB_ID.Text
            LastForm.ReturnObj = Dt
            ShowOk(R.Msg, True)
        Else
            ShowErrMsg(R.Msg)
        End If
    End Sub
    Protected Function CheckForm() As Boolean
        If TB_ID.Text = "" Then
            ShowErrMsg("物料名称编号不能为空")
            Return False
        End If

        If TB_Name.Text = "" Then
            ShowErrMsg("物料名称不能为空")
            Return False
        End If
        Return True
    End Function




    Private Sub Cmd_Del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Del.Click
        ShowConfirm("是否删除物料名称 [" & TB_Name.Text & "]?", AddressOf DelWL_Name)
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub DelWL_Name()
        Dim msg As MsgReturn = Dao.WL_Name_Del(Bill_ID)
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






#Region "双击获取新编号"

    Private Sub Label_ID_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label_ID.DoubleClick
        If Mode = Mode_Enum.Add Then
            TB_ID.Text = Dao.WL_Name_GetNewID()
            TB_Name.Focus()
        End If
    End Sub

#End Region




End Class
