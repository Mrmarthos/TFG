using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP_SERVER.Models
{
    public class Response 
    {
        public int ErrorCode { get; set; }
        public int Results { get; set; }
        public String ErrorMessage { get; set; }
        public int id { get; set; }
        public List<Data> Data { get; set; }


    }

   
}