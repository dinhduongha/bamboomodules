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
        public static void ConfigureAccountFiscalPositionAccount(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountFiscalPositionAccount>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("account_fiscal_position_account_pkey");

                entity.ToTable("account_fiscal_position_account");

                entity.HasIndex(e => e.TenantId, "account_fiscal_position_account_company_id_index");

                entity.HasIndex(e => new { e.TenantId, e.PositionId, e.AccountSrcId, e.AccountDestId }, "account_fiscal_position_account_account_src_dest_uniq").IsUnique();

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.AccountDestId).HasColumnName("account_dest_id");
                entity.Property(e => e.AccountSrcId).HasColumnName("account_src_id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.PositionId).HasColumnName("position_id");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne(d => d.AccountDest).WithMany(p => p.AccountFiscalPositionAccountAccountDests)
                    .HasForeignKey(d => d.AccountDestId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("account_fiscal_position_account_account_dest_id_fkey");

                entity.HasOne(d => d.AccountSrc).WithMany(p => p.AccountFiscalPositionAccountAccountSrcs)
                    .HasForeignKey(d => d.AccountSrcId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("account_fiscal_position_account_account_src_id_fkey");

                entity.HasOne<ResCompany>().WithMany()
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_fiscal_position_account_company_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_fiscal_position_account_create_uid_fkey");

                entity.HasOne(d => d.Position).WithMany(p => p.AccountFiscalPositionAccounts)
                    .HasForeignKey(d => d.PositionId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("account_fiscal_position_account_position_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_fiscal_position_account_write_uid_fkey");
            });
        }
    }
}