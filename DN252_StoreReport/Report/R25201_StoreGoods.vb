﻿Imports System.Data
Imports PClass
Imports BaseClass
Imports PClass.PClass
Imports System.Text

Public Class R25201_StoreGoods
    Inherits CReport

    Dim comletedCount As Integer = 0

    Protected Const fileName As String = "R25201_StoreGoods.grf"
    Dim DoOperator As OperatorType
    Dim FirstDate As Date
    Dim LastDate As Date


    Sub New()
        ReDim Dt_Header(0)
        Dt_Header(0) = New System.Data.DataTable("T")
        ReportFile = fileName
    End Sub


    Sub Start(ByVal oList As OptionList)
        Dim msg As DtReturnMsg = GetByOption(oList)
        If msg.IsOk Then
            Me.Dt_List = msg.Dt
            Me.LoadReport()
        Else
            MsgBox("加载报表信息错误")
        End If
    End Sub


#Region "数据库交换"

    Public Const SQL As String = "select Goods_no,Goods_spec,Goods_thick,Batch_no,sum(piece)piece,sum(QTY)QTY,sum(Cpiece)Cpiece,sum(CQTY)CQTY " & vbCrLf & _
            ",(select top 1 Goods_Name from T10001_Goods G where  G.Goods_no=P.Goods_no ) as Goods_Name" & vbCrLf & _
            "from(select Goods_no,Product_spec as Goods_spec,Goods_thick,Batch_no,Product_piece piece,Product_Qty QTY,0.0 as Cpiece,0.0as CQTY" & vbCrLf & _
            "from T25001_Produce_List P" & vbCrLf & _
            "union all" & vbCrLf & _
            "select Goods_no,Goods_spec,Goods_thick,Batch_no,0,0,piece Cpiece,QTY CQTY " & vbCrLf & _
            "from T25101_StoreOut_List )P" & vbCrLf
    Public Const SQL_GroupBy As String = "group by Goods_no,Goods_spec,Goods_thick,Batch_no" & vbCrLf
    Public Const SQL_OrderBy As String = " Order by Goods_no,Goods_spec,Goods_thick,Batch_no " & vbCrLf


    ''' <summary>
    ''' 获取查询条件集合
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetConditionNames() As List(Of FindOption)
        Dim foList As New List(Of FindOption)
        Dim fo As New FindOption
        fo.Field = "请选择"
        fo.DB_Field = ""
        foList.Add(fo)

        'fo = New FindOption
        'fo.Field = "材料编号"
        'fo.DB_Field = "Goods_No"
        'foList.Add(fo)

        'fo = New FindOption
        'fo.Field = "材料名称"
        'fo.DB_Field = "Goods_Name"
        'foList.Add(fo)

        fo = New FindOption
        fo.Field = "批号"
        fo.DB_Field = "Batch_no"
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "规格"
        fo.DB_Field = "Goods_spec"
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "厚度"
        fo.DB_Field = "Goods_Thick"
        foList.Add(fo)
        Return foList
    End Function

    ''' <summary>
    ''' 获取查询条件集合
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetConditionDt(ByVal Field As String) As DataTable
        Dim R As DtReturnMsg
        Dim sql As String = ""
        Select Case Field
            Case "Goods_spec"
                R = BaseClass.Goods.GetGoods_Spec_DT
            Case "Goods_Thick"
                R = BaseClass.Goods.GetGoods_Thick_DT
            Case Else
                Return Nothing
        End Select
        If R.IsOk = True Then
            Return R.Dt
        Else
            Return Nothing
        End If
    End Function





    ''' <summary>
    ''' 按条件获取成品出库单列表
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetByOption(ByVal oList As OptionList) As DtReturnMsg
        Dim paraMap As New Dictionary(Of String, Object)
        Dim sqlBuider As New StringBuilder
        sqlBuider.Append(SQL)
        sqlBuider.Append("  WHERE 1=1  ")
        sqlBuider.Append(BaseClass.OptionClass.OptionClass_BuidSqlConditon(oList.FoList, paraMap))
        sqlBuider.Append(SQL_GroupBy)
        sqlBuider.Append(SQL_OrderBy)
        Return PClass.PClass.SqlStrToDt(sqlBuider.ToString, paraMap)
    End Function
#End Region





    Sub DoWork()
        Select Case DoOperator
            Case OperatorType.Print
                Me.Print(True)
            Case OperatorType.Preview
                Me.PrintPreview()
            Case OperatorType.ExportDirect
                Me.ExportDirect(ExportType.gretXLS)
        End Select
    End Sub




End Class
