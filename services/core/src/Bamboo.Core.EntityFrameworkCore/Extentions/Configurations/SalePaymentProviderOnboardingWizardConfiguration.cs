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
        public static void ConfigureSalePaymentProviderOnboardingWizard(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SalePaymentProviderOnboardingWizard>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("sale_payment_provider_onboarding_wizard_pkey");

                entity.ToTable("sale_payment_provider_onboarding_wizard");

                entity.HasIndex(e => e.TenantId, "sale_payment_provider_onboarding_wizard_company_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.AccNumber).HasColumnName("acc_number");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
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

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("sale_payment_provider_onboarding_wizard_create_uid_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("sale_payment_provider_onboarding_wizard_write_uid_fkey");
            });
        }
    }
}