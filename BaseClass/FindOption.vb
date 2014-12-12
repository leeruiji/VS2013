Imports System.Text
Imports PClass.PClass

''' <summary>
''' 搜索条件 参数
''' </summary>
''' <remarks></remarks>
Public Class FindOption
    Public FindOrder As Byte
    ''' <summary>
    ''' 操作符
    ''' </summary>
    ''' <remarks></remarks>
    Public Field_Operator As Enum_Operator

    Dim _DB_Field As String
    ''' <summary>
    ''' 数据库字段
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property DB_Field() As String
        Get
            Return _DB_Field
        End Get
        Set(ByVal value As String)
            _DB_Field = value
        End Set
    End Property

    Dim _Field As String
    ''' <summary>
    ''' 中文显示字段
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Field() As String
        Get
            Return _Field
        End Get
        Set(ByVal value As String)
            _Field = value
        End Set
    End Property


    Dim _Value As String
    ''' <summary>
    ''' 值1
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Value() As String
        Get
            Return _Value
        End Get
        Set(ByVal value As String)
            _Value = value
        End Set
    End Property
    Dim _Value2 As String
    ''' <summary>
    ''' 值2
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Value2() As String
        Get
            Return _Value2
        End Get
        Set(ByVal value As String)
            _Value2 = value
        End Set
    End Property


    Dim _SQL As String = ""
    ''' <summary>
    ''' 查询的时候,要代入SQL语句,要跟Replace连用
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SQL() As String
        Get
            Return _SQL
        End Get
        Set(ByVal value As String)
            _SQL = value
        End Set
    End Property

    Dim _Sign As String = ""
    ''' <summary>
    ''' 语句替换部分
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Sign()
        Get
            Return _Sign
        End Get
        Set(ByVal value)
            _Sign = value
        End Set
    End Property


    Dim _IsOr As Boolean = False
    ''' <summary>
    ''' And 还是 Or
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property IsOr() As Boolean
        Get
            Return _IsOr
        End Get
        Set(ByVal value As Boolean)
            _IsOr = value
        End Set
    End Property


    Public Function Copy() As FindOption
        Dim fo As New FindOption
        fo.DB_Field = Me.DB_Field
        fo.Field = Me.Field
        fo.Sign = Me.Sign
        fo.SQL = Me.SQL
        fo.Value = Me.Value
        fo.Value2 = Me.Value2
        fo.IsOr = fo.IsOr
        Return fo
    End Function
End Class


''' <summary>
''' 搜索条件 参数
''' </summary>
''' <remarks></remarks>
Public Class OptionList

    Dim oList As New List(Of FindOption)

    Dim _sql As String = ""
    Public Property Sql() As String
        Get
            Return _sql
        End Get
        Set(ByVal value As String)
            _sql = value
        End Set
    End Property

    Dim _sqlIndex As String = ""
    Public Property SqlIndex() As String
        Get
            Return _sqlIndex
        End Get
        Set(ByVal value As String)
            _sqlIndex = value
        End Set
    End Property

    Dim _AfterWhere As String
    ''' <summary>
    ''' 附加查询
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property AfterWhere() As String
        Get
            Return _AfterWhere
        End Get
        Set(ByVal value As String)
            _AfterWhere = value
        End Set
    End Property

    Public Property FoList() As List(Of FindOption)
        Get
            Return oList
        End Get
        Set(ByVal value As List(Of FindOption))
            oList = value
        End Set
    End Property


    Private _OrderBy As String = ""
    ''' <summary>
    ''' 排序字段 可以带Desc ,如果没有设置的话使用 默认设置
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property OrderBy() As String
        Get
            Return _OrderBy
        End Get
        Set(ByVal value As String)
            _OrderBy = value
        End Set
    End Property
End Class

