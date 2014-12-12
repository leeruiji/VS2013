Imports PClass.PClass
Imports System.Data
Imports System.Text
Module Module_Dao
#Region "应机具"


    ''' <summary>
    ''' 获取对应机具信息
    ''' </summary>
    ''' <param name="sId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function At_GetById(ByVal sId As String) As DtReturnMsg

        Return PClass.PClass.SqlStrToDt(SQL_At_GetAtByid, "@At_ID", sId)
    End Function

    ''' <summary>
    ''' 获取所有机具
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function At_GetAll() As DtReturnMsg
        ' Dim sql As String = "select * from T_At J left join T15000_Department D on D.Dept_No=J.At_dept order by At_ID"
        Return PClass.PClass.SqlStrToDt(SQL_At_GetAllAt)
    End Function



    ''' <summary>
    ''' 添加机具
    ''' </summary>
    ''' <param name="dtSource"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function At_Add(ByVal dtSource As DataTable) As MsgReturn
        Dim Cnn As New SqlClient.SqlConnection
        Dim Da As New SqlClient.SqlDataAdapter
        Dim dt As DataTable
        Dim msg As New MsgReturn
        Dim sql As String
        Dim AtId As String = dtSource.Rows(0)("At_ID")
        Try

            sql = SQL_At_SelAtByid
            dt = SqlStrToDt(sql, Cnn, Da, "At_ID", AtId).Dt
            If dt.Rows.Count = 0 Then
                DvToDt(dtSource, dt, New List(Of String), True)
                DtToUpDate(dt, Cnn, Da)
                msg.IsOk = True
            Else
                msg.IsOk = False
                msg.Msg = "机具" & dtSource.Rows(0)("At_Name") & "已经存在"
            End If

            Return msg
        Catch ex As Exception
            msg.IsOk = False
            msg.Msg = "机具" & dtSource.Rows(0)("At_Name") & "添加错误"
            DebugToLog(ex)
            Return msg
        Finally
            Da.Dispose()
            Cnn.Dispose()
        End Try

    End Function

    ''' <summary>
    ''' 修改机具信息
    ''' </summary>
    ''' <param name="dtSource"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function At_Save(ByVal dtSource As DataTable) As MsgReturn

        Dim Cnn As New SqlClient.SqlConnection
        Dim Da As New SqlClient.SqlDataAdapter
        Dim dt As DataTable
        Dim msg As New MsgReturn
        Dim sql As String
        Dim AtId As String = dtSource.Rows(0)("At_ID")
        Try

            sql = SQL_At_SelAtByid
            dt = SqlStrToDt(sql, Cnn, Da, "At_ID", AtId).Dt
            If dt.Rows.Count = 1 Then
                DvUpdateToDt(dtSource, dt, New List(Of String))
                DtToUpDate(dt, Cnn, Da)
                msg.IsOk = True
            Else
                msg.IsOk = False
                msg.Msg = "机具" & dtSource.Rows(0)("At_Name") & "不存在"
            End If

            Return msg
        Catch ex As Exception
            msg.IsOk = False
            msg.Msg = "机具" & dtSource.Rows(0)("At_Name") & "修改错误"
            DebugToLog(ex)
            Return msg
        Finally
            Da.Dispose()
            Cnn.Dispose()
        End Try
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="AtId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function At_Del(ByVal AtId As String) As MsgReturn
        Return RunSQL(SQL_At_DelAtByid, "@At_ID", AtId)
    End Function

#End Region


End Module
