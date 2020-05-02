using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace reseau_fly
{
    public class Trajet
    {
        private int id_T;
        private string heure_dep, heure_arr, aeroport, date, destination, image;
        private int prix;

        public Trajet()
        {
            this.Id_T = 0;
            this.Heure_dep = this.Heure_arr = this.Aeroport = this.Date = this.Destination = this.Image = "";
            this.Prix = 0;
        }
        public Trajet(string heure_dep, string heure_arr, string aeroport, string date, string destination, string image, int prix)
        {
            this.Heure_dep = heure_dep;
            this.Heure_arr = heure_arr;
            this.Aeroport = aeroport;
            this.Date = date;
            this.Destination = destination;
            this.Image = image;
            this.Prix = prix;
        }
        public Trajet(int id_T, string heure_dep, string heure_arr, string aeroport, string date, string destination, string image, int prix)
        {
            this.Id_T = id_T;
            this.Heure_dep = heure_dep;
            this.Heure_arr = heure_arr;
            this.Aeroport = aeroport;
            this.Date = date;
            this.Destination = destination;
            this.Image = image;
            this.Prix = prix;
        }

        public int Id_T { get => id_T; set => id_T = value; }
        public string Heure_dep { get => heure_dep; set => heure_dep = value; }
        public string Heure_arr { get => heure_arr; set => heure_arr = value; }
        public string Aeroport { get => aeroport; set => aeroport = value; }
        public string Date { get => date; set => date = value; }
        public string Destination { get => destination; set => destination = value; }
        public string Image { get => image; set => image = value; }
        public int Prix { get => prix; set => prix = value; }

        public string afficher()
        {
            string chaine = "<table border =1>";
            chaine += "<tr><td> id Trajet </td><td> Heure départ </td><td> Heure arrivée </td><td> Aéroport de départ </td><td> Date </td><td> Destination </td><td> Image </td><td> Prix </td></tr>";
            chaine += "<tr><td> " + this.id_T + "</td> <td> " + this.heure_dep + "</td> <td>" + this.heure_arr + "</td> <td>" + this.aeroport + "</td> <td>" + this.date + "</td> <td>" + this.destination + "</td> <td>" + this.image + "</td> <td>" + this.prix + "</td></tr>";
            chaine += "</table>";
            return chaine;
        }
    }
}