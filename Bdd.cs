using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
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

        public void insertUtilisateur(Utilisateur unUser)
        {
            string requete = "";

            try
            {
                //Connexion SQL
                this.maConnexion.Open();

                //requete paramétrée : @designation = :designation
                //requete = "insert into produit values (null, @designation, @prix, @qte, @categorie);";

                requete = "insert into utilisateur values (null, @nom, @prenom, @mail, @mdp, @pic);";

                //on crée une commande SQL
                MySqlCommand cmd = this.maConnexion.CreateCommand();

                cmd.CommandText = requete;

                //affecter les valeurs aux paramètres de la requete
                //cmd.Parameters.AddWithValue("@designation", unProduit.getDesignation());

                cmd.Parameters.AddWithValue("@nom", unUser.Nom);
                cmd.Parameters.AddWithValue("@prenom", unUser.Prenom);
                cmd.Parameters.AddWithValue("@mail", unUser.Mail);
                cmd.Parameters.AddWithValue("@mdp", unUser.Mdp);
                cmd.Parameters.AddWithValue("@pic", unUser.Pic);

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
                                unReader.GetString(4),
                                unReader.GetString(5)
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
                this.maConnexion.Open();

                requete = "update utilisateur set nom = @nom, prenom = @prenom, mail = @mail, pic = @pic where id_U = @id_U;";

                MySqlCommand cmd = this.maConnexion.CreateCommand();

                cmd.CommandText = requete;
                cmd.Parameters.AddWithValue("@nom", unUtilisateur.Nom);
                cmd.Parameters.AddWithValue("@prenom", unUtilisateur.Prenom);
                cmd.Parameters.AddWithValue("@mail", unUtilisateur.Mail);
                cmd.Parameters.AddWithValue("@pic", unUtilisateur.Pic);
                cmd.Parameters.AddWithValue("@id_U", unUtilisateur.Id_U);
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
                this.maConnexion.Open();
                MySqlCommand cmd = this.maConnexion.CreateCommand();
                cmd.CommandText = requete;
                cmd.Parameters.AddWithValue("@id_U", id_U);
                DbDataReader unReader = cmd.ExecuteReader();
                try
                {
                    if (unReader.HasRows)
                    {
                        if (unReader.Read())
                        {
                            unUtilisateur = new Utilisateur(
                              unReader.GetInt32(0), unReader.GetString(1), unReader.GetString(2), unReader.GetString(3), unReader.GetString(4), unReader.GetString(5)
                               );
                        }
                    }
                    unReader.Close();
                }
                finally
                {
                    Console.WriteLine("Erreur extraction champs de la base de données ");
                }
                this.maConnexion.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur d'execution de la requete :" + requete);
            }
            return unUtilisateur;
        }
        public reseau_fly.Utilisateur Connexion(string mail, string mdp)
        {
            Utilisateur unUtilisateur = null;
            string requete = "select * from utilisateur where mail = @mail and mdp = @mdp;";
            try
            {
                this.maConnexion.Open();
                MySqlCommand cmd = this.maConnexion.CreateCommand();
                cmd.CommandText = requete;
                cmd.Parameters.AddWithValue("@mail", mail);
                cmd.Parameters.AddWithValue("@mdp", mdp);
                DbDataReader unReader = cmd.ExecuteReader();
                try
                {
                    if (unReader.HasRows)
                    {
                        if (unReader.Read())
                        {
                            unUtilisateur = new Utilisateur(
                              unReader.GetInt32(0), unReader.GetString(1), unReader.GetString(2), unReader.GetString(3), unReader.GetString(4), unReader.GetString(5)
                               );
                        }
                    }
                    unReader.Close();
                }
                finally
                {
                    Console.WriteLine("Erreur extraction champs de la base de données ");
                }
                this.maConnexion.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur d'execution de la requete :" + requete);
            }
            return unUtilisateur;
        }

        public reseau_fly.Utilisateur verifUtilisateur(string mail, string mdp)
        {
            Utilisateur unUtilisateur = null;
            string requete = "select * from utilisateur where mail = @mail and mdp = @mdp;";
            try
            {
                this.maConnexion.Open();
                MySqlCommand cmd = this.maConnexion.CreateCommand();
                cmd.CommandText = requete;
                cmd.Parameters.AddWithValue("@mail", mail);
                cmd.Parameters.AddWithValue("@mdp", mdp);
                DbDataReader unReader = cmd.ExecuteReader();
                try
                {
                    if (unReader.HasRows)
                    {
                        if (unReader.Read())
                        {
                            unUtilisateur = new Utilisateur(
                              unReader.GetInt32(0), unReader.GetString(1), unReader.GetString(2), unReader.GetString(3), unReader.GetString(4), unReader.GetString(5)
                               );
                        }
                    }
                    unReader.Close();
                }
                finally
                {
                    Console.WriteLine("Erreur extraction champs de la base de données ");
                }
                this.maConnexion.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur d'execution de la requete :" + requete);
            }
            Debug.WriteLine(requete);
            return unUtilisateur;
        }

        public reseau_fly.Utilisateur verifMail(string mail)
        {
            Utilisateur unUtilisateur = null;
            string requete = "select * from utilisateur where mail = @mail;";
            try
            {
                this.maConnexion.Open();
                MySqlCommand cmd = this.maConnexion.CreateCommand();
                cmd.CommandText = requete;
                cmd.Parameters.AddWithValue("@mail", mail);
                DbDataReader unReader = cmd.ExecuteReader();
                try
                {
                    if (unReader.HasRows)
                    {
                        if (unReader.Read())
                        {
                            unUtilisateur = new Utilisateur(
                              unReader.GetInt32(0), unReader.GetString(1), unReader.GetString(2), unReader.GetString(3), unReader.GetString(4), unReader.GetString(5)
                               );
                        }
                    }
                    unReader.Close();
                }
                finally
                {
                    Console.WriteLine("Erreur extraction champs de la base de données ");
                }
                this.maConnexion.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur d'execution de la requete :" + requete);
            }
            Debug.WriteLine(requete);
            return unUtilisateur;
        }
        public List<Trajet> selectAllTrajets()
        {
            List<Trajet> lesTrajets = new List<Trajet>();
            string requete = "select * from trajet;";
            try
            {
                this.maConnexion.Open();
                MySqlCommand cmd = this.maConnexion.CreateCommand();
                cmd.CommandText = requete;
                DbDataReader unReader = cmd.ExecuteReader();
                try
                {
                    if (unReader.HasRows)
                    {
                        while (unReader.Read())
                        {
                            Trajet unTrajet = new Trajet(
                                unReader.GetInt32(0),
                                unReader.GetString(1),
                                unReader.GetString(2),
                                unReader.GetString(3),
                                unReader.GetString(4),
                                unReader.GetString(5),
                                unReader.GetString(6),
                                unReader.GetInt32(7)
                                );
                            lesTrajets.Add(unTrajet);
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
            return lesTrajets;
        }

        public List<Trajet> selectWhereDestination(string string_aeroport, string string_recherche)
        {
            List<Trajet> desTrajets = new List<Trajet>();

            string requete = "select * from trajet where aeroport like '%" + string_aeroport + "%' and destination like '%" + string_recherche + "%';";

            try
            {
                this.maConnexion.Open();

                MySqlCommand cmd = this.maConnexion.CreateCommand();

                cmd.CommandText = requete;

                DbDataReader unReader = cmd.ExecuteReader();

                try
                {
                    if (unReader.HasRows)
                    {
                        while (unReader.Read())
                        {
                            Trajet unTrajet = new Trajet(
                                unReader.GetInt32(0),
                                unReader.GetString(1),
                                unReader.GetString(2),
                                unReader.GetString(3),
                                unReader.GetString(4),
                                unReader.GetString(5),
                                unReader.GetString(6),
                                unReader.GetInt32(7)
                                );

                            desTrajets.Add(unTrajet);
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

            Debug.WriteLine(requete);

            return desTrajets;
        }
        public reseau_fly.Trajet detailTrajet(int id_T)
        {
            Trajet unTrajet = null;

            string requete = "select * from trajet where id_T = @id_T;";
            try
            {
                this.maConnexion.Open();
                MySqlCommand cmd = this.maConnexion.CreateCommand();
                cmd.CommandText = requete;
                cmd.Parameters.AddWithValue("@id_T", id_T);
                DbDataReader unReader = cmd.ExecuteReader();
                try
                {
                    if (unReader.HasRows)
                    {
                        if (unReader.Read())
                        {
                            unTrajet = new Trajet
                                (
                                unReader.GetInt32(0),
                                unReader.GetString(1),
                                unReader.GetString(2),
                                unReader.GetString(3),
                                unReader.GetString(4),
                                unReader.GetString(5),
                                unReader.GetString(6),
                                unReader.GetInt32(7)
                                );
                        }
                    }
                    unReader.Close();
                }
                finally
                {
                    Console.WriteLine("Erreur extraction champs de la base de données ");
                }
                this.maConnexion.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur d'execution de la requete :" + requete);
            }
            Debug.WriteLine(requete);
            return unTrajet;
        }
        public List<Trajet> selectDateDestination(string destinationDate, int id_T)
        {
            List<Trajet> desTrajets = new List<Trajet>();

            string requete = "select * from trajet where destination = @destinationDate and id_T != @id_T;";
            try
            {
                this.maConnexion.Open();
                MySqlCommand cmd = this.maConnexion.CreateCommand();
                cmd.CommandText = requete;
                cmd.Parameters.AddWithValue("@destinationDate", destinationDate);
                cmd.Parameters.AddWithValue("@id_T", id_T);

                DbDataReader unReader = cmd.ExecuteReader();
                try
                {
                    if (unReader.HasRows)
                    {
                        if (unReader.Read())
                        {
                            Trajet unTrajet = new Trajet(
                                unReader.GetInt32(0),
                                unReader.GetString(1),
                                unReader.GetString(2),
                                unReader.GetString(3),
                                unReader.GetString(4),
                                unReader.GetString(5),
                                unReader.GetString(6),
                                unReader.GetInt32(7)
                                );

                            desTrajets.Add(unTrajet);
                        }
                    }
                    unReader.Close();
                }
                finally
                {
                    Console.WriteLine("Erreur extraction champs de la base de données ");
                }
                this.maConnexion.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur d'execution de la requete :" + requete);
            }
            Debug.WriteLine(requete);
            return desTrajets;
        }
        public void insertGroupe(Groupe unGroupe)
        {
            string requete = "";

            try
            {
                this.maConnexion.Open();

                requete = "insert into groupe values (null, @nom);";

                MySqlCommand cmd = this.maConnexion.CreateCommand();

                cmd.CommandText = requete;

                cmd.Parameters.AddWithValue("@nom", unGroupe.Nom);

                //execution de la requete via la commande
                cmd.ExecuteNonQuery();

                this.maConnexion.Close();
            }
            catch (Exception E)
            {
                Console.WriteLine("Erreur d'execution de la requete : " + requete);
            }
        }
        public List<Groupe> selectUserGroupe(int id_U)
        {
            List<Groupe> desGroupes = new List<Groupe>();

            string requete = "select g.* from utilisateur u, groupe g, adherer a where u.id_U = a.id_U and a.id_G = g.id_G and u.id_U = @id_U and a.role = 'super';";

            try
            {
                this.maConnexion.Open();

                MySqlCommand cmd = this.maConnexion.CreateCommand();
                cmd.CommandText = requete;
                cmd.Parameters.AddWithValue("@id_U", id_U);
                DbDataReader unReader = cmd.ExecuteReader();

                try
                {
                    if (unReader.HasRows)
                    {
                        while (unReader.Read())
                        {
                            Groupe unGroupe = new Groupe(
                                unReader.GetInt32(0),
                                unReader.GetString(1)
                                );

                            desGroupes.Add(unGroupe);
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

            Debug.WriteLine(requete);

            return desGroupes;
        }
        public List<Groupe> selectTrajetGroupe(int id_T)
        {
            List<Groupe> desGroupes = new List<Groupe>();

            string requete = "select g.* from groupe g, voyage v where g.id_G = v.id_G and v.id_T = @id_T;";

            try
            {
                this.maConnexion.Open();

                MySqlCommand cmd = this.maConnexion.CreateCommand();
                cmd.CommandText = requete;
                cmd.Parameters.AddWithValue("@id_T", id_T);
                DbDataReader unReader = cmd.ExecuteReader();

                try
                {
                    if (unReader.HasRows)
                    {
                        while (unReader.Read())
                        {
                            Groupe unGroupe = new Groupe(
                                unReader.GetInt32(0),
                                unReader.GetString(1)
                                );

                            desGroupes.Add(unGroupe);
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

            Debug.WriteLine(requete);

            return desGroupes;
        }
        public List<Utilisateur> selectGroupeUsers(int id_G)
        {
            List<Utilisateur> lesUtilisateurs = new List<Utilisateur>();
            string requete = "select u.* from utilisateur u, adherer a where u.id_U = a.id_U and a.id_G = @id_G;";
            try
            {
                this.maConnexion.Open();
                MySqlCommand cmd = this.maConnexion.CreateCommand();
                cmd.CommandText = requete;
                cmd.Parameters.AddWithValue("@id_G", id_G);
                DbDataReader unReader = cmd.ExecuteReader();
                try
                {
                    if (unReader.HasRows)
                    {
                        while (unReader.Read())
                        {
                            Utilisateur unUtilisateur = new Utilisateur(
                                unReader.GetInt32(0),
                                unReader.GetString(1),
                                unReader.GetString(2),
                                unReader.GetString(3),
                                unReader.GetString(4),
                                unReader.GetString(5)
                                );
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
        public reseau_fly.Groupe detailGroupe(int id_G)
        {
            Groupe unGroupe = null;

            string requete = "select * from groupe where id_G = @id_G;";
            try
            {
                this.maConnexion.Open();
                MySqlCommand cmd = this.maConnexion.CreateCommand();
                cmd.CommandText = requete;
                cmd.Parameters.AddWithValue("@id_G", id_G);
                DbDataReader unReader = cmd.ExecuteReader();
                try
                {
                    if (unReader.HasRows)
                    {
                        if (unReader.Read())
                        {
                            unGroupe = new Groupe
                                (
                                unReader.GetInt32(0),
                                unReader.GetString(1)
                                );
                        }
                    }
                    unReader.Close();
                }
                finally
                {
                    Console.WriteLine("Erreur extraction champs de la base de données ");
                }
                this.maConnexion.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur d'execution de la requete :" + requete);
            }
            Debug.WriteLine(requete);
            return unGroupe;
        }

        public String selectRoleUser(int id_U)
        {
            string requete = "select role from adherer where id_U = @id_U;";

            string role = "";

            try
            {
                this.maConnexion.Open();
                MySqlCommand cmd = this.maConnexion.CreateCommand();
                cmd.CommandText = requete;
                cmd.Parameters.AddWithValue("@id_U", id_U);
                DbDataReader unReader = cmd.ExecuteReader();
                try
                {
                    if (unReader.HasRows)
                    {
                        while (unReader.Read())
                        {
                            role = unReader.GetString(0);
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
            Debug.WriteLine(requete);
            return role;
        }
        public List<Details_Voyage> selectDetailsVoyage(int id_G)
        {
            List<Details_Voyage> lesDetails = new List<Details_Voyage>();

            string requete = "select v.id_V, t.date, v.titre, t.destination from trajet t, voyage v where t.id_T = v.id_T and v.id_G = @id_G;";
            try
            {
                this.maConnexion.Open();
                MySqlCommand cmd = this.maConnexion.CreateCommand();
                cmd.CommandText = requete;
                cmd.Parameters.AddWithValue("@id_G", id_G);
                DbDataReader unReader = cmd.ExecuteReader();
                try
                {
                    if (unReader.HasRows)
                    {
                        while (unReader.Read())
                        {
                            Details_Voyage unDetail = new Details_Voyage(
                                unReader.GetInt32(0),
                                unReader.GetString(1),
                                unReader.GetString(2),
                                unReader.GetString(3)
                                );
                            lesDetails.Add(unDetail);
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
            Debug.WriteLine(requete);
            return lesDetails;
        }
        public List<Adherer> selectAdherer(int id_U)
        {
            List<Adherer> lesAdhesions = new List<Adherer>();

            string requete = "select * from adherer where id_U = @id_U;";
            try
            {
                this.maConnexion.Open();
                MySqlCommand cmd = this.maConnexion.CreateCommand();
                cmd.CommandText = requete;
                cmd.Parameters.AddWithValue("@id_G", id_U);
                DbDataReader unReader = cmd.ExecuteReader();
                try
                {
                    if (unReader.HasRows)
                    {
                        while (unReader.Read())
                        {
                            Adherer uneAdhesion = new Adherer(
                                unReader.GetInt32(0),
                                unReader.GetInt32(1),
                                unReader.GetString(2)
                                );
                            lesAdhesions.Add(uneAdhesion);
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
            Debug.WriteLine(requete);
            return lesAdhesions;
        }
    }
}