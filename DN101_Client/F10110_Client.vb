Imports PClass.PClass
Imports System.Data
Imports System.Text
Public Class F10110_Client
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
        DP_Start.Value = New Date(Today.Year, Today.Month, 1)
        DP_End.Value = Today
        Me_Refresh()
    End Sub

    Protected Sub Me_Refresh()
        Dim startDate As Date
        Dim endDate As Date
        If DP_Start.Checked = False Then
            startDate = New Date(1999, 1, 1)
        Else
            startDate = DP_Start.Value.Date
        End If
        If DP_End.Checked = False Then
            endDate = New Date(2099, 1, 1)
        Else
            endDate = DP_End.Value.Date
        End If
        Dim msg As DtReturnMsg = Dao.Client_SumGH(startDate, endDate)
        If msg.IsOk Then
            FG1.DtToFG(msg.Dt)
            FG1.SortByLastOrder()
            FG1.RowSetForce("Client_No", ReturnId)
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
        Dim F As New F10111_Client_Msg("")
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
       ModifyClient
    End Sub

    ''' <summary>
    ''' 双击行.进入修改页面
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FG1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FG1.DoubleClick
        If Me.IsSel Then
            ReturnClient()
        Else
            ModifyClient()
        End If
    End Sub

    Protected Sub ReturnClient()
        Me.LastForm.ReturnId = FG1.SelectItem("ID")
        Me.LastForm.ReturnObj = FG1.SelectItem
        Me.Close()
    End Sub

    Sub ModifyClient()
        If FG1.RowSel < 0 Then
            ShowErrMsg("请选择一个要修改的客户")
            Exit Sub
        End If
        Dim F As New F10111_Client_Msg(FG1.SelectItem("ID"))
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
            ShowErrMsg("请选择一个要修改的客户")
            Exit Sub
        End If
        ShowConfirm("是否删除客户 [" & FG1.SelectItem("Client_Name") & "]?", AddressOf DelClient)
    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub DelClient()
        Dim msg As MsgReturn = Dao.Client_Del(FG1.SelectItem("ID"))
        If msg.IsOk Then
            Me_Refresh()
        Else
            ShowErrMsg("客户[" & FG1.SelectItem("Client_Name") & "]删除错误！")
        End If
    End Sub

    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub
#End Region



    Private Sub Btn_Search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Search.Click
        Me_Refresh()
    End Sub
End Class


Partial Friend Class Dao

#Region "客户信息"
    Private Const SQL_Client_NameCheckDuplicate = "select count(*) from T10110_Client where Client_No=@Client_No and id<>@id"
    Private Const SQL_Client_NoCheckDuplicate = "select count(*) from T10110_Client where Client_Name=@Client_Name "
    Private Const SQL_Client_GetAllClient As String = "select * from T10110_Client order by Client_No"
    Private Const SQL_Client_GetAllClient_SumGH As String = "select * ,(select count(*) from T30000_Produce_Gd where state>=0 and   Client_ID=ID and Date_KaiDan between @StartDate and @EndDate   )as SumGH from T10110_Client order by Client_No"
    Private Const SQL_Client_SetByid As String = "select top 1 S.*,U.User_Name,U1.User_Name as FounderName from T10110_Client S left join User_Info U on S.UPD_USER=U.User_ID  left join User_Info U1 on S.Founder=U.User_ID  where ID=@ID"
    Private Const SQL_Client_GetByid As String = "select top 1 * from T10110_Client  where ID=@Client_ID"
    Private Const SQL_Client_GetByNo As String = "select top 1 * from T10110_Client  where Client_No=@Client_No"
    Private Const SQL_Client_DelByid As String = "Delete from  T10110_Client where ID=@ID "
    Private Const SQL_Client_GetAutoID As String = "declare @i int" & vbCrLf & _
                                            "select @i=count(*) from T10110_Client where Client_No=@Client_No" & vbCrLf & _
                                            "if @i>0" & vbCrLf & _
                                            "set @i=0" & vbCrLf & _
                                            "else" & vbCrLf & _
                                            "begin" & vbCrLf & _
                                            "insert into T10110_Client (Client_No,Client_Name)Values(@Client_No,@Client_Name)" & vbCrLf & _
                                            "set @i=@@identity " & vbCrLf & _
                                            "end" & vbCrLf & _
                                            "select @i"

    Private Const SQL_Client_Link_Bz_GetByID_Save As String = "select * from T10111_ClientLinkBZ where Client_ID=@Client_ID"
    Private Const SQL_Client_Link_Bz_GetByID As String = "select C.*,b.Bz_No,b.Bz_Name from T10111_ClientLinkBZ C left join T10002_BZ B on b.ID=c.BZ_ID where Client_ID=@Client_ID  "


