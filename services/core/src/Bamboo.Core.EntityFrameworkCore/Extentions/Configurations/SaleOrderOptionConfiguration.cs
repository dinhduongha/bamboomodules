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
        public static void ConfigureSaleOrderOption(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SaleOrderOption>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("sale_order_option_pkey");

                entity.ToTable("sale_order_option");

                entity.HasIndex(e => e.TenantId, "sale_order_option_company_id_index");

                entity.HasIndex(e => e.OrderId, "sale_order_option_order_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.Discount).HasColumnName("discount");
                entity.Property(e => e.LineId).HasColumnName("line_id");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.OrderId).HasColumnName("order_id");
                entity.Property(e => e.PriceUnit).HasColumnName("price_unit");
                entity.Property(e => e.ProductId).HasColumnName("product_id");
                entity.Property(e => e.Quantity).HasColumnName("quantity");
                entity.Property(e => e.Sequence)
                    .HasColumnName("sequence");
                entity.Property(e => e.UomId).HasColumnName("uom_id");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("sale_order_option_create_uid_fkey");

                entity.HasOne(d => d.Line).WithMany(p => p.SaleOrderOptions)
                    .HasForeignKey(d => d.LineId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("sale_order_option_line_id_fkey");

                entity.HasOne(d => d.Order).WithMany(p => p.SaleOrderOptions)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("sale_order_option_order_id_fkey");

                entity.HasOne(d => d.Product).WithMany(p => p.SaleOrderOptions)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("sale_order_option_product_id_fkey");

                entity.HasOne(d => d.Uom).WithMany(p => p.SaleOrderOptions)
                    .HasForeignKey(d => d.UomId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("sale_order_option_uom_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("sale_order_option_write_uid_fkey");
            });
        }
    }
}