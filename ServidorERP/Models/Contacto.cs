using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP_SERVER.Models
{
    public class Contacto :Data
    {
        public String Correo { get; set; }
        public String Movil { get; set; }
        public String Telefono { get; set; }
        public String Nombre { get; set; }
        public String Apellido_1 { get; set; }
        public String Apellido_2 { get; set; }
        public String id { get; set; }
        public String Cuenta_id { get; set; }
        public String idSalesforce { get; set; }
        public String Comentario { get; set; }
        public String Company { get; set; }



    }


}