namespace Animal_Control.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AC_Liberacion
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Especie { get; set; }

        public int Edad { get; set; }

        [Required]
        [StringLength(50)]
        public string Sexo { get; set; }

        [Required]
        [StringLength(50)]
        public string Condicion { get; set; }

        public int Peso { get; set; }

        [Required]
        [StringLength(50)]
        public string Temperamento { get; set; }

        public int Frecuencia_Cardiaca { get; set; }

        public int Frecuencia_Respiratoria { get; set; }

        public int Temperatura { get; set; }

        [Required]
        [StringLength(50)]
        public string Coloracion_Mucosa { get; set; }

        public int ID_Usuario { get; set; }

        public int ID_Zona { get; set; }

        public int ID_Daño { get; set; }

        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

        [Required]
        [StringLength(500)]
        public string Comentario { get; set; }

        public virtual AC_Daño AC_Daño { get; set; }

        public virtual AC_Usuario AC_Usuario { get; set; }

        public virtual AC_Zona AC_Zona { get; set; }
    }
}
