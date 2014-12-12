Imports System.Data
Imports PClass.PClass
Imports System.Text
Imports System.ComponentModel
Imports System.IO


Public Class M880
    'Create Standalone SDK class dynamicly.
    Public axCZKEM1 As New zkemkeeper.CZKEM

    Private _Port As Int16



    '****************************************************************************************************
    '* Before you refer to this demo,we strongly suggest you read the development manual deeply first.  *
    '* This part is for demonstrating the communication with your device.                               *
    '* **************************************************************************************************


#Region "通信"
    Public bIsConnected = False 'the boolean value identifies whether the device is connected
    Public iMachineNumber As Integer 'the serial number of the device.After connecting the device ,this value will be changed.

    Public Function getConnectedState()
        Return bIsConnected
    End Function
    'If your device supports the TCP/IP communications, you can refer to this.
    'when you are using the tcp/ip communication,you can distinguish different devices by their IP address.
    Public Function ConnectAT(ByVal _Ip As String, ByVal _port As Integer, Optional ByVal _isDisConnect As Boolean = False) As MsgReturn
        Dim R As New MsgReturn
        Dim idwErrorCode As Integer
        Me._Port = _port
        If bIsConnected = False AndAlso _isDisConnect Then
            R.Msg = "连接已断开"
            R.IsOk = True
            Return R
        End If
        If _isDisConnect Then
            axCZKEM1.Disconnect()

            bIsConnected = False
            _isDisConnect = False
            R.Msg = "连接已断开"
            R.IsOk = True
            Return R
        End If

        bIsConnected = axCZKEM1.Connect_Net(_Ip, _port)
        If bIsConnected = True Then

            iMachineNumber = 0 'In fact,when you are using the tcp/ip communication,this parameter will be ignored,that is any integer will all right.Here we use 1.

            If axCZKEM1.RegEvent(iMachineNumber, 65535) = True Then 'Here you can register the realtime events that you want to be triggered(the parameters 65535 means registering all)



            End If
            R.Msg = "设备已连接"
            R.IsOk = True
        Else
            axCZKEM1.GetLastError(idwErrorCode)
            R.Msg = ("Unable to connect the device,ErrorCode=" & idwErrorCode)
        End If

        Return R

    End Function

    Public Sub CloseConnectAt()
        axCZKEM1.Disconnect()
    End Sub

#End Region
#Region "导入导出数据"
    Public Function ExportUserInfoTODB(ByVal BW As BackgroundWorker) As MsgReturn
        Dim sUserID As String = ""
        Dim sName As String = ""
        Dim sPassword As String = ""
        Dim iPrivilege As Integer
        Dim bEnabled As Boolean = False

        Dim iFaceIndex As Integer = 50 'the only possible parameter value
        Dim sTmpData As String = ""
        Dim iLength As Integer
        Dim err As Integer = 0
        Dim succ As Integer = 0
        Dim msg As New MsgReturn
        Dim sql As New StringBuilder()
        Dim st As String = ""



        axCZKEM1.EnableDevice(iMachineNumber, False)
        axCZKEM1.ReadAllUserID(iMachineNumber) 'read all the user information to the memory
        sql.Insert(0, "delete from IfaceData ")
        If RunSQL(sql.ToString).IsOk Then
            BW.ReportProgress(10, "数据库数据已清除，正在插入新用户记录，请勿断开连接。")
        End If

        Dim p As New Dictionary(Of String, Object)
        While axCZKEM1.SSR_GetAllUserInfo(iMachineNumber, sUserID, sName, sPassword, iPrivilege, bEnabled) = True  'get all the users' information from the memory
            sTmpData = ""
            If axCZKEM1.GetUserFaceStr(iMachineNumber, sUserID, iFaceIndex, sTmpData, iLength) = True Then 'get the face templates from the memory
                sql = New StringBuilder
                sql.AppendLine("insert into [IfaceData] ([UserID],[Name],[Password],[Privilege],[FaceIndex],[TmpData],[Length],Enable) values (")
                sql.AppendLine(sUserID & ",N'" & sName & "','" & IIf(sPassword Is Nothing, "", sPassword) & "'," & iPrivilege & "," & iFaceIndex & ",@TmpData," & iLength & ", " & IIf(bEnabled, 1, 0) & ")")
                p.Clear()
                If st = sTmpData Then
                    MsgBox(st)
                    MsgBox(sTmpData)
                End If
                st = sTmpData

                p.Add("TmpData", sTmpData)
                'lvItem = lvFace.Items.Add(sUserID)
                'lvItem.SubItems.Add(sName)
                'lvItem.SubItems.Add(sPassword)
                'lvItem.SubItems.Add(iPrivilege.ToString())
                'lvItem.SubItems.Add(iFaceIndex.ToString())
                'lvItem.SubItems.Add(sTmpData)
                'lvItem.SubItems.Add(iLength.ToString())
                'If bEnabled = True Then
                '    lvItem.SubItems.Add("true")
                'Else
                '    lvItem.SubItems.Add("false")
                'End If
                If RunSQL(sql.ToString, p).IsOk Then
                    succ = succ + 1

                Else
                    err = err + 1
                End If
                BW.ReportProgress(10, "发送记录总数:" & succ + err & ",失败数:" & err)
            End If
        End While
        'If sql.Length > 0 Then
        '    sql.Insert(0, "delete from IfaceData ")
        'End If

        axCZKEM1.EnableDevice(iMachineNumber, True)
        If err = 0 Then
            msg.IsOk = True
        End If
        msg.Msg = "成功[" & succ & "]条，失败[" & err & "]条"
        Return msg
    End Function

    

    Public Function ImportUserInfoFromDB(ByVal BW As BackgroundWorker)
        Dim sUserID As String = ""
        Dim sName As String = ""
        Dim iFaceIndex As Integer
        Dim iLength As Integer
        Dim sPassword As String = ""
        Dim iPrivilege As Integer
        Dim sTmpData As String = ""
        Dim sEnabled As String = ""
        Dim bEnabled As Boolean = False
        Dim Msg As New MsgReturn
        Dim idwErrorCode As Integer
        axCZKEM1.EnableDevice(iMachineNumber, False)
        Dim err As Integer = 0
        Dim succ As Integer = 0
        Dim R As DtReturnMsg = SqlStrToDt("select * from IfaceData order by UserID")

        If R.IsOk AndAlso R.Dt.Rows.Count > 0 Then



            For Each dr As DataRow In R.Dt.Rows
                sUserID = dr("UserID")
                sName = IsNull(dr("Name"), "")
                sPassword = IsNull(dr("Password"), "")
                iPrivilege = IsNull(dr("Privilege"), 0)
                iFaceIndex = IsNull(dr("FaceIndex"), 0) ' Convert.ToInt32(lvItem.SubItems(4).Text.Trim())
                sTmpData = IsNull(dr("TmpData"), "") '  lvItem.SubItems(5).Text.Trim()
                iLength = IsNull(dr("Length"), 0) 'Convert.ToInt32(lvItem.SubItems(6).Text.Trim())

                If sEnabled = "true" Then
                    bEnabled = True
                Else
                    bEnabled = False
                End If

                If axCZKEM1.SSR_SetUserInfo(iMachineNumber, sUserID, sName, sPassword, iPrivilege, bEnabled) Then 'upload user information to the device
                    axCZKEM1.SetUserFaceStr(iMachineNumber, sUserID, iFaceIndex, sTmpData, iLength) 'upload face templates information to the device
                    Msg.IsOk = True
                    succ = succ + 1

                Else
                    axCZKEM1.GetLastError(idwErrorCode)
                    Msg.Msg = ("Operation failed,ErrorCode=" & idwErrorCode.ToString())
                    axCZKEM1.EnableDevice(iMachineNumber, True)
                    err = err + 1
                    Return Msg
                End If
                BW.ReportProgress(10, "发送记录总数:" & succ + err & ",失败数:" & err)
            Next
        End If
        axCZKEM1.RefreshData(iMachineNumber) 'the data in the device should be refreshed
        axCZKEM1.EnableDevice(iMachineNumber, True)
        Return Msg
    End Function
