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
        public static void ConfigureProjectProject(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProjectProject>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("project_project_pkey");

                entity.ToTable("project_project");

                entity.HasIndex(e => e.Date, "project_project_date_index");

                entity.HasIndex(e => e.SaleLineId, "project_project_sale_line_id_index").HasFilter("(sale_line_id IS NOT NULL)");

                entity.HasIndex(e => e.StageId, "project_project_stage_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.AccessToken).HasColumnName("access_token");
                entity.Property(e => e.Active).HasColumnName("active");
                entity.Property(e => e.AliasId).HasColumnName("alias_id");
                entity.Property(e => e.AllowBillable).HasColumnName("allow_billable");
                entity.Property(e => e.AllowMilestones).HasColumnName("allow_milestones");
                entity.Property(e => e.AllowRecurringTasks).HasColumnName("allow_recurring_tasks");
                entity.Property(e => e.AllowSubtasks).HasColumnName("allow_subtasks");
                entity.Property(e => e.AllowTaskDependencies).HasColumnName("allow_task_dependencies");
                entity.Property(e => e.AnalyticAccountId).HasColumnName("analytic_account_id");
                entity.Property(e => e.Color).HasColumnName("color");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.Date).HasColumnName("date");
                entity.Property(e => e.DateStart).HasColumnName("date_start");
                entity.Property(e => e.Description).HasColumnName("description");
                entity.Property(e => e.LabelTasks)
                    .HasColumnType("jsonb")
                    .HasColumnName("label_tasks");
                entity.Property(e => e.LastUpdateId).HasColumnName("last_update_id");
                entity.Property(e => e.LastUpdateStatus).HasColumnName("last_update_status");
                entity.Property(e => e.MessageMainAttachmentId).HasColumnName("message_main_attachment_id");
                entity.Property(e => e.Name)
                    .HasColumnType("jsonb")
                    .HasColumnName("name");
                entity.Property(e => e.PartnerEmail).HasColumnName("partner_email");
                entity.Property(e => e.PartnerId).HasColumnName("partner_id");
                entity.Property(e => e.PartnerPhone).HasColumnName("partner_phone");
                entity.Property(e => e.PrivacyVisibility).HasColumnName("privacy_visibility");
                entity.Property(e => e.RatingActive).HasColumnName("rating_active");
                entity.Property(e => e.RatingRequestDeadline)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("rating_request_deadline");
                entity.Property(e => e.RatingStatus).HasColumnName("rating_status");
                entity.Property(e => e.RatingStatusPeriod).HasColumnName("rating_status_period");
                entity.Property(e => e.SaleLineId).HasColumnName("sale_line_id");
                entity.Property(e => e.Sequence)
                    .HasColumnName("sequence");
                entity.Property(e => e.StageId).HasColumnName("stage_id");
                entity.Property(e => e.TaskPropertiesDefinition)
                    .HasColumnType("jsonb")
                    .HasColumnName("task_properties_definition");
                entity.Property(e => e.UserId).HasColumnName("user_id");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne(d => d.Alias).WithMany(p => p.ProjectProjects)
                    .HasForeignKey(d => d.AliasId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("project_project_alias_id_fkey");

                entity.HasOne(d => d.AnalyticAccount).WithMany(p => p.ProjectProjects)
                    .HasForeignKey(d => d.AnalyticAccountId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("project_project_analytic_account_id_fkey");

                entity.HasOne<ResCompany>().WithMany()
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("project_project_company_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("project_project_create_uid_fkey");

                entity.HasOne(d => d.LastUpdate).WithMany(p => p.ProjectProjects)
                    .HasForeignKey(d => d.LastUpdateId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("project_project_last_update_id_fkey");

                entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.ProjectProjects)
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("project_project_message_main_attachment_id_fkey");

                entity.HasOne<ResPartner>().WithMany()
                    .HasForeignKey(d => d.PartnerId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("project_project_partner_id_fkey");

                entity.HasOne(d => d.SaleLine).WithMany(p => p.ProjectProjects)
                    .HasForeignKey(d => d.SaleLineId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("project_project_sale_line_id_fkey");

                entity.HasOne(d => d.Stage).WithMany(p => p.ProjectProjects)
                    .HasForeignKey(d => d.StageId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("project_project_stage_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("project_project_user_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("project_project_write_uid_fkey");

                //entity.HasMany(d => d.ProjectTags).WithMany(p => p.ProjectProjects)
                entity.HasMany<ProjectTags>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "ProjectProjectProjectTagsRel",
                        r => r.HasOne<ProjectTags>().WithMany()
                            .HasForeignKey("ProjectTagsId")
                            .HasConstraintName("project_project_project_tags_rel_project_tags_id_fkey"),
                        l => l.HasOne<ProjectProject>().WithMany()
                            .HasForeignKey("ProjectProjectId")
                            .HasConstraintName("project_project_project_tags_rel_project_project_id_fkey"),
                        j =>
                        {
                            j.HasKey("ProjectProjectId", "ProjectTagsId").HasName("project_project_project_tags_rel_pkey");
                            j.ToTable("project_project_project_tags_rel");
                            j.HasIndex(new[] { "ProjectTagsId", "ProjectProjectId" }, "project_project_project_tags__project_tags_id_project_proje_idx");
                        });

                //entity.HasMany(d => d.Users).WithMany(p => p.Projects)
                entity.HasMany<ResUser>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "ProjectFavoriteUserRel",
                        r => r.HasOne<ResUser>().WithMany()
                            .HasForeignKey("UserId")
                            .HasConstraintName("project_favorite_user_rel_user_id_fkey"),
                        l => l.HasOne<ProjectProject>().WithMany()
                            .HasForeignKey("ProjectId")
                            .HasConstraintName("project_favorite_user_rel_project_id_fkey"),
                        j =>
                        {
                            j.HasKey("ProjectId", "UserId").HasName("project_favorite_user_rel_pkey");
                            j.ToTable("project_favorite_user_rel");
                            j.HasIndex(new[] { "UserId", "ProjectId" }, "project_favorite_user_rel_user_id_project_id_idx");
                        });
            });
        }
    }
}