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
        public static void ConfigureProjectTaskType(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProjectTaskType>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("project_task_type_pkey");

                entity.ToTable("project_task_type");

                entity.HasIndex(e => e.UserId, "project_task_type_user_id_index");

                //entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.Active).HasColumnName("active");
                entity.Property(e => e.AutoValidationKanbanState).HasColumnName("auto_validation_kanban_state");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.Description)
                    .HasColumnType("jsonb")
                    .HasColumnName("description");
                entity.Property(e => e.Fold).HasColumnName("fold");
                entity.Property(e => e.LegendBlocked)
                    .HasColumnType("jsonb")
                    .HasColumnName("legend_blocked");
                entity.Property(e => e.LegendDone)
                    .HasColumnType("jsonb")
                    .HasColumnName("legend_done");
                entity.Property(e => e.LegendNormal)
                    .HasColumnType("jsonb")
                    .HasColumnName("legend_normal");
                entity.Property(e => e.MailTemplateId).HasColumnName("mail_template_id");
                entity.Property(e => e.Name)
                    .HasColumnType("jsonb")
                    .HasColumnName("name");
                entity.Property(e => e.RatingTemplateId).HasColumnName("rating_template_id");
                entity.Property(e => e.Sequence)
                    .HasColumnName("sequence");
                entity.Property(e => e.SmsTemplateId).HasColumnName("sms_template_id");
                entity.Property(e => e.UserId).HasColumnName("user_id");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("project_task_type_create_uid_fkey");

                entity.HasOne(d => d.MailTemplate).WithMany(p => p.ProjectTaskTypeMailTemplates)
                    .HasForeignKey(d => d.MailTemplateId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("project_task_type_mail_template_id_fkey");

                entity.HasOne(d => d.RatingTemplate).WithMany(p => p.ProjectTaskTypeRatingTemplates)
                    .HasForeignKey(d => d.RatingTemplateId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("project_task_type_rating_template_id_fkey");

                entity.HasOne(d => d.SmsTemplate).WithMany(p => p.ProjectTaskTypes)
                    .HasForeignKey(d => d.SmsTemplateId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("project_task_type_sms_template_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("project_task_type_user_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("project_task_type_write_uid_fkey");

                //entity.HasMany(d => d.Projects).WithMany(p => p.Types)
                entity.HasMany<ProjectProject>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "ProjectTaskTypeRel",
                        r => r.HasOne<ProjectProject>().WithMany()
                            .HasForeignKey("ProjectId")
                            .HasConstraintName("project_task_type_rel_project_id_fkey"),
                        l => l.HasOne<ProjectTaskType>().WithMany()
                            .HasForeignKey("TypeId")
                            .HasConstraintName("project_task_type_rel_type_id_fkey"),
                        j =>
                        {
                            j.HasKey("TypeId", "ProjectId").HasName("project_task_type_rel_pkey");
                            j.ToTable("project_task_type_rel");
                            j.HasIndex(new[] { "ProjectId", "TypeId" }, "project_task_type_rel_project_id_type_id_idx");
                        });
            });
        }
    }
}