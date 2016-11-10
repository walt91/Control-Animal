using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Animal_Control.Models
{
    public class QueryGastos
    {

        public int G_ID { get; set; }
        public string Articulo { get; set; }
        public int Costo { get; set; }
        public string Usuario { get; set; }
        public DateTime Fecha { get; set; }
    }
}