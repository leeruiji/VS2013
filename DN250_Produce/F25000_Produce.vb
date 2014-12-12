Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports BaseClass

Public Class F25000_Produce
    ''' <summary>
    ''' 权限获取
    ''' </summary>
    ''' <remarks></remarks>
    Sub FormCheckRight()
        Control_CheckRight(ID, ClassMain.Add, Cmd_Add)
        Control_CheckRight(ID, ClassMain.Modify, Cmd_Modify)
        Control_CheckRight(ID, ClassMain.Del, Cmd_Del)
    End Sub

    Private Sub F10100_Produce_Me_Load() Handles Me.Me_Load
        FormCheckRight()
        FG1.IniFormat()
        DP_Start.Value = New Date(Now.Year, Now.Month, 1).Date
        DP_End.Value = Today
        CB_ConditionName1.ComboBox.DisplayMember = "Field"
        CB_ConditionName1.ComboBox.ValueMember = "DB_Field"
        'CB_ConditionValue1.ComboBox.DisplayMember = "ConditionValue"
        'CB_ConditionValue1.ComboBox.ValueMember = "ConditionValue"
        CB_ConditionName1.ComboBox.DataSource = Produce_GetConditionNames()
        CB_ConditionName2.ComboBox.DisplayMember = ".Field"
        CB_ConditionName2.ComboBox.ValueMember = ".DB_Field"
        CB_ConditionValue2.ComboBox.DisplayMember = "ConditionValue"
        CB_ConditionValue2.ComboBox.ValueMember = "ConditionValue"
        CB_ConditionName2.ComboBox.DataSource = Produce_GetConditionNames()
        Me_Refresh()
    End Sub

    Protected Sub Me_Refresh()
        Dim msg As DtReturnMsg = Produce_GetByOption(GetFindOtions)
        If msg.IsOk Then
            FG1.DtToFG(msg.Dt)
            FG1.RowSetForce("Produce_ID", ReturnId)
        End If
    End Sub




#Region "控件事件"


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
        Dim F As New F25001_Produce_Msg("")
        With F
            .Mode = Mode_Enum.Add
            .P_F_RS_ID = ""
            .P_F_RS_ID2 = ""
        End With
        F_RS_ID = ""
        Me.ReturnId = ""
        Me.ReturnObj = Nothing
        Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F, Me)
        AddHandler VF.ClosedX, AddressOf Me_Refresh
        VF.Show()
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_Modify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Modify.Click
        If FG1.RowSel < 0 Then
            ShowMsg("请选择一个要修改的生产单", "")
            Exit Sub
        End If
        Dim F As New F25001_Produce_Msg(FG1.SelectItem("Produce_ID"))
        With F
            .Mode = Mode_Enum.Modify
            .P_F_RS_ID = ""
            .P_F_RS_ID2 = ""
        End With
        F_RS_ID = ""
        Me.ReturnId = ""
        Me.ReturnObj = Nothing
        Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F, Me)
        AddHandler VF.ClosedX, AddressOf Me_Refresh
        VF.Show()
    End Sub

    ''' <summary>
    ''' 双击行.进入修改页面
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FG1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FG1.DoubleClick
        If FG1.RowSel < 0 Then
            ShowMsg("请选择一个要修改的生产单", "")
            Exit Sub
        End If
        Dim F As New F25001_Produce_Msg(FG1.SelectItem("Produce_ID"))
        With F
            .Mode = Mode_Enum.Modify
            .P_F_RS_ID = ""
            .P_F_RS_ID2 = ""
        End With
        F_RS_ID = ""
        Me.ReturnId = ""
        Me.ReturnObj = Nothing
        Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F, Me)
        AddHandler VF.ClosedX, AddressOf Me_Refresh
        VF.Show()
    End Sub


    Private Sub Cmd_Del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Del.Click
        If FG1.RowSel < 0 Then
            ShowMsg("请选择一个要修改的生产单", "")
            Exit Sub
        End If
        ShowConfirm("是否删除生产单 [" & FG1.SelectItem("Produce_ID") & "]?", AddressOf DelProduce)
    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub DelProduce()
        Dim msg As MsgReturn = Produce_Del(FG1.SelectItem("Produce_ID"))
        If msg.IsOk Then
            Me_Refresh()
        Else
            ShowErrMsg(msg.Msg, Me.Title)

        End If

    End Sub

    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub
