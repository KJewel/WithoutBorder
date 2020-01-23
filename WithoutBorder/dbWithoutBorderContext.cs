using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WithoutBorder
{
    public partial class dbWithoutBorderContext : DbContext
    {
        public dbWithoutBorderContext()
        {
        }

        public dbWithoutBorderContext(DbContextOptions<dbWithoutBorderContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TBonus> TBonus { get; set; }
        public virtual DbSet<TContract> TContract { get; set; }
        public virtual DbSet<TDevice> TDevice { get; set; }
        public virtual DbSet<TInfoDevice> TInfoDevice { get; set; }
        public virtual DbSet<TManufacture> TManufacture { get; set; }
        public virtual DbSet<TRole> TRole { get; set; }
        public virtual DbSet<TSpec> TSpec { get; set; }
        public virtual DbSet<TTarif> TTarif { get; set; }
        public virtual DbSet<TTypeDevice> TTypeDevice { get; set; }
        public virtual DbSet<TUsers> TUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-C840JGG\\SQLEXPRESS;Database=dbWithoutBorder;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TBonus>(entity =>
            {
                entity.ToTable("tBonus");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.PercentBonus).HasColumnName("percentBonus");
            });

            modelBuilder.Entity<TContract>(entity =>
            {
                entity.ToTable("tContract");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ConlusionDate)
                    .HasColumnName("conlusionDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdBonus).HasColumnName("idBonus");

                entity.Property(e => e.IdDevice).HasColumnName("idDevice");

                entity.Property(e => e.IdOperator).HasColumnName("idOperator");

                entity.Property(e => e.IdTarif).HasColumnName("idTarif");

                entity.Property(e => e.IdUser).HasColumnName("idUser");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.HasOne(d => d.IdBonusNavigation)
                    .WithMany(p => p.TContract)
                    .HasForeignKey(d => d.IdBonus)
                    .HasConstraintName("FK_tContract_tBonus");

                entity.HasOne(d => d.IdDeviceNavigation)
                    .WithMany(p => p.TContract)
                    .HasForeignKey(d => d.IdDevice)
                    .HasConstraintName("FK_tContract_tDevice");

                entity.HasOne(d => d.IdOperatorNavigation)
                    .WithMany(p => p.TContractIdOperatorNavigation)
                    .HasForeignKey(d => d.IdOperator)
                    .HasConstraintName("FK_tContract_tUsers1");

                entity.HasOne(d => d.IdTarifNavigation)
                    .WithMany(p => p.TContract)
                    .HasForeignKey(d => d.IdTarif)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tContract_tTarif");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.TContractIdUserNavigation)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tContract_tUsers");
            });

            modelBuilder.Entity<TDevice>(entity =>
            {
                entity.ToTable("tDevice");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdManufacture).HasColumnName("idManufacture");

                entity.Property(e => e.IdTypeDevice).HasColumnName("idTypeDevice");

                entity.Property(e => e.Image)
                    .IsRequired()
                    .HasColumnName("image");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.Price).HasColumnName("price");

                entity.HasOne(d => d.IdManufactureNavigation)
                    .WithMany(p => p.TDevice)
                    .HasForeignKey(d => d.IdManufacture)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tDevice_tManufacture");

                entity.HasOne(d => d.IdTypeDeviceNavigation)
                    .WithMany(p => p.TDevice)
                    .HasForeignKey(d => d.IdTypeDevice)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tDevice_tTypeDevice");
            });
            
            modelBuilder.Entity<TInfoDevice>(entity =>
            {
                entity.ToTable("tInfoDevice");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.TInfoDevice)
                    .HasForeignKey<TInfoDevice>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tInfoDevice_tDevice");
            });

            modelBuilder.Entity<TManufacture>(entity =>
            {
                entity.ToTable("tManufacture");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TRole>(entity =>
            {
                entity.ToTable("tRole");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TSpec>(entity =>
            {
                entity.HasKey(e => e.IdUser);

                entity.ToTable("tSpec");

                entity.Property(e => e.IdUser)
                    .HasColumnName("idUser")
                    .ValueGeneratedNever();

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdUserNavigation)
                    .WithOne(p => p.TSpec)
                    .HasForeignKey<TSpec>(d => d.IdUser)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_tSpec_tUsers");
            });

            modelBuilder.Entity<TTarif>(entity =>
            {
                entity.ToTable("tTarif");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.Price).HasColumnName("price");
            });

            modelBuilder.Entity<TTypeDevice>(entity =>
            {
                entity.ToTable("tTypeDevice");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TUsers>(entity =>
            {
                entity.HasKey(e => e.IdUser);

                entity.ToTable("tUsers");

                entity.Property(e => e.IdUser).HasColumnName("idUser");

                entity.Property(e => e.IdRole).HasColumnName("idRole");

                entity.Property(e => e.Login)
                    .HasColumnName("login")
                    .HasMaxLength(50);

                entity.Property(e => e.Middlename)
                    .HasColumnName("middlename")
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.PassportNumber).HasColumnName("passportNumber");

                entity.Property(e => e.PassportSeria).HasColumnName("passportSeria");

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(50);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasColumnName("surname")
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdRoleNavigation)
                    .WithMany(p => p.TUsers)
                    .HasForeignKey(d => d.IdRole)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_tUsers_tRole");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
