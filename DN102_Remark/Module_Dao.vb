Imports BaseClass
Imports PClass.PClass
Imports System.Data
Imports System.Text

Module Module_Dao
#Region "备注"

    ''' <summary>
    ''' 获取所有备注信息
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Remark_GetAll() As DtReturnMsg

        Return PClass.PClass.SqlStrToDt(SQL_Remark_Get)
    End Function

    ''' <summary>
    ''' 获取查询条件集合
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Remark_GetConditionNames() As List(Of FindOption)
        Dim foList As New List(Of FindOption)
        Dim fo As New FindOption
        fo.Field = "请选择"
        fo.DB_Field = ""
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "值"
        fo.DB_Field = "Remark"
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "备注"
        fo.DB_Field = "Remark2"
        foList.Add(fo)


        Return foList
    End Function

    ''' <summary>
    ''' 按条件获取备注信息
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Remark_GetByOption(ByVal oList As OptionList) As DtReturnMsg
        Dim paraMap As New Dictionary(Of String, Object)
        Dim sqlBuider As New StringBuilder
        sqlBuider.Append(SQL_Remark_Get)
        sqlBuider.Append("  WHERE 1=1  ")
        sqlBuider.Append(BaseClass.OptionClass.OptionClass_BuidSqlConditon(oList.FoList, paraMap))
        sqlBuider.Append(SQL_Remark_OrderBy)
        Return PClass.PClass.SqlStrToDt(sqlBuider.ToString, paraMap)
    End Function

    ''' <summary>
    ''' 获取备注信息
    ''' </summary>
    ''' <param name="sId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Remark_GetById(ByVal sId As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_Remark_GetByID, "@Remark_ID", sId)
    End Function


  

    ''' <summary>
    ''' 增加一个备注
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Remark_Add(ByVal dt As DataTable) As MsgReturn
        Dim Cnn As New SqlClient.SqlConnection
        Dim Da As New SqlClient.SqlDataAdapter
        Dim gId As String = ""
        Dim sql As String
        Dim returnMsg As New MsgReturn
        sql = SQL_Remark_GetByID
        If dt.Rows.Count <> 1 Then
            returnMsg.IsOk = False
            returnMsg.Msg = "新增备注失败!"
            Return returnMsg
        End If
        gId = dt.Rows(0)("Remark_ID")
        Try
            Dim msg As DtReturnMsg = SqlStrToDt(sql, Cnn, Da, "@Remark_ID", gId)
            If msg.IsOk AndAlso msg.Dt.Rows.Count = 0 Then
                DvToDt(dt, msg.Dt, New List(Of String), True)
                DtToUpDate(msg.Dt, Cnn, Da)
                returnMsg.IsOk = True
                returnMsg.Msg = "备注[" & dt.Rows(0)("Remark_ID") & "新增成功!"
            Else
                returnMsg.IsOk = False
                returnMsg.Msg = "备注[" & dt.Rows(0)("Remark_ID") & "已经存在!"
            End If
        Catch ex As Exception
            DebugToLog(ex)
            returnMsg.IsOk = False
            returnMsg.Msg = "新增备注分类失败!"
        Finally
            Da.Dispose()
            Cnn.Dispose()
        End Try
        Return returnMsg
    End Function



    ''' <summary>
    '''修改一个备注
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Remark_Save(ByVal dt As DataTable) As MsgReturn
        Dim Cnn As New SqlClient.SqlConnection
        Dim Da As New SqlClient.SqlDataAdapter
        Dim gId As String = ""
        Dim sql As String
        Dim returnMsg As New MsgReturn
        sql = SQL_Remark_GetByID

        If dt.Rows.Count <> 1 Then
            returnMsg.IsOk = False
            returnMsg.Msg = "修改备注失败!"
            Return returnMsg

        End If
        gId = dt.Rows(0)("Remark_ID")
        Try
            Dim msg As DtReturnMsg = SqlStrToDt(sql, Cnn, Da, "@Remark_ID", gId)
            If msg.IsOk AndAlso msg.Dt.Rows.Count = 1 Then

                DvUpdateToDt(dt, msg.Dt, New List(Of String))
                DtToUpDate(msg.Dt, Cnn, Da)
                returnMsg.IsOk = True
                returnMsg.Msg = "备注[" & dt.Rows(0)("Remark_ID") & "保存成功!"
            Else
                returnMsg.IsOk = False
                returnMsg.Msg = "备注[" & dt.Rows(0)("Remark_ID") & "不存在!"
            End If


        Catch ex As Exception
            DebugToLog(ex)
            returnMsg.IsOk = False
            returnMsg.Msg = "修改备注失败!"
        Finally
            Da.Dispose()
            Cnn.Dispose()
        End Try
        Return returnMsg
    End Function



    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="BZId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Remark_Del(ByVal BZId As String)
        Return RunSQL(SQL_Remark_DelByid, "@Remark_ID", BZId)
    End Function

    ''' <summary>
    ''' 生成新的分类ID 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Remark_GetNewID() As String
        Dim paraMap As New Dictionary(Of String, Object)
        paraMap.Add("@DB_Str", "T10200_Remark")
        paraMap.Add("@Id_Str", "RK")
        paraMap.Add("@Field", "Remark_ID")
        paraMap.Add("@Zero", "4")
        Dim msgID As MsgReturn = SqlStrToOneStr("GetTableID_NoDate", paraMap, True)
        If msgID.IsOk Then
            Return msgID.Msg
        Else
            Return ""
        End If
    End Function


#End Region
End Module
