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
        public static void ConfigureProductProduct(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<ProductProduct>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("product_product_pkey");

            entity.ToTable("product_product");

            entity.HasIndex(e => e.TenantId);

            entity.HasIndex(e => e.OrganizationUnitId);

            entity.HasIndex(e => e.Barcode, "product_product__barcode_index").HasFilter("(barcode IS NOT NULL)");

            entity.HasIndex(e => e.CombinationIndices, "product_product__combination_indices_index");

            entity.HasIndex(e => e.DefaultCode, "product_product__default_code_index");

            entity.HasIndex(e => e.ProductTmplId, "product_product__product_tmpl_id_index");

            entity.HasIndex(e => new { e.ProductTmplId, e.CombinationIndices }, "product_product_combination_unique")
                .IsUnique()
                .HasFilter("(active IS TRUE)");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");

            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.Barcode).HasColumnName("barcode");
            entity.Property(e => e.BaseUnitCount).HasColumnName("base_unit_count");
            entity.Property(e => e.BaseUnitId).HasColumnName("base_unit_id");
            entity.Property(e => e.CanImageVariant1024BeZoomed).HasColumnName("can_image_variant_1024_be_zoomed");
            entity.Property(e => e.CombinationIndices).HasColumnName("combination_indices");
            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.DefaultCode).HasColumnName("default_code");
            entity.Property(e => e.ImageFetchPending).HasColumnName("image_fetch_pending");
            entity.Property(e => e.LotPropertiesDefinition)
                .HasColumnType("jsonb")
                .HasColumnName("lot_properties_definition");
       
        entity.Property(e => e.MessageMainAttachmentId).HasColumnName("message_main_attachment_id");
            entity.Property(e => e.ProductTmplId).HasColumnName("product_tmpl_id");
            entity.Property(e => e.StandardPrice)
                .HasColumnType("jsonb")
                .HasColumnName("standard_price");
            entity.Property(e => e.VariantRibbonId).HasColumnName("variant_ribbon_id");
            entity.Property(e => e.Volume).HasColumnName("volume");
            entity.Property(e => e.Weight).HasColumnName("weight");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            entity.HasOne(d => d.BaseUnit).WithMany(p => p.ProductProduct)
                .HasForeignKey(d => d.BaseUnitId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("product_product_base_unit_id_fkey");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.ProductProductCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("product_product_create_uid_fkey");

            // entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.ProductProduct)
            entity.HasOne(d => d.MessageMainAttachment).WithMany()
                .HasForeignKey(d => d.MessageMainAttachmentId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("product_product_message_main_attachment_id_fkey");

            entity.HasOne(d => d.ProductTmpl).WithMany(p => p.ProductProduct)
                .HasForeignKey(d => d.ProductTmplId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("product_product_product_tmpl_id_fkey");

            entity.HasOne(d => d.VariantRibbon).WithMany(p => p.ProductProduct)
                .HasForeignKey(d => d.VariantRibbonId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("product_product_variant_ribbon_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.ProductProductWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("product_product_write_uid_fkey");

            // entity.HasMany(d => d.ProductTag).WithMany(p => p.ProductProduct)
            entity.HasMany<ProductTag>().WithMany()
                .UsingEntity<Dictionary<string, object>>(
                    "ProductTagProductProductRel",
                    r => r.HasOne<ProductTag>().WithMany()
                        .HasForeignKey("ProductTagId")
                        .HasConstraintName("product_tag_product_product_rel_product_tag_id_fkey"),
                    l => l.HasOne<ProductProduct>().WithMany()
                        .HasForeignKey("ProductProductId")
                        .HasConstraintName("product_tag_product_product_rel_product_product_id_fkey"),
                    j =>
                    {
                        j.HasKey("ProductProductId", "ProductTagId").HasName("product_tag_product_product_rel_pkey");
                        j.ToTable("product_tag_product_product_rel");
                        j.HasIndex(new[] { "ProductTagId", "ProductProductId" }, "product_tag_product_product_r_product_tag_id_product_produc_idx");
                        j.IndexerProperty<Guid>("ProductProductId").HasColumnName("product_product_id");
                        j.IndexerProperty<Guid>("ProductTagId").HasColumnName("product_tag_id");
                    });

            // entity.HasMany(d => d.ProductTemplateAttributeValue).WithMany(p => p.ProductProduct)
            entity.HasMany<ProductTemplateAttributeValue>().WithMany()
                .UsingEntity<Dictionary<string, object>>(
                    "ProductVariantCombination",
                    r => r.HasOne<ProductTemplateAttributeValue>().WithMany()
                        .HasForeignKey("ProductTemplateAttributeValueId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("product_variant_combination_product_template_attribute_val_fkey"),
                    l => l.HasOne<ProductProduct>().WithMany()
                        .HasForeignKey("ProductProductId")
                        .HasConstraintName("product_variant_combination_product_product_id_fkey"),
                    j =>
                    {
                        j.HasKey("ProductProductId", "ProductTemplateAttributeValueId").HasName("product_variant_combination_pkey");
                        j.ToTable("product_variant_combination");
                        j.HasIndex(new[] { "ProductTemplateAttributeValueId", "ProductProductId" }, "product_variant_combination_product_template_attribute_valu_idx");
                        j.IndexerProperty<Guid>("ProductProductId").HasColumnName("product_product_id");
                        j.IndexerProperty<Guid>("ProductTemplateAttributeValueId").HasColumnName("product_template_attribute_value_id");
                    });

            // entity.HasMany(d => d.ResPartner).WithMany(p => p.ProductProduct)
            entity.HasMany<ResPartner>().WithMany()
                .UsingEntity<Dictionary<string, object>>(
                    "StockNotificationProductPartnerRel",
                    r => r.HasOne<ResPartner>().WithMany()
                        .HasForeignKey("ResPartnerId")
                        .HasConstraintName("stock_notification_product_partner_rel_res_partner_id_fkey"),
                    l => l.HasOne<ProductProduct>().WithMany()
                        .HasForeignKey("ProductProductId")
                        .HasConstraintName("stock_notification_product_partner_rel_product_product_id_fkey"),
                    j =>
                    {
                        j.HasKey("ProductProductId", "ResPartnerId").HasName("stock_notification_product_partner_rel_pkey");
                        j.ToTable("stock_notification_product_partner_rel");
                        j.HasIndex(new[] { "ResPartnerId", "ProductProductId" }, "stock_notification_product_pa_res_partner_id_product_produc_idx");
                        j.IndexerProperty<Guid>("ProductProductId").HasColumnName("product_product_id");
                        j.IndexerProperty<Guid>("ResPartnerId").HasColumnName("res_partner_id");
                    });
            });
        }
    }
}
