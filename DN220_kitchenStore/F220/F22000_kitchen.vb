Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports BaseClass
Public Class F22000_kitchen
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
        FG1.Cols("WL_Cost").Visible = CheckRight(ID, ClassMain.ShowPrice)
    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        ID = 22000
        Me.P_F_RS_ID = ID
        GoodsTypeTree1.SetParent(Me)
        GoodsTypeTree1.SetRootID(GoodsTypeTree.NODE_kitchen)

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
        CB_ConditionName1.ComboBox.DataSource = Dao.WL_GetConditionNames()
        CB_ConditionName2.ComboBox.DisplayMember = ".Field"
        CB_ConditionName2.ComboBox.ValueMember = ".DB_Field"
        CB_ConditionValue2.ComboBox.DisplayMember = "ConditionValue"
        CB_ConditionValue2.ComboBox.ValueMember = "ConditionValue"
        CB_ConditionName2.ComboBox.DataSource = Dao.WL_GetConditionNames()

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
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub Search(Optional ByVal isGetByType As Boolean = False)
        Dim msg As DtReturnMsg = Dao.WL_GetByOption(GetFindOtions(isGetByType Or CK_IsSelByType.Checked))
        If msg.IsOk Then
            Try
                dtGoods = msg.Dt
                FG1.DtToFG(msg.Dt)
                FG1.SortByLastOrder()
                FG1.RowSetForce("WL_No", ReturnId)
            Catch ex As Exception
                DebugToLog(ex)
            End Try
        End If
    End Sub

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
        Dim F As New F22001_kitchen_Msg(GoodsTypeTree1.TV_GoodsType.SelectedNode.Name, GoodsTypeTree1.TV_GoodsType.SelectedNode.Text, GoodsTypeTree1.TV_GoodsType.SelectedNode.Tag, "0")
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
            ShowErrMsg("请选择一个要修改的物料")
            Exit Sub
        End If
        Dim F As New F22001_kitchen_Msg(FG1.SelectItem("ID"))
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

        Dim msg As MsgReturn = Dao.WL_Del(FG1.SelectItem("ID"))
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
        ShowConfirm("是否删除物料 [" & FG1.SelectItem("WL_Name") & "]?", AddressOf DelGoods)
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
            fo.DB_Field = "WL_Type_ID"
            fo.Value = GoodsTypeTree1.TV_GoodsType.SelectedNode.Name
            fo.Field_Operator = Enum_Operator.Operator_Like
            oList.FoList.Add(fo)
        End If



        If CK_ShowDisable.Checked = False Then
            fo = New FindOption
            fo.DB_Field = "WL_Disable"
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
        Dim rptLoader As New R22000_Goods_List()
        rptLoader.Start(dtGoods, type)
    End Sub

    Private Sub Cmd_Preview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Preview.Click
        Print(PClass.CReport.OperatorType.Preview)
    End Sub
#End Region

End Class


Partial Class Dao

#Region "SQL"
    Public Const SQL_WL_GetGoodsType = "select top 1 WL_Type_ID from T22001_kitchen where WL_No=@WL_No"

    Public Const SQL_WL_CheckDel As String = " select id, WL_No,WL_Name,WL_Spec from T22001_kitchen where  ID=@ID   and   (   exists (select top 1 * from T22003_Store_Detail where WL_ID=@ID )  or   exists(select  top 1 * from T10011_BZC_PFList where WL_ID=@ID)  )"


    Public Const SQL_WL_NameCheckDuplicate = "select count(*) from T22001_kitchen where WL_No=@WL_No and id<>@id"

    Public Const SQL_WL_Get As String = "select G.*,T.GoodsType_Name from T22001_kitchen G left join T22000_GoodsType T on G.WL_Type_ID=T.GoodsType_ID   "

    Public Const SQL_WL_GetByID As String = "select * from T22001_kitchen where ID=@ID"
    Public Const SQL_WL_GetByNo As String = "select * from T22001_kitchen where WL_No=@WL_No"

    Public Const SQL_WL_SelByID As String = "select top 1 G.*,T.GoodsType_Name from T22001_kitchen G left join T22000_GoodsType T on G.WL_Type_ID=T.GoodsType_ID   where G.ID=@ID"
    Public Const SQL_WL_OrderBy As String = " order by WL_Type_ID, WL_No "

    Public Const SQL_WL_DelByid As String = "Delete from  T22001_kitchen where ID=@ID "
    Public Const SQL_WL_Enable As String = "update T22001_kitchen set WL_Disable=0 where ID=@ID "
