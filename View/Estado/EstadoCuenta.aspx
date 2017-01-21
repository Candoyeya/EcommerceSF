<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="EstadoCuenta.aspx.vb" Inherits="EstadoCuenta" %>

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
                                <div class="info-box bg-orange hover-zoom-effect">
                                    <div class="icon">
                                        <i class="material-icons">view_list</i>
                                    </div>
                                    <div class="content">
                                        <div class="text"><h3>Estado de Cuenta</h3></div>
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
                            <asp:Table ID="Table1" class="table table-bordered table-striped table-hover dataTable js-exportable" runat="server">
                               <asp:TableHeaderRow > 
                                    <asp:TableHeaderCell>Fecha Contabilización</asp:TableHeaderCell>
                                    <asp:TableHeaderCell>Numero de origen</asp:TableHeaderCell>
                                    <asp:TableHeaderCell>Cuenta de contrapartida</asp:TableHeaderCell>
                                    <asp:TableHeaderCell>Información  Detallada</asp:TableHeaderCell>
                                    <asp:TableHeaderCell>Saldo Vencido</asp:TableHeaderCell>
                                    <asp:TableHeaderCell>Saldo Vencido FC</asp:TableHeaderCell> 
                               </asp:TableHeaderRow>
                            </asp:Table>
                        </div>
                    </div>
                </div>
            </div>
            <!-- #END# Exportable Table -->           
        </div>
<%--Script java...--%>
    <%--Cargar tabla con opciones y traducir al español...--%>
    <%--Ultima actualizacion 21/12/2016...--%>
<script>
        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable({
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
                    "sSearch": "Buscar:",
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

