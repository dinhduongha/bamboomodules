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
        public static void ConfigureResCurrencyRate(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<ResCurrencyRate>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("res_currency_rate_pkey");

            entity.ToTable("res_currency_rate");

            entity.HasIndex(e => e.TenantId);

            entity.HasIndex(e => e.OrganizationUnitId);

            entity.HasIndex(e => e.Name, "res_currency_rate__name_index");

            entity.HasIndex(e => new { e.Name, e.CurrencyId, e.TenantId }, "res_currency_rate_unique_name_per_day").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");

            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");

            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Rate).HasColumnName("rate");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.Company).WithMany(p => p.ResCurrencyRate)
            entity.HasOne(d => d.Company).WithMany()
                .HasForeignKey(d => d.TenantId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("res_currency_rate_company_id_fkey");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.ResCurrencyRateCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("res_currency_rate_create_uid_fkey");

            // entity.HasOne(d => d.Currency).WithMany(p => p.ResCurrencyRate)
            entity.HasOne(d => d.Currency).WithMany()
                .HasForeignKey(d => d.CurrencyId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("res_currency_rate_currency_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.ResCurrencyRateWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("res_currency_rate_write_uid_fkey");
            });
        }
    }
}
