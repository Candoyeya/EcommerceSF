<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Catalogo.aspx.vb" Inherits="View_Ventas_Catalogo" %>

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
                            <div class="col-lg-5 col-md-5 col-sm-5 col-xs-12">
                                <div class="info-box bg-green hover-zoom-effect">
                                    <div class="icon">
                                        <i class="material-icons">store</i>
                                    </div>
                                    <div class="content">
                                        <div class="text"><h3>Catalogos</h3></div>
                                    </div>
                                </div>
                            </div> 
                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                <br />
                                <br />
                                <div class="input-group">
                                    <input id="Articulo" runat="server" type="text" class="form-control" placeholder="Buscar Articulo..."/>
                                    <span class="input-group-btn" runat="server">
                                    <button id="BtnBuscar" runat="server" class="btn btn-default" type="button">
                                        <i class="material-icons">search</i>
                                    </button>
                                    </span>
                                </div><!-- /input-group -->
                            </div>
                            <br />
                            <br />
                            <br />
                            <h3></h3>
                        </div>
                        <!--Cuerpo pagina-->
                        <div class="body">
                            <!--Fila 1--> 
                            
                            <!--Fila 2-->    
                            <div class="row">
                                <asp:GridView ID="GvCatalogo" runat="server" Wrap="False" 
                                              ShowFooter="false" AutoGenerateColumns="False"
                                              GridLines="None" Class="gvv display">
                                    <Columns>
                                         <%--campos imagen catalogo...--%>
                                        <asp:TemplateField HeaderStyle-Height="10" HeaderStyle-Width="100" ItemStyle-Height="100" ItemStyle-Width="200">                                            
                                            <ItemTemplate >
                                                <img alt='' src="<%# Eval("CatalogoIMG") %>" width="150" height="150" class="img-rounded"/>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         <%--campos Nombre...--%>
                                        <asp:BoundField HeaderText="Catalogo" DataField="Nombre" ItemStyle-CssClass="active" />
                                        <%--campos Boton de visualizar...--%>
                                        <asp:HyperLinkField HeaderText="Visualizar" 
                                                            DataNavigateUrlFields="Grupo" 
                                                            DataNavigateUrlFormatString="../../View/Ventas/Orden.aspx?Grupo={0}" 
                                                            Text='<div class="icon-button-demo"><button type="button" class="btn btn-success btn-circle-lg waves-effect waves-circle waves-float"><i class="material-icons">chrome_reader_mode</i></button></div>' />
                                    </Columns>
                                </asp:GridView>
                            </div>
                            <%--++++++++++++++++++++++++++++++++++++++++--%>
                            <div runat="server" id="Constructor"></div>
                            <%--+++++++++++++++++++++++++++++++++++++++++--%>
                        </div>
                    </div>
                </div>
            </div>
            <!-- #END# Exportable Table -->           
        </div>
<%--Script java...--%>
    <%--Cargar tabla con opciones y traducir al español...--%>
    <%--Ultima actualizacion 09/01/2017...--%>
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
                    "sSearch": "Buscar Catalogo:",
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
            $('#GvCatalogo').DataTable();
    } );
</script>
</asp:Content>

