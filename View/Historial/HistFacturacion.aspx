<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="HistFacturacion.aspx.vb" Inherits="HistFacturacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CP2" Runat="Server">
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
                                Historial de Facturacion
                            </h2>                            
                        </div>
                        <div class="body" runat="server">                            
                            <div class="demo-masked-input">
                                <div class="row clearfix">
                                    <div style="width: 110px; margin-left: auto; margin-right: auto">Búsqueda  por:</div> 
                                    <div style="max-width: 307px; margin-left: auto; margin-right: auto">
                                        <asp:RadioButtonList runat="server" ID="radios" onchange="return selectValue();" RepeatLayout="Flow" CssClass="labels">
                                            <asp:ListItem    Text="Mostrar facturas vencidas" Value="factuavencida"   ></asp:ListItem>
                                            <asp:ListItem  Text="Mostrar facturas vencidas por fecha" Value="factuavencidaxfecha"></asp:ListItem>
                                            <asp:ListItem Text="Mostrar facturas por fecha" Value="factuaxfecha"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>

                                    <div class="col-md-3">
                                        <b>Fecha Inicial</b>
                                        <div class="input-group">
                                            <span class="input-group-addon">
                                                <i class="material-icons">date_range</i>
                                            </span>
                                            <div class="form-line">
                                                <input runat="server" id="fecha1" type="text" class="form-control date" placeholder="Ej: 2016-11-01"/>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <b>Fecha Final</b>
                                        <div class="input-group">
                                            <span class="input-group-addon">
                                                <i class="material-icons">date_range</i>
                                            </span>
                                            <div class="form-line">
                                                <input runat="server" id="fecha2" type="text" class="form-control date" placeholder="Ej: 2016-11-01"/>
                                            </div>
                                        </div>
                                    </div>                                     
                                </div>
                            </div>
                            <div class="row clearfix demo-button-sizes" runat="server">
                                <div class="col-xs-6 col-sm-3 col-md-2 col-lg-2">
                                    <button runat="server" id="buscarfac" type="button" class="btn bg-cyan btn-block waves-effect">Filtrar</button>
                                </div>
                            </div>
                            <script>
                                //Funcion del paginado
                                function discre(id) {
                                    document.getElementById("idpagina").value = id.substring(3, id.length);
                                    document.getElementById('<%= botonpagina.ClientID%>').click();
                                    //reload(); 
                                }
                                //Funcion Para los Radio Button
                                function selectValue() {

                                    if (document.getElementById("ContentPlaceHolder1_radios_0").checked == true) {

                                        $("#ContentPlaceHolder1_radios_0").css('color', 'black');
                                        $("#ContentPlaceHolder1_radios_1").css('color', 'grey');
                                        $("#ContentPlaceHolder1_radios_2").css('color', 'grey');

                                        $("#fechas").hide();

                                    } else {
                                        $("#ContentPlaceHolder1_radios_0").css('color', 'grey');
                                        $("#ContentPlaceHolder1_radios_1").css('color', 'black');
                                        $("#ContentPlaceHolder1_radios_2").css('color', 'black');
                                        $("#fechas").show();
                                    }


                                }
                            </script>
                            <asp:Table ID="Table1" class="table table-bordered table-striped table-hover dataTable js-exportable" runat="server">
                               <asp:TableHeaderRow > 
                                    <asp:TableHeaderCell>Fecha</asp:TableHeaderCell>
                                    <asp:TableHeaderCell>Vencimiento</asp:TableHeaderCell>
                                    <asp:TableHeaderCell>Folio</asp:TableHeaderCell>
                                    <asp:TableHeaderCell>Moneda</asp:TableHeaderCell>
                                    <asp:TableHeaderCell>Cargo</asp:TableHeaderCell>
                                    <asp:TableHeaderCell>Abono</asp:TableHeaderCell>
                                    <asp:TableHeaderCell>Saldo</asp:TableHeaderCell>
                                    <asp:TableHeaderCell>Descarga</asp:TableHeaderCell>
                               </asp:TableHeaderRow>
                            </asp:Table>
                        </div>

                        <div style="text-align: center;" runat="server" id="PaginationDiv">
                        </div>

                        <!--IdCliente-->
                        <input type="text" runat="server" id="actuacan" clientidmode="Static" style="display: none" />
                        <input type="text" runat="server" id="actuaid" clientidmode="Static" style="display: none" />
                        <!--descargarpdf-->            
                        <button id="descargaboton" runat="server" class="btn btn-default" type="button" style="display: none">dois</button>
                        <button id="descargabotonpdf" runat="server" class="btn btn-default" type="button" style="display: none">dois</button>
                        <!--PAGINADO--> 
                        <input type="text" runat="server" id="idpagina" clientidmode="Static" style="display: none" />
                        <button id="botonpagina" runat="server" class="btn btn-default" type="button"   style="display: none">dois</button>
                         
                        <script>
                            <%-- function discre(id) {

                                document.getElementById("actuacan").value = 'dis';
                                document.getElementById("actuaid").value = id.substring(3, id.length);
                                document.getElementById('<%= secretbutton.ClientID%>').click();
                                //reload(); 
                            }--%>               
                            function descargapdf(id) {

                                document.getElementById("actuacan").value = 'dis';
                                document.getElementById("actuaid").value = id.substring(3, id.length);
                                document.getElementById('<%= descargabotonpdf.ClientID%>').click();

                                 //reload(); 
                            }
                            function descarga(id) {

                                document.getElementById("actuacan").value = 'dis';
                                document.getElementById("actuaid").value = id.substring(3, id.length);
                                document.getElementById('<%= descargaboton.ClientID%>').click();

                                  //reload(); 
                            }
                        </script>
                </div>
            </div>
            <!-- #END# Exportable Table -->           
        </div>
</asp:Content>

