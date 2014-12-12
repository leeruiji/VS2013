Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports BaseClass
Public Class F10000_WL
    Dim selectedGoodsType As String = ""
    Dim selectNode As TreeNode
    Dim nodeMap As New Dictionary(Of String, Object)
    Dim dtGoods As DataTable
    ''' <summary>
    ''' 权限获取
    ''' </summary>
    ''' <remarks></remarks>
    Sub FormCheckRight()
        Control_CheckRight(ID, ClassMain.Add, Cmd_Add)
        Control_CheckRight(ID, ClassMain.Modify, Cmd_Modify)
        TSMI_Add.Visible = Cmd_Add.Visible
        TSMI_Modify.Visible = Cmd_Modify.Visible




        'Control_CheckRight(ID, ClassMain.Del, Cmd_Del)
        'FG1.Cols("WL_Cost").Visible = CheckRight(ID, ClassMain.ShowPrice)
        'FG1.Cols("Wl_Price").Visible = CheckRight(ID, ClassMain.CkPrice)
        'FG1.Cols("WL_Qty").Visible = CheckRight(ID, ClassMain.WL_Qty)
        'FG1.Cols("WL_DownQty").Visible = CheckRight(ID, ClassMain.WL_DownQty)
    End Sub
  

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        ID = 10000
        Me.P_F_RS_ID = ID
        GoodsTypeTree1.SetParent(Me)
        GoodsTypeTree1.SetRootID(GoodsTypeTree.NODE_WL)

        ' 在 InitializeComponent() 调用之后添加任何初始化。
    End Sub




    Private Sub Form_WL_Me_Load() Handles Me.Me_Load
        FG1.IniFormat()
        FormCheckRight()
        FG1.IniColsSize()
        'Dim folist As List(Of FindOption) = WL_GetConditionNames()
        CB_ConditionName1.ComboBox.DisplayMember = "Field"
        CB_ConditionName1.ComboBox.ValueMember = "DB_Field"
        'TB_ConditionValue1.ComboBox.DisplayMember = "ConditionValue"
        'TB_ConditionValue1.ComboBox.ValueMember = "ConditionValue"
        CB_ConditionName1.ComboBox.DataSource = WL_GetConditionNames()
        CB_ConditionName2.ComboBox.DisplayMember = ".Field"
        CB_ConditionName2.ComboBox.ValueMember = ".DB_Field"
        CB_ConditionValue2.ComboBox.DisplayMember = "ConditionValue"
        CB_ConditionValue2.ComboBox.ValueMember = "ConditionValue"
        CB_ConditionName2.ComboBox.DataSource = WL_GetConditionNames()

        TB_ConditionValue1.Text = ""
        TB_ConditionValue1.Focus()
        Me.GoodsTypeTree1.Me_Refresh()
        Search()
        If IsSel Then
            CB_ConditionName1.ComboBox.SelectedIndex = 1
        End If
    End Sub

    Private Sub F10000_WL_Form_KeyDown(ByVal sender As Object, ByRef e As System.Windows.Forms.KeyEventArgs) Handles Me.Form_KeyDown
 
        Select Case e.KeyCode
            Case Keys.Enter
                If IsSel = False Then
                    Me.Search()
                Else
                End If
            Case Keys.Left
                Me.GoodsTypeTree1.Focus()
            Case Keys.Right, Keys.Down, Keys.Up
                FG1.Focus()
        End Select
    End Sub

    Private Sub F10000_WL_Form_KeyPress(ByVal sender As Object, ByRef e As System.Windows.Forms.KeyPressEventArgs) Handles Me.Form_KeyPress
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
    ''' 搜索
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub Search(Optional ByVal isGetByType As Boolean = False)
        Dim MsgShort As DataTable
        Dim msg As DtReturnMsg = WL_GetByOption(GetFindOtions(isGetByType Or CK_IsSelByType.Checked))
        If msg.IsOk Then
            If CB_Short.Checked = True Then
                MsgShort = ShortQty(msg.Dt)
                FG1.Cols("WL_ShortQty").Visible = True
                FG1.IniColsSize()
                FG1.FG_ColResize()
            Else
                MsgShort = msg.Dt
                FG1.Cols("WL_ShortQty").Visible = False
                FG1.IniColsSize()
                FG1.FG_ColResize()
            End If

            Try
                For i As Integer = 0 To MsgShort.Rows.Count - 1
                    MsgShort.Rows(i)("IsEP") = IsNull(msg.Dt.Rows(i)("IsEP"), False)
                    MsgShort.Rows(i)("IsZJ") = IsNull(msg.Dt.Rows(i)("IsZJ"), False)
                Next
                dtGoods = MsgShort
                FG1.DtToFG(MsgShort)
                FG1.SortByLastOrder()
                FG1.RowSetForce("WL_No", ReturnId)
            Catch ex As Exception
                DebugToLog(ex)
            End Try
        End If
    End Sub

    ''' <summary>
    ''' 计算缺货数量
    ''' </summary>
    ''' <remarks></remarks>
    Private Function ShortQty(ByVal msg As DataTable) As DataTable
        Dim dt As DataTable = msg.Clone
        Dim dr() As DataRow = msg.Select("WL_ShortQty>0")
        For Each dtRow In dr
            dt.ImportRow(dtRow)
        Next
        Return dt
    End Function












    Private Sub Edit_Retrun()
        If ReturnId <> "" Then
            Dim Dt As DataTable = TryCast(ReturnObj, DataTable)
            If Not Dt Is Nothing Then
                If GoodsTypeTree1.selectedType = Dt.Rows(0).Item("WL_Type_ID") Then
                    Search(True)
                Else
                    GoodsTypeTree1.SelectNode(Dt.Rows(0).Item("WL_Type_ID"))
                End If
            End If
        End If
    End Sub




#Region "控件事件"

    Private Sub Btn_Refresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Refresh.Click
        Form_WL_Me_Load()
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
        If GoodsTypeTree1.TV_GoodsType.SelectedNode Is Nothing Then

            If Not ParentForm Is Nothing Then
                ShowErrMsg("请选择一个分类")
            End If
            Exit Sub
        End If
        Dim F As New F10001_WL_Msg(GoodsTypeTree1.TV_GoodsType.SelectedNode.Name, GoodsTypeTree1.TV_GoodsType.SelectedNode.Text, GoodsTypeTree1.TV_GoodsType.SelectedNode.Tag, "0")
        With F
            .Mode = Mode_Enum.Add
            .P_F_RS_ID = 10000
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
            ShowErrMsg("请选择一个要修改的化工物料")
            Exit Sub
        End If
        Dim F As New F10001_WL_Msg(FG1.SelectItem("ID"))
        With F
            .Mode = Mode_Enum.Modify
            .P_F_RS_ID = 10000
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

    Private Sub Cmd_Del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If FG1.RowSel <= 0 Then
            ShowErrMsg("请选择一个要修改的化工物料")
            Exit Sub
        End If
        ShowConfirm("是否删除化工物料 [" & FG1.SelectItem("WL_Name") & "]?", AddressOf DelGoods)
    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub DelGoods()

        Dim msg As MsgReturn = WL_Del(FG1.SelectItem("ID"))
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


#Region "树形菜单事件"


    Private Sub GoodsTypeTree1_SelectedEvent(ByVal typeId As String, ByVal typeName As String) Handles GoodsTypeTree1.SelectedEvent
        Try
            Search(True)
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

    Private Sub TSMI_Del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ShowConfirm("是否删除化工物料 [" & FG1.SelectItem("WL_Name") & "]?", AddressOf DelGoods)
    End Sub

#End Region


#Region "FG事件"



    Private Sub FG1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles FG1.KeyDown

        If e.KeyCode = Keys.Enter Then



            If FG1.RowSel <= 0 Then
                ShowErrMsg("请选择一个化工物料")
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
        Dim msg As DtReturnMsg = OptionClass.OptionClass_GetConditionValues(OptionClass.Table_WL, CB_ConditionName2.ComboBox.SelectedValue, "")
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
        Search(CK_IsSelByType.Checked)
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
            Search(CK_IsSelByType.Checked)

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
            If CB_ConditionName1.ComboBox.SelectedValue = "WL_Name" Then
                sqlBuider.Append("  and( ")
                sqlBuider.Append(" WL_FindHelper ")
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
        If CB_ConditionName1.ComboBox.SelectedValue = "WL_Name" Then
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
    ''' <summary>
    ''' 生成搜索条件
    ''' </summary>
    ''' <remarks></remarks>
    Protected Function GetFindOtions(Optional ByVal isGetByType As Boolean = False) As OptionList

        Dim oList As New OptionList
        Dim fo As New FindOption
        If isGetByType AndAlso Not GoodsTypeTree1.TV_GoodsType.SelectedNode Is Nothing Then
            fo = New FindOption
            fo.DB_Field = "G.WL_Type_ID"
            fo.Value = GoodsTypeTree1.TV_GoodsType.SelectedNode.Name
            fo.Field_Operator = Enum_Operator.Operator_Like
            oList.FoList.Add(fo)
        End If



        If CK_ShowDisable.Checked = False Then
            fo = New FindOption
            fo.DB_Field = "G.WL_Disable"
            fo.Value = 0
            fo.Field_Operator = Enum_Operator.Operator_Equal
            oList.FoList.Add(fo)
            If FG1.Cols("WL_Disable").Visible Then
                FG1.Cols("WL_Disable").Visible = False
                FG1.IniColsSize()
                FG1.FG_ColResize()
            End If
        Else
            If FG1.Cols("WL_Disable").Visible = False Then
                FG1.Cols("WL_Disable").Visible = True
                FG1.IniColsSize()
                FG1.FG_ColResize()
            End If
        End If



        'If CB_Short.Checked = True Then
        '    fo = New FindOption
        '    fo.DB_Field = "WL_ShortQty"
        '    fo.Value = 0
        '    fo.Field_Operator = Enum_Operator.Operator_MoreOrEqual
        '    oList.FoList.Add(fo)
        '    FG1.Cols("WL_ShortQty").Visible = True
        '    FG1.IniColsSize()
        '    FG1.FG_ColResize()
        'Else
        '    FG1.Cols("WL_ShortQty").Visible = False
        '    FG1.IniColsSize()
        '    FG1.FG_ColResize()
        'End If


        If CB_ConditionName1.ComboBox.SelectedItem IsNot Nothing AndAlso TB_ConditionValue1.Text <> "" Then
            fo = CB_ConditionName1.ComboBox.SelectedItem
            fo.Value = TB_ConditionValue1.Text
            If fo.Field_Operator <> Enum_Operator.Operator_In Then fo.Field_Operator = Enum_Operator.Operator_Like_Both
            oList.FoList.Add(fo)
        End If
        If CB_ConditionName2.ComboBox.SelectedItem IsNot Nothing AndAlso CB_ConditionName2.ComboBox.SelectedValue <> "" Then
            fo = CB_ConditionName2.ComboBox.SelectedItem
            fo.Value = CB_ConditionValue2.Text
            If fo.Field_Operator <> Enum_Operator.Operator_In Then fo.Field_Operator = Enum_Operator.Operator_Like_Both
            oList.FoList.Add(fo)
        End If



        Return oList
    End Function
#End Region

#Region "报表"


    Private Sub Cmd_Print_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmd_Print.Click
        Print(PClass.CReport.OperatorType.Print)

    End Sub

    Protected Sub Print(ByVal type As PClass.CReport.OperatorType)
        If dtGoods Is Nothing Then
            Exit Sub
        End If
        Dim rptLoader As New R10000_Goods_List()
        rptLoader.Start(dtGoods, type)
    End Sub

    Private Sub Cmd_Preview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Preview.Click
        Print(PClass.CReport.OperatorType.Preview)
    End Sub
#End Region

End Class
