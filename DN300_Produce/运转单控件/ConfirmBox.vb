Imports PClass

Public Class ConfirmBox
    Implements IViewForm
    Dim ResultReturn As DeReturn
    Dim ResultButton1 As DeNoReturn
    Dim ResultButton2 As DeNoReturn
    Dim ResultButton3 As DeNoReturn
    Dim ResultNoReturn As DeNoReturn

    Dim ResultHideShadow As DeHideShadow
    Dim NoReturn As DeNoReturn
    Public Delegate Sub DeReturn(ByVal Result As MsgBoxResult)
    Public Delegate Sub DeHideShadow()
    Public Delegate Sub DeNoReturn()
    Public Result As MsgBoxResult
    Public MsButton As MessageBoxButtons
    Public ReturnMode As Integer
    Private IsLoad As Boolean = False

    Sub New(ByVal Msg As String, ByVal Title As String, ByVal ResultReturn As DeReturn, ByVal HideShadow As DeHideShadow, Optional ByVal Button As MessageBoxButtons = MessageBoxButtons.OK, Optional ByVal Icon As MessageBoxIcon = MessageBoxIcon.None)
        ' 此调用是设计器所必需的。
        InitializeComponent()
        ReturnMode = 1
        Me.ResultReturn = ResultReturn
        Me.ResultHideShadow = HideShadow
        Me.Text = Title
        Label1.Text = Msg
        MsButton = Button
        Dim PngName As String = ""
        Select Case Button
            Case MessageBoxButtons.OK
                Result = MsgBoxResult.Ok
                PngName = "Information"
                SP_OK.Visible = True
            Case MessageBoxButtons.OKCancel
                PngName = "Question"
                ButtonY.Text = "确定(_Y)"
                ButtonN.Text = "取消(_N)"
                Result = MsgBoxResult.Cancel
                SP_YesNo.Visible = True
            Case MessageBoxButtons.YesNo
                Result = MsgBoxResult.No
                PngName = "Question"
                SP_YesNo.Visible = True
            Case MessageBoxButtons.YesNoCancel
                Result = MsgBoxResult.Cancel
                PngName = "Question"
                Sp_YesNoCancel.Visible = True
        End Select

        Select Case Icon
            Case MessageBoxIcon.None
                PictureBox1.Visible = False
            Case MessageBoxIcon.Warning
                PngName = "Warning"
            Case MessageBoxIcon.Asterisk
                PngName = "Asterisk"
            Case MessageBoxIcon.Error
                PngName = "Error"
            Case MessageBoxIcon.Exclamation
                PngName = "Exclamation"
            Case MessageBoxIcon.Hand
                PngName = "Hand"
            Case MessageBoxIcon.Information
                PngName = "Information"
            Case MessageBoxIcon.Question
                PngName = "Question"
            Case MessageBoxIcon.Stop
                PngName = "Stop"
        End Select


        If PngName <> "" Then
            PictureBox1.Image = My.Resources.ResourceManager.GetObject("_" & PngName)
        Else
            PictureBox1.Visible = False
        End If

        Me.Show()
    End Sub

    Sub New(ByVal Msg As String, ByVal Title As String, ByVal ResultReturn As DeNoReturn, ByVal HideShadow As DeHideShadow, Optional ByVal Icon As MessageBoxIcon = MessageBoxIcon.None)
        ' 此调用是设计器所必需的。
        InitializeComponent()

        ReturnMode = 0
        Me.ResultNoReturn = ResultReturn
        Me.ResultHideShadow = HideShadow
        Me.Text = Title
        Label1.Text = Msg
        MsButton = MsgBoxResult.Ok
        Dim PngName As String = ""

        Result = MsgBoxResult.Ok
        PngName = "Information"
        SP_OK.Visible = True


        Select Case Icon
            Case MessageBoxIcon.None
                PictureBox1.Visible = False
            Case MessageBoxIcon.Warning
                PngName = "Warning"
            Case MessageBoxIcon.Asterisk
                PngName = "Asterisk"
            Case MessageBoxIcon.Error
                PngName = "Error"
            Case MessageBoxIcon.Exclamation
                PngName = "Exclamation"
            Case MessageBoxIcon.Hand
                PngName = "Hand"
            Case MessageBoxIcon.Information
                PngName = "Information"
            Case MessageBoxIcon.Question
                PngName = "Question"
            Case MessageBoxIcon.Stop
                PngName = "Stop"
        End Select
        If PngName <> "" Then
            PictureBox1.Image = My.Resources.ResourceManager.GetObject("_" & PngName)
        Else
            PictureBox1.Visible = False
        End If

        Me.Show()
    End Sub

    Sub New(ByVal Msg As String, ByVal Title As String, ByVal Button1 As String, ByVal Button2 As String, ByVal Button3 As String, ByVal Button1Return As ConfirmBox.DeNoReturn, ByVal Button2Return As ConfirmBox.DeNoReturn, ByVal Button3Return As ConfirmBox.DeNoReturn, ByVal HideShadow As DeHideShadow)
        ' 此调用是设计器所必需的。
        InitializeComponent()

        ReturnMode = 3
        Me.ResultButton1 = Button1Return
        Me.ResultButton2 = Button2Return
        Me.ResultButton3 = Button3Return
        Me.ResultHideShadow = HideShadow
        ResultNoReturn = Button3Return
        Me.Text = Title
        Label1.Text = Msg
        MsButton = MsgBoxResult.Cancel
        Dim PngName As String = "Question"
        Result = MsgBoxResult.Cancel

        Sp_YesNoCancel.Visible = True
        ButtonY1.Text = Button1
        ButtonN1.Text = Button2
        ButtonC1.Text = Button3

        If PngName <> "" Then
            PictureBox1.Image = My.Resources.ResourceManager.GetObject("_" & PngName)
        Else
            PictureBox1.Visible = False
        End If
        Me.Show()
    End Sub

    Sub New(ByVal Msg As String, ByVal Title As String, ByVal YesReturn As DeNoReturn, ByVal NoReturn As DeNoReturn, ByVal HideShadow As DeHideShadow)
        ' 此调用是设计器所必需的。
        InitializeComponent()

        ReturnMode = 2
        Me.ResultNoReturn = YesReturn
        Me.NoReturn = NoReturn
        Me.ResultHideShadow = HideShadow
        Me.Text = Title
        Label1.Text = Msg
        MsButton = MsgBoxResult.Yes
        Dim PngName As String = "Question"
        Result = MsgBoxResult.No
        SP_YesNo.Visible = True
        If PngName <> "" Then
            PictureBox1.Image = My.Resources.ResourceManager.GetObject("_" & PngName)
        Else
            PictureBox1.Visible = False
        End If
        Me.Show()
    End Sub


    Sub New(ByVal Msg As String, ByVal Title As String, ByVal ResultReturn As DeNoReturn, Optional ByVal Icon As MessageBoxIcon = MessageBoxIcon.None)
        ' 此调用是设计器所必需的。
        InitializeComponent()

        ReturnMode = 0
        Me.ResultNoReturn = ResultReturn
        Me.Text = Title
        Label1.Text = Msg
        MsButton = MsgBoxResult.Ok
        Dim PngName As String = ""

        Result = MsgBoxResult.Ok
        PngName = "Information"
        SP_OK.Visible = True


        Select Case Icon
            Case MessageBoxIcon.None

            Case MessageBoxIcon.Warning
                PngName = "Warning"
            Case MessageBoxIcon.Asterisk
                PngName = "Asterisk"
            Case MessageBoxIcon.Error
                PngName = "Error"
            Case MessageBoxIcon.Exclamation
                PngName = "Exclamation"
            Case MessageBoxIcon.Hand
                PngName = "Hand"
            Case MessageBoxIcon.Information
                PngName = "Information"
            Case MessageBoxIcon.Question
                PngName = "Question"
            Case MessageBoxIcon.Stop
                PngName = "Stop"

        End Select
        If PngName <> "" Then
            PictureBox1.Image = My.Resources.ResourceManager.GetObject("_" & PngName)
        Else
            PictureBox1.Visible = False
        End If
        Me.Show()
    End Sub


    Sub New(ByVal Msg As String, ByVal Title As String, ByVal ResultReturn As DeReturn, ByVal HideShadow As DeHideShadow, ByVal ButtonTextY1 As String, ByVal ButtonTextN1 As String, ByVal ButtonTextC1 As String, Optional ByVal DefaultReturn As MsgBoxResult = MsgBoxResult.Yes)
        ' 此调用是设计器所必需的。
        InitializeComponent()

        ReturnMode = 1
        Me.ResultReturn = ResultReturn
        Me.ResultHideShadow = HideShadow
        Me.Text = Title
        Label1.Text = Msg
        MsButton = DefaultReturn
        Dim PngName As String = "Question"

        Result = DefaultReturn
        Sp_YesNoCancel.Visible = True
        ButtonY1.Text = ButtonTextY1
        ButtonN1.Text = ButtonTextN1
        ButtonC1.Text = ButtonTextC1
        If PngName <> "" Then
            PictureBox1.Image = My.Resources.ResourceManager.GetObject("_" & PngName)
        Else
            PictureBox1.Visible = False
        End If

        Me.Show()
    End Sub

    Private Sub ConfirmBox_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Me.Closing
        Me.Visible = False
        ' Me.Refresh()
        Select Case ReturnMode
            Case 0
                ResultHideShadow()
                ResultNoReturn()
            Case 1
                ResultHideShadow()
                ResultReturn(Result)
            Case 2
                ResultHideShadow()
                If Result = MsgBoxResult.Yes Or Result = MsgBoxResult.Ok Then
                    ResultNoReturn()
                Else
                    NoReturn()
                End If
            Case 3
                ResultHideShadow()
                ResultNoReturn()
        End Select
    End Sub

    Private Sub ButtonOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonOk.Click
        Result = MsgBoxResult.Ok
        Close()
    End Sub
    Private Sub ButtonY_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonY.Click
        If MsButton = MessageBoxButtons.OKCancel Then
            Result = MsgBoxResult.Ok
        Else
            Result = MsgBoxResult.Yes
        End If
        Close()
    End Sub

    Private Sub ButtonN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonN.Click
        If MsButton = MessageBoxButtons.OKCancel Then
            Result = MsgBoxResult.Cancel
        Else
            Result = MsgBoxResult.No
        End If
        Close()
    End Sub

    Private Sub ButtonC1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonC1.Click
        If ReturnMode = 3 Then
            ResultNoReturn = ResultButton3
        Else
            Result = MsgBoxResult.Cancel
        End If
        Close()
    End Sub

    Private Sub ButtonY1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonY1.Click
        If ReturnMode = 3 Then
            ResultNoReturn = ResultButton1
        Else
            Result = MsgBoxResult.Yes
        End If
        Close()
    End Sub

    Private Sub ButtonN1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonN1.Click
        If ReturnMode = 3 Then
            ResultNoReturn = ResultButton2
        Else
            Result = MsgBoxResult.No
        End If
        Close()
    End Sub



    Public Sub Active() Implements IViewForm.Active
        If Me.WindowState = FormWindowState.Minimized Then
            Me.WindowState = FormWindowState.Normal
            Me.Show()
        End If
        Me.Activate()
    End Sub



    Public Sub AddMu() Implements IViewForm.AddMu

    End Sub

    Public Property Child() As BaseForm Implements IViewForm.Child
        Get
            Return Nothing
        End Get
        Set(ByVal value As BaseForm)
        End Set
    End Property

    Public Sub Close1() Implements IViewForm.Close
        Me.Close()
    End Sub

    Public Event Closed1() Implements IViewForm.ClosedX

    Public Sub HideShadow() Implements IViewForm.HideShadow

    End Sub

    Public Sub ShowShadow() Implements IViewForm.ShowShadow

    End Sub
    Public Sub HideLoading() Implements IViewForm.HideLoading

    End Sub

    Public Sub ShowLoading(Optional ByVal ShowShadow As Boolean = True) Implements IViewForm.ShowLoading

    End Sub
    Public Property Text1() As String Implements IViewForm.Text
        Get
            Return Me.Text
        End Get
        Set(ByVal value As String)
            value = Me.Text
        End Set
    End Property

    Public Sub SetFormState(ByVal State As System.Windows.Forms.FormWindowState) Implements IViewForm.SetFormState
        Me.WindowState = State
    End Sub


    Private Sub ConfirmBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Control = True AndAlso e.KeyCode = Keys.C Then
            Clipboard.SetText(Label1.Text)
        End If
        Select Case e.KeyCode
            Case 13
                If Sp_YesNoCancel.Visible Then
                    ButtonY1_Click(sender, e)
                Else
                    ButtonOk_Click(sender, e)
                End If
                e.Handled = True
                e.SuppressKeyPress = False
            Case 8
                If Sp_YesNoCancel.Visible Then
                    ButtonN1_Click(sender, e)
                ElseIf SP_YesNo.Visible Then
                    ButtonN_Click(sender, e)
                End If
                e.Handled = True
                e.SuppressKeyPress = False
            Case 27
                ButtonC1_Click(sender, e)
                e.Handled = True
                e.SuppressKeyPress = False
        End Select
    End Sub

    Private Sub ConfirmBox_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Me.Icon = PClass.PClass.MainForm.icon
        Catch ex As Exception
        End Try
        IsLoad = True
        ColChange()
    End Sub


    Private Sub ConfirmBox_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        If IsLoad Then
            ButtonY.Left = (Me.Width - 10) / 2 - ButtonY.Width
            ButtonN.Left = (Me.Width + 10) / 2
            ButtonN1.Left = (Me.Width - ButtonN1.Width) / 2
            ButtonY1.Left = ButtonN1.Left - 10 - ButtonN1.Width
            ButtonC1.Left = ButtonN1.Left + 10 + ButtonN1.Width
            ButtonOk.Left = ButtonN1.Left
            Me.Left = (Screen.PrimaryScreen.WorkingArea.Width - Me.Width) / 2
            Me.Top = (Screen.PrimaryScreen.WorkingArea.Height - Me.Height) / 2
        End If
    End Sub

    Private Sub Label1_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label1.Resize
        ColChange()
    End Sub

    Sub ColChange()
        If IsLoad Then
            If PictureBox1.Visible = False Then
                Label1.Left = 10
                Label1.Top = 10
                Me.Height = Label1.Height + 88
            Else
                If Label1.Height < 15 Then
                    Label1.Top = 18
                    Me.Height = 120
                    If Sp_YesNoCancel.Visible = True Then
                        Me.MinimumSize = New Size(300, Me.MinimumSize.Height)
                    End If
                Else
                    Label1.Top = 10
                    Me.Height = Label1.Height + 100
                End If
                Label1.Left = 64
            End If
        End If
    End Sub

    Private Sub PictureBox1_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox1.VisibleChanged
        ColChange()
    End Sub

    Public Sub Form_KeyDownX(ByVal sender As Object, ByRef e As System.Windows.Forms.KeyEventArgs) Implements IViewForm.Form_KeyDownX

    End Sub

    Public Sub Form_KeyPressX(ByVal sender As Object, ByRef e As System.Windows.Forms.KeyPressEventArgs) Implements IViewForm.Form_KeyPressX

    End Sub


    Public ReadOnly Property IsShowShadow() As Boolean Implements IViewForm.IsShowShadow
        Get

        End Get
    End Property



End Class