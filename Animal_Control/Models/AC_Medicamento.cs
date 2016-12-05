namespace Animal_Control.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AC_Medicamento
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AC_Medicamento()
        {
            AC_Control_Diario = new HashSet<AC_Control_Diario>();
        }

        [Key]
        public int M_ID { get; set; }

        [Required(ErrorMessage = "Escriba el nombre")]
        [StringLength(50)]
        public string Nombre { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AC_Control_Diario> AC_Control_Diario { get; set; }
    }
}
