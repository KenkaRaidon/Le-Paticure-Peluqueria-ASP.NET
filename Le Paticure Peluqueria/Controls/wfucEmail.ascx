<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wfucEmail.ascx.cs" Inherits="Le_Paticure_Peluqueria.Controls.Email" %>

<link href="../CSS/bootstrap.min.css" rel="stylesheet" type="text/css" />
<link href="../CSS/Main.css" rel="stylesheet" type="text/css" />

<asp:TextBox ID="tbEmail" runat="server" CssClass="form-control"></asp:TextBox>

<asp:RegularExpressionValidator ID="revTbEmail" runat="server" CssClass="text-danger" 
    ErrorMessage="Formato de Email incorrecto" ControlToValidate="tbEmail" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
</asp:RegularExpressionValidator>
<asp:RequiredFieldValidator ID="rfvTbRequerido" runat="server" CssClass="text-danger" ErrorMessage="Campo Obligatorio" ControlToValidate="tbEmail" Display="Dynamic"></asp:RequiredFieldValidator>