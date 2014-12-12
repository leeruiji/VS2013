Imports System.Data
Imports PClass
Imports BaseClass
Imports PClass.PClass
Imports System.Text

Public Enum Enum_Order
    DataID = 0
    ClientBZColor = 1
    BZColor = 2
    BZ = 3
    Color = 4
End Enum

Public Class R40910_BZSH_Mx
    Inherits CReport
    Dim comletedCount As Integer = 0
    Protected fileName As String = "R40910_BZSH_Mx.grf"

    ''' <summary>
    ''' 排序方法
    ''' </summary>
    ''' <remarks></remarks>



    Dim FirstDate As Date
    Dim LastDate As Date
    Dim Client_ID As Integer
    Dim Client_Name As String = ""
    Dim LF As Integer = 0
    Dim Ln As Integer = 0
    Dim OList As List(Of FindOption)
    Public dtGoods As DataTable
    Dim IsLoaded As Boolean = False
    Public SumZL As Double
    Public SumNum As Integer
    Public order As Enum_Order


    Sub New()
        ReportFile = Me.fileName
        ReDim Dt_Header(1)

    End Sub

    Public Event StartLoading()
    Public Event HideLoading()


    Sub SetOption(ByVal startDate As Date, ByVal endDate As Date, ByVal _ClientId As Integer, ByVal Olist As List(Of FindOption))
        FirstDate = startDate
        LastDate = endDate
        Me.Client_ID = _ClientId
        Me.OList = Olist
        Ln = Ln + 1
        'If order = Enum_Order.BZ OrElse order = Enum_Order.BZColor Then
        '    ShowBZGroup(True)
        'Else
        '    ShowBZGroup(False)

        'End If
        'If _operator = OperatorType.LoadFile OrElse LF <> Ln Then
        Dim msg As DtReturnMsg = Dao.BZSH_Mx_Get(FirstDate, LastDate, Client_ID, Olist, order)
        If msg.IsOk Then
            If IsLoaded = False Then
                dtGoods = msg.Dt
                IsLoaded = True
            Else
                If dtGoods.Rows.Count < msg.Dt.Rows.Count Then
                    dtGoods = msg.Dt
                End If
            End If

            Dt_List = msg.Dt
            For Each R As DataRow In Dt_List.Rows
                If IsNull(R("Client_Bzc"), "") <> "" Then
                    R("Client_Bzc") = R("Client_Bzc") & "#"
                End If
                If IsNull(R("BZ_No"), "").ToString.Contains("#") = False Then
                    R("BZ_No") = ""
                End If
                If IsNull(R("CPName"), "") = "" Then
                    R("CPName") = R("BZ_No") & R("BZ_Name")
                End If
                If IsNull(R("BzcMsg"), "") = "" Then
                    R("BzcMsg") = R("Client_Bzc") & R("BZC_Name") & vbCrLf & "GY-" & Format(IsNull(R("BZc_No"), ""), "000000") & R("BZC_PF")
                End If
            Next
            SumNum = IsNull(Dt_List.Compute("Sum(Qty)", ""), 0)
            SumZL = IsNull(Dt_List.Compute("Sum(PWeight)", ""), 0)

            LF = Ln
            Dim dtHeader As New DataTable("T")
            dtHeader.Columns.Add("StartDate", GetType(Date))
            dtHeader.Columns.Add("EndDate", GetType(Date))

            Dim dr As DataRow = dtHeader.NewRow
            dr("StartDate") = Me.FirstDate
            dr("EndDate") = Me.LastDate

            dtHeader.Rows.Add(dr)
            Dt_Header(1) = dtHeader

            '        Me.DoOperator = _operator
            '        DoPrint()
            '    End If
            'Else
            '    Me.DoOperator = _operator
            '    DoPrint()
        End If
    End Sub


    Public Sub ShowBZGroup()
        Dim IsShow As Boolean = False
        Try

            If order = Enum_Order.BZ OrElse order = Enum_Order.BZColor Then
                Me.Report.DetailGrid.Groups("布类").Footer.Height = 0.64
            Else

                Me.Report.DetailGrid.Groups("布类").Footer.Height = 0

            End If

        Catch ex As Exception

        End Try

    End Sub
    Sub Start(ByVal Excelout As Boolean, Optional ByVal _operator As OperatorType = OperatorType.LoadFile)

        If Excelout Then
            Me.SetCanExcelOut()
        Else
            Me.SetCanNotExcelOut()
        End If

        Me.DoOperator = _operator
        If Me.DoOperator = OperatorType.LoadFile Then
            Me.LoadReport()

        Else
            Me.DoWork()
        End If

    End Sub


  
    Private Sub R40910_BZSH_Mx_ReportInitialize() Handles Me.ReportInitialize
        ShowBZGroup()
    End Sub
