using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IA.Model;

namespace IA.Pages.ArticlePages
{
    public partial class Listing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Om det finns något meddelande i extension-metoden så hämtas det
            MessageLiteral.Text = Page.GetTempData("Message") as string;
            MessagePanel.Visible = !String.IsNullOrWhiteSpace(MessageLiteral.Text);
        }

        public IEnumerable<Article> ArticleListView_GetData()
        {
            try
            {
                Service service = new Service();
                return service.GetArticleHeaders();
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett fel inträffade då artikel rubrikerna skulle hämtas.");
                return null;
            }
        }

        protected void ImageCloseButton_Click(object sender, ImageClickEventArgs e)
        {

        }
    }
}