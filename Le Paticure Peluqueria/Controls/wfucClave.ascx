<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wfucClave.ascx.cs" Inherits="Le_Paticure_Peluqueria.Controls.wfucClave" %>

<link href="../CSS/bootstrap.min.css" rel="stylesheet" type="text/css" />
<link href="../CSS/Main.css" rel="stylesheet" type="text/css" />

<asp:TextBox ID="tbClave" runat="server" CssClass="form-control"></asp:TextBox>

<asp:RegularExpressionValidator ID="revTbAlfaNumericoReq" runat="server" CssClass="text-danger" 
    ErrorMessage="Formato incorrecto de Clave" ControlToValidate="tbClave" Display="Dynamic" ValidationExpression="[0-9]{5}"></asp:RegularExpressionValidator>
<asp:RequiredFieldValidator ID="rfvTbRequerido" runat="server" CssClass="text-danger" ErrorMessage="Campo Obligatorio" ControlToValidate="tbClave" Display="Dynamic"></asp:RequiredFieldValidator>
