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
        public static void ConfigureSmsTemplateReset(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SmsTemplateReset>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("sms_template_reset_pkey");

                entity.ToTable("sms_template_reset");

                entity.HasIndex(e => e.TenantId, "sms_template_reset_company_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("sms_template_reset_create_uid_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("sms_template_reset_write_uid_fkey");

                //entity.HasMany(d => d.SmsTemplates).WithMany(p => p.SmsTemplateResets)
                entity.HasMany<SmsTemplate>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "SmsTemplateSmsTemplateResetRel",
                        r => r.HasOne<SmsTemplate>().WithMany()
                            .HasForeignKey("SmsTemplateId")
                            .HasConstraintName("sms_template_sms_template_reset_rel_sms_template_id_fkey"),
                        l => l.HasOne<SmsTemplateReset>().WithMany()
                            .HasForeignKey("SmsTemplateResetId")
                            .HasConstraintName("sms_template_sms_template_reset_rel_sms_template_reset_id_fkey"),
                        j =>
                        {
                            j.HasKey("SmsTemplateResetId", "SmsTemplateId").HasName("sms_template_sms_template_reset_rel_pkey");
                            j.ToTable("sms_template_sms_template_reset_rel");
                            j.HasIndex(new[] { "SmsTemplateId", "SmsTemplateResetId" }, "sms_template_sms_template_res_sms_template_id_sms_template__idx");
                        });
            });
        }
    }
}