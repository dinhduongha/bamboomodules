using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
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

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.Name, "account_asset_category__name_index");

                        entity.HasIndex(e => e.Type, "account_asset_category__type_index");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.AccountAnalyticId).HasColumnName("account_analytic_id");
                        entity.Property(e => e.AccountAssetId).HasColumnName("account_asset_id");
                        entity.Property(e => e.AccountDepreciationExpenseId).HasColumnName("account_depreciation_expense_id");
                        entity.Property(e => e.AccountDepreciationId).HasColumnName("account_depreciation_id");
                        entity.Property(e => e.Active).HasColumnName("active");
                        entity.Property(e => e.AnalyticDistribution)
                            .HasColumnType("jsonb")
                            .HasColumnName("analytic_distribution");

                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.DateFirstDepreciation).HasColumnName("date_first_depreciation");
                        entity.Property(e => e.GroupEntries).HasColumnName("group_entries");
                        entity.Property(e => e.JournalId).HasColumnName("journal_id");
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

                        entity.HasOne(d => d.AccountAnalytic).WithMany(p => p.AccountAssetCategory)
                            .HasForeignKey(d => d.AccountAnalyticId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_asset_category_account_analytic_id_fkey");

                        // entity.HasOne(d => d.AccountAsset).WithMany(p => p.AccountAssetCategoryAccountAsset) .HasForeignKey(d => d.AccountAssetId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("account_asset_category_account_asset_id_fkey");
                        entity.HasOne(d => d.AccountAsset).WithMany()
                            .HasForeignKey(d => d.AccountAssetId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("account_asset_category_account_asset_id_fkey");

                        // entity.HasOne(d => d.AccountDepreciationExpense).WithMany(p => p.AccountAssetCategoryAccountDepreciationExpense) .HasForeignKey(d => d.AccountDepreciationExpenseId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("account_asset_category_account_depreciation_expense_id_fkey");
                        entity.HasOne(d => d.AccountDepreciationExpense).WithMany()
                            .HasForeignKey(d => d.AccountDepreciationExpenseId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("account_asset_category_account_depreciation_expense_id_fkey");

                        // entity.HasOne(d => d.AccountDepreciation).WithMany(p => p.AccountAssetCategoryAccountDepreciation) .HasForeignKey(d => d.AccountDepreciationId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("account_asset_category_account_depreciation_id_fkey");
                        entity.HasOne(d => d.AccountDepreciation).WithMany()
                            .HasForeignKey(d => d.AccountDepreciationId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("account_asset_category_account_depreciation_id_fkey");

                        // entity.HasOne(d => d.Company).WithMany(p => p.AccountAssetCategory) .HasForeignKey(d => d.TenantId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("account_asset_category_company_id_fkey");
                        entity.HasOne(d => d.Company).WithMany()
                            .HasForeignKey(d => d.TenantId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("account_asset_category_company_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.AccountAssetCategoryCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("account_asset_category_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_asset_category_create_uid_fkey");

                        // entity.HasOne(d => d.Journal).WithMany(p => p.AccountAssetCategory) .HasForeignKey(d => d.JournalId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("account_asset_category_journal_id_fkey");
                        entity.HasOne(d => d.Journal).WithMany()
                            .HasForeignKey(d => d.JournalId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("account_asset_category_journal_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.AccountAssetCategoryWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("account_asset_category_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_asset_category_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}