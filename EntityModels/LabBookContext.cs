using System.Windows;
using Microsoft.EntityFrameworkCore;

namespace LabBook_WPF_EF.EntityModels
{
    public partial class LabBookContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }

        public LabBookContext()
        {
        }

        public LabBookContext(DbContextOptions<LabBookContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                _ = optionsBuilder.UseSqlServer(Application.Current.FindResource("ConnectionString").ToString());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users");
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasColumnName("active")
                    .HasDefaultValueSql("('true')");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EMail)
                    .IsRequired()
                    .HasColumnName("e_mail")
                    .HasMaxLength(50);

                entity.Property(e => e.Identifier)
                    .IsRequired()
                    .HasColumnName("identifier")
                    .HasMaxLength(10)
                    .HasComment("first letter of name and surname eg. JB");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasColumnName("login")
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(50);

                entity.Property(e => e.Permission)
                    .IsRequired()
                    .HasColumnName("permission")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('user')");

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasColumnName("surname")
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
