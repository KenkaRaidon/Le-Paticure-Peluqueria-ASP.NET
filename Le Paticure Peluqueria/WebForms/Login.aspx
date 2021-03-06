<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Le_Paticure_Peluqueria.WebForms.Login" %>

<%@ Register Src="~/Controls/wfucRequerido.ascx" TagPrefix="uc1" TagName="wfucRequerido" %>
<%@ Register Src="~/Controls/wfucPassword.ascx" TagPrefix="uc1" TagName="wfucPassword" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <title></title>
    <link href="../CSS/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../CSS/Main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-3">
            <div class="card">
                <div class="card-header text-center">
                    <h5 class="card-title">
                        <asp:Label ID="lblTituloAccion" runat="server" Text="Login"></asp:Label>
                    </h5>
                </div>
                <div class="card-body">
                    <asp:Label ID="lblUsuario" runat="server" Text="Usuario"></asp:Label>
                    <uc1:wfucRequerido runat="server" ID="tbUsuario" />
                    <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
                    <uc1:wfucPassword runat="server" ID="tbPassword" />
                </div>
                <div class="card-footer text-right">
                    <asp:Button ID="btnLogin" runat="server" CssClass="btn btn-success" OnClick="btnLogin_Click" Text="Login" />
                </div>
            </div>
            <br />
            <asp:Label ID="lblMensaje" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
