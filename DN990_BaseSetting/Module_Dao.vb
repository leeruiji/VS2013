Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports BaseClass
Module Module_Dao

    Public Function GetConditionValues(ByVal tableName As String, ByVal fieldName As String, ByVal likeValue As String) As DtReturnMsg
        Dim sqlBuider As New StringBuilder
        sqlBuider.Append("select distinct(")
        sqlBuider.Append(fieldName)
        sqlBuider.Append(") as ConditionValue ")
        sqlBuider.Append("from ")
        sqlBuider.Append(tableName)
        sqlBuider.Append("   where ")
        sqlBuider.Append(fieldName)
        sqlBuider.Append(" like @")
        sqlBuider.Append(fieldName)
        sqlBuider.Append(" order by ")
        sqlBuider.Append(fieldName)

        Dim R As New DtReturnMsg
        Try
            R = SqlStrToDt(sqlBuider.ToString, "@" & fieldName, likeValue & "%")
        Catch ex As Exception
            DebugToLog(ex)
        End Try
        Return R
    End Function
#Region "职位"


    ''' <summary>
    ''' 获取对应职位信息
    ''' </summary>
    ''' <param name="id"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Job_GetById(ByVal id As String) As DtReturnMsg
        Dim sql As New StringBuilder
        sql.Append(" select J.*,D.Dept_Name from (select * from T15003_Job where ID='")
        sql.Append(id)
        sql.Append("') J ")
        sql.Append("left join T15000_Department D on J.Job_Dept=D.Dept_No ")
        Return PClass.PClass.SqlStrToDt(sql.ToString)
    End Function

    ''' <summary>
    ''' 获取所有职位
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Job_GetAll() As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_Job_GetAllJob)
    End Function

    ''' <summary>
    ''' 获取所有职位
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Job_GetByDept(ByVal deptNo As String) As DtReturnMsg
        Dim sqlbuider As New StringBuilder
        sqlbuider.AppendLine(SQL_Job_GetAllJob)
        If deptNo <> "0" Then
            sqlbuider.Append(" where  J.Job_Dept like  '")
            sqlbuider.Append(deptNo & "%'")
        End If
     
        sqlbuider.Append("order by  J.Job_Dept ,Job_No")
        Return PClass.PClass.SqlStrToDt(sqlbuider.ToString)
    End Function
    ''' <summary>
    ''' 生成新的职位ID 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Job_GetNewID() As String
        Dim paraMap As New Dictionary(Of String, Object)
        paraMap.Add("@DB_Str", "T15003_Job")
        paraMap.Add("@Id_Str", "J")
        paraMap.Add("@Field", "Job_No")
        paraMap.Add("@Zero", "3")
        Dim msgID As MsgReturn = SqlStrToOneStr("GetTableID_NoDate", paraMap, True)
        If msgID.IsOk Then
            Return msgID.Msg
        Else
            Return ""
        End If
    End Function

    ''' <summary>
    ''' 增加一个职位
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Job_Add(ByVal dt As DataTable) As MsgReturn
        Dim Cnn As New SqlClient.SqlConnection
        Dim Da As New SqlClient.SqlDataAdapter
        Dim Job_No As String = ""

        Dim returnMsg As New MsgReturn
        If dt.Rows.Count <> 1 Then
            returnMsg.IsOk = False
            returnMsg.Msg = "新增职位失败!"
            Return returnMsg
        End If
        Job_No = dt.Rows(0)("Job_No")
        Try
            Dim msg As DtReturnMsg = SqlStrToDt(SQL_Job_GetByNo, Cnn, Da, "@Job_No", Job_No)
            If msg.IsOk AndAlso msg.Dt.Rows.Count = 0 Then
                DvToDt(dt, msg.Dt, New List(Of String), True)
                DtToUpDate(msg.Dt, Cnn, Da)
                returnMsg.IsOk = True
                returnMsg.Msg = "职位[" & dt.Rows(0)("Job_Name") & "]添加成功!"
            Else
                returnMsg.IsOk = False
                returnMsg.Msg = "职位编号[" & dt.Rows(0)("Job_No") & "已经存在!"
            End If
        Catch ex As Exception
            DebugToLog(ex)
            returnMsg.IsOk = False
            returnMsg.Msg = "新增职位失败!"
        Finally
            Da.Dispose()
            Cnn.Dispose()
        End Try
        Return returnMsg
    End Function
    ''' <summary>
    ''' 修改职位信息
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Job_Save(ByVal dt As DataTable) As MsgReturn
        Dim Cnn As New SqlClient.SqlConnection
        Dim Da As New SqlClient.SqlDataAdapter
        Dim returnMsg As New MsgReturn
        If dt.Rows.Count <> 1 Then
            returnMsg.IsOk = False
            returnMsg.Msg = "修改位失败!"
            Return returnMsg
        End If
        Dim jobId As String = dt.Rows(0)("ID")
        If Job_NameCheckDuplicate(dt.Rows(0)("Job_No"), jobId) Then
            returnMsg.Msg = "职位编号[" & dt.Rows(0)("Job_No") & "]已存在!"
            Return returnMsg
        End If
        Try
            Dim msg As DtReturnMsg = SqlStrToDt(SQL_Job_GetByid, Cnn, Da, "ID", jobId)
            If msg.IsOk AndAlso msg.Dt.Rows.Count = 1 Then
                DvUpdateToDt(dt, msg.Dt, New List(Of String))
                DtToUpDate(msg.Dt, Cnn, Da)
                returnMsg.IsOk = True
            Else
                returnMsg.IsOk = False
                returnMsg.Msg = "职位编号[" & dt.Rows(0)("Job_No") & "]不存在"
            End If

        Catch ex As Exception
            DebugToLog(ex)
            returnMsg.IsOk = False
            returnMsg.Msg = "职位编号[" & dt.Rows(0)("Job_No") & "]修改错误"
        Finally
            Da.Dispose()
            Cnn.Dispose()
        End Try
        Return returnMsg
    End Function

    ''' <summary>
    ''' 检查布类编号的是否重复
    ''' </summary>
    ''' <param name="Job_No"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Job_NameCheckDuplicate(ByVal Job_No As String, ByVal ID As Integer) As Boolean
        Dim P As New Dictionary(Of String, Object)
        P.Add("Job_No", Job_No)
        P.Add("ID", ID)
        Dim r As MsgReturn = SqlStrToOneStr(SQL_Job_NameCheckDuplicate, P)
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
    ''' 
    ''' </summary>
    ''' <param name="jobId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Job_Del(ByVal jobId As String)
        Return RunSQL(SQL_Job_DelByid, "@ID", jobId)
    End Function
#End Region
#Region "部门及员工"



    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Public Function Department_GetDeptAll() As DtReturnMsg
        Dim sql As String = "select * from T15000_Department order by Dept_No"
        Return PClass.PClass.SqlStrToDt(sql)

    End Function

    Public Function Department_GetDeptById(ByVal id As String) As DtReturnMsg
        Dim sql As String = "select * from T15000_Department where Dept_No='" & id & "' order by Dept_No"
        Return PClass.PClass.SqlStrToDt(sql)
    End Function
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Department_GetNewEmployee_Dept(ByVal parentId As String) As String
        Try
            Dim sql As String
            Dim msg As New MsgReturn
            If parentId.Length >= 4 Then
                sql = "select top 1 Dept_No  from T15000_Department where Dept_No like '" & parentId & "%' order by Dept_No desc"
            Else
                parentId = "D"
                sql = "select top 1 Dept_No  from T15000_Department where len( Dept_No)=4  order by Dept_No desc"
            End If

            msg = SqlStrToOneStr(sql)
            Dim j As Integer = 3
            If msg.IsOk Then
                Dim s As String = ""
                Dim i As Integer
                If msg.Msg.Length = parentId.Length Then
                    i = 1
                ElseIf msg.Msg.Length = 0 Then
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
    '''=================================================
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Employee_GetEmployeeAll() As DtReturnMsg
        Dim sql As String = "select E.*,D.Dept_Name from V15001_Employee  E  left join T15000_Department D on E.Employee_Dept=D.Dept_No order by  Employee_Dept,Employee_Job, Employee_No  "
        Dim msgEmployee As DtReturnMsg = PClass.PClass.SqlStrToDt(sql)

        Return msgEmployee
    End Function

    ''' <summary>
    ''' 根据员工ID获取员工信息
    ''' </summary>
    ''' <param name="id"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Employee_GetById(ByVal id As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_Employee_GetByID, "@Employee_No", id)
    End Function

    ''' <summary>
    ''' 获取员工信息
    ''' </summary>
    ''' <param name="oList"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Employee_GetByOption(ByVal oList As List(Of FindOption)) As DtReturnMsg
        Dim paraMad As New Dictionary(Of String, Object)
        Dim sql As New StringBuilder
        sql.Append("  select TE.* ,Job.Job_Name ,(case when len(Employee_Dept)=7 then ")
        sql.Append(" (select top 1 Dept_Name from T15000_Department D where left(TE.Employee_Dept,4)=D.Dept_No) ")
        sql.Append(" else TD.Dept_Name end) as Dept_Name, ")
        sql.Append(" (case when len(Employee_Dept)=7 then ")
        sql.Append(" TD.Dept_Name else '' end )GroupName ")
        sql.Append(" ,dbo.GetAge(Employee_Birthdate,getdate())Age ")
        sql.Append(" from (select  ID,Employee_No,Employee_Name ,Employee_Dept,Employee_Job,Employee_Birthdate,Employee_Sex,Employee_FileType,Employee_FirstDate,Employee_IDCard,Employee_SignDate,Employee_Education,Employee_Phone,Employee_Contact,Employee_IsMarried,Employee_JiGuan,Employee_Room,Employee_Card,Employee_CardMakeDate,Employee_CardStartDate,Employee_IsShuiKa,Employee_QuitType,Employee_QuitDate from V15001_Employee where 1=1  ")
        sql.Append(BaseClass.OptionClass.OptionClass_BuidSqlConditon(oList, paraMad))
        sql.Append(" ) TE left join T15000_Department TD on TE.Employee_Dept=TD.Dept_No  ")
        sql.Append(" left join T15003_Job Job on Job.ID=Employee_Job  order by TE.Employee_No ")
        Dim Dtr As DtReturnMsg = PClass.PClass.SqlStrToDt(sql.ToString, paraMad)
        If Dtr.IsOk Then
            For Each r As DataRow In Dtr.Dt.Rows
                If r("Employee_FileType") <> F990031_Employee_Msg.EMPLOYEE_FILE_TYPE_LIZHI Then
                    r("Employee_QuitDate") = DBNull.Value
                    r("Employee_QuitType") = ""
                End If
            Next
        End If
        Return Dtr
    End Function


    ''' <summary>
    ''' 获取查询条件集合
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Employee_GetConditionNames() As List(Of FindOption)
        Dim foList As New List(Of FindOption)
        Dim fo As New FindOption
       

        fo = New FindOption
        fo.Field = "员工编号"
        fo.DB_Field = "Employee_No"
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "员工姓名"
        fo.DB_Field = "Employee_Name"
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "宿舍"
        fo.DB_Field = "Employee_Room"
        foList.Add(fo)
        Return foList
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Employee_GetNewID() As String
        Dim paraMap As New Dictionary(Of String, Object)
        paraMap.Add("@DB_Str", "V15001_Employee")
        paraMap.Add("@Id_Str", "E")
        paraMap.Add("@Field", "Employee_No")
        paraMap.Add("@Zero", "4")
        Dim msgID As MsgReturn = SqlStrToOneStr("GetTableID_NoDate", paraMap, True)
        If msgID.IsOk Then
            Return msgID.Msg
        Else
            Return ""
        End If
    End Function


    Public Function Employee_Del(ByVal id As String) As MsgReturn
        Dim sql As String = "Delete  from T15001_Employee where Employee_No='" & id & "' Delete from User_Info where Employee_No='" & id & "'"
        Return PClass.PClass.RunSQL(sql)
    End Function
    '''===================================================================
    Public Function User_GetAll() As DtReturnMsg
        Dim sql As String = "select U.*,D.Dept_Name from User_Info U left join T15000_Department D on U.User_Dept=D.Dept_No where Invalid=0 order by  User_Dept, User_ID"
        Dim msgUser As DtReturnMsg = PClass.PClass.SqlStrToDt(sql)


        Return msgUser
    End Function

    ''' <summary>
    '''根据用户编号获取用户信息
    ''' </summary>
    ''' <param name="userId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function User_GetById(ByVal userId As String) As DtReturnMsg
        Dim sql As New StringBuilder
        sql.Append(" select TE.*,TD.Dept_Name from (select * from User_Info where User_ID='")
        sql.Append(userId)
        sql.Append("') TE ")
        sql.Append("left join T15000_Department TD on TE.User_Dept=TD.Dept_No  ")
        Return PClass.PClass.SqlStrToDt(sql.ToString)
    End Function
    Public Function User_CheckExist(ByVal employeeID As String, Optional ByVal userId As String = "") As Integer
        Dim paraMap As New Dictionary(Of String, Object)
        Dim sql As New StringBuilder
        sql.Append(" select count(1) from User_Info where Employee_No=@Employee_No")
        paraMap.Add("@Employee_No", employeeID)
        If Not userId = "" Then
            sql.Append(" and  User_ID=@User_ID ")
            paraMap.Add("@User_ID", userId)
        End If
        Dim msg As DtReturnMsg = PClass.PClass.SqlStrToDt(sql.ToString, paraMap)
        If msg.IsOk Then
            Return msg.Dt.Rows.Count
        Else
            Return 0
        End If
    End Function

    ''' <summary>
    ''' 根据员工编号获取用户信息
    ''' </summary>
    ''' <param name="employeeId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function User_GetByEmployeeId(ByVal employeeId As String) As DtReturnMsg

        Dim sql As New StringBuilder
        sql.Append(" select TE.*,TD.Dept_Name from (select * from User_Info where Employee_No='")
        sql.Append(employeeId)
        sql.Append("') TE ")
        sql.Append("left join T15000_Department TD on TE.User_Dept=TD.Dept_No  ")
        Return PClass.PClass.SqlStrToDt(sql.ToString)
    End Function

    Public Function User_GetByName(ByVal name As String) As DtReturnMsg

        Dim sql As New StringBuilder
        sql.Append(" select TE.*,TD.Dept_Name from (select * from User_Info where User_Name='")
        sql.Append(name)
        sql.Append("') TE ")
        sql.Append("left join T15000_Department TD on TE.User_Dept=TD.Dept_No  order by TE.User_Name")
        Return PClass.PClass.SqlStrToDt(sql.ToString)
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function User_GetNewID() As String
        Dim paraMap As New Dictionary(Of String, Object)
        paraMap.Add("@DB_Str", "User_Info")
        paraMap.Add("@Id_Str", "U")
        paraMap.Add("@Field", "User_ID")
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
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Group_GetAll() As DtReturnMsg
        Dim sql As String = "Select * from User_Group"
        Return SqlStrToDt(sql)

    End Function

    Public Function User_UpdateStateByEmploeeID(ByVal _eId As String, ByVal Invalid As Boolean)
        Dim Cnn As New SqlClient.SqlConnection
        Dim Da As New SqlClient.SqlDataAdapter
        Dim dt As DataTable
        Dim sql As String
        Dim Employee_Dept As String = ""
        Try

            sql = "select top 1 * from User_Info where Employee_No=@Employee_No "
            dt = SqlStrToDt(sql, Cnn, Da, "Employee_No", _eId).Dt
            If dt.Rows.Count = 1 Then
                dt.Rows(0)("Invalid") = Invalid
                PClass.PClass.DtToUpDate(dt, Cnn, Da)
            End If

            Da.Dispose()
            Cnn.Dispose()
            Return True
        Catch ex As Exception
            DebugToLog(ex)
            Return False
        End Try
    End Function

#End Region

#Region "员工卡记录"
    ''' <summary>
    ''' 查看卡片记录
    ''' </summary>
    ''' <param name="card"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CardHistory_GetByCard(ByVal card As String)
        Dim sqlBuider = New StringBuilder
        sqlBuider.AppendLine("select ID, Employee_Name,Employee_No, Employee_Card,Employee_CardStartDate,Employee_CardEndDate from T15001_Employee  where  isnull(Employee_Card,'')<>''  and Employee_Card=@Card")
        sqlBuider.AppendLine(" union all ")
        sqlBuider.AppendLine(" select H.ID,E.Employee_Name,E.Employee_No,Card,StartDate,EndDate from T15004_CardHistory H left join T15001_Employee E on  H.ID=E.ID where  Employee_Card=@Card")
        Return PClass.PClass.SqlStrToDt(SQL_Card_GetHistoryByCard, "@Card", card)
    End Function
    ''' <summary>
    ''' 查看卡片记录
    ''' </summary>
    ''' <param name="_ID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CardHistory_GetByID(ByVal _ID As String)

        Dim sqlBuider = New StringBuilder
        sqlBuider.AppendLine("select ID, Employee_Name,Employee_No, Employee_Card,Employee_CardStartDate,Employee_CardEndDate from T15001_Employee  where  isnull(Employee_Card,'')<>''  and ID=@ID")
        sqlBuider.AppendLine(" union all ")
        sqlBuider.AppendLine(" select H.ID,E.Employee_Name,E.Employee_No,Card,StartDate,EndDate from T15004_CardHistory H left join T15001_Employee E on  H.ID=E.ID where H.ID=@ID")
        Return PClass.PClass.SqlStrToDt(sqlBuider.ToString, "@ID", _ID)
    End Function
#End Region
End Module
