namespace Animal_Control.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AC_Control_Diario
    {
        [Key]
        public int CD_ID { get; set; }

        public int ID_Animal { get; set; }

        public int? ID_Medicamento { get; set; }

        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

        public int ID_Usuario { get; set; }

        public int? ID_Vacuna { get; set; }

        [Required(ErrorMessage = "Escriba un comentario")]
        [StringLength(500)]
        public string Comentario { get; set; }

        public virtual AC_Animal AC_Animal { get; set; }

        public virtual AC_Medicamento AC_Medicamento { get; set; }

        public virtual AC_Usuario AC_Usuario { get; set; }

        public virtual AC_Vacuna AC_Vacuna { get; set; }
    }
}
