Imports System.Drawing
Imports System.Windows.Forms

<System.ComponentModel.ToolboxItem(False)> _
Public Class YearMonth
    Public _Parent As MonthPicker

    Private _YearForeColor As Color = Color.Black
    Private _MonthForeColor As Color = Color.Black

    Private _SeletYearForeColor As Color = Color.White
    Private _SeletYearBackColor As Color = Color.Blue
    Private _SeletMonthForeColor As Color = Color.White
    Private _SeletMonthBackColor As Color = Color.Blue
    Private _SeletTodayForeColor As Color = Color.Red


    Private ShowDate As Date


    Sub ChangeDate(ByVal Value As Date, Optional ByVal mustChange As Boolean = False)
        If Value.Year <> ShowDate.Year OrElse mustChange Then
            ChangeYear(Value)
        End If
        ChangeMonth(Value)
        ShowDate = Value
    End Sub

    Sub ChangeMonth(ByVal Value As Date)

        SetMonthColor(Month1, Value.Month)
        SetMonthColor(Month2, Value.Month)
        SetMonthColor(Month3, Value.Month)
        SetMonthColor(Month4, Value.Month)
        SetMonthColor(Month5, Value.Month)
        SetMonthColor(Month6, Value.Month)
        SetMonthColor(Month7, Value.Month)
        SetMonthColor(Month8, Value.Month)
        SetMonthColor(Month9, Value.Month)
        SetMonthColor(Month10, Value.Month)
        SetMonthColor(Month11, Value.Month)
        SetMonthColor(Month12, Value.Month)
        Dim T As Date = _Parent.ThisMonth
        If Value.Year = T.Year Then

            SetThisMonthColor(Month1, T.Month)
            SetThisMonthColor(Month2, T.Month)
            SetThisMonthColor(Month3, T.Month)
            SetThisMonthColor(Month4, T.Month)
            SetThisMonthColor(Month5, T.Month)
            SetThisMonthColor(Month6, T.Month)
            SetThisMonthColor(Month7, T.Month)
            SetThisMonthColor(Month8, T.Month)
            SetThisMonthColor(Month9, T.Month)
            SetThisMonthColor(Month10, T.Month)
            SetThisMonthColor(Month11, T.Month)
            SetThisMonthColor(Month12, T.Month)
        End If


    End Sub

    Sub SetThisMonthColor(ByVal L As Label, ByVal M As Integer)
        If L.Tag = M Then
            L.ForeColor = _SeletTodayForeColor
        End If
    End Sub

    Sub SetMonthColor(ByVal L As Label, ByVal M As Integer)
        If L.Tag = M Then
            L.ForeColor = _SeletMonthForeColor
            L.BackColor = _SeletMonthBackColor
        Else
            L.ForeColor = _MonthForeColor
            L.BackColor = Color.Transparent
        End If
    End Sub

    Sub ChangeYear(ByVal Value As Date)
        LabelYear3.Text = Value.Year + 3
        LabelYear2.Text = Value.Year + 2
        LabelYear1.Text = Value.Year + 1
        LabelYear_This.Text = Value.Year
        LabelYear_This.BackColor = _SeletYearBackColor
        LabelYear_1.Text = Value.Year - 1
        LabelYear_2.Text = Value.Year - 2
        LabelYear_3.Text = Value.Year - 3
        If Value.Year + 3 = _Parent.ThisMonth.Year Then
            LabelYear3.ForeColor = _SeletTodayForeColor
        Else
            LabelYear3.ForeColor = _YearForeColor
        End If
        If Value.Year + 2 = _Parent.ThisMonth.Year Then
            LabelYear2.ForeColor = _SeletTodayForeColor
        Else
            LabelYear2.ForeColor = _YearForeColor
        End If
        If Value.Year + 1 = _Parent.ThisMonth.Year Then
            LabelYear1.ForeColor = _SeletTodayForeColor
        Else
            LabelYear1.ForeColor = _YearForeColor
        End If

        If Value.Year = _Parent.ThisMonth.Year Then
            LabelYear_This.ForeColor = _SeletTodayForeColor
        Else
            LabelYear_This.ForeColor = _SeletYearForeColor
        End If

        If Value.Year - 1 = _Parent.ThisMonth.Year Then
            LabelYear_1.ForeColor = _SeletTodayForeColor
        Else
            LabelYear_1.ForeColor = _YearForeColor
        End If
        If Value.Year - 2 = _Parent.ThisMonth.Year Then
            LabelYear_2.ForeColor = _SeletTodayForeColor
        Else
            LabelYear_2.ForeColor = _YearForeColor
        End If
        If Value.Year - 3 = _Parent.ThisMonth.Year Then
            LabelYear_3.ForeColor = _SeletTodayForeColor
        Else
            LabelYear_3.ForeColor = _YearForeColor
        End If
    End Sub


    Function GetDate() As Date
        Return ShowDate
    End Function


#Region "事件实现"

    ''' <summary>
    ''' 点击本月
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Label_TheMonth_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label_TheMonth.Click
        ChangeDate(_Parent.ThisMonth)
    End Sub


    Private Sub Next_Last_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Next_Last.Click
        ChangeDate(ShowDate.AddYears(-1))
    End Sub

    Private Sub Cmd_Next_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Next.Click
        ChangeDate(ShowDate.AddYears(1))
    End Sub

    Private Sub LabelYear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LabelYear3.Click, LabelYear2.Click, LabelYear1.Click, LabelYear_3.Click, LabelYear_2.Click, LabelYear_1.Click
        ChangeDate(ShowDate.AddYears(CInt(sender.tag)))
    End Sub
    Private Sub LabelYear_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LabelYear_This.DoubleClick
        Cmd_OK_Click(sender, e)
    End Sub



    Private Sub Month_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Month9.Click, Month8.Click, Month7.Click, Month6.Click, Month5.Click, Month4.Click, Month3.Click, Month2.Click, Month12.Click, Month11.Click, Month10.Click, Month1.Click
        ChangeDate(New Date(ShowDate.Year, CInt(sender.tag), 1))
    End Sub

    Private Sub Month_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Month9.DoubleClick, Month8.DoubleClick, Month7.DoubleClick, Month6.DoubleClick, Month5.DoubleClick, Month4.DoubleClick, Month3.DoubleClick, Month2.DoubleClick, Month12.DoubleClick, Month11.DoubleClick, Month10.DoubleClick, Month1.DoubleClick
        ChangeDate(New Date(ShowDate.Year, CInt(sender.tag), 1))
        Cmd_OK_Click(sender, e)
    End Sub

    Private Sub Cmd_OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_OK.Click
        _Parent.Value = GetDate()
        _Parent.CloseToolTrip(True)
        _Parent.RaiseValueChange()
    End Sub

    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        _Parent.CloseToolTrip(True)
    End Sub

#End Region
  
End Class


