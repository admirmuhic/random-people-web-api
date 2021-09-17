using Microsoft.EntityFrameworkCore;

#nullable disable

namespace RandomPeopleWebAPI.Models
{
    public partial class RandomPeopleDbContext : DbContext
    {
        public RandomPeopleDbContext(DbContextOptions<RandomPeopleDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Person> People { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=b38d79xdicnprbjipxnu-mysql.services.clever-cloud.com;port=3306;database=b38d79xdicnprbjipxnu;uid=u6xbf5ivgrunzshu;password=5kj3G17BtNQlDBrVqgDJ;treattinyasboolean=true", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.22-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("address");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.AddressId).HasColumnName("address_id");

                entity.Property(e => e.City)
                    .HasMaxLength(25)
                    .HasColumnName("city");

                entity.Property(e => e.Street)
                    .HasMaxLength(45)
                    .HasColumnName("street");

                entity.Property(e => e.ZipCode)
                    .HasMaxLength(10)
                    .HasColumnName("zip_code");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("person");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_0900_ai_ci");

                entity.HasIndex(e => e.AddressId, "address_id");

                entity.Property(e => e.PersonId).HasColumnName("person_id");

                entity.Property(e => e.AddressId).HasColumnName("address_id");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(45)
                    .HasColumnName("first_name");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.LastName)
                    .HasMaxLength(25)
                    .HasColumnName("last_name");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.People)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("address_id_fk");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
