using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureSaleOrderDiscount(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<SaleOrderDiscount>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("sale_order_discount_pkey");

                        entity.ToTable("sale_order_discount");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.DiscountAmount).HasColumnName("discount_amount");
                        entity.Property(e => e.DiscountPercentage).HasColumnName("discount_percentage");
                        entity.Property(e => e.DiscountType).HasColumnName("discount_type");
                        entity.Property(e => e.SaleOrderId).HasColumnName("sale_order_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.SaleOrderDiscountCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("sale_order_discount_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("sale_order_discount_create_uid_fkey");

                        entity.HasOne(d => d.SaleOrder).WithMany(p => p.SaleOrderDiscount)
                            .HasForeignKey(d => d.SaleOrderId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("sale_order_discount_sale_order_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.SaleOrderDiscountWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("sale_order_discount_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("sale_order_discount_write_uid_fkey");

                        // entity.HasMany(d => d.AccountTax).WithMany(p => p.SaleOrderDiscount)
                        entity.HasMany(d => d.AccountTax).WithMany(p => p.SaleOrderDiscount)
                            .UsingEntity<Dictionary<string, object>>(
                                "AccountTaxSaleOrderDiscountRel",
                                r => r.HasOne<AccountTax>().WithMany()
                                    .HasForeignKey("AccountTaxId")
                                    .HasConstraintName("account_tax_sale_order_discount_rel_account_tax_id_fkey"),
                                l => l.HasOne<SaleOrderDiscount>().WithMany()
                                    .HasForeignKey("SaleOrderDiscountId")
                                    .HasConstraintName("account_tax_sale_order_discount_rel_sale_order_discount_id_fkey"),
                                j =>
                                {
                                    j.HasKey("SaleOrderDiscountId", "AccountTaxId").HasName("account_tax_sale_order_discount_rel_pkey");
                                    j.ToTable("account_tax_sale_order_discount_rel");
                                    j.HasIndex(new[] { "AccountTaxId", "SaleOrderDiscountId" }, "account_tax_sale_order_discou_account_tax_id_sale_order_dis_idx");
                                    j.IndexerProperty<Guid>("SaleOrderDiscountId").HasColumnName("sale_order_discount_id");
                                    j.IndexerProperty<Guid>("AccountTaxId").HasColumnName("account_tax_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}