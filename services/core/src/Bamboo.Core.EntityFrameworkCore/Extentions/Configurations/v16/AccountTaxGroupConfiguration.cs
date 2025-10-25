using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureAccountTaxGroup(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<AccountTaxGroup>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("account_tax_group_pkey");

                        entity.ToTable("account_tax_group");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.AdvanceTaxPaymentAccountId).HasColumnName("advance_tax_payment_account_id");

                        entity.Property(e => e.CountryId).HasColumnName("country_id");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.Name)
                            .HasColumnType("jsonb")
                            .HasColumnName("name");
                        entity.Property(e => e.PosReceiptLabel).HasColumnName("pos_receipt_label");
                        entity.Property(e => e.PrecedingSubtotal)
                            .HasColumnType("jsonb")
                            .HasColumnName("preceding_subtotal");
                        entity.Property(e => e.Sequence).HasColumnName("sequence");
                        entity.Property(e => e.TaxPayableAccountId).HasColumnName("tax_payable_account_id");
                        entity.Property(e => e.TaxReceivableAccountId).HasColumnName("tax_receivable_account_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.AdvanceTaxPaymentAccount).WithMany(p => p.AccountTaxGroupAdvanceTaxPaymentAccount) .HasForeignKey(d => d.AdvanceTaxPaymentAccountId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("account_tax_group_advance_tax_payment_account_id_fkey");
                        entity.HasOne(d => d.AdvanceTaxPaymentAccount).WithMany()
                            .HasForeignKey(d => d.AdvanceTaxPaymentAccountId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_tax_group_advance_tax_payment_account_id_fkey");

                        // entity.HasOne(d => d.Company).WithMany(p => p.AccountTaxGroup) .HasForeignKey(d => d.TenantId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("account_tax_group_company_id_fkey");
                        entity.HasOne(d => d.Company).WithMany()
                            .HasForeignKey(d => d.TenantId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("account_tax_group_company_id_fkey");

                        // entity.HasOne(d => d.Country).WithMany(p => p.AccountTaxGroup) .HasForeignKey(d => d.CountryId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("account_tax_group_country_id_fkey");
                        entity.HasOne(d => d.Country).WithMany()
                            .HasForeignKey(d => d.CountryId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_tax_group_country_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.AccountTaxGroupCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("account_tax_group_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_tax_group_create_uid_fkey");

                        // entity.HasOne(d => d.TaxPayableAccount).WithMany(p => p.AccountTaxGroupTaxPayableAccount) .HasForeignKey(d => d.TaxPayableAccountId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("account_tax_group_tax_payable_account_id_fkey");
                        entity.HasOne(d => d.TaxPayableAccount).WithMany()
                            .HasForeignKey(d => d.TaxPayableAccountId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_tax_group_tax_payable_account_id_fkey");

                        // entity.HasOne(d => d.TaxReceivableAccount).WithMany(p => p.AccountTaxGroupTaxReceivableAccount) .HasForeignKey(d => d.TaxReceivableAccountId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("account_tax_group_tax_receivable_account_id_fkey");
                        entity.HasOne(d => d.TaxReceivableAccount).WithMany()
                            .HasForeignKey(d => d.TaxReceivableAccountId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_tax_group_tax_receivable_account_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.AccountTaxGroupWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("account_tax_group_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_tax_group_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}