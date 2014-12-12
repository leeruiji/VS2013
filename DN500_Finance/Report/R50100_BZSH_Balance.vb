Imports System.Data
Imports PClass
Imports BaseClass
Imports PClass.PClass
Imports System.Text

Public Class R50100_BZSH_Balance

    Inherits CReport

    Dim comletedCount As Integer = 0

    Protected Const fileName As String = "R50100_BZSH_Balance.grf"

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


    Sub New()
        ReDim Dt_Header(1)
        ReportFile = fileName
    End Sub





#Region "数据库交换"

    Sub SetOption(ByVal startDate As Date, ByVal endDate As Date, ByVal _ClientId As Integer, ByVal _clientName As String)
        FirstDate = startDate
        LastDate = endDate
        Me.Client_ID = _ClientId
        Client_Name = _clientName
        Me.OList = Olist
        Ln = Ln + 1
    End Sub

    Sub Start(ByVal _ID As String, Optional ByVal _operator As OperatorType = OperatorType.LoadFile)
        If _ID = "0" Then
            Exit Sub
        End If

        '   If _operator = OperatorType.LoadFile OrElse LF <> Ln Then
        'Dim msgTable As DtReturnMsg = Dao.Balance_GetById(_ID)
        'If msgTable.IsOk AndAlso msgTable.Dt.Rows.Count > 0 Then
        '    Me.FirstDate = Dao.CBalance_GetLast_BalanceDate(_ID)
        '    Me.LastDate = msgTable.Dt.Rows(0)("sDate")
        '    Me.Client_Name = msgTable.Dt.Rows(0)("Client_Name")
        '    Me.Client_ID = msgTable.Dt.Rows(0)("Client_ID")
        '    SetHeader()
        'End If
        SetHeader()
        Dim msg As DtReturnMsg = Dao.Balance_SelListById_AfterLock(_ID)
        If msg.IsOk Then
            Dim dtList As DataTable = msg.Dt
            If IsLoaded = False Then
                dtGoods = dtList
                IsLoaded = True
            Else
                If dtGoods.Rows.Count < dtList.Rows.Count Then
                    dtGoods = dtList
                End If
            End If

            Dt_List = dtList



            For Each R As DataRow In Dt_List.Rows
                'If IsNull(R("Client_Bzc"), "") <> "" Then
                '    R("Client_Bzc") = R("Client_Bzc") & "#"
                'End If
                'If IsNull(R("BZ_No"), "").ToString.Contains("#") = False Then
                '    R("BZ_No") = ""
                'End If
                Dim JG As String = IsNull(R("JiaGongNeiRong"), "")
                If JG.Contains("返") Then

                ElseIf JG.Contains("退") Then


                End If



            Next
            SumNum = IsNull(Dt_List.Compute("Sum(Qty)", ""), 0)
            SumZL = IsNull(Dt_List.Compute("Sum(PWeight)", ""), 0)

            LF = Ln


            Me.DoOperator = _operator
            If _operator = OperatorType.LoadFile Then
                Me.LoadReport()
            Else
                Me.DoWork()
            End If
        End If
        'Else
        'Me.DoOperator = _operator
        'Me.DoWork()
        ' End If
    End Sub


    Sub Start(ByVal dtList As DataTable, Optional ByVal _operator As OperatorType = OperatorType.LoadFile)
        If Client_ID = 0 Then
            Exit Sub
        End If
        If _operator = OperatorType.LoadFile OrElse LF <> Ln Then

            If dtList IsNot Nothing Then
                If IsLoaded = False Then
                    dtGoods = dtList
                    IsLoaded = True
                Else
                    If dtGoods.Rows.Count < dtList.Rows.Count Then
                        dtGoods = dtList
                    End If
                End If

                Dt_List = dtList



                For Each R As DataRow In Dt_List.Rows
                    'If IsNull(R("Client_Bzc"), "") <> "" Then
                    '    R("Client_Bzc") = R("Client_Bzc") & "#"
                    'End If
                    'If IsNull(R("BZ_No"), "").ToString.Contains("#") = False Then
                    '    R("BZ_No") = ""
                    'End If
                    Dim JG As String = IsNull(R("JiaGongNeiRong"), "")
                    If JG.Contains("返") Then

                    ElseIf JG.Contains("退") Then


                    End If



                Next
                SumNum = IsNull(Dt_List.Compute("Sum(Qty)", ""), 0)
                SumZL = IsNull(Dt_List.Compute("Sum(PWeight)", ""), 0)

                LF = Ln
                SetHeader()

                Me.DoOperator = _operator
                If _operator = OperatorType.LoadFile Then
                    Me.LoadReport()
                Else
                    Me.DoWork()
                End If
            End If
        Else
            Me.DoOperator = _operator
            Me.DoWork()
        End If
    End Sub

    Private Sub SetHeader()
        Dim dtHeader As New DataTable("T")
        dtHeader.Columns.Add("StartDate", GetType(Date))
        dtHeader.Columns.Add("EndDate", GetType(Date))
        dtHeader.Columns.Add("MadeDate", GetType(Date))
        dtHeader.Columns.Add("Client_Name", GetType(String))
        dtHeader.Columns.Add("User_Name", GetType(String))
        dtHeader.Columns.Add("DateStr")



        Dim dr As DataRow = dtHeader.NewRow
        dr("StartDate") = Me.FirstDate
        dr("EndDate") = Me.LastDate
        dr("Client_Name") = Me.Client_Name
        dr("MadeDate") = Me.LastDate.AddDays(1)
        dr("User_Name") = User_Name
        If Me.FirstDate.Month = Me.LastDate.Month AndAlso Me.FirstDate.Year = Me.LastDate.Year Then
            dr("DateStr") = Me.FirstDate.ToString("yyyy年MM月")
        ElseIf Me.FirstDate.Month <> Me.LastDate.Month AndAlso Me.FirstDate.Year = Me.LastDate.Year Then
            dr("DateStr") = Me.FirstDate.ToString("yyyy年MM") & Me.LastDate.ToString("至MM月")
        Else
            dr("DateStr") = Me.FirstDate.ToString("yyyy年MM月") & Me.LastDate.ToString("至yyyy年MM月")
        End If


        dtHeader.Rows.Add(dr)
        Dt_Header(1) = dtHeader
    End Sub


    Dim arr As Byte()