#End Region
#Region "卡管理"


    'It is mainly for demonstrating how to download the cardnumber from the device.　
    'Card number is part of the user information.
    Public Function GetCards() As List(Of Card)
        Dim ld As New List(Of Card)
        If bIsConnected = False Then
            '   MsgBox("Please connect the device first", MsgBoxStyle.Exclamation, "Error")
            Return ld
        End If

        Dim sdwEnrollNumber As String = ""
        Dim sName As String = ""
        Dim sPassword As String = ""
        Dim iPrivilege As Integer
        Dim bEnabled As Boolean = False
        Dim sCardnumber As String = ""
        Dim c As Card

        axCZKEM1.EnableDevice(iMachineNumber, False) 'disable the device
        axCZKEM1.ReadAllUserID(iMachineNumber) 'read all the user information to the memory

        While axCZKEM1.SSR_GetAllUserInfo(iMachineNumber, sdwEnrollNumber, sName, sPassword, iPrivilege, bEnabled) = True 'get user information from memory
            '  If axCZKEM1.GetStrCardNumber(sdwEnrollNumber) = True Then 'get the card number from the memory
            c = New Card(sdwEnrollNumber)
            c.UserName = sName
            c.UserID = sdwEnrollNumber
            c.iPrivilege = iPrivilege
            c.password = sPassword
            c.isEnable = bEnabled
            ld.Add(c)

            ' End If
        End While

        axCZKEM1.EnableDevice(iMachineNumber, True) 'enable the device
        Return ld
    End Function
    'Upload the cardnumber as part of the user information　
    Public Function SetCard(ByVal _card As Card, Optional ByVal setCardNum As Boolean = False) As MsgReturn
        Dim R As New MsgReturn
        If bIsConnected = False Then
            R.Msg = "未能连接设备"
            Return R
        End If
        If _card.UserID = "" Or _card.CardNum.Trim() = "" Then
            R.Msg = ("UserID,Privilege,Cardnumber must be inputted first!")
            Return R
        End If
        Dim idwErrorCode As Integer



        'Dim sdwEnrollNumber As Integer = Val(_card.CardNum)
        'Dim sName As String = _card.UserName
        'Dim sPassword As String = _card.password
        'Dim iPrivilege As Integer = Card.iPrivilege
        'Dim sCardnumber As String = _card


        axCZKEM1.EnableDevice(iMachineNumber, False)
        If setCardNum Then
            axCZKEM1.SetStrCardNumber(_card.CardNum) 'Before you using function SetUserInfo,set the card number to make sure you can upload it to the device
        End If

        If axCZKEM1.SSR_SetUserInfo(iMachineNumber, _card.UserID, _card.UserName, _card.password, _card.iPrivilege, _card.isEnable) = True Then 'upload the user's information(card number included)
            R.Msg = "设置成功"
            R.IsOk = True

        Else
            axCZKEM1.GetLastError(idwErrorCode)
            MsgBox("Operation failed,ErrorCode=" & idwErrorCode.ToString(), MsgBoxStyle.Exclamation, "Error")
            R.Msg = "设置失败,ErrorCode=" & idwErrorCode.ToString()

        End If
        axCZKEM1.RefreshData(iMachineNumber) 'the data in the device should be refreshed
        axCZKEM1.EnableDevice(iMachineNumber, True)
        Return R
    End Function

    Public Sub ClearAdmin(ByVal iMachineNumber As String)
        If axCZKEM1.ClearAdministrators(iMachineNumber) = True Then
            axCZKEM1.RefreshData(iMachineNumber) 'the data in the device should be refreshed

        Else
            '  axCZKEM1.GetLastError(idwErrorCode)

        End If
    End Sub
    Public Function DeleteUser(ByVal sUserID As String, ByVal cbBackupDE As String)
        Dim idwErrorCode As Integer
        Dim R As New MsgReturn
        If bIsConnected = False Then
            R.Msg = "未能连接设备"
            Return R
        End If

        Dim iBackupNumber As Integer = Convert.ToInt32(cbBackupDE)


        axCZKEM1.EnableDevice(iMachineNumber, False)
        If axCZKEM1.SSR_DeleteEnrollData(iMachineNumber, sUserID, iBackupNumber) = True Then
            axCZKEM1.RefreshData(iMachineNumber) 'the data in the device should be refreshed
            R.Msg = ("DeleteEnrollData,UserID=" + sUserID + " BackupNumber=" + iBackupNumber.ToString())

        Else
            axCZKEM1.GetLastError(idwErrorCode)
            R.Msg = ("Operation failed,ErrorCode=" & idwErrorCode.ToString())
        End If
        Return R
    End Function

    Public Function ClearCards() As MsgReturn
        Dim R As New MsgReturn
        If bIsConnected = False Then
            R.Msg = ("Please connect the device first")
            Return R
        End If
        Dim idwErrorCode As Integer

        axCZKEM1.EnableDevice(iMachineNumber, False) 'disable the device
        If axCZKEM1.ClearData(iMachineNumber, 5) = True Then
            axCZKEM1.RefreshData(iMachineNumber) 'the data in the device should be refreshed
            R.Msg = ("All att Logs have been cleared from teiminal!")
            R.IsOk = True
        Else
            axCZKEM1.GetLastError(idwErrorCode)
            R.Msg = ("Operation failed,ErrorCode=" & idwErrorCode)
        End If

        axCZKEM1.EnableDevice(iMachineNumber, True) 'enable the device
        Return R
    End Function

   
    'Add the existed userid to DropDownLists.
    Dim bAddControl As Boolean = True

