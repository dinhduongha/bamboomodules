using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigurePosPayment(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<PosPayment>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("pos_payment_pkey");

                        entity.ToTable("pos_payment");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.AccountMoveId, "pos_payment__account_move_id_index").HasFilter("(account_move_id IS NOT NULL)");

                        entity.HasIndex(e => e.EmployeeId, "pos_payment__employee_id_index");

                        entity.HasIndex(e => e.PosOrderId, "pos_payment__pos_order_id_index");

                        entity.HasIndex(e => e.SessionId, "pos_payment__session_id_index");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.AccountMoveId).HasColumnName("account_move_id");
                        entity.Property(e => e.Amount).HasColumnName("amount");
                        entity.Property(e => e.CardBrand).HasColumnName("card_brand");
                        entity.Property(e => e.CardNo).HasColumnName("card_no");
                        entity.Property(e => e.CardType).HasColumnName("card_type");
                        entity.Property(e => e.CardholderName).HasColumnName("cardholder_name");

                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
                        entity.Property(e => e.IsChange).HasColumnName("is_change");
                        entity.Property(e => e.Name).HasColumnName("name");
                        entity.Property(e => e.OnlineAccountPaymentId).HasColumnName("online_account_payment_id");
                        entity.Property(e => e.PaymentDate)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("payment_date");
                        entity.Property(e => e.PaymentMethodAuthcode).HasColumnName("payment_method_authcode");
                        entity.Property(e => e.PaymentMethodId).HasColumnName("payment_method_id");
                        entity.Property(e => e.PaymentMethodIssuerBank).HasColumnName("payment_method_issuer_bank");
                        entity.Property(e => e.PaymentMethodPaymentMode).HasColumnName("payment_method_payment_mode");
                        entity.Property(e => e.PaymentRefNo).HasColumnName("payment_ref_no");
                        entity.Property(e => e.PaymentStatus).HasColumnName("payment_status");
                        entity.Property(e => e.PosOrderId).HasColumnName("pos_order_id");
                        entity.Property(e => e.SessionId).HasColumnName("session_id");
                        entity.Property(e => e.Ticket).HasColumnName("ticket");
                        entity.Property(e => e.TransactionId).HasColumnName("transaction_id");
                        entity.Property(e => e.Uuid).HasColumnName("uuid");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        entity.HasOne(d => d.AccountMove).WithMany(p => p.PosPayment)
                            .HasForeignKey(d => d.AccountMoveId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("pos_payment_account_move_id_fkey");

                        // entity.HasOne(d => d.Company).WithMany(p => p.PosPayment) .HasForeignKey(d => d.TenantId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("pos_payment_company_id_fkey");
                        entity.HasOne(d => d.Company).WithMany()
                            .HasForeignKey(d => d.TenantId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("pos_payment_company_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.PosPaymentCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("pos_payment_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("pos_payment_create_uid_fkey");

                        entity.HasOne(d => d.Employee).WithMany(p => p.PosPayment)
                            .HasForeignKey(d => d.EmployeeId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("pos_payment_employee_id_fkey");

                        entity.HasOne(d => d.OnlineAccountPayment).WithMany(p => p.PosPayment)
                            .HasForeignKey(d => d.OnlineAccountPaymentId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("pos_payment_online_account_payment_id_fkey");

                        entity.HasOne(d => d.PaymentMethod).WithMany(p => p.PosPayment)
                            .HasForeignKey(d => d.PaymentMethodId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("pos_payment_payment_method_id_fkey");

                        entity.HasOne(d => d.PosOrder).WithMany(p => p.PosPayment)
                            .HasForeignKey(d => d.PosOrderId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("pos_payment_pos_order_id_fkey");

                        entity.HasOne(d => d.Session).WithMany(p => p.PosPayment)
                            .HasForeignKey(d => d.SessionId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("pos_payment_session_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.PosPaymentWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("pos_payment_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("pos_payment_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}