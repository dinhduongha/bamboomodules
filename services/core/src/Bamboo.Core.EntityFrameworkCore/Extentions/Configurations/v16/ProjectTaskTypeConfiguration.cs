using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
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

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.UserId, "project_task_type__user_id_index");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.Active).HasColumnName("active");
                        entity.Property(e => e.AutoValidationState).HasColumnName("auto_validation_state");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.Fold).HasColumnName("fold");
                        entity.Property(e => e.MailTemplateId).HasColumnName("mail_template_id");
                        entity.Property(e => e.Name)
                            .HasColumnType("jsonb")
                            .HasColumnName("name");
                        entity.Property(e => e.RatingTemplateId).HasColumnName("rating_template_id");
                        entity.Property(e => e.Sequence).HasColumnName("sequence");
                        entity.Property(e => e.SmsTemplateId).HasColumnName("sms_template_id");
                        entity.Property(e => e.UserId).HasColumnName("user_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.ProjectTaskTypeCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("project_task_type_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("project_task_type_create_uid_fkey");

                        entity.HasOne(d => d.MailTemplate).WithMany(p => p.ProjectTaskTypeMailTemplate)
                            .HasForeignKey(d => d.MailTemplateId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("project_task_type_mail_template_id_fkey");

                        entity.HasOne(d => d.RatingTemplate).WithMany(p => p.ProjectTaskTypeRatingTemplate)
                            .HasForeignKey(d => d.RatingTemplateId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("project_task_type_rating_template_id_fkey");

                        entity.HasOne(d => d.SmsTemplate).WithMany(p => p.ProjectTaskType)
                            .HasForeignKey(d => d.SmsTemplateId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("project_task_type_sms_template_id_fkey");

                        // entity.HasOne(d => d.User).WithMany(p => p.ProjectTaskTypeUser) .HasForeignKey(d => d.UserId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("project_task_type_user_id_fkey");
                        entity.HasOne(d => d.User).WithMany()
                            .HasForeignKey(d => d.UserId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("project_task_type_user_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.ProjectTaskTypeWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("project_task_type_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("project_task_type_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}