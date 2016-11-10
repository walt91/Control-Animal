namespace Animal_Control.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AC_Ingresos
    {
        [Key]
        public int I_ID { get; set; }

        public int Dinero { get; set; }

        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

        public int ID_Usuario { get; set; }

        [Required]
        [StringLength(500)]
        public string Comentario { get; set; }

        public virtual AC_Usuario AC_Usuario { get; set; }
    }
}
