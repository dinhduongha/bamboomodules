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
        public static void ConfigureAccountInvoiceSend(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountInvoiceSend>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("account_invoice_send_pkey");

                entity.ToTable("account_invoice_send");

                entity.HasIndex(e => e.TenantId, "account_invoice_send_company_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.ComposerId).HasColumnName("composer_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
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

                entity.HasOne(d => d.Composer).WithMany(p => p.AccountInvoiceSends)
                    .HasForeignKey(d => d.ComposerId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("account_invoice_send_composer_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_invoice_send_create_uid_fkey");

                entity.HasOne(d => d.Template).WithMany(p => p.AccountInvoiceSends)
                    .HasForeignKey(d => d.TemplateId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_invoice_send_template_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_invoice_send_write_uid_fkey");

                //entity.HasMany(d => d.AccountMoves).WithMany(p => p.AccountInvoiceSends)
                entity.HasMany<AccountMove>().WithMany()
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
                        });
            });
        }
    }
}