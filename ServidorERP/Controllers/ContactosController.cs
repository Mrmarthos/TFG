using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ERP_SERVER.Models;
using ERP_SERVER.BBDD;
using System.Data.SqlClient;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ERP_SERVER.Controllers
{
    public class ContactosController : ApiController
    {
        [Route("api/[controller]")]

        // GET: api/Contactos
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }



        public void Get(String email)

        {



        }

        // POST: api/Contactos/
        [Authorize]
        public Response Post([FromBody]Contacto cont)
        {



               Uri MyUrl = this.Request.RequestUri;

                if (MyUrl.ToString().Contains("GetByCorreo") && cont.Correo!=null)
                {

                Response res = new Response();

                res.ErrorCode =0;
                res.ErrorMessage = "OK";

                
                res.Data = ERP_SERVER.BBDD.ContactHandler.GetContactbyemail(cont.Correo);

                res.Results = res.Data.Count();
                if (res.Results == 0)
                {
                    res.ErrorCode = 1;
                    res.ErrorMessage = "No se ha podido obtener el contacto";
                }
                return res;




            }
            else if (MyUrl.ToString().Contains("GetByCompany")&& cont.Company!=null)
                {
                Response res = new Response();

                res.ErrorCode = 0;
                res.ErrorMessage = "OK";
               
                res.Data = ERP_SERVER.BBDD.ContactHandler.GetContactbyCompany(cont.Company);
                res.Results = res.Data.Count();
                if (res.Results == 0)
                {
                    res.ErrorCode = 1;
                    res.ErrorMessage = "No se ha podido Obtener el contacto";
                }
                return res;


            }
            else if (MyUrl.ToString().Contains("InsertContact"))
            {
                Response res = new Response();
                Response res2 = new Response();
                res.ErrorCode = 0;
                res.ErrorMessage = "OK";
             
                if (!ERP_SERVER.BBDD.ContactHandler.InsertContact(cont))
                {
                    res.ErrorCode = 1;
                    res.ErrorMessage = "No se ha podido Insertar el contacto";
                }

                res2.Data = ERP_SERVER.BBDD.ContactHandler.GetContactbyName(cont);

                //res.id = Int32.Parse(res2.Data.First().id);
                Contacto c = (Contacto)res2.Data.First();
                res.id = Int32.Parse(c.id);
                return res;
                


            }
            else if (MyUrl.ToString().Contains("GetByName") && (cont.Nombre != null || cont.Apellido_1 !=null))
            {
                Response res = new Response();

                res.ErrorCode = 0;
                res.ErrorMessage = "OK";

                res.Data = ERP_SERVER.BBDD.ContactHandler.GetContactbyName(cont);
                res.Results = res.Data.Count();
                if (res.Results == 0)
                {
                    res.ErrorCode = 1;
                    res.ErrorMessage = "No se ha podido Obtener el contacto";
                }
                return res;


            }
            else if (MyUrl.ToString().Contains("ModifyContact"))
            {
                Response res = new Response();

                res.ErrorCode = 0;
                res.ErrorMessage = "OK";

                if (!ERP_SERVER.BBDD.ContactHandler.ModifyContact(cont))
                {
                    res.ErrorCode = 1;
                    res.ErrorMessage = "No se ha podido Modfificar el contacto";
                }
                return res;


            }




            return null;
          
          
         }



 


        // PUT: api/Contactos/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Contactos/5
        public void Delete(int id)
        {
        }
    }
}
