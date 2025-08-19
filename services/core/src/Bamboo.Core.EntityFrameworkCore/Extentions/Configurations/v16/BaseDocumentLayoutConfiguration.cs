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
        public static void ConfigureBaseDocumentLayout(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<BaseDocumentLayout>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("base_document_layout_pkey");

            entity.ToTable("base_document_layout");

            entity.HasIndex(e => e.TenantId);

            entity.HasIndex(e => e.OrganizationUnitId);

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");

            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");

            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.FromInvoice).HasColumnName("from_invoice");
            entity.Property(e => e.ReportLayoutId).HasColumnName("report_layout_id");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.Company).WithMany(p => p.BaseDocumentLayout)
            entity.HasOne(d => d.Company).WithMany()
                .HasForeignKey(d => d.TenantId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("base_document_layout_company_id_fkey");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.BaseDocumentLayoutCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("base_document_layout_create_uid_fkey");

            entity.HasOne(d => d.ReportLayout).WithMany(p => p.BaseDocumentLayout)
                .HasForeignKey(d => d.ReportLayoutId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("base_document_layout_report_layout_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.BaseDocumentLayoutWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("base_document_layout_write_uid_fkey");
            });
        }
    }
}
