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
        public static void ConfigurePaymentProviderOnboardingWizard(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<PaymentProviderOnboardingWizard>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("payment_provider_onboarding_wizard_pkey");

            entity.ToTable("payment_provider_onboarding_wizard");

            entity.HasIndex(e => e.TenantId);

            entity.HasIndex(e => e.OrganizationUnitId);

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");

            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
            entity.Property(e => e.AccNumber).HasColumnName("acc_number");
            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.JournalName).HasColumnName("journal_name");
            entity.Property(e => e.ManualName).HasColumnName("manual_name");
            entity.Property(e => e.ManualPostMsg).HasColumnName("manual_post_msg");
            entity.Property(e => e.PaymentMethod).HasColumnName("payment_method");
            entity.Property(e => e.PaypalEmailAccount).HasColumnName("paypal_email_account");
            entity.Property(e => e.PaypalPdtToken).HasColumnName("paypal_pdt_token");
            entity.Property(e => e.PaypalSellerAccount).HasColumnName("paypal_seller_account");
            entity.Property(e => e.PaypalUserType).HasColumnName("paypal_user_type");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.PaymentProviderOnboardingWizardCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("payment_provider_onboarding_wizard_create_uid_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.PaymentProviderOnboardingWizardWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("payment_provider_onboarding_wizard_write_uid_fkey");
            });
        }
    }
}