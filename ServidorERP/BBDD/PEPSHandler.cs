using ERP_SERVER.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ERP_SERVER.BBDD
{
    public class PEPSHandler
    {

        public static Boolean InsertPEP(PEPS Pep)
        {

            Conexion conexion = new Conexion();

            SqlConnection conn = conexion.Establececonexion();

            List<Contacto> contactos = new List<Contacto>();

            var Nombre = new SqlParameter("Nombre", SqlDbType.VarChar);

            if (Pep.Nombre == null)
            {
                Nombre.Value = DBNull.Value;
            }
            else { Nombre.Value = Pep.Nombre; }

            var Gerente = new SqlParameter("Gerente", SqlDbType.Int);

            if (Pep.Gerente == null)
            {
                Gerente.Value = DBNull.Value;
            }
            else { Gerente.Value = Pep.Gerente; }

            var Comercial = new SqlParameter("Comercial", SqlDbType.Int);

            if (Pep.Comercial== null)
            {
                Comercial.Value = DBNull.Value;
            }
            else { Comercial.Value = Pep.Comercial; }


            var Fecha_Incio = new SqlParameter("Fecha_Incio", SqlDbType.Date);

            if (Pep.Fecha_Inicio == null)
            {
                Fecha_Incio.Value = DBNull.Value;
            }
            else { Fecha_Incio.Value = Pep.Fecha_Inicio; }


            var Fecha_Fin = new SqlParameter("Fecha_Fin", SqlDbType.Date);

            if (Pep.Fecha_Fin== null)
            {
                Fecha_Fin.Value = DBNull.Value;
            }
            else { Fecha_Fin.Value = Pep.Fecha_Fin; }


            var Jefe_Proyecto = new SqlParameter("Jefe_Proyecto", SqlDbType.Int);

            if (Pep.Jefe_Proyecto == null)
            {
                Jefe_Proyecto.Value = DBNull.Value;
            }
            else { Jefe_Proyecto.Value = Pep.Jefe_Proyecto; }


            var Importe = new SqlParameter("Importe", SqlDbType.Money);

            if (Pep.Importe == null)
            {
                Importe.Value = DBNull.Value;
            }
            else { Importe.Value = Pep.Importe; }


            var Cod_Oferta = new SqlParameter("Cod_Oferta", SqlDbType.VarChar);

            if (Pep.Cod_Oferta == null)
            {
                Cod_Oferta.Value = DBNull.Value;
            }
            else { Cod_Oferta.Value = Pep.Cod_Oferta; }

            var Area = new SqlParameter("Area", SqlDbType.VarChar);

            if (Pep.Area == null)
            {
                Area.Value = DBNull.Value;
            }
            else { Area.Value = Pep.Area; }






            var IdSalesforce = new SqlParameter("idSalesforce", SqlDbType.VarChar);

            if (Pep.IdSalesforce == null)
            {
                IdSalesforce.Value = DBNull.Value;
            }
            else { IdSalesforce.Value = Pep.IdSalesforce; }


            var Cliente = new SqlParameter("Cliente", SqlDbType.NChar);

            if (Pep.Cliente == null)
            {
                Cliente.Value = DBNull.Value;
            }
            else { Cliente.Value = Pep.Cliente; }


            String sqlquery = "Insert into PEPS (IdSalesforce,Nombre,Gerente,Comercial,Fecha_Incio,Fecha_Fin,Jefe_Proyecto,Importe,Cod_Oferta,Area,Cliente) values(@IdSalesforce,@Nombre,@Gerente,@Comercial,@Fecha_Incio,@Fecha_Fin,@Jefe_Proyecto,@Importe,@Cod_Oferta,@Area,@Cliente)";
            try
            {
                SqlCommand cmd = new SqlCommand(sqlquery, conn);


                cmd.Parameters.Add(IdSalesforce);
                cmd.Parameters.Add(Nombre);
                cmd.Parameters.Add(Gerente);
                cmd.Parameters.Add(Comercial);
                cmd.Parameters.Add(Fecha_Incio);
                cmd.Parameters.Add(Fecha_Fin);
                cmd.Parameters.Add(Jefe_Proyecto);
                cmd.Parameters.Add(Importe);
                cmd.Parameters.Add(Cod_Oferta);
                cmd.Parameters.Add(Area);
                cmd.Parameters.Add(Cliente);
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

        public static List<Data> GetIdSalesforce(String id)
        {
          

                Conexion conexion = new Conexion();

                SqlConnection conn = conexion.Establececonexion();

                List<Data> Peps = new List<Data>();

                var IdSalesforce = new SqlParameter("IdSalesforce", SqlDbType.VarChar);

                if (id == null)
                {
                IdSalesforce.Value = DBNull.Value;
                }
                else { IdSalesforce.Value = "%" + id + "%"; }

               String sqlquery = "  select * from PEPS where IdSalesforce LIKE @IdSalesforce";
            try
                {
                    SqlCommand cmd = new SqlCommand(sqlquery, conn);
                    cmd.Parameters.Add(IdSalesforce);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                         PEPS pep= new PEPS();



                        pep.Id = reader.GetValue(reader.GetOrdinal("Id")).ToString();


                        Peps.Add(pep);

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

                return Peps;

            }

        public static Boolean  ModifyPEP (PEPS Pep)
        {

            Conexion conexion = new Conexion();

            SqlConnection conn = conexion.Establececonexion();

            List<Contacto> contactos = new List<Contacto>();

            var Nombre = new SqlParameter("Nombre", SqlDbType.VarChar);

            if (Pep.Nombre == null)
            {
                Nombre.Value = DBNull.Value;
            }
            else { Nombre.Value = Pep.Nombre; }

            var Gerente = new SqlParameter("Gerente", SqlDbType.NChar);

            if (Pep.Gerente == null)
            {
                Gerente.Value = DBNull.Value;
            }
            else { Gerente.Value = Pep.Gerente; }

            var Comercial = new SqlParameter("Comercial", SqlDbType.NChar);

            if (Pep.Comercial == null)
            {
                Comercial.Value = DBNull.Value;
            }
            else { Comercial.Value = Pep.Comercial; }


            var Fecha_Incio = new SqlParameter("Fecha_Incio", SqlDbType.Date);

            if (Pep.Fecha_Inicio == null)
            {
                Fecha_Incio.Value = DBNull.Value;
            }
            else { Fecha_Incio.Value = Pep.Fecha_Inicio; }


            var Fecha_Fin = new SqlParameter("Fecha_Fin", SqlDbType.Date);

            if (Pep.Fecha_Fin == null)
            {
                Fecha_Fin.Value = DBNull.Value;
            }
            else { Fecha_Fin.Value = Pep.Fecha_Fin; }


            var Jefe_Proyecto = new SqlParameter("Jefe_Proyecto", SqlDbType.NChar);

            if (Pep.Jefe_Proyecto == null)
            {
                Jefe_Proyecto.Value = DBNull.Value;
            }
            else { Jefe_Proyecto.Value = Pep.Jefe_Proyecto; }


            var Importe = new SqlParameter("Importe", SqlDbType.Money);

            if (Pep.Importe == null)
            {
                Importe.Value = DBNull.Value;
            }
            else { Importe.Value = Pep.Importe; }


            var Cod_Oferta = new SqlParameter("Cod_Oferta", SqlDbType.VarChar);

            if (Pep.Cod_Oferta == null)
            {
                Cod_Oferta.Value = DBNull.Value;
            }
            else { Cod_Oferta.Value = Pep.Cod_Oferta; }

            var Area = new SqlParameter("Area", SqlDbType.VarChar);

            if (Pep.Area == null)
            {
                Area.Value = DBNull.Value;
            }
            else { Area.Value = Pep.Area; }






            var IdSalesforce = new SqlParameter("idSalesforce", SqlDbType.VarChar);

            if (Pep.IdSalesforce == null)
            {
                IdSalesforce.Value = DBNull.Value;
            }
            else { IdSalesforce.Value = Pep.IdSalesforce; }


            var Id = new SqlParameter("Id", SqlDbType.NChar);

            if (Pep.Id == null)
            {
                Id.Value = DBNull.Value;
            }
            else { Id.Value = Pep.Id; }




            String sqlquery = "UPDATE PEPS SET IdSalesforce = @IdSalesforce, Nombre = @Nombre, Gerente = @Gerente, Comercial = @Comercial, Fecha_Incio=@Fecha_Incio,Jefe_Proyecto = @Jefe_Proyecto, Fecha_Fin = @Fecha_Fin, Importe = @Importe,Cod_Oferta=@Cod_Oferta,Area=@Area WHERE (idSalesforce = @idSalesforce AND Id=@Id); ";
            try
            {
                SqlCommand cmd = new SqlCommand(sqlquery, conn);


                cmd.Parameters.Add(IdSalesforce);
                cmd.Parameters.Add(Nombre);
                cmd.Parameters.Add(Gerente);
                cmd.Parameters.Add(Comercial);
                cmd.Parameters.Add(Fecha_Incio);
                cmd.Parameters.Add(Fecha_Fin);
                cmd.Parameters.Add(Jefe_Proyecto);
                cmd.Parameters.Add(Importe);
                cmd.Parameters.Add(Cod_Oferta);
                cmd.Parameters.Add(Area);
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