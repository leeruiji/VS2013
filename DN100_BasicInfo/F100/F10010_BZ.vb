Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports BaseClass
Imports PClass.CReport
Public Class F10010_BZ
    Dim selectedGoodsType As String = ""
    Dim selectNode As TreeNode
    Dim nodeMap As New Dictionary(Of String, Object)
    Dim dtGoods As DataTable
    ''' <summary>
    ''' 权限获取
    ''' </summary>
    ''' <remarks></remarks>
    Sub FormCheckRight()
        'Control_CheckRight(ID, ClassMain.Add, Cmd_Add)
        'Control_CheckRight(ID, ClassMain.Modify, Cmd_Modify)
        'Control_CheckRight(ID, ClassMain.Del, Cmd_Del)
        Dim canAdd As Boolean = CheckRight(ID, ClassMain.Add)
        Cmd_Add.Visible = canAdd
        TSMI_Add.Visible = canAdd

        Dim canModify As Boolean = CheckRight(ID, ClassMain.Modify)
        Cmd_Modify.Visible = canModify
        TSMI_Modify.Visible = canModify

        Dim canDel As Boolean = CheckRight(ID, ClassMain.Del)
        Cmd_Del.Visible = canDel
        TSMI_Del.Visible = canDel

    End Sub


    Public Sub New()
        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        Me.P_F_RS_ID = 10010
        '  GoodsTypeTree1.SetParent(Me)
        ' GoodsTypeTree1.SetRootID(GoodsTypeTree.NODE_BZ)
        ' 在 InitializeComponent() 调用之后添加任何初始化。
    End Sub


    Private Sub Form_Me_Load() Handles Me.Me_Load
        FormCheckRight()
        CB_ConditionName1.ComboBox.DisplayMember = "Field"
        CB_ConditionName1.ComboBox.ValueMember = "DB_Field"
        'TB_ConditionValue1.ComboBox.DisplayMember = "ConditionValue"
        'TB_ConditionValue1.ComboBox.ValueMember = "ConditionValue"
        CB_ConditionName1.ComboBox.DataSource = BZ_GetConditionNames()
        CB_ConditionName2.ComboBox.DisplayMember = ".Field"
        CB_ConditionName2.ComboBox.ValueMember = ".DB_Field"
        CB_ConditionValue2.ComboBox.DisplayMember = "ConditionValue"
        CB_ConditionValue2.ComboBox.ValueMember = "ConditionValue"
        CB_ConditionName2.ComboBox.DataSource = BZ_GetConditionNames()

        TB_ConditionValue1.Text = ""
        TB_ConditionValue1.Focus()
        Search()
        If IsSel Then
            CB_ConditionName1.ComboBox.SelectedIndex = 1
        End If
    End Sub


    Private Sub F10000_BZ_Form_KeyDown(ByVal sender As Object, ByRef e As System.Windows.Forms.KeyEventArgs) Handles Me.Form_KeyDown
        If e.KeyCode = Keys.Enter AndAlso IsSel = True Then
            Me.Search()
        End If
        Select Case e.KeyCode
            Case Keys.Enter
                If IsSel = False Then
                    Me.Search()
                Else
                End If
            Case Keys.Left
                Me.ClinetBZTree1.Focus()
            Case Keys.Right
                FG1.Focus()
        End Select
    End Sub



    Private Sub F10000_BZ_Form_KeyPress(ByVal sender As Object, ByRef e As System.Windows.Forms.KeyPressEventArgs) Handles Me.Form_KeyPress
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

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub Search()

        Dim msg As DtReturnMsg = BZ_GetByOption(GetFindOtions())
        If msg.IsOk Then
            Try
                Dim Dt As DataTable
                If SelectRetrun Then
                    Dt = TryCast(FG1.DataSource, DataTable)
                    If Dt Is Nothing Then
                        Dt = msg.Dt
                    Else
                        BaseClass.ComFun.DtReFreshRow(Dt, msg.Dt, "BZ_No", ReturnId)
                    End If
                Else
                    Dt = msg.Dt
                End If
                If SelectRetrun Then
                    SelectRetrun = False
                Else
                    FG1.DtToFG(Dt)
                End If
                FG1.RowSetForce("BZ_No", ReturnId)
            Catch ex As Exception
                DebugToLog(ex)
            End Try
        End If
    End Sub

    Public SelectRetrun As Boolean = False
    Private Sub Edit_Retrun()
        If ReturnId <> "" Then
            'Dim Dt As DataTable = TryCast(ReturnObj, DataTable)
            'If Not Dt Is Nothing Then
            SelectRetrun = True
            Search()
        End If
        'End If
    End Sub

