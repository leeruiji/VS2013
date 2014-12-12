Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports BaseClass

Module Module_Dao
#Region "成品出库单"
    Private Const StoreOut_DB_NAME As String = "成品出库单"

    ''' <summary>
    ''' 获取对成品出库单信息
    ''' </summary>
    ''' <param name="sId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function StoreOut_GetById(ByVal sId As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_StoreOut_GetStoreOutByid, "@StoreOut_ID", sId)
    End Function

    ''' <summary>
    ''' 获取对成品出库单列表信息
    ''' </summary>
    ''' <param name="sId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function StoreOut_GetListById(ByVal sId As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_StoreOut_GetStoreOutListByid, "@StoreOut_ID", sId)
    End Function

    '''' <summary>
    '''' 获取所有成品出库单
    '''' </summary>
    '''' <returns></returns>
    '''' <remarks></remarks>
    'Public Function StoreOut_GetByOption(ByVal oList As List(Of BaseClass.FindOption)) As DtReturnMsg
    '    Dim paraMap As New Dictionary(Of String, Object)
    '    Dim sql As String = SQL_StoreOut_Get & BaseClass.OptionClass.OptionClass_BuidSqlConditon(oList, paraMap) & SQL_StoreOut_OrderBy
    '    Return PClass.PClass.SqlStrToDt(SQL_StoreOut_Get)
    'End Function

    ''' <summary>
    ''' 获取查询条件集合
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function StoreOut_GetConditionNames() As List(Of FindOption)
        Dim foList As New List(Of FindOption)
        Dim fo As New FindOption
        fo.Field = "请选择"
        fo.DB_Field = ""
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "成品出库单号"
        fo.DB_Field = "StoreOut_ID"
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "供应商"
        fo.DB_Field = "Supplier_Name"
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "商品编号"
        fo.DB_Field = "Goods_No"
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "商品名称"
        fo.DB_Field = "Goods_Name"
        foList.Add(fo)
        Return foList
    End Function
    ''' <summary>
    ''' 按条件获取成品出库单列表
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function StoreOut_GetByOption(ByVal oList As OptionList) As DtReturnMsg
        Dim paraMap As New Dictionary(Of String, Object)
        Dim sqlBuider As New StringBuilder
        sqlBuider.Append(oList.Sql)
        sqlBuider.Append("  WHERE 1=1  ")
        sqlBuider.Append(BaseClass.OptionClass.OptionClass_BuidSqlConditon(oList.FoList, paraMap))
        sqlBuider.Append(SQL_StoreOut_OrderBy)
        Return PClass.PClass.SqlStrToDt(sqlBuider.ToString, paraMap)
    End Function



    ''' <summary>
    ''' 获取一个新ID
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function StoreOut_GetNewId(ByVal D As Date) As RetrunNewIdMsg
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
                R.RetrunMsg = "获取" & StoreOut_DB_NAME & "单号成功!"
            End If
            Dim paraMap As New Dictionary(Of String, Object)
            paraMap.Add("@DB_Str", "T25100_StoreOut_table")
            paraMap.Add("@Id_Str", "CH")
            paraMap.Add("@Field", "StoreOut_ID")
            paraMap.Add("@Zero", "3")
            paraMap.Add("@Date", D.ToString("yyyy-MM-dd"))
            Dim MR As MsgReturn = SqlStrToOneStr("GetTableID_NoSave_Date", paraMap, True)
            If MR.IsOk Then
                R.NewID = MR.Msg
                R.IsOk = True
            Else
                R.RetrunMsg = "获取" & StoreOut_DB_NAME & "单号失败!"
                R.IsOk = False
            End If
            Return R
        Catch ex As Exception
            DebugToLog(ex)
            R.IsOk = False
            R.RetrunMsg = "获取" & StoreOut_DB_NAME & "单号失败!" & ex.Message
            Return R
        End Try
    End Function




    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="dtTable"></param>
    ''' <param name="dtList"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function StoreOut_Add(ByVal dtTable As DataTable, ByVal dtList As DataTable) As DtListReturnMsg
        Dim msg As New DtListReturnMsg
        Dim sqlMap As New Dictionary(Of String, String)
        Dim paraMap As New Dictionary(Of String, Object)
        Dim StoreOutId As String = dtTable.Rows(0)("StoreOut_ID")
        paraMap.Add("StoreOut_ID", StoreOutId)
        Try
            sqlMap.Add("Table", SQL_StoreOut_SelByid)
            sqlMap.Add("List", SQL_StoreOut_SelListByid)
            msg = SqlStrToDt(sqlMap, paraMap)
            If msg.DtList("Table").Rows.Count = 0 Then
                DvToDt(dtTable, msg.DtList("Table"), New List(Of String), True)
                DvToDt(dtList, msg.DtList("List"), New List(Of String), True)
                DtToUpDate(msg)
                msg.Msg = "" & StoreOut_DB_NAME & "[" & dtTable.Rows(0)("StoreOut_ID") & "]添加成功!"
                msg.IsOk = True
            Else
                msg.IsOk = False
                msg.Msg = "" & StoreOut_DB_NAME & "[" & dtTable.Rows(0)("StoreOut_ID") & "[已经存在!"
            End If
            Return msg
        Catch ex As Exception
            msg.IsOk = False
            msg.Msg = "" & StoreOut_DB_NAME & "[" & dtTable.Rows(0)("StoreOut_ID") & "]添加错误!"
            DebugToLog(ex)
            Return msg
        Finally
        End Try
    End Function





    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="dtTable"></param>
    ''' <param name="dtList"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function StoreOut_Save(ByVal dtTable As DataTable, ByVal dtList As DataTable) As DtListReturnMsg
        Dim msg As New DtListReturnMsg
        Dim sqlMap As New Dictionary(Of String, String)
        Dim paraMap As New Dictionary(Of String, Object)
        Dim StoreOutId As String = dtTable.Rows(0)("StoreOut_ID")
        paraMap.Add("StoreOut_ID", StoreOutId)
        Try
            sqlMap.Add("Table", SQL_StoreOut_SelByid)
            sqlMap.Add("List", SQL_StoreOut_SelListByid)
            msg = SqlStrToDt(sqlMap, paraMap)
            If msg.DtList("Table").Rows.Count = 1 Then
                DvUpdateToDt(dtTable, msg.DtList("Table"), New List(Of String))
                DvToDt(dtList, msg.DtList("List"), New List(Of String))
                DtToUpDate(msg)
                msg.Msg = "" & StoreOut_DB_NAME & "[" & dtTable.Rows(0)("StoreOut_ID") & "]修改成功!"
                msg.IsOk = True
            Else
                msg.IsOk = False
                msg.Msg = "" & StoreOut_DB_NAME & "[" & dtTable.Rows(0)("StoreOut_ID") & "]不存在"
            End If
            Return msg
        Catch ex As Exception
            msg.IsOk = False
            msg.Msg = "" & StoreOut_DB_NAME & "[" & dtTable.Rows(0)("StoreOut_ID") & "]修改错误"
            DebugToLog(ex)
            Return msg
        Finally

        End Try
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="StoreOutId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function StoreOut_Del(ByVal StoreOutId As String)
        Return RunSQL(SQL_StoreOut_DelStoreOutByid, "@StoreOut_ID", StoreOutId)
    End Function

#End Region


End Module
