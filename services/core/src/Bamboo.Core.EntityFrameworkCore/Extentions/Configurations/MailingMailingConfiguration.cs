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
        public static void ConfigureMailingMailing(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MailingMailing>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("mailing_mailing_pkey");

                entity.ToTable("mailing_mailing", tb => tb.HasComment("Mass Mailing"));

                entity.HasIndex(e => e.CampaignId, "mailing_mailing_campaign_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.AbTestingCompleted)
                    .HasComment("A/B Testing Campaign Finished")
                    .HasColumnName("ab_testing_completed");
                entity.Property(e => e.AbTestingEnabled)
                    .HasComment("Allow A/B Testing")
                    .HasColumnName("ab_testing_enabled");
                entity.Property(e => e.AbTestingPc)
                    .HasComment("A/B Testing percentage")
                    .HasColumnName("ab_testing_pc");
                entity.Property(e => e.Active)
                    .HasComment("Active")
                    .HasColumnName("active");
                entity.Property(e => e.BodyArch)
                    .HasComment("Body")
                    .HasColumnName("body_arch");
                entity.Property(e => e.BodyHtml)
                    .HasComment("Body converted to be sent by mail")
                    .HasColumnName("body_html");
                entity.Property(e => e.BodyPlaintext)
                    .HasComment("SMS Body")
                    .HasColumnName("body_plaintext");
                entity.Property(e => e.CalendarDate)
                    .HasComment("Calendar Date")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("calendar_date");
                entity.Property(e => e.CampaignId)
                    .HasComment("UTM Campaign")
                    .HasColumnName("campaign_id");
                entity.Property(e => e.Color)
                    .HasComment("Color Index")
                    .HasColumnName("color");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasComment("Created on")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId)
                    .HasComment("Created by")
                    .HasColumnName("create_uid");
                entity.Property(e => e.EmailFrom)
                    .HasComment("Send From")
                    .HasColumnType("character varying")
                    .HasColumnName("email_from");
                entity.Property(e => e.Favorite)
                    .HasComment("Favorite")
                    .HasColumnName("favorite");
                entity.Property(e => e.FavoriteDate)
                    .HasComment("Favorite Date")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("favorite_date");
                entity.Property(e => e.KeepArchives)
                    .HasComment("Keep Archives")
                    .HasColumnName("keep_archives");
                entity.Property(e => e.KpiMailRequired)
                    .HasComment("KPI mail required")
                    .HasColumnName("kpi_mail_required");
                entity.Property(e => e.Lang)
                    .HasComment("Language")
                    .HasColumnType("character varying")
                    .HasColumnName("lang");
                entity.Property(e => e.MailServerId)
                    .HasComment("Mail Server")
                    .HasColumnName("mail_server_id");
                entity.Property(e => e.MailingDomain)
                    .HasComment("Domain")
                    .HasColumnType("character varying")
                    .HasColumnName("mailing_domain");
                entity.Property(e => e.MailingFilterId)
                    .HasComment("Favorite Filter")
                    .HasColumnName("mailing_filter_id");
                entity.Property(e => e.MailingModelId)
                    .HasComment("Recipients Model")
                    .HasColumnName("mailing_model_id");
                entity.Property(e => e.MailingType)
                    .HasComment("Mailing Type")
                    .HasColumnType("character varying")
                    .HasColumnName("mailing_type");
                entity.Property(e => e.MediumId)
                    .HasComment("Medium")
                    .HasColumnName("medium_id");
                entity.Property(e => e.MessageMainAttachmentId)
                    .HasComment("Main Attachment")
                    .HasColumnName("message_main_attachment_id");
                entity.Property(e => e.Preview)
                    .HasComment("Preview")
                    .HasColumnType("character varying")
                    .HasColumnName("preview");
                entity.Property(e => e.ReplyTo)
                    .HasComment("Reply To")
                    .HasColumnType("character varying")
                    .HasColumnName("reply_to");
                entity.Property(e => e.ReplyToMode)
                    .HasComment("Reply-To Mode")
                    .HasColumnType("character varying")
                    .HasColumnName("reply_to_mode");
                entity.Property(e => e.ScheduleDate)
                    .HasComment("Scheduled for")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("schedule_date");
                entity.Property(e => e.ScheduleType)
                    .HasComment("Schedule")
                    .HasColumnType("character varying")
                    .HasColumnName("schedule_type");
                entity.Property(e => e.SentDate)
                    .HasComment("Sent Date")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("sent_date");
                entity.Property(e => e.SmsAllowUnsubscribe)
                    .HasComment("Include opt-out link")
                    .HasColumnName("sms_allow_unsubscribe");
                entity.Property(e => e.SmsForceSend)
                    .HasComment("Send Directly")
                    .HasColumnName("sms_force_send");
                entity.Property(e => e.SmsTemplateId)
                    .HasComment("SMS Template")
                    .HasColumnName("sms_template_id");
                entity.Property(e => e.SourceId)
                    .HasComment("Source")
                    .HasColumnName("source_id");
                entity.Property(e => e.State)
                    .HasComment("Status")
                    .HasColumnType("character varying")
                    .HasColumnName("state");
                entity.Property(e => e.Subject)
                    .HasComment("Subject")
                    .HasColumnType("character varying")
                    .HasColumnName("subject");
                entity.Property(e => e.UserId)
                    .HasComment("Responsible")
                    .HasColumnName("user_id");
                entity.Property(e => e.LastModificationTime)
                    .HasComment("Last Updated on")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId)
                    .HasComment("Last Updated by")
                    .HasColumnName("write_uid");

                entity.HasOne(d => d.Campaign).WithMany(p => p.MailingMailings)
                    .HasForeignKey(d => d.CampaignId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mailing_mailing_campaign_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mailing_mailing_create_uid_fkey");

                entity.HasOne(d => d.MailServer).WithMany(p => p.MailingMailings)
                    .HasForeignKey(d => d.MailServerId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mailing_mailing_mail_server_id_fkey");

                entity.HasOne(d => d.MailingFilter).WithMany(p => p.MailingMailings)
                    .HasForeignKey(d => d.MailingFilterId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mailing_mailing_mailing_filter_id_fkey");

                entity.HasOne(d => d.MailingModel).WithMany(p => p.MailingMailings)
                    .HasForeignKey(d => d.MailingModelId)
                    .HasConstraintName("mailing_mailing_mailing_model_id_fkey");

                entity.HasOne(d => d.Medium).WithMany(p => p.MailingMailings)
                    .HasForeignKey(d => d.MediumId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("mailing_mailing_medium_id_fkey");

                entity.HasOne(d => d.MessageMainAttachment).WithMany()
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mailing_mailing_message_main_attachment_id_fkey");

                entity.HasOne(d => d.SmsTemplate).WithMany()
                    .HasForeignKey(d => d.SmsTemplateId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mailing_mailing_sms_template_id_fkey");

                entity.HasOne(d => d.Source).WithMany()
                    .HasForeignKey(d => d.SourceId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("mailing_mailing_source_id_fkey");

                entity.HasOne(d => d.User).WithMany()
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mailing_mailing_user_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mailing_mailing_write_uid_fkey");

                entity.HasMany(d => d.Attachments).WithMany(p => p.MassMailings)
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
                            j.ToTable("mass_mailing_ir_attachments_rel", tb => tb.HasComment("RELATION BETWEEN mailing_mailing AND ir_attachment"));
                            j.HasIndex(new[] { "AttachmentId", "MassMailingId" }, "mass_mailing_ir_attachments_r_attachment_id_mass_mailing_id_idx");
                            j.IndexerProperty<Guid>("MassMailingId").HasColumnName("mass_mailing_id");
                            j.IndexerProperty<Guid>("AttachmentId").HasColumnName("attachment_id");
                        });
            });
        }
    }
}