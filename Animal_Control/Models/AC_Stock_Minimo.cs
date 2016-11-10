namespace Animal_Control.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AC_Stock_Minimo
    {
        [Key]
        public int SMI_ID { get; set; }

        public int ID_Articulo { get; set; }

        public int Cantidad { get; set; }

        public virtual AC_Articulo AC_Articulo { get; set; }
    }
}
