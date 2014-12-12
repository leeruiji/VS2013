Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports BaseClass

Public Class F15606_PBB_Mx_Msg
    Implements iShift

    Dim isloaded As Boolean = False
    ''' <summary>
    ''' 班次模板列表
    ''' </summary>
    ''' <remarks></remarks>
    Dim Dt_Shift_Moudel_List As DataTable
    ''' <summary>
    ''' 班次集合
    ''' </summary>
    ''' <remarks></remarks>
    Dim Dt_Shifts As DataTable
    Dim Dt_Month As DataTable
    Dim Dt_Date As DataTable
    Dim Dt_Modify As DataTable



    Public Sub New()
        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()


    End Sub
    ''' <summary>
    ''' 权限获取
    ''' </summary>
    ''' <remarks></remarks>
    Sub FormCheckRight()
        ID = 15605
        Control_CheckRight(ID, ClassMain.Modify, Cmd_Modify)
    End Sub

    Private Sub F15518_Real_Shift_Msg_AfterLoad() Handles Me.AfterLoad
        FP_Month.SuspendLayout()
        Date_Ini()
        FP_Month.ResumeLayout()
        Date_Change(MonthPicker1.Value)

        isloaded = True
    End Sub

    Private Sub Me_From_Load() Handles Me.Me_Load
        If P_F_RS_ID = "" Then
            Me.Close()
            Exit Sub
        Else
            TB_Depart.Text = Me.P_F_RS_ID5
            TB_Employee_Name.Text = Me.P_F_RS_ID3


            Dim Rt As DtReturnMsg = Dao.Real_Shift_GetJoinMoudel(P_F_RS_ID)
            If Rt.IsOk AndAlso Rt.Dt.Rows.Count > 0 Then
                Try
                    TB_Moduel_Name.Text = Rt.Dt.Rows(0)("Name")
                    Label_Moudel_Name.Text = Rt.Dt.Rows(0)("Shift_Moudel_Name")
                    Label_Moudel_Name.Tag = Rt.Dt.Rows(0)("Shift_Moudel_ID")
                    Bill_ID = Rt.Dt.Rows(0)("ID")
                Catch ex As Exception
                    ShowErrMsg("没有找到实际班次模板", True)
                    Exit Sub
                End Try
            Else
                ShowErrMsg("没有找到实际班次模板", True)
                Exit Sub
            End If
        End If

        Dim Rmodify As DtReturnMsg = Dao.Real_Shift_Modify(P_F_RS_ID2, P_F_RS_ID4)
        If Rmodify.IsOk Then

            Dt_Modify = Rmodify.Dt
        End If






        Dim D As Date = GetDate()
        MonthPicker1._ThisMonth = GetDate()
        If F_RS_ID2 = "" OrElse IsDate(F_RS_ID2) = False Then
            MonthPicker1.Value = New Date(D.Year, D.Month, 1)
        Else
            D = CDate(F_RS_ID2)
            MonthPicker1.Value = New Date(D.Year, D.Month, 1)
        End If

        FormCheckRight()

        Ch_Name = GetBillTypeName(ID)
        'Dao.Balance_DB_NAME = Ch_Name
        Me.Title = Ch_Name
        L = Now
        Dim R As DtReturnMsg = Dao.Shifts_GetByAll
        If R.IsOk = False Then
            Me.Close()
            Exit Sub
        Else
            Dt_Shifts = R.Dt
        End If

        R = Dao.Shift_Moduel_GetList(Label_Moudel_Name.Tag)
        If R.IsOk = False Then
            Me.Close()
            Exit Sub
        Else
            Dt_Shift_Moudel_List = R.Dt
        End If

    End Sub
   





