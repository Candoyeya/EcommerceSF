<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Embarques.aspx.vb" Inherits="Embarques" %>

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
                                <div class="info-box bg-blue hover-zoom-effect">
                                    <div class="icon">
                                        <i class="material-icons">check_box</i>
                                    </div>
                                    <div class="content">
                                        <div class="text"><h3>Confirmar Pedido</h3></div>
                                    </div>
                                </div>
                            </div> 
                            <br />
                            <br />
                            <br />
                            <h3>                                
                            </h3> 
                        </div>
                        <div class="body">
                            <asp:Table ID="Table1" class="table table-bordered table-striped table-hover dataTable" runat="server">
                               <asp:TableHeaderRow >  
                                    <asp:TableHeaderCell>Fecha</asp:TableHeaderCell>
                                    <asp:TableHeaderCell>Entrega</asp:TableHeaderCell>
                                    <asp:TableHeaderCell>Pedido</asp:TableHeaderCell>
                                    <asp:TableHeaderCell>Destino</asp:TableHeaderCell>
                                    <asp:TableHeaderCell>Guia</asp:TableHeaderCell>
                                    <asp:TableHeaderCell>Discrepancia</asp:TableHeaderCell>
                                    <asp:TableHeaderCell>Confirmar</asp:TableHeaderCell>
                               </asp:TableHeaderRow>
                            </asp:Table>

                            <div style="text-align: center;" runat="server" id="PaginationDiv"></div> 
                            <button id="botonpagina" runat="server" class="btn btn-default" type="button" style="display: none">dois</button>
                            <input type="text" runat="server" id="idpagina" clientidmode="Static" style="display: none" />  
                            <input type="text" runat="server" id="actuacan" clientidmode="Static" style="display: none"  />
                            <input type="text" runat="server" id="actuaid" clientidmode="Static" style="display: none" />
                            <div class="icon-button-demo">
                            <button id="secretbutton" runat="server" class="btn btn-default" type="button" style="display: none">dois</button>
                            </div>

                            <script>
                                function ver(id) {
                                    document.getElementById("idpagina").value = id.substring(3, id.length);
                                    document.getElementById('<%= botonpagina.ClientID%>').click();
                                     //reload(); 
                                }
                                function confirpedido(id) {                     
                                    document.getElementById("actuacan").value = 'confir';
                                    document.getElementById("actuaid").value = id.substring(3, id.length); 
                                     document.getElementById('<%= secretbutton.ClientID%>').click(); 
                                    //reload();
                                }
                                function discre(id) {                     
                                    document.getElementById("actuacan").value = 'dis';
                                    document.getElementById("actuaid").value = id.substring(3, id.length); 
                                     document.getElementById('<%= secretbutton.ClientID%>').click(); 
                                    //reload(); 
                                }
                            </script>
                        </div>
                    </div>
                </div>
            </div>
            <!-- #END# Exportable Table -->           
        </div>
<%--Script java...--%>
    <%--Cargar tabla con opciones y traducir al español...--%>
    <%--Ultima actualizacion 23/12/2016...--%>
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

