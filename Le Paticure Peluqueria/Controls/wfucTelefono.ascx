<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wfucTelefono.ascx.cs" Inherits="Le_Paticure_Peluqueria.Controls.wfucTelefono" %>

<link href="../CSS/bootstrap.min.css" rel="stylesheet" type="text/css" />

<asp:TextBox ID="tbTelefono" runat="server" CssClass="form-control"></asp:TextBox>

<asp:RegularExpressionValidator ID="revTbAlfaNumericoReq" runat="server" CssClass="text-danger" 
    ErrorMessage="Formato incorrecto de telefono" ControlToValidate="tbTelefono" Display="Dynamic" ValidationExpression="[0-9]{10}"></asp:RegularExpressionValidator>
<asp:RequiredFieldValidator ID="rfvTbRequerido" runat="server" CssClass="text-danger" ErrorMessage="Campo Obligatorio" ControlToValidate="tbTelefono" Display="Dynamic"></asp:RequiredFieldValidator>
