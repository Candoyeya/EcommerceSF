<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Pruebas3.aspx.vb" Inherits="Pruebas3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

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
                            <h2>
                                PRUEBAS
                            </h2>                            
                        </div>
                        
                        <div class="body">
                            
                              <h2>Modal Login Example</h2>
                              <!-- Trigger the modal with a button -->
                              <button type="button" class="btn btn-default btn-lg" id="myBtn">Login</button>

                              <!-- Modal -->
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
                                                  <label for="psw"><i class="material-icons">message</i> Asunto:</label>
                                                  <input type="text" class="form-control" id="asuntini" runat="server" />
                                              </div>
                                              <div class="col-lg-3 col-md-3"></div>
                                          </div>
                                        <div class="row">
                                            <div class="col-lg-1 col-md-1"></div>
                                              <div class="col-lg-10 col-md-10">
                                                  <label for="psw"><i class="material-icons">format_align_justify</i> Mensaje:</label>
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
                            </div>
 
                            <script>
                                $(document).ready(function(){
                                    $("#myBtn").click(function(){
                                        $("#myModal").modal();
                                    });
                                });
                            </script>
                        
                    </div>
                </div>
            </div>
            <!-- #END# Exportable Table -->           
        </div>

</asp:Content>

