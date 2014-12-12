Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports BaseClass
Public Class F10060_BZC
    Dim selectedGoodsType As String = ""
    Dim selectNode As TreeNode
    Dim nodeMap As New Dictionary(Of String, Object)
    Dim dtGoods As DataTable
    Dim dtlist As DataTable

    Private Sub F10020_BZC_AfterLoad() Handles Me.AfterLoad
        FG1.FG_ColResize()
        Fg2.FG_ColResize()
        Fg3.FG_ColResize()
        CB_ConditionName1.ComboBox.SelectedIndex = 0
        TB_ConditionValue1.Focus()
    End Sub

    Private Sub F10000_BZC_Form_KeyDown(ByVal sender As Object, ByRef e As System.Windows.Forms.KeyEventArgs) Handles Me.Form_KeyDown
        If e.KeyCode = Keys.Enter AndAlso IsSel = True Then
            Me_Refresh()
        End If
    End Sub


    'Private Sub Form_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.
    '    Select Case e.KeyChar
    '        Case vbCr
    '        Case Else
    '            If Me.ActiveControl.Text <> TB_ConditionValue1.Text Then
    '                If e.KeyChar = Chr(System.Windows.Forms.Keys.Back) Then
    '                    If TB_ConditionValue1.Text.Length > 0 Then TB_ConditionValue1.Text = TB_ConditionValue1.Text.Substring(0, TB_ConditionValue1.Text.Length - 1)
    '                    TB_ConditionValue1.Focus()
    '                Else
    '                    TB_ConditionValue1.Text = e.KeyChar
    '                    TB_ConditionValue1.Focus()
    '                End If
    '            End If
    '    End Select
    'End Sub


    Private Sub F10000_BZC_Form_KeyPress(ByVal sender As Object, ByRef e As System.Windows.Forms.KeyPressEventArgs) Handles Me.Form_KeyPress
        Select Case e.KeyChar
            Case vbCr
            Case Else
                If TB_ConditionValue1.Focused = False AndAlso TSC_BZ.Focused = False AndAlso TSC_Client.Focused = False Then
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

    Private Sub F10020_BZC_Me_Closing(ByVal sender As Object, ByRef e As System.ComponentModel.CancelEventArgs) Handles Me.Me_Closing
        Me.MeIsLoad = False
    End Sub


    Private Sub F10000_BZC_Me_Load() Handles Me.Me_Load
        FormCheckRight()
        '    Dim folist As List(Of FindOption) = BZC_GetConditionNames()
        FG1.IniColsSize()
        Fg2.IniColsSize()
        Fg3.IniColsSize()
        TSB_LastPrice.Checked = My.Settings.Lastprice
        Dim R As DtReturnMsg = Get_BZC()
        If R.IsOk Then
            dtBZC = R.Dt
        End If

        If P_F_RS_ID3 <> "" Then
            TSC_Client.IDAsInt = CInt(P_F_RS_ID3)
            TSC_Client.Text = TSC_Client.GetByTextBoxTag
        End If


        CB_ConditionName1.ComboBox.DisplayMember = "Field"
        CB_ConditionName1.ComboBox.ValueMember = "DB_Field"
        'TB_ConditionValue1.ComboBox.DisplayMember = "ConditionValue"
        'TB_ConditionValue1.ComboBox.ValueMember = "ConditionValue"
        CB_ConditionName1.ComboBox.DataSource = Dao.BZC_GetConditionNames()
        CB_ConditionName2.ComboBox.DisplayMember = ".Field"
        CB_ConditionName2.ComboBox.ValueMember = ".DB_Field"
        CB_ConditionValue2.ComboBox.DisplayMember = "ConditionValue"
        CB_ConditionValue2.ComboBox.ValueMember = "ConditionValue"
        CB_ConditionName2.ComboBox.DataSource = Dao.BZC_GetConditionNames()

        TB_ConditionValue1.Text = ""
        TB_ConditionValue1.Focus()
        ' Search()
        If IsSel Then
            Cmd_Select.Visible = True
            TSC_Client.Enabled = False
            Me_Refresh()
        End If
    End Sub
