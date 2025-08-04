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
        public static void ConfigureSmsTemplate(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SmsTemplate>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("sms_template_pkey");

                entity.ToTable("sms_template");

                entity.HasIndex(e => e.TenantId, "sms_template_company_id_index");

                entity.HasIndex(e => e.Model, "sms_template_model_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.Body)
                    .HasColumnType("jsonb")
                    .HasColumnName("body");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.Lang).HasColumnName("lang");
                entity.Property(e => e.Model).HasColumnName("model");
                entity.Property(e => e.ModelId).HasColumnName("model_id");
                entity.Property(e => e.Name)
                    .HasColumnType("jsonb")
                    .HasColumnName("name");
                entity.Property(e => e.SidebarActionId).HasColumnName("sidebar_action_id");
                entity.Property(e => e.TemplateFs).HasColumnName("template_fs");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("sms_template_create_uid_fkey");

                entity.HasOne(d => d.ModelNavigation).WithMany(p => p.SmsTemplates)
                    .HasForeignKey(d => d.ModelId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("sms_template_model_id_fkey");

                entity.HasOne(d => d.SidebarAction).WithMany(p => p.SmsTemplates)
                    .HasForeignKey(d => d.SidebarActionId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("sms_template_sidebar_action_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("sms_template_write_uid_fkey");
            });
        }
    }
}