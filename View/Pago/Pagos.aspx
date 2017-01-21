<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Pagos.aspx.vb" Inherits="Pagos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
       <!--Inicia Cuerpo pagina-->

        <div class="container-fluid"> 
            <div class="row clearfix">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <div class="card">
                        <div class="header">
                            <div class="col-lg-5 col-md-5 col-sm-5 col-xs-12">
                                <div class="info-box bg-green hover-zoom-effect">
                                    <div class="icon">
                                        <i class="material-icons">monetization_on</i>
                                    </div>
                                    <div class="content">
                                        <div class="text"><h3>Pagos</h3></div>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <br />
                            <br /> 
                            <h3>
                            </h3>                            
                        </div>
                        <div class="body" runat="server">                            
                            <div class="demo-masked-input">
                                <div class="row clearfix">
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
                                    <button runat="server" id="buscaredo" type="button" class="btn bg-cyan btn-block waves-effect">BUSCAR</button>
                                </div>
                            </div>
                            <script>
                                function discre(id) {
                                    document.getElementById("idpagina").value = id.substring(3, id.length);
                                    document.getElementById('<%= botonpagina.ClientID%>').click();
                                    //reload(); 
                                }                               
                            </script>
                            <asp:Table ID="Table1" class="table table-bordered table-striped table-hover dataTable js-exportable" runat="server">
                               <asp:TableHeaderRow > 
                                    <asp:TableHeaderCell>Fecha de pago</asp:TableHeaderCell>
                                    <asp:TableHeaderCell>Pago</asp:TableHeaderCell>
                                    <asp:TableHeaderCell>Factura</asp:TableHeaderCell>
                                    <asp:TableHeaderCell>Moneda</asp:TableHeaderCell>
                                    <asp:TableHeaderCell>Total</asp:TableHeaderCell>
                                    <asp:TableHeaderCell>Importe</asp:TableHeaderCell> 
                               </asp:TableHeaderRow>
                            </asp:Table>
                        </div>
                        <input type="text" runat="server" id="idpagina" clientidmode="Static" style="display: none" />
                         <button id="botonpagina" runat="server" class="btn btn-default" type="button"   style="display: none">dois</button>

                          <div style="text-align: center;" runat="server" id="PaginationDiv">
                    </div>
                </div>
            </div>
            <!-- #END# Exportable Table -->           
        </div>
<%--Script java...--%>
    <%--Cargar tabla con opciones y traducir al español...--%>
    <%--Ultima actualizacion 12/01/2017...--%>
<script>
        $(document).ready(function () {
            $(".table").prepend($("<thead></thead><tfoot></tfoot>").append($(this).find("tr:first"))).dataTable({
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
            $('#Table1').DataTable();
    } );
</script>
</asp:Content>

