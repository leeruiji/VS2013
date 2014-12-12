Imports System.Drawing
Imports System.Windows.Forms
Imports PClass.PClass

<System.Serializable()> Public Class cStore_Area
    Private LastDG As DataGridView
    Private Sel_List As New List(Of String)
    Private Last_List As New List(Of String)
    Private Letter() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}

    Public Property Select_List() As List(Of String)
        Get
            Return Sel_List
        End Get
        Set(ByVal value As List(Of String))
            Sel_List = value
            ShowSelList()
        End Set
    End Property


    ''' <summary>
    ''' 布仓为［空］时候的字体颜色
    ''' </summary>
    ''' <remarks></remarks>
    Public Color_Empty As Drawing.Color = Color.FromArgb(239, 254, 253)
    ''' <summary>
    ''' 布仓为［有库存］时候的字体颜色
    ''' </summary>
    ''' <remarks></remarks>
    Public Color_Normal As Drawing.Color = Color.FromArgb(60, 157, 255)
    ''' <summary>
    ''' 布仓为［选择］时候的字体颜色
    ''' </summary>
    ''' <remarks></remarks>
    Public Color_Sel As Drawing.Color = Color.Red
    ''' <summary>
    '''　［普通］单元格的颜色
    ''' </summary>
    ''' <remarks></remarks>
    Public Color_Cell As Drawing.Color = Color.Blue
    ''' <summary>
    '''　［普通间行］单元格的颜色
    ''' </summary>
    ''' <remarks></remarks>
    Public Color_CellA As Drawing.Color = Color.Black
    ''' <summary>
    '''　［柱］单元格的颜色
    ''' </summary>
    ''' <remarks></remarks>
    Public Color_Post As Drawing.Color = Color.Green
    ''' <summary>
    '''　［电梯］单元格的颜色
    ''' </summary>
    ''' <remarks></remarks>
    Public Color_Stairs As Drawing.Color = Color.LightSlateGray
    ''' <summary>
    '''　［禁用］单元格的颜色
    ''' </summary>
    ''' <remarks></remarks>
    Public Color_Disable As Drawing.Color = Color.Gray
    ''' <summary>
    '''　［通道］单元格的颜色
    ''' </summary>
    ''' <remarks></remarks>
    Public Color_Passage As Drawing.Color = Color.Yellow

    ''' <summary>
    ''' 楼层编号
    ''' </summary>
    ''' <remarks></remarks>
    Public Floor As Integer = 1
    Private Last_Area As String = ""
    Private _Row As Integer
    Public IsAdd As Boolean = False
    Public ReadOnly Property Row() As Integer
        Get
            Return _Row
        End Get
    End Property
    Private _Col As Integer
    Public ReadOnly Property Col() As Integer
        Get
            Return _Col
        End Get
    End Property
    Private RowHeight As Integer = 20
    Private ColWidth As Integer = 20
    Private RowTimeMax As Long = 0

    ''' <summary>
    ''' 格
    ''' </summary>
    ''' <remarks></remarks>
    Public Cell As DataTable
    ''' <summary>
    ''' 从Dt获取数据到实例
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetFormDt() As Boolean
        Dim R As DtReturnMsg = SqlStrToDt(SQL_Store_Area_GeyBy_Area_Full, "@Floor", Floor)
        If R.IsOk = False Then Return False
        Cell = R.Dt
        Try
            RowTimeMax = Cell.Compute("max(RowTimeMax)", "")
        Catch ex As Exception
            RowTimeMax = 0
        End Try

    End Function


    Public Function GetDifference() As Boolean
        If Cell Is Nothing Then
            GetFormDt()
            Return True
        End If
        Dim P As New Dictionary(Of String, Object)
        P.Add("@RowTimeMax", RowTimeMax)
        P.Add("@Floor", Floor)
        Dim R As DtReturnMsg = SqlStrToDt(SQL_Store_Area_GeyBy_Area_RowTime, P)
        If R.IsOk AndAlso R.Dt.Rows.Count > 0 Then
            For Each Row As DataRow In R.Dt.Rows
                Dim Dr() As DataRow = Cell.Select("Floor='" & Row("Floor") & "' and x=" & Row("x") & " and y=" & Row("y"))
                If Dr.Length > 0 Then
                    Dr(0)("ColWidth") = Row("ColWidth")
                    Dr(0)("RowHeight") = Row("RowHeight")
                    Dr(0)("sNo") = Row("sNo")
                    Dr(0)("MaxQty") = Row("MaxQty")
                    Dr(0)("Qty") = Row("Qty")
                    Dr(0)("State") = Row("State")
                    Dr(0)("Msg") = Row("Msg")
                    Dr(0)("mDate") = Row("mDate")
                    Dr(0)("RowTimeMax") = Row("RowTimeMax")
                End If
            Next
            RowTimeMax = Cell.Compute("max(RowTimeMax)", "")
            Return True
        Else
            Return False
        End If
    End Function

    Private Const SQL_Store_Area_GeyBy_Area_RowTime As String = "select *,cast(mDate as bigint) as RowTimeMax from T40500_Store_Map WITH(NOLOCK)  where Floor=@Floor and mDate>@RowTimeMax order by Floor,mDate desc"
    Private Const SQL_Store_Area_GeyBy_Area_Full As String = "select Floor,X,Y,ColWidth,RowHeight,sNo,MaxQty,State,Msg,mDate,Isnull(sn.Qty,0)As Qty,cast(mDate as bigint) as RowTimeMax from T40500_Store_Map M WITH(NOLOCK) Left join (Select StoreNo,Sum(Qty) As Qty from T40520_PB_StoreNo Group By StoreNo )sn On sn.StoreNo=M.sNo  where Floor=@Floor order by Floor,mDate desc"
    Private Const SQL_Store_Area_GeyBy_Area As String = "select Floor,X,Y,ColWidth,RowHeight,sNo,MaxQty,State,Msg from T40500_Store_Map WITH(NOLOCK)  where Floor=@Floor"

    ''' <summary>
    ''' 保存到数据库
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Save() As MsgReturn
        Dim Cnn As New SqlClient.SqlConnection
        Dim Da As New SqlClient.SqlDataAdapter
        Dim gId As String = ""
        Dim returnMsg As New MsgReturn
        If Cell.Rows.Count = 0 Then
            returnMsg.IsOk = False
            returnMsg.Msg = "修改仓库平面失败!"
            Return returnMsg
        End If
        Try
            Dim s As String
            If Last_Area = "" Then
                s = Me.Floor
            Else
                s = Last_Area
            End If
            Dim msg As DtReturnMsg = SqlStrToDt(SQL_Store_Area_GeyBy_Area, Cnn, Da, "@Floor", s)
            If msg.IsOk Then
                Dim Dr As DataRow
                For Each R As DataRow In msg.Dt.Rows
                    Dim Rows() As DataRow = Cell.Select("X='" & R("X") & "' and Y='" & R("Y") & "'")
                    If Rows.Length = 0 Then
                        R.Delete()
                    End If
                Next
                For Each R As DataRow In Cell.Rows
                    Dim Rows() As DataRow = msg.Dt.Select("X='" & R("X") & "' and Y='" & R("Y") & "'")
                    If Rows.Length > 0 Then
                        Dr = Rows(0)
                    Else
                        Dr = msg.Dt.NewRow()
                        msg.Dt.Rows.Add(Dr)
                        Dr("X") = R("X")
                        Dr("Y") = R("Y")
                    End If
                    Dr("State") = R("State")
                    Dr("Floor") = R("Floor")
                    Dr("ColWidth") = R("ColWidth")
                    Dr("RowHeight") = R("RowHeight")
                    Dr("sNo") = R("sNo")
                    Dr("MaxQty") = R("MaxQty")
                Next
                DtToUpDate(msg.Dt, Cnn, Da)
                returnMsg.IsOk = True
                returnMsg.Msg = "仓库平面[" & Floor & "]保存成功!"
            Else
                returnMsg.IsOk = False
                returnMsg.Msg = "仓库平面[" & Floor & "]不存在!"
            End If
        Catch ex As Exception
            DebugToLog(ex)
            returnMsg.IsOk = False
            returnMsg.Msg = "修改仓库平面失败!"
        Finally
            Da.Dispose()
            Cnn.Dispose()
        End Try
        Return returnMsg
    End Function

