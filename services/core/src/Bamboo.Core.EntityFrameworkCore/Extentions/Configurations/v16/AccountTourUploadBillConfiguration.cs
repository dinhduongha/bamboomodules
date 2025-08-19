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
        public static void ConfigureAccountTourUploadBill(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<AccountTourUploadBill>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("account_tour_upload_bill_pkey");

            entity.ToTable("account_tour_upload_bill");

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
            entity.Property(e => e.Selection).HasColumnName("selection");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.AccountTourUploadBillCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("account_tour_upload_bill_create_uid_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.AccountTourUploadBillWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("account_tour_upload_bill_write_uid_fkey");

            // entity.HasMany(d => d.IrAttachment).WithMany(p => p.AccountTourUploadBill)
            entity.HasMany(d => d.IrAttachment).WithMany()
                .UsingEntity<Dictionary<string, object>>(
                    "AccountTourUploadBillIrAttachmentsRel",
                    r => r.HasOne<IrAttachment>().WithMany()
                        .HasForeignKey("IrAttachmentId")
                        .HasConstraintName("account_tour_upload_bill_ir_attachments_r_ir_attachment_id_fkey"),
                    l => l.HasOne<AccountTourUploadBill>().WithMany()
                        .HasForeignKey("AccountTourUploadBillId")
                        .HasConstraintName("account_tour_upload_bill_ir_at_account_tour_upload_bill_id_fkey"),
                    j =>
                    {
                        j.HasKey("AccountTourUploadBillId", "IrAttachmentId").HasName("account_tour_upload_bill_ir_attachments_rel_pkey");
                        j.ToTable("account_tour_upload_bill_ir_attachments_rel");
                        j.HasIndex(new[] { "IrAttachmentId", "AccountTourUploadBillId" }, "account_tour_upload_bill_ir_a_ir_attachment_id_account_tour_idx");
                        j.IndexerProperty<Guid>("AccountTourUploadBillId").HasColumnName("account_tour_upload_bill_id");
                        j.IndexerProperty<Guid>("IrAttachmentId").HasColumnName("ir_attachment_id");
                    });
            });
        }
    }
}