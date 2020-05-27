<!-- #Include virtual="include/header_test.aspx" -->

<%
    reseau_fly.Bdd uneBdd = new reseau_fly.Bdd();

    string activite = "";

    string titre_users = "";

    string users = "";

    string verif_users = "";

    string action = "";

    string rejoindre = "";

    string display_none = "";

    string disabled = "";

    //insert into groupe ==> demande le NOM (nom différent) /=> récup. id_G avec le nom/ insert into adherer (choix du rôle) / insert into voyage (id_T)
    //groupe.aspx?action=new&id_T="+ unTrajet.Id_T +"

    //link
    //groupe.aspx?action=lier&id_G=" + unGroupe.Id_G + "&id_T="+ unTrajet.Id_T +"

    //insert into inviter
    //groupe.aspx?action=rejoindre&id_G=" + leGroupe.Id_G + "

    if (Request["id_G"] != null)
    {
        int id_G = int.Parse(Request["id_G"]);
        
        System.Diagnostics.Debug.WriteLine("groupe rechercher : " + id_G);

        if (Request["action"] == "rejoindre")
        {
            action +="style='border-radius:10px;width:100px;color:white;'";

            display_none += "style='display:none;'";

            rejoindre += "Rejoindre";
        }

        reseau_fly.Groupe unGroupe = uneBdd.detailGroupe(id_G);
        
        //liste les membres du groupe
        List<reseau_fly.Utilisateur> lesGroupeUsers = uneBdd.selectGroupeUsers(id_G);

        //details des voyages du groupe
        List<reseau_fly.Details_Voyage> lesDetails = uneBdd.selectDetailsVoyage(id_G);
        
        if(lesGroupeUsers.Count != 0)
        {

            titre_users += "Membres";        

            foreach(reseau_fly.Utilisateur unGroupeUser in lesGroupeUsers)
            {
                users += "<tr>" +
                            "<td>" +
                               "<div class='table-data__info'>" +
                                   "<h6>" + unGroupeUser.Nom + " " + unGroupeUser.Prenom + "</h6>" +
                                       "<span><a href='#'>" + unGroupeUser.Mail + "</a></span>" +
                               "</div>" +
                            "</td>" +
                            "<td>" +
                            "<div class='rs-select2--trans rs-select2--sm'>" +
                               "<select class='js-select2' name='role'>" +
                                    "<option selected value='" + uneBdd.selectRoleUser(unGroupeUser.Id_U) + "'>" + uneBdd.selectRoleUser(unGroupeUser.Id_U) + "</option>" +
                                    "<option value='super'>super</option>" +
                                    "<option value='tourisme'>tourisme</option>" +
                                    "<option value='location'>location</option>" +
                                    "<option value='transport'>transport</option>" +
                               "</select>" +
                                "<div class='dropDownSelect2'></div>" +
                            "</div>" +
                            "</td>" +
                            "<td style='padding-left: 5px;'>" +
                            "<span class='more'><i class='fas fa-check'></i></span>" +
                            "</td>" +
                            "<td style='padding-left: 5px;'>" +
                            "<span class='more'><i class='fas fa-times'></i></span>" +
                            "</td>" +
                            "</tr>";
             }
        }
        else
        {
            titre_users += "Inviter : ";
            
            verif_users += "style='display:none;'";
        }

        if(lesDetails.Count != 0)
        {
            foreach(reseau_fly.Details_Voyage unDetail in lesDetails)
            {
                activite += "<div class='au-task__item au-task__item--success'>" +
                                "<div class='au-task__item-inner'>" +
                                    "<h5 class='task'>" +
                                        "<a href=''>" + unDetail.Destination + " : " + unDetail.Titre + "</a>" +
                                    "</h5>" +
                                    "<span class='time'>" + unDetail.Date + "</span>" +
                                "</div>" +
                            "</div>";
            }
        }

    }
    else
    {
        activite += "<h1>Aucun groupe sélectionné !</h1>" +
                "<a href='home.aspx'><img src='images/gtfo.jpg'></img></a>";

        verif_users += "style='display:none;'";
    }
%>

<section style="padding-top: 40px; background-color: #ffffff;">
    <div class="section__content section__content--p30">
        <div class="container-fluid">
            <div class="row">
                <div class="col-xl-12">
                    <div class="row">
                        <div class="col-lg-7">
                        <!-- DEBUT ACTIVITE LOG  -->
                            <div class="au-card au-card--no-shadow au-card--no-pad au-card--border">
                                <div class="au-card-title" style="background-image: url('images/sky.jpg');">
                                    <div class="bg-overlay bg-overlay--blue"></div>
                                    <h3>
                                        <i class="fa fa-history"></i>Activité du groupe 
                                    </h3>
                                    <button class="au-btn-plus" <%=action %> >
                                        <%=rejoindre %><i class="zmdi zmdi-plus"<%=display_none %>></i>
                                    </button>
                                </div>
                                <div class="au-task js-list-load au-task--border">
                                    <div class="au-task-list js-scrollbar3">
                                        <!-- DEBUT FOREACH -->
                                        <%=activite %>
                                        <!-- FIN FOREACH -->
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-- FIN ACTIVITE LOG -->
                        <div class="col-lg-5">
                            <!-- TAB-USERS START-->
                            <div class="user-data m-b-40" style="position: fixed; width: 550px;">
                                <h3 class="title-3 m-b-30">
                                    <i class="zmdi zmdi-account-calendar"></i><%=titre_users %>
                                </h3>
                                <div class="table-responsive table-data" <%=verif_users %>>
                                    <table class="table">
                                        <thead>
                                            <tr>
                                                <td>utilisateur</td>
                                                <td>rôle</td>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <!-- COMMENCE LE FOREACH -->
                                            <%=users %>
                                            <!-- FIN DU FOREACH -->
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                            <!-- TAB-USERS END -->
                        </div>
    </div>
    </div>
            </div>
        </div>
</section>

<!-- #Include virtual="include/footer.aspx" -->
