using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureMailingMailing(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<MailingMailing>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("mailing_mailing_pkey");

                        entity.ToTable("mailing_mailing");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.CampaignId, "mailing_mailing__campaign_id_index");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("next_uuid()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.AbTestingEnabled).HasColumnName("ab_testing_enabled");
                        entity.Property(e => e.AbTestingPc).HasColumnName("ab_testing_pc");
                        entity.Property(e => e.Active).HasColumnName("active");
                        entity.Property(e => e.BodyArch).HasColumnName("body_arch");
                        entity.Property(e => e.BodyHtml).HasColumnName("body_html");
                        entity.Property(e => e.BodyPlaintext).HasColumnName("body_plaintext");
                        entity.Property(e => e.CalendarDate)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("calendar_date");
                        entity.Property(e => e.CampaignId).HasColumnName("campaign_id");
                        entity.Property(e => e.CardCampaignId).HasColumnName("card_campaign_id");
                        entity.Property(e => e.Color).HasColumnName("color");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.EmailFrom).HasColumnName("email_from");
                        entity.Property(e => e.Favorite).HasColumnName("favorite");
                        entity.Property(e => e.FavoriteDate)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("favorite_date");
                        entity.Property(e => e.KeepArchives).HasColumnName("keep_archives");
                        entity.Property(e => e.KpiMailRequired).HasColumnName("kpi_mail_required");
                        entity.Property(e => e.Lang).HasColumnName("lang");
                        entity.Property(e => e.MailServerId).HasColumnName("mail_server_id");
                        entity.Property(e => e.MailingDomain).HasColumnName("mailing_domain");
                        entity.Property(e => e.MailingFilterId).HasColumnName("mailing_filter_id");
                        entity.Property(e => e.MailingModelId).HasColumnName("mailing_model_id");
                        entity.Property(e => e.MailingType).HasColumnName("mailing_type");
                        entity.Property(e => e.MediumId).HasColumnName("medium_id");
                        entity.Property(e => e.Preview).HasColumnName("preview");
                        entity.Property(e => e.ReplyTo).HasColumnName("reply_to");
                        entity.Property(e => e.ReplyToMode).HasColumnName("reply_to_mode");
                        entity.Property(e => e.ScheduleDate)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("schedule_date");
                        entity.Property(e => e.ScheduleType).HasColumnName("schedule_type");
                        entity.Property(e => e.SentDate)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("sent_date");
                        entity.Property(e => e.SmsAllowUnsubscribe).HasColumnName("sms_allow_unsubscribe");
                        entity.Property(e => e.SmsForceSend).HasColumnName("sms_force_send");
                        entity.Property(e => e.SmsTemplateId).HasColumnName("sms_template_id");
                        entity.Property(e => e.SourceId).HasColumnName("source_id");
                        entity.Property(e => e.State).HasColumnName("state");
                        entity.Property(e => e.Subject).HasColumnName("subject");
                        entity.Property(e => e.UserId).HasColumnName("user_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        entity.HasOne(d => d.Campaign).WithMany(p => p.MailingMailing)
                            .HasForeignKey(d => d.CampaignId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mailing_mailing_campaign_id_fkey");

                        entity.HasOne(d => d.CardCampaign).WithMany(p => p.MailingMailing)
                            .HasForeignKey(d => d.CardCampaignId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mailing_mailing_card_campaign_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.MailingMailingCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("mailing_mailing_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mailing_mailing_create_uid_fkey");

                        entity.HasOne(d => d.MailServer).WithMany(p => p.MailingMailing)
                            .HasForeignKey(d => d.MailServerId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mailing_mailing_mail_server_id_fkey");

                        entity.HasOne(d => d.MailingFilter).WithMany(p => p.MailingMailing)
                            .HasForeignKey(d => d.MailingFilterId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mailing_mailing_mailing_filter_id_fkey");

                        entity.HasOne(d => d.MailingModel).WithMany(p => p.MailingMailing)
                            .HasForeignKey(d => d.MailingModelId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("mailing_mailing_mailing_model_id_fkey");

                        entity.HasOne(d => d.Medium).WithMany(p => p.MailingMailing)
                            .HasForeignKey(d => d.MediumId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("mailing_mailing_medium_id_fkey");

                        entity.HasOne(d => d.SmsTemplate).WithMany(p => p.MailingMailing)
                            .HasForeignKey(d => d.SmsTemplateId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mailing_mailing_sms_template_id_fkey");

                        entity.HasOne(d => d.Source).WithMany(p => p.MailingMailing)
                            .HasForeignKey(d => d.SourceId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("mailing_mailing_source_id_fkey");

                        // entity.HasOne(d => d.User).WithMany(p => p.MailingMailingUser) .HasForeignKey(d => d.UserId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("mailing_mailing_user_id_fkey");
                        entity.HasOne(d => d.User).WithMany()
                            .HasForeignKey(d => d.UserId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mailing_mailing_user_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.MailingMailingWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("mailing_mailing_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mailing_mailing_write_uid_fkey");

                        // entity.HasMany(d => d.Attachment).WithMany(p => p.MassMailing)
                        entity.HasMany(d => d.Attachment).WithMany()
                            .UsingEntity<Dictionary<string, object>>(
                                "MassMailingIrAttachmentsRel",
                                r => r.HasOne<IrAttachment>().WithMany()
                                    .HasForeignKey("AttachmentId")
                                    .HasConstraintName("mass_mailing_ir_attachments_rel_attachment_id_fkey"),
                                l => l.HasOne<MailingMailing>().WithMany()
                                    .HasForeignKey("MassMailingId")
                                    .HasConstraintName("mass_mailing_ir_attachments_rel_mass_mailing_id_fkey"),
                                j =>
                                {
                                    j.HasKey("MassMailingId", "AttachmentId").HasName("mass_mailing_ir_attachments_rel_pkey");
                                    j.ToTable("mass_mailing_ir_attachments_rel");
                                    j.HasIndex(new[] { "AttachmentId", "MassMailingId" }, "mass_mailing_ir_attachments_r_attachment_id_mass_mailing_id_idx");
                                    j.IndexerProperty<Guid>("MassMailingId").HasColumnName("mass_mailing_id");
                                    j.IndexerProperty<Guid>("AttachmentId").HasColumnName("attachment_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}