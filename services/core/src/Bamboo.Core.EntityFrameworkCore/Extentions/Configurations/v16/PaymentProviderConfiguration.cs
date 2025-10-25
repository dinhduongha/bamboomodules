using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
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

                        entity.HasIndex(e => e.TenantId, "payment_provider__company_id_index");

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.AllowExpressCheckout).HasColumnName("allow_express_checkout");
                        entity.Property(e => e.AllowTokenization).HasColumnName("allow_tokenization");
                        entity.Property(e => e.AuthMsg)
                            .HasColumnType("jsonb")
                            .HasColumnName("auth_msg");
                        entity.Property(e => e.AuthorizeClientKey).HasColumnName("authorize_client_key");
                        entity.Property(e => e.AuthorizeLogin).HasColumnName("authorize_login");
                        entity.Property(e => e.AuthorizeSignatureKey).HasColumnName("authorize_signature_key");
                        entity.Property(e => e.AuthorizeTransactionKey).HasColumnName("authorize_transaction_key");
                        entity.Property(e => e.CancelMsg)
                            .HasColumnType("jsonb")
                            .HasColumnName("cancel_msg");
                        entity.Property(e => e.CaptureManually).HasColumnName("capture_manually");
                        entity.Property(e => e.Code).HasColumnName("code");
                        entity.Property(e => e.Color).HasColumnName("color");

                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.CustomMode).HasColumnName("custom_mode");
                        entity.Property(e => e.DoneMsg)
                            .HasColumnType("jsonb")
                            .HasColumnName("done_msg");
                        entity.Property(e => e.ExpressCheckoutFormViewId).HasColumnName("express_checkout_form_view_id");
                        entity.Property(e => e.InlineFormViewId).HasColumnName("inline_form_view_id");
                        entity.Property(e => e.IsPublished).HasColumnName("is_published");
                        entity.Property(e => e.MaximumAmount).HasColumnName("maximum_amount");
                        entity.Property(e => e.ModuleId).HasColumnName("module_id");
                        entity.Property(e => e.Name)
                            .HasColumnType("jsonb")
                            .HasColumnName("name");
                        entity.Property(e => e.PendingMsg)
                            .HasColumnType("jsonb")
                            .HasColumnName("pending_msg");
                        entity.Property(e => e.PreMsg)
                            .HasColumnType("jsonb")
                            .HasColumnName("pre_msg");
                        entity.Property(e => e.QrCode).HasColumnName("qr_code");
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

                        // entity.HasOne(d => d.Company).WithMany(p => p.PaymentProvider) .HasForeignKey(d => d.TenantId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("payment_provider_company_id_fkey");
                        entity.HasOne(d => d.Company).WithMany()
                            .HasForeignKey(d => d.TenantId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("payment_provider_company_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.PaymentProviderCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("payment_provider_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("payment_provider_create_uid_fkey");

                        entity.HasOne(d => d.ExpressCheckoutFormView).WithMany(p => p.PaymentProviderExpressCheckoutFormView)
                            .HasForeignKey(d => d.ExpressCheckoutFormViewId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("payment_provider_express_checkout_form_view_id_fkey");

                        entity.HasOne(d => d.InlineFormView).WithMany(p => p.PaymentProviderInlineFormView)
                            .HasForeignKey(d => d.InlineFormViewId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("payment_provider_inline_form_view_id_fkey");

                        entity.HasOne(d => d.Module).WithMany(p => p.PaymentProvider)
                            .HasForeignKey(d => d.ModuleId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("payment_provider_module_id_fkey");

                        entity.HasOne(d => d.RedirectFormView).WithMany(p => p.PaymentProviderRedirectFormView)
                            .HasForeignKey(d => d.RedirectFormViewId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("payment_provider_redirect_form_view_id_fkey");

                        entity.HasOne(d => d.TokenInlineFormView).WithMany(p => p.PaymentProviderTokenInlineFormView)
                            .HasForeignKey(d => d.TokenInlineFormViewId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("payment_provider_token_inline_form_view_id_fkey");

                        // entity.HasOne(d => d.Website).WithMany(p => p.PaymentProvider) .HasForeignKey(d => d.WebsiteId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("payment_provider_website_id_fkey");
                        entity.HasOne(d => d.Website).WithMany()
                            .HasForeignKey(d => d.WebsiteId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("payment_provider_website_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.PaymentProviderWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("payment_provider_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("payment_provider_write_uid_fkey");

                        // entity.HasMany(d => d.Country).WithMany(p => p.Payment)
                        entity.HasMany(d => d.Country).WithMany()
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
                                    j.IndexerProperty<Guid>("PaymentId").HasColumnName("payment_id");
                                    j.IndexerProperty<Guid>("CountryId").HasColumnName("country_id");
                                });

                        // entity.HasMany(d => d.Currency).WithMany(p => p.PaymentProvider)
                        entity.HasMany(d => d.Currency).WithMany()
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

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}