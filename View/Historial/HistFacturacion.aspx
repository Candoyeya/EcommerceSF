<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="HistFacturacion.aspx.vb" Inherits="HistFacturacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<!--Inicia CCS-------------------------------------------------------------------------->


<!--Inicia JS------------------------------------------------------------------------------------------>     
    <script src="<%= ResolveClientUrl("~/plugins/jquery-datatable/extensions/export/dataTables.buttons.min.js") %>"></script>
    <script src="<%= ResolveClientUrl("~/plugins/jquery-datatable/extensions/export/buttons.flash.min.js") %>"></script>
    <script src="<%= ResolveClientUrl("~/plugins/jquery-datatable/extensions/export/jszip.min.js") %>"></script>
    <script src="<%= ResolveClientUrl("~/plugins/jquery-datatable/extensions/export/pdfmake.min.js") %>"></script>
    <script src="<%= ResolveClientUrl("~/plugins/jquery-datatable/extensions/export/vfs_fonts.js") %>"></script>
    <script src="<%= ResolveClientUrl("~/plugins/jquery-datatable/extensions/export/buttons.html5.min.js") %>"></script>
    <script src="<%= ResolveClientUrl("~/plugins/jquery-datatable/extensions/export/buttons.print.min.js") %>"></script>

    <script>

    </script>
                
    <!--Inicia Cuerpo pagina-->
        <div class="container-fluid">
            <div class="row clearfix">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <div class="card">
                        <div class="header">
                            <div class="col-lg-5 col-md-5 col-sm-5 col-xs-12">
                                <div class="info-box bg-red hover-zoom-effect">
                                    <div class="icon">
                                        <i class="material-icons">insert_drive_file</i>
                                    </div>
                                    <div class="content">
                                        <div class="text"><h3>Historial de Facturacion</h3></div>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <br />
                            <br /> 
                            <h3>                                
                            </h3>
                             <!-- Cuerpo-->                             
                        </div>
                        <div class="body"> 
                            <asp:ScriptManager id="ScriptManager1" runat="server"></asp:ScriptManager>
                            <asp:UpdatePanel id="UpdatePanel1" UpdateMode="Conditional" runat="server">
                                <ContentTemplate>
                                     <!--Fila 1--> 
                                    <div class="row">
                                        <!--Columna 1-->  
                                        <div class="col-lg-5 col-md-5" ></div>
                                        <!--Columna 2-->  
                                        <div class="col-lg-4 col-md-4">
                                            <h4><span>Búsqueda por:</span></h4>
                                            <div class="demo-radio-button">
                                                <asp:RadioButtonList ID="RbRadios" runat="server" class="radio-col-light-green" RepeatLayout="Flow" AutoPostBack="true" CausesValidation="false">
                                                    <asp:ListItem Text="Mostrar facturas vencidas" Value="RbFacVen"></asp:ListItem>
                                                    <asp:ListItem Text="Mostrar facturas vencidas por fecha" Value="RbFacVenxFec"></asp:ListItem>
                                                    <asp:ListItem Text="Mostrar facturas por fecha" Value="RbFacFec"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </div>
                                        </div>
                                        <!--Columna 3-->  
                                        <div class="col-lg-4 col-md-4"></div>
                                    </div>
                                    <!--Fila 2--> 
                                    <div class="row">
                                        <!--Columna 1-->  
                                        <div class="col-lg-3 col-md-3"></div>
                                        <!--Columna 2-->  
                                        <div runat="server" id="Vista" >
                                            <div class="col-lg-3 col-md-3">
                                                <div class="input-group date" data-provide="datepicker">
                                                    <input type="date" id="DtpInicial" runat="server" class="form-control" />
                                                    <div class="input-group-addon"><i class="material-icons">date_range</i></div>
                                                </div>
                                            </div>
                                            <div class="col-lg-3 col-md-3">
                                                <div class="input-group date" data-provide="datepicker">
                                                    <input type="date" id="DtpFin" runat="server" class="form-control" />
                                                    <div class="input-group-addon"><i class="material-icons">date_range</i></div>
                                                </div>
                                            </div>
                                             <!--<asp:Label runat="server" ID="dato"></asp:Label>-->
                                        </div>
                                        <!--Columna 3-->  
                                        <div class="col-lg-5 col-md-5"></div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <!--Fila 3--> 
                            <div class="row">
                                <!--Columna 1-->  
                                <div class="col-lg-5 col-md-5"></div>
                                <div class="col-lg-3 col-md-3">
                                    <div class="button-demo">
                                        <button type="button" runat="server" id="BtnBuscar" class="btn btn-success waves-effect"><i class="material-icons">search</i><span>   Buscar</span></button>
                                    </div>
                                </div>
                                <div class="col-lg-4 col-md-4"></div>
                            </div>
                            <!--Fila 3--> 
                            <div class="row">
                                <!--Columna 1-->  
                                <div class="col-lg-11 col-md-11">
                                    <asp:GridView ID="GvFacturas" runat="server" ShowFooter="false" AutoGenerateColumns="False"
                                         ShowHeaderWhenEmpty="true" 
                                         CellPadding="4" GridLines="None" Class="table table-bordered table-striped table-hover dataTable">
                                       
                                        <Columns>
                                            <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                                            <asp:BoundField DataField="Vencimiento" HeaderText="Vencimiento" />
                                            <asp:BoundField DataField="Folio" HeaderText="Folio" />
                                            <asp:BoundField DataField="Moneda" HeaderText="Moneda" />
                                            <asp:BoundField DataField="Cargo" HeaderText="Cargo" />
                                            <asp:BoundField DataField="Abono" HeaderText="Abono" />
                                            <asp:BoundField DataField="Saldo" HeaderText="Saldo" />
                                            <asp:TemplateField HeaderText="PDF" runat="server" >
                                                <ItemTemplate>
                                                    <asp:LinkButton runat="server" ID="BtnDescargar" OnClick="BtnDescarga_Click" CssClass="btn btn-success waves-effect"><i class="material-icons">file_download</i>Descargar</asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                </div>
            </div>         
        </div>
</div>
<%--Script java...--%>
    <%--Cargar tabla con opciones y traducir al español...--%>
    <%--Ultima actualizacion 27/01/2017...--%>
<script>
    $(document).ready(function () {
        $(".table").prepend($("<thead></thead><tfoot></tfoot>").append($(this).find("tr:first"))).dataTable({
            dom: 'Bfrtip',
            buttons: [
                'copy', 'csv', 'excel', 'pdf', 'print'
            ]
        });
        $("#GvFacturas").DataTable();
    });
</script>
</asp:Content>

