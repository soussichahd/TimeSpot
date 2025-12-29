# TimeSpotCe projet est une application web développée en ASP.NET Core (.NET).
Il s’agit d’un mini site e-commerce permettant la gestion des produits, du panier et des utilisateurs avec différents rôles.

Gestion du panier{
Le panier est géré à l’aide des cookies.
Chaque utilisateur possède un identifiant de panier.
Les produits ajoutés au panier sont associés à ce cookie.
}
Gestion du cache mémoire{
Le projet utilise IMemoryCache (cache mémoire local côté serveur) pour améliorer les performances :
Page Accueil:
Les résultats de recherche des produits sont stockés dans le cache
Cela permet de réduire les accès répétitifs à la base de données.
Page Détail Produit:
Les informations d’un produit sont mises en cache
Les requêtes vers la base de données sont évitées si les données sont déjà disponibles
}
