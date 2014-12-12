Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports BaseClass.FindOption
Imports BaseClass.OptionClass
Imports BaseClass
Module Module_Dao
#Region "运转单"

    ''' <summary>
    ''' 获取所有运转单
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Produce_GetAll() As DtReturnMsg

        Return PClass.PClass.SqlStrToDt(SQL_Produce_Get_WithName)
    End Function



    ''' <summary>
    ''' 按条件获取运转单
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Produce_GetByOption(ByVal oList As OptionList) As DtReturnMsg
        Dim paraMap As New Dictionary(Of String, Object)
        Dim sqlBuider As New StringBuilder
        sqlBuider.Append(SQL_Produce_Get_WithName)
        sqlBuider.Append("  WHERE 1=1  ")
        sqlBuider.Append(OptionClass_BuidSqlConditon(oList.FoList, paraMap))
        sqlBuider.Append(SQL_Produce_OrderBy)
        Return PClass.PClass.SqlStrToDt(sqlBuider.ToString, paraMap)
    End Function

    ''' <summary>
    ''' 按条件获取运转单
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Produce_GetByOptionString(ByVal s As String) As DtReturnMsg
        Dim paraMap As New Dictionary(Of String, Object)
        Dim sqlBuider As New StringBuilder
        sqlBuider.Append(SQL_Produce_Get_WithName)
        sqlBuider.Append("  WHERE 1=1  ")
        sqlBuider.Append(s)
        sqlBuider.Append(SQL_Produce_OrderBy)
        Return PClass.PClass.SqlStrToDt(sqlBuider.ToString, paraMap)
    End Function

    ''' <summary>
    ''' 获取运转单信息
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Produce_GetEmptyRow() As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_Produce_GetEmptyRow)
    End Function


    ''' <summary>
    ''' 获取运转单信息
    ''' </summary>
    ''' <param name="sId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Produce_GetById(ByVal sId As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_Produce_GetByID_WithName, "@GH", sId)
    End Function


    ''' <summary>
    ''' 增加一个运转单
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Produce_Add(ByVal Dt_Produce As DataTable, ByVal Dt_BZ As DataTable) As MsgReturn
        Dim msg As New DtListReturnMsg
        Dim returnMsg As New MsgReturn
        Dim sqlMap As New Dictionary(Of String, String)
        Dim paraMap As New Dictionary(Of String, Object)
        If Dt_Produce.Rows.Count <> 1 Then '检查参数
            returnMsg.IsOk = False
            returnMsg.Msg = "添加运转单失败!"
            Return returnMsg
        End If
        paraMap.Add("@GH", Dt_Produce.Rows(0)("GH"))
        sqlMap.Add("Produce", SQL_Produce_GetByID)
        sqlMap.Add("BzList", SQL_Produce_GetBZList)
        msg = SqlStrToDt(sqlMap, paraMap)
        Try
            If msg.IsOk AndAlso msg.DtList("Produce").Rows.Count = 0 Then
                DvToDt(Dt_Produce, msg.DtList("Produce"), New List(Of String), False)
                DvToDt(Dt_BZ, msg.DtList("BzList"), New List(Of String))

                DtToUpDate(msg)
                returnMsg.IsOk = True
                returnMsg.Msg = "运转单[" & Dt_Produce.Rows(0)("GH") & "添加成功!"
            ElseIf msg.DtList("Produce").Rows.Count = 1 Then
                returnMsg.IsOk = False
                returnMsg.Msg = "运转单[" & Dt_Produce.Rows(0)("GH") & "]已经存在!,请双击编号文本框,获取新编号!"
            End If
        Catch ex As Exception
            DebugToLog(ex)
            returnMsg.IsOk = False
            returnMsg.Msg = "添加运转单失败!"
        End Try
        Return returnMsg
    End Function



    ''' <summary>
    '''修改一个运转单
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Produce_Save(ByVal Dt_Produce As DataTable, ByVal Dt_BZ As DataTable) As MsgReturn
        Dim msg As New DtListReturnMsg
        Dim returnMsg As New MsgReturn
        Dim sqlMap As New Dictionary(Of String, String)
        Dim paraMap As New Dictionary(Of String, Object)
        If Dt_Produce.Rows.Count <> 1 Then '检查参数
            returnMsg.IsOk = False
            returnMsg.Msg = "修改运转单失败!"
            Return returnMsg
        End If
        paraMap.Add("@GH", Dt_Produce.Rows(0)("GH"))
        sqlMap.Add("Produce", SQL_Produce_GetByID)
        sqlMap.Add("BzList", SQL_Produce_GetBZList)
        msg = SqlStrToDt(sqlMap, paraMap)
        Try
            If msg.IsOk AndAlso msg.DtList("Produce").Rows.Count > 0 Then
                DvUpdateToDt(Dt_Produce, msg.DtList("Produce"), New List(Of String))
                DvToDt(Dt_BZ, msg.DtList("BzList"), New List(Of String))

                DtToUpDate(msg)
                returnMsg.IsOk = True
                returnMsg.Msg = "运转单[" & Dt_Produce.Rows(0)("GH") & "修改成功!"
            Else
                returnMsg.IsOk = False
                returnMsg.Msg = "运转单[" & Dt_Produce.Rows(0)("GH") & "不已经存在!"
            End If
        Catch ex As Exception
            DebugToLog(ex)
            returnMsg.IsOk = False
            returnMsg.Msg = "修改运转单失败!"
        End Try
        Return returnMsg
    End Function




    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="BZId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Produce_Del(ByVal BZId As String)
        Return RunSQL(SQL_Produce_DelByid, "@GH", BZId)
    End Function



    ''' <summary>
    ''' 获取一个新ID
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Produce_GetNewID(ByVal D As Date) As RetrunNewIdMsg
        Dim R As New RetrunNewIdMsg
        R.MaxDate = Maxdate.AddDays(1)
        Try
            If D.Date <= Maxdate Then
                R.NewIdDate = Maxdate.AddDays(1)
                R.IsTheDate = False
                R.RetrunMsg = "你选择的日期小于或等于日结日期!"
            Else
                R.NewIdDate = D
                R.IsTheDate = True
                R.RetrunMsg = "获取运转单号成功!"
            End If
            Dim paraMap As New Dictionary(Of String, Object)
            paraMap.Add("@DB_Str", "T30000_Produce_Gd")
            paraMap.Add("@Id_Str", "YZ")
            paraMap.Add("@Field", "GH")
            paraMap.Add("@Zero", "3")
            paraMap.Add("@Date", D.ToString("yyyy-MM-dd"))
            Dim MR As MsgReturn = SqlStrToOneStr("GetTableID_NoSave_Date", paraMap, True)
            If MR.IsOk Then
                R.NewID = MR.Msg
                R.IsOk = True
            Else
                R.RetrunMsg = "获取运转单号失败!"
                R.IsOk = False
            End If
            Return R
        Catch ex As Exception
            DebugToLog(ex)
            R.IsOk = False
            R.RetrunMsg = "获取运转单号失败!" & ex.Message
            Return R
        End Try
    End Function
    ''' <summary>
    ''' 获取生产单布种列表
    ''' </summary>
    ''' <param name="sId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Produce_GetBZList(ByVal sId As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_Produce_GetBZList, "@GH", sId)
    End Function

    ''' <summary>
    ''' 获取客户色号
    ''' </summary>
    ''' <param name="bzcID"></param>
    ''' <param name="bzID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Produce_GetClientBZC(ByVal bzcID As String, ByVal bzID As String) As DtReturnMsg
        Dim sqlBuider As New StringBuilder
        sqlBuider.Append("select Client_Bzc from T10009_BzcLinkBz where BZ_ID='")
        sqlBuider.Append(bzcID)
        sqlBuider.Append("' ")
        If Not bzID = "" Then
            sqlBuider.Append(" and BZ_No='")
            sqlBuider.Append(bzID)
            sqlBuider.Append("'")
        End If

        Return PClass.PClass.SqlStrToDt(sqlBuider.ToString)
    End Function

    ''' <summary>
    ''' 按色号获取布种列表
    ''' </summary>
    ''' <param name="bzcID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Produce_GetBZListByBzcID(ByVal bzcID As String) As DtReturnMsg

        Return PClass.PClass.SqlStrToDt(SQL_Produce_GetBZByBZCID, "@BZC_ID", bzcID)
    End Function


    ''' <summary>
    ''' 按色号获取客户
    ''' </summary>
    ''' <param name="bzcID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Produce_GetClientByBzcID(ByVal bzcID As String) As DtReturnMsg

        Return PClass.PClass.SqlStrToDt(SQL_Produce_GetClientByBZCID, "@BZC_ID", bzcID)
    End Function
#End Region



End Module
