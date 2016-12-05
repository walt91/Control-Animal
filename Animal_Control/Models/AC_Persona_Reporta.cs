namespace Animal_Control.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AC_Persona_Reporta
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AC_Persona_Reporta()
        {
            AC_Animal = new HashSet<AC_Animal>();
        }

        [Key]
        public int PR_ID { get; set; }

        [Required(ErrorMessage = "Escriba un nombre")]
        [StringLength(150)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Escriba la cedula")]
        [StringLength(50)]
        public string Cedula { get; set; }

        [Required]
        [StringLength(50)]
        public string Telefono { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AC_Animal> AC_Animal { get; set; }
    }
}
