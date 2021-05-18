<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="EmailCita.aspx.cs" Inherits="Le_Paticure_Peluqueria.WebForms.EmailCita" %>

<%@ Register Src="~/Controls/wfucRequerido.ascx" TagPrefix="uc1" TagName="wfucRequerido" %>
<%@ Register Src="~/Controls/wfucClave.ascx" TagPrefix="uc1" TagName="wfucClave" %>
<%@ Register Src="~/Controls/wfucMensajeEmail.ascx" TagPrefix="uc1" TagName="wfucMensajeEmail" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
 
    <asp:Panel ID="pnlCapturaDatos" runat="server">
        <div class="container mt-3">
            <div class="modal-content">
                <div class="card">
                    <div class="card-header">
                        <h5 class="card-title">
                            <asp:Label ID="lblTituloAccion" runat="server" Text="Recordatorio para cita"></asp:Label>
                        </h5>
                    </div>
                    <div class="card-body">
                        <div class="row pl-2 pr-2">
                            <div class="col-lg-3 col-md-3 col col-sm-4">
                                <div class="form-group text-dark m-0">
                                    <p class="font-weight-bold mb-1">Destinatario:</p>
                                    <asp:DropDownList ID="ddlDestinatario" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-lg-3 col-md-3 col-sm-4">
                                <div class="form-group text-dark m-0">
                                    <p class="font-weight-bold mb-1">Asunto:</p>
                                    <uc1:wfucRequerido runat="server" ID="tbAsunto" />
                                </div>
                            </div>
                            
                        </div>
                        <div class="row pl-2 pr-2">
                            <div class="col-lg-3 col-md-3 col-sm-4">
                                <div class="form-group text-dark m-0">
                                    <p class="font-weight-bold mb-1">Mensaje:</p>
                                    <uc1:wfucMensajeEmail runat="server" id="tbMensajeEmail" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="card-footer text-right">
                        <asp:Button ID="btnEnviar" runat="server" Text="Enviar" CssClass="btn btn-sm btn-success" OnClick="btnEnviar_Click" />
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
</asp:Content>
