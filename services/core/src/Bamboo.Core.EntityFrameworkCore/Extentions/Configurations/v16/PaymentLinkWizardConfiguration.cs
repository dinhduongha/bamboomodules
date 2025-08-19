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
        public static void ConfigurePaymentLinkWizard(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<PaymentLinkWizard>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("payment_link_wizard_pkey");

            entity.ToTable("payment_link_wizard");

            entity.HasIndex(e => e.TenantId);

            entity.HasIndex(e => e.OrganizationUnitId);

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");

            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
            entity.Property(e => e.Amount).HasColumnName("amount");
            entity.Property(e => e.AmountMax).HasColumnName("amount_max");
            entity.Property(e => e.AmountPaid).HasColumnName("amount_paid");
            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.DiscountDate).HasColumnName("discount_date");
            entity.Property(e => e.HasEligibleEpd).HasColumnName("has_eligible_epd");
            entity.Property(e => e.OpenInstallments)
                .HasColumnType("jsonb")
                .HasColumnName("open_installments");
            entity.Property(e => e.PartnerId).HasColumnName("partner_id");
            entity.Property(e => e.PaymentProviderSelection).HasColumnName("payment_provider_selection");
            entity.Property(e => e.ResId).HasColumnName("res_id");
            entity.Property(e => e.ResModel).HasColumnName("res_model");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.PaymentLinkWizardCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("payment_link_wizard_create_uid_fkey");

            // entity.HasOne(d => d.Currency).WithMany(p => p.PaymentLinkWizard)
            entity.HasOne(d => d.Currency).WithMany()
                .HasForeignKey(d => d.CurrencyId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("payment_link_wizard_currency_id_fkey");

            // entity.HasOne(d => d.Partner).WithMany(p => p.PaymentLinkWizard)
            entity.HasOne(d => d.Partner).WithMany()
                .HasForeignKey(d => d.PartnerId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("payment_link_wizard_partner_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.PaymentLinkWizardWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("payment_link_wizard_write_uid_fkey");
            });
        }
    }
}
