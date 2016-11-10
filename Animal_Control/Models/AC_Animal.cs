namespace Animal_Control.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AC_Animal
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AC_Animal()
        {
            AC_Control_Diario = new HashSet<AC_Control_Diario>();
            AC_Visita_Veterinaria = new HashSet<AC_Visita_Veterinaria>();
        }

        public int ID { get; set; }

        [Required(ErrorMessage = "Agregue una especie")]
        [StringLength(50)]
        public string Especie { get; set; }

        public int Edad { get; set; }

        [Required(ErrorMessage = "Escriba un sexo")]
        [StringLength(50)]
        public string Sexo { get; set; }

        [Required(ErrorMessage = "Escriba la condicion en que llega")]
        [StringLength(50)]
        public string Condicion { get; set; }

        [Required(ErrorMessage = "Digite el peso del animal")]
        public int Peso { get; set; }

        [Required(ErrorMessage = "Escriba el temperamento del animal")]
        [StringLength(50)]
        public string Temperamento { get; set; }

        public int Frecuencia_Cardiaca { get; set; }

        public int Frecuencia_Respiratoria { get; set; }

        public int Temperatura { get; set; }

        [Required(ErrorMessage = "Rellene el campo")]
        [StringLength(50)]
        public string Coloracion_Mucosa { get; set; }

        public int ID_Usuario { get; set; }

        public int ID_Zona { get; set; }

        public int ID_Daño { get; set; }

        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "Escriba un comentario")]
        [StringLength(500)]
        public string Comentario { get; set; }

        public int ID_Persona_Reporta { get; set; }

        public virtual AC_Daño AC_Daño { get; set; }

        public virtual AC_Persona_Reporta AC_Persona_Reporta { get; set; }

        public virtual AC_Usuario AC_Usuario { get; set; }

        public virtual AC_Zona AC_Zona { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AC_Control_Diario> AC_Control_Diario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AC_Visita_Veterinaria> AC_Visita_Veterinaria { get; set; }
    }
}
