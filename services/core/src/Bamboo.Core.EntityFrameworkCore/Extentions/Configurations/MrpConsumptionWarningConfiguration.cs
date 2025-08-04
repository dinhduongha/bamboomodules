using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
// TODO: Hãy chắc chắn rằng bạn đã thêm using cho namespace chứa Models của mình ở đây
// Ví dụ: using YourProject.Models;
using Bamboo.Core.Models;
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

                entity.HasIndex(e => e.TenantId, "mrp_consumption_warning_company_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mrp_consumption_warning_create_uid_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mrp_consumption_warning_write_uid_fkey");

                //entity.HasMany(d => d.MrpProductions).WithMany(p => p.MrpConsumptionWarnings)
                entity.HasMany<MrpProduction>().WithMany()
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
                        });
            });
        }
    }
}