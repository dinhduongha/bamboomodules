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
        public static void ConfigurePosMakePayment(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PosMakePayment>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("pos_make_payment_pkey");

                entity.ToTable("pos_make_payment");

                entity.HasIndex(e => e.TenantId, "pos_make_payment_company_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.Amount).HasColumnName("amount");
                entity.Property(e => e.ConfigId).HasColumnName("config_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.PaymentDate)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("payment_date");
                entity.Property(e => e.PaymentMethodId).HasColumnName("payment_method_id");
                entity.Property(e => e.PaymentName).HasColumnName("payment_name");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne(d => d.Config).WithMany(p => p.PosMakePayments)
                    .HasForeignKey(d => d.ConfigId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("pos_make_payment_config_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("pos_make_payment_create_uid_fkey");

                entity.HasOne(d => d.PaymentMethod).WithMany(p => p.PosMakePayments)
                    .HasForeignKey(d => d.PaymentMethodId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("pos_make_payment_payment_method_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("pos_make_payment_write_uid_fkey");
            });
        }
    }
}