#End Region








End Class

Partial Class Dao

    ''' <summary>
    ''' 获取表头结构
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CBalance_GetEmpty_PrintDt() As DataTable
        Dim dt As New DataTable("T")
        dt.Columns.Add("sDate", GetType(Date))
        dt.Columns.Add("BZ", GetType(String))
        dt.Columns.Add("BZC", GetType(String))
        dt.Columns.Add("GH", GetType(String))
        dt.Columns.Add("JiaGongNeiRong", GetType(String))
        dt.Columns.Add("Qty", GetType(Integer))
        dt.Columns.Add("PWeight", GetType(Double))
        dt.Columns.Add("Price", GetType(Double))
        dt.Columns.Add("Amount", GetType(Double))
        dt.Columns.Add("JiaoDai", GetType(String))
        dt.Columns.Add("Amount_JiaoDai", GetType(Double))
        dt.Columns.Add("ZhiTong", GetType(Double))
        dt.Columns.Add("Amount_ZhiTong", GetType(Double))
        dt.Columns.Add("Amount_GH", GetType(Double))
        dt.Columns.Add("sID", GetType(String))
        dt.Columns.Add("Price_ZhiTong", GetType(Double))
        dt.Columns.Add("StartDate", GetType(Date))
        dt.Columns.Add("EndDate", GetType(Date))

        'dt.Columns.Add("Client_Bzc", GetType(String))
        'dt.Columns.Add("BZ_No", GetType(String))
        'dt.Columns.Add("BZ_Name", GetType(String))
        'dt.Columns.Add("BZC_No", GetType(String))
        'dt.Columns.Add("BZC_Name", GetType(String))
        'dt.Columns.Add("BZC_PF", GetType(String))

        dt.Columns.Add("Client_Name", GetType(String))
        dt.Columns.Add("User_Name", GetType(String))
        dt.Columns.Add("DateStr", GetType(String))
        dt.Columns.Add("MadeDate", GetType(Date))
        Return dt
    End Function
End Class