#Region "日期生成"

    Public StartDate As Date
    Public EndDate As Date
    ''' <summary>
    ''' 本月有几日
    ''' </summary>
    ''' <remarks></remarks>
    Dim MDays As Integer



    Sub Date_Ini()

        For i As Integer = 1 To 7
            Dim P As New Panel With {.Name = "PL_LastMonth" & i, _
                                .Visible = False, _
                                .BackColor = System.Drawing.Color.Transparent, _
                                .BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle, _
                                .Size = New System.Drawing.Size(120, 84)}

            Dim L As New Label With {.Name = "LB_LastMonth" & i}
            P.Controls.Add(L)
            L.AutoSize = True
            L.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
            L.ForeColor = System.Drawing.Color.Olive
            L.Location = New System.Drawing.Point(15, 9)
            L.Size = New System.Drawing.Size(34, 16)
            FP_Month.Controls.Add(P)
        Next
        For i As Integer = 1 To 31
            Dim U As New ModuelDay
            U.Name = "ModuelDay" & i
            U.PF = Me
            U.CB_Data.ValueMember = "Line"
            U.CB_Data.DisplayMember = "shift_name"
            U.CB_Data.DataSource = Dt_Shifts
            U.CB_Data.ValueMember = "Line"
            U.CB_Data.DisplayMember = "shift_name"

            FP_Month.Controls.Add(U)

     
        Next
        For i As Integer = 1 To 13
            Dim P As New Panel With {.Name = "PL_ThisMonth" & i, _
                                        .Visible = False, _
                                        .BackColor = System.Drawing.Color.Transparent, _
                                        .BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle, _
                                        .Size = New System.Drawing.Size(120, 84)}

            Dim L As New Label With {.Name = "LB_ThisMonth" & i}
            P.Controls.Add(L)
            L.AutoSize = True
            L.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
            L.ForeColor = System.Drawing.Color.Olive
            L.Location = New System.Drawing.Point(15, 9)
            L.Size = New System.Drawing.Size(34, 16)
            L.Text = i & "号"
            FP_Month.Controls.Add(P)
        Next
    End Sub

    Sub Date_Change(ByVal D As Date)
        Dim R As DtReturnMsg = Dao.Real_Shift_GetMonth_WithMonth(Bill_ID, D)
        If R.IsOk = False Then
            ShowErrMsg("加载失败," & R.Msg)
            Exit Sub
        End If
        Dt_Month = R.Dt
        If Dt_Month.Rows.Count > 0 Then
            TB_Remark.Text = IsNull(Dt_Month.Rows(0)("Remark"), "")
        Else
            TB_Remark.Text = ""
        End If

        R = Dao.Real_Shift_GetDate_WithMonth(Bill_ID, D)
        If R.IsOk = False Then
            ShowErrMsg("加载失败," & R.Msg)
            Exit Sub
        End If
        Dt_Date = R.Dt


        StartDate = D
        MDays = Date.DaysInMonth(D.Year, D.Month)
        EndDate = New Date(D.Year, D.Month, MDays)

        Dim LDFW As Integer = Date.DaysInMonth(D.AddMonths(-1).Year, D.AddMonths(-1).Month)
        Dim DFW As Integer = D.DayOfWeek
        If DFW = 0 Then DFW = 7
        For i As Integer = 1 To DFW
            Dim P As Panel = FP_Month.Controls("PL_LastMonth" & i)
            P.Visible = True
            P.Controls("LB_LastMonth" & i).Text = LDFW - DFW + i & "号"
        Next

        For i As Integer = DFW + 1 To 7
            FP_Month.Controls("PL_LastMonth" & i).Visible = False
        Next

        For i As Integer = 1 To MDays
            Dim U As ModuelDay = FP_Month.Controls("ModuelDay" & i)
            U.IsSel = False
            U.SetDate(New Date(D.Year, D.Month, i))
            SetModulDay(U)
            U.IsChanged = False

        Next

        For i As Integer = 28 To MDays
            FP_Month.Controls("ModuelDay" & i).Visible = True
        Next
        For i As Integer = MDays + 1 To 31
            FP_Month.Controls("ModuelDay" & i).Visible = False
        Next

        DFW = 42 - MDays - DFW

        For i As Integer = 1 To DFW
            Dim P As Panel = FP_Month.Controls("PL_ThisMonth" & i)
            P.Visible = True
            P.Controls("LB_ThisMonth" & i).Text = i & "号"
        Next
        For i As Integer = DFW + 1 To 13
            FP_Month.Controls("PL_ThisMonth" & i).Visible = False
        Next
        For i As Integer = 1 To MDays
            Dim U As ModuelDay = FP_Month.Controls("ModuelDay" & i)

            For m As Integer = 0 To Dt_Modify.Rows.Count - 1
                If Dt_Modify.Rows(m)("sDate") = U.User_Date Then
                    U.IsChanged = True
                    U.LabelState.Text = "手动排班"
                    U.CB_Data.SelectedValue = Dt_Modify.Rows(m)("Shift_ID")

                End If

            Next
        Next


    End Sub

   


    Sub SetModulDay(ByVal U As ModuelDay)
        Dim R() As DataRow
        R = Dt_Date.Select("sDate='" & U.User_Date.ToString("yyyy-MM-dd") & "'")
        If R.Length > 0 Then
            U.CB_Data.SelectedValue = IsNull(R(0)("Shift_ID"), 0)
            U.shiftId = IsNull(R(0)("Shift_ID"), 0)
            U.LabelState.Text = IsNull(R(0)("Remark"), "")
        Else
            R = Dt_Shift_Moudel_List.Select("sDay=" & U.NowDay & "")
            If R.Length > 0 Then
                U.CB_Data.SelectedValue = IsNull(R(0)("Shift_Line"), 0)
                U.shiftId = IsNull(R(0)("Shift_Line"), 0)
                U.LabelState.Text = ""

            End If
        End If
    End Sub

