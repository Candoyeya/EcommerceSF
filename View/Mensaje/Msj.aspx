<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Msj.aspx.vb" Inherits="View_Mensaje_Msj" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<link href="<%= ResolveClientUrl("~/css/alt/ChatSF.css") %>" rel="stylesheet" />
    
<!--Inicia Cuerpo pagina-->
        <div class="container-fluid"> 
            <div class="row clearfix">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <div class="card">
                        <div class="header">
                            <div class="col-lg-5 col-md-5 col-sm-5 col-xs-12">
                                <div class="info-box bg-blue hover-zoom-effect">
                                    <div class="icon">
                                        <i class="material-icons">drafts</i>
                                    </div>
                                    <div class="content">
                                        <div class="text"><h3>Conversacion</h3></div>
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
                            <div class="container">
                                <!-- Fila 1 -->
                                <div class="row">
                                    <button runat="server" id="btnregresar" type="button" class="btn btn-success waves-effect" aria-label="Left Align">
                                        <i class="material-icons">arrow_back</i>Regresar
                                    </button>
                                    <br />
                                </div>
                                <!-- Fila 2 -->
                                <div class="row">
                                    <div runat="server" id="mensajesapliados"></div>
                                </div>
                                <!-- Fila 3 -->
                                <div class="row">
                                    <div class="col-lg-6 col-md-6 ">
                                        <textarea id="TextArea1" style="max-width: 600px;" rows="3" runat="server" class="form-control"></textarea>
                                    </div>
                                    <div class="col-lg-1 col-md-1 "></div>
                                    <div class="col-lg-5 col-md-5 ">
                                        <button runat="server" id="enviarpinshimensaje" style="width: 170px; margin-left: auto" type="button" class="btn btn-primary waves-effect" aria-label="Right Align">
                                            Enviar mensaje <i class="material-icons">email</i>
                                        </button>
                                    </div>
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

