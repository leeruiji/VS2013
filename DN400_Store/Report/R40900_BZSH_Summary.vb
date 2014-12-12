Imports System.Data
Imports PClass
Imports BaseClass
Imports PClass.PClass
Imports System.Text

Public Class R40900_BZSH_Summary

    Inherits CReport
    Dim comletedCount As Integer = 0
    Protected fileName As String = "R40900_BZSH_Summary.grf"

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
    Public ColorDt As DataTable
    Private ContentCell As grproLib.IGRColumnContent
    Public Const Color_White As Integer = 16777215
    Public Const CTP_Sift As String = "*退胚*/*原货退回*"
    Public Const CTP_Color As Integer = 16754431
    Public Const CFG_Sift As String = "*退*不收费*"
    Public Const CFG_Color As Integer = 6986751
    Public Const CFK_Sift As String = "*退*收费*"
    Public Const CFK_Color As Integer = 16765090
    Public Const CQT_Sift As String = "*返定收费"
    Public Const CQT_Color As Integer = Color_White




    Sub New(ByVal Excelout As Boolean)
        ReportFile = Me.fileName
        ReDim Dt_Header(1)
       

    End Sub


    Sub SetOption(ByVal startDate As Date, ByVal endDate As Date, ByVal _ClientId As Integer, ByVal _clientName As String, ByVal Olist As List(Of FindOption), ByVal _State As String)
        FirstDate = startDate
        LastDate = endDate
        Me.Client_ID = _ClientId
        Client_Name = _clientName
        Me.OList = Olist
        Ln = Ln + 1
        Dim msg As DtReturnMsg
        If _State = "送货汇总" Then
            Dim msg1 As DtReturnMsg = Dao.BZSH_Summary_Get(FirstDate, LastDate, Client_ID, Olist)
            msg = msg1
        ElseIf _State = "外发加工汇总" Then
            Dim msg2 As DtReturnMsg = Dao.OutWork_Summary_Get(FirstDate, LastDate, Client_ID, Olist)
            msg = msg2
            'ElseIf _State = "全部汇总" Then
            '    Dim msg3 As DtReturnMsg = Dao.Summary_Get(FirstDate, LastDate, Client_ID, Olist)
            '    'Dim msg4 As DtReturnMsg = Dao.OutWork_Summary_Get(FirstDate, LastDate, Client_ID, Olist)
            '    msg = msg3
        End If
        If msg.IsOk Then
            If IsLoaded = False Then
                dtGoods = msg.Dt
                IsLoaded = True
            Else
                If dtGoods.Rows.Count < msg.Dt.Rows.Count Then
                    dtGoods = msg.Dt
                End If
            End If

            msg.Dt.Columns.Add("BackColor", GetType(Integer))
            Dt_List = msg.Dt
            Dim Normal_Qty As Integer = 0
            Dim Normal_PWeight As Double = 0

            Dim TP_Sift As String = CTP_Sift
            Dim TP_Type As Dao.SiftType = Dao.SiftType.TuiPei
            Dim TP_Color As Integer = CTP_Color
            Dim TP_Qty As Integer = 0
            Dim TP_PWeight As Double = 0

            Dim FG_Sift As String = CFG_Sift
            Dim FG_Type As Dao.SiftType = Dao.SiftType.FanGong
            Dim FG_Color As Integer = CFG_Color
            Dim FG_Qty As Integer = 0
            Dim FG_PWeight As Double = 0

            Dim FK_Sift As String = CFK_Sift
            Dim FK_Type As Dao.SiftType = Dao.SiftType.FanGong
            Dim FK_Color As Integer = CFK_Color


            Dim QT_Sift As String = CQT_Sift
            Dim QT_Type As Dao.SiftType = Dao.SiftType.Normal
            Dim QT_Color As Integer = CQT_Color

            If ColorDt IsNot Nothing Then
                Dim Drs() As DataRow
                Drs = ColorDt.Select("ID=0")
                If Drs.Length > 0 Then
                    TP_Sift = Drs(0)("Sift")
                    TP_Type = Drs(0)("Type")
                    TP_Color = Drs(0)("Color")
                End If

                Drs = ColorDt.Select("ID=1")
                If Drs.Length > 0 Then
                    FG_Sift = Drs(0)("Sift")
                    FG_Type = Drs(0)("Type")
                    FG_Color = Drs(0)("Color")
                End If

                Drs = ColorDt.Select("ID=2")
                If Drs.Length > 0 Then
                    FK_Sift = Drs(0)("Sift")
                    FK_Type = Drs(0)("Type")
                    FK_Color = Drs(0)("Color")
                End If

                Drs = ColorDt.Select("ID=3")
                If Drs.Length > 0 Then
                    QT_Sift = Drs(0)("Sift")
                    QT_Type = Drs(0)("Type")
                    QT_Color = Drs(0)("Color")
                End If
            End If

            For Each R As DataRow In Dt_List.Rows
                If IsNull(R("Client_Bzc"), "") <> "" Then
                    R("Client_Bzc") = R("Client_Bzc") & "#"
                End If
                If IsNull(R("BZ_No"), "").ToString.Contains("#") = False Then
                    R("BZ_No") = ""
                End If


                If IsNull(R("BzcMsg"), "") = "" Then
                    R("BzcMsg") = R("Client_Bzc") & R("BZC_Name") & vbCrLf & "GY-" & Format(IsNull(R("BZc_No"), ""), "000000") & R("BZC_PF")
                End If

                Dim JG As String = IsNull(R("JiaGongNeiRong"), "")


                If StrLikeCheck(JG, TP_Sift) Then
                    R("BackColor") = TP_Color
                    Select Case TP_Type
                        Case Dao.SiftType.Normal
                            Normal_Qty = Normal_Qty + R("Qty")
                            Normal_PWeight = Normal_PWeight + R("PWeight")
                        Case Dao.SiftType.TuiPei
                            TP_Qty = TP_Qty + R("Qty")
                            TP_PWeight = TP_PWeight + R("PWeight")
                        Case Dao.SiftType.FanGong
                            FG_Qty = FG_Qty + R("Qty")
                            FG_PWeight = FG_PWeight + R("PWeight")
                    End Select
                ElseIf StrLikeCheck(JG, FG_Sift) Then
                    R("BackColor") = FG_Color
                    Select Case FG_Type
                        Case Dao.SiftType.Normal
                            Normal_Qty = Normal_Qty + R("Qty")
                            Normal_PWeight = Normal_PWeight + R("PWeight")
                        Case Dao.SiftType.TuiPei
                            TP_Qty = TP_Qty + R("Qty")
                            TP_PWeight = TP_PWeight + R("PWeight")
                        Case Dao.SiftType.FanGong
                            FG_Qty = FG_Qty + R("Qty")
                            FG_PWeight = FG_PWeight + R("PWeight")
                    End Select
                ElseIf StrLikeCheck(JG, FK_Sift) Then
                    R("BackColor") = FK_Color
                    Select Case FK_Type
                        Case Dao.SiftType.Normal
                            Normal_Qty = Normal_Qty + R("Qty")
                            Normal_PWeight = Normal_PWeight + R("PWeight")
                        Case Dao.SiftType.TuiPei
                            TP_Qty = TP_Qty + R("Qty")
                            TP_PWeight = TP_PWeight + R("PWeight")
                        Case Dao.SiftType.FanGong
                            FG_Qty = FG_Qty + R("Qty")
                            FG_PWeight = FG_PWeight + R("PWeight")
                    End Select
                ElseIf StrLikeCheck(JG, QT_Sift) Then
                    R("BackColor") = QT_Color
                    Select Case QT_Type
                        Case Dao.SiftType.Normal
                            Normal_Qty = Normal_Qty + R("Qty")
                            Normal_PWeight = Normal_PWeight + R("PWeight")
                        Case Dao.SiftType.TuiPei
                            TP_Qty = TP_Qty + R("Qty")
                            TP_PWeight = TP_PWeight + R("PWeight")
                        Case Dao.SiftType.FanGong
                            FG_Qty = FG_Qty + R("Qty")
                            FG_PWeight = FG_PWeight + R("PWeight")
                    End Select
                Else
                    R("BackColor") = Color_White
                    Normal_Qty = Normal_Qty + R("Qty")
                    Normal_PWeight = Normal_PWeight + R("PWeight")
                End If
            Next
            SumNum = IsNull(Dt_List.Compute("Sum(Qty)", ""), 0)
            SumZL = IsNull(Dt_List.Compute("Sum(PWeight)", ""), 0)

            LF = Ln
            Dim dtHeader As New DataTable("T")
            dtHeader.Columns.Add("StartDate", GetType(Date))
            dtHeader.Columns.Add("EndDate", GetType(Date))
            dtHeader.Columns.Add("MadeDate", GetType(Date))
            dtHeader.Columns.Add("Client_Name", GetType(String))
            dtHeader.Columns.Add("User_Name", GetType(String))
            dtHeader.Columns.Add("DateStr")

            dtHeader.Columns.Add("Normal_Qty")
            dtHeader.Columns.Add("Normal_PWeight")
            dtHeader.Columns.Add("TP_Qty")
            dtHeader.Columns.Add("TP_PWeight")
            dtHeader.Columns.Add("FG_Qty")
            dtHeader.Columns.Add("FG_PWeight")


            Dim dr As DataRow = dtHeader.NewRow
            dr("StartDate") = Me.FirstDate
            dr("EndDate") = Me.LastDate
            dr("Client_Name") = Me.Client_Name
            dr("MadeDate") = Me.LastDate.AddDays(1)
            dr("User_Name") = User_Name
            dr("Normal_Qty") = Normal_Qty
            dr("Normal_PWeight") = Normal_PWeight
            dr("TP_Qty") = TP_Qty
            dr("TP_PWeight") = TP_PWeight
            dr("FG_Qty") = FG_Qty
            dr("FG_PWeight") = FG_PWeight

            If Me.FirstDate.Month = Me.LastDate.Month AndAlso Me.FirstDate.Year = Me.LastDate.Year Then
                dr("DateStr") = Me.FirstDate.ToString("yyyy年MM月")
            ElseIf Me.FirstDate.Month <> Me.LastDate.Month AndAlso Me.FirstDate.Year = Me.LastDate.Year Then
                dr("DateStr") = Me.FirstDate.ToString("yyyy年MM") & Me.LastDate.ToString("-MM月")
            Else
                dr("DateStr") = Me.FirstDate.ToString("yyyy年MM月") & Me.LastDate.ToString("yyyy年MM月")
            End If
            dtHeader.Rows.Add(dr)
            Dt_Header(1) = dtHeader
        End If
    End Sub






    Sub Start(ByVal Excelout As Boolean, Optional ByVal _operator As OperatorType = OperatorType.LoadFile)

        If Excelout Then
            Me.SetCanExcelOut()
        Else
            Me.SetCanNotExcelOut()
        End If

        If Client_ID = 0 Then
            Exit Sub
        End If
        Me.DoOperator = _operator
        If _operator = OperatorType.LoadFile Then
            Me.LoadReport()
            SetColVStyle()
        Else
            SetColVStyle()
            Me.DoWork()
        End If
    End Sub

    Sub SetColVStyle()
        Select Case DoOperator
            Case OperatorType.ExportDirect '导出

                Me.Report.ReportHeader(1).RepeatOnPage = False
                Me.Report.ReportFooter(1).Visible = True
                Me.Report.ReportFooter(2).Visible = True
                Me.Report.ReportFooter(3).Visible = True
                Me.Report.ReportFooter(4).Visible = False

                Me.Report.ReportFooter(1).NewPage = grproLib.GRNewPageStyle.grnpsNone
                Me.Report.ReportFooter(2).NewPage = grproLib.GRNewPageStyle.grnpsNone
                Me.Report.ReportFooter(3).NewPage = grproLib.GRNewPageStyle.grnpsNone


                Me.Report.DetailGrid.ColumnTitle.RepeatStyle = grproLib.GRRepeatStyle.grrsNone
            Case OperatorType.Preview, OperatorType.Print '预览和打印

                Me.Report.ReportHeader(1).RepeatOnPage = True

                Me.Report.ReportFooter(1).Visible = False
                Me.Report.ReportFooter(2).Visible = True
                Me.Report.ReportFooter(3).Visible = True
                Me.Report.ReportFooter(4).Visible = True

                Me.Report.ReportFooter(1).NewPage = grproLib.GRNewPageStyle.grnpsNone

                Dim Y As Integer = Dt_List.Rows.Count Mod 20
                If Dt_List.Rows.Count = 0 Then Y = -1
                If Y = 0 Then Y = 20
                Select Case Y '根据行数去决定换页
                    Case Is > 16
                        Me.Report.ReportFooter(2).NewPage = grproLib.GRNewPageStyle.grnpsBefore
                        Me.Report.ReportFooter(3).NewPage = grproLib.GRNewPageStyle.grnpsNone
                    Case Is > 14
                        Me.Report.ReportFooter(2).NewPage = grproLib.GRNewPageStyle.grnpsNone
                        Me.Report.ReportFooter(3).NewPage = grproLib.GRNewPageStyle.grnpsBefore
                    Case Else
                        Me.Report.ReportFooter(2).NewPage = grproLib.GRNewPageStyle.grnpsNone
                        Me.Report.ReportFooter(3).NewPage = grproLib.GRNewPageStyle.grnpsNone
                End Select



                Me.Report.DetailGrid.ColumnTitle.RepeatStyle = grproLib.GRRepeatStyle.grrsOnPage
            Case OperatorType.LoadFile
                Me.Report.ReportHeader(1).RepeatOnPage = True

                Me.Report.ReportFooter(1).Visible = True
                Me.Report.ReportFooter(2).Visible = True
                Me.Report.ReportFooter(3).Visible = False
                Me.Report.ReportFooter(4).Visible = False


                Me.Report.DetailGrid.ColumnTitle.RepeatStyle = grproLib.GRRepeatStyle.grrsOnPage
        End Select
    End Sub



    Private Sub R40900_BZSH_Summary_ReportInitialize() Handles Me.ReportInitialize
        ContentCell = Report.DetailGrid.ColumnContent




    End Sub

    Private Sub R40900_BZSH_Summary_SectionFormat() Handles Me.SectionFormat
        Dim BackColor As UInteger
        'Select Case Report.FieldByName("BackColor").Value
        '    Case 1
        '        BackColor = &HC080FF
        '    Case 2
        '        BackColor = &H80CCFF
        '    Case 3
        '        BackColor = &H84FBE3
        '    Case Else
        '        BackColor = &HFFFFFF
        'End Select

        BackColor = Report.FieldByName("BackColor").Value
        ContentCell.ContentCells.Item("加工内容").BackColor = BackColor
        ContentCell.ContentCells.Item("胚匹").BackColor = BackColor
        ContentCell.ContentCells.Item("胚重").BackColor = BackColor



    End Sub





