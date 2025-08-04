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
        public static void ConfigureProductTemplate(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductTemplate>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("product_template_pkey");

                entity.ToTable("product_template");

                entity.HasIndex(e => e.TenantId, "product_template_company_id_index");

                entity.HasIndex(e => e.IsPublished, "product_template_is_published_index");

                entity.HasIndex(e => e.WebsiteId, "product_template_website_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.Active).HasColumnName("active");
                entity.Property(e => e.AllowOutOfStockOrder).HasColumnName("allow_out_of_stock_order");
                entity.Property(e => e.AvailableInPos).HasColumnName("available_in_pos");
                entity.Property(e => e.AvailableThreshold).HasColumnName("available_threshold");
                entity.Property(e => e.BaseUnitCount).HasColumnName("base_unit_count");
                entity.Property(e => e.BaseUnitId).HasColumnName("base_unit_id");
                entity.Property(e => e.CanBeExpensed).HasColumnName("can_be_expensed");
                entity.Property(e => e.CanImage1024BeZoomed).HasColumnName("can_image_1024_be_zoomed");
                entity.Property(e => e.CategId).HasColumnName("categ_id");
                entity.Property(e => e.Color).HasColumnName("color");
                entity.Property(e => e.CompareListPrice).HasColumnName("compare_list_price");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.DaysToPrepareMo).HasColumnName("days_to_prepare_mo");
                entity.Property(e => e.DefaultCode).HasColumnName("default_code");
                entity.Property(e => e.Description)
                    .HasColumnType("jsonb")
                    .HasColumnName("description");
                entity.Property(e => e.DescriptionPicking)
                    .HasColumnType("jsonb")
                    .HasColumnName("description_picking");
                entity.Property(e => e.DescriptionPickingin)
                    .HasColumnType("jsonb")
                    .HasColumnName("description_pickingin");
                entity.Property(e => e.DescriptionPickingout)
                    .HasColumnType("jsonb")
                    .HasColumnName("description_pickingout");
                entity.Property(e => e.DescriptionPurchase)
                    .HasColumnType("jsonb")
                    .HasColumnName("description_purchase");
                entity.Property(e => e.DescriptionSale)
                    .HasColumnType("jsonb")
                    .HasColumnName("description_sale");
                entity.Property(e => e.DetailedType).HasColumnName("detailed_type");
                entity.Property(e => e.ExpensePolicy).HasColumnName("expense_policy");
                entity.Property(e => e.HasConfigurableAttributes).HasColumnName("has_configurable_attributes");
                entity.Property(e => e.InvoicePolicy).HasColumnName("invoice_policy");
                entity.Property(e => e.IsPublished).HasColumnName("is_published");
                entity.Property(e => e.ListPrice).HasColumnName("list_price");
                entity.Property(e => e.MessageMainAttachmentId).HasColumnName("message_main_attachment_id");
                entity.Property(e => e.Name)
                    .HasColumnType("jsonb")
                    .HasColumnName("name");
                entity.Property(e => e.OutOfStockMessage)
                    .HasColumnType("jsonb")
                    .HasColumnName("out_of_stock_message");
                entity.Property(e => e.PosCategId).HasColumnName("pos_categ_id");
                entity.Property(e => e.Priority).HasColumnName("priority");
                entity.Property(e => e.ProduceDelay).HasColumnName("produce_delay");
                entity.Property(e => e.PurchaseLineWarn).HasColumnName("purchase_line_warn");
                entity.Property(e => e.PurchaseLineWarnMsg).HasColumnName("purchase_line_warn_msg");
                entity.Property(e => e.PurchaseMethod).HasColumnName("purchase_method");
                entity.Property(e => e.PurchaseOk).HasColumnName("purchase_ok");
                entity.Property(e => e.RatingLastValue).HasColumnName("rating_last_value");
                entity.Property(e => e.SaleDelay).HasColumnName("sale_delay");
                entity.Property(e => e.SaleLineWarn).HasColumnName("sale_line_warn");
                entity.Property(e => e.SaleLineWarnMsg).HasColumnName("sale_line_warn_msg");
                entity.Property(e => e.SaleOk).HasColumnName("sale_ok");
                entity.Property(e => e.SeoName)
                    .HasColumnType("jsonb")
                    .HasColumnName("seo_name");
                entity.Property(e => e.Sequence)
                    .HasColumnName("sequence");
                entity.Property(e => e.ServiceTracking).HasColumnName("service_tracking");
                entity.Property(e => e.ServiceType).HasColumnName("service_type");
                entity.Property(e => e.ShowAvailability).HasColumnName("show_availability");
                entity.Property(e => e.ToWeight).HasColumnName("to_weight");
                entity.Property(e => e.Tracking).HasColumnName("tracking");
                entity.Property(e => e.Type).HasColumnName("type");
                entity.Property(e => e.UomId).HasColumnName("uom_id");
                entity.Property(e => e.UomPoId).HasColumnName("uom_po_id");
                entity.Property(e => e.Volume).HasColumnName("volume");
                entity.Property(e => e.WebsiteDescription)
                    .HasColumnType("jsonb")
                    .HasColumnName("website_description");
                entity.Property(e => e.WebsiteId).HasColumnName("website_id");
                entity.Property(e => e.WebsiteMetaDescription)
                    .HasColumnType("jsonb")
                    .HasColumnName("website_meta_description");
                entity.Property(e => e.WebsiteMetaKeywords)
                    .HasColumnType("jsonb")
                    .HasColumnName("website_meta_keywords");
                entity.Property(e => e.WebsiteMetaOgImg).HasColumnName("website_meta_og_img");
                entity.Property(e => e.WebsiteMetaTitle)
                    .HasColumnType("jsonb")
                    .HasColumnName("website_meta_title");
                entity.Property(e => e.WebsiteRibbonId).HasColumnName("website_ribbon_id");
                entity.Property(e => e.WebsiteSequence).HasColumnName("website_sequence");
                entity.Property(e => e.WebsiteSizeX).HasColumnName("website_size_x");
                entity.Property(e => e.WebsiteSizeY).HasColumnName("website_size_y");
                entity.Property(e => e.Weight).HasColumnName("weight");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne(d => d.BaseUnit).WithMany(p => p.ProductTemplates)
                    .HasForeignKey(d => d.BaseUnitId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("product_template_base_unit_id_fkey");

                entity.HasOne(d => d.Categ).WithMany(p => p.ProductTemplates)
                    .HasForeignKey(d => d.CategId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("product_template_categ_id_fkey");

                entity.HasOne<ResCompany>().WithMany()
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("product_template_company_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("product_template_create_uid_fkey");

                entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.ProductTemplates)
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("product_template_message_main_attachment_id_fkey");

                entity.HasOne(d => d.PosCateg).WithMany(p => p.ProductTemplates)
                    .HasForeignKey(d => d.PosCategId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("product_template_pos_categ_id_fkey");

                entity.HasOne(d => d.Uom).WithMany(p => p.ProductTemplateUoms)
                    .HasForeignKey(d => d.UomId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("product_template_uom_id_fkey");

                entity.HasOne(d => d.UomPo).WithMany(p => p.ProductTemplateUomPos)
                    .HasForeignKey(d => d.UomPoId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("product_template_uom_po_id_fkey");

                entity.HasOne(d => d.Website).WithMany(p => p.ProductTemplates)
                    .HasForeignKey(d => d.WebsiteId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("product_template_website_id_fkey");

                entity.HasOne(d => d.WebsiteRibbon).WithMany(p => p.ProductTemplates)
                    .HasForeignKey(d => d.WebsiteRibbonId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("product_template_website_ribbon_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("product_template_write_uid_fkey");

                //entity.HasMany(d => d.AccountAccountTags).WithMany(p => p.ProductTemplates)
                entity.HasMany<AccountAccountTag>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "AccountAccountTagProductTemplateRel",
                        r => r.HasOne<AccountAccountTag>().WithMany()
                            .HasForeignKey("AccountAccountTagId")
                            .HasConstraintName("account_account_tag_product_templat_account_account_tag_id_fkey"),
                        l => l.HasOne<ProductTemplate>().WithMany()
                            .HasForeignKey("ProductTemplateId")
                            .HasConstraintName("account_account_tag_product_template_r_product_template_id_fkey"),
                        j =>
                        {
                            j.HasKey("ProductTemplateId", "AccountAccountTagId").HasName("account_account_tag_product_template_rel_pkey");
                            j.ToTable("account_account_tag_product_template_rel");
                            j.HasIndex(new[] { "AccountAccountTagId", "ProductTemplateId" }, "account_account_tag_product_t_account_account_tag_id_produc_idx");
                        });

                /// TODO:
                //entity.HasMany(d => d.Dests).WithMany(p => p.Srcs)
                entity.HasMany<ProductProduct>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "ProductAccessoryRel",
                        r => r.HasOne<ProductProduct>().WithMany()
                            .HasForeignKey("DestId")
                            .HasConstraintName("product_accessory_rel_dest_id_fkey"),
                        l => l.HasOne<ProductTemplate>().WithMany()
                            .HasForeignKey("SrcId")
                            .HasConstraintName("product_accessory_rel_src_id_fkey"),
                        j =>
                        {
                            j.HasKey("SrcId", "DestId").HasName("product_accessory_rel_pkey");
                            j.ToTable("product_accessory_rel");
                            j.HasIndex(new[] { "DestId", "SrcId" }, "product_accessory_rel_dest_id_src_id_idx");
                        });

                /// TODO:
                //entity.HasMany(d => d.Dests1).WithMany(p => p.SrcsNavigation)
                entity.HasMany<ProductTemplate>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "ProductOptionalRel",
                        r => r.HasOne<ProductTemplate>().WithMany()
                            .HasForeignKey("DestId")
                            .HasConstraintName("product_optional_rel_dest_id_fkey"),
                        l => l.HasOne<ProductTemplate>().WithMany()
                            .HasForeignKey("SrcId")
                            .HasConstraintName("product_optional_rel_src_id_fkey"),
                        j =>
                        {
                            j.HasKey("SrcId", "DestId").HasName("product_optional_rel_pkey");
                            j.ToTable("product_optional_rel");
                            j.HasIndex(new[] { "DestId", "SrcId" }, "product_optional_rel_dest_id_src_id_idx");
                        });

                /// TODO:
                //entity.HasMany(d => d.DestsNavigation).WithMany(p => p.Srcs)
                entity.HasMany<ProductTemplate>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "ProductAlternativeRel",
                        r => r.HasOne<ProductTemplate>().WithMany()
                            .HasForeignKey("DestId")
                            .HasConstraintName("product_alternative_rel_dest_id_fkey"),
                        l => l.HasOne<ProductTemplate>().WithMany()
                            .HasForeignKey("SrcId")
                            .HasConstraintName("product_alternative_rel_src_id_fkey"),
                        j =>
                        {
                            j.HasKey("SrcId", "DestId").HasName("product_alternative_rel_pkey");
                            j.ToTable("product_alternative_rel");
                            j.HasIndex(new[] { "DestId", "SrcId" }, "product_alternative_rel_dest_id_src_id_idx");
                        });

                //entity.HasMany(d => d.PosCategories).WithMany(p => p.ProductTemplates)
                entity.HasMany<PosCategory>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "PosCategoryProductTemplateRel",
                        r => r.HasOne<PosCategory>().WithMany()
                            .HasForeignKey("PosCategoryId")
                            .HasConstraintName("pos_category_product_template_rel_pos_category_id_fkey"),
                        l => l.HasOne<ProductTemplate>().WithMany()
                            .HasForeignKey("ProductTemplateId")
                            .HasConstraintName("pos_category_product_template_rel_product_template_id_fkey"),
                        j =>
                        {
                            j.HasKey("ProductTemplateId", "PosCategoryId").HasName("pos_category_product_template_rel_pkey");
                            j.ToTable("pos_category_product_template_rel");
                            j.HasIndex(new[] { "PosCategoryId", "ProductTemplateId" }, "pos_category_product_template_pos_category_id_product_templ_idx");
                            j.IndexerProperty<Guid>("ProductTemplateId").HasColumnName("product_template_id");
                            j.IndexerProperty<Guid>("PosCategoryId").HasColumnName("pos_category_id");
                        });

                //entity.HasMany(d => d.ProductCombos).WithMany(p => p.ProductTemplates)
                // entity.HasMany<ProductCombo>().WithMany()
                //     .UsingEntity<Dictionary<string, object>>(
                //         "ProductComboProductTemplateRel",
                //         r => r.HasOne<ProductCombo>().WithMany()
                //             .HasForeignKey("ProductComboId")
                //             .HasConstraintName("product_combo_product_template_rel_product_combo_id_fkey"),
                //         l => l.HasOne<ProductTemplate>().WithMany()
                //             .HasForeignKey("ProductTemplateId")
                //             .HasConstraintName("product_combo_product_template_rel_product_template_id_fkey"),
                //         j =>
                //         {
                //             j.HasKey("ProductTemplateId", "ProductComboId").HasName("product_combo_product_template_rel_pkey");
                //             j.ToTable("product_combo_product_template_rel");
                //             j.HasIndex(new[] { "ProductComboId", "ProductTemplateId" }, "product_combo_product_templat_product_combo_id_product_temp_idx");
                //             j.IndexerProperty<Guid>("ProductTemplateId").HasColumnName("product_template_id");
                //             j.IndexerProperty<Guid>("ProductComboId").HasColumnName("product_combo_id");
                //         });

                //entity.HasMany(d => d.ProductCombos).WithMany(p => p.ProductTemplates)
                entity.HasMany<ProductCombo>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "ProductComboProductTemplateRel",
                        r => r.HasOne<ProductCombo>().WithMany()
                            .HasForeignKey("ProductComboId")
                            .HasConstraintName("product_combo_product_template_rel_product_combo_id_fkey"),
                        l => l.HasOne<ProductTemplate>().WithMany()
                            .HasForeignKey("ProductTemplateId")
                            .HasConstraintName("product_combo_product_template_rel_product_template_id_fkey"),
                        j =>
                        {
                            j.HasKey("ProductTemplateId", "ProductComboId").HasName("product_combo_product_template_rel_pkey");
                            j.ToTable("product_combo_product_template_rel");
                            j.HasIndex(new[] { "ProductComboId", "ProductTemplateId" }, "product_combo_product_templat_product_combo_id_product_temp_idx");
                            j.IndexerProperty<Guid>("ProductTemplateId").HasColumnName("product_template_id");
                            j.IndexerProperty<Guid>("ProductComboId").HasColumnName("product_combo_id");
                        });

                //entity.HasMany(d => d.ProductTags).WithMany(p => p.ProductTemplates)
                entity.HasMany<ProductTag>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "ProductTagProductTemplateRel",
                        r => r.HasOne<ProductTag>().WithMany()
                            .HasForeignKey("ProductTagId")
                            .HasConstraintName("product_tag_product_template_rel_product_tag_id_fkey"),
                        l => l.HasOne<ProductTemplate>().WithMany()
                            .HasForeignKey("ProductTemplateId")
                            .HasConstraintName("product_tag_product_template_rel_product_template_id_fkey"),
                        j =>
                        {
                            j.HasKey("ProductTemplateId", "ProductTagId").HasName("product_tag_product_template_rel_pkey");
                            j.ToTable("product_tag_product_template_rel");
                            j.HasIndex(new[] { "ProductTagId", "ProductTemplateId" }, "product_tag_product_template__product_tag_id_product_templa_idx");
                        });

                /// TODO:
                //entity.HasMany(d => d.Srcs).WithMany(p => p.DestsNavigation)
                entity.HasMany<ProductTemplate>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "ProductAlternativeRel",
                        r => r.HasOne<ProductTemplate>().WithMany()
                            .HasForeignKey("SrcId")
                            .HasConstraintName("product_alternative_rel_src_id_fkey"),
                        l => l.HasOne<ProductTemplate>().WithMany()
                            .HasForeignKey("DestId")
                            .HasConstraintName("product_alternative_rel_dest_id_fkey"),
                        j =>
                        {
                            j.HasKey("SrcId", "DestId").HasName("product_alternative_rel_pkey");
                            j.ToTable("product_alternative_rel");
                            j.HasIndex(new[] { "DestId", "SrcId" }, "product_alternative_rel_dest_id_src_id_idx");
                        });

                /// TODO:
                //entity.HasMany(d => d.SrcsNavigation).WithMany(p => p.Dests1)
                entity.HasMany<ProductTemplate>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "ProductOptionalRel",
                        r => r.HasOne<ProductTemplate>().WithMany()
                            .HasForeignKey("SrcId")
                            .HasConstraintName("product_optional_rel_src_id_fkey"),
                        l => l.HasOne<ProductTemplate>().WithMany()
                            .HasForeignKey("DestId")
                            .HasConstraintName("product_optional_rel_dest_id_fkey"),
                        j =>
                        {
                            j.HasKey("SrcId", "DestId").HasName("product_optional_rel_pkey");
                            j.ToTable("product_optional_rel");
                            j.HasIndex(new[] { "DestId", "SrcId" }, "product_optional_rel_dest_id_src_id_idx");
                        });

                /// TODO:
                //entity.HasMany(d => d.Taxes).WithMany(p => p.Prods)
                entity.HasMany<AccountTax>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "ProductSupplierTaxesRel",
                        r => r.HasOne<AccountTax>().WithMany()
                            .HasForeignKey("TaxId")
                            .HasConstraintName("product_supplier_taxes_rel_tax_id_fkey"),
                        l => l.HasOne<ProductTemplate>().WithMany()
                            .HasForeignKey("ProdId")
                            .HasConstraintName("product_supplier_taxes_rel_prod_id_fkey"),
                        j =>
                        {
                            j.HasKey("ProdId", "TaxId").HasName("product_supplier_taxes_rel_pkey");
                            j.ToTable("product_supplier_taxes_rel");
                            j.HasIndex(new[] { "TaxId", "ProdId" }, "product_supplier_taxes_rel_tax_id_prod_id_idx");
                        });

                /// TODO:
                //entity.HasMany(d => d.TaxesNavigation).WithMany(p => p.ProdsNavigation)
                entity.HasMany<AccountTax>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "ProductTaxesRel",
                        r => r.HasOne<AccountTax>().WithMany()
                            .HasForeignKey("TaxId")
                            .HasConstraintName("product_taxes_rel_tax_id_fkey"),
                        l => l.HasOne<ProductTemplate>().WithMany()
                            .HasForeignKey("ProdId")
                            .HasConstraintName("product_taxes_rel_prod_id_fkey"),
                        j =>
                        {
                            j.HasKey("ProdId", "TaxId").HasName("product_taxes_rel_pkey");
                            j.ToTable("product_taxes_rel");
                            j.HasIndex(new[] { "TaxId", "ProdId" }, "product_taxes_rel_tax_id_prod_id_idx");
                        });
            });
        }
    }
}