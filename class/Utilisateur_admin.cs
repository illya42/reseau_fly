using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace reseau_fly
{
    public class Utilisateur_admin
    {
        private int id_A;
        private int id_U;
        private string role;
        public Utilisateur_admin()
        {
            this.Id_A = 0;
            this.Id_U = 0;
            this.Role = "";
        }
        public Utilisateur_admin(int id_U, string role)
        {
            this.Id_U = id_U;
            this.Role = role;
        }

        public Utilisateur_admin(int id_A, int id_U, string role)
        {
            this.Id_A = id_A;
            this.Id_U = id_U;
            this.Role = role;
        }

        public int Id_A { get => id_A; set => id_A = value; }
        public int Id_U { get => id_U; set => id_U = value; }
        public string Role { get => role; set => role = value; }

        public string afficher()
        {
            string chaine = "<table border =1>";
            chaine += "<tr><td> id Admin </td><td> id Utilisateur </td> <td> Rôle </td></tr>";
            chaine += "<tr><td> " + this.Id_A + "</td> <td> " + this.Id_U + "</td> <td>" + this.Role + "</td></tr>";
            chaine += "</table>";
            return chaine;
        }
    }
}