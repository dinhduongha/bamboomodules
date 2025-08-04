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
        public static void ConfigureAccountAssetCategory(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountAssetCategory>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("account_asset_category_pkey");

                entity.ToTable("account_asset_category");

                entity.HasIndex(e => e.Name, "account_asset_category_name_index");

                entity.HasIndex(e => e.Type, "account_asset_category_type_index");

                entity.HasIndex(e => e.AnalyticDistribution, "account_asset_category_analytic_distribution_gin_index").HasMethod("gin");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.AccountAnalyticId).HasColumnName("account_analytic_id");
                entity.Property(e => e.AccountAssetId).HasColumnName("account_asset_id");
                entity.Property(e => e.AccountDepreciationExpenseId).HasColumnName("account_depreciation_expense_id");
                entity.Property(e => e.AccountDepreciationId).HasColumnName("account_depreciation_id");
                entity.Property(e => e.Active).HasColumnName("active");
                entity.Property(e => e.AnalyticDistribution)
                    .HasColumnType("jsonb")
                    .HasColumnName("analytic_distribution");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.DateFirstDepreciation).HasColumnName("date_first_depreciation");
                entity.Property(e => e.GroupEntries).HasColumnName("group_entries");
                entity.Property(e => e.JournalId).HasColumnName("journal_id");
                entity.Property(e => e.MessageMainAttachmentId).HasColumnName("message_main_attachment_id");
                entity.Property(e => e.Method).HasColumnName("method");
                entity.Property(e => e.MethodEnd).HasColumnName("method_end");
                entity.Property(e => e.MethodNumber).HasColumnName("method_number");
                entity.Property(e => e.MethodPeriod).HasColumnName("method_period");
                entity.Property(e => e.MethodProgressFactor).HasColumnName("method_progress_factor");
                entity.Property(e => e.MethodTime).HasColumnName("method_time");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.OpenAsset).HasColumnName("open_asset");
                entity.Property(e => e.Prorata).HasColumnName("prorata");
                entity.Property(e => e.Type).HasColumnName("type");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne(d => d.AccountAnalytic).WithMany(p => p.AccountAssetCategories)
                    .HasForeignKey(d => d.AccountAnalyticId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_asset_category_account_analytic_id_fkey");

                entity.HasOne(d => d.AccountAsset).WithMany(p => p.AccountAssetCategoryAccountAssets)
                    .HasForeignKey(d => d.AccountAssetId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("account_asset_category_account_asset_id_fkey");

                entity.HasOne(d => d.AccountDepreciationExpense).WithMany(p => p.AccountAssetCategoryAccountDepreciationExpenses)
                    .HasForeignKey(d => d.AccountDepreciationExpenseId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("account_asset_category_account_depreciation_expense_id_fkey");

                entity.HasOne(d => d.AccountDepreciation).WithMany(p => p.AccountAssetCategoryAccountDepreciations)
                    .HasForeignKey(d => d.AccountDepreciationId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("account_asset_category_account_depreciation_id_fkey");

                entity.HasOne<ResCompany>().WithMany()
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("account_asset_category_company_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_asset_category_create_uid_fkey");

                entity.HasOne(d => d.Journal).WithMany(p => p.AccountAssetCategories)
                    .HasForeignKey(d => d.JournalId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("account_asset_category_journal_id_fkey");

                entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.AccountAssetCategories)
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_asset_category_message_main_attachment_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_asset_category_write_uid_fkey");
            });
        }
    }
}