using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Animal_Control.Models
{
    public class QueryControlDiario
    {
        public int ID { get; set; } 
        public string animal { get; set; }
        public string usuario { get; set; }
        public string comentario { get; set; }
        public DateTime fecha { get; set; }
    }
}