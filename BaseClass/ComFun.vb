Imports System.Text
Imports PClass.PClass
Imports PClass.BaseForm
Imports System.Windows.Forms

Public MustInherit Class ComFun
    Private Const SQL_AreaDt As String = "select distinct Area col from T25100_StoreOut_table order by 1"
    Public Shared Autitedtime As DateTime = GetDate()

    ''' <summary>
    ''' 写入Log
    ''' </summary>
    ''' <remarks></remarks>
    Public Const SQL_Log As String = "insert into T10080_BillStateLog (BillType,ID,State,StateName,ChangeTime,ChagneUser)values(@BillType,@ID,@State,@StateName,Getdate(),@ChagneUser) "


#Region "委托声明"
    Public Delegate Sub DSub_None()
#End Region

#Region "两个DT"

    ''' <summary>
    ''' 两个DT Left Join 返回DT1 会自动增加字段
    ''' </summary>
    ''' <param name="Dt1"></param>
    ''' <param name="dt2"></param>
    ''' <param name="AddColumn">Dt1 在 Dt2 中没有的字段</param>
    ''' <param name="LinkColumn">Dt1 和 Dt2 关联的字段 相当于 [On Dt1.A=Dt2.A and Dt1.B=Dt2.B] </param>
    ''' <param name="SelectStr">Dt2.Select的语句 如果不填会自动生成 A=%A% and B='%B%'</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Dt_LeftJoin(ByVal Dt1 As DataTable, ByVal dt2 As DataTable, ByVal AddColumn As Dictionary(Of String, String), ByVal LinkColumn As Dictionary(Of String, String), Optional ByVal SelectStr As String = "") As DataTable
        For Each C As KeyValuePair(Of String, String) In AddColumn
            If Dt1.Columns.Contains(C.Key) = False Then
                Dt1.Columns.Add(C.Key, dt2.Columns(C.Value).DataType)
            End If
        Next

        If SelectStr = "" Then
            For Each C As KeyValuePair(Of String, String) In LinkColumn
                SelectStr = SelectStr & " " & C.Value & " = '%" & C.Key & "%" & "' and "
            Next
            If SelectStr <> "" Then SelectStr = SelectStr.Substring(0, SelectStr.Length - 5)
        End If

        Dim Str As String = ""
        Dim IsNull As Boolean = False
        For Each Row As DataRow In Dt1.Rows
            Str = SelectStr
            IsNull = False
            For Each C As KeyValuePair(Of String, String) In LinkColumn
                If Row(C.Key) Is DBNull.Value Then
                    IsNull = True
                    Continue For
                End If
                Str = Str.Replace("%" & C.Key & "%", Row(C.Key))
            Next
            If IsNull = False Then
                Dim Rows2() As DataRow = dt2.Select(Str)
                If Rows2.Length > 0 Then
                    For Each C As KeyValuePair(Of String, String) In AddColumn
                        Row(C.Key) = Rows2(0)(C.Value)
                    Next
                End If
            End If
        Next
        Return Dt1
    End Function

    ''' <summary>
    '''  两个DT Left Join 返回DT1 会自动增加字段
    ''' </summary>
    ''' <param name="Dt1"></param>
    ''' <param name="dt2"></param>
    ''' <param name="AddColumn">Dt1 在 Dt2 中没有的字段 ,增加之后的名字 </param>
    ''' <param name="AddColumnToDt2">Dt1 在 Dt2 中没有的字段</param>
    ''' <param name="LinkColumn">Dt1 和 Dt2 关联的字段 相当于 [On Dt1.A=Dt2.A] </param>
    ''' <param name="LinkColumnToDt2"></param>
    ''' <param name="SelectStr">Dt2.Select的语句 如果不填会自动生成  [B='%B%']</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Dt_LeftJoin(ByVal Dt1 As DataTable, ByVal dt2 As DataTable, ByVal AddColumn As String, ByVal AddColumnToDt2 As String, ByVal LinkColumn As String, ByVal LinkColumnToDt2 As String, Optional ByVal SelectStr As String = "") As DataTable
        If Dt1.Columns.Contains(AddColumn) = False Then
            Dt1.Columns.Add(AddColumn, dt2.Columns(AddColumnToDt2).DataType)
        End If
        If SelectStr = "" Then
            SelectStr = SelectStr & " " & LinkColumnToDt2 & " = '%" & LinkColumn & "%'"

        End If
        Dim Str As String = ""
        For Each Row As DataRow In Dt1.Rows
            Str = SelectStr
            If Row(LinkColumn) IsNot DBNull.Value Then
                Str = Str.Replace("%" & LinkColumn & "%", Row(LinkColumn))
                Dim Rows2() As DataRow = dt2.Select(Str)
                If Rows2.Length > 0 Then
                    Row(AddColumn) = Rows2(0)(AddColumnToDt2)
                End If
            End If

        Next
        Dt1.AcceptChanges()
        Return Dt1

    End Function


    ''' <summary>
    ''' Dt多出少补
    ''' </summary>
    ''' <param name="Dt"></param>
    ''' <param name="DtRow"></param>
    ''' <param name="Field"></param>
    ''' <param name="RetrunID"></param>
    ''' <remarks></remarks>
    Shared Sub DtReFreshRow(ByVal Dt As DataTable, ByVal DtRow As DataTable, ByVal Field As String, ByVal RetrunID As String)
        Dim Rows() As DataRow = Dt.Select(Field & "='" & RetrunID & "'")
        If DtRow.Rows.Count > 0 Then
            Dim Dr As DataRow
            If Rows.Length > 0 Then
                Dr = Rows(0)
            Else
                Dr = Dt.NewRow
                Dt.Rows.Add(Dr)
                Dr("FG_Index") = Dt.Rows.Count
            End If
            For Each C As DataColumn In DtRow.Columns
                Dr(C.ColumnName) = DtRow.Rows(0)(C.ColumnName)
            Next
        Else
            If Rows.Length > 0 Then
                Rows(0).Delete()
            End If
        End If
        Dt.AcceptChanges()
    End Sub
    ' 比较两个DataTable数据（结构相同）
    '''  <param name="dt1">来自数据库的DataTable</param> 
    ''' <param name="dt2">来自文件的DataTable</param> 
    ''' <param name="keyField">关键字段名</param>
    ''' <param name="dtRetAdd">新增数据（dt2中的数据）</param>  
    ''' <param name="dtRetDif1">不同的数据（数据库中的数据）</param> 
    ''' <param name="dtRetDif2">不同的数据（图2中的数据）</param> 
    ''' <param name="dtRetDel">删除的数据（dt2中的数据）</param> 
    Public Shared Sub CompareDt(ByVal dt1 As DataTable, ByVal dt2 As DataTable, ByVal keyField As String, ByRef dtRetAdd As DataTable, ByRef dtRetDif1 As DataTable, ByRef dtRetDif2 As DataTable, ByRef dtRetDel As DataTable)
        '为三个表拷贝表结构  
        dtRetDel = dt1.Clone()
        dtRetAdd = dtRetDel.Clone()
        dtRetDif1 = dtRetDel.Clone()
        dtRetDif2 = dtRetDel.Clone()
        Dim colCount As Integer = dt1.Columns.Count
        Dim dv1 As DataView = dt1.DefaultView
        Dim dv2 As DataView = dt2.DefaultView
        '先以第一个表为参照，看第二个表是修改了还是删除了 
        For Each dr1 As DataRowView In dv1
            dv2.RowFilter = keyField & " = '" & dr1(keyField).ToString() & "'"
            If dv2.Count > 0 Then
                If Not CompareUpdate(dr1, dv2(0)) Then
                    '比较是否有不同的      dtRetDif1.Rows.Add(dr1.Row.ItemArray)  
                    '修改前      
                    dtRetDif2.Rows.Add(dv2(0).Row.ItemArray)
                    '修改后    
                    dtRetDif2.Rows(dtRetDif2.Rows.Count - 1)("FID") = dr1.Row("FID")
                    '将ID赋给来自文件的表，因为它的ID全部==0     
                    Continue For
                End If
            Else
                '已经被删除的   
                dtRetDel.Rows.Add(dr1.Row.ItemArray)
            End If
        Next
        '以第一个表为参照，看记录是否是新增的   
        dv2.RowFilter = ""
        '清空条件  
        For Each dr2 As DataRowView In dv2
            dv1.RowFilter = keyField & " = '" & dr2(keyField).ToString() & "'"
            If dv1.Count = 0 Then   '新增的   
                dtRetAdd.Rows.Add(dr2.Row.ItemArray)
            End If
        Next
    End Sub
    '比较是否有不同的
    Public Shared Function CompareDt(ByVal dt1 As DataTable, ByVal dt2 As DataTable) As Boolean

        'For Each dv1 As DataRowView In dt1.DefaultView
        '    For Each dv2 As DataRowView In dt2.DefaultView
        '        If Not CompareUpdate(dv1, dv2) Then
        '            Return False
        '        End If
        '    Next
        'Next
        If dt1.Rows.Count <> dt2.Rows.Count Then
            Return False
        Else

            For i As Integer = 0 To dt1.Rows.Count - 1
                If Not CompareUpdate(dt1.DefaultView(i), dt2.DefaultView(i)) Then
                    Return False
                End If
            Next
        End If

        Return True
    End Function
    '比较是否有不同的
    Public Shared Function CompareUpdate(ByVal dr1 As DataRowView, ByVal dr2 As DataRowView) As Boolean
        '行里只要有一项不一样，整个行就不一样,无需比较其它 
        Dim val1 As Object
        Dim val2 As Object
        For i As Integer = 1 To dr1.Row.ItemArray.Length - 1
            val1 = dr1(i)
            val2 = dr2(i)
            If Not val1.Equals(val2) Then

                Return False
            End If
        Next
        Return True
    End Function
#End Region

#Region "按钮显示不显示"
    ''' <summary>
    ''' 按钮状态
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum Enum_CmdState
        ''' <summary>
        ''' 两个的禁用
        ''' </summary>
        ''' <remarks></remarks>
        AllDisable = 0
        ''' <summary>
        ''' 启用第一个 禁用第二个
        ''' </summary>
        ''' <remarks></remarks>
        Enable1Disable2 = 1
        ''' <summary>
        ''' 禁用第一个,启用第二个
        ''' </summary>
        ''' <remarks></remarks>
        Enable2Disable1 = 2
        ''' <summary>
        ''' 两个的都启用
        ''' </summary>
        ''' <remarks></remarks>
        AllEnable = 3
    End Enum
#End Region

    ''' <summary>
    ''' 两个按钮启用和禁用的控制
    ''' </summary>
    ''' <param name="Button1">按钮1 可以为nothing</param>
    ''' <param name="Button2">按钮2 可以为nothing</param>
    ''' <param name="State">按钮状态</param>
    ''' <param name="EnableIsVisable">是否禁用后隐藏,启用后才显示</param>
    ''' <remarks></remarks>
    Public Shared Sub SetCmd_State(ByVal Button1 As ToolStripButton, ByVal Button2 As ToolStripButton, ByVal State As Enum_CmdState, Optional ByVal EnableIsVisable As Boolean = True)
        Select Case State
            Case Enum_CmdState.AllDisable
                If EnableIsVisable Then
                    If Button1 IsNot Nothing Then
                        Button1.Enabled = False
                        Button1.Visible = False
                    End If
                    If Button2 IsNot Nothing Then
                        Button2.Enabled = False
                        Button2.Visible = False
                    End If
                Else
                    If Button1 IsNot Nothing Then
                        Button1.Enabled = False
                        Button1.Visible = True
                    End If
                    If Button2 IsNot Nothing Then
                        Button2.Enabled = False
                        Button2.Visible = True
                    End If
                End If
            Case Enum_CmdState.AllEnable
                If EnableIsVisable Then
                    If Button1 IsNot Nothing Then
                        Button1.Enabled = Button1.Tag
                        Button1.Visible = Button1.Tag
                    End If
                    If Button2 IsNot Nothing Then
                        Button2.Enabled = Button2.Tag
                        Button2.Visible = Button2.Tag
                    End If
                Else
                    If Button1 IsNot Nothing Then
                        Button1.Enabled = Button1.Tag
                        Button1.Visible = True
                    End If
                    If Button2 IsNot Nothing Then
                        Button2.Enabled = Button2.Tag
                        Button2.Visible = True
                    End If
                End If
            Case Enum_CmdState.Enable1Disable2
                If EnableIsVisable Then
                    If Button1 IsNot Nothing Then
                        Button1.Enabled = Button1.Tag
                        Button1.Visible = Button1.Tag
                    End If
                    If Button2 IsNot Nothing Then
                        Button2.Enabled = False
                        Button2.Visible = False
                    End If
                Else
                    If Button1 IsNot Nothing Then
                        Button1.Enabled = Button1.Tag
                        Button1.Visible = True
                    End If
                    If Button2 IsNot Nothing Then
                        Button2.Enabled = False
                        Button2.Visible = True
                    End If
                End If
            Case Enum_CmdState.Enable2Disable1
                SetCmd_State(Button2, Button1, Enum_CmdState.Enable1Disable2, EnableIsVisable)
        End Select
    End Sub

    Public Shared Function GetAreaDt() As DataTable
        Dim R As DtReturnMsg = SqlStrToDt(SQL_AreaDt)
        Return R.Dt
    End Function

#Region "设置摸个控件位于父控件的中间"
    ''' <summary>
    ''' 设置摸个控件位于父控件的中间
    ''' </summary>
    ''' <param name="Col"></param>
    ''' <remarks></remarks>
    Public Shared Sub Col_Center(ByVal Col As Control)
        Dim P As Control = Col.Parent
        Col.Left = (P.Width - Col.Width) / 2
        Col.Top = (P.Height - Col.Height) / 2
    End Sub
