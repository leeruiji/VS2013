Imports PClass.PClass
Imports System.Data
Imports System.Text
Public Class F99013_Room_Msg
    Dim RoomID As String = ""
    Dim dtRoom As DataTable

    Public Sub New()

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。

    End Sub

    Public Sub New(ByVal jID As String)
        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        ' 在 InitializeComponent() 调用之后添加任何初始化。
        RoomID = jID
        Me.Mode = Mode
    End Sub
    ''' <summary>
    ''' 权限获取
    ''' </summary>
    ''' <remarks></remarks>
    Sub FormCheckRight()
        ID = 15004
        Control_CheckRight(ID, ClassMain.Modify, Cmd_Modify)
        Control_CheckRight(ID, ClassMain.Del, Cmd_Del)
    End Sub
    Private Sub F99006_Room_Msg_Me_Load() Handles Me.Me_Load
        FormCheckRight()
        If Mode = Mode_Enum.Add Then
            If CheckRight(ID, ClassMain.Add) = False Then Me.ShowErrMsg("没有权限添加!", True) : Exit Sub
            TB_ID.Text = "" 'Dao.Room_GetNewID()
            RoomID = 0
            Cmd_Del.Visible = False
        End If
        Me_Refresh()
    End Sub

    Protected Sub Me_Refresh()
        Dim msg As DtReturnMsg = Dao.Room_GetById(RoomID)
        If msg.IsOk Then
            dtRoom = msg.Dt
            SetForm(msg.Dt)
        End If
    End Sub

#Region "表单信息"
    ''' <summary>
    ''' 获取表单内容
    ''' </summary>
    ''' <remarks></remarks>
    Protected Function GetForm() As DataTable
        Dim dt As DataTable
        dt = dtRoom.Clone
        If Not dt Is Nothing Then
            dt.Clear()
            Dim dr As DataRow = dt.NewRow
            If Mode <> Mode_Enum.Add Then dr("ID") = RoomID
            dr("Room_No") = TB_ID.Text
            dr("Room_Name") = TB_Name.Text
            dr("Room_Buiding") = CB_Room_Buiding.Text
            dr("Room_Floor") = Cb_Room_Floor.Text
            dr("Room_Note") = TB_Room_Note.Text
            dt.Rows.Add(dr)
        End If
        Return dt
    End Function

    ''' <summary>
    ''' 设置表单内容
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub SetForm(ByVal dt As DataTable)
        If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
            TB_ID.Text = IsNull(dt.Rows(0)("Room_No"), "")
            TB_Name.Text = IsNull(dt.Rows(0)("Room_Name"), "")
            TB_Name.Text = IsNull(dt.Rows(0)("Room_Buiding"), "")
            TB_Name.Text = IsNull(dt.Rows(0)("Room_Floor"), "")
            TB_Room_Note.Text = IsNull(dt.Rows(0)("Room_Note"), "")


        End If

    End Sub

#End Region


#Region "工具栏按钮"
    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub

    Private Sub Cmd_Modify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Modify.Click

        If CheckForm() Then ShowConfirm("是否保存宿舍 [" & TB_Name.Text & "] 的修改?", AddressOf SaveRoom)
    End Sub

    Protected Sub SaveRoom()
        Dim R As MsgReturn
        If Me.Mode = Mode_Enum.Add Then
            R = Dao.Room_Add(GetForm())
        Else
            R = Dao.Room_Save(GetForm())
        End If
        If R.IsOk Then
            LastForm.ReturnId = TB_ID.Text
            Me.Close()
        Else
            ShowErrMsg(R.Msg)
        End If
    End Sub
    Protected Function CheckForm() As Boolean
        If TB_ID.Text = "" Then
            ShowMsg("宿舍编号不能为空", "")
            Return False
        End If

        If TB_Name.Text = "" Then
            ShowMsg("宿舍名称不能为空", "")
            Return False
        End If
        'Try


        '    Integer.Parse(TB_Grade.Text)
        'Catch ex As Exception
        '    ShowMsg("等级必须为整数", Me.Title)
        '    Return False
        'End Try


        Return True
    End Function


    Private Sub Cmd_Del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Del.Click
        ShowConfirm("是否删除宿舍 [" & TB_Name.Text & "]?", AddressOf DelRoom)
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub DelRoom()
        Dim msg As MsgReturn = Dao.Room_Del(RoomID)
        If msg.IsOk Then
            LastForm.ReturnId = "0"
            Me.Close()
        Else
            ShowErrMsg(msg.Msg)
        End If
    End Sub
#End Region

#Region "双击获取新编号"
    Private Sub Label_ID_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label_ID.MouseDoubleClick
        If Mode = Mode_Enum.Add Then
            TB_ID.Text = "" ' Dao.Room_GetNewID()
            TB_Name.Focus()
        End If
    End Sub
#End Region


End Class


Partial Class Dao
#Region "SQL"
    Public Const SQL_Room_NameCheckDuplicate = "select count(*) from T15004_Room where Room_No=@Room_No and id<>@id"

    Public Const SQL_Room_GetAllRoom As String = "select * from T15004_Room  order by Room_Buiding,Room_Floor, Room_No"

    Public Const SQL_Room_GetByid As String = "select top 1 * from T15004_Room where ID=@ID"
    Public Const SQL_Room_GetByNo As String = "select top 1 * from T15004_Room where Room_No=@Room_No"

    Public Const SQL_Room_DelByid As String = "Delete from  T15004_Room where ID=@ID "

    Public Const SQL_Room_SelRoomNo As String = "select Room_No from T15004_Room  order by Room_Buiding,Room_Floor, Room_No"
