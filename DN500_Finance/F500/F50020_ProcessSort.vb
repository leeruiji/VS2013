Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports BaseClass
Public Class F50020_ProcessSort
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
        'Dao.Balance_DB_NAME = Ch_Name
        Me.Title = Ch_Name & "列表"
        Me_Refresh()
    End Sub

    Protected Sub Me_Refresh()

        CB_ConditionName1.ComboBox.DisplayMember = "Field"
        CB_ConditionName1.ComboBox.ValueMember = "DB_Field"

        CB_ConditionName1.ComboBox.DataSource = GetConditionNames()


        TB_ConditionValue1.Text = ""
        TB_ConditionValue1.Focus()
        Search()
    End Sub

    Protected Sub Search()

        Dim msg As DtReturnMsg = GetByOption(GetFindOtions)
        If msg.IsOk Then
            Try
                FG1.DtToFG(msg.Dt)
                FG1.SortByLastOrder()
                FG1.RowSetForce("ProcessSort", ReturnId)
            Catch ex As Exception
                DebugToLog(ex)
            End Try

        End If
    End Sub

    Private Sub Edit_Retrun()
        If ReturnId <> "" Then
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
        Dim F As New F50021_ProcessSort_Msg()
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
        ModifyProcessSort()
    End Sub

    ''' <summary>
    ''' 双击行.进入修改页面
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FG1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FG1.DoubleClick
        If Me.IsSel Then
            ReturnProcessSort()
        Else
            ModifyProcessSort()
        End If
    End Sub

    Protected Sub ReturnProcessSort()
        Me.LastForm.ReturnId = FG1.SelectItem("ProcessSort")
        Me.LastForm.ReturnObj = FG1.SelectItem
        Me.Close()
    End Sub

    Sub ModifyProcessSort()
        If FG1.RowSel < 0 Then
            ShowErrMsg("请选择一个要修改的加工类型")
            Exit Sub
        End If
        Dim F As New F50021_ProcessSort_Msg(FG1.SelectItem("line"))
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


    Private Sub Cmd_Del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Del.Click
        If FG1.RowSel < 0 Then
            ShowErrMsg("请选择一个要修改的加工类型")
            Exit Sub
        End If
        ShowConfirm("是否删除加工类型 [" & FG1.SelectItem("ProcessSort") & "]?", AddressOf DelProcessSort)
    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub DelProcessSort()
        Dim msg As MsgReturn = Dao.ProcessSort_Del(FG1.SelectItem("line"))
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

    
    Protected Function GetFindOtions() As OptionList
        Dim oList As New OptionList
        Dim fo As New FindOption
        If Not CB_ConditionName1.ComboBox.SelectedValue Is Nothing AndAlso Not CB_ConditionName1.ComboBox.SelectedValue = "" Then
            fo = New FindOption
            fo.DB_Field = CB_ConditionName1.ComboBox.SelectedValue
            fo.Value = TB_ConditionValue1.Text
            fo.Field_Operator = Enum_Operator.Operator_Like
            oList.FoList.Add(fo)
        End If
        Return oList
    End Function
    Public Function GetConditionNames() As List(Of FindOption)
        Dim foList As New List(Of FindOption)
        Dim fo As New FindOption
        fo.Field = "请选择"
        fo.DB_Field = ""
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "加工类型"
        fo.DB_Field = "ProcessSort"
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "备注"
        fo.DB_Field = "Remark"
        foList.Add(fo)


        Return foList
    End Function

    ''' <summary>
    ''' 按条件获取备注信息
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetByOption(ByVal oList As OptionList) As DtReturnMsg
        Dim paraMap As New Dictionary(Of String, Object)
        Dim sqlBuider As New StringBuilder
        sqlBuider.Append(Dao.SQL_ProcessSort_Get)
        sqlBuider.Append("  WHERE 1=1  ")
        sqlBuider.Append(BaseClass.OptionClass.OptionClass_BuidSqlConditon(oList.FoList, paraMap))
        sqlBuider.Append(Dao.SQL_ProcessSort_OrderBy)
        Return PClass.PClass.SqlStrToDt(sqlBuider.ToString, paraMap)
    End Function

    Private Sub Btn_Search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Search.Click
        Search()
    End Sub
End Class

Partial Friend Class Dao
#Region "成品分类"
    '===================成品分类信息==============
    Private Const SQL_ProcessSortCheckDuplicate = "select count(*) from T50020_ProcessSort where ProcessSort=@ProcessSort "
    Private Const SQL_ProcessSortChecksave = "select count(*) from T50020_ProcessSort where ProcessSort=@ProcessSort and  line<>@line"
    Private Const SQL_ProcessSort_GetAll As String = "select * from  T50020_ProcessSort order by ProcessSort"
    Private Const SQL_ProcessSort_Getline As String = "select top 1 * from T50020_ProcessSort where line=@line"
    Private Const SQL_ProcessSort_GetProcessSort As String = "select top 1 * from T50020_ProcessSort where ProcessSort=@ProcessSort "
    Public Const SQL_ProcessSort_Get = "select * from  T50020_ProcessSort"
    Public Const SQL_ProcessSort_OrderBy = "order by ProcessSort"
    Private Const SQL_ProcessSort_DelByNo As String = "Delete from  T50020_ProcessSort where line=@line"
