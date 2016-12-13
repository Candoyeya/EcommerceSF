<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="PedidosVista.aspx.vb" Inherits="PedidosVista" %>

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
                                Pedidos Pendientes
                            </h2>
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
                            <div class="row clearfix">
                                <div class="col-md-3">
                                    <div class="align-left">
                                        <div><span class="font-bold">Cliente:</span><asp:Label ID="viewCliente" runat="server" Text=""></asp:Label></div>
                                        <div><span class="font-bold">Nombre:</span><asp:Label ID="viewCardName" runat="server" Text=""></asp:Label></div>
                                        <div><span class="font-bold">Moneda del Documento:</span><asp:Label ID="viewmoneda" runat="server" Text=""></asp:Label></div>  
                                    </div>                                    
                                </div>
                                <div class="col-md-3">
                                    <div class="align-left">
                                        <div><span class="font-bold">Numero:</span><asp:Label ID="viewNum" runat="server" Text=""></asp:Label></div>
                                        <div><span class="font-bold">Fecha de contabilización:</span><asp:Label ID="viewDocdate" runat="server" Text=""></asp:Label></div>
                                        <div><span class="font-bold">Fecha de entrega:</span><asp:Label ID="viewDocDuedate" runat="server" Text=""></asp:Label></div> 
                                    </div>
                                </div>                               
                            </div>
                            <asp:Table ID="Table1" class="table table-bordered table-striped table-hover dataTable js-exportable" runat="server">
                               <asp:TableHeaderRow >  
                                    <asp:TableHeaderCell>Codigo</asp:TableHeaderCell>
                                    <asp:TableHeaderCell>Descripcion</asp:TableHeaderCell>
                                    <asp:TableHeaderCell>Cantidad</asp:TableHeaderCell>
                                    <asp:TableHeaderCell>Entregados</asp:TableHeaderCell>
                                    <asp:TableHeaderCell>Precio unidad</asp:TableHeaderCell>
                                    <asp:TableHeaderCell>Total</asp:TableHeaderCell>
                               </asp:TableHeaderRow>
                            </asp:Table>
                        </div>
                    </div>
                </div>
            </div>
            <!-- #END# Exportable Table -->           
        </div>
</asp:Content>

