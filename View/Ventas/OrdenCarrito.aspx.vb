Imports Modulo

Imports System.Xml
Imports System.Globalization
Imports System.IO
Imports System.Data
Partial Class View_Ventas_OrdenCarrito
    Inherits System.Web.UI.Page
    Public ws As DIS.DIServer


    Dim TablaPolo As String
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim rueba As String = "Prueba"

        If Not Page.IsPostBack Then
            TablaPolo = "<table     style=' text-align: center;width: 100%; min-width: 600px;border: solid 1px #575656; background: #ffffff'><tr><th>Articulo</th><th>Cantidad</th><th>Precio unitario</th><th>Descuento</th><th>Precio tras descuento</th><th>Precio total</th></tr> "

            If IsNothing(Session("carritonumitems")) Then
                Response.Redirect("~/View/Ventas/Orden.aspx")
            End If
            'Busqueda de facturas venciadas Balance
            Dim tRow As New TableRow()
            Dim tCell As New TableCell()
            ws = New DIS.DIServer
            ws.Url = Serveriii
            Dim carrito As ArrayList = New ArrayList
            Dim carritocan As ArrayList = New ArrayList
            Dim carritoprecio As ArrayList = New ArrayList
            Dim carritoitem As ArrayList = New ArrayList
            Dim carritoiva As ArrayList = New ArrayList
            Dim carritoDescuento As ArrayList = New ArrayList
            Dim carritoDescuentoEDIT As ArrayList = New ArrayList
            Dim carritoNotaArt As ArrayList = New ArrayList
            Dim precioYaConDescuento As String = ""
            Dim mystring As String
            Dim Respuesta As XmlNode
            Dim restring As String
            Dim totalxarticulo As Double = 0
            Dim totaliva As Double = 0
            Dim totalivafinal As Double = 0
            Dim fechastring = Today.ToString("yyyyMMdd")
            Dim subtotal As Double = 0
            Dim sqldato As String
            Dim banderaCar As Boolean = False
            Dim RowPolo As String = ""
            Try
                Session("Sumaivas") = 0
                If IsNothing(Session("carrito")) Then
                Else
                    carrito = CType(Session("carrito"), ArrayList)
                    carritocan = CType(Session("carritocan"), ArrayList)
                    carritoprecio = CType(Session("precio"), ArrayList)
                    carritoitem = CType(Session("nom"), ArrayList)
                    carritoNotaArt = CType(Session("carritoNotaArt"), ArrayList)
                    Try
                        If Session("carritoDescuentoEDIT") = Nothing Then
                            banderaCar = True
                        Else
                            carritoDescuentoEDIT = CType(Session("carritoDescuentoEDIT"), ArrayList)
                        End If

                    Catch ex As Exception
                        carritoDescuentoEDIT = CType(Session("carritoDescuentoEDIT"), ArrayList)
                    End Try

                    For i As Integer = 0 To carrito.Count - 1
                        RowPolo = "<tr>"
                        '-------------------------------------
                        'NOMBRE ARITCULO
                        '-------------------------------------
                        tRow = New TableRow()
                        tCell = New TableCell()
                        tCell.Text = carritoitem(i)
                        tRow.Cells.Add(tCell)
                        RowPolo += "<td style='border: solid 1px #575656; background: #ffffff'>" & carritoitem(i) & "</td>"
                        '-------------------------------------
                        'CANTIDAD
                        '-------------------------------------
                        tCell = New TableCell()
                        tCell.Text = "<input id='row" & i & "' type='text' size='4' value='" & carritocan(i) & "' onchange='myFunction(this.value,id)'>"
                        tCell.HorizontalAlign = HorizontalAlign.Center
                        tRow.Cells.Add(tCell)
                        RowPolo += "<td style='border: solid 1px #575656; background: #ffffff'>" & carritocan(i) & "</td>"
                        '-------------------------------------
                        'PRECIO ORIGINAL
                        '-------------------------------------
                        tCell = New TableCell()
                        mystring = "<env:Envelope xmlns:env='http://schemas.xmlsoap.org/soap/envelope/'><env:Header><SessionID>" & Session("Token") & "</SessionID></env:Header><env:Body><dis:GetItemPrice xmlns:dis='http://www.sap.com/SBO/DIS'><CardCode>" & Session("RazCode") & "</CardCode><ItemCode>" & carrito(i) & "</ItemCode><Quantity>" & carritocan(i) & "</Quantity><Date>" & fechastring & "</Date></dis:GetItemPrice></env:Body></env:Envelope>"
                        restring = ws.Interact(Session("Token"), mystring)
                        tCell.Text = ReadXML(restring, "Currency") + " " + String.Format("{0:N}", Convert.ToDouble(carritoprecio(i)))
                        tRow.Cells.Add(tCell)
                        RowPolo += "<td style='border: solid 1px #575656; background: #ffffff'>" & tCell.Text & "</td>"
                        '-------------------------------------
                        '% DESCUENTO
                        '-------------------------------------
                        tCell = New TableCell()
                        Dim preciosporarticulo As ArrayList
                        If banderaCar = True Or (carritoDescuentoEDIT.Count - 1) < i Then
                            preciosporarticulo = getItemPriceDiscountByPolo(Session("RazCode"), carrito(i), carritocan(i), Session("Token"))
                            carritoDescuentoEDIT.Add(preciosporarticulo(1))
                            tCell.Text = "%<input id='row" & i & "' type='text' size='4' value='" & Convert.ToDouble(carritoDescuentoEDIT(i)) & "' onchange='porcentaje(this.value,id)'>"
                        Else
                            tCell.Text = "%<input id='row" & i & "' type='text' size='4' value='" & Convert.ToDouble(carritoDescuentoEDIT(i)) & "' onchange='porcentaje(this.value,id)'>"
                        End If
                        tCell.HorizontalAlign = HorizontalAlign.Center
                        tRow.Cells.Add(tCell)
                        RowPolo += "<td style='border: solid 1px #575656; background: #ffffff'>%" & Convert.ToDouble(carritoDescuentoEDIT(i)) & "</td>"
                        '-------------------------------------
                        'PRECIO CON DESCUENTO
                        '-------------------------------------
                        tCell = New TableCell()
                        If CInt(carritoDescuentoEDIT(i)) <= 0 Then
                            tCell.Text = ReadXML(restring, "Currency") + " " + String.Format("{0:N}", Convert.ToDouble(carritoprecio(i)))
                            precioYaConDescuento = Convert.ToDouble(carritoprecio(i))
                        Else
                            tCell.Text = ReadXML(restring, "Currency") + " " + String.Format("{0:N}", Convert.ToDouble((Convert.ToDouble(carritoprecio(i)) - (Convert.ToDouble(carritoDescuentoEDIT(i)) / 100) * Convert.ToDouble(carritoprecio(i)))))
                            precioYaConDescuento = Convert.ToDouble((Convert.ToDouble(carritoprecio(i)) - (Convert.ToDouble(carritoDescuentoEDIT(i)) / 100) * Convert.ToDouble(carritoprecio(i))))
                        End If
                        tRow.Cells.Add(tCell)
                        RowPolo += "<td style='border: solid 1px #575656; background: #ffffff'>" & tCell.Text & "</td>"
                        '-------------------------------------
                        'PRECIO * CANTIDAD = TOTAL DE LINEA
                        '-------------------------------------
                        tCell = New TableCell()
                        totalxarticulo = precioYaConDescuento * carritocan(i)
                        totalxarticulo = Convert.ToDouble(totalxarticulo)
                        tCell.Text = Session("RazMON") + " " + Convert.ToDouble(totalxarticulo.ToString).ToString("N2", CultureInfo.CreateSpecificCulture("en-US"))

                        RowPolo += "<td style='border: solid 1px #575656; background: #ffffff'>" & tCell.Text & "</td></tr>"
                        TablaPolo += RowPolo
                        tRow.Cells.Add(tCell)

                        '-------------------------------------
                        'NOTA DE ARTICULO
                        '------------------------- 
                        'tCell = New TableCell()
                        'tCell.Text = "<input id='row" & i & "' type='text' size='' value='" & carritoNotaArt(i) & "' onchange=' NotaArt(this.value,id)'>"
                        'tCell.HorizontalAlign = HorizontalAlign.Center
                        'tRow.Cells.Add(tCell)

                        Dim monedaartic As String = ReadXML(restring, "Currency")
                        subtotal = subtotal + totalxarticulo
                        sqldato = " SELECT top 20 t2.ItemCode, t2.U_IL_iva, t3.rate   FROM   OITM t2  inner join  OSTC t3 on t2.U_IL_iva=t3.Code   where t2.ItemCode ='" & carrito(i) & "' "
                        Respuesta = ws.ExecuteSQL(Session("Token"), sqldato)
                        totaliva = ReadXML(Respuesta.InnerXml, "rate")
                        carritoiva.Insert(i, ReadXML(Respuesta.InnerXml, "U_IL_iva"))
                        If totaliva > 0 Then
                            Session("Sumaivas") = Session("Sumaivas") + (totalxarticulo * totaliva / 100)
                            mystring = Session("Sumaivas")
                        End If
                        Table1.Rows.Add(tRow)
                    Next
                End If
                Session("ivas") = carritoiva
                tRow = New TableRow()
                For x = 1 To 4
                    tCell = New TableCell()
                    tCell.Text = " "
                    tRow.Cells.Add(tCell)
                Next
                tCell = New TableHeaderCell()
                tCell.Text = "Subtotal"
                tCell.HorizontalAlign = HorizontalAlign.Right
                tRow.Cells.Add(tCell)
                tCell = New TableCell()
                'aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa 
                '-------------------------------------
                'SUBTOTAL
                '-------------------------------------
                tCell.Text = Session("RazMON") + " " + String.Format("{0:N}", Convert.ToDouble(subtotal))
                RowPolo = " <tr><td></td><td></td><td></td><td></td><th style='border: solid 1px #575656; background: #ffffff'>Subtotoal</th><td style='border: solid 1px #575656; background: #ffffff'>" & tCell.Text & "</td></tr>"
                tRow.Cells.Add(tCell)
                Table1.Rows.Add(tRow)
                tRow = New TableRow()
                For x = 1 To 4
                    tCell = New TableCell()
                    tCell.Text = " "
                    tRow.Cells.Add(tCell)
                Next
                tCell = New TableHeaderCell()
                tCell.Text = "Impuesto"
                tRow.Cells.Add(tCell)
                tCell = New TableCell()
                '-------------------------------------
                'IMPUESTO
                '-------------------------------------
                tCell.Text = Session("RazMON") + " " + String.Format("{0:N}", Session("Sumaivas"))
                RowPolo += " <tr><td></td><td></td><td></td><td></td><th style='border: solid 1px #575656; background: #ffffff'>Impuesto</th><td style='border: solid 1px #575656; background: #ffffff'>" & tCell.Text & "</td></tr>"
                tRow.Cells.Add(tCell)
                Table1.Rows.Add(tRow)
                tRow = New TableRow()
                For x = 1 To 4
                    tCell = New TableCell()
                    tCell.Text = " "
                    tRow.Cells.Add(tCell)
                Next
                tCell = New TableHeaderCell()
                tCell.Text = "Total"
                tCell.HorizontalAlign = HorizontalAlign.Right
                tRow.Cells.Add(tCell)
                tCell = New TableCell()
                '-------------------------------------
                'TOTAL
                '-------------------------------------
                tCell.Text = Session("RazMON") + " " + String.Format("{0:N}", Convert.ToDouble(subtotal) + Session("Sumaivas"))
                '------------------Tabla Envio Mail-------------------
                RowPolo += " <tr><td ></td><td></td><td></td><td></td><th style='border: solid 1px #575656; background: #ffffff'>Total</th><td style='border: solid 1px #575656; background: #ffffff'>" & tCell.Text & "</td></tr>"
                TablaPolo += RowPolo
                If Session("usutipo") = "venta" Then
                    TablaPolo = "Socio de Negocio: " & Session("RazName") & "<br><br>" & TablaPolo
                Else
                    TablaPolo = "Socio de Negocio: " & Session("usuName") & "<br><br>" & TablaPolo
                End If
                Session("pedidoTableHTML") = TablaPolo
                tRow.Cells.Add(tCell)
                Table1.Rows.Add(tRow)
                Session("carritoDescuentoEDIT") = carritoDescuentoEDIT
            Catch ex As Exception
                Dim ectraoficial As String = ex.Message
            End Try
        End If

    End Sub

    Protected Sub secretbutton_ServerClick(sender As Object, e As EventArgs) Handles secretbutton.ServerClick
        Try
            'actualizan cantidad del articulo
            Dim confirmValue As String = Request.Form("confirm_value")
            If confirmValue = "Ok" Then
                Dim valor As Integer = actuacan.Value
                actuacan.Value = valor
                If valor > 0 Then
                    Try
                        Dim carrito As ArrayList = New ArrayList
                        Dim carritocan As ArrayList = New ArrayList
                        Dim carritoprecio As ArrayList = New ArrayList
                        Dim carritoitem As ArrayList = New ArrayList
                        Dim carritoDescuentoEDIT As ArrayList = New ArrayList
                        If IsNothing(Session("carrito")) Then
                        Else
                            carrito = CType(Session("carrito"), ArrayList)
                            carritocan = CType(Session("carritocan"), ArrayList)
                            carritoDescuentoEDIT = CType(Session("carritoDescuentoEDIT"), ArrayList)

                            Dim preciosporarticulo As ArrayList = getItemPriceDiscountByPolo(Session("RazCode"), carrito(actuaid.Value), actuacan.Value, Session("Token"))

                            carritoDescuentoEDIT(actuaid.Value) = Convert.ToDouble(preciosporarticulo(1))
                            carritocan(actuaid.Value) = actuacan.Value
                            Session("carritocan") = carritocan
                            Session("carritoDescuentoEDIT") = carritoDescuentoEDIT
                            Response.Redirect("~/View/Ventas/OrdenCarrito.aspx")
                        End If
                    Catch ex As Exception
                        Response.Redirect("~/View/Ventas/OrdenCarrito.aspx")
                    End Try
                Else

                    'en caso de ser cero lo que se pide se elimina del carrito
                    Dim carrito As ArrayList = New ArrayList
                    Dim carritocan As ArrayList = New ArrayList
                    Dim carritoprecio As ArrayList = New ArrayList
                    Dim carritoitem As ArrayList = New ArrayList
                    Dim carritoDescuento As ArrayList = New ArrayList
                    Dim carritoNotaArt As ArrayList = New ArrayList

                    If IsNothing(Session("carrito")) Then
                    Else
                        carrito = CType(Session("carrito"), ArrayList)
                        carritocan = CType(Session("carritocan"), ArrayList)
                        carritoprecio = CType(Session("precio"), ArrayList)
                        carritoitem = CType(Session("nom"), ArrayList)
                        carritoDescuento = CType(Session("carritoDescuento"), ArrayList)
                        'carritoNotaArt = CType(Session("carritoNotaArt"), ArrayList)

                        carrito.RemoveAt(actuaid.Value)
                        carritocan.RemoveAt(actuaid.Value)
                        carritoprecio.RemoveAt(actuaid.Value)
                        carritoitem.RemoveAt(actuaid.Value)
                        carritoDescuento.RemoveAt(actuaid.Value)
                        'carritoNotaArt.RemoveAt(actuaid.Value)

                        Session("carritonumitems") = CInt(Session("carritonumitems")) - 1
                        Session("carrito") = carrito
                        Session("carritocan") = carritocan
                        Session("precio") = carritoprecio
                        Session("nom") = carritoitem
                        Session("carritoDescuento") = carritoDescuento
                        'Session("carritoNotaArt") = carritoNotaArt

                        If carrito.Count = 0 Then
                            Limpiarcarro_ServerClick("", Nothing)
                        End If
                        Response.Redirect("OrdenCarrito.aspx")
                    End If
                End If
            Else
                ClientScript.RegisterStartupScript(Me.[GetType](), "aleasrt", " document.location.href='OrdenCarrito';", True)
            End If

        Catch ex As Exception
            Response.Redirect("~/View/Ventas/OrdenCarrito.aspx")
        End Try
    End Sub

    Protected Sub Limpiarcarro_ServerClick(sender As Object, e As EventArgs) Handles Limpiarcarro.ServerClick
        Session("carrito") = Nothing
        Session("carritocan") = Nothing
        Session("precio") = Nothing
        Session("nom") = Nothing
        Session("carritonumitems") = Nothing
        Session("ivas") = Nothing
        Session("carritoDescuento") = Nothing
        'Session("carritoNotaArt") = Nothing
        Session("carritoDescuentoEDIT") = Nothing

        Response.Redirect("~/View/Ventas/Orden.aspx")
    End Sub

    Protected Sub regresar_ServerClick(sender As Object, e As EventArgs) Handles regresar.ServerClick
        Response.Redirect("~/View/Ventas/Orden.aspx")
    End Sub

    Protected Sub agregaorden()
        '//Update 11/01/2017
        Try
            ws = New DIS.DIServer
            ws.Url = Serveriii
            Dim carrito As ArrayList = New ArrayList
            Dim carritocan As ArrayList = New ArrayList
            Dim carritoprecio As ArrayList = New ArrayList
            Dim carritoitem As ArrayList = New ArrayList
            Dim carritoiva As ArrayList = New ArrayList
            Dim carritoDescuentoEDIT As ArrayList = New ArrayList
            Dim carritoNotaArt As ArrayList = New ArrayList
            Dim answer As Date = Today.AddDays(15)
            Dim fechastring = answer.ToString("yyyyMMdd")
            Dim subtotal As Double = 0
            Dim orden As String = "", Objeto As String = Nothing
            If IsNothing(Session("carrito")) Then

            Else
                carrito = CType(Session("carrito"), ArrayList)
                carritocan = CType(Session("carritocan"), ArrayList)
                carritoprecio = CType(Session("precio"), ArrayList)
                carritoitem = CType(Session("nom"), ArrayList)
                carritoiva = CType(Session("ivas"), ArrayList)
                carritoDescuentoEDIT = CType(Session("carritoDescuentoEDIT"), ArrayList)
                'carritoNotaArt = CType(Session("carritoNotaArt"), ArrayList)

                If Session("tipodocventas") = "pedido" Then
                    Objeto = "oOrders"
                Else
                    Objeto = "oQuotations"
                End If
                '---Borrar es solo para ver caso de ejemplo
                Objeto = "oQuotations"
                '----Creacion de BOMdata 
                '----Crear metodo para establecer almacen default antes de realizar la venta(pedido) en bomdata
                orden = "" &
                        "<BOM xmlns='http://www.sap.com/SBO/DIS'><BO><AdmInfo><Object>" & Objeto & "</Object>" &
                        "</AdmInfo><Documents><row> <DocDueDate>" & fechastring & "</DocDueDate><Comments>" & TextArea1.InnerText & "</Comments>" &
                        "<CardCode>" & Session("RazCode") & "</CardCode><SalesPersonCode>89</SalesPersonCode><U_embarque>Entrega a Domicilio</U_embarque>" &
                        "<U_FPago>" & U_FPago.Value & "</U_FPago><U_PagoFiscal>" & U_PagoFiscal.Value & "</U_PagoFiscal><U_Fac>" & U_Fac.Value & "</U_Fac>" &
                        "</row></Documents><Document_Lines>"
                For i As Integer = 0 To carrito.Count - 1
                    orden = orden + "" &
                             "<row><LineNum>" & (i + 1) & "</LineNum><ItemCode>" & carrito(i) & "</ItemCode><Quantity>" & carritocan(i) & "</Quantity><WarehouseCode>" & DfltWH(carrito(i)) & "</WarehouseCode><TaxCode>" & carritoiva(i) & "</TaxCode><DiscountPercent>" & carritoDescuentoEDIT(i) & "</DiscountPercent><SalesPersonCode>89</SalesPersonCode></row>"
                Next
                '<FreeText>" & carritoNotaArt(i) & "</FreeText>
                orden = orden + "</Document_Lines>" &
                                        "<AddressExtension>" &
                                            "<row>" &
                                                "<BillToStreet>" & Domicilio.Value & "</BillToStreet>" &
                                                "<BillToStreetNo>" & Referencia.Value & "</BillToStreetNo>" &
                                                "<BillToBlock>" & Comunidad.Value & "</BillToBlock>" &
                                                "<BillToCity>" & Telefono.Value & "</BillToCity>" &
                                                "<BillToZipCode>" & Contacto.Value & "</BillToZipCode>" &
                                                "<BillToCounty>" & Hora_E.Value & "</BillToCounty>" &
                                            "</row>" &
                                        "</AddressExtension>" &
                                "</BO></BOM>"


                Dim Respuesta As System.Xml.XmlNode = ws.AddObject(Session("Token"), orden, "AddOrder")

                Dim errorr As String = ReadXML(Respuesta.InnerXml, "env:Text")
                If errorr = "" Then
                    If CheckMail.Checked Then
                        EnvioMailPedido()
                    End If

                    Session("carrito") = Nothing
                    Session("carritocan") = Nothing
                    Session("precio") = Nothing
                    Session("nom") = Nothing
                    Session("carritonumitems") = Nothing
                    Session("ivas") = Nothing
                    Session("carritoDescuentoEDIT") = Nothing
                    'Session("carritoNotaArt") = Nothing

                    'EnvioMailPedido("leopoldo.delatorre@interlatin.com.mx", "leopoldo.delatorre@interlatin.com.mx")

                    ClientScript.RegisterStartupScript(Me.[GetType](), "aleasrt", "alert('Documento " & Session("tipodocventas") & " creado. ');document.location.href='Catalogo';", True)
                Else
                    errorr = Replace(errorr, "'", "")
                    Me.Page.ClientScript.RegisterStartupScript(Me.GetType(), "aleasrt", "alert('" & errorr & "');document.location.href='OrdenCarrito';", True)

                End If
                System.Diagnostics.Debug.Write(ReadXML(Respuesta.InnerXml, "env:Text") & vbCrLf)
            End If
        Catch ex As Exception
            System.Diagnostics.Debug.Write(ex.Message & vbCrLf)
        End Try
    End Sub

    Function DfltWH(ByVal ItemCode As String) As String
        '//**Creacion 11/01/2017**//
        '//Update 11/01/2017
        Try
            Dim sql As String = "Select TOP 1 T0.DfltWH " &
                                "From OITM T0 Inner Join OWHS T1 On (T1.WhsCode=T0.DfltWH) " &
                                "Where T0.ItemCode='" & ItemCode & "'"
            Dim DefaulWhs As String = Nothing
            cnn.Open()
            cmd = New SqlClient.SqlCommand(sql, cnn)
            dr = cmd.ExecuteReader()
            '--------->Recorrer todos los registros de la consulta
            If dr.HasRows Then
                While dr.Read
                    DefaulWhs = dr.Item("DfltWH")
                End While
            End If

            cnn.Close()
            dr.Close()
            Return DefaulWhs

        Catch ex As Exception
            cnn.Close()
            dr.Close()
            Dim fail As String = ex.Message
            ClientScript.RegisterStartupScript(Me.[GetType](), "aleasrt", "alert('" & fail & "');  ", True)
        End Try
    End Function

    Protected Sub OnConfirm(sender As Object, e As EventArgs)
        Dim confirmValue As String = Request.Form("confirm_value")
        If confirmValue = "Ok" Then
            agregaorden()
            'ClientScript.RegisterStartupScript(Me.[GetType](), "alert", "alert('You clicked YES!')", True)
        Else
            ClientScript.RegisterStartupScript(Me.[GetType](), "aleasrt", " document.location.href='OrdenCarrito';", True)
        End If
    End Sub


    Protected Sub Mailer()
        '   <table style="width:100%"  border="1">
        '  <tr>
        '    <td>Jill</td>
        '    <td>Smith</td>
        '    <td>50</td>
        '  </tr> 
        '  <tr>
        '    <td> </td>
        '    <th>Impuesto </th>
        '    <td>94</td>
        '  </tr> 
        '</table> 
    End Sub

    Protected Sub cambioPorcentaje_ServerClick(sender As Object, e As EventArgs) Handles cambioPorcentaje.ServerClick
        Try
            'actualizan porcentaje de descuento
            Dim valor As Double = Convert.ToDouble(actuacan.Value)

            actuacan.Value = valor
            If valor > 0 Then
                Try
                    Dim carritoDescuentoEDIT As ArrayList = New ArrayList
                    Dim carrito As ArrayList = New ArrayList
                    Dim carritocan As ArrayList = New ArrayList
                    carritoDescuentoEDIT = CType(Session("carritoDescuentoEDIT"), ArrayList)
                    carrito = CType(Session("carrito"), ArrayList)
                    carritocan = CType(Session("carritocan"), ArrayList)

                    Dim preciosporarticulo As ArrayList = getItemPriceDiscountByPolo(Session("RazCode"), carrito(actuaid.Value), carritocan(actuaid.Value), Session("Token"))

                    If Convert.ToDouble(preciosporarticulo(1)) > Convert.ToDouble(actuacan.Value) Then
                        carritoDescuentoEDIT(actuaid.Value) = Convert.ToDouble(actuacan.Value)
                    Else
                        carritoDescuentoEDIT(actuaid.Value) = Convert.ToDouble(preciosporarticulo(1))
                    End If

                    Session("carritoDescuentoEDIT") = carritoDescuentoEDIT
                    ClientScript.RegisterStartupScript(Me.[GetType](), "aleasrt", " document.location.href='OrdenCarrito';", True)

                Catch ex As Exception
                    ClientScript.RegisterStartupScript(Me.[GetType](), "aleasrt", " document.location.href='OrdenCarrito';", True)
                End Try
            Else
                ClientScript.RegisterStartupScript(Me.[GetType](), "aleasrt", " document.location.href='OrdenCarrito';", True)
            End If

        Catch ex As Exception
            ClientScript.RegisterStartupScript(Me.[GetType](), "aleasrt", " document.location.href='OrdenCarrito';", True)
        End Try
    End Sub

    Protected Sub cambioNota_ServerClick(sender As Object, e As EventArgs) Handles cambioNota.ServerClick
        Try
            'actualizan porcentaje de descuento
            Try
                Dim carritoNotaArt As ArrayList = New ArrayList
                carritoNotaArt = CType(Session("carritoNotaArt"), ArrayList)
                carritoNotaArt(actuaid.Value) = actuacan.Value
                Session("carritoNotaArt") = carritoNotaArt
                ClientScript.RegisterStartupScript(Me.[GetType](), "aleasrt", " document.location.href='OrdenCarrito';", True)

            Catch ex As Exception
                ClientScript.RegisterStartupScript(Me.[GetType](), "aleasrt", " document.location.href='OrdenCarrito';", True)
            End Try
        Catch ex As Exception
            ClientScript.RegisterStartupScript(Me.[GetType](), "aleasrt", " document.location.href='OrdenCarrito';", True)
        End Try
    End Sub

    Private Sub EnvioMailPedido()
        Try
            Dim oMsg As CDO.Message = New CDO.Message()
            Dim iConfg As CDO.Configuration
            Dim oFields As ADODB.Fields
            Dim oField As ADODB.Field
            iConfg = oMsg.Configuration
            oFields = iConfg.Fields

            'Canal de comunicacion
            oField = oFields("http://schemas.microsoft.com/cdo/configuration/sendusing")
            oField.Value = CDO.CdoSendUsing.cdoSendUsingPort
            '1: cdoSendUsingPickup 2: cdoSendUsingPort

            'IP del servidor SMTP
            oField = oFields("http://schemas.microsoft.com/cdo/configuration/smtpserver")
            oField.Value = Session("smtp")

            'Tiempo de espera
            oField = oFields("http://schemas.microsoft.com/cdo/configuration/smtpconnectiontimeout")
            oField.Value = 20 'Segs

            'Puerto del SMTP
            oField = oFields("http://schemas.microsoft.com/cdo/configuration/smtpserverport")
            oField.Value = Session("puerto")  '585 TCP/IP

            'Tipo de autenticacion
            oField = oFields("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate")
            oField.Value = CDO.CdoProtocolsAuthentication.cdoBasic

            'Nombre de usuario
            oField = oFields("http://schemas.microsoft.com/cdo/configuration/sendusername")
            oField.Value = Session("username")

            'Contraseña
            oField = oFields("http://schemas.microsoft.com/cdo/configuration/sendpassword")
            oField.Value = Session("password")

            'Utiliza SSL
            oField = oFields("http://schemas.microsoft.com/cdo/configuration/smtpusessl")
            If Session("ssl") = "SI" Then
                oField.Value = True
            Else
                oField.Value = False
            End If
            'Actualizamos los datos de la cuenta SMTP
            oFields.Update()
            oMsg.Configuration = iConfg
            oMsg.Subject = "Oferta de venta - " & Now
            '1) Solo texto
            oMsg.HTMLBody = "Oferta de venta - " & Now
            '2) Correo en HTML
            'oMsg.HTMLBody = "<body></body>" 
            'Cuentas de Email
            oMsg.ReplyTo = Session("MailDestino")
            oMsg.To = Session("MailDestino")
            oMsg.From = Session("acount")

            Dim dir = System.IO.Path.GetTempPath()
            Dim file__1 = Path.Combine(dir, Guid.NewGuid().ToString() + ".xls")
            Directory.CreateDirectory(dir)
            File.WriteAllText(file__1, Session("pedidoTableHTML"))
            Dim _count = File.ReadAllText(file__1)
            'Adjuntos
            Dim Attchs As CDO.IBodyPart
            Attchs = oMsg.AddAttachment(file__1)
            'Attchs = oMsg.AddAttachment(adjPDF)
            'Attchs = oMsg.AddAttachment("c:\Windows\Factura.pdf")

            'Enviamos el correo
            oMsg.Send()

            'Limpiamos las variables
            oMsg = Nothing
            iConfg = Nothing
            oFields = Nothing
            oField = Nothing
            File.Delete(file__1)
            ' Return "Envio Correcto"
        Catch ex As Exception

            'Return ex.Message
        End Try





    End Sub
End Class
