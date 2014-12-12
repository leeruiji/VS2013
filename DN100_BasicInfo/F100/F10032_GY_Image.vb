Imports PClass.PClass
Imports System.Data
Imports System.Text
Public Class F10032_GY_Image


    Public Sub New()

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。

    End Sub

    Public Sub New(ByVal img As Image)

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        PB_ImgBig.Image = img


    End Sub

    ''' <summary>
    ''' 权限获取
    ''' </summary>
    ''' <remarks></remarks>
    Sub FormCheckRight()

        Control_CheckRight(ID, ClassMain.Modify, Cmd_Modify)
        Control_CheckRight(ID, ClassMain.Del, Cmd_Del)
    End Sub


    Private Sub F10032_GY_Image_Load() Handles Me.Me_Load
        FormCheckRight()
        Dim F As Form = TryCast(Me.VForm, Form)
        If Not PB_ImgBig.Image Is Nothing Then
            F.Height = PB_ImgBig.Image.Height + 50 + Tool_Top.Height
            F.Width = PB_ImgBig.Image.Width + 10
            F.Left = (Screen.PrimaryScreen.WorkingArea.Width - F.Width) / 2
            F.Top = (Screen.PrimaryScreen.WorkingArea.Height - F.Height) / 2
        End If

        If F.Width > Screen.PrimaryScreen.WorkingArea.Width Or F.Height + 100 > Screen.PrimaryScreen.WorkingArea.Height Then

            F.WindowState = FormWindowState.Maximized
        End If

    End Sub

    ''' <summary>
    ''' 选择图片
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Btn_SelImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_SelImage.Click
        If Me.OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            PB_ImgBig.ImageLocation = OpenFileDialog1.FileName
            PB_ImgBig.Image = Image.FromFile(PB_ImgBig.ImageLocation)
            Me.Height = PB_ImgBig.Image.Height + 50
            Me.Width = PB_ImgBig.Image.Width + 10
        End If
    End Sub

    ''' <summary>
    ''' 保存图片
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_Modify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Modify.Click
        If Not PB_ImgBig.ImageLocation Is Nothing Then
            Me.LastForm.ReturnId = PB_ImgBig.ImageLocation
        End If
    End Sub

    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Close()
        Me.LastForm.ReturnId = ""
    End Sub

    Private Sub Cmd_Del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Del.Click
        PB_ImgBig.ImageLocation = ""
        Me.LastForm.ReturnId = ""
        Me.Close()
    End Sub
End Class
