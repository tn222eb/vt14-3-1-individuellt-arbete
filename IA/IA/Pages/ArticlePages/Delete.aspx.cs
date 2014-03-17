using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IA.Model;

namespace IA.Pages.ArticlePages
{
    public partial class Delete : System.Web.UI.Page
    {
        // Hämtar den andra RouteValue id och lägger i den i egenskapen så jag kan använda från flera ställen
        protected int Id
        {
            get { return int.Parse(RouteData.Values["id"].ToString()); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // Ta bort artikeltyp
        protected void DeleteLinkButton_Command(object sender, CommandEventArgs e)
        {
            try
            {
                // Hämtar artikelns artikeltyp
                Service service = new Service();
                var articleTypes = service.GetArticleType(Id);

                // Om de finns fler än 1 artikeltyp så ska de gå o ta bort men om de bara finns 1 så kommer det inte kunna gå
                if (articleTypes.Count > 1)
                {
                    // Hämtar RouteValue id och gör om den till en int sen skickar med den för sedan ta bort artikeltyp
                    var id2 = int.Parse(e.CommandArgument.ToString());
                    service.DeleteArticleType(id2);
                    // Lägger till ett meddelande i extension-metoden
                    Page.SetTempData("Message", "Kategorin har tagits bort från artikeln.");
                    Response.RedirectToRoute("Default");
                    Context.ApplicationInstance.CompleteRequest();
                }
                else
                {
                    ModelState.AddModelError(String.Empty, "Går ej ta bort, artikeln måste minst ha en kategori.");
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Fel inträffade då kategorin skulle tas bort från artikeln.");
            }
        }

        protected void LinkButton1_Command(object sender, CommandEventArgs e)
        {
            // Hämtar id från egenskap för gå tillbaka till artikeln man var på
            var id = Id;
            Response.RedirectToRoute("ArticleDetails", id);
            Context.ApplicationInstance.CompleteRequest();
        }
    }
}