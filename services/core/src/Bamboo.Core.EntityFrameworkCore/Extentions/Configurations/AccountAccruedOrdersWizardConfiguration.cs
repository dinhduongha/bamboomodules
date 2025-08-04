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
        public static void ConfigureAccountAccruedOrdersWizard(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountAccruedOrdersWizard>(entity =>
            {
                    entity.HasKey(e => e.Id).HasName("account_accrued_orders_wizard_pkey");

                    entity.ToTable("account_accrued_orders_wizard");

                    entity.Property(e => e.Id)
                        .HasDefaultValueSql("next_uuid()")
                        .HasColumnName("id");
                    entity.Property(e => e.TenantId).HasColumnName("company_id");
                    entity.Property(e => e.AccountId).HasColumnName("account_id");
                    entity.Property(e => e.Amount).HasColumnName("amount");
                    entity.Property(e => e.TenantId).HasColumnName("company_id");
                    entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
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

                    entity.HasOne(d => d.Account).WithMany(p => p.AccountAccruedOrdersWizards)
                        .HasForeignKey(d => d.AccountId)
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("account_accrued_orders_wizard_account_id_fkey");

                    entity.HasOne<ResCompany>().WithMany()
                        .HasForeignKey(d => d.TenantId)
                        .OnDelete(DeleteBehavior.SetNull)
                        .HasConstraintName("account_accrued_orders_wizard_company_id_fkey");

                    entity.HasOne<ResUser>().WithMany()
                        .HasForeignKey(d => d.CreatorId)
                        .OnDelete(DeleteBehavior.SetNull)
                        .HasConstraintName("account_accrued_orders_wizard_create_uid_fkey");

                    entity.HasOne<ResCurrency>().WithMany()
                        .HasForeignKey(d => d.CurrencyId)
                        .OnDelete(DeleteBehavior.SetNull)
                        .HasConstraintName("account_accrued_orders_wizard_currency_id_fkey");

                // TODO: RELATION CHECK
                //entity.HasOne(d => d.Journal).WithMany(p => p.AccountAccruedOrdersWizards)
                entity.HasOne(d => d.Journal).WithMany()
                        .HasForeignKey(d => d.JournalId)
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("account_accrued_orders_wizard_journal_id_fkey");

                    entity.HasOne<ResUser>().WithMany()
                        .HasForeignKey(d => d.LastModifierId)
                        .OnDelete(DeleteBehavior.SetNull)
                        .HasConstraintName("account_accrued_orders_wizard_write_uid_fkey");
            });
        }
    }
}