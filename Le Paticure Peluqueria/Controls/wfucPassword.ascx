<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wfucPassword.ascx.cs" Inherits="Le_Paticure_Peluqueria.Controls.wfucPassword" %>

<link href="../CSS/bootstrap.min.css" rel="stylesheet" type="text/css" />

<asp:TextBox ID="tbPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>

<asp:RequiredFieldValidator ID="rfvTbRequerido" runat="server" CssClass="text-danger" ErrorMessage="Campo Obligatorio" ControlToValidate="tbPassword" Display="Dynamic"></asp:RequiredFieldValidator>
