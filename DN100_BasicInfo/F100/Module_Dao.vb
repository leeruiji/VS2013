Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports BaseClass.FindOption
Imports BaseClass.OptionClass
Imports BaseClass
Imports C1.Win.C1FlexGrid
Imports PClass

Module Module_Dao




#Region "分类"
    ''' <summary>
    ''' 获取所有分类
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GoodsType_GetChildrenByParentID(ByVal parentID As String) As DtReturnMsg
        If Not parentID Is Nothing OrElse Not parentID = "" Then
            Dim sql As String = "select * from T10000_GoodsType where GoodsType_ID like '" & parentID & "%'  order by GoodsType_ID"
            Return PClass.PClass.SqlStrToDt(sql)
        Else
            Return New DtReturnMsg
        End If

    End Function

    ''' <summary>
    ''' 获取所有分类
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GoodsType_GetAll() As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_GoodsType_GetAll)
    End Function

    ''' <summary>
    ''' 获取分类信息
    ''' </summary>
    ''' <param name="sId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GoodsType_GetById(ByVal sId As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_GoodsType_GetByID, "@GoodsType_ID", sId)
    End Function
    ''' <summary>
    ''' 定父节点下增加一个分类
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GoodsType_Add(ByVal dt As DataTable) As MsgReturn
        Dim Cnn As New SqlClient.SqlConnection
        Dim Da As New SqlClient.SqlDataAdapter
        Dim gId As String = ""
        Dim sql As String
        Dim returnMsg As New MsgReturn

        sql = SQL_GoodsType_GetByID
        If dt.Rows.Count <> 1 Then
            returnMsg.IsOk = False
            returnMsg.Msg = "新增分类失败!"
            Return returnMsg

        End If
        gId = dt.Rows(0)("GoodsType_ID")
        Try
            Dim msg As DtReturnMsg = SqlStrToDt(sql, Cnn, Da, "@GoodsType_ID", gId)
            If msg.IsOk AndAlso msg.Dt.Rows.Count = 0 Then

                DvToDt(dt, msg.Dt, New List(Of String), True)
                DtToUpDate(msg.Dt, Cnn, Da)
                returnMsg.IsOk = True
                returnMsg.Msg = "分类[" & dt.Rows(0)("GoodsType_Name") & "]新增成功!"
            Else
                returnMsg.IsOk = False
                returnMsg.Msg = "分类[" & dt.Rows(0)("GoodsType_Name") & "]已存在!"
            End If
        Catch ex As Exception
            DebugToLog(ex)
            returnMsg.IsOk = False
            returnMsg.Msg = "新增分类失败!"
        Finally
            Da.Dispose()
            Cnn.Dispose()
        End Try
        Return returnMsg
    End Function



    ''' <summary>
    '''修改一个分类
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GoodsType_Save(ByVal oGid As String, ByVal dt As DataTable) As MsgReturn
        Dim Cnn As New SqlClient.SqlConnection
        Dim Da As New SqlClient.SqlDataAdapter
        Dim gId As String = ""
        Dim sql As String
        Dim returnMsg As New MsgReturn
        Dim newID As String = ""
        sql = SQL_GoodsType_GetByID
        If dt.Rows.Count <> 1 Then
            returnMsg.IsOk = False
            returnMsg.Msg = "修改分类失败!"
            Return returnMsg

        End If
        gId = oGid '
        newID = dt.Rows(0)("GoodsType_ID")
        Try

            Dim msg As DtReturnMsg = SqlStrToDt(sql, Cnn, Da, "@GoodsType_ID", gId)
            If msg.IsOk AndAlso msg.Dt.Rows.Count = 1 Then
                DvToDt(dt, msg.Dt, New List(Of String))
                If gId <> newID Then
                    sql = "update T10000_GoodsType set GoodsType_ID =replace( GoodsType_ID,'" & oGid & "','" & newID & "') where GoodsType_ID like '" & oGid & "%' " & _
                          "update T10001_WL set WL_Type_ID= replace( WL_Type_ID,'" & oGid & "','" & newID & "') where WL_Type_ID like '" & oGid & "%' "
                    DtToUpDate(msg.Dt, Cnn, Da, sql)
                Else
                    DtToUpDate(msg.Dt, Cnn, Da)
                End If
                returnMsg.IsOk = True
                returnMsg.Msg = "分类[" & dt.Rows(0)("GoodsType_Name") & "保存成功!"
            Else
                returnMsg.IsOk = False
                returnMsg.Msg = "分类[" & dt.Rows(0)("GoodsType_Name") & "不存在!"
            End If


        Catch ex As Exception
            DebugToLog(ex)
            returnMsg.IsOk = False
            returnMsg.Msg = "修改分类失败!"
        Finally
            Da.Dispose()
            Cnn.Dispose()
        End Try
        Return returnMsg
    End Function

    ''' <summary>
    ''' 删除一个分类
    ''' </summary>
    ''' <param name="GoodsType_ID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GoodsType_Del(ByVal GoodsType_ID As String) As MsgReturn
        If Val(SqlStrToOneStr(SQL_GoodsType_CheckDel, "GoodsType_ID", GoodsType_ID).Msg) > 0 Then
            Dim R As New MsgReturn
            R.IsOk = False
            R.Msg = "分类删除失败,分类下还有子分类或物料"
            Return R
        End If
        Return RunSQL(SQL_GoodsType_Del, "@GoodsType_ID", GoodsType_ID)
    End Function
    ''' <summary>
    ''' 生成新的分类ID 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GoodsType_GetNewID(ByVal parentId As String) As String
        Try
            Dim sql As String
            Dim msg As New MsgReturn
            If parentId.Length >= 5 Then
                sql = "select top 1 GoodsType_ID  from T10000_GoodsType where GoodsType_ID like '" & parentId & "%'  and len(GoodsType_ID)>" & parentId.Length & " order by len(GoodsType_ID) asc,GoodsType_ID desc"
            Else
                parentId = "GT"
                sql = "select top 1 GoodsType_ID  from T10000_GoodsType where len( GoodsType_ID)=5  order by GoodsType_ID desc"
            End If

            msg = SqlStrToOneStr(sql)
            Dim j As Integer = 3
            If msg.IsOk Then
                Dim s As String = ""
                Dim i As Integer
                If msg.Msg.Length = parentId.Length OrElse msg.Msg.Length = 0 Then
                    i = 1
                Else
                    i = Integer.Parse(msg.Msg.Substring(msg.Msg.Length - j)) + 1
                End If
                s = Space(j).Replace(" ", 0) & i
                s = s.Substring(s.Length - j)
                Return parentId & s
            Else
                Return ""

            End If
        Catch ex As Exception
            DebugToLog(ex)
            Return ""
        End Try
    End Function

