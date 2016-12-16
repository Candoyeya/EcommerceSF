﻿<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Embarques.aspx.vb" Inherits="Embarques" %>

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
                            <h3>
                                Confirmar Pedido
                            </h3>
                            <!--
                            <ul class="header-dropdown m-r--5">
                                <li class="dropdown">
                                    <a href="javascript:void(0);" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">
                                        <i class="material-icons">more_vert</i>
                                    </a>
                                    <ul class="dropdown-menu pull-right">
                                        <li><a href="javascript:void(0);">Action</a></li>
                                        <li><a href="javascript:void(0);">Another action</a></li>
                                        <li><a href="javascript:void(0);">Something else here</a></li>
                                    </ul>
                                </li>
                            </ul>-->
                        </div>
                        <div class="body">
                            <asp:Table ID="Table1" class="table table-bordered table-striped table-hover dataTable js-exportable" runat="server">
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
</asp:Content>
