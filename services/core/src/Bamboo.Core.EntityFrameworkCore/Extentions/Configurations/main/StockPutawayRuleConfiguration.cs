using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureStockPutawayRule(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<StockPutawayRule>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("stock_putaway_rule_pkey");

                        entity.ToTable("stock_putaway_rule");

                        entity.HasIndex(e => e.CategoryId, "stock_putaway_rule__category_id_index").HasFilter("(category_id IS NOT NULL)");

                        entity.HasIndex(e => e.TenantId, "stock_putaway_rule__company_id_index");

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.LocationInId, "stock_putaway_rule__location_in_id_index");

                        entity.HasIndex(e => e.ProductId, "stock_putaway_rule__product_id_index").HasFilter("(product_id IS NOT NULL)");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.Active).HasColumnName("active");
                        entity.Property(e => e.CategoryId).HasColumnName("category_id");

                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.LocationInId).HasColumnName("location_in_id");
                        entity.Property(e => e.LocationOutId).HasColumnName("location_out_id");
                        entity.Property(e => e.ProductId).HasColumnName("product_id");
                        entity.Property(e => e.Sequence).HasColumnName("sequence");
                        entity.Property(e => e.StorageCategoryId).HasColumnName("storage_category_id");
                        entity.Property(e => e.Sublocation).HasColumnName("sublocation");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        entity.HasOne(d => d.Category).WithMany(p => p.StockPutawayRule)
                            .HasForeignKey(d => d.CategoryId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("stock_putaway_rule_category_id_fkey");

                        // entity.HasOne(d => d.Company).WithMany(p => p.StockPutawayRule) .HasForeignKey(d => d.TenantId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("stock_putaway_rule_company_id_fkey");
                        entity.HasOne(d => d.Company).WithMany()
                            .HasForeignKey(d => d.TenantId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("stock_putaway_rule_company_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.StockPutawayRuleCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("stock_putaway_rule_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_putaway_rule_create_uid_fkey");

                        entity.HasOne(d => d.LocationIn).WithMany(p => p.StockPutawayRuleLocationIn)
                            .HasForeignKey(d => d.LocationInId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("stock_putaway_rule_location_in_id_fkey");

                        entity.HasOne(d => d.LocationOut).WithMany(p => p.StockPutawayRuleLocationOut)
                            .HasForeignKey(d => d.LocationOutId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("stock_putaway_rule_location_out_id_fkey");

                        // entity.HasOne(d => d.Product).WithMany(p => p.StockPutawayRule) .HasForeignKey(d => d.ProductId) .OnDelete(DeleteBehavior.Cascade) .HasConstraintName("stock_putaway_rule_product_id_fkey");
                        entity.HasOne(d => d.Product).WithMany()
                            .HasForeignKey(d => d.ProductId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("stock_putaway_rule_product_id_fkey");

                        entity.HasOne(d => d.StorageCategory).WithMany(p => p.StockPutawayRule)
                            .HasForeignKey(d => d.StorageCategoryId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("stock_putaway_rule_storage_category_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.StockPutawayRuleWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("stock_putaway_rule_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_putaway_rule_write_uid_fkey");

                        // entity.HasMany(d => d.StockPackageType).WithMany(p => p.StockPutawayRule)
                        entity.HasMany(d => d.StockPackageType).WithMany(p => p.StockPutawayRule)
                            .UsingEntity<Dictionary<string, object>>(
                                "StockPackageTypeStockPutawayRuleRel",
                                r => r.HasOne<StockPackageType>().WithMany()
                                    .HasForeignKey("StockPackageTypeId")
                                    .HasConstraintName("stock_package_type_stock_putaway_rul_stock_package_type_id_fkey"),
                                l => l.HasOne<StockPutawayRule>().WithMany()
                                    .HasForeignKey("StockPutawayRuleId")
                                    .HasConstraintName("stock_package_type_stock_putaway_rul_stock_putaway_rule_id_fkey"),
                                j =>
                                {
                                    j.HasKey("StockPutawayRuleId", "StockPackageTypeId").HasName("stock_package_type_stock_putaway_rule_rel_pkey");
                                    j.ToTable("stock_package_type_stock_putaway_rule_rel");
                                    j.HasIndex(new[] { "StockPackageTypeId", "StockPutawayRuleId" }, "stock_package_type_stock_puta_stock_package_type_id_stock_p_idx");
                                    j.IndexerProperty<Guid>("StockPutawayRuleId").HasColumnName("stock_putaway_rule_id");
                                    j.IndexerProperty<Guid>("StockPackageTypeId").HasColumnName("stock_package_type_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}