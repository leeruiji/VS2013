Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports BaseClass

Module Module_Dao
#Region "送货单"
    Private Const BZSH_DB_NAME As String = "送货单"

    ''' <summary>
    ''' 获取对送货单信息
    ''' </summary>
    ''' <param name="sId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function BZSH_GetById(ByVal sId As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_BZSH_GetBZSHByidWhithClientName, "@BZSH_ID", sId)
    End Function

    ''' <summary>
    ''' 获取对送货单列表信息
    ''' </summary>
    ''' <param name="sId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function BZSH_GetListById(ByVal sId As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_BZSH_GetBZSHListByid, "@BZSH_ID", sId)
    End Function

    '''' <summary>
    '''' 获取所有送货单
    '''' </summary>
    '''' <returns></returns>
    '''' <remarks></remarks>
    'Public Function BZSH_GetByOption(ByVal oList As List(Of BaseClass.FindOption)) As DtReturnMsg
    '    Dim paraMap As New Dictionary(Of String, Object)
    '    Dim sql As String = SQL_BZSH_Get & BaseClass.OptionClass.OptionClass_BuidSqlConditon(oList, paraMap) & SQL_BZSH_OrderBy
    '    Return PClass.PClass.SqlStrToDt(SQL_BZSH_Get)
    'End Function

    ''' <summary>
    ''' 获取查询条件集合
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function BZSH_GetConditionNames() As List(Of FindOption)
        Dim foList As New List(Of FindOption)
        Dim fo As New FindOption
        fo.Field = "请选择"
        fo.DB_Field = ""
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "送货单号"
        fo.DB_Field = "BZSH_ID"
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "客户编号"
        fo.DB_Field = "P.Client_ID"
        foList.Add(fo)

     
        Return foList
    End Function
    ''' <summary>
    ''' 按条件获取送货单列表
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function BZSH_GetByOption(ByVal oList As OptionList) As DtReturnMsg
        Dim paraMap As New Dictionary(Of String, Object)
        Dim sqlBuider As New StringBuilder
        sqlBuider.Append(oList.Sql)
        sqlBuider.Append("  WHERE 1=1  ")
        sqlBuider.Append(BaseClass.OptionClass.OptionClass_BuidSqlConditon(oList.FoList, paraMap))
        sqlBuider.Append(SQL_BZSH_OrderBy)
        Return PClass.PClass.SqlStrToDt(sqlBuider.ToString, paraMap)
    End Function



    ''' <summary>
    ''' 获取一个新ID
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function BZSH_GetNewId(ByVal D As Date) As RetrunNewIdMsg
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
                R.RetrunMsg = "获取" & BZSH_DB_NAME & "单号成功!"
            End If
            Dim paraMap As New Dictionary(Of String, Object)
            paraMap.Add("@DB_Str", "T40000_BZSH_Table")
            paraMap.Add("@Id_Str", "BZSH")
            paraMap.Add("@Field", "BZSH_ID")
            paraMap.Add("@Zero", "3")
            paraMap.Add("@Date", D.ToString("yyyy-MM-dd"))
            Dim MR As MsgReturn = SqlStrToOneStr("GetTableID_NoSave_Date", paraMap, True)
            If MR.IsOk Then
                R.NewID = MR.Msg
                R.IsOk = True
            Else
                R.RetrunMsg = "获取" & BZSH_DB_NAME & "单号失败!"
                R.IsOk = False
            End If
            Return R
        Catch ex As Exception
            DebugToLog(ex)
            R.IsOk = False
            R.RetrunMsg = "获取" & BZSH_DB_NAME & "单号失败!" & ex.Message
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
    Public Function BZSH_Add(ByVal dtTable As DataTable, ByVal dtList As DataTable, Optional ByVal Supplier_Name_New As String = "") As DtListReturnMsg
        Dim msg As New DtListReturnMsg
        Dim sqlMap As New Dictionary(Of String, String)
        Dim paraMap As New Dictionary(Of String, Object)
        Dim BZSHId As String = dtTable.Rows(0)("BZSH_ID")
        paraMap.Add("BZSH_ID", BZSHId)
        Try
            sqlMap.Add("Table", SQL_BZSH_SelByid)
            sqlMap.Add("List", SQL_BZSH_SelListByid)
            
          
            msg = SqlStrToDt(sqlMap, paraMap)
            If msg.DtList("Table").Rows.Count = 0 Then

                DvToDt(dtTable, msg.DtList("Table"), New List(Of String), True)
                DvToDt(dtList, msg.DtList("List"), New List(Of String), True)
                DtToUpDate(msg)
                msg.Msg = "" & BZSH_DB_NAME & "[" & dtTable.Rows(0)("BZSH_ID") & "]添加成功!"
                msg.IsOk = True
            Else
                msg.IsOk = False
                msg.Msg = "" & BZSH_DB_NAME & "[" & dtTable.Rows(0)("BZSH_ID") & "[已经存在!,请双击编号文本框,获取新编号!"
            End If
            Return msg
        Catch ex As Exception
            msg.IsOk = False
            msg.Msg = "" & BZSH_DB_NAME & "[" & dtTable.Rows(0)("BZSH_ID") & "]添加错误!"
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
    Public Function BZSH_Save(ByVal dtTable As DataTable, ByVal dtList As DataTable) As DtListReturnMsg
        Dim msg As New DtListReturnMsg
        Dim sqlMap As New Dictionary(Of String, String)
        Dim paraMap As New Dictionary(Of String, Object)
        Dim BZSHId As String = dtTable.Rows(0)("BZSH_ID")
        paraMap.Add("BZSH_ID", BZSHId)
        Try
            sqlMap.Add("Table", SQL_BZSH_SelByid)
            sqlMap.Add("List", SQL_BZSH_SelListByid)
            msg = SqlStrToDt(sqlMap, paraMap)
            If msg.DtList("Table").Rows.Count = 1 Then
                DvUpdateToDt(dtTable, msg.DtList("Table"), New List(Of String))
                DvToDt(dtList, msg.DtList("List"), New List(Of String))
                DtToUpDate(msg)
                msg.Msg = "" & BZSH_DB_NAME & "[" & dtTable.Rows(0)("BZSH_ID") & "]修改成功!"
                msg.IsOk = True
            Else
                msg.IsOk = False
                msg.Msg = "" & BZSH_DB_NAME & "[" & dtTable.Rows(0)("BZSH_ID") & "]不存在"
            End If
            Return msg
        Catch ex As Exception
            msg.IsOk = False
            msg.Msg = "" & BZSH_DB_NAME & "[" & dtTable.Rows(0)("BZSH_ID") & "]修改错误"
            DebugToLog(ex)
            Return msg
        Finally

        End Try
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="BZSHId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function BZSH_Del(ByVal BZSHId As String)
        Return RunSQL(SQL_BZSH_DelBZSHByid, "@BZSH_ID", BZSHId)
    End Function

    ''' <summary>
    ''' 获取运转单信息
    ''' </summary>
    ''' <param name="sId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Produce_GetById(ByVal sId As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_Produce_GetByID_WithName, "@Produce_ID", sId)
    End Function

#End Region

#Region "胚布入库单"

    Public Enum Enum_PBRK
        New_PBRK = 0
        ShenHe = 1
        XiaoZhang = 2
    End Enum


    Private Const PBRK_DB_NAME As String = "胚布入库单"

    ''' <summary>
    ''' 获取对胚布入库单信息
    ''' </summary>
    ''' <param name="sId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function PBRK_GetById(ByVal sId As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_PBRK_GetPBRKByid, "@PBRK_ID", sId)
    End Function

    ''' <summary>
    ''' 获取对胚布入库单列表信息
    ''' </summary>
    ''' <param name="sId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function PBRK_GetListById(ByVal sId As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_PBRK_GetPBRKListByid, "@PBRK_ID", sId)
    End Function

    ''' <summary>
    ''' 获取胚布入库单 连接到缸号的明细信息
    ''' </summary>
    ''' <param name="sId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function PBRK_SetListById(ByVal sId As String) As DtReturnMsg
        Dim R As DtReturnMsg = PClass.PClass.SqlStrToDt(SQL_PBRK_SetListById, "@PBRK_ID", sId)
        If R.IsOk Then
            R.Dt.Columns.Add("State_Name")
            For Each Row As DataRow In R.Dt.Rows
                If Row("State") = 0 Then
                    Row("State_Name") = ComFun.GetProduceStateName(IsNull(Row("GH_State"), 0))
                Else
                    Row("State_Name") = "已出货"
                End If
            Next
        End If
        Return R
    End Function

    '''' <summary>
    '''' 获取所有胚布入库单
    '''' </summary>
    '''' <returns></returns>
    '''' <remarks></remarks>
    'Public Function PBRK_GetByOption(ByVal oList As List(Of BaseClass.FindOption)) As DtReturnMsg
    '    Dim paraMap As New Dictionary(Of String, Object)
    '    Dim sql As String = SQL_PBRK_Get & BaseClass.OptionClass.OptionClass_BuidSqlConditon(oList, paraMap) & SQL_PBRK_OrderBy
    '    Return PClass.PClass.SqlStrToDt(SQL_PBRK_Get)
    'End Function

    ''' <summary>
    ''' 获取查询条件集合
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function PBRK_GetConditionNames() As List(Of FindOption)
        Dim foList As New List(Of FindOption)
        Dim fo As New FindOption
        fo.Field = "请选择"
        fo.DB_Field = ""
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "胚布入库单号"
        fo.DB_Field = "PBRK_ID"
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "客户编号"
        fo.DB_Field = "Client_ID"
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "布类编号"
        fo.DB_Field = "BZ_No"
        foList.Add(fo)



        Return foList
    End Function
    ''' <summary>
    ''' 按条件获取胚布入库单列表
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function PBRK_GetByOption(ByVal oList As OptionList) As DtReturnMsg
        Dim paraMap As New Dictionary(Of String, Object)
        Dim sqlBuider As New StringBuilder
        sqlBuider.Append(SQL_PBRK_Get_WithName)
        sqlBuider.Append("  WHERE 1=1  ")
        sqlBuider.Append(BaseClass.OptionClass.OptionClass_BuidSqlConditon(oList.FoList, paraMap))
        sqlBuider.Append(SQL_PBRK_OrderBy)
        Return PClass.PClass.SqlStrToDt(sqlBuider.ToString, paraMap)
    End Function

    Public Function PBRK_CheckID(ByVal PBRK_ID As String) As Boolean
        Dim R As MsgReturn = SqlStrToOneStr(SQL_PBRK_CheckID, "@PBRK_ID", PBRK_ID)
        If R.IsOk Then
            If Val(R.Msg) = 0 Then
                Return False
            Else
                Return True
            End If
        Else
            Return False
        End If
    End Function




    ''' <summary>
    ''' 获取一个新ID
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function PBRK_GetNewId(ByVal D As Date) As RetrunNewIdMsg
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
                R.RetrunMsg = "获取" & PBRK_DB_NAME & "单号成功!"
            End If
            Dim paraMap As New Dictionary(Of String, Object)
            paraMap.Add("@DB_Str", "T40100_PBRK_Table")
            paraMap.Add("@Id_Str", "")
            paraMap.Add("@Field", "PBRK_ID")
            paraMap.Add("@Zero", "3")
            paraMap.Add("@Date", D.ToString("yyyy-MM-dd"))
            Dim MR As MsgReturn = SqlStrToOneStr("GetTableID_NoSave_Date", paraMap, True)
            If MR.IsOk Then
                R.NewID = MR.Msg
                R.IsOk = True
            Else
                R.RetrunMsg = "获取" & PBRK_DB_NAME & "单号失败!"
                R.IsOk = False
            End If
            Return R
        Catch ex As Exception
            DebugToLog(ex)
            R.IsOk = False
            R.RetrunMsg = "获取" & PBRK_DB_NAME & "单号失败!" & ex.Message
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
    Public Function PBRK_Add(ByVal dtTable As DataTable, ByVal dtList As DataTable, Optional ByVal Supplier_Name_New As String = "") As DtListReturnMsg
        Dim msg As New DtListReturnMsg
        Dim sqlMap As New Dictionary(Of String, String)
        Dim paraMap As New Dictionary(Of String, Object)
        Dim PBRKId As String = dtTable.Rows(0)("PBRK_ID")
        paraMap.Add("PBRK_ID", PBRKId)
        Try
            sqlMap.Add("Table", SQL_PBRK_SelByid)
            sqlMap.Add("List", SQL_PBRK_SelListByid)


            msg = SqlStrToDt(sqlMap, paraMap)
            If msg.DtList("Table").Rows.Count = 0 Then

                DvToDt(dtTable, msg.DtList("Table"), New List(Of String), True)
                DvToDt(dtList, msg.DtList("List"), New List(Of String), True)
                DtToUpDate(msg)
                msg.Msg = "" & PBRK_DB_NAME & "[" & dtTable.Rows(0)("PBRK_ID") & "]添加成功!"
                msg.IsOk = True
            Else
                msg.IsOk = False
                msg.Msg = "" & PBRK_DB_NAME & "[" & dtTable.Rows(0)("PBRK_ID") & "[已经存在!,请双击编号文本框,获取新编号!"
            End If
            Return msg
        Catch ex As Exception
            msg.IsOk = False
            msg.Msg = "" & PBRK_DB_NAME & "[" & dtTable.Rows(0)("PBRK_ID") & "]添加错误!"
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
    Public Function PBRK_Save(ByVal dtTable As DataTable, ByVal dtList As DataTable) As DtListReturnMsg
        Dim msg As New DtListReturnMsg
        Dim sqlMap As New Dictionary(Of String, String)
        Dim paraMap As New Dictionary(Of String, Object)
        Dim PBRKId As String = dtTable.Rows(0)("PBRK_ID")
        paraMap.Add("PBRK_ID", PBRKId)
        Try
            sqlMap.Add("Table", SQL_PBRK_SelByid)
            sqlMap.Add("List", SQL_PBRK_SelListByid)
            msg = SqlStrToDt(sqlMap, paraMap)
            If msg.DtList("Table").Rows.Count = 1 Then
                If msg.DtList("Table").Rows(0)("State") <> Enum_PBRK.New_PBRK Then
                    msg.DaList("Table").Dispose()
                    msg.DaList("List").Dispose()
                    msg.Cnn.Dispose()
                    msg.IsOk = False
                    msg.Msg = "" & PBRK_DB_NAME & "[" & dtTable.Rows(0)("PBRK_ID") & "]已经被审核不能再修改!"
                End If
                DvUpdateToDt(dtTable, msg.DtList("Table"), New List(Of String))
                DvToDt(dtList, msg.DtList("List"), New List(Of String))
                DtToUpDate(msg)
                msg.Msg = "" & PBRK_DB_NAME & "[" & dtTable.Rows(0)("PBRK_ID") & "]修改成功!"
                msg.IsOk = True
            Else
                msg.IsOk = False
                msg.Msg = "" & PBRK_DB_NAME & "[" & dtTable.Rows(0)("PBRK_ID") & "]不存在"
            End If
            Return msg
        Catch ex As Exception
            msg.IsOk = False
            msg.Msg = "" & PBRK_DB_NAME & "[" & dtTable.Rows(0)("PBRK_ID") & "]修改错误"
            DebugToLog(ex)
            Return msg
        Finally

        End Try
    End Function





    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="PBRKId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function PBRK_Del(ByVal PBRKId As String)
        Return RunSQL(SQL_PBRK_DelPBRKByid, "@PBRK_ID", PBRKId)
    End Function

    ''' <summary>
    ''' 更新入库单状态
    ''' </summary>
    ''' <param name="state"></param>
    ''' <param name="_id"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function PBRK_UpdateState(ByVal state As Enum_PBRK, ByVal _id As String) As MsgReturn
        Dim returnMsg As New MsgReturn
        Dim msg As DtReturnMsg = PBRK_GetById(_id)
        If msg.IsOk AndAlso msg.Dt.Rows.Count > 0 Then
            If IsNull(msg.Dt.Rows(0)("State"), Enum_PBRK.New_PBRK) <> Enum_PBRK.ShenHe Then


                Dim paraMap As New Dictionary(Of String, Object)
                paraMap.Add("@State", state)
                paraMap.Add("@PBRK_ID", _id)
                Dim sql As String = "Update T40100_PBRK_Table set State=@State where PBRK_ID=@PBRK_ID"
                If PClass.PClass.RunSQL(sql, paraMap).IsOk Then
                    returnMsg.IsOk = True
                Else
                    returnMsg.IsOk = False
                    returnMsg.Msg = "入库单[" & _id & "]审核失败!"
                End If

            Else
                returnMsg.IsOk = False
                returnMsg.Msg = "入库单[" & _id & "]已经审核!"
            End If
        Else
            returnMsg.IsOk = False
            returnMsg.Msg = "入库单[" & _id & "]审核失败!"
        End If
        Return returnMsg
    End Function


#End Region


#Region "生产配布"

    ''' <summary>
    ''' 获取对胚布入库单列表信息
    ''' </summary>
    ''' <param name="sId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function PBRK_GetListByGH(ByVal GH As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_PBRK_GetListByGH, "@GH", GH)
    End Function

    Function SCPB_GetPBRK_Table_ByID(ByVal PBRK_ID As String) As DtReturnMsg
        Return SqlStrToDt(SQL_SCPB_GetPBRK_Table_ByID, "@PBRK_ID", PBRK_ID)
    End Function


    Function SCPB_GetGH_ByID(ByVal PBRK_ID As String) As DtReturnMsg
        Return SqlStrToDt(SQL_SCPB_GetGH_ByID, "@GH", PBRK_ID)
    End Function
    ''' <summary>
    ''' 按条件获取胚布入库单列表
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SCPB_GetByOption(ByVal oList As OptionList) As DtReturnMsg
        Dim paraMap As New Dictionary(Of String, Object)
        Dim sqlBuider As New StringBuilder
        sqlBuider.Append(SQL_ProduceGd_Get_WithName)
        sqlBuider.Append("  WHERE state>0  ")
        sqlBuider.Append(BaseClass.OptionClass.OptionClass_BuidSqlConditon(oList.FoList, paraMap))
        sqlBuider.Append(" order by Produce_ID ")
        Return PClass.PClass.SqlStrToDt(sqlBuider.ToString, paraMap)
    End Function

    ''' <summary>
    ''' 获取查询条件集合
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SCPB_GetConditionNames() As List(Of FindOption)
        Dim foList As New List(Of FindOption)
        Dim fo As New FindOption
        fo.Field = "请选择"
        fo.DB_Field = ""
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "缸号"
        fo.DB_Field = "Produce_ID"
        foList.Add(fo)


        'fo = New FindOption
        'fo.Field = "胚布入库单号"
        'fo.DB_Field = "PBRK_ID"
        'foList.Add(fo)


        Return foList
    End Function





    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="GH"></param>
    ''' <param name="PB_Date"></param>
    ''' <param name="dtList"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SCPB_Save(ByVal GH As String, ByVal PB_Date As Date, ByVal dtList As DataTable, ByVal IsNum As Boolean) As MsgReturn

        Dim S As New StringBuilder("")
        Dim ZL As Double = 0
        Dim C As Integer = 0
        Dim PBRK_ID As String = ""
        S.AppendLine("declare @State int")
        S.AppendLine("declare @Err Varchar(8000)")
        S.AppendLine("set @State=(select top 1 isnull(State,'-1')State from t30010_Produce_Gd where Produce_ID=@GH)")
        S.AppendLine("set @Err=''")
        S.AppendLine("if @State<>@PB_State")
        S.AppendLine("select N'Error=state;缸号不是待配布状态'")
        S.AppendLine("else")
        S.AppendLine("begin")
        S.AppendLine("begin tran T")
        S.AppendLine("Update T30010_Produce_Gd set PB_ZLSum=@PB_ZLSum,PB_CountSum=@PB_CountSum,Date_PeiBu=@Date_PeiBu,PB_User=@PB_User")
        If IsNum = False Then
            S.AppendLine(",CR_LuoSeBzCount=@PB_CountSum")
        End If
        S.AppendLine("where Produce_ID=@GH")
        S.AppendLine("Update T30010_Produce_Gd set State=@PB_State+1,Date_ShouPei=(select top 1 PBRK_Date from T40100_PBRK_Table where PBRK_ID=@PBRK_ID)")
        S.AppendLine(",ShaPi=(select  top 1 ShaPi from T40100_PBRK_Table where PBRK_ID=@PBRK_ID) where Produce_ID=@GH and PB_CountSum=CR_LuoSeBzCount")
        S.AppendLine("update T40101_PBRK_List set GH='',PB=0 where GH=@GH")

        If dtList.Rows.Count > 0 Then '取第一个入库单的收坯时间
            PBRK_ID = dtList.Rows(0)("PBRK_ID")
        End If
        For Each R As DataRow In dtList.Rows
            S.AppendLine("update T40101_PBRK_List set GH=@GH,PB=" & R("PB") & " where GH='' and PBRK_Line=" & R("PBRK_Line"))
            S.AppendLine("if @@Rowcount=0 set @Err=@Err + '" & R("PBRK_Line") & "' + ','")
            ZL = ZL + R("ZL")
            C = C + 1
        Next
        S.AppendLine("Exec('P40100_PBRK_ReSum '''+@GH+''' ')")

        S.AppendLine("if @Err<>''")
        S.AppendLine("begin")
        S.AppendLine("rollback")
        S.AppendLine("set @Err=N'Error=gh;' + @Err")
        S.AppendLine("select @Err")
        S.AppendLine("end")
        S.AppendLine("else")
        S.AppendLine("begin")
        S.AppendLine("commit")
        S.AppendLine("select N'Error=no;'")
        S.AppendLine("end")
        S.AppendLine("end")
        Dim P As New Dictionary(Of String, Object)
        P.Add("@GH", GH)
        P.Add("@Date_PeiBu", PB_Date.ToString("yyyy-MM-dd"))
        P.Add("@PB_State", Enum_ProduceState.XiaDan)
        P.Add("@PB_ZLSum", ZL)
        P.Add("@PB_CountSum", C)
        P.Add("@PBRK_ID", PBRK_ID)
        P.Add("@PB_User", User_Name)


        Dim Rm As MsgReturn = SqlStrToOneStr(S.ToString, P)
        If Rm.IsOk Then
            Dim Sp() As String = Rm.Msg.Split("=")
            If Sp(1).StartsWith("no") Then
                Rm.Msg = "保存配布单成功!"
                Rm.IsOk = True
            Else
                Rm.IsOk = False
                If Sp(1).StartsWith("state") Then
                    Rm.Msg = "1保存配布单失败,原因:" & "缸号[" & GH & "]不在代配布状态"
                Else
                    If Sp(1).StartsWith("gh") Then
                        Sp = Rm.Msg.Split(";")
                        Rm.Msg = "2保存配布单失败;" & Sp(1)
                    Else
                        Rm.Msg = "9保存配布单失败,原因:未知"
                    End If
                End If
            End If
        Else
            Rm.Msg = "9保存配布单失败,原因:" & Rm.Msg
        End If
        Return Rm
    End Function

#End Region
End Module
