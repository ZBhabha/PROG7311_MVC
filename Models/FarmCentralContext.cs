using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace FarmCentralApp.Models
{
    public partial class FarmCentralContext : DbContext
    {
        public FarmCentralContext()
        {
        }

        public FarmCentralContext(DbContextOptions<FarmCentralContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Farmer> Farmers { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-N6L95NC\\ZAHEERA;Initial Catalog=FarmCentral;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.AdminId)
                    .HasName("PK__Employee__59AF14B517A630CE");

                entity.ToTable("Employee");

                entity.Property(e => e.AdminId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ADMIN_ID");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD");
            });

            modelBuilder.Entity<Farmer>(entity =>
            {
                entity.ToTable("Farmer");

                entity.Property(e => e.FarmerId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("FARMER_ID");

                entity.Property(e => e.FarmerName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("FARMER_NAME");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ProductId).HasColumnName("PRODUCT_ID");

                entity.Property(e => e.FarmerId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("FARMER_ID");

                entity.Property(e => e.ProductDate)
                    .HasColumnType("date")
                    .HasColumnName("PRODUCT_DATE");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PRODUCT_NAME");

                entity.Property(e => e.ProductPrice).HasColumnName("PRODUCT_PRICE");

                entity.Property(e => e.ProductQuantity).HasColumnName("PRODUCT_QUANTITY");

                entity.Property(e => e.ProductType)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PRODUCT_TYPE");

                entity.HasOne(d => d.Farmer)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.FarmerId)
                    .HasConstraintName("FK__Products__FARMER__3B75D760");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
