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
        public static void ConfigureRecurringPayment(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RecurringPayment>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("recurring_payment_pkey");

                entity.ToTable("recurring_payment");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.Amount).HasColumnName("amount");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.DateBegin).HasColumnName("date_begin");
                entity.Property(e => e.DateEnd).HasColumnName("date_end");
                entity.Property(e => e.Description).HasColumnName("description");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.PartnerId).HasColumnName("partner_id");
                entity.Property(e => e.PaymentType).HasColumnName("payment_type");
                entity.Property(e => e.State).HasColumnName("state");
                entity.Property(e => e.TemplateId).HasColumnName("template_id");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResCompany>().WithMany()
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("recurring_payment_company_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("recurring_payment_create_uid_fkey");

                entity.HasOne<ResPartner>().WithMany()
                    .HasForeignKey(d => d.PartnerId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("recurring_payment_partner_id_fkey");

                entity.HasOne(d => d.Template).WithMany(p => p.RecurringPayments)
                    .HasForeignKey(d => d.TemplateId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("recurring_payment_template_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("recurring_payment_write_uid_fkey");
            });
        }
    }
}