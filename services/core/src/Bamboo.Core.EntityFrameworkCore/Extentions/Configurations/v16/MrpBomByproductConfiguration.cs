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
        public static void ConfigureMrpBomByproduct(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<MrpBomByproduct>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("mrp_bom_byproduct_pkey");

            entity.ToTable("mrp_bom_byproduct");

            entity.HasIndex(e => e.BomId, "mrp_bom_byproduct__bom_id_index");

            entity.HasIndex(e => e.TenantId, "mrp_bom_byproduct__company_id_index");

            entity.HasIndex(e => e.OrganizationUnitId);

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");

            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
            entity.Property(e => e.BomId).HasColumnName("bom_id");

            entity.Property(e => e.CostShare).HasColumnName("cost_share");
            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.OperationId).HasColumnName("operation_id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.ProductQty).HasColumnName("product_qty");
            entity.Property(e => e.ProductUomId).HasColumnName("product_uom_id");
            entity.Property(e => e.Sequence).HasColumnName("sequence");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            entity.HasOne(d => d.Bom).WithMany(p => p.MrpBomByproduct)
                .HasForeignKey(d => d.BomId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("mrp_bom_byproduct_bom_id_fkey");

            // entity.HasOne(d => d.Company).WithMany(p => p.MrpBomByproduct)
            entity.HasOne(d => d.Company).WithMany()
                .HasForeignKey(d => d.TenantId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("mrp_bom_byproduct_company_id_fkey");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.MrpBomByproductCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("mrp_bom_byproduct_create_uid_fkey");

            entity.HasOne(d => d.Operation).WithMany(p => p.MrpBomByproduct)
                .HasForeignKey(d => d.OperationId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("mrp_bom_byproduct_operation_id_fkey");

            // entity.HasOne(d => d.Product).WithMany(p => p.MrpBomByproduct)
            entity.HasOne(d => d.Product).WithMany()
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("mrp_bom_byproduct_product_id_fkey");

            // entity.HasOne(d => d.ProductUom).WithMany(p => p.MrpBomByproduct)
            entity.HasOne(d => d.ProductUom).WithMany()
                .HasForeignKey(d => d.ProductUomId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("mrp_bom_byproduct_product_uom_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.MrpBomByproductWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("mrp_bom_byproduct_write_uid_fkey");

            // entity.HasMany(d => d.ProductTemplateAttributeValue).WithMany(p => p.MrpBomByproduct)
            entity.HasMany(d => d.ProductTemplateAttributeValue).WithMany(p => p.MrpBomByproduct)
                .UsingEntity<Dictionary<string, object>>(
                    "MrpBomByproductProductTemplateAttributeValueRel",
                    r => r.HasOne<ProductTemplateAttributeValue>().WithMany()
                        .HasForeignKey("ProductTemplateAttributeValueId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("mrp_bom_byproduct_product_tem_product_template_attribute_v_fkey"),
                    l => l.HasOne<MrpBomByproduct>().WithMany()
                        .HasForeignKey("MrpBomByproductId")
                        .HasConstraintName("mrp_bom_byproduct_product_template_at_mrp_bom_byproduct_id_fkey"),
                    j =>
                    {
                        j.HasKey("MrpBomByproductId", "ProductTemplateAttributeValueId").HasName("mrp_bom_byproduct_product_template_attribute_value_rel_pkey");
                        j.ToTable("mrp_bom_byproduct_product_template_attribute_value_rel");
                        j.HasIndex(new[] { "ProductTemplateAttributeValueId", "MrpBomByproductId" }, "mrp_bom_byproduct_product_tem_product_template_attribute_va_idx");
                        j.IndexerProperty<Guid>("MrpBomByproductId").HasColumnName("mrp_bom_byproduct_id");
                        j.IndexerProperty<Guid>("ProductTemplateAttributeValueId").HasColumnName("product_template_attribute_value_id");
                    });
            });
        }
    }
}