#End Region




#Region "布类"

    ''' <summary>
    ''' 获取所有布类信息
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function BZ_GetAll() As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_BZ_Get)
    End Function

    ''' <summary>
    ''' 获取查询条件集合
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function BZ_GetConditionNames() As List(Of FindOption)
        Dim foList As New List(Of FindOption)
        Dim fo As New FindOption
        fo.Field = "请选择"
        fo.DB_Field = ""
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "布类编号"
        fo.DB_Field = "BZ_No"
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "布类名称"
        fo.DB_Field = "BZ_Name"
        foList.Add(fo)
        Return foList
    End Function

    ''' <summary>
    ''' 按条件获取布类信息
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function BZ_GetByOption(ByVal oList As OptionList) As DtReturnMsg
        Dim paraMap As New Dictionary(Of String, Object)
        Dim sqlBuider As New StringBuilder
        sqlBuider.Append(SQL_BZ_Get)
        sqlBuider.Append("  WHERE 1=1  ")
        sqlBuider.Append(OptionClass_BuidSqlConditon(oList.FoList, paraMap))
        sqlBuider.Append(SQL_BZ_OrderBy)
        Return PClass.PClass.SqlStrToDt(sqlBuider.ToString, paraMap)
    End Function

    ''' <summary>
    ''' 获取布类信息
    ''' </summary>
    ''' <param name="sId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function BZ_GetById(ByVal sId As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_BZ_SelByID, "@ID", sId)
    End Function


    ''' <summary>
    ''' 增加一个布类
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function BZ_Add(ByVal dt As DataTable) As MsgReturn
        Dim Cnn As New SqlClient.SqlConnection
        Dim Da As New SqlClient.SqlDataAdapter
        Dim BZ_No As String = ""
        Dim Client_ID As Integer
        Dim returnMsg As New MsgReturn
        If dt.Rows.Count <> 1 Then
            returnMsg.IsOk = False
            returnMsg.Msg = "新增布类失败!"
            Return returnMsg
        End If
        BZ_No = dt.Rows(0)("BZ_No")
        Client_ID = dt.Rows(0)("Client_ID")
        If BZ_NameCheckDuplicate(dt.Rows(0)("BZ_No"), dt.Rows(0)("BZ_Name"), dt.Rows(0)("Client_ID"), 0) Then
            returnMsg.Msg = "布类编号[" & dt.Rows(0)("BZ_No") & "]布类名称[" & dt.Rows(0)("BZ_Name") & "]已存在一个同编号同名称!"
            Return returnMsg
        End If
        Try
            Dim msg As DtReturnMsg = SqlStrToDt(SQL_BZ_GetByNo, Cnn, Da, "@BZ_No", BZ_No)
            If msg.IsOk AndAlso msg.Dt.Rows.Count = 0 Then
                DvToDt(dt, msg.Dt, New List(Of String), True)
                DtToUpDate(msg.Dt, Cnn, Da)
                returnMsg.IsOk = True
                returnMsg.Msg = "布类[" & dt.Rows(0)("BZ_Name") & "]添加成功!"
            Else
                returnMsg.IsOk = False
                returnMsg.Msg = "布类编号[" & dt.Rows(0)("BZ_No") & "]已经存在!"
            End If
        Catch ex As Exception
            DebugToLog(ex)
            returnMsg.IsOk = False
            returnMsg.Msg = "新增布类失败!"
        Finally
            Da.Dispose()
            Cnn.Dispose()
        End Try
        Return returnMsg
    End Function



    ''' <summary>
    '''修改一个布类
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function BZ_Save(ByVal dt As DataTable) As MsgReturn
        Dim Cnn As New SqlClient.SqlConnection
        Dim Da As New SqlClient.SqlDataAdapter
        Dim gId As String = ""
        Dim returnMsg As New MsgReturn
        If dt.Rows.Count <> 1 Then
            returnMsg.IsOk = False
            returnMsg.Msg = "修改布类失败!"
            Return returnMsg
        End If
        gId = dt.Rows(0)("ID")
        If BZ_NameCheckDuplicate(dt.Rows(0)("BZ_No"), dt.Rows(0)("BZ_Name"), dt.Rows(0)("Client_ID"), gId) Then
            returnMsg.Msg = "布类编号[" & dt.Rows(0)("BZ_No") & "]布类名称[" & dt.Rows(0)("BZ_Name") & "]已存在一个同编号同名称!"
            Return returnMsg
        End If
        Try
            Dim msg As DtReturnMsg = SqlStrToDt(SQL_BZ_GetByID, Cnn, Da, "@ID", gId)
            If msg.IsOk AndAlso msg.Dt.Rows.Count = 1 Then
                DvUpdateToDt(dt, msg.Dt, New List(Of String))
                DtToUpDate(msg.Dt, Cnn, Da)
                returnMsg.IsOk = True
                returnMsg.Msg = "布类[" & dt.Rows(0)("BZ_Name") & "]保存成功!"
            Else
                returnMsg.IsOk = False
                returnMsg.Msg = "布类[" & dt.Rows(0)("BZ_Name") & "]不存在!"
            End If
        Catch ex As Exception
            DebugToLog(ex)
            returnMsg.IsOk = False
            returnMsg.Msg = "修改布类失败!"
        Finally
            Da.Dispose()
            Cnn.Dispose()
        End Try
        Return returnMsg
    End Function

    ''' <summary>
    ''' 检查布类编号的是否重复
    ''' </summary>
    ''' <param name="BZ_No"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function BZ_NameCheckDuplicate(ByVal BZ_No As String, ByVal BZ_Name As String, ByVal Client_ID As Integer, ByVal ID As Integer) As Boolean
        Dim P As New Dictionary(Of String, Object)
        P.Add("BZ_No", BZ_No)
        P.Add("BZ_Name", BZ_Name)
        P.Add("Client_ID", Client_ID)
        P.Add("ID", ID)
        Dim r As MsgReturn = SqlStrToOneStr(SQL_BZ_NameCheckDuplicate, P)
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
    ''' 生成新的布类ID 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function BZ_GetNewID(ByVal startNo As String) As String
        Dim paraMap As New Dictionary(Of String, Object)
        paraMap.Add("@DB_Str", "T10002_BZ")
        paraMap.Add("@Id_Str", startNo)
        paraMap.Add("@Field", "BZ_No")
        paraMap.Add("@Zero", "3")
        Dim msgID As MsgReturn = SqlStrToOneStr("GetTableID_NoDate", paraMap, True)
        If msgID.IsOk Then
            Return msgID.Msg
        Else
            Return ""
        End If
    End Function


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="ID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function BZ_Del(ByVal ID As String)
        Dim sqlbuider As New StringBuilder()
        sqlbuider.AppendLine(" insert into T10002_BZ_Del (ID,BZ_No,BZ_Name, CP_Name,CP_No,BZ_Price,BZ_Unit,BZ_Spec,BZ_Type_ID,BZ_Remark, ")
        sqlbuider.AppendLine(" BZ_FindHelper,Founder,Found_Date,Upd_User,Upd_Date,Client_ID, DelUser) ")
        sqlbuider.AppendLine(" select ID,BZ_No,BZ_Name, CP_Name,CP_No,BZ_Price,BZ_Unit,BZ_Spec,BZ_Type_ID,BZ_Remark, ")
        sqlbuider.AppendLine("BZ_FindHelper,Founder,Found_Date,Upd_User,Upd_Date,Client_ID, @DelUser from T10002_BZ where ID=@ID ")
        sqlbuider.AppendLine(" insert into T10009_BzcLinkBz_Del ( BZC_ID,BZ_ID,Client_Bzc,PF_ID,DelUser) select BZC_ID,BZ_ID,Client_Bzc,PF_ID,@DelUser from T10009_BzcLinkBz where BZ_ID=@ID ")
        sqlbuider.AppendLine(" insert into T10111_ClientLinkBZ_Del (Client_ID,BZ_ID,DelUser) select Client_ID,BZ_ID,@DelUser from T10111_ClientLinkBZ_Del where BZ_ID=@ID")
        sqlbuider.AppendLine(SQL_BZ_DelByid)
        Dim p As New Dictionary(Of String, Object)
        p.Add("ID", ID)
        p.Add("DelUser", User_Name)
        Return RunSQL(sqlbuider.ToString, p)
    End Function
#End Region




#Region "物料"

    Public Function WL_ReNew(ByVal Old_ID As Integer, ByVal New_No As String) As MsgReturn
        Dim P As New Dictionary(Of String, Object)
        Dim R As New MsgReturn
        P.Add("Old_ID", Old_ID)
        Dim S As New Dictionary(Of String, String)
        S.Add("T", "select top 1 * from T10001_WL where ID=@Old_ID")
        Using H As New DtHelper(S, P)
            If H.IsOk Then
                If H.DtList("T").Rows.Count > 0 Then
                    If IsNull(H.DtList("T").Rows(0)("Wl_Qty"), 0) < 10 Then
                        Dim Row As DataRow = H.DtList("T").NewRow
                        For Each C As DataColumn In H.DtList("T").Columns
                            If C.ColumnName <> "ID" Then
                                Row(C) = H.DtList("T").Rows(0)(C)
                            End If
                        Next
                        Row("WL_No") = New_No
                        Row("WL_Cost") = 0
                        Row("WL_Qty") = 0
                        Row("WL_Disable") = 0
                        H.DtList("T").Rows.Add(Row)
                        H.Update("T", False)
                        Dim Rt As MsgReturn = H.SelectOneValue("select top 1 ID from T10001_WL where WL_No=@New_No order by ID desc", "New_No", New_No)
                        If Rt.IsOk Then
                            Dim New_Id As Long = Val(Rt.Msg)
                            Dim SQL As New System.Text.StringBuilder("")
                            Dim DS As New Dictionary(Of String, String)

                            P.Add("New_Id", New_Id)
                            SQL.AppendLine("update T10001_WL set WL_NewID=@New_Id,WL_Disable=1 where id=@Old_id")

                            SQL.AppendLine("update T10005_GYList set WL_ID=@New_Id where WL_ID=@Old_id")
                            SQL.AppendLine("update T10008_GXJ_WL set WL_ID=@New_Id where WL_ID=@Old_id")
                            SQL.AppendLine("update T10011_BZC_PFList set WL_ID=@New_Id where WL_ID=@Old_id")
                            SQL.AppendLine("update T10013_RB_PFList set WL_ID=@New_Id where WL_ID=@Old_id")
                            SQL.AppendLine("update T10015_DXGYList set WL_ID=@New_Id where WL_ID=@Old_id")
                            DS.Add("1", SQL.ToString)

                            R = H.UpdateAll(True, DS, P)
                            If R.IsOk Then
                                R.Msg = New_Id
                            End If
                        Else
                            R.IsOk = False
                            R.Msg = "物料[" & H.DtList("T").Rows(0)("WL_Name") & "]转换失败!"
                        End If
                    Else
                        R.IsOk = False
                        R.Msg = "物料[" & H.DtList("T").Rows(0)("WL_Name") & "]库存大于10,不能进行转换!"
                    End If
                Else
                    R.IsOk = False
                    R.Msg = "物料已经不存在!"
                End If
            Else
                R.IsOk = False
                R.Msg = "转换失败!" & H.Msg
            End If
        End Using
        Return R
    End Function



    Public Function WL_GetGoodsType(ByVal WL_No As String) As MsgReturn
        Return PClass.PClass.SqlStrToOneStr(SQL_WL_GetGoodsType, "WL_No", WL_No)
    End Function
    ''' <summary>
    ''' 获取所有物料信息
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function WL_GetAll() As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_WL_Get)
    End Function

    ''' <summary>
    ''' 获取查询条件集合
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function WL_GetConditionNames() As List(Of FindOption)
        Dim foList As New List(Of FindOption)
        Dim fo As New FindOption
        fo.Field = "请选择"
        fo.DB_Field = ""
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "物料编号"
        fo.DB_Field = "WL_No"
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "物料名称"
        fo.DB_Field = "WL_Name"
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "供应商"
        fo.DB_Field = "Supplier_Name"
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "物料规格"
        fo.DB_Field = "WL_Spec"
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "模糊搜索"
        fo.DB_Field = " "
        fo.Field_Operator = Enum_Operator.Operator_Like_Both
        fo.SQL = "(WL_No %Like% or WL_Name %Like% or Supplier_Name %Like% or  WL_Spec %Like% or WL_FindHelper %Like%  or WL_Qty %Like%)"
        fo.Sign = "%Like%"
        foList.Add(fo)

        Return foList
    End Function

    ''' <summary>
    ''' 按条件获取物料信息
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function WL_GetByOption(ByVal oList As OptionList) As DtReturnMsg
        Dim paraMap As New Dictionary(Of String, Object)
        Dim sqlBuider As New StringBuilder
        sqlBuider.Append(SQL_WL_Get)
        sqlBuider.Append("  WHERE 1=1  ")
        sqlBuider.Append(OptionClass.OptionClass_BuidSqlConditon(oList.FoList, paraMap))
        sqlBuider.Append(SQL_WL_OrderBy)
        Return PClass.PClass.SqlStrToDt(sqlBuider.ToString, paraMap)
    End Function

    ''' <summary>
    ''' 获取物料信息
    ''' </summary>
    ''' <param name="sId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function WL_GetById(ByVal sId As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_WL_SelByID, "@ID", sId)
    End Function

    ''' <summary>
    ''' 获取装配物料基本信息
    ''' </summary>
    ''' <param name="WL_No"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function WL_AssembleGetByWL_No(ByVal WL_No As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_WL_AssembleSelByWL_No, "@WL_No", WL_No)
    End Function


    ''' <summary>
    ''' 增加一个物料
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function WL_Add(ByVal dt As DataTable, ByVal dtlist As DataTable, ByVal IsAssemble As Boolean) As MsgReturn
        Dim msg As New DtListReturnMsg
        Dim sqlMap As New Dictionary(Of String, String)
        Dim paraMap As New Dictionary(Of String, Object)
        Dim Cnn As New SqlClient.SqlConnection
        Dim Da As New SqlClient.SqlDataAdapter
        Dim WL_No As String = dt.Rows(0)("WL_No")

        Dim returnMsg As New MsgReturn
        If dt.Rows.Count <> 1 Then
            returnMsg.IsOk = False
            returnMsg.Msg = "新增物料失败!"
            Return returnMsg
        End If
        paraMap.Add("WL_No", WL_No)
        If IsAssemble Then
            Try
                sqlMap.Add("Table", SQL_WL_GetByNo)
                sqlMap.Add("List", SQL_WL_AssembleSelByWL_No)
                msg = SqlStrToDt(sqlMap, paraMap)
                'Dim msg As DtReturnMsg = SqlStrToDt(SQL_WL_GetByNo, Cnn, Da, "@WL_No", WL_No)
                'Dim msg_list As DtReturnMsg = SqlStrToDt(SQL_WL_AssembleSelByWL_No, Cnn, Da, "@WL_No", WL_No)
                'If msg.IsOk AndAlso msg.Dt.Rows.Count = 0 Then
                '    DvToDt(dt, msg.Dt, New List(Of String), True)
                '    DvToDt(dtlist, msg_list.Dt, New List(Of String), True)
                '    DtToUpDate(msg.Dt, Cnn, Da)
                '    DtToUpDate(msg_list.Dt, Cnn, Da)
                '    returnMsg.IsOk = True
                '    returnMsg.Msg = "物料[" & dt.Rows(0)("WL_Name") & "]添加成功!"
                'Else
                '    returnMsg.IsOk = False
                '    returnMsg.Msg = "物料编号[" & dt.Rows(0)("WL_No") & "]已经存在!"
                'End If
                If msg.DtList("Table").Rows.Count = 0 Then
                    DvToDt(dt, msg.DtList("Table"), New List(Of String), True)
                    DvToDt(dtlist, msg.DtList("List"), New List(Of String), True)
                    Dim TmSQL As String = "insert into Bill_Barcode (No_ID,NO_Type)values('" & WL_No & "'," & BillType.WL & ")"
                    DtToUpDate(msg, TmSQL)
                    returnMsg.Msg = "物料[" & dt.Rows(0)("WL_Name") & "]添加成功!"
                    returnMsg.IsOk = True
                Else
                    returnMsg.IsOk = False
                    returnMsg.Msg = "物料编号[" & dt.Rows(0)("WL_No") & "]已经存在!"
                End If

            Catch ex As Exception
                DebugToLog(ex)
                returnMsg.IsOk = False
                returnMsg.Msg = "新增物料失败!"
            Finally
                Da.Dispose()
                Cnn.Dispose()
            End Try
        Else
            Try
                Dim msg_Table As DtReturnMsg = SqlStrToDt(SQL_WL_GetByNo, Cnn, Da, "@WL_No", WL_No)
                If msg_Table.IsOk AndAlso msg_Table.Dt.Rows.Count = 0 Then
                    DvToDt(dt, msg_Table.Dt, New List(Of String), True)
                    DtToUpDate(msg_Table.Dt, Cnn, Da)
                    returnMsg.IsOk = True
                    returnMsg.Msg = "物料[" & dt.Rows(0)("WL_Name") & "]添加成功!"
                Else
                    returnMsg.IsOk = False
                    returnMsg.Msg = "物料编号[" & dt.Rows(0)("WL_No") & "]已经存在!"
                End If

            Catch ex As Exception
                DebugToLog(ex)
                returnMsg.IsOk = False
                returnMsg.Msg = "新增物料失败!"
            Finally
                Da.Dispose()
                Cnn.Dispose()
            End Try
        End If

        Return returnMsg
    End Function



    ''' <summary>
    '''修改一个物料
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function WL_Save(ByVal dt As DataTable, ByVal dtlist As DataTable, ByVal IsAssemble As Boolean) As MsgReturn
        Dim msg As New DtListReturnMsg
        Dim sqlMap As New Dictionary(Of String, String)
        Dim paraMap As New Dictionary(Of String, Object)
        Dim Cnn As New SqlClient.SqlConnection
        Dim Da As New SqlClient.SqlDataAdapter
        Dim gId As String = ""
        Dim returnMsg As New MsgReturn
        If dt.Rows.Count <> 1 Then
            returnMsg.IsOk = False
            returnMsg.Msg = "修改物料失败!"
            Return returnMsg
        End If
        gId = dt.Rows(0)("ID")
        If WL_NameCheckDuplicate(dt.Rows(0)("WL_No"), gId) Then
            returnMsg.Msg = "物料编号[" & dt.Rows(0)("WL_No") & "]已存在!"
            Return returnMsg
        End If
        paraMap.Add("ID", gId)
        paraMap.Add("WL_No", dt.Rows(0)("WL_No"))
        If IsAssemble Then
            Try
                sqlMap.Add("Table", SQL_WL_GetByID)
                sqlMap.Add("List", SQL_WL_AssembleSelByWL_No)
                msg = SqlStrToDt(sqlMap, paraMap)
                If msg.IsOk AndAlso msg.DtList("Table").Rows.Count = 1 Then
                    Dim P As New List(Of String)
                    P.Add("WL_Qty")
                    If IsNull(msg.DtList("Table").Rows(0).Item("WL_Qty"), 0) <> 0 Then
                        P.Add("WL_Cost")
                    End If
                    DvUpdateToDt(dt, msg.DtList("Table"), P)
                    DvToDt(dtlist, msg.DtList("List"), New List(Of String))
                    Dim TmSQL As String = "insert into Bill_Barcode (No_ID,NO_Type)values('" & dt.Rows(0)("WL_No") & "'," & BillType.WL & ")"
                    DtToUpDate(msg, TmSQL)
                    returnMsg.Msg = "物料[" & dt.Rows(0)("WL_Name") & "]保存成功!"
                    returnMsg.IsOk = True
                Else
                    returnMsg.IsOk = False
                    returnMsg.Msg = "物料[" & dt.Rows(0)("WL_Name") & "]不存在!"
                End If
            Catch ex As Exception
                DebugToLog(ex)
                returnMsg.IsOk = False
                returnMsg.Msg = "修改物料失败!"
            Finally
                Da.Dispose()
                Cnn.Dispose()
            End Try
        Else
            Try
                Dim msg_Table As DtReturnMsg = SqlStrToDt(SQL_WL_GetByID, Cnn, Da, "@ID", gId)
                If msg_Table.IsOk AndAlso msg_Table.Dt.Rows.Count = 1 Then
                    Dim P As New List(Of String)
                    P.Add("WL_Qty")
                    If IsNull(msg_Table.Dt.Rows(0).Item("WL_Qty"), 0) <> 0 Then
                        P.Add("WL_Cost")
                    End If
                    DvUpdateToDt(dt, msg_Table.Dt, P)
                    DtToUpDate(msg_Table.Dt, Cnn, Da)
                    returnMsg.IsOk = True
                    returnMsg.Msg = "物料[" & dt.Rows(0)("WL_Name") & "]保存成功!"
                Else
                    returnMsg.IsOk = False
                    returnMsg.Msg = "物料[" & dt.Rows(0)("WL_Name") & "]不存在!"
                End If
            Catch ex As Exception
                DebugToLog(ex)
                returnMsg.IsOk = False
                returnMsg.Msg = "修改物料失败!"
            Finally
                Da.Dispose()
                Cnn.Dispose()
            End Try
        End If     
        Return returnMsg
    End Function

    ''' <summary>
    ''' 检查物料编号的是否重复
    ''' </summary>
    ''' <param name="WL_No"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function WL_NameCheckDuplicate(ByVal WL_No As String, ByVal ID As Integer) As Boolean
        Dim P As New Dictionary(Of String, Object)
        P.Add("WL_No", WL_No)
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
    ''' 生成新的物料ID 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function WL_GetNewID(ByVal startNo As String) As String
        Dim paraMap As New Dictionary(Of String, Object)
        paraMap.Add("@DB_Str", "T10001_WL")
        paraMap.Add("@Id_Str", startNo)
        paraMap.Add("@Field", "WL_No")
        paraMap.Add("@Zero", "3")
        Dim msgID As MsgReturn = SqlStrToOneStr("GetTableID_NoDate", paraMap, True)
        If msgID.IsOk Then
            Return msgID.Msg
        Else
            Return ""
        End If
    End Function

    ''' <summary>
    ''' 物料启用
    ''' </summary>
    ''' <param name="ID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function WL_Endable(ByVal ID As String) As MsgReturn
        Dim R As New MsgReturn
        R = RunSQL(SQL_WL_Enable, "@ID", ID)
        If Val(R.Msg) > 0 Then
            R.IsOk = True
            R.Msg = "启用成功！"
        Else
            R.IsOk = False
            R.Msg = "启用失败！"
        End If
        Return R
    End Function


    ''' <summary>
    '''获取色号空表单
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>


    Public Function Get_BZC() As DtReturnMsg
        Dim R As New DtReturnMsg
        R = SqlStrToDt(SQL_BZC)
        Return R

    End Function

    Public Function BZC_PF_UpDate(ByVal BZC_ID As Integer, ByVal ID As Integer, ByVal IsOk As Boolean) As MsgReturn
        Dim P As New Dictionary(Of String, Object)
        Dim R As MsgReturn
        P.Add("BZC_ID", BZC_ID)
        P.Add("ID", ID)
        P.Add("IsOk", IsOk)

        R = RunSQL(SQL_UPDATE_PF_ALL, "@BZC_ID", BZC_ID)
        If R.IsOk Then
            R = RunSQL(SQL_UPDATE_PF, P)
            Return R
        End If
        Return R
    End Function


    ''' <summary>
    ''' 物料删除
    ''' </summary>
    ''' <param name="ID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function WL_Del(ByVal ID As String) As MsgReturn
        Dim R As New MsgReturn
        Dim msg As DtReturnMsg = PClass.PClass.SqlStrToDt(SQL_WL_CheckDel, "@ID", ID)
        If msg.IsOk AndAlso msg.Dt.Rows.Count = 0 Then
            Return RunSQL(SQL_WL_DelByid, "@ID", ID)
        Else
            R.IsOk = False
            R.Msg = "[" & msg.Dt.Rows(0)("WL_Name") & "]" & "[" & msg.Dt.Rows(0)("WL_Spec") & "]" & "已经被引用,不能删除！"
            Return R
        End If
    End Function
