DATABASE PIPE NAME

    sqllocaldb i mssqllocaldb
    Affiche les infos de sql express y compris le pipe name

USER
    //mf.flores@free.fr
    //Abcd1!

UPGRADE LOCALDB

    C:\>sqllocaldb stop MSSQLLocalDB
    LocalDB instance "MSSQLLocalDB" stopped.
 
    C:\>sqllocaldb delete MSSQLLocalDB
    LocalDB instance "MSSQLLocalDB" deleted.
 
    C:\>sqllocaldb create MSSQLLocalDB
    LocalDB instance "MSSQLLocalDB" created with version 13.0.1601.5.
 
    C:\>sqllocaldb start MSSQLLocalDB
    LocalDB instance "MSSQLLocalDB" started.

VALIDATION COTE SERVEUR

    ajouté à la fin du fichier de la vue .cshtml qui contient le formulaire
    @section scripts
    {
        @Scripts.Render("~/bundles/jqueryval")
    }

STYLE
    dossier content, fichier site.css à la fin du fichier, voir bootstrap overrides

POLICES 
    gratuites
        google.com/fonts

    payantes
        fonts.com
        fontsquirrel.com
        typekit.com
EXTENSIONS
    Productivity power tools 2017
    web essentials
    zencoding
    bootbox : messages d'alerte : sur bootboxjx.com, télécharger, copier le fichier bootbox.min.js dans le dossier scripts et l'inclure dans le projet
        dans app_start ajouter au bundle bootstrap
        copier un exemple sur le site bootbox selon le message : confirm, alert...

EXPRESSION TREES (ARBORESCENCE D'EXPRESSION)
voir GigFormViewModel.cs, méthode get de la propriété Action
cours Become a full-stack .NET developer advanced topics
Basic CRUD : Implementig the Update / using Expressions to replace magic strings
