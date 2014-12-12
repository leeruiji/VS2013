Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports BaseClass
Imports PClass.CReport

Public Class F40150_PBTC
    ''' <summary>
    ''' 权限获取
    ''' </summary>
    ''' <remarks></remarks>
    Sub FormCheckRight()
        Control_CheckRight(ID, ClassMain.Add, Cmd_Add)
        Control_CheckRight(ID, ClassMain.Modify, Cmd_Modify)

    End Sub
    Private Sub Me_AfterLoad() Handles Me.AfterLoad
        FG1.FG_ColResize()
        SumFG1.AddSum()
    End Sub



    Private Sub F10100_PBTC_Me_Load() Handles Me.Me_Load
        FormCheckRight()
        Ch_Name = GetBillTypeName(ID)
        'Dao.Balance_DB_NAME = Ch_Name
        Me.Title = Ch_Name & "列表"

        FG1.IniFormat()
        DP_Start.Value = GetDate()
        DP_End.Value = DP_Start.Value
        CB_ConditionName1.ComboBox.DisplayMember = "Field"
        CB_ConditionName1.ComboBox.ValueMember = "DB_Field"
        'CB_ConditionValue1.ComboBox.DisplayMember = "ConditionValue"
        'CB_ConditionValue1.ComboBox.ValueMember = "ConditionValue"
        CB_ConditionName1.ComboBox.DataSource = Dao.PBTC_GetConditionNames()
        'CB_ConditionName2.ComboBox.DisplayMember = ".Field"
        'CB_ConditionName2.ComboBox.ValueMember = ".DB_Field"
        'CB_ConditionValue2.ComboBox.DisplayMember = "ConditionValue"
        'CB_ConditionValue2.ComboBox.ValueMember = "ConditionValue"
        'CB_ConditionName2.ComboBox.DataSource = Dao.PBTC_GetConditionNames()
        Me_Refresh()
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
        FG1.Visible = False
        T.Start(GetFindOtions)
        If Nohide = False Then Me.ShowLoading(MeIsLoad)
    End Sub


    Sub SetData(ByVal msg As DtReturnMsg)
        If msg.IsOk Then
            msg.Dt.Columns.Add("IsChecked", GetType(Boolean))

            Dim Dt As DataTable

            If SelectRetrun Then
                Dt = TryCast(FG1.DataSource, DataTable)
                If Dt Is Nothing Then
                    Dt = msg.Dt
                Else
                    BaseClass.ComFun.DtReFreshRow(Dt, msg.Dt, "ID", ReturnId)
                End If
            Else
                Dt = msg.Dt
            End If

            If SelectRetrun Then
                SelectRetrun = False
            Else
                FG1.DtToFG(Dt)
            End If
            SumFG1.ReSum()
            FG1.RowSetForce("ID", ReturnId)
        Else
            FG1.Rows.Count = 1
        End If
        FG1.Visible = True
        Me.HideLoading()
        Nohide = False
    End Sub

    Protected Sub GetData(ByVal oList As OptionList)
        Dim msg As DtReturnMsg = Dao.PBTC_GetByOption(oList)
        Me.Invoke(New DSetData(AddressOf SetData), msg)
    End Sub
    Private Delegate Sub DSetData(ByVal msg As DtReturnMsg)

