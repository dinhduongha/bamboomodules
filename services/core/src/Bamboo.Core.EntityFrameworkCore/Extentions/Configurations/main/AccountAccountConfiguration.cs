using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureAccountAccount(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<AccountAccount>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("account_account_pkey");

                        entity.ToTable("account_account");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.AccountType, "account_account__account_type_index");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.AccountStockExpenseId).HasColumnName("account_stock_expense_id");
                        entity.Property(e => e.AccountStockVariationId).HasColumnName("account_stock_variation_id");
                        entity.Property(e => e.AccountType).HasColumnName("account_type");
                        entity.Property(e => e.Active).HasColumnName("active");
                        entity.Property(e => e.CodeStore)
                            .HasColumnType("jsonb")
                            .HasColumnName("code_store");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
                        entity.Property(e => e.Description)
                            .HasColumnType("jsonb")
                            .HasColumnName("description");
                        entity.Property(e => e.Name)
                            .HasColumnType("jsonb")
                            .HasColumnName("name");
                        entity.Property(e => e.NonTrade).HasColumnName("non_trade");
                        entity.Property(e => e.Note).HasColumnName("note");
                        entity.Property(e => e.Reconcile).HasColumnName("reconcile");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.AccountStockExpense).WithMany(p => p.InverseAccountStockExpense) .HasForeignKey(d => d.AccountStockExpenseId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("account_account_account_stock_expense_id_fkey");
                        entity.HasOne(d => d.AccountStockExpense).WithMany()
                            .HasForeignKey(d => d.AccountStockExpenseId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_account_account_stock_expense_id_fkey");

                        // entity.HasOne(d => d.AccountStockVariation).WithMany(p => p.InverseAccountStockVariation) .HasForeignKey(d => d.AccountStockVariationId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("account_account_account_stock_variation_id_fkey");
                        entity.HasOne(d => d.AccountStockVariation).WithMany()
                            .HasForeignKey(d => d.AccountStockVariationId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_account_account_stock_variation_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.AccountAccountCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("account_account_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_account_create_uid_fkey");

                        // entity.HasOne(d => d.Currency).WithMany(p => p.AccountAccount) .HasForeignKey(d => d.CurrencyId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("account_account_currency_id_fkey");
                        entity.HasOne(d => d.Currency).WithMany()
                            .HasForeignKey(d => d.CurrencyId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_account_currency_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.AccountAccountWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("account_account_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_account_write_uid_fkey");

                        // entity.HasMany(d => d.AccountAccountTag).WithMany(p => p.AccountAccount)
                        entity.HasMany<AccountAccountTag>().WithMany()
                            .UsingEntity<Dictionary<string, object>>(
                                "AccountAccountAccountTag",
                                r => r.HasOne<AccountAccountTag>().WithMany()
                                    .HasForeignKey("AccountAccountTagId")
                                    .OnDelete(DeleteBehavior.Restrict)
                                    .HasConstraintName("account_account_account_tag_account_account_tag_id_fkey"),
                                l => l.HasOne<AccountAccount>().WithMany()
                                    .HasForeignKey("AccountAccountId")
                                    .HasConstraintName("account_account_account_tag_account_account_id_fkey"),
                                j =>
                                {
                                    j.HasKey("AccountAccountId", "AccountAccountTagId").HasName("account_account_account_tag_pkey");
                                    j.ToTable("account_account_account_tag");
                                    j.HasIndex(new[] { "AccountAccountTagId", "AccountAccountId" }, "account_account_account_tag_account_account_tag_id_account__idx");
                                    j.IndexerProperty<Guid>("AccountAccountId").HasColumnName("account_account_id");
                                    j.IndexerProperty<Guid>("AccountAccountTagId").HasColumnName("account_account_tag_id");
                                });

                        // entity.HasMany(d => d.ResCompany).WithMany(p => p.AccountAccount)
                        entity.HasMany<ResCompany>().WithMany()
                            .UsingEntity<Dictionary<string, object>>(
                                "AccountAccountResCompanyRel",
                                r => r.HasOne<ResCompany>().WithMany()
                                    .HasForeignKey("ResCompanyId")
                                    .HasConstraintName("account_account_res_company_rel_res_company_id_fkey"),
                                l => l.HasOne<AccountAccount>().WithMany()
                                    .HasForeignKey("AccountAccountId")
                                    .HasConstraintName("account_account_res_company_rel_account_account_id_fkey"),
                                j =>
                                {
                                    j.HasKey("AccountAccountId", "ResCompanyId").HasName("account_account_res_company_rel_pkey");
                                    j.ToTable("account_account_res_company_rel");
                                    j.HasIndex(new[] { "ResCompanyId", "AccountAccountId" }, "account_account_res_company_r_res_company_id_account_accoun_idx");
                                    j.IndexerProperty<Guid>("AccountAccountId").HasColumnName("account_account_id");
                                    j.IndexerProperty<Guid>("ResCompanyId").HasColumnName("res_company_id");
                                });

                        // entity.HasMany(d => d.Tax).WithMany(p => p.Account)
                        entity.HasMany<AccountTax>().WithMany()
                            .UsingEntity<Dictionary<string, object>>(
                                "AccountAccountTaxDefaultRel",
                                r => r.HasOne<AccountTax>().WithMany()
                                    .HasForeignKey("TaxId")
                                    .HasConstraintName("account_account_tax_default_rel_tax_id_fkey"),
                                l => l.HasOne<AccountAccount>().WithMany()
                                    .HasForeignKey("AccountId")
                                    .HasConstraintName("account_account_tax_default_rel_account_id_fkey"),
                                j =>
                                {
                                    j.HasKey("AccountId", "TaxId").HasName("account_account_tax_default_rel_pkey");
                                    j.ToTable("account_account_tax_default_rel");
                                    j.HasIndex(new[] { "TaxId", "AccountId" }, "account_account_tax_default_rel_tax_id_account_id_idx");
                                    j.IndexerProperty<Guid>("AccountId").HasColumnName("account_id");
                                    j.IndexerProperty<Guid>("TaxId").HasColumnName("tax_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}