#End Region

#Region "物料"

    Public Shared Function WL_ReNew(ByVal Old_ID As Integer, ByVal New_No As String) As DtReturnMsg
        Dim P As New Dictionary(Of String, Object)
        P.Add("Old_ID", Old_ID)
        P.Add("New_No", New_No)
        Return SqlStrToDt("P10001_ReNew_WL", P, True)
    End Function



    Public Shared Function WL_GetGoodsType(ByVal WL_No As String) As MsgReturn
        Return PClass.PClass.SqlStrToOneStr(SQL_WL_GetGoodsType, "WL_No", WL_No)
    End Function
    ''' <summary>
    ''' 获取所有物料信息
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function WL_GetAll() As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_WL_Get)
    End Function

    ''' <summary>
    ''' 获取查询条件集合
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function WL_GetConditionNames() As List(Of FindOption)
        Dim foList As New List(Of FindOption)
        Dim fo As New FindOption
        fo.Field = "请选择"
        fo.DB_Field = ""
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "物料编号"
        fo.DB_Field = "WL_No"
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "物料名称"
        fo.DB_Field = "WL_Name"
        foList.Add(fo)



        fo = New FindOption
        fo.Field = "物料规格"
        fo.DB_Field = "WL_Spec"
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "模糊搜索"
        fo.DB_Field = " "
        fo.Field_Operator = Enum_Operator.Operator_Like_Both
        fo.SQL = "(WL_No %Like% or WL_Name %Like%  or  WL_Spec %Like% or WL_FindHelper %Like%  or WL_Qty %Like%)"
        fo.Sign = "%Like%"
        foList.Add(fo)

        Return foList
    End Function

    ''' <summary>
    ''' 按条件获取物料信息
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function WL_GetByOption(ByVal oList As OptionList) As DtReturnMsg
        Dim paraMap As New Dictionary(Of String, Object)
        Dim sqlBuider As New StringBuilder
        sqlBuider.Append(SQL_WL_Get)
        sqlBuider.Append("  WHERE 1=1  ")
        sqlBuider.Append(OptionClass.OptionClass_BuidSqlConditon(oList.FoList, paraMap))
        sqlBuider.Append(SQL_WL_OrderBy)
        Return PClass.PClass.SqlStrToDt(sqlBuider.ToString, paraMap)
    End Function

    ''' <summary>
    ''' 获取物料信息
    ''' </summary>
    ''' <param name="sId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function WL_GetById(ByVal sId As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_WL_SelByID, "@ID", sId)
    End Function


    ''' <summary>
    ''' 增加一个物料
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function WL_Add(ByVal dt As DataTable) As MsgReturn
        Dim Cnn As New SqlClient.SqlConnection
        Dim Da As New SqlClient.SqlDataAdapter
        Dim WL_No As String = ""

        Dim returnMsg As New MsgReturn
        If dt.Rows.Count <> 1 Then
            returnMsg.IsOk = False
            returnMsg.Msg = "新增物料失败!"
            Return returnMsg
        End If
        WL_No = dt.Rows(0)("WL_No")
        Try
            Dim msg As DtReturnMsg = SqlStrToDt(SQL_WL_GetByNo, Cnn, Da, "@WL_No", WL_No)
            If msg.IsOk AndAlso msg.Dt.Rows.Count = 0 Then
                DvToDt(dt, msg.Dt, New List(Of String), True)
                DtToUpDate(msg.Dt, Cnn, Da)
                returnMsg.IsOk = True
                returnMsg.Msg = "物料[" & dt.Rows(0)("WL_Name") & "]添加成功!"
            Else
                returnMsg.IsOk = False
                returnMsg.Msg = "物料编号[" & dt.Rows(0)("WL_No") & "]已经存在!"
            End If
        Catch ex As Exception
            DebugToLog(ex)
            returnMsg.IsOk = False
            returnMsg.Msg = "新增物料失败!"
        Finally
            Da.Dispose()
            Cnn.Dispose()
        End Try
        Return returnMsg
    End Function



    ''' <summary>
    '''修改一个物料
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function WL_Save(ByVal dt As DataTable) As MsgReturn
        Dim Cnn As New SqlClient.SqlConnection
        Dim Da As New SqlClient.SqlDataAdapter
        Dim gId As String = ""
        Dim returnMsg As New MsgReturn
        If dt.Rows.Count <> 1 Then
            returnMsg.IsOk = False
            returnMsg.Msg = "修改物料失败!"
            Return returnMsg
        End If
        gId = dt.Rows(0)("ID")
        If WL_NameCheckDuplicate(dt.Rows(0)("WL_No"), gId) Then
            returnMsg.Msg = "物料编号[" & dt.Rows(0)("WL_No") & "]已存在!"
            Return returnMsg
        End If
        Try
            Dim msg As DtReturnMsg = SqlStrToDt(SQL_WL_GetByID, Cnn, Da, "@ID", gId)
            If msg.IsOk AndAlso msg.Dt.Rows.Count = 1 Then
                Dim P As New List(Of String)
                P.Add("WL_Qty")
                If IsNull(msg.Dt.Rows(0).Item("WL_Qty"), 0) <> 0 Then
                    P.Add("WL_Cost")
                End If
                DvUpdateToDt(dt, msg.Dt, P)
                DtToUpDate(msg.Dt, Cnn, Da)
                returnMsg.IsOk = True
                returnMsg.Msg = "物料[" & dt.Rows(0)("WL_Name") & "]保存成功!"
            Else
                returnMsg.IsOk = False
                returnMsg.Msg = "物料[" & dt.Rows(0)("WL_Name") & "]不存在!"
            End If
        Catch ex As Exception
            DebugToLog(ex)
            returnMsg.IsOk = False
            returnMsg.Msg = "修改物料失败!"
        Finally
            Da.Dispose()
            Cnn.Dispose()
        End Try
        Return returnMsg
    End Function

    ''' <summary>
    ''' 检查物料编号的是否重复
    ''' </summary>
    ''' <param name="WL_No"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function WL_NameCheckDuplicate(ByVal WL_No As String, ByVal ID As Integer) As Boolean
        Dim P As New Dictionary(Of String, Object)
        P.Add("WL_No", WL_No)
        P.Add("ID", ID)
        Dim r As MsgReturn = SqlStrToOneStr(SQL_WL_NameCheckDuplicate, P)
        If r.IsOk Then
            If Val(r.Msg) > 0 Then
                Return True
            Else
                Return False
            End If
        Else
            Return True
        End If
    End Function



    ''' <summary>
    ''' 生成新的物料ID 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function WL_GetNewID(ByVal startNo As String) As String
        Dim paraMap As New Dictionary(Of String, Object)
        paraMap.Add("@DB_Str", "T22001_kitchen")
        paraMap.Add("@Id_Str", startNo)
        paraMap.Add("@Field", "WL_No")
        paraMap.Add("@Zero", "3")
        Dim msgID As MsgReturn = SqlStrToOneStr("GetTableID_NoDate", paraMap, True)
        If msgID.IsOk Then
            Return msgID.Msg
        Else
            Return ""
        End If
    End Function

    ''' <summary>
    ''' 物料启用
    ''' </summary>
    ''' <param name="ID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function WL_Endable(ByVal ID As String) As MsgReturn
        Dim R As New MsgReturn
        R = RunSQL(SQL_WL_Enable, "@ID", ID)
        If Val(R.Msg) > 0 Then
            R.IsOk = True
            R.Msg = "启用成功！"
        Else
            R.IsOk = False
            R.Msg = "启用失败！"
        End If
        Return R
    End Function

    ''' <summary>
    ''' 物料删除
    ''' </summary>
    ''' <param name="ID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function WL_Del(ByVal ID As String) As MsgReturn
        Dim R As New MsgReturn
        Dim msg As DtReturnMsg = PClass.PClass.SqlStrToDt(SQL_WL_CheckDel, "@ID", ID)
        If msg.IsOk AndAlso msg.Dt.Rows.Count = 0 Then
            Return RunSQL(SQL_WL_DelByid, "@ID", ID)
        Else
            R.IsOk = False
            R.Msg = "[" & msg.Dt.Rows(0)("WL_Name") & "]" & "[" & msg.Dt.Rows(0)("WL_Spec") & "]" & "已经被引用,不能删除！"
            Return R
        End If
    End Function
#End Region
End Class