#End Region


#Region "树形FG"

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="_DtList"></param>
    ''' <param name="_fg"></param>
    ''' <param name="_GySet"></param>
    ''' <param name="F"></param>
    ''' <remarks></remarks>
    Public Sub CreateTreeiew(ByVal _DtList As DataTable, ByVal _fg As FG, ByVal _GySet As Dictionary(Of String, C1.Win.C1FlexGrid.Node), ByVal F As BaseForm, ByVal RootColsName As String)
        Dim E As Boolean = _fg.CanEditing
        _GySet.Clear()
        _fg.Rows.Count = 1
        _fg.SubtotalPosition = SubtotalPositionEnum.AboveData
        _fg.Rows.Count = 1
        _fg.Tree.Column = _fg.Cols(RootColsName).Index
        _fg.Tree.LineStyle = Drawing2D.DashStyle.Solid
        _fg.Tree.Style = TreeStyleFlags.SimpleLeaf
        _fg.AllowMerging = AllowMergingEnum.Free
        Dim nodeIndex As Int16 = 1
        '  Dim drsE As DataRow() = dtList.Select("  IsGY=1")
        For Each dr As DataRow In _DtList.Rows
            If IsNull(dr("IsGY"), False) = True Then
                Dim GYSetID As String = IsNull(dr("GYSetID"), 0)
                If _GySet.ContainsKey(GYSetID) Then
                    Exit Sub
                End If
                Dim ParentNode As C1.Win.C1FlexGrid.Node = _fg.Rows.InsertNode(nodeIndex, 0)

                DrToGoodsNode(dr("GY_Name"), dr("GYSetID"), IsNull(dr("IsPageTwo"), 0), ParentNode)
                _GySet.Add(dr("GYSetID"), ParentNode)
            ElseIf IsNull(dr("IsGY"), False) = False AndAlso IsNull(dr("GYSetID"), 0) > 0 Then
                If _GySet.ContainsKey(IsNull(dr("GYSetID"), 0)) = False Then
                    Continue For
                End If
                Dim parentItem As Node = _GySet(IsNull(dr("GYSetID"), 0))
                InsertGoodsNode(dr, dr("GYSetID"), parentItem, _fg, F)
            ElseIf IsNull(dr("IsGY"), False) = False AndAlso IsNull(dr("GYSetID"), 0) = 0 Then
                InsertGoodsNode(dr, 0, Nothing, _fg, F)
            End If
            nodeIndex = nodeIndex + 1
        Next
        _fg.ReAddIndex()
        _fg.CanEditing = E
        ' CaculateSumAmount()
    End Sub

    Public Sub DrToGoodsNode(ByVal GY_Name As String, ByVal GYSetID As Integer, ByVal IsPageTwo As Boolean, ByVal Node As C1.Win.C1FlexGrid.Node)
        Node.Row("DyingStep") = GY_Name
        Node.Row("WL_Name") = GY_Name
        Node.Row("GY_Name") = GY_Name
        Node.Row("WL_No") = GY_Name
        Node.Row("WL_Spec") = GY_Name
        Node.Row("IsPageTwo") = IsPageTwo
        Node.Row("WL_ID") = -1
        Node.Row("GYSetID") = GYSetID
        Node.Row("Qty") = ""
        Node.Row("IsGY") = True
        Node.Row.AllowMerging = True
        SetFGTreeRow(Node)
    End Sub



    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub InsertGoodsNode(ByVal dr As DataRow, ByVal _GYSetID As Integer, ByVal parentNode As Node, ByVal _fg As FG, ByVal F As BaseForm, Optional ByVal isAddNew As Boolean = False)
        Try

            _fg.FinishEditing(True)
            Dim rowIndex As Integer
            Dim price As Double = 0
            Dim qty As Double = 0
            '插入套装配件
            If parentNode IsNot Nothing Then
                rowIndex = parentNode.AddNode(NodeTypeEnum.LastChild, IsNull(dr("DyingStep"), ""), dr("WL_ID"), Nothing).Row.Index  '_fg.Rows.InsertNode(rowIndex, 2)
            Else
                rowIndex = _fg.Rows.InsertNode(_fg.Rows.Count, 0).Row.Index
                _fg.ReAddIndex()
            End If
            'If rowIndex = 1 Then
            '    MsgBox(11)
            'End If

            _fg.Item(rowIndex, "IsGY") = False
            _fg.Item(rowIndex, "GYSetID") = _GYSetID
            _fg.Item(rowIndex, "DyingStep") = IsNull(dr("DyingStep"), "")
            _fg.Item(rowIndex, "WL_ID") = IsNull(dr("WL_ID"), 0)
            _fg.Item(rowIndex, "GYSetID") = dr("GYSetID")
            _fg.Item(rowIndex, "WL_No") = IsNull(dr("WL_No"), "")
            _fg.Item(rowIndex, "IsPageTwo") = IsNull(dr("IsPageTwo"), 0)
            _fg.Item(rowIndex, "WL_Name") = IsNull(dr("WL_Name"), "")
            _fg.Item(rowIndex, "GY_Name") = dr("GY_Name")
            _fg.Item(rowIndex, "WL_Spec") = IsNull(dr("WL_Spec"), "")
            _fg.Item(rowIndex, "Qty") = IsNull(dr("Qty"), 0)


        Catch ex As Exception
            F.ShowErrMsg("插入商品节点[" & IsNull(dr("WL_Name"), "") & "失败！错误：" & ex.Message)
        End Try
    End Sub



    ''' <summary>
    ''' 设置套装行的颜色
    ''' </summary>
    ''' <param name="Node"></param>
    ''' <remarks></remarks>
    Friend Sub SetFGTreeRow(ByVal Node As C1.Win.C1FlexGrid.Node)
        'Dim f As New Font(Fg1.Styles(0).Font, FontStyle.Bold)
        'ParentNode.Row.StyleNew.Font = f
        Node.Row.StyleNew.BackColor = Color.DodgerBlue
        Node.Row.StyleNew.ForeColor = Color.White
        Node.Row.StyleNew.TextAlign = TextAlignEnum.LeftCenter
        Node.Row.StyleNew.Font = New Font(Node.Row.StyleNew.Font, FontStyle.Bold)
    End Sub

    ''' <summary>
    ''' 判断是否毛坯料
    ''' </summary>
    ''' <param name="WL_No"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function WL_RawGetByWL_No(ByVal WL_No As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_WL_RawGetByNo, "@WL_No", WL_No)
    End Function

    ''' <summary>
    ''' 判断是否可以用作装配组件
    ''' </summary>
    ''' <param name="WL_No"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function AssembleGetByWL_No(ByVal WL_No As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_WL_AssembleByNo, "@WL_No", WL_No)
    End Function


#End Region


End Module
