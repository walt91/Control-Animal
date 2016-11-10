namespace Animal_Control.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AC_Articulo_Proveedor
    {
        [Key]
        public int AP_ID { get; set; }

        public int ID_Articulo { get; set; }

        public int ID_Proveedor { get; set; }

        public virtual AC_Articulo AC_Articulo { get; set; }

        public virtual AC_Proveedor AC_Proveedor { get; set; }
    }
}
