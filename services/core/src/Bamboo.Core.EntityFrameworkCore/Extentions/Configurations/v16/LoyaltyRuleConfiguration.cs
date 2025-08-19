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
        public static void ConfigureLoyaltyRule(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<LoyaltyRule>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("loyalty_rule_pkey");

            entity.ToTable("loyalty_rule");

            entity.HasIndex(e => e.TenantId);

            entity.HasIndex(e => e.OrganizationUnitId);

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");

            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.Code).HasColumnName("code");

            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.MinimumAmount).HasColumnName("minimum_amount");
            entity.Property(e => e.MinimumAmountTaxMode).HasColumnName("minimum_amount_tax_mode");
            entity.Property(e => e.MinimumQty).HasColumnName("minimum_qty");
            entity.Property(e => e.Mode).HasColumnName("mode");
            entity.Property(e => e.ProductCategoryId).HasColumnName("product_category_id");
            entity.Property(e => e.ProductDomain).HasColumnName("product_domain");
            entity.Property(e => e.ProductTagId).HasColumnName("product_tag_id");
            entity.Property(e => e.ProgramId).HasColumnName("program_id");
            entity.Property(e => e.PromoBarcode).HasColumnName("promo_barcode");
            entity.Property(e => e.RewardPointAmount).HasColumnName("reward_point_amount");
            entity.Property(e => e.RewardPointMode).HasColumnName("reward_point_mode");
            entity.Property(e => e.RewardPointSplit).HasColumnName("reward_point_split");
            entity.Property(e => e.WebsiteId).HasColumnName("website_id");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.Company).WithMany(p => p.LoyaltyRule)
            entity.HasOne(d => d.Company).WithMany()
                .HasForeignKey(d => d.TenantId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("loyalty_rule_company_id_fkey");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.LoyaltyRuleCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("loyalty_rule_create_uid_fkey");

            entity.HasOne(d => d.ProductCategory).WithMany(p => p.LoyaltyRule)
                .HasForeignKey(d => d.ProductCategoryId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("loyalty_rule_product_category_id_fkey");

            entity.HasOne(d => d.ProductTag).WithMany(p => p.LoyaltyRule)
                .HasForeignKey(d => d.ProductTagId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("loyalty_rule_product_tag_id_fkey");

            entity.HasOne(d => d.Program).WithMany(p => p.LoyaltyRule)
                .HasForeignKey(d => d.ProgramId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("loyalty_rule_program_id_fkey");

            // entity.HasOne(d => d.Website).WithMany(p => p.LoyaltyRule)
            entity.HasOne(d => d.Website).WithMany()
                .HasForeignKey(d => d.WebsiteId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("loyalty_rule_website_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.LoyaltyRuleWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("loyalty_rule_write_uid_fkey");

            // entity.HasMany(d => d.ProductProduct).WithMany(p => p.LoyaltyRule)
            entity.HasMany(d => d.ProductProduct).WithMany()
                .UsingEntity<Dictionary<string, object>>(
                    "LoyaltyRuleProductProductRel",
                    r => r.HasOne<ProductProduct>().WithMany()
                        .HasForeignKey("ProductProductId")
                        .HasConstraintName("loyalty_rule_product_product_rel_product_product_id_fkey"),
                    l => l.HasOne<LoyaltyRule>().WithMany()
                        .HasForeignKey("LoyaltyRuleId")
                        .HasConstraintName("loyalty_rule_product_product_rel_loyalty_rule_id_fkey"),
                    j =>
                    {
                        j.HasKey("LoyaltyRuleId", "ProductProductId").HasName("loyalty_rule_product_product_rel_pkey");
                        j.ToTable("loyalty_rule_product_product_rel");
                        j.HasIndex(new[] { "ProductProductId", "LoyaltyRuleId" }, "loyalty_rule_product_product__product_product_id_loyalty_ru_idx");
                        j.IndexerProperty<Guid>("LoyaltyRuleId").HasColumnName("loyalty_rule_id");
                        j.IndexerProperty<Guid>("ProductProductId").HasColumnName("product_product_id");
                    });
            });
        }
    }
}