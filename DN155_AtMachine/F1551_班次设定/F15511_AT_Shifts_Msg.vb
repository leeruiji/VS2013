Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports BaseClass

Public Class F15511_AT_Shifts_Msg
    Dim dtAt As DataTable
    Dim dtDept As DataTable
    Dim isloaded As Boolean = False

    Public Sub New()

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        Bill_ID = 0
        ' 在 InitializeComponent() 调用之后添加任何初始化。

    End Sub

    Public Sub New(ByVal jID As Integer)

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。
        Bill_ID = jID

        Me.Mode = Mode

    End Sub
    ''' <summary>
    ''' 权限获取
    ''' </summary>
    ''' <remarks></remarks>
    Sub FormCheckRight()
        ID = 15510
        Control_CheckRight(ID, ClassMain.Modify, Cmd_Modify)
        Control_CheckRight(ID, ClassMain.Del, Cmd_Del)
    End Sub

    Private Sub Me_Form_KeyDown(ByVal sender As Object, ByRef e As System.Windows.Forms.KeyEventArgs) Handles Me.Form_KeyDown
        If e.KeyCode = Keys.Enter Then
            Try

                SendKeys.SendWait("{TAB}")

            Catch ex As Exception
            End Try
        End If
    End Sub



    Private Sub F15511_AT_Shifts_Msg_Me_Closing(ByVal sender As Object, ByRef e As System.ComponentModel.CancelEventArgs) Handles Me.Me_Closing
        Me.LastForm.ReturnId = TB_shift_id.Text
    End Sub


    Private Sub F15501_At_Msg_Load() Handles Me.Me_Load
        FormCheckRight()
        Ch_Name = GetBillTypeName(ID)
        'Dao.Balance_DB_NAME = Ch_Name
        Fg1.Cols("Up_Time").Editor = DP_Up_Time
        Fg1.Cols("Down_Time").Editor = DP_Up_Time
        Me.Title = Ch_Name
        Me_Refresh()
        isloaded = True
    End Sub

    Protected Sub Me_Refresh()
        Dim msg As DtReturnMsg = Dao.Shifts_GetByID(Bill_ID)
        If msg.IsOk Then
            dtAt = msg.Dt
            SetForm(msg.Dt)
            CaculateWorkTime()
        End If
    End Sub

