<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Inicio.aspx.vb" Inherits="Inicio" %>

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
                                <div class="info-box bg-red hover-zoom-effect">
                                    <div class="icon">
                                        <i class="material-icons">attach_money</i>
                                    </div>
                                    <div class="content">
                                        <div class="text"><h3>Saldos Pendientes</h3></div>
                                    </div>
                                </div>
                            </div> 
                            <br />
                            <br />
                            <br />
                            <br />
                            <h2>                                
                            </h2>
                            
                        </div>
                        
                        <div class="body">    
                            <br />
                            <asp:Table ID="Table1" class="table table-bordered table-striped table-hover dataTable js-exportable" runat="server">
                               <asp:TableHeaderRow >  
                               </asp:TableHeaderRow>
                               <asp:TableFooterRow>
                               </asp:TableFooterRow>
                            </asp:Table>  
                        </div>
                    </div>
                </div>
            </div>
            <!-- #END# Exportable Table -->           
        </div>
</asp:Content>

