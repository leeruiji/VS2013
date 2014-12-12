Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports BaseClass

Module Module_Dao
#Region "生产单"
    Private Const Produce_DB_NAME As String = "生产单"

    ''' <summary>
    ''' 获取对生产单信息
    ''' </summary>
    ''' <param name="sId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Produce_GetById(ByVal sId As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_Produce_GetProduceByid, "@Produce_ID", sId)
    End Function

    ''' <summary>
    ''' 获取对生产单列表信息
    ''' </summary>
    ''' <param name="sId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Produce_GetListById(ByVal sId As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_Produce_GetProduceListByid, "@Produce_ID", sId)
    End Function

    '''' <summary>
    '''' 获取所有生产单
    '''' </summary>
    '''' <returns></returns>
    '''' <remarks></remarks>
    'Public Function Produce_GetByOption(ByVal oList As List(Of BaseClass.FindOption)) As DtReturnMsg
    '    Dim paraMap As New Dictionary(Of String, Object)
    '    Dim sql As String = SQL_Produce_Get & BaseClass.OptionClass.OptionClass_BuidSqlConditon(oList, paraMap) & SQL_Produce_OrderBy
    '    Return PClass.PClass.SqlStrToDt(SQL_Produce_Get)
    'End Function

    ''' <summary>
    ''' 获取查询条件集合
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Produce_GetConditionNames() As List(Of FindOption)
        Dim foList As New List(Of FindOption)
        Dim fo As New FindOption
        fo.Field = "请选择"
        fo.DB_Field = ""
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "生产单号"
        fo.DB_Field = "Produce_ID"
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
    ''' 按条件获取生产单列表
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Produce_GetByOption(ByVal oList As OptionList) As DtReturnMsg
        Dim paraMap As New Dictionary(Of String, Object)
        Dim sqlBuider As New StringBuilder
        sqlBuider.Append(oList.Sql)
        sqlBuider.Append("  WHERE 1=1  ")
        sqlBuider.Append(BaseClass.OptionClass.OptionClass_BuidSqlConditon(oList.FoList, paraMap))
        sqlBuider.Append(SQL_Produce_OrderBy)
        Return PClass.PClass.SqlStrToDt(sqlBuider.ToString, paraMap)
    End Function




    ''' <summary>
    ''' 获取一个新ID
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Produce_GetNewId(ByVal D As Date) As RetrunNewIdMsg
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
                R.RetrunMsg = "获取" & Produce_DB_NAME & "单号成功!"
            End If
            Dim paraMap As New Dictionary(Of String, Object)
            paraMap.Add("@DB_Str", "T25000_Produce_table")
            paraMap.Add("@Id_Str", "SC")
            paraMap.Add("@Field", "Produce_ID")
            paraMap.Add("@Zero", "3")
            paraMap.Add("@Date", D.ToString("yyyy-MM-dd"))
            Dim MR As MsgReturn = SqlStrToOneStr("GetTableID_NoSave_Date", paraMap, True)
            If MR.IsOk Then
                R.NewID = MR.Msg
                R.IsOk = True
            Else
                R.RetrunMsg = "获取" & Produce_DB_NAME & "单号失败!"
                R.IsOk = False
            End If
            Return R
        Catch ex As Exception
            DebugToLog(ex)
            R.IsOk = False
            R.RetrunMsg = "获取" & Produce_DB_NAME & "单号失败!" & ex.Message
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
    Public Function Produce_Add(ByVal dtTable As DataTable, ByVal dtList As DataTable, Optional ByVal Supplier_Name_New As String = "") As DtListReturnMsg
        Dim msg As New DtListReturnMsg
        Dim sqlMap As New Dictionary(Of String, String)
        Dim paraMap As New Dictionary(Of String, Object)
        Dim ProduceId As String = dtTable.Rows(0)("Produce_ID")
        paraMap.Add("Produce_ID", ProduceId)
        Try
            sqlMap.Add("Table", SQL_Produce_SelByid)
            sqlMap.Add("List", SQL_Produce_SelListByid)
            If Supplier_Name_New <> "" Then
                If dtTable.Rows(0).Item("Supplier_id") = "" Then '自动生产ID
                    sqlMap.Add("Supplier", BaseClass.ClientSupplier.SQL_Supplier_New & " where Supplier_Name='" & Supplier_Name_New & "'")
                Else
                    sqlMap.Add("Supplier", BaseClass.ClientSupplier.SQL_Supplier_New & " where Supplier_Id='" & dtTable.Rows(0).Item("Supplier_id") & "'")
                End If
            End If
            msg = SqlStrToDt(sqlMap, paraMap)
            If msg.DtList("Table").Rows.Count = 0 Then
                If Supplier_Name_New <> "" Then
                    If msg.DtList("Supplier").Rows.Count = 0 Then
                        '自动生产ID
                        dtTable.Rows(0).Item("Supplier_id") = BaseClass.ClientSupplier.Supplier_GetNewID()
                        Dim Dr As DataRow = msg.DtList("Supplier").NewRow
                        Dr.Item("Supplier_id") = dtTable.Rows(0).Item("Supplier_id")
                        Dr.Item("Supplier_Name") = Supplier_Name_New
                        msg.DtList("Supplier").Rows.Add(Dr)
                    Else
                        If dtTable.Rows(0).Item("Supplier_id") = "" Then '自动生产ID
                            dtTable.Rows(0).Item("Supplier_id") = msg.DtList("Supplier").Rows(0)("Supplier_id")
                        End If
                    End If
                End If
                DvToDt(dtTable, msg.DtList("Table"), New List(Of String), True)
                DvToDt(dtList, msg.DtList("List"), New List(Of String), True)
                DtToUpDate(msg)
                msg.Msg = "" & Produce_DB_NAME & "[" & dtTable.Rows(0)("Produce_ID") & "]添加成功!"
                msg.IsOk = True
            Else
                msg.IsOk = False
                msg.Msg = "" & Produce_DB_NAME & "[" & dtTable.Rows(0)("Produce_ID") & "[已经存在!"
            End If
            Return msg
        Catch ex As Exception
            msg.IsOk = False
            msg.Msg = "" & Produce_DB_NAME & "[" & dtTable.Rows(0)("Produce_ID") & "]添加错误!"
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
    Public Function Produce_Save(ByVal dtTable As DataTable, ByVal dtList As DataTable) As DtListReturnMsg
        Dim msg As New DtListReturnMsg
        Dim sqlMap As New Dictionary(Of String, String)
        Dim paraMap As New Dictionary(Of String, Object)
        Dim ProduceId As String = dtTable.Rows(0)("Produce_ID")
        paraMap.Add("Produce_ID", ProduceId)
        Try
            sqlMap.Add("Table", SQL_Produce_SelByid)
            sqlMap.Add("List", SQL_Produce_SelListByid)
            msg = SqlStrToDt(sqlMap, paraMap)
            If msg.DtList("Table").Rows.Count = 1 Then
                DvUpdateToDt(dtTable, msg.DtList("Table"), New List(Of String))
                DvToDt(dtList, msg.DtList("List"), New List(Of String))
                DtToUpDate(msg)
                msg.Msg = "" & Produce_DB_NAME & "[" & dtTable.Rows(0)("Produce_ID") & "]修改成功!"
                msg.IsOk = True
            Else
                msg.IsOk = False
                msg.Msg = "" & Produce_DB_NAME & "[" & dtTable.Rows(0)("Produce_ID") & "]不存在"
            End If
            Return msg
        Catch ex As Exception
            msg.IsOk = False
            msg.Msg = "" & Produce_DB_NAME & "[" & dtTable.Rows(0)("Produce_ID") & "]修改错误"
            DebugToLog(ex)
            Return msg
        Finally

        End Try
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="ProduceId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Produce_Del(ByVal ProduceId As String)
        Return RunSQL(SQL_Produce_DelProduceByid, "@Produce_ID", ProduceId)
    End Function

#End Region


End Module
