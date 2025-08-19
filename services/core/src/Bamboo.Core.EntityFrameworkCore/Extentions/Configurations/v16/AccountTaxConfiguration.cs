using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Bamboo.Core.Models;
// Cần thêm using đến namespace chứa entity của bạn ở đây
// Ví dụ: using YourProject.Entities;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureAccountTax(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<AccountTax>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("account_tax_pkey");

            entity.ToTable("account_tax");

            entity.HasIndex(e => e.TenantId);

            entity.HasIndex(e => e.OrganizationUnitId);

            entity.HasIndex(e => new { e.Name, e.TenantId, e.TypeTaxUse, e.TaxScope }, "account_tax_name_company_uniq").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");

            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.Amount).HasColumnName("amount");
            entity.Property(e => e.AmountType).HasColumnName("amount_type");
            entity.Property(e => e.Analytic).HasColumnName("analytic");
            entity.Property(e => e.CashBasisTransitionAccountId).HasColumnName("cash_basis_transition_account_id");

            entity.Property(e => e.CountryId).HasColumnName("country_id");
            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.Description)
                .HasColumnType("jsonb")
                .HasColumnName("description");
            entity.Property(e => e.Formula).HasColumnName("formula");
            entity.Property(e => e.IncludeBaseAmount).HasColumnName("include_base_amount");
            entity.Property(e => e.InvoiceLabel)
                .HasColumnType("jsonb")
                .HasColumnName("invoice_label");
            entity.Property(e => e.InvoiceLegalNotes).HasColumnName("invoice_legal_notes");
            entity.Property(e => e.IsBaseAffected).HasColumnName("is_base_affected");
            entity.Property(e => e.Name)
                .HasColumnType("jsonb")
                .HasColumnName("name");
            entity.Property(e => e.PriceIncludeOverride).HasColumnName("price_include_override");
            entity.Property(e => e.PriceInclude).HasColumnName("price_include");
            entity.Property(e => e.RealAmount).HasColumnName("real_amount");
            entity.Property(e => e.Sequence).HasColumnName("sequence");
            entity.Property(e => e.TaxExigibility).HasColumnName("tax_exigibility");
            entity.Property(e => e.TaxGroupId).HasColumnName("tax_group_id");
            entity.Property(e => e.TaxScope).HasColumnName("tax_scope");
            entity.Property(e => e.TypeTaxUse).HasColumnName("type_tax_use");
            entity.Property(e => e.UblCiiTaxCategoryCode).HasColumnName("ubl_cii_tax_category_code");
            entity.Property(e => e.UblCiiTaxExemptionReasonCode).HasColumnName("ubl_cii_tax_exemption_reason_code");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            entity.HasOne(d => d.CashBasisTransitionAccount).WithMany()
                .HasForeignKey(d => d.CashBasisTransitionAccountId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("account_tax_cash_basis_transition_account_id_fkey");

            // entity.HasOne(d => d.Company).WithMany(p => p.AccountTax)
            entity.HasOne(d => d.Company).WithMany()
                .HasForeignKey(d => d.TenantId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("account_tax_company_id_fkey");

            // entity.HasOne(d => d.Country).WithMany(p => p.AccountTax)
            entity.HasOne(d => d.Country).WithMany()
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("account_tax_country_id_fkey");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.AccountTaxCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("account_tax_create_uid_fkey");

            entity.HasOne(d => d.TaxGroup).WithMany(p => p.AccountTax)
                .HasForeignKey(d => d.TaxGroupId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("account_tax_tax_group_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.AccountTaxWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("account_tax_write_uid_fkey");

            // entity.HasMany(d => d.ChildTax).WithMany(p => p.ParentTax)
            entity.HasMany(d => d.ChildTax).WithMany(p => p.ParentTax)
                .UsingEntity<Dictionary<string, object>>(
                    "AccountTaxFiliationRel",
                    r => r.HasOne<AccountTax>().WithMany()
                        .HasForeignKey("ChildTax")
                        .HasConstraintName("account_tax_filiation_rel_child_tax_fkey"),
                    l => l.HasOne<AccountTax>().WithMany()
                        .HasForeignKey("ParentTax")
                        .HasConstraintName("account_tax_filiation_rel_parent_tax_fkey"),
                    j =>
                    {
                        j.HasKey("ParentTax", "ChildTax").HasName("account_tax_filiation_rel_pkey");
                        j.ToTable("account_tax_filiation_rel");
                        j.HasIndex(new[] { "ChildTax", "ParentTax" }, "account_tax_filiation_rel_child_tax_parent_tax_idx");
                        j.IndexerProperty<Guid>("ParentTax").HasColumnName("parent_tax");
                        j.IndexerProperty<Guid>("ChildTax").HasColumnName("child_tax");
                    });

            // entity.HasMany(d => d.ParentTax).WithMany(p => p.ChildTax)
            entity.HasMany(d => d.ParentTax).WithMany(p => p.ChildTax)
                .UsingEntity<Dictionary<string, object>>(
                    "AccountTaxFiliationRel",
                    r => r.HasOne<AccountTax>().WithMany()
                        .HasForeignKey("ParentTax")
                        .HasConstraintName("account_tax_filiation_rel_parent_tax_fkey"),
                    l => l.HasOne<AccountTax>().WithMany()
                        .HasForeignKey("ChildTax")
                        .HasConstraintName("account_tax_filiation_rel_child_tax_fkey"),
                    j =>
                    {
                        j.HasKey("ParentTax", "ChildTax").HasName("account_tax_filiation_rel_pkey");
                        j.ToTable("account_tax_filiation_rel");
                        j.HasIndex(new[] { "ChildTax", "ParentTax" }, "account_tax_filiation_rel_child_tax_parent_tax_idx");
                        j.IndexerProperty<Guid>("ParentTax").HasColumnName("parent_tax");
                        j.IndexerProperty<Guid>("ChildTax").HasColumnName("child_tax");
                    });
            });
        }
    }
}
