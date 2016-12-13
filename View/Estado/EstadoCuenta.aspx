<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="EstadoCuenta.aspx.vb" Inherits="EstadoCuenta" %>

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
                                Estado de Cuenta
                            </h2>                            
                        </div>
                        <div class="body" runat="server">                            
                            <div class="demo-masked-input">
                                <div class="row clearfix">
                                    <div class="col-md-3">
                                        <b>Fecha Inicial</b>
                                        <div class="input-group">
                                            <span class="input-group-addon">
                                                <i class="material-icons">date_range</i>
                                            </span>
                                            <div class="form-line">
                                                <input runat="server" id="fecha1" type="text" class="form-control date" placeholder="Ej: 2016-11-01"/>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <b>Fecha Final</b>
                                        <div class="input-group">
                                            <span class="input-group-addon">
                                                <i class="material-icons">date_range</i>
                                            </span>
                                            <div class="form-line">
                                                <input runat="server" id="fecha2" type="text" class="form-control date" placeholder="Ej: 2016-11-01"/>
                                            </div>
                                        </div>
                                    </div>                                     
                                </div>
                            </div>
                            <div class="row clearfix demo-button-sizes" runat="server">
                                <div class="col-xs-6 col-sm-3 col-md-2 col-lg-2">
                                    <button runat="server" id="buscaredo" type="button" class="btn bg-cyan btn-block waves-effect">BUSCAR</button>
                                </div>
                            </div>
                            <asp:Table ID="Table1" class="table table-bordered table-striped table-hover dataTable js-exportable" runat="server">
                               <asp:TableHeaderRow > 
                                    <asp:TableHeaderCell>Fecha Contabilización</asp:TableHeaderCell>
                                    <asp:TableHeaderCell>Numero de origen</asp:TableHeaderCell>
                                    <asp:TableHeaderCell>Cuenta de contrapartida</asp:TableHeaderCell>
                                    <asp:TableHeaderCell>Información  Detallada</asp:TableHeaderCell>
                                    <asp:TableHeaderCell>Saldo Vencido</asp:TableHeaderCell>
                                    <asp:TableHeaderCell>Saldo Vencido FC</asp:TableHeaderCell> 
                               </asp:TableHeaderRow>
                            </asp:Table>
                        </div>
                    </div>
                </div>
            </div>
            <!-- #END# Exportable Table -->           
        </div>
</asp:Content>

