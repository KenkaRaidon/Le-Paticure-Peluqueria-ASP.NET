<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="Empleados.aspx.cs" Inherits="Le_Paticure_Peluqueria.WebForms.Empleados" %>

<%@ Register Src="~/Controls/wfucClave.ascx" TagPrefix="uc1" TagName="wfucClave" %>
<%@ Register Src="~/Controls/wfucRequerido.ascx" TagPrefix="uc1" TagName="wfucRequerido" %>
<%@ Register Src="~/Controls/wfucTelefono.ascx" TagPrefix="uc1" TagName="wfucTelefono" %>
<%@ Register Src="~/Controls/wfucEmail.ascx" TagPrefix="uc1" TagName="wfucEmail" %>





<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <div class="container pl-0 pr-0">
        <h1>Empleados</h1>
        <%--Contenedor del menu principal--%>
        <div class="row border pl-2">
            <div class="col-lg-8 col-md-6 col-sm-6">
                <asp:Label ID="lblUsuario" runat="server"></asp:Label><br />
                <asp:LinkButton ID="btnMenuNuevo" runat="server" CssClass="btn btn-sm btn-primary ml-3" CausesValidation="False" OnClick="btnMenuNuevo_Click">Nuevo Empleado</asp:LinkButton>
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
        <%--Panel de listado empleados--%>
        <asp:Panel ID="pnlGrvEmpleados" runat="server">
            <div class="container mt-3">
                <h6 class="text-dark ml-0">
                    <asp:Label ID="lblNumeroRegistro" runat="server"></asp:Label>
                </h6>
                <asp:GridView ID="grvEmpleados" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="IdEmpleado" ForeColor="#333333" GridLines="None" OnRowEditing="grvEmpleados_RowEditing" OnRowDeleting="grvEmpleados_RowDeleting">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="ClaveEmpleado" HeaderText="CLAVE" />
                        <asp:BoundField DataField="NombreEmpleado" HeaderText="NOMBRE" />
                        <asp:BoundField DataField="ApellidoEmpleado" HeaderText="APELLIDO" />
                        <asp:BoundField DataField="DireccionEmpleado" HeaderText="DIRECCION" />
                        <asp:BoundField DataField="TelCelEmpleado" HeaderText="TELEFONO" />
                        <asp:BoundField DataField="EmailEmpleado" HeaderText="EMAIL" />
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
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                    <SortedAscendingCellStyle BackColor="#FDF5AC" />
                    <SortedAscendingHeaderStyle BackColor="#4D0000" />
                    <SortedDescendingCellStyle BackColor="#FCF6C0" />
                    <SortedDescendingHeaderStyle BackColor="#820000" />
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
                                <asp:Label ID="lblTituloAccion" runat="server"></asp:Label>
                            </h5>
                        </div>
                        <div class="card-body">
                            <div class="row pl-2 pr-2">
                                <div class="col-lg-3 col-md-3 col col-sm-4">
                                    <div class="form-group text-dark m-0">
                                        <p class="font-weight-bold mb-1">Clave Empleado:</p>
                                        <uc1:wfucClave runat="server" id="tbClaveEmpleado" />
                                    </div>
                                </div>
                                <div class="col-lg-3 col-md-3 col col-sm-4">
                                    <div class="form-group text-dark m-0">
                                        <p class="font-weight-bold mb-1">Nombre Empleado:</p>
                                        <uc1:wfucRequerido runat="server" ID="tbNombreEmpleado" />
                                    </div>
                                </div>
                                <div class="col-lg-3 col-md-3 col col-sm-4">
                                    <div class="form-group text-dark m-0">
                                        <p class="font-weight-bold mb-1">Apellido Empleado:</p>
                                        <uc1:wfucRequerido runat="server" ID="tbApellidoEmpleado" />
                                    </div>
                                </div>
                            </div>
                            <div class="row pl-2 pr-2">
                                <div class="col-lg-3 col-md-3 col col-sm-4">
                                    <div class="form-group text-dark m-0">
                                        <p class="font-weight-bold mb-1">Direccion Empleado:</p>
                                        <uc1:wfucRequerido runat="server" ID="tbDireccionEmpleado" />
                                    </div>
                                </div>
                                <div class="col-lg-3 col-md-3 col col-sm-4">
                                    <div class="form-group text-dark m-0">
                                        <p class="font-weight-bold mb-1">Telefono Empleado:</p>
                                        <uc1:wfucTelefono runat="server" ID="tbTelCelEmpleado" />
                                    </div>
                                </div>
                                <div class="col-lg-3 col-md-3 col col-sm-4">
                                    <div class="form-group text-dark m-0">
                                        <p class="font-weight-bold mb-1">Email Empleado:</p>
                                        <uc1:wfucEmail runat="server" ID="TbEmailEmpleado" />
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
    </div>
    <asp:HiddenField ID="hfIdEmpleado" runat="server" />
</asp:Content>
