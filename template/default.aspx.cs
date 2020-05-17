using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace reseau_fly
{
    public partial class _default : System.Web.UI.Page
    {
        public string header_file, footer_file;
        override protected void OnInit(EventArgs e)
        {
            base.OnInit(e);
            header_file = "header.html";

            footer_file = "footer.html";
        }
    }
}