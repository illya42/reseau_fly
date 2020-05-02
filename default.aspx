<%@ Page Language="C#" %>
<%@ Import Namespace="System.Collections.Generic" %>
<meta charset="utf-8">
<!DOCTYPE html>
<html>
<head runat="server">
    <title>Default</title>
    <script runat="server">
    
    </script>
</head>
<body>
    <h1> Gestion des Utilisateurs </h1>
   
    <%
        string n = "test";
        reseau_fly.Bdd uneBdd = new reseau_fly.Bdd();
        reseau_fly.Utilisateur unUGet = null;
        if (Request["action"] != null && Request["id_U"] != null && Request["action"] == "e") 
        {
            int id_U = int.Parse(Request["id_U"]);
            unUGet = uneBdd.selectWhereUtilisateur(id_U);
        }
    %>

    <form id="form2" method="POST"> 
      
            <table border="0"> 
             <tr><td> Nom : </td><td> <input type="text" name="nom"  value='<%= (unUGet==null)?"":unUGet.Nom %>'> </td></tr> 
             <tr><td> Prénom : </td><td> <input type="text" name="prenom" value='<%= (unUGet==null)?"":unUGet.Prenom +"" %>'> </td></tr> 
             <tr><td> Adresse mail : </td><td> <input type="text" name="mail" value='<%= (unUGet==null)?"":unUGet.Mail +"" %>' > </td></tr> 
             <tr><td> Image de profil : </td><td> <input type="text" name="pic" value='<%= (unUGet==null)?"":unUGet.Pic %>'> </td></tr> 
                 
             <tr><td>  <input type="reset" name="Annuler" value="Annuler" > </td> 
                 <td> <%= (unUGet==null)? "<input type='submit' name='valider' value='Valider' >" :  "<input type='submit' name='modifier' value='Modifier' >" %> </td> 
                 </tr> 
                    
             </table> 
     </form> 

     <p>
            
     
     <br/>
     
     <br/>
            <%
            
            string chaine ="";
            if (Request.Form["valider"] != null)
            {
                string nom = Request.Form["nom"]; 
                string prenom = Request.Form["prenom"]; 
                string mail = Request.Form["mail"]; 
                string pic = Request.Form["pic"];
            
                reseau_fly.Utilisateur unUtilisateur = new  reseau_fly.Utilisateur (nom, prenom, mail, pic);
                // chaine = unProduit.afficher();
                
                uneBdd.insertUtilisateur(unUtilisateur); 
                chaine +=" <br/> <br/> Inscription réussie </br>"; 
            }
            
            
            //suppression d'un produit à partir de l'id fourni fourni dans l'URL avec action = s
            if (Request["action"] != null && Request["id_U"] != null) 
            {
                if (Request["action"] == "s") 
                {
                int id_U = int.Parse(Request["id_U"]);
                uneBdd.deleteUtilisateur(id_U);
                } 
                else if (Request["action"] == "e" && Request.Form["modifier"] != null) 
                {
                    int id_U = int.Parse(Request["id_U"]);
                    string nom = Request.Form["nom"]; 
                    string prenom = Request.Form["prenom"]; 
                    string mail = Request.Form["mail"]; 
                    string pic = Request.Form["pic"];
            
                    reseau_fly.Utilisateur unUtilisateur = new reseau_fly.Utilisateur (id_U, nom, prenom, mail, pic);
                    uneBdd.updateUtilisateur(unUtilisateur);
                }
            }
            
            
            %>
     </p>
        <div id="id1"   >           
            <%= chaine %>    
        </div>
        
        
        <div id="id2">
            <h2> Liste des utilisateurs </h2>
            <table border="1">
                <tr><td> id Utilisateur </td><td> Nom </td> <td> Prénom </td> <td> Mail </td><td> Pic </td> <td> Actions </td> </tr>
            
                <% 
                        string chaine1 = "";
                        
                        List<reseau_fly.Utilisateur> lesUtilisateurs = uneBdd.selectAllUtilisateurs();
                
                        foreach(reseau_fly.Utilisateur unUtilisateur in lesUtilisateurs) 
                        {
                            chaine1 += "<tr><td> " + unUtilisateur.Id_U
                                    + "</td> <td> " + unUtilisateur.Nom 
                                    + "</td> <td>" + unUtilisateur.Prenom 
                                    + "</td> <td>" + unUtilisateur.Mail 
                                    + "</td> <td>" + unUtilisateur.Pic 
                                    + "</td> "
                                    + "<td> <a href='Default.aspx?action=s&id_U="+unUtilisateur.Id_U+"'>Supprimer </a>" + " "
                                          +"<a href='Default.aspx?action=e&id_U="+unUtilisateur.Id_U+"'>Editer</a>"
                                    +"</td>"
                                    +"</tr>";
                        }
                %>   
                <%= chaine1 %>
            </table>
        </div>
</body>
</html>