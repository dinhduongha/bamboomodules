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
        public static void ConfigureQuotationDocument(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<QuotationDocument>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("quotation_document_pkey");

                entity.ToTable("quotation_document");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.Active).HasColumnName("active");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.DocumentType).HasColumnName("document_type");
                entity.Property(e => e.IrAttachmentId).HasColumnName("ir_attachment_id");
                entity.Property(e => e.Sequence).HasColumnName("sequence");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("quotation_document_create_uid_fkey");

                entity.HasOne(d => d.IrAttachment).WithMany(p => p.QuotationDocuments)
                    .HasForeignKey(d => d.IrAttachmentId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("quotation_document_ir_attachment_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("quotation_document_write_uid_fkey");

                entity.HasMany(d => d.SaleOrderTemplates).WithMany(p => p.QuotationDocuments)
                    .UsingEntity<Dictionary<string, object>>(
                        "HeaderFooterQuotationTemplateRel",
                        r => r.HasOne<SaleOrderTemplate>().WithMany()
                            .HasForeignKey("SaleOrderTemplateId")
                            .HasConstraintName("header_footer_quotation_template_re_sale_order_template_id_fkey"),
                        l => l.HasOne<QuotationDocument>().WithMany()
                            .HasForeignKey("QuotationDocumentId")
                            .HasConstraintName("header_footer_quotation_template_rel_quotation_document_id_fkey"),
                        j =>
                        {
                            j.HasKey("QuotationDocumentId", "SaleOrderTemplateId").HasName("header_footer_quotation_template_rel_pkey");
                            j.ToTable("header_footer_quotation_template_rel");
                            j.HasIndex(new[] { "SaleOrderTemplateId", "QuotationDocumentId" }, "header_footer_quotation_templ_sale_order_template_id_quotat_idx");
                            j.IndexerProperty<Guid>("QuotationDocumentId").HasColumnName("quotation_document_id");
                            j.IndexerProperty<Guid>("SaleOrderTemplateId").HasColumnName("sale_order_template_id");
                        });

                entity.HasMany(d => d.SalePdfFormFields).WithMany(p => p.QuotationDocuments)
                    .UsingEntity<Dictionary<string, object>>(
                        "QuotationDocumentSalePdfFormFieldRel",
                        r => r.HasOne<SalePdfFormField>().WithMany()
                            .HasForeignKey("SalePdfFormFieldId")
                            .HasConstraintName("quotation_document_sale_pdf_form_fi_sale_pdf_form_field_id_fkey"),
                        l => l.HasOne<QuotationDocument>().WithMany()
                            .HasForeignKey("QuotationDocumentId")
                            .HasConstraintName("quotation_document_sale_pdf_form_fie_quotation_document_id_fkey"),
                        j =>
                        {
                            j.HasKey("QuotationDocumentId", "SalePdfFormFieldId").HasName("quotation_document_sale_pdf_form_field_rel_pkey");
                            j.ToTable("quotation_document_sale_pdf_form_field_rel");
                            j.HasIndex(new[] { "SalePdfFormFieldId", "QuotationDocumentId" }, "quotation_document_sale_pdf_f_sale_pdf_form_field_id_quotat_idx");
                            j.IndexerProperty<Guid>("QuotationDocumentId").HasColumnName("quotation_document_id");
                            j.IndexerProperty<Guid>("SalePdfFormFieldId").HasColumnName("sale_pdf_form_field_id");
                        });
            });
        }
    }
}