#Region "行列修改"
    ''' <summary>
    ''' 设置行列到实例
    ''' </summary>
    ''' <param name="Row"></param>
    ''' <param name="Col"></param>
    ''' <param name="RowHeight"></param>
    ''' <param name="ColWidth"></param>
    ''' <remarks></remarks>
    Sub SetRowCol(ByVal Row As Integer, ByVal Col As Integer, ByVal RowHeight As Integer, ByVal ColWidth As Integer, Optional ByVal MaxQty As Integer = 20)
        IsAdd = True
        Cell = Me.GetNewCell()
        Me._Row = Row
        Me._Col = Col

        For j As Integer = 0 To Row - 1
            For i As Integer = 0 To Col - 1
                Dim Dr As DataRow = Cell.NewRow
                Dr("Floor") = Floor
                Dr("x") = i
                Dr("y") = j
                Dr("ColWidth") = ColWidth
                Dr("RowHeight") = RowHeight

                Dr("sNo") = ""
                Dr("MaxQty") = MaxQty
                Dr("Qty") = 0
                Dr("State") = Enum_State.Normal
                Cell.Rows.Add(Dr)
            Next
        Next
        Me.RowHeight = RowHeight
        Me.ColWidth = ColWidth
        Cell.AcceptChanges()
    End Sub

    Sub SetAddRow()
        Me._Row = Row + 1
        For i As Integer = 0 To Col - 1
            Dim Dr As DataRow = Cell.NewRow
            Dr("Floor") = Floor
            Dr("x") = i
            Dr("y") = Me._Row
            Dr("ColWidth") = ColWidth
            Dr("RowHeight") = RowHeight

            Dr("sNo") = ""
            Dr("MaxQty") = 20
            Dr("Qty") = 0
            Dr("State") = Enum_State.Normal
            Cell.Rows.Add(Dr)
        Next

    End Sub
    ''' <summary>
    ''' 设置列通道
    ''' </summary>
    ''' <param name="Col"></param>
    ''' <param name="ColWidth"></param>
    ''' <remarks></remarks>
    Sub SetPassageCol(ByVal Col As Integer, ByVal ColWidth As Integer, Optional ByVal SetValue As Boolean = False)
        Dim Rows() As DataRow = Cell.Select("X=" & Col)
        For Each Dr As DataRow In Rows
            If Dr("ColWidth") = Me.ColWidth Or SetValue Then
                Dr("State") = Enum_State.Passage
                Dr("ColWidth") = ColWidth
                Dr("MaxQty") = 0
            Else
                Dr("State") = Enum_State.Normal
                Dr("MaxQty") = 20
                Dr("ColWidth") = Me.ColWidth
            End If
        Next
    End Sub

    ''' <summary>
    ''' 设置列通道 间隔
    ''' </summary>
    ''' <param name="ColWidth"></param>
    ''' <param name="Start"></param>
    ''' <param name="JStep"></param>
    ''' <remarks></remarks>
    Sub SetPassageJCol(ByVal ColWidth As Integer, ByVal Start As Integer, ByVal JStep As Integer)
        Dim j As Integer = Col
        Start = IIf(j < Start, j, Start)
        For i As Integer = Start To j Step JStep
            SetPassageCol(i, ColWidth, True)
        Next
    End Sub


    ''' <summary>
    ''' 设置行通道 间隔
    ''' </summary>
    ''' <param name="RowHeight"></param>
    ''' <param name="Start"></param>
    ''' <param name="JStep"></param>
    ''' <remarks></remarks>
    Sub SetPassageJRow(ByVal RowHeight As Integer, ByVal Start As Integer, ByVal JStep As Integer)
        Dim j As Integer = Row
        Start = IIf(j < Start, j, Start)
        For i As Integer = Start To j Step JStep
            SetPassageRow(i, RowHeight, True)
        Next
    End Sub

    ''' <summary>
    ''' 设置行通道
    ''' </summary>
    ''' <param name="Row"></param>
    ''' <param name="RowHeight"></param>
    ''' <remarks></remarks>
    Sub SetPassageRow(ByVal Row As Integer, ByVal RowHeight As Integer, Optional ByVal SetValue As Boolean = False)
        Dim Rows() As DataRow = Cell.Select("Y=" & Row)
        For Each Dr As DataRow In Rows
            If Dr("RowHeight") = Me.RowHeight Or SetValue Then
                Dr("State") = Enum_State.Passage
                Dr("RowHeight") = RowHeight
                Dr("MaxQty") = 0
            Else
                Dr("State") = Enum_State.Normal
                Dr("MaxQty") = 20
                Dr("RowHeight") = Me.RowHeight
            End If
        Next
    End Sub
