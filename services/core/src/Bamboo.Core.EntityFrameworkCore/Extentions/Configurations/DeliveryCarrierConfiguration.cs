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
        public static void ConfigureDeliveryCarrier(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DeliveryCarrier>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("delivery_carrier_pkey");

                entity.ToTable("delivery_carrier");

                entity.HasIndex(e => e.IsPublished, "delivery_carrier__is_published_index");

                entity.HasIndex(e => e.WebsiteId, "delivery_carrier__website_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.Active).HasColumnName("active");
                entity.Property(e => e.Amount).HasColumnName("amount");
                entity.Property(e => e.CarrierDescription)
                    .HasColumnType("jsonb")
                    .HasColumnName("carrier_description");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.DebugLogging).HasColumnName("debug_logging");
                entity.Property(e => e.DeliveryType).HasColumnName("delivery_type");
                entity.Property(e => e.FixedMargin).HasColumnName("fixed_margin");
                entity.Property(e => e.FixedPrice).HasColumnName("fixed_price");
                entity.Property(e => e.FreeOver).HasColumnName("free_over");
                entity.Property(e => e.GetReturnLabelFromPortal).HasColumnName("get_return_label_from_portal");
                entity.Property(e => e.IntegrationLevel).HasColumnName("integration_level");
                entity.Property(e => e.InvoicePolicy).HasColumnName("invoice_policy");
                entity.Property(e => e.IsPublished).HasColumnName("is_published");
                entity.Property(e => e.Margin).HasColumnName("margin");
                entity.Property(e => e.MaxVolume).HasColumnName("max_volume");
                entity.Property(e => e.MaxWeight).HasColumnName("max_weight");
                entity.Property(e => e.Name)
                    .HasColumnType("jsonb")
                    .HasColumnName("name");
                entity.Property(e => e.ProdEnvironment).HasColumnName("prod_environment");
                entity.Property(e => e.ProductId).HasColumnName("product_id");
                entity.Property(e => e.ReturnLabelOnDelivery).HasColumnName("return_label_on_delivery");
                entity.Property(e => e.Sequence).HasColumnName("sequence");
                entity.Property(e => e.ShippingInsurance).HasColumnName("shipping_insurance");
                entity.Property(e => e.TrackingUrl).HasColumnName("tracking_url");
                entity.Property(e => e.WebsiteId).HasColumnName("website_id");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResCompany>().WithMany()
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("delivery_carrier_company_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("delivery_carrier_create_uid_fkey");

                entity.HasOne(d => d.Product).WithMany()
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("delivery_carrier_product_id_fkey");

                entity.HasOne(d => d.Website).WithMany()
                    .HasForeignKey(d => d.WebsiteId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("delivery_carrier_website_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("delivery_carrier_write_uid_fkey");

                entity.HasMany(d => d.Countries).WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "DeliveryCarrierCountryRel",
                        r => r.HasOne<ResCountry>().WithMany()
                            .HasForeignKey("CountryId")
                            .HasConstraintName("delivery_carrier_country_rel_country_id_fkey"),
                        l => l.HasOne<DeliveryCarrier>().WithMany()
                            .HasForeignKey("CarrierId")
                            .HasConstraintName("delivery_carrier_country_rel_carrier_id_fkey"),
                        j =>
                        {
                            j.HasKey("CarrierId", "CountryId").HasName("delivery_carrier_country_rel_pkey");
                            j.ToTable("delivery_carrier_country_rel");
                            j.HasIndex(new[] { "CountryId", "CarrierId" }, "delivery_carrier_country_rel_country_id_carrier_id_idx");
                            j.IndexerProperty<Guid>("CarrierId").HasColumnName("carrier_id");
                            j.IndexerProperty<Guid>("CountryId").HasColumnName("country_id");
                        });

                entity.HasMany(d => d.ProductTags).WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "ProductTagDeliveryCarrierExcludedRel",
                        r => r.HasOne<ProductTag>().WithMany()
                            .HasForeignKey("ProductTagId")
                            .HasConstraintName("product_tag_delivery_carrier_excluded_rel_product_tag_id_fkey"),
                        l => l.HasOne<DeliveryCarrier>().WithMany()
                            .HasForeignKey("DeliveryCarrierId")
                            .HasConstraintName("product_tag_delivery_carrier_excluded__delivery_carrier_id_fkey"),
                        j =>
                        {
                            j.HasKey("DeliveryCarrierId", "ProductTagId").HasName("product_tag_delivery_carrier_excluded_rel_pkey");
                            j.ToTable("product_tag_delivery_carrier_excluded_rel");
                            j.HasIndex(new[] { "ProductTagId", "DeliveryCarrierId" }, "product_tag_delivery_carrier__product_tag_id_delivery_carr_idx1");
                            j.IndexerProperty<Guid>("DeliveryCarrierId").HasColumnName("delivery_carrier_id");
                            j.IndexerProperty<Guid>("ProductTagId").HasColumnName("product_tag_id");
                        });

                entity.HasMany(d => d.ProductTagsNavigation).WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "ProductTagDeliveryCarrierMustHaveRel",
                        r => r.HasOne<ProductTag>().WithMany()
                            .HasForeignKey("ProductTagId")
                            .HasConstraintName("product_tag_delivery_carrier_must_have_rel_product_tag_id_fkey"),
                        l => l.HasOne<DeliveryCarrier>().WithMany()
                            .HasForeignKey("DeliveryCarrierId")
                            .HasConstraintName("product_tag_delivery_carrier_must_have_delivery_carrier_id_fkey"),
                        j =>
                        {
                            j.HasKey("DeliveryCarrierId", "ProductTagId").HasName("product_tag_delivery_carrier_must_have_rel_pkey");
                            j.ToTable("product_tag_delivery_carrier_must_have_rel");
                            j.HasIndex(new[] { "ProductTagId", "DeliveryCarrierId" }, "product_tag_delivery_carrier__product_tag_id_delivery_carri_idx");
                            j.IndexerProperty<Guid>("DeliveryCarrierId").HasColumnName("delivery_carrier_id");
                            j.IndexerProperty<Guid>("ProductTagId").HasColumnName("product_tag_id");
                        });

                entity.HasMany(d => d.Routes).WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "StockRouteShipping",
                        r => r.HasOne<StockRoute>().WithMany()
                            .HasForeignKey("RouteId")
                            .HasConstraintName("stock_route_shipping_route_id_fkey"),
                        l => l.HasOne<DeliveryCarrier>().WithMany()
                            .HasForeignKey("ShippingId")
                            .HasConstraintName("stock_route_shipping_shipping_id_fkey"),
                        j =>
                        {
                            j.HasKey("ShippingId", "RouteId").HasName("stock_route_shipping_pkey");
                            j.ToTable("stock_route_shipping");
                            j.HasIndex(new[] { "RouteId", "ShippingId" }, "stock_route_shipping_route_id_shipping_id_idx");
                            j.IndexerProperty<Guid>("ShippingId").HasColumnName("shipping_id");
                            j.IndexerProperty<Guid>("RouteId").HasColumnName("route_id");
                        });

                entity.HasMany(d => d.States).WithMany(p => p.Carriers)
                    .UsingEntity<Dictionary<string, object>>(
                        "DeliveryCarrierStateRel",
                        r => r.HasOne<ResCountryState>().WithMany()
                            .HasForeignKey("StateId")
                            .HasConstraintName("delivery_carrier_state_rel_state_id_fkey"),
                        l => l.HasOne<DeliveryCarrier>().WithMany()
                            .HasForeignKey("CarrierId")
                            .HasConstraintName("delivery_carrier_state_rel_carrier_id_fkey"),
                        j =>
                        {
                            j.HasKey("CarrierId", "StateId").HasName("delivery_carrier_state_rel_pkey");
                            j.ToTable("delivery_carrier_state_rel");
                            j.HasIndex(new[] { "StateId", "CarrierId" }, "delivery_carrier_state_rel_state_id_carrier_id_idx");
                            j.IndexerProperty<Guid>("CarrierId").HasColumnName("carrier_id");
                            j.IndexerProperty<Guid>("StateId").HasColumnName("state_id");
                        });

                entity.HasMany(d => d.ZipPrefixes).WithMany(p => p.Carriers)
                    .UsingEntity<Dictionary<string, object>>(
                        "DeliveryZipPrefixRel",
                        r => r.HasOne<DeliveryZipPrefix>().WithMany()
                            .HasForeignKey("ZipPrefixId")
                            .HasConstraintName("delivery_zip_prefix_rel_zip_prefix_id_fkey"),
                        l => l.HasOne<DeliveryCarrier>().WithMany()
                            .HasForeignKey("CarrierId")
                            .HasConstraintName("delivery_zip_prefix_rel_carrier_id_fkey"),
                        j =>
                        {
                            j.HasKey("CarrierId", "ZipPrefixId").HasName("delivery_zip_prefix_rel_pkey");
                            j.ToTable("delivery_zip_prefix_rel");
                            j.HasIndex(new[] { "ZipPrefixId", "CarrierId" }, "delivery_zip_prefix_rel_zip_prefix_id_carrier_id_idx");
                            j.IndexerProperty<Guid>("CarrierId").HasColumnName("carrier_id");
                            j.IndexerProperty<Guid>("ZipPrefixId").HasColumnName("zip_prefix_id");
                        });
            });
        }
    }
}