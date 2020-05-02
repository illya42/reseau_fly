using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace reseau_fly
{
    public class Utilisateur
    {
        private int id_U;
        private string nom;
        private string prenom;
        private string mail;
        private string pic;
        public Utilisateur()
        {
            this.Id_U = 0;
            this.Nom = "";
            this.Prenom = "";
            this.Mail = "";
            this.Pic = "";
        }
        public Utilisateur(string nom, string prenom, string mail, string pic)
        {
            this.Nom = nom;
            this.Prenom = prenom;
            this.Mail = mail;
            this.Pic = pic;
        }

        public Utilisateur(int id_U, string nom, string prenom, string mail, string pic)
        {
            this.Id_U = id_U;
            this.Nom = nom;
            this.Prenom = prenom;
            this.Mail = mail;
            this.Pic = pic;
        }

        public int Id_U { get => id_U; set => id_U = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Mail { get => mail; set => mail = value; }
        public string Pic { get => pic; set => pic = value; }

        public string afficher()
        {
            string chaine = "<table border =1>";
            chaine += "<tr><td> id Utilisateur </td><td> Nom </td> <td> Prénom </td> <td> Mail </td><td> Pic </td></tr>";
            chaine += "<tr><td> " + this.Id_U + "</td> <td> " + this.Nom + "</td> <td>" + this.Prenom + "</td> <td>" + this.Mail + "</td> <td>" + this.Pic + "</td> </tr>";
            chaine += "</table>";
            return chaine;
        }
    }
}