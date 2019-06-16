using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace webapi.Models
{
    public partial class lofyContext : DbContext
    {
        public lofyContext()
        {
        }

        public lofyContext(DbContextOptions<lofyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CompanyforPerson> CompanyforPerson { get; set; }
        public virtual DbSet<ContactforPerson> ContactforPerson { get; set; }
        public virtual DbSet<LinkinSystem> LinkinSystem { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<RecipientinLocation> RecipientinLocation { get; set; }
        public virtual DbSet<StockforProductinLocation> StockforProductinLocation { get; set; }
        public virtual DbSet<SupplierinLocation> SupplierinLocation { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=test;database=lofy");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<CompanyforPerson>(entity =>
            {
                entity.ToTable("companyfor_person", "lofy");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.PersonId)
                    .HasColumnName("person_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.CompanyforPerson)
                    .HasPrincipalKey<RecipientinLocation>(p => p.CompanyId)
                    .HasForeignKey<CompanyforPerson>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_companyFor_person_recipientIn_location1");

                entity.HasOne(d => d.Id1)
                    .WithOne(p => p.CompanyforPerson)
                    .HasPrincipalKey<SupplierinLocation>(p => p.CompanyId)
                    .HasForeignKey<CompanyforPerson>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_companyFor_person_supplierIn_location1");
            });

            modelBuilder.Entity<ContactforPerson>(entity =>
            {
                entity.HasKey(e => e.PersonId);

                entity.ToTable("contactfor_person", "lofy");

                entity.Property(e => e.PersonId)
                    .HasColumnName("person_id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LinkinSystem>(entity =>
            {
                entity.HasKey(e => e.System);

                entity.ToTable("linkin_system", "lofy");

                entity.Property(e => e.System)
                    .HasColumnName("system")
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("location", "lofy");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Latitude).HasColumnName("latitude");

                entity.Property(e => e.Longitude).HasColumnName("longitude");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Location)
                    .HasForeignKey<Location>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_location_recipientIn_location1");

                entity.HasOne(d => d.Id1)
                    .WithOne(p => p.Location)
                    .HasPrincipalKey<StockforProductinLocation>(p => p.LocationId)
                    .HasForeignKey<Location>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_location_stockFor_productIn_location1");

                entity.HasOne(d => d.Id2)
                    .WithOne(p => p.Location)
                    .HasForeignKey<Location>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_location_supplierIn_location1");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("person", "lofy");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.First)
                    .IsRequired()
                    .HasColumnName("first")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Person)
                    .HasForeignKey<Person>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_person_companyFor_person1");

                entity.HasOne(d => d.Id1)
                    .WithOne(p => p.Person)
                    .HasForeignKey<Person>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_person_contactFor_person1");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("product", "lofy");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Manufacturer)
                    .IsRequired()
                    .HasColumnName("manufacturer")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Product)
                    .HasForeignKey<Product>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_product_stockFor_productIn_location1");
            });

            modelBuilder.Entity<RecipientinLocation>(entity =>
            {
                entity.HasKey(e => e.LocationId);

                entity.ToTable("recipientin_location", "lofy");

                entity.HasIndex(e => e.CompanyId)
                    .HasName("company_id_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.LocationId)
                    .HasName("location_id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.LocationId)
                    .HasColumnName("location_id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.CompanyId)
                    .HasColumnName("company_id")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<StockforProductinLocation>(entity =>
            {
                entity.HasKey(e => e.ProductId);

                entity.ToTable("stockfor_productin_location", "lofy");

                entity.HasIndex(e => e.LocationId)
                    .HasName("location_id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.ProductId)
                    .HasColumnName("product_id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Count)
                    .HasColumnName("count")
                    .HasColumnType("int(11)");

                entity.Property(e => e.LocationId)
                    .HasColumnName("location_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Price).HasColumnName("price");
            });

            modelBuilder.Entity<SupplierinLocation>(entity =>
            {
                entity.HasKey(e => e.LocationId);

                entity.ToTable("supplierin_location", "lofy");

                entity.HasIndex(e => e.CompanyId)
                    .HasName("company_id_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.LocationId)
                    .HasName("location_id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.LocationId)
                    .HasColumnName("location_id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.CompanyId)
                    .HasColumnName("company_id")
                    .HasColumnType("int(11)");
            });
        }
    }
}