#End Region

#Region "数组转字符串"

    Public Shared Function ArrayToString(ByVal A() As String, ByVal SplitStr As String) As String
        Dim T As New System.Text.StringBuilder("")
        For Each S As String In A
            T.Append(S)
            T.Append(SplitStr)
        Next
        If T.Length > 0 Then
            Return T.ToString.Substring(0, T.Length - SplitStr.Length)
        Else
            Return ""
        End If
    End Function

    Public Shared Function ListToString(ByVal L As List(Of String), ByVal SplitStr As String) As String
        Dim T As New System.Text.StringBuilder("")
        For Each S As String In L
            T.Append(S)
            T.Append(SplitStr)
        Next
        If T.Length > 0 Then
            Return T.ToString.Substring(0, T.Length - SplitStr.Length)
        Else
            Return ""
        End If
    End Function

    Public Shared Function DtToString(ByVal Dt As DataTable, ByVal Field As String, ByVal SplitStr As String) As String
        Dim T As New System.Text.StringBuilder("")
        For Each Row As DataRow In Dt.Rows
            T.Append(Row(Field))
            T.Append(SplitStr)
        Next
        If T.Length > 0 Then
            Return T.ToString.Substring(0, T.Length - SplitStr.Length)
        Else
            Return ""
        End If
    End Function

    Public Shared Function RowsToString(ByVal Rows() As DataRow, ByVal Field As String, ByVal SplitStr As String) As String
        Dim T As New System.Text.StringBuilder("")
        For Each Row As DataRow In Rows
            T.Append(Row(Field))
            T.Append(SplitStr)
        Next
        If T.Length > 0 Then
            Return T.ToString.Substring(0, T.Length - SplitStr.Length)
        Else
            Return ""
        End If
    End Function
#End Region

    Public Shared LastFont As Drawing.Font
#Region "控件赋值"


    Public Shared Function GetLocalTime() As Date
        Return DateAdd(DateInterval.Second, TimeDiff, Now)
    End Function
    Public Shared Function GetLocalDate() As Date
        Return DateAdd(DateInterval.Second, TimeDiff, Now).Date
    End Function

#Region "DateTimePicker"
    Public Shared Sub SetColValue(ByVal Dr As DataRow, ByRef DTPicker As DateTimePicker, Optional ByVal IsNullText As Object = Nothing, Optional ByVal Field As String = "", Optional ByVal Lock As Boolean = False)
        If Field = "" Then
            Field = DTPicker.Name.Substring(DTPicker.Name.IndexOf("_") + 1)
        End If
        If DTPicker.ShowCheckBox Then
            If IsDBNull(Dr.Item(Field)) Then
                DTPicker.Value = GetLocalDate()
                DTPicker.Checked = False
            Else
                If IsNullText Is Nothing Then
                    IsNullText = GetLocalDate()
                End If

                DTPicker.Value = IsNull(Dr.Item(Field), IsNullText)
                If Lock = True Then DTPicker.Enabled = False
            End If
        Else
            DTPicker.Value = IsNull(Dr.Item(Field), IsNullText)
            If Lock = True Then DTPicker.Enabled = False
        End If
    End Sub

    Public Shared Sub GetColValue(ByVal Dr As DataRow, ByRef DTPicker As DateTimePicker, Optional ByVal IsNullText As Object = Nothing, Optional ByVal Field As String = "", Optional ByVal IsDate As Boolean = False)
        If Field = "" Then
            Field = DTPicker.Name.Substring(DTPicker.Name.IndexOf("_") + 1)
        End If
        If DTPicker.ShowCheckBox Then
            If DTPicker.Checked = False Then
                Dr.Item(Field) = DBNull.Value
                Exit Sub
            End If
        End If
        If IsDate Then
            Dr.Item(Field) = Format(DTPicker.Value, "yyyy-MM-dd")
        Else
            Dr.Item(Field) = Format(DTPicker.Value, "yyyy-MM-dd HH:mm:ss")
        End If
    End Sub
#End Region



#Region "TextBox"
    Public Shared Sub SetColValue(ByVal Dr As DataRow, ByRef TB As TextBox, Optional ByVal IsNullText As Object = "", Optional ByVal Field As String = "", Optional ByVal Lock As Boolean = False, Optional ByVal FormatString As String = "")
        If Field = "" Then
            Field = TB.Name.Substring(TB.Name.IndexOf("_") + 1)
        End If
        If FormatString <> "" Then
            TB.Text = Format(Val(IsNull(Dr.Item(Field), IsNullText)), FormatString)
        Else
            TB.Text = IsNull(Dr.Item(Field), IsNullText)
        End If
        If Lock = True Then TB.ReadOnly = True
    End Sub

    Public Shared Sub GetColValue(ByVal Dr As DataRow, ByRef TB As TextBox, Optional ByVal IsNullText As Object = "", Optional ByVal Field As String = "", Optional ByVal Lock As Boolean = False, Optional ByVal FormatString As String = "")
        If Field = "" Then
            Field = TB.Name.Substring(TB.Name.IndexOf("_") + 1)
        End If
        If FormatString <> "" Then
            Dr.Item(Field) = Format(Val(TB.Text), FormatString)
        Else
            Dr.Item(Field) = TB.Text
        End If
    End Sub
#End Region

#Region "CheckBox"
    ''' <summary>
    ''' DataRow赋值到CheckBox
    ''' </summary>
    ''' <param name="Dr"></param>
    ''' <param name="CKB"></param>
    ''' <param name="IsNullText"></param>
    ''' <param name="Field"></param>
    ''' <param name="Lock"></param>
    ''' <param name="FalseToNull"></param>
    ''' <remarks></remarks>
    Public Shared Sub SetColValue(ByVal Dr As DataRow, ByRef CKB As CheckBox, Optional ByVal IsNullText As Boolean = False, Optional ByVal Field As String = "", Optional ByVal Lock As Boolean = False, Optional ByVal FalseToNull As Boolean = False)
        If Field = "" Then
            Field = CKB.Name.Substring(CKB.Name.IndexOf("_") + 1)
        End If
        CKB.Checked = IsNull(Dr.Item(Field), IsNullText)
        If Lock = True Then CKB.Enabled = False
    End Sub

    ''' <summary>
    ''' CheckBox赋值到DataRow
    ''' </summary>
    ''' <param name="Dr"></param>
    ''' <param name="CKB"></param>
    ''' <param name="IsNullText"></param>
    ''' <param name="Field"></param>
    ''' <param name="Lock"></param>
    ''' <param name="FalseToNull">False的时候 会Null值</param>
    ''' <remarks></remarks>
    Public Shared Sub GetColValue(ByVal Dr As DataRow, ByRef CKB As CheckBox, Optional ByVal IsNullText As Boolean = False, Optional ByVal Field As String = "", Optional ByVal Lock As Boolean = False, Optional ByVal FalseToNull As Boolean = False)
        If Field = "" Then
            Field = CKB.Name.Substring(CKB.Name.IndexOf("_") + 1)
        End If
        If FalseToNull Then
            Dr.Item(Field) = IIf(CKB.Checked, True, DBNull.Value)
        Else
            Dr.Item(Field) = CKB.Checked
        End If
    End Sub
#End Region

#Region "ComboBox"
    Public Shared Sub SetColValue(ByVal Dr As DataRow, ByRef CB As ComboBox, Optional ByVal IsNullText As Object = "", Optional ByVal Field As String = "", Optional ByVal Lock As Boolean = False, Optional ByVal FormatString As String = "")
        If Field = "" Then
            Field = CB.Name.Substring(CB.Name.IndexOf("_") + 1)
        End If
        CB.SelectedValue = IsNull(Dr.Item(Field), IsNullText)
        If FormatString <> "" Then
            CB.SelectedValue = Format(Val(IsNull(Dr.Item(Field), IsNullText)), FormatString)
        Else
            CB.SelectedValue = IsNull(Dr.Item(Field), IsNullText)
        End If
        If Lock = True Then CB.Enabled = False
    End Sub

    Public Shared Sub GetColValue(ByVal Dr As DataRow, ByRef CB As ComboBox, Optional ByVal IsNullText As Object = "", Optional ByVal Field As String = "", Optional ByVal Lock As Boolean = False, Optional ByVal FormatString As String = "")
        If Field = "" Then
            Field = CB.Name.Substring(CB.Name.IndexOf("_") + 1)
        End If
        If FormatString <> "" Then
            Dr.Item(Field) = Format(Val(CB.SelectedValue), FormatString)
        Else
            Dr.Item(Field) = CB.SelectedValue
        End If
    End Sub
#End Region


#End Region

#Region "生成唯一标示"
    ''' <summary>
    ''' 生成唯一标示
    ''' </summary>
    ''' <returns></returns>
    Public Shared Function GetLineID() As Long
        Dim ran As New Random(Guid.NewGuid().GetHashCode())
        'Return Now.Ticks - ran.Nexts
        Dim T As String = GetTime.Ticks.ToString.Substring(0, 11) & Now.Ticks.ToString.Substring(11)
        Dim s As String = CLng(ran.Next) + CLng(T.Substring(T.Length - 5)) + 10000
        Return CLng(T.Substring(0, T.Length - 4) & s.Substring(0, 5))
    End Function

#End Region

#Region "操作 sql "

    Private Const SQL_StoreReason As String = "select * from T10200_Remark where Remark_Type=@Remark_Type order by Remark_ID"

    Private Const SQL_Dept_Get As String = "select Dept_No,Dept_Name from T15000_Department where len(Dept_No)=4 order by Dept_No"


