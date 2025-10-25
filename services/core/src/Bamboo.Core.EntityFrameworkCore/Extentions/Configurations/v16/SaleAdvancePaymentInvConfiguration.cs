using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
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

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.AdvancePaymentMethod).HasColumnName("advance_payment_method");
                        entity.Property(e => e.Amount).HasColumnName("amount");

                        entity.Property(e => e.ConsolidatedBilling).HasColumnName("consolidated_billing");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
                        entity.Property(e => e.DateEndInvoiceTimesheet).HasColumnName("date_end_invoice_timesheet");
                        entity.Property(e => e.DateStartInvoiceTimesheet).HasColumnName("date_start_invoice_timesheet");
                        entity.Property(e => e.DeductDownPayments).HasColumnName("deduct_down_payments");
                        entity.Property(e => e.FixedAmount).HasColumnName("fixed_amount");
                        entity.Property(e => e.InvoicingTimesheetEnabled).HasColumnName("invoicing_timesheet_enabled");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.Company).WithMany(p => p.SaleAdvancePaymentInv) .HasForeignKey(d => d.TenantId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("sale_advance_payment_inv_company_id_fkey");
                        entity.HasOne(d => d.Company).WithMany()
                            .HasForeignKey(d => d.TenantId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("sale_advance_payment_inv_company_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.SaleAdvancePaymentInvCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("sale_advance_payment_inv_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("sale_advance_payment_inv_create_uid_fkey");

                        // entity.HasOne(d => d.Currency).WithMany(p => p.SaleAdvancePaymentInv) .HasForeignKey(d => d.CurrencyId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("sale_advance_payment_inv_currency_id_fkey");
                        entity.HasOne(d => d.Currency).WithMany()
                            .HasForeignKey(d => d.CurrencyId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("sale_advance_payment_inv_currency_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.SaleAdvancePaymentInvWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("sale_advance_payment_inv_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("sale_advance_payment_inv_write_uid_fkey");

                        // entity.HasMany(d => d.SaleOrder).WithMany(p => p.SaleAdvancePaymentInv)
                        entity.HasMany(d => d.SaleOrder).WithMany(p => p.SaleAdvancePaymentInv)
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
                                    j.IndexerProperty<Guid>("SaleAdvancePaymentInvId").HasColumnName("sale_advance_payment_inv_id");
                                    j.IndexerProperty<Guid>("SaleOrderId").HasColumnName("sale_order_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}