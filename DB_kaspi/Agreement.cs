//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DB_kaspi
{
    using System;
    using System.Collections.Generic;
    
    public partial class Agreement
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Agreement()
        {
            this.Credit = new HashSet<Credit>();
            this.Debet = new HashSet<Debet>();
            this.Deposit = new HashSet<Deposit>();
        }
    
        public int ID { get; set; }
        public System.DateTime DateOfIssue { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
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
