<!-- #Include virtual="include/header_test.aspx" -->

<%
    reseau_fly.Bdd uneBdd = new reseau_fly.Bdd();

    string image = "";

    string details = "";

    string details2 = "";

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
