using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace reseau_fly.template.include
{
    public partial class header_test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["mail"] != null)
            {
                login_div.Style["display"] = "inline-block"; //the default display mode

                utilisateur_details.Text = Session["nom"].ToString() + " " + Session["prenom"].ToString();
            }
            else
            {
                login_div.Style["display"] = "none";
            }
        }
    }
}