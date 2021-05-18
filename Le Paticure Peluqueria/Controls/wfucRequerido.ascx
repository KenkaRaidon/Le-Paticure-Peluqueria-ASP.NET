<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wfucRequerido.ascx.cs" Inherits="Le_Paticure_Peluqueria.Controls.wfucRequerido" %>

<link href="../CSS/bootstrap.min.css" rel="stylesheet" type="text/css" />
<link href="../CSS/Main.css" rel="stylesheet" type="text/css" />

<asp:TextBox ID="tbRequerido" runat="server" CssClass="form-control"></asp:TextBox>

<asp:RegularExpressionValidator ID="revTbAlfaNumericoReq" runat="server" CssClass="text-danger" 
    ErrorMessage="Formato incorrecto" ControlToValidate="tbRequerido" Display="Dynamic" ValidationExpression="^[a-zA-Z0-9 .áéíóú]+$"></asp:RegularExpressionValidator>
<asp:RequiredFieldValidator ID="rfvTbRequerido" runat="server" CssClass="text-danger" ErrorMessage="Campo Obligatorio" ControlToValidate="tbRequerido" Display="Dynamic"></asp:RequiredFieldValidator>