End Class
#Region "数据库交换"

Partial Friend Class Dao


    ''' <summary>
    ''' 获取查询条件集合
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function BZSH_Summary_GetConditionNames() As List(Of FindOption)
        Dim foList As New List(Of FindOption)
        Dim fo As New FindOption
        fo.Field = "请选择"
        fo.DB_Field = ""
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "缸号"
        fo.DB_Field = "GH"
        foList.Add(fo)

    



        Return foList
    End Function


    Public Shared Function BZSH_Mx_Get(ByVal startDate As Date, ByVal endDate As Date, ByVal _ClientID As Integer, ByVal Olist As List(Of FindOption), ByVal order As Enum_Order) As DtReturnMsg
        Dim r As New DtReturnMsg
        r.IsOk = False
        Dim para As New Dictionary(Of String, Object)
        para.Add("@StartDate", startDate)
        para.Add("@EndDate", endDate)
        Dim sqlBuider As New StringBuilder()
        '     sqlBuider.AppendLine("select T400.*,C.Client_No,C.Client_Name from ")
        sqlBuider.AppendLine("select P.* ,isnull(BZ.CP_No,BZ.BZ_No)as BZ_No,isnull(BZ.CP_Name,BZ.BZ_Name)as BZ_Name,isNull((Select top 1 Client_BZC from V10003_Client_BZC C ")
        sqlBuider.AppendLine(" where P.BZC_ID=C.BZC_ID and C.BZ_ID=P.BZ_ID),'') as Client_Bzc,BZC.BZC_Name,P.BZC_ID,BZC.BZC_No  ")
        sqlBuider.AppendLine(" ,(select top 1 Client_Name from T10110_Client where ID=p.Client_ID) as Client_Name ")
        sqlBuider.AppendLine("  from (select L.*,T.Client_ID,T.BZSH_Date from T40001_BZSH_List L ,T40000_BZSH_Table T  where T.State>=0 and  L.BZSH_ID=T.BZSH_ID )  P ")
        sqlBuider.Append("  left join T10002_BZ BZ on BZ.ID=P.BZ_ID  ")
        sqlBuider.Append("  left join T10003_BZC BZC on BZC.ID=P.BZC_ID   ")
        sqlBuider.Append(" where  BZSH_Date between @StartDate and  @EndDate ")
        If Olist.Count > 0 Then

            sqlBuider.Append(BaseClass.OptionClass.OptionClass_BuidSqlConditon(Olist, para))
        End If
        If _ClientID <> 0 Then
            sqlBuider.Append("  and P.Client_ID=@Client_ID  ")
            para.Add("@Client_Id", _ClientID)
        End If
        Select Case order
            Case Enum_Order.DataID
                sqlBuider.Append(" order by P.BZSH_Date,P.BZSH_ID,P.Line  ")
            Case Enum_Order.ClientBZColor
                sqlBuider.Append(" order by P.Client_ID,BZ_Name,BZC.BZC_Name,P.BZSH_Date,P.BZSH_ID  ")
            Case Enum_Order.BZColor
                sqlBuider.Append(" order by BZ_Name,BZC.BZC_Name,P.BZSH_Date,P.BZSH_ID  ")
            Case Enum_Order.BZ
                sqlBuider.Append(" order by BZ_Name,P.BZSH_Date,P.BZSH_ID  ")
            Case Enum_Order.Color
                sqlBuider.Append(" order by BZC.BZC_Name,P.BZSH_Date,P.BZSH_ID  ")
            Case Else
                sqlBuider.Append(" order by BZ_Name, P.BZSH_Date,P.BZSH_ID,P.Line  ")
        End Select


        Return PClass.PClass.SqlStrToDt(sqlBuider.ToString, para)

    End Function

End Class


#End Region


