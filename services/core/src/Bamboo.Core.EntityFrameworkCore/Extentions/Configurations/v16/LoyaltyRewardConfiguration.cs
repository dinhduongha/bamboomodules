using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureLoyaltyReward(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<LoyaltyReward>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("loyalty_reward_pkey");

                        entity.ToTable("loyalty_reward");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("next_uuid()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.Active).HasColumnName("active");
                        entity.Property(e => e.ClearWallet).HasColumnName("clear_wallet");

                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.Description)
                            .HasColumnType("jsonb")
                            .HasColumnName("description");
                        entity.Property(e => e.Discount).HasColumnName("discount");
                        entity.Property(e => e.DiscountApplicability).HasColumnName("discount_applicability");
                        entity.Property(e => e.DiscountLineProductId).HasColumnName("discount_line_product_id");
                        entity.Property(e => e.DiscountMaxAmount).HasColumnName("discount_max_amount");
                        entity.Property(e => e.DiscountMode).HasColumnName("discount_mode");
                        entity.Property(e => e.DiscountProductCategoryId).HasColumnName("discount_product_category_id");
                        entity.Property(e => e.DiscountProductDomain).HasColumnName("discount_product_domain");
                        entity.Property(e => e.DiscountProductTagId).HasColumnName("discount_product_tag_id");
                        entity.Property(e => e.ProgramId).HasColumnName("program_id");
                        entity.Property(e => e.RequiredPoints).HasColumnName("required_points");
                        entity.Property(e => e.RewardProductId).HasColumnName("reward_product_id");
                        entity.Property(e => e.RewardProductQty).HasColumnName("reward_product_qty");
                        entity.Property(e => e.RewardProductTagId).HasColumnName("reward_product_tag_id");
                        entity.Property(e => e.RewardType).HasColumnName("reward_type");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.Company).WithMany(p => p.LoyaltyReward) .HasForeignKey(d => d.TenantId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("loyalty_reward_company_id_fkey");
                        entity.HasOne(d => d.Company).WithMany()
                            .HasForeignKey(d => d.TenantId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("loyalty_reward_company_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.LoyaltyRewardCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("loyalty_reward_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("loyalty_reward_create_uid_fkey");

                        // entity.HasOne(d => d.DiscountLineProduct).WithMany(p => p.LoyaltyRewardDiscountLineProduct) .HasForeignKey(d => d.DiscountLineProductId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("loyalty_reward_discount_line_product_id_fkey");
                        entity.HasOne(d => d.DiscountLineProduct).WithMany()
                            .HasForeignKey(d => d.DiscountLineProductId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("loyalty_reward_discount_line_product_id_fkey");

                        entity.HasOne(d => d.DiscountProductCategory).WithMany(p => p.LoyaltyReward)
                            .HasForeignKey(d => d.DiscountProductCategoryId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("loyalty_reward_discount_product_category_id_fkey");

                        entity.HasOne(d => d.DiscountProductTag).WithMany(p => p.LoyaltyRewardDiscountProductTag)
                            .HasForeignKey(d => d.DiscountProductTagId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("loyalty_reward_discount_product_tag_id_fkey");

                        entity.HasOne(d => d.Program).WithMany(p => p.LoyaltyReward)
                            .HasForeignKey(d => d.ProgramId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("loyalty_reward_program_id_fkey");

                        // entity.HasOne(d => d.RewardProduct).WithMany(p => p.LoyaltyRewardRewardProduct) .HasForeignKey(d => d.RewardProductId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("loyalty_reward_reward_product_id_fkey");
                        entity.HasOne(d => d.RewardProduct).WithMany()
                            .HasForeignKey(d => d.RewardProductId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("loyalty_reward_reward_product_id_fkey");

                        entity.HasOne(d => d.RewardProductTag).WithMany(p => p.LoyaltyRewardRewardProductTag)
                            .HasForeignKey(d => d.RewardProductTagId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("loyalty_reward_reward_product_tag_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.LoyaltyRewardWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("loyalty_reward_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("loyalty_reward_write_uid_fkey");

                        // entity.HasMany(d => d.AccountTax).WithMany(p => p.LoyaltyReward)
                        entity.HasMany(d => d.AccountTax).WithMany(p => p.LoyaltyReward)
                            .UsingEntity<Dictionary<string, object>>(
                                "AccountTaxLoyaltyRewardRel",
                                r => r.HasOne<AccountTax>().WithMany()
                                    .HasForeignKey("AccountTaxId")
                                    .HasConstraintName("account_tax_loyalty_reward_rel_account_tax_id_fkey"),
                                l => l.HasOne<LoyaltyReward>().WithMany()
                                    .HasForeignKey("LoyaltyRewardId")
                                    .HasConstraintName("account_tax_loyalty_reward_rel_loyalty_reward_id_fkey"),
                                j =>
                                {
                                    j.HasKey("LoyaltyRewardId", "AccountTaxId").HasName("account_tax_loyalty_reward_rel_pkey");
                                    j.ToTable("account_tax_loyalty_reward_rel");
                                    j.HasIndex(new[] { "AccountTaxId", "LoyaltyRewardId" }, "account_tax_loyalty_reward_re_account_tax_id_loyalty_reward_idx");
                                    j.IndexerProperty<Guid>("LoyaltyRewardId").HasColumnName("loyalty_reward_id");
                                    j.IndexerProperty<Guid>("AccountTaxId").HasColumnName("account_tax_id");
                                });

                        // entity.HasMany(d => d.ProductProduct).WithMany(p => p.LoyaltyReward)
                        entity.HasMany(d => d.ProductProduct).WithMany()
                            .UsingEntity<Dictionary<string, object>>(
                                "LoyaltyRewardProductProductRel",
                                r => r.HasOne<ProductProduct>().WithMany()
                                    .HasForeignKey("ProductProductId")
                                    .HasConstraintName("loyalty_reward_product_product_rel_product_product_id_fkey"),
                                l => l.HasOne<LoyaltyReward>().WithMany()
                                    .HasForeignKey("LoyaltyRewardId")
                                    .HasConstraintName("loyalty_reward_product_product_rel_loyalty_reward_id_fkey"),
                                j =>
                                {
                                    j.HasKey("LoyaltyRewardId", "ProductProductId").HasName("loyalty_reward_product_product_rel_pkey");
                                    j.ToTable("loyalty_reward_product_product_rel");
                                    j.HasIndex(new[] { "ProductProductId", "LoyaltyRewardId" }, "loyalty_reward_product_produc_product_product_id_loyalty_re_idx");
                                    j.IndexerProperty<Guid>("LoyaltyRewardId").HasColumnName("loyalty_reward_id");
                                    j.IndexerProperty<Guid>("ProductProductId").HasColumnName("product_product_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}