#Region "表单信息"
    ''' <summary>
    ''' 获取表单内容
    ''' </summary>
    ''' <remarks></remarks>
    Protected Function GetForm() As DataTable
        Dim dt As DataTable
        dt = dtAt.Clone
        If Not dt Is Nothing Then
            dt.Clear()
            Dim dr As DataRow = dt.NewRow
            '  dr("Line") = -99

            dr("shift_id") = TB_shift_id.Text
            dr("IsOut") = 0
            dr("shift_name") = TB_shift_name.Text

            If CB_IsRest.Checked Then
                dr("UP_Time") = "00:00"
                dr("Down_Time") = "00:00"
                dr("TwoTime") = False
            Else
                dr("UP_Time") = CDate(Fg1.Item(1, "UP_Time")).ToString("HH:mm")
                dr("Down_Time") = CDate(Fg1.Item(1, "Down_Time")).ToString("HH:mm")

                If Fg1.Rows.Count > 2 Then
                    dr("UP_Time2") = CDate(Fg1.Item(2, "UP_Time")).ToString("HH:mm")
                    dr("Down_Time2") = CDate(Fg1.Item(2, "Down_Time")).ToString("HH:mm")
                    dr("TwoTime") = True
                Else
                    dr("UP_Time2") = ""
                    dr("Down_Time2") = ""
                    dr("TwoTime") = False
                End If
                Dim SL As New List(Of String)
                For i As Integer = 3 To Fg1.Rows.Count - 1
                    SL.Add(CDate(Fg1.Item(i, "UP_Time")).ToString("HH:mm") & "-" & CDate(Fg1.Item(i, "Down_Time")).ToString("HH:mm"))
                Next
                If SL.Count > 0 Then
                    dr("ShiftStr") = ComFun.ListToString(SL, "|")
                Else
                    dr("ShiftStr") = ""
                End If

            End If





            dr("CD_Max") = Val(TB_CD_Max.Text)
            dr("ZT_Max") = Val(TB_ZT_Max.Text)
            dr("CD_Min") = Val(TB_CD_Min.Text)
            dr("ZT_Min") = Val(TB_ZT_Min.Text)

            dr("ZD_Max") = Val(TB_ZD_Max.Text)
            dr("CZ_Max") = Val(TB_CZ_Max.Text)

            dr("No_CheckTime") = CKB_No_CheckTime.Checked
            dr("IsRest") = CB_IsRest.Checked

            dr("Remark") = TB_Remark.Text
            dr("work_hrs") = Val(TB_work_hrs.Text)
            dr("need_hrs") = Val(TB_need_hrs.Text)

            dr("is_default") = 0
            dt.Rows.Add(dr)



        End If
        Return dt
    End Function





    Sub DroFG(ByVal Dr As DataRow)
        Dim Dt As New DataTable("T")
        Dt.Columns.Add("UP_Time", GetType(DateTime))
        Dt.Columns.Add("Down_Time", GetType(DateTime))

        Dim Row As DataRow
        Try
            Row = Dt.NewRow
            Row("UP_Time") = CDate(Today.ToString("yyyy-MM-dd") & " " & Dr("UP_Time"))
            Row("Down_Time") = CDate(Today.ToString("yyyy-MM-dd") & " " & Dr("Down_Time"))
            Dt.Rows.Add(Row)
        Catch ex As Exception
        End Try
        Try
            If Dr("TwoTime") = True Then
                Row = Dt.NewRow
                Row("UP_Time") = CDate(Today.ToString("yyyy-MM-dd") & " " & Dr("UP_Time2"))
                Row("Down_Time") = CDate(Today.ToString("yyyy-MM-dd") & " " & Dr("Down_Time2"))
                Dt.Rows.Add(Row)
            End If
        Catch ex As Exception
        End Try
        Dim Str As String = IsNull(Dr("ShiftStr"), "")
        If Str <> "" Then
            Dim SP() As String = Str.Split("|")
            For Each S As String In SP
                If S <> "" Then
                    Dim sp2() As String = S.Split("-")
                    If sp2.Length = 2 Then
                        Try
                            Row = Dt.NewRow
                            Row("UP_Time") = CDate(Today.ToString("yyyy-MM-dd") & " " & sp2(0))
                            Row("Down_Time") = CDate(Today.ToString("yyyy-MM-dd") & " " & sp2(1))
                            Dt.Rows.Add(Row)
                        Catch ex As Exception
                        End Try
                    End If
                End If
            Next
        End If
        Dt.AcceptChanges()
        Fg1.DtToSetFG(Dt)
    End Sub



    ''' <summary>
    ''' 设置表单内容
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub SetForm(ByVal dt As DataTable)
        If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
            Dim dr As DataRow = dt.Rows(0)
            TB_shift_id.Text = dr("shift_id")
            TB_shift_name.Text = dr("shift_name")

            DroFG(dr)

            TB_CD_Max.Text = IsNull(dr("CD_Max"), 0)
            TB_ZT_Max.Text = IsNull(dr("ZT_Max"), 0)
            TB_CD_Min.Text = IsNull(dr("CD_Min"), 0)
            TB_ZT_Min.Text = IsNull(dr("ZT_Min"), 0)

            TB_ZD_Max.Text = IsNull(dr("ZD_Max"), 0)
            TB_CZ_Max.Text = IsNull(dr("CZ_Max"), 0)
            CB_IsRest.Checked = IsNull(dr("IsRest"), False)
            CKB_No_CheckTime.Checked = IsNull(dr("No_CheckTime"), False)

            '  CKB_TwoTime.Checked = IsNull(dr("TwoTime"), False)

            TB_Remark.Text = IsNull(dr("Remark"), "")

            TB_work_hrs.Text = IsNull(dr("work_hrs"), 0)

            TB_need_hrs.Text = IsNull(dr("need_hrs"), 0)
        End If

    End Sub


    Private Sub CaculateWorkTime()
        Dim m As Integer

        For i As Integer = 1 To Fg1.Rows.Count - 1
            If Fg1.Item(i, "UP_Time") IsNot Nothing AndAlso Fg1.Item(i, "Down_Time") IsNot Nothing Then
                Dim D1 As Date = CDate("2010-1-1 " & CDate(Fg1.Item(i, "UP_Time")).ToString("HH:mm"))
                Dim D2 As Date = CDate("2010-1-1 " & CDate(Fg1.Item(i, "Down_Time")).ToString("HH:mm"))
                If D1 > D2 AndAlso DateDiff(DateInterval.Hour, D1, D2.AddDays(1)) > 12 Then
                    Dim D As Date = D1
                    D1 = D2
                    D2 = D
                    Fg1.Item(i, "UP_Time") = CDate(Today.ToString("yyyy-MM-dd") & " " & D1.ToString("HH:mm"))
                    Fg1.Item(i, "Down_Time") = CDate(Today.ToString("yyyy-MM-dd") & " " & D2.ToString("HH:mm"))
                End If
                If D1 > D2 Then
                    m += DateDiff(DateInterval.Minute, D1, D2.AddDays(1))
                Else
                    m += DateDiff(DateInterval.Minute, D1, D2)
                End If
            End If
        Next
        TB_CaTime.Text = (m \ 60) & IIf((m Mod 60) >= 30, ".5", "")
    End Sub
