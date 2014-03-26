using IA.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IA.Pages.ArticlePages
{
    public partial class Edit : System.Web.UI.Page
    {
        private Service _service;

        private Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public Article ArticleFormView_GetItem([RouteData] int id)
        {
            try
            {
                return Service.GetArticle(id);
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Fel inträffade då artikel innehållet skulle hämtas.");
                return null;
            }
        }

        public void ArticleFormView_UpdateItem([RouteData] int id)
        {
            try
            {
                var article = Service.GetArticle(id);
                if (article == null)
                {
                    ModelState.AddModelError(String.Empty, "Artikeln hittades inte.");
                    return;
                }

                // Skapar en array-lista som jag kommer stoppa in valen från checkbox
                ArrayList categoryId = new ArrayList();
                CheckBoxList cbl = (CheckBoxList)ArticleFormView.FindControl("CategoryCheckBoxList");
                foreach (ListItem liRole in cbl.Items)
                {
                    if (liRole.Selected)
                    {
                        // Gör till int och lägger i listan
                        categoryId.Add(int.Parse(liRole.Value));
                    }
                }

                // Kollar om ifall användaren valt något från checkbox
                if (categoryId.Count == 0)
                {
                    ModelState.AddModelError(String.Empty, "Artikeln måste minst ha en kategori.");
                }

                if (TryUpdateModel(article))
                {
                    Service.SaveArticle(article);

                    // Rensar alla artikeltyp för artikel
                    Service.DeleteArticleTypes(article.ArticleID);

                    // Skickar in både articleID och categoryID för skapa relationsobjektet tills det inte finns 
                    // några fler valda från checkboxen
                    for (int i = 0; i < categoryId.Count; i++)
                    {
                        Service.InsertArticleType(article.ArticleID, (int)categoryId[i]);
                    }

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

        // Hämtar alla kategorier till checkbox
        public IEnumerable<Categoryy> CategoryCheckBoxList_GetCategorys()
        {
            Service service = new Service();
            return service.GetCategorys();
        }

        protected void CategoryCheckBoxList_DataBound(object sender, EventArgs e)
        {
            var checkBoxList = (CheckBoxList)ArticleFormView.FindControl("CategoryCheckBoxList");
            var articleID = int.Parse(RouteData.Values["id"].ToString());
            var articleTypes = Service.GetArticleType(articleID);

            foreach (var checkBox in checkBoxList.Items.Cast<ListItem>())
            {
                for (int i = 0; i < articleTypes.Count; i++)
                {
                    if (articleTypes[i].CategoryID.ToString() == checkBox.Value)
                    {
                        checkBox.Selected = true;
                    }
                }
            }
        }
    }
}