using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Le_Paticure_Peluqueria.Controls
{
    public partial class wfucFechaCita : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public string Text
        {
            get { return tbFechaCita.Text.Trim(); }
            set { tbFechaCita.Text = value; }
        }
        public bool Enabled
        {
            set { tbFechaCita.Enabled = value; }
        }
    }
}