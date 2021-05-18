using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Le_Paticure_Peluqueria.Controls
{
    public partial class wfucMensajeEmail : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public string Text
        {
            get { return tbMensajeEmail.Text.Trim(); }
            set { tbMensajeEmail.Text = value; }
        }
        public bool Enabled
        {
            set { tbMensajeEmail.Enabled = value; }
        }
    }
}