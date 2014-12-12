Option Compare Text
Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports PClass
Imports BaseClass
Imports PClass.CReport

Public Class F40940_QCSH_Summary
    Private WithEvents R As New R40940_QCSH_Summary
    Dim isLoaded As Boolean = False
    Dim ExcelOut As Boolean = False
    ''' <summary>
    ''' 权限获取
    ''' </summary>
    ''' <remarks></remarks>
    Sub FormCheckRight()
        ExcelOut = CheckRight(ID, ClassMain.RpCanExcelOut)

        'Control_CheckRight(ID, ClassMain.Print, Cmd_Print)
    End Sub

    Private Sub Form_Me_Load() Handles MyBase.Me_Load
        FormCheckRight()
        Ch_Name = GetBillTypeName(ID)
        Me.Title = Ch_Name


        DP_Start.Value = New Date(Today.Year, Today.Month, 1)
        DP_End.Value = GetDate()
        Try
            GR.Report = R.Report
        Catch ex As Exception
            Me.Close()
            Exit Sub
        End Try
        Me_Refresh()
        isLoaded = True
        ' Dim T As New Threading.Thread(AddressOf Get_Goods)
        '  T.Start()
    End Sub

    Protected Sub Me_Refresh()
        If CK_Date.Checked Then
            R.SetOption(DP_End.Value.Date, DP_End.Value.Date)
        Else
            R.SetOption(DP_Start.Value.Date, DP_End.Value.Date)
        End If

        R.Start(ExcelOut)
    End Sub

#Region "控件事件"
    'Private Sub Btn_ExcelOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_ExcelOut.Click
    '    R.ExportXLS()
    'End Sub
    'Private Sub Btn_PrePrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_PrePrint.Click
    '    R.PrintPreview()
    'End Sub
    Private Sub R_LoadFileCompleted() Handles R.LoadFileCompleted
        GR.Refresh()
    End Sub

    'Private Sub Btn_Refresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Search.Click
    '    Me_Refresh()
    'End Sub
    Private Sub Btn_Search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Search.Click
        Me.Me_Refresh()
    End Sub

    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub

    Private Sub CK_Date_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CK_Date.CheckStateChanged
        If CK_Date.Checked Then
            Label_C.Visible = False
            Label_D.Visible = False
            DP_Start.Visible = False
        Else
            Label_C.Visible = True
            Label_D.Visible = True
            DP_Start.Visible = True
        End If
    End Sub

#End Region

#Region "打印预览报表"
    Private Sub Cmd_Preview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        R.Start(ExcelOut, OperatorType.Preview)
    End Sub
#End Region



End Class

