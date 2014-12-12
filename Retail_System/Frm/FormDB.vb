Imports PClass.PClass

Public Class FormDB
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim x As New CSaveXml
        If LoadCXml(x) Then
            T_DB.Text = x.MDB
            T_IP.Text = x.MIP
            T_Pwd.Text = DeDes(x.MPassword, AppDes)
            T15002_User.Text = x.MUserId
        End If
    End Sub

    Private Sub CmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSave.Click
        Save()

    End Sub

    Sub Save()
        Dim X As New CSaveXml
        X.MDB = T_DB.Text
        X.MIP = IIf(T_IP.Text.Trim = "192.168.19.240", "192.168.16.10", T_IP.Text)
        X.MPassword = EnDes(T_Pwd.Text, AppDes)
        X.MUserId = T15002_User.Text
        X.Printer_Tm = Printer_Tm
        X.Printer_A4 = Printer_A4
        X.Printer_SaleNo = Printer_SaleNo
        X.Printer_SalePrepare = Printer_SalePrepare
        X.WBaudRate = WBaudRate
        X.WCom = WCom


        X.Tm_PrintOffsetX = Tm_PrintOffsetX
        X.Tm_PrintOffsetY = Tm_PrintOffsetY

        X.SalePrepare_PrintOffsetX = SalePrepare_PrintOffsetX
        X.SalePrepare_PrintOffsetY = SalePrepare_PrintOffsetY

        X.SaleNo_PrintOffsetX = SaleNo_PrintOffsetX
        X.SaleNo_PrintOffsetY = SaleNo_PrintOffsetY

        X.A4_PrintOffsetX = A4_PrintOffsetX
        X.A4_PrintOffsetY = A4_PrintOffsetY






        Dim sfFormatter As New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter
        'BinaryFormatter是进行二进制序列化的。其它的序列化方式你可以在Runtime.Serialization.Formatters中找到。
        '我们还要有一个流来作为序列化的输出:
        Dim fStream As New IO.FileStream(AppPath & "Csx.dat", IO.FileMode.Create)
        '准备工作完了, 现在可以调用Formatter的Serialize方法来进行序列化了
        sfFormatter.Serialize(fStream, X)
        '最后不要忘了关闭流:
        fStream.Close()
        DB_Set = True
        Close()
    End Sub

    Private Sub CmdEnd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdEnd.Click

        DB_Set = False
        Close()
    End Sub

    Private Sub T_IP_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles T_IP.KeyPress
        If e.KeyChar = vbCr Then
            'T_DB.SelectAll()
            T_DB.Focus()
        End If
    End Sub

    Private Sub T_DB_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles T_DB.KeyPress
        If e.KeyChar = vbCr Then
            'T_DB.SelectAll()
            T15002_User.Focus()
        End If
    End Sub

    Private Sub T15002_User_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles T15002_User.KeyPress
        If e.KeyChar = vbCr Then
            'T_DB.SelectAll()
            T_Pwd.Focus()
        End If
    End Sub

    Private Sub T_Pwd_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles T_Pwd.KeyPress
        If e.KeyChar = vbCr Then
            'T_DB.SelectAll()
            Save()
        End If
    End Sub





End Class