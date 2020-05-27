<!-- #Include virtual="include/header_test.aspx" -->
<%
    reseau_fly.Bdd uneBdd = new reseau_fly.Bdd();

    string image = "";

    string details = "";

    string details2 = "";
    
    string titre_groupes_dispo ="";

    string titre_lier_groupes = "";

    string groupes_dispo = "";

    string groupes_lier_dispo = "";

    if (Request["id_T"] != null)
    {
        int id_T = int.Parse(Request["id_T"]);

        int date_id_T = int.Parse(Request["id_T"]);
        
        //debug outprint du trajet sélectionné
        System.Diagnostics.Debug.WriteLine("trajet rechercher : " + id_T);
        
        //infos sur le trajet sélectionné
        reseau_fly.Trajet unTrajet = uneBdd.detailTrajet(id_T);
        
        //récupere la destination pour les trajets avec des dates diff.
        string destinationDate = unTrajet.Destination;
        
        //voir ligne juste en haut
        List<reseau_fly.Trajet> desTrajets = uneBdd.selectDateDestination(destinationDate, id_T);

        //fonctions pour voir les autres groupes dispo
        List<reseau_fly.Groupe> lesGroupes = uneBdd.selectTrajetGroupe(id_T);

        details += "<ul style='list-style: none;'>" +
                    "<li>" +
                    "<h3 style='padding:0px 0px 10px; border-bottom:1.5px solid #3B9E00'>" +
                    "<i class='fas fa-map-marker-alt fa-sm' style='margin-right: 20px;color:green;'></i>" + unTrajet.Destination + "</h3>" +
                    "</li>" +
                    "<li>" +
                    "<h3 style='padding:10px 0px 10px; border-bottom:1.5px solid #3B9E00'>" +
                    "<i class='fas fa-plane fa-sm' style='margin-right: 20px; width:16px;color:green;'></i>" + unTrajet.Aeroport + "</h3>" +
                    "</li>" +
                    "<li>" +
                    "<h3 style='padding:10px 0px 10px;'>" +
                    "<i class='fas fa-euro-sign fa-sm' style='margin-right: 20px; width:16px;color:green;'></i>" + unTrajet.Prix + " par prs.</h3>" +
                    "</li>" +
                    "<li>" +
                    "<h3 style='padding:10px 0px 10px;'>" +
                    "<i class='fas fa-clock fa-sm' style='margin-right: 20px; width:16px;color:green;'></i>" + unTrajet.Heure_dep + "</h3>" +
                    "</li>" +
                    "<li>" +
                    "<h3 style='padding:10px 0px 10px;'>" +
                    "<i style='margin-right: 36px;'></i>" + unTrajet.Heure_arr + "</h3>" +
                    "</li>" +
                    "</ul>";

        details += "<h4 style='padding:10px 0px 10px;'><a style='display:inline; padding:5px;' href='groupe.aspx?action=new&id_T="+ unTrajet.Id_T +"'>" +
                    "<button class='button-card' style='padding:5px 10px; float:left;'>Créer un groupe !</button>" + 
                    "</a></h4>";

                    image += "<img class='picture' src='" + unTrajet.Image + "'></img>" +
                            "<h4 style='padding:10px 10px 10px;'><div style='display:inline; padding:5px 10px;'>";

                    if(lesGroupes.Count != 0)
                    {
                        image += "<button id='myBtn' class='button-card' style='padding:5px 10px; float:none;'>Voir les groupes disponibles !</button>" + 
                        "</div>";
                    }

                    if(Session["Id_U"] != null)
                    {
                        List<reseau_fly.Groupe> desGroupes = uneBdd.selectUserGroupe(Convert.ToInt32(Session["Id_U"]));

                        if(desGroupes.Count != 0 )
                        {
                            image += "<button id='myBtn_2' class='button-card' style='padding:5px 10px; float:none;'>Lier à un groupe !</button>";
                        }

                        if(desGroupes.Count == 0)
                        {
                            titre_lier_groupes += "Vous n'avez pas de groupes";
                        }
                        else
                        {
                            titre_lier_groupes += "Lier à un de vos groupes :";
            
                            foreach(reseau_fly.Groupe unGroupe in desGroupes)
                            {
                                    groupes_lier_dispo += "<h4 style='padding-bottom:5px;'>Nom du groupe : <a href='groupe.aspx?action=lier&id_G=" + unGroupe.Id_G + "&id_T="+ unTrajet.Id_T +"'>" + unGroupe.Nom + " n°" + unGroupe.Id_G + "</a></h4>";
                            }
                        }
                        image += "</h4>";
                    }

        details2 += "<h3 style='padding:0px 10px 10px; border-bottom:1px solid #000'>" +
                    "<i class='fas fa-calendar-alt' style='margin-right: 20px;'></i>" + unTrajet.Date + "</h3>";


        if(desTrajets.Count == 0)
        {
            details2 += "<h4 style='padding:10px 10px 10px;'>Aucune autres dates disponibles</h4>";
        }
        else
        {
            details2 += "<h4 style='padding:10px 10px 10px;'>Autres dates disponibles :</h4>";

            foreach (reseau_fly.Trajet dateTrajet in desTrajets)
            {
                details2 += "<h4><a style='display:inline; padding:10px;' href='voyage.aspx?id_T="+ dateTrajet.Id_T +"'>" + dateTrajet.Date + "</a></h4>";
            }
        }
        
        if(lesGroupes.Count == 0)
        {
            titre_groupes_dispo += "Aucun groupes disponibles";
        }
        else
        {
            titre_groupes_dispo += "Liste des groupes disponibles :";
            
            foreach( reseau_fly.Groupe leGroupe in lesGroupes )
            {
                groupes_dispo += "<h4 style='padding-bottom:5px;'>Nom du groupe : <a href='groupe.aspx?action=rejoindre&id_G=" + leGroupe.Id_G + "'>" + leGroupe.Nom + " n°" + leGroupe.Id_G + "</a></h4>";
            }
        }


    }
    else
    {
        image+= "<h1>Aucun trajet sélectionné !</h1>" +
                "<a href='home.aspx'><img src='images/gtfo.jpg'></img></a>";
    }
%>

<section style="padding-top: 40px; background-color: #ffffff;">
    <div class="section__content section__content--p30">
        <div class="container-fluid">
            <div class="row">
                <div class="col-xl-12">
                    <div class="row">
                        <div class="col-lg-2">
                            <%=details %>
                        </div>
                        <div class="col-lg-6">
                            <%=image %>
                        </div>
                        <div class="col-lg-4">
                            <%=details2 %>
                        </div>
                    </div>
                </div>
            </div>
        </div>
</section>

<!-- The Modal -->
<div id="myModal" class="modal">

    <!-- Modal content -->
    <div class="modal-content">
        <div class="modal-header">
            <h2 style="text-align:left;"><%= titre_groupes_dispo %></h2>
        </div>
        <div class="modal-body" style="padding-top:20px;padding-bottom:10px;">
            <%= groupes_dispo %>
        </div>
    </div>

</div>

<!-- The Modal -->
<div id="myModal_2" class="modal">

    <!-- Modal content -->
    <div class="modal-content">
        <div class="modal-header">
            <h2 style="text-align:left;"><%= titre_lier_groupes %></h2>
        </div>
        <div class="modal-body" style="padding-top:20px;padding-bottom:10px;">
            <%= groupes_lier_dispo %>
        </div>
    </div>

</div>

<!-- #Include virtual="include/footer.aspx" -->
