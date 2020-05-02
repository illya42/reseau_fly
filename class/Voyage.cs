using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace reseau_fly
{
    public class Voyage
    {
        private int id_V, id_G, id_T;
        private string titre;

        public Voyage()
        {
            this.Id_V = 0;
            this.Id_G = 0;
            this.Id_T = 0;
            this.Titre = "";
        }
        public Voyage(int id_G, int id_T, string titre)
        {
            this.Id_G = 0;
            this.Id_T = 0;
            this.Titre = titre;
        }

        public Voyage(int id_V, int id_G, int id_T, string titre)
        {
            this.Id_V = id_V;
            this.Id_G = id_G;
            this.Id_T = id_T;
            this.Titre = titre;
        }

        public int Id_V { get => id_V; set => id_V = value; }
        public int Id_G { get => id_G; set => id_G = value; }
        public int Id_T { get => id_T; set => id_T = value; }
        public string Titre { get => titre; set => titre = value; }

        public string afficher()
        {
            string chaine = "<table border =1>";
            chaine += "<tr><td> id Voyage </td><td> id Groupe </td><td> id Trajet </td><td> Titre </td></tr>";
            chaine += "<tr><td> " + this.id_V + "</td> <td> " + this.id_G + "</td> <td> " + this.id_T + "</td> <td> " + this.titre + "</td></tr>";
            chaine += "</table>";
            return chaine;
        }
    }
}