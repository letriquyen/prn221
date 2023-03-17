using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Repository.Models
{
    public partial class SafeBuildingContext : DbContext
    {
        public SafeBuildingContext()
        {
        }

        public SafeBuildingContext(DbContextOptions<SafeBuildingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Building> Buildings { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Facility> Facilities { get; set; }
        public virtual DbSet<Flat> Flats { get; set; }
        public virtual DbSet<FlatFacility> FlatFacilities { get; set; }
        public virtual DbSet<FlatType> FlatTypes { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<RentContract> RentContracts { get; set; }
        public virtual DbSet<Service> Services { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(local);uid=sa;pwd=sa12345;database= SafeBuilding;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("admin");

                entity.Property(e => e.Id)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("id");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Fullname)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("fullname");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Phone)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("status");
            });

            modelBuilder.Entity<Building>(entity =>
            {
                entity.ToTable("building");

                entity.Property(e => e.Id)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("status");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customer");

                entity.Property(e => e.Id)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.CitizenId)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("citizen_id");

                entity.Property(e => e.DateJoin)
                    .HasColumnType("date")
                    .HasColumnName("date_join");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnType("date")
                    .HasColumnName("date_of_birth");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Fullname)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("fullname");

                entity.Property(e => e.Gender)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("gender");

                entity.Property(e => e.Phone)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("status");
            });

            modelBuilder.Entity<Facility>(entity =>
            {
                entity.ToTable("facility");

                entity.Property(e => e.Id)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("id");

                entity.Property(e => e.FlatId)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("flat_id");

                entity.Property(e => e.Item)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("item");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.HasOne(d => d.Flat)
                    .WithMany(p => p.Facilities)
                    .HasForeignKey(d => d.FlatId)
                    .HasConstraintName("FKig3pise7ig6nfo2aypnp4mvm");
            });

            modelBuilder.Entity<Flat>(entity =>
            {
                entity.ToTable("flat");

                entity.Property(e => e.Id)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("id");

                entity.Property(e => e.BuildingId)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("building_id");

                entity.Property(e => e.Detail)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("detail");

                entity.Property(e => e.FlatTypeId)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("flat_type_id");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.RoomNumber).HasColumnName("room_number");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.HasOne(d => d.Building)
                    .WithMany(p => p.Flats)
                    .HasForeignKey(d => d.BuildingId)
                    .HasConstraintName("FKcuvibqssnlnlcvkphbl35qud1");

                entity.HasOne(d => d.FlatType)
                    .WithMany(p => p.Flats)
                    .HasForeignKey(d => d.FlatTypeId)
                    .HasConstraintName("FKpyg3bde4wtav173p6punqlvee");
            });

            modelBuilder.Entity<FlatFacility>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("flat_facility");

                entity.Property(e => e.FacilityId)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("facility_id");

                entity.Property(e => e.FlatId)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("flat_id");

                entity.HasOne(d => d.Facility)
                    .WithMany()
                    .HasForeignKey(d => d.FacilityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKn3pl38ks8vgl5cx24kr7fu633");

                entity.HasOne(d => d.Flat)
                    .WithMany()
                    .HasForeignKey(d => d.FlatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKgn03s51bdmobbxd6y4s8boct9");
            });

            modelBuilder.Entity<FlatType>(entity =>
            {
                entity.ToTable("flat_type");

                entity.Property(e => e.Id)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("status");
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.ToTable("invoice");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CustomerId)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("customer_id");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.Electricity)
                    .HasMaxLength(255)
                    .HasColumnName("electricity");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("email");

                entity.Property(e => e.Management)
                    .HasMaxLength(255)
                    .HasColumnName("management");

                entity.Property(e => e.Parking)
                    .HasMaxLength(255)
                    .HasColumnName("parking");

                entity.Property(e => e.Rent)
                    .HasMaxLength(255)
                    .HasColumnName("rent");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .HasColumnName("status");

                entity.Property(e => e.Water)
                    .HasMaxLength(255)
                    .HasColumnName("water");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__invoice__custome__6383C8BA");
            });

            modelBuilder.Entity<RentContract>(entity =>
            {
                entity.ToTable("rent_contract");

                entity.Property(e => e.Id)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("id");

                entity.Property(e => e.Contract)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("contract");

                entity.Property(e => e.CustomerId)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("customer_id");

                entity.Property(e => e.ExpiryDate)
                    .HasColumnType("date")
                    .HasColumnName("expiry_date");

                entity.Property(e => e.FlatId)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("flat_id");

                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasColumnName("start_date");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.Property(e => e.Value).HasColumnName("value");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.RentContracts)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK8s6ylg2rnjswlkpfxrkvc12k");

                entity.HasOne(d => d.Flat)
                    .WithMany(p => p.RentContracts)
                    .HasForeignKey(d => d.FlatId)
                    .HasConstraintName("FKl3lgtukycyujhrn86lnacc5w0");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.ToTable("service");

                entity.Property(e => e.Id)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("status");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
