using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureAccountPaymentWithholdingLine(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<AccountPaymentWithholdingLine>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("account_payment_withholding_line_pkey");

                        entity.ToTable("account_payment_withholding_line");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.AccountId).HasColumnName("account_id");
                        entity.Property(e => e.Amount).HasColumnName("amount");
                        entity.Property(e => e.AnalyticDistribution)
                            .HasColumnType("jsonb")
                            .HasColumnName("analytic_distribution");
                        entity.Property(e => e.BaseAmount).HasColumnName("base_amount");

                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.Name).HasColumnName("name");
                        entity.Property(e => e.PaymentId).HasColumnName("payment_id");
                        entity.Property(e => e.PlaceholderType).HasColumnName("placeholder_type");
                        entity.Property(e => e.PlaceholderValue).HasColumnName("placeholder_value");
                        entity.Property(e => e.PreviousPlaceholderType).HasColumnName("previous_placeholder_type");
                        entity.Property(e => e.SourceBaseAmount).HasColumnName("source_base_amount");
                        entity.Property(e => e.SourceBaseAmountCurrency).HasColumnName("source_base_amount_currency");
                        entity.Property(e => e.SourceCurrencyId).HasColumnName("source_currency_id");
                        entity.Property(e => e.SourceTaxAmount).HasColumnName("source_tax_amount");
                        entity.Property(e => e.SourceTaxAmountCurrency).HasColumnName("source_tax_amount_currency");
                        entity.Property(e => e.SourceTaxId).HasColumnName("source_tax_id");
                        entity.Property(e => e.TaxId).HasColumnName("tax_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.Account).WithMany(p => p.AccountPaymentWithholdingLine) .HasForeignKey(d => d.AccountId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("account_payment_withholding_line_account_id_fkey");
                        entity.HasOne(d => d.Account).WithMany()
                            .HasForeignKey(d => d.AccountId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("account_payment_withholding_line_account_id_fkey");

                        // entity.HasOne(d => d.Company).WithMany(p => p.AccountPaymentWithholdingLine) .HasForeignKey(d => d.TenantId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("account_payment_withholding_line_company_id_fkey");
                        entity.HasOne(d => d.Company).WithMany()
                            .HasForeignKey(d => d.TenantId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("account_payment_withholding_line_company_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.AccountPaymentWithholdingLineCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("account_payment_withholding_line_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_payment_withholding_line_create_uid_fkey");

                        entity.HasOne(d => d.Payment).WithMany(p => p.AccountPaymentWithholdingLine)
                            .HasForeignKey(d => d.PaymentId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("account_payment_withholding_line_payment_id_fkey");

                        // entity.HasOne(d => d.SourceCurrency).WithMany(p => p.AccountPaymentWithholdingLine) .HasForeignKey(d => d.SourceCurrencyId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("account_payment_withholding_line_source_currency_id_fkey");
                        entity.HasOne(d => d.SourceCurrency).WithMany()
                            .HasForeignKey(d => d.SourceCurrencyId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_payment_withholding_line_source_currency_id_fkey");

                        entity.HasOne(d => d.SourceTax).WithMany(p => p.AccountPaymentWithholdingLineSourceTax)
                            .HasForeignKey(d => d.SourceTaxId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_payment_withholding_line_source_tax_id_fkey");

                        entity.HasOne(d => d.Tax).WithMany(p => p.AccountPaymentWithholdingLineTax)
                            .HasForeignKey(d => d.TaxId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("account_payment_withholding_line_tax_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.AccountPaymentWithholdingLineWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("account_payment_withholding_line_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_payment_withholding_line_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}