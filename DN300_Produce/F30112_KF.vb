Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports BaseClass
Imports PClass.CReport
Imports BaseClass.ComFun

Public Class F30112_KF
    Dim isLoaded As Boolean = False
    Dim SumAmountLB As Decimal = 0
    Dim Msgcopy As DataTable
    ''' <summary>
    ''' 权限获取
    ''' </summary>
    ''' <remarks></remarks>
    Sub FormCheckRight()
        ID = 30112
        Control_CheckRight(ID, ClassMain.Add, Cmd_Add)
        Control_CheckRight(ID, ClassMain.Modify, Cmd_Modify)
        Control_CheckRight(ID, ClassMain.Del, Cmd_Del)
        If CheckRight(ID, ClassMain.CanExcelOut) Then
            FG1.SetCanExcelOut()
        Else
            FG1.SetCanNotExcelOut()
        End If
    End Sub

    Private Sub F30112_KF_AfterLoad() Handles Me.AfterLoad
        FG1.FG_ColResize()
        SumFG1.AddSum()
    End Sub

    Private Sub Form_Me_Load() Handles Me.Me_Load
        FormCheckRight()
        '默认时间不可选
        'CB_SearchByDate.Checked = False
        FG1.IniFormat()
        FG1.IniColsSize()

        Ch_Name = "开幅工艺"
        Me.Title = Ch_Name & "列表"

        DP_Start.Value = GetDate().Date.AddDays(-7)
        DP_End.Value = GetDate()
        CB_ConditionName1.ComboBox.DisplayMember = "Field"
        CB_ConditionName1.ComboBox.ValueMember = "DB_Field"
        CB_ConditionName1.ComboBox.DataSource = Dao.BZ_GetConditionName()


        CB_State.ComboBox.DisplayMember = "Field"
        CB_State.ComboBox.ValueMember = "DB_Field"
        CB_State.ComboBox.DataSource = Dao.KF_GetCondition()
        CB_State.ComboBox.SelectedIndex = 1
        Me_Refresh()
        isLoaded = True

    End Sub

    Private Sub Me_KeyDown(ByVal sender As Object, ByRef e As System.Windows.Forms.KeyEventArgs) Handles Me.Form_KeyDown
        If e.KeyCode = Keys.Enter Then
            Try
                SendKeys.SendWait("{TAB}")
            Catch ex As Exception
            End Try
        End If
    End Sub

    Protected Sub Me_Refresh()
        Dim msg As DtReturnMsg = Dao.BZKF_GetByOption(GetFindOtions)
        If msg.IsOk Then
            msg.Dt.Columns.Add("OClass", GetType(String))
            msg.Dt.Columns.Add("BZ", GetType(String))
            msg.Dt.Columns.Add("BZC", GetType(String))
            msg.Dt.Columns.Add("IsChecked", GetType(Boolean))

            For Each Dr As DataRow In msg.Dt.Rows
                If IsNull(Dr("OrClass"), True) = True Then
                    Dr("OClass") = "甲班"
                Else
                    Dr("OClass") = "乙班"
                End If
                If IsNull(Dr("ClientBzc"), "") <> "" Then
                    Dr("ClientBzc") = Dr("ClientBzc") & "#"
                Else
                    Dr("ClientBzc") = ""
                End If
                If IsNull(Dr("BZ_No"), "").ToString.Contains("#") = False Then
                    Dr("BZ_No") = ""
                End If
                'If IsNull(Dr("IsFD"), False) = True AndAlso IsNull(Dr("BzcMsg"), "") = "" Then
                '    Dr("BzcMsg") = "返定"
                'Else

                '    If IsNull(Dr("BzcMsg"), "") = "" Then
                '        Dr("BzcMsg") = Dr("ClientBzc") & Dr("BZC_Name") & "GY-" & Format(IsNull(Dr("BZc_No"), ""), "000000") ' & Dr("BZC_PF")
                '    Else
                '        Dr("BzcMsg") = Dr("BzcMsg").ToString.Replace(vbCrLf, "")
                '    End If
                'End If
                Dr("BZC") = Dr("BzcMsg")
                Dr("BZ") = Dr("BZ_No") & Dr("BZ_Name")
                Dr("IsChecked") = False
                Dr("isInvoid") = IsNull(Dr("isInvoid"), False)
            Next

            FG1.DtToFG(msg.Dt)
            SumFG1.ReSum()
            FG1.RowSetForce("GH", ReturnId)

        End If
        Msgcopy = msg.Dt
    End Sub

    Private Sub Form_Me_KeyPress(ByVal sender As Object, ByRef e As System.Windows.Forms.KeyPressEventArgs) Handles Me.Form_KeyPress
        Select Case e.KeyChar
            Case vbCr, Chr(27) 'esc
            Case Else
                If TSC_Client.Focused = True OrElse TSC_BZ.Focused = True Then
                    Exit Sub
                End If
                If TB_ConditionValue1.Focused = False Then
                    If e.KeyChar = Chr(System.Windows.Forms.Keys.Back) Then
                        If TB_ConditionValue1.Text.Length > 0 Then TB_ConditionValue1.Text = TB_ConditionValue1.Text.Substring(0, TB_ConditionValue1.Text.Length - 1)
                        TB_ConditionValue1.Focus()
                    Else
                        TB_ConditionValue1.Text = e.KeyChar
                        TB_ConditionValue1.Focus()
                    End If
                    If CB_ConditionName1.SelectedIndex = 0 AndAlso CB_ConditionName1.Items.Count > 1 Then
                        CB_ConditionName1.SelectedIndex = 1
                    End If
                End If
        End Select
    End Sub


