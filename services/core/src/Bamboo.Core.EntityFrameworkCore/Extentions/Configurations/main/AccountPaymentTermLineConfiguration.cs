using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureAccountPaymentTermLine(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<AccountPaymentTermLine>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("account_payment_term_line_pkey");

                        entity.ToTable("account_payment_term_line");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.PaymentId, "account_payment_term_line__payment_id_index");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.DaysNextMonth).HasColumnName("days_next_month");
                        entity.Property(e => e.DelayType).HasColumnName("delay_type");
                        entity.Property(e => e.NbDays).HasColumnName("nb_days");
                        entity.Property(e => e.PaymentId).HasColumnName("payment_id");
                        entity.Property(e => e.Value).HasColumnName("value");
                        entity.Property(e => e.ValueAmount).HasColumnName("value_amount");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.AccountPaymentTermLineCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("account_payment_term_line_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_payment_term_line_create_uid_fkey");

                        entity.HasOne(d => d.Payment).WithMany(p => p.AccountPaymentTermLine)
                            .HasForeignKey(d => d.PaymentId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("account_payment_term_line_payment_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.AccountPaymentTermLineWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("account_payment_term_line_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_payment_term_line_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}