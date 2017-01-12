Imports Modulo
Imports System.Xml
Imports System.Globalization
Imports System.IO
Imports System.Data
Imports ConectaClass
Partial Class View_Ventas_Orden
    Inherits System.Web.UI.Page
    Public ws As DIS.DIServer
    Dim Grupo As String
    Dim Articulo As String
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Session.Timeout = 20
        'actualizacarritochiquito()
        If Not Page.IsPostBack Then
            DropDownList1.Visible = False
            'Busqueda de facturas venciadas Balance
            Dim tRow As New TableRow()
            Dim tCell As New TableCell()
            ws = New DIS.DIServer
            ws.Url = Serveriii
            Try
                Dim valor As String = ""
                Dim texto As String = ""
                Dim Respuesta As XmlNode
                '--Revision de almacen a comprar
                Respuesta = ws.SBObob(Session("Token"), "GetWareHouseList", "", "")
                Dim doc2 As New XmlDocument()
                doc2.LoadXml(Respuesta.InnerXml)
                System.Diagnostics.Debug.Write(Respuesta.InnerXml & vbCrLf)
                Dim root2 As XmlNode = doc2.FirstChild
                Dim rootin As XmlNode
                root2 = root2.LastChild
                'root2 = root2.FirstChild 
                If root2.HasChildNodes Then
                    Dim s As Integer
                    For s = 0 To root2.ChildNodes.Count - 1
                        rootin = root2.ChildNodes(s)
                        If rootin.HasChildNodes Then
                            Dim x As Integer
                            tRow = New TableRow()
                            For x = 0 To rootin.ChildNodes.Count - 1
                                Select Case rootin.ChildNodes(x).Name
                                    Case "WarehouseName"
                                        txtwharehouse.Value = rootin.ChildNodes(x).InnerText
                                        x = rootin.ChildNodes.Count - 1
                                        s = root2.ChildNodes.Count - 1
                                End Select
                            Next x
                            'DropDownList1.Items.Insert(s, txtwharehouse.Value) 
                        End If
                    Next s
                End If

                Session("busqueda") = ""
                Session("pagIni") = 1
                'buscarFinale()
                'CargaArticulos()
                LoadString()
                Catalogo()
            Catch ex As Exception
            End Try
        End If
    End Sub
    Dim Respuesta As XmlNode
    ' Protected Sub btnbuscar_ServerClick(sender As Object, e As EventArgs) Handles btnbuscar.ServerClick
    '    Session("busqueda") = barrabusqueda.Value
    '   Session("pagIni") = 1
    '  buscarFinale()

    'End Sub
    Dim pattern As String = " "
    Dim elements() As String

    Public Sub LoadString()
        '//**Creacion 09/01/2017**//
        '---Funcion Obtener String url
        If Request.QueryString("Grupo") <> "" Then
            Grupo = Request.QueryString("Grupo")
        Else
            If Request.QueryString("Articulo") <> "" Then
                Articulo = Request.QueryString("Articulo")
            End If
        End If
    End Sub

    Public Sub Catalogo()
        '//**Creacion 03/01/2017**//
        '//Update 11/01/2017
        '---Funcion cargar catalogo de articulos
        Dim today As Date = DateTime.Now
        Dim fechastring = today.ToString("yyyyMMdd")
        Dim encontrados As Integer = 0
        Dim wharehose As String = txtwharehouse.Value
        Dim tRow As New TableRow()
        Dim tCell As New TableCell()
        Try
            Respuesta = ws.ExecuteSQL(Session("Token"), "select Rate from ORTT where RateDate = CONVERT (date, GETDATE()) ")
            Session("usdrate") = ReadXML(Respuesta.InnerXml, "rate")
            If Session("usdrate") > 0 Then
                '--Consulta SQL articulos eh imagen
                Dim sqldato As String = "Select Y0.ItemCode,Y0.ItemName,Y0.imag From " &
                                        "(SELECT SUM(T0.OnHand)+SUM(T0.IsCommited) as 'Existencia',t1.ItemCode,t1.ItemName,ISNULL(CONVERT(VARCHAR(MAX), T2.ImagenBase ),'') as 'imag' " &
                                        "FROM OITW T0 " &
                                        "INNER JOIN OITM T1 ON T0.ItemCode=T1.ItemCode " &
                                        "left join EcommerceSF.dbo.TAAE T2 On (T2.ItemCode=T0.ItemCode) "
                If Articulo <> "" Then
                    sqldato = sqldato + "where T0.WhsCode between '01' and '04' and t1.validFor='Y' and T1.U_IL_iva is not null AND T1.ItemName like '%" & Articulo & "%' "
                Else
                    If Grupo <> "" Then
                        sqldato = sqldato + "where T0.WhsCode between '01' and '04' and t1.validFor='Y' and T1.U_IL_iva is not null AND T1.ItmsGrpCod='" & Grupo & "' "
                    Else
                        sqldato = sqldato + "where T0.WhsCode between '01' and '04' and t1.validFor='Y' and T1.U_IL_iva is not null "
                    End If
                End If


                sqldato = sqldato + "GROUP BY T1.ItemCode,T1.ItemName,CONVERT(VARCHAR(MAX), T2.ImagenBase))AS Y0 "
                sqldato = sqldato + "where y0.Existencia>0 ORDER BY Existencia"
                '---Revisar almacen por default para que no tome material que no sea del almacen fijado
                '---Tabla temporal
                Dim DataTable As New DataTable()
                DataTable.Columns.AddRange(New DataColumn() {New DataColumn("Col1", GetType(Integer)),
                                                       New DataColumn("Col2", GetType(String)),
                                                       New DataColumn("codigo", GetType(String)),
                                                       New DataColumn("nombre", GetType(String)),
                                                       New DataColumn("cosa", GetType(String)),
                                                       New DataColumn("ProfilePicture", GetType(String))})
                cnn.Open()
                cmd = New SqlClient.SqlCommand(sqldato, cnn)
                dr = cmd.ExecuteReader()
                '--------->Recorrer todos los registros de la consulta
                If dr.HasRows Then
                    While dr.Read
                        DataTable.Rows.Add(0,
                                           "1",
                                           dr.Item("ItemCode"),
                                           dr.Item("ItemName"),
                                           Session("RazMON") + " " + PrecioLista(dr.Item("ItemCode")),
                                           If(dr.Item("imag") = "", "data:image/png;base64,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", dr.Item("imag")))
                    End While
                End If
                cnn.Close()
                dr.Close()
                '----Agregar los datos a gridview
                mygrid.DataSource = DataTable
                mygrid.DataBind()
            Else
                ClientScript.RegisterStartupScript(Me.[GetType](), "aleasrt", "alert(' No se a definido el tipo de cambio del día. Contacte al Administrador ');document.location.href='Mensajes'; ", True)
            End If
        Catch ex As Exception
            cnn.Close()
            dr.Close()
            Dim fail As String = ex.Message
            ClientScript.RegisterStartupScript(Me.[GetType](), "aleasrt", "alert('" & fail & "');  ", True)
        End Try
    End Sub

    Function PrecioLista(ByVal item As String) As String
        '//**Creacion 03/01/2017**//
        '---Funcion Obtener el precio lista de venta
        Try
            Dim precio As String = Nothing, sql As String = "SELECT (CASE WHEN (Select T2.Price From NuevaBD.dbo.spp1 T2 WHERE T2.ItemCode=T0.ItemCode AND T2.ListNum=T1.PriceList)is null THEN (CASE WHEN (SELECT Discount FROM NuevaBD.dbo.EDG1 T3 WHERE T3.ObjKey=T0.ItemCode) IS NULL THEN (CASE WHEN T0.VATLiable='Y' THEN CAST(ROUND((T1.Price),2) AS DECIMAL(16,2)) ELSE CAST(ROUND(T1.Price,2) AS DECIMAL(16,2)) END) ELSE ((CASE WHEN T0.VATLiable='Y' THEN CAST(ROUND((T1.Price),2) AS DECIMAL(16,2)) ELSE CAST(ROUND(T1.Price,2) AS DECIMAL(16,2)) END)-(((CASE WHEN T0.VATLiable='Y' THEN CAST(ROUND((T1.Price),2) AS DECIMAL(16,2)) ELSE CAST(ROUND(T1.Price,2) AS DECIMAL(16,2)) END)*(SELECT Discount FROM NuevaBD.dbo.EDG1 T3 WHERE T3.ObjKey=T0.ItemCode))/100)) END) ELSE (Select CAST(ROUND((T2.Price),2) AS DECIMAL(16,2)) From NuevaBD.dbo.spp1 T2 WHERE T2.ItemCode=T0.ItemCode AND T2.ListNum=T1.PriceList) END) AS Precio " &
                                                            "FROM NuevaBD.dbo.OITM T0 INNER JOIN NuevaBD.dbo.ITM1 T1 ON (T1.ItemCode = T0.ItemCode) INNER JOIN NuevaBD.dbo.OPLN T2 ON (T2.ListNum = T1.PriceList) inner join NuevaBD.dbo.OCRD T3 on T3.listnum = T1.PriceList " &
                                                            "WHERE T1.ItemCode='" & item & "' AND T3.CardCode='" & Session("RazCode") & "'"
            con.Open()
            command = New SqlClient.SqlCommand(sql, con)
            dr2 = command.ExecuteReader()
            '--------->Recorrer todos los registros de la consulta
            If dr2.HasRows Then
                While dr2.Read
                    precio = String.Format("{0:N}", Convert.ToDouble(dr2.Item("Precio")))
                End While
            End If
            con.Close()
            dr2.Close()

            Return precio
        Catch ex As Exception
            con.Close()
            dr2.Close()
            Dim fail As String = ex.Message
            ClientScript.RegisterStartupScript(Me.[GetType](), "aleasrt", "alert('" & fail & "');  ", True)
        End Try
    End Function

    Protected Sub BtnBuscar_ServerClick(sender As Object, e As EventArgs) Handles BtnBuscar.ServerClick
        If Item.Value <> "" Then
            Response.Redirect("~/View/Ventas/Orden.aspx?Articulo=" & Item.Value)
        End If
    End Sub

    Protected Sub BindGrid()
        mygrid.DataSource = DirectCast(ViewState("Customers"), DataTable)
        mygrid.DataBind()
    End Sub

    Protected Sub checar()
        mygrid.Rows(0).Cells(0).Text = "a"

    End Sub

    Private Function ReadXML(Xml As String, NodeName As String)
        Dim reader As System.Xml.XmlTextReader = New System.Xml.XmlTextReader(New System.IO.StringReader(Xml))
        Dim valor As String
        valor = ""
        Do While (reader.Read())
            If reader.NodeType = System.Xml.XmlNodeType.Element Then
                If reader.Name.ToUpper = NodeName.ToUpper Then
                    valor = reader.ReadElementContentAsString
                End If
            End If
        Loop
        reader.Close()
        reader.Dispose()
        Return valor
    End Function


    Public Sub agregar(cantidad As String, itemm As String, nombr As String)
        Try
            '            myNewArrList  = CType(Session("MyArrayList"), ArrayList)

            '            'Then to pull out your values you just do this.
            '            Dim myValue As String
            'myValue = myNewArrList(0).ToString();
            'Dim myButton = CType(sender, HtmlButton)

            Dim carrito As ArrayList = New ArrayList
            Dim carritocan As ArrayList = New ArrayList
            Dim carritoprecio As ArrayList = New ArrayList
            Dim carritoitem As ArrayList = New ArrayList
            Dim carritoDescuento As ArrayList = New ArrayList
            Dim carritoNotaArt As ArrayList = New ArrayList

            Dim preciosporarticulo As ArrayList = getItemPriceDiscountByPolo(Session("RazCode"), itemm, 1, Session("Token"))

            Dim bas As Boolean = IsNothing(Session("carrito"))
            If IsNothing(Session("carrito")) Then

                carrito.Add(itemm)
                'carritocan.Add(1)
                carritocan.Add(cantidad)
                carritoprecio.Add(preciosporarticulo(0))
                carritoitem.Add(nombr)

                'carritoDescuento.Add(preciosporarticulo(1))
                carritoNotaArt.Add("")

                Session("carrito") = carrito
                Session("carritocan") = carritocan
                Session("precio") = carritoprecio
                Session("nom") = carritoitem
                Session("carritoDescuento") = carritoDescuento
                Session("carritoNotaArt") = carritoNotaArt

            Else
                Dim bandera As Boolean = False
                carrito = CType(Session("carrito"), ArrayList)
                carritocan = CType(Session("carritocan"), ArrayList)
                carritoprecio = CType(Session("precio"), ArrayList)
                carritoitem = CType(Session("nom"), ArrayList)
                carritoDescuento = CType(Session("carritoDescuento"), ArrayList)
                carritoNotaArt = CType(Session("carritoNotaArt"), ArrayList)


                For i As Integer = 0 To carrito.Count - 1

                    If carrito(i).ToString() = itemm Then
                        carritocan.Insert(i, (carritocan(i) + CInt(cantidad)))
                        carritocan.RemoveAt(i + 1)
                        bandera = True
                    End If

                Next
                If bandera = False Then
                    carrito.Add(itemm)
                    carritocan.Add(cantidad)
                    carritoprecio.Add(preciosporarticulo(0))
                    carritoitem.Add(nombr)
                    carritoDescuento.Add(preciosporarticulo(1))
                    carritoNotaArt.Add("")
                End If

                Session("carrito") = carrito
                Session("carritocan") = carritocan
                Session("precio") = carritoprecio
                Session("nom") = carritoitem
                Session("carritoDescuento") = carritoDescuento
                Session("carritoNotaArt") = carritoNotaArt
            End If




            Dim mpContentPlaceHolder As ContentPlaceHolder
            Dim mpdiv As HtmlGenericControl
            mpContentPlaceHolder = CType(Master.FindControl("CP2"), ContentPlaceHolder)
            mpdiv = CType(mpContentPlaceHolder.FindControl("carritonoti"), HtmlGenericControl)
            If mpdiv.InnerText = "" Then
                Session("carritonumitems") = 1
                mpdiv.InnerHtml = "1"
            Else
                Session("carritonumitems") = Session("carritonumitems") + 1
                mpdiv.InnerHtml = mpdiv.InnerText + 1
            End If
            mpdiv.Attributes.Add("style", "visibility:visible")
            'actualizacarritochiquito()
            ' ClientScript.RegisterStartupScript(Me.[GetType](), "aleasrt", "alert(' Se agregó  " & articnom.Value & " al carrito') ", True)
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub botonpagina_ServerClick(sender As Object, e As EventArgs) Handles botonpagina.ServerClick
        Session("pagIni") = idpagina.Value
        'buscarFinale()
    End Sub


    Protected Sub BtnAgregar_Click(sender As Object, e As EventArgs) Handles BtnAgregar.Click
        'checar()

        'SetRowData()
        Dim data As String = ""
        For Each row As GridViewRow In mygrid.Rows
            If row.RowType = DataControlRowType.DataRow Then
                Dim chkRow As CheckBox = TryCast(row.Cells(0).FindControl("CheckBox1"), CheckBox)
                Dim canti As TextBox = TryCast(row.Cells(0).FindControl("txtcantidad"), TextBox)

                If chkRow.Checked Then
                    Dim Cantidad As String = canti.Text
                    Dim codd As String = row.Cells(2).Text
                    Dim nombr As String = row.Cells(3).Text
                    agregar(Cantidad, codd, nombr)
                End If
            End If
        Next

    End Sub

    Private Sub SetRowData()
        Dim rowIndex As Integer = 0
        If ViewState("Customers") IsNot Nothing Then
            Dim dtCurrentTable As DataTable = DirectCast(ViewState("Customers"), DataTable)
            Dim drCurrentRow As DataRow = Nothing
            If dtCurrentTable.Rows.Count > 0 Then
                For i As Integer = 1 To dtCurrentTable.Rows.Count
                    Dim TextBoxName As CheckBox = DirectCast(mygrid.Rows(rowIndex).Cells(1).FindControl("CheckBox1"), CheckBox)
                    Dim TextBoxAge As TextBox = DirectCast(mygrid.Rows(rowIndex).Cells(2).FindControl("txtcantidad"), TextBox)
                    drCurrentRow = dtCurrentTable.NewRow()
                    dtCurrentTable.Rows(i - 1)(0) = TextBoxName.Text
                    dtCurrentTable.Rows(i - 1)(1) = TextBoxAge.Text
                    rowIndex += 1
                Next
                'grvStudentDetails.DataSource = dtCurrentTable;
                'grvStudentDetails.DataBind();
                ViewState("CurrentTable") = dtCurrentTable
            End If
        Else
            Response.Write("ViewState is null")
        End If
        'SetPreviousData();
    End Sub

    Private Sub agregaralgrid()

    End Sub
End Class
