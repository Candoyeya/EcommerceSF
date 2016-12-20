<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Discrepancias.aspx.vb" Inherits="View_Embarque_Discrepancias" %>

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
                            <h2>
                                Discrepancias del Cliente
                            </h2>                            
                        </div>
                        
                        <div class="body">    
                            <div style="width: auto; overflow-x: auto;"> 
                                <div style="min-width: 600px;"> 
                                    <asp:Table ID="Table1" class="table abc" runat="server" Style="width: 100%; min-width: 600px">
                                        <asp:TableHeaderRow>
                                            <asp:TableHeaderCell>Fecha</asp:TableHeaderCell>
                                            <asp:TableHeaderCell>Entrega</asp:TableHeaderCell>
                                            <asp:TableHeaderCell>Pedido</asp:TableHeaderCell>
                                            <asp:TableHeaderCell>Socio</asp:TableHeaderCell> 
                                            <asp:TableHeaderCell>Detalle</asp:TableHeaderCell>                         
                                        </asp:TableHeaderRow> 
                                    </asp:Table> 
                                </div> 
                            </div> 

                            <input type="text" runat="server" id="actuacan" clientidmode="Static" style="display: none"  />
                            <input type="text" runat="server" id="actuaid" clientidmode="Static" style="display: none" />
                            <button id="secretbutton" runat="server" class="btn btn-default" type="button" style="display: none">dois</button>
                                        
                            <script>      
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

