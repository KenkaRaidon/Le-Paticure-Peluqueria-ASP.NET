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
    public partial class Citas : System.Web.UI.Page
    {
        E_Cita Cita = new E_Cita();
        N_Cita NM = new N_Cita();

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
            Servicio();
            Mascota();
            ControlsOff();
            ControlsClear();
            ControlsSwitch(true);
        }
        protected void ControlsOff()
        {
            pnlCapturaDatos.Visible = false;
            pnlGrvCitas.Visible = false;
            btnInsertar.Visible = false;
            btnBorrar.Visible = false;
            btnModificar.Visible = false;
        }
        protected void ControlsClear()
        {
            tbFechaCita.Text = string.Empty;
            tbClaveCita.Text = string.Empty;
        }
        protected void ControlsSwitch(bool TrueOrFalse)
        {
            tbFechaCita.Enabled = TrueOrFalse;
            tbClaveCita.Enabled = TrueOrFalse;
            ddlServicio.Enabled = TrueOrFalse;
            ddlMascota.Enabled = TrueOrFalse;
        }
        #endregion

        #region ObjetoCita
        protected E_Cita ControlsWebForm_ObjetoIdentidad()
        {
            E_Cita Cita = new E_Cita()
            {
                ClaveCita = tbClaveCita.Text.Trim(),
                IdServicio = Convert.ToInt32(ddlMascota.Text),
                IdMascota = Convert.ToInt32(ddlMascota.Text),
                FechaCita= Convert.ToDateTime(tbFechaCita.Text)
            };
            return Cita;
        }
        protected void ObjetoEntidad_ControlsWebForm()
        {
            int IdCita = hfIdCita.Value == string.Empty ? 0 : Convert.ToInt32(hfIdCita.Value);

            E_Cita Cita = NM.BuscarCita(IdCita);
            if (Cita != null)
            {
                tbClaveCita.Text = Cita.ClaveCita.Trim();
                ddlServicio.Text = Cita.IdServicio.ToString();
                ddlMascota.Text = Cita.IdMascota.ToString();
                tbFechaCita.Text = Cita.FechaCita.ToString();
            }
        }
        protected void VisualizarGrvCitas()
        {
            ControlsInit();
            pnlGrvCitas.Visible = true;
            DataTable dt = consultar("SELECT Cita.IdCita, Cita.ClaveCita, Servicio.Servicio, Mascotas.ClaveMascota, Mascotas.NombreMascota, Cita.FechaCita FROM Cita, Mascotas, Servicio WHERE Cita.IdServicio=Servicio.IdServicio AND Cita.IdMascota=Mascotas.IdMascota");
            int count = dt.Rows.Count;
            lblNumeroRegistro.Text = count.ToString();
            if (count.Equals(0))
            {
                pnlGrvCitas.Visible = false;
                lblMensaje.Text = "No hay informacion para mostrar";
            }
            else
            {
                grvCitas.DataSource = dt;
                grvCitas.DataBind();
            }
        }
        #endregion

        #region Botones Menu Navegacion
        protected void btnMenuNuevo_Click(object sender, EventArgs e)
        {
            pnlGrvCitas.Visible = false;
            pnlCapturaDatos.Visible = true;
            btnInsertar.Visible = true;
            lblTituloAccion.Text = "Nuevo Cita";
        }
        protected void btnMenuListado_Click(object sender, EventArgs e)
        {
            pnlGrvCitas.Visible = true;
            VisualizarGrvCitas();
        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (tbCriterioBusqueda.Text.Trim() != string.Empty)
            {
                List<E_Cita> LstCita = NM.LstBuscarCita(tbCriterioBusqueda.Text.Trim());

                switch (LstCita.Count)
                {
                    case 0:
                        lblMensaje.Text = "No se encontro informacion";
                        lblMensaje.Visible = true;
                        break;
                    case 1:
                        ControlsInit();
                        hfIdCita.Value = LstCita[0].IdCita.ToString();
                        ObjetoEntidad_ControlsWebForm();
                        pnlCapturaDatos.Visible = true;
                        break;
                    default:
                        VisualizarGrvCitas();
                        break;
                }
            }
        }
        #endregion
        protected void Servicio()
        {
            ddlServicio.DataSource = consultar("SELECT * FROM Servicio");
            ddlServicio.DataTextField = "Servicio";
            ddlServicio.DataValueField = "IdServicio";
            ddlServicio.DataBind();
        }
        protected void Mascota()
        {
            ddlMascota.DataSource = consultar("SELECT * FROM Mascotas");
            ddlMascota.DataTextField = "NombreMascota";
            ddlMascota.DataValueField = "IdMascota";
            ddlMascota.DataBind();
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
            lblMensaje.Text = NM.InsertarCita(ControlsWebForm_ObjetoIdentidad());
            VisualizarGrvCitas();
        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            lblMensaje.Text = NM.BorrarCita(Convert.ToInt32(hfIdCita.Value));
            VisualizarGrvCitas();
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            Cita.IdCita = Convert.ToInt32(hfIdCita.Value);
            Cita.ClaveCita = tbClaveCita.Text;
            Cita.IdServicio = Convert.ToInt32(ddlServicio.Text);
            Cita.IdMascota = Convert.ToInt32(ddlMascota.Text);
            Cita.FechaCita = Convert.ToDateTime(tbFechaCita.Text);
            lblMensaje.Text = NM.ModificarCita(Cita);
            VisualizarGrvCitas();
        }

        protected void btnCancelar_Click(object sender, EventArgs e) => ControlsInit();
        #endregion

        #region Metodos Gridview
        protected void grvCitas_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            e.Cancel = true;
            hfIdCita.Value = grvCitas.DataKeys[e.RowIndex].Value.ToString();
            ObjetoEntidad_ControlsWebForm();
            ControlsSwitch(false);
            pnlGrvCitas.Visible = false;
            pnlCapturaDatos.Visible = true;
            btnBorrar.Visible = true;
            lblTituloAccion.Text = "Borrar Cita";
        }

        protected void grvCitas_RowEditing(object sender, GridViewEditEventArgs e)
        {
            e.Cancel = true;
            hfIdCita.Value = grvCitas.DataKeys[e.NewEditIndex].Value.ToString();
            ObjetoEntidad_ControlsWebForm();
            ControlsSwitch(true);
            pnlGrvCitas.Visible = false;
            pnlCapturaDatos.Visible = true;
            btnModificar.Visible = true;
            lblTituloAccion.Text = "Modificar Cita";
        }
        #endregion


    }
}