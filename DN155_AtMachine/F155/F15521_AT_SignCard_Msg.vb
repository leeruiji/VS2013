Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports BaseClass

Public Class F15521_AT_SignCard_Msg

    Dim dtSignCard As DataTable
    Dim isloaded As Boolean = False

    Public Sub New()

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。
        Bill_ID = 0
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
        ID = 15520
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

    Private Sub F15521_AT_SignCard_Msg_Me_Closing(ByVal sender As Object, ByRef e As System.ComponentModel.CancelEventArgs) Handles Me.Me_Closing
        If dtSignCard IsNot Nothing AndAlso dtSignCard.Rows.Count > 0 Then
            Me.LastForm.ReturnId = dtSignCard.Rows(0)("SD_ID")
        End If

    End Sub


    Private Sub F15501_At_Msg_Load() Handles Me.Me_Load
        FormCheckRight()
        Ch_Name = GetBillTypeName(ID)
        'Dao.Balance_DB_NAME = Ch_Name
        Me.Title = Ch_Name

        Me_Refresh()
        isloaded = True
    End Sub

    Protected Sub Me_Refresh()
        Dim msg As DtReturnMsg = Dao.SignCard_GetByID(Bill_ID)
        If msg.IsOk Then
            dtSignCard = msg.Dt
            SetForm(msg.Dt)

        End If
        If Mode = Mode_Enum.Modify Then
            DP_EndDate.Visible = False
            LB_DateTo.Visible = False
        End If
    End Sub

#Region "表单信息"
    ''' <summary>
    ''' 获取表单内容
    ''' </summary>
    ''' <remarks></remarks>
    Protected Function GetForm() As DataTable
        Dim dt As DataTable
        dt = dtSignCard.Clone
        If Not dt Is Nothing Then
            dt.Clear()
            Dim dr As DataRow ' = dt.NewRow
            If Mode = Mode_Enum.Add Then


                Dim d As Date = DP_StartDate.Value.Date
                While (d <= DP_EndDate.Value.Date)
                    dr = dt.NewRow

                    dr("SD_Cause") = TB_SD_Cause.Text
                    dr("Employee_ID") = CB_Employee_ID.IDAsInt

                    dr("Card") = Dao.User_GetCard(CB_Employee_ID.IDAsInt)

                    dr("Employee_Name") = CB_Employee_ID.NameValue
                    dr("Employee_No") = CB_Employee_ID.NoValue
                    dr("Employee_Date") = New Date(d.Year, d.Month, d.Day, DP_SignTime.Value.Hour, DP_SignTime.Value.Minute, DP_SignTime.Value.Second)

                    dr("SD_Date") = GetDate()
                    dr("SD_User") = PClass.PClass.User_Name
                    dr("IsHandle") = 1
                    dt.Rows.Add(dr)
                    d = d.AddDays(1)
                End While
            Else
                dr = dt.NewRow

                dr("SD_Cause") = TB_SD_Cause.Text
                dr("Employee_ID") = CB_Employee_ID.IDAsInt
                dr("Card") = Dao.User_GetCard(CB_Employee_ID.IDAsInt)
                dr("Employee_Name") = CB_Employee_ID.NameValue
                dr("Employee_No") = CB_Employee_ID.NoValue
                dr("Employee_Date") = New Date(DP_StartDate.Value.Year, DP_StartDate.Value.Month, DP_StartDate.Value.Day, DP_SignTime.Value.Hour, DP_SignTime.Value.Minute, DP_SignTime.Value.Second) ' DP_StartDate.Value

                dr("SD_Date") = GetDate()
                dr("SD_User") = PClass.PClass.User_Name
                dr("IsHandle") = 1
                dt.Rows.Add(dr)
            End If



        End If
        Return dt
    End Function

    ''' <summary>
    ''' 设置表单内容
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub SetForm(ByVal dt As DataTable)
        If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
            Dim dr As DataRow = dt.Rows(0)
            TB_SD_Cause.Text = IsNull(dr("SD_Cause"), "")
            CB_Employee_ID.IDValue = dr("Employee_ID")
            CB_Employee_ID.GetByTextBoxTag()

            'dr("Employee_Date") = New Date(d.Year, d.Month, d.Day, DP_SignTime.Value.Hour, DP_SignTime.Value.Minute, DP_SignTime.Value.Second)
            DP_StartDate.Value = dr("Employee_Date")
            DP_EndDate.Value = dr("Employee_Date")
            DP_SignTime.Value = dr("Employee_Date")

            'dr("SD_Date") = GetDate()
            ' dr("SD_User") = PClass.PClass.User_Name
            ' dr("IsHandle") = 1
        End If

    End Sub


#End Region


