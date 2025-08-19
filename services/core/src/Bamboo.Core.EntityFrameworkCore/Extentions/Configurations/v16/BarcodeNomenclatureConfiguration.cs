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
        public static void ConfigureBarcodeNomenclature(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<BarcodeNomenclature>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("barcode_nomenclature_pkey");

            entity.ToTable("barcode_nomenclature");

            entity.HasIndex(e => e.TenantId);

            entity.HasIndex(e => e.OrganizationUnitId);

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
            entity.Property(e => e.Gs1SeparatorFnc1).HasColumnName("gs1_separator_fnc1");
            entity.Property(e => e.IsGs1Nomenclature).HasColumnName("is_gs1_nomenclature");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.UpcEanConv).HasColumnName("upc_ean_conv");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.BarcodeNomenclatureCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("barcode_nomenclature_create_uid_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.BarcodeNomenclatureWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("barcode_nomenclature_write_uid_fkey");
            });
        }
    }
}