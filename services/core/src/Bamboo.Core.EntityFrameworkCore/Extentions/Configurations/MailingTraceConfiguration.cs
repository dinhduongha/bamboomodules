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
        public static void ConfigureMailingTrace(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MailingTrace>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("mailing_trace_pkey");

                entity.ToTable("mailing_trace", tb => tb.HasComment("Mailing Statistics"));

                entity.HasIndex(e => e.CampaignId, "mailing_trace_campaign_id_index").HasFilter("(campaign_id IS NOT NULL)");

                entity.HasIndex(e => e.MailMailId, "mailing_trace_mail_mail_id_index").HasFilter("(mail_mail_id IS NOT NULL)");

                entity.HasIndex(e => e.MailMailIdInt, "mailing_trace_mail_mail_id_int_index").HasFilter("(mail_mail_id_int IS NOT NULL)");

                entity.HasIndex(e => e.MassMailingId, "mailing_trace_mass_mailing_id_index");

                entity.HasIndex(e => e.SmsSmsId, "mailing_trace_sms_sms_id_index").HasFilter("(sms_sms_id IS NOT NULL)");

                entity.HasIndex(e => e.SmsSmsIdInt, "mailing_trace_sms_id_int_index").HasFilter("(sms_id_int IS NOT NULL)");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CampaignId)
                    .HasComment("Campaign")
                    .HasColumnName("campaign_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasComment("Created on")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId)
                    .HasComment("Created by")
                    .HasColumnName("create_uid");
                entity.Property(e => e.Email)
                    .HasComment("Email")
                    .HasColumnType("character varying")
                    .HasColumnName("email");
                entity.Property(e => e.FailureType)
                    .HasComment("Failure type")
                    .HasColumnType("character varying")
                    .HasColumnName("failure_type");
                entity.Property(e => e.LinksClickDatetime)
                    .HasComment("Clicked On")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("links_click_datetime");
                entity.Property(e => e.MailMailId)
                    .HasComment("Mail")
                    .HasColumnName("mail_mail_id");
                entity.Property(e => e.MailMailIdInt)
                    .HasComment("Mail ID (tech)")
                    .HasColumnName("mail_mail_id_int");
                entity.Property(e => e.MassMailingId)
                    .HasComment("Mailing")
                    .HasColumnName("mass_mailing_id");
                entity.Property(e => e.MessageId)
                    .HasComment("Message-ID")
                    .HasColumnType("character varying")
                    .HasColumnName("message_id");
                entity.Property(e => e.Model)
                    .HasComment("Document model")
                    .HasColumnType("character varying")
                    .HasColumnName("model");
                entity.Property(e => e.OpenDatetime)
                    .HasComment("Opened On")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("open_datetime");
                entity.Property(e => e.ReplyDatetime)
                    .HasComment("Replied On")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("reply_datetime");
                entity.Property(e => e.ResId)
                    .HasComment("Document ID")
                    .HasColumnName("res_id");
                entity.Property(e => e.SentDatetime)
                    .HasComment("Sent On")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("sent_datetime");
                entity.Property(e => e.SmsCode)
                    .HasComment("Code")
                    .HasColumnType("character varying")
                    .HasColumnName("sms_code");
                entity.Property(e => e.SmsNumber)
                    .HasComment("Number")
                    .HasColumnType("character varying")
                    .HasColumnName("sms_number");
                entity.Property(e => e.SmsSmsId)
                    .HasComment("SMS")
                    .HasColumnName("sms_sms_id");
                entity.Property(e => e.SmsSmsIdInt)
                    .HasComment("SMS ID (tech)")
                    .HasColumnName("sms_id_int");
                entity.Property(e => e.TraceStatus)
                    .HasComment("Status")
                    .HasColumnType("character varying")
                    .HasColumnName("trace_status");
                entity.Property(e => e.TraceType)
                    .HasComment("Type")
                    .HasColumnType("character varying")
                    .HasColumnName("trace_type");
                entity.Property(e => e.LastModificationTime)
                    .HasComment("Last Updated on")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId)
                    .HasComment("Last Updated by")
                    .HasColumnName("write_uid");

                entity.HasOne(d => d.Campaign).WithMany(p => p.MailingTraces)
                    .HasForeignKey(d => d.CampaignId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mailing_trace_campaign_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mailing_trace_create_uid_fkey");

                entity.HasOne(d => d.MailMail).WithMany()
                    .HasForeignKey(d => d.MailMailId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mailing_trace_mail_mail_id_fkey");

                entity.HasOne(d => d.MassMailing).WithMany(p => p.MailingTraces)
                    .HasForeignKey(d => d.MassMailingId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("mailing_trace_mass_mailing_id_fkey");

                entity.HasOne(d => d.SmsSms).WithMany()
                    .HasForeignKey(d => d.SmsSmsId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mailing_trace_sms_sms_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mailing_trace_write_uid_fkey");
            });
        }
    }
}