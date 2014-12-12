Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports BaseClass
Public Class F10200_Remark
    Dim selectedGoodsType As String = ""
    Dim selectNode As TreeNode
    Dim nodeMap As New Dictionary(Of String, Object)
    Dim dtGoods As DataTable

    Dim RemarkType As Enum_RemarkType

    Private Sub F10200_Remark_Form_KeyDown(ByVal sender As Object, ByRef e As System.Windows.Forms.KeyEventArgs) Handles Me.Form_KeyDown
        If e.KeyCode = Keys.Enter AndAlso IsSel = True Then
            Search()
        End If
    End Sub




    Private Sub F10200_Remark_Form_KeyPress(ByVal sender As Object, ByRef e As System.Windows.Forms.KeyPressEventArgs) Handles Me.Form_KeyPress
        Select Case e.KeyChar
            Case vbCr
            Case Else
                If TB_ConditionValue1.Focused = False Then
                    If e.KeyChar = Chr(System.Windows.Forms.Keys.Back) Then
                        If TB_ConditionValue1.Text.Length > 0 Then TB_ConditionValue1.Text = TB_ConditionValue1.Text.Substring(0, TB_ConditionValue1.Text.Length - 1)
                        TB_ConditionValue1.Focus()
                    Else
                        TB_ConditionValue1.Text = e.KeyChar
                        TB_ConditionValue1.Focus()
                    End If
                End If
        End Select
    End Sub
    Public Sub New()

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        ' 在 InitializeComponent() 调用之后添加任何初始化。

    End Sub

    ''' <summary>
    ''' 权限获取
    ''' </summary>
    ''' <remarks></remarks>
    Sub FormCheckRight()
        Control_CheckRight(ID, ClassMain.Add, Cmd_Add)
        Control_CheckRight(ID, ClassMain.Modify, Cmd_Modify)
        Control_CheckRight(ID, ClassMain.Del, Cmd_Del)
    End Sub


    Private Sub F10200_Remark_Me_Load() Handles Me.Me_Load
        Select Case ID
            Case 10200
                Me.Title = "质量要求"
                RemarkType = Enum_RemarkType.Quality
            Case 10201
                Me.Title = "车牌"
                RemarkType = Enum_RemarkType.ChePai
                FG1.Cols("Remark").Caption = "车牌号码"
                FG1.Cols("Remark2").Caption = "司机"
            Case 10203
                Me.Title = "加工类别"
                RemarkType = Enum_RemarkType.ProcessType
                FG1.Cols("Remark").Caption = "加工类别"
            Case 10023
                Me.Title = "染色步骤"
                RemarkType = Enum_RemarkType.Dying_Step
                FG1.Cols("Remark").Caption = "染色步骤"
            Case 10204
                Me.Title = "仓库区域"
                RemarkType = Enum_RemarkType.Store_Area
                FG1.Cols("Remark").Caption = "仓库区域"
            Case 10205
                Me.Title = "入库原因"
                RemarkType = Enum_RemarkType.StoreIn_Reason
                FG1.Cols("Remark").Caption = "入库原因"
            Case 10206
                Me.Title = "退料原因"
                RemarkType = Enum_RemarkType.TuiLiao_Reason
                FG1.Cols("Remark").Caption = "退料原因"
            Case 10207
                Me.Title = "出库原因"
                RemarkType = Enum_RemarkType.StoreOut_Reason
                FG1.Cols("Remark").Caption = "出库原因"
            Case 10208
                Me.Title = "领料原因"
                RemarkType = Enum_RemarkType.LingLiao_Reason
                FG1.Cols("Remark").Caption = "领料原因"

            Case 10209
                Me.Title = "回修原因"
                RemarkType = Enum_RemarkType.HsReason
                FG1.Cols("Remark").Caption = "回修原因"

            Case 10221   '改色原因
                Me.Title = "改色原因"
                RemarkType = Enum_RemarkType.HsReason
                FG1.Cols("Remark").Caption = "改色原因:"


            Case Else
                RemarkType = Enum_RemarkType.Other
                Me.Title = "其他备注"
        End Select
        FormCheckRight()
        Ch_Name = GetBillTypeName(ID)
        'Dao.Balance_DB_NAME = Ch_Name
        Me.Title = Ch_Name & "列表"

        CB_ConditionName1.ComboBox.DisplayMember = "Field"
        CB_ConditionName1.ComboBox.ValueMember = "DB_Field"

        CB_ConditionName1.ComboBox.DataSource = Remark_GetConditionNames()


        TB_ConditionValue1.Text = ""
        TB_ConditionValue1.Focus()
        Search()
        If IsSel Then
            CB_ConditionName1.ComboBox.SelectedIndex = 1
            Me.Width = 400
            Me.Height = 300
            FG1.Width = 299
        End If
    End Sub

    Protected Sub Search()

        Dim msg As DtReturnMsg = Remark_GetByOption(GetFindOtions)
        If msg.IsOk Then
            Try
                FG1.DtToFG(msg.Dt)
                FG1.RowSetForce("Remark_ID", ReturnId)
            Catch ex As Exception
                DebugToLog(ex)
            End Try

        End If
    End Sub

