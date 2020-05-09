using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP_SERVER.Models
{
    public class PEPS:Data
    {

        public String IdSalesforce { get; set; }
        public String Nombre { get; set; }
        public String Gerente { get; set; }
        public String Comercial { get; set; }
        public String Fecha_Inicio { get; set; }
        public String Fecha_Fin { get; set; }
        public String Jefe_Proyecto { get; set; }
        public String Importe { get; set; }
        public String Cod_Oferta { get; set; }
        public String Id { get; set; }
        public String Area { get; set; }
        public String Cliente { get; set; }

    }
}