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
        public static void ConfigureAccountInvoiceSend(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<AccountInvoiceSend>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("account_invoice_send_pkey");

            entity.ToTable("account_invoice_send");

            entity.HasIndex(e => e.TenantId);

            entity.HasIndex(e => e.OrganizationUnitId);

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");

            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
            entity.Property(e => e.ComposerId).HasColumnName("composer_id");
            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.IsEmail).HasColumnName("is_email");
            entity.Property(e => e.IsPrint).HasColumnName("is_print");
            entity.Property(e => e.Printed).HasColumnName("printed");
            entity.Property(e => e.SnailmailIsLetter).HasColumnName("snailmail_is_letter");
            entity.Property(e => e.TemplateId).HasColumnName("template_id");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            entity.HasOne(d => d.Composer).WithMany(p => p.AccountInvoiceSend)
                .HasForeignKey(d => d.ComposerId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("account_invoice_send_composer_id_fkey");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.AccountInvoiceSendCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("account_invoice_send_create_uid_fkey");

            entity.HasOne(d => d.Template).WithMany(p => p.AccountInvoiceSend)
                .HasForeignKey(d => d.TemplateId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("account_invoice_send_template_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.AccountInvoiceSendWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("account_invoice_send_write_uid_fkey");

            // entity.HasMany(d => d.AccountMove).WithMany(p => p.AccountInvoiceSend)
            entity.HasMany(d => d.AccountMove).WithMany(p => p.AccountInvoiceSend)
                .UsingEntity<Dictionary<string, object>>(
                    "AccountMoveAccountInvoiceSendRel",
                    r => r.HasOne<AccountMove>().WithMany()
                        .HasForeignKey("AccountMoveId")
                        .HasConstraintName("account_move_account_invoice_send_rel_account_move_id_fkey"),
                    l => l.HasOne<AccountInvoiceSend>().WithMany()
                        .HasForeignKey("AccountInvoiceSendId")
                        .HasConstraintName("account_move_account_invoice_send__account_invoice_send_id_fkey"),
                    j =>
                    {
                        j.HasKey("AccountInvoiceSendId", "AccountMoveId").HasName("account_move_account_invoice_send_rel_pkey");
                        j.ToTable("account_move_account_invoice_send_rel");
                        j.HasIndex(new[] { "AccountMoveId", "AccountInvoiceSendId" }, "account_move_account_invoice__account_move_id_account_invoi_idx");
                        j.IndexerProperty<Guid>("AccountInvoiceSendId").HasColumnName("account_invoice_send_id");
                        j.IndexerProperty<Guid>("AccountMoveId").HasColumnName("account_move_id");
                    });
            });
        }
    }
}