#Region "控件事件"

    Private Sub Btn_Refresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Refresh.Click
        Search()
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Add.Click
        AddRemark()
    End Sub

    Protected Sub AddRemark()

        Dim F As New F10201_Remark_Msg("")
        With F
            .Mode = Mode_Enum.Add
            .P_F_RS_ID = ""
            .P_F_RS_ID2 = ""
            .ID = Me.ID
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
        ModifyRemark()
    End Sub

    Protected Sub ModifyRemark()
        If FG1.RowSel <= 0 Then
            ShowErrMsg("请选择一个要修改的备注")
            Exit Sub
        End If
        Dim F As New F10201_Remark_Msg(FG1.SelectItem("Remark_ID"))
        With F
            .Mode = Mode_Enum.Modify
            .P_F_RS_ID = ""
            .P_F_RS_ID2 = ""
            .ID = Me.ID
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
            Search()
        End If
    End Sub



    ''' <summary>
    ''' 双击行.进入修改页面
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FG1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FG1.DoubleClick
        If Me.IsSel Then
            ReturnGoods()
        Else
            ModifyRemark()
        End If

    End Sub

    Protected Sub ReturnGoods()
        Me.LastForm.ReturnId = FG1.SelectItem("Remark_ID")
        Me.LastForm.ReturnObj = FG1.SelectItem("Remark")
        Me.Close()
    End Sub

    Private Sub Cmd_Del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Del.Click
        If FG1.RowSel <= 0 Then
            ShowErrMsg("请选择一个要修改的备注")
            Exit Sub
        End If
        ShowConfirm("是否删除备注 [" & FG1.SelectItem("Remark") & "]?", AddressOf DelRemark)
    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub DelRemark()

        Dim msg As MsgReturn = Remark_Del(FG1.SelectItem("Remark_ID"))
        If msg.IsOk Then
            Search()
        Else
            ShowErrMsg(msg.Msg)

        End If

    End Sub

    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub



#End Region


#Region "FG事件"



    Private Sub FG1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles FG1.KeyDown

        If e.KeyCode = Keys.Enter Then



            If FG1.RowSel <= 0 Then
                ShowErrMsg("请选择一个备注")
                Exit Sub
            End If

            If IsSel Then
                ReturnGoods()
            Else
                ModifyRemark()
            End If
        End If
    End Sub
#End Region


#Region "搜索工具栏"

    ''' <summary>
    ''' 点击查询
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Btn_Search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Search.Click
        Search()
    End Sub

    ''' <summary>
    '''自动搜索
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TB_ConditionValue1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TB_ConditionValue1.TextChanged
        Try

            If CB_ConditionName1.SelectedIndex <= 0 Then
                CB_ConditionName1.SelectedIndex = 1
            End If

            Search()
        Catch ex As Exception
            DebugToLog(ex)
        End Try


    End Sub
    ''' <summary>
    ''' 生成搜索条件
    ''' </summary>
    ''' <remarks></remarks>
    Protected Function GetFindOtionsString() As String

        Dim sqlBuider As New StringBuilder

        sqlBuider.Append(" 1=1 ")
        If Not CB_ConditionName1.ComboBox.SelectedValue Is Nothing AndAlso Not CB_ConditionName1.ComboBox.SelectedValue = "" Then
            If CB_ConditionName1.ComboBox.SelectedValue = "Remark_Name" Then
                sqlBuider.Append("  and( ")
                sqlBuider.Append(" Remark_FindHelper ")
                sqlBuider.Append(" like '%")
                sqlBuider.Append(TB_ConditionValue1.Text)
                sqlBuider.Append("%'")
                sqlBuider.Append(" or ")
            Else
                sqlBuider.Append("  and ")
            End If
            sqlBuider.Append(CB_ConditionName1.ComboBox.SelectedValue)
            sqlBuider.Append(" like '%")
            sqlBuider.Append(TB_ConditionValue1.Text)
            sqlBuider.Append("%'")

        End If
        If CB_ConditionName1.ComboBox.SelectedValue = "Remark_Name" Then
            sqlBuider.Append(" ) ")

        End If



        Return sqlBuider.ToString
    End Function
    ''' <summary>
    ''' 生成搜索条件
    ''' </summary>
    ''' <remarks></remarks>
    Protected Function GetFindOtions() As OptionList

        Dim oList As New OptionList
        Dim fo As New FindOption

        fo = New FindOption
        fo.DB_Field = "Remark_Type"
        fo.Value = RemarkType
        fo.Field_Operator = Enum_Operator.Operator_Equal
        oList.FoList.Add(fo)

        If Not CB_ConditionName1.ComboBox.SelectedValue Is Nothing AndAlso Not CB_ConditionName1.ComboBox.SelectedValue = "" Then
            fo = New FindOption
            fo.DB_Field = CB_ConditionName1.ComboBox.SelectedValue
            fo.Value = TB_ConditionValue1.Text
            fo.Field_Operator = Enum_Operator.Operator_Like_Both
            oList.FoList.Add(fo)
        End If



        Return oList
    End Function
#End Region



End Class
