using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Lab1_asp.net
{
    public partial class illness_covidContext : DbContext
    {
        public illness_covidContext()
        {
        }

        public illness_covidContext(DbContextOptions<illness_covidContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AdminAccount> AdminAccounts { get; set; } = null!;
        public virtual DbSet<CaseDisease> CaseDiseases { get; set; } = null!;
        public virtual DbSet<CaseType> CaseTypes { get; set; } = null!;
        public virtual DbSet<Country> Countries { get; set; } = null!;
        public virtual DbSet<Person> People { get; set; } = null!;
        public virtual DbSet<Sex> Sexes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server= VLADSFA;\nDatabase = illness_covid; Trusted_Connection = True; ");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdminAccount>(entity =>
            {
                entity.ToTable("admin_account");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.LoginAccount)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("login_account");

                entity.Property(e => e.PasswordAccount)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("password_account");
            });

            modelBuilder.Entity<CaseDisease>(entity =>
            {
                entity.ToTable("case_disease");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CaseDate)
                    .HasColumnType("date")
                    .HasColumnName("case_date");

                entity.Property(e => e.CaseType)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("case_type");

                entity.Property(e => e.CountryName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("country_name");

                entity.Property(e => e.LocalityName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("locality_name");

                entity.Property(e => e.PersonId).HasColumnName("person_id");

                entity.HasOne(d => d.CaseTypeNavigation)
                    .WithMany(p => p.CaseDiseases)
                    .HasForeignKey(d => d.CaseType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__case_dise__case___30F848ED");

                entity.HasOne(d => d.CountryNameNavigation)
                    .WithMany(p => p.CaseDiseases)
                    .HasForeignKey(d => d.CountryName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__case_dise__count__31EC6D26");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.CaseDiseases)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__case_dise__perso__300424B4");
            });

            modelBuilder.Entity<CaseType>(entity =>
            {
                entity.HasKey(e => e.TypeNames)
                    .HasName("PK__case_typ__2B2B98511ECB3F4E");

                entity.ToTable("case_type");

                entity.Property(e => e.TypeNames)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("type_names");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(e => e.CountryName)
                    .HasName("PK__country__F7018895A7B70145");

                entity.ToTable("country");

                entity.Property(e => e.CountryName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("country_name");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("person");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BirthdayDate)
                    .HasColumnType("date")
                    .HasColumnName("birthday_date");

                entity.Property(e => e.CountryName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("country_name");

                entity.Property(e => e.LocalityName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("locality_name");

                entity.Property(e => e.PersonName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("person_name");

                entity.Property(e => e.PersonSurname)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("person_surname");

                entity.Property(e => e.SexName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("sex_name");

                entity.HasOne(d => d.CountryNameNavigation)
                    .WithMany(p => p.People)
                    .HasForeignKey(d => d.CountryName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__person__country___2D27B809");

                entity.HasOne(d => d.SexNameNavigation)
                    .WithMany(p => p.People)
                    .HasForeignKey(d => d.SexName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__person__sex_name__2C3393D0");
            });

            modelBuilder.Entity<Sex>(entity =>
            {
                entity.HasKey(e => e.SexName)
                    .HasName("PK__sex__E6018C1F91F3C79F");

                entity.ToTable("sex");

                entity.Property(e => e.SexName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("sex_name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
