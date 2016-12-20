﻿Imports Modulo
Imports System.Xml
Imports System.Globalization
Imports System.IO
Imports System.Data
Imports ConectaClass
Partial Class View_Ventas_Orden
    Inherits System.Web.UI.Page
    Public ws As DIS.DIServer
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Session.Timeout = 20
        actualizacarritochiquito()
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
                buscarFinale()
            Catch ex As Exception
            End Try
        End If
    End Sub
    Dim Respuesta As XmlNode
    Protected Sub btnbuscar_ServerClick(sender As Object, e As EventArgs) Handles btnbuscar.ServerClick
        Session("busqueda") = barrabusqueda.Value
        Session("pagIni") = 1
        buscarFinale()

    End Sub
    Dim pattern As String = " "
    Dim elements() As String
    Public Sub buscarFinale()
        'Busqueda de facturas venciadas Balance        
        Dim tRow As New TableRow()
        Dim tCell As New TableCell()
        ws = New DIS.DIServer
        ws.Url = Serveriii
        Try
            Respuesta = ws.ExecuteSQL(Session("Token"), "select Rate from ORTT where RateDate = CONVERT (date, GETDATE()) ")
            Session("usdrate") = ReadXML(Respuesta.InnerXml, "rate")
            If Session("usdrate") > 0 Then
                Dim today As Date = DateTime.Now
                Dim fechastring = today.ToString("yyyyMMdd")
                Dim encontrados As Integer = 0
                Dim Respuesta As XmlNode
                Dim wharehose As String = txtwharehouse.Value
                Dim sqldato As String
                sqldato = "select top 1 U_arttype as tipo,U_artcan as cantidad from [Ecom].[dbo].[@IL_CONFIG_E] "
                Respuesta = ws.ExecuteSQL(Session("Token"), sqldato)
                Session("configarttype") = ReadXML(Respuesta.InnerXml, "tipo")
                Session("configartcan") = ReadXML(Respuesta.InnerXml, "cantidad")

                sqldato = "select  COUNT(*)   as disp   FROM OITW t1  " &
                "inner join OITM t2 on t1.ItemCode = t2.ItemCode" &
                " inner join OWHS t3 on t1.WhsCode = t3.WhsCode where ( t1.ItemCode like  '%119182dusdui2%' "
                pattern = " "
                elements = Regex.Split(Session("busqueda"), pattern)
                For Each element In elements
                    If element <> "" AndAlso elements.Count > 1 Then
                        sqldato = sqldato & " or t1.ItemCode like  '%" & element & "%' "
                        sqldato = sqldato & " or t2.ItemName like  '%" & element & "%' "

                    ElseIf elements.Count = 1 Then
                        sqldato = sqldato & " or t1.ItemCode like  '%" & element & "%' "
                        sqldato = sqldato & " or t2.ItemName like  '%" & element & "%' "

                    End If
                Next
                If Session("configarttype") = "stock" Then
                    sqldato = sqldato & ") and t2.validFor='Y' and t3.WhsName ='" & wharehose & "' and  (t1.OnHand - t1.IsCommited -t1.OnOrder)   &gt;0 and t2.U_IL_iva&lt;&gt;'' "
                Else
                    sqldato = sqldato & ")and t2.validFor='Y' and t3.WhsName ='" & wharehose & "'  and t2.U_IL_iva&lt;&gt;'' "

                    '            sqldato = "select  COUNT(*)   as disp   FROM OITW t1  " &
                    '"inner join OITM t2 on t1.ItemCode = t2.ItemCode" &
                    '" inner join OWHS t3 on t1.WhsCode = t3.WhsCode" &
                    ' " where  ( t1.ItemCode like  '%" & Session("busqueda") & "%' or  t1.ItemCode like '%" & Session("busqueda") & "%' or t2.ItemName like '%" & Session("busqueda") & "%' )  " &
                    '"and t3.WhsName ='" & wharehose & "' and t2.U_IL_iva&lt;&gt;'' "

                End If
                Respuesta = ws.ExecuteSQL(Session("Token"), sqldato)
                Dim totalrows As Integer = ReadXML(Respuesta.InnerXml, "disp")
                Dim twoDarray(CInt(totalrows), 10) As String
                'paginacion ***************************************
                Dim n As Integer
                Dim contapag As Integer = 0
                Dim inic As Integer
                Dim finic As Integer
                Dim configcant As Integer = Session("configartcan")
                If totalrows > configcant Then
                    Dim nacho As Integer = Math.Ceiling(totalrows / Session("configartcan"))

                    PaginationDiv.InnerHtml = " <ul class='pagination  pagination-lg'>"

                    If nacho > 1 Then
                        If nacho > 3 Then
                            'checa inicio
                            If (Session("pagIni") - 1) <= 1 Then
                                inic = 1
                            ElseIf (Session("pagIni")) = nacho Then
                                inic = (Session("pagIni") - 2)
                            Else
                                inic = (Session("pagIni") - 1)
                            End If
                            'checa final
                            If (Session("pagIni") + 1) >= nacho Then
                                finic = nacho
                            ElseIf (Session("pagIni")) = 1 Then
                                finic = (Session("pagIni") + 2)
                            Else
                                finic = (Session("pagIni") + 1)
                            End If
                            If Session("pagIni") > 1 Then
                                PaginationDiv.InnerHtml = PaginationDiv.InnerHtml + " <li style='cursor: pointer; ' class='' id='row" & (Session("pagIni") - 1) & "'       onclick='discre( id)'><a><i class='fa fa-arrow-left'></i></a></li>"
                            End If

                            If inic > 2 Then

                                PaginationDiv.InnerHtml = PaginationDiv.InnerHtml + "<li style='cursor: pointer; '  class='' id='row1'       onclick='discre( id)'><a>1</a></li><li><a>...</a></li>"

                            End If

                            For n = inic To finic
                                If n = Session("pagIni") Then
                                    PaginationDiv.InnerHtml = PaginationDiv.InnerHtml + "<li style='cursor: pointer; '  class='active' id='row" & n & "'       onclick='discre( id)'><a>" & n & "</a></li>"
                                Else
                                    PaginationDiv.InnerHtml = PaginationDiv.InnerHtml + "<li style='cursor: pointer; '  class='' id='row" & n & "'       onclick='discre( id)'><a>" & n & "</a></li>"
                                End If
                            Next
                            If (Session("pagIni") + 2) <= nacho Then
                                PaginationDiv.InnerHtml = PaginationDiv.InnerHtml + "<li><a>...</a></li><li style='cursor: pointer; '  class='' id='row" & nacho & "'       onclick='discre( id)'><a>" & nacho & "</a></li>"
                            End If
                            If Session("pagIni") < nacho Then
                                PaginationDiv.InnerHtml = PaginationDiv.InnerHtml + "<li style='cursor: pointer; '  class='' id='row" & (Session("pagIni") + 1) & "'       onclick='discre( id)'><a><i class='fa fa-arrow-right'></i></a></li>"
                            End If
                        Else
                            For n = 1 To nacho
                                If n = Session("pagIni") Then
                                    PaginationDiv.InnerHtml = PaginationDiv.InnerHtml + "<li style='cursor: pointer; '  class='active' id='row" & n & "'       onclick='discre( id)'><a>" & n & "</a></li>"
                                Else
                                    PaginationDiv.InnerHtml = PaginationDiv.InnerHtml + "<li style='cursor: pointer; '  class='' id='row" & n & "'       onclick='discre( id)'><a>" & n & "</a></li>"
                                End If
                            Next
                        End If
                        PaginationDiv.InnerHtml = PaginationDiv.InnerHtml + " </ul>"
                    Else
                        PaginationDiv.InnerHtml = ""
                    End If
                Else
                    PaginationDiv.InnerHtml = ""
                End If
                sqldato = "select  CONVERT(int,ROW_NUMBER() OVER ( ORDER BY T0.ItemCode asc)) AS 'RowNum' 			,T0.ItemCode 	 			,SUM(T1.OnHand - T1.IsCommited - T1.OnOrder) as 'disp'  			,T0.ItemName  			,ISNULL(T0.U_IL_iva, 'null') as 'iva' 			,ISNULL(CONVERT(NVARCHAR(MAX), T0.U_IL_imagen),'') as 'imag' 	 , t0.InvntryUom		from OITM T0 			inner join OITW T1 on T0.ItemCode = T1.ItemCode  			inner join OWHS t3 on T1.WhsCode = T3.WhsCode 		where T3.WhsName = '" & wharehose & "' and(t1.ItemCode like  '%119182dusdui2%'  "

                pattern = " "
                elements = Regex.Split(Session("busqueda"), pattern)
                For Each element In elements
                    If element <> "" Then
                        sqldato = sqldato & " or t1.ItemCode like  '%" & element & "%' "
                        sqldato = sqldato & " or t0.ItemName like  '%" & element & "%' "
                    ElseIf elements.Count = 1 Then
                        sqldato = sqldato & " or t1.ItemCode like  '%" & element & "%' "
                        sqldato = sqldato & " or t0.ItemName like  '%" & element & "%' "

                    End If
                Next
                sqldato = sqldato & ") and t0.validFor='Y' and T0.U_IL_iva is not null group by  			T0.ItemCode 	 , t0.InvntryUom		   ,T0.ItemName  		   ,ISNULL(T0.U_IL_iva, 'null') 		   ,CONVERT(NVARCHAR(MAX), T0.U_IL_imagen) 	 "
                ' and T0.U_IL_iva is not null
                'and t0.SellItem='Y'
                'Else
                '    sqldato = "select  CONVERT(int,ROW_NUMBER() OVER ( ORDER BY T0.ItemCode asc)) AS 'RowNum' 			,T0.ItemCode 	 			,SUM(T1.OnHand - T1.IsCommited - T1.OnOrder) as 'disp'  			,T0.ItemName  			,ISNULL(T0.U_IL_iva, 'null') as 'iva' 			,ISNULL(CONVERT(NVARCHAR(MAX), T0.U_IL_imagen),'') as 'imag' 	 , t0.InvntryUom		from OITM T0 			inner join OITW T1 on T0.ItemCode = T1.ItemCode  			inner join OWHS t3 on T1.WhsCode = T3.WhsCode 		where T3.WhsName = '" & wharehose & "' and(t1.ItemCode like  '%" & Session("busqueda") & "%'  or t0.ItemName like '%" & Session("busqueda") & "%' ) and T0.U_IL_iva is not null 		group by  			T0.ItemCode 	 , t0.InvntryUom		   ,T0.ItemName  		   ,ISNULL(T0.U_IL_iva, 'null') 		   ,CONVERT(NVARCHAR(MAX), T0.U_IL_imagen) 	 "
                'End If 
                If Session("configarttype") = "stock" Then
                    sqldato = sqldato + "having SUM( t1.OnHand - t1.IsCommited -t1.OnOrder)  &gt;0"
                End If
                '**********************************************************************************************
                '**********************************************************************************************
                '**********************************************************************************************
                'grid table
                '**********************************************************************************************
                '**********************************************************************************************
                '**********************************************************************************************

                Dim dt As New DataTable()
                Dim dr As DataRow = Nothing
                ' dt.Columns.AddRange(New DataColumn(4) {New DataColumn("col1", GetType(String)), New DataColumn("col2", GetType(String)), New DataColumn("col3", GetType(String)), New DataColumn("col4", GetType(String)), New DataColumn("col5", GetType(String))})

                dt.Columns.Add(New DataColumn("Col1", GetType(String)))
                dt.Columns.Add(New DataColumn("Col2", GetType(String)))
                dt.Columns.Add(New DataColumn("codigo", GetType(String)))
                dt.Columns.Add(New DataColumn("nombre", GetType(String)))
                dt.Columns.Add(New DataColumn("cosa", GetType(String)))
                'dr = dt.NewRow()

                'dr("Col1") = String.Empty
                'dr("Col2") = String.Empty
                'dr("codigo") = String.Empty
                'dr("nombre") = String.Empty
                'dr("cosa") = String.Empty
                'dt.Rows.Add(dr)
                ViewState("Customers") = dt

                Me.BindGrid()

                Respuesta = ws.ExecuteSQL(Session("Token"), sqldato)
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

                            Dim informacion As New ArrayList
                            For x = 0 To rootin.ChildNodes.Count - 1
                                Select Case rootin.ChildNodes(x).Name
                                    Case "RowNum"
                                        If CInt(rootin.ChildNodes(x).InnerText) > (Session("configartcan") * Session("pagIni")) Then
                                            x = rootin.ChildNodes.Count
                                            Exit Select
                                        End If
                                        If Session("pagIni") <> 1 Then
                                            If CInt(rootin.ChildNodes(x).InnerText) < (Session("configartcan") * (Session("pagIni") - 1)) Then
                                                x = rootin.ChildNodes.Count
                                                Exit Select
                                            End If
                                        End If
                                    Case "ItemCode"
                                        If rootin.ChildNodes(x).InnerText = "" Then
                                            ClientScript.RegisterStartupScript(Me.[GetType](), "aleasrt", "alert(' La busqueda no arrojo resultados ');", True)
                                            Return
                                        Else
                                            twoDarray(s, x) = rootin.ChildNodes(x).InnerText
                                            informacion.Add(rootin.ChildNodes(x).InnerText)
                                        End If
                                    Case "disp"
                                        twoDarray(s, x) = Convert.ToInt64(Math.Floor(Convert.ToDouble(rootin.ChildNodes(x).InnerText)))
                                        informacion.Add(rootin.ChildNodes(x).InnerText)
                                    Case "ItemName"
                                        twoDarray(s, x) = rootin.ChildNodes(x).InnerText
                                        informacion.Add(rootin.ChildNodes(x).InnerText)
                                    Case "iva"
                                        twoDarray(s, x + 1) = rootin.ChildNodes(x).InnerText
                                    Case "imag"
                                        If rootin.ChildNodes(x).InnerText = "" Then
                                            twoDarray(s, x + 2) = "data:image/png;base64,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"
                                        Else
                                            twoDarray(s, x + 2) = Session("ftp") + "imagenes/" + rootin.ChildNodes(x).InnerText
                                        End If
                                    Case "InvntryUom"
                                        twoDarray(s, x + 2) = rootin.ChildNodes(x).InnerText

                                End Select
                            Next x
                        End If
                    Next s
                End If

                Dim divs As String = ""
                For v = 0 To twoDarray.GetLength(0) - 1
                    If twoDarray(v, 1) = Nothing Or twoDarray(v, 5) = "null" Then
                    Else

                        encontrados = encontrados + 1
                        Dim mystring As String = "<env:Envelope xmlns:env='http://schemas.xmlsoap.org/soap/envelope/'><env:Header><SessionID>" & Session("Token") & "</SessionID></env:Header><env:Body><dis:GetItemPrice xmlns:dis='http://www.sap.com/SBO/DIS'><CardCode>" & Session("RazCode") & "</CardCode><ItemCode>" & twoDarray(v, 1) & "</ItemCode><Quantity>1</Quantity><Date>" & fechastring & "</Date></dis:GetItemPrice></env:Body></env:Envelope>"
                        Dim restring As String = ws.Interact(Session("Token"), mystring)
                        If Session("configarttype") = "stock" Then
                            twoDarray(v, 4) = ReadXML(restring, "Currency") + " " + String.Format("{0:N}", Convert.ToDouble(ReadXML(restring, "Price")))


                            dt = DirectCast(ViewState("Customers"), DataTable)
                            dr = dt.NewRow()
                            dr("Col1") = ""
                            dr("Col2") = "1"
                            dr("codigo") = twoDarray(v, 1)
                            dr("nombre") = twoDarray(v, 3)
                            dr("cosa") = twoDarray(v, 4)
                            dt.Rows.Add(dr)

                            ViewState("Customers") = dt

                            Me.BindGrid()

                            '    divs = divs + " <div class='row articulo'> <div class='col-xs-12 col-sm-3  col-md-2 col-lg-2' style='text-align: center;'>               <div  class='articuloimagen' ><img  class='articuloimagen'  src ='" & twoDarray(v, 7) & "'  />                     </div>                  </div>                  <div class='col-xs-12 col-sm-6  col-md-4 col-lg-4' style='text-align: center;'>                   " &
                            '"<a class='titulodesc'  > <span  id='title" & twoDarray(v, 1) & "'>" & twoDarray(v, 3) & "</span></a>    <div class='tituloparte'  >  Codigo de articulo: <span class='negritas'>" & twoDarray(v, 1) & "</span>                     </div>                      <div class=' '>                         " &
                            '"<span class='piezas'   id='verExistencia19090'>" & twoDarray(v, 2) & "  " & twoDarray(v, 8) & " 	disponibles </span>                      </div>                 </div>                  <div class='col-xs-12 col-sm-3  col-md-2 col-lg-2  ' style='text-align: center;'>                   " &
                            '"<div class='precio'><span  id='precio" & twoDarray(v, 1) & "'> " & twoDarray(v, 4) & "</span>   <div class='textoiva' style=''>                             IVA no incluído*                         </div>                     </div>                 </div>                  <div class='col-xs-12 col-sm-4  col-md-3 col-lg-3 ' style='text-align: center;'>           " &
                            '"<div class='botonagregar' id=' '  >                        " &
                            '"<button type='button' runat='server' id='item" & twoDarray(v, 1) & "' onclick ='envioid(id)'  class='btn btn-primary btn-sm'>                             Agregar al carrito <i class='fa fa fa-cart-plus'></i>                          </button>                     </div>                      <div class='textodisponibilidad'  >                         Disponibilidad: <span class='disponible'>En Stock</span>                     </div>                 </div>              </div>"
                        Else
                            twoDarray(v, 4) = ReadXML(restring, "Currency") + " " + String.Format("{0:N}", Convert.ToDouble(ReadXML(restring, "Price")))


                            dt = DirectCast(ViewState("Customers"), DataTable)
                            dr = dt.NewRow()
                            dr("Col1") = ""
                            dr("Col2") = "1"
                            dr("codigo") = twoDarray(v, 1)
                            dr("nombre") = twoDarray(v, 3)
                            dr("cosa") = twoDarray(v, 4)
                            dt.Rows.Add(dr)

                            ViewState("Customers") = dt

                            Me.BindGrid()

                            '    divs = divs + " <div class='row articulo'> <div class='col-xs-12 col-sm-3  col-md-2 col-lg-2 ' style='text-align: center;'>               <div  class='articuloimagen' ><img class='articuloimagen'  src ='" & twoDarray(v, 7) & "'  />                     </div>                  </div>                  <div class='col-xs-12 col-sm-6  col-md-4 col-lg-4' style='text-align: center;'>                   " &
                            '"<a class='titulodesc'  > <span  id='title" & twoDarray(v, 1) & "'>" & twoDarray(v, 3) & "</span></a>    <div class='tituloparte'  >  Codigo de articulo: <span class='negritas'>" & twoDarray(v, 1) & "</span>                     </div>                      <div class=' '>                         " &
                            '"<span class='piezas'   id='verExistencia19090'></span>                      </div>                 </div>                  <div class='col-xs-12 col-sm-3  col-md-2 col-lg-2  ' style='text-align: center;'>                   " &
                            '"<div class='precio'><span  id='precio" & twoDarray(v, 1) & "'> " & twoDarray(v, 4) & "</span>   <div class='textoiva' style=''>                             IVA no incluído*                         </div>                     </div>                 </div>                  <div class='col-xs-12 col-sm-4  col-md-3 col-lg-3 ' style='text-align: center;'>           " &
                            '"<div class='botonagregar' id=' '  >                        " &
                            '"<button type='button' runat='server' id='item" & twoDarray(v, 1) & "' onclick ='envioid(id)'  class='btn btn-primary btn-sm'>                             Agregar al carrito <i class='fa fa fa-cart-plus'></i>                          </button>                     </div>                      <div class='textodisponibilidad'  >                                            </div>                 </div>              </div>"
                        End If
                    End If
                Next v
                divs = "<div class='row ' ><div class='col-xs-12 col-sm-6  col-md-6 col-lg-6 busqueda ' style=''>    <div><font class='busquedatexto' style=''>Búsqueda  </font><font class='busquedatextovalor'  style=''>" & Session("busqueda") & "</font></div>                 </div>                  <div class='col-xs-12 col-sm-6  col-md-6 col-lg-6 '> " &
                                   "<div class='productoencontrado'>" & totalrows & " Productos Encontrados</div>                 </div>             </div> " + divs

                articuloslista.InnerHtml = divs
            Else
                ClientScript.RegisterStartupScript(Me.[GetType](), "aleasrt", "alert(' No se a definido el tipo de cambio del día. Contacte al Administrador ');document.location.href='Mensajes'; ", True)

            End If

        Catch ex As Exception
            Dim errrrorr As String = ex.Message
            ClientScript.RegisterStartupScript(Me.[GetType](), "aleasrt", "alert('" & errrrorr & "');  ", True)

        End Try
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
            actualizacarritochiquito()
            ' ClientScript.RegisterStartupScript(Me.[GetType](), "aleasrt", "alert(' Se agregó  " & articnom.Value & " al carrito') ", True)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub actualizacarritochiquito()
        Try
            Dim carrito As ArrayList = New ArrayList
            Dim carritocan As ArrayList = New ArrayList
            Dim carritoprecio As ArrayList = New ArrayList
            Dim carritoitem As ArrayList = New ArrayList
            Dim carritoiva As ArrayList = New ArrayList
            Dim mystring As String

            Dim restring As String
            Dim totalxarticulo As Double = 0
            Dim totaliva As Double = 0
            Dim totalivafinal As Double = 0
            Dim fechastring = Today.ToString("yyyyMMdd")
            Dim subtotal As Double = 0
            Dim sqldato As String
            Dim tRow As New TableRow()
            Dim tCell As New TableCell()


            Table1.Rows.Clear()
            tRow = New TableRow()
            tCell = New TableHeaderCell()
            tCell.Text = "Articulo"
            tRow.Cells.Add(tCell)
            tCell = New TableHeaderCell()
            tCell.Text = "Cantidad"
            tRow.Cells.Add(tCell)
            Table1.Rows.Add(tRow)

            If IsNothing(Session("carrito")) Then
                Table1.Visible = False

            Else
                Table1.Visible = True

                carrito = CType(Session("carrito"), ArrayList)
                carritocan = CType(Session("carritocan"), ArrayList)
                carritoprecio = CType(Session("precio"), ArrayList)
                carritoitem = CType(Session("nom"), ArrayList)


                For i As Integer = 0 To carrito.Count - 1
                    tRow = New TableRow()
                    tCell = New TableCell()
                    tCell.Text = carritoitem(i)
                    tRow.Cells.Add(tCell)
                    tCell = New TableCell()
                    tCell.Text = carritocan(i)
                    tRow.Cells.Add(tCell)
                    Table1.Rows.Add(tRow)
                Next

            End If

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub botonpagina_ServerClick(sender As Object, e As EventArgs) Handles botonpagina.ServerClick
        Session("pagIni") = idpagina.Value
        buscarFinale()
    End Sub


    Protected Sub aaaaaaaaaaaaaaa_Click(sender As Object, e As EventArgs) Handles aaaaaaaaaaaaaaa.Click
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
