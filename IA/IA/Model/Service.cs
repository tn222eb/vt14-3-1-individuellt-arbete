using IA.Model.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Collections;

namespace IA.Model
{
    public class Service
    {
        private ArticleDAL _articleDAL;
        private ArticleTypeDAL _articleTypeDAL;
        private CategoryDAL _categoryDAL;

        private ArticleDAL ArticleDAL
        {
            get { return _articleDAL ?? (_articleDAL = new ArticleDAL()); }
        }

        private ArticleTypeDAL ArticleTypeDAL
        {
            get { return _articleTypeDAL ?? (_articleTypeDAL = new ArticleTypeDAL()); }
        }

        private CategoryDAL CategoryDAL
        {
            get { return _categoryDAL ?? (_categoryDAL = new CategoryDAL()); }
        }


        // Tar bort vald artikel
        public void DeleteArticle(int articleID)
        {
            ArticleDAL.DeleteArticle(articleID);
        }

        // Hämtar alla kategori
        public IEnumerable<Categoryy> GetCategorys(bool refresh = false)
        {
            // Hämtar kategorier från cache
            var categorys = HttpContext.Current.Cache["Category"] as IEnumerable<Categoryy>;

            // Om det inte finns det en lista med kategorier i cache
            if (categorys == null || refresh)
            {
                
                // Hämta och sedan cacha i 10 minuter
                categorys = CategoryDAL.GetCategorys();
                HttpContext.Current.Cache.Insert("Category", categorys, null, DateTime.Now.AddMinutes(10), TimeSpan.Zero);
            }
            return categorys;
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
                var ex = new ValidationException("Objektet klarade inte valideringen.");
                ex.Data.Add("ValidationResults", validationResults);
                throw ex;
            }

            // Article-objektet sparas antingen genom att en ny artikel skapas eller genom att en befintlig artikel uppdateras
            if (article.ArticleID == 0)
            {
                ArticleDAL.InsertArticle(article);
            }
            else
            {
                ArticleDAL.UpdateArticle(article);
            }
        }

        // Lägger artikeltyp
        public void InsertArticleType(int articleID, int categoryID)
        {
            ArticleTypeDAL.InsertArticleType(articleID, categoryID);
        }

        // Hämtar artikeltyp
        public List<ArticleType> GetArticleType(int articleID)
        {
            return ArticleTypeDAL.GetArticleTypeByID(articleID);
        }

        // Tar bort artikeltyp
        public void DeleteArticleType(int articleTypeID)
        {
            ArticleTypeDAL.DeleteArticleType(articleTypeID);
        }

    }
}