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
        public static void ConfigureAccountTaxRepartitionLineTemplate(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountTaxRepartitionLineTemplate>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("account_tax_repartition_line_template_pkey");

                entity.ToTable("account_tax_repartition_line_template");

                entity.HasIndex(e => e.TenantId, "account_tax_repartition_line_template_company_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.AccountId).HasColumnName("account_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.FactorPercent).HasColumnName("factor_percent");
                entity.Property(e => e.InvoiceTaxId).HasColumnName("invoice_tax_id");
                entity.Property(e => e.RefundTaxId).HasColumnName("refund_tax_id");
                entity.Property(e => e.RepartitionType).HasColumnName("repartition_type");
                entity.Property(e => e.UseInTaxClosing).HasColumnName("use_in_tax_closing");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne(d => d.Account).WithMany(p => p.AccountTaxRepartitionLineTemplates)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_tax_repartition_line_template_account_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_tax_repartition_line_template_create_uid_fkey");

                entity.HasOne(d => d.InvoiceTax).WithMany(p => p.AccountTaxRepartitionLineTemplateInvoiceTaxes)
                    .HasForeignKey(d => d.InvoiceTaxId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_tax_repartition_line_template_invoice_tax_id_fkey");

                entity.HasOne(d => d.RefundTax).WithMany(p => p.AccountTaxRepartitionLineTemplateRefundTaxes)
                    .HasForeignKey(d => d.RefundTaxId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_tax_repartition_line_template_refund_tax_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_tax_repartition_line_template_write_uid_fkey");

                //entity.HasMany(d => d.AccountAccountTags).WithMany(p => p.AccountTaxRepartitionLineTemplates)
                entity.HasMany<AccountAccountTag>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "AccountTaxRepartitionFinancialTag",
                        r => r.HasOne<AccountAccountTag>().WithMany()
                            .HasForeignKey("AccountAccountTagId")
                            .HasConstraintName("account_tax_repartition_financial_t_account_account_tag_id_fkey"),
                        l => l.HasOne<AccountTaxRepartitionLineTemplate>().WithMany()
                            .HasForeignKey("AccountTaxRepartitionLineTemplateId")
                            .HasConstraintName("account_tax_repartition_finan_account_tax_repartition_line_fkey"),
                        j =>
                        {
                            j.HasKey("AccountTaxRepartitionLineTemplateId", "AccountAccountTagId").HasName("account_tax_repartition_financial_tags_pkey");
                            j.ToTable("account_tax_repartition_financial_tags");
                            j.HasIndex(new[] { "AccountAccountTagId", "AccountTaxRepartitionLineTemplateId" }, "account_tax_repartition_finan_account_account_tag_id_accoun_idx");
                        });

                /// TODO: SharedTypeEntity
                //entity.HasMany(d => d.AccountReportExpressions).WithMany(p => p.AccountTaxRepartitionLineTemplates)
                entity.HasMany<AccountReportExpression>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "AccountTaxRepTemplateMinu",
                        r => r.HasOne<AccountReportExpression>().WithMany()
                            .HasForeignKey("AccountReportExpressionId")
                            .HasConstraintName("account_tax_rep_template_minu_account_report_expression_id_fkey"),
                        l => l.HasOne<AccountTaxRepartitionLineTemplate>().WithMany()
                            .HasForeignKey("AccountTaxRepartitionLineTemplateId")
                            .HasConstraintName("account_tax_rep_template_minu_account_tax_repartition_line_fkey"),
                        j =>
                        {
                            j.HasKey("AccountTaxRepartitionLineTemplateId", "AccountReportExpressionId").HasName("account_tax_rep_template_minus_pkey");
                            j.ToTable("account_tax_rep_template_minus");
                            j.HasIndex(new[] { "AccountReportExpressionId", "AccountTaxRepartitionLineTemplateId" }, "account_tax_rep_template_minu_account_report_expression_id__idx");
                        });

                /// TODO: SharedTypeEntity
                //entity.HasMany(d => d.AccountReportExpressionsNavigation).WithMany(p => p.AccountTaxRepartitionLineTemplatesNavigation)
                entity.HasMany<AccountReportExpression>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "AccountTaxRepTemplatePlu",
                        r => r.HasOne<AccountReportExpression>().WithMany()
                            .HasForeignKey("AccountReportExpressionId")
                            .HasConstraintName("account_tax_rep_template_plus_account_report_expression_id_fkey"),
                        l => l.HasOne<AccountTaxRepartitionLineTemplate>().WithMany()
                            .HasForeignKey("AccountTaxRepartitionLineTemplateId")
                            .HasConstraintName("account_tax_rep_template_plus_account_tax_repartition_line_fkey"),
                        j =>
                        {
                            j.HasKey("AccountTaxRepartitionLineTemplateId", "AccountReportExpressionId").HasName("account_tax_rep_template_plus_pkey");
                            j.ToTable("account_tax_rep_template_plus");
                            j.HasIndex(new[] { "AccountReportExpressionId", "AccountTaxRepartitionLineTemplateId" }, "account_tax_rep_template_plus_account_report_expression_id__idx");
                        });
            });
        }
    }
}