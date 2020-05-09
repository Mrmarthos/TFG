using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using System.Configuration;

namespace ERP_SERVER.BBDD
{
    public class Conexion
    {

        public SqlConnection Establececonexion()
        {

            try
            {
                SqlConnection conn;
                conn = new SqlConnection();

              
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["AzureDB"].ConnectionString;
                conn.Open();
                return conn;

            }
            catch (SqlException ex)

            {
                return null;
            }

           
        }
    }
}