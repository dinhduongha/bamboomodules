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
        public static void ConfigureProjectTask(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProjectTask>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("project_task_pkey");

                entity.ToTable("project_task");

                entity.HasIndex(e => e.AncestorId, "project_task_ancestor_id_index").HasFilter("(ancestor_id IS NOT NULL)");

                entity.HasIndex(e => e.DateDeadline, "project_task_date_deadline_index");

                entity.HasIndex(e => e.DateEnd, "project_task_date_end_index");

                entity.HasIndex(e => e.DateLastStageUpdate, "project_task_date_last_stage_update_index");

                entity.HasIndex(e => e.DisplayProjectId, "project_task_display_project_id_index");

                entity.HasIndex(e => e.EmailFrom, "project_task_email_from_index")
                    .HasMethod("gin")
                    .HasOperators(new[] { "gin_trgm_ops" });

                entity.HasIndex(e => e.IsClosed, "project_task_is_closed_index");

                entity.HasIndex(e => e.Name, "project_task_name_index")
                    .HasMethod("gin")
                    .HasOperators(new[] { "gin_trgm_ops" });

                entity.HasIndex(e => e.ParentId, "project_task_parent_id_index");

                entity.HasIndex(e => e.Priority, "project_task_priority_index");

                entity.HasIndex(e => e.ProjectId, "project_task_project_id_index");

                entity.HasIndex(e => e.SaleLineId, "project_task_sale_line_id_index").HasFilter("(sale_line_id IS NOT NULL)");

                entity.HasIndex(e => e.StageId, "project_task_stage_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.AccessToken).HasColumnName("access_token");
                entity.Property(e => e.Active).HasColumnName("active");
                entity.Property(e => e.AnalyticAccountId).HasColumnName("analytic_account_id");
                entity.Property(e => e.AncestorId).HasColumnName("ancestor_id");
                entity.Property(e => e.Color).HasColumnName("color");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.DateAssign)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("date_assign");
                entity.Property(e => e.DateDeadline).HasColumnName("date_deadline");
                entity.Property(e => e.DateEnd)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("date_end");
                entity.Property(e => e.DateLastStageUpdate)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("date_last_stage_update");
                entity.Property(e => e.Description).HasColumnName("description");
                entity.Property(e => e.DisplayProjectId).HasColumnName("display_project_id");
                entity.Property(e => e.DisplayedImageId).HasColumnName("displayed_image_id");
                entity.Property(e => e.EmailCc).HasColumnName("email_cc");
                entity.Property(e => e.EmailFrom).HasColumnName("email_from");
                entity.Property(e => e.IsAnalyticAccountIdChanged).HasColumnName("is_analytic_account_id_changed");
                entity.Property(e => e.IsBlocked).HasColumnName("is_blocked");
                entity.Property(e => e.IsClosed).HasColumnName("is_closed");
                entity.Property(e => e.KanbanState).HasColumnName("kanban_state");
                entity.Property(e => e.MessageMainAttachmentId).HasColumnName("message_main_attachment_id");
                entity.Property(e => e.MilestoneId).HasColumnName("milestone_id");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.ParentId).HasColumnName("parent_id");
                entity.Property(e => e.PartnerEmail).HasColumnName("partner_email");
                entity.Property(e => e.PartnerId).HasColumnName("partner_id");
                entity.Property(e => e.PartnerPhone).HasColumnName("partner_phone");
                entity.Property(e => e.PlannedHours).HasColumnName("planned_hours");
                entity.Property(e => e.Priority).HasColumnName("priority");
                entity.Property(e => e.ProjectId).HasColumnName("project_id");
                entity.Property(e => e.RatingLastValue).HasColumnName("rating_last_value");
                entity.Property(e => e.RecurrenceId).HasColumnName("recurrence_id");
                entity.Property(e => e.RecurringTask).HasColumnName("recurring_task");
                entity.Property(e => e.SaleLineId).HasColumnName("sale_line_id");
                entity.Property(e => e.SaleOrderId).HasColumnName("sale_order_id");
                entity.Property(e => e.Sequence)
                    .HasColumnName("sequence");
                entity.Property(e => e.StageId).HasColumnName("stage_id");
                entity.Property(e => e.TaskProperties)
                    .HasColumnType("jsonb")
                    .HasColumnName("task_properties");
                entity.Property(e => e.WorkingDaysClose).HasColumnName("working_days_close");
                entity.Property(e => e.WorkingDaysOpen).HasColumnName("working_days_open");
                entity.Property(e => e.WorkingHoursClose).HasColumnName("working_hours_close");
                entity.Property(e => e.WorkingHoursOpen).HasColumnName("working_hours_open");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne(d => d.AnalyticAccount).WithMany(p => p.ProjectTasks)
                    .HasForeignKey(d => d.AnalyticAccountId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("project_task_analytic_account_id_fkey");

                entity.HasOne(d => d.Ancestor).WithMany(p => p.InverseAncestor)
                    .HasForeignKey(d => d.AncestorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("project_task_ancestor_id_fkey");

                entity.HasOne<ResCompany>().WithMany()
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("project_task_company_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("project_task_create_uid_fkey");

                entity.HasOne(d => d.DisplayProject).WithMany(p => p.ProjectTaskDisplayProjects)
                    .HasForeignKey(d => d.DisplayProjectId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("project_task_display_project_id_fkey");

                entity.HasOne(d => d.DisplayedImage).WithMany(p => p.ProjectTaskDisplayedImages)
                    .HasForeignKey(d => d.DisplayedImageId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("project_task_displayed_image_id_fkey");

                entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.ProjectTaskMessageMainAttachments)
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("project_task_message_main_attachment_id_fkey");

                entity.HasOne(d => d.Milestone).WithMany(p => p.ProjectTasks)
                    .HasForeignKey(d => d.MilestoneId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("project_task_milestone_id_fkey");

                entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("project_task_parent_id_fkey");

                entity.HasOne<ResPartner>().WithMany()
                    .HasForeignKey(d => d.PartnerId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("project_task_partner_id_fkey");

                entity.HasOne(d => d.Project).WithMany(p => p.ProjectTaskProjects)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("project_task_project_id_fkey");

                entity.HasOne(d => d.Recurrence).WithMany(p => p.ProjectTasks)
                    .HasForeignKey(d => d.RecurrenceId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("project_task_recurrence_id_fkey");

                entity.HasOne(d => d.SaleLine).WithMany(p => p.ProjectTasks)
                    .HasForeignKey(d => d.SaleLineId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("project_task_sale_line_id_fkey");

                entity.HasOne(d => d.SaleOrder).WithMany(p => p.ProjectTasks)
                    .HasForeignKey(d => d.SaleOrderId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("project_task_sale_order_id_fkey");

                entity.HasOne(d => d.Stage).WithMany(p => p.ProjectTasks)
                    .HasForeignKey(d => d.StageId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("project_task_stage_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("project_task_write_uid_fkey");

                //entity.HasMany(d => d.DependsOns).WithMany(p => p.Tasks)
                entity.HasMany<ProjectTask>().WithMany()
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
                        });

                //entity.HasMany(d => d.ProjectTags).WithMany(p => p.ProjectTasks)
                entity.HasMany<ProjectTags>().WithMany()
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
                        });

                //entity.HasMany(d => d.Tasks).WithMany(p => p.DependsOns)
                entity.HasMany<ProjectTask>().WithMany()
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
                        });
            });
        }
    }
}