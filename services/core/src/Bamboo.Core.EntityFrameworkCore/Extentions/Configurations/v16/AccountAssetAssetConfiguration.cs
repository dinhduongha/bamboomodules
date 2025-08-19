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
        public static void ConfigureAccountAssetAsset(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<AccountAssetAsset>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("account_asset_asset_pkey");

            entity.ToTable("account_asset_asset");

            entity.HasIndex(e => e.TenantId);

            entity.HasIndex(e => e.OrganizationUnitId);

            entity.HasIndex(e => e.AnalyticDistribution, "account_asset_asset_analytic_distribution_gin_index").HasMethod("gin");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");

            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
            entity.Property(e => e.AccountAnalyticId).HasColumnName("account_analytic_id");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.AnalyticDistribution)
                .HasColumnType("jsonb")
                .HasColumnName("analytic_distribution");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.Code).HasColumnName("code");

            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.DateFirstDepreciation).HasColumnName("date_first_depreciation");
            entity.Property(e => e.FirstDepreciationManualDate).HasColumnName("first_depreciation_manual_date");
            entity.Property(e => e.InvoiceId).HasColumnName("invoice_id");
            entity.Property(e => e.MessageMainAttachmentId).HasColumnName("message_main_attachment_id");
            entity.Property(e => e.Method).HasColumnName("method");
            entity.Property(e => e.MethodEnd).HasColumnName("method_end");
            entity.Property(e => e.MethodNumber).HasColumnName("method_number");
            entity.Property(e => e.MethodPeriod).HasColumnName("method_period");
            entity.Property(e => e.MethodProgressFactor).HasColumnName("method_progress_factor");
            entity.Property(e => e.MethodTime).HasColumnName("method_time");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Note).HasColumnName("note");
            entity.Property(e => e.PartnerId).HasColumnName("partner_id");
            entity.Property(e => e.Prorata).HasColumnName("prorata");
            entity.Property(e => e.SalvageValue).HasColumnName("salvage_value");
            entity.Property(e => e.State).HasColumnName("state");
            entity.Property(e => e.Value).HasColumnName("value");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            entity.HasOne(d => d.AccountAnalytic).WithMany(p => p.AccountAssetAsset)
                .HasForeignKey(d => d.AccountAnalyticId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("account_asset_asset_account_analytic_id_fkey");

            entity.HasOne(d => d.Category).WithMany(p => p.AccountAssetAsset)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("account_asset_asset_category_id_fkey");

            // entity.HasOne(d => d.Company).WithMany(p => p.AccountAssetAsset)
            entity.HasOne(d => d.Company).WithMany()
                .HasForeignKey(d => d.TenantId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("account_asset_asset_company_id_fkey");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.AccountAssetAssetCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("account_asset_asset_create_uid_fkey");

            // entity.HasOne(d => d.Currency).WithMany(p => p.AccountAssetAsset)
            entity.HasOne(d => d.Currency).WithMany()
                .HasForeignKey(d => d.CurrencyId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("account_asset_asset_currency_id_fkey");

            entity.HasOne(d => d.Invoice).WithMany(p => p.AccountAssetAsset)
                .HasForeignKey(d => d.InvoiceId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("account_asset_asset_invoice_id_fkey");

            // entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.AccountAssetAsset)
            entity.HasOne(d => d.MessageMainAttachment).WithMany()
                .HasForeignKey(d => d.MessageMainAttachmentId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("account_asset_asset_message_main_attachment_id_fkey");

            // entity.HasOne(d => d.Partner).WithMany(p => p.AccountAssetAsset)
            entity.HasOne(d => d.Partner).WithMany()
                .HasForeignKey(d => d.PartnerId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("account_asset_asset_partner_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.AccountAssetAssetWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("account_asset_asset_write_uid_fkey");
            });
        }
    }
}