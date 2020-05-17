using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace reseau_fly.template
{
    public partial class inscription : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Inscription(object sender, EventArgs e)
        {
            Regex r = new Regex("^[a-zA-Z0-9]+$");

            bool verif_n = false;
            bool verif_p = false;
            bool verif_m = false;
            bool verif_mdp = false;

            string nom = Nom.Text;
            string prenom = Prenom.Text;
            string mail = Mail.Text;
            string mdp = Mdp.Text;

            string pic = "pic";

            Bdd uneBdd = new Bdd();

            if (uneBdd.verifMail(mail) != null)
            {
                Mail.Text = "";

                Mail.Attributes.Add("placeholder", "Adresse mail déjà utilisé !");
            }
            else
            {
                verif_m = true;
            }

            if (r.IsMatch(nom))
            {
                verif_n = true;
            }
            else
            {
                Nom.Text = "";

                Nom.Attributes.Add("placeholder", "Caractères incorrectes !");

                verif_n = false;
            }

            if (r.IsMatch(prenom))
            {
                verif_p = true;
            }
            else
            {
                Prenom.Text = "";

                Prenom.Attributes.Add("placeholder", "Caractères incorrectes !");

                verif_p = false;
            }

            if (r.IsMatch(mdp))
            {
                verif_mdp = true;
            }
            else
            {
                Mdp.Text = "";

                Mdp.Attributes.Add("placeholder", "Caractères incorrectes !");
                
                verif_mdp = false;
            }

            Utilisateur unUser = new Utilisateur(nom, prenom, mail, mdp, pic);

            if (verif_n == true && verif_p == true && verif_m == true && verif_mdp == true)
            {
                uneBdd.insertUtilisateur(unUser);

                Debug.WriteLine(nom + " " + prenom + " " + mail + " " + mdp + " " + pic);

                Session["nom"] = unUser.Nom;
                Session["prenom"] = unUser.Prenom;
                Session["mail"] = unUser.Mail;

                Response.Redirect("home.aspx");
            }
        }
    }
}