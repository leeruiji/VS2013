Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports BaseClass
Public Class F10201_Remark_Msg
    Dim RemarkID As String = ""

    Dim dtWL As DataTable
    Dim dtList As DataTable
    Dim RemarkType As Enum_RemarkType
    Public Sub New()

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。

    End Sub

    Public Sub New(ByVal RemarkID As String)

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        Me.RemarkID = RemarkID
        Me.Mode = Mode

    End Sub

    Private Sub F10201_Quality_Msg_Form_KeyDown(ByVal sender As Object, ByRef e As System.Windows.Forms.KeyEventArgs) Handles Me.Form_KeyDown
        If e.KeyCode = Keys.Enter Then
            Try

                SendKeys.SendWait("{TAB}")

            Catch ex As Exception
            End Try
        End If
    End Sub

    ''' <summary>
    ''' 权限获取
    ''' </summary>
    ''' <remarks></remarks>
    Sub FormCheckRight()
        If ID = 0 Then ID = 10200
        Control_CheckRight(ID, ClassMain.Modify, Cmd_Modify)
        Control_CheckRight(ID, ClassMain.Del, Cmd_Del)
    End Sub

    Private Sub FormLoad() Handles Me.Me_Load
        Select Case ID
            Case 10200
                Me.Title = "质量要求详细信息"
                RemarkType = Enum_RemarkType.Quality
            Case 10201
                Me.Title = "车牌信息"
                RemarkType = Enum_RemarkType.ChePai
                LB_Remark.Text = "车牌信息:"
                LB_Remark2.Text = "司机:"
            Case 10203
                Me.Title = "加工类别"
                RemarkType = Enum_RemarkType.ProcessType
                LB_Remark.Text = "加工类别:"
            Case 10023
                Me.Title = "染色步骤"
                RemarkType = Enum_RemarkType.Dying_Step

                LB_Remark.Text = "染色步骤:"
                'Case 10204
                '    Me.Title = "仓库区域"
                '    RemarkType = Enum_RemarkType.Store_Area
                '    LB_Remark.Text = "仓库区域:"
     

            Case 10205
                Me.Title = "入库原因"
                RemarkType = Enum_RemarkType.StoreIn_Reason
                LB_Remark.Text = "入库原因:"

            Case 10206
                Me.Title = "退料原因"
                RemarkType = Enum_RemarkType.TuiLiao_Reason
                LB_Remark.Text = "退料原因:"

            Case 10207
                Me.Title = "出库原因"
                RemarkType = Enum_RemarkType.StoreOut_Reason
                LB_Remark.Text = "出库原因:"
            Case 10208
                Me.Title = "领料原因"
                RemarkType = Enum_RemarkType.LingLiao_Reason
                LB_Remark.Text = "领料原因:"

            Case 10209   '回修项目
                Me.Title = "回修项目"
                RemarkType = Enum_RemarkType.HsReason
                LB_Remark.Text = "回修项目:"

            Case 10221   '改色原因
                Me.Title = "改色原因"
                RemarkType = Enum_RemarkType.GSReason
                LB_Remark.Text = "改色原因:"

            Case 10220   '回修项目
                Me.Title = "回修项目"
                RemarkType = Enum_RemarkType.HsReason
                LB_Remark.Text = "回修项目:"


            Case Else
                RemarkType = Enum_RemarkType.Other
                Me.Title = "其他备注详细信息"
        End Select
        FormCheckRight()
        Ch_Name = GetBillTypeName(ID)
        'Dao.Balance_DB_NAME = Ch_Name
        Me.Title = Ch_Name

        Me_Refresh()


        If Mode = Mode_Enum.Add Then
            If CheckRight(ID, ClassMain.Add) = False Then Me.ShowErrMsg("没有权限添加!", True) : Exit Sub
            TB_ID.Text = Remark_GetNewID()
        Else
            TB_ID.Text = RemarkID
        End If
        TB_Remark.Focus()
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub Me_Refresh() Handles Btn_Refresh.Click

        Dim msg As DtReturnMsg = Remark_GetById(RemarkID)
        If msg.IsOk Then
            dtWL = msg.Dt
            SetForm(msg.Dt)
        End If

        If Mode = Mode_Enum.Add Then

        End If
    End Sub



#Region "表单信息"
    ''' <summary>
    ''' 获取表单内容
    ''' </summary>
    ''' <remarks></remarks>
    Protected Function GetForm() As DataTable
        Dim dt As DataTable
        dt = dtWL.Clone
        If Not dt Is Nothing Then
            dt.Clear()
            Dim dr As DataRow = dt.NewRow
            dt.Rows.Add(dr)

            dt.Rows(0)("Remark_ID") = TB_ID.Text

            dt.Rows(0)("Remark") = TB_Remark.Text
            dt.Rows(0)("Remark2") = TB_Remark2.Text
            dt.Rows(0)("Remark_Type") = RemarkType

        End If
        Return dt
    End Function

    ''' <summary>
    ''' 设置表单内容
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub SetForm(ByVal dt As DataTable)
        If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then

            TB_ID.Text = IsNull(dt.Rows(0)("Remark_ID"), "")

            TB_Remark.Text = IsNull(dt.Rows(0)("Remark"), "")
            TB_Remark2.Text = IsNull(dt.Rows(0)("Remark2"), "")
        End If
    End Sub




#End Region

#Region "工具栏,按钮"


    Private Sub Cmd_Modify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Modify.Click
        If CheckForm() Then ShowConfirm("是否保存备注[" & TB_ID.Text & "] 的修改?", AddressOf Save)
    End Sub

    Protected Sub Save()
        Dim R As MsgReturn

        If Me.Mode = Mode_Enum.Add Then
            R = Remark_Add(GetForm())
        Else
            R = Remark_Save(GetForm())
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
            ShowErrMsg("备注编号不能为空")
            TB_ID.Focus()
            Return False
        End If


        Return True
    End Function




    Private Sub Cmd_Del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Del.Click
        ShowConfirm("是否删除备注[" & TB_ID.Text & "]?", AddressOf DelWL)
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub DelWL()
        Dim msg As MsgReturn = Remark_Del(TB_ID.Text)
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





    Private Sub Me_Refresh(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Refresh.Click

    End Sub

  
End Class