#Region "客户"
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <param name="condition"></param>
    ''' <param name="sortstr"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetNewDataTable(ByVal dt As DataTable, ByVal condition As String, Optional ByVal sortstr As String = "") As DataTable
        Dim newdt As New DataTable()
        newdt = dt.Clone()
        Dim dr As DataRow() = dt.Select(condition, sortstr)
        For i As Integer = 0 To dr.Length - 1
            newdt.ImportRow(DirectCast(dr(i), DataRow))
        Next
        Return newdt
        '返回的查询结果
    End Function

    Public Shared Dt_Mini_Client As DataTable
    Public Shared Sub Get_Dt_Mini_Client()
        Dim R As DtReturnMsg = SqlStrToDt("select ID,Client_No,Client_Name,Client_FindHelper from T10110_Client where isnull( Disable,0) =0 order by Client_No")
        If R.IsOk Then
            Dt_Mini_Client = R.Dt
        End If
    End Sub
#End Region

#Region "员工"
    ''' <summary>
    ''' 物料临时表
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Dt_Mini_Employee As DataTable
    Private Const SQL_Get_Dt_Mini_Employee As String = "select ID,Employee_No,Employee_Name,Employee_FindHelper from T15001_Employee "
    Private Const SQL_Get_Dt_Mini_Employee_OrderBY As String = " order by Employee_No"
    Public Shared Sub Get_Dt_Mini_Employee()
        Dim R As DtReturnMsg = SqlStrToDt(SQL_Get_Dt_Mini_Employee & SQL_Get_Dt_Mini_Employee_OrderBY)
        If R.IsOk Then
            Dt_Mini_Employee = R.Dt
        End If
    End Sub

    Public Shared Function Get_Employee_Name(ByVal Employee_No As String) As String
        Dim R As DataRow = Get_Employee_Row(Employee_No)
        If R Is Nothing Then
            Return ""
        Else
            Return R("Employee_Name")
        End If
    End Function

    Public Shared Function Get_Employee_Row(ByVal Employee_No As String) As DataRow
        If Dt_Mini_Employee Is Nothing Then
            Dim R As DtReturnMsg = SqlStrToDt(SQL_Get_Dt_Mini_Employee & " where Employee_No=@Employee_No", "Employee_No", Employee_No)
            If R.IsOk = False Then
                Return Nothing
            Else
                If R.Dt.Rows.Count > 0 Then
                    Return R.Dt.Rows(0)
                Else
                    Return Nothing
                End If
            End If
        Else
            Dim Dr() As DataRow = Dt_Mini_Employee.Select("Employee_No='" & Employee_No & "'")
            If Dr.Length > 0 Then
                Return Dr(0)
            Else
                Return Nothing
            End If
        End If
    End Function
#End Region

#Region "染厂专用"

#Region "布种"
    ''' <summary>
    ''' 布种临时表
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Dt_Mini_Bz As DataTable
    Private Const SQL_Get_Dt_Mini_Bz As String = "select ID,BZ_No,BZ_Name,BZ_FindHelper,BZ_Spec,BZ_Type_ID from T10002_BZ "
    Private Const SQL_Get_Dt_Mini_Bz_OrderBY As String = " order by BZ_No"
    Public Shared Sub Get_Dt_Mini_Bz()
        Dim R As DtReturnMsg = SqlStrToDt(SQL_Get_Dt_Mini_Bz & SQL_Get_Dt_Mini_Bz_OrderBY)
        If R.IsOk Then
            Dt_Mini_Bz = R.Dt
        End If
    End Sub

    Public Shared Function Get_Bz_Name(ByVal BZ_No As String) As String
        Dim R As DataRow = Get_Bz_Row(BZ_No)
        If R Is Nothing Then
            Return ""
        Else
            Return R("BZ_Name")
        End If
    End Function

    Public Shared Function Get_Bz_Row(ByVal BZ_No As String) As DataRow
        Dim R As DtReturnMsg = SqlStrToDt(SQL_Get_Dt_Mini_Bz & " where BZ_No=@BZ_No", "BZ_No", BZ_No)
        If R.IsOk = False Then
            Return Nothing
        Else
            If R.Dt.Rows.Count > 0 Then
                Return R.Dt.Rows(0)
            Else
                Return Nothing
            End If
        End If
    End Function
#End Region

#Region "物料"


    ''' <summary>
    ''' 物料临时表
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Dt_Mini_WL As DataTable
    Private Const SQL_Get_Dt_Mini_WL As String = "select ID,WL_No,WL_Name,WL_FindHelper,WL_Spec,WL_Type_ID from T10001_WL "
    'Private Const SQL_WL_GetByNo As String = "select Top 1 Id,WL_No,WL_Name,WL_Unit,WL_Spec,WL_Store_ID,WL_Cost,WL_Type_ID,WL_Price,WL_Unit_LL,WL_Percent,WL_Qty,isZJ from T10001_WL where WL_No=@WL_No and isnull(WL_Disable,0)<>1"
    Private Const SQL_WL_GetByNo As String = "select Top 1 WL.*,ISNULL(WL.WL_DownQty, 0) - ISNULL(WL.WL_Qty, 0) AS WL_ShortQty, ISNULL(WL.WL_Qty, 0) - ISNULL(WL.WL_BeiQty, 0) AS WL_ApproveQty,GT.IsAssemble,W.WL_Qty as RWL_Qty  from T10001_WL WL left join  T10000_GoodsType GT on WL.WL_Type_ID =GT.GoodsType_ID left join T10001_WL W on WL.RWL_No =W.WL_No where WL.WL_No=@WL_No and isnull(WL.WL_Disable,0)<>1"

    Private Const SQL_Kitchen_GetByNo As String = "select Top 1 Id,WL_No,WL_Name,WL_Unit,WL_Spec,WL_Store_ID,WL_Cost,WL_Type_ID,WL_Price,WL_Qty from T22001_kitchen where WL_No=@WL_No and isnull(WL_Disable,0)<>1"

    Private Const SQL_Metal_GetByNo As String = "select Top 1 Id,WL_No,WL_Name,WL_Unit,WL_Spec,WL_Store_ID,WL_Cost,WL_Type_ID,WL_Price,WL_Qty from T21001_Metal where WL_No=@WL_No and isnull(WL_Disable,0)<>1"
    Private Const SQL_PolyBag_GetByNo As String = "select Top 1 Id,WL_No,WL_Name,WL_Unit,WL_Spec,WL_Store_ID,WL_Cost,WL_Type_ID,WL_Price,WL_Qty from T24001_PolyBag where WL_No=@WL_No and isnull(WL_Disable,0)<>1"
    Private Const SQL_CocalBag_GetByNo As String = "select Top 1 Id,WL_No,WL_Name,WL_Unit,WL_Spec,WL_Store_ID,WL_Cost,WL_Type_ID,WL_Price,WL_Qty from T26001_WLCoal where WL_No=@WL_No and isnull(WL_Disable,0)<>1"

    Private Const SQL_Get_Dt_Mini_WL_OrderBY As String = " order by WL_No"
    Public Shared Sub Get_Dt_Mini_WL()
        Dim R As DtReturnMsg = SqlStrToDt(SQL_Get_Dt_Mini_WL & SQL_Get_Dt_Mini_WL_OrderBY)
        If R.IsOk Then
            Dt_Mini_WL = R.Dt
        End If
    End Sub

    Public Shared Function Get_WL_Name(ByVal WL_No As String) As String
        Dim R As DataRow = Get_WL_Row(WL_No)
        If R Is Nothing Then
            Return ""
        Else
            Return R("WL_Name")
        End If
    End Function

    Public Shared Function Get_WL_Cost(ByVal WL_ID As Integer) As DataRow
        Dim R As DtReturnMsg = SqlStrToDt("select Top 1 WL_Cost,WL_Percent,IsZJ  from T10001_WL where ID=@WL_ID", "WL_ID", WL_ID)
        If R.IsOk AndAlso R.Dt.Rows.Count > 0 Then
            Return R.Dt.Rows(0)
        Else
            Return Nothing
        End If
    End Function

    Public Shared Function Get_WL_Row(ByVal WL_No As String) As DataRow
        If Dt_Mini_WL Is Nothing Then
            Dim R As DtReturnMsg = SqlStrToDt(SQL_Get_Dt_Mini_WL & " where WL_No=@WL_No", "WL_No", WL_No)
            If R.IsOk = False Then
                Return Nothing
            Else
                If R.Dt.Rows.Count > 0 Then
                    Return R.Dt.Rows(0)
                Else
                    Return Nothing
                End If
            End If
        Else
            Dim Dr() As DataRow = Dt_Mini_WL.Select("WL_No='" & WL_No & "'")
            If Dr.Length > 0 Then
                Return Dr(0)
            Else
                Return Nothing
            End If
        End If
    End Function

    ''' <summary>
    ''' 获取物料信息
    ''' </summary>
    ''' <param name="No"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function WL_GetByNo(ByVal No As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_WL_GetByNo, "@WL_No", No)
    End Function
    ''' <summary>
    ''' 获取物料信息
    ''' </summary>
    ''' <param name="No"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Metal_GetByNo(ByVal No As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_Metal_GetByNo, "@WL_No", No)
    End Function
    ''' <summary>
    ''' 获取物料信息
    ''' </summary>
    ''' <param name="No"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Kitchen_GetByNo(ByVal No As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_Kitchen_GetByNo, "@WL_No", No)
    End Function
    ''' <summary>
    ''' 获取物料信息
    ''' </summary>
    ''' <param name="No"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function PolyBag_GetByNo(ByVal No As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_PolyBag_GetByNo, "@WL_No", No)
    End Function

    ''' <summary>
    ''' 获取物料信息
    ''' </summary>
    ''' <param name="No"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Cocal_GetByNo(ByVal No As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_PolyBag_GetByNo, "@WL_No", No)
    End Function




#End Region
#Region "仓库获取"
    Public Shared Function GetStoreDt() As DataTable
        Dim R As DtReturnMsg = SqlStrToDt("select * from T10003_Store")
        If R.IsOk Then
            Return R.Dt
        Else
            R.Dt = New DataTable
            R.Dt.Columns.Add("ID", GetType(Integer))
            R.Dt.Columns.Add("Store_Name", GetType(Integer))
            R.Dt.Columns.Add("Store_Remark", GetType(Integer))
            R.Dt.Columns.Add("Store_FindHelper", GetType(Integer))
            R.Dt.Columns.Add("Store_Manager", GetType(Integer))
            R.Dt.Columns.Add("Store_MRP", GetType(Integer))
            Return R.Dt
        End If
    End Function
#End Region
#Region "色号"


    Public Shared Dt_Mini_Bzc As DataTable
    Public Shared Sub Get_Dt_Mini_Bzc()
        Dim R As DtReturnMsg = SqlStrToDt("select ID,BZC_No,BZC_Name,BZC_FindHelper from T10003_BZC order by BZC_No")
        If R.IsOk Then
            Dt_Mini_Bzc = R.Dt
        End If
    End Sub
#End Region

#Region "车牌"
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetChePaiList() As DtReturnMsg
        Dim sqlStr As String = "select Remark,Remark2 from T10200_Remark where Remark_Type=" & Enum_RemarkType.ChePai
        Return SqlStrToDt(sqlStr)

    End Function
#End Region
#End Region


#End Region

#Region "获取生产单状态显示名"

    Public Shared Function ProduceStateName(ByVal state As Enum_ProduceState) As String
        Select Case state
            Case Enum_ProduceState.Invalid
                Return "已作废"
            Case Enum_ProduceState.XiaDan
                Return "已下单"
            Case Enum_ProduceState.PeiBu
                Return "已配布"
            Case Enum_ProduceState.YuDing
                Return "预定"
            Case Enum_ProduceState.RanSe
                Return "染色"
            Case Enum_ProduceState.TuoShui
                Return "脱水"
            Case Enum_ProduceState.ZhongJian
                Return "中检"
            Case Enum_ProduceState.KaiFu
                Return "开幅"
            Case Enum_ProduceState.DingXing
                Return "定型"
            Case Enum_ProduceState.ChengJian
                Return "成检"
            Case Enum_ProduceState.SongHuo
                Return "已送货"
            Case Else
                Return "新建"
        End Select
    End Function


    Public Shared Function GetProduceStateName(ByVal state As Enum_ProduceState) As String
        'Select Case state
        '    Case Enum_ProduceState.Invalid
        '        Return "已作废"
        '    Case Enum_ProduceState.XiaDan
        '        Return "已下单"

        '    Case Enum_ProduceState.PeiBu
        '        Return "已配布"
        '    Case Enum_ProduceState.YuDing
        '        Return "预定"
        '    Case Enum_ProduceState.RanSe
        '        Return "染色"
        '    Case Enum_ProduceState.TuoShui
        '        Return "脱水"
        '    Case Enum_ProduceState.ZhongJian
        '        Return "中检"
        '    Case Enum_ProduceState.KaiFu
        '        Return "开幅"
        '    Case Enum_ProduceState.DingXing
        '        Return "定型"
        '    Case Enum_ProduceState.ChengJian
        '        Return "成检"
        '    Case Enum_ProduceState.SongHuo
        '        Return "已送货"
        '    Case Else
        '        Return "新建"
        'End Select

        If state <= Enum_ProduceState.Invalid Then
            Return "已作废"
        ElseIf state >= Enum_ProduceState.XiaDan And state < Enum_ProduceState.PeiBu Then
            Return "已下单"
        ElseIf state >= Enum_ProduceState.PeiBu And state < Enum_ProduceState.SongBu Then
            Return "已配布"
        ElseIf state >= Enum_ProduceState.SongBu And state < Enum_ProduceState.YuDing Then
            Return "已松布"
        ElseIf state >= Enum_ProduceState.YuDing And state < Enum_ProduceState.RanSe Then
            Return "已预定"
        ElseIf state >= Enum_ProduceState.RanSe And state < Enum_ProduceState.ChuGang Then
            Return "已染色"
        ElseIf state >= Enum_ProduceState.ChuGang And state < Enum_ProduceState.TuoShui Then
            Return "已出缸"
        ElseIf state >= Enum_ProduceState.TuoShui And state < Enum_ProduceState.ZhongJian Then
            Return "已脱水"
        ElseIf state >= Enum_ProduceState.ZhongJian And state < Enum_ProduceState.KaiFu Then
            Return "已中检"
        ElseIf state >= Enum_ProduceState.KaiFu And state < Enum_ProduceState.DingXing Then
            Return "已开幅"
        ElseIf state >= Enum_ProduceState.DingXing And state < Enum_ProduceState.ChengJianZhong Then
            Return "已定型"
        ElseIf state >= Enum_ProduceState.ChengJianZhong And state < Enum_ProduceState.ChengJian Then
            Return "成检中"
        ElseIf state >= Enum_ProduceState.ChengJian And state < Enum_ProduceState.RuKu Then
            Return "已成检"
        ElseIf state >= Enum_ProduceState.RuKu And state < Enum_ProduceState.SongHuo Then
            Return "成品入库"
        ElseIf state >= Enum_ProduceState.SongHuo Then
            Return "已送货"
        Else
            Return "新建"
        End If

    End Function

    ''' <summary>
    ''' 工序状态
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetWorkStateName(ByVal state As Enum_WorkState) As String
        Select Case state
            Case Enum_WorkState.Start
                Return "已开始"
            Case Enum_WorkState.Finish
                Return "已结束"
            Case Enum_WorkState.None
                Return "待处理"
            Case Else
                Return "错误状态"
        End Select
    End Function





#End Region


#Region "获取生成部门的集合"
    ''' <summary>
    ''' 获取生成部门的集合
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Productive_GetList() As DtReturnMsg
        Dim R As New DtReturnMsg
        Dim sql As String = "select Dept_No,Dept_Name from T15000_Department  where IsProductive=1"
        Return PClass.PClass.SqlStrToDt(sql)
    End Function
#End Region



#Region "获取备注集合"
    ''' <summary>
    ''' 获取备注集合
    ''' </summary>
    ''' <param name="_remarkType"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Remark_GetList(ByVal _remarkType As Enum_RemarkType) As DtReturnMsg
        Dim R As New DtReturnMsg
        Dim sql As String = "select Remark from T10200_Remark  where Remark_Type=@Remark_Type"
        Dim para As New Dictionary(Of String, Enum_RemarkType)
        Return PClass.PClass.SqlStrToDt(sql, "@Remark_Type", _remarkType)

    End Function

#End Region

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function StoreMap_CheckStoreNo(ByVal _sNo As String) As DtReturnMsg
        Dim sql As String = " select sNo from T40500_Store_Map where  sNo=@sNo and @sNo<>'' "
        Return PClass.PClass.SqlStrToDt(sql, "@sNo", _sNo)

    End Function



#Region "单据状态"
    Public Shared Function GetStateName(ByVal state As Enum_State) As String
        Select Case state
            Case Enum_State.AddNew
                Return "新建"
            Case Enum_State.Audited
                Return "已审核"
            Case Enum_State.Invoid
                Return "已作废"
            Case Else
                Return "新建"
        End Select
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="state"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetStateName_Upgrade(ByVal state As Enum_State) As String
        Select Case state
            Case Enum_StroeOutstate.AddNew
                Return "新建"
            Case Enum_StroeOutstate.Comfirm
                Return "已确认"
            Case Enum_StroeOutstate.Audited
                Return "已审核"
            Case Enum_StroeOutstate.Invoid
                Return "已作废"
            Case Else
                Return "新建"
        End Select
    End Function

    ''' <summary>
    ''' 备货单状态解释器
    ''' </summary>
    ''' <param name="state"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetStoreStateName(ByVal state As Enum_StroeOutstate) As String
        Select Case state
            Case Enum_StroeOutstate.AddNew
                Return "新建"
            Case Enum_StroeOutstate.Comfirm
                Return "已确认"
            Case Enum_StroeOutstate.Audited
                Return "已审核"
            Case Enum_StroeOutstate.Invoid
                Return "已作废"
            Case Else
                Return "新建"
        End Select
    End Function



    Public Shared Function GetBZSH_StateName(ByVal state As Enum_BZSHState) As String
        Select Case state
            Case Enum_BZSHState.AddNew
                Return "新建"
            Case Enum_BZSHState.Store_Comfirm
                Return "已确认"
            Case Enum_BZSHState.Audited
                Return "已审核"
            Case Enum_BZSHState.Invoid
                Return "已作废"
            Case Else
                Return "新建"
        End Select
    End Function

    Public Shared Function GetPBRK_StateName(ByVal state As Enum_PBRK_State) As String
        Select Case state
            Case Enum_PBRK_State.AddNew
                Return "新建"
            Case Enum_PBRK_State.Confirm
                Return "已确认"
            Case Enum_PBRK_State.Audited
                Return "已审核"
            Case Enum_PBRK_State.Invoid
                Return "已作废"
            Case Else
                Return "新建"
        End Select
    End Function
#End Region


#Region "生成单据编号"





    Private Shared Function GetBillTable(ByVal BT As BillType) As String
        Select Case BT
            Case BillType.CostChange
                Return "T10005_CostChange"
            Case BillType.ReleasePass
                Return "T15540_AT_ReleasePass"
            Case BillType.MetalCostChange
                Return "T21005_CostChange"
            Case BillType.Produce
                Return "T30000_Produce_Gd"
            Case BillType.ApplyPurchase
                Return "T20000_Puchase_Table"
            Case BillType.Purchase
                Return "T20020_ApplyPurchase_Table"
            Case BillType.StoreIn
                Return "T20200_StoreIn_Table"
            Case BillType.StoreOut
                Return "T20300_StoreOut_Table"
            Case BillType.Assemble_Requisition
                Return "T20310_Assemble_Requisition_Table"
            Case BillType.SGLingLiao
                Return "T20330_SGLingLiao_Table"
            Case BillType.DXLingLiao
                Return "T20310_LingLiao_Table"
            Case BillType.PurchaseReturn
                Return "T20010_PurchaseReturn_Table"
            Case BillType.StockAdjust
                Return "T20400_StockAdjust_Table"


            Case BillType.Purchase_MT
                Return "T21100_Puchase_Table"

            Case BillType.PurchaseCoal
                Return "T21114_Purchase_Coal_Table"

            Case BillType.PurchaseReturn_MT
                Return "T21110_PurchaseReturn_Table"
            Case BillType.StoreIn_MT
                Return "T21200_StoreIn_Table"
            Case BillType.StoreOut_MT
                Return "T21300_StoreOut_Table"
            Case BillType.LingLiao_MT
                Return "T21300_StoreOut_Table"

            Case BillType.OtherOut
                Return "T20302_OtherOut_Table"
            Case BillType.BeiStoreOut
                Return "T20302_OtherOut_Table"

            Case BillType.KitchenCostChange
                Return "T22005_CostChange"
            Case BillType.Purchase_KT
                Return "T22100_Puchase_Table"
            Case BillType.PurchaseReturn_KT
                Return "T22110_PurchaseReturn_Table"
            Case BillType.StoreIn_KT
                Return "T22200_StoreIn_Table"
            Case BillType.StoreOut_KT
                Return "T22300_StoreOut_Table"
            Case BillType.LingLiao_KT
                Return "T22300_StoreOut_Table"


            Case BillType.PolyBagCostChange
                Return "T24005_CostChange"
            Case BillType.Purchase_Bag
                Return "T24100_Puchase_Table"
            Case BillType.PurchaseReturn_Bag
                Return "T24110_PurchaseReturn_Table"
            Case BillType.StoreIn_Bag
                Return "T24200_StoreIn_Table"
            Case BillType.StoreOut_Bag
                Return "T24300_StoreOut_Table"
            Case BillType.LingLiao_Bag
                Return "T24300_StoreOut_Table"

            Case BillType.Schedule
                Return " T27120_Schedule_Table"

            Case BillType.CoCostChange
                Return "T26005_CostChange"
            Case BillType.Purchase_CO
                Return "T26100_Puchase_Table"
            Case BillType.PurchaseReturn_CO
                Return "T26110_PurchaseReturn_Table"
            Case BillType.StoreIn_CO
                Return "T26200_StoreIn_Table"
            Case BillType.StoreOut_CO
                Return "T26300_StoreOut_Table"
            Case BillType.LingLiao_CO
                Return "T26300_StoreOut_Table"
            Case BillType.ClientOrder
                Return "T27000_ClientOrder_Table"
            Case BillType.ProduceOrder
                Return "T27110_ProduceOrder_Table"

            Case BillType.AssembleOrder
                Return "T27130_AssembleOrder_Table"



            Case BillType.Delivery
                Return " T27200_Delivery_Table"

            Case BillType.ReturnGoods
                Return "T27210_ReturnGoods_Table"

            Case BillType.ProLiLiao
                Return " T27140_ProLiLiao_Table"


            Case BillType.PBStore
                Return "T40204_PBStore_Table"

            Case BillType.RBReport
                Return "T30207_DayReport_Table"

            Case BillType.Inform
                Return "T30231_RetrunInform"

            Case BillType.DXReport
                Return "T30207_DayReport_Table"

            Case BillType.QLReport
                Return "T30220_QualityDayReport_Table"
            Case BillType.Applique
                Return "T30225_BBSQ_Table"
            Case BillType.GHSQ
                Return "T30227_GHSQ_Table"
            Case BillType.GSSQ
                Return "T30229_GSSQ_Table"

            Case BillType.CPIni
                Return "T40310_CPIni_Table"
            Case BillType.Price
                Return "T50000_Price_Table"
            Case BillType.BZSH_Balance
                Return "T50100_CBalance_Table"


            Case BillType.ProcessPrice
                Return "T50010_ProcessPrice_Table"
            Case BillType.IniTouch
                Return "T50012_SGPrice_Table"

            Case BillType.InnerPrice
                Return "T50030_InnerPrice_Table"

            Case BillType.PBTC
                Return "T40150_PBTC_Table"
            Case BillType.BZSH
                Return "T40000_BZSH_Table"
            Case BillType.OutWork
                Return "T40002_OutWork_Table"
            Case BillType.PBRK
                Return "T40100_PBRK_Table"
            Case Else
                Return ""
        End Select
    End Function
    ''' <summary>
    ''' 获取新单号
    ''' </summary>
    ''' <param name="BillType">单据类型</param>
    ''' <param name="D">单据日期</param>
    ''' <param name="LastNo">上次日期</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetBillNewID(ByVal BillType As BillType, ByVal D As Date, ByVal LastNo As String, ByVal BillStart As String, ByVal BillLong As Integer) As RetrunNewIdMsg
        Dim R As New RetrunNewIdMsg
        If BillStart Is Nothing Then
            BillStart = ""
        End If
        Dim BillTable As String = GetBillTable(BillType)

        Dim P As New Dictionary(Of String, Object)
        Dim IDStr As String = "ID"
        Dim GetNewID As String = "GetNewID"

        DelBillNewID(BillType, LastNo, IDStr)
        P.Add("@BillType", BillType)
        P.Add("@BillTable", BillTable)
        P.Add("@BillStart", BillStart)
        P.Add("@Field", IDStr)
        P.Add("@Zero", BillLong)
        R.MaxDate = GetMaxDate()
        If D <= R.MaxDate Then
            R.IsTheDate = False
            D = R.MaxDate.AddDays(1)
            R.RetrunMsg = "你选择的日期小于或等于日结日期!"
        Else
            R.IsTheDate = True
            R.RetrunMsg = "获取单号成功"
        End If
        R.NewIdDate = D
        P.Add("@Date", D.ToString("yyyy-MM-dd"))
        Dim MR As MsgReturn = SqlStrToOneStr("GetNewID", P, True)
        If MR.IsOk = True Then
            R.IsOk = True
            R.NewID = MR.Msg
        Else
            R.IsOk = False
            R.RetrunMsg = "获取单号失败"
        End If
        Return R
    End Function
    ''' <summary>
    ''' 获取新单号
    ''' </summary>
    ''' <param name="BillType">单据类型</param>
    ''' <param name="D">单据日期</param>
    ''' <param name="LastNo">上次日期</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetBillNewID(ByVal BillType As BillType, ByVal D As Date, ByVal LastNo As String) As RetrunNewIdMsg
        Dim R As New RetrunNewIdMsg
        Dim BillStart As String = ""
        Dim BillTable As String = GetBillTable(BillType)
        Dim BillLong As Integer = 4
        Dim P As New Dictionary(Of String, Object)
        Dim IDStr As String = "ID"
        Dim GetNewID As String = "GetNewID"
        Select Case BillType

            Case BillType.CostChange
                BillStart = "CC"
                BillLong = 4
            Case BillType.ReleasePass
                BillStart = "RP"
                BillLong = 4
            Case BillType.KitchenCostChange
                BillStart = "KCC"
                BillLong = 4
            Case BillType.Applique
                BillStart = "BBQ"
                BillLong = 4
            Case BillType.GHSQ
                BillStart = "GHQ"
                BillLong = 4
            Case BillType.GSSQ
                BillStart = "GSQ"
                BillLong = 4
            Case BillType.MetalCostChange
                BillStart = "MCC"
                BillLong = 4
            Case BillType.Produce
                BillStart = "GY"
                BillLong = 3
                IDStr = "GH"
            Case BillType.Purchase
                BillStart = "CG"
                BillLong = 4
            Case BillType.ApplyPurchase
                BillStart = "SG"
                BillLong = 4
            Case BillType.PurchaseReturn
                BillStart = "CT"
                BillLong = 4
            Case BillType.StoreIn
                BillStart = "RK"
                BillLong = 4
            Case BillType.StoreOut
                BillStart = "CK"
                BillLong = 4
                '备货出库
            Case BillType.BeiStoreOut
                BillStart = "BH"
                BillLong = 4
            Case BillType.LingLiao
                BillStart = "LL"
                BillLong = 4
            Case BillType.SGLingLiao
                BillStart = "SGLL"
                BillLong = 4
            Case BillType.DXLingLiao
                BillStart = "DL"
                BillLong = 4
            Case BillType.StockAdjust
                BillStart = "STAD"
                BillLong = 4

            Case BillType.Purchase_MT
                BillStart = "WJCG"
                BillLong = 4
            Case BillType.PurchaseReturn_MT
                BillStart = "WJCT"
                BillLong = 4
            Case BillType.StoreIn_MT
                BillStart = "WJRK"
                BillLong = 4
            Case BillType.StoreOut_MT
                BillStart = "WJCK"
                BillLong = 4
            Case BillType.LingLiao_MT
                BillStart = "WJLL"
                BillLong = 4



            Case BillType.Purchase_CO
                BillStart = "COCG"
                BillLong = 4
            Case BillType.PurchaseReturn_CO
                BillStart = "COCT"
                BillLong = 4
            Case BillType.StoreIn_CO
                BillStart = "CORK"
                BillLong = 4
            Case BillType.StoreOut_CO
                BillStart = "COCK"
                BillLong = 4
            Case BillType.LingLiao_CO
                BillStart = "COLL"
                BillLong = 4

                '客户订单单号
            Case BillType.ClientOrder
                BillStart = "CO"
                BillLong = 4

                '生产领料单
            Case BillType.ProLiLiao
                BillStart = "PL"
                BillLong = 4

            Case BillType.Delivery
                BillStart = "SH"
                BillLong = 4

            Case BillType.ReturnGoods
                BillStart = "RG"
                BillLong = 4

            Case BillType.OtherOut
                BillStart = "OT"
                BillLong = 4


                '生产指令单单号
            Case BillType.ProduceOrder
                BillStart = "PO"
                BillLong = 4

                '生产排期单
            Case BillType.Schedule
                BillStart = "SC"
                BillLong = 4

                '装配单单号
            Case BillType.AssembleOrder
                BillStart = "AO"
                BillLong = 4

            Case BillType.Inform
                BillStart = "RI"
                BillLong = 4

            Case BillType.Purchase_Bag
                BillStart = "BGCG"
                BillLong = 4
            Case BillType.PurchaseReturn_Bag
                BillStart = "BGCT"
                BillLong = 4
            Case BillType.StoreIn_Bag
                BillStart = "BGRK"
                BillLong = 4
            Case BillType.StoreOut_Bag
                BillStart = "BGCK"
                BillLong = 4
            Case BillType.LingLiao_Bag
                BillStart = "BGLL"
                BillLong = 4

            Case BillType.PBStore
                BillStart = "PS"
                BillLong = 4

            Case BillType.PurchaseCoal
                BillStart = "PC"
                BillLong = 4

            Case BillType.Purchase_KT
                BillStart = "CFCG"
                BillLong = 4
            Case BillType.PurchaseReturn_KT
                BillStart = "CFCT"
                BillLong = 4
            Case BillType.StoreIn_KT
                BillStart = "CFRK"
                BillLong = 4
            Case BillType.StoreOut_KT
                BillStart = "CFCK"
                BillLong = 4
            Case BillType.LingLiao_KT
                BillStart = "CFLL"
                BillLong = 4




            Case BillType.Price
                BillStart = "BJ"
                BillLong = 4
            Case BillType.IniTouch
                BillStart = "SGBJ"
                BillLong = 4
            Case BillType.ProcessPrice
                BillStart = "PP"
                BillLong = 4

            Case BillType.BZSH_Balance
                BillStart = "BB"
                BillLong = 4
            Case BaseClass.BillType.PBTC
                BillStart = "TC"
                BillLong = 4

            Case BillType.OutWork
                BillStart = "OW"
                BillLong = 4

        End Select
        DelBillNewID(BillType, LastNo, IDStr)
        P.Add("@BillType", BillType)
        P.Add("@BillTable", BillTable)
        P.Add("@BillStart", BillStart)
        P.Add("@Field", IDStr)
        P.Add("@Zero", BillLong)
        R.MaxDate = GetMaxDate()
        If D <= R.MaxDate Then
            R.IsTheDate = False
            D = R.MaxDate.AddDays(1)
            R.RetrunMsg = "你选择的日期小于或等于日结日期!"
        Else
            R.IsTheDate = True
            R.RetrunMsg = "获取单号成功"
        End If
        R.NewIdDate = D
        P.Add("@Date", D.ToString("yyyy-MM-dd"))
        Dim MR As MsgReturn = SqlStrToOneStr("GetNewID", P, True)
        If MR.IsOk = True Then
            R.IsOk = True
            R.NewID = MR.Msg
        Else
            R.IsOk = False
            R.RetrunMsg = "获取单号失败"
        End If
        Return R
    End Function

    Public Shared Sub DelBillNewID(ByVal BillType As BillType, ByVal LastNo As String, Optional ByVal IDStr As String = "ID")
        If LastNo <> "" Then
            Dim P As New Dictionary(Of String, Object)
            Dim s() As String = LastNo.Split("-")
            If s.Length > 1 AndAlso s(0).Length >= 6 Then '检查旧的单号是否存在
                Dim BillTable As String = GetBillTable(BillType)
                Dim Mr1 As MsgReturn = SqlStrToOneStr("select count(*) from " & BillTable & " where " & IDStr & "=@id", "@ID", LastNo.Replace("-", ""))
                If Mr1.IsOk Then
                    P.Add("@Type", BillType)
                    Dim DStr As String = s(0).Substring(s(0).Length - 6)
                    Try
                        P.Add("@sDate", "20" & DStr.Substring(0, 2) & "-" & DStr.Substring(2, 2) & "-" & DStr.Substring(4, 2))
                        P.Add("@sIndex", Val(s(1)))

                        RunSQL("update Bill_Index set sIndex=sIndex-1 where Type=@Type and sDate=@sDate and sIndex=@sIndex", P)
                    Catch ex As Exception
                    End Try
                End If
            End If
        End If
    End Sub


    ''' <summary>
    ''' 获取新单号
    ''' </summary>
    ''' <param name="BillType"></param>
    ''' <param name="billStart"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetBillNewID_Prefix(ByVal BillType As BillType, ByVal D As Date, ByVal LastNo As String, ByVal BillStart As String, ByVal BillLong As Integer) As RetrunNewIdMsg
        Dim R As New RetrunNewIdMsg
        If BillStart Is Nothing Then
            BillStart = ""
        End If
        Dim BillTable As String = GetBillTable(BillType)

        Dim P As New Dictionary(Of String, Object)
        Dim IDStr As String = "ID"
        Dim GetNewID As String = "GetNewIDOnlyYear"

        DelBillNewID_Prefix(BillType, LastNo, IDStr)
        P.Add("@BillType", BillType)
        P.Add("@BillTable", BillTable)
        P.Add("@BillStart", BillStart)
        P.Add("@Field", IDStr)
        P.Add("@Zero", BillLong)
        R.MaxDate = GetMaxDate()
        If D <= R.MaxDate Then
            R.IsTheDate = False
            D = R.MaxDate.AddDays(1)
            R.RetrunMsg = "你选择的日期小于或等于日结日期!"
        Else
            R.IsTheDate = True
            R.RetrunMsg = "获取单号成功"
        End If
        R.NewIdDate = D
        P.Add("@Date", D.ToString("yyyy-MM-dd"))
        Dim MR As MsgReturn = SqlStrToOneStr(GetNewID, P, True)
        If MR.IsOk = True Then
            R.IsOk = True
            R.NewID = MR.Msg
        Else
            R.IsOk = False
            R.RetrunMsg = "获取单号失败"
        End If
        Return R
    End Function

    Public Shared Sub DelBillNewID_Prefix(ByVal BillType As BillType, ByVal LastNo As String, Optional ByVal IDStr As String = "ID")
        If LastNo <> "" Then
            Dim P As New Dictionary(Of String, Object)
            Dim s() As String = LastNo.Split("-")
            If s.Length > 1 AndAlso s(0).Length >= 4 Then '检查旧的单号是否存在
                Dim BillTable As String = GetBillTable(BillType)
                Dim Mr1 As MsgReturn = SqlStrToOneStr("select count(*) from " & BillTable & " where " & IDStr & "=@id", "@ID", LastNo.Replace("-", ""))
                If Mr1.IsOk Then
                    P.Add("@BillType", BillType)
                    'Dim DStr As String = s(0).Substring(s(0).Length - 2)
                    Try
                        P.Add("@Prefix", s(0))
                        P.Add("@sIndex", Val(s(1)))

                        RunSQL("update Bill_Index_Prefix set sIndex=sIndex-1 where BillType=@BillType and Prefix=@Prefix and sIndex=@sIndex", P)
                    Catch ex As Exception
                    End Try
                End If
            End If
        End If
    End Sub

