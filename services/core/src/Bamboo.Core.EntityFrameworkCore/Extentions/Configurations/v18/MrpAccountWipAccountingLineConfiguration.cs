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
        public static void ConfigureMrpAccountWipAccountingLine(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<MrpAccountWipAccountingLine>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("mrp_account_wip_accounting_line_pkey");

            entity.ToTable("mrp_account_wip_accounting_line");

            entity.HasIndex(e => e.TenantId);

            entity.HasIndex(e => e.OrganizationUnitId);

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");

            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
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

            // entity.HasOne(d => d.Account).WithMany(p => p.MrpAccountWipAccountingLine)
            entity.HasOne(d => d.Account).WithMany()
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("mrp_account_wip_accounting_line_account_id_fkey");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.MrpAccountWipAccountingLineCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("mrp_account_wip_accounting_line_create_uid_fkey");

            // entity.HasOne(d => d.Currency).WithMany(p => p.MrpAccountWipAccountingLine)
            entity.HasOne(d => d.Currency).WithMany()
                .HasForeignKey(d => d.CurrencyId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("mrp_account_wip_accounting_line_currency_id_fkey");

            entity.HasOne(d => d.WipAccounting).WithMany(p => p.MrpAccountWipAccountingLine)
                .HasForeignKey(d => d.WipAccountingId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("mrp_account_wip_accounting_line_wip_accounting_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.MrpAccountWipAccountingLineWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("mrp_account_wip_accounting_line_write_uid_fkey");
            });
        }
    }
}