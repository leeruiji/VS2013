Imports System.Data
Imports PClass
Imports BaseClass
Imports PClass.PClass
Imports System.Text

Public Class R30229_GSSQ_List
    Inherits CReport
    Dim comletedCount As Integer = 0
    Protected Const fileName As String = "R30229_GSSQ_List.grf"
    Dim FirstDate As Date
    Dim LastDate As Date


    Sub New()
        ReDim Dt_Header(1)
        ReportFile = fileName
    End Sub


    Sub Start(ByVal ID As String, ByVal DoOperator As OperatorType)
        Dim R As DtReturnMsg = Dao.GSSQ_SelListById(ID)
        If R.IsOk = False Then
            MsgBox(R.Msg)
            Exit Sub
        End If

        Dt_List = R.Dt

        R = Dao.GSSQ_SelById(ID)
        If R.IsOk = False Then
            MsgBox(R.Msg)
            Exit Sub
        End If
        R.Dt.Columns.Add("BC", GetType(String))
        If IsNull(R.Dt.Rows(0)("Banci"), False) = True Then
            R.Dt.Rows(0)("BC") = "甲班"
        Else
            R.Dt.Rows(0)("BC") = "乙班"
        End If
        Dt_Header(1) = R.Dt

        Me.DoOperator = DoOperator
        Me.DoWork()
    End Sub







End Class
#Region "数据库交换"

Partial Friend Class Dao
    ''' <summary>
    ''' 获取改色申请单
    ''' </summary>
    ''' <param name="sId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GSSQ_SelById(ByVal sId As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_GSSQ_SelByid, "@ID", sId)
    End Function


End Class


#End Region
