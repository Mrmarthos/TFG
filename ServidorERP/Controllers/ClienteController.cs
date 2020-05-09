using ERP_SERVER.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ERP_SERVER.Controllers
{
    public class ClienteController : ApiController
    {
        // GET: api/Cliente
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Cliente/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Cliente
        [Authorize]
        public Response Post([FromBody]Cliente Cliente)
        {
            Uri MyUrl = this.Request.RequestUri;

            if (MyUrl.ToString().Contains("GetByNombre") && Cliente.Nombre != null)
            {

                Response res = new Response();

                res.ErrorCode = 0;
                res.ErrorMessage = "OK";


                res.Data = ERP_SERVER.BBDD.ClienteHandler.GetClientebyName(Cliente.Nombre);

                res.Results = res.Data.Count();
                if (res.Results == 0)
                {
                    res.ErrorCode = 1;
                    res.ErrorMessage = "No se ha podido obtener el cliente";
                }
                return res;




            }


            if (MyUrl.ToString().Contains("GetByNIF") )
            {

                Response res = new Response();

                res.ErrorCode = 0;
                res.ErrorMessage = "OK";


                res.Data = ERP_SERVER.BBDD.ClienteHandler.GetClientebyNIF(Cliente.NIF_CIF);

                res.Results = res.Data.Count();
                if (res.Results == 0)
                {
                    res.ErrorCode = 1;
                    res.ErrorMessage = "No se ha podido obtener el cliente";
                }
                return res;




            }


            if (MyUrl.ToString().Contains("InsertClient") && Cliente.NIF_CIF != null)
            {

                Response res = new Response();
                Response res2 = new Response();
                res.ErrorCode = 0;
                res.ErrorMessage = "OK";

                if (!ERP_SERVER.BBDD.ClienteHandler.InsertClient(Cliente))
                {
                    res.ErrorCode = 1;
                    res.ErrorMessage = "No se ha podido Insertar el cliente";
                }

                res2.Data = ERP_SERVER.BBDD.ClienteHandler.GetClientebyNIF(Cliente.NIF_CIF);

                Cliente c = (Cliente)res2.Data.First();
                //res.id = Int32.Parse(c.Id);
                return res;




            }

            if (MyUrl.ToString().Contains("ModifyClient") && Cliente.NIF_CIF != null)
            {

                Response res = new Response();

                res.ErrorCode = 0;
                res.ErrorMessage = "OK";

                if (!ERP_SERVER.BBDD.ClienteHandler.ModifyClient(Cliente))
                {
                    res.ErrorCode = 1;
                    res.ErrorMessage = "No se ha podido Modfificar el contacto";
                }
                Response res2 = new Response();
                res2.Data = ERP_SERVER.BBDD.ClienteHandler.GetClientebyNIF(Cliente.NIF_CIF);

                Cliente c = (Cliente)res2.Data.First();
                res.id = Int32.Parse(c.Id);
                return res;
                




            }


            return null;

        }

        // PUT: api/Cliente/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Cliente/5
        public void Delete(int id)
        {
        }
    }
}
