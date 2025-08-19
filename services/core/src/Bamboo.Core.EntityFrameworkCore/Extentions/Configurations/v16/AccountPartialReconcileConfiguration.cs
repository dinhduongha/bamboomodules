using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Bamboo.Core.Models;
// Cần thêm using đến namespace chứa entity của bạn ở đây
// Ví dụ: using YourProject.Entities;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureAccountPartialReconcile(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<AccountPartialReconcile>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("account_partial_reconcile_pkey");

            entity.ToTable("account_partial_reconcile");

            entity.HasIndex(e => e.TenantId);

            entity.HasIndex(e => e.OrganizationUnitId);

            entity.HasIndex(e => e.CreditMoveId, "account_partial_reconcile_credit_move_id_index");

            entity.HasIndex(e => e.DebitMoveId, "account_partial_reconcile_debit_move_id_index");

            entity.HasIndex(e => e.ExchangeMoveId, "account_partial_reconcile_exchange_move_id_index").HasFilter("(exchange_move_id IS NOT NULL)");

            entity.HasIndex(e => e.FullReconcileId, "account_partial_reconcile_full_reconcile_id_index").HasFilter("(full_reconcile_id IS NOT NULL)");

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
            entity.Property(e => e.CreditAmountCurrency).HasColumnName("credit_amount_currency");
            entity.Property(e => e.CreditCurrencyId).HasColumnName("credit_currency_id");
            entity.Property(e => e.CreditMoveId).HasColumnName("credit_move_id");
            entity.Property(e => e.DebitAmountCurrency).HasColumnName("debit_amount_currency");
            entity.Property(e => e.DebitCurrencyId).HasColumnName("debit_currency_id");
            entity.Property(e => e.DebitMoveId).HasColumnName("debit_move_id");
            entity.Property(e => e.ExchangeMoveId).HasColumnName("exchange_move_id");
            entity.Property(e => e.FullReconcileId).HasColumnName("full_reconcile_id");
            entity.Property(e => e.MaxDate).HasColumnName("max_date");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.Company).WithMany(p => p.AccountPartialReconcile)
            entity.HasOne(d => d.Company).WithMany()
                .HasForeignKey(d => d.TenantId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("account_partial_reconcile_company_id_fkey");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.AccountPartialReconcileCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("account_partial_reconcile_create_uid_fkey");

            entity.HasOne(d => d.CreditCurrency).WithMany()
                .HasForeignKey(d => d.CreditCurrencyId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("account_partial_reconcile_credit_currency_id_fkey");

            entity.HasOne(d => d.CreditMove).WithMany(p => p.AccountPartialReconcileCreditMove)
                .HasForeignKey(d => d.CreditMoveId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("account_partial_reconcile_credit_move_id_fkey");

            entity.HasOne(d => d.DebitCurrency).WithMany()
                .HasForeignKey(d => d.DebitCurrencyId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("account_partial_reconcile_debit_currency_id_fkey");

            entity.HasOne(d => d.DebitMove).WithMany(p => p.AccountPartialReconcileDebitMove)
                .HasForeignKey(d => d.DebitMoveId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("account_partial_reconcile_debit_move_id_fkey");

            entity.HasOne(d => d.ExchangeMove).WithMany(p => p.AccountPartialReconcile)
                .HasForeignKey(d => d.ExchangeMoveId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("account_partial_reconcile_exchange_move_id_fkey");

            entity.HasOne(d => d.FullReconcile).WithMany(p => p.AccountPartialReconcile)
                .HasForeignKey(d => d.FullReconcileId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("account_partial_reconcile_full_reconcile_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.AccountPartialReconcileWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("account_partial_reconcile_write_uid_fkey");
            });
        }
    }
}