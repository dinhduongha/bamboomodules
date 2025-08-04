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
        public static void ConfigurePosPayment(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PosPayment>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("pos_payment_pkey");

                entity.ToTable("pos_payment");

                entity.HasIndex(e => e.SessionId, "pos_payment_session_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.AccountMoveId).HasColumnName("account_move_id");
                entity.Property(e => e.Amount).HasColumnName("amount");
                entity.Property(e => e.CardType).HasColumnName("card_type");
                entity.Property(e => e.CardholderName).HasColumnName("cardholder_name");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.IsChange).HasColumnName("is_change");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.PaymentDate)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("payment_date");
                entity.Property(e => e.PaymentMethodId).HasColumnName("payment_method_id");
                entity.Property(e => e.PaymentStatus).HasColumnName("payment_status");
                entity.Property(e => e.PosOrderId).HasColumnName("pos_order_id");
                entity.Property(e => e.SessionId).HasColumnName("session_id");
                entity.Property(e => e.Ticket).HasColumnName("ticket");
                entity.Property(e => e.TransactionId).HasColumnName("transaction_id");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne(d => d.AccountMove).WithMany(p => p.PosPayments)
                    .HasForeignKey(d => d.AccountMoveId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("pos_payment_account_move_id_fkey");

                entity.HasOne<ResCompany>().WithMany()
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("pos_payment_company_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("pos_payment_create_uid_fkey");

                entity.HasOne(d => d.PaymentMethod).WithMany(p => p.PosPayments)
                    .HasForeignKey(d => d.PaymentMethodId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("pos_payment_payment_method_id_fkey");

                entity.HasOne(d => d.PosOrder).WithMany(p => p.PosPayments)
                    .HasForeignKey(d => d.PosOrderId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("pos_payment_pos_order_id_fkey");

                entity.HasOne(d => d.Session).WithMany(p => p.PosPayments)
                    .HasForeignKey(d => d.SessionId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("pos_payment_session_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("pos_payment_write_uid_fkey");
            });
        }
    }
}