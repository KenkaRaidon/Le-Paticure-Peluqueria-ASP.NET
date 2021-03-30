using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Le_Paticure_Peluqueria.Controls
{
    public partial class wfucPassword : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public string Text
        {
            get { return tbPassword.Text.Trim(); }
            set { tbPassword.Text = value; }
        }
        public bool Enabled
        {
            set { tbPassword.Enabled = value; }
        }
    }
}