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
        public static void ConfigureResCurrency(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<ResCurrency>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("res_currency_pkey");

            entity.ToTable("res_currency");

            entity.HasIndex(e => e.Name, "res_currency_unique_name").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.CurrencySubunitLabel)
                .HasColumnType("jsonb")
                .HasColumnName("currency_subunit_label");
            //entity.Property(e => e.CurrencySubunitLabel).HasColumnName("currency_subunit_label");
            entity.Property(e => e.CurrencyUnitLabel)
                .HasColumnType("jsonb")
                .HasColumnName("currency_unit_label");
            //entity.Property(e => e.CurrencyUnitLabel).HasColumnName("currency_unit_label");
            entity.Property(e => e.DecimalPlaces).HasColumnName("decimal_places");
            entity.Property(e => e.FullName).HasColumnName("full_name");
            entity.Property(e => e.IsoNumeric).HasColumnName("iso_numeric");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Position).HasColumnName("position");
            entity.Property(e => e.Rounding).HasColumnName("rounding");
            entity.Property(e => e.Symbol).HasColumnName("symbol");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.ResCurrencyCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("res_currency_create_uid_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.ResCurrencyWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("res_currency_write_uid_fkey");
            });
        }
    }
}
