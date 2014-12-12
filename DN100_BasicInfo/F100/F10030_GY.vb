Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports BaseClass
Public Class F10030_GY
    Dim selectedGoodsType As String = ""
    Dim selectNode As TreeNode
    Dim nodeMap As New Dictionary(Of String, Object)
    Dim dtGoods As DataTable
    Dim isloaded As Boolean = False

    Private Sub F10030_GY_Form_KeyDown(ByVal sender As Object, ByRef e As System.Windows.Forms.KeyEventArgs) Handles Me.Form_KeyDown
        If e.KeyCode = Keys.Enter AndAlso IsSel = True Then
            Search()
        End If
    End Sub





    Private Sub F10030_GY_Form_KeyPress(ByVal sender As Object, ByRef e As System.Windows.Forms.KeyPressEventArgs) Handles Me.Form_KeyPress
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


    Private Sub F10030_GY_Me_Load() Handles Me.Me_Load
        FormCheckRight()
        '    Dim folist As List(Of FindOption) = GY_GetConditionNames() 
        FG1.IniColsSize()
        FG1.IniFormat()
        CB_ConditionName1.ComboBox.DisplayMember = "Field"
        CB_ConditionName1.ComboBox.ValueMember = "DB_Field"
        'TB_ConditionValue1.ComboBox.DisplayMember = "ConditionValue"
        'TB_ConditionValue1.ComboBox.ValueMember = "ConditionValue"
        CB_ConditionName1.ComboBox.DataSource = Dao.GY_GetConditionNames()
        CB_ConditionName2.ComboBox.DisplayMember = ".Field"
        CB_ConditionName2.ComboBox.ValueMember = ".DB_Field"
        CB_ConditionValue2.ComboBox.DisplayMember = "ConditionValue"
        CB_ConditionValue2.ComboBox.ValueMember = "ConditionValue"
        CB_ConditionName2.ComboBox.DataSource = Dao.GY_GetConditionNames()


        CB_State.ComboBox.DisplayMember = "Field"
        CB_State.ComboBox.ValueMember = "DB_Field"

        CB_State.ComboBox.DataSource = GY_GetCondition3()

        TB_ConditionValue1.Text = ""
        TB_ConditionValue1.Focus()
        Search()
        If IsSel Then
            CB_ConditionName1.ComboBox.SelectedIndex = 1
            LB_S.Visible = False
            CB_State.Visible = False
        End If
        isloaded = True
    End Sub

    Protected Sub Search()

        Dim msg As DtReturnMsg = Dao.GY_GetByOption(GetFindOtions)
        If msg.IsOk Then

            Dim Dt As DataTable

            If SelectRetrun Then
                Dt = TryCast(FG1.DataSource, DataTable)
                If Dt Is Nothing Then
                    Dt = msg.Dt
                Else
                    BaseClass.ComFun.DtReFreshRow(Dt, msg.Dt, "GY_No", ReturnId)
                End If
            Else
                Dt = msg.Dt
            End If




            Try

                If SelectRetrun Then
                    SelectRetrun = False
                Else
                    FG1.DtToFG(Dt)
                End If

                FG1.RowSetForce("GY_No", ReturnId)
            Catch ex As Exception
                DebugToLog(ex)
            End Try

        End If
    End Sub
    Public SelectRetrun As Boolean = False


    Private Sub Edit_Retrun()
        If ReturnId <> "" Then
            SelectRetrun = True

            Search()
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
        AddGoods()
    End Sub

    Protected Sub AddGoods()

        Dim F As New F10031_GY_Msg(0)
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
        ModifyGoods()
    End Sub

    Protected Sub ModifyGoods()
        If FG1.RowSel <= 0 Then
            ShowErrMsg("请选择一个要修改的工艺")
            Exit Sub
        End If
        Dim F As New F10031_GY_Msg(FG1.SelectItem("ID"))
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
            ShowErrMsg("请选择一个要修改的工艺")
            Exit Sub
        End If
        ShowConfirm("是否删除工艺 [" & FG1.SelectItem("GY_Name") & "]?", AddressOf DelGoods)
    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub DelGoods()

        Dim msg As MsgReturn = Dao.GY_Del(FG1.SelectItem("ID"))
        If msg.IsOk Then
            ReturnId = FG1.SelectItem("GY_No")
            Edit_Retrun()
        Else
            ShowErrMsg(msg.Msg)

        End If

    End Sub

    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub


    ''' <summary>
    ''' 状态选定
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CB_State_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CB_State.SelectedIndexChanged
        If isLoaded = True Then
            Search()
        End If
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
        ShowConfirm("是否删除工艺 [" & FG1.SelectItem("GY_Name") & "]?", AddressOf DelGoods)
    End Sub

#End Region


#Region "FG事件"



    Private Sub FG1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles FG1.KeyDown

        If e.KeyCode = Keys.Enter Then



            If FG1.RowSel <= 0 Then
                ShowErrMsg("请选择一个工艺")
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
    'Private Sub CB_ConditionName1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CB_ConditionName1.SelectedIndexChanged
    '    If CB_ConditionName1.ComboBox.SelectedValue = "" Then
    '        Exit Sub
    '    End If
    '    Dim msg As DtReturnMsg = OptionClass.OptionClass_GetConditionValues(OptionClass.Table_Goods, CB_ConditionName1.ComboBox.SelectedValue, "")
    '    If msg.IsOk Then
    '        TB_ConditionValue1.ComboBox.DataSource = msg.Dt

    '    End If
    'End Sub

    Private Sub CB_ConditionName2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CB_ConditionName2.SelectedIndexChanged
        If CB_ConditionName2.ComboBox.SelectedValue = "" Then
            Exit Sub
        End If
        Dim msg As DtReturnMsg = OptionClass.OptionClass_GetConditionValues(OptionClass.Table_GY, CB_ConditionName2.ComboBox.SelectedValue, "")
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
    Protected Function GetFindOtions() As OptionList

        Dim oList As New OptionList
        Dim fo As New FindOption


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
            fo.DB_Field = "GY_No"
            fo.Value = Me.ReturnId
            fo.Field_Operator = Enum_Operator.Operator_Equal
            oList.FoList.Add(fo)
        End If

        If CB_State.SelectedIndex > 0 Then
            fo = New FindOption
            fo.DB_Field = "isnull(State,0)"
            fo.Value = CB_State.ComboBox.SelectedValue
            fo.Field_Operator = Enum_Operator.Operator_Equal
            oList.FoList.Add(fo)

        End If

        If IsSel Then
            fo = New FindOption
            fo.DB_Field = "isnull(State,0)"
            fo.Value = Enum_State.Invoid
            fo.Field_Operator = Enum_Operator.Operator_More
            oList.FoList.Add(fo)
        End If



        Return oList
    End Function
#End Region


    ''' <summary>
    ''' 获取查询条件集合
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GY_GetCondition3() As List(Of FindOption)
        Dim foList As New List(Of FindOption)
        Dim fo As New FindOption
        fo.Field = "全部"
        fo.DB_Field = ""
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "新建"
        fo.DB_Field = Enum_State.AddNew
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "锁定"
        fo.DB_Field = Enum_State.Audited
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "已作废"
        fo.DB_Field = Enum_State.Invoid
        foList.Add(fo)

        Return foList
    End Function



End Class
