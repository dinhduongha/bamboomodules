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
        public static void ConfigureMrpBomLine(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<MrpBomLine>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("mrp_bom_line_pkey");

            entity.ToTable("mrp_bom_line");

            entity.HasIndex(e => e.BomId, "mrp_bom_line__bom_id_index");

            entity.HasIndex(e => e.TenantId, "mrp_bom_line__company_id_index");

            entity.HasIndex(e => e.OrganizationUnitId);

            entity.HasIndex(e => e.ProductTmplId, "mrp_bom_line__product_tmpl_id_index");

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
            entity.Property(e => e.ManualConsumption).HasColumnName("manual_consumption");
            entity.Property(e => e.OperationId).HasColumnName("operation_id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.ProductQty).HasColumnName("product_qty");
            entity.Property(e => e.ProductTmplId).HasColumnName("product_tmpl_id");
            entity.Property(e => e.ProductUomId).HasColumnName("product_uom_id");
            entity.Property(e => e.Sequence).HasColumnName("sequence");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            entity.HasOne(d => d.Bom).WithMany(p => p.MrpBomLine)
                .HasForeignKey(d => d.BomId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("mrp_bom_line_bom_id_fkey");

            // entity.HasOne(d => d.Company).WithMany(p => p.MrpBomLine)
            entity.HasOne(d => d.Company).WithMany()
                .HasForeignKey(d => d.TenantId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("mrp_bom_line_company_id_fkey");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.MrpBomLineCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("mrp_bom_line_create_uid_fkey");

            entity.HasOne(d => d.Operation).WithMany(p => p.MrpBomLine)
                .HasForeignKey(d => d.OperationId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("mrp_bom_line_operation_id_fkey");

            // entity.HasOne(d => d.Product).WithMany(p => p.MrpBomLine)
            entity.HasOne(d => d.Product).WithMany()
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("mrp_bom_line_product_id_fkey");

            entity.HasOne(d => d.ProductTmpl).WithMany(p => p.MrpBomLine)
                .HasForeignKey(d => d.ProductTmplId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("mrp_bom_line_product_tmpl_id_fkey");

            // entity.HasOne(d => d.ProductUom).WithMany(p => p.MrpBomLine)
            entity.HasOne(d => d.ProductUom).WithMany()
                .HasForeignKey(d => d.ProductUomId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("mrp_bom_line_product_uom_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.MrpBomLineWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("mrp_bom_line_write_uid_fkey");

            // entity.HasMany(d => d.ProductTemplateAttributeValue).WithMany(p => p.MrpBomLine)
            entity.HasMany(d => d.ProductTemplateAttributeValue).WithMany(p => p.MrpBomLine)
                .UsingEntity<Dictionary<string, object>>(
                    "MrpBomLineProductTemplateAttributeValueRel",
                    r => r.HasOne<ProductTemplateAttributeValue>().WithMany()
                        .HasForeignKey("ProductTemplateAttributeValueId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("mrp_bom_line_product_template_product_template_attribute_v_fkey"),
                    l => l.HasOne<MrpBomLine>().WithMany()
                        .HasForeignKey("MrpBomLineId")
                        .HasConstraintName("mrp_bom_line_product_template_attribute_va_mrp_bom_line_id_fkey"),
                    j =>
                    {
                        j.HasKey("MrpBomLineId", "ProductTemplateAttributeValueId").HasName("mrp_bom_line_product_template_attribute_value_rel_pkey");
                        j.ToTable("mrp_bom_line_product_template_attribute_value_rel");
                        j.HasIndex(new[] { "ProductTemplateAttributeValueId", "MrpBomLineId" }, "mrp_bom_line_product_template_product_template_attribute_va_idx");
                        j.IndexerProperty<Guid>("MrpBomLineId").HasColumnName("mrp_bom_line_id");
                        j.IndexerProperty<Guid>("ProductTemplateAttributeValueId").HasColumnName("product_template_attribute_value_id");
                    });
            });
        }
    }
}
