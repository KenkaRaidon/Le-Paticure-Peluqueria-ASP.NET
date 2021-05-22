<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wfucFechaCita.ascx.cs" Inherits="Le_Paticure_Peluqueria.Controls.wfucFechaCita" %>

<link href="../CSS/bootstrap.min.css" rel="stylesheet" type="text/css" />
<link href="../CSS/Main.css" rel="stylesheet" type="text/css" />

<asp:TextBox ID="tbFechaCita" runat="server" TextMode="DateTimeLocal"></asp:TextBox>

<asp:RequiredFieldValidator ID="rfvTbRequerido" runat="server" CssClass="text-danger" ErrorMessage="Campo Obligatorio" ControlToValidate="tbFechaCita" Display="Dynamic"></asp:RequiredFieldValidator>