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
        public static void ConfigureBaseImportTestsModelsComplex(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<BaseImportTestsModelsComplex>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("base_import_tests_models_complex_pkey");

            entity.ToTable("base_import_tests_models_complex");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.C).HasColumnName("c");
            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
            entity.Property(e => e.D).HasColumnName("d");
            entity.Property(e => e.Dt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("dt");
            entity.Property(e => e.F).HasColumnName("f");
            entity.Property(e => e.M).HasColumnName("m");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.BaseImportTestsModelsComplexCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("base_import_tests_models_complex_create_uid_fkey");

            // entity.HasOne(d => d.Currency).WithMany(p => p.BaseImportTestsModelsComplex)
            entity.HasOne(d => d.Currency).WithMany()
                .HasForeignKey(d => d.CurrencyId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("base_import_tests_models_complex_currency_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.BaseImportTestsModelsComplexWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("base_import_tests_models_complex_write_uid_fkey");
            });
        }
    }
}