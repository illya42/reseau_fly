<!-- #Include virtual="include/header_test.aspx" -->

<section style="padding-top: 40px; background-color: #ffffff;">
    <div class="section__content section__content--p30">
        <div class="container-fluid">
            <div class="row">
                <div class="col-xl-12">
                    <div class="row">
                        <div class="col-lg-12">
                            <form method="post">
                                <h4>Chercher un voyage :
                                    <input name="recherche_aeroport" type="text" style="background-color: #ddd; border-radius: .5rem; padding: 0 .5rem;" placeholder="votre départ"/>
                                    <input name="recherche_destination" type="text" style="background-color: #ddd; border-radius: .5rem; padding: 0 .5rem;" placeholder="votre destination" />
                                    <button type="submit" name="chercher" class="button-chercher">chercher</button></h4>
                            </form>
                            <br />
                            <div class="wrapper-card">
                                <%
                                    reseau_fly.Bdd uneBdd = new reseau_fly.Bdd();

                                    string cases = "";
                                    
                                    if(Request.Form["chercher"] != null)
                                    {
                                        string recherche_destination = Request.Form["recherche_destination"];
                                        string recherche_aeroport = Request.Form["recherche_aeroport"];
                                        
                                        System.Diagnostics.Debug.WriteLine("rech. depart : " + recherche_aeroport + " rech. destination : " + recherche_destination);

                                        List<reseau_fly.Trajet> desTrajets = uneBdd.selectWhereDestination(recherche_aeroport, recherche_destination);

                                        foreach(reseau_fly.Trajet unTrajet in desTrajets) 
                                        {
                                            cases += "<div class='card'>"  
                                                    + "<img class='image-card' src='" + unTrajet.Image + "'>"
                                                    + "<div class='content-card'>"
                                                    + "<h4>" + unTrajet.Destination + "</h4>"
                                                    + "<p>" + unTrajet.Date + "<a style='display:inline; float:right;' href='voyage.aspx?id_T="+unTrajet.Id_T+"'><button class='button-card'>Voyager !</button></a></p>"
                                                    + "</div></div>";
                                        }
                                    }
                                    else
                                    {
                                        List<reseau_fly.Trajet> lesTrajets = uneBdd.selectAllTrajets();
                
                                        foreach(reseau_fly.Trajet unTrajet in lesTrajets) 
                                        {
                                            cases += "<div class='card'>"  
                                                    + "<img class='image-card' src='" + unTrajet.Image + "'>"
                                                    + "<div class='content-card'>"
                                                    + "<h4>" + unTrajet.Destination + "</h4>"
                                                    + "<p>" + unTrajet.Date + "<a style='display:inline; float:right;' href='voyage.aspx?id_T="+unTrajet.Id_T+"'><button class='button-card'>Voyager !</button></a></p>"
                                                    + "</div></div>";
                                        }
                                    }
                                %>
                                <%=cases %>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
</section>

<!-- #Include virtual="include/footer.aspx" -->

