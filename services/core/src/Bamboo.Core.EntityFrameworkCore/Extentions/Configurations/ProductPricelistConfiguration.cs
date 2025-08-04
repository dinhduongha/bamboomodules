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
        public static void ConfigureProductPricelist(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductPricelist>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("product_pricelist_pkey");

                entity.ToTable("product_pricelist");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");    
                entity.Property(e => e.Active).HasColumnName("active");
                entity.Property(e => e.Code).HasColumnName("code");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
                entity.Property(e => e.DiscountPolicy).HasColumnName("discount_policy");
                entity.Property(e => e.Name)
                    .HasColumnType("jsonb")
                    .HasColumnName("name");
                entity.Property(e => e.Selectable).HasColumnName("selectable");
                entity.Property(e => e.Sequence)
                    .HasColumnName("sequence");
                entity.Property(e => e.WebsiteId).HasColumnName("website_id");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResCompany>().WithMany()
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("product_pricelist_company_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("product_pricelist_create_uid_fkey");

                entity.HasOne<ResCurrency>().WithMany()
                    .HasForeignKey(d => d.CurrencyId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("product_pricelist_currency_id_fkey");

                entity.HasOne(d => d.Website).WithMany(p => p.ProductPricelists)
                    .HasForeignKey(d => d.WebsiteId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("product_pricelist_website_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("product_pricelist_write_uid_fkey");

                //entity.HasMany(d => d.ResCountryGroups).WithMany(p => p.Pricelists)
                entity.HasMany<ResCountryGroup>().WithMany()
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
                        });
            });
        }
    }
}