using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Entidades;
using Negocios;

namespace Le_Paticure_Peluqueria.WebForms
{
    public partial class Login : System.Web.UI.Page
    {
        N_Usuario NU = new N_Usuario();
        E_Usuario usuario = new E_Usuario();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            usuario = NU.Login(tbUsuario.Text, tbPassword.Text);
            if (usuario != null)
            {
                string Usuario = usuario.NombreUsuario;
                Session["snLogin"] = Usuario;
                Response.Redirect("Empleados.aspx");
            }
            else
            {
                lblMensaje.Text = "No se ingreso";
            }
        }
    }
}