#End Region
#Region "打卡记录"
    ' **************************************************************************************************
    ' * Before you refer to this demo,we strongly suggest you read the development manual deeply first.*
    ' * This part is for demonstrating operations with(read/get/clear) the attendance records.         *
    ' * ************************************************************************************************
    'Download the attendance records from the device.
    Public Function GetLogData() As List(Of CardLog)
        Dim ld As New List(Of CardLog)
        Dim c As CardLog
        If bIsConnected = False Then
            Return ld
        End If

        Dim sdwEnrollNumber As String = ""
        Dim idwVerifyMode As Integer
        Dim idwInOutMode As Integer
        Dim idwYear As Integer
        Dim idwMonth As Integer
        Dim idwDay As Integer
        Dim idwHour As Integer
        Dim idwMinute As Integer
        Dim idwSecond As Integer
        Dim idwWorkcode As Integer

        Dim idwErrorCode As Integer
        Dim iGLCount = 0

        axCZKEM1.EnableDevice(iMachineNumber, False) 'disable the device
        If axCZKEM1.ReadGeneralLogData(iMachineNumber) Then 'read all the attendance records to the memory
            'get records from the memory

            While axCZKEM1.SSR_GetGeneralLogData(iMachineNumber, sdwEnrollNumber, idwVerifyMode, idwInOutMode, idwYear, idwMonth, idwDay, idwHour, idwMinute, idwSecond, idwWorkcode)
                iGLCount += 1
                '   lvItem = lvLogs.Items.Add(iGLCount.ToString())
                c = New CardLog(sdwEnrollNumber)
                c.idwVerifyMode = idwVerifyMode
                c.idwInOutMode = idwInOutMode
                c.dateStr = idwYear.ToString() & "-" + idwMonth.ToString() & "-" & idwDay.ToString() & " " & idwHour.ToString() & ":" & idwMinute.ToString() & ":" & idwSecond.ToString()
                c.idwWorkcode = idwWorkcode
                ld.Add(c)
            End While
            ClearLog()
        Else

            axCZKEM1.GetLastError(idwErrorCode)
            If idwErrorCode <> 0 Then
                MsgBox("Reading data from terminal failed,ErrorCode: " & idwErrorCode, MsgBoxStyle.Exclamation, "Error")
            Else
                MsgBox("No data from terminal returns!", MsgBoxStyle.Exclamation, "Error")
            End If
        End If

        axCZKEM1.EnableDevice(iMachineNumber, True) 'enable the device
        Return ld
    End Function
    'Get the count of attendance records in from ternimal.
    Public Function GetState() As MsgReturn
        Dim R As New MsgReturn
        If bIsConnected = False Then
            R.Msg = ("Please connect the device first")
            Return R
        End If
        Dim idwErrorCode As Integer
        Dim iValue = 0

        axCZKEM1.EnableDevice(iMachineNumber, False) 'disable the device
        If axCZKEM1.GetDeviceStatus(iMachineNumber, 6, iValue) = True Then 'Here we use the function "GetDeviceStatus" to get the record's count.The parameter "Status" is 6.
            R.Msg = ("The count of the AttLogs in the device is " + iValue.ToString())
            R.IsOk = True
        Else
            axCZKEM1.GetLastError(idwErrorCode)
            R.Msg = ("Operation failed,ErrorCode=" & idwErrorCode)
        End If

        axCZKEM1.EnableDevice(iMachineNumber, True) 'enable the device

        Return R
    End Function
    'Clear all attendance records from terminal.
    Public Function ClearLog() As MsgReturn
        Dim R As New MsgReturn
        If bIsConnected = False Then
            R.Msg = ("Please connect the device first")
            Return R
        End If
        Dim idwErrorCode As Integer

        axCZKEM1.EnableDevice(iMachineNumber, False) 'disable the device
        If axCZKEM1.ClearGLog(iMachineNumber) = True Then
            axCZKEM1.RefreshData(iMachineNumber) 'the data in the device should be refreshed
            R.Msg = ("All att Logs have been cleared from teiminal!")
            R.IsOk = True
        Else
            axCZKEM1.GetLastError(idwErrorCode)
            R.Msg = ("Operation failed,ErrorCode=" & idwErrorCode)
        End If

        axCZKEM1.EnableDevice(iMachineNumber, True) 'enable the device
        Return R
    End Function
