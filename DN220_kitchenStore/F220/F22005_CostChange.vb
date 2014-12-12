Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports BaseClass
Public Class F22005_CostChange
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
        'Control_CheckRight(ID, ClassMain.Modify, Cmd_Modify)
        'Control_CheckRight(ID, ClassMain.Del, Cmd_Del)
        '  Control_CheckRight(ID, ClassMain.Disable, Cmd_Disable)
        '  Control_CheckRight(ID, ClassMain.Disable, Cmd_Enable)
    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        ID = 22010
        Me.P_F_RS_ID = ID

        ' 在 InitializeComponent() 调用之后添加任何初始化。
    End Sub


    Private Sub F10010_Goods_Child_Unloaded(ByVal sender As Object) Handles Me.Child_Unloaded
        If Me.ReturnMsg <> "" Then
            FG1.RowSetForce(FG1.Cols("ID").Index, Me.ReturnMsg)
        End If
    End Sub

  

    Private Sub Form_Me_Load() Handles Me.Me_Load
        FG1.IniFormat()

        If Not BaseClass.ComFun.LastFont Is Nothing Then
            FG1.Font = BaseClass.ComFun.LastFont
        End If
        DP_Start.Value = New Date(Today.Year, Today.Month, 1)
        DP_End.Value = Today

        CB_ConditionName1.ComboBox.DataSource = Dao.CostChange_GetConditionNames
        CB_ConditionName1.ComboBox.DisplayMember = "Field"
        CB_ConditionName1.ComboBox.ValueMember = "DB_Field"
        Me.Search()
    End Sub
    Private Sub Me_AfterLoad() Handles Me.AfterLoad
        FG1.FG_ColResize()
        SumFG1.AddSum()
        If IsSel Then

            FG1.Focus()
        End If

    End Sub

    Private Sub F10000_WL_Form_KeyDown(ByVal sender As Object, ByRef e As System.Windows.Forms.KeyEventArgs) Handles Me.Form_KeyDown
        If e.KeyCode = Keys.Enter AndAlso IsSel = True Then
            Me.Search()
        End If

    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub Search()
        Dim msg As DtReturnMsg = Dao.CostChange_GetByOption(GetFindOtions)
        If msg.IsOk Then
            FG1.DtToSetFG(msg.Dt)
            SumFG1.ReSum()
        Else
            FG1.Rows.Count = 1
        End If
    End Sub

    Private Sub Edit_Retrun()
        If ReturnId <> "" Then
            Me.Search()
            FG1.RowSetForce(FG1.Cols("ID").Index, ReturnId)

        End If
    End Sub


#Region "搜索条件"
    ''' <summary>
    ''' 生成搜索条件
    ''' </summary>
    ''' <remarks></remarks>
    Protected Function GetFindOtions() As OptionList
        Dim oList As New OptionList
        Dim fo As New FindOption
        Dim goodsCount As Integer = 0
        fo = New FindOption
        fo.DB_Field = "Audit_Date"
        fo.Value = New Date(DP_Start.Value.Year, DP_Start.Value.Month, DP_Start.Value.Day).AddMilliseconds(-1)
        fo.Value2 = New Date(DP_End.Value.Year, DP_End.Value.Month, DP_End.Value.Day).AddDays(1)
        fo.Field_Operator = Enum_Operator.Operator_Between
        oList.FoList.Add(fo)

        If CB_ConditionName1.ComboBox.SelectedItem IsNot Nothing AndAlso TB_ConditionValue1.Text <> "" Then
            fo = CB_ConditionName1.ComboBox.SelectedItem
            fo.Value = TB_ConditionValue1.Text
            If fo.Field_Operator <> Enum_Operator.Operator_In Then fo.Field_Operator = Enum_Operator.Operator_Like_Both
            oList.FoList.Add(fo)
        End If


        Return oList
    End Function
#End Region

