using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
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

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.ListId, "mailing_subscription__list_id_index");

                        entity.HasIndex(e => new { e.ContactId, e.ListId }, "mailing_subscription_unique_contact_list").IsUnique();

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.ContactId).HasColumnName("contact_id");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
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

                        entity.HasOne(d => d.Contact).WithMany(p => p.MailingSubscription)
                            .HasForeignKey(d => d.ContactId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("mailing_subscription_contact_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.MailingSubscriptionCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("mailing_subscription_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mailing_subscription_create_uid_fkey");

                        entity.HasOne(d => d.List).WithMany(p => p.MailingSubscription)
                            .HasForeignKey(d => d.ListId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("mailing_subscription_list_id_fkey");

                        entity.HasOne(d => d.OptOutReason).WithMany(p => p.MailingSubscription)
                            .HasForeignKey(d => d.OptOutReasonId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("mailing_subscription_opt_out_reason_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.MailingSubscriptionWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("mailing_subscription_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mailing_subscription_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}