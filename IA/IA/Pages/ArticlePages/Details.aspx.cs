using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IA.Model;
using System.Web.ModelBinding;
using System.Collections;

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

        // Hämtar artikel
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

        // Hämtar artikeltyp
        public IEnumerable<ArticleType> ArticleTypeListView_GetData([RouteData] int id)
        {
            try
            {
                return Service.GetArticleType(id);
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Fel inträffade då artikeltyp skulle hämtas.");
                return null;
            }
        }

        // Hämtar ut kategori till artikeln
        protected void ArticleTypeListView_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            var label = e.Item.FindControl("CategoryLabel") as Label;
            if (label != null)
            {
                // Typ omvandlar så att man kan använda nyckel
                var articleType = (ArticleType)e.Item.DataItem;

                // Hämtar sedan kategorierna och väljer ut den som har samma ID
                var category = Service.GetCategorys()
                    .Single(c => c.CategoryID == articleType.CategoryID);
                
                // Skriver ut kategorin
                label.Text = String.Format(label.Text, category.Category);
            }
        }
    }
}