<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Cotizaciones.aspx.vb" Inherits="View_Ventas_Cotizaciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                <div class="card">
                    <!--Titulo pagina-->
                    <div class="header">
                        <div class="col-lg-5 col-md-5 col-sm-5 col-xs-12">
                            <div class="info-box bg-green hover-zoom-effect">
                                <div class="icon">
                                    <i class="material-icons">shopping_basket</i>
                                </div>
                                <div class="content">
                                    <div class="text"><h3>Cotizaciones</h3></div>
                                </div>
                            </div>
                        </div>
                        <br />
                        <br />
                        <br /> 
                        <h3>
                        </h3>                            
                    </div>
                    <!--Cuerpo pagina-->
                    <div class="body">
                        <!--Fila 1-->    
                        <div class="row">
                            <!--Columna 1-->  
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                <asp:GridView ID="GVCotizaciones" runat="server" CssClass="gvv display" GridLines="None" AutoGenerateColumns="False">
                                    <EmptyDataRowStyle forecolor="Red" CssClass="gvv display" />
                                    <emptydatatemplate>
                                        No hay cotizaciones Realizadas  
                                    </emptydatatemplate>
                                    <Columns>
                                        <asp:BoundField HeaderText="Folio:" DataField="DocNum" ItemStyle-CssClass="active" />
                                        <asp:BoundField HeaderText="Fecha:" DataField="DocDate" ItemStyle-CssClass="active" />
                                        <asp:BoundField HeaderText="Total Articulos" DataField="Filas" ItemStyle-CssClass="active" HeaderStyle-Height="10" HeaderStyle-Width="150"/>
                                        <asp:BoundField HeaderText="Total" DataField="DocTotal" ItemStyle-CssClass="active" />
                                        <asp:HyperLinkField HeaderText="Visualizar" 
                                                            DataNavigateUrlFields="DocNum"
                                                            DataNavigateUrlFormatString="../../View/Ventas/VerCotizaciones.aspx?DocNum={0}" 
                                                            Text='<div class="icon-button-demo"><button type="button" class="btn btn-success btn-circle-lg waves-effect waves-circle waves-float"><i class="material-icons">chrome_reader_mode</i></button></div>' />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                    <!--TERMINA pagina-->
                </div>
            </div>
        </div>
    </div>
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
                    "sSearch": "Buscar Cotizaciones:",
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
            $('#GVCotizaciones').DataTable();
    } );
</script>
</asp:Content>

