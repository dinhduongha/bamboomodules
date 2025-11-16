using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
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

                        entity.HasIndex(e => e.TenantId, "product_template__company_id_index");

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.IsPublished, "product_template__is_published_index");

                        entity.HasIndex(e => e.VariantsDefaultCode, "product_template__variants_default_code_index")
                            .HasMethod("gin")
                            .HasOperators(new[] { "gin_trgm_ops" });

                        entity.HasIndex(e => e.WebsiteId, "product_template__website_id_index");

                        entity.HasIndex(e => e.WebsiteSequence, "product_template__website_sequence_index");

                        entity.HasIndex(e => e.DefaultCode, "product_template_default_code_gist_idx")
                            .HasMethod("gist")
                            .HasOperators(new[] { "gist_trgm_ops" });

                        entity.HasIndex(e => e.IsFavorite, "product_template_is_favorite_index").HasFilter("(is_favorite IS TRUE)");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.Active).HasColumnName("active");
                        entity.Property(e => e.AlertTime).HasColumnName("alert_time");
                        entity.Property(e => e.AllowOutOfStockOrder).HasColumnName("allow_out_of_stock_order");
                        entity.Property(e => e.AssetCategoryId)
                            .HasColumnType("jsonb")
                            .HasColumnName("asset_category_id");
                        entity.Property(e => e.AvailableInPos).HasColumnName("available_in_pos");
                        entity.Property(e => e.AvailableThreshold).HasColumnName("available_threshold");
                        entity.Property(e => e.BaseUnitCount).HasColumnName("base_unit_count");
                        entity.Property(e => e.BaseUnitId).HasColumnName("base_unit_id");
                        entity.Property(e => e.CanBeExpensed)
                            .HasDefaultValue(false)
                            .HasColumnName("can_be_expensed");
                        entity.Property(e => e.CanImage1024BeZoomed).HasColumnName("can_image_1024_be_zoomed");
                        entity.Property(e => e.CategId).HasColumnName("categ_id");
                        entity.Property(e => e.Color).HasColumnName("color");

                        entity.Property(e => e.CompareListPrice).HasColumnName("compare_list_price");
                        entity.Property(e => e.CountryOfOrigin).HasColumnName("country_of_origin");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.DefaultCode).HasColumnName("default_code");
                        entity.Property(e => e.DeferredRevenueCategoryId)
                            .HasColumnType("jsonb")
                            .HasColumnName("deferred_revenue_category_id");
                        entity.Property(e => e.Description)
                            .HasColumnType("jsonb")
                            .HasColumnName("description");
                        entity.Property(e => e.DescriptionEcommerce)
                            .HasColumnType("jsonb")
                            .HasColumnName("description_ecommerce");
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
                        entity.Property(e => e.EmailTemplateId).HasColumnName("email_template_id");
                        entity.Property(e => e.ExpensePolicy).HasColumnName("expense_policy");
                        entity.Property(e => e.ExpirationTime).HasColumnName("expiration_time");
                        entity.Property(e => e.GradeId).HasColumnName("grade_id");
                        entity.Property(e => e.HasConfigurableAttributes).HasColumnName("has_configurable_attributes");
                        entity.Property(e => e.HsCode).HasColumnName("hs_code");
                        entity.Property(e => e.InvoicePolicy).HasColumnName("invoice_policy");
                        entity.Property(e => e.IsFavorite).HasColumnName("is_favorite");
                        entity.Property(e => e.IsPublished).HasColumnName("is_published");
                        entity.Property(e => e.IsSeoOptimized).HasColumnName("is_seo_optimized");
                        entity.Property(e => e.IsStorable).HasColumnName("is_storable");
                        entity.Property(e => e.LandedCostOk).HasColumnName("landed_cost_ok");
                        entity.Property(e => e.ListPrice).HasColumnName("list_price");
                        entity.Property(e => e.LotSequenceId).HasColumnName("lot_sequence_id");
                        entity.Property(e => e.LotValuated).HasColumnName("lot_valuated");
                        entity.Property(e => e.Name)
                            .HasColumnType("jsonb")
                            .HasColumnName("name");
                        entity.Property(e => e.OutOfStockMessage)
                            .HasColumnType("jsonb")
                            .HasColumnName("out_of_stock_message");
                        entity.Property(e => e.PosSequence).HasColumnName("pos_sequence");
                        entity.Property(e => e.ProductAddMode).HasColumnName("product_add_mode");
                        entity.Property(e => e.ProductProperties)
                            .HasColumnType("jsonb")
                            .HasColumnName("product_properties");
                        entity.Property(e => e.ProjectId)
                            .HasColumnType("jsonb")
                            .HasColumnName("project_id");
                        entity.Property(e => e.ProjectTemplateId)
                            .HasColumnType("jsonb")
                            .HasColumnName("project_template_id");
                        entity.Property(e => e.PropertyAccountExpenseId)
                            .HasColumnType("jsonb")
                            .HasColumnName("property_account_expense_id");
                        entity.Property(e => e.PropertyAccountIncomeId)
                            .HasColumnType("jsonb")
                            .HasColumnName("property_account_income_id");
                        entity.Property(e => e.PropertyPriceDifferenceAccountId)
                            .HasColumnType("jsonb")
                            .HasColumnName("property_price_difference_account_id");
                        entity.Property(e => e.PropertyStockInventory)
                            .HasColumnType("jsonb")
                            .HasColumnName("property_stock_inventory");
                        entity.Property(e => e.PropertyStockProduction)
                            .HasColumnType("jsonb")
                            .HasColumnName("property_stock_production");
                        entity.Property(e => e.PublicDescription)
                            .HasColumnType("jsonb")
                            .HasColumnName("public_description");
                        entity.Property(e => e.PublishDate)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("publish_date");
                        entity.Property(e => e.PurchaseLineWarnMsg).HasColumnName("purchase_line_warn_msg");
                        entity.Property(e => e.PurchaseMethod).HasColumnName("purchase_method");
                        entity.Property(e => e.PurchaseOk).HasColumnName("purchase_ok");
                        entity.Property(e => e.RatingLastValue).HasColumnName("rating_last_value");
                        entity.Property(e => e.RemovalTime).HasColumnName("removal_time");
                        entity.Property(e => e.ResponsibleId)
                            .HasColumnType("jsonb")
                            .HasColumnName("responsible_id");
                        entity.Property(e => e.SaleDelay).HasColumnName("sale_delay");
                        entity.Property(e => e.SaleLineWarnMsg).HasColumnName("sale_line_warn_msg");
                        entity.Property(e => e.SaleOk).HasColumnName("sale_ok");
                        entity.Property(e => e.SelfOrderAvailable).HasColumnName("self_order_available");
                        entity.Property(e => e.SeoName)
                            .HasColumnType("jsonb")
                            .HasColumnName("seo_name");
                        entity.Property(e => e.Sequence).HasColumnName("sequence");
                        entity.Property(e => e.ServiceToPurchase)
                            .HasColumnType("jsonb")
                            .HasColumnName("service_to_purchase");
                        entity.Property(e => e.ServiceTracking).HasColumnName("service_tracking");
                        entity.Property(e => e.ServiceType).HasColumnName("service_type");
                        entity.Property(e => e.ServiceUpsellThreshold).HasColumnName("service_upsell_threshold");
                        entity.Property(e => e.ShowAvailability).HasColumnName("show_availability");
                        entity.Property(e => e.SplitMethodLandedCost).HasColumnName("split_method_landed_cost");
                        entity.Property(e => e.TaskTemplateId)
                            .HasColumnType("jsonb")
                            .HasColumnName("task_template_id");
                        entity.Property(e => e.ToWeight).HasColumnName("to_weight");
                        entity.Property(e => e.Tracking).HasColumnName("tracking");
                        entity.Property(e => e.Type).HasColumnName("type");
                        entity.Property(e => e.UomId).HasColumnName("uom_id");
                        entity.Property(e => e.UseExpirationDate).HasColumnName("use_expiration_date");
                        entity.Property(e => e.UseTime).HasColumnName("use_time");
                        entity.Property(e => e.VariantsDefaultCode).HasColumnName("variants_default_code");
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

                        entity.HasOne(d => d.BaseUnit).WithMany(p => p.ProductTemplate)
                            .HasForeignKey(d => d.BaseUnitId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("product_template_base_unit_id_fkey");

                        entity.HasOne(d => d.Categ).WithMany(p => p.ProductTemplate)
                            .HasForeignKey(d => d.CategId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("product_template_categ_id_fkey");

                        // entity.HasOne(d => d.Company).WithMany(p => p.ProductTemplate) .HasForeignKey(d => d.TenantId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("product_template_company_id_fkey");
                        entity.HasOne(d => d.Company).WithMany()
                            .HasForeignKey(d => d.TenantId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("product_template_company_id_fkey");

                        // entity.HasOne(d => d.CountryOfOriginNavigation).WithMany(p => p.ProductTemplate) .HasForeignKey(d => d.CountryOfOrigin) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("product_template_country_of_origin_fkey");
                        entity.HasOne(d => d.CountryOfOriginNavigation).WithMany()
                            .HasForeignKey(d => d.CountryOfOrigin)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("product_template_country_of_origin_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.ProductTemplateCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("product_template_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("product_template_create_uid_fkey");

                        entity.HasOne(d => d.EmailTemplate).WithMany(p => p.ProductTemplate)
                            .HasForeignKey(d => d.EmailTemplateId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("product_template_email_template_id_fkey");

                        entity.HasOne(d => d.Grade).WithMany(p => p.ProductTemplate)
                            .HasForeignKey(d => d.GradeId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("product_template_grade_id_fkey");

                        entity.HasOne(d => d.LotSequence).WithMany(p => p.ProductTemplate)
                            .HasForeignKey(d => d.LotSequenceId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("product_template_lot_sequence_id_fkey");

                        // entity.HasOne(d => d.Uom).WithMany(p => p.ProductTemplate) .HasForeignKey(d => d.UomId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("product_template_uom_id_fkey");
                        entity.HasOne(d => d.Uom).WithMany()
                            .HasForeignKey(d => d.UomId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("product_template_uom_id_fkey");

                        // entity.HasOne(d => d.Website).WithMany(p => p.ProductTemplate) .HasForeignKey(d => d.WebsiteId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("product_template_website_id_fkey");
                        entity.HasOne(d => d.Website).WithMany()
                            .HasForeignKey(d => d.WebsiteId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("product_template_website_id_fkey");

                        entity.HasOne(d => d.WebsiteRibbon).WithMany(p => p.ProductTemplate)
                            .HasForeignKey(d => d.WebsiteRibbonId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("product_template_website_ribbon_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.ProductTemplateWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("product_template_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("product_template_write_uid_fkey");

                        // entity.HasMany(d => d.AccountAccountTag).WithMany(p => p.ProductTemplate)
                        entity.HasMany(d => d.AccountAccountTag).WithMany(p => p.ProductTemplate)
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
                                    j.IndexerProperty<Guid>("ProductTemplateId").HasColumnName("product_template_id");
                                    j.IndexerProperty<Guid>("AccountAccountTagId").HasColumnName("account_account_tag_id");
                                });

                        // entity.HasMany(d => d.Dest).WithMany(p => p.Src)
                        entity.HasMany(d => d.Dest).WithMany(p => p.Src)
                            .UsingEntity<Dictionary<string, object>>(
                                "PosProductOptionalRel",
                                r => r.HasOne<ProductTemplate>().WithMany()
                                    .HasForeignKey("DestId")
                                    .HasConstraintName("pos_product_optional_rel_dest_id_fkey"),
                                l => l.HasOne<ProductTemplate>().WithMany()
                                    .HasForeignKey("SrcId")
                                    .HasConstraintName("pos_product_optional_rel_src_id_fkey"),
                                j =>
                                {
                                    j.HasKey("SrcId", "DestId").HasName("pos_product_optional_rel_pkey");
                                    j.ToTable("pos_product_optional_rel");
                                    j.HasIndex(new[] { "DestId", "SrcId" }, "pos_product_optional_rel_dest_id_src_id_idx");
                                    j.IndexerProperty<Guid>("SrcId").HasColumnName("src_id");
                                    j.IndexerProperty<Guid>("DestId").HasColumnName("dest_id");
                                });

                        // entity.HasMany(d => d.Dest1).WithMany(p => p.SrcNavigation)
                        entity.HasMany(d => d.Dest1).WithMany(p => p.SrcNavigation)
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
                                    j.IndexerProperty<Guid>("SrcId").HasColumnName("src_id");
                                    j.IndexerProperty<Guid>("DestId").HasColumnName("dest_id");
                                });

                        // entity.HasMany(d => d.Dest2).WithMany(p => p.Src1)
                        entity.HasMany(d => d.Dest2).WithMany(p => p.Src1)
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
                                    j.IndexerProperty<Guid>("SrcId").HasColumnName("src_id");
                                    j.IndexerProperty<Guid>("DestId").HasColumnName("dest_id");
                                });

                        // entity.HasMany(d => d.DestNavigation).WithMany(p => p.Src)
                        entity.HasMany(d => d.DestNavigation).WithMany()
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
                                    j.IndexerProperty<Guid>("SrcId").HasColumnName("src_id");
                                    j.IndexerProperty<Guid>("DestId").HasColumnName("dest_id");
                                });

                        // entity.HasMany(d => d.PosCategory).WithMany(p => p.ProductTemplate)
                        entity.HasMany(d => d.PosCategory).WithMany(p => p.ProductTemplate)
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

                        // entity.HasMany(d => d.ProductCombo).WithMany(p => p.ProductTemplate)
                        entity.HasMany(d => d.ProductCombo).WithMany(p => p.ProductTemplate)
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

                        // entity.HasMany(d => d.ProductTag).WithMany(p => p.ProductTemplate)
                        entity.HasMany(d => d.ProductTag).WithMany(p => p.ProductTemplate)
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
                                    j.IndexerProperty<Guid>("ProductTemplateId").HasColumnName("product_template_id");
                                    j.IndexerProperty<Guid>("ProductTagId").HasColumnName("product_tag_id");
                                });

                        // entity.HasMany(d => d.Src).WithMany(p => p.Dest)
                        entity.HasMany(d => d.Src).WithMany(p => p.Dest)
                            .UsingEntity<Dictionary<string, object>>(
                                "PosProductOptionalRel",
                                r => r.HasOne<ProductTemplate>().WithMany()
                                    .HasForeignKey("SrcId")
                                    .HasConstraintName("pos_product_optional_rel_src_id_fkey"),
                                l => l.HasOne<ProductTemplate>().WithMany()
                                    .HasForeignKey("DestId")
                                    .HasConstraintName("pos_product_optional_rel_dest_id_fkey"),
                                j =>
                                {
                                    j.HasKey("SrcId", "DestId").HasName("pos_product_optional_rel_pkey");
                                    j.ToTable("pos_product_optional_rel");
                                    j.HasIndex(new[] { "DestId", "SrcId" }, "pos_product_optional_rel_dest_id_src_id_idx");
                                    j.IndexerProperty<Guid>("SrcId").HasColumnName("src_id");
                                    j.IndexerProperty<Guid>("DestId").HasColumnName("dest_id");
                                });

                        // entity.HasMany(d => d.Src1).WithMany(p => p.Dest2)
                        entity.HasMany(d => d.Src1).WithMany(p => p.Dest2)
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
                                    j.IndexerProperty<Guid>("SrcId").HasColumnName("src_id");
                                    j.IndexerProperty<Guid>("DestId").HasColumnName("dest_id");
                                });

                        // entity.HasMany(d => d.SrcNavigation).WithMany(p => p.Dest1)
                        entity.HasMany(d => d.SrcNavigation).WithMany(p => p.Dest1)
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
                                    j.IndexerProperty<Guid>("SrcId").HasColumnName("src_id");
                                    j.IndexerProperty<Guid>("DestId").HasColumnName("dest_id");
                                });

                        // entity.HasMany(d => d.Tax).WithMany(p => p.Prod)
                        entity.HasMany(d => d.Tax).WithMany(p => p.Prod)
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
                                    j.IndexerProperty<Guid>("ProdId").HasColumnName("prod_id");
                                    j.IndexerProperty<Guid>("TaxId").HasColumnName("tax_id");
                                });

                        // entity.HasMany(d => d.TaxNavigation).WithMany(p => p.ProdNavigation)
                        entity.HasMany(d => d.TaxNavigation).WithMany(p => p.ProdNavigation)
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
                                    j.IndexerProperty<Guid>("ProdId").HasColumnName("prod_id");
                                    j.IndexerProperty<Guid>("TaxId").HasColumnName("tax_id");
                                });

                        // entity.HasMany(d => d.UomUom).WithMany(p => p.ProductTemplateNavigation)
                        entity.HasMany(d => d.UomUom).WithMany()
                            .UsingEntity<Dictionary<string, object>>(
                                "ProductTemplateUomUomRel",
                                r => r.HasOne<UomUom>().WithMany()
                                    .HasForeignKey("UomUomId")
                                    .HasConstraintName("product_template_uom_uom_rel_uom_uom_id_fkey"),
                                l => l.HasOne<ProductTemplate>().WithMany()
                                    .HasForeignKey("ProductTemplateId")
                                    .HasConstraintName("product_template_uom_uom_rel_product_template_id_fkey"),
                                j =>
                                {
                                    j.HasKey("ProductTemplateId", "UomUomId").HasName("product_template_uom_uom_rel_pkey");
                                    j.ToTable("product_template_uom_uom_rel");
                                    j.HasIndex(new[] { "UomUomId", "ProductTemplateId" }, "product_template_uom_uom_rel_uom_uom_id_product_template_id_idx");
                                    j.IndexerProperty<Guid>("ProductTemplateId").HasColumnName("product_template_id");
                                    j.IndexerProperty<Guid>("UomUomId").HasColumnName("uom_uom_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}