Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports BaseClass
Imports PClass.CReport

Public Class F30104_PG
    Dim isLoaded As Boolean = False
    'Dim PeiBu As Boolean = False
    ''' <summary>
    ''' 权限获取
    ''' </summary>
    ''' <remarks></remarks>
    Sub FormCheckRight()

        'Control_CheckRight(ID, ClassMain.Add, Cmd_Add)
        Control_CheckRight(ID, ClassMain.Modify, Cmd_Modify)
        'Control_CheckRight(ID, ClassMain.Del, Cmd_Del)
        Control_CheckRight(ID, ClassMain.Print, Cmd_Preview)
        Control_CheckRight(ID, ClassMain.Print, Cmd_Print)


        'Control_CheckRight(ID, ClassMain.JiaJi, Cmd_JiaJi)
        'Control_CheckRight(ID, ClassMain.UnJiaJi, Cmd_UnJiaJi)
        'Control_CheckRight(ID, ClassMain.CanEdit, Cmd_Eidt)
        'Control_CheckRight(ID, ClassMain.CanEdit, Cmd_CancelEdit)

        'If User_ID = "Admin" Then
        '    PeiBu = True
        'Else
        '    PeiBu = False
        'End If
        'CheckRight(ID, ClassMain.PeiBu)
        CheckRight(ID, ClassMain.CanExcelOut)

        If CheckRight(ID, ClassMain.CanExcelOut) Then
            FG1.SetCanExcelOut()
        Else
            FG1.SetCanNotExcelOut()
        End If




    End Sub

    Private Sub F30104_PG_AfterLoad() Handles Me.AfterLoad
        'TB_GH.Focus()
    End Sub

    Private Sub Form_Me_Load() Handles Me.Me_Load
        FormCheckRight()
        Ch_Name = GetBillTypeName(ID)
        'Dao.Balance_DB_NAME = Ch_Name
        Me.Title = Ch_Name
        SplitContainer1.Panel2Collapsed = True
        '默认时间不可选
        'CB_SearchByDate.Checked = False
        FG1.IniFormat()
        FG1.IniColsSize()

        DP_Start.Value = Today.AddDays(-7)
        Dp_End.Value = Today

        CB_ConditionName1.ComboBox.DisplayMember = "Field"
        CB_ConditionName1.ComboBox.ValueMember = "DB_Field"
        CB_ConditionName1.ComboBox.DataSource = Dao.PG_GetConditionNames()

        CB_State.ComboBox.DisplayMember = "Field"
        CB_State.ComboBox.ValueMember = "DB_Field"
        CB_State.ComboBox.DataSource = Dao.PG_GetState

        'FG1.Cols("JiaJi").StyleDisplay.ForeColor = Color.Red

        'FG1.Cols("CR_LuoSeBzCount").StyleDisplay.ForeColor = Color.OrangeRed
        'FG1.Cols("PeiBu").StyleDisplay.ForeColor = Color.Blue
        'FG1.Cols("SongBu").StyleDisplay.ForeColor = Color.Blue
        'FG1.Cols("YuDing").StyleDisplay.ForeColor = Color.Blue
        FG1.Cols("RanSeGH").StyleDisplay.ForeColor = Color.OrangeRed
        'FG1.Cols("ChuGang").StyleDisplay.ForeColor = Color.Blue
        'FG1.Cols("TuoShui").StyleDisplay.ForeColor = Color.Blue
        'FG1.Cols("ZhongJian").StyleDisplay.ForeColor = Color.Blue
        'FG1.Cols("KaiFu").StyleDisplay.ForeColor = Color.Blue
        'FG1.Cols("DingXing").StyleDisplay.ForeColor = Color.Blue
        'FG1.Cols("ChengJian").StyleDisplay.ForeColor = Color.Blue
        'FG1.Cols("Date_JiaoHuo").StyleDisplay.ForeColor = Color.OrangeRed

        FG1.CanEditing = True
        'Cmd_CancelEdit.Visible = False
        FG1.Styles.Add("GreenRow", FG1.Styles("Normal"))
        FG1.Styles("GreenRow").BackColor = Color.GreenYellow
        Me_Refresh()
        isLoaded = True

    End Sub

    'Protected Sub Me_Refresh()
    '    Dim msg As DtReturnMsg = Dao.PG_GetByOption(GetFindOtions)
    '    If msg.IsOk Then
    '        SetFg(msg.Dt)

    '    End If
    'End Sub

    Protected Sub Me_Refresh()
        Static T As Threading.Thread
        If T IsNot Nothing Then
            If T.IsAlive Then
                Try
                    T.Abort()
                Catch ex As Exception
                End Try
            End If
        End If
        T = New Threading.Thread(AddressOf GetData)
        FG1.Visible = False
        Me.ShowLoading(MeIsLoad)
        T.Start(GetFindOtions)

    End Sub

    'Public Sub PG_Style(ByVal Style As String)
    '    Dim sqlBuider As New StringBuilder
    '    If CB_State.ComboBox.SelectedIndex >= 0 Then
    '        Select Case CB_State.ComboBox.SelectedIndex
    '            Case 0
    '                sqlBuider.Append("G.RGBH is not null")
    '            Case 1
    '                sqlBuider.Append("G.RGBH is null")

    '        End Select
    '    End If
    '    Style = sqlBuider.ToString
    'End Sub

    Protected Sub GetData(ByVal oList As OptionList)
        Dim sqlBuider As New StringBuilder
        Dim msg As DtReturnMsg = Dao.PG_GetByOption(oList)
        If msg.IsOk Then
            Me.Invoke(New DSetFG(AddressOf SetFg), msg.Dt)
        Else
            Me.Invoke(New DSetFG(AddressOf SetFg), Nothing)
        End If
    End Sub
    Private Delegate Sub DSetFG(ByVal Dt As DataTable)




