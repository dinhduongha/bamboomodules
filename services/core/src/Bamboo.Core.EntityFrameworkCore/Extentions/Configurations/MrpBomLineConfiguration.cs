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
        public static void ConfigureMrpBomLine(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MrpBomLine>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("mrp_bom_line_pkey");

                entity.ToTable("mrp_bom_line");

                entity.HasIndex(e => e.BomId, "mrp_bom_line_bom_id_index");

                entity.HasIndex(e => e.TenantId, "mrp_bom_line_company_id_index");

                entity.HasIndex(e => e.ProductTmplId, "mrp_bom_line_product_tmpl_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.BomId).HasColumnName("bom_id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CostShare).HasColumnName("cost_share");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.ManualConsumption).HasColumnName("manual_consumption");
                entity.Property(e => e.OperationId).HasColumnName("operation_id");
                entity.Property(e => e.ProductId).HasColumnName("product_id");
                entity.Property(e => e.ProductQty).HasColumnName("product_qty");
                entity.Property(e => e.ProductTmplId).HasColumnName("product_tmpl_id");
                entity.Property(e => e.ProductUomId).HasColumnName("product_uom_id");
                entity.Property(e => e.Sequence)
                    .HasColumnName("sequence");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne(d => d.Bom).WithMany(p => p.MrpBomLines)
                    .HasForeignKey(d => d.BomId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("mrp_bom_line_bom_id_fkey");

                entity.HasOne<ResCompany>().WithMany()
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mrp_bom_line_company_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mrp_bom_line_create_uid_fkey");

                entity.HasOne(d => d.Operation).WithMany(p => p.MrpBomLines)
                    .HasForeignKey(d => d.OperationId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mrp_bom_line_operation_id_fkey");

                entity.HasOne(d => d.Product).WithMany(p => p.MrpBomLines)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("mrp_bom_line_product_id_fkey");

                entity.HasOne(d => d.ProductTmpl).WithMany(p => p.MrpBomLines)
                    .HasForeignKey(d => d.ProductTmplId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mrp_bom_line_product_tmpl_id_fkey");

                entity.HasOne(d => d.ProductUom).WithMany(p => p.MrpBomLines)
                    .HasForeignKey(d => d.ProductUomId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("mrp_bom_line_product_uom_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mrp_bom_line_write_uid_fkey");

                //entity.HasMany(d => d.ProductTemplateAttributeValues).WithMany(p => p.MrpBomLines)
                entity.HasMany<ProductTemplateAttributeValue>().WithMany()
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
                        });
            });
        }
    }
}