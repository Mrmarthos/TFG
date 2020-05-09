using ERP_SERVER.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ERP_SERVER.BBDD
{
    public class ClienteHandler
    {
        public static List<Data> GetClientebyName(String Name)
        {

            Conexion conexion = new Conexion();

            SqlConnection conn = conexion.Establececonexion();

            List<Data> Clientes = new List<Data>();

            var Nombre = new SqlParameter("Name", SqlDbType.VarChar);

            if(Nombre == null)
            {
                Nombre.Value = DBNull.Value;
            }
            else { Nombre.Value = "%" + Name + "%"; }

            String sqlquery = " select * from Clientes where Nombre LIKE @Name";
            try
            {
                SqlCommand cmd = new SqlCommand(sqlquery, conn);
                cmd.Parameters.Add(Nombre);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
            {
                Cliente cliente = new Cliente();


                    cliente.Ciudad= reader.GetValue(reader.GetOrdinal("Ciudad")).ToString();
                    cliente.Nombre = reader.GetValue(reader.GetOrdinal("Nombre")).ToString();
                    cliente.NIF_CIF = reader.GetValue(reader.GetOrdinal("NIF_CIF")).ToString();
                    cliente.Direccion = reader.GetValue(reader.GetOrdinal("Direccion")).ToString();
                    cliente.Direccion_Facturacion = reader.GetValue(reader.GetOrdinal("Direccion_Facturacion")).ToString();
                    cliente.Propietario = reader.GetValue(reader.GetOrdinal("Propietario")).ToString();
                    cliente.Pais = reader.GetValue(reader.GetOrdinal("Pais")).ToString();
                    cliente.Cod_Postal = reader.GetValue(reader.GetOrdinal("Cod_Postal")).ToString();
                    cliente.IdSalesforce= reader.GetValue(reader.GetOrdinal("IdSalesforce")).ToString();
                    cliente.Id = reader.GetValue(reader.GetOrdinal("Id")).ToString();

              
                    Clientes.Add(cliente);

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

            return Clientes;

        }


        public static List<Data> GetClientebyNIF(String NIF)
        {

            Conexion conexion = new Conexion();

            SqlConnection conn = conexion.Establececonexion();

            List<Data> Clientes = new List<Data>();

            var nif = new SqlParameter("NIF", SqlDbType.VarChar);

            if (nif == null)
            {
                nif.Value = DBNull.Value;
            }
            else { nif.Value = NIF ; }

            String sqlquery = "  select * from Clientes where NIF_CIF = @NIF";
            try
            {
                SqlCommand cmd = new SqlCommand(sqlquery, conn);
                cmd.Parameters.Add(nif);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Cliente cliente = new Cliente();


                    cliente.Ciudad = reader.GetValue(reader.GetOrdinal("Ciudad")).ToString();
                    cliente.Nombre = reader.GetValue(reader.GetOrdinal("Nombre")).ToString();
                    cliente.NIF_CIF = reader.GetValue(reader.GetOrdinal("NIF_CIF")).ToString();
                    cliente.Direccion = reader.GetValue(reader.GetOrdinal("Direccion")).ToString();
                    cliente.Direccion_Facturacion = reader.GetValue(reader.GetOrdinal("Direccion_Facturacion")).ToString();
                    cliente.Propietario = reader.GetValue(reader.GetOrdinal("Propietario")).ToString();
                    cliente.Pais = reader.GetValue(reader.GetOrdinal("Pais")).ToString();
                    cliente.Cod_Postal = reader.GetValue(reader.GetOrdinal("Cod_Postal")).ToString();
                    cliente.IdSalesforce = reader.GetValue(reader.GetOrdinal("IdSalesforce")).ToString();
                    cliente.Id = reader.GetValue(reader.GetOrdinal("Id")).ToString();


                    Clientes.Add(cliente);

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

            return Clientes;

        }

        public static Boolean InsertClient(Cliente Cliente)
        {

            Conexion conexion = new Conexion();

            SqlConnection conn = conexion.Establececonexion();

            List<Contacto> contactos = new List<Contacto>();

            var Nombre = new SqlParameter("Nombre", SqlDbType.VarChar);

            if (Cliente.Nombre == null)
            {
                Nombre.Value = DBNull.Value;
            }
            else { Nombre.Value = Cliente.Nombre; }

            var NIF_CIF = new SqlParameter("NIF_CIF", SqlDbType.NChar);

            if (Cliente.NIF_CIF == null)
            {
                NIF_CIF.Value = DBNull.Value;
            }
            else { NIF_CIF.Value = Cliente.NIF_CIF; }

            var Direccion = new SqlParameter("Direccion", SqlDbType.VarChar);

            if (Cliente.Direccion == null)
            {
                Direccion.Value = DBNull.Value;
            }
            else { Direccion.Value = Cliente.Direccion; }


            var Direccion_Facturacion = new SqlParameter("Direccion_Facturacion", SqlDbType.VarChar);

            if (Cliente.Direccion_Facturacion == null)
            {
                Direccion_Facturacion.Value = DBNull.Value;
            }
            else { Direccion_Facturacion.Value = Cliente.Direccion_Facturacion; }


            var Propietario = new SqlParameter("Propietario", SqlDbType.NChar);

            if (Cliente.Propietario == null)
            {
                Propietario.Value = DBNull.Value;
            }
            else { Propietario.Value = Cliente.Propietario; }


            var Razon_Social = new SqlParameter("Razon_Social", SqlDbType.VarChar);

            if (Cliente.Razon_Social == null)
            {
                Razon_Social.Value = DBNull.Value;
            }
            else { Razon_Social.Value = Cliente.Razon_Social; }


            var Ciudad = new SqlParameter("Ciudad", SqlDbType.VarChar);

            if (Cliente.Ciudad == null)
            {
                Ciudad.Value = DBNull.Value;
            }
            else { Ciudad.Value = Cliente.Ciudad; }


            var Pais = new SqlParameter("Pais", SqlDbType.VarChar);

            if (Cliente.Pais == null)
            {
                Pais.Value = DBNull.Value;
            }
            else { Pais.Value = Cliente.Pais; }

            var Cod_Postal = new SqlParameter("Cod_Postal", SqlDbType.NChar);

            if (Cliente.Cod_Postal == null)
            {
                Cod_Postal.Value = DBNull.Value;
            }
            else { Cod_Postal.Value = Cliente.Cod_Postal; }


            var IdSalesforce = new SqlParameter("idSalesforce", SqlDbType.VarChar);

            if (Cliente.IdSalesforce == null)
            {
                IdSalesforce.Value = DBNull.Value;
            }
            else { IdSalesforce.Value = Cliente.IdSalesforce; }


            String sqlquery = "Insert into Clientes (Nombre,NIF_CIF,Direccion,Direccion_Facturacion,Propietario,Razon_Social,Ciudad,Cod_Postal,IdSalesforce,Pais) values(@Nombre,@NIF_CIF,@Direccion,@Direccion_Facturacion,@Propietario,@Razon_Social,@Ciudad,@Cod_Postal,@IdSalesforce,@Pais)";
            try
            {
                SqlCommand cmd = new SqlCommand(sqlquery, conn);


                cmd.Parameters.Add(Nombre);
                cmd.Parameters.Add(NIF_CIF);
                cmd.Parameters.Add(Direccion);
                cmd.Parameters.Add(Direccion_Facturacion);
                cmd.Parameters.Add(Razon_Social);
                cmd.Parameters.Add(Ciudad);
                cmd.Parameters.Add(Cod_Postal);
                cmd.Parameters.Add(IdSalesforce);
                cmd.Parameters.Add(Propietario);
                cmd.Parameters.Add(Pais);
                cmd.ExecuteNonQuery();




            }
            catch (SqlException ex)
            {
                return false;

            }
            finally
            {
                conn.Close();
            }

            return true;

        }

        public static Boolean ModifyClient(Cliente Cliente)
        {

            Conexion conexion = new Conexion();

            SqlConnection conn = conexion.Establececonexion();

            List<Contacto> contactos = new List<Contacto>();

            var Nombre = new SqlParameter("Nombre", SqlDbType.VarChar);

            if (Cliente.Nombre == null)
            {
                Nombre.Value = DBNull.Value;
            }
            else { Nombre.Value = Cliente.Nombre; }

            var NIF_CIF = new SqlParameter("NIF_CIF", SqlDbType.VarChar);

            if (Cliente.NIF_CIF == null)
            {
                NIF_CIF.Value = DBNull.Value;
            }
            else { NIF_CIF.Value = Cliente.NIF_CIF; }

            var Direccion = new SqlParameter("Direccion", SqlDbType.VarChar);

            if (Cliente.Direccion == null)
            {
                Direccion.Value = DBNull.Value;
            }
            else { Direccion.Value = Cliente.Direccion; }


            var Direccion_Facturacion = new SqlParameter("Direccion_Facturacion", SqlDbType.VarChar);

            if (Cliente.Direccion_Facturacion == null)
            {
                Direccion_Facturacion.Value = DBNull.Value;
            }
            else { Direccion_Facturacion.Value = Cliente.Direccion_Facturacion; }


            var Propietario = new SqlParameter("Propietario", SqlDbType.Int);

            if (Cliente.Propietario == null)
            {
                Propietario.Value = DBNull.Value;
            }
            else { Propietario.Value = Cliente.Propietario; }


            var Razon_Social = new SqlParameter("Razon_Social", SqlDbType.VarChar);

            if (Cliente.Razon_Social == null)
            {
                Razon_Social.Value = DBNull.Value;
            }
            else { Razon_Social.Value = Cliente.Razon_Social; }


            var Ciudad = new SqlParameter("Ciudad", SqlDbType.VarChar);

            if (Cliente.Ciudad == null)
            {
                Ciudad.Value = DBNull.Value;
            }
            else { Ciudad.Value = Cliente.Ciudad; }


            var Pais = new SqlParameter("Pais", SqlDbType.VarChar);

            if (Cliente.Pais == null)
            {
                Pais.Value = DBNull.Value;
            }
            else { Pais.Value = Cliente.Pais; }

            var Cod_Postal = new SqlParameter("Cod_Postal", SqlDbType.NChar);

            if (Cliente.Cod_Postal == null)
            {
                Cod_Postal.Value = DBNull.Value;
            }
            else { Cod_Postal.Value = Cliente.Cod_Postal; }

            var Id = new SqlParameter("Id", SqlDbType.NChar);

            if (Cliente.Id == null)
            {
                Id.Value = DBNull.Value;
            }
            else { Id.Value = Cliente.Id; }


            var IdSalesforce = new SqlParameter("idSalesforce", SqlDbType.VarChar);

            if (Cliente.IdSalesforce == null)
            {
                IdSalesforce.Value = DBNull.Value;
            }
            else { IdSalesforce.Value = Cliente.IdSalesforce; }


            String sqlquery = "UPDATE Clientes SET Nombre = @Nombre, NIF_CIF = @NIF_CIF, Direccion = @Direccion, Direccion_Facturacion = @Direccion_Facturacion, Propietario = @Propietario, Razon_Social = @Razon_Social, Ciudad = @Ciudad,Cod_Postal=@Cod_Postal,Pais=@Pais WHERE (idSalesforce = @idSalesforce AND Id=@Id); ";
            try
            {
                SqlCommand cmd = new SqlCommand(sqlquery, conn);


                cmd.Parameters.Add(Nombre);
                cmd.Parameters.Add(NIF_CIF);
                cmd.Parameters.Add(Direccion);
                cmd.Parameters.Add(Direccion_Facturacion);
                cmd.Parameters.Add(Razon_Social);
                cmd.Parameters.Add(Ciudad);
                cmd.Parameters.Add(Cod_Postal);
                cmd.Parameters.Add(IdSalesforce);
                cmd.Parameters.Add(Propietario);
                cmd.Parameters.Add(Pais);
                cmd.Parameters.Add(Id);
                cmd.ExecuteNonQuery();




            }
            catch (SqlException ex)
            {
                return false;

            }
            finally
            {
                conn.Close();
            }

            return true;

        }

    }
}