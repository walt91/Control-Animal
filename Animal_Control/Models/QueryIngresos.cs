using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Animal_Control.Models
{
    public class QueryIngresos
    {
        public int I_ID { get; set; }
        public string Comentario { get; set; }
        public int Dinero { get; set; }
        public string Usuario { get; set; }
        public DateTime Fecha { get; set; }

    }
}