<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Pruebas3.aspx.vb" Inherits="Pruebas3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


<!--Inicia Cuerpo pagina-->
        <div class="container-fluid">   
            <div class="row clearfix">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <div class="card">
                        <div class="header">
                            <div class="col-lg-5 col-md-5 col-sm-5 col-xs-12">
                                <div class="info-box bg-red hover-zoom-effect">
                                    <div class="icon">
                                        <i class="material-icons">warning</i>
                                    </div>
                                    <div class="content">
                                        <div class="text"><h3>Pruebas</h3></div>
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
                            <asp:LinkButton runat="server" ID="BtnDescargar" CssClass="btn btn-success waves-effect"><i class="material-icons">file_download</i>Descargar</asp:LinkButton>
                              
                        </div>
                    </div>
                </div>
            </div>
            <!-- #END# Exportable Table -->           
        </div>

</asp:Content>