#End Region
#Region "卡机色丁"

    Public Function GetPort()
        Return _Port
    End Function

    'Get the MAC Address of the device
    Public Function GetDeviceMAC() As MsgReturn
        Dim R As New MsgReturn
        If bIsConnected = False Then
            R.Msg = ("Please connect the device first")
            Return R
        End If
        Dim idwErrorCode As Integer

        Dim sMAC As String = ""

        If axCZKEM1.GetDeviceMAC(iMachineNumber, sMAC) = True Then
            R.Msg = sMAC
            R.IsOk = True
        Else
            axCZKEM1.GetLastError(idwErrorCode)
            R.Msg = ("Operation failed,ErrorCode=" & idwErrorCode.ToString())
        End If
        Return R
    End Function
    'Get the name of the manufacturer
    Public Function GetVendor() As MsgReturn
        Dim R As New MsgReturn
        If bIsConnected = False Then
            R.Msg = ("Please connect the device first")
            Return R
        End If
        Dim idwErrorCode As Integer

        Dim sVendor As String = ""

        If axCZKEM1.GetVendor(sVendor) = True Then
            R.Msg = sVendor
            R.IsOk = True
        Else
            axCZKEM1.GetLastError(idwErrorCode)
            R.Msg = ("Operation failed,ErrorCode=" & idwErrorCode.ToString())
        End If
        Return R
    End Function



    'Get the IP Address of the device
    Public Function GetDeviceIP() As MsgReturn
        Dim R As New MsgReturn
        If bIsConnected = False Then
            R.Msg = ("Please connect the device first")
            Return R
        End If
        Dim idwErrorCode As Integer

        Dim sIP As String = ""

        If axCZKEM1.GetDeviceIP(iMachineNumber, sIP) = True Then
            R.Msg = sIP
            R.IsOk = True
        Else
            axCZKEM1.GetLastError(idwErrorCode)
            R.Msg = ("Operation failed,ErrorCode=" & idwErrorCode.ToString())
        End If
        Return R
    End Function

    'Query the device's current state
    'Please refer to our development manual for more detailed parameters information.
    Public Function QueryState() As MsgReturn
        Dim R As New MsgReturn
        If bIsConnected = False Then
            R.Msg = ("Please connect the device first")
            Return R
        End If
        Dim idwErrorCode As Integer

        Dim iState As Integer

        If axCZKEM1.QueryState(iState) = True Then
            R.Msg = iState.ToString()
            R.IsOk = True
        Else
            axCZKEM1.GetLastError(idwErrorCode)
            R.Msg = ("Operation failed,ErrorCode=" & idwErrorCode.ToString())
        End If
        Return R
    End Function



    'Restart the device
    Public Function RestartDevice(ByVal sender As System.Object, ByVal e As System.EventArgs) As MsgReturn
        Dim R As New MsgReturn
        If bIsConnected = False Then
            R.Msg = ("Please connect the device first")
            Return R
        End If
        Dim idwErrorCode As Integer


        If axCZKEM1.RestartDevice(iMachineNumber) = True Then
            R.Msg = ("The device will restart!")
            R.IsOk = True
        Else
            axCZKEM1.GetLastError(idwErrorCode)
            R.Msg = ("Operation failed,ErrorCode=" & idwErrorCode.ToString())
        End If
        Return R
    End Function
    'Power off the device
    Public Function PowerOffDevice() As MsgReturn
        Dim R As New MsgReturn
        If bIsConnected = False Then
            R.Msg = ("Please connect the device first")
            Return R
        End If
        Dim idwErrorCode As Integer


        If axCZKEM1.PowerOffDevice(iMachineNumber) = True Then
            R.Msg = ("PowerOffDevice")
            R.IsOk = True
        Else
            axCZKEM1.GetLastError(idwErrorCode)
            R.Msg = ("Operation failed,ErrorCode=" & idwErrorCode.ToString())
        End If
        Return R
    End Function
    'Synchronize the device time as the computer's.
    Public Function SetDeviceTime() As MsgReturn
        Dim R As New MsgReturn
        If bIsConnected = False Then
            R.Msg = ("Please connect the device first")
            Return R
        End If
        Dim idwErrorCode As Integer


        If axCZKEM1.SetDeviceTime(iMachineNumber) = True Then
            axCZKEM1.RefreshData(iMachineNumber) 'the data in the device should be refreshed
            R.Msg = ("Successfully set the time of the machine and the terminal to sync PC!")
            Dim idwYear As Integer
            Dim idwMonth As Integer
            Dim idwDay As Integer
            Dim idwHour As Integer
            Dim idwMinute As Integer
            Dim idwSecond As Integer
            If axCZKEM1.GetDeviceTime(iMachineNumber, idwYear, idwMonth, idwDay, idwHour, idwMinute, idwSecond) Then 'show the time
                R.Msg = idwYear.ToString() + "-" + idwMonth.ToString() + "-" + idwDay.ToString() + " " + idwHour.ToString() + ":" + idwMinute.ToString() + ":" + idwSecond.ToString()
                R.IsOk = True
            End If
        Else
            axCZKEM1.GetLastError(idwErrorCode)
            R.Msg = ("Operation failed,ErrorCode=" & idwErrorCode.ToString())
        End If
        Return R
    End Function
    'Obtain the device' current time.
    Public Function GetDeviceTime() As MsgReturn
        Dim R As New MsgReturn
        If bIsConnected = False Then
            R.Msg = ("Please connect the device first")
            Return R
        End If
        Dim idwErrorCode As Integer

        Dim idwYear As Integer
        Dim idwMonth As Integer
        Dim idwDay As Integer
        Dim idwHour As Integer
        Dim idwMinute As Integer
        Dim idwSecond As Integer


        If axCZKEM1.GetDeviceTime(iMachineNumber, idwYear, idwMonth, idwDay, idwHour, idwMinute, idwSecond) = True Then
            axCZKEM1.RefreshData(iMachineNumber) 'the data in the device should be refreshed
            R.Msg = idwYear.ToString() + "-" + idwMonth.ToString() + "-" + idwDay.ToString() + " " + idwHour.ToString() + ":" + idwMinute.ToString() + ":" + idwSecond.ToString()
            R.IsOk = True
        Else
            axCZKEM1.GetLastError(idwErrorCode)
            R.Msg = ("Operation failed,ErrorCode=" & idwErrorCode.ToString())
        End If
        Return R
    End Function