#Region "工具栏按钮"


    Private Sub Cmd_Modify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Modify.Click

        If CheckForm() Then ShowConfirm("是否保存签卡记录 [" & CB_Employee_ID.Text & "] 的修改?", AddressOf Save)
    End Sub

    Protected Sub Save()

        Dim R As MsgReturn

        If Me.Mode = Mode_Enum.Add Then
            R = Dao.SignCard_Add(GetForm())
        Else
            R = Dao.SignCard_Save(GetForm(), dtSignCard)
        End If
        If R.IsOk Then
            LastForm.ReturnId = CB_Employee_ID.Text
            Me.Close()
        Else
            ShowErrMsg(R.Msg)
        End If
    End Sub
    Protected Function CheckForm() As Boolean
        If CB_Employee_ID.IDAsInt = 0 Then
            ShowErrMsg("请选择一个员工！", AddressOf CB_Employee_ID.Focus)
            Return False
        End If



        If TB_SD_Cause.Text = "" Then
            ShowErrMsg("签卡原因不能为空", AddressOf TB_SD_Cause.Focus)
            Return False
        End If




        Return True
    End Function




    Private Sub Cmd_Del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Del.Click
        ShowConfirm("是否删除签卡记录 [" & CB_Employee_ID.Text & "]?", AddressOf DelSignCard)
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub DelSignCard()
        Dim msg As MsgReturn = Dao.SignCard_Del(dtSignCard.Rows(0)("SD_ID"), dtSignCard.Rows(0)("Card"), dtSignCard.Rows(0)("Employee_Date"))
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





    Private Sub PanelMain_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PanelMain.Paint

    End Sub
End Class


Partial Class Dao
#Region "常量，SQL"

    ''' <summary>
    ''' 按编号查询签卡记录信息
    ''' </summary>
    ''' <remarks></remarks>
    Public Const SQL_SignCard_GetAll = " select * from T15520_AT_SignCard "
    ''' <summary>
    ''' 按编号查询签卡记录信息
    ''' </summary>
    ''' <remarks></remarks>
    Public Const SQL_SignCard_GetByID = " select * from T15520_AT_SignCard where SD_ID=@SD_ID "
    ''' <summary>
    ''' 删除
    ''' </summary>
    ''' <remarks></remarks>
    Public Const SQL_SignCard_DelAtByid = "delete from T15520_AT_SignCard where SD_ID=@SD_ID   Delete  from T15502_At_Data where Card_ID=@Card_ID and Card_Date=@Card_Date and AT_ID=999 "
#End Region

#Region "查询条件"
    Public Shared Function User_GetCard(ByVal ID As Integer) As String
        Return SqlStrToOneStr("select Employee_Card from T15001_Employee where ID=@ID", "ID", ID).Msg
    End Function



    ''' <summary>
    ''' 获取查询条件集合
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function SignCard_GetConditionNames() As List(Of FindOption)
        Dim foList As New List(Of FindOption)
        Dim fo As New FindOption
        fo.Field = "请选择"
        fo.DB_Field = ""
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "卡号"
        fo.DB_Field = "Card"
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "员工编号"
        fo.DB_Field = "Employee_No"
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "员工名称"
        fo.DB_Field = "Employee_Name"
        foList.Add(fo)

        Return foList
    End Function
#End Region

#Region "查询"

    ''' <summary>
    '''查询所有次信息
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function SignCard_GetByOption(ByVal oList As OptionList) As DtReturnMsg


        Dim paraMap As New Dictionary(Of String, Object)
        Dim sqlBuider As New StringBuilder
        sqlBuider.Append(SQL_SignCard_GetAll)
        sqlBuider.Append("  WHERE 1=1  ")
        sqlBuider.Append(BaseClass.OptionClass.OptionClass_BuidSqlConditon(oList.FoList, paraMap))
        sqlBuider.Append(" order by  SD_ID")
        Return PClass.PClass.SqlStrToDt(sqlBuider.ToString, paraMap)
    End Function

    ''' <summary>
    ''' 按编号查询签卡记录信息
    ''' </summary>
    ''' <param name="_id"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function SignCard_GetByID(ByVal _id As Integer) As DtReturnMsg
        Dim rmsg As DtReturnMsg
        rmsg = PClass.PClass.SqlStrToDt(SQL_SignCard_GetByID, "@SD_ID", _id)
        Return rmsg
    End Function

#End Region