#Region "控件事件"

    Private Sub Btn_Refresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Refresh.Click
        Form_Me_Load()
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Add.Click
        AddGoods()
    End Sub

    Protected Sub AddGoods()
        If Me.ClinetBZTree1.TreeView1.SelectedNode Is Nothing OrElse Me.ClinetBZTree1.TreeView1.SelectedNode.Name = ClinetBZTree.RootID Then
            ShowErrMsg("请选择一个客户?")
            Exit Sub
        End If
        Dim F As New F10011_BZ_Msg(Me.ClinetBZTree1.TreeView1.SelectedNode.Name, Me.ClinetBZTree1.TreeView1.SelectedNode.Text, Me.ClinetBZTree1.TreeView1.SelectedNode.Tag, "")
        With F
            .Mode = Mode_Enum.Add
            .P_F_RS_ID = 10010
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
        ModifyGoods()
    End Sub

    Protected Sub ModifyGoods()
        If FG1.RowSel <= 0 Then
            ShowErrMsg("请选择一个要修改的布类")
            Exit Sub
        End If
        Dim F As New F10011_BZ_Msg(Me.ClinetBZTree1.TreeView1.SelectedNode.Name, Me.ClinetBZTree1.TreeView1.SelectedNode.Text, Me.ClinetBZTree1.TreeView1.SelectedNode.Tag, FG1.Item(FG1.RowSel, "ID"))
        With F
            .Mode = Mode_Enum.Modify
            .P_F_RS_ID = 10010
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
            ReturnGoods()
        Else
            ModifyGoods()
        End If

    End Sub

    Protected Sub ReturnGoods()
        Me.LastForm.ReturnId = FG1.SelectItem("ID")
        Me.LastForm.ReturnObj = FG1.SelectItem
        Me.Close()
    End Sub

    Private Sub Cmd_Del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Del.Click
        If FG1.RowSel <= 0 Then
            ShowErrMsg("请选择一个要修改的布类?")
            Exit Sub
        End If
        ShowConfirm("是否删除布类 [" & FG1.SelectItem("BZ_Name") & "]?", AddressOf DelGoods)
    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub DelGoods()

        Dim msg As MsgReturn = BZ_Del(FG1.SelectItem("ID"))
        If msg.IsOk Then
            ReturnId = FG1.SelectItem("BZ_No")
            Edit_Retrun()
        Else
            ShowErrMsg(msg.Msg)

        End If

    End Sub

    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub



#End Region

#Region "树形菜单事件"


    Private Sub GoodsTypeTree1_SelectedEvent(ByVal typeId As String, ByVal typeName As String) Handles ClinetBZTree1.SelectedEvent
        Try
            Search()
        Catch ex As Exception
            DebugToLog(ex)
        End Try
    End Sub

#End Region

#Region "右键菜单"
    Private Sub TSMI_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMI_Add.Click
        AddGoods()
    End Sub

    Private Sub TSMI_Modify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMI_Modify.Click
        ModifyGoods()
    End Sub

    Private Sub TSMI_Del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMI_Del.Click
        ShowConfirm("是否删除布类 [" & FG1.SelectItem("BZ_Name") & "]?", AddressOf DelGoods)
    End Sub

#End Region

#Region "FG事件"

    'Private Sub FG1_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles FG1.MouseDoubleClick

    '    If FG1.RowSel <= 0 Then
    '        ShowErrMsg("请选择一个布种")
    '        Exit Sub
    '    End If

    '    If IsSel Then
    '        ''ReturnGoods()
    '    Else
    '        ModifyGoods()
    '    End If


    'End Sub

    Private Sub FG1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles FG1.KeyDown
        If e.KeyCode = Keys.Enter Then
            If FG1.RowSel <= 0 Then
                ShowErrMsg("请选择一个布类")
                Exit Sub
            End If

            If IsSel Then
                ReturnGoods()
            Else
                ModifyGoods()
            End If
        End If
    End Sub
#End Region

