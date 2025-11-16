using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureSmsSms(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<SmsSms>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("sms_sms_pkey");

                        entity.ToTable("sms_sms");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.MailMessageId, "sms_sms__mail_message_id_index");

                        entity.HasIndex(e => e.Uuid, "sms_sms_uuid_unique").IsUnique();

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.Body).HasColumnName("body");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.FailureType).HasColumnName("failure_type");
                        entity.Property(e => e.MailMessageId).HasColumnName("mail_message_id");
                        entity.Property(e => e.MailingId).HasColumnName("mailing_id");
                        entity.Property(e => e.Number).HasColumnName("number");
                        entity.Property(e => e.PartnerId).HasColumnName("partner_id");
                        entity.Property(e => e.RecordCompanyId).HasColumnName("record_company_id");
                        entity.Property(e => e.State).HasColumnName("state");
                        entity.Property(e => e.ToDelete).HasColumnName("to_delete");
                        entity.Property(e => e.Uuid).HasColumnName("uuid");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.SmsSmsCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("sms_sms_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("sms_sms_create_uid_fkey");

                        entity.HasOne(d => d.MailMessage).WithMany(p => p.SmsSms)
                            .HasForeignKey(d => d.MailMessageId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("sms_sms_mail_message_id_fkey");

                        entity.HasOne(d => d.Mailing).WithMany(p => p.SmsSms)
                            .HasForeignKey(d => d.MailingId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("sms_sms_mailing_id_fkey");

                        // entity.HasOne(d => d.Partner).WithMany(p => p.SmsSms) .HasForeignKey(d => d.PartnerId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("sms_sms_partner_id_fkey");
                        entity.HasOne(d => d.Partner).WithMany()
                            .HasForeignKey(d => d.PartnerId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("sms_sms_partner_id_fkey");

                        // entity.HasOne(d => d.RecordCompany).WithMany(p => p.SmsSms) .HasForeignKey(d => d.RecordCompanyId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("sms_sms_record_company_id_fkey");
                        entity.HasOne(d => d.RecordCompany).WithMany()
                            .HasForeignKey(d => d.RecordCompanyId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("sms_sms_record_company_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.SmsSmsWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("sms_sms_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("sms_sms_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}