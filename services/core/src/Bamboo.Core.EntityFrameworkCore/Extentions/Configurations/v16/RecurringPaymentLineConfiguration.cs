using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureRecurringPaymentLine(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<RecurringPaymentLine>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("recurring_payment_line_pkey");

                        entity.ToTable("recurring_payment_line");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("next_uuid()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.Amount).HasColumnName("amount");

                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.Date).HasColumnName("date");
                        entity.Property(e => e.JournalId).HasColumnName("journal_id");
                        entity.Property(e => e.PartnerId).HasColumnName("partner_id");
                        entity.Property(e => e.PaymentId).HasColumnName("payment_id");
                        entity.Property(e => e.RecurringPaymentId).HasColumnName("recurring_payment_id");
                        entity.Property(e => e.State).HasColumnName("state");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.Company).WithMany(p => p.RecurringPaymentLine) .HasForeignKey(d => d.TenantId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("recurring_payment_line_company_id_fkey");
                        entity.HasOne(d => d.Company).WithMany()
                            .HasForeignKey(d => d.TenantId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("recurring_payment_line_company_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.RecurringPaymentLineCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("recurring_payment_line_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("recurring_payment_line_create_uid_fkey");

                        // entity.HasOne(d => d.Journal).WithMany(p => p.RecurringPaymentLine) .HasForeignKey(d => d.JournalId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("recurring_payment_line_journal_id_fkey");
                        entity.HasOne(d => d.Journal).WithMany()
                            .HasForeignKey(d => d.JournalId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("recurring_payment_line_journal_id_fkey");

                        // entity.HasOne(d => d.Partner).WithMany(p => p.RecurringPaymentLine) .HasForeignKey(d => d.PartnerId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("recurring_payment_line_partner_id_fkey");
                        entity.HasOne(d => d.Partner).WithMany()
                            .HasForeignKey(d => d.PartnerId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("recurring_payment_line_partner_id_fkey");

                        entity.HasOne(d => d.Payment).WithMany(p => p.RecurringPaymentLine)
                            .HasForeignKey(d => d.PaymentId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("recurring_payment_line_payment_id_fkey");

                        entity.HasOne(d => d.RecurringPayment).WithMany(p => p.RecurringPaymentLine)
                            .HasForeignKey(d => d.RecurringPaymentId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("recurring_payment_line_recurring_payment_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.RecurringPaymentLineWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("recurring_payment_line_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("recurring_payment_line_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}