#End Region

End Class

Public Class Card
    Public Sub New()

    End Sub
    Public Sub New(ByVal _cardNum As Integer)
        CardNum = _cardNum.ToString("0000000000")
    End Sub
    Public Sub New(ByVal _cardNum As String)
        CardNum = Val(_cardNum).ToString("0000000000")
    End Sub
    Public CardNum As String
    Public UserID As String
    Public UserName As String
    Public password As String
    Public iPrivilege As Integer = 0
    Public isEnable As Boolean



End Class

Public Class CardLog
    Public Sub New()

    End Sub
    Public Sub New(ByVal _cardNum As Integer)
        CardNum = _cardNum.ToString("0000000000")
    End Sub
    Public Sub New(ByVal _cardNum As String)
        CardNum = _cardNum
    End Sub
    Public CardNum As String
    Public idwVerifyMode As String
    Public idwInOutMode As String
    Public dateStr As String
    Public idwWorkcode As String

End Class
Module ModuleZKS
#Region "基础函数"
#Region "M880实例"
    Public M880_Instatnce As M880

#End Region

    Public Function ZKS_GetAtMachineTime(ByVal ipAddr As String, ByVal ipPort As Integer, ByVal clock_id As Short) As String




        If OpenPort(ipAddr, ipPort, clock_id) Then
            Dim R As MsgReturn = M880_Instatnce.GetDeviceTime()
            If R.IsOk Then
                ClosePort()
                Return R.Msg
            Else
                ClosePort()
                Return "不能读出设备的时间"
            End If
        Else
            Return "不能联接设备"
        End If
    End Function

    Public Function ZKS_SetAtMachineTime(ByVal ipAddr As String, ByVal ipPort As Integer, ByVal clock_id As Short) As String
        If OpenPort(ipAddr, ipPort, clock_id) Then

            If M880_Instatnce.SetDeviceTime().IsOk Then
                Return "设置时间成功"
            Else
                Return "设置时间失败"
            End If
            ClosePort()
        Else
            Return "不能联接设备"
        End If
    End Function




    Public FileName As String = AppPath + "\" + Format(Now, "yyyy-MM-dd") + ".txt"



