﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace InviduelltArbete.Model.DAL
{
    public abstract class DALBase
    {
        private static string _connectionString;

        protected static SqlConnection CreateConnection()
        {
            // Returnerar referens till anslutnings-objekt
            return new SqlConnection(_connectionString);
        }

        static DALBase()
        {
            // Hämtar anslutningssträngen från web.config
            _connectionString = WebConfigurationManager.ConnectionStrings["UD13_tn222eb_ProjektConnectionString"].ConnectionString;
        }
    }
}