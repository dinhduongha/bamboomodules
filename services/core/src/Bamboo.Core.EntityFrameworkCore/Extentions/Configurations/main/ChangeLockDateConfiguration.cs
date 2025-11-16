using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureChangeLockDate(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<ChangeLockDate>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("change_lock_date_pkey");

                        entity.ToTable("change_lock_date");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");

                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.FiscalyearLockDate).HasColumnName("fiscalyear_lock_date");
                        entity.Property(e => e.HardLockDate).HasColumnName("hard_lock_date");
                        entity.Property(e => e.PurchaseLockDate).HasColumnName("purchase_lock_date");
                        entity.Property(e => e.SaleLockDate).HasColumnName("sale_lock_date");
                        entity.Property(e => e.TaxLockDate).HasColumnName("tax_lock_date");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.Company).WithMany(p => p.ChangeLockDate) .HasForeignKey(d => d.TenantId) .OnDelete(DeleteBehavior.Cascade) .HasConstraintName("change_lock_date_company_id_fkey");
                        entity.HasOne(d => d.Company).WithMany()
                            .HasForeignKey(d => d.TenantId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("change_lock_date_company_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.ChangeLockDateCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("change_lock_date_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("change_lock_date_create_uid_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.ChangeLockDateWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("change_lock_date_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("change_lock_date_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}