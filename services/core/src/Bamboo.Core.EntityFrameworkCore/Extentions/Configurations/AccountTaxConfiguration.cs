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
        public static void ConfigureAccountTax(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountTax>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("account_tax_pkey");

                entity.ToTable("account_tax");

                entity.HasIndex(e => e.TenantId, "account_tax_company_id_index");

                entity.HasIndex(e => new { e.TenantId, e.Name, e.TypeTaxUse, e.TaxScope }, "account_tax_name_company_uniq").IsUnique();

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.Active).HasColumnName("active");
                entity.Property(e => e.Amount).HasColumnName("amount");
                entity.Property(e => e.AmountType).HasColumnName("amount_type");
                entity.Property(e => e.Analytic).HasColumnName("analytic");
                entity.Property(e => e.CashBasisTransitionAccountId).HasColumnName("cash_basis_transition_account_id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CountryId).HasColumnName("country_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.Description)
                    .HasColumnType("jsonb")
                    .HasColumnName("description");
                entity.Property(e => e.IncludeBaseAmount).HasColumnName("include_base_amount");
                entity.Property(e => e.InvoiceLabel)
                    .HasColumnType("jsonb")
                    .HasColumnName("invoice_label");
                entity.Property(e => e.InvoiceLegalNotes).HasColumnName("invoice_legal_notes");
                entity.Property(e => e.IsBaseAffected).HasColumnName("is_base_affected");
                entity.Property(e => e.Name)
                    .HasColumnType("jsonb")
                    .HasColumnName("name");
                entity.Property(e => e.PriceInclude).HasColumnName("price_include");
                entity.Property(e => e.RealAmount).HasColumnName("real_amount");
                entity.Property(e => e.PriceIncludeOverride).HasColumnName("price_include_override");
                entity.Property(e => e.Sequence)
                    .HasColumnName("sequence");
                entity.Property(e => e.TaxExigibility).HasColumnName("tax_exigibility");
                entity.Property(e => e.TaxGroupId).HasColumnName("tax_group_id");
                entity.Property(e => e.TaxScope).HasColumnName("tax_scope");
                entity.Property(e => e.TypeTaxUse).HasColumnName("type_tax_use");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne(d => d.CashBasisTransitionAccount).WithMany(p => p.AccountTaxes)
                    .HasForeignKey(d => d.CashBasisTransitionAccountId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_tax_cash_basis_transition_account_id_fkey");

                entity.HasOne<ResCompany>().WithMany()
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("account_tax_company_id_fkey");

                entity.HasOne<ResCountry>().WithMany()
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("account_tax_country_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_tax_create_uid_fkey");

                entity.HasOne(d => d.TaxGroup).WithMany(p => p.AccountTaxes)
                    .HasForeignKey(d => d.TaxGroupId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("account_tax_tax_group_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_tax_write_uid_fkey");

                //entity.HasMany(d => d.ChildTaxes).WithMany(p => p.ParentTaxes)
                entity.HasMany<AccountTax>().WithMany()
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

                //entity.HasMany(d => d.ParentTaxes).WithMany(p => p.ChildTaxes)
                entity.HasMany<AccountTax>().WithMany()
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