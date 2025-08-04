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
        public static void ConfigureMrpBom(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MrpBom>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("mrp_bom_pkey");

                entity.ToTable("mrp_bom");

                entity.HasIndex(e => e.TenantId, "mrp_bom_company_id_index");

                entity.HasIndex(e => e.ProductId, "mrp_bom_product_id_index");

                entity.HasIndex(e => e.ProductTmplId, "mrp_bom_product_tmpl_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.Active).HasColumnName("active");
                entity.Property(e => e.AllowOperationDependencies).HasColumnName("allow_operation_dependencies");
                entity.Property(e => e.Code).HasColumnName("code");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.Consumption).HasColumnName("consumption");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.MessageMainAttachmentId).HasColumnName("message_main_attachment_id");
                entity.Property(e => e.PickingTypeId).HasColumnName("picking_type_id");
                entity.Property(e => e.ProductId).HasColumnName("product_id");
                entity.Property(e => e.ProductQty).HasColumnName("product_qty");
                entity.Property(e => e.ProductTmplId).HasColumnName("product_tmpl_id");
                entity.Property(e => e.ProductUomId).HasColumnName("product_uom_id");
                entity.Property(e => e.ReadyToProduce).HasColumnName("ready_to_produce");
                entity.Property(e => e.Sequence)
                    .HasColumnName("sequence");
                entity.Property(e => e.Type).HasColumnName("type");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResCompany>().WithMany()
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mrp_bom_company_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mrp_bom_create_uid_fkey");

                entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.MrpBoms)
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mrp_bom_message_main_attachment_id_fkey");

                entity.HasOne(d => d.PickingType).WithMany(p => p.MrpBoms)
                    .HasForeignKey(d => d.PickingTypeId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mrp_bom_picking_type_id_fkey");

                entity.HasOne(d => d.Product).WithMany(p => p.MrpBoms)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mrp_bom_product_id_fkey");

                entity.HasOne(d => d.ProductTmpl).WithMany(p => p.MrpBoms)
                    .HasForeignKey(d => d.ProductTmplId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("mrp_bom_product_tmpl_id_fkey");

                entity.HasOne(d => d.ProductUom).WithMany(p => p.MrpBoms)
                    .HasForeignKey(d => d.ProductUomId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("mrp_bom_product_uom_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mrp_bom_write_uid_fkey");
            });
        }
    }
}