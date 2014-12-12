Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports System.Threading

Public Class F15620_At_Change
    Dim AtID As String = ""
    Dim dtAt As DataTable

    Public Sub New()
        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        Bill_ID = ""
        ' 在 InitializeComponent() 调用之后添加任何初始化。
    End Sub

    Public Sub New(ByVal jID As String)
        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。
        AtID = jID
        Me.Mode = Mode
    End Sub
    ''' <summary>
    ''' 权限获取
    ''' </summary>
    ''' <remarks></remarks>
    Sub FormCheckRight()
        ID = 15620
        'Control_CheckRight(ID, ClassMain.Modify, Cmd_Modify)
        ' Control_CheckRight(ID, ClassMain.Del, Cmd_Del)
    End Sub

    Dim DtList As DataTable

    Private Sub F15620_At_Change_Me_Closing(ByVal sender As Object, ByRef e As System.ComponentModel.CancelEventArgs) Handles Me.Me_Closing
        If Panel1.Enabled = False AndAlso Me.CloseNoAsk = False Then
            e.Cancel = True
            ShowConfirm("正在分析中,是否强制关闭窗口,可能会造成数据分析不完整!", AddressOf Me.StopAndClose)
        End If
    End Sub
    Sub StopAndClose()
        Try
            cAt.IsStop = True
        Catch ex As Exception
        End Try
        CloseToNoAsk()
    End Sub


    Private Sub F15501_At_Msg_Load() Handles Me.Me_Load
        FormCheckRight()
        Ch_Name = GetBillTypeName(ID)
        'Dao.Balance_DB_NAME = Ch_Name
        Me.Title = Ch_Name & "列表"
        Dim D As Date = GetDate()
        DtList = New DataTable("T")
        DtList.Columns.Add("Dept_Name")
        DtList.Columns.Add("Employee_ID", GetType(Integer))
        DtList.Columns.Add("Employee_Name")
        DtList.Columns.Add("IsOk", GetType(Boolean))
        Fg1.DtToFG(DtList)
        DateTimePicker1.Text = D.ToString("yyyy-MM-01")
        DateTimePicker2.Value = D
    End Sub





