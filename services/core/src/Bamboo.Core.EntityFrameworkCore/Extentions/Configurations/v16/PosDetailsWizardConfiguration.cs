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
        public static void ConfigurePosDetailsWizard(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<PosDetailsWizard>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("pos_details_wizard_pkey");

            entity.ToTable("pos_details_wizard");

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
            entity.Property(e => e.EndDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("end_date");
            entity.Property(e => e.StartDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("start_date");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.PosDetailsWizardCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("pos_details_wizard_create_uid_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.PosDetailsWizardWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("pos_details_wizard_write_uid_fkey");

            // entity.HasMany(d => d.PosConfig).WithMany(p => p.PosDetailsWizard)
            entity.HasMany(d => d.PosConfig).WithMany(p => p.PosDetailsWizard)
                .UsingEntity<Dictionary<string, object>>(
                    "PosDetailConfigs",
                    r => r.HasOne<PosConfig>().WithMany()
                        .HasForeignKey("PosConfigId")
                        .HasConstraintName("pos_detail_configs_pos_config_id_fkey"),
                    l => l.HasOne<PosDetailsWizard>().WithMany()
                        .HasForeignKey("PosDetailsWizardId")
                        .HasConstraintName("pos_detail_configs_pos_details_wizard_id_fkey"),
                    j =>
                    {
                        j.HasKey("PosDetailsWizardId", "PosConfigId").HasName("pos_detail_configs_pkey");
                        j.ToTable("pos_detail_configs");
                        j.HasIndex(new[] { "PosConfigId", "PosDetailsWizardId" }, "pos_detail_configs_pos_config_id_pos_details_wizard_id_idx");
                        j.IndexerProperty<Guid>("PosDetailsWizardId").HasColumnName("pos_details_wizard_id");
                        j.IndexerProperty<Guid>("PosConfigId").HasColumnName("pos_config_id");
                    });
            });
        }
    }
}