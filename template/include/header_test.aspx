﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="header_test.aspx.cs" Inherits="reseau_fly.template.include.header_test" %>

<!DOCTYPE html>

<head runat="server">
    <!-- Required meta tags-->
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="au theme template">
    <meta name="author" content="Hau Nguyen">
    <meta name="keywords" content="au theme template">

    <!-- Title Page-->
    <title>Accueil</title>

    <!-- Fontfaces CSS-->
    <link href="css/font-face.css" rel="stylesheet" media="all">
    <link href="vendor/font-awesome-4.7/css/font-awesome.min.css" rel="stylesheet" media="all">
    <link href="vendor/font-awesome-5/css/fontawesome-all.min.css" rel="stylesheet" media="all">
    <link href="vendor/mdi-font/css/material-design-iconic-font.min.css" rel="stylesheet" media="all">

    <!-- Bootstrap CSS-->
    <link href="vendor/bootstrap-4.1/bootstrap.min.css" rel="stylesheet" media="all">

    <!-- Vendor CSS-->
    <link href="vendor/animsition/animsition.min.css" rel="stylesheet" media="all">
    <link href="vendor/bootstrap-progressbar/bootstrap-progressbar-3.3.4.min.css" rel="stylesheet" media="all">
    <link href="vendor/wow/animate.css" rel="stylesheet" media="all">
    <link href="vendor/css-hamburgers/hamburgers.min.css" rel="stylesheet" media="all">
    <link href="vendor/slick/slick.css" rel="stylesheet" media="all">
    <link href="vendor/select2/select2.min.css" rel="stylesheet" media="all">
    <link href="vendor/perfect-scrollbar/perfect-scrollbar.css" rel="stylesheet" media="all">
    <link href="vendor/vector-map/jqvmap.min.css" rel="stylesheet" media="all">

    <!-- Main CSS-->
    <link href="css/theme.css" rel="stylesheet" media="all">
</head>

<body class="animsition">
    <div class="page-wrapper">
        <!-- MENU SIDEBAR-->
        <aside class="menu-sidebar2">
            <!-- Logo -->
            <div class="logo">
                <a href="home.aspx">
                    <img src="images/logo_app.png" alt="Fly Together" />
                </a>
            </div>
            <div class="menu-sidebar2__content js-scrollbar1">

                <!-- Mini-profil -->
                <div id="login_div" class="account2" style="display: none;" runat="server">
                    <form runat="server">
                        <div class="image img-cir img-120">
                            <img src="images/logo_user.png" alt="" />
                        </div>
                        <asp:TextBox ReadOnly="true" ID="utilisateur_details" class="name" runat="server"></asp:TextBox>
                    </form>
                </div>

                <nav class="navbar-sidebar2">
                    <ul id="connection_unreq" class="list-unstyled navbar__list" style="display: none;" runat="server">
                        <li class="has-sub">
                            <a class="js-arrow" href="#">
                                <i class="fas fa-bars"></i>Menu
                                <span class="arrow"></span>
                            </a>
                            <ul class="list-unstyled navbar__sub-list js-sub-list">
                                <li>
                                    <a href="menu_admin.html">
                                        <i class="fas fa-tachometer-alt"></i>Administration
                                    </a>
                                </li>
                                <li>
                                    <a href="index4.html">
                                        <i class="fas fa-plane"></i>Voyage
                                    </a>
                                </li>
                            </ul>
                        </li>
                        <li>
                            <a href="inbox.html">
                                <i class="fas fa-envelope"></i>Messagerie
                            </a>
                        </li>
                        <li class="has-sub">
                            <a class="js-arrow" href="#">
                                <i class="fas fa-cog"></i>Outils
                                <span class="arrow"></span>
                            </a>
                            <ul class="list-unstyled navbar__sub-list js-sub-list">
                                <li>
                                    <a href="form.html">
                                        <i class="far fa-check-square"></i>Créer une étape
                                    </a>
                                </li>
                                <li>
                                    <a href="calendar.html">
                                        <i class="fas fa-calendar-alt"></i>Calendrier
                                    </a>
                                </li>
                                <li>
                                    <a href="table.html">
                                        <i class="fas fa-thumb-tack"></i>Liste des étapes
                                    </a>
                                </li>
                                <li>
                                    <a href="calendar.html">
                                        <i class="fas fa-table"></i>Liste des groupes
                                    </a>
                                </li>
                            </ul>
                        </li>
                        <li class="has-sub">
                            <a class="js-arrow" href="#">
                                <i class="fas fa-user"></i>Compte
                                <span class="arrow"></span>
                            </a>
                            <ul class="list-unstyled navbar__sub-list js-sub-list">
                                <li>
                                    <a href="login.html">
                                        <i class="fas fa-file"></i>Profil
                                    </a>
                                </li>
                                <li>
                                    <a href="register.html">
                                        <i class="fas fa-users"></i>Groupes
                                    </a>
                                </li>
                                <li>
                                    <!-- DISCONNECT -->
                                    <a href="">
                                        <i class="fas fa-power-off"></i>Déconnexion
                                    </a>
                                </li>
                            </ul>
                        </li>

                    </ul>
                    <ul id="connection_req" class="list-unstyled navbar__list" style="display: none;" runat="server">
                        <li>
                            <br />
                            <a href="login.aspx">
                                <i class="fas fa-plug"></i>Connection
                            </a>
                        </li>
                    </ul>
                </nav>
            </div>
        </aside>
    </div>
    <!-- END MENU SIDEBAR-->
    <!-- PAGE CONTAINER-->
    <div class="page-container2">
        <!-- HEADER DESKTOP-->
        <header class="header-desktop2">
            <div class="section__content section__content--p30">
                <div class="container-fluid">
                    <div class="header-wrap2">
                        <div class="logo d-block d-lg-none">
                            <a href="#">
                                <img src="images/icon/logo-white.png" alt="CoolAdmin" />
                            </a>
                        </div>
                        <!-- Barre de recherche -->
                        <div class="header-button2" id="connection_unreq2" runat="server">
                            <div class="header-button-item js-item-menu">
                                <i class="zmdi zmdi-search"></i>
                                <div class="search-dropdown js-dropdown">
                                    <!-- SEARCH -->
                                    <form action="">
                                        <input class="au-input au-input--full au-input--h65" type="text" placeholder="Chercher un utilisateur ..." />
                                    </form>
                                </div>
                            </div>
                            <!-- Notifications -->
                            <div class="header-button-item mr-0 js-sidebar-btn">
                                <i class="zmdi zmdi-menu"></i>
                            </div>
                            <!-- Menu -->
                            <div class="setting-menu js-right-sidebar d-none d-lg-block">
                                <div class="account-dropdown__body">
                                    <div class="account-dropdown__item">
                                        <a href="#">
                                            <i class="zmdi zmdi-account"></i>Compte
                                        </a>
                                    </div>
                                    <div class="account-dropdown__item">
                                        <a href="#">
                                            <i class="zmdi zmdi-settings"></i>Paramètres
                                        </a>
                                    </div>
                                </div>
                                <div class="account-dropdown__body">
                                    <div class="account-dropdown__item">
                                        <a href="#">
                                            <i class="zmdi zmdi-email"></i>Nous contacter
                                        </a>
                                    </div>
                                    <div class="account-dropdown__item">
                                        <a href="#">
                                            <i class="zmdi zmdi-notifications"></i>Notifications
                                        </a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </header>

        <!-- END HEADER DESKTOP-->
