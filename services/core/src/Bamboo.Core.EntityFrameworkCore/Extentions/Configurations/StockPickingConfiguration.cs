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
        public static void ConfigureStockPicking(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StockPicking>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("stock_picking_pkey");

                entity.ToTable("stock_picking");

                entity.HasIndex(e => e.BackorderId, "stock_picking_backorder_id_index").HasFilter("(backorder_id IS NOT NULL)");

                entity.HasIndex(e => e.TenantId, "stock_picking_company_id_index");

                entity.HasIndex(e => e.Name, "stock_picking_name_index")
                    .HasMethod("gin")
                    .HasOperators(new[] { "gin_trgm_ops" });

                entity.HasIndex(e => new { e.TenantId, e.Name }, "stock_picking_name_uniq").IsUnique();

                entity.HasIndex(e => e.Origin, "stock_picking_origin_index")
                    .HasMethod("gin")
                    .HasOperators(new[] { "gin_trgm_ops" });

                entity.HasIndex(e => e.PickingTypeId, "stock_picking_picking_type_id_index");

                entity.HasIndex(e => e.SaleId, "stock_picking_sale_id_index").HasFilter("(sale_id IS NOT NULL)");

                entity.HasIndex(e => e.ScheduledDate, "stock_picking_scheduled_date_index");

                entity.HasIndex(e => e.State, "stock_picking_state_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.BackorderId).HasColumnName("backorder_id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.Date)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("date");
                entity.Property(e => e.DateDeadline)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("date_deadline");
                entity.Property(e => e.DateDone)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("date_done");
                entity.Property(e => e.GroupId).HasColumnName("group_id");
                entity.Property(e => e.HasDeadlineIssue).HasColumnName("has_deadline_issue");
                entity.Property(e => e.ImmediateTransfer).HasColumnName("immediate_transfer");
                entity.Property(e => e.IsLocked).HasColumnName("is_locked");
                entity.Property(e => e.LocationDestId).HasColumnName("location_dest_id");
                entity.Property(e => e.LocationId).HasColumnName("location_id");
                entity.Property(e => e.MessageMainAttachmentId).HasColumnName("message_main_attachment_id");
                entity.Property(e => e.MoveType).HasColumnName("move_type");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.Note).HasColumnName("note");
                entity.Property(e => e.Origin).HasColumnName("origin");
                entity.Property(e => e.OwnerId).HasColumnName("owner_id");
                entity.Property(e => e.PartnerId).HasColumnName("partner_id");
                entity.Property(e => e.PickingTypeId).HasColumnName("picking_type_id");
                entity.Property(e => e.PosOrderId).HasColumnName("pos_order_id");
                entity.Property(e => e.PosSessionId).HasColumnName("pos_session_id");
                entity.Property(e => e.Printed).HasColumnName("printed");
                entity.Property(e => e.Priority).HasColumnName("priority");
                entity.Property(e => e.SaleId).HasColumnName("sale_id");
                entity.Property(e => e.ScheduledDate)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("scheduled_date");
                entity.Property(e => e.State).HasColumnName("state");
                entity.Property(e => e.UserId).HasColumnName("user_id");
                entity.Property(e => e.WebsiteId).HasColumnName("website_id");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne(d => d.Backorder).WithMany(p => p.InverseBackorder)
                    .HasForeignKey(d => d.BackorderId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_picking_backorder_id_fkey");

                entity.HasOne<ResCompany>().WithMany()
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_picking_company_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_picking_create_uid_fkey");

                entity.HasOne(d => d.Group).WithMany(p => p.StockPickings)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_picking_group_id_fkey");

                entity.HasOne(d => d.LocationDest).WithMany(p => p.StockPickingLocationDests)
                    .HasForeignKey(d => d.LocationDestId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("stock_picking_location_dest_id_fkey");

                entity.HasOne(d => d.Location).WithMany(p => p.StockPickingLocations)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("stock_picking_location_id_fkey");

                entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.StockPickings)
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_picking_message_main_attachment_id_fkey");

                entity.HasOne(d => d.Owner).WithMany(p => p.StockPickingOwners)
                    .HasForeignKey(d => d.OwnerId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_picking_owner_id_fkey");

                entity.HasOne<ResPartner>().WithMany()
                    .HasForeignKey(d => d.PartnerId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_picking_partner_id_fkey");

                entity.HasOne(d => d.PickingType).WithMany(p => p.StockPickings)
                    .HasForeignKey(d => d.PickingTypeId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("stock_picking_picking_type_id_fkey");

                entity.HasOne(d => d.PosOrder).WithMany(p => p.StockPickings)
                    .HasForeignKey(d => d.PosOrderId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_picking_pos_order_id_fkey");

                entity.HasOne(d => d.PosSession).WithMany(p => p.StockPickings)
                    .HasForeignKey(d => d.PosSessionId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_picking_pos_session_id_fkey");

                entity.HasOne(d => d.Sale).WithMany(p => p.StockPickings)
                    .HasForeignKey(d => d.SaleId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_picking_sale_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_picking_user_id_fkey");

                entity.HasOne(d => d.Website).WithMany(p => p.StockPickings)
                    .HasForeignKey(d => d.WebsiteId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_picking_website_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_picking_write_uid_fkey");
            });
        }
    }
}