<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="DiscrepanciaAdm.aspx.vb" Inherits="View_Embarque_DiscrepanciaAdm" %>

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
                                Discrepancias del Cliente
                            </h2>                            
                        </div>
                        
                        <div class="body">    
                            <div style="width: auto; overflow-x: auto;">
                                <div style="min-width: 600px;">
                                    <asp:Table ID="Table1" class="table abc" runat="server" Style="width: 100%; min-width: 600px">
                                        <asp:TableHeaderRow>
                                            <asp:TableHeaderCell>Código</asp:TableHeaderCell>
                                            <asp:TableHeaderCell>Producto</asp:TableHeaderCell>
                                            <asp:TableHeaderCell>Cantidad</asp:TableHeaderCell>
                                            <asp:TableHeaderCell>Unidad</asp:TableHeaderCell>
                                        </asp:TableHeaderRow>
                                    </asp:Table>
                                </div>
                            </div>
                            <div style="width: auto; overflow-x: auto;">
                                <div style="min-width: 600px;">
                                    <div class="titulolink">
                                        <br />
                                        <a href="#">Discrepancia</a>
                                    </div>
                                    <asp:Table ID="Table2" class="table abc" runat="server" Style="width: 100%; min-width: 600px">
                                        <asp:TableHeaderRow>
                                            <asp:TableHeaderCell>Articulo</asp:TableHeaderCell>
                                            <asp:TableHeaderCell>Cantidad</asp:TableHeaderCell>
                                            <asp:TableHeaderCell>Observacion</asp:TableHeaderCell>
                                            <asp:TableHeaderCell>Imagen</asp:TableHeaderCell>
                                        </asp:TableHeaderRow>
                                    </asp:Table>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- #END# Exportable Table -->           
        </div>
</asp:Content>

