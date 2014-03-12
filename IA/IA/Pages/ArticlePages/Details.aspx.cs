using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IA.Model;
using System.Web.ModelBinding;

namespace IA.Pages.ArticlePages
{
    public partial class Details : System.Web.UI.Page
    {

        private Service _service;

        private Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // Om det finns något meddelande i extension-metoden så hämtas det
            MessageLiteral.Text = Page.GetTempData("Message") as string;
            MessagePanel.Visible = !String.IsNullOrWhiteSpace(MessageLiteral.Text);
        }

        public Article ArticleListView_GetData([RouteData] int id)
        {
            try
            {
                return Service.GetArticle(id);
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Fel inträffade då artikeln skulle hämtas.");
                return null;
            }
        }

        // Tar bort artikeln
        public void ArticleListView_DeleteItem([RouteData] int id)
        {
            try
            {
                Service.DeleteArticle(id);
                // Lägger till ett meddelande i extension-metoden
                Page.SetTempData("Message", "Artikeln har tagits bort.");
                Response.RedirectToRoute("Default");
                Context.ApplicationInstance.CompleteRequest();
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då artikeln skulle tas bort.");
            }
        }

        // Uppdaterar artikeln
        public void ArticleListView_UpdateItem([RouteData] int id)
        {
            try
            {
                var article = Service.GetArticle(id);
                if (article == null)
                {
                    ModelState.AddModelError(String.Empty,
                    String.Format("Artikeln hittades inte."));
                    return;
                }

                if (TryUpdateModel(article))
                {
                    Service.SaveArticle(article);
                    // Lägger till ett meddelande i extension-metoden
                    Page.SetTempData("Message", "Artikeln har uppdaterats.");
                    Response.RedirectToRoute("ArticleDetails", new { id = article.ArticleID });
                    Context.ApplicationInstance.CompleteRequest();
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då artikeln skulle uppdateras.");
            }
        }
    }
}