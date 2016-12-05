namespace Animal_Control.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AC_Articulo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AC_Articulo()
        {
            AC_Articulo_Proveedor = new HashSet<AC_Articulo_Proveedor>();
            AC_Gastos = new HashSet<AC_Gastos>();
            AC_Stock_Maximo = new HashSet<AC_Stock_Maximo>();
            AC_Stock_Minimo = new HashSet<AC_Stock_Minimo>();
        }

        [Key]
        public int A_ID { get; set; }

        [Required(ErrorMessage = "Escriba un Nombre")]
        [StringLength(50)]
        public string Nombre { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AC_Articulo_Proveedor> AC_Articulo_Proveedor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AC_Gastos> AC_Gastos { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AC_Stock_Maximo> AC_Stock_Maximo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AC_Stock_Minimo> AC_Stock_Minimo { get; set; }
    }
}