#End Region

#Region "搜索工具栏"
    'Private Sub CB_ConditionName1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CB_ConditionName1.SelectedIndexChanged
    '    Dim oList As OptionList = GetFindOtions()
    '    Dim msg As DtReturnMsg = OptionClass.OptionClass_GetConditionValues("(" & oList.Sql & ")Con", CB_ConditionName1.ComboBox.SelectedValue, "")
    '    If msg.IsOk Then
    '        CB_ConditionValue1.ComboBox.DataSource = msg.Dt

    '    End If
    'End Sub

    Private Sub CB_ConditionName2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CB_ConditionName2.SelectedIndexChanged
        Dim oList As OptionList = GetFindOtions()
        Dim msg As DtReturnMsg = OptionClass.OptionClass_GetConditionValues("(" & oList.Sql & ")Con", CB_ConditionName2.ComboBox.SelectedValue, "")
        If msg.IsOk Then
            CB_ConditionValue2.ComboBox.DataSource = msg.Dt
        End If
    End Sub


    ''' <summary>
    '''自动搜索
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TB_ConditionValue1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TB_ConditionValue1.TextChanged
        Me_Refresh()
    End Sub


    ''' <summary>
    ''' 生产搜索条件
    ''' </summary>
    ''' <remarks></remarks>
    Protected Function GetFindOtions() As OptionList

        Dim oList As New OptionList
        Dim fo As New FindOption
        '   oList.Sql = SQL_Produce_Get_Sel
        Dim sqlbuider As New StringBuilder(SQL_Produce_Get_Sel)
        Dim goodsCount As Integer = 0
        fo = New FindOption
        fo.DB_Field = "Produce_Date"
        fo.Value = DP_Start.Value.Date
        fo.Value2 = DP_End.Value.Date
        fo.Field_Operator = Enum_Operator.Operator_Between
        oList.FoList.Add(fo)

        If Not CB_ConditionName1.ComboBox.SelectedValue Is Nothing AndAlso Not CB_ConditionName1.ComboBox.SelectedValue = "" Then
            fo = New FindOption
            fo.DB_Field = CB_ConditionName1.ComboBox.SelectedValue
            If fo.DB_Field = "Goods_No" Then
                goodsCount = 1

            ElseIf fo.DB_Field = "Goods_Name" Then
                goodsCount = 2

            End If

            fo.Value = TB_ConditionValue1.Text
            fo.Field_Operator = Enum_Operator.Operator_Like
            oList.FoList.Add(fo)
        End If

        If Not CB_ConditionName2.ComboBox.SelectedValue Is Nothing AndAlso Not CB_ConditionName2.ComboBox.SelectedValue = "" Then
            fo = New FindOption
            fo.DB_Field = CB_ConditionName2.ComboBox.SelectedValue
            If fo.DB_Field = "Goods_No" Then
                goodsCount = 1
            ElseIf fo.DB_Field = "Goods_Name" Then
                goodsCount = 2
            End If
            fo.Value = CB_ConditionValue2.ComboBox.Text
            fo.Field_Operator = Enum_Operator.Operator_Like
            oList.FoList.Add(fo)
        End If

        If goodsCount = 1 Then
            sqlbuider.Append(", List.Goods_No ")
            sqlbuider.Append(SQL_Produce_Get_Body)
            sqlbuider.Append(SQL_Produce_Get_leftJoin_GoodsNo)
        ElseIf goodsCount = 2 Then
            sqlbuider.Append(", List.Goods_No,List.Goods_Name ")
            sqlbuider.Append(SQL_Produce_Get_Body)
            sqlbuider.Append(SQL_Produce_Get_leftJoin_GoodsName)
        Else

            sqlbuider.Append(SQL_Produce_Get_Body)

        End If
        '   sqlbuider.Append(SQL_Produce_OrderBy)
        oList.Sql = sqlbuider.ToString
        Return oList
    End Function

    Private Sub Btn_Search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Search.Click
        Me.Me_Refresh()
    End Sub


#End Region

End Class
