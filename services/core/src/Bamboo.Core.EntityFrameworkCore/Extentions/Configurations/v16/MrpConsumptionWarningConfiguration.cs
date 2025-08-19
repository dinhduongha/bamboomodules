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
        public static void ConfigureMrpConsumptionWarning(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<MrpConsumptionWarning>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("mrp_consumption_warning_pkey");

            entity.ToTable("mrp_consumption_warning");

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

            // entity.HasOne(d => d.CreateU).WithMany(p => p.MrpConsumptionWarningCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("mrp_consumption_warning_create_uid_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.MrpConsumptionWarningWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("mrp_consumption_warning_write_uid_fkey");

            // entity.HasMany(d => d.MrpProduction).WithMany(p => p.MrpConsumptionWarning)
            entity.HasMany(d => d.MrpProduction).WithMany(p => p.MrpConsumptionWarning)
                .UsingEntity<Dictionary<string, object>>(
                    "MrpConsumptionWarningMrpProductionRel",
                    r => r.HasOne<MrpProduction>().WithMany()
                        .HasForeignKey("MrpProductionId")
                        .HasConstraintName("mrp_consumption_warning_mrp_production_r_mrp_production_id_fkey"),
                    l => l.HasOne<MrpConsumptionWarning>().WithMany()
                        .HasForeignKey("MrpConsumptionWarningId")
                        .HasConstraintName("mrp_consumption_warning_mrp_pro_mrp_consumption_warning_id_fkey"),
                    j =>
                    {
                        j.HasKey("MrpConsumptionWarningId", "MrpProductionId").HasName("mrp_consumption_warning_mrp_production_rel_pkey");
                        j.ToTable("mrp_consumption_warning_mrp_production_rel");
                        j.HasIndex(new[] { "MrpProductionId", "MrpConsumptionWarningId" }, "mrp_consumption_warning_mrp_p_mrp_production_id_mrp_consump_idx");
                        j.IndexerProperty<Guid>("MrpConsumptionWarningId").HasColumnName("mrp_consumption_warning_id");
                        j.IndexerProperty<Guid>("MrpProductionId").HasColumnName("mrp_production_id");
                    });
            });
        }
    }
}