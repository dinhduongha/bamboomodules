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
        public static void ConfigureResPartnerBank(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<ResPartnerBank>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("res_partner_bank_pkey");

            entity.ToTable("res_partner_bank");

            entity.HasIndex(e => e.TenantId);

            entity.HasIndex(e => e.OrganizationUnitId);

            entity.HasIndex(e => e.PartnerId, "res_partner_bank__partner_id_index");

            entity.HasIndex(e => new { e.SanitizedAccNumber, e.PartnerId }, "res_partner_bank_unique_number").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");

            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
            entity.Property(e => e.AbaRouting).HasColumnName("aba_routing");
            entity.Property(e => e.AccHolderName).HasColumnName("acc_holder_name");
            entity.Property(e => e.AccNumber).HasColumnName("acc_number");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.AllowOutPayment).HasColumnName("allow_out_payment");
            entity.Property(e => e.BankId).HasColumnName("bank_id");

            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
            entity.Property(e => e.HasIbanWarning).HasColumnName("has_iban_warning");
            entity.Property(e => e.HasMoneyTransferWarning).HasColumnName("has_money_transfer_warning");
            entity.Property(e => e.IncludeReference).HasColumnName("include_reference");
            entity.Property(e => e.MessageMainAttachmentId).HasColumnName("message_main_attachment_id");
            entity.Property(e => e.PartnerId).HasColumnName("partner_id");
            entity.Property(e => e.ProxyType).HasColumnName("proxy_type");
            entity.Property(e => e.ProxyValue).HasColumnName("proxy_value");
            entity.Property(e => e.SanitizedAccNumber).HasColumnName("sanitized_acc_number");
            entity.Property(e => e.Sequence).HasColumnName("sequence");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            entity.HasOne(d => d.Bank).WithMany(p => p.ResPartnerBank)
                .HasForeignKey(d => d.BankId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("res_partner_bank_bank_id_fkey");

            // entity.HasOne(d => d.Company).WithMany(p => p.ResPartnerBank)
            entity.HasOne(d => d.Company).WithMany()
                .HasForeignKey(d => d.TenantId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("res_partner_bank_company_id_fkey");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.ResPartnerBankCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("res_partner_bank_create_uid_fkey");

            // entity.HasOne(d => d.Currency).WithMany(p => p.ResPartnerBank)
            entity.HasOne(d => d.Currency).WithMany()
                .HasForeignKey(d => d.CurrencyId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("res_partner_bank_currency_id_fkey");

            // entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.ResPartnerBank)
            entity.HasOne(d => d.MessageMainAttachment).WithMany()
                .HasForeignKey(d => d.MessageMainAttachmentId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("res_partner_bank_message_main_attachment_id_fkey");

            // entity.HasOne(d => d.Partner).WithMany(p => p.ResPartnerBank)
            entity.HasOne(d => d.Partner).WithMany()
                .HasForeignKey(d => d.PartnerId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("res_partner_bank_partner_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.ResPartnerBankWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("res_partner_bank_write_uid_fkey");
            });
        }
    }
}
