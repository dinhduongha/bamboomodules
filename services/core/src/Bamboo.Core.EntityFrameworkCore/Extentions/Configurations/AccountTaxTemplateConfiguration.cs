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
        public static void ConfigureAccountTaxTemplate(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountTaxTemplate>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("account_tax_template_pkey");

                entity.ToTable("account_tax_template");

                entity.HasIndex(e => e.TenantId, "account_tax_template_company_id_index");

                entity.HasIndex(e => new { e.TenantId, e.Name, e.TypeTaxUse, e.TaxScope, e.ChartTemplateId }, "account_tax_template_name_company_uniq").IsUnique();

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.Active).HasColumnName("active");
                entity.Property(e => e.Amount).HasColumnName("amount");
                entity.Property(e => e.AmountType).HasColumnName("amount_type");
                entity.Property(e => e.Analytic).HasColumnName("analytic");
                entity.Property(e => e.CashBasisTransitionAccountId).HasColumnName("cash_basis_transition_account_id");
                entity.Property(e => e.ChartTemplateId).HasColumnName("chart_template_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.Description)
                    .HasColumnType("jsonb")
                    .HasColumnName("description");
                entity.Property(e => e.IncludeBaseAmount).HasColumnName("include_base_amount");
                entity.Property(e => e.IsBaseAffected).HasColumnName("is_base_affected");
                entity.Property(e => e.Name)
                    .HasColumnType("jsonb")
                    .HasColumnName("name");
                entity.Property(e => e.PriceInclude).HasColumnName("price_include");
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

                entity.HasOne(d => d.CashBasisTransitionAccount).WithMany(p => p.AccountTaxTemplates)
                    .HasForeignKey(d => d.CashBasisTransitionAccountId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_tax_template_cash_basis_transition_account_id_fkey");

                entity.HasOne(d => d.ChartTemplate).WithMany(p => p.AccountTaxTemplates)
                    .HasForeignKey(d => d.ChartTemplateId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("account_tax_template_chart_template_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_tax_template_create_uid_fkey");

                entity.HasOne(d => d.TaxGroup).WithMany(p => p.AccountTaxTemplates)
                    .HasForeignKey(d => d.TaxGroupId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_tax_template_tax_group_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_tax_template_write_uid_fkey");

                //entity.HasMany(d => d.ChildTaxes).WithMany(p => p.ParentTaxes)
                entity.HasMany<AccountTaxTemplate>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "AccountTaxTemplateFiliationRel",
                        r => r.HasOne<AccountTaxTemplate>().WithMany()
                            .HasForeignKey("ChildTax")
                            .HasConstraintName("account_tax_template_filiation_rel_child_tax_fkey"),
                        l => l.HasOne<AccountTaxTemplate>().WithMany()
                            .HasForeignKey("ParentTax")
                            .HasConstraintName("account_tax_template_filiation_rel_parent_tax_fkey"),
                        j =>
                        {
                            j.HasKey("ParentTax", "ChildTax").HasName("account_tax_template_filiation_rel_pkey");
                            j.ToTable("account_tax_template_filiation_rel");
                            j.HasIndex(new[] { "ChildTax", "ParentTax" }, "account_tax_template_filiation_rel_child_tax_parent_tax_idx");
                        });

                //entity.HasMany(d => d.ParentTaxes).WithMany(p => p.ChildTaxes)
                entity.HasMany<AccountTaxTemplate>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "AccountTaxTemplateFiliationRel",
                        r => r.HasOne<AccountTaxTemplate>().WithMany()
                            .HasForeignKey("ParentTax")
                            .HasConstraintName("account_tax_template_filiation_rel_parent_tax_fkey"),
                        l => l.HasOne<AccountTaxTemplate>().WithMany()
                            .HasForeignKey("ChildTax")
                            .HasConstraintName("account_tax_template_filiation_rel_child_tax_fkey"),
                        j =>
                        {
                            j.HasKey("ParentTax", "ChildTax").HasName("account_tax_template_filiation_rel_pkey");
                            j.ToTable("account_tax_template_filiation_rel");
                            j.HasIndex(new[] { "ChildTax", "ParentTax" }, "account_tax_template_filiation_rel_child_tax_parent_tax_idx");
                        });
            });
        }
    }
}