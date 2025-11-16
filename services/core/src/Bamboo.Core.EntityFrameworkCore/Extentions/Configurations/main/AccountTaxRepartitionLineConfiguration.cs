using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureAccountTaxRepartitionLine(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<AccountTaxRepartitionLine>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("account_tax_repartition_line_pkey");

                        entity.ToTable("account_tax_repartition_line");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.TaxId, "account_tax_repartition_line__tax_id_index").HasFilter("(tax_id IS NOT NULL)");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.AccountId).HasColumnName("account_id");

                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.DocumentType).HasColumnName("document_type");
                        entity.Property(e => e.FactorPercent).HasColumnName("factor_percent");
                        entity.Property(e => e.RepartitionType).HasColumnName("repartition_type");
                        entity.Property(e => e.Sequence).HasColumnName("sequence");
                        entity.Property(e => e.TaxId).HasColumnName("tax_id");
                        entity.Property(e => e.UseInTaxClosing).HasColumnName("use_in_tax_closing");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.Account).WithMany(p => p.AccountTaxRepartitionLine) .HasForeignKey(d => d.AccountId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("account_tax_repartition_line_account_id_fkey");
                        entity.HasOne(d => d.Account).WithMany()
                            .HasForeignKey(d => d.AccountId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_tax_repartition_line_account_id_fkey");

                        // entity.HasOne(d => d.Company).WithMany(p => p.AccountTaxRepartitionLine) .HasForeignKey(d => d.TenantId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("account_tax_repartition_line_company_id_fkey");
                        entity.HasOne(d => d.Company).WithMany()
                            .HasForeignKey(d => d.TenantId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_tax_repartition_line_company_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.AccountTaxRepartitionLineCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("account_tax_repartition_line_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_tax_repartition_line_create_uid_fkey");

                        entity.HasOne(d => d.Tax).WithMany(p => p.AccountTaxRepartitionLine)
                            .HasForeignKey(d => d.TaxId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("account_tax_repartition_line_tax_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.AccountTaxRepartitionLineWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("account_tax_repartition_line_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_tax_repartition_line_write_uid_fkey");

                        // entity.HasMany(d => d.AccountAccountTag).WithMany(p => p.AccountTaxRepartitionLine)
                        entity.HasMany(d => d.AccountAccountTag).WithMany(p => p.AccountTaxRepartitionLine)
                            .UsingEntity<Dictionary<string, object>>(
                                "AccountAccountTagAccountTaxRepartitionLineRel",
                                r => r.HasOne<AccountAccountTag>().WithMany()
                                    .HasForeignKey("AccountAccountTagId")
                                    .OnDelete(DeleteBehavior.Restrict)
                                    .HasConstraintName("account_account_tag_account_tax_rep_account_account_tag_id_fkey"),
                                l => l.HasOne<AccountTaxRepartitionLine>().WithMany()
                                    .HasForeignKey("AccountTaxRepartitionLineId")
                                    .HasConstraintName("account_account_tag_account_t_account_tax_repartition_line_fkey"),
                                j =>
                                {
                                    j.HasKey("AccountTaxRepartitionLineId", "AccountAccountTagId").HasName("account_account_tag_account_tax_repartition_line_rel_pkey");
                                    j.ToTable("account_account_tag_account_tax_repartition_line_rel");
                                    j.HasIndex(new[] { "AccountAccountTagId", "AccountTaxRepartitionLineId" }, "account_account_tag_account_t_account_account_tag_id_accoun_idx");
                                    j.IndexerProperty<Guid>("AccountTaxRepartitionLineId").HasColumnName("account_tax_repartition_line_id");
                                    j.IndexerProperty<Guid>("AccountAccountTagId").HasColumnName("account_account_tag_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}