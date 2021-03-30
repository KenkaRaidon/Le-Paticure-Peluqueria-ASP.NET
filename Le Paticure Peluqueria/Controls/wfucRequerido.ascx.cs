using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Le_Paticure_Peluqueria.Controls
{
    public partial class wfucRequerido : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public string Text
        {
            get { return tbRequerido.Text.Trim(); }
            set { tbRequerido.Text = value; }
        }
        public bool Enabled
        {
            set { tbRequerido.Enabled = value; }
        }
    }
}