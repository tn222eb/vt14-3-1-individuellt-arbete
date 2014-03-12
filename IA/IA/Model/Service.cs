using IA.Model.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace IA.Model
{
    public class Service
    {
        private ArticleDAL _articleDAL;

        private ArticleDAL ArticleDAL
        {
            // Ett articleDAL-objekt skapas först då det behövs för första gången
            get { return _articleDAL ?? (_articleDAL = new ArticleDAL()); }
        }

        /// Tar bort vald artikel ur databasen
        public void DeleteArticle(int articleID)
        {
            ArticleDAL.DeleteArticle(articleID);
        }

        // Hämtar alla artikel rubriker
        public IEnumerable<Article> GetArticleHeaders()
        {
            return ArticleDAL.GetArticleHeaders();
        }


        // Hämtar vald artikel
        public Article GetArticle(int articleID)
        {
            return ArticleDAL.GetArticleByID(articleID);
        }

        // Spara en artikel i databasen
        public void SaveArticle(Article article)
        {
            // Validering på affärslogiklagret
            ICollection<ValidationResult> validationResults;
            if (!article.Validate(out validationResults))
            {
                // kastas ett undantag med ett allmänt felmeddelande samt en referens till samlingen med resultat av valideringen
                var ex = new ValidationException("Objektet klarade inte valideringen.");
                ex.Data.Add("ValidationResults", validationResults);
                throw ex;
            }

            // Article-objektet sparas antingen genom att en ny artikel skapas eller genom att en befintlig artikel uppdateras
            if (article.ArticleID == 0) // Ny artikel om ArticleID är 0!
            {
                ArticleDAL.InsertArticle(article);
            }
            else
            {
                ArticleDAL.UpdateArticle(article);
            }
        }


    }
}