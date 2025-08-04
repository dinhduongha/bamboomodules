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
        public static void ConfigureResPartnerBank(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ResPartnerBank>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("res_partner_bank_pkey");

                entity.ToTable("res_partner_bank");

                entity.HasIndex(e => e.TenantId, "res_partner_bank_partner_company_id_index");

                entity.HasIndex(e => e.PartnerId, "res_partner_bank_partner_id_index");

                entity.HasIndex(e => new { e.TenantId, e.SanitizedAccNumber, e.PartnerId }, "res_partner_bank_unique_number").IsUnique();

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.AccHolderName).HasColumnName("acc_holder_name");
                entity.Property(e => e.AccNumber).HasColumnName("acc_number");
                entity.Property(e => e.Active).HasColumnName("active");
                entity.Property(e => e.AllowOutPayment).HasColumnName("allow_out_payment");
                entity.Property(e => e.BankId).HasColumnName("bank_id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
                entity.Property(e => e.MessageMainAttachmentId).HasColumnName("message_main_attachment_id");
                entity.Property(e => e.PartnerId).HasColumnName("partner_id");
                entity.Property(e => e.SanitizedAccNumber).HasColumnName("sanitized_acc_number");
                entity.Property(e => e.Sequence)
                    .HasColumnName("sequence");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne(d => d.Bank).WithMany(p => p.ResPartnerBanks)
                    .HasForeignKey(d => d.BankId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("res_partner_bank_bank_id_fkey");

                entity.HasOne<ResCompany>().WithMany()
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("res_partner_bank_company_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("res_partner_bank_create_uid_fkey");

                entity.HasOne<ResCurrency>().WithMany()
                    .HasForeignKey(d => d.CurrencyId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("res_partner_bank_currency_id_fkey");

                entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.ResPartnerBanks)
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("res_partner_bank_message_main_attachment_id_fkey");

                entity.HasOne<ResPartner>().WithMany()
                    .HasForeignKey(d => d.PartnerId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("res_partner_bank_partner_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("res_partner_bank_write_uid_fkey");
            });
        }
    }
}