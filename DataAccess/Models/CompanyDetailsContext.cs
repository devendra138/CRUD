using Microsoft.EntityFrameworkCore;

namespace DataAccess.Models
{
    public partial class CompanyDetailsContext : DbContext
    {
        public CompanyDetailsContext()
        {
        }

        public CompanyDetailsContext(DbContextOptions<CompanyDetailsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Designation> Designations { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=desktop-idjhk8u;Database=CompanyDetails;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Designation>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Designation");

                entity.Property(e => e.DesignationId).ValueGeneratedOnAdd();

                entity.Property(e => e.DesignationName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmployeeId);

                entity.ToTable("employee");

                entity.Property(e => e.EmployeeId).ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
