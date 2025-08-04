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
        public static void ConfigureSnailmailConfirmInvoice(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SnailmailConfirmInvoice>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("snailmail_confirm_invoice_pkey");

                entity.ToTable("snailmail_confirm_invoice");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.InvoiceSendId).HasColumnName("invoice_send_id");
                entity.Property(e => e.ModelName).HasColumnName("model_name");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("snailmail_confirm_invoice_create_uid_fkey");

                entity.HasOne(d => d.InvoiceSend).WithMany(p => p.SnailmailConfirmInvoices)
                    .HasForeignKey(d => d.InvoiceSendId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("snailmail_confirm_invoice_invoice_send_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("snailmail_confirm_invoice_write_uid_fkey");
            });
        }
    }
}