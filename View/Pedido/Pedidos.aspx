<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Pedidos.aspx.vb" Inherits="Pedidos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<!--Inicia Cuerpo pagina-->

        <div class="container-fluid">  
            <!-- Exportable Table -->
            <div class="row clearfix">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <div class="card">
                        <div class="header">
                            <div class="col-lg-5 col-md-5 col-sm-5 col-xs-12">
                                <div class="info-box bg-grey hover-zoom-effect">
                                    <div class="icon">
                                        <i class="material-icons">local_shipping</i>
                                    </div>
                                    <div class="content">
                                        <div class="text"><h3>Pedidos Pendientes</h3></div>
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
                            <asp:Table ID="Table1" class="table table-bordered table-striped table-hover dataTable js-exportable" runat="server">
                               <asp:TableHeaderRow >  
                                   <asp:TableHeaderCell>Fecha</asp:TableHeaderCell>
                                   <asp:TableHeaderCell>Numero de pedido</asp:TableHeaderCell>
                                   <asp:TableHeaderCell>Comentarios</asp:TableHeaderCell>
                                   <asp:TableHeaderCell>Importe</asp:TableHeaderCell>
                                   <asp:TableHeaderCell>Ver documento</asp:TableHeaderCell>
                               </asp:TableHeaderRow>
                            </asp:Table>

                            <div style="text-align: center;" runat="server" id="PaginationDiv"></div> 
                            <input type="text" runat="server" id="actuacan" clientidmode="Static" style="display: none" />
                            <input type="text" runat="server" id="actuaid" clientidmode="Static" style="display: none" />
                            <button id="secretbutton" runat="server" class="btn btn-default" type="button" style="display: none">dois</button>
                            <button id="botonpagina" runat="server" class="btn btn-default" type="button" style="display: none">dois</button>
                            <input type="text" runat="server" id="idpagina" clientidmode="Static" style="display: none" />
                            

                            <script>
                
                                function ver(id) { 
                                    document.getElementById("actuacan").value = 'dis';
                                    document.getElementById("actuaid").value = id.substring(3, id.length);
                                    document.getElementById('<%= secretbutton.ClientID%>').click();
                                    //reload(); 
                                }
                                function discre(id) {
                                    document.getElementById("idpagina").value = id.substring(3, id.length);
                                    document.getElementById('<%= botonpagina.ClientID%>').click();
                                      //reload(); 
                                    }
                            </script>
                        </div>
                    </div>
                </div>
            </div>
            <!-- #END# Exportable Table -->           
        </div>
</asp:Content>

