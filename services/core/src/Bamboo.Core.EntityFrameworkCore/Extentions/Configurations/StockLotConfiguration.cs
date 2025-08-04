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
        public static void ConfigureStockLot(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StockLot>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("stock_lot_pkey");

                entity.ToTable("stock_lot");

                entity.HasIndex(e => e.TenantId, "stock_lot_company_id_index");

                entity.HasIndex(e => e.Name, "stock_lot_name_index")
                    .HasMethod("gin")
                    .HasOperators(new[] { "gin_trgm_ops" });

                entity.HasIndex(e => e.ProductId, "stock_lot_product_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.MessageMainAttachmentId).HasColumnName("message_main_attachment_id");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.Note).HasColumnName("note");
                entity.Property(e => e.ProductId).HasColumnName("product_id");
                entity.Property(e => e.ProductUomId).HasColumnName("product_uom_id");
                entity.Property(e => e.Ref).HasColumnName("ref");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResCompany>().WithMany()
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("stock_lot_company_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_lot_create_uid_fkey");

                entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.StockLots)
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_lot_message_main_attachment_id_fkey");

                entity.HasOne(d => d.Product).WithMany(p => p.StockLots)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("stock_lot_product_id_fkey");

                entity.HasOne(d => d.ProductUom).WithMany(p => p.StockLots)
                    .HasForeignKey(d => d.ProductUomId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_lot_product_uom_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_lot_write_uid_fkey");
            });
        }
    }
}