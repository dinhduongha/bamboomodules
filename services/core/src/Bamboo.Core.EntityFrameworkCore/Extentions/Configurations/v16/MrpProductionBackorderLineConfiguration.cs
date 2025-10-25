using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureMrpProductionBackorderLine(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<MrpProductionBackorderLine>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("mrp_production_backorder_line_pkey");

                        entity.ToTable("mrp_production_backorder_line");

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
                        entity.Property(e => e.MrpProductionBackorderId).HasColumnName("mrp_production_backorder_id");
                        entity.Property(e => e.MrpProductionId).HasColumnName("mrp_production_id");
                        entity.Property(e => e.ToBackorder).HasColumnName("to_backorder");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.MrpProductionBackorderLineCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("mrp_production_backorder_line_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mrp_production_backorder_line_create_uid_fkey");

                        entity.HasOne(d => d.MrpProductionBackorder).WithMany(p => p.MrpProductionBackorderLine)
                            .HasForeignKey(d => d.MrpProductionBackorderId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("mrp_production_backorder_line_mrp_production_backorder_id_fkey");

                        entity.HasOne(d => d.MrpProduction).WithMany(p => p.MrpProductionBackorderLine)
                            .HasForeignKey(d => d.MrpProductionId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("mrp_production_backorder_line_mrp_production_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.MrpProductionBackorderLineWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("mrp_production_backorder_line_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mrp_production_backorder_line_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}