#End Region


#Region "出,入库原因"

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function StoreIn_GetReason(ByVal remarkType As Enum_RemarkType)
        Return PClass.PClass.SqlStrToDt(SQL_StoreReason, "@Remark_Type", remarkType)
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function StoreOut_GetReason(ByVal remarkType As Enum_RemarkType)
        Return PClass.PClass.SqlStrToDt(SQL_StoreReason, "@Remark_Type", remarkType)
    End Function
#End Region



#Region "双击行调出对应的单据"

    Public Delegate Sub DbClickReturn()



    'Public Shared Sub ShowBill(ByVal BillName As String, ByVal _Id As String, ByRef pForm As PClass.BaseForm)
    '    Dim billID As Integer = 0
    '    Select Case BillName
    '        Case "采购收货单"
    '            billID = 2001
    '        Case "领料单"
    '            billID = 40111

    '        Case "退料单"
    '            billID = 40011

    '        Case "其他出库单"
    '            billID = 40101

    '        Case "其他入库单"
    '            billID = 40001

    '        Case "验收单"
    '            billID = 30021

    '        Case "采购退货单"
    '            billID = 20011

    '    End Select
    '    Dim f As PClass.BaseForm = PClass.PClass.LoadFormIDToChild(billID, pForm)
    '    If f Is Nothing Then Exit Sub

    '    With f
    '        .Mode = Mode_Enum.Modify
    '        .P_F_RS_ID = _Id
    '        .IsSel = True
    '    End With
    '    pForm.ReturnId = ""
    '    pForm.ReturnObj = Nothing
    '    Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(f, pForm)
    '    '      AddHandler VF.ClosedX, AddressOf returnMethod

    '    VF.Show()
    'End Sub


    Public Shared Function ShowBill(ByVal BillType As Integer, ByVal _Id As String, ByRef pForm As PClass.BaseForm) As PClass.BaseForm
        Dim f As PClass.BaseForm = PClass.PClass.LoadModifyFormByID(BillType)
        If f Is Nothing Then Return Nothing
        With f
            .Mode = Mode_Enum.Modify
            .P_F_RS_ID = _Id
        End With
        pForm.ReturnId = ""
        pForm.ReturnObj = Nothing
        Return f
    End Function

