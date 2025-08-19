using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Bamboo.Core.Models;
// Cần thêm using đến namespace chứa entity của bạn ở đây
// Ví dụ: using YourProject.Entities;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureAccountPaymentTerm(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<AccountPaymentTerm>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("account_payment_term_pkey");

            entity.ToTable("account_payment_term");

            entity.HasIndex(e => e.TenantId);

            entity.HasIndex(e => e.OrganizationUnitId);

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");

            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
            entity.Property(e => e.Active).HasColumnName("active");

            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.DiscountDays).HasColumnName("discount_days");
            entity.Property(e => e.DiscountPercentage).HasColumnName("discount_percentage");
            entity.Property(e => e.DisplayOnInvoice).HasColumnName("display_on_invoice");
            entity.Property(e => e.EarlyDiscount).HasColumnName("early_discount");
            entity.Property(e => e.EarlyPayDiscountComputation).HasColumnName("early_pay_discount_computation");
            entity.Property(e => e.Name)
                .HasColumnType("jsonb")
                .HasColumnName("name");
            entity.Property(e => e.Note)
                .HasColumnType("jsonb")
                .HasColumnName("note");
            entity.Property(e => e.Sequence).HasColumnName("sequence");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.Company).WithMany(p => p.AccountPaymentTerm)
            entity.HasOne(d => d.Company).WithMany()
                .HasForeignKey(d => d.TenantId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("account_payment_term_company_id_fkey");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.AccountPaymentTermCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("account_payment_term_create_uid_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.AccountPaymentTermWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("account_payment_term_write_uid_fkey");
            });
        }
    }
}
