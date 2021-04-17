namespace Kaspi_BD
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Deposit")]
    public partial class Deposit
    {
        public int ID { get; set; }

        public int? AgrID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? StartDate { get; set; }

        [Column(TypeName = "money")]
        public decimal? Amount { get; set; }

        public virtual Agreement Agreement { get; set; }
    }
}
