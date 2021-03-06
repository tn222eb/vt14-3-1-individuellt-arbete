﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace IA.Model.DAL
{
    public class CategoryDAL : DALBase
    {
        /// Hämtar alla kategorier
        public IEnumerable<Categoryy> GetCategorys()
        {
            // Skapar ett anslutningsobjekt
            using (var conn = CreateConnection())
            {
                try
                {
                    // Skapar och initierar ett SqlCommand-objekt som används till att exekvera specifierad lagrad procedur
                    var cmd = new SqlCommand("appSchema.uspGetCategorys", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    List<Categoryy> categorys = new List<Categoryy>(10);

                    // Öppnar anslutningen till databasen
                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        var categoryIDIndex = reader.GetOrdinal("CategoryID");
                        var categoryIndex = reader.GetOrdinal("Category");

                        while (reader.Read())
                        {
                            // Hämtar ut data
                            categorys.Add(new Categoryy
                            {
                                CategoryID = reader.GetByte(categoryIDIndex),
                                Category = reader.GetString(categoryIndex),
                            });
                        }
                    }
                    // Sätter kapaciteten till antalet element i List-objektet
                    categorys.TrimExcess();

                    return categorys;
                }
                catch
                {
                    throw new ApplicationException("An error occured while getting categorys from the database.");
                }
            }
        }
    }
}