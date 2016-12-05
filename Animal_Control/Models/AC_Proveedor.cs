namespace Animal_Control.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AC_Proveedor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AC_Proveedor()
        {
            AC_Articulo_Proveedor = new HashSet<AC_Articulo_Proveedor>();
        }

        [Key]
        public int P_ID { get; set; }

        [Required(ErrorMessage = "Escriba el nombre")]
        [StringLength(100)]
        public string Nombre { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AC_Articulo_Proveedor> AC_Articulo_Proveedor { get; set; }
    }
}
