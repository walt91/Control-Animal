namespace Animal_Control.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AC_Visita_Veterinaria
    {
        [Key]
        public int VV_ID { get; set; }

        public int ID_Animal { get; set; }

        public int ID_Usuario { get; set; }

        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

        public virtual AC_Animal AC_Animal { get; set; }

        public virtual AC_Usuario AC_Usuario { get; set; }
    }
}
