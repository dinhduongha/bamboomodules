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
        public static void ConfigureStockWarehouse(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StockWarehouse>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("stock_warehouse_pkey");

                entity.ToTable("stock_warehouse");

                entity.HasIndex(e => new { e.TenantId, e.Code }, "stock_warehouse_warehouse_code_uniq").IsUnique();

                entity.HasIndex(e => new { e.TenantId, e.Name }, "stock_warehouse_warehouse_name_uniq").IsUnique();

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.Active).HasColumnName("active");
                entity.Property(e => e.BuyPullId).HasColumnName("buy_pull_id");
                entity.Property(e => e.BuyToResupply).HasColumnName("buy_to_resupply");
                entity.Property(e => e.Code).HasColumnName("code");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.CrossdockRouteId).HasColumnName("crossdock_route_id");
                entity.Property(e => e.DeliveryRouteId).HasColumnName("delivery_route_id");
                entity.Property(e => e.DeliverySteps).HasColumnName("delivery_steps");
                entity.Property(e => e.InTypeId).HasColumnName("in_type_id");
                entity.Property(e => e.IntTypeId).HasColumnName("int_type_id");
                entity.Property(e => e.LotStockId).HasColumnName("lot_stock_id");
                entity.Property(e => e.ManuTypeId).HasColumnName("manu_type_id");
                entity.Property(e => e.ManufactureMtoPullId).HasColumnName("manufacture_mto_pull_id");
                entity.Property(e => e.ManufacturePullId).HasColumnName("manufacture_pull_id");
                entity.Property(e => e.ManufactureSteps).HasColumnName("manufacture_steps");
                entity.Property(e => e.ManufactureToResupply).HasColumnName("manufacture_to_resupply");
                entity.Property(e => e.MtoPullId).HasColumnName("mto_pull_id");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.OutTypeId).HasColumnName("out_type_id");
                entity.Property(e => e.PackTypeId).HasColumnName("pack_type_id");
                entity.Property(e => e.PartnerId).HasColumnName("partner_id");
                entity.Property(e => e.PbmLocId).HasColumnName("pbm_loc_id");
                entity.Property(e => e.PbmMtoPullId).HasColumnName("pbm_mto_pull_id");
                entity.Property(e => e.PbmRouteId).HasColumnName("pbm_route_id");
                entity.Property(e => e.PbmTypeId).HasColumnName("pbm_type_id");
                entity.Property(e => e.PickTypeId).HasColumnName("pick_type_id");
                entity.Property(e => e.PosTypeId).HasColumnName("pos_type_id");
                entity.Property(e => e.ReceptionRouteId).HasColumnName("reception_route_id");
                entity.Property(e => e.ReceptionSteps).HasColumnName("reception_steps");
                entity.Property(e => e.ReturnTypeId).HasColumnName("return_type_id");
                entity.Property(e => e.SamLocId).HasColumnName("sam_loc_id");
                entity.Property(e => e.SamRuleId).HasColumnName("sam_rule_id");
                entity.Property(e => e.SamTypeId).HasColumnName("sam_type_id");
                entity.Property(e => e.Sequence)
                    .HasColumnName("sequence");
                entity.Property(e => e.ViewLocationId).HasColumnName("view_location_id");
                entity.Property(e => e.WhInputStockLocId).HasColumnName("wh_input_stock_loc_id");
                entity.Property(e => e.WhOutputStockLocId).HasColumnName("wh_output_stock_loc_id");
                entity.Property(e => e.WhPackStockLocId).HasColumnName("wh_pack_stock_loc_id");
                entity.Property(e => e.WhQcStockLocId).HasColumnName("wh_qc_stock_loc_id");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne(d => d.BuyPull).WithMany(p => p.StockWarehouseBuyPulls)
                    .HasForeignKey(d => d.BuyPullId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_warehouse_buy_pull_id_fkey");

                entity.HasOne<ResCompany>().WithMany()
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("stock_warehouse_company_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_warehouse_create_uid_fkey");

                entity.HasOne(d => d.CrossdockRoute).WithMany(p => p.StockWarehouseCrossdockRoutes)
                    .HasForeignKey(d => d.CrossdockRouteId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("stock_warehouse_crossdock_route_id_fkey");

                entity.HasOne(d => d.DeliveryRoute).WithMany(p => p.StockWarehouseDeliveryRoutes)
                    .HasForeignKey(d => d.DeliveryRouteId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("stock_warehouse_delivery_route_id_fkey");

                entity.HasOne(d => d.InType).WithMany(p => p.StockWarehouseInTypes)
                    .HasForeignKey(d => d.InTypeId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_warehouse_in_type_id_fkey");

                entity.HasOne(d => d.IntType).WithMany(p => p.StockWarehouseIntTypes)
                    .HasForeignKey(d => d.IntTypeId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_warehouse_int_type_id_fkey");

                entity.HasOne(d => d.LotStock).WithMany(p => p.StockWarehouseLotStocks)
                    .HasForeignKey(d => d.LotStockId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("stock_warehouse_lot_stock_id_fkey");

                entity.HasOne(d => d.ManuType).WithMany(p => p.StockWarehouseManuTypes)
                    .HasForeignKey(d => d.ManuTypeId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_warehouse_manu_type_id_fkey");

                entity.HasOne(d => d.ManufactureMtoPull).WithMany(p => p.StockWarehouseManufactureMtoPulls)
                    .HasForeignKey(d => d.ManufactureMtoPullId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_warehouse_manufacture_mto_pull_id_fkey");

                entity.HasOne(d => d.ManufacturePull).WithMany(p => p.StockWarehouseManufacturePulls)
                    .HasForeignKey(d => d.ManufacturePullId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_warehouse_manufacture_pull_id_fkey");

                entity.HasOne(d => d.MtoPull).WithMany(p => p.StockWarehouseMtoPulls)
                    .HasForeignKey(d => d.MtoPullId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_warehouse_mto_pull_id_fkey");

                entity.HasOne(d => d.OutType).WithMany(p => p.StockWarehouseOutTypes)
                    .HasForeignKey(d => d.OutTypeId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_warehouse_out_type_id_fkey");

                entity.HasOne(d => d.PackType).WithMany(p => p.StockWarehousePackTypes)
                    .HasForeignKey(d => d.PackTypeId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_warehouse_pack_type_id_fkey");

                entity.HasOne<ResPartner>().WithMany()
                    .HasForeignKey(d => d.PartnerId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_warehouse_partner_id_fkey");

                entity.HasOne(d => d.PbmLoc).WithMany(p => p.StockWarehousePbmLocs)
                    .HasForeignKey(d => d.PbmLocId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_warehouse_pbm_loc_id_fkey");

                entity.HasOne(d => d.PbmMtoPull).WithMany(p => p.StockWarehousePbmMtoPulls)
                    .HasForeignKey(d => d.PbmMtoPullId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_warehouse_pbm_mto_pull_id_fkey");

                entity.HasOne(d => d.PbmRoute).WithMany(p => p.StockWarehousePbmRoutes)
                    .HasForeignKey(d => d.PbmRouteId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("stock_warehouse_pbm_route_id_fkey");

                entity.HasOne(d => d.PbmType).WithMany(p => p.StockWarehousePbmTypes)
                    .HasForeignKey(d => d.PbmTypeId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_warehouse_pbm_type_id_fkey");

                entity.HasOne(d => d.PickType).WithMany(p => p.StockWarehousePickTypes)
                    .HasForeignKey(d => d.PickTypeId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_warehouse_pick_type_id_fkey");

                entity.HasOne(d => d.PosType).WithMany(p => p.StockWarehousePosTypes)
                    .HasForeignKey(d => d.PosTypeId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_warehouse_pos_type_id_fkey");

                entity.HasOne(d => d.ReceptionRoute).WithMany(p => p.StockWarehouseReceptionRoutes)
                    .HasForeignKey(d => d.ReceptionRouteId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("stock_warehouse_reception_route_id_fkey");

                entity.HasOne(d => d.ReturnType).WithMany(p => p.StockWarehouseReturnTypes)
                    .HasForeignKey(d => d.ReturnTypeId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_warehouse_return_type_id_fkey");

                entity.HasOne(d => d.SamLoc).WithMany(p => p.StockWarehouseSamLocs)
                    .HasForeignKey(d => d.SamLocId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_warehouse_sam_loc_id_fkey");

                entity.HasOne(d => d.SamRule).WithMany(p => p.StockWarehouseSamRules)
                    .HasForeignKey(d => d.SamRuleId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_warehouse_sam_rule_id_fkey");

                entity.HasOne(d => d.SamType).WithMany(p => p.StockWarehouseSamTypes)
                    .HasForeignKey(d => d.SamTypeId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_warehouse_sam_type_id_fkey");

                entity.HasOne(d => d.ViewLocation).WithMany(p => p.StockWarehouseViewLocations)
                    .HasForeignKey(d => d.ViewLocationId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("stock_warehouse_view_location_id_fkey");

                entity.HasOne(d => d.WhInputStockLoc).WithMany(p => p.StockWarehouseWhInputStockLocs)
                    .HasForeignKey(d => d.WhInputStockLocId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_warehouse_wh_input_stock_loc_id_fkey");

                entity.HasOne(d => d.WhOutputStockLoc).WithMany(p => p.StockWarehouseWhOutputStockLocs)
                    .HasForeignKey(d => d.WhOutputStockLocId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_warehouse_wh_output_stock_loc_id_fkey");

                entity.HasOne(d => d.WhPackStockLoc).WithMany(p => p.StockWarehouseWhPackStockLocs)
                    .HasForeignKey(d => d.WhPackStockLocId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_warehouse_wh_pack_stock_loc_id_fkey");

                entity.HasOne(d => d.WhQcStockLoc).WithMany(p => p.StockWarehouseWhQcStockLocs)
                    .HasForeignKey(d => d.WhQcStockLocId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_warehouse_wh_qc_stock_loc_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_warehouse_write_uid_fkey");

                //entity.HasMany(d => d.SuppliedWhs).WithMany(p => p.SupplierWhs)
                entity.HasMany<StockWarehouse>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "StockWhResupplyTable",
                        r => r.HasOne<StockWarehouse>().WithMany()
                            .HasForeignKey("SuppliedWhId")
                            .HasConstraintName("stock_wh_resupply_table_supplied_wh_id_fkey"),
                        l => l.HasOne<StockWarehouse>().WithMany()
                            .HasForeignKey("SupplierWhId")
                            .HasConstraintName("stock_wh_resupply_table_supplier_wh_id_fkey"),
                        j =>
                        {
                            j.HasKey("SuppliedWhId", "SupplierWhId").HasName("stock_wh_resupply_table_pkey");
                            j.ToTable("stock_wh_resupply_table");
                            j.HasIndex(new[] { "SupplierWhId", "SuppliedWhId" }, "stock_wh_resupply_table_supplier_wh_id_supplied_wh_id_idx");
                        });

                //entity.HasMany(d => d.SupplierWhs).WithMany(p => p.SuppliedWhs)
                entity.HasMany<StockWarehouse>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "StockWhResupplyTable",
                        r => r.HasOne<StockWarehouse>().WithMany()
                            .HasForeignKey("SupplierWhId")
                            .HasConstraintName("stock_wh_resupply_table_supplier_wh_id_fkey"),
                        l => l.HasOne<StockWarehouse>().WithMany()
                            .HasForeignKey("SuppliedWhId")
                            .HasConstraintName("stock_wh_resupply_table_supplied_wh_id_fkey"),
                        j =>
                        {
                            j.HasKey("SuppliedWhId", "SupplierWhId").HasName("stock_wh_resupply_table_pkey");
                            j.ToTable("stock_wh_resupply_table");
                            j.HasIndex(new[] { "SupplierWhId", "SuppliedWhId" }, "stock_wh_resupply_table_supplier_wh_id_supplied_wh_id_idx");
                        });
            });
        }
    }
}