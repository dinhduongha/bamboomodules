using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureAccountAccruedOrdersWizard(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<AccountAccruedOrdersWizard>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("account_accrued_orders_wizard_pkey");

                        entity.ToTable("account_accrued_orders_wizard");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("next_uuid()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.AccountId).HasColumnName("account_id");
                        entity.Property(e => e.Amount).HasColumnName("amount");

                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
                        entity.Property(e => e.Date).HasColumnName("date");
                        entity.Property(e => e.JournalId).HasColumnName("journal_id");
                        entity.Property(e => e.ReversalDate).HasColumnName("reversal_date");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.Account).WithMany(p => p.AccountAccruedOrdersWizard) .HasForeignKey(d => d.AccountId) .OnDelete(DeleteBehavior.Cascade) .HasConstraintName("account_accrued_orders_wizard_account_id_fkey");
                        entity.HasOne(d => d.Account).WithMany()
                            .HasForeignKey(d => d.AccountId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("account_accrued_orders_wizard_account_id_fkey");

                        // entity.HasOne(d => d.Company).WithMany(p => p.AccountAccruedOrdersWizard) .HasForeignKey(d => d.TenantId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("account_accrued_orders_wizard_company_id_fkey");
                        entity.HasOne(d => d.Company).WithMany()
                            .HasForeignKey(d => d.TenantId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_accrued_orders_wizard_company_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.AccountAccruedOrdersWizardCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("account_accrued_orders_wizard_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_accrued_orders_wizard_create_uid_fkey");

                        // entity.HasOne(d => d.Currency).WithMany(p => p.AccountAccruedOrdersWizard) .HasForeignKey(d => d.CurrencyId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("account_accrued_orders_wizard_currency_id_fkey");
                        entity.HasOne(d => d.Currency).WithMany()
                            .HasForeignKey(d => d.CurrencyId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_accrued_orders_wizard_currency_id_fkey");

                        // entity.HasOne(d => d.Journal).WithMany(p => p.AccountAccruedOrdersWizard) .HasForeignKey(d => d.JournalId) .OnDelete(DeleteBehavior.Cascade) .HasConstraintName("account_accrued_orders_wizard_journal_id_fkey");
                        entity.HasOne(d => d.Journal).WithMany()
                            .HasForeignKey(d => d.JournalId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("account_accrued_orders_wizard_journal_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.AccountAccruedOrdersWizardWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("account_accrued_orders_wizard_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_accrued_orders_wizard_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}