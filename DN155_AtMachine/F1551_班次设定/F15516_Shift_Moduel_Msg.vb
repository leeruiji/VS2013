Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports BaseClass

Public Class F15516_Shift_Moduel_Msg
    Implements iShift
    Dim dtModuel As DataTable
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
        ID = 15515
        Control_CheckRight(ID, ClassMain.Modify, Cmd_Modify)
    End Sub

    Private Sub Me_From_Load() Handles Me.Me_Load
        FormCheckRight()
        Ch_Name = GetBillTypeName(ID)
        'Dao.Balance_DB_NAME = Ch_Name
        Me.Title = Ch_Name
        Debug.Print((L - Now).TotalMilliseconds / 1000)
        L = Now


        Date_Ini()

        Me_Refresh()

        isloaded = True
    End Sub
    Public StartDate As Date
    ''' <summary>
    ''' 本月有几日
    ''' </summary>
    ''' <remarks></remarks>
    Dim MDays As Integer = 31
    Sub Date_Ini()

        Dim R As DtReturnMsg = Dao.Shifts_GetByAll
        If R.IsOk = False Then
            Exit Sub
        End If
        For i As Integer = 1 To 31
            Dim U As New ModuelDay
            U.Name = "ModuelDay" & i
            U.PF = Me

            U.CB_Data.ValueMember = "Line"
            U.CB_Data.DisplayMember = "shift_name"
            U.CB_Data.DataSource = R.Dt.Copy
            U.CB_Data.ValueMember = "Line"
            U.CB_Data.DisplayMember = "shift_name"
            U.SetDate(i)
            FP_Month.Controls.Add(U)
        Next


    End Sub



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
    Protected Sub Me_Refresh()
        Dim msg As DtReturnMsg = Dao.Shift_ModuelGet(Me.Bill_ID)
        If msg.IsOk Then
            DtTable = msg.Dt
            If msg.Dt.Rows.Count > 0 Then


                TB_Moduel_Name.Text = IsNull(msg.Dt.Rows(0)("Name"), "")
                TB_Moduel_Name.Tag = msg.Dt.Rows(0)("ID")
                TB_Remark.Text = IsNull(msg.Dt.Rows(0)("Remark"), "")
            End If
        End If

        msg = Dao.Shift_Moduel_GetList(Bill_ID)
        If msg.IsOk Then
            DtList = msg.Dt
            If msg.Dt.Rows.Count > 0 Then
                For Each u As ModuelDay In FP_Month.Controls
                    Dim drs As DataRow() = msg.Dt.Select("sDay=" & u.NowDay)
                    If drs.Length > 0 Then
                        u.Shift_Line = drs(0)("Shift_Line")
                        u.CB_Data.SelectedValue = drs(0)("Shift_Line")
                    End If
                Next
            End If


        End If

    End Sub

