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
        public static void ConfigureSlideChannelInvite(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SlideChannelInvite>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("slide_channel_invite_pkey");

                entity.ToTable("slide_channel_invite", tb => tb.HasComment("Channel Invitation Wizard"));

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.Body)
                    .HasComment("Contents")
                    .HasColumnName("body");
                entity.Property(e => e.ChannelId)
                    .HasComment("Slide channel")
                    .HasColumnName("channel_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasComment("Created on")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId)
                    .HasComment("Created by")
                    .HasColumnName("create_uid");
                entity.Property(e => e.Lang)
                    .HasComment("Language")
                    .HasColumnType("character varying")
                    .HasColumnName("lang");
                entity.Property(e => e.Subject)
                    .HasComment("Subject")
                    .HasColumnType("character varying")
                    .HasColumnName("subject");
                entity.Property(e => e.TemplateId)
                    .HasComment("Mail Template")
                    .HasColumnName("template_id");
                entity.Property(e => e.LastModificationTime)
                    .HasComment("Last Updated on")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId)
                    .HasComment("Last Updated by")
                    .HasColumnName("write_uid");

                entity.HasOne(d => d.Channel).WithMany(p => p.SlideChannelInvites)
                    .HasForeignKey(d => d.ChannelId)
                    .HasConstraintName("slide_channel_invite_channel_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("slide_channel_invite_create_uid_fkey");

                entity.HasOne(d => d.Template).WithMany()
                    .HasForeignKey(d => d.TemplateId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("slide_channel_invite_template_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("slide_channel_invite_write_uid_fkey");

                entity.HasMany(d => d.IrAttachments).WithMany(p => p.SlideChannelInvites)
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
                            j.ToTable("ir_attachment_slide_channel_invite_rel", tb => tb.HasComment("RELATION BETWEEN slide_channel_invite AND ir_attachment"));
                            j.HasIndex(new[] { "IrAttachmentId", "SlideChannelInviteId" }, "ir_attachment_slide_channel_i_ir_attachment_id_slide_channe_idx");
                            j.IndexerProperty<Guid>("SlideChannelInviteId").HasColumnName("slide_channel_invite_id");
                            j.IndexerProperty<Guid>("IrAttachmentId").HasColumnName("ir_attachment_id");
                        });

                entity.HasMany(d => d.ResPartners).WithMany()
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
                            j.ToTable("res_partner_slide_channel_invite_rel", tb => tb.HasComment("RELATION BETWEEN slide_channel_invite AND res_partner"));
                            j.HasIndex(new[] { "ResPartnerId", "SlideChannelInviteId" }, "res_partner_slide_channel_inv_res_partner_id_slide_channel__idx");
                            j.IndexerProperty<Guid>("SlideChannelInviteId").HasColumnName("slide_channel_invite_id");
                            j.IndexerProperty<Guid>("ResPartnerId").HasColumnName("res_partner_id");
                        });
            });
        }
    }
}