<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="VerCotizaciones.aspx.vb" Inherits="View_Ventas_VerCotizaciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<link href="https://gitcdn.github.io/bootstrap-toggle/2.2.2/css/bootstrap-toggle.min.css" rel="stylesheet"/>
<script src="https://gitcdn.github.io/bootstrap-toggle/2.2.2/js/bootstrap-toggle.min.js"></script>
<!--Inicia Cuerpo pagina-->
        <div class="container-fluid">  
            <div class="row clearfix">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <div class="card">
                        <!--Titulo de la pagina--> 
                        <div class="header">                            
                            <div class="col-lg-5 col-md-5 col-sm-5 col-xs-12">
                                <div class="info-box bg-green hover-zoom-effect">
                                    <div class="icon">
                                        <i class="material-icons">shopping_cart</i>
                                    </div>
                                    <div class="content">
                                        <div class="text"><h3>Vista de Cotizacion</h3></div>
                                    </div>
                                </div>
                            </div>                    
                            <br />
                            <br />
                            <br />
                            <h3></h3>
                        </div>
                        <!--Cuerpo Pagina 1--> 
                        <div class="body"> 
                            <asp:ScriptManager id="ScriptManager1" runat="server"></asp:ScriptManager>
                            <!--Fila 1--> 
                            <div class="row">
                                <!--Columna 1--> 
                                <div class="col-lg-4 col-md-2"></div>
                                    <div id="Advertencia" runat="server" class="col-lg-4 col-md-4"></div>
                                <div class="col-lg-4 col-md-2"></div>
                            </div>
                            <!--Fila 2--> 
                            <div class="row">
                                <!--Columna 1--> 
                                <div class="col-lg-2 col-md-2">
                                    <label>Realizar: </label><br />
                                    <input id="TipoDoc" runat="server" type="checkbox" checked data-toggle="toggle" data-on="Pedido" data-off="Cotizacion" data-onstyle="success" data-offstyle="info"/>
                                    <br />
                                    <br />
                                    <br />
                                    <label>Forma de Entrega: </label>
                                    <input id="TipoEntrega" runat="server" type="checkbox" checked data-toggle="toggle" data-on="Entrega Domicilio" data-off="Paso por el" data-onstyle="success" data-offstyle="info"/>
                                </div>
                                <!--Columna 2--> 
                                <div class="col-lg-10 col-md-10">
                                    <fieldset>
                                        <legend class="text-primary">Datos del Cliente</legend>                                       
                                        <div class="row">
                                            <div class="col-lg-4 col-md-4">
                                                <h4><span class="label label-default">Cliente:</span><asp:Label Id="DatoCliente" runat="server"></asp:Label></h4>
                                                <h4><span class="label label-default">Nombre:</span><asp:Label ID="DatoNombre" runat="server"></asp:Label></h4>
                                            </div>
                                            <div class="col-lg-4 col-md-4">
                                                <h4><span class="label label-default">RFC:</span><asp:Label id="DatoRFC" runat="server"></asp:Label></h4>
                                                <h4><span class="label label-default">Condicion de Pago:</span><asp:Label ID="DatoCP" runat="server"></asp:Label></h4>
                                            </div>
                                            <div class="col-lg-4 col-md-4">
                                                <h4><span class="label label-default">Cuenta de Bancos:</span><asp:Label ID="DatoCB" runat="server"></asp:Label></h4>
                                            </div>
                                        </div>                                        
                                    </fieldset>
                                </div>
                                <!--Columna 3--> 
                                <div class="col-md-1"></div>
                            </div>
                            <!--Fila 3--> 
                            <div class="row">                                
                                <!--Columna 1--> 
                                <div class="col-md-6">
                                    <fieldset><legend class="text-primary">Datos de Envio</legend>
                                        <!--Fila text 1--> 
                                        <div class="row">
                                            <div class="col-sm-5">                                                
                                                <asp:UpdatePanel id="UpdatePanel1" UpdateMode="Conditional" runat="server">
                                                    <ContentTemplate>
                                                        <div class="input-group">                                                                                                        
                                                            <label>Estado</label>
                                                            <asp:DropDownList ID="Estado" runat="server" CssClass="form-control" AutoPostBack="true" CausesValidation="false" ></asp:DropDownList>
                                                            <br />
                                                            <br />
                                                            <br />
                                                            <label>Municipio</label>
                                                            <asp:DropDownList ID="Municipio" runat="server" CssClass="form-control" AutoPostBack="true" CausesValidation="false"></asp:DropDownList>
                                                            <br />
                                                            <br />
                                                            <br />
                                                            <label>Colonia</label>
                                                            <asp:DropDownList ID="Colonia" runat="server" CssClass="form-control"></asp:DropDownList>
                                                            <br />
                                                            <br />
                                                            <br />
                                                            <label>Referencia</label>
                                                            <input type="text" class="form-control" id="Referencia" placeholder="Calle/# Externo/Ubicacion" runat="server"/>  
                                                         </div>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>                                                
                                            </div>
                                            <div class="col-sm-5">
                                                <div class="input-group">
                                                    <label>Telefono</label>
                                                    <input type="text" class="form-control" id="Telefono" placeholder="" runat="server"/>
                                                    <br />
                                                    <br />
                                                    <br />
                                                    <label>Contacto</label>
                                                    <input type="text" class="form-control" id="Contacto" placeholder="" runat="server"/>                                                    
                                                     <br />
                                                    <br />
                                                    <br />
                                                    <br /> 
                                                    <label><asp:CheckBox ID="CheckMail" runat="server" Checked="false" Enabled="False" />  Envio por Mail</label>
                                                 </div>
                                            </div>                                            
                                        </div>                                        
                                    </fieldset>                                                                       
                                </div>
                                <!--Columna 2--> 
                                <div class="col-sm-1">
                                </div>
                                <!--Columna 3-->
                                <div class="col-md-5">                                    
                                    <fieldset><legend class="text-primary">Forma de Pago</legend><div class="row">
                                        <div class="col-md-9">
                                             <div class="input-group">                                                
                                                <label>Forma de Pago Fiscal</label>
                                                <select class="form-control" id="U_PagoFiscal" runat="server">
                                                    <option value="">Selecciona una opcion</option>
                                                    <option value="01">Efectivo.</option>
                                                    <option value="02">Cheque Nominativo.</option>
                                                    <option value="03">Transferencia Electronica de f</option>
                                                    <option value="04">Tarjeta de Credito</option>
                                                    <option value="05">Monedero Electronico</option>
                                                    <option value="06">Dinero Electronico</option>
                                                    <option value="08">Vales de Despensa</option>
                                                    <option value="28">Tarjeta de Debito</option>
                                                    <option value="29">Tarjeta de Servicio.</option>
                                                    <option value="NA">NA</option>
                                                    <option value="99">Otros.</option>
                                                </select> 
                                                 <br />
                                                <br />
                                                <br />
                                                <label>Requiere Factura</label>
                                                <select class="form-control" id="U_Fac" runat="server">
                                                    <option value="">Selecciona una opcion</option>
                                                    <option value="01">SI</option>
                                                    <option value="02">NO</option>                                                    
                                                </select> 
                                             </div>
                                        </div>                                                                               
                                    </div></fieldset> 
                                    <fieldset><legend class="text-primary">Comentarios:</legend><div class="row">
                                        <div class="col-md-9">
                                            <textarea id="TextArea1" cols="1" rows="2" runat="server" class="form-control"></textarea> 
                                        </div>                                                                               
                                    </div></fieldset>                                      
                                </div>
                            </div>   
                            <!--Fila 4--> 
                            <div class="row">                                
                                <div id="tablaprueba" runat="server" style="width: auto; overflow-x: auto;">
                                    <div style="min-width: 600px;">                                        
                                        <asp:UpdatePanel id="UpdatePanel2" UpdateMode="Conditional" runat="server">
                                            <ContentTemplate>
                                                <asp:GridView ID="GVCotizacion" runat="server" ShowFooter="false" AutoGenerateColumns="False"
                                                                ShowHeaderWhenEmpty="true" EmptyDataText = "No hay Coincidencias"
                                                                CellPadding="4" GridLines="None" Class="gvv display">
                                                    <Columns>
                                                        <asp:BoundField DataField="ItemName" HeaderText="Articulo" HeaderStyle-Height="5" HeaderStyle-Width="350"/>
                                                        <asp:BoundField DataField="Quantity" HeaderText="Cantidad" />
                                                        <asp:BoundField DataField="Price" HeaderText="Precio unitario" />
                                                        <asp:BoundField DataField="LineTotal" HeaderText="Precio total" />
                                                    </Columns>
                                                </asp:GridView>
                                                
                                                 <%--Script java...--%>
                                                    <%--Cargar tabla con opciones y traducir al español...--%>
                                                    <%--Ultima actualizacion 23/01/2017...--%>
                                                <script>
                                                        $(document).ready(function () {
                                                            $(".gvv").prepend($("<thead></thead><tfoot></tfoot>").append($(this).find("tr:first"))).dataTable({
                                                                "language":
                                                                {
                                                                    "sProcessing": "Procesando...",
                                                                    "sLengthMenu": "Mostrar _MENU_ registros",
                                                                    "sZeroRecords": "No se encontraron resultados",
                                                                    "sEmptyTable": "Ningún dato disponible en esta tabla",
                                                                    "sInfo": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
                                                                    "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
                                                                    "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
                                                                    "sInfoPostFix": "",
                                                                    "sSearch": "Buscar en resultados:",
                                                                    "sUrl": "",
                                                                    "sInfoThousands": ",",
                                                                    "sLoadingRecords": "Cargando...",
                                                                    "oPaginate": {
                                                                        "sFirst": "Primero",
                                                                        "sLast": "Último",
                                                                        "sNext": "Siguiente",
                                                                        "sPrevious": "Anterior"
                                                                    },
                                                                    "oAria": {
                                                                        "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
                                                                        "sSortDescending": ": Activar para ordenar la columna de manera descendente"
                                                                    }
                                                                }
                                                            });
                                                            $('#GVCotizacion').DataTable();
                                                    } );
                                                </script>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        
                                    </div>
                                </div>  
                            </div>
                            <!--Fila 5--> 
                            <div class="row" runat="server">
                                <!--Columna 1-->
                                <div class="col-sm-9"></div>
                                <!--Columna 2-->
                                <div class="col-sm-3" runat="server">
                                    <div class="input-group" runat="server">
                                        <br />                                                                                                                                 
                                    </div>
                                    <asp:Table id="totales" runat="server" CssClass="table">
                                        <asp:TableRow>
                                            <asp:TableHeaderCell CssClass="info" Text="SubTotal:" Font-Size="Medium"></asp:TableHeaderCell>
                                            <asp:TableCell><h4><asp:Label ID="SubTotalCompra" runat="server" Text="" Font-Size="Medium"></asp:Label></h4></asp:TableCell>
                                        </asp:TableRow>
                                        <asp:TableRow>
                                            <asp:TableHeaderCell CssClass="warning" Text="Impuesto:" Font-Size="Medium"></asp:TableHeaderCell>
                                            <asp:TableCell><h4><asp:Label ID="IvaCompra" runat="server" Text="" Font-Size="Medium"></asp:Label></h4></asp:TableCell>
                                        </asp:TableRow>
                                        <asp:TableRow>
                                            <asp:TableHeaderCell CssClass="success" Text="Total:" Font-Size="Medium"></asp:TableHeaderCell>
                                            <asp:TableCell><h4><asp:Label ID="TotalCompra" runat="server" Text="" Font-Size="Medium"></asp:Label></h4></asp:TableCell>
                                        </asp:TableRow>  
                                    </asp:Table>
                                </div>
                            </div>   
                            <!--Fila 6--> 
                            <div class="row">
                                <!--Columna 1-->
                                <div class="col-sm-10"></div>
                                <!--Columna 2-->
                                <div class="col-sm-1">
                                    <div class="row">
                                        <div class="col-sm-5">
                                            <br />
                                            <div class="button-demo">
                                                <asp:LinkButton type="button" runat="server" ID="BtnEnviar" class="btn btn-success waves-effect"><i class="material-icons">shopping_cart</i>Realizar Pedido</asp:LinkButton>
                                            </div>
                                        </div>
                                    </div>                                    
                                </div> 
                            </div> 
                        </div>
                    </div>
                </div>
            </div>
            <!-- #END# Exportable Table -->           
        </div>
</asp:Content>