#End Region


#Region "工具栏按钮"


    Private Sub Cmd_Modify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Modify.Click

        If CheckForm() Then ShowConfirm("是否保存班次 [" & TB_shift_name.Text & "] 的修改?", AddressOf Save)
    End Sub

    Protected Sub Save()

        Dim R As MsgReturn

        If Me.Mode = Mode_Enum.Add Then
            R = Dao.Shift_Add(GetForm())
        Else
            R = Dao.Shifts_Save(Me.Bill_ID, GetForm())
        End If
        If R.IsOk Then
            LastForm.ReturnId = TB_shift_id.Text
            Me.Close()
        Else
            ShowErrMsg(R.Msg)
        End If
    End Sub
    Protected Function CheckForm() As Boolean
        For i As Integer = Fg1.Rows.Count - 1 To 1 Step -1
            Try
                If Fg1.Item(i, "UP_Time") Is Nothing OrElse Fg1.Item(i, "Down_Time") Is Nothing Then
                    Fg1.RemoveItem(i)
                End If
            Catch ex As Exception
            End Try
        Next
        If CB_IsRest.Checked = False AndAlso Fg1.Rows.Count < 2 Then
            ShowErrMsg("至少要有一个完整的上班下班时间", AddressOf TB_shift_id.Focus)
            Return False
        End If
        If TB_shift_id.Text = "" Then
            ShowErrMsg("班次编号不能为空", AddressOf TB_shift_id.Focus)
            Return False
        End If

        If TB_shift_name.Text = "" Then
            ShowErrMsg("班次名称不能为空", AddressOf TB_shift_name.Focus)
            Return False
        End If
        'If MTB_UP_Time.Text = "" Then
        '    ShowErrMsg("上班不能为空", AddressOf MTB_UP_Time.Focus)
        '    Return False
        'End If

        'If MTB_Down_Time.Text = "" Then
        '    ShowErrMsg("下班不能为空", AddressOf MTB_Down_Time.Focus)
        '    Return False
        'End If

        If CB_IsRest.Checked = False AndAlso Val(TB_CD_Min.Text) < 0 Then
            ShowErrMsg("迟到时间不能小于0", AddressOf TB_CD_Min.Focus)
            Return False
        End If

        If CB_IsRest.Checked = False AndAlso Val(TB_ZT_Min.Text) < 0 Then
            ShowErrMsg("退时间不能小于0", AddressOf TB_ZT_Min.Focus)
            Return False
        End If

        If CB_IsRest.Checked = False AndAlso Val(TB_CD_Max.Text) <= 0 Then
            ShowErrMsg("迟到时间不能小于或等于0", AddressOf TB_CD_Max.Focus)
            Return False
        End If

        If CB_IsRest.Checked = False AndAlso Val(TB_ZT_Max.Text) <= 0 Then
            ShowErrMsg("退时间不能小于或等于0", AddressOf TB_ZT_Max.Focus)
            Return False
        End If


        Return True
    End Function




    Private Sub Cmd_Del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Del.Click
        ShowConfirm("是否删除班次 [" & TB_shift_name.Text & "]?", AddressOf DelShifts)
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub DelShifts()
        Dim msg As MsgReturn = Dao.Shifts_SetOut(TB_shift_id.Text)
        If msg.IsOk Then
            Me.Close()
        Else
            ShowErrMsg(msg.Msg)
        End If

    End Sub

    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub
