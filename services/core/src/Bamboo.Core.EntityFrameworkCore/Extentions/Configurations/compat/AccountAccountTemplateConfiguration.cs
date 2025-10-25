using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureAccountAccountTemplate(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<AccountAccountTemplate>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("account_account_template_pkey");

                        entity.ToTable("account_account_template");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.AccountType).HasColumnName("account_type");
                        entity.Property(e => e.ChartTemplateId).HasColumnName("chart_template_id");
                        entity.Property(e => e.Code).HasColumnName("code");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
                        entity.Property(e => e.MessageMainAttachmentId).HasColumnName("message_main_attachment_id");
                        entity.Property(e => e.Name)
                            .HasColumnType("jsonb")
                            .HasColumnName("name");
                        entity.Property(e => e.Nocreate).HasColumnName("nocreate");
                        entity.Property(e => e.Note).HasColumnName("note");
                        entity.Property(e => e.Reconcile).HasColumnName("reconcile");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        entity.HasOne(d => d.ChartTemplate).WithMany(p => p.AccountAccountTemplate)
                            .HasForeignKey(d => d.ChartTemplateId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_account_template_chart_template_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.AccountAccountTemplateCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("account_account_template_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_account_template_create_uid_fkey");

                        // entity.HasOne(d => d.Currency).WithMany(p => p.AccountAccountTemplate) .HasForeignKey(d => d.CurrencyId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("account_account_template_currency_id_fkey");
                        entity.HasOne(d => d.Currency).WithMany()
                            .HasForeignKey(d => d.CurrencyId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_account_template_currency_id_fkey");

                        // entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.AccountAccountTemplate) .HasForeignKey(d => d.MessageMainAttachmentId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("account_account_template_message_main_attachment_id_fkey");
                        entity.HasOne(d => d.MessageMainAttachment).WithMany()
                            .HasForeignKey(d => d.MessageMainAttachmentId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_account_template_message_main_attachment_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.AccountAccountTemplateWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("account_account_template_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_account_template_write_uid_fkey");

                        // entity.HasMany(d => d.AccountAccountTag).WithMany(p => p.AccountAccountTemplate)
                        entity.HasMany(d => d.AccountAccountTag).WithMany(p => p.AccountAccountTemplate)
                            .UsingEntity<Dictionary<string, object>>(
                                "AccountAccountTemplateAccountTag",
                                r => r.HasOne<AccountAccountTag>().WithMany()
                                    .HasForeignKey("AccountAccountTagId")
                                    .HasConstraintName("account_account_template_account_ta_account_account_tag_id_fkey"),
                                l => l.HasOne<AccountAccountTemplate>().WithMany()
                                    .HasForeignKey("AccountAccountTemplateId")
                                    .HasConstraintName("account_account_template_accou_account_account_template_id_fkey"),
                                j =>
                                {
                                    j.HasKey("AccountAccountTemplateId", "AccountAccountTagId").HasName("account_account_template_account_tag_pkey");
                                    j.ToTable("account_account_template_account_tag");
                                    j.HasIndex(new[] { "AccountAccountTagId", "AccountAccountTemplateId" }, "account_account_template_acco_account_account_tag_id_accoun_idx");
                                    j.IndexerProperty<Guid>("AccountAccountTemplateId").HasColumnName("account_account_template_id");
                                    j.IndexerProperty<Guid>("AccountAccountTagId").HasColumnName("account_account_tag_id");
                                });

                        // entity.HasMany(d => d.Tax).WithMany(p => p.Account)
                        entity.HasMany(d => d.Tax).WithMany(p => p.Account)
                            .UsingEntity<Dictionary<string, object>>(
                                "AccountAccountTemplateTaxRel",
                                r => r.HasOne<AccountTaxTemplate>().WithMany()
                                    .HasForeignKey("TaxId")
                                    .HasConstraintName("account_account_template_tax_rel_tax_id_fkey"),
                                l => l.HasOne<AccountAccountTemplate>().WithMany()
                                    .HasForeignKey("AccountId")
                                    .HasConstraintName("account_account_template_tax_rel_account_id_fkey"),
                                j =>
                                {
                                    j.HasKey("AccountId", "TaxId").HasName("account_account_template_tax_rel_pkey");
                                    j.ToTable("account_account_template_tax_rel");
                                    j.HasIndex(new[] { "TaxId", "AccountId" }, "account_account_template_tax_rel_tax_id_account_id_idx");
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