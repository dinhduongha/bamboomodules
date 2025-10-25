using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureProductPricelistItem(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<ProductPricelistItem>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("product_pricelist_item_pkey");

                        entity.ToTable("product_pricelist_item");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.ComputePrice, "product_pricelist_item__compute_price_index");

                        entity.HasIndex(e => e.PricelistId, "product_pricelist_item__pricelist_id_index");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.AppliedOn).HasColumnName("applied_on");
                        entity.Property(e => e.Base).HasColumnName("base");
                        entity.Property(e => e.BasePricelistId).HasColumnName("base_pricelist_id");
                        entity.Property(e => e.CategId).HasColumnName("categ_id");

                        entity.Property(e => e.ComputePrice).HasColumnName("compute_price");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
                        entity.Property(e => e.DateEnd)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("date_end");
                        entity.Property(e => e.DateStart)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("date_start");
                        entity.Property(e => e.DisplayAppliedOn).HasColumnName("display_applied_on");
                        entity.Property(e => e.FixedPrice).HasColumnName("fixed_price");
                        entity.Property(e => e.MinQuantity).HasColumnName("min_quantity");
                        entity.Property(e => e.PercentPrice).HasColumnName("percent_price");
                        entity.Property(e => e.PriceDiscount).HasColumnName("price_discount");
                        entity.Property(e => e.PriceMarkup).HasColumnName("price_markup");
                        entity.Property(e => e.PriceMaxMargin).HasColumnName("price_max_margin");
                        entity.Property(e => e.PriceMinMargin).HasColumnName("price_min_margin");
                        entity.Property(e => e.PriceRound).HasColumnName("price_round");
                        entity.Property(e => e.PriceSurcharge).HasColumnName("price_surcharge");
                        entity.Property(e => e.PricelistId).HasColumnName("pricelist_id");
                        entity.Property(e => e.ProductId).HasColumnName("product_id");
                        entity.Property(e => e.ProductTmplId).HasColumnName("product_tmpl_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        entity.HasOne(d => d.BasePricelist).WithMany(p => p.ProductPricelistItemBasePricelist)
                            .HasForeignKey(d => d.BasePricelistId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("product_pricelist_item_base_pricelist_id_fkey");

                        entity.HasOne(d => d.Categ).WithMany(p => p.ProductPricelistItem)
                            .HasForeignKey(d => d.CategId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("product_pricelist_item_categ_id_fkey");

                        // entity.HasOne(d => d.Company).WithMany(p => p.ProductPricelistItem) .HasForeignKey(d => d.TenantId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("product_pricelist_item_company_id_fkey");
                        entity.HasOne(d => d.Company).WithMany()
                            .HasForeignKey(d => d.TenantId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("product_pricelist_item_company_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.ProductPricelistItemCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("product_pricelist_item_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("product_pricelist_item_create_uid_fkey");

                        // entity.HasOne(d => d.Currency).WithMany(p => p.ProductPricelistItem) .HasForeignKey(d => d.CurrencyId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("product_pricelist_item_currency_id_fkey");
                        entity.HasOne(d => d.Currency).WithMany()
                            .HasForeignKey(d => d.CurrencyId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("product_pricelist_item_currency_id_fkey");

                        entity.HasOne(d => d.Pricelist).WithMany(p => p.ProductPricelistItemPricelist)
                            .HasForeignKey(d => d.PricelistId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("product_pricelist_item_pricelist_id_fkey");

                        // entity.HasOne(d => d.Product).WithMany(p => p.ProductPricelistItem) .HasForeignKey(d => d.ProductId) .OnDelete(DeleteBehavior.Cascade) .HasConstraintName("product_pricelist_item_product_id_fkey");
                        entity.HasOne(d => d.Product).WithMany()
                            .HasForeignKey(d => d.ProductId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("product_pricelist_item_product_id_fkey");

                        entity.HasOne(d => d.ProductTmpl).WithMany(p => p.ProductPricelistItem)
                            .HasForeignKey(d => d.ProductTmplId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("product_pricelist_item_product_tmpl_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.ProductPricelistItemWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("product_pricelist_item_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("product_pricelist_item_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}