using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureCrmStage(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<CrmStage>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("crm_stage_pkey");

                        entity.ToTable("crm_stage");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.Color).HasColumnName("color");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.Fold).HasColumnName("fold");
                        entity.Property(e => e.IsWon).HasColumnName("is_won");
                        entity.Property(e => e.Name)
                            .HasColumnType("jsonb")
                            .HasColumnName("name");
                        entity.Property(e => e.Requirements).HasColumnName("requirements");
                        entity.Property(e => e.RottingThresholdDays).HasColumnName("rotting_threshold_days");
                        entity.Property(e => e.Sequence).HasColumnName("sequence");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.CrmStageCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("crm_stage_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("crm_stage_create_uid_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.CrmStageWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("crm_stage_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("crm_stage_write_uid_fkey");

                        // entity.HasMany(d => d.CrmTeam).WithMany(p => p.CrmStage)
                        entity.HasMany(d => d.CrmTeam).WithMany(p => p.CrmStage)
                            .UsingEntity<Dictionary<string, object>>(
                                "CrmStageCrmTeamRel",
                                r => r.HasOne<CrmTeam>().WithMany()
                                    .HasForeignKey("CrmTeamId")
                                    .OnDelete(DeleteBehavior.Restrict)
                                    .HasConstraintName("crm_stage_crm_team_rel_crm_team_id_fkey"),
                                l => l.HasOne<CrmStage>().WithMany()
                                    .HasForeignKey("CrmStageId")
                                    .HasConstraintName("crm_stage_crm_team_rel_crm_stage_id_fkey"),
                                j =>
                                {
                                    j.HasKey("CrmStageId", "CrmTeamId").HasName("crm_stage_crm_team_rel_pkey");
                                    j.ToTable("crm_stage_crm_team_rel");
                                    j.HasIndex(new[] { "CrmTeamId", "CrmStageId" }, "crm_stage_crm_team_rel_crm_team_id_crm_stage_id_idx");
                                    j.IndexerProperty<Guid>("CrmStageId").HasColumnName("crm_stage_id");
                                    j.IndexerProperty<Guid>("CrmTeamId").HasColumnName("crm_team_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}