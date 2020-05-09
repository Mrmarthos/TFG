using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP_SERVER.Models
{
    public class Cliente: Data
    {

        public String Nombre { get; set; }
        public String NIF_CIF { get; set; }
        public String Direccion { get; set; }
        public String Direccion_Facturacion { get; set; }
        public String Propietario { get; set; }
        public String Razon_Social { get; set; }
        public String Ciudad { get; set; }
        public String Pais { get; set; }
        public String Cod_Postal { get; set; }
        public String IdSalesforce { get; set; }
        public String Id { get; set; }
    }
}