#End Region
#Region "客户"


    ''' <summary>
    ''' 获取对应供应商信息
    ''' </summary>
    ''' <param name="sId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Client_GetById(ByVal sId As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_Client_SetByid, "@ID", sId)
    End Function

    ''' <summary>
    ''' 获取所有供应商
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Client_GetAll() As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_Client_GetAllClient)
    End Function





    ''' <summary>
    ''' 增加一个客户
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Client_Add(ByVal Dt_Client As DataTable, ByVal Dt_Bz_Link As DataTable) As MsgReturn
        Dim msg As New DtListReturnMsg
        Dim sqlMap As New Dictionary(Of String, String)
        Dim paraMap As New Dictionary(Of String, Object)
        Dim Client_Name As String = ""
        Dim returnMsg As New MsgReturn
        If Dt_Client.Rows.Count <> 1 Then
            returnMsg.IsOk = False
            returnMsg.Msg = "新增客户失败!"
            Return returnMsg
        End If
        Client_Name = Dt_Client.Rows(0)("Client_Name")
        If Client_NoCheckDuplicate(Dt_Client.Rows(0)("Client_Name"), Client_Name) Then
            returnMsg.Msg = "客户名称[" & Dt_Client.Rows(0)("Client_Name") & "]已存在!"
            Return returnMsg
        End If
        paraMap.Add("@Client_No", Dt_Client.Rows(0)("Client_No"))
        paraMap.Add("@Client_Name", Dt_Client.Rows(0)("Client_Name"))
        Dim V As MsgReturn = SqlStrToOneStr(SQL_Client_GetAutoID, paraMap)
        If V.IsOk = False Then
            V.Msg = "添加客户失败!" & V.Msg
            Return V
        Else
            If Val(V.Msg) = 0 Then
                V.IsOk = False
                V.Msg = "色号[" & Dt_Client.Rows(0)("Client_No") & "]已经存在!"
                Return V
            End If
        End If

        Dim ID As Integer = Val(V.Msg)
        paraMap.Clear()
        paraMap.Add("@Client_ID", ID)
        sqlMap.Add("Client", SQL_Client_GetByid)
        sqlMap.Add("Bz_Link", SQL_Client_Link_Bz_GetByID_Save)

        msg = SqlStrToDt(sqlMap, paraMap)
        If msg.IsOk Then
            If msg.DtList("Client").Rows.Count = 1 Then
                Dim HL As New List(Of String)
                HL.Add("ID")
                DvUpdateToDt(Dt_Client, msg.DtList("Client"), HL)
                If Dt_Bz_Link IsNot Nothing Then
                    For Each R As DataRow In Dt_Bz_Link.Rows
                        R.Item("Client_ID") = ID
                    Next
                End If
               

                DvToDt(Dt_Bz_Link, msg.DtList("Bz_Link"), New List(Of String))
                Try
                    DtToUpDate(msg)
                    returnMsg.IsOk = True
                    returnMsg.Msg = "客户[" & Dt_Client.Rows(0)("Client_Name") & "]添加成功!"
                Catch ex As Exception
                    Client_Del(ID)
                    returnMsg.IsOk = False
                    returnMsg.Msg = "添加客户失败!"
                End Try

            Else
                returnMsg.IsOk = False
                returnMsg.Msg = "添加客户失败!"
            End If
        Else
            Client_Del(ID)
            returnMsg.IsOk = False
            returnMsg.Msg = "添加客户失败!"
        End If
        Return returnMsg
    End Function




    ''' <summary>
    '''修改一个客户
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Client_Save(ByVal Dt_Client As DataTable, ByVal Dt_Bz_Link As DataTable) As MsgReturn
        Dim msg As New DtListReturnMsg
        Dim returnMsg As New MsgReturn
        Dim sqlMap As New Dictionary(Of String, String)
        Dim paraMap As New Dictionary(Of String, Object)
        Dim gId As String = ""
        If Dt_Client.Rows.Count <> 1 Then
            returnMsg.IsOk = False
            returnMsg.Msg = "修改客户失败!"
            Return returnMsg
        End If
        gId = Dt_Client.Rows(0)("ID")
        If Client_NameCheckDuplicate(Dt_Client.Rows(0)("Client_No"), gId) Then
            returnMsg.Msg = "客户[" & Dt_Client.Rows(0)("Client_No") & "]已存在!"
            Return returnMsg
        End If
        paraMap.Add("@Client_ID", gId)
        sqlMap.Add("Client", SQL_Client_GetByid)
        sqlMap.Add("Bz_Link", SQL_Client_Link_Bz_GetByID_Save)
        msg = SqlStrToDt(sqlMap, paraMap)
        Try
            If msg.IsOk AndAlso msg.DtList("Client").Rows.Count > 0 Then
                DvUpdateToDt(Dt_Client, msg.DtList("Client"), New List(Of String))
                DvToDt(Dt_Bz_Link, msg.DtList("Bz_Link"), New List(Of String))
                DtToUpDate(msg)
                returnMsg.IsOk = True
                returnMsg.Msg = "客户[" & Dt_Client.Rows(0)("Client_Name") & "]修改成功!"
            Else
                returnMsg.IsOk = False
                returnMsg.Msg = "客户[" & Dt_Client.Rows(0)("Client_Name") & "]不已经存在!"
            End If
        Catch ex As Exception
            DebugToLog(ex)
            returnMsg.IsOk = False
            returnMsg.Msg = "修改客户分类失败!"
        End Try
        Return returnMsg
    End Function

    ''' <summary>
    ''' 检查客户编号的是否重复
    ''' </summary>
    ''' <param name="Client_No"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Client_NameCheckDuplicate(ByVal Client_No As String, ByVal ID As Integer) As Boolean
        Dim P As New Dictionary(Of String, Object)
        P.Add("Client_No", Client_No)
        P.Add("ID", ID)
        Dim r As MsgReturn = SqlStrToOneStr(SQL_Client_NameCheckDuplicate, P)
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
    ''' 检查客户名称的是否重复
    ''' </summary>
    ''' <param name="Client_Name"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Client_NoCheckDuplicate(ByVal Client_Name As String, ByVal ID As String) As Boolean
        Dim P As New Dictionary(Of String, Object)
        P.Add("Client_Name", Client_Name)
        Dim r As MsgReturn = SqlStrToOneStr(SQL_Client_NoCheckDuplicate, P)
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
    ''' 生成新的客户ID 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Client_GetNewID() As String
        Dim paraMap As New Dictionary(Of String, Object)
        paraMap.Add("@DB_Str", "T10110_Client")
        paraMap.Add("@Id_Str", "C")
        paraMap.Add("@Field", "Client_No")
        paraMap.Add("@Zero", "3")
        Dim msgID As MsgReturn = SqlStrToOneStr("GetTableID_NoDate", paraMap, True)
        If msgID.IsOk Then
            Return msgID.Msg
        Else
            Return ""
        End If
    End Function


    ''' <summary>
    ''' 删除客户
    ''' </summary>
    ''' <param name="Id"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Client_Del(ByVal Id As String) As MsgReturn
        Return RunSQL(SQL_Client_DelByid, "@ID", Id)
    End Function


    ''' <summary>
    ''' 获取客户布种列表
    ''' </summary>
    ''' <param name="sId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Client_Bz_Link_GetById(ByVal sId As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_Client_Link_Bz_GetByID, "@Client_ID", sId)
    End Function



    ''' <summary>
    ''' 获取客户布种列表
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Client_SumGH(ByVal StartDate As Date, ByVal Enddate As Date) As DtReturnMsg


        Dim p As New Dictionary(Of String, Object)

        p.Add("StartDate", StartDate)
        p.Add("EndDate", Enddate)
        Return PClass.PClass.SqlStrToDt(SQL_Client_GetAllClient_SumGH, p)
    End Function
#End Region
End Class