<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="Citas.aspx.cs" Inherits="Le_Paticure_Peluqueria.WebForms.Citas" %>

<%@ Register Src="~/Controls/wfucRequerido.ascx" TagPrefix="uc1" TagName="wfucRequerido" %>
<%@ Register Src="~/Controls/wfucClave.ascx" TagPrefix="uc1" TagName="wfucClave" %>
<%@ Register Src="~/Controls/wfucFechaCita.ascx" TagPrefix="uc1" TagName="wfucFechaCita" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <h1>Citas</h1>
    <%--Contenedor del menu principal--%>
    <div class="row border pl-2">
        <div class="col-lg-8 col-md-6 col-sm-6">
            <asp:Label ID="lblUsuario" runat="server"></asp:Label><br />
            <asp:LinkButton ID="btnMenuNuevo" runat="server" CssClass="btn btn-sm btn-primary ml-3" CausesValidation="False" OnClick="btnMenuNuevo_Click">Nuevo Cita</asp:LinkButton>
            <asp:LinkButton ID="btnMenuListado" runat="server" CssClass="btn btn-sm btn-primary ml-3" CausesValidation="false" OnClick="btnMenuListado_Click">Listado</asp:LinkButton>
        </div>
        <div class="col-lg-4 col-md-6 col-sm-6">
            <div class="row">
                <div class="col-lg-8 col-md-6 col-sm-6">
                    <asp:TextBox ID="tbCriterioBusqueda" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-lg-4 col-md-6 col-sm-6">
                    <asp:LinkButton ID="btnBuscar" runat="server" CssClass="btn btn-sm btn-success ml-3" CausesValidation="false" OnClick="btnBuscar_Click">Buscar</asp:LinkButton>
                </div>
            </div>
        </div>
    </div>

    <asp:Label ID="lblMensaje" runat="server"></asp:Label>
    <%--Panel de listado Citas--%>
    <asp:Panel ID="pnlGrvCitas" runat="server">
        <div class="container mt-3">
            <h6 class="text-dark font ml-0">Registros encontrados:
                        <asp:Label ID="lblNumeroRegistro" runat="server" Text=""></asp:Label>
            </h6>
            <asp:GridView ID="grvCitas" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="IdCita" OnRowEditing="grvCitas_RowEditing" OnRowDeleting="grvCitas_RowDeleting" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px">
                <Columns>
                    <asp:BoundField DataField="ClaveCita" HeaderText="CLAVE CITA" />
                    <asp:BoundField DataField="ClaveMascota" HeaderText="CLAVE MASCOTA" />
                    <asp:BoundField DataField="NombreMascota" HeaderText="NOMBRE MASCOTA" />
                    <asp:BoundField DataField="Servicios" HeaderText="SERVICIO" />
                    <asp:BoundField DataField="FechaCita" HeaderText="FECHA CITA" />
                    <asp:TemplateField InsertVisible="false" ShowHeader="true" HeaderText="EDITAR">
                        <ItemTemplate>
                            <asp:LinkButton ID="grvBtnEditar" runat="server" CommandName="Edit">Editar</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField InsertVisible="false" ShowHeader="true" HeaderText="BORRAR">
                        <ItemTemplate>
                            <asp:LinkButton ID="grvBtnBorrar" runat="server" CommandName="Delete">Borrar</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                <RowStyle BackColor="White" ForeColor="#330099" />
                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                <SortedAscendingCellStyle BackColor="#FEFCEB" />
                <SortedAscendingHeaderStyle BackColor="#AF0101" />
                <SortedDescendingCellStyle BackColor="#F6F0C0" />
                <SortedDescendingHeaderStyle BackColor="#7E0000" />
            </asp:GridView>
        </div>
    </asp:Panel>

    <%--Panel de form llenado de datos--%>
    <asp:Panel ID="pnlCapturaDatos" runat="server">
        <div class="container mt-3">
            <div class="modal-content">
                <div class="card">
                    <div class="card-header">
                        <h5 class="card-title">
                            <asp:Label ID="lblTituloAccion" runat="server" Text=""></asp:Label>
                        </h5>
                    </div>
                    <div class="card-body">
                        <div class="row pl-2 pr-2">
                            <div class="col-lg-3 col-md-3 col col-sm-4">
                                <div class="form-group text-dark m-0">
                                    <p class="font-weight-bold mb-1">Clave:</p>
                                    <uc1:wfucClave runat="server" ID="tbClaveCita" />
                                </div>
                            </div>
                            <div class="col-lg-3 col-md-3 col-sm-4">
                                <div class="form-group text-dark m-0">
                                    <p class="font-weight-bold mb-1">Servicio:</p>
                                    <asp:CheckBoxList ID="ddlServicio" runat="server"></asp:CheckBoxList>
                                    <asp:CustomValidator ID="CustomValidator" ErrorMessage="Selecciona al menos un servicio" ForeColor="Red" ClientValidationFunction="ValidateCheckBoxList" runat="server" />
                                    <script type="text/javascript">
                                        function ValidateCheckBoxList(sender, args) {
                                            var checkBoxList = document.getElementById("<%=ddlServicio.ClientID %>");
                                            var checkboxes = checkBoxList.getElementsByTagName("input");
                                            var isValid = false;
                                            for (var i = 0; i < checkboxes.length; i++) {
                                                if (checkboxes[i].checked) {
                                                    isValid = true;
                                                    break;
                                                }
                                            }
                                            args.IsValid = isValid;
                                        }
                                    </script>
                                </div>
                            </div>
                            <div class="col-lg-3 col-md-3 col-sm-4">
                                <div class="form-group text-dark m-0">
                                    <p class="font-weight-bold mb-1">Mascota:</p>
                                    <asp:DropDownList ID="ddlMascota" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-lg-3 col-md-3 col-sm-4">
                                <div class="form-group text-dark m-0">
                                    <p class="font-weight-bold mb-1">Fecha Cita:</p>
                                    <uc1:wfucFechaCita runat="server" ID="tbFechaCita" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="card-footer text-right">
                        <asp:Button ID="btnInsertar" runat="server" Text="Ingresar" CssClass="btn btn-sm btn-success" OnClick="btnInsertar_Click" />
                        <asp:Button ID="btnBorrar" runat="server" CssClass="btn btn-sm btn-danger" OnClick="btnBorrar_Click" Text="Borrar" />
                        <asp:Button ID="btnModificar" runat="server" CssClass="btn btn-sm btn-primary" OnClick="btnModificar_Click" Text="Modificar" />
                        <asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-sm btn-dark" Text="Cancelar" OnClick="btnCancelar_Click" CausesValidation="false" />
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
    <asp:HiddenField ID="hfIdCita" runat="server" />
</asp:Content>
