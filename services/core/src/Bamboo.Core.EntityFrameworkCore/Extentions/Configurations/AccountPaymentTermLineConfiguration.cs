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
        public static void ConfigureAccountPaymentTermLine(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountPaymentTermLine>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("account_payment_term_line_pkey");

                entity.ToTable("account_payment_term_line");

                entity.HasIndex(e => e.TenantId, "account_payment_term_line_company_id_index");

                entity.HasIndex(e => e.PaymentId, "account_payment_term_line_payment_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.DaysNextMonth).HasColumnName("days_next_month");
                entity.Property(e => e.DelayType).HasColumnName("delay_type");
                entity.Property(e => e.NbDays).HasColumnName("nb_days");
                entity.Property(e => e.Days).HasColumnName("days");
                entity.Property(e => e.DaysAfter).HasColumnName("days_after");
                entity.Property(e => e.DiscountDays).HasColumnName("discount_days");
                entity.Property(e => e.DiscountPercentage).HasColumnName("discount_percentage");
                entity.Property(e => e.EndMonth).HasColumnName("end_month");
                entity.Property(e => e.Months).HasColumnName("months");
                entity.Property(e => e.PaymentId).HasColumnName("payment_id");
                entity.Property(e => e.Value).HasColumnName("value");
                entity.Property(e => e.ValueAmount).HasColumnName("value_amount");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_payment_term_line_create_uid_fkey");

                entity.HasOne(d => d.Payment).WithMany(p => p.AccountPaymentTermLines)
                    .HasForeignKey(d => d.PaymentId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("account_payment_term_line_payment_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_payment_term_line_write_uid_fkey");
            });
        }
    }
}