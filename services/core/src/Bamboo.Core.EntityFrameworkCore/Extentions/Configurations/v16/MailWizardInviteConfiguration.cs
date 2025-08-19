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
        public static void ConfigureMailWizardInvite(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<MailWizardInvite>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("mail_wizard_invite_pkey");

            entity.ToTable("mail_wizard_invite");

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
            entity.Property(e => e.Notify).HasColumnName("notify");
            entity.Property(e => e.ResId).HasColumnName("res_id");
            entity.Property(e => e.ResModel).HasColumnName("res_model");
            entity.Property(e => e.SendMail).HasColumnName("send_mail");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.MailWizardInviteCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("mail_wizard_invite_create_uid_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.MailWizardInviteWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("mail_wizard_invite_write_uid_fkey");

            // entity.HasMany(d => d.ResPartner).WithMany(p => p.MailWizardInvite)
            entity.HasMany(d => d.ResPartner).WithMany()
                .UsingEntity<Dictionary<string, object>>(
                    "MailWizardInviteResPartnerRel",
                    r => r.HasOne<ResPartner>().WithMany()
                        .HasForeignKey("ResPartnerId")
                        .HasConstraintName("mail_wizard_invite_res_partner_rel_res_partner_id_fkey"),
                    l => l.HasOne<MailWizardInvite>().WithMany()
                        .HasForeignKey("MailWizardInviteId")
                        .HasConstraintName("mail_wizard_invite_res_partner_rel_mail_wizard_invite_id_fkey"),
                    j =>
                    {
                        j.HasKey("MailWizardInviteId", "ResPartnerId").HasName("mail_wizard_invite_res_partner_rel_pkey");
                        j.ToTable("mail_wizard_invite_res_partner_rel");
                        j.HasIndex(new[] { "ResPartnerId", "MailWizardInviteId" }, "mail_wizard_invite_res_partne_res_partner_id_mail_wizard_in_idx");
                        j.IndexerProperty<Guid>("MailWizardInviteId").HasColumnName("mail_wizard_invite_id");
                        j.IndexerProperty<Guid>("ResPartnerId").HasColumnName("res_partner_id");
                    });
            });
        }
    }
}
