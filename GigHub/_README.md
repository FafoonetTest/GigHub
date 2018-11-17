Ligne de commande : 

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
