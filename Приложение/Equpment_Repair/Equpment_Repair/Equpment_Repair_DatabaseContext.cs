using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Equpment_Repair
{
    public partial class Equpment_Repair_DatabaseContext : DbContext
    {
        public Equpment_Repair_DatabaseContext()
        {
        }

        public Equpment_Repair_DatabaseContext(DbContextOptions<Equpment_Repair_DatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CompletionStage> CompletionStage { get; set; }
        public virtual DbSet<Request> Request { get; set; }
        public virtual DbSet<RequestType> RequestType { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-9R2S8EF\\MYSERVERNAME;Initial Catalog=Equpment_Repair_Database;Persist Security Info=True;User ID=SA;Password=123;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CompletionStage>(entity =>
            {
                entity.ToTable("Completion_Stage");

                entity.HasIndex(e => e.Name)
                    .HasName("UQ__Completi__737584F6EEF70057")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Request>(entity =>
            {
                entity.HasIndex(e => e.Number)
                    .HasName("UQ__Request__78A1A19DFD12FE95")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AddictionDate)
                    .HasColumnName("Addiction_Date")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ClientId).HasColumnName("Client_ID");

                entity.Property(e => e.CompletionStageId).HasColumnName("Completion_Stage_ID");

                entity.Property(e => e.EmployeeId).HasColumnName("Employee_ID");

                entity.Property(e => e.Equpment)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.MalfunctionType)
                    .IsRequired()
                    .HasColumnName("Malfunction_Type")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProblemDescription)
                    .IsRequired()
                    .HasColumnName("Problem_Description")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.RequestTypeId).HasColumnName("Request_Type_ID");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.RequestClient)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Request__Client___6C190EBB");

                entity.HasOne(d => d.CompletionStage)
                    .WithMany(p => p.Request)
                    .HasForeignKey(d => d.CompletionStageId)
                    .HasConstraintName("FK__Request__Complet__6EF57B66");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.RequestEmployee)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__Request__Employe__6D0D32F4");

                entity.HasOne(d => d.RequestType)
                    .WithMany(p => p.Request)
                    .HasForeignKey(d => d.RequestTypeId)
                    .HasConstraintName("FK__Request__Request__6E01572D");
            });

            modelBuilder.Entity<RequestType>(entity =>
            {
                entity.ToTable("Request_Type");

                entity.HasIndex(e => e.Name)
                    .HasName("UQ__Request___737584F602F0D5AE")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("UQ__Role__737584F62D8A521B")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Login)
                    .HasName("UQ__User__5E55825B1631B29F")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId).HasColumnName("Role_ID");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__User__Role_ID__6754599E");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