#End Region



    ''' <summary>
    ''' 生成搜索条件
    ''' </summary>
    ''' <remarks></remarks>
    Protected Function GetFindOtions() As OptionList
        Dim oList As New OptionList
        Dim fo As New FindOption
        Dim goodsCount As Integer = 0




        Return oList
    End Function



    Dim L As Date = Now


#Region "表单信息"


    ''' <summary>
    ''' 获取表单内容
    ''' </summary>
    ''' <remarks></remarks>
    Protected Function GetForm() As DataTable
        Dim Dt As DataTable = Dt_Modify.Clone
        Dim Dr As DataRow
        For i As Integer = 1 To MDays

            Dr = Dt.NewRow
            Dim U As ModuelDay = FP_Month.Controls("ModuelDay" & i)
            If U.IsChanged = True Then
                Dr("Employee_ID") = Me.P_F_RS_ID2
                Dr("sMonth") = StartDate
                Dr("sDate") = U.User_Date
                Dr("Shift_ID") = U.Shift_Line
                Dr("Remark") = TB_Remark.Text
                Dt.Rows.Add(Dr)
            End If
        Next
        Return Dt
    End Function

    ''' <summary>
    ''' 设置表单内容
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub SetForm(ByVal dt As DataTable)
        If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
            Dim dr As DataRow = dt.Rows(0)
            'TB_SD_Cause.Text = IsNull(dr("SD_Cause"), "")
            'TB_Employee_ID.Tag = dr("Employee_ID")
            'TB_Card.Text = IsNull(dr("Card"), "")
            'TB_Employee_Name.Text = IsNull(dr("Employee_Name"), "")
            'TB_Employee_ID.Text = IsNull(dr("Employee_No"), "")
            ''dr("Employee_Date") = New Date(d.Year, d.Month, d.Day, DP_SignTime.Value.Hour, DP_SignTime.Value.Minute, DP_SignTime.Value.Second)
            'DP_StartDate.Value = dr("Employee_Date")
            'DP_EndDate.Value = dr("Employee_Date")
            'DP_SignTime.Value = dr("Employee_Date")

            'dr("SD_Date") = GetDate()
            ' dr("SD_User") = PClass.PClass.User_Name
            ' dr("IsHandle") = 1
        End If

    End Sub


#End Region


#Region "工具栏按钮"


    Private Sub Cmd_Modify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Modify.Click
        IsSaveAndChange = False
        ShowConfirm("是否保存[" & MonthPicker1.Value.ToString("yyyy年MM月") & "]实际班次模板 [" & TB_Moduel_Name.Text & "] 的修改?", AddressOf Save)
    End Sub

    Protected Sub Save()
        Dim R As MsgReturn
        R = Dao.Real_Shift_Day_Save(P_F_RS_ID2, P_F_RS_ID4, GetForm)
        If R.IsOk Then
            LastForm.ReturnId = StartDate.ToString("yyyy-MM-dd")
            If IsSaveAndChange Then
                ChangeNoSave()
            Else
                Me.Close()
            End If
        Else
            ShowErrMsg(R.Msg)
        End If
    End Sub






    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub
