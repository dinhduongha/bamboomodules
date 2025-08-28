using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureProductLabelLayout(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<ProductLabelLayout>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("product_label_layout_pkey");

                        entity.ToTable("product_label_layout");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("next_uuid()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.CustomQuantity).HasColumnName("custom_quantity");
                        entity.Property(e => e.ExtraHtml).HasColumnName("extra_html");
                        entity.Property(e => e.MoveQuantity).HasColumnName("move_quantity");
                        entity.Property(e => e.PricelistId).HasColumnName("pricelist_id");
                        entity.Property(e => e.PrintFormat).HasColumnName("print_format");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.ProductLabelLayoutCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("product_label_layout_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("product_label_layout_create_uid_fkey");

                        entity.HasOne(d => d.Pricelist).WithMany(p => p.ProductLabelLayout)
                            .HasForeignKey(d => d.PricelistId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("product_label_layout_pricelist_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.ProductLabelLayoutWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("product_label_layout_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("product_label_layout_write_uid_fkey");

                        // entity.HasMany(d => d.ProductProduct).WithMany(p => p.ProductLabelLayout)
                        entity.HasMany(d => d.ProductProduct).WithMany()
                            .UsingEntity<Dictionary<string, object>>(
                                "ProductLabelLayoutProductProductRel",
                                r => r.HasOne<ProductProduct>().WithMany()
                                    .HasForeignKey("ProductProductId")
                                    .HasConstraintName("product_label_layout_product_product_re_product_product_id_fkey"),
                                l => l.HasOne<ProductLabelLayout>().WithMany()
                                    .HasForeignKey("ProductLabelLayoutId")
                                    .HasConstraintName("product_label_layout_product_produ_product_label_layout_id_fkey"),
                                j =>
                                {
                                    j.HasKey("ProductLabelLayoutId", "ProductProductId").HasName("product_label_layout_product_product_rel_pkey");
                                    j.ToTable("product_label_layout_product_product_rel");
                                    j.HasIndex(new[] { "ProductProductId", "ProductLabelLayoutId" }, "product_label_layout_product__product_product_id_product_la_idx");
                                    j.IndexerProperty<Guid>("ProductLabelLayoutId").HasColumnName("product_label_layout_id");
                                    j.IndexerProperty<Guid>("ProductProductId").HasColumnName("product_product_id");
                                });

                        // entity.HasMany(d => d.ProductTemplate).WithMany(p => p.ProductLabelLayout)
                        entity.HasMany(d => d.ProductTemplate).WithMany(p => p.ProductLabelLayout)
                            .UsingEntity<Dictionary<string, object>>(
                                "ProductLabelLayoutProductTemplateRel",
                                r => r.HasOne<ProductTemplate>().WithMany()
                                    .HasForeignKey("ProductTemplateId")
                                    .HasConstraintName("product_label_layout_product_template__product_template_id_fkey"),
                                l => l.HasOne<ProductLabelLayout>().WithMany()
                                    .HasForeignKey("ProductLabelLayoutId")
                                    .HasConstraintName("product_label_layout_product_templ_product_label_layout_id_fkey"),
                                j =>
                                {
                                    j.HasKey("ProductLabelLayoutId", "ProductTemplateId").HasName("product_label_layout_product_template_rel_pkey");
                                    j.ToTable("product_label_layout_product_template_rel");
                                    j.HasIndex(new[] { "ProductTemplateId", "ProductLabelLayoutId" }, "product_label_layout_product__product_template_id_product_l_idx");
                                    j.IndexerProperty<Guid>("ProductLabelLayoutId").HasColumnName("product_label_layout_id");
                                    j.IndexerProperty<Guid>("ProductTemplateId").HasColumnName("product_template_id");
                                });

                        // entity.HasMany(d => d.StockMove).WithMany(p => p.ProductLabelLayout)
                        entity.HasMany(d => d.StockMove).WithMany(p => p.ProductLabelLayout)
                            .UsingEntity<Dictionary<string, object>>(
                                "ProductLabelLayoutStockMoveRel",
                                r => r.HasOne<StockMove>().WithMany()
                                    .HasForeignKey("StockMoveId")
                                    .HasConstraintName("product_label_layout_stock_move_rel_stock_move_id_fkey"),
                                l => l.HasOne<ProductLabelLayout>().WithMany()
                                    .HasForeignKey("ProductLabelLayoutId")
                                    .HasConstraintName("product_label_layout_stock_move_re_product_label_layout_id_fkey"),
                                j =>
                                {
                                    j.HasKey("ProductLabelLayoutId", "StockMoveId").HasName("product_label_layout_stock_move_rel_pkey");
                                    j.ToTable("product_label_layout_stock_move_rel");
                                    j.HasIndex(new[] { "StockMoveId", "ProductLabelLayoutId" }, "product_label_layout_stock_mo_stock_move_id_product_label_l_idx");
                                    j.IndexerProperty<Guid>("ProductLabelLayoutId").HasColumnName("product_label_layout_id");
                                    j.IndexerProperty<Guid>("StockMoveId").HasColumnName("stock_move_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}