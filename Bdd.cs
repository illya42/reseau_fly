using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace reseau_fly
{
    public class Bdd
    {
        //Déclaration d'une instance de connexion à Mysql
        private MySqlConnection maConnexion = null;
        public Bdd()
        {
            string url = "SERVER=127.0.0.1;port=3306;Database=dbfly_c;User Id=root;password=root";

            try
            {
                this.maConnexion = new MySqlConnection(url);
                Console.WriteLine("Connexion réussie");
            }
            catch (Exception E)
            {
                Console.WriteLine("Erreur de connexion à : " + url);
            }
        }

        public void insertUtilisateur(reseau_fly.Utilisateur unUtilisateur)
        {
            string requete = "";

            try
            {
                //Connexion SQL
                this.maConnexion.Open();

                //requete paramétrée : @designation = :designation
                //requete = "insert into produit values (null, @designation, @prix, @qte, @categorie);";

                requete = "insert into utilisateur values (null, @nom, @prenom, @mail, @pic);";

                //on crée une commande SQL
                MySqlCommand cmd = this.maConnexion.CreateCommand();

                cmd.CommandText = requete;

                //affecter les valeurs aux paramètres de la requete
                //cmd.Parameters.AddWithValue("@designation", unProduit.getDesignation());

                cmd.Parameters.AddWithValue("@nom", unUtilisateur.Nom);
                cmd.Parameters.AddWithValue("@prenom", unUtilisateur.Prenom);
                cmd.Parameters.AddWithValue("@mail", unUtilisateur.Mail);
                cmd.Parameters.AddWithValue("@pic", unUtilisateur.Pic);

                //execution de la requete via la commande
                cmd.ExecuteNonQuery();

                this.maConnexion.Close();
            }
            catch (Exception E)
            {
                Console.WriteLine("Erreur d'execution de la requete : " + requete);
            }
        }
        public List<Utilisateur> selectAllUtilisateurs()
        {
            List<Utilisateur> lesUtilisateurs = new List<Utilisateur>();

            string requete = "select * from utilisateur;";

            try
            {
                this.maConnexion.Open();

                MySqlCommand cmd = this.maConnexion.CreateCommand();

                cmd.CommandText = requete;

                //Parcourir les enregistrements : ResultSet
                DbDataReader unReader = cmd.ExecuteReader();

                try
                {
                    if (unReader.HasRows)
                    {
                        //Parcours des résultats avec un while lire
                        while (unReader.Read())
                        {
                            //On instancie un produit
                            Utilisateur unUtilisateur = new Utilisateur(
                                unReader.GetInt32(0),
                                unReader.GetString(1),
                                unReader.GetString(2),
                                unReader.GetString(3),
                                unReader.GetString(4)
                                );

                            //On ajoute un produit dans la liste
                            lesUtilisateurs.Add(unUtilisateur);
                        }
                    }
                    unReader.Close();
                }
                finally
                {
                    Console.WriteLine("Erreur extraction des champs de la BDD");
                }

                this.maConnexion.Close();
            }
            catch (Exception E)
            {
                Console.WriteLine("Erreur d'execution de la requete : " + requete);
            }

            return lesUtilisateurs;
        }

        public void deleteUtilisateur(int id_U)
        {
            string requete = "delete from utilisateur where id_U = @id_U;";

            try
            {
                this.maConnexion.Open();

                MySqlCommand cmd = this.maConnexion.CreateCommand();

                cmd.CommandText = requete;

                cmd.Parameters.AddWithValue("@id_U", id_U);

                //execution de la requete via la commande
                cmd.ExecuteNonQuery();

                this.maConnexion.Close();
            }
            catch (Exception E)
            {
                Console.WriteLine("Erreur d'execution de la requete : " + requete);
            }
        }

        public void updateUtilisateur(reseau_fly.Utilisateur unUtilisateur)
        {
            string requete = "";

            try
            {
                //Connexion SQL
                this.maConnexion.Open();

                //requete paramétrée : @designation = :designation
                requete = "update utilisateur set nom = @nom, prenom = @prenom, mail = @mail, pic = @pic where id_U = @id_U;";

                //on crée une commande SQL
                MySqlCommand cmd = this.maConnexion.CreateCommand();

                cmd.CommandText = requete;

                //affecter les valeurs aux paramètres de la requete
                cmd.Parameters.AddWithValue("@nom", unUtilisateur.Nom);
                cmd.Parameters.AddWithValue("@prenom", unUtilisateur.Prenom);
                cmd.Parameters.AddWithValue("@mail", unUtilisateur.Mail);
                cmd.Parameters.AddWithValue("@pic", unUtilisateur.Pic);
                cmd.Parameters.AddWithValue("@id_U", unUtilisateur.Id_U);

                //execution de la requete via la commande
                cmd.ExecuteNonQuery();

                this.maConnexion.Close();
            }
            catch (Exception E)
            {
                Console.WriteLine("Erreur d'execution de la requete : " + requete);
            }
        }
        public reseau_fly.Utilisateur selectWhereUtilisateur(int id_U)
        {
            Utilisateur unUtilisateur = null;
            string requete = "select * from utilisateur where id_U = @id_U;";

            try
            {
                //ouverture de la connexion SQL
                this.maConnexion.Open();

                //on crée une commande SQL (comme Statement en java)
                MySqlCommand cmd = this.maConnexion.CreateCommand();

                cmd.CommandText = requete;
                cmd.Parameters.AddWithValue("@id_U", id_U);

                //parcourir les enregitrements (comme en java : ResultSet)
                DbDataReader unReader = cmd.ExecuteReader();
                try
                {
                    if (unReader.HasRows)
                    {
                        //parcours des resultats avec un while lire
                        if (unReader.Read())
                        {
                            //on instancie un produit 
                            unUtilisateur = new Utilisateur(
                              unReader.GetInt32(0), unReader.GetString(1), unReader.GetString(2), unReader.GetString(3), unReader.GetString(4)
                               );
                        }
                    }
                    unReader.Close();
                }
                finally
                {
                    Console.WriteLine("Erreur extraction champs de la base de données ");
                }

                //fermeture de la connexion 
                this.maConnexion.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur d'execution de la requete :" + requete);
            }

            return unUtilisateur;
        }
    }
}