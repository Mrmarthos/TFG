using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP_SERVER.Models
{
    public class Empleados:Data
    {

        public String Correo { get; set; }
        public String Movil { get; set; }
        public String Nombre { get; set; }
        public String Apellido_1 { get; set; }
        public String Apellido_2 { get; set; }
        public String Num_Empleado { get; set; }
        public String Jefe_de_proyecto { get; set; }
        public String Gerente { get; set; }
        public String Usuario_Salesforce { get; set; }
        public String Activo { get; set; }
        public String PerfilSalesforce { get; set; }
   

    }
}