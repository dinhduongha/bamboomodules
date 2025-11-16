using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
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

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
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
                        entity.Property(e => e.InvoiceLegalNotes)
                            .HasColumnType("jsonb")
                            .HasColumnName("invoice_legal_notes");
                        entity.Property(e => e.IsBaseAffected).HasColumnName("is_base_affected");
                        entity.Property(e => e.IsDomestic).HasColumnName("is_domestic");
                        entity.Property(e => e.IsWithholdingTaxOnPayment).HasColumnName("is_withholding_tax_on_payment");
                        entity.Property(e => e.Name)
                            .HasColumnType("jsonb")
                            .HasColumnName("name");
                        entity.Property(e => e.PriceIncludeOverride).HasColumnName("price_include_override");
                        entity.Property(e => e.Sequence).HasColumnName("sequence");
                        entity.Property(e => e.TaxExigibility).HasColumnName("tax_exigibility");
                        entity.Property(e => e.TaxGroupId).HasColumnName("tax_group_id");
                        entity.Property(e => e.TaxScope).HasColumnName("tax_scope");
                        entity.Property(e => e.TypeTaxUse).HasColumnName("type_tax_use");
                        entity.Property(e => e.UblCiiTaxCategoryCode).HasColumnName("ubl_cii_tax_category_code");
                        entity.Property(e => e.UblCiiTaxExemptionReasonCode).HasColumnName("ubl_cii_tax_exemption_reason_code");
                        entity.Property(e => e.WithholdingSequenceId).HasColumnName("withholding_sequence_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CashBasisTransitionAccount).WithMany(p => p.AccountTax) .HasForeignKey(d => d.CashBasisTransitionAccountId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("account_tax_cash_basis_transition_account_id_fkey");
                        entity.HasOne(d => d.CashBasisTransitionAccount).WithMany()
                            .HasForeignKey(d => d.CashBasisTransitionAccountId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_tax_cash_basis_transition_account_id_fkey");

                        // entity.HasOne(d => d.Company).WithMany(p => p.AccountTax) .HasForeignKey(d => d.TenantId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("account_tax_company_id_fkey");
                        entity.HasOne(d => d.Company).WithMany()
                            .HasForeignKey(d => d.TenantId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("account_tax_company_id_fkey");

                        // entity.HasOne(d => d.Country).WithMany(p => p.AccountTax) .HasForeignKey(d => d.CountryId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("account_tax_country_id_fkey");
                        entity.HasOne(d => d.Country).WithMany()
                            .HasForeignKey(d => d.CountryId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("account_tax_country_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.AccountTaxCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("account_tax_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_tax_create_uid_fkey");

                        entity.HasOne(d => d.TaxGroup).WithMany(p => p.AccountTax)
                            .HasForeignKey(d => d.TaxGroupId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("account_tax_tax_group_id_fkey");

                        entity.HasOne(d => d.WithholdingSequence).WithMany(p => p.AccountTax)
                            .HasForeignKey(d => d.WithholdingSequenceId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_tax_withholding_sequence_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.AccountTaxWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("account_tax_write_uid_fkey");
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

                        // entity.HasMany(d => d.DestTax).WithMany(p => p.SrcTax)
                        entity.HasMany(d => d.DestTax).WithMany(p => p.SrcTax)
                            .UsingEntity<Dictionary<string, object>>(
                                "AccountTaxAlternatives",
                                r => r.HasOne<AccountTax>().WithMany()
                                    .HasForeignKey("DestTaxId")
                                    .HasConstraintName("account_tax_alternatives_dest_tax_id_fkey"),
                                l => l.HasOne<AccountTax>().WithMany()
                                    .HasForeignKey("SrcTaxId")
                                    .HasConstraintName("account_tax_alternatives_src_tax_id_fkey"),
                                j =>
                                {
                                    j.HasKey("DestTaxId", "SrcTaxId").HasName("account_tax_alternatives_pkey");
                                    j.ToTable("account_tax_alternatives");
                                    j.HasIndex(new[] { "SrcTaxId", "DestTaxId" }, "account_tax_alternatives_src_tax_id_dest_tax_id_idx");
                                    j.IndexerProperty<Guid>("DestTaxId").HasColumnName("dest_tax_id");
                                    j.IndexerProperty<Guid>("SrcTaxId").HasColumnName("src_tax_id");
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

                        // entity.HasMany(d => d.SrcTax).WithMany(p => p.DestTax)
                        entity.HasMany(d => d.SrcTax).WithMany(p => p.DestTax)
                            .UsingEntity<Dictionary<string, object>>(
                                "AccountTaxAlternatives",
                                r => r.HasOne<AccountTax>().WithMany()
                                    .HasForeignKey("SrcTaxId")
                                    .HasConstraintName("account_tax_alternatives_src_tax_id_fkey"),
                                l => l.HasOne<AccountTax>().WithMany()
                                    .HasForeignKey("DestTaxId")
                                    .HasConstraintName("account_tax_alternatives_dest_tax_id_fkey"),
                                j =>
                                {
                                    j.HasKey("DestTaxId", "SrcTaxId").HasName("account_tax_alternatives_pkey");
                                    j.ToTable("account_tax_alternatives");
                                    j.HasIndex(new[] { "SrcTaxId", "DestTaxId" }, "account_tax_alternatives_src_tax_id_dest_tax_id_idx");
                                    j.IndexerProperty<Guid>("DestTaxId").HasColumnName("dest_tax_id");
                                    j.IndexerProperty<Guid>("SrcTaxId").HasColumnName("src_tax_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}