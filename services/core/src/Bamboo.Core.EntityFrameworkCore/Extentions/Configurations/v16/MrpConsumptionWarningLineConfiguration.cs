using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureMrpConsumptionWarningLine(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<MrpConsumptionWarningLine>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("mrp_consumption_warning_line_pkey");

                        entity.ToTable("mrp_consumption_warning_line");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("next_uuid()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.MrpConsumptionWarningId).HasColumnName("mrp_consumption_warning_id");
                        entity.Property(e => e.MrpProductionId).HasColumnName("mrp_production_id");
                        entity.Property(e => e.ProductConsumedQtyUom).HasColumnName("product_consumed_qty_uom");
                        entity.Property(e => e.ProductExpectedQtyUom).HasColumnName("product_expected_qty_uom");
                        entity.Property(e => e.ProductId).HasColumnName("product_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.MrpConsumptionWarningLineCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("mrp_consumption_warning_line_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mrp_consumption_warning_line_create_uid_fkey");

                        entity.HasOne(d => d.MrpConsumptionWarning).WithMany(p => p.MrpConsumptionWarningLine)
                            .HasForeignKey(d => d.MrpConsumptionWarningId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("mrp_consumption_warning_line_mrp_consumption_warning_id_fkey");

                        entity.HasOne(d => d.MrpProduction).WithMany(p => p.MrpConsumptionWarningLine)
                            .HasForeignKey(d => d.MrpProductionId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("mrp_consumption_warning_line_mrp_production_id_fkey");

                        // entity.HasOne(d => d.Product).WithMany(p => p.MrpConsumptionWarningLine) .HasForeignKey(d => d.ProductId) .OnDelete(DeleteBehavior.Cascade) .HasConstraintName("mrp_consumption_warning_line_product_id_fkey");
                        entity.HasOne(d => d.Product).WithMany()
                            .HasForeignKey(d => d.ProductId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("mrp_consumption_warning_line_product_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.MrpConsumptionWarningLineWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("mrp_consumption_warning_line_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mrp_consumption_warning_line_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}