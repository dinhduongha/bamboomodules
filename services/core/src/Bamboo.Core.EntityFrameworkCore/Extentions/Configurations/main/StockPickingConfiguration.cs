using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
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

                        entity.HasIndex(e => e.BackorderId, "stock_picking__backorder_id_index").HasFilter("(backorder_id IS NOT NULL)");

                        entity.HasIndex(e => e.BatchId, "stock_picking__batch_id_index");

                        entity.HasIndex(e => e.TenantId, "stock_picking__company_id_index");

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.Name, "stock_picking__name_index")
                            .HasMethod("gin")
                            .HasOperators(new[] { "gin_trgm_ops" });

                        entity.HasIndex(e => e.Origin, "stock_picking__origin_index")
                            .HasMethod("gin")
                            .HasOperators(new[] { "gin_trgm_ops" });

                        entity.HasIndex(e => e.OwnerId, "stock_picking__owner_id_index").HasFilter("(owner_id IS NOT NULL)");

                        entity.HasIndex(e => e.PartnerId, "stock_picking__partner_id_index").HasFilter("(partner_id IS NOT NULL)");

                        entity.HasIndex(e => e.PickingTypeId, "stock_picking__picking_type_id_index");

                        entity.HasIndex(e => e.PosOrderId, "stock_picking__pos_order_id_index");

                        entity.HasIndex(e => e.PosSessionId, "stock_picking__pos_session_id_index");

                        entity.HasIndex(e => e.ReturnId, "stock_picking__return_id_index").HasFilter("(return_id IS NOT NULL)");

                        entity.HasIndex(e => e.SaleId, "stock_picking__sale_id_index").HasFilter("(sale_id IS NOT NULL)");

                        entity.HasIndex(e => e.ScheduledDate, "stock_picking__scheduled_date_index");

                        entity.HasIndex(e => e.State, "stock_picking__state_index");

                        entity.HasIndex(e => new { e.Name, e.TenantId }, "stock_picking_name_uniq").IsUnique();

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.BackorderId).HasColumnName("backorder_id");
                        entity.Property(e => e.BatchId).HasColumnName("batch_id");
                        entity.Property(e => e.BatchSequence).HasColumnName("batch_sequence");
                        entity.Property(e => e.CarrierId).HasColumnName("carrier_id");
                        entity.Property(e => e.CarrierPrice).HasColumnName("carrier_price");
                        entity.Property(e => e.CarrierTrackingRef).HasColumnName("carrier_tracking_ref");

                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
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
                        entity.Property(e => e.IsLocked).HasColumnName("is_locked");
                        entity.Property(e => e.LocationDestId).HasColumnName("location_dest_id");
                        entity.Property(e => e.LocationId).HasColumnName("location_id");
                        entity.Property(e => e.MoveType).HasColumnName("move_type");
                        entity.Property(e => e.Name).HasColumnName("name");
                        entity.Property(e => e.Note).HasColumnName("note");
                        entity.Property(e => e.Origin).HasColumnName("origin");
                        entity.Property(e => e.OwnerId).HasColumnName("owner_id");
                        entity.Property(e => e.PartnerId).HasColumnName("partner_id");
                        entity.Property(e => e.PickingProperties)
                            .HasColumnType("jsonb")
                            .HasColumnName("picking_properties");
                        entity.Property(e => e.PickingTypeId).HasColumnName("picking_type_id");
                        entity.Property(e => e.PosOrderId).HasColumnName("pos_order_id");
                        entity.Property(e => e.PosSessionId).HasColumnName("pos_session_id");
                        entity.Property(e => e.Printed).HasColumnName("printed");
                        entity.Property(e => e.Priority).HasColumnName("priority");
                        entity.Property(e => e.ProjectId).HasColumnName("project_id");
                        entity.Property(e => e.ReturnId).HasColumnName("return_id");
                        entity.Property(e => e.SaleId).HasColumnName("sale_id");
                        entity.Property(e => e.ScheduledDate)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("scheduled_date");
                        entity.Property(e => e.State).HasColumnName("state");
                        entity.Property(e => e.UserId).HasColumnName("user_id");
                        entity.Property(e => e.WebsiteId).HasColumnName("website_id");
                        entity.Property(e => e.Weight).HasColumnName("weight");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        entity.HasOne(d => d.Backorder).WithMany(p => p.InverseBackorder)
                            .HasForeignKey(d => d.BackorderId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_picking_backorder_id_fkey");

                        entity.HasOne(d => d.Batch).WithMany(p => p.StockPicking)
                            .HasForeignKey(d => d.BatchId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_picking_batch_id_fkey");

                        entity.HasOne(d => d.Carrier).WithMany(p => p.StockPicking)
                            .HasForeignKey(d => d.CarrierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_picking_carrier_id_fkey");

                        // entity.HasOne(d => d.Company).WithMany(p => p.StockPicking) .HasForeignKey(d => d.TenantId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("stock_picking_company_id_fkey");
                        entity.HasOne(d => d.Company).WithMany()
                            .HasForeignKey(d => d.TenantId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_picking_company_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.StockPickingCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("stock_picking_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_picking_create_uid_fkey");

                        entity.HasOne(d => d.Group).WithMany(p => p.StockPicking)
                            .HasForeignKey(d => d.GroupId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_picking_group_id_fkey");

                        entity.HasOne(d => d.LocationDest).WithMany(p => p.StockPickingLocationDest)
                            .HasForeignKey(d => d.LocationDestId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("stock_picking_location_dest_id_fkey");

                        entity.HasOne(d => d.Location).WithMany(p => p.StockPickingLocation)
                            .HasForeignKey(d => d.LocationId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("stock_picking_location_id_fkey");

                        // entity.HasOne(d => d.Owner).WithMany(p => p.StockPickingOwner) .HasForeignKey(d => d.OwnerId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("stock_picking_owner_id_fkey");
                        entity.HasOne(d => d.Owner).WithMany()
                            .HasForeignKey(d => d.OwnerId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_picking_owner_id_fkey");

                        // entity.HasOne(d => d.Partner).WithMany(p => p.StockPickingPartner) .HasForeignKey(d => d.PartnerId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("stock_picking_partner_id_fkey");
                        entity.HasOne(d => d.Partner).WithMany()
                            .HasForeignKey(d => d.PartnerId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_picking_partner_id_fkey");

                        entity.HasOne(d => d.PickingType).WithMany(p => p.StockPicking)
                            .HasForeignKey(d => d.PickingTypeId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("stock_picking_picking_type_id_fkey");

                        entity.HasOne(d => d.PosOrder).WithMany(p => p.StockPicking)
                            .HasForeignKey(d => d.PosOrderId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_picking_pos_order_id_fkey");

                        entity.HasOne(d => d.PosSession).WithMany(p => p.StockPicking)
                            .HasForeignKey(d => d.PosSessionId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_picking_pos_session_id_fkey");

                        entity.HasOne(d => d.Project).WithMany(p => p.StockPicking)
                            .HasForeignKey(d => d.ProjectId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_picking_project_id_fkey");

                        entity.HasOne(d => d.Return).WithMany(p => p.InverseReturn)
                            .HasForeignKey(d => d.ReturnId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_picking_return_id_fkey");

                        entity.HasOne(d => d.Sale).WithMany(p => p.StockPicking)
                            .HasForeignKey(d => d.SaleId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_picking_sale_id_fkey");

                        // entity.HasOne(d => d.User).WithMany(p => p.StockPickingUser) .HasForeignKey(d => d.UserId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("stock_picking_user_id_fkey");
                        entity.HasOne(d => d.User).WithMany()
                            .HasForeignKey(d => d.UserId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_picking_user_id_fkey");

                        // entity.HasOne(d => d.Website).WithMany(p => p.StockPicking) .HasForeignKey(d => d.WebsiteId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("stock_picking_website_id_fkey");
                        entity.HasOne(d => d.Website).WithMany()
                            .HasForeignKey(d => d.WebsiteId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_picking_website_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.StockPickingWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("stock_picking_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_picking_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}