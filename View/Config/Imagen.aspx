<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Imagen.aspx.vb" Inherits="View_Config_Imagen" %>

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
                            <h3>
                                Cambio de Foto de Perfil
                            </h3>
                        </div>
                        
                        <div class="body">    
                            <img class="img-responsive" src="" alt=" " runat ="server" id="imagenperfil" width="460" height="460" style="margin-left:auto;margin-right :auto ;" /> 
                            <div style="text-align:center ">
                             Imagen:<br /><br />
                                        <input type="hidden" name="MAX_FILE_SIZE" value="4194304"  style="   display: block; margin: 0 auto;"/>
                                        <input id="File1" runat="server" type="file" accept="image/*"  style="   display: block; margin: 0 auto;"/>
                            <br />
                                </div>
                            <div>
                            <button id="subirr" runat="server" class=" btn btn-primary   " type="button"   style="width:200px;   display: block; margin: 0 auto;" >Cambiar imagen</button>
                            </div>
                              <br /> <br /> <br />
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