#End Region

#Region "单据类型，下拉列表集合"


    ''' <summary>
    ''' 获取进销存表中唯一的单据名称集合
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function JXC_GetBillTypeList() As DataTable
        '   Return PClass.PClass.SqlStrToDt(SQL_JXC_GetBillType)
        Dim dt As New DataTable
        dt.Columns.Add("BillName", GetType(String))
        dt.Columns.Add("BillType", GetType(Integer))

        Dim dr As DataRow

        dr = dt.NewRow
        dr("BillName") = "选择单据"
        dr("BillType") = 0
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("BillName") = "订单"
        dr("BillType") = 270
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("BillName") = "  客户订单"
        dr("BillType") = 27000
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("BillName") = "采购"
        dr("BillType") = 200
        dt.Rows.Add(dr)

        'dr = dt.NewRow
        'dr("BillName") = "  申购单"
        'dr("BillType") = 20000
        'dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("BillName") = "  采购单"
        dr("BillType") = 20010
        dt.Rows.Add(dr)




        dr = dt.NewRow
        dr("BillName") = "入库"
        dr("BillType") = 202
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("BillName") = "  其它入库单"
        dr("BillType") = 20200
        dt.Rows.Add(dr)

        'dr = dt.NewRow
        'dr("BillName") = "  退料单"
        'dr("BillType") = 20210
        'dt.Rows.Add(dr)



        dr = dt.NewRow
        dr("BillName") = "出库"
        dr("BillType") = 203
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("BillName") = "  其它出库单"
        dr("BillType") = 20302
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("BillName") = "  备货出库单"
        dr("BillType") = 20300
        dt.Rows.Add(dr)

        'dr = dt.NewRow
        'dr("BillName") = "  染部领料单"
        'dr("BillType") = 20310
        'dt.Rows.Add(dr)

        'dr = dt.NewRow
        'dr("BillName") = "  定型领料单"
        'dr("BillType") = 20320
        'dt.Rows.Add(dr)

        Return dt
    End Function

    ''' <summary>
    ''' 获取进销存表中唯一的单据名称集合
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function JXC_GetBillTypeList_Metal() As DataTable
        '   Return PClass.PClass.SqlStrToDt(SQL_JXC_GetBillType)
        Dim dt As New DataTable
        dt.Columns.Add("BillName", GetType(String))
        dt.Columns.Add("BillType", GetType(Integer))

        Dim dr As DataRow

        dr = dt.NewRow
        dr("BillName") = "选择单据"
        dr("BillType") = 0
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("BillName") = "五金采购"
        dr("BillType") = 211
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("BillName") = "  五金采购单"
        dr("BillType") = 21100
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("BillName") = "  五金退货单"
        dr("BillType") = 21110
        dt.Rows.Add(dr)




        dr = dt.NewRow
        dr("BillName") = "五金入库"
        dr("BillType") = 212
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("BillName") = "  五金其它入库单"
        dr("BillType") = 21200
        dt.Rows.Add(dr)





        dr = dt.NewRow
        dr("BillName") = "五金出库"
        dr("BillType") = 213
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("BillName") = "  五金其它出库单"
        dr("BillType") = 21300
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("BillName") = "  五金领料单"
        dr("BillType") = 211310
        dt.Rows.Add(dr)
        Return dt
    End Function


    ''' <summary>
    ''' 获取进销存表中唯一的单据名称集合
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function JXC_GetBillTypeList_Cocal() As DataTable
        '   Return PClass.PClass.SqlStrToDt(SQL_JXC_GetBillType)
        Dim dt As New DataTable
        dt.Columns.Add("BillName", GetType(String))
        dt.Columns.Add("BillType", GetType(Integer))

        Dim dr As DataRow

        dr = dt.NewRow
        dr("BillName") = "选择单据"
        dr("BillType") = 0
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("BillName") = "采购"
        dr("BillType") = 261
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("BillName") = "  采购单"
        dr("BillType") = 26100
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("BillName") = "  退货单"
        dr("BillType") = 26110
        dt.Rows.Add(dr)




        dr = dt.NewRow
        dr("BillName") = "入库"
        dr("BillType") = 262
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("BillName") = "  其它入库单"
        dr("BillType") = 26200
        dt.Rows.Add(dr)





        dr = dt.NewRow
        dr("BillName") = "出库"
        dr("BillType") = 263
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("BillName") = "  其它出库单"
        dr("BillType") = 26300
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("BillName") = "  领料单"
        dr("BillType") = 261310
        dt.Rows.Add(dr)
        Return dt
    End Function










    ''' <summary>
    ''' 获取进销存表中唯一的单据名称集合
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function JXC_GetBillTypeList_PolyBag() As DataTable
        '   Return PClass.PClass.SqlStrToDt(SQL_JXC_GetBillType)
        Dim dt As New DataTable
        dt.Columns.Add("BillName", GetType(String))
        dt.Columns.Add("BillType", GetType(Integer))

        Dim dr As DataRow

        dr = dt.NewRow
        dr("BillName") = "选择单据"
        dr("BillType") = 0
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("BillName") = "胶袋采购"
        dr("BillType") = 211
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("BillName") = "  胶袋采购单"
        dr("BillType") = 21100
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("BillName") = "  胶袋退货单"
        dr("BillType") = 21110
        dt.Rows.Add(dr)




        dr = dt.NewRow
        dr("BillName") = "胶袋入库"
        dr("BillType") = 212
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("BillName") = "  胶袋其它入库单"
        dr("BillType") = 21200
        dt.Rows.Add(dr)





        dr = dt.NewRow
        dr("BillName") = "胶袋出库"
        dr("BillType") = 213
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("BillName") = "  胶袋其它出库单"
        dr("BillType") = 21300
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("BillName") = "  胶袋领料单"
        dr("BillType") = 211310
        dt.Rows.Add(dr)
        Return dt
    End Function



    ''' <summary>
    ''' 获取进销存表中唯一的单据名称集合
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function JXC_GetBillTypeList_kitchen() As DataTable
        '   Return PClass.PClass.SqlStrToDt(SQL_JXC_GetBillType)
        Dim dt As New DataTable
        dt.Columns.Add("BillName", GetType(String))
        dt.Columns.Add("BillType", GetType(Integer))

        Dim dr As DataRow

        dr = dt.NewRow
        dr("BillName") = "选择单据"
        dr("BillType") = 0
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("BillName") = "厨房采购"
        dr("BillType") = 221
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("BillName") = "厨房采购单"
        dr("BillType") = 22100
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("BillName") = "厨房退货单"
        dr("BillType") = 22110
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("BillName") = "厨房入库"
        dr("BillType") = 222
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("BillName") = "厨房其它入库单"
        dr("BillType") = 22200
        dt.Rows.Add(dr)


        dr = dt.NewRow
        dr("BillName") = "厨房出库"
        dr("BillType") = 223
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("BillName") = "厨房其它出库单"
        dr("BillType") = 22300
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("BillName") = "厨房领料单"
        dr("BillType") = 221310
        dt.Rows.Add(dr)

        Return dt
    End Function
