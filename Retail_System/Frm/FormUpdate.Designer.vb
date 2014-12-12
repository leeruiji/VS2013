<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormUpdate
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormUpdate))
        Me.Cmd_DLL_Update = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label_NowVer = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label_DBVer = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label_DBDate = New System.Windows.Forms.Label
        Me.Label_PCLassDate = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label_PCLassVer = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label_PClassNowVer = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Cmd_Exe_Update = New System.Windows.Forms.Button
        Me.Cmd_PClass_Update = New System.Windows.Forms.Button
        Me.Cmd_CE_Update = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.CmdADDFJ = New System.Windows.Forms.Button
        Me.LabelMsg = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Cmd_BaseClass_Update = New System.Windows.Forms.Button
        Me.Label_BaseClassNowVer = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label_BaseCLassVer = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label_BaseCLassDate = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Fg1 = New PClass.FG
        Me.Fg2 = New PClass.FG
        Me.Cmd_Msg = New System.Windows.Forms.Button
        Me.Cmd_Bill = New System.Windows.Forms.Button
        CType(Me.Fg1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Fg2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Cmd_DLL_Update
        '
        Me.Cmd_DLL_Update.Location = New System.Drawing.Point(811, 4)
        Me.Cmd_DLL_Update.Name = "Cmd_DLL_Update"
        Me.Cmd_DLL_Update.Size = New System.Drawing.Size(80, 30)
        Me.Cmd_DLL_Update.TabIndex = 1
        Me.Cmd_DLL_Update.Text = "更新DLL"
        Me.Cmd_DLL_Update.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 12)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "当前主程序版本:"
        '
        'Label_NowVer
        '
        Me.Label_NowVer.AutoSize = True
        Me.Label_NowVer.ForeColor = System.Drawing.Color.Blue
        Me.Label_NowVer.Location = New System.Drawing.Point(113, 9)
        Me.Label_NowVer.Name = "Label_NowVer"
        Me.Label_NowVer.Size = New System.Drawing.Size(29, 12)
        Me.Label_NowVer.TabIndex = 3
        Me.Label_NowVer.Text = "1.00"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(149, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 12)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "系统版本:"
        '
        'Label_DBVer
        '
        Me.Label_DBVer.AutoSize = True
        Me.Label_DBVer.ForeColor = System.Drawing.Color.Blue
        Me.Label_DBVer.Location = New System.Drawing.Point(214, 9)
        Me.Label_DBVer.Name = "Label_DBVer"
        Me.Label_DBVer.Size = New System.Drawing.Size(29, 12)
        Me.Label_DBVer.TabIndex = 5
        Me.Label_DBVer.Text = "1.00"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(266, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(83, 12)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "最后更新时间:"
        '
        'Label_DBDate
        '
        Me.Label_DBDate.AutoSize = True
        Me.Label_DBDate.ForeColor = System.Drawing.Color.Blue
        Me.Label_DBDate.Location = New System.Drawing.Point(355, 9)
        Me.Label_DBDate.Name = "Label_DBDate"
        Me.Label_DBDate.Size = New System.Drawing.Size(29, 12)
        Me.Label_DBDate.TabIndex = 7
        Me.Label_DBDate.Text = "2009"
        '
        'Label_PCLassDate
        '
        Me.Label_PCLassDate.AutoSize = True
        Me.Label_PCLassDate.ForeColor = System.Drawing.Color.Blue
        Me.Label_PCLassDate.Location = New System.Drawing.Point(355, 30)
        Me.Label_PCLassDate.Name = "Label_PCLassDate"
        Me.Label_PCLassDate.Size = New System.Drawing.Size(29, 12)
        Me.Label_PCLassDate.TabIndex = 13
        Me.Label_PCLassDate.Text = "2009"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(266, 30)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(83, 12)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "最后更新时间:"
        '
        'Label_PCLassVer
        '
        Me.Label_PCLassVer.AutoSize = True
        Me.Label_PCLassVer.ForeColor = System.Drawing.Color.Blue
        Me.Label_PCLassVer.Location = New System.Drawing.Point(214, 30)
        Me.Label_PCLassVer.Name = "Label_PCLassVer"
        Me.Label_PCLassVer.Size = New System.Drawing.Size(29, 12)
        Me.Label_PCLassVer.TabIndex = 11
        Me.Label_PCLassVer.Text = "1.00"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(149, 30)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(59, 12)
        Me.Label10.TabIndex = 10
        Me.Label10.Text = "系统版本:"
        '
        'Label_PClassNowVer
        '
        Me.Label_PClassNowVer.AutoSize = True
        Me.Label_PClassNowVer.ForeColor = System.Drawing.Color.Blue
        Me.Label_PClassNowVer.Location = New System.Drawing.Point(113, 30)
        Me.Label_PClassNowVer.Name = "Label_PClassNowVer"
        Me.Label_PClassNowVer.Size = New System.Drawing.Size(29, 12)
        Me.Label_PClassNowVer.TabIndex = 9
        Me.Label_PClassNowVer.Text = "1.00"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(12, 30)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(95, 12)
        Me.Label12.TabIndex = 8
        Me.Label12.Text = "当前PClass版本:"
        '
        'Cmd_Exe_Update
        '
        Me.Cmd_Exe_Update.Location = New System.Drawing.Point(725, 39)
        Me.Cmd_Exe_Update.Name = "Cmd_Exe_Update"
        Me.Cmd_Exe_Update.Size = New System.Drawing.Size(79, 32)
        Me.Cmd_Exe_Update.TabIndex = 14
        Me.Cmd_Exe_Update.Text = "更新主程序"
        Me.Cmd_Exe_Update.UseVisualStyleBackColor = True
        '
        'Cmd_PClass_Update
        '
        Me.Cmd_PClass_Update.Location = New System.Drawing.Point(899, 3)
        Me.Cmd_PClass_Update.Name = "Cmd_PClass_Update"
        Me.Cmd_PClass_Update.Size = New System.Drawing.Size(79, 32)
        Me.Cmd_PClass_Update.TabIndex = 15
        Me.Cmd_PClass_Update.Text = "更新PClass"
        Me.Cmd_PClass_Update.UseVisualStyleBackColor = True
        '
        'Cmd_CE_Update
        '
        Me.Cmd_CE_Update.Location = New System.Drawing.Point(986, 3)
        Me.Cmd_CE_Update.Name = "Cmd_CE_Update"
        Me.Cmd_CE_Update.Size = New System.Drawing.Size(79, 32)
        Me.Cmd_CE_Update.TabIndex = 16
        Me.Cmd_CE_Update.Text = "更新CE系统"
        Me.Cmd_CE_Update.UseVisualStyleBackColor = True
        Me.Cmd_CE_Update.Visible = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(725, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(79, 32)
        Me.Button1.TabIndex = 17
        Me.Button1.Text = "附件列表"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'CmdADDFJ
        '
        Me.CmdADDFJ.Location = New System.Drawing.Point(812, 3)
        Me.CmdADDFJ.Name = "CmdADDFJ"
        Me.CmdADDFJ.Size = New System.Drawing.Size(79, 32)
        Me.CmdADDFJ.TabIndex = 19
        Me.CmdADDFJ.Text = "添加附件"
        Me.CmdADDFJ.UseVisualStyleBackColor = True
        Me.CmdADDFJ.Visible = False
        '
        'LabelMsg
        '
        Me.LabelMsg.AutoSize = True
        Me.LabelMsg.Font = New System.Drawing.Font("宋体", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LabelMsg.ForeColor = System.Drawing.Color.Red
        Me.LabelMsg.Location = New System.Drawing.Point(234, 280)
        Me.LabelMsg.Name = "LabelMsg"
        Me.LabelMsg.Size = New System.Drawing.Size(88, 24)
        Me.LabelMsg.TabIndex = 20
        Me.LabelMsg.Text = "Label2"
        Me.LabelMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.LabelMsg.Visible = False
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(498, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(23, 12)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "共:"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(497, 34)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 12)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "更新:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Cmd_BaseClass_Update
        '
        Me.Cmd_BaseClass_Update.Location = New System.Drawing.Point(812, 39)
        Me.Cmd_BaseClass_Update.Name = "Cmd_BaseClass_Update"
        Me.Cmd_BaseClass_Update.Size = New System.Drawing.Size(79, 32)
        Me.Cmd_BaseClass_Update.TabIndex = 23
        Me.Cmd_BaseClass_Update.Text = "更新BaseClass"
        Me.Cmd_BaseClass_Update.UseVisualStyleBackColor = True
        '
        'Label_BaseClassNowVer
        '
        Me.Label_BaseClassNowVer.AutoSize = True
        Me.Label_BaseClassNowVer.ForeColor = System.Drawing.Color.Blue
        Me.Label_BaseClassNowVer.Location = New System.Drawing.Point(113, 51)
        Me.Label_BaseClassNowVer.Name = "Label_BaseClassNowVer"
        Me.Label_BaseClassNowVer.Size = New System.Drawing.Size(29, 12)
        Me.Label_BaseClassNowVer.TabIndex = 25
        Me.Label_BaseClassNowVer.Text = "1.00"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(-2, 51)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(113, 12)
        Me.Label7.TabIndex = 24
        Me.Label7.Text = "当前BaseClass版本:"
        '
        'Label_BaseCLassVer
        '
        Me.Label_BaseCLassVer.AutoSize = True
        Me.Label_BaseCLassVer.ForeColor = System.Drawing.Color.Blue
        Me.Label_BaseCLassVer.Location = New System.Drawing.Point(214, 51)
        Me.Label_BaseCLassVer.Name = "Label_BaseCLassVer"
        Me.Label_BaseCLassVer.Size = New System.Drawing.Size(29, 12)
        Me.Label_BaseCLassVer.TabIndex = 27
        Me.Label_BaseCLassVer.Text = "1.00"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(149, 51)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(59, 12)
        Me.Label11.TabIndex = 26
        Me.Label11.Text = "系统版本:"
        '
        'Label_BaseCLassDate
        '
        Me.Label_BaseCLassDate.AutoSize = True
        Me.Label_BaseCLassDate.ForeColor = System.Drawing.Color.Blue
        Me.Label_BaseCLassDate.Location = New System.Drawing.Point(355, 51)
        Me.Label_BaseCLassDate.Name = "Label_BaseCLassDate"
        Me.Label_BaseCLassDate.Size = New System.Drawing.Size(29, 12)
        Me.Label_BaseCLassDate.TabIndex = 29
        Me.Label_BaseCLassDate.Text = "2009"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(266, 51)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(83, 12)
        Me.Label14.TabIndex = 28
        Me.Label14.Text = "最后更新时间:"
        '
        'Fg1
        '
        Me.Fg1.AllowEditing = False
        Me.Fg1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Fg1.AutoAddIndex = True
        Me.Fg1.AutoGenerateColumns = False
        Me.Fg1.AutoResize = False
        Me.Fg1.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.Fg1.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.XpThemes
        Me.Fg1.CanEditing = False
        Me.Fg1.ColumnInfo = resources.GetString("Fg1.ColumnInfo")
        Me.Fg1.EditFormat = True
        Me.Fg1.ExtendLastCol = True
        Me.Fg1.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Fg1.ForeColor = System.Drawing.Color.Black
        Me.Fg1.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.Fg1.IsAutoAddRow = True
        Me.Fg1.IsClickStartEdit = True
        Me.Fg1.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.Fg1.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.Fg1.Location = New System.Drawing.Point(3, 76)
        Me.Fg1.Name = "Fg1"
        Me.Fg1.Rows.Count = 10
        Me.Fg1.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.Fg1.Size = New System.Drawing.Size(1064, 549)
        Me.Fg1.StartCol = ""
        Me.Fg1.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("Fg1.Styles"))
        Me.Fg1.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.BelowData
        Me.Fg1.TabIndex = 30
        '
        'Fg2
        '
        Me.Fg2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Fg2.AutoAddIndex = True
        Me.Fg2.AutoGenerateColumns = False
        Me.Fg2.AutoResize = False
        Me.Fg2.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.Fg2.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.XpThemes
        Me.Fg2.CanEditing = False
        Me.Fg2.ColumnInfo = resources.GetString("Fg2.ColumnInfo")
        Me.Fg2.EditFormat = True
        Me.Fg2.ExtendLastCol = True
        Me.Fg2.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Fg2.ForeColor = System.Drawing.Color.Black
        Me.Fg2.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.Fg2.IsAutoAddRow = True
        Me.Fg2.IsClickStartEdit = True
        Me.Fg2.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.Fg2.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.Fg2.Location = New System.Drawing.Point(3, 76)
        Me.Fg2.Name = "Fg2"
        Me.Fg2.Rows.Count = 10
        Me.Fg2.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.Fg2.Size = New System.Drawing.Size(1064, 549)
        Me.Fg2.StartCol = ""
        Me.Fg2.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("Fg2.Styles"))
        Me.Fg2.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.BelowData
        Me.Fg2.TabIndex = 31
        '
        'Cmd_Msg
        '
        Me.Cmd_Msg.Location = New System.Drawing.Point(899, 39)
        Me.Cmd_Msg.Name = "Cmd_Msg"
        Me.Cmd_Msg.Size = New System.Drawing.Size(79, 32)
        Me.Cmd_Msg.TabIndex = 32
        Me.Cmd_Msg.Text = "通知所有人进行更新"
        Me.Cmd_Msg.UseVisualStyleBackColor = True
        '
        'Cmd_Bill
        '
        Me.Cmd_Bill.Location = New System.Drawing.Point(986, 38)
        Me.Cmd_Bill.Name = "Cmd_Bill"
        Me.Cmd_Bill.Size = New System.Drawing.Size(79, 32)
        Me.Cmd_Bill.TabIndex = 35
        Me.Cmd_Bill.Text = "单据类型"
        Me.Cmd_Bill.UseVisualStyleBackColor = True
        Me.Cmd_Bill.Visible = False
        '
        'FormUpdate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1071, 637)
        Me.Controls.Add(Me.Cmd_Bill)
        Me.Controls.Add(Me.Cmd_Msg)
        Me.Controls.Add(Me.LabelMsg)
        Me.Controls.Add(Me.Label_BaseCLassDate)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label_BaseCLassVer)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label_BaseClassNowVer)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Cmd_BaseClass_Update)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Cmd_CE_Update)
        Me.Controls.Add(Me.Cmd_PClass_Update)
        Me.Controls.Add(Me.Cmd_Exe_Update)
        Me.Controls.Add(Me.Label_PCLassDate)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label_PCLassVer)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label_PClassNowVer)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label_DBDate)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label_DBVer)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label_NowVer)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CmdADDFJ)
        Me.Controls.Add(Me.Cmd_DLL_Update)
        Me.Controls.Add(Me.Fg1)
        Me.Controls.Add(Me.Fg2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = Global.Retail_System.My.Resources.Resources.V3_Vis
        Me.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormUpdate"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "系统更新模块"
        CType(Me.Fg1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Fg2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Cmd_DLL_Update As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label_NowVer As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label_DBVer As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label_DBDate As System.Windows.Forms.Label
    Friend WithEvents Label_PCLassDate As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label_PCLassVer As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label_PClassNowVer As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Cmd_Exe_Update As System.Windows.Forms.Button
    Friend WithEvents Cmd_PClass_Update As System.Windows.Forms.Button
    Friend WithEvents Cmd_CE_Update As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents CmdADDFJ As System.Windows.Forms.Button
    Friend WithEvents LabelMsg As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Cmd_BaseClass_Update As System.Windows.Forms.Button
    Friend WithEvents Label_BaseClassNowVer As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label_BaseCLassVer As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label_BaseCLassDate As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Fg1 As PClass.FG
    Friend WithEvents Fg2 As PClass.FG
    Friend WithEvents Cmd_Msg As System.Windows.Forms.Button
    Friend WithEvents Cmd_Bill As System.Windows.Forms.Button
End Class