#Region "控件事件"

    Private Sub Edit_Retrun()
        Me_Refresh()
    End Sub
    Private Sub Cmd_Refresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Refresh.Click
        Me_Refresh()
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Add.Click
        Dim F As New F30113_KF_Msg()
        With F
            .Mode = Mode_Enum.Add
            .P_F_RS_ID = ""
            .P_F_RS_ID2 = ""
            .ID = Me.ID
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
        ShowModify()
    End Sub



    ''' <summary>
    ''' 双击行.进入修改页面
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FG1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FG1.DoubleClick
        ShowModify()
    End Sub

    Protected Sub ShowModify()
        If FG1.RowSel < 0 Then
            ShowErrMsg("请选择一个要修改的缸号")
            Exit Sub
        End If
        Dim F As New F30113_KF_Msg(FG1.Item(FG1.RowSel, "GH"), FG1.Item(FG1.RowSel, "Line"))
        With F
            .Mode = Mode_Enum.Modify
            .P_F_RS_ID = ""
            .P_F_RS_ID2 = ""
            .ID = Me.ID
        End With
        F_RS_ID = ""
        Me.ReturnId = ""
        Me.ReturnObj = Nothing
        Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F, Me)
        AddHandler VF.ClosedX, AddressOf Edit_Retrun
        VF.Show()
    End Sub

    Private Sub Cmd_Del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Del.Click
        If FG1.RowSel < 0 Then
            ShowErrMsg("请选择一个要修改的缸号")
            Exit Sub
        End If
        ShowConfirm("是否删除缸号" & "[" & FG1.Item(FG1.RowSel, "GH") & "]?", AddressOf DelSQ)
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub DelSQ()
        Dim msg As MsgReturn = Dao.Sql_KF_DelectGH(FG1.Item(FG1.RowSel, "GH"), FG1.Item(FG1.RowSel, "line"))
        If msg.IsOk Then
            Me_Refresh()
        Else
            ShowErrMsg("删除失败！")
        End If

    End Sub

    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub
#End Region