#End Region



#Region "根据物料获取库存"

    Public Shared Function GetWLQty(ByVal WL_ID As Integer) As Decimal
        Dim Qty As Decimal = 0
        Dim SQL_GetWL As String = "Select Isnull(WL_Qty,0)-Isnull(WL_BeiQty,0) As Qty  from  T10001_WL Where ID=@ID"
        Dim DtMsg As DtReturnMsg = PClass.PClass.SqlStrToDt(SQL_GetWL, "@ID", WL_ID)
        If DtMsg.IsOk AndAlso DtMsg.Dt.Rows.Count = 1 Then
            Qty = DtMsg.Dt.Rows(0)("Qty")
        End If
        Return Qty
    End Function


#End Region




#Region "获取当前用户的部门"
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="_userID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function User_GetDept(ByVal _userID As String) As DtReturnMsg
        Dim sql As String = SQL_User_GetDept
        Return SqlStrToDt(sql, "@User_ID", _userID)
    End Function
#End Region

#Region "部门"
    Private Const SQL_Dept_GetByEmpName = "select top 1 E.ID,Dept_No,Dept_Name,(select  Job_Name from T15003_Job j where Employee_job=j.ID )Job_Name from T15001_Employee E ,T15000_Department D where E.Employee_Dept =D.Dept_No and E.Employee_Name=@Emp_Name"

    ''' <summary>
    ''' 获取最上层的部门
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Dept_Get()
        Return PClass.PClass.SqlStrToDt(SQL_Dept_Get)
    End Function


    ''' <summary>
    ''' 获取所有部门（已排序）
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Dept_GetAll()
        Return SqlStrToDt("select *  from V15000_Dept ")
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Employee_GetAll() As DtReturnMsg
        Return SqlStrToDt("select *  from T15001_Employee order by Employee_Dept ,ID ")
    End Function

    ''' <summary>
    ''' 根据员工名称查询部门编号，名称
    ''' </summary>
    ''' <param name="_name"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Dept_GetByEmpName(ByVal _name As String) As DtReturnMsg
        Return SqlStrToDt(SQL_Dept_GetByEmpName, "@Emp_Name", _name)
    End Function
#End Region

#Region "单位转换"

    ''' <summary>
    ''' 获取单位转换率
    ''' </summary>
    ''' <param name="_Unit_Display"></param>
    ''' <param name="WL_Unit"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Unit_Convert(ByVal _Unit_Display As String, ByVal WL_Unit As String) As Double


    End Function

#End Region

#Region "客户"


    ''' <summary>
    ''' 根据ID获取客户资料
    ''' </summary>
    ''' <param name="ID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Clinet_GetBy_ID(ByVal ID As Integer) As DtReturnMsg
        Dim sql As String = "select ID,Client_No,Client_Name ,Client_FindHelper,Code from T10110_Client where ID=@ID"
        Return SqlStrToDt(sql, "ID", ID)
    End Function
    ''' <summary>
    ''' 根据色号获取客户资料
    ''' </summary>
    ''' <param name="_BzcID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Clinet_GetBy_BZCID(ByVal _BzcID As Integer) As DtReturnMsg
        Dim sql As String = "select ID,Client_No,Client_Name from T10110_Client where ID=(Select Client_ID from T10003_BZC where ID=@BZC_ID)"
        Return SqlStrToDt(sql, "BZC_ID", _BzcID)
    End Function
#End Region

#Region "缸号状态"
    ''' <summary>
    ''' 缸号状态 集合
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GH_GetStateTable()
        Static dt As DataTable
        If dt Is Nothing Then
            dt = New DataTable("State")
        Else
            Return dt.Copy
        End If

        dt.Columns.Add("State", GetType(Integer))
        dt.Columns.Add("StateName", GetType(String))
        Dim dr As DataRow = dt.NewRow

        dr("State") = -99
        dr("StateName") = "全部"
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("State") = Enum_ProduceState.XiaDan
        dr("StateName") = "下单"
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("State") = Enum_ProduceState.PeiBu
        dr("StateName") = "配布"
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("State") = Enum_ProduceState.SongBu
        dr("StateName") = "松布"
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("State") = Enum_ProduceState.YuDing
        dr("StateName") = "预定"
        dt.Rows.Add(dr)


        dr = dt.NewRow
        dr("State") = Enum_ProduceState.RanSe
        dr("StateName") = "染色"
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("State") = Enum_ProduceState.ChuGang
        dr("StateName") = "出缸"
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("State") = Enum_ProduceState.TuoShui
        dr("StateName") = "脱水"
        dt.Rows.Add(dr)


        dr = dt.NewRow
        dr("State") = Enum_ProduceState.ZhongJian
        dr("StateName") = "中检"
        dt.Rows.Add(dr)


        dr = dt.NewRow
        dr("State") = Enum_ProduceState.KaiFu
        dr("StateName") = "开幅"
        dt.Rows.Add(dr)


        dr = dt.NewRow
        dr("State") = Enum_ProduceState.DingXing
        dr("StateName") = "定型"
        dt.Rows.Add(dr)


        dr = dt.NewRow
        dr("State") = Enum_ProduceState.ChengJian
        dr("StateName") = "成检"
        dt.Rows.Add(dr)



        dr = dt.NewRow
        dr("State") = Enum_ProduceState.RuKu
        dr("StateName") = "成品入库"
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("State") = Enum_ProduceState.SongHuo
        dr("StateName") = "出货"
        dt.Rows.Add(dr)

        Return dt.Copy
    End Function
#End Region

#Region "缸号检查"
    Public Const SQL_GetGHForTM = "declare @GH varchar(20)" & vbCrLf & _
   "select Top 1 @GH=No_ID from Bill_Barcode" & vbCrLf & _
   "where No_Tm=@No_TM " & vbCrLf & _
   "if @GH is null" & vbCrLf & _
   "select @GH" & vbCrLf & _
   "else" & vbCrLf & _
   "Select top 1 GH from T30000_Produce_Gd where GH = @GH"

    Public Shared Function GetGHForTM(ByVal Search As String) As MsgReturn
        Dim R As New MsgReturn
        Search = FixGH(Search)
        If GHTmCheck(Search) Then
            Dim DtR As DtReturnMsg = SqlStrToDt(SQL_GetGHForTM, "No_TM", Search.Substring(0, Search.Length - 1))
            If DtR.IsOk AndAlso DtR.Dt.Rows.Count > 0 AndAlso Not IsDBNull(DtR.Dt.Rows(0)(0)) Then
                R.IsOk = True
                R.Msg = DtR.Dt.Rows(0)(0)
            Else
                R.IsOk = False
                R.Msg = "没有找和[" & Search & "]相关的缸号!"
            End If
        Else
            If Search.Length > 8 Then
                Dim DtR As DtReturnMsg = SqlStrToDt("Select top 1 GH from T30000_Produce_Gd where GH Like @GH", "GH", "%" & Search & "%")
                If DtR.IsOk AndAlso DtR.Dt.Rows.Count > 0 Then
                    R.IsOk = True
                    R.Msg = DtR.Dt.Rows(0)(0)
                Else
                    R.IsOk = False
                    R.Msg = "没有找和[" & Search & "]相关的缸号!"
                End If
            Else
                R.IsOk = False
                R.Msg = "没有找和[" & Search & "]相关的缸号!"
            End If
        End If
        Return R
    End Function




    Public Shared Function GHTmCheck(ByVal Tm As String) As Boolean
        If Tm.Length > 8 OrElse Tm.Length < 5 Then
            Return False
        End If
        Dim T As String = CStr(CInt(Val(Tm)))
        Dim s As String = T.Substring(0, T.Length - 1)
        Dim i As Integer = s.Length + 1
        Dim L As Long
        For Each c As String In s
            L = i * c + L
            i = i - 1
        Next
        L = L Mod 11
        L = L Mod 10
        If T.EndsWith(CStr(L)) Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Shared Function GetGHTm(ByVal GHTm As Integer) As Integer
        Dim s As String = GHTm
        Dim i As Integer = s.Length + 1
        Dim L As Long
        For Each c As String In s
            L = i * c + L
            i = i - 1
        Next
        L = L Mod 11
        L = L Mod 10
        Return CInt(GHTm.ToString & L)
    End Function


    Private Const Replace_GH_String As String = "[^a-zA-Z0-9]"
    Private Const Check_GH_String As String = "^[G|g]{1}[Y|y]{1}[0-9]{9}[a-zA-Z]{0,4}$"
    Public Shared Function FixGH(ByVal GH As String) As String
        GH = GH.Trim.ToUpper
        GH = System.Text.RegularExpressions.Regex.Replace(GH, Replace_GH_String, "")
        If GH.Length < 9 Then
            Return GH
        End If
        If GH <> "" AndAlso GH.Length >= 9 AndAlso Not GH.StartsWith("GY", StringComparison.CurrentCultureIgnoreCase) Then
            GH = "GY" & GH
        Else
            GH = GH.Replace("gy", "GY")
        End If
        Return GH
    End Function

    Public Shared Function CheckGH(ByVal GH As String) As MsgReturn
        Dim R As New MsgReturn
        If GH.Length < 9 Then
            R.Msg = "缸号的位不对,请输入正确!"
        Else
            If System.Text.RegularExpressions.Regex.IsMatch(GH, Check_GH_String) = False Then
                R.Msg = "请检查缸号是否正确!"
            Else
                R.IsOk = True
            End If
        End If
        Return R
    End Function
#End Region
#Region "检查缸号是否已领料"

    ''' <summary>
    ''' 检查缸号是否已领料,是则返回领料单号，否则返回“”
    ''' </summary>
    ''' <param name="GH"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetGHLingLiaoID(ByVal GH As String) As List(Of String)
        Dim ll As New List(Of String)
        Dim R As DtReturnMsg = SqlStrToDt("Select ID from T22310_LingLiao_Table where Produce_ID=@GH and State=1")
        If R.IsOk AndAlso R.Dt.Rows.Count > 0 Then
            For Each dr As DataRow In R.Dt.Rows
                ll.Add(dr("ID"))
            Next
        End If
        Return ll
    End Function
#End Region

#Region "入库单号检查"
    Private Const Replace_RK_String As String = "[^a-zA-Z0-9]"
    Private Const Check_RK_String As String = "^[0-9]{8}$"
    Private Const Check_RK_StringIsInput As String = "^[a-zA-Z]{1,2}[0-9]{5}[a-zA-Z]{1}$"
    Public Shared Function FixRK(ByVal RK As String) As String
        RK = RK.Trim.ToUpper
        RK = System.Text.RegularExpressions.Regex.Replace(RK, Replace_RK_String, "")
        Return RK
    End Function

    Public Shared Function CheckRK(ByVal RK As String, Optional ByVal IsInputCheck As Boolean = False) As MsgReturn
        Dim R As New MsgReturn
        'If RK.Length < 8 Then
        '    R.Msg = "入库单号的必须8位以上,请输入正确!"
        'Else
        '    If System.Text.RegularExpressions.Regex.IsMatch(RK, IIf(IsInputCheck, Check_RK_StringIsInput, Check_RK_String)) = False Then
        '        R.Msg = "请检查入库单号是否填写正确!"
        '    Else
        R.IsOk = True
        '    End If
        'End If
        Return R
    End Function
#End Region

#Region "获取染色工艺明细"
    Public Const SQL_GY_GeList_ByIDWithName = "select P.*,WL_Percent,WL_Cost,WL_Store_ID,WL_Type_ID,WL_Name,WL_No,WL_Spec,W.IsZJ,W.WL_Unit_LL,w.WL_Unit from T10005_GYList  P left join T10001_WL W on P.WL_ID=W.ID where  P.ID=@ID "


    Public Shared Function GY_GetList_ByID(ByVal _ID As Integer) As DtReturnMsg
        Dim R As New DtReturnMsg
        Dim sql As String = SQL_GY_GeList_ByIDWithName
        Dim para As New Dictionary(Of String, Object)
        para.Add("@ID", _ID)
        R = PClass.PClass.SqlStrToDt(sql, para)
        Return R
    End Function



#End Region

#Region "获取手感工艺明细"
    Private Const SQL_SGGY_GeList_ByIDWithName = "select P.*,''as DyingStep,WL_Percent,WL_Cost,WL_Store_ID,WL_Type_ID,WL_Name,WL_No,WL_Spec,W.IsZJ,W.WL_Unit_LL,w.WL_Unit  from " & OptionClass.Table_SGGYList & "  P left join T10001_WL W on P.WL_ID=W.ID where  P.ID=@ID "
    Private Const SQL_SGGY_GeBList_ByIDWithName = "select P.*,''as DyingStep,WL_Percent,WL_Cost,WL_Store_ID,WL_Type_ID,WL_Name,WL_No,WL_Spec,W.IsZJ,W.WL_Unit_LL,w.WL_Unit  from " & OptionClass.Table_SGGYList & "  P left join T10001_WL W on P.WL_ID=W.ID where  P.ID=@ID and P.Color=@Color"
    Private Const SQL_SGGY_GeZList_ByIDWithName = "select P.*,''as DyingStep,WL_Percent,WL_Cost,WL_Store_ID,WL_Type_ID,WL_Name,WL_No,WL_Spec,W.IsZJ,W.WL_Unit_LL,w.WL_Unit  from " & OptionClass.Table_SGGYList & "  P left join T10001_WL W on P.WL_ID=W.ID where  P.ID=@ID and Color='杂色'"
    Private Const SQL_SGGY_GeHList_ByIDWithName = "select P.*,''as DyingStep,WL_Percent,WL_Cost,WL_Store_ID,WL_Type_ID,WL_Name,WL_No,WL_Spec,W.IsZJ,W.WL_Unit_LL,w.WL_Unit  from " & OptionClass.Table_SGGYList & "  P left join T10001_WL W on P.WL_ID=W.ID where  P.ID=@ID and Color='黑色'"

    Private Const SQL_SGGY_GetByID As String = "select top 1 * from " & OptionClass.Table_SGGY & " where ID=@ID"


    Public Shared Function DXGY_GetList_ByID(ByVal _ID As Integer) As DtReturnMsg
        Dim R As New DtReturnMsg
        Dim sql As String = SQL_SGGY_GeList_ByIDWithName
        Dim para As New Dictionary(Of String, Object)
        para.Add("@ID", _ID)
        R = PClass.PClass.SqlStrToDt(sql, para)
        Return R
    End Function
    Public Shared Function SGGY_GetList(ByVal _ID As Double, ByVal _color As String) As DtReturnMsg
        Dim R As New DtReturnMsg
        Dim sql As String = SQL_SGGY_GeBList_ByIDWithName
        Dim para As New Dictionary(Of String, Object)
        para.Add("@ID", _ID)
        para.Add("@Color", _color)
        R = PClass.PClass.SqlStrToDt(sql, para)
        Return R
    End Function
    Public Shared Function SGGY_GetZList(ByVal _ID As Integer) As DtReturnMsg
        Dim R As New DtReturnMsg
        Dim sql As String = SQL_SGGY_GeZList_ByIDWithName
        Dim para As New Dictionary(Of String, Object)
        para.Add("@ID", _ID)
        R = PClass.PClass.SqlStrToDt(sql, para)
        Return R
    End Function
    Public Shared Function SGGY_GetHList(ByVal _ID As Integer) As DtReturnMsg
        Dim R As New DtReturnMsg
        Dim sql As String = SQL_SGGY_GeHList_ByIDWithName
        Dim para As New Dictionary(Of String, Object)
        para.Add("@ID", _ID)
        R = PClass.PClass.SqlStrToDt(sql, para)
        Return R
    End Function

    ''' <summary>
    ''' 获取工艺信息
    ''' </summary>
    ''' <param name="sId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function DXGY_GetById(ByVal sId As Integer) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_SGGY_GetByID, "@Id", sId)
    End Function
#End Region

#Region "对账单"

    ''' <summary>
    ''' 相同单号，日期只显示第一个
    ''' </summary>
    ''' <param name="dtList"></param>
    ''' <remarks></remarks>
    Public Shared Sub Balance_HideCells(ByVal dtList As DataTable)
        Dim C_Date As New DataColumn("C_Date", GetType(Date))
        Dim C_ID As New DataColumn("C_ID")
        Dim C_BillName As New DataColumn("C_BillName")
        If Not dtList.Columns.Contains("C_Date") Then dtList.Columns.Add(C_Date)

        If Not dtList.Columns.Contains("C_ID") Then dtList.Columns.Add(C_ID)
        If Not dtList.Columns.Contains("C_BillName") Then dtList.Columns.Add(C_BillName)
        Dim ListID As String = ""

        For i As Integer = dtList.Rows.Count - 1 To 0 Step -1
            If dtList.Rows(i)("sID") Is DBNull.Value Then
                dtList.Rows.RemoveAt(i)
            End If
        Next
        dtList.AcceptChanges()
        For Each Row As DataRow In dtList.Rows
            If ListID <> Row("sID") Then
                ListID = Row("sID")
                Row("C_ID") = Row("sID")
                Row("C_Date") = Row("sDate")
                Row("C_BillName") = Row("BillName")
            End If
        Next
    End Sub
