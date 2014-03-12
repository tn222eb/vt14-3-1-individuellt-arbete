using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace IA.Model.DAL
{
    public class ArticleDAL : DALBase
    {
        /// Hämtar alla artiklars rubrik
        public IEnumerable<Article> GetArticleHeaders()
        {
            // Skapar och initierar ett anslutningsobjekt
            using (var conn = CreateConnection())
            {
                try
                {
                    var articleheaders = new List<Article>(100);

                    // Skapar och initierar ett SqlCommand-objekt som används till att exekvera specifierad lagrad procedur
                    var cmd = new SqlCommand("appSchema.uspGetArticleHeaders", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Öppnar anslutningen till databasen
                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        var articleIDIndex = reader.GetOrdinal("ArticleID");
                        var headerIndex = reader.GetOrdinal("Header");

                        while (reader.Read())
                        {
                            // Hämtar ut data
                            articleheaders.Add(new Article
                            {
                                ArticleID = reader.GetInt32(articleIDIndex),
                                Header = reader.GetString(headerIndex),
                            });
                        }
                    }

                    // Sätter kapaciteten till antalet element i List-objektet
                    articleheaders.TrimExcess();

                    return articleheaders;
                }
                catch
                {
                    throw new ApplicationException("An error occured while getting articles from the database.");
                }
            }
        }

        // Hämtar en artikel
        public Article GetArticleByID(int articleID)
        {
            // Skapar och initierar ett anslutningsobjekt
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    // Skapar och initierar ett SqlCommand-objekt som används till att exekvera specifierad lagrad procedur
                    SqlCommand cmd = new SqlCommand("appSchema.uspGetArticle", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Lägger till den parameter den lagrade proceduren kräver
                    cmd.Parameters.AddWithValue("@ArticleID", articleID);

                    // Öppnar anslutningen till databasen.
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var articleIDIndex = reader.GetOrdinal("ArticleID");
                            var headerIndex = reader.GetOrdinal("Header");
                            var contentIndex = reader.GetOrdinal("Content");
                            var createdDateIndex = reader.GetOrdinal("CreatedDate");
                            var authorIDIndex = reader.GetOrdinal("AuthorID");

                            return new Article
                            {
                                ArticleID = reader.GetInt32(articleIDIndex),
                                Header = reader.GetString(headerIndex),
                                Content = reader.GetString(contentIndex),
                                CreatedDate = reader.GetDateTime(createdDateIndex),
                                AuthorID = reader.GetInt32(authorIDIndex)
                            };
                        }
                    }
                    return null;
                }
                catch
                {
                    throw new ApplicationException("An error occured in the data access layer.");
                }
            }
        }

        /// Skapar en ny artikel
        public void InsertArticle(Article article)
        {
            // Skapar och initierar ett anslutningsobjekt
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    // Skapar och initierar ett SqlCommand-objekt som används till att exekvera specifierad lagrad procedur
                    SqlCommand cmd = new SqlCommand("appSchema.uspInsertArticle", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Lägger till de parametrar den lagrade proceduren kräver
                    cmd.Parameters.Add("@Header", SqlDbType.VarChar, 255).Value = article.Header;
                    cmd.Parameters.Add("@Content", SqlDbType.VarChar, 8000).Value = article.Content;

                    // Hämtar det värde som databasen tilldelat ArticleID
                    cmd.Parameters.Add("@ArticleID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

                    // Öppnar anslutningen till databasen
                    conn.Open();

                    cmd.ExecuteNonQuery();

                    // Hämtar primärnyckelns värde för den nya posten och tilldelar Article-objektet värdet
                    article.ArticleID = (int)cmd.Parameters["@ArticleID"].Value;
                }
                catch
                {
                    throw new ApplicationException("An error occured in the data access layer.");
                }
            }
        }


        // Uppdaterar en artikel
        public void UpdateArticle(Article article)
        {
            // Skapar och initierar ett anslutningsobjekt
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    // Skapar och initierar ett SqlCommand-objekt som används till att exekvera specifierad lagrad procedur
                    SqlCommand cmd = new SqlCommand("appSchema.uspUpdateArticle", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Lägger till de parametrar den lagrade proceduren kräver
                    cmd.Parameters.Add("@ArticleID", SqlDbType.Int, 4).Value = article.ArticleID;
                    cmd.Parameters.Add("@Header", SqlDbType.VarChar, 255).Value = article.Header;
                    cmd.Parameters.Add("@Content", SqlDbType.VarChar, 8000).Value = article.Content;

                    // Öppnar anslutningen till databasen
                    conn.Open();

                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    throw new ApplicationException("An error occured in the data access layer.");
                }
            }
        }


        // Tar bort en artikel
        public void DeleteArticle(int articleID)
        {
            // Skapar och initierar ett anslutningsobjekt
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    // Skapar och initierar ett SqlCommand-objekt som används till att exekvera specifierad lagrad procedur
                    SqlCommand cmd = new SqlCommand("appSchema.uspDeleteArticle", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Lägger till den parameter den lagrade proceduren kräver
                    cmd.Parameters.Add("@ArticleID", SqlDbType.Int, 4).Value = articleID;

                    // Öppnar anslutningen till databasen
                    conn.Open();

                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    throw new ApplicationException("An error occured in the data access layer.");
                }
            }
        }



    }
}