#Region "卡记录"


    ''' <summary>
    ''' M880
    ''' </summary>
    ''' <param name="ipAddr"></param>
    ''' <param name="ipPort"></param>
    ''' <param name="clock_id"></param>
    ''' <param name="BW"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ZKS_LoadAtMachineCard(ByVal ipAddr As String, ByVal ipPort As Integer, ByVal clock_id As Short, ByVal BW As BackgroundWorker) As String
        Dim RecCount, ClockID, n, TotalRecNum, RecordNotRecviceNum

        Dim IsEmptyRecord As Boolean
        Dim result As String
        Dim OutData As New StringBuilder("", 912)
        Dim strLine As New StringBuilder
        '当前设备是否有记录，避免设备记录数刚好是16的倍数时造成系统提示无记录的现象
        IsEmptyRecord = True
        RecCount = 0
        TotalRecNum = 0
        RecordNotRecviceNum = 0
        n = 0

        ClockID = clock_id
        Dim Ds As String = ""
        Dim Id As String = ""
        Dim x As Integer = x

        BW.ReportProgress(1, "开始下载数据!")
        Try


            If OpenPort(ipAddr, ipPort, clock_id) Then


                Try


                    '   Do


                    ' ResultValue = GetLastErrCode()
                    'If ResultValue > 0 Then
                    '    If (n <= 10) Then

                    '        System.Threading.Thread.Sleep(250)
                    '        n = n + 1
                    '    Else
                    'result = MessageBox.Show("操作提示", "数据读取错,是否重试", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                    'If (result = DialogResult.Yes) Then
                    '    Style = Kind1
                    'ElseIf result = DialogResult.No Then
                    '    Style = Kind2
                    'ElseIf (result = DialogResult.Cancel) Then
                    '    Exit Do
                    '    n = 0
                    'End If
                    'n = 0
                    '    End If
                    'End If
                    'If ResultValue = -1 Then
                    '    If (IsEmptyRecord) Then

                    '        Exit Do
                    '    End If
                    'Else
                    '记录处理
                    IsEmptyRecord = False

                    Dim ld As List(Of CardLog) = M880_Instatnce.GetLogData
                    For Each c As CardLog In ld

                        Try

                            Id = Val(c.CardNum).ToString("0000000000")
                            Ds = c.dateStr ' Val(oneRecord(1)).ToString("0000-00-00 00:00:00")  ' CLng(Mid(Records, 1 + 10, 14)).ToString("0000-00-00 00:00:00")
                            strLine.AppendLine("if not(exists(select top 1 * from T15502_At_Data where card_id='" & Id & "' and Card_date='" & Ds & "' and at_id=" & clock_id & "))insert into T15502_At_Data(card_id,Card_date,at_id,ishandle,User_ID)Values('" & Id & "','" & Ds & "'," & clock_id & ",0,0)")
                            RecCount = RecCount + 1

                        Catch ex As Exception
                        End Try


                    Next


                    'n = 0
                    'End If
                    'If (RecCount >= TotalRecNum) Then

                    '    Exit Do
                    'End If
                    ' Loop While (sResult <> -1)
                    BW.ReportProgress(10, "下载记录总数:" & RecCount)


                    If RecCount > 0 Then
                        x = UploadCard(strLine.ToString)
                    End If
                Finally
                    ClosePort()

                    result = "下载记录总数:" & RecCount
                End Try

            Else
                result = "无法连接设备."
                Return result
            End If
        Catch ex As Exception

        End Try
        If RecCount > 0 Then
            BW.ReportProgress(11, "下载完成,共" & RecCount & "开始识别记录!")
            Dim RR As MsgReturn = SqlStrToOneStr("P15500_At_Data_Check")
            If RR.IsOk Then
                If Val(RR.Msg) > 0 Then
                    result = "下载记录总数:" & RecCount & RR.Msg & "条记录没有识别!"
                Else
                    result = "下载记录总数:" & RecCount & "全部记录都已经识别!"
                End If
            Else
                result = "下载记录总数:" & RecCount & "识别记录失败!"
            End If
        Else
            result = (CStr(clock_id) & " 号机内没有数据" & IIf(x = -1, ",打开数据库失败,数据已下载到文件,但没有保存到数据库!", ""))
        End If
        Return result

    End Function

    Function UploadCard(ByVal Str As String) As Integer
        Dim Sqlstr As String

        Try
            RunSQL(Str)
            If My.Computer.FileSystem.FileExists(FileName) Then
                Using Fs As New FileStream(FileName, FileMode.Open, FileAccess.Read)
                    Using Br As New StreamReader(Fs)
                        Sqlstr = Br.ReadToEnd
                        Br.Close()
                    End Using
                    Fs.Close()
                End Using
                If Sqlstr.Length > 0 Then RunSQL(Sqlstr)
                If My.Computer.FileSystem.FileExists(FileName) Then My.Computer.FileSystem.DeleteFile(FileName)
            End If
            Return 1
        Catch ex As Exception
            Using Fs As New FileStream(FileName, FileMode.Append, FileAccess.Write)
                Using Br As New StreamWriter(Fs)
                    Br.WriteLine(Str)
                End Using
            End Using
            Return -1
        End Try

    End Function

    Public Function ClearATLog(ByVal ipAddr As String, ByVal ipPort As Integer) As MsgReturn
        Dim R As New MsgReturn
        Try
            If OpenPort(ipAddr, ipPort, 0) Then

                M880_Instatnce.ClearLog()
                ClosePort()
                R.IsOk = True

            Else
                R.Msg = "无法连接机器."
            End If
        Catch ex As Exception
            R.Msg = ex.Message
        End Try
        Return R
    End Function
    Private Function OpenPort(ByVal ipAddr As String, ByVal ipPort As Integer, ByVal clock_id As Short) As Boolean
        ' SelectCommStyle(1)
        '  SetCommStyle(1)
        ' hPort = OpenClientSocket(ipAddr, ipPort)
        ' hPort = OpenClientSocket(ipAddr, ipPort, True)
        '  SetCmdVerify(True)
        'If CallClock(hPort, clock_id) Then
        '    OpenPort = True
        'Else
        '    OpenPort = False
        'End If
        'M880
        If M880_Instatnce Is Nothing Then
            M880_Instatnce = New M880
            Return M880_Instatnce.ConnectAT(ipAddr, ipPort).IsOk
        Else
            If M880_Instatnce.getConnectedState Then
                If Not ipAddr = M880_Instatnce.GetDeviceIP.Msg Then
                    M880_Instatnce.ConnectAT(M880_Instatnce.GetDeviceIP.Msg, ipPort, True)
                    M880_Instatnce.ConnectAT(ipAddr, ipPort)
                    Return True
                Else
                    Return True
                End If

            Else
                M880_Instatnce.ConnectAT(ipAddr, ipPort)
                Return True
            End If
        End If

    End Function

    Private Function ClosePort() As Boolean
        M880_Instatnce.ConnectAT(M880_Instatnce.GetDeviceIP.Msg, M880_Instatnce.GetPort, True)
    End Function

    'Public Function DelAtAllUser(ByVal ipAddr As String, ByVal ipPort As Integer, ByVal clock_id As Short) As Boolean
    '    For i As Integer = 1 To 3
    '        If OpenPort(ipAddr, ipPort, clock_id) Then
    '            Try
    '                '   DeleteAllAllowedCard(hPort)
    '                'DeleteFixCard(ipPort, clock_id, 0)
    '                ClosePort()

    '                Return True
    '            Catch ex As Exception
    '                ClosePort()
    '            End Try
    '        End If
    '    Next
    '    Return False
    'End Function
#End Region
    'Public M As New System.Text.StringBuilder
#Region "打卡名单"

    Public Sub ZKS_ClearAdmin(ByVal ipAddr As String, ByVal ipPort As Integer, ByVal clock_id As Short)
        If OpenPort(ipAddr, ipPort, clock_id) Then
            M880_Instatnce.ClearAdmin(clock_id)

        Else


        End If

    End Sub
    Public Function ZKS_SetAdmin(ByVal ipAddr As String, ByVal ipPort As Integer, ByVal clock_id As Short, ByVal BW As BackgroundWorker, ByVal Dt As DataTable, Optional ByVal isEnable As Boolean = True) As String
        '  M = New System.Text.StringBuilder
        Dim DataBuff As String = Space(2000)
        Dim Count As Integer = 0
        Dim ECount As Integer = 0
        ZKS_ErrList = Dt.Clone

        BW.ReportProgress(1, "开始发送名单!")
        Try

            For i As Integer = 0 To Dt.Rows.Count - 1
                If ZKS_SendAtMachineOneUser(ipAddr, ipPort, clock_id, Dt.Rows(i).Item("Employee_Name").ToString, Dt.Rows(i).Item("Employee_Card").ToString, 1) Then
                    Count += 1
                Else
                    ZKS_ErrList.ImportRow(Dt.Rows(i))
                    ECount += 1
                End If
                BW.ReportProgress(10, "发送记录总数:" & Count & ",失败数:" & ECount)
            Next

            Return "总数:" + CStr(Count) + "/已发送:" + CStr(Count) + "/失败:" + CStr(ECount)
        Catch ex As Exception
            Return "总数:" + CStr(Count) + "/已发送:" + CStr(Count) + "/失败:" + CStr(ECount)
        End Try
        ClosePort()
    End Function

    Public Function ZKS_SendAtMachineOneUser(ByVal ipAddr As String, ByVal ipPort As Integer, ByVal clock_id As Short, ByVal sName As String, ByVal ER_ID As String, ByVal _privilege As Integer, Optional ByVal isEnable As Boolean = True, Optional ByVal IsClosePort As Boolean = False) As Boolean
        '   M.AppendLine(hPort & vbTab & ER_ID & vbTab & sName)
        For i As Integer = 1 To 5
            Try
                If OpenPort(ipAddr, ipPort, clock_id) Then
                    If sName.Length > 4 Then
                        sName = sName.Substring(0, 4)
                    End If
                    Dim c As New Card(Val(ER_ID).ToString)
                    c.UserName = sName
                    c.UserID = Val(ER_ID).ToString
                    c.isEnable = isEnable
                    c.iPrivilege = _privilege

                    Dim R As MsgReturn = M880_Instatnce.SetCard(c, IIf(_privilege > 0, True, False))
                    If R.IsOk Then
                        If IsClosePort Then
                            ClosePort()
                        End If
                        Return True
                    End If
                    'If SetAllowedCard(hPort, ER_ID, "", sName) Then
                    '    ClosePort()
                    '    Return True
                    'End If
                    If IsClosePort Then
                        ClosePort()
                    End If
                End If
            Catch ex As Exception
            End Try
            Threading.Thread.Sleep(10)
        Next
        Return False
    End Function

    Public Function ZKS_DeleteAtMachineOneUser(ByVal ipAddr As String, ByVal ipPort As Integer, ByVal clock_id As Short, ByVal sName As String, ByVal ER_ID As String, Optional ByVal isClosePort As Boolean = False) As Boolean
        '   M.AppendLine(hPort & vbTab & ER_ID & vbTab & sName)
        For i As Integer = 1 To 5
            Try
                If OpenPort(ipAddr, ipPort, clock_id) Then
                    If sName.Length > 4 Then
                        sName = sName.Substring(0, 4)
                    End If

                    Dim R As MsgReturn = M880_Instatnce.DeleteUser(ER_ID, 0)
                    If R.IsOk Then
                        If isClosePort Then
                            ClosePort()
                        End If

                        Return True
                    End If
                    'If SetAllowedCard(hPort, ER_ID, "", sName) Then
                    '    ClosePort()
                    '    Return True
                    'End If
                    If isClosePort Then
                        ClosePort()
                    End If
                End If
            Catch ex As Exception
            End Try
            Threading.Thread.Sleep(10)
        Next
        Return False
    End Function

    Public Function ZKS_SendAtMachineName(ByVal ipAddr As String, ByVal ipPort As Integer, ByVal clock_id As Short, ByVal BW As BackgroundWorker) As String
        '   M = New System.Text.StringBuilder
        Dim DataBuff As String = Space(2000)
        Dim Count As Integer = 0
        Dim ECount As Integer = 0

        BW.ReportProgress(1, "删除原有的名单!")
        If ZKS_ClearATCards(ipAddr, ipPort).IsOk = False Then
            Return CStr(clock_id) & "号机联机失败"
        End If

        BW.ReportProgress(1, "开始发送名单!")
        Try
            Dim R As DtReturnMsg = SqlStrToDt("select ID,Employee_No,Employee_Name,isnull(Employee_Card,'') as Employee_Card from T15001_Employee where isnull(Employee_Card,'')<>'' and Employee_CardEndDate is null")
            ZKS_ErrList = R.Dt.Clone

            For i As Integer = 0 To R.Dt.Rows.Count - 1
                If ZKS_SendAtMachineOneUser(ipAddr, ipPort, clock_id, R.Dt.Rows(i).Item("Employee_Name").ToString, R.Dt.Rows(i).Item("Employee_Card").ToString, 0) Then
                    Count += 1
                Else
                    ZKS_ErrList.ImportRow(R.Dt.Rows(i))
                    ECount += 1
                End If
                BW.ReportProgress(10, "发送记录总数:" & Count & ",失败数:" & ECount)
            Next

            Return "总数:" + CStr(Count) + "/已发送:" + CStr(Count) + "/失败:" + CStr(ECount)
        Catch ex As Exception
            Return "总数:" + CStr(Count) + "/已发送:" + CStr(Count) + "/失败:" + CStr(ECount)
        End Try
        ClosePort()
    End Function

    Public Function ZKS_SendAtMachineName_Part(ByVal ipAddr As String, ByVal ipPort As Integer, ByVal clock_id As Short, ByVal BW As BackgroundWorker, ByVal Dt As DataTable, Optional ByVal isEnable As Boolean = True) As String
        '  M = New System.Text.StringBuilder
        Dim DataBuff As String = Space(2000)
        Dim Count As Integer = 0
        Dim ECount As Integer = 0
        ZKS_ErrList = Dt.Clone

        BW.ReportProgress(1, "开始发送名单!")
        Try
            '' Dim R As DtReturnMsg = SqlStrToDt("select ID,Employee_No,Employee_Name,isnull(Employee_Card,'') as Employee_Card from T15001_Employee where isnull(Employee_Card,'')<>'' and Employee_CardEndDate is null")


            For i As Integer = 0 To Dt.Rows.Count - 1
                If ZKS_SendAtMachineOneUser(ipAddr, ipPort, clock_id, Dt.Rows(i).Item("Employee_Name").ToString, Dt.Rows(i).Item("Employee_Card").ToString, 0) Then
                    Count += 1
                Else
                    ZKS_ErrList.ImportRow(Dt.Rows(i))
                    ECount += 1
                End If
                BW.ReportProgress(10, "发送记录总数:" & Count & ",失败数:" & ECount)
            Next

            Return "总数:" + CStr(Count) + "/已发送:" + CStr(Count) + "/失败:" + CStr(ECount)
        Catch ex As Exception
            Return "总数:" + CStr(Count) + "/已发送:" + CStr(Count) + "/失败:" + CStr(ECount)
        End Try
        ClosePort()
    End Function
    Public Function DeleteAtMachineName(ByVal ipAddr As String, ByVal ipPort As Integer, ByVal BW As BackgroundWorker) As String
        '  M = New System.Text.StringBuilder
        Dim DataBuff As String = Space(2000)


        BW.ReportProgress(1, "开始发送名单!")
        Try

            ZKS_ClearATCards(ipAddr, ipPort)
            Return "删除成功"
        Catch ex As Exception
            Return "删除失败"
        End Try
        ClosePort()
    End Function
    Public Function ZKS_DeleteAtMachineName_Part(ByVal ipAddr As String, ByVal ipPort As Integer, ByVal clock_id As Short, ByVal BW As BackgroundWorker, ByVal Dt As DataTable, Optional ByVal isEnable As Boolean = True) As String
        '  M = New System.Text.StringBuilder
        Dim DataBuff As String = Space(2000)
        Dim Count As Integer = 0
        Dim ECount As Integer = 0
        ZKS_ErrList = Dt.Clone

        BW.ReportProgress(1, "开始发送名单!")
        Try

            For i As Integer = 0 To Dt.Rows.Count - 1
                If ZKS_DeleteAtMachineOneUser(ipAddr, ipPort, clock_id, Dt.Rows(i).Item("Employee_Name").ToString, Dt.Rows(i).Item("Employee_Card").ToString) Then
                    Count += 1
                Else
                    ZKS_ErrList.ImportRow(Dt.Rows(i))
                    ECount += 1
                End If
                BW.ReportProgress(10, "发送记录总数:" & Count & ",失败数:" & ECount)
            Next

            Return "总数:" + CStr(Count) + "/已发送:" + CStr(Count) + "/失败:" + CStr(ECount)
        Catch ex As Exception
            Return "总数:" + CStr(Count) + "/已发送:" + CStr(Count) + "/失败:" + CStr(ECount)
        End Try
        ClosePort()
    End Function
    Public Function ZKS_DeleteAtLog(ByVal ipAddr As String, ByVal ipPort As Integer, ByVal BW As BackgroundWorker) As String
        '  M = New System.Text.StringBuilder
        Dim DataBuff As String = Space(2000)


        BW.ReportProgress(1, "开始发送名单!")
        Try

            ClearATLog(ipAddr, ipPort)
            Return "删除成功"
        Catch ex As Exception
            Return "删除失败"
        End Try
        ClosePort()
    End Function

    Public Function ZKS_GetATCards(ByVal ipAddr As String, ByVal ipPort As Integer) As List(Of Card)
        Dim ld As New List(Of Card)
        Try
            If OpenPort(ipAddr, ipPort, 0) Then

                ld = M880_Instatnce.GetCards
                ClosePort()
                Return ld
            Else
                Return New List(Of Card)
            End If
        Catch ex As Exception
            Return New List(Of Card)
        End Try
        Threading.Thread.Sleep(10)
    End Function

    Public Function ZKS_ClearATCards(ByVal ipAddr As String, ByVal ipPort As Integer) As MsgReturn
        Dim R As New MsgReturn
        Try
            If OpenPort(ipAddr, ipPort, 0) Then

                M880_Instatnce.ClearCards()
                ClosePort()
                R.IsOk = True

            Else
                R.Msg = "无法连接机器."
            End If
        Catch ex As Exception
            R.Msg = ex.Message
        End Try
        Return R
    End Function
#End Region

#Region "导出导入用户信息"
    Public Function ZKS_ExportUserinfo(ByVal ipAddr As String, ByVal ipPort As Integer, ByVal clock_id As Short, ByVal BW As BackgroundWorker) As String
        '   M = New System.Text.StringBuilder
        Dim DataBuff As String = Space(2000)
        Dim Count As Integer = 0
        Dim ECount As Integer = 0
        Dim msg As MsgReturn

        BW.ReportProgress(1, "开始发送名单!")
        Try

     
            If OpenPort(ipAddr, ipPort, 0) Then
                msg = M880_Instatnce.ExportUserInfoTODB(BW)
                If msg.IsOk Then
                    Return "导出成功"
                Else
                    Return "导出失败"
                End If
            Else
                Return "联机失败"
            End If
        Catch ex As Exception
            Return "联机失败"
        End Try
        ClosePort()
    End Function
    Public Function ZKS_ImportUserinfo(ByVal ipAddr As String, ByVal ipPort As Integer, ByVal clock_id As Short, ByVal BW As BackgroundWorker) As String
        '   M = New System.Text.StringBuilder
        Dim DataBuff As String = Space(2000)
        Dim Count As Integer = 0
        Dim ECount As Integer = 0
        Dim msg As MsgReturn

        BW.ReportProgress(1, "开始发送名单!")
        Try


            If OpenPort(ipAddr, ipPort, 0) Then
                msg = M880_Instatnce.ImportUserInfoFromDB(BW)
                If msg.IsOk Then
                    Return "导入成功"
                Else
                    Return "导入失败"
                End If
            Else
                Return "联机失败"
            End If
        Catch ex As Exception
            Return "联机失败"
        End Try
        ClosePort()
    End Function
#End Region



    Public ZKS_ErrList As DataTable
#End Region
End Module

