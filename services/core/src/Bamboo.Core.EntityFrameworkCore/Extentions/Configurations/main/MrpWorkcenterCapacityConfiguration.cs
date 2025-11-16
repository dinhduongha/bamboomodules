using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureMrpWorkcenterCapacity(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<MrpWorkcenterCapacity>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("mrp_workcenter_capacity_pkey");

                        entity.ToTable("mrp_workcenter_capacity");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.WorkcenterId, "mrp_workcenter_capacity__workcenter_id_index");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.Capacity).HasColumnName("capacity");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.ProductId).HasColumnName("product_id");
                        entity.Property(e => e.ProductUomId).HasColumnName("product_uom_id");
                        entity.Property(e => e.TimeStart).HasColumnName("time_start");
                        entity.Property(e => e.TimeStop).HasColumnName("time_stop");
                        entity.Property(e => e.WorkcenterId).HasColumnName("workcenter_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.MrpWorkcenterCapacityCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("mrp_workcenter_capacity_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mrp_workcenter_capacity_create_uid_fkey");

                        // entity.HasOne(d => d.Product).WithMany(p => p.MrpWorkcenterCapacity) .HasForeignKey(d => d.ProductId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("mrp_workcenter_capacity_product_id_fkey");
                        entity.HasOne(d => d.Product).WithMany()
                            .HasForeignKey(d => d.ProductId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mrp_workcenter_capacity_product_id_fkey");

                        // entity.HasOne(d => d.ProductUom).WithMany(p => p.MrpWorkcenterCapacity) .HasForeignKey(d => d.ProductUomId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("mrp_workcenter_capacity_product_uom_id_fkey");
                        entity.HasOne(d => d.ProductUom).WithMany()
                            .HasForeignKey(d => d.ProductUomId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("mrp_workcenter_capacity_product_uom_id_fkey");

                        entity.HasOne(d => d.Workcenter).WithMany(p => p.MrpWorkcenterCapacity)
                            .HasForeignKey(d => d.WorkcenterId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("mrp_workcenter_capacity_workcenter_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.MrpWorkcenterCapacityWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("mrp_workcenter_capacity_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mrp_workcenter_capacity_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}