#End Region

    Public Sub DG_Show(ByVal DG As DataGridView)
        LastDG = DG
        DG_Ini(DG)
        DG_ReFresh(DG)
    End Sub

    Public Sub DG_ReFresh(ByVal DG As DataGridView)
        LastDG = DG
        For Each Dr As DataRow In Cell.Rows
            SetCellColor(DG, Dr)
        Next
        ShowSelList()
    End Sub

    Public Sub DG_MouseOn(ByVal DG As DataGridView, ByVal x As Integer, ByVal Y As Integer, ByVal IsOn As Boolean)
        Dim Dr As DataRow = GetCellRow(x, Y)
        SetCellColor(DG, Dr, IsOn)
    End Sub

    Private Sub SetCellColor(ByVal DG As DataGridView, ByVal Dr As DataRow, Optional ByVal IsSel As Boolean = False)
        Dim y As Integer = CInt(Dr("y").ToString)
        Dim C As DataGridViewCell = DG.Item("C" & Dr("x").ToString, y)
        Dim s As String = Dr("sNo")
        If s.Length > 0 Then s = s
        Select Case Dr("State")
            Case Enum_State.Normal
                If y Mod 2 = 1 Then
                    C.Style.ForeColor = Color_CellA
                Else
                    C.Style.ForeColor = Color_Cell
                End If
                C.Value = s
                If Dr("Qty") = 0 Then
                    C.Style.BackColor = Color_Empty
                Else
                    C.Style.BackColor = Color_Normal
                End If
     
                If IsNull(Dr("Msg"), "") <> "" Then
                    C.ToolTipText = "仓位编号:" & s & vbTab & "类型:仓位" & vbCrLf & Dr("Msg")
                Else
                    C.ToolTipText = "仓位编号:" & s & vbTab & "类型:仓位" & vbCrLf & "本仓位为空."
                End If
            Case Enum_State.Passage
                C.Style.BackColor = Color_Passage
                C.Value = ""
                C.ToolTipText = "通道"
            Case Enum_State.Disable
                C.Style.BackColor = Color_Disable
                C.Value = s
                If IsNull(Dr("Msg"), "") <> "" Then
                    C.ToolTipText = "仓位编号:" & s & vbTab & "类型:禁用" & vbCrLf & Dr("Msg")
                Else
                    C.ToolTipText = "仓位编号:" & s & vbTab & "类型:禁用"
                End If
            Case Enum_State.Post
                C.Style.BackColor = Color_Post
                C.Value = "柱"
                C.Style.ForeColor = Color.Blue
                If IsNull(Dr("Msg"), "") <> "" Then
                    C.ToolTipText = "柱" & vbCrLf & Dr("Msg")
                Else
                    C.ToolTipText = "柱"
                End If
            Case Enum_State.Stairs
                C.Style.BackColor = Color_Stairs
                C.Value = "楼梯"
                C.Style.ForeColor = Color.Blue
                If IsNull(Dr("Msg"), "") <> "" Then
                    C.ToolTipText = "楼梯" & vbCrLf & Dr("Msg")
                Else
                    C.ToolTipText = "楼梯"
                End If
        End Select


        If IsSel Then
            C.Style.BackColor = Color_Sel
        End If
    End Sub


    Public Sub ShowSelList()
        Dim R() As DataRow
        For Each S As String In Last_List
            If S <> "" Then
                If S.Substring(1, 1) = Floor Then
                    R = Cell.Select("sNo='" & S & "'")
                    If R.Length > 0 Then
                        SetCellColor(LastDG, R(0))
                    End If
                End If
            End If
        Next
        Last_List.Clear()
        For Each S As String In Sel_List
            If S <> "" Then
                If S.Substring(1, 1) = Floor Then
                    R = Cell.Select("sNo='" & S & "'")
                    If R.Length > 0 Then
                        SetCellColor(LastDG, R(0), True)
                        Last_List.Add(S)
                    End If
                End If
            End If
        Next
    End Sub


    ''' <summary>
    ''' 刷新DG结果
    ''' </summary>
    ''' <param name="DG"></param>
    ''' <remarks></remarks>
    Public Sub DG_Ini(ByVal DG As DataGridView)
        LastDG = DG
        DG_Format(DG)
        Dim Rows() As DataRow
        Dim Cols() As DataRow

        Cols = Cell.Select("Y=0 ")

        For i As Integer = 0 To Cols.Length - 1
            DG.Columns.Add("C" & i, "")
            DG.Columns("C" & i).DefaultCellStyle.BackColor = Color.Coral
        Next
        _Col = Cols.Length '- 1
        Rows = Cell.Select("X=0 ")
        For i As Integer = 0 To Rows.Length - 1
            DG.Rows.Add()
            DG.Rows(i).DefaultCellStyle.BackColor = Color.Bisque
        Next
        _Row = Rows.Length - 1
        For Each Dr As DataRow In Rows
            DG.Rows(Dr("Y").ToString).Height = Dr("RowHeight")
        Next


        For Each Dr As DataRow In Cols
            DG.Columns("C" & Dr("x").ToString).Width = Dr("ColWidth")
        Next

    End Sub


    ''' <summary>
    ''' 获取新单元结构
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetNewCell() As DataTable
        Dim T As New DataTable("Passage")

        T.Columns.Add("Floor", GetType(String))
        T.Columns.Add("X", GetType(Integer))
        T.Columns.Add("Y", GetType(Integer))
        T.Columns.Add("ColWidth", GetType(Integer))
        T.Columns.Add("RowHeight", GetType(Integer))
        T.Columns.Add("sNo", GetType(String))
        T.Columns.Add("MaxQty", GetType(Integer))
        T.Columns.Add("Qty", GetType(Integer))
        T.Columns.Add("State", GetType(Integer))
        T.Columns.Add("Msg")
        Last_Area = ""
        Return T
    End Function

#Region "单元格"
    ''' <summary>
    ''' 分配编号
    ''' </summary>
    ''' <param name="NoStart"></param>
    ''' <remarks></remarks>
    Public Sub AutoAddNo(ByVal NoStart As Integer)
        'Dim Dr As DataRow
        'For Each Dr In Cell.Rows
        '    Dr("sNo") = ""
        'Next
        'Dim Rows() As DataRow = Cell.Select("", "y,x")

        'Dim j As Integer = 1
        'Dim x As Integer = 0
        'Dim K As Integer = 1
        'Dim Ly As Integer = -1
        'Dim G As Boolean = False
        'Dim GStart As Integer = 0
        'Dim GLastNo As Integer = 0

        'For i As Integer = 0 To Rows.Length - 1
        '    Dr = Rows(i)
        '    If Dr("State") = Enum_State.Normal OrElse Dr("State") = Enum_State.Disable Then
        '        If Dr("y") <> Ly Then
        '            j = NoStart
        '            Ly = Dr("y")
        '            If K > 70 Then
        '                If G Then '倒转赋值
        '                    K = GLastNo - 1
        '                    For N As Integer = i To GStart Step -1
        '                        Dr = Rows(N)
        '                        If Dr("State") = Enum_State.Normal OrElse Dr("State") = Enum_State.Disable Then
        '                            Dr("sNo") = Letter(x) & Floor & Format(K, "00")
        '                            j = j + 1
        '                            K = K + 1
        '                        End If
        '                    Next
        '                End If
        '                Dr = Rows(i)
        '                K = 1
        '                x = x + 1
        '            Else
        '                GStart = i
        '                GLastNo = K
        '                G = True
        '            End If
        '        End If
        '        Dr("sNo") = Letter(x) & Floor & Format(K, "00")
        '        j = j + 1
        '        K = K + 1
        '    End If
        'Next
        'If G Then '倒转赋值
        '    K = GLastNo
        '    For N As Integer = Rows.Length - 1 To GStart Step -1
        '        Dr = Rows(N)
        '        If Dr("State") = Enum_State.Normal OrElse Dr("State") = Enum_State.Disable Then
        '            Dr("sNo") = Letter(x) & Floor & Format(K, "00")
        '            j = j + 1
        '            K = K + 1
        '        End If
        '    Next
        'End If



        Dim Dr As DataRow
        For Each Dr In Cell.Rows
            Dr("sNo") = ""
        Next
        Dim Rows() As DataRow = Cell.Select("", "y,x")

        Dim j As Integer = 1
        Dim x As Integer = -1
        Dim K As Integer = 1
        Dim Ly As Integer = -1
        Dim G As Integer = 2
        Dim GStart As Integer = 0
        Dim GLastNo As Integer = 0


        For i As Integer = 0 To Rows.Length - 1
            Dr = Rows(i)
            If Dr("y") <> Ly Then
                If G = 2 Then
                    G = -1
                End If
                G = G + 1
                Select Case G
                    Case 0
                        x = x + 1
                        K = NoStart
                    Case 1
                    Case 2
                        K = NoStart + 1
                End Select
                Ly = Dr("y")
            End If
            If G <> 1 Then
                Dr = Rows(i)
                Dr("sNo") = Letter(x) & Floor & Format(K, "00")
                K = K + 2
            End If
        Next

   
    End Sub

    Public Function GetCellRow(ByVal X As Integer, ByVal Y As Integer) As DataRow
        Return Cell.Select("X=" & X & " and Y=" & Y)(0)
    End Function
