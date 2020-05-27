using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace reseau_fly.template
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void connection(object sender, EventArgs e)
        {
            reseau_fly.Bdd uneBdd = new reseau_fly.Bdd();

            // User / Mdp = ID des TextBox 
            Utilisateur unUtilisateur = new Utilisateur();

            string mail = Mail.Text;
            string mdp = Mdp.Text;

            if (uneBdd.verifUtilisateur(mail, mdp) != null)
            {
                unUtilisateur = uneBdd.verifUtilisateur(mail, mdp);

                Session["nom"] = unUtilisateur.Nom;
                Session["prenom"] = unUtilisateur.Prenom;
                Session["mail"] = unUtilisateur.Mail;
                Session["Id_U"] = unUtilisateur.Id_U;

                //uneBdd.selectUserGroupe(unUtilisateur.Id_U);
                Response.Redirect("home.aspx");
                //Response.Redirect(Request.UrlReferrer.ToString());
            }
            else
            {
                if(uneBdd.verifMail(mail) != null)
                {
                    Mdp.Text = "";

                    Mdp.Attributes.Add("placeholder", "Mauvais mot de passe !");
                }
                else
                {
                    Mail.Text = "";
                    Mdp.Text = "";

                    Mail.Attributes.Add("placeholder", "Mauvaise adresse !");
                    Mdp.Attributes.Add("placeholder", "Mauvais mot de passe !");
                }
            }
        }
    }
}