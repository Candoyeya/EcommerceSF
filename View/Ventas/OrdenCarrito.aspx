<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="OrdenCarrito.aspx.vb" Inherits="View_Ventas_OrdenCarrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<!--Inicia Cuerpo pagina-->
        <div class="container-fluid">           
            <!--<div class="block-header">
                <h2>
                    JQUERY DATATABLES
                    <small>Taken from <a href="https://datatables.net/" target="_blank">datatables.net</a></small>
                </h2>
            </div>       -->     
            <!-- Exportable Table -->
            <div class="row clearfix">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <div class="card">
                        <div class="header">
                            <h3>
                                Carrito de Compra
                            </h3>
                            
                        </div>
                        
                        <div class="body"> 
                            <!--Fila 1--> 
                            <div class="row">
                                <!--Columna 1--> 
                                <div class="col-md-6">
                                    <fieldset><legend class="text-primary">Datos de Envio</legend>
                                        <!--Fila text 1--> 
                                        <div class="row">
                                            <div class="col-sm-5">
                                                <div class="input-group">
                                                    <label>Domicilio</label>
                                                    <input type="text" class="form-control" id="Domicilio" placeholder="" runat="server"/>                                                    
                                                    <br />
                                                    <br />
                                                    <br />
                                                    <label>Comunidad</label>
                                                    <input type="text" class="form-control" id="Comunidad" placeholder="" runat="server"/>
                                                    <br />
                                                    <br />
                                                    <br />
                                                    <label>Referencia</label>
                                                    <input type="text" class="form-control" id="Referencia" placeholder="" runat="server"/>  
                                                 </div>
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
                                                    <label>Hora de Envio</label>
                                                    <input type="text" class="form-control" id="Hora_E" placeholder="" runat="server"/>
                                                    <br />
                                                    <br />
                                                    <br />
                                                    <br /> 
                                                    <label><asp:CheckBox ID="CheckMail" runat="server" Checked="false"/>  Envio por Mail</label>
                                                 </div>
                                            </div>                                            
                                        </div>                                        
                                    </fieldset>                                                                       
                                </div>

                                <!--Columna 2-->
                                <div class="col-md-4">
                                    <fieldset><legend class="text-primary">Forma de Pago</legend><div class="row">
                                        <div class="col-md-9">
                                             <div class="input-group">
                                                <label>Forma de Pago</label>
                                                <select class="form-control" id="U_FPago" runat="server">
                                                    <option value="">Selecciona una opcion</option>
                                                    <option value="1">EFECTIVO</option>
                                                    <option value="2">CHEQUE</option>
                                                    <option value="3">TRANSFERENCIA</option>
                                                    <option value="4">CREDITO</option>
                                                </select>
                                                <br />
                                                <br />
                                                <br />
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
                                                    <option value="98">NA</option>
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
                                    <fieldset><legend class="text-primary">Notas</legend><div class="row">
                                        <div class="col-md-9">
                                            <textarea id="TextArea1" cols="1" rows="2" runat="server" class="form-control"></textarea> 
                                        </div>                                                                               
                                    </div></fieldset>                                      
                                </div>
                            </div>
                            <!--Fila 2--> 
                            <div class="row">
                                <div id="tablaprueba" runat="server" style="width: auto; overflow-x: auto;">
                                    <div style="min-width: 600px;">
                                        <asp:Table ID="Table1" class="table table-bordered table-striped table-hover dataTable" runat="server" Style="width: 100%; min-width: 600px">
                                            <asp:TableHeaderRow>
                                                <asp:TableHeaderCell>Articulo</asp:TableHeaderCell>
                                                <asp:TableHeaderCell>Cantidad</asp:TableHeaderCell>
                                                <asp:TableHeaderCell>Precio unitario</asp:TableHeaderCell>
                                                <asp:TableHeaderCell>Descuento</asp:TableHeaderCell>
                                                <asp:TableHeaderCell>Precio tras descuento</asp:TableHeaderCell>
                                                <%--<asp:TableHeaderCell>Descuento</asp:TableHeaderCell>--%>
                                                <asp:TableHeaderCell>Precio total</asp:TableHeaderCell>
                                                 <%--<asp:TableHeaderCell>Nota de Articulo</asp:TableHeaderCell>--%>
                                            </asp:TableHeaderRow>
                                        </asp:Table>
                                    </div>
                                </div>
                                
                            </div>   
                            
                            <!--Fila 3--> 
                            <div class="row">
                                <!--Columna 1-->
                                <div class="col-sm-10">
                                    <div class="row">
                                        <div class="col-sm-5">
                                            <br />                                            
                                            <div class="button-demo">
                                                <button type="button" runat="server" id="regresar" class="btn btn-primary waves-effect">
                                                    <i class="material-icons">add_shopping_cart</i>  Continuar agregando
                                                </button>
                                            </div>   
                                            <br /> 
                                            <div class="button-demo">
                                                <button type="button" runat="server" id="Limpiarcarro" class="btn btn-danger waves-effect">
                                                    Limpiar carrito <i class="material-icons">remove_shopping_cart</i>
                                                </button>
                                            </div>                                           
                                            
                                        </div>                                        
                                    </div>                                    
                                </div>
                                <!--Columna 2-->
                                <div class="col-sm-1">
                                    <div class="row">
                                        <div class="col-sm-5">
                                            <br />
                                            <div class="button-demo">
                                                <asp:LinkButton type="button" runat="server" ID="confirmar" OnClick="OnConfirm" class="btn btn-success waves-effect" OnClientClick="Confirm()"><i class="material-icons">shopping_cart</i>Confirmar</asp:LinkButton>
                                                                                                
                                            </div>
                                        </div>
                                    </div>                                    
                                </div> 
                            </div> 

                            <input type="text" runat="server" id="actuacan" clientidmode="Static" style="display: none" />
                            <input type="text" runat="server" id="actuaid" clientidmode="Static" style="display: none" />
                            <button id="secretbutton" runat="server" class="btn btn-default" type="button" style="display: none">dois</button>
                            <button id="cambioPorcentaje" runat="server" class="btn btn-default" type="button" style="display: none">dois</button>
                             <button id="cambioNota" runat="server" class="btn btn-default" type="button" style="display: none">dois</button>


                            <script type="text/javascript">
                                function Confirm() {
                                    var confirm_value = document.createElement("INPUT");
                                    confirm_value.type = "hidden";
                                    confirm_value.name = "confirm_value";
                                    if (confirm("Desea agregar este documento?")) {
                                        confirm_value.value = "Ok";
                                    } else {
                                        confirm_value.value = "Cancel";
                                    }
                                    document.forms[0].appendChild(confirm_value);
                                }
                            </script>

                            <%--<asp:Button ID="btnConfirm" runat="server" OnClick = "OnConfirm" Text = "Raise Confirm" OnClientClick = "Confirm()"/>--%>


                            <script>
                                function myFunction(val, id) {

                                    if (val < 1) {
                                        var confirm_value = document.createElement("INPUT");
                                        confirm_value.type = "hidden";
                                        confirm_value.name = "confirm_value";
                                        if (confirm("Desea borrar del carrito?")) {
                                            document.getElementById("actuacan").value = val;
                                            document.getElementById("actuaid").value = id.substring(3, id.length);
                                            confirm_value.value = "Ok";
                                        } else {
                                            confirm_value.value = "Cancel";
                                        }
                                        document.forms[0].appendChild(confirm_value);
                                    }
                                    else {
                                        var confirm_value = document.createElement("INPUT");
                                        confirm_value.type = "hidden";
                                        confirm_value.name = "confirm_value";
                                        confirm_value.value = "Ok";
                                        document.getElementById("actuacan").value = val;
                                        document.getElementById("actuaid").value = id.substring(3, id.length);
                                        document.forms[0].appendChild(confirm_value);
                                    }

                                    document.getElementById('<%= secretbutton.ClientID%>').click();
                                    reload();
                                }

                                function porcentaje(val, id) {
                                    document.getElementById("actuacan").value = val;
                                    document.getElementById("actuaid").value = id.substring(3, id.length);
                                    document.getElementById('<%= cambioPorcentaje.ClientID%>').click();
                                        reload();
                                    }

                                    function NotaArt(val, id) {
                                        document.getElementById("actuacan").value = val;
                                        document.getElementById("actuaid").value = id.substring(3, id.length);
                                        document.getElementById('<%= cambioNota.ClientID%>').click();
                                    reload();
                                }
                            </script>
                        </div>
                    </div>
                </div>
            </div>
            <!-- #END# Exportable Table -->           
        </div>
</asp:Content>

