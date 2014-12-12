Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports BaseClass

Public Class F15530_AT_Leave
    ''' <summary>
    ''' 权限获取
    ''' </summary>
    ''' <remarks></remarks>
    Sub FormCheckRight()
        Control_CheckRight(ID, ClassMain.Add, Cmd_Add)
        Control_CheckRight(ID, ClassMain.Modify, Cmd_Modify)
        Control_CheckRight(ID, ClassMain.Del, Cmd_Del)
    End Sub
    Private Sub F10100_At_Me_Load() Handles MyBase.Me_Load
        FormCheckRight()
        Ch_Name = GetBillTypeName(ID)
        'Dao.Balance_DB_NAME = Ch_Name
        Me.Title = Ch_Name & "列表"
        CB_ConditionName2.ComboBox.DataSource = Dao.Leave_GetConditionNames
        CB_ConditionName2.ComboBox.DisplayMember = "Field"
        CB_ConditionName2.ComboBox.ValueMember = "DB_Field"
        CB_ConditionValue2.ComboBox.DisplayMember = "ConditionValue"
        CB_ConditionValue2.ComboBox.ValueMember = "ConditionValue"
        DP_Start.Value = New Date(Today.Year, Today.Month, 1)
        DP_End.Value = Today


        Me_Refresh()
    End Sub

    Protected Sub Me_Refresh()
        Dim msg As DtReturnMsg = Dao.Leave_GetByOption(GetFindOtions)
        If msg.IsOk Then
            FG1.DtToSetFG(msg.Dt)

            If Me.ReturnId <> "" Then
                FG1.RowSetForce("LE_ID", ReturnId)
            End If

        End If
    End Sub


    ''' <summary>
    ''' 生成搜索条件
    ''' </summary>
    ''' <remarks></remarks>
    Protected Function GetFindOtions() As OptionList
        Dim oList As New OptionList
        Dim fo As New FindOption
        Dim goodsCount As Integer = 0
        fo = New FindOption
        fo.DB_Field = "Le_StartDate"
        fo.Value = DP_End.Value.Date
        fo.Field_Operator = Enum_Operator.Operator_LessOrEqual
        oList.FoList.Add(fo)
        fo = New FindOption
        fo.DB_Field = "Le_EndDate"
        fo.Value = DP_Start.Value.Date
        fo.Field_Operator = Enum_Operator.Operator_MoreOrEqual
        oList.FoList.Add(fo)


        If TCS_Name.IDAsInt <> 0 AndAlso TCS_Name.Text <> "" Then
            fo = New FindOption
            fo.DB_Field = "Employee_ID"
            fo.Value = TCS_Name.IDAsInt
            fo.Field_Operator = Enum_Operator.Operator_Equal
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

    Private Sub CB_ConditionName2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CB_ConditionName2.SelectedIndexChanged
        If CB_ConditionName2.ComboBox.SelectedIndex = 0 Then
            CB_ConditionValue2.SelectedIndex = -1
            Exit Sub
        End If
        CB_ConditionValue2.ComboBox.Text = ""
        CB_ConditionValue2.ComboBox.SelectedIndex = -1
        Dim oList As OptionList = GetFindOtions()
        Dim paraMap As New Dictionary(Of String, Object)
        Dim msg As DtReturnMsg = OptionClass.OptionClass_GetConditionValues("(" & Dao.SQL_Leave_GetAll & " where 1=1 " & OptionClass.OptionClass_BuidSqlConditon(oList.FoList, paraMap) & ")Con", CB_ConditionName2.ComboBox.SelectedValue, "", paraMap)
        If msg.IsOk Then
            CB_ConditionValue2.ComboBox.DataSource = msg.Dt

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
        Dim F As New F15531_AT_Leave_Msg(0)
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
        If FG1.RowSel < 0 Then
            ShowErrMsg("请选择一个要修改的签卡记录")
            Exit Sub
        End If
        Dim F As New F15531_AT_Leave_Msg(FG1.Item(FG1.RowSel, "LE_ID"), DP_Start.Value, DP_End.Value, FG1.Item(FG1.RowSel, "Employee_ID"))
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
    Private Sub Edit_Retrun()
        If ReturnId <> "" Then
            Me_Refresh()
        End If
    End Sub







    ''' <summary>
    ''' 双击行.进入修改页面
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FG1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FG1.DoubleClick
        If FG1.RowSel < 0 Then
            ShowErrMsg("请选择一个要修改的签卡记录")
            Exit Sub
        End If

        Dim F As New F15531_AT_Leave_Msg(FG1.Item(FG1.RowSel, "LE_ID"), DP_Start.Value, DP_End.Value, FG1.Item(FG1.RowSel, "Employee_ID"))
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
        If FG1.RowSel <= 0 Then
            ShowErrMsg("请选择一个要修改的请假记录")
            Exit Sub
        End If
        ShowConfirm("是否删除请假记录 [" & FG1.Item(FG1.RowSel, "Employee_Name") & "]?", AddressOf DelAt)
    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub DelAt()
        Dim msg As MsgReturn = Dao.Leave_Del(FG1.Item(FG1.RowSel, "LE_ID"))
        If msg.IsOk Then
            Me_Refresh()
        Else
            ShowErrMsg(msg.Msg)

        End If

    End Sub

    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub
#End Region



    Private Sub Btn_Search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Search.Click
        Me_Refresh()
    End Sub
End Class


