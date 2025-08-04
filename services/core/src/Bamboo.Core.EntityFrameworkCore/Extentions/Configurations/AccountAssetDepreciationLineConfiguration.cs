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
        public static void ConfigureAccountAssetDepreciationLine(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountAssetDepreciationLine>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("account_asset_depreciation_line_pkey");

                entity.ToTable("account_asset_depreciation_line");

                entity.HasIndex(e => e.TenantId, "account_asset_depreciation_line_company_id_index");
                entity.HasIndex(e => e.DepreciationDate, "account_asset_depreciation_line_depreciation_date_index");

                entity.HasIndex(e => e.Name, "account_asset_depreciation_line_name_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.Amount).HasColumnName("amount");
                entity.Property(e => e.AssetId).HasColumnName("asset_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.DepreciatedValue).HasColumnName("depreciated_value");
                entity.Property(e => e.DepreciationDate).HasColumnName("depreciation_date");
                entity.Property(e => e.MoveCheck).HasColumnName("move_check");
                entity.Property(e => e.MoveId).HasColumnName("move_id");
                entity.Property(e => e.MovePostedCheck).HasColumnName("move_posted_check");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.RemainingValue).HasColumnName("remaining_value");
                entity.Property(e => e.Sequence).HasColumnName("sequence");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne(d => d.Asset).WithMany(p => p.AccountAssetDepreciationLines)
                    .HasForeignKey(d => d.AssetId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("account_asset_depreciation_line_asset_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_asset_depreciation_line_create_uid_fkey");

                entity.HasOne(d => d.Move).WithMany(p => p.AccountAssetDepreciationLines)
                    .HasForeignKey(d => d.MoveId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_asset_depreciation_line_move_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_asset_depreciation_line_write_uid_fkey");
            });
        }
    }
}