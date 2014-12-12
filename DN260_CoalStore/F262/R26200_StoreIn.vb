Imports System.Data
Imports PClass
Imports BaseClass
Imports PClass.PClass
Imports System.Text

Public Class R26200_StoreIn
    Inherits CReport
    Dim comletedCount As Integer = 0
    Protected fileName_Ohter As String = "R20200_StoreIn_Other.grf"
    Protected fileName_TuiLiao As String = "R20210_StoreIn_TuiLiao.grf"
    Dim FirstDate As Date
    Dim LastDate As Date


    Sub New()
        ReDim Dt_Header(1)

    End Sub


    Sub Start(ByVal ID As String, ByVal DoOperator As OperatorType, ByVal _StoreInType As Enum_StoreIn_Type)
        Select Case _StoreInType
            Case Enum_StoreIn_Type.Other
                Me.ReportFile = fileName_Ohter
            Case Enum_StoreIn_Type.TuiLiao
                Me.ReportFile = fileName_TuiLiao
            Case Else
                Me.ReportFile = fileName_Ohter


        End Select
        Dim R As DtReturnMsg = Dao.StoreIn_SelListById(ID)
        If R.IsOk = False Then
            MsgBox(R.Msg)
            Exit Sub
        End If
        Dt_List = R.Dt

        R = Dao.StoreIn_SelById(ID)
        If R.IsOk = False Then
            MsgBox(R.Msg)
            Exit Sub
        End If
        Dt_Header(1) = R.Dt

        Me.DoOperator = DoOperator
        Me.DoWork()
    End Sub







End Class
#Region "数据库交换"

Partial Friend Class Dao
    ''' <summary>
    ''' 获取对采购单信息-打印用
    ''' </summary>
    ''' <param name="sId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function StoreIn_SelById(ByVal sId As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_StoreIn_SelByid, "@ID", sId)
    End Function


End Class


#End Region
