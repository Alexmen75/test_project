namespace Kaspi_BD
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Customer")]
    public partial class Customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            Agreement = new HashSet<Agreement>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(30)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(30)]
        public string SecondName { get; set; }

        [StringLength(30)]
        public string Patronomyc { get; set; }

        [Required]
        [StringLength(20)]
        public string UIN { get; set; }

        [Column(TypeName = "date")]
        public DateTime Birthday { get; set; }

        [StringLength(3)]
        public string Sex { get; set; }

        public int DocumentID { get; set; }

        public int AccaounID { get; set; }

        public virtual Accaunt Accaunt { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Agreement> Agreement { get; set; }

        public virtual Document Document { get; set; }
    }
}
