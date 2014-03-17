using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace IA
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute("CreateArticle", "skapa/artikel", "~/Pages/ArticlePages/Create.aspx");
            routes.MapPageRoute("Default", "", "~/Pages/ArticlePages/Listing.aspx");
            routes.MapPageRoute("ArticleDetails", "artikel/{id}", "~/Pages/ArticlePages/Details.aspx");
            routes.MapPageRoute("DeleteArticleType", "artikel/{id}/tabort/artikeltyp/{id2}", "~/Pages/ArticlePages/Delete.aspx");
            routes.MapPageRoute("Error", "serverfel", "~/Pages/Shared/Error.aspx");
        }
    }
}