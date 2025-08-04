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
        public static void ConfigureProjectProjectStage(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProjectProjectStage>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("project_project_stage_pkey");

                entity.ToTable("project_project_stage");

                entity.HasIndex(e => e.TenantId, "project_project_stage_company_id_index");

                //entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.Active).HasColumnName("active");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.Fold).HasColumnName("fold");
                entity.Property(e => e.MailTemplateId).HasColumnName("mail_template_id");
                entity.Property(e => e.Name)
                    .HasColumnType("jsonb")
                    .HasColumnName("name");
                entity.Property(e => e.Sequence)
                    .HasColumnName("sequence");
                entity.Property(e => e.SmsTemplateId).HasColumnName("sms_template_id");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("project_project_stage_create_uid_fkey");

                entity.HasOne(d => d.MailTemplate).WithMany(p => p.ProjectProjectStages)
                    .HasForeignKey(d => d.MailTemplateId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("project_project_stage_mail_template_id_fkey");

                entity.HasOne(d => d.SmsTemplate).WithMany(p => p.ProjectProjectStages)
                    .HasForeignKey(d => d.SmsTemplateId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("project_project_stage_sms_template_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("project_project_stage_write_uid_fkey");
            });
        }
    }
}