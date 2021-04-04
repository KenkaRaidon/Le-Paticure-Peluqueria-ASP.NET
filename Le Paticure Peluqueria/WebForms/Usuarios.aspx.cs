using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Entidades;
using Negocios;

namespace Le_Paticure_Peluqueria.WebForms
{
    public partial class Usuarios : System.Web.UI.Page
    {
        E_Usuario Usuario = new E_Usuario();
        N_Usuario NU = new N_Usuario();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["snLogin"] != null)
            {
                string Usuario = (string)Session["snLogin"];
                lblUsuario.Text = "Bienvenid@ " + Usuario;
                if (!IsPostBack)
                    ControlsInit();
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }
        #region Metodos General
        protected void ControlsInit()
        {
            Empleado();
            ControlsOff();
            ControlsClear();
            ControlsSwitch(true);
        }
        protected void ControlsOff()
        {
            pnlCapturaDatos.Visible = false;
            pnlGrvUsuarios.Visible = false;
            btnInsertar.Visible = false;
            btnBorrar.Visible = false;
            btnModificar.Visible = false;
        }
        protected void ControlsClear()
        {
            tbNombreUsuario.Text = string.Empty;
            tbPasswordUsuario.Text = string.Empty;
        }
        protected void ControlsSwitch(bool TrueOrFalse)
        {
            tbNombreUsuario.Enabled = TrueOrFalse;
            tbPasswordUsuario.Enabled = TrueOrFalse;
            ddlEmpleado.Enabled = TrueOrFalse;
        }
        #endregion

        #region ObjetoUsuario
        protected E_Usuario ControlsWebForm_ObjetoIdentidad()
        {
            E_Usuario Usuario = new E_Usuario()
            {
                NombreUsuario = tbNombreUsuario.Text.Trim(),
                PasswordUsuario = tbPasswordUsuario.Text.Trim(),
                IdEmpleado =Convert.ToInt32(ddlEmpleado.Text)
            };
            return Usuario;
        }
        protected void ObjetoEntidad_ControlsWebForm()
        {
            int IdUsuario = hfIdUsuario.Value == string.Empty ? 0 : Convert.ToInt32(hfIdUsuario.Value);

            E_Usuario Usuario = NU.BuscarUsuario(IdUsuario);
            if (Usuario != null)
            {
                tbNombreUsuario.Text = Usuario.NombreUsuario.Trim();
                tbPasswordUsuario.Text = Usuario.PasswordUsuario.Trim();
                ddlEmpleado.Text = Usuario.IdEmpleado.ToString();
            }
        }
        protected void VisualizarGrvUsuarios()
        {
            ControlsInit();
            pnlGrvUsuarios.Visible = true;
            DataTable dt = consultar("SELECT Usuarios.IdUsuario, Usuarios.NombreUsuario, Usuarios.PasswordUsuario, Empleados.IdEmpleado, Empleados.NombreEmpleado, Empleados.ApellidoEmpleado FROM Empleados, Usuarios WHERE Empleados.IdEmpleado = Usuarios.IdEmpleado");
            int count = dt.Rows.Count;
            lblNumeroRegistro.Text = count.ToString();
            if (count.Equals(0))
            {
                pnlGrvUsuarios.Visible = false;
                lblMensaje.Text = "No hay informacion para mostrar";
            } 
            else
            {
                grvUsuarios.DataSource = dt;
                grvUsuarios.DataBind();
            }
        }
        #endregion

        #region Botones Menu Navegacion
        protected void btnMenuNuevo_Click(object sender, EventArgs e)
        {
            pnlGrvUsuarios.Visible = false;
            pnlCapturaDatos.Visible = true;
            btnInsertar.Visible = true;
            lblTituloAccion.Text = "Nuevo Usuario";
        }
        protected void btnMenuListado_Click(object sender, EventArgs e)
        {
            pnlGrvUsuarios.Visible = true;
            VisualizarGrvUsuarios();
        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (tbCriterioBusqueda.Text.Trim() != string.Empty)
            {
                List<E_Usuario> LstUsuario = NU.LstBuscarUsuario(tbCriterioBusqueda.Text.Trim());

                switch (LstUsuario.Count)
                {
                    case 0:
                        lblMensaje.Text = "No se encontro informacion";
                        lblMensaje.Visible = true;
                        break;
                    case 1:
                        ControlsInit();
                        hfIdUsuario.Value = LstUsuario[0].IdUsuario.ToString();
                        ObjetoEntidad_ControlsWebForm();
                        pnlCapturaDatos.Visible = true;
                        break;
                    default:
                        VisualizarGrvUsuarios();
                        break;
                }
            }
        }
        #endregion
        protected void Empleado()
        {
            ddlEmpleado.DataSource = consultar("SELECT * FROM Empleados");
            ddlEmpleado.DataTextField = "NombreEmpleado";
            ddlEmpleado.DataValueField = "IdEmpleado";
            ddlEmpleado.DataBind();
        }
        public DataTable consultar(string strSQL)
        {
            string con = "Data Source=DESKTOP-OTHRDKV\\SQLEXPRESS;Initial Catalog=PeluqueriaPeticure;Integrated Security=True";
            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            SqlCommand cmd = new SqlCommand(strSQL, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds= new DataTable();
            da.Fill(ds);
            conn.Close();
            return ds;
        }

        #region Botones IBM
        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            lblMensaje.Text = NU.InsertarUsuario(ControlsWebForm_ObjetoIdentidad());
            VisualizarGrvUsuarios();
        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            lblMensaje.Text = NU.BorrarUsuario(Convert.ToInt32(hfIdUsuario.Value));
            VisualizarGrvUsuarios();
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            Usuario.IdUsuario = Convert.ToInt32(hfIdUsuario.Value);
            Usuario.NombreUsuario = tbNombreUsuario.Text;
            Usuario.PasswordUsuario = tbPasswordUsuario.Text;
            Usuario.IdEmpleado =Convert.ToInt32(ddlEmpleado.Text);
            lblMensaje.Text = NU.ModificarUsuario(Usuario);
            VisualizarGrvUsuarios();
        }

        protected void btnCancelar_Click(object sender, EventArgs e) => ControlsInit();
        #endregion

        #region Metodos Gridview
        protected void grvClientes_RowEditing(object sender, GridViewEditEventArgs e)
        {
            e.Cancel = true;
            hfIdUsuario.Value = grvUsuarios.DataKeys[e.NewEditIndex].Value.ToString();
            ObjetoEntidad_ControlsWebForm();
            ControlsSwitch(true);
            pnlGrvUsuarios.Visible = false;
            pnlCapturaDatos.Visible = true;
            btnModificar.Visible = true;
            lblTituloAccion.Text = "Modificar Usuario";
        }
        protected void grvClientes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            e.Cancel = true;
            hfIdUsuario.Value = grvUsuarios.DataKeys[e.RowIndex].Value.ToString();
            ObjetoEntidad_ControlsWebForm();
            ControlsSwitch(false);
            pnlGrvUsuarios.Visible = false;
            pnlCapturaDatos.Visible = true;
            btnBorrar.Visible = true;
            lblTituloAccion.Text = "Borrar Usuario";
        }
        #endregion
    }
}