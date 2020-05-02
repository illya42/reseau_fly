using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace reseau_fly
{
    public class Groupe
    {
        private int id_G;
        private string nom;

        public Groupe()
        {
            this.Id_G = 0;
            this.Nom = "";
        }
        public Groupe(string nom)
        {
            this.Nom = nom;
        }

        public Groupe(int id_G, string nom)
        {
            this.Id_G = id_G;
            this.Nom = nom;
        }

        public int Id_G { get => id_G; set => id_G = value; }
        public string Nom { get => nom; set => nom = value; }

        public string afficher()
        {
            string chaine = "<table border =1>";
            chaine += "<tr><td> id Groupe </td><td> Nom </td></tr>";
            chaine += "<tr><td> " + this.id_G + "</td> <td> " + this.Nom + "</td></tr>";
            chaine += "</table>";
            return chaine;
        }
    }
}