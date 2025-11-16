using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureProjectProjectStageDeleteWizard(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<ProjectProjectStageDeleteWizard>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("project_project_stage_delete_wizard_pkey");

                        entity.ToTable("project_project_stage_delete_wizard");

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
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.ProjectProjectStageDeleteWizardCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("project_project_stage_delete_wizard_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("project_project_stage_delete_wizard_create_uid_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.ProjectProjectStageDeleteWizardWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("project_project_stage_delete_wizard_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("project_project_stage_delete_wizard_write_uid_fkey");

                        // entity.HasMany(d => d.ProjectProjectStage).WithMany(p => p.ProjectProjectStageDeleteWizard)
                        entity.HasMany(d => d.ProjectProjectStage).WithMany(p => p.ProjectProjectStageDeleteWizard)
                            .UsingEntity<Dictionary<string, object>>(
                                "ProjectProjectStageProjectProjectStageDeleteWizardRel",
                                r => r.HasOne<ProjectProjectStage>().WithMany()
                                    .HasForeignKey("ProjectProjectStageId")
                                    .HasConstraintName("project_project_stage_project_pro_project_project_stage_id_fkey"),
                                l => l.HasOne<ProjectProjectStageDeleteWizard>().WithMany()
                                    .HasForeignKey("ProjectProjectStageDeleteWizardId")
                                    .HasConstraintName("project_project_stage_project_project_project_stage_delete_fkey"),
                                j =>
                                {
                                    j.HasKey("ProjectProjectStageDeleteWizardId", "ProjectProjectStageId").HasName("project_project_stage_project_project_stage_delete_wizard__pkey");
                                    j.ToTable("project_project_stage_project_project_stage_delete_wizard_rel");
                                    j.HasIndex(new[] { "ProjectProjectStageId", "ProjectProjectStageDeleteWizardId" }, "project_project_stage_project_project_project_stage_id_proj_idx");
                                    j.IndexerProperty<Guid>("ProjectProjectStageDeleteWizardId").HasColumnName("project_project_stage_delete_wizard_id");
                                    j.IndexerProperty<Guid>("ProjectProjectStageId").HasColumnName("project_project_stage_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}