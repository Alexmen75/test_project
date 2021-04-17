namespace Kaspi_BD
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Agreement")]
    public partial class Agreement
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Agreement()
        {
            Credit = new HashSet<Credit>();
            Debet = new HashSet<Debet>();
            Deposit = new HashSet<Deposit>();
        }

        public int ID { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateOfIssue { get; set; }

        [Column(TypeName = "date")]
        public DateTime? EndDate { get; set; }

        public int CustomerID { get; set; }

        public int AccauntID { get; set; }

        public virtual Accaunt Accaunt { get; set; }

        public virtual Customer Customer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Credit> Credit { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Debet> Debet { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Deposit> Deposit { get; set; }
    }
}