''' <summary>
''' SQL语句计算操作符
''' </summary>
''' <remarks></remarks>
Public Enum Enum_Operator
    ''' <summary>
    ''' =(等于)
    ''' </summary>
    ''' <remarks></remarks>
    Operator_Equal = 0
    ''' <summary>
    ''' Like(后面加%)
    ''' </summary>
    ''' <remarks></remarks>
    Operator_Like = 1
    ''' <summary>
    ''' (不等于)
    ''' </summary>
    ''' <remarks></remarks>
    Operator_UnEqual = 2
    ''' <summary>
    ''' >(大于)
    ''' </summary>
    ''' <remarks></remarks>
    Operator_More = 3
    ''' <summary>
    ''' >=(大于等于)
    ''' </summary>
    ''' <remarks></remarks>
    Operator_MoreOrEqual = 4
    ''' <summary>
    ''' (小于)
    ''' </summary>
    ''' <remarks></remarks>
    Operator_Less = 5
    ''' <summary>
    ''' 小于等于
    ''' </summary>
    ''' <remarks></remarks>
    Operator_LessOrEqual = 6
    ''' <summary>
    ''' 在两个值之间
    ''' </summary>
    ''' <remarks></remarks>
    Operator_Between = 7
    ''' <summary>
    ''' Like(两边加%)
    ''' </summary>
    ''' <remarks></remarks>
    Operator_Like_Both = 8
    ''' <summary>
    ''' Like(前面加%)
    ''' </summary>
    ''' <remarks></remarks>
    Operator_Like_Before = 9
    ''' <summary>
    ''' 包含
    ''' </summary>
    ''' <remarks></remarks>
    Operator_In = 10
    ''' <summary>
    ''' IsNull值
    ''' </summary>
    ''' <remarks></remarks>
    Operator_IsNull = 11
    ''' <summary>
    ''' IsNotNull值
    ''' </summary>
    ''' <remarks></remarks>
    Operator_IsNotNull = 12
End Enum

Public Enum Enum_OptionID
    '商品信息
    T10001_Goods

End Enum

