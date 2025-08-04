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
        public static void ConfigureAccountFullReconcile(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountFullReconcile>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("account_full_reconcile_pkey");

                entity.ToTable("account_full_reconcile");

                entity.HasIndex(e => e.TenantId, "account_full_reconcile_company_id_index");
                entity.HasIndex(e => e.ExchangeMoveId, "account_full_reconcile__exchange_move_id_index").HasFilter("(exchange_move_id IS NOT NULL)");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.ExchangeMoveId).HasColumnName("exchange_move_id");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_full_reconcile_create_uid_fkey");

                entity.HasOne(d => d.ExchangeMove).WithMany(p => p.AccountFullReconciles)
                    .HasForeignKey(d => d.ExchangeMoveId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_full_reconcile_exchange_move_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_full_reconcile_write_uid_fkey");
            });
        }
    }
}