#End Region


#Region "成品分类"


    ''' <summary>
    ''' 获取对应成品分类信息
    ''' </summary>
    ''' <param name="line"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ProcessSort_GetByProcessSort(ByVal line As Integer) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_ProcessSort_Getline, "@line", line)
    End Function

    ''' <summary>
    ''' 获取所有成品分类
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ProcessSort_GetAll() As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_ProcessSort_GetAll)
    End Function





    ''' <summary>
    ''' 增加一个成品分类
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ProcessSort_Add(ByVal dt As DataTable) As MsgReturn
        Dim Cnn As New SqlClient.SqlConnection
        Dim Da As New SqlClient.SqlDataAdapter
        Dim ProcessSort As String = ""
        Dim returnMsg As New MsgReturn
        If dt.Rows.Count <> 1 Then
            returnMsg.IsOk = False
            returnMsg.Msg = "新增加工类型失败!"
            Return returnMsg
        End If

        ProcessSort = dt.Rows(0)("ProcessSort")
        If ProcessSortCheckDuplicate(ProcessSort) Then
            returnMsg.Msg = "加工类型[" & dt.Rows(0)("ProcessSort") & "]已存在!"
            Return returnMsg
        End If
        Try
            Dim msg As DtReturnMsg = SqlStrToDt(SQL_ProcessSort_GetProcessSort, Cnn, Da, "@ProcessSort", ProcessSort)
            If msg.IsOk AndAlso msg.Dt.Rows.Count = 0 Then
                DvToDt(dt, msg.Dt, New List(Of String), True)
                DtToUpDate(msg.Dt, Cnn, Da)

                returnMsg.IsOk = True
                returnMsg.Msg = "加工类型[" & dt.Rows(0)("ProcessSort") & "]添加成功!"
            Else
                returnMsg.IsOk = False
                returnMsg.Msg = "加工类型[" & dt.Rows(0)("ProcessSort") & "已经存在!"
            End If
        Catch ex As Exception
            DebugToLog(ex)
            returnMsg.IsOk = False
            returnMsg.Msg = "新增加工类型失败!"
        Finally
            Da.Dispose()
            Cnn.Dispose()
        End Try
        Return returnMsg
    End Function



    ''' <summary>
    '''修改一个成品分类
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ProcessSort_Save(ByVal dt As DataTable, ByVal line As Integer) As MsgReturn
        Dim Cnn As New SqlClient.SqlConnection
        Dim Da As New SqlClient.SqlDataAdapter

        Dim returnMsg As New MsgReturn
        If dt.Rows.Count <> 1 Then
            returnMsg.IsOk = False
            returnMsg.Msg = "修改加工类型失败!"
            Return returnMsg
        End If

        If ProcessSortChecksave(dt.Rows(0)("ProcessSort"), line) Then
            returnMsg.Msg = "加工类型[" & dt.Rows(0)("ProcessSort") & "]已存在!"
            Return returnMsg
        End If

        Try
            Dim msg As DtReturnMsg = SqlStrToDt(SQL_ProcessSort_Getline, Cnn, Da, "@line", line)
            If msg.IsOk AndAlso msg.Dt.Rows.Count = 1 Then
                DvUpdateToDt(dt, msg.Dt, New List(Of String))
                DtToUpDate(msg.Dt, Cnn, Da)
                returnMsg.IsOk = True
                returnMsg.Msg = "加工类型[" & dt.Rows(0)("ProcessSort") & "]保存成功!"
            Else
                returnMsg.IsOk = False
                returnMsg.Msg = "加工类型[" & dt.Rows(0)("ProcessSort") & "]不存在!"
            End If
        Catch ex As Exception
            DebugToLog(ex)
            returnMsg.IsOk = False
            returnMsg.Msg = "修改加工类型失败!"
        Finally
            Da.Dispose()
            Cnn.Dispose()
        End Try
        Return returnMsg
    End Function

    ''' <summary>
    ''' 检查加工类型是否重复
    ''' </summary>
    ''' <param name="ProcessSort"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ProcessSortCheckDuplicate(ByVal ProcessSort As String) As Boolean
        Dim P As New Dictionary(Of String, Object)
        P.Add("ProcessSort", ProcessSort)
        Dim r As MsgReturn = SqlStrToOneStr(SQL_ProcessSortCheckDuplicate, P)
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
    Public Shared Function ProcessSortChecksave(ByVal ProcessSort As String, ByVal line As Integer) As Boolean
        Dim P As New Dictionary(Of String, Object)
        P.Add("ProcessSort", ProcessSort)
        P.Add("line", line)
        Dim r As MsgReturn = SqlStrToOneStr(SQL_ProcessSortChecksave, P)
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
    ''' 删除成品分类
    ''' </summary>
    ''' <param name="line "></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ProcessSort_Del(ByVal line As Integer) As MsgReturn
        Return RunSQL(SQL_ProcessSort_DelByNo, "@line ", line)
    End Function

#End Region



    







End Class