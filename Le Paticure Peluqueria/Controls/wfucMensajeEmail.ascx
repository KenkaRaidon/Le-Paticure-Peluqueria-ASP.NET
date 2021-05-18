<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wfucMensajeEmail.ascx.cs" Inherits="Le_Paticure_Peluqueria.Controls.wfucMensajeEmail" %>

<link href="../CSS/bootstrap.min.css" rel="stylesheet" type="text/css" />
<link href="../CSS/Main.css" rel="stylesheet" type="text/css" />

<asp:TextBox ID="tbMensajeEmail" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>

<asp:RequiredFieldValidator ID="rfvTbMensajeEmail" runat="server" CssClass="text-danger" ErrorMessage="Campo Obligatorio" ControlToValidate="tbMensajeEmail" Display="Dynamic"></asp:RequiredFieldValidator>