#End Region
#Region "宿舍"


    ''' <summary>
    ''' 获取对应宿舍信息
    ''' </summary>
    ''' <param name="id"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Room_GetById(ByVal id As String) As DtReturnMsg
        Dim p As New Dictionary(Of String, Object)
        p.Add("ID", id)
        Dim sql As New StringBuilder
        sql.Append(SQL_Room_GetByid)

        Return PClass.PClass.SqlStrToDt(sql.ToString, p)
    End Function

    ''' <summary>
    ''' 获取所有宿舍
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Room_GetAll() As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_Room_GetAllRoom)
    End Function

    ''' <summary>
    ''' 获取所有宿舍编号
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Room_GetRoomNo() As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_Room_SelRoomNo)
    End Function

    '生成新的宿舍ID
    'Public Shared Function Room_GetNewID() As String
    '    Dim paraMap As New Dictionary(Of String, Object)
    '    paraMap.Add("@DB_Str", "T15004_Room")
    '    paraMap.Add("@Id_Str", "J")
    '    paraMap.Add("@Field", "Room_No")
    '    paraMap.Add("@Zero", "3")
    '    Dim msgID As MsgReturn = SqlStrToOneStr("GetTableID_NoDate", paraMap, True)
    '    If msgID.IsOk Then
    '        Return msgID.Msg
    '    Else
    '        Return ""
    '    End If
    'End Function

    ''' <summary>
    ''' 增加一个宿舍
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Room_Add(ByVal dt As DataTable) As MsgReturn
        Dim Cnn As New SqlClient.SqlConnection
        Dim Da As New SqlClient.SqlDataAdapter
        Dim Room_No As String = ""

        Dim returnMsg As New MsgReturn
        If dt.Rows.Count <> 1 Then
            returnMsg.IsOk = False
            returnMsg.Msg = "新增宿舍失败!"
            Return returnMsg
        End If
        Room_No = dt.Rows(0)("Room_No")
        Try
            Dim msg As DtReturnMsg = SqlStrToDt(SQL_Room_GetByNo, Cnn, Da, "@Room_No", Room_No)
            If msg.IsOk AndAlso msg.Dt.Rows.Count = 0 Then
                DvToDt(dt, msg.Dt, New List(Of String), True)
                DtToUpDate(msg.Dt, Cnn, Da)
                returnMsg.IsOk = True
                returnMsg.Msg = "宿舍[" & dt.Rows(0)("Room_Name") & "]添加成功!"
            Else
                returnMsg.IsOk = False
                returnMsg.Msg = "宿舍编号[" & dt.Rows(0)("Room_No") & "已经存在!"
            End If
        Catch ex As Exception
            DebugToLog(ex)
            returnMsg.IsOk = False
            returnMsg.Msg = "新增宿舍失败!"
        Finally
            Da.Dispose()
            Cnn.Dispose()
        End Try
        Return returnMsg
    End Function
    ''' <summary>
    ''' 修改宿舍信息
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Room_Save(ByVal dt As DataTable) As MsgReturn
        Dim Cnn As New SqlClient.SqlConnection
        Dim Da As New SqlClient.SqlDataAdapter
        Dim returnMsg As New MsgReturn
        If dt.Rows.Count <> 1 Then
            returnMsg.IsOk = False
            returnMsg.Msg = "修改位失败!"
            Return returnMsg
        End If
        Dim RoomId As String = dt.Rows(0)("ID")
        If Room_NameCheckDuplicate(dt.Rows(0)("Room_No"), RoomId) Then
            returnMsg.Msg = "宿舍编号[" & dt.Rows(0)("Room_No") & "]已存在!"
            Return returnMsg
        End If
        Try
            Dim msg As DtReturnMsg = SqlStrToDt(SQL_Room_GetByid, Cnn, Da, "ID", RoomId)
            If msg.IsOk AndAlso msg.Dt.Rows.Count = 1 Then
                DvUpdateToDt(dt, msg.Dt, New List(Of String))
                DtToUpDate(msg.Dt, Cnn, Da)
                returnMsg.IsOk = True
            Else
                returnMsg.IsOk = False
                returnMsg.Msg = "宿舍编号[" & dt.Rows(0)("Room_No") & "]不存在"
            End If

        Catch ex As Exception
            DebugToLog(ex)
            returnMsg.IsOk = False
            returnMsg.Msg = "宿舍编号[" & dt.Rows(0)("Room_No") & "]修改错误"
        Finally
            Da.Dispose()
            Cnn.Dispose()
        End Try
        Return returnMsg
    End Function

    ''' <summary>
    ''' 检查布类编号的是否重复
    ''' </summary>
    ''' <param name="Room_No"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Room_NameCheckDuplicate(ByVal Room_No As String, ByVal ID As Integer) As Boolean
        Dim P As New Dictionary(Of String, Object)
        P.Add("Room_No", Room_No)
        P.Add("ID", ID)
        Dim r As MsgReturn = SqlStrToOneStr(SQL_Room_NameCheckDuplicate, P)
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
    ''' 
    ''' </summary>
    ''' <param name="RoomId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Room_Del(ByVal RoomId As String)
        Return RunSQL(SQL_Room_DelByid, "@ID", RoomId)
    End Function
#End Region
End Class