#End Region


#Region "区域列表生成"





    Public Shared Function Get_Area_Dt() As DataTable
        Dim Dt As New DataTable("Floor")
        Dt.Columns.Add("Floor")
        Dt.Columns.Add("FloorName")

        Dt.Rows.Add(1, "一层")
        Dt.Rows.Add(2, "二层")
        Dt.Rows.Add(3, "三层")
        Dt.Rows.Add(4, "四层")
        Dt.Rows.Add(5, "五层")
        Dt.Rows.Add(6, "六层")
        Dt.AcceptChanges()
        Return Dt
    End Function

#End Region

    Public Shared Sub DG_Format(ByVal DG As DataGridView)

        DG.AllowUserToAddRows = False
        DG.AllowUserToDeleteRows = False
        DG.AllowUserToOrderColumns = False
        DG.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DG.RowsDefaultCellStyle.BackColor = Color.White
        DG.AllowUserToResizeRows = False
        DG.AllowUserToResizeColumns = False
        DG.Rows.Clear()
        DG.EditMode = DataGridViewEditMode.EditProgrammatically
        DG.Columns.Clear()
    End Sub


    Enum Enum_State
        ''' <summary>
        ''' 正常格
        ''' </summary>
        ''' <remarks></remarks>
        Normal = 0
        ''' <summary>
        ''' 柱
        ''' </summary>
        ''' <remarks></remarks>
        Post = 1
        ''' <summary>
        ''' 禁用
        ''' </summary>
        ''' <remarks></remarks>
        Disable = 2
        ''' <summary>
        ''' 通道
        ''' </summary>
        ''' <remarks></remarks>
        Passage = 3
        ''' <summary>
        ''' 楼梯
        ''' </summary>
        ''' <remarks></remarks>
        Stairs = 4
    End Enum

    Enum Enum_SelType
        ''' <summary>
        ''' 选择格
        ''' </summary>
        ''' <remarks></remarks>
        Cell = 0
        ''' <summary>
        ''' 选择布
        ''' </summary>
        ''' <remarks></remarks>
        BZ = 1

    End Enum


End Class

