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
            routes.MapPageRoute("CreateArticle", "nyartikel", "~/Pages/ArticlePages/Create.aspx");
            routes.MapPageRoute("Default", "", "~/Pages/ArticlePages/Listing.aspx");
            routes.MapPageRoute("DeleteArticle", "artikel/{id}/radera", "~/Pages/ArticlePages/Delete.aspx");
            routes.MapPageRoute("EditArticle", "artikel/{id}/redigera", "~/Pages/ArticlePages/Delete.aspx");
            routes.MapPageRoute("ArticleDetails", "artikel/{id}", "~/Pages/ArticlePages/Details.aspx");
        }
    }
}