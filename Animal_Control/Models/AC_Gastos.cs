namespace Animal_Control.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AC_Gastos
    {
        [Key]
        public int G_ID { get; set; }

       
        public int? ID_Articulo { get; set; }

        [Required]
        public int Costo { get; set; }

        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

        public int ID_Usuario { get; set; }

        public virtual AC_Articulo AC_Articulo { get; set; }

        public virtual AC_Usuario AC_Usuario { get; set; }
    }
}