#End Region

#Region "班次"
    ''' <summary>
    ''' 班次信息
    ''' </summary>
    ''' <remarks></remarks>
    Private Shared DtSheftMoudel As DataTable

    ''' <summary>
    ''' 获取所有班次列表
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Sheft_GetSheftMoudel() As DataTable
        If DtSheftMoudel IsNot Nothing Then
            Return DtSheftMoudel
        Else
            Dim sql As String = "select * from T15517_Real_Shift order by ID"
            Dim msg As DtReturnMsg = SqlStrToDt(sql)
            If msg.IsOk Then
                Return msg.Dt
            Else
                Return Nothing
            End If
        End If

    End Function
#End Region

#Region "用户"

    ''' <summary>
    ''' 获取用户显示名
    ''' </summary>
    ''' <param name="UserID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function User_GetNameByID(ByVal UserID As String) As String

        If UserID = "Admin" Then Return "管理员账号"
        Dim R As MsgReturn = SqlStrToOneStr("select top 1 User_Display from User_Info where User_ID=@User_ID", "User_ID", UserID)
        If R.IsOk Then
            Return R.Msg
        Else
            Return ""
        End If

    End Function

#End Region
End Class
''' <summary>
''' 
''' </summary>
''' <remarks></remarks>
Public Enum Enum_HR
    User
    Employee
    Department
End Enum

''' <summary>
''' 备注类型
''' </summary>
''' <remarks></remarks>
Public Enum Enum_RemarkType
    Quality = 1
    ChePai = 2
    ProcessType = 3
    Dying_Step = 4
    Store_Area = 5
    Other = 0
    StoreIn_Reason = 6
    StoreOut_Reason = 7
    LingLiao_Reason = 8
    TuiLiao_Reason = 9
    ProcessSort = 10
    HsReason = 11       '回修项目
    GSReason = 12 '改色原因
End Enum

''' <summary>
''' 缸号状态枚举
''' </summary>
''' <remarks></remarks>
Public Enum Enum_ProduceState
    Invalid = -1
    ''' <summary>
    ''' 新建
    ''' </summary>
    ''' <remarks></remarks>
    AddNew = 0
    ''' <summary>
    ''' 下单
    ''' </summary>
    ''' <remarks></remarks>
    XiaDan = 1
    ''' <summary>
    ''' 配布
    ''' </summary>
    ''' <remarks></remarks>
    PeiBu = 10
    ''' <summary>
    ''' 松布
    ''' </summary>
    ''' <remarks></remarks>
    SongBu = 15
    ''' <summary>
    ''' 预定
    ''' </summary>
    ''' <remarks></remarks>
    YuDing = 20
    ''' <summary>
    ''' 染色
    ''' </summary>
    ''' <remarks></remarks>
    RanSe = 30

    ''' <summary>
    ''' 出缸
    ''' </summary>
    ''' <remarks></remarks>
    ChuGang = 38

    ''' <summary>
    ''' 脱水
    ''' </summary>
    ''' <remarks></remarks>
    TuoShui = 40
    ''' <summary>
    ''' 中检
    ''' </summary>
    ''' <remarks></remarks>
    ZhongJian = 50
    ''' <summary>
    ''' 开幅
    ''' </summary>
    ''' <remarks></remarks>
    KaiFu = 60
    ''' <summary>
    ''' 定型
    ''' </summary>
    ''' <remarks></remarks>
    DingXing = 70
    ''' <summary>
    ''' 成检中
    ''' </summary>
    ''' <remarks></remarks>
    ChengJianZhong = 79
    ''' <summary>
    ''' 成检
    ''' </summary>
    ''' <remarks></remarks>
    ChengJian = 80

    ''' <summary>
    ''' 成品入库
    ''' </summary>
    ''' <remarks></remarks>
    RuKu = 85
    ''' <summary>
    ''' 送货
    ''' </summary>
    ''' <remarks></remarks>
    SongHuo = 90
End Enum

''' <summary>
''' 胚布状态枚举
''' </summary>
''' <remarks></remarks>
Public Enum Enum_PBState
    AddNew = 0
    ''' <summary>
    ''' 胚布入库
    ''' </summary>
    ''' <remarks></remarks>
    PBRK = 1
    ''' <summary>
    ''' 配布
    ''' </summary>
    ''' <remarks></remarks>
    PeiBu = 2
    ''' <summary>
    ''' 成品入库
    ''' </summary>
    ''' <remarks></remarks>
    CPRK = 3
    ''' <summary>
    ''' 送货
    ''' </summary>
    ''' <remarks></remarks>
    SongHuo = 4
    ''' <summary>
    ''' 退布
    ''' </summary>
    ''' <remarks></remarks>
    TuiBu = 5
    ''' <summary>
    ''' 作废
    ''' </summary>
    ''' <remarks></remarks>
    Disable = -1

End Enum

''' <summary>
''' 送货单状态枚举
''' </summary>
''' <remarks></remarks>
Public Enum Enum_BZSHState
    AddNew = 0
    ''' <summary>
    ''' 仓库确认
    ''' </summary>
    ''' <remarks></remarks>
    Store_Comfirm = 1
    ''' <summary>
    ''' 审核
    ''' </summary>
    ''' <remarks></remarks>
    Audited = 2
    ''' <summary>
    ''' 作废
    ''' </summary>
    ''' <remarks></remarks>
    Invoid = -1

End Enum


''' <summary>
''' 备货单状态枚举
''' </summary>
''' <remarks></remarks>
Public Enum Enum_StroeOutstate
    AddNew = 0
    ''' <summary>
    ''' 仓库确认
    ''' </summary>
    ''' <remarks></remarks>
    Comfirm = 1
    ''' <summary>
    ''' 审核
    ''' </summary>
    ''' <remarks></remarks>
    Audited = 2
    ''' <summary>
    ''' 作废
    ''' </summary>
    ''' <remarks></remarks>
    Invoid = -1

End Enum

''' <summary>
''' 单据状态枚举
''' </summary>
''' <remarks></remarks>
Public Enum Enum_State_Upgrade
    AddNew = 0
    ''' <summary>
    ''' 确认
    ''' </summary>
    ''' <remarks></remarks>
    Comfirm = 1
    ''' <summary>
    ''' 审核
    ''' </summary>
    ''' <remarks></remarks>
    Audited = 2
    ''' <summary>
    ''' 作废
    ''' </summary>
    ''' <remarks></remarks>
    Invoid = -1
End Enum

''' <summary>
''' 单据状态枚举
''' </summary>
''' <remarks></remarks>
Public Enum Enum_State
    ''' <summary>
    ''' 新建
    ''' </summary>
    ''' <remarks></remarks>
    AddNew = 0
    ''' <summary>
    ''' 审核
    ''' </summary>
    ''' <remarks></remarks>
    Audited = 1
    ''' <summary>
    ''' 作废
    ''' </summary>
    ''' <remarks></remarks>
    Invoid = -1
End Enum

''' <summary>
''' 胚布入库单据状态枚举
''' </summary>
''' <remarks></remarks>
Public Enum Enum_PBRK_State
    ''' <summary>
    ''' 新建
    ''' </summary>
    ''' <remarks></remarks>
    AddNew = 0
    ''' <summary>
    ''' 确认
    ''' </summary>
    ''' <remarks></remarks>
    Confirm = 1
    ''' <summary>
    ''' 取消确认
    ''' </summary>
    ''' <remarks></remarks>
    UNConfirm = 4
    ''' <summary>
    ''' 审核
    ''' </summary>
    ''' <remarks></remarks>
    Audited = 2
    ''' <summary>
    ''' 反审核
    ''' </summary>
    ''' <remarks></remarks>
    UNAudited = 3
    ''' <summary>
    ''' 作废
    ''' </summary>
    ''' <remarks></remarks>
    Invoid = -1
