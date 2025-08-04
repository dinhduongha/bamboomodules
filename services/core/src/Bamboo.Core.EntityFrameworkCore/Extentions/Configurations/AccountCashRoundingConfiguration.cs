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
        public static void ConfigureAccountCashRounding(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountCashRounding>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("account_cash_rounding_pkey");

                entity.ToTable("account_cash_rounding");

                entity.HasIndex(e => e.TenantId, "account_cash_rounding_company_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.LossAccountId)
                    .HasColumnType("jsonb")
                    .HasColumnName("loss_account_id");
                entity.Property(e => e.Name)
                    .HasColumnType("jsonb")
                    .HasColumnName("name");
                entity.Property(e => e.ProfitAccountId)
                    .HasColumnType("jsonb")
                    .HasColumnName("profit_account_id");
                entity.Property(e => e.Rounding).HasColumnName("rounding");
                entity.Property(e => e.RoundingMethod).HasColumnName("rounding_method");
                entity.Property(e => e.Strategy).HasColumnName("strategy");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_cash_rounding_create_uid_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_cash_rounding_write_uid_fkey");
            });
        }
    }
}