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
        public static void ConfigureSlideChannelInvite(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<SlideChannelInvite>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("slide_channel_invite_pkey");

            entity.ToTable("slide_channel_invite");

            entity.HasIndex(e => e.TenantId);

            entity.HasIndex(e => e.OrganizationUnitId);

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");

            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
            entity.Property(e => e.Body).HasColumnName("body");
            entity.Property(e => e.ChannelId).HasColumnName("channel_id");
            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.EnrollMode).HasColumnName("enroll_mode");
            entity.Property(e => e.Lang).HasColumnName("lang");
            entity.Property(e => e.SendEmail).HasColumnName("send_email");
            entity.Property(e => e.Subject).HasColumnName("subject");
            entity.Property(e => e.TemplateId).HasColumnName("template_id");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            entity.HasOne(d => d.Channel).WithMany(p => p.SlideChannelInvite)
                .HasForeignKey(d => d.ChannelId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("slide_channel_invite_channel_id_fkey");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.SlideChannelInviteCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("slide_channel_invite_create_uid_fkey");

            entity.HasOne(d => d.Template).WithMany(p => p.SlideChannelInvite)
                .HasForeignKey(d => d.TemplateId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("slide_channel_invite_template_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.SlideChannelInviteWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("slide_channel_invite_write_uid_fkey");

            // entity.HasMany(d => d.IrAttachment).WithMany(p => p.SlideChannelInvite)
            entity.HasMany(d => d.IrAttachment).WithMany()
                .UsingEntity<Dictionary<string, object>>(
                    "IrAttachmentSlideChannelInviteRel",
                    r => r.HasOne<IrAttachment>().WithMany()
                        .HasForeignKey("IrAttachmentId")
                        .HasConstraintName("ir_attachment_slide_channel_invite_rel_ir_attachment_id_fkey"),
                    l => l.HasOne<SlideChannelInvite>().WithMany()
                        .HasForeignKey("SlideChannelInviteId")
                        .HasConstraintName("ir_attachment_slide_channel_invite_slide_channel_invite_id_fkey"),
                    j =>
                    {
                        j.HasKey("SlideChannelInviteId", "IrAttachmentId").HasName("ir_attachment_slide_channel_invite_rel_pkey");
                        j.ToTable("ir_attachment_slide_channel_invite_rel");
                        j.HasIndex(new[] { "IrAttachmentId", "SlideChannelInviteId" }, "ir_attachment_slide_channel_i_ir_attachment_id_slide_channe_idx");
                        j.IndexerProperty<Guid>("SlideChannelInviteId").HasColumnName("slide_channel_invite_id");
                        j.IndexerProperty<Guid>("IrAttachmentId").HasColumnName("ir_attachment_id");
                    });

            // entity.HasMany(d => d.ResPartner).WithMany(p => p.SlideChannelInvite)
            entity.HasMany(d => d.ResPartner).WithMany()
                .UsingEntity<Dictionary<string, object>>(
                    "ResPartnerSlideChannelInviteRel",
                    r => r.HasOne<ResPartner>().WithMany()
                        .HasForeignKey("ResPartnerId")
                        .HasConstraintName("res_partner_slide_channel_invite_rel_res_partner_id_fkey"),
                    l => l.HasOne<SlideChannelInvite>().WithMany()
                        .HasForeignKey("SlideChannelInviteId")
                        .HasConstraintName("res_partner_slide_channel_invite_r_slide_channel_invite_id_fkey"),
                    j =>
                    {
                        j.HasKey("SlideChannelInviteId", "ResPartnerId").HasName("res_partner_slide_channel_invite_rel_pkey");
                        j.ToTable("res_partner_slide_channel_invite_rel");
                        j.HasIndex(new[] { "ResPartnerId", "SlideChannelInviteId" }, "res_partner_slide_channel_inv_res_partner_id_slide_channel__idx");
                        j.IndexerProperty<Guid>("SlideChannelInviteId").HasColumnName("slide_channel_invite_id");
                        j.IndexerProperty<Guid>("ResPartnerId").HasColumnName("res_partner_id");
                    });
            });
        }
    }
}
