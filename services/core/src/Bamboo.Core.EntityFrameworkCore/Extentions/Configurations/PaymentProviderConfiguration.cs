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
        public static void ConfigurePaymentProvider(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PaymentProvider>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("payment_provider_pkey");

                entity.ToTable("payment_provider");

                entity.HasIndex(e => e.TenantId, "payment_provider_company_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.AllowExpressCheckout).HasColumnName("allow_express_checkout");
                entity.Property(e => e.AllowTokenization).HasColumnName("allow_tokenization");
                entity.Property(e => e.AuthMsg)
                    .HasColumnType("jsonb")
                    .HasColumnName("auth_msg");
                entity.Property(e => e.CancelMsg)
                    .HasColumnType("jsonb")
                    .HasColumnName("cancel_msg");
                entity.Property(e => e.CaptureManually).HasColumnName("capture_manually");
                entity.Property(e => e.Code).HasColumnName("code");
                entity.Property(e => e.Color).HasColumnName("color");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.DisplayAs)
                    .HasColumnType("jsonb")
                    .HasColumnName("display_as");
                entity.Property(e => e.DoneMsg)
                    .HasColumnType("jsonb")
                    .HasColumnName("done_msg");
                entity.Property(e => e.ExpressCheckoutFormViewId).HasColumnName("express_checkout_form_view_id");
                entity.Property(e => e.FeesActive).HasColumnName("fees_active");
                entity.Property(e => e.FeesDomFixed).HasColumnName("fees_dom_fixed");
                entity.Property(e => e.FeesDomVar).HasColumnName("fees_dom_var");
                entity.Property(e => e.FeesIntFixed).HasColumnName("fees_int_fixed");
                entity.Property(e => e.FeesIntVar).HasColumnName("fees_int_var");
                entity.Property(e => e.InlineFormViewId).HasColumnName("inline_form_view_id");
                entity.Property(e => e.IsPublished).HasColumnName("is_published");
                entity.Property(e => e.MaximumAmount).HasColumnName("maximum_amount");
                entity.Property(e => e.ModuleId).HasColumnName("module_id");
                entity.Property(e => e.ModuleState).HasColumnName("module_state");
                entity.Property(e => e.Name)
                    .HasColumnType("jsonb")
                    .HasColumnName("name");
                entity.Property(e => e.PendingMsg)
                    .HasColumnType("jsonb")
                    .HasColumnName("pending_msg");
                entity.Property(e => e.PreMsg)
                    .HasColumnType("jsonb")
                    .HasColumnName("pre_msg");
                entity.Property(e => e.RedirectFormViewId).HasColumnName("redirect_form_view_id");
                entity.Property(e => e.Sequence).HasColumnName("sequence");
                entity.Property(e => e.SoReferenceType).HasColumnName("so_reference_type");
                entity.Property(e => e.State).HasColumnName("state");
                entity.Property(e => e.TokenInlineFormViewId).HasColumnName("token_inline_form_view_id");
                entity.Property(e => e.WebsiteId).HasColumnName("website_id");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResCompany>().WithMany()
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("payment_provider_company_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("payment_provider_create_uid_fkey");

                entity.HasOne(d => d.ExpressCheckoutFormView).WithMany(p => p.PaymentProviderExpressCheckoutFormViews)
                    .HasForeignKey(d => d.ExpressCheckoutFormViewId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("payment_provider_express_checkout_form_view_id_fkey");

                entity.HasOne(d => d.InlineFormView).WithMany(p => p.PaymentProviderInlineFormViews)
                    .HasForeignKey(d => d.InlineFormViewId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("payment_provider_inline_form_view_id_fkey");

                entity.HasOne(d => d.Module).WithMany(p => p.PaymentProviders)
                    .HasForeignKey(d => d.ModuleId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("payment_provider_module_id_fkey");

                entity.HasOne(d => d.RedirectFormView).WithMany(p => p.PaymentProviderRedirectFormViews)
                    .HasForeignKey(d => d.RedirectFormViewId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("payment_provider_redirect_form_view_id_fkey");

                entity.HasOne(d => d.TokenInlineFormView).WithMany(p => p.PaymentProviderTokenInlineFormViews)
                    .HasForeignKey(d => d.TokenInlineFormViewId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("payment_provider_token_inline_form_view_id_fkey");

                entity.HasOne(d => d.Website).WithMany(p => p.PaymentProviders)
                    .HasForeignKey(d => d.WebsiteId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("payment_provider_website_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("payment_provider_write_uid_fkey");

                //entity.HasMany(d => d.Countries).WithMany(p => p.Payments)
                entity.HasMany<ResCountry>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "PaymentCountryRel",
                        r => r.HasOne<ResCountry>().WithMany()
                            .HasForeignKey("CountryId")
                            .HasConstraintName("payment_country_rel_country_id_fkey"),
                        l => l.HasOne<PaymentProvider>().WithMany()
                            .HasForeignKey("PaymentId")
                            .HasConstraintName("payment_country_rel_payment_id_fkey"),
                        j =>
                        {
                            j.HasKey("PaymentId", "CountryId").HasName("payment_country_rel_pkey");
                            j.ToTable("payment_country_rel");
                            j.HasIndex(new[] { "CountryId", "PaymentId" }, "payment_country_rel_country_id_payment_id_idx");
                        });

                //entity.HasMany(d => d.PaymentIcons).WithMany(p => p.PaymentProviders)
                entity.HasMany<PaymentIcon>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "PaymentIconPaymentProviderRel",
                        r => r.HasOne<PaymentIcon>().WithMany()
                            .HasForeignKey("PaymentIconId")
                            .HasConstraintName("payment_icon_payment_provider_rel_payment_icon_id_fkey"),
                        l => l.HasOne<PaymentProvider>().WithMany()
                            .HasForeignKey("PaymentProviderId")
                            .HasConstraintName("payment_icon_payment_provider_rel_payment_provider_id_fkey"),
                        j =>
                        {
                            j.HasKey("PaymentProviderId", "PaymentIconId").HasName("payment_icon_payment_provider_rel_pkey");
                            j.ToTable("payment_icon_payment_provider_rel");
                            j.HasIndex(new[] { "PaymentIconId", "PaymentProviderId" }, "payment_icon_payment_provider_payment_icon_id_payment_provi_idx");
                        });

                //entity.HasMany(d => d.Currencies).WithMany(p => p.PaymentProviders)
                entity.HasMany<ResCurrency>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "PaymentCurrencyRel",
                        r => r.HasOne<ResCurrency>().WithMany()
                            .HasForeignKey("CurrencyId")
                            .HasConstraintName("payment_currency_rel_currency_id_fkey"),
                        l => l.HasOne<PaymentProvider>().WithMany()
                            .HasForeignKey("PaymentProviderId")
                            .HasConstraintName("payment_currency_rel_payment_provider_id_fkey"),
                        j =>
                        {
                            j.HasKey("PaymentProviderId", "CurrencyId").HasName("payment_currency_rel_pkey");
                            j.ToTable("payment_currency_rel");
                            j.HasIndex(new[] { "CurrencyId", "PaymentProviderId" }, "payment_currency_rel_currency_id_payment_provider_id_idx");
                            j.IndexerProperty<Guid>("PaymentProviderId").HasColumnName("payment_provider_id");
                            j.IndexerProperty<Guid>("CurrencyId").HasColumnName("currency_id");
                        });
            });
        }
    }
}