using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Indocement_RESTFullAPI.Models;

public partial class IndocementDbContext : DbContext
{
    public IndocementDbContext()
    {
    }

    public IndocementDbContext(DbContextOptions<IndocementDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bpjs> Bpjs { get; set; }

    public virtual DbSet<Cache> Caches { get; set; }

    public virtual DbSet<CacheLock> CacheLocks { get; set; }

    public virtual DbSet<Departement> Departements { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Esl> Esls { get; set; }

    public virtual DbSet<FailedJob> FailedJobs { get; set; }

    public virtual DbSet<FamilyEmployee> FamilyEmployees { get; set; }

    public virtual DbSet<IdCard> IdCards { get; set; }

    public virtual DbSet<Job> Jobs { get; set; }

    public virtual DbSet<JobBatch> JobBatches { get; set; }

    public virtual DbSet<Keluhan> Keluhans { get; set; }

    public virtual DbSet<Konsultasi> Konsultasis { get; set; }

    public virtual DbSet<Migration> Migrations { get; set; }

    public virtual DbSet<PasswordResetToken> PasswordResetTokens { get; set; }

    public virtual DbSet<PlantDivision> PlantDivisions { get; set; }

    public virtual DbSet<Section> Sections { get; set; }

    public virtual DbSet<Session> Sessions { get; set; }

    public virtual DbSet<Unit> Units { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public override int SaveChanges()
    {
        SetTimestamps();
        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        SetTimestamps();
        return base.SaveChangesAsync(cancellationToken);
    }

    private void SetTimestamps()
    {
        var now = DateTime.Now;

        foreach (var entry in ChangeTracker.Entries())
        {
            switch (entry.Entity)
            {
                case Unit p:
                    if (entry.State == EntityState.Added && !p.CreatedAt.HasValue)
                        p.CreatedAt = now;
                    if (entry.State == EntityState.Added || entry.State == EntityState.Modified)
                        p.UpdatedAt = now;
                    break;

                case PlantDivision c:
                    if (entry.State == EntityState.Added && !c.CreatedAt.HasValue)
                        c.CreatedAt = now;
                    if (entry.State == EntityState.Added || entry.State == EntityState.Modified)
                        c.UpdatedAt = now;
                    break;

                case Departement c:
                    if (entry.State == EntityState.Added && !c.CreatedAt.HasValue)
                        c.CreatedAt = now;
                    if (entry.State == EntityState.Added || entry.State == EntityState.Modified)
                        c.UpdatedAt = now;
                    break;

                case Section c:
                    if (entry.State == EntityState.Added && !c.CreatedAt.HasValue)
                        c.CreatedAt = now;
                    if (entry.State == EntityState.Added || entry.State == EntityState.Modified)
                        c.UpdatedAt = now;
                    break;

                case Esl c:
                    if (entry.State == EntityState.Added && !c.CreatedAt.HasValue)
                        c.CreatedAt = now;
                    if (entry.State == EntityState.Added || entry.State == EntityState.Modified)
                        c.UpdatedAt = now;
                    break;

                case Employee c:
                    if (entry.State == EntityState.Added && !c.CreatedAt.HasValue)
                        c.CreatedAt = now;
                    if (entry.State == EntityState.Added || entry.State == EntityState.Modified)
                        c.UpdatedAt = now;
                    break;

                case User c:
                    if (entry.State == EntityState.Added && !c.CreatedAt.HasValue)
                        c.CreatedAt = now;
                    if (entry.State == EntityState.Added || entry.State == EntityState.Modified)
                        c.UpdatedAt = now;
                    break;
            }
        }
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=SMKN1CBN-6\\MSSQLSERVER01;Database=indocement;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bpjs>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_bpjs_id");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.AnakKe).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.UrlAkteLahir).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.UrlKk).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.UrlSuratNikah).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.UrlSuratPotongGaji).HasDefaultValueSql("(NULL)");

            entity.HasOne(d => d.IdEmployeeNavigation).WithMany(p => p.Bpjs).HasConstraintName("bpjs$bpjs_id_employee_foreign");
        });

        modelBuilder.Entity<Cache>(entity =>
        {
            entity.HasKey(e => e.Key).HasName("PK_cache_key");
        });

        modelBuilder.Entity<CacheLock>(entity =>
        {
            entity.HasKey(e => e.Key).HasName("PK_cache_locks_key");
        });

        modelBuilder.Entity<Departement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_departement_id");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(NULL)");

            entity.HasOne(d => d.IdPlantDivisionNavigation).WithMany(p => p.Departements).HasConstraintName("departement$departement_id_plant_division_foreign");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_employee_id");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.LivingArea).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.Telepon).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.UrlFoto).HasDefaultValueSql("(NULL)");

            entity.HasOne(d => d.IdEslNavigation).WithMany(p => p.Employees).HasConstraintName("employee$employee_id_esl_foreign");

            entity.HasOne(d => d.IdSectionNavigation).WithMany(p => p.Employees).HasConstraintName("employee$employee_id_section_foreign");
        });

        modelBuilder.Entity<Esl>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_esl_id");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(NULL)");
        });

        modelBuilder.Entity<FailedJob>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_failed_jobs_id");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.FailedAt).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<FamilyEmployee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_family_employee_id");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.AlamatAyah).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.AlamatAyahMertua).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.AlamatIbu).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.AlamatIbuMertua).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.AlamatPasangan).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.FotoAyah).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.FotoAyahMertua).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.FotoIbu).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.FotoIbuMertua).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.FotoPasangan).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.TeleponAyah).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.TeleponAyahMertua).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.TeleponIbu).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.TeleponIbuMertua).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.TeleponPasangan).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(NULL)");

            entity.HasOne(d => d.IdEmployeeNavigation).WithMany(p => p.FamilyEmployees).HasConstraintName("family_employee$family_employee_id_employee_foreign");
        });

        modelBuilder.Entity<IdCard>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_id_card_id");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.UrlCardRusak).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.UrlSuratKehilangan).HasDefaultValueSql("(NULL)");

            entity.HasOne(d => d.IdEmployeeNavigation).WithMany(p => p.IdCards).HasConstraintName("id_card$id_card_id_employee_foreign");
        });

        modelBuilder.Entity<Job>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_jobs_id");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.ReservedAt).HasDefaultValueSql("(NULL)");
        });

        modelBuilder.Entity<JobBatch>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_job_batches_id");

            entity.Property(e => e.CancelledAt).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.FinishedAt).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.Options).HasDefaultValueSql("(NULL)");
        });

        modelBuilder.Entity<Keluhan>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_keluhan_id");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.Keluhan1).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(NULL)");

            entity.HasOne(d => d.IdEmployeeNavigation).WithMany(p => p.Keluhans).HasConstraintName("keluhan$keluhan_id_employee_foreign");
        });

        modelBuilder.Entity<Konsultasi>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_konsultasi_id");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.Konsultasi1).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(NULL)");

            entity.HasOne(d => d.IdEmployeeNavigation).WithMany(p => p.Konsultasis).HasConstraintName("konsultasi$konsultasi_id_employee_foreign");
        });

        modelBuilder.Entity<Migration>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_migrations_id");
        });

        modelBuilder.Entity<PasswordResetToken>(entity =>
        {
            entity.HasKey(e => e.Email).HasName("PK_password_reset_tokens_email");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(NULL)");
        });

        modelBuilder.Entity<PlantDivision>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_plant_division_id");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(NULL)");

            entity.HasOne(d => d.IdUnitNavigation).WithMany(p => p.PlantDivisions).HasConstraintName("plant_division$plant_division_id_unit_foreign");
        });

        modelBuilder.Entity<Section>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_section_id");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(NULL)");

            entity.HasOne(d => d.IdDepartementNavigation).WithMany(p => p.Sections).HasConstraintName("section$section_id_departement_foreign");
        });

        modelBuilder.Entity<Session>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_sessions_id");

            entity.Property(e => e.IpAddress).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.UserAgent).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.UserId).HasDefaultValueSql("(NULL)");
        });

        modelBuilder.Entity<Unit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_unit_id");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(NULL)");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_users_id");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.EmailVerifiedAt).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.RememberToken).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(NULL)");

            entity.HasOne(d => d.IdEmployeeNavigation).WithMany(p => p.Users).HasConstraintName("users$users_id_employee_foreign");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
