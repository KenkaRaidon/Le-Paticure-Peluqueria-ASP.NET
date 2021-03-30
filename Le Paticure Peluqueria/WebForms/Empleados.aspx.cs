using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

using Entidades;
using Negocios;

namespace Le_Paticure_Peluqueria.WebForms
{
    public partial class Empleados : System.Web.UI.Page
    {
        E_Empleado Empleado = new E_Empleado();
        N_Empleado NC = new N_Empleado();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                ControlsInit();
        }

        #region Metodos General
        protected void ControlsInit()
        {
            ControlsOff();
            ControlsClear();
            ControlsSwitch(true);
        }
        protected void ControlsOff()
        {
            pnlCapturaDatos.Visible = false;
            pnlGrvEmpleados.Visible = false;
            btnInsertar.Visible = false;
            btnBorrar.Visible = false;
            btnModificar.Visible = false;
        }
        protected void ControlsClear()
        {
            tbClaveEmpleado.Text = string.Empty;
            tbNombreEmpleado.Text = string.Empty;
            tbApellidoEmpleado.Text = string.Empty;
            tbDireccionEmpleado.Text = string.Empty;
            tbTelCelEmpleado.Text = string.Empty;
            TbEmailEmpleado.Text = string.Empty;
        }
        protected void ControlsSwitch(bool TrueOrFalse)
        {
            tbClaveEmpleado.Enabled = TrueOrFalse;
            tbNombreEmpleado.Enabled = TrueOrFalse;
            tbApellidoEmpleado.Enabled = TrueOrFalse;
            tbDireccionEmpleado.Enabled = TrueOrFalse;
            tbTelCelEmpleado.Enabled = TrueOrFalse;
            TbEmailEmpleado.Enabled = TrueOrFalse;
        }
        #endregion

        #region ObjetoCliente
        protected E_Empleado ControlsWebForm_ObjetoIdentidad()
        {
            E_Empleado Empleado = new E_Empleado()
            {
                ClaveEmpleado = tbClaveEmpleado.Text.Trim(),
                NombreEmpleado = tbNombreEmpleado.Text.Trim(),
                ApellidoEmpleado = tbApellidoEmpleado.Text.Trim(),
                DireccionEmpleado = tbDireccionEmpleado.Text.Trim(),
                TelCelEmpleado = tbTelCelEmpleado.Text.Trim(),
                EmailEmpleado=TbEmailEmpleado.Text.Trim()
            };
            return Empleado;
        }
        protected void ObjetoEntidad_ControlsWebForm()
        {
            int IdEmpleado = hfIdEmpleado.Value == string.Empty ? 0 : Convert.ToInt32(hfIdEmpleado.Value);

            E_Empleado Empleado = NC.BuscarEmpleado(IdEmpleado);
            if (Empleado != null)
            {
                tbClaveEmpleado.Text = Empleado.ClaveEmpleado.Trim();
                tbNombreEmpleado.Text = Empleado.NombreEmpleado.Trim();
                tbApellidoEmpleado.Text = Empleado.ApellidoEmpleado.Trim();
                tbDireccionEmpleado.Text = Empleado.DireccionEmpleado.Trim();
                tbTelCelEmpleado.Text = Empleado.TelCelEmpleado.Trim();
                TbEmailEmpleado.Text = Empleado.EmailEmpleado.Trim();
            }
        }
        protected void VisualizarGrvEmpleados(List<E_Empleado> LstEmpleados)
        {
            ControlsInit();
            pnlGrvEmpleados.Visible = true;
            lblNumeroRegistro.Text = LstEmpleados.Count.ToString();
            if (LstEmpleados.Count.Equals(0))
                lblMensaje.Text = "No hay informacion para mostrar";
            else
            {
                grvEmpleados.DataSource = LstEmpleados;
                grvEmpleados.DataBind();
            }
        }
        #endregion

        #region Botones Menu Navegacion
        protected void btnMenuNuevo_Click(object sender, EventArgs e)
        {
            pnlGrvEmpleados.Visible = false;
            pnlCapturaDatos.Visible = true;
            btnInsertar.Visible = true;
            lblTituloAccion.Text = "Nuevo Empleado";
        }
        protected void btnMenuListado_Click(object sender, EventArgs e)
        {
            pnlGrvEmpleados.Visible = true;
            VisualizarGrvEmpleados(NC.LstEmpleados());
        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (tbCriterioBusqueda.Text.Trim() != string.Empty)
            {
                List<E_Empleado> LstEmpleados = NC.LstBuscarEmpleado(tbCriterioBusqueda.Text.Trim());

                switch (LstEmpleados.Count)
                {
                    case 0:
                        lblMensaje.Text = "No se encontro informacion";
                        lblMensaje.Visible = true;
                        break;
                    case 1:
                        ControlsInit();
                        hfIdEmpleado.Value = LstEmpleados[0].IdEmpleado.ToString();
                        ObjetoEntidad_ControlsWebForm();
                        pnlCapturaDatos.Visible = true;
                        break;
                    default:
                        VisualizarGrvEmpleados(LstEmpleados);
                        break;
                }
            }
        }
        #endregion

        #region Botones IBM
        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            lblMensaje.Text = NC.InsertarEmpleado(ControlsWebForm_ObjetoIdentidad());
            VisualizarGrvEmpleados(NC.LstEmpleados());
        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            lblMensaje.Text = NC.BorrarEmpleado(Convert.ToInt32(hfIdEmpleado.Value));
            VisualizarGrvEmpleados(NC.LstEmpleados());
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            Empleado.IdEmpleado = Convert.ToInt32(hfIdEmpleado.Value);
            Empleado.ClaveEmpleado = tbClaveEmpleado.Text;
            Empleado.NombreEmpleado = tbNombreEmpleado.Text;
            Empleado.ApellidoEmpleado = tbApellidoEmpleado.Text;
            Empleado.DireccionEmpleado = tbDireccionEmpleado.Text;
            Empleado.TelCelEmpleado = tbTelCelEmpleado.Text;
            Empleado.EmailEmpleado = TbEmailEmpleado.Text;
            lblMensaje.Text = NC.ModificarEmpleado(Empleado);
            VisualizarGrvEmpleados(NC.LstEmpleados());
        }

        protected void btnCancelar_Click(object sender, EventArgs e) => ControlsInit();
        #endregion

        #region Metodos Gridview
        protected void grvEmpleados_RowEditing(object sender, GridViewEditEventArgs e)
        {
            e.Cancel = true;
            hfIdEmpleado.Value = grvEmpleados.DataKeys[e.NewEditIndex].Value.ToString();
            ObjetoEntidad_ControlsWebForm();
            ControlsSwitch(true);
            pnlGrvEmpleados.Visible = false;
            pnlCapturaDatos.Visible = true;
            btnModificar.Visible = true;
            lblTituloAccion.Text = "Modificar cliente";
        }
        protected void grvEmpleados_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            e.Cancel = true;
            hfIdEmpleado.Value = grvEmpleados.DataKeys[e.RowIndex].Value.ToString();
            ObjetoEntidad_ControlsWebForm();
            ControlsSwitch(false);
            pnlGrvEmpleados.Visible = false;
            pnlCapturaDatos.Visible = true;
            btnBorrar.Visible = true;
            lblTituloAccion.Text = "Borrar cliente";
        }
        #endregion

    }
}