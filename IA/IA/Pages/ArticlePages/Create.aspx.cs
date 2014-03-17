using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IA.Model;
using System.Collections;

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
                        ModelState.AddModelError(String.Empty, "En kategori måste väljas.");
                    }

                    else
                    {
                        Service service = new Service();
                        service.SaveArticle(article);

                        // Skickar in både articleID och categoryID för skapa relationsobjektet tills det inte finns 
                        // några fler valda från checkboxen
                        for (int i = 0; i < categoryId.Count; i++)
                        {
                            service.InsertArticleType(article.ArticleID, (int)categoryId[i]);
                        }

                        // Lägger till ett meddelande i extension-metoden
                        Page.SetTempData("Message", "Artikeln har lagts till.");
                        Response.RedirectToRoute("Default");
                        Context.ApplicationInstance.CompleteRequest();
                    }
                }
                catch (Exception)
                {
                    ModelState.AddModelError(String.Empty, "Fel inträffade då artikeln skulle läggas till.");
                }
            }
        }

        // Hämtar alla kategorier till checkbox
        public IEnumerable<Categoryy> CategoryCheckBoxList_GetCategorys()
        {
            Service service = new Service();
            return service.GetCategorys();
        }



    }
}