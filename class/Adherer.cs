using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace reseau_fly
{
    public class Adherer
    {
        private int id_U;
        private int id_G;
        private string role;
        public Adherer()
        {
            this.Id_U = 0;
            this.Id_G = 0;
            this.Role = "";
        }
        public Adherer(int id_U, int id_G, string role)
        {
            this.Id_U = id_U;
            this.Id_G = id_G;
            this.Role = role;
        }

        public int Id_U { get => id_U; set => id_U = value; }
        public int Id_G { get => id_G; set => id_G = value; }
        public string Role { get => role; set => role = value; }
    }
}