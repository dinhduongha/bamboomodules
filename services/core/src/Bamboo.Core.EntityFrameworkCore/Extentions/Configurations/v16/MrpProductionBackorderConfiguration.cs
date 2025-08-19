using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Bamboo.Core.Models;
// Cần thêm using đến namespace chứa entity của bạn ở đây
// Ví dụ: using YourProject.Entities;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureMrpProductionBackorder(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<MrpProductionBackorder>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("mrp_production_backorder_pkey");

            entity.ToTable("mrp_production_backorder");

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
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.MrpProductionBackorderCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("mrp_production_backorder_create_uid_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.MrpProductionBackorderWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("mrp_production_backorder_write_uid_fkey");

            // entity.HasMany(d => d.MrpProduction).WithMany(p => p.MrpProductionBackorder)
            entity.HasMany(d => d.MrpProduction).WithMany(p => p.MrpProductionBackorder)
                .UsingEntity<Dictionary<string, object>>(
                    "MrpProductionMrpProductionBackorderRel",
                    r => r.HasOne<MrpProduction>().WithMany()
                        .HasForeignKey("MrpProductionId")
                        .HasConstraintName("mrp_production_mrp_production_backorder__mrp_production_id_fkey"),
                    l => l.HasOne<MrpProductionBackorder>().WithMany()
                        .HasForeignKey("MrpProductionBackorderId")
                        .HasConstraintName("mrp_production_mrp_production__mrp_production_backorder_id_fkey"),
                    j =>
                    {
                        j.HasKey("MrpProductionBackorderId", "MrpProductionId").HasName("mrp_production_mrp_production_backorder_rel_pkey");
                        j.ToTable("mrp_production_mrp_production_backorder_rel");
                        j.HasIndex(new[] { "MrpProductionId", "MrpProductionBackorderId" }, "mrp_production_mrp_production_mrp_production_id_mrp_product_idx");
                        j.IndexerProperty<Guid>("MrpProductionBackorderId").HasColumnName("mrp_production_backorder_id");
                        j.IndexerProperty<Guid>("MrpProductionId").HasColumnName("mrp_production_id");
                    });
            });
        }
    }
}