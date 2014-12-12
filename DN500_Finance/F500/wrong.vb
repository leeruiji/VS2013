Imports PClass.PClass
Imports System.Data
Imports System.Text
Public Class wrong

    Dim dtJob As DataTable


    Dim WLName As String = ""

    Public Sub New()

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

    End Sub

    Public Sub New(ByVal DT As DataTable)

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        Me.dtJob = DT

    End Sub






    Private Sub wrong_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        FG1.DtToFG(dtJob)
    End Sub

    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Close1()
    End Sub
End Class