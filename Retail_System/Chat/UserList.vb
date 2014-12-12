Imports PClass.PClass
Imports Retail_System.ChatClient
Imports Retail_System.SystemIcon
Public Class UserList
    Public RetrunObj As Image

    Private Sub UserList_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Deactivate
        UserList_Move(Me, New EventArgs)
    End Sub
    Private Sub UserList_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        TimerHide.Stop()
        TimerShow.Stop()
        CloseUserList(False)
    End Sub


    Private Sub UserList_Move(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Move
        If Me.Top < 20 AndAlso Me.Top > -20 Then
            Me.Top = 0
            TimerHide.Start()
        ElseIf Me.Top < -20 Then
            TimerShow.Start()
        Else
            TimerHide.Stop()
            TimerShow.Stop()
        End If
    End Sub

    Private Sub UserList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = My.Resources.V3_Vis
        NotifyIcon1.Icon = My.Resources.V3_Vis
        NotifyIcon1.Text = My.Application.Info.Title
        LabelUserName.Text = UserName
        ImageList_Node.Images.Add("User_Gray", ImageToGray(ImageList_Node.Images("User")))
        CreateTreeView()
        GetList(Me, New EventArgs)
        If MeImageMd5 = "" Then
            PicHead.Image = My.Resources.PicHead
        Else
            CheckFaceImage(MeImageMd5, New DCheckFaceImage(AddressOf MyFaceImageLoad))
        End If
        GetAllFace()
        Me.TopMost = True
        Me.ShowInTaskbar = False
    End Sub


    Private Sub TimerShow_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerShow.Tick
        Try
            If Me.DisplayRectangle.Contains(Me.PointToClient(MousePosition)) Then
                Me.Top = 0
                TimerShow.Stop()

            ElseIf Me.Top < 20 AndAlso Me.Top > -20 Then
                Me.Top = 0
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub TimerHide_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerHide.Tick
        Try
            If Me.DisplayRectangle.Contains(Me.PointToClient(MousePosition)) = False Then
                If MouseButtons = Windows.Forms.MouseButtons.Left Then
                    Exit Sub
                End If
                Me.Top = 5 - Me.Height
                TimerHide.Stop()
            End If
        Catch ex As Exception

        End Try
    
    End Sub



#Region "头像加载"
    Sub MyFaceImageLoad(ByVal Md5 As String, ByVal IsOk As Boolean)
        If IsOk Then
            Try
                PicHead.Image = Image.FromFile(SystemFacePath & Md5 & ".png")
                PicHead.SizeMode = PictureBoxSizeMode.Normal
            Catch ex As Exception
                PicHead.Image = My.Resources.PicHead
            End Try
        Else
            PicHead.Image = My.Resources.PicHead
        End If
    End Sub

    Sub GetAllFace()
        Dim T As New Threading.Thread(AddressOf DGetAllFace) With {.IsBackground = True}
        T.Start()
    End Sub

    Sub DGetAllFace()
        Dim SQL As String = "select User_Name,Md5 from " & ChatUserSetting
        Dim msgUser As DtReturnMsg = PClass.PClass.SqlChatToDt(SQL)
        If msgUser.IsOk AndAlso msgUser.Dt.Rows.Count > 0 Then
            Dim D As New Dictionary(Of String, Image)
            Dim U As New Dictionary(Of String, String)
            For Each R As DataRow In msgUser.Dt.Rows
                If IsNull(R("Md5"), "") = "" Then
                    Continue For
                End If
                If IO.File.Exists(SystemFacePath & R("Md5") & ".png") = False Then
                    If LoadFace(R("Md5"), Nothing) = False Then
                        Continue For
                    End If
                End If
                Dim Img As Image = Image.FromFile(SystemFacePath & R("Md5") & ".png")
                Img = MakeSmallImg(Img, ImageList_Node.ImageSize.Width, ImageList_Node.ImageSize.Height)
                D.Add(R("Md5"), Img)
                D.Add(R("Md5") & "_Gray", ImageToGray(Img))
                U.Add(R("User_Name"), R("Md5"))
            Next
            Me.Invoke(New DFSetAllFaceList(AddressOf FSetAllFaceList), D, U)
            U.Clear()
            D.Clear()
        End If
    End Sub

    Delegate Sub DFSetAllFaceList(ByVal D As Dictionary(Of String, Image), ByVal U As Dictionary(Of String, String))
    Sub FSetAllFaceList(ByVal D As Dictionary(Of String, Image), ByVal U As Dictionary(Of String, String))
        For Each V As KeyValuePair(Of String, Image) In D
            If ImageList_Node.Images.ContainsKey(V.Key) = False Then
                ImageList_Node.Images.Add(V.Key, V.Value)
            End If
        Next
        UserMd5.Clear()
        For Each V As KeyValuePair(Of String, String) In U
            If ImageList_Node.Images.ContainsKey(V.Key) = False Then
                UserMd5.Add(V.Key, V.Value)
            End If
        Next
        GetUserList()
        GetList(Me, New EventArgs)
    End Sub


#End Region
 
#Region "查询数据"
    Public Function User_GetAll() As DtReturnMsg
        Dim sql As String = "select User_ID,User_Dept,U.User_Name,Dept_No,D.NodeLevel,D.NodeIndex,D.Dept_Name from User_Info U left join T15000_Department D on U.User_Dept=D.Dept_No WHERE Invalid<>1 order by  User_Dept, User_ID"
        Dim msgUser As DtReturnMsg = PClass.PClass.SqlStrToDt(sql)
        Return msgUser
    End Function


    Public Function Department_GetDeptAll() As DtReturnMsg
        Dim sql As String = "select * from T15000_Department order by Dept_No"
        Return PClass.PClass.SqlStrToDt(sql)
    End Function
#End Region



#Region "刷新"


    Sub GetList(ByVal sender As Object, ByVal e As EventArgs)

        GetAllOnlineList()
        If DtOnLine IsNot Nothing Then
            'For Each Row As DataRow In DtOnLine.Rows
            '    'Dim sNode As TreeNode
            '    If nodeUserIdMap.ContainsKey(Row("User_ID")) = False Then
            '        CreateTreeView()
            '        Try
            '            GetList(sender, e)
            '        Catch ex As Exception
            '        End Try
            '    Else
            '        nodeUserIdMap(Row("User_ID")).ToolTipText = nodeUserIdMap(Row("User_ID")).Text & "在线"
            '    End If
            'Next
            For Each Kv As KeyValuePair(Of String, String) In UserIdToUserName
                Dim eNode As TreeNode = nodeUserIdMap(Kv.Key)
                Dim OnLine As Boolean = False
                Dim GrayStr As String = ""
                If DtOnLine.Select("User_ID='" & Kv.Key & "'").Length > 0 Then
                    eNode.BackColor = Color.White
                    eNode.ForeColor = Color.Blue
                    eNode.ToolTipText = Kv.Value & "在线"
                    OnLine = True
                Else
                    eNode.ForeColor = Color.Gray
                    eNode.ToolTipText = Kv.Value & "离线"
                    eNode.BackColor = Color.White
                    GrayStr = "_Gray"
                    OnLine = False
                End If

                If UserMd5.ContainsKey(Kv.Value) Then
                    eNode.ImageKey = UserMd5(Kv.Value) & GrayStr
                    eNode.SelectedImageKey = eNode.ImageKey
                Else
                    eNode.ImageKey = "User" & GrayStr
                    eNode.SelectedImageKey = eNode.ImageKey
                End If


                Try
                    Dim F As Dialog = GetDialog(Kv.Value)
                    If F IsNot Nothing Then
                        F.IsOnline = OnLine
                    End If
                Catch ex As Exception
                End Try
            Next
        End If

        
    End Sub



    Sub GetUserList()
        CreateTreeView()
    End Sub
#End Region







#Region "生成树形菜单"
    Dim selectedDept As String = ""
    Dim nodeMap As New Dictionary(Of String, TreeNode)
    Public nodeUserIdMap As New Dictionary(Of String, TreeNode)

    Public UserNameToUserId As New Dictionary(Of String, String)
    Public UserIdToUserName As New Dictionary(Of String, String)

    Public UserMd5 As New Dictionary(Of String, String)
    Dim selectNode As TreeNode
    Dim DtUser As DataTable
    Dim DtDepts As DataTable
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub CreateTreeView()
        If DtDepts Is Nothing Then
            Dim msgDept As DtReturnMsg = Department_GetDeptAll()
            If msgDept.IsOk Then
                DtDepts = msgDept.Dt
            Else
                Exit Sub
            End If
        End If
        If DtUser Is Nothing Then
            Dim msgUser As DtReturnMsg = User_GetAll()
            If msgUser.IsOk Then
                DtUser = msgUser.Dt
            Else
                Exit Sub
            End If
        End If

        nodeMap.Clear()
        UserNameToUserId.Clear()
        UserIdToUserName.Clear()
        nodeUserIdMap.Clear()

        Dim root As New TreeNode

        root.Name = "D0"
        root.Text = "部门"
        root.ImageIndex = 0
        If selectedDept = root.Name Then
            selectNode = root
        End If
        nodeMap.Add(root.Name, root)
        root.Tag = Enum_HR.Department
        root.Expand()

        For Each dr In DtDepts.Select(" len (Dept_No)=4 ", "NodeLevel,NodeIndex")
            Dim nId As String = dr("Dept_No")
            Dim nName As String = dr("Dept_Name")
            Dim item As TreeNode = root.Nodes.Add(nName)
            item.Name = nId
            item.Text = nName
            If nId = selectedDept Then
                selectNode = item
            End If
            CreateUserNode(nId, item)
            nodeMap.Add(item.Name, item)

            For Each dr2 In DtDepts.Select(" len (Dept_No)>=7 and substring (Dept_No,1,4)='" & nId & "'", "NodeLevel,NodeIndex")
                CreateTreeItems(dr2("Dept_No"), dr2("Dept_Name"), item)
            Next
        Next

        Dim eNode As New TreeNode
        eNode.Name = "Admin"
        eNode.Text = "Admin"
        eNode.ToolTipText = "Admin"
        If UserMd5.ContainsKey("Admin") Then
            eNode.ImageKey = UserMd5("Admin") & "_Gray"
            eNode.SelectedImageKey = UserMd5("Admin") & "_Gray"
        Else
            eNode.ImageKey = "User_Gray"
            eNode.SelectedImageKey = "User_Gray"
        End If
        eNode.Tag = Enum_HR.User
        nodeMap("D0").Nodes.Add(eNode)
        nodeUserIdMap.Add(eNode.Name, eNode)
        UserNameToUserId.Add("Admin", "Admin")
        UserIdToUserName.Add("Admin", "Admin")

        TreeView_Dept.Nodes.Clear()
        TreeView_Dept.Nodes.Add(root)
        TreeView_Dept.SelectedNode = selectNode
        If Not selectNode Is Nothing Then
            'ChooseNode(selectNode)
        End If
        TreeView_Dept.ExpandAll()
    End Sub



    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="nodeName"></param>
    ''' <param name="nodeText"></param>
    ''' <param name="parentItem"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CreateTreeItems(ByVal nodeName As String, ByVal nodeText As String, ByVal parentItem As TreeNode) As TreeNode
        Dim MParentID As String = nodeName.Substring(0, nodeName.Length - 3)
        Dim p As TreeNode
        If nodeMap.ContainsKey(MParentID) Then
            p = nodeMap.Item(MParentID)
        Else
            Return Nothing
        End If
        If Not p Is Nothing Then
            Dim item As TreeNode = New TreeNode
            item.Name = nodeName
            item.Text = nodeText
            item.Tag = Enum_HR.Department
            If nodeName = selectedDept Then
                selectNode = item
                item.Checked = True
                item.Expand()
            End If
            nodeMap.Add(item.Name, item)
            p.Nodes.Add(item)
            CreateUserNode(nodeName, item)

            Return item
        Else
            Return Nothing
        End If

    End Function


    Protected Sub CreateUserNode(ByVal name As String, ByVal parentItem As TreeNode)
        Dim drsE As DataRow() = DtUser.Select("User_Dept='" & name & "'")
        For Each dr In drsE
            Dim eNode As New TreeNode
            eNode.Name = dr("User_ID")
            eNode.Text = dr("User_Name")
            eNode.ImageKey = "User_Gray"
            eNode.SelectedImageKey = "User_Gray"
            Dim GrayStr As String = "_Gray"
            If UserMd5.ContainsKey(dr("User_Name")) Then
                eNode.ImageKey = UserMd5(dr("User_Name")) & GrayStr
                eNode.SelectedImageKey = eNode.ImageKey
            Else
                eNode.ImageKey = "User" & GrayStr
                eNode.SelectedImageKey = eNode.ImageKey
            End If
            eNode.Tag = Enum_HR.User
            eNode.BackColor = Color.White
            nodeUserIdMap.Add(eNode.Name, eNode)
            UserIdToUserName.Add(dr("User_ID"), dr("User_Name"))
            UserNameToUserId.Add(dr("User_Name"), dr("User_ID"))
            eNode.ToolTipText = eNode.Text & "离线"
            If eNode.Name = selectedDept Then
                selectNode = eNode
            End If
            parentItem.Nodes.Add(eNode)
        Next
    End Sub
#End Region

    Public Enum Enum_HR
        User
        Employee
        Department
    End Enum

    Private Sub TreeView_Dept_NodeMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles TreeView_Dept.NodeMouseDoubleClick
        If e.Node.Tag = Enum_HR.User Then
            Try
                Dim F As Dialog = ShowChatDialog(e.Node.ToolTipText.Substring(0, e.Node.ToolTipText.Length - 2))
                F.IsOnline = Not e.Node.ToolTipText.EndsWith("离线")
            Catch ex As Exception
            End Try
        End If
    End Sub

#Region "闪动"
    Dim IconList As New Dictionary(Of String, Icon)
    Dim StrIcon_User As String = ""
    Dim StrIconGray_User As String = ""

    Private Sub TimerFlash_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerFlash.Tick

        Static T As Boolean
        T = Not T
        Dim NDate As Date = DateAdd(DateInterval.Second, TimeDiff, Now)
        TreeView_Dept.SuspendLayout()
        Dim StrIconKey As String = ""
        Dim StrIconGrayKey As String = ""
        StrIcon_User = ""
        StrIconGray_User = ""
        Try
            For Each U As UnReadMsgType In User_UnReadMsgList.Values
                Dim eNode As TreeNode = nodeUserIdMap(UserNameToUserId(U.User))
                Dim s As String = eNode.ToolTipText
                If s.EndsWith("离线") AndAlso U.LastTime.AddMilliseconds(ReceiveSleepTime * 2.5) > NDate Then
                    Dim Tx As New Threading.Thread(AddressOf ReFresh_UserList) With {.IsBackground = True}
                    Tx.Start()
                End If

                If U.Count > 0 Then
                    eNode.Text = U.User & "(" & U.Count & ")"
                    If T Then
                        Dim StrGray As String = ""
                        If s.EndsWith("离线") Then
                            eNode.ForeColor = Color.Gray
                            eNode.ToolTipText = U.User & "离线"
                            StrGray = "_Gray"
                        Else
                            eNode.ForeColor = Color.Blue
                            eNode.ToolTipText = U.User & "在线"
                        End If

                        If UserMd5.ContainsKey(U.User) Then
                            eNode.ImageKey = UserMd5(U.User) & StrGray
                            eNode.SelectedImageKey = eNode.ImageKey
                        Else
                            eNode.ImageKey = "User" & StrGray
                            eNode.SelectedImageKey = eNode.ImageKey
                        End If

                        If StrGray = "" Then
                            StrIconKey = eNode.ImageKey
                            StrIcon_User = U.User
                        Else
                            StrIconGrayKey = eNode.ImageKey
                            StrIconGray_User = U.User
                        End If
                    Else
                        eNode.ForeColor = Color.White
                        eNode.ImageKey = "Transparent"
                        eNode.SelectedImageKey = eNode.ImageKey
                        StrIconKey = eNode.ImageKey
                    End If


                Else
                    Dim StrGray As String = ""
                    If s.EndsWith("离线") Then
                        eNode.ForeColor = Color.Gray
                        eNode.ToolTipText = U.User & "离线"
                        StrGray = "_Gray"
                    Else
                        eNode.ForeColor = Color.Blue
                        eNode.ToolTipText = U.User & "在线"
                    End If
                    eNode.Text = U.User
                    If UserMd5.ContainsKey(U.User) Then
                        eNode.ImageKey = UserMd5(U.User) & StrGray
                        eNode.SelectedImageKey = eNode.ImageKey
                    Else
                        eNode.ImageKey = "User" & StrGray
                        eNode.SelectedImageKey = eNode.ImageKey
                    End If
                End If

            Next
            If T Then
                If StrIconKey <> "" Then
                    If IconList.ContainsKey(StrIconKey) = False Then
                        IconList.Add(StrIconKey, ImageToIcon(ImageList_Node.Images(StrIconKey)))
                    End If
                    NotifyIcon1.Icon = IconList(StrIconKey)
                    NotifyIcon1.Text = "收到[" & StrIcon_User & "]的信息"
                    NotifyIcon1.Tag = StrIcon_User
                ElseIf StrIconGrayKey <> "" Then
                    If IconList.ContainsKey(StrIconGrayKey) = False Then
                        IconList.Add(StrIconGrayKey, ImageToIcon(ImageList_Node.Images(StrIconGrayKey)))
                    End If
                    NotifyIcon1.Icon = IconList(StrIconGrayKey)
                    NotifyIcon1.Text = "收到[" & StrIconGray_User & "]的信息"
                    NotifyIcon1.Tag = StrIconGray_User
                Else
                    NotifyIcon1.Text = My.Application.Info.Title
                    NotifyIcon1.Tag = Nothing
                End If
            Else
                If StrIconKey <> "" Then
                    If IconList.ContainsKey(StrIconKey) = False Then
                        IconList.Add(StrIconKey, ImageToIcon(ImageList_Node.Images(StrIconKey)))
                    End If
                    NotifyIcon1.Icon = IconList(StrIconKey)
                Else
                    NotifyIcon1.Icon = My.Resources.V3_Vis
                    NotifyIcon1.Tag = Nothing
                End If
            End If

        Catch ex As Exception

        End Try


    End Sub
#End Region



#Region "头像设置"
    Private Sub PicHead_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicHead.Click
        Using F As New FormFaceSelect(PicHead.Image)
            RetrunObj = Nothing
            F.LastForm = Me
            F.ShowDialog()
            If RetrunObj IsNot Nothing Then
                Dim PicHeadPath As String = TempImgPath & RetrunObj.GetHashCode & Now.ToBinary & ".png"
                MakeSmallImg(RetrunObj, PicHeadPath, 48, 48)

                Dim Md5 As String = FileToMD5(PicHeadPath)
                IO.File.Move(PicHeadPath, SystemFacePath & Md5 & ".png")
                PicHeadPath = SystemFacePath & Md5 & ".png"
                PicHead.Image = Image.FromFile(PicHeadPath)
                PicHead.SizeMode = PictureBoxSizeMode.Normal
                MeImageByte = IO.File.ReadAllBytes(PicHeadPath)
                MeImageMd5 = Md5
                MeImage = PicHead.Image
                ChatClient.SaveSetting(SettingType.MeImage)
                If UserMd5.ContainsKey(UserName) Then
                    UserMd5(User_Name) = Md5
                    If ImageList_Node.Images.ContainsKey(Md5) = False Then
                        ImageList_Node.Images.Add(Md5, PicHead.Image)
                        ImageList_Node.Images.Add(Md5 & "_Gray", ImageToGray(PicHead.Image))
                    End If
                End If
                GetUserList()
                GetList(Me, New EventArgs)
            End If
        End Using
    End Sub
#End Region




   
 
   

    Private Sub Label2_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label2.DoubleClick
        GetAllFace()
    End Sub

    Public Sub NotifyIcon1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles NotifyIcon1.Click
        If NotifyIcon1.Tag IsNot Nothing Then
            ShowUnRead()
        Else
            TimerActivate.Start()
        End If
    End Sub

    Sub ShowUnRead()
        If NotifyIcon1.Tag IsNot Nothing Then
            Try
                Dim F As Dialog = ShowChatDialog(NotifyIcon1.Tag)
                F.IsOnline = Not nodeUserIdMap(UserNameToUserId(NotifyIcon1.Tag)).ToolTipText.EndsWith("离线")
            Catch ex As Exception
            End Try
        Else
            TimerActivate.Start()
        End If
    End Sub

   

    Private Sub TimerActivate_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerActivate.Tick
        TimerActivate.Stop()
        Me.Show()
        Me.Activate()
        Me.Top = 0
        Me.TimerHide.Stop()
        Me.WindowState = FormWindowState.Normal
        Me.Activate()
    End Sub
End Class