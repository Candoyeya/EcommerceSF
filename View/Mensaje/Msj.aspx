<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Msj.aspx.vb" Inherits="View_Mensaje_Msj" %>

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
                                SALDOS PENDIENTES
                            </h2>
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
                            </ul>
                        </div>
                        
                        <div class="body">    
                            <div class="container">
                                <div style="padding-bottom: 10px" >
                                    <button runat="server" id="btnregresar" type="button" class="btn btn-default" aria-label="Left Align">
                                        <i class='fa fa-arrow-left '></i>Regresar
                                    </button>
                                </div>
                                <div runat="server" id="mensajesapliados"></div>
                                <div>
                                    <textarea id="TextArea1" style="max-width: 600px;" rows="3" runat="server" class="form-control"></textarea>
                                </div>
                                <div style="width: 170px; margin-left: auto">
                                    <button runat="server" id="enviarpinshimensaje" style="width: 170px; margin-left: auto" type="button" class="btn btn-default" aria-label="Right Align">
                                        Eviar mensaje <i class='fa  fa-envelope-o  '></i>
                                    </button>
                                </div>
                            </div>
                            <!-- @end .container -->
                            <input type="text" runat="server" id="actuacan" clientidmode="Static" style="display: none" />
                            <input type="text" runat="server" id="actuaid" clientidmode="Static" style="display: none" />
                            <button id="secretbutton" runat="server" class="btn btn-default" type="button" style="display: none">dois</button>

                            <script>
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

