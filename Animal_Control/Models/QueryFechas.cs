using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Animal_Control.Models
{
    public class QueryFechas
    {
        [DataType(DataType.Date)]
        public DateTime fecha1 { get; set; }
        [DataType(DataType.Date)]
        public DateTime fecha2 { get; set; }
    }
}