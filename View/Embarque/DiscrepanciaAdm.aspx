<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="DiscrepanciaAdm.aspx.vb" Inherits="View_Embarque_DiscrepanciaAdm" %>

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
                                <div class="info-box bg-red hover-zoom-effect">
                                    <div class="icon">
                                        <i class="material-icons">report_problem</i>
                                    </div>
                                    <div class="content">
                                        <div class="text"><h3>Discrepancias del Cliente</h3></div>
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
                            <div style="width: auto; overflow-x: auto;">
                                <div style="min-width: 600px;">
                                    <asp:Table ID="Table1" class="table table-bordered table-striped table-hover dataTable" runat="server" Style="width: 100%; min-width: 600px">
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
                                    <asp:Table ID="Table2" class="table table-bordered table-striped table-hover dataTable" runat="server" Style="width: 100%; min-width: 600px">
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

