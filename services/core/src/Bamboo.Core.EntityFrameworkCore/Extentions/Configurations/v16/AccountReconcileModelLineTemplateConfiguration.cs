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
        public static void ConfigureAccountReconcileModelLineTemplate(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<AccountReconcileModelLineTemplate>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("account_reconcile_model_line_template_pkey");

            entity.ToTable("account_reconcile_model_line_template");

            entity.HasIndex(e => e.TenantId);

            entity.HasIndex(e => e.OrganizationUnitId);

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");

            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.AmountString).HasColumnName("amount_string");
            entity.Property(e => e.AmountType).HasColumnName("amount_type");
            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.ForceTaxIncluded).HasColumnName("force_tax_included");
            entity.Property(e => e.Label).HasColumnName("label");
            entity.Property(e => e.ModelId).HasColumnName("model_id");
            entity.Property(e => e.Sequence).HasColumnName("sequence");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.Account).WithMany(p => p.AccountReconcileModelLineTemplate)
            entity.HasOne(d => d.Account).WithMany()
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("account_reconcile_model_line_template_account_id_fkey");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.AccountReconcileModelLineTemplateCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("account_reconcile_model_line_template_create_uid_fkey");

            entity.HasOne(d => d.Model).WithMany(p => p.AccountReconcileModelLineTemplate)
                .HasForeignKey(d => d.ModelId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("account_reconcile_model_line_template_model_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.AccountReconcileModelLineTemplateWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("account_reconcile_model_line_template_write_uid_fkey");

            // entity.HasMany(d => d.AccountTaxTemplate).WithMany(p => p.AccountReconcileModelLineTemplate)
            entity.HasMany(d => d.AccountTaxTemplate).WithMany(p => p.AccountReconcileModelLineTemplate)
                .UsingEntity<Dictionary<string, object>>(
                    "AccountReconcileModelLineTemplateAccountTaxTemplateRel",
                    r => r.HasOne<AccountTaxTemplate>().WithMany()
                        .HasForeignKey("AccountTaxTemplateId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("account_reconcile_model_line_templ_account_tax_template_id_fkey"),
                    l => l.HasOne<AccountReconcileModelLineTemplate>().WithMany()
                        .HasForeignKey("AccountReconcileModelLineTemplateId")
                        .HasConstraintName("account_reconcile_model_line_account_reconcile_model_line_fkey1"),
                    j =>
                    {
                        j.HasKey("AccountReconcileModelLineTemplateId", "AccountTaxTemplateId").HasName("account_reconcile_model_line_template_account_tax_template_pkey");
                        j.ToTable("account_reconcile_model_line_template_account_tax_template_rel");
                        j.HasIndex(new[] { "AccountTaxTemplateId", "AccountReconcileModelLineTemplateId" }, "account_reconcile_model_line__account_tax_template_id_accou_idx");
                        j.IndexerProperty<Guid>("AccountReconcileModelLineTemplateId").HasColumnName("account_reconcile_model_line_template_id");
                        j.IndexerProperty<Guid>("AccountTaxTemplateId").HasColumnName("account_tax_template_id");
                    });
            });
        }
    }
}