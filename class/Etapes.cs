using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace reseau_fly
{
    public class Etapes
    {
        private int id_E, id_V;
        private string type, statut, libelle, details, date;

        public Etapes()
        {
            this.Id_E = Id_V = 0;
            this.Type = Statut = Libelle = Details = Date = "";
        }
        public Etapes(int id_V, string type, string statut, string libelle, string details, string date)
        {
            this.Id_V = id_V;
            this.Type = type;
            this.Statut = statut;
            this.Libelle = libelle;
            this.Details = details;
            this.Date = date;
        }

        public Etapes(int id_E, int id_V, string type, string statut, string libelle, string details, string date)
        {
            this.Id_E = id_E;
            this.Id_V = id_V;
            this.Type = type;
            this.Statut = statut;
            this.Libelle = libelle;
            this.Details = details;
            this.Date = date;
        }

        public int Id_E { get => id_E; set => id_E = value; }
        public int Id_V { get => id_V; set => id_V = value; }
        public string Type { get => type; set => type = value; }
        public string Statut { get => statut; set => statut = value; }
        public string Libelle { get => libelle; set => libelle = value; }
        public string Details { get => details; set => details = value; }
        public string Date { get => date; set => date = value; }

        public string afficher()
        {
            string chaine = "<table border =1>";
            chaine += "<tr><td> id Etapes </td><td> id Voyage </td><td> Type </td><td> Statut </td><td> Libellé </td><td> Détails </td><td> Date </td></tr>";
            chaine += "<tr><td> " + this.id_E + "</td> <td> " + this.id_V + "</td> <td> " + this.type + "</td> <td> " + this.statut + "</td> <td> " + this.libelle + "</td> <td> " + this.details + "</td> <td> " + this.date + "</td></tr>";
            chaine += "</table>";
            return chaine;
        }
    }
}