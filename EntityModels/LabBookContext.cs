using System.Windows;
using Microsoft.EntityFrameworkCore;

namespace LabBook_WPF_EF.EntityModels
{
    public partial class LabBookContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Material> Materials { get; set; }
        public virtual DbSet<ClpSignalWord> ClpSignalWords { get; set; }
        public virtual DbSet<Currency> Currencies { get; set; }
        public virtual DbSet<Unit> Units { get; set; }
        public virtual DbSet<MaterialFunction> MaterialFunctions { get; set; }
        public virtual DbSet<ClpGHS> ClpGHs { get; set; }
        public virtual DbSet<ClpPhraseHP> ClpPhraseHPs { get; set; }
        public virtual DbSet<MaterialJoinGHS> MaterialGHs { get; set; }
        public virtual DbSet<MaterialJoinHP> MaterialJoinHPs { get; set; }

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

            modelBuilder.Entity<Currency>(entity =>
            {
                entity.ToTable("CmbCurrency");
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(20);

                entity.Property(e => e.Rate)
                    .IsRequired()
                    .HasColumnName("rate")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.DateCreated)
                    .HasColumnName("date_created")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Unit>(entity =>
            {
                entity.ToTable("CmbUnit");
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ClpSignalWord>(entity =>
            {
                entity.ToTable("CmbClpSignalWord");
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ClpGHS>(entity =>
            {
                entity.ToTable("CmbClpPictogram");
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(50);

                entity.Property(e => e.GHS).HasColumnName("ghs");

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasColumnName("png_file")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ClpPhraseHP>(entity =>
            {
                entity.ToTable("CmbClpHP");
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DangerClass)
                    .IsRequired()
                    .HasColumnName("class")
                    .HasMaxLength(50);

                entity.Property(e => e.Phrase)
                    .IsRequired()
                    .HasColumnName("clp")
                    .HasMaxLength(50);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(500);

                entity.Property(e => e.PhraseOrder).HasColumnName("ordering");

                entity.Property(e => e.IsPhraseH)
                    .IsRequired()
                    .HasColumnName("is_h")
                    .HasDefaultValueSql("('true')");

                entity.Property(e => e.GhsId)
                    .HasColumnName("ghs_id")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ClpSignalWordId)
                    .HasColumnName("signal_id")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DateCreated)
                    .HasColumnName("date_created")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.ClpGHS)
                    .WithMany(p => p.ClpPhraseHpList)
                    .HasForeignKey(d => d.GhsId)
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(d => d.ClpSignalWord)
                    .WithMany(p => p.ClpPhraseHpList)
                    .HasForeignKey(d => d.ClpSignalWordId)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<MaterialJoinGHS>(entity =>
            {
                entity.ToTable("MaterialGHS");
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.MaterialId).HasColumnName("material_id");
                entity.Property(e => e.GhsId).HasColumnName("ghs_id");

                entity.Property(e => e.DateCreated)
                    .HasColumnName("date_created")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Material)
                    .WithMany(p => p.MaterialJoinGhsList)
                    .HasForeignKey(d => d.MaterialId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.ClpGHS)
                    .WithMany(p => p.MaterialGhslist)
                    .HasForeignKey(d => d.GhsId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<MaterialJoinHP>(entity =>
            {
                entity.ToTable("MaterialCLP");
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.MaterialId).HasColumnName("material_id");
                entity.Property(e => e.HpId).HasColumnName("clp_id");

                entity.Property(e => e.DateCreated)
                    .HasColumnName("date_created")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Material)
                    .WithMany(p => p.MaterialJoinHpList)
                    .HasForeignKey(d => d.MaterialId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.ClpPhraseHP)
                    .WithMany(p => p.MaterialJoinHpList)
                    .HasForeignKey(d => d.HpId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<MaterialFunction>(entity =>
            {
                entity.ToTable("CmbMaterialFunction");
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.DateCreated)
                    .HasColumnName("date_created")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Material>(entity =>
            {
                entity.ToTable("Material");
                entity.Ignore(e => e.Modified);

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100);

                entity.Property(e => e.IsIntermadiate)
                    .IsRequired()
                    .HasColumnName("is_intermediate")
                    .HasDefaultValueSql("('false')");

                entity.Property(e => e.IsDanger)
                    .IsRequired()
                    .HasColumnName("is_danger")
                    .HasDefaultValueSql("('false')");

                entity.Property(e => e.IsProduction)
                    .IsRequired()
                    .HasColumnName("is_production")
                    .HasDefaultValueSql("('false')");

                entity.Property(e => e.IsObserved)
                    .IsRequired()
                    .HasColumnName("is_observed")
                    .HasDefaultValueSql("('false')");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("is_active")
                    .HasDefaultValueSql("('false')");

                entity.Property(e => e.IntermediateNrD)
                    .HasColumnName("intermediate_nrD")
                    .HasDefaultValueSql("((-1))");

                entity.Property(e => e.ClpSignalWordId)
                    .HasColumnName("clp_signal_word_id")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ClpMsdsId)
                    .HasColumnName("clp_msds_id")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.FunctionId)
                    .HasColumnName("function_id")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Price).HasColumnName("price");
                entity.Property(e => e.Density).HasColumnName("density");
                entity.Property(e => e.Solids).HasColumnName("solids");
                entity.Property(e => e.Ash450).HasColumnName("ash_450");
                entity.Property(e => e.VOC).HasColumnName("VOC");
                entity.Property(e => e.Remarks).HasColumnName("remarks").HasMaxLength(2000);

                entity.Property(e => e.CurrencyId)
                    .HasColumnName("currency_id")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.UnitId)
                    .HasColumnName("unit_id")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LoginId)
                    .HasColumnName("login_id")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DateCreated)
                    .HasColumnName("date_created")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateUpdate)
                    .HasColumnName("date_update")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.User)
                    .WithMany(d => d.MaterialList)
                    .HasForeignKey(d => d.LoginId)
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(d => d.ClpSignalWord)
                    .WithMany(p => p.MaterialList)
                    .HasForeignKey(d => d.ClpSignalWordId)
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(d => d.MaterialFunction)
                    .WithMany(p => p.MaterialList)
                    .HasForeignKey(d => d.FunctionId)
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(d => d.Currency)
                    .WithMany(p => p.MaterialList)
                    .HasForeignKey(d => d.CurrencyId)
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.MaterialList)
                    .HasForeignKey(d => d.UnitId)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