#Region "Fg事件"
    Private Sub FG1_AfterEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles FG1.AfterEdit

        Dim IsUpdated As Boolean
        Select Case FG1.ColSel
            Case FG1.Cols("RanSeGH").Index
                'If FG1.Item(FG1.RowSel, "PeiBu") = "" AndAlso PeiBu = False Then
                '    ShowErrMsg("你没有权限把本单设置成配布状态")
                '    Exit Sub
                'End If
                Dim rGH As String = FG1.Item(FG1.RowSel, "RanSeGH")
                rGH = StrConv(rGH, vbNarrow)
                If rGH <> "" Then
                    'If FG1.Item(FG1.RowSel, "TuoShui") = "" Then
                    '    IsUpdated = UpdateState_RanSe(rGH, Enum_ProduceState.RanSe, True)
                    'Else
                    IsUpdated = UpdateState_RanSe(rGH, Enum_ProduceState.RanSe, False)
                    'End If
                    'Else
                    'IsUpdated = UpdateState_RanSe(rGH, Enum_ProduceState.YuDing, True)
                End If


                'Case FG1.Cols("Date_JiaoHuo").Index
                '    If FG1.Item(FG1.RowSel, "PeiBu") = "" AndAlso PeiBu = False Then
                '        ShowErrMsg("你没有权限把本单设置成配布状态")
                '        Exit Sub
                '    End If
                '    IsUpdated = UpdateState_SongHuo(FG1.Item(FG1.RowSel, "Date_JiaoHuo"), Enum_ProduceState.SongHuo)

            Case FG1.Cols("Remark").Index
                UpdateRemark(FG1.Item(FG1.RowSel, "Remark"))
        End Select
        If IsUpdated Then
            updateRow()
        End If
    End Sub

    Sub ChangeState()
        If UpdateState(LastState) Then
            updateRow()
        End If
    End Sub
    Dim LastState As Enum_ProduceState

    'Private Sub FG1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles FG1.Click

    '    If SplitContainer1.Panel2Collapsed = False Then
    '        Getworklist(FG1.Item(FG1.RowSel, "GH"))
    '    End If


    '    If FG1.RowSel < 1 OrElse FG1.Item(FG1.RowSel, "GH") = "" OrElse FG1.CanEditing = False Then
    '        Exit Sub
    '    End If



    '    'If FG1.ColSel = FG1.Cols("IsChecked").Index Then
    '    '    FG1.Item(FG1.RowSel, "IsChecked") = Not FG1.Item(FG1.RowSel, "IsChecked")
    '    '    Exit Sub
    '    'ElseIf FG1.ColSel < FG1.Cols("PeiBu").Index Then
    '    '    Exit Sub
    '    'End If


    '    Dim udpSuc As Boolean = False
    '    Dim State As Enum_ProduceState
    '    If FG1.Item(FG1.RowSel, "PeiBu") = "" AndAlso PeiBu = False AndAlso FG1.Cols("LRemark").Index <> FG1.ColSel Then
    '        ShowErrMsg("你没有权限把本单设置成配布状态")
    '        Exit Sub
    '    End If
    '    Select Case FG1.ColSel
    '        Case FG1.Cols("PeiBu").Index
    '            If FG1.Item(FG1.RowSel, "PeiBu") = "" AndAlso PeiBu = False Then
    '                ShowErrMsg("你没有权限把本单设置成配布状态")
    '                Exit Sub
    '            End If
    '            If FG1.Item(FG1.RowSel, "PeiBu") = "" Then
    '                State = Enum_ProduceState.PeiBu
    '            Else
    '                LastState = Enum_ProduceState.XiaDan
    '                ShowConfirm("单号[" & FG1.Item(FG1.RowSel, "GH") & "]已经配布,取消配布?", AddressOf ChangeState)
    '                Exit Sub
    '            End If
    '            'Case FG1.Cols("SongBu").Index
    '            '    If FG1.Item(FG1.RowSel, "PeiBu") = "" AndAlso PeiBu = False Then
    '            '        ShowErrMsg("你没有权限把本单设置成配布状态")
    '            '        Exit Sub
    '            '    End If
    '            '    If FG1.Item(FG1.RowSel, "SongBu") = "" Then
    '            '        State = Enum_ProduceState.SongBu
    '            '    Else
    '            '        State = Enum_ProduceState.PeiBu
    '            '    End If
    '            'Case FG1.Cols("YuDing").Index
    '            '    If FG1.Item(FG1.RowSel, "PeiBu") = "" AndAlso PeiBu = False Then
    '            '        ShowErrMsg("你没有权限把本单设置成配布状态")
    '            '        Exit Sub
    '            '    End If
    '            '    If FG1.Item(FG1.RowSel, "YuDing") = "" Then
    '            '        State = Enum_ProduceState.YuDing
    '            '    Else
    '            '        'State = Enum_ProduceState.SongBu
    '            '    End If
    '        Case FG1.Cols("RanSeGH").Index
    '            'If IsNull(FG1.Item(FG1.RowSel, "RanSeGH"), "") <> "" Then
    '            '    State = Enum_ProduceState.RanSe

    '            '    Exit Sub
    '            'Else
    '            '    State = Enum_ProduceState.YuDing
    '            'End If
    '            FG1.StartEditing(FG1.RowSel, FG1.Cols("RanSeGh").Index)
    '            Exit Sub



    '            'Case FG1.Cols("ChuGang").Index
    '            '    If FG1.Item(FG1.RowSel, "PeiBu") = "" AndAlso PeiBu = False Then
    '            '        ShowErrMsg("你没有权限把本单设置成配布状态")
    '            '        Exit Sub
    '            '    End If
    '            '    If FG1.Item(FG1.RowSel, "ChuGang") = "" Then
    '            '        State = Enum_ProduceState.ChuGang
    '            '    Else
    '            '        State = Enum_ProduceState.RanSe
    '            '    End If


    '            'Case FG1.Cols("TuoShui").Index
    '            '    If FG1.Item(FG1.RowSel, "PeiBu") = "" AndAlso PeiBu = False Then
    '            '        ShowErrMsg("你没有权限把本单设置成配布状态")
    '            '        Exit Sub
    '            '    End If
    '            'If FG1.Item(FG1.RowSel, "TuoShui") = "" Then
    '            '    State = Enum_ProduceState.TuoShui
    '            'Else
    '            '    'State = Enum_ProduceState.ChuGang
    '            'End If
    '            'Case FG1.Cols("ZhongJian").Index
    '            '    If FG1.Item(FG1.RowSel, "PeiBu") = "" AndAlso PeiBu = False Then
    '            '        ShowErrMsg("你没有权限把本单设置成配布状态")
    '            '        Exit Sub
    '            '    End If
    '            '    If FG1.Item(FG1.RowSel, "ZhongJian") = "" Then
    '            '        State = Enum_ProduceState.ZhongJian
    '            '    Else
    '            '        'State = Enum_ProduceState.TuoShui
    '            '    End If
    '            'Case FG1.Cols("KaiFu").Index
    '            '    If FG1.Item(FG1.RowSel, "PeiBu") = "" AndAlso PeiBu = False Then
    '            '        ShowErrMsg("你没有权限把本单设置成配布状态")
    '            '        Exit Sub
    '            '    End If
    '            '    If FG1.Item(FG1.RowSel, "KaiFu") = "" Then
    '            '        State = Enum_ProduceState.KaiFu
    '            '    Else
    '            '        'State = Enum_ProduceState.ZhongJian
    '            '    End If
    '            'Case FG1.Cols("DingXIng").Index
    '            '    If FG1.Item(FG1.RowSel, "PeiBu") = "" AndAlso PeiBu = False Then
    '            '        ShowErrMsg("你没有权限把本单设置成配布状态")
    '            '        Exit Sub
    '            '    End If
    '            '    If FG1.Item(FG1.RowSel, "DingXIng") = "" Then
    '            '        State = Enum_ProduceState.DingXing
    '            '    Else
    '            '        'State = Enum_ProduceState.KaiFu
    '            '    End If
    '            'Case FG1.Cols("ChengJian").Index
    '            '    If FG1.Item(FG1.RowSel, "PeiBu") = "" AndAlso PeiBu = False Then
    '            '        ShowErrMsg("你没有权限把本单设置成配布状态")
    '            '        Exit Sub
    '            '    End If
    '            '    If FG1.Item(FG1.RowSel, "ChengJian") = "" Then
    '            '        State = Enum_ProduceState.ChengJian
    '            '    Else
    '            '        'State = Enum_ProduceState.DingXing
    '            '    End If
    '        Case FG1.Cols("Date_JiaoHuo").Index
    '            FG1.StartEditing(FG1.RowSel, FG1.Cols("Date_JiaoHuo").Index)
    '            Exit Sub
    '        Case FG1.Cols("LRemark").Index
    '            FG1.StartEditing(FG1.RowSel, FG1.Cols("LRemark").Index)
    '            Exit Sub
    '            'Case FG1.Cols("IsChecked").Index
    '            '    FG1.Item(FG1.RowSel, "IsChecked") = Not FG1.Item(FG1.RowSel, "IsChecked")
    '            '    Exit Sub
    '        Case Else
    '            Exit Sub

    '    End Select

    '    If UpdateState(State) Then
    '        updateRow()
    '    End If



    'End Sub

    'Private Sub Getworklist(ByVal GH As String)

    '    Dim dtwork As DtReturnMsg = Dao.Produce_Worklist(GH)
    '    If dtwork.IsOk Then
    '        dtwork.Dt.Columns.Add("StateName", GetType(String))

    '        For Each dr As DataRow In dtwork.Dt.Rows
    '            dr("StateName") = ComFun.GetWorkStateName(IsNull(dr("State"), Enum_WorkState.None))
    '        Next
    '        Fg2.DtToFG(dtwork.Dt)
    '    End If

    'End Sub


    Private Sub FG1_SelectRowChange(ByVal Row As Integer) Handles FG1.SelectRowChange
        If Row > 0 Then
            If IIf(FG1.Item(Row, "State") Is Nothing, Enum_ProduceState.AddNew, FG1.Item(Row, "State")) = Enum_ProduceState.Invalid Then
                Cmd_Del.Enabled = True
            Else
                Cmd_Del.Enabled = False
            End If
        End If
    End Sub