#Region "分析部分"
    Dim RtStr As String = ""
    Dim WithEvents cAt As cAt_All

    Private Sub Button_Start_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Start.Click
        GetEmplyee()
        If DtList.Rows.Count = 0 Then
            ShowErrMsg("请选择要分析的人")
            Exit Sub
        End If
        PBE.Visible = True
        Panel1.Enabled = False
        If CheckBox1.Checked Then
            Fg1.Enabled = False
            LabelMsg.Text = "正在分析"
            Dim T As New Thread(AddressOf S_AT_Start)
            T.IsBackground = True
            T.Start()
        Else
            Fg1.Enabled = True
            BW.RunWorkerAsync()
            Exit Sub
        End If
    End Sub




    Sub S_AT_Start()
        Try
            Dim T As New S_AT.At_Change
            RtStr = T.Start(PClass.PClass.EnDes(PClass.PClass.CnnStr, "Msatn"), DateTimePicker1.Value.Date, DateTimePicker2.Value.Date, DtList)
        Catch ex As Exception
            RtStr = "分析失败,请尝试使用非高速模式"
        End Try
        Me.Invoke(New BaseClass.ComFun.DSub_None(AddressOf S_AT_Complete))
    End Sub


    Sub S_AT_Complete()
        PBE.Visible = False
        Button_Start.Enabled = True
        DateTimePicker1.Enabled = True
        DateTimePicker2.Enabled = True
        Panel1.Enabled = True
        Fg1.Enabled = True
        LabelMsg.Text = RtStr
    End Sub

    Sub GetEmplyee()
        If CheckBoxAll.Checked Then
            DtList.Rows.Clear()
            Dim R As DtReturnMsg = Dao.AllEmployee(DateTimePicker1.Value.Date)
            If R.IsOk AndAlso R.Dt.Rows.Count > 0 Then
                Fg1.Visible = False
                For Each Row As DataRow In R.Dt.Rows
                    Dim Dr As DataRow = DtList.NewRow
                    Dr("Employee_Name") = Row("Employee_Name")
                    Dr("Employee_ID") = Row("Employee_ID")
                    Dr("Dept_Name") = Row("Dept_Name")
                    Dr("IsOk") = False
                    DtList.Rows.Add(Dr)
                Next
                Fg1.ReAddIndex()
                Fg1.Visible = True
            End If
        End If
    End Sub


    Private Sub BW_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BW.DoWork
        Dim StartTime As Date = DateTime.Now   '获得开始时间 
        Try
            RtStr = ""
            Run()
            RtStr = RtStr & ",共用时间:" & Now.Subtract(StartTime).TotalSeconds & "秒"
        Catch ex As Exception
            RtStr = "分析失败," & ex.ToString & ",共用时间:" & Now.Subtract(StartTime).TotalSeconds & "秒"
        End Try
    End Sub

    Private Sub BW_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BW.RunWorkerCompleted
        PBE.Visible = False
        Button_Start.Enabled = True
        DateTimePicker1.Enabled = True
        DateTimePicker2.Enabled = True
        Panel1.Enabled = True
        LabelMsg.Text = RtStr
    End Sub


    '分析程序
    Sub Run()
        IsStop = False
        Dim T As New Thread(AddressOf Progress)
        T.Start()
        cAt = New cAt_All(DateTimePicker1.Value.Date, DateTimePicker2.Value.Date, DtList)
        cAt.Start()
        cAt.ProgressValue = 100
        cAt.progressEValue = 100
        cAt.ProgressMsg = "分析完成" & "一共分析了" & cAt.Ni & "人"
        RtStr = cAt.ProgressMsg
        IsStop = True
        ProgressDone.Set()
    End Sub




#Region "进度报告"


    Private ProgressDone As New ManualResetEvent(False)
    Private Sub cAt_ProgressEvent(ByVal ProgressValue As Integer, ByVal progressEValue As Integer, ByVal Msg As String) Handles cAt.ProgressEvent
        ProgressDone.Set()
    End Sub
    Dim IsStop As Boolean = False
    Sub Progress()
        Do Until IsStop = True
            ProgressDone.Reset()
            ProgressDone.WaitOne()
            Try
                Me.Invoke(New DDProgress(AddressOf DProgress))
            Catch ex As Exception

            End Try
        Loop
    End Sub
    Delegate Sub DDProgress()
    Sub DProgress()
        PB.Value = cAt.ProgressValue
        PBE.Value = 1
        LabelMsg.Text = "进度:" & cAt.ProgressValue & "%," & cAt.ProgressMsg
    End Sub
#End Region

#End Region