Public Class OptionClass
    ''' <summary>
    '''表名: 物料信息
    ''' </summary>
    ''' <remarks></remarks>
    Public Const Table_WL = "T10001_WL"
    ''' <summary>
    '''表名:布种
    ''' </summary>
    ''' <remarks></remarks>
    Public Const Table_BZ = "T10002_BZ"
    ''' <summary>
    '''表名:色号
    ''' </summary>
    ''' <remarks></remarks>
    Public Const Table_BZC = "T10003_BZC"

    ''' <summary>
    '''表名:染色工艺
    ''' </summary>
    ''' <remarks></remarks>
    Public Const Table_GY = "T10004_GY"

    ''' <summary>
    '''表名:手感工艺
    ''' </summary>
    ''' <remarks></remarks>
    Public Const Table_SGGY = "T10035_SGGY"

    ''' <summary>
    '''表名:手感工艺列表
    ''' </summary>
    ''' <remarks></remarks>
    Public Const Table_SGGYList = "T10036_SGGYList"


    ''' <summary>
    '''表名:定胚工艺
    ''' </summary>
    ''' <remarks></remarks>
    Public Const Table_DPGY = "T10016_DPGY"

    ''' <summary>
    '''表名:定胚工艺列表
    ''' </summary>
    ''' <remarks></remarks>
    Public Const Table_DPGYList = "T10017_DPGYList"


    ''' <summary>
    '''表名:缩水工艺
    ''' </summary>
    ''' <remarks></remarks>
    Public Const Table_SSGY = "T10018_SSGY"

    ''' <summary>
    '''表名:缩水工艺列表
    ''' </summary>
    ''' <remarks></remarks>
    Public Const Table_SSGYList = "T10019_SSGYList"


    ''' <summary>
    '''表名:加工内容
    ''' </summary>
    ''' <remarks></remarks>
    Public Const Table_Work = "T10022_Work"


    ''' <summary>
    '''表名:加工内容集合
    ''' </summary>
    ''' <remarks></remarks>
    Public Const Table_WorkTable = "T10023_WorkTable"


    ''' <summary>
    '''表名: 采购信息
    ''' </summary>
    ''' <remarks></remarks>
    Public Const Table_Purchase = "T20000_Purchase_table"


    ''' <summary>
    '''表名:缸号
    ''' </summary>
    ''' <remarks></remarks>
    Public Const Table_Produce = "T30000_Produce_Gd"






    ''' <summary>
    ''' 获取查询条件集合
    ''' </summary>
    ''' <param name="tableName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function OptionClass_GetConditionNameList(ByVal tableName As String) As PClass.PClass.DtReturnMsg
        Dim sql As String = "Select * from OtionClass where OptionID=@OptionID order by OptionOrder"
        Return PClass.PClass.SqlStrToDt(sql, "@OptionID", tableName)
    End Function

    ''' <summary>
    ''' 获取相应表和字段的现有项集合
    ''' </summary>
    ''' <param name="tableName"></param>
    ''' <param name="fieldName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function OptionClass_GetConditionValues(ByVal tableName As String, ByVal fieldName As String, ByVal LikeVules As String) As DtReturnMsg
        Dim dotIndex As Integer = 0
        Dim fieldNameWithoutDot As String = dotIndex
        Try
            dotIndex = fieldName.IndexOf(".")
            fieldNameWithoutDot = fieldName.Substring(dotIndex + 1, fieldName.Length - dotIndex - 1)
        Catch ex As Exception

        End Try
        fieldName.IndexOf(".")

        Dim sqlBuider As New StringBuilder
        sqlBuider.Append("select distinct(")
        sqlBuider.Append(fieldNameWithoutDot)
        sqlBuider.Append(") as ConditionValue ")
        sqlBuider.Append("from ")
        If tableName.Contains("order") Then
            Dim i As Integer = tableName.LastIndexOf("order ")
            Dim s As String = tableName.Substring(i + 6)
            If s.Replace(")Con", "").Contains(")") Then
                sqlBuider.Append(tableName)
            Else
                If s.Contains(")Con") Then
                    Dim j As Integer = s.LastIndexOf(")Con")
                    sqlBuider.Append(tableName.Substring(0, i - 1) & tableName.Substring(tableName.Length - j))
                Else
                    sqlBuider.Append(tableName.Substring(0, i - 1))
                End If
            End If
        Else
            sqlBuider.Append(tableName)
        End If
        sqlBuider.Append(" where ")
        sqlBuider.Append(fieldNameWithoutDot)
        sqlBuider.Append(" like @")
        sqlBuider.Append(fieldNameWithoutDot)
        sqlBuider.Append(" order by ")

        sqlBuider.Append(fieldNameWithoutDot)

        Dim R As New DtReturnMsg

        Try
            R = SqlStrToDt(sqlBuider.ToString, "@" & fieldNameWithoutDot, LikeVules & "%")

        Catch ex As Exception
            DebugToLog(ex)

            R.IsOk = False
            R.Msg = "没有找到相应的条件值"
            R.Dt = New DataTable("T")
        End Try
        Return R
    End Function


    ''' <summary>
    ''' 获取相应表和字段的现有项集合
    ''' </summary>
    ''' <param name="tableName"></param>
    ''' <param name="fieldName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function OptionClass_GetConditionValues(ByVal tableName As String, ByVal fieldName As String, ByVal LikeVules As String, ByVal paraMap As Dictionary(Of String, Object)) As DtReturnMsg
        Dim dotIndex As Integer = 0

        Dim fieldNameWithoutDot As String = dotIndex
        Try
            dotIndex = fieldName.IndexOf(".")
            fieldNameWithoutDot = fieldName.Substring(dotIndex + 1, fieldName.Length - dotIndex - 1)
        Catch ex As Exception

        End Try
        fieldName.IndexOf(".")

        Dim sqlBuider As New StringBuilder
        sqlBuider.Append("select distinct(")
        sqlBuider.Append(fieldNameWithoutDot)
        sqlBuider.Append(") as ConditionValue ")
        sqlBuider.Append("from ")
        If tableName.Contains("order") Then
            Dim i As Integer = tableName.LastIndexOf("order ")
            Dim s As String = tableName.Substring(i + 6)
            If s.Replace(")Con", "").Contains(")") Then
                sqlBuider.Append(tableName)
            Else
                If s.Contains(")Con") Then
                    Dim j As Integer = s.LastIndexOf(")Con")
                    sqlBuider.Append(tableName.Substring(0, i - 1) & tableName.Substring(tableName.Length - j))
                Else
                    sqlBuider.Append(tableName.Substring(0, i - 1))
                End If
            End If
        Else
            sqlBuider.Append(tableName)
        End If
        '  sqlBuider.Append(" where 1=1 ")
        'sqlBuider.Append(fieldNameWithoutDot)
        'sqlBuider.Append(" like @")
        'sqlBuider.Append(fieldNameWithoutDot)
        'paraMap.Add("@" & fieldNameWithoutDot, LikeVules & "%")
        ' sqlBuider.Append(BaseClass.OptionClass.OptionClass_BuidSqlConditon(foList, paraMap))
        sqlBuider.Append(" order by ")

        sqlBuider.Append(fieldNameWithoutDot)

        Dim R As New DtReturnMsg

        Try
            R = SqlStrToDt(sqlBuider.ToString, paraMap)

        Catch ex As Exception
            DebugToLog(ex)

            R.IsOk = False
            R.Msg = "没有找到相应的条件值"
            R.Dt = New DataTable("T")
        End Try
        Return R
    End Function

    ''' <summary>
    ''' 被排除的SQL变量字符
    ''' </summary>
    ''' <remarks></remarks>
    Private Shared SQL_EXCEPT_CHAR() As Char = {".", "'", "(", ")", "<", ">", "=", "*", "?", ",", "/", "\", "@", "%"}

    ''' <summary>
    ''' 根据条件生成where 条件，并通过参数返回参数和值的数组
    ''' </summary>
    ''' <param name="oList"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function OptionClass_BuidSqlConditon(ByVal oList As List(Of FindOption), ByRef paramap As Dictionary(Of String, Object)) As String

        Dim sqlBuider As New StringBuilder
        Dim Inedx As Integer = 10
        Dim fieldName As String
        Dim isFirst As Boolean = True
        For Each fo As FindOption In oList
            If fo.DB_Field.Replace(".", "") <> "" Then
                If fo.Value Is Nothing Then fo.Value = ""
                If fo.Value2 Is Nothing Then fo.Value2 = ""
                Try

                    If fo.Value = "[Empty]" Then fo.Value = ""
                    If fo.Value2 = "[Empty]" Then fo.Value2 = ""
                Catch ex As Exception
                End Try
                Try
                    If fo.Value.ToLower = "true" Then
                        fo.Value = "1"
                    ElseIf fo.Value.ToLower = "false" Then
                        fo.Value = "0"
                    End If
                Catch ex As Exception

                End Try
                Inedx = Inedx + 1
                If fo.DB_Field.IndexOfAny(SQL_EXCEPT_CHAR) > 0 Then
                    fieldName = "@_Var" & Inedx
                Else
                    fieldName = "@" & fo.DB_Field.Replace(" ", "_") & Inedx
                End If
                Dim FieldBuider As New StringBuilder()

                Select Case fo.Field_Operator
                    Case Enum_Operator.Operator_Equal
                        FieldBuider.Append(fo.DB_Field)
                        FieldBuider.Append("=")
                        FieldBuider.Append(fieldName)
                        paramap.Add(fieldName, fo.Value)
                    Case Enum_Operator.Operator_Like
                        FieldBuider.Append(fo.DB_Field)
                        FieldBuider.Append(" like ")
                        FieldBuider.Append(fieldName)
                        FieldBuider.Append("+ '%'")
                        paramap.Add(fieldName, fo.Value)
                    Case Enum_Operator.Operator_More
                        FieldBuider.Append(fo.DB_Field)
                        FieldBuider.Append(" > ")
                        FieldBuider.Append(fieldName)
                        If IsDate(fo.Value) Then
                            paramap.Add(fieldName, CDate(fo.Value))
                        Else
                            paramap.Add(fieldName, fo.Value)
                        End If
                    Case Enum_Operator.Operator_MoreOrEqual
                        FieldBuider.Append(fo.DB_Field)
                        FieldBuider.Append(" >= ")
                        FieldBuider.Append(fieldName)
                        If IsDate(fo.Value) Then
                            paramap.Add(fieldName, CDate(fo.Value))
                        Else
                            paramap.Add(fieldName, fo.Value)
                        End If
                    Case Enum_Operator.Operator_Less
                        FieldBuider.Append(fo.DB_Field)
                        FieldBuider.Append(" < ")
                        FieldBuider.Append(fieldName)
                        If IsDate(fo.Value) Then
                            paramap.Add(fieldName, CDate(fo.Value))
                        Else
                            paramap.Add(fieldName, fo.Value)
                        End If
                    Case Enum_Operator.Operator_LessOrEqual
                        FieldBuider.Append(fo.DB_Field)
                        FieldBuider.Append(" <= ")
                        FieldBuider.Append(fieldName)
                        If IsDate(fo.Value) Then
                            paramap.Add(fieldName, CDate(fo.Value))
                        Else
                            paramap.Add(fieldName, fo.Value)
                        End If
                    Case Enum_Operator.Operator_Like_Both
                        FieldBuider.Append(fo.DB_Field)
                        FieldBuider.Append(" like '%' + ")
                        FieldBuider.Append(fieldName)
                        FieldBuider.Append("+ '%'")
                        paramap.Add(fieldName, fo.Value)
                    Case Enum_Operator.Operator_Like_Before
                        FieldBuider.Append(fo.DB_Field)
                        FieldBuider.Append(" like '%' + ")
                        FieldBuider.Append(fieldName)
                        paramap.Add(fieldName, fo.Value)
                    Case Enum_Operator.Operator_UnEqual
                        FieldBuider.Append(fo.DB_Field)
                        FieldBuider.Append(" <> ")
                        FieldBuider.Append(fieldName)
                        paramap.Add(fieldName, fo.Value)
                    Case Enum_Operator.Operator_Between
                        If fo.Value = "" Then
                            FieldBuider.Append(fo.DB_Field)
                            FieldBuider.Append(" <= ")
                            FieldBuider.Append(fieldName)
                            If IsDate(fo.Value2) Then
                                paramap.Add(fieldName, CDate(fo.Value2))
                            Else
                                paramap.Add(fieldName, fo.Value2)
                            End If
                        ElseIf fo.Value2 = "" Then
                            FieldBuider.Append(fo.DB_Field)
                            FieldBuider.Append(" >= ")
                            FieldBuider.Append(fieldName)
                            If IsDate(fo.Value) Then
                                paramap.Add(fieldName, CDate(fo.Value))
                            Else
                                paramap.Add(fieldName, fo.Value)
                            End If
                        Else
                            FieldBuider.Append(fo.DB_Field)
                            FieldBuider.Append("  between ")
                            FieldBuider.Append(fieldName)
                            FieldBuider.Append("A")
                            FieldBuider.Append(" and ")
                            FieldBuider.Append(fieldName)
                            FieldBuider.Append("B")
                            If IsDate(fo.Value) Then
                                paramap.Add(fieldName & "A", CDate(fo.Value))
                            Else
                                paramap.Add(fieldName & "A", fo.Value)
                            End If
                            If IsDate(fo.Value2) Then
                                paramap.Add(fieldName & "B", CDate(fo.Value2))
                            Else
                                paramap.Add(fieldName & "B", fo.Value2)
                            End If
                        End If
                    Case Enum_Operator.Operator_In
                        FieldBuider.Append(fo.DB_Field)
                        FieldBuider.Append(" In (")
                        Dim Sp() As String = fo.Value.Split(",")
                        Dim i As Integer = 0
                        For Each s As String In Sp
                            If s <> "" Then
                                i = i + 1
                                FieldBuider.Append(fieldName)
                                FieldBuider.Append("In")
                                FieldBuider.Append(i)
                                FieldBuider.Append(",")
                                paramap.Add(fieldName & "In" & i, s)
                            End If
                        Next
                        If i > 0 Then
                            FieldBuider.Remove(FieldBuider.Length - 1, 1)
                        End If
                        FieldBuider.Append(")")
                    Case Enum_Operator.Operator_IsNull
                        FieldBuider.Append(fo.DB_Field)
                        FieldBuider.Append(" is null ")
                    Case Enum_Operator.Operator_IsNotNull
                        FieldBuider.Append(fo.DB_Field)
                        FieldBuider.Append(" is not null ")
                    Case Else
                        Continue For
                End Select
                If isFirst = False AndAlso fo.IsOr Then
                    sqlBuider.Append(" or ")
                Else
                    sqlBuider.Append(" and ")
                End If
                isFirst = False
                If fo.SQL <> "" AndAlso fo.Sign <> "" Then
                    sqlBuider.AppendLine(fo.SQL.Replace(fo.Sign, FieldBuider.ToString))
                Else
                    sqlBuider.AppendLine(FieldBuider.ToString)
                End If
            End If
        Next
        Return sqlBuider.ToString
    End Function


End Class
