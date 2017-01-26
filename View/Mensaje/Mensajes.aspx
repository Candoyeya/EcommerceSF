<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Mensajes.aspx.vb" Inherits="View_Mensaje_Mensajes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style>
      .modal-header, h4, .close {
          background-color: #5cb85c;
          color:white !important;
          text-align: center;
          font-size: 30px;
      }
      .modal-footer {
          background-color: #f9f9f9;
      }
  </style>
<!--Inicia Cuerpo pagina-->
        <div class="container-fluid">  
            <div class="row clearfix">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <div class="card">
                        <div class="header">
                            <div class="col-lg-5 col-md-5 col-sm-5 col-xs-12">
                                <div class="info-box bg-blue hover-zoom-effect">
                                    <div class="icon">
                                        <i class="material-icons">forum</i>
                                    </div>
                                    <div class="content">
                                        <div class="text"><h3>Mensajes</h3></div>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <br />
                            <br /> 
                            <h3>                                
                            </h3> 
                        </div>
                        
                        <div class="body" >          
                            <div style="width: auto; overflow-x: auto;"> 
                                <div style="width: 236px; margin-left: auto; margin-right: auto;">
                                    <div style="width: 170px; margin-left: auto;margin-right: auto;">
                                        <button id="enviarpinshimensaje" onclick="lansa()" style="width: 170px; margin-left: auto" type="button" class="btn btn-success waves-effect">
                                            Nuevo mensaje <i class="material-icons">email</i>
                                        </button>                       
                                    </div>
                                     <br />
                                        <!-- Modal 26/01/2016-->
                                          <div class="modal fade" id="myModal" role="dialog">
                                            <div class="modal-dialog">
                                              <!-- Modal content-->
                                              <div class="modal-content">
                                                <div class="modal-header" style="padding:35px 50px;">
                                                  <button type="button" class="close" data-dismiss="modal">&times;</button>
                                                  <h4><i class="material-icons">email</i> Nuevo Mensaje</h4>
                                                </div>
                                                <div class="modal-body" style="padding:40px 50px;">
                                                      <div class="row">
                                                          <div class="col-lg-3 col-md-3"></div>
                                                          <div class="col-lg-6 col-md-6">
                                                              <label><i class="material-icons">message</i> Asunto:</label>
                                                              <input type="text" class="form-control" id="asuntini" runat="server" />
                                                          </div>
                                                          <div class="col-lg-3 col-md-3"></div>
                                                      </div>
                                                    <div class="row">
                                                        <div class="col-lg-1 col-md-1"></div>
                                                          <div class="col-lg-10 col-md-10">
                                                              <label ><i class="material-icons">format_align_justify</i> Mensaje:</label>
                                                              <textarea id="TextArea1" runat="server" class="form-control" style=" margin-left: auto; margin-right: auto;"   rows="3"></textarea>
                                                          </div>
                                                        <div class="col-lg-1 col-md-1"></div>
                                                    </div>
                                                </div>
                                                <div class="modal-footer">
                                                    <div class="row">
                                                        <div class="col-lg-1 col-md-1"></div>
                                                        <div class="col-lg-10 col-md-10">
                                                            <button runat="server" id="enviarmensajillo" style="width: 170px; margin-left: auto" type="button" class="btn btn-success btn-block btn-lg waves-effect" data-dismiss="modal">
                                                                Eviar mensaje <i class="material-icons">send</i>
                                                            </button>
                                                        </div>
                                                        <div class="col-lg-1 col-md-1"></div>
                                                    </div>
                                                </div>
                                              </div>
      
                                            </div>
                                          </div> 
                                        <script>
                                            $(document).ready(function(){
                                                $("#enviarpinshimensaje").click(function () {
                                                    $("#myModal").modal();
                                                });
                                            });
                                        </script>
                                    <br />  
                                </div>
                            </div>
                            <div style="width: auto; overflow-x: auto;"> 
                                <div style="min-width: 600px;">
                                    <asp:Table ID="Table1" class="gvv display" runat="server" Style="width: 100%; min-width: 600px">
                                        <asp:TableHeaderRow>
                                            <asp:TableHeaderCell>Fecha</asp:TableHeaderCell>
                                            <asp:TableHeaderCell>Asunto</asp:TableHeaderCell>
                                            <asp:TableHeaderCell>Estado</asp:TableHeaderCell>
                                            <asp:TableHeaderCell></asp:TableHeaderCell>
                                        </asp:TableHeaderRow>
                                    </asp:Table>
                                </div>
                            </div>
                            <input type="text" runat="server" id="actuacan" clientidmode="Static" style="display: none" />
                            <input type="text" runat="server" id="actuaid" clientidmode="Static" style="display: none" />
                            <button id="secretbutton" runat="server" class="btn btn-default" type="button" style="display: none">dois</button>
                            <script>
                                function discre(id) {                    
                                    document.getElementById("actuaid").value = id.substring(3, id.length);
                                    document.getElementById('<%= secretbutton.ClientID%>').click();
                                        //reload(); 
                                }
                                function lansa() {
                                    //alert("aaa");
                                    
                                    document.getElementById("quedemonios").style.display = "Block";
                                    //document.getElementById('<%= secretbutton.ClientID%>').click(); 
                                    //reload(); 
                                }
                                
                            </script>
                        </div>
                    </div>
                </div>
            </div>
            <!-- #END# Exportable Table -->           
        </div>
 <%--Script java...--%>
    <%--Cargar tabla con opciones y traducir al español...--%>
    <%--Ultima actualizacion 24/01/2017...--%>
<script>
        $(document).ready(function () {
            $(".gvv").prepend($("<thead></thead><tfoot></tfoot>").append($(this).find("tr:first"))).dataTable({
                "language":
                {
                    "sProcessing": "Procesando...",
                    "sLengthMenu": "Mostrar _MENU_ registros",
                    "sZeroRecords": "No se encontraron resultados",
                    "sEmptyTable": "Ningún dato disponible en esta tabla",
                    "sInfo": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
                    "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
                    "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
                    "sInfoPostFix": "",
                    "sSearch": "Buscar en resultados:",
                    "sUrl": "",
                    "sInfoThousands": ",",
                    "sLoadingRecords": "Cargando...",
                    "oPaginate": {
                        "sFirst": "Primero",
                        "sLast": "Último",
                        "sNext": "Siguiente",
                        "sPrevious": "Anterior"
                    },
                    "oAria": {
                        "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
                        "sSortDescending": ": Activar para ordenar la columna de manera descendente"
                    }
                }
            });
            $('#Table1').DataTable();
    } );
</script>
</asp:Content>