#Region "搜索工具栏"

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
    ''' 生成搜索条件
    ''' </summary>
    ''' <remarks></remarks>
    Protected Function GetFindOtions() As OptionList
        Dim oList As New OptionList
        Dim fo As New FindOption
        Dim goodsCount As Integer = 0

        fo = New FindOption
        fo.DB_Field = "sDate"
        fo.Value = DP_Start.Value.Date
        fo.Value2 = DP_End.Value.Date
        fo.Field_Operator = Enum_Operator.Operator_Between
        oList.FoList.Add(fo)


        If CB_ConditionName1.ComboBox.SelectedItem IsNot Nothing AndAlso TB_ConditionValue1.Text <> "" Then
            fo = CB_ConditionName1.ComboBox.SelectedItem
            fo.Value = TB_ConditionValue1.Text
            If fo.Field_Operator <> Enum_Operator.Operator_In Then fo.Field_Operator = Enum_Operator.Operator_Like_Both
            oList.FoList.Add(fo)
        End If

        If Val(TSC_Client.IDValue) <> 0 Then
            fo = New FindOption
            fo.DB_Field = "GD.Client_Name"
            fo.Value = TSC_Client.GetByTextBoxTag
            fo.Field_Operator = Enum_Operator.Operator_Equal
            oList.FoList.Add(fo)
        End If

        If Val(TSC_BZ.IDValue) <> 0 Then
            fo = New FindOption
            fo.DB_Field = "GD.BZ_Name"
            fo.Value = TSC_BZ.GetByTextBoxTag
            fo.Field_Operator = Enum_Operator.Operator_Equal
            oList.FoList.Add(fo)
        End If


        If CB_State.SelectedIndex > 0 Then
            fo = New FindOption
            fo.DB_Field = "isInvoid"
            fo.Value = IIf(CB_State.ComboBox.SelectedValue = 0, False, True)
            fo.Field_Operator = Enum_Operator.Operator_Equal
            oList.FoList.Add(fo)
        End If


        Return oList
    End Function

    Private Sub Btn_Search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Search.Click
        Me.Me_Refresh()
    End Sub

    Private Sub Client_List1_Col_Sel(ByVal Col_No As String, ByVal Col_Name As String, ByVal ID As String) Handles TSC_Client.Col_Sel
        If TSC_BZ.SearchID <> ID Then
            TSC_BZ.Text = ""
            TSC_BZ.IDValue = 0
        End If
        TSC_BZ.SearchType = cSearchType.ENum_SearchType.Client
        TSC_BZ.SearchID = ID
    End Sub

    Private Sub TSC_Client_SetEmpty() Handles TSC_Client.SetEmpty
        TSC_Client.IDValue = 0
        TSC_BZ.SearchType = cSearchType.ENum_SearchType.ALL
        TSC_BZ.SearchID = 0
    End Sub


#End Region

#Region "报表事件"


    Private Sub Btn_Preview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Preview.Click
        Print(OperatorType.Preview)
    End Sub



    Protected Sub Print(ByVal DoOperator As OperatorType)
        If FG1.RowSel < 0 Then
            ShowErrMsg("请选择一项定型工艺!")
            Exit Sub
        End If
        Dim R As New R30110_DProcess
        R.Start(Msgcopy, DoOperator)
    End Sub

    Protected Sub Print_WorkName(ByVal dt As DataTable, ByVal dtWork_Name As DataTable, ByVal DoOperator As OperatorType)
        Dim R As New R30111_DProcess_Msg
        If CheckRight(ID, ClassMain.RpCanExcelOut) Then
            R.SetCanExcelOut()
        Else
            R.SetCanNotExcelOut()
        End If

        R.Start(dt, dtWork_Name, DoOperator)
    End Sub

    Protected Sub Print_JTSum(ByVal dt As DataTable, ByVal dtJTSum As DataTable, ByVal DoOperator As OperatorType)
        Dim R As New R30111_DProcess_JTSum()
        If CheckRight(ID, ClassMain.RpCanExcelOut) Then
            R.SetCanExcelOut()
        Else
            R.SetCanNotExcelOut()
        End If
        R.Start(dt, dtJTSum, DoOperator)
    End Sub

#End Region

#Region "FG1事件"
    'Private Sub FG1_SelectRowChange(ByVal Row As Integer) Handles FG1.SelectRowChange
    '    If FG1.SelectItem Is Nothing OrElse IsNull(FG1.Item(FG1.RowSel, "ID"), "") = "" Then
    '        Exit Sub
    '    End If
    '    If IsNull(FG1.SelectItem("State"), Enum_State.AddNew) = Enum_State.AddNew Then
    '        Cmd_Del.Enabled = Cmd_Del.Tag
    '    Else
    '        Cmd_Del.Enabled = False
    '    End If
    'End Sub

    Private Sub FG1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles FG1.Click
        If FG1.RowSel < 1 Then
            Exit Sub
        End If

        If FG1.ColSel = FG1.Cols("IsChecked").Index Then
            FG1.Item(FG1.RowSel, "IsChecked") = Not FG1.Item(FG1.RowSel, "IsChecked")
        End If
    End Sub



#End Region

    Private Sub Cmd_WordName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_WordName.Click
        Dim dt As New DataTable
        dt.Columns.Add("sDate", GetType(Date))
        dt.Columns.Add("eDate", GetType(Date))
        Dim dr As DataRow = dt.NewRow
        dr("sDate") = DP_Start.Value
        dr("eDate") = DP_End.Value
        dt.Rows.Add(dr)

        Dim dtwork As DtReturnMsg = Dao.Sql_KF_GetWorkName(DP_Start.Value, DP_End.Value)
        If dtwork.IsOk Then
            Print_WorkName(dt, dtwork.Dt, OperatorType.Preview)
        End If
    End Sub

    Private Sub Cmd_JTTJ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_JTTJ.Click
        Dim dt As New DataTable
        dt.Columns.Add("sDate", GetType(Date))
        dt.Columns.Add("eDate", GetType(Date))
        Dim dr As DataRow = dt.NewRow
        dr("sDate") = DP_Start.Value
        dr("eDate") = DP_End.Value
        dt.Rows.Add(dr)
        Dim DtJTS As DtReturnMsg = Dao.Sql_KF_GetJTH(DP_Start.Value, DP_End.Value)
        If DtJTS.IsOk Then
            DtJTS.Dt.Columns.Add("Ben", GetType(String))
            For Each dtr As DataRow In DtJTS.Dt.Rows
                If IsNull(dtr("Bengci"), True) = True Then
                    dtr("Ben") = "甲班"
                Else
                    dtr("Ben") = "乙班"
                End If
            Next
            Print_JTSum(dt, DtJTS.Dt, OperatorType.Preview)
        End If
    End Sub


    Dim InList As List(Of String)
    Private Sub Cmd_Invoid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Invoid.Click
        InList = New List(Of String)

        For i = 1 To FG1.Rows.Count - 1
            If IsNull(FG1.Item(i, "IsChecked"), False) = True Then
                InList.Add(FG1.Item(i, "Line"))
            End If

        Next
        If InList.Count > 0 Then
            ShowConfirm("是否要将选定开幅工艺作废? ", AddressOf Invoid)
        Else
            ShowErrMsg("您没有选择开幅工艺!")
        End If
    End Sub


    Protected Sub Invoid()
        Dim msg As MsgReturn

        Dim msgBudder As New StringBuilder

        Dim okCount As Integer = 0
        Dim failedCount As Integer = 0
        msgBudder.AppendLine("")
        For Each _ID As String In InList
            msg = Dao.KF_InValid(_ID, True)
            If msg.IsOk Then
                okCount = okCount + 1
            Else
                failedCount = failedCount + 1
                msgBudder.AppendLine(msg.Msg)
            End If
        Next
        msgBudder.Insert(0, "开幅工艺批量作废,共" & okCount & "张单作废成功," & failedCount & "张单作废失败!")
        If failedCount > 0 Then
            ShowErrMsg(msgBudder.ToString)
        Else
            ShowOk(msgBudder.ToString, False)
        End If
        Me_Refresh()
    End Sub


    Protected Sub UnInvoid()
        Dim msg As MsgReturn

        Dim msgBudder As New StringBuilder

        Dim okCount As Integer = 0
        Dim failedCount As Integer = 0
        msgBudder.AppendLine("")
        For Each _ID As String In InList
            msg = Dao.KF_InValid(_ID, False)
            If msg.IsOk Then
                okCount = okCount + 1
            Else
                failedCount = failedCount + 1
                msgBudder.AppendLine(msg.Msg)
            End If
        Next
        msgBudder.Insert(0, "开幅工艺批量反作废,共" & okCount & "张单反作废成功," & failedCount & "张单反作废失败!")
        If failedCount > 0 Then
            ShowErrMsg(msgBudder.ToString)
        Else
            ShowOk(msgBudder.ToString, False)
        End If
        Me_Refresh()
    End Sub



    Private Sub Cmd_UnInvoid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_UnInvoid.Click
        InList = New List(Of String)

        For i = 1 To FG1.Rows.Count - 1
            If IsNull(FG1.Item(i, "IsChecked"), False) = True Then
                InList.Add(FG1.Item(i, "Line"))
            End If

        Next
        If InList.Count > 0 Then
            ShowConfirm("是否要将选定开幅工艺反作废? ", AddressOf UnInvoid)
        Else
            ShowErrMsg("您没有选择开幅工艺!")
        End If
    End Sub

    Private Sub CB_State_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CB_State.SelectedIndexChanged

        If isLoaded = True Then
            Me_Refresh()
        End If
    End Sub



    
End Class

Partial Friend Class Dao
    Public Const KF_DB_NAME = "开幅工艺"
    Public Const SQL_KF_Get_WithName = "SELECT K.*, BZ_No,BzcMsg,IsFD, GD.CR_LuoSeBzCount, GD.PB_ZLSum, GD.Client_Name, GD.BZ_Name, GD.BZC_Name,GD.BZC_No,GD.ClientBzc FROM " & _
                                       " T30112_KF K   LEFT OUTER JOIN " & _
                                    "(SELECT G.GH,G.ClientBzc,BZ_No,BzcMsg,IsFD, G.CR_LuoSeBzCount, G.PB_ZLSum, C.Client_Name, BZ.BZ_Name, BZC.BZC_Name,BZC.BZC_No " & _
                                     " FROM T30000_Produce_Gd G LEFT JOIN " & _
                                     "T10110_Client C ON C.id = G.Client_id LEFT JOIN " & _
                                       "T10002_BZ BZ ON BZ.id = G.BZ_id LEFT JOIN" & _
                                      " T10003_BZC BZC ON BZC.id = G.BZC_id) GD ON K.GH = GD.GH"

    Public Const SQL_KF_DelGh = "DELETE from T30112_KF where GH=@GH and Line=@Line"
    Public Const SQL_KF_OrderBy As String = " order by sDate "
    'Public Const SQL_Work_Getf As String = "select Work_No,Work_Name from T10022_Work where Dept_No='D006' and Correction=1" '获取返定
    'Public Const SQL_Work_Get As String = "select Work_No,Work_Name from T10022_Work where Dept_No='D006' and Correction=0" '
    'Public Const SQL_Chengpin_Get As String = "select Remark from T30110_DProcess where GH=@GH and Remark=@Remark "


    Public Const SQL_Get_KFWorkName_Sum As String = "SELECT isnull(SUM(CR_LuoSeBzCount), 0) AS CR_LuoSeBzCount, isnull(SUM(PB_ZLSum), 0) AS PB_ZLSum FROM (SELECT * FROM T30112_KF WHERE sDate BETWEEN @sDate1 AND @sDate2 ) T LEFT JOINT30000_Produce_Gd G ON G.GH = T .GH"


    Public Const SQL_KF_GetJTS As String = " SELECT JTH, Bengci, Sum(DxCount) AS DxCount, Sum(DSZL) AS Dszl " & _
                                         "FROM T30110_DProcess Where sDate Between @sDate1 and @sDate2 and isInvoid=0" & _
                                         "GROUP BY JTH, Bengci Order by JTH, Bengci  "





    ''' <summary>
    ''' 获取查询条件集合
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function BZ_GetConditionName() As List(Of FindOption)
        Dim foList As New List(Of FindOption)
        Dim fo As New FindOption
        fo.Field = "请选择"
        fo.DB_Field = ""
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "缸号"
        fo.DB_Field = "D.GH"
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "客户"
        fo.DB_Field = "GD.Client_Name"
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "色号"
        fo.DB_Field = "GD.BZC_No"
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "开幅员"
        fo.DB_Field = "Operator"
        foList.Add(fo)

        'fo = New FindOption
        'fo.Field = "备注"
        'fo.DB_Field = "Work_Name"
        'foList.Add(fo)


        Return foList
    End Function

    ''' <summary>
    ''' 获取查询条件集合
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function KF_GetCondition() As List(Of FindOption)
        Dim foList As New List(Of FindOption)
        Dim fo As New FindOption
        fo.Field = "全部"
        fo.DB_Field = ""
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "新建"
        fo.DB_Field = 0
        foList.Add(fo)


        fo = New FindOption
        fo.Field = "已作废"
        fo.DB_Field = 1
        foList.Add(fo)

        Return foList
    End Function





    ''' <summary>
    ''' 按条件获取条码入库单列表
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function BZKF_GetByOption(ByVal oList As OptionList) As DtReturnMsg
        Dim paraMap As New Dictionary(Of String, Object)
        Dim sqlBuider As New StringBuilder
        sqlBuider.Append(SQL_KF_Get_WithName)
        sqlBuider.Append("  WHERE 1=1  ")
        sqlBuider.Append(BaseClass.OptionClass.OptionClass_BuidSqlConditon(oList.FoList, paraMap))
        sqlBuider.Append(SQL_KF_OrderBy)
        Return PClass.PClass.SqlStrToDt(sqlBuider.ToString, paraMap)
    End Function

    ''' <summary>
    ''' 审核
    ''' </summary>
    ''' <param name="GH"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Sql_KF_DelectGH(ByVal GH As String, ByVal line As Integer)
        Dim p As New Dictionary(Of String, Object)
        p.Add("GH", GH)
        p.Add("Line", line)
        Return RunSQL(SQL_KF_DelGh, p)
    End Function


    ''' <summary>
    ''' 获取工取的落色重量合计
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Sql_KF_GetWorkName(ByVal sDate As Date, ByVal eDate As Date) As DtReturnMsg
        Dim p As New Dictionary(Of String, Object)
        p.Add("@sDate1", sDate)
        p.Add("@sDate2", eDate)
        Return PClass.PClass.SqlStrToDt(SQL_Get_KFWorkName_Sum, p)
    End Function




    'Public Shared Function Work_KF_Get(ByVal GH As String) As DtReturnMsg

    '    If ischengpi(GH) Then
    '        Return PClass.PClass.SqlStrToDt(SQL_Work_Getf)
    '    Else
    '        Return PClass.PClass.SqlStrToDt(SQL_Work_Get)
    '    End If
    'End Function



    'Public Shared Function ischengpi(ByVal GH As String) As Boolean
    '    Dim p As New Dictionary(Of String, Object)
    '    Dim msg As DtReturnMsg
    '    p.Add("GH", GH)
    '    p.Add("Remark", "005")
    '    msg = PClass.PClass.SqlStrToDt(SQL_Chengpin_Get, p)
    '    If msg.IsOk = True AndAlso msg.Dt.Rows.Count > 0 Then
    '        Return True
    '    Else
    '        Return False
    '    End If
    'End Function



    ''' <summary>
    ''' 作废出库单
    ''' </summary>
    ''' <param name="_ID"></param>
    ''' <param name="isInvoid">作废还是反作废</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function KF_InValid(ByVal _ID As Long, ByVal isInvoid As Boolean) As MsgReturn
        Dim paraMap As New Dictionary(Of String, Object)
        paraMap.Add("Line", _ID)
        paraMap.Add("isInvoid", isInvoid)

        Dim R As MsgReturn = SqlStrToOneStr("Update T30112_KF set isInvoid=@isInvoid  where Line=@Line  ", paraMap)
        Dim s As String = IIf(isInvoid, "已作废", "还原")
        If R.IsOk Then
            R.Msg = KF_DB_NAME & s & "成功！"
        Else
            R.Msg = KF_DB_NAME & s & "失败！" & R.Msg

        End If
        Return R
    End Function




    ''' <summary>
    ''' 按机号合计条数，重量
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Sql_KF_GetJTH(ByVal sDate As Date, ByVal eDate As Date) As DtReturnMsg
        Dim p As New Dictionary(Of String, Object)
        p.Add("@sDate1", sDate)
        p.Add("@sDate2", eDate)
        Return PClass.PClass.SqlStrToDt(SQL_KF_GetJTS, p)
    End Function


End Class