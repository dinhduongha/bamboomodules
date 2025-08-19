using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Bamboo.Core.Models;
// Cần thêm using đến namespace chứa entity của bạn ở đây
// Ví dụ: using YourProject.Entities;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureMailMail(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<MailMail>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("mail_mail_pkey");

            entity.ToTable("mail_mail");

            entity.HasIndex(e => e.TenantId);

            entity.HasIndex(e => e.OrganizationUnitId);

            entity.HasIndex(e => e.MailMessageId, "mail_mail__mail_message_id_index");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");

            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
            entity.Property(e => e.AutoDelete).HasColumnName("auto_delete");
            entity.Property(e => e.BodyHtml).HasColumnName("body_html");
            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.EmailCc).HasColumnName("email_cc");
            entity.Property(e => e.EmailTo).HasColumnName("email_to");
            entity.Property(e => e.FailureReason).HasColumnName("failure_reason");
            entity.Property(e => e.FailureType).HasColumnName("failure_type");
            entity.Property(e => e.FetchmailServerId).HasColumnName("fetchmail_server_id");
            entity.Property(e => e.Headers).HasColumnName("headers");
            entity.Property(e => e.IsNotification).HasColumnName("is_notification");
            entity.Property(e => e.MailMessageId).HasColumnName("mail_message_id");
            entity.Property(e => e.MailingId).HasColumnName("mailing_id");
            entity.Property(e => e.References).HasColumnName("references");
            entity.Property(e => e.ScheduledDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("scheduled_date");
            entity.Property(e => e.State).HasColumnName("state");
            entity.Property(e => e.ToDelete).HasColumnName("to_delete");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.MailMailCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("mail_mail_create_uid_fkey");

            entity.HasOne(d => d.FetchmailServer).WithMany(p => p.MailMail)
                .HasForeignKey(d => d.FetchmailServerId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("mail_mail_fetchmail_server_id_fkey");

            entity.HasOne(d => d.MailMessage).WithMany(p => p.MailMail)
                .HasForeignKey(d => d.MailMessageId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("mail_mail_mail_message_id_fkey");

            entity.HasOne(d => d.Mailing).WithMany(p => p.MailMail)
                .HasForeignKey(d => d.MailingId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("mail_mail_mailing_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.MailMailWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("mail_mail_write_uid_fkey");

            // entity.HasMany(d => d.ResPartner).WithMany(p => p.MailMail)
            entity.HasMany(d => d.ResPartner).WithMany()
                .UsingEntity<Dictionary<string, object>>(
                    "MailMailResPartnerRel",
                    r => r.HasOne<ResPartner>().WithMany()
                        .HasForeignKey("ResPartnerId")
                        .HasConstraintName("mail_mail_res_partner_rel_res_partner_id_fkey"),
                    l => l.HasOne<MailMail>().WithMany()
                        .HasForeignKey("MailMailId")
                        .HasConstraintName("mail_mail_res_partner_rel_mail_mail_id_fkey"),
                    j =>
                    {
                        j.HasKey("MailMailId", "ResPartnerId").HasName("mail_mail_res_partner_rel_pkey");
                        j.ToTable("mail_mail_res_partner_rel");
                        j.HasIndex(new[] { "ResPartnerId", "MailMailId" }, "mail_mail_res_partner_rel_res_partner_id_mail_mail_id_idx");
                        j.IndexerProperty<Guid>("MailMailId").HasColumnName("mail_mail_id");
                        j.IndexerProperty<Guid>("ResPartnerId").HasColumnName("res_partner_id");
                    });
            });
        }
    }
}