#End Region
#Region "控件点击"
    Dim ClickUserDateList As New List(Of Integer)

    Public Sub ModuelDayClick(ByVal LU As ModuelDay, ByVal Key As Keys) Implements iShift.ModuelDayClick
        If Key = Keys.Shift Then
            If ClickUserDateList.Count > 0 Then
                Dim E As Integer = ClickUserDateList(ClickUserDateList.Count - 1)
                If E < LU.NowDay Then '如果当前选择 大于 最后一个
                    If ClickUserDateList.Count <> 1 Then '如果当前不止一个会将回来的删除
                        For i As Integer = ClickUserDateList.IndexOf(E) - 1 To 0 Step -1
                            Dim U As ModuelDay = FP_Month.Controls("ModuelDay" & ClickUserDateList(i))
                            ClickUserDateList.RemoveAt(i)
                            U.IsSel = False
                            U.ShowSelColor()
                        Next
                    End If
                    For i As Integer = E + 1 To LU.NowDay
                        Dim U As ModuelDay = FP_Month.Controls("ModuelDay" & i)
                        ClickUserDateList.Add(i)
                        U.IsSel = True
                        U.ShowSelColor()
                    Next
                ElseIf E = LU.NowDay Then '如果当前选择 等于 最后一个
                    For i As Integer = ClickUserDateList.IndexOf(E) - 1 To 0 Step -1
                        Dim U As ModuelDay = FP_Month.Controls("ModuelDay" & ClickUserDateList(i))
                        ClickUserDateList.RemoveAt(i)
                        U.IsSel = False
                        U.ShowSelColor()
                    Next
                Else
                    Dim S As Integer = ClickUserDateList(0)
                    If S = LU.NowDay Then '如果当前选择 等于 第一个
                        For i As Integer = ClickUserDateList.Count - 1 To 1 Step -1
                            Dim U As ModuelDay = FP_Month.Controls("ModuelDay" & ClickUserDateList(i))
                            ClickUserDateList.RemoveAt(i)
                            U.IsSel = False
                            U.ShowSelColor()
                        Next
                    ElseIf S > LU.NowDay Then '如果当前选择 小于 第一个
                        If ClickUserDateList.Count <> 1 Then '如果当前不止一个会将回来的删除
                            For i As Integer = ClickUserDateList.Count - 1 To 1 Step -1
                                Dim U As ModuelDay = FP_Month.Controls("ModuelDay" & ClickUserDateList(i))
                                ClickUserDateList.RemoveAt(i)
                                U.IsSel = False
                                U.ShowSelColor()
                            Next
                        End If
                        For i As Integer = LU.NowDay To S - 1
                            Dim U As ModuelDay = FP_Month.Controls("ModuelDay" & i)
                            ClickUserDateList.Add(i)
                            U.IsSel = True
                            U.ShowSelColor()
                        Next

                    Else '如果当前选择 大于 第一个 而且小于最后一个
                        For i As Integer = ClickUserDateList.IndexOf(E) To ClickUserDateList.IndexOf(LU.NowDay) + 1 Step -1
                            Dim U As ModuelDay = FP_Month.Controls("ModuelDay" & ClickUserDateList(i))
                            ClickUserDateList.RemoveAt(i)
                            U.IsSel = False
                            U.ShowSelColor()
                        Next
                    End If
                End If
                ClickUserDateList.Sort()
            Else '第一次点击
                ClickUserDateList.Add(LU.NowDay)
                LU.IsSel = True
                LU.ShowSelColor()
            End If
        ElseIf Key = Keys.Control Then
            ClickUserDateList.Add(LU.NowDay)
            LU.IsSel = True
            LU.ShowSelColor()
            ClickUserDateList.Sort()
        Else
            For i As Integer = ClickUserDateList.Count - 1 To 0 Step -1
                Dim U As ModuelDay = FP_Month.Controls("ModuelDay" & ClickUserDateList(i))
                ClickUserDateList.RemoveAt(i)
                U.IsSel = False
                U.ShowSelColor()
            Next
        End If
    End Sub


    Public IsChange As Boolean = False
    Public Sub ComboxSel(ByVal U As ModuelDay) Implements iShift.ComboxSel
        If IsChange = False Then
            IsChange = True
            For Each Index As Integer In ClickUserDateList
                Dim SU As ModuelDay = FP_Month.Controls("ModuelDay" & Index)
                SU.CB_Data.SelectedValue = U.CB_Data.SelectedValue
            Next
            IsChange = False
        End If
    End Sub
#End Region




    Private Sub MonthPicker1_ValueChange(ByVal Value As System.DateTime) Handles MonthPicker1.ValueChange
        If StartDate = MonthPicker1.Value Then Exit Sub
        For i As Integer = 1 To MDays
            If TryCast(FP_Month.Controls("ModuelDay" & i), ModuelDay).IsChanged Then
                ShowConfirm("是否保存[" & MonthPicker1.Value.ToString("yyyy年MM月") & "]实际班次模板 [" & TB_Moduel_Name.Text & "] 的修改?", "保存修改", "不保存", "取消", AddressOf SaveAndChange, AddressOf ChangeNoSave, AddressOf CancelChange)
                Exit Sub
            End If
        Next
        ChangeNoSave()
    End Sub

    Dim IsSaveAndChange As Boolean = False
    Sub SaveAndChange()
        IsSaveAndChange = True
        Save()
    End Sub
    Sub ChangeNoSave()
        Date_Change(MonthPicker1.Value)
    End Sub

    Sub CancelChange()
        MonthPicker1.Value = StartDate
    End Sub

