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
        public static void ConfigureBarcodeRule(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BarcodeRule>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("barcode_rule_pkey");

                entity.ToTable("barcode_rule");

                entity.HasIndex(e => e.TenantId, "misc_barcode_rule_company_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.Alias).HasColumnName("alias");
                entity.Property(e => e.AssociatedUomId).HasColumnName("associated_uom_id");
                entity.Property(e => e.BarcodeNomenclatureId).HasColumnName("barcode_nomenclature_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.Encoding).HasColumnName("encoding");
                entity.Property(e => e.Gs1ContentType).HasColumnName("gs1_content_type");
                entity.Property(e => e.Gs1DecimalUsage).HasColumnName("gs1_decimal_usage");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.Pattern).HasColumnName("pattern");
                entity.Property(e => e.Sequence)
                    .HasColumnName("sequence");
                entity.Property(e => e.Type).HasColumnName("type");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne(d => d.AssociatedUom).WithMany(p => p.BarcodeRules)
                    .HasForeignKey(d => d.AssociatedUomId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("barcode_rule_associated_uom_id_fkey");

                entity.HasOne(d => d.BarcodeNomenclature).WithMany(p => p.BarcodeRules)
                    .HasForeignKey(d => d.BarcodeNomenclatureId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("barcode_rule_barcode_nomenclature_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("barcode_rule_create_uid_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("barcode_rule_write_uid_fkey");
            });
        }
    }
}