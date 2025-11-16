using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureProductFeed(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<ProductFeed>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("product_feed_pkey");

                        entity.ToTable("product_feed");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.AccessToken).HasColumnName("access_token");
                        entity.Property(e => e.CacheExpiry)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("cache_expiry");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.LangId).HasColumnName("lang_id");
                        entity.Property(e => e.LastNotificationDate).HasColumnName("last_notification_date");
                        entity.Property(e => e.Name).HasColumnName("name");
                        entity.Property(e => e.PricelistId).HasColumnName("pricelist_id");
                        entity.Property(e => e.Target).HasColumnName("target");
                        entity.Property(e => e.WebsiteId).HasColumnName("website_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.ProductFeedCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("product_feed_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("product_feed_create_uid_fkey");

                        entity.HasOne(d => d.Lang).WithMany(p => p.ProductFeed)
                            .HasForeignKey(d => d.LangId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("product_feed_lang_id_fkey");

                        entity.HasOne(d => d.Pricelist).WithMany(p => p.ProductFeed)
                            .HasForeignKey(d => d.PricelistId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("product_feed_pricelist_id_fkey");

                        // entity.HasOne(d => d.Website).WithMany(p => p.ProductFeed) .HasForeignKey(d => d.WebsiteId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("product_feed_website_id_fkey");
                        entity.HasOne(d => d.Website).WithMany()
                            .HasForeignKey(d => d.WebsiteId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("product_feed_website_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.ProductFeedWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("product_feed_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("product_feed_write_uid_fkey");

                        // entity.HasMany(d => d.ProductPublicCategory).WithMany(p => p.ProductFeed)
                        entity.HasMany(d => d.ProductPublicCategory).WithMany(p => p.ProductFeed)
                            .UsingEntity<Dictionary<string, object>>(
                                "ProductFeedProductPublicCategoryRel",
                                r => r.HasOne<ProductPublicCategory>().WithMany()
                                    .HasForeignKey("ProductPublicCategoryId")
                                    .HasConstraintName("product_feed_product_public_cat_product_public_category_id_fkey"),
                                l => l.HasOne<ProductFeed>().WithMany()
                                    .HasForeignKey("ProductFeedId")
                                    .HasConstraintName("product_feed_product_public_category_rel_product_feed_id_fkey"),
                                j =>
                                {
                                    j.HasKey("ProductFeedId", "ProductPublicCategoryId").HasName("product_feed_product_public_category_rel_pkey");
                                    j.ToTable("product_feed_product_public_category_rel");
                                    j.HasIndex(new[] { "ProductPublicCategoryId", "ProductFeedId" }, "product_feed_product_public_c_product_public_category_id_pr_idx");
                                    j.IndexerProperty<Guid>("ProductFeedId").HasColumnName("product_feed_id");
                                    j.IndexerProperty<Guid>("ProductPublicCategoryId").HasColumnName("product_public_category_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}