#Region "刷新FG"
    Public Nohide As Boolean = False

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
        T.Start(GetFindOtions)
        If Nohide = False Then Me.ShowLoading(MeIsLoad)
    End Sub


    Sub SetData(ByVal msg As DtReturnMsg)
        If msg.IsOk Then
            msg.Dt.Columns.Add("Select", GetType(Boolean))
            Try
                MeIsLoad = False
                dtGoods = msg.Dt
                Dim Dt As DataTable

                If SelectRetrun Then
                    Dt = TryCast(FG1.DataSource, DataTable)
                    If Dt Is Nothing Then
                        Dt = msg.Dt
                    Else
                        BaseClass.ComFun.DtReFreshRow(Dt, msg.Dt, "BZC_No", ReturnId)
                    End If
                Else
                    Dt = msg.Dt
                End If

                If SelectRetrun Then
                    SelectRetrun = False
                Else
                    FG1.DtToFG(Dt)
                    dtlist = Dt
                End If

                If ReturnId <> "" Then FG1.RowSetForce("BZC_No", CInt(Val(ReturnId)))
                If FG1.Rows.Count > 1 AndAlso FG1.RowSetForce("BZC_NoShow", Dao.BZC_NoToText(ReturnId)) = -1 Then
                    FG1.Row = 1
                    FG1.RowSel = 1
                End If
                If msg.Dt.Rows.Count = 0 Then
                    Fg2.Rows.Count = 1
                    Fg3.Rows.Count = 1
                    MeIsLoad = True
                Else
                    MeIsLoad = True
                    GetPF()
                End If
            Catch ex As Exception
                MeIsLoad = True
                DebugToLog(ex)
            End Try
        Else
            FG1.Rows.Count = 1
        End If
        Me.HideLoading()
        Nohide = False
    End Sub


    Protected Sub GetData(ByVal oList As OptionList)
        Dim msg As DtReturnMsg = Dao.SeBZC_GetByOption(oList)

        Me.Invoke(New DSetData(AddressOf SetData), msg)
    End Sub
    Private Delegate Sub DSetData(ByVal msg As DtReturnMsg)
#End Region
    Public SelectRetrun As Boolean = False


    Private Sub Edit_Retrun()
        If ReturnId <> "" Then
            SelectRetrun = True
            Me_Refresh()
        End If
    End Sub



#Region "数据库交互"

#End Region

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
        AddGoods()
    End Sub

    Protected Sub AddGoods()
        Dim F As New F10021_BZC_Msg("")
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
            ShowErrMsg("请选择一个要修改的色号")
            Exit Sub
        End If
        Dim F As New F10021_BZC_Msg(FG1.Item(FG1.RowSel, "ID"))
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
            '    ReturnGoods()
            'Else
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
            ShowErrMsg("请选择一个要删除的色号")
            Exit Sub
        End If
        ShowConfirm("是否删除色号 [" & FG1.Item(FG1.RowSel, "BZC_Name") & "]?", AddressOf DelGoods)
    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub DelGoods()




        Dim msg As MsgReturn = Dao.BZC_Del(FG1.Item(FG1.RowSel, "ID"))
        If msg.IsOk Then
            ReturnId = FG1.SelectItem("BZC_No")
            Edit_Retrun()

        Else
            ShowErrMsg(msg.Msg)
        End If
    End Sub

    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub

    Private Sub TSC_Client_SetEmpty() Handles TSC_Client.SetEmpty
        TSC_Client.IDValue = 0
        TSC_BZ.SearchType = cSearchType.ENum_SearchType.ALL
        TSC_BZ.SearchID = 0
    End Sub

    Private Sub CBL_Client_Col_Sel(ByVal Col_No As String, ByVal Col_Name As String, ByVal ID As String) Handles TSC_Client.Col_Sel
        If Val(ID) <> 0 Then
            If TSC_BZ.SearchID <> ID Then
                TSC_BZ.SetSearchEmpty()
            End If
            TSC_BZ.SearchType = cSearchType.ENum_SearchType.Client
            TSC_BZ.SearchID = ID
        Else
            TSC_BZ.SearchType = cSearchType.ENum_SearchType.ALL
            TSC_BZ.SearchID = 0
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
        ShowConfirm("是否删除色号 [" & FG1.SelectItem("BZC_Name") & "]?", AddressOf DelGoods)
    End Sub