#Region "修改"

    ''' <summary>
    ''' 添加签卡记录
    ''' </summary>
    ''' <param name="dtSource"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function SignCard_Add(ByVal dtSource As DataTable) As MsgReturn
        Dim msg As New DtListReturnMsg
        Dim R As New MsgReturn
        Dim sqlMap As New Dictionary(Of String, String)
        Dim paraMap As New Dictionary(Of String, Object)
        '  Dim PurchaseId As String = dtTable.Rows(0)("SD_ID")
        Dim IsInsert As Boolean = False
        '   paraMap.Add("SD_ID", PurchaseId)
        Try
            sqlMap.Add("SignCard", "select top 0 * from T15520_AT_SignCard")
            sqlMap.Add("Data", " select top 0 * from T15502_At_Data ")

            msg = SqlStrToDt(sqlMap, paraMap)
            If msg.DtList("SignCard").Rows.Count = 0 Then
                DvToDt(dtSource, msg.DtList("SignCard"), New List(Of String), True)
                Dim dtData As DataTable = msg.DtList("Data").Clone
                Dim newDr As DataRow
                For Each dr As DataRow In dtSource.Rows
                    newDr = dtData.NewRow
                    newDr("Card_ID") = dr("Card")
                    newDr("Card_Date") = dr("Employee_Date")
                    newDr("AT_ID") = 999
                    newDr("User_ID") = dr("Employee_ID")
                    newDr("Type") = "手工签卡"
                    newDr("IsHandle") = 1
                    dtData.Rows.Add(newDr)
                Next
                DvToDt(dtData, msg.DtList("Data"), New List(Of String), True)

                DtToUpDate(msg)
                R.Msg = "签卡记录[" & dtSource.Rows(0)("Employee_Name") & "]添加成功!"
                R.IsOk = True
            Else
                R.IsOk = False
                R.Msg = "签卡记录[" & dtSource.Rows(0)("Employee_Name") & "]已经存在!请双击编号文本框,获取新编号!"
            End If
            Return R
        Catch ex As Exception
            R.IsOk = False
            R.Msg = "签卡记录[" & dtSource.Rows(0)("Employee_Name") & "]添加错误!"
            DebugToLog(ex)
            Return R
        Finally
        End Try
    End Function

    ''' <summary>
    ''' 添加签卡记录
    ''' </summary>
    ''' <param name="dtSource"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function SignCard_Save(ByVal dtSource As DataTable, ByVal _dtSignCard As DataTable) As MsgReturn
        Dim msg As New DtListReturnMsg
        Dim R As New MsgReturn
        Dim sqlMap As New Dictionary(Of String, String)
        Dim paraMap As New Dictionary(Of String, Object)
        Dim SD_ID As String = _dtSignCard.Rows(0)("SD_ID")
        Dim IsInsert As Boolean = False
        paraMap.Add("SD_ID", SD_ID)
        paraMap.Add("Card_ID", _dtSignCard.Rows(0)("Card"))
        paraMap.Add("Card_Date", _dtSignCard.Rows(0)("Employee_Date"))
        Try
            sqlMap.Add("SignCard", SQL_SignCard_GetByID)
            sqlMap.Add("Data", " select top 1 * from T15502_At_Data where Card_ID=@Card_ID and Card_Date=@Card_Date and AT_ID=999")

            msg = SqlStrToDt(sqlMap, paraMap)
            If msg.DtList("SignCard").Rows.Count = 1 Then
                DvUpdateToDt(dtSource, msg.DtList("SignCard"), New List(Of String))
                Dim dtData As DataTable = msg.DtList("Data").Clone
                Dim newDr As DataRow
                For Each dr As DataRow In dtSource.Rows
                    newDr = dtData.NewRow
                    newDr("Card_ID") = dr("Card")
                    newDr("Card_Date") = dr("Employee_Date")
                    newDr("AT_ID") = 999
                    newDr("User_ID") = dr("Employee_ID")
                    newDr("Type") = "手工签卡"
                    newDr("IsHandle") = 1
                    dtData.Rows.Add(newDr)
                Next
                DvUpdateToDt(dtData, msg.DtList("Data"), New List(Of String))

                DtToUpDate(msg)
                R.Msg = "签卡记录[" & dtSource.Rows(0)("Employee_Name") & "]添加成功!"
                R.IsOk = True
            Else
                R.IsOk = False
                R.Msg = "签卡记录[" & dtSource.Rows(0)("Employee_Name") & "]不存在!"
            End If
            Return R
        Catch ex As Exception
            R.IsOk = False
            R.Msg = "签卡记录[" & dtSource.Rows(0)("Employee_Name") & "]添加错误!"
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
    Public Shared Function SignCard_Del(ByVal Bill_ID As Integer, ByVal _card As String, ByVal _cardDate As Date) As MsgReturn
        Dim p As New Dictionary(Of String, Object)
        p.Add("SD_ID", Bill_ID)
        p.Add("Card_ID", _card)
        p.Add("Card_Date", _cardDate)
        Return RunSQL(SQL_SignCard_DelAtByid, p)
    End Function

#End Region

End Class