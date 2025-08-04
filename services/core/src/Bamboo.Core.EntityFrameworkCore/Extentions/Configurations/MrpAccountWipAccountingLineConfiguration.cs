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
        public static void ConfigureMrpAccountWipAccountingLine(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MrpAccountWipAccountingLine>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("mrp_account_wip_accounting_line_pkey");

                entity.ToTable("mrp_account_wip_accounting_line");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.AccountId).HasColumnName("account_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.Credit).HasColumnName("credit");
                entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
                entity.Property(e => e.Debit).HasColumnName("debit");
                entity.Property(e => e.Label).HasColumnName("label");
                entity.Property(e => e.WipAccountingId).HasColumnName("wip_accounting_id");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne(d => d.Account).WithMany(p => p.MrpAccountWipAccountingLines)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mrp_account_wip_accounting_line_account_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mrp_account_wip_accounting_line_create_uid_fkey");

                entity.HasOne<ResCurrency>().WithMany()
                    .HasForeignKey(d => d.CurrencyId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mrp_account_wip_accounting_line_currency_id_fkey");

                entity.HasOne(d => d.WipAccounting).WithMany(p => p.MrpAccountWipAccountingLines)
                    .HasForeignKey(d => d.WipAccountingId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mrp_account_wip_accounting_line_wip_accounting_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mrp_account_wip_accounting_line_write_uid_fkey");
            });
        }
    }
}