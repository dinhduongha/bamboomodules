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
        public static void ConfigureAccountTaxGroup(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountTaxGroup>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("account_tax_group_pkey");

                entity.ToTable("account_tax_group");

                entity.HasIndex(e => e.TenantId, "account_tax_group_company_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CountryId).HasColumnName("country_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.Name)
                    .HasColumnType("jsonb")
                    .HasColumnName("name");
                entity.Property(e => e.PosReceiptLabel).HasColumnName("pos_receipt_label");
                entity.Property(e => e.PrecedingSubtotal).HasColumnName("preceding_subtotal");
                entity.Property(e => e.Sequence)
                    .HasColumnName("sequence");
                entity.Property(e => e.TaxPayableAccountId).HasColumnName("tax_payable_account_id");
                entity.Property(e => e.TaxReceivableAccountId).HasColumnName("tax_receivable_account_id");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne(d => d.AdvanceTaxPaymentAccount).WithMany(p => p.AccountTaxGroupAdvanceTaxPaymentAccounts)
                    .HasForeignKey(d => d.AdvanceTaxPaymentAccountId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_tax_group_advance_tax_payment_account_id_fkey");

                entity.HasOne<ResCompany>().WithMany()
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("account_tax_group_company_id_fkey");

                entity.HasOne<ResCountry>().WithMany()
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_tax_group_country_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_tax_group_create_uid_fkey");

                entity.HasOne(d => d.TaxPayableAccount).WithMany(p => p.AccountTaxGroupTaxPayableAccounts)
                    .HasForeignKey(d => d.TaxPayableAccountId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_tax_group_tax_payable_account_id_fkey");

                entity.HasOne(d => d.TaxReceivableAccount).WithMany(p => p.AccountTaxGroupTaxReceivableAccounts)
                    .HasForeignKey(d => d.TaxReceivableAccountId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_tax_group_tax_receivable_account_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_tax_group_write_uid_fkey");
            });
        }
    }
}