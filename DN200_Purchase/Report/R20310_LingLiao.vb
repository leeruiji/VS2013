Imports System.Data
Imports PClass
Imports BaseClass
Imports PClass.PClass
Imports System.Text
Public Class R20310_LingLiao
    Inherits CReport
    Dim comletedCount As Integer = 0

    Protected fileName As String = "R20310_StoreOut_LingLiao.grf"
    Dim FirstDate As Date
    Dim LastDate As Date
    Dim BType As BillType = BillType.LingLiao
    Dim IsFirst As Boolean
    Dim ID As String
    Sub New()
        ReDim Dt_Header(1)
    End Sub


    Sub Start(ByVal ID As String, ByVal DoOperator As OperatorType, Optional ByVal isFirst As Boolean = True)
        Me.IsFirst = isFirst
        Me.ID = ID
        Me.ReportFile = fileName
        Dim R As DtReturnMsg = Dao.LingLiao_SelListById(ID)
        If R.IsOk = False Then
            MsgBox(R.Msg)
            Exit Sub
        End If
        Dt_List = DtRunSQLtoDt(R.Dt, "Isnull(IsPageTwo,1)=" & IIf(isFirst, 0, 1))
        Dt_List.Columns.Add("StepStr")
        Dt_List.Columns.Add("StepTime")
        Dim S As Integer = 1
        Dim K As Integer = 0

        For i As Integer = 0 To Dt_List.Rows.Count - 1
            Dim Row As DataRow = Dt_List.Rows(i)
            If IsNull(Row("DyingStep"), "") <> "" Then
                For J As Integer = K To i
                    Dt_List.Rows(J).Item("StepStr") = S
                    Dt_List.Rows(J).Item("StepTime") = Dt_List.Rows(i).Item("DyingStep")
                Next
                S = S + 1
                K = i + 1
            End If
        Next

        R = Dao.LingLiao_SelById(ID)
        If R.IsOk = False Then
            MsgBox(R.Msg)
            Exit Sub
        End If
        R.Dt.Columns.Add("GY_Image", GetType(Byte()))

        R.Dt.Columns.Add("Title")
       
        If R.Dt.Rows.Count > 0 Then
            If IsNull(R.Dt.Rows(0)("IsJiaLiao"), False) = False Then
                R.Dt.Rows(0)("Title") = "领料单"
            Else
                R.Dt.Rows(0)("Title") = "加料单"
            End If


            If isFirst Then
                If IsNull(R.Dt.Rows(0).Item("GY_ID1"), 0) <> 0 Then
                    Dim Ri As DtReturnMsg = Dao.GY_GetById(IsNull(R.Dt.Rows(0).Item("GY_ID1"), 0))
                    If Ri.IsOk AndAlso Ri.Dt.Rows.Count > 0 Then
                        R.Dt.Rows(0)("GY_Image") = Ri.Dt.Rows(0).Item("GY_Image")
                    End If
                End If
            Else
                If IsNull(R.Dt.Rows(0).Item("GY_ID2"), 0) <> 0 Then
                    Dim Ri As DtReturnMsg = Dao.GY_GetById(IsNull(R.Dt.Rows(0).Item("GY_ID2"), 0))
                    If Ri.IsOk AndAlso Ri.Dt.Rows.Count > 0 Then
                        R.Dt.Rows(0)("GY_Image") = Ri.Dt.Rows(0).Item("GY_Image")
                    End If
                End If
            End If
        End If
        Dt_Header(1) = R.Dt
        Me.DoOperator = DoOperator
        Me.DoWork()
    End Sub



    Private Sub Report_PrintEnd() Handles Me.PrintEnd
        Dao.UpdatePrintState(ID, IsFirst)
    End Sub
End Class
#Region "数据库交换"

Partial Friend Class Dao

    Public Const SQL_GY_GetByID As String = "select top 1 * from T10004_GY where ID=@ID"
    Public Const ZHSQL_GY_GetByID As String = "select  * from T20310_LingLiao_Table where ID=@ID"
    Public Const PrintOneUpdate As String = "Update T20310_LingLiao_Table Set PrintOne=1 Where ID=@ID"
    Public Const PrintTwoUpdate As String = "Update T20310_LingLiao_Table Set PrintTwo=1 Where ID=@ID"

    ''' <summary>
    ''' 获取对采购单信息-打印用
    ''' </summary>
    ''' <param name="sId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function LingLiao_SelById(ByVal sId As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_LingLiao_SelByid, "@ID", sId)
    End Function



    ''' <summary>
    ''' 获取对采购单信息-打印用
    ''' </summary>
    ''' <param name="sId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ZHLingLiao_SelById(ByVal sId As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_LingLiao_SelByid, "@ID", sId)
    End Function


    ''' <summary>
    ''' 设置打印状态为已打印
    ''' </summary>
    ''' <param name="sId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function UpdatePrintState(ByVal sId As String, ByVal isFrist As Boolean) As MsgReturn
        If isFrist Then
            Return PClass.PClass.RunSQL(PrintOneUpdate, "@ID", sId)
        Else
            Return PClass.PClass.RunSQL(PrintTwoUpdate, "@ID", sId)
        End If
    End Function


    ''' <summary>
    ''' 获取工艺信息
    ''' </summary>
    ''' <param name="sId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GY_GetById(ByVal sId As Integer) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_GY_GetByID, "@Id", sId)
    End Function

End Class


#End Region