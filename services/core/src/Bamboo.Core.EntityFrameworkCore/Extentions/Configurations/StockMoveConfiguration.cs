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
        public static void ConfigureStockMove(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StockMove>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("stock_move_pkey");

                entity.ToTable("stock_move");

                entity.HasIndex(e => e.TenantId, "stock_move_company_id_index");

                entity.HasIndex(e => e.CreatedPurchaseLineId, "stock_move_created_purchase_line_id_index").HasFilter("(created_purchase_line_id IS NOT NULL)");

                entity.HasIndex(e => e.Date, "stock_move_date_index");

                entity.HasIndex(e => e.LocationDestId, "stock_move_location_dest_id_index");

                entity.HasIndex(e => e.LocationId, "stock_move_location_id_index");

                entity.HasIndex(e => e.OrderpointId, "stock_move_orderpoint_id_index");

                entity.HasIndex(e => e.OriginReturnedMoveId, "stock_move_origin_returned_move_id_index");

                entity.HasIndex(e => e.PickingId, "stock_move_picking_id_index");

                entity.HasIndex(e => e.ProductId, "stock_move_product_id_index");

                entity.HasIndex(e => new { e.ProductId, e.LocationId, e.LocationDestId, e.TenantId, e.State }, "stock_move_product_location_index");

                entity.HasIndex(e => e.ProductionId, "stock_move_production_id_index").HasFilter("(production_id IS NOT NULL)");

                entity.HasIndex(e => e.PurchaseLineId, "stock_move_purchase_line_id_index").HasFilter("(purchase_line_id IS NOT NULL)");

                entity.HasIndex(e => e.RawMaterialProductionId, "stock_move_raw_material_production_id_index").HasFilter("(raw_material_production_id IS NOT NULL)");

                entity.HasIndex(e => e.SaleLineId, "stock_move_sale_line_id_index").HasFilter("(sale_line_id IS NOT NULL)");

                entity.HasIndex(e => e.State, "stock_move_state_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.Additional).HasColumnName("additional");
                entity.Property(e => e.AnalyticAccountLineId).HasColumnName("analytic_account_line_id");
                entity.Property(e => e.BomLineId).HasColumnName("bom_line_id");
                entity.Property(e => e.ByproductId).HasColumnName("byproduct_id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.ConsumeUnbuildId).HasColumnName("consume_unbuild_id");
                entity.Property(e => e.CostShare).HasColumnName("cost_share");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.CreatedProductionId).HasColumnName("created_production_id");
                entity.Property(e => e.CreatedPurchaseLineId).HasColumnName("created_purchase_line_id");
                entity.Property(e => e.Date)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("date");
                entity.Property(e => e.DateDeadline)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("date_deadline");
                entity.Property(e => e.DelayAlertDate)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("delay_alert_date");
                entity.Property(e => e.DescriptionPicking).HasColumnName("description_picking");
                entity.Property(e => e.GroupId).HasColumnName("group_id");
                entity.Property(e => e.IsDone).HasColumnName("is_done");
                entity.Property(e => e.IsInventory).HasColumnName("is_inventory");
                entity.Property(e => e.LocationDestId).HasColumnName("location_dest_id");
                entity.Property(e => e.LocationId).HasColumnName("location_id");
                entity.Property(e => e.ManualConsumption).HasColumnName("manual_consumption");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.NextSerial).HasColumnName("next_serial");
                entity.Property(e => e.NextSerialCount).HasColumnName("next_serial_count");
                entity.Property(e => e.OperationId).HasColumnName("operation_id");
                entity.Property(e => e.OrderFinishedLotId).HasColumnName("order_finished_lot_id");
                entity.Property(e => e.OrderpointId).HasColumnName("orderpoint_id");
                entity.Property(e => e.Origin).HasColumnName("origin");
                entity.Property(e => e.OriginReturnedMoveId).HasColumnName("origin_returned_move_id");
                entity.Property(e => e.PackageLevelId).HasColumnName("package_level_id");
                entity.Property(e => e.PartnerId).HasColumnName("partner_id");
                entity.Property(e => e.PickingId).HasColumnName("picking_id");
                entity.Property(e => e.PickingTypeId).HasColumnName("picking_type_id");
                entity.Property(e => e.PriceUnit).HasColumnName("price_unit");
                entity.Property(e => e.Priority).HasColumnName("priority");
                entity.Property(e => e.ProcureMethod).HasColumnName("procure_method");
                entity.Property(e => e.ProductId).HasColumnName("product_id");
                entity.Property(e => e.ProductPackagingId).HasColumnName("product_packaging_id");
                entity.Property(e => e.ProductQty).HasColumnName("product_qty");
                entity.Property(e => e.ProductUom).HasColumnName("product_uom");
                entity.Property(e => e.ProductUomQty).HasColumnName("product_uom_qty");
                entity.Property(e => e.ProductionId).HasColumnName("production_id");
                entity.Property(e => e.PropagateCancel).HasColumnName("propagate_cancel");
                entity.Property(e => e.PurchaseLineId).HasColumnName("purchase_line_id");
                entity.Property(e => e.QuantityDone).HasColumnName("quantity_done");
                entity.Property(e => e.RawMaterialProductionId).HasColumnName("raw_material_production_id");
                entity.Property(e => e.Reference).HasColumnName("reference");
                entity.Property(e => e.RepairId).HasColumnName("repair_id");
                entity.Property(e => e.ReservationDate).HasColumnName("reservation_date");
                entity.Property(e => e.RestrictPartnerId).HasColumnName("restrict_partner_id");
                entity.Property(e => e.RuleId).HasColumnName("rule_id");
                entity.Property(e => e.SaleLineId).HasColumnName("sale_line_id");
                entity.Property(e => e.Scrapped).HasColumnName("scrapped");
                entity.Property(e => e.Sequence)
                    .HasColumnName("sequence");
                entity.Property(e => e.State).HasColumnName("state");
                entity.Property(e => e.ToRefund).HasColumnName("to_refund");
                entity.Property(e => e.UnbuildId).HasColumnName("unbuild_id");
                entity.Property(e => e.UnitFactor).HasColumnName("unit_factor");
                entity.Property(e => e.WarehouseId).HasColumnName("warehouse_id");
                entity.Property(e => e.WorkorderId).HasColumnName("workorder_id");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne(d => d.AnalyticAccountLine).WithMany()
                    .HasForeignKey(d => d.AnalyticAccountLineId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_move_analytic_account_line_id_fkey");

                entity.HasOne(d => d.BomLine).WithMany(p => p.StockMoves)
                    .HasForeignKey(d => d.BomLineId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_move_bom_line_id_fkey");

                entity.HasOne(d => d.Byproduct).WithMany(p => p.StockMoves)
                    .HasForeignKey(d => d.ByproductId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_move_byproduct_id_fkey");

                entity.HasOne<ResCompany>().WithMany()
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("stock_move_company_id_fkey");

                entity.HasOne(d => d.ConsumeUnbuild).WithMany(p => p.StockMoveConsumeUnbuilds)
                    .HasForeignKey(d => d.ConsumeUnbuildId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_move_consume_unbuild_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_move_create_uid_fkey");

                entity.HasOne(d => d.CreatedProduction).WithMany(p => p.StockMoveCreatedProductions)
                    .HasForeignKey(d => d.CreatedProductionId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_move_created_production_id_fkey");

                entity.HasOne(d => d.CreatedPurchaseLine).WithMany(p => p.StockMoveCreatedPurchaseLines)
                    .HasForeignKey(d => d.CreatedPurchaseLineId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_move_created_purchase_line_id_fkey");

                entity.HasOne(d => d.Group).WithMany(p => p.StockMoves)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_move_group_id_fkey");

                entity.HasOne(d => d.LocationDest).WithMany(p => p.StockMoveLocationDests)
                    .HasForeignKey(d => d.LocationDestId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("stock_move_location_dest_id_fkey");

                entity.HasOne(d => d.Location).WithMany(p => p.StockMoveLocations)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("stock_move_location_id_fkey");

                entity.HasOne(d => d.Operation).WithMany(p => p.StockMoves)
                    .HasForeignKey(d => d.OperationId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_move_operation_id_fkey");

                entity.HasOne(d => d.OrderFinishedLot).WithMany(p => p.StockMoves)
                    .HasForeignKey(d => d.OrderFinishedLotId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_move_order_finished_lot_id_fkey");

                entity.HasOne(d => d.Orderpoint).WithMany(p => p.StockMoves)
                    .HasForeignKey(d => d.OrderpointId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_move_orderpoint_id_fkey");

                entity.HasOne(d => d.OriginReturnedMove).WithMany(p => p.InverseOriginReturnedMove)
                    .HasForeignKey(d => d.OriginReturnedMoveId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_move_origin_returned_move_id_fkey");

                entity.HasOne(d => d.PackageLevel).WithMany(p => p.StockMoves)
                    .HasForeignKey(d => d.PackageLevelId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_move_package_level_id_fkey");

                entity.HasOne<ResPartner>().WithMany()
                    .HasForeignKey(d => d.PartnerId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_move_partner_id_fkey");

                entity.HasOne(d => d.Picking).WithMany(p => p.StockMoves)
                    .HasForeignKey(d => d.PickingId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_move_picking_id_fkey");

                entity.HasOne(d => d.PickingType).WithMany(p => p.StockMoves)
                    .HasForeignKey(d => d.PickingTypeId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_move_picking_type_id_fkey");

                entity.HasOne(d => d.Product).WithMany(p => p.StockMoves)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("stock_move_product_id_fkey");

                entity.HasOne(d => d.ProductPackaging).WithMany(p => p.StockMoves)
                    .HasForeignKey(d => d.ProductPackagingId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_move_product_packaging_id_fkey");

                entity.HasOne(d => d.ProductUomNavigation).WithMany(p => p.StockMoves)
                    .HasForeignKey(d => d.ProductUom)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("stock_move_product_uom_fkey");

                entity.HasOne(d => d.Production).WithMany(p => p.StockMoveProductions)
                    .HasForeignKey(d => d.ProductionId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_move_production_id_fkey");

                entity.HasOne(d => d.PurchaseLine).WithMany(p => p.StockMovePurchaseLines)
                    .HasForeignKey(d => d.PurchaseLineId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_move_purchase_line_id_fkey");

                entity.HasOne(d => d.RawMaterialProduction).WithMany(p => p.StockMoveRawMaterialProductions)
                    .HasForeignKey(d => d.RawMaterialProductionId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_move_raw_material_production_id_fkey");

                entity.HasOne(d => d.Repair).WithMany(p => p.StockMoves)
                    .HasForeignKey(d => d.RepairId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_move_repair_id_fkey");

                entity.HasOne(d => d.RestrictPartner).WithMany(p => p.StockMoveRestrictPartners)
                    .HasForeignKey(d => d.RestrictPartnerId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_move_restrict_partner_id_fkey");

                entity.HasOne(d => d.Rule).WithMany(p => p.StockMoves)
                    .HasForeignKey(d => d.RuleId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("stock_move_rule_id_fkey");

                entity.HasOne(d => d.SaleLine).WithMany(p => p.StockMoves)
                    .HasForeignKey(d => d.SaleLineId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_move_sale_line_id_fkey");

                entity.HasOne(d => d.Unbuild).WithMany(p => p.StockMoveUnbuilds)
                    .HasForeignKey(d => d.UnbuildId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_move_unbuild_id_fkey");

                entity.HasOne(d => d.Warehouse).WithMany(p => p.StockMoves)
                    .HasForeignKey(d => d.WarehouseId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_move_warehouse_id_fkey");

                entity.HasOne(d => d.Workorder).WithMany(p => p.StockMoves)
                    .HasForeignKey(d => d.WorkorderId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_move_workorder_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_move_write_uid_fkey");
                /*
                //entity.HasMany(d => d.MoveDests).WithMany(p => p.MoveOrigs)
                entity.HasMany<StockMove>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "StockMoveMoveRel",
                        r => r.HasOne<StockMove>().WithMany()
                            .HasForeignKey("MoveDestId")
                            .HasConstraintName("stock_move_move_rel_move_dest_id_fkey"),
                        l => l.HasOne<StockMove>().WithMany()
                            .HasForeignKey("MoveOrigId")
                            .HasConstraintName("stock_move_move_rel_move_orig_id_fkey"),
                        j =>
                        {
                            j.HasKey("MoveOrigId", "MoveDestId").HasName("stock_move_move_rel_pkey");
                            j.ToTable("stock_move_move_rel");
                            j.HasIndex(new[] { "MoveDestId", "MoveOrigId" }, "stock_move_move_rel_move_dest_id_move_orig_id_idx");
                        });

                //entity.HasMany(d => d.MoveOrigs).WithMany(p => p.MoveDests)
                entity.HasMany<StockMove>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "StockMoveMoveRel",
                        r => r.HasOne<StockMove>().WithMany()
                            .HasForeignKey("MoveOrigId")
                            .HasConstraintName("stock_move_move_rel_move_orig_id_fkey"),
                        l => l.HasOne<StockMove>().WithMany()
                            .HasForeignKey("MoveDestId")
                            .HasConstraintName("stock_move_move_rel_move_dest_id_fkey"),
                        j =>
                        {
                            j.HasKey("MoveOrigId", "MoveDestId").HasName("stock_move_move_rel_pkey");
                            j.ToTable("stock_move_move_rel");
                            j.HasIndex(new[] { "MoveDestId", "MoveOrigId" }, "stock_move_move_rel_move_dest_id_move_orig_id_idx");
                        });

                //entity.HasMany(d => d.Routes).WithMany(p => p.Moves)
                entity.HasMany<StockRoute>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "StockRouteMove",
                        r => r.HasOne<StockRoute>().WithMany()
                            .HasForeignKey("RouteId")
                            .HasConstraintName("stock_route_move_route_id_fkey"),
                        l => l.HasOne<StockMove>().WithMany()
                            .HasForeignKey("MoveId")
                            .HasConstraintName("stock_route_move_move_id_fkey"),
                        j =>
                        {
                            j.HasKey("MoveId", "RouteId").HasName("stock_route_move_pkey");
                            j.ToTable("stock_route_move");
                            j.HasIndex(new[] { "RouteId", "MoveId" }, "stock_route_move_route_id_move_id_idx");
                        });
                */

                entity.HasMany(d => d.AccountAnalyticLines).WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "AccountAnalyticLineStockMoveRel",
                        r => r.HasOne<AccountAnalyticLine>().WithMany()
                            .HasForeignKey("AccountAnalyticLineId")
                            .HasConstraintName("account_analytic_line_stock_move__account_analytic_line_id_fkey"),
                        l => l.HasOne<StockMove>().WithMany()
                            .HasForeignKey("StockMoveId")
                            .HasConstraintName("account_analytic_line_stock_move_rel_stock_move_id_fkey"),
                        j =>
                        {
                            j.HasKey("StockMoveId", "AccountAnalyticLineId").HasName("account_analytic_line_stock_move_rel_pkey");
                            j.ToTable("account_analytic_line_stock_move_rel");
                            j.HasIndex(new[] { "AccountAnalyticLineId", "StockMoveId" }, "account_analytic_line_stock_m_account_analytic_line_id_stoc_idx");
                            j.IndexerProperty<Guid>("StockMoveId").HasColumnName("stock_move_id");
                            j.IndexerProperty<Guid>("AccountAnalyticLineId").HasColumnName("account_analytic_line_id");
                        });

                entity.HasMany(d => d.MoveDests).WithMany(p => p.MoveOrigs)
                    .UsingEntity<Dictionary<string, object>>(
                        "StockMoveMoveRel",
                        r => r.HasOne<StockMove>().WithMany()
                            .HasForeignKey("MoveDestId")
                            .HasConstraintName("stock_move_move_rel_move_dest_id_fkey"),
                        l => l.HasOne<StockMove>().WithMany()
                            .HasForeignKey("MoveOrigId")
                            .HasConstraintName("stock_move_move_rel_move_orig_id_fkey"),
                        j =>
                        {
                            j.HasKey("MoveOrigId", "MoveDestId").HasName("stock_move_move_rel_pkey");
                            j.ToTable("stock_move_move_rel");
                            j.HasIndex(new[] { "MoveDestId", "MoveOrigId" }, "stock_move_move_rel_move_dest_id_move_orig_id_idx");
                            j.IndexerProperty<Guid>("MoveOrigId").HasColumnName("move_orig_id");
                            j.IndexerProperty<Guid>("MoveDestId").HasColumnName("move_dest_id");
                        });

                entity.HasMany(d => d.MoveOrigs).WithMany(p => p.MoveDests)
                    .UsingEntity<Dictionary<string, object>>(
                        "StockMoveMoveRel",
                        r => r.HasOne<StockMove>().WithMany()
                            .HasForeignKey("MoveOrigId")
                            .HasConstraintName("stock_move_move_rel_move_orig_id_fkey"),
                        l => l.HasOne<StockMove>().WithMany()
                            .HasForeignKey("MoveDestId")
                            .HasConstraintName("stock_move_move_rel_move_dest_id_fkey"),
                        j =>
                        {
                            j.HasKey("MoveOrigId", "MoveDestId").HasName("stock_move_move_rel_pkey");
                            j.ToTable("stock_move_move_rel");
                            j.HasIndex(new[] { "MoveDestId", "MoveOrigId" }, "stock_move_move_rel_move_dest_id_move_orig_id_idx");
                            j.IndexerProperty<Guid>("MoveOrigId").HasColumnName("move_orig_id");
                            j.IndexerProperty<Guid>("MoveDestId").HasColumnName("move_dest_id");
                        });

                entity.HasMany(d => d.Routes).WithMany(p => p.Moves)
                    .UsingEntity<Dictionary<string, object>>(
                        "StockRouteMove",
                        r => r.HasOne<StockRoute>().WithMany()
                            .HasForeignKey("RouteId")
                            .HasConstraintName("stock_route_move_route_id_fkey"),
                        l => l.HasOne<StockMove>().WithMany()
                            .HasForeignKey("MoveId")
                            .HasConstraintName("stock_route_move_move_id_fkey"),
                        j =>
                        {
                            j.HasKey("MoveId", "RouteId").HasName("stock_route_move_pkey");
                            j.ToTable("stock_route_move");
                            j.HasIndex(new[] { "RouteId", "MoveId" }, "stock_route_move_route_id_move_id_idx");
                            j.IndexerProperty<Guid>("MoveId").HasColumnName("move_id");
                            j.IndexerProperty<Guid>("RouteId").HasColumnName("route_id");
                        });

                entity.HasMany(d => d.TemplateAttributeValues).WithMany(p => p.Moves)
                    .UsingEntity<Dictionary<string, object>>(
                        "TemplateAttributeValueStockMoveRel",
                        r => r.HasOne<ProductTemplateAttributeValue>().WithMany()
                            .HasForeignKey("TemplateAttributeValueId")
                            .HasConstraintName("template_attribute_value_stock_template_attribute_value_id_fkey"),
                        l => l.HasOne<StockMove>().WithMany()
                            .HasForeignKey("MoveId")
                            .HasConstraintName("template_attribute_value_stock_move_rel_move_id_fkey"),
                        j =>
                        {
                            j.HasKey("MoveId", "TemplateAttributeValueId").HasName("template_attribute_value_stock_move_rel_pkey");
                            j.ToTable("template_attribute_value_stock_move_rel");
                            j.HasIndex(new[] { "TemplateAttributeValueId", "MoveId" }, "template_attribute_value_stoc_template_attribute_value_id_m_idx");
                            j.IndexerProperty<Guid>("MoveId").HasColumnName("move_id");
                            j.IndexerProperty<Guid>("TemplateAttributeValueId").HasColumnName("template_attribute_value_id");
                        });
            });
        }
    }
}