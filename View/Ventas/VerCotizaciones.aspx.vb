Imports Modulo
Imports ConectaMod
Imports System.Xml
Imports System.Globalization
Imports System.IO
Imports System.Data
Partial Class View_Ventas_VerCotizaciones
    Inherits System.Web.UI.Page
    Dim DocNum As String, DocDate As String, TipoEmbarque As String, TipoPago As String, TipoFac As String
    Dim ColReg As String, MunReg As String, EstReg As String
    Dim EstatusValido As String
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        '//Update 23/01/2017
        If Not Page.IsPostBack Then
            Try
                EstatusValido = "Y"
                DatosCliente()
                Municipio.Enabled = False
                Colonia.Enabled = False
                LoadString()
                LlenarTabla()
                ValidarOferta()
                LlenarEstado()
                Previos()
            Catch ex As Exception
                Dim fail As String = ex.Message
                ClientScript.RegisterStartupScript(Me.[GetType](), "aleasrt", "alert('" & fail & "');  ", True)
            End Try

        End If
    End Sub

    Protected Sub Previos()
        '//**Creacion 25/01/2017**//
        '//Update 25/01/2017
        TipoDoc.Checked = False

        If TipoEmbarque = "El cliente se lo lleva" Then
            TipoEntrega.Checked = False
        Else
            TipoEntrega.Checked = True
        End If

        If TipoPago = "" Then
            U_PagoFiscal.SelectedIndex = 0
        Else
            U_PagoFiscal.Items.FindByValue(TipoPago).Selected = True
        End If

        If TipoFac = "" Then
            U_Fac.SelectedIndex = 0
        Else
            U_Fac.Items.FindByValue(TipoFac).Selected = True
        End If

    End Sub

    Protected Sub ValidarOferta()
        '//**Creacion 25/01/2017**//
        '//Update 25/01/2017
        Dim fechastring = Today.ToString("dd/MM/yyyy")
        Dim Validar As Integer = DateDiff(DateInterval.Day, Convert.ToDateTime(DocDate), Convert.ToDateTime(fechastring))
        If (Validar) > 1 Then
            'BtnEnviar.Enabled = False
            BtnEnviar.Attributes.Add("disabled", "disabled")
            EstatusValido = "N"
            Dim html As String = "<div class='info-box bg-orange hover-zoom-effect'>" &
                                    "<div Class='icon'>" &
                                        "<i class='material-icons'>warning</i>" &
                                    "</div>" &
                                    "<div class='content'>" &
                                        "<div Class='text'><h3>Oferta Vencida</h3></div>" &
                                    "</div>" &
                                "</div>"

            Advertencia.InnerHtml = html

        End If

    End Sub

    Protected Sub DatosCliente()
        '//**Creacion 23/01/2017**//
        '//Update 23/01/2017
        Try
            '--Realizar busqueda XML
            Dim Sql As String = "Select T0.CardCode,T0.CardName,T0.LicTradNum,T1.PymntGroup,T0.U_NCuneta " &
                                "From NuevaBD.dbo.OCRD T0 " &
                                "Inner Join NuevaBD.dbo.OCTG T1 On (T1.GroupNum=T0.GroupNum) " &
                                "Where T0.CardCode='" & Session("RazCode") & "'"
            ws = New DIS.DIServer
            XmlDoc.LoadXml(ws.ExecuteSQL(Session("Token"), Sql).InnerXml)
            Node = XmlDoc.FirstChild.LastChild.Clone.ChildNodes

            '---Recorrer Busqueda
            For Each Nodo As XmlNode In Node
                DatoCliente.Text = Nodo("CardCode").InnerText
                DatoNombre.Text = Nodo("CardName").InnerText
                DatoRFC.Text = Nodo("LicTradNum").InnerText
                DatoCP.Text = Nodo("PymntGroup").InnerText
                DatoCB.Text = Nodo("U_NCuneta").InnerText
            Next

        Catch ex As Exception
            Dim fail As String = ex.Message
            ClientScript.RegisterStartupScript(Me.[GetType](), "aleasrt", "alert('" & fail & "');  ", True)
        End Try
    End Sub

    Protected Sub LlenarEstado()
        '//**Creacion 23/01/2017**//
        '//Update 23/01/2017
        Try
            Dim Sql As String = "Select T0.D_Estado " &
                                "From EcommerceSF.dbo.TAEM T0 " &
                                "Where (T0.C_Estado='06' or T0.C_Estado='14' or T0.C_Estado='16')"

            cnn.Open()
            cmd = New SqlClient.SqlCommand(Sql, cnn)
            dr = cmd.ExecuteReader()

            '--------->Recorrer todos los registros de la consulta
            Estado.DataSource = dr
            Estado.DataTextField = "D_Estado"
            Estado.DataValueField = "D_Estado"
            Estado.DataBind()
            Estado.Items.Insert(0, New ListItem("- Seleccione Estado- ", "00"))
            cnn.Close()
            dr.Close()
            If EstReg <> "" Then
                Estado.Items.FindByValue(EstReg).Selected = True
                LlenarMunicipio()
                EstReg = ""
            End If
        Catch ex As Exception
            cnn.Close()
            dr.Close()
            Dim fail As String = ex.Message
            ClientScript.RegisterStartupScript(Me.[GetType](), "aleasrt", "alert('" & fail & "');  ", True)
        End Try

    End Sub

    Protected Sub Estado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Estado.SelectedIndexChanged
        LlenarMunicipio()
    End Sub

    Protected Sub LlenarMunicipio()
        '//**Creacion 23/01/2017**//
        '//Update 25/01/2017
        If Estado.SelectedValue = "00" Then
            Municipio.Enabled = False
            Municipio.Items.Clear()
            Colonia.Items.Clear()
        Else
            Try

                Municipio.Enabled = True
                Dim Sql As String = "Select T0.D_Municipio " &
                                    "From EcommerceSF.dbo.TAMM T0 " &
                                    "	Inner Join EcommerceSF.dbo.TAEM T1 ON (T1.C_Estado=T0.C_Estado) " &
                                    "Where T1.D_Estado='" & Estado.SelectedValue & "'"

                cnn.Open()
                cmd = New SqlClient.SqlCommand(Sql, cnn)
                dr = cmd.ExecuteReader()

                '--------->Recorrer todos los registros de la consulta
                Municipio.DataSource = dr
                Municipio.DataTextField = "D_Municipio"
                Municipio.DataValueField = "D_Municipio"
                Municipio.DataBind()
                Municipio.Items.Insert(0, New ListItem("- Seleccione Municipio -", "00"))
                cnn.Close()
                dr.Close()

                If MunReg <> "" Then
                    Municipio.Items.FindByValue(MunReg).Selected = True
                    LlenarColonia()
                    MunReg = ""
                End If
            Catch ex As Exception
                cnn.Close()
                dr.Close()
                Dim fail As String = ex.Message
                ClientScript.RegisterStartupScript(Me.[GetType](), "aleasrt", "alert('" & fail & "');  ", True)
            End Try
        End If
    End Sub

    Protected Sub Municipio_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Municipio.SelectedIndexChanged
        LlenarColonia()
    End Sub

    Protected Sub LlenarColonia()
        '//**Creacion 23/01/2017**//
        '//Update 25/01/2017
        If Municipio.SelectedValue = "00" Then
            Colonia.Enabled = False
            Colonia.Items.Clear()
        Else
            Try

                Colonia.Enabled = True
                Dim Sql As String = "Select T0.D_Asentamiento " &
                                    "From EcommerceSF.dbo.TAAM T0 " &
                                    "	Inner Join EcommerceSF.dbo.TAEM T1 ON (T1.C_Estado=T0.C_Estado) " &
                                    "	Inner Join EcommerceSF.dbo.TAMM T2 ON (T2.C_Municipio=T0.C_Municipio) " &
                                    "Where T1.D_Estado='" & Estado.SelectedValue & "' and T2.D_Municipio='" & Municipio.SelectedValue & "'"

                cnn.Open()
                cmd = New SqlClient.SqlCommand(Sql, cnn)
                dr = cmd.ExecuteReader()

                '--------->Recorrer todos los registros de la consulta
                Colonia.DataSource = dr
                Colonia.DataTextField = "D_Asentamiento"
                Colonia.DataValueField = "D_Asentamiento"
                Colonia.DataBind()
                Colonia.Items.Insert(0, New ListItem("- Seleccione Colonia -", "00"))
                cnn.Close()
                dr.Close()
                If ColReg <> "" Then
                    Colonia.Items.FindByValue(ColReg).Selected = True
                    ColReg = ""
                End If
            Catch ex As Exception
                cnn.Close()
                dr.Close()
                Dim fail As String = ex.Message
                ClientScript.RegisterStartupScript(Me.[GetType](), "aleasrt", "alert('" & fail & "');  ", True)
            End Try
        End If
    End Sub

    Protected Sub LlenarTabla()
        Try
            Dim sql As String = Nothing
            Dim Identificador(3) As String
            Dim contador As Integer = 0
            Dim SubTotal As Double = 0, Impuesto As Double = 0, Total As Double = 0
            sql = "Select T2.ItemName,T1.Quantity,T1.Price,T1.LineTotal,T1.VatSum,T0.DocTotal,T0.DocDate," &
                          "T0.U_embarque,T0.U_PagoFiscal,T0.U_Fac,T3.StreetNoB,T3.StreetB,T3.BlockB,T3.CityB,T3.ZipCodeB,T0.Comments " &
                  "From NuevaBD.dbo.OQUT T0 " &
                  "	Inner Join NuevaBD.dbo.QUT1 T1 ON (T1.DocEntry=T0.DocEntry) " &
                  "	Inner Join NuevaBD.dbo.OITM T2 ON (T2.ItemCode=T1.ItemCode) " &
                  "	Inner Join NuevaBD.dbo.QUT12 T3 On (T3.Docentry=T0.DocEntry) " &
                  "Where T0.DocNum='" & DocNum & "' "

            '---Definir tabla temporal para llenar gv
            Dim DataTable As New DataTable()
            DataTable.Columns.AddRange(New DataColumn() {New DataColumn("ItemName", GetType(String)),
                                                       New DataColumn("Quantity", GetType(String)),
                                                       New DataColumn("Price", GetType(String)),
                                                       New DataColumn("LineTotal", GetType(String))})

            cnn.Open()
            cmd = New SqlClient.SqlCommand(sql, cnn)
            dr = cmd.ExecuteReader()
            '--------->Recorrer todos los registros de la consulta
            If dr.HasRows Then
                While dr.Read

                    DataTable.Rows.Add(dr.Item("ItemName"),
                                       String.Format("{0:N}", Convert.ToDouble(dr.Item("Quantity"))),
                                       Session("RazMON") + " " + String.Format("{0:N}", Convert.ToDouble(dr.Item("Price"))),
                                       Session("RazMON") + " " + String.Format("{0:N}", Convert.ToDouble(dr.Item("LineTotal"))))
                    SubTotal = SubTotal + Convert.ToDouble(dr.Item("LineTotal"))
                    Impuesto = Impuesto + Convert.ToDouble(dr.Item("VatSum"))
                    Total = dr.Item("DocTotal")
                    DocDate = dr.Item("DocDate")
                    TipoEmbarque = If(IsDBNull(dr.Item("U_embarque")), "", dr.Item("U_embarque"))
                    TipoPago = If(IsDBNull(dr.Item("U_PagoFiscal")), "", dr.Item("U_PagoFiscal"))
                    TipoFac = If(IsDBNull(dr.Item("U_Fac")), "", dr.Item("U_Fac"))
                    Referencia.Value = If(IsDBNull(dr.Item("StreetNoB")), "", dr.Item("StreetNoB"))
                    ColReg = If(IsDBNull(dr.Item("StreetB")), "", dr.Item("StreetB"))
                    Dim temp As String = If(IsDBNull(dr.Item("BlockB")), "", dr.Item("BlockB"))
                    If temp <> "" Then
                        Dim Pos As Integer = InStr(temp, "-")
                        If Pos <> 0 Then
                            Identificador = temp.Split("-")
                            EstReg = Identificador(0)
                            MunReg = Identificador(1)
                        End If
                    Else
                        EstReg = ""
                        MunReg = ""
                    End If

                    Telefono.Value = If(IsDBNull(dr.Item("CityB")), "", dr.Item("CityB"))
                    Contacto.Value = If(IsDBNull(dr.Item("ZipCodeB")), "", dr.Item("ZipCodeB"))
                    TextArea1.Value = If(IsDBNull(dr.Item("Comments")), "", dr.Item("Comments"))

                End While
            End If
            cnn.Close()
            dr.Close()
            '----Agregar los datos a gridview
            GVCotizacion.DataSource = DataTable
            GVCotizacion.DataBind()
            SubTotalCompra.Text = Session("RazMON") + " " + String.Format("{0:N}", Convert.ToDouble(SubTotal))
            IvaCompra.Text = Session("RazMON") + " " + String.Format("{0:N}", Convert.ToDouble(Impuesto))
            TotalCompra.Text = Session("RazMON") + " " + String.Format("{0:N}", Convert.ToDouble(Total))

        Catch ex As Exception
            cnn.Close()
            dr.Close()
            Dim fail As String = ex.Message
            ClientScript.RegisterStartupScript(Me.[GetType](), "aleasrt", "alert('" & fail & "');  ", True)
        End Try
    End Sub
    Public Sub LoadString()
        '//**Creacion 09/01/2017**//
        '---Funcion Obtener String url
        If Request.QueryString("DocNum") <> "" Then
            DocNum = Request.QueryString("DocNum")
        End If
    End Sub

    Protected Sub BtnEnviar_ServerClick(sender As Object, e As EventArgs) Handles BtnEnviar.ServerClick
        If EstatusValido = "Y" Then
            EnviarPedido()
        End If

    End Sub

    Protected Sub EnviarPedido()
        '//**Creacion 25/01/2017**//
        '//Update 25/01/2017
        Try
            'ws = New DIS.DIServer
            'ws.Url = Serveriii
            LoadString()
            Dim answer As Date = Today.AddDays(15)
            Dim fechastring = answer.ToString("yyyyMMdd")
            Dim BOMData As String = Nothing, Objeto As String = Nothing, Embarque As String = Nothing

            If TipoDoc.Checked Then
                Objeto = "oOrders"
            Else
                Objeto = "oQuotations"
            End If

            If TipoEntrega.Checked Then
                Embarque = "Entrega a Domicilio"
            Else
                Embarque = "El cliente se lo lleva"
            End If

            BOMData = "<BOM xmlns='http://www.sap.com/SBO/DIS'><BO><AdmInfo><Object>" & Objeto & "</Object>" &
                        "</AdmInfo><Documents><row> <DocDueDate>" & fechastring & "</DocDueDate><Comments>" & TextArea1.InnerText & "</Comments>" &
                        "<CardCode>" & Session("RazCode") & "</CardCode><SalesPersonCode>89</SalesPersonCode><U_embarque>" & Embarque & "</U_embarque>" &
                        "<U_PagoFiscal>" & U_PagoFiscal.Value & "</U_PagoFiscal><U_Fac>" & U_Fac.Value & "</U_Fac>" &
                        "</row></Documents><Document_Lines>"

            '--Realizar busqueda XML
            Dim Sql As String = "Select T1.LineNum,T1.ItemCode,T1.Quantity,T2.DfltWH,T1.TaxCode " &
                                "From NuevaBD.dbo.OQUT T0 " &
                                "	Inner Join NuevaBD.dbo.QUT1 T1 On (T1.DocEntry=T0.DocEntry) " &
                                "	Inner Join NuevaBD.dbo.OITM T2 On (T2.ItemCode=T1.ItemCode) " &
                                "Where T0.DocNum='" & DocNum & "'"
            'ws = New DIS.DIServer
            XmlDoc.LoadXml(ws.ExecuteSQL(Session("Token"), Sql).InnerXml)
            Node = XmlDoc.FirstChild.LastChild.Clone.ChildNodes

            '---Recorrer Busqueda
            For Each Nodo As XmlNode In Node
                BOMData = BOMData + "<row>" &
                                         "<LineNum>" & Nodo("LineNum").InnerText & "</LineNum>" &
                                         "<ItemCode>" & Nodo("ItemCode").InnerText & "</ItemCode>" &
                                         "<Quantity>" & Nodo("Quantity").InnerText & "</Quantity>" &
                                         "<WarehouseCode>" & Nodo("DfltWH").InnerText & "</WarehouseCode>" &
                                         "<TaxCode>" & Nodo("TaxCode").InnerText & "</TaxCode>" &
                                         "<SalesPersonCode>89</SalesPersonCode>" &
                                    "</row>"
            Next

            BOMData = BOMData + "</Document_Lines>" &
                                        "<AddressExtension>" &
                                            "<row>" &
                                                "<BillToStreet>" & Colonia.SelectedValue & "</BillToStreet>" &
                                                "<BillToStreetNo>" & Referencia.Value & "</BillToStreetNo>" &
                                                "<BillToBlock>" & Estado.SelectedValue & "-" & Municipio.SelectedValue & "</BillToBlock>" &
                                                "<BillToCity>" & Telefono.Value & "</BillToCity>" &
                                                "<BillToZipCode>" & Contacto.Value & "</BillToZipCode>" &
                                            "</row>" &
                                        "</AddressExtension>" &
                                "</BO></BOM>"
            Dim Respuesta As System.Xml.XmlNode = ws.AddObject(Session("Token"), BOMData, "AddOrder")

            Dim errorr As String = ReadXML(Respuesta.InnerXml, "env:Text")
            If errorr = "" Then
                If Objeto = "oOrders" Then
                    ClientScript.RegisterStartupScript(Me.[GetType](), "aleasrt", "alert('Documento creado con Exito. ');document.location.href='Catalogo';", True)
                Else
                    ClientScript.RegisterStartupScript(Me.[GetType](), "aleasrt", "alert('Documento creado con Exito.(Nota: Valido por 24Hrs) ');document.location.href='Catalogo';", True)
                End If
            Else
                errorr = Replace(errorr, "'", "")
                Me.Page.ClientScript.RegisterStartupScript(Me.GetType(), "aleasrt", "alert('" & errorr & "');document.location.href='OrdenCarrito';", True)

            End If
            System.Diagnostics.Debug.Write(ReadXML(Respuesta.InnerXml, "env:Text") & vbCrLf)
        Catch ex As Exception
            Dim fail As String = ex.Message
            ClientScript.RegisterStartupScript(Me.[GetType](), "aleasrt", "alert('" & fail & "');  ", True)
        End Try
    End Sub
End Class
