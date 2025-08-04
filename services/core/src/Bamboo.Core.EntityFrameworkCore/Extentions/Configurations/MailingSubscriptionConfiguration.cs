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
        public static void ConfigureMailingSubscription(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MailingSubscription>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("mailing_subscription_pkey");

                entity.ToTable("mailing_subscription");

                entity.HasIndex(e => new { e.ContactId, e.ListId }, "mailing_subscription_unique_contact_list").IsUnique();

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.ContactId).HasColumnName("contact_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.ListId).HasColumnName("list_id");
                entity.Property(e => e.OptOut).HasColumnName("opt_out");
                entity.Property(e => e.OptOutDatetime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("opt_out_datetime");
                entity.Property(e => e.OptOutReasonId).HasColumnName("opt_out_reason_id");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne(d => d.Contact).WithMany(p => p.MailingSubscriptions)
                    .HasForeignKey(d => d.ContactId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("mailing_subscription_contact_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mailing_subscription_create_uid_fkey");

                entity.HasOne(d => d.List).WithMany(p => p.MailingSubscriptions)
                    .HasForeignKey(d => d.ListId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("mailing_subscription_list_id_fkey");

                entity.HasOne(d => d.OptOutReason).WithMany(p => p.MailingSubscriptions)
                    .HasForeignKey(d => d.OptOutReasonId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("mailing_subscription_opt_out_reason_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mailing_subscription_write_uid_fkey");
            });
        }
    }
}