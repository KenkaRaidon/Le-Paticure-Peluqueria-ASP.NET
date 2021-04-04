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
    public partial class Mascotas : System.Web.UI.Page
    {
        E_Mascota Mascota = new E_Mascota();
        N_Mascota NM = new N_Mascota();

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
            pnlGrvMascotas.Visible = false;
            btnInsertar.Visible = false;
            btnBorrar.Visible = false;
            btnModificar.Visible = false;
        }
        protected void ControlsClear()
        {
            tbNombreMascota.Text = string.Empty;
            tbClaveMascota.Text = string.Empty;
        }
        protected void ControlsSwitch(bool TrueOrFalse)
        {
            tbNombreMascota.Enabled = TrueOrFalse;
            tbClaveMascota.Enabled = TrueOrFalse;
            ddlRaza.Enabled = TrueOrFalse;
        }
        #endregion

        #region ObjetoMascota
        protected E_Mascota ControlsWebForm_ObjetoIdentidad()
        {
            E_Mascota Mascota = new E_Mascota()
            {
                NombreMascota = tbNombreMascota.Text.Trim(),
                ClaveMascota = tbClaveMascota.Text.Trim(),
                IdRaza = Convert.ToInt32(ddlRaza.Text)
            };
            return Mascota;
        }
        protected void ObjetoEntidad_ControlsWebForm()
        {
            int IdMascota = hfIdMascota.Value == string.Empty ? 0 : Convert.ToInt32(hfIdMascota.Value);

            E_Mascota Mascota = NM.BuscarMascota(IdMascota);
            if (Mascota != null)
            {
                tbNombreMascota.Text = Mascota.NombreMascota.Trim();
                tbClaveMascota.Text = Mascota.ClaveMascota.Trim();
                ddlRaza.Text = Mascota.IdRaza.ToString();
            }
        }
        protected void VisualizarGrvMascotas()
        {
            ControlsInit();
            pnlGrvMascotas.Visible = true;
            DataTable dt = consultar("SELECT Mascotas.IdMascota, Mascotas.ClaveMascota, Mascotas.NombreMascota, Raza.Raza FROM Mascotas, Raza WHERE Mascotas.IdRaza=Raza.IdRaza");
            int count = dt.Rows.Count;
            lblNumeroRegistro.Text = count.ToString();
            if (count.Equals(0))
            {
                pnlGrvMascotas.Visible = false;
                lblMensaje.Text = "No hay informacion para mostrar";
            }
            else
            {
                grvMascotas.DataSource = dt;
                grvMascotas.DataBind();
            }
        }
        #endregion

        #region Botones Menu Navegacion
        protected void btnMenuNuevo_Click(object sender, EventArgs e)
        {
            pnlGrvMascotas.Visible = false;
            pnlCapturaDatos.Visible = true;
            btnInsertar.Visible = true;
            lblTituloAccion.Text = "Nuevo Mascota";
        }
        protected void btnMenuListado_Click(object sender, EventArgs e)
        {
            pnlGrvMascotas.Visible = true;
            VisualizarGrvMascotas();
        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (tbCriterioBusqueda.Text.Trim() != string.Empty)
            {
                List<E_Mascota> LstMascota = NM.LstBuscarMascota(tbCriterioBusqueda.Text.Trim());

                switch (LstMascota.Count)
                {
                    case 0:
                        lblMensaje.Text = "No se encontro informacion";
                        lblMensaje.Visible = true;
                        break;
                    case 1:
                        ControlsInit();
                        hfIdMascota.Value = LstMascota[0].IdMascota.ToString();
                        ObjetoEntidad_ControlsWebForm();
                        pnlCapturaDatos.Visible = true;
                        break;
                    default:
                        VisualizarGrvMascotas();
                        break;
                }
            }
        }
        #endregion
        protected void Empleado()
        {
            ddlRaza.DataSource = consultar("SELECT * FROM Raza");
            ddlRaza.DataTextField = "Raza";
            ddlRaza.DataValueField = "IdRaza";
            ddlRaza.DataBind();
        }
        public DataTable consultar(string strSQL)
        {
            string con = "Data Source=DESKTOP-OTHRDKV\\SQLEXPRESS;Initial Catalog=PeluqueriaPeticure;Integrated Security=True";
            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            SqlCommand cmd = new SqlCommand(strSQL, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            conn.Close();
            return ds;
        }

        #region Botones IBM
        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            lblMensaje.Text = NM.InsertarMascota(ControlsWebForm_ObjetoIdentidad());
            VisualizarGrvMascotas();
        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            lblMensaje.Text = NM.BorrarMascota(Convert.ToInt32(hfIdMascota.Value));
            VisualizarGrvMascotas();
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            Mascota.IdMascota = Convert.ToInt32(hfIdMascota.Value);
            Mascota.NombreMascota = tbNombreMascota.Text;
            Mascota.ClaveMascota = tbClaveMascota.Text;
            Mascota.IdRaza = Convert.ToInt32(ddlRaza.Text);
            lblMensaje.Text = NM.ModificarMascota(Mascota);
            VisualizarGrvMascotas();
        }

        protected void btnCancelar_Click(object sender, EventArgs e) => ControlsInit();
        #endregion

        #region Metodos Gridview
        protected void grvMascotas_RowEditing(object sender, GridViewEditEventArgs e)
        {
            e.Cancel = true;
            hfIdMascota.Value = grvMascotas.DataKeys[e.NewEditIndex].Value.ToString();
            ObjetoEntidad_ControlsWebForm();
            ControlsSwitch(true);
            pnlGrvMascotas.Visible = false;
            pnlCapturaDatos.Visible = true;
            btnModificar.Visible = true;
            lblTituloAccion.Text = "Modificar Mascota";
        }
        protected void grvMascotas_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            e.Cancel = true;
            hfIdMascota.Value = grvMascotas.DataKeys[e.RowIndex].Value.ToString();
            ObjetoEntidad_ControlsWebForm();
            ControlsSwitch(false);
            pnlGrvMascotas.Visible = false;
            pnlCapturaDatos.Visible = true;
            btnBorrar.Visible = true;
            lblTituloAccion.Text = "Borrar Mascota";
        }
        #endregion
    }
}