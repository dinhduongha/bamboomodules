using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
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

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.InvoiceSendId).HasColumnName("invoice_send_id");
                        entity.Property(e => e.ModelName).HasColumnName("model_name");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.SnailmailConfirmInvoiceCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("snailmail_confirm_invoice_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("snailmail_confirm_invoice_create_uid_fkey");

                        entity.HasOne(d => d.InvoiceSend).WithMany(p => p.SnailmailConfirmInvoice)
                            .HasForeignKey(d => d.InvoiceSendId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("snailmail_confirm_invoice_invoice_send_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.SnailmailConfirmInvoiceWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("snailmail_confirm_invoice_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("snailmail_confirm_invoice_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}