#End Region








    Private Sub CB_IsRest_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CB_IsRest.CheckedChanged
        If CB_IsRest.Checked Then
            DP_Up_Time.Enabled = False
            'DP_Down_Time.Enabled = False

            TB_CD_Min.ReadOnly = True
            TB_CD_Max.ReadOnly = True
            TB_ZT_Min.ReadOnly = True
            TB_ZT_Max.ReadOnly = True
            TB_ZD_Max.ReadOnly = True
            TB_CZ_Max.ReadOnly = True
            'CKB_No_CheckTime.Checked = True
            'CKB_No_CheckTime.Enabled = False

            DP_Up_Time.Value = Today
            Fg1.CanEditing = False
            '  DP_Down_Time.Value = Today
        Else
            DP_Up_Time.Enabled = True
            '  DP_Down_Time.Enabled = True

            TB_CD_Min.ReadOnly = False
            TB_CD_Max.ReadOnly = False
            TB_ZT_Min.ReadOnly = False
            TB_ZT_Max.ReadOnly = False
            TB_ZD_Max.ReadOnly = False
            TB_CZ_Max.ReadOnly = False
            Fg1.CanEditing = True
            'CKB_No_CheckTime.Checked = True
            'CKB_No_CheckTime.Enabled = True


        End If
    End Sub



#Region "FG"
    ''' <summary>
    '''增行
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_AddRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_AddRow.Click
        AddRow()
    End Sub

    ''' <summary>
    ''' 增行
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub AddRow()
        Fg1.AddRow()
    End Sub

    ''' <summary>
    ''' 减行
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_RemoveRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_RemoveRow.Click
        Fg1.RemoveRow()
    End Sub

#End Region


    Private Sub Cmd_Caculate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Caculate.Click
        CaculateWorkTime()
    End Sub

    Private Sub Fg1_AfterEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles Fg1.AfterEdit
        If isloaded Then
            CaculateWorkTime()
        End If
    End Sub
End Class


Partial Class Dao
#Region "常量，SQL"

    ''' <summary>
    ''' 按编号查询班次信息
    ''' </summary>
    ''' <remarks></remarks>
    Public Const SQL_Shifts_GetAll = " select * from T15510_AT_Shifts where IsOut=0 order by  Line"
    ''' <summary>
    ''' 按编号查询班次信息
    ''' </summary>
    ''' <remarks></remarks>
    Public Const SQL_Shifts_GetByLine = " select * from T15510_AT_Shifts where Line=@Line "

    ''' <summary>
    ''' 按编号查询班次信息
    ''' </summary>
    ''' <remarks></remarks>
    Public Const SQL_Shifts_GetByShiftID = " select * from T15510_AT_Shifts where Shift_ID=@Shift_ID "
    ''' <summary>
    ''' 删除
    ''' </summary>
    ''' <remarks></remarks>
    Public Const SQL_Shifts_DelAtByid = " Delete from T15510_AT_Shifts where Shift_Line=@Shift_Line "

    ''' <summary>
    ''' 设置过时
    ''' </summary>
    ''' <remarks></remarks>
    Public Const SQL_Shifts_SetOut = " Update T15510_AT_Shifts set IsOut=1 where Line=@Line "


    ''' <summary>
    '''  根据员工编号，返回ta所属的部门可能的班次
    ''' </summary>
    ''' <remarks></remarks>
    Public Const SQL_Shift_GetEmployeeShifts = "select * from T15510_AT_Shifts"


