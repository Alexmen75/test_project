namespace Kaspi_BD
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Accaunt> Accaunt { get; set; }
        public virtual DbSet<Agreement> Agreement { get; set; }
        public virtual DbSet<Credit> Credit { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Debet> Debet { get; set; }
        public virtual DbSet<Deposit> Deposit { get; set; }
        public virtual DbSet<Document> Document { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Accaunt>()
                .Property(e => e.Balance)
                .IsFixedLength();

            modelBuilder.Entity<Accaunt>()
                .HasMany(e => e.Agreement)
                .WithRequired(e => e.Accaunt)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Accaunt>()
                .HasMany(e => e.Customer)
                .WithRequired(e => e.Accaunt)
                .HasForeignKey(e => e.AccaounID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Agreement>()
                .HasMany(e => e.Credit)
                .WithRequired(e => e.Agreement)
                .HasForeignKey(e => e.AgrID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Agreement>()
                .HasMany(e => e.Debet)
                .WithRequired(e => e.Agreement)
                .HasForeignKey(e => e.AgrID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Agreement>()
                .HasMany(e => e.Deposit)
                .WithOptional(e => e.Agreement)
                .HasForeignKey(e => e.AgrID);

            modelBuilder.Entity<Credit>()
                .Property(e => e.Amount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Agreement)
                .WithRequired(e => e.Customer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Deposit>()
                .Property(e => e.Amount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Document>()
                .HasMany(e => e.Customer)
                .WithRequired(e => e.Document)
                .WillCascadeOnDelete(false);
        }
    }
}