End Enum

Public Enum BillType
    ''' <summary>
    ''' 产品装配资料
    ''' </summary>
    ''' <remarks></remarks>
    WL = 10001
    ''' <summary>
    ''' 化工仓成本价调整
    ''' </summary>
    ''' <remarks></remarks>
    CostChange = 10013


    ''' <summary>
    '''放行条
    ''' </summary>
    ''' <remarks></remarks>
    ReleasePass = 15540


    ''' <summary>
    ''' 申购
    ''' </summary>
    ''' <remarks></remarks>
    ApplyPurchase = 20000
    ''' <summary>
    ''' 采购退货
    ''' </summary>
    ''' <remarks></remarks>
    PurchaseReturn = 20010
    ''' <summary>
    ''' 采购
    ''' </summary>
    ''' <remarks></remarks>
    Purchase = 20020


    ''' <summary>
    ''' 入库
    ''' </summary>
    ''' <remarks></remarks>
    StoreIn = 20200
    ''' <summary>
    ''' 出库
    ''' </summary>
    ''' <remarks></remarks>
    StoreOut = 20300


    ''' <summary>
    ''' 其它出库单
    ''' </summary>
    ''' <remarks></remarks>
    OtherOut = 20302

    ''' <summary>
    ''' 备货出库
    ''' </summary>
    ''' <remarks></remarks>
    BeiStoreOut = 20304


    ''' <summary>
    '''装配领料
    ''' </summary>
    ''' <remarks></remarks>
    Assemble_Requisition = 20310

    ''' <summary>
    ''' 领料
    ''' </summary>
    ''' <remarks></remarks>
    LingLiao = 20310
    '''<summary>
    '''定型领料
    ''' </summary>
    ''' <remarks></remarks>
    DXLingLiao = 20320
    '''<summary>
    '''手感领料
    ''' </summary>
    ''' <remarks></remarks>
    SGLingLiao = 20330
    ''' <summary>
    '''仓库库存损耗调整
    ''' </summary>
    ''' <remarks></remarks>
    StockAdjust = 20400



    ''' <summary>
    ''' 五金仓成本价调整
    ''' </summary>
    ''' <remarks></remarks>
    MetalCostChange = 21005
    ''' <summary>
    ''' 采购
    ''' </summary>
    ''' <remarks></remarks>
    Purchase_MT = 21000
    ''' <summary>
    ''' 采购退货
    ''' </summary>
    ''' <remarks></remarks>
    PurchaseReturn_MT = 21010


    ''' <summary>
    ''' 回修通知单
    ''' </summary>
    ''' <remarks></remarks>
    PBStore = 40203


    ''' <summary>
    ''' 送货单
    ''' </summary>
    ''' <remarks></remarks>
    Delivery = 27200


    ''' <summary>
    ''' 退货单
    ''' </summary>
    ''' <remarks></remarks>
    ReturnGoods = 27210


    ''' <summary>
    ''' 生产领料单
    ''' </summary>
    ''' <remarks></remarks>
    ProLiLiao = 27140


    ''' <summary>
    ''' 入库
    ''' </summary>
    ''' <remarks></remarks>
    StoreIn_MT = 21200
    ''' <summary>
    ''' 出库
    ''' </summary>
    ''' <remarks></remarks>
    StoreOut_MT = 21300
    ''' <summary>
    '''领料
    ''' </summary>
    ''' <remarks></remarks>
    LingLiao_MT = 21310

    ''' <summary>
    ''' 厨房采购
    ''' </summary>
    ''' <remarks></remarks>
    Purchase_KT = 22000

    ''' <summary>
    ''' 厨房退货
    ''' </summary>
    ''' <remarks></remarks>
    PurchaseReturn_KT = 22010


    ''' <summary>
    ''' 厨房入库
    ''' </summary>
    ''' <remarks></remarks>
    StoreIn_KT = 22200
    ''' <summary>
    ''' 厨房出库
    ''' </summary>
    ''' <remarks></remarks>
    StoreOut_KT = 22300
    ''' <summary>
    '''厨房领料
    ''' </summary>
    ''' <remarks></remarks>
    LingLiao_KT = 22310

    ''' <summary>
    ''' 厨房仓成本价调整
    ''' </summary>
    ''' <remarks></remarks>
    KitchenCostChange = 22005




    ''' <summary>
    ''' 其它材料采购
    ''' </summary>
    ''' <remarks></remarks>
    Purchase_CO = 26000

    ''' <summary>
    ''' 其它材料退货
    ''' </summary>
    ''' <remarks></remarks>
    PurchaseReturn_CO = 26010


    ''' <summary>
    ''' 其它材料入库
    ''' </summary>
    ''' <remarks></remarks>
    StoreIn_CO = 26200
    ''' <summary>
    ''' 其它材料出库
    ''' </summary>
    ''' <remarks></remarks>
    StoreOut_CO = 26300
    ''' <summary>
    '''其它材料领料
    ''' </summary>
    ''' <remarks></remarks>
    LingLiao_CO = 26310

    ''' <summary>
    ''' 其它材料仓成本价调整
    ''' </summary>
    ''' <remarks></remarks>
    CoCostChange = 26005


    ''' <summary>
    ''' 仓成本价调整
    ''' </summary>
    ''' <remarks></remarks>
    PolyBagCostChange = 24005
    ''' <summary>
    ''' 采购
    ''' </summary>
    ''' <remarks></remarks>
    Purchase_Bag = 24000
    ''' <summary>
    ''' 采购退货
    ''' </summary>
    ''' <remarks></remarks>
    PurchaseReturn_Bag = 24010


    ''' <summary>
    ''' 入库
    ''' </summary>
    ''' <remarks></remarks>
    StoreIn_Bag = 24200
    ''' <summary>
    ''' 出库
    ''' </summary>
    ''' <remarks></remarks>
    StoreOut_Bag = 24300
    ''' <summary>
    '''领料
    ''' </summary>
    ''' <remarks></remarks>
    LingLiao_Bag = 24310


    ''' <summary>
    '''客户订单
    ''' </summary>
    ''' <remarks></remarks>
    ClientOrder = 27000

    ''' <summary>
    '''生产指令单
    ''' </summary>
    ''' <remarks></remarks>
    ProduceOrder = 27110


    ''' <summary>
    ''' 生产安排
    ''' </summary>
    ''' <remarks></remarks>
    Schedule = 27120

    ''' <summary>
    ''' 装配指令
    ''' </summary>
    ''' <remarks></remarks>
    AssembleOrder = 27130

    ''' <summary>
    ''' 生产计划
    ''' </summary>
    ''' <remarks></remarks>
    Produce = 30000


    ''' <summary>
    ''' 染部日报表
    ''' </summary>
    ''' <remarks></remarks>
    RBReport = 30206

    ''' <summary>
    ''' 定型日报表
    ''' </summary>
    ''' <remarks></remarks>
    DXReport = 30208

    ''' <summary>
    ''' 质量日报表
    ''' </summary>
    ''' <remarks></remarks>
    QLReport = 30220

    ''' <summary>
    ''' 补布申请单
    ''' </summary>
    ''' <remarks></remarks>
    Applique = 30226

    ''' <summary>
    ''' 回修通知单
    ''' </summary>
    ''' <remarks></remarks>
    Inform = 30231

    ''' <summary>
    ''' 煤采购单
    ''' </summary>
    ''' <remarks></remarks>
    PurchaseCoal = 21114


    ''' <summary>
    ''' 改黑申请单
    ''' </summary>
    ''' <remarks></remarks>
    GHSQ = 30228

    ''' <summary>
    ''' 改色申请单
    ''' </summary>
    ''' <remarks></remarks>
    GSSQ = 30230

    ''' <summary>
    ''' 成品送货
    ''' </summary>
    ''' <remarks></remarks>
    BZSH = 40000
    ''' <summary>
    ''' 外发加工单
    ''' </summary>
    ''' <remarks></remarks>
    OutWork = 40002
    ''' <summary>
    ''' 胚布入库
    ''' </summary>
    ''' <remarks></remarks>
    PBRK = 40100
    ''' <summary>
    ''' 胚布调仓
    ''' </summary>
    ''' <remarks></remarks>
    PBTC = 40150
    ''' <summary>
    ''' 成品入库库
    ''' </summary>
    ''' <remarks></remarks>
    CPRK = 40300
    ''' <summary>
    ''' 成品期初库存
    ''' </summary>
    ''' <remarks></remarks>
    CPIni = 40310
    ''' <summary>
    ''' 胚布送货对账单
    ''' </summary>
    ''' <remarks></remarks>
    BZSH_Balance = 40500
    ''' <summary>
    ''' 报价单
    ''' </summary>
    ''' <remarks></remarks>
    Price = 50000


    ''' <summary>
    ''' 加工内容报价单
    ''' </summary>
    ''' <remarks></remarks>
    ProcessPrice = 50010

    ''' <summary>
    ''' 手感报价单
    ''' </summary>
    ''' <remarks></remarks>
    IniTouch = 50032

    ''' <summary>
    ''' 内部报价单
    ''' </summary>
    ''' <remarks></remarks>
    InnerPrice = 50030

End Enum

''' <summary>
''' 入库单类型枚举
''' </summary>
''' <remarks></remarks>
Public Enum Enum_StoreIn_Type
    ''' <summary>
    ''' 其它入库
    ''' </summary>
    ''' <remarks></remarks>
    Other = 0
    ''' <summary>
    ''' 退料入库
    ''' </summary>
    ''' <remarks></remarks>
    TuiLiao = 1
    ''' <summary>
    ''' 成品入库
    ''' </summary>
    ''' <remarks></remarks>
    CPRK = 2

End Enum

''' <summary>
''' 出库单类型枚举
''' </summary>
''' <remarks></remarks>
Public Enum Enum_StoreOut_Type
    ''' <summary>
    ''' 其它出库
    ''' </summary>
    ''' <remarks></remarks>
    Other = 0
    ''' <summary>
    ''' 领料出库
    ''' </summary>
    ''' <remarks></remarks>
    LingLiao = 1
    ''' <summary>
    ''' 成品出库
    ''' </summary>
    ''' <remarks></remarks>
    CPCK = 2
    ''' <summary>
    ''' 备货出库
    ''' </summary>
    ''' <remarks></remarks>
    BeiHuo = 3

End Enum

''' <summary>
''' 物料选择类型
''' </summary>
''' <remarks></remarks>
Public Enum Enum_WLSelectMode
    OneRow = 0
    ''' <summary>
    ''' 采购单
    ''' </summary>
    ''' <remarks></remarks>
    MutiRow = 1

End Enum



''' <summary>
''' 布类状态枚举
''' </summary>
''' <remarks></remarks>
Public Enum Enum_BZ_State

    ''' <summary>
    ''' 禁用
    ''' </summary>
    ''' <remarks></remarks>
    Disable = -1


    ''' <summary>
    ''' 在用
    ''' </summary>
    ''' <remarks></remarks>
    isUsed = 0

End Enum












''' <summary>
''' 工序状态类型
''' </summary>
''' <remarks></remarks>
Public Enum Enum_WorkState
    ''' <summary>
    ''' 待处理
    ''' </summary>
    ''' <remarks></remarks>
    None = 0

    ''' <summary>
    ''' 已开始
    ''' </summary>
    ''' <remarks></remarks>
    Start = 1

    ''' <summary>
    ''' 已结束
    ''' </summary>
    ''' <remarks></remarks>
    Finish = 2

    ''' <summary>
    ''' 错误状态
    ''' </summary>
    ''' <remarks></remarks>
    Wrong = 3
End Enum
Public Class DatePickerValueChangeHandler

    Dim IsDropDowned As Boolean
    Dim IsDateChanged As Boolean
    Dim WithEvents DTP_sDate As DateTimePicker
    Delegate Sub DDate_Change(ByVal NewDate As Date)
    Delegate Function Disloaded() As Boolean
    Dim Date_Change As DDate_Change
    Dim isloaded As Disloaded
    Sub New(ByVal DTP_sDate As DateTimePicker, ByVal isloaded As Disloaded, ByVal Date_Change As DDate_Change)
        Me.DTP_sDate = DTP_sDate
        Me.isloaded = isloaded
        Me.Date_Change = Date_Change
    End Sub

    Private Sub DTP_sDate_CloseUp(ByVal sender As Object, ByVal e As System.EventArgs) Handles DTP_sDate.CloseUp
        IsDropDowned = False
        If isloaded() AndAlso IsDateChanged = True Then
            Date_Change(DTP_sDate.Value)
        End If
        IsDateChanged = False
    End Sub

    Private Sub DTP_sDate_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles DTP_sDate.DropDown
        IsDropDowned = True
    End Sub
    Private Sub DTP_sDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTP_sDate.ValueChanged
        If isloaded() Then
            If IsDropDowned = False Then
                Date_Change(DTP_sDate.Value)
                IsDateChanged = False
            Else
                IsDateChanged = True
            End If
        End If
    End Sub

End Class