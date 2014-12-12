Imports PClass
Imports PClass.PClass
Public Class WinMaxForm
    Implements IViewForm
    Public ChObj As BaseForm
    Public WithEvents GridShadow As New PictureBox With {.Visible = False, .Dock = DockStyle.Fill}

    Sub New()
        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        ' 在 InitializeComponent() 调用之后添加任何初始化。
        Me.ShowInTaskbar = True
    End Sub

    Public Sub AddMu() Implements IViewForm.AddMu
        Me.Controls.Add(GridShadow)
        Me.Controls.Add(ChObj)
        ChObj.VForm = Me
        ChObj.Dock = DockStyle.Fill

    End Sub

    Public Shared Function SetTabFormOut(ByVal Tab As IViewForm) As WinMaxForm
        If Tab Is Nothing Then Return Nothing
        Dim VF As New WinMaxForm
        Dim Child As BaseForm = Tab.Child
        Tab.Child = Nothing
        VF.Text = Tab.Text

        VF.Width = Child.Width + 10
        VF.Height = Child.Height + 10
        VF.Child = Child
        Child.VForm = VF
        VF.AddMu()
        VF.Show()
        VF.Activate()
        Tab.Close()
        Return VF
    End Function

    Public Property Child() As BaseForm Implements IViewForm.Child
        Set(ByVal value As BaseForm)
            ChObj = Nothing
            ChObj = value
            If value IsNot Nothing Then
                If value.CanMaxSize Then
                    'Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
                    If value.AutoMax Then
                        'Me.WindowState = FormWindowState.Maximized
                    End If
                Else
                    Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedDialog
                    Me.MaximizeBox = False
                End If
            End If
        End Set
        Get
            Return ChObj
        End Get
    End Property

#Region "遮罩层"
    Public ReadOnly Property IsShowShadow() As Boolean Implements IViewForm.IsShowShadow
        Get
            Return GridShadow.Visible
        End Get
    End Property

    Public Sub HideLoading() Implements IViewForm.HideLoading
        GridShadow.Image = Nothing
        HideShadow()
    End Sub

    Public Sub ShowLoading(Optional ByVal ShowShadow As Boolean = True) Implements IViewForm.ShowLoading
        If IsShowShadow Then Exit Sub
        If ShowShadow Then
            Me.ShowShadow()
            GridShadow.SizeMode = PictureBoxSizeMode.CenterImage
        Else
            GridShadow.Visible = True
            GridShadow.BackColor = Color.White
            GridShadow.SizeMode = PictureBoxSizeMode.CenterImage
            GridShadow.Focus()
        End If
    End Sub

    Sub ShowShadow() Implements IViewForm.ShowShadow
        CaptureFromImageToPicture(Me, GridShadow)
        GridShadow.Visible = True
        GridShadow.Focus()
    End Sub

    Sub HideShadow() Implements IViewForm.HideShadow
        GridShadow.Visible = False
        Me.Update()
    End Sub
#End Region



    Private Sub ViewForm_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If Not ChObj Is Nothing Then ChObj.GetActive()
    End Sub

    Private Sub ViewForm_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Me.FormClosing
        If Not ChObj Is Nothing Then ChObj.Me_Closingx(sender, e)
    End Sub

    Private Sub ViewForm_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.FormClosed
        If Not ChObj Is Nothing Then ChObj.Me_Closedx()
        RaiseEvent ClosedX()
    End Sub

    Private Sub GridShadow_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridShadow.LostFocus
        If GridShadow.Visible = False Then GridShadow.Focus()
    End Sub

    Private Sub GridShadow_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles GridShadow.MouseDown
        If Not ChObj Is Nothing Then ChObj.GetActive()
    End Sub


    Private Sub Me_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        If Not ChObj Is Nothing Then ChObj.GetActive()
    End Sub



    Sub Active() Implements IViewForm.Active
        If Me.WindowState = FormWindowState.Minimized Then

            Me.WindowState = LastState
            Me.BringToFront()
            Me.Show()
        Else
            Me.BringToFront()
        End If
        Me.Activate()
    End Sub



    Public Sub Close1() Implements IViewForm.Close
        Me.Close()
    End Sub


    Public Property SetText() As String Implements IViewForm.Text
        Get
            Return Text
        End Get
        Set(ByVal value As String)
            Text = value
        End Set
    End Property

    Public Event ClosedX() Implements IViewForm.ClosedX

    Public Sub SetFormState(ByVal State As System.Windows.Forms.FormWindowState) Implements IViewForm.SetFormState
        Me.WindowState = State
    End Sub



#Region "KeyDown 和keyPress"
    Private Sub ViewForm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.Form_KeyDownX(sender, e)
    End Sub

    Public Sub Form_KeyDownX(ByVal sender As Object, ByRef e As System.Windows.Forms.KeyEventArgs) Implements IViewForm.Form_KeyDownX
        If Not ChObj Is Nothing Then
            ChObj.Form_KeyDownX(sender, e)
        End If
    End Sub



    Private Sub ViewForm_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Me.Form_KeyPressX(sender, e)
    End Sub

    Public Sub Form_KeyPressX(ByVal sender As Object, ByRef e As System.Windows.Forms.KeyPressEventArgs) Implements IViewForm.Form_KeyPressX
        If Not ChObj Is Nothing Then
            ChObj.Form_KeyPressX(sender, e)
        End If
    End Sub
#End Region

    Private Sub ViewForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If MainForm IsNot Nothing Then
            Me.Icon = MainForm.icon
        End If
    End Sub


    Sub ToMaxAndToMost()
        'T.Start()
        Me.Focus()
        Me.Activate()
    End Sub

    Private LastState As FormWindowState = FormWindowState.Normal
    Private Sub ViewForm_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Try
            If Me.WindowState <> FormWindowState.Minimized Then LastState = Me.WindowState
        Catch ex As Exception
        End Try
    End Sub


    Dim WithEvents T As New Timer With {.Interval = 1000}

    Private Sub T_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles T.Tick
        If Form.ActiveForm IsNot Me AndAlso Me.IsShowShadow = False Then
            Me.Active()
        End If
    End Sub
End Class