#End Region

#Region "加载FG"
    Private Sub updateRow()
        Dim R As DtReturnMsg = Dao.PG_GetByGH(FG1.Item(FG1.RowSel, "GH"))
        If R.IsOk AndAlso R.Dt.Rows.Count >= 1 Then
            SetRow(R.Dt.Rows(0), FG1.RowSel)
        End If
    End Sub

    Private Sub SetRow(ByVal dr As DataRow, ByVal rowIndex As Integer)
        Dim State As Enum_ProduceState = IsNull(dr("State"), Enum_ProduceState.AddNew)
        FG1.Item(rowIndex, "State") = IsNull(dr("State"), Enum_ProduceState.AddNew)
        FG1.Item(rowIndex, "Date_KaiDan") = dr("Date_KaiDan")

        FG1.Item(rowIndex, "Contract") = dr("Contract")


        If IsNull(dr("ClientBzc"), "") <> "" Then
            dr("ClientBzc") = dr("ClientBzc") & "#"
        Else
            dr("ClientBzc") = ""
        End If
        If IsNull(dr("BZ_No"), "").ToString.Contains("#") = False Then
            dr("BZ_No") = ""
        End If
        If IsNull(dr("IsFD"), False) = True AndAlso IsNull(dr("BzcMsg"), "") = "" Then
            dr("BzcMsg") = "返定"
        Else

            If IsNull(dr("BzcMsg"), "") = "" Then
                dr("BzcMsg") = dr("ClientBzc") & dr("BZC_Name") & vbCrLf & "GY-" & Format(IsNull(dr("BZc_No"), ""), "000000") & dr("BZC_PF")
                'Else
                '    dr("BzcMsg") = dr("BzcMsg").ToString.Replace(vbCrLf, "")
            End If
        End If
        FG1.Item(rowIndex, "BZC") = dr("BzcMsg")
        FG1.Item(rowIndex, "BZ") = dr("BZ_No") & dr("BZ_Name")
        FG1.Item(rowIndex, "GH") = dr("GH")
        FG1.Item(rowIndex, "RGBH") = IsNull(dr("RGBH"), "")
        FG1.Item(rowIndex, "Client_Name") = dr("Client_Name")
        FG1.Item(rowIndex, "Remark") = IsNull(dr("Remark"), "")
        FG1.Item(rowIndex, "BZC_Name") = dr("BZC_Name")
        FG1.Item(rowIndex, "BZc_No") = dr("BZc_No")
        FG1.Item(rowIndex, "RanSeGH") = IIf(State >= Enum_ProduceState.RanSe, dr("RanSeGH"), "")
        'FG1.Item(rowIndex, "CPName") = dr("CPName")
        'FG1.Item(rowIndex, "CR_LuoSeBzZL") = dr("CR_LuoSeBzZL")
        FG1.Item(rowIndex, "CR_LuoSeBzCount") = dr("CR_LuoSeBzCount")
        FG1.Item(rowIndex, "PB_ZLSum") = dr("PB_ZLSum")
        'If IsNull(dr("PB_CountSum"), 0) = 0 Then
        '    FG1.Item(rowIndex, "PeiBu") = IIf(State >= Enum_ProduceState.PeiBu, "●", "")
        'Else
        '    FG1.Item(rowIndex, "PeiBu") = IIf(State >= Enum_ProduceState.PeiBu, "★", "")
        'End If
        'FG1.Item(rowIndex, "YuDing") = IIf(State >= Enum_ProduceState.YuDing, "★", "")
        'FG1.Item(rowIndex, "SongBu") = IIf(State >= Enum_ProduceState.SongBu, "★", "")
        'FG1.Item(rowIndex, "ChuGang") = IIf(State >= Enum_ProduceState.ChuGang, "★", "")
        'FG1.Item(rowIndex, "TuoShui") = IIf(State >= Enum_ProduceState.TuoShui, "★", "")
        'FG1.Item(rowIndex, "ZhongJian") = IIf(State >= Enum_ProduceState.ZhongJian, "★", "")

        'FG1.Item(rowIndex, "KaiFu") = IIf(State >= Enum_ProduceState.KaiFu, "★", "")
        'FG1.Item(rowIndex, "DingXing") = IIf(State >= Enum_ProduceState.DingXing, "★", "")
        'FG1.Item(rowIndex, "ChengJian") = IIf(State >= Enum_ProduceState.ChengJian, "★", "")

        'FG1.Item(rowIndex, "Date_JiaoHuo") = IIf(State >= Enum_ProduceState.SongHuo, dr("Date_JiaoHuo"), Nothing)
        FG1.Item(rowIndex, "JGSJ") = IsNull(dr("JGSJ"), "")
        FG1.Item(rowIndex, "CGSJ") = IsNull(dr("CGSJ"), "")
        'If IsNull(dr("JiaJi"), False) = True Then
        '    FG1.Item(rowIndex, "JiaJi") = "加急"
        '    '   FG1.se()
        '    FG1.Rows(rowIndex).Style = FG1.Styles("GreenRow")
        '    '' FG1.Rows(rowIndex).Style.BackColor = Color.GreenYellow
        '    '  FG1.SetCellStyle( rowIndex ,FG1.Cols （“JiaJi”）.Index ,
        'Else
        '    FG1.Item(rowIndex, "JiaJi") = ""
        'End If

        FG1.Item(rowIndex, "IsChecked") = False

    End Sub

    Private Sub SetFg(ByVal dt As DataTable)
        FG1.Redraw = False
        FG1.FinishEditing()
        Dim i As Integer = 1
        FG1.Rows.Count = 1
        Dim sumQty As Integer = 0
        Dim sumZL As Double = 0
        If dt IsNot Nothing Then
            For Each dr As DataRow In dt.Rows
                FG1.AddRow()
                FG1.Rows(i).HeightDisplay = 38
                Try
                    SetRow(dr, i)
                Catch ex As Exception

                End Try
                i += 1
                sumQty += IsNull(dr("CR_LuoSeBzCount"), 0)
                sumZL += IsNull(dr("PB_ZLSum"), 0)
            Next
        End If
        'LB_Luose_Qty.Text = sumQty
        'LB_LuoSe_ZL.Text = sumZL
        FG1.RowSetForce("GH", ReturnId)
        FG1.Redraw = True
        FG1.Visible = True
        Me.HideLoading()
    End Sub
#End Region



#Region "新增,修改"
    Private Function UpdateState_RanSe(ByVal _RanSeGh As String, ByVal state As Enum_ProduceState, ByVal UpdateState As Boolean) As Boolean
        Dim Msg As MsgReturn = Dao.Produce_UpdateState_RanSeGH(FG1.Item(FG1.RowSel, "GH"), _RanSeGh, state, UpdateState)
        If Msg.IsOk = False Then
            ShowErrMsg(Msg.Msg)
        Else

        End If
        Return Msg.IsOk
    End Function


    Private Function UpdateState_SongHuo(ByVal SongHuoDate As Date, ByVal state As Enum_ProduceState) As Boolean
        Dim Msg As MsgReturn = Dao.Produce_UpdateState_ChuHuo(FG1.Item(FG1.RowSel, "GH"), SongHuoDate, state)
        If Msg.IsOk = False Then
            ShowErrMsg(Msg.Msg)
        Else

        End If
        Return Msg.IsOk
    End Function
    Private Function UpdateState(ByVal _State As Enum_ProduceState) As Boolean
        Dim Msg As MsgReturn = Dao.Produce_UpdateState(FG1.Item(FG1.RowSel, "GH"), _State)
        If Msg.IsOk = False Then
            ShowErrMsg(Msg.Msg)
        Else

        End If
        Return Msg.IsOk
    End Function

    ''' <summary>
    ''' 更新备注
    ''' </summary>
    ''' <param name="Remark"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function UpdateRemark(ByVal Remark As String) As Boolean
        Dim Msg As MsgReturn = Dao.Produce_UpdateRemark(FG1.Item(FG1.RowSel, "GH"), Remark)
        If Msg.IsOk = False Then
            ShowErrMsg(Msg.Msg)
        Else

        End If
        Return Msg.IsOk
    End Function


    ''' <summary>
    ''' 双击行.进入修改页面
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FG1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FG1.DoubleClick
        If FG1.CanEditing = False Then
            ShowModify()
        End If

    End Sub

    Protected Sub ShowModify()
        If FG1.RowSel < 0 Then
            ShowErrMsg("请选择一个要修改的" & Dao.PG_DB_NAME)
            Exit Sub
        End If
        Dim F As New F30105_PG_Msg(FG1.Item(FG1.RowSel, "GH"))
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



    'Private Sub Cmd_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Add.Click
    '    Dim F As New F30009_PG_Msg()
    '    With F
    '        .Mode = Mode_Enum.Add
    '        .P_F_RS_ID = ""
    '        .P_F_RS_ID2 = ""
    '    End With
    '    F_RS_ID = ""
    '    Me.ReturnId = ""
    '    Me.ReturnObj = Nothing
    '    Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F, Me)
    '    AddHandler VF.ClosedX, AddressOf Edit_Retrun
    '    VF.Show()
    'End Sub

#End Region


#Region "控件事件"

    Private Sub Cmd_Del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Del.Click
        If FG1.RowSel <= 0 Then
            ShowMsg("请选择一个要删除的" & Dao.PG_DB_NAME, "")
            Exit Sub
        End If
        ShowConfirm("是否删除" & Dao.PG_DB_NAME & " [" & FG1.Item(FG1.RowSel, "GH") & "]?", AddressOf DelProduce)
    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub DelProduce()

        Dim msg As MsgReturn = Dao.ProduceGd_Del(FG1.Item(FG1.RowSel, "GH"))
        If msg.IsOk Then
            Me_Refresh()
        Else
            ShowErrMsg(msg.Msg)

        End If

    End Sub


    Private Sub Cmd_Modify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Modify.Click
        ShowModify()
    End Sub

    Private Sub Edit_Retrun()
        If ReturnId <> "" Then
            Me_Refresh()
        End If
    End Sub
    Private Sub Cmd_Refresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Refresh.Click
        Me_Refresh()
    End Sub


    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub
#End Region
    Private Sub Client_List1_Col_Sel(ByVal Col_No As String, ByVal Col_Name As String, ByVal ID As String) Handles TSC_Client.Col_Sel
        If TSC_BZ.SearchID <> ID Then
            TSC_BZ.Text = ""
            TSC_BZ.IDValue = 0

            TSC_BZC.Text = ""
            TSC_BZC.IDValue = 0
        End If
        TSC_BZ.SearchType = cSearchType.ENum_SearchType.Client
        TSC_BZ.SearchID = ID

        TSC_BZC.SearchType = cSearchType.ENum_SearchType.Client
        TSC_BZC.SearchID = ID
    End Sub

    Private Sub TSC_Client_SetEmpty() Handles TSC_Client.SetEmpty
        TSC_Client.IDValue = 0
        TSC_BZ.SearchType = cSearchType.ENum_SearchType.ALL
        TSC_BZ.SearchID = 0


        TSC_BZC.SearchType = cSearchType.ENum_SearchType.ALL
        TSC_BZC.SearchID = 0
    End Sub

#Region "搜索工具栏"




    ''' <summary>
    ''' 生成搜索条件
    ''' </summary>
    ''' <remarks></remarks>
    Protected Function GetFindOtions() As OptionList
        Dim oList As New OptionList
        Dim fo As New FindOption
        Dim goodsCount As Integer = 0
        fo = New FindOption
        fo.DB_Field = "G.Date_KaiDan"
        fo.Value = DP_Start.Value.Date
        fo.Value2 = Dp_End.Value.Date
        fo.Field_Operator = Enum_Operator.Operator_Between
        oList.FoList.Add(fo)


       
        If Val(TSC_Client.IDValue) <> 0 Then
            fo = New FindOption
            fo.DB_Field = "G.Client_ID"
            fo.Value = Val(TSC_Client.IDValue)
            fo.Field_Operator = Enum_Operator.Operator_Equal
            oList.FoList.Add(fo)
        End If

        If Val(TSC_BZ.IDValue) <> 0 Then
            fo = New FindOption
            fo.DB_Field = "G.BZ_ID"
            fo.Value = Val(TSC_BZ.IDValue)
            fo.Field_Operator = Enum_Operator.Operator_Equal
            oList.FoList.Add(fo)
        End If

        If Val(TSC_BZC.IDValue) <> 0 Then
            fo = New FindOption
            fo.DB_Field = "G.BZC_ID"
            fo.Value = Val(TSC_BZC.IDValue)
            fo.Field_Operator = Enum_Operator.Operator_Equal
            oList.FoList.Add(fo)
        End If



        If CB_State.ComboBox.SelectedIndex >= 0 Then
            Select Case CB_State.ComboBox.SelectedIndex
                Case 0
                    fo = New FindOption
                    fo.DB_Field = "G.RGBH"
                    fo.Field_Operator = Enum_Operator.Operator_IsNotNull
                    oList.FoList.Add(fo)

                Case 1
                    fo = New FindOption
                    fo.DB_Field = "G.RGBH"
                    fo.Field_Operator = Enum_Operator.Operator_IsNull
                    oList.FoList.Add(fo)


                Case 2
                    fo = New FindOption
                    fo.DB_Field = "G.RGBH"
                    fo.Field_Operator = Enum_Operator.Operator_IsNotNull
                    oList.FoList.Add(fo)

                    fo = New FindOption
                    fo.DB_Field = "JGSJ"
                    fo.Field_Operator = Enum_Operator.Operator_IsNull
                    oList.FoList.Add(fo)
                Case 3
                    fo = New FindOption
                    fo.DB_Field = "G.RGBH"
                    fo.Field_Operator = Enum_Operator.Operator_IsNotNull
                    oList.FoList.Add(fo)

                    fo = New FindOption
                    fo.DB_Field = "JGSJ"
                    fo.Field_Operator = Enum_Operator.Operator_IsNotNull
                    oList.FoList.Add(fo)

                    fo = New FindOption
                    fo.DB_Field = "CGSJ"
                    fo.Field_Operator = Enum_Operator.Operator_IsNull
                    oList.FoList.Add(fo)
                   


            End Select
        End If


            If CB_ConditionName1.ComboBox.SelectedItem IsNot Nothing AndAlso TB_ConditionValue1.Text <> "" Then
                fo = CB_ConditionName1.ComboBox.SelectedItem
                fo.Value = TB_ConditionValue1.Text
                If fo.Field_Operator <> Enum_Operator.Operator_In Then fo.Field_Operator = Enum_Operator.Operator_Like_Both
                oList.FoList.Add(fo)
            End If

            Return oList
    End Function

    Private Sub Btn_Search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Search.Click
        Me.Me_Refresh()
    End Sub



#End Region

#Region "报表事件"

    Private Sub Btn_Preview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Print(OperatorType.Preview)
    End Sub

    Private Sub Cmd_Print_ButtonDoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Btn_Print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Print(OperatorType.Print)
    End Sub

    ''打印加急

    'Private Sub Cmd_Preview_JiaJi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Preview_JiaJi.Click
    '    Print_JiaJi(OperatorType.Preview)
    'End Sub
    'Private Sub Cmd_Print_JiaJi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Print_JiaJi.Click
    '    Print_JiaJi(OperatorType.Print)
    'End Sub

    Protected Sub Print(ByVal DoOperator As OperatorType, Optional ByVal IsSel As Boolean = False)
        If FG1.Rows.Count < 0 Then
            ShowErrMsg("没有内容可以打印!")
            Exit Sub
        End If
        Dim R As New R30104_PG(CheckRight(ID, ClassMain.RpCanExcelOut))
        Dim dt As DataTable
        If IsSel Then
            dt = GetPrintDt_Sel()
        Else
            ShowErrMsg("没有选择要打印的项!")
            Exit Sub
        End If

        R.Start(dt, DoOperator)
    End Sub

    'Protected Sub Print_JiaJi(ByVal DoOperator As OperatorType)
    '    If FG1.Rows.Count < 0 Then
    '        ShowErrMsg("没有内容可以打印!")
    '        Exit Sub
    '    End If
    '    Dim R As New R30100_Process(CheckRight(ID, ClassMain.RpCanExcelOut))
    '    R.Start_JiaJi(GetPrintDt_JiaJi, DoOperator)
    'End Sub

    'Private Function GetPrintDt() As DataTable
    '    Dim dt As DataTable = Dao.PG_PrintDt()

    '    Dim dr As DataRow
    '    For i As Int16 = 1 To FG1.Rows.Count - 1
    '        dr = dt.NewRow
    '        FGRowToDr(dr, i)

    '        dt.Rows.Add(dr)
    '    Next
    '    Return dt
    'End Function

    '打印选择项
    Private Sub Cmd_Print_Sel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Print(OperatorType.Print, True)
    End Sub
    Private Sub Cmd_Preview_Sel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Print(OperatorType.Preview, True)
    End Sub
    'Private Function GetPrintDt_JiaJi() As DataTable
    '    Dim dt As DataTable = Dao.Process_GetEmpty_PrintDt()

    '    Dim dr As DataRow
    '    For i As Int16 = 1 To FG1.Rows.Count - 1
    '        If FG1.Item(i, "JiaJi") = "" Then
    '            Continue For
    '        End If
    '        dr = dt.NewRow
    '        FGRowToDr(dr, i)

    '        dt.Rows.Add(dr)
    '    Next
    '    Return dt
    'End Function

    Private Function GetPrintDt_Sel() As DataTable
        Dim dt As DataTable = Dao.PG_PrintDt()
        Dim dr As DataRow
        'For i As Int16 = 1 To FG1.Rows.Count - 1
        '    If FG1.Item(i, "IsChecked") = False Then
        '        Continue For
        '    End If
        dr = dt.NewRow
        'FGRowToDr(dr, i)
        FGRowToDr(dr)
        dt.Rows.Add(dr)
        'Next
        Return dt
    End Function

    Private Sub FGRowToDr(ByRef dr As DataRow)
        Dim j As Int16 = 0
        For i As Int16 = 1 To FG1.Rows.Count - 1
            If FG1.Item(i, "IsChecked") = False Then
                Continue For
            End If
            j += 1
            'dr("Date_KaiDan") = FG1.Item(i, "Date_KaiDan")
            dr("Client_Name" & j) = FG1.Item(i, "Client_Name")
            'dr("JiaJi") = FG1.Item(i, "JiaJi")
            'dr("Contract") = FG1.Item(i, "Contract")
            dr("BZ" & j) = FG1.Item(i, "BZ")
            dr("BZC" & j) = FG1.Item(i, "BZC")
            dr("GH" & j) = FG1.Item(i, "GH")
            dr("RGBH" & j) = FG1.Item(i, "RGBH")
            dr("CR_LuoSeBzCount" & j) = FG1.Item(i, "CR_LuoSeBzCount")
            'dr("PeiBu") = FG1.Item(i, "PeiBu")
            'dr("SongBu") = FG1.Item(i, "SongBu")
            'dr("YuDing") = FG1.Item(i, "YuDing")
            dr("RanSeGH" & j) = FG1.Item(i, "RanSeGH")
            'dr("ChuGang") = FG1.Item(i, "ChuGang")
            'dr("TuoShui") = FG1.Item(i, "TuoShui")
            'dr("ZhongJian") = FG1.Item(i, "ZhongJian")
            'dr("KaiFu") = FG1.Item(i, "KaiFu")
            'dr("DingXIng") = FG1.Item(i, "DingXIng")
            'dr("ChengJian") = FG1.Item(i, "ChengJian")
            'dr("Date_JiaoHuo") = IIf(FG1.Item(i, "Date_JiaoHuo") Is Nothing, DBNull.Value, FG1.Item(i, "Date_JiaoHuo"))
            'dr("JGSJ") = FG1.Item(i, "JGSJ")
            'dr("CGSJ") = FG1.Item(i, "CGSJ")
            dr("PB_ZLSum" & j) = FG1.Item(i, "PB_ZLSum")
            dr("BZC_Name" & j) = FG1.Item(i, "BZC_Name")
            dr("BZc_No" & j) = FG1.Item(i, "BZc_No")
            dr("Remark" & j) = FG1.Item(i, "Remark")
        Next

    End Sub

#End Region



#Region "加急"
    ''' <summary>
    ''' 设置所有选择的行为加急
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    'Private Sub Cmd_JiaJi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim sqlBuider As New StringBuilder
    '    Dim P As New Dictionary(Of String, Object)
    '    P.Add("UPD_User", User_Name)
    '    For i As Int16 = 1 To FG1.Rows.Count - 1
    '        If FG1.Item(i, "IsChecked") = True AndAlso FG1.Item(i, "GH") <> "" Then
    '            sqlBuider.AppendLine("Update T30000_Produce_Gd set JiaJi=1,UPD_User=@UPD_User,UPD_Date=GetDate() where GH='" & FG1.Item(i, "GH") & "' ")
    '        End If
    '    Next
    '    If sqlBuider.ToString.Trim.Length <= 0 Then
    '        Exit Sub
    '    End If
    '    Dim R As MsgReturn = RunSQL(sqlBuider.ToString, P)
    '    If R.IsOk = False Then
    '        ShowErrMsg(R.Msg)
    '    Else
    '        Me_Refresh()
    '    End If
    'End Sub



    'Private Sub Cmd_UnJiaJi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim sqlBuider As New StringBuilder
    '    Dim P As New Dictionary(Of String, Object)
    '    P.Add("UPD_User", User_Name)
    '    For i As Int16 = 1 To FG1.Rows.Count - 1
    '        If FG1.Item(i, "IsChecked") = True AndAlso FG1.Item(i, "GH") <> "" Then
    '            sqlBuider.AppendLine("Update T30000_Produce_Gd set JiaJi=0,UPD_User=@UPD_User,UPD_Date=GetDate() where GH='" & FG1.Item(i, "GH") & "' ")
    '        End If
    '    Next
    '    If sqlBuider.ToString.Trim.Length <= 0 Then
    '        Exit Sub
    '    End If
    '    Dim R As MsgReturn = RunSQL(sqlBuider.ToString, P)
    '    If R.IsOk = False Then
    '        ShowErrMsg(R.Msg)
    '    Else
    '        Me_Refresh()
    '    End If
    'End Sub
#End Region

    '#Region "鼠标右键事件"
    '    ''' <summary>
    '    ''' 
    '    ''' </summary>
    '    ''' <param name="sender"></param>
    '    ''' <param name="e"></param>
    '    ''' <remarks></remarks>
    '    'Private Sub Cmd_ChooseAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_ChooseAll.Click
    '    '    If FG1.Rows.Count > 1 AndAlso FG1.CanEditing = True Then
    '    '        For i = 1 To FG1.Rows.Count - 1
    '    '            FG1.Item(i, "IsChecked") = True
    '    '        Next
    '    '    End If
    '    'End Sub
    '    ''' <summary>
    '    ''' 
    '    ''' </summary>
    '    ''' <param name="sender"></param>
    '    ''' <param name="e"></param>
    '    ''' <remarks></remarks>
    '    'Private Sub Cmd_UnChooseAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_UnChooseAll.Click
    '    '    If FG1.Rows.Count > 1 AndAlso FG1.CanEditing = True Then
    '    '        For i = 1 To FG1.Rows.Count - 1
    '    '            FG1.Item(i, "IsChecked") = False
    '    '        Next
    '    '    End If
    '    'End Sub
    '    ''' <summary>
    '    ''' 
    '    ''' </summary>
    '    ''' <param name="sender"></param>
    '    ''' <param name="e"></param>
    '    ''' <remarks></remarks>
    '    Private Sub Cmd_UnChoose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_UnChoose.Click
    '        If FG1.Rows.Count > 1 AndAlso FG1.CanEditing = True Then
    '            For i = 1 To FG1.Rows.Count - 1
    '                FG1.Item(i, "IsChecked") = Not FG1.Item(i, "IsChecked")
    '            Next
    '        End If
    '    End Sub


    '#End Region


#Region "编辑状态"
    'Private Sub Cmd_Eidt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    FG1.CanEditing = True
    '    'Cmd_CancelEdit.Visible = True
    '    'Cmd_Eidt.Visible = False
    'End Sub


    'Private Sub Cmd_CancelEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    FG1.FinishEditing()
    '    FG1.CanEditing = False
    '    'Cmd_CancelEdit.Visible = False
    '    'Cmd_Eidt.Visible = True
    'End Sub
#End Region





    Private Sub Cmd_Print_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub


    'Private Sub Cmd_FormInorOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_FormInorOut.Click
    '    SetFormInorOut(Me.VForm)
    'End Sub


    'Private Sub Cmd_ShowWork_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    SplitContainer1.Panel2Collapsed = False
    '    'Cmd_ShowWork.Visible = False
    '    'Cmd_CanCelWork.Visible = True
    '    Getworklist(FG1.Item(FG1.RowSel, "GH"))
    'End Sub

    'Private Sub Cmd_CanCelWork_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    SplitContainer1.Panel2Collapsed = True
    '    'Cmd_ShowWork.Visible = True
    '    'Cmd_CanCelWork.Visible = False
    'End Sub

    Private Sub Cmd_Preview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Preview.Click
        Dim j As Int16 = 0
        For i As Int16 = 1 To FG1.Rows.Count - 1
            If FG1.Item(i, "IsChecked") = False Then
                Continue For
            Else
                j += 1
            End If
        Next
        If j <= 4 Then
            Print(OperatorType.Preview, True)
        Else
            ShowErrMsg("选择项超出最大预览项！")
        End If
    End Sub

    Private Sub Cmd_Print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Print.Click
        Dim j As Int16 = 0
        For i As Int16 = 1 To FG1.Rows.Count - 1
            If FG1.Item(i, "IsChecked") = False Then
                Continue For
            Else
                j += 1
            End If
        Next
        If j <= 4 Then
            Print(OperatorType.Print, True)
        Else
            ShowErrMsg("选择项超出最大打印项！")
        End If
    End Sub


End Class

Partial Friend Class Dao

    Public Const PG_DB_NAME As String = "排缸表"

    '===================进度表信息==============
    Public Const SQL_PG_Get_WithName = " select G.GH,G.State,G.RanSeGH,G.Date_JiaoHuo,G.Date_KaiDan,G.BZC_ID,G.ClientBZC,G.BZ_ID,G.Contract,G.CR_LuoSeBzCount,G.IsFD,BzcMsg,G.PB_CountSum,G.CPName,G.CR_LuoSeBzZL,G.PB_ZLSum, " & _
                                            "G.State, G.Client_ID,C.Client_No,C.Client_Name,G.Remark  ,G.CR_LuoSeBzCount,G.CR_LuoSeBzZL," & _
                                            "BZ.BZ_No,BZ.BZ_Name,ClientBZC,BZC_No,BZC_Name,BZC_PF,G.RGBH,G.JGSJ,G.CGSJ" & _
                                            "  from T30000_Produce_Gd G  " & _
                                            "left join T10110_Client C on G.Client_ID =C.ID " & _
                                            "  left join T10003_BZC BZC on G.BZC_ID=BZC.ID " & _
                                            " left join T10002_BZ BZ on G.BZ_ID=BZ.ID   "

    Public Const SQL_PG_OrderBy As String = " order by  G.Client_ID,G.GH"

    Public Const SQL_PGWorklist_Get_GH As String = "Select * T30003_Produce_Worklist where GH=@GH"

    ''' <summary>
    ''' 获取查询条件集合
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function PG_GetConditionNames() As List(Of FindOption)
        Dim foList As New List(Of FindOption)
        Dim fo As New FindOption
        fo.Field = "请选择"
        fo.DB_Field = ""
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "缸号"
        fo.DB_Field = "G.Gh"
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "订单"
        fo.DB_Field = "G.Contract"
        foList.Add(fo)






        Return foList
    End Function



    ''' <summary>
    ''' 获取查询条件集合
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function PG_GetState() As List(Of FindOption)
        Dim foList As New List(Of FindOption)
        Dim fo As New FindOption
        fo.Field = "已排缸"
        fo.DB_Field = "G.RGBH"
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "未排缸"
        fo.DB_Field = "G.RGBH"
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "未进缸"
        fo.DB_Field = "G.JGSJ"
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "未出缸"
        fo.DB_Field = "G.CGSJ"
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "全部"
        fo.DB_Field = ""
        foList.Add(fo)

        Return foList
    End Function
    ''' <summary>
    ''' 按条件获取进度表列表
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function PG_GetByOption(ByVal oList As OptionList) As DtReturnMsg
        Dim paraMap As New Dictionary(Of String, Object)
        Dim sqlBuider As New StringBuilder
        sqlBuider.Append(SQL_PG_Get_WithName)
        sqlBuider.Append("  WHERE  1=1  ")
        sqlBuider.Append(BaseClass.OptionClass.OptionClass_BuidSqlConditon(oList.FoList, paraMap))
        sqlBuider.Append(SQL_PG_OrderBy)
        Return PClass.PClass.SqlStrToDt(sqlBuider.ToString, paraMap)
    End Function

    ''' <summary>
    ''' 按条件获取进度表列表
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function PG_GetByGH(ByVal _Gh As String) As DtReturnMsg
        Dim paraMap As New Dictionary(Of String, Object)
        paraMap.Add("GH", _Gh)
        Dim sqlBuider As New StringBuilder
        sqlBuider.Append(SQL_PG_Get_WithName)
        sqlBuider.Append("  WHERE Gh= @GH  ")

        Return PClass.PClass.SqlStrToDt(sqlBuider.ToString, paraMap)
    End Function

    Protected Function PG_Style() As String

    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' 
    'Public Shared Function PG_GetWorkState_ByTime(ByVal Start As Boolean, ByVal Finish As Boolean) As String
    '    If Start = False AndAlso Finish = False Then
    '        Return ComFun.GetWorkStateName(Enum_WorkState.None)
    '    ElseIf Start = True AndAlso Finish = False Then
    '        Return ComFun.GetWorkStateName(Enum_WorkState.Start)
    '    ElseIf Start = True AndAlso Finish = True Then
    '        Return ComFun.GetWorkStateName(Enum_WorkState.Finish)
    '    Else
    '        Return ComFun.GetWorkStateName(Enum_WorkState.Wrong)
    '    End If
    'End Function








End Class