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
        public static void ConfigureSaleAdvancePaymentInv(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SaleAdvancePaymentInv>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("sale_advance_payment_inv_pkey");

                entity.ToTable("sale_advance_payment_inv");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.AdvancePaymentMethod).HasColumnName("advance_payment_method");
                entity.Property(e => e.Amount).HasColumnName("amount");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
                entity.Property(e => e.DeductDownPayments).HasColumnName("deduct_down_payments");
                entity.Property(e => e.DepositAccountId).HasColumnName("deposit_account_id");
                entity.Property(e => e.FixedAmount).HasColumnName("fixed_amount");
                entity.Property(e => e.ProductId).HasColumnName("product_id");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResCompany>().WithMany()
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("sale_advance_payment_inv_company_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("sale_advance_payment_inv_create_uid_fkey");

                entity.HasOne<ResCurrency>().WithMany()
                    .HasForeignKey(d => d.CurrencyId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("sale_advance_payment_inv_currency_id_fkey");

                entity.HasOne(d => d.DepositAccount).WithMany(p => p.SaleAdvancePaymentInvs)
                    .HasForeignKey(d => d.DepositAccountId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("sale_advance_payment_inv_deposit_account_id_fkey");

                entity.HasOne(d => d.Product).WithMany(p => p.SaleAdvancePaymentInvs)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("sale_advance_payment_inv_product_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("sale_advance_payment_inv_write_uid_fkey");

                //entity.HasMany(d => d.AccountTaxes).WithMany(p => p.SaleAdvancePaymentInvs)
                entity.HasMany<AccountTax>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "AccountTaxSaleAdvancePaymentInvRel",
                        r => r.HasOne<AccountTax>().WithMany()
                            .HasForeignKey("AccountTaxId")
                            .HasConstraintName("account_tax_sale_advance_payment_inv_rel_account_tax_id_fkey"),
                        l => l.HasOne<SaleAdvancePaymentInv>().WithMany()
                            .HasForeignKey("SaleAdvancePaymentInvId")
                            .HasConstraintName("account_tax_sale_advance_payme_sale_advance_payment_inv_id_fkey"),
                        j =>
                        {
                            j.HasKey("SaleAdvancePaymentInvId", "AccountTaxId").HasName("account_tax_sale_advance_payment_inv_rel_pkey");
                            j.ToTable("account_tax_sale_advance_payment_inv_rel");
                            j.HasIndex(new[] { "AccountTaxId", "SaleAdvancePaymentInvId" }, "account_tax_sale_advance_paym_account_tax_id_sale_advance_p_idx");
                        });

                //entity.HasMany(d => d.SaleOrders).WithMany(p => p.SaleAdvancePaymentInvs)
                entity.HasMany<SaleOrder>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "SaleAdvancePaymentInvSaleOrderRel",
                        r => r.HasOne<SaleOrder>().WithMany()
                            .HasForeignKey("SaleOrderId")
                            .HasConstraintName("sale_advance_payment_inv_sale_order_rel_sale_order_id_fkey"),
                        l => l.HasOne<SaleAdvancePaymentInv>().WithMany()
                            .HasForeignKey("SaleAdvancePaymentInvId")
                            .HasConstraintName("sale_advance_payment_inv_sale__sale_advance_payment_inv_id_fkey"),
                        j =>
                        {
                            j.HasKey("SaleAdvancePaymentInvId", "SaleOrderId").HasName("sale_advance_payment_inv_sale_order_rel_pkey");
                            j.ToTable("sale_advance_payment_inv_sale_order_rel");
                            j.HasIndex(new[] { "SaleOrderId", "SaleAdvancePaymentInvId" }, "sale_advance_payment_inv_sale_sale_order_id_sale_advance_pa_idx");
                        });
            });
        }
    }
}