#Region "表单信息"
    Dim DtTable As DataTable
    Dim DtList As DataTable

    ''' <summary>
    ''' 获取表单内容
    ''' </summary>
    ''' <remarks></remarks>
    Protected Function GetForm() As DataTable
        Dim _DtTable As DataTable
        _DtTable = DtTable.Clone
        Dim dr As DataRow
        dr = _DtTable.NewRow
        dr("Name") = TB_Moduel_Name.Text
        If Mode = Mode_Enum.Add Then
            '   dr("ID") = -99
        Else
            dr("ID") = Val(TB_Moduel_Name.Tag)
        End If

        dr("Remark") = TB_Remark.Text
        _DtTable.Rows.Add(dr)
        DtTable = _DtTable
        Dim _DtList As DataTable = DtList.Clone

        For i As Integer = 1 To MDays
            dr = _DtList.NewRow
            Dim U As ModuelDay = FP_Month.Controls("ModuelDay" & i)
            If Mode = Mode_Enum.Add Then
                dr("ID") = -99
            Else
                dr("ID") = Val(TB_Moduel_Name.Tag)
            End If

            dr("sDay") = U.NowDay
            dr("Shift_Line") = U.Shift_Line

            _DtList.Rows.Add(dr)

        Next
        DtList = _DtList
        Return DtTable
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

        If CheckForm() Then ShowConfirm("是否保存班次模板 [" & TB_Moduel_Name.Text & "] 的修改?", AddressOf Save)
    End Sub

    Protected Sub Save()

        Dim R As New MsgReturn
        If Mode = Mode_Enum.Add Then
            R = Dao.Shift_Moduel_Add(GetForm, DtList)
        ElseIf Mode = Mode_Enum.Modify Then
            R = Dao.Shift_Moduel_Save(Me.Bill_ID, GetForm, DtList)
        End If


        If R.IsOk Then
            LastForm.ReturnId = TB_Moduel_Name.Tag
            Me.Close()
        Else
            ShowErrMsg(R.Msg)
        End If
    End Sub
    Protected Function CheckForm() As Boolean
        If TB_Moduel_Name.Text = "" Then
            ShowErrMsg("模板名称不能为空！", AddressOf TB_Moduel_Name.Focus)
            Return False
        End If

        Dim msg As DtReturnMsg = Dao.Shift_ModuelGetBYName(TB_Moduel_Name.Text)
        If msg.IsOk Then
            If Mode = Mode_Enum.Add AndAlso msg.Dt.Rows.Count > 0 Then
                ShowErrMsg("模板名称【" & TB_Moduel_Name.Text & "】已经被使用，请使用另一名称！", AddressOf TB_Moduel_Name.Focus)
                Return False
            ElseIf Mode = Mode_Enum.Modify AndAlso msg.Dt.Rows.Count > 0 Then
                Dim drs As DataRow() = msg.Dt.Select("ID<>" & TB_Moduel_Name.Tag)
                If drs.Length > 0 Then
                    ShowErrMsg("模板名称【" & TB_Moduel_Name.Text & "】已经被使用，请使用另一名称！", AddressOf TB_Moduel_Name.Focus)
                    Return False
                End If

            End If
        Else
            ShowErrMsg("验证模板名称时出错：" & msg.Msg)
            Return False
        End If
        'If TB_Card.Text = "" Then
        '    ShowErrMsg("卡号不能为空", AddressOf TB_Card.Focus)
        '    Return False
        'End If

        'If TB_SD_Cause.Text = "" Then
        '    ShowErrMsg("签卡原因不能为空", AddressOf TB_SD_Cause.Focus)
        '    Return False
        'End If




        Return True
    End Function




    Private Sub Cmd_Del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ShowConfirm("是否删除班次模板 [" & TB_Moduel_Name.Text & "]?", AddressOf DelModuel)
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub DelModuel()
        Dim msg As MsgReturn = Dao.Shift_Moduel_Del(dtModuel.Rows(0)("ID"))
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




End Class