#End Region


#Region "FG事件"
    Dim SelectedPFID As Integer = 0
    Public Sub GetPF()
        If FG1.RowSel >= FG1.Rows.Fixed Then
            Dim msg2 As DtReturnMsg = Dao.BZCPF_GetPFListByBZCID(FG1.Item(FG1.RowSel, "ID"))
            If msg2.IsOk Then
                MeIsLoad = False
                Fg2.DtToSetFG(msg2.Dt)
                MeIsLoad = True
                If SelectedPFID <> 0 AndAlso Fg2.Rows.Count > 1 Then
                    Fg2.RowSetForce(Fg2.Cols("ID").Index, SelectedPFID)
                End If
                If msg2.Dt.Rows.Count = 0 Then
                    Fg3.Rows.Count = 1
                Else
                    If Fg2.Rows.Count > 1 AndAlso Fg2.RowSel <= 0 Then
                        Fg2.Row = 1
                        Fg2.RowSel = 1
                    End If
                    MeIsLoad = True
                    GetPFLIst()
                End If

            End If
        End If
        MeIsLoad = True
    End Sub

    Protected Sub GetPFLIst()
        If Fg2.RowSel >= Fg2.Rows.Fixed Then
            Dim msg3 As DtReturnMsg = Dao.BZCPF_GeList_ByID(Fg2.Item(Fg2.RowSel, "ID"), FG1.Item(FG1.RowSel, "ID"))
            If msg3.IsOk Then
                Fg3.DtToSetFG(msg3.Dt)
                If Fg2.Item(Fg2.RowSel, "IsCheck") = True Then
                    Fg3.Cols("UpdQty").Visible = True
                Else
                    Fg3.Cols("UpdQty").Visible = False
                End If
            End If
        Else
            If Fg2.RowSel <= 0 AndAlso Fg2.Rows.Count > 1 Then
                Fg2.RowSel = 1
            End If
        End If

    End Sub

    'Private Sub Fg2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fg2.Click
    '    GetPFLIst()
    'End Sub


    'Private Sub Fg1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles FG1.Click
    '    GetPF()
    'End Sub


    Private Sub FG1_SelectRowChange(ByVal Row As Integer) Handles FG1.SelectRowChange
        If Me.MeIsLoad Then GetPF()
    End Sub


    Private Sub Fg2_SelectRowChange(ByVal Row As Integer) Handles Fg2.SelectRowChange
        If Me.MeIsLoad Then GetPFLIst()
    End Sub

    Private Sub Fg2_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fg2.DoubleClick
        Dim _BZC_ID As Integer = Val(FG1.Item(FG1.RowSel, "ID"))
        Dim _PFID As Integer = Val(Fg2.Item(Fg2.RowSel, "ID"))
        ModifyPF(_PFID, _BZC_ID)
    End Sub
    Protected Sub ModifyPF(ByVal _PFID As Integer, ByVal _BZC_ID As Integer)
        Dim F As New F10022_BZC_PF(_PFID, _BZC_ID)
        With F
            .Mode = Mode_Enum.Modify
            .P_F_RS_ID = ""
            .P_F_RS_ID2 = ""
        End With
        F_RS_ID = ""
        Me.ReturnId = ""
        Me.ReturnObj = Nothing
        Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F, Me)
        SelectedPFID = _PFID
        AddHandler VF.ClosedX, AddressOf GetPF
        VF.Show()
    End Sub



    Private Sub Fg3_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fg3.DoubleClick
        Dim _BZC_ID As Integer = Val(FG1.Item(FG1.RowSel, "ID"))
        Dim _PFID As Integer = Val(Fg2.Item(Fg2.RowSel, "ID"))
        ModifyPF(_PFID, _BZC_ID)
    End Sub
    Private Sub FG1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles FG1.KeyDown

        If e.KeyCode = Keys.Enter Then



            If FG1.RowSel <= 0 Then
                ShowErrMsg("请选择一个色号")
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
        Dim msg As DtReturnMsg = OptionClass.OptionClass_GetConditionValues(OptionClass.Table_BZC, CB_ConditionName2.ComboBox.SelectedValue, "")
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
        Me_Refresh()
    End Sub



    ''' <summary>
    '''自动搜索
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TB_ConditionValue1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TB_ConditionValue1.TextChanged
        If CB_ConditionName1.SelectedIndex <= 0 Then
            CB_ConditionName1.SelectedIndex = 1
        End If
        If TimerSearch.Enabled = False Then TimerSearch.Start()
    End Sub

    Dim LastSearch As String = ""
    Private Sub TimerSearch_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerSearch.Tick
        TimerSearch.Stop()
        LastSearch = TB_ConditionValue1.Text
        Try
            Nohide = True
            Me_Refresh()
            If LastSearch <> TB_ConditionValue1.Text Then
                TimerSearch.Start()
            End If
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
            If CB_ConditionName1.ComboBox.SelectedValue = "BZC_Name" Then
                sqlBuider.Append("  and( ")
                sqlBuider.Append(" BZC_FindHelper ")
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
        If CB_ConditionName1.ComboBox.SelectedValue = "BZC_Name" Then
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
    Protected Function GetFindOtions() As OptionList

        Dim oList As New OptionList
        Dim fo As New FindOption


        If Val(TSC_BZ.IDValue) <> 0 Then
            fo = New FindOption
            fo.DB_Field = " "
            fo.Value = TSC_BZ.IDValue
            fo.Field_Operator = Enum_Operator.Operator_Equal
            fo.SQL = " exists(SELECT * FROM V10003_Client_BZC where bz_id %Like% and C.id=BZC_ID) "
            fo.Sign = "%Like%"
            oList.FoList.Add(fo)


        End If

        If TSB_LastPrice.Checked = False Then
            fo = New FindOption
            fo.DB_Field = " "
            fo.Value = ""
            fo.Field_Operator = Enum_Operator.Operator_Equal
            fo.SQL = "  not exists(Select * from T50001_Price_List where BZC_ID=C.ID) "
            fo.Sign = "%Like%"
            oList.FoList.Add(fo)

        End If




        If Val(TSC_Client.IDValue) <> 0 Then
            fo = New FindOption
            fo.DB_Field = "Client_id"
            fo.Value = TSC_Client.IDValue
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
            fo.DB_Field = "BZC_No"
            fo.Value = Me.ReturnId
            fo.Field_Operator = Enum_Operator.Operator_Equal
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
        Dim rptLoader As New R10020_BZC()
        rptLoader.Start(dtGoods, type)
    End Sub

    Private Sub Cmd_Preview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Preview.Click
        Print(PClass.CReport.OperatorType.Preview)
    End Sub
#End Region

   
    Dim dtBZC As New DataTable
 
    Private Sub FG1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FG1.Click
        If FG1.RowSel < 1 OrElse FG1.ColSel <> (FG1.Cols("Select").Index) Then
            Exit Sub
        End If
        FG1.Item(FG1.RowSel, "Select") = Not IsNull(FG1.Item(FG1.RowSel, "Select"), False)
        If FG1.Item(FG1.RowSel, "Select") = True Then
            Dim row() As DataRow = dtlist.Select("ID='" & FG1.Item(FG1.RowSel, "ID") & "'")
            dtBZC.ImportRow(TryCast(row(0), DataRow))
        Else
            Dim row() As DataRow = dtBZC.Select("ID='" & FG1.Item(FG1.RowSel, "ID") & "'")
            dtBZC.Rows.Remove(TryCast(row(0), DataRow))
            dtBZC.AcceptChanges()
        End If
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Select.Click
        LastForm.ReturnObj = dtBZC
        Me.Close()
    End Sub


    Private Sub TSB_LastPrice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSB_LastPrice.Click
       
        My.Settings.Lastprice = TSB_LastPrice.Checked
        My.Settings.Save()
    End Sub
End Class
