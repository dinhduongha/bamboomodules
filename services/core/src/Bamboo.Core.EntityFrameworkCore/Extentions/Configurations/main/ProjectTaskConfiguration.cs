using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureProjectTask(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<ProjectTask>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("project_task_pkey");

                        entity.ToTable("project_task");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.CreationTime, "project_task__create_date_index");

                        entity.HasIndex(e => e.DateDeadline, "project_task__date_deadline_index");

                        entity.HasIndex(e => e.DateEnd, "project_task__date_end_index");

                        entity.HasIndex(e => e.DateLastStageUpdate, "project_task__date_last_stage_update_index");

                        entity.HasIndex(e => e.MilestoneId, "project_task__milestone_id_index").HasFilter("(milestone_id IS NOT NULL)");

                        entity.HasIndex(e => e.Name, "project_task__name_index")
                            .HasMethod("gin")
                            .HasOperators(new[] { "gin_trgm_ops" });

                        entity.HasIndex(e => e.ParentId, "project_task__parent_id_index");

                        entity.HasIndex(e => e.PartnerId, "project_task__partner_id_index").HasFilter("(partner_id IS NOT NULL)");

                        entity.HasIndex(e => e.Priority, "project_task__priority_index");

                        entity.HasIndex(e => e.ProjectId, "project_task__project_id_index");

                        entity.HasIndex(e => e.RecurrenceId, "project_task__recurrence_id_index").HasFilter("(recurrence_id IS NOT NULL)");

                        entity.HasIndex(e => e.SaleLineId, "project_task__sale_line_id_index").HasFilter("(sale_line_id IS NOT NULL)");

                        entity.HasIndex(e => e.StageId, "project_task__stage_id_index");

                        entity.HasIndex(e => e.State, "project_task__state_index");

                        entity.HasIndex(e => e.IsTemplate, "project_task_is_template_idx").HasFilter("(is_template IS TRUE)");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.AccessToken).HasColumnName("access_token");
                        entity.Property(e => e.Active).HasColumnName("active");
                        entity.Property(e => e.AllocatedHours).HasColumnName("allocated_hours");
                        entity.Property(e => e.Color).HasColumnName("color");

                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.DateAssign)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("date_assign");
                        entity.Property(e => e.DateDeadline)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("date_deadline");
                        entity.Property(e => e.DateEnd)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("date_end");
                        entity.Property(e => e.DateLastStageUpdate)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("date_last_stage_update");
                        entity.Property(e => e.Description).HasColumnName("description");
                        entity.Property(e => e.DisplayInProject).HasColumnName("display_in_project");
                        entity.Property(e => e.DisplayedImageId).HasColumnName("displayed_image_id");
                        entity.Property(e => e.EffectiveHours).HasColumnName("effective_hours");
                        entity.Property(e => e.EmailCc).HasColumnName("email_cc");
                        entity.Property(e => e.EmailFrom).HasColumnName("email_from");
                        entity.Property(e => e.HasTemplateAncestor).HasColumnName("has_template_ancestor");
                        entity.Property(e => e.HtmlFieldHistory)
                            .HasColumnType("jsonb")
                            .HasColumnName("html_field_history");
                        entity.Property(e => e.IsTemplate).HasColumnName("is_template");
                        entity.Property(e => e.MilestoneId).HasColumnName("milestone_id");
                        entity.Property(e => e.Name).HasColumnName("name");
                        entity.Property(e => e.Overtime).HasColumnName("overtime");
                        entity.Property(e => e.ParentId).HasColumnName("parent_id");
                        entity.Property(e => e.PartnerCompanyName).HasColumnName("partner_company_name");
                        entity.Property(e => e.PartnerId).HasColumnName("partner_id");
                        entity.Property(e => e.PartnerName).HasColumnName("partner_name");
                        entity.Property(e => e.PartnerPhone).HasColumnName("partner_phone");
                        entity.Property(e => e.Priority).HasColumnName("priority");
                        entity.Property(e => e.Progress).HasColumnName("progress");
                        entity.Property(e => e.ProjectId).HasColumnName("project_id");
                        entity.Property(e => e.RatingLastValue).HasColumnName("rating_last_value");
                        entity.Property(e => e.RecurrenceId).HasColumnName("recurrence_id");
                        entity.Property(e => e.RecurringTask).HasColumnName("recurring_task");
                        entity.Property(e => e.RemainingHours).HasColumnName("remaining_hours");
                        entity.Property(e => e.SaleLineId).HasColumnName("sale_line_id");
                        entity.Property(e => e.SaleOrderId).HasColumnName("sale_order_id");
                        entity.Property(e => e.Sequence).HasColumnName("sequence");
                        entity.Property(e => e.StageId).HasColumnName("stage_id");
                        entity.Property(e => e.State).HasColumnName("state");
                        entity.Property(e => e.SubtaskEffectiveHours).HasColumnName("subtask_effective_hours");
                        entity.Property(e => e.TaskProperties)
                            .HasColumnType("jsonb")
                            .HasColumnName("task_properties");
                        entity.Property(e => e.TotalHoursSpent).HasColumnName("total_hours_spent");
                        entity.Property(e => e.WorkingDaysClose).HasColumnName("working_days_close");
                        entity.Property(e => e.WorkingDaysOpen).HasColumnName("working_days_open");
                        entity.Property(e => e.WorkingHoursClose).HasColumnName("working_hours_close");
                        entity.Property(e => e.WorkingHoursOpen).HasColumnName("working_hours_open");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.Company).WithMany(p => p.ProjectTask) .HasForeignKey(d => d.TenantId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("project_task_company_id_fkey");
                        entity.HasOne(d => d.Company).WithMany()
                            .HasForeignKey(d => d.TenantId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("project_task_company_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.ProjectTaskCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("project_task_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("project_task_create_uid_fkey");

                        // entity.HasOne(d => d.DisplayedImage).WithMany(p => p.ProjectTask) .HasForeignKey(d => d.DisplayedImageId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("project_task_displayed_image_id_fkey");
                        entity.HasOne(d => d.DisplayedImage).WithMany()
                            .HasForeignKey(d => d.DisplayedImageId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("project_task_displayed_image_id_fkey");

                        entity.HasOne(d => d.Milestone).WithMany(p => p.ProjectTask)
                            .HasForeignKey(d => d.MilestoneId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("project_task_milestone_id_fkey");

                        entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent)
                            .HasForeignKey(d => d.ParentId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("project_task_parent_id_fkey");

                        // entity.HasOne(d => d.Partner).WithMany(p => p.ProjectTask) .HasForeignKey(d => d.PartnerId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("project_task_partner_id_fkey");
                        entity.HasOne(d => d.Partner).WithMany()
                            .HasForeignKey(d => d.PartnerId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("project_task_partner_id_fkey");

                        entity.HasOne(d => d.Project).WithMany(p => p.ProjectTask)
                            .HasForeignKey(d => d.ProjectId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("project_task_project_id_fkey");

                        entity.HasOne(d => d.Recurrence).WithMany(p => p.ProjectTask)
                            .HasForeignKey(d => d.RecurrenceId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("project_task_recurrence_id_fkey");

                        entity.HasOne(d => d.SaleLine).WithMany(p => p.ProjectTask)
                            .HasForeignKey(d => d.SaleLineId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("project_task_sale_line_id_fkey");

                        entity.HasOne(d => d.SaleOrder).WithMany(p => p.ProjectTask)
                            .HasForeignKey(d => d.SaleOrderId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("project_task_sale_order_id_fkey");

                        entity.HasOne(d => d.Stage).WithMany(p => p.ProjectTask)
                            .HasForeignKey(d => d.StageId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("project_task_stage_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.ProjectTaskWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("project_task_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("project_task_write_uid_fkey");

                        // entity.HasMany(d => d.DependsOn).WithMany(p => p.Task)
                        entity.HasMany(d => d.DependsOn).WithMany(p => p.Task)
                            .UsingEntity<Dictionary<string, object>>(
                                "TaskDependenciesRel",
                                r => r.HasOne<ProjectTask>().WithMany()
                                    .HasForeignKey("DependsOnId")
                                    .HasConstraintName("task_dependencies_rel_depends_on_id_fkey"),
                                l => l.HasOne<ProjectTask>().WithMany()
                                    .HasForeignKey("TaskId")
                                    .HasConstraintName("task_dependencies_rel_task_id_fkey"),
                                j =>
                                {
                                    j.HasKey("TaskId", "DependsOnId").HasName("task_dependencies_rel_pkey");
                                    j.ToTable("task_dependencies_rel");
                                    j.HasIndex(new[] { "DependsOnId", "TaskId" }, "task_dependencies_rel_depends_on_id_task_id_idx");
                                    j.IndexerProperty<Guid>("TaskId").HasColumnName("task_id");
                                    j.IndexerProperty<Guid>("DependsOnId").HasColumnName("depends_on_id");
                                });

                        // entity.HasMany(d => d.ProjectRole).WithMany(p => p.ProjectTask)
                        entity.HasMany(d => d.ProjectRole).WithMany(p => p.ProjectTask)
                            .UsingEntity<Dictionary<string, object>>(
                                "ProjectRoleProjectTaskRel",
                                r => r.HasOne<ProjectRole>().WithMany()
                                    .HasForeignKey("ProjectRoleId")
                                    .HasConstraintName("project_role_project_task_rel_project_role_id_fkey"),
                                l => l.HasOne<ProjectTask>().WithMany()
                                    .HasForeignKey("ProjectTaskId")
                                    .HasConstraintName("project_role_project_task_rel_project_task_id_fkey"),
                                j =>
                                {
                                    j.HasKey("ProjectTaskId", "ProjectRoleId").HasName("project_role_project_task_rel_pkey");
                                    j.ToTable("project_role_project_task_rel");
                                    j.HasIndex(new[] { "ProjectRoleId", "ProjectTaskId" }, "project_role_project_task_rel_project_role_id_project_task__idx");
                                    j.IndexerProperty<Guid>("ProjectTaskId").HasColumnName("project_task_id");
                                    j.IndexerProperty<Guid>("ProjectRoleId").HasColumnName("project_role_id");
                                });

                        // entity.HasMany(d => d.ProjectTags).WithMany(p => p.ProjectTask)
                        entity.HasMany(d => d.ProjectTags).WithMany(p => p.ProjectTask)
                            .UsingEntity<Dictionary<string, object>>(
                                "ProjectTagsProjectTaskRel",
                                r => r.HasOne<ProjectTags>().WithMany()
                                    .HasForeignKey("ProjectTagsId")
                                    .HasConstraintName("project_tags_project_task_rel_project_tags_id_fkey"),
                                l => l.HasOne<ProjectTask>().WithMany()
                                    .HasForeignKey("ProjectTaskId")
                                    .HasConstraintName("project_tags_project_task_rel_project_task_id_fkey"),
                                j =>
                                {
                                    j.HasKey("ProjectTaskId", "ProjectTagsId").HasName("project_tags_project_task_rel_pkey");
                                    j.ToTable("project_tags_project_task_rel");
                                    j.HasIndex(new[] { "ProjectTagsId", "ProjectTaskId" }, "project_tags_project_task_rel_project_tags_id_project_task__idx");
                                    j.IndexerProperty<Guid>("ProjectTaskId").HasColumnName("project_task_id");
                                    j.IndexerProperty<Guid>("ProjectTagsId").HasColumnName("project_tags_id");
                                });

                        // entity.HasMany(d => d.Task).WithMany(p => p.DependsOn)
                        entity.HasMany(d => d.Task).WithMany(p => p.DependsOn)
                            .UsingEntity<Dictionary<string, object>>(
                                "TaskDependenciesRel",
                                r => r.HasOne<ProjectTask>().WithMany()
                                    .HasForeignKey("TaskId")
                                    .HasConstraintName("task_dependencies_rel_task_id_fkey"),
                                l => l.HasOne<ProjectTask>().WithMany()
                                    .HasForeignKey("DependsOnId")
                                    .HasConstraintName("task_dependencies_rel_depends_on_id_fkey"),
                                j =>
                                {
                                    j.HasKey("TaskId", "DependsOnId").HasName("task_dependencies_rel_pkey");
                                    j.ToTable("task_dependencies_rel");
                                    j.HasIndex(new[] { "DependsOnId", "TaskId" }, "task_dependencies_rel_depends_on_id_task_id_idx");
                                    j.IndexerProperty<Guid>("TaskId").HasColumnName("task_id");
                                    j.IndexerProperty<Guid>("DependsOnId").HasColumnName("depends_on_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}