using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigurePaymentTransaction(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<PaymentTransaction>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("payment_transaction_pkey");

                        entity.ToTable("payment_transaction");

                        entity.HasIndex(e => e.TenantId, "payment_transaction__company_id_index");

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.Operation, "payment_transaction__operation_index");

                        entity.HasIndex(e => e.State, "payment_transaction__state_index");

                        entity.HasIndex(e => e.Reference, "payment_transaction_reference_uniq").IsUnique();

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.Amount).HasColumnName("amount");

                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
                        entity.Property(e => e.IsDonation).HasColumnName("is_donation");
                        entity.Property(e => e.IsPostProcessed).HasColumnName("is_post_processed");
                        entity.Property(e => e.LandingRoute).HasColumnName("landing_route");
                        entity.Property(e => e.LastStateChange)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("last_state_change");
                        entity.Property(e => e.Operation).HasColumnName("operation");
                        entity.Property(e => e.PartnerAddress).HasColumnName("partner_address");
                        entity.Property(e => e.PartnerCity).HasColumnName("partner_city");
                        entity.Property(e => e.PartnerCountryId).HasColumnName("partner_country_id");
                        entity.Property(e => e.PartnerEmail).HasColumnName("partner_email");
                        entity.Property(e => e.PartnerId).HasColumnName("partner_id");
                        entity.Property(e => e.PartnerLang).HasColumnName("partner_lang");
                        entity.Property(e => e.PartnerName).HasColumnName("partner_name");
                        entity.Property(e => e.PartnerPhone).HasColumnName("partner_phone");
                        entity.Property(e => e.PartnerStateId).HasColumnName("partner_state_id");
                        entity.Property(e => e.PartnerZip).HasColumnName("partner_zip");
                        entity.Property(e => e.PaymentId).HasColumnName("payment_id");
                        entity.Property(e => e.PaymentMethodId).HasColumnName("payment_method_id");
                        entity.Property(e => e.PosOrderId).HasColumnName("pos_order_id");
                        entity.Property(e => e.ProviderId).HasColumnName("provider_id");
                        entity.Property(e => e.ProviderReference).HasColumnName("provider_reference");
                        entity.Property(e => e.Reference).HasColumnName("reference");
                        entity.Property(e => e.SourceTransactionId).HasColumnName("source_transaction_id");
                        entity.Property(e => e.State).HasColumnName("state");
                        entity.Property(e => e.StateMessage).HasColumnName("state_message");
                        entity.Property(e => e.TokenId).HasColumnName("token_id");
                        entity.Property(e => e.Tokenize).HasColumnName("tokenize");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.Company).WithMany(p => p.PaymentTransaction) .HasForeignKey(d => d.TenantId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("payment_transaction_company_id_fkey");
                        entity.HasOne(d => d.Company).WithMany()
                            .HasForeignKey(d => d.TenantId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("payment_transaction_company_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.PaymentTransactionCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("payment_transaction_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("payment_transaction_create_uid_fkey");

                        // entity.HasOne(d => d.Currency).WithMany(p => p.PaymentTransaction) .HasForeignKey(d => d.CurrencyId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("payment_transaction_currency_id_fkey");
                        entity.HasOne(d => d.Currency).WithMany()
                            .HasForeignKey(d => d.CurrencyId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("payment_transaction_currency_id_fkey");

                        // entity.HasOne(d => d.PartnerCountry).WithMany(p => p.PaymentTransaction) .HasForeignKey(d => d.PartnerCountryId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("payment_transaction_partner_country_id_fkey");
                        entity.HasOne(d => d.PartnerCountry).WithMany()
                            .HasForeignKey(d => d.PartnerCountryId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("payment_transaction_partner_country_id_fkey");

                        // entity.HasOne(d => d.Partner).WithMany(p => p.PaymentTransaction) .HasForeignKey(d => d.PartnerId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("payment_transaction_partner_id_fkey");
                        entity.HasOne(d => d.Partner).WithMany()
                            .HasForeignKey(d => d.PartnerId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("payment_transaction_partner_id_fkey");

                        // entity.HasOne(d => d.PartnerState).WithMany(p => p.PaymentTransaction) .HasForeignKey(d => d.PartnerStateId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("payment_transaction_partner_state_id_fkey");
                        entity.HasOne(d => d.PartnerState).WithMany()
                            .HasForeignKey(d => d.PartnerStateId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("payment_transaction_partner_state_id_fkey");

                        entity.HasOne(d => d.Payment).WithMany(p => p.PaymentTransactionNavigation)
                            .HasForeignKey(d => d.PaymentId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("payment_transaction_payment_id_fkey");

                        entity.HasOne(d => d.PaymentMethod).WithMany(p => p.PaymentTransaction)
                            .HasForeignKey(d => d.PaymentMethodId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("payment_transaction_payment_method_id_fkey");

                        entity.HasOne(d => d.PosOrder).WithMany(p => p.PaymentTransaction)
                            .HasForeignKey(d => d.PosOrderId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("payment_transaction_pos_order_id_fkey");

                        entity.HasOne(d => d.Provider).WithMany(p => p.PaymentTransaction)
                            .HasForeignKey(d => d.ProviderId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("payment_transaction_provider_id_fkey");

                        entity.HasOne(d => d.SourceTransaction).WithMany(p => p.InverseSourceTransaction)
                            .HasForeignKey(d => d.SourceTransactionId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("payment_transaction_source_transaction_id_fkey");

                        entity.HasOne(d => d.Token).WithMany(p => p.PaymentTransaction)
                            .HasForeignKey(d => d.TokenId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("payment_transaction_token_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.PaymentTransactionWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("payment_transaction_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("payment_transaction_write_uid_fkey");

                        // entity.HasMany(d => d.SaleOrder).WithMany(p => p.Transaction)
                        entity.HasMany(d => d.SaleOrder).WithMany(p => p.Transaction)
                            .UsingEntity<Dictionary<string, object>>(
                                "SaleOrderTransactionRel",
                                r => r.HasOne<SaleOrder>().WithMany()
                                    .HasForeignKey("SaleOrderId")
                                    .HasConstraintName("sale_order_transaction_rel_sale_order_id_fkey"),
                                l => l.HasOne<PaymentTransaction>().WithMany()
                                    .HasForeignKey("TransactionId")
                                    .HasConstraintName("sale_order_transaction_rel_transaction_id_fkey"),
                                j =>
                                {
                                    j.HasKey("TransactionId", "SaleOrderId").HasName("sale_order_transaction_rel_pkey");
                                    j.ToTable("sale_order_transaction_rel");
                                    j.HasIndex(new[] { "SaleOrderId", "TransactionId" }, "sale_order_transaction_rel_sale_order_id_transaction_id_idx");
                                    j.IndexerProperty<Guid>("TransactionId").HasColumnName("transaction_id");
                                    j.IndexerProperty<Guid>("SaleOrderId").HasColumnName("sale_order_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}