#Region "搜索工具栏"


    Private Sub CB_ConditionName2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CB_ConditionName2.SelectedIndexChanged
        If CB_ConditionName2.ComboBox.SelectedValue = "" Then
            Exit Sub
        End If
        Dim msg As DtReturnMsg = OptionClass.OptionClass_GetConditionValues(OptionClass.Table_BZ, CB_ConditionName2.ComboBox.SelectedValue, "")
        If msg.IsOk Then
            CB_ConditionValue2.ComboBox.DataSource = msg.Dt
        End If
    End Sub

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
            If CB_ConditionName1.ComboBox.SelectedValue = "BZ_Name" Then
                sqlBuider.Append("  and( ")
                sqlBuider.Append(" BZ_FindHelper ")
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
        If CB_ConditionName1.ComboBox.SelectedValue = "BZ_Name" Then
            sqlBuider.Append(" ) ")

        End If

        If Not CB_ConditionName2.ComboBox.SelectedValue Is Nothing AndAlso Not CB_ConditionName2.ComboBox.SelectedValue = "" Then
            sqlBuider.Append("  and ")
            sqlBuider.Append(CB_ConditionName2.ComboBox.SelectedValue)
            sqlBuider.Append(" like '%")
            sqlBuider.Append(CB_ConditionValue2.ComboBox.SelectedValue)
            sqlBuider.Append("%'")
        End If

        Return sqlBuider.ToString
    End Function
    Protected Function GetFindOtions(Optional ByVal isGetByType As Boolean = False) As OptionList

        Dim oList As New OptionList
        Dim fo As New FindOption

        If Not Me.ClinetBZTree1.TreeView1.SelectedNode Is Nothing AndAlso Val(Me.ClinetBZTree1.TreeView1.SelectedNode.Name) <> -1 Then
            fo = New FindOption
            fo.DB_Field = "Client_ID"
            fo.Value = Me.ClinetBZTree1.TreeView1.SelectedNode.Name
            fo.Field_Operator = Enum_Operator.Operator_Equal
            oList.FoList.Add(fo)
        End If

     



        If Not CB_ConditionName1.ComboBox.SelectedValue Is Nothing AndAlso Not CB_ConditionName1.ComboBox.SelectedValue = "" Then
            fo = New FindOption
            fo.DB_Field = CB_ConditionName1.ComboBox.SelectedValue
            fo.Value = TB_ConditionValue1.Text
            fo.Field_Operator = Enum_Operator.Operator_Like_Both
            oList.FoList.Add(fo)
        End If

        If Not CB_ConditionName2.ComboBox.SelectedValue Is Nothing AndAlso Not CB_ConditionName2.ComboBox.SelectedValue = "" Then
            fo = New FindOption
            fo.DB_Field = CB_ConditionName2.ComboBox.SelectedValue
            fo.Value = CB_ConditionValue2.ComboBox.Text
            fo.Field_Operator = Enum_Operator.Operator_Like
            oList.FoList.Add(fo)
        End If

        If SelectRetrun Then
            fo = New FindOption
            fo.DB_Field = "BZ_No"
            fo.Value = Me.ReturnId
            fo.Field_Operator = Enum_Operator.Operator_Equal
            oList.FoList.Add(fo)
        End If

        If TM_State.Tag < 100 Then
            fo = New FindOption
            fo.DB_Field = "Isnull(BZ_State,0)"
            fo.Value = TM_State.Tag
            fo.Field_Operator = Enum_Operator.Operator_Equal
            oList.FoList.Add(fo)
        End If




        Return oList
    End Function
#End Region


    Private Sub Cmd_Preview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Preview.Click
        Print(OperatorType.Preview)
    End Sub

    Protected Sub Print(ByVal DoOperator As OperatorType)
        Dim R As New R10010_BZ
        R.Start(FG1.DataSource, DoOperator)
    End Sub

    Private Sub TSM_All_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSM_All.Click
        TM_State.Tag = 100
        TM_State.Text = "全部"
    End Sub

    Private Sub TSM_isUse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSM_isUse.Click
        TM_State.Tag = 0
        TM_State.Text = "在用"
    End Sub

    Private Sub Tlm_Disble_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tlm_Disble.Click
        TM_State.Tag = -1
        TM_State.Text = "禁用"
    End Sub
End Class
