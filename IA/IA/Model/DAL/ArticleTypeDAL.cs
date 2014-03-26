using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace IA.Model.DAL
{
    public class ArticleTypeDAL : DALBase
    {
        public void InsertArticleType(int articleID, int categoryID)
        {
            // Skapar och initierar ett anslutningsobjekt
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    // Skapar och initierar ett SqlCommand-objekt som används till att exekvera specifierad lagrad procedur
                    SqlCommand cmd = new SqlCommand("appSchema.uspNewArticleType", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Lägger till de parametrar den lagrade proceduren kräver
                    cmd.Parameters.Add("@ArticleID", SqlDbType.Int, 4).Value = articleID;
                    cmd.Parameters.Add("@CategoryID", SqlDbType.Int, 4).Value = categoryID;

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

        public List<ArticleType> GetArticleTypeByID(int articleID)
        {
            // Skapar och initierar ett anslutningsobjekt
            using (var conn = CreateConnection())
            {
                try
                {
                    var articleTypes = new List<ArticleType>(10);

                    // Skapar och initierar ett SqlCommand-objekt som används till att exekvera specifierad lagrad procedur
                    var cmd = new SqlCommand("appSchema.uspGetArticleType", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Lägger till den parameter den lagrade proceduren kräver
                    cmd.Parameters.AddWithValue("@ArticleID", articleID);

                    // Öppnar anslutningen till databasen
                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        var articleTypeIDIndex = reader.GetOrdinal("ArticleTypeID");
                        var articleIDIndex = reader.GetOrdinal("ArticleID");
                        var categoryIDIndex = reader.GetOrdinal("CategoryID");

                        while (reader.Read())
                        {
                            // Hämtar ut data
                            articleTypes.Add(new ArticleType
                            {
                                ArticleTypeID = reader.GetInt32(articleTypeIDIndex),
                                ArticleID = reader.GetInt32(articleIDIndex),
                                CategoryID = reader.GetByte(categoryIDIndex),
                            });
                        }
                    }

                    // Sätter kapaciteten till antalet element i List-objektet
                    articleTypes.TrimExcess();

                    return articleTypes;
                }
                catch
                {
                    throw new ApplicationException("An error occured while getting articletypes from the database.");
                }
            }
        }

        public void DeleteArticleTypes(int articleID)
        {
            // Skapar och initierar ett anslutningsobjekt
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    // Skapar och initierar ett SqlCommand-objekt som används till att exekvera specifierad lagrad procedur
                    SqlCommand cmd = new SqlCommand("appSchema.uspDeleteArticleTypes", conn);
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