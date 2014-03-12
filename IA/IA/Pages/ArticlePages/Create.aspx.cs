using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IA.Model;

namespace IA.Pages.ArticlePages
{
    public partial class Create : System.Web.UI.Page
    {
        public void ArticleFormView_InsertItem(Article article)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Service service = new Service();
                    service.SaveArticle(article);
                    // Lägger till ett meddelande i extension-metoden
                    Page.SetTempData("Message", "Artikeln har lagts till.");
                    Response.RedirectToRoute("Default");
                    Context.ApplicationInstance.CompleteRequest();
                }
                catch (Exception)
                {
                    ModelState.AddModelError(String.Empty, "Fel inträffade då artikeln skulle läggas till.");
                }
            }
        }
    }
}