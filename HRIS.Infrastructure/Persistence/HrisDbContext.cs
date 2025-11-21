using HRIS.Domain.Entities.Common;
using HRIS.Domain.Entities.Domain.HRIS;
using HRIS.Domain.Entities.Domain.Lookup;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Infrastructure.Persistence
{
    public class HRISDbContext : DbContext
    {
        public HRISDbContext(DbContextOptions<HRISDbContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<EmployeeIdentification> EmployeeIdentifications => Set<EmployeeIdentification>();
        public DbSet<CivilStatus> CivilStatuses => Set<CivilStatus>();
        public DbSet<IdentificationType> IdentificationTypes => Set<IdentificationType>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Fluent API configurations

            // Employee:
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employees", "hris");

                entity.HasKey(e => e.EmployeeID);

                entity.Property(e => e.EmploymentID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ExtensionName)
                    .HasMaxLength(10);


                entity.Property(e => e.BirthDate)
                    .IsRequired();

                entity.Property(e => e.BirthPlace)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.SexAtBirth)
                    .IsRequired()
                    .HasMaxLength(1);

                // Index
                entity.HasIndex(e => e.EmploymentID)
                    .IsUnique();

                // FKs/Relationships
                entity.HasOne(e => e.CivilStatus)
                      .WithMany(cs => cs.Employees)
                      .HasForeignKey(e => e.CivilStatusID);

                entity.HasMany(e => e.EmployeeIdentifications)
                      .WithOne(ei => ei.Employee)
                      .HasForeignKey(ei => ei.EmployeeID);
            });

            // EmployeeIdentification:
            modelBuilder.Entity<EmployeeIdentification>(entity =>
            {
                entity.ToTable("EmployeeIdentifications", "hris");

                entity.HasKey(ei => ei.EmployeeIdentificationID);

                entity.Property(ei => ei.IdentificationNumber)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(ei => ei.IssuedDate)
                    .IsRequired();

                entity.Property(ei => ei.ExpiredDate)
                    .IsRequired(false);

                entity.Property(ei => ei.IssuedPlace)
                    .IsRequired()
                    .HasMaxLength(150);

                // Index
                entity.HasIndex(ei => new { ei.EmployeeID, ei.IdentificationTypeID })
                      .IsUnique();

                // FKs/Relationships
                entity.HasOne(ei => ei.IdentificationType)
                      .WithMany(it => it.EmployeeIdentifications)
                      .HasForeignKey(ei => ei.IdentificationTypeID);
            });

            // CivilStatus:
            modelBuilder.Entity<CivilStatus>(entity =>
            {
                entity.ToTable("CivilStatuses", "lookup");

                entity.HasKey(cs => cs.CivilStatusID);

                entity.Property(cs => cs.StatusDescription)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(cs => cs.StatusCode)
                    .IsRequired()
                    .HasMaxLength(10);

            });

            // IdentificationType:
            modelBuilder.Entity<IdentificationType>(entity =>
            {
                entity.ToTable("IdentificationTypes", "lookup");

                entity.HasKey(it => it.IdentificationTypeID);

                entity.Property(it => it.Type)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(it => it.Description)
                    .IsRequired()
                    .HasMaxLength(200);
            });


        }


        // Synchronous SaveChanges override to handle audit information
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            ApplyAuditInformation();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override int SaveChanges()
        {
            ApplyAuditInformation();
            return base.SaveChanges();
        }


        // Asynchronous SaveChanges override to handle audit information
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            ApplyAuditInformation();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ApplyAuditInformation();
            return base.SaveChangesAsync(cancellationToken);

        }


        private void ApplyAuditInformation()
        {
            // This method can be used to automatically set audit fields like CreatedDate, ModifiedDate, etc.
            // when entities are added or modified in the DbContext.

            var now = DateTimeOffset.UtcNow;
            var currentUser = "system"; // Replace with actual user context retrieval logic


            foreach (EntityEntry<BaseAuditableEntity> entry in ChangeTracker.Entries<BaseAuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = now;
                        entry.Entity.CreatedBy ??= currentUser; // Replace with actual user ID
                        entry.Entity.IsActive = true;
                        break;
                    case EntityState.Modified:
                        entry.Entity.UpdatedDate = now;
                        entry.Entity.UpdatedBy ??= currentUser; // Replace with actual user ID
                        break;
                    case EntityState.Deleted:
                        entry.Entity.DeletedDate = now;
                        entry.Entity.DeletedBy ??= currentUser; // Replace with actual user ID
                        entry.Entity.IsActive = false;
                        entry.State = EntityState.Modified; // Soft delete
                        break;
                }

            }

        }
    }
}
