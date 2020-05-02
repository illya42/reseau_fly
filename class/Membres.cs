using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace reseau_fly
{
    public class Membres
    {
        private int id_M;
        private int id_U;
        private int id_G;

        public Membres()
        {
            this.Id_M = 0;
            this.Id_U = 0;
            this.Id_G = 0;
        }
        public Membres(int id_U, int id_G)
        {
            this.Id_U = id_U;
            this.Id_G = id_G;
        }

        public Membres(int id_M, int id_U, int id_G)
        {
            this.Id_M = id_M;
            this.Id_U = id_U;
            this.Id_G = id_G;
        }
        public int Id_M { get => id_M; set => id_M = value; }
        public int Id_U { get => id_U; set => id_U = value; }
        public int Id_G { get => id_G; set => id_G = value; }

        public string afficher()
        {
            string chaine = "<table border =1>";
            chaine += "<tr><td> id Membres </td><td> id Utilisateur </td> <td> id Groupe </td></tr>";
            chaine += "<tr><td> " + this.Id_M + "</td> <td> " + this.Id_U + "</td> <td>" + this.Id_G + "</td></tr>";
            chaine += "</table>";
            return chaine;
        }
    }
}