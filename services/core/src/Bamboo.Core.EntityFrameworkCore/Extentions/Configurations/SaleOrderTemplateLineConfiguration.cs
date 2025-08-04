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
        public static void ConfigureSaleOrderTemplateLine(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SaleOrderTemplateLine>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("sale_order_template_line_pkey");

                entity.ToTable("sale_order_template_line");

                entity.HasIndex(e => e.TenantId, "sale_order_template_line_company_id_index");

                entity.HasIndex(e => e.SaleOrderTemplateId, "sale_order_template_line_sale_order_template_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.DisplayType).HasColumnName("display_type");
                entity.Property(e => e.Name)
                    .HasColumnType("jsonb")
                    .HasColumnName("name");
                entity.Property(e => e.ProductId).HasColumnName("product_id");
                entity.Property(e => e.ProductUomId).HasColumnName("product_uom_id");
                entity.Property(e => e.ProductUomQty).HasColumnName("product_uom_qty");
                entity.Property(e => e.SaleOrderTemplateId).HasColumnName("sale_order_template_id");
                entity.Property(e => e.Sequence)
                    .HasColumnName("sequence");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResCompany>().WithMany()
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("sale_order_template_line_company_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("sale_order_template_line_create_uid_fkey");

                entity.HasOne(d => d.Product).WithMany(p => p.SaleOrderTemplateLines)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("sale_order_template_line_product_id_fkey");

                entity.HasOne(d => d.ProductUom).WithMany(p => p.SaleOrderTemplateLines)
                    .HasForeignKey(d => d.ProductUomId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("sale_order_template_line_product_uom_id_fkey");

                entity.HasOne(d => d.SaleOrderTemplate).WithMany(p => p.SaleOrderTemplateLines)
                    .HasForeignKey(d => d.SaleOrderTemplateId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("sale_order_template_line_sale_order_template_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("sale_order_template_line_write_uid_fkey");
            });
        }
    }
}