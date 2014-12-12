Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports BaseClass
Public Class F10072_ReProject_Sel
    Dim selectedGoodsType As String = ""
    Dim selectNode As TreeNode
    Dim nodeMap As New Dictionary(Of String, Object)
    Dim dtRemark As DataTable

    Dim RemarkType As Enum_RemarkType

    Private Sub F10200_Remark_Form_KeyDown(ByVal sender As Object, ByRef e As System.Windows.Forms.KeyEventArgs) Handles Me.Form_KeyDown
        If e.KeyCode = Keys.Enter AndAlso IsSel = True Then
            Me_Refresh()
        End If
    End Sub




    Private Sub F10200_Remark_Form_KeyPress(ByVal sender As Object, ByRef e As System.Windows.Forms.KeyPressEventArgs) Handles Me.Form_KeyPress
        Select Case e.KeyChar
            Case vbCr
            Case Else
                If TB_ConditionValue1.Focused = False Then
                    If e.KeyChar = Chr(System.Windows.Forms.Keys.Back) AndAlso Not Me.ActiveControl.Name = TB_Preview.Name Then
                        If TB_ConditionValue1.Text.Length > 0 Then TB_ConditionValue1.Text = TB_ConditionValue1.Text.Substring(0, TB_ConditionValue1.Text.Length - 1)
                        TB_ConditionValue1.Focus()
                    ElseIf Not Me.ActiveControl.Name = TB_Preview.Name Then
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

    Private Sub Form_Me_Load() Handles Me.Me_Load
        FormCheckRight()
        Ch_Name = GetBillTypeName(ID)
        Me.Title = Ch_Name & "列表"
        CB_ConditionName1.ComboBox.DisplayMember = "Field"
        CB_ConditionName1.ComboBox.ValueMember = "DB_Field"

        CB_ConditionName1.ComboBox.DataSource = ReProject_GetConditionNames()
        Me_Refresh()
        TB_Preview.Text = Me.P_F_RS_ID
        If IsSel Then
            CB_ConditionName1.ComboBox.SelectedIndex = 1
            Me.Width = 400
            Me.Height = 300
            FG1.Width = 299
        End If
    End Sub

    Protected Sub Me_Refresh()
        Dim msg As DtReturnMsg = ReProject_GetByOption(GetFindOtions)
        If msg.IsOk Then
            FG1.DtToFG(msg.Dt)
            FG1.SortByLastOrder()
            FG1.RowSetForce("ID", ReturnId)
        End If
    End Sub

#Region "控件事件"

    Private Sub Btn_Refresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Refresh.Click
        Me_Refresh()
    End Sub

    ''' <summary>
    ''' 新增备注
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <ReProjects></ReProjects>
    Private Sub Cmd_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Add.Click
        Dim F As New F10071_ReProject_Msg(0)
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
        ModifyReProject()
    End Sub

    Sub ModifyReProject()
        If FG1.RowSel < 0 Then
            ShowErrMsg("请选择一个要修改的备注")
            Exit Sub
        End If
        Dim F As New F10071_ReProject_Msg(FG1.SelectItem("ID"))
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
        '  If Me.IsSel Then
        SetRemark()
        ' Else
        ' ModifyRemark()
        '  End If

    End Sub

    Protected Sub SetRemark()
        If TB_Preview.Text = "" Then
            TB_Preview.Text = FG1.SelectItem("ReProject_Name")
        Else
            TB_Preview.Text = TB_Preview.Text & Me.P_F_RS_ID2 & FG1.SelectItem("ReProject_Name")
        End If
    End Sub

    Private Sub Cmd_Del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Del.Click
        If FG1.RowSel < 0 Then
            ShowErrMsg("请选择一个要修改的回修项目")
            Exit Sub
        End If
        ShowConfirm("是否删除回修项目 [" & FG1.SelectItem("ReProject_Name") & "]?", AddressOf DelReProject)
    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <ReProjects></ReProjects>
    Protected Sub DelReProject()
        Dim msg As MsgReturn = Dao.ReProject_Disable(FG1.SelectItem("ID"))
        If msg.IsOk Then
            Me_Refresh()
        Else
            ShowErrMsg("回修项目[" & FG1.SelectItem("ReProject_Name") & "]删除错误！")
        End If
    End Sub

    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub

    Private Sub Edit_Retrun()
        If ReturnId <> "" Then
            Me_Refresh()
        End If
    End Sub


#End Region

#Region "FG事件"



    Private Sub FG1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles FG1.KeyDown

        If e.KeyCode = Keys.Enter Then
            If FG1.RowSel <= 0 Then
                ShowErrMsg("请选择一个备注")
                Exit Sub
            End If

            '   If IsSel Then
            SetRemark()
            'Else
            '     ModifyRemark()
            '  End If
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
        Me_Refresh()
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

            Me_Refresh()
        Catch ex As Exception
            DebugToLog(ex)
        End Try


    End Sub


    ''' <summary>
    ''' 获取查询条件集合
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ReProject_GetConditionNames() As List(Of FindOption)
        Dim foList As New List(Of FindOption)
        Dim fo As New FindOption
        fo.Field = "请选择"
        fo.DB_Field = ""
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "回修项目"
        fo.DB_Field = "ReProject_Name"
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "备注"
        fo.DB_Field = "Remark"
        foList.Add(fo)


        Return foList
    End Function








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
   
#End Region

    Private Sub Cmd_Choose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Choose.Click

        Me.LastForm.ReturnMsg = TB_Preview.Text
        Me.Close()
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
        Return oList
    End Function


    ''' <summary>
    ''' 按条件获取备注信息
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ReProject_GetByOption(ByVal oList As OptionList) As DtReturnMsg
        Dim paraMap As New Dictionary(Of String, Object)
        Dim sqlBuider As New StringBuilder
        sqlBuider.Append("select * from T10025_ReProjet")
        sqlBuider.Append("  WHERE 1=1  ")
        sqlBuider.Append(BaseClass.OptionClass.OptionClass_BuidSqlConditon(oList.FoList, paraMap))
        sqlBuider.Append("order by ID")
        Return PClass.PClass.SqlStrToDt(sqlBuider.ToString, paraMap)
    End Function






End Class
