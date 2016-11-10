using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Animal_Control.Models
{
    public class QueryVisitaVeterinario
    {
        public int ID { get; set; }
        public string Animal { get; set; }
        public string Usuario { get; set; }
        public DateTime Fecha { get; set; }
    }
}