#End Region



    'Private Sub F40000_PBTC_KeyPress(ByVal sender As Object, ByRef e As System.Windows.Forms.KeyPressEventArgs) Handles Me.Form_KeyPress
    '    Select Case e.KeyChar
    '        Case vbCr
    '        Case Else
    '            If TB_ConditionValue1.Focused = False Then
    '                If e.KeyChar = Chr(System.Windows.Forms.Keys.Back) Then
    '                    If TB_ConditionValue1.Text.Length > 0 Then TB_ConditionValue1.Text = TB_ConditionValue1.Text.Substring(0, TB_ConditionValue1.Text.Length - 1)
    '                    TB_ConditionValue1.Focus()
    '                Else
    '                    TB_ConditionValue1.Text = e.KeyChar
    '                    TB_ConditionValue1.Focus()
    '                End If
    '                If CB_ConditionName1.SelectedIndex = 0 AndAlso CB_ConditionName1.Items.Count > 1 Then
    '                    CB_ConditionName1.SelectedIndex = 1
    '                End If
    '            End If
    '    End Select
    'End Sub


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
        Dim F As New F40151_PBTC_Msg("")
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
            ShowErrMsg("请选择一个要修改的仓位调整单")
            Exit Sub
        End If
        Dim F As New F40151_PBTC_Msg(FG1.SelectItem("ID"))
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
        If FG1.RowSel < 0 Then
            ShowErrMsg("请选择一个要修改的仓位调整单")
            Exit Sub
        End If
        Dim F As New F40151_PBTC_Msg(FG1.Item(FG1.RowSel, "ID"))
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
    Public SelectRetrun As Boolean = False

    Private Sub Edit_Retrun()
        If ReturnId <> "" Then
            SelectRetrun = True
            Me_Refresh()
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

    'Private Sub CB_ConditionName2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If CB_ConditionName2.ComboBox.SelectedIndex = 0 Then
    '        CB_ConditionValue2.SelectedIndex = -1
    '        Exit Sub
    '    End If
    '    Dim oList As OptionList = GetFindOtions()
    '    Dim msg As DtReturnMsg = OptionClass.OptionClass_GetConditionValues("(" & Dao.SQL_PBTC_Get_WithName & ")Con", CB_ConditionName2.ComboBox.SelectedValue, "")
    '    If msg.IsOk Then
    '        CB_ConditionValue2.ComboBox.DataSource = msg.Dt
    '    End If
    'End Sub


    ''' <summary>
    '''自动搜索
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TB_ConditionValue1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TB_ConditionValue1.TextChanged
        Nohide = True
        Me_Refresh()
    End Sub


    ''' <summary>
    ''' 生成搜索条件
    ''' </summary>
    ''' <remarks></remarks>
    Protected Function GetFindOtions() As OptionList

        Dim oList As New OptionList
        Dim fo As New FindOption
        '   oList.Sql = SQL_PBTC_Get_Sel
        '    Dim sqlbuider As New StringBuilder(SQL_PBTC_Get_Sel)
        Dim goodsCount As Integer = 0

        'fo = New FindOption
        'fo.DB_Field = "State"
        'fo.Value = -1
        'fo.Field_Operator = Enum_Operator.Operator_More
        'oList.FoList.Add(fo)


        fo = New FindOption
        fo.DB_Field = "sDate"
        fo.Value = DP_Start.Value.Date
        fo.Value2 = DP_End.Value.Date
        fo.Field_Operator = Enum_Operator.Operator_Between
        oList.FoList.Add(fo)


        If Not CB_ConditionName1.ComboBox.SelectedValue Is Nothing AndAlso Not CB_ConditionName1.ComboBox.SelectedValue = "" Then
            fo = New FindOption
            fo.DB_Field = CB_ConditionName1.ComboBox.SelectedValue

            fo.Value = TB_ConditionValue1.Text
            fo.Field_Operator = Enum_Operator.Operator_Like_Both
            oList.FoList.Add(fo)
        End If


        If Val(CB_BZ.IDValue) > 0 Then
            fo = New FindOption
            fo.Field = "布种编号"
            fo.DB_Field = "BZ_ID"
            fo.Value = CB_BZ.IDValue
            fo.Field_Operator = Enum_Operator.Operator_Equal
            fo.SQL = "exists(select * from T40151_PBTC_List L,T40101_PBRK_List R,T40100_PBRK_Table T where %BZ_ID% and T.ID=R.ID and L.ID=P.ID and R.Line=L.sLine)"
            fo.Sign = "%BZ_ID%"
            oList.FoList.Add(fo)
        End If
        'If Not CB_ConditionName2.ComboBox.SelectedValue Is Nothing AndAlso Not CB_ConditionName2.ComboBox.SelectedValue = "" Then
        '    fo = New FindOption
        '    fo.DB_Field = CB_ConditionName2.ComboBox.SelectedValue
        '    'If fo.DB_Field = "BZ_ID" Then
        '    '    goodsCount = 1
        '    'ElseIf fo.DB_Field = "BZ_Name" Then
        '    '    goodsCount = 2
        '    'End If
        '    fo.Value = CB_ConditionValue2.ComboBox.Text
        '    fo.Field_Operator = Enum_Operator.Operator_Like
        '    oList.FoList.Add(fo)
        'End If
        If SelectRetrun Then
            fo = New FindOption
            fo.DB_Field = "p.id"
            fo.Value = Me.ReturnId
            fo.Field_Operator = Enum_Operator.Operator_Equal
            oList.FoList.Add(fo)
        End If




        'If goodsCount = 1 Then
        '    sqlbuider.Append(", List.BZ_ID ")
        '    sqlbuider.Append(SQL_PBTC_Get_Body)
        '    sqlbuider.Append(SQL_PBTC_Get_leftJoin_GoodsNo)
        'ElseIf goodsCount = 2 Then
        '    sqlbuider.Append(", List.BZ_ID,List.BZ_Name ")
        '    sqlbuider.Append(SQL_PBTC_Get_Body)
        '    sqlbuider.Append(SQL_PBTC_Get_leftJoin_GoodsName)
        'Else

        '    sqlbuider.Append(SQL_PBTC_Get_Body)

        'End If
        ''   sqlbuider.Append(SQL_PBTC_OrderBy)
        'oList.Sql = sqlbuider.ToString
        Return oList
    End Function

    Private Sub Btn_Search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Search.Click
        Me.Me_Refresh()
    End Sub


#End Region
#Region "报表事件"

    Private Sub Btn_Preview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Preview.Click
        Print(OperatorType.Preview)
    End Sub

    Private Sub Btn_Print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Print.Click
        Print(OperatorType.Print)
    End Sub

    Protected Sub Print(ByVal DoOperator As OperatorType)
        If FG1.RowSel < 0 Then
            ShowErrMsg("请选择一张出货单!")
            Exit Sub
        End If
        ' Dim R As New R40001_PBTC
        ' R.Start(FG1.Item(FG1.RowSel, "ID"), DoOperator)
    End Sub

#End Region







End Class
