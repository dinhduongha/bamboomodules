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
        public static void ConfigureSmsTemplatePreview(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SmsTemplatePreview>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("sms_template_preview_pkey");

                entity.ToTable("sms_template_preview");

                entity.HasIndex(e => e.TenantId, "sms_template_preview_company_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.Lang).HasColumnName("lang");
                entity.Property(e => e.ResourceRef).HasColumnName("resource_ref");
                entity.Property(e => e.SmsTemplateId).HasColumnName("sms_template_id");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("sms_template_preview_create_uid_fkey");

                entity.HasOne(d => d.SmsTemplate).WithMany(p => p.SmsTemplatePreviews)
                    .HasForeignKey(d => d.SmsTemplateId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("sms_template_preview_sms_template_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("sms_template_preview_write_uid_fkey");
            });
        }
    }
}