End Class
#Region "数据库交换"

Partial Friend Class Dao





    Public Shared Function BZSH_Summary_Get(ByVal startDate As Date, ByVal endDate As Date, ByVal _ClientID As Integer, ByVal Olist As List(Of FindOption)) As DtReturnMsg
        Dim r As New DtReturnMsg
        r.IsOk = False
        Dim para As New Dictionary(Of String, Object)
        para.Add("@StartDate", startDate)
        para.Add("@EndDate", endDate)

        para.Add("@Client_Id", _ClientID)
        Dim sqlBuider As New StringBuilder()
        '     sqlBuider.AppendLine("select T400.*,C.Client_No,C.Client_Name from ")
        sqlBuider.AppendLine("select  P.* ,isnull(BZ.CP_No,BZ.BZ_No)as BZ_No,isnull(BZ.CP_Name,BZ.BZ_Name)as BZ_Name,isNull((Select top 1 Client_BZC from V10003_Client_BZC C ")
        sqlBuider.AppendLine(" where P.BZC_ID=C.BZC_ID and C.BZ_ID=P.BZ_ID),'') as Client_Bzc,BZC.BZC_Name,P.BZC_ID,BZC.BZC_No  ")
        sqlBuider.AppendLine("  from (select L.*,T.Client_ID,T.BZSH_Date from T40001_BZSH_List L ,T40000_BZSH_Table T  where T.State>=0 and L.BZSH_ID=T.BZSH_ID )  P ")
        sqlBuider.Append("  left join T10002_BZ BZ on BZ.ID=P.BZ_ID  ")
        sqlBuider.Append("   left join T10003_BZC BZC on BZC.ID=P.BZC_ID   ")
        If Olist.Count > 0 Then

            sqlBuider.Append(BaseClass.OptionClass.OptionClass_BuidSqlConditon(Olist, para))
        End If
        '   sqlBuider.Append(" ) T400 left join T10110_Client on T400.Client_ID=C.ID")
        sqlBuider.Append(" where  BZSH_Date between @StartDate and  @EndDate and P.Client_ID=@Client_ID   ")
        sqlBuider.Append(" order by P.BZSH_Date,P.BZSH_ID,P.Line  ")
        Return PClass.PClass.SqlStrToDt(sqlBuider.ToString, para)

    End Function

    Public Shared Function OutWork_Summary_Get(ByVal startDate As Date, ByVal endDate As Date, ByVal _ClientID As Integer, ByVal Olist As List(Of FindOption)) As DtReturnMsg
        Dim r As New DtReturnMsg
        r.IsOk = False
        Dim para As New Dictionary(Of String, Object)
        para.Add("@StartDate", startDate)
        para.Add("@EndDate", endDate)

        'para.Add("@Client_Id", _ClientID)
        Dim sqlBuider As New StringBuilder()
        '     sqlBuider.AppendLine("select T400.*,C.Client_No,C.Client_Name from ")
        sqlBuider.AppendLine("select '' as BzcMsg,'' as Client_Bzc ,'' as BZ_No,''as BZ_Name,''as BZC_Name,''as BZC_No,''as BZC_PF,T.OutWork_Date,T.ZhiDan as orderBill,T.ID as BZSH_ID,T.SumQty  as Qty,T.SumPWeight as PWeight ,L.GH ,L.JiaGongNeiRong,L.Line  ")
        sqlBuider.AppendLine("from T40002_OutWork_Table T ")
        sqlBuider.AppendLine(" left join T40003_OutWork_List L on L.ID =T.ID ")
        'sqlBuider.Append("  left join T10002_BZ BZ on BZ.ID=P.BZ_ID  ")
        'sqlBuider.Append("   left join T10003_BZC BZC on BZC.ID=P.BZC_ID   ")
        If Olist.Count > 0 Then

            sqlBuider.Append(BaseClass.OptionClass.OptionClass_BuidSqlConditon(Olist, para))
        End If
        '   sqlBuider.Append(" ) T400 left join T10110_Client on T400.Client_ID=C.ID")
        sqlBuider.Append(" where  OutWork_Date between @StartDate and  @EndDate   ")
        sqlBuider.Append(" order by L.Line  ")
        Return PClass.PClass.SqlStrToDt(sqlBuider.ToString, para)

    End Function
    Public Shared Function Summary_Get(ByVal startDate As Date, ByVal endDate As Date, ByVal _ClientID As Integer, ByVal Olist As List(Of FindOption)) As DtReturnMsg
        Dim r As New DtReturnMsg
        r.IsOk = False
        Dim para As New Dictionary(Of String, Object)
        para.Add("@StartDate", startDate)
        para.Add("@EndDate", endDate)

        para.Add("@Client_Id", _ClientID)
        Dim sqlBuider As New StringBuilder()
        '     sqlBuider.AppendLine("select T400.*,C.Client_No,C.Client_Name from ")
        sqlBuider.AppendLine("select  P.* ,isnull(BZ.CP_No,BZ.BZ_No)as BZ_No,isnull(BZ.CP_Name,BZ.BZ_Name)as BZ_Name,isNull((Select top 1 Client_BZC from V10003_Client_BZC C ")
        sqlBuider.AppendLine(" where P.BZC_ID=C.BZC_ID and C.BZ_ID=P.BZ_ID),'') as Client_Bzc,BZC.BZC_Name,P.BZC_ID,BZC.BZC_No  ")
        sqlBuider.AppendLine("  from (select L.*,T.Client_ID,T.BZSH_Date from T40001_BZSH_List L ,T40000_BZSH_Table T  where T.State>=0 and L.BZSH_ID=T.BZSH_ID )  P ")
        sqlBuider.Append("  left join T10002_BZ BZ on BZ.ID=P.BZ_ID  ")
        sqlBuider.Append("   left join T10003_BZC BZC on BZC.ID=P.BZC_ID   ")
        If Olist.Count > 0 Then

            sqlBuider.Append(BaseClass.OptionClass.OptionClass_BuidSqlConditon(Olist, para))
        End If
        '   sqlBuider.Append(" ) T400 left join T10110_Client on T400.Client_ID=C.ID")
        sqlBuider.Append(" where  BZSH_Date between @StartDate and  @EndDate and P.Client_ID=@Client_ID   ")
        sqlBuider.Append(" order by P.BZSH_Date,P.BZSH_ID,P.Line  ")
        Return PClass.PClass.SqlStrToDt(sqlBuider.ToString, para)

    End Function
End Class


#End Region


