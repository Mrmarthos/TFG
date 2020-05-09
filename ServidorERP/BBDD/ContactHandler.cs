using ERP_SERVER.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ERP_SERVER.BBDD
{
    public class ContactHandler
    {
        public static List<Data> GetContactbyemail(String correo)
        {

            Conexion conexion = new Conexion();

            SqlConnection conn = conexion.Establececonexion();

            List<Data> contactos = new List<Data>();

            var Email = new SqlParameter("Email", SqlDbType.VarChar);

            if (Email == null)
            {
                Email.Value = DBNull.Value;
            }
            else { Email.Value = "%" +correo +"%"; }

            String sqlquery = "  select * from Contactos where Correo LIKE @Email";
            try
            {
                SqlCommand cmd = new SqlCommand(sqlquery, conn);
                cmd.Parameters.Add(Email);
                cmd.ExecuteNonQuery();
                SqlDataReader reader = cmd.ExecuteReader();

            
            while (reader.Read())
            {
                Contacto cont = new Contacto();

                cont.Apellido_1 = reader.GetValue(reader.GetOrdinal("Apellido_1")).ToString();
                cont.Apellido_2 = reader.GetValue(reader.GetOrdinal("Apellido_2")).ToString();
                cont.Correo = reader.GetValue(reader.GetOrdinal("Correo")).ToString();
                cont.Nombre = reader.GetValue(reader.GetOrdinal("Nombre")).ToString();
                cont.Movil = reader.GetValue(reader.GetOrdinal("Movil")).ToString();
                cont.Telefono = reader.GetValue(reader.GetOrdinal("Telefono")).ToString();
                cont.Comentario= reader.GetValue(reader.GetOrdinal("Comentario")).ToString();
                    cont.Comentario = reader.GetValue(reader.GetOrdinal("Comentario")).ToString();
                    cont.Cuenta_id = reader.GetValue(reader.GetOrdinal("Cuenta_id")).ToString();
                    contactos.Add(cont);

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

            return contactos;
        }
     
        public static List<Data> GetContactbyCompany(String company)
        {

            Conexion conexion = new Conexion();

            SqlConnection conn = conexion.Establececonexion();

            List<Data> contactos = new List<Data>();

            var compania = new SqlParameter("compania", SqlDbType.VarChar);

            if (company == null)
            {
                compania.Value = DBNull.Value;
            }
            else { compania.Value = company; }

            String sqlquery = "select * from Contactos where Contactos.Cuenta_id IN ( Select Clientes.Id  from Clientes where Clientes.Nombre LIKE @compania)";
            try
            {
                SqlCommand cmd = new SqlCommand(sqlquery, conn);
                cmd.Parameters.Add(compania);
                SqlDataReader reader = cmd.ExecuteReader();
                              

                while (reader.Read())
                {
                    Contacto cont = new Contacto();

                    cont.Apellido_1 = reader.GetValue(reader.GetOrdinal("Apellido_1")).ToString();
                    cont.Apellido_2 = reader.GetValue(reader.GetOrdinal("Apellido_2")).ToString();
                    cont.Correo = reader.GetValue(reader.GetOrdinal("Correo")).ToString();
                    cont.Cuenta_id = reader.GetValue(reader.GetOrdinal("Cuenta_id")).ToString();
                    cont.id = reader.GetValue(reader.GetOrdinal("id")).ToString();
                    cont.Nombre = reader.GetValue(reader.GetOrdinal("Nombre")).ToString();
                    cont.Movil = reader.GetValue(reader.GetOrdinal("Movil")).ToString();
                    cont.idSalesforce = reader.GetValue(reader.GetOrdinal("idSalesforce")).ToString();
                    cont.Telefono = reader.GetValue(reader.GetOrdinal("Telefono")).ToString();
                    cont.Comentario= reader.GetValue(reader.GetOrdinal("Comentario")).ToString();
                    contactos.Add(cont);

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

            return contactos;

        }


        public static List<Data> GetContactbyName(Contacto con)
        {

            Conexion conexion = new Conexion();

            SqlConnection conn = conexion.Establececonexion();

            List<Data> contactos = new List<Data>();

            var Nombre = new SqlParameter("Nombre", SqlDbType.VarChar);

            if (con.Nombre == null)
            {
                Nombre.Value = DBNull.Value;
            }
            else { Nombre.Value =  "%"+con.Nombre+"%"; }


            var Apellido = new SqlParameter("Apellido", SqlDbType.VarChar);

            if (con.Apellido_1 == null)
            {
                Apellido.Value = DBNull.Value;
            }
            else { Apellido.Value = "%" + con.Apellido_1 + "%"; }

        
            String sqlquery = "select * from Contactos where Nombre like @Nombre or Apellido_1 like @Apellido ";
            try
            {
                SqlCommand cmd = new SqlCommand(sqlquery, conn);
                cmd.Parameters.Add(Nombre);
                cmd.Parameters.Add(Apellido);
                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    Contacto cont = new Contacto();

                    cont.Apellido_1 = reader.GetValue(reader.GetOrdinal("Apellido_1")).ToString();
                    cont.Apellido_2 = reader.GetValue(reader.GetOrdinal("Apellido_2")).ToString();
                    cont.Correo = reader.GetValue(reader.GetOrdinal("Correo")).ToString();
                    cont.Cuenta_id = reader.GetValue(reader.GetOrdinal("Cuenta_id")).ToString();
                    cont.id = reader.GetValue(reader.GetOrdinal("id")).ToString();
                    cont.Nombre = reader.GetValue(reader.GetOrdinal("Nombre")).ToString();
                    cont.Movil = reader.GetValue(reader.GetOrdinal("Movil")).ToString();
                    cont.idSalesforce = reader.GetValue(reader.GetOrdinal("idSalesforce")).ToString();
                    cont.Comentario = reader.GetValue(reader.GetOrdinal("Comentario")).ToString();
             
                    contactos.Add(cont);

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

            return contactos;

        }

        public static Boolean InsertContact(Contacto cont)
        {

            Conexion conexion = new Conexion();

            SqlConnection conn = conexion.Establececonexion();

            List<Contacto> contactos = new List<Contacto>();

            var Correo = new SqlParameter("Correo", SqlDbType.VarChar);

            if (cont.Correo == null)
            {
                Correo.Value = DBNull.Value;
            }
            else { Correo.Value = cont.Correo; }

            var Movil = new SqlParameter("Movil", SqlDbType.NChar);

            if (cont.Movil == null)
            {
                Movil.Value = DBNull.Value;
            }
            else { Movil.Value = cont.Movil; }

            var Telefono = new SqlParameter("Telefono", SqlDbType.NChar);

            if (cont.Telefono == null)
            {
                Telefono.Value = DBNull.Value;
            }
            else { Telefono.Value = cont.Telefono; }

            var Nombre = new SqlParameter("Nombre", SqlDbType.VarChar);

            if (cont.Nombre == null)
            {
                Nombre.Value = DBNull.Value;
            }
            else { Nombre.Value = cont.Nombre; }

            var Apellido_1 = new SqlParameter("Apellido_1", SqlDbType.VarChar);

            if (cont.Apellido_1 == null)
            {
                Apellido_1.Value = DBNull.Value;
            }
            else { Apellido_1.Value = cont.Apellido_1; }

            var Apellido_2 = new SqlParameter("Apellido_2", SqlDbType.VarChar);

            if (cont.Apellido_2 == null)
            {
                Apellido_2.Value = DBNull.Value;
            }
            else { Apellido_2.Value = cont.Apellido_2; }

       


            var id = new SqlParameter("id", SqlDbType.NChar);

            if (cont.id == null)
            {
                id.Value = DBNull.Value;
            }
            else { id.Value = cont.id; }

            var Cuenta_id = new SqlParameter("Cuenta_id", SqlDbType.VarChar);

            if (cont.Cuenta_id == null || cont.Cuenta_id=="null")
            {
                Cuenta_id.Value = DBNull.Value;
            }
            else { Cuenta_id.Value = cont.Cuenta_id; }



            var idSalesforce = new SqlParameter("IdSalesforce", SqlDbType.VarChar);

            if (cont.idSalesforce==null){
                idSalesforce.Value = DBNull.Value;
            }
            else { idSalesforce.Value = cont.idSalesforce; }





            String sqlquery = "Insert into Contactos (Correo,Movil,Telefono,Nombre,Apellido_1,Apellido_2,Cuenta_id,idSalesforce) values(@Correo,@Movil,@Telefono,@Nombre,@Apellido_1,@Apellido_2,@Cuenta_id,@idSalesforce)";
            try
            {
                SqlCommand cmd = new SqlCommand(sqlquery, conn);


                cmd.Parameters.Add(Correo);
                cmd.Parameters.Add(Movil);        
                cmd.Parameters.Add(Telefono);
                cmd.Parameters.Add(Nombre);
                cmd.Parameters.Add(Apellido_1);
                cmd.Parameters.Add(Apellido_2);
                cmd.Parameters.Add(Cuenta_id);
                cmd.Parameters.Add(idSalesforce);
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


        public static Boolean ModifyContact(Contacto cont)
        {

            Conexion conexion = new Conexion();

            SqlConnection conn = conexion.Establececonexion();

            List<Contacto> contactos = new List<Contacto>();

            var Correo = new SqlParameter("Correo", SqlDbType.VarChar);

            if (cont.Correo == null)
            {
                Correo.Value = DBNull.Value;
            }
            else { Correo.Value = cont.Correo; }

            var Movil = new SqlParameter("Movil", SqlDbType.NChar);

            if (cont.Movil == null)
            {
                Movil.Value = DBNull.Value;
            }
            else { Movil.Value = cont.Movil; }

            var Telefono = new SqlParameter("Telefono", SqlDbType.NChar);

            if (cont.Telefono == null)
            {
                Telefono.Value = DBNull.Value;
            }
            else { Telefono.Value = cont.Telefono; }

            var Nombre = new SqlParameter("Nombre", SqlDbType.VarChar);

            if (cont.Nombre == null)
            {
                Nombre.Value = DBNull.Value;
            }
            else { Nombre.Value = cont.Nombre; }

            var Apellido_1 = new SqlParameter("Apellido_1", SqlDbType.VarChar);

            if (cont.Apellido_1 == null)
            {
                Apellido_1.Value = DBNull.Value;
            }
            else { Apellido_1.Value = cont.Apellido_1; }

            var Apellido_2 = new SqlParameter("Apellido_2", SqlDbType.VarChar);

            if (cont.Apellido_2 == null)
            {
                Apellido_2.Value = DBNull.Value;
            }
            else { Apellido_2.Value = cont.Apellido_2; }




            var id = new SqlParameter("id", SqlDbType.NChar);

            if (cont.id == null)
            {
                id.Value = DBNull.Value;
            }
            else { id.Value = cont.id; }

            var Cuenta_id = new SqlParameter("Cuenta_id", SqlDbType.VarChar);

            if (cont.Cuenta_id == null)
            {
                Cuenta_id.Value = DBNull.Value;
            }
            else { Cuenta_id.Value = cont.Cuenta_id; }



            var idSalesforce = new SqlParameter("IdSalesforce", SqlDbType.VarChar);

            if (cont.idSalesforce == null)
            {
                idSalesforce.Value = DBNull.Value;
            }
            else { idSalesforce.Value = cont.idSalesforce; }





            String sqlquery = "UPDATE Contactos SET Correo = @Correo, Movil = @Movil, Telefono = @Telefono, Nombre = @Nombre, Apellido_1 = @Apellido_1, Apellido_2 = @Apellido_2, Cuenta_id = @Cuenta_id WHERE idSalesforce = @idSalesforce; ";

            
            try
            {
                SqlCommand cmd = new SqlCommand(sqlquery, conn);


                cmd.Parameters.Add(Correo);
                cmd.Parameters.Add(Movil);
                cmd.Parameters.Add(Telefono);
                cmd.Parameters.Add(Nombre);
                cmd.Parameters.Add(Apellido_1);
                cmd.Parameters.Add(Apellido_2);
                cmd.Parameters.Add(id);
                cmd.Parameters.Add(Cuenta_id);
                cmd.Parameters.Add(idSalesforce);
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