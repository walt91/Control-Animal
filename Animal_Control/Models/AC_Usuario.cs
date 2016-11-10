namespace Animal_Control.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AC_Usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AC_Usuario()
        {
            AC_Animal = new HashSet<AC_Animal>();
            AC_Control_Diario = new HashSet<AC_Control_Diario>();
            AC_Gastos = new HashSet<AC_Gastos>();
            AC_Ingresos = new HashSet<AC_Ingresos>();
            AC_Liberacion = new HashSet<AC_Liberacion>();
            AC_Visita_Veterinaria = new HashSet<AC_Visita_Veterinaria>();
        }

        [Required (ErrorMessage ="Escribir un correo valido")]
        [EmailAddress (ErrorMessage = "Escribir un correo valido")]
        [StringLength(50)]
        public string Correo { get; set; }

        [Required (ErrorMessage = "Escribir un nombre")]
        [StringLength(250)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Escribir una contraseña")]
        [StringLength(50)]
        public string Contraseña { get; set; }

        [Required]
        [StringLength(50)]
        public string Pais { get; set; }

        [Key]
        public int U_ID { get; set; }

        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AC_Animal> AC_Animal { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AC_Control_Diario> AC_Control_Diario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AC_Gastos> AC_Gastos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AC_Ingresos> AC_Ingresos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AC_Liberacion> AC_Liberacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AC_Visita_Veterinaria> AC_Visita_Veterinaria { get; set; }
    }
}