#End Region

#Region "查询"

    ''' <summary>
    '''查询班所有次信息
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Shifts_GetByAll() As DtReturnMsg
        Dim rmsg As DtReturnMsg
        rmsg = PClass.PClass.SqlStrToDt(SQL_Shifts_GetAll)

        If rmsg.IsOk Then
            For Each R As DataRow In rmsg.Dt.Rows
                If IsNull(R("TwoTime"), False) = False Then
                    R("UP_Time2") = ""
                    R("Down_Time2") = ""
                End If
            Next
        End If
        rmsg.Dt.AcceptChanges()
        Return rmsg
    End Function

    ''' <summary>
    ''' 按编号查询班次信息
    ''' </summary>
    ''' <param name="_id"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Shifts_GetByID(ByVal _id As String) As DtReturnMsg
        Dim rmsg As DtReturnMsg
        rmsg = PClass.PClass.SqlStrToDt(SQL_Shifts_GetByLine, "@Line", _id)
        Return rmsg
    End Function


#End Region

#Region "修改"

    '''' <summary>
    '''' 添加班次
    '''' </summary>
    '''' <param name="dtSource"></param>
    '''' <returns></returns>
    '''' <remarks></remarks>
    'Public Shared Function Shifts_Add(ByVal dtSource As DataTable) As MsgReturn
    '    Dim Cnn As New SqlClient.SqlConnection
    '    Dim Da As New SqlClient.SqlDataAdapter
    '    Dim dt As DataTable
    '    Dim msg As New MsgReturn
    '    Dim sql As String
    '    Dim AtId As String = dtSource.Rows(0)("shift_id")
    '    Try

    '        sql = SQL_Shifts_GetByID
    '        dt = SqlStrToDt(sql, Cnn, Da, "shift_id", AtId).Dt
    '        If dt.Rows.Count = 0 Then
    '            DvToDt(dtSource, dt, New List(Of String), True)
    '            DtToUpDate(dt, Cnn, Da)
    '            msg.IsOk = True
    '        Else
    '            msg.IsOk = False
    '            msg.Msg = "班次" & dtSource.Rows(0)("shift_name") & "已经存在"
    '        End If

    '        Return msg
    '    Catch ex As Exception
    '        msg.IsOk = False
    '        msg.Msg = "班次" & dtSource.Rows(0)("shift_name") & "添加错误"
    '        DebugToLog(ex)
    '        Return msg
    '    Finally
    '        Da.Dispose()
    '        Cnn.Dispose()
    '    End Try

    'End Function



    '''' <summary>
    '''' 修改班次信息
    '''' </summary>
    '''' <param name="dtSource"></param>
    '''' <returns></returns>
    '''' <remarks></remarks>
    'Public Shared Function Shifts_Save(ByVal dtSource As DataTable, ByVal _Bill_ID As String) As MsgReturn

    '    Dim Cnn As New SqlClient.SqlConnection
    '    Dim Da As New SqlClient.SqlDataAdapter
    '    Dim dt As DataTable
    '    Dim msg As New MsgReturn
    '    Dim sql As String
    '    Dim AtId As String = _Bill_ID
    '    Try

    '        sql = SQL_Shifts_GetByID
    '        dt = SqlStrToDt(sql, Cnn, Da, "shift_id", AtId).Dt
    '        If dt.Rows.Count = 1 Then
    '            DvUpdateToDt(dtSource, dt, New List(Of String))
    '            DtToUpDate(dt, Cnn, Da)
    '            msg.IsOk = True
    '        Else
    '            msg.IsOk = False
    '            msg.Msg = "班次" & dtSource.Rows(0)("shift_name") & "不存在"
    '        End If

    '        Return msg
    '    Catch ex As Exception
    '        msg.IsOk = False
    '        msg.Msg = "班次" & dtSource.Rows(0)("shift_name") & "修改错误"
    '        DebugToLog(ex)
    '        Return msg
    '    Finally
    '        Da.Dispose()
    '        Cnn.Dispose()
    '    End Try
    ' End Function


    ''' <summary>
    ''' 添加班次
    ''' </summary>
    ''' <param name="dtTable"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Shift_Add(ByVal dtTable As DataTable) As MsgReturn
        Dim msg As New DtListReturnMsg
        Dim R As New MsgReturn
        Dim sqlMap As New Dictionary(Of String, String)
        Dim paraMap As New Dictionary(Of String, Object)
        Dim shift_id As String = dtTable.Rows(0)("shift_id")
        Dim IsInsert As Boolean = False
        paraMap.Add("shift_id", shift_id)
        paraMap.Add("Shift_Line", -1)
        Try
            sqlMap.Add("Table", SQL_Shifts_GetByShiftID)

            msg = SqlStrToDt(sqlMap, paraMap)
            If msg.DtList("Table").Rows.Count = 0 Then
                DvToDt(dtTable, msg.DtList("Table"), New List(Of String), True)


                DtToUpDate(msg)
                R.IsOk = True
            Else
                R.IsOk = False
                R.Msg = "班次[" & dtTable.Rows(0)("shift_id") & "]已经存在!"
            End If
            Return R
        Catch ex As Exception
            R.IsOk = False
            R.Msg = "班次[" & dtTable.Rows(0)("shift_id") & "]添加错误!"
            DebugToLog(ex)
            Return R
        Finally
        End Try
    End Function

    ''' <summary>
    ''' 修改班次
    ''' </summary>
    ''' <param name="dtTable"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Shifts_Save(ByVal LID As String, ByVal dtTable As DataTable) As MsgReturn
        Dim msg As New DtListReturnMsg
        Dim R As New MsgReturn
        Dim sqlMap As New Dictionary(Of String, String)
        Dim paraMap As New Dictionary(Of String, Object)
        Dim shiftID As String = dtTable.Rows(0)("shift_id")

        dtTable.Rows(0)("Line") = LID
        paraMap.Add("Line", LID)

        Try

            'If Val(SqlStrToOneStr("select Count(1) from T15610_Attendance_Data where Shift_Line=@Shift_Line and isLock=0", "Shift_Line", LID).Msg) > 0 Then
            '    R.IsOk = False
            '    R.Msg = " 班次[" & shiftID & "][" & LID & "]正在使用中！"
            '    Return R
            'End If

            sqlMap.Add("Table", SQL_Shifts_GetByLine)

            msg = SqlStrToDt(sqlMap, paraMap)
            If msg.DtList("Table").Rows.Count >= 1 Then

                Dim L As New List(Of String)
                L.Add("Line")
                DvUpdateToDt(dtTable, msg.DtList("Table"), L)


                DtToUpDate(msg)

                R.IsOk = True
            Else
                R.IsOk = False
                R.Msg = "班次[" & LID & "]不存在"
            End If
            Return R
        Catch ex As Exception
            R.IsOk = False
            R.Msg = "班次[" & LID & "]修改错误"
            DebugToLog(ex)
            Return R
        Finally
        End Try
    End Function


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="AtId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Shifts_SetOut(ByVal AtId As Integer) As MsgReturn
        Return RunSQL(SQL_Shifts_SetOut, "@Line", AtId)
    End Function

    ''' <summary>
    ''' 根据员工编号，返回ta所属的部门可能的班次
    ''' </summary>
    ''' <param name="_employeeID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Shift_GetEmployeeShifts(ByVal _employeeID As Integer) As DtReturnMsg
        Dim sqlBuider As New StringBuilder
        sqlBuider.Append("select S.* from  ")
        sqlBuider.Append(" T15001_Employee E,T15511_AT_Shifts_Dept D,T15510_AT_Shifts s ")
        sqlBuider.Append(" where e.Employee_Dept=d.Dept_No and d.shift_id=s.shift_id ")
        sqlBuider.Append(" and e.ID=@Employee_ID ")
        Return SqlStrToDt(sqlBuider.ToString, "Employee_ID", _employeeID)

    End Function

#End Region

End Class