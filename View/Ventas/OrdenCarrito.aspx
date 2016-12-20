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
                            <h2>
                                Carrito de Compra
                            </h2>
                            
                        </div>
                        
                        <div class="body">    
                            <button type="button" runat="server" id="Limpiarcarro" class="btn btn-default btn-md" style="float: right;">
                                Limpiar carrito <i class="fa fa-trash "></i>
                            </button>


                            <br />
                            <br />

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
                                            <asp:TableHeaderCell>Nota de Articulo</asp:TableHeaderCell>
                                        </asp:TableHeaderRow>
                                    </asp:Table>

                                </div>

                            </div>
                            <asp:CheckBox ID="CheckMail" runat="server" Checked  />  Envio por Mail


                            <div style="width: 180px; margin-left: auto">
                                Notas:<textarea id="TextArea1" cols="20" rows="2" runat="server" class="form-control"></textarea>
                            </div>
                            <br />


                            <button type="button" runat="server" id="regresar" class="btn btn-default btn-md" style="">
                                <i class="fa fa-arrow-left"></i>Continuar agregando

                            </button>


                            <asp:Button type="button" runat="server" ID="confirmar" Text="confirmar" OnClick="OnConfirm" class="btn btn-default btn-md" OnClientClick="Confirm()" Style="float: right" />


                            <br />
                            <br />
                            <br />
                            <br />


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

