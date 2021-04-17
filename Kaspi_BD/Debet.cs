namespace Kaspi_BD
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Debet")]
    public partial class Debet
    {
        public int ID { get; set; }

        public int AgrID { get; set; }

        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }

        public long Code { get; set; }

        public virtual Agreement Agreement { get; set; }
    }
}
