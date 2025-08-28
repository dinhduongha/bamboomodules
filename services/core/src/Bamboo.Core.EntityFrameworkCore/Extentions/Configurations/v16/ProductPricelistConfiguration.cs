using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureProductPricelist(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<ProductPricelist>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("product_pricelist_pkey");

                        entity.ToTable("product_pricelist");

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
                        entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
                        entity.Property(e => e.Name)
                            .HasColumnType("jsonb")
                            .HasColumnName("name");
                        entity.Property(e => e.Selectable).HasColumnName("selectable");
                        entity.Property(e => e.Sequence).HasColumnName("sequence");
                        entity.Property(e => e.WebsiteId).HasColumnName("website_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.Company).WithMany(p => p.ProductPricelist) .HasForeignKey(d => d.TenantId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("product_pricelist_company_id_fkey");
                        entity.HasOne(d => d.Company).WithMany()
                            .HasForeignKey(d => d.TenantId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("product_pricelist_company_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.ProductPricelistCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("product_pricelist_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("product_pricelist_create_uid_fkey");

                        // entity.HasOne(d => d.Currency).WithMany(p => p.ProductPricelist) .HasForeignKey(d => d.CurrencyId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("product_pricelist_currency_id_fkey");
                        entity.HasOne(d => d.Currency).WithMany()
                            .HasForeignKey(d => d.CurrencyId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("product_pricelist_currency_id_fkey");

                        // entity.HasOne(d => d.Website).WithMany(p => p.ProductPricelist) .HasForeignKey(d => d.WebsiteId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("product_pricelist_website_id_fkey");
                        entity.HasOne(d => d.Website).WithMany()
                            .HasForeignKey(d => d.WebsiteId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("product_pricelist_website_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.ProductPricelistWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("product_pricelist_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("product_pricelist_write_uid_fkey");

                        // entity.HasMany(d => d.ResCountryGroup).WithMany(p => p.Pricelist)
                        entity.HasMany(d => d.ResCountryGroup).WithMany(p => p.Pricelist)
                            .UsingEntity<Dictionary<string, object>>(
                                "ResCountryGroupPricelistRel",
                                r => r.HasOne<ResCountryGroup>().WithMany()
                                    .HasForeignKey("ResCountryGroupId")
                                    .HasConstraintName("res_country_group_pricelist_rel_res_country_group_id_fkey"),
                                l => l.HasOne<ProductPricelist>().WithMany()
                                    .HasForeignKey("PricelistId")
                                    .HasConstraintName("res_country_group_pricelist_rel_pricelist_id_fkey"),
                                j =>
                                {
                                    j.HasKey("PricelistId", "ResCountryGroupId").HasName("res_country_group_pricelist_rel_pkey");
                                    j.ToTable("res_country_group_pricelist_rel");
                                    j.HasIndex(new[] { "ResCountryGroupId", "PricelistId" }, "res_country_group_pricelist_r_res_country_group_id_pricelis_idx");
                                    j.IndexerProperty<Guid>("PricelistId").HasColumnName("pricelist_id");
                                    j.IndexerProperty<Guid>("ResCountryGroupId").HasColumnName("res_country_group_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}