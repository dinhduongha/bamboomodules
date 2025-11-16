using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureMrpProductionSerials(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<MrpProductionSerials>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("mrp_production_serials_pkey");

                        entity.ToTable("mrp_production_serials");

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
                        entity.Property(e => e.LotName).HasColumnName("lot_name");
                        entity.Property(e => e.LotQuantity).HasColumnName("lot_quantity");
                        entity.Property(e => e.ProductionId).HasColumnName("production_id");
                        entity.Property(e => e.SerialNumbers).HasColumnName("serial_numbers");
                        entity.Property(e => e.WorkorderId).HasColumnName("workorder_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.MrpProductionSerialsCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("mrp_production_serials_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mrp_production_serials_create_uid_fkey");

                        entity.HasOne(d => d.Production).WithMany(p => p.MrpProductionSerials)
                            .HasForeignKey(d => d.ProductionId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mrp_production_serials_production_id_fkey");

                        entity.HasOne(d => d.Workorder).WithMany(p => p.MrpProductionSerials)
                            .HasForeignKey(d => d.WorkorderId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mrp_production_serials_workorder_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.MrpProductionSerialsWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("mrp_production_serials_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mrp_production_serials_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}