using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace reseau_fly
{
    public class Details_Voyage
    {
        private int id_V;
        private string date;
        private string titre;
        private string destination;
        public Details_Voyage()
        {
            this.Id_V = 0;
            this.Date = "";
            this.Titre = "";
            this.Destination = "";
        }
        public Details_Voyage(int id_V, string date, string nom, string destination)
        {
            this.Id_V = id_V;
            this.Date = date;
            this.Titre = nom;
            this.Destination = destination;
        }

        public int Id_V { get => id_V; set => id_V = value; }
        public string Date { get => date; set => date = value; }
        public string Titre { get => titre; set => titre = value; }
        public string Destination { get => destination; set => destination = value; }
    }

}