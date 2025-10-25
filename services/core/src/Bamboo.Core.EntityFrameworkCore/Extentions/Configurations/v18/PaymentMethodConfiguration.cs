using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigurePaymentMethod(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<PaymentMethod>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("payment_method_pkey");

                        entity.ToTable("payment_method");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.Active).HasColumnName("active");
                        entity.Property(e => e.Code).HasColumnName("code");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.Name)
                            .HasColumnType("jsonb")
                            .HasColumnName("name");
                        entity.Property(e => e.PrimaryPaymentMethodId).HasColumnName("primary_payment_method_id");
                        entity.Property(e => e.Sequence).HasColumnName("sequence");
                        entity.Property(e => e.SupportExpressCheckout).HasColumnName("support_express_checkout");
                        entity.Property(e => e.SupportRefund).HasColumnName("support_refund");
                        entity.Property(e => e.SupportTokenization).HasColumnName("support_tokenization");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.PaymentMethodCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("payment_method_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("payment_method_create_uid_fkey");

                        entity.HasOne(d => d.PrimaryPaymentMethod).WithMany(p => p.InversePrimaryPaymentMethod)
                            .HasForeignKey(d => d.PrimaryPaymentMethodId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("payment_method_primary_payment_method_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.PaymentMethodWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("payment_method_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("payment_method_write_uid_fkey");

                        // entity.HasMany(d => d.PaymentProvider).WithMany(p => p.PaymentMethod)
                        entity.HasMany(d => d.PaymentProvider).WithMany(p => p.PaymentMethod)
                            .UsingEntity<Dictionary<string, object>>(
                                "PaymentMethodPaymentProviderRel",
                                r => r.HasOne<PaymentProvider>().WithMany()
                                    .HasForeignKey("PaymentProviderId")
                                    .HasConstraintName("payment_method_payment_provider_rel_payment_provider_id_fkey"),
                                l => l.HasOne<PaymentMethod>().WithMany()
                                    .HasForeignKey("PaymentMethodId")
                                    .HasConstraintName("payment_method_payment_provider_rel_payment_method_id_fkey"),
                                j =>
                                {
                                    j.HasKey("PaymentMethodId", "PaymentProviderId").HasName("payment_method_payment_provider_rel_pkey");
                                    j.ToTable("payment_method_payment_provider_rel");
                                    j.HasIndex(new[] { "PaymentProviderId", "PaymentMethodId" }, "payment_method_payment_provid_payment_provider_id_payment_m_idx");
                                    j.IndexerProperty<Guid>("PaymentMethodId").HasColumnName("payment_method_id");
                                    j.IndexerProperty<Guid>("PaymentProviderId").HasColumnName("payment_provider_id");
                                });

                        // entity.HasMany(d => d.ResCountry).WithMany(p => p.PaymentMethod)
                        entity.HasMany(d => d.ResCountry).WithMany()
                            .UsingEntity<Dictionary<string, object>>(
                                "PaymentMethodResCountryRel",
                                r => r.HasOne<ResCountry>().WithMany()
                                    .HasForeignKey("ResCountryId")
                                    .HasConstraintName("payment_method_res_country_rel_res_country_id_fkey"),
                                l => l.HasOne<PaymentMethod>().WithMany()
                                    .HasForeignKey("PaymentMethodId")
                                    .HasConstraintName("payment_method_res_country_rel_payment_method_id_fkey"),
                                j =>
                                {
                                    j.HasKey("PaymentMethodId", "ResCountryId").HasName("payment_method_res_country_rel_pkey");
                                    j.ToTable("payment_method_res_country_rel");
                                    j.HasIndex(new[] { "ResCountryId", "PaymentMethodId" }, "payment_method_res_country_re_res_country_id_payment_method_idx");
                                    j.IndexerProperty<Guid>("PaymentMethodId").HasColumnName("payment_method_id");
                                    j.IndexerProperty<Guid>("ResCountryId").HasColumnName("res_country_id");
                                });

                        // entity.HasMany(d => d.ResCurrency).WithMany(p => p.PaymentMethod)
                        entity.HasMany(d => d.ResCurrency).WithMany()
                            .UsingEntity<Dictionary<string, object>>(
                                "PaymentMethodResCurrencyRel",
                                r => r.HasOne<ResCurrency>().WithMany()
                                    .HasForeignKey("ResCurrencyId")
                                    .HasConstraintName("payment_method_res_currency_rel_res_currency_id_fkey"),
                                l => l.HasOne<PaymentMethod>().WithMany()
                                    .HasForeignKey("PaymentMethodId")
                                    .HasConstraintName("payment_method_res_currency_rel_payment_method_id_fkey"),
                                j =>
                                {
                                    j.HasKey("PaymentMethodId", "ResCurrencyId").HasName("payment_method_res_currency_rel_pkey");
                                    j.ToTable("payment_method_res_currency_rel");
                                    j.HasIndex(new[] { "ResCurrencyId", "PaymentMethodId" }, "payment_method_res_currency_r_res_currency_id_payment_metho_idx");
                                    j.IndexerProperty<Guid>("PaymentMethodId").HasColumnName("payment_method_id");
                                    j.IndexerProperty<Guid>("ResCurrencyId").HasColumnName("res_currency_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}