using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureUomUom(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<UomUom>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("uom_uom_pkey");

                        entity.ToTable("uom_uom");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.ParentPath, "uom_uom__parent_path_index");

                        entity.HasIndex(e => e.RelativeUomId, "uom_uom__relative_uom_id_index").HasFilter("(relative_uom_id IS NOT NULL)");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.Active).HasColumnName("active");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.Factor).HasColumnName("factor");
                        entity.Property(e => e.IsPosGroupable).HasColumnName("is_pos_groupable");
                        entity.Property(e => e.Name)
                            .HasColumnType("jsonb")
                            .HasColumnName("name");
                        entity.Property(e => e.PackageTypeId).HasColumnName("package_type_id");
                        entity.Property(e => e.ParentPath).HasColumnName("parent_path");
                        entity.Property(e => e.RelativeFactor).HasColumnName("relative_factor");
                        entity.Property(e => e.RelativeUomId).HasColumnName("relative_uom_id");
                        entity.Property(e => e.Sequence).HasColumnName("sequence");
                        entity.Property(e => e.TimesheetWidget).HasColumnName("timesheet_widget");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.UomUomCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("uom_uom_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("uom_uom_create_uid_fkey");

                        entity.HasOne(d => d.PackageType).WithMany(p => p.UomUom)
                            .HasForeignKey(d => d.PackageTypeId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("uom_uom_package_type_id_fkey");

                        // entity.HasOne(d => d.RelativeUom).WithMany(p => p.InverseRelativeUom) .HasForeignKey(d => d.RelativeUomId) .OnDelete(DeleteBehavior.Cascade) .HasConstraintName("uom_uom_relative_uom_id_fkey");
                        entity.HasOne(d => d.RelativeUom).WithMany()
                            .HasForeignKey(d => d.RelativeUomId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("uom_uom_relative_uom_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.UomUomWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("uom_uom_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("uom_uom_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}