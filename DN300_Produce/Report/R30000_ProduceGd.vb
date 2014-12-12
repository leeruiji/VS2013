Imports System.Data
Imports PClass
Imports BaseClass
Imports PClass.PClass
Imports System.Text

Public Class R30000_ProduceGd

    Inherits CReport

    Dim comletedCount As Integer = 0

    Protected Const fileName As String = "R30000_ProduceGd.grf"
    Dim FirstDate As Date
    Dim LastDate As Date

    Dim _GH As String = ""


    Sub New(ByVal Excelout As Boolean)
        ReDim Dt_Header(1)
        ReportFile = fileName
        If Excelout Then
            Me.SetCanExcelOut()
        Else
            Me.SetCanNotExcelOut()
        End If
    End Sub





#Region "数据库交换"
    Sub Start(ByVal GH As String, ByVal DoOperator As OperatorType)
        Dim msg As DtReturnMsg = Dao.ProduceGd_GetById(GH)
        If msg.IsOk Then
            Me.Start(msg.Dt, DoOperator)
        End If
    End Sub



    Sub Start(ByVal dt As DataTable, ByVal DoOperator As OperatorType)
        If Not dt Is Nothing Then
            Dim T As DataTable = dt.Copy
            T.Columns.Add("RemarkString")
            T.Columns.Add("SmallGH")
            If T.Rows.Count > 0 Then
                Dim Dr As DataRow = T.Rows(0)
                ' T.Columns.Add("BzcMsg")

                If IsNull(T.Rows(0)("ClientBzc"), "") <> "" Then
                    Dr("ClientBzc") = Dr("ClientBzc") & "#"
                End If
                If IsNull(Dr("BZ_No"), "").ToString.Contains("#") = False Then
                    Dr("BZ_No") = ""
                End If
                If IsNull(Dr("CPName"), "") <> "" Then
                    Dr("CPName") = Dr("CPName")
                Else
                    Dr("CPName") = Dr("BZ_Name")
                End If

                If IsNull(Dr("CGRemark"), "") <> "" Then
                    Dr("CGRemark") = "拆缸原因:" & Dr("CGRemark")
                End If


                Dim p As New Dictionary(Of String, Object)
                p.Add("No_ID", Dr("GH"))
                p.Add("NO_Type", 30000)
                Dim RT As MsgReturn = SqlStrToOneStr("select top 1 No_TM from Bill_Barcode where No_ID=@No_ID and NO_Type=@NO_Type", p)
                If RT.IsOk = True Then
                    If RT.Msg = "" Then
                        RT = SqlStrToOneStr("insert into Bill_Barcode(No_ID,NO_Type)values(@No_ID,@NO_Type)" & vbCrLf & "Select @@Identity", p)
                        If RT.Msg = "" Then
                            RT.Msg = "0"
                        End If
                    End If
                End If

                Dr("SmallGH") = BaseClass.ComFun.GetGHTm(RT.Msg)
                If IsNull(Dr("IsFD"), False) = True AndAlso IsNull(Dr("BzcMsg"), "") = "" Then
                    Dr("BzcMsg") = "返定"
                Else
                    If IsNull(Dr("BzcMsg"), "") = "" Then
                        Dr("BzcMsg") = Dr("ClientBzc") & Dr("BZC_Name") & vbCrLf & "GY-" & Format(IsNull(Dr("BZc_No"), ""), "000000") & Dr("BZC_PF") & vbCrLf & Dr("RanSe")
                    End If
                End If


                Dim RemarkString As String = ""
                If IsNull(Dr("zhitong"), 0) <> 0 Then
                    RemarkString = RemarkString & "纸筒:" & Format(IsNull(Dr("zhitong"), 0), FormatSharp("zhitong")) & "KG   "
                End If

                If IsNull(Dr("jiazhong"), 0) <> 0 Then
                    RemarkString = RemarkString & "加大:" & Format(IsNull(Dr("jiazhong"), 0), FormatSharp("jiazhong")) & "KG   "
                End If

                T.Rows(0)("RemarkString") = RemarkString
                _GH = Dr("GH")
            End If
            Me.Dt_List = T
            Me.DoOperator = DoOperator
            ' Report.Printer.PrintOffsetY = TopMargin
            ' Report.Printer.LeftMargin = LeftMargin

            Me.DoWork()
        Else
            MsgBox("加载报表信息错误")
        End If
    End Sub

    Dim arr As Byte()
#End Region



    Private Sub R30000_ProduceGd_PrintEnd() Handles Me.PrintEnd
        Try
            PClass.PClass.RunSQL("Update T30000_Produce_Gd Set State =" & Enum_ProduceState.XiaDan & ",UPD_User=@UPD_User,UPD_Date=GetDate() where GH='" & _GH & "'and  State =" & Enum_ProduceState.AddNew, "UPD_User", User_Name)
        Catch ex As Exception
            MsgBox("更新运转单状态时发生错误。")
        End Try
    End Sub
End Class
