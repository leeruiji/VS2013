Imports PClass.PClass
Imports System.Data
Imports System.Text
Public Class F10130_JGDW
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
        Dim msg As DtReturnMsg = Dao.GetAll()
        If msg.IsOk Then
            FG1.DtToFG(msg.Dt)
            FG1.SortByLastOrder()
            FG1.RowSetForce("JGDW_No", ReturnId)
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
        Dim F As New F10131_JGDW_Msg("")
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
        ModifyJGDW()
    End Sub

    ''' <summary>
    ''' 双击行.进入修改页面
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FG1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FG1.DoubleClick
        If Me.IsSel Then
            ReturnJGDW()
        Else
            ModifyJGDW()
        End If
    End Sub

    Protected Sub ReturnJGDW()
        Me.LastForm.ReturnId = FG1.SelectItem("ID")
        Me.LastForm.ReturnObj = FG1.SelectItem
        Me.Close()
    End Sub

    Sub ModifyJGDW()
        If FG1.RowSel < 0 Then
            ShowErrMsg("请选择一个要修改的加工单位")
            Exit Sub
        End If
        Dim F As New F10131_JGDW_Msg(FG1.SelectItem("ID"))
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
            ShowErrMsg("请选择一个要修改的加工单位")
            Exit Sub
        End If
        ShowConfirm("是否删除加工单位 [" & FG1.SelectItem("JGDW_Name") & "]?", AddressOf DelJGDW)
    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub DelJGDW()
        Dim msg As MsgReturn = Dao.JGDW_Del(FG1.SelectItem("ID"))
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



End Class

Partial Friend Class Dao
#Region "加工单位"
    '===================加工单位信息==============
    Private Const SQL_JGDW_NameCheckDuplicate = "select count(*) from T10130_JGDW where  JGDW_No=@JGDW_No and id<>@id"

    Private Const SQL_JGDW_GetAll As String = "select * from T10130_JGDW order by  JGDW_No"

    Private Const SQL_JGDW_SetByid As String = "select top 1 S.*,U.User_Name,U1.User_Name as FounderName from T10130_JGDW S left join User_Info U on S.UPD_USER=U.User_ID  left join User_Info U1 on S.Founder=U.User_ID  where ID=@ID"

    Private Const SQL_JGDW_GetByid As String = "select top 1 * from T10130_JGDW  where ID=@ID"

    Private Const SQL_JGDW_GetByNo As String = "select top 1 * from T10130_JGDW  where  JGDW_No=@JGDW_No"

    Private Const SQL_JGDW_DelByid As String = "Delete from  T10130_JGDW where ID=@ID "
#End Region


#Region "加工单位"


    ''' <summary>
    ''' 获取对应加工单位信息
    ''' </summary>
    ''' <param name="sId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function JGDW_GetById(ByVal sId As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_JGDW_SetByid, "@ID", sId)
    End Function

    ''' <summary>
    ''' 获取所有加工单位
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetAll() As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_JGDW_GetAll)
    End Function





    ''' <summary>
    ''' 增加一个加工单位
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function JGDW_Add(ByVal dt As DataTable) As MsgReturn
        Dim Cnn As New SqlClient.SqlConnection
        Dim Da As New SqlClient.SqlDataAdapter
        Dim No As String = ""

        Dim returnMsg As New MsgReturn
        If dt.Rows.Count <> 1 Then
            returnMsg.IsOk = False
            returnMsg.Msg = "新增加工单位失败!"
            Return returnMsg
        End If
        No = dt.Rows(0)("JGDW_No")
        Try
            Dim msg As DtReturnMsg = SqlStrToDt(SQL_JGDW_GetByNo, Cnn, Da, "@JGDW_No", No)
            If msg.IsOk AndAlso msg.Dt.Rows.Count = 0 Then
                DvToDt(dt, msg.Dt, New List(Of String), True)
                DtToUpDate(msg.Dt, Cnn, Da)
                returnMsg.IsOk = True
                returnMsg.Msg = "加工单位[" & dt.Rows(0)("JGDW_Name") & "]添加成功!"
            Else
                returnMsg.IsOk = False
                returnMsg.Msg = "加工单位编号[" & dt.Rows(0)("JGDW_No") & "已经存在!"
            End If
        Catch ex As Exception
            DebugToLog(ex)
            returnMsg.IsOk = False
            returnMsg.Msg = "新增加工单位失败!"
        Finally
            Da.Dispose()
            Cnn.Dispose()
        End Try
        Return returnMsg
    End Function



    ''' <summary>
    '''修改一个加工单位
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function JGDW_Save(ByVal dt As DataTable) As MsgReturn
        Dim Cnn As New SqlClient.SqlConnection
        Dim Da As New SqlClient.SqlDataAdapter
        Dim gId As String = ""
        Dim returnMsg As New MsgReturn
        If dt.Rows.Count <> 1 Then
            returnMsg.IsOk = False
            returnMsg.Msg = "修改加工单位失败!"
            Return returnMsg
        End If
        gId = dt.Rows(0)("ID")
        If JGDW_NameCheckDuplicate(dt.Rows(0)("JGDW_No"), gId) Then
            returnMsg.Msg = "加工单位编号[" & dt.Rows(0)("JGDW_No") & "]已存在!"
            Return returnMsg
        End If
        Try
            Dim msg As DtReturnMsg = SqlStrToDt(SQL_JGDW_GetByid, Cnn, Da, "@ID", gId)
            If msg.IsOk AndAlso msg.Dt.Rows.Count = 1 Then
                DvUpdateToDt(dt, msg.Dt, New List(Of String))
                DtToUpDate(msg.Dt, Cnn, Da)
                returnMsg.IsOk = True
                returnMsg.Msg = "加工单位[" & dt.Rows(0)("JGDW_Name") & "]保存成功!"
            Else
                returnMsg.IsOk = False
                returnMsg.Msg = "加工单位[" & dt.Rows(0)(" JGDW_Name") & "]不存在!"
            End If
        Catch ex As Exception
            DebugToLog(ex)
            returnMsg.IsOk = False
            returnMsg.Msg = "修改加工单位失败!"
        Finally
            Da.Dispose()
            Cnn.Dispose()
        End Try
        Return returnMsg
    End Function

    ''' <summary>
    ''' 检查加工单位编号的是否重复
    ''' </summary>
    ''' <param name=" No"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function JGDW_NameCheckDuplicate(ByVal No As String, ByVal ID As Integer) As Boolean
        Dim P As New Dictionary(Of String, Object)
        P.Add("JGDW_No", No)
        P.Add("ID", ID)
        Dim r As MsgReturn = SqlStrToOneStr(SQL_JGDW_NameCheckDuplicate, P)
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
    ''' 生成新的加工单位ID 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function JGDW_GetNewID() As String
        Dim paraMap As New Dictionary(Of String, Object)
        paraMap.Add("@DB_Str", "T10130_JGDW")
        paraMap.Add("@Id_Str", "J")
        paraMap.Add("@Field", " JGDW_No")
        paraMap.Add("@Zero", "3")
        Dim msgID As MsgReturn = SqlStrToOneStr("GetTableID_NoDate", paraMap, True)
        If msgID.IsOk Then
            Return msgID.Msg
        Else
            Return ""
        End If
    End Function


    ''' <summary>
    ''' 删除加工单位
    ''' </summary>
    ''' <param name="Id"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function JGDW_Del(ByVal Id As String) As MsgReturn
        Return RunSQL(SQL_JGDW_DelByid, "@ID", Id)
    End Function

#End Region
End Class