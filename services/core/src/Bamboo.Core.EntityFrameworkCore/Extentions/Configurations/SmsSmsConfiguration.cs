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
        public static void ConfigureSmsSms(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SmsSms>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("sms_sms_pkey");

                entity.ToTable("sms_sms");

                entity.HasIndex(e => e.TenantId, "sms_sms_company_id_index");

                entity.HasIndex(e => e.MailMessageId, "sms_sms_mail_message_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.Body).HasColumnName("body");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.FailureType).HasColumnName("failure_type");
                entity.Property(e => e.MailMessageId).HasColumnName("mail_message_id");
                entity.Property(e => e.Number).HasColumnName("number");
                entity.Property(e => e.PartnerId).HasColumnName("partner_id");
                entity.Property(e => e.State).HasColumnName("state");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("sms_sms_create_uid_fkey");

                entity.HasOne(d => d.MailMessage).WithMany(p => p.SmsSms)
                    .HasForeignKey(d => d.MailMessageId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("sms_sms_mail_message_id_fkey");

                entity.HasOne<ResPartner>().WithMany()
                    .HasForeignKey(d => d.PartnerId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("sms_sms_partner_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("sms_sms_write_uid_fkey");
            });
        }
    }
}