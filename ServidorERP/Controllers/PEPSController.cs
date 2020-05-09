using ERP_SERVER.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ERP_SERVER.Controllers
{
    public class PEPSController : ApiController
    {
        // GET: api/PEPS
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/PEPS/5
        [Authorize]
        public string Get(int id)
        {
            return "value";
        }

        public Response Post([FromBody]PEPS Peps)
        {
            Uri MyUrl = this.Request.RequestUri;

           



            if (MyUrl.ToString().Contains("InsertPEP") && Peps.IdSalesforce != null)
            {

                Response res = new Response();
                Response res2 = new Response();
                res.ErrorCode = 0;
                res.ErrorMessage = "OK";

                if (!ERP_SERVER.BBDD.PEPSHandler.InsertPEP(Peps))
                {
                    res.ErrorCode = 1;
                    res.ErrorMessage = "No se ha podido Insertar el pep";
                }

                res2.Data = ERP_SERVER.BBDD.PEPSHandler.GetIdSalesforce(Peps.IdSalesforce);

                PEPS c = (PEPS)res2.Data.First();
                res.id = Int32.Parse(c.Id);
                return res;




            }


            if (MyUrl.ToString().Contains("ModifyPEP") && Peps.IdSalesforce != null)
            {

                Response res = new Response();
                Response res2 = new Response();
                res.ErrorCode = 0;
                res.ErrorMessage = "OK";

                if (!ERP_SERVER.BBDD.PEPSHandler.ModifyPEP(Peps))
                {
                    res.ErrorCode = 1;
                    res.ErrorMessage = "No se ha podido modificar el pep";
                }

                res2.Data = ERP_SERVER.BBDD.PEPSHandler.GetIdSalesforce(Peps.IdSalesforce);

                PEPS c = (PEPS)res2.Data.First();
                res.id = Int32.Parse(c.Id);
                return res;




            }




            return null;

        }

        // PUT: api/PEPS/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/PEPS/5
        public void Delete(int id)
        {
        }
    }
}
