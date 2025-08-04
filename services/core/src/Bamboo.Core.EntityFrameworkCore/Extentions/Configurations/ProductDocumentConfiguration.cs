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
        public static void ConfigureProductDocument(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductDocument>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("product_document_pkey");

                entity.ToTable("product_document");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.Active).HasColumnName("active");
                entity.Property(e => e.AttachedOnMrp).HasColumnName("attached_on_mrp");
                entity.Property(e => e.AttachedOnSale).HasColumnName("attached_on_sale");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.IrAttachmentId).HasColumnName("ir_attachment_id");
                entity.Property(e => e.Sequence).HasColumnName("sequence");
                entity.Property(e => e.ShownOnProductPage).HasColumnName("shown_on_product_page");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("product_document_create_uid_fkey");

                entity.HasOne(d => d.IrAttachment).WithMany(p => p.ProductDocuments)
                    .HasForeignKey(d => d.IrAttachmentId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("product_document_ir_attachment_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("product_document_write_uid_fkey");

                entity.HasMany(d => d.SalePdfFormFields).WithMany(p => p.ProductDocuments)
                    .UsingEntity<Dictionary<string, object>>(
                        "ProductDocumentSalePdfFormFieldRel",
                        r => r.HasOne<SalePdfFormField>().WithMany()
                            .HasForeignKey("SalePdfFormFieldId")
                            .HasConstraintName("product_document_sale_pdf_form_fiel_sale_pdf_form_field_id_fkey"),
                        l => l.HasOne<ProductDocument>().WithMany()
                            .HasForeignKey("ProductDocumentId")
                            .HasConstraintName("product_document_sale_pdf_form_field_r_product_document_id_fkey"),
                        j =>
                        {
                            j.HasKey("ProductDocumentId", "SalePdfFormFieldId").HasName("product_document_sale_pdf_form_field_rel_pkey");
                            j.ToTable("product_document_sale_pdf_form_field_rel");
                            j.HasIndex(new[] { "SalePdfFormFieldId", "ProductDocumentId" }, "product_document_sale_pdf_for_sale_pdf_form_field_id_produc_idx");
                            j.IndexerProperty<Guid>("ProductDocumentId").HasColumnName("product_document_id");
                            j.IndexerProperty<Guid>("SalePdfFormFieldId").HasColumnName("sale_pdf_form_field_id");
                        });
            });
        }
    }
}