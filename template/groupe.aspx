<!-- #Include virtual="include/header_test.aspx" -->

<%
    reseau_fly.Bdd uneBdd = new reseau_fly.Bdd();

    string activite = "";

    string users = "";
%>

<section style="padding-top: 40px; background-color: #ffffff;">
    <div class="section__content section__content--p30">
        <div class="container-fluid">
            <div class="row">
                <div class="col-xl-12">
                    <div class="row">
                        <div class="col-lg-7">
                            <%=activite %>
                        </div>
                        <div class="col-lg-5">
                            <!-- TAB-USERS START-->
                            <div class="user-data m-b-40" style="position: fixed;">
                                <h3 class="title-3 m-b-30">
                                    <i class="zmdi zmdi-account-calendar"></i>Membres
                                </h3>
                                <div class="table-responsive table-data">
                                    <table class="table">
                                        <thead>
                                            <tr>
                                                <td>name</td>
                                                <td>role</td>
                                                <td>type</td>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <!-- COMMENCE LE FOREACH -->
                                            <tr>
                                                <td>
                                                    <div class="table-data__info">
                                                        <%=users %>
                                                        <h6>lori lynch</h6>
                                                        <span>
                                                            <a href="#">johndoe@gmail.com</a>
                                                        </span>
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="rs-select2--trans rs-select2--sm">
                                                        <select class="js-select2" name="role">
                                                            <option value="">Super</option>
                                                            <option value="">Tourisme</option>
                                                            <option value="">Locations</option>
                                                            <option value="">Transports</option>
                                                        </select>
                                                        <div class="dropDownSelect2"></div>
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="rs-select2--trans rs-select2--sm">
                                                        <select class="js-select2" name="type">
                                                            <option value="">Admin</option>
                                                            <option value="">Membre</option>
                                                        </select>
                                                        <div class="dropDownSelect2"></div>
                                                    </div>
                                                </td>
                                                <td style="padding-left: 5px;">
                                                    <span class="more">
                                                        <i class="zmdi zmdi-more"></i>
                                                    </span>
                                                </td>
                                            </tr>
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
