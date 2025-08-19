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
        public static void ConfigureMailResendPartner(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<MailResendPartner>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("mail_resend_partner_pkey");

            entity.ToTable("mail_resend_partner");

            entity.HasIndex(e => e.TenantId);

            entity.HasIndex(e => e.OrganizationUnitId);

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");

            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.Message).HasColumnName("message");
            entity.Property(e => e.NotificationId).HasColumnName("notification_id");
            entity.Property(e => e.PartnerId).HasColumnName("partner_id");
            entity.Property(e => e.Resend).HasColumnName("resend");
            entity.Property(e => e.ResendWizardId).HasColumnName("resend_wizard_id");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.MailResendPartnerCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("mail_resend_partner_create_uid_fkey");

            entity.HasOne(d => d.Notification).WithMany(p => p.MailResendPartner)
                .HasForeignKey(d => d.NotificationId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("mail_resend_partner_notification_id_fkey");

            // entity.HasOne(d => d.Partner).WithMany(p => p.MailResendPartner)
            entity.HasOne(d => d.Partner).WithMany()
                .HasForeignKey(d => d.PartnerId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("mail_resend_partner_partner_id_fkey");

            entity.HasOne(d => d.ResendWizard).WithMany(p => p.MailResendPartner)
                .HasForeignKey(d => d.ResendWizardId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("mail_resend_partner_resend_wizard_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.MailResendPartnerWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("mail_resend_partner_write_uid_fkey");
            });
        }
    }
}
