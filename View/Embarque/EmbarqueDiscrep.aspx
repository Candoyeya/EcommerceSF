<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="EmbarqueDiscrep.aspx.vb" Inherits="EmbarqueDiscrep" %>

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
                                Discrepancias En Pedido
                            </h3>                            
                        </div>
                        <div class="body">
                            <div>
                                <!--Tabla de productos-->
                                <asp:Table ID="Table1" class="table table-bordered table-striped table-hover dataTable js-exportable" runat="server">
                                   <asp:TableHeaderRow >  
                                        <asp:TableHeaderCell>Código</asp:TableHeaderCell>
                                        <asp:TableHeaderCell>Producto</asp:TableHeaderCell>
                                        <asp:TableHeaderCell>Cantidad</asp:TableHeaderCell>
                                        <asp:TableHeaderCell>Unidad</asp:TableHeaderCell>
                                   </asp:TableHeaderRow>
                                </asp:Table>
                                <h2 class="card-inside-title">Discrepancia:</h2>  
                                <br />
                                <!--Tabla de discrepancias-->
                                <asp:Table ID="Table2" class="table table-bordered table-striped table-hover dataTable js-exportable" runat="server">
                                   <asp:TableHeaderRow >  
                                        <asp:TableHeaderCell>Articulo</asp:TableHeaderCell>
                                        <asp:TableHeaderCell>Cantidad</asp:TableHeaderCell>
                                        <asp:TableHeaderCell>Observacion</asp:TableHeaderCell>
                                        <asp:TableHeaderCell>Imagen</asp:TableHeaderCell>
                                        <asp:TableHeaderCell>Eliminar</asp:TableHeaderCell>
                                   </asp:TableHeaderRow>
                                </asp:Table>
                            </div>
                            <div class="row clearfix">
                                <div class="col-xs-12 col-md-6    ">                                    
                                    <div class="demo-dropup">
                                        <!--Lista de codigo de articulos-->
                                        <h2 class="card-inside-title">Código:</h2>  
                                        <br />
                                        <div class="btn-group dropup">
                                            <asp:DropDownList ID="DropDownList1" runat="server" class="btn btn-default waves-effect"></asp:DropDownList>
                                        </div>
                                    
                                        <!--Lista de discrepancias-->      
                                        <h2 class="card-inside-title">Discrepancia:</h2>                                 
                                        <br />
                                        <div class="btn-group dropup">
                                            <asp:DropDownList ID="DropDownList2" runat="server" class="btn btn-default waves-effect">
                                                    <asp:ListItem>Dañado</asp:ListItem>
                                                    <asp:ListItem>Faltante</asp:ListItem>
                                                    <asp:ListItem>Otro</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>                                    
                                    </div>
                                    <!--Candidad dañada/faltante--> 
                                    <h2 class="card-inside-title">Cantidad:</h2>                                     
                                    <br />
                                    <div class="col-md-6">
                                        <div class="input-group spinner" data-trigger="spinner">
                                            <div class="form-line">
                                                <input type="text" runat="server" id="Cantidad" class="form-control text-center" value="1" data-rule="quantity"/>
                                            </div>
                                            <span class="input-group-addon">
                                                <a href="javascript:;" class="spin-up" data-spin="up"><i class="glyphicon glyphicon-chevron-up"></i></a>
                                                <a href="javascript:;" class="spin-down" data-spin="down"><i class="glyphicon glyphicon-chevron-down"></i></a>
                                            </span>
                                        </div>
                                    </div>                                
                                    
                                    <!--Cargar imagen-->  
                                    <h2 class="card-inside-title">Imagen:</h2>                                  
                                    <br />                                   

                                    <asp:FileUpload ID="File1" runat="server" class="btn btn-success btn-lg waves-effect" accept="image/*"/>                           
                                </div>
                                <div class="col-xs-12 col-md-6   ">                                    
                                    <!--Ingresar comentario-->
                                    <h2 class="card-inside-title">Observación:</h2>
                                    <div class="row clearfix">
                                        <div class="col-sm-12">
                                            <div class="form-group">
                                                <div class="form-line">
                                                    <textarea id="TextArea1" cols="20" rows="2" runat="server" class="form-control no-resize" placeholder="Por favor Escribe tu comentario..."></textarea>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row clearfix demo-button-sizes">
                                        <button id="enviardisc" runat="server" class="btn bg-teal btn-block btn-lg waves-effect" type="button">Enviar Discrepancia</button>
                                    </div>
                                </div>
                            </div>                         
                            

                            <br /> 
                            <input type="text" runat="server" id="actuaid" clientidmode="Static" style="display: none" />
                            <div class="button-demo">                                
                                <button id="secretbutton" runat="server" class="btn btn-success waves-effect" type="button" style="display: none">dois</button>
                            </div>
                            <br /> 
                            <br /> 
                        </div>

                        <script>
                            function basura(id) {

                                document.getElementById("actuaid").value = id.substring(3, id.length);
                                document.getElementById('<%= secretbutton.ClientID%>').click();
                                    //reload();
                                }


                        </script>
                    </div>
                </div>
            </div>
            <!-- #END# Exportable Table -->           
        </div>
<!--Fin Cuerpo pagina-->
</asp:Content>

