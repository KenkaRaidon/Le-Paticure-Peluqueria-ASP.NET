using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Le_Paticure_Peluqueria.WebForms
{
    public partial class EmailCita : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                Destinatario();
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            EnviaEmail(ddlDestinatario.SelectedValue, tbAsunto.Text, tbMensajeEmail.Text);
            tbAsunto.Text = string.Empty;
            tbMensajeEmail.Text = string.Empty;
        }
        public void EnviaEmail(string pEmailDestino, string pAsunto, string pMensaje)
        {
            try
            {
                MailMessage Email = new MailMessage();
                Email.SubjectEncoding = Encoding.UTF8;
                Email.BodyEncoding = Encoding.UTF8;
                Email.From = new MailAddress("lepaticure98@gmail.com");
                Email.Subject = pAsunto;
                Email.Body = pMensaje;
                Email.To.Add(pEmailDestino);
               
                SmtpClient cliente = new SmtpClient();
                cliente.DeliveryMethod = SmtpDeliveryMethod.Network;
                cliente.Host = "smtp.gmail.com";
                cliente.Port = 587;
                cliente.Credentials = new NetworkCredential("lepaticure98@gmail.com", "lepaticure0987");
                cliente.EnableSsl = true;
                cliente.Send(Email);
            }
            catch (SmtpException ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        protected void Destinatario()
        {
            ddlDestinatario.DataSource = consultar("SELECT * FROM Mascotas");
            ddlDestinatario.DataTextField = "EmailDueño";
            ddlDestinatario.DataValueField = "EmailDueño";
            ddlDestinatario.DataBind();
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
    }
}