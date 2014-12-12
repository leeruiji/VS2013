Imports PClass.PClass
Imports System.Data
Imports System.Text
Public Class F10007_WL_Name
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
        Dim msg As DtReturnMsg = Dao.WL_Name_GetAll()
        If msg.IsOk Then
            FG1.DtToFG(msg.Dt)
            FG1.SortByLastOrder()
            FG1.RowSetForce("Supplier_No", ReturnId)
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
        Dim F As New F10008_WL_Name_Msg("")
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
        ModifyWL_Name()
    End Sub

    ''' <summary>
    ''' 双击行.进入修改页面
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FG1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FG1.DoubleClick
        If Me.IsSel Then
            ReturnWL_Name()
        Else
            ModifyWL_Name()
        End If
    End Sub

    Protected Sub ReturnWL_Name()
        Me.LastForm.ReturnId = FG1.SelectItem("ID")
        Me.LastForm.ReturnObj = FG1.SelectItem
        Me.Close()
    End Sub

    Sub ModifyWL_Name()
        If FG1.RowSel < 0 Then
            ShowErrMsg("请选择一个要修改的物料名称")
            Exit Sub
        End If
        Dim F As New F10008_WL_Name_Msg(FG1.SelectItem("ID"))
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
            ShowErrMsg("请选择一个要修改的物料名称")
            Exit Sub
        End If
        ShowConfirm("是否删除物料名称 [" & FG1.SelectItem("WL_Name") & "]?", AddressOf DelWL_Name)
    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub DelWL_Name()
        Dim msg As MsgReturn = Dao.WL_Name_Del(FG1.SelectItem("ID"))
        If msg.IsOk Then
            Me_Refresh()
        Else
            ShowErrMsg("物料名称[" & FG1.SelectItem("WL_Name") & "]删除错误！")
        End If
    End Sub

    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub
#End Region



End Class

Partial Friend Class Dao
#Region "供应商"
    '===================供应商信息==============
    Private Const SQL_WL_NameCheckDuplicate = "select count(*) from T10007_WL_Name where WL_Name_No=@WL_Name_No and id<>@id"

    Private Const SQL_WL_Name_GetAll As String = "select * from T10007_WL_Name order by WL_Name_No"

    Private Const SQL_WL_Name_SetByid As String = "select top 1 * from T10007_WL_Name where ID=@ID"

    Private Const SQL_WL_Name_GetByNo As String = "select top 1 * from T10007_WL_Name  where WL_Name_No=@WL_Name_No"

    Private Const SQL_WL_Name_DelByid As String = "Delete from  T10007_WL_Name where ID=@ID "
#End Region


#Region "物料名称"


    ''' <summary>
    ''' 获取对应物料名称信息
    ''' </summary>
    ''' <param name="sId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function WL_Name_GetById(ByVal sId As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_WL_Name_SetByid, "@ID", sId)
    End Function

    ''' <summary>
    ''' 获取所有物料名称
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function WL_Name_GetAll() As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_WL_Name_GetAll)
    End Function





    ''' <summary>
    ''' 增加一个供应商
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function WL_Name_Add(ByVal dt As DataTable) As MsgReturn
        Dim Cnn As New SqlClient.SqlConnection
        Dim Da As New SqlClient.SqlDataAdapter
        Dim WL_Name_No As String = ""

        Dim returnMsg As New MsgReturn
        If dt.Rows.Count <> 1 Then
            returnMsg.IsOk = False
            returnMsg.Msg = "新增物料名称失败!"
            Return returnMsg
        End If
        WL_Name_No = dt.Rows(0)("WL_Name_No")
        Try
            Dim msg As DtReturnMsg = SqlStrToDt(SQL_WL_Name_GetByNo, Cnn, Da, "@WL_Name_No", WL_Name_No)
            If msg.IsOk AndAlso msg.Dt.Rows.Count = 0 Then
                DvToDt(dt, msg.Dt, New List(Of String), True)
                DtToUpDate(msg.Dt, Cnn, Da)
                returnMsg.IsOk = True
                returnMsg.Msg = "物料名称[" & dt.Rows(0)("WL_Name") & "]添加成功!"
            Else
                returnMsg.IsOk = False
                returnMsg.Msg = "物料名称编号[" & dt.Rows(0)("WL_Name_No") & "已经存在!"
            End If
        Catch ex As Exception
            DebugToLog(ex)
            returnMsg.IsOk = False
            returnMsg.Msg = "新增物料名称失败!"
        Finally
            Da.Dispose()
            Cnn.Dispose()
        End Try
        Return returnMsg
    End Function



    ''' <summary>
    '''修改一个物料名称
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function WL_Name_Save(ByVal dt As DataTable) As MsgReturn
        Dim Cnn As New SqlClient.SqlConnection
        Dim Da As New SqlClient.SqlDataAdapter
        Dim gId As String = ""
        Dim returnMsg As New MsgReturn
        If dt.Rows.Count <> 1 Then
            returnMsg.IsOk = False
            returnMsg.Msg = "修改物料名称失败!"
            Return returnMsg
        End If
        gId = dt.Rows(0)("ID")
        If WL_NameCheckDuplicate(dt.Rows(0)("WL_Name_No"), gId) Then
            returnMsg.Msg = "物料名称编号[" & dt.Rows(0)("Wl_Name_No") & "]已存在!"
            Return returnMsg
        End If
        Try
            Dim msg As DtReturnMsg = SqlStrToDt(SQL_WL_Name_SetByid, Cnn, Da, "@ID", gId)
            If msg.IsOk AndAlso msg.Dt.Rows.Count = 1 Then
                DvUpdateToDt(dt, msg.Dt, New List(Of String))
                DtToUpDate(msg.Dt, Cnn, Da)
                returnMsg.IsOk = True
                returnMsg.Msg = "供应商[" & dt.Rows(0)("WL_Name") & "]保存成功!"
            Else
                returnMsg.IsOk = False
                returnMsg.Msg = "供应商[" & dt.Rows(0)("WL_Name") & "]不存在!"
            End If
        Catch ex As Exception
            DebugToLog(ex)
            returnMsg.IsOk = False
            returnMsg.Msg = "修改供应商失败!"
        Finally
            Da.Dispose()
            Cnn.Dispose()
        End Try
        Return returnMsg
    End Function

    ''' <summary>
    ''' 检查物料名称编号的是否重复
    ''' </summary>
    ''' <param name="Supplier_No"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function WL_NameCheckDuplicate(ByVal WL_Name_No As String, ByVal ID As Integer) As Boolean
        Dim P As New Dictionary(Of String, Object)
        P.Add("WL_Name_No", WL_Name_No)
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
    ''' 生成新的物料名称ID 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function WL_Name_GetNewID() As String
        Dim paraMap As New Dictionary(Of String, Object)
        paraMap.Add("@DB_Str", "T10007_WL_Name")
        paraMap.Add("@Id_Str", "WN")
        paraMap.Add("@Field", "WL_Name_No")
        paraMap.Add("@Zero", "3")
        Dim msgID As MsgReturn = SqlStrToOneStr("GetTableID_NoDate", paraMap, True)
        If msgID.IsOk Then
            Return msgID.Msg
        Else
            Return ""
        End If
    End Function


    ''' <summary>
    ''' 删除物料名称
    ''' </summary>
    ''' <param name="Id"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function WL_Name_Del(ByVal Id As String) As MsgReturn
        Return RunSQL(SQL_WL_Name_DelByid, "@ID", Id)
    End Function

#End Region
End Class