using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureProductFetchImageWizard(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<ProductFetchImageWizard>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("product_fetch_image_wizard_pkey");

                        entity.ToTable("product_fetch_image_wizard");

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
                        entity.Property(e => e.NbProductsSelected).HasColumnName("nb_products_selected");
                        entity.Property(e => e.NbProductsToProcess).HasColumnName("nb_products_to_process");
                        entity.Property(e => e.NbProductsUnableToProcess).HasColumnName("nb_products_unable_to_process");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.ProductFetchImageWizardCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("product_fetch_image_wizard_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("product_fetch_image_wizard_create_uid_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.ProductFetchImageWizardWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("product_fetch_image_wizard_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("product_fetch_image_wizard_write_uid_fkey");

                        // entity.HasMany(d => d.ProductProduct).WithMany(p => p.ProductFetchImageWizard)
                        entity.HasMany(d => d.ProductProduct).WithMany()
                            .UsingEntity<Dictionary<string, object>>(
                                "ProductFetchImageWizardProductProductRel",
                                r => r.HasOne<ProductProduct>().WithMany()
                                    .HasForeignKey("ProductProductId")
                                    .HasConstraintName("product_fetch_image_wizard_product_prod_product_product_id_fkey"),
                                l => l.HasOne<ProductFetchImageWizard>().WithMany()
                                    .HasForeignKey("ProductFetchImageWizardId")
                                    .HasConstraintName("product_fetch_image_wizard_pr_product_fetch_image_wizard_i_fkey"),
                                j =>
                                {
                                    j.HasKey("ProductFetchImageWizardId", "ProductProductId").HasName("product_fetch_image_wizard_product_product_rel_pkey");
                                    j.ToTable("product_fetch_image_wizard_product_product_rel");
                                    j.HasIndex(new[] { "ProductProductId", "ProductFetchImageWizardId" }, "product_fetch_image_wizard_pr_product_product_id_product_fe_idx");
                                    j.IndexerProperty<Guid>("ProductFetchImageWizardId").HasColumnName("product_fetch_image_wizard_id");
                                    j.IndexerProperty<Guid>("ProductProductId").HasColumnName("product_product_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}