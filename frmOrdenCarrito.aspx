<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="frmOrdenCarrito.aspx.vb" Inherits="frmOrdenCarrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">



    <script src="Scripts/bootstrap-datepicker.min.js"></script>

    <link href="Content/bootstrap-datepicker.min.css" rel="stylesheet" />




    <style runat="server" id="estilo"></style>

    <div id="page-wrapper">
        <div class="row">



            <style>
                .abc table {
                    background: #f5f5f5;
                    border-collapse: separate;
                    box-shadow: inset 0 1px 0 #fff;
                    font-size: 12px;
                    line-height: 24px;
                    margin: 30px auto;
                    text-align: left;
                    width: 800px;
                }

                th {
                    background: url(http://jackrugile.com/images/misc/noise-diagonal.png), linear-gradient(#777, #444);
                    border-left: 1px solid #555;
                    border-right: 1px solid #777;
                    border-top: 1px solid #555;
                    border-bottom: 1px solid #333;
                    box-shadow: inset 0 1px 0 #999;
                    color: #fff;
                    font-weight: bold;
                    padding: 10px 15px;
                    position: relative;
                    text-shadow: 0 1px 0 #000;
                }

                    th:after {
                        background: linear-gradient(rgba(255,255,255,0), rgba(255,255,255,.08));
                        content: '';
                        display: block;
                        height: 25%;
                        left: 0;
                        margin: 1px 0 0 0;
                        position: absolute;
                        top: 25%;
                        width: 100%;
                    }

                    th:first-child {
                        border-left: 1px solid #777;
                        box-shadow: inset 1px 1px 0 #999;
                    }

                    th:last-child {
                        box-shadow: inset -1px 1px 0 #999;
                    }

                td {
                    border-right: 1px solid #fff;
                    border-left: 1px solid #e8e8e8;
                    border-top: 1px solid #fff;
                    border-bottom: 1px solid #e8e8e8;
                    padding: 10px 15px;
                    position: relative;
                    transition: all 300ms;
                }

                    td:first-child {
                        box-shadow: inset 1px 0 0 #fff;
                    }

                    td:last-child {
                        border-right: 1px solid #e8e8e8;
                        box-shadow: inset -1px 0 0 #fff;
                    }

                tr {
                }

                    tr:nth-child(odd) td {
                        background: #f1f1f1;
                    }

                    tr:last-of-type td {
                        box-shadow: inset 0 -1px 0 #fff;
                    }

                        tr:last-of-type td:first-child {
                            box-shadow: inset 1px -1px 0 #fff;
                        }

                        tr:last-of-type td:last-child {
                            box-shadow: inset -1px -1px 0 #fff;
                        }

                tbody:hover td {
                }

                tbody:hover tr:hover td {
                    color: #444;
                }

                .row {
                    margin-right: 0px;
                    margin-left: 0px;
                }

                .row-centered {
                    text-align: center;
                }

                .col-centered {
                    display: inline-block;
                    float: none;
                    /* reset the text-align */
                    text-align: left;
                    /* inline-block space fix */
                    margin-right: -4px;
                }

                .col-fixed {
                    /* custom width */
                    width: 220px;
                }

                .col-min {
                    /* custom min width */
                    min-width: 320px;
                }

                .col-max {
                    /* custom max width */
                    max-width: 320px;
                }
                /* visual styles */

                h1 {
                    margin: 40px 0px 20px 0px;
                    color: #95c500;
                    font-size: 28px;
                    line-height: 34px;
                    text-align: center;
                }

                [class*="col-"] {
                    padding-top: 10px;
                    padding-bottom: 15px;
                }

                    [class*="col-"]:before {
                        display: block;
                        position: relative;
                        margin-bottom: 8px;
                        font-family: sans-serif;
                        font-size: 10px;
                        letter-spacing: 1px;
                        color: #658600;
                        text-align: left;
                    }

                .item {
                    width: 100%;
                    height: 100%;
                    border: 1px solid #cecece;
                    padding: 16px 8px;
                    background: #ededed;
                    background: -webkit-gradient(linear, left top, left bottom,color-stop(0%, #f4f4f4), color-stop(100%, #ededed));
                    background: -moz-linear-gradient(top, #f4f4f4 0%, #ededed 100%);
                    background: -ms-linear-gradient(top, #f4f4f4 0%, #ededed 100%);
                }

                /* content styles */
                .item {
                    display: table;
                }

                .content {
                    display: table-cell;
                    vertical-align: middle;
                    text-align: center;
                }

                    .content:before {
                        content: "Content";
                        font-family: sans-serif;
                        font-size: 12px;
                        letter-spacing: 1px;
                        color: #747474;
                    }

                /* centering styles for jsbin */
            </style>

            <div class="titulolink">
                <br />
                <a href="frmInicio.aspx"><i class="fa fa-home fa-fw"></i></a>>
            <a href="frmOrden.aspx">Orden de compra</a>>
            <a href="#">Carrito</a>>
            <br />
                <br />
            </div>



            <script>
                $('.input-group.date').datepicker({

                    autoclose: true, format: 'yyyy-mm-dd'

                });
            </script>

            <button type="button" runat="server" id="Limpiarcarro" class="btn btn-default btn-md" style="float: right;">
                Limpiar carrito <i class="fa fa-trash "></i>
            </button>


            <br />
            <br />

            <div id="tablaprueba" runat="server" style="width: auto; overflow-x: auto;">

                <div style="min-width: 600px;">

                    <asp:Table ID="Table1" class="table abc" runat="server" Style="width: 100%; min-width: 600px">
                        <asp:TableHeaderRow>
                            <asp:TableHeaderCell>Articulo</asp:TableHeaderCell>
                            <asp:TableHeaderCell>Cantidad</asp:TableHeaderCell>
                            <asp:TableHeaderCell>Precio unitario</asp:TableHeaderCell>
                            <asp:TableHeaderCell>Descuento</asp:TableHeaderCell>
                            <asp:TableHeaderCell>Precio tras descuento</asp:TableHeaderCell>


                            <%--<asp:TableHeaderCell>Descuento</asp:TableHeaderCell>--%>
                            <asp:TableHeaderCell>Precio total</asp:TableHeaderCell>
                            <asp:TableHeaderCell>Nota de Articulo</asp:TableHeaderCell>
                        </asp:TableHeaderRow>
                    </asp:Table>

                </div>

            </div>
            <asp:CheckBox ID="CheckMail" runat="server" Checked  />  Envio por Mail


            <div style="width: 180px; margin-left: auto">
                Notas:<textarea id="TextArea1" cols="20" rows="2" runat="server" class="form-control"></textarea>
            </div>
            <br />


            <button type="button" runat="server" id="regresar" class="btn btn-default btn-md" style="">
                <i class="fa fa-arrow-left"></i>Continuar agregando

            </button>

            


            <asp:Button type="button" runat="server" ID="confirmar" Text="confirmar" OnClick="OnConfirm" class="btn btn-default btn-md" OnClientClick="Confirm()" Style="float: right" />




            <br />
            <br />
            <br />
            <br />





            <input type="text" runat="server" id="actuacan" clientidmode="Static" style="display: none" />
            <input type="text" runat="server" id="actuaid" clientidmode="Static" style="display: none" />
            <button id="secretbutton" runat="server" class="btn btn-default" type="button" style="display: none">dois</button>
            <button id="cambioPorcentaje" runat="server" class="btn btn-default" type="button" style="display: none">dois</button>
             <button id="cambioNota" runat="server" class="btn btn-default" type="button" style="display: none">dois</button>






            <script type="text/javascript">
                function Confirm() {
                    var confirm_value = document.createElement("INPUT");
                    confirm_value.type = "hidden";
                    confirm_value.name = "confirm_value";
                    if (confirm("Desea agregar este documento?")) {
                        confirm_value.value = "Ok";
                    } else {
                        confirm_value.value = "Cancel";
                    }
                    document.forms[0].appendChild(confirm_value);
                }
            </script>


            <%--<asp:Button ID="btnConfirm" runat="server" OnClick = "OnConfirm" Text = "Raise Confirm" OnClientClick = "Confirm()"/>--%>







            <script>
                function myFunction(val, id) {

                    if (val < 1) {
                        var confirm_value = document.createElement("INPUT");
                        confirm_value.type = "hidden";
                        confirm_value.name = "confirm_value";
                        if (confirm("Desea borrar del carrito?")) {
                            document.getElementById("actuacan").value = val;
                            document.getElementById("actuaid").value = id.substring(3, id.length);
                            confirm_value.value = "Ok";
                        } else {
                            confirm_value.value = "Cancel";
                        }
                        document.forms[0].appendChild(confirm_value);
                    }
                    else {
                        var confirm_value = document.createElement("INPUT");
                        confirm_value.type = "hidden";
                        confirm_value.name = "confirm_value";
                        confirm_value.value = "Ok";
                        document.getElementById("actuacan").value = val;
                        document.getElementById("actuaid").value = id.substring(3, id.length);
                        document.forms[0].appendChild(confirm_value);
                    }


                    document.getElementById('<%= secretbutton.ClientID%>').click();

                    reload();

                }



                function porcentaje(val, id) {
                    document.getElementById("actuacan").value = val;
                    document.getElementById("actuaid").value = id.substring(3, id.length);
                    document.getElementById('<%= cambioPorcentaje.ClientID%>').click();

                        reload();

                    }

                    function NotaArt(val, id) {
                        document.getElementById("actuacan").value = val;
                        document.getElementById("actuaid").value = id.substring(3, id.length);
                        document.getElementById('<%= cambioNota.ClientID%>').click();

                    reload();

                }


            </script>



        </div>
</asp:Content>

