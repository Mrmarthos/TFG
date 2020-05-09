using ERP_SERVER.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ERP_SERVER.Controllers
{
    public class EmpleadosController : ApiController
    {
        // GET: api/Empleados
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Empleados/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Empleados
        [Authorize]
        public Response Post([FromBody]Empleados empleado)
        {
            Uri MyUrl = this.Request.RequestUri;

            if (MyUrl.ToString().Contains("GetEmpleados") )
            {

                Response res = new Response();

                res.ErrorCode = 0;
                res.ErrorMessage = "OK";


                res.Data = ERP_SERVER.BBDD.EmpleadosHandler.GetEmployes();

                res.Results = res.Data.Count();
                if (res.Results == 0)
                {
                    res.ErrorCode = 1;
                    res.ErrorMessage = "No se ha podido obtener el cliente";
                }
                return res;




            }

            return null;

        }

        // PUT: api/Empleados/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Empleados/5
        public void Delete(int id)
        {
        }
    }
}
