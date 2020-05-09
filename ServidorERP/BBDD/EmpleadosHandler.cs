using ERP_SERVER.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ERP_SERVER.BBDD
{
    public class EmpleadosHandler
    {
        public static List<Data> GetEmployes()
        {

            Conexion conexion = new Conexion();

            SqlConnection conn = conexion.Establececonexion();

            List<Data> Empleadoslist = new List<Data>();

            
            String sqlquery = " " +
                "" +
                " select * from Empleados";
            try
            {
                SqlCommand cmd = new SqlCommand(sqlquery, conn);
     
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Empleados empleado = new Empleados();


                    empleado.Correo = reader.GetValue(reader.GetOrdinal("Correo")).ToString();
                    empleado.Movil = reader.GetValue(reader.GetOrdinal("Movil")).ToString();
                    empleado.Nombre = reader.GetValue(reader.GetOrdinal("Nombre")).ToString();
                    empleado.Apellido_1 = reader.GetValue(reader.GetOrdinal("Apellido_1")).ToString();
                    empleado.Apellido_2 = reader.GetValue(reader.GetOrdinal("Apellido_2")).ToString();
                    empleado.Num_Empleado = reader.GetValue(reader.GetOrdinal("Num_Empleado")).ToString();
                    empleado.Jefe_de_proyecto = reader.GetValue(reader.GetOrdinal("Jefe_de_proyecto")).ToString();
                    empleado.Gerente = reader.GetValue(reader.GetOrdinal("Gerente")).ToString();
                    empleado.Usuario_Salesforce = reader.GetValue(reader.GetOrdinal("Usuario_Salesforce")).ToString();
                    empleado.Activo = reader.GetValue(reader.GetOrdinal("Activo")).ToString();
                    empleado.PerfilSalesforce = reader.GetValue(reader.GetOrdinal("PerfilSalesforce")).ToString();


                    Empleadoslist.Add(empleado);

                }

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return Empleadoslist;

        }

    }
}