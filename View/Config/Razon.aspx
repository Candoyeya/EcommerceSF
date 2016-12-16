<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Razon.aspx.vb" Inherits="View_Config_Razon" %>

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
                                Carrito de Compra
                            </h2>
                            
                        </div>
                        
                        <div class="body">    
                            <div class="row">
                                <div class="Absolute-Center is-Responsive " id="centrado" style="">
                                    <div class=" text-center">
                                        <span style="font-size: 23px">Socio de negocio</span>
                                        <hr    style="color: black;height: 1px; background-color: black; width:75%;" />
                                    </div>

                                    <div class="input-group">
                                        <input type="text" runat="server" id="barrabusqueda" class="form-control" placeholder="Search for..." />
                                        <span class="input-group-btn">
                                            <button id="btnbuscar" runat="server" class="btn btn-default" type="button"><i class="fa fa-search"></i></button>
                                        </span>
                                    </div>
                                    <br />

                                    <label>Busqueda por:</label>
                                    <br />

                                    <asp:RadioButtonList runat="server" ID="radios" RepeatLayout="Flow" CssClass="labels">
                                        <asp:ListItem Text="Nombre" Value="Nombre" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="Codigo" Value="Codigo"></asp:ListItem>
                                    </asp:RadioButtonList>

                                    <br />
                                    <br />



                                    <asp:ListBox ID="ListBox1" runat="server" Rows="5" Style="height: 200px !important; width: 600px !important; max-width: 100% !important;"></asp:ListBox>

                                    <br /><br /> 
                                    <div style="width: 115px; margin: 0 auto;">

                                        <button type="button" runat="server" id="aceptarrazon" class="btn btn-default btn-lg">
                                            Aceptar <i class="fa fa-sign-in"></i>

                                        </button>
                                    </div>


                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- #END# Exportable Table -->           
        </div>
</asp:Content>

