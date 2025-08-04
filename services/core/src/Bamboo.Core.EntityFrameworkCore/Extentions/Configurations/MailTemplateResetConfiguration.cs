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
        public static void ConfigureMailTemplateReset(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MailTemplateReset>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("mail_template_reset_pkey");

                entity.ToTable("mail_template_reset");

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
                    .HasConstraintName("mail_template_reset_create_uid_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mail_template_reset_write_uid_fkey");

                //entity.HasMany(d => d.MailTemplates).WithMany(p => p.MailTemplateResets)
                entity.HasMany<MailTemplate>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "MailTemplateMailTemplateResetRel",
                        r => r.HasOne<MailTemplate>().WithMany()
                            .HasForeignKey("MailTemplateId")
                            .HasConstraintName("mail_template_mail_template_reset_rel_mail_template_id_fkey"),
                        l => l.HasOne<MailTemplateReset>().WithMany()
                            .HasForeignKey("MailTemplateResetId")
                            .HasConstraintName("mail_template_mail_template_reset_r_mail_template_reset_id_fkey"),
                        j =>
                        {
                            j.HasKey("MailTemplateResetId", "MailTemplateId").HasName("mail_template_mail_template_reset_rel_pkey");
                            j.ToTable("mail_template_mail_template_reset_rel");
                            j.HasIndex(new[] { "MailTemplateId", "MailTemplateResetId" }, "mail_template_mail_template_r_mail_template_id_mail_templat_idx");
                        });
            });
        }
    }
}