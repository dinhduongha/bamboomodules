using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureHrWorkLocation(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<HrWorkLocation>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("hr_work_location_pkey");

                        entity.ToTable("hr_work_location");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.Active).HasColumnName("active");
                        entity.Property(e => e.AddressId).HasColumnName("address_id");

                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.LocationNumber).HasColumnName("location_number");
                        entity.Property(e => e.LocationType).HasColumnName("location_type");
                        entity.Property(e => e.Name).HasColumnName("name");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.Address).WithMany(p => p.HrWorkLocation) .HasForeignKey(d => d.AddressId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("hr_work_location_address_id_fkey");
                        entity.HasOne(d => d.Address).WithMany()
                            .HasForeignKey(d => d.AddressId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("hr_work_location_address_id_fkey");

                        // entity.HasOne(d => d.Company).WithMany(p => p.HrWorkLocation) .HasForeignKey(d => d.TenantId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("hr_work_location_company_id_fkey");
                        entity.HasOne(d => d.Company).WithMany()
                            .HasForeignKey(d => d.TenantId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("hr_work_location_company_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.HrWorkLocationCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("hr_work_location_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_work_location_create_uid_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.HrWorkLocationWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("hr_work_location_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_work_location_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}