#Region "添加员工"
    Dim VF As PClass.ViewForm
    Dim F As F15542_AT_EmployeeSel
    Private Sub Cmd_SelDept_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_SelDept.Click
        'Dim VF As New PClass.ViewForm
        Dim F = New F15542_AT_EmployeeSel
        With F
            .Mode = Mode_Enum.Add
            .P_F_RS_ID = ""
            .P_F_RS_ID2 = ""
            '.parentForm = Me
        End With
        F_RS_ID = ""
        Me.ReturnId = ""
        Me.ReturnObj = Nothing
        If VF Is Nothing OrElse VF.IsDisposed = True Then
            VF = PClass.PClass.LoadChildForm(F, Me)
        Else
            Me.VForm.ShowShadow()
        End If

        AddHandler VF.ClosedX, AddressOf Getlist
        VF.Show()
    End Sub

    Private Sub Getlist()
        If ReturnObj Is Nothing Then
            Exit Sub
        End If
        Dim Addlist As DataTable = DtList.Clone
        Dataswap(ReturnObj, Addlist)
        Dim R As DtReturnMsg = CheckTable(Addlist, DtList)
        If R.IsOk Then
            DtList.Merge(R.Dt)
        End If
        Fg1.ReAddIndex()
    End Sub

    Private Sub Dataswap(ByVal ob As Object, ByVal dt As DataTable)
        Dim Dob As DataTable = TryCast(ob, DataTable)

        For Each row As DataRow In Dob.Rows
            If row.RowState = DataRowState.Deleted Then
                Continue For
            End If
            Dim dtrow As DataRow = dt.NewRow
            dtrow("Dept_Name") = row("Dept_Name")
            dtrow("Employee_Name") = row("Employee_Name")
            dtrow("Employee_ID") = row("ID")
            dtrow("IsOk") = False
            dt.Rows.Add(dtrow)
        Next

    End Sub


    Private Function CheckTable(ByVal dl As DataTable, ByVal dlist As DataTable) As DtReturnMsg
        Dim R As New DtReturnMsg
        If dl Is Nothing OrElse dlist Is Nothing Then
            R.IsOk = False
        End If
        Dim check As Boolean = False
        Dim dt As DataTable = dl.Clone
        For Each dr As DataRow In dl.Rows
            For i As Integer = 0 To dlist.Rows.Count - 1
                If dr("Employee_ID") = dlist.Rows(i)("Employee_ID") Then
                    check = True
                    Exit For

                End If

            Next
            If check = False Then
                dt.ImportRow(dr)
            End If
            check = False
        Next
        R.Dt = dt
        R.IsOk = True
        Return R
    End Function


    Private Sub Cmd_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Add.Click
        If CB_Employee.IDAsInt = 0 Then
            CB_Employee.SetSearchEmpty()
            Exit Sub
        End If

        'For i As Integer = 1 To Fg1.Rows.Count - 1

        'Next
        Dim Dr As DataRow = DtList.NewRow
        Dr("Employee_Name") = CB_Employee.NameValue
        Dr("Employee_ID") = CB_Employee.IDAsInt

        Dr("IsOk") = False
        DtList.Rows.Add(Dr)
        Fg1.ReAddIndex()
        CB_Employee.SetSearchEmpty()
    End Sub


#End Region

    Private Sub CheckBoxAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxAll.CheckedChanged
        Cmd_SelDept.Enabled = Not CheckBoxAll.Checked
        Cmd_Add.Enabled = Not CheckBoxAll.Checked
        CB_Employee.Enabled = Not CheckBoxAll.Checked
    End Sub

End Class

Partial Class Dao

    Public Shared Function AllEmployee(ByVal StartDate As Date) As DtReturnMsg
        Dim sqlBuider As New System.Text.StringBuilder("")
        sqlBuider.AppendLine("select U.ID as Employee_ID,Employee_Name" & vbCrLf)
        sqlBuider.AppendLine(",(case when len(Employee_Dept)=7 then ")
        sqlBuider.AppendLine(" (select top 1 Dept_Name from T15000_Department D where left(Employee_Dept,4)=D.Dept_No) ")
        sqlBuider.AppendLine(" else TD.Dept_Name end) as Dept_Name, ")
        sqlBuider.AppendLine(" (case when len(Employee_Dept)=7 then ")
        sqlBuider.AppendLine(" TD.Dept_Name else '' end )GroupName ")
        sqlBuider.AppendLine(" from ")
        sqlBuider.AppendLine("T15001_Employee U ")
        sqlBuider.AppendLine(" left join T15000_Department TD on U.Employee_Dept=TD.Dept_No  ")
        sqlBuider.AppendLine(" where (Employee_FileType <> '离职' or (Employee_FileType = '离职' and isnull(Employee_QuitDate,'2099-1-1')>='" & StartDate.ToString("yyyy-MM-dd") & "')) ")

        Return SqlStrToDt(sqlBuider.ToString)
    End Function

End Class