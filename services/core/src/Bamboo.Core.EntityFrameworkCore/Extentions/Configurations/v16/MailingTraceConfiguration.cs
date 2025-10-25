using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
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

                        entity.ToTable("mailing_trace");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.CampaignId, "mailing_trace__campaign_id_index").HasFilter("(campaign_id IS NOT NULL)");

                        entity.HasIndex(e => e.MailMailId, "mailing_trace__mail_mail_id_index").HasFilter("(mail_mail_id IS NOT NULL)");

                        entity.HasIndex(e => e.MailMailIdInt, "mailing_trace__mail_mail_id_int_index").HasFilter("(mail_mail_id_int IS NOT NULL)");

                        entity.HasIndex(e => e.MassMailingId, "mailing_trace__mass_mailing_id_index");

                        entity.HasIndex(e => e.SmsIdInt, "mailing_trace__sms_id_int_index").HasFilter("(sms_id_int IS NOT NULL)");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.CampaignId).HasColumnName("campaign_id");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.Email).HasColumnName("email");
                        entity.Property(e => e.FailureReason).HasColumnName("failure_reason");
                        entity.Property(e => e.FailureType).HasColumnName("failure_type");
                        entity.Property(e => e.LinksClickDatetime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("links_click_datetime");
                        entity.Property(e => e.MailMailId).HasColumnName("mail_mail_id");
                        entity.Property(e => e.MailMailIdInt).HasColumnName("mail_mail_id_int");
                        entity.Property(e => e.MassMailingId).HasColumnName("mass_mailing_id");
                        entity.Property(e => e.MessageId).HasColumnName("message_id");
                        entity.Property(e => e.Model).HasColumnName("model");
                        entity.Property(e => e.OpenDatetime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("open_datetime");
                        entity.Property(e => e.ReplyDatetime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("reply_datetime");
                        entity.Property(e => e.ResId).HasColumnName("res_id");
                        entity.Property(e => e.SentDatetime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("sent_datetime");
                        entity.Property(e => e.SmsCode).HasColumnName("sms_code");
                        entity.Property(e => e.SmsIdInt).HasColumnName("sms_id_int");
                        entity.Property(e => e.SmsNumber).HasColumnName("sms_number");
                        entity.Property(e => e.TraceStatus).HasColumnName("trace_status");
                        entity.Property(e => e.TraceType).HasColumnName("trace_type");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        entity.HasOne(d => d.Campaign).WithMany(p => p.MailingTrace)
                            .HasForeignKey(d => d.CampaignId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mailing_trace_campaign_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.MailingTraceCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("mailing_trace_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mailing_trace_create_uid_fkey");

                        entity.HasOne(d => d.MailMail).WithMany(p => p.MailingTrace)
                            .HasForeignKey(d => d.MailMailId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mailing_trace_mail_mail_id_fkey");

                        entity.HasOne(d => d.MassMailing).WithMany(p => p.MailingTrace)
                            .HasForeignKey(d => d.MassMailingId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("mailing_trace_mass_mailing_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.MailingTraceWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("mailing_trace_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mailing_trace_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}