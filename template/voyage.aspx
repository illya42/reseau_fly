<!-- #Include virtual="include/header_test.aspx" -->
<%
    reseau_fly.Bdd uneBdd = new reseau_fly.Bdd();

    string image = "";

    string details = "";

    string details2 = "";

    if (Request["id_T"] != null)
    {
        int id_T = int.Parse(Request["id_T"]);

        int date_id_T = int.Parse(Request["id_T"]);

        System.Diagnostics.Debug.WriteLine("trajet rechercher : " + id_T);

        reseau_fly.Trajet unTrajet = uneBdd.detailTrajet(id_T);

        string destinationDate = unTrajet.Destination;

        List<reseau_fly.Trajet> desTrajets = uneBdd.selectDateDestination(destinationDate);

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


        image += "<img src='" + unTrajet.Image + "'></img>" +
                    "<h4 style='padding:10px 10px 10px; border-bottom:1px solid #000'>" +
                    "<a style='display:inline; padding:5px;' href='groupe.aspx?action=new&id_T="+ unTrajet.Id_T +"'>" +
                    "<button class='button-card' style='padding:5px 10px; float:left;'>Créer un groupe de voyage !</button>" + 
                    "</a>" +
                    "<a style='display:inline; padding:5px;' href='groupe.aspx?id_T="+ unTrajet.Id_T +"'>" +
                    "<button class='button-card' style='padding:5px 10px; float:none;'>Voir les groupes disponibles !</button>" + 
                    "</a>" +
                    "</h4>";
                    if(Session["Id_U"] != null)
                    {
                        List<reseau_fly.Groupe> desGroupes = uneBdd.selectUserGroupe(Convert.ToInt32(Session["Id_U"]));

                        image += "<h4 style='padding:10px 10px 10px;'>Lier à un groupe existant : " + 
                                    "<select style='display:inline; border:0px' name='liste_groupe' id='date_choisie'>" +
                                    "<option selected='true' disabled='disabled'> Vos groupes disponibles </option>";

                        foreach (reseau_fly.Groupe unGroupe in desGroupes)
                        {
                            image += "<option value=" + unGroupe.Nom + ">" + unGroupe.Nom + "</option>";
                        }

                        image += "</select>";

                        if(Request.Form["liste_groupe"] != null)
                        {
                            int liste_groupe_id_G = int.Parse(Request.Form["liste_groupe"]);

                            image += "<a style='display:inline; padding:10px;' href='voyage.aspx?action=create&id_G='" + liste_groupe_id_G + "'&id_T=" + date_id_T + "'><button class='button-card' style='float:none;padding:5px 10px'>Lier !</button></a>";
                        }

                        image += "</h4>";
                    }

        details2 += "<h3 style='padding:0px 10px 10px; border-bottom:1px solid #000'>" +
                    "<i class='fas fa-calendar-alt' style='margin-right: 20px;'></i>" + unTrajet.Date + "</h3>" +
                    "<h4 style='padding:10px 10px 10px;'>" +
                    "<select style='display:inline; border:0px' name='date' id='date_choisie'>" +
                    "<option selected='true' disabled='disabled'> Autres dates disponibles </option>";
        foreach (reseau_fly.Trajet dateTrajet in desTrajets)
        {
            details2 += "<option value=" + dateTrajet.Date + ">" + dateTrajet.Date + "</option>";
        }
        details2 += "</select>";

        if(Request.Form["date"] != null)
        {
            date_id_T = int.Parse(Request.Form["date"]);
        }

        details2 += "<a style='display:inline; padding:10px;' href='voyage.aspx?id_T="+ date_id_T +"'><button class='button-card' style='padding:5px 10px'>Choisir !</button></a></h4>";
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
<!-- #Include virtual="include/footer.aspx" -->