#Region "控件事件"

    Private Sub Btn_Refresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Refresh.Click
        Me.Search()
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

        Dim F As New F22006_CostChange_Msg()
        With F
            .Mode = Mode_Enum.Add
            .P_F_RS_ID = ID
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
            ShowErrMsg("请选择一个要修改的商品")
            Exit Sub
        End If
        Dim F As New F22006_CostChange_Msg()
        With F

            .Mode = Mode_Enum.Modify
            .P_F_RS_ID = FG1.Item(FG1.RowSel, FG1.Cols("ID").Index).ToString
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

    ''' <summary>
    ''' 选择窗口时返回商品
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub ReturnGoods()
        If Me.LastForm Is Nothing Then

        Else
            Me.LastForm.ReturnId = FG1.SelectItem("ID")
            Me.LastForm.ReturnObj = FG1.SelectItem
        End If

        Me.Close()
    End Sub

    Private Sub Cmd_Del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Del.Click
        If FG1.RowSel < 0 Then
            ShowErrMsg("请选择一个要修改的物料")
            Exit Sub
        End If
        ShowConfirm("是否删除物料 [" & FG1.SelectItem("WL_Name") & "]?", AddressOf DelGoods)
    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub DelGoods()

        'Dim msg As MsgReturn = WL_Del(FG1.SelectItem("ID"))
        'If msg.IsOk Then
        '    Search()
        'Else
        '    ShowErrMsg(msg.Msg, Me.Title)

        'End If

    End Sub

    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub


    Private Sub Cmd_Disable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If FG1.RowSel <= 0 Then
            ShowErrMsg("请选择一个物料!")
            Exit Sub
        End If
        ShowConfirm("是否禁用物料 [" & FG1.SelectItem("WL_Name") & "]?", AddressOf DisableWL)
    End Sub

    Public Sub DisableWL()
        'Dim msg As MsgReturn = PClass.PClass.RunSQL(SQL_WL_Disable, "@ID", FG1.SelectItem("ID"))
        'If msg.IsOk Then
        '    FG1.SelectItem("WL_Disable") = True
        'Else
        '    ShowErrMsg(msg.Msg, Me.Title)

        'End If
    End Sub

    Private Sub Cmd_Enable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If FG1.RowSel <= 0 Then
            ShowErrMsg("请选择一个物料!")
            Exit Sub
        End If
        ShowConfirm("是启用用物料 [" & FG1.SelectItem("WL_Name") & "]?", AddressOf EnableWL)
    End Sub

    Public Sub EnableWL()
        'Dim msg As MsgReturn = PClass.PClass.RunSQL(SQL_WL_Enable, "@ID", FG1.SelectItem("ID"))
        'If msg.IsOk Then
        '    FG1.SelectItem("WL_Disable") = False
        'Else
        '    ShowErrMsg(msg.Msg, Me.Title)

        'End If
    End Sub

#End Region



#Region "FG事件"

    Private Sub FG1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles FG1.KeyDown
        If e.KeyCode = Keys.Enter Then

            If FG1.RowSel <= 0 Then
                ShowErrMsg("请选择一个物料")
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


#End Region


    Private Sub Btn_Search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Search.Click
        Me.Search()
    End Sub



End Class


Partial Class Dao
#Region "常量"
    Public Const SQl_CostChange_Get = "select P.*,WL_No,WL_Name,WL_Unit,WL_Spec,WL_Price,WL_Type_ID from T22005_CostChange P left join T22001_kitchen W on P.WL_ID=W.ID  "
#End Region
    ''' <summary>
    ''' 获取查询条件集合
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CostChange_GetConditionNames() As List(Of FindOption)
        Dim foList As New List(Of FindOption)
        Dim fo As New FindOption
        fo.Field = "请选择"
        fo.DB_Field = ""
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "单据编号"
        fo.DB_Field = "P.ID"
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "物料编号"
        fo.DB_Field = "WL_No"
        fo.Field_Operator = Enum_Operator.Operator_Like_Both
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "物料名称"
        fo.DB_Field = "WL_Name"
        fo.Field_Operator = Enum_Operator.Operator_Like_Both
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "模糊搜索"
        fo.DB_Field = " "
        fo.Field_Operator = Enum_Operator.Operator_Like_Both
        fo.SQL = "(P.ID %Like% or WL_No %Like% or WL_Name %Like% or Remark %Like%)"
        fo.Sign = "%Like%"
        foList.Add(fo)

        Return foList
    End Function
    ''' <summary>
    ''' 按条件获取单列表
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CostChange_GetByOption(ByVal oList As OptionList) As DtReturnMsg
        Dim paraMap As New Dictionary(Of String, Object)
        Dim sqlBuider As New StringBuilder
        sqlBuider.Append(SQl_CostChange_Get)
        sqlBuider.Append("  WHERE 1=1  ")
        sqlBuider.Append(BaseClass.OptionClass.OptionClass_BuidSqlConditon(oList.FoList, paraMap))
        sqlBuider.Append(" order by P.ID")
        Return PClass.PClass.SqlStrToDt(sqlBuider.ToString, paraMap)
    End Function
End Class