End Class


Partial Class Dao

    Private Const SQL_Personal_Shift_Day_Get As String = "select  * from T15605_Personal_Shift where Employee_ID=@Employee_ID And sMonth=@sMonth"

    'Private Const SQL_Real_Shift_GetJoinMoudel As String = "select top 1 S.*,(select top 1 Name from T15515_Shift_Moudel M where M.ID=S.Shift_Moudel_ID) as Shift_Moudel_Name from T15517_Real_Shift S where ID=@ID"

    'Private Const SQL_Real_Shift_GetByName As String = "select top 1 * from T15517_Real_Shift where Name=@Name"

    'Private Const SQL_Real_Shift_GetList As String = "select * from T15517_Real_Shift_List where ID=@ID"

    'Private Const SQL_Real_Shift_GetMonth_WithMonth As String = "select top 1 * from T15518_Real_Shift_Month where ID=@ID and sMonth=@sMonth"

    'Private Const SQL_Real_Shift_GetDate_WithMonth As String = "select * from T15519_Real_Shift_Day where ID=@ID and sMonth=@sMonth"



    'Public Const SQL_Real_Shift_Del = "delete from T15517_Real_Shift where ID=@ID  delete from T15517_Real_Shift_List where ID=@ID "




    Public Shared Function Real_Shift_Modify(ByVal Employee_ID As Integer, ByVal sMonth As Date) As DtReturnMsg
        Dim P As New Dictionary(Of String, Object)
        P.Add("Employee_ID", Employee_ID)
        P.Add("sMonth", sMonth)

        Dim R As DtReturnMsg = SqlStrToDt(SQL_Personal_Shift_Day_Get, P)
        Return R
    End Function

    'Public Shared Function Real_Shift_GetJoinMoudel(ByVal _ID As Integer) As DtReturnMsg
    '    Return SqlStrToDt(SQL_Real_Shift_GetJoinMoudel, "ID", _ID)
    'End Function

    'Public Shared Function Real_Shift_GetMonth_WithMonth(ByVal _ID As Integer, ByVal M As Date) As DtReturnMsg
    '    Dim P As New Dictionary(Of String, Object)
    '    P.Add("ID", _ID)
    '    P.Add("sMonth", New Date(M.Year, M.Month, 1))
    '    Dim R As DtReturnMsg = SqlStrToDt(SQL_Real_Shift_GetMonth_WithMonth, P)
    '    Return R
    'End Function

    'Public Shared Function Real_Shift_GetDate_WithMonth(ByVal _ID As Integer, ByVal M As Date) As DtReturnMsg
    '    Dim P As New Dictionary(Of String, Object)
    '    P.Add("ID", _ID)
    '    P.Add("sMonth", New Date(M.Year, M.Month, 1))
    '    Dim R As DtReturnMsg = SqlStrToDt(SQL_Real_Shift_GetDate_WithMonth, P)
    '    Return R
    'End Function



    Public Shared Function Real_Shift_Day_Save(ByVal Employee_ID As Integer, ByVal sMonth As Date, ByVal dtList As DataTable) As MsgReturn
        Dim msg As New DtReturnMsg
        Dim R As New MsgReturn
        Dim paraMap As New Dictionary(Of String, Object)
        Dim Cnn As New SqlClient.SqlConnection
        Dim Da As New SqlClient.SqlDataAdapter
        paraMap.Add("Employee_ID", Employee_ID)
        paraMap.Add("sMonth", sMonth)
        Try

            msg = SqlStrToDt(SQL_Personal_Shift_Day_Get, Cnn, Da, paraMap)
            DvToDt(dtList, msg.Dt, New List(Of String))
            DtToUpDate(msg.Dt, Cnn, Da)
            R.Msg = "实际班次修改成功!"
            R.IsOk = True

            Return R
        Catch ex As Exception
            R.IsOk = False
            R.Msg = "实际班次添加错误!"
            DebugToLog(ex)
            Return R
        Finally
        End Try
    End Function



    '''' <summary>
    '''' 
    '''' </summary>
    '''' <param name="Bill_ID"></param>
    '''' <returns></returns>
    '''' <remarks></remarks>
    'Public Shared Function Real_Shift_Del(ByVal Bill_ID As String) As MsgReturn
    '    Return RunSQL(SQL_Real_Shift_Del, "@ID", Bill_ID)
    'End Function

End Class