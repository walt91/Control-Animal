using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Animal_Control.Models
{
    public class QueryStockMinimo
    {
        public int ID { get; set; }
        public string Articulo { get; set; }
        public int cantidad { set; get; }
    }
}