using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureProjectTaskTypeDeleteWizard(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<ProjectTaskTypeDeleteWizard>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("project_task_type_delete_wizard_pkey");

                        entity.ToTable("project_task_type_delete_wizard");

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

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.ProjectTaskTypeDeleteWizardCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("project_task_type_delete_wizard_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("project_task_type_delete_wizard_create_uid_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.ProjectTaskTypeDeleteWizardWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("project_task_type_delete_wizard_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("project_task_type_delete_wizard_write_uid_fkey");

                        // entity.HasMany(d => d.ProjectProject).WithMany(p => p.ProjectTaskTypeDeleteWizard)
                        entity.HasMany(d => d.ProjectProject).WithMany(p => p.ProjectTaskTypeDeleteWizard)
                            .UsingEntity<Dictionary<string, object>>(
                                "ProjectProjectProjectTaskTypeDeleteWizardRel",
                                r => r.HasOne<ProjectProject>().WithMany()
                                    .HasForeignKey("ProjectProjectId")
                                    .HasConstraintName("project_project_project_task_type_delet_project_project_id_fkey"),
                                l => l.HasOne<ProjectTaskTypeDeleteWizard>().WithMany()
                                    .HasForeignKey("ProjectTaskTypeDeleteWizardId")
                                    .HasConstraintName("project_project_project_task__project_task_type_delete_wiz_fkey"),
                                j =>
                                {
                                    j.HasKey("ProjectTaskTypeDeleteWizardId", "ProjectProjectId").HasName("project_project_project_task_type_delete_wizard_rel_pkey");
                                    j.ToTable("project_project_project_task_type_delete_wizard_rel");
                                    j.HasIndex(new[] { "ProjectProjectId", "ProjectTaskTypeDeleteWizardId" }, "project_project_project_task__project_project_id_project_ta_idx");
                                    j.IndexerProperty<Guid>("ProjectTaskTypeDeleteWizardId").HasColumnName("project_task_type_delete_wizard_id");
                                    j.IndexerProperty<Guid>("ProjectProjectId").HasColumnName("project_project_id");
                                });

                        // entity.HasMany(d => d.ProjectTaskType).WithMany(p => p.ProjectTaskTypeDeleteWizard)
                        entity.HasMany(d => d.ProjectTaskType).WithMany(p => p.ProjectTaskTypeDeleteWizard)
                            .UsingEntity<Dictionary<string, object>>(
                                "ProjectTaskTypeProjectTaskTypeDeleteWizardRel",
                                r => r.HasOne<ProjectTaskType>().WithMany()
                                    .HasForeignKey("ProjectTaskTypeId")
                                    .HasConstraintName("project_task_type_project_task_type_d_project_task_type_id_fkey"),
                                l => l.HasOne<ProjectTaskTypeDeleteWizard>().WithMany()
                                    .HasForeignKey("ProjectTaskTypeDeleteWizardId")
                                    .HasConstraintName("project_task_type_project_tas_project_task_type_delete_wiz_fkey"),
                                j =>
                                {
                                    j.HasKey("ProjectTaskTypeDeleteWizardId", "ProjectTaskTypeId").HasName("project_task_type_project_task_type_delete_wizard_rel_pkey");
                                    j.ToTable("project_task_type_project_task_type_delete_wizard_rel");
                                    j.HasIndex(new[] { "ProjectTaskTypeId", "ProjectTaskTypeDeleteWizardId" }, "project_task_type_project_tas_project_task_type_id_project__idx");
                                    j.IndexerProperty<Guid>("ProjectTaskTypeDeleteWizardId").HasColumnName("project_task_type_delete_wizard_id");
                                    j.IndexerProperty<Guid>("ProjectTaskTypeId").HasColumnName("project_task_type_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}