Partial Class Dao

    Private Const SQL_Shift_Moduel_Get As String = "select * from T15515_Shift_Moudel where ID=@ID"

    Private Const SQL_Shift_Moduel_GetByName As String = "select * from T15515_Shift_Moudel where Name=@Name"

    Private Const SQL_Shift_Moduel_GetList As String = "select * from T15516_Shift_Moudel_List where ID=@ID"

    Public Const SQL_Shift_Moduel_Del = "delete from T15515_Shift_Moudel where ID=@ID ; delete from T15516_Shift_Moudel_List where ID=@ID "

    Public Shared Function Shift_ModuelGet(ByVal _ID As Integer) As DtReturnMsg
        Dim P As New Dictionary(Of String, Object)
        P.Add("ID", _ID)

        Dim R As DtReturnMsg = SqlStrToDt(SQL_Shift_Moduel_Get, P)
        Return R
    End Function

    Public Shared Function Shift_ModuelGetBYName(ByVal _Name As String) As DtReturnMsg
        Dim P As New Dictionary(Of String, Object)
        P.Add("Name", _Name)

        Dim R As DtReturnMsg = SqlStrToDt(SQL_Shift_Moduel_GetByName, P)
        Return R
    End Function



    Public Shared Function Shift_Moduel_GetList(ByVal _ID As Integer) As DtReturnMsg
        Dim P As New Dictionary(Of String, Object)
        P.Add("ID", _ID)

        Dim R As DtReturnMsg = SqlStrToDt(SQL_Shift_Moduel_GetList, P)
        Return R
    End Function


    ''' <summary>
    ''' 添加班次模板
    ''' </summary>
    ''' <param name="dtTable"></param>
    ''' <param name="dtList"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Shift_Moduel_Add(ByVal dtTable As DataTable, ByVal dtList As DataTable) As MsgReturn
        Dim msg As New DtListReturnMsg
        Dim R As New MsgReturn
        Dim sqlMap As New Dictionary(Of String, String)
        Dim paraMap As New Dictionary(Of String, Object)
        Dim _Name As String = dtTable.Rows(0)("Name")
        Dim IsInsert As Boolean = False
        '  paraMap.Add("ID", _Name)
        paraMap.Add("ID", -1)
        Try
            sqlMap.Add("Table", SQL_Shift_Moduel_Get)
            sqlMap.Add("List", SQL_Shift_Moduel_GetList)

            msg = SqlStrToDt(sqlMap, paraMap)
            If msg.DtList("Table").Rows.Count = 0 Then
                DvToDt(dtTable, msg.DtList("Table"), New List(Of String), True)
                DvToDt(dtList, msg.DtList("List"), New List(Of String), True)

                DtToUpDate(msg, "Update T15516_Shift_Moudel_List set ID=(select top 1 ID from T15515_Shift_Moudel where Name='" & _Name & "' order by ID desc) where ID=-99  ")
                R.Msg = "班次模板[" & _Name & "]添加成功!"
                R.IsOk = True
            Else
                R.IsOk = False
                R.Msg = "班次模板[" & _Name & "]已经存在!"
            End If
            Return R
        Catch ex As Exception
            R.IsOk = False
            R.Msg = "班次模板[" & _Name & "]添加错误!"
            DebugToLog(ex)
            Return R
        Finally
        End Try
    End Function


    Public Shared Function Shift_Moduel_Save(ByVal LID As String, ByVal dtTable As DataTable, ByVal dtList As DataTable) As MsgReturn
        Dim msg As New DtListReturnMsg
        Dim R As New MsgReturn
        Dim sqlMap As New Dictionary(Of String, String)
        Dim paraMap As New Dictionary(Of String, Object)
        Dim _Name As String = dtTable.Rows(0)("Name")
        Dim IsInsert As Boolean = False
        '  paraMap.Add("ID", _Name)
        paraMap.Add("ID", LID)
        Try
            sqlMap.Add("Table", SQL_Shift_Moduel_Get)
            sqlMap.Add("List", SQL_Shift_Moduel_GetList)

            msg = SqlStrToDt(sqlMap, paraMap)
            If msg.DtList("Table").Rows.Count = 1 Then
                DvToDt(dtList, msg.DtList("List"), New List(Of String))
                DvUpdateToDt(dtTable, msg.DtList("Table"), New List(Of String))

                DtToUpDate(msg) ', "Update T15516_Shift_Moudel_List set ID=(select top 1 ID from T15515_Shift_Moudel where Name='" & _Name & "' order by ID desc) where ID=-99  ")
                R.Msg = "班次模板[" & _Name & "]修改成功!"
                R.IsOk = True
            Else
                R.IsOk = False
                R.Msg = "班次模板[" & _Name & "]不!"
            End If
            Return R
        Catch ex As Exception
            R.IsOk = False
            R.Msg = "班次模板[" & _Name & "]添加错误!"
            DebugToLog(ex)
            Return R
        Finally
        End Try
    End Function



    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="Bill_ID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Shift_Moduel_Del(ByVal Bill_ID As String) As MsgReturn
        Return RunSQL(SQL_Shift_Moduel_Del, "@ID", Bill_ID)
    End Function

End Class